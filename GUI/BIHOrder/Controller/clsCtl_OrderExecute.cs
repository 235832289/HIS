using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Windows.Forms;
using com.digitalwave.iCare.gui.HIS;
using com.digitalwave.iCare.gui.LIS;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.ValueObject;
using iCare;
using iCareData;
//using com.digitalwave.GLS_WS.Send;

namespace com.digitalwave.iCare.BIHOrder
{
    /// <summary>
    /// 医嘱执行类
    /// </summary>
    class clsCtl_OrderExecute : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量声名
        internal com.digitalwave.iCare.BIHOrder.frmExecuteOrdersProgress objFrmExecuteOrdersProgress = null;
        clsDcl_ExecuteOrder m_objManage = null;
        clsDcl_InputOrder m_objInputOrder = null;
        DataTable m_dtPatients;
        DataTable m_dtChargeList;
        DataTable m_dtExecOrder;
        DataTable m_dtChargeMoney;
        DataTable m_dtPrepay;
        /// <summary>
        /// 审核状态选择项0-全部,1-未审核,2-已审核
        /// </summary>
        int m_intState = -1;
        /// <summary>
        /// 医嘱LOAD状态
        /// </summary>
        public bool EOstate = false;
        /// <summary>
        /// 病人LOAD状态
        /// </summary>
        public bool EPstate = false;
        /// <summary>
        /// 病人收费状态
        /// </summary>
        public bool ECstate = false;
        /// <summary>
        /// 医嘱类型列表
        /// </summary>
        public Hashtable m_htOrderCate = new Hashtable();
        /// <summary>
        /// 住院基本配置表VO
        /// </summary>
        public clsSPECORDERCATE m_objSpecateVo = null;
        /// <summary>
        /// 执行是否需要审核
        /// </summary>
        bool m_blExeConfirm = false;
        /// <summary>
        /// 当前选中执行医嘱的病人列表（登记号）
        /// </summary>
        public ArrayList m_arrRegisterID = new ArrayList();

        /// <summary>
        /// 执行单补执行字段(0-非补执行,1-补执行)
        /// </summary>
        public int m_intRepairEveVo = 0;
        /// <summary>
        /// 执行单补执行次数(0-非补执行,1-补执行)
        /// </summary>
        public int m_intRepairEveVoCount = 0;
        public Hashtable m_htReExecute = new Hashtable();
        /// <summary>
        /// 系统参数表(ICARE公用) 1008 住院确认记帐流程对应的身份ID 多种类型以身份隔开
        /// </summary>
        public string m_strPARMVALUE_VCHR = "";
        /// <summary>
        /// 系统参数表(ICARE公用) 0013 检验组合打折发票类型 多种类型以身份隔开
        /// </summary>
        public string m_strLisPARMVALUE_VCHR = "";
        /// <summary>
        /// 是否启用让利,1 可以,0 不可以 
        /// </summary>
        internal int intDiffPriceOn = 0;
        /// <summary>
        /// 药品让利类型,对应系统参数,9003
        /// </summary>
        public string m_strDiffMedicineType = string.Empty;
        public bool m_blFirstLoad = false;
        /// <summary>
        /// 药品库存量VO(执行前用于取出库存明细表中各批次药品理论库存，执行后用于更新相应批次的理论库存) 
        /// </summary>
        private clsDsStorageVO[] m_objDsStorageVOArr = null;

        /// <summary>
        /// 检查申请单的对应关系　TypeID　对应　类型
        /// </summary>
        private Dictionary<string, string> m_gdctApplyRlt = null;

        System.Drawing.Color FeedColor = System.Drawing.Color.Green; //需要皮试的项目颜色
        ArrayList m_arrBedIdList = null;//为快捷键上下按床号选中医嘱用
        public int m_intBedIndex = -1;//为快捷键上下按床号选中医嘱用 -1为不是快捷键方式，其它为快捷键方式
        public bool m_blBedIdKey = false;//为快捷键上下按床号选中医嘱用(false-不是快捷键方式,true-快捷键方式)
        public System.Collections.Generic.List<clsBIHCanExecOrder> m_glstExecOrderList = null; //在批量执行医嘱的时候，把所有能够执行的医嘱都储存在这个ArrayList里面，对象是clsBIHCanExecOrder
        //以上是新代码
        #endregion
        /// <summary>
        /// 委托
        /// </summary>
        delegate void filltheDatagridview();

        #region 构造函数
        public clsCtl_OrderExecute()
        {
            m_objManage = new clsDcl_ExecuteOrder();
            m_objInputOrder = new clsDcl_InputOrder();

        }
        #endregion
        // private frmOrderExecute objOrderExecute = new frmOrderExecute();
        #region 构造函数 2010/8/19
        //public clsCtl_OrderExecute(ref frmOrderExecute p_objOrderExecute)
        //{
        //    objOrderExecute = p_objOrderExecute;
        //}
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.BIHOrder.frmOrderExecute m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmOrderExecute)frmMDI_Child_Base_in;

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
                refreshTheData();
                this.m_objViewer.m_cboCode.Focus();
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

            m_intState = getState();

            #region LOAD 数据
            m_lngGetCanExecuteOrderByArea();//通过科室找出该科室所有可能需要执行的医嘱，储存在全局变量m_dtExecOrder

            System.Collections.Generic.List<string> m_glstRegisterid_chr;

            //速度查询 要开启 
            GetTheExecuteRegisterID(out m_glstRegisterid_chr);//删除重复的病人流水号，界面运算，不涉及数据库
            m_lngGetPatientDTByArea(m_glstRegisterid_chr);//根据上一个函数获得的没有重复病人流水号的病人号数组，获取病人相关信息，这些病人均有医嘱可能需要执行
            m_lngGetChargeByArea(m_glstRegisterid_chr);

            //补执行的执行医嘱单统计
            if (this.m_objViewer.m_chkReExcute.Checked == true)
            {
                m_lngGetReExecute();
            }
            #endregion

            bool m_blBed = false;
            if (this.m_objViewer.m_cboCode.SelectedIndex == 1)//默认选择显示全区，值为0；个人（某张病床），值为1
            {
                m_blBed = true;
            }
            else
            {
                m_blBed = false;
            }

            refreshTheDataByBed(m_blBed);
            ControlTheButton();
        }

        private void GetTheExecuteRegisterID(out System.Collections.Generic.List<string> m_glstRegisterid_chr)
        {
            m_glstRegisterid_chr = new System.Collections.Generic.List<string>();
            if (m_dtExecOrder != null && m_dtExecOrder.Rows.Count > 0)
            {
                string strREGISTERID_CHR = "";
                int intExecOrderRowsCount = m_dtExecOrder.Rows.Count;
                for (int i = 0; i < intExecOrderRowsCount; i++)
                {
                    strREGISTERID_CHR = m_dtExecOrder.Rows[i]["REGISTERID_CHR"].ToString().Trim();
                    if (!m_glstRegisterid_chr.Contains(strREGISTERID_CHR))
                    {
                        m_glstRegisterid_chr.Add(strREGISTERID_CHR);
                    }
                }
            }
        }

        /// <summary>
        /// 线程获取医嘱信息
        /// </summary>
        public void m_lngGetCanExecuteOrderByArea()
        {
            long lngRes = m_objManage.m_lngGetExecOrderDTByArea((string)m_objViewer.m_txtArea.Tag, out m_dtExecOrder);
            EOstate = true;
        }

        /// <summary>
        /// 线程获取医嘱信息
        /// </summary>
        public void m_lngGetCanExecuteOrderByBed()
        {
            long lngRes = m_objManage.m_lngGetExecOrderDTByAreaBed((string)m_objViewer.m_txtArea.Tag, ((clsBIHBed)m_objViewer.m_txtBedNo2.Tag).m_objPatient.m_strRegisterID, out m_dtExecOrder);
            EOstate = true;
            clsBIHCanExecOrder[] arrExecOrder;
            DataView myDataView = GetExecDataView(m_dtExecOrder, m_intState);
            filltheExecOrderTable(myDataView, out arrExecOrder);
            BindTheBihOrderList(arrExecOrder);
        }

        /// <summary>
        /// 线程获取病人信息
        /// </summary>
        public void m_lngGetPatientDTByArea()
        {
            long lngRes = m_objManage.m_lngGetPatientDTByArea((string)m_objViewer.m_txtArea.Tag, out  m_dtPatients);
            EPstate = true;

        }
        /// <summary>
        /// 线程获取病人信息，根据上一个函数获得的没有重复病人流水号的病人号数组，获取病人相关信息，这些病人均有医嘱可能需要执行
        /// </summary>
        public void m_lngGetPatientDTByArea(System.Collections.Generic.List<string> m_glstRegisterid_chr)
        {
            long lngRes = m_objManage.m_lngGetPatientDTByArea(m_glstRegisterid_chr, out  m_dtPatients);
            EPstate = true;

        }



        /// <summary>
        /// 线程获取病人信息
        /// </summary>
        public void m_lngGetPatientDTByAreaBed()
        {
            long lngRes = m_objManage.m_lngGetPatientDTByAreaBed((string)m_objViewer.m_txtArea.Tag, ((clsBIHBed)m_objViewer.m_txtBedNo2.Tag).m_objPatient.m_strRegisterID, out  m_dtPatients);
            EPstate = true;

        }

        /// <summary>
        /// 线程获取费用信息
        /// </summary>
        public void m_lngGetChargeByArea()
        {
            long lngRes = m_objManage.m_lngGetChargeByArea((string)m_objViewer.m_txtArea.Tag, out  m_dtChargeList, out  m_dtChargeMoney, out  m_dtPrepay);
            ECstate = true;

        }

        /// <summary>
        /// 线程获取费用信息
        /// </summary> 
        public void m_lngGetChargeByArea(System.Collections.Generic.List<string> m_glstRegisterid_chr)
        {
            long lngRes = m_objManage.m_lngGetChargeByArea((string)m_objViewer.m_txtArea.Tag, m_glstRegisterid_chr, out  m_dtChargeList, out  m_dtChargeMoney, out  m_dtPrepay);
            ECstate = true;

        }

        /// <summary>
        /// 线程获取费用信息
        /// </summary>
        public void m_lngGetChargeByAreaBed()
        {
            long lngRes = m_objManage.m_lngGetChargeByAreaBed((string)m_objViewer.m_txtArea.Tag, ((clsBIHBed)m_objViewer.m_txtBedNo2.Tag).m_objPatient.m_strRegisterID, out  m_dtChargeList, out  m_dtChargeMoney);
            ECstate = true;

        }
        /// <summary>
        /// 检查线程状态 判断当前病人表,医嘱表,费用表是否已LOAD成功
        /// </summary>
        public void TestTheTableLoadState()
        {

            while (!ECstate || !EPstate || !EOstate)
            {
            }
            ECstate = false;
            EPstate = false;
            EOstate = false;
            filltheDatagridview mygate = new filltheDatagridview(OrderListSelect);
            this.m_objViewer.Invoke(mygate);
        }

        private DataView GetExecDataView(DataTable m_dtExecOrder, int m_intState)
        {
            DataView myDataView = new DataView(m_dtExecOrder);
            switch (m_intState)
            {
                case 0:
                    myDataView = m_dtExecOrder.DefaultView;
                    break;
                //case 1:
                //    myDataView.RowFilter = " execCount=0 ";
                //    break;
                //case 2:
                //    myDataView.RowFilter = " execCount>0";
                //    break;
            }
            return myDataView;
        }

        /// <summary>
        /// 界面导入当前病区及床位 相应的数据
        /// </summary>
        internal void LoadTheDate2()
        {
            if (m_objViewer.m_txtArea.Tag == null || ((string)m_objViewer.m_txtArea.Tag).Trim().Equals(""))
            {
                MessageBox.Show("病区必须选！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtArea.Focus();
                return;
            }
            if (m_objViewer.m_txtBedNo2.Tag == null || ((clsBIHBed)m_objViewer.m_txtBedNo2.Tag).m_strBedID.Trim().Equals(""))
            {
                MessageBox.Show("床位必须选！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtBedNo2.Focus();
                return;
            }
            this.m_objViewer.m_dtvChangeList.Rows.Clear();
            clsBIHCanExecOrder[] arrExecOrder;
            m_intState = getState();
            #region 后台工作线程

            //this.m_objViewer.backgroundWorker1.RunWorkerAsync();
            #endregion
            #region LOAD 数据
            DoWork();
            m_lngGetCanExecuteOrderByBed();
            #endregion
            ControlTheButton();
            int cout = GetWaitCfPersonCout();
            this.m_objViewer.m_lblNewOrderCount.Text = "共有 " + cout.ToString() + " 病人有医嘱需要执行";
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

        #region 床位号事件
        internal void m_txtBedNo2FindItem(string strFindCode, ListView lvwList)
        {


            this.m_objViewer.m_txtBedNo2.Tag = null;
            //clsBIHOrderService m_objService = new clsBIHOrderService();
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
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
            //long ret = m_objService.m_lngGetBihBedByArea(strAreaID, strBedNo, out arrBed);
            ArrayList m_arrBedList = GetTheBed(strFindCode);

            if (m_arrBedList.Count > 0)
            {
                arrBed = (clsBIHBed[])m_arrBedList.ToArray(typeof(clsBIHBed));
            }
            if (arrBed != null)
            {
                if (arrBed.Length == 0)
                {
                    MessageBox.Show("当前科室没有床位，请重新选病区", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    //    upName=arrBed[i].m_objPatient.m_strAreaName;
                    //}

                    //ListViewItem objItem = new ListViewItem(upName);

                    //objItem.SubItems.Add(arrBed[i].m_strBedName);
                    ListViewItem objItem = new ListViewItem(arrBed[i].m_strBedName);
                    objItem.SubItems.Add(arrBed[i].m_objPatient.m_strPatientName);
                    objItem.SubItems.Add(arrBed[i].m_objPatient.m_strSex);
                    /*<----------------------*/
                    //objItem.Tag = arrBed[i].m_strBedID;
                    objItem.Tag = arrBed[i];
                    lvwList.Items.Add(objItem);

                }

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
                    m_objBed.m_strAreaID = order.m_strCURAREAID_CHR;
                    m_objBed.m_strBedID = order.m_strBedID;
                    //m_objBed.m_strBedName = order.m_strCURBEDName;
                    m_objBed.m_strBedName = order.m_strBedName;
                    m_objBed.m_objPatient = new clsBIHPatientInfo();
                    m_objBed.m_objPatient.m_strPatientName = order.m_strPatientName;
                    m_objBed.m_objPatient.m_strAreaName = order.m_strCURAREAName;
                    m_objBed.m_objPatient.m_strSex = order.m_strPatientSex;
                    m_arrBedList.Add(m_objBed);

                }
            }
            return m_arrBedList;
        }

        internal void m_txtBedNo2InitListView(ListView lvwList)
        {
            //lvwList.Columns.Add("病  区", 100, HorizontalAlignment.Left);
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
                this.m_objViewer.Cursor = Cursors.WaitCursor;
                refreshTheDataByBed(true);
                this.m_objViewer.Cursor = Cursors.Default;
            }
        }

        internal void refreshTheDataByBed(bool m_blBed)
        {
            if (this.m_objViewer.m_cboCode.SelectedIndex == 1 && m_blBed == true)//显示单个病人的医嘱
            {
                if (this.m_objViewer.m_txtBedNo2.Tag is clsBIHBed)
                {
                    DataView myDataView = GetExecDataView(m_dtExecOrder, m_intState);
                    DataTable m_dtData = myDataView.ToTable();
                    myDataView = new DataView(m_dtData);
                    myDataView.RowFilter = "bedid_chr='" + ((clsBIHBed)this.m_objViewer.m_txtBedNo2.Tag).m_strBedID + "'";
                    // myDataView.Sort = "FLAG_INT";
                    myDataView.Sort = "code_chr,recipeno_int,orderid_chr asc";
                    clsBIHCanExecOrder[] arrExecOrder;
                    filltheExecOrderTable(myDataView, out arrExecOrder);
                    BindTheBihOrderList(arrExecOrder);
                }
            }
            else if (m_blBed == false)//显示全区病人的医嘱
            {
                DataView myDataView = GetExecDataView(m_dtExecOrder, m_intState);//m_dtExecOrder记录该病区可能需要执行的全部医嘱
                myDataView.Sort = "code_chr,recipeno_int,orderid_chr asc";
                clsBIHCanExecOrder[] arrExecOrder;
                filltheExecOrderTable(myDataView, out arrExecOrder);//把该病区需要执行的医嘱，专储到数组arrExecOrder
                BindTheBihOrderList(arrExecOrder);
            }

            if (this.m_objViewer.m_blAutoStopAlert)
            {
                GetTheStopOrder();
            }
        }

        internal void GetTheStopOrder()
        {

            //检查医嘱是否停用
            ArrayList m_arrOrderIDs = new ArrayList();
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
            {
                clsBIHCanExecOrder order = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag;
                if (!m_arrOrderIDs.Contains(order.m_strOrderID))
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
                        if (!this.m_objViewer.m_blStopControl)
                        {
                            m_blStop = true;
                        }
                    }

                    if (!this.m_objViewer.m_blDeableMedControl)
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

        #endregion

        #region 当前医嘱执行记录选择事件处理
        /// <summary>
        /// 当前医嘱执行记录选择事件处理
        /// </summary>
        internal void OrderListSelect()
        {
            if (this.m_objViewer.blnFormLoad == false)
            {
                if (this.m_objViewer.m_dtvOrderList.CurrentCell != null && this.m_objViewer.m_dtvOrderList.RowCount > 0)
                {
                    clsBIHCanExecOrder order = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[this.m_objViewer.m_dtvOrderList.CurrentCell.RowIndex].Tag;
                    //******testing**********************
                    //if (order != null)
                    //{
                    //    string strRegisterID = order.m_strRegisterID;
                    //    System.Collections.ArrayList arrRegisterID = new ArrayList();
                    //    arrRegisterID.Add(strRegisterID);
                    //    m_lngGetChargeByArea(arrRegisterID);
                    //}

                    //************************************
                    if (order != null)
                    {
                        if (m_dtPatients != null && m_dtPatients.Rows.Count > 0)
                        {
                            fillthePatient(order);
                            filltheChargeList(order);
                            decimal m_decSum = m_objInputOrder.GettheChargeSum(order, m_dtChargeList);
                            this.m_objViewer.m_txtChargeSum.Text = "费用总计：" + m_decSum.ToString();
                            m_decSum = m_objInputOrder.GetTheSameChargeSum(order, m_dtChargeList);
                            this.m_objViewer.m_txtSameCharge.Text = "同方费用总计：" + m_decSum.ToString();

                        }
                        ControlTheButton();
                        TheSameNoRowSelect(order);
                    }
                }
                else
                {
                    clsBIHPatientInfo m_objPatient = new clsBIHPatientInfo();
                    BindTheObjPatinet(m_objPatient);
                    this.m_objViewer.m_txtChargeSum.Text = "费用总计：";
                    this.m_objViewer.m_txtSameCharge.Text = "同方费用总计：";
                    //this.m_objViewer.m_lblNewOrderCount.Text = "共有 病人有医嘱需要执行";
                }
            }
        }




        #endregion

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

        #region 审核及撤销按钮控制
        /// <summary>
        /// 审核及撤销按钮控制
        /// </summary>
        private void ControlTheButton()
        {
            bool m_blState = false;
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
                        if (CanExecOrder((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag) == false)
                        {
                            m_blState = false;
                            break;
                        }
                        else
                        {
                            m_blState = true;

                        }
                    }
                }

            }
            //this.m_objViewer.m_cmdToCommit.Enabled = m_blState;

        }
        #endregion

        #region 当前医嘱记录改变时病人改变事件
        /// <summary>
        /// 当前医嘱记录改变时病人改变事件
        /// </summary>
        /// <param name="order"></param>
        private void fillthePatient(clsBIHCanExecOrder order)
        {
            if (m_dtPatients != null && m_dtPatients.Rows.Count > 0)
            {
                string m_strInHospitalNoOld = "";
                string m_strInHospitalNoNow = "";
                m_strInHospitalNoOld = this.m_objViewer.m_ctlPatient.m_txtRegisterid.Text.Trim();
                m_strInHospitalNoNow = order.m_strRegisterID.Trim();
                if (m_strInHospitalNoOld.Equals(m_strInHospitalNoNow))
                {
                    return;
                }

                DataView myDataView = new DataView(m_dtPatients);
                myDataView.RowFilter = "registerid_chr='" + order.m_strRegisterID + "'";
                if (myDataView.Count <= 0)
                {
                    return;
                }
                clsBIHPatientInfo m_objPatient;
                m_mthGetPatientInfoFromDateTable(myDataView, out m_objPatient);
                this.m_objViewer.m_ctlPatient.m_objPatient = m_objPatient;
                this.m_objViewer.m_ctlPatient.m_mthShowPatient();

                //BindTheObjPatinet(m_objPatient);


            }
        }

        /// <summary>
        /// 梆定病人界面信息
        /// </summary>
        /// <param name="m_objPatient"></param>
        private void BindTheObjPatinet(clsBIHPatientInfo m_objPatient)
        {
            this.m_objViewer.m_ctlPatient.m_txtRegisterid.Text = m_objPatient.m_strRegisterID;
            this.m_objViewer.m_ctlPatient.m_txtInHospitalNo.Text = m_objPatient.m_strInHospitalNo;
            this.m_objViewer.m_ctlPatient.m_txtName.Text = m_objPatient.m_strPatientName;
            this.m_objViewer.m_ctlPatient.m_txtSex.Text = m_objPatient.m_strSex;
            this.m_objViewer.m_ctlPatient.m_txtPayType.Text = m_objPatient.m_strPayTypeName;
            if (m_objPatient.m_dtInHospital != DateTime.MinValue)
            {
                this.m_objViewer.m_ctlPatient.m_txtInHospitalDate.Text = m_objPatient.m_dtInHospital.ToString("yyyy-MM-dd");
                TimeSpan ts = DateTime.Now.Date - m_objPatient.m_dtInHospital.Date;
                this.m_objViewer.m_ctlPatient.m_txtInDays.Text = clsConverter.ToString(ts.Days);

            }
            else
            {
                this.m_objViewer.m_ctlPatient.m_txtInHospitalDate.Text = "";
                this.m_objViewer.m_ctlPatient.m_txtInDays.Text = "";

            }
            this.m_objViewer.m_ctlPatient.m_txtState.Text = m_objPatient.m_strInpatientState;


            this.m_objViewer.m_ctlPatient.m_txtPreMoney.Text = m_objPatient.m_decPreMoney.ToString("0.00");
            this.m_objViewer.m_ctlPatient.m_txtUseMoney.Text = m_objPatient.m_decPreUseMoney.ToString("0.00");
            this.m_objViewer.m_ctlPatient.m_txtPrePayMoney.Text = m_objPatient.m_decPrePayMoney.ToString("0.00");
            this.m_objViewer.m_ctlPatient.m_txtClearMoney.Text = Convert.ToDecimal(m_objPatient.m_decClearMoney + m_objPatient.m_decVerticalMoney).ToString("0.00");
            this.m_objViewer.m_ctlPatient.m_txtREMARKNAME.Text = m_objPatient.m_strREMARKNAME_VCHR + m_objPatient.m_strDES_VCHR.Trim();
            /*<=======================================================*/
            this.m_objViewer.m_ctlPatient.m_txtLIMITRATE_MNY.Text = m_objPatient.m_dblLIMITRATE_MNY.ToString("0.00");
            this.m_objViewer.m_ctlPatient.m_txtDiagnose.Text = m_objPatient.m_strDiagnose;

            //#region	诊断提示	glzhang	2005.10.24
            //string strDiagnose = "\n   门诊诊断：" + m_objPatient.m_strMzdiagnose_vchr + "   \n";
            //strDiagnose += "\n   入院诊断（ICD10）：" + m_objPatient.m_strDiagnose + "   \n";
            //if (m_objPatient.m_strDiagnose_vchr.Length > 0)
            //{
            //    strDiagnose += "\n   入院诊断（医保）：" + m_objPatient.m_strDiagnose_vchr + "   \n";
            //}
            //else
            //{
            //    strDiagnose += "\n   入院诊断（医保）：－   \n";
            //}
            //toolTipDiagnose.SetToolTip(m_txtDiagnose, strDiagnose);
            //#endregion

            //在这里赋值是否医保病人
            try
            {
                this.m_objViewer.m_ctlPatient.m_chkIsMedicareMan.Checked = new com.digitalwave.iCare.middletier.HIS.clsBIH_INS_Compute().m_IsInsPatient(m_objPatient.m_strPayTypeID.Trim());
            }
            catch
            {

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
            m_objViewer.m_dtvChangeList.Rows.Clear();
            int k = 0;
            if (arrExecOrder != null)
            {
                //上一个记录的病人流水号
                string m_strPreRegister = "";
                decimal m_dmlOneUse = 0;//补一次的领量
                //加上补执行次数
                string m_strRecute = "";
                bool m_blCheck = false;//长,临,带, 
                int m_intState = 0;//0-全部医嘱，1-新医嘱，2-旧医嘱
                m_intState = this.m_objViewer.m_cboState.SelectedIndex;
                for (int i = 0; i < arrExecOrder.Length; i++)
                {
                    m_strRecute = "";
                    //判断当前医嘱是否可执行
                    if (this.m_objViewer.m_rdoNOT.Checked)//没有执行的医嘱
                    {
                        if (CanExecOrder(arrExecOrder[i]) == false)
                        {
                            continue;
                        }
                    }
                    else if (this.m_objViewer.m_rdoAll.Checked)
                    {
                        if (CanListOrder(arrExecOrder[i]) == false)
                        {
                            continue;
                        }
                    }
                    m_blCheck = false;
                    if (this.m_objViewer.m_chkLong.Checked == true)//如果选择执行长嘱，而这条医嘱正好是长嘱，可以执行
                    {
                        if (arrExecOrder[i].m_intExecuteType == 1)
                        {
                            m_blCheck = true;
                        }
                    }
                    if (this.m_objViewer.m_chkShort.Checked == true)////如果选择执行临嘱，而这条医嘱正好是临嘱，可以执行
                    {
                        if (arrExecOrder[i].m_intExecuteType == 2)
                        {
                            m_blCheck = true;
                        }
                    }
                    if (this.m_objViewer.m_chkOut.Checked == true)//如果选择执行出院带药，而这条医嘱正好是出院带药，可以执行
                    {
                        if (arrExecOrder[i].m_intExecuteType == 3)
                        {
                            m_blCheck = true;
                        }
                    }
                    if (m_blCheck == false)
                    {
                        continue;
                    }
                    switch (m_intState)//关于给m_intState赋值的代码已经费掉，所以m_intState总是为0
                    {
                        case 0:
                            m_blCheck = true;
                            break;
                        case 1:
                            if (arrExecOrder[i].m_intStatus != 5)
                            {
                                continue;
                            }
                            break;
                        case 2:
                            if (arrExecOrder[i].m_intStatus == 5)
                            {
                                continue;
                            }
                            break;
                    }
                    if (arrExecOrder[i].m_intRepair > 0 && arrExecOrder[i].m_intRepairCount > 0)
                    {
                        m_strRecute = " 补漏执行" + arrExecOrder[i].m_intRepairCount + "次";
                    }
                    /*<=========================*/

                    // 序号（含CheckBox）dtv_NO\床号dtv_bedcode\姓名m_dtvLastName\方号dtv_RecipeNo\医嘱（医嘱方式）dtv_ExecuteType\类别viewname_vchr
                    //\项目名称dtv_Name\剂量dtv_Dosage\用法dtv_UseType\频率dtv_Freq\数量dtv_Get\嘱托dtv_ENTRUST\主管医生DOCTOR_VCHR\提交时间m_dtvPOSTDATE_DAT\审核人m_dtvCONFIRMER_VCHR\审核时间 m_dtvCONFIRM_DAT
                    m_objViewer.m_dtvOrderList.Rows.Add();
                    k = m_objViewer.m_dtvOrderList.RowCount - 1;
                    DataGridViewRow row1 = m_objViewer.m_dtvOrderList.Rows[m_objViewer.m_dtvOrderList.RowCount - 1];
                    row1.Cells["dtv_NO"].Value = Convert.ToString((k + 1));
                    if (m_objViewer.m_chkSelectAll.Checked == true)
                    {
                        row1.Cells["m_dtvselectCheck"].Value = "1";//执行医嘱时候需要看看这个数值
                    }
                    else
                    {
                        row1.Cells["m_dtvselectCheck"].Value = "0";
                    }

                    if (m_strPreRegister.Trim().Equals(arrExecOrder[i].m_strRegisterID.Trim()))//当前病人和上一个病人是同一个人，不显示姓名等
                    {
                        row1.Cells["dtv_bedcode"].Value = "";
                        row1.Cells["m_dtvLastName"].Value = "";
                        row1.Cells["dtv_DEPTNAME_VCHR"].Value = "";
                    }
                    else
                    {
                        row1.Cells["dtv_bedcode"].Value = arrExecOrder[i].m_strCURBEDName;
                        row1.Cells["m_dtvLastName"].Value = arrExecOrder[i].m_strPatientName;
                        row1.Cells["dtv_DEPTNAME_VCHR"].Value = arrExecOrder[i].m_strCURAREAName;
                        m_strPreRegister = arrExecOrder[i].m_strRegisterID;
                    }
                    //医嘱类型
                    clsT_aid_bih_ordercate_VO p_objItem = null;
                    if (m_htOrderCate.Contains(arrExecOrder[i].m_strOrderDicCateID))
                    {
                        p_objItem = (clsT_aid_bih_ordercate_VO)m_htOrderCate[arrExecOrder[i].m_strOrderDicCateID];
                    }
                    string m_strCase = "";
                    if (arrExecOrder[i].m_intStatus == 5)//已审核，待执行的医嘱
                    {
                        m_strCase = "新";
                        row1.Cells["dtv_Case"].Style.ForeColor = System.Drawing.Color.Red;//需要皮试的项目颜色
                    }
                    else if (arrExecOrder[i].m_intStatus == 2)//已执行过的医嘱
                    {
                        m_strCase = "";
                    }
                    row1.Cells["dtv_Case"].Value = m_strCase;
                    if (arrExecOrder[i].m_intExecuteType == 1)//长嘱，需要显示方号
                    {
                        //方
                        row1.Cells["dtv_RecipeNo"].Value = " " + arrExecOrder[i].m_intRecipenNo2.ToString();
                    }
                    row1.Cells["dtv_ExecuteType"].Value = arrExecOrder[i].m_strExecuteTypeName;
                    row1.Cells["viewname_vchr"].Value = arrExecOrder[i].m_strOrderDicCateName;
                    row1.Cells["dtv_Name"].Value = arrExecOrder[i].m_strName;
                    row1.Cells["dtv_Dosage"].Value = arrExecOrder[i].m_dmlDosage.ToString() + arrExecOrder[i].m_strDosageUnit.ToString().Trim();
                    row1.Cells["dtv_UseType"].Value = arrExecOrder[i].m_strDosetypeName;
                    row1.Cells["dtv_Freq"].Value = arrExecOrder[i].m_strExecFreqName;
                    row1.Cells["dtv_Get"].Value = arrExecOrder[i].m_dmlGet.ToString() + arrExecOrder[i].m_strGetunit;
                    row1.Cells["dtv_ENTRUST"].Value = arrExecOrder[i].m_strEntrust;
                    row1.Cells["DOCTOR_VCHR"].Value = arrExecOrder[i].m_strDOCTOR_VCHR;
                    row1.Cells["m_dtvPOSTDATE_DAT"].Value = arrExecOrder[i].m_dtPostdate.ToString();
                    row1.Cells["m_dtvCONFIRMER_VCHR"].Value = arrExecOrder[i].m_strASSESSORFOREXEC_CHR;
                    row1.Cells["m_dtvCONFIRM_DAT"].Value = arrExecOrder[i].m_strASSESSORFOREXEC_DAT;
                    row1.Cells["CREATOR_CHR"].Value = arrExecOrder[i].m_strCreator;
                    if (arrExecOrder[i].PretestDays != 0) row1.Cells["pretestdays"].Value = arrExecOrder[i].PretestDays;

                    //“方法”列。用于显示检验医嘱的样本类型，和检查医嘱的部位信息
                    if (!arrExecOrder[i].m_strPARTID_VCHR.Trim().Equals(""))
                    {
                        row1.Cells["dtv_method"].Value = arrExecOrder[i].m_strPARTNAME_VCHR;
                    }
                    else if (!arrExecOrder[i].m_strSAMPLEID_VCHR.Trim().Equals(""))
                    {
                        row1.Cells["dtv_method"].Value = arrExecOrder[i].m_strSAMPLEName_VCHR;
                    }
                    else
                    {
                        row1.Cells["dtv_method"].Value = "";
                    }
                    //说明
                    row1.Cells["dtv_REMARK"].Value = arrExecOrder[i].m_strREMARK_VCHR.Trim();
                    #region 医嘱类型界面处理
                    p_objItem = null;
                    //上面的重复代码需要删除*************************
                    if (m_htOrderCate.Contains(arrExecOrder[i].m_strOrderDicCateID))
                    {
                        p_objItem = (clsT_aid_bih_ordercate_VO)m_htOrderCate[arrExecOrder[i].m_strOrderDicCateID];
                    }
                    //*******************************
                    if (p_objItem != null)
                    {
                        if (!arrExecOrder[i].m_strExecFreqID.Trim().Equals(m_objSpecateVo.m_strCONFREQID_CHR.Trim()))//连续性医嘱不显示剂量
                        {
                            if (p_objItem.m_intDOSAGEVIEWTYPE == 1)
                            {
                                //用量
                                if (arrExecOrder[i].m_dmlDosage > 0)
                                {
                                    row1.Cells["dtv_Dosage"].Value = arrExecOrder[i].m_dmlDosage.ToString() + "" + arrExecOrder[i].m_strDosageUnit;
                                }
                                else
                                {
                                    row1.Cells["dtv_Dosage"].Value = "";

                                }
                            }
                            else
                            {
                                row1.Cells["dtv_Dosage"].Value = "";
                            }
                        }
                        else
                        {
                            row1.Cells["dtv_Dosage"].Value = "";
                        }
                        if (!arrExecOrder[i].m_strExecFreqID.Trim().Equals(m_objSpecateVo.m_strCONFREQID_CHR.Trim()))//连续性医嘱不显示剂量
                        {
                            if (p_objItem.m_intUSAGEVIEWTYPE == 1)
                            {
                                //用法
                                row1.Cells["dtv_UseType"].Value = arrExecOrder[i].m_strDosetypeName;
                            }
                            else
                            {
                                //用法
                                row1.Cells["dtv_UseType"].Value = "";
                            }
                        }
                        else
                        {
                            //用法
                            row1.Cells["dtv_UseType"].Value = "";
                        }
                        if (p_objItem.m_intExecuFrenquenceType == 1)
                        {
                            //频率
                            row1.Cells["dtv_Freq"].Value = arrExecOrder[i].m_strExecFreqName;
                        }
                        else
                        {
                            //当不显示时，医嘱表中的为修改标志=1时也显示出来 (0-普通状态,1-频率修改)
                            if (arrExecOrder[i].m_intCHARGE_INT == 1)
                            {
                                row1.Cells["dtv_Freq"].Value = arrExecOrder[i].m_strExecFreqName;//频率
                            }
                            else
                            {
                                row1.Cells["dtv_Freq"].Value = "";//频率
                            }
                        }
                        if (p_objItem.m_intAPPENDVIEWTYPE_INT == 1 && (arrExecOrder[i].m_intStatus == 5 || (arrExecOrder[i].m_intStatus == 2 && arrExecOrder[i].m_dtStartDate == arrExecOrder[i].m_dtExecutedate)))//已审核但末执行，及首次执行的才显示补次及补次的合计量
                        {
                            //补次，这个是医生开医嘱时候指定的补次次数，或者护士执行时候指定的补次次数（附加量），第一次执行医嘱的时候开会出现；不同于忘记执行医嘱造成的补漏
                            row1.Cells["ATTACHTIMES_INT"].Value = arrExecOrder[i].m_intATTACHTIMES_INT;
                            m_dmlOneUse = arrExecOrder[i].m_dmlOneUse * arrExecOrder[i].m_intATTACHTIMES_INT;
                        }
                        else
                        {
                            //补次
                            row1.Cells["ATTACHTIMES_INT"].Value = "";
                            m_dmlOneUse = 0;
                        }

                        //领量
                        if (p_objItem.m_intQTYVIEWTYPE_INT == 1)
                        {
                            if (arrExecOrder[i].m_dmlGet > 0)
                            {
                                row1.Cells["dtv_Get"].Value = arrExecOrder[i].m_dmlGet.ToString() + " " + arrExecOrder[i].m_strGetunit;
                            }
                            else
                            {
                                row1.Cells["dtv_Get"].Value = "";
                            }
                        }
                        else
                        {
                            //领量
                            row1.Cells["dtv_Get"].Value = "";
                        }
                    }
                    else
                    {
                        //用量
                        row1.Cells["dtv_Dosage"].Value = "";
                        //频率
                        row1.Cells["dtv_Freq"].Value = "";
                        //用法
                        row1.Cells["dtv_UseType"].Value = "";
                        //补次
                        row1.Cells["ATTACHTIMES_INT"].Value = "";
                        //领量
                        row1.Cells["dtv_Get"].Value = "";

                    }
                    #endregion
                    string m_strFeel = "";
                    if (arrExecOrder[i].m_intISNEEDFEEL == 1)
                    {

                        switch (arrExecOrder[i].m_intFEEL_INT)
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
                    }
                    //出院带药天数
                    string m_strOUTGETMEDDAYS_INT = "";
                    //总量字段的控制
                    if (arrExecOrder[i].m_strOrderDicCateID.Equals(m_objSpecateVo.m_strMID_MEDICINE_CHR))//中药类型逻辑
                    {
                        row1.Cells["dtv_sum"].Value = arrExecOrder[i].m_intOUTGETMEDDAYS_INT.ToString() + "服共" + Convert.ToString(arrExecOrder[i].m_dmlGet + m_dmlOneUse) + arrExecOrder[i].m_strGetunit;
                        m_strOUTGETMEDDAYS_INT = arrExecOrder[i].m_intOUTGETMEDDAYS_INT.ToString() + "服";
                    }
                    else
                    {
                        //总量  N天共M片。N-表示出院带药的天数，M-表示出院带药合计的数量
                        if (arrExecOrder[i].m_intExecuteType == 3)
                        {
                            row1.Cells["dtv_sum"].Value = arrExecOrder[i].m_intOUTGETMEDDAYS_INT.ToString() + "天共" + Convert.ToString(arrExecOrder[i].m_dmlGet + m_dmlOneUse) + arrExecOrder[i].m_strGetunit;
                            m_strOUTGETMEDDAYS_INT = arrExecOrder[i].m_intOUTGETMEDDAYS_INT.ToString() + "天";
                        }
                        else
                        {
                            row1.Cells["dtv_sum"].Value = "共" + Convert.ToString(arrExecOrder[i].m_dmlGet + m_dmlOneUse) + arrExecOrder[i].m_strGetunit;
                            m_strOUTGETMEDDAYS_INT = "";
                        }
                    }
                    //名称
                    row1.Cells["dtv_Name"].Value = arrExecOrder[i].m_strName + " " + row1.Cells["dtv_Dosage"].Value.ToString() + " " + row1.Cells["dtv_UseType"].Value.ToString() + " " + row1.Cells["dtv_Freq"].Value.ToString() + m_strFeel + " " + m_strOUTGETMEDDAYS_INT + m_strRecute;

                    row1.Tag = arrExecOrder[i];
                }
            }
            //刷新同方医嘱的方号颜色并隐藏相同性质的字段
            m_mthRefreshSameReqNoColor();
            if (this.m_objViewer.m_dtvOrderList.RowCount > 0)
            {
                this.m_objViewer.m_dtvOrderList.CurrentCell = this.m_objViewer.m_dtvOrderList.Rows[0].Cells[3];
            }

        }

        /// <summary>
        /// 当前是否还有要执行的医嘱(true-存在未执行的,false-未存在执行的)
        /// </summary>
        /// <param name="arrExecOrder"></param>
        internal bool m_blBihOrderCanExecute()
        {
            clsBIHCanExecOrder[] arrExecOrder;
            DataView myDataView = GetExecDataView(m_dtExecOrder, m_intState);
            filltheExecOrderTable(myDataView, out arrExecOrder);

            int k = 0;
            bool m_blHave = false;
            if (arrExecOrder != null)
            {
                //上一个记录的病人流水号
                for (int i = 0; i < arrExecOrder.Length; i++)
                {
                    //判断当前医嘱是否可执行
                    if (CanListOrder(arrExecOrder[i]) == false)
                    {
                        continue;
                    }
                    m_blHave = true;
                    break;
                }
            }
            return m_blHave;
        }

        private void BindTheExecData(clsBIHCanExecOrder ExecOrder)
        {
            //m_intRepair：0-不是补漏的医嘱（正常医嘱）,1-只是补漏的医嘱,2-补漏及非补漏的医嘱（正常及补漏医嘱）

            if (m_htReExecute.Contains(ExecOrder.m_strOrderID))//长嘱，已执行过的，如有补次将有补次
            {
                //连续性医嘱执行过一次后，不再执行
                if (ExecOrder.m_strExecFreqID.Trim().Equals(m_objSpecateVo.m_strCONFREQID_CHR.Trim()))
                {
                    return;
                }
                /*<=================================*/
                int m_intExecAllCount = int.Parse(m_htReExecute[ExecOrder.m_strOrderID].ToString());//该条医嘱已执行的次数，已存在的执行单个数
                int ALLCount = 0;//总应有的执行数目
                int m_intTemp = 0;
                TimeSpan span;
                if (ExecOrder.m_intDays_Int <= 0)
                {
                    m_intTemp = 1;
                }
                else
                {
                    m_intTemp = ExecOrder.m_intDays_Int;
                }
                if (ExecOrder.m_dtStartDate != DateTime.MinValue)
                {
                    span = ExecOrder.m_dtToday - ExecOrder.m_dtStartDate;
                    ALLCount = span.Days / m_intTemp;
                    ALLCount += ExecOrder.m_intATTACHTIMES_INT + 1;//第一次执行的次数；m_intATTACHTIMES_INT（医生开医嘱或者护士转抄医嘱的时候，手工补的次数）
                    //以执行频率每2天执行一次为例子考虑
                    //如果过了3天，应该执行2次；如果过了4天，应该执行3次
                    if (span.Days % m_intTemp == 0)
                    {
                        ExecOrder.m_intRepairCount = ALLCount - m_intExecAllCount - 1;
                        if (ExecOrder.m_intRepairCount <= 0)
                        {
                            return;
                        }
                        ExecOrder.m_intRepair = 2;
                    }
                    else
                    {
                        ExecOrder.m_intRepairCount = ALLCount - m_intExecAllCount;
                        if (ExecOrder.m_intRepairCount <= 0)
                        {
                            return;
                        }
                        ExecOrder.m_intRepair = 1;
                    }
                }
            }
        }

        /// <summary>
        /// 刷新同方医嘱的方号颜色并隐藏相同性质的字段,皮试结果颜色显示
        /// </summary>
        public void m_mthRefreshSameReqNoColor()
        {
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
            {
                DataGridViewRow objRow = this.m_objViewer.m_dtvOrderList.Rows[i];
                clsBIHCanExecOrder ExecOrder = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag;

                if (ExecOrder.m_intISNEEDFEEL == 1)
                {
                    objRow.Cells["dtv_Name"].Style.ForeColor = FeedColor;//需要皮试的项目颜色
                }
                if (i < this.m_objViewer.m_dtvOrderList.RowCount - 1)
                {
                    clsBIHCanExecOrder ExecOrder2 = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i + 1].Tag;
                    if ((ExecOrder.m_strRegisterID == ExecOrder2.m_strRegisterID) && (ExecOrder.m_intRecipenNo == ExecOrder2.m_intRecipenNo))
                    {
                        this.m_objViewer.m_dtvOrderList.Rows[i + 1].Cells["dtv_RecipeNo"].Value = "";
                        this.m_objViewer.m_dtvOrderList.Rows[i + 1].Cells["dtv_ExecuteType"].Value = "";
                        this.m_objViewer.m_dtvOrderList.Rows[i + 1].Cells["dtv_ENTRUST"].Value = "";
                        this.m_objViewer.m_dtvOrderList.Rows[i + 1].Cells["ATTACHTIMES_INT"].Value = "";
                        if (ExecOrder.m_strOrderDicCateID.Equals(m_objSpecateVo.m_strMID_MEDICINE_CHR))//中药类型逻辑
                        {
                            this.m_objViewer.m_dtvOrderList.Rows[i + 1].Cells["dtv_REMARK"].Value = "";
                        }
                    }
                }

            }
            int cout = GetWaitCfPersonCout();
            this.m_objViewer.m_lblNewOrderCount.Text = "共有 " + cout.ToString() + " 病人有医嘱需要执行";



        }

        private bool CanListOrder(clsBIHCanExecOrder clsBIHCanExecOrder)
        {


            switch (clsBIHCanExecOrder.m_intExecuteType)
            {
                case 1:
                    return CanExecOrder(clsBIHCanExecOrder);
                    break;
                case 2:
                    if (clsBIHCanExecOrder.m_intStatus == 5)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case 3:
                    if (clsBIHCanExecOrder.m_intStatus == 5)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
            }

            return false;
        }


        #endregion

        #region 判断当前医嘱是否可执行
        /// <summary>
        /// 判断当前医嘱是否可执行
        /// </summary>
        /// <param name="clsBIHCanExecOrder"></param>
        private bool CanExecOrder(clsBIHCanExecOrder m_BIHCanExecOrder)//m_BIHCanExecOrder记录一条医嘱
        {
            //加上补执行次数
            if (m_objViewer.m_chkReExcute.Checked == true)//如果补漏执行
            {
                BindTheExecData(m_BIHCanExecOrder);
                if (m_BIHCanExecOrder.m_intRepair > 0)
                {
                    return true;
                }
            }
            /*<==================================*/
            bool m_blCanExec = false;//是否可以执行
            int m_intTemp;
            //状态不为审核执行或执行的为不可执行
            if (m_BIHCanExecOrder.m_intStatus != 2 && m_BIHCanExecOrder.m_intStatus != 5)//2和5代表该条医嘱可以执行，不等于2或5，即表示不可以执行
            {
                return false;
            }
            TimeSpan span;
            switch (m_BIHCanExecOrder.m_intExecuteType)
            {
                case 1://长嘱
                    //查看今日是否已执行过
                    span = m_BIHCanExecOrder.m_dtExecutedate - m_BIHCanExecOrder.m_dtToday;
                    if (span.Days == 0)//表示今日已经执行了
                    {
                        return false;
                    }
                    /*<==========================*/
                    span = m_BIHCanExecOrder.m_dtToday - m_BIHCanExecOrder.m_dtStartDate;
                    if (span.Days < 0)//表示尚未需要开始执行该条医嘱，因为当前日期小于开始执行时间
                    {
                        return false;
                    }
                    if (m_BIHCanExecOrder.m_intStatus == 5)//表示可以执行
                    {
                        return true;
                    }
                    else if (m_BIHCanExecOrder.m_intStatus == 2)
                    {
                        //连续性医嘱执行过一次后，不再执行
                        if (m_BIHCanExecOrder.m_strExecFreqID.Trim().Equals(m_objSpecateVo.m_strCONFREQID_CHR.Trim()))
                        {
                            return false;
                        }
                        /*<=================================*/
                    }
                    span = m_BIHCanExecOrder.m_dtFinishDate - m_BIHCanExecOrder.m_dtToday;//因为医嘱停嘱时间在今日之前，故此已经停止医嘱，不需要执行
                    if ((m_BIHCanExecOrder.m_dtFinishDate != DateTime.MinValue) && (span.Days < 0))
                    {
                        return false;
                    }
                    //针对医嘱执行频率的规定，是x天内执行y次，护士执行医嘱的时候，一次过把x天内的y次都执行了，把y次的费用给收齐了，看看表t_aid_recipefreq
                    if (m_BIHCanExecOrder.m_intDays_Int <= 0)//医嘱没有医嘱执行频率对应的一个频率时间段的话，给个默认值。1天。
                    {
                        m_intTemp = 1;
                    }
                    else
                    {
                        m_intTemp = m_BIHCanExecOrder.m_intDays_Int;
                    }
                    if (m_BIHCanExecOrder.m_dtStartDate != DateTime.MinValue)//具有有效的医嘱开始时间
                    {
                        span = m_BIHCanExecOrder.m_dtToday - m_BIHCanExecOrder.m_dtStartDate;
                        if (span.Days % m_intTemp == 0)//正好是新的执行时间段
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    break;
                case 2://临嘱
                    if (m_BIHCanExecOrder.m_intStatus == 5)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case 3://带药
                    if (m_BIHCanExecOrder.m_intStatus == 5)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;

            }
            return m_blCanExec;
        }
        #endregion

        #region 判断当前医嘱是否可撤消执行
        /// <summary>
        /// 判断当前医嘱是否可撤消执行
        /// </summary>
        /// <param name="clsBIHCanExecOrder"></param>
        private bool CanExecDrawOrder(clsBIHCanExecOrder m_BIHCanExecOrder)
        {

            bool m_blCanExecDraw = true;

            //if (m_BIHCanExecOrder.m_intExecCount <= 0)
            //{
            //    return false;
            //}

            return m_blCanExecDraw;
        }
        #endregion

        #region 为费用datagridview填值
        /// <summary>
        /// 为费用datagridview填值
        /// </summary>
        /// <param name="order"></param>
        private void filltheChargeList(clsBIHCanExecOrder order)
        {
            if (m_dtChargeList != null && m_dtChargeList.Rows.Count > 0)
            {
                this.m_objViewer.m_dtvChangeList.Rows.Clear();
                DataView myDataView = new DataView(m_dtChargeList);
                myDataView.RowFilter = "orderid_chr='" + order.m_strOrderID + "'";
                myDataView.Sort = "FLAG_INT";
                if (myDataView.Count <= 0)
                {
                    return;
                }
                clsChargeForDisplay[] m_arrObjItem;
                GetChargeListFromDateTable(myDataView, out m_arrObjItem);

                int k = 0;
                for (int i = 0; i < m_arrObjItem.Length; i++)
                {
                    if (m_arrObjItem[i].m_intCONTINUEUSETYPE_INT == 1 && order.m_intStatus == 2)//续用处理
                    {
                        continue;
                    }

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
                        // 总让利金额
                        if (this.intDiffPriceOn == 1)
                            row1.Cells["TotalDiffCost"].Value = m_arrObjItem[i].m_dblDiffCostMoney;
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
            //objRow记录该病区需要执行的所有医嘱，原始数据来自m_dtExecorder
            //arrExecOrder记录该病区需要执行的所有医嘱
            //医嘱执行对象数组

            int intRowsCount = objRow.Count;
            if (intRowsCount <= 0)
            {
                arrExecOrder = new clsBIHCanExecOrder[0];
            }
            else
            {
                m_arrBedIdList = new ArrayList();
                arrExecOrder = new clsBIHCanExecOrder[intRowsCount];//该病区需要执行的医嘱的数组
                DataRowView row = null;
                for (int i = 0; i < intRowsCount; i++)
                {
                    row = objRow[i];//单条需要执行的医嘱
                    arrExecOrder[i] = new clsBIHCanExecOrder();
                    arrExecOrder[i].m_strAREAID_CHR = row["AREAID_CHR"].ToString();//当前病人所在病区id
                    arrExecOrder[i].m_strBedID = row["bedid_chr"].ToString();//当前病人所在床位ID
                    arrExecOrder[i].m_strBedName = row["code_chr"].ToString().Trim();

                    arrExecOrder[i].m_strRegisterID = row["registerid_chr"].ToString().Trim();
                    arrExecOrder[i].m_strPatientName = row["LASTNAME_VCHR"].ToString().Trim();//姓名
                    arrExecOrder[i].m_strPatientSex = row["SEX_CHR"].ToString().Trim();//性别

                    if (!row["RECIPENO_INT"].ToString().Trim().Equals(""))
                        arrExecOrder[i].m_intRecipenNo = int.Parse(row["RECIPENO_INT"].ToString().Trim()); //方号
                    if (!row["RECIPENO2_INT"].ToString().Trim().Equals(""))
                        arrExecOrder[i].m_intRecipenNo2 = int.Parse(row["RECIPENO2_INT"].ToString().Trim()); //方号

                    if (!row["EXECUTETYPE_INT"].ToString().Trim().Equals(""))
                        arrExecOrder[i].m_intExecuteType = int.Parse(row["EXECUTETYPE_INT"].ToString().Trim());//医嘱（医嘱方式）
                    arrExecOrder[i].m_strOrderDicCateID = row["ordercateid_chr"].ToString().Trim();//类别ID
                    arrExecOrder[i].m_strOrderDicCateName = row["viewname_vchr"].ToString().Trim();//类别名称
                    arrExecOrder[i].m_strName = row["NAME_VCHR"].ToString().Trim();//项目名称
                    if (!row["Dosage_Dec"].ToString().Trim().Equals(""))
                        arrExecOrder[i].m_dmlDosage = decimal.Parse(row["Dosage_Dec"].ToString().Trim()); ;//剂量
                    arrExecOrder[i].m_strDosageUnit = row["dosageunit_chr"].ToString().Trim();//剂量单位
                    arrExecOrder[i].m_strExecFreqID = row["EXECFREQID_CHR"].ToString().Trim();//频率ID
                    arrExecOrder[i].m_strExecFreqName = row["EXECFREQNAME_CHR"].ToString().Trim();////频率名称
                    if (!row["GET_DEC"].ToString().Trim().Equals(""))
                        arrExecOrder[i].m_dmlGet = decimal.Parse(row["GET_DEC"].ToString().Trim());//领量
                    arrExecOrder[i].m_strGetunit = row["getunit_chr"].ToString().Trim();//领量单位
                    arrExecOrder[i].m_strEntrust = row["ENTRUST_VCHR"].ToString().Trim();//嘱托
                    arrExecOrder[i].m_strDOCTOR_VCHR = row["DOCTOR_VCHR"].ToString().Trim();//主管医生
                    if (!row["POSTDATE_DAT"].ToString().Trim().Equals(""))//提交时间
                        arrExecOrder[i].m_dtPostdate = Convert.ToDateTime(row["POSTDATE_DAT"].ToString().Trim());
                    arrExecOrder[i].m_strASSESSORFOREXEC_CHR = row["CONFIRMER_VCHR"].ToString().Trim();//审核人-
                    arrExecOrder[i].m_strASSESSORFOREXEC_DAT = row["CONFIRM_DAT"].ToString().Trim();//审核时间
                    arrExecOrder[i].m_strDosetypeID = row["DOSETYPEID_CHR"].ToString().Trim();//用法名称
                    arrExecOrder[i].m_strDosetypeName = row["DOSETYPENAME_CHR"].ToString().Trim();//用法名称
                    arrExecOrder[i].m_strOrderID = row["orderid_chr"].ToString().Trim();//医嘱表流水号
                    if (!row["STATUS_INT"].ToString().Trim().Equals(""))
                        arrExecOrder[i].m_intStatus = int.Parse(row["STATUS_INT"].ToString().Trim());//当前医嘱状态
                    arrExecOrder[i].m_strCreatorID = row["CREATORID_CHR"].ToString().Trim();//开医嘱单医生ID
                    arrExecOrder[i].m_strCreator = row["CREATOR_CHR"].ToString().Trim();//开医嘱单医生
                    arrExecOrder[i].m_strCHARGEDOCTORGROUPID = row["chargedoctorgroupid_chr"].ToString().Trim();//开医嘱单医生所在专业组

                    arrExecOrder[i].m_dtToday = Convert.ToDateTime(Convert.ToDateTime(row["today"].ToString().Trim()).ToString("yyyy-MM-dd"));//从数据库取出医嘱时的时间,为判断当前医嘱是否可执行使用
                    if (!row["Days_Int"].ToString().Trim().Equals(""))
                        arrExecOrder[i].m_intDays_Int = int.Parse(row["Days_Int"].ToString().Trim());//天数 医嘱频率对应的 天数 为判断当前医嘱是否可执行使用 
                    if (!row["TIMES_INT"].ToString().Trim().Equals(""))
                        arrExecOrder[i].m_intTIMES_INT = int.Parse(row["TIMES_INT"].ToString().Trim());//次数 医嘱频率对应的 次数  

                    if (!row["FINISHDATE_DAT"].ToString().Trim().Equals(""))//结束时间
                    {
                        arrExecOrder[i].m_dtFinishDate = Convert.ToDateTime(row["FINISHDATE_DAT"].ToString().Trim());//FINISHDATE_DAT
                    }
                    else
                    {
                        arrExecOrder[i].m_dtFinishDate = DateTime.MinValue;
                    }
                    if (!row["STARTDATE_DAT"].ToString().Trim().Equals(""))//开始时间
                    {
                        arrExecOrder[i].m_dtStartDate = Convert.ToDateTime(Convert.ToDateTime(row["STARTDATE_DAT"].ToString().Trim()).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        arrExecOrder[i].m_dtStartDate = DateTime.MinValue;
                    }
                    if (!row["EXECUTEDATE_DAT"].ToString().Trim().Equals(""))//执行时间
                    {
                        arrExecOrder[i].m_dtExecutedate = Convert.ToDateTime(Convert.ToDateTime(row["EXECUTEDATE_DAT"].ToString().Trim()).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        arrExecOrder[i].m_dtExecutedate = DateTime.MinValue;
                    }
                    arrExecOrder[i].m_strOrderDicID = row["ORDERDICID_CHR"].ToString().Trim();//诊疗项目流水号
                    arrExecOrder[i].m_strParentID = row["patientid_chr"].ToString().Trim();//病人ID
                    arrExecOrder[i].m_strCREATEAREA_ID = row["createareaid_chr"].ToString().Trim();//开单科室ID
                    arrExecOrder[i].m_strCREATEAREA_Name = row["CREATEAREANAME_VCHR"].ToString().Trim();//开单科室
                    if (!row["OUTGETMEDDAYS_INT"].ToString().Trim().Equals(""))
                    {
                        arrExecOrder[i].m_intOUTGETMEDDAYS_INT = int.Parse(row["OUTGETMEDDAYS_INT"].ToString().Trim());//出院带药天数(当执行类型为3=出院带药})
                    }
                    arrExecOrder[i].m_strSAMPLEID_VCHR = row["SAMPLEID_VCHR"].ToString().Trim();//检验样本号
                    arrExecOrder[i].m_strSAMPLEName_VCHR = row["sample_type_desc_vchr"].ToString().Trim();//检验样本类型
                    arrExecOrder[i].m_strPARTID_VCHR = row["PARTID_VCHR"].ToString().Trim();//检查部位ID
                    arrExecOrder[i].m_strPARTNAME_VCHR = row["partname"].ToString().Trim();//检查部位名称

                    arrExecOrder[i].m_strDOCTORID_CHR = row["DOCTORID_CHR"].ToString().Trim();//管床医生
                    arrExecOrder[i].m_strCURAREAID_CHR = row["CURAREAID_CHR"].ToString().Trim();//下医嘱时病人所在病区ID
                    arrExecOrder[i].m_strCURBEDID_CHR = row["CURBEDID_CHR"].ToString().Trim();//下医嘱时病人所在病床ID
                    arrExecOrder[i].m_strCURAREAName = row["DEPTNAME_VCHR"].ToString().Trim();//开单科室名称
                    arrExecOrder[i].m_strCURBEDName = row["code_chr"].ToString().Trim();//开单病床名称

                    if (arrExecOrder[i].m_intExecuteType == 1)//这是长嘱
                    {
                        arrExecOrder[i].m_strEXECTIME_VCHR = row["LEXECTIME_VCHR"].ToString().Trim();//长嘱执行时间
                    }
                    else
                    {
                        arrExecOrder[i].m_strEXECTIME_VCHR = row["TEXECTIME_VCHR"].ToString().Trim();//临嘱执行时间
                    }
                    arrExecOrder[i].m_intATTACHTIMES_INT = clsConverter.ToInt(row["ATTACHTIMES_INT"].ToString().Trim());//补次次数
                    arrExecOrder[i].m_strDOCTORGROUPID_CHR = row["DOCTORGROUPID_CHR"].ToString().Trim();//医生专业组ID
                    //皮试相关字段
                    arrExecOrder[i].m_intISNEEDFEEL = int.Parse(row["ISNEEDFEEL"].ToString().Trim());//是否需要皮试
                    arrExecOrder[i].m_intFEEL_INT = int.Parse(row["FEEL_INT"].ToString().Trim());//皮试结果
                    arrExecOrder[i].m_strFEELRESULT_VCHR = Convert.ToString(row["FEELRESULT_VCHR"].ToString().Trim());//皮试结果备注
                    if (!row["CHARGE_INT"].ToString().Trim().Equals("")) //     修改标志(0-普通状态,1-频率修改)，可能是操作人下医嘱的时候，修改了默认的频率，待查！！！
                        arrExecOrder[i].m_intCHARGE_INT = int.Parse(row["CHARGE_INT"].ToString().Trim());
                    //说明
                    arrExecOrder[i].m_strREMARK_VCHR = row["REMARK_VCHR"].ToString().Trim();
                    //申请单类别ID(AR_APPLY_TYPELIST)
                    arrExecOrder[i].m_strAPPLYTYPEID_CHR = row["APPLYTYPEID_CHR"].ToString().Trim();
                    //检验申请单元ID(t_aid_lis_apply_unit)
                    arrExecOrder[i].m_strLISAPPLYUNITID_CHR = row["LISAPPLYUNITID_CHR"].ToString().Trim();
                    //补一次的领量
                    arrExecOrder[i].m_dmlOneUse = Convert.ToDecimal(row["SINGLEAMOUNT_DEC"].ToString().Trim());
                    // 预发天数
                    arrExecOrder[i].PretestDays = row["pretestdays"] == DBNull.Value ? 0 : Convert.ToInt32(row["pretestdays"]);
                    // 疗程天数.预扣数量2(预扣量剩余)--领量
                    arrExecOrder[i].PreAmount2 = row["preamount2"] == DBNull.Value ? 0 : Convert.ToDecimal(row["preamount2"]);
                    // 疗程天数
                    arrExecOrder[i].CureDays = row["curedays"] == DBNull.Value ? 0 : Convert.ToInt32(row["curedays"]);
                    // 疗程-审核状态: -9 空; -1 药房审核不通过; 0 默认; 1 审核通过
                    arrExecOrder[i].CheckState = row["checkstate"] == DBNull.Value ? -9 : Convert.ToInt32(row["checkstate"]);

                    //为当前医嘱记录按病人床号保存 为了按床号f8,f9进行上下转换
                    //m_arrBedIdList记录了带有医嘱的所有病床号
                    if (m_blBedIdKey)
                    {
                        if (!m_arrBedIdList.Contains(arrExecOrder[i].m_strBedID))
                        {
                            m_arrBedIdList.Add(arrExecOrder[i].m_strBedID);
                        }
                    }
                }
            }
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
            if (objRow.Count <= 0) return;
            objPatient = new clsBIHPatientInfo();
            DataRowView row2 = objRow[0];
            objPatient.m_strRegisterID = clsConverter.ToString(row2["RegisterID_Chr"]).Trim();
            objPatient.m_strPatientID = clsConverter.ToString(row2["PatientID_Chr"]).Trim();
            objPatient.m_strInHospitalNo = clsConverter.ToString(row2["InPatientID_Chr"]).Trim();
            objPatient.m_dtInHospital = clsConverter.ToDateTime(row2["InPatient_Dat"]);
            objPatient.m_strDeptID = clsConverter.ToString(row2["DeptID_Chr"]).Trim();
            objPatient.m_strDeptName = clsConverter.ToString(row2["deptname"]).Trim();
            objPatient.m_strPATIENTCARDID_CHR = row2["patientcardid_chr"].ToString().Trim();

            objPatient.m_strAreaID = clsConverter.ToString(row2["AreaID_Chr"]).Trim();
            objPatient.m_strAreaName = clsConverter.ToString(row2["AreaName"]).Trim();
            objPatient.m_strBedID = clsConverter.ToString(row2["BedID_Chr"]).Trim();
            objPatient.m_strBedName = clsConverter.ToString(row2["BedName"]).Trim();
            /** update by xzf (05-09-29) */
            //@ objPatient.m_strDiagnose=clsConverter.ToString(objRow["Diagnose_Vchr"]).Trim();
            objPatient.m_strDiagnose = clsConverter.ToString(row2["ICD10DIAGTEXT_VCHR"]).Trim();
            /* <<============================= */
            objPatient.m_intInTimes = clsConverter.ToInt(row2["InPatientCount_Int"]);
            objPatient.m_strPatientName = clsConverter.ToString(row2["Name_VChr"]).Trim();

            objPatient.m_strSex = clsConverter.ToString(row2["Sex_Chr"]).Trim();
            objPatient.m_dtBorn = clsConverter.ToDateTime(row2["Birth_Dat"]);
            objPatient.m_strPayTypeID = clsConverter.ToString(row2["PayTypeID_Chr"]).Trim();
            objPatient.m_strPayTypeName = clsConverter.ToString(row2["PayTypeName_VChr"]).Trim();
            objPatient.m_strInpatientState = clsConverter.ToString(row2["state"]).Trim();
            objPatient.m_strMzdiagnose_vchr = clsConverter.ToString(row2["mzdiagnose_vchr"]).Trim();
            objPatient.m_strDiagnose_vchr = clsConverter.ToString(row2["diagnose_vchr"]).Trim();
            objPatient.m_intREMARK_INT = clsConverter.ToInt(row2["REMARK_INT"]);
            objPatient.m_intCHARGECTL_INT = clsConverter.ToInt(row2["CHARGECTL_INT"]);
            objPatient.m_decinsuredsum_mny = clsConverter.ToDecimal(row2["insuredsum_mny"]);
            if (row2["limitrate_mny"] != System.DBNull.Value)
            {
                objPatient.m_dblLIMITRATE_MNY = double.Parse(row2["limitrate_mny"].ToString());
            }
            try
            {
                // TimeSpan span1 = clsConverter.ToDateTime(row2["today"].ToString().Trim()) - objPatient.m_dtBorn;
                //objPatient.m_intAge = span1.Days / 365;
                ////统一年龄算法
                //objPatient.m_strAge = (new clsBrithdayToAge().m_strGetAge(objPatient.m_dtBorn)).Trim();
                objPatient.m_strAge = com.digitalwave.Emr.StaticObject.clsConsts.s_strCalAge(objPatient.m_dtBorn.ToString("yyyy-MM-dd hh:mm:ss"), objPatient.m_dtInHospital, out objPatient.m_intAge);

            }
            catch
            {
            }
            try
            {
                objPatient.m_strREMARKNAME_VCHR = row2["REMARKNAME_VCHR"].ToString().Trim();
            }
            catch
            {
            }
            try
            {
                objPatient.m_strDES_VCHR = row2["DES_VCHR"].ToString().Trim();
            }
            catch
            {
            }
            decimal PreMoney = 0, PreUseMoney = 0, NotUsePreMoney = 0, ClearMoney = 0, WaitMoney = 0, WaitClearMoney = 0, VerticalMoney = 0;
            //decimal unitprice_dec = 0, amount_dec = 0, m_decSum = 0, m_decPre = 0;
            decimal m_decSum = 0, m_decPre = 0;
            int pstatus_int = -1;

            //病人的合计金预交金
            if (m_dtChargeMoney != null && m_dtChargeMoney.Rows.Count > 0)
            {
                DataView myDataView = new DataView(m_dtChargeMoney);
                myDataView.RowFilter = "registerid_chr='" + objPatient.m_strRegisterID + "'";

                for (int i = 0; i < myDataView.Count; i++)
                {
                    DataRowView row = myDataView[i];
                    //unitprice_dec = 0;
                    //amount_dec = 0;
                    pstatus_int = -1;
                    //if (!row["unitprice_dec"].ToString().Trim().Equals(""))
                    //{
                    //    unitprice_dec = Convert.ToDecimal(row["unitprice_dec"].ToString().Trim());
                    //}
                    //if (!row["amount_dec"].ToString().Trim().Equals(""))
                    //{
                    //    amount_dec = Convert.ToDecimal(row["amount_dec"].ToString().Trim());
                    //}
                    //if (!row["pstatus_int"].ToString().Trim().Equals(""))
                    //{
                    //    pstatus_int = int.Parse(row["pstatus_int"].ToString().Trim());
                    //}
                    //m_decSum = decimal.Round(unitprice_dec * amount_dec, 2);
                    decimal.TryParse(row["Money"].ToString().Trim(), out m_decSum);
                    int.TryParse(row["pstatus_int"].ToString().Trim(), out pstatus_int);
                    switch (pstatus_int)
                    {
                        case 1:
                            WaitMoney += m_decSum;
                            break;
                        case 2:
                            WaitClearMoney += m_decSum;
                            break;
                        case 3:
                            ClearMoney += m_decSum;
                            break;
                        case 4:
                            VerticalMoney += m_decSum;
                            break;

                    }
                    if (pstatus_int != 0)
                    {
                        PreUseMoney += m_decSum;
                    }


                }
            }
            if (m_dtPrepay != null && m_dtPrepay.Rows.Count > 0)
            {
                DataView myDataView2 = new DataView(m_dtPrepay);
                myDataView2.RowFilter = "registerid_chr='" + objPatient.m_strRegisterID + "'";
                for (int i = 0; i < myDataView2.Count; i++)
                {
                    DataRowView row = myDataView2[i];
                    if (!row["money_dec"].ToString().Trim().Equals(""))
                    {
                        m_decPre += decimal.Round(Convert.ToDecimal(row["money_dec"].ToString().Trim()), 2);
                    }

                }
            }
            NotUsePreMoney = m_decPre;

            objPatient.m_decPreMoney = NotUsePreMoney;//剩余的预交金额
            objPatient.m_decPreUseMoney = PreUseMoney;//已用金额
            objPatient.m_decClearMoney = ClearMoney;//已清金额
            objPatient.m_decVerticalMoney = VerticalMoney;//直收金额，某些药品或者治疗需要马上结清
            objPatient.m_decPrePayMoney = NotUsePreMoney - WaitMoney - WaitClearMoney;//结余金额
            //WaitMoney --- 待结费用
            //WaitClearMoney --- 已结算，但未清账

        }
        #endregion

        #region 费用表转换为费用明细对象  -- 医嘱执行关键方法 20180403 (医嘱信息 -> 费用信息)
        /// <summary>
        /// 将当前费用信息转换为费用明细表的信息  -- 医嘱执行关键方法 20180403 (医嘱信息 -> 费用信息)
        /// </summary>
        /// <param name="objRow"></param>
        /// <param name="m_arrObjItem"></param>
        void GetChargeListFromDateTable(DataView objRow, out clsChargeForDisplay[] m_arrObjItem)
        {
            m_arrObjItem = new clsChargeForDisplay[objRow.Count];
            decimal UNITPRICE_DEC = 0, ItemPrice_Mny = 0, PackQty_Dec = 0, decItemTradePrice = 0;
            int IPCHARGEFLG_INT = 0;
            for (int i = 0; i < objRow.Count; i++)
            {
                m_arrObjItem[i] = new clsChargeForDisplay();

                #region 附加的收费项目信息
                // 住院诊疗项目收费项目执行客户表VO
                clsORDERCHARGEDEPT_VO orderChargeVo = new clsORDERCHARGEDEPT_VO();
                DataRowView row = objRow[i];
                orderChargeVo.m_strSeq_int = clsConverter.ToString(row["SEQ_INT"]).Trim();
                orderChargeVo.m_strOrderid_chr = clsConverter.ToString(row["ORDERID_CHR"]).Trim();
                orderChargeVo.m_strOrderdicid_chr = clsConverter.ToString(row["ORDERDICID_CHR"]).Trim();
                orderChargeVo.m_strChargeitemid_chr = clsConverter.ToString(row["CHARGEITEMID_CHR"]).Trim();
                orderChargeVo.m_strClacarea_chr = clsConverter.ToString(row["CLACAREA_CHR"]).Trim();
                orderChargeVo.m_strCreatearea_chr = clsConverter.ToString(row["CREATEAREA_CHR"]).Trim();
                orderChargeVo.m_intFLAG_INT = clsConverter.ToInt(row["FLAG_INT"]);
                orderChargeVo.m_strChargeitemname_chr = clsConverter.ToString(row["CHARGEITEMNAME_CHR"]).Trim();
                orderChargeVo.m_strSpec_vchr = clsConverter.ToString(row["ITEMSPEC_VCHR"]).Trim();//取收费项目的规格
                orderChargeVo.m_strUnit_vchr = clsConverter.ToString(row["UNIT_VCHR"]).Trim();
                orderChargeVo.m_decAmount_dec = clsConverter.ToDecimal(row["AMOUNT_DEC"]);
                string strMedicinetypeid = row["medicinetypeid_chr"].ToString();
                //取收费项目中的单价
                /*decode(b.IPCHARGEFLG_INT,1,Round(B.ItemPrice_Mny/B.PackQty_Dec,4),0,B.ItemPrice_Mny,Round(B.ItemPrice_Mny/B.PackQty_Dec,4)) ItemPriceA*/
                UNITPRICE_DEC = 0;
                ItemPrice_Mny = 0;
                PackQty_Dec = 0;
                int.TryParse(row["IPCHARGEFLG_INT"].ToString(), out IPCHARGEFLG_INT);
                decimal.TryParse(row["ItemPrice_Mny"].ToString(), out ItemPrice_Mny);
                decimal.TryParse(row["PackQty_Dec"].ToString(), out PackQty_Dec);
                decimal.TryParse(row["tradeprice_mny"].ToString(), out decItemTradePrice);// 批发单价
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
                orderChargeVo.m_decUnitprice_dec = UNITPRICE_DEC;
                orderChargeVo.m_decUnitTradePrice_dec = decItemTradePrice;

                orderChargeVo.m_strCreatorid_chr = clsConverter.ToString(row["CREATORID_CHR"]).Trim();
                orderChargeVo.m_strCreator_vchr = clsConverter.ToString(row["CREATOR_VCHR"]).Trim();
                orderChargeVo.m_strCreatedate_dat = clsConverter.ToDateTime(row["CREATEDATE_DAT"]);
                orderChargeVo.REMARK = clsConverter.ToString(row["REMARK"]).Trim();
                orderChargeVo.m_strINSURACEDESC_VCHR = clsConverter.ToString(row["INSURACEDESC_VCHR"]).Trim();
                orderChargeVo.m_intRATETYPE_INT = clsConverter.ToInt(row["RATETYPE_INT"]);//是否计费 
                orderChargeVo.m_intCONTINUEUSETYPE_INT = clsConverter.ToInt(row["CONTINUEUSETYPE_INT"]);
                if (!row["SINGLEAMOUNT_DEC"].ToString().Trim().Equals(""))
                    orderChargeVo.m_decSINGLEAMOUNT_DEC = clsConverter.ToDecimal(row["SINGLEAMOUNT_DEC"]);
                //附加的收费信息
                orderChargeVo.m_intISRICH_INT = clsConverter.ToInt(row["ISRICH_INT"]);
                orderChargeVo.m_strISSELFPAY_CHR = clsConverter.ToString(row["ISSELFPAY_CHR"]).Trim();
                orderChargeVo.m_strItemIPCalcType_Chr = clsConverter.ToString(row["ItemIPCalcType_Chr"]).Trim();
                orderChargeVo.m_strItemIpInvType_Chr = clsConverter.ToString(row["ItemIpInvType_Chr"]).Trim();//核算类别
                orderChargeVo.m_intITEMSRCTYPE_INT = clsConverter.ToInt(row["ITEMSRCTYPE_INT"]);
                orderChargeVo.m_strITEMSRCID_VCHR = clsConverter.ToString(row["ITEMSRCID_VCHR"]);
                orderChargeVo.m_intPUTMEDTYPE_INT = clsConverter.ToInt(row["PUTMEDTYPE_INT"]);
                orderChargeVo.m_intMEDICNETYPE_INT = clsConverter.ToInt(row["MEDICNETYPE_INT"]);
                orderChargeVo.m_decDOSAGE_DEC = clsConverter.ToDecimal(row["DOSAGE_DEC"]);
                orderChargeVo.m_strDOSAGEUNIT_CHR = clsConverter.ToString(row["DOSAGEUNIT_CHR"]);
                #region  摆药处理 药品的都摆 -- 摆药标识(判断)
                if (orderChargeVo.m_intITEMSRCTYPE_INT == 1 && orderChargeVo.m_intPUTMEDTYPE_INT == 1 && orderChargeVo.m_intFLAG_INT != 3)
                {
                    // 药品来源: 0 药房(全计费,摆药); 1 患者自备(只收费用法加收项目,不摆药); 2 科室基数(全计费，不摆药) 20180404
                    if (clsConverter.ToInt(row["medSource"]) == 1 || clsConverter.ToInt(row["medSource"]) == 2)
                    {
                        orderChargeVo.m_intPOFLAG_INT = 0;
                    }
                    else
                    {
                        orderChargeVo.m_intPOFLAG_INT = 1;
                    }
                }
                #endregion
                m_arrObjItem[i].m_objORDERCHARGEDEPT_VO = orderChargeVo;//住院诊疗项目收费项目执行客户表
                #endregion

                m_arrObjItem[i].m_strChargeID = clsConverter.ToString(row["CHARGEITEMID_CHR"]).Trim();
                //收费项目名称
                m_arrObjItem[i].m_strName = clsConverter.ToString(row["CHARGEITEMNAME_CHR"]).Trim();
                double dblNum = 0;
                //单价 
                m_arrObjItem[i].m_dblPrice = double.Parse(orderChargeVo.m_decUnitprice_dec.ToString());

                if (!row["AMOUNT_DEC"].ToString().Trim().Equals(""))
                {
                    dblNum = double.Parse(clsConverter.ToString(row["AMOUNT_DEC"]).Trim());
                }
                //领量
                m_arrObjItem[i].m_dblDrawAmount = dblNum;
                m_arrObjItem[i].m_dblTradePrice = double.Parse(decItemTradePrice.ToString());
                // 总让利金额,取负数
                if (this.m_blnIsDiffMed(strMedicinetypeid))//是让利药品才显示
                {
                    m_arrObjItem[i].m_dblDiffCostMoney = Math.Round((m_arrObjItem[i].m_dblTradePrice - m_arrObjItem[i].m_dblPrice) * dblNum, 4);
                }
                //合计金额
                m_arrObjItem[i].m_dblMoney = m_arrObjItem[i].m_dblPrice * dblNum;
                //续用类型 {-1=非用法收费（药品收费等）;0=不续用;1=全部续用;2-长嘱续用}
                if (!row["CONTINUEUSETYPE_INT"].ToString().Trim().Equals(""))
                {
                    m_arrObjItem[i].m_intCONTINUEUSETYPE_INT = int.Parse(row["CONTINUEUSETYPE_INT"].ToString().Trim());
                }

                //是否连续性医嘱	{0=否；1=是} 连续性医嘱不提示药品费用信息；
                // m_arrObjItem[i].m_intIsContinueOrder = (blnIsConOrder) ? (1) : (0);
                //是否缺药
                // m_arrObjItem[i].m_strNoqtyFLag = objMedicineItemArr[i1].m_strNoqtyFLag;
                // 加上科室名称
                m_arrObjItem[i].m_strClacarea_chr = clsConverter.ToString(row["CLACAREA_CHR"]).Trim();
                m_arrObjItem[i].m_strClacareaName_chr = clsConverter.ToString(row["deptname_vchr"]).Trim();
                //暂存住院诊疗项目收费项目执行客户表的流水号
                m_arrObjItem[i].m_strSeq_int = clsConverter.ToString(row["SEQ_INT"]).Trim(); ;
                m_arrObjItem[i].m_strYBClass = clsConverter.ToString(row["INSURACEDESC_VCHR"]).Trim();
                m_arrObjItem[i].m_strSPEC_VCHR = clsConverter.ToString(row["ITEMSPEC_VCHR"]).Trim();
                m_arrObjItem[i].m_strUNIT_VCHR = clsConverter.ToString(row["UNIT_VCHR"]).Trim();
                //收费项来源于 0-主诊疗项目，1-诊疗项目,2－带出的用法，3－自定义新开
                if (!row["FLAG_INT"].ToString().Trim().Equals(""))
                    m_arrObjItem[i].m_intType = clsConverter.ToInt(row["FLAG_INT"].ToString().Trim());
                // 住院诊疗项目收费项目执行客户表VO
                if (!row["ITEMSRCTYPE_INT"].ToString().Trim().Equals(""))
                {
                    m_arrObjItem[i].m_intITEMSRCTYPE_INT = int.Parse(row["ITEMSRCTYPE_INT"].ToString().Trim());
                }
                if (!row["IPNOQTYFLAG_INT"].ToString().Trim().Equals(""))//中心药房缺药标志 0-有药 1－缺药
                {
                    m_arrObjItem[i].m_intIPNOQTYFLAG_INT = int.Parse(row["IPNOQTYFLAG_INT"].ToString().Trim());
                }
            }
            #region 附加的信息 摆药处理 存在开关时
            if (this.m_objViewer.m_blPutMedicineFormDic == false)
            {
                for (int i = 0; i < m_arrObjItem.Length; i++)
                {
                    //一对多的诊疗项，主项目需要摆药，附加项目不摆药
                    if (m_arrObjItem[i].m_objORDERCHARGEDEPT_VO.m_intFLAG_INT == 1)//存在诊疗项目带出的收费项目时，不摆药，病区自备了，一对多的诊疗项目
                    {
                        for (int j = 0; j < m_arrObjItem.Length; j++)
                        {
                            if (m_arrObjItem[j].m_objORDERCHARGEDEPT_VO.m_intFLAG_INT == 1)
                            {
                                m_arrObjItem[j].m_objORDERCHARGEDEPT_VO.m_intPOFLAG_INT = 0;
                            }
                        }
                        return;
                    }
                }
            }
            #endregion

        }
        #endregion

        // 添加护士执行检验医嘱后发送检验单到检验采集界面
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

        internal bool UpdateBihOrderConfirmer()
        {
            string m_strORDERID_Arr = "";
            System.Collections.Generic.List<string> p_glstAllPhysicianOrderID = GetTheSelectArrItem();//把所有可能需要执行的医嘱根据选中的病人和这些病人的医嘱状态，筛选出来
            if (p_glstAllPhysicianOrderID.Count <= 0)
            {
                MessageBox.Show("请先选择医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }
            //原来的代码
            string[] m_arrCanNoOrder = null;
            System.Collections.Generic.List<string> p_glstNonExcutablePhysicianOrderID = null;
            string[] m_arrORDERID = p_glstAllPhysicianOrderID.ToArray();

            bool blnOK_To_Execute_PhysicianOrder = ConfirmCurrentOrder(m_arrORDERID, out m_arrCanNoOrder);
            if (blnOK_To_Execute_PhysicianOrder == false)//有医嘱状态改变
            {
                MessageBox.Show("当前待执行医嘱状态已变化,再确定后再尝试!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DelTheOrderFromDTView(m_arrCanNoOrder);
                m_mthRefreshSameReqNoColor();
                return false;
            }
            if (m_blExeConfirm == true)//执行是否需要审核，确认执行人是否有权限
            {
                string doctid = "";
                if (clsPublic.m_dlgConfirm(out doctid) == DialogResult.Yes)
                {

                }
                else
                {
                    return false;
                }
            }
            else
            {

            }
            #region 生成检查申请单并生成医嘱执行预约表记录(检查申请单)
            // 生成检查申请单
            System.Collections.Generic.List<clsCommitOrder> p_glstCommitPhysicianOrderList = null;
            System.Collections.Generic.List<clsExecOrderVO> p_glstExecOrderVO_List = null;
            p_glstCommitPhysicianOrderList = GetTheSelectExecOrderArrItem(ref p_glstExecOrderVO_List);

            this.objFrmExecuteOrdersProgress.lblExecuteOrderNote.Text = "正在检查欠费情况。。。。。。";
            this.objFrmExecuteOrdersProgress.Refresh();

            // 欠费提示
            if (this.m_objViewer.m_blCanSelectOrder == true && this.m_objViewer.m_blLessExecuteAlert == true)
            {
                p_glstExecOrderVO_List = LessMoneyControl(p_glstExecOrderVO_List);
            }
            if (p_glstExecOrderVO_List.Count <= 0)
            {
                return false;
            }

            #region 检查药品库存量并对库存不足药品给出提示
            Application.DoEvents();

            this.objFrmExecuteOrdersProgress.lblExecuteOrderNote.Text = "正在检查药品库存。。。。。。";
            this.objFrmExecuteOrdersProgress.Refresh();

            p_glstExecOrderVO_List = CheckMedicineKC(ref p_glstExecOrderVO_List);
            if (p_glstExecOrderVO_List == null || p_glstExecOrderVO_List.Count <= 0)
            {
                return false;
            }
            #endregion

            // 饮食，等级护理的同步处理
            this.objFrmExecuteOrdersProgress.lblExecuteOrderNote.Text = "正在处理病人护理和饮食。。。。。。";
            this.objFrmExecuteOrdersProgress.Refresh();

            ArrayList m_arrNurseVO = new ArrayList(); // 等级护理级别/饮食护理
            // 更新病人费用护理标志
            ArrayList m_arrNurOrders = new ArrayList();
            int intCommitPhysicianOrderListCount = p_glstCommitPhysicianOrderList.Count;
            clsCommitOrder objOneCommitPhysicianOrder = null;

            for (int i = 0; i < intCommitPhysicianOrderListCount; i++)
            {
                objOneCommitPhysicianOrder = p_glstCommitPhysicianOrderList[i];
                //等级护理单
                if (objOneCommitPhysicianOrder.m_strOrderDicCateID.Trim().Equals(m_objSpecateVo.m_strNURSECATE.Trim()))
                {
                    clsPatientNurseVO m_objCare = GetThePatientNurseVO(objOneCommitPhysicianOrder);
                    m_objCare.m_intTYPE_INT = 1;
                    m_objCare.m_strORDERID_CHR = objOneCommitPhysicianOrder.m_strOrderID;
                    switch (m_objCare.m_strOrderDicName)
                    {
                        case "普通护理":
                            m_objCare.m_intNURSING_CLASS = -1;
                            break;
                        case "特级护理":
                            m_objCare.m_intNURSING_CLASS = 0;
                            break;
                        case "一级护理":
                            m_objCare.m_intNURSING_CLASS = 1;
                            break;
                        case "二级护理":
                            m_objCare.m_intNURSING_CLASS = 2;
                            break;
                        case "三级护理":
                            m_objCare.m_intNURSING_CLASS = 3;
                            break;
                        case "I级护理":
                            m_objCare.m_intNURSING_CLASS = 1;
                            break;
                        case "II级护理":
                            m_objCare.m_intNURSING_CLASS = 2;
                            break;
                        case "III级护理":
                            m_objCare.m_intNURSING_CLASS = 3;
                            break;
                        default:
                            m_objCare.m_intNURSING_CLASS = -1;
                            break;
                    }
                    m_arrNurseVO.Add(m_objCare);
                    m_arrNurOrders.Add(objOneCommitPhysicianOrder.m_strOrderID);
                }

                //饮食护理单
                if (objOneCommitPhysicianOrder.m_strOrderDicCateID.Trim().Equals(m_objSpecateVo.m_strEATDICCATE.Trim()))
                {
                    clsPatientNurseVO m_objEat = GetThePatientNurseVO(objOneCommitPhysicianOrder);
                    m_objEat.m_strORDERID_CHR = objOneCommitPhysicianOrder.m_strOrderID;
                    m_objEat.m_intTYPE_INT = 2;
                    m_arrNurseVO.Add(m_objEat);
                }
            }
            //更新病人费用护理标志
            //原来的正确代码 SetTheNurseCharge(m_arrNurOrders, m_arrExecOrder);
            //特别关注此新代码,确保能够更新m_glstExecOrderList
            SetTheNurseCharge(m_arrNurOrders, p_glstExecOrderVO_List);
            /*<=======================================*/
            //为每个病人每种两种护理设置一种为有效,其它为无效
            string m_strRegisterid = "";
            //记录最后的等级护理
            Hashtable m_htActive_int = new Hashtable();
            ArrayList m_ArrRegisterid = new ArrayList();
            for (int i = 0; i < m_arrNurseVO.Count; i++)//等级护理单
            {
                if (((clsPatientNurseVO)m_arrNurseVO[i]).m_intTYPE_INT == 1)//类型 1-护理等级 2-饮食状态
                {
                    m_strRegisterid = ((clsPatientNurseVO)m_arrNurseVO[i]).m_strREGISTERID_CHR;
                    ((clsPatientNurseVO)m_arrNurseVO[i]).m_intACTIVE_INT = 0;// 生效状态 0-无效 1-有效
                    if (m_htActive_int.Contains(m_strRegisterid))
                    {
                        m_htActive_int[m_strRegisterid] = (clsPatientNurseVO)m_arrNurseVO[i];//把最新的护理项目存入m_htActive_int
                    }
                    else
                    {
                        m_htActive_int.Add(m_strRegisterid, (clsPatientNurseVO)m_arrNurseVO[i]);
                    }
                    if (!m_ArrRegisterid.Contains(m_strRegisterid))
                    {
                        m_ArrRegisterid.Add(m_strRegisterid);
                    }
                }
            }
            //最后的等级护理进行更新为有效
            for (int i = 0; i < m_ArrRegisterid.Count; i++)
            {
                if (m_htActive_int.Contains(m_ArrRegisterid[i].ToString()))
                {
                    ((clsPatientNurseVO)m_htActive_int[m_ArrRegisterid[i].ToString()]).m_intACTIVE_INT = 1;//把最新的护理项目
                }
            }
            /*<=========================*/
            for (int i = 0; i < m_arrNurseVO.Count; i++)//饮食护理单
            {
                if (((clsPatientNurseVO)m_arrNurseVO[i]).m_intTYPE_INT == 2)//类型 1-护理等级 2-饮食状态
                {
                    m_strRegisterid = ((clsPatientNurseVO)m_arrNurseVO[i]).m_strREGISTERID_CHR;
                    ((clsPatientNurseVO)m_arrNurseVO[i]).m_intACTIVE_INT = 1;
                    for (int j = i + 1; j < m_arrNurseVO.Count; j++)
                    {
                        if (((clsPatientNurseVO)m_arrNurseVO[j]).m_intTYPE_INT == 2)
                        {
                            if (m_strRegisterid.Equals(((clsPatientNurseVO)m_arrNurseVO[j]).m_strREGISTERID_CHR))
                            {
                                ((clsPatientNurseVO)m_arrNurseVO[i]).m_intACTIVE_INT = 0;
                                ((clsPatientNurseVO)m_arrNurseVO[j]).m_intACTIVE_INT = 1;
                            }
                        }
                    }
                }
            }
            #endregion

            this.objFrmExecuteOrdersProgress.lblPatient_Lbl.Visible = false;
            this.objFrmExecuteOrdersProgress.lblPatientName.Visible = false;
            this.objFrmExecuteOrdersProgress.lblPhysicianOrder_Lbl.Visible = false;
            this.objFrmExecuteOrdersProgress.lblPhysicianOrder.Visible = false;
            this.objFrmExecuteOrdersProgress.lblOrderCount.Visible = false;
            this.objFrmExecuteOrdersProgress.lblOrderNum.Visible = false;
            this.objFrmExecuteOrdersProgress.lblOrderSuffix.Visible = false;
            this.objFrmExecuteOrdersProgress.lblExecuteOrderNote.Visible = true;

            #region 检查疗程用药.自动确认
            List<string> lstOrderId = new List<string>();
            List<EntityCureMed> lstCureMed = null;
            List<EntityCureSubStock> lstSubStock = null;
            foreach (clsExecOrderVO item in p_glstExecOrderVO_List)
            {
                if (item.CureDays > 0 && (item.CheckState == 0 || item.CheckState == -9))
                {
                    if (lstOrderId.IndexOf(item.ORDERID_CHR) < 0) lstOrderId.Add(item.ORDERID_CHR);
                }
            }
            if (lstOrderId.Count > 0)
            {
                Application.DoEvents();
                this.objFrmExecuteOrdersProgress.lblExecuteOrderNote.Text = "正在检测疗程用药。。。。。。";
                this.objFrmExecuteOrdersProgress.Refresh();

                string orderIdArr = string.Empty;
                foreach (string orderid in lstOrderId)
                {
                    orderIdArr += "'" + orderid + "',";
                }
                orderIdArr = orderIdArr.TrimEnd(',');
                using (clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject())
                {
                    lstCureMed = svc.GetCureMed2(orderIdArr);
                    if (lstCureMed != null && lstCureMed.Count > 0)
                    {
                        if (this.CheckCureMed(ref lstCureMed, out lstSubStock) == false)
                        {
                            return false;
                        }
                    }
                }
            }

            #endregion

            Application.DoEvents();
            this.objFrmExecuteOrdersProgress.lblExecuteOrderNote.Text = "正在更新数据库。。。。。。";
            this.objFrmExecuteOrdersProgress.Refresh();

            try
            {
                string error = string.Empty;
                List<clsT_Bih_Opr_Putmeddetail_VO> lstPutMedCfkl = new List<clsT_Bih_Opr_Putmeddetail_VO>();
                long lngRes = m_objManage.m_lngUpdateBihOrderExecConfirmer(p_glstExecOrderVO_List, m_arrNurseVO, lstCureMed, lstSubStock, out lstPutMedCfkl, out error);
                if (error != string.Empty)
                {
                    MessageBox.Show(error, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (lstPutMedCfkl != null && lstPutMedCfkl.Count > 0)
                {
                    #region 中药房.配方颗粒.机器

                    string putMedIds = string.Empty;
                    foreach (clsT_Bih_Opr_Putmeddetail_VO item in lstPutMedCfkl)
                    {
                        putMedIds += "'" + item.m_strPUTMEDDETAILID_CHR + "',";
                    }
                    string xmlIn = string.Empty;
                    xmlIn += "<req>" + Environment.NewLine;
                    xmlIn += string.Format("<recipeId>{0}</recipeId>", "") + Environment.NewLine;
                    xmlIn += string.Format("<putMedId>{0}</putMedId>", putMedIds.TrimEnd(',')) + Environment.NewLine;
                    xmlIn += string.Format("<opIp>{0}</opIp>", "2") + Environment.NewLine;
                    xmlIn += "</req>" + Environment.NewLine;
                    try
                    {
                        using (MedService ms = new MedService())
                        {
                            string outXml = ms.FireBird(xmlIn);
                            //Log.Output(outXml);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Output(ex.Message);
                    }
                    #endregion
                }
            }
            catch
            {
                MessageBox.Show("不能对同一医嘱多人同时进行执行操作!请刷新后再操作", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            // 上面才刚刚执行完,没有必要马上又在执行吧?怀疑是后面加上去的,没有重复检查代码逻辑
            m_arrCanNoOrder = null;
            blnOK_To_Execute_PhysicianOrder = ConfirmCurrentOrder(m_arrORDERID, out m_arrCanNoOrder);
            p_glstNonExcutablePhysicianOrderID = new List<string>();
            for (int k = 0; k < m_arrCanNoOrder.Length; k++)
            {
                p_glstNonExcutablePhysicianOrderID.Add(m_arrCanNoOrder[k].ToString());
            }
            ArrayList SendCheckArr2 = new ArrayList();

            if (blnOK_To_Execute_PhysicianOrder == false)
            {
                #region 发送检查申请单，及预约单
                Application.DoEvents();
                this.objFrmExecuteOrdersProgress.lblExecuteOrderNote.Text = "正在处理检查、检验申请单及预约单。。。。。。";
                this.objFrmExecuteOrdersProgress.Refresh();

                Dictionary<string, List<clsCommitOrder>> gdctTestApply = new Dictionary<string, List<clsCommitOrder>>();
                List<string> arrRegID = new List<string>();//检查
                List<string> arrCheckRegID = new List<string>();//检验

                for (int i = 0; i < intCommitPhysicianOrderListCount; i++)
                {
                    objOneCommitPhysicianOrder = p_glstCommitPhysicianOrderList[i];
                    if (!objOneCommitPhysicianOrder.m_strAPPLYTYPEID_CHR.Trim().Equals("") && p_glstNonExcutablePhysicianOrderID.Contains(objOneCommitPhysicianOrder.m_strOrderID))
                    {
                        if (!arrRegID.Contains(objOneCommitPhysicianOrder.m_strRegisterID))
                        {
                            arrRegID.Add(objOneCommitPhysicianOrder.m_strRegisterID);
                            gdctTestApply.Add(objOneCommitPhysicianOrder.m_strRegisterID, new List<clsCommitOrder>());
                            gdctTestApply[objOneCommitPhysicianOrder.m_strRegisterID].Add(objOneCommitPhysicianOrder);
                        }
                        else
                        {
                            gdctTestApply[objOneCommitPhysicianOrder.m_strRegisterID].Add(objOneCommitPhysicianOrder);
                        }
                    }
                }

                if (gdctTestApply.Count > 0)
                {
                    com.digitalwave.iCare.ValueObject.clsOrderBooking[] m_arrOrderBooking;
                    clsATTACHRELATION_VO[] m_arATTACHRELATION;
                    if (m_mthSendCheckApplyBill(gdctTestApply, out m_arrOrderBooking, out m_arATTACHRELATION))
                    {
                        m_objManage.m_lngUpdateOrderBookingArr(m_arrOrderBooking);
                        m_objManage.m_lngUpdateOrderAttachRelation(m_arATTACHRELATION);
                    }
                    else
                    {
                        MessageBox.Show("检查发送失败。", "提示");
                        return false;
                    }
                }
                #endregion

                #region 发送检验申请单
                if (m_objViewer.m_blSendLisBill == false)
                {
                    Application.DoEvents();
                    this.objFrmExecuteOrdersProgress.lblExecuteOrderNote.Text = "正在处理检查、检验申请单及预约单。。。。。。";
                    this.objFrmExecuteOrdersProgress.Refresh();

                    Dictionary<string, List<clsCommitOrder>> gdctCheckApply = new Dictionary<string, List<clsCommitOrder>>();
                    for (int i = 0; i < intCommitPhysicianOrderListCount; i++)
                    {
                        objOneCommitPhysicianOrder = p_glstCommitPhysicianOrderList[i];
                        if (!objOneCommitPhysicianOrder.m_strLISAPPLYUNITID_CHR.Trim().Equals("") && p_glstNonExcutablePhysicianOrderID.Contains(objOneCommitPhysicianOrder.m_strOrderID))
                        {
                            if (!arrCheckRegID.Contains(objOneCommitPhysicianOrder.m_strRegisterID))
                            {
                                arrCheckRegID.Add(objOneCommitPhysicianOrder.m_strRegisterID);
                                gdctCheckApply.Add(objOneCommitPhysicianOrder.m_strRegisterID, new List<clsCommitOrder>());
                                gdctCheckApply[objOneCommitPhysicianOrder.m_strRegisterID].Add(objOneCommitPhysicianOrder);
                            }
                            else
                            {
                                gdctCheckApply[objOneCommitPhysicianOrder.m_strRegisterID].Add(objOneCommitPhysicianOrder);
                            }
                        }
                    }

                    // 检验 
                    if (gdctCheckApply.Count > 0)
                    {
                        List<string> arrLisError = null;
                        List<string> objListAll = new List<string>();
                        foreach (string strKey in gdctCheckApply.Keys)
                        {
                            List<clsCommitOrder> objLis = gdctCheckApply[strKey];
                            arrLisError = new List<string>();
                            for (int intJ = 0; intJ < objLis.Count; intJ++)
                            {
                                clsCommitOrder objCommitOrderVO = objLis[intJ];
                                //不是检验或者未执行成功  
                                if (!p_glstNonExcutablePhysicianOrderID.Contains(objCommitOrderVO.m_strOrderID) || objCommitOrderVO.m_strOrderDicCateID != this.m_objSpecateVo.m_strORDERCATEID_LIS_CHR)
                                {
                                    objLis.Remove(objCommitOrderVO);
                                    intJ--;
                                }
                                else
                                {
                                    arrLisError.Add(objCommitOrderVO.m_strOrderID);//没有发送成功的
                                }
                            }
                            arrLisError = new List<string>();
                            //为医嘱设置单价，合计金额等
                            this.SetThePrice(ref objLis);
                            this.sendTheCheck(ref objLis, ref arrLisError);//传入时arrLisError保存所有医嘱ID，传出时保存没有发送成功的申请单的医嘱ID
                            objListAll.AddRange(arrLisError);
                            arrLisError = null;
                        }

                        if (objListAll.Count > 0)
                        {
                            string strMessage = "";
                            foreach (clsCommitOrder order in p_glstCommitPhysicianOrderList)
                            {
                                if (objListAll.Contains(order.m_strOrderID))
                                {
                                    strMessage += order.m_strName + "\r\n";
                                }
                            }
                            strMessage += "以上医嘱发送检验申请单失败。";
                            MessageBox.Show(this.m_objViewer, strMessage, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                #endregion

                DelTheOrderFromDTView(m_arrCanNoOrder);
                m_mthRefreshSameReqNoColor();
                refreshThePatientCharge();
            }
            return true;
        }
        /// <summary>
        /// 检验申请
        /// </summary>
        public bool sendTheCheck(ref List<clsCommitOrder> SendCheckArr, ref List<string> m_arrLisOrders)
        {
            clsBIHLis obj = new clsBIHLis();
            //frmLisAppl obj = new frmLisAppl();
            m_arrLisOrders = new List<string>();
            //m_arrLisOrders = new ArrayList();
            clsLisApplMainVO objLMVO;
            clsTestApplyItme_VO[] itemArr_VO;
            // List<string> personArr;

            //为每一病人生成一条检验申请单
            //int intPersonCount = personArr.Count;

            //for(int i = 0; i < intPersonCount; i++)
            //{
            List<clsCommitOrder> commitArr = SendCheckArr;
            //for(int k = 0; k < SendCheckArr.Count; k++)
            //{
            //    if(SendCheckArr[k].m_strPatientID == personArr[i])
            //    {
            //        commitArr.Add(SendCheckArr[k]);
            //    }
            //}
            //if(commitArr.Count <= 0)
            //{
            //    continue;
            //}

            //clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();

            long m_lngRef = this.m_mthSendTestApplyBillByCommit(commitArr, out objLMVO, out itemArr_VO);
            //m_objService.Dispose();
            //m_objService = null;


            if (m_lngRef <= 0)
            {
                return false;
            }
            if (obj.m_mthNewApp(objLMVO, itemArr_VO, true))
            {
                clsLISAppResults[] objAppResult = obj.m_objGetMutiResults();
                string strOrderID = string.Empty;

                if (objAppResult != null)
                {
                    int intResultLen = objAppResult.Length;
                    int intOrderLen = 0;
                    for (int i2 = 0; i2 < intResultLen; i2++)
                    {
                        if (objAppResult[i2].m_arrOrderId != null && objAppResult[i2].m_arrOrderId.Length > 0)
                        {
                            intOrderLen = objAppResult[i2].m_arrOrderId.Length;
                            for (int j = 0; j < intOrderLen; j++)
                            {
                                strOrderID = objAppResult[i2].m_arrOrderId[j];

                                if (m_arrLisOrders.Contains(strOrderID))//已发送成功，可以清除掉
                                {
                                    m_arrLisOrders.Remove(strOrderID);
                                }
                            }
                        }
                    }
                }

                if (objAppResult.Length > 0)
                {
                    //foreach (string strKey in obj.M_dicLISKeyValue.Keys)
                    //{
                    //    m_objOrderIDDefApplyID.Add(strKey, obj.M_dicLISKeyValue[strKey].ToString());
                    //}
                    //objOrder.m_strLISAPPID_VCHR = objAppResult[0].m_StrApplicationID.ToString().Trim();
                    //objOrder.m_strSAMPLEID_VCHR = m_strSampleid;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;

            }
            //  }
            return true;

        }
        //2010/8/26
        internal void SetThePrice(ref List<clsCommitOrder> SendCheckArr)
        {
            ArrayList m_strOrderIds = new ArrayList();
            Hashtable m_htOrders = new Hashtable();
            for (int i = 0; i < SendCheckArr.Count; i++)
            {
                clsCommitOrder order = (clsCommitOrder)SendCheckArr[i];
                if (!m_strOrderIds.Contains(order.m_strOrderID))
                {
                    m_strOrderIds.Add(order.m_strOrderID);

                }
                if (!m_htOrders.Contains(order.m_strOrderID))
                {
                    m_htOrders.Add(order.m_strOrderID, order);
                }
                //order.m_decTotalPrice
            }
            if (m_strOrderIds.Count <= 0)
            {
                return;
            }
            string[] m_arrOrders = (string[])m_strOrderIds.ToArray(typeof(string));
            DataTable m_dtOrderSign = null;
            m_objManage.m_lngGetOrderLisSign(m_arrOrders, out  m_dtOrderSign);
            if (m_dtOrderSign != null && m_dtOrderSign.Rows.Count > 0)
            {
                string m_strOrderID = "", m_OrderID = "";
                int m_intDisCount = 0;
                string InvCateID = "";//费用发票类别id
                decimal AMOUNT_DEC = 0, UNITPRICE_DEC = 0, m_dmlGet = 0, m_dmlPrice = 0;
                decimal m_decTotalPrice = 0;
                for (int i = 0; i < m_strOrderIds.Count; i++)
                {
                    m_dmlGet = 0;
                    m_dmlPrice = 0;
                    m_intDisCount = 0;
                    m_decTotalPrice = 0;
                    m_strOrderID = (string)m_strOrderIds[i];
                    //frmBIHOrderCommit objBIHOrderCommit = new frmBIHOrderCommit();//2010/8/26
                    for (int j = 0; j < m_dtOrderSign.Rows.Count; j++)
                    {

                        m_OrderID = m_dtOrderSign.Rows[j]["orderid_chr"].ToString();
                        if (!m_strOrderID.Equals(m_OrderID))
                        {
                            continue;
                        }
                        InvCateID = m_dtOrderSign.Rows[j]["ItemIpInvType_Chr"].ToString();
                        decimal.TryParse(m_dtOrderSign.Rows[j]["AMOUNT_DEC"].ToString(), out AMOUNT_DEC);
                        decimal.TryParse(m_dtOrderSign.Rows[j]["UNITPRICE_DEC"].ToString(), out UNITPRICE_DEC);
                        if (m_dtOrderSign.Rows[j]["FLAG_INT"].ToString().Trim().Equals("0"))//主收费项目
                        {
                            m_dmlGet = AMOUNT_DEC;
                            m_dmlPrice = UNITPRICE_DEC;
                        }
                        m_decTotalPrice += AMOUNT_DEC * UNITPRICE_DEC;

                        if (this.m_objViewer.m_blLisDiscount == true && m_strLisPARMVALUE_VCHR.Contains(InvCateID) && !InvCateID.Equals(""))
                        {
                            m_intDisCount++;
                        }
                    }
                    //检验打折的逻辑
                    clsCommitOrder order = (clsCommitOrder)m_htOrders[m_strOrderID];
                    order.m_decTotalPrice = m_decTotalPrice;
                    order.m_dmlGet = m_dmlGet;
                    order.m_dmlPrice = m_dmlPrice;
                    if (m_intDisCount > this.m_objViewer.m_decLisDiscountMount)
                    {
                        order.m_decDiscount = this.m_objViewer.m_decLisDiscountMount;
                    }
                    else
                    {
                        order.m_decDiscount = 100;
                    }
                }
            }
        }
        /// <summary>
        /// 检验申请单参数填充 
        /// </summary>
        /// <param name="CommitArr"></param>
        /// <param name="objLMVO"></param>
        /// <param name="itemArr_VO"></param>
        /// <returns></returns>
        private long m_mthSendTestApplyBillByCommit(List<clsCommitOrder> CommitArr, out clsLisApplMainVO objLMVO, out clsTestApplyItme_VO[] itemArr_VO)
        {
            List<clsTestApplyItme_VO> objTemp = new List<clsTestApplyItme_VO>();
            objLMVO = new clsLisApplMainVO();
            itemArr_VO = null;
            clsCommitOrder[] p_objCommitOrder = CommitArr.ToArray();
            int intLen = p_objCommitOrder.Length;
            clsTestApplyItme_VO item_VO = null;
            DataTable dt = null;
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            for (int i = 0; i < intLen; i++)
            {
                #region 接口数据
                item_VO = new clsTestApplyItme_VO();
                item_VO.m_decPrice = p_objCommitOrder[i].m_dmlPrice;
                item_VO.m_decQty = p_objCommitOrder[i].m_dmlGet;
                item_VO.m_decTolPrice = p_objCommitOrder[i].m_decTotalPrice;
                // 根据诊疗项目关联申请单元Id
                item_VO.m_strItemID = p_objCommitOrder[i].m_strLISAPPLYUNITID_CHR;
                item_VO.m_strUsageID = p_objCommitOrder[i].m_strSAMPLEID_VCHR;
                item_VO.m_strItemName = p_objCommitOrder[i].m_strName;
                item_VO.m_strSpec = p_objCommitOrder[i].m_strSpec;
                item_VO.m_strSampleId = p_objCommitOrder[i].m_strSAMPLEID_VCHR;
                item_VO.m_strUnit = p_objCommitOrder[i].m_strUseunit;
                item_VO.m_strOutpatRecipeID = "";
                item_VO.m_strRowNo = i.ToString();
                item_VO.m_strOprDeptID = "";
                item_VO.strPartID = "";
                item_VO.m_strOutpatRecipeDeID = p_objCommitOrder[i].m_strChargeITEMID_CHR;//这里借用保存项目ID
                item_VO.m_strOrderID = p_objCommitOrder[i].m_strOrderID;
                item_VO.m_decDiscount = p_objCommitOrder[i].m_decDiscount;
                objTemp.Add(item_VO);
                #endregion
            }
            if (objTemp.Count <= 0)
            {
                objTemp.Add(new clsTestApplyItme_VO());
            }
            itemArr_VO = objTemp.ToArray();

            #region 收费病人基本数据

            if (p_objCommitOrder.Length <= 0)
            {
                return -1;
            }
            //给VO附病人数据
            objLMVO.m_intEmergency = 0;
            objLMVO.m_intForm_int = 0;
            objLMVO.m_strAge = p_objCommitOrder[0].m_strAge + " 岁";

            if (p_objCommitOrder[0].m_intSOURCETYPE_INT == 1)
            {
                objLMVO.m_strAppl_DeptID = p_objCommitOrder[0].m_strCREATEAREA_ID;
            }
            else
            {
                objLMVO.m_strAppl_DeptID = p_objCommitOrder[0].m_strCURAREAID_CHR;
            }
            string strEmployeeID = p_objCommitOrder[0].m_strCreatorID;
            objLMVO.m_strAppl_EmpID = p_objCommitOrder[0].m_strCreatorID;
            objLMVO.m_strDiagnose = p_objCommitOrder[0].m_strDIAGNOSE_VCHR;
            objLMVO.m_strOperator_ID = strEmployeeID;
            objLMVO.m_strPatient_Name = p_objCommitOrder[0].m_strPatientName;
            objLMVO.m_strPatientID = p_objCommitOrder[0].m_strPatientID;
            objLMVO.m_strPatientType = "1";
            objLMVO.m_strSex = p_objCommitOrder[0].m_strsex_chr;
            //急诊标志
            objLMVO.m_intEmergency = 0;
            //收费状态
            objLMVO.m_intChargeState = 1;
            //住院号
            objLMVO.m_strPatient_inhospitalno_chr = p_objCommitOrder[0].m_strINPATIENTID_CHR;
            //床号
            objLMVO.m_strBedNO = p_objCommitOrder[0].m_strBedName;
            //当时病人所在的病区(借用的字段)
            //objLMVO.m_strSummary = p_objCommitOrder[0].m_strCURAREAID_CHR;

            objLMVO.m_strOrderunitrelation = p_objCommitOrder[0].m_strOrderID;
            #endregion

            #region 新收费病人基本数据
            //if (p_objCommitOrder.Length <= 0)
            //{
            //    return -1;
            //}

            //objLMVO.m_strInPatientID = p_objCommitOrder[0].m_strINPATIENTID_CHR;//住院号
            //objLMVO.m_strPatientCardID = p_objCommitOrder[0].m_strINPATIENTID_CHR;//住院号


            //objLMVO.m_enuPatientType = com.digitalwave.iCare.ValueObject.LIS.LisPatientType.Inpatient;
            //objLMVO.m_strRegisterID = p_objCommitOrder[0].m_strRegisterID;//登记号
            //objLMVO.m_strPatientName = p_objCommitOrder[0].m_strPatientName;//病人姓名
            //objLMVO.m_strSex = p_objCommitOrder[0].m_strsex_chr;//性别
            //objLMVO.m_strBirthDate = p_objCommitOrder[0].m_dtmBirthDay.ToString("yyyy-MM-dd HH:mm:ss");
            //objLMVO.m_strAgeReferenceDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //objLMVO.m_strAppDoctorID = p_objCommitOrder[0].m_strCreatorID;//申请医生
            //if (p_objCommitOrder[0].m_intSOURCETYPE_INT == 1)//申请科室
            //{
            //    objLMVO.m_strAppDeptID = p_objCommitOrder[0].m_strCREATEAREA_ID;
            //}
            //else
            //{
            //    objLMVO.m_strAppDeptID = p_objCommitOrder[0].m_strCURAREAID_CHR;
            //}
            ////申请日期
            //objLMVO.m_strAppDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //objLMVO.m_strPATIENTID = p_objCommitOrder[0].m_strPatientID;//病人编号
            //objLMVO.m_strOperatorID = p_objCommitOrder[0].m_strCreatorID;//操作者


            #endregion
            if (itemArr_VO.Length > 0)
            {
                objLMVO.m_strSampleTypeID = p_objCommitOrder[0].m_strSAMPLEID_VCHR;//加入获取样本类型代码
            }
            else
            {
                return 0;
            }


            return 1;
        }

        #region 检验相关

        /// <summary>
        /// 将从数组中提交病人列表 2010/8/23
        /// </summary>
        /// <param name="SendCheckArr"></param>
        /// <param name="p_dtResultArr"></param>
        private void m_getPersonGroupList(List<clsCommitOrder> SendCheckArr, out List<string> personArr)
        {
            int intSendCount = SendCheckArr.Count;
            personArr = new List<string>(intSendCount);

            for (int i = 0; i < intSendCount; i++)
            {
                string m_strperID = SendCheckArr[i].m_strPatientID.ToString().Trim();
                if (!personArr.Contains(m_strperID))
                {
                    personArr.Add(m_strperID);
                }
            }
            personArr.TrimExcess();
        }
        #endregion

        #region 检查药品库存量 -- 医嘱执行关键方法20180403
        /// <summary>
        /// 检查药品库存量 -- 医嘱执行关键方法20180403
        /// </summary>
        /// <param name="p_lstExecOrderList"></param>
        /// <returns></returns>
        List<clsExecOrderVO> CheckMedicineKC(ref List<clsExecOrderVO> p_lstExecOrderList)
        {
            int intLstCount = p_lstExecOrderList.Count;
            List<clsExecOrderVO> lstExecOrderResult = new List<clsExecOrderVO>(intLstCount);
            //药品ID <药房ID,<药品ID>>
            Dictionary<string, List<string>> dicMedicineID = new Dictionary<string, List<string>>();
            List<string> lstMedicineID = null;              // dtnMedicineID中的value
            Dictionary<string, double> dicKC = null;        // <药房ID*药ID，库存量>
            Dictionary<string, double> dicXYL = new Dictionary<string, double>();       // <药房ID*药ID，需用量>
            Dictionary<string, List<clsExecOrderVO>> dicYYPO = new Dictionary<string, List<clsExecOrderVO>>();  // 用药医嘱<药房ID*药ID，<用药医嘱对象>>
            clsT_Bih_Opr_Putmeddetail_VO[] objPutmedVOArr = null;
            List<clsExecOrderVO> lstExceVO = null;
            long res = -1;
            string medId = string.Empty;                    // 药品ID
            string pharmacyId = string.Empty;               // 药房ID
            string portfolioKey = string.Empty;             // 组合主键（药房ID*药品ID）
            //
            List<string> lstOrderId = new List<string>();
            Dictionary<string, decimal> dicGet = new Dictionary<string, decimal>();                 // key: 药房ID+OrderID
            Dictionary<string, decimal> dicGet2 = new Dictionary<string, decimal>();                // key: 药房ID+药品ID

            foreach (clsExecOrderVO ordervo in p_lstExecOrderList)
            {
                objPutmedVOArr = ordervo.m_arrPutmeddetail_VO;
                if (objPutmedVOArr != null)
                {
                    for (int i = 0; i < objPutmedVOArr.Length; i++)     // 找出所有需执行的药品ID
                    {
                        if (objPutmedVOArr[i].m_intMEDICNETYPE_INT == 3 && objPutmedVOArr[i].m_intPUTMEDTYPE_INT == 1)
                        {
                            continue;
                        }

                        medId = objPutmedVOArr[i].m_strMEDID_CHR;               // 药品ID
                        pharmacyId = objPutmedVOArr[i].m_strMEDSTOREID_CHR;     // 药房ID
                        portfolioKey = pharmacyId + "*" + medId;                // 中间加*以后方便拆分
                        if (!dicMedicineID.ContainsKey(pharmacyId))
                        {
                            lstMedicineID = new List<string>() { medId };
                            dicMedicineID.Add(pharmacyId, lstMedicineID);
                        }
                        else
                        {
                            if (!dicMedicineID[pharmacyId].Contains(medId))
                            {
                                dicMedicineID[pharmacyId].Add(medId);
                            }
                        }

                        // 处理用药医嘱
                        if (!dicYYPO.ContainsKey(portfolioKey))
                        {
                            lstExceVO = new List<clsExecOrderVO>();
                            lstExceVO.Add(ordervo);
                            dicYYPO.Add(portfolioKey, lstExceVO);
                        }
                        else
                        {
                            lstExceVO = dicYYPO[portfolioKey];
                            if (!lstExceVO.Contains(ordervo))
                            {
                                dicYYPO[portfolioKey].Add(ordervo);
                            }
                        }
                        // 预发药处理 20180320
                        objPutmedVOArr[i].PretestDays = ordervo.PretestDays;
                        objPutmedVOArr[i].m_dblGET_DEC = objPutmedVOArr[i].m_dblGET_DEC * (ordervo.PretestDays == 0 ? 1 : ordervo.PretestDays + 1); // 领量 = 领量 * (预发天数+1)

                        // 处理药品需用量
                        if (!dicXYL.ContainsKey(portfolioKey))
                        {
                            dicXYL.Add(portfolioKey, objPutmedVOArr[i].m_dblGET_DEC);
                        }
                        else
                        {
                            dicXYL[portfolioKey] += objPutmedVOArr[i].m_dblGET_DEC;
                        }
                    }
                    // 疗程用药
                    if (!dicGet.ContainsKey(portfolioKey) && ordervo.PreAmount2 != 0)
                    {
                        dicGet.Add(portfolioKey, ordervo.PreAmount2);
                        lstOrderId.Add(ordervo.ORDERID_CHR);
                    }
                }
            }
            #region 疗程用药
            if (lstOrderId.Count > 0)
            {
                Dictionary<string, string> dicMedId = new Dictionary<string, string>();
                using (clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject())
                {
                    dicMedId = svc.GetMedIdByOrderId(lstOrderId);
                }
                foreach (string key in dicGet.Keys)
                {
                    if (dicMedId.ContainsKey(key.Split('*')[1]))
                    {
                        dicGet2.Add(key.Split('*')[0] + "*" + dicMedId[key.Split('*')[1]], dicGet[key]);
                    }
                }
                if (dicGet2.Count > 0)
                {
                    foreach (string key in dicGet2.Keys)
                    {
                        if (dicXYL.ContainsKey(key))
                        {
                            dicXYL[key] = dicXYL[key] - Convert.ToDouble(dicGet2[key]);     // 需求量 = 需求量 - 预扣量
                        }
                    }
                }
            }
            #endregion

            if (dicMedicineID.Count != 0)
            {
                res = m_objManage.m_lngGetMedicineKC(dicMedicineID, out dicKC, out m_objDsStorageVOArr);
            }
            else
            {
                return p_lstExecOrderList;      // 不含药品
            }
            if (res > 0 && dicKC != null)
            {
                #region 领量基本单位转化成最小单位
                if (m_objDsStorageVOArr != null)
                {
                    clsDsStorageVO objCurrentVO = null;
                    string strKey = string.Empty;
                    for (int i = 0; i < m_objDsStorageVOArr.Length; i++)
                    {
                        objCurrentVO = m_objDsStorageVOArr[i];
                        strKey = objCurrentVO.m_strPharmacyID + "*" + objCurrentVO.m_strMedicineID;
                        if (objCurrentVO.m_intIpChargeFlg == 0 && dicXYL.ContainsKey(strKey))       // 基本单位
                        {
                            dicXYL[strKey] = dicXYL[strKey] * objCurrentVO.m_dblPackqty;            // 最小单位＝基本单位*包装量
                        }
                    }
                }
                #endregion

                List<string> lstMedID = new List<string>();         // 记录有库存但不足全部的组合ID
                #region 过滤掉库存足的
                foreach (string strKey in dicMedicineID.Keys)
                {
                    lstMedicineID = dicMedicineID[strKey];
                    for (int i = 0; i < lstMedicineID.Count; i++)   // 必须用lstMedicineID.Count，否则有误
                    {
                        medId = lstMedicineID[i];
                        portfolioKey = strKey + "*" + medId;
                        if (dicXYL.ContainsKey(portfolioKey) && dicKC.ContainsKey(portfolioKey))
                        {
                            if (dicXYL[portfolioKey] <= dicKC[portfolioKey])    // 需用量<=库存量
                            {
                                lstMedicineID.Remove(medId);
                                i--;
                            }
                            else if (dicKC[portfolioKey] > 0)                   // 还有库存只是不足全部
                            {
                                lstMedID.Add(portfolioKey);
                            }
                        }
                    }
                }
                #endregion

                #region 将dtnMedicineID中List<>.Count==0的记录移除
                List<string> lstKeyForRemove = new List<string>(dicMedicineID.Count);
                foreach (string strKey in dicMedicineID.Keys)
                {
                    if (dicMedicineID[strKey].Count == 0)
                    {
                        lstKeyForRemove.Add(strKey);
                    }
                }
                lstKeyForRemove.TrimExcess();

                foreach (string strKey in lstKeyForRemove)
                {
                    dicMedicineID.Remove(strKey);
                }
                #endregion

                if (dicMedicineID.Count == 0)//库存都够
                {
                    lstExecOrderResult = p_lstExecOrderList;
                }
                else if (dicMedicineID.Count > 0)//有库存不足
                {
                    #region 库存不足时告知及询问
                    List<clsExecOrderVO> lstNonExcutablePO = new List<clsExecOrderVO>();//不可执行或需选择执行的医嘱
                    foreach (string strKey1 in dicMedicineID.Keys)//遍历药房ID
                    {
                        lstMedicineID = dicMedicineID[strKey1];
                        foreach (string strKey2 in lstMedicineID)//遍历药品ID
                        {
                            portfolioKey = strKey1 + "*" + strKey2;//组合ID
                            if (dicYYPO.ContainsKey(portfolioKey))
                            {
                                List<clsExecOrderVO> lstCurrent = dicYYPO[portfolioKey];
                                foreach (clsExecOrderVO objCurrentVO in lstCurrent)
                                {
                                    if (!lstNonExcutablePO.Contains(objCurrentVO))
                                    {
                                        lstNonExcutablePO.Add(objCurrentVO);
                                    }
                                }
                            }
                        }
                    }

                    #region 移除库存不足的医嘱
                    IEnumerator objEnuPO = null;
                    clsExecOrderVO objCurrentPO = null;
                    List<clsExecOrderVO> lstChooseVO = new List<clsExecOrderVO>();//需要选择是否执行的医嘱

                    string strPortfolioKey2 = string.Empty;
                    for (int i1 = 0; i1 < lstNonExcutablePO.Count; i1++)
                    {
                        objCurrentPO = lstNonExcutablePO[i1];

                        if (objCurrentPO != null)
                        {
                            foreach (clsT_Bih_Opr_Putmeddetail_VO objCurrentVO in objCurrentPO.m_arrPutmeddetail_VO)
                            {
                                strPortfolioKey2 = objCurrentVO.m_strMEDSTOREID_CHR + "*" + objCurrentVO.m_strMEDID_CHR;
                                if (lstMedID.Contains(strPortfolioKey2) && dicKC.ContainsKey(strPortfolioKey2))
                                {
                                    if (objCurrentVO.m_dblGET_DEC <= dicKC[strPortfolioKey2])//用量小于库存量
                                    {
                                        if (!lstChooseVO.Contains(objCurrentPO))
                                        {
                                            dicKC[strPortfolioKey2] = dicKC[strPortfolioKey2] - objCurrentVO.m_dblGET_DEC;//在库存量减去已选择的药量
                                            lstChooseVO.Add(objCurrentPO);
                                            lstNonExcutablePO.Remove(objCurrentPO);
                                            i1--;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //记录不能执行的医嘱的病人registerID和方号（去除同方其它基嘱）
                    List<string> m_lstNoExeRecipenNo = new List<string>();
                    int intLstnoExeCount = lstNonExcutablePO.Count;
                    for (int i2 = 0; i2 < intLstnoExeCount; i2++)
                    {
                        if (!m_lstNoExeRecipenNo.Contains(lstNonExcutablePO[i2].m_strRegisterRecipenNo))
                        {
                            m_lstNoExeRecipenNo.Add(lstNonExcutablePO[i2].m_strRegisterRecipenNo);

                        }
                    }

                    string strNoExecuOrder = "";
                    objEnuPO = p_lstExecOrderList.GetEnumerator();
                    while (objEnuPO.MoveNext())//最终移除库存不够的医嘱
                    {
                        clsExecOrderVO objCurrentOrder = objEnuPO.Current as clsExecOrderVO;

                        if (objCurrentOrder != null)
                        {
                            if (!m_lstNoExeRecipenNo.Contains(objCurrentOrder.m_strRegisterRecipenNo))
                            {
                                lstExecOrderResult.Add(objCurrentOrder);

                            }
                            else
                            {
                                //提示信息生成
                                strNoExecuOrder += objCurrentOrder.m_objPatient.m_strBedName + "床病人:" + objCurrentOrder.m_objPatient.m_strPatientName + "\n医嘱:" + objCurrentOrder.m_strOrderName + "\n";
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(strNoExecuOrder))
                    {
                        if (MessageBox.Show(strNoExecuOrder, "库存不足,不能执行", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        {
                            lstExecOrderResult.Clear();
                        }
                    }
                    #endregion

                    #endregion
                }
            }
            if (lstExecOrderResult != null)
            {
                lstExecOrderResult.TrimExcess();
            }
            return lstExecOrderResult;
        }
        #endregion

        private void refreshThePatientCharge()
        {
            //原来正确的代码 ArrayList m_arrRegisterid_chr = null;
            System.Collections.Generic.List<string> m_glstRegisterid_chr = null;
            GetTheExecuteRegisterID(out m_glstRegisterid_chr);
            this.m_objManage.m_lngGetChargeByRegisterids(m_glstRegisterid_chr, out m_dtChargeMoney, out m_dtPrepay);
        }

        /// <summary>
        /// 根据流水号删除行
        /// </summary>
        /// <param name="m_arrCanNoOrder"></param>
        //原来的代码
        private void DelTheOrderFromDTView(string[] m_arrCanNoOrder)
        {
            int intOrderListRowsCount = this.m_objViewer.m_dtvOrderList.Rows.Count;
            DataGridViewRow row1 = null;
            DataGridViewRow row2 = null;
            for (int i = 0; i < intOrderListRowsCount; i++)
            {
                row1 = this.m_objViewer.m_dtvOrderList.Rows[i];
                for (int k = 0; k < m_arrCanNoOrder.Length; k++)
                {
                    if (m_arrCanNoOrder[k] == ((clsBIHCanExecOrder)row1.Tag).m_strOrderID)
                    {
                        if ((row1.Cells["dtv_bedcode"].Value != null && !row1.Cells["dtv_bedcode"].Value.ToString().Equals("")) || (row1.Cells["m_dtvLastName"].Value != null && !row1.Cells["m_dtvLastName"].Value.ToString().Equals("")))
                        {
                            if (i < this.m_objViewer.m_dtvOrderList.Rows.Count - 1)
                            {
                                row2 = this.m_objViewer.m_dtvOrderList.Rows[i + 1];
                                if (((clsBIHCanExecOrder)row1.Tag).m_strRegisterID.Equals(((clsBIHCanExecOrder)row2.Tag).m_strRegisterID))
                                {
                                    row2.Cells["dtv_bedcode"].Value = ((clsBIHCanExecOrder)row1.Tag).m_strCURBEDName;
                                    row2.Cells["m_dtvLastName"].Value = ((clsBIHCanExecOrder)row1.Tag).m_strPatientName;
                                    row2.Cells["dtv_DEPTNAME_VCHR"].Value = ((clsBIHCanExecOrder)row1.Tag).m_strCURAREAName;
                                }
                            }
                        }

                        this.m_objViewer.m_dtvOrderList.Rows.Remove(this.m_objViewer.m_dtvOrderList.Rows[i]);
                        i--;
                        intOrderListRowsCount = this.m_objViewer.m_dtvOrderList.Rows.Count;
                    }
                }
            }
        }

        internal bool ConfirmCurrentOrder(string[] m_arrORDERID, out string[] m_arrCanNoOrder)
        {
            //根据选中的医嘱号，重新从数据库把医嘱拿出来，检查他们的最新状态，确定哪些医嘱已被更改状态，例如已经被其他人执行
            DataTable m_dtOrder = null;
            //原来的正确代码 m_arrCanNoOrder = new ArrayList();
            m_arrCanNoOrder = null;
            //p_glstNonExcutablePhysicianOrderID = new System.Collections.Generic.List<string>(p_glstORDERID.Count);//把不能执行的医嘱号码储存在这里
            long lngRef = m_objManage.m_lngConfirmCurrentOrder(m_arrORDERID, out  m_dtOrder);//由于可能多人同时操作医嘱执行，故此，每次执行前需要在查找数据库的最新状态，解决并发的问题
            //List<string> lsstrOrderID = new List<string>();
            ArrayList strOrderIDArr = null;
            ArrayList arrCanNoOrder = new ArrayList();
            if (lngRef > 0 && m_dtOrder != null)
            {
                strOrderIDArr = new ArrayList();
                string orderid_chr = "", status_int = "";
                DateTime executedate_dat, today;
                bool m_blCan = false;
                int intRowsCount = m_dtOrder.Rows.Count;
                System.Data.DataRow objRow = null;
                for (int i = 0; i < intRowsCount; i++)
                {
                    m_blCan = false;
                    objRow = m_dtOrder.Rows[i];
                    orderid_chr = objRow["orderid_chr"].ToString().Trim();
                    status_int = objRow["status_int"].ToString().Trim();
                    DateTime.TryParse(objRow["executedate_dat"].ToString().Trim(), out executedate_dat);
                    DateTime.TryParse(objRow["sysdate"].ToString().Trim(), out today);
                    if (objRow["ordercateid_chr"].ToString().Trim() == "03")
                    {
                        strOrderIDArr.Add(orderid_chr);
                    }
                    if (status_int.Equals("5"))//表示已审核提交
                    {
                        m_blCan = true;
                    }
                    else if (status_int.Equals("2"))//表示已执行
                    {
                        if (executedate_dat.Date == today.Date)//表示今天已执行
                        {
                            m_blCan = false;
                        }
                        else
                        {
                            m_blCan = true;//表示今天还没有执行，可以执行
                        }
                    }
                    if (!m_blCan)
                    {
                        arrCanNoOrder.Add(orderid_chr);
                        //p_glstNonExcutablePhysicianOrderID.Add(orderid_chr);
                    }
                }
                m_arrCanNoOrder = (string[])arrCanNoOrder.ToArray(typeof(string));
                //修改检验项目状态生成申请单，参数1表示住院
                if (strOrderIDArr.Count > 0)
                {
                    string[] strOrderID = (string[])strOrderIDArr.ToArray(typeof(string));
                    com.digitalwave.iCare.middletier.LIS.clsLIS_Svc objSvc = (com.digitalwave.iCare.middletier.LIS.clsLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLIS_Svc));
                    objSvc.m_lngUpdateStatus(strOrderID, 1);
                }
            }
            if (m_arrCanNoOrder.Length > 0)
            {
                return false;
            }
            return true;
        }

        //原来的正确代码
        private System.Collections.Generic.List<clsExecOrderVO> LessMoneyControl(System.Collections.Generic.List<clsExecOrderVO> m_glstAllExecutablePhysicianOrderList)
        {
            int intAllExecutablePhysicianOrderListCount = m_glstAllExecutablePhysicianOrderList.Count;

            //原来的正确代码 ArrayList m_arrPatientList = new ArrayList();
            //预先分配好内存,这样就不需要不断扩容,进行费时的内存操作
            System.Collections.Generic.List<string> glstPatientList = new System.Collections.Generic.List<string>(intAllExecutablePhysicianOrderListCount);
            //原来的正确代码 ArrayList m_arrCanNOPatientList = new ArrayList();
            System.Collections.Generic.List<string> glstPatientListWithNonexecutablePhysicainOrder = new System.Collections.Generic.List<string>(intAllExecutablePhysicianOrderListCount);
            //原来的正确代码 ArrayList m_arrCanExeOrder = new ArrayList();
            System.Collections.Generic.List<clsExecOrderVO> glstFinalExecutablePhysicianOrderList = new System.Collections.Generic.List<clsExecOrderVO>(intAllExecutablePhysicianOrderListCount);

            clsBIHPatientInfo m_objPatient = null;
            decimal m_decSum = 0;
            clsExecOrderVO objExecutablePhysicianOrderVO = null;
            string strRegisterID = null;

            for (int i = 0; i < intAllExecutablePhysicianOrderListCount; i++)
            {
                objExecutablePhysicianOrderVO = m_glstAllExecutablePhysicianOrderList[i];
                strRegisterID = objExecutablePhysicianOrderVO.m_objPatient.m_strRegisterID;

                if (!glstPatientList.Contains(strRegisterID))
                {
                    glstPatientList.Add(strRegisterID);
                    //原来的正确代码 m_arrPatientList.Add(((clsExecOrderVO)m_arrExecOrder[i]).m_objPatient.m_strRegisterID);
                }
            }

            int intPatientListCount = glstPatientList.Count;

            for (int i = 0; i < intPatientListCount; i++)
            {
                m_decSum = 0;
                m_objPatient = null;
                strRegisterID = glstPatientList[i];
                for (int j = 0; j < intAllExecutablePhysicianOrderListCount; j++)
                {
                    objExecutablePhysicianOrderVO = m_glstAllExecutablePhysicianOrderList[j];

                    if (strRegisterID.Equals(objExecutablePhysicianOrderVO.m_objPatient.m_strRegisterID))
                    {
                        m_objPatient = objExecutablePhysicianOrderVO.m_objPatient;
                        m_decSum += objExecutablePhysicianOrderVO.m_decChargeMedItemMoney + objExecutablePhysicianOrderVO.m_decChargeNoMedItemMoney;
                    }
                }
                if (m_objPatient != null)
                {
                    if (m_objPatient.m_decPrePayMoney < m_decSum)
                    {
                        string m_strAlert = "病人：" + m_objPatient.m_strPatientName + "\r\n"; ;
                        m_strAlert += "当次执行医嘱记帐记帐金额为" + m_decSum.ToString("0.00") + "元，结余金额为" + m_objPatient.m_decPrePayMoney.ToString("0.00") + "元，是否确定执行";
                        if (MessageBox.Show(m_strAlert, "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                        }
                        else
                        {
                            if (!glstPatientListWithNonexecutablePhysicainOrder.Contains(m_objPatient.m_strRegisterID))
                            //原来的正确代码 if (!m_arrCanNOPatientList.Contains(m_objPatient.m_strRegisterID))
                            {
                                //原来的正确代码 m_arrCanNOPatientList.Add(m_objPatient.m_strRegisterID);
                                glstPatientListWithNonexecutablePhysicainOrder.Add(m_objPatient.m_strRegisterID);
                            }
                        }

                    }
                }
            }
            //添加有效的病人执行VO
            for (int j = 0; j < intAllExecutablePhysicianOrderListCount; j++)
            {
                objExecutablePhysicianOrderVO = m_glstAllExecutablePhysicianOrderList[j];
                if (!glstPatientListWithNonexecutablePhysicainOrder.Contains(objExecutablePhysicianOrderVO.m_objPatient.m_strRegisterID))
                {
                    //原来的正确代码 m_arrCanExeOrder.Add(m_arrExecOrder[j]);
                    glstFinalExecutablePhysicianOrderList.Add(objExecutablePhysicianOrderVO);
                }
            }
            //原来的正确代码 return m_arrCanExeOrder;
            return glstFinalExecutablePhysicianOrderList;
        }

        /// <summary>
        /// 医嘱执行关键方法 20180403 (主要获取摆药信息)
        /// </summary>
        /// <param name="order"></param>
        /// <param name="ExecVO"></param>
        void CreateTheMedicineVos(clsBIHCanExecOrder order, clsExecOrderVO ExecVO)
        {
            ArrayList m_arrPatientChareVO = new ArrayList();
            if (ExecVO.ISINCEPT_INT == 1)
            {
                if (ExecVO.m_arrPatientChareVO != null && ExecVO.m_arrPatientChareVO.Length > 0)
                {
                    for (int j = 0; j < ExecVO.m_arrPatientChareVO.Length; j++)
                    {
                        clsBihPatientCharge_VO PatientChareVO = (clsBihPatientCharge_VO)ExecVO.m_arrPatientChareVO[j];
                        if (PatientChareVO.m_intITEMSRCTYPE_INT == 1 && ExecVO.m_arrPatientChareVO[j].m_intPUTMEDTYPE_INT != 0)//药品而且需要摆药
                        {
                            #region 摆药VO
                            clsT_Bih_Opr_Putmeddetail_VO m_objPutmeddetail_VO = new clsT_Bih_Opr_Putmeddetail_VO();
                            m_objPutmeddetail_VO.m_strPUTMEDDETAILID_CHR = ExecVO.m_arrPatientChareVO[j].m_strPUTMEDREQID_CHR;
                            m_objPutmeddetail_VO.m_strAREAID_CHR = (string)this.m_objViewer.m_txtArea.Tag;
                            m_objPutmeddetail_VO.m_strBedID = ExecVO.m_strEXEBEDID_CHR;//下嘱时病人所在的病床ID
                            m_objPutmeddetail_VO.m_strPAIENTID_CHR = ExecVO.m_arrPatientChareVO[j].PatientID;
                            m_objPutmeddetail_VO.m_strREGISTERID_CHR = ExecVO.m_arrPatientChareVO[j].RegisterID;
                            m_objPutmeddetail_VO.m_strORDERID_CHR = ExecVO.m_arrPatientChareVO[j].OrderID;
                            m_objPutmeddetail_VO.m_strORDEREXECID_CHR = "";
                            m_objPutmeddetail_VO.m_intORDEREXECTYPE_INT = ExecVO.m_arrPatientChareVO[j].OrderExecType;
                            m_objPutmeddetail_VO.m_intRECIPENO_INT = order.m_intRecipenNo2;
                            m_objPutmeddetail_VO.m_dblDOSAGE_DEC = (double)ExecVO.m_arrPatientChareVO[j].m_decDOSAGE_DEC;
                            m_objPutmeddetail_VO.m_strDOSAGEUNIT_VCHR = ExecVO.m_arrPatientChareVO[j].m_strDOSAGEUNIT_CHR;
                            m_objPutmeddetail_VO.m_strCHARGEITEMID_CHR = ExecVO.m_arrPatientChareVO[j].ChargeItemID;
                            m_objPutmeddetail_VO.m_strMEDID_CHR = ExecVO.m_arrPatientChareVO[j].m_strITEMSRCID_VCHR;
                            m_objPutmeddetail_VO.m_strMEDNAME_VCHR = ExecVO.m_arrPatientChareVO[j].ChargeItemName;
                            m_objPutmeddetail_VO.m_intISRICH_INT = ExecVO.m_arrPatientChareVO[j].IsRich;

                            m_objPutmeddetail_VO.m_strDOSETYPEID_CHR = order.m_strDosetypeID;
                            m_objPutmeddetail_VO.m_strEXECFREQID_CHR = order.m_strExecFreqID;
                            m_objPutmeddetail_VO.m_intEXECTIMES_INT = ExecVO.EXECUTETIME_INT;
                            m_objPutmeddetail_VO.m_intEXECDAYS_INT = ExecVO.EXECUTEDAYS_INT;
                            m_objPutmeddetail_VO.m_dblUNITPRICE_MNY = (double)ExecVO.m_arrPatientChareVO[j].UnitPrice;

                            m_objPutmeddetail_VO.m_strUNIT_VCHR = ExecVO.m_arrPatientChareVO[j].Unit;
                            m_objPutmeddetail_VO.m_dblGET_DEC = (double)ExecVO.m_arrPatientChareVO[j].Amount;
                            m_objPutmeddetail_VO.m_strCREATOR_CHR = this.m_objViewer.LoginInfo.m_strEmpID;

                            m_objPutmeddetail_VO.m_strPCHARGEID_CHR = ExecVO.m_arrPatientChareVO[j].PchargeID;
                            m_objPutmeddetail_VO.m_strEXECTIME_VCHR = ExecVO.EXECUTEDATE_VCHR;
                            m_objPutmeddetail_VO.m_intNEEDCONFIRM_INT = ExecVO.NEEDCONFIRM_INT;
                            m_objPutmeddetail_VO.m_intACTIVATETYPE_INT = ExecVO.m_arrPatientChareVO[j].ActivateType;

                            m_objPutmeddetail_VO.m_intITEMSRCTYPE_INT = ExecVO.m_arrPatientChareVO[j].m_intITEMSRCTYPE_INT;
                            m_objPutmeddetail_VO.m_intISRECRUIT_INT = ExecVO.ISRECRUIT_INT;
                            m_objPutmeddetail_VO.m_intOUTGETMEDDAYS_INT = order.m_intOUTGETMEDDAYS_INT;
                            m_objPutmeddetail_VO.m_intPUTMEDTYPE_INT = ExecVO.m_arrPatientChareVO[j].m_intPUTMEDTYPE_INT;
                            m_objPutmeddetail_VO.m_intMEDICNETYPE_INT = ExecVO.m_arrPatientChareVO[j].m_intMEDICNETYPE_INT;
                            m_objPutmeddetail_VO.m_strMEDSTOREID_CHR = ExecVO.m_arrPatientChareVO[j].ClacArea; // 药房ID
                            m_arrPatientChareVO.Add(m_objPutmeddetail_VO);
                            #endregion
                        }
                    }
                }
            }
            clsT_Bih_Opr_Putmeddetail_VO[] Putmeddetail_VOs = null;
            if (m_arrPatientChareVO.Count > 0)
            {
                Putmeddetail_VOs = (clsT_Bih_Opr_Putmeddetail_VO[])m_arrPatientChareVO.ToArray(typeof(clsT_Bih_Opr_Putmeddetail_VO));
            }
            ExecVO.m_arrPutmeddetail_VO = Putmeddetail_VOs;

        }

        //原来的正确代码 private void SetTheNurseCharge(ArrayList m_arrNurOrders, ArrayList m_arrExecOrder)
        private void SetTheNurseCharge(ArrayList m_arrNurOrders, System.Collections.Generic.List<clsExecOrderVO> p_glstExecutablePhysicianOrderList)
        {
            int intNurOrdersCount = m_arrNurOrders.Count;
            int intExecutablePhysicianOrderListCount = p_glstExecutablePhysicianOrderList.Count;
            clsExecOrderVO objOneExecutablePhysicianOrder = null;

            if (intNurOrdersCount > 0 && intExecutablePhysicianOrderListCount > 0)
            {
                for (int i = 0; i < intExecutablePhysicianOrderListCount; i++)
                {
                    objOneExecutablePhysicianOrder = p_glstExecutablePhysicianOrderList[i];

                    //原来正确的代码 if (((clsExecOrderVO)m_arrExecOrder[i]).m_arrPatientChareVO != null && ((clsExecOrderVO)m_arrExecOrder[i]).m_arrPatientChareVO.Length > 0)
                    if (objOneExecutablePhysicianOrder.m_arrPatientChareVO != null && (objOneExecutablePhysicianOrder.m_arrPatientChareVO.Length > 0))
                    {
                        //原来正确的代码 m_arrNurOrders.Contains(((clsExecOrderVO)m_arrExecOrder[i]).ORDERID_CHR.Trim()))//如果当前医嘱属于护理医嘱，需要修改费用表里的标志PATIENTNURSE_INT
                        if (m_arrNurOrders.Contains(objOneExecutablePhysicianOrder.ORDERID_CHR.Trim()))//如果当前医嘱属于护理医嘱，需要修改费用表里的标志PATIENTNURSE_INT
                        {
                            //原来的正确代码 for (int j = 0; j < ((clsExecOrderVO)m_arrExecOrder[i]).m_arrPatientChareVO.Length; j++)
                            for (int j = 0; j < objOneExecutablePhysicianOrder.m_arrPatientChareVO.Length; j++)
                            {
                                //原来的正确代码 ((clsExecOrderVO)m_arrExecOrder[i]).m_arrPatientChareVO[j].PATIENTNURSE_INT = 1;

                                //objOneExecutablePhysicianOrder里面数据的修改是否会反映到原来m_glstExecutablePhysicianOrderList的数据里面,需要验证!!!
                                p_glstExecutablePhysicianOrderList[i].m_arrPatientChareVO[j].PATIENTNURSE_INT = 1;
                            }
                        }
                    }
                }

            }
        }

        /// <summary>
        /// 病人饮食护理历史记录表VO
        /// </summary>
        /// <param name="clsCommitOrder"></param>
        /// <returns></returns>
        private clsPatientNurseVO GetThePatientNurseVO(clsCommitOrder clsCommitOrder)
        {
            clsPatientNurseVO m_objVo = new clsPatientNurseVO();
            m_objVo.m_dtACTIVE_DAT = DateTime.Now;
            m_objVo.m_intACTIVE_INT = 1;
            m_objVo.m_strOPERATORID_CHR = this.m_objViewer.LoginInfo.m_strEmpID;
            m_objVo.m_strORDERDICID_CHR = clsCommitOrder.m_strOrderDicID;
            m_objVo.m_strOrderDicName = clsCommitOrder.m_strName.Trim();
            m_objVo.m_strREGISTERID_CHR = clsCommitOrder.m_strRegisterID;
            return m_objVo;
        }

        /// <summary>
        /// 选择待执行的病人列表
        /// </summary>
        /// <returns></returns>
        public bool SelectTheOrderFromPerson()
        {
            clsBIHCanExecOrder[] arrBed = (clsBIHCanExecOrder[])getThePersonFromView(0).ToArray(typeof(clsBIHCanExecOrder));
            if (arrBed.Length == 0)
            {
                return false;
            }
            m_arrRegisterID = new ArrayList();
            //欠费病人列表
            ArrayList m_arrPatient = null;
            frmBedPatientList objForm = null;

            if (this.m_objViewer.m_blMoneyControl == false)//
            {
                this.m_objViewer.Cursor = Cursors.WaitCursor;
                //objForm.m_arrPatient = GetTheOverChargeList(objForm.arrBed);
                SetTheAllCheck();
                ArrayList arrSelected = GetTheSelectArrItemList();
                decimal m_decSum = 0;
                Hashtable m_htChargeSum = new Hashtable();
                for (int j = 0; j < arrSelected.Count; j++)
                {
                    m_decSum = 0;
                    clsBIHCanExecOrder order = (clsBIHCanExecOrder)arrSelected[j];
                    if (!m_htChargeSum.ContainsKey(order.m_strRegisterID))
                    {
                        m_htChargeSum.Add(order.m_strRegisterID, m_decSum);
                    }
                    m_decSum = (decimal)m_htChargeSum[order.m_strRegisterID];
                    m_decSum += m_objInputOrder.GettheChargeSum(order, m_dtChargeList);
                    m_htChargeSum[order.m_strRegisterID] = m_decSum;
                }
                m_arrPatient = GetTheOverChargeList(arrBed, m_htChargeSum);
            }
            else
            {
                m_arrPatient = new ArrayList();
            }
            objForm = new frmBedPatientList(m_arrPatient, 1);
            objForm.arrBed = arrBed;
            this.m_objViewer.Cursor = Cursors.Default;
            if (objForm.ShowDialog() == DialogResult.OK)
            {

                m_arrRegisterID = objForm.m_arrPersionID;
                if (m_arrRegisterID.Count > 0)
                {
                    // this.m_objViewer.cmdRefurbish_Click(null, null);
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
        /// 选择待撤消执行的病人列表
        /// </summary>
        /// <returns></returns>
        public bool SelectTheRedrawOrderFromPerson()
        {
            clsBIHCanExecOrder[] arrBed = (clsBIHCanExecOrder[])getThePersonFromView(1).ToArray(typeof(clsBIHCanExecOrder));
            if (arrBed.Length == 0)
            {
                return false;
            }
            m_arrRegisterID = new ArrayList();
            //欠费病人列表
            ArrayList m_arrPatient = null;
            frmBedPatientList objForm = null;
            m_arrPatient = new ArrayList();
            objForm = new frmBedPatientList(m_arrPatient, 1);
            objForm.arrBed = arrBed;
            if (objForm.ShowDialog() == DialogResult.OK)
            {

                m_arrRegisterID = objForm.m_arrPersionID;
                if (m_arrRegisterID.Count > 0)
                {
                    this.m_objViewer.cmdRefurbish_Click(null, null);
                }
                else
                {
                    return false;
                }
                SetTheDrawCheckFromPersionList(m_arrRegisterID);
            }
            else
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 获得欠费的病人列表
        /// </summary>
        /// <param name="clsBIHCanExecOrder"></param>
        /// <returns></returns>
        private ArrayList GetTheOverChargeList(clsBIHCanExecOrder[] clsBIHCanExecOrder, Hashtable m_htChargeSum)
        {
            ArrayList m_arr = new ArrayList();
            for (int i = 0; i < clsBIHCanExecOrder.Length; i++)
            {
                DataView myDataView = new DataView(m_dtPatients);
                myDataView.RowFilter = "registerid_chr='" + clsBIHCanExecOrder[i].m_strRegisterID + "'";
                myDataView.Sort = "REMARK_NO desc";
                if (myDataView.Count <= 0)
                {
                    continue;
                }
                clsBIHPatientInfo m_objPatient;
                m_mthGetPatientInfoFromDateTable(myDataView, out m_objPatient);
                if (m_objPatient.m_intREMARK_INT == 1 && m_objPatient.m_intCHARGECTL_INT == 1)
                {
                    continue;
                }
                decimal m_decSum = 0;
                if (m_htChargeSum.ContainsKey(m_objPatient.m_strRegisterID))
                {
                    m_decSum = (decimal)m_htChargeSum[m_objPatient.m_strRegisterID];
                }
                //for (int j = 0; j < clsBIHCanExecOrder.Length; j++)
                //{
                //    clsBIHCanExecOrder order = (clsBIHCanExecOrder)clsBIHCanExecOrder[j];
                //    if (order.m_strRegisterID.Equals(m_objPatient.m_strRegisterID))
                //    {
                //        m_decSum += m_objInputOrder.GettheChargeSum(order, m_dtChargeList);
                //    }
                //}
                if (m_objPatient.m_decPrePayMoney + m_objPatient.m_decinsuredsum_mny - m_decSum < 0)
                {
                    if (!m_arr.Contains(clsBIHCanExecOrder[i].m_strRegisterID))
                    {
                        m_arr.Add(clsBIHCanExecOrder[i].m_strRegisterID);
                    }
                }
            }
            return m_arr;
        }

        /// <summary>
        /// 选中病人待执行的医嘱
        /// </summary>
        /// <param name="arr"></param>
        private void SetTheCheckFromPersionList(ArrayList arr)
        {
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
            {
                string m_strRegisterID = ((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strRegisterID;
                if (arr.Contains(m_strRegisterID))
                {
                    if (CanExecOrder((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag))
                    {
                        m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value = "1";
                    }
                    else
                    {
                        m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value = "0";
                    }
                }
                else
                {
                    m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value = "0";
                }
            }
        }
        /// <summary>
        /// 选中病人待执行的医嘱
        /// </summary>
        /// <param name="arr"></param>
        private void SetTheAllCheck()
        {
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
            {

                m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value = "1";

            }
        }
        /// <summary>
        /// 选中病人待撤消执行的医嘱
        /// </summary>
        /// <param name="arr"></param>
        private void SetTheDrawCheckFromPersionList(ArrayList arr)
        {
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
            {
                string m_strRegisterID = ((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strRegisterID;
                if (arr.Contains(m_strRegisterID))
                {
                    if (CanExecDrawOrder((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag))
                    {
                        m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value = "1";
                    }
                    else
                    {
                        m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value = "0";
                    }
                }
                else
                {
                    m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value = "0";
                }
            }
        }


        /// <summary>
        /// 选择病人
        /// </summary>
        /// <param name="m_intCase">0-执行医嘱操作，1-撤消医嘱执行操作</param>
        /// <returns></returns>
        private ArrayList getThePersonFromView(int m_intCase)
        {
            int cout = 0;
            ArrayList arr = new ArrayList();
            ArrayList arr2 = new ArrayList();
            string m_strRegisterID = "";
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.Rows.Count; i++)
            {
                if (m_intCase == 0)
                {
                    if (CanExecOrder((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag) == false)
                    {
                        continue;
                    }
                }
                else if (m_intCase == 1)
                {
                    if (CanExecDrawOrder((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag) == false)
                    {
                        continue;
                    }
                }
                m_strRegisterID = ((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strRegisterID;
                if (!arr.Contains(m_strRegisterID))
                {
                    arr.Add(m_strRegisterID);
                    arr2.Add((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag);
                }

            }

            return arr2;
        }

        //刷新当前数据
        public void refreshTheData()
        {
            this.m_objViewer.Cursor = Cursors.WaitCursor;
            LoadTheDate();
            this.m_objViewer.Cursor = Cursors.Default;
            //当前新开医嘱病人统计


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
                if (CanExecOrder((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag) == false)
                {
                    continue;
                }
                string m_strRegisterID = ((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strRegisterID;
                if (!arr.Contains(m_strRegisterID))
                {
                    arr.Add(m_strRegisterID);
                }

            }
            cout = arr.Count;
            return cout;
        }


        private string GetTheSelectItem()
        {
            string orderArr = "";
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.Rows.Count; i++)
            {
                if (m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value.ToString().Trim() == "1")
                {
                    orderArr += "'" + ((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strOrderID + "',";

                }
            }
            orderArr = orderArr.TrimEnd(',');
            return orderArr;
        }

        /// <summary>
        /// 获得当前选中的可执行的医嘱项目
        /// </summary>
        /// <returns></returns>
        private System.Collections.Generic.List<string> GetTheSelectArrItem()
        {
            m_objViewer.m_dtvOrderList.RefreshEdit();
            int intOrderListRowsCount = this.m_objViewer.m_dtvOrderList.Rows.Count;
            DataGridViewRow objDataGridViewRow = null;
            m_glstExecOrderList = new System.Collections.Generic.List<clsBIHCanExecOrder>(intOrderListRowsCount);
            List<string> glstExcutablePhysicianOrderID = new List<string>(intOrderListRowsCount);

            for (int i = 0; i < intOrderListRowsCount; i++)
            {
                objDataGridViewRow = m_objViewer.m_dtvOrderList.Rows[i];
                clsBIHCanExecOrder objBIHCanExecOrder = (clsBIHCanExecOrder)objDataGridViewRow.Tag;

                if (objDataGridViewRow.Cells["m_dtvselectCheck"].Value.Equals("1"))
                {
                    if (CanExecOrder(objBIHCanExecOrder))
                    {
                        glstExcutablePhysicianOrderID.Add(objBIHCanExecOrder.m_strOrderID);
                        m_glstExecOrderList.Add(objBIHCanExecOrder);
                    }
                }
            }
            glstExcutablePhysicianOrderID.TrimExcess();
            m_glstExecOrderList.TrimExcess();
            return glstExcutablePhysicianOrderID;
        }

        /// <summary>
        /// 获得当前选中的可执行的医嘱项目VO对象
        /// </summary>
        /// <returns></returns>
        private ArrayList GetTheSelectArrItemList()
        {
            ArrayList orderArr = new ArrayList();
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.Rows.Count; i++)
            {
                if (m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value.ToString().Equals("1"))
                {
                    orderArr.Add(((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag));
                }
            }

            return orderArr;
        }

        /// <summary>
        /// 获得当前选中的可撤消执行的医嘱项目
        /// </summary>
        /// <returns></returns>
        private ArrayList GetTheSelectDrawArrItem()
        {
            ArrayList orderArr = new ArrayList();
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.Rows.Count; i++)
            {
                if (m_objViewer.m_dtvOrderList.Rows[i].Cells["m_dtvselectCheck"].Value.ToString().Equals("1"))
                {
                    orderArr.Add((clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.Rows[i].Tag);
                }
            }

            return orderArr;
        }
        /// <summary>
        /// 得到已选中的医嘱对象数组  -- 医嘱执行关键方法 20180403
        /// </summary>
        /// <returns></returns>
        List<clsCommitOrder> GetTheSelectExecOrderArrItem(ref List<clsExecOrderVO> p_glstExecOrderVOList)
        {
            int intExecOrderListCount = m_glstExecOrderList.Count;
            List<clsCommitOrder> glstCommitOrderList = new List<clsCommitOrder>(intExecOrderListCount);
            p_glstExecOrderVOList = new List<clsExecOrderVO>(intExecOrderListCount);

            clsBIHCanExecOrder order = null;
            this.objFrmExecuteOrdersProgress.Show();
            this.objFrmExecuteOrdersProgress.lblOrderCount.Text = "共" + intExecOrderListCount.ToString() + "条医嘱";
            for (int i = 0; i < intExecOrderListCount; i++)
            {
                order = m_glstExecOrderList[i];
                this.objFrmExecuteOrdersProgress.lblOrderNum.Text = (i + 1).ToString();
                this.objFrmExecuteOrdersProgress.lblPatientName.Text = order.m_strPatientName;
                this.objFrmExecuteOrdersProgress.lblPhysicianOrder.Text = order.m_strName;

                this.objFrmExecuteOrdersProgress.Refresh();
                Application.DoEvents();
                if (order.m_intRepair == 0)
                {
                    m_intRepairEveVo = 0;
                    clsCommitOrder CommitOrder = new clsCommitOrder();
                    GetCommitOrderFromExecOrder(order, ref CommitOrder, ref p_glstExecOrderVOList);

                    glstCommitOrderList.Add(CommitOrder);
                }
                else if (order.m_intRepair == 1)
                {
                    m_intRepairEveVo = 1;
                    for (int k = 0; k < order.m_intRepairCount; k++)
                    {
                        m_intRepairEveVoCount = k;
                        clsCommitOrder CommitOrder = new clsCommitOrder();
                        GetCommitOrderFromExecOrder(order, ref CommitOrder, ref p_glstExecOrderVOList);

                        glstCommitOrderList.Add(CommitOrder);
                    }
                }
                else if (order.m_intRepair == 2)
                {
                    m_intRepairEveVo = 0;
                    for (int k = 0; k < order.m_intRepairCount + 1; k++)//order.m_intRepairCount + 1的原因是因为按正常要求今天也要执行一次，所以加一次
                    {
                        m_intRepairEveVoCount = k;//执行单补执行次数(0-非补执行,1-补执行)？？？
                        clsCommitOrder CommitOrder = new clsCommitOrder();
                        GetCommitOrderFromExecOrder(order, ref CommitOrder, ref p_glstExecOrderVOList);
                        glstCommitOrderList.Add(CommitOrder);
                        m_intRepairEveVo = 1;
                    }
                }
            }
            return glstCommitOrderList;
        }
        /// <summary>
        /// 医嘱执行关键方法 20180403
        /// </summary>
        /// <param name="order"></param>
        /// <param name="p_objCommitOrder"></param>
        /// <param name="p_glstExecOrderVO_List"></param>
        void GetCommitOrderFromExecOrder(clsBIHCanExecOrder order, ref clsCommitOrder p_objCommitOrder, ref System.Collections.Generic.List<clsExecOrderVO> p_glstExecOrderVO_List)
        {
            DataView myDataView = new DataView(m_dtPatients);

            if (myDataView.Count == 0)
                return;
            myDataView.RowFilter = "registerid_chr='" + order.m_strRegisterID + "'";
            myDataView.Sort = "REMARK_NO desc";
            clsBIHPatientInfo m_objPatient = null;
            if (myDataView.Count > 0)
            {
                m_mthGetPatientInfoFromDateTable(myDataView, out m_objPatient);//返回病人信息
            }
            myDataView = new DataView(m_dtChargeList);
            myDataView.RowFilter = "orderid_chr='" + order.m_strOrderID + "'";
            myDataView.Sort = "FLAG_INT";
            clsChargeForDisplay[] m_arrObjItem = null;
            if (myDataView.Count > 0)
            {
                GetChargeListFromDateTable(myDataView, out m_arrObjItem);//返回该条医嘱执行单的所有费用信息，含是否摆药信息的标志

            }
            p_objCommitOrder.m_strCreatorID = order.m_strCreatorID;

            p_objCommitOrder.m_strCreator = order.m_strCreator;
            p_objCommitOrder.m_strCREATEAREA_ID = order.m_strCREATEAREA_ID;
            p_objCommitOrder.m_strCREATEAREA_Name = order.m_strCREATEAREA_Name;
            p_objCommitOrder.m_strCURAREAID_CHR = order.m_strCURAREAID_CHR;
            p_objCommitOrder.m_strCURAREAName = order.m_strCURAREAName;
            p_objCommitOrder.m_strCURBEDID_CHR = order.m_strCURBEDID_CHR;
            p_objCommitOrder.m_strCURBEDName = order.m_strCURBEDName;
            p_objCommitOrder.m_strDOCTORID_CHR = order.m_strDOCTORID_CHR;
            p_objCommitOrder.m_strDOCTOR_VCHR = order.m_strDOCTOR_VCHR;

            p_objCommitOrder.m_strOrderID = order.m_strOrderID;
            p_objCommitOrder.m_strName = order.m_strName;
            p_objCommitOrder.m_strOrderDicID = order.m_strOrderDicID;//诊疗项目ID
            p_objCommitOrder.m_strPARTID_VCHR = order.m_strPARTID_VCHR;
            p_objCommitOrder.m_strSpec = order.m_strSpec;//规格{=This.Get医嘱项目.Get药品.规格}
            p_objCommitOrder.m_strUseunit = order.m_strDosageUnit;
            p_objCommitOrder.m_strPARTNAME_VCHR = order.m_strPARTNAME_VCHR;
            p_objCommitOrder.m_strOrderDicCateID = order.m_strOrderDicCateID;
            p_objCommitOrder.m_strOrderDicCateName = order.m_strOrderDicCateName;
            p_objCommitOrder.m_strAPPLYTYPEID_CHR = order.m_strAPPLYTYPEID_CHR; // 申请单类别ID(AR_APPLY_TYPELIST)(检查)
            p_objCommitOrder.m_strLISAPPLYUNITID_CHR = order.m_strLISAPPLYUNITID_CHR;//检验申请单元ID(t_aid_lis_apply_unit)
            p_objCommitOrder.m_strDEPTID_CHR = order.m_strCREATEAREA_ID;
            p_objCommitOrder.m_strDEPTNAME_VCHR = order.m_strCREATEAREA_Name;
            p_objCommitOrder.m_strRegisterID = order.m_strRegisterID;
            p_objCommitOrder.m_strCHARGEDOCTORGROUPID = order.m_strCHARGEDOCTORGROUPID;//

            p_objCommitOrder.m_strSAMPLEID_VCHR = order.m_strSAMPLEID_VCHR;//样本类型ID
            p_objCommitOrder.m_strSAMPLEName_VCHR = order.m_strSAMPLEName_VCHR;//样本类型名

            if (m_objPatient != null)
            {
                p_objCommitOrder.m_strINPATIENTID_CHR = m_objPatient.m_strInHospitalNo;
                p_objCommitOrder.m_strAge = m_objPatient.m_strAge;
                p_objCommitOrder.m_strPATIENTCARDID_CHR = m_objPatient.m_strPATIENTCARDID_CHR;
                p_objCommitOrder.m_strDIAGNOSE_VCHR = m_objPatient.m_strDiagnose;
                p_objCommitOrder.m_strPatientName = m_objPatient.m_strPatientName;

                p_objCommitOrder.m_strsex_chr = m_objPatient.m_strSex;
                p_objCommitOrder.m_strBedName = m_objPatient.m_strBedName;//删除
                p_objCommitOrder.m_strParentID = m_objPatient.m_strPatientID;
                p_objCommitOrder.m_strAreaID = m_objPatient.m_strAreaID;
                p_objCommitOrder.m_strAreaName = m_objPatient.m_strAreaName;
                p_objCommitOrder.m_strBedID = m_objPatient.m_strBedID;
                p_objCommitOrder.m_strBedName = m_objPatient.m_strBedName;
                p_objCommitOrder.Birthday = m_objPatient.m_dtBorn.ToString("yyyy-MM-dd");
            }

            if (m_arrObjItem != null && m_arrObjItem.Length > 0)
            {
                decimal m_dmlPrice = 0;//检查费用总计
                clsChargeForDisplay m_arrLipMainItem = null;//检查主收费项
                clsORDERCHARGEDEPT_VO objOrderChargeDept_VO = null;//new code

                for (int i = 0; i < m_arrObjItem.Length; i++)
                {
                    objOrderChargeDept_VO = m_arrObjItem[i].m_objORDERCHARGEDEPT_VO;//new code

                    if (objOrderChargeDept_VO.m_intFLAG_INT == 0)//主诊疗项目
                    {
                        m_arrLipMainItem = m_arrObjItem[i];
                        m_dmlPrice += objOrderChargeDept_VO.m_decAmount_dec * objOrderChargeDept_VO.m_decUnitprice_dec; //new code
                    }
                    else if (objOrderChargeDept_VO.m_intFLAG_INT == 1)
                    {
                        m_dmlPrice += objOrderChargeDept_VO.m_decAmount_dec * objOrderChargeDept_VO.m_decUnitprice_dec;//new code
                    }
                    objOrderChargeDept_VO = null;
                }

                if (m_arrLipMainItem != null)
                {
                    p_objCommitOrder.m_dmlPrice = decimal.Parse(m_arrLipMainItem.m_dblPrice.ToString());
                    p_objCommitOrder.m_decTotalPrice = m_dmlPrice;//换为诊疗项目的总价
                    p_objCommitOrder.m_dmlGet = decimal.Parse(m_arrLipMainItem.m_dblDrawAmount.ToString());

                    p_objCommitOrder.m_strChargeITEMID_CHR = m_arrLipMainItem.m_strChargeID;
                    p_objCommitOrder.m_strCharegITEMName = m_arrLipMainItem.m_strName;
                }
            }
            ArrayList m_ObjItemList = new ArrayList();
            if (m_arrObjItem != null && m_arrObjItem.Length > 0)
            {
                for (int i = 0; i < m_arrObjItem.Length; i++)
                {
                    if (m_arrObjItem[i].m_intCONTINUEUSETYPE_INT == 1 && order.m_intStatus == 2)//续用处理，而且已经执行过了，也就是说不能再收费了
                    {
                        continue;
                    }
                    else
                    {
                        m_ObjItemList.Add(m_arrObjItem[i]);
                    }
                }
            }
            clsChargeForDisplay[] m_arrObjItem2 = null;
            if (m_ObjItemList.Count > 0)
            {
                m_arrObjItem2 = (clsChargeForDisplay[])m_ObjItemList.ToArray(typeof(clsChargeForDisplay));//记录真正要收费的收费项目
            }

            BindTheDateToExecVo(m_objPatient, order, m_arrObjItem2, ref p_glstExecOrderVO_List);
        }
        /// <summary>
        /// 医嘱执行关键方法 20180403  (主要是医嘱费用信息)
        /// </summary>
        /// <param name="m_objPatient"></param>
        /// <param name="order"></param>
        /// <param name="m_arrObjItem"></param>
        /// <param name="p_glstExecOrderVO_List"></param>
        void BindTheDateToExecVo(clsBIHPatientInfo m_objPatient, clsBIHCanExecOrder order, clsChargeForDisplay[] m_arrObjItem, ref System.Collections.Generic.List<clsExecOrderVO> p_glstExecOrderVO_List)
        {
            int intIsFirst = 0;//是否首次执行{1-是/0-否}
            int ISRECRUIT_INT = 0;//是否补次{1/0}
            int m_intNEEDCONFIRM_INT = 0;//是否需要费用审核 0-否 1-是
            int intChargeItemStatus = 0;        //*--结算状态（0-待确认；1-待结）
            int ACTIVATETYPE_INT = 1;//生效类型{1=其它;2=补记帐;3=确认记帐;4=确认收费;5=直接收费}
            int intIsRich = 0;                  //*--收费项目的贵重标志
            string ISSELFPAY_CHR = "";//是否自费项目("T","F")                                                                      
            int NEEDCONFIRM_INT = 0;//是否需要费用审核 0-否 1-是;
            int m_intDisCount = 0;//检验是否打折标志的收费项目个数 
            /*
            根据1018-1021确认病人在当前的身份和特注状态下，是否需要费用审核，
            并将标志写入(医嘱执行单)“NEEDCONFIRM_INT”字段。如果需要费用审核，
            则需要通过单独的确认记帐界面完成操作，信息才能允许发送到中心药房摆药。
           凡是需要审核的医嘱，费用信息写入住院费用明细信息表时，PSTATUS_INT=0，标志为未确认收费项目。 
             */
            // reMainMoney 没欠费(>0)/欠费(<0)
            int REMARK_INT = m_objPatient.m_intREMARK_INT;
            int CHARGECTL_INT = m_objPatient.m_intCHARGECTL_INT;

            decimal ChargeMedItemMoney = 0;
            decimal ChargeNoMedItemMoney = 0;
            decimal reMainMoney = m_objPatient.m_decPrePayMoney + m_objPatient.m_decinsuredsum_mny;
            decimal decTotalDiffCost = 0;//让利金额取负值
            //不存在收费项目时直接返回
            if (m_arrObjItem != null && m_arrObjItem.Length > 0)
            {
                SumTheCharge(m_arrObjItem, out ChargeMedItemMoney, out ChargeNoMedItemMoney, out intIsRich, out ISSELFPAY_CHR, out decTotalDiffCost);
                if (REMARK_INT == 1 && CHARGECTL_INT == 1)//特注欠费控制的病人
                {
                    if (ChargeMedItemMoney > 0 && this.m_objViewer.m_dmlMedOCMin != 0 && this.m_objViewer.m_dmlMedOCMin + reMainMoney < ChargeMedItemMoney)//药品项目价钱和>0&&欠费病人药品项目确认最小金额限制<药品项目价钱和
                        m_intNEEDCONFIRM_INT = 1;//要审核
                    if (ChargeNoMedItemMoney > 0 && this.m_objViewer.m_dmlNoMedOCMin != 0 && this.m_objViewer.m_dmlNoMedOCMin + reMainMoney < ChargeNoMedItemMoney)//非药品项目价钱和>0&&欠费病人药品项目确认最小金额限制<非药品项目价钱和
                        m_intNEEDCONFIRM_INT = 1;//要审核
                }
                else//非特注欠费控制的病人(普通病人)
                {
                    if (ChargeMedItemMoney > 0 && this.m_objViewer.m_dmlMedICMin != 0 && this.m_objViewer.m_dmlMedICMin + reMainMoney < ChargeMedItemMoney)//药品项目价钱和>0&&普通病人药品项目确认最小金额限制<药品项目价钱和
                        m_intNEEDCONFIRM_INT = 1;//要审核
                    if (ChargeNoMedItemMoney > 0 && this.m_objViewer.m_dmlNoMedICMin != 0 && this.m_objViewer.m_dmlNoMedICMin + reMainMoney < ChargeNoMedItemMoney)//非药品项目价钱和>0&&普通病人非药品项目确认最小金额限制<非药品项目价钱和
                        m_intNEEDCONFIRM_INT = 1;//要审核
                }
                if (this.intDiffPriceOn == 1)
                    ChargeMedItemMoney = ChargeMedItemMoney + decTotalDiffCost;// 减掉药品让利总金额
            }

            for (int i = 0; i <= order.m_intATTACHTIMES_INT; i++)
            {
                if (i > 0)
                {
                    ISRECRUIT_INT = 1;
                }
                if (order.m_intStatus == 5)
                {
                    intIsFirst = 1;
                }
                clsBihPatientCharge_VO[] m_arrPatientChargeVO = null;//费用数组
                if (m_arrObjItem != null && m_arrObjItem.Length > 0)
                {
                    ArrayList m_arrObjItemList = new ArrayList();
                    for (int k = 0; k < m_arrObjItem.Length; k++)
                    {
                        if (m_arrObjItem[k].m_objORDERCHARGEDEPT_VO.m_decUnitprice_dec != 0)//UnitPrice_Dec  住院单价{=收费项目.住院单价} -- 20180403: 单价=0 不收费，不摆药
                        {
                            m_arrObjItemList.Add(m_arrObjItem[k]);
                        }
                    }
                    m_arrPatientChargeVO = new clsBihPatientCharge_VO[m_arrObjItemList.Count];
                    for (int i2 = 0; i2 < m_arrObjItemList.Count; i2++)
                    {
                        m_arrPatientChargeVO[i2] = new clsBihPatientCharge_VO();
                        m_arrPatientChargeVO[i2].PchargeID = "";//PChargeID_Chr 流水号
                        m_arrPatientChargeVO[i2].RegisterID = order.m_strRegisterID;    // m_objPatient.m_strRegisterID;//RegisterID_Chr
                        m_arrPatientChargeVO[i2].ActiveDat = "";//CHARGEACTIVE_DAT 费用生效日期
                        m_arrPatientChargeVO[i2].OrderID = order.m_strOrderID;//OrderID_Chr
                        m_arrPatientChargeVO[i2].OrderExecID = "";//OrderExecID_Chr
                        m_arrPatientChargeVO[i2].CalcCateID = ((clsChargeForDisplay)m_arrObjItemList[i2]).m_objORDERCHARGEDEPT_VO.m_strItemIPCalcType_Chr;//CalCCateID_Chr  费用核算类别id {=收费项目类型.id}
                        m_arrPatientChargeVO[i2].InvCateID = ((clsChargeForDisplay)m_arrObjItemList[i2]).m_objORDERCHARGEDEPT_VO.m_strItemIpInvType_Chr;//InvCateID_Chr    费用发票类别id {=收费项目类型.id}
                        m_arrPatientChargeVO[i2].ChargeItemID = ((clsChargeForDisplay)m_arrObjItemList[i2]).m_objORDERCHARGEDEPT_VO.m_strChargeitemid_chr;//ChargeItemID_Chr
                        m_arrPatientChargeVO[i2].ChargeItemName = ((clsChargeForDisplay)m_arrObjItemList[i2]).m_objORDERCHARGEDEPT_VO.m_strChargeitemname_chr;//ChargeItemName_Chr
                        m_arrPatientChargeVO[i2].Unit = ((clsChargeForDisplay)m_arrObjItemList[i2]).m_objORDERCHARGEDEPT_VO.m_strUnit_vchr;//Unit_Vchr 住院单位{=收费项目.住院单位}
                        m_arrPatientChargeVO[i2].UnitPrice = ((clsChargeForDisplay)m_arrObjItemList[i2]).m_objORDERCHARGEDEPT_VO.m_decUnitprice_dec;//UnitPrice_Dec  住院单价{=收费项目.住院单价}
                        m_arrPatientChargeVO[i2].Amount = ((clsChargeForDisplay)m_arrObjItemList[i2]).m_objORDERCHARGEDEPT_VO.m_decAmount_dec;//AMount_Dec    领量
                        m_arrPatientChargeVO[i2].m_decSINGLEAMOUNT_DEC = ((clsChargeForDisplay)m_arrObjItemList[i2]).m_objORDERCHARGEDEPT_VO.m_decSINGLEAMOUNT_DEC;//AMount_Dec    领量
                        m_arrPatientChargeVO[i2].Discount = 100;//DisCount_Dec=1；折扣比例
                        if (((clsChargeForDisplay)m_arrObjItemList[i2]).m_objORDERCHARGEDEPT_VO.m_strISSELFPAY_CHR.Trim().Equals("T"))
                        {
                            m_arrPatientChargeVO[i2].Ismepay = 1;//IsMepay_Int=1； 是否自费项目 {=收费项目.是否自费项目}
                        }
                        else
                        {
                            m_arrPatientChargeVO[i2].Ismepay = 0;//IsMepay_Int=1； 是否自费项目 {=收费项目.是否自费项目}
                        }
                        m_arrPatientChargeVO[i2].CreateType = 1;//CreateType_Int 录入类型 {1=自动(医嘱);2=自动(日处理);3=补登(医嘱);4=补登(非医嘱)}
                        m_arrPatientChargeVO[i2].Creator = this.m_objViewer.LoginInfo.m_strEmpID;//Creator_Chr
                        m_arrPatientChargeVO[i2].CreateDat = "";//Create_Dat
                        m_arrPatientChargeVO[i2].CHARGEDOCTORGROUPID_CHR = order.m_strCHARGEDOCTORGROUPID;

                        m_arrPatientChargeVO[i2].Status = 1;// Status_Int有效状态{1=有效;0=无效;-1=历史}
                        m_arrPatientChargeVO[i2].ClacArea = ((clsChargeForDisplay)m_arrObjItemList[i2]).m_objORDERCHARGEDEPT_VO.m_strClacarea_chr;//ClacArea_Chr
                        m_arrPatientChargeVO[i2].CreateArea = ((clsChargeForDisplay)m_arrObjItemList[i2]).m_objORDERCHARGEDEPT_VO.m_strCreatearea_chr;//CreateArea_Chr
                        m_arrPatientChargeVO[i2].IsRich = ((clsChargeForDisplay)m_arrObjItemList[i2]).m_objORDERCHARGEDEPT_VO.m_intISRICH_INT;//ISRICH_INT
                        m_arrPatientChargeVO[i2].CurAreaID = order.m_strAREAID_CHR;//执行时病人所在病区ID
                        m_arrPatientChargeVO[i2].CurBedID = order.m_strBedID;//执行时病人所在病床ID
                        m_arrPatientChargeVO[i2].PatientID = order.m_strParentID;   // m_objPatient.m_strPatientID;
                        m_arrPatientChargeVO[i2].INSURACEDESC_VCHR = ((clsChargeForDisplay)m_arrObjItemList[i2]).m_strYBClass.Trim();//医保信息
                        m_arrPatientChargeVO[i2].SPEC_VCHR = ((clsChargeForDisplay)m_arrObjItemList[i2]).m_strSPEC_VCHR.Trim();//规格{=this.get诊疗项目.get收费项目.规格}
                        m_arrPatientChargeVO[i2].DoctorID = order.m_strDOCTORID_CHR;
                        m_arrPatientChargeVO[i2].Doctor = order.m_strDOCTOR_VCHR;
                        m_arrPatientChargeVO[i2].DoctorGroupID = order.m_strDOCTORGROUPID_CHR;
                        m_arrPatientChargeVO[i2].m_intITEMSRCTYPE_INT = ((clsChargeForDisplay)m_arrObjItemList[i2]).m_intITEMSRCTYPE_INT;//收费项目来源
                        m_arrPatientChargeVO[i2].m_strPUTMEDREQID_CHR = i2.ToString();
                        m_arrPatientChargeVO[i2].m_strITEMSRCID_VCHR = ((clsChargeForDisplay)m_arrObjItemList[i2]).m_objORDERCHARGEDEPT_VO.m_strITEMSRCID_VCHR;
                        m_arrPatientChargeVO[i2].m_intMEDICNETYPE_INT = ((clsChargeForDisplay)m_arrObjItemList[i2]).m_objORDERCHARGEDEPT_VO.m_intMEDICNETYPE_INT;
                        m_arrPatientChargeVO[i2].TotalDiffCostMoney_dec = (decimal)((clsChargeForDisplay)m_arrObjItemList[i2]).m_dblDiffCostMoney;// 总让利金额
                        m_arrPatientChargeVO[i2].BuyPrice = (decimal)((clsChargeForDisplay)m_arrObjItemList[i2]).m_dblTradePrice;
                        m_arrPatientChargeVO[i2].m_intPUTMEDTYPE_INT = ((clsChargeForDisplay)m_arrObjItemList[i2]).m_objORDERCHARGEDEPT_VO.m_intPOFLAG_INT;
                        if (((clsChargeForDisplay)m_arrObjItemList[i2]).m_objORDERCHARGEDEPT_VO.m_intFLAG_INT == 0)
                        {
                            m_arrPatientChargeVO[i2].m_decDOSAGE_DEC = order.m_dmlDosage;
                            m_arrPatientChargeVO[i2].m_strDOSAGEUNIT_CHR = order.m_strDosageUnit;
                        }
                        else
                        {
                            m_arrPatientChargeVO[i2].m_decDOSAGE_DEC = ((clsChargeForDisplay)m_arrObjItemList[i2]).m_objORDERCHARGEDEPT_VO.m_decDOSAGE_DEC;
                            m_arrPatientChargeVO[i2].m_strDOSAGEUNIT_CHR = ((clsChargeForDisplay)m_arrObjItemList[i2]).m_objORDERCHARGEDEPT_VO.m_strDOSAGEUNIT_CHR;
                        }

                        //检验打折数目统计
                        if (this.m_objViewer.m_blLisDiscount == true && order.m_strOrderDicCateID.Trim().Equals(m_objSpecateVo.m_strORDERCATEID_LIS_CHR.Trim()) && m_strLisPARMVALUE_VCHR.Contains(m_arrPatientChargeVO[i2].InvCateID) && !m_arrPatientChargeVO[i2].InvCateID.Equals(""))
                        {
                            m_intDisCount++;
                        }
                        m_arrPatientChargeVO[i2].CHARGEDOCTORID_CHR = order.m_strCreatorID;
                        m_arrPatientChargeVO[i2].CHARGEDOCTOR_VCHR = order.m_strCreator;
                    }
                }
                clsExecOrderVO ExecVo = new clsExecOrderVO();//执行单VO
                ExecVo.ORDEREXECID_CHR = "";//流水号
                ExecVo.ORDERID_CHR = order.m_strOrderID;//医嘱单id	{=医嘱单.id}
                ExecVo.m_strOrderName = order.m_strName;//医嘱名
                ExecVo.CREATORID_CHR = this.m_objViewer.LoginInfo.m_strEmpID;//生成执行单人{=雇员.Id}
                ExecVo.CREATOR_CHR = this.m_objViewer.LoginInfo.m_strEmpName;//生成执行单人{=雇员.name}
                ExecVo.EXECUTETIME_INT = order.m_intTIMES_INT;//执行次数  频率表的次数
                ExecVo.EXECUTEDAYS_INT = order.m_intDays_Int;//执行天数  天数 来自于频率表
                if (ISRECRUIT_INT > 0)
                {
                    ExecVo.EXECUTEDATE_VCHR = "补次";
                }
                else
                {
                    ExecVo.EXECUTEDATE_VCHR = order.m_strEntrust;//执行时间 例: 08:00-14:00-明20:00 来自于医嘱嘱托
                }
                ExecVo.ISCHARGE_INT = 0;// 是否已计费{1-是/0-否}
                ExecVo.ISINCEPT_INT = 0;// 是否已发送{1-是/0-否}
                ExecVo.ISFIRST_INT = intIsFirst;//IsFirst_int 是否首次执行{1-是/0-否}
                ExecVo.ISRECRUIT_INT = ISRECRUIT_INT;//是否补次{1/0}
                ExecVo.STATUS_INT = 1;//Status_Int=1    STATUS_INT 有效标志	{1=有效;0=删除;-1=历史}
                ExecVo.m_strEXEAREAID_CHR = order.m_strAREAID_CHR;//执行时病人所在病区ID
                ExecVo.m_strEXEBEDID_CHR = order.m_strBedID;//执行时病人所在床号ID
                ExecVo.m_objPatient = m_objPatient;
                ExecVo.m_strRegisterRecipenNo = order.m_strRegisterID + "*" + order.m_intRecipenNo.ToString();
                //费用相关字段
                ExecVo.m_decChargeMedItemMoney = ChargeMedItemMoney;//药品
                ExecVo.m_decChargeNoMedItemMoney = ChargeNoMedItemMoney;//非药品 
                /*费用一些标志位处理*/
                if (m_intNEEDCONFIRM_INT == 1)//医嘱执行单表是否需要确认标志
                {
                    intChargeItemStatus = 0;
                }
                //*--结算状态（0-待确认；1-待结）
                if (intIsRich == 1 || ISSELFPAY_CHR.ToUpper().Equals("T"))
                {
                    intChargeItemStatus = 0;

                }
                if (m_intNEEDCONFIRM_INT == 0 && intIsRich == 0 && !ISSELFPAY_CHR.ToUpper().Equals("T"))
                {
                    intChargeItemStatus = 1;
                }
                if (intChargeItemStatus == 0)
                {
                    ACTIVATETYPE_INT = 3;
                }
                else if (intChargeItemStatus == 1)
                {
                    ACTIVATETYPE_INT = 1;
                }
                //贵重医嘱执行后生效类型为3=确认记帐
                if (intChargeItemStatus == 0 && intIsRich == 1)
                {
                    ACTIVATETYPE_INT = 3;
                }

                //自费医嘱执行后生效类型也是4=确认收费
                if (intChargeItemStatus == 0 && ISSELFPAY_CHR.Trim().Equals("T"))
                {
                    ACTIVATETYPE_INT = 4;
                }
                //如果属于 系统参数表(ICARE公用) 1008 住院确认记帐流程对应的身份ID 多种类型以身份隔开 就不走确认收费，走确主认记账流程
                if (ACTIVATETYPE_INT == 4 && !m_strPARMVALUE_VCHR.Trim().Equals("") && m_strPARMVALUE_VCHR.Contains(m_objPatient.m_strPayTypeID))
                {
                    ACTIVATETYPE_INT = 3;
                }
                if (intChargeItemStatus == 0)
                {
                    NEEDCONFIRM_INT = 1;//NEEDCONFIRM_INT是否需要费用审核 0-否 1-是
                }
                else
                {
                    NEEDCONFIRM_INT = 0;//NEEDCONFIRM_INT是否需要费用审核 0-否 1-是
                }
                if (m_arrPatientChargeVO != null && m_arrPatientChargeVO.Length > 0)
                {
                    for (int j = 0; j < m_arrPatientChargeVO.Length; j++)
                    {
                        m_arrPatientChargeVO[j].NeedConfirm = NEEDCONFIRM_INT;
                        m_arrPatientChargeVO[j].PStatus = intChargeItemStatus;
                        m_arrPatientChargeVO[j].ActivateType = ACTIVATETYPE_INT;
                        if (m_arrPatientChargeVO[j].NeedConfirm == 0)//不用审核时直接发药
                        {
                            m_arrPatientChargeVO[j].Activator = this.m_objViewer.LoginInfo.m_strEmpID;//生成执行单人{=雇员.Id}
                        }
                        if (order.m_intExecuteType == 1 && ISRECRUIT_INT == 1 && intIsFirst == 1)//长嘱新开加
                        {
                            m_arrPatientChargeVO[j].OrderExecType = 3;//OrderExecType_Int 医嘱执行类型{1=长嘱;2=临嘱;3=长嘱新开加;4=出院带药}
                            m_arrPatientChargeVO[j].Amount = m_arrPatientChargeVO[j].m_decSINGLEAMOUNT_DEC;
                        }
                        else if (order.m_intExecuteType == 1)
                        {
                            m_arrPatientChargeVO[j].OrderExecType = 1;//长嘱
                        }
                        else if (order.m_intExecuteType == 2)
                        {
                            m_arrPatientChargeVO[j].OrderExecType = 2;//临嘱
                        }
                        else if (order.m_intExecuteType == 3)
                        {
                            m_arrPatientChargeVO[j].OrderExecType = 4;//出院带药
                        }
                        //检验打折的逻辑
                        if (m_intDisCount > this.m_objViewer.m_intLisDiscountNum)
                        {
                            m_arrPatientChargeVO[j].NEWDISCOUNT_DEC = this.m_objViewer.m_decLisDiscountMount;
                        }
                    }
                }
                ExecVo.m_arrPatientChareVO = m_arrPatientChargeVO;//把病人当前医嘱的费用单放到医嘱执行单VO
                ExecVo.NEEDCONFIRM_INT = NEEDCONFIRM_INT;//是否需要费用审核 0-否 1-是
                //长嘱连续性医嘱的特殊处理(1不进行收费，2执行单状态为已发送)
                if (order.m_intExecuteType == 1 && m_objSpecateVo.m_strCONFREQID_CHR.Trim().Equals(order.m_strExecFreqID.Trim()))
                {
                    ExecVo.m_arrPatientChareVO = null;
                    ExecVo.NEEDCONFIRM_INT = 0;
                    ExecVo.ISINCEPT_INT = 1;
                    ExecVo.m_intOrderType = 1;//连续性执行单标识
                    ExecVo.CREATEDATE_DAT = order.m_dtPostdate;//执行时，将生成有效的开始时间就是医嘱提交的时间
                }
                if (ExecVo.NEEDCONFIRM_INT == 0)//不走确认时，直接发药
                {
                    ExecVo.ISINCEPT_INT = 1;// 是否已发送{1-是/0-否}
                }
                //补漏执行标志
                ExecVo.m_intRepair = m_intRepairEveVo;
                //执行单号标识ID 为了避免同一时间的操作，跟执行表约束结合使用
                ExecVo.m_strAUTOID_VCHR = i.ToString() + m_intRepairEveVoCount.ToString();
                //
                ExecVo.PretestDays = order.PretestDays;
                //
                ExecVo.PreAmount2 = order.PreAmount2;
                //
                ExecVo.RegisterId = order.m_strRegisterID;

                ExecVo.CureDays = order.CureDays;
                ExecVo.CheckState = order.CheckState;

                CreateTheMedicineVos(order, ExecVo);//把当前医嘱对应的发药单放到执行单VO中               
                p_glstExecOrderVO_List.Add(ExecVo);
                //不是长嘱及首次执行的,不进行补次操作
                if (order.m_intExecuteType != 1 || intIsFirst != 1)
                {
                    break;
                }
            }
        }

        private void SumTheCharge(clsChargeForDisplay[] m_arrObjItem, out decimal ChargeMedItemMoney, out decimal ChargeNoMedItemMoney, out int intIsRich, out string ISSELFPAY_CHR, out decimal p_decTotalDiffCost)
        {
            ChargeMedItemMoney = 0;
            ChargeNoMedItemMoney = 0;
            intIsRich = 0;
            ISSELFPAY_CHR = "F";
            p_decTotalDiffCost = 0;// 总让利金额
            for (int i = 0; i < m_arrObjItem.Length; i++)
            {
                if (m_arrObjItem[i].m_objORDERCHARGEDEPT_VO.m_intISRICH_INT == 1)
                {
                    intIsRich = 1;
                }
                if (m_arrObjItem[i].m_objORDERCHARGEDEPT_VO.m_strISSELFPAY_CHR.Trim().Equals("T"))
                {
                    ISSELFPAY_CHR = "T";
                }
                if (m_arrObjItem[i].m_objORDERCHARGEDEPT_VO.m_intRATETYPE_INT == 1)
                {
                    if (m_arrObjItem[i].m_objORDERCHARGEDEPT_VO.m_intITEMSRCTYPE_INT == 1)
                    {
                        ChargeMedItemMoney += m_arrObjItem[i].m_objORDERCHARGEDEPT_VO.m_decAmount_dec * m_arrObjItem[i].m_objORDERCHARGEDEPT_VO.m_decUnitprice_dec;
                        p_decTotalDiffCost += m_arrObjItem[i].m_objORDERCHARGEDEPT_VO.m_decAmount_dec * (m_arrObjItem[i].m_objORDERCHARGEDEPT_VO.m_decUnitTradePrice_dec - m_arrObjItem[i].m_objORDERCHARGEDEPT_VO.m_decUnitprice_dec);// 总让利金额
                    }
                    else
                    {
                        ChargeNoMedItemMoney += m_arrObjItem[i].m_objORDERCHARGEDEPT_VO.m_decAmount_dec * m_arrObjItem[i].m_objORDERCHARGEDEPT_VO.m_decUnitprice_dec;
                    }

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
                    m_strOrderID += "'" + ((clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag).m_strOrderID + "',";
                }
            }
            m_strOrderID = m_strOrderID.TrimEnd(',');
            return m_strOrderID;

        }
        #endregion

        #region 初始化界面
        /// <summary>
        /// 初始化界面
        /// </summary>
        internal void IniTheForm()
        {
            long l = this.m_objManage.m_lngGetAPPLY_RLT(out this.m_gdctApplyRlt);
            if (l < 0)
            {
                MessageBox.Show(this.m_objViewer, "检查申请单对照表有错误，请与管理员联系！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            m_blFirstLoad = true;
            this.m_objViewer.m_chkSelectAll.Checked = true;
            if (this.m_objViewer.m_txtArea.Text.Trim().Equals(""))
            {
                this.m_objViewer.m_txtArea.Text = this.m_objViewer.LoginInfo.m_strInpatientAreaName;
                this.m_objViewer.m_txtArea.Tag = this.m_objViewer.LoginInfo.m_strInpatientAreaID;
            }
            this.m_objViewer.m_txtArea.Focus();
            this.m_objViewer.m_cboCode.SelectedIndex = 0;
            this.m_objViewer.m_cboState.Text = "全部医嘱";
            if (this.m_objViewer.m_blCanSelectOrder == true)
            {
                this.m_objViewer.m_dtvOrderList.Columns["m_dtvselectCheck"].Visible = true;
                this.m_objViewer.m_cmdToCommit.Visible = true;
                this.m_objViewer.m_chkSelectAll.Visible = true;
            }
            this.intDiffPriceOn = clsPublic.m_intGetSysParm("9002");// 让利启用开关
            this.m_strDiffMedicineType = clsPublic.m_strGetSysparm("9003");// 让利药品类型
            refreshTheData();
            m_blFirstLoad = false;
        }
        #endregion

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
            ControlTheButton();
        }
        #endregion

        internal void AddNewChargeItem()
        {
            if (this.m_objViewer.m_dtvOrderList.CurrentRow == null || this.m_objViewer.m_dtvOrderList.CurrentRow.Tag == null)
            {
                return;
            }

            clsBIHCanExecOrder m_objOrderItem = (clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.CurrentRow.Tag;
            if (m_objOrderItem.m_intStatus == 2)
            {
                MessageBox.Show("已执行过的项目不允许更改收费项目!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmChargeItem frmCharge = new frmChargeItem(m_objOrderItem);
            if (frmCharge.ShowDialog() == DialogResult.OK)
            {
                refreshTheChargeDate();
                OrderListSelect();

            };
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

            clsBIHCanExecOrder m_objOrderItem = (clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.CurrentRow.Tag;
            if (m_objOrderItem.m_intStatus == 2)
            {
                MessageBox.Show("已执行过的项目不允许更改收费项目!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            clsChargeForDisplay objItem = (clsChargeForDisplay)this.m_objViewer.m_dtvChangeList.CurrentRow.Tag;

            //主收费项目不允许修改 收费类别m_intType	{1=普通药品收费；2=主收费；3=用法收费}
            string m_intType = objItem.m_intType.ToString().Trim();
            string m_strSeq_int = objItem.m_strSeq_int;
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
            clsBIHCanExecOrder m_objOrderItem = (clsBIHCanExecOrder)m_objViewer.m_dtvOrderList.CurrentRow.Tag;
            if (m_objOrderItem.m_intStatus == 2)
            {
                MessageBox.Show("已执行过的项目不允许更改收费项目!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        #region 检查申请

        /// <summary>
        /// 提交发送检查申请单
        /// </summary>

        #region 旧有的算法
        /*
        private bool m_mthSendCheckApplyBill(ref ArrayList SendCheckArr, out com.digitalwave.iCare.ValueObject.clsOrderBooking[] m_arrOrderBooking, out clsATTACHRELATION_VO[] m_arATTACHRELATION)
        {
            m_arrOrderBooking = new com.digitalwave.iCare.ValueObject.clsOrderBooking[0];
            m_arATTACHRELATION = new clsATTACHRELATION_VO[0];
            clsApplyRecord objApplyVO;

            com.digitalwave.GLS_WS.clsApplyForm objfrm = new com.digitalwave.GLS_WS.clsApplyForm();
            //检查类型 申请单映射表VO
            ArrayList m_ATTACHRELATION=new ArrayList();
            ArrayList m_OrderBooking = new ArrayList();
            for (int i = 0; i < SendCheckArr.Count; i++)
            {
                
                clsTestApplyItme_VO item_VO = new clsTestApplyItme_VO();
                clsCommitOrder p_objCommitOrder = (clsCommitOrder)SendCheckArr[i];
                m_mthFillApplyInfo(p_objCommitOrder, out objApplyVO);
                item_VO.m_decDiscount = 0;
                //item_VO.m_decPrice = p_objCommitOrder.m_dmlPrice;
                if (p_objCommitOrder.m_dmlGet == 0)
                {
                    item_VO.m_decPrice = p_objCommitOrder.m_decTotalPrice;
                }
                else
                {
                    item_VO.m_decPrice = p_objCommitOrder.m_decTotalPrice / p_objCommitOrder.m_dmlGet;
                }
                item_VO.m_decQty = p_objCommitOrder.m_dmlGet; 
                item_VO.m_decTolPrice = p_objCommitOrder.m_decTotalPrice; 
                item_VO.m_strItemID = p_objCommitOrder.m_strOrderID; 
                item_VO.m_strItemName = p_objCommitOrder.m_strName;
                item_VO.m_strSpec = p_objCommitOrder.m_strSpec;
                item_VO.m_strUnit = p_objCommitOrder.m_strUseunit;
                item_VO.m_strOutpatRecipeID = "";
                item_VO.m_strRowNo = i.ToString();
                item_VO.m_strOprDeptID = "";

                if (item_VO.m_strItemID.Trim().Equals(""))
                {
                    continue;
                }
                string strTypeID = ""; 
                strTypeID = p_objCommitOrder.m_strAPPLYTYPEID_CHR;
                objApplyVO.m_strDiagnosePart = p_objCommitOrder.m_strPARTNAME_VCHR;
         
                //m_arrOrderBooking[i].m_decBOOKID_INT = -1;
                if (strTypeID == "" || strTypeID == "-1")
                {
                    
                    continue;
                }
                //获取相应检查医嘱的诊断及病历摘要信息
                clsEMR_HIS_CheckRequisition CheckRequest = new clsEMR_HIS_CheckRequisition(p_objCommitOrder.m_strRegisterID, p_objCommitOrder.m_strOrderID);
                clsEMR_HIS_CheckRequisitionValue CheckMessage = CheckRequest.m_objGetCheckRequisition();
                //病历摘要
                if (CheckMessage != null)
                {
                    objApplyVO.m_strSummary = CheckMessage.m_strCASESUMMARY_VCHR+"\r\n"+CheckMessage.m_strPHYSEXAM_VCHR;
                    objApplyVO.m_strDiagnose = CheckMessage.m_strADMISSIONDIAGNOSIS_VCHR;
                }
                objApplyVO.m_strTypeID = strTypeID;
                objApplyVO.m_objChargeItem = item_VO;
                objApplyVO.m_intChargeStatus = 2;
                objApplyVO.m_objAttachRelation.m_strSourceItemID = p_objCommitOrder.m_strOrderID; 
                objApplyVO.m_strAreaID = p_objCommitOrder.m_strAreaID;
                objApplyVO.m_strArea = p_objCommitOrder.m_strAreaName; 
                objApplyVO.m_strBedNO = p_objCommitOrder.m_strBedName;
                objApplyVO.m_strBIHNO = p_objCommitOrder.m_strINPATIENTID_CHR; 
                objApplyVO.m_strDeptID = p_objCommitOrder.m_strDEPTID_CHR;
                objApplyVO.m_strDepartment = p_objCommitOrder.m_strDEPTNAME_VCHR;
                objApplyVO.m_strDiagnosePart = p_objCommitOrder.m_strPARTNAME_VCHR;
                objApplyVO.m_strDoctorID = p_objCommitOrder.m_strCreatorID;
                objApplyVO.m_strDoctorName = p_objCommitOrder.m_strCreator;
                objApplyVO.m_strName = p_objCommitOrder.m_strPatientName;
                objApplyVO.m_strSex = p_objCommitOrder.m_strsex_chr;
                objApplyVO.m_intDeleted = 0;
                
                clsCheckType objCTArr = objfrm.GetIDWithVO(objApplyVO);
                if (objCTArr != null)
                {
                    com.digitalwave.iCare.ValueObject.clsOrderBooking m_objOrderBooking = new com.digitalwave.iCare.ValueObject.clsOrderBooking();
                    m_objOrderBooking.m_decBOOKID_INT = 0;
                    m_objOrderBooking.m_decUNITPRICE_DEC = objApplyVO.m_objChargeItem.m_decPrice;
                    m_objOrderBooking.m_decAMOUNT_DEC = p_objCommitOrder.m_dmlGet;
                    m_objOrderBooking.m_intBOOKSTATUS_INT = 0;
                    m_objOrderBooking.m_strAPPLY_TYPE_INT = objCTArr.m_strTypeID;
                    m_objOrderBooking.m_strCHARGEITEMID_CHR = p_objCommitOrder.m_strChargeITEMID_CHR;
                    m_objOrderBooking.m_strCHARGEITEMNAME_VCHR = p_objCommitOrder.m_strCharegITEMName;
                    m_objOrderBooking.m_strCREATERID_CHR = p_objCommitOrder.m_strCREATEAREA_ID;
                    m_objOrderBooking.m_strCREATEAREA_CHR = p_objCommitOrder.m_strCREATEAREA_ID;
                    m_objOrderBooking.m_strCURAREAID_CHR = p_objCommitOrder.m_strCURAREAID_CHR;
                    m_objOrderBooking.m_strCURBEDID_CHR = p_objCommitOrder.m_strCURBEDID_CHR;
                    m_objOrderBooking.m_strDOCTORID_CHR = p_objCommitOrder.m_strDOCTORID_CHR;
                    m_objOrderBooking.m_strORDERID_CHR = p_objCommitOrder.m_strOrderID;
                    m_objOrderBooking.m_strORDERNAME_VCHR = p_objCommitOrder.m_strName;
                    m_objOrderBooking.m_strPATIENTID_CHR = p_objCommitOrder.m_strParentID;
                    m_objOrderBooking.m_strREGISTERID_CHR = p_objCommitOrder.m_strRegisterID;
                    m_objOrderBooking.m_strUNIT_VCHR = p_objCommitOrder.m_strUseunit;
                    m_objOrderBooking.m_strSENDERID_CHR = this.m_objViewer.LoginInfo.m_strEmpID;
                    m_objOrderBooking.m_strATTACHID_VCHR = objCTArr.m_strApplyID;

                    m_OrderBooking.Add(m_objOrderBooking);

                    clsATTACHRELATION_VO ATTACHRELATION_VO = new clsATTACHRELATION_VO();
                    ATTACHRELATION_VO.strATTACHID_VCHR = objCTArr.m_strApplyID;
                    ATTACHRELATION_VO.strATTACHTYPE_INT = "1";
                    ATTACHRELATION_VO.strATTARELAID_CHR = "";
                    ATTACHRELATION_VO.strSOURCEITEMID_VCHR = p_objCommitOrder.m_strOrderID;
                    ATTACHRELATION_VO.strSYSFROM_INT = "2";
                    ATTACHRELATION_VO.strURGENCY_INT = "0";
                    
                    m_ATTACHRELATION.Add(ATTACHRELATION_VO);
                }
                if (m_ATTACHRELATION.Count > 0)
                {
                    m_arATTACHRELATION = (clsATTACHRELATION_VO[])m_ATTACHRELATION.ToArray(typeof(clsATTACHRELATION_VO));
                }
                if (m_OrderBooking.Count > 0)
                {
                    m_arrOrderBooking = (com.digitalwave.iCare.ValueObject.clsOrderBooking[])m_OrderBooking.ToArray(typeof(com.digitalwave.iCare.ValueObject.clsOrderBooking));
                }
            }
            return true;
        }
        */
        #endregion

        private void m_mthFillApplyInfo(clsCommitOrder p_objCommitOrder, out clsApplyRecord objApplyVO)
        {
            objApplyVO = new clsApplyRecord();
            objApplyVO.m_datApplyDate = DateTime.Now;
            objApplyVO.m_strAge = p_objCommitOrder.m_strAge;
            objApplyVO.m_strCardNO = p_objCommitOrder.m_strPATIENTCARDID_CHR;
            objApplyVO.m_strDiagnose = p_objCommitOrder.m_strDIAGNOSE_VCHR;
            objApplyVO.m_strDoctorName = p_objCommitOrder.m_strCreator;

            objApplyVO.m_strDoctorID = p_objCommitOrder.m_strCreatorID;
            objApplyVO.m_strName = p_objCommitOrder.m_strPatientName;
            objApplyVO.m_strSex = p_objCommitOrder.m_strsex_chr;
            objApplyVO.m_objAttachRelation.m_intSysFrom = 2;
            objApplyVO.m_strDeptID = p_objCommitOrder.m_strDEPTID_CHR;
            objApplyVO.m_strDepartment = p_objCommitOrder.m_strDEPTNAME_VCHR;
            objApplyVO.m_strBedNO = p_objCommitOrder.m_strBedName;
            objApplyVO.m_strBIHNO = p_objCommitOrder.m_strINPATIENTID_CHR;
            objApplyVO.m_strDiagnosePart = p_objCommitOrder.m_strPARTID_VCHR;
            objApplyVO.m_intSubmitted = 1;
        }

        private bool m_mthSendCheckApplyBill(Dictionary<string, List<clsCommitOrder>> p_gdctOrder,
                     out com.digitalwave.iCare.ValueObject.clsOrderBooking[] m_arrOrderBooking, out clsATTACHRELATION_VO[] m_arATTACHRELATION)
        {
            m_arrOrderBooking = null;
            m_arATTACHRELATION = null;

            com.digitalwave.GLS_WS.clsApplyForm objfrm = new com.digitalwave.GLS_WS.clsApplyForm();
            //检查类型 申请单映射表VO
            List<com.digitalwave.iCare.ValueObject.clsOrderBooking> glstBooking = new List<com.digitalwave.iCare.ValueObject.clsOrderBooking>();
            List<clsATTACHRELATION_VO> glstRelation = new List<clsATTACHRELATION_VO>();

            clsApplyRecord objApplyVO;
            clsTestApplyItme_VO item_VO;
            clsEMR_HIS_CheckRequisition CheckRequest;
            clsEMR_HIS_CheckRequisitionValue CheckMessage;
            System.Collections.Generic.List<clsApplyRecord> glstApplyVO;

            com.digitalwave.GLS_WS.clsApplyInterface objRisSend = new com.digitalwave.GLS_WS.clsApplyInterface();
            foreach (string Register in p_gdctOrder.Keys)
            {
                glstApplyVO = new List<clsApplyRecord>();
                List<clsCommitOrder> glstCommitOrder = p_gdctOrder[Register];

                List<com.digitalwave.iCare.ValueObject.clsOrderBooking> bookingTmp = new List<com.digitalwave.iCare.ValueObject.clsOrderBooking>();

                List<clsATTACHRELATION_VO> RelationTmp = new List<clsATTACHRELATION_VO>();
                Hashtable hasTmp = new Hashtable();
                for (int i1 = 0; i1 < glstCommitOrder.Count; i1++)
                {
                    if (glstCommitOrder[i1].m_strOrderID == "")
                    {
                        continue;
                    }
                    objApplyVO = new clsApplyRecord();
                    string strTypeID = "";
                    strTypeID = glstCommitOrder[i1].m_strAPPLYTYPEID_CHR;
                    objApplyVO.m_strDiagnosePart = glstCommitOrder[i1].m_strPARTNAME_VCHR;
                    if (strTypeID == "" || strTypeID == "-1")
                    {
                        continue;
                    }

                    if (!hasTmp.ContainsKey(strTypeID))
                    {
                        hasTmp.Add(strTypeID, this.m_gdctApplyRlt[strTypeID].ToString());
                    }

                    m_mthFillApplyInfo(glstCommitOrder[i1], out objApplyVO);
                    item_VO = new clsTestApplyItme_VO();
                    item_VO.m_decDiscount = 0;
                    if (glstCommitOrder[i1].m_dmlGet == 0)
                    {
                        item_VO.m_decPrice = glstCommitOrder[i1].m_decTotalPrice;
                    }
                    else
                    {
                        item_VO.m_decPrice = glstCommitOrder[i1].m_decTotalPrice / glstCommitOrder[i1].m_dmlGet;
                    }
                    item_VO.m_decQty = glstCommitOrder[i1].m_dmlGet;
                    item_VO.m_decTolPrice = glstCommitOrder[i1].m_decTotalPrice;
                    item_VO.m_strItemID = glstCommitOrder[i1].m_strOrderID;
                    item_VO.m_strItemName = glstCommitOrder[i1].m_strName;
                    item_VO.m_strSpec = glstCommitOrder[i1].m_strSpec;
                    item_VO.m_strUnit = glstCommitOrder[i1].m_strUseunit;
                    item_VO.m_strOutpatRecipeID = "";
                    item_VO.m_strRowNo = i1.ToString();
                    item_VO.m_strOprDeptID = "";

                    CheckRequest = new clsEMR_HIS_CheckRequisition(Register, glstCommitOrder[i1].m_strOrderID);
                    CheckMessage = CheckRequest.m_objGetCheckRequisition();
                    if (CheckMessage != null)
                    {
                        objApplyVO.m_strSummary = CheckMessage.m_strCASESUMMARY_VCHR + "\r\n" + CheckMessage.m_strPHYSEXAM_VCHR;
                        objApplyVO.m_strDiagnose = CheckMessage.m_strADMISSIONDIAGNOSIS_VCHR;
                    }

                    objApplyVO.m_strTypeID = strTypeID;
                    objApplyVO.m_objChargeItem = item_VO;
                    objApplyVO.m_intChargeStatus = 2;
                    objApplyVO.m_objAttachRelation.m_strSourceItemID = glstCommitOrder[i1].m_strOrderID;
                    objApplyVO.m_strAreaID = glstCommitOrder[i1].m_strAreaID;
                    objApplyVO.m_strArea = glstCommitOrder[i1].m_strAreaName;
                    objApplyVO.m_strBedNO = glstCommitOrder[i1].m_strBedName;
                    objApplyVO.m_strBIHNO = glstCommitOrder[i1].m_strINPATIENTID_CHR;
                    objApplyVO.m_strDeptID = glstCommitOrder[i1].m_strDEPTID_CHR;
                    objApplyVO.m_strDepartment = glstCommitOrder[i1].m_strDEPTNAME_VCHR;
                    objApplyVO.m_strDiagnosePart = glstCommitOrder[i1].m_strPARTNAME_VCHR;
                    objApplyVO.m_strDoctorID = glstCommitOrder[i1].m_strCreatorID;
                    objApplyVO.m_strDoctorName = glstCommitOrder[i1].m_strCreator;
                    objApplyVO.m_strName = glstCommitOrder[i1].m_strPatientName;
                    objApplyVO.m_strSex = glstCommitOrder[i1].m_strsex_chr;
                    objApplyVO.m_intDeleted = 0;
                    objApplyVO.BirthDay = glstCommitOrder[i1].Birthday;
                    glstApplyVO.Add(objApplyVO);// 添加申请单到队列

                    //组VO

                    com.digitalwave.iCare.ValueObject.clsOrderBooking m_objOrderBooking = new com.digitalwave.iCare.ValueObject.clsOrderBooking();
                    m_objOrderBooking.m_decBOOKID_INT = 0;
                    m_objOrderBooking.m_decUNITPRICE_DEC = objApplyVO.m_objChargeItem.m_decPrice;
                    m_objOrderBooking.m_decAMOUNT_DEC = glstCommitOrder[i1].m_dmlGet;
                    m_objOrderBooking.m_intBOOKSTATUS_INT = 0;
                    m_objOrderBooking.m_strAPPLY_TYPE_INT = strTypeID;
                    m_objOrderBooking.m_strCHARGEITEMID_CHR = glstCommitOrder[i1].m_strChargeITEMID_CHR;
                    m_objOrderBooking.m_strCHARGEITEMNAME_VCHR = glstCommitOrder[i1].m_strCharegITEMName;
                    m_objOrderBooking.m_strCREATERID_CHR = glstCommitOrder[i1].m_strCREATEAREA_ID;
                    m_objOrderBooking.m_strCREATEAREA_CHR = glstCommitOrder[i1].m_strCREATEAREA_ID;
                    m_objOrderBooking.m_strCURAREAID_CHR = glstCommitOrder[i1].m_strCURAREAID_CHR;
                    m_objOrderBooking.m_strCURBEDID_CHR = glstCommitOrder[i1].m_strCURBEDID_CHR;
                    m_objOrderBooking.m_strDOCTORID_CHR = glstCommitOrder[i1].m_strDOCTORID_CHR;
                    m_objOrderBooking.m_strORDERID_CHR = glstCommitOrder[i1].m_strOrderID;
                    m_objOrderBooking.m_strORDERNAME_VCHR = glstCommitOrder[i1].m_strName;
                    m_objOrderBooking.m_strPATIENTID_CHR = glstCommitOrder[i1].m_strParentID;
                    m_objOrderBooking.m_strREGISTERID_CHR = glstCommitOrder[i1].m_strRegisterID;
                    m_objOrderBooking.m_strUNIT_VCHR = glstCommitOrder[i1].m_strUseunit;
                    m_objOrderBooking.m_strSENDERID_CHR = this.m_objViewer.LoginInfo.m_strEmpID;

                    bookingTmp.Add(m_objOrderBooking);

                    clsATTACHRELATION_VO ATTACHRELATION_VO = new clsATTACHRELATION_VO();
                    ATTACHRELATION_VO.strATTACHTYPE_INT = "1";
                    ATTACHRELATION_VO.strATTARELAID_CHR = "";
                    ATTACHRELATION_VO.strSOURCEITEMID_VCHR = glstCommitOrder[i1].m_strOrderID;
                    ATTACHRELATION_VO.strSYSFROM_INT = "2";
                    ATTACHRELATION_VO.strURGENCY_INT = "0";
                    ATTACHRELATION_VO.strDiagnosePart = objApplyVO.m_strDiagnosePart;
                    ATTACHRELATION_VO.strChargeDetail = objApplyVO.m_strChargeDetail;
                    ATTACHRELATION_VO.strDiagnosePartID = glstCommitOrder[i1].m_strPARTID_VCHR;
                    RelationTmp.Add(ATTACHRELATION_VO);

                }
                clsCheckType[] objCTArr = objRisSend.opGetIDWithVO(glstApplyVO.ToArray(), hasTmp);

                if (objCTArr != null)
                {
                    for (int i1 = 0; i1 < objCTArr.Length; i1++)
                    {
                        for (int j1 = 0; j1 < bookingTmp.Count; j1++)
                        {
                            if (objCTArr[i1].objItem_VO.m_strItemID == bookingTmp[j1].m_strORDERID_CHR)
                            {
                                bookingTmp[j1].m_strATTACHID_VCHR = objCTArr[i1].m_strApplyID;
                                break;
                            }
                        }
                        for (int j1 = 0; j1 < RelationTmp.Count; j1++)
                        {
                            if (objCTArr[i1].objItem_VO.m_strItemID == RelationTmp[j1].strSOURCEITEMID_VCHR)
                            {
                                RelationTmp[j1].strATTACHID_VCHR = objCTArr[i1].m_strApplyID;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }
                glstBooking.AddRange(bookingTmp);
                glstRelation.AddRange(RelationTmp);
                bookingTmp.Clear();
                RelationTmp.Clear();
                objCTArr = null;
            }

            m_arrOrderBooking = glstBooking.ToArray();
            m_arATTACHRELATION = glstRelation.ToArray();
            objfrm = null;
            glstBooking = null;
            glstRelation = null;
            objApplyVO = null;
            item_VO = null;
            CheckRequest = null;
            glstApplyVO = null;
            return true;
        }

        #endregion
        internal void m_lngGetBihExecOrderControls(out decimal m_dmlMedOCMin, out decimal m_dmlNoMedOCMin, out decimal m_dmlMedICMin, out decimal m_dmlNoMedICMin, out int m_intMoneyControl)
        {
            long lngRes = m_objManage.m_lngGetBihExecOrderControls(out  m_dmlMedOCMin, out  m_dmlNoMedOCMin, out  m_dmlMedICMin, out  m_dmlNoMedICMin, out m_intMoneyControl);
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

        internal void DoWork()
        {
            m_lngGetPatientDTByArea();
            m_lngGetChargeByArea();
            if (this.m_objViewer.m_chkReExcute.Checked == true)
                //补执行的执行医嘱单统计
                if (this.m_objViewer.m_chkReExcute.Checked == true)
                {
                    m_lngGetReExecute();
                }
        }

        /// <summary>
        /// 补执行的执行医嘱单统计
        /// 查找医嘱执行表t_opr_bih_orderexecute里面记录的每条医嘱的已执行次数
        /// </summary>
        private void m_lngGetReExecute()
        {
            DataTable m_dtReExecute;
            m_htReExecute = new Hashtable();
            long lngRes = m_objManage.m_lngGetReExecute((string)m_objViewer.m_txtArea.Tag, out  m_dtReExecute);
            //此方法可以考虑优化，由m_dtReExecute来记录医嘱及每条医嘱执行的次数
            if (lngRes > 0 && m_dtReExecute.Rows.Count > 0)
            {
                int intRowsCount = m_dtReExecute.Rows.Count;
                System.Data.DataRow objRow = null;

                for (int i = 0; i < intRowsCount; i++)
                {
                    objRow = m_dtReExecute.Rows[i];
                    m_htReExecute.Add(objRow["orderid_chr"].ToString(), objRow["exeCounts"].ToString());
                }
            }
        }

        internal void RunWorkerCompleted()
        {
            while (true)
            {
                if (ECstate == true)
                {
                    break;
                }
            }
            ECstate = false;
            EPstate = false;
            EOstate = false;
            OrderListSelect();
            this.m_objViewer.m_plControls.Enabled = true;
        }

        internal void GetTheControl()
        {
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
            m_glstControl.Add("1046");//1046', '允许欠费执行时且病人将欠费时的病人费用提示开关', '0-不提示 1-提示'
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
            if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
            {
                int intRowsCount = dtbResult.Rows.Count;
                System.Data.DataRow objOneDataRow = null;
                string strSetID = null;
                string strSetStatus = null;

                for (int i = 0; i < intRowsCount; i++)
                {
                    objOneDataRow = dtbResult.Rows[i];
                    strSetID = objOneDataRow["setid_chr"].ToString().Trim();
                    strSetStatus = objOneDataRow["setstatus_int"].ToString().Trim();

                    switch (strSetID)
                    {
                        case "1028":
                            if (strSetStatus.Equals("0"))
                            {
                                this.m_objViewer.m_blNeedComfirm = false;
                            }
                            else
                            {
                                this.m_objViewer.m_blNeedComfirm = true;
                            }
                            break;
                        case "1029":
                            if (strSetStatus.Equals("0"))
                            {
                                this.m_objViewer.m_blExeConfirm = false;
                            }
                            else
                            {
                                this.m_objViewer.m_blExeConfirm = true;
                            }
                            break;
                        case "1038"://'1038', '住院转抄界面是否显示审核提醒', '0-否；1-是', 1,
                            if (strSetStatus.Equals("0"))
                            {
                                this.m_objViewer.m_blNeedMessageAlert = false;
                            }
                            else
                            {
                                this.m_objViewer.m_blNeedMessageAlert = true;
                            }
                            break;
                        case "1039"://'1039', '住院转抄界面审核提醒显示间隔时间', '单位:秒', 10, 
                            if (!strSetStatus.Equals(""))
                            {
                                this.m_objViewer.m_intMessageOpenTime = int.Parse(strSetStatus);
                            }
                            break;
                        case "1040"://'1040', '住院转抄界面审核提醒窗体显示停留时间', '单位:秒', 5, 
                            if (!strSetStatus.Equals(""))
                            {
                                this.m_objViewer.m_intMessageCloseTime = int.Parse(strSetStatus);
                            }
                            break;
                        case "1018":
                            this.m_objViewer.m_dmlMedOCMin = decimal.Parse(strSetStatus);//欠费病人药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额
                            break;
                        case "1019":
                            this.m_objViewer.m_dmlNoMedOCMin = decimal.Parse(strSetStatus);//欠费病人非药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额
                            break;
                        case "1020":
                            this.m_objViewer.m_dmlMedICMin = decimal.Parse(strSetStatus);//普通病人药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额
                            break;
                        case "1021":
                            this.m_objViewer.m_dmlNoMedICMin = decimal.Parse(strSetStatus);//普通病人非药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额
                            break;
                        case "1030":
                            if (strSetStatus.Equals("0"))
                            {
                                this.m_objViewer.m_blMoneyControl = false;
                            }
                            else
                            {
                                this.m_objViewer.m_blMoneyControl = true;
                            }

                            break;
                        case "1046":
                            if (strSetStatus.Equals("0"))
                            {
                                this.m_objViewer.m_blLessExecuteAlert = false;
                            }
                            else
                            {
                                this.m_objViewer.m_blLessExecuteAlert = true;
                            }
                            break;
                        case "1047":
                            if (strSetStatus.Equals("0"))
                            {
                                this.m_objViewer.m_blCanSelectOrder = false;
                            }
                            else
                            {
                                this.m_objViewer.m_blCanSelectOrder = true;
                            }
                            break;
                        case "1049":
                            if (strSetStatus.Equals("0"))
                            {
                                this.m_objViewer.m_blPutMedicineFormDic = false;
                            }
                            else
                            {
                                this.m_objViewer.m_blPutMedicineFormDic = true;
                            }
                            break;
                        case "4006":
                            int.TryParse(strSetStatus, out this.m_objViewer.m_intLisDiscountNum);
                            break;
                        case "4007":
                            decimal.TryParse(strSetStatus, out this.m_objViewer.m_decLisDiscountMount);
                            break;
                        case "4008":
                            if (strSetStatus.Equals("0"))
                            {
                                this.m_objViewer.m_blLisDiscount = false;
                            }
                            else
                            {
                                this.m_objViewer.m_blLisDiscount = true;
                            }
                            break;
                        case "1036":
                            if (strSetStatus.Equals("1"))
                            {
                                this.m_objViewer.m_blDeableMedControl = true;
                            }
                            else
                            {
                                this.m_objViewer.m_blDeableMedControl = false;
                            }
                            break;
                        case "1037":
                            if (strSetStatus.Equals("1"))
                            {
                                this.m_objViewer.m_blStopControl = true;
                            }
                            else
                            {
                                this.m_objViewer.m_blStopControl = false;
                            }
                            break;
                        case "1053":
                            if (strSetStatus.Equals("1"))
                            {
                                this.m_objViewer.m_blAutoStopAlert = true;
                            }
                            else
                            {
                                this.m_objViewer.m_blAutoStopAlert = false;
                            }
                            break;
                        case "1050":
                            if (strSetStatus.Equals("0"))
                            {
                                this.m_objViewer.m_blSendLisBill = false;
                            }
                            else
                            {
                                this.m_objViewer.m_blSendLisBill = true;
                            }
                            break;
                    }
                }
            }

        }


        /// <summary>
        /// 刷新现有的数据
        /// </summary>
        internal void RefreshHadDate()
        {
            this.m_objViewer.Cursor = Cursors.WaitCursor;
            if (this.m_objViewer.m_cboCode.SelectedIndex == 0)
            {
                refreshTheDataByBed(false);
            }
            else
            {
                refreshTheDataByBed(true);
            }
            this.m_objViewer.Cursor = Cursors.Default;
        }

        //撤消操作
        internal bool Redraw()
        {
            ArrayList m_arrExecOrder = GetTheSelectDrawArrItem();
            long lngRes = m_objManage.m_lngExecDrawOrderByOrderID(m_arrExecOrder);
            if (lngRes > 0)
            {
                MessageBox.Show("撤消执行成功!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshTheData();


            }
            this.m_objViewer.Cursor = Cursors.Default;

            return true;

        }

        /// <summary>
        /// 获取住院基本配置表
        /// </summary>
        internal void SetSPECORDERCATE()
        {
            long lngRes = 0;
            lngRes = m_objInputOrder.m_lngAddGetSPECORDERCATE(out m_objSpecateVo);
        }

        internal long m_lngFindSendArea(string m_strAreaID, out DataTable m_dtItem)
        {
            long lngRes = 0;
            lngRes = m_objInputOrder.m_lngFindSendArea(m_strAreaID, out  m_dtItem);
            return lngRes;
        }



        internal void TheSelectedItemForComfirmRun()
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

        internal bool GetTheComfirmRunSelectItemCount()
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

        internal long IsAllPatSend(string m_strAreaId, out bool ifAll)
        {
            long lngRes = m_objManage.IsAllPatSend(m_strAreaId, out ifAll);
            return lngRes;

        }

        /// <summary>
        /// 右键选择执行时的欠费提醒
        /// </summary>
        /// <returns></returns>
        internal bool m_blLessMoneyControl()
        {
            //欠费病人列表
            ArrayList m_arrPatient = null;
            ArrayList arrSelected = null;
            if (this.m_objViewer.m_blMoneyControl == false)//
            {
                arrSelected = GetTheSelectArrItemList();
                decimal m_decSum = 0;
                Hashtable m_htChargeSum = new Hashtable();
                for (int j = 0; j < arrSelected.Count; j++)
                {
                    m_decSum = 0;
                    clsBIHCanExecOrder order = (clsBIHCanExecOrder)arrSelected[j];
                    if (!m_htChargeSum.ContainsKey(order.m_strRegisterID))
                    {
                        m_htChargeSum.Add(order.m_strRegisterID, m_decSum);
                    }
                    m_decSum = (decimal)m_htChargeSum[order.m_strRegisterID];
                    m_decSum += m_objInputOrder.GettheChargeSum(order, m_dtChargeList);
                    m_htChargeSum[order.m_strRegisterID] = m_decSum;
                }
                clsBIHCanExecOrder[] arrBed = (clsBIHCanExecOrder[])arrSelected.ToArray(typeof(clsBIHCanExecOrder));
                m_arrPatient = GetTheOverChargeList(arrBed, m_htChargeSum);
            }
            if (m_arrPatient != null && m_arrPatient.Count > 0)
            {
                if (arrSelected != null && arrSelected.Count > 0)
                {
                    ArrayList m_arrPatient2 = new ArrayList();
                    for (int i = 0; i < arrSelected.Count; i++)
                    {
                        if (m_arrPatient.Contains(((clsBIHCanExecOrder)arrSelected[i]).m_strRegisterID))
                        {
                            m_arrPatient2.Add((clsBIHCanExecOrder)arrSelected[i]);
                            m_arrPatient.Remove(((clsBIHCanExecOrder)arrSelected[i]).m_strRegisterID);
                        }
                    }
                    if (m_arrPatient2.Count > 0)
                    {
                        LessMoneyAlert(m_arrPatient2);
                        return false;
                    }

                }

            }
            return true;
        }

        /// <summary>
        /// 欠费病人不能执行提示框
        /// </summary>
        /// <param name="m_arrLessMoney"></param>
        private void LessMoneyAlert(ArrayList m_arrLessMoney)
        {
            string m_strMessage = "";
            for (int i = 0; i < m_arrLessMoney.Count; i++)
            {
                m_strMessage += ((clsBIHCanExecOrder)m_arrLessMoney[i]).m_strBedName + "床病人" + ((clsBIHCanExecOrder)m_arrLessMoney[i]).m_strPatientName + "\r\n";
            }
            if (!m_strMessage.Equals(""))
            {
                m_strMessage += "为欠费病人,医嘱不能执行!";
                MessageBox.Show(m_strMessage, "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            /*<======================================*/
        }

        /// <summary>
        /// 选中的项目转换为CHECKBOX列也选中
        /// </summary>
        internal void SelectItemToChecked()
        {

            //有效的选中列(皮试没有结果或为阴性的为无效)
            ArrayList m_arrActive = new ArrayList();
            string m_strID = "";//病人流水登记号及方号组合
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.SelectedRows.Count; i++)
            {
                clsBIHCanExecOrder order = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.SelectedRows[i].Tag;
                m_strID = order.m_strRegisterID + "," + order.m_intRecipenNo.ToString() + ";";
                m_arrActive.Add(m_strID);

            }
            /*<================================*/
            m_strID = "";
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.Rows.Count; i++)
            {
                clsBIHCanExecOrder order = (clsBIHCanExecOrder)this.m_objViewer.m_dtvOrderList.Rows[i].Tag;
                m_strID = order.m_strRegisterID + "," + order.m_intRecipenNo.ToString() + ";";
                if (m_arrActive.Contains(m_strID))
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
        /// 系统参数表(ICARE公用)
        /// </summary>
        internal long LoadThePARMVALUE()
        {
            ArrayList PARMCODE_CHR = new ArrayList();
            DataTable m_dtPARMVALUE_VCHR = new DataTable();
            PARMCODE_CHR.Add("1008");//1008 住院确认记帐流程对应的身份ID 多种类型以身份隔开
            PARMCODE_CHR.Add("0013");//0013 检验组合打折发票类型 多种类型以身份隔开
            //long lngRes = m_objManage.LoadThePARMVALUE(PARMCODE_CHR, out m_strPARMVALUE_VCHR);
            long lngRes = m_objManage.LoadThePARMVALUE(PARMCODE_CHR, out m_dtPARMVALUE_VCHR);
            if (lngRes > 0 && m_dtPARMVALUE_VCHR != null)
            {
                string m_strPARMCODE = "";
                string m_strPARMVALUE = "";
                for (int i = 0; i < m_dtPARMVALUE_VCHR.Rows.Count; i++)
                {
                    m_strPARMCODE = m_dtPARMVALUE_VCHR.Rows[i]["PARMCODE_CHR"].ToString().Trim();
                    m_strPARMVALUE = m_dtPARMVALUE_VCHR.Rows[i]["PARMVALUE_VCHR"].ToString().Trim();

                    switch (m_strPARMCODE)
                    {
                        case "1008":
                            m_strPARMVALUE_VCHR = m_strPARMVALUE;
                            break;
                        case "0013":
                            m_strLisPARMVALUE_VCHR = m_strPARMVALUE;
                            break;
                    }

                }
            }
            return lngRes;
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

        #region CheckCureMed
        /// <summary>
        /// CheckCureMed
        /// </summary>
        /// <param name="lstOrder"></param>
        /// <param name="lstSubStock"></param>
        /// <returns></returns>
        bool CheckCureMed(ref List<EntityCureMed> lstOrder, out List<EntityCureSubStock> lstSubStock)
        {
            lstSubStock = new List<EntityCureSubStock>();
            List<string> lstOrderId = new List<string>();
            Dictionary<string, double> dicGet = new Dictionary<string, double>();                   // key: 药房ID+OrderID
            Dictionary<string, double> dicGet3 = new Dictionary<string, double>();                  // key: RegisterId+OrderID+药房ID+药品ID
            Dictionary<string, double> dicTmp = new Dictionary<string, double>();
            Dictionary<string, List<string>> dicOrder = new Dictionary<string, List<string>>();
            string key = string.Empty;
            foreach (EntityCureMed item in lstOrder)
            {
                lstOrderId.Add(item.orderId);
                if (dicOrder.ContainsKey(item.execDeptId))
                {
                    dicOrder[item.execDeptId].Add(item.orderId);
                }
                else
                {
                    dicOrder.Add(item.execDeptId, new List<string>() { item.orderId });
                }
                dicGet.Add(item.execDeptId + "*" + item.orderId, Convert.ToDouble(item.preAmount));
                dicTmp.Add(item.registerId + "*" + item.orderId + "*" + item.execDeptId, Convert.ToDouble(item.preAmount));
            }
            Dictionary<string, string> dicMedId = new Dictionary<string, string>();
            using (clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject())
            {
                dicMedId = svc.GetMedIdByOrderId(lstOrderId);
            }
            string orderId = string.Empty;
            List<string> lstKey = new List<string>();
            lstKey.AddRange(dicTmp.Keys);
            foreach (string item in lstKey)
            {
                orderId = item.Split('*')[1];
                if (dicMedId.ContainsKey(orderId))
                {
                    dicGet3.Add(item + "*" + dicMedId[orderId], dicTmp[item]);
                }
            }

            #region 需求量
            List<string> lstOrderId_NoInDic = new List<string>();
            Dictionary<string, double> dicGet2 = new Dictionary<string, double>();                  // key: 药房ID+药品ID            
            Dictionary<string, List<string>> dicOrder2 = new Dictionary<string, List<string>>();    // key: 药房ID+药品ID
            foreach (string storeid in dicOrder.Keys)
            {
                foreach (string orderid in dicOrder[storeid])
                {
                    if (!dicMedId.ContainsKey(orderid))
                    {
                        lstOrderId_NoInDic.Add(orderid);     // 不在药品字典中的orderId
                    }
                    else
                    {
                        if (dicOrder2.ContainsKey(storeid))
                        {
                            dicOrder2[storeid].Add(dicMedId[orderid]);
                        }
                        else
                        {
                            dicOrder2.Add(storeid, new List<string>() { dicMedId[orderid] });
                        }
                        key = storeid + "*" + dicMedId[orderid];
                        if (dicGet2.ContainsKey(key))
                        {
                            dicGet2[key] += dicGet[storeid + "*" + orderid];
                        }
                        else
                        {
                            dicGet2.Add(key, dicGet[storeid + "*" + orderid]);
                        }
                    }
                }
            }
            #endregion

            if (dicOrder2.Keys.Count > 0)
            {
                Dictionary<string, double> dicKc = null;    // <药房ID*药ID, 库存量>
                clsDsStorageVO[] dsStorageVOArr = null;
                clsDcl_ExecuteOrder execDcl = new clsDcl_ExecuteOrder();
                execDcl.m_lngGetMedicineKC(dicOrder2, out dicKc, out dsStorageVOArr);
                if (dsStorageVOArr != null && dsStorageVOArr.Length > 0)
                {
                    #region 变量
                    // 领量基本单位转化成最小单位
                    Dictionary<string, string> dicMedName = new Dictionary<string, string>();
                    Dictionary<string, double> dicMedPack = new Dictionary<string, double>();
                    foreach (clsDsStorageVO vo in dsStorageVOArr)
                    {
                        key = vo.m_strPharmacyID + "*" + vo.m_strMedicineID;
                        if (!dicMedPack.ContainsKey(key))
                        {
                            if (vo.m_intIpChargeFlg == 0)
                            {
                                dicMedPack.Add(key, vo.m_dblPackqty);
                            }
                            else
                            {
                                dicMedPack.Add(key, 1);
                            }
                        }
                        if (!dicMedName.ContainsKey(vo.m_strMedicineID))
                        {
                            dicMedName.Add(vo.m_strMedicineID, vo.medName);
                        }
                    }
                    #endregion

                    #region 库存判断
                    lstKey.Clear();
                    lstKey.AddRange(dicGet2.Keys);
                    foreach (string key2 in lstKey)
                    {
                        if (dicMedPack.ContainsKey(key2))                           // 基本单位
                        {
                            dicGet2[key2] = dicGet2[key2] * dicMedPack[key2];       // 最小单位=基本单位*包装量
                        }
                        if (dicKc.ContainsKey(key2))
                        {
                            if (dicGet2[key2] > dicKc[key2])
                            {
                                MessageBox.Show("药品:" + dicMedName[key2.Split('*')[1]] + " 库存不足\r\n\r\n库存数:" + dicKc[key2] + " 需求数:" + dicGet2[key2], "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                            else
                            {
                                // 库存判断通过
                            }
                        }
                        else
                        {
                            string medid = key2.Split('*')[1];
                            if (dicMedName.ContainsKey(medid))
                            {
                                MessageBox.Show("药品:" + dicMedName[medid] + " 无库存", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("药品编码:" + medid + " 无库存", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            return false;
                        }
                    }
                    #endregion

                    #region 生成库存扣减信息
                    double ipAmount = 0;
                    double opAmount = 0;
                    EntityCureSubStock subVo = null;
                    foreach (string key3 in dicGet3.Keys)
                    {
                        key = key3.Split('*')[2] + "*" + key3.Split('*')[3];
                        if (dicMedPack.ContainsKey(key))                       // 基本单位
                        {
                            opAmount = dicGet3[key3];
                            ipAmount = dicGet3[key3] * dicMedPack[key];        // 最小单位=基本单位*包装量
                        }
                        else
                        {
                            opAmount = Convert.ToDouble(clsPublic.Round(Convert.ToDecimal(dicGet3[key3]) / Convert.ToDecimal(dicMedPack[key]), 4));  // 基本单位=最小单位/包装量
                            ipAmount = dicGet3[key3];
                        }
                        for (int k = 0; k < dsStorageVOArr.Length; k++)
                        {
                            clsDsStorageVO dsVo = dsStorageVOArr[k];
                            if (dsVo.m_dbIprealgross == 0) continue;
                            if (dsVo.m_strPharmacyID == key.Split('*')[0] && dsVo.m_strMedicineID == key.Split('*')[1])
                            {
                                subVo = new EntityCureSubStock();
                                subVo.serSid = dsVo.m_intSeriesID;
                                subVo.storeId = dsVo.m_strPharmacyID;
                                subVo.medId = dsVo.m_strMedicineID;
                                if (dsVo.m_dbIprealgross <= ipAmount)
                                {
                                    subVo.ipAmountReal = dsVo.m_dbIprealgross;
                                    subVo.opAmountReal = dsVo.m_dbOprealgross;
                                    ipAmount = ipAmount - subVo.ipAmountReal;
                                    opAmount = opAmount - subVo.opAmountReal;
                                    dsVo.m_dbIprealgross = 0;
                                    dsVo.m_dbOprealgross = 0;
                                }
                                else
                                {
                                    subVo.ipAmountReal = ipAmount;
                                    subVo.opAmountReal = opAmount;
                                    subVo.ipAmountVir = subVo.ipAmountReal;
                                    subVo.opAmountVir = subVo.opAmountReal;
                                    ipAmount = 0;
                                    dsVo.m_dbIprealgross -= ipAmount;
                                    dsVo.m_dbOprealgross -= opAmount;
                                }
                                subVo.registerId = key3.Split('*')[0];
                                subVo.orderId = key3.Split('*')[1];
                                lstSubStock.Add(subVo);
                                if (ipAmount == 0) break;
                            }
                        }
                    }
                    #endregion

                    #region 审核
                    foreach (EntityCureMed item in lstOrder)
                    {
                        item.checkDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        item.checkState = "1";
                        item.checkOperName = this.m_objViewer.LoginInfo.m_strEmpID;
                    }
                    //using (clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject())
                    //{
                    //    if (svc.SaveCureMedConfirm(lstOrder, lstSubStock) > 0)
                    //    {
                    //        MessageBox.Show("审核成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    }
                    //}
                    #endregion
                }
            }
            return true;
        }
        #endregion
    }

    #region Log

    public class Log
    {
        public static void OutputXml(string xml)
        {
            bool isWrite = true;
            if (isWrite) Output(xml);
        }

        public static void OutputXml(string xml, bool isWrite)
        {
            if (isWrite) Output(xml);
        }

        public static void Output(string txt)
        {
            string strDate = DateTime.Now.ToString("yyyy-MM-dd");
            string strTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
            string strFile = System.AppDomain.CurrentDomain.BaseDirectory + @"\log\" + strDate + ".txt";
            bool blnAllWaysNew = false;
            StreamWriter sw = null;
            try
            {
                FileInfo fi = new FileInfo(strFile);
                if (fi.Exists)
                {
                    if (fi.Length >= 2000000)
                    {
                        fi.CopyTo(System.AppDomain.CurrentDomain.BaseDirectory + @"\log\" + strDate + "-" + DateTime.Now.ToString("HHmm") + ".txt", true);
                        sw = fi.CreateText();
                    }
                    else
                    {
                        if (blnAllWaysNew)
                        {
                            sw = fi.CreateText();
                        }
                        else
                        {
                            sw = fi.AppendText();
                        }
                    }
                }
                else
                {
                    if (!Directory.Exists(fi.DirectoryName))
                    {
                        Directory.CreateDirectory(fi.DirectoryName);
                    }
                    sw = fi.CreateText();
                }
                sw.WriteLine("-->>>>> " + strTime);
                sw.WriteLine(txt);
                sw.WriteLine();
            }
            catch (Exception e)
            {
                //throw e;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }

        public static void Output(string fileName, string txt)
        {
            StreamWriter sw = null;
            try
            {
                FileInfo fi = new FileInfo(fileName);
                if (fi.Exists)
                {
                    sw = fi.AppendText();
                }
                else
                {
                    if (!Directory.Exists(fi.DirectoryName))
                    {
                        Directory.CreateDirectory(fi.DirectoryName);
                    }
                    sw = fi.CreateText();
                }
                sw.WriteLine(txt);
                sw.WriteLine();
            }
            catch (Exception e)
            {
                //throw e;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }
    }
    #endregion
}
