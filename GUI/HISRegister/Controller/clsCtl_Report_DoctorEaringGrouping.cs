using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility;
using com.digitalwave.iCare.gui.Security;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
    class clsCtl_Report_DoctorEaringGrouping : com.digitalwave.GUI_Base.clsController_Base
    {        
        clsDcl_Report_DoctorEarningGrouping m_objManage = null;        

        #region 构造函数
        public clsCtl_Report_DoctorEaringGrouping()
		{
            m_objManage = new clsDcl_Report_DoctorEarningGrouping();
		}
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmReport_DoctorEarningGrouping m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmReport_DoctorEarningGrouping)frmMDI_Child_Base_in;
        }
        #endregion


        private string[] strGParams = null,
            strZParams = null;
        private string groupid=null;
        private string strGroupName=null;
        private string strBeginDat=null;
        private string strEndDat=null;

        internal void m_mthSelectDoctorEarningGrouping(string p_strRptID, string[] p_strGroupIDArr)
        {
            //clsLogText objLog = new clsLogText();
            //objLog.Log2File("c:\\log.txt", DateTime.Now.ToString());

            if (m_objViewer.m_txtChoicegroup.Tag != null)
                groupid = m_objViewer.m_txtChoicegroup.Tag.ToString();

            strGroupName = m_objViewer.m_txtChoicegroup.Text;
            strBeginDat = m_objViewer.m_dtpBeginDat.Value.ToShortDateString();
            strEndDat = m_objViewer.m_dtpEndDat.Value.ToShortDateString();

            DataTable dtbReport = null;
            DataTable dtbTypeID = null;
            string[] strTypeIDArr1 = null, strTypeIDArr2 = null;
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


            if (groupid == null || strGroupName == "")
            {
                strGroupName = "全院";

                if ((strTypeIDArr1.Length > 0) && (strTypeIDArr2.Length > 0))
                {
                    lngRes = m_objManage.m_mthGetDoctorEarningWithOutChooseGroup(strBeginDat, strEndDat, strTypeIDArr1, strTypeIDArr2, out dtbReport);

                }


            }
            else
            {
                lngRes = m_objManage.m_lngGetDoctorEarningGrouping(strBeginDat, strEndDat, groupid, strTypeIDArr1, strTypeIDArr2, out dtbReport);
            }
            //objLog.Log2File("c:\\log.txt", DateTime.Now.ToString());
            bindTable(dtbReport, strGroupName);
        }


        private void bindTable(DataTable m_dtbReport,string strGroupName)
        {
            m_objViewer.dw_doctorearinggrouping.Reset();
            m_objViewer.dw_doctorearinggrouping.SetRedrawOff();

            m_objViewer.dw_doctorearinggrouping.Modify("groupname.text='" + strGroupName + "'");
            m_objViewer.dw_doctorearinggrouping.Modify("bigindatetext.text='" + this.strBeginDat + "'");
            m_objViewer.dw_doctorearinggrouping.Modify("enddatetext.text='" + this.strEndDat + "'");

            m_objViewer.dw_doctorearinggrouping.Retrieve(m_dtbReport);

            this.m_objViewer.dw_doctorearinggrouping.SetRedrawOn();
            this.m_objViewer.dw_doctorearinggrouping.Refresh();
        }

        internal void m_mthInitializeControl()
        {
            m_objViewer.m_dtpBeginDat.Value = DateTime.Now;
            m_objViewer.m_dtpEndDat.Value = DateTime.Now;
        }

        internal void m_txtChoicegroupFindItem(string strFindCode, ListView lvwList)
        {
            DataTable m_dtResult ;
            long lngRes = m_objManage.m_lngSelectGroupIdAndName(strFindCode, out m_dtResult);
            if (lngRes > 0 && m_dtResult != null && m_dtResult.Rows.Count > 0)
            {

                for (int i = 0; i < m_dtResult.Rows.Count; i++)
                {
                    ListViewItem lvi = lvwList.Items.Add(m_dtResult.Rows[i]["USERCODE_CHR"].ToString());
                    lvi.SubItems.Add(m_dtResult.Rows[i]["groupname_vchr"].ToString());
                    lvi.Tag = m_dtResult.Rows[i]["groupid_chr"].ToString();
                }
            }
        }

        internal void m_txtChoicegroupInitListView(ListView lvwList)
        {
            lvwList.Columns.Add("编号", 60, HorizontalAlignment.Left);
            lvwList.Columns.Add("专业组名称", 100, HorizontalAlignment.Left);
            lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvwList.Width = 170;
        }

        internal void m_txtChoicegroupSelectItem(ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {
                m_objViewer.m_txtChoicegroup.Text = lviSelected.SubItems[1].Text;
                m_objViewer.m_txtChoicegroup.Tag = lviSelected.Tag;              
            }
        }


        internal void m_mthGetParams(string strGhfCode, string strZjCode)
        {
            //clsMZPublic.m_mthGetSysparm(strGhfCode, strZjCode, out strGParams, out strZParams);

            strGParams = clsPublic.m_strGetSysparm(strGhfCode).Split(';');
            strZParams = clsPublic.m_strGetSysparm(strZjCode).Split(';');
        }

    }
}
