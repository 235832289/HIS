using System;

using System.Drawing;

using System.Collections;

using System.ComponentModel;

using System.Windows.Forms;

using System.Data;


 

namespace com.digitalwave.iCare.gui.HIS

{

	public class Form1 : System.Windows.Forms.Form

	{

		private System.Windows.Forms.DataGrid dgGrid;

		private DataTable dtblFunctionalArea;

		private System.Windows.Forms.Button buttonFocus;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;

		private System.ComponentModel.Container components = null;

 

		public Form1()

		{

			InitializeComponent();

			PopulateGrid();

		}

 

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

		private void InitializeComponent()

		{
			this.dgGrid = new System.Windows.Forms.DataGrid();
			this.buttonFocus = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// dgGrid
			// 
			this.dgGrid.DataMember = "";
			this.dgGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgGrid.Location = new System.Drawing.Point(4, 8);
			this.dgGrid.Name = "dgGrid";
			this.dgGrid.Size = new System.Drawing.Size(316, 168);
			this.dgGrid.TabIndex = 0;
			this.dgGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgGrid_KeyDown);
			this.dgGrid.DoubleClick += new System.EventHandler(this.dgGrid_DoubleClick);
			// 
			// buttonFocus
			// 
			this.buttonFocus.Location = new System.Drawing.Point(232, 188);
			this.buttonFocus.Name = "buttonFocus";
			this.buttonFocus.Size = new System.Drawing.Size(84, 23);
			this.buttonFocus.TabIndex = 1;
			this.buttonFocus.Text = "获取焦点";
			this.buttonFocus.Click += new System.EventHandler(this.buttonFocus_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(16, 184);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "textBox1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(144, 184);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 32);
			this.button1.TabIndex = 3;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// toolBar1
			// 
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.toolBarButton1,
																						this.toolBarButton2,
																						this.toolBarButton3,
																						this.toolBarButton4});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(608, 41);
			this.toolBar1.TabIndex = 4;
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Text = "新增明细";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(344, 280);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(88, 32);
			this.button2.TabIndex = 5;
			this.button2.Text = "button2";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(424, 120);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(136, 40);
			this.button3.TabIndex = 6;
			this.button3.Text = "button3";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(608, 373);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.toolBar1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.buttonFocus);
			this.Controls.Add(this.dgGrid);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dgGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

 

		/// <summary>

		/// 应用程序的主入口点。

		/// </summary>

		[STAThread]

		static void Main() 

		{

			Application.Run(new Form1());

		}

		//初始化DataGrid

		private void PopulateGrid()

		{

			//创建一个DataTable对象，包括四列，前三列为String，最后一列为Boolean。

			dtblFunctionalArea  = new DataTable ("FunctionArea");

			string[] arrstrFunctionalArea = new string [3]{"Functional Area","Min","Max"};

			DataColumn dtCol = null;

			//创建String列       

			for(int i=0; i< 3;i++)

			{    

				dtCol = new DataColumn(arrstrFunctionalArea[i]);

				dtCol.DataType  = Type.GetType("System.String");

				dtCol.DefaultValue = "";
                if(i==2)
					dtCol.ReadOnly=true;
				dtblFunctionalArea.Columns.Add(dtCol);               

			}     

 

			//创建Boolean列，用CheckedBox来显示。    

			DataColumn dtcCheck = new DataColumn("IsMandatory");
            
			dtcCheck.DataType = System.Type.GetType("System.Boolean");

			dtcCheck.DefaultValue = false;

			dtblFunctionalArea.Columns.Add(dtcCheck);

            DataColumn dtcMe=new DataColumn("完全",System.Type.GetType("System.String"));
            dtblFunctionalArea.Columns.Add(dtcMe);
//            DataGridCell k=new DataGridCell(2,5);
//			
//			dgGrid.CurrentCell=k;

			//把表绑定到DataGrid

			dgGrid.DataSource    = dtblFunctionalArea;  

 

			//为DataGrid加载DataGridTableStyle样式

			if(!dgGrid.TableStyles.Contains("FunctionArea"))

			{

				DataGridTableStyle dgdtblStyle = new DataGridTableStyle();

				dgdtblStyle.MappingName = dtblFunctionalArea.TableName;

				dgGrid.TableStyles.Add(dgdtblStyle);

				dgdtblStyle.RowHeadersVisible = false;

				dgdtblStyle.HeaderBackColor = Color.LightSteelBlue;

				dgdtblStyle.AllowSorting  = false;

				dgdtblStyle.HeaderBackColor = Color.FromArgb(8,36,107);

				dgdtblStyle.RowHeadersVisible = false;

				dgdtblStyle.HeaderForeColor = Color.White;

				dgdtblStyle.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F,  

					System.Drawing.FontStyle.Bold, 

					System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));

				dgdtblStyle.GridLineColor = Color.DarkGray;

				dgdtblStyle.PreferredRowHeight = 22;

				dgGrid.BackgroundColor = Color.White;  

 

				//设置列的宽度  

				GridColumnStylesCollection colStyle = dgGrid.TableStyles[0].GridColumnStyles;

				colStyle[0].Width = 100;

				colStyle[1].Width = 50;

				colStyle[2].Width = 50;

				colStyle[3].Width = 80;
				colStyle[0].Alignment=HorizontalAlignment.Center;
				colStyle[1].Alignment=HorizontalAlignment.Center;
				colStyle[2].Alignment=HorizontalAlignment.Center;
				colStyle[3].Alignment=HorizontalAlignment.Center;
				dgGrid.CaptionText="KKKKKKKK";

			}

 

			DataGridTextBoxColumn dgtb = (DataGridTextBoxColumn)dgGrid.TableStyles[0].GridColumnStyles[0]; 

			ComboBox cmbFunctionArea = new ComboBox();

			cmbFunctionArea.Items.AddRange(new object[]{"选项一","选项二","选项三"});

			cmbFunctionArea.Cursor = Cursors.Arrow;

			cmbFunctionArea.DropDownStyle= ComboBoxStyle.DropDownList;
            
			cmbFunctionArea.Dock = DockStyle.Fill;

			//在选定项发生更改并且提交了该更改后发生

			cmbFunctionArea.SelectionChangeCommitted += new EventHandler(cmbFunctionArea_SelectionChangeCommitted); 

			//把ComboBox添加到DataGridTableStyle的第一列

			dgtb.TextBox.Controls.Add(cmbFunctionArea);             


			DataGridTextBoxColumn dgts = (DataGridTextBoxColumn)dgGrid.TableStyles[0].GridColumnStyles[4]; 

			DateTimePicker DP = new DateTimePicker();

			DP.Value=DateTime.Now.AddDays(12);

			DP.Cursor = Cursors.Arrow;
            DP.ValueChanged+=new EventHandler(DP_ValueChanged);

			DP.Dock = DockStyle.Fill;


			//把ComboBox添加到DataGridTableStyle的第一列

			dgts.TextBox.Controls.Add(DP);  
			//dgts.TextBox.Click+=new EventHandler(TextBox_Click);
			dgts.TextBox.Enabled=false;

		}

		//设置焦点模拟

		private void GetFocus(int row,int col)

		{

			//先把焦点移动到DataGrid

			this.dgGrid.Focus();   

			//把焦点移动到DataGridCell

			DataGridCell dgc = new DataGridCell(row,col); 

			this.dgGrid.CurrentCell = dgc; 

			DataGridTextBoxColumn dgtb = (DataGridTextBoxColumn)dgGrid.TableStyles[0].GridColumnStyles[col]; 

			//设置焦点

			dgtb.TextBox.Focus();
			dgtb.TextBox.Enabled=false;
            dgtb.TextBox.Enabled=true;

 

		}          

		//把Combobox上修改的数据提交到当前的网格

		private void cmbFunctionArea_SelectionChangeCommitted(object sender, EventArgs e)

		{

			this.dgGrid[this.dgGrid.CurrentCell] = ((ComboBox)sender).SelectedItem.ToString();

		}        

		//设置新的焦点

		private void buttonFocus_Click(object sender, System.EventArgs e)

		{

			//焦点模拟,这里设置第三行第一列

			GetFocus(2,0);
//			clsDomainControl_ChargeItem cls=new clsDomainControl_ChargeItem();
			

		}
		private void DP_ValueChanged(object sender,EventArgs e)
		{
			this.dgGrid[this.dgGrid.CurrentCell]=((DateTimePicker)sender).Value.ToShortDateString();
		}

		private void dgGrid_DoubleClick(object sender, System.EventArgs e)
		{
			MessageBox.Show(dgGrid.CurrentCell.RowNumber.ToString());
		}

		private void dgGrid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		   MessageBox.Show(e.KeyCode.ToString());
		}

		private void Text_ValueChanged(object sender,EventArgs e)
		{
			MessageBox.Show("JJ");
			
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			
			
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			frmOPDoctor frm=new frmOPDoctor();
			frm.Show();
		}

	}

}