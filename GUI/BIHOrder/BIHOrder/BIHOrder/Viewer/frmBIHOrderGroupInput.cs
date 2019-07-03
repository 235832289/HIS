using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.BIHOrder.Control;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.CustomFromService;//申请单用到
using com.digitalwave.iCare.gui.HIS;	//申请单用到
using iCare.CustomForm;					//申请单用到
using iCareData;						//申请单用到
using com.digitalwave.GUI_Base;			//申请单用到
using iCare;
using com.digitalwave.iCare.gui.LIS;

namespace com.digitalwave.iCare.BIHOrder
{
    public partial class frmBIHOrderGroupInput : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        /// <summary>
        /// 组套列表
        /// </summary>
        public clsBIHOrderGroup[] arrGroup;
        /// <summary>
        /// 已选中的非同方组套列表项
        /// </summary>
        public Hashtable m_htBIHOrder = new Hashtable();
        /// <summary>
        /// 已选中的非同方组套列表项KEY
        /// </summary>
        public ArrayList m_arrBIHOrderKey = new ArrayList();
        /// <summary>
        /// 已选中的同方组套列表项
        /// </summary>
        public Hashtable m_htBIHOrderGroup = new Hashtable();
        /// <summary>
        /// 已选中的同方组套列表项KEY
        /// </summary>
        public ArrayList m_arrBIHOrderGroupKey = new ArrayList();
        /// <summary>
        /// 组套选择改变事件标志
        /// </summary>
        public bool m_blGpChange = false;
        /// <summary>
        /// 当前组套选中的项目总价
        /// </summary>
        public decimal m_dlCheckItem = 0;
        /// <summary>
        /// 当前员工
        /// </summary>
        //public string m_strDoctorID = "";
        /// <summary>
        /// 同方医嘱组套数组
        /// </summary>
        public ArrayList m_arrSameNo = new ArrayList();
        /// <summary>
        /// 保存由父窗体传来的基本信息如：病人ID，费用标志，是否皮试
        /// </summary>
        public clsBIHOrder baseBIHOrder = new clsBIHOrder();
        /// <summary>
        /// 医嘱主界面的datagridview控件
        /// </summary>
        public DataGridView m_dgvOrder = null;
        /// <summary>
        /// 医嘱类型列表
        /// </summary>
        public Hashtable m_htOrderCate = new Hashtable();
        /// <summary>
        /// 住院基本配置表VO
        /// </summary>
        public clsSPECORDERCATE m_objSpecateVo;
        /// <summary>
        /// 来源(0-医嘱调用,1-收费调用)
        /// </summary>
        public int m_intSourceType = 0;
        /// <summary>
        /// 来源=1-收费调用时返回的选中的诊疗项目数组
        /// </summary>
        public ArrayList m_arrOrderDic = new ArrayList();
        /// <summary>
        /// 来源=1-收费调用时返回的 数值
        /// </summary>
        public decimal m_decMount = 0;
        /// <summary>
        /// 停用项目是否可录入开关
        /// </summary>
        public bool m_blStopControl = true;
        /// <summary>
        /// 缺药的项目是否可以录入0-不可以false，1-可以true
        /// </summary>
        public bool m_blDeableMedControl = false;
        /// <summary>
        /// 返回的诊疗项目表(诊疗项目名称-1列，类型-2列)
        /// </summary>
        public DataTable m_dtOrderDic = new DataTable();
        public ArrayList m_strOrderCateList = new ArrayList();
        /// <summary>
        /// 医嘱调用界面返回的医嘱数组
        /// </summary>
        public ArrayList m_arrGroupOrder = null;
        /// <summary>
        /// 身份ID
        /// </summary>
        public string strPayType = string.Empty;

        internal bool IsChildPrice { get; set; }

        public ctlBIHOrderDetail m_ctlOrder = null;
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_OrderGroupInput();
            objController.Set_GUI_Apperance(this);
        }

        public frmBIHOrderGroupInput()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 组套医嘱
        /// </summary>
        /// <param name="m_strFindCode">查询内容</param>
        /// <param name="OrderCateList">过滤的类型数组</param>
        /// <param name="m_strEmpId">员工号ID</param>
        /// <param name="m_strInpatientAreaID">员工病区ID</param>
        /// <param name="m_intClass">查询类型(-1默认拼音,0 拼音,1 五笔,2 名称,3 用户编码,4 混合)</param>
        /// <param name="m_intType">来源(0-医嘱调用,1-收费调用)</param>
        public frmBIHOrderGroupInput(string m_strFindCode, ArrayList OrderCateList, string m_strEmpId, string m_strInpatientAreaID, int m_intClass, int m_intType)
        {
            InitializeComponent();
            m_strOrderCateList = OrderCateList;
            m_strEmpId = this.LoginInfo.m_strEmpID;
            m_strInpatientAreaID = this.LoginInfo.m_strInpatientAreaID;
            this.Cursor = Cursors.WaitCursor;
            //保存同方组套医嘱
            ((clsCtl_OrderGroupInput)this.objController).LoadTheGroup(m_strFindCode, m_strEmpId, m_strInpatientAreaID, m_intClass, out arrGroup);
            /*<-------------------------------------------------*/
            m_intSourceType = m_intType;
            this.Cursor = Cursors.Default;
            this.txtFind.Text = m_strFindCode;
            if (m_intClass > 3)
            {
                this.seachClass.SelectedIndex = 0;
            }
            else
            {
                this.seachClass.SelectedIndex = m_intClass;
            }
            ((clsCtl_OrderGroupInput)this.objController).LoadTheCate(ref m_htOrderCate);
        }

        /// <summary>
        /// 组套医嘱
        /// </summary>
        /// <param name="m_strFindCode">查询内容</param>
        /// <param name="m_strEmpId">员工号ID</param>
        /// <param name="m_strInpatientAreaID">员工病区ID</param>
        /// <param name="m_intClass">查询类型(-1默认拼音,0 拼音,1 五笔,2 名称,3 用户编码,4 混合)</param>
        /// <param name="m_intType">来源(0-医嘱调用,1-收费调用)</param>
        public frmBIHOrderGroupInput(string m_strFindCode, string m_strEmpId, string m_strInpatientAreaID, int m_intClass, int m_intType)
        {
            InitializeComponent();
            m_strEmpId = this.LoginInfo.m_strEmpID;
            m_strInpatientAreaID = this.LoginInfo.m_strInpatientAreaID;
            this.Cursor = Cursors.WaitCursor;
            //保存同方组套医嘱
            ((clsCtl_OrderGroupInput)this.objController).LoadTheGroup(m_strFindCode, m_strEmpId, m_strInpatientAreaID, m_intClass, out arrGroup);
            /*<-------------------------------------------------*/
            m_intSourceType = m_intType;
            this.Cursor = Cursors.Default;
            this.txtFind.Text = m_strFindCode;
            if (m_intClass > 3)
            {
                this.seachClass.SelectedIndex = 0;
            }
            else
            {
                this.seachClass.SelectedIndex = m_intClass;
            }
            ((clsCtl_OrderGroupInput)this.objController).LoadTheCate(ref m_htOrderCate);
        }

        /// <summary>
        /// 组套医嘱
        /// </summary>
        /// <param name="m_arrGroup"></param>
        /// <param name="m_BIHOrder"></param>
        /// <param name="m_OrderCate"></param>
        /// <param name="m_dgOrder"></param>
        /// <param name="m_SpecateVo"></param>
        /// <param name="strFindCode">查询内容</param>
        /// <param name="m_intClass">查询类型(-1默认拼音,0 拼音,1 五笔,2 名称,3 用户编码,4 混合)</param>
        /// <param name="m_intType">来源(0-医嘱调用,1-收费调用)</param>
        /// <param name="StopControl"></param>
        /// <param name="DeableMedControl"></param>
        public frmBIHOrderGroupInput(clsBIHOrderGroup[] m_arrGroup, clsBIHOrder m_BIHOrder, Hashtable m_OrderCate, DataGridView m_dgOrder, clsSPECORDERCATE m_SpecateVo, string strFindCode, int m_intClass, int m_intType, bool StopControl, bool DeableMedControl)
        {
            InitializeComponent();

            arrGroup = m_arrGroup;
            baseBIHOrder = m_BIHOrder;
            m_htOrderCate = m_OrderCate;
            m_dgvOrder = m_dgOrder;
            m_objSpecateVo = m_SpecateVo;
            this.txtFind.Text = strFindCode;
            this.seachClass.SelectedIndex = m_intClass;
            m_intSourceType = m_intType;
            m_blStopControl = StopControl;
            m_blDeableMedControl = DeableMedControl;
            this.TopMost = false;

        }

        /// <summary>
        /// 组套医嘱
        /// </summary>
        /// <param name="m_arrGroup"></param>
        /// <param name="m_BIHOrder"></param>
        /// <param name="m_OrderCate"></param>
        /// <param name="m_dgOrder"></param>
        /// <param name="m_SpecateVo"></param>
        /// <param name="strFindCode">查询内容</param>
        /// <param name="m_intClass">查询类型(-1默认拼音,0 拼音,1 五笔,2 名称,3 用户编码,4 混合)</param>
        /// <param name="m_intType">来源(0-医嘱调用,1-收费调用)</param>
        /// <param name="StopControl"></param>
        /// <param name="DeableMedControl"></param>
        public frmBIHOrderGroupInput(clsBIHOrderGroup[] m_arrGroup, clsBIHOrder m_BIHOrder, Hashtable m_OrderCate, DataGridView m_dgOrder, clsSPECORDERCATE m_SpecateVo, string strFindCode, int m_intClass, int m_intType, bool StopControl, bool DeableMedControl, ctlBIHOrderDetail p_ctlOrder, bool _isChildPrice)
        {
            InitializeComponent();

            arrGroup = m_arrGroup;
            baseBIHOrder = m_BIHOrder;
            m_htOrderCate = m_OrderCate;
            m_dgvOrder = m_dgOrder;
            m_objSpecateVo = m_SpecateVo;
            this.txtFind.Text = strFindCode;
            this.seachClass.SelectedIndex = m_intClass;
            m_intSourceType = m_intType;
            m_blStopControl = StopControl;
            m_blDeableMedControl = DeableMedControl;
            this.TopMost = false;
            this.m_ctlOrder = p_ctlOrder;
            this.IsChildPrice = _isChildPrice;
        }

        private void frmBIHOrderGroupInput_Load(object sender, EventArgs e)
        {
            //初始化界面
            iniTheView();
            ((clsCtl_OrderGroupInput)this.objController).bindGroupTree();
            //this.ra_selectAll.Checked = true;
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        /// <returns></returns>
        private void iniTheView()
        {
            if (m_intSourceType == 0)
            {
                this.m_txtMount.Text = "1";
                this.m_txtMount.Visible = false;
                this.m_lblMount.Visible = false;
                this.m_cmdAddNewTemp.Visible = true;
                this.m_cmdChangeTemp.Visible = true;
            }
            else
            {
                this.m_txtMount.Text = "1";
                this.m_txtMount.Visible = true;
                this.m_lblMount.Visible = true;
                this.m_cmdAddNewTemp.Visible = false;
                this.m_cmdChangeTemp.Visible = false;

                GetTheControl();
            }
        }

        internal void GetTheControl()
        {
            int m_intNeedConfirm = -1;
            //long lngRes = m_objManage.GetTheComfirmControl(out m_intNeedConfirm, out m_intExeConfirm);
            System.Collections.Generic.List<string> m_arrControl = new System.Collections.Generic.List<string>();
            //ArrayList m_arrControl = new ArrayList();
            m_arrControl.Add("1036");//m_blDeableMedControl 医嘱录入是否可以录入缺药的收费项目 0-否，1-是 1036
            m_arrControl.Add("1037");//m_blStopControl 医嘱录入是否可以录入已停用的收费项目 0-否,1-是 1037

            DataTable dtbResult = null;
            long lngRes = ((clsCtl_OrderGroupInput)this.objController).GetTheHisControl(m_arrControl, out  dtbResult);
            if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
            {
                for (int i = 0; i < dtbResult.Rows.Count; i++)
                {
                    switch (dtbResult.Rows[i]["setid_chr"].ToString().TrimEnd())
                    {
                        case "1036":
                            if (dtbResult.Rows[i]["setstatus_int"].ToString().Equals("0"))
                            {
                                m_blDeableMedControl = false;
                            }
                            else
                            {
                                m_blDeableMedControl = true;
                            }
                            break;
                        case "1037":
                            if (dtbResult.Rows[i]["setstatus_int"].ToString().Equals("0"))
                            {
                                m_blStopControl = false;
                            }
                            else
                            {
                                m_blStopControl = true;
                            }
                            break;
                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            m_cmdChangeTemp.Enabled = false;
            this.Text = "组套模板";
            if (e.Node.Tag is clsBIHOrderGroup)
            {
                clsBIHOrderGroup group1 = (clsBIHOrderGroup)e.Node.Tag;
                if (group1.m_strCreatorID.Trim().Equals(this.LoginInfo.m_strEmpID))
                {
                    m_cmdChangeTemp.Enabled = true;
                }
                m_blGpChange = true;
                m_dlCheckItem = 0;
                // 根据组套ID查询相关的诊疗项
                ((clsCtl_OrderGroupInput)this.objController).bindGroupListView(((clsBIHOrderGroup)e.Node.Tag).m_strGroupID.Trim());
                /*<------------------------------------------------*/
                //是否组套
                if (((clsBIHOrderGroup)e.Node.Tag).m_intISSAMERECIPENO_INT > 0)
                {
                    this.m_chkRECIPENO_SAME.Checked = true;
                }
                else
                {
                    this.m_chkRECIPENO_SAME.Checked = false;
                }
                /*<-------------------------------------------------*/
                //txtRemark.Text = ((clsBIHOrderGroup)e.Node.Tag).m_strDes.Trim();
                m_blGpChange = false;
                //ra_selectAll.Checked = false;
                //ra_selectAll.Checked = true;
                //ra_selectBack.Checked = false;
                this.Text = "组套模板" + " " + group1.m_strName + "  " + group1.m_strUSERCODE_VCHR + "  " + group1.m_strPYCode + "  " + group1.m_strWBCode + " " + "停用或缺药项目不能选中";
            }
            else
            {
                m_dtvGroupDetail.Rows.Clear();
                m_dtvChangeList.Rows.Clear();
            }
        }

        private void listView2_ItemChecked(object sender, ItemCheckedEventArgs e)
        {


            //if(e.Item.Tag is clsBIHOrder&&!m_blGpChange&&m_chkRECIPENO_SAME.Checked)
            //{
            //    if (e.Item.Checked)
            //    {
            //        for (int i = 0; i < this.listView2.Items.Count; i++)
            //        {
            //            listView2.Items[i].Checked = true;


            //        }
            //    }
            //    else
            //    {
            //        for (int i = 0; i < this.listView2.Items.Count; i++)
            //        {
            //            listView2.Items[i].Checked = false; 

            //        }
            //    }

            //}
            ///*<===========================================================*/
            //clsBIHOrder order = new clsBIHOrder();
            //m_dlCheckItem = 0;
            //for (int i = 0; i < this.listView2.CheckedItems.Count; i++)
            //{
            //    order = (clsBIHOrder)this.listView2.CheckedItems[i].Tag;
            //    m_dlCheckItem += order.m_dmlPrice * (order.m_dmlGet);
            //}
            //this.label3.Text = m_dlCheckItem.ToString("0.000");

        }

        private void selectAll_CheckedChanged(object sender, EventArgs e)
        {
            //if (ra_selectAll.Checked)
            //{
            //    for (int i = 0; i < listView2.Items.Count; i++)
            //    {
            //        listView2.Items[i].Checked = true;
            //    }
            //}
            if (ra_selectAll.Checked == true)
            {
                bool m_blCan = true;
                string m_strCheck = "1";
                for (int i = 0; i < this.m_dtvGroupDetail.RowCount; i++)
                {
                    m_strCheck = "1";
                    m_blCan = true;

                    clsBIHOrder order = (clsBIHOrder)this.m_dtvGroupDetail.Rows[i].Tag;
                    //if (this.m_dtvGroupDetail.Rows[i].Cells["dtv_Check"].Tag.ToString().Equals("0"))
                    //{
                    //    m_strCheck = "0";
                    //    m_blCan = false;
                    //}
                    //this.m_dtvGroupDetail.Rows[i].Cells["dtv_Check"].Value = m_strCheck;
                    //if (m_blCan == false)
                    //{
                    //    selectRowWithSon(order.m_intRecipenNo, m_strCheck, out  m_blCan);
                    //}
                    //同步选择父子医嘱
                    selectRowWithSon(order.m_intRecipenNo, m_strCheck, out m_blCan);

                    /*<===============================*/
                    if (m_blCan == false)
                    {
                        m_strCheck = "0";
                        //同步选择父子医嘱
                        selectRowWithSon(order.m_intRecipenNo, m_strCheck, out m_blCan);
                    }


                }
            }

            theCheckItemCout();
        }

        private void listView2_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            //MessageBox.Show("bad");
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void selectBack_CheckedChanged(object sender, EventArgs e)
        {
            //if (ra_selectBack.Checked)
            //{
            //    for (int i = 0; i < listView2.Items.Count; i++)
            //    {
            //        listView2.Items[i].Checked = !listView2.Items[i].Checked;
            //    }
            //}

        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (m_intSourceType == 0)
            {
                this.Cursor = Cursors.WaitCursor;

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
                //保存同方组套医嘱
                if (((clsCtl_OrderGroupInput)this.objController).SaveTheGroup() == true)
                {
                    for (int i = 0; i < this.m_arrGroupOrder.Count; i++)
                    {
                        clsBIHOrder order = (clsBIHOrder)this.m_arrGroupOrder[i];
                        if (str.Contains(strPayType))
                        {
                            string strRemark = string.Empty;
                            string strItemName = string.Empty;
                            bool blnRes = m_objDomain.m_blnShiying(order.m_strOrderDicID, out strRemark, out strItemName);
                            if (blnRes)
                            {
                                MessageBox.Show("该模板中项目【" + strItemName + "】限【" + strRemark + "】使用，判断本处方是否符合限制条件后。\n请在下拉框选择【符合】、【不符合】。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);

                            }
                        }
                        if (((frmBIHOrderInput)this.m_ctlOrder.ParentForm).m_objDomain.m_blChcekOpcurrentgross(ref order) == false)
                        {
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }
                    this.Cursor = Cursors.Default;
                    this.DialogResult = DialogResult.OK;
                    //this.Close();
                }
                this.Cursor = Cursors.Default;
            }
            else if (m_intSourceType == 1)
            {
                ((clsCtl_OrderGroupInput)this.objController).GetTheSelectOrderDic(ref m_arrOrderDic, ref m_dtOrderDic);

                m_decMount = clsConverter.ToDecimal(this.m_txtMount.Text.Trim());

                if (m_arrOrderDic.Count == 0)
                {
                    MessageBox.Show("请选择项目!", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (m_decMount == 0)
                {
                    MessageBox.Show("请输入数量且不能为0 ", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.m_txtMount.Focus();
                    this.m_txtMount.SelectAll();
                    return;
                }

                this.DialogResult = DialogResult.OK;
            }
        }

        private void btFind_Click(object sender, EventArgs e)
        {
            string strFindCode = txtFind.Text.Trim();

            int m_intClass = seachClass.SelectedIndex;
            clsBIHOrderGroup[] arrGroup;
            clsBIHOrderGroupService m_objService2 = new clsDcl_GetSvcObject().m_GetOrderGroupSvcObject();
            long ret1 = m_objService2.m_lngFindGroup(strFindCode, this.baseBIHOrder.m_strCreatorID, "", m_intClass, out arrGroup);
            if ((ret1 > 0) && (arrGroup != null))
            {
                this.arrGroup = arrGroup;
                ((clsCtl_OrderGroupInput)this.objController).bindGroupTree();
            }
        }

        #region 初始化界面控件及变量
        /// <summary>
        /// 初始化界面控件及变量
        /// </summary>
        public void iniControl()
        {
            this.treeView1.Nodes.Clear();
            //this.listView2.Items.Clear();
            this.m_dtvGroupDetail.Rows.Clear();
            this.m_htBIHOrder.Clear();
        }
        #endregion

        private void frmBIHOrderGroupInput_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                #region 快捷键
                case Keys.Escape:
                    btExit_Click(null, null);
                    break;
                case Keys.F1:
                    if (m_cmdAddNewTemp.Visible == true)
                    {
                        m_cmdAddNewTemp_Click(null, null);
                    }
                    break;
                case Keys.F2:
                    if (m_cmdChangeTemp.Visible == true)
                    {
                        m_cmdChangeTemp_Click(null, null);
                    }
                    break;
                case Keys.F3://
                    btOK_Click(null, null);
                    break;
                #endregion
            }

            // 组合快捷键
            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.F)    // 打印医嘱 [Ctrl + F] 
                {
                    btFind_Click(null, null);
                }
            }
        }

        private void m_dtvGroupDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                int m_intRecipenNo = -1;    // 方号
                string m_strCheck = "0";
                bool m_blCan = true;        // 是否可选标志(停用或缺药后的当前选项只读状态进行判断)
                if (this.m_dtvGroupDetail.Rows.Count > 0)
                {
                    clsBIHOrder bihorder = (clsBIHOrder)this.m_dtvGroupDetail.Rows[e.RowIndex].Tag;
                    m_intRecipenNo = bihorder.m_intRecipenNo;
                    if (!this.m_dtvGroupDetail.Rows[e.RowIndex].Cells["dtv_Check"].Value.Equals("1"))
                    {
                        this.m_dtvGroupDetail.Rows[e.RowIndex].Cells["dtv_Check"].Value = "1";
                        m_strCheck = "1";
                    }
                    else
                    {
                        this.m_dtvGroupDetail.Rows[e.RowIndex].Cells["dtv_Check"].Value = "0";
                        m_strCheck = "0";
                    }
                    // 同步选择父子医嘱
                    selectRowWithSon(m_intRecipenNo, m_strCheck, out m_blCan);

                    /*<===============================*/
                    if (m_blCan == false)
                    {
                        m_strCheck = "0";
                        // 同步选择父子医嘱
                        selectRowWithSon(m_intRecipenNo, m_strCheck, out m_blCan);
                    }
                    theCheckItemCout();
                }

            }
        }

        private void selectRowWithSon(int m_intRecipenNo, string m_strCheck, out bool m_blCan)
        {
            m_blCan = true;
            for (int i = 0; i < this.m_dtvGroupDetail.RowCount; i++)
            {
                clsBIHOrder m_objOrder = (clsBIHOrder)this.m_dtvGroupDetail.Rows[i].Tag;
                if (m_objOrder.m_intRecipenNo == m_intRecipenNo)
                {
                    this.m_dtvGroupDetail.Rows[i].Cells["dtv_Check"].Value = m_strCheck;
                    if (this.m_dtvGroupDetail.Rows[i].Cells["dtv_Check"].Tag.ToString().Equals("0"))
                    {
                        m_blCan = false;
                    }
                }
            }
        }

        /// <summary>
        /// 当前选中项目合计
        /// </summary>
        private void theCheckItemCout()
        {

            m_dlCheckItem = 0;
            for (int i = 0; i < this.m_dtvGroupDetail.RowCount; i++)
            {
                if (this.m_dtvGroupDetail.Rows[i].Cells["dtv_Check"].Value.ToString().Equals("0"))
                {
                    continue;
                }
                clsBIHOrder m_objOrder = (clsBIHOrder)this.m_dtvGroupDetail.Rows[i].Tag;
                m_dlCheckItem += m_objOrder.m_dmlPrice * (m_objOrder.m_dmlGet);
            }
            //this.label3.Text = m_dlCheckItem.ToString("0.000");
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btOK_Click(null, null);
            }
        }

        private void m_cmdAddNewTemp_Click(object sender, EventArgs e)
        {
            if (m_dgvOrder == null)
            {
                return;
            }
            //clsBIHOrder[] m_arrBihOrder = null;
            //if (m_dgvOrder.RowCount > 0)
            //{
            //    m_arrBihOrder = new clsBIHOrder[m_dgvOrder.RowCount];
            //    for (int i = 0; i < m_dgvOrder.RowCount; i++)
            //    {
            //        m_arrBihOrder[i] = (clsBIHOrder)m_dgvOrder.Rows[i].Tag;
            //    }

            //}
            //frmOrderTemplate_Group_Add m_frmGroupAdd = new frmOrderTemplate_Group_Add(m_arrBihOrder,m_htOrderCate,m_objSpecateVo);
            //m_frmGroupAdd.ShowDialog();
            ArrayList m_arrBihOrder = new ArrayList();

            if (this.m_dgvOrder.RowCount > 0)
            {
                for (int i = 0; i < m_dgvOrder.RowCount; i++)
                {
                    //医嘱类型为文字医嘱或为特殊医嘱的不允许生成
                    clsBIHOrder order = (clsBIHOrder)this.m_dgvOrder.Rows[i].Tag;
                    if (!CanCopyToGroup(order))
                    {
                        continue;
                    }
                    m_arrBihOrder.Add(order);
                }

            }
            if (m_arrBihOrder.Count > 0)
            {
                frmOrderTemplate_Group_Add m_frmGroupAdd = new frmOrderTemplate_Group_Add((clsBIHOrder[])(m_arrBihOrder.ToArray(typeof(clsBIHOrder))), m_htOrderCate, m_objSpecateVo);
                m_frmGroupAdd.ShowDialog();
            }
        }

        public bool CanCopyToGroup(clsBIHOrder order)
        {
            bool m_blCan = true;
            //医嘱类型为文字医嘱或为特殊医嘱的不允许生成
            if (order.m_intTYPE_INT != 0)
            {
                m_blCan = false;
            }
            /*<==============================*/
            return m_blCan;
        }

        private void ra_selectBack_CheckedChanged(object sender, EventArgs e)
        {
            if (ra_selectBack.Checked == true)
            {
                ArrayList m_hander = new ArrayList();
                for (int i = 0; i < this.m_dtvGroupDetail.RowCount; i++)
                {
                    string m_strCheck = "0";
                    bool m_blCan = true;
                    if (this.m_dtvGroupDetail.Rows[i].Cells["dtv_Check"].Value.ToString().Trim().Equals("1"))
                    {
                        clsBIHOrder order = (clsBIHOrder)this.m_dtvGroupDetail.Rows[i].Tag;
                        if (m_hander.Contains(order.m_intRecipenNo))
                        {
                            continue;
                        }
                        else
                        {
                            m_hander.Add(order.m_intRecipenNo);
                        }
                        m_strCheck = "0";
                        //同步选择父子医嘱
                        selectRowWithSon(order.m_intRecipenNo, m_strCheck, out m_blCan);

                        /*<===============================*/
                        if (m_blCan == false)
                        {
                            m_strCheck = "0";
                            //同步选择父子医嘱
                            selectRowWithSon(order.m_intRecipenNo, m_strCheck, out m_blCan);
                        }
                    }
                    else
                    {
                        clsBIHOrder order = (clsBIHOrder)this.m_dtvGroupDetail.Rows[i].Tag;
                        if (m_hander.Contains(order.m_intRecipenNo))
                        {
                            continue;
                        }
                        else
                        {
                            m_hander.Add(order.m_intRecipenNo);
                        }
                        m_strCheck = "1";
                        //同步选择父子医嘱
                        selectRowWithSon(order.m_intRecipenNo, m_strCheck, out m_blCan);

                        /*<===============================*/
                        if (m_blCan == false)
                        {
                            m_strCheck = "0";
                            //同步选择父子医嘱
                            selectRowWithSon(order.m_intRecipenNo, m_strCheck, out m_blCan);
                        }
                    }
                }
            }
        }

        private void m_dtvGroupDetail_CurrentCellChanged(object sender, EventArgs e)
        {
            ((clsCtl_OrderGroupInput)this.objController).m_lngBindChargeListByGroupDetail();
        }

        private void m_cmdChangeTemp_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag is clsBIHOrderGroup)
            {
                com.digitalwave.iCare.gui.HIS.frmGroupManager groupManager = new frmGroupManager(((clsBIHOrderGroup)treeView1.SelectedNode.Tag).m_strGroupID);
                if (groupManager.ShowDialog() == DialogResult.OK)
                {
                    frmBIHOrderGroupInput_Load(null, null);

                }
            }
        }

        private void m_mthOnlyNumber(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = false;

            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            { }
            else if ((e.KeyChar == 8) || (e.KeyChar == 13))
            { }
            else if ((e.KeyChar == '.'))
            { }
            else
            {
                e.Handled = true;
            }
        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btFind_Click(null, null);
            }
        }

    }
}