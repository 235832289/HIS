using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCareData;

namespace com.digitalwave.Emr.Signature_gui
{
	/// <summary>
	/// frmVerifySigners ��ժҪ˵����
	/// �޺ۼ��޸���֤ǩ����
	/// </summary>
	public class frmVerifySigners : System.Windows.Forms.Form
	{
		#region ϵͳ
		public System.Windows.Forms.ListView m_lsvItemList;
		private System.Windows.Forms.Label lblM;
		private System.Windows.Forms.Button btnConfirm;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		

		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.m_lsvItemList = new System.Windows.Forms.ListView();
			this.lblM = new System.Windows.Forms.Label();
			this.btnConfirm = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// m_lsvItemList
			// 
			this.m_lsvItemList.BackColor = System.Drawing.SystemColors.Info;
			this.m_lsvItemList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lsvItemList.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lsvItemList.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvItemList.ForeColor = System.Drawing.Color.Black;
			this.m_lsvItemList.FullRowSelect = true;
			this.m_lsvItemList.GridLines = true;
			this.m_lsvItemList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_lsvItemList.HideSelection = false;
			this.m_lsvItemList.Location = new System.Drawing.Point(0, 0);
			this.m_lsvItemList.MultiSelect = false;
			this.m_lsvItemList.Name = "m_lsvItemList";
			this.m_lsvItemList.Size = new System.Drawing.Size(338, 160);
			this.m_lsvItemList.TabIndex = 2;
			this.m_lsvItemList.View = System.Windows.Forms.View.Details;
			this.m_lsvItemList.DoubleClick += new System.EventHandler(this.m_lsvItemList_DoubleClick);
			// 
			// lblM
			// 
			this.lblM.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lblM.ForeColor = System.Drawing.Color.Red;
			this.lblM.Location = new System.Drawing.Point(0, 207);
			this.lblM.Name = "lblM";
			this.lblM.Size = new System.Drawing.Size(338, 32);
			this.lblM.TabIndex = 3;
			this.lblM.Text = "    ��ʾ�����������ʱ�Ƕ�ǩ����������޺ۼ��޸���Ҫ������֤ǩ���ߣ�����ֻ�����кۼ��޸ġ�";
			// 
			// btnConfirm
			// 
			this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnConfirm.Location = new System.Drawing.Point(176, 168);
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.TabIndex = 4;
			this.btnConfirm.Text = "ȷ��";
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Location = new System.Drawing.Point(256, 168);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 24);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "ȡ��";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label1.Location = new System.Drawing.Point(0, 200);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(336, 2);
			this.label1.TabIndex = 6;
			// 
			// frmVerifySigners
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(338, 239);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnConfirm);
			this.Controls.Add(this.lblM);
			this.Controls.Add(this.m_lsvItemList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmVerifySigners";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "�޺ۼ��޸���֤ǩ����";
			this.TopMost = true;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmVerifySigners_Closing);
			this.Load += new System.EventHandler(this.frmVerifySigners_Load);
			this.ResumeLayout(false);

		}
		#endregion
				#endregion

		#region ���캯��
		public frmVerifySigners(ArrayList objArr)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			objSignerArr=objArr;
			objController = new clsVerifySignersController(this);
			this.TopMost=true;
		}
		#endregion

		#region �ֶ�
		/// <summary>
		/// ���������
		/// </summary>
		private clsVerifySignersController objController=null;
		/// <summary>
		/// ǩ���߼���
		/// </summary>
		public  ArrayList objSignerArr;
		/// <summary>
		/// �Ƿ�ͨ����֤��Ĭ��Ϊfalse
		/// </summary>
		public bool blnIsPass=false;
		#endregion

		#region �¼�
		/// <summary>
		/// ���������¼�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmVerifySigners_Load(object sender, System.EventArgs e)
		{
			m_lsvItemList.Columns.Clear();
			m_lsvItemList.Columns.Add("����",80,HorizontalAlignment.Left);
			m_lsvItemList.Columns.Add("ְ��",90,HorizontalAlignment.Left);
			m_lsvItemList.Columns.Add("��֤",90,HorizontalAlignment.Left);
			m_lsvItemList.ResumeLayout(false);
			m_lsvItemList.Items.Clear();
			//�б�
			objController.m_mthListSigners();
		}
	
		/// <summary>
		/// �˳��¼�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmVerifySigners_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			objController.m_mthComfirm();
			if (blnIsPass==false)
				this.DialogResult=System.Windows.Forms.DialogResult.Cancel;
			else
				this.DialogResult=System.Windows.Forms.DialogResult.OK;
		}	
		/// <summary>
		/// ȷ���¼�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnConfirm_Click(object sender, System.EventArgs e)
		{
			Close();
		}
		/// <summary>
		/// ȡ���¼�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}
		/// <summary>
		/// ˫���¼�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_lsvItemList_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				objController.m_mthVerifySiger();
			}
			catch (Exception exp)
			{
				MessageBox.Show("��֤ʧ�ܣ�����ͨ����֤��\n"+exp.Message,"iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);

			}
		}

	#endregion

	}
}
