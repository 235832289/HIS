using System;
using System.Windows.Forms;
using System.Drawing;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.common;

namespace com.digitalwave.iCare.BIHOrder.Control
{
	#region clsAreaTextBox
	/// <summary>
	/// 病区
	/// </summary>
	public class clsAreaTextBox:ctlFindTextBox
	{
		//private clsBIHOrderService m_objService=new clsBIHOrderService();
        clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
		private string m_strAreaID="";
		private string m_strAreaName="";
		public string AreaID
		{ 
			get{return m_strAreaID;}
			set
			{
				m_strAreaID=value;
				this.Tag=m_strAreaID;
			}
		}
		public string AreaName
		{ 
			get{return m_strAreaName;}
			set
			{
				m_strAreaName=value;
				this.Text=m_strAreaName;
			}
		}

		public clsAreaTextBox():base()
		{
			this.m_evtFindItem +=new EventHandler_OnFindItem(m_txtArea_m_evtFindItem);
			this.m_evtInitListView +=new EventHandler_InitListView(m_txtArea_m_evtInitListView);
			this.m_evtSelectItem +=new EventHandler_OnSelectItem(m_txtArea_m_evtSelectItem);
			this.Tag="";
		}

		#region Area

		private void m_txtArea_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
		{
			clsBIHArea[] arrArea;
			long ret=m_objService.m_lngFindArea(strFindCode,out arrArea);
			if((ret>0) && (arrArea!=null))
			{
				for(int i=0;i<arrArea.Length;i++)
				{
					ListViewItem lvi=lvwList.Items.Add(arrArea[i].m_strAreaName);
					lvi.Tag=arrArea[i];
				}
			}
		}

		private void m_txtArea_m_evtInitListView(System.Windows.Forms.ListView lvwList)
		{
			lvwList.Columns.Add("",120,HorizontalAlignment.Left);
			lvwList.Width=140;
		}

		private void m_txtArea_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
		{
			if(lviSelected!=null)
			{
				this.Text=lviSelected.Text;
				this.Tag=(lviSelected.Tag as clsBIHArea).m_strAreaID;
				m_strAreaName=this.Text.Trim();
				m_strAreaID=this.Tag.ToString().Trim();
			}
		}

		#endregion

		public void m_mthSetArea(string strAreaID,string strAreaName)
		{
			this.Text=strAreaName;
			this.Tag=strAreaID;
			m_strAreaID=strAreaID;
			m_strAreaName=strAreaName;
		}

		public void m_mthSetArea(string strAreaID)
		{
			clsBIHArea objArea;
			long ret= m_objService.m_lngGetAreaByID(strAreaID,out objArea);
			if(objArea == null)
			{
				this.Text="";
				this.Tag="";
			}
			else
			{
				this.Text=objArea.m_strAreaName;
				this.Tag=objArea.m_strAreaID;
				m_strAreaID=objArea.m_strAreaID;
				m_strAreaName=objArea.m_strAreaName;
			}

		}

	}

	#endregion 
	#region clsBedTextBox

	public class clsBedTextBox:ctlFindTextBox
	{
		//private clsBIHOrderService m_objService=new clsBIHOrderService();
        clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
		public clsBedTextBox():base()
		{
			this.m_evtFindItem +=new EventHandler_OnFindItem(clsBedTextBox_m_evtFindItem);
			this.m_evtInitListView +=new EventHandler_InitListView(clsBedTextBox_m_evtInitListView);
			this.m_evtSelectItem +=new EventHandler_OnSelectItem(clsBedTextBox_m_evtSelectItem);
			this.Tag="";
		}
		
		private string m_strAreaID="";
		public string AreaID
		{
			get
			{
				return m_strAreaID;
			}
			set
			{
				if(m_strAreaID!=value)
				{
					this.Text="";
					this.Tag="";

					m_strAreaID=value;
				}
			}
		}

		private void clsBedTextBox_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
		{
			if(m_strAreaID.Trim()=="") 
			{
				System.Windows.Forms.MessageBox.Show("请先指定病区!");
				return;
			}

			clsBIHBed[] arrBed;
			long ret=m_objService.m_lngGetBedByArea(m_strAreaID,strFindCode,out arrBed);
			if((ret>0) && (arrBed!=null))
			{
				for(int i=0;i<arrBed.Length;i++)
				{
					ListViewItem lvi=lvwList.Items.Add(arrBed[i].m_strBedName);
					lvi.Tag=arrBed[i];
				}
			}
		}

		private void clsBedTextBox_m_evtInitListView(System.Windows.Forms.ListView lvwList)
		{
			lvwList.Columns.Add("",100,HorizontalAlignment.Left);
			lvwList.Width=120;
		}

		private void clsBedTextBox_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
		{
			if(lviSelected!=null)
			{
				this.Text=lviSelected.Text;
				this.Tag=(lviSelected.Tag as clsBIHBed).m_strBedID;
			}
		}
		public string BedID
		{
			get
			{
				if(this.Tag==null)
					return "";
				else
					return (this.Tag.ToString().Trim());
			}
			set
			{
				this.Tag=value;
			}
		}
	}
	#endregion 
	#region clsDoctorTextBox

	public class clsDoctorTextBox:ctlFindTextBox
	{
		//private clsBIHOrderService m_objService=new clsBIHOrderService();
		public clsDoctorTextBox():base()
		{
			this.m_evtFindItem +=new EventHandler_OnFindItem(m_txtDoctor_m_evtFindItem);
			this.m_evtInitListView +=new EventHandler_InitListView(m_txtDoctor_m_evtInitListView);
			this.m_evtSelectItem +=new EventHandler_OnSelectItem(m_txtDoctor_m_evtSelectItem);
		}
		#region Doctor

		private void m_txtDoctor_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
		{
            //clsBIHOrderService m_objService = new clsBIHOrderService();
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            clsBIHDoctor[] arrDoctor;
            long ret = m_objService.m_lngFindDoctor(strFindCode, out arrDoctor);
            if ((ret > 0) && (arrDoctor != null))
            {
                for (int i = 0; i < arrDoctor.Length; i++)
                {
                    ListViewItem lvi = lvwList.Items.Add(arrDoctor[i].m_strDoctorNo);
                    lvi.SubItems.Add(arrDoctor[i].m_strDoctorName);
                    lvi.Tag = arrDoctor[i];
                }
            }
		}

		private void m_txtDoctor_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
		{
            this.Text = lviSelected.SubItems[1].Text;
            this.Tag = (lviSelected.Tag as clsBIHDoctor).m_strDoctorID;
            m_strDoctorID = this.Tag.ToString().Trim();
            m_strDoctorName = this.Text.Trim();
		}

		private void m_txtDoctor_m_evtInitListView(System.Windows.Forms.ListView lvwList)
		{
			lvwList.Columns.Clear();
			ColumnHeader ch1= lvwList.Columns.Add( "No",60,HorizontalAlignment.Left);
			ColumnHeader ch2= lvwList.Columns.Add("Name",60,HorizontalAlignment.Left);
			lvwList.Width=140;
		}

		#endregion

		public void m_mthSetDoctor(string DoctorID,string DoctorName)
		{
			this.Text=DoctorName;
			this.Tag=DoctorID;
			m_strDoctorID=DoctorID;
			m_strDoctorName=DoctorName;
		}
		private string m_strDoctorID="";
		public string DoctorID
		{
			get{return m_strDoctorID;}
			set
			{
				m_strDoctorID=value;
				this.Tag=m_strDoctorID;
			}
		}
		private string m_strDoctorName="";
		public string DoctorName
		{
			get{return m_strDoctorName;}
			set
			{
				m_strDoctorName=value;
				this.Text=m_strDoctorName;
			}
		}
	}
	#endregion 
	#region clsAsyncCall
	public class clsAsyncCall
	{
		private event clsAsyncCallStart m_objStart;

		private void AllFun()
		{
			if(m_objStart!=null)
			{
				m_objStart();
			}
		}
		public clsAsyncCall AddMethod(clsAsyncCallStart objMethod)
		{
			m_objStart+= objMethod;
			return this;
		}

		public void Run()
		{
			new System.Threading.Thread(new System.Threading.ThreadStart(AllFun)).Start();
		}
	}
	public delegate void clsAsyncCallStart();
	#endregion
	#region clsTextFocusHighlight
	public class clsTextFocusHighlight
	{
		private void m_mthEnter(object sender,System.EventArgs e)
		{
			System.Drawing.Color clrBack=System.Drawing.SystemColors.Info;

			if(sender is System.Windows.Forms.TextBox)
			{
				System.Windows.Forms.TextBox objTxt=sender as System.Windows.Forms.TextBox;
				if(objTxt.Enabled && (!objTxt.ReadOnly))
				{
					objTxt.BackColor=clrBack;
					objTxt.SelectAll();
				}
			}
			else if(sender is System.Windows.Forms.ComboBox)
			{
				System.Windows.Forms.ComboBox objCbo = sender as System.Windows.Forms.ComboBox;
				if(objCbo.Enabled)
				{
					objCbo.BackColor=clrBack;
				}
			}
		}
		private void m_mthLeave(object sender,System.EventArgs e)
		{
			System.Drawing.Color clrBack=System.Drawing.Color.White;

			if(sender is System.Windows.Forms.TextBox)
			{
				System.Windows.Forms.TextBox objTxt=sender as System.Windows.Forms.TextBox;
				if(objTxt.Enabled && (!objTxt.ReadOnly))
				{
					objTxt.BackColor=clrBack;
				}
			}
			else if(sender is System.Windows.Forms.ComboBox)
			{
				System.Windows.Forms.ComboBox objCbo = sender as System.Windows.Forms.ComboBox;
				if(objCbo.Enabled)
				{
					objCbo.BackColor=clrBack;
				}
			}
		}


		public void m_mthBindTextBox(System.Windows.Forms.Control objCtrl)
		{
			objCtrl.Enter +=new EventHandler(m_mthEnter);
			objCtrl.Leave += new EventHandler(m_mthLeave);
		}

		public void m_mthBindForm(System.Windows.Forms.Control objForm)
		{
			foreach(System.Windows.Forms.Control ctrl in objForm.Controls)
			{
				if((ctrl is System.Windows.Forms.TextBox)||(ctrl is System.Windows.Forms.ComboBox))
				{
					m_mthBindTextBox(ctrl as System.Windows.Forms.Control);
				}
			}
		}

		public void m_mthBindForm(System.Windows.Forms.Control objForm,bool blnRecursive)
		{
			if(blnRecursive)
			{
				//递归
				m_mthBindControl(objForm);
			}
			else
			{
			}
		}
		private void m_mthBindControl(System.Windows.Forms.Control objControl)
		{
			foreach(System.Windows.Forms.Control ctrl in objControl.Controls)
			{
				if((ctrl is System.Windows.Forms.TextBox)||(ctrl is System.Windows.Forms.ComboBox))
				{
					m_mthBindTextBox(ctrl as System.Windows.Forms.Control);
				}

				if((ctrl is System.Windows.Forms.Panel) || (ctrl is System.Windows.Forms.GroupBox))
				{
					m_mthBindControl(ctrl);
				}
			}
		}


		public void m_mthBindControls(System.Windows.Forms.Control[] arrControl)
		{
			if((arrControl!=null)&&(arrControl.Length>0))
			{
				for(int i=0;i<arrControl.Length;i++)
				{
					m_mthBindTextBox(arrControl[i]);
				}
			}
		}
	}
	#endregion

	#region clsOrderStatus
	public class clsOrderStatus
	{
		/// <summary>
		/// 根据医嘱类型状态返回颜色
		/// </summary>
		/// <param name="intType">医嘱类型	{1=长期;2=临时}</param>
		/// <param name="intStatus">执行状态	{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 审核提交;6-审核停止;7-退回;}</param>
		/// <param name="clrBack">[用于区别医嘱类型]</param>
		/// <param name="clrFore">[用于区别执行状态]</param>
		public static void s_mthGetColorByStatus(int intType,int intStatus,out Color clrBack,out Color clrFore)
		{
			clrFore=clsOrderColor.ForeColor;
			clrBack=clsOrderColor.BackColor;

			if(intType==1)
				clrBack =clsOrderColor.BackColorLongOrder;
			else if(intType==2)
				clrBack =clsOrderColor.BackColorTemOrder;
			else 
				clrBack =clsOrderColor.BackColor;

			switch(intStatus)
			{
				case 0:		//新建
					clrFore=clsOrderColor.ForeColorOrderStatus0 ;
					break;
				case 1:		//已提交
					clrFore=clsOrderColor.ForeColorOrderStatus1 ;
					break;
				case 2:		//执行
					clrFore=clsOrderColor.ForeColorOrderStatus2 ;
					break;
				case 3:		//停止
					clrFore=clsOrderColor.ForeColorOrderStatus3;
					break;
				case 4:		//重整
					clrFore=clsOrderColor.ForeColorOrderStatus4;
					break;
				case 5:		//审核提交
					clrFore=clsOrderColor.ForeColorOrderStatus5;
					break;
				case 6:		//审核停止
					clrFore=clsOrderColor.ForeColorOrderStatus6;
					break;
				case 7:		//退回
					clrFore=clsOrderColor.ForeColorOrderStatus7;
					break;
				case -1:	//作废
					clrFore=clsOrderColor.ForeColorOrderStatus_1;
					break;
			}
		}

		/// <summary>
		/// 费用状态
		/// </summary>
		/// <param name="intPStatus"></param>
		/// <returns></returns>
		public static string m_strGetChargeStatusMessage(int intPStatus)
		{
			string strStatus="";
			switch(intPStatus)
			{
				case 0:
					strStatus="待确认";
					break;
				case 1:
					strStatus="待结";
					break;
				case 2:
					strStatus="待清";
					break;
				case 3:
					strStatus="已清";
					break;
				case 4:
					strStatus="直收";
					break;
			}
			return strStatus;
		}
	}
	#endregion
	#region 医嘱颜色
	public class clsOrderColor
	{
		/// <summary>
		/// 正常背景颜色
		/// </summary>
		public static Color BackColor =SystemColors.Control;
		/// <summary>
		/// 正常前景颜色
		/// </summary>
		public static Color ForeColor =SystemColors.ControlText;
		/// <summary>
		/// 长期医嘱背景颜色
		/// </summary>
		public static Color BackColorLongOrder =SystemColors.Window;//Thistle
		/// <summary>
		/// 临时医嘱背景颜色
		/// </summary>
		public static Color BackColorTemOrder =Color.Bisque;//LightGray;//SkyBlue;
		/// <summary>
		/// 0-新建状态前景色
		/// </summary>
		public static Color ForeColorOrderStatus0 =Color.Black;	
		/// <summary>
		/// 1-提交状态前景色
		/// </summary>
		public static Color ForeColorOrderStatus1 =Color.Blue;
		/// <summary>
		/// 2-执行状态前景色
		/// </summary>
		public static Color ForeColorOrderStatus2 =Color.Green;
		/// <summary>
		/// 3-停止状态前景色
		/// </summary>
		public static Color ForeColorOrderStatus3 =Color.Red;
		/// <summary>
		/// 4-重整状态前景色
		/// </summary>
		public static Color ForeColorOrderStatus4 =Color.Brown;
		/// <summary>
		/// 5-审核提交前景色
		/// </summary>
		public static Color ForeColorOrderStatus5 =Color.CornflowerBlue;
		/// <summary>
		/// 6-审核停止前景色
		/// </summary>
		public static Color ForeColorOrderStatus6 =Color.DarkRed;
		/// <summary>
		/// 7-退回前景色
		/// </summary>
		public static Color ForeColorOrderStatus7 =Color.DarkCyan;//Olive;
		/// <summary>
		/// -1作废状态前景色
		/// </summary>
		public static Color ForeColorOrderStatus_1 =Color.Yellow;
		/// <summary>
		/// 可以执行的医嘱前景色
		/// </summary>
		public static Color ForeColorCanExecute =Color.Teal;
		/// <summary>
		/// 不可执行的医嘱前景色
		/// </summary>
		public static Color ForeColorCanNotExecute =Color.Red;
		/// <summary>
		/// 可以执行的医嘱背景色
		/// </summary>
		public static Color BackColorCanExecute =SystemColors.GrayText;
		/// <summary>
		/// 不可执行的医嘱背景色
		/// </summary>
		public static Color BackColorCanNotExecute =SystemColors.Control;
		/// <summary>
		/// 余额超出费用下限的背景色
		/// </summary>
		public static Color BackColorChargeUnderLowerLimit =Color.Tomato;
		/// <summary>
		/// 余额超出费用下限的前景色
		/// </summary>
		public static Color ForeColorChargeUnderLowerLimit =Color.Green;
	}
	#endregion			

	#region clsGenerator
	public class clsGenerator
	{
		public static object CreateObject(System.Type objType)
		{
			return com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(objType);
		}
	}
	#endregion
	#region clsDoseTypeTextBox 用法
		
	public class clsDoseTypeTextBox:System.Windows.Forms.TextBox
	{
		private ListView m_objListView;
		private System.Windows.Forms.Form m_objForm;
		//private clsBIHOrderService m_objService=(clsBIHOrderService)(clsGenerator.CreateObject(typeof(clsBIHOrderService)));
        clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
		public clsDoseTypeTextBox():base()
		{
		}

		public void m_mthSetForm( System.Windows.Forms.Form  objForm)
		{			
			m_objForm=objForm;

			m_mthInitListView();

            //this.KeyDown += new KeyEventHandler(clsDoseTypeTextBox_KeyDown);
            //this.Enter += new EventHandler(clsDoseTypeTextBox_Enter);
            //this.Leave += new EventHandler(clsDoseTypeTextBox_Leave);
		}


		/// <summary>
		/// 获取被选中的用法
		/// </summary>
		public clsBSEUsageType[] SelectUsageType
		{
			get
			{
				 

				System.Collections.ArrayList arl=new System.Collections.ArrayList();
				for(int i=0;i<m_objListView.Items.Count;i++)
				{
					if(m_objListView.Items[i].Checked)
						arl.Add(m_objListView.Items[i].Tag);
				}

				return (clsBSEUsageType[])(arl.ToArray(typeof(clsBSEUsageType)));
			}
		}
		/// <summary>
		/// 获取或设置被选中的用法(通过ID)
		/// </summary>
		public string[] SelectUsageTypeIDs
		{
			get
			{
				clsBSEUsageType[] arrType=SelectUsageType;
				string[] arrID=new string[arrType.Length];
				for(int i=0;i<arrType.Length;i++)
				{
					arrID[i]=arrType[i].m_strUsageID;
				}
				return arrID;
			}
			set
			{
				if(value==null) value=new string[0];
				for(int i=0;i<m_objListView.Items.Count;i++)
				{
					clsBSEUsageType objType=(m_objListView.Items[i].Tag as clsBSEUsageType);
					if(objType==null) continue;
					string strTypeID=objType.m_strUsageID.Trim();
					m_objListView.Items[i].Checked=false;

					for(int j=0;j<value.Length;j++)
					{
						if(strTypeID==value[j].Trim())
						{
							m_objListView.Items[i].Checked=true;
							break;
						}
					}
				}
				m_mthRefreshText();
			}
		}

		private void m_mthInitListView()
		{
			m_objListView=new ListView();
			
			//
			m_objListView.Width=this.Width;
			m_objListView.Columns.Add( "用法名称",this.Width-30,HorizontalAlignment.Left);
			m_objListView.CheckBoxes=true;
			m_objListView.Visible=false;
			m_objListView.View=View.Details;
			m_objListView.Height=120;
			m_objListView.HeaderStyle=ColumnHeaderStyle.None;

			m_objListView.Leave +=new EventHandler(m_objListView_Leave);
			m_objListView.KeyDown +=new KeyEventHandler(m_objListView_KeyDown);
			//
			clsBSEUsageType[] arrType;
			long ret=m_objService.m_lngGetUsageType("",out arrType);
			if((ret>0) && (arrType!=null))
			{
				for(int i=0;i<arrType.Length;i++)
				{
					ListViewItem lvi=m_objListView.Items.Add(arrType[i].m_strUsageName);
					lvi.Tag=arrType[i];
				}
			}

			//
			m_objForm.Controls.Add(m_objListView);
			
		}

		private void clsDoseTypeTextBox_Enter(object sender, EventArgs e)
		{
			m_mthShowListView();
		}

		private void m_mthShowListView()
		{
			Point pt=this.Location;
			pt=this.Parent.PointToScreen(pt);
			if(pt.Y<700-m_objListView.Height)
			{
				pt=new Point(pt.X,pt.Y + this.Height);
			}
			else
			{
				pt=new Point(pt.X,pt.Y - m_objListView.Height);
			}
			
			//m_frmListView.Width=this.Width;
			pt=m_objForm.PointToClient(pt);
			m_objListView.Location=pt;
			m_objListView.Visible=true;
			m_objListView.BringToFront();
			
			m_objListView.Focus();
	
		}

		public void m_mthRefreshText()
		{
			string strText="";
			for(int i=0;i<m_objListView.Items.Count;i++)
			{
				if(m_objListView.Items[i].Checked)
				{
					if(strText.Length>0) strText += ";";
					strText += m_objListView.Items[i].Text.Trim();
				}
			}
			this.Text=strText;
		}
		
		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave (e);
	
			m_mthRefreshText();
		}

		private void m_objListView_Leave(object sender, EventArgs e)
		{
			if(!this.Focused)
			{
				m_objListView.Visible=false;
				m_mthRefreshText();
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown (e);
	
			if(e.KeyCode==Keys.Enter)
			{
				m_mthShowListView();
			}
			else if(e.KeyCode==Keys.Escape)
			{
				m_objListView.Visible=false;
			}
		}

		private void m_objListView_KeyDown(object sender, KeyEventArgs e)
		{
			if((e.KeyCode==Keys.Enter)||(e.KeyCode==Keys.Escape))
			{
				m_objListView_Leave(sender,e);
			}
		}
	}
	#endregion
	#region clsSelectBedControl 用法
	/// <summary>
	/// 病床控件
	/// 注意：分隔符为“,”号；
	/// </summary>	
	public class clsSelectBedControl:System.Windows.Forms.TextBox
	{
		#region 变量申明
		private ListView m_objListView;
		System.Windows.Forms.Form m_objForm;
		/// <summary>
		/// 病区ID
		/// </summary>
		private string m_strAreaID ="";
		private clsDcl_InputOrder m_objManage = new clsDcl_InputOrder();
		#endregion

		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public clsSelectBedControl():base()
		{
		}
		#endregion
		#region 属性
		/// <summary>
		/// 获取被选中的病床对象
		/// </summary>
		public clsT_Bse_Bed_VO[] m_GetSelectBed
		{
			get
			{
				System.Collections.ArrayList arl=new System.Collections.ArrayList();
				for(int i=0;i<m_objListView.Items.Count;i++)
				{
					if(m_objListView.Items[i].Checked)
						arl.Add(m_objListView.Items[i].Tag);
				}
				return (clsT_Bse_Bed_VO[])(arl.ToArray(typeof(clsT_Bse_Bed_VO)));
			}
		}
		/// <summary>
		/// 获取或设置选中的病床	[病床ID]
		/// </summary>
		public string[] m_SelectBed
		{
			get
			{
				clsT_Bse_Bed_VO[] objItemArr =m_GetSelectBed;
				string[] strBedIDArr =new string[objItemArr.Length];
				for(int i=0;i<strBedIDArr.Length;i++)
				{
					strBedIDArr[i]=objItemArr[i].m_strBEDID_CHR;
				}
				return strBedIDArr;
			}
			set
			{
				if(value==null) value=new string[0];
				for(int i=0;i<m_objListView.Items.Count;i++)
				{
					clsT_Bse_Bed_VO objItem =(m_objListView.Items[i].Tag as clsT_Bse_Bed_VO);
					if(objItem==null) continue;
					string stBedID =objItem.m_strBEDID_CHR.Trim();
					m_objListView.Items[i].Checked =false;
					for(int j=0;j<value.Length;j++)
					{
						if(stBedID==value[j].Trim())
						{
							m_objListView.Items[i].Checked=true;
							break;
						}
					}
				}
				m_mthRefreshText();
			}
		}

		public string m_SetAreaID
		{
			set
			{
				m_strAreaID =value;
				LoadListViewItem(m_strAreaID);
			}
		}
		#endregion
		#region 私有方法
		/// <summary>
		/// 初始化控件
		/// </summary>
		public void InitControl(System.Windows.Forms.Form objForm)
		{
			//
			m_objForm =objForm;

			m_objListView=new ListView();
			m_objListView.Width=this.Width;
			m_objListView.Columns.Add( "床号",this.Width-30,HorizontalAlignment.Left);
			m_objListView.CheckBoxes=true;
			m_objListView.Visible=true;
			m_objListView.View=View.Details;
			m_objListView.Height=120;
			m_objListView.HeaderStyle=ColumnHeaderStyle.None;
			m_objListView.Leave +=new EventHandler(m_objListView_Leave);
			m_objListView.KeyDown +=new KeyEventHandler(m_objListView_KeyDown);

			m_objForm.Controls.Add(m_objListView);			
		}
		private void LoadListViewItem(string p_strAreaID)
		{
			m_objListView.Items.Clear();
			if(p_strAreaID==null || p_strAreaID.Trim()=="") return;
			clsT_Bse_Bed_VO[] objItemArr;			
			long lngRes =m_objManage.m_lngGetBedInfoByAreaID(m_strAreaID,out objItemArr);
			if(lngRes>0 && objItemArr!=null)
			{
				for(int i=0;i<objItemArr.Length;i++)
				{
					ListViewItem lvi=m_objListView.Items.Add(objItemArr[i].m_strCODE_CHR);
					lvi.Tag=objItemArr[i];
				}
			}
		}
		private void m_mthShowListView()
		{
			Point pt=this.Location;
			pt=this.Parent.PointToScreen(pt);
			int intHeight =this.Parent.Height;
			
			if(pt.Y<intHeight-m_objListView.Height)
			{
				pt=new Point(pt.X,pt.Y + this.Height);
			}
			else
			{
				pt=new Point(pt.X,pt.Y - m_objListView.Height);
			}			
			pt=m_objForm.PointToClient(pt);
			m_objListView.Location=pt;
			m_objListView.Visible=true;
			m_objListView.BringToFront();			
			m_objListView.Focus();
		}

		private void clsDoseTypeTextBox_Enter(object sender, EventArgs e)
		{
			m_mthShowListView();
		}
		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave (e);	
			m_mthRefreshText();
		}
		private void m_objListView_Leave(object sender, EventArgs e)
		{
			if(!this.Focused)
			{
				m_objForm.Visible=false;
				m_mthRefreshText();
			}
		}
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown (e);
	
			if(e.KeyCode==Keys.Enter)
			{
				m_mthShowListView();
			}
			else if(e.KeyCode==Keys.Escape)
			{
				m_objForm.Visible=false;
			}
		}
		private void m_objListView_KeyDown(object sender, KeyEventArgs e)
		{
			if((e.KeyCode==Keys.Enter)||(e.KeyCode==Keys.Escape))
			{
				m_objListView_Leave(sender,e);
			}
		}
		private void m_mthRefreshText()
		{
			string strText="";
			for(int i=0;i<m_objListView.Items.Count;i++)
			{
				if(m_objListView.Items[i].Checked)
				{
					if(strText.Length>0) strText += ",";
					strText += m_objListView.Items[i].Text.Trim();
				}
			}
			this.Text=strText;
		}		
		#endregion
	}
	#endregion

	#region 医嘱类型处理
	/// <summary>
	/// 医嘱类型处理
	/// </summary>
	public class  clsOrderDicCates
	{
		private static clsBIHOrderCate[] s_arrCate=null;
		private clsBIHOrderService objObject;
		public clsOrderDicCates()
		{
            objObject = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));			
			long ret=objObject.m_lngGetOrderCate(out s_arrCate);
			if(ret<=0) s_arrCate=null;
		}

        /// <summary>
        /// 用于检查类型表再次读取时是否出现了更新
        /// </summary>
        public static bool Cate_tag = false;
		/// <summary>
		/// 重新获取医嘱类型Vo
		/// </summary>
        private static void s_initCate()
        { 
            long ret = 1;
            clsBIHOrderCate[] s_arrCate_temp = null;
            if (!Cate_tag||s_arrCate==null)
            {
                com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
                ret = objSvc.m_lngGetOrderCate(out s_arrCate_temp);
                if (ret > 0 &&s_arrCate!=null&& s_arrCate.Length > 0 && s_arrCate.Length == s_arrCate_temp.Length)
                {
                    for (int i = 0; i < s_arrCate.Length; i++)
                    {
                        if (s_arrCate[i].m_intISATTACH_INT == s_arrCate_temp[i].m_intISATTACH_INT
                       && s_arrCate[i].m_strCLASSNAME_VCHR.Equals(s_arrCate_temp[i].m_strCLASSNAME_VCHR)
                       && s_arrCate[i].m_strDes.Equals(s_arrCate_temp[i].m_strDes)
                       && s_arrCate[i].m_strDLLNAME_VCHR.Equals(s_arrCate_temp[i].m_strDLLNAME_VCHR)
                       && s_arrCate[i].m_strName.Equals(s_arrCate_temp[i].m_strName)
                       && s_arrCate[i].m_strOPRADD_VCHR.Equals(s_arrCate_temp[i].m_strOPRADD_VCHR)
                       && s_arrCate[i].m_strOPRUPD_VCHR.Equals(s_arrCate_temp[i].m_strOPRUPD_VCHR)
                       && s_arrCate[i].m_strOrderCateID.Equals(s_arrCate_temp[i].m_strOrderCateID)
                       && s_arrCate[i].m_strSourceTable.Equals(s_arrCate_temp[i].m_strSourceTable)
                       && s_arrCate[i].m_strTABLEPK_VCHR.Equals(s_arrCate_temp[i].m_strTABLEPK_VCHR))
                        {

                            Cate_tag = true;
                        }
                        else
                        {
                            Cate_tag = false;
                            break;
                        }

                    }
                }

                s_arrCate = s_arrCate_temp;

            }
            /*<------------------------*/

            if (ret <= 0) s_arrCate = null;
        }
		/// <summary>
		/// 获取是否可以有附加单据	根据附加单据流水号
		/// </summary>
		/// <param name="strCateID">附加单据流水号</param>
		/// <returns></returns>
		public static bool IsMedOrder(string strCateID)
		{
			s_initCate();//必须重新获取数据
			for(int i1=0;i1<s_arrCate.Length;i1++)
			{
				if(s_arrCate[i1].m_strOrderCateID.ToString().Trim()==strCateID.Trim() && s_arrCate[i1].m_intISATTACH_INT==1)
				{
					return true;
				}
			}
			return false;
		}
		/// <summary>
		/// 获取附加单据Vo对象	根据附加单据流水号
		/// </summary>
		/// <param name="strCateID">附加单据流水号</param>
		/// <returns></returns>
		public static clsBIHOrderCate m_objGetCate(string strCateID)
		{
			s_initCate();
			if(s_arrCate==null) return null;

			for(int i=0;i<s_arrCate.Length;i++)
			{
				if(s_arrCate[i].m_strOrderCateID==strCateID.Trim())
				{
					return s_arrCate[i];
				}
			}
			return null;
		}
	}
	#endregion	
	#region 皮试编辑类
	/// <summary>
	/// 用于皮试编辑	{作为父子窗口的桥梁}
	/// </summary>
	public class clsFeelEdit
	{
		public clsFeelEdit()
		{}	
		#region 入参
		/// <summary>
		/// 医嘱ID
		/// </summary>
		public string m_strOrderID ="";				
		/// <summary>
		/// 病人姓名
		/// </summary>
		public string m_strPatientName ="";
		/// <summary>
		/// 医嘱名称
		/// </summary>
		public string m_strOrderName ="";
		#endregion
		#region 出参
		/// <summary>
		/// 推出状态	{0=执行错误或没有操作退出	1=执行成功推出}
		/// </summary>
		public int m_intExitState =0;
		/// <summary>
		/// 皮试结果	{阴性、阳性}
		/// </summary>
		public string m_strFeelResult ="";
		/// <summary>
		/// 皮试结果	{1=阴性、2=阳性}
		/// </summary>
		public int m_intFeelResult =0;		
		#endregion
	}
	#endregion
}
