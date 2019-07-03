using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
using System.Data;
using System.Collections;
using System.Text;
using System.Drawing;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 协定处方浏览逻辑类
    /// </summary>
    public class clsCtl_AccordRecipeList : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量
        /// <summary>
        /// DoctorWorkstation-DoMain类
        /// </summary>
        private clsDcl_DoctorWorkstation objSvc;
        #endregion

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsCtl_AccordRecipeList()
        {
            objSvc = new clsDcl_DoctorWorkstation();
        }
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 对象
        /// </summary>
        public com.digitalwave.iCare.gui.HIS.frmAccordRecipeList m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmAccordRecipeList)frmMDI_Child_Base_in;
        }
        #endregion

        #region 建树
        /// <summary>
        /// 建树
        /// </summary>
        public void m_mthCreateTree(string EmpID)
        {
            DataTable dt;

            try
            {
                this.m_objViewer.Cursor = Cursors.WaitCursor;
                long l = this.objSvc.m_lngFindAccordRecipe(EmpID, out dt);
                if (l > 0)
                {
                    this.m_objViewer.tv.BeginUpdate();
                    this.m_objViewer.tv.Nodes.Clear();

                    DataView DV = new DataView(dt);
                    DV.RowFilter = "status_int = 1";
                    DV.Sort = "recipename_chr asc";

                    ArrayList RecArr = new ArrayList();
                    DataRow dr = null;
                    for (int i = 0; i < DV.Count; i++)
                    {
                        dr = DV[i].Row;

                        AccordRecipeEdit objAR = new AccordRecipeEdit();
                        objAR.RecipeID_Chr = dr["recipeid_chr"].ToString().Trim();
                        objAR.Recipename_Chr = dr["recipename_chr"].ToString().Trim();
                        objAR.UserCode_Chr = dr["usercode_chr"].ToString().Trim();
                        objAR.PyCode_Chr = dr["pycode_chr"].ToString().Trim();
                        objAR.WbCode_Chr = dr["wbcode_chr"].ToString().Trim();
                        objAR.Privilege_Int = dr["privilege_int"].ToString();
                        objAR.Status_Int = dr["status_int"].ToString();
                        objAR.ReMark_Vchr = dr["diseasename_vchr"].ToString();
                        objAR.OrigeName = dr["recipename_chr"].ToString().Trim();
                        RecArr.Add(objAR);
                    }

                    this.m_objViewer.tv.Nodes.Add("协定处方模板列表");
                    TreeNode FirstNode = null;
                    TreeNode FindNode = this.m_objViewer.tv.Nodes[0];
                    FindNode.Tag = "root";
                    FindNode.Name = "root";
                    FindNode.ImageIndex = 1;
                    FindNode.SelectedImageIndex = 1;

                    int count = 0;
                    bool Exists = false;

                    foreach (AccordRecipeEdit objRecipe in RecArr)
                    {
                        FindNode = this.m_objViewer.tv.Nodes[0];

                        string[] SplitArr = objRecipe.LevelNameArr;

                        for (int i = 0; i < SplitArr.Length; i++)
                        {
                            Exists = false;
                            for (int j = 0; j < FindNode.Nodes.Count; j++)
                            {
                                if (SplitArr[i] == FindNode.Nodes[j].Text)
                                {
                                    Exists = true;
                                    FindNode = FindNode.Nodes[j];
                                    break;
                                }
                            }

                            if (Exists)
                            {
                                if (i == SplitArr.Length - 1)
                                {
                                    TreeNode tnAdd = new TreeNode(SplitArr[i].Trim());
                                    FindNode.Parent.Nodes.Add(tnAdd);
                                    tnAdd.Tag = objRecipe;
                                    tnAdd.ImageIndex = 0;
                                    tnAdd.SelectedImageIndex = 5;
                                    tnAdd.Name = "child->" + SplitArr[i].Trim();
                                }
                            }
                            else
                            {
                                TreeNode tnAdd = new TreeNode(SplitArr[i].Trim());
                                FindNode.Nodes.Add(tnAdd);
                                if (i == SplitArr.Length - 1)
                                {
                                    tnAdd.Tag = objRecipe;
                                    tnAdd.ImageIndex = 0;
                                    tnAdd.SelectedImageIndex = 5;
                                    tnAdd.Name = "child->" + SplitArr[i].Trim();
                                }
                                else
                                {
                                    tnAdd.ImageIndex = 2;
                                    tnAdd.SelectedImageIndex = 5;
                                    tnAdd.Name = "parent->" + SplitArr[i].Trim();
                                }
                                if (count == 0)
                                {
                                    FirstNode = tnAdd;
                                    count++;
                                }

                                FindNode = tnAdd;
                            }
                        }
                    }

                    this.m_objViewer.tv.EndUpdate();
                    this.m_objViewer.tv.SelectedNode = FirstNode;
                }
            }
            finally
            {
                this.m_objViewer.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region 查找
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="FindStr"></param>
        /// <param name="ChildFlag"></param>
        public void m_mthFindTree(string FindStr, bool ChildFlag)
        {
            bool FindFlag = false;
            TreeNodeCollection nodes = this.m_objViewer.tv.Nodes;
            foreach (TreeNode n in nodes)
            {
                //递归查找树节点
                FindRecursive(n, FindStr.ToLower(), ChildFlag, ref FindFlag);
            }
        }

        /// <summary>
        /// 递归查找树节点
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="FindStr"></param>
        /// <param name="ChildFlag"></param>
        /// <param name="FindFlag"></param>
        private void FindRecursive(TreeNode treeNode, string FindStr, bool ChildFlag, ref bool FindFlag)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                //if (tn.Tag == null)
                //{
                //    continue;
                //}

                if (FindFlag)
                {
                    return;
                }

                if (ChildFlag)
                {
                    if (tn.Name.ToString().ToLower().StartsWith("child"))
                    {
                        AccordRecipeEdit objAR = tn.Tag as AccordRecipeEdit;
                        if (objAR.UserCode_Chr.ToLower().StartsWith(FindStr) || objAR.PyCode_Chr.ToLower().StartsWith(FindStr) ||
                            objAR.WbCode_Chr.ToLower().StartsWith(FindStr) || objAR.Recipename_Chr.ToLower().StartsWith(FindStr))
                        {
                            if (!tn.IsSelected)
                            {
                                this.m_objViewer.tv.SelectedNode = tn;
                            }

                            if (!tn.IsExpanded)
                            {
                                tn.Expand();
                            }

                            FindFlag = true;

                            return;
                        }
                    }
                    else
                    {
                        FindRecursive(tn, FindStr, ChildFlag, ref FindFlag);
                    }
                }
                else
                {
                    string tnName = tn.Name.ToString().ToLower().Replace("parent->", "").Replace("child->", "");
                    if (tnName.StartsWith(FindStr))
                    {
                        if (!tn.IsSelected)
                        {
                            this.m_objViewer.tv.SelectedNode = tn;
                        }

                        if (!tn.IsExpanded)
                        {
                            tn.Expand();
                        }

                        FindFlag = true;

                        return;
                    }
                    else
                    {
                        FindRecursive(tn, FindStr, ChildFlag, ref FindFlag);
                    }
                }
            }
        }
        #endregion

        #region 显示
        /// <summary>
        /// 显示
        /// </summary>
        public void m_mthShow(string RecipeID)
        {
            if (RecipeID.Trim() == "")
            {
                return;
            }

            this.m_objViewer.btnOk.Tag = RecipeID;
            this.m_objViewer.dtgOrderItem.Rows.Clear();

            int row = 0;
            int rowcount = 0;
            long l = 0;
            DataTable dt;
            DataRow dr;

            #region 西药
            l = this.objSvc.m_lngGetAccordRecipe(RecipeID, 1, out dt);
            if (l > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];

                    string[] sarr = new string[11];
                    sarr[0] = "T";
                    rowcount = this.m_objViewer.dtgOrderItem.Rows.Count + 1;
                    sarr[1] = rowcount.ToString();
                    sarr[2] = dr["recno"].ToString().Trim();
                    sarr[3] = dr["itemname_vchr"].ToString().Trim();
                    sarr[4] = dr["itemspec_vchr"].ToString().Trim();
                    sarr[5] = dr["dosageunit_chr"].ToString().Trim();
                    sarr[6] = dr["freqname"].ToString().Trim();
                    sarr[7] = dr["usagename_vchr"].ToString().Trim();
                    sarr[8] = dr["recqty"].ToString().Trim();
                    sarr[9] = dr["submoney"].ToString().Trim();
                    sarr[10] = clsPublic.Round(clsPublic.ConvertObjToDecimal(dr["recqty"]) * clsPublic.ConvertObjToDecimal(dr["submoney"]), 2).ToString();

                    row = this.m_objViewer.dtgOrderItem.Rows.Add(sarr);
                    this.m_objViewer.dtgOrderItem.Rows[row].Tag = dr;

                    if (Math.IEEERemainder(Convert.ToDouble(rowcount), 2) == 0)
                    {
                        this.m_objViewer.dtgOrderItem.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                    }

                    if (dr["noqtyflag_int"].ToString().Trim() != "0")
                    {
                        this.m_objViewer.dtgOrderItem.Rows[row].Cells[0].Value = "F";
                        this.m_objViewer.dtgOrderItem.Rows[row].DefaultCellStyle.ForeColor = Color.Red;
                        this.m_objViewer.dtgOrderItem.Rows[row].Cells[0].ReadOnly = true;
                    }

                    if (dr["ifstop_int"].ToString().Trim() != "0")
                    {
                        this.m_objViewer.dtgOrderItem.Rows[row].Cells[0].Value = "F";
                        this.m_objViewer.dtgOrderItem.Rows[row].DefaultCellStyle.ForeColor = Color.Gray;
                        this.m_objViewer.dtgOrderItem.Rows[row].Cells[0].ReadOnly = true;
                    }
                }
            }
            #endregion

            #region 中药
            l = this.objSvc.m_lngGetAccordRecipe(RecipeID, 2, out dt);
            if (l > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];

                    string[] sarr = new string[11];
                    sarr[0] = "T";
                    rowcount = this.m_objViewer.dtgOrderItem.Rows.Count + 1;
                    sarr[1] = rowcount.ToString();
                    sarr[2] = "";
                    sarr[3] = dr["itemname_vchr"].ToString().Trim();
                    sarr[4] = dr["itemspec_vchr"].ToString().Trim();
                    sarr[5] = dr["dosageunit_chr"].ToString().Trim();
                    sarr[6] = "";
                    sarr[7] = dr["usagename_vchr"].ToString().Trim();
                    sarr[8] = dr["recqty"].ToString().Trim();
                    sarr[9] = dr["submoney"].ToString().Trim();
                    sarr[10] = clsPublic.Round(clsPublic.ConvertObjToDecimal(dr["recqty"]) * clsPublic.ConvertObjToDecimal(dr["submoney"]), 2).ToString();

                    row = this.m_objViewer.dtgOrderItem.Rows.Add(sarr);
                    this.m_objViewer.dtgOrderItem.Rows[row].Tag = dr;

                    if (Math.IEEERemainder(Convert.ToDouble(rowcount), 2) == 0)
                    {
                        this.m_objViewer.dtgOrderItem.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                    }

                    if (dr["noqtyflag_int"].ToString().Trim() != "0")
                    {
                        this.m_objViewer.dtgOrderItem.Rows[row].Cells[0].Value = "F";
                        this.m_objViewer.dtgOrderItem.Rows[row].DefaultCellStyle.ForeColor = Color.Red;
                        this.m_objViewer.dtgOrderItem.Rows[row].Cells[0].ReadOnly = true;
                    }

                    if (dr["ifstop_int"].ToString().Trim() != "0")
                    {
                        this.m_objViewer.dtgOrderItem.Rows[row].Cells[0].Value = "F";
                        this.m_objViewer.dtgOrderItem.Rows[row].DefaultCellStyle.ForeColor = Color.Gray;
                        this.m_objViewer.dtgOrderItem.Rows[row].Cells[0].ReadOnly = true;
                    }
                }
            }
            #endregion

            #region 检验
            l = this.objSvc.m_lngGetAccordRecipe(RecipeID, 3, out dt);
            if (l > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];

                    string[] sarr = new string[11];
                    sarr[0] = "T";
                    rowcount = this.m_objViewer.dtgOrderItem.Rows.Count + 1;
                    sarr[1] = rowcount.ToString();
                    sarr[2] = "";
                    sarr[3] = dr["name_chr"].ToString().Trim();
                    sarr[4] = dr["itemspec_vchr"].ToString().Trim();
                    sarr[5] = dr["itemunit"].ToString().Trim();
                    sarr[6] = "";
                    sarr[7] = "";
                    sarr[8] = dr["recqty"].ToString().Trim();
                    sarr[9] = "";
                    sarr[10] = "";

                    row = this.m_objViewer.dtgOrderItem.Rows.Add(sarr);
                    this.m_objViewer.dtgOrderItem.Rows[row].Tag = dr;

                    if (Math.IEEERemainder(Convert.ToDouble(rowcount), 2) == 0)
                    {
                        this.m_objViewer.dtgOrderItem.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                    }

                    if (dr["ifstop_int"].ToString().Trim() != "0")
                    {
                        this.m_objViewer.dtgOrderItem.Rows[row].Cells[0].Value = "F";
                        this.m_objViewer.dtgOrderItem.Rows[row].DefaultCellStyle.ForeColor = Color.Gray;
                        this.m_objViewer.dtgOrderItem.Rows[row].Cells[0].ReadOnly = true;
                    }
                }
            }
            #endregion

            #region 检查
            l = this.objSvc.m_lngGetAccordRecipe(RecipeID, 4, out dt);
            if (l > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];

                    string[] sarr = new string[11];
                    sarr[0] = "T";
                    rowcount = this.m_objViewer.dtgOrderItem.Rows.Count + 1;
                    sarr[1] = rowcount.ToString();
                    sarr[2] = "";
                    sarr[3] = dr["name_chr"].ToString().Trim();
                    sarr[4] = dr["itemspec_vchr"].ToString().Trim();
                    sarr[5] = dr["itemunit"].ToString().Trim();
                    sarr[6] = "";
                    sarr[7] = "";
                    sarr[8] = dr["recqty"].ToString().Trim();
                    sarr[9] = "";
                    sarr[10] = "";

                    row = this.m_objViewer.dtgOrderItem.Rows.Add(sarr);
                    this.m_objViewer.dtgOrderItem.Rows[row].Tag = dr;

                    if (Math.IEEERemainder(Convert.ToDouble(rowcount), 2) == 0)
                    {
                        this.m_objViewer.dtgOrderItem.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                    }

                    if (dr["ifstop_int"].ToString().Trim() != "0")
                    {
                        this.m_objViewer.dtgOrderItem.Rows[row].Cells[0].Value = "F";
                        this.m_objViewer.dtgOrderItem.Rows[row].DefaultCellStyle.ForeColor = Color.Gray;
                        this.m_objViewer.dtgOrderItem.Rows[row].Cells[0].ReadOnly = true;
                    }
                }
            }
            #endregion

            #region 治疗
            l = this.objSvc.m_lngGetAccordRecipe(RecipeID, 5, out dt);
            if (l > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];

                    string[] sarr = new string[11];
                    sarr[0] = "T";
                    rowcount = this.m_objViewer.dtgOrderItem.Rows.Count + 1;
                    sarr[1] = rowcount.ToString();
                    sarr[2] = "";
                    sarr[3] = dr["name_chr"].ToString().Trim();
                    sarr[4] = dr["itemspec_vchr"].ToString().Trim();
                    sarr[5] = dr["itemunit"].ToString().Trim();
                    sarr[6] = "";
                    sarr[7] = "";
                    sarr[8] = dr["recqty"].ToString().Trim();
                    sarr[9] = "";
                    sarr[10] = "";

                    row = this.m_objViewer.dtgOrderItem.Rows.Add(sarr);
                    this.m_objViewer.dtgOrderItem.Rows[row].Tag = dr;

                    if (Math.IEEERemainder(Convert.ToDouble(rowcount), 2) == 0)
                    {
                        this.m_objViewer.dtgOrderItem.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                    }

                    if (dr["ifstop_int"].ToString().Trim() != "0")
                    {
                        this.m_objViewer.dtgOrderItem.Rows[row].Cells[0].Value = "F";
                        this.m_objViewer.dtgOrderItem.Rows[row].DefaultCellStyle.ForeColor = Color.Gray;
                        this.m_objViewer.dtgOrderItem.Rows[row].Cells[0].ReadOnly = true;
                    }
                }
            }
            #endregion

            #region 其他
            l = this.objSvc.m_lngGetAccordRecipe(RecipeID, 6, out dt);
            if (l > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];

                    string[] sarr = new string[11];
                    sarr[0] = "T";
                    rowcount = this.m_objViewer.dtgOrderItem.Rows.Count + 1;
                    sarr[1] = rowcount.ToString();
                    sarr[2] = "";
                    sarr[3] = dr["itemname_vchr"].ToString().Trim();
                    sarr[4] = dr["itemspec_vchr"].ToString().Trim();
                    sarr[5] = dr["itemopunit_chr"].ToString().Trim();
                    sarr[6] = "";
                    sarr[7] = "";
                    sarr[8] = dr["recqty"].ToString().Trim();
                    sarr[9] = dr["itemprice_mny"].ToString().Trim();
                    sarr[10] = clsPublic.Round(clsPublic.ConvertObjToDecimal(dr["recqty"]) * clsPublic.ConvertObjToDecimal(dr["itemprice_mny"]), 2).ToString();

                    row = this.m_objViewer.dtgOrderItem.Rows.Add(sarr);
                    this.m_objViewer.dtgOrderItem.Rows[row].Tag = dr;

                    if (Math.IEEERemainder(Convert.ToDouble(rowcount), 2) == 0)
                    {
                        this.m_objViewer.dtgOrderItem.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                    }

                    if (dr["noqtyflag_int"].ToString().Trim() != "0")
                    {
                        this.m_objViewer.dtgOrderItem.Rows[row].Cells[0].Value = "F";
                        this.m_objViewer.dtgOrderItem.Rows[row].DefaultCellStyle.ForeColor = Color.Red;
                        this.m_objViewer.dtgOrderItem.Rows[row].Cells[0].ReadOnly = true;
                    }

                    if (dr["ifstop_int"].ToString().Trim() != "0")
                    {
                        this.m_objViewer.dtgOrderItem.Rows[row].Cells[0].Value = "F";
                        this.m_objViewer.dtgOrderItem.Rows[row].DefaultCellStyle.ForeColor = Color.Gray;
                        this.m_objViewer.dtgOrderItem.Rows[row].Cells[0].ReadOnly = true;
                    }
                }
            }
            #endregion
        }
        #endregion

        #region 选择
        /// <summary>
        /// 选择
        /// </summary>
        /// <returns></returns>
        public bool m_blnChoose()
        {
            bool ret = false;

            if (this.m_objViewer.dtgOrderItem.Rows.Count == 0)
            {
                return ret;
            }

            DataRow dr;
            for (int i = 0; i < this.m_objViewer.dtgOrderItem.Rows.Count; i++)
            {
                if (this.m_objViewer.dtgOrderItem.Rows[i].Cells[0].Value.ToString() == "F")
                {
                    continue;
                }

                dr = this.m_objViewer.dtgOrderItem.Rows[i].Tag as DataRow;

                string classid = dr["recclass"].ToString();
                switch (classid)
                {
                    case "1":
                        this.m_objViewer.Arr1.Add(dr);
                        break;
                    case "2":
                        this.m_objViewer.Arr2.Add(dr);
                        break;
                    case "3":
                        this.m_objViewer.Arr3.Add(dr);
                        break;
                    case "4":
                        this.m_objViewer.Arr4.Add(dr);
                        break;
                    case "5":
                        this.m_objViewer.Arr5.Add(dr);
                        break;
                    case "6":
                        this.m_objViewer.Arr6.Add(dr);
                        break;
                    default:
                        break;
                }

                ret = true;
            }

            return ret;
        }
        #endregion
    }
}
