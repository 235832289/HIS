using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
    public delegate void OnConfirmHanlder(DataTable p_dtbResult);
	/// <summary>
	/// frmSingleItemDiscount 的摘要说明。
	/// </summary>
	public class frmSingleItemDiscount : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal System.Windows.Forms.DataGrid dataGrid1;
		internal PinkieControls.ButtonXP btOK;
		internal PinkieControls.ButtonXP btExit;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
        /// <summary>
        /// 是否新建药品时使用
        /// </summary>
        public bool m_blnUseByAddingNewMedicine = false;
        public DataTable m_dtbChargeItem = null;
        public event OnConfirmHanlder OnConfirm_Handler;

		public frmSingleItemDiscount()
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.btOK = new PinkieControls.ButtonXP();
			this.btExit = new PinkieControls.ButtonXP();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(4, 0);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(288, 424);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Table1";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "病人类型";
			this.dataGridTextBoxColumn1.MappingName = "CatName";
			this.dataGridTextBoxColumn1.ReadOnly = true;
			this.dataGridTextBoxColumn1.Width = 150;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "收费比例";
			this.dataGridTextBoxColumn2.MappingName = "decDiscount";
			this.dataGridTextBoxColumn2.Width = 75;
			// 
			// btOK
			// 
			this.btOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btOK.DefaultScheme = true;
			this.btOK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btOK.Font = new System.Drawing.Font("宋体", 10.5F);
			this.btOK.Hint = "";
			this.btOK.Location = new System.Drawing.Point(36, 448);
			this.btOK.Name = "btOK";
			this.btOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btOK.Size = new System.Drawing.Size(80, 32);
			this.btOK.TabIndex = 82;
			this.btOK.Text = "保存(&S)";
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// btExit
			// 
			this.btExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btExit.DefaultScheme = true;
			this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btExit.Font = new System.Drawing.Font("宋体", 10.5F);
			this.btExit.Hint = "";
			this.btExit.Location = new System.Drawing.Point(160, 448);
			this.btExit.Name = "btExit";
			this.btExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btExit.Size = new System.Drawing.Size(80, 32);
			this.btExit.TabIndex = 83;
			this.btExit.Text = "退出(ESC)";
			this.btExit.Click += new System.EventHandler(this.btExit_Click);
			// 
			// frmSingleItemDiscount
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.CancelButton = this.btExit;
			this.ClientSize = new System.Drawing.Size(296, 497);
			this.Controls.Add(this.btExit);
			this.Controls.Add(this.btOK);
			this.Controls.Add(this.dataGrid1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmSingleItemDiscount";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "项目比例设置";
			this.Load += new System.EventHandler(this.frmSingleItemDiscount_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsCtl_SingleItemDiscount();
			objController.Set_GUI_Apperance(this);
		}
		private void frmSingleItemDiscount_Load(object sender, System.EventArgs e)
		{
            if (m_blnUseByAddingNewMedicine)
            {
                if (m_dtbChargeItem == null || m_dtbChargeItem.Rows.Count == 0)
                    strItemID = "";
                dataGrid1.DataSource = m_dtbChargeItem;
                btOK.Text = "确定&O";
            }
		}

		private void btOK_Click(object sender, System.EventArgs e)
		{
            if (!m_blnUseByAddingNewMedicine)
            {
                ((clsCtl_SingleItemDiscount)this.objController).m_mthSave();
            }
            else
            {
                if (OnConfirm_Handler != null)
                {
                    m_dtbChargeItem.AcceptChanges();
                    OnConfirm_Handler(m_dtbChargeItem);
                }
                this.Close();
            }
		}

		private void btExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
        private bool _isendle;
        public bool isEndle
        {
            set
            {
                _isendle = value;
                if (!value)
                {
                    dataGrid1.Enabled = false;
                }
            }
        }
		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			int row =this.dataGrid1.CurrentRowIndex;
			if(dataGrid1[row,0].ToString().Trim()=="")
			{
			this.dataGrid1.CurrentCell =new DataGridCell(row-1,1);
			}
			if(this.dataGrid1.CurrentCell.ColumnNumber==0)
			{
				this.dataGrid1.CurrentCell =new DataGridCell(row,1);
			}
		}
		/// <summary>
		/// 传入项目ID
		/// </summary>
		public string strItemID
		{
			set
			{
			((clsCtl_SingleItemDiscount)this.objController).m_mthFindData(value);
			}
		}
	}
}
