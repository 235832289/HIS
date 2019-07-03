using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.LIS_Data_Acquisition_Controller
{
	/// <summary>
	/// frmRealtimeMessage 的摘要说明。
	/// </summary>
	public class frmRealtimeMessage : System.Windows.Forms.Form
	{
		public clsController_LIS_Data_Acquisition m_objController;
		System.Timers.Timer m_objTimer;
		#region FormControl
		private System.Windows.Forms.RichTextBox m_txtWindow;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.StatusBar m_stbState;
		private System.Windows.Forms.Panel m_palList;
		private System.Windows.Forms.Panel m_palWindow;
		private System.Windows.Forms.StatusBarPanel m_stpMessage;
		private System.Windows.Forms.StatusBarPanel m_stp2;
		private System.Windows.Forms.StatusBarPanel m_stpDateTime;
		private System.Windows.Forms.MainMenu m_mnuMain;
		private System.Windows.Forms.MenuItem m_mnuClear;
		private System.Windows.Forms.MenuItem m_mnuHide;
        private System.Windows.Forms.ListView m_lsvList;
		#endregion
        private IContainer components;
		#region 构造函数
		public frmRealtimeMessage()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			m_objTimer =  new System.Timers.Timer();
			m_objTimer.Interval = 1000;
			m_objTimer.Elapsed +=new System.Timers.ElapsedEventHandler(m_objTimer_Elapsed);
			m_objTimer.Enabled = true;
		}

		#endregion
		#region override
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

		#endregion
		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRealtimeMessage));
            this.m_txtWindow = new System.Windows.Forms.RichTextBox();
            this.m_lsvList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.m_stbState = new System.Windows.Forms.StatusBar();
            this.m_stpMessage = new System.Windows.Forms.StatusBarPanel();
            this.m_stpDateTime = new System.Windows.Forms.StatusBarPanel();
            this.m_stp2 = new System.Windows.Forms.StatusBarPanel();
            this.m_palList = new System.Windows.Forms.Panel();
            this.m_palWindow = new System.Windows.Forms.Panel();
            this.m_mnuMain = new System.Windows.Forms.MainMenu(this.components);
            this.m_mnuClear = new System.Windows.Forms.MenuItem();
            this.m_mnuHide = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.m_stpMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_stpDateTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_stp2)).BeginInit();
            this.m_palList.SuspendLayout();
            this.m_palWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_txtWindow
            // 
            this.m_txtWindow.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.m_txtWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtWindow.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtWindow.Location = new System.Drawing.Point(0, 0);
            this.m_txtWindow.Name = "m_txtWindow";
            this.m_txtWindow.ReadOnly = true;
            this.m_txtWindow.Size = new System.Drawing.Size(598, 411);
            this.m_txtWindow.TabIndex = 0;
            this.m_txtWindow.Text = "";
            // 
            // m_lsvList
            // 
            this.m_lsvList.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.m_lsvList.BackColor = System.Drawing.Color.LightSlateGray;
            this.m_lsvList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.m_lsvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvList.FullRowSelect = true;
            this.m_lsvList.GridLines = true;
            this.m_lsvList.HideSelection = false;
            this.m_lsvList.Location = new System.Drawing.Point(0, 0);
            this.m_lsvList.MultiSelect = false;
            this.m_lsvList.Name = "m_lsvList";
            this.m_lsvList.Size = new System.Drawing.Size(360, 411);
            this.m_lsvList.TabIndex = 1;
            this.m_lsvList.UseCompatibleStateImageBehavior = false;
            this.m_lsvList.View = System.Windows.Forms.View.Details;
            this.m_lsvList.ItemActivate += new System.EventHandler(this.m_lsvList_ItemActivate);
            this.m_lsvList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lsvList_MouseUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "设备";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "样本号";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "检验日期";
            this.columnHeader3.Width = 150;
            // 
            // m_stbState
            // 
            this.m_stbState.Location = new System.Drawing.Point(0, 411);
            this.m_stbState.Name = "m_stbState";
            this.m_stbState.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.m_stpMessage,
            this.m_stpDateTime,
            this.m_stp2});
            this.m_stbState.ShowPanels = true;
            this.m_stbState.Size = new System.Drawing.Size(958, 22);
            this.m_stbState.TabIndex = 2;
            // 
            // m_stpMessage
            // 
            this.m_stpMessage.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.m_stpMessage.Icon = ((System.Drawing.Icon)(resources.GetObject("m_stpMessage.Icon")));
            this.m_stpMessage.Name = "m_stpMessage";
            this.m_stpMessage.Text = "就绪";
            this.m_stpMessage.Width = 642;
            // 
            // m_stpDateTime
            // 
            this.m_stpDateTime.Name = "m_stpDateTime";
            this.m_stpDateTime.Text = "2004-07-16 10:38:01";
            this.m_stpDateTime.Width = 140;
            // 
            // m_stp2
            // 
            this.m_stp2.Name = "m_stp2";
            this.m_stp2.Text = " 灏瀚科技 DigitalWave";
            this.m_stp2.Width = 160;
            // 
            // m_palList
            // 
            this.m_palList.Controls.Add(this.m_lsvList);
            this.m_palList.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_palList.Location = new System.Drawing.Point(0, 0);
            this.m_palList.Name = "m_palList";
            this.m_palList.Size = new System.Drawing.Size(360, 411);
            this.m_palList.TabIndex = 3;
            // 
            // m_palWindow
            // 
            this.m_palWindow.Controls.Add(this.m_txtWindow);
            this.m_palWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_palWindow.Location = new System.Drawing.Point(360, 0);
            this.m_palWindow.Name = "m_palWindow";
            this.m_palWindow.Size = new System.Drawing.Size(598, 411);
            this.m_palWindow.TabIndex = 4;
            // 
            // m_mnuMain
            // 
            this.m_mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_mnuClear,
            this.m_mnuHide});
            // 
            // m_mnuClear
            // 
            this.m_mnuClear.Index = 0;
            this.m_mnuClear.Text = "清空(&C)";
            this.m_mnuClear.Click += new System.EventHandler(this.m_mnuClear_Click);
            // 
            // m_mnuHide
            // 
            this.m_mnuHide.Index = 1;
            this.m_mnuHide.Text = "隐藏(&H)";
            this.m_mnuHide.Click += new System.EventHandler(this.m_mnuHide_Click);
            // 
            // frmRealtimeMessage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(958, 433);
            this.Controls.Add(this.m_palWindow);
            this.Controls.Add(this.m_palList);
            this.Controls.Add(this.m_stbState);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.m_mnuMain;
            this.Name = "frmRealtimeMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据采集实时监控";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmRealtimeMessage_Closing);
            this.Load += new System.EventHandler(this.frmRealtimeMessage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_stpMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_stpDateTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_stp2)).EndInit();
            this.m_palList.ResumeLayout(false);
            this.m_palWindow.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		public void m_mthShowMessage(bool p_blnAdd, clsDeviceSampleDataKey p_objDSDKey, object[] p_objResultVOArr)
		{

			string strCommingDate;
			if(p_blnAdd)
			{
				ListViewItem lvi = new ListViewItem(p_objDSDKey.strDeviceName);
				lvi.SubItems.Add(p_objDSDKey.strDeviceSampleID);
				lvi.SubItems.Add(p_objDSDKey.strCheckDate);
				this.m_lsvList.Items.Add(lvi);
				lvi.Selected = true;
				lvi.Focused = true;
				lvi.EnsureVisible();
				lvi.Tag = p_objDSDKey;
				strCommingDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				p_objDSDKey.strCommingDateTime = strCommingDate;
			}
			else
			{
				strCommingDate = p_objDSDKey.strCommingDateTime;
			}
			string strSeq;
			string strItemName;
			string strResult;
			string strFlag;
			string strRefrange;
			this.m_txtWindow.Clear();
			m_txtWindow.AppendText("Device data comming in " + strCommingDate 
				+ "  ......\r\n");
			m_txtWindow.AppendText("Device Name: " + p_objDSDKey.strDeviceName + "  Device Sample ID: " + p_objDSDKey.strDeviceSampleID + "  CheckDate: " + p_objDSDKey.strCheckDate + "\r\n\r\n");
			m_txtWindow.AppendText("Seq.    ItemName            Result      Flag    ReferanceRange\r\n");
			m_txtWindow.AppendText("--------------------------------------------------------------------------\r\n");


			for(int i=0;i<p_objResultVOArr.Length;i++)//clsLIS_Device_Test_ResultVO[]
			{
				strSeq = i.ToString().PadRight(8);
				if(p_objResultVOArr[i] is clsLIS_Device_Test_ResultVO)
				{
					clsLIS_Device_Test_ResultVO objTestResult = (clsLIS_Device_Test_ResultVO)p_objResultVOArr[i];

						strItemName = objTestResult.strDevice_Check_Item_Name;
					if(strItemName != null)
					{
						strItemName = strItemName.PadRight(20);	
					}
					else
					{
						strItemName = "           ";
					}
					if(objTestResult.strResult != null)
					{
						strResult = objTestResult.strResult.PadRight(12);		
					}
					else
					{
						strResult = "            ";
					}
					if(objTestResult.strAbnormal_Flag != null)
					{
						strFlag = objTestResult.strAbnormal_Flag.PadRight(8);
					}
					else
					{
						strFlag = "        ";
					}
					strRefrange = objTestResult.strRefRange;
				}
				else
				{
					clsDeviceReslutVO objResult = (clsDeviceReslutVO)p_objResultVOArr[i];
						strItemName = objResult.m_strDeviceCheckItemName;
					if(strItemName != null)
					{
						strItemName = strItemName.PadRight(20);	
					}
					else
					{
						strItemName = "           ";
					}
					if(objResult.m_strResult != null)
					{
						strResult = objResult.m_strResult.PadRight(12);		
					}
					else
					{
						strResult = "            ";
					}
					if(objResult.m_strAbnormalFlag != null)
					{
						strFlag = objResult.m_strAbnormalFlag.PadRight(8);
					}
					else
					{
						strFlag = "        ";
					}
					strRefrange =objResult.m_strRefRange;
				}
				m_txtWindow.AppendText(strSeq);
				m_txtWindow.AppendText(strItemName);
				m_txtWindow.AppendText(strResult);
				m_txtWindow.AppendText(strFlag);
				m_txtWindow.AppendText(strRefrange + "\r\n");
			}
			m_txtWindow.AppendText("--------------------------------------------------------------------------\r\n");

			if((!this.Visible) ||(this.WindowState == FormWindowState.Minimized))
			{
//				frmMessageNotify frm = new frmMessageNotify();
//				frm.m_frmRealWindow = this;
//				frm.m_lblDevice.Text = p_objDSDKey.strDeviceName;
//				frm.m_lnkDeviceSample.Text = p_objDSDKey.strDeviceSampleID;
//				frm.TopMost = true;
//				frm.m_objKey = p_objDSDKey;
//				frm.Show();
			}
			else
			{
				//				this.Show();
				this.Activate();
			}

		}


		private void frmRealtimeMessage_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.Hide();
			e.Cancel = true;
		}

		private void m_mnuHide_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}

		private void m_mnuClear_Click(object sender, System.EventArgs e)
		{
			this.m_txtWindow.Clear();
			this.m_lsvList.Items.Clear();
		}

		private void m_lsvList_ItemActivate(object sender, System.EventArgs e)
		{
			clsDeviceSampleDataKey objKey = (clsDeviceSampleDataKey)this.m_lsvList.SelectedItems[0].Tag;
			clsDeviceReslutVO[] objDeviceResultArr = null;
			this.m_objController.m_mthGetDeviceData(objKey.strDeviceID,objKey.strDeviceSampleID,objKey.strCheckDate,objKey.intResultBeginIndex,objKey.intResultEndIndex,out objDeviceResultArr);
			if(objDeviceResultArr != null)
			{
				this.m_mthShowMessage(false,objKey,objDeviceResultArr);
			}
		}

		private void m_lsvList_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(this.m_lsvList.FocusedItem != null)
			{
				this.m_lsvList.FocusedItem.Selected = true;
			}
		}

		private void m_objTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			// this.m_stpDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		}

		public void m_mthShowWithSample(clsDeviceSampleDataKey p_objKey)
		{
			if(p_objKey == null)
				return;
			for(int i=0;i<this.m_lsvList.Items.Count;i++)
			{
				if(this.m_lsvList.Items[i].Tag.ToString() == p_objKey.ToString())
				{
					this.m_lsvList.Items[i].Focused = true;
					this.m_lsvList.Items[i].EnsureVisible();
					this.m_lsvList.Items[i].Selected = true;
					m_lsvList_ItemActivate(this.m_lsvList,null);
					break;
				}
			}
		}

        private void frmRealtimeMessage_Load(object sender, EventArgs e)
        {

        }
	}	
}
