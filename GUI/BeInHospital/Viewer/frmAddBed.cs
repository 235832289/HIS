using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 床位管理［加床］界面表示层
	/// 作者： 徐斌辉
	/// 创建时间： 2004-09-13
	/// </summary>
	public class frmAddBed : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        #region 控件声明
        /// <summary>
        /// 病区号
        /// </summary>
        internal string m_strAreaID;
        /// <summary>
        /// 床位ID
        /// </summary>
        private string m_strBedID = "";
        private IContainer components;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.ComboBox m_cboSTATUS_INT;
        internal System.Windows.Forms.ComboBox m_cboSEX_INT;
        internal System.Windows.Forms.ComboBox m_cboCATEGORY_INT;
        internal System.Windows.Forms.TextBox m_txtCODE_CHR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private PinkieControls.ButtonXP cmdOK;
        private PinkieControls.ButtonXP cmdCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        internal txtListView m_txtBedMoney;
        internal txtListView m_txtAirCondistionMoney;
        private TabControl tabControl1;
        private TabPage tabPage1;
        internal TextBox m_txtAreaName;
        internal TextBox m_txtDepName;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_strAreaID">病区号</param>
        public frmAddBed(string p_strAreaID)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //

            m_strAreaID = p_strAreaID;
            //
        }

        public frmAddBed(string p_strBedID, string p_null)
        {
            InitializeComponent();
            m_strBedID = p_strBedID;
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
        #endregion

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtAreaName = new System.Windows.Forms.TextBox();
            this.m_txtDepName = new System.Windows.Forms.TextBox();
            this.m_txtAirCondistionMoney = new com.digitalwave.iCare.gui.HIS.txtListView(this.components);
            this.m_txtBedMoney = new com.digitalwave.iCare.gui.HIS.txtListView(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cboSEX_INT = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_cboCATEGORY_INT = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.m_cboSTATUS_INT = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtCODE_CHR = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdCancel = new PinkieControls.ButtonXP();
            this.cmdOK = new PinkieControls.ButtonXP();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtAreaName);
            this.groupBox1.Controls.Add(this.m_txtDepName);
            this.groupBox1.Controls.Add(this.m_txtAirCondistionMoney);
            this.groupBox1.Controls.Add(this.m_txtBedMoney);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.m_cboSEX_INT);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.m_cboCATEGORY_INT);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.m_cboSTATUS_INT);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_txtCODE_CHR);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(609, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // m_txtAreaName
            // 
            this.m_txtAreaName.Location = new System.Drawing.Point(387, 31);
            this.m_txtAreaName.Name = "m_txtAreaName";
            this.m_txtAreaName.ReadOnly = true;
            this.m_txtAreaName.Size = new System.Drawing.Size(164, 23);
            this.m_txtAreaName.TabIndex = 1;
            this.m_txtAreaName.TabStop = false;
            // 
            // m_txtDepName
            // 
            this.m_txtDepName.Location = new System.Drawing.Point(104, 31);
            this.m_txtDepName.Name = "m_txtDepName";
            this.m_txtDepName.ReadOnly = true;
            this.m_txtDepName.Size = new System.Drawing.Size(164, 23);
            this.m_txtDepName.TabIndex = 0;
            this.m_txtDepName.TabStop = false;
            // 
            // m_txtAirCondistionMoney
            // 
            this.m_txtAirCondistionMoney.findDataMode = com.digitalwave.iCare.gui.HIS.txtListView.findMode.fromDataSouse;
            this.m_txtAirCondistionMoney.Location = new System.Drawing.Point(104, 181);
            this.m_txtAirCondistionMoney.m_blnDefSelect = true;
            this.m_txtAirCondistionMoney.m_blnEmpty = false;
            this.m_txtAirCondistionMoney.m_blnEnterShowList = true;
            this.m_txtAirCondistionMoney.m_blnFirstFind = true;
            this.m_txtAirCondistionMoney.m_blnFocuseShow = true;
            this.m_txtAirCondistionMoney.m_blnPagination = false;
            this.m_txtAirCondistionMoney.m_blnSelectItem = true;
            this.m_txtAirCondistionMoney.m_dtbDataSourse = null;
            this.m_txtAirCondistionMoney.m_intNowPage = 0;
            this.m_txtAirCondistionMoney.m_intPageRows = 10;
            this.m_txtAirCondistionMoney.m_intTotalPage = 1;
            this.m_txtAirCondistionMoney.m_ListViewAlign = com.digitalwave.iCare.gui.HIS.txtListView.ListViewAlign.LeftTop;
            this.m_txtAirCondistionMoney.m_listViewLocation = new System.Drawing.Point(0, 0);
            this.m_txtAirCondistionMoney.m_listViewSize = new System.Drawing.Point(500, 80);
            this.m_txtAirCondistionMoney.m_objListViewColumnsArr = null;
            this.m_txtAirCondistionMoney.m_strSaveField = "itemid_chr";
            this.m_txtAirCondistionMoney.m_strShowField = "charename";
            this.m_txtAirCondistionMoney.m_strSQL = "";
            this.m_txtAirCondistionMoney.m_strSQLPage = null;
            this.m_txtAirCondistionMoney.Name = "m_txtAirCondistionMoney";
            this.m_txtAirCondistionMoney.Size = new System.Drawing.Size(447, 23);
            this.m_txtAirCondistionMoney.TabIndex = 7;
            // 
            // m_txtBedMoney
            // 
            this.m_txtBedMoney.findDataMode = com.digitalwave.iCare.gui.HIS.txtListView.findMode.fromDataSouse;
            this.m_txtBedMoney.Location = new System.Drawing.Point(104, 143);
            this.m_txtBedMoney.m_blnDefSelect = true;
            this.m_txtBedMoney.m_blnEmpty = false;
            this.m_txtBedMoney.m_blnEnterShowList = true;
            this.m_txtBedMoney.m_blnFirstFind = true;
            this.m_txtBedMoney.m_blnFocuseShow = true;
            this.m_txtBedMoney.m_blnPagination = false;
            this.m_txtBedMoney.m_blnSelectItem = true;
            this.m_txtBedMoney.m_dtbDataSourse = null;
            this.m_txtBedMoney.m_intNowPage = 0;
            this.m_txtBedMoney.m_intPageRows = 10;
            this.m_txtBedMoney.m_intTotalPage = 1;
            this.m_txtBedMoney.m_ListViewAlign = com.digitalwave.iCare.gui.HIS.txtListView.ListViewAlign.LeftTop;
            this.m_txtBedMoney.m_listViewLocation = new System.Drawing.Point(0, 0);
            this.m_txtBedMoney.m_listViewSize = new System.Drawing.Point(500, 120);
            this.m_txtBedMoney.m_objListViewColumnsArr = null;
            this.m_txtBedMoney.m_strSaveField = "itemid_chr";
            this.m_txtBedMoney.m_strShowField = "charename";
            this.m_txtBedMoney.m_strSQL = "";
            this.m_txtBedMoney.m_strSQLPage = null;
            this.m_txtBedMoney.Name = "m_txtBedMoney";
            this.m_txtBedMoney.Size = new System.Drawing.Size(447, 23);
            this.m_txtBedMoney.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(30, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 10;
            this.label7.Text = "空 调 费：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(30, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "科室名称：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_cboSEX_INT
            // 
            this.m_cboSEX_INT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSEX_INT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboSEX_INT.Items.AddRange(new object[] {
            "男",
            "女",
            "不限"});
            this.m_cboSEX_INT.Location = new System.Drawing.Point(104, 105);
            this.m_cboSEX_INT.Name = "m_cboSEX_INT";
            this.m_cboSEX_INT.Size = new System.Drawing.Size(164, 22);
            this.m_cboSEX_INT.TabIndex = 4;
            this.m_cboSEX_INT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboSEX_INT_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(30, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 13;
            this.label8.Text = "床位类别：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_cboCATEGORY_INT
            // 
            this.m_cboCATEGORY_INT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCATEGORY_INT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCATEGORY_INT.Items.AddRange(new object[] {
            "",
            "开放",
            "加床",
            "虚床"});
            this.m_cboCATEGORY_INT.Location = new System.Drawing.Point(387, 105);
            this.m_cboCATEGORY_INT.Name = "m_cboCATEGORY_INT";
            this.m_cboCATEGORY_INT.Size = new System.Drawing.Size(164, 22);
            this.m_cboCATEGORY_INT.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(313, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 15;
            this.label9.Text = "类　　别：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_cboSTATUS_INT
            // 
            this.m_cboSTATUS_INT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSTATUS_INT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboSTATUS_INT.Items.AddRange(new object[] {
            "",
            "空床",
            "占床",
            "预约占床",
            "包床"});
            this.m_cboSTATUS_INT.Location = new System.Drawing.Point(387, 67);
            this.m_cboSTATUS_INT.Name = "m_cboSTATUS_INT";
            this.m_cboSTATUS_INT.Size = new System.Drawing.Size(164, 22);
            this.m_cboSTATUS_INT.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(313, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "病区名称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(313, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "当前状态：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(30, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 17;
            this.label2.Text = "床 位 费：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtCODE_CHR
            // 
            this.m_txtCODE_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCODE_CHR.Location = new System.Drawing.Point(104, 67);
            this.m_txtCODE_CHR.MaxLength = 10;
            this.m_txtCODE_CHR.Name = "m_txtCODE_CHR";
            this.m_txtCODE_CHR.Size = new System.Drawing.Size(164, 23);
            this.m_txtCODE_CHR.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(30, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "病床编号：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdCancel.DefaultScheme = true;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdCancel.Hint = "";
            this.cmdCancel.Location = new System.Drawing.Point(543, 281);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdCancel.Size = new System.Drawing.Size(80, 27);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "关闭(Esc)";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdOK.DefaultScheme = true;
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdOK.Hint = "";
            this.cmdOK.Location = new System.Drawing.Point(452, 281);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdOK.Size = new System.Drawing.Size(80, 27);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "确定(F2)";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(7, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(623, 273);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(615, 246);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "床位信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // frmAddBed
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(640, 314);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(200, 187);
            this.MaximizeBox = false;
            this.Name = "frmAddBed";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "添加病床";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAddBed_KeyDown);
            this.Load += new System.EventHandler(this.frmAddBed_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region 设置窗体控制器
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_AddBed();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 初始化数据
        private void frmAddBed_Load(object sender, System.EventArgs e)
        {
            m_mthSetEnter2Tab(new System.Windows.Forms.Control[] { m_txtBedMoney, m_txtAirCondistionMoney, m_cboSTATUS_INT });
            if (m_strBedID != "")
            {
                ((clsCtl_AddBed)this.objController).m_mthSetBedInfo(m_strBedID);
            }
            else
            {
                m_cboSTATUS_INT.SelectedIndex = 1;
                m_cboSEX_INT.SelectedIndex = 2;
                m_cboCATEGORY_INT.SelectedIndex = 1;
            }
            m_cboSTATUS_INT.Enabled = false;
            ((clsCtl_AddBed)objController).m_mthInitData();

        }
        #endregion

        #region 保存床位信息
        private void cmdOK_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_AddBed)this.objController).m_AddBed();
        }
        #endregion

        #region 事件
        private void cmdCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frmAddBed_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            m_mthSetKeyTab(e);
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (MessageBox.Show("是否确定退出", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    break;
                case Keys.F2:
                    cmdOK_Click(sender, e);
                    break;
            }
        }

        private void m_cboSEX_INT_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.m_cboCATEGORY_INT.Focus();
            }
        }
        #endregion
    }
}
