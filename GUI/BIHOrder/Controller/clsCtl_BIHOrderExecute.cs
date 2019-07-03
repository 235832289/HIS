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
using com.digitalwave.iCare.gui.LIS;

namespace com.digitalwave.iCare.BIHOrder
{
    /// <summary>
    /// 护士工作站:		查看审核医嘱	逻辑控制层
    /// 作者： 徐斌辉
    /// 创建时间： 2005-02-15
    /// </summary>
    public class clsCtl_BIHOrderExecute : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量

        /// <summary>
        /// 计时器,用于定时刷新数据 
        /// </summary>
        Timer m_timer;

        clsDcl_ExecuteOrder m_objManage = null;
        clsDcl_InputOrder m_objInputOrder = null;
        public string m_strReportID;
        /// <summary>
        /// 操作人ID
        /// </summary>
        public string m_strOperatorID;
        /// <summary>
        /// 操作人
        /// </summary>
        public string m_strOperatorName;
        /// <summary>
        /// 医嘱类型ID	{药品}
        /// </summary>
        private string m_strMedicineOrderTypeID = "";
        /// <summary>
        /// 医嘱基本信息对象	[数组]
        /// </summary>
        public clsOrderBaseInfo[] m_objOrderBaseInfoArr = null;
        /// <summary>
        /// 医嘱费用信息对象	[数组]
        /// </summary>
        public clsPatientChargeInfo[] m_objPatientChargeInfoArr = null;
        /// <summary>
        /// 可执行医嘱对象
        /// </summary>
        public clsBIHCanExecOrder[] m_objBIHCanExecOrderArr;
        /// <summary>
        /// 医嘱类型Vo	[数组]
        /// </summary>
        private clsT_aid_bih_ordercate_VO[] m_objOrdercateArr = null;
        #endregion
        #region 构造函数
        public clsCtl_BIHOrderExecute()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_objManage = new clsDcl_ExecuteOrder();
            m_objInputOrder = new clsDcl_InputOrder();
            m_strReportID = null;
        }
        #endregion
        #region 设置窗体对象
        com.digitalwave.iCare.BIHOrder.frmBIHOrderExecute m_objViewer;
        com.digitalwave.iCare.BIHOrder.frmEditOnceAgain m_objViewer2 = new frmEditOnceAgain();
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmBIHOrderExecute)frmMDI_Child_Base_in;

        }
        #endregion
        #region 清空
        /// <summary>
        /// 清空ListView信息及其变量
        /// </summary>
        public void EmptyListView()
        {
            m_objOrderBaseInfoArr = null;
            m_objPatientChargeInfoArr = null;
            m_objBIHCanExecOrderArr = null;
            ClearListView();
        }
        /// <summary>
        /// 清空ListView
        /// </summary>
        private void ClearListView()
        {
            m_objViewer.m_lsvOrderBaseInfo.Items.Clear();
            m_objViewer.m_lsvPatientChargeInfo.Items.Clear();
            m_objViewer.m_lsvToolTip.Items.Clear();
            m_objViewer.chkSelectAll.Checked = false;
        }
        #endregion
        #region 载入
        public void m_LoadInitialization()
        {
            SetOrderColor();
            FillComboBoxOrderCate(m_objViewer.m_cobOrderCate);
            if (m_objViewer.m_cobOrderCate.Items.Count > 0) m_objViewer.m_cobOrderCate.SelectedIndex = 0;//默认全部
        }
        /// <summary>
        /// 填充FindComboBox	{诊疗项目类型}
        /// </summary>
        /// <param name="cbControl"></param>
        private void FillComboBoxOrderCate(ComboBox cbControl)
        {
            cbControl.Items.Clear();
            long lngRes = 0;
            lngRes = m_objInputOrder.m_lngGetAidOrderCate(out m_objOrdercateArr);
            if (lngRes > 0 && m_objOrdercateArr != null && m_objOrdercateArr.Length > 0)
            {
                //载入医嘱类型对象	ViewName 相同的只载入一次
                ArrayList alViewName = new ArrayList();
                clsOrderCate objItem = new clsOrderCate();
                for (int i1 = 0; i1 < m_objOrdercateArr.Length; i1++)
                {
                    if (!alViewName.Contains(m_objOrdercateArr[i1].m_strVIEWNAME_VCHR.Trim()))
                    {
                        objItem = new clsOrderCate();
                        objItem.m_objOrderCate = m_objOrdercateArr[i1];
                        cbControl.Items.Add(objItem);
                        alViewName.Add(m_objOrdercateArr[i1].m_strVIEWNAME_VCHR.Trim());
                    }
                }
                objItem = new clsOrderCate();
                objItem.m_objOrderCate.m_strVIEWNAME_VCHR = "全部";
                objItem.m_objOrderCate.m_strORDERCATEID_CHR = "";
                cbControl.Items.Insert(0, objItem);
            }
        }
        #endregion
        #region 填充ListView
        /// <summary>
        /// 填充ListView
        /// </summary>
        private void FillListView()
        {
            m_objViewer.m_lsvOrderBaseInfo.Items.Clear();
            m_objViewer.m_lsvPatientChargeInfo.Items.Clear();
            //填充基本信息
            #region 填充基本信息
            if (m_objOrderBaseInfoArr == null || m_objOrderBaseInfoArr.Length <= 0) return;
            ListViewItem lviTemp = null;
            clsT_Opr_Bih_OrderFeel_VO objTem;
            for (int i1 = 0; i1 < m_objOrderBaseInfoArr.Length; i1++)
            {
                clsBIHCanExecOrder objItem = m_objOrderBaseInfoArr[i1].m_objBIHCanExecOrder;
                //
                lviTemp = new ListViewItem((i1 + 1).ToString());
                if (i1 > 0 && objItem.m_strRegisterID.Trim() == m_objOrderBaseInfoArr[i1 - 1].m_objBIHCanExecOrder.m_strRegisterID.Trim())
                {
                    //床号
                    lviTemp.SubItems.Add("");
                    //姓名
                    lviTemp.SubItems.Add("");
                }
                else
                {
                    //床号
                    lviTemp.SubItems.Add(objItem.m_strBedName);
                    //姓名
                    lviTemp.SubItems.Add(objItem.m_strPatientName);
                }
                //方号
                lviTemp.SubItems.Add(objItem.m_intRecipenNo.ToString());
                //长/临
                if (objItem.m_intExecuteType == 1)
                {
                    lviTemp.SubItems.Add("长");
                }
                else
                {
                    if (objItem.m_intExecuteType == 2)
                        lviTemp.SubItems.Add("临");
                    else
                        lviTemp.SubItems.Add("");
                }
                //医嘱名称
                lviTemp.SubItems.Add(objItem.m_strName);
                //剂量（单位）
                if (objItem.m_dmlDosage > 0)
                    lviTemp.SubItems.Add(objItem.m_dmlDosage.ToString() + " " + objItem.m_strDosageUnit);
                else
                    lviTemp.SubItems.Add("");
                //用量（单位）
                if (objItem.m_dmlUse > 0)
                    lviTemp.SubItems.Add(objItem.m_dmlUse.ToString() + " " + objItem.m_strUseunit);
                else
                    lviTemp.SubItems.Add("");
                //领量
                if (objItem.m_dmlGet > 0)
                    lviTemp.SubItems.Add(objItem.m_dmlGet.ToString() + " " + objItem.m_strGetunit);
                else
                    lviTemp.SubItems.Add("");
                //单价
                lviTemp.SubItems.Add(objItem.m_dmlPrice.ToString("0.0000"));
                //执行频率
                lviTemp.SubItems.Add(objItem.m_strExecFreqName);
                //用药方式
                lviTemp.SubItems.Add(objItem.m_strDosetypeName);
                //补次	{if(首次执行 && 状态为通过审核 && 类型为药品) then 默认为补次}
                lviTemp.SubItems.Add((m_objOrderBaseInfoArr[i1].m_intIsRecruit == 1) ? "√" : "");
                //皮试	皮试结果
                if (objItem.m_intISNEEDFEEL == 1)
                {
                    //是否皮试
                    lviTemp.SubItems.Add("√");
                    //皮试结果
                    objTem = null;
                    m_objManage.m_lngGetOrderFeelByOrderID(objItem.m_strOrderID, out objTem);
                    if (objTem != null && objTem.m_strORDERFEELID_CHR != null)
                    {
                        lviTemp.SubItems.Add(objTem.m_strResultTypeName);
                    }
                    else
                    {
                        lviTemp.SubItems.Add("");
                    }
                }
                else
                {
                    //是否皮试
                    lviTemp.SubItems.Add("");
                    //皮试结果
                    lviTemp.SubItems.Add("");
                }
                //父级医嘱
                lviTemp.SubItems.Add(objItem.m_strParentName);
                //开始时间
                lviTemp.SubItems.Add(DateTimeToString(objItem.m_dtStartDate));
                //停止人
                lviTemp.SubItems.Add(objItem.m_strStoper);
                //停止时间
                lviTemp.SubItems.Add(DateTimeToString(objItem.m_dtStopdate));
                //颜色设置(仅在背景色上区分长临嘱)
                #region 颜色设置
                System.Drawing.Color clrForeColor = System.Drawing.Color.Black, clrBackColor = System.Drawing.Color.White;
                switch (objItem.m_intStatus)
                {
                    case 1://已经提交
                        clrForeColor = m_objViewer.m_lblNotExecute.BackColor;
                        break;
                    case 3://已停止
                        clrForeColor = m_objViewer.m_lblStopExecute.BackColor;
                        break;
                    default://执行过
                        clrForeColor = m_objViewer.m_lblExecute.BackColor;
                        break;
                }
                if (objItem.m_intExecuteType == 1)
                    clrBackColor = m_objViewer.m_lblLong.BackColor;
                else
                    clrBackColor = m_objViewer.m_lblTemp.BackColor;
                lviTemp.BackColor = clrBackColor;
                lviTemp.ForeColor = clrForeColor;
                #endregion
                lviTemp.Tag = m_objOrderBaseInfoArr[i1];
                m_objViewer.m_lsvOrderBaseInfo.Items.Add(lviTemp);
            }
            #endregion
            //填充医嘱费用信息Vo
            //填充费用信息
            #region 填充费用信息
            if (m_objPatientChargeInfoArr == null || m_objPatientChargeInfoArr.Length <= 0) return;
            lviTemp = null;
            for (int i1 = 0; i1 < m_objPatientChargeInfoArr.Length; i1++)
            {
                //床号
                lviTemp = new ListViewItem(m_objPatientChargeInfoArr[i1].m_strBedName);
                //姓名
                lviTemp.SubItems.Add(m_objPatientChargeInfoArr[i1].m_strPatientName);
                //费用下限
                lviTemp.SubItems.Add(m_objPatientChargeInfoArr[i1].m_dblLowerLimitMoney.ToString("0.00"));
                //累计费用
                lviTemp.SubItems.Add(m_objPatientChargeInfoArr[i1].m_dblSumMoney.ToString("0.00"));
                //余  额
                lviTemp.SubItems.Add(m_objPatientChargeInfoArr[i1].m_dblBalanceMoney.ToString("0.00"));
                //填充颜色	{业务说明：余额超过费用下限的均突出显示}
                #region 填充颜色
                if (m_objPatientChargeInfoArr[i1].m_dblBalanceMoney <= m_objPatientChargeInfoArr[i1].m_dblLowerLimitMoney)
                {
                    lviTemp.BackColor = System.Drawing.Color.Pink;
                    lviTemp.ForeColor = System.Drawing.Color.Blue;
                }
                #endregion
                lviTemp.Tag = m_objPatientChargeInfoArr[i1];
                m_objViewer.m_lsvPatientChargeInfo.Items.Add(lviTemp);
            }
            #endregion
        }
        /// <summary>
        /// 填充医嘱基本信息对象和医嘱费用信息对象
        /// </summary>
        /// <param name="p_objBIHCanExecOrderArr">可执行医嘱Vo	[数组]</param>
        private void FillObject(clsBIHCanExecOrder[] p_objBIHCanExecOrderArr)
        {
            if (p_objBIHCanExecOrderArr == null || p_objBIHCanExecOrderArr.Length <= 0) return;
            #region 填充“基本信息对象”
            int i1 = 0, i2 = 0;
            m_objOrderBaseInfoArr = new clsOrderBaseInfo[p_objBIHCanExecOrderArr.Length];
            for (i1 = 0; i1 < p_objBIHCanExecOrderArr.Length; i1++)
            {
                m_objOrderBaseInfoArr[i1] = new clsOrderBaseInfo();
                //业务说明：	{if(首次执行 && 状态为提交 && 类型为药品) then 默认为补次}
                if (m_strMedicineOrderTypeID.Trim() == "")
                {
                    m_strMedicineOrderTypeID = m_objManage.m_strGetMedicineOrderTypeID();
                }
                if (p_objBIHCanExecOrderArr[i1].m_intExecuteType == 1 && p_objBIHCanExecOrderArr[i1].m_intStatus == 1 && p_objBIHCanExecOrderArr[i1].m_strOrderDicCateID.Trim() == m_strMedicineOrderTypeID)
                {
                    m_objOrderBaseInfoArr[i1].m_intIsRecruit = 1;
                }
                else
                {
                    m_objOrderBaseInfoArr[i1].m_intIsRecruit = 0;
                }
                m_objOrderBaseInfoArr[i1].m_objBIHCanExecOrder = p_objBIHCanExecOrderArr[i1];
            }
            #endregion
            #region 填充“费用信息对象”
            ArrayList alDifferentRegisterID = new ArrayList();
            #region 获取不同入院登记ID的“可执行Vo对象”
            for (i1 = 0; i1 < p_objBIHCanExecOrderArr.Length; i1++)
            {
                for (i2 = 0; i2 < alDifferentRegisterID.Count; i2++)
                {
                    if (((clsBIHCanExecOrder)alDifferentRegisterID[i2]).m_strRegisterID.Trim() == p_objBIHCanExecOrderArr[i1].m_strRegisterID.Trim())
                    {
                        break;
                    }
                }
                if (i2 >= alDifferentRegisterID.Count)
                {
                    alDifferentRegisterID.Add(p_objBIHCanExecOrderArr[i1]);
                }
            }
            #endregion
            //填充医嘱费用信息Vo
            #region 填充
            m_objPatientChargeInfoArr = new clsPatientChargeInfo[alDifferentRegisterID.Count];
            for (i1 = 0; i1 < alDifferentRegisterID.Count; i1++)
            {
                m_objPatientChargeInfoArr[i1] = new clsPatientChargeInfo();
                clsBIHCanExecOrder objItem = (clsBIHCanExecOrder)alDifferentRegisterID[i1];
                double dblSumMoney = 0;			//累计费用
                double dblBalanceMoney = 0;		//预交金余额
                double dblLowerLimitMoney = 0;	//费用下限
                try
                {
                    dblSumMoney = m_objManage.m_dblGetSumMoneyByRegisterID(objItem.m_strRegisterID);
                    dblBalanceMoney = m_objManage.m_dblGetBalanceMoneyByRegisterID(objItem.m_strRegisterID);
                    dblLowerLimitMoney = m_objManage.m_dblGetLowerLimitMoneyByRegisterID(objItem.m_strRegisterID);
                }
                catch { }
                //填充
                m_objPatientChargeInfoArr[i1].m_strRegisterID = objItem.m_strRegisterID;
                m_objPatientChargeInfoArr[i1].m_strPatientName = objItem.m_strPatientName;
                m_objPatientChargeInfoArr[i1].m_strBedName = objItem.m_strBedName;
                try
                {
                    m_objPatientChargeInfoArr[i1].m_dblSumMoney = m_objManage.m_dblGetSumMoneyByRegisterID(objItem.m_strRegisterID);
                    m_objPatientChargeInfoArr[i1].m_dblBalanceMoney = m_objManage.m_dblGetBalanceMoneyByRegisterID(objItem.m_strRegisterID);
                    m_objPatientChargeInfoArr[i1].m_dblLowerLimitMoney = m_objManage.m_dblGetLowerLimitMoneyByRegisterID(objItem.m_strRegisterID);
                }
                catch
                { }
            }
            #endregion
            #endregion
        }
        #endregion

        #region 事件
        #region 查询医嘱
        #region 直接查找库
        //		/// <summary>
        //		/// 查找医嘱(可执行|全部)
        //		/// </summary>
        //		public void m_FindOrder()
        //		{
        //			#region 查询条件
        //			EmptyListView();
        //			//病区、病床
        //			string strAreaID ="",strBedIDs ="",strCreatorID="";
        //			if(m_objViewer.m_txtArea.Tag!=null && m_objViewer.m_txtArea.Tag.ToString().Trim()!="" && m_objViewer.m_txtArea.Text.Trim()!="")
        //			{
        //				strAreaID =clsConverter.ToString(m_objViewer.m_txtArea.Tag).Trim();
        //				strBedIDs =m_objViewer.m_BedIDs;
        //			}
        //			else
        //			{
        //				m_objViewer.m_txtArea.Text ="";
        //				m_objViewer.m_txtArea.Tag ="";
        //				m_objViewer.m_BedIDs ="";
        //			}
        //			if(strAreaID.Trim()=="")
        //			{
        //				MessageBox.Show("病区必须选！","提示框！",MessageBoxButtons.OK,MessageBoxIcon.Information);
        //				m_objViewer.m_txtArea.Focus();
        //				m_objViewer.m_txtArea.SelectAll();
        //				return;
        //			}
        //			//录入医生
        //			if(m_objViewer.m_txtDoctor.Tag!=null && m_objViewer.m_txtDoctor.Tag.ToString().Trim()!="" && m_objViewer.m_txtDoctor.Text.Trim()!="")
        //			{
        //				strCreatorID=clsConverter.ToString(m_objViewer.m_txtDoctor.Tag).Trim();
        //			}
        //			//仅显皮试
        //			bool blnNeedFeel =m_objViewer.m_chkNeedFeel.Checked;
        //			//仅显示今天
        //			bool blnOnlyToday =m_objViewer.m_chkOnlyToday.Checked;
        //			//出院带药
        //			bool blnTakeMedicine =m_objViewer.m_chktakeMedicine.Checked;
        //			//执行日期
        //			DateTime dtStartExecute =m_objViewer.m_dtpStartExecute.Value;
        //			DateTime dtEndExecute =m_objViewer.m_dtpEndExecute.Value;
        //			//执行状态
        //			string strOrderStatus =m_objViewer.GetOrderStatus;
        //			//医嘱类型
        //			string strOrderType =m_objViewer.GetOrderType;
        //			//诊疗项目类型
        //			string strOrderCate ="";
        //			if(m_objViewer.m_cobOrderCate.SelectedIndex>0)
        //			{
        //				clsOrderCate objOrderCate =(clsOrderCate)m_objViewer.m_cobOrderCate.SelectedItem;
        //				strOrderCate =objOrderCate.m_objOrderCate.m_strORDERCATEID_CHR.Trim();
        //			}
        //			#endregion
        //
        //			long lngRes =-1;
        //			clsBIHCanExecOrder[] objBIHCanExecOrderArr=new clsBIHCanExecOrder[0];
        //			switch(m_objViewer.Work)
        //			{	//{1=查看医嘱；2=审核提交；3=执行医嘱；4=审查停止；}
        //				case 1:
        //					lngRes =m_objManage.m_lngGetCanExecuteOrder(strAreaID,strBedIDs,strOrderType,strOrderStatus,strOrderCate,blnNeedFeel,blnOnlyToday,blnTakeMedicine,strCreatorID,dtStartExecute,out objBIHCanExecOrderArr);
        //					break;
        //				case 2:
        //					break;
        //				case 3:
        //					lngRes =m_objManage.m_lngGetCanExecuteOrderOnlyCan(strAreaID,strBedIDs,strOrderType,strOrderStatus,strOrderCate,blnNeedFeel,blnOnlyToday,blnTakeMedicine,strCreatorID,dtStartExecute,out objBIHCanExecOrderArr);
        //					break;
        //				case 4:
        //					break;
        //			}			
        //			//填充医嘱基本信息对象和医嘱费用信息对象
        //			FillObject(objBIHCanExecOrderArr);
        //			//填充LisvtView			
        //			FillListView();
        //		}
        //		public void m_FindOrder(string AreaName,string AreaID,string strBedIDs,string strCreatorID)
        //		{
        //			#region 查询条件
        //			EmptyListView();
        //			m_objViewer.m_txtArea.Text = AreaName;
        //			m_objViewer.m_txtArea.Tag = AreaID;
        //
        //			//仅显皮试
        //			bool blnNeedFeel =m_objViewer.m_chkNeedFeel.Checked;
        //			//仅显示今天
        //			bool blnOnlyToday =m_objViewer.m_chkOnlyToday.Checked;
        //			//出院带药
        //			bool blnTakeMedicine =m_objViewer.m_chktakeMedicine.Checked;
        //			//执行日期
        //			DateTime dtStartExecute =m_objViewer.m_dtpStartExecute.Value;
        //			DateTime dtEndExecute =m_objViewer.m_dtpEndExecute.Value;
        //			//执行状态
        //			string strOrderStatus =m_objViewer.GetOrderStatus;
        //			//医嘱类型
        //			string strOrderType =m_objViewer.GetOrderType;
        //			//诊疗项目类型
        //			string strOrderCate ="";
        //			if(m_objViewer.m_cobOrderCate.SelectedIndex>0)
        //			{
        //				clsOrderCate objOrderCate =(clsOrderCate)m_objViewer.m_cobOrderCate.SelectedItem;
        //				strOrderCate =objOrderCate.m_objOrderCate.m_strORDERCATEID_CHR.Trim();
        //			}
        //			#endregion
        //
        //			long lngRes =-1;
        //			clsBIHCanExecOrder[] objBIHCanExecOrderArr=new clsBIHCanExecOrder[0];
        //			switch(m_objViewer.Work)
        //			{	//{1=查看医嘱；2=审核提交；3=执行医嘱；4=审查停止；}
        //				case 1:
        //					lngRes =m_objManage.m_lngGetCanExecuteOrder(AreaID,strBedIDs,strOrderType,strOrderStatus,strOrderCate,blnNeedFeel,blnOnlyToday,blnTakeMedicine,strCreatorID,dtStartExecute,out objBIHCanExecOrderArr);
        //					break;
        //				case 2:
        //					break;
        //				case 3:
        //					lngRes =m_objManage.m_lngGetCanExecuteOrderOnlyCan(AreaID,strBedIDs,strOrderType,strOrderStatus,strOrderCate,blnNeedFeel,blnOnlyToday,blnTakeMedicine,strCreatorID,dtStartExecute,out objBIHCanExecOrderArr);
        //					break;
        //				case 4:
        //					break;
        //			}			
        //			//填充医嘱基本信息对象和医嘱费用信息对象
        //			FillObject(objBIHCanExecOrderArr);
        //			//填充LisvtView			
        //			FillListView();
        //		}
        #endregion
        #region 过滤模式
        public void m_FindOrder()
        {
            #region 查询条件
            EmptyListView();
            //病区、病床
            string strAreaID = "", strBedIDs = "";
            if (m_objViewer.m_txtArea.Tag != null && m_objViewer.m_txtArea.Tag.ToString().Trim() != "" && m_objViewer.m_txtArea.Text.Trim() != "")
            {
                strAreaID = clsConverter.ToString(m_objViewer.m_txtArea.Tag).Trim();
                strBedIDs = m_objViewer.m_BedIDs;
            }
            else
            {
                m_objViewer.m_txtArea.Text = "";
                m_objViewer.m_txtArea.Tag = "";
                m_objViewer.m_BedIDs = "";
            }
            if (strAreaID.Trim() == "")
            {
                MessageBox.Show("病区必须选！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtArea.Focus();
                m_objViewer.m_txtArea.SelectAll();
                return;
            }
            //执行日期
            DateTime dtStartExecute = m_objViewer.m_dtpStartExecute.Value;
            DateTime dtEndExecute = m_objViewer.m_dtpEndExecute.Value;
            #endregion

            long lngRes = -1;
            switch (m_objViewer.Work)
            {	//{1=查看医嘱；2=审核提交；3=执行医嘱；4=审查停止；}
                case 1:
                    lngRes = m_objManage.m_lngGetCanExecuteOrder(strAreaID, strBedIDs, dtStartExecute, out m_objBIHCanExecOrderArr);
                    break;
                case 2:
                    lngRes = m_objManage.m_lngGetOrderForAuditingExecute(strAreaID, strBedIDs, dtStartExecute, out m_objBIHCanExecOrderArr);
                    break;
                case 3:
                    lngRes = m_objManage.m_lngGetCanExecuteOrderOnlyCan(strAreaID, strBedIDs, dtStartExecute, out m_objBIHCanExecOrderArr);
                    break;
                case 4:
                    lngRes = m_objManage.m_lngGetOrderForAuditingStop(strAreaID, strBedIDs, dtStartExecute, out m_objBIHCanExecOrderArr);
                    break;
            }
            //帮带ListView
            DataBindListView();
        }
        public void m_FindOrder(string strAreaName, string strAreaID, string strBedIDs, string strCreatorID)
        {
            EmptyListView();
            m_objViewer.m_txtArea.Text = strAreaName;
            m_objViewer.m_txtArea.Tag = strAreaID;
            //执行日期
            DateTime dtStartExecute = m_objViewer.m_dtpStartExecute.Value;
            DateTime dtEndExecute = m_objViewer.m_dtpEndExecute.Value;

            long lngRes = -1;
            switch (m_objViewer.Work)
            {	//{1=查看医嘱；2=审核提交；3=执行医嘱；4=审查停止；}
                case 1:
                    lngRes = m_objManage.m_lngGetCanExecuteOrder(strAreaID, strBedIDs, dtStartExecute, out m_objBIHCanExecOrderArr);
                    break;
                case 2:
                    lngRes = m_objManage.m_lngGetOrderForAuditingExecute(strAreaID, strBedIDs, dtStartExecute, out m_objBIHCanExecOrderArr);
                    break;
                case 3:
                    lngRes = m_objManage.m_lngGetCanExecuteOrderOnlyCan(strAreaID, strBedIDs, dtStartExecute, out m_objBIHCanExecOrderArr);
                    break;
                case 4:
                    lngRes = m_objManage.m_lngGetOrderForAuditingStop(strAreaID, strBedIDs, dtStartExecute, out m_objBIHCanExecOrderArr);
                    break;
            }
            //帮带ListView
            DataBindListView();
        }
        #endregion
        #endregion
        #region 查看医嘱单
        /// <summary>
        /// 查看医嘱单
        /// </summary>
        public void m_ViewExecOrder()
        {
            m_mthShowChargeItemList(null);
        }
        #endregion
        #region 执   行、审核提交、审核停止
        /// <summary>
        /// 操作事件	{2=审核提交；3=执行医嘱；4=审查停止；}
        /// 业务说明:	请假的病人可以审核,但不能执行医嘱.
        /// </summary>
        public void m_WorkExecute()
        {
            switch (m_objViewer.Work)
            {	//{1=查看医嘱；2=审核提交；3=执行医嘱；4=审查停止；}				
                case 2:
                    AuditingForExecute();
                    break;
                case 3:
                    m_ExecuteOrder();
                    break;
                case 4:
                    AuditingForStop();
                    break;
            }
        }
        #region 执    行
        /// <summary>
        /// 执行医嘱
        /// </summary>
        private void m_ExecuteOrder()
        {
            if (m_objViewer.Work != 3) return;
            long lngRes = -1;
            #region	获取可执行项
            ArrayList alCanExecItem = GetOrderBaseInfoByListView(1);
            if (alCanExecItem.Count <= 0)
            {
                MessageBox.Show(m_objViewer, "请选医嘱！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #endregion
            #region 填充变量
            //医嘱ID [数组]		
            string[] strOrderIDArr = new string[alCanExecItem.Count];
            //入院登记ID [数组]		
            string[] strRegisterIDArr = new string[alCanExecItem.Count];
            //方号	[数组]	
            int[] intRecipenNoArr = new int[alCanExecItem.Count];
            //执行单记录ID [数组] [out 参数，如果返回多个ID则有逗号“，”分割，为空执行失败。]
            string[] strOrderExecIDArr = new string[alCanExecItem.Count];
            //指定是否补次(即执行两次) [数组]
            bool[] blnIsRecruitArr = new bool[alCanExecItem.Count];
            //执行医生流水号
            string strEmpID = m_strOperatorID;
            //执行医生姓名
            string strEmpName = m_strOperatorName;
            //执行日期
            DateTime dtExecDate = m_objViewer.m_dtpStartExecute.Value;
            //父级医嘱ID [数组]
            string[] strParentIDArr = new string[alCanExecItem.Count];
            for (int i1 = 0; i1 < alCanExecItem.Count; i1++)
            {
                clsOrderBaseInfo objItem = (clsOrderBaseInfo)alCanExecItem[i1];
                strOrderIDArr[i1] = objItem.m_objBIHCanExecOrder.m_strOrderID;
                strRegisterIDArr[i1] = objItem.m_objBIHCanExecOrder.m_strRegisterID;
                intRecipenNoArr[i1] = objItem.m_objBIHCanExecOrder.m_intRecipenNo;
                blnIsRecruitArr[i1] = (objItem.m_intIsRecruit == 1) ? true : false;
                strParentIDArr[i1] = objItem.m_objBIHCanExecOrder.m_strParentID;
            }
            #endregion

            #region 请假验证
            if (!PassCheckPatientIsLeave(alCanExecItem))
            {
                MessageBox.Show(m_objViewer, "存在请假的病人;\r\n请假病人不能执行医嘱!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            #region 方号验证
            if (!PassExecuteRecipeNOValidate(alCanExecItem))
            {
                MessageBox.Show("同方号的医嘱必须一起执行！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            #region 子医嘱验证
            if (!PassValidateFatherSonOrder(alCanExecItem))
            {
                MessageBox.Show("子级医嘱不能单独执行，必须和其父级医嘱一起执行！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            #region 排斥验证
            string[] strExcludeOrderIDArr, strExcludeOrderNameArr;
            string[] strCanExecuteOrderIDArr = null;
            int intExcludeType = 0;
            lngRes = m_objManage.m_lngGetCanExecuteOrderByOrderID(strOrderIDArr[0], out strCanExecuteOrderIDArr);
            lngRes = m_objManage.m_lngJudgeExcludeOrder(strOrderIDArr, strCanExecuteOrderIDArr, 2, out intExcludeType, out strExcludeOrderIDArr, out strExcludeOrderNameArr);
            if (lngRes > 0 && intExcludeType != 0)
            {
                string strMessageBox = "";
                //{0=没排斥；1=全排斥临时医嘱；2=全排斥长期医嘱；3=全排斥临常医嘱；4=普通排斥；}
                switch (intExcludeType)
                {
                    case 1:
                        strMessageBox += "下列医嘱存在全排斥[长期、临时]：\r\n";
                        break;
                    case 2:
                        strMessageBox += "下列医嘱存在全排斥[长期]：\r\n";
                        break;
                    case 3:
                        strMessageBox += "下列医嘱存在全排斥[临时]：\r\n";
                        break;
                    case 4:
                        strMessageBox += "下列医嘱存在排斥：\r\n";
                        break;
                }
                for (int i1 = 0; i1 < strExcludeOrderNameArr.Length; i1++)
                {
                    strMessageBox += strExcludeOrderNameArr[i1] + "\r\n";
                }
                MessageBox.Show(strMessageBox, "执行失败!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #endregion
            #region 提示确认
            if (strOrderIDArr == null || strOrderIDArr.Length <= 0)
            {
                MessageBox.Show(m_objViewer, "没有要执行的医嘱！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show(m_objViewer, "确定执行选中的医嘱吗?", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            #endregion

            #region 执行医嘱
            try
            {
                lngRes = m_objManage.m_lngExecuteOrder(strOrderIDArr, strRegisterIDArr, intRecipenNoArr, out strOrderExecIDArr, blnIsRecruitArr, strEmpID, strEmpName, dtExecDate, strParentIDArr);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion
            #region 提交附加单据
            string strMessage = "医嘱执行成功";
            #endregion
            #region 报告结果
            if (lngRes <= 0)
            {
                if (strMessage.Trim() == "") strMessage = "医嘱执行失败！";
                MessageBox.Show(strMessage, "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_FindOrder();
                return;
            }

            //显示费用信息
            //获取生成的执行单
            string[] strArr;
            int j;
            //用于保存执行过的执行单ID
            ArrayList arlExecOrderID = new ArrayList();
            for (int i1 = 0; i1 < strOrderExecIDArr.Length; i1++)
            {
                strArr = strOrderExecIDArr[i1].Split(new char[] { ',' });
                for (j = 0; j < strArr.Length; j++)
                {
                    if (strArr[j] != string.Empty) arlExecOrderID.Add(strArr[j].Trim());
                }
            }
            string[] arrID = (string[])(arlExecOrderID.ToArray(typeof(string)));
            m_mthShowChargeItemList(arrID);
            m_FindOrder();//刷新数据
            #endregion
        }
        #endregion
        #region 审核提交
        /// <summary>
        /// 审核提交
        /// </summary>
        private void AuditingForExecute()
        {
            if (m_objViewer.Work != 2) return;
            long lngRes = -1;
            //获取选中项
            ArrayList alCanExecItem = GetOrderBaseInfoByListView(1);
            if (alCanExecItem.Count <= 0)
            {
                MessageBox.Show(m_objViewer, "请选医嘱！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            #region 方号验证
            if (!PassExecuteRecipeNOValidate(alCanExecItem))
            {
                MessageBox.Show("同方号的医嘱必须同步操作！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            string[] strOrderIDArr = new string[alCanExecItem.Count];
            clsOrderBaseInfo objItem;
            for (int i1 = 0; i1 < alCanExecItem.Count; i1++)
            {
                objItem = (clsOrderBaseInfo)alCanExecItem[i1];
                strOrderIDArr[i1] = objItem.m_objBIHCanExecOrder.m_strOrderID;
            }
            lngRes = m_objManage.m_lngAuditingForExecute(strOrderIDArr, m_strOperatorID, m_strOperatorName);

            //报告结果
            if (lngRes <= 0)
            {
                MessageBox.Show("操作失败！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            m_FindOrder();
        }
        #endregion
        #region 审核停止
        /// <summary>
        /// 审核停止
        /// </summary>
        private void AuditingForStop()
        {
            if (m_objViewer.Work != 4) return;
            long lngRes = -1;
            //获取选中项
            ArrayList alCanExecItem = GetOrderBaseInfoByListView(1);
            if (alCanExecItem.Count <= 0)
            {
                MessageBox.Show(m_objViewer, "请选医嘱！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //验证方号
            #region 方号验证
            if (!PassExecuteRecipeNOValidate(alCanExecItem))
            {
                MessageBox.Show("同方号的医嘱必须同步操作！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            string[] strOrderIDArr = new string[alCanExecItem.Count];
            clsOrderBaseInfo objItem;
            for (int i1 = 0; i1 < alCanExecItem.Count; i1++)
            {
                objItem = (clsOrderBaseInfo)alCanExecItem[i1];
                strOrderIDArr[i1] = objItem.m_objBIHCanExecOrder.m_strOrderID;
            }
            lngRes = m_objManage.m_lngAuditingForStop(strOrderIDArr, m_strOperatorID, m_strOperatorName);

            //报告结果
            if (lngRes <= 0)
            {
                MessageBox.Show("操作失败！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            m_FindOrder();
        }
        #endregion
        #region 排斥医嘱名称
        /// <summary>
        /// 获取排斥医嘱的名称
        /// </summary>
        /// <param name="strExcludeOrderIDArr">排斥医嘱ID</param>
        /// <returns></returns>
        private string GetExcludeOrderName(string[] strExcludeOrderIDArr)
        {
            string strExcludeOrderName = "";
            for (int i1 = 0; i1 < strExcludeOrderIDArr.Length; i1++)
            {
                if (strExcludeOrderIDArr[i1] == null || strExcludeOrderIDArr[i1].Trim() == "") continue;
                for (int i2 = 0; i2 < m_objOrderBaseInfoArr.Length; i2++)
                {
                    if (((clsOrderBaseInfo)m_objOrderBaseInfoArr[i2]).m_objBIHCanExecOrder.m_strOrderID.Trim() == strExcludeOrderIDArr[i1].Trim())
                    {
                        strExcludeOrderName += "\n　　" + ((clsOrderBaseInfo)m_objOrderBaseInfoArr[i2]).m_objBIHCanExecOrder.m_intRecipenNo.ToString().Trim() + "-" + ((clsOrderBaseInfo)m_objOrderBaseInfoArr[i2]).m_objBIHCanExecOrder.m_strName.Trim();
                    }
                }
            }
            return strExcludeOrderName;
        }
        #endregion
        #region 方号验证
        /// <summary>
        /// 方号验证
        /// </summary>
        /// <param name="alCanExecItem">医嘱基本信息对象</param>
        /// <returns></returns>
        private bool PassExecuteRecipeNOValidate(ArrayList alCanExecItem)
        {
            clsBIHCanExecOrder[] objTempCanExecOrderArr = null;
            objTempCanExecOrderArr = m_objBIHCanExecOrderArr;
            #region 获取全部的可执行记录	用于直接和访问数据库
            //			string strAreaID ="",strBedIDs ="",strCreatorID="";
            //			if(m_objViewer.m_txtArea.Tag!=null && m_objViewer.m_txtArea.Tag.ToString().Trim()!="" && m_objViewer.m_txtArea.Text.Trim()!="")
            //			{
            //				strAreaID =clsConverter.ToString(m_objViewer.m_txtArea.Tag).Trim();
            //				strBedIDs =m_objViewer.m_BedIDs;
            //			}				
            //			DateTime dtStartExecute=m_objViewer.m_dtpStartExecute.Value;
            //			m_objManage.m_lngGetCanExecuteOrderOnlyCan(strAreaID,strBedIDs,dtStartExecute,out objTempCanExecOrderArr);
            #endregion
            if (objTempCanExecOrderArr == null || objTempCanExecOrderArr.Length <= 0) return false;

            bool lbnSame = false;
            for (int i1 = 0; i1 < alCanExecItem.Count; i1++)
            {
                clsOrderBaseInfo objItem = ((clsOrderBaseInfo)alCanExecItem[i1]);
                for (int i2 = 0; i2 < objTempCanExecOrderArr.Length; i2++)
                {
                    //if(住院登记ID相同 && 方号相同 && 没有选中) return false;
                    if (objItem.m_objBIHCanExecOrder.m_strRegisterID.Trim() == objTempCanExecOrderArr[i2].m_strRegisterID.Trim()
                        && objItem.m_objBIHCanExecOrder.m_intRecipenNo == objTempCanExecOrderArr[i2].m_intRecipenNo
                        && objItem.m_objBIHCanExecOrder.m_strOrderID != objTempCanExecOrderArr[i2].m_strOrderID)
                    {
                        lbnSame = false;
                        for (int i3 = 0; i3 < alCanExecItem.Count; i3++)
                        {
                            if (((clsOrderBaseInfo)alCanExecItem[i3]).m_objBIHCanExecOrder.m_strOrderID == objTempCanExecOrderArr[i2].m_strOrderID)
                            {
                                lbnSame = true;
                                break;
                            }
                        }
                        if (!lbnSame) return false;
                    }
                }
            }
            return true;
        }
        #endregion
        #region 请假验证
        /// <summary>
        /// 请假验证	{请假的人不能执行医嘱}
        /// 说明: 请假了,则不通过验证;
        /// </summary>
        /// <param name="alCanExecItem">医嘱基本信息对象{clsOrderBaseInfo}</param>
        /// <returns></returns>
        private bool PassCheckPatientIsLeave(ArrayList alCanExecItem)
        {
            bool blnRes = false;
            ArrayList alItem = new ArrayList();//存储监测过了的患者
            string strRegisterIDs = "";
            for (int i1 = 0; i1 < alCanExecItem.Count; i1++)
            {
                clsOrderBaseInfo objItem = ((clsOrderBaseInfo)alCanExecItem[i1]);
                string strRes = objItem.m_objBIHCanExecOrder.m_strRegisterID.Trim();
                if (!alItem.Contains(strRes))
                {
                    alItem.Add(strRes);
                    strRegisterIDs = (strRegisterIDs == "") ? (strRegisterIDs) : (strRegisterIDs + ",");
                    strRegisterIDs += "'" + strRes + "'";
                }
            }
            if (strRegisterIDs != "")
            {
                bool blnIsLeave = false;
                long lngRes = m_objManage.m_lngCheckPatientIsLeave(strRegisterIDs, out blnIsLeave);
                blnRes = (!blnIsLeave);
            }
            return blnRes;
        }
        #endregion
        #region 父子医嘱验证
        /// <summary>
        /// 父子医嘱验证
        /// </summary>
        /// <param name="alCanExecItem">医嘱基本信息对象</param>
        /// <returns></returns>
        private bool PassValidateFatherSonOrder(ArrayList alCanExecItem)
        {
            if (alCanExecItem.Count <= 0) return true;
            string strParentID = "", strOrderID = "";
            bool blnSame = false;
            for (int i1 = 0; i1 < alCanExecItem.Count; i1++)
            {
                strParentID = ((clsOrderBaseInfo)alCanExecItem[i1]).m_objBIHCanExecOrder.m_strParentID.Trim();//父级医嘱ID 
                if (strParentID == null || strParentID == "") continue;
                //if(父级医嘱没有选中) return false;
                blnSame = false;
                for (int i2 = 0; i2 < alCanExecItem.Count; i2++)
                {
                    strOrderID = ((clsOrderBaseInfo)alCanExecItem[i2]).m_objBIHCanExecOrder.m_strOrderID.Trim();
                    if (strParentID == strOrderID)
                    {
                        blnSame = true;
                        break;
                    }
                }
                if (!blnSame) return false;
            }
            return true;
        }
        #endregion
        #endregion
        #region 打印医嘱
        /// <summary>
        /// 打印医嘱
        /// </summary>
        public void m_PrintOrder()
        {
            //获取入院登记ID
            #region 获取入院登记ID
            string strRegisterID = "";
            ArrayList alSelectItem = new ArrayList();
            if (m_objViewer.m_tabMain.SelectedIndex == 0)//基本信息
            {
                if (m_objViewer.m_lsvOrderBaseInfo.CheckBoxes)
                {
                    alSelectItem = GetSelectListView(m_objViewer.m_lsvOrderBaseInfo);
                    if (alSelectItem.Count <= 0 || alSelectItem.Count > 1)
                    {
                        MessageBox.Show("打印对象不能确定，请选则一条记录！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    strRegisterID = ((clsOrderBaseInfo)alSelectItem[0]).m_objBIHCanExecOrder.m_strRegisterID;
                }
                else
                {
                    if (m_objViewer.m_lsvOrderBaseInfo.SelectedItems.Count != 1)
                    {
                        MessageBox.Show("打印对象不能确定，请选则一条记录！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    strRegisterID = ((clsOrderBaseInfo)m_objViewer.m_lsvOrderBaseInfo.SelectedItems[0].Tag).m_objBIHCanExecOrder.m_strRegisterID;
                }
            }
            else//费用信息
            {
                if (m_objViewer.m_lsvPatientChargeInfo.CheckBoxes)
                {
                    alSelectItem = GetSelectListView(m_objViewer.m_lsvPatientChargeInfo);
                    if (alSelectItem.Count <= 0 || alSelectItem.Count > 1)
                    {
                        MessageBox.Show("打印对象不能确定，请选则一条记录！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    strRegisterID = ((clsPatientChargeInfo)alSelectItem[0]).m_strRegisterID;
                }
                else
                {
                    if (m_objViewer.m_lsvPatientChargeInfo.SelectedItems.Count != 1)
                    {
                        MessageBox.Show("打印对象不能确定，请选则一条记录！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    strRegisterID = ((clsPatientChargeInfo)m_objViewer.m_lsvPatientChargeInfo.SelectedItems[0].Tag).m_strRegisterID;
                }
            }
            #endregion

            if (strRegisterID.Trim() == "") return;
            //显示打印设置页面
            frmPrintOrder objPrintOrder = new frmPrintOrder(strRegisterID);
            objPrintOrder.ShowDialog();
        }
        #endregion
        #region 菜单事件
        public void m_funPopup()
        {
            m_objViewer.ctuMenu.MenuItems[0].Enabled = false;
            if (m_objViewer.Work != 2 && m_objViewer.Work != 3) return;
            if (m_objViewer.m_lsvOrderBaseInfo.SelectedItems.Count == 1 && m_objViewer.m_lsvOrderBaseInfo.SelectedItems[0].Tag != null)
            {
                clsOrderBaseInfo objItem = (clsOrderBaseInfo)m_objViewer.m_lsvOrderBaseInfo.SelectedItems[0].Tag;
                if (objItem.m_objBIHCanExecOrder.m_intStatus == 1 || objItem.m_objBIHCanExecOrder.m_intStatus == 5)
                {
                    m_objViewer.ctuMenu.MenuItems[0].Enabled = true;
                    m_objViewer.ctuMenu.MenuItems[0].DefaultItem = true;
                }
            }
        }
        /// <summary>
        /// 退回医嘱
        /// </summary>
        public void m_funSendBackOrder()
        {
            if (m_objViewer.m_lsvOrderBaseInfo.SelectedItems.Count != 1) return;
            if (m_objViewer.m_lsvOrderBaseInfo.SelectedItems[0].Tag == null || (!(m_objViewer.m_lsvOrderBaseInfo.SelectedItems[0].Tag is clsOrderBaseInfo))) return;

            clsOrderBaseInfo objItem = (clsOrderBaseInfo)m_objViewer.m_lsvOrderBaseInfo.SelectedItems[0].Tag;
            if (objItem.m_objBIHCanExecOrder.m_intStatus != 1 && objItem.m_objBIHCanExecOrder.m_intStatus != 5)
            {
                return;
            }
             
            bool showBack = false;
            if (objItem.m_objBIHCanExecOrder.m_strParentID == null)
            {
                showBack = true;
            }
            else if (objItem.m_objBIHCanExecOrder.m_strParentID.ToString().Trim().Equals(""))
            {
                showBack = true;
            }
            else
            {
                ArrayList alCanExecItem = GetOrderBaseInfoByListView(2);
                for (int i = 0; i < alCanExecItem.Count; i++)
                {
                    if (((clsOrderBaseInfo)alCanExecItem[i]).m_objBIHCanExecOrder.m_strParentID.ToString().Trim().Equals(objItem.m_objBIHCanExecOrder.m_strOrderID.ToString().Trim()))
                    {
                        showBack = true;
                        break;
                    }
                }

            }
            //检查当前状态是否有子医嘱
            if (showBack)
            {
                int count = 0;
                for (int i = 0; i < m_objViewer.m_lsvOrderBaseInfo.Items.Count; i++)
                {
                    if (((clsOrderBaseInfo)m_objViewer.m_lsvOrderBaseInfo.Items[i].Tag).m_objBIHCanExecOrder.m_strParentID.ToString().Trim().Equals(objItem.m_objBIHCanExecOrder.m_strOrderID.ToString().Trim()))
                    {
                        count = 1;
                        break;
                    }
                }
                if (count == 1)
                {
                    showBack = true;
                }
                else
                {
                    showBack = false;
                }
            }



            if (showBack)
            {
                com.digitalwave.iCare.BIHOrder.frmConfirmOrderBack objfrmConfirmOrderBack = new frmConfirmOrderBack();
                objfrmConfirmOrderBack.m_strOrderID = objItem.m_objBIHCanExecOrder.m_strOrderID.ToString().Trim();
                objfrmConfirmOrderBack.m_strOrderName = objItem.m_objBIHCanExecOrder.m_strName.ToString().Trim();
                objfrmConfirmOrderBack.m_strPatientName = objItem.m_objBIHCanExecOrder.m_strPatientName.ToString().Trim();
                if (objfrmConfirmOrderBack.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }

            /*<=======================================================================*/
            com.digitalwave.iCare.BIHOrder.frmSendBackReason objfrmSendBackReason = new com.digitalwave.iCare.BIHOrder.frmSendBackReason();
            objfrmSendBackReason.m_txbOrderName.Text = objItem.m_objBIHCanExecOrder.m_strName.Trim();
            if (objfrmSendBackReason.ShowDialog() != DialogResult.OK)
                return;

            long lngRes = 0;
            
            if (showBack)
            {
                lngRes = m_objManage.m_lngReturnOrder(objItem.m_objBIHCanExecOrder.m_strOrderID, objfrmSendBackReason.m_txtReason.Text.Replace(",", "").Trim(), m_strOperatorID, m_strOperatorName, true);

            }
            else
            {
                lngRes = m_objManage.m_lngReturnOrder(objItem.m_objBIHCanExecOrder.m_strOrderID, objfrmSendBackReason.m_txtReason.Text.Replace(",", "").Trim(), m_strOperatorID, m_strOperatorName);

            }
            /*<=============================================================================================*/
            //报告结果
            if (lngRes <= 0)
            {
                MessageBox.Show("操作失败！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // 将选中的项目放入数组中
            ArrayList checkList = new ArrayList();

            for (int i = 0; i < m_objViewer.m_lsvOrderBaseInfo.CheckedItems.Count; i++)
            {
                checkList.Add(((clsOrderBaseInfo)m_objViewer.m_lsvOrderBaseInfo.CheckedItems[i].Tag).m_objBIHCanExecOrder.m_strOrderID.ToString().Trim());
            }
            /*<===============================================*/
            m_FindOrder();
            // 保留原有的非退回项目的数组
            for (int i = 0; i < m_objViewer.m_lsvOrderBaseInfo.Items.Count; i++)
            {
                if (checkList.Contains(((clsOrderBaseInfo)m_objViewer.m_lsvOrderBaseInfo.Items[i].Tag).m_objBIHCanExecOrder.m_strOrderID.ToString().Trim()))
                {
                    m_objViewer.m_lsvOrderBaseInfo.Items[i].Checked = true; ;
                }
            }
            /*<===============================================*/

        }
        #endregion
        #region ListView事件
        /// <summary>
        /// 业务说明：只有提交状态且长期医嘱才能设置为“补次”
        /// </summary>
        public void m_ItemActivateOrderBaseInfo()
        {
            if (m_objViewer.Work != 3) return;
            if (m_objViewer.m_lsvOrderBaseInfo.SelectedItems.Count <= 0 || m_objViewer.m_lsvOrderBaseInfo.SelectedItems.Count > 1) return;
            clsOrderBaseInfo objSelectItem = (clsOrderBaseInfo)m_objViewer.m_lsvOrderBaseInfo.SelectedItems[0].Tag;

            //补次	[位于第11列]
            #region 补次
            //			if(objSelectItem.m_objBIHCanExecOrder.m_intExecuteType==1 && objSelectItem.m_objBIHCanExecOrder.m_intStatus==1)
            //			{
            //				if(objSelectItem.m_intIsRecruit==1)
            //				{
            //					if(MessageBox.Show(m_objViewer,"当前为“补次”状态，确定“不补次”吗？","提示框？",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            //					{
            //						objSelectItem.m_intIsRecruit=0;
            //						m_objViewer.m_lsvOrderBaseInfo.SelectedItems[0].SubItems[11].Text ="";
            //						m_objViewer.m_lsvOrderBaseInfo.Refresh();
            //					}
            //				}
            //				else
            //				{
            //					if(MessageBox.Show(m_objViewer,"当前为“不补次”状态，确定“补次”吗？","提示框？",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            //					{
            //						objSelectItem.m_intIsRecruit=1;
            //						m_objViewer.m_lsvOrderBaseInfo.SelectedItems[0].SubItems[11].Text ="√";	
            //						m_objViewer.m_lsvOrderBaseInfo.Refresh();
            //					}
            //				}
            //			}
            #endregion

            #region 皮试	[皮试结果位于第13列]
            //			//如果要皮试则，显示皮试
            //			if(objSelectItem.m_objBIHCanExecOrder.m_intISNEEDFEEL==1)
            //			{
            //				//显示皮试录入页面
            //				clsFeelEdit objFellEdit =new clsFeelEdit();
            //				objFellEdit.m_strOrderID =objSelectItem.m_objBIHCanExecOrder.m_strOrderID;
            //				objFellEdit.m_strPatientName =objSelectItem.m_objBIHCanExecOrder.m_strPatientName;
            //				objFellEdit.m_strOrderName =objSelectItem.m_objBIHCanExecOrder.m_strName;
            //				frmNeedFeel objfrmNeedFeel =new frmNeedFeel(objFellEdit);
            //				objfrmNeedFeel.ShowDialog();
            //
            //				//刷新页面
            //				if(objFellEdit.m_intExitState>0)
            //				{
            //					m_objViewer.m_lsvOrderBaseInfo.SelectedItems[0].SubItems[13].Text =objFellEdit.m_strFeelResult;
            //					m_objViewer.m_lsvOrderBaseInfo.Refresh();
            //				}
            //			}
            #endregion
        }
        public void m_ItemCheckPatientChargeInfo(System.Windows.Forms.ItemCheckEventArgs e)
        {
            clsPatientChargeInfo objCur = (clsPatientChargeInfo)m_objViewer.m_lsvPatientChargeInfo.Items[e.Index].Tag;
            if (m_objViewer.m_lsvPatientChargeInfo.Items[e.Index].Checked)
            {
                for (int i1 = 0; i1 < m_objViewer.m_lsvOrderBaseInfo.Items.Count; i1++)
                {
                    clsOrderBaseInfo objItem = (clsOrderBaseInfo)m_objViewer.m_lsvOrderBaseInfo.Items[i1].Tag;
                    //if(入院登记ID相同 && 选中) 不选中
                    if (objItem.m_objBIHCanExecOrder.m_strRegisterID.Trim() == objCur.m_strRegisterID.Trim() && m_objViewer.m_lsvOrderBaseInfo.Items[i1].Checked)
                        m_objViewer.m_lsvOrderBaseInfo.Items[i1].Checked = false;
                }
            }
            else
            {
                for (int i1 = 0; i1 < m_objViewer.m_lsvOrderBaseInfo.Items.Count; i1++)
                {
                    clsOrderBaseInfo objItem = (clsOrderBaseInfo)m_objViewer.m_lsvOrderBaseInfo.Items[i1].Tag;
                    //if(入院登记ID相同 && 没选中) 选中
                    if (objItem.m_objBIHCanExecOrder.m_strRegisterID.Trim() == objCur.m_strRegisterID.Trim() && (!m_objViewer.m_lsvOrderBaseInfo.Items[i1].Checked))
                        m_objViewer.m_lsvOrderBaseInfo.Items[i1].Checked = true;
                }
            }
        }
        /// <summary>
        /// 选中项改变的事件
        /// </summary>
        public void m_SelectedIndexChangedOrderBaseInfo()
        {
            if (m_objViewer.m_lsvOrderBaseInfo.SelectedItems.Count != 1)
            {
                m_objViewer.m_lsvToolTip.Items.Clear();
                return;
            }
            clsOrderBaseInfo objSelectItem = (clsOrderBaseInfo)m_objViewer.m_lsvOrderBaseInfo.SelectedItems[0].Tag;
            //显示费用信息
            m_DisPlayToolTipListView(objSelectItem, m_objViewer.m_lsvToolTip);
 
            /*
			if(m_objViewer.m_lsvOrderBaseInfo.SelectedItems.Count<=0 || m_objViewer.m_lsvOrderBaseInfo.SelectedItems.Count>1)
			{
				m_objViewer.cmdEditFeel.Enabled =false;
				m_objViewer.cmdOnceAgain.Enabled =false;
				m_objViewer.cmdOnceAgain.Text ="补次(F3)";
				return;
			}
			//补次	[位于第10列]	{业务说明:审核之后,执行之间才能编辑}	{if(首次执行 && 状态为通过审核 && 类型为药品) then 默认为补次}
			if(m_objViewer.Work==3 && objSelectItem.m_objBIHCanExecOrder.m_intExecuteType==1 && objSelectItem.m_objBIHCanExecOrder.m_intStatus==5)
			{
				m_objViewer.cmdOnceAgain.Enabled =true;
				if(objSelectItem.m_intIsRecruit==1)
					m_objViewer.cmdOnceAgain.Text ="不补次(F3)";
				else
					m_objViewer.cmdOnceAgain.Text ="补次(F3)";
			}
			else
			{
				m_objViewer.cmdOnceAgain.Enabled =false;
			}
             */
            //皮试	[皮试结果位于第12列]	{业务说明:审核之后,执行之间才能编辑}
            if (m_objViewer.Work == 3 && objSelectItem.m_objBIHCanExecOrder.m_intISNEEDFEEL == 1)
                m_objViewer.cmdEditFeel.Enabled = true;
            else
                m_objViewer.cmdEditFeel.Enabled = false;

            //审核停止	{业务说明: 只有长期医嘱才需要停止医嘱功能}
            if (m_objViewer.Work == 4)
            {
                if (objSelectItem.m_objBIHCanExecOrder.m_intExecuteType == 1 && objSelectItem.m_objBIHCanExecOrder.m_intStatus == 3)
                {
                    m_objViewer.m_cmdExecute.Enabled = true;
                }
                else
                {
                    m_objViewer.m_cmdExecute.Enabled = false;
                }
            }
        }
        #endregion
        #region 其他
        /// <summary>
        /// 补次
        /// </summary>
        public void m_OnceAgain()
        { 
            //if (m_objViewer.Work != 3) return;
            //if (m_objViewer.m_lsvOrderBaseInfo.SelectedItems.Count <= 0 || m_objViewer.m_lsvOrderBaseInfo.SelectedItems.Count > 1) return; 
            //clsOrderBaseInfo objSelectItem = (clsOrderBaseInfo)m_objViewer.m_lsvOrderBaseInfo.SelectedItems[0].Tag;
            //if (objSelectItem.m_objBIHCanExecOrder.m_intExecuteType == 1 && objSelectItem.m_objBIHCanExecOrder.m_intStatus == 5)
            //{
            //    if (objSelectItem.m_intIsRecruit == 1)
            //    {
            //        //if(MessageBox.Show(m_objViewer,"当前为“补次”状态，确定“不补次”吗？","提示框？",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            //        {
            //            objSelectItem.m_intIsRecruit = 0; 
            //            /*---------------------------------------------------->
            //            m_objViewer.m_lsvOrderBaseInfo.SelectedItems[0].SubItems[12].Text ="";
            //             */

            //            m_objViewer.m_lsvOrderBaseInfo.SelectedItems[0].SubItems[13].Text = "";

            //            /*<========================================================*/
            //            m_objViewer.m_lsvOrderBaseInfo.Refresh();
            //        }
            //    }
            //    else
            //    {
            //        //if(MessageBox.Show(m_objViewer,"当前为“不补次”状态，确定“补次”吗？","提示框？",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            //        {
            //            objSelectItem.m_intIsRecruit = 1; 
            //            /*
            //            m_objViewer.m_lsvOrderBaseInfo.SelectedItems[0].SubItems[12].Text ="√";	
            //             */
            //            m_objViewer.m_lsvOrderBaseInfo.SelectedItems[0].SubItems[13].Text = "√";

            //            /*<===================================================================*/
            //            m_objViewer.m_lsvOrderBaseInfo.Refresh();
            //        }
            //    }
            //}

            if (m_objViewer.Work != 3) return;
            if (m_objViewer.m_lsvOrderBaseInfo.CheckedItems.Count <= 0)
            {
                MessageBox.Show("没有选中可进行补次的项！");
                return;
            }
            else
            {
                int count = 0;
                for (int i = 0; i < m_objViewer.m_lsvOrderBaseInfo.CheckedItems.Count; i++)
                {

                    clsOrderBaseInfo objSelectItem = (clsOrderBaseInfo)m_objViewer.m_lsvOrderBaseInfo.CheckedItems[i].Tag;
                    if (objSelectItem.m_objBIHCanExecOrder.m_intExecuteType == 1 && objSelectItem.m_objBIHCanExecOrder.m_intStatus == 5)
                    {
                        count++;
                        break;
                    }
                }
                if (count < 0)
                {
                    MessageBox.Show("没有选中可进行补次的项！");
                    return;
                }
            }
            //将列表相应存入数组中。－－以方便父子医嘱补次同步
            ArrayList m_arrtemp = new ArrayList();

            /*<========================================================*/
            DialogResult m_dlgResult = m_objViewer2.ShowDialog();
            if (m_dlgResult == DialogResult.Cancel)
            {
                return;
            }
            else if (m_dlgResult == DialogResult.Yes)
            {
                for (int i = 0; i < m_objViewer.m_lsvOrderBaseInfo.CheckedItems.Count; i++)
                {
                    clsOrderBaseInfo objSelectItem = (clsOrderBaseInfo)m_objViewer.m_lsvOrderBaseInfo.CheckedItems[i].Tag;
                    if (objSelectItem.m_objBIHCanExecOrder.m_intExecuteType == 1 && objSelectItem.m_objBIHCanExecOrder.m_intStatus == 5)
                    {
                        objSelectItem.m_intIsRecruit = 1;
                        m_objViewer.m_lsvOrderBaseInfo.CheckedItems[i].SubItems[13].Text = "√";
                        if (objSelectItem.m_objBIHCanExecOrder.m_strParentID.Trim() != "")
                        {
                            m_arrtemp.Add(objSelectItem.m_objBIHCanExecOrder.m_strParentID.Trim());
                        }
                        else
                        {
                            m_arrtemp.Add(objSelectItem.m_objBIHCanExecOrder.m_strOrderID.Trim());
                        }

                    }
                }
                //父子医嘱补次同步
                for (int i = 0; i < m_objViewer.m_lsvOrderBaseInfo.Items.Count; i++)
                {
                    clsOrderBaseInfo objSelectItem = (clsOrderBaseInfo)m_objViewer.m_lsvOrderBaseInfo.Items[i].Tag;
                    if (objSelectItem.m_objBIHCanExecOrder.m_intExecuteType == 1 && objSelectItem.m_objBIHCanExecOrder.m_intStatus == 5)
                    {

                        if (m_arrtemp.Contains(objSelectItem.m_objBIHCanExecOrder.m_strOrderID.Trim()))
                        {
                            m_objViewer.m_lsvOrderBaseInfo.Items[i].SubItems[13].Text = "√";
                            objSelectItem.m_intIsRecruit = 1;
                        }
                        else
                        {
                            if (m_arrtemp.Contains(objSelectItem.m_objBIHCanExecOrder.m_strParentID.Trim()))
                            {
                                m_objViewer.m_lsvOrderBaseInfo.Items[i].SubItems[13].Text = "√";
                                objSelectItem.m_intIsRecruit = 1;
                            }
                        }
                    }
                }

                m_objViewer.m_lsvOrderBaseInfo.Refresh();
            }
            else if (m_dlgResult == DialogResult.No)
            {
                for (int i = 0; i < m_objViewer.m_lsvOrderBaseInfo.CheckedItems.Count; i++)
                {
                    clsOrderBaseInfo objSelectItem = (clsOrderBaseInfo)m_objViewer.m_lsvOrderBaseInfo.CheckedItems[i].Tag;
                    if (objSelectItem.m_objBIHCanExecOrder.m_intExecuteType == 1 && objSelectItem.m_objBIHCanExecOrder.m_intStatus == 5)
                    {
                        objSelectItem.m_intIsRecruit = 0;
                        m_objViewer.m_lsvOrderBaseInfo.CheckedItems[i].SubItems[13].Text = "";
                        if (objSelectItem.m_objBIHCanExecOrder.m_strParentID.Trim() != "")
                        {
                            m_arrtemp.Add(objSelectItem.m_objBIHCanExecOrder.m_strParentID.Trim());
                        }
                        else
                        {
                            m_arrtemp.Add(objSelectItem.m_objBIHCanExecOrder.m_strOrderID.Trim());
                        }
                    }
                }
                //父子医嘱补次同步
                for (int i = 0; i < m_objViewer.m_lsvOrderBaseInfo.Items.Count; i++)
                {
                    clsOrderBaseInfo objSelectItem = (clsOrderBaseInfo)m_objViewer.m_lsvOrderBaseInfo.Items[i].Tag;
                    if (objSelectItem.m_objBIHCanExecOrder.m_intExecuteType == 1 && objSelectItem.m_objBIHCanExecOrder.m_intStatus == 5)
                    {

                        if (m_arrtemp.Contains(objSelectItem.m_objBIHCanExecOrder.m_strOrderID.Trim()))
                        {
                            m_objViewer.m_lsvOrderBaseInfo.Items[i].SubItems[13].Text = "";
                            objSelectItem.m_intIsRecruit = 0;
                        }
                        else
                        {
                            if (m_arrtemp.Contains(objSelectItem.m_objBIHCanExecOrder.m_strParentID.Trim()))
                            {
                                m_objViewer.m_lsvOrderBaseInfo.Items[i].SubItems[13].Text = "";
                                objSelectItem.m_intIsRecruit = 0;
                            }
                        }
                    }
                }
                /*<========================================================*/
                m_objViewer.m_lsvOrderBaseInfo.Refresh();
            }
            else
            {
                return;
            }

            /*<======================================================================*/
        }
        /// <summary>
        /// 编辑皮试
        /// </summary>
        public void m_EditFeel()
        {
            //if(m_objViewer.Work!=3) return;
            if (m_objViewer.m_lsvOrderBaseInfo.SelectedItems.Count != 1) return;
            clsOrderBaseInfo objSelectItem = (clsOrderBaseInfo)m_objViewer.m_lsvOrderBaseInfo.SelectedItems[0].Tag;
            //如果要皮试则，显示皮试
            if (objSelectItem.m_objBIHCanExecOrder.m_intISNEEDFEEL == 1)
            {
                //显示皮试录入页面
                clsFeelEdit objFellEdit = new clsFeelEdit();
                objFellEdit.m_strOrderID = objSelectItem.m_objBIHCanExecOrder.m_strOrderID;
                objFellEdit.m_strPatientName = objSelectItem.m_objBIHCanExecOrder.m_strPatientName;
                objFellEdit.m_strOrderName = objSelectItem.m_objBIHCanExecOrder.m_strName;
                frmNeedFeel objfrmNeedFeel = new frmNeedFeel(objFellEdit);
                objfrmNeedFeel.ShowDialog();

                //刷新页面
                if (objFellEdit.m_intExitState > 0)
                {
                    m_objViewer.m_lsvOrderBaseInfo.SelectedItems[0].SubItems[14].Text = objFellEdit.m_strFeelResult;
                    m_objViewer.m_lsvOrderBaseInfo.Refresh();
                    //设置缓存区
                    GetOrderFeelFromBuffer(objSelectItem.m_objBIHCanExecOrder.m_strOrderID, true);
                }
            }
        }
        #endregion
        #endregion
        #region 私有方法
        #region 邦定ListView
        /// <summary>
        /// 邦定ListView	{医嘱基本信息、医嘱费用信息}
        /// </summary>
        /// <param name="p_objItemArr">可执行医嘱对象</param>
        public void DataBindListView()
        {
            ClearListView();
            if (m_objBIHCanExecOrderArr == null || m_objBIHCanExecOrderArr.Length <= 0) return;

            ArrayList alOrderBaseInfo = new ArrayList();
            alOrderBaseInfo = GetOrderBaseInfo(m_objBIHCanExecOrderArr);
            DataBind_OrderBaseInfo(alOrderBaseInfo);

            ArrayList alItem = new ArrayList();
            alItem = GetPatientChargeInfo(alOrderBaseInfo);
            DataBind_PatientChargeInfo(alItem);
        }
        /// <summary>
        /// 邦定医嘱基本信息	LisView
        /// clsOrderBaseInfo
        /// </summary>
        /// <param name="p_alItem">医嘱基本信息对象</param>
        private void DataBind_OrderBaseInfo(ArrayList p_alItem)
        {
            m_objViewer.m_btnAddBills.Enabled = false;
            m_objViewer.m_lsvOrderBaseInfo.Items.Clear();
            if (p_alItem == null || p_alItem.Count <= 0) return;
            #region 填充信息
            ListViewItem lviTemp = null;
            clsT_Opr_Bih_OrderFeel_VO objTem;
            clsBIHCanExecOrder objItem = new clsBIHCanExecOrder();
            for (int i1 = 0; i1 < p_alItem.Count; i1++)
            {
                objItem = ((clsOrderBaseInfo)p_alItem[i1]).m_objBIHCanExecOrder;
                //序号
                lviTemp = new ListViewItem((i1 + 1).ToString());
                if (i1 > 0 && objItem.m_strRegisterID.Trim() == ((clsOrderBaseInfo)p_alItem[i1 - 1]).m_objBIHCanExecOrder.m_strRegisterID.Trim())
                {
                    //床号
                    lviTemp.SubItems.Add("");
                    //姓名
                    lviTemp.SubItems.Add("");
                }
                else
                {
                    //床号
                    lviTemp.SubItems.Add(objItem.m_strBedName);
                    //姓名
                    lviTemp.SubItems.Add(objItem.m_strPatientName);
                }
                //方号
                lviTemp.SubItems.Add(objItem.m_intRecipenNo.ToString());
                //长/临
                if (objItem.m_intExecuteType == 1)
                {
                    lviTemp.SubItems.Add("长");
                }
                else
                {
                    if (objItem.m_intExecuteType == 2)
                        lviTemp.SubItems.Add("临");
                    else
                        lviTemp.SubItems.Add("");
                }

                //Add by jli in 2005-04-20

                //DataTable dtbAddBills=new DataTable();
                //long lngRet=this.m_objViewer.m_lngGetAddBillByOrderID(objItem.m_strOrderID.Trim(),out dtbAddBills);
                if (objItem.m_strATTARELAID_CHR != null && objItem.m_strATTARELAID_CHR != "")
                {
                    lviTemp.SubItems.Add("◆");
                    m_objViewer.m_btnAddBills.Enabled = true;
                }
                else
                {
                    lviTemp.SubItems.Add("");
                }

                //Add End

                //医嘱名称
                lviTemp.SubItems.Add(objItem.m_strName);
                //嘱托
                lviTemp.SubItems.Add(objItem.m_strEntrust);
                // 
                lviTemp.SubItems.Add(objItem.m_strSpec.ToString().Trim());
                /*<===========================================================*/
                //剂量（单位）
                if (objItem.m_dmlDosage > 0)
                    lviTemp.SubItems.Add(objItem.m_dmlDosage.ToString() + " " + objItem.m_strDosageUnit);
                else
                    lviTemp.SubItems.Add("");
                //用量（单位）
                //if(objItem.m_dmlUse>0)
                //	lviTemp.SubItems.Add(objItem.m_dmlUse.ToString() + " " + objItem.m_strUseunit);
                //else
                //	lviTemp.SubItems.Add("");
                //领量
                if (objItem.m_dmlGet > 0)
                    lviTemp.SubItems.Add(objItem.m_dmlGet.ToString() + " " + objItem.m_strGetunit);
                else
                    lviTemp.SubItems.Add("");
                //单价
                //lviTemp.SubItems.Add(objItem.m_dmlPrice.ToString("0.0000"));
                //执行频率
                lviTemp.SubItems.Add(objItem.m_strExecFreqName);
                //用药方式
                lviTemp.SubItems.Add(objItem.m_strDosetypeName);
                //补次	{if(首次执行 && 状态为提交 && 类型为药品) then 默认为补次}
                lviTemp.SubItems.Add((((clsOrderBaseInfo)p_alItem[i1]).m_intIsRecruit == 1) ? "√" : "");
                //皮试	皮试结果
                if (objItem.m_intISNEEDFEEL == 1)
                {
                    //是否皮试
                    lviTemp.SubItems.Add("√");
                    //皮试结果
                    objTem = GetOrderFeelFromBuffer(objItem.m_strOrderID, false);
                    //					objTem =null;
                    //					m_objManage.m_lngGetOrderFeelByOrderID(objItem.m_strOrderID,out objTem);
                    if (objTem != null && objTem.m_strORDERFEELID_CHR != null)
                    {
                        lviTemp.SubItems.Add(objTem.m_strResultTypeName);
                    }
                    else
                    {
                        lviTemp.SubItems.Add("");
                    }
                }
                else
                {
                    //是否皮试
                    lviTemp.SubItems.Add("");
                    //皮试结果
                    lviTemp.SubItems.Add("");
                }
                //父级医嘱
                lviTemp.SubItems.Add(objItem.m_strParentName);
                //开始时间
                lviTemp.SubItems.Add(DateTimeToString(objItem.m_dtStartDate));
                //停止人
                lviTemp.SubItems.Add(objItem.m_strStoper);
                //停止时间
                lviTemp.SubItems.Add(DateTimeToString(objItem.m_dtStopdate));
                //颜色设置(仅在背景色上区分长临嘱)
                #region 颜色设置
                System.Drawing.Color clrForeColor = System.Drawing.Color.Black, clrBackColor = System.Drawing.Color.White;
                switch (objItem.m_intStatus)//执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 审核提交;6-审核停止;}
                {
                    case 1://已经提交
                        clrForeColor = m_objViewer.m_lblNotExecute.BackColor;
                        break;
                    case 2://执行过
                        clrForeColor = m_objViewer.m_lblExecute.BackColor;
                        break;
                    case 3://已停止
                        clrForeColor = m_objViewer.m_lblStopExecute.BackColor;
                        break;
                    case 5://已审核提交
                        clrForeColor = m_objViewer.m_lblAuditingExecute.BackColor;
                        break;
                    case 6://已审核停止
                        clrForeColor = m_objViewer.m_lblAuditingStop.BackColor;
                        break;
                }
                if (objItem.m_intExecuteType == 1)
                    clrBackColor = m_objViewer.m_lblLong.BackColor;
                else
                    clrBackColor = m_objViewer.m_lblTemp.BackColor;
                lviTemp.BackColor = clrBackColor;
                lviTemp.ForeColor = clrForeColor;
                #endregion
                lviTemp.Tag = (clsOrderBaseInfo)p_alItem[i1];
                m_objViewer.m_lsvOrderBaseInfo.Items.Add(lviTemp);
            }
            #endregion
        }
        /// <summary>
        /// 邦定医嘱费用信息	LisView
        /// clsPatientChargeInfo
        /// </summary>
        /// <param name="p_alItem">医嘱费用信息对象</param>
        private void DataBind_PatientChargeInfo(ArrayList p_alItem)
        {
            m_objViewer.m_lsvPatientChargeInfo.Items.Clear();
            if (p_alItem == null || p_alItem.Count <= 0) return;
            #region 填充信息
            ListViewItem lviTemp = null;
            clsPatientChargeInfo objItem = new clsPatientChargeInfo();
            for (int i1 = 0; i1 < p_alItem.Count; i1++)
            {
                objItem = ((clsPatientChargeInfo)p_alItem[i1]);
                //床号
                lviTemp = new ListViewItem(objItem.m_strBedName);
                //姓名
                lviTemp.SubItems.Add(objItem.m_strPatientName);
                //费用下限
                lviTemp.SubItems.Add(objItem.m_dblLowerLimitMoney.ToString("0.00"));
                //累计费用
                lviTemp.SubItems.Add(objItem.m_dblSumMoney.ToString("0.00"));
                //余  额
                lviTemp.SubItems.Add(objItem.m_dblBalanceMoney.ToString("0.00"));
                //填充颜色	{业务说明：余额超过费用下限的均突出显示}
                #region 填充颜色
                if (objItem.m_dblBalanceMoney <= objItem.m_dblLowerLimitMoney)
                {
                    lviTemp.BackColor = System.Drawing.Color.Red;
                    lviTemp.ForeColor = System.Drawing.Color.Blue;
                }
                #endregion
                lviTemp.Tag = objItem;
                m_objViewer.m_lsvPatientChargeInfo.Items.Add(lviTemp);
            }
            #endregion
        }
        #endregion
        #region 获取对象	根据可执行医嘱对象
        /// <summary>
        /// 获取医嘱基本信息对象	[ArrayList]	供应ListView显示
        /// clsOrderBaseInfo
        /// </summary>
        /// <param name="p_objItemArr">可执行医嘱对象	[数组]</param>
        /// <returns></returns>
        private ArrayList GetOrderBaseInfo(clsBIHCanExecOrder[] p_objItemArr)
        {
            ArrayList alResult = new ArrayList();
            if (p_objItemArr == null || p_objItemArr.Length <= 0) return alResult;
            clsOrderBaseInfo objItem;
            for (int i1 = 0; i1 < p_objItemArr.Length; i1++)
            {
                if (!PassFilter(p_objItemArr[i1])) continue;
                objItem = new clsOrderBaseInfo();
                objItem.m_objBIHCanExecOrder = p_objItemArr[i1];
                //设置默认补次	
                #region 设置默认补次
                //业务说明：	{if(首次执行 && 状态为通过审核 && 类型为药品) then 默认为补次}
                if (m_strMedicineOrderTypeID.Trim() == "")
                {
                    m_strMedicineOrderTypeID = m_objManage.m_strGetMedicineOrderTypeID();
                }
                if (p_objItemArr[i1].m_intExecuteType == 1 && p_objItemArr[i1].m_intStatus == 5 && p_objItemArr[i1].m_strOrderDicCateID.Trim() == m_strMedicineOrderTypeID)
                {
                    objItem.m_intIsRecruit = 1;
                }
                else
                {
                    objItem.m_intIsRecruit = 0;
                }
                #endregion
                alResult.Add(objItem);
            }
            return alResult;
        }
        /// <summary>
        /// 获取医嘱费用信息对象	[ArrayList]
        /// clsPatientChargeInfo
        /// </summary>
        /// <param name="p_alItem">医嘱基本信息对象	[ArrayList]</param>
        /// <returns></returns>
        private ArrayList GetPatientChargeInfo(ArrayList p_alItem)
        {
            clsOrderBaseInfo[] p_objItemArr;
            p_objItemArr = (clsOrderBaseInfo[])(p_alItem.ToArray(typeof(clsOrderBaseInfo)));

            ArrayList alResult = new ArrayList();
            if (p_objItemArr == null || p_objItemArr.Length <= 0) return alResult;
            clsPatientChargeInfo objItem;
            bool blnExist = false;
            for (int i1 = 0; i1 < p_objItemArr.Length; i1++)
            {
                blnExist = false;
                for (int i2 = 0; i2 < alResult.Count; i2++)
                {
                    objItem = (clsPatientChargeInfo)alResult[i2];
                    if (objItem.m_strRegisterID.Trim() == p_objItemArr[i1].m_objBIHCanExecOrder.m_strRegisterID.Trim())
                    {
                        blnExist = true;
                        break;
                    }
                }
                if (!blnExist)
                {
                    objItem = new clsPatientChargeInfo();
                    #region 填充
                    double dblSumMoney = 0;			//累计费用
                    double dblBalanceMoney = 0;		//预交金余额
                    double dblLowerLimitMoney = 0;	//费用下限
                    try
                    {
                        dblSumMoney = m_objManage.m_dblGetSumMoneyByRegisterID(p_objItemArr[i1].m_objBIHCanExecOrder.m_strRegisterID);
                        dblBalanceMoney = m_objManage.m_dblGetBalanceMoneyByRegisterID(p_objItemArr[i1].m_objBIHCanExecOrder.m_strRegisterID);
                        dblLowerLimitMoney = m_objManage.m_dblGetLowerLimitMoneyByRegisterID(p_objItemArr[i1].m_objBIHCanExecOrder.m_strRegisterID);
                    }
                    catch { }
                    //入院登记ID
                    objItem.m_strRegisterID = p_objItemArr[i1].m_objBIHCanExecOrder.m_strRegisterID;
                    //病床号
                    objItem.m_strBedName = p_objItemArr[i1].m_objBIHCanExecOrder.m_strBedName;
                    //病人姓名
                    objItem.m_strPatientName = p_objItemArr[i1].m_objBIHCanExecOrder.m_strPatientName;
                    //累计费用
                    objItem.m_dblSumMoney = dblSumMoney;
                    //预交金余额
                    objItem.m_dblBalanceMoney = dblBalanceMoney;
                    //费用下限
                    objItem.m_dblLowerLimitMoney = dblLowerLimitMoney;
                    #endregion
                    alResult.Add(objItem);
                }
            }
            return alResult;
        }
        #endregion
        #region 过滤器
        /// <summary>
        /// 过滤器	过滤可执行医嘱对象以供ListView显示
        /// </summary>
        /// <param name="p_objItem">可执行医嘱对象</param>
        /// <returns></returns>
        private bool PassFilter(clsBIHCanExecOrder p_objItem)
        {
            if (p_objItem == null || p_objItem.m_strOrderID == null || p_objItem.m_strOrderID.Trim() == "") return false;
            //医嘱类型	{1=长期;2=临时}
            #region 医嘱类型
            if (!m_objViewer.m_chkLong.Checked)
            {
                if (p_objItem.m_intExecuteType == 1) return false;
            }
            if (!m_objViewer.m_chkTemp.Checked)
            {
                if (p_objItem.m_intExecuteType == 2) return false;
            }
            #endregion
            //执行状态	{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5-已审核提交;6-已审核停止;}
            #region 执行状态
            if (!m_objViewer.m_chkStatus1.Checked)
            {
                if (p_objItem.m_intStatus == 1) return false;
            }
            if ((!m_objViewer.m_chkStatus2.Checked))
            {
                if (p_objItem.m_intStatus == 2) return false;
            }
            if ((!m_objViewer.m_chkStatus3.Checked))
            {
                if (p_objItem.m_intStatus == 3) return false;
            }
            if ((!m_objViewer.m_chkStatus5.Checked))
            {
                if (p_objItem.m_intStatus == 5) return false;
            }
            if ((!m_objViewer.m_chkStatus6.Checked))
            {
                if (p_objItem.m_intStatus == 6) return false;
            }
            #endregion
            //出院摆药
            #region 出院摆药
            if ((m_objViewer.m_chktakeMedicine.Checked))
            {
                if (!(p_objItem.RateType == 4)) return false;
            }
            #endregion
            //仅显当天
            #region 仅显当天
            if ((m_objViewer.m_chkOnlyToday.Checked))
            {
                if (p_objItem.m_dtPostdate.ToString("yyyy-MM-dd") != System.DateTime.Now.ToString("yyyy-MM-dd")) return false;
            }
            #endregion
            //仅显皮试
            #region 仅显皮试
            if ((m_objViewer.m_chkNeedFeel.Checked))
            {
                if (p_objItem.m_intISNEEDFEEL != 1) return false;
            }
            #endregion
            //诊疗项目类型
            #region 诊疗项目类型
            if (m_objViewer.m_cobOrderCate.SelectedIndex > 0)
            {
                clsOrderCate objItem = (clsOrderCate)m_objViewer.m_cobOrderCate.SelectedItem;
                if (objItem.m_objOrderCate.m_strORDERCATEID_CHR != null && objItem.m_objOrderCate.m_strORDERCATEID_CHR.Trim() != "")
                {
                    //获取相同显示名称的 诊疗项目ID聚合
                    ArrayList alOrdercateID = new ArrayList();
                    for (int i1 = 0; i1 < m_objOrdercateArr.Length; i1++)
                    {
                        if (m_objOrdercateArr[i1].m_strVIEWNAME_VCHR.Trim() == objItem.m_objOrderCate.m_strVIEWNAME_VCHR.Trim())
                        {
                            if (!alOrdercateID.Contains(objItem.m_objOrderCate.m_strORDERCATEID_CHR.Trim()))
                            {
                                alOrdercateID.Add(objItem.m_objOrderCate.m_strORDERCATEID_CHR.Trim());
                            }
                        }
                    }

                    if (!alOrdercateID.Contains(p_objItem.m_strOrderDicCateID.Trim())) return false;
                }
            }
            #endregion
            //录入医生
            #region 录入医生
            if (m_objViewer.m_txtDoctor.Tag != null && m_objViewer.m_txtDoctor.Tag.ToString().Trim() != "" && m_objViewer.m_txtDoctor.Text.Trim() != "")
            {
                string strCreatorID = clsConverter.ToString(m_objViewer.m_txtDoctor.Tag).Trim();
                if (strCreatorID != "")
                {
                    if (p_objItem.m_strCreatorID.Trim() != strCreatorID) return false;
                }
            }
            #endregion
            return true;
        }
        #endregion
        #region 获取对象	根据ListView
        /// <summary>
        /// 获取医嘱基本信息对象	[ArrayList]	根据ListView
        /// clsOrderBaseInfo
        /// </summary>
        /// <param name="intCheckedState">是否选中{0=未选中;1=选中;2全部(默认)}</param>
        /// <returns></returns>
        private ArrayList GetOrderBaseInfoByListView(int intCheckedState)
        {
            ArrayList alResult = new ArrayList();
            for (int i1 = 0; i1 < m_objViewer.m_lsvOrderBaseInfo.Items.Count; i1++)
            {
                if (m_objViewer.m_lsvOrderBaseInfo.Items[i1].Tag != null)
                {
                    clsOrderBaseInfo objItem = (clsOrderBaseInfo)m_objViewer.m_lsvOrderBaseInfo.Items[i1].Tag;
                    switch (intCheckedState)
                    {
                        case 0://未选中
                            if (!m_objViewer.m_lsvOrderBaseInfo.Items[i1].Checked)
                            {
                                alResult.Add(objItem);
                            }
                            break;
                        case 1://选中
                            if (m_objViewer.m_lsvOrderBaseInfo.Items[i1].Checked)
                            {
                                alResult.Add(objItem);
                            }
                            break;
                        default://全部(默认)
                            alResult.Add(objItem);
                            break;
                    }
                }
            }
            return alResult;
        }
        #endregion
        #region 其他
        public DateTime m_dtLastValue = clsBIHOrder.m_dtNullDate;
        /// <summary>
        /// 转化时间To字符串
        /// </summary>
        /// <param name="dtValue">DataTime型</param>
        /// <returns></returns>
        private string DateTimeToString(DateTime dtValue)
        {
            if (dtValue.Date == clsBIHOrder.m_dtNullDate.Date)
                return "";
            else
                return dtValue.ToString("yyyy-MM-dd HH:mm");
        }
        /// <summary>
        /// 设置颜色
        /// </summary>
        private void SetOrderColor()
        {
            m_objViewer.m_lblTemp.BackColor = clsOrderColor.BackColorTemOrder;
            m_objViewer.m_lblLong.BackColor = clsOrderColor.BackColorLongOrder;
            m_objViewer.m_lblExecute.BackColor = clsOrderColor.ForeColorOrderStatus2;
            m_objViewer.m_lblNotExecute.BackColor = clsOrderColor.ForeColorOrderStatus1;
            m_objViewer.m_lblStopExecute.BackColor = clsOrderColor.ForeColorOrderStatus3;
            m_objViewer.m_lblCanNotExecute.BackColor = clsOrderColor.ForeColorCanNotExecute;
            /** @update by xzf (05-09-20) */
            //@m_objViewer.m_lblLowerLimitBackColor.BackColor =clsOrderColor.BackColorChargeUnderLowerLimit;
            /* m_objViewer.m_lblLowerLimitBackColor.BackColor =clsOrderColor.BackColorChargeUnderLowerLimit; */
            /* <<================================== */
            m_objViewer.m_lblAuditingExecute.BackColor = clsOrderColor.ForeColorOrderStatus5;
            m_objViewer.m_lblAuditingStop.BackColor = clsOrderColor.ForeColorOrderStatus6;
        }
        /// <summary>
        /// 获取ListView中的选种项	[获取对应的对象]
        /// </summary>
        /// <param name="lsvItem">ListView控件</param>
        /// <returns></returns>
        private ArrayList GetSelectListView(ListView lsvItem)
        {
            ArrayList alSeletcItem = new ArrayList();
            for (int i1 = 0; i1 < lsvItem.Items.Count; i1++)
            {
                if (lsvItem.Items[i1].Checked)
                {
                    alSeletcItem.Add(lsvItem.Items[i1].Tag);
                }
            }
            return alSeletcItem;
        }
        /// <summary>
        /// 提交医嘱执行单	[反射方法]
        /// </summary>
        /// <param name="strDllName">Dll名</param>
        /// <param name="strClassName">Class名</param>
        /// <param name="strCommitAttachOrder">方法名</param>
        /// <param name="strOrderID">医嘱ID</param>
        /// <returns></returns>
        private long lngCommitAttachOrder(string strDllName, string strClassName, string strCommitAttachOrder, string strOrderID)
        {
            if (strDllName.Trim() == "" || strClassName.Trim() == "" || strCommitAttachOrder.Trim() == "" || strOrderID.Trim() == "") return -1;
            long lngRes = 1;
            try
            {
                System.Reflection.Assembly objAsm = System.Reflection.Assembly.LoadFrom(strDllName);
                if (objAsm == null) return -1;
                //设置参数
                object[] objParams = new object[1];
                objParams[0] = strOrderID;
                object obj = objAsm.CreateInstance(strClassName, true);
                if (obj == null) return -1;
                int intIndex = strCommitAttachOrder.IndexOf("(");
                string strMethodName = strCommitAttachOrder.Substring(0, intIndex);
                Type objType = obj.GetType();
                System.Reflection.MethodInfo objMi = objType.GetMethod(strMethodName);
                if (objMi == null) return -1;
                objMi.Invoke(obj, objParams);
            }
            catch
            {
                lngRes = -1;
            }
            return lngRes;
        }
        /// <summary>
        /// 显示费用明细
        /// </summary>
        /// <param name="arrOrderExecID">执行单	[数组]</param>
        public void m_mthShowChargeItemList(string[] arrOrderExecID)
        {
            frmBIHChargeItemList objfrmBIHChargeItemList = new frmBIHChargeItemList();

            objfrmBIHChargeItemList.m_mthSetCurrentArea(clsConverter.ToString(m_objViewer.m_txtArea.Tag), m_objViewer.m_txtArea.Text);
            if (m_objViewer.m_txtBed.Tag == null) m_objViewer.m_txtBed.Tag = "";
            objfrmBIHChargeItemList.m_mthSetBed(m_objViewer.m_txtBed.Tag.ToString());
            objfrmBIHChargeItemList.m_mthSetDoctor(clsConverter.ToString(m_objViewer.m_txtDoctor.Tag), m_objViewer.m_txtDoctor.Text);
            objfrmBIHChargeItemList.m_mthSetExecuteDate(m_objViewer.m_dtpStartExecute.Value);
            objfrmBIHChargeItemList.m_mthSetCurrentDoctor(m_strOperatorID, m_strOperatorName);

            objfrmBIHChargeItemList.m_mthSetOrderList(arrOrderExecID);
            if (m_objViewer.MdiParent != null) objfrmBIHChargeItemList.MdiParent = m_objViewer.MdiParent;
            objfrmBIHChargeItemList.Show();
            objfrmBIHChargeItemList.BringToFront();
        }
        #endregion
        #endregion
        #region 病区、病床
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
                //LoadBedListView();
            }
        }
        public void m_txtBedKeyDown()
        {
            LoadBedListView();

            //载入数据	
            #region 载入数据
            if (m_objViewer.m_txtBed.Tag == null) m_objViewer.m_txtBed.Tag = "";
            string strID = m_objViewer.m_txtBed.Tag.ToString().Trim();
            string[] strIDArr = strID.Split(new char[] { ',' });
            if (strIDArr != null && strIDArr.Length > 0)
            {
                for (int i = 0; i < m_objViewer.m_lsvSelectBed.Items.Count; i++)
                {
                    clsT_Bse_Bed_VO objItem = (m_objViewer.m_lsvSelectBed.Items[i].Tag as clsT_Bse_Bed_VO);
                    if (objItem == null) continue;
                    strID = objItem.m_strBEDID_CHR.Trim();
                    m_objViewer.m_lsvSelectBed.Items[i].Checked = false;
                    for (int j = 0; j < strIDArr.Length; j++)
                    {
                        if (strID == strIDArr[j].Trim())
                        {
                            m_objViewer.m_lsvSelectBed.Items[i].Checked = true;
                            break;
                        }
                    }
                }
            }
            #endregion
            m_objViewer.m_lsvSelectBed.Visible = true;
            m_objViewer.m_lsvSelectBed.Focus();
        }
        /// <summary>
        /// 载入病床信息
        /// </summary>
        public void LoadBedListView()
        {
            m_objViewer.m_txtBed.Text = "";
            m_objViewer.m_txtBed.Tag = "";
            m_objViewer.m_lsvSelectBed.Items.Clear();
            if (m_objViewer.m_txtArea.Tag == null) m_objViewer.m_txtArea.Tag = "";
            string strAreaID = m_objViewer.m_txtArea.Tag.ToString().Trim();
            if (strAreaID.Trim() == "") return;
            clsT_Bse_Bed_VO[] objItemArr;
            long lngRes = m_objInputOrder.m_lngGetBedInfoByAreaID(strAreaID, out objItemArr);
            if (lngRes > 0 && objItemArr != null && objItemArr.Length > 0)
            {
                #region 填充ListView
                ListViewItem lviTemp = null;
                for (int i1 = 0; i1 < objItemArr.Length; i1++)
                {
                    //序号
                    //lviTemp = new ListViewItem((i1+1).ToString());
                    //床号
                    //lviTemp.SubItems.Add(objItemArr[i1].m_strCODE_CHR);
                    //类别
                    //lviTemp.SubItems.Add(objItemArr[i1].m_strSexName);
                    //占床状态
                    //lviTemp.SubItems.Add(objItemArr[i1].m_strStatusName);		
                    lviTemp = new ListViewItem(objItemArr[i1].m_strCODE_CHR);
                    lviTemp.SubItems.Add(objItemArr[i1].m_strPatientName.Trim());
                    lviTemp.SubItems.Add(objItemArr[i1].m_strPatientSex.Trim());

                    lviTemp.Tag = objItemArr[i1];
                    m_objViewer.m_lsvSelectBed.Items.Add(lviTemp);
                }
                #endregion
            }
        }
        /// <summary>
        /// 分隔符","号	Text保存床号	Tag保存ID
        /// </summary>
        public void m_lsvSelectBedLeave()
        {
            string strText = "";
            string strID = "";
            clsT_Bse_Bed_VO objItem = new clsT_Bse_Bed_VO();
            for (int i1 = 0; i1 < m_objViewer.m_lsvSelectBed.Items.Count; i1++)
            {
                objItem = ((m_objViewer.m_lsvSelectBed.Items[i1].Tag) as clsT_Bse_Bed_VO);
                if (m_objViewer.m_lsvSelectBed.Items[i1].Checked)
                {
                    if (strText.Length > 0)
                    {
                        strText += ",";
                        strID += ",";
                    }
                    strText += objItem.m_strCODE_CHR.Trim();
                    strID += objItem.m_strBEDID_CHR.Trim();
                }
            }
            m_objViewer.m_txtBed.Text = strText;
            m_objViewer.m_txtBed.Tag = strID;
            m_objViewer.m_lsvSelectBed.Visible = false;
        }
        #endregion
        #region 显示费用信息
        /// <summary>
        /// 存储费用信息	[缓存作用] {医嘱ID[关键字],费用对象(ArrayList)}
        /// </summary>
        public System.Collections.Hashtable m_htbToolTip = new Hashtable();
        /// <summary>
        /// 绑定ListView的信息ToolTip
        /// </summary>
        /// <param name="p_objItem">医嘱记录对象</param>
        /// <param name="p_lsvToolTip">ListView 控件</param>
        /// <returns></returns>
        /// 业务说明：
        ///		1、自备等不收取病人费用的医嘱，在医生或护士处查看收费明细时，都不应该显示出来；
        /// </remarks>
        public void m_DisPlayToolTipListView(clsOrderBaseInfo p_objItem, System.Windows.Forms.ListView p_lsvToolTip)
        {
            p_lsvToolTip.Items.Clear();
            string strOrderID = p_objItem.m_objBIHCanExecOrder.m_strOrderID.Trim();
            if ((p_objItem.m_objBIHCanExecOrder.m_intExecuteType == 2 && p_objItem.m_objBIHCanExecOrder.m_intIsRepare >= 3 && p_objItem.m_objBIHCanExecOrder.m_intIsRepare <= 4))
            {
                if (m_htbToolTip.ContainsKey(strOrderID))
                {
                    m_htbToolTip.Remove(strOrderID);
                }
                return;
            }
            else
            {
                if (!m_htbToolTip.ContainsKey(strOrderID))
                {
                    FillToolTipHashtable(p_objItem);
                }
            }
            if (m_htbToolTip.ContainsKey(strOrderID))
            {
                ArrayList alItem = new ArrayList();
                alItem = (m_htbToolTip[strOrderID] as ArrayList);
                if (alItem != null && alItem.Count > 0)
                {
                    clsChargeForDisplay[] objItemArr = (clsChargeForDisplay[])(alItem.ToArray(typeof(clsChargeForDisplay)));
                    //显示ListView
                    m_objInputOrder.DisplayCharge(objItemArr, p_lsvToolTip);
                }
            }
        }
        /// <summary>
        /// 给哈希表填值 ToopTip
        /// </summary>
        /// <param name="p_objItem">医嘱记录对象</param>
        /// <returns></returns>
        private void FillToolTipHashtable(clsOrderBaseInfo p_objItem)
        {
            long lngRes = 0;
            if (p_objItem == null || p_objItem.m_objBIHCanExecOrder.m_strOrderID == null || p_objItem.m_objBIHCanExecOrder.m_strOrderID.Trim() == "") return;
            //获取医嘱ID
            string strOrderID = p_objItem.m_objBIHCanExecOrder.m_strOrderID.Trim();
            //主收费的领量
            double dblNumber = System.Convert.ToDouble(p_objItem.m_objBIHCanExecOrder.m_dmlGet);
            clsT_aid_bih_ordercate_VO objOrdercate;
            lngRes = m_objInputOrder.m_lngGetAidOrderCateByID(p_objItem.m_objBIHCanExecOrder.m_strOrderDicCateID, out objOrdercate);
            if (lngRes > 0 && objOrdercate != null && objOrdercate.m_intDOSAGEVIEWTYPE == 2) dblNumber = 1;
            //执行频率ID
            string strFreqID = p_objItem.m_objBIHCanExecOrder.m_strExecFreqID;
            //用法ID
            string strUsageID = p_objItem.m_objBIHCanExecOrder.m_strDosetypeID;
            //是否子级医嘱	{0=非子级医嘱;1=子级医嘱}
            int intIsSonOrder = 0;
            if (p_objItem.m_objBIHCanExecOrder != null && p_objItem.m_objBIHCanExecOrder.m_strParentID != null && p_objItem.m_objBIHCanExecOrder.m_strParentID.Trim() != "")
                intIsSonOrder = 1;

            clsChargeForDisplay[] objItemArr;
            lngRes = m_objInputOrder.m_lngGetBIHCharge(strOrderID, intIsSonOrder, dblNumber, strFreqID, strUsageID, out objItemArr);
            if (objItemArr != null && objItemArr.Length > 0)
            {
                ArrayList alItem = new ArrayList();
                for (int i1 = 0; i1 < objItemArr.Length; i1++)
                {
                    alItem.Add(objItemArr[i1]);
                }
                if (alItem != null && alItem.Count > 0 && (!m_htbToolTip.ContainsKey(strOrderID)))
                {
                    m_htbToolTip.Add(strOrderID, alItem);
                }
            }
        }
        /// <summary>
        /// 获取医嘱皮试结果对象	[从缓冲区]
        /// </summary>
        /// <param name="p_strOrderID">医嘱ID</param>
        /// <param name="p_blnRefurbish">是否刷新缓存区中的对应缓存数据	{不存在则填充,存在则刷新}</param>
        private clsT_Opr_Bih_OrderFeel_VO GetOrderFeelFromBuffer(string p_strOrderID, bool p_blnRefurbish)
        {
            clsT_Opr_Bih_OrderFeel_VO objItem = new clsT_Opr_Bih_OrderFeel_VO();
            if (!m_htbToolTip.ContainsKey("ORDERFEEL" + p_strOrderID.Trim()))//{Key="ORDERFEEL"+医嘱ID}
            {
                long lngRes = m_objManage.m_lngGetOrderFeelByOrderID(p_strOrderID, out objItem);
                if (lngRes > 0 && objItem != null && objItem.m_strORDERID_CHR != null && objItem.m_strORDERID_CHR.Trim() != "")
                {
                    m_htbToolTip.Add("ORDERFEEL" + p_strOrderID.Trim(), objItem);
                }
            }
            else if (p_blnRefurbish)
            {
                long lngRes = m_objManage.m_lngGetOrderFeelByOrderID(p_strOrderID, out objItem);
                if (lngRes > 0 && objItem != null && objItem.m_strORDERID_CHR != null && objItem.m_strORDERID_CHR.Trim() != "")
                {
                    m_htbToolTip["ORDERFEEL" + p_strOrderID.Trim()] = objItem;
                }
            }
            else
            {
                objItem = (m_htbToolTip["ORDERFEEL" + p_strOrderID.Trim()] as clsT_Opr_Bih_OrderFeel_VO);
            }
            return objItem;
        }
        /// <summary>
        /// 清空缓存数据
        /// </summary>
        public void m_ClearBuffer()
        {
            m_htbToolTip.Clear();
        }
        #endregion
        #region 内部用的类
        /// <summary>
        /// 医嘱费用信息对象
        /// </summary>
        public class clsPatientChargeInfo
        {
            public clsPatientChargeInfo()
            { }
            /// <summary>
            /// 入院登记ID
            /// </summary>
            public string m_strRegisterID = "";
            /// <summary>
            /// 病床号
            /// </summary>
            public string m_strBedName = "";
            /// <summary>
            /// 病人姓名
            /// </summary>
            public string m_strPatientName = "";
            /// <summary>
            /// 累计费用
            /// </summary>
            public double m_dblSumMoney = 0;
            /// <summary>
            /// 预交金余额
            /// </summary>
            public double m_dblBalanceMoney = 0;
            /// <summary>
            /// 费用下限
            /// </summary>
            public double m_dblLowerLimitMoney = 0;
        }
        /// <summary>
        /// 医嘱基本信息对象
        /// </summary>
        public class clsOrderBaseInfo
        {
            public clsOrderBaseInfo()
            { }
            /// <summary>
            /// 是否补次	{1=补次;0=不补次}
            /// </summary>
            public int m_intIsRecruit = 0;
            /// <summary>
            /// 执行医嘱Vo对象
            /// </summary>
            public clsBIHCanExecOrder m_objBIHCanExecOrder = new clsBIHCanExecOrder();
        }
        #endregion

        #region	初始化计时器	glzhang 2005.08.1
        /// <summary>
        /// 初始化计时器	glzhang 2005.08.1
        /// </summary>
        public void m_mthInitAlert()
        {
            m_timer = new Timer();
            m_timer.Interval = 10 * 60 * 1000;//定义刷新数据间隔时间
            m_timer.Tick += new System.EventHandler(m_mthAlert);
            m_timer.Start();
        }
        #endregion

        #region	设置提示灯可视状态	glzhang	205.08.1
        /// <summary>
        /// 设置提示灯状态	glzhang	205.08.1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void m_mthAlert(object sender, System.EventArgs e)
        {
            /*  判断当前病区是否存在已提交的医嘱*/
            /*
			m_objBIHCanExecOrderArr = null;
			//病区、病床
			string strAreaID ="",strBedIDs ="";
			//执行日期
			DateTime dtStartExecute =m_objViewer.m_dtpStartExecute.Value;

			if(m_objViewer.m_txtArea.Tag!=null && m_objViewer.m_txtArea.Tag.ToString().Trim()!="" && m_objViewer.m_txtArea.Text.Trim()!="")
			{
				strAreaID =clsConverter.ToString(m_objViewer.m_txtArea.Tag).Trim();
				strBedIDs =m_objViewer.m_BedIDs;
			}
			else
			{
				return;
			}

			long lngRes=0;

			//获取审核提交医嘱
			lngRes =m_objManage.m_lngGetOrderForAuditingExecute(strAreaID,strBedIDs,dtStartExecute,out m_objBIHCanExecOrderArr);
			if(lngRes >0)
			{
				if(m_objBIHCanExecOrderArr==null || m_objBIHCanExecOrderArr.Length<=0)
				{
					m_objViewer.pictureBox3.Visible=false;
					m_objViewer.pictureBox6.Visible=false;
				}
				else
				{
					m_objViewer.pictureBox3.Visible=true;
					m_objViewer.pictureBox6.Visible=true;
				}
				
			}
			else
			{
				MessageBox.Show("定时刷新数据失败　！！","操作提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
             */
            //病区、病床
            string strAreaID = "";

            if (m_objViewer.m_txtArea.Tag != null && m_objViewer.m_txtArea.Tag.ToString().Trim() != "" && m_objViewer.m_txtArea.Text.Trim() != "")
            {
                strAreaID = clsConverter.ToString(m_objViewer.m_txtArea.Tag).Trim();
            }
            long lngRes = m_objManage.m_lngGetOrderForAuditingExecute(strAreaID);
            if (lngRes > 0)
            {
                m_objViewer.pictureBox3.Visible = true;
                m_objViewer.pictureBox6.Visible = true;

            }
            else
            {
                m_objViewer.pictureBox3.Visible = false;
                m_objViewer.pictureBox6.Visible = false;
            }


            /*<==========================================================================*/
        }
        #endregion


        public long m_lngDellORDERCHARGEDEPT(string m_strSeq_int)
        {
            clsDcl_InputOrder objInputOrder = new clsDcl_InputOrder();
            long m_lngref = objInputOrder.m_lngDellORDERCHARGEDEPT(m_strSeq_int);
            return m_lngref;
        }
    }
}
