using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmDefRecipeTabpage : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 医生工作站DomainClass
        /// </summary>
        private clsDcl_DoctorWorkstation objDoct;
        /// <summary>
        /// 当前行
        /// </summary>
        private int CurrentRow = -1;

        public frmDefRecipeTabpage()
        {
            InitializeComponent();

            objDoct = new clsDcl_DoctorWorkstation();
        }

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        private void m_mthInit()
        {
            DataTable dt;

            long l = this.objDoct.m_lngGetDoctorList(out dt);

            if (l > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string[] s = new string[4];

                    s[0] = "F";
                    s[1] = dt.Rows[i]["empno_chr"].ToString().Trim();
                    s[2] = dt.Rows[i]["lastname_vchr"].ToString().Trim();
                    s[3] = dt.Rows[i]["deptname"].ToString().Trim();

                    int row = this.dataGridView1.Rows.Add(s);
                    this.dataGridView1.Rows[row].Tag = dt.Rows[i];

                    if (i == 0)
                    {
                        this.m_mthPreviewPurview(dt.Rows[i]["empid_chr"].ToString());
                    }
                }
            }

            ListViewItem lv1 = new ListViewItem("西药权限");
            lv1.ImageIndex = 0;
            lv1.Tag = "1";
            this.lvTop.Items.Add(lv1);

            ListViewItem lv2 = new ListViewItem("中药权限");
            lv2.ImageIndex = 0;
            lv2.Tag = "2";
            this.lvTop.Items.Add(lv2);

            ListViewItem lv3 = new ListViewItem("检验权限");
            lv3.ImageIndex = 0;
            lv3.Tag = "3";
            this.lvTop.Items.Add(lv3);

            ListViewItem lv4 = new ListViewItem("检查权限");
            lv4.ImageIndex = 0;
            lv4.Tag = "4";
            this.lvTop.Items.Add(lv4);

            ListViewItem lv5 = new ListViewItem("治疗权限");
            lv5.ImageIndex = 0;
            lv5.Tag = "5";
            this.lvTop.Items.Add(lv5);
            
        }
        #endregion               

        #region 添加权限
        /// <summary>
        /// 添加权限
        /// </summary>
        private void m_mthAddPurview()
        {
            ArrayList PurviewArr = new ArrayList();

            if (this.lvTop.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                for (int i = 0; i < this.lvTop.SelectedItems.Count; i++)
                {
                    string text = this.lvTop.SelectedItems[i].Text.ToString();                  
                    ListViewItem item = this.lvBottom.FindItemWithText(text);
                    if (item == null)
                    {
                        PurviewArr.Add(this.lvTop.SelectedItems[i].Tag.ToString());
                    }                      
                }                
            }

            if (PurviewArr.Count == 0)
            {
                return;
            }
  
            ArrayList objArr = new ArrayList();            

            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if (this.dataGridView1.Rows[i].Cells[0].Value.ToString().ToUpper() == "T")
                {
                    DataRow dr = this.dataGridView1.Rows[i].Tag as DataRow;
                   
                    com.digitalwave.iCare.ValueObject.clsOutRecipePurview_VO RecipePurview_VO = new com.digitalwave.iCare.ValueObject.clsOutRecipePurview_VO();
                    RecipePurview_VO.EmpID = dr["empid_chr"].ToString();
                    RecipePurview_VO.PurviewArr = PurviewArr;

                    objArr.Add(RecipePurview_VO);
                }
            }

            if (objArr.Count == 0)
            {
                return;
            }

            long l = this.objDoct.m_lngSaveDoctorRecipePurview(objArr, 1);
            if (l > 0)
            {
                this.m_mthAddItem(PurviewArr);
                //MessageBox.Show("添加门诊医生处方权限成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("添加门诊医生处方权限失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion

        #region 删除权限
        /// <summary>
        /// 删除权限
        /// </summary>
        private void m_mthDelPurview()
        {
            ArrayList PurviewArr = new ArrayList();

            if (this.lvBottom.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                for (int i = 0; i < this.lvBottom.SelectedItems.Count; i++)
                {
                    PurviewArr.Add(this.lvBottom.SelectedItems[i].Tag.ToString());                    
                }
            }                                               

            if (CurrentRow == -1)
            {
                return;
            }

            ArrayList objArr = new ArrayList();

            if (this.dataGridView1.Rows[CurrentRow].Cells[0].Value.ToString().ToUpper() == "T")
            {
                DataRow dr = this.dataGridView1.Rows[CurrentRow].Tag as DataRow;

                if (MessageBox.Show("确认删除【" + dr["lastname_vchr"].ToString() + "】医生的处方权限吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }              

                com.digitalwave.iCare.ValueObject.clsOutRecipePurview_VO RecipePurview_VO = new com.digitalwave.iCare.ValueObject.clsOutRecipePurview_VO();
                RecipePurview_VO.EmpID = dr["empid_chr"].ToString();
                RecipePurview_VO.PurviewArr = PurviewArr;

                objArr.Add(RecipePurview_VO);
            }
            else
            {
                return;
            }                      

            long l = this.objDoct.m_lngSaveDoctorRecipePurview(objArr, 2);
            if (l > 0)
            {
                this.m_mthDelItem(PurviewArr);
                //MessageBox.Show("删除门诊医生处方权限成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("删除门诊医生处方权限失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion

        #region 浏览权限
        /// <summary>
        /// 浏览权限
        /// </summary>
        private void m_mthPreviewPurview(string DoctID)
        {
            DataTable dt;

            long l = this.objDoct.m_lngGetDoctorRecipePurview(DoctID, out dt);
            if (l > 0)
            {
                ArrayList PurviewArr = new ArrayList();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PurviewArr.Add(dt.Rows[i]["purview_chr"].ToString());
                }

                this.lvBottom.Items.Clear();

                if (PurviewArr.Count > 0)
                {
                    this.m_mthAddItem(PurviewArr);
                }
            }
        }
        #endregion

        #region 添加LV项目
        /// <summary>
        /// 添加LV项目
        /// </summary>
        /// <param name="objArr"></param>
        private void m_mthAddItem(ArrayList objArr)
        {            
            for (int i = 0; i < objArr.Count; i++)
            {
                int index = int.Parse(objArr[i].ToString());                
                string[] s = new string[5] { "西药权限", "中药权限", "检验权限", "检查权限", "治疗权限" };

                ListViewItem lv = new ListViewItem(s[index - 1]);
                lv.ImageIndex = 0;
                lv.Tag = index.ToString();
                this.lvBottom.Items.Add(lv);                
            }
        }
        #endregion

        #region 删除LV项目
        /// <summary>
        /// 删除LV项目
        /// </summary>
        /// <param name="objArr"></param>
        private void m_mthDelItem(ArrayList objArr)
        {
            for (int i = 0; i < objArr.Count; i++)
            {
                int index = int.Parse(objArr[i].ToString());
                string[] s = new string[5] { "西药权限", "中药权限", "检验权限", "检查权限", "治疗权限" };
                                
                ListViewItem item = this.lvBottom.FindItemWithText(s[index - 1]);
                if (item != null)
                {
                    this.lvBottom.Items.Remove(item);
                }
            }
        }
        #endregion

        private void frmDefRecipeTabpage_Load(object sender, EventArgs e)
        {
            this.m_mthInit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string Status = "F";

            if (this.checkBox1.Checked)
            {
                Status = "T";
            }

            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                this.dataGridView1.Rows[i].Cells[0].Value = Status;
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.Rows[e.RowIndex].Tag == null)
            {
                return;
            }

            CurrentRow = e.RowIndex;

            DataRow dr = this.dataGridView1.Rows[CurrentRow].Tag as DataRow;

            this.m_mthPreviewPurview(dr["empid_chr"].ToString());
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().ToUpper() == "T")
            {
                this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = "F";
            }
            else
            {
                this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = "T";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.m_mthAddPurview();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            this.m_mthDelPurview();
        }

        private void lvTop_DoubleClick(object sender, EventArgs e)
        {
            this.m_mthAddPurview();
        }

        private void lvBottom_DoubleClick(object sender, EventArgs e)
        {
            this.m_mthDelPurview();
        }           
    }
}