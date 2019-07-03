using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using Static = com.digitalwave.Emr.StaticObject;

namespace iCare.PrintTool
{
	/// <summary>
	/// Summary description for frmPrintPreviewDialog.
	/// </summary>
	public class frmPrintPreviewDialog : System.Windows.Forms.PrintPreviewDialog
	{
		private System.Windows.Forms.Button m_cmdPrintCurrent;
		private System.Windows.Forms.Button m_cmdPrintSetup;
        private Label m_lblCoverPrinter;
        private PrintDialog pdSet = null;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPrintPreviewDialog()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            this.PrintPreviewControl.Zoom = 1;
			Type ppdType = typeof(System.Windows.Forms.PrintPreviewDialog);
			PropertyInfo objWSPI = ppdType.GetProperty("WindowState", BindingFlags.Public|BindingFlags.Instance);
			objWSPI.SetValue(this,FormWindowState.Maximized,null);

            pdSet = new PrintDialog();
		}

		/// <summary>
		/// Clean up any resources being used.
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_cmdPrintCurrent = new System.Windows.Forms.Button();
            this.m_cmdPrintSetup = new System.Windows.Forms.Button();
            this.m_lblCoverPrinter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_cmdPrintCurrent
            // 
            this.m_cmdPrintCurrent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdPrintCurrent.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmdPrintCurrent.Location = new System.Drawing.Point(306, 2);
            this.m_cmdPrintCurrent.Name = "m_cmdPrintCurrent";
            this.m_cmdPrintCurrent.Size = new System.Drawing.Size(89, 22);
            this.m_cmdPrintCurrent.TabIndex = 4;
            this.m_cmdPrintCurrent.Text = "打印当前页";
            this.m_cmdPrintCurrent.Click += new System.EventHandler(this.m_cmdPrintCurrent_Click);
            // 
            // m_cmdPrintSetup
            // 
            this.m_cmdPrintSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdPrintSetup.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmdPrintSetup.Location = new System.Drawing.Point(408, 2);
            this.m_cmdPrintSetup.Name = "m_cmdPrintSetup";
            this.m_cmdPrintSetup.Size = new System.Drawing.Size(89, 22);
            this.m_cmdPrintSetup.TabIndex = 4;
            this.m_cmdPrintSetup.Text = "打印设置";
            this.m_cmdPrintSetup.Click += new System.EventHandler(this.m_cmdPrintSetup_Click);
            // 
            // m_lblCoverPrinter
            // 
            this.m_lblCoverPrinter.Location = new System.Drawing.Point(-1, -1);
            this.m_lblCoverPrinter.Name = "m_lblCoverPrinter";
            this.m_lblCoverPrinter.Size = new System.Drawing.Size(21, 23);
            this.m_lblCoverPrinter.TabIndex = 5;
            this.m_lblCoverPrinter.Visible = false;
            // 
            // frmPrintPreviewDialog
            // 
            this.ClientSize = new System.Drawing.Size(940, 677);
            this.Controls.Add(this.m_lblCoverPrinter);
            this.Controls.Add(this.m_cmdPrintSetup);
            this.Controls.Add(this.m_cmdPrintCurrent);
            this.Name = "frmPrintPreviewDialog";
            this.Text = "frmPrintPreviewDialog";
            this.Load += new System.EventHandler(this.frmPrintPreviewDialog_Load);
            this.Controls.SetChildIndex(this.m_cmdPrintCurrent, 0);
            this.Controls.SetChildIndex(this.m_cmdPrintSetup, 0);
            this.Controls.SetChildIndex(this.m_lblCoverPrinter, 0);
            this.ResumeLayout(false);

		}
		#endregion

        public void m_mthCoverPrinter()
        {
            m_blnIsCase = false;
            m_cmdPrintCurrent.Enabled = false;
        }

        private bool m_blnIsCase = false;
		private void frmPrintPreviewDialog_Load(object sender, System.EventArgs e)
		{
			m_cmdPrintCurrent.BringToFront();

            if (MDIParent.s_ObjCurrentPatient != null && MDIParent.s_ObjCurrentPatient.m_IntCharacter == 1)
            {
                if (Static::clsEMR_StaticObject.s_ObjCurrentEmployee.m_strRoleNameArr != null)
                {
                    int intRolesCount = Static::clsEMR_StaticObject.s_ObjCurrentEmployee.m_strRoleNameArr.Length;
                    for (int i = 0; i < intRolesCount; i++)
                    {
                        if (Static::clsEMR_StaticObject.s_ObjCurrentEmployee.m_strRoleNameArr[i] == "病案室")
                        {
                            m_blnIsCase = true;
                            break;
                        }
                    }
                }
                if (!m_blnIsCase)
                {
                    this.m_lblCoverPrinter.Visible = true;
                    return;
                }
            }

            m_blnCheckPrinter();
		}
        /// <summary>
        /// 打印当前页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void m_cmdPrintCurrent_Click(object sender, System.EventArgs e)
		{
            if (MDIParent.s_ObjCurrentPatient != null && MDIParent.s_ObjCurrentPatient.m_IntCharacter == 1 && !m_blnIsCase)
            {
                clsPublicFunction.ShowInformationMessageBox("此病人病历为只读，不能打印！");
                return;
            }

			if(Document == null)
				return;

			Type ppdType = typeof(System.Windows.Forms.PrintPreviewDialog);
			FieldInfo objCounterFI = ppdType.GetField("pageCounter",BindingFlags.NonPublic| BindingFlags.Instance);

			NumericUpDown nudCurrent = objCounterFI.GetValue(this) as NumericUpDown;

			if(nudCurrent != null)
			{
				m_intCurrentPage = Decimal.ToInt32(nudCurrent.Value);
				m_blnIsCurrentPage = true;

				Document.Print();
			}
		}

		private bool m_blnIsCurrentPage = false;
		private int m_intCurrentPage = -1;
		private int m_intCurrentPrintedPage = 1;

		/// <summary>
		/// 处理打印。如果返回true，继续打印；如果返回false，继续调用打印函数。
		/// </summary>
		/// <param name="p_objArg"></param>
		/// <returns></returns>
		public bool m_blnHandlePrint(System.Drawing.Printing.PrintPageEventArgs p_objArg)
		{
			if(m_blnIsCurrentPage)
			{
				if(m_intCurrentPrintedPage < m_intCurrentPage)
				{
					p_objArg.Graphics.Clear(Color.White);
					m_intCurrentPrintedPage++;
					return false;
				}
				else
				{
					p_objArg.HasMorePages = false;
					m_blnIsCurrentPage = false;
					m_intCurrentPrintedPage = 1;
				}
			}		
	
			m_blnIsCurrentPage = false;
			m_intCurrentPrintedPage = 1;
			return true;
		}

		private void m_cmdPrintSetup_Click(object sender, System.EventArgs e)
		{
            if (pdSet == null)   
            {
                pdSet = new PrintDialog();
            }
			
			pdSet.Document=this.Document;
			pdSet.ShowDialog();

            m_blnCheckPrinter();
        }   

        private void m_blnCheckPrinter()
        {
            this.m_lblCoverPrinter.Visible = false;

            if (string.IsNullOrEmpty(pdSet.PrinterSettings.PrinterName))
            {
                this.m_lblCoverPrinter.Visible = true;
            }

           // m_cmdPrintSetup_Click(sender,e);
        }
	}
}
