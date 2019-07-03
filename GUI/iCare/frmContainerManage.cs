using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.PublicMiddleTier;
namespace iCare
{
	/// <summary>
	/// Summary description for frmContainerManage.
	/// </summary>
	public class frmContainerManage : iCare.iCareBaseForm.frmBaseForm
	{
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Button AddNewRecord;
		protected internal System.Windows.Forms.ColumnHeader 编码;
		private System.Windows.Forms.ColumnHeader 容器名称;
		private System.Windows.Forms.ColumnHeader 助记码;
		private System.Windows.Forms.ColumnHeader 最小体积;
		private System.Windows.Forms.ColumnHeader 最大体积;
		private System.Windows.Forms.TextBox Container_ID;
		private System.Windows.Forms.TextBox Container_Name;
		private System.Windows.Forms.TextBox Help_Code;
		private System.Windows.Forms.TextBox MinVol;
		private System.Windows.Forms.TextBox MaxVol;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmContainerManage()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.listView1 = new System.Windows.Forms.ListView();
			this.编码 = new System.Windows.Forms.ColumnHeader();
			this.容器名称 = new System.Windows.Forms.ColumnHeader();
			this.助记码 = new System.Windows.Forms.ColumnHeader();
			this.最小体积 = new System.Windows.Forms.ColumnHeader();
			this.最大体积 = new System.Windows.Forms.ColumnHeader();
			this.AddNewRecord = new System.Windows.Forms.Button();
			this.Container_ID = new System.Windows.Forms.TextBox();
			this.Container_Name = new System.Windows.Forms.TextBox();
			this.Help_Code = new System.Windows.Forms.TextBox();
			this.MinVol = new System.Windows.Forms.TextBox();
			this.MaxVol = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.编码,
																						this.容器名称,
																						this.助记码,
																						this.最小体积,
																						this.最大体积});
			this.listView1.Location = new System.Drawing.Point(64, 24);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(568, 216);
			this.listView1.TabIndex = 0;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// 编码
			// 
			this.编码.Width = 90;
			// 
			// 容器名称
			// 
			this.容器名称.Width = 143;
			// 
			// 助记码
			// 
			this.助记码.Width = 96;
			// 
			// 最小体积
			// 
			this.最小体积.Width = 106;
			// 
			// 最大体积
			// 
			this.最大体积.Width = 91;
			// 
			// AddNewRecord
			// 
			this.AddNewRecord.Location = new System.Drawing.Point(440, 368);
			this.AddNewRecord.Name = "AddNewRecord";
			this.AddNewRecord.Size = new System.Drawing.Size(200, 40);
			this.AddNewRecord.TabIndex = 1;
			this.AddNewRecord.Text = "添加";
			this.AddNewRecord.Click += new System.EventHandler(this.AddNewRecord_Click);
			// 
			// Container_ID
			// 
			this.Container_ID.Location = new System.Drawing.Point(56, 296);
			this.Container_ID.Name = "Container_ID";
			this.Container_ID.TabIndex = 2;
			this.Container_ID.Text = "";
			// 
			// Container_Name
			// 
			this.Container_Name.Location = new System.Drawing.Point(232, 296);
			this.Container_Name.Name = "Container_Name";
			this.Container_Name.TabIndex = 3;
			this.Container_Name.Text = "";
			// 
			// Help_Code
			// 
			this.Help_Code.Location = new System.Drawing.Point(424, 296);
			this.Help_Code.Name = "Help_Code";
			this.Help_Code.TabIndex = 4;
			this.Help_Code.Text = "";
			// 
			// MinVol
			// 
			this.MinVol.Location = new System.Drawing.Point(56, 376);
			this.MinVol.Name = "MinVol";
			this.MinVol.TabIndex = 5;
			this.MinVol.Text = "";
			// 
			// MaxVol
			// 
			this.MaxVol.Location = new System.Drawing.Point(232, 376);
			this.MaxVol.Name = "MaxVol";
			this.MaxVol.TabIndex = 6;
			this.MaxVol.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(56, 264);
			this.label1.Name = "label1";
			this.label1.TabIndex = 7;
			this.label1.Text = "编码";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(240, 256);
			this.label2.Name = "label2";
			this.label2.TabIndex = 8;
			this.label2.Text = "容器名称";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(432, 256);
			this.label3.Name = "label3";
			this.label3.TabIndex = 9;
			this.label3.Text = "助记码";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(56, 336);
			this.label4.Name = "label4";
			this.label4.TabIndex = 10;
			this.label4.Text = "最小体积";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(248, 336);
			this.label5.Name = "label5";
			this.label5.TabIndex = 11;
			this.label5.Text = "最大体积";
			// 
			// frmContainerManage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(688, 461);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label5,
																		  this.label4,
																		  this.label3,
																		  this.label2,
																		  this.label1,
																		  this.MaxVol,
																		  this.MinVol,
																		  this.Help_Code,
																		  this.Container_Name,
																		  this.Container_ID,
																		  this.AddNewRecord,
																		  this.listView1});
			this.Name = "frmContainerManage";
			this.Text = "frmContainerManage";
			this.ResumeLayout(false);

		}
		#endregion

		private void AddNewRecord_Click(object sender, System.EventArgs e)
		{
	/*		clsContainerManageService ccms = new clsContainerManageService();
		
			
			clsContainerManage[] cm ;
			long eff = ccms.m_lngGetAllContainer( out cm );

			if ( eff == 0 )
				return ;

			for ( int i = 0; i < eff; i ++)
			{

				ListViewItem lvt = new ListViewItem ( new string [5] { cm[i].m_strContainer_ID.ToString(), cm[i].m_strContainer_Name.ToString(), cm[i].m_strHelp_Code.ToString(), cm[i].m_fltMinVol.ToString(), cm[i].m_fltMaxVol.ToString() } );
				

				listView1.Items.Add( lvt );
				
			}*/
			
//			clsContainerManage objCM = new clsContainerManage(); 
//
//			objCM.m_strContainer_ID = Container_ID.Text;
//			objCM.m_strContainer_Name = Container_Name.Text;
//			objCM.m_strHelp_Code = Help_Code.Text;
//			objCM.m_fltMinVol = Convert.ToSingle ( MinVol.Text );
//			objCM.m_fltMaxVol = Convert.ToSingle ( MaxVol.Text );
//			objCM.m_dtmBegin_Name_Date = DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
//
//			clsContainerManageService objCMS = new clsContainerManageService();
//
//			long eff2 = objCMS.m_lngAddContainer ( objCM );
			

		}
	}
}
