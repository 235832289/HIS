using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// frmSystemSeting 的摘要说明。
    /// </summary>
    public class frmSystemSeting : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        internal com.digitalwave.controls.datagrid.ctlDataGrid m_dtgGroup;
        private PinkieControls.ButtonXP m_btnSave;
        private PinkieControls.ButtonXP m_btnExit;
        internal System.Windows.Forms.ListView lsvConfig;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmSystemSeting()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo1 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo2 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo3 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo4 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo5 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            this.m_dtgGroup = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.m_btnSave = new PinkieControls.ButtonXP();
            this.m_btnExit = new PinkieControls.ButtonXP();
            this.lsvConfig = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // m_dtgGroup
            // 
            this.m_dtgGroup.AllowAddNew = false;
            this.m_dtgGroup.AllowDelete = false;
            this.m_dtgGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.m_dtgGroup.AutoAppendRow = false;
            this.m_dtgGroup.AutoScroll = true;
            this.m_dtgGroup.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_dtgGroup.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dtgGroup.CaptionText = "";
            this.m_dtgGroup.CaptionVisible = false;
            this.m_dtgGroup.CausesValidation = false;
            this.m_dtgGroup.ColumnHeadersVisible = true;
            clsColumnInfo1.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo1.BackColor = System.Drawing.Color.White;
            clsColumnInfo1.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo1.ColumnIndex = 0;
            clsColumnInfo1.ColumnName = "Column1";
            clsColumnInfo1.ColumnWidth = 60;
            clsColumnInfo1.Enabled = false;
            clsColumnInfo1.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo1.HeadText = "编号";
            clsColumnInfo1.ReadOnly = true;
            clsColumnInfo1.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo2.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo2.BackColor = System.Drawing.Color.White;
            clsColumnInfo2.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo2.ColumnIndex = 1;
            clsColumnInfo2.ColumnName = "Column2";
            clsColumnInfo2.ColumnWidth = 180;
            clsColumnInfo2.Enabled = false;
            clsColumnInfo2.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo2.HeadText = "名称";
            clsColumnInfo2.ReadOnly = true;
            clsColumnInfo2.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo3.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo3.BackColor = System.Drawing.Color.White;
            clsColumnInfo3.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo3.ColumnIndex = 2;
            clsColumnInfo3.ColumnName = "Column3";
            clsColumnInfo3.ColumnWidth = 480;
            clsColumnInfo3.Enabled = false;
            clsColumnInfo3.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo3.HeadText = "描述";
            clsColumnInfo3.ReadOnly = true;
            clsColumnInfo3.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo4.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo4.BackColor = System.Drawing.Color.White;
            clsColumnInfo4.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Int;
            clsColumnInfo4.ColumnIndex = 3;
            clsColumnInfo4.ColumnName = "Column7";
            clsColumnInfo4.ColumnWidth = 40;
            clsColumnInfo4.Enabled = true;
            clsColumnInfo4.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo4.HeadText = "状态";
            clsColumnInfo4.ReadOnly = false;
            clsColumnInfo4.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo5.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo5.BackColor = System.Drawing.Color.White;
            clsColumnInfo5.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo5.ColumnIndex = 4;
            clsColumnInfo5.ColumnName = "Column8";
            clsColumnInfo5.ColumnWidth = 60;
            clsColumnInfo5.Enabled = true;
            clsColumnInfo5.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo5.HeadText = "模块ID";
            clsColumnInfo5.ReadOnly = false;
            clsColumnInfo5.TextFont = new System.Drawing.Font("宋体", 10F);
            this.m_dtgGroup.Columns.Add(clsColumnInfo1);
            this.m_dtgGroup.Columns.Add(clsColumnInfo2);
            this.m_dtgGroup.Columns.Add(clsColumnInfo3);
            this.m_dtgGroup.Columns.Add(clsColumnInfo4);
            this.m_dtgGroup.Columns.Add(clsColumnInfo5);
            this.m_dtgGroup.FullRowSelect = false;
            this.m_dtgGroup.Location = new System.Drawing.Point(192, 16);
            this.m_dtgGroup.MultiSelect = false;
            this.m_dtgGroup.Name = "m_dtgGroup";
            this.m_dtgGroup.ReadOnly = false;
            this.m_dtgGroup.RowHeadersVisible = false;
            this.m_dtgGroup.RowHeaderWidth = 35;
            this.m_dtgGroup.SelectedRowBackColor = System.Drawing.Color.Purple;
            this.m_dtgGroup.SelectedRowForeColor = System.Drawing.Color.White;
            this.m_dtgGroup.Size = new System.Drawing.Size(818, 520);
            this.m_dtgGroup.TabIndex = 3;
            this.m_dtgGroup.m_evtCurrentCellChanged += new System.EventHandler(this.m_dtgGroup_m_evtCurrentCellChanged);
            this.m_dtgGroup.m_evtDataGridTextBoxKeyDown += new com.digitalwave.controls.datagrid.clsDGTextKeyEventHandler(this.m_dtgGroup_m_evtDataGridTextBoxKeyDown);
            // 
            // m_btnSave
            // 
            this.m_btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
            this.m_btnSave.DefaultScheme = true;
            this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSave.Hint = "";
            this.m_btnSave.Location = new System.Drawing.Point(720, 552);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSave.Size = new System.Drawing.Size(80, 32);
            this.m_btnSave.TabIndex = 8;
            this.m_btnSave.Text = "保存(&S)";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnExit
            // 
            this.m_btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
            this.m_btnExit.DefaultScheme = true;
            this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.m_btnExit.Hint = "";
            this.m_btnExit.Location = new System.Drawing.Point(816, 552);
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExit.Size = new System.Drawing.Size(80, 32);
            this.m_btnExit.TabIndex = 10;
            this.m_btnExit.Text = "退出(Esc)";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // lsvConfig
            // 
            this.lsvConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lsvConfig.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2});
            this.lsvConfig.FullRowSelect = true;
            this.lsvConfig.GridLines = true;
            this.lsvConfig.Location = new System.Drawing.Point(0, 16);
            this.lsvConfig.Name = "lsvConfig";
            this.lsvConfig.Size = new System.Drawing.Size(184, 520);
            this.lsvConfig.TabIndex = 11;
            this.lsvConfig.View = System.Windows.Forms.View.Details;
            this.lsvConfig.SelectedIndexChanged += new System.EventHandler(this.lsvConfig_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "分类ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "分类模块名称";
            this.columnHeader2.Width = 120;
            // 
            // frmSystemSeting
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1016, 589);
            this.Controls.Add(this.lsvConfig);
            this.Controls.Add(this.m_btnExit);
            this.Controls.Add(this.m_btnSave);
            this.Controls.Add(this.m_dtgGroup);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.KeyPreview = true;
            this.Name = "frmSystemSeting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统功能配置";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSystemSeting_KeyDown);
            this.Load += new System.EventHandler(this.frmSystemSeting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgGroup)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsControlSystemSeting();
            objController.Set_GUI_Apperance(this);
        }


        public new void Show_MDI_Child(Form frmMDI_Parent)
        {
            this.ShowDialog();
        }

        private void frmSystemSeting_Load(object sender, System.EventArgs e)
        {
            ((clsControlSystemSeting)this.objController).m_GetLeftInfo();

            this.m_dtgGroup.m_mthAddEnterToSpaceColumn(3);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)m_dtgGroup.Columns[3]).DataGridTextBoxColumn.TextBox.MaxLength = 3;
            ((clsControlSystemSeting)this.objController).m_GetSettings();
            if(this.lsvConfig.Items.Count>0)
                this.lsvConfig.Items[0].Selected = true;
            ((clsControlSystemSeting)this.objController).m_ShowSelectInfo();


        }

        private void m_btnSave_Click(object sender, System.EventArgs e)
        {
            ((clsControlSystemSeting)this.objController).m_SaveSettings();
            ((clsControlSystemSeting)this.objController).UpdataCurrentCell();
        }

        private void m_btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void m_dtgGroup_m_evtCurrentCellChanged(object sender, System.EventArgs e)
        {
            this.m_dtgGroup.CurrentCell = new DataGridCell(this.m_dtgGroup.CurrentCell.RowNumber, 3);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)this.m_dtgGroup.Columns[3]).DataGridTextBoxColumn.TextBox.SelectAll();

            m_dtgGroup[this.m_dtgGroup.CurrentCell.RowNumber, 3] = m_mthConvertToDecimal(m_dtgGroup[this.m_dtgGroup.CurrentCell.RowNumber, 3]);
            m_showText();



        }

        private void m_showText()
        {
            for (int i = 0; i < this.m_dtgGroup.RowCount; i++)
            {
                m_dtgGroup[i, 3] = m_mthConvertToDecimal(m_dtgGroup[i, 3]);
            }
        }

        private decimal m_mthConvertToDecimal(object obj)
        {
            decimal ret = 0;
            try
            {
                //				if(obj.ToString().Length==1)
                //				{

                ret = decimal.Parse(obj.ToString());
                //				}
            }
            catch
            {
                ret = 0;
            }
            return ret;

        }

        private void m_dtgGroup_m_evtDataGridTextBoxKeyDown(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.m_intColNumber == 3)
            {
                SendKeys.SendWait("{Tab}");
            }
        }

        private void frmSystemSeting_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("确认退出吗?", "iCare", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                m_btnExit_Click(sender, e);
            }
        }

        private void lsvConfig_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ((clsControlSystemSeting)this.objController).m_ShowSelectInfo();
            //		   for(int i2=0;i2<this.lsvConfig.SelectedIndices.Count;++i2)
            //		   {
            //			   for(int i1=0;i1<m_dtgGroup.RowCount;++i1)
            //			   {
            //				   if( this.lsvConfig.SelectedItems[i2].SubItems[0].Text==this.m_dtgGroup[i1,0].ToString())
            //					    this.m_dtgGroup.m_mthSelectARow(i1);
            //					   
            //			   }		 
            //		   }
        }

    }
}
