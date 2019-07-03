using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.gui.HIS;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.BIHOrder
{
    class clsCtl_OrderNurseConfirm : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量声名
        clsDcl_ExecuteOrder m_objManage = null;
        clsDcl_InputOrder m_objInputOrder = null;
        DataTable m_dtChargeList;
        DataTable m_dtExecOrder;
        ArrayList m_arrBedIdList = null;//为快捷键上下按床号选中医嘱用
        public int m_intBedIndex = -1;//为快捷键上下按床号选中医嘱用 -1为不是快捷键方式，其它为快捷键方式
        public bool m_blBedIdKey = false;//为快捷键上下按床号选中医嘱用(false-不是快捷键方式,true-快捷键方式)
        /// <summary>
        /// 审核状态选择项0-全部,1-未审核,2-已审核
        /// </summary>
        int m_intState = -1;
        /// <summary>
        /// 医嘱类型列表
        /// </summary>
        public Hashtable m_htOrderCate = new Hashtable();
        /// <summary>
        /// 住院基本配置表VO
        /// </summary>
        public clsSPECORDERCATE m_objSpecateVo;
        /// <summary>
        /// 提交是否需要审核
        /// </summary>
        bool m_blNeedComfirm = false;
        /// <summary>
        /// 执行是否需要审核
        /// </summary>
        bool m_blExeConfirm = false;
        /// <summary>
        /// '1038', '住院转抄界面是否显示审核提醒', '0-否；1-是'
        /// </summary>
        internal bool m_blNeedMessageAlert = false;
        /// <summary>
        /// '1039', '住院转抄界面审核提醒显示间隔时间', '单位:秒', 10,
        /// </summary>
        int m_intMessageOpenTime = 0;
        /// <summary>
        /// '1040', '住院转抄界面审核提醒窗体显示停留时间', '单位:秒', 5, 
        /// </summary>
        int m_intMessageCloseTime = 0;
        /// <summary>
        /// 1018欠费病人药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额
        /// </summary>
        decimal m_dmlMedOCMin = 0;
        /// <summary>
        /// 1019欠费病人非药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额
        /// </summary>
        decimal m_dmlNoMedOCMin = 0;
        /// <summary>
        /// 1020普通病人药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额
        /// </summary>
        decimal m_dmlMedICMin = 0;
        /// <summary>
        /// 1021普通病人非药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额
        /// </summary>
        decimal m_dmlNoMedICMin = 0;
        /// <summary>
        /// '1030', '控制护士执行模块是否允许欠费病人执行医嘱', '0-不允许 1-允许'
        /// </summary>
        bool m_blMoneyControl = false;
        /// <summary>
        /// '1046', '允许欠费执行时且病人将欠费时的病人费用提示开关', '0-不提示 1-提示'
        /// </summary>
        bool m_blLessExecuteAlert = false;
        /// <summary>
        /// '1047', '医嘱执行界面是否允许自行选择医嘱执行开关', '0-不允许 1-允许'
        /// </summary>
        bool m_blCanSelectOrder = false;
        /// <summary>
        /// '1049', '控制诊疗项目对应关联收费项目（一对多）是否摆药',  '0-不摆药 1-摆药' 
        /// </summary>
        public bool m_blPutMedicineFormDic = false;
        /// <summary>
        /// "4006"设置为8，则组合中检验（发票分类为检验）收费项目>8个时启用打折功能
        /// </summary>
        public int m_intLisDiscountNum = 0;
        /// <summary>
        /// 4007设置启用打折功能时，检验收费项目的打折比例。80，则打八折
        /// </summary>
        public decimal m_decLisDiscountMount = 100;
        /// <summary>
        /// 4008  0-false不打折 1-true 允许打折
        /// </summary>
        public bool m_blLisDiscount = false;
        /// <summary>
        /// 医嘱录入是否可以录入已停用的收费项目 0-否,1-是 1037
        /// </summary>
        public bool m_blStopControl = false;
        /// <summary>
        /// 医嘱录入是否可以录入缺药的收费项目 0-否，1-是 1036
        /// </summary>
        public bool m_blDeableMedControl = false;
        /// <summary>
        ///'1053', '住院医嘱录入界面是否自动提示当前病人存在停用或缺药的未停医嘱', '0-否；1-是', 1, '0010' 
        /// </summary>
        public bool m_blAutoStopAlert = false;
        /// <summary>
        /// 发送检验医嘱开关， false=执行时发送， true=提交时发送
        /// '1050' 检验医嘱在执行还是在提交时发送检验申请单；  0-执行时发送 1-提交时发送
        /// 2010/8/26 shichun.chen
        /// </summary>
        public bool m_blSendLisBill = false;
        /// <summary>
        /// 药品让利类型,对应系统参数,9003 
        /// </summary>
        public string m_strDiffMedicineType = string.Empty;
        /// <summary>
        /// 当前病人列表对象
        /// </summary>
        public Hashtable m_htPatientVos = new Hashtable();
        System.Drawing.Color FeedColor = System.Drawing.Color.Green; //需要皮试的项目颜色

        /// <summary>
        /// 是否启用预发药默认1天
        /// </summary>
        bool isUsePretestMed { get; set; }

        #endregion

        #region 构造函数
        public clsCtl_OrderNurseConfirm()
        {
            m_objManage = new clsDcl_ExecuteOrder();
            m_objInputOrder = new clsDcl_InputOrder();

        }
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.BIHOrder.frmOrderNurseConfirm m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmOrderNurseConfirm)frmMDI_Child_Base_in;

        }
        #endregion

        #region 病区事件
        public void m_txtAreaInitListView(System.Windows.Forms.ListView lvwList)
        {
            lvwList.Columns.Add("病区编号", 60, HorizontalAlignment.Left);
            lvwList.Columns.Add("病区名称", 90, HorizontalAlignment.Left);
            lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvwList.Width = 170;
        }
        public void m_txtAreaFindItem(string strFindCode, System.Windows.Forms.ListView lvwList)
        {
            clsBIHArea[] objItemArr;
            long lngRes = m_objInputOrder.m_lngFindArea(strFindCode, out objItemArr);
            if (lngRes > 0 && objItemArr != null && objItemArr.Length > 0)
            {
                //获取有权限访问的病区ID集合
                if (m_objViewer.LoginInfo != null)
                {
                    IList ilUsableAreaID = m_objViewer.LoginInfo.m_ilUsableAreaID;
                    clsDcl_InputOrder objInputOrder = new clsDcl_InputOrder();
                    objItemArr = (clsBIHArea[])(objInputOrder.GetUsableAreaObject(objItemArr, ilUsableAreaID)).ToArray(typeof(clsBIHArea));
                }
                for (int i = 0; i < objItemArr.Length; i++)
                {
                    /** @update by xzf (05-09-20) 
                     * 
                     */
                    //@ListViewItem lvi=lvwList.Items.Add(objItemArr[i].m_strAreaID);
                    ListViewItem lvi = lvwList.Items.Add(objItemArr[i].code);
                    lvi.SubItems.Add(objItemArr[i].m_strAreaName);
                    lvi.Tag = objItemArr[i].m_strAreaID;
                    /* <<======================== */
                }
            }
        }
        public void m_txtAreaSelectItem(System.Windows.Forms.ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {
                m_objViewer.m_txtArea.Text = lviSelected.SubItems[1].Text;
                m_objViewer.m_txtArea.Tag = lviSelected.Tag;
                this.m_objViewer.Cursor = Cursors.WaitCursor;
                LoadTheDate();
                this.m_objViewer.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 界面导入当前病区数据
        /// </summary>
        internal void LoadTheDate()
        {
            if (m_objViewer.m_txtArea.Tag == null || ((string)m_objViewer.m_txtArea.Tag).Trim().Equals(""))
            {
                MessageBox.Show("病区必须选！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtArea.Focus();
                return;
            }
            this.m_objViewer.m_dtvChangeList.Rows.Clear();
            this.m_objViewer.m_txtChargeSum.Text = "";
            this.m_objViewer.m_txtSameCharge.Text = "";
            m_htPatientVos.Clear();
            m_intState = getState();
            long lngRes = m_objManage.m_lngGetOrderByArea((string)m_objViewer.m_txtArea.Tag, m_intState, out m_dtExecOrder, out m_dtChargeList);

            bool isBed = (this.m_objViewer.m_cboCode.SelectedIndex == 1 ? true : false);
            refreshTheDataByBed(isBed);
            refreshTheDataByFeel();
            ControlTheButton();
        }

        /// <summary>
        /// 皮试过滤 当前界面只显示皮试项目
        /// </summary>
        public void refreshTheDataByFeel()
        {
            if (this.m_objViewer.m_chkNeedFeel.Checked == true)
            {
                ArrayList m_arrFeelOrder = new ArrayList();//含用皮试项的方号
                for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
                {
                    if (((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag).m_intISNEEDFEEL == 1)
                    {
                        m_arrFeelOrder.Add((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag);
                    }
                }
                //皮试过滤
                if (m_arrFeelOrder.Count > 0)
                {
                    SetTheNeelSelect(m_arrFeelOrder);

                }
                else
                {
                    this.m_objViewer.m_dtvOrderList.Rows.Clear();
                }

            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 当前新开医嘱病人统计
        /// </summary>
        /// <returns></returns>
        private int GetWaitCfPersonCout()
        {
            int cout = 0;
            ArrayList arr = new ArrayList();
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.Rows.Count; i++)
            {
                string m_strRegisterID = ((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strRegisterID;
                if (((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag).m_intStatus == 1)
                {
                    if (!arr.Contains(m_strRegisterID))
                    {
                        arr.Add(m_strRegisterID);
                    }
                }
            }
            cout = arr.Count;
            return cout;
        }

        /// <summary>
        /// 界面导入当前病区数据
        /// </summary>
        internal void LoadTheDate2(int ColumnIndex)
        {
            int RowIndex = 0;
            if (this.m_objViewer.m_dtvOrderList.SelectedRows.Count > 0)
            {
                RowIndex = this.m_objViewer.m_dtvOrderList.SelectedRows[0].Index;
            }
            DataView myDataView = new DataView(m_dtExecOrder);
            string m_strColumn = GetTheSortColumnName(ColumnIndex);

            myDataView.Sort = m_strColumn;
            if (myDataView.Count <= 0)
            {
                return;
            }
            clsBIHCanExecOrder[] arrExecOrder;
            filltheExecOrderTable(myDataView, out arrExecOrder);
            ResortTheDataGridView(arrExecOrder);

            if (this.m_objViewer.m_dtvOrderList.RowCount > RowIndex)
            {
                this.m_objViewer.m_dtvOrderList.CurrentCell = this.m_objViewer.m_dtvOrderList[ColumnIndex, RowIndex];
            }
            // SelectAll();

        }

        /// <summary>
        /// 重新排序
        /// </summary>
        /// <param name="arrExecOrder"></param>
        public void ResortTheDataGridView(clsBIHCanExecOrder[] arrExecOrder)
        {
            clsBIHCanExecOrder oldExecOrder;
            int j = 0;
            for (int i = 0; i < arrExecOrder.Length; i++)
            {
                j = findTheExecOrder(arrExecOrder[i]);
                ChangeThePosition(i, j);
            }
            //对特别的字段进行排序显示空白控制
            ArrayList m_arrSep = new ArrayList();
            m_arrSep.Add("dtv_CURAREAName");
            m_arrSep.Add("dtv_bedcode");
            m_arrSep.Add("m_dtvLastName");
            RefreshTheSPColumn(m_arrSep);
        }

        /// <summary>
        ///  //对特别的字段进行排序显示空白控制
        /// </summary>
        /// <param name="m_arrSep"></param>
        public void RefreshTheSPColumn(ArrayList m_arrSep)
        {
            string m_strUpRegisterID = "", m_strDownRegisterID = "";
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
            {

                m_strDownRegisterID = ((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strRegisterID;
                if (!m_strUpRegisterID.Equals(m_strDownRegisterID))
                {
                    this.m_objViewer.m_dtvOrderList.Rows[i].Cells["dtv_CURAREAName"].Value = ((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strCURAREAName;
                    this.m_objViewer.m_dtvOrderList.Rows[i].Cells["dtv_bedcode"].Value = ((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strBedName;
                    this.m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvLastName"].Value = ((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strPatientName;
                }
                else
                {
                    this.m_objViewer.m_dtvOrderList.Rows[i].Cells["dtv_CURAREAName"].Value = "";
                    this.m_objViewer.m_dtvOrderList.Rows[i].Cells["dtv_bedcode"].Value = "";
                    this.m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvLastName"].Value = "";
                }
                m_strUpRegisterID = m_strDownRegisterID;
            }
        }

        /// <summary>
        /// 找到相应在医嘱执行对象中的DATAGRIDVIEW的位置
        /// </summary>
        /// <param name="clsBIHCanExecOrder"></param>
        /// <returns></returns>
        public int findTheExecOrder(clsBIHCanExecOrder clsBIHCanExecOrder)
        {
            string m_strOrderID = clsBIHCanExecOrder.m_strOrderID;
            int j = 0;
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
            {
                if (((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strOrderID.Equals(m_strOrderID))
                {
                    j = i;
                    break;
                }
            }
            return j;
        }

        private void ChangeThePosition(int i, int j)
        {
            string m_strValue1, m_strValue2;
            for (int a = 0; a < this.m_objViewer.m_dtvOrderList.ColumnCount; a++)
            {
                m_strValue1 = this.m_objViewer.m_dtvOrderList.Rows[i].Cells[a].Value.ToString().Trim();
                m_strValue2 = this.m_objViewer.m_dtvOrderList.Rows[j].Cells[a].Value.ToString().Trim();
                this.m_objViewer.m_dtvOrderList.Rows[i].Cells[a].Value = m_strValue2;
                this.m_objViewer.m_dtvOrderList.Rows[j].Cells[a].Value = m_strValue1;
            }
            clsBIHCanExecOrder order = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag;
            this.m_objViewer.m_dtvOrderList.Rows[i].Tag = this.m_objViewer.m_dtvOrderList.Rows[j].Tag;
            this.m_objViewer.m_dtvOrderList.Rows[j].Tag = order;
        }

        /// <summary>
        /// 根据列索引得到相应过滤字段名
        /// </summary>
        /// <param name="ColumnIndex"></param>
        /// <returns></returns>
        public string GetTheSortColumnName(int ColumnIndex)
        {
            string m_strColumnBegin = "CURAREAName,code_chr,LASTNAME_VCHR";//对普通字段进行排序
            //string m_strColumnID = "";//对关键的字段进行排序(如床位号及病人)
            string m_strColumn = "";//返回的过渡条件字段
            m_strColumn = this.m_objViewer.m_dtvOrderList.Columns[ColumnIndex].Name;
            switch (m_strColumn)
            {
                case "dtv_bedcode":
                    m_strColumnBegin = "CURAREAName,code_chr";

                    if (this.m_objViewer.m_dtvOrderList.SortOrder == SortOrder.Ascending)
                    {
                        m_strColumnBegin = m_strColumnBegin + " asc";
                    }
                    else
                    {
                        m_strColumnBegin = m_strColumnBegin + " desc";
                    }
                    m_strColumnBegin = m_strColumnBegin + "," + "LASTNAME_VCHR";
                    m_strColumn = "";
                    break;
                case "m_dtvLastName":
                    m_strColumn = "";
                    break;
                case "dtv_RecipeNo":
                    m_strColumn = "recipeno_int";
                    break;
                case "dtv_ExecuteType":
                    m_strColumn = "executetype_int";
                    break;
                case "viewname_vchr":
                    m_strColumn = "viewname_vchr";
                    break;
                case "dtv_Name":
                    m_strColumn = "NAME_VCHR";
                    break;
                case "dtv_Dosage":
                    m_strColumn = "Dosage_Dec";
                    break;
                case "dtv_UseType":
                    m_strColumn = "DOSETYPENAME_CHR";
                    break;
                case "dtv_Freq":
                    m_strColumn = "EXECFREQNAME_CHR";
                    break;
                case "dtv_Get":
                    m_strColumn = "GET_DEC";
                    break;
                case "dtv_ENTRUST":
                    m_strColumn = "ENTRUST_VCHR";
                    break;
                case "DOCTOR_VCHR":
                    m_strColumn = "DOCTOR_VCHR";
                    break;
                case "m_dtvPOSTDATE_DAT":
                    m_strColumn = "POSTDATE_DAT";
                    break;
                case "m_dtvCONFIRMER_VCHR":
                    m_strColumn = "CONFIRMER_VCHR";
                    break;
                case "m_dtvCONFIRM_DAT":
                    m_strColumn = "CONFIRM_DAT";
                    break;
                case "CREATOR_CHR":
                    m_strColumn = "CREATOR_CHR";
                    break;
                case "dtv_NO":
                    m_strColumn = "";
                    break;
                case "dtv_CURAREAName":
                    m_strColumnBegin = "CURAREAName";

                    if (this.m_objViewer.m_dtvOrderList.SortOrder == SortOrder.Ascending)
                    {
                        m_strColumnBegin = m_strColumnBegin + " asc";
                    }
                    else
                    {
                        m_strColumnBegin = m_strColumnBegin + " desc";
                    }

                    m_strColumnBegin = m_strColumnBegin + "," + "code_chr,LASTNAME_VCHR";
                    m_strColumn = "";
                    break;
            }
            if (m_strColumn.Trim().Equals(""))
            {
                m_strColumn = m_strColumnBegin + m_strColumn;
            }
            else
            {
                m_strColumn = m_strColumnBegin + "," + m_strColumn;
            }
            if (this.m_objViewer.m_dtvOrderList.SortOrder == SortOrder.Ascending)
            {
                m_strColumn = m_strColumn + " asc";
            }
            else
            {
                m_strColumn = m_strColumn + " desc";
            }
            return m_strColumn;
        }

        /// <summary>
        /// 新增或修改收费项目时重新提交收费数据
        /// </summary>
        internal void refreshTheChargeDate()
        {
            if (m_objViewer.m_txtArea.Tag == null || ((string)m_objViewer.m_txtArea.Tag).Trim().Equals(""))
            {

                return;
            }
            m_intState = getState();
            long lngRes = m_objManage.m_lngrefreshTheChargeDate((string)m_objViewer.m_txtArea.Tag, m_intState, out m_dtChargeList);

        }

        /// <summary>
        /// 返回当前审核状态选择项
        /// </summary>
        /// <returns></returns>
        private int getState()
        {
            int i = -1;
            if (m_objViewer.m_rdoAll.Checked)
            {
                i = 0;
            }
            else if (m_objViewer.m_rdoNOT.Checked)
            {
                i = 1;
            }
            else if (m_objViewer.m_rdoYET.Checked)
            {
                i = 2;
            }

            return i;
        }
        #endregion

        #region 当前医嘱执行记录选择事件处理
        /// <summary>
        /// 当前医嘱执行记录选择事件处理
        /// </summary>
        internal void OrderListSelect()
        {
            this.m_objViewer.m_txtSameCharge.Text = "";
            this.m_objViewer.m_dtvChangeList.Rows.Clear();
            if (this.m_objViewer.m_dtvOrderList.CurrentCell != null && this.m_objViewer.m_dtvOrderList.RowCount > 0)
            {

                clsBIHCanExecOrder order = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[this.m_objViewer.m_dtvOrderList.CurrentCell.RowIndex].Tag;

                if (order != null)
                {
                    //if (m_dtPatients != null && m_dtPatients.Rows.Count > 0)
                    //{
                    //fillthePatient(order);
                    filltheChargeList(order);
                    decimal m_decSum = m_objInputOrder.GettheChargeSum(order, m_dtChargeList);
                    this.m_objViewer.m_txtChargeSum.Text = "费用总计：" + m_decSum.ToString();
                    m_decSum = m_objInputOrder.GetTheSameChargeSum(order, m_dtChargeList);
                    this.m_objViewer.m_txtSameCharge.Text = "同方费用总计：" + m_decSum.ToString();

                    //}
                    ControlTheButton();
                    TheSameNoRowSelect(order);
                }
            }

        }



        /// <summary>
        /// 同方医嘱一起选中
        /// </summary>
        /// <param name="order"></param>
        private void TheSameNoRowSelect(clsBIHCanExecOrder order)
        {
            string m_strID = order.m_strRegisterID + "," + order.m_intRecipenNo.ToString() + ";";
            string m_strTemp = "";

            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.Rows.Count; i++)
            {
                clsBIHCanExecOrder Exeorder = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag;
                m_strTemp = Exeorder.m_strRegisterID + "," + Exeorder.m_intRecipenNo.ToString() + ";";
                if (m_strTemp.Equals(m_strID))
                {
                    this.m_objViewer.m_dtvOrderList.Rows[i].Selected = true;
                }

            }
            /*<====================================*/
        }


        #endregion

        #region 当前医嘱记录改变时病人改变事件
        /// <summary>
        /// 当前医嘱记录改变时病人改变事件
        /// </summary>
        /// <param name="order"></param>
        private void BindthePatient(clsBIHCanExecOrder order)
        {
            clsBIHPatientInfo m_objPatient = null;
            if (m_htPatientVos.Contains(order.m_strRegisterID))
            {
                m_objPatient = (clsBIHPatientInfo)m_htPatientVos[order.m_strRegisterID];
            }
            else
            {
                DataTable m_dtPatient = null;
                long lngRes = m_objManage.m_lngGetPatientInfoVo(order.m_strRegisterID, out m_dtPatient);
                if (m_dtPatient != null && m_dtPatient.Rows.Count > 0)
                {
                    string m_strInHospitalNoOld = "";
                    string m_strInHospitalNoNow = "";
                    m_strInHospitalNoOld = this.m_objViewer.m_ctlPatient.m_txtRegisterid.Text.Trim();
                    m_strInHospitalNoNow = order.m_strRegisterID.Trim();
                    if (m_strInHospitalNoOld.Equals(m_strInHospitalNoNow))
                    {
                        return;
                    }

                    DataView myDataView = new DataView(m_dtPatient);
                    myDataView.RowFilter = "registerid_chr='" + order.m_strRegisterID + "'";
                    if (myDataView.Count <= 0)
                    {
                        return;
                    }
                    m_mthGetPatientInfoFromDateTable(myDataView, out m_objPatient);
                    m_htPatientVos.Add(order.m_strRegisterID, m_objPatient);
                }
            }
            if (m_objPatient != null)
            {
                this.m_objViewer.m_ctlPatient.m_objPatient = m_objPatient;
                this.m_objViewer.m_ctlPatient.m_mthShowPatient();
            }
        }
        #endregion

        #region 梆定医嘱执行DATAGRIDVIEW
        /// <summary>
        /// 梆定医嘱执行DATAGRIDVIEW
        /// </summary>
        /// <param name="arrExecOrder"></param>
        private void BindTheBihOrderList(clsBIHCanExecOrder[] arrExecOrder)
        {
            m_objViewer.m_dtvOrderList.Rows.Clear();
            if (arrExecOrder != null)
            {
                // 序号（含CheckBox）dtv_NO\床号dtv_bedcode\姓名m_dtvLastName\方号dtv_RecipeNo\医嘱（医嘱方式）dtv_ExecuteType\类别viewname_vchr
                // 项目名称dtv_Name\剂量dtv_Dosage\用法dtv_UseType\频率dtv_Freq\数量dtv_Get\嘱托dtv_ENTRUST\主管医生DOCTOR_VCHR\提交时间m_dtvPOSTDATE_DAT\审核人m_dtvCONFIRMER_VCHR\审核时间 m_dtvCONFIRM_DAT
                DataGridViewRow row = null;
                foreach (clsBIHCanExecOrder item in arrExecOrder)
                {
                    m_objViewer.m_dtvOrderList.Rows.Add();
                    row = m_objViewer.m_dtvOrderList.Rows[m_objViewer.m_dtvOrderList.RowCount - 1];
                    BindTheBihOrderListDetail(row, item);
                }
            }
            refreshTheDataGridView();
            if (m_blAutoStopAlert)
            {
                GetTheStopOrder();
            }
        }

        /// <summary>
        /// 刷新界面主体数据
        /// </summary>
        public void refreshTheDataGridView()
        {
            //刷新相同病人医嘱隐藏相同性质的字段
            m_mthRefreshSamePersionColumn();
            //刷新同方医嘱的方号颜色并隐藏相同性质的字段
            m_mthRefreshSameReqNoColor();
            //编程触发事件
            if (this.m_objViewer.m_dtvOrderList.RowCount > 0)
            {
                this.m_objViewer.m_dtvOrderList.CurrentCell = this.m_objViewer.m_dtvOrderList.Rows[0].Cells[1];
            }
            //当前新开医嘱病人统计
            int cout = GetWaitCfPersonCout();
            this.m_objViewer.m_lblNewOrderCount.Text = "共有 " + cout.ToString() + " 病人有新开的医嘱";
        }

        /// <summary>
        /// 刷新相同病人医嘱隐藏相同性质的字段
        /// </summary>
        internal void m_mthRefreshSamePersionColumn()
        {
            string m_strPreRegister = "";
            for (int i = 0; i < m_objViewer.m_dtvOrderList.RowCount; i++)
            {
                DataGridViewRow row1 = m_objViewer.m_dtvOrderList.Rows[i];
                clsBIHCanExecOrder m_objExecOrder = (clsBIHCanExecOrder)row1.Tag;
                if (m_strPreRegister.Trim().Equals(m_objExecOrder.m_strRegisterID.Trim()))
                {
                    row1.Cells["dtv_bedcode"].Value = "";
                    row1.Cells["m_dtvLastName"].Value = "";
                    row1.Cells["inpatientid"].Value = "";
                    //row1.Cells["dtv_CURAREAName"].Value = "";
                }
                m_strPreRegister = m_objExecOrder.m_strRegisterID;
            }
        }

        /// <summary>
        /// 梆定医嘱执行明细数据
        /// </summary>
        internal void BindTheBihOrderListDetail(DataGridViewRow row, clsBIHCanExecOrder objExecOrder)
        {
            row.Cells["dtv_NO"].Value = Convert.ToString((row.Index + 1));
            //  row.ReadOnly = true;
            decimal m_dmlOneUse = 0;    // 补一次的领量
            if (m_objViewer.m_chkSelectAll.Checked == true)
            {
                row.Cells["m_dtvselectCheck"].Value = "1";
            }
            else
            {
                row.Cells["m_dtvselectCheck"].Value = "0";
            }

            row.Cells["dtv_bedcode"].Value = objExecOrder.m_strBedName;
            row.Cells["m_dtvLastName"].Value = objExecOrder.m_strPatientName;
            row.Cells["inpatientid"].Value = objExecOrder.m_strInpatientID;

            // 医嘱类型
            clsT_aid_bih_ordercate_VO p_objItem = null;
            if (m_htOrderCate.Contains(objExecOrder.m_strOrderDicCateID))
            {
                p_objItem = (clsT_aid_bih_ordercate_VO)m_htOrderCate[objExecOrder.m_strOrderDicCateID];
            }
            if (p_objItem == null)
            {
                if (objExecOrder.m_intTYPE_INT > 0)
                {
                    row.Cells["dtv_Name"].Value = objExecOrder.m_strName.ToString();
                    row.Cells["dtv_Name"].Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                    row.Tag = objExecOrder;
                    return;
                }
            }

            if (objExecOrder.m_intExecuteType == 1)
            {
                // 方
                row.Cells["dtv_RecipeNo"].Value = " " + objExecOrder.m_intRecipenNo2.ToString();
            }
            row.Cells["dtv_ExecuteType"].Value = objExecOrder.m_strExecuteTypeName;
            row.Cells["viewname_vchr"].Value = objExecOrder.m_strOrderDicCateName;
            row.Cells["dtv_Name"].Value = objExecOrder.m_strName;

            row.Cells["dtv_Dosage"].Value = objExecOrder.m_dmlDosageRate.ToString() + objExecOrder.m_strDosageUnit.ToString().Trim();   // 剂量
            row.Cells["dtv_UseType"].Value = objExecOrder.m_strDosetypeName;    // 用药方式
            row.Cells["dtv_Freq"].Value = objExecOrder.m_strExecFreqName;       // 频率
            row.Cells["dtv_Get"].Value = objExecOrder.m_dmlGet.ToString() + objExecOrder.m_strGetunit;
            row.Cells["dtv_ENTRUST"].Value = objExecOrder.m_strEntrust;
            row.Cells["DOCTOR_VCHR"].Value = objExecOrder.m_strDOCTOR_VCHR;
            row.Cells["m_dtvPOSTDATE_DAT"].Value = objExecOrder.m_dtPostdate.ToString();
            row.Cells["m_dtvCONFIRMER_VCHR"].Value = objExecOrder.m_strASSESSORFOREXEC_CHR;
            row.Cells["m_dtvCONFIRM_DAT"].Value = objExecOrder.m_strASSESSORFOREXEC_DAT;
            row.Cells["CREATOR_CHR"].Value = objExecOrder.m_strCreator;
            string m_strCase = "";
            if (objExecOrder.m_intStatus == 1 || objExecOrder.m_intStatus == 5)
            {
                m_strCase = "新";
                row.Cells["dtv_Case"].Style.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                m_strCase = "停";
            }
            row.Cells["dtv_Case"].Value = m_strCase;

            // “方法”列。用于显示检验医嘱的样本类型，和检查医嘱的部位信息
            if (!objExecOrder.m_strPARTID_VCHR.Trim().Equals(""))
            {
                row.Cells["dtv_method"].Value = objExecOrder.m_strPARTNAME_VCHR;
            }
            else if (!objExecOrder.m_strSAMPLEID_VCHR.Trim().Equals(""))
            {
                row.Cells["dtv_method"].Value = objExecOrder.m_strSAMPLEName_VCHR;
            }
            else
            {
                row.Cells["dtv_method"].Value = "";
            }
            // 医嘱说明
            row.Cells["dtv_REMARK"].Value = objExecOrder.m_strREMARK_VCHR.Trim();

            #region 医嘱类型界面处理
            p_objItem = null;
            if (m_htOrderCate.Contains(objExecOrder.m_strOrderDicCateID))
            {
                p_objItem = (clsT_aid_bih_ordercate_VO)m_htOrderCate[objExecOrder.m_strOrderDicCateID];
            }
            if (p_objItem != null)
            {
                if (!objExecOrder.m_strExecFreqID.Trim().Equals(m_objSpecateVo.m_strCONFREQID_CHR.Trim()))  // 连续性医嘱不显示剂量
                {
                    if (p_objItem.m_intDOSAGEVIEWTYPE == 1)
                    {
                        // 用量
                        if (objExecOrder.m_dmlDosage > 0)
                        {
                            row.Cells["dtv_Dosage"].Value = objExecOrder.m_dmlDosage.ToString() + "" + objExecOrder.m_strDosageUnit;
                        }
                        else
                        {
                            row.Cells["dtv_Dosage"].Value = "";
                        }
                    }
                    else
                    {
                        row.Cells["dtv_Dosage"].Value = "";
                    }
                }
                else
                {
                    row.Cells["dtv_Dosage"].Value = "";
                }

                if (!objExecOrder.m_strExecFreqID.Trim().Equals(m_objSpecateVo.m_strCONFREQID_CHR.Trim()))  // 连续性医嘱不显示剂量
                {
                    if (p_objItem.m_intUSAGEVIEWTYPE == 1)
                    {
                        // 用法
                        row.Cells["dtv_UseType"].Value = objExecOrder.m_strDosetypeName;
                    }
                    else
                    {
                        // 用法
                        row.Cells["dtv_UseType"].Value = "";
                    }
                }
                else
                {
                    // 用法
                    row.Cells["dtv_UseType"].Value = "";
                }

                if (p_objItem.m_intExecuFrenquenceType == 1)
                {
                    // 频率
                    row.Cells["dtv_Freq"].Value = objExecOrder.m_strExecFreqName;
                }
                else
                {
                    // 当不显示时，医嘱表中的为修改标志=1时也显示出来 (0-普通状态,1-频率修改)
                    if (objExecOrder.m_intCHARGE_INT == 1)
                    {
                        row.Cells["dtv_Freq"].Value = objExecOrder.m_strExecFreqName;   // 频率
                    }
                    else
                    {
                        row.Cells["dtv_Freq"].Value = "";   // 频率
                    }
                }

                if (p_objItem.m_intAPPENDVIEWTYPE_INT == 1)
                {
                    // 补次
                    row.Cells["ATTACHTIMES_INT"].Value = objExecOrder.m_intATTACHTIMES_INT;
                    m_dmlOneUse = objExecOrder.m_dmlOneUse * objExecOrder.m_intATTACHTIMES_INT;
                }
                else
                {
                    // 补次
                    row.Cells["ATTACHTIMES_INT"].Value = "";
                    m_dmlOneUse = 0;
                }
                // 领量
                if (p_objItem.m_intQTYVIEWTYPE_INT == 1)
                {
                    if (objExecOrder.m_dmlGet > 0)
                    {
                        row.Cells["dtv_Get"].Value = objExecOrder.m_dmlGet.ToString() + " " + objExecOrder.m_strGetunit;
                    }
                    else
                    {
                        row.Cells["dtv_Get"].Value = "";
                    }
                }
                else
                {
                    // 领量
                    row.Cells["dtv_Get"].Value = "";
                }
            }
            else
            {
                // 用量
                row.Cells["dtv_Dosage"].Value = "";
                // 频率
                row.Cells["dtv_Freq"].Value = "";
                // 用法
                row.Cells["dtv_UseType"].Value = "";
                // 补次
                row.Cells["ATTACHTIMES_INT"].Value = "";
                // 领量
                row.Cells["dtv_Get"].Value = "";
            }
            #endregion
            string m_strFeel = "";
            if (objExecOrder.m_intISNEEDFEEL == 1)
            {

                switch (objExecOrder.m_intFEEL_INT)
                {
                    case 0:
                        m_strFeel = " AST( ) ";
                        break;
                    case 1:
                        m_strFeel = " AST(-) ";
                        break;
                    case 2:
                        m_strFeel = " AST(+) ";
                        break;
                }
                row.Cells["dtv_Name"].Value = objExecOrder.m_strName + m_strFeel;
            }
            // 出院带药天数
            string m_strOUTGETMEDDAYS_INT = "";
            // 总量字段的控制
            if (objExecOrder.m_strOrderDicCateID.Equals(m_objSpecateVo.m_strMID_MEDICINE_CHR))      // 中药类型逻辑
            {
                row.Cells["dtv_sum"].Value = objExecOrder.m_intOUTGETMEDDAYS_INT.ToString() + "服共" + Convert.ToString(objExecOrder.m_dmlGet + m_dmlOneUse) + objExecOrder.m_strGetunit;
                m_strOUTGETMEDDAYS_INT = objExecOrder.m_intOUTGETMEDDAYS_INT.ToString() + "服";
            }
            else
            {
                // 总量 N天共M片。N-表示出院带药的天数，M-表示出院带药合计的数量
                if (objExecOrder.m_intExecuteType == 3)
                {
                    row.Cells["dtv_sum"].Value = objExecOrder.m_intOUTGETMEDDAYS_INT.ToString() + "天共" + Convert.ToString(objExecOrder.m_dmlGet + m_dmlOneUse) + objExecOrder.m_strGetunit;
                    m_strOUTGETMEDDAYS_INT = objExecOrder.m_intOUTGETMEDDAYS_INT.ToString() + "天";
                }
                else
                {
                    row.Cells["dtv_sum"].Value = "共" + Convert.ToString(objExecOrder.m_dmlGet + m_dmlOneUse) + objExecOrder.m_strGetunit;
                    m_strOUTGETMEDDAYS_INT = "";
                }

            }
            row.Cells["m_dtvASSESSORFORSTOP_CHR"].Value = objExecOrder.m_strASSESSORFORSTOP_CHR;
            row.Cells["m_dtvASSESSORFORSTOP_DAT"].Value = objExecOrder.m_strASSESSORFORSTOP_DAT;
            // 名称
            row.Cells["dtv_Name"].Value = objExecOrder.m_strName + " " + row.Cells["dtv_Dosage"].Value.ToString() + " " + row.Cells["dtv_UseType"].Value.ToString() + " " + row.Cells["dtv_Freq"].Value.ToString() + m_strFeel + " " + m_strOUTGETMEDDAYS_INT;

            #region 预发天数.默认1天
            if (this.isUsePretestMed)
            {
                if (objExecOrder.m_intStatus == 1)
                {
                    if (objExecOrder.m_strExecuteTypeName.Contains("长期"))
                    {
                        if ((Convert.ToDateTime(DateTime.Now.ToShortDateString()) - Convert.ToDateTime(objExecOrder.m_dtPostdate.ToShortDateString())).Days == 0)   // 当天
                        {
                            using (clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject())
                            {
                                if (svc.IsMedInjection(objExecOrder.m_strOrderDicID, 1) == true)    // 针剂
                                {
                                    row.Cells["pretestdays"].Value = "1";
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            row.Tag = objExecOrder;
        }
        #endregion

        /// <summary>
        /// 刷新同方医嘱的方号颜色并隐藏相同性质的字段,皮试结果颜色显示
        /// </summary>
        public void m_mthRefreshSameReqNoColor()
        {
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
            {
                DataGridViewRow objRow = this.m_objViewer.m_dtvOrderList.Rows[i];
                clsBIHCanExecOrder ExecOrder = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag;

                if (ExecOrder.m_intISNEEDFEEL == 1 && (ExecOrder.m_intStatus == 1 || ExecOrder.m_intStatus == 5))
                {
                    objRow.Cells["dtv_Name"].Style.ForeColor = FeedColor;       // 需要皮试的项目颜色
                }

                // 已停或正在停的医嘱,已执行过的临嘱用红色显示
                if (ExecOrder.m_intStatus == 3 || ExecOrder.m_intStatus == 6 || (ExecOrder.m_intExecuteType == 2 && ExecOrder.m_intStatus == 2))
                {
                    objRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                }
                if (i < this.m_objViewer.m_dtvOrderList.RowCount - 1)
                {
                    clsBIHCanExecOrder ExecOrder2 = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i + 1].Tag;
                    if ((ExecOrder.m_strRegisterID == ExecOrder2.m_strRegisterID) && (ExecOrder.m_intRecipenNo == ExecOrder2.m_intRecipenNo))
                    {
                        this.m_objViewer.m_dtvOrderList.Rows[i + 1].Cells["dtv_RecipeNo"].Value = "";
                        this.m_objViewer.m_dtvOrderList.Rows[i + 1].Cells["dtv_ExecuteType"].Value = "";
                        this.m_objViewer.m_dtvOrderList.Rows[i + 1].Cells["dtv_ENTRUST"].Value = "";
                        this.m_objViewer.m_dtvOrderList.Rows[i + 1].Cells["dtv_CASE"].Value = "";
                        this.m_objViewer.m_dtvOrderList.Rows[i + 1].Cells["ATTACHTIMES_INT"].Value = "";
                        if (ExecOrder.m_strOrderDicCateID.Equals(m_objSpecateVo.m_strMID_MEDICINE_CHR))     // 中药类型逻辑
                        {
                            this.m_objViewer.m_dtvOrderList.Rows[i + 1].Cells["dtv_REMARK"].Value = "";
                        }
                    }
                }
            }
        }

        #region 为费用datagridview填值
        /// <summary>
        /// 为费用datagridview填值
        /// </summary>
        /// <param name="order"></param>
        private void filltheChargeList(clsBIHCanExecOrder order)
        {
            this.m_objViewer.m_dtvChangeList.Rows.Clear();
            if (m_dtChargeList != null && m_dtChargeList.Rows.Count > 0)
            {

                DataView myDataView = new DataView(m_dtChargeList);
                myDataView.RowFilter = "orderid_chr='" + order.m_strOrderID + "'";
                myDataView.Sort = "FLAG_INT";
                if (myDataView.Count <= 0)
                {
                    return;
                }
                clsChargeForDisplay[] m_arrObjItem;
                m_mthGetChargeListFromDateTable(myDataView, out m_arrObjItem);
                int k = 0;
                for (int i = 0; i < m_arrObjItem.Length; i++)
                {

                    k++;
                    this.m_objViewer.m_dtvChangeList.Rows.Add();
                    DataGridViewRow row1 = this.m_objViewer.m_dtvChangeList.Rows[this.m_objViewer.m_dtvChangeList.RowCount - 1];
                    row1.Cells["seq"].Value = Convert.ToString(k);
                    row1.Cells["chargeName"].Value = m_arrObjItem[i].m_strName;
                    row1.Cells["ITEMSPEC_VCHR"].Value = m_arrObjItem[i].m_strSPEC_VCHR;
                    row1.Cells["ChargeClass"].Value = "";
                    switch (m_arrObjItem[i].m_intType)
                    {
                        case 0:
                            row1.Cells["ChargeClass"].Value = "主项目";
                            break;
                        case 1:
                            row1.Cells["ChargeClass"].Value = "辅助项目";
                            break;
                        case 2:
                            row1.Cells["ChargeClass"].Value = "用法带出";
                            break;
                        case 3:
                            row1.Cells["ChargeClass"].Value = "补充录入";
                            break;
                    }

                    row1.Cells["ChargePrice"].Value = m_arrObjItem[i].m_dblPrice.ToString();
                    row1.Cells["get_count"].Value = m_arrObjItem[i].m_dblDrawAmount.ToString() + " " + m_arrObjItem[i].m_strUNIT_VCHR;
                    row1.Cells["countSum"].Value = m_arrObjItem[i].m_dblMoney.ToString();
                    row1.Cells["TotalDiffCost"].Value = m_arrObjItem[i].m_dblDiffCostMoney.ToString("0.0000");// 总让利金额
                    switch (m_arrObjItem[i].m_intCONTINUEUSETYPE_INT)
                    {
                        case 1:
                            row1.Cells["xuClass"].Value = "首次用";
                            break;
                        case 0:
                            row1.Cells["xuClass"].Value = "连续用";
                            break;
                        default:
                            row1.Cells["xuClass"].Value = " -- ";
                            break;
                    }

                    row1.Cells["excuteDept"].Value = m_arrObjItem[i].m_strClacareaName_chr;
                    row1.Cells["YBClass"].Value = m_arrObjItem[i].m_strYBClass;
                    row1.Cells["IPNOQTYFLAG_INT"].Value = "";
                    if (m_arrObjItem[i].m_intITEMSRCTYPE_INT == 1)
                    {
                        if (m_arrObjItem[i].m_intIPNOQTYFLAG_INT == 1)
                        {
                            row1.Cells["IPNOQTYFLAG_INT"].Value = "缺药";
                            row1.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                        }
                    }

                    row1.Tag = m_arrObjItem[i];

                    //序号 seq
                    //项目名称 chargeName
                    //费用类型 ChargeClass
                    //单价 ChargePrice
                    //数量 get_count
                    //总金额 countSum
                    //续用类型 xuClass
                    //执行科室 excuteDept
                    //医保类型 YBClass
                }
            }

        }
        #endregion

        #region 给执行医嘱对象付值
        /// <summary>
        /// 给执行医嘱对象付值
        /// </summary>
        /// <param name="objDT"></param>
        /// <param name="arrExecOrder"></param>
        private void filltheExecOrderTable(DataView objRow, out clsBIHCanExecOrder[] arrExecOrder)
        {
            //医嘱执行对象数组
            //arrExecOrder = new clsBIHCanExecOrder[0];//旧代码
            int intRowsCount = objRow.Count;

            if (intRowsCount <= 0)
            {
                arrExecOrder = new clsBIHCanExecOrder[0];//new code
                //return; //旧代码
            }
            else
            {
                //arrExecOrder = new clsBIHCanExecOrder[objRow.Count];//旧代码
                arrExecOrder = new clsBIHCanExecOrder[intRowsCount];//new code
                m_arrBedIdList = new ArrayList();
                System.Data.DataRowView objOneDataRowView = null;

                for (int i = 0; i < intRowsCount; i++)
                {
                    objOneDataRowView = objRow[i];//new code

                    arrExecOrder[i] = new clsBIHCanExecOrder();

                    arrExecOrder[i].m_strInpatientID = objOneDataRowView["inpatientid_chr"].ToString().Trim();

                    //arrExecOrder[i].m_strBedID = Convert.ToString(objRow[i]["bedid_chr"].ToString().Trim());//旧代码
                    arrExecOrder[i].m_strBedID = objOneDataRowView["bedid_chr"].ToString().Trim();//新代码

                    //arrExecOrder[i].m_strBedName = Convert.ToString(objRow[i]["code_chr"].ToString().Trim()); //old code
                    arrExecOrder[i].m_strBedName = objOneDataRowView["code_chr"].ToString().Trim();//new code

                    //arrExecOrder[i].m_strCURBEDID_CHR = Convert.ToString(objRow[i]["CURBEDID_CHR"].ToString().Trim());//old code
                    arrExecOrder[i].m_strCURBEDID_CHR = objOneDataRowView["CURBEDID_CHR"].ToString().Trim();//new code

                    //arrExecOrder[i].m_strCURBEDName = Convert.ToString(objRow[i]["code_chr"].ToString().Trim());//原来就已经没有使用了

                    //arrExecOrder[i].m_strRegisterID = Convert.ToString(objRow[i]["registerid_chr"].ToString().Trim());//old code
                    arrExecOrder[i].m_strRegisterID = objOneDataRowView["registerid_chr"].ToString().Trim();//new code

                    //arrExecOrder[i].m_strPatientName = Convert.ToString(objRow[i]["LASTNAME_VCHR"].ToString().Trim());//姓名 old code
                    arrExecOrder[i].m_strPatientName = objOneDataRowView["LASTNAME_VCHR"].ToString().Trim();//new code

                    //arrExecOrder[i].m_strPatientSex = Convert.ToString(objRow[i]["SEX_CHR"].ToString().Trim());//姓名 old code
                    arrExecOrder[i].m_strPatientSex = objOneDataRowView["SEX_CHR"].ToString().Trim();//new code

                    //old code**************
                    //if (!objRow[i]["RECIPENO_INT"].ToString().Trim().Equals(""))
                    //    arrExecOrder[i].m_intRecipenNo = int.Parse(objRow[i]["RECIPENO_INT"].ToString().Trim()); //方号
                    //if (!objRow[i]["RECIPENO2_INT"].ToString().Trim().Equals(""))
                    //    arrExecOrder[i].m_intRecipenNo2 = int.Parse(objRow[i]["RECIPENO2_INT"].ToString().Trim()); //方号(用于外部显示)
                    //********************

                    //new code**********************
                    if (!objOneDataRowView["RECIPENO_INT"].ToString().Trim().Equals(""))
                        arrExecOrder[i].m_intRecipenNo = int.Parse(objOneDataRowView["RECIPENO_INT"].ToString().Trim()); //方号
                    if (!objOneDataRowView["RECIPENO2_INT"].ToString().Trim().Equals(""))
                        arrExecOrder[i].m_intRecipenNo2 = int.Parse(objOneDataRowView["RECIPENO2_INT"].ToString().Trim()); //方号(用于外部显示)
                    //****************************

                    //old code*****************************
                    //if (!objRow[i]["EXECUTETYPE_INT"].ToString().Trim().Equals(""))
                    //    arrExecOrder[i].m_intExecuteType = int.Parse(objRow[i]["EXECUTETYPE_INT"].ToString().Trim());//医嘱（医嘱方式）
                    //**************************************

                    //new code********************
                    if (!objOneDataRowView["EXECUTETYPE_INT"].ToString().Trim().Equals(""))
                        arrExecOrder[i].m_intExecuteType = int.Parse(objOneDataRowView["EXECUTETYPE_INT"].ToString().Trim());//医嘱（医嘱方式）
                    //********************************

                    //arrExecOrder[i].m_strOrderDicCateID = Convert.ToString(objRow[i]["ordercateid_chr"].ToString().Trim());//类别ID old code
                    arrExecOrder[i].m_strOrderDicCateID = objOneDataRowView["ordercateid_chr"].ToString().Trim();//new code

                    clsT_aid_bih_ordercate_VO p_objItem = null;
                    if (m_htOrderCate.Contains(arrExecOrder[i].m_strOrderDicCateID))
                    {
                        p_objItem = (clsT_aid_bih_ordercate_VO)m_htOrderCate[arrExecOrder[i].m_strOrderDicCateID];
                    }
                    if (p_objItem != null)
                    {
                        arrExecOrder[i].m_strOrderDicCateName = p_objItem.m_strVIEWNAME_VCHR;//类别名称

                    }

                    //arrExecOrder[i].m_strName = Convert.ToString(objRow[i]["NAME_VCHR"].ToString().Trim());//old code 项目名称
                    arrExecOrder[i].m_strName = objOneDataRowView["NAME_VCHR"].ToString().Trim();//new code

                    //old code******************************
                    //if (!objRow[i]["Dosage_Dec"].ToString().Trim().Equals(""))
                    //    arrExecOrder[i].m_dmlDosage = decimal.Parse(objRow[i]["Dosage_Dec"].ToString().Trim()); ;//剂量
                    //*****************************************

                    //new code*************************
                    if (!objOneDataRowView["Dosage_Dec"].ToString().Trim().Equals(""))
                        arrExecOrder[i].m_dmlDosage = decimal.Parse(objOneDataRowView["Dosage_Dec"].ToString().Trim()); ;//剂量
                    //***************

                    //arrExecOrder[i].m_strDosageUnit = Convert.ToString(objRow[i]["dosageunit_chr"].ToString().Trim());//old code 剂量单位
                    arrExecOrder[i].m_strDosageUnit = objOneDataRowView["dosageunit_chr"].ToString().Trim();//new code

                    //arrExecOrder[i].m_strExecFreqID = Convert.ToString(objRow[i]["EXECFREQID_CHR"].ToString().Trim());//old code
                    arrExecOrder[i].m_strExecFreqID = objOneDataRowView["EXECFREQID_CHR"].ToString().Trim();//new code

                    //arrExecOrder[i].m_strExecFreqName = Convert.ToString(objRow[i]["EXECFREQNAME_CHR"].ToString().Trim());//old code
                    arrExecOrder[i].m_strExecFreqName = objOneDataRowView["EXECFREQNAME_CHR"].ToString().Trim();//new code

                    if (!objOneDataRowView["GET_DEC"].ToString().Trim().Equals(""))
                        arrExecOrder[i].m_dmlGet = decimal.Parse(objOneDataRowView["GET_DEC"].ToString().Trim());


                    arrExecOrder[i].m_strGetunit = objOneDataRowView["getunit_chr"].ToString().Trim();
                    arrExecOrder[i].m_strEntrust = objOneDataRowView["ENTRUST_VCHR"].ToString().Trim();//嘱托
                    arrExecOrder[i].m_strDOCTOR_VCHR = objOneDataRowView["DOCTOR_VCHR"].ToString().Trim();//主管医生
                    if (!objOneDataRowView["POSTDATE_DAT"].ToString().Trim().Equals(""))
                        arrExecOrder[i].m_dtPostdate = Convert.ToDateTime(objOneDataRowView["POSTDATE_DAT"].ToString().Trim());
                    arrExecOrder[i].m_strASSESSORFOREXEC_CHR = objOneDataRowView["CONFIRMER_VCHR"].ToString().Trim();//审核人-
                    arrExecOrder[i].m_strASSESSORFOREXEC_DAT = objOneDataRowView["CONFIRM_DAT"].ToString().Trim();//审核时间
                    arrExecOrder[i].m_strDosetypeID = objOneDataRowView["DOSETYPEID_CHR"].ToString().Trim();//用法ID
                    arrExecOrder[i].m_strDosetypeName = objOneDataRowView["DOSETYPENAME_CHR"].ToString().Trim();//用法名称
                    arrExecOrder[i].m_strOrderID = objOneDataRowView["orderid_chr"].ToString().Trim();//医嘱表流水号
                    if (!objOneDataRowView["STATUS_INT"].ToString().Trim().Equals(""))
                        arrExecOrder[i].m_intStatus = int.Parse(objOneDataRowView["STATUS_INT"].ToString().Trim());//当前医嘱状态
                    arrExecOrder[i].m_strCreatorID = objOneDataRowView["CREATORID_CHR"].ToString().Trim();//开医嘱单医生ID
                    arrExecOrder[i].m_strCreator = objOneDataRowView["CREATOR_CHR"].ToString().Trim();//开医嘱单医生

                    arrExecOrder[i].m_strOrderDicID = objOneDataRowView["ORDERDICID_CHR"].ToString().Trim();//诊疗项目流水号
                    arrExecOrder[i].m_strParentID = objOneDataRowView["patientid_chr"].ToString().Trim();//病人ID
                    arrExecOrder[i].m_strCREATEAREA_ID = objOneDataRowView["createareaid_chr"].ToString().Trim();//开单科室ID
                    arrExecOrder[i].m_strCURAREAID_CHR = objOneDataRowView["CURAREAID_CHR"].ToString().Trim();//下医嘱时病人所在病区ID
                    //arrExecOrder[i].m_strCURAREAName = Convert.ToString(objRow[i]["CURAREAName"].ToString().Trim());//下医嘱时病人所在病区名称
                    if (!objOneDataRowView["OUTGETMEDDAYS_INT"].ToString().Trim().Equals(""))
                    {
                        arrExecOrder[i].m_intOUTGETMEDDAYS_INT = int.Parse(objOneDataRowView["OUTGETMEDDAYS_INT"].ToString().Trim());//出院带药天数(当执行类型为3=出院带药})
                    }
                    arrExecOrder[i].m_strSAMPLEID_VCHR = objOneDataRowView["SAMPLEID_VCHR"].ToString().Trim();
                    arrExecOrder[i].m_strSAMPLEName_VCHR = objOneDataRowView["sample_type_desc_vchr"].ToString().Trim();
                    arrExecOrder[i].m_strPARTID_VCHR = objOneDataRowView["PARTID_VCHR"].ToString().Trim();
                    arrExecOrder[i].m_strPARTNAME_VCHR = objOneDataRowView["partname"].ToString().Trim();
                    //皮试相关字段
                    arrExecOrder[i].m_intISNEEDFEEL = int.Parse(objOneDataRowView["ISNEEDFEEL"].ToString().Trim());//是否需要皮试
                    arrExecOrder[i].m_intFEEL_INT = int.Parse(objOneDataRowView["FEEL_INT"].ToString().Trim());//皮试结果
                    arrExecOrder[i].m_strFEELRESULT_VCHR = objOneDataRowView["FEELRESULT_VCHR"].ToString().Trim();//皮试结果备注
                    if (!objOneDataRowView["CHARGE_INT"].ToString().Trim().Equals(""))
                        arrExecOrder[i].m_intCHARGE_INT = int.Parse(objOneDataRowView["CHARGE_INT"].ToString().Trim());
                    if (!objOneDataRowView["ATTACHTIMES_INT"].ToString().Trim().Equals(""))
                        arrExecOrder[i].m_intATTACHTIMES_INT = int.Parse(objOneDataRowView["ATTACHTIMES_INT"].ToString().Trim());
                    arrExecOrder[i].m_strREMARK_VCHR = objOneDataRowView["REMARK_VCHR"].ToString().Trim();//医嘱说明
                    arrExecOrder[i].m_intTYPE_INT = int.Parse(objOneDataRowView["TYPE_INT"].ToString().Trim());//医嘱归类(0-普通,1-术后医嘱,2-转科医嘱,3-出院(今日),4-出院(明日))
                    arrExecOrder[i].m_dmlOneUse = decimal.Parse(objOneDataRowView["SINGLEAMOUNT_DEC"].ToString().Trim());//补一次的领量
                    arrExecOrder[i].m_strASSESSORFORSTOP_CHR = objOneDataRowView["ASSESSORFORSTOP_CHR"].ToString().Trim();//审核停止人
                    DateTime m_dtDate = DateTime.MinValue;
                    DateTime.TryParse(objOneDataRowView["ASSESSORFORSTOP_DAT"].ToString().Trim(), out m_dtDate);
                    if (m_dtDate != null && m_dtDate != DateTime.MinValue)
                    {
                        arrExecOrder[i].m_strASSESSORFORSTOP_DAT = m_dtDate.ToString();//审核停止时间
                    }
                    //为当前医嘱记录按病人床号保存 为了按床号f8,f9进行上下转换
                    if (m_blBedIdKey)
                    {
                        if (!m_arrBedIdList.Contains(arrExecOrder[i].m_strBedID))
                        {
                            m_arrBedIdList.Add(arrExecOrder[i].m_strBedID);
                        }
                    }
                    /*<===================================*/
                }
            }

            //                    床号
            //\
            //姓名
            //\方号 (code_chr)
            //方号-RECIPENO_INT
            //医嘱（医嘱方式）-EXECUTETYPE_INT
            //类别
            //项目名称--NAME_VCHR
            //剂量--DOSAGE_DEC 剂量单位--DOSAGEUNIT_CHR
            //用法ID--DOSETYPEID_CHR 用药方式DOSETYPENAME_CHR
            //频率--EXECFREQID_CHR
            //频率名称--EXECFREQNAME_CHR
            //数量--GET_DEC
            //领量单位--GETUNIT_CHR
            //嘱托--ENTRUST_VCHR
            //主管医生--DOCTOR_VCHR
            //提交时间--POSTDATE_DAT
            //审核人--CONFIRMER_VCHR
            //审核时间--CONFIRM_DAT
        }

        #endregion

        #region 病人表转换成病人信息对象
        /// <summary>
        /// 病人表转换成病人信息对象
        /// </summary>
        /// <param name="objRow"></param>
        /// <param name="objPatient"></param>
        private void m_mthGetPatientInfoFromDateTable(DataView objRow, out clsBIHPatientInfo objPatient)
        {
            objPatient = null;
            if (objRow == null) return;

            objPatient = new clsBIHPatientInfo();
            objPatient.m_strRegisterID = clsConverter.ToString(objRow[0]["RegisterID_Chr"]).Trim();
            objPatient.m_strPatientID = clsConverter.ToString(objRow[0]["PatientID_Chr"]).Trim();
            objPatient.m_strInHospitalNo = clsConverter.ToString(objRow[0]["InPatientID_Chr"]).Trim();
            objPatient.m_dtInHospital = clsConverter.ToDateTime(objRow[0]["InPatient_Dat"]);
            objPatient.m_strDeptID = clsConverter.ToString(objRow[0]["DeptID_Chr"]).Trim();
            objPatient.m_strAreaID = clsConverter.ToString(objRow[0]["AreaID_Chr"]).Trim();

            objPatient.m_strAreaName = clsConverter.ToString(objRow[0]["AreaName"]).Trim();
            objPatient.m_strBedID = clsConverter.ToString(objRow[0]["BedID_Chr"]).Trim();
            objPatient.m_strBedName = clsConverter.ToString(objRow[0]["BedName"]).Trim();
            /** update by xzf (05-09-29) */
            //@ objPatient.m_strDiagnose=clsConverter.ToString(objRow["Diagnose_Vchr"]).Trim();
            objPatient.m_strDiagnose = clsConverter.ToString(objRow[0]["ICD10DIAGTEXT_VCHR"]).Trim();
            /* <<============================= */
            objPatient.m_intInTimes = clsConverter.ToInt(objRow[0]["InPatientCount_Int"]);
            objPatient.m_strPatientName = clsConverter.ToString(objRow[0]["Name_VChr"]).Trim();

            objPatient.m_strSex = clsConverter.ToString(objRow[0]["Sex_Chr"]).Trim();
            objPatient.m_dtBorn = clsConverter.ToDateTime(objRow[0]["Birth_Dat"]);
            objPatient.m_strPayTypeID = clsConverter.ToString(objRow[0]["PayTypeID_Chr"]).Trim();
            objPatient.m_strPayTypeName = clsConverter.ToString(objRow[0]["PayTypeName_VChr"]).Trim();
            objPatient.m_strInpatientState = clsConverter.ToString(objRow[0]["state"]).Trim();
            objPatient.m_strMzdiagnose_vchr = clsConverter.ToString(objRow[0]["mzdiagnose_vchr"]).Trim();
            objPatient.m_strDiagnose_vchr = clsConverter.ToString(objRow[0]["diagnose_vchr"]).Trim();
            if (objRow[0]["limitrate_mny"] != System.DBNull.Value)
            {
                objPatient.m_dblLIMITRATE_MNY = double.Parse(objRow[0]["limitrate_mny"].ToString());
            }
            try
            {
                TimeSpan span1 = clsConverter.ToDateTime(objRow[0]["today"].ToString().Trim()) - objPatient.m_dtBorn;
                objPatient.m_intAge = span1.Days / 365;
            }
            catch
            {
            }
            try
            {
                objPatient.m_strREMARKNAME_VCHR = objRow[0]["REMARKNAME_VCHR"].ToString().Trim();
            }
            catch
            {
            }
            try
            {
                objPatient.m_strDES_VCHR = objRow[0]["DES_VCHR"].ToString().Trim();
            }
            catch
            {
            }
            //病人的合计金预交金
            //if (m_dtChargeMoney.Rows.Count > 0)
            //{
            //    DataView myDataView = new DataView(m_dtChargeMoney);
            //    myDataView.RowFilter = "registerid_chr='" + objPatient.m_strRegisterID + "'";
            //    if (myDataView.Count <= 0)
            //    {
            //        return;
            //    }
            //    decimal PreMoney = 0, PreUseMoney = 0, NotUsePreMoney = 0, ClearMoney = 0, WaitMoney = 0, WaitClearMoney = 0, VerticalMoney=0;

            //    if (!myDataView[0]["clearmoney"].ToString().Trim().Equals(""))
            //    {
            //        ClearMoney = decimal.Parse(myDataView[0]["clearmoney"].ToString().Trim());
            //    }
            //    if (!myDataView[0]["preusemoney"].ToString().Trim().Equals(""))
            //    {
            //        PreUseMoney = decimal.Parse(myDataView[0]["preusemoney"].ToString().Trim());
            //    }

            //    if (!myDataView[0]["NotUsePreMoney"].ToString().Trim().Equals(""))
            //    {
            //        NotUsePreMoney = decimal.Parse(myDataView[0]["NotUsePreMoney"].ToString().Trim());
            //    }
            //    if (!myDataView[0]["WaitMoney"].ToString().Trim().Equals(""))
            //    {
            //        WaitMoney = decimal.Parse(myDataView[0]["WaitMoney"].ToString().Trim());
            //    }
            //    if (!myDataView[0]["WaitClearMoney"].ToString().Trim().Equals(""))
            //    {
            //        WaitClearMoney = decimal.Parse(myDataView[0]["WaitClearMoney"].ToString().Trim());
            //    }
            //    if (!myDataView[0]["VerticalMoney"].ToString().Trim().Equals(""))
            //    {
            //        VerticalMoney = decimal.Parse(myDataView[0]["VerticalMoney"].ToString().Trim());
            //    }

            //    objPatient.m_decPreMoney = NotUsePreMoney;
            //    objPatient.m_decPreUseMoney = PreUseMoney;
            //    objPatient.m_decClearMoney = ClearMoney;
            //    objPatient.m_decVerticalMoney = VerticalMoney;
            //    objPatient.m_decPrePayMoney = NotUsePreMoney - WaitMoney - WaitClearMoney;

            //}
        }
        #endregion

        #region 费用表转换为费用明细对象
        /// <summary>
        /// 费用表转换为费用明细对象
        /// </summary>
        /// <param name="objRow"></param>
        /// <param name="m_arrObjItem"></param>
        private void m_mthGetChargeListFromDateTable(DataView objRow, out clsChargeForDisplay[] m_arrObjItem)
        {


            m_arrObjItem = new clsChargeForDisplay[objRow.Count];
            decimal UNITPRICE_DEC = 0, ItemPrice_Mny = 0, PackQty_Dec = 0, decItemTradePrice = 0;
            int IPCHARGEFLG_INT = 0;
            for (int i = 0; i < objRow.Count; i++)
            {
                m_arrObjItem[i] = new clsChargeForDisplay();
                m_arrObjItem[i].strOrderID = clsConverter.ToString(objRow[i]["orderid_chr"]).Trim();
                m_arrObjItem[i].m_strChargeID = clsConverter.ToString(objRow[i]["CHARGEITEMID_CHR"]).Trim();
                //收费项目名称
                m_arrObjItem[i].m_strName = clsConverter.ToString(objRow[i]["CHARGEITEMNAME_CHR"]).Trim();
                double dblNum = 0;
                //if (objMedicineItemArr[i1].m_objChargeItem.m_strITEMID_CHR.Trim() == objMedicineItemArr[i1].m_strChiefItemID.Trim())//是否主收费项目
                //{
                //    dblNum = p_dblDraw;
                //    //收费类别	{1=普通药品收费；2=主收费；3=用法收费}
                //    m_arrObjItem[i].m_intType = 2;
                //}
                //else
                //{
                //    dblNum = System.Convert.ToDouble(m_dmlGetChargeNotMainItem(objRecipeFreq, objMedicineItemArr[i1]));
                //    //收费类别	{1=普通药品收费；2=主收费；3=用法收费}
                //    m_arrObjItem[i].m_intType = 1;
                //}
                //单价
                //if (!objRow[i]["UNITPRICE_DEC"].ToString().Trim().Equals(""))
                //{
                //    m_arrObjItem[i].m_dblPrice = double.Parse(clsConverter.ToString(objRow[i]["UNITPRICE_DEC"]).Trim());
                //}
                //取收费项目中的单价
                /*decode(b.IPCHARGEFLG_INT,1,Round(B.ItemPrice_Mny/B.PackQty_Dec,4),0,B.ItemPrice_Mny,Round(B.ItemPrice_Mny/B.PackQty_Dec,4)) ItemPriceA*/
                UNITPRICE_DEC = 0;
                ItemPrice_Mny = 0;
                PackQty_Dec = 0;
                int.TryParse(objRow[i]["IPCHARGEFLG_INT"].ToString(), out IPCHARGEFLG_INT);
                decimal.TryParse(objRow[i]["ItemPrice_Mny"].ToString(), out ItemPrice_Mny);
                decimal.TryParse(objRow[i]["PackQty_Dec"].ToString(), out PackQty_Dec);
                if (objRow.Table != null && objRow.Table.Columns.Contains("tradeprice_mny"))
                    decimal.TryParse(objRow[i]["tradeprice_mny"].ToString(), out decItemTradePrice);// 批发单价
                if (PackQty_Dec <= 0)
                {
                    PackQty_Dec = 1;
                }
                switch (IPCHARGEFLG_INT)
                {
                    case 1:
                        UNITPRICE_DEC = decimal.Round(ItemPrice_Mny / PackQty_Dec, 4);
                        decItemTradePrice = decimal.Round(decItemTradePrice / PackQty_Dec, 4);
                        break;
                    case 0:
                        UNITPRICE_DEC = decimal.Round(ItemPrice_Mny, 4);
                        break;
                    default:
                        UNITPRICE_DEC = decimal.Round(ItemPrice_Mny / PackQty_Dec, 4);
                        decItemTradePrice = decimal.Round(decItemTradePrice / PackQty_Dec, 4);
                        break;

                }
                //orderChargeVo.m_decUnitprice_dec = clsConverter.ToDecimal(row["UNITPRICE_DEC"]);
                m_arrObjItem[i].m_dblPrice = double.Parse(UNITPRICE_DEC.ToString());
                /*<===============*/

                if (!objRow[i]["AMOUNT_DEC"].ToString().Trim().Equals(""))
                {
                    dblNum = double.Parse(clsConverter.ToString(objRow[i]["AMOUNT_DEC"]).Trim());
                }
                /*<---------------------------------*/
                //领量
                m_arrObjItem[i].m_dblDrawAmount = dblNum;

                //合计金额
                m_arrObjItem[i].m_dblMoney = m_arrObjItem[i].m_dblPrice * dblNum;

                m_arrObjItem[i].m_dblTradePrice = double.Parse(decItemTradePrice.ToString());

                //com.digitalwave.Utility.clsLogText jianjunlog = new com.digitalwave.Utility.clsLogText();
                //jianjunlog.LogError("medicnetype_int : " + objRow[i]["medicnetype_int"].ToString());
                //jianjunlog.LogError("m_dblTradePrice :" + m_arrObjItem[i].m_dblTradePrice.ToString());
                //jianjunlog.LogError("m_dblPrice = " + m_arrObjItem[i].m_dblPrice.ToString());
                if (this.m_blnIsDiffMed(objRow[i]["medicinetypeid_chr"].ToString()))//药品才让利
                    // 总让利金额,取负数
                    m_arrObjItem[i].m_dblDiffCostMoney = Math.Round((m_arrObjItem[i].m_dblTradePrice - m_arrObjItem[i].m_dblPrice) * dblNum, 4);
                //续用类型 {-1=非用法收费（药品收费等）;0=不续用;1=全部续用;2-长嘱续用}
                if (!objRow[i]["CONTINUEUSETYPE_INT"].ToString().Trim().Equals(""))
                {
                    m_arrObjItem[i].m_intCONTINUEUSETYPE_INT = int.Parse(objRow[i]["CONTINUEUSETYPE_INT"].ToString().Trim());
                }

                //是否连续性医嘱	{0=否；1=是} 连续性医嘱不提示药品费用信息；
                // m_arrObjItem[i].m_intIsContinueOrder = (blnIsConOrder) ? (1) : (0);
                //是否缺药
                // m_arrObjItem[i].m_strNoqtyFLag = objMedicineItemArr[i1].m_strNoqtyFLag;
                // 加上科室名称
                m_arrObjItem[i].m_strClacarea_chr = clsConverter.ToString(objRow[i]["CLACAREA_CHR"]).Trim();
                m_arrObjItem[i].m_strClacareaName_chr = clsConverter.ToString(objRow[i]["deptname_vchr"]).Trim();
                //暂存住院诊疗项目收费项目执行客户表的流水号
                m_arrObjItem[i].m_strSeq_int = clsConverter.ToString(objRow[i]["SEQ_INT"]).Trim(); ;
                m_arrObjItem[i].m_strYBClass = clsConverter.ToString(objRow[i]["INSURACEDESC_VCHR"]).Trim();
                m_arrObjItem[i].m_strUNIT_VCHR = clsConverter.ToString(objRow[i]["UNIT_VCHR"]).Trim();
                //收费项来源于 0-主诊疗项目，1-诊疗项目,2－带出的用法，3－自定义新开
                if (!objRow[i]["FLAG_INT"].ToString().Trim().Equals(""))
                    m_arrObjItem[i].m_intType = clsConverter.ToInt(objRow[i]["FLAG_INT"].ToString().Trim());
                // 住院诊疗项目收费项目执行客户表VO
                //objItem.m_objORDERCHARGEDEPT_VO = objMedicineItemArr[i1].m_objORDERCHARGEDEPT_VO;
                if (!objRow[i]["ITEMSRCTYPE_INT"].ToString().Trim().Equals(""))
                {
                    m_arrObjItem[i].m_intITEMSRCTYPE_INT = int.Parse(objRow[i]["ITEMSRCTYPE_INT"].ToString().Trim());
                }
                if (!objRow[i]["IPNOQTYFLAG_INT"].ToString().Trim().Equals(""))
                {
                    m_arrObjItem[i].m_intIPNOQTYFLAG_INT = int.Parse(objRow[i]["IPNOQTYFLAG_INT"].ToString().Trim());
                }
                m_arrObjItem[i].m_strSPEC_VCHR = clsConverter.ToString(objRow[i]["ITEMSPEC_VCHR"].ToString().Trim());
            }
        }
        #endregion

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
                    m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value = "1";
                }
            }
            else
            {
                for (int i = 0; i < m_objViewer.m_dtvOrderList.Rows.Count; i++)
                {
                    m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value = "0";
                }
            }
        }
        #endregion

        #region 审核及撤销按钮控制
        /// <summary>
        /// 审核及撤销按钮控制
        /// </summary>
        public void ControlTheButton()
        {
            this.m_objViewer.m_cmdChargeAdd.Enabled = true;
            this.m_objViewer.m_cmdChargeDele.Enabled = true;
            this.m_objViewer.m_cmdChargeModify.Enabled = true;
            this.m_objViewer.m_cmdEditFeel.Enabled = true;
            this.m_objViewer.m_cmdBack.Enabled = true;
            this.m_objViewer.m_cmdPrintFeel.Enabled = true;
            this.m_objViewer.m_cmdRedraw.Enabled = true;
            this.m_objViewer.m_cmdToCommit.Enabled = true;
            //可提交的数目
            int m_intCount1 = 0;
            //已提交的数目
            int m_intCount2 = 0;
            //皮试选项
            int m_intCount3 = 0;
            //要审核停目的数目
            int m_intNotStop = 0;
            //已审核停目的数目
            int m_intYetStop = 0;
            if (this.m_objViewer.m_dtvOrderList.Rows.Count > 0)
            {
                for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
                {
                    if (this.m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value == null)
                    {
                        return;
                    }
                    if (this.m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value.ToString().Trim().Equals("1"))
                    {
                        clsBIHCanExecOrder order = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag;
                        if (order.m_intStatus == 1)
                        {
                            m_intCount1++;
                        }
                        else if (order.m_intStatus == 5)
                        {
                            m_intCount2++;
                        }
                        else if (order.m_intStatus == 3)
                        {
                            m_intNotStop++;
                        }
                        else if (order.m_intStatus == 6)
                        {
                            m_intYetStop++;
                        }
                    }
                }

            }
            if (this.m_objViewer.m_dtvOrderList.SelectedRows.Count > 0)
            {
                clsBIHCanExecOrder order = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.SelectedRows[0].Tag;
                if (order.m_intStatus == 1 && order.m_intISNEEDFEEL == 1)
                {
                    m_intCount3++;
                }
            }
            if (m_intCount1 > 0 && m_intCount2 > 0)
            {
                this.m_objViewer.m_cmdToCommit.Enabled = false;
                this.m_objViewer.m_cmdRedraw.Enabled = false;

            }
            else if (m_intCount1 > 0 && m_intCount2 == 0)
            {

                this.m_objViewer.m_cmdRedraw.Enabled = false;
            }
            else if (m_intCount1 == 0 && m_intCount2 > 0)
            {
                this.m_objViewer.m_cmdToCommit.Enabled = false;

            }
            else
            {
                this.m_objViewer.m_cmdToCommit.Enabled = false;
                this.m_objViewer.m_cmdRedraw.Enabled = false;

            }
            if (m_intCount3 > 0)
            {

            }
            else
            {
                this.m_objViewer.m_cmdEditFeel.Enabled = false;
            }
            if (m_intNotStop > 0)
            {
                this.m_objViewer.m_cmdToCommit.Enabled = true;
            }
            //if(m_intNotStop>0)
            //{
            //    this.m_objViewer.m_cmdChargeAdd.Enabled=false;
            //    this.m_objViewer.m_cmdChargeDele.Enabled=false;
            //    this.m_objViewer.m_cmdChargeModify.Enabled=false;
            //    this.m_objViewer.m_cmdEditFeel.Enabled=false;
            //    this.m_objViewer.m_cmdBack.Enabled=false;
            //    this.m_objViewer.m_cmdPrintFeel.Enabled=false;
            //    this.m_objViewer.m_cmdRedraw.Enabled=false;

            //}
            //if(m_intYetStop>0)
            //{
            //    this.m_objViewer.m_cmdChargeAdd.Enabled=false;
            //    this.m_objViewer.m_cmdChargeDele.Enabled=false;
            //    this.m_objViewer.m_cmdChargeModify.Enabled=false;
            //    this.m_objViewer.m_cmdEditFeel.Enabled=false;
            //    this.m_objViewer.m_cmdBack.Enabled=false;
            //    this.m_objViewer.m_cmdPrintFeel.Enabled=false;
            //    this.m_objViewer.m_cmdRedraw.Enabled=false;
            //    this.m_objViewer.m_cmdToCommit.Enabled=false;
            //}
            if (this.m_objViewer.m_rdoNOT.Checked == true)
            {
                this.m_objViewer.m_plChargeControl.Enabled = true;
            }
            else
            {
                this.m_objViewer.m_plChargeControl.Enabled = false;
            }
            ControlTheBackButton();
        }
        #endregion

        #region 退回按钮的控制
        /// <summary>
        /// 退回按钮的控制
        /// </summary>
        private void ControlTheBackButton()
        {


            if (this.m_objViewer.m_dtvOrderList.SelectedRows.Count > 0)
            {
                if (((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.SelectedRows[0].Tag).m_intStatus == 1)
                {
                    this.m_objViewer.m_cmdBack.Enabled = true;
                }
                else
                {
                    this.m_objViewer.m_cmdBack.Enabled = false;
                }
            }

        }
        #endregion

        /// <summary>
        /// 初始化界面
        /// </summary>
        internal void IniTheForm()
        {
            this.m_objViewer.m_txtSameCharge.Text = "";
            this.m_objViewer.m_chkSelectAll.Checked = true;
            this.m_objViewer.m_txtArea.Text = this.m_objViewer.LoginInfo.m_strInpatientAreaName;
            this.m_objViewer.m_txtArea.Tag = this.m_objViewer.LoginInfo.m_strInpatientAreaID;
            this.m_objViewer.m_txtArea.Focus();
            this.m_objViewer.m_cboCode.SelectedIndex = 0;
            this.m_objViewer.Cursor = Cursors.WaitCursor;
            LoadTheDate();
            this.m_objViewer.Cursor = Cursors.Default;
            this.m_strDiffMedicineType = clsPublic.m_strGetSysparm("9003");

            string preTestMed1day = clsPublic.m_strGetSysparm("9014");
            int p1day = 0;
            int.TryParse(preTestMed1day, out p1day);
            this.isUsePretestMed = p1day == 1 ? true : false;
        }

        #region 判断是否是让利药品类型

        /// <summary>
        /// 判断是否是让利药品
        /// </summary>
        /// <param name="p_strMedicineType">药品类型Id</param>
        /// <returns></returns>
        private bool m_blnIsDiffMed(string p_strMedicineType)
        {
            bool blnIsDiff = false;
            string[] strDiffTypeIds = this.m_strDiffMedicineType.Split(new char[] { ';' });
            if (strDiffTypeIds == null || strDiffTypeIds.Length == 0)
                return blnIsDiff;
            foreach (string strTypeId in strDiffTypeIds)
            {
                if (string.Compare(strTypeId, p_strMedicineType) == 0)
                {
                    blnIsDiff = true;
                    break;
                }
            }
            return blnIsDiff;
        }
        #endregion

        #region 重置定时器
        /// <summary>
        /// 重置定时器
        /// </summary>
        /// <param name="Status"></param>
        public void m_mthReSetTimer(bool Status)
        {
            if (Status)
            {
                this.m_objViewer.m_timerMessage.Enabled = true;
                if (m_intMessageOpenTime == 0)
                {
                    m_intMessageOpenTime = 1;
                }
                this.m_objViewer.m_timerMessage.Interval = m_intMessageOpenTime * 1000;
            }
            else
            {
                this.m_objViewer.m_timerMessage.Enabled = false;
            }
        }
        #endregion

        internal void ChangeTheSelectState(int rowNum)
        {
            if (this.m_objViewer.m_dtvOrderList.Rows.Count > 0 && rowNum >= 0)
            {
                if (this.m_objViewer.m_dtvOrderList.Rows[rowNum].Cells["m_dtvselectCheck"].Value.ToString().Trim().Equals("0"))
                {
                    this.m_objViewer.m_dtvOrderList.Rows[rowNum].Cells["m_dtvselectCheck"].Value = "1";
                }
                else if (this.m_objViewer.m_dtvOrderList.Rows[rowNum].Cells["m_dtvselectCheck"].Value.ToString().Trim().Equals("1"))
                {
                    this.m_objViewer.m_dtvOrderList.Rows[rowNum].Cells["m_dtvselectCheck"].Value = "0";
                }

                ControlTheButton();
            }
            //同方处理
            TheSamerecipeno(rowNum);
        }

        internal void SetTheNeelSelect(ArrayList m_arrNeel)
        {
            //要皮试的病人列表
            ArrayList m_arrRegister = new ArrayList();
            //要皮试的医嘱方号
            ArrayList m_arrRecipenNo = new ArrayList();
            for (int i = 0; i < m_arrNeel.Count; i++)
            {
                if (((clsBIHCanExecOrder)m_arrNeel[i]).m_intISNEEDFEEL == 1)
                {
                    m_arrRegister.Add(((clsBIHCanExecOrder)m_arrNeel[i]).m_strRegisterID);
                    m_arrRecipenNo.Add(((clsBIHCanExecOrder)m_arrNeel[i]).m_intRecipenNo);
                }
            }
            //不是皮试的删除
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
            {
                clsBIHCanExecOrder order = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag;
                if (m_arrRecipenNo.Contains(order.m_intRecipenNo) && m_arrRegister.Contains(order.m_strRegisterID))
                {
                }
                else
                {
                    this.m_objViewer.m_dtvOrderList.Rows.Remove(this.m_objViewer.m_dtvOrderList.Rows[i]);
                    i--;
                }
            }
        }

        #region 同方处理
        /// <summary>
        /// 同方处理
        /// </summary>
        /// <param name="rowNum"></param>
        private void TheSamerecipeno(int rowNum)
        {

            if (this.m_objViewer.m_dtvOrderList.Rows.Count > 0 && rowNum >= 0)
            {

                string m_strValue = this.m_objViewer.m_dtvOrderList.Rows[rowNum].Cells["m_dtvselectCheck"].Value.ToString().Trim();
                int m_intRecipenNo = ((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[rowNum].Tag).m_intRecipenNo;
                string m_strRegisterID = ((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[rowNum].Tag).m_strRegisterID;
                decimal m_decSum = 0;
                for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
                {
                    if (((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag).m_intRecipenNo == m_intRecipenNo && ((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strRegisterID.Equals(m_strRegisterID))
                    {
                        this.m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value = m_strValue;

                    }
                }


            }
        }
        #endregion

        #region 同方处理
        /// <summary>
        /// 同方处理
        /// </summary>
        /// <param name="rowNum"></param>
        private void TheSamerecipeno(clsBIHCanExecOrder Order, string m_strValue)
        {

            int m_intRecipenNo = Order.m_intRecipenNo;
            string m_strRegisterID = Order.m_strRegisterID;
            decimal m_decSum = 0;
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
            {
                if (((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag).m_intRecipenNo == m_intRecipenNo && ((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strRegisterID.Equals(m_strRegisterID))
                {
                    this.m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value = m_strValue;

                }
            }

        }
        #endregion

        internal void UpdateBihOrderConfirmer()
        {
            long lngRes = 0;
            List<EntityConfirmOrder> lstOrder = null;
            ArrayList m_strStopORDERID_Arr = null;
            string strLeaveHospital = "";
            lstOrder = GetTheSelectItem();
            m_strStopORDERID_Arr = GetTheStopSelectItem(ref strLeaveHospital);
            if (lstOrder.Count == 0 && m_strStopORDERID_Arr.Count == 0)
            {
                MessageBox.Show("没有可审核的医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            System.Collections.Generic.List<string> m_glstNonExecutableOrder = null;
            System.Collections.Generic.List<string> m_glstSelectORDERID = new System.Collections.Generic.List<string>();

            if (lstOrder.Count > 0)
            {
                foreach (EntityConfirmOrder item in lstOrder)
                {
                    m_glstSelectORDERID.Add(item.OrderId);
                }
            }
            if (m_strStopORDERID_Arr.Count > 0)
            {
                m_glstSelectORDERID.AddRange((string[])m_strStopORDERID_Arr.ToArray(typeof(string)));
            }
            if (!ConfirmCurrentOrder(m_glstSelectORDERID, out m_glstNonExecutableOrder))
            {
                MessageBox.Show("当前待医嘱状态已变化,再确定后再尝试!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DelTheOrderFromDTView(m_glstNonExecutableOrder);
                m_mthRefreshSameReqNoColor();
                return;
            }
            if (m_blNeedComfirm == true)
            {
                string empid = "";
                string empname = "";

                DialogResult dlg = clsPublic.m_dlgConfirm(out empid, out empname);
                if (dlg == DialogResult.Yes)
                {
                    this.m_objViewer.Cursor = Cursors.WaitCursor;

                    if (this.m_objViewer.m_rdoNOT.Checked)
                    {
                        lngRes = m_objManage.m_lngUpdateBihOrderConfirmer(lstOrder, empid, empname);
                        lngRes = m_objManage.m_lngStopBihOrderConfirmer(m_strStopORDERID_Arr, empid, empname);
                        if (strLeaveHospital != "")
                        {
                            lngRes = m_objManage.m_lngUpdateLeaveConfiemer(strLeaveHospital, empid, empname);
                        }
                    }
                    m_glstNonExecutableOrder = null;
                    if (!ConfirmCurrentOrder(m_glstSelectORDERID, out m_glstNonExecutableOrder))
                    {
                        DelTheOrderFromDTView(m_glstNonExecutableOrder);
                        m_mthRefreshSameReqNoColor();
                    }
                    this.m_objViewer.Cursor = Cursors.Default;
                    MessageBox.Show("核对成功!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                #region
                //DotorComfirmBox comfirmBox1 = new DotorComfirmBox();
                //if (comfirmBox1.ShowDialog() == DialogResult.OK)
                //{
                //    this.m_objViewer.Cursor = Cursors.WaitCursor;
                //    //if (this.m_objViewer.m_rdoNOTStop.Checked == true)
                //    //{
                //    //    if (MessageBox.Show("审核停止后将不能进行撤消操作，要继续吗!", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                //    //    {
                //    //        lngRes = m_objManage.m_lngStopBihOrderConfirmer(m_strORDERID_Arr, comfirmBox1.empid_chr, comfirmBox1.lastname_vchr);
                //    //    }

                //    //}
                //    //else 
                //    if (this.m_objViewer.m_rdoNOT.Checked)
                //    {
                //        lngRes = m_objManage.m_lngUpdateBihOrderConfirmer(m_strORDERID_Arr, comfirmBox1.empid_chr, comfirmBox1.lastname_vchr);
                //        lngRes = m_objManage.m_lngStopBihOrderConfirmer(m_strStopORDERID_Arr, comfirmBox1.empid_chr, comfirmBox1.lastname_vchr);

                //    }

                //    m_arrCanNoOrder = null;
                //    if (!ConfirmCurrentOrder(m_SelectORDERID_Arr, out m_arrCanNoOrder))
                //    {
                //        DelTheOrderFromDTView(m_arrCanNoOrder);
                //        m_mthRefreshSameReqNoColor();

                //    }
                //    MessageBox.Show("核对成功!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    //LoadTheDate();



                //    this.m_objViewer.Cursor = Cursors.Default;
                //}
                #endregion
            }
            else
            {
                this.m_objViewer.Cursor = Cursors.WaitCursor;
                if (this.m_objViewer.m_rdoNOT.Checked)
                {
                    lngRes = m_objManage.m_lngUpdateBihOrderConfirmer(lstOrder, this.m_objViewer.LoginInfo.m_strEmpID, this.m_objViewer.LoginInfo.m_strEmpName);
                    lngRes = m_objManage.m_lngStopBihOrderConfirmer(m_strStopORDERID_Arr, this.m_objViewer.LoginInfo.m_strEmpID, this.m_objViewer.LoginInfo.m_strEmpName);
                    if (strLeaveHospital != "")
                    {
                        lngRes = m_objManage.m_lngUpdateLeaveConfiemer(strLeaveHospital, this.m_objViewer.LoginInfo.m_strEmpID, this.m_objViewer.LoginInfo.m_strEmpName);
                    }
                }
                m_glstNonExecutableOrder = null;
                if (!ConfirmCurrentOrder(m_glstSelectORDERID, out m_glstNonExecutableOrder))
                {
                    DelTheOrderFromDTView(m_glstNonExecutableOrder);
                    m_mthRefreshSameReqNoColor();
                }
                MessageBox.Show("核对成功!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.Cursor = Cursors.Default;
            }
            if (this.m_objViewer.m_dtvOrderList.RowCount == 0)
            {
                this.m_objViewer.m_dtvChangeList.Rows.Clear();
            }
        }

        internal bool ConfirmCurrentOrder(System.Collections.Generic.List<string> m_glstORDERID, out System.Collections.Generic.List<string> m_glstNonExcutableOrder)
        {
            string m_strStatus1 = "", m_strStatus2 = "";
            if (this.m_objViewer.m_rdoNOT.Checked)
            {
                m_strStatus1 = "1";
                m_strStatus2 = "3";
            }
            else
            {
                m_strStatus1 = "5";
                m_strStatus2 = "6";
            }
            DataTable m_dtOrder = null;
            //原来的代码m_arrCanNoOrder = new ArrayList();

            ArrayList strOrderIDArr = new ArrayList();
            for (int i1 = 0; i1 < m_glstORDERID.Count; i1++)
            {
                strOrderIDArr.Add(m_glstORDERID[i1]);
            }
            string[] m_arrorder = (string[])strOrderIDArr.ToArray(typeof(string));

            m_glstNonExcutableOrder = new System.Collections.Generic.List<string>(m_glstORDERID.Count);
            long lngRef = m_objManage.m_lngConfirmCurrentOrder(m_arrorder, out  m_dtOrder);
            if (lngRef > 0 && m_dtOrder != null)
            {
                string orderid_chr = "", status_int = "";
                DateTime executedate_dat, today;
                bool m_blCan = false;
                int intOrderRowsCount = m_dtOrder.Rows.Count;
                System.Data.DataRow objRow = null;

                for (int i = 0; i < intOrderRowsCount; i++)
                {
                    m_blCan = false;
                    objRow = m_dtOrder.Rows[i];
                    orderid_chr = objRow["orderid_chr"].ToString().Trim();
                    status_int = objRow["status_int"].ToString().Trim();
                    DateTime.TryParse(objRow["executedate_dat"].ToString().Trim(), out executedate_dat);
                    DateTime.TryParse(objRow["sysdate"].ToString().Trim(), out today);
                    if (status_int.Equals(m_strStatus1) || status_int.Equals(m_strStatus2))
                    {
                        m_blCan = true;
                    }
                    else
                    {
                        m_blCan = false;
                    }

                    if (!m_blCan)
                    {
                        //原来的代码m_arrCanNoOrder.Add(orderid_chr);
                        m_glstNonExcutableOrder.Add(orderid_chr);
                    }
                }

            }
            if (m_glstNonExcutableOrder.Count > 0)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 根据流水号删除行
        /// </summary>
        /// <param name="m_arrCanNoOrder"></param>
        //原来的代码private void DelTheOrderFromDTView(ArrayList m_arrCanNoOrder)
        private void DelTheOrderFromDTView(System.Collections.Generic.List<string> m_glstNonExecutableOrder)
        {
            int intOrderListRowsCount = this.m_objViewer.m_dtvOrderList.Rows.Count;
            DataGridViewRow row1 = null;
            DataGridViewRow row2 = null;

            //for (int i = 0; i < intOrderListRowsCount; i++)//错误的，由于在循环内DataGridView进行了Remove的操作，Count值是改变的。
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.Rows.Count; i++)
            {
                row1 = this.m_objViewer.m_dtvOrderList.Rows[i];
                if (m_glstNonExecutableOrder.Contains(((clsBIHCanExecOrder)row1.Tag).m_strOrderID))
                {
                    if ((row1.Cells["dtv_bedcode"].Value != null && !row1.Cells["dtv_bedcode"].Value.ToString().Equals("")) || (row1.Cells["m_dtvLastName"].Value != null && !row1.Cells["m_dtvLastName"].Value.ToString().Equals("")))
                    {
                        if (i < this.m_objViewer.m_dtvOrderList.Rows.Count - 1)
                        {
                            row2 = this.m_objViewer.m_dtvOrderList.Rows[i + 1];
                            if (((clsBIHCanExecOrder)row1.Tag).m_strRegisterID.Equals(((clsBIHCanExecOrder)row2.Tag).m_strRegisterID))
                            {
                                row2.Cells["dtv_bedcode"].Value = ((clsBIHCanExecOrder)row1.Tag).m_strBedName;
                                row2.Cells["m_dtvLastName"].Value = ((clsBIHCanExecOrder)row1.Tag).m_strPatientName;
                                //row2.Cells["dtv_DEPTNAME_VCHR"].Value = ((clsBIHCanExecOrder)row1.Tag).m_strCURAREAName;
                            }
                        }
                    }

                    this.m_objViewer.m_dtvOrderList.Rows.Remove(this.m_objViewer.m_dtvOrderList.Rows[i]);
                    i--;
                }
            }
            SelectAll();
            ControlTheButton();
        }

        /// <summary>
        /// 得到提交状态的医嘱
        /// </summary>
        /// <returns></returns>
        private List<EntityConfirmOrder> GetTheSelectItem()
        {
            string orderDicId = string.Empty;
            string orderTypeName = string.Empty;
            EntityConfirmOrder vo = null;
            List<EntityConfirmOrder> lstOrder = new List<EntityConfirmOrder>();
            clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.Rows.Count; i++)
            {
                if (m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value.ToString().Trim() == "1")
                {
                    if (((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag).m_intStatus == 1)
                    {
                        vo = new EntityConfirmOrder();
                        orderDicId = ((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strOrderDicID;
                        vo.OrderId = ((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strOrderID.Trim();
                        vo.PretestDays = Convert.ToInt32(m_objViewer.m_dtvOrderList.Rows[i].Cells["pretestdays"].Value);
                        orderTypeName = ((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strExecuteTypeName;
                        if (vo.PretestDays > 0)
                        {
                            if (orderTypeName.Contains("长期") == false)
                            {
                                MessageBox.Show("预发药只能是:长期医嘱");
                                lstOrder.Clear();
                                return lstOrder;
                            }
                            if ((Convert.ToDateTime(DateTime.Now.ToShortDateString()) - Convert.ToDateTime(((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag).m_dtPostdate.ToShortDateString())).Days > 0)
                            {
                                MessageBox.Show("预发药只能是:当天新开医嘱");
                                lstOrder.Clear();
                                return lstOrder;
                            }
                            if (svc.IsMedInjection(orderDicId, 1) == false)
                            {
                                MessageBox.Show("预发药只能是:针剂药品医嘱");
                                lstOrder.Clear();
                                return lstOrder;
                            }
                        }
                        lstOrder.Add(vo);
                    }
                }
            }
            svc = null;
            return lstOrder;
        }

        /// <summary>
        /// 得到待审核停止状态的医嘱
        /// </summary>
        /// <returns></returns>
        private ArrayList GetTheStopSelectItem(ref string strLeaveHospital)
        {
            ArrayList orderArr = new ArrayList();
            strLeaveHospital = "";
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.Rows.Count; i++)
            {
                if (m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value.ToString().Trim() == "1")
                {
                    clsBIHCanExecOrder objTmp = this.m_objViewer.m_dtvOrderList.Rows[i].Tag as clsBIHCanExecOrder;
                    if (objTmp.m_intStatus != 1)
                    {
                        orderArr.Add(((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strOrderID.Trim());

                        if (objTmp.m_intTYPE_INT == 3 || objTmp.m_intTYPE_INT == 4)
                        {
                            strLeaveHospital = objTmp.m_strOrderID;
                        }
                    }
                }
            }
            return orderArr;
        }

        /// <summary>
        /// 得到待撤消状态的医嘱
        /// </summary>
        /// <returns></returns>
        private ArrayList GetTheRedrawSelectItem()
        {
            ArrayList orderArr = new ArrayList();
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.Rows.Count; i++)
            {
                if (m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value.ToString().Trim() == "1")
                {
                    if (((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag).m_intStatus == 5)
                    {
                        orderArr.Add(((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strOrderID.Trim());
                    }
                }
            }

            return orderArr;
        }

        /// <summary>
        /// 如果当前选中的项中有可以撤消审核的项，就为TRUE,否则为FALSE
        /// </summary>
        /// <returns></returns>
        internal bool GetTheRedrawSelectItemCount()
        {
            bool m_blRedraw = false;
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.Rows.Count; i++)
            {
                if (m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value.ToString().Trim() == "1")
                {
                    if (((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag).m_intStatus == 5)
                    {
                        m_blRedraw = true;
                        break;

                    }
                }
            }
            return m_blRedraw;
        }

        /// <summary>
        /// 如果当前选中的项中有可以审核的项，就为TRUE,否则为FALSE
        /// </summary>
        /// <returns></returns>
        internal bool GetTheCommitSelectItemCount()
        {
            bool m_blRedraw = false;
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.Rows.Count; i++)
            {
                if (m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value.ToString().Trim() == "1")
                {
                    m_blRedraw = true;
                    break;
                }
            }
            return m_blRedraw;
        }

        internal void UpdateBihOrderRedraw()
        {
            ArrayList m_strORDERID_Arr = null;
            m_strORDERID_Arr = GetTheRedrawSelectItem();
            if (m_strORDERID_Arr.Count == 0)
            {
                MessageBox.Show("请先选择医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            //原来的代码ArrayList m_arrCanNoOrder = null;
            //原来的代码ArrayList m_SelectORDERID_Arr = new ArrayList();
            System.Collections.Generic.List<string> m_glstNonExecutableOrder = null;//状态发生了变化,不可以执行的医嘱
            System.Collections.Generic.List<string> m_glstSelectOrder = new System.Collections.Generic.List<string>();//所有可能需要执行的医嘱

            if (m_strORDERID_Arr.Count > 0)
            {
                //原来的代码m_SelectORDERID_Arr.AddRange((string[])m_strORDERID_Arr.ToArray(typeof(string)));
                m_glstSelectOrder.AddRange((string[])m_strORDERID_Arr.ToArray(typeof(string)));
            }

            //m_strORDERID_Arr.ToArray(
            //原来的代码if (!ConfirmCurrentOrder(m_SelectORDERID_Arr, out m_arrCanNoOrder))


            if (!ConfirmCurrentOrder(m_glstSelectOrder, out m_glstNonExecutableOrder))
            {
                MessageBox.Show("当前待医嘱状态已变化,再确定后再尝试!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DelTheOrderFromDTView(m_glstNonExecutableOrder);
                m_mthRefreshSameReqNoColor();
                return;
            }
            if (m_blNeedComfirm == true)
            {
                string empid = "";
                string empname = "";

                DialogResult dlg = clsPublic.m_dlgConfirm(out empid, out empname);
                if (dlg == DialogResult.Yes)
                {
                    long lngRes = m_objManage.m_lngUpdateBihOrderRedraw(m_strORDERID_Arr, empid, empname);
                    //原来的代码m_arrCanNoOrder = null;
                    m_glstNonExecutableOrder = null;
                    //原来的代码if (!ConfirmCurrentOrder(m_SelectORDERID_Arr, out m_arrCanNoOrder))
                    if (!ConfirmCurrentOrder(m_glstSelectOrder, out m_glstNonExecutableOrder))
                    {
                        //原来的代码DelTheOrderFromDTView(m_arrCanNoOrder);
                        DelTheOrderFromDTView(m_glstNonExecutableOrder);
                        m_mthRefreshSameReqNoColor();

                    }
                    MessageBox.Show("撤销审核成功!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return;
                }

                #region
                //DotorComfirmBox comfirmBox1 = new DotorComfirmBox();
                //comfirmBox1.m_txtName.Focus();
                //if (comfirmBox1.ShowDialog() == DialogResult.OK)
                //{

                //    long lngRes = m_objManage.m_lngUpdateBihOrderRedraw(m_strORDERID_Arr, comfirmBox1.empid_chr, comfirmBox1.lastname_vchr);
                //    m_arrCanNoOrder = null;
                //    if (!ConfirmCurrentOrder(m_SelectORDERID_Arr, out m_arrCanNoOrder))
                //    {
                //        DelTheOrderFromDTView(m_arrCanNoOrder);
                //        m_mthRefreshSameReqNoColor();

                //    }
                //    MessageBox.Show("撤销审核成功!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //}
                //comfirmBox1.Close();
                #endregion
            }
            else
            {

                long lngRes = m_objManage.m_lngUpdateBihOrderRedraw(m_strORDERID_Arr, this.m_objViewer.LoginInfo.m_strEmpID, this.m_objViewer.LoginInfo.m_strEmpName);
                //原来的代码m_arrCanNoOrder = null;
                m_glstNonExecutableOrder = null;
                //原来的代码if (!ConfirmCurrentOrder(m_SelectORDERID_Arr, out m_arrCanNoOrder))
                if (!ConfirmCurrentOrder(m_glstSelectOrder, out m_glstNonExecutableOrder))
                {
                    //原来的代码DelTheOrderFromDTView(m_arrCanNoOrder);
                    DelTheOrderFromDTView(m_glstNonExecutableOrder);
                    m_mthRefreshSameReqNoColor();

                }
                MessageBox.Show("撤销审核成功!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            if (this.m_objViewer.m_dtvOrderList.RowCount == 0)
            {
                this.m_objViewer.m_dtvChangeList.Rows.Clear();
            }

        }

        internal void UpdateBihOrderBack()
        {
            if (m_objViewer.m_dtvOrderList.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选择医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            string empid = "";
            string empname = "";

            DialogResult dlg = clsPublic.m_dlgConfirm(out empid, out empname);
            if (dlg == DialogResult.Yes)
            {
                string m_strORDERID_Arr = "";
                clsBIHCanExecOrder order = ((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.SelectedRows[0].Tag);
                frmSendBackReason BackReason = new frmSendBackReason();
                BackReason.m_txbOrderName.Text = order.m_strName;

                if (BackReason.ShowDialog() == DialogResult.OK)
                {
                    m_strORDERID_Arr = getTheORDERIDWithSon(order);
                    long lngRes = m_objManage.m_lngUpdateBihOrderBack(m_strORDERID_Arr, empid, empname, BackReason.m_txtReason.Text.Trim());
                    if (lngRes > 0)
                    {
                        MessageBox.Show("退回审核成功!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.m_objViewer.Cursor = Cursors.WaitCursor;
                        LoadTheDate();
                        this.m_objViewer.Cursor = Cursors.Default;


                    }
                }
            }

            #region
            //DotorComfirmBox comfirmBox1 = new DotorComfirmBox();
            //comfirmBox1.m_txtName.Focus();
            //if (comfirmBox1.ShowDialog() == DialogResult.OK)
            //{
            //    string m_strORDERID_Arr = "";
            //    clsBIHCanExecOrder order = ((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.SelectedRows[0].Tag);
            //    frmSendBackReason BackReason = new frmSendBackReason();
            //    BackReason.m_txbOrderName.Text = order.m_strName;

            //    if (BackReason.ShowDialog() == DialogResult.OK)
            //    {
            //        m_strORDERID_Arr = getTheORDERIDWithSon(order);
            //        //m_strORDERID_Arr = "'" +order.m_strOrderID +"'";
            //        long lngRes = m_objManage.m_lngUpdateBihOrderBack(m_strORDERID_Arr, comfirmBox1.empid_chr, comfirmBox1.lastname_vchr, BackReason.m_txtReason.Text.Trim());
            //        if (lngRes > 0)
            //        {
            //            MessageBox.Show("退回审核成功!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            this.m_objViewer.Cursor = Cursors.WaitCursor;
            //            LoadTheDate();
            //            this.m_objViewer.Cursor = Cursors.Default;


            //        }
            //    }
            //}
            //comfirmBox1.Close();
            #endregion
        }

        #region 连同子医嘱的一起返回
        /// <summary>
        /// 连同子医嘱的一起返回
        /// </summary>
        /// <param name="order"></param>
        private string getTheORDERIDWithSon(clsBIHCanExecOrder order)
        {
            string m_strOrderID = "";
            int m_intRecipenNo = order.m_intRecipenNo;
            string m_strRegisterID = order.m_strRegisterID;
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
            {
                if (((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag).m_intRecipenNo == m_intRecipenNo && ((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strRegisterID.Equals(m_strRegisterID))
                {
                    m_strOrderID += ((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strOrderID + ",";
                }
            }
            m_strOrderID = m_strOrderID.TrimEnd(',');
            return m_strOrderID;

        }
        #endregion

        #region 判断当前是否为子医嘱
        /// <summary>
        /// 连同子医嘱的一起返回
        /// </summary>
        /// <param name="order"></param>
        internal void m_TestORDERIDIsSon(clsBIHCanExecOrder order, out bool m_blSon)
        {
            m_blSon = false;
            string m_strOrderID = "";
            int m_intRecipenNo = order.m_intRecipenNo;
            string m_strRegisterID = order.m_strRegisterID;
            int SameCount = 0;
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
            {
                if (((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag).m_intRecipenNo == m_intRecipenNo && ((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strRegisterID.Equals(m_strRegisterID))
                {
                    m_strOrderID = ((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strOrderID;
                    if (m_strOrderID.Equals(order.m_strOrderID))
                    {

                        if (SameCount == 0)//当前操作的医嘱是父医嘱
                        {
                            m_blSon = false;
                            break; ;
                        }
                        else
                        {
                            m_blSon = true;
                            break;
                        }
                    }
                    else
                    {
                        SameCount++;
                    }
                }
            }

        }
        #endregion

        internal void AddNewChargeItem()
        {
            if (this.m_objViewer.m_dtvOrderList.CurrentRow == null || this.m_objViewer.m_dtvOrderList.CurrentRow.Tag == null)
            {
                return;
            }

            clsBIHCanExecOrder objItem = (clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.CurrentRow.Tag;
            frmChargeItem frmCharge = new frmChargeItem(objItem);
            if (frmCharge.ShowDialog() == DialogResult.OK)
            {
                refreshTheChargeDate();
                OrderListSelect();

            };
        }

        internal void ChargeItemChanged()
        {
            if (this.m_objViewer.m_dtvOrderList.CurrentRow == null || this.m_objViewer.m_dtvOrderList.CurrentRow.Tag == null)
            {
                return;
            }
            if (this.m_objViewer.m_dtvChangeList.CurrentRow == null || this.m_objViewer.m_dtvChangeList.CurrentRow.Tag == null)
            {
                return;
            }
            clsChargeForDisplay objItem = (clsChargeForDisplay)this.m_objViewer.m_dtvChangeList.CurrentRow.Tag;

            //主收费项目不允许修改 收费类别m_intType	{1=普通药品收费；2=主收费；3=用法收费}
            string m_intType = objItem.m_intType.ToString().Trim();
            string m_strSeq_int = objItem.m_strSeq_int;
            //string m_strGet_DEC = m_dtvOrderdicCharge["SumNumber", m_dtvOrderdicCharge.CurrentRow.Index].Value.ToString().Trim();

            //MessageBox.Show(strOrderID);
            frmChargeItem frmCharge = new frmChargeItem(m_strSeq_int);
            //初始化类型信息
            try
            {
                frmCharge.m_intType = int.Parse(m_intType);
            }
            catch
            {
            }
            /*<========================*/
            if (frmCharge.ShowDialog() == DialogResult.OK)
            {

                refreshTheChargeDate();
                OrderListSelect();


            }
        }

        internal void DeleItemChanged()
        {
            if (this.m_objViewer.m_dtvOrderList.CurrentRow == null || this.m_objViewer.m_dtvOrderList.CurrentRow.Tag == null)
            {
                return;
            }
            if (this.m_objViewer.m_dtvChangeList.CurrentRow == null || this.m_objViewer.m_dtvChangeList.CurrentRow.Tag == null)
            {
                return;
            }
            clsChargeForDisplay objItem = (clsChargeForDisplay)this.m_objViewer.m_dtvChangeList.CurrentRow.Tag;

            //主收费项目不允许修改
            string m_intType = objItem.m_intType.ToString().Trim();
            if (m_intType.Trim().Equals("0"))
            {
                MessageBox.Show("主收费项目不允许删除!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /*<---------------------------*/
            if (MessageBox.Show("是否删除该项目?", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

            }
            else
            {
                return;
            }

            string m_strSeq_int = objItem.m_strSeq_int;
            long reg = m_objInputOrder.m_lngDellORDERCHARGEDEPT(m_strSeq_int);
            if (reg <= 0)
            {
                MessageBox.Show("删除失败!");
            }
            else
            {
                refreshTheChargeDate();
                OrderListSelect();

            }
        }

        /// <summary>
        /// 检查当前是否有新数据的变动
        /// </summary>
        internal void CheckTheChanged()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(4000);

                DataTable m_dtExecOrder2 = new DataTable();
                long lngRes = m_objManage.m_lngCheckTheChanged((string)m_objViewer.m_txtArea.Tag, m_intState, out m_dtExecOrder2);
                if (CompareTheTable(m_dtExecOrder, m_dtExecOrder2) == false)
                {
                    this.m_objViewer.Cursor = Cursors.WaitCursor;
                    LoadTheDate();
                    this.m_objViewer.Cursor = Cursors.Default;
                }
            }
        }

        private bool CompareTheTable(DataTable m_dtExecOrder, DataTable m_dtExecOrder2)
        {
            bool m_blSame = false;
            if (m_dtExecOrder != null || m_dtExecOrder2 != null)
            {
                if (m_dtExecOrder.Rows.Count != m_dtExecOrder2.Rows.Count)
                {
                    m_blSame = false;

                }
                else
                {
                    for (int i = 0; i < this.m_dtExecOrder.Rows.Count; i++)
                    {
                        for (int j = 0; j < this.m_dtChargeList.Columns.Count; j++)
                        {
                            if (this.m_dtExecOrder.Rows[i][j].ToString().Trim().Equals(m_dtExecOrder2.Rows[i][j].ToString().Trim()))
                            {

                            }
                            else
                            {
                                m_blSame = false;
                                break;
                            }
                        }
                    }
                    m_blSame = true;
                }

            }
            return m_blSame;
        }

        /// <summary>
        /// 打开窗体时导入医嘱类型
        /// </summary>
        internal void LoadTheOrderCate()
        {
            clsT_aid_bih_ordercate_VO[] p_objItemArr = null;
            long lngRes = m_objInputOrder.m_lngGetAidOrderCate(out p_objItemArr);
            m_htOrderCate.Clear();
            int intLen = p_objItemArr.Length;
            for (int i = 0; i < intLen; i++)
            {
                if (!m_htOrderCate.Contains(p_objItemArr[i].m_strORDERCATEID_CHR))
                {
                    m_htOrderCate.Add(p_objItemArr[i].m_strORDERCATEID_CHR, p_objItemArr[i]);
                }
            }

        }

        internal void GetTheControl()
        {
            int m_intNeedConfirm = -1;
            //long lngRes = m_objManage.GetTheComfirmControl(out m_intNeedConfirm, out m_intExeConfirm);

            /*原来的正确代码,需要保留
            ArrayList m_arrControl = new ArrayList();
            m_arrControl.Add("1028");//提交，执行是否需要输入员工号开关 0-不需要 1-需要
            m_arrControl.Add("1029");//执行是否需要输入员工号开关 0-不需要 1-需要
            m_arrControl.Add("1036");//医嘱录入是否可以录入缺药的收费项目 0-否，1-是 1036
            m_arrControl.Add("1037");//医嘱录入是否可以录入已停用的收费项目 0-否,1-是 1037           
            m_arrControl.Add("1038");//'1038', '住院转抄界面是否显示审核提醒', '0-否；1-是', 1,
            m_arrControl.Add("1039");//'1039', '住院转抄界面审核提醒显示间隔时间', '单位:秒', 10, 
            m_arrControl.Add("1040");//'1040', '住院转抄界面审核提醒窗体显示停留时间', '单位:秒', 5, 
            m_arrControl.Add("1018");//m_dmlMedOCMin = 0;//欠费病人药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额
            m_arrControl.Add("1019");//m_dmlNoMedOCMin = 0;//欠费病人非药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额
            m_arrControl.Add("1020");//m_dmlMedICMin = 0;//普通病人药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额
            m_arrControl.Add("1021");//m_dmlNoMedICMin = 0;//普通病人非药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额
            m_arrControl.Add("1030");//m_intMoneyControl = 0;//'1030', '控制护士执行模块是否允许欠费病人执行医嘱', '0-不允许 1-允许'
            m_arrControl.Add("1046");//'1046', '允许欠费执行时且病人将欠费时的病人费用提示开关', '0-不提示 1-提示'
            m_arrControl.Add("1047");//'1047', '医嘱执行界面是否允许自行选择医嘱执行开关', '0-不允许 1-允许'
            m_arrControl.Add("1049");//'1049', '控制诊疗项目对应关联收费项目（一对多）是否摆药',  '0-不摆药 1-摆药'           
            m_arrControl.Add("4006");//设置为8，则组合中检验（发票分类为检验）收费项目>8个时启用打折功能
            m_arrControl.Add("4007");//设置启用打折功能时，检验收费项目的打折比例。80，则打八折
            m_arrControl.Add("4008");//0 不打折 1 允许打折
            m_arrControl.Add("1053");//'1053', '住院医嘱录入界面是否自动提示当前病人存在停用或缺药的未停医嘱', '0-否；1-是', 1
            */


            //以下是新代码
            System.Collections.Generic.List<string> m_glstControl = new System.Collections.Generic.List<string>();
            m_glstControl.Add("1028");//提交，执行是否需要输入员工号开关 0-不需要 1-需要
            m_glstControl.Add("1029");//执行是否需要输入员工号开关 0-不需要 1-需要
            m_glstControl.Add("1036");//医嘱录入是否可以录入缺药的收费项目 0-否，1-是 1036
            m_glstControl.Add("1037");//医嘱录入是否可以录入已停用的收费项目 0-否,1-是 1037           
            m_glstControl.Add("1038");//'1038', '住院转抄界面是否显示审核提醒', '0-否；1-是', 1,
            m_glstControl.Add("1039");//'1039', '住院转抄界面审核提醒显示间隔时间', '单位:秒', 10, 
            m_glstControl.Add("1040");//'1040', '住院转抄界面审核提醒窗体显示停留时间', '单位:秒', 5, 
            m_glstControl.Add("1018");//m_dmlMedOCMin = 0;//欠费病人药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额
            m_glstControl.Add("1019");//m_dmlNoMedOCMin = 0;//欠费病人非药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额
            m_glstControl.Add("1020");//m_dmlMedICMin = 0;//普通病人药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额
            m_glstControl.Add("1021");//m_dmlNoMedICMin = 0;//普通病人非药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额
            m_glstControl.Add("1030");//m_intMoneyControl = 0;//'1030', '控制护士执行模块是否允许欠费病人执行医嘱', '0-不允许 1-允许'
            m_glstControl.Add("1046");//'1046', '允许欠费执行时且病人将欠费时的病人费用提示开关', '0-不提示 1-提示'
            m_glstControl.Add("1047");//'1047', '医嘱执行界面是否允许自行选择医嘱执行开关', '0-不允许 1-允许'
            m_glstControl.Add("1049");//'1049', '控制诊疗项目对应关联收费项目（一对多）是否摆药',  '0-不摆药 1-摆药'           
            m_glstControl.Add("4006");//设置为8，则组合中检验（发票分类为检验）收费项目>8个时启用打折功能
            m_glstControl.Add("4007");//设置启用打折功能时，检验收费项目的打折比例。80，则打八折
            m_glstControl.Add("4008");//0 不打折 1 允许打折
            m_glstControl.Add("1053");//'1053', '住院医嘱录入界面是否自动提示当前病人存在停用或缺药的未停医嘱', '0-否；1-是', 1
            m_glstControl.Add("1050"); // '1050' 检验医嘱在执行还是在提交时发送检验申请单；  0-执行时发送 1-提交时发送

            //以上是新代码

            DataTable dtbResult = null;
            long lngRes = m_objManage.GetTheHisControl(m_glstControl, out  dtbResult);
            int intRowCount = dtbResult.Rows.Count; //new code

            if (lngRes > 0 && dtbResult != null && intRowCount > 0)
            {
                System.Data.DataRow objRow = null;//new code

                for (int i = 0; i < intRowCount; i++)
                {
                    objRow = dtbResult.Rows[i];//new code
                    string strSetID = objRow["setid_chr"].ToString().TrimEnd();//new code
                    string strSetStatus = objRow["setstatus_int"].ToString().TrimEnd();//new code
                    switch (strSetID)
                    {
                        case "1028":
                            if (strSetStatus.Equals("0"))
                            {
                                m_blNeedComfirm = false;
                            }
                            else
                            {
                                m_blNeedComfirm = true;
                            }
                            break;
                        case "1029":
                            if (strSetStatus.Equals("0"))
                            {
                                m_blExeConfirm = false;
                            }
                            else
                            {
                                m_blExeConfirm = true;
                            }
                            break;
                        case "1038"://'1038', '住院转抄界面是否显示审核提醒', '0-否；1-是', 1,
                            if (strSetStatus.Equals("0"))
                            {
                                m_blNeedMessageAlert = false;
                            }
                            else
                            {
                                m_blNeedMessageAlert = true;
                            }
                            break;
                        case "1039"://'1039', '住院转抄界面审核提醒显示间隔时间', '单位:秒', 10, 
                            if (!strSetStatus.Equals(""))
                            {
                                m_intMessageOpenTime = int.Parse(strSetStatus);
                            }
                            break;
                        case "1040"://'1040', '住院转抄界面审核提醒窗体显示停留时间', '单位:秒', 5, 
                            if (!strSetStatus.Equals(""))
                            {
                                m_intMessageCloseTime = int.Parse(strSetStatus);
                            }
                            break;
                        case "1018":
                            m_dmlMedOCMin = decimal.Parse(strSetStatus);//欠费病人药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额
                            break;
                        case "1019":
                            m_dmlNoMedOCMin = decimal.Parse(strSetStatus);//欠费病人非药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额
                            break;
                        case "1020":
                            m_dmlMedICMin = decimal.Parse(strSetStatus);//普通病人药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额
                            break;
                        case "1021":
                            m_dmlNoMedICMin = decimal.Parse(strSetStatus);//普通病人非药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额
                            break;
                        case "1030":
                            if (strSetStatus.Equals("0"))
                            {
                                m_blMoneyControl = false;
                            }
                            else
                            {
                                m_blMoneyControl = true;
                            }

                            break;
                        case "1046":
                            if (strSetStatus.Equals("0"))
                            {
                                m_blLessExecuteAlert = false;
                            }
                            else
                            {
                                m_blLessExecuteAlert = true;
                            }
                            break;
                        case "1047":
                            if (strSetStatus.Equals("0"))
                            {
                                m_blCanSelectOrder = false;
                            }
                            else
                            {
                                m_blCanSelectOrder = true;
                            }
                            break;
                        case "1049":
                            if (strSetStatus.Equals("0"))
                            {
                                m_blPutMedicineFormDic = false;
                            }
                            else
                            {
                                m_blPutMedicineFormDic = true;
                            }
                            break;
                        case "4006":
                            int.TryParse(strSetStatus, out m_intLisDiscountNum);
                            break;
                        case "4007":
                            decimal.TryParse(strSetStatus, out m_decLisDiscountMount);
                            break;
                        case "4008":
                            if (strSetStatus.Equals("0"))
                            {
                                m_blLisDiscount = false;
                            }
                            else
                            {
                                m_blLisDiscount = true;
                            }
                            break;
                        case "1036":
                            if (strSetStatus.Equals("1"))
                            {
                                m_blDeableMedControl = true;
                            }
                            else
                            {
                                m_blDeableMedControl = false;
                            }
                            break;
                        case "1037":
                            if (strSetStatus.Equals("1"))
                            {
                                m_blStopControl = true;
                            }
                            else
                            {
                                m_blStopControl = false;
                            }
                            break;
                        case "1053":
                            if (strSetStatus.Equals("1"))
                            {
                                m_blAutoStopAlert = true;
                            }
                            else
                            {
                                m_blAutoStopAlert = false;
                            }
                            break;
                        case "1050":
                            if (strSetStatus.Equals("0"))
                            {
                                m_blSendLisBill = false;
                            }
                            else
                            {
                                m_blSendLisBill = true;
                            }
                            break;
                    }
                }
            }

        }

        #region 床位号事件
        internal void m_txtBedNo2FindItem(string strFindCode, ListView lvwList)
        {

            this.m_objViewer.m_txtBedNo2.Tag = null;
            /*<----------------------------------------*/

            if (this.m_objViewer.m_txtArea.Tag == null)
            {
                //if (m_blnPrompt) MessageBox.Show("请先指定病区!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("请先指定病区!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_txtArea.Text = "";
                this.m_objViewer.m_txtArea.Tag = null;
                this.m_objViewer.m_txtArea.Focus();
                return;
            }
            string strAreaID = (string)this.m_objViewer.m_txtArea.Tag;
            clsBIHBed[] arrBed = null;
            string strBedNo = this.m_objViewer.m_txtBedNo2.Text.Trim();
            ArrayList m_arrBedList = GetTheBed(strFindCode);

            if (m_arrBedList.Count > 0)
            {
                arrBed = (clsBIHBed[])m_arrBedList.ToArray(typeof(clsBIHBed));
            }
            //long ret = m_objService.m_lngGetBihBedByArea(strAreaID, strBedNo, out arrBed);
            if (arrBed != null)
            {
                if (arrBed.Length == 0)
                {
                    MessageBox.Show("当前科室没有相应当前操作条件的床位，请重新选病区", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.m_objViewer.m_txtBedNo2.Focus();
                    return;
                }
                string upName = "";
                for (int i = 0; i < arrBed.Length; i++)
                {
                    //为床号列表加上姓名及姓别 
                    // ListViewItem objItem = m_lvwBed.Items.Add(arrBed[i].m_strBedName);
                    /*------------------------------------>*/
                    //if (i > 0)
                    //{
                    //    upName = arrBed[i - 1].m_objPatient.m_strAreaName;
                    //}
                    //if (arrBed[i].m_objPatient.m_strAreaName.Trim().Equals(upName.Trim()))
                    //{
                    //    upName = "";
                    //}
                    //else
                    //{
                    //    upName = arrBed[i].m_objPatient.m_strAreaName;
                    //}

                    //ListViewItem objItem = new ListViewItem(upName);
                    ListViewItem objItem = new ListViewItem(arrBed[i].m_strBedName);
                    objItem.SubItems.Add(arrBed[i].m_objPatient.m_strPatientName);
                    objItem.SubItems.Add(arrBed[i].m_objPatient.m_strSex);
                    /*<----------------------*/
                    //objItem.Tag = arrBed[i].m_strBedID;
                    objItem.Tag = arrBed[i];
                    lvwList.Items.Add(objItem);

                }

            }
            else
            {
                MessageBox.Show("当前科室没有相应的床位，请重新选病区", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
        }

        /// <summary>
        /// 得到当前床号列表
        /// </summary>
        /// <returns></returns>
        private ArrayList GetTheBed(String m_strBedNo)
        {
            ArrayList m_arrBeds = new ArrayList();
            ArrayList m_arrBedList = new ArrayList();
            clsBIHCanExecOrder[] arrExecOrder;
            DataView myDataView = new DataView(m_dtExecOrder);
            filltheExecOrderTable(myDataView, out arrExecOrder);
            string m_strBedIdSelect = "";//已选定的床号（快捷键选定)
            //是否是快捷键方式选床号过滤
            if (m_blBedIdKey)
            {
                if (m_intBedIndex != -1 && m_arrBedIdList != null && m_arrBedIdList.Count > 0)
                {
                    if (m_intBedIndex >= m_arrBedIdList.Count || m_intBedIndex <= -1)
                    {
                        m_intBedIndex = 0;
                    }
                    m_strBedIdSelect = Convert.ToString(m_arrBedIdList[m_intBedIndex]);
                }
                m_blBedIdKey = false;
            }
            /*<============================*/
            for (int i = 0; i < arrExecOrder.Length; i++)
            {
                clsBIHCanExecOrder order = arrExecOrder[i];
                if (m_strBedIdSelect.Equals(""))
                {
                    if (!order.m_strBedName.Contains(m_strBedNo))
                    {
                        continue;
                    }
                }
                else
                {
                    if (!order.m_strBedID.Equals(m_strBedIdSelect))
                    {
                        continue;
                    }
                }

                if (!m_arrBeds.Contains(order.m_strBedID))
                {
                    m_arrBeds.Add(order.m_strBedID);
                    clsBIHBed m_objBed = new clsBIHBed();
                    //m_objBed.m_strAreaID = order.m_strCURAREAID_CHR;
                    m_objBed.m_strBedID = order.m_strBedID;
                    //m_objBed.m_strBedName = order.m_strCURBEDName;
                    m_objBed.m_strBedName = order.m_strBedName;
                    m_objBed.m_objPatient = new clsBIHPatientInfo();
                    m_objBed.m_objPatient.m_strPatientName = order.m_strPatientName;
                    //m_objBed.m_objPatient.m_strAreaName = order.m_strCURAREAName;
                    m_objBed.m_objPatient.m_strSex = order.m_strPatientSex;
                    m_arrBedList.Add(m_objBed);

                }
            }
            return m_arrBedList;
        }

        internal void m_txtBedNo2InitListView(ListView lvwList)
        {
            // lvwList.Columns.Add("病  区", 100, HorizontalAlignment.Left);
            lvwList.Columns.Add("床　号", 40, HorizontalAlignment.Left);
            lvwList.Columns.Add("姓　名", 80, HorizontalAlignment.Left);
            lvwList.Columns.Add("性　别", 40, HorizontalAlignment.Left);
            lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvwList.Width = 170;
            /* <<================================= */
        }

        internal void m_txtBedNo2SelectItem(ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {
                this.m_objViewer.m_txtBedNo2.Text = lviSelected.SubItems[0].Text;
                this.m_objViewer.m_txtBedNo2.Tag = lviSelected.Tag;
                this.m_objViewer.m_txtBedNo2.SelectAll();
                this.m_objViewer.m_cboCode.SelectedIndex = 1;
                refreshTheDataByBed(true);
            }
        }

        internal void refreshTheDataByBed(bool isBed)
        {
            if (isBed)
            {
                if (this.m_objViewer.m_txtBedNo2.Tag is clsBIHBed)
                {
                    if (m_dtExecOrder == null) return;
                    DataView myDataView = new DataView(m_dtExecOrder);
                    myDataView.RowFilter = "bedid_chr = '" + ((clsBIHBed)this.m_objViewer.m_txtBedNo2.Tag).m_strBedID + "'";
                    myDataView.Sort = "code_chr, registerid_chr, recipeno_int, orderid_chr asc";

                    clsBIHCanExecOrder[] arrExecOrder;
                    filltheExecOrderTable(myDataView, out arrExecOrder);
                    BindTheBihOrderList(arrExecOrder);
                }
            }
            else if (!isBed)
            {
                if (m_dtExecOrder == null) return;
                DataView myDataView = new DataView(m_dtExecOrder);
                myDataView.Sort = "code_chr, registerid_chr, recipeno_int, orderid_chr asc";
                clsBIHCanExecOrder[] arrExecOrder;
                filltheExecOrderTable(myDataView, out arrExecOrder);
                BindTheBihOrderList(arrExecOrder);
            }
        }
        #endregion

        internal void m_cboCode_SelectedValueChanged()
        {
            if (this.m_objViewer.m_cboCode.SelectedIndex == 0)
            {
                refreshTheDataByBed(false);
            }
            else
            {
                refreshTheDataByBed(true);
            }
        }

        public bool SelectTheOrderFromPerson()
        {
            clsBIHCanExecOrder[] arr = (clsBIHCanExecOrder[])getThePersonFromView().ToArray(typeof(clsBIHCanExecOrder));
            if (arr.Length == 0)
            {
                return false;
            }
            ArrayList m_arrRegisterID = new ArrayList();
            clsBIHCanExecOrder[] arrBed = (clsBIHCanExecOrder[])getThePersonFromView().ToArray(typeof(clsBIHCanExecOrder)); ;
            // 需要皮试的但不是阴性的将要提交的医嘱的病人id
            //ArrayList m_arrFeelTest = GetTheFeelFaulList();
            ArrayList m_arrFeelTest = new ArrayList();
            frmBedPatientList objForm = new frmBedPatientList(m_arrFeelTest, 0);
            objForm.arrBed = arrBed;
            if (objForm.ShowDialog() == DialogResult.OK)
            {

                m_arrRegisterID = objForm.m_arrPersionID;
                if (m_arrRegisterID.Count > 0)
                {
                    //this.m_objViewer.cmdRefurbish_Click(null, null);
                }
                else
                {
                    return false;
                }
                SetTheCheckFromPersionList(m_arrRegisterID);
            }
            else
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获得皮试没结果或为阳性的病人列表
        /// </summary>
        /// <param name="clsBIHCanExecOrder"></param>
        /// <returns></returns>
        private ArrayList GetTheFeelFaulList()
        {
            ArrayList m_arr = new ArrayList();
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
            {
                clsBIHCanExecOrder order = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag;
                if (order.m_intISNEEDFEEL == 1 && (order.m_intFEEL_INT == 2 || order.m_intFEEL_INT == 0))
                {
                    if (!m_arr.Contains(order.m_strRegisterID))
                    {
                        m_arr.Add(order.m_strRegisterID);
                    }
                }

            }
            return m_arr;
        }


        private void SetTheCheckFromPersionList(ArrayList arr)
        {
            clsBIHCanExecOrder order = null;
            string m_strRegisterID = "";
            ArrayList m_arrFellArr = new ArrayList();//不能通过核对的皮试项
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
            {
                order = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag;
                m_strRegisterID = order.m_strRegisterID;
                if (arr.Contains(m_strRegisterID))
                {
                    m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value = "1";
                    if (order.m_intISNEEDFEEL == 1 && order.m_intFEEL_INT != 0 && order.m_strDosetypeID.Trim().Equals(m_objSpecateVo.m_strUSAGEID_CHR.Trim()))//需要特殊收费皮试频率
                    {

                    }
                    else if (order.m_intISNEEDFEEL == 1 && (order.m_intFEEL_INT == 2 || order.m_intFEEL_INT == 0))//需要皮试但还没有皮试结果或为阳性
                    {
                        m_arrFellArr.Add(order);
                        //m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value = "0";
                    }
                }
                else
                {
                    m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value = "0";
                }
            }
            SetTheFeelSameNoSelect(m_arrFellArr);
        }

        /// <summary>
        /// 不能核对的皮试同方的不选中
        /// </summary>
        /// <param name="m_arrFellArr"></param>
        private void SetTheFeelSameNoSelect(ArrayList m_arrFellArr)
        {
            clsBIHCanExecOrder order1, order2;
            for (int i = 0; i < m_arrFellArr.Count; i++)
            {
                order1 = (clsBIHCanExecOrder)m_arrFellArr[i];
                for (int j = 0; j < this.m_objViewer.m_dtvOrderList.RowCount; j++)
                {
                    order2 = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[j].Tag;
                    if (order1.m_strRegisterID == order2.m_strRegisterID && order1.m_intRecipenNo == order2.m_intRecipenNo)
                    {
                        m_objViewer.m_dtvOrderList.Rows[j].Cells["m_dtvselectCheck"].Value = "0";
                    }
                }
            }
        }

        private ArrayList getThePersonFromView()
        {
            int cout = 0;
            ArrayList arr = new ArrayList();
            ArrayList arr2 = new ArrayList();
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.Rows.Count; i++)
            {

                string m_strRegisterID = ((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strRegisterID;
                if (!arr.Contains(m_strRegisterID))
                {
                    arr.Add(m_strRegisterID);
                    arr2.Add((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag);
                }

            }

            return arr2;
        }

        /// <summary>
        /// 编辑皮试
        /// </summary>
        internal void EditFeel()
        {
            if (m_objViewer.m_dtvOrderList.SelectedRows.Count > 0)
            {
                DataGridViewRow row1 = m_objViewer.m_dtvOrderList.SelectedRows[0];
                clsBIHCanExecOrder order = (clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.SelectedRows[0].Tag;
                //如果要皮试则，显示皮试
                if (order.m_intISNEEDFEEL == 0)
                {
                    MessageBox.Show("请单独选中一条有AST()皮试标志的医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //显示皮试录入页面
                clsT_Opr_Bih_OrderFeel_VO m_objFell = new clsT_Opr_Bih_OrderFeel_VO();
                m_objFell.m_strORDERID_CHR = order.m_strOrderID;
                m_objFell.m_strParentName = order.m_strPatientName;
                m_objFell.m_strOrderName = order.m_strName;
                m_objFell.m_intRESULTTYPE_INT = order.m_intFEEL_INT;
                m_objFell.m_strDES_VCHR = order.m_strFEELRESULT_VCHR;
                frmNeedFeel objfrmNeedFeel = new frmNeedFeel(m_objFell);
                if (objfrmNeedFeel.ShowDialog() == DialogResult.OK)
                {

                    int intDeleteFeelFlag = objfrmNeedFeel.m_intFeelFlag;

                    if ((objfrmNeedFeel.p_objRecord.m_intRESULTTYPE_INT == 1 || objfrmNeedFeel.p_objRecord.m_intRESULTTYPE_INT == 0) && intDeleteFeelFlag == 1)
                    {
                        long l = this.m_objManage.m_lngDeleteFeelCharge(order.m_strOrderID);
                    }
                    else if (objfrmNeedFeel.p_objRecord.m_intRESULTTYPE_INT == 2)
                    {
                        DataView myDataView = new DataView(m_dtChargeList);
                        myDataView.RowFilter = "orderid_chr='" + order.m_strOrderID + "'";
                        myDataView.Sort = "FLAG_INT";
                        if (myDataView.Count <= 0)
                        {
                            return;
                        }
                        clsChargeForDisplay[] m_arrObjItem;
                        m_mthGetChargeListFromDateTable(myDataView, out m_arrObjItem);
                        frmFeelCharge objCharge = new frmFeelCharge(m_arrObjItem);
                        if (objCharge.ShowDialog() == DialogResult.OK)
                        {
                            if (objCharge.listFeelCharge == null || objCharge.listFeelCharge.Count == 0)
                            {
                            }
                            else
                            {
                                clsBIHPatientInfo m_objPatient;

                                DataTable m_dtPatient = null;
                                long lngRes = m_objManage.m_lngGetPatientInfoVo(order.m_strRegisterID, out m_dtPatient);
                                if (m_dtPatient != null && m_dtPatient.Rows.Count > 0)
                                {
                                    string m_strInHospitalNoOld = "";
                                    string m_strInHospitalNoNow = "";
                                    m_strInHospitalNoOld = this.m_objViewer.m_ctlPatient.m_txtRegisterid.Text.Trim();
                                    m_strInHospitalNoNow = order.m_strRegisterID.Trim();
                                    if (m_strInHospitalNoOld.Equals(m_strInHospitalNoNow))
                                    {
                                        return;
                                    }

                                    DataView dtPatient = new DataView(m_dtPatient);
                                    dtPatient.RowFilter = "registerid_chr='" + order.m_strRegisterID + "'";
                                    if (dtPatient.Count <= 0)
                                    {
                                        return;
                                    }
                                    m_mthGetPatientInfoFromDateTable(dtPatient, out m_objPatient);

                                    string strItemid = "";
                                    for (int i1 = 0; i1 < objCharge.listFeelCharge.Count; i1++)
                                    {
                                        strItemid += "'" + objCharge.listFeelCharge[i1].m_strChargeID + "',";
                                    }

                                    strItemid = strItemid.TrimEnd(',');

                                    if (intDeleteFeelFlag == 2)
                                    {
                                        if (MessageBox.Show(this.m_objViewer, "该医嘱的皮试已经加收，要这次的皮试费用为准吗？ \r\n[是] 以该次的皮试费为准。[否] 再次加收皮试费 。", "提示框", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            long lngDelete = this.m_objManage.m_lngDeleteFeelCharge(order.m_strOrderID);
                                        }
                                    }

                                    long l = this.m_objManage.m_lngFeelCharge(order.m_strOrderID, strItemid, order.m_intExecuteType, m_objPatient.m_strAreaID,
                                        m_objPatient.m_strBedID, this.m_objViewer.LoginInfo.m_strEmpID, IsChildPrice(order.m_strOrderID));
                                    if (l > 0)
                                    {
                                        MessageBox.Show(this.m_objViewer, "已经成功收取皮试费用。", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    else
                                    {
                                        MessageBox.Show(this.m_objViewer, "皮试费收取失败。", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                    }

                    order.m_intFEEL_INT = objfrmNeedFeel.p_objRecord.m_intRESULTTYPE_INT;
                    order.m_strFEELRESULT_VCHR = objfrmNeedFeel.p_objRecord.m_strDES_VCHR;
                    //if (order.m_intISNEEDFEEL == 1)
                    //{
                    //    string m_strFeel = "";
                    //    switch (order.m_intFEEL_INT)
                    //    {
                    //        case 0:
                    //            m_strFeel = " AST( ) ";
                    //            break;
                    //        case 1:
                    //            m_strFeel = " AST(-) ";
                    //            break;
                    //        case 2:
                    //            m_strFeel = " AST(+) ";
                    //            break;
                    //    }

                    //    //row1.Cells["dtv_Name"].Value = order.m_strName + m_strFeel;

                    //}
                    m_SaveTheATTACHTIMES_INT(order);
                    BindTheBihOrderListDetail(row1, order);
                    refreshTheDataGridView();
                }

                // }
            }
        }

        bool IsChildPrice(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
                return false;
            using (clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject())
            {
                DateTime birthday = svc.GetBirthdayByOrderId(orderId);
                return new clsBrithdayToAge().IsChild(birthday);
            }
        }

        public void PrintFeel()
        {
            ArrayList m_arrExecOrder = new ArrayList();
            for (int i = 0; i < m_objViewer.m_dtvOrderList.RowCount; i++)
            {
                DataGridViewRow row1 = m_objViewer.m_dtvOrderList.Rows[i];
                clsBIHCanExecOrder order = (clsBIHCanExecOrder)row1.Tag;
                if (order.m_intISNEEDFEEL == 1 && order.m_intFEEL_INT > 0)
                {
                    m_arrExecOrder.Add(order);
                }
            }
            if (m_arrExecOrder.Count > 0)
            {
                frmFeelCard m_freCard = new frmFeelCard((clsBIHCanExecOrder[])m_arrExecOrder.ToArray(typeof(clsBIHCanExecOrder)));
                m_freCard.ShowDialog();
            }
        }

        /// <summary>
        /// 信息提醒
        /// </summary>
        internal void MessageList()
        {
            if (m_objViewer.m_txtArea.Tag == null || ((string)m_objViewer.m_txtArea.Tag).Trim().Equals(""))
            {
                return;
            }
            DataTable m_dtNewOrder = null;
            //获取当前需求审核的数据
            long lngRes = m_objManage.m_lngGetOrderMessageByTimer((string)m_objViewer.m_txtArea.Tag, out m_dtNewOrder);
            if (m_dtNewOrder != null && m_dtNewOrder.Rows.Count > 0)
            {
            }
            else
            {
                return;
            }
            //需要审核的提交状态的医嘱
            int m_intExeNewSum = 0;
            //需要审核的停止状态的医嘱
            int m_intExeStopSum = 0;
            //病人列表
            ArrayList m_arrPatient = new ArrayList();
            for (int i = 0; i < m_dtNewOrder.Rows.Count; i++)
            {
                if (m_dtNewOrder.Rows[i]["status_int"].ToString().Equals("1"))
                {
                    m_intExeNewSum++;
                }
                else
                {
                    if (m_dtNewOrder.Rows[i]["status_int"].ToString().Equals("3"))
                    {
                        if (m_dtNewOrder.Rows[i]["EXECUTETYPE_INT"].ToString().Equals("1"))
                        {
                            m_intExeStopSum++;
                        }
                    }
                }
                if (!m_arrPatient.Contains(m_dtNewOrder.Rows[i]["REGISTERID_CHR"].ToString()))
                {
                    m_arrPatient.Add(m_dtNewOrder.Rows[i]["REGISTERID_CHR"].ToString());
                }

            }
            string Remark = "";
            if (m_arrPatient.Count > 0)
            {
                Remark = " 共有 " + m_arrPatient.Count.ToString() + " 个病人的医嘱需要审核";
            }
            if (Remark.Trim().Length > 0)
            {
                Remark += " \r\n" + " ";
                if (m_intExeNewSum > 0)
                {
                    Remark += " 需审核提交的医嘱 " + m_intExeNewSum.ToString() + " 条";
                }
                if (m_intExeStopSum > 0)
                {
                    Remark += " \r\n" + " ";
                    Remark += " 需审核停止的医嘱 " + m_intExeStopSum.ToString() + " 条";
                }
            }
            if (!Remark.Equals(""))
            {
                //int ShowCodexRemarkFrmTimerinterval = ((frmBIHOrderInput)this.ParentForm).ShowCodexRemarkFrmTimerinterval;
                frmMessageRemark frmRemark = new frmMessageRemark(Remark, m_intMessageCloseTime);
                //frmRemark.StartPosition = FormStartPosition.CenterScreen;
                frmRemark.StartPosition = FormStartPosition.Manual;
                frmRemark.Location = new System.Drawing.Point(500, 10);
                frmRemark.m_freNurse = this.m_objViewer;
                frmRemark.Show();
            }



        }

        /// <summary>
        /// 获取住院基本配置表
        /// </summary>
        internal void SetSPECORDERCATE()
        {
            long lngRes = 0;
            lngRes = m_objInputOrder.m_lngAddGetSPECORDERCATE(out m_objSpecateVo);
        }

        /// <summary>
        /// 转到执行界面
        /// </summary>
        internal void m_cmdTurnToExecute()
        {
            frmOrderExecute OrderExecute = new frmOrderExecute(m_objSpecateVo, m_htOrderCate, true);
            //开关传递

            OrderExecute.m_blNeedComfirm = m_blNeedComfirm;
            OrderExecute.m_blExeConfirm = m_blExeConfirm;
            OrderExecute.m_blNeedMessageAlert = m_blNeedMessageAlert;
            OrderExecute.m_intMessageOpenTime = m_intMessageOpenTime;
            OrderExecute.m_intMessageCloseTime = m_intMessageCloseTime;
            OrderExecute.m_dmlMedOCMin = m_dmlMedOCMin;
            OrderExecute.m_dmlNoMedOCMin = m_dmlNoMedOCMin;
            OrderExecute.m_dmlMedICMin = m_dmlMedICMin;
            OrderExecute.m_dmlNoMedICMin = m_dmlNoMedICMin;
            OrderExecute.m_blMoneyControl = m_blMoneyControl;
            OrderExecute.m_blLessExecuteAlert = m_blLessExecuteAlert;
            OrderExecute.m_blCanSelectOrder = m_blCanSelectOrder;
            OrderExecute.m_blPutMedicineFormDic = m_blPutMedicineFormDic;
            OrderExecute.m_intLisDiscountNum = m_intLisDiscountNum;
            OrderExecute.m_decLisDiscountMount = m_decLisDiscountMount;
            OrderExecute.m_blLisDiscount = m_blLisDiscount;
            OrderExecute.m_blAutoStopAlert = m_blAutoStopAlert;
            OrderExecute.m_blDeableMedControl = m_blDeableMedControl;
            OrderExecute.m_blStopControl = m_blStopControl;
            OrderExecute.m_blSendLisBill = m_blSendLisBill;//--
            /*<====================================*/

            OrderExecute.m_txtArea.Tag = this.m_objViewer.m_txtArea.Tag;
            OrderExecute.m_txtArea.Text = this.m_objViewer.m_txtArea.Text;

            this.m_objViewer.m_timerMessage.Enabled = false;
            OrderExecute.ShowDialog();
            this.m_objViewer.m_timerMessage.Enabled = true;
        }



        internal void m_SaveTheEntrust(clsBIHCanExecOrder order1)
        {
            //修改医嘱嘱托
            long lngRes = m_objManage.m_lngSaveTheEntrust(order1.m_strRegisterID, order1.m_intRecipenNo, order1.m_strEntrust);

        }

        internal void m_SaveTheATTACHTIMES_INT(clsBIHCanExecOrder order1)
        {
            //修改医嘱补次
            long lngRes = m_objManage.m_lngSaveTheATTACHTIMES_INT(order1.m_strRegisterID, order1.m_intRecipenNo, order1.m_intATTACHTIMES_INT);

        }

        internal void TheSelectedItemForDrawBack()
        {
            ClearSelect();

            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.SelectedRows.Count; i++)
            {
                DataGridViewRow row1 = this.m_objViewer.m_dtvOrderList.SelectedRows[i];
                clsBIHCanExecOrder order = (clsBIHCanExecOrder)row1.Tag;
                string m_strValue = "1";
                //同方处理
                TheSamerecipeno(order, m_strValue);
            }

        }

        private void ClearSelect()
        {
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
            {
                DataGridViewRow row1 = this.m_objViewer.m_dtvOrderList.Rows[i];
                row1.Cells["m_dtvselectCheck"].Value = "0";
            }
        }

        /// <summary>
        /// 选中的项目转换为CHECKBOX列也选中
        /// </summary>
        internal void SelectItemToChecked()
        {
            //有效的选中列(皮试没有结果或为阴性的为无效)
            ArrayList m_arrActive = new ArrayList();
            //不能过核对的皮试数组
            ArrayList m_arrFeelDeable = new ArrayList();
            string m_strID = "";
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.Rows.Count; i++)
            {
                clsBIHCanExecOrder order = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag;
                m_strID = order.m_strRegisterID + "," + order.m_intRecipenNo.ToString() + ";";
                if (order.m_intISNEEDFEEL == 1)//需要特殊收费皮试频率
                {
                    if (order.m_intISNEEDFEEL == 1 && order.m_intFEEL_INT != 0 && order.m_strDosetypeID.Trim().Equals(m_objSpecateVo.m_strUSAGEID_CHR.Trim()))//需要特殊收费皮试频率
                    {
                    }
                    else if (order.m_intISNEEDFEEL == 1 && (order.m_intFEEL_INT == 2 || order.m_intFEEL_INT == 0))//需要皮试但还没有皮试结果或为阳性
                    {
                        //需要皮试但还没有皮试结果或为阳性不选中
                        m_arrFeelDeable.Add(m_strID);
                    }
                }
            }
            m_strID = "";//病人流水登记号及方号组合
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.SelectedRows.Count; i++)
            {
                clsBIHCanExecOrder order = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.SelectedRows[i].Tag;
                m_strID = order.m_strRegisterID + "," + order.m_intRecipenNo.ToString() + ";";
                m_arrActive.Add(m_strID);

            }
            m_strID = "";
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.Rows.Count; i++)
            {
                clsBIHCanExecOrder order = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag;
                m_strID = order.m_strRegisterID + "," + order.m_intRecipenNo.ToString() + ";";
                if (m_arrActive.Contains(m_strID) && !m_arrFeelDeable.Contains(m_strID))
                {
                    this.m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value = "1";
                }
                else
                {
                    this.m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value = "0";
                }

            }

        }

        /// <summary>
        /// 清空当前的所有选中
        /// </summary>
        internal void ClearTheChecked()
        {
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.Rows.Count; i++)
            {
                this.m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value = "0";
            }
        }

        /// <summary>
        /// 刷新当前医嘱项目的信息，包括同方医嘱 的补次或嘱托信息
        /// </summary>
        /// <param name="order1"></param>
        internal void RefreshTheOrderListData(clsBIHCanExecOrder order1)
        {
            string m_strID = order1.m_strRegisterID + "," + order1.m_intRecipenNo.ToString();
            string m_strTemp = "";
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
            {
                clsBIHCanExecOrder order = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag;
                m_strTemp = order.m_strRegisterID + "," + order.m_intRecipenNo.ToString();
                if (m_strID.Equals(m_strTemp))
                {
                    order.m_intATTACHTIMES_INT = order1.m_intATTACHTIMES_INT;
                    order.m_strEntrust = order1.m_strEntrust;

                    DataGridViewRow row1 = this.m_objViewer.m_dtvOrderList.Rows[i];
                    BindTheBihOrderListDetail(row1, order);
                }
            }
            refreshTheDataGridView();
        }

        internal void m_cmdBedIdKeySelect()
        {

            m_blBedIdKey = true;
            if (m_arrBedIdList != null && m_arrBedIdList.Count > 0)
            {
                if (this.m_objViewer.m_txtBedNo2.Tag is clsBIHBed)
                {
                    string m_strBedID = ((clsBIHBed)this.m_objViewer.m_txtBedNo2.Tag).m_strBedID;
                    for (int i = 0; i < m_arrBedIdList.Count; i++)
                    {
                        if (m_arrBedIdList[i].ToString().Equals(m_strBedID))
                        {
                            m_intBedIndex = i++;
                            break;
                        }

                    }
                }
            }
            else
            {
                m_intBedIndex++;
            }
            this.m_objViewer.m_txtBedNo2.Text = "";
            this.m_objViewer.m_txtBedNo2.Focus();
            SendKeys.Send("{ENTER}");

        }

        internal void GetTheStopOrder()
        {

            //检查医嘱是否停用
            ArrayList m_arrOrderIDs = new ArrayList();
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
            {
                clsBIHCanExecOrder order = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag;
                if ((order.m_intStatus == 1 || order.m_intStatus == 5) && !m_arrOrderIDs.Contains(order.m_strOrderID))
                {
                    m_arrOrderIDs.Add(order.m_strOrderID);
                }
            }
            ArrayList m_strOrders = GetTheStopOrders(m_arrOrderIDs);
            if (m_strOrders != null && m_strOrders.Count > 0)
            {
                string m_strErrMessage = "";
                for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
                {
                    clsBIHCanExecOrder order = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag;
                    if (m_strOrders.Contains(order.m_strOrderID))
                    {
                        if (!m_strErrMessage.Contains(order.m_strName))
                        {
                            m_strErrMessage += order.m_strName + "\r\n";
                        }
                        this.m_objViewer.m_dtvOrderList.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Brown;
                    }
                }
                if (!m_strErrMessage.Trim().Equals(""))
                {
                    m_strErrMessage = "以下医嘱因相关收费项目停用或药品停药!" + "\r\n" + m_strErrMessage;
                    MessageBox.Show(m_strErrMessage, "停用提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            /*<==================================*/
        }

        /// <summary>
        /// 返回当前停用或停药的医嘱流水数组
        /// </summary>
        /// <param name="m_arrOrderIDs"></param>
        /// <returns></returns>
        private ArrayList GetTheStopOrders(ArrayList m_arrOrderIDs)
        {
            ArrayList m_arrStopOrderIds = new ArrayList();
            if (m_arrOrderIDs.Count <= 0)
            {
                return m_arrStopOrderIds;
            }
            string[] m_strOrders = (string[])m_arrOrderIDs.ToArray(typeof(string));
            DataTable m_dtOrderSign = null;
            this.m_objManage.m_lngGetOrderStopSign(m_strOrders, out m_dtOrderSign);
            if (m_dtOrderSign != null)
            {
                string orderid_chr = "";
                string STATUS_INT = "";//(诊疗项目状态 0-停用 1-正常)
                string IFSTOP_INT = "";//停用标志 1-停用 0-正常
                string ITEMSRCTYPE_INT = "";//项目来源类型1－药品表
                string IPNOQTYFLAG_INT = "";//中心药房缺药标志 0-有药 1－缺药
                bool m_blStop = false;
                for (int i = 0; i < m_dtOrderSign.Rows.Count; i++)
                {
                    m_blStop = false;
                    DataRow row = m_dtOrderSign.Rows[i];
                    orderid_chr = row["orderid_chr"].ToString().Trim();
                    STATUS_INT = row["STATUS_INT"].ToString().Trim();//(诊疗项目状态 0-停用 1-正常)
                    IFSTOP_INT = row["IFSTOP_INT"].ToString().Trim();//停用标志 1-停用 0-正常
                    ITEMSRCTYPE_INT = row["ITEMSRCTYPE_INT"].ToString().Trim();//项目来源类型1－药品表
                    IPNOQTYFLAG_INT = row["IPNOQTYFLAG_INT"].ToString().Trim();//中心药房缺药标志 0-有药 1－缺药
                    if ((STATUS_INT.Equals("0") || IFSTOP_INT.Equals("1")))
                    {
                        if (!m_blStopControl)
                        {
                            m_blStop = true;
                        }
                    }

                    if (!m_blDeableMedControl)
                    {
                        if (ITEMSRCTYPE_INT.Equals("1") && IPNOQTYFLAG_INT.Equals("1"))
                        {
                            m_blStop = true;
                        }
                    }


                    if (m_blStop)
                    {
                        if (!m_arrStopOrderIds.Contains(orderid_chr))
                        {
                            m_arrStopOrderIds.Add(orderid_chr);
                        }
                    }

                }

            }
            return m_arrStopOrderIds;

        }


        internal void setTheCurrentPatient()
        {
            if (this.m_objViewer.m_dtvOrderList.SelectedRows.Count <= 0)
            {
                return;
            }
            clsBIHCanExecOrder order = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.SelectedRows[0].Tag;
            BindthePatient(order);
        }
    }
}
