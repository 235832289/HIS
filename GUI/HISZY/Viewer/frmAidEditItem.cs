using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 收费项目辅助编辑UI
    /// </summary>
    public partial class frmAidEditItem : Form
    {
        private clsParmItem_VO Item_VO;

        /// <summary>
        /// 构造
        /// </summary>
        public frmAidEditItem(ref clsParmItem_VO vo)
        {
            InitializeComponent();

            Item_VO = vo;
        }        

        private void frmAidEditItem_Load(object sender, EventArgs e)
        {
            clsColumns_VO[] columArr = new clsColumns_VO[]{ new clsColumns_VO("编号","code_vchr",HorizontalAlignment.Left,50),
                                            new clsColumns_VO("拼音码","pycode_chr",HorizontalAlignment.Left,60),
                                            new clsColumns_VO("地点名称","deptname_vchr",HorizontalAlignment.Left,130),
                                            new clsColumns_VO("","deptid_chr",HorizontalAlignment.Left,0)
                                          };

            string SqlSource = @"select deptid_chr, deptname_vchr, pycode_chr, code_vchr
                                   from t_bse_deptdesc
                                  where status_int = 1
                               order by code_vchr";

            this.txtExecArea.m_strSQL = SqlSource;
            this.txtExecArea.m_mthInitListView(columArr);
            this.txtExecArea.m_listView.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

            this.txtExecArea.Value = Item_VO.DeptID;
            this.txtExecArea.Text = Item_VO.DeptName;

            this.lblItemCode.Text = Item_VO.ItemCode;
            this.lblItemName.Text = Item_VO.ItemName;
            this.txtAmount.Text = Item_VO.ItemAmout.ToString();
        }

        private void frmAidEditItem_Activated(object sender, EventArgs e)
        {
            this.txtAmount.Focus();
        }

        #region 编辑
        /// <summary>
        /// 编辑
        /// </summary>
        private void m_mthEdit()
        {
            if (this.txtAmount.Text.Trim() == "")
            {
                MessageBox.Show("请输入数量。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtAmount.Focus();
                return;
            }

            if (!Microsoft.VisualBasic.Information.IsNumeric(this.txtAmount.Text.Trim()))
            {
                MessageBox.Show("数量输入错误，请重新输入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtAmount.SelectAll();
                this.txtAmount.Focus();
                return;
            }

            //if (Item_VO.AllowNegative == false)
            //{
            //    if (clsPublic.ConvertObjToDecimal(this.txtAmount.Text.Trim()) < 0)
            //    {
            //        MessageBox.Show("当前系统设置为：禁止非中心药房的人员在补记帐时录负数冲帐。\r\n\r\n请重新输入数量。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        this.txtAmount.SelectAll();
            //        this.txtAmount.Focus();
            //        return;
            //    }
            //}

            if (this.txtExecArea.Value == null || this.txtExecArea.Value.ToString().Trim() == "")
            {
                MessageBox.Show("请选择执行地点。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                this.txtExecArea.Focus();
                return;
            }

            if (Item_VO.ItemAmout == clsPublic.ConvertObjToDecimal(this.txtAmount.Text.Trim()) &&
               Item_VO.DeptID == this.txtExecArea.Value.ToString())
            {
                this.Close();
            }
            else
            {
                Item_VO.ItemAmout = clsPublic.ConvertObjToDecimal(this.txtAmount.Text.Trim());
                Item_VO.DeptID = this.txtExecArea.Value.ToString();
                Item_VO.DeptName = this.txtExecArea.Text.Trim();                

                this.DialogResult = DialogResult.OK;
            }
        }
        #endregion

        private void frmAidEditItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F8)
            {
                this.m_mthEdit();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.m_mthEdit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }                
    }
}