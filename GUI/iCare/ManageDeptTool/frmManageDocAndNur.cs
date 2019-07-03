using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;
using iCareData;

namespace iCare
{
	/// <summary>
	/// Summary description for frmManageDocAndNur.
	/// </summary>
	public class frmManageDocAndNur : iCare.iCareBaseForm.frmBaseForm
	{
		private System.Windows.Forms.ListBox lstAllEmployee;
		private System.Windows.Forms.ListBox lstDoc;
		private System.Windows.Forms.ListBox lstNur;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        //private clsBorderTool m_objBorderTool;
		private ctlHighLightFocus m_objHighLight;
		private clsManageDocAndNurDomain m_objDomain;
		private ArrayList m_arlAddOrRemove;
		private ArrayList m_arlValue;
		private PinkieControls.ButtonXP cmdAddDoc;
		private PinkieControls.ButtonXP cmdRemoveDoc;
		private PinkieControls.ButtonXP cmdAddNur;
		private PinkieControls.ButtonXP cmdRemoveNur;
		private PinkieControls.ButtonXP cmdCancel;
		private PinkieControls.ButtonXP cmdOK;

		private const string c_strAnaDeptID = "9900001";

		public frmManageDocAndNur()
		{
			InitializeComponent();

            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[] {lstAllEmployee,lstDoc,lstNur});
			m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);
			m_objHighLight.m_mthAddControlInContainer(this);

			m_objDomain = new clsManageDocAndNurDomain();
			
			#region 初始化listBox
			clsDocAndNur[] objArr = m_objDomain.m_objGetSpecialEmployeeInDept(0);
			if(objArr != null && objArr.Length > 0)
				lstAllEmployee.Items.AddRange(objArr);

			clsDocAndNur[] objArr1 = m_objDomain.m_objGetSpecialEmployeeInDept(1);
			if(objArr1 != null && objArr1.Length > 0)
				lstDoc.Items.AddRange(objArr1);

			clsDocAndNur[] objArr2 = m_objDomain.m_objGetSpecialEmployeeInDept(2);
			if(objArr2 != null && objArr2.Length > 0)
				lstNur.Items.AddRange(objArr2);
			#endregion

			m_arlAddOrRemove = new ArrayList();
			m_arlValue = new ArrayList();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmManageDocAndNur));
			this.lstAllEmployee = new System.Windows.Forms.ListBox();
			this.lstDoc = new System.Windows.Forms.ListBox();
			this.lstNur = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cmdAddDoc = new PinkieControls.ButtonXP();
			this.cmdRemoveDoc = new PinkieControls.ButtonXP();
			this.cmdAddNur = new PinkieControls.ButtonXP();
			this.cmdRemoveNur = new PinkieControls.ButtonXP();
			this.cmdCancel = new PinkieControls.ButtonXP();
			this.cmdOK = new PinkieControls.ButtonXP();
			this.SuspendLayout();
			// 
			// lstAllEmployee
			// 
			this.lstAllEmployee.BackColor = System.Drawing.Color.White;
			this.lstAllEmployee.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lstAllEmployee.ForeColor = System.Drawing.Color.Black;
			this.lstAllEmployee.ItemHeight = 14;
			this.lstAllEmployee.Location = new System.Drawing.Point(16, 48);
			this.lstAllEmployee.Name = "lstAllEmployee";
			this.lstAllEmployee.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstAllEmployee.Size = new System.Drawing.Size(160, 340);
			this.lstAllEmployee.TabIndex = 0;
			// 
			// lstDoc
			// 
			this.lstDoc.BackColor = System.Drawing.Color.White;
			this.lstDoc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lstDoc.ForeColor = System.Drawing.Color.Black;
			this.lstDoc.ItemHeight = 14;
			this.lstDoc.Location = new System.Drawing.Point(264, 48);
			this.lstDoc.Name = "lstDoc";
			this.lstDoc.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstDoc.Size = new System.Drawing.Size(160, 144);
			this.lstDoc.TabIndex = 1;
			// 
			// lstNur
			// 
			this.lstNur.BackColor = System.Drawing.Color.White;
			this.lstNur.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lstNur.ForeColor = System.Drawing.Color.Black;
			this.lstNur.ItemHeight = 14;
			this.lstNur.Location = new System.Drawing.Point(264, 240);
			this.lstNur.Name = "lstNur";
			this.lstNur.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstNur.Size = new System.Drawing.Size(160, 144);
			this.lstNur.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 19);
			this.label1.TabIndex = 3;
			this.label1.Text = "所有员工:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(264, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 19);
			this.label2.TabIndex = 4;
			this.label2.Text = "医生:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(264, 208);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 19);
			this.label3.TabIndex = 5;
			this.label3.Text = "护士:";
			// 
			// cmdAddDoc
			// 
			this.cmdAddDoc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdAddDoc.DefaultScheme = true;
			this.cmdAddDoc.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdAddDoc.ForeColor = System.Drawing.Color.Black;
			this.cmdAddDoc.Hint = "";
			this.cmdAddDoc.Location = new System.Drawing.Point(192, 92);
			this.cmdAddDoc.Name = "cmdAddDoc";
			this.cmdAddDoc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdAddDoc.Size = new System.Drawing.Size(52, 32);
			this.cmdAddDoc.TabIndex = 10000001;
			this.cmdAddDoc.Text = "→";
			this.cmdAddDoc.Click += new System.EventHandler(this.cmdToDoc_Click);
			// 
			// cmdRemoveDoc
			// 
			this.cmdRemoveDoc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdRemoveDoc.DefaultScheme = true;
			this.cmdRemoveDoc.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdRemoveDoc.ForeColor = System.Drawing.Color.Black;
			this.cmdRemoveDoc.Hint = "";
			this.cmdRemoveDoc.Location = new System.Drawing.Point(192, 124);
			this.cmdRemoveDoc.Name = "cmdRemoveDoc";
			this.cmdRemoveDoc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdRemoveDoc.Size = new System.Drawing.Size(52, 32);
			this.cmdRemoveDoc.TabIndex = 10000001;
			this.cmdRemoveDoc.Text = "←";
			this.cmdRemoveDoc.Click += new System.EventHandler(this.cmdRemoveDoc_Click);
			// 
			// cmdAddNur
			// 
			this.cmdAddNur.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdAddNur.DefaultScheme = true;
			this.cmdAddNur.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdAddNur.ForeColor = System.Drawing.Color.Black;
			this.cmdAddNur.Hint = "";
			this.cmdAddNur.Location = new System.Drawing.Point(192, 288);
			this.cmdAddNur.Name = "cmdAddNur";
			this.cmdAddNur.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdAddNur.Size = new System.Drawing.Size(52, 32);
			this.cmdAddNur.TabIndex = 10000001;
			this.cmdAddNur.Text = "→";
			this.cmdAddNur.Click += new System.EventHandler(this.cmdToNur_Click);
			// 
			// cmdRemoveNur
			// 
			this.cmdRemoveNur.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdRemoveNur.DefaultScheme = true;
			this.cmdRemoveNur.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdRemoveNur.ForeColor = System.Drawing.Color.Black;
			this.cmdRemoveNur.Hint = "";
			this.cmdRemoveNur.Location = new System.Drawing.Point(192, 320);
			this.cmdRemoveNur.Name = "cmdRemoveNur";
			this.cmdRemoveNur.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdRemoveNur.Size = new System.Drawing.Size(52, 32);
			this.cmdRemoveNur.TabIndex = 10000001;
			this.cmdRemoveNur.Text = "←";
			this.cmdRemoveNur.Click += new System.EventHandler(this.cmdRemoveNur_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdCancel.DefaultScheme = true;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmdCancel.ForeColor = System.Drawing.Color.Black;
			this.cmdCancel.Hint = "";
			this.cmdCancel.Location = new System.Drawing.Point(360, 396);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdCancel.Size = new System.Drawing.Size(64, 32);
			this.cmdCancel.TabIndex = 10000001;
			this.cmdCancel.Text = "取 消";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdOK.DefaultScheme = true;
			this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmdOK.ForeColor = System.Drawing.Color.Black;
			this.cmdOK.Hint = "";
			this.cmdOK.Location = new System.Drawing.Point(292, 396);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdOK.Size = new System.Drawing.Size(64, 32);
			this.cmdOK.TabIndex = 10000001;
			this.cmdOK.Text = "确 定";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// frmManageDocAndNur
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(446, 439);
			this.Controls.Add(this.cmdAddDoc);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmdRemoveDoc);
			this.Controls.Add(this.cmdAddNur);
			this.Controls.Add(this.cmdRemoveNur);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.lstNur);
			this.Controls.Add(this.lstDoc);
			this.Controls.Add(this.lstAllEmployee);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmManageDocAndNur";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "员工维护";
			this.Load += new System.EventHandler(this.frmManageDocAndNur_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdToDoc_Click(object sender, System.EventArgs e)
		{
			m_mthAddDocOrNur(lstDoc,1);			
		}

		private void cmdToNur_Click(object sender, System.EventArgs e)
		{
			m_mthAddDocOrNur(lstNur,0);
		}

		private void cmdRemoveDoc_Click(object sender, System.EventArgs e)
		{
			m_mthRemoveDocOrNur(lstDoc);
		}

		private void m_mthSave()
		{
			if(m_arlAddOrRemove.Count ==0) return;

			bool[] blnArr = (bool[])m_arlAddOrRemove.ToArray(typeof(bool));
			clsDocAndNur[] objArr = (clsDocAndNur[])m_arlValue.ToArray(typeof(clsDocAndNur));

			long lngRes = m_objDomain.m_lngSave(blnArr,objArr);
			if(lngRes < 0)
				clsPublicFunction.ShowInformationMessageBox(clsHRPMessage.c_strSaveFail);
			else
			{
				m_arlAddOrRemove.Clear();
				m_arlValue.Clear();
			}
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			m_mthSave();
		}

		private void m_mthAddDocOrNur(ListBox p_lstTarget,int p_intFlag)
		{
			if(lstAllEmployee.SelectedItems.Count < 1) return;

			for(int i = 0;i < lstAllEmployee.SelectedItems.Count;i++)
			{
				clsDocAndNur obj = (clsDocAndNur)lstAllEmployee.SelectedItems[i];
				obj.m_intFlag = p_intFlag;
				bool blnExist = false;
				
				ArrayList arlExistItems = new ArrayList();
				arlExistItems.AddRange(lstDoc.Items);
				arlExistItems.AddRange(lstNur.Items);
				clsDocAndNur[] objArr = (clsDocAndNur[])arlExistItems.ToArray(typeof(clsDocAndNur));
				arlExistItems.Clear();

				if(objArr.Length > 0)
				{
					for(int j = 0;j < objArr.Length;j++)
					{
						if(obj.m_strEmployeeID == objArr[j].m_strEmployeeID)
						{
							blnExist = true;
							break;
						}
					}					
				}
				if(!blnExist)
				{
					p_lstTarget.Items.Add(obj);
					m_arlAddOrRemove.Add(true);
					m_arlValue.Add(obj);
				}
			}
		}

		private void m_mthRemoveDocOrNur(ListBox p_lst)
		{
			if(p_lst.SelectedItems.Count < 1) 
				return;

			while(p_lst.SelectedItems.Count > 0)
			{
				clsDocAndNur obj = (clsDocAndNur)p_lst.SelectedItems[0];
				m_arlAddOrRemove.Add(false);
				m_arlValue.Add(obj);
				p_lst.Items.Remove(p_lst.SelectedItems[0]);
			}

		}

		private void cmdRemoveNur_Click(object sender, System.EventArgs e)
		{
			m_mthRemoveDocOrNur(lstNur);
		}

		private void frmManageDocAndNur_Load(object sender, System.EventArgs e)
		{
			lstAllEmployee.Focus();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
