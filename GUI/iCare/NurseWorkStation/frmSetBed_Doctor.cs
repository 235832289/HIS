using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCare;
using iCareData;

namespace iCare
{
	/// <summary>
	/// frmSetBed_Doctor 的摘要说明。
	/// </summary>
	public class frmSetBed_Doctor : System.Windows.Forms.Form
	{
		private clsBedCardManageDomain m_objDomain;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ListView m_lsvBedInfo;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ContextMenu m_ctmMain;
		private System.Windows.Forms.TreeView m_trvResult;
		private PinkieControls.ButtonXP m_cmdAddBed;
		private System.Windows.Forms.CheckedListBox m_chkDoc;
		private PinkieControls.ButtonXP m_cmdAddDoc;
		private PinkieControls.ButtonXP m_cmdSave;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.MenuItem mniAdd;
		private PinkieControls.ButtonXP m_cmdReturn;

		/// <summary>
		/// 科室ID
		/// </summary>
		private string m_strDeptID;
		private System.Windows.Forms.MenuItem mniClear;
		/// <summary>
		/// 病区ID
		/// </summary>
		private string m_strAreaID;

		public frmSetBed_Doctor(string p_strAreaID,string p_strDeptID)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			m_objDomain = new clsBedCardManageDomain();
			m_strDeptID = p_strDeptID;
			m_strAreaID = p_strAreaID;

			m_mthIniti();
			new clsSortTool().m_mthSetListViewSortable(m_lsvBedInfo);
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
			this.m_lsvBedInfo = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.m_ctmMain = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.mniClear = new System.Windows.Forms.MenuItem();
			this.m_cmdAddBed = new PinkieControls.ButtonXP();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_chkDoc = new System.Windows.Forms.CheckedListBox();
			this.m_trvResult = new System.Windows.Forms.TreeView();
			this.m_cmdAddDoc = new PinkieControls.ButtonXP();
			this.m_cmdSave = new PinkieControls.ButtonXP();
			this.m_cmdReturn = new PinkieControls.ButtonXP();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_lsvBedInfo
			// 
			this.m_lsvBedInfo.CheckBoxes = true;
			this.m_lsvBedInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.columnHeader1,
																						   this.columnHeader2});
			this.m_lsvBedInfo.ContextMenu = this.m_ctmMain;
			this.m_lsvBedInfo.FullRowSelect = true;
			this.m_lsvBedInfo.GridLines = true;
			this.m_lsvBedInfo.Location = new System.Drawing.Point(4, 8);
			this.m_lsvBedInfo.Name = "m_lsvBedInfo";
			this.m_lsvBedInfo.Size = new System.Drawing.Size(160, 396);
			this.m_lsvBedInfo.TabIndex = 0;
			this.m_lsvBedInfo.View = System.Windows.Forms.View.Details;
			this.m_lsvBedInfo.DoubleClick += new System.EventHandler(this.m_lsvBedInfo_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "床位名称";
			this.columnHeader1.Width = 69;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "在床患者";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader2.Width = 75;
			// 
			// m_ctmMain
			// 
			this.m_ctmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mniAdd,
																					  this.mniDelete,
																					  this.mniClear});
			// 
			// mniAdd
			// 
			this.mniAdd.Index = 0;
			this.mniAdd.Text = "添加(&A)";
			this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
			// 
			// mniDelete
			// 
			this.mniDelete.Index = 1;
			this.mniDelete.Text = "删除(&D)";
			this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
			// 
			// mniClear
			// 
			this.mniClear.Index = 2;
			this.mniClear.Text = "清除(&C)";
			this.mniClear.Click += new System.EventHandler(this.mniClear_Click);
			// 
			// m_cmdAddBed
			// 
			this.m_cmdAddBed.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdAddBed.DefaultScheme = true;
			this.m_cmdAddBed.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdAddBed.Hint = "";
			this.m_cmdAddBed.Location = new System.Drawing.Point(168, 104);
			this.m_cmdAddBed.Name = "m_cmdAddBed";
			this.m_cmdAddBed.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdAddBed.Size = new System.Drawing.Size(24, 124);
			this.m_cmdAddBed.TabIndex = 1;
			this.m_cmdAddBed.Text = ">>";
			this.m_cmdAddBed.Click += new System.EventHandler(this.m_cmdAddBed_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_chkDoc);
			this.groupBox1.Controls.Add(this.m_trvResult);
			this.groupBox1.Controls.Add(this.m_lsvBedInfo);
			this.groupBox1.Controls.Add(this.m_cmdAddBed);
			this.groupBox1.Controls.Add(this.m_cmdAddDoc);
			this.groupBox1.Controls.Add(this.m_cmdSave);
			this.groupBox1.Controls.Add(this.m_cmdReturn);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(550, 411);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			// 
			// m_chkDoc
			// 
			this.m_chkDoc.CheckOnClick = true;
			this.m_chkDoc.Location = new System.Drawing.Point(388, 8);
			this.m_chkDoc.Name = "m_chkDoc";
			this.m_chkDoc.Size = new System.Drawing.Size(160, 400);
			this.m_chkDoc.TabIndex = 4;
			this.m_chkDoc.DoubleClick += new System.EventHandler(this.m_chkDoc_DoubleClick);
			// 
			// m_trvResult
			// 
			this.m_trvResult.CheckBoxes = true;
			this.m_trvResult.ContextMenu = this.m_ctmMain;
			this.m_trvResult.ImageIndex = -1;
			this.m_trvResult.Location = new System.Drawing.Point(196, 8);
			this.m_trvResult.Name = "m_trvResult";
			this.m_trvResult.SelectedImageIndex = -1;
			this.m_trvResult.Size = new System.Drawing.Size(160, 360);
			this.m_trvResult.TabIndex = 3;
			this.m_trvResult.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.m_trvResult_AfterCheck);
			this.m_trvResult.DoubleClick += new System.EventHandler(this.m_trvResult_DoubleClick);
			// 
			// m_cmdAddDoc
			// 
			this.m_cmdAddDoc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdAddDoc.DefaultScheme = true;
			this.m_cmdAddDoc.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdAddDoc.Hint = "";
			this.m_cmdAddDoc.Location = new System.Drawing.Point(360, 104);
			this.m_cmdAddDoc.Name = "m_cmdAddDoc";
			this.m_cmdAddDoc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdAddDoc.Size = new System.Drawing.Size(24, 124);
			this.m_cmdAddDoc.TabIndex = 1;
			this.m_cmdAddDoc.Text = "<<";
			this.m_cmdAddDoc.Click += new System.EventHandler(this.m_cmdAddDoc_Click);
			// 
			// m_cmdSave
			// 
			this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdSave.DefaultScheme = true;
			this.m_cmdSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdSave.Hint = "";
			this.m_cmdSave.Location = new System.Drawing.Point(196, 376);
			this.m_cmdSave.Name = "m_cmdSave";
			this.m_cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdSave.Size = new System.Drawing.Size(64, 28);
			this.m_cmdSave.TabIndex = 1;
			this.m_cmdSave.Text = "保  存";
			this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
			// 
			// m_cmdReturn
			// 
			this.m_cmdReturn.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdReturn.DefaultScheme = true;
			this.m_cmdReturn.DialogResult = System.Windows.Forms.DialogResult.Abort;
			this.m_cmdReturn.Hint = "";
			this.m_cmdReturn.Location = new System.Drawing.Point(292, 376);
			this.m_cmdReturn.Name = "m_cmdReturn";
			this.m_cmdReturn.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdReturn.Size = new System.Drawing.Size(64, 28);
			this.m_cmdReturn.TabIndex = 1;
			this.m_cmdReturn.Text = "返  回";
			this.m_cmdReturn.Click += new System.EventHandler(this.m_cmdReturn_Click);
			// 
			// frmSetBed_Doctor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.CancelButton = this.m_cmdReturn;
			this.ClientSize = new System.Drawing.Size(550, 411);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "frmSetBed_Doctor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "管床设置";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 初始化信息
		/// </summary>
		private void m_mthIniti()
		{
			//添加床位
			if(m_strAreaID != null)
			{
				clsBed_PatientInfo[] objInfoArr = null;
				m_objDomain.m_lngGetBedInfoByAreaID(m_strAreaID,out objInfoArr);
				if(objInfoArr == null)
					return;
				this.m_lsvBedInfo.BeginUpdate();
				for(int i=0;i<objInfoArr.Length;i++)
				{
					ListViewItem item = new ListViewItem(new string[]{objInfoArr[i].m_strBedName,objInfoArr[i].m_strInPatientName});
					item.Tag = objInfoArr[i];
					this.m_lsvBedInfo.Items.Add(item);
				}
				this.m_lsvBedInfo.EndUpdate();
			}
			//添加管床医生
			if(m_strDeptID != null)
			{
				clsEmployee[] objEmployeeArr = new clsEmployeeManager().m_objGetEmployeeByDeptID(m_strDeptID);
				if(objEmployeeArr == null)
					return;
				m_chkDoc.Items.AddRange(objEmployeeArr);
			}
			m_mthSetResult();
		}
		private void m_mthSetResult()
		{
			//设置床位－医生对应
			if(m_strAreaID == null || m_strAreaID == "")
				return;
			clsBed_ManageDocValue[] objBed_DocArr = null;
			m_objDomain.m_lngGetBed_ManageDoc(m_strAreaID,out objBed_DocArr);
			if(objBed_DocArr == null)
				return;
			m_trvResult.BeginUpdate();
			for(int j2=0;j2<objBed_DocArr.Length;j2++)
			{
				for(int k3=0;k3<m_chkDoc.Items.Count;k3++)
				{
					if(((clsEmployee)m_chkDoc.Items[k3]).m_StrEmployeeID.Trim() == objBed_DocArr[j2].m_strManageDocID)
					{
						m_mthSetDoc((clsEmployee)m_chkDoc.Items[k3]);
						break;
					}
				}
				for(int m4=0;m4<objBed_DocArr[j2].m_strBedIDArr.Length;m4++)
				{
					for(int n5=0;n5<m_lsvBedInfo.Items.Count;n5++)
					{
						if(((clsBed_PatientInfo)(m_lsvBedInfo.Items[n5].Tag)).m_strBedID == objBed_DocArr[j2].m_strBedIDArr[m4])
						{
							m_mthSetBed(m_lsvBedInfo.Items[n5]);
							break;
						}
					}
				}
			}
			m_trvResult.ExpandAll();
			m_trvResult.EndUpdate();
		}

		/// <summary>
		/// 添加床位到关系结果集
		/// </summary>
		/// <param name="p_objItem"></param>
		private void m_mthSetBed(ListViewItem p_objItem)
		{
			TreeNode node = new TreeNode(p_objItem.Text);
			node.Tag = p_objItem;
			node.Checked = true;
			node.ForeColor = Color.Green;
			if(m_trvResult.SelectedNode.Tag is ListViewItem)
			{
				m_trvResult.SelectedNode.Parent.Nodes.Add(node);
				m_trvResult.SelectedNode.Parent.Expand();
			}
			else
			{
				m_trvResult.SelectedNode.Nodes.Add(node);
				m_trvResult.SelectedNode.Expand();
			}
			m_lsvBedInfo.Items.Remove(p_objItem);
		}
		/// <summary>
		/// 添加管床医生到关系结果集
		/// </summary>
		/// <param name="p_objEmployee"></param>
		private void m_mthSetDoc(clsEmployee p_objEmployee)
		{
			if(p_objEmployee == null)
				return;
			TreeNode node = new TreeNode(p_objEmployee.ToString());
			node.Tag = p_objEmployee;
			node.Checked = true;
			node.ForeColor = Color.Blue;
			if(!m_trvResult.Nodes.Contains(node))
			{
				m_trvResult.Nodes.Add(node);
			}
			m_trvResult.SelectedNode = node;
			m_chkDoc.Items.Remove(p_objEmployee);
		}
		/// <summary>
		/// 清除关系结果集
		/// </summary>
		/// <param name="p_trnNode"></param>
		private void m_mthSetResult(TreeNode p_trnNode)
		{
			ListViewItem item = p_trnNode.Tag as ListViewItem;
			clsEmployee objEmployee =  p_trnNode.Tag as clsEmployee;
			if(item != null)
			{
				if(!m_lsvBedInfo.Items.Contains(item))
					m_lsvBedInfo.Items.Add(item);
			}
			else if(objEmployee != null)
			{
				foreach(TreeNode node in p_trnNode.Nodes)
				{
					m_mthSetResult(node);
				}
				m_chkDoc.Items.Add(objEmployee);
			}
			if(p_trnNode != null)
				p_trnNode.Remove();
		}

		#region Event
		private void m_lsvBedInfo_DoubleClick(object sender, System.EventArgs e)
		{
			if(m_lsvBedInfo.SelectedItems.Count <= 0)
			{
				return;
			}
			if(m_trvResult.Nodes.Count <= 0 || m_trvResult.SelectedNode == null)
			{
				clsPublicFunction.ShowInformationMessageBox("请先添加管床医生！");
				return;
			}
			m_mthSetBed(m_lsvBedInfo.SelectedItems[0]);
		}
		private void m_chkDoc_DoubleClick(object sender, System.EventArgs e)
		{
			if(m_chkDoc.SelectedItems.Count <= 0)
				return;
			m_mthSetDoc((clsEmployee)(m_chkDoc.SelectedItems[0]));
		}

		private void m_trvResult_DoubleClick(object sender, System.EventArgs e)
		{
			if(m_trvResult.SelectedNode == null)
				return;
			m_mthSetResult(m_trvResult.SelectedNode);
		}

		private void m_cmdAddBed_Click(object sender, System.EventArgs e)
		{
			if(m_trvResult.Nodes.Count <= 0 || m_trvResult.SelectedNode == null)
			{
				clsPublicFunction.ShowInformationMessageBox("请先添加管床医生！");
				return;
			}
			foreach(ListViewItem item in m_lsvBedInfo.CheckedItems)
			{
				m_mthSetBed(item);
			}
		}

		private void m_cmdAddDoc_Click(object sender, System.EventArgs e)
		{
			for(int i=0;i<m_chkDoc.Items.Count;i++)
			{
				if(m_chkDoc.GetItemChecked(i))
				{
					m_mthSetDoc((clsEmployee)(m_chkDoc.Items[i]));
				}
			}
		}

		private void m_cmdSave_Click(object sender, System.EventArgs e)
		{
			if(m_trvResult.Nodes.Count <= 0)
			{
				clsPublicFunction.ShowInformationMessageBox("未有结果集，至少需要一对床位-医生对应！");
				return;
			}
			m_objDomain.m_lngDeleteBed_ManageDo(m_strAreaID);
			for(int i=0;i<m_trvResult.Nodes.Count;i++)
			{
				if(m_trvResult.Nodes[i].Checked == false || m_trvResult.Nodes[i].Nodes.Count <= 0)
					continue;
				clsEmployee objEmployee = m_trvResult.Nodes[i].Tag as clsEmployee;
				if(objEmployee == null)
					continue;
				for(int j2=0;j2<m_trvResult.Nodes[i].Nodes.Count;j2++)
				{
					clsBed_PatientInfo objBedInfo = ((ListViewItem)(m_trvResult.Nodes[i].Nodes[j2].Tag)).Tag as clsBed_PatientInfo;
					if(objBedInfo == null)
						continue;
					m_objDomain.m_lngAddBed_ManageDoc(objBedInfo.m_strBedID,objEmployee.m_StrEmployeeID,m_strAreaID);
					m_trvResult.Nodes[i].Nodes[j2].Checked = false;
				}
				m_trvResult.Nodes[i].Checked = false;
			}
		}

		private void m_trvResult_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(e.Node.Checked == false)
				e.Node.ForeColor = Color.Gray;
			else
			{
				if(e.Node.Tag is ListViewItem)
					e.Node.ForeColor = Color.Green;
				else
					e.Node.ForeColor = Color.Blue;
			}
		}

		private void mniClear_Click(object sender, System.EventArgs e)
		{
			ListView lstView = mniClear.GetContextMenu().SourceControl as ListView;
			CheckedListBox chkList = mniClear.GetContextMenu().SourceControl as CheckedListBox;
			if(lstView != null)
			{
				foreach(ListViewItem item in lstView.CheckedItems)
				{
					item.Checked = false;
				}
			}
			else if(chkList != null)
			{
				for(int i=0;i<chkList.Items.Count;i++)
				{
					chkList.SetItemChecked(i,false);
				}
			}
		}

		private void mniDelete_Click(object sender, System.EventArgs e)
		{
			if(m_trvResult.SelectedNode == null)
				return;
			m_mthSetResult(m_trvResult.SelectedNode);
		}

		private void mniAdd_Click(object sender, System.EventArgs e)
		{
			ListView lstView = mniClear.GetContextMenu().SourceControl as ListView;
			CheckedListBox chkList = mniClear.GetContextMenu().SourceControl as CheckedListBox;
			if(lstView != null)
			{
				m_cmdAddBed.PerformClick();
			}
			else if(chkList != null)
				m_cmdAddDoc.PerformClick();
		}

		private void m_cmdReturn_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			frmCaseGrade frm = new frmCaseGrade();
			frm.Show();
		}
	}
}
