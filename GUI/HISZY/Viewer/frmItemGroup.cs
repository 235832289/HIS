using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 收费组合UI
    /// </summary>
    public partial class frmItemGroup : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造

        /// </summary>
        public frmItemGroup(string pattype, string applyareaid, bool _isChildPrice)
        {
            InitializeComponent();

            PatType = pattype;
            ApplyAreaID = applyareaid;
            this.IsChildPrice = _isChildPrice;
        }

        #region 变量
        /// <summary>
        /// 主项目视图

        /// </summary>
        private DataView dvMain;
        /// <summary>
        /// 明细视图
        /// </summary>
        private DataView dvDet;
        /// <summary>
        /// 身份(费别)
        /// </summary>
        private string PatType = "";
        /// <summary>
        /// 开单科室

        /// </summary>
        private string ApplyAreaID = "";
        /// <summary>
        /// 返回DATAROW数组
        /// </summary>
        internal ArrayList DrArr = new ArrayList();
        /// <summary>
        /// 收费组合数量
        /// </summary>
        internal int Nums = 1;

        bool IsChildPrice { get; set; }

        #endregion

        #region 建树
        /// <summary>
        /// 建树
        /// </summary>
        private void m_mthLoad()
        {
            clsDcl_CommonFind objCom = new clsDcl_CommonFind();

            DataTable dt;

            long l = objCom.m_lngGetItemGroup(this.LoginInfo.m_strEmpID, out dt);
            if (l > 0)
            {
                dvMain = new DataView(dt);

                //子节点id
                string childId = "";
                //子节点text
                string childName = "";

                for (int i = 0; i < 3; i++)
                {
                    int typeid = i;
                    string typecode = "";
                    string typename = "";

                    if (typeid == 0)
                    {
                        typecode = "public";
                        typename = "公用";
                    }
                    else if (typeid == 1)
                    {
                        typeid = 2;
                        typecode = "dept";
                        typename = "科室";
                    }
                    else if (typeid == 2)
                    {
                        typeid = 1;
                        typecode = "indi";
                        typename = "个人";
                    }

                    //typeid: 0 公用 2 个人 1 科室

                    dvMain.RowFilter = "privilege_int = " + typeid.ToString();
                    if (dvMain.Count > 0)
                    {
                        TreeNode tn = new TreeNode(typename);
                        tn.Tag = typecode;
                        tn.ImageIndex = 0;
                        tn.SelectedImageIndex = 0;
                        this.tv.Nodes.Add(tn);

                        for (int j = 0; j < dvMain.Count; j++)
                        {
                            DataRow dr = dvMain[j].Row;

                            childId = dr["recipeid_chr"].ToString();
                            childName = dr["recipename_chr"].ToString().Trim();
                            //childName = "[" + dr["usercode_chr"].ToString() + "] " + dr["recipename_chr"].ToString().Trim();

                            TreeNode tnChild = new TreeNode(childName);
                            tnChild.Tag = childId;
                            tnChild.ImageIndex = 2;
                            tnChild.SelectedImageIndex = 3;
                            tn.Nodes.Add(tnChild);
                        }
                    }
                }

                this.tv.ExpandAll();
                //复原
                dvMain.RowFilter = "1 = 1";
            }
            else
            {
                return;
            }

            l = objCom.m_lngGetItemGroupDet(out dt, PatType, ApplyAreaID );
            if (l > 0)
            {
                dvDet = new DataView(dt);
            }
        }
        #endregion

        #region 查明细

        /// <summary>
        /// 查明细

        /// </summary>
        /// <param name="RecID"></param>
        private void m_mthFillDet(string RecID)
        {
            this.dvRight.Rows.Clear();

            this.Cursor = Cursors.WaitCursor;

            dvDet.RowFilter = "recipeid_chr = '" + RecID + "'";

            for (int i = 0; i < dvDet.Count; i++)
            {
                DataRow dr = dvDet[i].Row;

                string[] sarr = new string[7];

                sarr[1] = dr["itemcode_vchr"].ToString().Trim();
                sarr[2] = dr["itemname_vchr"].ToString().Trim();
                sarr[3] = dr["itemspec_vchr"].ToString().Trim();
                sarr[4] = dr["itemprice_mny"].ToString().Trim();
                sarr[5] = dr["amount"].ToString().Trim();

                int flag = 0;

                //优先停用->缺药
                if (dr["ifstop_int"].ToString() == "1")
                {
                    sarr[0] = "F";
                    sarr[6] = "停用";
                    flag = 1;
                }
                else
                {
                    sarr[0] = "T";

                    if (dr["noqtyflag_int"].ToString() == "1")
                    {
                        sarr[0] = "F";
                        sarr[6] = "缺药";
                        flag = 2;
                    }
                }

                int row = this.dvRight.Rows.Add(sarr);
                this.dvRight.Rows[row].Tag = dr;

                if (flag == 1)
                {
                    this.dvRight.Rows[row].Cells[0].ReadOnly = true;
                    this.dvRight.Rows[row].DefaultCellStyle.ForeColor = Color.Red;
                }
                else if (flag == 2)
                {
                    this.dvRight.Rows[row].DefaultCellStyle.ForeColor = Color.Blue;
                }

                if (Math.IEEERemainder(row, 2) == 0)
                {
                    this.dvRight.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                }
            }

            this.Cursor = Cursors.Default;
        }
        #endregion

        #region 全选

        /// <summary>
        /// 全选

        /// </summary>
        private void m_mthAllSelect()
        {
            for (int i = 0; i < this.dvRight.Rows.Count; i++)
            {
                if (this.dvRight.Rows[i].Cells[0].ReadOnly)
                {
                    continue;
                }

                this.dvRight.Rows[i].Cells[0].Value = "T";
            }
        }
        #endregion

        #region 反选

        /// <summary>
        /// 反选

        /// </summary>
        private void m_mthDeSelect()
        {
            for (int i = 0; i < this.dvRight.Rows.Count; i++)
            {
                if (this.dvRight.Rows[i].Cells[0].ReadOnly)
                {
                    continue;
                }

                if (this.dvRight.Rows[i].Cells[0].Value.ToString() == "T")
                {
                    this.dvRight.Rows[i].Cells[0].Value = "F";
                }
                else
                {
                    this.dvRight.Rows[i].Cells[0].Value = "T";
                }
            }
        }
        #endregion

        #region 确定
        /// <summary>
        /// 确定
        /// </summary>
        private void m_mthOK()
        {
            if (this.dvRight.Rows.Count == 0)
            {
                return;
            }

            for (int i = 0; i < this.dvRight.Rows.Count; i++)
            {
                if (this.dvRight.Rows[i].Cells[0].Value.ToString() == "T")
                {
                    DataRow dr = this.dvRight.Rows[i].Tag as DataRow;
                    DrArr.Add(dr);
                }
            }

            if (DrArr.Count == 0)
            {
                MessageBox.Show("对不起，你没有选择什么收费项目。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                this.Nums = int.Parse(this.txtNums.Value.ToString());
                this.DialogResult = DialogResult.OK;
            }
        }
        #endregion

        private void frmItemGroup_Load(object sender, EventArgs e)
        {
            this.m_mthLoad();
        }

        private void frmItemGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F4)
            {
                this.m_mthDeSelect();
            }
            else if (e.KeyCode == Keys.F5)
            {
                this.m_mthAllSelect();
            }
            else if (e.KeyCode == Keys.F8)
            {
                this.m_mthOK();
            }
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string recid = e.Node.Tag.ToString();

            if (recid.Trim() == "" || recid.ToLower() == "public" || recid.ToLower() == "dept" || recid.ToLower() == "indi")
            {
                return;
            }
            else
            {
                this.m_mthFillDet(recid);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.m_mthOK();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}