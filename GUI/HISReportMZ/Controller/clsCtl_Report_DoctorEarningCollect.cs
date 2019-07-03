using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility;
using com.digitalwave.iCare.gui.Security;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// 统计门诊挂号费及诊金报表 界面逻辑控制类
    /// </summary>
    class clsCtl_Report_DoctorEarningCollect : com.digitalwave.GUI_Base.clsController_Base
    {
        clsDcl_Report_DoctorEarningCollect m_objManage = null;

        #region 构造函数
        public clsCtl_Report_DoctorEarningCollect()
		{
            m_objManage = new clsDcl_Report_DoctorEarningCollect();
		}
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.Reports.frmReport_DoctorEarningCollect m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmReport_DoctorEarningCollect)frmMDI_Child_Base_in;
        }
        #endregion

        private string[] strGParams = null,
                         strZParams = null;

        internal void m_mthSelectDoctorEarning(string p_strRptID,string[] p_strGroupIDArr)
        {
            string strBegingDat = m_objViewer.m_dtpBeginDat.Value.ToShortDateString();
            string strEnDat = m_objViewer.m_dtpEndDat.Value.ToShortDateString();
            DataTable dtbReport = null;
            DataTable dtbTypeID = null;
            string[] strTypeIDArr1 = null , strTypeIDArr2 = null;
            long lngRes = 0;
            lngRes = m_objManage.m_lngGetTypeID(p_strRptID, p_strGroupIDArr[0], out dtbTypeID);
            if (lngRes > 0)
            {
                if ((dtbTypeID != null) && (dtbTypeID.Rows.Count > 0))
                {
                    strTypeIDArr1 = new string[dtbTypeID.Rows.Count];
                    for (int iRow = 0; iRow < dtbTypeID.Rows.Count; iRow++)
                    {
                        strTypeIDArr1[iRow] = dtbTypeID.Rows[iRow]["typeid_chr"].ToString();
                    }

                }
            }

            dtbTypeID = null;
            lngRes = m_objManage.m_lngGetTypeID(p_strRptID, p_strGroupIDArr[1], out dtbTypeID);
            if (lngRes > 0)
            {
                if ((dtbTypeID != null) && (dtbTypeID.Rows.Count > 0))
                {
                    strTypeIDArr2 = new string[dtbTypeID.Rows.Count];
                    for (int iRow = 0; iRow < dtbTypeID.Rows.Count; iRow++)
                    {
                        strTypeIDArr2[iRow] = dtbTypeID.Rows[iRow]["typeid_chr"].ToString();
                    }

                }
            }

            if (strTypeIDArr1 != null && strTypeIDArr2 != null)
            {
                if ((strTypeIDArr1.Length > 0) && (strTypeIDArr2.Length > 0))
                {
                    lngRes = m_objManage.m_lngGetDoctorEarningCollect(strBegingDat, strEnDat, strTypeIDArr1, strTypeIDArr2, out dtbReport);
                    bindTable(dtbReport);
                }

            }

        }


        private void bindTable(DataTable m_dtbReport)
        {
            m_objViewer.dw_doctorearning.Reset();
            m_objViewer.dw_doctorearning.SetRedrawOff();

            m_objViewer.dw_doctorearning.Modify("bigindatetext.text='"+m_objViewer.m_dtpBeginDat.Value.ToShortDateString()+"'");
            m_objViewer.dw_doctorearning.Modify("enddatetext.text='" + m_objViewer.m_dtpEndDat.Value.ToShortDateString() + "'");

            m_objViewer.dw_doctorearning.Retrieve(m_dtbReport);
            this.m_objViewer.dw_doctorearning.SetRedrawOn();
            this.m_objViewer.dw_doctorearning.Refresh();
        }

        internal void m_mthGetParams(string strGhfCode, string strZjCode)
        {

            clsLogText objLog = new clsLogText();

            //objLog.Log2File("c:\\log.txt", DateTime.Now.ToString() + "E");

            strGParams = clsPublic.m_strGetSysparm(strGhfCode).Split(';');
            strZParams = clsPublic.m_strGetSysparm(strZjCode).Split(';');

            //clsMZPublic.m_mthGetSysparm(strGhfCode, strZjCode, out strGParams, out strZParams);

            //objLog.Log2File("c:\\log.txt", DateTime.Now.ToString() + "F");
        }

    }

}
