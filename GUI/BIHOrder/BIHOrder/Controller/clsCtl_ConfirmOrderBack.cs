using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.BIHOrder.Control;
using com.digitalwave.iCare.middletier.BIHOrderServer;

namespace com.digitalwave.iCare.BIHOrder
{
    /// <summary>
    ///  
    /// </summary>
    class clsCtl_ConfirmOrderBack : com.digitalwave.GUI_Base.clsController_Base
    {

        #region 变量
        clsDcl_ConfirmOrderBack m_objManage = null;
		public string m_strReportID;
		public string m_strOperatorID;
		#endregion 
		#region 构造函数
        public clsCtl_ConfirmOrderBack()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
            m_objManage = new clsDcl_ConfirmOrderBack();
			
		}
		#endregion 

        #region 设置窗体对象
        com.digitalwave.iCare.BIHOrder.frmConfirmOrderBack m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmConfirmOrderBack)frmMDI_Child_Base_in;
        }
        #endregion

        #region 载入
        /// <summary>
        /// 载入
        /// </summary>
        public void LoadData()
        {
            #region 颜色
            //长期
            m_objViewer.m_lblLong.BackColor = clsOrderColor.BackColorLongOrder;
            //临时
            m_objViewer.m_lblTemp.BackColor = clsOrderColor.BackColorTemOrder;
            //新建
            m_objViewer.m_lblStatus0.BackColor = clsOrderColor.ForeColorOrderStatus0;
            //已提交
            m_objViewer.m_lblStatus1.BackColor = clsOrderColor.ForeColorOrderStatus1;
            //执行
            m_objViewer.m_lblStatus2.BackColor = clsOrderColor.ForeColorOrderStatus2;
            //停止
            m_objViewer.m_lblStatus3.BackColor = clsOrderColor.ForeColorOrderStatus3;
            //重整
            m_objViewer.m_lblStatus4.BackColor = clsOrderColor.ForeColorOrderStatus4;
            //作废
            m_objViewer.m_lblStatus5.BackColor = clsOrderColor.ForeColorOrderStatus_1;

            m_objViewer.m_strOperateName = "[退回]";
            //父医嘱名称
            m_objViewer.m_txbOrderName.Text = m_objViewer.m_strOrderName.ToString().Trim();
            //病人姓名
            m_objViewer.m_txbPatientName.Text = m_objViewer.m_strPatientName.ToString().Trim();

            m_objViewer.m_lblPrompt.Text = m_objViewer.m_lblPrompt.Text.Replace("[]", m_objViewer.m_strOperateName);
            #endregion
            if (m_objViewer.m_strOrderID == string.Empty) return;

            //获取相关医嘱
            clsBIHOrder[] objResultArr;
            long lngRes =(new com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService()).m_lngGetOrderByParentID(m_objViewer.m_strOrderID, out objResultArr );
          
            if (lngRes <= 0 || objResultArr == null || objResultArr.Length <= 0) return;

            //赋值ListView
            #region 赋值
            ListViewItem lviTemp = null;
            System.Drawing.Color clrBack, clrFore;
            for (int i1 = 0; i1 < objResultArr.Length; i1++)
            {
                if (objResultArr[i1].m_intStatus == 1 || objResultArr[i1].m_intStatus == 5)
                {


                    //序号
                    lviTemp = new ListViewItem((i1 + 1).ToString());
                    //方号
                    lviTemp.SubItems.Add(objResultArr[i1].m_intRecipenNo.ToString());
                    //长/临	
                    if (objResultArr[i1].m_intExecuteType == 1)
                    {
                        lviTemp.SubItems.Add("长");
                    }
                    else
                    {
                        if (objResultArr[i1].m_intExecuteType == 2)
                            lviTemp.SubItems.Add("临");
                        else
                            lviTemp.SubItems.Add("");
                    }
                    //名称
                    lviTemp.SubItems.Add(objResultArr[i1].m_strName);
                    //剂 量
                    lviTemp.SubItems.Add(objResultArr[i1].m_dmlDosageRate.ToString() + objResultArr[i1].m_strDosageUnit);
                    //领 量  
                    lviTemp.SubItems.Add(objResultArr[i1].m_dmlGet.ToString() + objResultArr[i1].m_strGetunit);
                    //执行频率	  
                    lviTemp.SubItems.Add(objResultArr[i1].m_strExecFreqName);
                    //用 法	
                    lviTemp.SubItems.Add(objResultArr[i1].m_strDosetypeName);
                    //皮		
                    if (objResultArr[i1].m_intISNEEDFEEL == 1)
                        lviTemp.SubItems.Add("√");
                    else
                        lviTemp.SubItems.Add("");//×
                    //父级医嘱
                    lviTemp.SubItems.Add(objResultArr[i1].m_strParentName);

                    lviTemp.Tag = objResultArr[i1];
                    m_objViewer.m_lsvDisplayOrder.Items.Add(lviTemp);
                    clsOrderStatus.s_mthGetColorByStatus(objResultArr[i1].m_intExecuteType, objResultArr[i1].m_intStatus, out clrBack, out clrFore);
                    m_objViewer.m_lsvDisplayOrder.Items[m_objViewer.m_lsvDisplayOrder.Items.Count - 1].ForeColor = clrFore;
                    m_objViewer.m_lsvDisplayOrder.Items[m_objViewer.m_lsvDisplayOrder.Items.Count - 1].BackColor = clrBack;
                }
               
            }

            #endregion
        }
        #endregion
    }
}
