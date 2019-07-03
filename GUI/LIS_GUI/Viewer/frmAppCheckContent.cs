using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// 检验项目申请界面
	/// </summary>
	public class frmAppCheckContent : Form
	{
		
		#region FormControl

		internal PinkieControls.ButtonXP m_btnConfirm;
		internal PinkieControls.ButtonXP m_btnCancel;
		internal System.Windows.Forms.Panel panel1;
		internal System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolTip tipSummary;
        internal System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.CheckBox checkBox1;
        internal System.Windows.Forms.CheckBox checkBox2;
        internal System.Windows.Forms.CheckBox checkBox3;
        internal System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Panel m_palWork;
        private System.Windows.Forms.Panel m_palTrv;
        internal System.Windows.Forms.TreeView m_trvFrameGroup;
        internal System.Windows.Forms.TreeView m_trvDeptGroup;
        internal System.Windows.Forms.TreeView m_trvCustomGroup;
        private System.ComponentModel.IContainer components;

		#endregion

		#region 构造函数
		public frmAppCheckContent()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
            m_objController = new clsController_AppCheckContent(this);
            m_objController.m_mthInitialAppGroupList();

		}
		#endregion

		#region Override
		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
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
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("节点6");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("节点5", new System.Windows.Forms.TreeNode[] {
            treeNode25});
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("节点4", new System.Windows.Forms.TreeNode[] {
            treeNode26});
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("节点7");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("制式申请组合", new System.Windows.Forms.TreeNode[] {
            treeNode27,
            treeNode28});
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("节点1");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode30});
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("节点2");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("自定义申请组合", new System.Windows.Forms.TreeNode[] {
            treeNode31,
            treeNode32});
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("节点0");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("节点1");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("科室申请组合", new System.Windows.Forms.TreeNode[] {
            treeNode34,
            treeNode35});
            this.m_btnConfirm = new PinkieControls.ButtonXP();
            this.m_btnCancel = new PinkieControls.ButtonXP();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tipSummary = new System.Windows.Forms.ToolTip(this.components);
            this.m_palWork = new System.Windows.Forms.Panel();
            this.m_palTrv = new System.Windows.Forms.Panel();
            this.m_trvFrameGroup = new System.Windows.Forms.TreeView();
            this.m_trvCustomGroup = new System.Windows.Forms.TreeView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.m_trvDeptGroup = new System.Windows.Forms.TreeView();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.lblSummary = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.m_palWork.SuspendLayout();
            this.m_palTrv.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnConfirm
            // 
            this.m_btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnConfirm.DefaultScheme = true;
            this.m_btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnConfirm.Hint = "";
            this.m_btnConfirm.Location = new System.Drawing.Point(507, 10);
            this.m_btnConfirm.Name = "m_btnConfirm";
            this.m_btnConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnConfirm.Size = new System.Drawing.Size(104, 32);
            this.m_btnConfirm.TabIndex = 0;
            this.m_btnConfirm.Text = "确定";
            this.m_btnConfirm.Click += new System.EventHandler(this.m_btnConfirm_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnCancel.DefaultScheme = true;
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Hint = "";
            this.m_btnCancel.Location = new System.Drawing.Point(627, 10);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnCancel.Size = new System.Drawing.Size(96, 32);
            this.m_btnCancel.TabIndex = 1;
            this.m_btnCancel.Text = "取消";
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnCancel);
            this.panel1.Controls.Add(this.m_btnConfirm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 535);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 56);
            this.panel1.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 535);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // tipSummary
            // 
            this.tipSummary.AutomaticDelay = 50;
            // 
            // m_palWork
            // 
            this.m_palWork.Controls.Add(this.m_palTrv);
            this.m_palWork.Controls.Add(this.splitter2);
            this.m_palWork.Controls.Add(this.panel4);
            this.m_palWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_palWork.Location = new System.Drawing.Point(0, 0);
            this.m_palWork.Name = "m_palWork";
            this.m_palWork.Size = new System.Drawing.Size(744, 535);
            this.m_palWork.TabIndex = 0;
            // 
            // m_palTrv
            // 
            this.m_palTrv.Controls.Add(this.m_trvFrameGroup);
            this.m_palTrv.Controls.Add(this.m_trvCustomGroup);
            this.m_palTrv.Controls.Add(this.checkBox1);
            this.m_palTrv.Controls.Add(this.panel2);
            this.m_palTrv.Controls.Add(this.checkBox2);
            this.m_palTrv.Controls.Add(this.checkBox3);
            this.m_palTrv.Controls.Add(this.m_trvDeptGroup);
            this.m_palTrv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_palTrv.Location = new System.Drawing.Point(0, 0);
            this.m_palTrv.Name = "m_palTrv";
            this.m_palTrv.Size = new System.Drawing.Size(442, 535);
            this.m_palTrv.TabIndex = 0;
            // 
            // m_trvFrameGroup
            // 
            this.m_trvFrameGroup.CheckBoxes = true;
            this.m_trvFrameGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_trvFrameGroup.Location = new System.Drawing.Point(0, 24);
            this.m_trvFrameGroup.Name = "m_trvFrameGroup";
            treeNode25.Name = "";
            treeNode25.Text = "节点6";
            treeNode26.Name = "";
            treeNode26.Text = "节点5";
            treeNode27.Name = "";
            treeNode27.Text = "节点4";
            treeNode28.Name = "";
            treeNode28.Text = "节点7";
            treeNode29.Name = "";
            treeNode29.Text = "制式申请组合";
            this.m_trvFrameGroup.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode29});
            this.m_trvFrameGroup.Size = new System.Drawing.Size(442, 511);
            this.m_trvFrameGroup.TabIndex = 0;
            this.m_trvFrameGroup.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.m_trvAppGroup_AfterCheck);
            this.m_trvFrameGroup.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.m_trvFrameGroup.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.m_trvFrameGroup_AfterExpand);
            // 
            // m_trvCustomGroup
            // 
            this.m_trvCustomGroup.CheckBoxes = true;
            this.m_trvCustomGroup.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_trvCustomGroup.ItemHeight = 16;
            this.m_trvCustomGroup.Location = new System.Drawing.Point(108, 176);
            this.m_trvCustomGroup.Name = "m_trvCustomGroup";
            treeNode30.Name = "";
            treeNode30.Text = "节点1";
            treeNode31.Name = "";
            treeNode31.Text = "节点0";
            treeNode32.Name = "";
            treeNode32.Text = "节点2";
            treeNode33.Name = "";
            treeNode33.Text = "自定义申请组合";
            this.m_trvCustomGroup.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode33});
            this.m_trvCustomGroup.Size = new System.Drawing.Size(136, 136);
            this.m_trvCustomGroup.TabIndex = 0;
            this.m_trvCustomGroup.TabStop = false;
            this.m_trvCustomGroup.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(12, 68);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 24);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "科室申请组合";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(442, 24);
            this.panel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "申请项目";
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(8, 40);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(120, 24);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.TabStop = false;
            this.checkBox2.Text = "制式申请组合";
            this.checkBox2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox2.Visible = false;
            // 
            // checkBox3
            // 
            this.checkBox3.Location = new System.Drawing.Point(8, 96);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(128, 24);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.TabStop = false;
            this.checkBox3.Text = "自定义申请组合";
            this.checkBox3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox3.Visible = false;
            // 
            // m_trvDeptGroup
            // 
            this.m_trvDeptGroup.CheckBoxes = true;
            this.m_trvDeptGroup.Location = new System.Drawing.Point(144, 44);
            this.m_trvDeptGroup.Name = "m_trvDeptGroup";
            treeNode34.Name = "";
            treeNode34.Text = "节点0";
            treeNode35.Name = "";
            treeNode35.Text = "节点1";
            treeNode36.Name = "";
            treeNode36.Text = "科室申请组合";
            this.m_trvDeptGroup.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode36});
            this.m_trvDeptGroup.Size = new System.Drawing.Size(32, 44);
            this.m_trvDeptGroup.TabIndex = 5;
            this.m_trvDeptGroup.TabStop = false;
            this.m_trvDeptGroup.Visible = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(442, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(6, 535);
            this.splitter2.TabIndex = 12;
            this.splitter2.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtSummary);
            this.panel4.Controls.Add(this.lblSummary);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(448, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(296, 535);
            this.panel4.TabIndex = 0;
            // 
            // txtSummary
            // 
            this.txtSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSummary.BackColor = System.Drawing.SystemColors.Info;
            this.txtSummary.Location = new System.Drawing.Point(0, 24);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.ReadOnly = true;
            this.txtSummary.Size = new System.Drawing.Size(292, 511);
            this.txtSummary.TabIndex = 3;
            this.txtSummary.TabStop = false;
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(4, 4);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(35, 14);
            this.lblSummary.TabIndex = 2;
            this.lblSummary.Text = "备注";
            // 
            // frmAppCheckContent
            // 
            this.AcceptButton = this.m_btnConfirm;
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.CancelButton = this.m_btnCancel;
            this.ClientSize = new System.Drawing.Size(744, 591);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.m_palWork);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAppCheckContent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检验项目申请";
            this.Load += new System.EventHandler(this.frmAppCheckContent_Load);
            this.panel1.ResumeLayout(false);
            this.m_palWork.ResumeLayout(false);
            this.m_palTrv.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        #region 成员申明

        public clsController_AppCheckContent m_objController;
        private System.Collections.Generic.List<TreeNode> checkedNodes = new System.Collections.Generic.List<TreeNode>(); 
        
        #endregion

        #region 事件实现
		
		private void frmAppCheckContent_Load(object sender, System.EventArgs e)
		{
			this.m_trvFrameGroup.Focus();
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			TreeNode tn = e.Node;

			string strSummary = string.Empty;

			if(tn != null)
			{
				m_objController = new clsController_AppCheckContent(this);
				strSummary = m_objController.m_mthReturnNodeSummary(tn);
				this.txtSummary.Text = strSummary;
			}
		}

		private void m_btnCancel_Click(object sender, System.EventArgs e)
		{
			
		}

		private void m_btnConfirm_Click(object sender, System.EventArgs e)
		{
			this.m_objController.m_mthGenerateAppContent();
		}

		private void m_trvAppGroup_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
            if (e.Node.Checked)
            {
                checkedNodes.Add(e.Node);
                if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "")
                {
                    e.Node.Nodes.Clear();
                    m_objController.m_mthGetChildUserGroupAndApplUnit(e.Node);
                }
                foreach (TreeNode trn in e.Node.Nodes)
                {
                    m_mthRecursivedSetChildNodeChecked(trn, false);

                }
                m_mthRecursivedSetParentNodeChecked(e.Node.Parent, false);
            }
            else
            {
                checkedNodes.Remove(e.Node);
            }
		}
		
        private void m_mthRecursivedSetChildNodeChecked(TreeNode p_trnChildNode,bool p_blnChecked)
		{
			if(p_trnChildNode == null)
			{
				return;
			}
			p_trnChildNode.Checked = p_blnChecked;
			foreach(TreeNode trn in p_trnChildNode.Nodes)
			{
				m_mthRecursivedSetChildNodeChecked(trn,p_blnChecked);

			}
		}
		
        private void m_mthRecursivedSetParentNodeChecked(TreeNode p_trnParentNode,bool p_blnChecked)
		{
			if(p_trnParentNode == null) return;

			p_trnParentNode.Checked = p_blnChecked;
			
			m_mthRecursivedSetParentNodeChecked(p_trnParentNode.Parent,p_blnChecked);

		}

		private void m_trvFrameGroup_AfterExpand(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "")
			{
				m_objController.m_mthGetNextLevelUserGorupAndApplUnit(e.Node);
			}
		}

        public void m_mthClearChecked()
        {

            TreeNode[] nodes = checkedNodes.ToArray();
            if (nodes != null )
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    nodes[i].Checked = false;
                    nodes[i].Collapse(false);
                }
            }
        }

	    #endregion	

    }
}
