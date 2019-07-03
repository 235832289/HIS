using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using ControlLibrary;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 病人流动日报——界面表示层
	/// 作者： 徐斌辉
	/// 创建时间： 2004-09-23
	/// </summary>
	public class frmStatPatientFlowDaily : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
	{
		#region 控件-变量申明

        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private PinkieControls.ButtonXP cmdClose;
		private System.Windows.Forms.ColumnHeader ColumnName;
        private System.Windows.Forms.ColumnHeader ColumnNnm;
		internal System.Drawing.Printing.PrintDocument m_pdSickRoomLog;
		internal System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
		private PinkieControls.ButtonXP buttonXP1;
		private PinkieControls.ButtonXP m_cmdPrint;
		private System.Windows.Forms.GroupBox groupBox1;
        internal com.digitalwave.controls.Control.MyPrintPreViewControl printDialog;
        private Label label3;
		#endregion 
        internal ControlLibrary.txtListView m_txtAREAID_CHR;
        
        internal bool m_bolAllArea = true;
        internal NullableDateControls.MaskDateEdit m_dtpDateTime;
        internal NullableDateControls.MaskDateEdit m_dtToTime;

        private IContainer components;

		#region 构造函数
		public frmStatPatientFlowDaily()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			//
			//
//			((clsCtl_StatPatientFlowDaily)this.objController).LoadDeptID();
		}

        #region 接收函数接口
        /// <summary>
        /// 
        /// </summary>
        internal string str_parmval = "0";

        public void m_mthShow(string ParmVal)
        {
            str_parmval = ParmVal;
            
            this.Show();
        }
        #endregion

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStatPatientFlowDaily));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdClose = new PinkieControls.ButtonXP();
            this.m_pdSickRoomLog = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.m_cmdPrint = new PinkieControls.ButtonXP();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtAREAID_CHR = new ControlLibrary.txtListView(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.m_dtToTime = new NullableDateControls.MaskDateEdit();
            this.m_dtpDateTime = new NullableDateControls.MaskDateEdit();
            this.printDialog = new com.digitalwave.controls.Control.MyPrintPreViewControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(304, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "查询时间:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "病区名称:";
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdClose.DefaultScheme = true;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdClose.Hint = "";
            this.cmdClose.Location = new System.Drawing.Point(915, 16);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdClose.Size = new System.Drawing.Size(80, 31);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "关  闭(&C)";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // m_pdSickRoomLog
            // 
            this.m_pdSickRoomLog.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdSickRoomLog_PrintPage);
            this.m_pdSickRoomLog.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdSickRoomLog_BeginPrint);
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Document = this.m_pdSickRoomLog;
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(723, 16);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(80, 31);
            this.buttonXP1.TabIndex = 4;
            this.buttonXP1.Text = "统计(&F)";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdPrint.DefaultScheme = true;
            this.m_cmdPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdPrint.Hint = "";
            this.m_cmdPrint.Location = new System.Drawing.Point(819, 16);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdPrint.Size = new System.Drawing.Size(80, 31);
            this.m_cmdPrint.TabIndex = 5;
            this.m_cmdPrint.Text = "打印(&D)";
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtAREAID_CHR);
            this.groupBox1.Controls.Add(this.m_cmdPrint);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmdClose);
            this.groupBox1.Controls.Add(this.buttonXP1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1002, 56);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // m_txtAREAID_CHR
            // 
            this.m_txtAREAID_CHR.findDataMode = ControlLibrary.txtListView.findMode.fromDataSouse;
            this.m_txtAREAID_CHR.Location = new System.Drawing.Point(84, 20);
            this.m_txtAREAID_CHR.m_blnFocuseShow = true;
            this.m_txtAREAID_CHR.m_blnPagination = false;
            this.m_txtAREAID_CHR.m_dtbDataSourse = null;
            this.m_txtAREAID_CHR.m_intDelayTime = 100;
            this.m_txtAREAID_CHR.m_intPageRows = 10;
            this.m_txtAREAID_CHR.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.LeftBottom;
            this.m_txtAREAID_CHR.m_listViewSize = new System.Drawing.Point(260, 100);
            this.m_txtAREAID_CHR.m_strFieldsArr = new string[] {
        "code_vchr",
        "pycode_chr",
        "deptname_vchr"};
            this.m_txtAREAID_CHR.m_strSaveField = "deptid_chr";
            this.m_txtAREAID_CHR.m_strShowField = "deptname_vchr";
            this.m_txtAREAID_CHR.m_strSQL = null;
            this.m_txtAREAID_CHR.Name = "m_txtAREAID_CHR";
            this.m_txtAREAID_CHR.Size = new System.Drawing.Size(200, 23);
            this.m_txtAREAID_CHR.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(518, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "~";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Visible = false;
            // 
            // m_dtToTime
            // 
            this.m_dtToTime.Location = new System.Drawing.Point(540, 23);
            this.m_dtToTime.Mask = "yyyy年MM月dd日";
            this.m_dtToTime.Name = "m_dtToTime";
            this.m_dtToTime.Size = new System.Drawing.Size(139, 23);
            this.m_dtToTime.TabIndex = 3;
            this.m_dtToTime.Visible = false;
            // 
            // m_dtpDateTime
            // 
            this.m_dtpDateTime.Location = new System.Drawing.Point(376, 23);
            this.m_dtpDateTime.Mask = "yyyy年MM月dd日";
            this.m_dtpDateTime.Name = "m_dtpDateTime";
            this.m_dtpDateTime.Size = new System.Drawing.Size(139, 23);
            this.m_dtpDateTime.TabIndex = 2;
            // 
            // printDialog
            // 
            this.printDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printDialog.Document = this.m_pdSickRoomLog;
            this.printDialog.Location = new System.Drawing.Point(0, 56);
            this.printDialog.Name = "printDialog";
            this.printDialog.ReportName = "";
            this.printDialog.ShowPannel = false;
            this.printDialog.ShowPrintButton = true;
            this.printDialog.Size = new System.Drawing.Size(1002, 607);
            this.printDialog.TabIndex = 23;
            // 
            // frmStatPatientFlowDaily
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1002, 663);
            this.Controls.Add(this.m_dtToTime);
            this.Controls.Add(this.m_dtpDateTime);
            this.Controls.Add(this.printDialog);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Name = "frmStatPatientFlowDaily";
            this.Text = "病人流动日报";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStatPatientFlowDaily_KeyDown);
            this.Load += new System.EventHandler(this.frmStatPatientFlowDaily_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_StatPatientFlowDaily();
			objController.Set_GUI_Apperance(this);
		}

        /// <summary>
        /// 
        /// </summary>
        public void ShowByNur()
        {
            this.m_bolAllArea = false;
            this.Show();
        }
		
		#region 事件
		private void cmdStat_Click(object sender, System.EventArgs e)
		{
//			((clsCtl_StatPatientFlowDaily)this.objController).m_Stat();
		}
		#endregion

		private void m_txtDEPTID_CHR_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode ==Keys.Enter)
			{
				m_dtpDateTime.Focus();
			}
		}

		private void cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_dtpDateTime_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
//			if(e.KeyCode ==Keys.Enter)
//			{
////				cmdStat.Focus();
//			}
		}

		private void buttonXP1_Click(object sender, System.EventArgs e)
		{
            if (!clsPublic.m_blnCheckDateRange(str_parmval, this.m_dtpDateTime.Value.ToString("yyyy-MM-dd"), this.m_dtToTime.Value.ToString("yyyy-MM-dd")))
            {
                return;
            }
            
            ((clsCtl_StatPatientFlowDaily)this.objController).preview();
		}

		private void m_cmdPrint_Click(object sender, System.EventArgs e)
		{
			((clsCtl_StatPatientFlowDaily)this.objController).Print();
		}

		private void m_pdSickRoomLog_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			((clsCtl_StatPatientFlowDaily)this.objController).PrintPage(sender,e);
		}

		private void frmStatPatientFlowDaily_Load(object sender, System.EventArgs e)
		{
            m_dtpDateTime.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_dtToTime.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_mthSetEnter2Tab(new System.Windows.Forms.Control[] { m_txtAREAID_CHR});
            
            ((clsCtl_StatPatientFlowDaily)this.objController).LoadAreaID();
			((clsCtl_StatPatientFlowDaily)this.objController).m_mthSetPrintPecent();
		}

		private void m_pdSickRoomLog_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			((clsCtl_StatPatientFlowDaily)this.objController).m_mthGetPrintDate();
		}

        private void frmStatPatientFlowDaily_KeyDown(object sender, KeyEventArgs e)
        {
            m_mthSetKeyTab(e);
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (MessageBox.Show("确认退出么?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    break;
            }
        }
	}
}
