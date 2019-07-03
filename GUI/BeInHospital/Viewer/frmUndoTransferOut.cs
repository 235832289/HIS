using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmUndoTransferOut ��ժҪ˵����
	/// </summary>
	public class frmUndoTransferOut : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private PinkieControls.ButtonXP m_cmdOK;
		private PinkieControls.ButtonXP m_cmdCancel;
		internal System.Windows.Forms.ComboBox m_cboEmptyBed;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmUndoTransferOut()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

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
            this.m_cboEmptyBed = new System.Windows.Forms.ComboBox();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cboEmptyBed
            // 
            this.m_cboEmptyBed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboEmptyBed.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboEmptyBed.Location = new System.Drawing.Point(125, 33);
            this.m_cboEmptyBed.Name = "m_cboEmptyBed";
            this.m_cboEmptyBed.Size = new System.Drawing.Size(101, 22);
            this.m_cboEmptyBed.TabIndex = 1;
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_cmdOK.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(80, 99);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOK.Size = new System.Drawing.Size(72, 28);
            this.m_cmdOK.TabIndex = 1;
            this.m_cmdOK.Text = "ȷ��(&S)";
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancel.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(167, 100);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(72, 28);
            this.m_cmdCancel.TabIndex = 2;
            this.m_cmdCancel.Text = "ȡ��(&C)";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(61, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "��λ:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_cboEmptyBed);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // frmUndoTransferOut
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(301, 133);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_cmdOK);
            this.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUndoTransferOut";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "����ת��";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
	}
}
