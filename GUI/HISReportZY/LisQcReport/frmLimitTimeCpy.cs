using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.gui.HIS.Reports;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmLimitTimeCpy : Form
    {
        string applyunitId = string.Empty;

        public frmLimitTimeCpy(string applyunitId_)
        {
            applyunitId = applyunitId_;
            InitializeComponent();
        }

        /// <summary>
        /// 类变量
        /// </summary>
        internal bool IsEnglish = false;
        private clsDcl_LimitTimeMaitain m_objManage;
        Dictionary<string, string> dicGroup;

        private void dgvCpyItem_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dgvItem_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgvItem.CurrentRow != null)
            {
                {
                    object[] value = new object[dgvItem.Columns.Count];
                    for (int i = 0; i < dgvItem.Columns.Count; i++)
                    {
                        value[i] = dgvItem.CurrentRow.Cells[i].Value;
                    }

                    dgvCpyItem.Rows.Add(value);
                }
            }
        }

        private void frm_Load(object sender, EventArgs e)
        {
            init();
        }

        #region
        void init()
        {
            m_objManage = new clsDcl_LimitTimeMaitain();

            DataTable dtbResult;
            dicGroup = new Dictionary<string, string>();
            m_objManage.lngGetAllCheckSpec(out dtbResult);

            for (int i = 0; i < dtbResult.Rows.Count; i++)
            {
                this.cbxGroup.Items.Add(dtbResult.Rows[i]["check_category_desc_vchr"].ToString());
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
                if (kvp.Value.Equals(this.cbxGroup.Text))
                {
                    groupId = kvp.Key;
                }
            }

            long lngRes = m_objManage.lngGetAllCheckItem(out dtbResult, groupId);

            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                this.dgvItem.DataSource = dtbResult;
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
            strTempName = this.txtSearchName.Text.Trim();
            string groupId = string.Empty;

            foreach (KeyValuePair<string, string> kvp in dicGroup)
            {
                if (kvp.Value.Equals(this.cbxGroup.Text))
                {
                    strGroupId = kvp.Key;
                }
            }

            long lngRes = m_objManage.lngGetCheckItemByName(strTempName, strGroupId, out dtbResult);

            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                this.dgvItem.DataSource = dtbResult;
            }
        }
        #endregion

        private void dgvCpyItem_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.dgvCpyItem.Rows.RemoveAt(e.RowIndex);//删除当前行
        }

        private void btnCpy_Click(object sender, EventArgs e)
        {
            m_mthCpyLimitTime();
        }


        public void m_mthCpyLimitTime()
        {
            long lngRes = 0;

            DataTable dtResult = null;

            lngRes = m_objManage.lngGetLimitTime(out dtResult, applyunitId);

            if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
            {
                DataRow dr = dtResult.Rows[0];

                if (this.dgvCpyItem.Rows.Count > 0)
                {
                    for (int i = 0; i < this.dgvCpyItem.Rows.Count; i++)
                    {
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

                        DataRow newRow;
                        newRow = dt.NewRow();
                        newRow["applyunitid"] = dgvCpyItem.Rows[i].Cells[0].Value.ToString();
                        newRow["week1"] = dr["week1"].ToString();
                        newRow["week2"] = dr["week2"].ToString(); ;
                        newRow["normalLimit"] = dr["normalLimit"].ToString();
                        newRow["emergencyLimit"] = dr["emergencyLimit"].ToString();
                        newRow["acceptTime1"] = dr["acceptTime1"].ToString();
                        newRow["acceptTime2"] = dr["acceptTime2"].ToString();
                        newRow["acceptTime3"] = dr["acceptTime3"].ToString();
                        newRow["acceptTime4"] = dr["acceptTime4"].ToString();
                        newRow["confirTime1"] = dr["confirtime1"].ToString();
                        newRow["confirTime2"] = dr["confirtime2"].ToString();
                        newRow["confirTime3"] = dr["confirtime3"].ToString();
                        newRow["confirTime4"] = dr["confirtime4"].ToString();
                        newRow["week3"] = dr["week3"].ToString();
                        newRow["week4"] = dr["week4"].ToString();
                        newRow["week5"] = dr["week5"].ToString();
                        newRow["week6"] = dr["week6"].ToString();
                        newRow["confirmendtime"] = dr["confirmendtime"].ToString();
                        newRow["acceptTime5"] = dr["acceptTime5"].ToString();
                        newRow["acceptTime6"] = dr["acceptTime6"].ToString();
                        newRow["timelimit5"] = dr["timelimit5"].ToString();
                        newRow["timelimit6"] = dr["timelimit6"].ToString();

                        dt.Rows.Add(newRow);

                        lngRes = m_objManage.lngSaveLimitTime(dt);
                    }

                    if (lngRes > 0)
                    {
                        MessageBox.Show("复制成功 !");
                    }
                }
            }
        }

        private void cbxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_mthListCheckItem();
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            m_mthGetCheckItemByName();
        }
    }
}
