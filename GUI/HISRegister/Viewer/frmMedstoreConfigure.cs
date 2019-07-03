using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
namespace  com.digitalwave.iCare.gui.HIS
{
	public class frmMedstoreConfigure : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.ImageList imageList1;
		internal System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private PinkieControls.ButtonXP btExit;
		internal PinkieControls.ButtonXP btSave;
		internal System.Windows.Forms.Label lbeName;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		internal System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.Label label3;
		internal System.Windows.Forms.Label lbeWindowName;
		private System.Windows.Forms.GroupBox groupBox4;
		internal System.Windows.Forms.ListView listView3;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.ComponentModel.IContainer components = null;

		public frmMedstoreConfigure()
		{
			// 该调用是 Windows 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitializeComponent 调用后添加任何初始化
		}

		/// <summary>
		/// 清理所有正在使用的资源。
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

		#region 设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedstoreConfigure));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbeWindowName = new System.Windows.Forms.Label();
            this.lbeName = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listView3 = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btExit = new PinkieControls.ButtonXP();
            this.btSave = new PinkieControls.ButtonXP();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(3, 19);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(359, 218);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btExit);
            this.groupBox1.Controls.Add(this.btSave);
            this.groupBox1.Location = new System.Drawing.Point(8, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 332);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.lbeWindowName);
            this.groupBox5.Controls.Add(this.lbeName);
            this.groupBox5.Location = new System.Drawing.Point(8, 264);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(244, 56);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "当前的发药窗口";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "药房:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "窗口:";
            // 
            // lbeWindowName
            // 
            this.lbeWindowName.AutoSize = true;
            this.lbeWindowName.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbeWindowName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbeWindowName.Location = new System.Drawing.Point(92, 64);
            this.lbeWindowName.Name = "lbeWindowName";
            this.lbeWindowName.Size = new System.Drawing.Size(0, 19);
            this.lbeWindowName.TabIndex = 11;
            // 
            // lbeName
            // 
            this.lbeName.AutoSize = true;
            this.lbeName.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbeName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbeName.Location = new System.Drawing.Point(92, 28);
            this.lbeName.Name = "lbeName";
            this.lbeName.Size = new System.Drawing.Size(0, 19);
            this.lbeName.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listView3);
            this.groupBox4.Location = new System.Drawing.Point(8, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(116, 240);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "药房类型";
            // 
            // listView3
            // 
            this.listView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView3.HideSelection = false;
            this.listView3.LargeImageList = this.imageList1;
            this.listView3.Location = new System.Drawing.Point(3, 19);
            this.listView3.MultiSelect = false;
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(110, 218);
            this.listView3.TabIndex = 0;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.SelectedIndexChanged += new System.EventHandler(this.listView3_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listView2);
            this.groupBox3.Location = new System.Drawing.Point(396, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(180, 240);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "窗口";
            // 
            // listView2
            // 
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.HideSelection = false;
            this.listView2.LargeImageList = this.imageList1;
            this.listView2.Location = new System.Drawing.Point(3, 19);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(174, 218);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Location = new System.Drawing.Point(128, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 240);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "药房";
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btExit.DefaultScheme = true;
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExit.Hint = "";
            this.btExit.Location = new System.Drawing.Point(344, 276);
            this.btExit.Name = "btExit";
            this.btExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btExit.Size = new System.Drawing.Size(78, 44);
            this.btExit.TabIndex = 6;
            this.btExit.Text = "退出(ESC)";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btSave
            // 
            this.btSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btSave.DefaultScheme = true;
            this.btSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btSave.Hint = "";
            this.btSave.Location = new System.Drawing.Point(258, 276);
            this.btSave.Name = "btSave";
            this.btSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btSave.Size = new System.Drawing.Size(80, 44);
            this.btSave.TabIndex = 5;
            this.btSave.Text = "保存(&S)";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // frmMedstoreConfigure
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.CancelButton = this.btExit;
            this.ClientSize = new System.Drawing.Size(502, 333);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmMedstoreConfigure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "发药药房配置";
            this.Load += new System.EventHandler(this.frmMedstoreConfigure_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		public override void CreateController()
		{

			this.objController=new com.digitalwave.iCare.gui.HIS.clsCtl_MedstoreConfigure();
			objController.Set_GUI_Apperance(this);
		}

		private void frmMedstoreConfigure_Load(object sender, System.EventArgs e)
		{
			((clsCtl_MedstoreConfigure)this.objController).m_mthMedstoreType();
//			((clsCtl_MedstoreConfigure)this.objController).m_mthMedstoreInfo();
			this.listView3.Items[0].Selected=true;
			
		}

		private void btSave_Click(object sender, System.EventArgs e)
		{
			((clsCtl_MedstoreConfigure)this.objController).m_mthSave();
		}

		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.listView1.SelectedItems.Count>0)
			{
			this.btSave.Tag=this.listView1.SelectedItems[0].Tag;
//			this.lbeName.Text=this.listView1.SelectedItems[0].Text;
			((clsCtl_MedstoreConfigure)this.objController).m_mthWindowInfoByID();
			}
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void listView2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.listView2.SelectedItems.Count>0)
			{
				this.lbeWindowName.Tag=this.listView2.SelectedItems[0].Tag;
//				this.lbeWindowName.Text=this.listView2.SelectedItems[0].Text;
			}
		}

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void listView3_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				((clsCtl_MedstoreConfigure)this.objController).m_mthMedstoreInfo((string)this.listView3.SelectedItems[0].Tag);
			}
			catch
			{
			}
		}

		private void groupBox5_Enter(object sender, System.EventArgs e)
		{
		
		}
	}
}

