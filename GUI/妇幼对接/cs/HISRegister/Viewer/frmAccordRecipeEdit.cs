using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.Utility;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 协定处方维护UI
    /// </summary>
    public partial class frmAccordRecipeEdit : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 变量
        #region 全局变量,保存datagrid输入数据时的行号,为了不回车也能计算金额,-1代表不计算
        public int intRowNo1 = -1;//西药
        public int intRowNo2 = -1;//中药
        public int intRowNo3 = -1;//检验
        public int intRowNo4 = -1;//检查
        public int intRowNo5 = -1;//手术
        public int intRowNo6 = -1;//其他
        public int intRowNoLis = -1;//检验诊疗项目
        public int intRowNoTest = -1;//检查诊疗项目
        public int intRowNoOps = -1;//手术治疗诊疗项目
        #endregion
        /// <summary> 
        /// 处理快捷键输入 true 取消,false输入
        /// </summary>
        internal bool HandleInput = false;
        /// <summary>
        /// 正常前景色
        /// </summary>
        private Color nfc = Color.FromArgb(0, 0, 0);
        /// <summary>
        /// 正常背景色
        /// </summary>
        private Color nbc = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 编辑前景色
        /// </summary>
        private Color efc = Color.FromArgb(222, 239, 165);
        /// <summary>
        /// 当前树节点
        /// </summary>
        internal TreeNode CurrTn;
        /// <summary>
        /// 当前TAB页索引
        /// </summary>
        private int CurrLoaction = -1;
        /// <summary>
        /// DataGrid1
        /// </summary>
        internal com.digitalwave.controls.datagrid.ctlDataGrid DataGrid1;
        /// <summary>
        /// DataGrid2
        /// </summary>
        internal com.digitalwave.controls.datagrid.ctlDataGrid DataGrid2;
        /// <summary>
        /// DataGridLis
        /// </summary>
        internal com.digitalwave.controls.datagrid.ctlDataGrid DataGridLis;
        /// <summary>
        /// DataGridTest
        /// </summary>
        internal com.digitalwave.controls.datagrid.ctlDataGrid DataGridTest;
        /// <summary>
        /// DataGridOps
        /// </summary>
        internal com.digitalwave.controls.datagrid.ctlDataGrid DataGridOps;
        /// <summary>
        /// DataGrid6
        /// </summary>
        internal com.digitalwave.controls.datagrid.ctlDataGrid DataGrid6;
        #endregion

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public frmAccordRecipeEdit()
        {
            InitializeComponent();
        }

        public frmAccordRecipeEdit(com.digitalwave.controls.datagrid.ctlDataGrid d1, com.digitalwave.controls.datagrid.ctlDataGrid d2,
                                   com.digitalwave.controls.datagrid.ctlDataGrid dlis, com.digitalwave.controls.datagrid.ctlDataGrid dtest,
                                   com.digitalwave.controls.datagrid.ctlDataGrid dops, com.digitalwave.controls.datagrid.ctlDataGrid d6, int intLocation)
        {
            InitializeComponent();
            DataGrid1 = d1;
            DataGrid2 = d2;
            DataGridLis = dlis;
            DataGridTest = dtest;
            DataGridOps = dops;
            DataGrid6 = d6;
            CurrLoaction = intLocation;
        }
        #endregion

        #region 控制DataGrid列
        private void m_mthHandleDataGridInput()
        {
            foreach (System.Windows.Forms.Control cc in this.tabControl1.Controls)
            {
                foreach (System.Windows.Forms.Control c in cc.Controls)
                {
                    com.digitalwave.controls.datagrid.ctlDataGrid dategrid = c as com.digitalwave.controls.datagrid.ctlDataGrid;
                    if (dategrid != null)
                    {
                        for (int i = 0; i < dategrid.Columns.Count; i++)
                        {
                            if (((com.digitalwave.controls.datagrid.clsColumnInfo)dategrid.Columns[i]).DataGridTextBoxColumn.TextBox.Enabled == false || ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[i]).DataGridTextBoxColumn.TextBox.MaxLength < 10)
                            {
                                continue;
                            }
                            ((com.digitalwave.controls.datagrid.clsColumnInfo)dategrid.Columns[i]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
                        }
                    }
                }
            }

        }
        private void m_mthSetDataGridFormat()
        {
            m_mthHandleDataGridInput();
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[2]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[13]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[8]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress2);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[0]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress2);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid2.Columns[1]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress);
            
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridLis.Columns[1]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress);
            
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridTest.Columns[1]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress);
            
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridOps.Columns[1]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid6.Columns[1]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress);
            
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[1]).DataGridTextBoxColumn.TextBox.Leave += new EventHandler(TextBox_Leave);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid2.Columns[0]).DataGridTextBoxColumn.TextBox.Leave += new EventHandler(TextBox_Leave);
            
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridLis.Columns[0]).DataGridTextBoxColumn.TextBox.Leave += new EventHandler(TextBox_Leave);
            
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridTest.Columns[0]).DataGridTextBoxColumn.TextBox.Leave += new EventHandler(TextBox_Leave);
            
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridOps.Columns[0]).DataGridTextBoxColumn.TextBox.Leave += new EventHandler(TextBox_Leave);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid6.Columns[0]).DataGridTextBoxColumn.TextBox.Leave += new EventHandler(TextBox_Leave);

            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[2]).DataGridTextBoxColumn.TextBox.MaxLength = 7;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[0]).DataGridTextBoxColumn.TextBox.MaxLength = 2;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid2.Columns[1]).DataGridTextBoxColumn.TextBox.MaxLength = 4;
            
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid6.Columns[1]).DataGridTextBoxColumn.TextBox.MaxLength = 4;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[2]).DataGridTextBoxColumn.TextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[8]).DataGridTextBoxColumn.TextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid2.Columns[1]).DataGridTextBoxColumn.TextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridLis.Columns[1]).DataGridTextBoxColumn.TextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridTest.Columns[1]).DataGridTextBoxColumn.TextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridOps.Columns[1]).DataGridTextBoxColumn.TextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid6.Columns[1]).DataGridTextBoxColumn.TextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;

            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[1]).DataGridTextBoxColumn.TextBox.CharacterCasing = CharacterCasing.Upper;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid2.Columns[0]).DataGridTextBoxColumn.TextBox.CharacterCasing = CharacterCasing.Upper;
            
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridLis.Columns[0]).DataGridTextBoxColumn.TextBox.CharacterCasing = CharacterCasing.Upper;
            
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridTest.Columns[0]).DataGridTextBoxColumn.TextBox.CharacterCasing = CharacterCasing.Upper;
            
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridOps.Columns[0]).DataGridTextBoxColumn.TextBox.CharacterCasing = CharacterCasing.Upper;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid6.Columns[0]).DataGridTextBoxColumn.TextBox.CharacterCasing = CharacterCasing.Upper;

            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[1]).DataGridTextBoxColumn.TextBox.MaxLength = 20;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid2.Columns[0]).DataGridTextBoxColumn.TextBox.MaxLength = 20;
            
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridLis.Columns[0]).DataGridTextBoxColumn.TextBox.MaxLength = 20;
            
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridTest.Columns[0]).DataGridTextBoxColumn.TextBox.MaxLength = 20;
            
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridOps.Columns[0]).DataGridTextBoxColumn.TextBox.MaxLength = 20;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid6.Columns[0]).DataGridTextBoxColumn.TextBox.MaxLength = 20;
        }

        private void txtCount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if ((int)e.KeyChar >= 46 && (int)e.KeyChar <= 57 && (int)e.KeyChar != 47 || (int)e.KeyChar == 8)
            {

            }
            else
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.')
            {
                if (tb.Text.Trim() == "")
                {
                    tb.Text = "0.";
                    System.Windows.Forms.SendKeys.SendWait("{Right}");
                    System.Windows.Forms.SendKeys.SendWait("{Right}");
                    e.Handled = true;
                }
                if (tb.Text.IndexOf(".") > -1)
                {
                    e.Handled = true;
                }
            }
        }
        private void txtCount_KeyPress2(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if ((int)e.KeyChar > 46 && (int)e.KeyChar <= 57 && (int)e.KeyChar != 47 || (int)e.KeyChar == 8)
            {

            }
            else
            {
                e.Handled = true;

            }

        }
        private void TextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (HandleInput)
            {
                e.Handled = true;
                HandleInput = false;
            }

        }
        private void TextBox_Leave(object sender, EventArgs e)
        {
            //myInputLanguage = InputLanguage.CurrentInputLanguage;
        }
        #endregion

        #region 创建CTL对象
        /// <summary>
        /// 创建CTL对象
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_AccordRecipeEdit();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        private void frmAccordRecipeEdit_Load(object sender, EventArgs e)
        {
            ((clsCtl_AccordRecipeEdit)this.objController).m_mthInit();           
            ((clsCtl_AccordRecipeEdit)this.objController).m_mthCreateTree(this.LoginInfo.m_strEmpID);           

            if (CurrLoaction >= 0)
            {
                this.tv.SelectedNode = this.tv.Nodes[0];
                ((clsCtl_AccordRecipeEdit)this.objController).m_mthNew();
                ((clsCtl_AccordRecipeEdit)this.objController).m_mthCreateAccordRecipe();
                
                this.tabControl1.SelectedIndex = CurrLoaction;
            }            
        }

        private void frmAccordRecipeEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("退出窗口前请保存好数据，是否继续退出？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }             

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string FindStr = this.txtFind.Text.Trim();

                if (FindStr == "")
                {
                    return;
                }

                ((clsCtl_AccordRecipeEdit)this.objController).m_mthFindTree(FindStr, true);
            }
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name.ToString().ToLower().StartsWith("child"))
            {
                this.CurrTn = e.Node;
                AccordRecipeEdit obj = e.Node.Tag as AccordRecipeEdit;
                this.txtRecName.Text = obj.OrigeName;
                this.txtUserCode.Text = obj.UserCode_Chr;
                this.txtPyCode.Text = obj.PyCode_Chr;
                this.txtWbCode.Text = obj.WbCode_Chr;
                this.txtReMark.Text = obj.ReMark_Vchr;
                if (obj.Privilege_Int == "0")
                {
                    this.cboUseScope.SelectedIndex = 2;
                }
                else if (obj.Privilege_Int == "1")
                {
                    this.cboUseScope.SelectedIndex = 0;
                }
                else if (obj.Privilege_Int == "2")
                {
                    this.cboUseScope.SelectedIndex = 1;
                }

                if (obj.Status_Int == "1")
                {
                    this.cboStatus.SelectedIndex = 0;
                }
                else
                {
                    this.cboStatus.SelectedIndex = 1;
                }

                ((clsCtl_AccordRecipeEdit)this.objController).m_mthShow(obj.RecipeID_Chr);
            }
        }

        private void ctlDataGrid1_Leave(object sender, EventArgs e)
        {
            if (intRowNo1 > -1)
            {
                ((clsCtl_AccordRecipeEdit)this.objController).m_mthCalculateAmount(intRowNo1);
                intRowNo1 = -1;
            }
        }

        private void ctlDataGrid1_m_evtCurrentCellChanged(object sender, EventArgs e)
        {
            ((clsCtl_AccordRecipeEdit)this.objController).m_mthCalculateAmount();
            ((clsCtl_AccordRecipeEdit)this.objController).m_mthSetColNo1();

            intRowNo1 = -1;
            int row = ctlDataGrid1.CurrentCell.RowNumber;
            if (this.ctlDataGrid1[row, 0].ToString().Trim() == "" || this.ctlDataGrid1[row, 0].ToString().Trim() == "0")
            {
                this.ctlDataGrid1[row, 29] = -4;
            }
            int col = ctlDataGrid1.CurrentCell.ColumnNumber;

            if ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[col] != null)
            {
                //设置前背景色
                ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[col]).DataGridTextBoxColumn.TextBox.BackColor = efc;	//Color.SteelBlue;						
            }
        }

        private void ctlDataGrid1_m_evtDataGridKeyDown(object sender, KeyEventArgs e)
        {
            int row = this.ctlDataGrid1.CurrentCell.RowNumber;
            int col = this.ctlDataGrid1.CurrentCell.ColumnNumber;

            if (e.KeyCode == Keys.F6)
            {
                this.ctlDataGrid1.m_mthDeleteRow(row);
                ctlDataGrid1.CurrentCell = new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber, 0);
                //因为DataGrid有个Bug所以发送下面的模拟键
                SendKeys.SendWait("{Right}");
                SendKeys.SendWait("{Left}");
                SendKeys.SendWait("{Left}");
                return;
            }

            if (e.KeyCode == Keys.Left)
            {
                if (col == ((clsCtl_AccordRecipeEdit)this.objController).c_UsageName)
                {
                    this.ctlDataGrid1.CurrentCell = new DataGridCell(row, ((clsCtl_AccordRecipeEdit)this.objController).c_Count);
                }
                else if (col == ((clsCtl_AccordRecipeEdit)this.objController).c_Total)
                {
                    this.ctlDataGrid1.CurrentCell = new DataGridCell(row, ((clsCtl_AccordRecipeEdit)this.objController).c_Day);
                }
            }
        }

        private void ctlDataGrid1_m_evtDataGridTextBoxKeyDown(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyEventArgs e)
        {
            string m_strText = e.m_strText.Replace("'", "’");
            this.intRowNo1 = e.m_intRowNumber;

            if (e.KeyCode == Keys.Enter)
            {
                switch (e.m_intColNumber)
                {
                    case 0://方号
                        this.ctlDataGrid1.CurrentCell = new DataGridCell(this.intRowNo1, ((clsCtl_AccordRecipeEdit)this.objController).c_Find);
                        break;
                    case 1://查询
                        if (m_strText.Trim() == "")
                        {
                            return;
                        }
                        else
                        {
                            m_strText = m_strText.ToUpper();
                            ((clsCtl_AccordRecipeEdit)this.objController).m_mthFindWMedicineByID(m_strText, e.m_intRowNumber);
                        }
                        break;
                    case 2://数量
                        if (m_strText.Trim() == "")
                        {
                            return;
                        }
                        else
                        {
                            ctlDataGrid1[e.m_intRowNumber, 2] = m_strText;
                            ctlDataGrid1[e.m_intRowNumber, 26] = 1;
                            ctlDataGrid1.CurrentCell = new DataGridCell(e.m_intRowNumber, 6);
                        }
                        break;
                    case 6://用法
                        if (((clsCtl_AccordRecipeEdit)this.objController).m_mthFindUsage(m_strText, e.m_intRowNumber) > 0)
                        {
                            this.listView2.Location = e.m_ptPositionInDataGrid;
                            this.listView2.Top += e.m_szTextBoxSize.Height;
                            this.listView2.Show();
                            this.listView2.BringToFront();
                            this.listView2.Items[0].Selected = true;
                            this.listView2.Select();
                            this.listView2.Focus();
                        }
                        break;
                    case 7://频率
                        if (((clsCtl_AccordRecipeEdit)this.objController).m_mthFindFrequency(m_strText, e.m_intRowNumber) > 0)
                        {
                            this.listView3.Location = e.m_ptPositionInDataGrid;
                            this.listView3.Top += e.m_szTextBoxSize.Height;
                            this.listView3.Show();
                            this.listView3.BringToFront();
                            this.listView3.Items[0].Selected = true;
                            this.listView3.Select();
                            this.listView3.Focus();
                        }
                        break;
                    case 8://天数
                        if (m_strText.Trim() != "")
                        {
                            ctlDataGrid1[e.m_intRowNumber, 26] = 1;
                            ctlDataGrid1[e.m_intRowNumber, 8] = m_strText;
                            ((clsCtl_AccordRecipeEdit)this.objController).m_mthDaysEnter(m_strText);
                        }
                        break;
                    case 13://天数
                        if (m_strText.Trim() != "")
                        {
                            SendKeys.SendWait("{Tab}");
                        }
                        break;
                }
            }
            else
            {
                if (e.m_intColNumber == 13 && m_strText.Trim() != "")
                {
                    ctlDataGrid1[e.m_intRowNumber, 13] = m_strText;
                    ctlDataGrid1[e.m_intRowNumber, 26] = 0;
                    ((clsCtl_AccordRecipeEdit)this.objController).b_IndexChangeFlag = false;
                }
            }
        }

        private void ctlDataGrid2_Leave(object sender, EventArgs e)
        {
            if (this.intRowNo2 > -1)
            {
                ((clsCtl_AccordRecipeEdit)this.objController).m_mthCalculateAmount2(intRowNo2);
            }
        }

        private void ctlDataGrid2_m_evtCurrentCellChanged(object sender, EventArgs e)
        {
            ((clsCtl_AccordRecipeEdit)this.objController).m_mthSetColNo2();

            if (this.intRowNo2 > -1)
            {
                ((clsCtl_AccordRecipeEdit)this.objController).m_mthCalculateAmount2(this.intRowNo2);
                this.intRowNo2 = -1;
            }

            int row = ctlDataGrid1.CurrentCell.RowNumber;
            int col = ctlDataGrid1.CurrentCell.ColumnNumber;

            if ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid2.Columns[col] != null)
            {
                //设置前背景色
                ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid2.Columns[col]).DataGridTextBoxColumn.TextBox.BackColor = efc;	//Color.SteelBlue;			
            }
        }

        private void ctlDataGrid2_m_evtDataGridKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                int intRow = ctlDataGrid2.CurrentCell.RowNumber;
                this.ctlDataGrid2.m_mthDeleteRow(intRow);
                ctlDataGrid2.CurrentCell = new DataGridCell(this.ctlDataGrid2.CurrentCell.RowNumber, 0);
                //因为DataGrid有个Bug所以发送下面的模拟键
                SendKeys.SendWait("{Right}");
                SendKeys.SendWait("{Left}");
                SendKeys.SendWait("{Left}");
                return;
            }
        }

        private void ctlDataGrid2_m_evtDataGridTextBoxKeyDown(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyEventArgs e)
        {
            string m_strText = e.m_strText.Replace("'", "’");
            intRowNo2 = e.m_intRowNumber;
            if (e.KeyCode == Keys.Enter)//查询
            {
                if (e.m_intColNumber == 0)
                {
                    if (m_strText.Trim() == "")
                    {
                        return;
                    }

                    m_strText = m_strText.ToUpper();
                    ((clsCtl_AccordRecipeEdit)this.objController).m_mthFindCMedicineByID(m_strText, e.m_intRowNumber);

                }

                if (e.m_intColNumber == 1)//输入数量
                {
                    if (m_strText.Trim() == "")
                    {
                        return;
                    }

                    this.ctlDataGrid2[e.m_intRowNumber, 1] = m_strText;
                    intRowNo2 = e.m_intRowNumber;
                    if (e.KeyCode == Keys.Enter)
                    {
                        ctlDataGrid2.CurrentCell = new DataGridCell(e.m_intRowNumber, 5);
                    }
                }
                if (e.m_intColNumber == 5)//选择用法
                {
                    if (((clsCtl_AccordRecipeEdit)this.objController).m_mthFindUsage2(m_strText, e.m_intRowNumber) > 0)
                    {
                        this.listView4.Location = e.m_ptPositionInDataGrid;
                        this.listView4.Top += e.m_szTextBoxSize.Height;
                        this.listView4.Show();
                        this.listView4.BringToFront();
                        this.listView4.Items[0].Selected = true;
                        this.listView4.Select();
                        this.listView4.Focus();
                    }
                }
            }
        }

        private void ctlDataGridLis_Leave(object sender, EventArgs e)
        {
            if (intRowNoLis > -1)
            {
                intRowNoLis = -1;
            }
        }

        private void ctlDataGridLis_m_evtCurrentCellChanged(object sender, EventArgs e)
        {
            ((clsCtl_AccordRecipeEdit)this.objController).m_mthSetColNoLis();

            //设置前背景色
            int row = ctlDataGridLis.CurrentCell.RowNumber;
            int col = ctlDataGridLis.CurrentCell.ColumnNumber;

            if ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridLis.Columns[col] != null)
            {
                ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridLis.Columns[col]).DataGridTextBoxColumn.TextBox.BackColor = efc;	//Color.SteelBlue;			
            }
        }

        private void ctlDataGridLis_m_evtDataGridKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                int intRow = ctlDataGridLis.CurrentCell.RowNumber;
                this.ctlDataGridLis.m_mthDeleteRow(intRow);

                ctlDataGridLis.CurrentCell = new DataGridCell(this.ctlDataGridLis.CurrentCell.RowNumber, 0);
                SendKeys.SendWait("{Right}");
                SendKeys.SendWait("{Left}");
                SendKeys.SendWait("{Left}");
                return;
            }
        }

        private void ctlDataGridLis_m_evtDataGridTextBoxKeyDown(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyEventArgs e)
        {
            string m_strText = e.m_strText.Replace("'", "’");
            if (e.KeyCode == Keys.Enter)//查询
            {
                if (e.m_intColNumber == 0)
                {
                    if (m_strText.Trim() == "")
                    {
                        return;
                    }

                    intRowNoLis = e.m_intRowNumber;
                    m_strText = m_strText.ToUpper();

                    ((clsCtl_AccordRecipeEdit)this.objController).m_mthFindOrderLisByID(m_strText, e.m_intRowNumber);

                }
            }
            if (e.m_intColNumber == 1)//输入数量
            {
                intRowNoLis = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    if (m_strText.Trim() == "")
                    {
                        this.ctlDataGridLis[intRowNoLis, ((clsCtl_AccordRecipeEdit)this.objController).t_SumMoney] = "0";
                    }
                    else
                    {
                        this.ctlDataGridLis[intRowNoLis, ((clsCtl_AccordRecipeEdit)this.objController).t_SumMoney] = "";
                    }
                    // ((clsCtl_DoctorWorkstation)this.objController).m_mthCheckMainItemNum(this.ctlDataGridLis[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_resubitem].ToString(), this.ctlDataGridLis[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_MainItemNum].ToString(), m_strText, "lis");
                    SendKeys.SendWait("{Tab}");
                }
            }
            if (e.m_intColNumber == 4)//查询检验类型
            {
                intRowNoLis = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    if (((clsCtl_AccordRecipeEdit)this.objController).m_lngGetLisSampletyType(m_strText, e.m_intRowNumber) > 0)
                    {
                        this.listView5.Location = e.m_ptPositionInDataGrid;
                        this.listView5.Top += e.m_szTextBoxSize.Height;
                        this.listView5.Show();
                        this.listView5.BringToFront();
                        this.listView5.Items[0].Selected = true;
                        this.listView5.Select();
                        this.listView5.Focus();
                    }
                }
            }
        }

        private void ctlDataGridTest_Leave(object sender, EventArgs e)
        {
            if (intRowNoTest > -1)
            {
                intRowNoTest = -1;
            }
        }

        private void ctlDataGridTest_m_evtCurrentCellChanged(object sender, EventArgs e)
        {
            ((clsCtl_AccordRecipeEdit)this.objController).m_mthSetColNoTest();

            //设置前背景色
            int row = ctlDataGridTest.CurrentCell.RowNumber;
            int col = ctlDataGridTest.CurrentCell.ColumnNumber;

            if ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridTest.Columns[col] != null)
            {
                ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridTest.Columns[col]).DataGridTextBoxColumn.TextBox.BackColor = efc; //Color.SteelBlue;			
            }
        }

        private void ctlDataGridTest_m_evtDataGridKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                int intRow = ctlDataGridTest.CurrentCell.RowNumber;
                this.ctlDataGridTest.m_mthDeleteRow(intRow);
                ctlDataGridTest.CurrentCell = new DataGridCell(this.ctlDataGridTest.CurrentCell.RowNumber, 0);
                SendKeys.SendWait("{Right}");
                SendKeys.SendWait("{Left}");
                SendKeys.SendWait("{Left}");
                return;
            }
        }

        private void ctlDataGridTest_m_evtDataGridTextBoxKeyDown(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyEventArgs e)
        {
            string m_strText = e.m_strText.Replace("'", "’");
            if (e.KeyCode == Keys.Enter)//查询
            {
                if (e.m_intColNumber == 0)
                {
                    if (m_strText.Trim() == "")
                    {
                        return;
                    }

                    intRowNoTest = e.m_intRowNumber;
                    m_strText = m_strText.ToUpper();

                    ((clsCtl_AccordRecipeEdit)this.objController).m_mthFindExamineChargeByOrderID(m_strText, e.m_intRowNumber);
                }
            }
            if (e.m_intColNumber == 1)//输入数量
            {
                intRowNoTest = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    this.ctlDataGridTest[e.m_intRowNumber, e.m_intColNumber] = m_strText.Trim();
                    if (m_strText.Trim() == "")
                    {
                        this.ctlDataGridTest[intRowNoTest, ((clsCtl_AccordRecipeEdit)this.objController).t_SumMoney] = "0";
                    }
                    else
                    {
                        this.ctlDataGridTest[intRowNoTest, ((clsCtl_AccordRecipeEdit)this.objController).t_SumMoney] = "";
                    }
                    //((clsCtl_DoctorWorkstation)this.objController).m_mthCheckMainItemNum(this.ctlDataGridTest[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_resubitem].ToString(), this.ctlDataGridTest[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_MainItemNum].ToString(), m_strText, "test");
                    SendKeys.SendWait("{Tab}");
                }
            }
            if (e.m_intColNumber == 4)//输入检查部位
            {
                intRowNoTest = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    if (((clsCtl_AccordRecipeEdit)this.objController).m_mthLoadCheckPart(m_strText, e.m_intRowNumber) > 0)
                    {
                        this.listView5.Location = e.m_ptPositionInDataGrid;
                        this.listView5.Top += e.m_szTextBoxSize.Height;
                        this.listView5.Show();
                        this.listView5.BringToFront();
                        this.listView5.Items[0].Selected = true;
                        this.listView5.Select();
                        this.listView5.Focus();
                    }
                }
            }
        }

        private void ctlDataGridOps_Leave(object sender, EventArgs e)
        {
            if (intRowNoOps > -1)
            {
                intRowNoOps = -1;
            }
        }

        private void ctlDataGridOps_m_evtCurrentCellChanged(object sender, EventArgs e)
        {
            ((clsCtl_AccordRecipeEdit)this.objController).m_mthSetColNoOps();

            //设置前背景色
            int row = ctlDataGridOps.CurrentCell.RowNumber;
            int col = ctlDataGridOps.CurrentCell.ColumnNumber;

            if ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridOps.Columns[col] != null)
            {
                ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridOps.Columns[col]).DataGridTextBoxColumn.TextBox.BackColor = efc;	//Color.SteelBlue;			
            }
        }

        private void ctlDataGridOps_m_evtDataGridKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                int intRow = ctlDataGridOps.CurrentCell.RowNumber;

                this.ctlDataGridOps.m_mthDeleteRow(intRow);
                ctlDataGridOps.CurrentCell = new DataGridCell(this.ctlDataGridOps.CurrentCell.RowNumber, 0);
                //因为DataGrid有个Bug所以发送下面的模拟键
                SendKeys.SendWait("{Right}");
                SendKeys.SendWait("{Left}");
                SendKeys.SendWait("{Left}");
                return;
            }
        }

        private void ctlDataGridOps_m_evtDataGridTextBoxKeyDown(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyEventArgs e)
        {
            string m_strText = e.m_strText.Replace("'", "’");
            if (e.KeyCode == Keys.Enter)//查询
            {
                if (e.m_intColNumber == 0)
                {
                    if (m_strText.Trim() == "")
                    {
                        return;
                    }

                    intRowNoOps = e.m_intRowNumber;
                    m_strText = m_strText.ToUpper();

                    ((clsCtl_AccordRecipeEdit)this.objController).m_mthFindOPSChargeByOrderID(m_strText, e.m_intRowNumber);
                }
            }
            if (e.m_intColNumber == 1)//输入数量
            {
                intRowNoOps = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    this.ctlDataGridOps[e.m_intRowNumber, e.m_intColNumber] = m_strText.Trim();
                    if (m_strText.Trim() == "")
                    {
                        this.ctlDataGridOps[intRowNoOps, ((clsCtl_AccordRecipeEdit)this.objController).o_SumMoney] = "0";
                    }
                    else
                    {
                        this.ctlDataGridOps[intRowNoOps, ((clsCtl_AccordRecipeEdit)this.objController).o_SumMoney] = Convert.ToDecimal(m_strText);
                    }
                    //((clsCtl_DoctorWorkstation)this.objController).m_mthCheckMainItemNum(ctlDataGridOps[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).o_resubitem].ToString(), ctlDataGridOps[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).o_MainItemNum].ToString(), m_strText, "ops");
                    SendKeys.SendWait("{Tab}");
                }
            }
        }

        private void ctlDataGrid6_Leave(object sender, EventArgs e)
        {
            if (intRowNo6 > -1)
            {
                intRowNo6 = -1;
            }
        }

        private void ctlDataGrid6_m_evtCurrentCellChanged(object sender, EventArgs e)
        {
            ((clsCtl_AccordRecipeEdit)this.objController).m_mthSetColNo6();
            if (this.intRowNo6 > -1)
            {
                this.intRowNo6 = -1;
            }

            //设置前背景色
            int row = ctlDataGrid6.CurrentCell.RowNumber;
            int col = ctlDataGrid6.CurrentCell.ColumnNumber;

            if ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid6.Columns[col] != null)
            {
                ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid6.Columns[col]).DataGridTextBoxColumn.TextBox.BackColor = efc;	//Color.SteelBlue;			
            }
        }

        private void ctlDataGrid6_m_evtDataGridKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                int intRow = ctlDataGrid6.CurrentCell.RowNumber;
                this.ctlDataGrid6.m_mthDeleteRow(intRow);
                ctlDataGrid6.CurrentCell = new DataGridCell(this.ctlDataGrid6.CurrentCell.RowNumber, 0);
                SendKeys.SendWait("{Right}");
                SendKeys.SendWait("{Left}");
                SendKeys.SendWait("{Left}");
                return;
            }
        }

        private void ctlDataGrid6_m_evtDataGridTextBoxKeyDown(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyEventArgs e)
        {
            string m_strText = e.m_strText.Replace("'", "’");
            if (e.KeyCode == Keys.Enter)//查询
            {
                if (e.m_intColNumber == 0)
                {

                    if (m_strText.Trim() == "")
                    {
                        return;
                    }
                    intRowNo6 = e.m_intRowNumber;
                    m_strText = m_strText.ToUpper();

                    ((clsCtl_AccordRecipeEdit)this.objController).m_mthFindOtherChargeByID(m_strText, e.m_intRowNumber);
                }
            }
            if (e.m_intColNumber == 1)//输入数量
            {
                intRowNo6 = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    ctlDataGrid6.CurrentCell = new DataGridCell(intRowNo6 + 1, 0);
                }
            }
            if (e.m_intColNumber == 5)//输入单价
            {
                intRowNo6 = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    ctlDataGrid6.CurrentCell = new DataGridCell(intRowNo6 + 1, 0);
                }
            }
        }

        private void listView2_KeyDown(object sender, KeyEventArgs e)
        {
            ((clsCtl_AccordRecipeEdit)this.objController).m_mthListViewKeyDown2(e);
        }

        private void listView2_Leave(object sender, EventArgs e)
        {
            this.listView2.Hide();
        }

        private void listView3_KeyDown(object sender, KeyEventArgs e)
        {
            ((clsCtl_AccordRecipeEdit)this.objController).m_mthListViewKeyDown3(e);
        }

        private void listView3_Leave(object sender, EventArgs e)
        {
            this.listView3.Hide();
        }

        private void listView3_DoubleClick(object sender, EventArgs e)
        {
            ((clsCtl_AccordRecipeEdit)this.objController).m_mthListViewDoubleClick3();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            ((clsCtl_AccordRecipeEdit)this.objController).m_mthListViewDoubleClick();
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            ((clsCtl_AccordRecipeEdit)this.objController).m_mthListViewKeyDown(e);
        }

        private void listView1_Leave(object sender, EventArgs e)
        {
            listView1.Height = 0;
        }

        private void listView4_DoubleClick(object sender, EventArgs e)
        {
            ((clsCtl_AccordRecipeEdit)this.objController).m_mthListViewDoubleClick4();
        }

        private void listView4_KeyDown(object sender, KeyEventArgs e)
        {
            ((clsCtl_AccordRecipeEdit)this.objController).m_mthListView4KeyDown(e);
        }

        private void listView4_Leave(object sender, EventArgs e)
        {
            this.listView4.Hide();
        }

        private void txtRecName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string val = this.txtRecName.Text.Trim();
                if (val != "")
                {
                    clsCreateChinaCode Ccode = new clsCreateChinaCode();
                    this.txtPyCode.Text = Ccode.m_strCreateChinaCode(val, ChinaCode.PY);
                    this.txtWbCode.Text = Ccode.m_strCreateChinaCode(val, ChinaCode.WB);
                }

                this.txtUserCode.Focus();
            }
        }

        private void txtUserCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtReMark.Focus();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ((clsCtl_AccordRecipeEdit)this.objController).m_mthNew();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ((clsCtl_AccordRecipeEdit)this.objController).m_mthDel(this.btnSave.Tag.ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ((clsCtl_AccordRecipeEdit)this.objController).m_mthSave();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {            
            string RecipeID = this.btnSave.Tag.ToString().Trim();      

            ((clsCtl_AccordRecipeEdit)this.objController).m_mthCreateTree(this.LoginInfo.m_strEmpID);
           
            if (RecipeID != "")
            {
                ((clsCtl_AccordRecipeEdit)this.objController).m_mthFindChild(RecipeID);
            }            
        } 
    }
}