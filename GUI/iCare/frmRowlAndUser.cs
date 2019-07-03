using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace iCare
{
	/// <summary>
	/// frmRowlAndUser 的摘要说明。
	/// </summary>
	public class frmRowlAndUser : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private PinkieControls.ButtonXP m_cmdCancel;
		private System.Windows.Forms.ListView m_lsvRole;
		private PinkieControls.ButtonXP m_cmdEdit;
		private PinkieControls.ButtonXP m_cmdAdd;
		private PinkieControls.ButtonXP m_cmdDel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ListView m_lsvUser;
		private System.Windows.Forms.Label label1;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboDept;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private PinkieControls.ButtonXP m_cmdOK;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRowlAndUser()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRowlAndUser));
			this.panel2 = new System.Windows.Forms.Panel();
			this.m_cboDept = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_lsvUser = new System.Windows.Forms.ListView();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.m_lsvRole = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.m_cmdEdit = new PinkieControls.ButtonXP();
			this.m_cmdAdd = new PinkieControls.ButtonXP();
			this.m_cmdDel = new PinkieControls.ButtonXP();
			this.m_cmdCancel = new PinkieControls.ButtonXP();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_cmdOK = new PinkieControls.ButtonXP();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.m_cboDept);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.m_lsvUser);
			this.panel2.Controls.Add(this.m_lsvRole);
			this.panel2.Controls.Add(this.m_cmdEdit);
			this.panel2.Controls.Add(this.m_cmdAdd);
			this.panel2.Controls.Add(this.m_cmdDel);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(544, 340);
			this.panel2.TabIndex = 0;
			// 
			// m_cboDept
			// 
			this.m_cboDept.AccessibleName = "NoDefault";
			this.m_cboDept.BackColor = System.Drawing.Color.White;
			this.m_cboDept.BorderColor = System.Drawing.Color.Black;
			this.m_cboDept.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
			this.m_cboDept.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboDept.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboDept.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboDept.ForeColor = System.Drawing.Color.Black;
			this.m_cboDept.ListBackColor = System.Drawing.SystemColors.ControlLight;
			this.m_cboDept.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboDept.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboDept.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboDept.Location = new System.Drawing.Point(56, 10);
			this.m_cboDept.m_BlnEnableItemEventMenu = false;
			this.m_cboDept.Name = "m_cboDept";
			this.m_cboDept.SelectedIndex = -1;
			this.m_cboDept.SelectedItem = null;
			this.m_cboDept.Size = new System.Drawing.Size(208, 23);
			this.m_cboDept.TabIndex = 10000006;
			this.m_cboDept.TabStop = false;
			this.m_cboDept.TextBackColor = System.Drawing.Color.White;
			this.m_cboDept.TextForeColor = System.Drawing.Color.Black;
			this.m_cboDept.SelectedIndexChanged += new System.EventHandler(this.m_cboDept_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 19);
			this.label1.TabIndex = 10000005;
			this.label1.Text = "科室:";
			// 
			// m_lsvUser
			// 
			this.m_lsvUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader2,
																						this.columnHeader3});
			this.m_lsvUser.FullRowSelect = true;
			this.m_lsvUser.GridLines = true;
			this.m_lsvUser.HideSelection = false;
			this.m_lsvUser.Location = new System.Drawing.Point(8, 40);
			this.m_lsvUser.Name = "m_lsvUser";
			this.m_lsvUser.Size = new System.Drawing.Size(256, 288);
			this.m_lsvUser.TabIndex = 10000004;
			this.m_lsvUser.View = System.Windows.Forms.View.Details;
			this.m_lsvUser.SelectedIndexChanged += new System.EventHandler(this.m_lsvUser_SelectedIndexChanged);
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "员工编号";
			this.columnHeader2.Width = 0;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "员工姓名";
			this.columnHeader3.Width = 251;
			// 
			// m_lsvRole
			// 
			this.m_lsvRole.CheckBoxes = true;
			this.m_lsvRole.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1});
			this.m_lsvRole.FullRowSelect = true;
			this.m_lsvRole.GridLines = true;
			this.m_lsvRole.HideSelection = false;
			this.m_lsvRole.Location = new System.Drawing.Point(280, 40);
			this.m_lsvRole.MultiSelect = false;
			this.m_lsvRole.Name = "m_lsvRole";
			this.m_lsvRole.Size = new System.Drawing.Size(256, 248);
			this.m_lsvRole.TabIndex = 0;
			this.m_lsvRole.View = System.Windows.Forms.View.Details;
			this.m_lsvRole.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.m_lsvRole_ItemCheck);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "角色名称";
			this.columnHeader1.Width = 252;
			// 
			// m_cmdEdit
			// 
			this.m_cmdEdit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdEdit.DefaultScheme = true;
			this.m_cmdEdit.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdEdit.ForeColor = System.Drawing.Color.Black;
			this.m_cmdEdit.Hint = "";
			this.m_cmdEdit.Location = new System.Drawing.Point(372, 296);
			this.m_cmdEdit.Name = "m_cmdEdit";
			this.m_cmdEdit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdEdit.Size = new System.Drawing.Size(76, 32);
			this.m_cmdEdit.TabIndex = 10000003;
			this.m_cmdEdit.Text = "修改角色";
			this.m_cmdEdit.Click += new System.EventHandler(this.m_cmdEdit_Click);
			// 
			// m_cmdAdd
			// 
			this.m_cmdAdd.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdAdd.DefaultScheme = true;
			this.m_cmdAdd.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdAdd.ForeColor = System.Drawing.Color.Black;
			this.m_cmdAdd.Hint = "";
			this.m_cmdAdd.Location = new System.Drawing.Point(280, 296);
			this.m_cmdAdd.Name = "m_cmdAdd";
			this.m_cmdAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdAdd.Size = new System.Drawing.Size(76, 32);
			this.m_cmdAdd.TabIndex = 10000003;
			this.m_cmdAdd.Text = "新建角色";
			this.m_cmdAdd.Click += new System.EventHandler(this.m_cmdAdd_Click);
			// 
			// m_cmdDel
			// 
			this.m_cmdDel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdDel.DefaultScheme = true;
			this.m_cmdDel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdDel.ForeColor = System.Drawing.Color.Black;
			this.m_cmdDel.Hint = "";
			this.m_cmdDel.Location = new System.Drawing.Point(460, 296);
			this.m_cmdDel.Name = "m_cmdDel";
			this.m_cmdDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdDel.Size = new System.Drawing.Size(76, 32);
			this.m_cmdDel.TabIndex = 10000003;
			this.m_cmdDel.Text = "删除角色";
			this.m_cmdDel.Click += new System.EventHandler(this.m_cmdDel_Click);
			// 
			// m_cmdCancel
			// 
			this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdCancel.DefaultScheme = true;
			this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdCancel.ForeColor = System.Drawing.Color.Black;
			this.m_cmdCancel.Hint = "";
			this.m_cmdCancel.Location = new System.Drawing.Point(452, 352);
			this.m_cmdCancel.Name = "m_cmdCancel";
			this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdCancel.Size = new System.Drawing.Size(80, 32);
			this.m_cmdCancel.TabIndex = 10000002;
			this.m_cmdCancel.Text = "取消";
			this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(0, 340);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(668, 4);
			this.groupBox1.TabIndex = 10000003;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// m_cmdOK
			// 
			this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdOK.DefaultScheme = true;
			this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdOK.ForeColor = System.Drawing.Color.Black;
			this.m_cmdOK.Hint = "";
			this.m_cmdOK.Location = new System.Drawing.Point(360, 352);
			this.m_cmdOK.Name = "m_cmdOK";
			this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdOK.Size = new System.Drawing.Size(80, 32);
			this.m_cmdOK.TabIndex = 10000002;
			this.m_cmdOK.Text = "确定";
			this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
			// 
			// frmRowlAndUser
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(544, 389);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.m_cmdCancel);
			this.Controls.Add(this.m_cmdOK);
			this.Controls.Add(this.panel2);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmRowlAndUser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "用户与角色";
			this.Load += new System.EventHandler(this.frmRowlAndUser_Load);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void m_mthGetAllRole()
		{
			string SQL="select * from T_ROLE";
			DataTable dtRecoreds=null;

			m_lsvRole.Items.Clear();

            com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ objServ =
                (com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ));

            objServ.m_lngGetMaxID(SQL, ref dtRecoreds);

			if(dtRecoreds != null)
			{
				for (int i =0;i<dtRecoreds.Rows.Count;i++)
				{
					ListViewItem titem= m_lsvRole.Items.Add(dtRecoreds.Rows[i]["ROLE_NAME"].ToString());
					titem.Tag=dtRecoreds.Rows[i];
				}
			}
		}

		private void m_cmdEdit_Click(object sender, System.EventArgs e)
		{
			if (m_lsvRole.SelectedItems.Count!=0)
			{
				frmRowlInfo frm=new frmRowlInfo("Edit",((DataRow)m_lsvRole.SelectedItems[0].Tag)["ROLE_ID"].ToString());
				frm.ShowDialog();

				m_mthGetAllRole();
			}
		}

		private void m_cmdAdd_Click(object sender, System.EventArgs e)
		{
			frmRowlInfo frm=new frmRowlInfo("Add","");
			frm.ShowDialog();

			m_mthGetAllRole();
		}

		private void frmRowlAndUser_Load(object sender, System.EventArgs e)
		{
			m_mthGetAllDept();
			m_mthGetAllRole();
		}

		private void m_cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_cmdDel_Click(object sender, System.EventArgs e)
		{
			if (m_lsvRole.SelectedItems.Count!=0)
			{
				string SQL="delete from T_ROLE where ROLE_ID =" + ((DataRow)m_lsvRole.SelectedItems[0].Tag)["ROLE_ID"] + "";

                com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ objServ =
                    (com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ));

                objServ.m_lngSaveIllnessSymptom(SQL);

				m_mthGetAllRole();
			}
		}

		private void m_mthGetAllDept()
		{
			clsDeptAndAreaInfo[] objDeptAndAreaInfoArr=null;
			clsDepartmentManager objManagerDomain=new clsDepartmentManager();
			long lngRes=objManagerDomain.m_lngGetAllDeptAndAreaInfoArr(out objDeptAndAreaInfoArr);
			if(lngRes<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("数据库连接失败!");
				return;
			}
			else if(objDeptAndAreaInfoArr==null ) 
				return;

			for(int i=0;i<objDeptAndAreaInfoArr.Length;i++)
			{
				TreeNode objNode=new TreeNode(objDeptAndAreaInfoArr[i].m_objDept.m_StrDeptName);
				frmRowlInfo.clsNodeInfo objInfo=new  iCare.frmRowlInfo.clsNodeInfo();
				objInfo.m_intCategory=1;
				objInfo.m_strID=objDeptAndAreaInfoArr[i].m_objDept.m_StrDeptID;
				objInfo.m_strName=objDeptAndAreaInfoArr[i].m_objDept.m_StrDeptName;

				objInfo.m_objDeptDesc=new iCareData.clsDept_Desc();
				objInfo.m_objDeptDesc.m_dtmCreateDate=objDeptAndAreaInfoArr[i].m_objDept.m_DtmDeptCreateDate;
				objInfo.m_objDeptDesc.m_dtmModifyDate=objDeptAndAreaInfoArr[i].m_objDept.m_DtmDeptInfoModifyDate;
				objInfo.m_objDeptDesc.m_dtmModifyDate=objDeptAndAreaInfoArr[i].m_objDept.m_DtmDeptRelationModifyDate;
				objInfo.m_objDeptDesc.m_strCategory=objDeptAndAreaInfoArr[i].m_objDept.m_EnmDeptCategory.ToString();
				objInfo.m_objDeptDesc.m_strDeActivedOperatorID="";	
				objInfo.m_objDeptDesc.m_strDeptID=objDeptAndAreaInfoArr[i].m_objDept.m_StrDeptID;
				objInfo.m_objDeptDesc.m_strDeptName=objDeptAndAreaInfoArr[i].m_objDept.m_StrDeptName;
				objInfo.m_objDeptDesc.m_strInPatientOrOutPatient=objDeptAndAreaInfoArr[i].m_objDept.m_EnmDeptType.ToString();
				objInfo.m_objDeptDesc.m_strPYCode=objDeptAndAreaInfoArr[i].m_objDept.m_StrDeptPYCode;
				objInfo.m_objDeptDesc.m_strShortNO=objDeptAndAreaInfoArr[i].m_objDept.m_StrDeptShortNO;
				m_cboDept.AddItem(objInfo);
			}		
		}

		private void m_cboDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			clsEmployee[] objEmpArr ;
			m_lsvUser.Items.Clear();
			objEmpArr = clsSystemContext.s_ObjCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeByDeptID(((iCare.frmRowlInfo.clsNodeInfo)m_cboDept.SelectedItem).m_strID);
			if(objEmpArr !=null)
			{
				for(int i=0;i<objEmpArr.Length;i++)
				{
					ListViewItem lviNewItem;
					lviNewItem = new ListViewItem(new string[]{objEmpArr[i].m_StrEmployeeID,objEmpArr[i].m_StrFirstName});
						
					lviNewItem.Tag = objEmpArr[i];
					m_lsvUser.Items.Add(lviNewItem);	
				}
			}
		}

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			string SQL="";
			
			ListViewItem tItem=null;

			for (int i =0;i<m_lsvRole.Items.Count;i++)
			{
				if (m_lsvRole.Items[i].Checked)
				{
					tItem=m_lsvRole.Items[i];
					break;
				}
			}

			if (m_lsvUser.SelectedItems.Count>0  )
			{
				for (int i=0;i<m_lsvUser.SelectedItems.Count;i++)
				{
					SQL="delete from T_ROWLANDUSER where USER_ID='" + m_lsvUser.SelectedItems[i].SubItems[0].Text.Replace("'","''") + "'";

                    com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ objServ =
                        (com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ));

                    objServ.m_lngSaveIllnessSymptom(SQL);
					if (tItem!=null)
					{
						SQL="insert into T_ROWLANDUSER (USER_ID,ROLE_ID) values ('" + m_lsvUser.SelectedItems[i].SubItems[0].Text.Replace("'","''") + "'," + ((DataRow)tItem.Tag)["ROLE_ID"].ToString() + ")";

                        objServ.m_lngSaveIllnessSymptom(SQL);
					}
				}
			}
			else
			{
				clsPublicFunction.ShowInformationMessageBox("未选择用户或角色!");
				return;
			}
			this.Close();
		}

		private void m_lsvRole_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			for(int i=0;i<m_lsvRole.Items.Count;i++)
			{
				if (i!=e.Index)
					m_lsvRole.Items[i].Checked=false;
			}
			
		}

		private void m_lsvUser_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string SQL="";
			DataTable dtRecords=null;
			
			if (m_lsvUser.SelectedItems.Count<=0)
				return;
			
            SQL="select * from t_rowlanduser where USER_ID='" + m_lsvUser.SelectedItems[m_lsvUser.SelectedItems.Count-1].SubItems[0].Text.Replace("'","''") + "'";

            com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ objServ =
                (com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ));

            objServ.m_lngGetMaxID(SQL, ref dtRecords);

			if(dtRecords!=null )
			{
				for(int i=0;i<m_lsvRole.Items.Count;i++)
				{
					m_lsvRole.Items[i].Checked=false;
					if (dtRecords.Rows.Count>0)
					{
						if (dtRecords.Rows[0]["ROLE_ID"].ToString()==((DataRow)m_lsvRole.Items[i].Tag)["ROLE_ID"].ToString())
						{
							m_lsvRole.Items[i].Checked=true;
						}
					}
				}
			}
		
		}

		public static void m_mthGetUserRole(string p_strSourceName, ref DataTable dtRecords)
		{
			string SQL="select c.* from T_ROWLANDUSER a,T_ROLEDETAIL b,T_PURVIEWDEFINE c where a.ROLE_ID=b.ROLE_ID and b.PURVIEW_ID=c.PURVIEW_ID and a.USER_ID='" + MDIParent.strOperatorID.Replace("'","''") + "' and PURVIEW_SOURCE='" + p_strSourceName.Replace("'","''") + "'";

            com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ objServ =
                (com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ));

            objServ.m_lngGetMaxID(SQL,ref dtRecords);
		}
	}
}
