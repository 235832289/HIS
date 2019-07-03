using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 查询收费项目UI
    /// </summary>
    public partial class frmAidFindItem : Form
    {
        #region 变量
        /// <summary>
        /// 数据源
        /// </summary>
        private DataGridView DGV;
        /// <summary>
        /// 标志 1 帐务查询->明细费用 2 帐务查询->诊疗项目
        /// </summary>
        private int dvFlag = 1;
        /// <summary>
        /// 满足条件的记录行号
        /// </summary>
        internal int Row = -1;
        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="dgv">数据源</param>
        /// <param name="flag">标志 1 帐务查询->明细费用 2 帐务查询->诊疗项目</param>
        public frmAidFindItem(DataGridView dgv, int flag)
        {
            InitializeComponent();
            DGV = dgv;
            dvFlag = flag;
        }
        
        private void frmAidFindItem_Load(object sender, EventArgs e)
        {
            if (dvFlag == 1)
            {
                this.Text = "查找收费项目(按代码、拼音、名称)";
            }
            else if (dvFlag == 2)
            {
                this.Text = "查找诊疗项目(按拼音、名称)";
            }
        }

        private void frmAidFindItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtVal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string val = this.txtVal.Text.Trim();

                if (val == "")
                {
                    return;
                }
                else
                {
                    bool b = false;
                    if (dvFlag == 1)
                    {
                        for (int i = 0; i < this.DGV.Rows.Count; i++)
                        {
                            if (this.DGV.Rows[i].Cells["colxmdm"].Value.ToString().Contains(val) || this.DGV.Rows[i].Cells["colpym"].Value.ToString().ToUpper().Contains(val) || this.DGV.Rows[i].Cells["colxmmc"].Value.ToString().Contains(val))
                            {
                                Row = i;
                                b = true;
                                break;
                            }
                        }
                    }
                    else if (dvFlag == 2)
                    {
                        for (int i = 0; i < this.DGV.Rows.Count; i++)
                        {
                            if (this.DGV.Rows[i].Cells["colpym"].Value.ToString().ToUpper().Contains(val) || this.DGV.Rows[i].Cells["colzlxmmc"].Value.ToString().Contains(val))
                            {
                                Row = i;
                                b = true;
                                break;
                            }
                        }
                    }

                    if (b)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("没有找到满足条件的收费项目。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }             
    }
}