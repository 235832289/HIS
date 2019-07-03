using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.BIHOrderServer;

namespace com.digitalwave.iCare.BIHOrder
{
    public partial class frmChargeList : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        public ListViewItem[] arrItem = new ListViewItem[0];
        public ListViewItem m_lviSItem = new ListViewItem();
        /// <summary>
        /// 直接生成医嘱的诊疗项目数组
        /// </summary>
        public ListViewItem[] m_lviSItemArr = null;
        public DataSet m_dsDicChargeSet;
        /// <summary>
        /// 诊疗项目类型ID
        /// </summary>
        private string m_strORDERCATEID_CHR = "";
        /// <summary>
        /// 欠费开关
        /// </summary>
        private bool m_blLessMedControl = false;
        /// <summary>
        ///  查询类型
        /// </summary>
        private int m_intClass = 0;
        /// <summary>
        /// 类型名称
        /// </summary>
        private string m_strOrderName = "";
        /// <summary>
        /// 医嘱类型列表
        /// </summary>
        public Hashtable m_htOrderCate = new Hashtable();
        /// <summary>
        /// 停用医嘱是否可录入开关
        /// </summary>
        private bool m_blStopControl = true;
        /// <summary>
        /// 缺药的项目是否可以录入0-不可以false，1-可以true
        /// </summary>
        private bool m_blDeableMedControl = false;
        /// <summary>
        /// 药品库存量
        /// </summary>
        public float m_dmlOpcurrentgross_num = 0;
        /// <summary>
        /// 记录是否是药品 1是药品  2为材料
        /// </summary>
        public int m_intITEMSRCTYPE_INT = 0;
        /// <summary>
        /// 药房ID
        /// </summary>
        public string m_strMedDeptId = "";
        /// <summary>
        /// 身份ID
        /// </summary>
        public string strPayType = string.Empty;
        /// <summary>
        /// 适应症.备注
        /// </summary>
        public string syzRemark { get; set; }

        /// <summary>
        /// 是否儿童价格
        /// </summary>
        internal bool isChildPrice { get; set; }

        public frmChargeList()
        {
            InitializeComponent();
            arrItem = new ListViewItem[0];

        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_ChargeList();
            objController.Set_GUI_Apperance(this);
        }

        public frmChargeList(string m_strFindText, string ORDERCATEID_CHR, bool LessMedControl, int SelectClass, Hashtable m_htCate, bool StopControl, bool DeableMedControl, bool _isChildPrice)
        {
            m_htOrderCate = m_htCate;
            m_strORDERCATEID_CHR = ORDERCATEID_CHR;
            m_blLessMedControl = LessMedControl;
            m_intClass = SelectClass;
            m_strOrderName = m_strFindText;
            InitializeComponent();
            arrItem = new ListViewItem[0];
            m_blStopControl = StopControl;
            m_blDeableMedControl = DeableMedControl;
            this.isChildPrice = _isChildPrice;
        }

        private void frmChargeList_Load(object sender, EventArgs e)
        {
            m_txtFind.Text = m_strOrderName.TrimStart(@"/".ToCharArray());
            seachClass.SelectedIndex = m_intClass;

            clsT_aid_bih_ordercate_VO p_objItem;
            p_objItem = (clsT_aid_bih_ordercate_VO)m_htOrderCate[m_strORDERCATEID_CHR];
            if (p_objItem != null && p_objItem.m_strVIEWNAME_VCHR.Trim().Equals("文字医嘱"))
            {
                this.m_plTextOrder.Visible = true;
                this.m_cmdTextOrder.Visible = true;
            }


            LoadTheData();

        }

        private void LoadTheData()
        {
            m_lvwList.Items.Clear();
            m_lvwList.Items.AddRange(arrItem);
            if (m_lvwList.Items.Count > 0)
            {
                m_lvwList.Items[0].Selected = true;
                m_lvwList.Focus();
                if (m_dsDicChargeSet != null && m_dsDicChargeSet.Tables.Count > 0)
                {
                    DataView myDataView = m_dsDicChargeSet.Tables[0].DefaultView;
                    myDataView.RowFilter = "orderdicid_chr='" + ((clsBIHOrderDic)m_lvwList.SelectedItems[0].Tag).m_strOrderDicID + "'";
                    //m_dtvOrderdicCharge.DataSource = myDataView;
                    bintheChargeList(myDataView);
                    ClearTheBlank();
                }
                if (this.m_plTextOrder.Visible)
                {
                    SendKeys.Send("{F2}");
                }
                /*<=====================================*/
            }
            else if (this.m_plTextOrder.Visible)
            {
                this.txtInfo.Text = m_txtFind.Text;
                SendKeys.Send("{F2}");
            }
            else
            {

                SendKeys.Send("{Tab}");
                SendKeys.Send("{Tab}");
            }

        }


        private void m_lvwList_DoubleClick(object sender, EventArgs e)
        {
            if (m_lvwList.SelectedItems.Count <= 0)
            {
                return;
            }
            else
            {
                if (((clsBIHOrderDic)m_lvwList.SelectedItems[0].Tag).m_strDesc.Trim().Equals("*"))
                {
                    return;
                }
                if (m_blDeableMedControl == false)
                {
                    if (((clsBIHOrderDic)m_lvwList.SelectedItems[0].Tag).m_intIPNOQTYFLAG_INT == 1)
                    {
                        MessageBox.Show("不能选择缺药的项!", "提示!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }

                }
                //记录是否是药品
                this.m_intITEMSRCTYPE_INT = ((clsBIHOrderDic)m_lvwList.SelectedItems[0].Tag).m_intITEMSRCTYPE_INT;

                //库存量(求和后计算)
                int intOrderdicChargeCount = m_dtvOrderdicCharge.RowCount;
                for (int intI1 = 0; intI1 < intOrderdicChargeCount; intI1++)
                {
                    this.m_dmlOpcurrentgross_num += Convert.ToSingle(m_dtvOrderdicCharge.Rows[intI1].Cells["QTY_INT"].Value.ToString());
                }
                if (m_blStopControl == false)
                {

                    bool m_blCheck = false;
                    if (m_dsDicChargeSet != null && m_dsDicChargeSet.Tables.Count > 0)
                    {
                        DataView myDataView = m_dsDicChargeSet.Tables[0].DefaultView;
                        myDataView.RowFilter = "orderdicid_chr='" + ((clsBIHOrderDic)m_lvwList.SelectedItems[0].Tag).m_strOrderDicID + "'";
                        m_blCheck = CheckTheStopCharge(myDataView);

                    }
                    if (m_blCheck)
                    {
                        MessageBox.Show("不能选择已停用收费项目!", "提示!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                m_lviSItem = m_lvwList.SelectedItems[0];
                clsBIHOrderInputDomain m_objDomain = new clsBIHOrderInputDomain();
                ArrayList PARMCODE_CHR = new ArrayList();
                PARMCODE_CHR.Add("0008");
                DataTable m_dtPARMVALUE_VCHR = new DataTable();
                string str = string.Empty;
                long lngRes = m_objDomain.LoadThePARMVALUE(PARMCODE_CHR, out m_dtPARMVALUE_VCHR);
                if (m_dtPARMVALUE_VCHR.Rows.Count > 0)
                {
                    str = m_dtPARMVALUE_VCHR.Rows[0]["PARMVALUE_VCHR"].ToString();
                }
                if (str.Contains(strPayType))
                {
                    string strRemark = string.Empty;
                    string strItemName = string.Empty;
                    bool blnRes = m_objDomain.m_blnShiying(((clsBIHOrderDic)m_lvwList.SelectedItems[0].Tag).m_strOrderDicID, out strRemark, out strItemName);
                    if (blnRes)
                    {
                        // 限二级及二级以上医院
                        if (strRemark.Trim() == "限二级及二级以上医院" || strRemark.Trim() == "限二级以上医院")
                            MessageBox.Show("该项目限【" + strRemark + "】使用。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        else
                            MessageBox.Show("该项目限【" + strRemark + "】使用。" + Environment.NewLine + "判断本处方是否符合限制条件后，请在下拉框选择【符合】、【不符合】。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        this.syzRemark = strRemark;
                    }
                }
                this.DialogResult = DialogResult.OK;

            }
        }

        private bool CheckTheStopCharge(DataView myDataView)
        {
            if (myDataView.Count > 0)
            {

                for (int i = 0; i < myDataView.Count; i++)
                {
                    DataRowView row = myDataView[i];
                    if (row["IFSTOP_INT"].ToString().Trim().Equals("1"))//1停用，0-正常
                    {
                        return true; ;
                    }

                }
            }
            return false;

        }

        private void m_lvwList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    m_lvwList_DoubleClick(null, null);
                    break;
                case Keys.Escape:

                    this.DialogResult = DialogResult.No;
                    break;
            }
        }

        private void m_lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_lvwList.SelectedItems.Count > 0)
            {
                this.m_cmdAddOrder.Enabled = true;
                if (((clsBIHOrderDic)m_lvwList.SelectedItems[0].Tag).m_strDesc.Trim().Equals("*"))
                {
                    this.m_cmdAddOrder.Enabled = false;
                }

                if (m_dsDicChargeSet != null && m_dsDicChargeSet.Tables.Count > 0)
                {
                    DataView myDataView = m_dsDicChargeSet.Tables[0].DefaultView;
                    myDataView.RowFilter = "orderdicid_chr='" + ((clsBIHOrderDic)m_lvwList.SelectedItems[0].Tag).m_strOrderDicID + "'";
                    //m_dtvOrderdicCharge.DataSource = myDataView;
                    //m_dtvOrderdicCharge.DataMember = "chargeList";
                    bintheChargeList(myDataView);

                    ClearTheBlank();
                }

                clsT_aid_bih_ordercate_VO p_objItem;
                p_objItem = (clsT_aid_bih_ordercate_VO)m_htOrderCate[((clsBIHOrderDic)m_lvwList.SelectedItems[0].Tag).m_strOrderCateID];
                if (p_objItem != null && p_objItem.m_strVIEWNAME_VCHR.Trim().Equals("文字医嘱"))
                {
                    this.m_plTextOrder.Visible = true;
                    this.m_cmdTextOrder.Visible = true;

                }
                else
                {
                    this.m_plTextOrder.Visible = false;
                    this.m_cmdTextOrder.Visible = false;
                }
                //更新到文字医嘱输入框
                txtInfo.Text = ((clsBIHOrderDic)m_lvwList.SelectedItems[0].Tag).m_strName;
                txtInfo.Tag = (clsBIHOrderDic)m_lvwList.SelectedItems[0].Tag;
                /*<=====================================*/


            }
        }

        private void bintheChargeList(DataView myDataView)
        {
            m_dtvOrderdicCharge.Rows.Clear();
            double m_intChargeSum = 0;
            double QTY_INT = 0, MinPrice = 0;
            if (myDataView.Count > 0)
            {
                QTY_INT = 0;
                MinPrice = 0;
                for (int i = 0; i < myDataView.Count; i++)
                {
                    DataRowView row = myDataView[i];

                    m_dtvOrderdicCharge.Rows.Add();
                    DataGridViewRow m_dgvRow = m_dtvOrderdicCharge.Rows[m_dtvOrderdicCharge.RowCount - 1];
                    m_dgvRow.Cells["itemCode"].Value = row["ITEMCODE_VCHR"].ToString();
                    m_dgvRow.Cells["ItemName"].Value = row["ItemName"].ToString();
                    if (row["IsChiefItem"].ToString().Trim().Equals("1"))
                    {
                        m_dgvRow.Cells["IsChiefItem"].Value = "主";
                    }
                    else
                    {
                        m_dgvRow.Cells["IsChiefItem"].Value = "";
                    }
                    m_dgvRow.Cells["QTY_INT"].Value = row["QTY_INT"].ToString();
                    if (row["ipcurrentgross_num"].ToString().Trim() == "")
                    {
                        m_dgvRow.Cells["QTY_INT"].Value = 0;
                    }
                    else
                    {
                        m_dgvRow.Cells["QTY_INT"].Value = row["ipcurrentgross_num"].ToString().Trim();
                    }
                    double.TryParse(row["QTY_INT"].ToString(), out QTY_INT);
                    double.TryParse(row["MinPrice"].ToString(), out MinPrice);
                    m_dgvRow.Cells["DOSAGE_DEC"].Value = row["DOSAGE_DEC"].ToString();
                    m_dgvRow.Cells["DOSAGEUNIT_CHR"].Value = row["DOSAGEUNIT_CHR"].ToString();
                    m_dgvRow.Cells["ITEMIPUNIT_CHR"].Value = row["ITEMIPUNIT_CHR"].ToString();
                    m_dgvRow.Cells["ITEMSPEC_VCHR"].Value = row["ITEMSPEC_VCHR"].ToString().Trim();
                    m_dgvRow.Cells["MinPrice"].Value = row["MinPrice"].ToString();
                    if (row["itemsrctype_int"].ToString().Trim().Equals("1") && row["IPNOQTYFLAG_INT"].ToString().Trim().Equals("1"))
                    {
                        m_dgvRow.Cells["IPNOQTYFLAG_INT"].Value = "缺药";
                        m_dgvRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;

                    }
                    m_dgvRow.Cells["MinPrice"].Value = row["MinPrice"].ToString();
                    m_dgvRow.Cells["MedicareTypeName"].Value = row["MedicareTypeName"].ToString();
                    m_dgvRow.Cells["orderdicid_chr"].Value = row["orderdicid_chr"].ToString();
                    m_dgvRow.Cells["MEDICINEPREPTYPENAME_VCHR"].Value = row["MEDICINEPREPTYPENAME_VCHR"].ToString();

                    if (row["IFSTOP_INT"].ToString().Trim().Equals("1"))//1停用，0-正常
                    {
                        m_dgvRow.Cells["IFSTOP_INT"].Value = "停";
                        m_dgvRow.DefaultCellStyle.ForeColor = SystemColors.Control;
                    }
                    else
                    {
                        m_dgvRow.Cells["IFSTOP_INT"].Value = "";
                    }

                    m_dgvRow.Cells["expenselimit_mny"].Value = row["expenselimit_mny"].ToString();
                    //
                    string m_strPrecent_dec = "";
                    clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                    m_objService.m_lngGetChargeItemPrecent(row["itemid_chr"].ToString(), strPayType, out m_strPrecent_dec);
                    m_dgvRow.Cells["precent_dec"].Value = m_strPrecent_dec + "%";

                    /*
                    ItemName  收费项
                    IsChiefItem 主
                    QTY_INT  数量
                    DOSAGE_DEC 剂量
                    DOSAGEUNIT_CHR 剂量单位
                    ITEMIPUNIT_CHR 住院单位
                    ITEMSPEC_VCHR  规格
                    MinPrice       单价
                    IPNOQTYFLAG_INT  药库
                    orderdicid_chr
                     */

                    m_intChargeSum += QTY_INT * MinPrice;

                }
                this.m_lblChargeSum.Text = m_intChargeSum.ToString("0.00");
            }
        }

        public void ClearTheBlank()
        {
            for (int i = 0; i < m_dtvOrderdicCharge.RowCount; i++)
            {
                for (int j = 0; j < m_dtvOrderdicCharge.ColumnCount; j++)
                {
                    if (m_dtvOrderdicCharge[j, i].Value != null)
                        m_dtvOrderdicCharge[j, i].Value = m_dtvOrderdicCharge[j, i].Value.ToString().Trim();
                }
            }
        }

        private void m_dtvOrderdicCharge_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void btFind_Click(object sender, EventArgs e)
        {
            string strFindCode = this.m_txtFind.Text.Trim();
            //查询类型
            int m_intClass = seachClass.SelectedIndex;
            clsBIHOrderDic[] arrDic = null;
            ((clsCtl_ChargeList)this.objController).m_lngGetOrderDicChargeByCode(strFindCode, m_intClass, m_strORDERCATEID_CHR, m_blLessMedControl, this.m_strMedDeptId, out arrDic, out m_dsDicChargeSet);
            arrItem = (ListViewItem[])getTheChargeItem(arrDic).ToArray(typeof(ListViewItem));
            LoadTheData();


        }

        private ArrayList getTheChargeItem(clsBIHOrderDic[] arrDic)
        {
            ArrayList m_arlItems = new ArrayList();
            if ((arrDic != null) && (arrDic.Length > 0))
            {
                for (int i = 0; i < arrDic.Length; i++)
                {
                    //string strDicCode = arrDic[i].m_strUserCode;
                    //switch (m_intClass)
                    //{
                    //    case -1:
                    //        strDicCode = arrDic[i].m_strPYCode;
                    //        break;
                    //    case 0:
                    //        strDicCode = arrDic[i].m_strPYCode;
                    //        break;
                    //    case 1:
                    //        strDicCode = arrDic[i].m_strWBCode;
                    //        break;
                    //    case 2:
                    //        strDicCode = arrDic[i].m_strName;
                    //        break;
                    //    case 3:
                    //        strDicCode = arrDic[i].m_strUserCode;
                    //        break;
                    //}
                    ////用户编码
                    //ListViewItem objItem = new ListViewItem((i + 1).ToString());
                    ////objItem.SubItems.Add(arrDic[i].m_strUserCode);
                    //objItem.SubItems.Add(strDicCode);
                    ////项目名称(商用名）
                    //objItem.SubItems.Add(arrDic[i].m_strName);
                    ////项目名称(药品常用名称)
                    //objItem.SubItems.Add(arrDic[i].m_strITEMCOMMNAME_VCHR);
                    ////项目规格
                    //objItem.SubItems.Add(arrDic[i].m_strSpec);
                    ////包装
                    ////objItem.SubItems.Add(arrDic[i].m_StrPackage);
                    ////住院单价
                    //objItem.SubItems.Add(arrDic[i].m_dmlPrice.ToString("0.0000"));
                    ////单位
                    //objItem.SubItems.Add(arrDic[i].m_strDosageUnit);
                    ////药库提示
                    //if (arrDic[i].m_intITEMSRCTYPE_INT == 1 && arrDic[i].m_intIPNOQTYFLAG_INT == 1)
                    //{
                    //    objItem.SubItems.Add("缺药");
                    //    objItem.ForeColor = Color.Red;
                    //}
                    //else
                    //{
                    //    objItem.SubItems.Add("");
                    //}

                    //objItem.Tag = arrDic[i];
                    //m_arlItems.Add(objItem);

                    string strDicCode = arrDic[i].m_strUserCode;
                    switch (m_intClass)
                    {
                        case -1:
                            strDicCode = arrDic[i].m_strPYCode;
                            break;
                        case 0:
                            strDicCode = arrDic[i].m_strPYCode;
                            break;
                        case 1:
                            strDicCode = arrDic[i].m_strWBCode;
                            break;
                        case 2:
                            strDicCode = arrDic[i].m_strName;
                            break;
                        case 3:
                            strDicCode = arrDic[i].m_strUserCode;
                            break;
                    }
                    //用户编码
                    ListViewItem objItem = new ListViewItem((i + 1).ToString());
                    objItem.SubItems.Add(arrDic[i].m_strUserCode);
                    //objItem.SubItems.Add(arrDic[i].m_strUserCode);
                    objItem.SubItems.Add(strDicCode);
                    //项目名称(商用名）
                    objItem.SubItems.Add(arrDic[i].m_strName);
                    //项目名称(药品常用名称)
                    objItem.SubItems.Add(arrDic[i].m_strITEMCOMMNAME_VCHR);
                    //项目规格
                    objItem.SubItems.Add(arrDic[i].m_strSpec);
                    //包装
                    //objItem.SubItems.Add(arrDic[i].m_StrPackage);
                    //住院单价
                    //objItem.SubItems.Add(arrDic[i].m_dmlPrice.ToString("0.0000"));
                    //单位
                    //objItem.SubItems.Add(arrDic[i].m_strDosageUnit);
                    //药库提示
                    if (arrDic[i].m_intITEMSRCTYPE_INT == 1 && arrDic[i].m_intIPNOQTYFLAG_INT == 1)
                    {
                        objItem.SubItems.Add("缺药");
                        objItem.ForeColor = Color.Red;
                    }
                    else
                    {
                        //医保项目->绿色
                        if (arrDic[i].m_strYBTypeID.Trim() != "")
                        {
                            objItem.SubItems.Add("医保类");
                            objItem.ForeColor = Color.Green;
                        }
                        else
                        {
                            objItem.SubItems.Add("");
                        }
                    }

                    objItem.Tag = arrDic[i];
                    m_arlItems.Add(objItem);
                }
            }
            return m_arlItems;
        }

        private void seachClass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_txtFind.Focus();
            }
        }

        private void m_txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btFind_Click(null, null);
            }
        }

        private void buttonXP1_Click(object sender, EventArgs e)
        {
            if (m_lvwList.SelectedItems.Count <= 0 && this.m_plTextOrder.Visible == false)
            {

                return;
            }
            else
            {
                if (m_lvwList.SelectedItems.Count > 0)
                {
                    if (((clsBIHOrderDic)m_lvwList.SelectedItems[0].Tag).m_strDesc.Trim().Equals("*"))
                    {
                        return;
                    }
                    if (m_blDeableMedControl == false)
                    {
                        if (((clsBIHOrderDic)m_lvwList.SelectedItems[0].Tag).m_intIPNOQTYFLAG_INT == 1)
                        {
                            MessageBox.Show("不能选择缺药的项!", "提示!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return;
                        }
                    }
                    //记录是否是药品
                    this.m_intITEMSRCTYPE_INT = ((clsBIHOrderDic)m_lvwList.SelectedItems[0].Tag).m_intITEMSRCTYPE_INT;

                    //库存量(求和后计算)
                    int intOrderdicChargeCount = m_dtvOrderdicCharge.RowCount;
                    for (int intI1 = 0; intI1 < intOrderdicChargeCount; intI1++)
                    {
                        this.m_dmlOpcurrentgross_num += Convert.ToSingle(m_dtvOrderdicCharge.Rows[intI1].Cells["QTY_INT"].Value.ToString());
                    }
                    if (m_blStopControl == false)
                    {
                        bool m_blCheck = false;
                        if (m_dsDicChargeSet != null && m_dsDicChargeSet.Tables.Count > 0)
                        {
                            DataView myDataView = m_dsDicChargeSet.Tables[0].DefaultView;
                            myDataView.RowFilter = "orderdicid_chr='" + ((clsBIHOrderDic)m_lvwList.SelectedItems[0].Tag).m_strOrderDicID + "'";
                            m_blCheck = CheckTheStopCharge(myDataView);

                        }
                        if (m_blCheck)
                        {
                            MessageBox.Show("不能选择已停用收费项目!", "提示!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                //更新到文字医嘱输入框
                if (this.m_plTextOrder.Visible == true)
                {
                    //if (this.txtInfo.Text.Trim().Equals(""))
                    //{
                    //    return;
                    //}
                    //m_lviSItem = new ListViewItem();
                    //clsBIHOrderDic orderDic = new clsBIHOrderDic();
                    //if (m_lvwList.SelectedItems.Count > 0)
                    //{
                    //    orderDic = (clsBIHOrderDic)m_lvwList.SelectedItems[0].Tag;
                    //}
                    //else
                    //{
                    //    orderDic.m_strOrderCateID = m_strORDERCATEID_CHR;
                    //}
                    //orderDic.m_strName = txtInfo.Text;
                    //m_lviSItem.Tag = orderDic;

                    //m_lviSItemArr = new ListViewItem[1];
                    //m_lviSItemArr[0] = m_lviSItem;
                    clsBIHOrderDic orderDic = new clsBIHOrderDic();
                    if (GetTheTextOrder(ref orderDic) == false)
                    {
                        return;
                    }
                    m_lviSItem = new ListViewItem();
                    m_lviSItem.Tag = orderDic;
                    m_lviSItemArr = new ListViewItem[1];
                    m_lviSItemArr[0] = m_lviSItem;
                }
                else
                {
                    m_lviSItemArr = new ListViewItem[m_lvwList.SelectedItems.Count];
                    for (int i = 0; i < m_lvwList.SelectedItems.Count; i++)
                    {
                        m_lviSItemArr[i] = m_lvwList.SelectedItems[i];
                    }
                }
                this.DialogResult = DialogResult.Yes;

            }
        }

        private void buttonXP2_Click(object sender, EventArgs e)
        {

            m_lviSItem = new ListViewItem();
            clsBIHOrderDic orderDic = new clsBIHOrderDic();
            if (GetTheTextOrder(ref orderDic) == false)
            {
                return;
            }
            //if (m_lvwList.SelectedItems.Count > 0)
            //{
            //    orderDic = (clsBIHOrderDic)m_lvwList.SelectedItems[0].Tag;
            //}
            //else
            //{
            //   orderDic.m_strOrderCateID=m_strORDERCATEID_CHR;
            //}

            m_lviSItem.Tag = orderDic;
            this.DialogResult = DialogResult.OK;


        }

        private bool GetTheTextOrder(ref clsBIHOrderDic orderDic)
        {

            if (txtInfo.Text.Trim().Equals(""))
            {
                MessageBox.Show("内容不能为空!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtInfo.Focus();
                return false;

            }
            if (txtInfo.Tag is clsBIHOrderDic)
            {
                orderDic = (clsBIHOrderDic)txtInfo.Tag;
            }
            else
            {
                if (m_strORDERCATEID_CHR.Trim().Equals(""))
                {
                    MessageBox.Show("请先选择文字医嘱类别!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                //clsBIHOrderService m_objService = com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBIHOrderService)) as clsBIHOrderService;
                clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                clsBIHOrderDic[] arrDic;
                m_objService.m_lngGetOrderDicChargeByCode("", m_intClass, m_strORDERCATEID_CHR, false, this.m_strMedDeptId, out arrDic, out m_dsDicChargeSet, this.isChildPrice);
                //m_objService.m_lngGetOrderDicChargeByCode("", m_intClass, m_strORDERCATEID_CHR, false, out arrDic, out m_dsDicChargeSet);
                if (arrDic != null && arrDic.Length > 0)
                {
                    orderDic = arrDic[0];
                }

            }

            orderDic.m_strName = txtInfo.Text;
            return true;
        }

        private void frmChargeList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:

                    this.DialogResult = DialogResult.No;
                    break;
                case Keys.F1:
                    btFind_Click(null, null);
                    break;
                case Keys.F2:
                    if (m_plTextOrder.Visible == true)
                    {
                        txtInfo.Focus();
                        txtInfo.SelectAll();
                    }
                    break;
                case Keys.F3:
                    if (m_cmdTextOrder.Visible == true)
                    {
                        buttonXP2_Click(null, null);
                    }
                    break;
                case Keys.F4:
                    buttonXP1_Click(null, null);
                    break;
            }
        }





    }
}