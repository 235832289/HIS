using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmCSYBShiyingzheng : Form
    {
        public frmCSYBShiyingzheng()
        {
            InitializeComponent();
        }
        private DataTable m_dtChargeItem = null;
        private Dictionary<string, string> m_gdicChargeSFLB = null;
        private DataTable m_dtBseSFLB = null;
        internal List<clsSFLB_log> m_glstObjSFLB = null;

        public frmCSYBShiyingzheng(DataTable p_dt, Dictionary<string, string> p_gdicChargeSFLB, DataTable p_dtBseSFLB)
            : this()
        {
            this.m_dtChargeItem = p_dt;
            this.m_gdicChargeSFLB = p_gdicChargeSFLB;
            this.m_dtBseSFLB = p_dtBseSFLB;
        }

        string m_strIDS = string.Empty;
        private void frmCSYBShiyingzheng_Load(object sender, EventArgs e)
        {
            List<string> m_gsltIDs = m_glsGettokenNoBlank(clsPublic.m_strGetSysparm("3064"), ';');
            for (int i = 0; i < m_gsltIDs.Count; i++)
            {
                m_strIDS += "'" + m_gsltIDs[i].Trim() + "',";
            }
            //m_strIDS = m_strIDS.TrimEnd(',');

            this.cobSFLB.SendToBack();

            DataView dtv = this.m_dtBseSFLB.DefaultView;
            dtv.RowFilter = "sflbbh in( " + m_strIDS.TrimEnd(',') + ")";
            this.cobSum.DataSource = dtv.ToTable();
            this.cobSum.DisplayMember = "SFLB";
            this.cobSum.ValueMember = "sflbbh";

            DataRow dr = null;
            DataRow[] drArr = null;
            int intRowCount = this.m_dtChargeItem.Rows.Count;
            string[] strCells = null;
            string strSFLB = "";
            int dgvRowCount = 0;
            string preItemID = "";
            for(int i = 0; i < intRowCount; i++)
            {
                dr = this.m_dtChargeItem.Rows[i]; 
                strCells = new string[7];

                strCells[0] = Convert.ToString(i + 1);
                if(preItemID != dr["chargeitemid"].ToString())
                {
                    strCells[1] = dr["chargeitemcode"].ToString();
                    strCells[2] = dr["chargeitemname"].ToString(); 
                    preItemID = dr["chargeitemid"].ToString();
                }


                strCells[3] = dr["creatdat"].ToString();
                strCells[4] = dr["amount"].ToString() + dr["unit"].ToString();
                //strCells[5] = dr[""].ToString() + dr["unit"].ToString();
                if(dr["patchamount"] != DBNull.Value && Convert.ToDecimal(dr["patchamount"]) < 0)
                {
                    strCells[5] = Convert.ToString(Convert.ToDecimal(dr["patchamount"]) * -1) + dr["unit"].ToString();
                }
                else
                {
                    strCells[5] = "";
                }
                if(this.m_gdicChargeSFLB != null && this.m_gdicChargeSFLB.ContainsKey(dr["pchargeid"].ToString()))
                {
                    strSFLB = this.m_gdicChargeSFLB[dr["pchargeid"].ToString()];
                }
                else
                {
                    strSFLB = dr["sflb"].ToString();
                } 
                drArr = this.m_dtBseSFLB.Select("sflbbh = '" + strSFLB + "'");
                if(drArr!=null && drArr.Length > 0)
                {
                    strCells[6] = drArr[0]["sflb"].ToString();
                }

                dgvRowCount = this.m_dgvItem.Rows.Add(strCells);
                this.m_dgvItem.Rows[dgvRowCount].Tag = dr;
                this.m_dgvItem.Rows[dgvRowCount].Cells[6].Tag = strSFLB;
                /// dr 记录t_bse_chargeitem原始的编号   Cells[6].Tag 记录当前所用的编号
                /// Cells[0].Tag 记录当前修改后的编号
            }

            this.m_dgvItem.Refresh();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        { 
            DataGridViewRow dgvr = null;
            DataRow dr=null;
            m_glstObjSFLB = new List<clsSFLB_log>(this.m_dgvItem.Rows.Count);
            clsSFLB_log m_objNewLog = null;
            string m_strNewSFBH = "";
            for(int i = 0; i < this.m_dgvItem.Rows.Count; i++)
            {
                dgvr = this.m_dgvItem.Rows[i];

                if(this.chkSum.Checked == true)
                {
                    m_strNewSFBH = this.cobSum.SelectedValue.ToString();
                }
                else
                {
                    if(dgvr.Cells[0].Tag == null)
                    {
                        continue;
                    }
                    else
                    {
                        m_strNewSFBH = dgvr.Cells[0].Tag.ToString();
                    }
                }

                if(m_strNewSFBH == dgvr.Cells[6].Tag.ToString())
                {
                    continue;
                }

                dr = dgvr.Tag as DataRow;
                m_objNewLog = new clsSFLB_log();
                m_objNewLog.m_strItemID = dr["chargeitemid"].ToString();
                m_objNewLog.m_strNewSFLBBH = m_strNewSFBH;
                m_objNewLog.m_strOLDSFLBBH = dgvr.Cells[6].Tag.ToString();
                m_objNewLog.m_strPChargeID = dr["pchargeid"].ToString();

                this.m_glstObjSFLB.Add(m_objNewLog);
            }

            this.m_glstObjSFLB.TrimExcess();
            if(this.m_glstObjSFLB.Count < 1)
            {
                if(MessageBox.Show(this, "没有检查到需要更新的数据，是否继续操作？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void m_dgvItem_CurrentCellChanged(object sender, EventArgs e)
        {
            if(this.m_dgvItem.CurrentCell.ColumnIndex == 6)
            {
                System.Windows.Forms.DataGridViewCell cCell = this.m_dgvItem.CurrentCell;
                string strOrgSFLBBH = ((DataRow)this.m_dgvItem.Rows[cCell.RowIndex].Tag)["sflb"].ToString();
                
                System.Drawing.Rectangle rect = this.m_dgvItem.GetCellDisplayRectangle(cCell.ColumnIndex, cCell.RowIndex, true);

                DataView dtvSFLB = this.m_dtBseSFLB.DefaultView;
                dtvSFLB.RowFilter = "sflbbh in( " + m_strIDS + "'" + strOrgSFLBBH + "')";
                this.cobSFLB.DataSource = dtvSFLB.ToTable();
                this.cobSFLB.DisplayMember = "SFLB";
                this.cobSFLB.ValueMember = "sflbbh";
                DataGridViewRow cDGVR = this.m_dgvItem.CurrentRow;
                cobSFLB.Location = new System.Drawing.Point(rect.X + m_dgvItem.Location.X, rect.Y + m_dgvItem.Location.Y);
                this.cobSFLB.BringToFront();
                this.cobSFLB.Focus();

                DataRow[] m_dataRow = null;
                if(cDGVR.Cells[0].Tag == null)
                {
                    m_dataRow = this.m_dtBseSFLB.Select("sflbbh = '" + cDGVR.Cells[6].Tag.ToString() + "'");
                    if(m_dataRow.Length > 0)
                    {
                        this.cobSFLB.Text = m_dataRow[0]["sflb"].ToString();
                        this.cobSFLB.SelectedValue = m_dataRow[0]["sflbbh"].ToString();

                    } 
                }
                else
                {
                    m_dataRow = this.m_dtBseSFLB.Select("sflbbh = '" + cDGVR.Cells[0].Tag.ToString() + "'");
                    if(m_dataRow.Length > 0)
                    {
                        this.cobSFLB.Text = m_dataRow[0]["sflb"].ToString();
                        this.cobSFLB.SelectedValue = m_dataRow[0]["sflbbh"].ToString();

                    }  
                }
            }
        }

        private void cobSFLB_Leave(object sender, EventArgs e)
        {
            this.cobSFLB.SendToBack();
            DataGridViewRow cDgvr = this.m_dgvItem.CurrentRow;
            cDgvr.Cells[0].Tag = this.cobSFLB.SelectedValue;
            cDgvr.Cells[6].Value = this.cobSFLB.Text.Trim(); 
        }

        private void m_dgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.m_dgvItem_CurrentCellChanged(sender, null);
        }

        private void chkSum_CheckedChanged(object sender, EventArgs e)
        {
            if(this.chkSum.Checked == true)
            {
                this.m_dgvItem.Columns[4].ReadOnly = true;
                this.cobSFLB.Enabled = false;
                this.cobSum.Enabled = true;
            }
            else
            {
                this.m_dgvItem.Columns[4].ReadOnly = false;
                this.cobSFLB.Enabled = true;
                this.cobSum.Enabled = false;
            }
        }
        /// <summary>
        /// 获取分隔字符串数值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public List<string> m_glsGettokenNoBlank(string str, char sign)
        {
            string[] strtmp = str.Split(sign);
            int intLen = strtmp.Length;
            List<string> m_glsResult = new List<string>(intLen);

            for (int i = 0; i < intLen; i++)
            {
                if (string.IsNullOrEmpty(strtmp[i].Trim()))
                {
                    continue;
                }
                if (m_glsResult.Contains(strtmp[i].Trim()))
                {
                    continue;
                }

                m_glsResult.Add(strtmp[i]);
            }
            m_glsResult.TrimExcess();

            return m_glsResult;
        }
    }
}