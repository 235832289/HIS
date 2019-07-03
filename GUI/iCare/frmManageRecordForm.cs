using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using com.digitalwave.Utility.Controls;
using System.Windows.Forms;
using System.Text;
using iCareData;
namespace iCare
{
	public class frmManageRecordForm : iCare.frmPrimaryForm
	{
		private System.ComponentModel.IContainer components = null;

		public frmManageRecordForm()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
		}
		/// <summary>
		/// 父窗体
		/// </summary>
		protected Form m_objParentForm;
		/// <summary>
		/// 要传入的控件
		/// </summary>
		protected Control m_objSelectedControl;
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// frmManageRecordForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.ClientSize = new System.Drawing.Size(1016, 741);
			this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmManageRecordForm";
			this.Text = "";

		}
		#endregion

		/// <summary>
		/// 设置调用窗体的信息
		/// </summary>
		/// <param name="p_objParentForm"></param>
		protected void m_mthSetParentFormBase(Form p_objParentForm,Control p_objSelectedControl)
		{
			m_objParentForm = p_objParentForm;
			m_objSelectedControl = p_objSelectedControl;
		}


		/// <summary>
		/// 设置控键的显示内容
		/// </summary>
		/// <param name="p_strInputString"></param>
		protected virtual void m_mthSetControlText(string p_strInputString)
		{
			if(p_strInputString == null || p_strInputString == "")
				return;
			if(m_objSelectedControl.GetType().Name == "ctlRichTextBox")
			{
				ctlRichTextBox txtFocusTextBox = (ctlRichTextBox)m_objSelectedControl;
				txtFocusTextBox.m_mthInsertText(p_strInputString,txtFocusTextBox.Text.Length);
			}
			else if(m_objSelectedControl.GetType().Name == "TextBox")
			{
				TextBox txtFocusTextBox = (TextBox)m_objSelectedControl;
				txtFocusTextBox.Text = p_strInputString;
			}
		}

		/// <summary>
		/// 设置控键的显示内容
		/// </summary>
		/// <param name="p_strInputString"></param>
		protected virtual void m_mthSetControlText(clsDeptDoctorTechnicalPost p_objDoctor)
		{
			if(p_objDoctor == null)
				return;
			if(m_objSelectedControl is ListView)
			{
				for(int i1=0;i1<((ListView)m_objSelectedControl).Items.Count;i1++)
				{
					if(((ListView)m_objSelectedControl).Items[i1].Tag.ToString().Trim() == p_objDoctor.m_strEmployeeID.ToString().Trim())
					{
						clsPublicFunction.ShowInformationMessageBox("请勿重复添加！");
						return;
					}
				}
				ListViewItem lviTemp = new ListViewItem(p_objDoctor.m_strEmployeeName);
				lviTemp.Tag = p_objDoctor.m_strEmployeeID;
				((ListView)m_objSelectedControl).Items.Add(lviTemp);
			}
			else if(m_objSelectedControl is ctlBorderTextBox)
			{
				ctlBorderTextBox txtFocusTextBox = (ctlBorderTextBox)m_objSelectedControl;
				txtFocusTextBox.Text = p_objDoctor.m_strEmployeeName;
				txtFocusTextBox.Tag = p_objDoctor.m_strEmployeeID;
			}
			else if(m_objSelectedControl is ctlRichTextBox)
			{
				ctlRichTextBox txtFocusTextBox = (ctlRichTextBox)m_objSelectedControl;
				txtFocusTextBox.Text = p_objDoctor.m_strEmployeeName;
				txtFocusTextBox.Tag = p_objDoctor.m_strEmployeeID;
			}
		}
	}
}

