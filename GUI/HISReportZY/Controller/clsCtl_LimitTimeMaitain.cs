using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.gui.HIS.Reports;
using System.Data;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsCtl_LimitTimeMaitain : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 构造函数
        public clsCtl_LimitTimeMaitain()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_objManage = new clsDcl_LimitTimeMaitain();
        }
        #endregion


        /// <summary>
        /// 类变量
        /// </summary>
        private frmLimitTimeMaitain m_objViewer;
        internal bool IsEnglish = false;
        private clsDcl_LimitTimeMaitain m_objManage;
        Dictionary<string, string> dicGroup;

        #region 设置窗体对象
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            m_objViewer = (frmLimitTimeMaitain)frmMDI_Child_Base_in;
        }
        #endregion

        #region init
        /// <summary>
        /// init
        /// </summary>
        public void m_mthInit()
        {
            DataTable dtbResult;
            dicGroup = new Dictionary<string, string>();
            m_objManage.lngGetAllCheckSpec(out dtbResult);

            for (int i = 0; i < dtbResult.Rows.Count; i++)
            {
                m_objViewer.cbxGroup.Items.Add(dtbResult.Rows[i]["check_category_desc_vchr"].ToString());
                dicGroup.Add(dtbResult.Rows[i]["check_category_id_chr"].ToString(), dtbResult.Rows[i]["check_category_desc_vchr"].ToString());
            }

            m_mthListCheckItem();
        }
        #endregion

        #region 列出所有检验项目
        /// <summary>
        /// 列出所有检验项目
        /// </summary>
        public void m_mthListCheckItem()
        {
            DataTable dtbResult;
            string groupId = string.Empty;
            foreach (KeyValuePair<string, string> kvp in dicGroup)
            {
                if (kvp.Value.Equals(this.m_objViewer.cbxGroup.Text))
                {
                    groupId = kvp.Key;
                }
            }

            long lngRes = m_objManage.lngGetAllCheckItem(out dtbResult, groupId);

            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                m_objViewer.dgvItem.DataSource = dtbResult;
            }
        }
        #endregion

        #region   名字查找检验项目
        /// <summary>
        /// 
        /// </summary>
        public void m_mthGetCheckItemByName()
        {
            DataTable dtbResult;
            string strTempName = string.Empty;
            string strGroupId = string.Empty;
            strTempName = m_objViewer.txtSearchName.Text.Trim();
            string groupId = string.Empty;

            foreach (KeyValuePair<string, string> kvp in dicGroup)
            {
                if (kvp.Value.Equals(this.m_objViewer.cbxGroup.Text))
                {
                    strGroupId = kvp.Key;
                }
            }

            long lngRes = m_objManage.lngGetCheckItemByName(strTempName, strGroupId, out dtbResult);

            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                m_objViewer.dgvItem.DataSource = dtbResult;
            }
        }
        #endregion

        public void m_mthGetLimitTime()
        {
            long lngRes = 0;
            string applyunitid = string.Empty;
            DataTable dt = null;

            if (m_objViewer.dgvItem.Rows.Count > 0)
            {
                applyunitid = m_objViewer.dgvItem.CurrentRow.Cells["项目编码"].Value.ToString();
            }
            else
                return;

            if (string.IsNullOrEmpty(applyunitid))
                return;

            clear();

            lngRes = m_objManage.lngGetLimitTime(out dt, applyunitid);
            if (lngRes > 0 && dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                m_objViewer.cboWeek_1.Text = dr["week1"].ToString();
                m_objViewer.cboWeek_2.Text = dr["week2"].ToString();
                m_objViewer.cboWeek_3.Text = dr["week3"].ToString();
                m_objViewer.cboWeek_4.Text = dr["week4"].ToString();
                m_objViewer.cboWeek_5.Text = dr["week5"].ToString();
                m_objViewer.cboWeek_6.Text = dr["week6"].ToString();
                m_objViewer.txtNormal.Text = dr["normalLimit"].ToString();
                m_objViewer.txtEmergency.Text = dr["emergencyLimit"].ToString();
                m_objViewer.txtTimeLimit5.Text = dr["timelimit5"].ToString();
                m_objViewer.txtTimeLimit6.Text = dr["timelimit6"].ToString();

                if (!string.IsNullOrEmpty(dr["acceptTime1"].ToString()))
                {
                    m_objViewer.cboAceepH_1.Text = dr["acceptTime1"].ToString().Split(':')[0];
                    m_objViewer.cboAceepM_1.Text = dr["acceptTime1"].ToString().Split(':')[1];
                }
                if (!string.IsNullOrEmpty(dr["acceptTime2"].ToString()))
                {
                    string acceptTimePre2 = dr["acceptTime2"].ToString().Split('~')[0];
                    string acceptTime2 = dr["acceptTime2"].ToString().Split('~')[1];
                    m_objViewer.cboAceepHPre_2.Text = acceptTimePre2.Split(':')[0];
                    m_objViewer.cboAceepMPre_2.Text = acceptTimePre2.Split(':')[1];
                    m_objViewer.cboAceepH_2.Text = acceptTime2.Split(':')[0];
                    m_objViewer.cboAceepM_2.Text = acceptTime2.Split(':')[1];
                }
                if (!string.IsNullOrEmpty(dr["acceptTime3"].ToString()))
                {
                    string acceptTimePre3 = dr["acceptTime3"].ToString().Split('~')[0];
                    string acceptTime3 = dr["acceptTime3"].ToString().Split('~')[1];
                    m_objViewer.cboAceepHPre_3.Text = acceptTimePre3.Split(':')[0];
                    m_objViewer.cboAceepMPre_3.Text = acceptTimePre3.Split(':')[1];
                    m_objViewer.cboAceepH_3.Text = acceptTime3.Split(':')[0];
                    m_objViewer.cboAceepM_3.Text = acceptTime3.Split(':')[1];
                }
                if (!string.IsNullOrEmpty(dr["acceptTime4"].ToString()))
                {
                    m_objViewer.cboAceepH_4.Text = dr["acceptTime4"].ToString().Split(':')[0];
                    m_objViewer.cboAceepM_4.Text = dr["acceptTime4"].ToString().Split(':')[1];
                }

                if (!string.IsNullOrEmpty(dr["acceptTime5"].ToString()))
                {
                    string acceptTimePre5 = dr["acceptTime5"].ToString().Split('~')[0];
                    string acceptTime5 = dr["acceptTime5"].ToString().Split('~')[1];
                    m_objViewer.cboAceepHPre_5.Text = acceptTimePre5.Split(':')[0];
                    m_objViewer.cboAceepMPre_5.Text = acceptTimePre5.Split(':')[1];
                    m_objViewer.cboAceepH_5.Text = acceptTime5.Split(':')[0];
                    m_objViewer.cboAceepM_5.Text = acceptTime5.Split(':')[1];
                }
                if (!string.IsNullOrEmpty(dr["acceptTime6"].ToString()))
                {
                    string acceptTimePre6 = dr["acceptTime6"].ToString().Split('~')[0];
                    string acceptTime6 = dr["acceptTime6"].ToString().Split('~')[1];
                    m_objViewer.cboAceepHPre_6.Text = acceptTimePre6.Split(':')[0];
                    m_objViewer.cboAceepMPre_6.Text = acceptTimePre6.Split(':')[1];
                    m_objViewer.cboAceepH_6.Text = acceptTime6.Split(':')[0];
                    m_objViewer.cboAceepM_6.Text = acceptTime6.Split(':')[1];
                }

                if (!string.IsNullOrEmpty(dr["confirmendtime"].ToString()))
                {
                    m_objViewer.cboConfirEndH.Text = dr["confirmendtime"].ToString().Split(':')[0];
                    m_objViewer.cboConfirEndM.Text = dr["confirmendtime"].ToString().Split(':')[1];
                }

                if (!string.IsNullOrEmpty(dr["confirtime1"].ToString()))
                {
                    m_objViewer.cboConfirH_1.Text = dr["confirtime1"].ToString().Split(':')[0];
                    m_objViewer.cboConfirM_1.Text = dr["confirtime1"].ToString().Split(':')[1];
                }
                if (!string.IsNullOrEmpty(dr["confirtime2"].ToString()))
                {
                    m_objViewer.cboConfirH_2.Text = dr["confirtime2"].ToString().Split(':')[0];
                    m_objViewer.cboConfirM_2.Text = dr["confirtime2"].ToString().Split(':')[1];
                }
                if (!string.IsNullOrEmpty(dr["confirtime3"].ToString()))
                {
                    m_objViewer.cboConfirH_3.Text = dr["confirtime3"].ToString().Split(':')[0];
                    m_objViewer.cboConfirM_3.Text = dr["confirtime3"].ToString().Split(':')[1];
                }
                if (!string.IsNullOrEmpty(dr["confirtime4"].ToString()))
                {
                    m_objViewer.cboConfirH_4.Text = dr["confirtime4"].ToString().Split(':')[0];
                    m_objViewer.cboConfirM_4.Text = dr["confirtime4"].ToString().Split(':')[1];
                }
            }
            else
            {
                clear();
            }
        }


        public void m_mthSaveLimitTime()
        {
            long lngRes = 0;
            string applyunitid = string.Empty;

            if (m_objViewer.dgvItem.Rows.Count > 0)
            {
                applyunitid = m_objViewer.dgvItem.CurrentRow.Cells["项目编码"].Value.ToString();
            }
            else
                return;

            if (string.IsNullOrEmpty(applyunitid))
                return;

            DataTable dt = new DataTable("Datas");
            DataColumn dc = new DataColumn();
            dc.AutoIncrement = true;//自动增加
            dc.AutoIncrementSeed = 1;//起始为1
            dc.AutoIncrementStep = 1;//步长为1
            dc.AllowDBNull = false;//
            dc = dt.Columns.Add("applyunitid", Type.GetType("System.String"));
            dc = dt.Columns.Add("week1", Type.GetType("System.String"));
            dc = dt.Columns.Add("week2", Type.GetType("System.String"));
            dc = dt.Columns.Add("normalLimit", Type.GetType("System.String"));
            dc = dt.Columns.Add("emergencyLimit", Type.GetType("System.String"));
            dc = dt.Columns.Add("acceptTime1", Type.GetType("System.String"));
            dc = dt.Columns.Add("acceptTime2", Type.GetType("System.String"));
            dc = dt.Columns.Add("acceptTime3", Type.GetType("System.String"));
            dc = dt.Columns.Add("acceptTime4", Type.GetType("System.String"));

            dc = dt.Columns.Add("confirTime1", Type.GetType("System.String"));
            dc = dt.Columns.Add("confirTime2", Type.GetType("System.String"));
            dc = dt.Columns.Add("confirTime3", Type.GetType("System.String"));
            dc = dt.Columns.Add("confirTime4", Type.GetType("System.String"));
            dc = dt.Columns.Add("week3", Type.GetType("System.String"));
            dc = dt.Columns.Add("week4", Type.GetType("System.String"));
            dc = dt.Columns.Add("week5", Type.GetType("System.String"));
            dc = dt.Columns.Add("week6", Type.GetType("System.String"));
            dc = dt.Columns.Add("CONFIRMENDTIME", Type.GetType("System.String"));

            dc = dt.Columns.Add("acceptTime5", Type.GetType("System.String"));
            dc = dt.Columns.Add("acceptTime6", Type.GetType("System.String"));
            dc = dt.Columns.Add("timelimit5", Type.GetType("System.String"));
            dc = dt.Columns.Add("timelimit6", Type.GetType("System.String"));

            string week1 = m_objViewer.cboWeek_1.Text.Trim();
            string week2 = m_objViewer.cboWeek_2.Text.Trim();
            string week3 = m_objViewer.cboWeek_3.Text.Trim();
            string week4 = m_objViewer.cboWeek_4.Text.Trim();
            string week5 = m_objViewer.cboWeek_5.Text.Trim();
            string week6 = m_objViewer.cboWeek_6.Text.Trim();
            string normalLimit = m_objViewer.txtNormal.Text.Trim();
            string emergencyLimit = m_objViewer.txtEmergency.Text.Trim();
            string timelimit5 = m_objViewer.txtTimeLimit5.Text.Trim();
            string timelimit6 = m_objViewer.txtTimeLimit6.Text.Trim();

            #region ACCEPTTIME
            string acceptTimeH1 = m_objViewer.cboAceepH_1.Text.Trim(); ;
            string acceptTimeM1 = string.Empty;
            string acceptTime1 = string.Empty;
            if (!string.IsNullOrEmpty(acceptTimeH1))
            {
                acceptTimeM1 = string.IsNullOrEmpty(m_objViewer.cboAceepM_1.Text.Trim()) ? "00" : m_objViewer.cboAceepM_1.Text.Trim();
                acceptTime1 = acceptTimeH1 + ":" + acceptTimeM1;
            }

            string acceptTimeH2 = m_objViewer.cboAceepH_2.Text.Trim(); ;
            string acceptTimeM2 = string.Empty;
            string acceptTime2 = string.Empty;
            if (!string.IsNullOrEmpty(acceptTimeH2))
            {
                acceptTimeM2 = string.IsNullOrEmpty(m_objViewer.cboAceepM_2.Text.Trim()) ? "00" : m_objViewer.cboAceepM_2.Text.Trim();
                acceptTime2 = acceptTimeH2 + ":" + acceptTimeM2;
            }
            string acceptTimeHPre2 = m_objViewer.cboAceepHPre_2.Text.Trim(); ;
            string acceptTimeMPre2 = string.Empty;
            string acceptTimePre2 = string.Empty;
            if (!string.IsNullOrEmpty(acceptTimeHPre2))
            {
                acceptTimeMPre2 = string.IsNullOrEmpty(m_objViewer.cboAceepMPre_2.Text.Trim()) ? "00" : m_objViewer.cboAceepMPre_2.Text.Trim();
                acceptTimePre2 = acceptTimeHPre2 + ":" + acceptTimeMPre2;
            }

            if (!string.IsNullOrEmpty(acceptTimeH2) && !string.IsNullOrEmpty(acceptTimeHPre2))
            {
                acceptTime2 = acceptTimePre2 + "~" + acceptTime2;
            }


            string acceptTimeH3 = m_objViewer.cboAceepH_3.Text.Trim(); ;
            string acceptTimeM3 = string.Empty;
            string acceptTime3 = string.Empty;
            if (!string.IsNullOrEmpty(acceptTimeH3))
            {
                acceptTimeM3 = string.IsNullOrEmpty(m_objViewer.cboAceepM_3.Text.Trim()) ? "00" : m_objViewer.cboAceepM_3.Text.Trim();
                acceptTime3 = acceptTimeH3 + ":" + acceptTimeM3;
            }

            string acceptTimeHPre3 = m_objViewer.cboAceepHPre_3.Text.Trim(); ;
            string acceptTimeMPre3 = string.Empty;
            string acceptTimePre3 = string.Empty;
            if (!string.IsNullOrEmpty(acceptTimeHPre3))
            {
                acceptTimeMPre3 = string.IsNullOrEmpty(m_objViewer.cboAceepMPre_3.Text.Trim()) ? "00" : m_objViewer.cboAceepMPre_3.Text.Trim();
                acceptTimePre3 = acceptTimeHPre3 + ":" + acceptTimeMPre3;
            }
            if (!string.IsNullOrEmpty(acceptTimeH3) && !string.IsNullOrEmpty(acceptTimeHPre3))
            {
                acceptTime3 = acceptTimePre3 + "~" + acceptTime3;
            }

            string acceptTimeH4 = m_objViewer.cboAceepH_4.Text.Trim(); ;
            string acceptTimeM4 = string.Empty;
            string acceptTime4 = string.Empty;
            if (!string.IsNullOrEmpty(acceptTimeH4))
            {
                acceptTimeM4 = string.IsNullOrEmpty(m_objViewer.cboAceepM_4.Text.Trim()) ? "00" : m_objViewer.cboAceepM_4.Text.Trim();
                acceptTime4 = acceptTimeH4 + ":" + acceptTimeM4;
            }


            string acceptTimeH5 = m_objViewer.cboAceepH_5.Text.Trim(); ;
            string acceptTimeM5 = string.Empty;
            string acceptTime5 = string.Empty;
            if (!string.IsNullOrEmpty(acceptTimeH5))
            {
                acceptTimeM5 = string.IsNullOrEmpty(m_objViewer.cboAceepM_5.Text.Trim()) ? "00" : m_objViewer.cboAceepM_5.Text.Trim();
                acceptTime5 = acceptTimeH5 + ":" + acceptTimeM5;
            }

            string acceptTimeHPre5 = m_objViewer.cboAceepHPre_5.Text.Trim(); ;
            string acceptTimeMPre5 = string.Empty;
            string acceptTimePre5 = string.Empty;
            if (!string.IsNullOrEmpty(acceptTimeHPre5))
            {
                acceptTimeMPre5 = string.IsNullOrEmpty(m_objViewer.cboAceepMPre_5.Text.Trim()) ? "00" : m_objViewer.cboAceepMPre_5.Text.Trim();
                acceptTimePre5 = acceptTimeHPre5 + ":" + acceptTimeMPre5;
            }
            if (!string.IsNullOrEmpty(acceptTimeH5) && !string.IsNullOrEmpty(acceptTimeHPre5))
            {
                acceptTime5 = acceptTimePre5 + "~" + acceptTime5;
            }


            string acceptTimeH6 = m_objViewer.cboAceepH_6.Text.Trim(); ;
            string acceptTimeM6 = string.Empty;
            string acceptTime6 = string.Empty;
            if (!string.IsNullOrEmpty(acceptTimeH6))
            {
                acceptTimeM6 = string.IsNullOrEmpty(m_objViewer.cboAceepM_6.Text.Trim()) ? "00" : m_objViewer.cboAceepM_6.Text.Trim();
                acceptTime6 = acceptTimeH6 + ":" + acceptTimeM6;
            }

            string acceptTimeHPre6 = m_objViewer.cboAceepHPre_6.Text.Trim(); ;
            string acceptTimeMPre6 = string.Empty;
            string acceptTimePre6 = string.Empty;
            if (!string.IsNullOrEmpty(acceptTimeHPre6))
            {
                acceptTimeMPre6 = string.IsNullOrEmpty(m_objViewer.cboAceepMPre_6.Text.Trim()) ? "00" : m_objViewer.cboAceepMPre_6.Text.Trim();
                acceptTimePre6 = acceptTimeHPre6 + ":" + acceptTimeMPre6;
            }
            if (!string.IsNullOrEmpty(acceptTimeH6) && !string.IsNullOrEmpty(acceptTimeHPre6))
            {
                acceptTime6 = acceptTimePre6 + "~" + acceptTime6;
            }

            #endregion

            #region CONFIRTIME
            string confrEndH = m_objViewer.cboConfirEndH.Text.Trim(); ;
            string confrEndM = string.Empty;
            string confirmEndTime = string.Empty;
            if (!string.IsNullOrEmpty(confrEndH))
            {
                confrEndM = string.IsNullOrEmpty(m_objViewer.cboConfirEndM.Text.Trim()) ? "00" : m_objViewer.cboConfirEndM.Text.Trim();
                confirmEndTime = confrEndH + ":" + confrEndM;
            }


            string confirTimeH_1 = m_objViewer.cboConfirH_1.Text.Trim(); ;
            string confirTimeM_1 = string.Empty;
            string confirTime_1 = string.Empty;
            if (!string.IsNullOrEmpty(confirTimeH_1))
            {
                confirTimeM_1 = string.IsNullOrEmpty(m_objViewer.cboConfirM_1.Text.Trim()) ? "00" : m_objViewer.cboConfirM_1.Text.Trim();
                confirTime_1 = confirTimeH_1 + ":" + confirTimeM_1;
            }

            string confirTimeH_2 = m_objViewer.cboConfirH_2.Text.Trim(); ;
            string confirTimeM_2 = string.Empty;
            string confirTime_2 = string.Empty;
            if (!string.IsNullOrEmpty(confirTimeH_2))
            {
                confirTimeM_2 = string.IsNullOrEmpty(m_objViewer.cboConfirM_2.Text.Trim()) ? "00" : m_objViewer.cboConfirM_2.Text.Trim();
                confirTime_2 = confirTimeH_2 + ":" + confirTimeM_2;
            }

            string confirTimeH_3 = m_objViewer.cboConfirH_3.Text.Trim(); ;
            string confirTimeM_3 = string.Empty;
            string confirTime_3 = string.Empty;
            if (!string.IsNullOrEmpty(confirTimeH_3))
            {
                confirTimeM_3 = string.IsNullOrEmpty(m_objViewer.cboConfirM_3.Text.Trim()) ? "00" : m_objViewer.cboConfirM_3.Text.Trim();
                confirTime_3 = confirTimeH_3 + ":" + confirTimeM_3;
            }

            string confirTimeH_4 = m_objViewer.cboConfirH_4.Text.Trim(); ;
            string confirTimeM_4 = string.Empty;
            string confirTime_4 = string.Empty;
            if (!string.IsNullOrEmpty(confirTimeH_4))
            {
                confirTimeM_4 = string.IsNullOrEmpty(m_objViewer.cboConfirM_4.Text.Trim()) ? "00" : m_objViewer.cboConfirM_4.Text.Trim();
                confirTime_4 = confirTimeH_4 + ":" + confirTimeM_4;
            }

            #endregion


            DataRow newRow;
            newRow = dt.NewRow();
            newRow["applyunitid"] = applyunitid;
            newRow["week1"] = week1;
            newRow["week2"] = week2;
            newRow["normalLimit"] = normalLimit;
            newRow["emergencyLimit"] = emergencyLimit;
            newRow["acceptTime1"] = acceptTime1;
            newRow["acceptTime2"] = acceptTime2;
            newRow["acceptTime3"] = acceptTime3;
            newRow["acceptTime4"] = acceptTime4;
            newRow["confirTime1"] = confirTime_1;
            newRow["confirTime2"] = confirTime_2;
            newRow["confirTime3"] = confirTime_3;
            newRow["confirTime4"] = confirTime_4;
            newRow["week3"] = week3;
            newRow["week4"] = week4;
            newRow["week5"] = week5;
            newRow["week6"] = week6;
            newRow["confirmendtime"] = confirmEndTime;
            newRow["acceptTime5"] = acceptTime5;
            newRow["acceptTime6"] = acceptTime6;
            newRow["timelimit5"] = timelimit5;
            newRow["timelimit6"] = timelimit6;

            dt.Rows.Add(newRow);

            lngRes = m_objManage.lngSaveLimitTime(dt);

            if (lngRes > 0)
            {
                MessageBox.Show("保存成功！");
            }
            else
            {
                MessageBox.Show("保存失败！");
            }
        }


        public void m_mthDeletLimitTime()
        {
            long lngRes = 0;
            string applyunitid = string.Empty;

            if (m_objViewer.dgvItem.Rows.Count > 0)
            {
                applyunitid = m_objViewer.dgvItem.CurrentRow.Cells["项目编码"].Value.ToString();
            }
            else
                return;

            if (string.IsNullOrEmpty(applyunitid))
                return;

            lngRes = m_objManage.lngDeleteLimitTime(applyunitid);

            if (lngRes > 0)
            {
                clear();
                MessageBox.Show("删除成功！");
            }
            else
            {
                MessageBox.Show("删除失败！");
            }
        }

        public void clear()
        {
            m_objViewer.cboWeek_1.Text = "";
            m_objViewer.cboWeek_2.Text = "";
            m_objViewer.cboWeek_3.Text = "";
            m_objViewer.cboWeek_4.Text = "";
            m_objViewer.cboWeek_5.Text = "";
            m_objViewer.cboWeek_6.Text = "";
            m_objViewer.txtNormal.Text = "";
            m_objViewer.txtEmergency.Text = "";
            m_objViewer.cboAceepH_1.Text = "";
            m_objViewer.cboAceepM_1.Text = "";
            m_objViewer.cboAceepH_2.Text = "";
            m_objViewer.cboAceepM_2.Text = "";
            m_objViewer.cboAceepHPre_2.Text = "";
            m_objViewer.cboAceepMPre_2.Text = "";
            m_objViewer.cboAceepH_3.Text = "";
            m_objViewer.cboAceepM_3.Text = "";
            m_objViewer.cboAceepHPre_3.Text = "";
            m_objViewer.cboAceepMPre_3.Text = "";
            m_objViewer.cboAceepH_4.Text = "";
            m_objViewer.cboAceepM_4.Text = "";
            m_objViewer.cboConfirH_1.Text = "";
            m_objViewer.cboConfirM_1.Text = "";
            m_objViewer.cboConfirH_2.Text = "";
            m_objViewer.cboConfirM_2.Text = "";
            m_objViewer.cboConfirH_3.Text = "";
            m_objViewer.cboConfirM_3.Text = "";
            m_objViewer.cboConfirH_4.Text = "";
            m_objViewer.cboConfirM_4.Text = "";
            m_objViewer.cboConfirEndH.Text = "";
            m_objViewer.cboConfirEndM.Text = "";

            m_objViewer.cboAceepHPre_5.Text = "";
            m_objViewer.cboAceepMPre_5.Text = "";
            m_objViewer.cboAceepH_5.Text = "";
            m_objViewer.cboAceepM_5.Text = "";
            m_objViewer.cboAceepHPre_6.Text = "";
            m_objViewer.cboAceepMPre_6.Text = "";
            m_objViewer.cboAceepH_6.Text = "";
            m_objViewer.cboAceepM_6.Text = "";
            m_objViewer.txtTimeLimit5.Text = "";
            m_objViewer.txtTimeLimit6.Text = "";
            m_objViewer.cboConfirEndH.Text = "";
            m_objViewer.cboConfirEndM.Text = "";
        }

        
    }
}
