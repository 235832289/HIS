using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;



namespace com.digitalwave.Emr.Signature_gui
{
	/// <summary>
	/// frmCommonUsePanel 的摘要说明。
	/// </summary>
	public class frmCommonUsePanel  : System.Windows.Forms.Form
	{
		#region Designer generated code
        private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ImageList imageList1;
		public System.Windows.Forms.CheckBox chkMul;
		public System.Windows.Forms.CheckBox chkNon;
        private StatusStrip statusStrip1;
        public ToolStripStatusLabel tlbAllhospital;
        public ListView m_lsvItemList;
		public  System.Windows.Forms.TextBox txtInput;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
			
		}
		
		
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCommonUsePanel));
            this.txtInput = new System.Windows.Forms.TextBox();
            this.chkMul = new System.Windows.Forms.CheckBox();
            this.chkNon = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlbAllhospital = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_lsvItemList = new System.Windows.Forms.ListView();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.SystemColors.Info;
            this.txtInput.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInput.Location = new System.Drawing.Point(30, 0);
            this.txtInput.MaxLength = 10;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(138, 23);
            this.txtInput.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtInput, "输入关键字搜索");
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // chkMul
            // 
            this.chkMul.Location = new System.Drawing.Point(168, 0);
            this.chkMul.Name = "chkMul";
            this.chkMul.Size = new System.Drawing.Size(72, 24);
            this.chkMul.TabIndex = 2;
            this.chkMul.Text = "多签名";
            this.toolTip1.SetToolTip(this.chkMul, "选中多签名可以不需要关闭签名框");
            // 
            // chkNon
            // 
            this.chkNon.Enabled = false;
            this.chkNon.Location = new System.Drawing.Point(242, 0);
            this.chkNon.Name = "chkNon";
            this.chkNon.Size = new System.Drawing.Size(72, 24);
            this.chkNon.TabIndex = 3;
            this.chkNon.Text = "非系统";
            this.toolTip1.SetToolTip(this.chkNon, "选中可以直接输入非系统签名者信息");
            // 
            // label1
            // 
            this.label1.ImageIndex = 1;
            this.label1.ImageList = this.imageList1;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 23);
            this.label1.TabIndex = 419;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlbAllhospital});
            this.statusStrip1.Location = new System.Drawing.Point(0, 223);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(314, 22);
            this.statusStrip1.TabIndex = 420;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlbAllhospital
            // 
            this.tlbAllhospital.IsLink = true;
            this.tlbAllhospital.Name = "tlbAllhospital";
            this.tlbAllhospital.Size = new System.Drawing.Size(31, 17);
            this.tlbAllhospital.Text = "全院";
            this.tlbAllhospital.ToolTipText = "单击获取全院医生和护士签名列表";
            this.tlbAllhospital.Click += new System.EventHandler(this.tlbAllhospital_Click);
            // 
            // m_lsvItemList
            // 
            this.m_lsvItemList.BackColor = System.Drawing.SystemColors.Info;
            this.m_lsvItemList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_lsvItemList.ForeColor = System.Drawing.Color.Black;
            this.m_lsvItemList.FullRowSelect = true;
            this.m_lsvItemList.GridLines = true;
            this.m_lsvItemList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvItemList.HideSelection = false;
            this.m_lsvItemList.Location = new System.Drawing.Point(0, 26);
            this.m_lsvItemList.MultiSelect = false;
            this.m_lsvItemList.Name = "m_lsvItemList";
            this.m_lsvItemList.Size = new System.Drawing.Size(314, 197);
            this.m_lsvItemList.TabIndex = 421;
            this.m_lsvItemList.UseCompatibleStateImageBehavior = false;
            this.m_lsvItemList.View = System.Windows.Forms.View.Details;
            this.m_lsvItemList.DoubleClick += new System.EventHandler(this.m_lsvItemList_DoubleClick);
            this.m_lsvItemList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvItemList_KeyDown);
            // 
            // frmCommonUsePanel
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(314, 245);
            this.Controls.Add(this.m_lsvItemList);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.chkMul);
            this.Controls.Add(this.chkNon);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCommonUsePanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "签名";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCommonUsePanel_KeyDown);
            this.Load += new System.EventHandler(this.frmCommonUsePanel_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region 构造函数
		public frmCommonUsePanel()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			//设置Controller
			objController = new clsCommonUsePanelController(this);

            //
           
			
		}
		#endregion

		#region 字段
		/// <summary>
		/// 窗体控制器
		/// </summary>
		private clsCommonUsePanelController objController=null;
		/// <summary>
		/// 常用值类型
		/// </summary>
		internal int m_intType=-3;
 		/// <summary>
		/// 要传入的控件
		/// </summary>
		public Control m_objSelectedControl;
		/// <summary>
		/// 是否需要进行身份验证
		/// 默认需要
		/// </summary>
		public bool m_blnIsverify=true;
		/// <summary>
		/// 科室ID字段
		/// </summary>
		private string m_strDeptID="";

		/// <summary>
		/// 科室ID属性
		/// </summary>
		public string m_StrDeptID
		{
			set 
			{
				m_strDeptID = value;
			}
            get
            {  return m_strDeptID; }
		}
        /// <summary>
        /// 员工ID
        /// </summary>
        private string m_strEmployeeID;
        public string m_StrEmployeeID
        {
            set { m_strEmployeeID = value; }
            get { return m_strEmployeeID; }
        }
        private bool m_blnIsMultiSignAndNoTag = false;
        /// <summary>
        /// 是否可以添加多个签名，并且只返回名称，不返回ID（ true=是 false=否）
        /// </summary>
        public bool m_BlnIsMultiSignAndNoTag
        {
            set { m_blnIsMultiSignAndNoTag = value; }
            get { return m_blnIsMultiSignAndNoTag; }
        }

        /// <summary>
        /// 是否根据职称排序
        /// </summary>
        public bool m_BlnIsSortingByLevel = true;
        /// <summary>
        /// 是否显示所有员工(不限定医生、护士)
        /// </summary>
        public bool m_BlnIsShowAllEmployee = false;

        private bool m_blnIsShowLevel = true;
        /// <summary>
        /// 是否显示职称
        /// </summary>
        public bool m_BlnIsShowLevel
        {
            get { return m_blnIsShowLevel; }
            set 
            {
                ((clsCommonUsePanelController)objController).m_blnIsCustomSetting = true;
                m_blnIsShowLevel = value; 
            }
        }
		#endregion
	 
		#region 事件
		/// <summary>
		/// 窗体启动事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmCommonUsePanel_Load(object sender, System.EventArgs e)
		{
			m_lsvItemList.Columns.Clear();
            //m_lsvItemList.Columns.Add("工号", 60, HorizontalAlignment.Left);
            m_lsvItemList.Columns.Add("姓名", 100, HorizontalAlignment.Left);
            m_lsvItemList.Columns.Add("职称", 120, HorizontalAlignment.Left);
            //m_lsvItemList.Columns.Add("助记码", 60, HorizontalAlignment.Left);
			m_lsvItemList.ResumeLayout(false);
			m_lsvItemList.Items.Clear();
			try
			{
				this.Cursor=Cursors.WaitCursor;                
				((clsCommonUsePanelController)objController).m_thLoad();
								
			}
			finally
			{
				this.Cursor=Cursors.Default;
			}
 
		}
		/// <summary>
		/// 选中双击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_lsvItemList_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				((clsCommonUsePanelController)objController).m_thSelectEmployee();
			}
			catch (Exception exp)
			{
				MessageBox.Show("验证失败，不能通过验证。\n"+exp.Message,"iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);

			}
		}
		/// <summary>
		/// 方向下事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_lsvItemList_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode.Equals(Keys.Enter))
				m_lsvItemList_DoubleClick(null,null);
			if (e.KeyCode.Equals(Keys.Up))
			{
				if (m_lsvItemList.Items.Count>0)
				{
					if (m_lsvItemList.Items[0].Selected)
						txtInput.Focus();				
				}
				else
				{
					txtInput.Focus();
				}
						
			}
		}

		
		
		/// <summary>
		/// esc关闭窗体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmCommonUsePanel_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyCode)
			{
				case Keys.Escape:
					//释放对象
					objController=null;
					this.Close();
					break;
			}
		}
		/// <summary>
		/// 输入框按键事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtInput_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode.Equals(Keys.Enter))
				m_lsvItemList_DoubleClick(null,null);
			if (e.KeyCode.Equals(Keys.Down))
			{
				if( m_lsvItemList.Items.Count>0)
				{
					m_lsvItemList.Focus();
					m_lsvItemList.Items[0].Selected=true;
					m_lsvItemList.Items[0].Focused=true;
				}
			}

		}
		/// <summary>
		/// 输入框内容改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtInput_TextChanged(object sender, System.EventArgs e)
		{
			((clsCommonUsePanelController)objController).m_thInputHChange();
		}
        /// <summary>
        /// 单击全院事件
        /// 获取全部的医生和护士
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlbAllhospital_Click(object sender, EventArgs e)
        {
            ((clsCommonUsePanelController)objController).m_thLoadbyAll();
        }
		#endregion

		#region 方法
		/// <summary>
		/// 设置CommonUserType
		/// </summary>
		/// <param name="p_intType">常用值类型</param>
		public void m_mthSetCommonUserType(int p_intType)
		{
			m_intType = p_intType;
		}
 
		/// <summary>
		/// 设置调用窗体、控件、验证
		/// </summary>
		/// <param name="p_objParentForm">父窗体</param>
		/// <param name="p_objSelectedControl">签名控件</param>
		/// <param name="blnVerify">是否需要验证</param>
		public void m_mthSetParentForm(Control p_objSelectedControl,bool blnVerify)
		{
			m_objSelectedControl = p_objSelectedControl;
			m_blnIsverify=blnVerify;

		}
		#endregion
 
      
 	}
}
