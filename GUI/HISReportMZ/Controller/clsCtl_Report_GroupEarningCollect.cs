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
    class clsCtl_Report_GroupEarningCollect : com.digitalwave.GUI_Base.clsController_Base
    {
        clsDcl_Report_GroupEarningCollect m_objManage = null;        

        #region 构造函数
        public clsCtl_Report_GroupEarningCollect()
		{
            m_objManage = new clsDcl_Report_GroupEarningCollect();
		}
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.Reports.frmReport_GroupEarningCollect m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmReport_GroupEarningCollect)frmMDI_Child_Base_in;
        }
        #endregion

        private string[] strGParams = null,
            strZParams = null;

        internal void m_mthSelectGroupEarningCollect()
        {
            string strBeginDat = m_objViewer.m_dtpBeginDat.Value.ToShortDateString();
            string strEndDat = m_objViewer.m_dtpEndDat.Value.ToShortDateString();
            DataTable m_dtbReport = new DataTable();
            long lngRes = m_objManage.m_lngSelectGroupEarningCollect(strBeginDat, strEndDat, strGParams, strZParams, out m_dtbReport);
            bindTable(m_dtbReport);
        }

        public void m_mthShowReport(string p_strRptID, string[] p_strGroupIDArr)
        {
            string BeginDate = this.m_objViewer.m_dtpBeginDat.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string EndDate = this.m_objViewer.m_dtpEndDat.Value.ToString("yyyy-MM-dd") + " 23:59:59";

            DataTable dt1, dt2, dt3;

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


            long l = this.m_objManage.m_lngGetGroupEarningCollect(BeginDate, EndDate, strTypeIDArr1, strTypeIDArr2, out dt1, out dt2, out dt3);
            if (l > 0)
            {
                this.m_objViewer.dw_groupearningcollect.SetRedrawOff();
                this.m_objViewer.dw_groupearningcollect.Reset();

                string GroupID = "";               
                Hashtable hasGroupID = new Hashtable();

                DataRow dr;
                DataTable dt=null;
                for (int i = 0; i < 3; i++)
                {
                    if (i == 0)
                    {
                        dt = dt1;
                    }
                    else if (i == 1)
                    {
                        dt = dt2;
                    }
                    else if (i == 2)
                    {
                        dt = dt3;
                    }

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        dr = dt.Rows[j];

                        GroupID = dr["usercode_chr"].ToString();
                        if (!hasGroupID.ContainsKey(GroupID))
                        {
                            clsGhzjRep obj = new clsGhzjRep();
                            obj.GroupID = GroupID;
                            obj.GroupName = dr["groupname_vchr"].ToString();
                            obj.Ghf = Convert.ToDecimal(dr["totalghmny"].ToString());
                            obj.BGhf = Convert.ToDecimal(dr["totaloghmny"].ToString());
                            obj.Zjf = Convert.ToDecimal(dr["totalzcmny"].ToString());
                            obj.BZjf = Convert.ToDecimal(dr["totalozcmny"].ToString());

                            hasGroupID.Add(GroupID, obj);
                        }
                        else
                        {
                            ((clsGhzjRep)hasGroupID[GroupID]).Ghf += Convert.ToDecimal(dr["totalghmny"].ToString());
                            ((clsGhzjRep)hasGroupID[GroupID]).BGhf += Convert.ToDecimal(dr["totaloghmny"].ToString());
                            ((clsGhzjRep)hasGroupID[GroupID]).Zjf += Convert.ToDecimal(dr["totalzcmny"].ToString());
                            ((clsGhzjRep)hasGroupID[GroupID]).BZjf += Convert.ToDecimal(dr["totalozcmny"].ToString());
                        }
                    }
                }

                if (hasGroupID.Count > 0)
                {
                    ArrayList obj = new ArrayList();
                    obj.AddRange(hasGroupID.Values);

                    int row = 0;
                    clsGhzjRep objGh;
                    for (int i = 0; i < obj.Count; i++)
                    {
                        objGh = obj[i] as clsGhzjRep;

                        row = this.m_objViewer.dw_groupearningcollect.InsertRow(0);

                        this.m_objViewer.dw_groupearningcollect.SetItemString(row, "usercode_chr", objGh.GroupID);
                        this.m_objViewer.dw_groupearningcollect.SetItemString(row, "groupname_vchr", objGh.GroupName);
                        this.m_objViewer.dw_groupearningcollect.SetItemDecimal(row, "totalghmny", objGh.Ghf);
                        this.m_objViewer.dw_groupearningcollect.SetItemDecimal(row, "totaloghmny", objGh.BGhf);
                        this.m_objViewer.dw_groupearningcollect.SetItemDecimal(row, "totalzcmny", objGh.Zjf);
                        this.m_objViewer.dw_groupearningcollect.SetItemDecimal(row, "totalozcmny", objGh.BZjf);
                    }
                }


                m_objViewer.dw_groupearningcollect.Modify("bigindatetext.text='" + m_objViewer.m_dtpBeginDat.Value.ToShortDateString() + "'");
                m_objViewer.dw_groupearningcollect.Modify("enddatetext.text='" + m_objViewer.m_dtpEndDat.Value.ToShortDateString() + "'");

                this.m_objViewer.dw_groupearningcollect.SetRedrawOn();
                this.m_objViewer.dw_groupearningcollect.SetSort("usercode_chr asc");
                this.m_objViewer.dw_groupearningcollect.Sort();
                this.m_objViewer.dw_groupearningcollect.Refresh();
            }
        }

        private class clsGhzjRep
        {
            public string GroupID = "";
            public string GroupName = "";
            public decimal Ghf = 0;
            public decimal BGhf = 0;
            public decimal Zjf = 0;
            public decimal BZjf = 0;
        }

        private void bindTable(DataTable m_dtbReport)
        {
            m_objViewer.dw_groupearningcollect.Reset();

            m_objViewer.dw_groupearningcollect.Modify("bigindatetext.text='" + m_objViewer.m_dtpBeginDat.Value.ToShortDateString() + "'");
            m_objViewer.dw_groupearningcollect.Modify("enddatetext.text='" + m_objViewer.m_dtpEndDat.Value.ToShortDateString() + "'");

            m_objViewer.dw_groupearningcollect.Retrieve(m_dtbReport);
        }
        
        internal void m_mthGetParams(string strGhfCode, string strZjCode)
        {
            //clsMZPublic.m_mthGetSysparm(strGhfCode, strZjCode, out strGParams, out strZParams);

            this.m_objViewer.GhItemIDArr = clsPublic.m_strGetSysparm(strGhfCode).Trim().Replace(";", ",");
            this.m_objViewer.ZcItemIDArr = clsPublic.m_strGetSysparm(strZjCode).Trim().Replace(";", ",");

            strGParams = clsPublic.m_strGetSysparm(strGhfCode).Split(';');
            strZParams = clsPublic.m_strGetSysparm(strZjCode).Split(';');
        }

    }
}
