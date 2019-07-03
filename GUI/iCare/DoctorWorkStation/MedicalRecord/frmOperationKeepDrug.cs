using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;

namespace iCare
{
	public class frmOperationKeepDrug : iCare.frmManageRecordForm
	{
		private System.Windows.Forms.Button m_cmdCancel;
		private System.Windows.Forms.Button m_cmdOK;
		private System.Windows.Forms.ListView m_lsvItem;
		private System.ComponentModel.IContainer components = null;

		public frmOperationKeepDrug()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
 			// TODO: Add any initialization after the InitializeComponent call
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{m_lsvItem});
		}
		/// <summary>
		/// Clean up any resources being used.
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "propofol", System.Drawing.Color.White, System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152))), new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)))),
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "１１"),
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "１１１")}, -1);
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "isoflurane", System.Drawing.Color.White, System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152))), new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))))}, -1);
			System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "sevoflurane", System.Drawing.Color.White, System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152))), new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))))}, -1);
			System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "desflurane", System.Drawing.Color.White, System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152))), new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))))}, -1);
			System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "ketamine", System.Drawing.Color.White, System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152))), new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))))}, -1);
			System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "vencuron", System.Drawing.Color.White, System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152))), new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))))}, -1);
			System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "atracronium", System.Drawing.Color.White, System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152))), new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))))}, -1);
			System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "scoline", System.Drawing.Color.White, System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152))), new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))))}, -1);
			System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "2%lidocaine", System.Drawing.Color.White, System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152))), new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))))}, -1);
			System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								 new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "1%lidocaine", System.Drawing.Color.White, System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152))), new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))))}, -1);
			System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								 new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "0.25%bupivacaine", System.Drawing.Color.White, System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152))), new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))))}, -1);
			System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								 new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "0.375%bupivacaine", System.Drawing.Color.White, System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152))), new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))))}, -1);
			System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								 new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "0.5%ropivacaine", System.Drawing.Color.White, System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152))), new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))))}, -1);
			System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								 new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "0.75%ropivacaine", System.Drawing.Color.White, System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152))), new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))))}, -1);
			System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								 new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "0.15%dicaine", System.Drawing.Color.White, System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152))), new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))))}, -1);
			System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								 new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "0.3%dicaine", System.Drawing.Color.White, System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152))), new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))))}, -1);
			System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								 new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "0.5%levobupivacaine", System.Drawing.Color.White, System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152))), new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))))}, -1);
			this.m_cmdCancel = new System.Windows.Forms.Button();
			this.m_cmdOK = new System.Windows.Forms.Button();
			this.m_lsvItem = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// m_cmdCancel
			// 
			this.m_cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdCancel.Location = new System.Drawing.Point(308, 236);
			this.m_cmdCancel.Name = "m_cmdCancel";
			this.m_cmdCancel.Size = new System.Drawing.Size(76, 28);
			this.m_cmdCancel.TabIndex = 29275;
			this.m_cmdCancel.Text = "取  消";
			this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
			// 
			// m_cmdOK
			// 
			this.m_cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdOK.Location = new System.Drawing.Point(228, 236);
			this.m_cmdOK.Name = "m_cmdOK";
			this.m_cmdOK.Size = new System.Drawing.Size(76, 28);
			this.m_cmdOK.TabIndex = 29274;
			this.m_cmdOK.Text = "确  定";
			this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
			// 
			// m_lsvItem
			// 
			this.m_lsvItem.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_lsvItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_lsvItem.CheckBoxes = true;
			this.m_lsvItem.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvItem.ForeColor = System.Drawing.Color.White;
			this.m_lsvItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			listViewItem1.StateImageIndex = 0;
			listViewItem2.StateImageIndex = 0;
			listViewItem3.StateImageIndex = 0;
			listViewItem4.StateImageIndex = 0;
			listViewItem5.StateImageIndex = 0;
			listViewItem6.StateImageIndex = 0;
			listViewItem7.StateImageIndex = 0;
			listViewItem8.StateImageIndex = 0;
			listViewItem9.StateImageIndex = 0;
			listViewItem10.StateImageIndex = 0;
			listViewItem11.StateImageIndex = 0;
			listViewItem12.StateImageIndex = 0;
			listViewItem13.StateImageIndex = 0;
			listViewItem14.StateImageIndex = 0;
			listViewItem15.StateImageIndex = 0;
			listViewItem16.StateImageIndex = 0;
			listViewItem17.StateImageIndex = 0;
			this.m_lsvItem.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
																					  listViewItem1,
																					  listViewItem2,
																					  listViewItem3,
																					  listViewItem4,
																					  listViewItem5,
																					  listViewItem6,
																					  listViewItem7,
																					  listViewItem8,
																					  listViewItem9,
																					  listViewItem10,
																					  listViewItem11,
																					  listViewItem12,
																					  listViewItem13,
																					  listViewItem14,
																					  listViewItem15,
																					  listViewItem16,
																					  listViewItem17});
			this.m_lsvItem.Location = new System.Drawing.Point(8, 8);
			this.m_lsvItem.Name = "m_lsvItem";
			this.m_lsvItem.Size = new System.Drawing.Size(376, 220);
			this.m_lsvItem.TabIndex = 29276;
			this.m_lsvItem.View = System.Windows.Forms.View.List;
			// 
			// frmOperationKeepDrug
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.ClientSize = new System.Drawing.Size(392, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_lsvItem,
																		  this.m_cmdCancel,
																		  this.m_cmdOK});
			this.MaximizeBox = false;
			this.Name = "frmOperationKeepDrug";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "维持用药";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 设置调用窗体的信息
		/// </summary>
		/// <param name="p_objParentForm"></param>
		public void m_mthSetParentForm(Form p_objParentForm,Control p_objSelectedControl)
		{
			m_mthSetParentFormBase(p_objParentForm,p_objSelectedControl);
		}

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			string strOutputString = m_strGetOutPutString();
			m_mthSetControlText(strOutputString);
			this.Close();
		}

		private void m_cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// 获得输出文字
		/// </summary>
		/// <returns>输出文字</returns>
		private string m_strGetOutPutString()
		{
			StringBuilder stbOut = new StringBuilder("");

			for(int i1=0;i1<m_lsvItem.CheckedItems.Count;i1++)
			{
				stbOut.Append(m_lsvItem.CheckedItems[i1].Text + ",");
			}
			return stbOut.ToString();
		}
	}
}

