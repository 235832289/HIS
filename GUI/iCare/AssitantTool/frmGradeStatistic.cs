using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using iCareData;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;

namespace iCare
{
	/// <summary>
	/// frmGradeStatistic 的摘要说明。
	/// </summary>
	public class frmGradeStatistic : iCareBaseForm.frmBaseForm
	{
		/// <summary>
		/// 部门中间层对象
		/// </summary>
		private clsDepartmentManager m_objDepartmentManager=new clsDepartmentManager();
		private clsCaseGradeDomain m_objDomain ;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker m_dtpSeachDate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox m_cboDept;
		private System.Windows.Forms.ComboBox m_cboArea;
		private PinkieControls.ButtonXP m_cndFind;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TreeView m_trvPatient;
		private System.Windows.Forms.Label label5;
		private com.digitalwave.Utility.Controls.CollapsibleSplitter collapsibleSplitter1;
		private System.Windows.Forms.ListView m_lsvDitail;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ListBox m_lstDetail;
		private System.Windows.Forms.DateTimePicker m_dtpSeachDate2;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.ComponentModel.IContainer components;

		public frmGradeStatistic()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			m_objDomain = new clsCaseGradeDomain();
			m_mthInitilize();
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGradeStatistic));
			this.m_cboDept = new System.Windows.Forms.ComboBox();
			this.m_cboArea = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_dtpSeachDate = new System.Windows.Forms.DateTimePicker();
			this.m_cndFind = new PinkieControls.ButtonXP();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.m_lsvDitail = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.m_lstDetail = new System.Windows.Forms.ListBox();
			this.collapsibleSplitter1 = new com.digitalwave.Utility.Controls.CollapsibleSplitter();
			this.m_trvPatient = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.m_dtpSeachDate2 = new System.Windows.Forms.DateTimePicker();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_cboDept
			// 
			this.m_cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboDept.Location = new System.Drawing.Point(76, 14);
			this.m_cboDept.Name = "m_cboDept";
			this.m_cboDept.Size = new System.Drawing.Size(128, 22);
			this.m_cboDept.TabIndex = 0;
			this.m_cboDept.SelectedIndexChanged += new System.EventHandler(this.m_cboDept_SelectedIndexChanged);
			// 
			// m_cboArea
			// 
			this.m_cboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboArea.Location = new System.Drawing.Point(260, 14);
			this.m_cboArea.Name = "m_cboArea";
			this.m_cboArea.Size = new System.Drawing.Size(128, 22);
			this.m_cboArea.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(28, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "科室:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(212, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "病区:";
			// 
			// m_dtpSeachDate
			// 
			this.m_dtpSeachDate.Location = new System.Drawing.Point(420, 12);
			this.m_dtpSeachDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
			this.m_dtpSeachDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
			this.m_dtpSeachDate.Name = "m_dtpSeachDate";
			this.m_dtpSeachDate.Size = new System.Drawing.Size(124, 23);
			this.m_dtpSeachDate.TabIndex = 2;
			// 
			// m_cndFind
			// 
			this.m_cndFind.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cndFind.DefaultScheme = true;
			this.m_cndFind.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cndFind.Hint = "";
			this.m_cndFind.Location = new System.Drawing.Point(704, 9);
			this.m_cndFind.Name = "m_cndFind";
			this.m_cndFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cndFind.Size = new System.Drawing.Size(68, 28);
			this.m_cndFind.TabIndex = 3;
			this.m_cndFind.Text = "查找";
			this.m_cndFind.Click += new System.EventHandler(this.m_cndFind_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(400, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(20, 19);
			this.label3.TabIndex = 1;
			this.label3.Text = "自";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(548, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(20, 19);
			this.label4.TabIndex = 1;
			this.label4.Text = "至";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.m_lsvDitail);
			this.panel1.Controls.Add(this.m_lstDetail);
			this.panel1.Controls.Add(this.collapsibleSplitter1);
			this.panel1.Controls.Add(this.m_trvPatient);
			this.panel1.Location = new System.Drawing.Point(24, 48);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(740, 560);
			this.panel1.TabIndex = 4;
			// 
			// m_lsvDitail
			// 
			this.m_lsvDitail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.columnHeader1,
																						  this.columnHeader2,
																						  this.columnHeader3,
																						  this.columnHeader6,
																						  this.columnHeader5,
																						  this.columnHeader4});
			this.m_lsvDitail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lsvDitail.FullRowSelect = true;
			this.m_lsvDitail.Location = new System.Drawing.Point(204, 0);
			this.m_lsvDitail.Name = "m_lsvDitail";
			this.m_lsvDitail.Size = new System.Drawing.Size(536, 560);
			this.m_lsvDitail.TabIndex = 1;
			this.m_lsvDitail.View = System.Windows.Forms.View.Details;
			this.m_lsvDitail.DoubleClick += new System.EventHandler(this.m_lsvDitail_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "住院号";
			this.columnHeader1.Width = 66;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "姓名";
			this.columnHeader2.Width = 66;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "床位";
			this.columnHeader3.Width = 40;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "住院日期";
			this.columnHeader6.Width = 120;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "评级";
			this.columnHeader4.Width = 66;
			// 
			// m_lstDetail
			// 
			this.m_lstDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lstDetail.HorizontalScrollbar = true;
			this.m_lstDetail.ItemHeight = 14;
			this.m_lstDetail.Location = new System.Drawing.Point(204, 0);
			this.m_lstDetail.Name = "m_lstDetail";
			this.m_lstDetail.Size = new System.Drawing.Size(536, 550);
			this.m_lstDetail.TabIndex = 3;
			// 
			// collapsibleSplitter1
			// 
			this.collapsibleSplitter1.AnimationDelay = 20;
			this.collapsibleSplitter1.AnimationStep = 20;
			this.collapsibleSplitter1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.collapsibleSplitter1.BorderStyle3D = System.Windows.Forms.Border3DStyle.RaisedInner;
			this.collapsibleSplitter1.ControlToHide = this.m_trvPatient;
			this.collapsibleSplitter1.ExpandParentForm = false;
			this.collapsibleSplitter1.Location = new System.Drawing.Point(196, 0);
			this.collapsibleSplitter1.Name = "collapsibleSplitter1";
			this.collapsibleSplitter1.Size = new System.Drawing.Size(8, 560);
			this.collapsibleSplitter1.TabIndex = 2;
			this.collapsibleSplitter1.TabStop = false;
			this.collapsibleSplitter1.UseAnimations = false;
			this.collapsibleSplitter1.VisualStyle = com.digitalwave.Utility.Controls.VisualStyles.XP;
			// 
			// m_trvPatient
			// 
			this.m_trvPatient.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_trvPatient.ImageList = this.imageList1;
			this.m_trvPatient.Location = new System.Drawing.Point(0, 0);
			this.m_trvPatient.Name = "m_trvPatient";
			this.m_trvPatient.Size = new System.Drawing.Size(196, 560);
			this.m_trvPatient.TabIndex = 0;
			this.m_trvPatient.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trvPatient_AfterSelect);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label5.Location = new System.Drawing.Point(20, 44);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(748, 4);
			this.label5.TabIndex = 1;
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label6.Location = new System.Drawing.Point(764, 48);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(4, 560);
			this.label6.TabIndex = 1;
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label7.Location = new System.Drawing.Point(20, 48);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(4, 560);
			this.label7.TabIndex = 1;
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label8.Location = new System.Drawing.Point(20, 608);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(748, 4);
			this.label8.TabIndex = 1;
			// 
			// m_dtpSeachDate2
			// 
			this.m_dtpSeachDate2.Location = new System.Drawing.Point(572, 12);
			this.m_dtpSeachDate2.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
			this.m_dtpSeachDate2.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
			this.m_dtpSeachDate2.Name = "m_dtpSeachDate2";
			this.m_dtpSeachDate2.Size = new System.Drawing.Size(124, 23);
			this.m_dtpSeachDate2.TabIndex = 2;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "主治医生";
			this.columnHeader5.Width = 80;
			// 
			// frmGradeStatistic
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(792, 623);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.m_cndFind);
			this.Controls.Add(this.m_dtpSeachDate);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_cboDept);
			this.Controls.Add(this.m_cboArea);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.m_dtpSeachDate2);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.Name = "frmGradeStatistic";
			this.Text = "病历质量统计";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void m_mthInitilize()
		{
			clsDepartment[] objDeptArr;
			objDeptArr=	m_objDepartmentManager.m_objGetAllInDeptArr();		
			if(objDeptArr !=null)
			{
				m_cboDept.Items.Clear();
				for(int i=0;i<objDeptArr.Length;i++)
				{
					if(objDeptArr[i].m_StrDeptName != "")
						m_cboDept.Items.Add(objDeptArr[i]);
				}
			}
			if(m_cboDept.Items.Count > 0)
				m_cboDept.SelectedIndex = 0;
			m_dtpSeachDate.Value.AddMonths(-1);
		}
		private void m_cboDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.Cursor=Cursors.WaitCursor;
			this.m_cboArea.Items.Clear();
			clsInPatientArea[] objAreaArr;
			m_objDepartmentManager.m_lngGetAllAreaInDept(((clsDepartment)(this.m_cboDept.SelectedItem)).m_StrDeptID,out objAreaArr);
			if(objAreaArr !=null)
			{	
				this.m_cboArea.Items.AddRange(objAreaArr);
				this.m_cboArea.SelectedIndex = 0;
			}			
			this.Cursor=Cursors.Default;
		}

		private void m_cndFind_Click(object sender, System.EventArgs e)
		{
			clsCaseGradeValue[] objGradeValueArr;
			if(m_cboDept.SelectedItem == null /*|| m_cboArea.SelectedItem == null*/)
			{
				clsPublicFunction.ShowInformationMessageBox("请先选择科室！");
				return;
			}

            long lngRes = 0;
            if (m_cboArea.Items.Count > 0)
            {
                if (m_cboArea.SelectedItem == null)
                {
                    clsPublicFunction.ShowInformationMessageBox("请先选择病区！");
                    return;
                }
                lngRes = m_objDomain.m_lngGetGradeInfoByArea(((clsInPatientArea)m_cboArea.SelectedItem).m_StrAreaID_CHR, m_dtpSeachDate.Value, m_dtpSeachDate2.Value, out objGradeValueArr);
            }
            else
            {
                lngRes = m_objDomain.m_lngGetGradeInfoByDept(((clsDepartment)m_cboDept.SelectedItem).m_StrDeptID, m_dtpSeachDate.Value, m_dtpSeachDate2.Value, out objGradeValueArr);
            }

			if(lngRes <=0 || objGradeValueArr == null)
				return;

			m_trvPatient.BeginUpdate();
			m_trvPatient.Nodes.Clear();

            TreeNode node = null;
            if (m_cboArea.Items.Count > 0)
            {
                node = new TreeNode(m_cboArea.SelectedItem.ToString());
                node.Tag = (clsInPatientArea)m_cboArea.SelectedItem;
            }
            else
            {
                node = new TreeNode(m_cboDept.SelectedItem.ToString());
                node.Tag = (clsDepartment)m_cboDept.SelectedItem;
            }

			node.ImageIndex = 0;
			for(int i=0;i<objGradeValueArr.Length;i++)
			{
				TreeNode trnChild = new TreeNode(objGradeValueArr[i].m_strInPatientID);
				trnChild.Tag = objGradeValueArr[i];
				trnChild.ImageIndex = 1;
				trnChild.SelectedImageIndex = 1;
				node.Nodes.Add(trnChild);
			}
			m_trvPatient.Nodes.Add(node);
			m_trvPatient.SelectedNode = node;
			m_trvPatient.ExpandAll();
			m_trvPatient.EndUpdate();
		}

		private void m_trvPatient_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(m_trvPatient.SelectedNode == null)
				return;
			if((m_trvPatient.SelectedNode.Tag is clsInPatientArea || m_trvPatient.SelectedNode.Tag is clsDepartment)
                && m_trvPatient.SelectedNode.Nodes.Count > 0)
			{
				m_lsvDitail.BeginUpdate();
				m_lsvDitail.Visible = true;
				m_lstDetail.Visible = false;
				m_lsvDitail.Items.Clear();
				foreach(TreeNode node in m_trvPatient.SelectedNode.Nodes)
				{
					clsCaseGradeValue objGradeValue = node.Tag as clsCaseGradeValue;
                    if (objGradeValue == null)
                        continue;

					clsPatient objPatient = new clsPatient(objGradeValue.m_strInPatientID);
					string strGrade = "";
					//					string strCount = "";
					for(int i=0;i<objGradeValue.m_objItemValueArr.Length;i++)
					{
						if(objGradeValue.m_objItemValueArr[i].m_strItemID == "m_txtAllResult")
						{
							strGrade = objGradeValue.m_objItemValueArr[i].m_strItemContent;
							break;
						}
					}
					clsBedCardValue objBedCardValue = new clsBedCardValue();
					objBedCardValue.m_strInPatientID = objGradeValue.m_strInPatientID;
					objBedCardValue.m_strInPatientDate = objGradeValue.m_strInPatientDate;
					new clsBedCardManageDomain().m_lngGetBedCardValue(ref objBedCardValue);
					string strChargeDoc = objBedCardValue.m_strDoc_InCharge == null?"":new clsEmployee(objBedCardValue.m_strDoc_InCharge.Trim()).m_StrFirstName;
					ListViewItem item = new ListViewItem(new string[]{objGradeValue.m_strInPatientID,objPatient.m_StrName,objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(DateTime.Parse(objGradeValue.m_strInPatientDate)).m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName,objGradeValue.m_strInPatientDate,strChargeDoc,strGrade});
					item.Tag = objGradeValue;
					m_lsvDitail.Items.Add(item);
				}
				m_lsvDitail.EndUpdate();
			}
			else if(m_trvPatient.SelectedNode.Tag is clsCaseGradeValue)
			{
				
				clsCaseGradeValue objGradeValue2 = m_trvPatient.SelectedNode.Tag as clsCaseGradeValue;
				m_mthSetItem(objGradeValue2);

			}
		}

		private void m_lsvDitail_DoubleClick(object sender, System.EventArgs e)
		{
			if(m_lsvDitail.SelectedItems.Count <=0)
				return;
			clsCaseGradeValue objGradeValue = m_lsvDitail.SelectedItems[0].Tag as clsCaseGradeValue;
			m_mthSetItem(objGradeValue);
		}
		private void m_mthSetItem(clsCaseGradeValue p_objGradeValue)
		{
			m_lstDetail.BeginUpdate();
			m_lsvDitail.Visible = false;
			m_lstDetail.Visible = true;
			m_lstDetail.Items.Clear();
			for(int j2 =0;j2<p_objGradeValue.m_objItemValueArr.Length;j2++)
			{
				if(p_objGradeValue.m_objItemValueArr[j2].m_strDescription != null)
					if(p_objGradeValue.m_objItemValueArr[j2].m_strDescription != "")
					{
						string str = p_objGradeValue.m_objItemValueArr[j2].m_strDescription + "(";
						try
						{
							float.Parse(p_objGradeValue.m_objItemValueArr[j2].m_strItemContent);
							str += "扣分：" +p_objGradeValue.m_objItemValueArr[j2].m_strItemContent + "分)";
						}
						catch
						{
							str += p_objGradeValue.m_objItemValueArr[j2].m_strItemContent + ")";
						}
						m_lstDetail.Items.Add(str);
					}
			}
			m_lstDetail.EndUpdate();
		}


	}
}
