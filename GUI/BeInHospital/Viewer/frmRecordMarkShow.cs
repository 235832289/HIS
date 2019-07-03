using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using System.Text;
using System.Xml;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class frmRecordMarkShow  :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.ColumnHeader columnHeader2;
		public System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dateEnd;
		private System.Windows.Forms.DateTimePicker dateStar;
		private PinkieControls.ButtonXP buttonXP1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.ColumnHeader ColumnHeader;
		private System.Windows.Forms.ColumnHeader Col;
		private System.Windows.Forms.ListView listView3;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private PinkieControls.ButtonXP buttonXP2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRecordMarkShow()
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
				if (components != null) 
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
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.panel1 = new System.Windows.Forms.Panel();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.buttonXP2 = new PinkieControls.ButtonXP();
			this.buttonXP1 = new PinkieControls.ButtonXP();
			this.label2 = new System.Windows.Forms.Label();
			this.dateEnd = new System.Windows.Forms.DateTimePicker();
			this.dateStar = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.listView3 = new System.Windows.Forms.ListView();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.listView2 = new System.Windows.Forms.ListView();
			this.ColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.Col = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "操作时间";
			this.columnHeader2.Width = 150;
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.listView1.BackColor = System.Drawing.Color.LemonChiffon;
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3,
																						this.columnHeader4});
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.Location = new System.Drawing.Point(4, 48);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(460, 552);
			this.listView1.TabIndex = 3;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "操作人";
			this.columnHeader1.Width = 80;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "操作表名";
			this.columnHeader3.Width = 150;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "操作类型";
			this.columnHeader4.Width = 80;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.buttonXP2);
			this.panel1.Controls.Add(this.buttonXP1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.dateEnd);
			this.panel1.Controls.Add(this.dateStar);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(4, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(968, 48);
			this.panel1.TabIndex = 2;
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Items.AddRange(new object[] {
														   "全部药品"});
			this.comboBox1.Location = new System.Drawing.Point(776, 13);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(176, 22);
			this.comboBox1.TabIndex = 6;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// buttonXP2
			// 
			this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.buttonXP2.DefaultScheme = true;
			this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonXP2.Hint = "";
			this.buttonXP2.Location = new System.Drawing.Point(648, 4);
			this.buttonXP2.Name = "buttonXP2";
			this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.buttonXP2.Size = new System.Drawing.Size(96, 40);
			this.buttonXP2.TabIndex = 5;
			this.buttonXP2.Text = "退出(&ESC)";
			this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
			// 
			// buttonXP1
			// 
			this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.buttonXP1.DefaultScheme = true;
			this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
			this.buttonXP1.Hint = "";
			this.buttonXP1.Location = new System.Drawing.Point(512, 4);
			this.buttonXP1.Name = "buttonXP1";
			this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.buttonXP1.Size = new System.Drawing.Size(96, 40);
			this.buttonXP1.TabIndex = 4;
			this.buttonXP1.Text = "查询(&F)";
			this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(256, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "到";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dateEnd
			// 
			this.dateEnd.Location = new System.Drawing.Point(304, 13);
			this.dateEnd.Name = "dateEnd";
			this.dateEnd.Size = new System.Drawing.Size(120, 23);
			this.dateEnd.TabIndex = 2;
			// 
			// dateStar
			// 
			this.dateStar.Location = new System.Drawing.Point(136, 13);
			this.dateStar.Name = "dateStar";
			this.dateStar.Size = new System.Drawing.Size(120, 23);
			this.dateStar.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(56, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "操作日期";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.listView3);
			this.panel2.Controls.Add(this.listView2);
			this.panel2.Location = new System.Drawing.Point(472, 48);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(504, 552);
			this.panel2.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label4.BackColor = System.Drawing.SystemColors.Control;
			this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.ForeColor = System.Drawing.Color.Red;
			this.label4.Location = new System.Drawing.Point(16, 416);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(480, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "操作条件";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label3.BackColor = System.Drawing.SystemColors.Control;
			this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(16, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(480, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "操作字段";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// listView3
			// 
			this.listView3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listView3.BackColor = System.Drawing.SystemColors.Window;
			this.listView3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader5,
																						this.columnHeader7,
																						this.columnHeader6,
																						this.columnHeader9});
			this.listView3.GridLines = true;
			this.listView3.Location = new System.Drawing.Point(16, 440);
			this.listView3.Name = "listView3";
			this.listView3.Size = new System.Drawing.Size(480, 112);
			this.listView3.TabIndex = 1;
			this.listView3.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "字段";
			this.columnHeader5.Width = 120;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "条件";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "值";
			this.columnHeader6.Width = 130;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "备注";
			this.columnHeader9.Width = 220;
			// 
			// listView2
			// 
			this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listView2.BackColor = System.Drawing.SystemColors.Window;
			this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.ColumnHeader,
																						this.Col,
																						this.columnHeader10,
																						this.columnHeader8});
			this.listView2.GridLines = true;
			this.listView2.Location = new System.Drawing.Point(16, 32);
			this.listView2.Name = "listView2";
			this.listView2.Size = new System.Drawing.Size(480, 384);
			this.listView2.TabIndex = 0;
			this.listView2.View = System.Windows.Forms.View.Details;
			// 
			// ColumnHeader
			// 
			this.ColumnHeader.Text = "字段";
			this.ColumnHeader.Width = 170;
			// 
			// Col
			// 
			this.Col.Text = "值";
			this.Col.Width = 150;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "备注";
			this.columnHeader8.Width = 180;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "旧值";
			this.columnHeader10.Width = 100;
			// 
			// frmRecordMarkShow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.CancelButton = this.buttonXP2;
			this.ClientSize = new System.Drawing.Size(976, 605);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.MaximizeBox = false;
			this.Name = "frmRecordMarkShow";
			this.Text = "数据库操作痕迹记录";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmRecordMarkShow());
		}
		clsDomailControlRecordMark domailControl=new clsDomailControlRecordMark();
		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}
		clsRecordMark_VO[] p_objVO;
		private string strTable;
		public void m_mthShowMe(string strTable)
		{
			this.strTable=strTable;
			this.Show();
		}
		private void buttonXP1_Click(object sender, System.EventArgs e)
		{
			string strDateStar=dateStar.Value.ToShortDateString();
			string strDateEnd=dateEnd.Value.ToShortDateString();
			domailControl.m_objGetRecordMark(null,out p_objVO,strDateStar,strDateEnd,this.strTable);
			listView1.Items.Clear();
			comboBox1.Items.Clear();
			if(p_objVO.Length>0)
			{
				comboBox1.Items.Add("全部");
				for(int i1=0;i1<p_objVO.Length;i1++)
				{
					m_mthFillList(p_objVO[i1]);
					try
					{
						for(int f2=0;f2<comboBox1.Items.Count;f2++)
						{
							if(p_objVO[i1].m_objMarkFied[0].m_strFiedValues_CHR==comboBox1.Items[f2].ToString())
							{
								break;
							}
							if(f2==comboBox1.Items.Count-1)
							{
								comboBox1.Items.Add(p_objVO[i1].m_objMarkFied[0].m_strFiedValues_CHR);
							}
						}
					}
					catch
					{
					}
					
				}
				comboBox1.SelectedIndex=0;
			}
		}
		#region 填充列表
		/// <summary>
		/// 填充列表
		/// </summary>
		/// <param name="p_objVO"></param>
		private void m_mthFillList(clsRecordMark_VO p_objVO)
		{
			ListViewItem newItem=new ListViewItem(p_objVO.m_strOPERATORNAME_CHR);
			newItem.SubItems.Add(p_objVO.m_strOPERATE_DAT);
			newItem.SubItems.Add(p_objVO.m_strTABLENAME_VCHR);
			if(p_objVO.m_intTYPE_INT==0)
				newItem.SubItems.Add("新增");
			else if(p_objVO.m_intTYPE_INT==1)
			{
				newItem.SubItems.Add("修改");
			}
			else
				newItem.SubItems.Add("删除");
			newItem.Tag=p_objVO;
			listView1.Items.Add(newItem);
		}
		#endregion
		private void listView1_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
		
		}

		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			clsRecordMark_VO seleVO=new clsRecordMark_VO();
			if(this.listView1.SelectedItems.Count==0)
				return;
			seleVO=(clsRecordMark_VO)this.listView1.SelectedItems[0].Tag;
			listView2.Items.Clear();
			listView3.Items.Clear();
			if(seleVO.m_intTYPE_INT==1)
			{
				listView2.Columns[2].Width=100;
			}
			else
			{
				listView2.Columns[2].Width=0;
			}
			if(seleVO.m_objMarkFied!=null&&seleVO.m_objMarkFied.Length>0)
			{
				for(int i1=0;i1<seleVO.m_objMarkFied.Length;i1++)
				{
					seleVO.m_objMarkFied[i1].m_strFiedValues_CHR=seleVO.m_objMarkFied[i1].m_strFiedValues_CHR.Trim().Replace("'","");
					ListViewItem newItem=new ListViewItem(seleVO.m_objMarkFied[i1].m_strFiedName_VCHR.Trim());
					newItem.SubItems.Add(seleVO.m_objMarkFied[i1].m_strFiedValues_CHR.Trim());
					newItem.SubItems.Add(seleVO.m_objMarkFied[i1].m_strFiedValuesOLD_CHR.Trim());
					newItem.SubItems.Add(seleVO.m_objMarkFied[i1].m_strFiedComments_CHR.Trim());
					listView2.Items.Add(newItem);
					if(seleVO.m_intTYPE_INT==1)
					{
						if(seleVO.m_objMarkFied[i1].m_strFiedValues_CHR.Trim()!=seleVO.m_objMarkFied[i1].m_strFiedValuesOLD_CHR.Trim())
						{
							listView2.Items[listView2.Items.Count-1].BackColor=System.Drawing.Color.DarkKhaki;
						}
					}
				}
			}
			if(seleVO.m_objMarkWhere!=null&&seleVO.m_objMarkWhere.Length>0)
			{
				for(int i1=0;i1<seleVO.m_objMarkWhere.Length;i1++)
				{
					ListViewItem newItem=new ListViewItem(seleVO.m_objMarkWhere[i1].m_strFiedName_VCHR.Trim());
					newItem.SubItems.Add(seleVO.m_objMarkWhere[i1].m_strFiedCONDITION_CHR.Trim());
					newItem.SubItems.Add(seleVO.m_objMarkWhere[i1].m_strFiedValues_CHR.Trim());
					newItem.SubItems.Add(seleVO.m_objMarkWhere[i1].m_strFiedComments_CHR.Trim());
					listView3.Items.Add(newItem);
				}
			}
		}
		#region 把XML格式的字符串解析成所操作的值
		/// <summary>
		/// 把XML格式的字符串解析成所操作的值
		/// </summary>
		/// <param name="strXML">字符串</param>
		/// <param name="dtValues">返回数据库操作的值,delete语句为NULL</param>
		/// <param name="dtWhere">返回对数据库操作的条件,insert into语句为NULL</param>
		public void m_mthAnalyseXML(string strXML,out DataTable dtValues,out DataTable dtWhere)
		{
			dtValues=new DataTable();
			dtValues.Columns.Add("table_fied");
			dtValues.Columns.Add("values");
			dtWhere=new DataTable();
			dtWhere.Columns.Add("table_wherefied");
			dtWhere.Columns.Add("CONDITION");
			dtWhere.Columns.Add("wherevalues");
			if(strXML==null||strXML=="")
				return;
			XmlDocument doc=new XmlDocument();
			doc.LoadXml(strXML);
			try
			{
				if(!doc.HasChildNodes)
					return;
			}
			catch
			{
				return;
			}
			string str=doc.FirstChild.Name;
			XmlNode door=doc.FirstChild;
			if(door.HasChildNodes)
			{
				switch(door.Name)
				{
					case "INSERT":
						dtWhere=null;
						for(int i1=0;i1<door.ChildNodes.Count;i1++)
						{
							DataRow newRow=dtValues.NewRow();
							newRow["table_fied"]=door.ChildNodes[i1].Name;
							newRow["values"]=door.ChildNodes[i1].InnerText;
							dtValues.Rows.Add(newRow);
						}
						break;
					case "UPDATE":
						for(int i1=0;i1<door.ChildNodes.Count;i1++)
						{
							if(door.ChildNodes[i1].Name=="SET")
							{
								if(door.ChildNodes[i1].HasChildNodes)
								{
									for(int h1=0;h1<door.ChildNodes[i1].ChildNodes.Count;h1++)
									{
										DataRow newRow=dtValues.NewRow();
										newRow["table_fied"]=door.ChildNodes[i1].ChildNodes[h1].Name;
										newRow["values"]=door.ChildNodes[i1].ChildNodes[h1].InnerText;
										dtValues.Rows.Add(newRow);
									}
								}
							}
							if(door.ChildNodes[i1].Name=="WHERE")
							{
								if(door.ChildNodes[i1].HasChildNodes)
								{
									for(int f2=0;f2<door.ChildNodes[i1].ChildNodes.Count;f2++)
									{
										DataRow newRow=dtWhere.NewRow();
										for(int k1=0;k1<2;k1++)
										{	
											if(door.ChildNodes[i1].ChildNodes[f2].Name=="CONDITION")
											{
												newRow["CONDITION"]=door.ChildNodes[i1].ChildNodes[f2].InnerText;
											}
											else
											{
												newRow["table_wherefied"]=door.ChildNodes[i1].ChildNodes[f2].Name;
												newRow["wherevalues"]=door.ChildNodes[i1].ChildNodes[f2].InnerText;
											}
											if(k1==1)
											{
											}
											else
											{
												f2++;
											}
										}
										dtWhere.Rows.Add(newRow);
									}
								}
							}
						}
						break;
					case "DELETE":
						dtValues=null;
						for(int i1=0;i1<door.ChildNodes.Count;i1++)
						{
							if(door.ChildNodes[i1].Name=="WHERE")
							{
								if(door.ChildNodes[i1].HasChildNodes)
								{
									for(int f2=0;f2<door.ChildNodes[i1].ChildNodes.Count;f2++)
									{
										DataRow newRow=dtWhere.NewRow();
										for(int k1=0;k1<2;k1++)
										{
											if(door.ChildNodes[i1].ChildNodes[f2].Name=="CONDITION")
											{
												newRow["CONDITION"]=door.ChildNodes[i1].ChildNodes[f2].InnerText;
											}
											else
											{
												newRow["table_wherefied"]=door.ChildNodes[i1].ChildNodes[f2].Name;
												newRow["wherevalues"]=door.ChildNodes[i1].ChildNodes[f2].InnerText;
											}
												
											if(k1==1)
											{
											}
											else
											{
												f2++;
											}
										}
										dtWhere.Rows.Add(newRow);
									}

								}
							}
						}
						break;
				}

			}
		}
		#endregion

		private void buttonXP2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			listView1.Items.Clear();
			listView2.Items.Clear();
			listView3.Items.Clear();
			if(p_objVO.Length==0)
			{
				return;
			}
			if(comboBox1.SelectedIndex==0)
			{
				for(int i1=0;i1<p_objVO.Length;i1++)
				{
					m_mthFillList(p_objVO[i1]);
				}
			}
			else
			{
				for(int i1=0;i1<p_objVO.Length;i1++)
				{
					if(p_objVO[i1].m_objMarkFied[0].m_strFiedValues_CHR==comboBox1.SelectedItem.ToString())
					{
						m_mthFillList(p_objVO[i1]);
					}
				}
			}
		}
		}
}
