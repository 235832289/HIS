using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.common.ICD10.Midtier;
using System.Data;
//using com.digitalwave.iCare.middletier.HRPService;

namespace iCare
{
	/// <summary>
	/// FrmRowlAndUser 的摘要说明。
	/// </summary>
	public class frmRowlInfo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TreeView m_trvFunctionByFrom;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox m_txtName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox m_txtDesc;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TreeView m_trvDepartment;
		private System.Windows.Forms.Label label1;
		private PinkieControls.ButtonXP m_cmdCancel;
		private PinkieControls.ButtonXP m_cmdOK;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRowlInfo()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		public frmRowlInfo(string p_strMode,string p_RoleID):this()
		{
			m_strMode=p_strMode;
			m_RoleID=p_RoleID;
		}

		#region 定义的变量
		clsDepartmentManager m_objManagerDomain=new clsDepartmentManager();
		private string m_strMode;
		private string m_RoleID;
		private DataTable m_dtFunction;
		private	DataTable dtRecords0=null;			
		#endregion 定义的变量
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRowlInfo));
			this.panel3 = new System.Windows.Forms.Panel();
			this.m_trvFunctionByFrom = new System.Windows.Forms.TreeView();
			this.label4 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.m_txtName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtDesc = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.m_trvDepartment = new System.Windows.Forms.TreeView();
			this.label1 = new System.Windows.Forms.Label();
			this.m_cmdOK = new PinkieControls.ButtonXP();
			this.m_cmdCancel = new PinkieControls.ButtonXP();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.m_trvFunctionByFrom);
			this.panel3.Location = new System.Drawing.Point(352, 132);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(316, 328);
			this.panel3.TabIndex = 9;
			// 
			// m_trvFunctionByFrom
			// 
			this.m_trvFunctionByFrom.CheckBoxes = true;
			this.m_trvFunctionByFrom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_trvFunctionByFrom.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_trvFunctionByFrom.ImageIndex = -1;
			this.m_trvFunctionByFrom.Location = new System.Drawing.Point(0, 0);
			this.m_trvFunctionByFrom.Name = "m_trvFunctionByFrom";
			this.m_trvFunctionByFrom.SelectedImageIndex = -1;
			this.m_trvFunctionByFrom.Size = new System.Drawing.Size(316, 328);
			this.m_trvFunctionByFrom.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(352, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(164, 19);
			this.label4.TabIndex = 8;
			this.label4.Text = "为角色创建操作功能权限";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.m_txtName);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.m_txtDesc);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Location = new System.Drawing.Point(8, 8);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(656, 100);
			this.panel2.TabIndex = 7;
			// 
			// m_txtName
			// 
			this.m_txtName.Location = new System.Drawing.Point(92, 16);
			this.m_txtName.Name = "m_txtName";
			this.m_txtName.Size = new System.Drawing.Size(204, 23);
			this.m_txtName.TabIndex = 1;
			this.m_txtName.Text = "";
			this.m_txtName.TextChanged += new System.EventHandler(this.m_txtName_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 19);
			this.label2.TabIndex = 0;
			this.label2.Text = "角色名称：";
			// 
			// m_txtDesc
			// 
			this.m_txtDesc.Location = new System.Drawing.Point(92, 44);
			this.m_txtDesc.Multiline = true;
			this.m_txtDesc.Name = "m_txtDesc";
			this.m_txtDesc.Size = new System.Drawing.Size(424, 52);
			this.m_txtDesc.TabIndex = 1;
			this.m_txtDesc.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 19);
			this.label3.TabIndex = 0;
			this.label3.Text = "角色说明：";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.m_trvDepartment);
			this.panel1.Location = new System.Drawing.Point(8, 132);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(316, 328);
			this.panel1.TabIndex = 6;
			// 
			// m_trvDepartment
			// 
			this.m_trvDepartment.CheckBoxes = true;
			this.m_trvDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_trvDepartment.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_trvDepartment.ImageIndex = -1;
			this.m_trvDepartment.Location = new System.Drawing.Point(0, 0);
			this.m_trvDepartment.Name = "m_trvDepartment";
			this.m_trvDepartment.SelectedImageIndex = -1;
			this.m_trvDepartment.Size = new System.Drawing.Size(316, 328);
			this.m_trvDepartment.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 112);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(212, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "为角色创建科室数据权限";
			// 
			// m_cmdOK
			// 
			this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdOK.DefaultScheme = true;
			this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdOK.Enabled = false;
			this.m_cmdOK.ForeColor = System.Drawing.Color.Black;
			this.m_cmdOK.Hint = "";
			this.m_cmdOK.Location = new System.Drawing.Point(484, 468);
			this.m_cmdOK.Name = "m_cmdOK";
			this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdOK.Size = new System.Drawing.Size(84, 32);
			this.m_cmdOK.TabIndex = 10000001;
			this.m_cmdOK.Text = "完成";
			this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
			// 
			// m_cmdCancel
			// 
			this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdCancel.DefaultScheme = true;
			this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdCancel.ForeColor = System.Drawing.Color.Black;
			this.m_cmdCancel.Hint = "";
			this.m_cmdCancel.Location = new System.Drawing.Point(576, 468);
			this.m_cmdCancel.Name = "m_cmdCancel";
			this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdCancel.Size = new System.Drawing.Size(84, 32);
			this.m_cmdCancel.TabIndex = 10000001;
			this.m_cmdCancel.Text = "取消";
			this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
			// 
			// frmRowlInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(680, 505);
			this.Controls.Add(this.m_cmdOK);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.m_cmdCancel);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmRowlInfo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "定义角色权限";
			this.Load += new System.EventHandler(this.frmRowlInfo_Load);
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region 数据权限抄做

		#region 科室部门抄做
		private void m_mthGetAllDept()
		{
			m_trvDepartment.Nodes.Add("全院--科室");
			clsDeptAndAreaInfo[] objDeptAndAreaInfoArr=null;
			long lngRes=m_objManagerDomain.m_lngGetAllDeptAndAreaInfoArr(out objDeptAndAreaInfoArr);
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
				clsNodeInfo objInfo=new clsNodeInfo();
				objInfo.m_intCategory=1;
				objInfo.m_strCategoryName="科室";
				objInfo.m_strID=objDeptAndAreaInfoArr[i].m_objDept.m_StrDeptID;
				objInfo.m_strName=objDeptAndAreaInfoArr[i].m_objDept.m_StrDeptName;

				objInfo.m_objDeptDesc=new clsDept_Desc();
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


				objInfo.m_objChildCategory=new clsNodeInfo();
				objInfo.m_objChildCategory.m_intCategory=2;
				objInfo.m_objChildCategory.m_strCategoryName="病区";
				objNode.Tag=objInfo;
				objNode.ImageIndex=23;
				m_trvDepartment.Nodes[0].Nodes.Add(objNode);
			}		
		}
		#endregion 科室部门抄做

	
		//递归添加树的节点
		public void AddTree(int ParentID,TreeNode pNode) 
		{
			DataView dvTree = new DataView();
			dvTree=new DataView(dtRecords0);
			//过滤父id得到当前的所有子节点
                dvTree.RowFilter =  "[PURVIEW_pID] = " + ParentID;
			foreach(DataRowView Row in dvTree) 
			{
				if(pNode == null) 
				{    
					//添加根节点
					TreeNode tNode = m_trvFunctionByFrom.Nodes.Add(Row["PURVIEW_CNAME"].ToString());
					tNode.Tag=Row.Row;
					if(Row["PURVIEW_FUNCTION"].ToString().Trim().Length!=0)
					{
						tNode.ForeColor=Color.Blue;
					}
						
					if (m_strMode=="Edit")
					{
						if (m_dtFunction!=null)
						{
							for (int k=0;k<m_dtFunction.Rows.Count;k++)
							{
								if (Row["PURVIEW_ID"].ToString()==m_dtFunction.Rows[k]["PURVIEW_ID"].ToString())
								{
									tNode.Checked=true;
									break;
								}
							}
						}
					}

					AddTree(Int32.Parse(Row["PURVIEW_ID"].ToString()),tNode);   //再次递归
				} 
				else 
				{   
					//添加当前节点的子节点
					TreeNode tNode =  pNode.Nodes.Add(Row["PURVIEW_CNAME"].ToString());
					tNode.Tag=Row.Row;
					if(Row["PURVIEW_FUNCTION"].ToString().Trim().Length!=0)
					{
						tNode.ForeColor=Color.Blue;
					}
						
					if (m_strMode=="Edit")
					{
						if (m_dtFunction!=null)
						{
							for (int k=0;k<m_dtFunction.Rows.Count;k++)
							{
								if (Row["PURVIEW_ID"].ToString()==m_dtFunction.Rows[k]["PURVIEW_ID"].ToString())
								{
									tNode.Checked=true;
									break;
								}
							}
						}
					}
					AddTree(Int32.Parse(Row["PURVIEW_ID"].ToString()),tNode);	//再次递归
				}
			}			
		}		


		#region 得到所有界面抄做功能权限
		private void m_mthGetAllFunctionByFrom()
		{
			string SQL="";
//			TreeNode pNode=null;
		
			ArrayList NoteArry=new ArrayList();

            com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ objServ =
                    (com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ));

            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "440104001")
			{
			#region sqlserver 2000
				SQL="select * from t_purviewdefine ";

                objServ.m_lngGetMaxID(SQL, ref dtRecords0);
				if(dtRecords0!=null)
				{
					//调用递归函数完成树形结构
					AddTree(-1, (TreeNode)null);

				}
			#endregion 
				
			}
			else
			{
			#region oracle
				SQL="select * from t_purviewdefine start with PURVIEW_pID is null and (purview_type=0 or purview_type=1) connect by prior PURVIEW_ID=PURVIEW_pID";
                objServ.m_lngGetMaxID(SQL, ref dtRecords0);

				if(dtRecords0!=null)
				{
					for (int i=0;i<dtRecords0.Rows.Count;i++)
					{
						if (dtRecords0.Rows[i]["PURVIEW_pID"].ToString().Trim().Length==0)
						{ //根节点
							TreeNode tNode=m_trvFunctionByFrom.Nodes.Add(dtRecords0.Rows[i]["PURVIEW_CNAME"].ToString());
							tNode.Tag=dtRecords0.Rows[i];
						
							if(dtRecords0.Rows[i]["PURVIEW_FUNCTION"].ToString().Trim().Length!=0)
							{
								tNode.ForeColor=Color.Blue;
							}
						
							if (m_strMode=="Edit")
							{
								if (m_dtFunction!=null)
								{
									for (int k=0;k<m_dtFunction.Rows.Count;k++)
									{
										if (dtRecords0.Rows[i]["PURVIEW_ID"].ToString()==m_dtFunction.Rows[k]["PURVIEW_ID"].ToString())
										{
											tNode.Checked=true;
											break;
										}
									}
								}
							}
							NoteArry.Add(tNode);
						}
						else
						{
							for(int j=0;j<NoteArry.Count;j++)
							{
								if (((DataRow)((TreeNode)NoteArry[j]).Tag)["PURVIEW_ID"].ToString().Trim()==dtRecords0.Rows[i]["PURVIEW_pID"].ToString().Trim())
								{
									TreeNode tpNode = ((TreeNode)NoteArry[j]).Nodes.Add(dtRecords0.Rows[i]["PURVIEW_CNAME"].ToString());
									tpNode.Tag = dtRecords0.Rows[i];

									if(dtRecords0.Rows[i]["PURVIEW_FUNCTION"].ToString().Trim().Length!=0)
									{
										tpNode.ForeColor=Color.Blue;
									}

									if (m_strMode=="Edit")
									{
										if (m_dtFunction!=null)
										{
											for (int k=0;k<m_dtFunction.Rows.Count;k++)
											{
												if (dtRecords0.Rows[i]["PURVIEW_ID"].ToString()==m_dtFunction.Rows[k]["PURVIEW_ID"].ToString())
												{
													tpNode.Checked=true;
													break;
												}
											}
										}
									}
									NoteArry.Add(tpNode);
									break;
								}
							}
						}

					}
				}
			#endregion oracle
				
			}


			#region old
//			if (dtRecords!=null)
//			{
//				for (int i=0;i<dtRecords.Rows.Count;i++)
//				{
//					if (dtRecords.Rows[i]["PURVIEW_pID"].ToString().Trim().Length==0)
//					{
//						TreeNode tNode=m_trvFunctionByFrom.Nodes.Add(dtRecords.Rows[i]["PURVIEW_CNAME"].ToString());
//						tNode.Tag=dtRecords.Rows[i];
//						if (m_strMode=="Edit")
//						{
//							if (m_dtFunction!=null)
//							{
//								for (int k=0;k<m_dtFunction.Rows.Count;k++)
//								{
//									if (dtRecords.Rows[i]["PURVIEW_ID"].ToString()==m_dtFunction.Rows[k]["PURVIEW_ID"].ToString())
//									{
//										tNode.Checked=true;
//										break;
//									}
//								}
//							}
//						}
//						pNode=tNode;
//					}
//					else
//					{
//						if (pNode!=null)
//						{
//							TreeNode tNode=pNode.Nodes.Add(dtRecords.Rows[i]["PURVIEW_CNAME"].ToString());
//							tNode.Tag=dtRecords.Rows[i];
//							if (m_strMode=="Edit")
//							{
//								if (m_dtFunction!=null)
//								{
//									for (int k=0;k<m_dtFunction.Rows.Count;k++)
//									{
//										if (dtRecords.Rows[i]["PURVIEW_ID"].ToString()==m_dtFunction.Rows[k]["PURVIEW_ID"].ToString())
//										{
//											tNode.Checked=true;
//											break;
//										}
//									}
//								}
//							}
//						}
//					}
//					
//				}
//			}
			#endregion old
		}
		#endregion 得到所有界面抄做功能权限

		#endregion 数据权限抄做

		private void frmRowlInfo_Load(object sender, System.EventArgs e)
		{
			if (m_strMode=="Edit")
				m_mthGetData(m_RoleID);

			m_mthGetAllDept();
			m_mthGetAllFunctionByFrom();
		}

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			string SQL="";
			string strMaxID="";
			DataTable dtRecords=null;

            com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ objServ =
                (com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ));

			if (m_strMode=="Edit")
			{
				SQL="update T_ROLE set ROLE_NAME='" + m_txtName.Text.Replace("'","''") + "',ROLE_DESC='" + m_txtDesc.Text.Replace("'","''") + "' where ROLE_ID="+ m_RoleID + "";
                objServ.m_lngSaveIllnessSymptom(SQL);

				SQL="delete from T_ROLEDETAIL where ROLE_ID="+ m_RoleID + "";
                objServ.m_lngSaveIllnessSymptom(SQL);
				
				for (int i=0;i<m_trvFunctionByFrom.Nodes.Count;i++)
				{
					if(m_trvFunctionByFrom.Nodes[i].Checked)
					{
						SQL="insert into T_ROLEDETAIL(ROLE_ID,PURVIEW_ID,ROLE_TYPE,ROLE_VALUES) values ("+ m_RoleID + "," + ((DataRow)m_trvFunctionByFrom.Nodes[i].Tag)["PURVIEW_ID"].ToString() + ",0,'')";
                        objServ.m_lngSaveIllnessSymptom(SQL);
					}
					m_mthSeachNode(m_trvFunctionByFrom.Nodes[i],m_RoleID);
				}
			}
			else if (m_strMode=="Add")
			{
                if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "440104001")
				{
					SQL="select isnull(max(ROLE_ID),0)+1 from T_ROLE";				}
				else
				{
					SQL="select nvl(max(ROLE_ID),0)+1 from T_ROLE";				}


                    objServ.m_lngGetMaxID(SQL, ref dtRecords);
				if (dtRecords!=null)
				{
					strMaxID=dtRecords.Rows[0][0].ToString();
				}
				dtRecords.Clear();
				dtRecords=null;

				SQL="insert into T_ROLE (ROLE_ID,ROLE_NAME,ROLE_DESC) values ("+ strMaxID + ",'" + m_txtName.Text.Replace("'","''") + "','" + m_txtDesc.Text.Replace("'","''") + "')";
                objServ.m_lngSaveIllnessSymptom(SQL);

				for (int i=0;i<m_trvFunctionByFrom.Nodes.Count;i++)
				{
					if(m_trvFunctionByFrom.Nodes[i].Checked)
					{
						SQL="insert into T_ROLEDETAIL(ROLE_ID,PURVIEW_ID,ROLE_TYPE,ROLE_VALUES) values ("+ strMaxID + "," + ((DataRow)m_trvFunctionByFrom.Nodes[i].Tag)["PURVIEW_ID"].ToString() + ",0,'')";
                        objServ.m_lngSaveIllnessSymptom(SQL);
					}
					m_mthSeachNode(m_trvFunctionByFrom.Nodes[i],strMaxID);
				}
			}
			this.Close();
		}

		private void m_mthSaveFunciton(string p_strmaxid ,TreeNode p_node)
		{
			string SQL="insert into T_ROLEDETAIL(ROLE_ID,PURVIEW_ID,ROLE_TYPE,ROLE_VALUES) values ("+ p_strmaxid + "," + ((DataRow)p_node.Tag)["PURVIEW_ID"].ToString() + ",0,'')";

            com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ objServ =
                (com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ));

            objServ.m_lngSaveIllnessSymptom(SQL);
		}

		private void m_mthSeachNode(TreeNode p_node,string p_strmaxid)
		{
			if (p_node.Nodes.Count>0)
			{
				for(int i=0;i<p_node.Nodes.Count;i++)
				{
					if(p_node.Nodes[i].Checked)
					m_mthSaveFunciton(p_strmaxid,p_node.Nodes[i]);
					m_mthSeachNode(p_node.Nodes[i],p_strmaxid);
				}
			}
		}

		private void m_txtName_TextChanged(object sender, System.EventArgs e)
		{
			if (m_txtName.Text.Trim().Length!=0)
				m_cmdOK.Enabled=true;
			else
				m_cmdOK.Enabled=false;
		}

		private void m_mthGetData(string p_strRoleID)
		{
			string SQL="select * from T_ROLE where ROLE_ID=" + p_strRoleID + "";
			DataTable dtRecords=null;

            com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ objServ =
                (com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.common.ICD10.Midtier.clsIllnessSymptomServ));

			objServ.m_lngGetMaxID(SQL,ref dtRecords);

			if(dtRecords!=null)
			{
				m_txtName.Text=dtRecords.Rows[0]["ROLE_NAME"].ToString();
				m_txtDesc.Text=dtRecords.Rows[0]["ROLE_DESC"].ToString();
			}
			dtRecords.Clear();
			dtRecords=null;

			SQL="select * from T_ROLEDETAIL where ROLE_ID=" + p_strRoleID + "";
			objServ.m_lngGetMaxID(SQL,ref m_dtFunction);
		}

		private void m_cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		public class clsNodeInfo
		{
			public string m_strCategoryName;
			public int m_intCategory;//0=全院,1=科室,2=病房,3=员工,4=病人
			public string m_strID;
			public string m_strName;
			//		public string m_strBeginDate;
			public clsDept_Desc m_objDeptDesc;
			public clsArea_Desc m_objAreaDesc;
			public clsNodeInfo m_objChildCategory=null;
			/// <summary>
			/// 获取描述
			/// </summary>
			/// <returns></returns>
			public override string ToString()
			{
				return m_objDeptDesc.m_strDeptName;
			}

		}
	}
}
