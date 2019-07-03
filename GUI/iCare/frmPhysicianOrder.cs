using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
//using com.digitalwave.DataService;
using com.digitalwave.Utility;
using com.digitalwave.Utility.Controls ;
using iCare;
using iCareData;
using com.digitalwave.PhysicianOrderService;
namespace iCare
{

	public class frmPhysicianOrder : iCare.frmHRPBaseForm,PublicFunction
	{
		#region system define
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpStartDate;
		private System.Windows.Forms.GroupBox m_grbPhysicianOrder;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboUsage;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.Label label2;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboFrequency;
		private System.Windows.Forms.ListView m_lsvMedical;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtMedicalDose;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button m_cmdOK;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtQuery;
		private System.Windows.Forms.CheckBox m_chkIsSubPhysicainOrder;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboPhysicianOrderType;
		private System.Windows.Forms.Label label4;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboQueryType;
		private System.Windows.Forms.ListView m_lsvPhysicianOrder;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.ColumnHeader columnHeader17;
		private System.Windows.Forms.ColumnHeader columnHeader18;
		private System.Windows.Forms.ColumnHeader columnHeader19;
		private System.Windows.Forms.ColumnHeader columnHeader20;
		private System.Windows.Forms.ColumnHeader columnHeader21;
		private System.Windows.Forms.ColumnHeader columnHeader22;
		private System.Windows.Forms.ColumnHeader columnHeader23;
		private System.Windows.Forms.ColumnHeader columnHeader25;
		private System.Windows.Forms.ColumnHeader columnHeader26;
		private System.Windows.Forms.ColumnHeader columnHeader27;
		private System.Windows.Forms.ColumnHeader columnHeader28;
		private System.Windows.Forms.GroupBox m_grbTempPhysicianOrder;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTempQueryType;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTempPhysicianOrderType;
		private System.Windows.Forms.CheckBox m_chkTempIsSubPhysicainOrder;
		private System.Windows.Forms.Button m_cmdTempOK;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTempMedicalDose;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTempUsage;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTempFrequency;
		private System.Windows.Forms.ListView m_lsvTempMedical;
		private System.Windows.Forms.ListView m_lsvTempPhysicianOrder;
		private System.Windows.Forms.ColumnHeader columnHeader31;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpTempStartDate;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button m_cmdSubmit;
		private System.Windows.Forms.TabControl m_tabPhysicianOrder;
		private System.Windows.Forms.TabPage m_tbpLongTermPhycianOrder;
		private System.Windows.Forms.TabPage m_tbpShortTermPhycianOrder;
		private System.Windows.Forms.TabPage m_tbpPhysicianOrderList;
		private System.Windows.Forms.ColumnHeader columnHeader41;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboMedicineStandard;
		protected System.Windows.Forms.ListView m_lsvLongTermQuery;
		private System.Windows.Forms.ColumnHeader clmPatientName_BaseForm;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpEndDate;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtRemark;
		private System.Windows.Forms.Label label14;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTempMedicineStandard;
		private System.Windows.Forms.Button m_cmdTempSubmit;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTempRemark;
		private System.Windows.Forms.ColumnHeader columnHeader42;
		protected System.Windows.Forms.ListView m_lsvTempQuery;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTemptQuery;
		private System.Windows.Forms.TabPage m_tbpNurseHandle;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ColumnHeader columnHeader29;
		private System.Windows.Forms.ColumnHeader columnHeader30;
		private System.Windows.Forms.ColumnHeader columnHeader43;
		private System.Windows.Forms.ColumnHeader columnHeader44;
		private System.Windows.Forms.ColumnHeader columnHeader45;
		private System.Windows.Forms.ColumnHeader columnHeader49;
		private System.Windows.Forms.ToolTip m_tooltipLsv;
		private System.Windows.Forms.ListView m_lsvNursePhysicianOrder;
		private System.Windows.Forms.GroupBox m_grbNursePhysicianOrder;
		private System.Windows.Forms.RadioButton m_rdbNurseNotConfirmed;
		private System.Windows.Forms.RadioButton m_rdbNurseNotPerformed;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpNursePerformDate;
		private System.Windows.Forms.Label m_lblNursePerformDateTitle;
		private System.Windows.Forms.Button m_cmdNurseSetPerformed;
		private System.Windows.Forms.Label m_lblNurseAddInTitle;
		private System.Windows.Forms.Button m_cmdSetConfirmed;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpToDate;
		private System.Windows.Forms.Label label9;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboOrderPerform;
		private System.Windows.Forms.Label label12;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboOrderEnd;
		private System.Windows.Forms.Label label13;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboOrderCancel;
		private System.Windows.Forms.Label label17;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboOrderApprove;
		private System.Windows.Forms.Label label18;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboOrderListType;
		private System.Windows.Forms.Button m_cmdOrderQuery;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpFromDate;
		private System.Windows.Forms.ListView m_lstPhysicianOrderList;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader24;
		private System.Windows.Forms.ColumnHeader columnHeader32;
		private System.Windows.Forms.ColumnHeader columnHeader33;
		private System.Windows.Forms.ColumnHeader columnHeader34;
		private System.Windows.Forms.ColumnHeader columnHeader35;
		private System.Windows.Forms.ColumnHeader columnHeader36;
		private System.Windows.Forms.ColumnHeader columnHeader37;
		private System.Windows.Forms.ColumnHeader columnHeader38;
		private System.Windows.Forms.ColumnHeader columnHeader39;
		private System.Windows.Forms.ColumnHeader columnHeader40;
		private System.Windows.Forms.Button button1;
		protected System.Windows.Forms.ListView m_lsvNurseAddIn;
		private System.Windows.Forms.ColumnHeader columnHeader46;
		private System.Windows.Forms.Button m_cmdNurseDisplayAddIn;
		private System.Windows.Forms.NumericUpDown m_objNurseNumericInc;
		private System.Windows.Forms.ColumnHeader columnHeader47;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ContextMenu m_ctnPhysicianOrderList;
		private System.Windows.Forms.MenuItem m_mniCancelOrderList;
		private System.Windows.Forms.MenuItem m_mniEndOrderList;
		private System.Windows.Forms.TabPage m_tabPhysicianOrderTemplateSet;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.ColumnHeader columnHeader57;
		private System.Windows.Forms.ColumnHeader columnHeader58;
		private System.Windows.Forms.ColumnHeader columnHeader59;
		private System.Windows.Forms.ColumnHeader columnHeader60;
		private System.Windows.Forms.ColumnHeader columnHeader61;
		private System.Windows.Forms.ColumnHeader columnHeader62;
		private System.Windows.Forms.Label label21;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboXStandardID;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboXOrderTypeID;
		private System.Windows.Forms.CheckBox m_chkBeChild;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtDosage;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboXUsageID;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboXFrequencyID;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtName;
		private System.Windows.Forms.Label m_laIndicator;
		private System.Windows.Forms.Label m_labXItemUnitID;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboXOrderFlag;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboSelectMethod;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtGetSelectKeyWord;
		protected System.Windows.Forms.ListView m_lstResultSet;
		private System.Windows.Forms.ColumnHeader columnHeader63;
		private System.Windows.Forms.Label m_labName;
		private System.Windows.Forms.Label m_labType;
		private System.Windows.Forms.ListView m_lsvTemplateContent;
		private System.Windows.Forms.TreeView m_trvPOTemplate;
		private System.Windows.Forms.ColumnHeader columnHeader65;
		private System.Windows.Forms.ColumnHeader columnHeader66;
		private System.Windows.Forms.ColumnHeader columnHeader67;
		private System.Windows.Forms.ColumnHeader columnHeader68;
		private System.Windows.Forms.ColumnHeader columnHeader69;
		private System.Windows.Forms.ColumnHeader columnHeader70;
		private System.Windows.Forms.ColumnHeader columnHeader71;
		private System.Windows.Forms.ColumnHeader columnHeader72;
		private System.Windows.Forms.ColumnHeader columnHeader73;
		private System.Windows.Forms.Button m_cmdAddTempRecord;
		private System.Windows.Forms.Button m_cmdAlterTempRecord;
		private System.Windows.Forms.Button m_cmdApplyToTemp;
		private System.Windows.Forms.Button m_cmdDeltteTemp;
		private System.Windows.Forms.ColumnHeader columnHeader48;
		private System.ComponentModel.IContainer components = null;
		#endregion
		public frmPhysicianOrder()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

			m_objEditAddIn =new clsNumericListView(m_lsvNurseAddIn,m_objNurseNumericInc,null);
			

			m_rdbNurseNotConfirmed.Checked=true;

			m_dtbNursePhysicianOrder.Columns.Add("dcmChecked",typeof(bool));
			m_dtbNursePhysicianOrder.Columns.Add("dcmName");
			m_dtbNursePhysicianOrder.Columns.Add("dcmNumber",typeof(int));
			//			m_dtgNurseAddIn.DataSource=m_dtbNursePhysicianOrder;


			m_lsvLongTermQuery.LostFocus+=new EventHandler(m_mthEvent_LsvLostFocus);
			m_lsvTempQuery.LostFocus+=new EventHandler(m_mthEvent_LsvLostFocus);
			
			this.m_lsvPhysicianOrder.Items.Clear ();
  
			#region 自动定位相关控件,刘颖源,2003-6-25 15:32:26
			this.m_txtMedicalDose.BringToFront ();
			this.m_txtMedicalDose.Width =this.m_lsvMedical.Columns[2].Width ;
			this.m_txtMedicalDose.Left =this.m_lsvMedical.Left   + this.m_lsvMedical.Columns[0].Width + this.m_lsvMedical.Columns[1].Width -2;
			//  
			//			this.m_cboMedicalUnit.BringToFront ();
			//			this.m_cboMedicalUnit.Width =this.m_lsvMedical.Columns[3].Width -1;
			//			this.m_cboMedicalUnit.Left = this.m_lsvMedical.Left   + this.m_lsvMedical.Columns[0].Width + this.m_lsvMedical.Columns[1].Width + this.m_lsvMedical.Columns[2].Width;

			this.m_cboUsage.BringToFront ();
			this.m_cboUsage.Width =this.m_lsvMedical.Columns[4].Width -1;
			this.m_cboUsage.Left = this.m_lsvMedical.Left   + this.m_lsvMedical.Columns[0].Width + this.m_lsvMedical.Columns[1].Width + this.m_lsvMedical.Columns[2].Width + this.m_lsvMedical.Columns[3].Width;

			this.m_cboFrequency.BringToFront ();
			this.m_cboFrequency.Width =this.m_lsvMedical.Columns[5].Width -1 ;
			this.m_cboFrequency.Left = this.m_lsvMedical.Left   + this.m_lsvMedical.Columns[0].Width + this.m_lsvMedical.Columns[1].Width + this.m_lsvMedical.Columns[2].Width + + this.m_lsvMedical.Columns[3].Width + this.m_lsvMedical.Columns[4].Width;



			#endregion
			//			this.m_cboMedicalUnit.AddItem ("ml"); 
			//			this.m_cboMedicalUnit.AddItem ("g"); 

			//			this.m_cboUsage.AddItem ("滴注");
			//			this.m_cboUsage.AddItem ("口服");
			//
			//			this.m_cboFrequency.AddItem ("Qd");
			//			this.m_cboFrequency.AddItem ("Tid");

			m_cboQueryType.AddRangeItems(new string[]{"按拼音码查询","按拉丁名查询","按英文名查询","按药ID查询"});
			m_cboTempQueryType.AddRangeItems(new string[]{"按拼音码查询","按拉丁名查询","按英文名查询","按药ID查询"});

			m_mthSetQuickKeys();

			
			
			m_lsvMedical.Items.Clear();
			m_lsvMedical.Items.Add(new ListViewItem(new string[]{"","","","","",""}));
			m_lsvTempMedical.Items.Clear();
			m_lsvTempMedical.Items.Add(new ListViewItem(new string[]{"","","","","",""}));


			m_mthInitInfo();
			//下面这两个函数必须在m_mthInitInfo()之后执行
			m_mthFillShortTermOrderComboBox();
			m_mthFillLongTermOrderComboBox();
			m_mthNurseFillInitDataGrid();

			#region 刘颖源添加，初始化医嘱列表界面
			this.m_cboOrderApprove.AddItem ("等待校对");
			this.m_cboOrderApprove.AddItem ("已经校对");
			this.m_cboOrderApprove.AddItem ("全部");
			this.m_cboOrderApprove.SelectedIndex =2;

			this.m_cboOrderCancel.AddItem ("未作废");
			this.m_cboOrderCancel.AddItem ("已作废"); 
			this.m_cboOrderCancel.AddItem ("全部");
			this.m_cboOrderCancel.SelectedIndex =2;

			this.m_cboOrderEnd.AddItem ("未停止");
			this.m_cboOrderEnd.AddItem ("已停止");
			this.m_cboOrderEnd.AddItem ("全部");
			this.m_cboOrderEnd.SelectedIndex =2;

			this.m_cboOrderListType.AddItem ("长期医嘱");
			this.m_cboOrderListType.AddItem ("临时医嘱");
			this.m_cboOrderListType.AddItem ("备用长期医嘱");
			this.m_cboOrderListType.AddItem ("备用临时医嘱");
			this.m_cboOrderListType.AddItem ("全部");
			this.m_cboOrderListType.SelectedIndex =4;

			this.m_cboOrderPerform.AddItem("未执行");
			this.m_cboOrderPerform.AddItem ("已执行");
			this.m_cboOrderPerform.AddItem ("全部");
			this.m_cboOrderPerform.SelectedIndex =2;

			
			#endregion
		}


		#region 成员变量,刘颖源,2003-6-25 15:32:26
		
		private DataTable m_dtbNursePhysicianOrder=new DataTable("dtgNurseAddIn");
		
		

		clsPhysicianOrderDomain m_objDomain=new clsPhysicianOrderDomain();

		clsPhysicianOrderTypeValue[] m_objOrderTypeArr=null;
		clsPhysicianOrderUsageValue [] m_objOrderUsageArr=null;
		clsPhysicianOrderAddInInfoValue [] m_objAddInInfoArr=null;
		clsPhysicianOrderFrequencyInfoValue[] m_objFrequencyInfoArr=null;
		clsPhysicianOrderMedicineStandardValue [] m_objMedicineStandardArr=null;
		
		private bool m_blnNurseIsUnconfirmed=true;
		private clsNumericListView m_objEditAddIn=null;

		/// <summary>
		/// 记录当前的行的信息，每次添加到ListView后都要新new 一个。
		/// </summary>
		clsNewOrderRowInfo m_objCurrentNewOrderRowInfo=new clsNewOrderRowInfo();

		/// <summary>
		/// 记录当前添加的医嘱是否上一条的子医嘱
		/// </summary>
		private bool m_blnIsSubOrder=false;

		/// <summary>
		/// 指示当前显示查询用的ListView
		/// </summary>
		private ListView m_lsvCurrentQueryLsv=new ListView();
		private ctlBorderTextBox m_txtCurrentTextBox=new ctlBorderTextBox();
		

		/// <summary>
		/// 记录当前用LisvView查询时查到第几层
		/// </summary>
		private int m_intCurrentLevel=0;

		#endregion

		#region 添加Keydown事件
		private void m_mthSetQuickKeys()
		{			
			m_mthSetControlEvent(this);			
		}
		
		private void m_mthSetControlEvent(Control p_ctlControl)
		{
			#region 利用递归调用，读取并设置所有界面事件	
			string strTypeName = p_ctlControl.GetType().Name;
			if(strTypeName != "Lable" && strTypeName != "Button")
			{
				p_ctlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);

				if(p_ctlControl.HasChildren && strTypeName !="DataGrid" && strTypeName !="DateTimePicker" && strTypeName !="ctlComboBox")
				{									
					foreach(Control subcontrol in p_ctlControl.Controls)
					{				
						string strSubTypeName = subcontrol.GetType().Name;
						//						if(strSubTypeName=="ScrollBar") return;
						if(strSubTypeName != "Lable" && strSubTypeName != "Button")												
							m_mthSetControlEvent(subcontrol);	
						
					} 	
				}				
			}			
			#endregion
		}
		#endregion

		#region Override
		/// <summary>
		/// 本窗体中无需处理病人号改变事件
		/// </summary>
		protected override bool m_BlnCanTextChanged
		{
			get
			{
				return false;
			}
		}


		protected override bool m_BlnIsAddNew
		{
			get
			{
				return true;
			}
		}

		protected override iCare.enmFormState m_EnmCurrentFormState
		{
			get
			{
				return enmFormState.NowUser ;
			}
		}

		protected override void m_mthSetPatientFormInfo(iCare.clsPatient p_objSelectedPatient)
		{
			m_objBaseCurrentPatient=p_objSelectedPatient;
			if(m_blnNurseIsUnconfirmed)
			{
				m_mthNurseLoadUnconfirmedOrder();
			}
			else
			{
				m_mthNurseLoadUnperformedOrder();
			}
			
		}

		protected override long m_lngSubAddNew()
		{
			return 1;
		}

		protected override long m_lngSubPrint()
		{
			return 1;
		}
		protected override long m_lngSubDelete()
		{	
			return 1 ;
		}
		#endregion

		#region Public Function
		public void Copy()
		{
			m_lngCopy();
		}

		public void Cut()
		{
			m_lngCut();
		}

		public void Delete()
		{
			m_lngDelete();
		}
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		public void Display()
		{
		
		}

		public void Display(string cardno, string sendcheckdate)
		{
		
		}

		public void Paste()
		{
			m_lngPaste();
		}

		public void Print()
		{
			//			this.m_lngPrint();
		}

		public void Redo()
		{
		
		}

		public void Save()
		{
			this.m_lngSave();
		}

		public void Undo()
		{
		
		}
		#endregion




		private void m_mthInitInfo()
		{
			long lngRes=m_objDomain.m_lngGetAllPhysicianOrderType(out m_objOrderTypeArr);
			if(lngRes<=0) m_objOrderTypeArr=null;
			lngRes=m_objDomain.m_lngGetAllPhysicianOrderUsage(out m_objOrderUsageArr);
			if(lngRes<=0) m_objOrderUsageArr=null;
			lngRes=m_objDomain.m_lngGetAllPhysicianOrderAddInInfo(out m_objAddInInfoArr);
			if(lngRes<=0) m_objAddInInfoArr=null;
			lngRes=m_objDomain.m_lngGetAllPhysicianOrderFrequencyInfo(out m_objFrequencyInfoArr);
			if(lngRes<=0) m_objFrequencyInfoArr=null;


		}

		//		clsPhysicianOrderBaseValue [] m_objBaseValue=null;

		


		private void m_ShowMessage(string p_strMsg)
		{
			if(p_strMsg==null || p_strMsg.Trim().Length==0) return ;
			clsPublicFunction.ShowInformationMessageBox(p_strMsg);
		}
		private bool m_blnIsEmptyString(string p_str)
		{
			if(p_str==null || p_str.Trim().Length==0) return true;
			else return false;
		}


		/// <summary>
		/// 给医嘱列表添加子医嘱符号，仅用于医嘱列表和护士工作站
		/// </summary>
		/// <param name="p_lsv">需要加子医嘱符号的Listview</param>
		private void m_mthAddSubOrderSign(ListView p_lsv)
		{
			if(p_lsv==null) return;
			for(int i=0;i<p_lsv.Items.Count;i++)
			{
				// Tag 为null就是子医嘱
				if(i+1<p_lsv.Items.Count && p_lsv.Items[i].Tag!=null && p_lsv.Items[i+1].Tag==null)
				{
					p_lsv.Items[i].SubItems[3].Text=m_strAddSubOrderSignString(p_lsv.Items[i].SubItems[3].Text,"┑");
					//					p_lsv.Items[i+1].SubItems[3].Text=m_strAddSubOrderSignString(p_lsv.Items[i+1].SubItems[3].Text,"┙");
					i++;
					do
					{
						
						if(i+1==p_lsv.Items.Count || p_lsv.Items[i+1].Tag!=null)
						{
							p_lsv.Items[i].SubItems[3].Text=m_strAddSubOrderSignString(p_lsv.Items[i].SubItems[3].Text,"┙");
						}
						else
						{
							p_lsv.Items[i].SubItems[3].Text=m_strAddSubOrderSignString(p_lsv.Items[i].SubItems[3].Text,"│");
						}
						i++;
					
					}while(i<p_lsv.Items.Count && p_lsv.Items[i].Tag==null);
					i--;

				}
			}
		}

		private string m_strAddSubOrderSignString(string p_str, string p_strSign)
		{
			if(p_str==null || p_str.Trim().Length==0)
			{
				p_str="              ";
			}
			else
			{
				p_str=p_str.Trim()+"              ";
				p_str=p_str.Substring(0,14);
			}
			p_str+=p_strSign;
			return p_str;
		}

		#region 医嘱列表

		private void m_mthLoadAllCombinationList()
		{
			if(m_objBaseCurrentPatient==null || m_objBaseCurrentPatient.m_ObjInBedInfo==null
				|| m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo==null
				|| m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate==DateTime.MinValue)
			{
				m_ShowMessage("你还没选择病人。");
				return;
			}
			
			int intOrderList=this.m_cboOrderListType.SelectedIndex ;
			int intConfirm=this.m_cboOrderApprove.SelectedIndex ;
			int intCancel =this.m_cboOrderCancel.SelectedIndex ;
			int intEnd =this.m_cboOrderEnd.SelectedIndex ;
			int intPerformed =this.m_cboOrderPerform.SelectedIndex ;
			string strFromDate=this.m_dtpFromDate.Value.ToString ("yyyy-MM-dd HH:mm:ss");
			string strToDate=this.m_dtpToDate.Value.ToString ("yyyy-MM-dd HH:mm:ss");

			clsPhysicianOrderDetailListValue  [] objDetailListValueArr=null;
		
			this.m_lstPhysicianOrderList.Items.Clear (); 
			long lngRes=m_objDomain.m_lngGetAllCombinationPhysicianOrder (m_objBaseCurrentPatient.m_StrInPatientID,
				m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss"), intOrderList ,intConfirm ,intCancel ,intEnd ,intPerformed ,strFromDate,strToDate , out objDetailListValueArr);
			if(objDetailListValueArr==null || objDetailListValueArr.Length <=0)return;

			string strCurrentOpendate="",strCurrentOrderID="",strCurrentSubOrderID="";//strCurrentAddItemID="";
			ArrayList arlAddIn=new ArrayList();
			
			int intMainRecordIndex=-1;
			int intSubOrderNum=-1;
			
			for(int i=0;i<objDetailListValueArr.Length;i++)
			{
				
				if(strCurrentOpendate!=objDetailListValueArr[i].m_strOpenDate
					|| strCurrentOrderID!=objDetailListValueArr[i].m_strOrderID)
				{
					//					if(intMainRecordIndex!=-1)
					//					{
					//						((clsNurseConfirmInfo)m_lstPhysicianOrderList.Items[intMainRecordIndex].Tag).objAddInValueArr=(clsPhysicianOrderAddInValue[])arlAddIn.ToArray(typeof(clsPhysicianOrderAddInValue));
					//						arlAddIn.Clear();
					//						strCurrentAddItemID="";
					//						if(!m_blnIsEmptyString(m_lstPhysicianOrderList.Items[intMainRecordIndex].SubItems[7].Text))
					//						{
					//							m_lstPhysicianOrderList.Items[intMainRecordIndex].SubItems[7].Text
					//								=m_lstPhysicianOrderList.Items[intMainRecordIndex].SubItems[7].Text.Substring(0,m_lstPhysicianOrderList.Items[intMainRecordIndex].SubItems[7].Text.Length-1);
					//						}
					//						
					//					}

					intSubOrderNum=-1;
					clsNurseConfirmInfo objConfirmInfo=new clsNurseConfirmInfo();
					
					strCurrentOpendate=objDetailListValueArr[i].m_strOpenDate;
					strCurrentOrderID=objDetailListValueArr[i].m_strOrderID;
					strCurrentSubOrderID=objDetailListValueArr[i].m_strSubOrderID;
					objConfirmInfo.m_intSubOrderFlag=0;
					objConfirmInfo.m_strInPatientDate=m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss");
					objConfirmInfo.m_strInPatientID=m_objBaseCurrentPatient.m_StrInPatientID;
					objConfirmInfo.m_strOpenDate=strCurrentOpendate;
					objConfirmInfo.m_strOrderID=strCurrentOrderID;
					objConfirmInfo.m_blnIfConfirmed=objDetailListValueArr[i].m_strIfConfirm== "1" ? true : false;
					objConfirmInfo.m_blnIfPerformed=objDetailListValueArr[i].m_strIfPerformed== "1" ? true : false;
					objConfirmInfo.m_blnIfEnded=objDetailListValueArr[i].m_strIfEnd== "1" ? true : false;
					objConfirmInfo.m_blnIfCanceled=objDetailListValueArr[i].m_strIfCancel== "1" ? true : false;
					
					//Add ListView Item
					ListViewItem objLsvItem=new ListViewItem(new string[]{"","","","","","","",""});
					objLsvItem.SubItems[0].Text=objDetailListValueArr[i].m_strOrderFlag=="0" ? "长" : "临";
					objLsvItem.SubItems[1].Text=objDetailListValueArr[i].m_strStartDate;
					if(objDetailListValueArr[i].m_strOrderTypeID=="007")
					{
						objLsvItem.SubItems[2].Text=objDetailListValueArr[i].m_strMedicineName;
						objLsvItem.SubItems[3].Text=objDetailListValueArr[i].m_strItemDosage;
					}
					else
					{
						objLsvItem.SubItems[2].Text=objDetailListValueArr[i].m_strDetailName;
					}
					objLsvItem.SubItems[4].Text=objDetailListValueArr[i].m_strUsageName;
					objLsvItem.SubItems[5].Text=objDetailListValueArr[i].m_strFrequencyName;
					objLsvItem.SubItems[6].Text=objDetailListValueArr[i].m_strRemark;
					try
					{
						if(objDetailListValueArr[i].m_strActualEndDate!= null && objDetailListValueArr[i].m_strActualEndDate.Trim().Length!= 0 && DateTime.Parse( objDetailListValueArr[i].m_strActualEndDate)!=(DateTime.Parse("1900-1-1")))
						{
							objLsvItem.SubItems[7].Text=objDetailListValueArr[i].m_strActualEndDate;
						}
					}
					catch
					{
					}
					if(objDetailListValueArr[i].m_strActualEndUserID!=null && objDetailListValueArr[i].m_strActualEndUserID.Trim().Length!=0)
					{
						clsPatient objTempPatient=new clsPatient( objDetailListValueArr[i].m_strActualEndUserID);
						if(objTempPatient!=null && objTempPatient.m_ObjPeopleInfo!=null)
							objLsvItem.SubItems[8].Text=objTempPatient.m_ObjPeopleInfo.m_StrFirstName;
					}
					//附加物暂不显示

					
					objLsvItem.Tag=objConfirmInfo;
					m_lstPhysicianOrderList.Items.Add(objLsvItem);
					intMainRecordIndex=m_lstPhysicianOrderList.Items.Count-1;
					//					});
				}
				else
				{

					if(strCurrentSubOrderID!=objDetailListValueArr[i].m_strSubOrderID)
					{
						intSubOrderNum++;
						strCurrentSubOrderID=objDetailListValueArr[i].m_strSubOrderID;
						ListViewItem objLsvItem=new ListViewItem(new string[]{"","","","","","","",""});
						if(objDetailListValueArr[i].m_strOrderTypeID=="007")
						{
							objLsvItem.SubItems[2].Text=objDetailListValueArr[i].m_strMedicineName;
							objLsvItem.SubItems[3].Text=objDetailListValueArr[i].m_strItemDosage;
						}
						else
						{
							objLsvItem.SubItems[2].Text=objDetailListValueArr[i].m_strDetailName;
						}
						objLsvItem.SubItems[4].Text=objDetailListValueArr[i].m_strUsageName;
						objLsvItem.SubItems[5].Text=objDetailListValueArr[i].m_strFrequencyName;
						objLsvItem.SubItems[6].Text=objDetailListValueArr[i].m_strRemark;
						m_lstPhysicianOrderList.Items.Add(objLsvItem);
						
					}
					
				}
				
			}
			m_mthAddSubOrderSign(m_lstPhysicianOrderList);
			
		}



		private void m_mthCancelOrderListSelectHandle()
		{
			if(m_lstPhysicianOrderList.SelectedItems.Count==1)
			{
				int intIndex=0;
				if(m_lstPhysicianOrderList.SelectedItems[0].Tag==null)
				{
					intIndex=m_lstPhysicianOrderList.SelectedItems[0].Index;
					do
					{
						intIndex--;
						if(m_lstPhysicianOrderList.Items[intIndex].Tag!=null)
						{
							m_lstPhysicianOrderList.SelectedItems[0].Selected=false;
							m_lstPhysicianOrderList.Items[intIndex].Selected=true;
							break;
						}
					}while(intIndex>0);
				}
				m_mthCancelPhysicianOrderList();
			}
			else
			{
				//
			}
		}
		private void m_mthCancelPhysicianOrderList()
		{
			if(m_lstPhysicianOrderList.SelectedItems[0].Tag==null
				|| m_lstPhysicianOrderList.SelectedItems[0].Tag.GetType().Name!="clsNurseConfirmInfo") return;
			clsNurseConfirmInfo objConfirmInfo=(clsNurseConfirmInfo)m_lstPhysicianOrderList.SelectedItems[0].Tag;
			if(objConfirmInfo.m_blnIfPerformed )
			{
				m_ShowMessage("医嘱已执行，无法作废。");
				return;
			}
			if(objConfirmInfo.m_blnIfEnded )
			{
				m_ShowMessage("医嘱已停用，无法作废。");
				return;
			}
			if(objConfirmInfo.m_blnIfCanceled )
			{
				m_ShowMessage("医嘱已作废，无法重新作废。");
				return;
			}
			long lngRes=m_objDomain.m_lngCancelPhysicianOrder(objConfirmInfo.m_strInPatientID,objConfirmInfo.m_strInPatientDate,objConfirmInfo.m_strOpenDate,objConfirmInfo.m_strOrderID,MDIParent.OperatorID);
			if(lngRes<=0)
			{
				m_ShowMessage("无法废除此医嘱，请确定此医嘱是否已执行。");
				return;
			}
			m_mthLoadAllCombinationList();


		}

		
		private void m_mthEndOrderListSelectHandle()
		{
			if(m_lstPhysicianOrderList.SelectedItems.Count==1)
			{
				int intIndex=0;
				if(m_lstPhysicianOrderList.SelectedItems[0].Tag==null)
				{
					intIndex=m_lstPhysicianOrderList.SelectedItems[0].Index;
					do
					{
						intIndex--;
						if(m_lstPhysicianOrderList.Items[intIndex].Tag!=null)
						{
							m_lstPhysicianOrderList.SelectedItems[0].Selected=false;
							m_lstPhysicianOrderList.Items[intIndex].Selected=true;
							break;
						}
					}while(intIndex>0);
				}
				m_mthEndPhysicianOrderList();
			}
			else
			{
				//
			}
		}
		private void m_mthEndPhysicianOrderList()
		{
			if(m_lstPhysicianOrderList.SelectedItems[0].Tag==null
				|| m_lstPhysicianOrderList.SelectedItems[0].Tag.GetType().Name!="clsNurseConfirmInfo") return;
			clsNurseConfirmInfo objConfirmInfo=(clsNurseConfirmInfo)m_lstPhysicianOrderList.SelectedItems[0].Tag;
			if(objConfirmInfo.m_blnIfCanceled )
			{
				m_ShowMessage("医嘱已作废，无法停用。");
				return;
			}
			if(objConfirmInfo.m_blnIfEnded )
			{
				m_ShowMessage("医嘱已停用，无法重新停用。");
				return;
			}
		
			long lngRes=m_objDomain.m_lngStopPhysicianOrder(objConfirmInfo.m_strInPatientID,objConfirmInfo.m_strInPatientDate,objConfirmInfo.m_strOpenDate,objConfirmInfo.m_strOrderID,MDIParent.OperatorID.Trim());
			if(lngRes<=0)
			{
				m_ShowMessage("无法停用此医嘱。");
				return;
			}
			m_mthLoadAllCombinationList();
		}

		#endregion

		#region 护士工作站
		private void m_mthNurseConfirmSelectHandling()
		{
			if(m_lsvNursePhysicianOrder.SelectedItems.Count==1)
			{
				int intIndex=0;
				if(m_lsvNursePhysicianOrder.SelectedItems[0].Tag==null)
				{
					intIndex=m_lsvNursePhysicianOrder.SelectedItems[0].Index;
					do
					{
						intIndex--;
						if(m_lsvNursePhysicianOrder.Items[intIndex].Tag!=null)
						{
							m_lsvNursePhysicianOrder.SelectedItems[0].Selected=false;
							m_lsvNursePhysicianOrder.Items[intIndex].Selected=true;
							break;
						}
					}while(intIndex>0);
				}
				m_mthNurseSetConfirmedSingle(false);
			}
			else
			{
				//
			}
		}
		private void m_mthNurseSetConfirmedSingle(bool p_blnIsDoubleClick)
		{
			if(m_lsvNursePhysicianOrder.SelectedItems.Count!=1
				|| m_lsvNursePhysicianOrder.SelectedItems[0].Tag==null
				||m_lsvNursePhysicianOrder.SelectedItems[0].Tag.GetType().Name!="clsNurseConfirmInfo") return;
			clsNurseConfirmInfo objNurseConfirmInfo=(clsNurseConfirmInfo)m_lsvNursePhysicianOrder.SelectedItems[0].Tag;
			objNurseConfirmInfo.m_strConfirmUserID=MDIParent.OperatorID;
			if(!p_blnIsDoubleClick)
			{
				long lngRes=m_objDomain.m_lngConfirmPhysicianOrder(objNurseConfirmInfo.m_strInPatientID,objNurseConfirmInfo.m_strInPatientDate,
					objNurseConfirmInfo.m_strOpenDate,objNurseConfirmInfo.m_strOrderID,objNurseConfirmInfo.m_strConfirmUserID,objNurseConfirmInfo.objAddInValueArr);
				if(lngRes<=0)
				{
					m_ShowMessage("无法通过审核。");
					return;
				}
				int intIndex=m_lsvNursePhysicianOrder.SelectedItems[0].Index;
				m_lsvNursePhysicianOrder.SelectedItems[0].Remove();
				while(intIndex<m_lsvNursePhysicianOrder.Items.Count && m_lsvNursePhysicianOrder.Items[intIndex].Tag==null)
				{
					m_lsvNursePhysicianOrder.Items[intIndex].Remove();
				}	
		
			}
			else
			{
			}
		}

		private void m_mthNurseEditAddIn()
		{
			if(m_lsvNursePhysicianOrder.SelectedItems.Count==0)
			{
				m_ShowMessage("你还没选择医嘱。");
				return;
			}
			if(m_lsvNursePhysicianOrder.SelectedItems.Count>1)
			{
				m_ShowMessage("不能同时修改多条医嘱的附加物。");
				return;
			}

			int intIndex=0;
			if(m_lsvNursePhysicianOrder.SelectedItems[0].Tag==null)
			{
				intIndex=m_lsvNursePhysicianOrder.SelectedItems[0].Index;
				do
				{
					intIndex--;
					if(m_lsvNursePhysicianOrder.Items[intIndex].Tag!=null)
					{
						m_lsvNursePhysicianOrder.SelectedItems[0].Selected=false;
						m_lsvNursePhysicianOrder.Items[intIndex].Selected=true;
						break;
					}
				}while(intIndex>0);
			}
			
			int intLength=((clsNurseConfirmInfo)m_lsvNursePhysicianOrder.SelectedItems[0].Tag).objAddInValueArr.Length;
			clsNumericListViewAssistArrayItem[] objItemsArr=new clsNumericListViewAssistArrayItem[m_objAddInInfoArr.Length];
			for(int i=0;i<m_objAddInInfoArr.Length;i++)
			{	
				objItemsArr[i]=new clsNumericListViewAssistArrayItem();
				objItemsArr[i].m_strName=m_objAddInInfoArr[i].m_strItemName;
				objItemsArr[i].m_strID=m_objAddInInfoArr[i].m_strItemID;
				if(((clsNurseConfirmInfo)m_lsvNursePhysicianOrder.SelectedItems[0].Tag).objAddInValueArr!=null
					&& ((clsNurseConfirmInfo)m_lsvNursePhysicianOrder.SelectedItems[0].Tag).objAddInValueArr.Length>0)
				{
					
					for(int k=0;k<((clsNurseConfirmInfo)m_lsvNursePhysicianOrder.SelectedItems[0].Tag).objAddInValueArr.Length;k++)
					{
						if(m_objAddInInfoArr[i].m_strItemID==((clsNurseConfirmInfo)m_lsvNursePhysicianOrder.SelectedItems[0].Tag).objAddInValueArr[k].m_strItemID)
						{
							objItemsArr[i].m_strNumber=((clsNurseConfirmInfo)m_lsvNursePhysicianOrder.SelectedItems[0].Tag).objAddInValueArr[k].m_strNumber;
							break;
						}
						else
						{
							objItemsArr[i].m_strNumber="0";
						}
					}
				}
				else
				{
					objItemsArr[i].m_strNumber="0";
				}
			}
			m_objEditAddIn.m_ObjItemsArr=objItemsArr;
			m_objEditAddIn.m_mthShow();
			m_lsvNursePhysicianOrder.Enabled=false;
			m_cmdNurseSetPerformed.Enabled=false;
			m_cmdSetConfirmed.Enabled=false;
			m_rdbNurseNotConfirmed.Enabled=false;
			m_rdbNurseNotPerformed.Enabled=false;
		}
		
		private void m_mthNurseConfirmAddIn()
		{
			if(m_objEditAddIn.m_BlnIsOpen)
			{
				m_objEditAddIn.m_mthClose();
			}
			clsNumericListViewAssistArrayItem[] objItemsArr=m_objEditAddIn.m_ObjItemsArr;
			ArrayList arlItems=new ArrayList();
			if(objItemsArr==null)
			{
				((clsNurseConfirmInfo) m_lsvNursePhysicianOrder.SelectedItems[0].Tag).objAddInValueArr=null;
				return;
			}
			
			clsPhysicianOrderAddInValue[] objAddInArr=new clsPhysicianOrderAddInValue[objItemsArr.Length];
			for(int i=0;i<objAddInArr.Length;i++)
			{
				objAddInArr[i]=new clsPhysicianOrderAddInValue();
				objAddInArr[i].m_strInPatientID=((clsNurseConfirmInfo) m_lsvNursePhysicianOrder.SelectedItems[0].Tag).m_strInPatientID;
				objAddInArr[i].m_strInPatientDate=((clsNurseConfirmInfo) m_lsvNursePhysicianOrder.SelectedItems[0].Tag).m_strInPatientDate;
				objAddInArr[i].m_strOpenDate=((clsNurseConfirmInfo) m_lsvNursePhysicianOrder.SelectedItems[0].Tag).m_strOpenDate ;
				objAddInArr[i].m_strOrderID=((clsNurseConfirmInfo) m_lsvNursePhysicianOrder.SelectedItems[0].Tag).m_strOrderID ;
				objAddInArr[i].m_strItemID=objItemsArr[i].m_strID;
				objAddInArr[i].m_strNumber=objItemsArr[i].m_strNumber;
			}
			((clsNurseConfirmInfo) m_lsvNursePhysicianOrder.SelectedItems[0].Tag).objAddInValueArr=objAddInArr;		
			m_lsvNursePhysicianOrder.SelectedItems[0].SubItems[7].Text="";
			for(int i=0;i<objItemsArr.Length;i++)
			{
				m_lsvNursePhysicianOrder.SelectedItems[0].SubItems[7].Text+=objItemsArr[i].m_strName + "(" + objItemsArr[i].m_strNumber + ")" + "+";
			}
			if(m_lsvNursePhysicianOrder.SelectedItems[0].SubItems[7].Text.Length>0)
				m_lsvNursePhysicianOrder.SelectedItems[0].SubItems[7].Text=m_lsvNursePhysicianOrder.SelectedItems[0].SubItems[7].Text.Substring(0,m_lsvNursePhysicianOrder.SelectedItems[0].SubItems[7].Text.Length-1);
			m_lsvNursePhysicianOrder.Enabled=true;
			m_cmdNurseSetPerformed.Enabled=true;
			m_cmdSetConfirmed.Enabled=true;
			m_rdbNurseNotConfirmed.Enabled=true;
			m_rdbNurseNotPerformed.Enabled=true;
		}



		private void m_mthNursePerformSelectHandling()
		{
			if(m_lsvNursePhysicianOrder.SelectedItems.Count==1)
			{
				int intIndex=0;
				if(m_lsvNursePhysicianOrder.SelectedItems[0].Tag==null)
				{
					intIndex=m_lsvNursePhysicianOrder.SelectedItems[0].Index;
					do
					{
						intIndex--;
						if(m_lsvNursePhysicianOrder.Items[intIndex].Tag!=null)
						{
							m_lsvNursePhysicianOrder.SelectedItems[0].Selected=false;
							m_lsvNursePhysicianOrder.Items[intIndex].Selected=true;
							break;
						}
					}while(intIndex>0);
				}
				m_mthNurseSetPerformedSingle(false);
			}
			else
			{
				//
			}
		}
		private void m_mthNurseSetPerformedSingle(bool p_blnIsDoubleClick)
		{
			if(m_lsvNursePhysicianOrder.SelectedItems.Count!=1
				|| m_lsvNursePhysicianOrder.SelectedItems[0].Tag==null
				||m_lsvNursePhysicianOrder.SelectedItems[0].Tag.GetType().Name!="clsNursePerformInfo") return;
			
			clsNursePerformInfo objNursePerformInfo=(clsNursePerformInfo)m_lsvNursePhysicianOrder.SelectedItems[0].Tag;
			if(objNursePerformInfo.m_objPhysicianOrderPerformedList==null)
			{
				return;
			}

			objNursePerformInfo.m_objPhysicianOrderPerformedList.m_strPerformDate=m_dtpNursePerformDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
			objNursePerformInfo.m_objPhysicianOrderPerformedList.m_strPerformUserID=MDIParent.OperatorID;
			if(!p_blnIsDoubleClick)
			{
				clsPhysicianOrderPerformedListValue[] objPerfListValueArr=new clsPhysicianOrderPerformedListValue[1];
				objPerfListValueArr[0]=objNursePerformInfo.m_objPhysicianOrderPerformedList;

				if( objNursePerformInfo.m_objPhysicianOrderPerformedAddInArr==null && objNursePerformInfo.m_objPhysicianOrderAddInArr!=null)
				{
					objNursePerformInfo.m_objPhysicianOrderPerformedAddInArr=new clsPhysicianOrderPerformedAddInValue[objNursePerformInfo.m_objPhysicianOrderAddInArr.Length];
					for(int i=0;i<objNursePerformInfo.m_objPhysicianOrderPerformedAddInArr.Length;i++)
					{
						objNursePerformInfo.m_objPhysicianOrderPerformedAddInArr[i]=new clsPhysicianOrderPerformedAddInValue();
						objNursePerformInfo.m_objPhysicianOrderPerformedAddInArr[i].m_strInPatientID=objNursePerformInfo.m_objPhysicianOrderAddInArr[i].m_strInPatientID;
						objNursePerformInfo.m_objPhysicianOrderPerformedAddInArr[i].m_strInPatientDate=objNursePerformInfo.m_objPhysicianOrderAddInArr[i].m_strInPatientDate;
						objNursePerformInfo.m_objPhysicianOrderPerformedAddInArr[i].m_strOpenDate=objNursePerformInfo.m_objPhysicianOrderAddInArr[i].m_strOpenDate;
						objNursePerformInfo.m_objPhysicianOrderPerformedAddInArr[i].m_strOrderID=objNursePerformInfo.m_objPhysicianOrderAddInArr[i].m_strOrderID;
						objNursePerformInfo.m_objPhysicianOrderPerformedAddInArr[i].m_strItemID=objNursePerformInfo.m_objPhysicianOrderAddInArr[i].m_strItemID;
						objNursePerformInfo.m_objPhysicianOrderPerformedAddInArr[i].m_strCreateUserID=MDIParent.OperatorID.Trim();
						objNursePerformInfo.m_objPhysicianOrderPerformedAddInArr[i].m_strNumber=objNursePerformInfo.m_objPhysicianOrderAddInArr[i].m_strNumber;
						objNursePerformInfo.m_objPhysicianOrderPerformedAddInArr[i].m_strDeActiveUserID="";
					}
				}
				long lngRes=m_objDomain.m_lngPerformPhysicianOrders(objPerfListValueArr,
					objNursePerformInfo.m_objPhysicianOrderPerformedAddInArr);
				if(lngRes<=0)
				{
					m_ShowMessage("无法将所选医嘱变为已执行。");
					return;
				}
				int intIndex=m_lsvNursePhysicianOrder.SelectedItems[0].Index;
				m_lsvNursePhysicianOrder.SelectedItems[0].Remove();
				while(intIndex<m_lsvNursePhysicianOrder.Items.Count && m_lsvNursePhysicianOrder.Items[intIndex].Tag==null)
				{
					m_lsvNursePhysicianOrder.Items[intIndex].Remove();
				}
				
		
			}
			else
			{
			}
		}

		private void m_mthNurseEditPerformAddIn()
		{
			if(m_lsvNursePhysicianOrder.SelectedItems.Count==0)
			{
				m_ShowMessage("你还没选择医嘱。");
				return;
			}
			if(m_lsvNursePhysicianOrder.SelectedItems.Count>1)
			{
				m_ShowMessage("不能同时修改多条医嘱的附加物。");
				return;
			}

			int intIndex=0;
			if(m_lsvNursePhysicianOrder.SelectedItems[0].Tag==null)
			{
				intIndex=m_lsvNursePhysicianOrder.SelectedItems[0].Index;
				do
				{
					intIndex--;
					if(m_lsvNursePhysicianOrder.Items[intIndex].Tag!=null)
					{
						m_lsvNursePhysicianOrder.SelectedItems[0].Selected=false;
						m_lsvNursePhysicianOrder.Items[intIndex].Selected=true;
						break;
					}
				}while(intIndex>0);
			}
			
			int intLength=((clsNursePerformInfo)m_lsvNursePhysicianOrder.SelectedItems[0].Tag).m_objPhysicianOrderAddInArr.Length;
			clsNumericListViewAssistArrayItem[] objItemsArr=new clsNumericListViewAssistArrayItem[m_objAddInInfoArr.Length];
			for(int i=0;i<m_objAddInInfoArr.Length;i++)
			{	
				objItemsArr[i]=new clsNumericListViewAssistArrayItem();
				objItemsArr[i].m_strName=m_objAddInInfoArr[i].m_strItemName;
				objItemsArr[i].m_strID=m_objAddInInfoArr[i].m_strItemID;
				if(((clsNursePerformInfo)m_lsvNursePhysicianOrder.SelectedItems[0].Tag).m_objPhysicianOrderAddInArr!=null
					&& ((clsNursePerformInfo)m_lsvNursePhysicianOrder.SelectedItems[0].Tag).m_objPhysicianOrderAddInArr.Length>0)
				{
					for(int k=0;k<((clsNursePerformInfo)m_lsvNursePhysicianOrder.SelectedItems[0].Tag).m_objPhysicianOrderAddInArr.Length;k++)
					{
						if(m_objAddInInfoArr[i].m_strItemID==((clsNursePerformInfo)m_lsvNursePhysicianOrder.SelectedItems[0].Tag).m_objPhysicianOrderAddInArr[k].m_strItemID)
						{
							objItemsArr[i].m_strNumber=((clsNursePerformInfo)m_lsvNursePhysicianOrder.SelectedItems[0].Tag).m_objPhysicianOrderAddInArr[k].m_strNumber;
							break;
						}
						else
						{
							objItemsArr[i].m_strNumber="0";
						}
					}
				}
				else
				{
					objItemsArr[i].m_strNumber="0";
				}
			}
			m_objEditAddIn.m_ObjItemsArr=objItemsArr;
			m_objEditAddIn.m_mthShow();
			m_lsvNursePhysicianOrder.Enabled=false;
			m_cmdNurseSetPerformed.Enabled=false;
			m_cmdSetConfirmed.Enabled=false;
			m_rdbNurseNotConfirmed.Enabled=false;
			m_rdbNurseNotPerformed.Enabled=false;
		}
		private void m_mthNursePerformAddIn()
		{
			if(m_objEditAddIn.m_BlnIsOpen)
			{
				m_objEditAddIn.m_mthClose();
			}
			clsNumericListViewAssistArrayItem[] objItemsArr=m_objEditAddIn.m_ObjItemsArr;
			ArrayList arlItems=new ArrayList();
			if(objItemsArr==null)
			{
				((clsNursePerformInfo) m_lsvNursePhysicianOrder.SelectedItems[0].Tag).m_objPhysicianOrderAddInArr=null;
				return;
			}
			clsPhysicianOrderAddInValue[] objDisplayAddInArr=new clsPhysicianOrderAddInValue[objItemsArr.Length];
			clsPhysicianOrderPerformedAddInValue[] objAddInArr=new clsPhysicianOrderPerformedAddInValue[objItemsArr.Length];
			for(int i=0;i<objAddInArr.Length;i++)
			{
				objAddInArr[i]=new clsPhysicianOrderPerformedAddInValue();
				objAddInArr[i].m_strInPatientID=((clsNursePerformInfo) m_lsvNursePhysicianOrder.SelectedItems[0].Tag).m_objPhysicianOrderPerformedList.m_strInPatientID;
				objAddInArr[i].m_strInPatientDate=((clsNursePerformInfo) m_lsvNursePhysicianOrder.SelectedItems[0].Tag).m_objPhysicianOrderPerformedList.m_strInPatientDate;
				objAddInArr[i].m_strOpenDate=((clsNursePerformInfo) m_lsvNursePhysicianOrder.SelectedItems[0].Tag).m_objPhysicianOrderPerformedList.m_strOpenDate ;
				objAddInArr[i].m_strOrderID=((clsNursePerformInfo) m_lsvNursePhysicianOrder.SelectedItems[0].Tag).m_objPhysicianOrderPerformedList.m_strOrderID ;
				objAddInArr[i].m_strItemID=objItemsArr[i].m_strID;
				objAddInArr[i].m_strNumber=objItemsArr[i].m_strNumber;
				objAddInArr[i].m_strCreateUserID=MDIParent.OperatorID;
				objAddInArr[i].m_strDeActiveUserID="";

				objDisplayAddInArr[i]=new clsPhysicianOrderAddInValue();
				objDisplayAddInArr[i].m_strInPatientID=((clsNursePerformInfo) m_lsvNursePhysicianOrder.SelectedItems[0].Tag).m_objPhysicianOrderPerformedList.m_strInPatientID;
				objDisplayAddInArr[i].m_strInPatientDate=((clsNursePerformInfo) m_lsvNursePhysicianOrder.SelectedItems[0].Tag).m_objPhysicianOrderPerformedList.m_strInPatientDate;
				objDisplayAddInArr[i].m_strOpenDate=((clsNursePerformInfo) m_lsvNursePhysicianOrder.SelectedItems[0].Tag).m_objPhysicianOrderPerformedList.m_strOpenDate ;
				objDisplayAddInArr[i].m_strOrderID=((clsNursePerformInfo) m_lsvNursePhysicianOrder.SelectedItems[0].Tag).m_objPhysicianOrderPerformedList.m_strOrderID ;
				objDisplayAddInArr[i].m_strItemID=objItemsArr[i].m_strID;
				objDisplayAddInArr[i].m_strNumber=objItemsArr[i].m_strNumber;
				objDisplayAddInArr[i].m_strCreateUserID=MDIParent.OperatorID.Trim();
				objDisplayAddInArr[i].m_strDeActivedUserID="";
			}
			((clsNursePerformInfo) m_lsvNursePhysicianOrder.SelectedItems[0].Tag).m_objPhysicianOrderPerformedAddInArr=objAddInArr;		
			((clsNursePerformInfo) m_lsvNursePhysicianOrder.SelectedItems[0].Tag).m_objPhysicianOrderAddInArr=objDisplayAddInArr;		
			m_lsvNursePhysicianOrder.SelectedItems[0].SubItems[7].Text="";
			for(int i=0;i<objItemsArr.Length;i++)
			{
				m_lsvNursePhysicianOrder.SelectedItems[0].SubItems[7].Text+=objItemsArr[i].m_strName + "(" + objItemsArr[i].m_strNumber + ")" + "+";
			}
			m_lsvNursePhysicianOrder.SelectedItems[0].SubItems[7].Text=m_lsvNursePhysicianOrder.SelectedItems[0].SubItems[7].Text.Substring(0,m_lsvNursePhysicianOrder.SelectedItems[0].SubItems[7].Text.Length-1);
			m_lsvNursePhysicianOrder.Enabled=true;
			m_cmdNurseSetPerformed.Enabled=true;
			m_cmdSetConfirmed.Enabled=true;
			m_rdbNurseNotConfirmed.Enabled=true;
			m_rdbNurseNotPerformed.Enabled=true;
		}

		
		private void m_mthNurseLoadUnconfirmedOrder()
		{
			m_lsvNursePhysicianOrder.Items.Clear();
			if(m_objBaseCurrentPatient==null || m_objBaseCurrentPatient.m_ObjInBedInfo==null
				|| m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo==null
				|| m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate==DateTime.MinValue)
			{
				m_ShowMessage("你还没选择病人。");
				return;
			}
			clsPhysicianOrderDetailListValue[] objDetailListValueArr=null;
			long lngRes=m_objDomain.m_lngGetPhysicainOrderUnconfirmList(m_objBaseCurrentPatient.m_StrInPatientID,
				m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss"),out objDetailListValueArr);
			if(lngRes<=0 || objDetailListValueArr==null || objDetailListValueArr.Length==0) return;
			string strCurrentOpendate="",strCurrentOrderID="",strCurrentSubOrderID="",strCurrentAddItemID="";
			ArrayList arlAddIn=new ArrayList();
			
			int intMainRecordIndex=-1;
			int intSubOrderNum=-1;
			
			for(int i=0;i<objDetailListValueArr.Length;i++)
			{
				
				if(strCurrentOpendate!=objDetailListValueArr[i].m_strOpenDate
					|| strCurrentOrderID!=objDetailListValueArr[i].m_strOrderID)
				{
					if(intMainRecordIndex!=-1)
					{
						((clsNurseConfirmInfo)m_lsvNursePhysicianOrder.Items[intMainRecordIndex].Tag).objAddInValueArr=(clsPhysicianOrderAddInValue[])arlAddIn.ToArray(typeof(clsPhysicianOrderAddInValue));
						arlAddIn.Clear();
						strCurrentAddItemID="";
						if(!m_blnIsEmptyString(m_lsvNursePhysicianOrder.Items[intMainRecordIndex].SubItems[7].Text))
						{
							m_lsvNursePhysicianOrder.Items[intMainRecordIndex].SubItems[7].Text
								=m_lsvNursePhysicianOrder.Items[intMainRecordIndex].SubItems[7].Text.Substring(0,m_lsvNursePhysicianOrder.Items[intMainRecordIndex].SubItems[7].Text.Length-1);
						}
						
					}

					intSubOrderNum=-1;
					clsNurseConfirmInfo objConfirmInfo=new clsNurseConfirmInfo();
					
					strCurrentOpendate=objDetailListValueArr[i].m_strOpenDate;
					strCurrentOrderID=objDetailListValueArr[i].m_strOrderID;
					strCurrentSubOrderID=objDetailListValueArr[i].m_strSubOrderID;
					objConfirmInfo.m_intSubOrderFlag=0;
					objConfirmInfo.m_strInPatientDate=m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss");
					objConfirmInfo.m_strInPatientID=m_objBaseCurrentPatient.m_StrInPatientID;
					objConfirmInfo.m_strOpenDate=strCurrentOpendate;
					objConfirmInfo.m_strOrderID=strCurrentOrderID;
					
					
					//Add ListView Item
					ListViewItem objLsvItem=new ListViewItem(new string[]{"","","","","","","",""});
					objLsvItem.SubItems[0].Text=objDetailListValueArr[i].m_strOrderFlag=="0" ? "长" : "临";
					objLsvItem.SubItems[1].Text=objDetailListValueArr[i].m_strStartDate;
					if(objDetailListValueArr[i].m_strOrderTypeID=="007")
					{
						objLsvItem.SubItems[2].Text=objDetailListValueArr[i].m_strMedicineName;
						objLsvItem.SubItems[3].Text=objDetailListValueArr[i].m_strItemDosage;
					}
					else
					{
						objLsvItem.SubItems[2].Text=objDetailListValueArr[i].m_strDetailName;
					}
					objLsvItem.SubItems[4].Text=objDetailListValueArr[i].m_strUsageName;
					objLsvItem.SubItems[5].Text=objDetailListValueArr[i].m_strFrequencyName;
					objLsvItem.SubItems[6].Text=objDetailListValueArr[i].m_strRemark;
					//附加物暂不显示

					
					objLsvItem.Tag=objConfirmInfo;
					m_lsvNursePhysicianOrder.Items.Add(objLsvItem);
					intMainRecordIndex=m_lsvNursePhysicianOrder.Items.Count-1;
					//					});
				}
				else
				{

					if(strCurrentSubOrderID!=objDetailListValueArr[i].m_strSubOrderID)
					{
						intSubOrderNum++;
						strCurrentSubOrderID=objDetailListValueArr[i].m_strSubOrderID;
						ListViewItem objLsvItem=new ListViewItem(new string[]{"","","","","","","",""});
						if(objDetailListValueArr[i].m_strOrderTypeID=="007")
						{
							objLsvItem.SubItems[2].Text=objDetailListValueArr[i].m_strMedicineName;
							objLsvItem.SubItems[3].Text=objDetailListValueArr[i].m_strItemDosage;
						}
						else
						{
							objLsvItem.SubItems[2].Text=objDetailListValueArr[i].m_strDetailName;
						}
						objLsvItem.SubItems[4].Text=objDetailListValueArr[i].m_strUsageName;
						objLsvItem.SubItems[5].Text=objDetailListValueArr[i].m_strFrequencyName;
						objLsvItem.SubItems[6].Text=objDetailListValueArr[i].m_strRemark;
						m_lsvNursePhysicianOrder.Items.Add(objLsvItem);
						
					}
					
				}
				if(intSubOrderNum<0)
				{
					//只有附加物的改变，直接加进去
					if(objDetailListValueArr[i].m_strAddInItemID!=null
						&& objDetailListValueArr[i].m_strAddInItemID.Trim().Length!=0)
					{
						if(strCurrentAddItemID!=objDetailListValueArr[i].m_strAddInItemID)
						{
							strCurrentAddItemID=objDetailListValueArr[i].m_strAddInItemID;
							clsPhysicianOrderAddInValue objAddInValue=new clsPhysicianOrderAddInValue();
							objAddInValue.m_strCreateUserID=MDIParent.OperatorID;
							objAddInValue.m_strDescription="";
							objAddInValue.m_strInPatientDate=m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss");
							objAddInValue.m_strInPatientID=m_objBaseCurrentPatient.m_StrInPatientID;
							objAddInValue.m_strItemID=objDetailListValueArr[i].m_strAddInItemID;
							objAddInValue.m_strNumber=objDetailListValueArr[i].m_strNumber;
							objAddInValue.m_strOrderID=objDetailListValueArr[i].m_strOrderID;
							objAddInValue.m_strOpenDate=objDetailListValueArr[i].m_strOpenDate;
							arlAddIn.Add(objAddInValue);
							m_lsvNursePhysicianOrder.Items[intMainRecordIndex].SubItems[7].Text+=objDetailListValueArr[i].m_strItemName +"("+objDetailListValueArr[i].m_strNumber+")"+ "+";
						}
					}
				}
				if(i==objDetailListValueArr.Length-1)
				{
					((clsNurseConfirmInfo)m_lsvNursePhysicianOrder.Items[intMainRecordIndex].Tag).objAddInValueArr=(clsPhysicianOrderAddInValue[])arlAddIn.ToArray(typeof(clsPhysicianOrderAddInValue));
					arlAddIn.Clear();
					strCurrentAddItemID="";
					if(!m_blnIsEmptyString(m_lsvNursePhysicianOrder.Items[intMainRecordIndex].SubItems[7].Text))
					{
						m_lsvNursePhysicianOrder.Items[intMainRecordIndex].SubItems[7].Text
							=m_lsvNursePhysicianOrder.Items[intMainRecordIndex].SubItems[7].Text.Substring(0,m_lsvNursePhysicianOrder.Items[intMainRecordIndex].SubItems[7].Text.Length-1);
					}
				}
				
				
			}
			m_mthAddSubOrderSign(m_lsvNursePhysicianOrder);

		}
		private void m_mthNurseLoadUnperformedOrder()
		{

			

			m_lsvNursePhysicianOrder.Items.Clear();
			if(m_objBaseCurrentPatient==null || m_objBaseCurrentPatient.m_ObjInBedInfo==null
				|| m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo==null
				|| m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate==DateTime.MinValue)
			{
				m_ShowMessage("你还没选择病人。");
				return;
			}
			clsPhysicianOrderDetailListValue[] objDetailListValueArr=null;
			long lngRes=m_objDomain.m_lngGetWaitToPerformOrders(m_objBaseCurrentPatient.m_StrInPatientID,
				m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss"),out objDetailListValueArr);
			if(lngRes<=0 || objDetailListValueArr==null || objDetailListValueArr.Length==0) return;
			string strCurrentOpendate="",strCurrentOrderID="",strCurrentSubOrderID="",strCurrentAddItemID="";
			ArrayList arlAddIn=new ArrayList();
			ArrayList arlPerformAddIn=new ArrayList();
			
			int intMainRecordIndex=-1;
			int intSubOrderNum=-1;
			
			for(int i=0;i<objDetailListValueArr.Length;i++)
			{
				
				if(strCurrentOpendate!=objDetailListValueArr[i].m_strOpenDate
					|| strCurrentOrderID!=objDetailListValueArr[i].m_strOrderID)
				{
					if(intMainRecordIndex!=-1)
					{
						((clsNursePerformInfo)m_lsvNursePhysicianOrder.Items[intMainRecordIndex].Tag).m_objPhysicianOrderAddInArr=(clsPhysicianOrderAddInValue[])arlAddIn.ToArray(typeof(clsPhysicianOrderAddInValue));
						((clsNursePerformInfo)m_lsvNursePhysicianOrder.Items[intMainRecordIndex].Tag).m_objPhysicianOrderPerformedAddInArr=(clsPhysicianOrderPerformedAddInValue[])arlPerformAddIn.ToArray(typeof(clsPhysicianOrderPerformedAddInValue));
						arlAddIn.Clear();
						arlPerformAddIn.Clear();
						strCurrentAddItemID="";
						if(!m_blnIsEmptyString(m_lsvNursePhysicianOrder.Items[intMainRecordIndex].SubItems[7].Text))
						{
							m_lsvNursePhysicianOrder.Items[intMainRecordIndex].SubItems[7].Text
								=m_lsvNursePhysicianOrder.Items[intMainRecordIndex].SubItems[7].Text.Substring(0,m_lsvNursePhysicianOrder.Items[intMainRecordIndex].SubItems[7].Text.Length-1);
						}
						
					}

					intSubOrderNum=-1;
					clsNursePerformInfo objPerformInfo=new clsNursePerformInfo();
					objPerformInfo.m_objPhysicianOrderPerformedList=new clsPhysicianOrderPerformedListValue();
					
					strCurrentOpendate=objDetailListValueArr[i].m_strOpenDate;
					strCurrentOrderID=objDetailListValueArr[i].m_strOrderID;
					strCurrentSubOrderID=objDetailListValueArr[i].m_strSubOrderID;
					objPerformInfo.m_intSubOrderFlag=0;
					objPerformInfo.m_objPhysicianOrderPerformedList.m_strInPatientDate=m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss");
					objPerformInfo.m_objPhysicianOrderPerformedList.m_strInPatientID=m_objBaseCurrentPatient.m_StrInPatientID;
					objPerformInfo.m_objPhysicianOrderPerformedList.m_strOpenDate=strCurrentOpendate;
					objPerformInfo.m_objPhysicianOrderPerformedList.m_strOrderID=strCurrentOrderID;
					
					
					//Add ListView Item
					ListViewItem objLsvItem=new ListViewItem(new string[]{"","","","","","","",""});
					objLsvItem.SubItems[0].Text=objDetailListValueArr[i].m_strOrderFlag=="0" ? "长" : "临";
					objLsvItem.SubItems[1].Text=objDetailListValueArr[i].m_strStartDate;
					if(objDetailListValueArr[i].m_strOrderTypeID=="007")
					{
						objLsvItem.SubItems[2].Text=objDetailListValueArr[i].m_strMedicineName;
						objLsvItem.SubItems[3].Text=objDetailListValueArr[i].m_strItemDosage;
					}
					else
					{
						objLsvItem.SubItems[2].Text=objDetailListValueArr[i].m_strDetailName;
					}
					objLsvItem.SubItems[4].Text=objDetailListValueArr[i].m_strUsageName;
					objLsvItem.SubItems[5].Text=objDetailListValueArr[i].m_strFrequencyName;
					objLsvItem.SubItems[6].Text=objDetailListValueArr[i].m_strRemark;
					//附加物暂不显示

					
					objLsvItem.Tag=objPerformInfo;
					m_lsvNursePhysicianOrder.Items.Add(objLsvItem);
					intMainRecordIndex=m_lsvNursePhysicianOrder.Items.Count-1;
					//					});
				}
				else
				{

					if(strCurrentSubOrderID!=objDetailListValueArr[i].m_strSubOrderID)
					{
						intSubOrderNum++;
						strCurrentSubOrderID=objDetailListValueArr[i].m_strSubOrderID;
						ListViewItem objLsvItem=new ListViewItem(new string[]{"","","","","","","",""});
						if(objDetailListValueArr[i].m_strOrderTypeID=="007")
						{
							objLsvItem.SubItems[2].Text=objDetailListValueArr[i].m_strMedicineName;
							objLsvItem.SubItems[3].Text=objDetailListValueArr[i].m_strItemDosage;
						}
						else
						{
							objLsvItem.SubItems[2].Text=objDetailListValueArr[i].m_strDetailName;
						}
						objLsvItem.SubItems[4].Text=objDetailListValueArr[i].m_strUsageName;
						objLsvItem.SubItems[5].Text=objDetailListValueArr[i].m_strFrequencyName;
						objLsvItem.SubItems[6].Text=objDetailListValueArr[i].m_strRemark;
						m_lsvNursePhysicianOrder.Items.Add(objLsvItem);
						
					}
					
				}
				if(intSubOrderNum<0)
				{
					//只有附加物的改变，直接加进去
					if(objDetailListValueArr[i].m_strAddInItemID!=null
						&& objDetailListValueArr[i].m_strAddInItemID.Trim().Length!=0)
					{
						if(strCurrentAddItemID!=objDetailListValueArr[i].m_strAddInItemID)
						{
							strCurrentAddItemID=objDetailListValueArr[i].m_strAddInItemID;
							clsPhysicianOrderAddInValue objAddInValue=new clsPhysicianOrderAddInValue();
							objAddInValue.m_strCreateUserID=MDIParent.OperatorID;
							objAddInValue.m_strDeActivedUserID="";
							objAddInValue.m_strDescription="";
							objAddInValue.m_strInPatientDate=m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss");
							objAddInValue.m_strInPatientID=m_objBaseCurrentPatient.m_StrInPatientID;
							objAddInValue.m_strItemID=objDetailListValueArr[i].m_strAddInItemID;
							objAddInValue.m_strNumber=objDetailListValueArr[i].m_strNumber;
							objAddInValue.m_strOrderID=objDetailListValueArr[i].m_strOrderID;
							objAddInValue.m_strOpenDate=objDetailListValueArr[i].m_strOpenDate;
							arlAddIn.Add(objAddInValue);
							
							m_lsvNursePhysicianOrder.Items[intMainRecordIndex].SubItems[7].Text+=objDetailListValueArr[i].m_strItemName +"("+objDetailListValueArr[i].m_strNumber+")"+ "+";

							clsPhysicianOrderPerformedAddInValue objPerformAddInValue=new clsPhysicianOrderPerformedAddInValue();
							objPerformAddInValue.m_strInPatientID=objAddInValue.m_strInPatientID;
							objPerformAddInValue.m_strInPatientDate=objAddInValue.m_strInPatientDate;
							objPerformAddInValue.m_strOrderID=objAddInValue.m_strOrderID;
							objPerformAddInValue.m_strItemID=objAddInValue.m_strItemID;
							objPerformAddInValue.m_strNumber=objAddInValue.m_strNumber;
							objPerformAddInValue.m_strOpenDate=objAddInValue.m_strOpenDate;
							objPerformAddInValue.m_strCreateUserID=objAddInValue.m_strCreateUserID;
							objPerformAddInValue.m_strDeActiveUserID=objAddInValue.m_strDeActivedUserID;
							arlPerformAddIn.Add(objPerformAddInValue);
						}
					}
				}
				if(i==objDetailListValueArr.Length-1)
				{
					((clsNursePerformInfo)m_lsvNursePhysicianOrder.Items[intMainRecordIndex].Tag).m_objPhysicianOrderAddInArr=(clsPhysicianOrderAddInValue[])arlAddIn.ToArray(typeof(clsPhysicianOrderAddInValue));
					((clsNursePerformInfo)m_lsvNursePhysicianOrder.Items[intMainRecordIndex].Tag).m_objPhysicianOrderPerformedAddInArr=(clsPhysicianOrderPerformedAddInValue[])arlPerformAddIn.ToArray(typeof(clsPhysicianOrderPerformedAddInValue));
					arlAddIn.Clear();
					arlPerformAddIn.Clear();
					strCurrentAddItemID="";
					if(!m_blnIsEmptyString(m_lsvNursePhysicianOrder.Items[intMainRecordIndex].SubItems[7].Text))
					{
						m_lsvNursePhysicianOrder.Items[intMainRecordIndex].SubItems[7].Text
							=m_lsvNursePhysicianOrder.Items[intMainRecordIndex].SubItems[7].Text.Substring(0,m_lsvNursePhysicianOrder.Items[intMainRecordIndex].SubItems[7].Text.Length-1);
					}
				}
				
				
			}
			m_mthAddSubOrderSign(m_lsvNursePhysicianOrder);
		}
		

		private void m_mthNurseFillInitDataGrid()
		{
			
			for(int i=0;i<m_objAddInInfoArr.Length;i++)
			{
				object[] obj=new Object[3];
				obj[0]=false;
				obj[1]=m_objAddInInfoArr[i].m_strItemName;
				obj[2]=0;
				m_dtbNursePhysicianOrder.Rows.Add(obj);
			}
		}
		#endregion

		#region 临时医嘱的界面控制

		private void m_mthTempAddPhysicianOrder()
		{
			if(m_objBaseCurrentPatient==null || m_objBaseCurrentPatient.m_ObjInBedInfo==null 
				|| m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo==null)
			{
				m_ShowMessage("你还没有选定病人。");
				return;
			}

			if(m_blnIsSubOrder)
			{
				if(m_lsvTempPhysicianOrder.Items.Count==0)
				{
					m_ShowMessage("上面列表中没有医嘱。");
					return;
				}
				else
				{
					if(!m_blnTempInputValid()) return;
					m_objCurrentNewOrderRowInfo.m_intSubOrderFlag=2;
					if(((clsNewOrderRowInfo) m_lsvTempPhysicianOrder.Items[m_lsvTempPhysicianOrder.Items.Count-1].Tag).m_intSubOrderFlag==2)
					{
						((clsNewOrderRowInfo) m_lsvTempPhysicianOrder.Items[m_lsvTempPhysicianOrder.Items.Count-1].Tag).m_intSubOrderFlag=1;
						string strTemp3=m_lsvTempPhysicianOrder.Items[m_lsvTempPhysicianOrder.Items.Count-1].SubItems[2].Text.Substring(0,14);
						m_lsvTempPhysicianOrder.Items[m_lsvTempPhysicianOrder.Items.Count-1].SubItems[2].Text=strTemp3+"│";
						
					}
					else if(((clsNewOrderRowInfo) m_lsvTempPhysicianOrder.Items[m_lsvTempPhysicianOrder.Items.Count-1].Tag).m_intSubOrderFlag==0)
					{
						string strTemp1=m_lsvTempPhysicianOrder.Items[m_lsvTempPhysicianOrder.Items.Count-1].SubItems[2].Text+"              ";
						strTemp1=strTemp1.Substring(0,14);
						strTemp1+="┑";
						m_lsvTempPhysicianOrder.Items[m_lsvTempPhysicianOrder.Items.Count-1].SubItems[2].Text=strTemp1;
					}
				}
				for(int i=0;i<m_objOrderUsageArr.Length;i++)
				{
					if(m_objOrderUsageArr[i].m_strUsageID==((clsNewOrderRowInfo) m_lsvTempPhysicianOrder.Items[m_lsvTempPhysicianOrder.Items.Count-1].Tag).m_objPhysicianOrderContentValueArr.m_strUsageID)
					{
						m_cboTempUsage.SelectedIndex=i;
						break;
					}
				}
				for(int i=0;i<m_objFrequencyInfoArr.Length;i++)
				{
					if(m_objFrequencyInfoArr[i].m_strFrequencyID==((clsNewOrderRowInfo) m_lsvTempPhysicianOrder.Items[m_lsvTempPhysicianOrder.Items.Count-1].Tag).m_objPhysicianOrderContentValueArr.m_strFrequencyID)
					{
						m_cboTempFrequency.SelectedIndex=i;
						break;
					}
				}
																																																		  
			}
			else
			{
				if(!m_blnTempInputValid()) return;
				m_objCurrentNewOrderRowInfo.m_intSubOrderFlag=0;
			}

			ListViewItem objLsvItem=new ListViewItem(new string[]{"","","","","","","",""});
			
			
			if(m_objCurrentNewOrderRowInfo.m_intSubOrderFlag==0)
			{
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderBaseValueArr.m_strInPatientID=m_objBaseCurrentPatient.m_StrInPatientID;
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderBaseValueArr.m_strInPatientDate=m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss");
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderBaseValueArr.m_strStartDate=m_dtpTempStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderBaseValueArr.m_strStartUserID=MDIParent.OperatorID;
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderBaseValueArr.m_strEndDate=m_dtpTempStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderBaseValueArr.m_strOrderFlag="1";

				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strInPatientID=m_objBaseCurrentPatient.m_StrInPatientID;
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strInPatientDate=m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss");

				objLsvItem.SubItems[0].Text=m_objCurrentNewOrderRowInfo.m_objPhysicianOrderBaseValueArr.m_strStartDate;
				objLsvItem.SubItems[2].Text=m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemDosage;
				objLsvItem.SubItems[6].Text=m_objCurrentNewOrderRowInfo.m_objPhysicianOrderBaseValueArr.m_strEndDate;
			}
			else
			{
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderBaseValueArr=null;
				objLsvItem.SubItems[0].Text="";
				objLsvItem.SubItems[6].Text="";
				string strTemp2=m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemDosage + "              ";
				strTemp2=strTemp2.Substring(0,14);
				strTemp2+="┙";
				objLsvItem.SubItems[2].Text=strTemp2;
				
				for(int i=m_lsvTempPhysicianOrder.Items.Count-1;i>=0;i--)
				{
					if(((clsNewOrderRowInfo) m_lsvTempPhysicianOrder.Items[i].Tag).m_intSubOrderFlag==0)
					{
						m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strInPatientID
							=((clsNewOrderRowInfo) m_lsvTempPhysicianOrder.Items[i].Tag).m_objPhysicianOrderBaseValueArr.m_strInPatientID;
						m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strInPatientDate
							=((clsNewOrderRowInfo) m_lsvTempPhysicianOrder.Items[i].Tag).m_objPhysicianOrderBaseValueArr.m_strInPatientDate;
						break;
					}
				}
			}
			

			objLsvItem.SubItems[1].Text=m_lsvTempMedical.Items[0].SubItems[0].Text;
	
			objLsvItem.SubItems[3].Text=m_cboTempUsage.Text;
			objLsvItem.SubItems[4].Text=m_cboTempFrequency.Text;

			m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strRemark= m_txtTempRemark.Text;
			objLsvItem.SubItems[5].Text=m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strRemark;
			objLsvItem.Tag=m_objCurrentNewOrderRowInfo;
			m_lsvTempPhysicianOrder.Items.Add(objLsvItem);
			m_mthClearTempInputGroup();
			
			
			
		}

	
	
		
		private void m_mthTempSubmitPhysicianOrder()
		{
			
			
			ArrayList arlBase=new ArrayList();
			ArrayList arlContent=new ArrayList();
			int intCurrentID=0;
			for(int i=0;i<m_lsvTempPhysicianOrder.Items.Count;i++)
			{
				if(((clsNewOrderRowInfo)m_lsvTempPhysicianOrder.Items[i].Tag).m_intSubOrderFlag==0)
				{
					intCurrentID++;
					((clsNewOrderRowInfo)m_lsvTempPhysicianOrder.Items[i].Tag).m_objPhysicianOrderBaseValueArr.m_strOrderID=intCurrentID.ToString("00");
					((clsNewOrderRowInfo)m_lsvTempPhysicianOrder.Items[i].Tag).m_objPhysicianOrderContentValueArr.m_strOrderID=intCurrentID.ToString("00");

				}
				else
				{
					((clsNewOrderRowInfo)m_lsvTempPhysicianOrder.Items[i].Tag).m_objPhysicianOrderContentValueArr.m_strOrderID=intCurrentID.ToString("00");
				}

			}
			for(int i=0;i<m_lsvTempPhysicianOrder.Items.Count;i++)
			{
				if(m_lsvTempPhysicianOrder.Items[i].Tag!=null)
				{
					if(((clsNewOrderRowInfo)m_lsvTempPhysicianOrder.Items[i].Tag).m_objPhysicianOrderBaseValueArr!=null)
						arlBase.Add(((clsNewOrderRowInfo)m_lsvTempPhysicianOrder.Items[i].Tag).m_objPhysicianOrderBaseValueArr);
					if(((clsNewOrderRowInfo)m_lsvTempPhysicianOrder.Items[i].Tag).m_objPhysicianOrderContentValueArr!=null)
						arlContent.Add(((clsNewOrderRowInfo)m_lsvTempPhysicianOrder.Items[i].Tag).m_objPhysicianOrderContentValueArr);
				}

			}
			clsPhysicianOrderBaseValue[] objOrderBaseArr=(clsPhysicianOrderBaseValue[])arlBase.ToArray(typeof(clsPhysicianOrderBaseValue));
			clsPhysicianOrderContentValue[] objContentArr=(clsPhysicianOrderContentValue[] )arlContent.ToArray(typeof(clsPhysicianOrderContentValue));

			long lngRes=m_objDomain.m_lngCommitPhysicianOrder(objOrderBaseArr,objContentArr,null);
			if(lngRes<=0)
			{
				m_ShowMessage("无法提交。");
				return;
			}
			m_lsvTempPhysicianOrder.Items.Clear();
		}

		/// <summary>
		/// 取消主医嘱
		/// </summary>
		private void m_mthTempRemovePhysicianOrder()
		{
			if(m_lsvTempPhysicianOrder.SelectedItems.Count==0) return;
			if(((clsNewOrderRowInfo) m_lsvTempPhysicianOrder.SelectedItems[0].Tag).m_intSubOrderFlag==0)
			{
				if(m_lsvTempPhysicianOrder.SelectedItems[0].Index+1>=m_lsvTempPhysicianOrder.Items.Count)
				{
					m_lsvTempPhysicianOrder.SelectedItems[0].Remove();
				}
				else if(((clsNewOrderRowInfo)m_lsvTempPhysicianOrder.Items[ m_lsvTempPhysicianOrder.SelectedItems[0].Index+1].Tag).m_intSubOrderFlag>=0)
				{
					if(clsPublicFunction.ShowQuestionMessageBox("是否删除该主医嘱及其所有子医嘱？")!=DialogResult.Yes) return;
					int intTemp1=m_lsvTempPhysicianOrder.SelectedItems[0].Index;
					m_lsvTempPhysicianOrder.SelectedItems[0].Remove();
					do
					{
						if(((clsNewOrderRowInfo) m_lsvTempPhysicianOrder.Items[intTemp1].Tag).m_intSubOrderFlag!=0)m_lsvTempPhysicianOrder.Items[intTemp1].Remove();
						else break;
					}while(intTemp1<m_lsvTempPhysicianOrder.Items.Count);
				}
			}
			else if(((clsNewOrderRowInfo) m_lsvTempPhysicianOrder.SelectedItems[0].Tag).m_intSubOrderFlag==1)
			{
				m_lsvTempPhysicianOrder.SelectedItems[0].Remove();
			}
			else if(((clsNewOrderRowInfo) m_lsvTempPhysicianOrder.SelectedItems[0].Tag).m_intSubOrderFlag==2)
			{
				int intTemp2=m_lsvTempPhysicianOrder.SelectedItems[0].Index;
				if(((clsNewOrderRowInfo) m_lsvTempPhysicianOrder.Items[intTemp2-1].Tag).m_intSubOrderFlag==0)
				{
					m_lsvTempPhysicianOrder.Items[intTemp2-1].SubItems[2].Text=m_lsvTempPhysicianOrder.Items[intTemp2-1].SubItems[2].Text.Substring(0,14);
				}
				else if(((clsNewOrderRowInfo) m_lsvTempPhysicianOrder.Items[intTemp2-1].Tag).m_intSubOrderFlag==1)
				{
					m_lsvTempPhysicianOrder.Items[intTemp2-1].SubItems[2].Text=m_lsvTempPhysicianOrder.Items[intTemp2-1].SubItems[2].Text.Substring(0,14) + "┙";
					((clsNewOrderRowInfo) m_lsvTempPhysicianOrder.Items[intTemp2-1].Tag).m_intSubOrderFlag=2;
				}

				m_lsvTempPhysicianOrder.SelectedItems[0].Remove();
			}
		}
		
		private void m_mthClearTempInputGroup()
		{
			m_objCurrentNewOrderRowInfo=new clsNewOrderRowInfo();
			foreach( Control ctl in m_grbTempPhysicianOrder.Controls)
			{
				if(ctl.GetType().Name=="ctlBorderTextBox")
				{
					ctl.Text="";
				}
				else if(ctl.GetType().Name=="ctlComboBox")
				{
					((ctlComboBox)ctl).SelectedIndex=-1;
				}
			}
			for(int i=0;i<m_lsvMedical.Items[0].SubItems.Count;i++)
			{
				m_lsvTempMedical.Items[0].SubItems[i].Text="";
			}
			
		}
		private bool m_blnTempInputValid()
		{
			
			if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strOrderTypeID==null
				|| m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strOrderTypeID.Trim().Length==0
				|| m_cboTempPhysicianOrderType.SelectedIndex==-1)
			{
				m_ShowMessage("你还没有选择医嘱类型");
				return false;
			}
			if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strOrderTypeID=="007")
			{
				if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemID==null
					|| m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemID.Trim().Length==0)
				{
					m_ShowMessage("你还没有选择药品名称。");
					return false;
				}
				if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemTypeID==null
					|| m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemTypeID.Trim().Length==0)
				{
					m_ShowMessage("你还没有选择药品剂型。");
					return false;
				}
				if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemStandardID==null
					|| m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemStandardID.Trim().Length==0
					|| m_cboTempMedicineStandard.SelectedIndex==-1)
				{
					m_ShowMessage("你还没有选择药品规格。");
					return false;
				}
				if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemUnitID==null
					|| m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemUnitID.Trim().Length==0)
				{
					m_ShowMessage("你还没有选择药品单位。");
					return false;
				}
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemDosage=m_txtTempMedicalDose.Text.Trim();
				try
				{
					float.Parse(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemDosage);
				}
				catch
				{
					m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemDosage=null;
					m_ShowMessage("剂量必须为数字且不可为空。");
					return false;
				}
				if(m_blnIsSubOrder) return true;
				if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strFrequencyID==null
					|| m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strFrequencyID.Trim().Length==0
					|| m_cboTempFrequency.SelectedIndex==-1)
				{
					m_ShowMessage("你还没有选择药品频次。");
					return false;
				}
				if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strUsageID==null
					|| m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strUsageID.Trim().Length==0
					|| m_cboTempUsage.SelectedIndex==-1)
				{
					m_ShowMessage("你还没有选择药品用法。");
					return false;
				}
				return true;
			}
			else
			{
				if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strDetailID==null
					|| m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strDetailID.Trim().Length==0)
				{
					m_ShowMessage("你还没有输入医嘱名称");
					return false;
				}
				return true;
			}
			
			
		}

		private void m_mthFillShortTermOrderComboBox()
		{
			m_cboTempPhysicianOrderType.ClearItem();
			if(m_objOrderTypeArr!=null  )
			{
				for(int i=0;i<m_objOrderTypeArr.Length;i++)
				{
					if(m_objOrderTypeArr[i].m_strOrderTypeID!=null && m_objOrderTypeArr[i].m_strOrderTypeName!=null)
					{
						m_cboTempPhysicianOrderType.AddItem(m_objOrderTypeArr[i].m_strOrderTypeName.Trim());
					}
				}
			}
			m_cboTempUsage.ClearItem();
			if(m_objOrderUsageArr!=null  )
			{
				for(int i=0;i<m_objOrderUsageArr.Length;i++)
				{
					if(m_objOrderUsageArr[i].m_strUsageID!=null && m_objOrderUsageArr[i].m_strUsageName!=null)
					{
						m_cboTempUsage.AddItem(m_objOrderUsageArr[i].m_strUsageName.Trim());
					}
				}
			}
			m_cboTempFrequency.ClearItem();
			if(m_objFrequencyInfoArr!=null  )
			{
				for(int i=0;i<m_objFrequencyInfoArr.Length;i++)
				{
					if(m_objFrequencyInfoArr[i].m_strFrequencyID!=null && m_objFrequencyInfoArr[i].m_strFrequencyName!=null)
					{
						m_cboTempFrequency.AddItem(m_objFrequencyInfoArr[i].m_strFrequencyName.Trim());
					}
				}
			}
		}

		#endregion

		#region 长期医嘱的界面控制

		
		private void m_mthAddPhysicianOrder()
		{
			if(m_objBaseCurrentPatient==null || m_objBaseCurrentPatient.m_ObjInBedInfo==null 
				|| m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo==null)
			{
				m_ShowMessage("你还没有选定病人。");
				return;
			}

			if(m_blnIsSubOrder)
			{
				if(m_lsvPhysicianOrder.Items.Count==0)
				{
					m_ShowMessage("上面列表中没有医嘱。");
					return;
				}
				else
				{
					if(!m_blnLongTermInputValid()) return;
					m_objCurrentNewOrderRowInfo.m_intSubOrderFlag=2;
					if(((clsNewOrderRowInfo) m_lsvPhysicianOrder.Items[m_lsvPhysicianOrder.Items.Count-1].Tag).m_intSubOrderFlag==2)
					{
						((clsNewOrderRowInfo) m_lsvPhysicianOrder.Items[m_lsvPhysicianOrder.Items.Count-1].Tag).m_intSubOrderFlag=1;
						string strTemp3=m_lsvPhysicianOrder.Items[m_lsvPhysicianOrder.Items.Count-1].SubItems[2].Text.Substring(0,14);
						m_lsvPhysicianOrder.Items[m_lsvPhysicianOrder.Items.Count-1].SubItems[2].Text=strTemp3+"│";
						
					}
					else if(((clsNewOrderRowInfo) m_lsvPhysicianOrder.Items[m_lsvPhysicianOrder.Items.Count-1].Tag).m_intSubOrderFlag==0)
					{
						string strTemp1=m_lsvPhysicianOrder.Items[m_lsvPhysicianOrder.Items.Count-1].SubItems[2].Text+"              ";
						strTemp1=strTemp1.Substring(0,14);
						strTemp1+="┑";
						m_lsvPhysicianOrder.Items[m_lsvPhysicianOrder.Items.Count-1].SubItems[2].Text=strTemp1;
					}
				}
				for(int i=0;i<m_objOrderUsageArr.Length;i++)
				{
					if(m_objOrderUsageArr[i].m_strUsageID==((clsNewOrderRowInfo) m_lsvPhysicianOrder.Items[m_lsvPhysicianOrder.Items.Count-1].Tag).m_objPhysicianOrderContentValueArr.m_strUsageID)
					{
						m_cboUsage.SelectedIndex=i;
						break;
					}
				}
				for(int i=0;i<m_objFrequencyInfoArr.Length;i++)
				{
					if(m_objFrequencyInfoArr[i].m_strFrequencyID==((clsNewOrderRowInfo) m_lsvPhysicianOrder.Items[m_lsvPhysicianOrder.Items.Count-1].Tag).m_objPhysicianOrderContentValueArr.m_strFrequencyID)
					{
						m_cboFrequency.SelectedIndex=i;
						break;
					}
				}
			}
			else
			{
				if(!m_blnLongTermInputValid()) return;
				m_objCurrentNewOrderRowInfo.m_intSubOrderFlag=0;
			}

			ListViewItem objLsvItem=new ListViewItem(new string[]{"","","","","","","",""});
			
			
			if(m_objCurrentNewOrderRowInfo.m_intSubOrderFlag==0)
			{
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderBaseValueArr.m_strInPatientID=m_objBaseCurrentPatient.m_StrInPatientID;
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderBaseValueArr.m_strInPatientDate=m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss");
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderBaseValueArr.m_strStartDate=m_dtpStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderBaseValueArr.m_strStartUserID=MDIParent.OperatorID;
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderBaseValueArr.m_strEndDate=m_dtpStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderBaseValueArr.m_strOrderFlag="0";

				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strInPatientID=m_objBaseCurrentPatient.m_StrInPatientID;
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strInPatientDate=m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss");

				objLsvItem.SubItems[0].Text=m_objCurrentNewOrderRowInfo.m_objPhysicianOrderBaseValueArr.m_strStartDate;
				objLsvItem.SubItems[2].Text=m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemDosage;
				objLsvItem.SubItems[6].Text=m_objCurrentNewOrderRowInfo.m_objPhysicianOrderBaseValueArr.m_strEndDate;
			}
			else
			{
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderBaseValueArr=null;
				objLsvItem.SubItems[0].Text="";
				objLsvItem.SubItems[6].Text="";
				string strTemp2=m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemDosage + "              ";
				strTemp2=strTemp2.Substring(0,14);
				strTemp2+="┙";
				objLsvItem.SubItems[2].Text=strTemp2;
				
				for(int i=m_lsvPhysicianOrder.Items.Count-1;i>=0;i--)
				{
					if(((clsNewOrderRowInfo) m_lsvPhysicianOrder.Items[i].Tag).m_intSubOrderFlag==0)
					{
						m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strInPatientID
							=((clsNewOrderRowInfo) m_lsvPhysicianOrder.Items[i].Tag).m_objPhysicianOrderBaseValueArr.m_strInPatientID;
						m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strInPatientDate
							=((clsNewOrderRowInfo) m_lsvPhysicianOrder.Items[i].Tag).m_objPhysicianOrderBaseValueArr.m_strInPatientDate;
						break;
					}
				}
			}
			

			objLsvItem.SubItems[1].Text=m_lsvMedical.Items[0].SubItems[0].Text;
	
			objLsvItem.SubItems[3].Text=m_cboUsage.Text;
			objLsvItem.SubItems[4].Text=m_cboFrequency.Text;

			m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strRemark= m_txtRemark.Text;
			objLsvItem.SubItems[5].Text=m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strRemark;
			objLsvItem.Tag=m_objCurrentNewOrderRowInfo;
			m_lsvPhysicianOrder.Items.Add(objLsvItem);
			m_mthClearLongTermInputGroup();
			
			
			
		}

		
		private void m_mthSubmitPhysicianOrder()
		{
			
			
			ArrayList arlBase=new ArrayList();
			ArrayList arlContent=new ArrayList();
			int intCurrentID=0;
			for(int i=0;i<m_lsvPhysicianOrder.Items.Count;i++)
			{
				if(((clsNewOrderRowInfo)m_lsvPhysicianOrder.Items[i].Tag).m_intSubOrderFlag==0)
				{
					intCurrentID++;
					((clsNewOrderRowInfo)m_lsvPhysicianOrder.Items[i].Tag).m_objPhysicianOrderBaseValueArr.m_strOrderID=intCurrentID.ToString("00");
					((clsNewOrderRowInfo)m_lsvPhysicianOrder.Items[i].Tag).m_objPhysicianOrderContentValueArr.m_strOrderID=intCurrentID.ToString("00");

				}
				else
				{
					((clsNewOrderRowInfo)m_lsvPhysicianOrder.Items[i].Tag).m_objPhysicianOrderContentValueArr.m_strOrderID=intCurrentID.ToString("00");
				}

			}
			for(int i=0;i<m_lsvPhysicianOrder.Items.Count;i++)
			{
				if(m_lsvPhysicianOrder.Items[i].Tag!=null)
				{
					if(((clsNewOrderRowInfo)m_lsvPhysicianOrder.Items[i].Tag).m_objPhysicianOrderBaseValueArr!=null)
						arlBase.Add(((clsNewOrderRowInfo)m_lsvPhysicianOrder.Items[i].Tag).m_objPhysicianOrderBaseValueArr);
					if(((clsNewOrderRowInfo)m_lsvPhysicianOrder.Items[i].Tag).m_objPhysicianOrderContentValueArr!=null)
						arlContent.Add(((clsNewOrderRowInfo)m_lsvPhysicianOrder.Items[i].Tag).m_objPhysicianOrderContentValueArr);
				}

			}
			clsPhysicianOrderBaseValue[] objOrderBaseArr=(clsPhysicianOrderBaseValue[])arlBase.ToArray(typeof(clsPhysicianOrderBaseValue));
			clsPhysicianOrderContentValue[] objContentArr=(clsPhysicianOrderContentValue[] )arlContent.ToArray(typeof(clsPhysicianOrderContentValue));

			long lngRes=m_objDomain.m_lngCommitPhysicianOrder(objOrderBaseArr,objContentArr,null);
			if(lngRes<=0)
			{
				m_ShowMessage("无法提交。");
				return;
			}
			m_lsvPhysicianOrder.Items.Clear();
		}

		/// <summary>
		/// 取消主医嘱
		/// </summary>
		private void m_mthRemovePhysicianOrder()
		{
			if(m_lsvPhysicianOrder.SelectedItems.Count==0) return;
			if(((clsNewOrderRowInfo) m_lsvPhysicianOrder.SelectedItems[0].Tag).m_intSubOrderFlag==0)
			{
				if(m_lsvPhysicianOrder.SelectedItems[0].Index+1>=m_lsvPhysicianOrder.Items.Count)
				{
					m_lsvPhysicianOrder.SelectedItems[0].Remove();
				}
				else if(((clsNewOrderRowInfo)m_lsvPhysicianOrder.Items[ m_lsvPhysicianOrder.SelectedItems[0].Index+1].Tag).m_intSubOrderFlag>=0)
				{
					if(clsPublicFunction.ShowQuestionMessageBox("是否删除该主医嘱及其所有子医嘱？")!=DialogResult.Yes) return;
					int intTemp1=m_lsvPhysicianOrder.SelectedItems[0].Index;
					m_lsvPhysicianOrder.SelectedItems[0].Remove();
					do
					{
						if(((clsNewOrderRowInfo) m_lsvPhysicianOrder.Items[intTemp1].Tag).m_intSubOrderFlag!=0)m_lsvPhysicianOrder.Items[intTemp1].Remove();
						else break;
					}while(intTemp1<m_lsvPhysicianOrder.Items.Count);
				}
			}
			else if(((clsNewOrderRowInfo) m_lsvPhysicianOrder.SelectedItems[0].Tag).m_intSubOrderFlag==1)
			{
				m_lsvPhysicianOrder.SelectedItems[0].Remove();
			}
			else if(((clsNewOrderRowInfo) m_lsvPhysicianOrder.SelectedItems[0].Tag).m_intSubOrderFlag==2)
			{
				int intTemp2=m_lsvPhysicianOrder.SelectedItems[0].Index;
				if(((clsNewOrderRowInfo) m_lsvPhysicianOrder.Items[intTemp2-1].Tag).m_intSubOrderFlag==0)
				{
					m_lsvPhysicianOrder.Items[intTemp2-1].SubItems[2].Text=m_lsvPhysicianOrder.Items[intTemp2-1].SubItems[2].Text.Substring(0,14);
				}
				else if(((clsNewOrderRowInfo) m_lsvPhysicianOrder.Items[intTemp2-1].Tag).m_intSubOrderFlag==1)
				{
					m_lsvPhysicianOrder.Items[intTemp2-1].SubItems[2].Text=m_lsvPhysicianOrder.Items[intTemp2-1].SubItems[2].Text.Substring(0,14) + "┙";
					((clsNewOrderRowInfo) m_lsvPhysicianOrder.Items[intTemp2-1].Tag).m_intSubOrderFlag=2;
				}

				m_lsvPhysicianOrder.SelectedItems[0].Remove();
			}
		}
		
		private void m_mthClearLongTermInputGroup()
		{
			m_objCurrentNewOrderRowInfo=new clsNewOrderRowInfo();
			foreach( Control ctl in m_grbPhysicianOrder.Controls)
			{
				if(ctl.GetType().Name=="ctlBorderTextBox")
				{
					ctl.Text="";
				}
				else if(ctl.GetType().Name=="ctlComboBox")
				{
					((ctlComboBox)ctl).SelectedIndex=-1;
				}
			}
			for(int i=0;i<m_lsvMedical.Items[0].SubItems.Count;i++)
			{
				m_lsvMedical.Items[0].SubItems[i].Text="";
			}
			
		}
		private bool m_blnLongTermInputValid()
		{
			
			if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strOrderTypeID==null
				|| m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strOrderTypeID.Trim().Length==0
				|| m_cboPhysicianOrderType.SelectedIndex==-1)
			{
				m_ShowMessage("你还没有选择医嘱类型");
				return false;
			}
			if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strOrderTypeID=="007")
			{
				if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemID==null
					|| m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemID.Trim().Length==0)
				{
					m_ShowMessage("你还没有选择药品名称。");
					return false;
				}
				if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemTypeID==null
					|| m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemTypeID.Trim().Length==0)
				{
					m_ShowMessage("你还没有选择药品剂型。");
					return false;
				}
				if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemStandardID==null
					|| m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemStandardID.Trim().Length==0
					|| m_cboMedicineStandard.SelectedIndex==-1)
				{
					m_ShowMessage("你还没有选择药品规格。");
					return false;
				}
				if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemUnitID==null
					|| m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemUnitID.Trim().Length==0)
				{
					m_ShowMessage("你还没有选择药品单位。");
					return false;
				}
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemDosage=m_txtMedicalDose.Text.Trim();
				try
				{
					float.Parse(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemDosage);
				}
				catch
				{
					m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemDosage=null;
					m_ShowMessage("剂量必须为数字且不可为空。");
					return false;
				}
				if(m_blnIsSubOrder) return true;
				if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strFrequencyID==null
					|| m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strFrequencyID.Trim().Length==0
					|| m_cboFrequency.SelectedIndex==-1)
				{
					m_ShowMessage("你还没有选择药品频次。");
					return false;
				}
				if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strUsageID==null
					|| m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strUsageID.Trim().Length==0
					|| m_cboUsage.SelectedIndex==-1)
				{
					m_ShowMessage("你还没有选择药品用法。");
					return false;
				}
				return true;
			}
			else
			{
				if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strDetailID==null
					|| m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strDetailID.Trim().Length==0)
				{
					m_ShowMessage("你还没有输入医嘱名称");
					return false;
				}
				return true;
			}
			
			
		}

		private void m_mthFillLongTermOrderComboBox()
		{
			m_cboPhysicianOrderType.ClearItem();
			if(m_objOrderTypeArr!=null  )
			{
				for(int i=0;i<m_objOrderTypeArr.Length;i++)
				{
					if(m_objOrderTypeArr[i].m_strOrderTypeID!=null && m_objOrderTypeArr[i].m_strOrderTypeName!=null)
					{
						m_cboPhysicianOrderType.AddItem(m_objOrderTypeArr[i].m_strOrderTypeName.Trim());
					}
				}
			}
			m_cboUsage.ClearItem();
			if(m_objOrderUsageArr!=null  )
			{
				for(int i=0;i<m_objOrderUsageArr.Length;i++)
				{
					if(m_objOrderUsageArr[i].m_strUsageID!=null && m_objOrderUsageArr[i].m_strUsageName!=null)
					{
						m_cboUsage.AddItem(m_objOrderUsageArr[i].m_strUsageName.Trim());
					}
				}
			}
			m_cboFrequency.ClearItem();
			if(m_objFrequencyInfoArr!=null  )
			{
				for(int i=0;i<m_objFrequencyInfoArr.Length;i++)
				{
					if(m_objFrequencyInfoArr[i].m_strFrequencyID!=null && m_objFrequencyInfoArr[i].m_strFrequencyName!=null)
					{
						m_cboFrequency.AddItem(m_objFrequencyInfoArr[i].m_strFrequencyName.Trim());
					}
				}
			}
			

			
			//			m_cboMedicalUnit.AddRangeItems(new string[]{"ml","g"});
		}

		#endregion

		private void m_mthLoadCurrentQueryLsv(ListView p_lsvQuery)
		{
			if(p_lsvQuery!=null) m_lsvCurrentQueryLsv=p_lsvQuery;
			if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strOrderTypeID==null
				|| m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strOrderTypeID.Trim().Length==0)
			{
				m_ShowMessage("你还没有选择医嘱类型。");
				return;
			}
			if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strOrderTypeID.Trim()=="007")
			{
				if(m_intCurrentLevel==0)
				{
					if(m_objCurrentNewOrderRowInfo.m_intQueryType<0)
					{
						m_ShowMessage("你还没选择查询类型。");
						return;
					}
					
					m_blnLoadMedicineName(m_objCurrentNewOrderRowInfo.m_intQueryType,null);
						
				}
				else if(m_intCurrentLevel==1)
				{
					if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemID==null
						|| m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemID.Trim().Length==0)
					{
						m_ShowMessage("你还没选择药名。");
						return;
					}
					m_blnLoadMedicineTypeByMedicineID(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemID.Trim(),null);
				}
				
				
			}
			else
			{
				m_blnLoadOrderTypeDetailByOrderTypeID(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strOrderTypeID.Trim(),null);
			}

		}
		private bool m_blnLoadMedicineName(int p_intQueryType,ListView p_lsvQuery)
		{
			if(p_lsvQuery!=null) m_lsvCurrentQueryLsv=p_lsvQuery;
			m_lsvCurrentQueryLsv.Items.Clear();
			if(m_txtCurrentTextBox.Text==null || m_txtCurrentTextBox.Text.Trim().Length==0) return false;
			clsPhysicianOrderMedicineNameValue[] objMedicineNameArr=null;
			long lngRes=1;
			switch(p_intQueryType)
			{
				case 0:
					lngRes=m_objDomain.m_lngGetMedicineNameByPingYinCode(m_txtCurrentTextBox.Text.Trim(),out objMedicineNameArr);
					break;
				case 1:
					lngRes=m_objDomain.m_lngGetMedicineNameByLatinCode(m_txtCurrentTextBox.Text.Trim(),out objMedicineNameArr);
					break;
				case 2:
					lngRes=m_objDomain.m_lngGetMedicineNameByEnglishCode(m_txtCurrentTextBox.Text.Trim(),out objMedicineNameArr);
					break;
				case 3:
					lngRes=m_objDomain.m_lngGetMedicineNameByMedicineID(m_txtCurrentTextBox.Text.Trim(),out objMedicineNameArr);
					break;
				default:
					break;
			}
			if(lngRes<=0 || objMedicineNameArr==null) return false;
			for(int i=0;i<objMedicineNameArr.Length;i++)
			{
				if(objMedicineNameArr[i].m_strMedicineName!=null && objMedicineNameArr[i].m_strMedicineID!=null)
				{
					ListViewItem objLsvItem=new ListViewItem(objMedicineNameArr[i].m_strMedicineName.Trim());
					objLsvItem.Tag=objMedicineNameArr[i].m_strMedicineID.Trim();
					m_lsvCurrentQueryLsv.Items.Add(objLsvItem);

				}
			}
			m_lsvCurrentQueryLsv.Visible=true;
			m_lsvCurrentQueryLsv.BringToFront();
			m_lsvCurrentQueryLsv.Focus();
			if(m_lsvCurrentQueryLsv.Items.Count>0) m_lsvCurrentQueryLsv.Items[0].Selected=true;
			m_intCurrentLevel++;
			return true;
		}
		private bool m_blnLoadMedicineTypeByMedicineID(string p_strID,ListView p_lsvQuery)
		{
			if(p_strID==null || p_strID.Trim().Length==0) return false;
			if(p_lsvQuery!=null) m_lsvCurrentQueryLsv=p_lsvQuery;
			m_lsvCurrentQueryLsv.Items.Clear();
			if(m_txtCurrentTextBox.Text==null || m_txtCurrentTextBox.Text.Trim().Length==0) return false;
			clsPhysicianOrderMedicineTypeValue [] objMedicineTypeArr=null;
			long lngRes=m_objDomain.m_lngGetMedicineType(p_strID,out objMedicineTypeArr);
			if(lngRes<=0 || objMedicineTypeArr==null) return false;
			for(int i=0;i<objMedicineTypeArr.Length;i++)
			{
				if(objMedicineTypeArr[i].m_strMedicineOfTypeID!=null && objMedicineTypeArr[i].m_strMedicineOfTypeName!=null)
				{
					ListViewItem objLsvItem=new ListViewItem(objMedicineTypeArr[i].m_strMedicineOfTypeName.Trim());
					objLsvItem.Tag=objMedicineTypeArr[i].m_strMedicineOfTypeID.Trim();
					m_lsvCurrentQueryLsv.Items.Add(objLsvItem);
				}
			}
			if(m_lsvCurrentQueryLsv.Items.Count>0) m_lsvCurrentQueryLsv.Items[0].Selected=true;
			m_intCurrentLevel++;
			return true;
		}
		private bool m_blnLoadOrderTypeDetailByOrderTypeID(string p_strID,ListView p_lsvQuery)
		{
			if(p_lsvQuery!=null) m_lsvCurrentQueryLsv=p_lsvQuery;
			m_lsvCurrentQueryLsv.Items.Clear();
			clsPhysicianOrderTypeDetailValue [] objTypeDetailArr=null;
			long lngRes=m_objDomain.m_lngGetPhysicianOrderTypeDetail(p_strID,out objTypeDetailArr);
			if(lngRes<=0 || objTypeDetailArr==null) return false;
			for(int i=0;i<objTypeDetailArr.Length;i++)
			{
				if(objTypeDetailArr[i].m_strDetailID!=null && objTypeDetailArr[i].m_strDetailName!=null)
				{
					ListViewItem objLsvItem=new ListViewItem(objTypeDetailArr[i].m_strDetailName.Trim());
					objLsvItem.Tag=objTypeDetailArr[i].m_strDetailID.Trim();
					m_lsvCurrentQueryLsv.Items.Add(objLsvItem);
				}
			}
			m_lsvCurrentQueryLsv.Visible=true;
			m_lsvCurrentQueryLsv.BringToFront();
			m_lsvCurrentQueryLsv.Focus();
			if(m_lsvCurrentQueryLsv.Items.Count>0) m_lsvCurrentQueryLsv.Items[0].Selected=true;
			return true;
		}
		

		#region 医嘱列表的控制

		#endregion

		#region 用ListView进行有关查询的控制

		private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(sender==null) return;
			string strTypeName=sender.GetType().Name;
			if( strTypeName=="ctlBorderTextBox")
			{
				m_txtCurrentTextBox=(ctlBorderTextBox)sender;
				if(m_txtCurrentTextBox.Name== "m_txtQuery" || m_txtCurrentTextBox.Name=="m_txtTemptQuery")
				{
					switch(e.KeyValue)
					{
						case 13:// enter	
							m_intCurrentLevel=0;
							if(m_txtCurrentTextBox.Name== "m_txtQuery")
							{
								m_mthLoadCurrentQueryLsv(m_lsvLongTermQuery);
				
							}
							else if(m_txtCurrentTextBox.Name== "m_txtTemptQuery")
							{
								m_mthLoadCurrentQueryLsv(m_lsvTempQuery);
				
							}
						
							break;
						case 38://Arrow Up
							break;
						case 40://Arrow Down
							m_intCurrentLevel=0;
							if(m_txtCurrentTextBox.Name== "m_txtQuery")
							{
								m_mthLoadCurrentQueryLsv(m_lsvLongTermQuery);
							}
							else if(m_txtCurrentTextBox.Name== "m_txtTemptQuery")
							{
								m_mthLoadCurrentQueryLsv(m_lsvTempQuery);
				
							}
							break;
					}
				}
			}
			else if( strTypeName=="ListView")
			{
				m_lsvCurrentQueryLsv=(ListView)sender;
				//此处无需判断当前ListView的名称，因为这是由TextBox确定的，但需确定是否作为我们所使用的下拉框的ListView
				if(m_lsvCurrentQueryLsv.Name!="m_lsvLongTermQuery" && m_lsvCurrentQueryLsv.Name!="m_lsvTempQuery") return;
				switch(e.KeyValue)
				{
					case 13:// enter	
						if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strOrderTypeID==null
							|| m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strOrderTypeID.Trim().Length==0)
						{
							m_ShowMessage("你还没有选择医嘱类型。");
							return;
						}
						
						if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strOrderTypeID.Trim()!="007")
						{
							if(m_lsvCurrentQueryLsv.SelectedItems.Count==1 && 
								m_lsvCurrentQueryLsv.SelectedItems[0].Tag!=null && m_lsvCurrentQueryLsv.SelectedItems[0].Tag.GetType().Name=="String"
								&& m_lsvCurrentQueryLsv.SelectedItems[0].Text!=null)
							{
								m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strDetailID
									=(string)m_lsvCurrentQueryLsv.SelectedItems[0].Tag;
								if(m_lsvCurrentQueryLsv.Name=="m_lsvLongTermQuery")
								{
									m_lsvMedical.Items[0].SubItems[0].Text=m_lsvCurrentQueryLsv.SelectedItems[0].Text.Trim();
								}
								else if(m_lsvCurrentQueryLsv.Name=="m_lsvTempQuery")
								{
									m_lsvTempMedical.Items[0].SubItems[0].Text=m_lsvCurrentQueryLsv.SelectedItems[0].Text.Trim();
								}
							}
							m_txtCurrentTextBox.Text="";
							m_txtCurrentTextBox.Focus();
							return;
						}
						else if(m_intCurrentLevel==1)
						{
							if(m_lsvCurrentQueryLsv.SelectedItems.Count!=1 || m_lsvCurrentQueryLsv.SelectedItems[0].Tag==null
								|| m_lsvCurrentQueryLsv.SelectedItems[0].Tag.GetType().Name!="String"
								||m_lsvCurrentQueryLsv.SelectedItems[0].Text==null) return;
							m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemID
								=(string)m_lsvCurrentQueryLsv.SelectedItems[0].Tag;							
							if(m_lsvCurrentQueryLsv.Name=="m_lsvLongTermQuery")
							{
								m_lsvMedical.Items[0].SubItems[0].Text=m_lsvCurrentQueryLsv.SelectedItems[0].Text.Trim();
							}
							else if(m_lsvCurrentQueryLsv.Name=="m_lsvTempQuery")
							{
								m_lsvTempMedical.Items[0].SubItems[0].Text=m_lsvCurrentQueryLsv.SelectedItems[0].Text.Trim();
							}
						}
						else if(m_intCurrentLevel==2)
						{
							if(m_lsvCurrentQueryLsv.SelectedItems.Count!=1 || m_lsvCurrentQueryLsv.SelectedItems[0].Tag==null
								|| m_lsvCurrentQueryLsv.SelectedItems[0].Tag.GetType().Name!="String"
								||m_lsvCurrentQueryLsv.SelectedItems[0].Text==null) return;
							m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemTypeID
								=(string)m_lsvCurrentQueryLsv.SelectedItems[0].Tag;	
							if(m_lsvCurrentQueryLsv.Name=="m_lsvLongTermQuery")
							{
								m_lsvMedical.Items[0].SubItems[0].Text
									+="("+m_lsvCurrentQueryLsv.SelectedItems[0].Text.Trim()+")";
							}
							else if(m_lsvCurrentQueryLsv.Name=="m_lsvTempQuery")
							{
								m_lsvTempMedical.Items[0].SubItems[0].Text
									+="("+m_lsvCurrentQueryLsv.SelectedItems[0].Text.Trim()+")";
							}
							m_intCurrentLevel=0;
							m_txtCurrentTextBox.Text="";
							m_txtCurrentTextBox.Focus();
						}
						
						m_mthLoadCurrentQueryLsv(null);
						break;
					case 38://Arrow Up
						if(m_lsvCurrentQueryLsv.Items.Count>0 && m_lsvCurrentQueryLsv.Items[0].Selected==true)
						{
							m_txtCurrentTextBox.Focus();
						}
						break;

				}
			}
			else if( strTypeName=="NumericUpDown")
			{
				if(e.KeyValue==27 && m_objEditAddIn.m_BlnIsOpen)
				{
					if(m_blnNurseIsUnconfirmed) m_mthNurseConfirmAddIn();
					else m_mthNursePerformAddIn();
				}
			}

		}

		private void m_mthEvent_LsvLostFocus(object sender, System.EventArgs e)
		{
			if(((Control)sender).GetType().Name=="ListView") ((Control)sender).Visible=false;
		}
		#endregion

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
			this.components = new System.ComponentModel.Container();
			this.m_tabPhysicianOrder = new System.Windows.Forms.TabControl();
			this.m_tbpLongTermPhycianOrder = new System.Windows.Forms.TabPage();
			this.m_lsvLongTermQuery = new System.Windows.Forms.ListView();
			this.clmPatientName_BaseForm = new System.Windows.Forms.ColumnHeader();
			this.m_grbPhysicianOrder = new System.Windows.Forms.GroupBox();
			this.label14 = new System.Windows.Forms.Label();
			this.m_txtRemark = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cmdSubmit = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.m_dtpEndDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.label7 = new System.Windows.Forms.Label();
			this.m_cboQueryType = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.m_cboPhysicianOrderType = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_chkIsSubPhysicainOrder = new System.Windows.Forms.CheckBox();
			this.m_cmdOK = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.m_txtQuery = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtMedicalDose = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cboUsage = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboFrequency = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboMedicineStandard = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_dtpStartDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.m_lsvMedical = new System.Windows.Forms.ListView();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.m_lsvPhysicianOrder = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader31 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.m_tbpNurseHandle = new System.Windows.Forms.TabPage();
			this.m_objNurseNumericInc = new System.Windows.Forms.NumericUpDown();
			this.m_lsvNurseAddIn = new System.Windows.Forms.ListView();
			this.columnHeader46 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader47 = new System.Windows.Forms.ColumnHeader();
			this.m_grbNursePhysicianOrder = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.m_cmdNurseDisplayAddIn = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.m_cmdSetConfirmed = new System.Windows.Forms.Button();
			this.m_lblNurseAddInTitle = new System.Windows.Forms.Label();
			this.m_cmdNurseSetPerformed = new System.Windows.Forms.Button();
			this.m_lblNursePerformDateTitle = new System.Windows.Forms.Label();
			this.m_dtpNursePerformDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.m_rdbNurseNotPerformed = new System.Windows.Forms.RadioButton();
			this.m_rdbNurseNotConfirmed = new System.Windows.Forms.RadioButton();
			this.m_lsvNursePhysicianOrder = new System.Windows.Forms.ListView();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader29 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader30 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader43 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader44 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader45 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader49 = new System.Windows.Forms.ColumnHeader();
			this.m_tbpShortTermPhycianOrder = new System.Windows.Forms.TabPage();
			this.m_lsvTempQuery = new System.Windows.Forms.ListView();
			this.columnHeader42 = new System.Windows.Forms.ColumnHeader();
			this.m_grbTempPhysicianOrder = new System.Windows.Forms.GroupBox();
			this.label15 = new System.Windows.Forms.Label();
			this.m_cmdTempSubmit = new System.Windows.Forms.Button();
			this.m_cboTempMedicineStandard = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboTempQueryType = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.m_cboTempPhysicianOrderType = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_chkTempIsSubPhysicainOrder = new System.Windows.Forms.CheckBox();
			this.m_cmdTempOK = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.m_txtTemptQuery = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTempMedicalDose = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cboTempUsage = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboTempFrequency = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_dtpTempStartDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.m_lsvTempMedical = new System.Windows.Forms.ListView();
			this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader21 = new System.Windows.Forms.ColumnHeader();
			this.label16 = new System.Windows.Forms.Label();
			this.m_txtTempRemark = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_lsvTempPhysicianOrder = new System.Windows.Forms.ListView();
			this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader23 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader25 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader26 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader27 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader41 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader28 = new System.Windows.Forms.ColumnHeader();
			this.label2 = new System.Windows.Forms.Label();
			this.m_tbpPhysicianOrderList = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.m_dtpToDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.label9 = new System.Windows.Forms.Label();
			this.m_cboOrderPerform = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.m_cboOrderEnd = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label13 = new System.Windows.Forms.Label();
			this.m_cboOrderCancel = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label17 = new System.Windows.Forms.Label();
			this.m_cboOrderApprove = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label18 = new System.Windows.Forms.Label();
			this.m_cboOrderListType = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cmdOrderQuery = new System.Windows.Forms.Button();
			this.m_dtpFromDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.m_lstPhysicianOrderList = new System.Windows.Forms.ListView();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader24 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader32 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader33 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader34 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader35 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader36 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader37 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader38 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader39 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader40 = new System.Windows.Forms.ColumnHeader();
			this.m_ctnPhysicianOrderList = new System.Windows.Forms.ContextMenu();
			this.m_mniCancelOrderList = new System.Windows.Forms.MenuItem();
			this.m_mniEndOrderList = new System.Windows.Forms.MenuItem();
			this.m_tabPhysicianOrderTemplateSet = new System.Windows.Forms.TabPage();
			this.m_cmdDeltteTemp = new System.Windows.Forms.Button();
			this.m_cmdApplyToTemp = new System.Windows.Forms.Button();
			this.m_cmdAlterTempRecord = new System.Windows.Forms.Button();
			this.m_cmdAddTempRecord = new System.Windows.Forms.Button();
			this.m_labType = new System.Windows.Forms.Label();
			this.m_labName = new System.Windows.Forms.Label();
			this.m_lstResultSet = new System.Windows.Forms.ListView();
			this.columnHeader63 = new System.Windows.Forms.ColumnHeader();
			this.m_cboXOrderFlag = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_labXItemUnitID = new System.Windows.Forms.Label();
			this.m_laIndicator = new System.Windows.Forms.Label();
			this.m_cboXStandardID = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboSelectMethod = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label19 = new System.Windows.Forms.Label();
			this.m_cboXOrderTypeID = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_chkBeChild = new System.Windows.Forms.CheckBox();
			this.label20 = new System.Windows.Forms.Label();
			this.m_txtGetSelectKeyWord = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtDosage = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cboXUsageID = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboXFrequencyID = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.listView2 = new System.Windows.Forms.ListView();
			this.columnHeader57 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader58 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader59 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader60 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader61 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader62 = new System.Windows.Forms.ColumnHeader();
			this.label21 = new System.Windows.Forms.Label();
			this.m_txtName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_lsvTemplateContent = new System.Windows.Forms.ListView();
			this.columnHeader65 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader66 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader67 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader68 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader69 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader70 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader71 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader72 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader73 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader48 = new System.Windows.Forms.ColumnHeader();
			this.m_trvPOTemplate = new System.Windows.Forms.TreeView();
			this.m_tooltipLsv = new System.Windows.Forms.ToolTip(this.components);
			this.m_tabPhysicianOrder.SuspendLayout();
			this.m_tbpLongTermPhycianOrder.SuspendLayout();
			this.m_grbPhysicianOrder.SuspendLayout();
			this.m_tbpNurseHandle.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_objNurseNumericInc)).BeginInit();
			this.m_grbNursePhysicianOrder.SuspendLayout();
			this.m_tbpShortTermPhycianOrder.SuspendLayout();
			this.m_grbTempPhysicianOrder.SuspendLayout();
			this.m_tbpPhysicianOrderList.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.m_tabPhysicianOrderTemplateSet.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_lblForTitle
			// 
			this.m_lblForTitle.Text = "医 嘱 管 理";
			this.m_lblForTitle.Visible = true;
			// 
			// lblSex
			// 
			this.lblSex.Visible = true;
			// 
			// lblAge
			// 
			this.lblAge.Visible = true;
			// 
			// lblBedNoTitle
			// 
			this.lblBedNoTitle.Visible = true;
			// 
			// lblInHospitalNoTitle
			// 
			this.lblInHospitalNoTitle.Visible = true;
			// 
			// lblNameTitle
			// 
			this.lblNameTitle.Visible = true;
			// 
			// lblSexTitle
			// 
			this.lblSexTitle.Visible = true;
			// 
			// lblAgeTitle
			// 
			this.lblAgeTitle.Visible = true;
			// 
			// lblAreaTitle
			// 
			this.lblAreaTitle.Visible = true;
			// 
			// m_lsvInPatientID
			// 
			this.m_lsvInPatientID.Visible = true;
			// 
			// txtInPatientID
			// 
			this.txtInPatientID.Visible = true;
			// 
			// m_txtPatientName
			// 
			this.m_txtPatientName.Visible = true;
			// 
			// m_txtBedNO
			// 
			this.m_txtBedNO.Visible = true;
			// 
			// m_cboArea
			// 
			this.m_cboArea.Visible = true;
			// 
			// m_lsvPatientName
			// 
			this.m_lsvPatientName.Visible = true;
			// 
			// m_lsvBedNO
			// 
			this.m_lsvBedNO.Visible = true;
			// 
			// m_cboDept
			// 
			this.m_cboDept.Visible = true;
			// 
			// lblDept
			// 
			this.lblDept.Visible = true;
			// 
			// m_tabPhysicianOrder
			// 
			this.m_tabPhysicianOrder.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.m_tabPhysicianOrder.Controls.AddRange(new System.Windows.Forms.Control[] {
																							  this.m_tbpLongTermPhycianOrder,
																							  this.m_tbpNurseHandle,
																							  this.m_tbpShortTermPhycianOrder,
																							  this.m_tbpPhysicianOrderList,
																							  this.m_tabPhysicianOrderTemplateSet});
			this.m_tabPhysicianOrder.Location = new System.Drawing.Point(8, 112);
			this.m_tabPhysicianOrder.Name = "m_tabPhysicianOrder";
			this.m_tabPhysicianOrder.SelectedIndex = 0;
			this.m_tabPhysicianOrder.Size = new System.Drawing.Size(1004, 500);
			this.m_tabPhysicianOrder.TabIndex = 501;
			this.m_tabPhysicianOrder.SelectedIndexChanged += new System.EventHandler(this.m_tabPhysicianOrder_SelectedIndexChanged);
			// 
			// m_tbpLongTermPhycianOrder
			// 
			this.m_tbpLongTermPhycianOrder.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_tbpLongTermPhycianOrder.Controls.AddRange(new System.Windows.Forms.Control[] {
																									this.m_lsvLongTermQuery,
																									this.m_grbPhysicianOrder,
																									this.m_lsvPhysicianOrder});
			this.m_tbpLongTermPhycianOrder.Location = new System.Drawing.Point(4, 28);
			this.m_tbpLongTermPhycianOrder.Name = "m_tbpLongTermPhycianOrder";
			this.m_tbpLongTermPhycianOrder.Size = new System.Drawing.Size(996, 468);
			this.m_tbpLongTermPhycianOrder.TabIndex = 0;
			this.m_tbpLongTermPhycianOrder.Text = "长期医嘱";
			// 
			// m_lsvLongTermQuery
			// 
			this.m_lsvLongTermQuery.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lsvLongTermQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lsvLongTermQuery.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								 this.clmPatientName_BaseForm});
			this.m_lsvLongTermQuery.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvLongTermQuery.ForeColor = System.Drawing.Color.White;
			this.m_lsvLongTermQuery.FullRowSelect = true;
			this.m_lsvLongTermQuery.GridLines = true;
			this.m_lsvLongTermQuery.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lsvLongTermQuery.Location = new System.Drawing.Point(460, 160);
			this.m_lsvLongTermQuery.Name = "m_lsvLongTermQuery";
			this.m_lsvLongTermQuery.Size = new System.Drawing.Size(224, 188);
			this.m_lsvLongTermQuery.TabIndex = 5;
			this.m_lsvLongTermQuery.View = System.Windows.Forms.View.List;
			this.m_lsvLongTermQuery.Visible = false;
			// 
			// clmPatientName_BaseForm
			// 
			this.clmPatientName_BaseForm.Width = 220;
			// 
			// m_grbPhysicianOrder
			// 
			this.m_grbPhysicianOrder.Controls.AddRange(new System.Windows.Forms.Control[] {
																							  this.label14,
																							  this.m_txtRemark,
																							  this.m_cmdSubmit,
																							  this.label8,
																							  this.m_dtpEndDate,
																							  this.label7,
																							  this.m_cboQueryType,
																							  this.label4,
																							  this.m_cboPhysicianOrderType,
																							  this.m_chkIsSubPhysicainOrder,
																							  this.m_cmdOK,
																							  this.label3,
																							  this.m_txtQuery,
																							  this.m_txtMedicalDose,
																							  this.m_cboUsage,
																							  this.m_cboFrequency,
																							  this.m_cboMedicineStandard,
																							  this.m_dtpStartDate,
																							  this.m_lsvMedical});
			this.m_grbPhysicianOrder.Location = new System.Drawing.Point(4, 288);
			this.m_grbPhysicianOrder.Name = "m_grbPhysicianOrder";
			this.m_grbPhysicianOrder.Size = new System.Drawing.Size(984, 152);
			this.m_grbPhysicianOrder.TabIndex = 1;
			this.m_grbPhysicianOrder.TabStop = false;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(700, 62);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(64, 23);
			this.label14.TabIndex = 15034;
			this.label14.Text = "备注：";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtRemark
			// 
			this.m_txtRemark.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtRemark.BorderColor = System.Drawing.Color.White;
			this.m_txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtRemark.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtRemark.ForeColor = System.Drawing.Color.White;
			this.m_txtRemark.Location = new System.Drawing.Point(764, 60);
			this.m_txtRemark.Name = "m_txtRemark";
			this.m_txtRemark.Size = new System.Drawing.Size(208, 26);
			this.m_txtRemark.TabIndex = 15033;
			this.m_txtRemark.Text = "";
			// 
			// m_cmdSubmit
			// 
			this.m_cmdSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdSubmit.Location = new System.Drawing.Point(876, 112);
			this.m_cmdSubmit.Name = "m_cmdSubmit";
			this.m_cmdSubmit.Size = new System.Drawing.Size(96, 28);
			this.m_cmdSubmit.TabIndex = 15032;
			this.m_cmdSubmit.Text = "提交";
			this.m_cmdSubmit.Click += new System.EventHandler(this.m_cmdSubmit_Click);
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.ForeColor = System.Drawing.Color.White;
			this.label8.Location = new System.Drawing.Point(404, 28);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(88, 24);
			this.label8.TabIndex = 15031;
			this.label8.Text = "停嘱日期：";
			// 
			// m_dtpEndDate
			// 
			this.m_dtpEndDate.BorderColor = System.Drawing.Color.White;
			this.m_dtpEndDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtpEndDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpEndDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpEndDate.DropButtonForeColor = System.Drawing.Color.White;
			this.m_dtpEndDate.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpEndDate.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpEndDate.Location = new System.Drawing.Point(496, 28);
			this.m_dtpEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpEndDate.Name = "m_dtpEndDate";
			this.m_dtpEndDate.Size = new System.Drawing.Size(204, 26);
			this.m_dtpEndDate.TabIndex = 15030;
			this.m_dtpEndDate.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpEndDate.TextForeColor = System.Drawing.Color.White;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label7.ForeColor = System.Drawing.Color.White;
			this.label7.Location = new System.Drawing.Point(32, 28);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 24);
			this.label7.TabIndex = 15029;
			this.label7.Text = "开嘱日期：";
			// 
			// m_cboQueryType
			// 
			this.m_cboQueryType.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboQueryType.BorderColor = System.Drawing.Color.White;
			this.m_cboQueryType.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboQueryType.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboQueryType.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboQueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboQueryType.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboQueryType.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboQueryType.ForeColor = System.Drawing.Color.White;
			this.m_cboQueryType.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboQueryType.ListForeColor = System.Drawing.Color.White;
			this.m_cboQueryType.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboQueryType.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboQueryType.Location = new System.Drawing.Point(260, 60);
			this.m_cboQueryType.Name = "m_cboQueryType";
			this.m_cboQueryType.SelectedIndex = -1;
			this.m_cboQueryType.SelectedItem = null;
			this.m_cboQueryType.Size = new System.Drawing.Size(120, 26);
			this.m_cboQueryType.TabIndex = 15028;
			this.m_cboQueryType.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboQueryType.TextForeColor = System.Drawing.Color.White;
			this.m_cboQueryType.SelectedIndexChanged += new System.EventHandler(this.m_cboQueryType_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(32, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 24);
			this.label4.TabIndex = 15027;
			this.label4.Text = "医嘱类别：";
			// 
			// m_cboPhysicianOrderType
			// 
			this.m_cboPhysicianOrderType.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPhysicianOrderType.BorderColor = System.Drawing.Color.White;
			this.m_cboPhysicianOrderType.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPhysicianOrderType.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboPhysicianOrderType.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboPhysicianOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboPhysicianOrderType.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPhysicianOrderType.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPhysicianOrderType.ForeColor = System.Drawing.Color.White;
			this.m_cboPhysicianOrderType.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPhysicianOrderType.ListForeColor = System.Drawing.Color.White;
			this.m_cboPhysicianOrderType.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboPhysicianOrderType.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboPhysicianOrderType.Location = new System.Drawing.Point(124, 60);
			this.m_cboPhysicianOrderType.Name = "m_cboPhysicianOrderType";
			this.m_cboPhysicianOrderType.SelectedIndex = -1;
			this.m_cboPhysicianOrderType.SelectedItem = null;
			this.m_cboPhysicianOrderType.Size = new System.Drawing.Size(128, 26);
			this.m_cboPhysicianOrderType.TabIndex = 15026;
			this.m_cboPhysicianOrderType.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPhysicianOrderType.TextForeColor = System.Drawing.Color.White;
			this.m_cboPhysicianOrderType.SelectedIndexChanged += new System.EventHandler(this.m_cboPhysicianOrderType_SelectedIndexChanged);
			// 
			// m_chkIsSubPhysicainOrder
			// 
			this.m_chkIsSubPhysicainOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_chkIsSubPhysicainOrder.Location = new System.Drawing.Point(752, 28);
			this.m_chkIsSubPhysicainOrder.Name = "m_chkIsSubPhysicainOrder";
			this.m_chkIsSubPhysicainOrder.Size = new System.Drawing.Size(204, 24);
			this.m_chkIsSubPhysicainOrder.TabIndex = 15025;
			this.m_chkIsSubPhysicainOrder.Text = "作为上一医嘱的子医嘱";
			this.m_chkIsSubPhysicainOrder.CheckedChanged += new System.EventHandler(this.m_chkIsSubPhysicainOrder_CheckedChanged);
			// 
			// m_cmdOK
			// 
			this.m_cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdOK.Location = new System.Drawing.Point(776, 112);
			this.m_cmdOK.Name = "m_cmdOK";
			this.m_cmdOK.Size = new System.Drawing.Size(96, 28);
			this.m_cmdOK.TabIndex = 15024;
			this.m_cmdOK.Text = "选择";
			this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(400, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 20);
			this.label3.TabIndex = 15023;
			this.label3.Text = "查询：";
			// 
			// m_txtQuery
			// 
			this.m_txtQuery.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtQuery.BorderColor = System.Drawing.Color.White;
			this.m_txtQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtQuery.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtQuery.ForeColor = System.Drawing.Color.White;
			this.m_txtQuery.Location = new System.Drawing.Point(456, 60);
			this.m_txtQuery.Name = "m_txtQuery";
			this.m_txtQuery.Size = new System.Drawing.Size(224, 26);
			this.m_txtQuery.TabIndex = 15022;
			this.m_txtQuery.Text = "";
			// 
			// m_txtMedicalDose
			// 
			this.m_txtMedicalDose.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtMedicalDose.BorderColor = System.Drawing.Color.White;
			this.m_txtMedicalDose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtMedicalDose.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtMedicalDose.ForeColor = System.Drawing.Color.White;
			this.m_txtMedicalDose.Location = new System.Drawing.Point(432, 116);
			this.m_txtMedicalDose.Name = "m_txtMedicalDose";
			this.m_txtMedicalDose.Size = new System.Drawing.Size(88, 26);
			this.m_txtMedicalDose.TabIndex = 15021;
			this.m_txtMedicalDose.Text = "";
			// 
			// m_cboUsage
			// 
			this.m_cboUsage.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboUsage.BorderColor = System.Drawing.Color.White;
			this.m_cboUsage.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboUsage.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboUsage.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboUsage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboUsage.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboUsage.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboUsage.ForeColor = System.Drawing.Color.White;
			this.m_cboUsage.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboUsage.ListForeColor = System.Drawing.Color.White;
			this.m_cboUsage.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboUsage.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboUsage.Location = new System.Drawing.Point(592, 116);
			this.m_cboUsage.Name = "m_cboUsage";
			this.m_cboUsage.SelectedIndex = -1;
			this.m_cboUsage.SelectedItem = null;
			this.m_cboUsage.Size = new System.Drawing.Size(88, 26);
			this.m_cboUsage.TabIndex = 15015;
			this.m_cboUsage.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboUsage.TextForeColor = System.Drawing.Color.White;
			this.m_cboUsage.SelectedIndexChanged += new System.EventHandler(this.m_cboUsage_SelectedIndexChanged);
			// 
			// m_cboFrequency
			// 
			this.m_cboFrequency.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFrequency.BorderColor = System.Drawing.Color.White;
			this.m_cboFrequency.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFrequency.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboFrequency.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboFrequency.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFrequency.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFrequency.ForeColor = System.Drawing.Color.White;
			this.m_cboFrequency.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFrequency.ListForeColor = System.Drawing.Color.White;
			this.m_cboFrequency.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboFrequency.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboFrequency.Location = new System.Drawing.Point(692, 116);
			this.m_cboFrequency.Name = "m_cboFrequency";
			this.m_cboFrequency.SelectedIndex = -1;
			this.m_cboFrequency.SelectedItem = null;
			this.m_cboFrequency.Size = new System.Drawing.Size(64, 26);
			this.m_cboFrequency.TabIndex = 15019;
			this.m_cboFrequency.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFrequency.TextForeColor = System.Drawing.Color.White;
			this.m_cboFrequency.SelectedIndexChanged += new System.EventHandler(this.m_cboFrequency_SelectedIndexChanged);
			// 
			// m_cboMedicineStandard
			// 
			this.m_cboMedicineStandard.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboMedicineStandard.BorderColor = System.Drawing.Color.White;
			this.m_cboMedicineStandard.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboMedicineStandard.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboMedicineStandard.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboMedicineStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboMedicineStandard.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboMedicineStandard.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboMedicineStandard.ForeColor = System.Drawing.Color.White;
			this.m_cboMedicineStandard.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboMedicineStandard.ListForeColor = System.Drawing.Color.White;
			this.m_cboMedicineStandard.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboMedicineStandard.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboMedicineStandard.Location = new System.Drawing.Point(276, 116);
			this.m_cboMedicineStandard.Name = "m_cboMedicineStandard";
			this.m_cboMedicineStandard.SelectedIndex = -1;
			this.m_cboMedicineStandard.SelectedItem = null;
			this.m_cboMedicineStandard.Size = new System.Drawing.Size(152, 26);
			this.m_cboMedicineStandard.TabIndex = 15013;
			this.m_cboMedicineStandard.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboMedicineStandard.TextForeColor = System.Drawing.Color.White;
			this.m_cboMedicineStandard.DropDown += new System.EventHandler(this.m_cboMedicineStandard_DropDown);
			this.m_cboMedicineStandard.SelectedIndexChanged += new System.EventHandler(this.m_cboMedicineStandard_SelectedIndexChanged);
			// 
			// m_dtpStartDate
			// 
			this.m_dtpStartDate.BorderColor = System.Drawing.Color.White;
			this.m_dtpStartDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtpStartDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpStartDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpStartDate.DropButtonForeColor = System.Drawing.Color.White;
			this.m_dtpStartDate.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpStartDate.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpStartDate.Location = new System.Drawing.Point(124, 28);
			this.m_dtpStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpStartDate.Name = "m_dtpStartDate";
			this.m_dtpStartDate.Size = new System.Drawing.Size(204, 26);
			this.m_dtpStartDate.TabIndex = 31;
			this.m_dtpStartDate.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpStartDate.TextForeColor = System.Drawing.Color.White;
			// 
			// m_lsvMedical
			// 
			this.m_lsvMedical.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lsvMedical.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_lsvMedical.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.columnHeader9,
																						   this.columnHeader10,
																						   this.columnHeader11,
																						   this.columnHeader12,
																						   this.columnHeader13,
																						   this.columnHeader14});
			this.m_lsvMedical.ForeColor = System.Drawing.Color.White;
			this.m_lsvMedical.FullRowSelect = true;
			this.m_lsvMedical.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_lsvMedical.LabelWrap = false;
			this.m_lsvMedical.Location = new System.Drawing.Point(28, 96);
			this.m_lsvMedical.MultiSelect = false;
			this.m_lsvMedical.Name = "m_lsvMedical";
			this.m_lsvMedical.Scrollable = false;
			this.m_lsvMedical.Size = new System.Drawing.Size(728, 48);
			this.m_lsvMedical.TabIndex = 15016;
			this.m_lsvMedical.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "名称";
			this.columnHeader9.Width = 250;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "规格";
			this.columnHeader10.Width = 150;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "剂量";
			this.columnHeader11.Width = 100;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "单位";
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "用法";
			this.columnHeader13.Width = 100;
			// 
			// columnHeader14
			// 
			this.columnHeader14.Text = "频次";
			this.columnHeader14.Width = 70;
			// 
			// m_lsvPhysicianOrder
			// 
			this.m_lsvPhysicianOrder.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lsvPhysicianOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								  this.columnHeader1,
																								  this.columnHeader2,
																								  this.columnHeader8,
																								  this.columnHeader3,
																								  this.columnHeader5,
																								  this.columnHeader31,
																								  this.columnHeader6});
			this.m_lsvPhysicianOrder.ForeColor = System.Drawing.Color.White;
			this.m_lsvPhysicianOrder.FullRowSelect = true;
			this.m_lsvPhysicianOrder.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_lsvPhysicianOrder.HideSelection = false;
			this.m_lsvPhysicianOrder.Location = new System.Drawing.Point(4, 8);
			this.m_lsvPhysicianOrder.MultiSelect = false;
			this.m_lsvPhysicianOrder.Name = "m_lsvPhysicianOrder";
			this.m_lsvPhysicianOrder.Size = new System.Drawing.Size(984, 276);
			this.m_lsvPhysicianOrder.TabIndex = 0;
			this.m_lsvPhysicianOrder.View = System.Windows.Forms.View.Details;
			this.m_lsvPhysicianOrder.DoubleClick += new System.EventHandler(this.m_lstPhysicianOrder_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "开始时间";
			this.columnHeader1.Width = 171;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "医嘱";
			this.columnHeader2.Width = 200;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "剂量";
			this.columnHeader8.Width = 140;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "用法";
			this.columnHeader3.Width = 68;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "频次";
			this.columnHeader5.Width = 64;
			// 
			// columnHeader31
			// 
			this.columnHeader31.Text = "备注";
			this.columnHeader31.Width = 120;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "停嘱日期";
			this.columnHeader6.Width = 171;
			// 
			// m_tbpNurseHandle
			// 
			this.m_tbpNurseHandle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_tbpNurseHandle.Controls.AddRange(new System.Windows.Forms.Control[] {
																						   this.m_objNurseNumericInc,
																						   this.m_lsvNurseAddIn,
																						   this.m_grbNursePhysicianOrder,
																						   this.m_lsvNursePhysicianOrder});
			this.m_tbpNurseHandle.Location = new System.Drawing.Point(4, 26);
			this.m_tbpNurseHandle.Name = "m_tbpNurseHandle";
			this.m_tbpNurseHandle.Size = new System.Drawing.Size(996, 470);
			this.m_tbpNurseHandle.TabIndex = 3;
			this.m_tbpNurseHandle.Text = "护士工作站";
			// 
			// m_objNurseNumericInc
			// 
			this.m_objNurseNumericInc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_objNurseNumericInc.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_objNurseNumericInc.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_objNurseNumericInc.ForeColor = System.Drawing.Color.White;
			this.m_objNurseNumericInc.Location = new System.Drawing.Point(548, 240);
			this.m_objNurseNumericInc.Name = "m_objNurseNumericInc";
			this.m_objNurseNumericInc.Size = new System.Drawing.Size(60, 19);
			this.m_objNurseNumericInc.TabIndex = 15037;
			this.m_objNurseNumericInc.Visible = false;
			// 
			// m_lsvNurseAddIn
			// 
			this.m_lsvNurseAddIn.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lsvNurseAddIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lsvNurseAddIn.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  this.columnHeader46,
																							  this.columnHeader47});
			this.m_lsvNurseAddIn.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvNurseAddIn.ForeColor = System.Drawing.Color.White;
			this.m_lsvNurseAddIn.FullRowSelect = true;
			this.m_lsvNurseAddIn.GridLines = true;
			this.m_lsvNurseAddIn.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lsvNurseAddIn.Location = new System.Drawing.Point(396, 152);
			this.m_lsvNurseAddIn.MultiSelect = false;
			this.m_lsvNurseAddIn.Name = "m_lsvNurseAddIn";
			this.m_lsvNurseAddIn.Size = new System.Drawing.Size(232, 188);
			this.m_lsvNurseAddIn.TabIndex = 15028;
			this.m_lsvNurseAddIn.View = System.Windows.Forms.View.Details;
			this.m_lsvNurseAddIn.Visible = false;
			// 
			// columnHeader46
			// 
			this.columnHeader46.Width = 150;
			// 
			// columnHeader47
			// 
			this.columnHeader47.Width = 58;
			// 
			// m_grbNursePhysicianOrder
			// 
			this.m_grbNursePhysicianOrder.Controls.AddRange(new System.Windows.Forms.Control[] {
																								   this.button3,
																								   this.button2,
																								   this.m_cmdNurseDisplayAddIn,
																								   this.button1,
																								   this.m_cmdSetConfirmed,
																								   this.m_lblNurseAddInTitle,
																								   this.m_cmdNurseSetPerformed,
																								   this.m_lblNursePerformDateTitle,
																								   this.m_dtpNursePerformDate,
																								   this.m_rdbNurseNotPerformed,
																								   this.m_rdbNurseNotConfirmed});
			this.m_grbNursePhysicianOrder.Location = new System.Drawing.Point(8, 316);
			this.m_grbNursePhysicianOrder.Name = "m_grbNursePhysicianOrder";
			this.m_grbNursePhysicianOrder.Size = new System.Drawing.Size(980, 124);
			this.m_grbNursePhysicianOrder.TabIndex = 5;
			this.m_grbNursePhysicianOrder.TabStop = false;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(852, 64);
			this.button3.Name = "button3";
			this.button3.TabIndex = 15038;
			this.button3.Text = "button3";
			this.button3.Visible = false;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(860, 32);
			this.button2.Name = "button2";
			this.button2.TabIndex = 15037;
			this.button2.Text = "button2";
			this.button2.Visible = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// m_cmdNurseDisplayAddIn
			// 
			this.m_cmdNurseDisplayAddIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdNurseDisplayAddIn.Location = new System.Drawing.Point(388, 24);
			this.m_cmdNurseDisplayAddIn.Name = "m_cmdNurseDisplayAddIn";
			this.m_cmdNurseDisplayAddIn.Size = new System.Drawing.Size(96, 28);
			this.m_cmdNurseDisplayAddIn.TabIndex = 15036;
			this.m_cmdNurseDisplayAddIn.Text = "附加物";
			this.m_cmdNurseDisplayAddIn.Click += new System.EventHandler(this.m_cmdNurseDisplayAddIn_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(860, 92);
			this.button1.Name = "button1";
			this.button1.TabIndex = 15035;
			this.button1.Text = "button1";
			this.button1.Visible = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// m_cmdSetConfirmed
			// 
			this.m_cmdSetConfirmed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdSetConfirmed.Location = new System.Drawing.Point(388, 56);
			this.m_cmdSetConfirmed.Name = "m_cmdSetConfirmed";
			this.m_cmdSetConfirmed.Size = new System.Drawing.Size(96, 28);
			this.m_cmdSetConfirmed.TabIndex = 15034;
			this.m_cmdSetConfirmed.Text = "通过审核";
			this.m_cmdSetConfirmed.Click += new System.EventHandler(this.m_cmdSetConfirmed_Click);
			// 
			// m_lblNurseAddInTitle
			// 
			this.m_lblNurseAddInTitle.Location = new System.Drawing.Point(252, 24);
			this.m_lblNurseAddInTitle.Name = "m_lblNurseAddInTitle";
			this.m_lblNurseAddInTitle.Size = new System.Drawing.Size(72, 23);
			this.m_lblNurseAddInTitle.TabIndex = 15033;
			this.m_lblNurseAddInTitle.Text = "附加物：";
			// 
			// m_cmdNurseSetPerformed
			// 
			this.m_cmdNurseSetPerformed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdNurseSetPerformed.Location = new System.Drawing.Point(388, 56);
			this.m_cmdNurseSetPerformed.Name = "m_cmdNurseSetPerformed";
			this.m_cmdNurseSetPerformed.Size = new System.Drawing.Size(96, 28);
			this.m_cmdNurseSetPerformed.TabIndex = 15031;
			this.m_cmdNurseSetPerformed.Text = "执行";
			this.m_cmdNurseSetPerformed.Click += new System.EventHandler(this.m_cmdNurseSetPerformed_Click);
			// 
			// m_lblNursePerformDateTitle
			// 
			this.m_lblNursePerformDateTitle.Location = new System.Drawing.Point(64, 60);
			this.m_lblNursePerformDateTitle.Name = "m_lblNursePerformDateTitle";
			this.m_lblNursePerformDateTitle.Size = new System.Drawing.Size(88, 23);
			this.m_lblNursePerformDateTitle.TabIndex = 33;
			this.m_lblNursePerformDateTitle.Text = "执行时间：";
			// 
			// m_dtpNursePerformDate
			// 
			this.m_dtpNursePerformDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpNursePerformDate.BorderColor = System.Drawing.Color.White;
			this.m_dtpNursePerformDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtpNursePerformDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpNursePerformDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpNursePerformDate.DropButtonForeColor = System.Drawing.Color.White;
			this.m_dtpNursePerformDate.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpNursePerformDate.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpNursePerformDate.ForeColor = System.Drawing.Color.White;
			this.m_dtpNursePerformDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpNursePerformDate.Location = new System.Drawing.Point(152, 56);
			this.m_dtpNursePerformDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpNursePerformDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpNursePerformDate.Name = "m_dtpNursePerformDate";
			this.m_dtpNursePerformDate.Size = new System.Drawing.Size(204, 26);
			this.m_dtpNursePerformDate.TabIndex = 32;
			this.m_dtpNursePerformDate.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpNursePerformDate.TextForeColor = System.Drawing.Color.White;
			// 
			// m_rdbNurseNotPerformed
			// 
			this.m_rdbNurseNotPerformed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbNurseNotPerformed.Location = new System.Drawing.Point(20, 20);
			this.m_rdbNurseNotPerformed.Name = "m_rdbNurseNotPerformed";
			this.m_rdbNurseNotPerformed.Size = new System.Drawing.Size(108, 24);
			this.m_rdbNurseNotPerformed.TabIndex = 1;
			this.m_rdbNurseNotPerformed.Text = "待执行医嘱";
			this.m_rdbNurseNotPerformed.CheckedChanged += new System.EventHandler(this.m_rdbNurseNotPerformed_CheckedChanged);
			// 
			// m_rdbNurseNotConfirmed
			// 
			this.m_rdbNurseNotConfirmed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbNurseNotConfirmed.Location = new System.Drawing.Point(132, 20);
			this.m_rdbNurseNotConfirmed.Name = "m_rdbNurseNotConfirmed";
			this.m_rdbNurseNotConfirmed.Size = new System.Drawing.Size(108, 24);
			this.m_rdbNurseNotConfirmed.TabIndex = 0;
			this.m_rdbNurseNotConfirmed.Text = "未审核医嘱";
			this.m_rdbNurseNotConfirmed.CheckedChanged += new System.EventHandler(this.m_rdbNurseNotConfirmed_CheckedChanged);
			// 
			// m_lsvNursePhysicianOrder
			// 
			this.m_lsvNursePhysicianOrder.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lsvNursePhysicianOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																									   this.columnHeader7,
																									   this.columnHeader15,
																									   this.columnHeader29,
																									   this.columnHeader30,
																									   this.columnHeader43,
																									   this.columnHeader44,
																									   this.columnHeader45,
																									   this.columnHeader49});
			this.m_lsvNursePhysicianOrder.ForeColor = System.Drawing.Color.White;
			this.m_lsvNursePhysicianOrder.FullRowSelect = true;
			this.m_lsvNursePhysicianOrder.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_lsvNursePhysicianOrder.HideSelection = false;
			this.m_lsvNursePhysicianOrder.Location = new System.Drawing.Point(4, 4);
			this.m_lsvNursePhysicianOrder.MultiSelect = false;
			this.m_lsvNursePhysicianOrder.Name = "m_lsvNursePhysicianOrder";
			this.m_lsvNursePhysicianOrder.Size = new System.Drawing.Size(984, 304);
			this.m_lsvNursePhysicianOrder.TabIndex = 4;
			this.m_lsvNursePhysicianOrder.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "!";
			this.columnHeader7.Width = 25;
			// 
			// columnHeader15
			// 
			this.columnHeader15.Text = "开始时间";
			this.columnHeader15.Width = 171;
			// 
			// columnHeader29
			// 
			this.columnHeader29.Text = "医嘱";
			this.columnHeader29.Width = 200;
			// 
			// columnHeader30
			// 
			this.columnHeader30.Text = "剂量";
			this.columnHeader30.Width = 140;
			// 
			// columnHeader43
			// 
			this.columnHeader43.Text = "用法";
			this.columnHeader43.Width = 70;
			// 
			// columnHeader44
			// 
			this.columnHeader44.Text = "频次";
			this.columnHeader44.Width = 64;
			// 
			// columnHeader45
			// 
			this.columnHeader45.Text = "备注";
			this.columnHeader45.Width = 120;
			// 
			// columnHeader49
			// 
			this.columnHeader49.Text = "附加物";
			this.columnHeader49.Width = 230;
			// 
			// m_tbpShortTermPhycianOrder
			// 
			this.m_tbpShortTermPhycianOrder.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_tbpShortTermPhycianOrder.Controls.AddRange(new System.Windows.Forms.Control[] {
																									 this.m_lsvTempQuery,
																									 this.m_grbTempPhysicianOrder,
																									 this.m_lsvTempPhysicianOrder,
																									 this.label2});
			this.m_tbpShortTermPhycianOrder.Location = new System.Drawing.Point(4, 26);
			this.m_tbpShortTermPhycianOrder.Name = "m_tbpShortTermPhycianOrder";
			this.m_tbpShortTermPhycianOrder.Size = new System.Drawing.Size(996, 470);
			this.m_tbpShortTermPhycianOrder.TabIndex = 1;
			this.m_tbpShortTermPhycianOrder.Text = "临时医嘱";
			// 
			// m_lsvTempQuery
			// 
			this.m_lsvTempQuery.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lsvTempQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lsvTempQuery.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.columnHeader42});
			this.m_lsvTempQuery.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvTempQuery.ForeColor = System.Drawing.Color.White;
			this.m_lsvTempQuery.FullRowSelect = true;
			this.m_lsvTempQuery.GridLines = true;
			this.m_lsvTempQuery.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lsvTempQuery.Location = new System.Drawing.Point(528, 160);
			this.m_lsvTempQuery.Name = "m_lsvTempQuery";
			this.m_lsvTempQuery.Size = new System.Drawing.Size(224, 188);
			this.m_lsvTempQuery.TabIndex = 15027;
			this.m_lsvTempQuery.View = System.Windows.Forms.View.Details;
			this.m_lsvTempQuery.Visible = false;
			// 
			// columnHeader42
			// 
			this.columnHeader42.Width = 220;
			// 
			// m_grbTempPhysicianOrder
			// 
			this.m_grbTempPhysicianOrder.Controls.AddRange(new System.Windows.Forms.Control[] {
																								  this.label15,
																								  this.m_cmdTempSubmit,
																								  this.m_cboTempMedicineStandard,
																								  this.m_cboTempQueryType,
																								  this.label5,
																								  this.m_cboTempPhysicianOrderType,
																								  this.m_chkTempIsSubPhysicainOrder,
																								  this.m_cmdTempOK,
																								  this.label6,
																								  this.m_txtTemptQuery,
																								  this.m_txtTempMedicalDose,
																								  this.m_cboTempUsage,
																								  this.m_cboTempFrequency,
																								  this.m_dtpTempStartDate,
																								  this.m_lsvTempMedical,
																								  this.label16,
																								  this.m_txtTempRemark});
			this.m_grbTempPhysicianOrder.Location = new System.Drawing.Point(6, 288);
			this.m_grbTempPhysicianOrder.Name = "m_grbTempPhysicianOrder";
			this.m_grbTempPhysicianOrder.Size = new System.Drawing.Size(984, 152);
			this.m_grbTempPhysicianOrder.TabIndex = 15026;
			this.m_grbTempPhysicianOrder.TabStop = false;
			// 
			// label15
			// 
			this.label15.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label15.ForeColor = System.Drawing.Color.White;
			this.label15.Location = new System.Drawing.Point(40, 28);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(88, 24);
			this.label15.TabIndex = 15031;
			this.label15.Text = "开嘱日期：";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cmdTempSubmit
			// 
			this.m_cmdTempSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdTempSubmit.Location = new System.Drawing.Point(836, 76);
			this.m_cmdTempSubmit.Name = "m_cmdTempSubmit";
			this.m_cmdTempSubmit.Size = new System.Drawing.Size(96, 28);
			this.m_cmdTempSubmit.TabIndex = 15030;
			this.m_cmdTempSubmit.Text = "提交";
			this.m_cmdTempSubmit.Click += new System.EventHandler(this.m_cmdTempSubmit_Click);
			// 
			// m_cboTempMedicineStandard
			// 
			this.m_cboTempMedicineStandard.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTempMedicineStandard.BorderColor = System.Drawing.Color.White;
			this.m_cboTempMedicineStandard.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTempMedicineStandard.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTempMedicineStandard.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTempMedicineStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTempMedicineStandard.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTempMedicineStandard.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTempMedicineStandard.ForeColor = System.Drawing.Color.White;
			this.m_cboTempMedicineStandard.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTempMedicineStandard.ListForeColor = System.Drawing.Color.White;
			this.m_cboTempMedicineStandard.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTempMedicineStandard.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTempMedicineStandard.Location = new System.Drawing.Point(292, 112);
			this.m_cboTempMedicineStandard.Name = "m_cboTempMedicineStandard";
			this.m_cboTempMedicineStandard.SelectedIndex = -1;
			this.m_cboTempMedicineStandard.SelectedItem = null;
			this.m_cboTempMedicineStandard.Size = new System.Drawing.Size(148, 26);
			this.m_cboTempMedicineStandard.TabIndex = 15029;
			this.m_cboTempMedicineStandard.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTempMedicineStandard.TextForeColor = System.Drawing.Color.White;
			this.m_cboTempMedicineStandard.DropDown += new System.EventHandler(this.m_cboMedicineStandard_DropDown);
			this.m_cboTempMedicineStandard.SelectedIndexChanged += new System.EventHandler(this.m_cboMedicineStandard_SelectedIndexChanged);
			// 
			// m_cboTempQueryType
			// 
			this.m_cboTempQueryType.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTempQueryType.BorderColor = System.Drawing.Color.White;
			this.m_cboTempQueryType.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTempQueryType.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTempQueryType.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTempQueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTempQueryType.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTempQueryType.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTempQueryType.ForeColor = System.Drawing.Color.White;
			this.m_cboTempQueryType.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTempQueryType.ListForeColor = System.Drawing.Color.White;
			this.m_cboTempQueryType.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTempQueryType.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTempQueryType.Location = new System.Drawing.Point(288, 60);
			this.m_cboTempQueryType.Name = "m_cboTempQueryType";
			this.m_cboTempQueryType.SelectedIndex = -1;
			this.m_cboTempQueryType.SelectedItem = null;
			this.m_cboTempQueryType.Size = new System.Drawing.Size(148, 26);
			this.m_cboTempQueryType.TabIndex = 15028;
			this.m_cboTempQueryType.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTempQueryType.TextForeColor = System.Drawing.Color.White;
			this.m_cboTempQueryType.SelectedIndexChanged += new System.EventHandler(this.m_cboQueryType_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(40, 64);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 24);
			this.label5.TabIndex = 15027;
			this.label5.Text = "医嘱类别：";
			// 
			// m_cboTempPhysicianOrderType
			// 
			this.m_cboTempPhysicianOrderType.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTempPhysicianOrderType.BorderColor = System.Drawing.Color.White;
			this.m_cboTempPhysicianOrderType.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTempPhysicianOrderType.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTempPhysicianOrderType.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTempPhysicianOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTempPhysicianOrderType.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTempPhysicianOrderType.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTempPhysicianOrderType.ForeColor = System.Drawing.Color.White;
			this.m_cboTempPhysicianOrderType.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTempPhysicianOrderType.ListForeColor = System.Drawing.Color.White;
			this.m_cboTempPhysicianOrderType.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTempPhysicianOrderType.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTempPhysicianOrderType.Location = new System.Drawing.Point(132, 60);
			this.m_cboTempPhysicianOrderType.Name = "m_cboTempPhysicianOrderType";
			this.m_cboTempPhysicianOrderType.SelectedIndex = -1;
			this.m_cboTempPhysicianOrderType.SelectedItem = null;
			this.m_cboTempPhysicianOrderType.Size = new System.Drawing.Size(144, 26);
			this.m_cboTempPhysicianOrderType.TabIndex = 15026;
			this.m_cboTempPhysicianOrderType.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTempPhysicianOrderType.TextForeColor = System.Drawing.Color.White;
			this.m_cboTempPhysicianOrderType.SelectedIndexChanged += new System.EventHandler(this.m_cboPhysicianOrderType_SelectedIndexChanged);
			// 
			// m_chkTempIsSubPhysicainOrder
			// 
			this.m_chkTempIsSubPhysicainOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_chkTempIsSubPhysicainOrder.Location = new System.Drawing.Point(748, 28);
			this.m_chkTempIsSubPhysicainOrder.Name = "m_chkTempIsSubPhysicainOrder";
			this.m_chkTempIsSubPhysicainOrder.Size = new System.Drawing.Size(204, 24);
			this.m_chkTempIsSubPhysicainOrder.TabIndex = 15025;
			this.m_chkTempIsSubPhysicainOrder.Text = "作为上一医嘱的子医嘱";
			this.m_chkTempIsSubPhysicainOrder.CheckedChanged += new System.EventHandler(this.m_chkIsSubPhysicainOrder_CheckedChanged);
			// 
			// m_cmdTempOK
			// 
			this.m_cmdTempOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdTempOK.Location = new System.Drawing.Point(836, 112);
			this.m_cmdTempOK.Name = "m_cmdTempOK";
			this.m_cmdTempOK.Size = new System.Drawing.Size(96, 28);
			this.m_cmdTempOK.TabIndex = 15024;
			this.m_cmdTempOK.Text = "选择";
			this.m_cmdTempOK.Click += new System.EventHandler(this.m_cmdTempOK_Click);
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.ForeColor = System.Drawing.Color.White;
			this.label6.Location = new System.Drawing.Point(464, 64);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 20);
			this.label6.TabIndex = 15023;
			this.label6.Text = "查询：";
			// 
			// m_txtTemptQuery
			// 
			this.m_txtTemptQuery.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtTemptQuery.BorderColor = System.Drawing.Color.White;
			this.m_txtTemptQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtTemptQuery.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTemptQuery.ForeColor = System.Drawing.Color.White;
			this.m_txtTemptQuery.Location = new System.Drawing.Point(520, 60);
			this.m_txtTemptQuery.Name = "m_txtTemptQuery";
			this.m_txtTemptQuery.Size = new System.Drawing.Size(256, 26);
			this.m_txtTemptQuery.TabIndex = 15022;
			this.m_txtTemptQuery.Text = "";
			// 
			// m_txtTempMedicalDose
			// 
			this.m_txtTempMedicalDose.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtTempMedicalDose.BorderColor = System.Drawing.Color.White;
			this.m_txtTempMedicalDose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtTempMedicalDose.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTempMedicalDose.ForeColor = System.Drawing.Color.White;
			this.m_txtTempMedicalDose.Location = new System.Drawing.Point(444, 112);
			this.m_txtTempMedicalDose.Name = "m_txtTempMedicalDose";
			this.m_txtTempMedicalDose.Size = new System.Drawing.Size(92, 26);
			this.m_txtTempMedicalDose.TabIndex = 15021;
			this.m_txtTempMedicalDose.Text = "";
			// 
			// m_cboTempUsage
			// 
			this.m_cboTempUsage.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTempUsage.BorderColor = System.Drawing.Color.White;
			this.m_cboTempUsage.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTempUsage.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTempUsage.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTempUsage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTempUsage.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTempUsage.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTempUsage.ForeColor = System.Drawing.Color.White;
			this.m_cboTempUsage.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTempUsage.ListForeColor = System.Drawing.Color.White;
			this.m_cboTempUsage.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTempUsage.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTempUsage.Location = new System.Drawing.Point(612, 112);
			this.m_cboTempUsage.Name = "m_cboTempUsage";
			this.m_cboTempUsage.SelectedIndex = -1;
			this.m_cboTempUsage.SelectedItem = null;
			this.m_cboTempUsage.Size = new System.Drawing.Size(88, 26);
			this.m_cboTempUsage.TabIndex = 15015;
			this.m_cboTempUsage.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTempUsage.TextForeColor = System.Drawing.Color.White;
			this.m_cboTempUsage.SelectedIndexChanged += new System.EventHandler(this.m_cboUsage_SelectedIndexChanged);
			// 
			// m_cboTempFrequency
			// 
			this.m_cboTempFrequency.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTempFrequency.BorderColor = System.Drawing.Color.White;
			this.m_cboTempFrequency.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTempFrequency.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTempFrequency.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTempFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTempFrequency.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTempFrequency.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTempFrequency.ForeColor = System.Drawing.Color.White;
			this.m_cboTempFrequency.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTempFrequency.ListForeColor = System.Drawing.Color.White;
			this.m_cboTempFrequency.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTempFrequency.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTempFrequency.Location = new System.Drawing.Point(704, 112);
			this.m_cboTempFrequency.Name = "m_cboTempFrequency";
			this.m_cboTempFrequency.SelectedIndex = -1;
			this.m_cboTempFrequency.SelectedItem = null;
			this.m_cboTempFrequency.Size = new System.Drawing.Size(64, 26);
			this.m_cboTempFrequency.TabIndex = 15019;
			this.m_cboTempFrequency.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTempFrequency.TextForeColor = System.Drawing.Color.White;
			this.m_cboTempFrequency.SelectedIndexChanged += new System.EventHandler(this.m_cboFrequency_SelectedIndexChanged);
			// 
			// m_dtpTempStartDate
			// 
			this.m_dtpTempStartDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpTempStartDate.BorderColor = System.Drawing.Color.White;
			this.m_dtpTempStartDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtpTempStartDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpTempStartDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpTempStartDate.DropButtonForeColor = System.Drawing.Color.White;
			this.m_dtpTempStartDate.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpTempStartDate.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpTempStartDate.ForeColor = System.Drawing.Color.White;
			this.m_dtpTempStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpTempStartDate.Location = new System.Drawing.Point(136, 28);
			this.m_dtpTempStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpTempStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpTempStartDate.Name = "m_dtpTempStartDate";
			this.m_dtpTempStartDate.Size = new System.Drawing.Size(204, 26);
			this.m_dtpTempStartDate.TabIndex = 31;
			this.m_dtpTempStartDate.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpTempStartDate.TextForeColor = System.Drawing.Color.White;
			// 
			// m_lsvTempMedical
			// 
			this.m_lsvTempMedical.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lsvTempMedical.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_lsvTempMedical.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							   this.columnHeader16,
																							   this.columnHeader17,
																							   this.columnHeader18,
																							   this.columnHeader19,
																							   this.columnHeader20,
																							   this.columnHeader21});
			this.m_lsvTempMedical.ForeColor = System.Drawing.Color.White;
			this.m_lsvTempMedical.FullRowSelect = true;
			this.m_lsvTempMedical.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_lsvTempMedical.LabelWrap = false;
			this.m_lsvTempMedical.Location = new System.Drawing.Point(44, 92);
			this.m_lsvTempMedical.MultiSelect = false;
			this.m_lsvTempMedical.Name = "m_lsvTempMedical";
			this.m_lsvTempMedical.Scrollable = false;
			this.m_lsvTempMedical.Size = new System.Drawing.Size(732, 48);
			this.m_lsvTempMedical.TabIndex = 15016;
			this.m_lsvTempMedical.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader16
			// 
			this.columnHeader16.Text = "名称";
			this.columnHeader16.Width = 250;
			// 
			// columnHeader17
			// 
			this.columnHeader17.Text = "规格";
			this.columnHeader17.Width = 150;
			// 
			// columnHeader18
			// 
			this.columnHeader18.Text = "剂量";
			this.columnHeader18.Width = 100;
			// 
			// columnHeader19
			// 
			this.columnHeader19.Text = "单位";
			// 
			// columnHeader20
			// 
			this.columnHeader20.Text = "用法";
			this.columnHeader20.Width = 100;
			// 
			// columnHeader21
			// 
			this.columnHeader21.Text = "频次";
			this.columnHeader21.Width = 70;
			// 
			// label16
			// 
			this.label16.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label16.ForeColor = System.Drawing.Color.White;
			this.label16.Location = new System.Drawing.Point(416, 32);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(56, 20);
			this.label16.TabIndex = 15023;
			this.label16.Text = "备注：";
			// 
			// m_txtTempRemark
			// 
			this.m_txtTempRemark.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtTempRemark.BorderColor = System.Drawing.Color.White;
			this.m_txtTempRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtTempRemark.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTempRemark.ForeColor = System.Drawing.Color.White;
			this.m_txtTempRemark.Location = new System.Drawing.Point(472, 28);
			this.m_txtTempRemark.Name = "m_txtTempRemark";
			this.m_txtTempRemark.Size = new System.Drawing.Size(256, 26);
			this.m_txtTempRemark.TabIndex = 15022;
			this.m_txtTempRemark.Text = "";
			// 
			// m_lsvTempPhysicianOrder
			// 
			this.m_lsvTempPhysicianOrder.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lsvTempPhysicianOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																									  this.columnHeader22,
																									  this.columnHeader23,
																									  this.columnHeader25,
																									  this.columnHeader26,
																									  this.columnHeader27,
																									  this.columnHeader41,
																									  this.columnHeader28});
			this.m_lsvTempPhysicianOrder.ForeColor = System.Drawing.Color.White;
			this.m_lsvTempPhysicianOrder.FullRowSelect = true;
			this.m_lsvTempPhysicianOrder.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_lsvTempPhysicianOrder.HideSelection = false;
			this.m_lsvTempPhysicianOrder.Location = new System.Drawing.Point(6, 8);
			this.m_lsvTempPhysicianOrder.MultiSelect = false;
			this.m_lsvTempPhysicianOrder.Name = "m_lsvTempPhysicianOrder";
			this.m_lsvTempPhysicianOrder.Size = new System.Drawing.Size(984, 276);
			this.m_lsvTempPhysicianOrder.TabIndex = 15025;
			this.m_lsvTempPhysicianOrder.View = System.Windows.Forms.View.Details;
			this.m_lsvTempPhysicianOrder.DoubleClick += new System.EventHandler(this.m_lstPhysicianOrder_DoubleClick);
			// 
			// columnHeader22
			// 
			this.columnHeader22.Text = "开始时间";
			this.columnHeader22.Width = 171;
			// 
			// columnHeader23
			// 
			this.columnHeader23.Text = "医嘱";
			this.columnHeader23.Width = 200;
			// 
			// columnHeader25
			// 
			this.columnHeader25.Text = "剂量";
			this.columnHeader25.Width = 140;
			// 
			// columnHeader26
			// 
			this.columnHeader26.Text = "用法";
			this.columnHeader26.Width = 70;
			// 
			// columnHeader27
			// 
			this.columnHeader27.Text = "频次";
			this.columnHeader27.Width = 64;
			// 
			// columnHeader41
			// 
			this.columnHeader41.Text = "备注";
			this.columnHeader41.Width = 120;
			// 
			// columnHeader28
			// 
			this.columnHeader28.Text = "停嘱日期";
			this.columnHeader28.Width = 171;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(456, 268);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 15015;
			this.label2.Text = "规格";
			// 
			// m_tbpPhysicianOrderList
			// 
			this.m_tbpPhysicianOrderList.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_tbpPhysicianOrderList.Controls.AddRange(new System.Windows.Forms.Control[] {
																								  this.groupBox1,
																								  this.m_lstPhysicianOrderList});
			this.m_tbpPhysicianOrderList.Location = new System.Drawing.Point(4, 26);
			this.m_tbpPhysicianOrderList.Name = "m_tbpPhysicianOrderList";
			this.m_tbpPhysicianOrderList.Size = new System.Drawing.Size(996, 470);
			this.m_tbpPhysicianOrderList.TabIndex = 2;
			this.m_tbpPhysicianOrderList.Text = "医嘱列表";
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.label11,
																					this.label10,
																					this.m_dtpToDate,
																					this.label9,
																					this.m_cboOrderPerform,
																					this.label12,
																					this.m_cboOrderEnd,
																					this.label13,
																					this.m_cboOrderCancel,
																					this.label17,
																					this.m_cboOrderApprove,
																					this.label18,
																					this.m_cboOrderListType,
																					this.m_cmdOrderQuery,
																					this.m_dtpFromDate});
			this.groupBox1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox1.ForeColor = System.Drawing.Color.White;
			this.groupBox1.Location = new System.Drawing.Point(10, 320);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(984, 120);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			// 
			// label11
			// 
			this.label11.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label11.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label11.ForeColor = System.Drawing.Color.White;
			this.label11.Location = new System.Drawing.Point(496, 88);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(56, 24);
			this.label11.TabIndex = 15038;
			this.label11.Text = "到";
			// 
			// label10
			// 
			this.label10.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label10.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label10.ForeColor = System.Drawing.Color.White;
			this.label10.Location = new System.Drawing.Point(496, 56);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(56, 24);
			this.label10.TabIndex = 15037;
			this.label10.Text = "从";
			// 
			// m_dtpToDate
			// 
			this.m_dtpToDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpToDate.BorderColor = System.Drawing.Color.White;
			this.m_dtpToDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtpToDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpToDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpToDate.DropButtonForeColor = System.Drawing.Color.White;
			this.m_dtpToDate.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpToDate.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpToDate.ForeColor = System.Drawing.Color.White;
			this.m_dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpToDate.Location = new System.Drawing.Point(560, 88);
			this.m_dtpToDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpToDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpToDate.Name = "m_dtpToDate";
			this.m_dtpToDate.Size = new System.Drawing.Size(144, 26);
			this.m_dtpToDate.TabIndex = 15036;
			this.m_dtpToDate.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpToDate.TextForeColor = System.Drawing.Color.White;
			// 
			// label9
			// 
			this.label9.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label9.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label9.ForeColor = System.Drawing.Color.White;
			this.label9.Location = new System.Drawing.Point(496, 24);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 24);
			this.label9.TabIndex = 15035;
			this.label9.Text = "执行：";
			// 
			// m_cboOrderPerform
			// 
			this.m_cboOrderPerform.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOrderPerform.BorderColor = System.Drawing.Color.White;
			this.m_cboOrderPerform.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOrderPerform.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboOrderPerform.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboOrderPerform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboOrderPerform.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboOrderPerform.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboOrderPerform.ForeColor = System.Drawing.Color.White;
			this.m_cboOrderPerform.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOrderPerform.ListForeColor = System.Drawing.Color.White;
			this.m_cboOrderPerform.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboOrderPerform.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboOrderPerform.Location = new System.Drawing.Point(560, 24);
			this.m_cboOrderPerform.Name = "m_cboOrderPerform";
			this.m_cboOrderPerform.SelectedIndex = -1;
			this.m_cboOrderPerform.SelectedItem = null;
			this.m_cboOrderPerform.Size = new System.Drawing.Size(144, 26);
			this.m_cboOrderPerform.TabIndex = 15034;
			this.m_cboOrderPerform.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOrderPerform.TextForeColor = System.Drawing.Color.White;
			// 
			// label12
			// 
			this.label12.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label12.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label12.ForeColor = System.Drawing.Color.White;
			this.label12.Location = new System.Drawing.Point(264, 56);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(56, 24);
			this.label12.TabIndex = 15033;
			this.label12.Text = "停止：";
			// 
			// m_cboOrderEnd
			// 
			this.m_cboOrderEnd.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOrderEnd.BorderColor = System.Drawing.Color.White;
			this.m_cboOrderEnd.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOrderEnd.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboOrderEnd.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboOrderEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboOrderEnd.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboOrderEnd.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboOrderEnd.ForeColor = System.Drawing.Color.White;
			this.m_cboOrderEnd.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOrderEnd.ListForeColor = System.Drawing.Color.White;
			this.m_cboOrderEnd.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboOrderEnd.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboOrderEnd.Location = new System.Drawing.Point(320, 56);
			this.m_cboOrderEnd.Name = "m_cboOrderEnd";
			this.m_cboOrderEnd.SelectedIndex = -1;
			this.m_cboOrderEnd.SelectedItem = null;
			this.m_cboOrderEnd.Size = new System.Drawing.Size(144, 26);
			this.m_cboOrderEnd.TabIndex = 15032;
			this.m_cboOrderEnd.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOrderEnd.TextForeColor = System.Drawing.Color.White;
			// 
			// label13
			// 
			this.label13.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label13.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label13.ForeColor = System.Drawing.Color.White;
			this.label13.Location = new System.Drawing.Point(264, 24);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(56, 24);
			this.label13.TabIndex = 15031;
			this.label13.Text = "作废：";
			// 
			// m_cboOrderCancel
			// 
			this.m_cboOrderCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOrderCancel.BorderColor = System.Drawing.Color.White;
			this.m_cboOrderCancel.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOrderCancel.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboOrderCancel.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboOrderCancel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboOrderCancel.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboOrderCancel.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboOrderCancel.ForeColor = System.Drawing.Color.White;
			this.m_cboOrderCancel.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOrderCancel.ListForeColor = System.Drawing.Color.White;
			this.m_cboOrderCancel.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboOrderCancel.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboOrderCancel.Location = new System.Drawing.Point(320, 24);
			this.m_cboOrderCancel.Name = "m_cboOrderCancel";
			this.m_cboOrderCancel.SelectedIndex = -1;
			this.m_cboOrderCancel.SelectedItem = null;
			this.m_cboOrderCancel.Size = new System.Drawing.Size(144, 26);
			this.m_cboOrderCancel.TabIndex = 15030;
			this.m_cboOrderCancel.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOrderCancel.TextForeColor = System.Drawing.Color.White;
			// 
			// label17
			// 
			this.label17.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label17.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label17.ForeColor = System.Drawing.Color.White;
			this.label17.Location = new System.Drawing.Point(8, 56);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(88, 24);
			this.label17.TabIndex = 15029;
			this.label17.Text = "审核校对：";
			// 
			// m_cboOrderApprove
			// 
			this.m_cboOrderApprove.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOrderApprove.BorderColor = System.Drawing.Color.White;
			this.m_cboOrderApprove.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOrderApprove.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboOrderApprove.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboOrderApprove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboOrderApprove.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboOrderApprove.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboOrderApprove.ForeColor = System.Drawing.Color.White;
			this.m_cboOrderApprove.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOrderApprove.ListForeColor = System.Drawing.Color.White;
			this.m_cboOrderApprove.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboOrderApprove.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboOrderApprove.Location = new System.Drawing.Point(96, 56);
			this.m_cboOrderApprove.Name = "m_cboOrderApprove";
			this.m_cboOrderApprove.SelectedIndex = -1;
			this.m_cboOrderApprove.SelectedItem = null;
			this.m_cboOrderApprove.Size = new System.Drawing.Size(144, 26);
			this.m_cboOrderApprove.TabIndex = 15028;
			this.m_cboOrderApprove.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOrderApprove.TextForeColor = System.Drawing.Color.White;
			// 
			// label18
			// 
			this.label18.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label18.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label18.ForeColor = System.Drawing.Color.White;
			this.label18.Location = new System.Drawing.Point(8, 24);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(88, 24);
			this.label18.TabIndex = 15027;
			this.label18.Text = "医嘱类型：";
			// 
			// m_cboOrderListType
			// 
			this.m_cboOrderListType.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOrderListType.BorderColor = System.Drawing.Color.White;
			this.m_cboOrderListType.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOrderListType.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboOrderListType.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboOrderListType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboOrderListType.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboOrderListType.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboOrderListType.ForeColor = System.Drawing.Color.White;
			this.m_cboOrderListType.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOrderListType.ListForeColor = System.Drawing.Color.White;
			this.m_cboOrderListType.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboOrderListType.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboOrderListType.Location = new System.Drawing.Point(96, 24);
			this.m_cboOrderListType.Name = "m_cboOrderListType";
			this.m_cboOrderListType.SelectedIndex = -1;
			this.m_cboOrderListType.SelectedItem = null;
			this.m_cboOrderListType.Size = new System.Drawing.Size(144, 26);
			this.m_cboOrderListType.TabIndex = 15026;
			this.m_cboOrderListType.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOrderListType.TextForeColor = System.Drawing.Color.White;
			// 
			// m_cmdOrderQuery
			// 
			this.m_cmdOrderQuery.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_cmdOrderQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdOrderQuery.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdOrderQuery.ForeColor = System.Drawing.Color.White;
			this.m_cmdOrderQuery.Location = new System.Drawing.Point(880, 80);
			this.m_cmdOrderQuery.Name = "m_cmdOrderQuery";
			this.m_cmdOrderQuery.Size = new System.Drawing.Size(96, 28);
			this.m_cmdOrderQuery.TabIndex = 15024;
			this.m_cmdOrderQuery.Text = "查询";
			this.m_cmdOrderQuery.Click += new System.EventHandler(this.m_cmdOrderQuery_Click);
			// 
			// m_dtpFromDate
			// 
			this.m_dtpFromDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpFromDate.BorderColor = System.Drawing.Color.White;
			this.m_dtpFromDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtpFromDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpFromDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpFromDate.DropButtonForeColor = System.Drawing.Color.White;
			this.m_dtpFromDate.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpFromDate.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpFromDate.ForeColor = System.Drawing.Color.White;
			this.m_dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpFromDate.Location = new System.Drawing.Point(560, 56);
			this.m_dtpFromDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpFromDate.Name = "m_dtpFromDate";
			this.m_dtpFromDate.Size = new System.Drawing.Size(144, 26);
			this.m_dtpFromDate.TabIndex = 31;
			this.m_dtpFromDate.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpFromDate.TextForeColor = System.Drawing.Color.White;
			// 
			// m_lstPhysicianOrderList
			// 
			this.m_lstPhysicianOrderList.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lstPhysicianOrderList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																									  this.columnHeader4,
																									  this.columnHeader24,
																									  this.columnHeader32,
																									  this.columnHeader33,
																									  this.columnHeader34,
																									  this.columnHeader35,
																									  this.columnHeader36,
																									  this.columnHeader37,
																									  this.columnHeader38,
																									  this.columnHeader39,
																									  this.columnHeader40});
			this.m_lstPhysicianOrderList.ContextMenu = this.m_ctnPhysicianOrderList;
			this.m_lstPhysicianOrderList.ForeColor = System.Drawing.Color.White;
			this.m_lstPhysicianOrderList.FullRowSelect = true;
			this.m_lstPhysicianOrderList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_lstPhysicianOrderList.HideSelection = false;
			this.m_lstPhysicianOrderList.Location = new System.Drawing.Point(4, 4);
			this.m_lstPhysicianOrderList.MultiSelect = false;
			this.m_lstPhysicianOrderList.Name = "m_lstPhysicianOrderList";
			this.m_lstPhysicianOrderList.Size = new System.Drawing.Size(984, 304);
			this.m_lstPhysicianOrderList.TabIndex = 3;
			this.m_lstPhysicianOrderList.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "!";
			this.columnHeader4.Width = 30;
			// 
			// columnHeader24
			// 
			this.columnHeader24.Text = "开始时间";
			this.columnHeader24.Width = 171;
			// 
			// columnHeader32
			// 
			this.columnHeader32.Text = "医嘱";
			this.columnHeader32.Width = 200;
			// 
			// columnHeader33
			// 
			this.columnHeader33.Text = "剂量";
			this.columnHeader33.Width = 140;
			// 
			// columnHeader34
			// 
			this.columnHeader34.Text = "用法";
			this.columnHeader34.Width = 70;
			// 
			// columnHeader35
			// 
			this.columnHeader35.Text = "频次";
			this.columnHeader35.Width = 64;
			// 
			// columnHeader36
			// 
			this.columnHeader36.Text = "备注";
			// 
			// columnHeader37
			// 
			this.columnHeader37.Text = "停嘱日期";
			this.columnHeader37.Width = 171;
			// 
			// columnHeader38
			// 
			this.columnHeader38.Text = "停嘱人";
			this.columnHeader38.Width = 80;
			// 
			// columnHeader39
			// 
			this.columnHeader39.Text = "状态";
			// 
			// columnHeader40
			// 
			this.columnHeader40.Text = "主/子医嘱";
			this.columnHeader40.Width = 0;
			// 
			// m_ctnPhysicianOrderList
			// 
			this.m_ctnPhysicianOrderList.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																									this.m_mniCancelOrderList,
																									this.m_mniEndOrderList});
			// 
			// m_mniCancelOrderList
			// 
			this.m_mniCancelOrderList.Index = 0;
			this.m_mniCancelOrderList.Text = "作废";
			this.m_mniCancelOrderList.Click += new System.EventHandler(this.m_mniCancelOrderList_Click);
			// 
			// m_mniEndOrderList
			// 
			this.m_mniEndOrderList.Index = 1;
			this.m_mniEndOrderList.Text = "停用";
			this.m_mniEndOrderList.Click += new System.EventHandler(this.m_mniEndOrderList_Click);
			// 
			// m_tabPhysicianOrderTemplateSet
			// 
			this.m_tabPhysicianOrderTemplateSet.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_tabPhysicianOrderTemplateSet.Controls.AddRange(new System.Windows.Forms.Control[] {
																										 this.m_cmdDeltteTemp,
																										 this.m_cmdApplyToTemp,
																										 this.m_cmdAlterTempRecord,
																										 this.m_cmdAddTempRecord,
																										 this.m_labType,
																										 this.m_labName,
																										 this.m_lstResultSet,
																										 this.m_cboXOrderFlag,
																										 this.m_labXItemUnitID,
																										 this.m_laIndicator,
																										 this.m_cboXStandardID,
																										 this.m_cboSelectMethod,
																										 this.label19,
																										 this.m_cboXOrderTypeID,
																										 this.m_chkBeChild,
																										 this.label20,
																										 this.m_txtGetSelectKeyWord,
																										 this.m_txtDosage,
																										 this.m_cboXUsageID,
																										 this.m_cboXFrequencyID,
																										 this.listView2,
																										 this.label21,
																										 this.m_txtName,
																										 this.m_lsvTemplateContent,
																										 this.m_trvPOTemplate});
			this.m_tabPhysicianOrderTemplateSet.ForeColor = System.Drawing.Color.White;
			this.m_tabPhysicianOrderTemplateSet.Location = new System.Drawing.Point(4, 28);
			this.m_tabPhysicianOrderTemplateSet.Name = "m_tabPhysicianOrderTemplateSet";
			this.m_tabPhysicianOrderTemplateSet.Size = new System.Drawing.Size(996, 468);
			this.m_tabPhysicianOrderTemplateSet.TabIndex = 5;
			this.m_tabPhysicianOrderTemplateSet.Text = "医嘱模版";
			// 
			// m_cmdDeltteTemp
			// 
			this.m_cmdDeltteTemp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdDeltteTemp.Location = new System.Drawing.Point(848, 408);
			this.m_cmdDeltteTemp.Name = "m_cmdDeltteTemp";
			this.m_cmdDeltteTemp.Size = new System.Drawing.Size(120, 40);
			this.m_cmdDeltteTemp.TabIndex = 15057;
			this.m_cmdDeltteTemp.Text = "删除模版";
			this.m_cmdDeltteTemp.Click += new System.EventHandler(this.m_cmdDeltteTemp_Click);
			// 
			// m_cmdApplyToTemp
			// 
			this.m_cmdApplyToTemp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdApplyToTemp.Location = new System.Drawing.Point(848, 376);
			this.m_cmdApplyToTemp.Name = "m_cmdApplyToTemp";
			this.m_cmdApplyToTemp.Size = new System.Drawing.Size(120, 32);
			this.m_cmdApplyToTemp.TabIndex = 15056;
			this.m_cmdApplyToTemp.Text = "保存所有";
			this.m_cmdApplyToTemp.Click += new System.EventHandler(this.m_cmdApplyToTemp_Click);
			// 
			// m_cmdAlterTempRecord
			// 
			this.m_cmdAlterTempRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdAlterTempRecord.Location = new System.Drawing.Point(848, 344);
			this.m_cmdAlterTempRecord.Name = "m_cmdAlterTempRecord";
			this.m_cmdAlterTempRecord.Size = new System.Drawing.Size(120, 32);
			this.m_cmdAlterTempRecord.TabIndex = 15055;
			this.m_cmdAlterTempRecord.Text = "更改记录";
			this.m_cmdAlterTempRecord.Click += new System.EventHandler(this.m_cmdAlterTempRecord_Click);
			// 
			// m_cmdAddTempRecord
			// 
			this.m_cmdAddTempRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdAddTempRecord.Location = new System.Drawing.Point(848, 312);
			this.m_cmdAddTempRecord.Name = "m_cmdAddTempRecord";
			this.m_cmdAddTempRecord.Size = new System.Drawing.Size(120, 32);
			this.m_cmdAddTempRecord.TabIndex = 15054;
			this.m_cmdAddTempRecord.Text = "添加记录";
			this.m_cmdAddTempRecord.Click += new System.EventHandler(this.m_cmdAddTempRecord_Click);
			// 
			// m_labType
			// 
			this.m_labType.Location = new System.Drawing.Point(200, 416);
			this.m_labType.Name = "m_labType";
			this.m_labType.Size = new System.Drawing.Size(80, 23);
			this.m_labType.TabIndex = 15053;
			// 
			// m_labName
			// 
			this.m_labName.Location = new System.Drawing.Point(40, 416);
			this.m_labName.Name = "m_labName";
			this.m_labName.Size = new System.Drawing.Size(144, 56);
			this.m_labName.TabIndex = 15052;
			// 
			// m_lstResultSet
			// 
			this.m_lstResultSet.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lstResultSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lstResultSet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.columnHeader63});
			this.m_lstResultSet.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lstResultSet.ForeColor = System.Drawing.Color.White;
			this.m_lstResultSet.FullRowSelect = true;
			this.m_lstResultSet.GridLines = true;
			this.m_lstResultSet.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lstResultSet.Location = new System.Drawing.Point(512, 168);
			this.m_lstResultSet.Name = "m_lstResultSet";
			this.m_lstResultSet.Size = new System.Drawing.Size(224, 188);
			this.m_lstResultSet.TabIndex = 15051;
			this.m_lstResultSet.View = System.Windows.Forms.View.List;
			this.m_lstResultSet.Visible = false;
			this.m_lstResultSet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lstResultSetKeyDown);
			// 
			// columnHeader63
			// 
			this.columnHeader63.Width = 220;
			// 
			// m_cboXOrderFlag
			// 
			this.m_cboXOrderFlag.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXOrderFlag.BorderColor = System.Drawing.Color.White;
			this.m_cboXOrderFlag.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXOrderFlag.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboXOrderFlag.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboXOrderFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboXOrderFlag.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboXOrderFlag.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboXOrderFlag.ForeColor = System.Drawing.Color.White;
			this.m_cboXOrderFlag.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXOrderFlag.ListForeColor = System.Drawing.Color.White;
			this.m_cboXOrderFlag.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboXOrderFlag.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboXOrderFlag.Location = new System.Drawing.Point(360, 328);
			this.m_cboXOrderFlag.Name = "m_cboXOrderFlag";
			this.m_cboXOrderFlag.SelectedIndex = -1;
			this.m_cboXOrderFlag.SelectedItem = null;
			this.m_cboXOrderFlag.Size = new System.Drawing.Size(96, 26);
			this.m_cboXOrderFlag.TabIndex = 15050;
			this.m_cboXOrderFlag.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXOrderFlag.TextForeColor = System.Drawing.Color.White;
			this.m_cboXOrderFlag.Load += new System.EventHandler(this.m_cboXOrderFlag_Load);
			this.m_cboXOrderFlag.SelectedIndexChanged += new System.EventHandler(this.m_cboXOrderFlag_SelectedIndexChanged);
			// 
			// m_labXItemUnitID
			// 
			this.m_labXItemUnitID.Location = new System.Drawing.Point(544, 416);
			this.m_labXItemUnitID.Name = "m_labXItemUnitID";
			this.m_labXItemUnitID.Size = new System.Drawing.Size(48, 23);
			this.m_labXItemUnitID.TabIndex = 15049;
			// 
			// m_laIndicator
			// 
			this.m_laIndicator.Location = new System.Drawing.Point(48, 424);
			this.m_laIndicator.Name = "m_laIndicator";
			this.m_laIndicator.TabIndex = 15048;
			// 
			// m_cboXStandardID
			// 
			this.m_cboXStandardID.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXStandardID.BorderColor = System.Drawing.Color.White;
			this.m_cboXStandardID.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXStandardID.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboXStandardID.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboXStandardID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboXStandardID.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboXStandardID.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboXStandardID.ForeColor = System.Drawing.Color.White;
			this.m_cboXStandardID.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXStandardID.ListForeColor = System.Drawing.Color.White;
			this.m_cboXStandardID.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboXStandardID.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboXStandardID.Location = new System.Drawing.Point(288, 416);
			this.m_cboXStandardID.Name = "m_cboXStandardID";
			this.m_cboXStandardID.SelectedIndex = -1;
			this.m_cboXStandardID.SelectedItem = null;
			this.m_cboXStandardID.Size = new System.Drawing.Size(148, 26);
			this.m_cboXStandardID.TabIndex = 15046;
			this.m_cboXStandardID.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXStandardID.TextForeColor = System.Drawing.Color.White;
			this.m_cboXStandardID.Load += new System.EventHandler(this.m_cboXStandardID_Load);
			this.m_cboXStandardID.SelectedIndexChanged += new System.EventHandler(this.m_cboXStandardID_SelectedIndexChanged);
			// 
			// m_cboSelectMethod
			// 
			this.m_cboSelectMethod.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboSelectMethod.BorderColor = System.Drawing.Color.White;
			this.m_cboSelectMethod.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboSelectMethod.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboSelectMethod.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboSelectMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboSelectMethod.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboSelectMethod.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboSelectMethod.ForeColor = System.Drawing.Color.White;
			this.m_cboSelectMethod.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboSelectMethod.ListForeColor = System.Drawing.Color.White;
			this.m_cboSelectMethod.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboSelectMethod.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboSelectMethod.Location = new System.Drawing.Point(280, 360);
			this.m_cboSelectMethod.Name = "m_cboSelectMethod";
			this.m_cboSelectMethod.SelectedIndex = -1;
			this.m_cboSelectMethod.SelectedItem = null;
			this.m_cboSelectMethod.Size = new System.Drawing.Size(148, 26);
			this.m_cboSelectMethod.TabIndex = 15045;
			this.m_cboSelectMethod.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboSelectMethod.TextForeColor = System.Drawing.Color.White;
			// 
			// label19
			// 
			this.label19.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label19.ForeColor = System.Drawing.Color.White;
			this.label19.Location = new System.Drawing.Point(40, 360);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(88, 24);
			this.label19.TabIndex = 15044;
			this.label19.Text = "医嘱类别：";
			this.label19.Click += new System.EventHandler(this.label19_Click);
			// 
			// m_cboXOrderTypeID
			// 
			this.m_cboXOrderTypeID.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXOrderTypeID.BorderColor = System.Drawing.Color.White;
			this.m_cboXOrderTypeID.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXOrderTypeID.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboXOrderTypeID.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboXOrderTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboXOrderTypeID.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboXOrderTypeID.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboXOrderTypeID.ForeColor = System.Drawing.Color.White;
			this.m_cboXOrderTypeID.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXOrderTypeID.ListForeColor = System.Drawing.Color.White;
			this.m_cboXOrderTypeID.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboXOrderTypeID.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboXOrderTypeID.Location = new System.Drawing.Point(128, 360);
			this.m_cboXOrderTypeID.Name = "m_cboXOrderTypeID";
			this.m_cboXOrderTypeID.SelectedIndex = -1;
			this.m_cboXOrderTypeID.SelectedItem = null;
			this.m_cboXOrderTypeID.Size = new System.Drawing.Size(144, 26);
			this.m_cboXOrderTypeID.TabIndex = 15043;
			this.m_cboXOrderTypeID.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXOrderTypeID.TextForeColor = System.Drawing.Color.White;
			this.m_cboXOrderTypeID.Load += new System.EventHandler(this.m_cboXOrderTypeID_Load);
			this.m_cboXOrderTypeID.SelectedIndexChanged += new System.EventHandler(this.m_cboXOrderTypeID_SelectedIndexChanged);
			// 
			// m_chkBeChild
			// 
			this.m_chkBeChild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_chkBeChild.Location = new System.Drawing.Point(536, 328);
			this.m_chkBeChild.Name = "m_chkBeChild";
			this.m_chkBeChild.Size = new System.Drawing.Size(204, 24);
			this.m_chkBeChild.TabIndex = 15042;
			this.m_chkBeChild.Text = "作为上一医嘱的子医嘱";
			// 
			// label20
			// 
			this.label20.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label20.ForeColor = System.Drawing.Color.White;
			this.label20.Location = new System.Drawing.Point(456, 368);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(56, 20);
			this.label20.TabIndex = 15040;
			this.label20.Text = "查询：";
			// 
			// m_txtGetSelectKeyWord
			// 
			this.m_txtGetSelectKeyWord.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtGetSelectKeyWord.BorderColor = System.Drawing.Color.White;
			this.m_txtGetSelectKeyWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtGetSelectKeyWord.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtGetSelectKeyWord.ForeColor = System.Drawing.Color.White;
			this.m_txtGetSelectKeyWord.Location = new System.Drawing.Point(512, 360);
			this.m_txtGetSelectKeyWord.Name = "m_txtGetSelectKeyWord";
			this.m_txtGetSelectKeyWord.Size = new System.Drawing.Size(256, 26);
			this.m_txtGetSelectKeyWord.TabIndex = 15037;
			this.m_txtGetSelectKeyWord.Text = "";
			this.m_txtGetSelectKeyWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthSelectKeyWordDown);
			// 
			// m_txtDosage
			// 
			this.m_txtDosage.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtDosage.BorderColor = System.Drawing.Color.White;
			this.m_txtDosage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtDosage.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtDosage.ForeColor = System.Drawing.Color.White;
			this.m_txtDosage.Location = new System.Drawing.Point(440, 416);
			this.m_txtDosage.Name = "m_txtDosage";
			this.m_txtDosage.Size = new System.Drawing.Size(92, 26);
			this.m_txtDosage.TabIndex = 15036;
			this.m_txtDosage.Text = "";
			this.m_txtDosage.TextChanged += new System.EventHandler(this.m_txtDosage_TextChanged);
			// 
			// m_cboXUsageID
			// 
			this.m_cboXUsageID.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXUsageID.BorderColor = System.Drawing.Color.White;
			this.m_cboXUsageID.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXUsageID.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboXUsageID.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboXUsageID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboXUsageID.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboXUsageID.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboXUsageID.ForeColor = System.Drawing.Color.White;
			this.m_cboXUsageID.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXUsageID.ListForeColor = System.Drawing.Color.White;
			this.m_cboXUsageID.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboXUsageID.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboXUsageID.Location = new System.Drawing.Point(608, 416);
			this.m_cboXUsageID.Name = "m_cboXUsageID";
			this.m_cboXUsageID.SelectedIndex = -1;
			this.m_cboXUsageID.SelectedItem = null;
			this.m_cboXUsageID.Size = new System.Drawing.Size(88, 26);
			this.m_cboXUsageID.TabIndex = 15033;
			this.m_cboXUsageID.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXUsageID.TextForeColor = System.Drawing.Color.White;
			this.m_cboXUsageID.Load += new System.EventHandler(this.m_cboXUsageID_Load);
			this.m_cboXUsageID.SelectedIndexChanged += new System.EventHandler(this.m_cboXUsageID_SelectedIndexChanged);
			// 
			// m_cboXFrequencyID
			// 
			this.m_cboXFrequencyID.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXFrequencyID.BorderColor = System.Drawing.Color.White;
			this.m_cboXFrequencyID.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXFrequencyID.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboXFrequencyID.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboXFrequencyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboXFrequencyID.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboXFrequencyID.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboXFrequencyID.ForeColor = System.Drawing.Color.White;
			this.m_cboXFrequencyID.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXFrequencyID.ListForeColor = System.Drawing.Color.White;
			this.m_cboXFrequencyID.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboXFrequencyID.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboXFrequencyID.Location = new System.Drawing.Point(696, 416);
			this.m_cboXFrequencyID.Name = "m_cboXFrequencyID";
			this.m_cboXFrequencyID.SelectedIndex = -1;
			this.m_cboXFrequencyID.SelectedItem = null;
			this.m_cboXFrequencyID.Size = new System.Drawing.Size(64, 26);
			this.m_cboXFrequencyID.TabIndex = 15035;
			this.m_cboXFrequencyID.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXFrequencyID.TextForeColor = System.Drawing.Color.White;
			this.m_cboXFrequencyID.Load += new System.EventHandler(this.m_cboXFrequencyID_Load);
			this.m_cboXFrequencyID.SelectedIndexChanged += new System.EventHandler(this.m_cboXFrequencyID_SelectedIndexChanged);
			// 
			// listView2
			// 
			this.listView2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader57,
																						this.columnHeader58,
																						this.columnHeader59,
																						this.columnHeader60,
																						this.columnHeader61,
																						this.columnHeader62});
			this.listView2.ForeColor = System.Drawing.Color.White;
			this.listView2.FullRowSelect = true;
			this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView2.LabelWrap = false;
			this.listView2.Location = new System.Drawing.Point(40, 392);
			this.listView2.MultiSelect = false;
			this.listView2.Name = "listView2";
			this.listView2.Scrollable = false;
			this.listView2.Size = new System.Drawing.Size(732, 48);
			this.listView2.TabIndex = 15034;
			this.listView2.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader57
			// 
			this.columnHeader57.Text = "名称";
			this.columnHeader57.Width = 250;
			// 
			// columnHeader58
			// 
			this.columnHeader58.Text = "规格";
			this.columnHeader58.Width = 150;
			// 
			// columnHeader59
			// 
			this.columnHeader59.Text = "剂量";
			this.columnHeader59.Width = 100;
			// 
			// columnHeader60
			// 
			this.columnHeader60.Text = "单位";
			// 
			// columnHeader61
			// 
			this.columnHeader61.Text = "用法";
			this.columnHeader61.Width = 100;
			// 
			// columnHeader62
			// 
			this.columnHeader62.Text = "频次";
			this.columnHeader62.Width = 70;
			// 
			// label21
			// 
			this.label21.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label21.ForeColor = System.Drawing.Color.White;
			this.label21.Location = new System.Drawing.Point(16, 328);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(72, 20);
			this.label21.TabIndex = 15039;
			this.label21.Text = "模版名：";
			// 
			// m_txtName
			// 
			this.m_txtName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtName.BorderColor = System.Drawing.Color.White;
			this.m_txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtName.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtName.ForeColor = System.Drawing.Color.White;
			this.m_txtName.Location = new System.Drawing.Point(96, 328);
			this.m_txtName.Name = "m_txtName";
			this.m_txtName.Size = new System.Drawing.Size(256, 26);
			this.m_txtName.TabIndex = 15038;
			this.m_txtName.Text = "";
			this.m_txtName.TextChanged += new System.EventHandler(this.m_txtName_TextChanged);
			// 
			// m_lsvTemplateContent
			// 
			this.m_lsvTemplateContent.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lsvTemplateContent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								   this.columnHeader65,
																								   this.columnHeader66,
																								   this.columnHeader67,
																								   this.columnHeader68,
																								   this.columnHeader69,
																								   this.columnHeader70,
																								   this.columnHeader71,
																								   this.columnHeader72,
																								   this.columnHeader73,
																								   this.columnHeader48});
			this.m_lsvTemplateContent.ForeColor = System.Drawing.Color.White;
			this.m_lsvTemplateContent.FullRowSelect = true;
			this.m_lsvTemplateContent.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_lsvTemplateContent.HideSelection = false;
			this.m_lsvTemplateContent.Location = new System.Drawing.Point(272, 0);
			this.m_lsvTemplateContent.MultiSelect = false;
			this.m_lsvTemplateContent.Name = "m_lsvTemplateContent";
			this.m_lsvTemplateContent.Size = new System.Drawing.Size(712, 304);
			this.m_lsvTemplateContent.TabIndex = 5;
			this.m_lsvTemplateContent.View = System.Windows.Forms.View.Details;
			this.m_lsvTemplateContent.DoubleClick += new System.EventHandler(this.m_lsvTemplateContent_DoubleClick);
			this.m_lsvTemplateContent.SelectedIndexChanged += new System.EventHandler(this.m_lsvTemplateContent_SelectedIndexChanged);
			this.m_lsvTemplateContent.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.m_lsvTemplateContent_ItemCheck);
			// 
			// columnHeader65
			// 
			this.columnHeader65.Text = "医嘱类别";
			this.columnHeader65.Width = 100;
			// 
			// columnHeader66
			// 
			this.columnHeader66.Text = "名称";
			this.columnHeader66.Width = 120;
			// 
			// columnHeader67
			// 
			this.columnHeader67.Text = "";
			// 
			// columnHeader68
			// 
			this.columnHeader68.Text = "规格";
			// 
			// columnHeader69
			// 
			this.columnHeader69.Text = "剂量";
			// 
			// columnHeader70
			// 
			this.columnHeader70.Text = "单位";
			// 
			// columnHeader71
			// 
			this.columnHeader71.Text = "用法";
			// 
			// columnHeader72
			// 
			this.columnHeader72.Text = "频次";
			// 
			// columnHeader73
			// 
			this.columnHeader73.Text = "是否长嘱";
			this.columnHeader73.Width = 100;
			// 
			// columnHeader48
			// 
			this.columnHeader48.Text = "";
			// 
			// m_trvPOTemplate
			// 
			this.m_trvPOTemplate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_trvPOTemplate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_trvPOTemplate.ForeColor = System.Drawing.Color.White;
			this.m_trvPOTemplate.ImageIndex = -1;
			this.m_trvPOTemplate.Location = new System.Drawing.Point(8, 8);
			this.m_trvPOTemplate.Name = "m_trvPOTemplate";
			this.m_trvPOTemplate.SelectedImageIndex = -1;
			this.m_trvPOTemplate.Size = new System.Drawing.Size(256, 304);
			this.m_trvPOTemplate.TabIndex = 0;
			this.m_trvPOTemplate.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trvPOTemplate_AfterSelect);
			// 
			// frmPhysicianOrder
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.ClientSize = new System.Drawing.Size(800, 449);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblDept,
																		  this.m_lsvBedNO,
																		  this.m_lsvPatientName,
																		  this.m_lsvInPatientID,
																		  this.m_cboDept,
																		  this.m_cboArea,
																		  this.m_txtBedNO,
																		  this.m_txtPatientName,
																		  this.lblSex,
																		  this.lblAge,
																		  this.lblBedNoTitle,
																		  this.lblInHospitalNoTitle,
																		  this.lblNameTitle,
																		  this.lblSexTitle,
																		  this.lblAgeTitle,
																		  this.lblAreaTitle,
																		  this.txtInPatientID,
																		  this.m_lblForTitle,
																		  this.m_tabPhysicianOrder});
			this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmPhysicianOrder";
			this.Text = "医嘱管理";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmPhysicianOrder_Load);
			this.m_tabPhysicianOrder.ResumeLayout(false);
			this.m_tbpLongTermPhycianOrder.ResumeLayout(false);
			this.m_grbPhysicianOrder.ResumeLayout(false);
			this.m_tbpNurseHandle.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_objNurseNumericInc)).EndInit();
			this.m_grbNursePhysicianOrder.ResumeLayout(false);
			this.m_tbpShortTermPhycianOrder.ResumeLayout(false);
			this.m_grbTempPhysicianOrder.ResumeLayout(false);
			this.m_tbpPhysicianOrderList.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.m_tabPhysicianOrderTemplateSet.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		//		private void m_txtQuery_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		//		{
		//			if(e.KeyCode ==System.Windows.Forms.Keys.Enter )
		//			{
		//				this.m_lstOptions.Items.Clear ();
		//				this.m_lstOptions.Items.Add ("葡萄糖");
		//				this.m_lstOptions.Items.Add ("菌必治 ");
		//				if(this.m_lstOptions.Items.Count >0) this.m_lstOptions.SelectedIndex =0; 
		//				this.m_lstOptions.Visible =true;
		////				this.m_lstOptions.Focus ();
		//			}
		//		}

		//		private void lstOptions_Leave(object sender, System.EventArgs e)
		//		{
		//			this.m_lstOptions.Visible =false;
		//		}

		//		private void lstOptions_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		//		{
		//			if(e.KeyCode ==System.Windows.Forms.Keys.Enter )
		//			{
		//				this.m_lsvMedical.Items[0].Text = this.m_lstOptions.Text ;
		//				this.m_lstOptions.Visible =false;
		//
		//			}
		//		}

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			m_mthAddPhysicianOrder();
			//			ListViewItem  objListViewItem;
			//			if(this.m_chkIsSubPhysicainOrder.Checked)
			//			{
			//				int i;
			//				for(i=this.m_lsvPhysicianOrder.Items.Count  -1;i>=0;i--)
			//					if(this.m_lsvPhysicianOrder.Items[i].Text !="")break;
			//				if(i<0)
			//				{
			//					clsPublicFunction.ShowInformationMessageBox ("没有找到主医嘱，请先添加主医嘱，然后再添加子医嘱！");
			//					return;
			//				}
			//				else
			//				{
			//					string strDose1= this.m_lsvPhysicianOrder.Items[i].SubItems[3].Text   +  "                      ";  //+ "│" ;
			//					strDose1 =strDose1.Substring (0,14) +  "┑";
			//					this.m_lsvPhysicianOrder.Items[i].SubItems[3].Text =strDose1 ;
			//				}
			//			
			//				string strDose= this.m_txtMedicalDose.Text + this.m_txtMedicalUnit.Text +  "                      ";  //+ "│" ;
			//				strDose =strDose.Substring (0,14) +  "┙";
			//				objListViewItem=new ListViewItem (new string [] {"",   
			//																	this.m_lsvMedical.Items[0].SubItems[2].Text  + " " +  this.m_lsvMedical.Items[0].Text ,
			//																	"药物",																		
			//																	strDose,																	
			//																	"" ,
			//																	"" ,
			//																	"",
			//																	"",
			//																	"2",
			//				});
			//				for(int j=i+1;j<this.m_lsvPhysicianOrder.Items.Count ;j++)
			//				{
			//					strDose= this.m_lsvPhysicianOrder.Items[j].SubItems[3].Text   +  "                      ";  //+ "│" ;
			//					strDose =strDose.Substring (0,14) +  "│";
			//					this.m_lsvPhysicianOrder.Items[j].SubItems[3].Text =strDose ;
			//					this.m_lsvPhysicianOrder.Items[j].SubItems[8].Text ="1";  
			//
			//				}
			//			}
			//			else
			//			{
			//				objListViewItem=new ListViewItem (new string [] {this.m_dtpStartDate.Value.ToString ("yyyy-MM-dd HH:mm:ss"),
			//																	this.m_lsvMedical.Items[0].SubItems[2].Text  + " " +  this.m_lsvMedical.Items[0].Text ,
			//																	"药物",																		
			//																	this.m_txtMedicalDose.Text + this.m_txtMedicalUnit.Text ,
			//																	
			//																	this.m_cboUsage.Text ,
			//																	this.m_cboFrequency.Text ,
			//																	"",
			//																	"",
			//																	"0",
			//				});
			//			}
			//			objListViewItem.BackColor = Color.FromArgb(51, 102, 153);
			//			objListViewItem.ForeColor =Color.White ;
			//			this.m_lsvPhysicianOrder.Items.Add (objListViewItem); 
			//
			//			this.m_txtMedicalDose.Text ="";
			//			this.m_lsvMedical.Items[0].Text  ="";
			//			this.m_lsvMedical.Items[0].SubItems[2].Text ="";
			//			this.m_cboFrequency.SelectedIndex =-1;
			//			this.m_txtMedicalUnit.Text="";
			//			this.m_cboUsage.SelectedIndex =-1; 
		}

		private void frmPhysicianOrder_Load(object sender, System.EventArgs e)
		{
		
		}
		#region 删除长期医嘱,刘颖源,2003-6-26 13:06:28
		private void m_lstPhysicianOrder_DoubleClick(object sender, System.EventArgs e)
		{
			if(sender.GetType().Name=="ListView")
			{
				if(((ListView)sender).Name=="m_lsvPhysicianOrder")
				{
					m_mthRemovePhysicianOrder();
				}
				else if(((ListView)sender).Name=="m_lsvTempPhysicianOrder")
				{
					m_mthTempRemovePhysicianOrder();
				}
			}
			//			if(this.m_lsvPhysicianOrder.SelectedItems.Count <=0 || this.m_lsvPhysicianOrder.SelectedItems[0] ==null)return;
			//			int intIndex=this.m_lsvPhysicianOrder.SelectedItems[0].Index ;			
			//			if(this.m_lsvPhysicianOrder.SelectedItems[0].Text !="")
			//			{
			//				//删除整个医嘱
			//				if(this.m_lsvPhysicianOrder.Items.Count >intIndex +1 && int.Parse ( this.m_lsvPhysicianOrder.Items[intIndex +1].SubItems[8].Text )>0)		//包含有子医嘱
			//				{
			//					if(clsPublicFunction.ShowQuestionMessageBox ("该医嘱包含有一条或多条的子医嘱,是否确定删除?")==System.Windows.Forms.DialogResult.Yes )
			//					{	
			//						while(this.m_lsvPhysicianOrder.Items.Count >intIndex &&  int.Parse ( this.m_lsvPhysicianOrder.Items[intIndex].SubItems[8].Text  )!=2)
			//						{
			//							this.m_lsvPhysicianOrder.Items.RemoveAt (intIndex); 							
			//						}
			//
			//						while(this.m_lsvPhysicianOrder.Items.Count >intIndex &&  int.Parse ( this.m_lsvPhysicianOrder.Items[intIndex].SubItems[8].Text  )==2)
			//						{
			//							this.m_lsvPhysicianOrder.Items.RemoveAt (intIndex); 							
			//						}
			//					}
			//					else
			//					{
			//						
			//					}
			//				}
			//				else
			//				{
			//					this.m_lsvPhysicianOrder.Items.RemoveAt (intIndex);
			//				}
			//			}
			//			else
			//			{
			//				//删除子医嘱
			//				if(intIndex<=0)return;
			//				if(int.Parse (this.m_lsvPhysicianOrder.SelectedItems[0].SubItems[8].Text)==2)		//是最后一条子医嘱
			//				{
			//					if(this.m_lsvPhysicianOrder.Items [intIndex -1].Text !="")	//上一条是否主医嘱
			//					{
			//						string strDose1= this.m_lsvPhysicianOrder.Items[intIndex -1].SubItems[3].Text   +  "                      ";  //+ "│" ;
			//						strDose1 =strDose1.Substring (0,14);
			//						this.m_lsvPhysicianOrder.Items[intIndex -1].SubItems[3].Text =strDose1 ;
			//					}
			//					else
			//					{
			//						string strDose1= this.m_lsvPhysicianOrder.Items[intIndex -1].SubItems[3].Text   +  "                      ";  //+ "│" ;
			//						strDose1 =strDose1.Substring (0,14) +   "┙";
			//						this.m_lsvPhysicianOrder.Items[intIndex -1].SubItems[3].Text =strDose1 ;
			//						this.m_lsvPhysicianOrder.Items[intIndex -1].SubItems[8].Text ="2" ;
			//					}
			//				}
			//				this.m_lsvPhysicianOrder.Items.RemoveAt (intIndex);
			//			}
		}


		#endregion

		private void m_chkIsSubPhysicainOrder_CheckedChanged(object sender, System.EventArgs e)
		{
			if(sender.GetType().Name=="CheckBox")
			{

				m_blnIsSubOrder=((CheckBox)sender).Checked;
				m_cboUsage.Enabled=!m_blnIsSubOrder;
				m_cboTempUsage.Enabled=!m_blnIsSubOrder;
				m_cboFrequency.Enabled=!m_blnIsSubOrder;
				m_cboTempFrequency.Enabled=!m_blnIsSubOrder;
			}
			
			
		}

		
		private void m_cboPhysicianOrderType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(((ctlComboBox)sender).SelectedIndex==-1)
			{
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strOrderTypeID=null;
			}
			else
			{
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strOrderTypeID
					=m_objOrderTypeArr[((ctlComboBox)sender).SelectedIndex].m_strOrderTypeID;
				if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strOrderTypeID.Trim()!="007")
				{
					m_cboUsage.Enabled=false;
					m_cboTempUsage.Enabled=false;
					m_cboMedicineStandard.Enabled=false;
					m_cboTempMedicineStandard.Enabled=false;
					
				}
				else
				{
					m_cboUsage.Enabled=!m_blnIsSubOrder;
					m_cboTempUsage.Enabled=!m_blnIsSubOrder;
					m_cboMedicineStandard.Enabled=true;
					m_cboTempMedicineStandard.Enabled=true;
				}
			}
		}

		private void m_cboQueryType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_objCurrentNewOrderRowInfo.m_intQueryType=((ctlComboBox)sender).SelectedIndex;
			
		
		}

		private void m_cboMedicineStandard_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(((ctlComboBox)sender).SelectedIndex==-1)
			{
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemStandardID=null;
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemUnitID=null;
			}
			else
			{
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemStandardID
					=m_objMedicineStandardArr[((ctlComboBox)sender).SelectedIndex].m_strStandardID;
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemUnitID
					=m_objMedicineStandardArr[((ctlComboBox)sender).SelectedIndex].m_strUnitID;
				if(((ctlComboBox)sender).Name=="m_cboMedicineStandard" && m_lsvMedical.Items.Count==1)
				{
					m_lsvMedical.Items[0].SubItems[3].Text=m_objMedicineStandardArr[((ctlComboBox)sender).SelectedIndex].m_strUnitName;
				}
				else if(((ctlComboBox)sender).Name=="m_cboTempMedicineStandard" && m_lsvTempMedical.Items.Count==1)
				{
					m_lsvTempMedical.Items[0].SubItems[3].Text=m_objMedicineStandardArr[((ctlComboBox)sender).SelectedIndex].m_strUnitName;
				}
			}
		}

		private void m_cboUsage_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(((ctlComboBox)sender).SelectedIndex==-1)
			{
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strUsageID=null;
			}
			else
			{
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strUsageID
					=m_objOrderUsageArr[((ctlComboBox)sender).SelectedIndex].m_strUsageID;
			}
		}

		private void m_cboFrequency_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			if(((ctlComboBox)sender).SelectedIndex==-1)
			{
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strFrequencyID=null;
			}
			else
			{
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strFrequencyID
					=m_objFrequencyInfoArr[((ctlComboBox)sender).SelectedIndex].m_strFrequencyID;
			}
		}

		
		private void m_cboMedicineStandard_DropDown(object sender, System.EventArgs e)
		{
			if(sender.GetType().Name!="ctlComboBox" )return;
			ctlComboBox cboCurrentCbo=(ctlComboBox)sender;
			cboCurrentCbo.ClearItem();
			if(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemID==null
				|| m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemID.Trim().Length==0
				||m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemTypeID==null
				|| m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemTypeID.Trim().Length==0)
			{
				return;
			}
			long lngRes=m_objDomain.m_lngGetMedicineStandard(m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemID.Trim(),
				m_objCurrentNewOrderRowInfo.m_objPhysicianOrderContentValueArr.m_strItemTypeID.Trim(),
				out m_objMedicineStandardArr);
			if(lngRes<=0 || m_objMedicineStandardArr==null) return;
			for(int i=0;i<m_objMedicineStandardArr.Length;i++)
			{
				if(m_objMedicineStandardArr[i].m_strStandardID!=null && m_objMedicineStandardArr[i].m_strStandardName!=null)
				{
					cboCurrentCbo.AddItem(m_objMedicineStandardArr[i].m_strStandardName.Trim());					
					
				}
			}
		}


		private void m_cmdSubmit_Click(object sender, System.EventArgs e)
		{
			m_mthSubmitPhysicianOrder();
		}

		private void m_tabPhysicianOrder_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_blnIsSubOrder=false;
			m_chkIsSubPhysicainOrder.Checked=false;
			m_chkTempIsSubPhysicainOrder.Checked=false;
			m_mthClearTempInputGroup();
			m_mthClearLongTermInputGroup();
			//			m_lsvPhysicianOrder.Items.Clear();
			//			m_lsvTempPhysicianOrder.Items.Clear();
			if(m_tabPhysicianOrder.SelectedIndex==2)
			{
				if(m_objBaseCurrentPatient!=null) m_mthNurseLoadUnconfirmedOrder();
			}
			m_objEditAddIn.m_mthClose();
			//			m_cboUsage.Enabled=!m_blnIsSubOrder;
			//			m_cboTempUsage.Enabled=!m_blnIsSubOrder;
			//			m_cboFrequency.Enabled=!m_blnIsSubOrder;
			//			m_cboTempFrequency.Enabled=!m_blnIsSubOrder;
		
			if ( m_tabPhysicianOrder.SelectedIndex == 4 )
			{
				m_mthInitAllPhysicianOrderTemplateSet();
			}
		}

		private void m_cmdTempOK_Click(object sender, System.EventArgs e)
		{
			m_mthTempAddPhysicianOrder();
		}

		private void m_cmdTempSubmit_Click(object sender, System.EventArgs e)
		{
			m_mthTempSubmitPhysicianOrder();
		}

		

		private class clsNumericListViewAssistArrayItem
		{
			public string m_strID="";
			public string m_strName="";
			public string m_strNumber="";
		}
		private class clsNumericListView : ListView
		{
			private ListView m_lsv=null;
			private NumericUpDown m_objNum=null;
			private ArrayList m_arlItems=new ArrayList();
			
			private bool m_blnIsOpen=false;
			public bool m_BlnIsOpen
			{
				get
				{
					return m_blnIsOpen;
				}
			}
	
			private long m_intLeftPosition=0;
			private clsNumericListViewAssistArrayItem[] m_objItemsArr=null;
			public clsNumericListViewAssistArrayItem[] m_ObjItemsArr
			{
				get
				{
					
					return m_objItemsArr;
				}
				set
				{
					m_objItemsArr=value;
					m_arlItems.Clear();
					if(m_objItemsArr==null) return;
					for(int i=0;i<m_objItemsArr.Length;i++)
					{
						m_arlItems.Add(m_objItemsArr[i]);
					}
				}
			}

			public clsNumericListView(ListView p_lsv, NumericUpDown p_objNum, clsNumericListViewAssistArrayItem[] p_objItemsArr)
			{
				if(p_lsv==null || p_objNum==null) return;
				m_lsv=p_lsv;
				m_objNum=p_objNum;
				m_objItemsArr=p_objItemsArr;
				Init();
				//				this.sc
			}
			private void Init()
			{
				//				m_lsv.FullRowSelect=false;
				m_lsv.MouseDown+=new MouseEventHandler(m_mthLsvMouseDown);
				m_lsv.MouseUp+=new MouseEventHandler(m_mthLsvMouseUp);
				m_lsv.MouseLeave+=new EventHandler  (m_mthLsvMouseLeave);
				//				m_lsv.KeyDown+=new KeyEventHandler(m_mthKeyDown);
				//				m_objNum.KeyDown+=new KeyEventHandler(m_mthKeyDown);
				m_objNum.MouseLeave+=new EventHandler  (m_mthLsvMouseLeave);
				m_lsv.MouseMove +=new MouseEventHandler (m_mthLsvMouseMove);
				m_objNum.ValueChanged+=new EventHandler( m_mthNumValueChanged);
				//				m_lsv.SelectedIndexChanged+=new EventHandler(m_mthLsvSelectedIndexChanged);
			}
			//			private void m_mthLsvNumberClicked(object sender, System.EventArgs e)
			//			{
			//				
			//			}
			private void m_mthLsvMouseMove(object sender ,MouseEventArgs e)
			{
				m_intLeftPosition=e.X ;
			}
			
			private void m_mthLsvSelectedIndexChanged(object sender, System.EventArgs e)
			{
				
			}
			private void m_mthLsvMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
			{
				m_objNum.Visible=false;
				if(e.Clicks==1)
				{
					
				}
				else if(e.Clicks==2 && m_lsv.SelectedItems.Count==1 )
				{
					m_arlItems.RemoveAt(m_lsv.SelectedItems[0].Index);
					m_lsv.SelectedItems[0].Remove();

				}
		
			}
			private void m_mthLsvMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
			{

				if(m_lsv.SelectedItems.Count==1)
				{
					//					m_blnShiftFocus=true;
					m_objNum.Left=m_lsv.Left+m_lsv.Columns[0].Width+3;
					m_objNum.Top=m_lsv.Location.Y+m_lsv.SelectedItems[0].Bounds.Y;
					try
					{
						m_objNum.Value=int.Parse( m_lsv.SelectedItems[0].SubItems[1].Text);
					}
					catch
					{
					}
					m_objNum.Visible=true;
					m_objNum.BringToFront();

					
					//m_blnActiveLsvLoseFocus=true;
					//m_blnActiveNumLoseFocus=true;
					m_objNum.Focus();
				}
		
				
			}

			private void m_mthLsvMouseLeave(object sender, System.EventArgs  e)
			{
				//MessageBox.Show (m_objNum.Left.ToString () + " " + m_intLeftPosition.ToString ()); 

			
				
				if(((Control)sender).Name==m_lsv.Name  && m_intLeftPosition > (m_lsv.Width - 25))
				{
					
					m_objNum.Visible =false; 
					m_lsv.Focus();
					//MessageBox.Show (m_objNum.Left.ToString () + " " + m_intLeftPosition.ToString ()); 
				}
				else if(((Control)sender).Name==m_objNum.Name  && m_intLeftPosition > (m_objNum.Width - 25))
				{
					m_objNum.Visible =false; 
					m_lsv.Focus();
				}
			}

			private void m_mthLostFocus(object sender, System.EventArgs e)
			{
				
				Application.DoEvents();
				if(((Control)sender).Name==m_objNum.Name)
				{
					m_objNum.Visible=false;
					if(!m_lsv.Focused) m_lsv.Visible=false;
				
				}
				else if(((Control)sender).Name==m_lsv.Name && !m_objNum.Focused)
				{
					m_lsv.Visible=false;
				}
			
 
			}
			private void m_mthGotFocus(object sender, System.EventArgs e)
			{
				//				((Control)sender).Visible=true;
				
				if(((Control)sender).Name==m_objNum.Name)
				{
					//										((Control)sender).BringToFront();
					//					m_lsv.Visible=true;
					//					m_objNum.Visible=true;
					//					m_objNum.BringToFront();
	
					
				}
				else if(((Control)sender).Name==m_lsv.Name )
				{
					
					//					m_objNum.Visible=true;
					//					m_objNum.BringToFront();
					//					m_blnActiveNumLoseFocus=false;
					//					m_blnActiveLsvLoseFocus=true;
					//					m_objNum.Focus();
					
				}
				
				

			}
			private void m_mthKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
			{
				if(e.KeyValue==27 && ( ((Control)sender).Name==m_lsv.Name || ((Control)sender).Name==m_objNum.Name))
				{
					m_mthClose();
				}
			}
			private void m_mthNumValueChanged(object sender, System.EventArgs e)
			{
				if(m_lsv.SelectedItems.Count!=1) return;
				m_lsv.SelectedItems[0].SubItems[1].Text=m_objNum.Value.ToString();
				((clsNumericListViewAssistArrayItem)m_arlItems[m_lsv.SelectedItems[0].Index]).m_strNumber=m_objNum.Value.ToString();
			}

			public void m_mthShow()
			{
				if(m_blnIsOpen) return;
				m_lsv.Items.Clear();
				if(m_objItemsArr== null || m_objItemsArr.Length==0) return;
				for(int i=0;i<m_objItemsArr.Length;i++)
				{
					ListViewItem objLsvItem=new ListViewItem(new string[]{m_objItemsArr[i].m_strName,m_objItemsArr[i].m_strNumber });
					objLsvItem.Tag=m_objItemsArr[i].m_strID;
					m_lsv.Items.Add(objLsvItem);
				}
				m_objNum.Visible =false;
				m_lsv.Visible=true;
				m_lsv.Focus();
				
				if(m_lsv.Items.Count>0) m_lsv.Items[0].Selected=true;
				m_blnIsOpen=true;
			}
			public void m_mthClose()
			{
				if(!m_blnIsOpen) return;
				int i=0;
				while(i<m_arlItems.Count)
				{
					if(((clsNumericListViewAssistArrayItem)m_arlItems[i]).m_strNumber=="0")
					{
						m_arlItems.RemoveAt(i);
						
					}
					else
					{
						i++;
					}
				}
				m_objItemsArr=(clsNumericListViewAssistArrayItem[])m_arlItems.ToArray(typeof(clsNumericListViewAssistArrayItem));
				m_lsv.Visible=false;
				m_objNum.Visible=false;
				m_blnIsOpen=false;
			}
		}

		private class clsNurseConfirmInfo
		{
			
			public int m_intQueryType=-1;
			public int m_intSubOrderFlag=0;

			public bool m_blnIfConfirmed=false;
			public bool m_blnIfPerformed=false;
			public bool m_blnIfEnded=false;
			public bool m_blnIfCanceled=false;

			public string m_strInPatientID;
			public string m_strInPatientDate;
			public string m_strOpenDate;
			public string m_strOrderID;
			public string m_strConfirmUserID;
			public clsPhysicianOrderAddInValue[] objAddInValueArr=null;
		}

		private class clsNursePerformInfo
		{
			public int m_intQueryType=-1;
			public int m_intSubOrderFlag=0;
			public clsPhysicianOrderPerformedListValue m_objPhysicianOrderPerformedList=null;
			public clsPhysicianOrderPerformedAddInValue[] m_objPhysicianOrderPerformedAddInArr=null;
			public clsPhysicianOrderAddInValue[] m_objPhysicianOrderAddInArr=null;
		}

		private class clsNewOrderRowInfo
		{

			public clsPhysicianOrderBaseValue m_objPhysicianOrderBaseValueArr=new clsPhysicianOrderBaseValue();
			public clsPhysicianOrderContentValue m_objPhysicianOrderContentValueArr=new clsPhysicianOrderContentValue();

			public int m_intQueryType=-1;
			public int m_intSubOrderFlag=0;


		}

		private void m_cmdOrderQuery_Click(object sender, System.EventArgs e)
		{
			m_mthLoadAllCombinationList();
			return;

			#region Unreachable code
			/*
			ListViewItem obj;

			int intOrderList=this.m_cboOrderListType.SelectedIndex ;
			int intConfirm=this.m_cboOrderApprove.SelectedIndex ;
			int intCancel =this.m_cboOrderCancel.SelectedIndex ;
			int intEnd =this.m_cboOrderEnd.SelectedIndex ;
			int intPerformed =this.m_cboOrderPerform.SelectedIndex ;
			string strFromDate=this.m_dtpFromDate.Value.ToString ("yyyy-MM-dd HH:mm:ss");
			string strToDate=this.m_dtpToDate.Value.ToString ("yyyy-MM-dd HH:mm:ss");
			
			string strOpenDate="";
			string strOrderID="";
			string strSubOrderID="";
			string strAddInInfo="";
			
			clsPhysicianOrderDetailListValue  [] objPhysicianOrderDetailListValue=null;
			bool blnIsMainOrder=true;
			this.m_lstPhysicianOrderList.Items.Clear (); 
			long lngRes=m_objDomain.m_lngGetAllCombinationPhysicianOrder ("0000001","2003-01-01 00:00:00.000",intOrderList ,intConfirm ,intCancel ,intEnd ,intPerformed ,strFromDate,strToDate , out objPhysicianOrderDetailListValue);
			if(objPhysicianOrderDetailListValue==null || objPhysicianOrderDetailListValue.Length <=0)return;
			for(int i=0;i<objPhysicianOrderDetailListValue.Length ;i++)
			{
				#region open date
				if(strOpenDate ==objPhysicianOrderDetailListValue[i].m_strOpenDate )	//上一张的医嘱单
				{
					#region	OrderID
					if(strOrderID ==objPhysicianOrderDetailListValue[i].m_strOrderID )	//同一张医嘱单的上一条医嘱
					{
						#region	SubOrderID
						if(strSubOrderID ==objPhysicianOrderDetailListValue[i].m_strSubOrderID )	//同一条子医嘱
						{
							//计算附加物
						}
						else										//新的子医嘱
						{
							strSubOrderID =objPhysicianOrderDetailListValue[i].m_strSubOrderID ;
							blnIsMainOrder=false;
							#region 添加Item,SubOrderID
							ListViewItem objItem;
							objItem=new ListViewItem (new string []{"","","","","","","","","","","" });
							if(blnIsMainOrder )
							{
								objItem.SubItems[0].Text =objPhysicianOrderDetailListValue[i].m_strOrderFlag=="0"?"长":"临";
								objItem.SubItems[1].Text =objPhysicianOrderDetailListValue[i].m_strStartDate ;
								objItem.SubItems[7].Text =objPhysicianOrderDetailListValue[i].m_strActualEndDate.Trim ()=="1900-1-1"?"":objPhysicianOrderDetailListValue[i].m_strActualEndDate ;
								objItem.SubItems[8].Text =objPhysicianOrderDetailListValue[i].m_strActualEndUserID ;							
								objItem.SubItems[9].Text =strAddInInfo;
								blnIsMainOrder=false;
							}
							objItem.SubItems[2].Text =objPhysicianOrderDetailListValue[i].m_strOrderTypeID =="007"? objPhysicianOrderDetailListValue[i].m_strMedicineName:objPhysicianOrderDetailListValue[i].m_strDetailName  ;
							objItem.SubItems[3].Text =objPhysicianOrderDetailListValue[i].m_strItemDosage + " " + objPhysicianOrderDetailListValue[i].m_strUnitName ;
							objItem.SubItems[4].Text =objPhysicianOrderDetailListValue[i].m_strUsageName ;
							objItem.SubItems[5].Text =objPhysicianOrderDetailListValue[i].m_strFrequencyName ;
							objItem.SubItems[6].Text =objPhysicianOrderDetailListValue[i].m_strRemark ;
							objItem.ForeColor =Color.White ;
							this.m_lstPhysicianOrderList.Items.Add (objItem); 
							#endregion
						}
						#endregion

					}
					else																//不同医嘱,新的医嘱项目
					{
						strOrderID =objPhysicianOrderDetailListValue[i].m_strOrderID ;
						strSubOrderID =objPhysicianOrderDetailListValue[i].m_strSubOrderID ;
						blnIsMainOrder=true;
						#region 添加Item,SubOrderID
						ListViewItem objItem;
						objItem=new ListViewItem (new string []{"","","","","","","","","","","" });
						if(blnIsMainOrder )
						{
							objItem.SubItems[0].Text =objPhysicianOrderDetailListValue[i].m_strOrderFlag=="0"?"长":"临";
							objItem.SubItems[1].Text =objPhysicianOrderDetailListValue[i].m_strStartDate ;
							objItem.SubItems[7].Text =objPhysicianOrderDetailListValue[i].m_strActualEndDate.Trim ()=="1900-1-1"?"":objPhysicianOrderDetailListValue[i].m_strActualEndDate  ;
							objItem.SubItems[8].Text =objPhysicianOrderDetailListValue[i].m_strActualEndUserID ;							
							objItem.SubItems[9].Text =strAddInInfo;
							blnIsMainOrder=false;
						}
						objItem.SubItems[2].Text =objPhysicianOrderDetailListValue[i].m_strOrderTypeID =="007"? objPhysicianOrderDetailListValue[i].m_strMedicineName:objPhysicianOrderDetailListValue[i].m_strDetailName  ;
						objItem.SubItems[3].Text =objPhysicianOrderDetailListValue[i].m_strItemDosage + " " + objPhysicianOrderDetailListValue[i].m_strUnitName ;
						objItem.SubItems[4].Text =objPhysicianOrderDetailListValue[i].m_strUsageName ;
						objItem.SubItems[5].Text =objPhysicianOrderDetailListValue[i].m_strFrequencyName ;
						objItem.SubItems[6].Text =objPhysicianOrderDetailListValue[i].m_strRemark ;
						objItem.ForeColor =Color.White ;
						this.m_lstPhysicianOrderList.Items.Add (objItem); 
							#endregion

					}
					#endregion
				}
				else			//open date,不同时间开的医嘱单,新的医嘱单开始，加入该条目
				{
					strOpenDate =objPhysicianOrderDetailListValue[i].m_strOpenDate ;
					strOrderID =objPhysicianOrderDetailListValue[i].m_strOrderID ;
					strSubOrderID =objPhysicianOrderDetailListValue[i].m_strSubOrderID ;
					blnIsMainOrder =true;
					#region 添加Item,SubOrderID
					ListViewItem objItem;
					objItem=new ListViewItem (new string []{"","","","","","","","","","","" });
					if(blnIsMainOrder )
					{
						objItem.SubItems[0].Text =objPhysicianOrderDetailListValue[i].m_strOrderFlag=="0"?"长":"临";
						objItem.SubItems[1].Text =objPhysicianOrderDetailListValue[i].m_strStartDate ;
						objItem.SubItems[7].Text =objPhysicianOrderDetailListValue[i].m_strActualEndDate.Trim ()=="1900-1-1"?"":objPhysicianOrderDetailListValue[i].m_strActualEndDate  ;
						objItem.SubItems[8].Text =objPhysicianOrderDetailListValue[i].m_strActualEndUserID ;							
						objItem.SubItems[9].Text =strAddInInfo;
						blnIsMainOrder=false;
					}
					objItem.SubItems[2].Text =objPhysicianOrderDetailListValue[i].m_strOrderTypeID =="007"? objPhysicianOrderDetailListValue[i].m_strMedicineName:objPhysicianOrderDetailListValue[i].m_strDetailName  ;
					objItem.SubItems[3].Text =objPhysicianOrderDetailListValue[i].m_strItemDosage + " " + objPhysicianOrderDetailListValue[i].m_strUnitName ;
					objItem.SubItems[4].Text =objPhysicianOrderDetailListValue[i].m_strUsageName ;
					objItem.SubItems[5].Text =objPhysicianOrderDetailListValue[i].m_strFrequencyName ;
					objItem.SubItems[6].Text =objPhysicianOrderDetailListValue[i].m_strRemark ;
					objItem.ForeColor =Color.White ;
					this.m_lstPhysicianOrderList.Items.Add (objItem); 
						#endregion

				}
				#endregion


			}	//end for
			*/
			#endregion Unreachable code
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			m_mthNurseLoadUnconfirmedOrder();
			//			m_mthNurseLoadUnperformedOrder();
		}

		private void m_cmdSetConfirmed_Click(object sender, System.EventArgs e)
		{
			m_mthNurseConfirmSelectHandling();
		}

		private void m_cmdNurseSetPerformed_Click(object sender, System.EventArgs e)
		{
			m_mthNursePerformSelectHandling();
		}
			
		
		private void m_cmdNurseDisplayAddIn_Click(object sender, System.EventArgs e)
		{
			if(!m_objEditAddIn.m_BlnIsOpen)
			{
				if(m_blnNurseIsUnconfirmed) m_mthNurseEditAddIn();
				else m_mthNurseEditPerformAddIn();

			
			}
			else
			{
				if(m_blnNurseIsUnconfirmed) m_mthNurseConfirmAddIn();
				else m_mthNursePerformAddIn();

			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			m_mthSetQuickKeys();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			m_mthNurseLoadUnperformedOrder();
		}

		private void m_rdbNurseNotConfirmed_CheckedChanged(object sender, System.EventArgs e)
		{
			m_blnNurseIsUnconfirmed=true;
			m_cmdSetConfirmed.Visible=true;
			m_cmdNurseSetPerformed.Visible=false;
			m_dtpNursePerformDate.Visible=false;
			m_lblNursePerformDateTitle.Visible=false;
			if(m_objBaseCurrentPatient==null) return;
			m_mthNurseLoadUnconfirmedOrder();
		}

		private void m_rdbNurseNotPerformed_CheckedChanged(object sender, System.EventArgs e)
		{
			m_blnNurseIsUnconfirmed=false;
			m_cmdSetConfirmed.Visible=false;
			m_cmdNurseSetPerformed.Visible=true;
			m_dtpNursePerformDate.Visible=true;
			m_lblNursePerformDateTitle.Visible=true;
			if(m_objBaseCurrentPatient==null) return;
			m_mthNurseLoadUnperformedOrder();
		}

		private void m_mniCancelOrderList_Click(object sender, System.EventArgs e)
		{
			m_mthCancelOrderListSelectHandle();
		}

		private void m_mniEndOrderList_Click(object sender, System.EventArgs e)
		{
			m_mthEndOrderListSelectHandle();
		}

		private void tabPage1_Click(object sender, System.EventArgs e)
		{
		
		}

	// 8.3 here we go 
		class clsTempRecord : clsPhysicianOrderTemplateContentValue
		{
			public string  m_strOrderFlag = "";
		}

		clsTempRecord[] m_obj_Lsv_RecordArr;

		clsPhysicianOrderTemplateSetValueCase[] m_objTemp_PhysicianOrderTemplateSetValueCaseArr;


		clsPhysicianOrderTypeValue[] m_objPhysicianOrderTypeValueArr;
		clsPhysicianOrderTypeDetailValue[] m_objPhysicianOrderTypeDetailValueArr;
		clsPhysicianOrderUsageValue[] m_objPhysicianOrderUsageValueArr;
		clsPhysicianOrderFrequencyInfoValue[] m_objPhysicianOrderFrequencyInfoValueArr;
		clsPhysicianOrderMedicineNameValue[] m_objPhysicianOrderMedicineNameValueArr;
		clsPhysicianOrderMedicineTypeValue[] m_objPhysicianOrderMedicineTypeValueArr;
		clsPhysicianOrderMedicineStandardValue[] m_objPhysicianOrderMedicineStandardValueArr;
		
		

		
		private void m_mth_PhysicianOrderTemplate_SetAllNull () 
		{
			m_objTemp_PhysicianOrderTemplateSetValueCaseArr = null;

			m_objPhysicianOrderTypeValueArr = null;
			m_objPhysicianOrderTypeDetailValueArr = null;
			m_objPhysicianOrderUsageValueArr = null;
			m_objPhysicianOrderFrequencyInfoValueArr = null;
			m_objPhysicianOrderMedicineNameValueArr = null;
			m_objPhysicianOrderMedicineTypeValueArr = null;
			m_objPhysicianOrderMedicineStandardValueArr = null;
			
			


			m_strResult_Name = "";
			m_strResult_CreatorID = "";
			m_strResult_OrderFlag = "";
			m_strResult_OrderTypeID = "";
			m_strResult_DetailID = "";
			m_strResult_UsageID = "";
			m_strResult_FrequencyID = "";
			m_strResult_ItemID = "";
			m_strResult_ItemTypeID = "";
			m_strResult_ItemStandardID = "";
			m_strResult_ItemUnitID = "";
			m_strResult_ItemDosage = "";
			
		}


		private void m_mth_Show_m_PhysicianOrderTemplateSetValueCaseArr()
		{			
			if ( m_objTemp_PhysicianOrderTemplateSetValueCaseArr == null )
				return ;
			m_trvPOTemplate.Nodes.Add ( "医嘱模版名称" ) ;
			for ( int i = 0 ; i < m_objTemp_PhysicianOrderTemplateSetValueCaseArr.Length ; i ++ )
			{
				m_trvPOTemplate.Nodes[0].Nodes.Add ( m_objTemp_PhysicianOrderTemplateSetValueCaseArr[i].m_strName );
			}
			m_trvPOTemplate.ExpandAll();
		}

		private void m_mthPhysicianOrderTemplate_SetAllCtrlInit ()
		{
			// set all ctl to init
			m_trvPOTemplate.Nodes.Clear();
			m_lsvTemplateContent.Items.Clear();
			m_txtName.Text = "";
			m_lstResultSet.Items.Clear();
			m_txtGetSelectKeyWord.Text = "";
			m_cboSelectMethod.ClearItem();
			m_cboXOrderTypeID.ClearItem();
			m_cboXOrderFlag.ClearItem();
			m_labName.Text = "";
			m_labType.Text = "";
			m_cboXStandardID.ClearItem();
			m_txtDosage.Text = "";
			m_labXItemUnitID.Text = ""; 
			m_cboXUsageID.ClearItem();
			m_cboXFrequencyID.ClearItem();
		}


		private void m_mthInitAllPhysicianOrderTemplateSet()
		{
            clsPhysicianOrderService objServ =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			// set all to null 
			m_mth_PhysicianOrderTemplate_SetAllNull();
			// set all ctl to init
			m_mthPhysicianOrderTemplate_SetAllCtrlInit();
			// get m_objTemp_PhysicianOrderTemplateSetValueCaseArr and show listview

            objServ.m_lngGetAllPhysicianOrderTemplateSetCase(out m_objTemp_PhysicianOrderTemplateSetValueCaseArr);
			
            m_mth_Show_m_PhysicianOrderTemplateSetValueCaseArr();
			// set m_strResult_CreatorID
			m_strResult_CreatorID = MDIParent.OperatorID;
			// set m_lstResultSet to invisible
			m_lstResultSet.Visible = false;

			// init m_cboXOrderTypeID and m_objXPhysicianOrderTypeValue

            objServ.m_lngGetAllPhysicianOrderType(out m_objPhysicianOrderTypeValueArr);
			
            m_lngFill_m_cboXOrderTypeID();
			// init m_cboSelectMethod
			m_cboSelectMethod.AddItem("按拼音码查询");
			m_cboSelectMethod.AddItem("按拉丁名查询");
			m_cboSelectMethod.AddItem("按英文名查询");
			m_cboSelectMethod.AddItem("按拼药ID查询");
			m_cboSelectMethod.SelectedIndex = 0;
			// init m_cboXUsageID and m_objPhysicianOrderUsageValueArr

            objServ.m_lngGetAllPhysicianOrderUsage(out m_objPhysicianOrderUsageValueArr);
			
            for ( int i = 0 ; i < m_objPhysicianOrderUsageValueArr.Length ; i ++ )
			{
				m_cboXUsageID.AddItem(m_objPhysicianOrderUsageValueArr[i].m_strUsageName);
			}
			m_cboXUsageID.SelectedIndex = -1;
			// init m_cboXFrequencyID and m_objPhysicianOrderFrequencyInfoValueArr

            objServ.m_lngGetAllPhysicianOrderFrequencyInfo(out m_objPhysicianOrderFrequencyInfoValueArr);
			
            for ( int i = 0 ; i < m_objPhysicianOrderFrequencyInfoValueArr.Length ; i ++ )
			{
				m_cboXFrequencyID.AddItem(m_objPhysicianOrderFrequencyInfoValueArr[i].m_strFrequencyName);
			}
			m_cboXFrequencyID.SelectedIndex = -1;
			// init m_cboXOrderFlag
			m_cboXOrderFlag.AddItem("短嘱");
			m_cboXOrderFlag.AddItem("长嘱");
			m_cboXOrderFlag.SelectedIndex = 0;
			m_strResult_OrderFlag = ( (int) 0 ).ToString();
			m_chkBeChild.Checked = false;

			m_obj_Lsv_RecordArr = null;
		}

		private long m_lngFill_m_cboPhysicianOrderType()
		{
			for ( int i = 0 ; i < m_objPhysicianOrderTypeValueArr.Length ; i ++ )
			{
				m_cboPhysicianOrderType.AddItem ( m_objPhysicianOrderTypeValueArr[i].m_strOrderTypeName );
			}

			return 1;
		}

		private long m_lngFill_m_cboXOrderTypeID()
		{
			for ( int i = 0 ; i < m_objPhysicianOrderTypeValueArr.Length ; i ++ )
			{
				m_cboXOrderTypeID.AddItem ( m_objPhysicianOrderTypeValueArr[i].m_strOrderTypeName );
			}

			return 1;
		}

		private void m_cboXOrderTypeID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_strResult_OrderTypeID = m_objPhysicianOrderTypeValueArr [ m_cboXOrderTypeID.SelectedIndex ].m_strOrderTypeID;
			m_labName.Text = "";
			m_labType.Text = "";
			m_lstResultSet.Items.Clear();
			m_lstResultSet.Visible = false;
			if ( m_cboXOrderTypeID.SelectedIndex ==  6 )
				m_strResult_DetailID = "00001";
		}

		private void m_mthSelectKeyWordDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            clsPhysicianOrderService objServ =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			if ( ( e.KeyCode ==System.Windows.Forms.Keys.Enter ) && ( m_cboXOrderTypeID.SelectedIndex != 6 ) )   
			{
				m_lstResultSet.Items.Clear();
				// init m_objPhysicianOrderTypeDetailValueArr
  
				objServ.m_lngGetPhysicianOrderTypeDetail(  m_objPhysicianOrderTypeValueArr[ m_cboXOrderTypeID.SelectedIndex ].m_strOrderTypeID , out m_objPhysicianOrderTypeDetailValueArr );
				// show m_objPhysicianOrderTypeDetailValueArr on m_lstResultSet
				m_lstResultSet.Visible = true ;
				for ( int i = 0 ; i < m_objPhysicianOrderTypeDetailValueArr.Length ; i ++ )
				{
					m_lstResultSet.Items.Add ( m_objPhysicianOrderTypeDetailValueArr[i].m_strDetailName );
					
				}
			}

			if ( ( e.KeyCode ==System.Windows.Forms.Keys.Enter ) && ( m_cboXOrderTypeID.SelectedIndex == 6 ) )
			{	
				m_lstResultSet.Items.Clear();
				// init m_objPhysicianOrderMedicineNameValueArr
				if ( m_cboSelectMethod.SelectedIndex == 0 )
				{
                    objServ.m_lngGetMedicineNameByPingYinCode(m_txtGetSelectKeyWord.Text, out m_objPhysicianOrderMedicineNameValueArr);
				}
				if ( m_cboSelectMethod.SelectedIndex == 1 )
				{
                    objServ.m_lngGetMedicineNameByLatinCode(m_txtGetSelectKeyWord.Text, out m_objPhysicianOrderMedicineNameValueArr);
				}
				if ( m_cboSelectMethod.SelectedIndex == 2 )
				{
                    objServ.m_lngGetMedicineNameByEnglishCode(m_txtGetSelectKeyWord.Text, out m_objPhysicianOrderMedicineNameValueArr);
				}
				if ( m_cboSelectMethod.SelectedIndex == 3 )
				{
                    objServ.m_lngGetMedicineNameByMedicineID(m_txtGetSelectKeyWord.Text, out m_objPhysicianOrderMedicineNameValueArr);
				}

				for ( int i = 0 ; i < m_objPhysicianOrderMedicineNameValueArr.Length ; i ++ )
				{
					m_lstResultSet.Items.Add( m_objPhysicianOrderMedicineNameValueArr[i].m_strMedicineName) ;
				}

				m_lstResultSet.Visible = true ;

			}
		}

		private void m_lstResultSetKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ( ( e.KeyCode ==System.Windows.Forms.Keys.Enter ) && ( m_cboXOrderTypeID.SelectedIndex != 6 ) )   
			{
				m_labName.Text = m_objPhysicianOrderTypeDetailValueArr[ m_lstResultSet.SelectedIndices[0] ].m_strDetailName;
				m_strResult_DetailID =  m_objPhysicianOrderTypeDetailValueArr[ m_lstResultSet.SelectedIndices[0] ].m_strDetailID;
				m_lstResultSet.Visible = false;
				m_lstResultSet.Items.Clear();
				return ;
			}

            clsPhysicianOrderService objServ =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			if ( ( e.KeyCode ==System.Windows.Forms.Keys.Enter ) && ( m_cboXOrderTypeID.SelectedIndex == 6 ) )
			{
				if ( m_labName.Text == "" )
				{
					m_labName.Text = m_objPhysicianOrderMedicineNameValueArr[ m_lstResultSet.SelectedIndices[0] ].m_strMedicineName ;
					m_strResult_ItemID = m_objPhysicianOrderMedicineNameValueArr[ m_lstResultSet.SelectedIndices[0] ].m_strMedicineID ;
					// init next procedure for itmeTypeID
					m_lstResultSet.Items.Clear();

                    objServ.m_lngGetMedicineType(m_strResult_ItemID, out m_objPhysicianOrderMedicineTypeValueArr);
					
                    for ( int i = 0 ; i < m_objPhysicianOrderMedicineTypeValueArr.Length ; i ++ )
					{
						m_lstResultSet.Items.Add( m_objPhysicianOrderMedicineTypeValueArr[i].m_strMedicineOfTypeName );
					}
					return;
				}
				if ( m_labName.Text != "" )
				{
					try 
					{
						m_labType.Text = m_objPhysicianOrderMedicineTypeValueArr[ m_lstResultSet.SelectedIndices[0] ].m_strMedicineOfTypeName;
						m_strResult_ItemTypeID = m_objPhysicianOrderMedicineTypeValueArr[ m_lstResultSet.SelectedIndices[0] ].m_strMedicineOfTypeID;
						m_lstResultSet.Visible = false;
						m_lstResultSet.Items.Clear();

                        objServ.m_lngGetMedicineStandard(m_strResult_ItemID, m_strResult_ItemTypeID, out  m_objPhysicianOrderMedicineStandardValueArr);
						
                        m_cboXStandardID.ClearItem();
						for ( int i = 0 ; i < m_objPhysicianOrderMedicineStandardValueArr.Length ; i ++ )
						{
							m_cboXStandardID.AddItem( m_objPhysicianOrderMedicineStandardValueArr[i].m_strStandardName);
						}
						m_cboXStandardID.SelectedIndex = 0;
						return ;
					}
					catch {};
				}
			}
		}

		string m_strResult_Name;
		string m_strResult_CreatorID;
		string m_strResult_OrderFlag;
		string m_strResult_OrderTypeID;
		string m_strResult_DetailID;
		string m_strResult_UsageID;
		string m_strResult_FrequencyID;
		string m_strResult_ItemID;
		string m_strResult_ItemTypeID;
		string m_strResult_ItemStandardID;
		string m_strResult_ItemUnitID;
		string m_strResult_ItemDosage;

		private void m_cboXStandardID_Load(object sender, System.EventArgs e)
		{

		}

		private void m_cboXStandardID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_strResult_ItemStandardID = m_objPhysicianOrderMedicineStandardValueArr[ m_cboXStandardID.SelectedIndex ].m_strStandardID;
			m_strResult_ItemUnitID = m_objPhysicianOrderMedicineStandardValueArr[ m_cboXStandardID.SelectedIndex ].m_strUnitID;
			m_labXItemUnitID.Text = m_objPhysicianOrderMedicineStandardValueArr[ m_cboXStandardID.SelectedIndex ].m_strUnitName;
		}

		private void m_cboXUsageID_Load(object sender, System.EventArgs e)
		{
		
		}

		private void m_cboXUsageID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_strResult_UsageID = m_objPhysicianOrderUsageValueArr[ m_cboXUsageID.SelectedIndex ].m_strUsageID;
		}

		private void m_cboXFrequencyID_Load(object sender, System.EventArgs e)
		{

		}

		private void m_cboXFrequencyID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_strResult_FrequencyID = m_objPhysicianOrderFrequencyInfoValueArr[ m_cboXFrequencyID.SelectedIndex ].m_strFrequencyID;
		}

		private void m_mthFill_clsPhysicianOrderTemplateSetValueCase_withResult ( ref clsPhysicianOrderTemplateSetValueCase p_obj_POTSVC, int p_j, int p_k )
		{
			if ( ( p_obj_POTSVC == null ) || ( p_obj_POTSVC.objPhysicianOrderTemplateValueCaseArr[p_j] == null ) || ( p_obj_POTSVC.objPhysicianOrderTemplateValueCaseArr[p_j].objPhysicianOrderTemplateContentValueArr[p_k] == null ) )
				return ;
			//full fill temo obj
			p_obj_POTSVC.m_strCreatorID = MDIParent.OperatorID;
			p_obj_POTSVC.m_strName = m_strResult_Name;

			p_obj_POTSVC.objPhysicianOrderTemplateValueCaseArr[p_j].m_strOrderFlag = m_cboXOrderFlag.SelectedIndex.ToString();

			p_obj_POTSVC.objPhysicianOrderTemplateValueCaseArr[p_j].objPhysicianOrderTemplateContentValueArr[p_k].m_strOrderTypeID = m_strResult_OrderTypeID;
			p_obj_POTSVC.objPhysicianOrderTemplateValueCaseArr[p_j].objPhysicianOrderTemplateContentValueArr[p_k].m_strDetailID = m_strResult_DetailID;
			p_obj_POTSVC.objPhysicianOrderTemplateValueCaseArr[p_j].objPhysicianOrderTemplateContentValueArr[p_k].m_strUsageID = m_strResult_UsageID;
			p_obj_POTSVC.objPhysicianOrderTemplateValueCaseArr[p_j].objPhysicianOrderTemplateContentValueArr[p_k].m_strFrequencyID = m_strResult_FrequencyID;
			p_obj_POTSVC.objPhysicianOrderTemplateValueCaseArr[p_j].objPhysicianOrderTemplateContentValueArr[p_k].m_strItemID = m_strResult_ItemID;
			p_obj_POTSVC.objPhysicianOrderTemplateValueCaseArr[p_j].objPhysicianOrderTemplateContentValueArr[p_k].m_strItemTypeID = m_strResult_ItemTypeID;
			p_obj_POTSVC.objPhysicianOrderTemplateValueCaseArr[p_j].objPhysicianOrderTemplateContentValueArr[p_k].m_strItemStandardID = m_strResult_ItemStandardID;
			p_obj_POTSVC.objPhysicianOrderTemplateValueCaseArr[p_j].objPhysicianOrderTemplateContentValueArr[p_k].m_strItemUnitID = m_strResult_ItemUnitID;
			p_obj_POTSVC.objPhysicianOrderTemplateValueCaseArr[p_j].objPhysicianOrderTemplateContentValueArr[p_k].m_strItemDosage = m_strResult_ItemDosage;
		}

		private void m_trvPOTemplate_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if ( e.Node.Parent == null )
			{
				m_mthInitAllPhysicianOrderTemplateSet();
				return;
			}
			else 
			{
				m_lsvTemplateContent.Items.Clear();
				
				m_mthInit_m_obj_Lsv_RecordArr ( m_objTemp_PhysicianOrderTemplateSetValueCaseArr[ e.Node.Index ] );
				m_mthShow_TempResult_ONLsv ();

				m_strResult_Name = m_objTemp_PhysicianOrderTemplateSetValueCaseArr [ e.Node.Index ] .m_strName;
				m_txtName.Text = m_strResult_Name;
			}
		
		}

		private void m_mthInit_m_obj_Lsv_RecordArr ( clsPhysicianOrderTemplateSetValueCase p_objPOTSVC )
		{
			if ( p_objPOTSVC.objPhysicianOrderTemplateValueCaseArr == null )
				return;
			int count = 0;
			for ( int i = 0 ; i < p_objPOTSVC.objPhysicianOrderTemplateValueCaseArr .Length ; i ++ )
			{
				if ( p_objPOTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr != null )
				{
					count += p_objPOTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr.Length;
				}
			}
			m_obj_Lsv_RecordArr = new clsTempRecord[ count ];
			int step = 0 ;
			if ( p_objPOTSVC.objPhysicianOrderTemplateValueCaseArr != null )
			{
				for ( int i = 0 ; i < p_objPOTSVC.objPhysicianOrderTemplateValueCaseArr .Length ; i ++ )
				{
					if ( p_objPOTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr != null )
					{
						for ( int j = 0 ; j < p_objPOTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr.Length ; j ++ )
						{
							m_obj_Lsv_RecordArr[ step ] = new clsTempRecord();

							m_obj_Lsv_RecordArr[ step ].m_strSet_ID = p_objPOTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr[j].m_strSet_ID;
							m_obj_Lsv_RecordArr[ step ].m_strOrderID = p_objPOTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr[j].m_strOrderID;

							m_obj_Lsv_RecordArr[ step ].m_strOrderFlag = p_objPOTSVC.objPhysicianOrderTemplateValueCaseArr[i].m_strOrderFlag;

							m_obj_Lsv_RecordArr[ step ].m_strOrderTypeID = p_objPOTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr[j].m_strOrderTypeID;
							m_obj_Lsv_RecordArr[ step ].m_strDetailID = p_objPOTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr[j].m_strDetailID;
							m_obj_Lsv_RecordArr[ step ].m_strUsageID = p_objPOTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr[j].m_strUsageID;
							m_obj_Lsv_RecordArr[ step ].m_strFrequencyID = p_objPOTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr[j].m_strFrequencyID;
							m_obj_Lsv_RecordArr[ step ].m_strItemID = p_objPOTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr[j].m_strItemID;
							m_obj_Lsv_RecordArr[ step ].m_strItemTypeID = p_objPOTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr[j].m_strItemTypeID;
							m_obj_Lsv_RecordArr[ step ].m_strItemStandardID = p_objPOTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr[j].m_strItemStandardID;
							m_obj_Lsv_RecordArr[ step ].m_strItemUnitID = p_objPOTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr[j].m_strItemUnitID;
							m_obj_Lsv_RecordArr[ step ].m_strItemDosage = p_objPOTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr[j].m_strItemDosage;

							step ++;
						}
					}
				}
			}
		}

		private void m_mthShow_TempResult_ONLsv (  )
		{
            clsPhysicianOrderService objServ =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			m_lsvTemplateContent.Items.Clear();
			if ( m_obj_Lsv_RecordArr != null )
			{
				// mark the pre setid and orderid ;
				string strPreOrderID = "" ;
				string strPreSet_ID = "";

				for ( int i = 0 ; i < m_obj_Lsv_RecordArr.Length ; i ++ )
				{
					// fill gui ctrls
					string strOrderFlag = "";
					string strOrderTypeName = "";
					string strUsageName = "";
					string strFrequencyName = "";
					string strItemName = "";
					string strItemTypeName = "";
					string strItemStandardName = "";
					string strItemUnitName = "";
					string strItemDosage = "";
					//set the child identifier
					string strIfChild = " ";
					if ( m_obj_Lsv_RecordArr[i].m_strSet_ID == strPreSet_ID  &&  m_obj_Lsv_RecordArr[i].m_strOrderID == strPreOrderID )
					{
						strIfChild = "|";
					}
					else 
					{
						strIfChild = " ";
					}
					strPreSet_ID = m_obj_Lsv_RecordArr[i].m_strSet_ID;
					strPreOrderID = m_obj_Lsv_RecordArr[i].m_strOrderID;

					// orderflag
					if ( m_obj_Lsv_RecordArr[i].m_strOrderFlag == "0" )	
						strOrderFlag = "临";
					else
						strOrderFlag = "长";
					// ordertype
					for ( int j = 0 ; j < m_objPhysicianOrderTypeValueArr.Length ; j ++ )
					{
						if ( m_obj_Lsv_RecordArr[i].m_strOrderTypeID ==  m_objPhysicianOrderTypeValueArr[j].m_strOrderTypeID )
						{
							strOrderTypeName = m_objPhysicianOrderTypeValueArr[j].m_strOrderTypeName ;
							break;
						}
					}

					if ( m_obj_Lsv_RecordArr[i].m_strOrderTypeID != "007" )// if isnt 药
					{
                        objServ.m_lngGetPhysicianOrderTypeDetail(m_obj_Lsv_RecordArr[i].m_strOrderTypeID, out m_objPhysicianOrderTypeDetailValueArr);
						for ( int j = 0 ; j < m_objPhysicianOrderTypeDetailValueArr.Length ; j ++ )
						{
							if ( m_obj_Lsv_RecordArr[i].m_strDetailID == m_objPhysicianOrderTypeDetailValueArr[j].m_strDetailID )
							{
								strItemName = m_objPhysicianOrderTypeDetailValueArr[j].m_strDetailName;
								break;
							}
						}
					}

					if ( m_obj_Lsv_RecordArr[i].m_strOrderTypeID == "007" )// if 药
					{
						// set ItemID and name
                        objServ.m_lngGetMedicineNameByMedicineID("", out m_objPhysicianOrderMedicineNameValueArr);
						for ( int j = 0 ; j < m_objPhysicianOrderMedicineNameValueArr.Length ; j ++ )
						{
							if ( m_obj_Lsv_RecordArr[i].m_strItemID == m_objPhysicianOrderMedicineNameValueArr[j].m_strMedicineID )
							{
								strItemName = m_objPhysicianOrderMedicineNameValueArr[j].m_strMedicineName;
								break;
							}
						}
						// set ItemTypeID and name
                        objServ.m_lngGetMedicineType(m_obj_Lsv_RecordArr[i].m_strItemID, out m_objPhysicianOrderMedicineTypeValueArr);
						for ( int j = 0 ; j < m_objPhysicianOrderMedicineTypeValueArr.Length ; j ++ )
						{
							if ( m_obj_Lsv_RecordArr[i].m_strItemTypeID == m_objPhysicianOrderMedicineTypeValueArr[j].m_strMedicineOfTypeID )
							{
								strItemTypeName = m_objPhysicianOrderMedicineTypeValueArr[j].m_strMedicineOfTypeName;
								break;
							}
						}
						// set StandardID and UnitID
						objServ.m_lngGetMedicineStandard( m_obj_Lsv_RecordArr[i].m_strItemID, m_obj_Lsv_RecordArr[i].m_strItemTypeID, out  m_objPhysicianOrderMedicineStandardValueArr );
						for ( int j = 0 ; j < m_objPhysicianOrderMedicineStandardValueArr.Length ; j ++ )
						{
							if ( m_obj_Lsv_RecordArr[i].m_strItemStandardID == m_objPhysicianOrderMedicineStandardValueArr[j].m_strStandardID )
							{
								strItemStandardName = m_objPhysicianOrderMedicineStandardValueArr[j].m_strStandardName;
								strItemUnitName = m_objPhysicianOrderMedicineStandardValueArr[j].m_strUnitName;
								break;
							}
						}

						// set UsageID
						for ( int j = 0 ; j < m_objPhysicianOrderUsageValueArr.Length ; j ++ )
						{
							if ( m_obj_Lsv_RecordArr[i].m_strUsageID == m_objPhysicianOrderUsageValueArr[j].m_strUsageID ) 
							{
								strUsageName = m_objPhysicianOrderUsageValueArr[j].m_strUsageName;
								break;
							}
						}

						// init m_cboXFrequencyID and m_objPhysicianOrderFrequencyInfoValueArr
						for ( int j = 0 ; j < m_objPhysicianOrderFrequencyInfoValueArr.Length ; j ++ )
						{
							if ( m_obj_Lsv_RecordArr[i].m_strFrequencyID == m_objPhysicianOrderFrequencyInfoValueArr[j].m_strFrequencyID )
							{
								strFrequencyName = m_objPhysicianOrderFrequencyInfoValueArr[j].m_strFrequencyName;
								break;
							}
						}

						// set ItemDosage 
						strItemDosage = m_obj_Lsv_RecordArr[i].m_strItemDosage;
					}

					m_lsvTemplateContent.Items.Add( new ListViewItem ( new string[] { strOrderTypeName, strItemName, strItemTypeName, strItemStandardName, strItemDosage, strItemUnitName, strUsageName, strFrequencyName, strOrderFlag, strIfChild } ) );
				}
			}
		}

		private void m_lsvTemplateContent_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
		
		}

		private void m_lsvTemplateContent_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( m_lsvTemplateContent.SelectedIndices.Count == 0 )
				return ;

            clsPhysicianOrderService objServ =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			// fill m_strResult_
			if ( m_obj_Lsv_RecordArr == null )
				return ;
			m_strResult_OrderFlag = m_obj_Lsv_RecordArr[ m_lsvTemplateContent.SelectedIndices[0] ].m_strOrderFlag;
			m_strResult_OrderTypeID =  m_obj_Lsv_RecordArr[ m_lsvTemplateContent.SelectedIndices[0] ].m_strOrderTypeID;
			m_strResult_DetailID = m_obj_Lsv_RecordArr[ m_lsvTemplateContent.SelectedIndices[0] ].m_strDetailID;
			m_strResult_UsageID = m_obj_Lsv_RecordArr[ m_lsvTemplateContent.SelectedIndices[0] ].m_strUsageID;
			m_strResult_FrequencyID = m_obj_Lsv_RecordArr[ m_lsvTemplateContent.SelectedIndices[0] ].m_strFrequencyID;
			m_strResult_ItemID = m_obj_Lsv_RecordArr[ m_lsvTemplateContent.SelectedIndices[0] ].m_strItemID;
			m_strResult_ItemTypeID = m_obj_Lsv_RecordArr[ m_lsvTemplateContent.SelectedIndices[0] ].m_strItemTypeID;
			m_strResult_ItemStandardID = m_obj_Lsv_RecordArr[ m_lsvTemplateContent.SelectedIndices[0] ].m_strItemStandardID;
			m_strResult_ItemUnitID = m_obj_Lsv_RecordArr[ m_lsvTemplateContent.SelectedIndices[0] ].m_strItemUnitID;
			m_strResult_ItemDosage = m_obj_Lsv_RecordArr[ m_lsvTemplateContent.SelectedIndices[0] ].m_strItemDosage;
	
			// fill gui ctrls
			m_txtName.Text = m_strResult_Name;

			if ( m_strResult_OrderFlag == "0" )	
				m_cboXOrderFlag.SelectedIndex = 0;
			else
				m_cboXOrderFlag.SelectedIndex = 1;

			for ( int i = 0 ; i < m_objPhysicianOrderTypeValueArr.Length ; i ++ )
			{
				if ( m_strResult_OrderTypeID ==  m_objPhysicianOrderTypeValueArr[i].m_strOrderTypeID )
				{
					m_cboXOrderTypeID.SelectedIndex = i ;
					break;
				}
			}

			if ( m_cboXOrderTypeID.SelectedIndex != 6 )// if isnt 药
			{
                objServ.m_lngGetPhysicianOrderTypeDetail(m_strResult_OrderTypeID, out m_objPhysicianOrderTypeDetailValueArr);
				for ( int i = 0 ; i < m_objPhysicianOrderTypeDetailValueArr.Length ; i ++ )
				{
					if ( m_strResult_DetailID == m_objPhysicianOrderTypeDetailValueArr[i].m_strDetailID )
					{
						m_labName.Text = m_objPhysicianOrderTypeDetailValueArr[i].m_strDetailName;
						break;
					}
				}
			}

			if ( m_cboXOrderTypeID.SelectedIndex == 6 )// if 药
			{
				// set ItemID and name
                objServ.m_lngGetMedicineNameByMedicineID("", out m_objPhysicianOrderMedicineNameValueArr);
				for ( int i = 0 ; i < m_objPhysicianOrderMedicineNameValueArr.Length ; i ++ )
				{
					if ( m_strResult_ItemID == m_objPhysicianOrderMedicineNameValueArr[i].m_strMedicineID )
					{
						m_labName.Text = m_objPhysicianOrderMedicineNameValueArr[i].m_strMedicineName;
						break;
					}
				}
				// set ItemTypeID and name
                objServ.m_lngGetMedicineType(m_strResult_ItemID, out m_objPhysicianOrderMedicineTypeValueArr);
				for ( int i = 0 ; i < m_objPhysicianOrderMedicineTypeValueArr.Length ; i ++ )
				{
					if ( m_strResult_ItemTypeID == m_objPhysicianOrderMedicineTypeValueArr[i].m_strMedicineOfTypeID )
					{
						m_labType.Text = m_objPhysicianOrderMedicineTypeValueArr[i].m_strMedicineOfTypeName;
						break;
					}
				}
				// set StandardID and UnitID
                objServ.m_lngGetMedicineStandard(m_strResult_ItemID, m_strResult_ItemTypeID, out  m_objPhysicianOrderMedicineStandardValueArr);
				for ( int i = 0 ; i < m_objPhysicianOrderMedicineStandardValueArr.Length ; i ++ )
				{
					m_cboXStandardID.AddItem( m_objPhysicianOrderMedicineStandardValueArr[i].m_strStandardName);
				}
				for ( int i = 0 ; i < m_objPhysicianOrderMedicineStandardValueArr.Length ; i ++ )
				{
					if ( m_strResult_ItemStandardID == m_objPhysicianOrderMedicineStandardValueArr[i].m_strStandardID )
					{
						m_cboXStandardID.SelectedIndex = i ;
						m_labXItemUnitID.Text = m_objPhysicianOrderMedicineStandardValueArr[i].m_strUnitName;
						break;
					}
				}
				// set UsageID
				for ( int i = 0 ; i < m_objPhysicianOrderUsageValueArr.Length ; i ++ )
				{
					if ( m_strResult_UsageID == m_objPhysicianOrderUsageValueArr[i].m_strUsageID ) 
					{
						m_cboXUsageID.SelectedIndex = i ;
						break;
					}
				}

				// init m_cboXFrequencyID and m_objPhysicianOrderFrequencyInfoValueArr
				for ( int i = 0 ; i < m_objPhysicianOrderFrequencyInfoValueArr.Length ; i ++ )
				{
					if ( m_strResult_FrequencyID == m_objPhysicianOrderFrequencyInfoValueArr[i].m_strFrequencyID )
					{
						m_cboXFrequencyID.SelectedIndex = i;
						break;
					}
				}

				// set ItemDosage 
				m_txtDosage.Text = m_strResult_ItemDosage;
			}
		}

		
		private void m_cboXOrderFlag_Load(object sender, System.EventArgs e)
		{
			
		}

		private void m_cboXOrderTypeID_Load(object sender, System.EventArgs e)
		{
			
		}

		private void m_txtName_TextChanged(object sender, System.EventArgs e)
		{
			m_strResult_Name = m_txtName.Text;
		}

		private void m_cmdDeleteTemplate_Click(object sender, System.EventArgs e)
		{
            clsPhysicianOrderService objServ =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			if ( m_trvPOTemplate.SelectedNode.Parent == null )
			{
                objServ.m_lngDeletePhysicianOrderTemplateSetCase(m_objTemp_PhysicianOrderTemplateSetValueCaseArr[m_trvPOTemplate.SelectedNode.Index]);
				m_mthInitAllPhysicianOrderTemplateSet();
				return;
			}
			if ( m_trvPOTemplate.SelectedNode.Parent != null )
			{
				if ( ( m_trvPOTemplate.SelectedNode.Index == 0 ) && ( m_trvPOTemplate.SelectedNode.NextNode == null ) )
				{
                    objServ.m_lngDeletePhysicianOrderTemplateSetCase(m_objTemp_PhysicianOrderTemplateSetValueCaseArr[m_trvPOTemplate.SelectedNode.Index]);
					m_mthInitAllPhysicianOrderTemplateSet();
					return;
				}

				for ( int i = m_trvPOTemplate.SelectedNode.Index ; i < m_objTemp_PhysicianOrderTemplateSetValueCaseArr[ m_trvPOTemplate.SelectedNode.Parent.Index ].objPhysicianOrderTemplateValueCaseArr.Length - 1 ; i ++ )
				{
					m_objTemp_PhysicianOrderTemplateSetValueCaseArr[ m_trvPOTemplate.SelectedNode.Parent.Index ].objPhysicianOrderTemplateValueCaseArr[ i ] = m_objTemp_PhysicianOrderTemplateSetValueCaseArr[ m_trvPOTemplate.SelectedNode.Parent.Index ].objPhysicianOrderTemplateValueCaseArr[ i+1 ];
				}
                objServ.m_lngUpdatePhysicianOrderTemplateSetCase(m_objTemp_PhysicianOrderTemplateSetValueCaseArr[m_trvPOTemplate.SelectedNode.Parent.Index]);
				m_mthInitAllPhysicianOrderTemplateSet();
			}
		}

		private void m_cmdUpdateTemplate_Click(object sender, System.EventArgs e)
		{
			if ( m_trvPOTemplate.SelectedNode.Parent == null )
				return;
			// fill all value of result_
			m_objTemp_PhysicianOrderTemplateSetValueCaseArr[ m_trvPOTemplate.SelectedNode.Parent.Index ].m_strName = m_strResult_Name;
			m_objTemp_PhysicianOrderTemplateSetValueCaseArr[ m_trvPOTemplate.SelectedNode.Parent.Index ].objPhysicianOrderTemplateValueCaseArr[ m_trvPOTemplate.SelectedNode.Index ].m_strOrderFlag = m_strResult_OrderFlag;
			m_objTemp_PhysicianOrderTemplateSetValueCaseArr[ m_trvPOTemplate.SelectedNode.Parent.Index ].objPhysicianOrderTemplateValueCaseArr[ m_trvPOTemplate.SelectedNode.Index ].objPhysicianOrderTemplateContentValueArr[ m_lsvTemplateContent.SelectedIndices[0] ].m_strOrderTypeID = m_strResult_OrderTypeID;
			m_objTemp_PhysicianOrderTemplateSetValueCaseArr[ m_trvPOTemplate.SelectedNode.Parent.Index ].objPhysicianOrderTemplateValueCaseArr[ m_trvPOTemplate.SelectedNode.Index ].objPhysicianOrderTemplateContentValueArr[ m_lsvTemplateContent.SelectedIndices[0] ].m_strDetailID = m_strResult_DetailID;
			m_objTemp_PhysicianOrderTemplateSetValueCaseArr[ m_trvPOTemplate.SelectedNode.Parent.Index ].objPhysicianOrderTemplateValueCaseArr[ m_trvPOTemplate.SelectedNode.Index ].objPhysicianOrderTemplateContentValueArr[ m_lsvTemplateContent.SelectedIndices[0] ].m_strUsageID = m_strResult_UsageID;
			m_objTemp_PhysicianOrderTemplateSetValueCaseArr[ m_trvPOTemplate.SelectedNode.Parent.Index ].objPhysicianOrderTemplateValueCaseArr[ m_trvPOTemplate.SelectedNode.Index ].objPhysicianOrderTemplateContentValueArr[ m_lsvTemplateContent.SelectedIndices[0] ].m_strFrequencyID = m_strResult_FrequencyID;
			m_objTemp_PhysicianOrderTemplateSetValueCaseArr[ m_trvPOTemplate.SelectedNode.Parent.Index ].objPhysicianOrderTemplateValueCaseArr[ m_trvPOTemplate.SelectedNode.Index ].objPhysicianOrderTemplateContentValueArr[ m_lsvTemplateContent.SelectedIndices[0] ].m_strItemID = m_strResult_ItemID;
			m_objTemp_PhysicianOrderTemplateSetValueCaseArr[ m_trvPOTemplate.SelectedNode.Parent.Index ].objPhysicianOrderTemplateValueCaseArr[ m_trvPOTemplate.SelectedNode.Index ].objPhysicianOrderTemplateContentValueArr[ m_lsvTemplateContent.SelectedIndices[0] ].m_strItemTypeID = m_strResult_ItemTypeID;
			m_objTemp_PhysicianOrderTemplateSetValueCaseArr[ m_trvPOTemplate.SelectedNode.Parent.Index ].objPhysicianOrderTemplateValueCaseArr[ m_trvPOTemplate.SelectedNode.Index ].objPhysicianOrderTemplateContentValueArr[ m_lsvTemplateContent.SelectedIndices[0] ].m_strItemStandardID = m_strResult_ItemStandardID;
			m_objTemp_PhysicianOrderTemplateSetValueCaseArr[ m_trvPOTemplate.SelectedNode.Parent.Index ].objPhysicianOrderTemplateValueCaseArr[ m_trvPOTemplate.SelectedNode.Index ].objPhysicianOrderTemplateContentValueArr[ m_lsvTemplateContent.SelectedIndices[0] ].m_strItemUnitID = m_strResult_ItemUnitID;
			m_objTemp_PhysicianOrderTemplateSetValueCaseArr[ m_trvPOTemplate.SelectedNode.Parent.Index ].objPhysicianOrderTemplateValueCaseArr[ m_trvPOTemplate.SelectedNode.Index ].objPhysicianOrderTemplateContentValueArr[ m_lsvTemplateContent.SelectedIndices[0] ].m_strItemDosage = m_strResult_ItemDosage;
			// update to db
            clsPhysicianOrderService objServ =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

            objServ.m_lngUpdatePhysicianOrderTemplateSetCase(m_objTemp_PhysicianOrderTemplateSetValueCaseArr[m_trvPOTemplate.SelectedNode.Parent.Index]);
		}

		private void m_cboXOrderFlag_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( m_cboXOrderFlag.SelectedIndex == 0 )
				m_strResult_OrderFlag = ((int) 0).ToString();
			if ( m_cboXOrderFlag.SelectedIndex == 1 )
				m_strResult_OrderFlag = ((int) 1).ToString();
		}

		private void m_cmdAlterTempRecord_Click(object sender, System.EventArgs e)
		{
			m_obj_Lsv_RecordArr[ m_lsvTemplateContent.SelectedItems[0].Index ].m_strOrderFlag = m_strResult_OrderFlag;
			m_obj_Lsv_RecordArr[ m_lsvTemplateContent.SelectedItems[0].Index ].m_strOrderTypeID = m_strResult_OrderTypeID;
			m_obj_Lsv_RecordArr[ m_lsvTemplateContent.SelectedItems[0].Index ].m_strDetailID = m_strResult_DetailID;
			m_obj_Lsv_RecordArr[ m_lsvTemplateContent.SelectedItems[0].Index ].m_strUsageID = m_strResult_UsageID;
			m_obj_Lsv_RecordArr[ m_lsvTemplateContent.SelectedItems[0].Index ].m_strFrequencyID = m_strResult_FrequencyID;
			m_obj_Lsv_RecordArr[ m_lsvTemplateContent.SelectedItems[0].Index ].m_strItemID = m_strResult_ItemID;
			m_obj_Lsv_RecordArr[ m_lsvTemplateContent.SelectedItems[0].Index ].m_strItemTypeID = m_strResult_ItemTypeID;
			m_obj_Lsv_RecordArr[ m_lsvTemplateContent.SelectedItems[0].Index ].m_strItemStandardID = m_strResult_ItemStandardID;
			m_obj_Lsv_RecordArr[ m_lsvTemplateContent.SelectedItems[0].Index ].m_strItemUnitID = m_strResult_ItemUnitID;
			m_obj_Lsv_RecordArr[ m_lsvTemplateContent.SelectedItems[0].Index ].m_strItemDosage = m_strResult_ItemDosage;
			m_mthShow_TempResult_ONLsv ();
		}

		private void m_cmdAddTempRecord_Click(object sender, System.EventArgs e)
		{
			if ( ( m_trvPOTemplate.SelectedNode == null ) || ( ( m_obj_Lsv_RecordArr == null ) && ( m_trvPOTemplate.SelectedNode.Parent == null ) ) || ( m_obj_Lsv_RecordArr == null ) && ( m_trvPOTemplate.SelectedNode == null ) )
			{
				clsPhysicianOrderTemplateSetValueCase temp =  new clsPhysicianOrderTemplateSetValueCase();
				temp.objPhysicianOrderTemplateValueCaseArr = new clsPhysicianOrderTemplateValueCase[1];
				temp.objPhysicianOrderTemplateValueCaseArr[0] = new clsPhysicianOrderTemplateValueCase();
				temp.objPhysicianOrderTemplateValueCaseArr[0].objPhysicianOrderTemplateContentValueArr = new clsPhysicianOrderTemplateContentValue[1];
				temp.objPhysicianOrderTemplateValueCaseArr[0].objPhysicianOrderTemplateContentValueArr[0] = new clsPhysicianOrderTemplateContentValue();

				// ok go to work now 
				temp.m_strCreatorID = MDIParent.OperatorID;

				temp.m_strName = m_strResult_Name;
				temp.objPhysicianOrderTemplateValueCaseArr[0].m_strOrderFlag = m_strResult_OrderFlag;
				
				temp.objPhysicianOrderTemplateValueCaseArr[0].objPhysicianOrderTemplateContentValueArr[0].m_strOrderTypeID = m_strResult_OrderTypeID;
				temp.objPhysicianOrderTemplateValueCaseArr[0].objPhysicianOrderTemplateContentValueArr[0].m_strDetailID = m_strResult_DetailID;
				temp.objPhysicianOrderTemplateValueCaseArr[0].objPhysicianOrderTemplateContentValueArr[0].m_strUsageID = m_strResult_UsageID;
				temp.objPhysicianOrderTemplateValueCaseArr[0].objPhysicianOrderTemplateContentValueArr[0].m_strFrequencyID = m_strResult_FrequencyID;
				temp.objPhysicianOrderTemplateValueCaseArr[0].objPhysicianOrderTemplateContentValueArr[0].m_strItemID = m_strResult_ItemID;
				temp.objPhysicianOrderTemplateValueCaseArr[0].objPhysicianOrderTemplateContentValueArr[0].m_strItemTypeID = m_strResult_ItemTypeID;
				temp.objPhysicianOrderTemplateValueCaseArr[0].objPhysicianOrderTemplateContentValueArr[0].m_strItemStandardID = m_strResult_ItemStandardID;
				temp.objPhysicianOrderTemplateValueCaseArr[0].objPhysicianOrderTemplateContentValueArr[0].m_strItemUnitID = m_strResult_ItemUnitID;
				temp.objPhysicianOrderTemplateValueCaseArr[0].objPhysicianOrderTemplateContentValueArr[0].m_strItemDosage = m_strResult_ItemDosage;

                clsPhysicianOrderService objServ =
                    (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

                objServ.m_lngAddPhysicianOrderTemplateSetCase(temp);

				m_mthInitAllPhysicianOrderTemplateSet();
				m_trvPOTemplate.SelectedNode = m_trvPOTemplate.Nodes[0];
				return;
			}
			if ( m_obj_Lsv_RecordArr != null )
			{

				if ( m_chkBeChild.Checked == false ) 
				{
					clsTempRecord[] temp = new clsTempRecord[m_obj_Lsv_RecordArr.Length+1];
					for ( int i = 0 ; i < m_obj_Lsv_RecordArr.Length ; i ++ )
					{
						temp[ i ] = new clsTempRecord();
						// copy value
						temp[ i ] = m_obj_Lsv_RecordArr[ i ];
				
					}
					// new and fill value 
					temp[ temp.Length-1 ] = new clsTempRecord();
					// we supposed the problem is solved 
					temp[ temp.Length-1 ].m_strSet_ID = temp[ temp.Length-2 ].m_strSet_ID;
					temp[ temp.Length-1 ].m_strOrderID = ( (int)(int.Parse ( temp[ temp.Length-2 ].m_strOrderID ) + 1) ).ToString();
					//
					temp[ temp.Length-1 ].m_strOrderFlag = m_strResult_OrderFlag;
					temp[ temp.Length-1 ].m_strOrderTypeID = m_strResult_OrderTypeID;
					temp[ temp.Length-1 ].m_strDetailID = m_strResult_DetailID;
					temp[ temp.Length-1 ].m_strUsageID = m_strResult_UsageID;
					temp[ temp.Length-1 ].m_strFrequencyID = m_strResult_FrequencyID;
					temp[ temp.Length-1 ].m_strItemID = m_strResult_ItemID;
					temp[ temp.Length-1 ].m_strItemTypeID = m_strResult_ItemTypeID;
					temp[ temp.Length-1 ].m_strItemStandardID = m_strResult_ItemStandardID;
					temp[ temp.Length-1 ].m_strItemUnitID = m_strResult_ItemUnitID;
					temp[ temp.Length-1 ].m_strItemDosage = m_strResult_ItemDosage;

					m_obj_Lsv_RecordArr = temp;

					m_mthShow_TempResult_ONLsv();

					m_labName.Text = "";
					m_labType.Text = "";
					return;
				}
				else 
				{
					if ( ( m_lsvTemplateContent.SelectedIndices == null ) || ( m_lsvTemplateContent.SelectedIndices.Count == 0 ) )
					{
						return;
					}
					int selected = m_lsvTemplateContent.SelectedIndices[0] ; 
					clsTempRecord[] temp = new clsTempRecord[m_obj_Lsv_RecordArr.Length+1];
					for ( int i = 0 ; i < temp.Length ; i ++ )
					{
						temp[i] = new clsTempRecord();
					}
					for ( int i = 0 ; i <= selected ; i ++ )
					{
						temp[ i ] = m_obj_Lsv_RecordArr [ i ];
					}
					// set the new value
					//set the set_id orderId and subOrderId
					temp[ selected+1 ].m_strSet_ID = temp[ selected ].m_strSet_ID;
					temp[ selected+1 ].m_strOrderID = temp[ selected ].m_strOrderID;
				
					// now the normal value
					temp[ selected+1 ].m_strOrderFlag = m_strResult_OrderFlag;
					temp[ selected+1 ].m_strOrderTypeID = m_strResult_OrderTypeID;
					temp[ selected+1 ].m_strDetailID = m_strResult_DetailID;
					temp[ selected+1 ].m_strUsageID = m_strResult_UsageID;
					temp[ selected+1 ].m_strFrequencyID = m_strResult_FrequencyID;
					temp[ selected+1 ].m_strItemID = m_strResult_ItemID;
					temp[ selected+1 ].m_strItemTypeID = m_strResult_ItemTypeID;
					temp[ selected+1 ].m_strItemStandardID = m_strResult_ItemStandardID;
					temp[ selected+1 ].m_strItemUnitID = m_strResult_ItemUnitID;
					temp[ selected+1 ].m_strItemDosage = m_strResult_ItemDosage;
					// and the leave value
					for ( int i = selected + 2 ; i < temp.Length ; i ++ )
					{
						temp [ i ] = m_obj_Lsv_RecordArr [ i - 1 ];
					}

					m_obj_Lsv_RecordArr = temp;

					m_mthShow_TempResult_ONLsv();

					m_labName.Text = "";
					m_labType.Text = "";
					return;
				}
			}
		}

		private void m_lsvTemplateContent_DoubleClick(object sender, System.EventArgs e)
		{
			m_mthDeleteSelectedTempRecord();
		}

		private void m_mthDeleteSelectedTempRecord ()
		{
			if ( m_obj_Lsv_RecordArr == null )
				return ;
			clsTempRecord[] temp = new clsTempRecord[m_obj_Lsv_RecordArr.Length-1];
			for ( int i = 0 ; i < temp.Length ; i ++ )
			{
				temp[i] = new clsTempRecord();
			}
			if ( m_lsvTemplateContent.SelectedIndices.Count == 0 )
				return ;
			int selected = m_lsvTemplateContent.SelectedIndices[0] ; 
			for ( int i = 0 ; i < selected ; i ++ )
			{
				temp[i] = m_obj_Lsv_RecordArr[i];
			}
			for ( int i = selected ; i < temp.Length ; i ++ )
			{
				temp[i] = m_obj_Lsv_RecordArr[i+1];
			}
			
			m_obj_Lsv_RecordArr = temp;

			m_mthShow_TempResult_ONLsv();
		}

		private void m_txtDosage_TextChanged(object sender, System.EventArgs e)
		{
			m_strResult_ItemDosage = m_txtDosage.Text;
		}

		private void m_cmdDeltteTemp_Click(object sender, System.EventArgs e)
		{
			if ( ( m_trvPOTemplate.SelectedNode != null ) && ( m_trvPOTemplate.SelectedNode.Parent != null ) )
			{
				if ( m_objTemp_PhysicianOrderTemplateSetValueCaseArr == null )
					return;

                clsPhysicianOrderService objServ =
                    (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

                objServ.m_lngDeletePhysicianOrderTemplateSetCase(m_objTemp_PhysicianOrderTemplateSetValueCaseArr[m_trvPOTemplate.SelectedNode.Index]);
				m_mthInitAllPhysicianOrderTemplateSet();
			}
		}

		private void m_cmdApplyToTemp_Click(object sender, System.EventArgs e)
		{
			
			// update the database
			if ( ( m_trvPOTemplate.SelectedNode != null ) && ( m_trvPOTemplate.SelectedNode.Parent != null ) )
			{
				clsPhysicianOrderTemplateSetValueCase temp = new clsPhysicianOrderTemplateSetValueCase();
				temp.m_strSet_ID = m_objTemp_PhysicianOrderTemplateSetValueCaseArr[ m_trvPOTemplate.SelectedNode.Index ].m_strSet_ID;
				temp.m_strName = m_objTemp_PhysicianOrderTemplateSetValueCaseArr[ m_trvPOTemplate.SelectedNode.Index ].m_strName;

				m_mthParse_clsTempRecord_To_clsPhysicianOrderTemplateSetValueCase( m_obj_Lsv_RecordArr, ref temp );

                clsPhysicianOrderService objServ =
                    (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

                objServ.m_lngUpdatePhysicianOrderTemplateSetCase(temp);

				m_mthInitAllPhysicianOrderTemplateSet();
				return;
			}
		}

		private void m_mthParse_clsTempRecord_To_clsPhysicianOrderTemplateSetValueCase ( clsTempRecord[] p_objTempRecordArr, ref clsPhysicianOrderTemplateSetValueCase p_POTSVC )
		{
			if ( ( p_objTempRecordArr == null ) || ( p_objTempRecordArr.Length == 0 ) )
				return;

			// we set and get extent for eacy templatevalue
			int intTemplate_Count = p_objTempRecordArr.Length ;
			for ( int i = 1 ; i < p_objTempRecordArr.Length ; i ++ )
			{
				if ( p_objTempRecordArr[i].m_strOrderID == p_objTempRecordArr[i-1].m_strOrderID )
				{
					intTemplate_Count -- ;
				}
			}
			
			struExtent[] extent = new struExtent[ intTemplate_Count ];
			for ( int i = 0 ; i < extent.Length ; i ++ )
			{
				extent[i] = new struExtent();
			}
			extent[0].i = 0;
			int extentIndex = 1;
			for ( int i = 1 ; i < p_objTempRecordArr.Length ; i ++ )
			{
				if ( p_objTempRecordArr[i].m_strOrderID != p_objTempRecordArr[i-1].m_strOrderID )
				{
					extent[ extentIndex++ ].i = i;
				}
			}

			int extentCount = 0;
			for ( int i = 0 ; i < extent.Length-1 ; i ++ )
			{
				extent[i].j = extent[i+1].i - extent[i].i;
				extentCount += extent[i+1].i - extent[i].i;
			}
			extent[ extent.Length-1 ].j = p_objTempRecordArr.Length - extentCount;
			//

			// fill p_POTSVC now
			int tempRecordIndex = 0;
			p_POTSVC.objPhysicianOrderTemplateValueCaseArr = new clsPhysicianOrderTemplateValueCase[ extent.Length ] ;
			for ( int i = 0 ; i < p_POTSVC.objPhysicianOrderTemplateValueCaseArr.Length ; i ++ )
			{
				p_POTSVC.objPhysicianOrderTemplateValueCaseArr[i] = new clsPhysicianOrderTemplateValueCase();
				// fill values
				p_POTSVC.objPhysicianOrderTemplateValueCaseArr[i].m_strOrderFlag = p_objTempRecordArr[ tempRecordIndex ].m_strOrderFlag;

				p_POTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr = new clsPhysicianOrderTemplateContentValue[ extent[i].j ];
				for ( int j = 0 ; j < extent[i].j ; j ++ )
				{
					p_POTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr[j] = new clsPhysicianOrderTemplateContentValue();
					//fill values
					p_POTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr[j].m_strOrderTypeID = p_objTempRecordArr[ tempRecordIndex ].m_strOrderTypeID;
					p_POTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr[j].m_strDetailID = p_objTempRecordArr[ tempRecordIndex ].m_strDetailID;
					p_POTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr[j].m_strUsageID = p_objTempRecordArr[ tempRecordIndex ].m_strUsageID;
					p_POTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr[j].m_strFrequencyID = p_objTempRecordArr[ tempRecordIndex ].m_strFrequencyID;
					p_POTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr[j].m_strItemID = p_objTempRecordArr[ tempRecordIndex ].m_strItemID;
					p_POTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr[j].m_strItemTypeID = p_objTempRecordArr[ tempRecordIndex ].m_strItemTypeID;
					p_POTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr[j].m_strItemStandardID = p_objTempRecordArr[ tempRecordIndex ].m_strItemStandardID;
					p_POTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr[j].m_strItemUnitID = p_objTempRecordArr[ tempRecordIndex ].m_strItemUnitID;
					p_POTSVC.objPhysicianOrderTemplateValueCaseArr[i].objPhysicianOrderTemplateContentValueArr[j].m_strItemDosage = p_objTempRecordArr[ tempRecordIndex ].m_strItemDosage;
					// tempRecordIndex up now
					tempRecordIndex++;
				}
			}

			
		}

		private void label19_Click(object sender, System.EventArgs e)
		{
		
		}



		#region Commented
		//		private class cslPhysicianOrderListRow
		//		{
		//			
		//
		////			private const int c_intBeginDate=0;
		////			private const int c_intPhysicianOrderName=1;
		////			private const int c_intDosage
		//
		//
		//			private ListViewItem m_objLsvItem=null;
		//			private int m_intColumnNumber=1;
		//			public int m_IntColumnNumber
		//			{
		//				get
		//				{
		//					return m_intColumnNumber;
		//				}
		//			}
		//			
		//			cslPhysicianOrderListRow(int p_intColumnNumber)
		//			{
		//				if(p_intColumnNumber<=0) m_intColumnNumber=1;
		//				else m_intColumnNumber=p_intColumnNumber;
		//				m_objLsvItem=new ListViewItem(m_strGetInitStringArr());
		//			}
		//
		//			cslPhysicianOrderListRow(string p_strText,int p_intColumnNumber)
		//			{
		//				if(p_intColumnNumber<=0) m_intColumnNumber=1;
		//				else m_intColumnNumber=p_intColumnNumber;
		//				if(p_strText==null)
		//				{
		//					m_objLsvItem=new ListViewItem(m_strGetInitStringArr());
		//				}
		//				else
		//				{
		//					m_objLsvItem=new ListViewItem(m_strGetInitStringArr());
		//					m_objLsvItem.Text=p_strText;
		//				}
		//			}
		//
		//			cslPhysicianOrderListRow(ListViewItem p_objLsvItem)
		//			{
		//				if(p_objLsvItem!=null)
		//				{
		//					m_objLsvItem=p_objLsvItem;
		//					m_intColumnNumber=m_objLsvItem.SubItems.Count;
		//				}
		//
		//			}
		//
		//			private string[] m_strGetInitStringArr()
		//			{
		//				string[] str=new string[m_intColumnNumber];
		//				for(int i=0;i<m_intColumnNumber;i++)
		//				{
		//					str[i]="";
		//				}
		//				return str;
		//			}
		//
		//			private DateTime m_dtmStartDate;
		//			public DateTime m_DtmStartDate
		//			{
		//				get
		//				{
		//					return m_dtmStartDate;
		//				}
		//				set
		//				{
		//					m_dtmStartDate=value;
		//					
		//				}
		//			}
		//
		//			
		//			
		//			
		//		}

		#endregion
	}
	
	public class cls3Ident
	{
		public cls3Ident()
		{
			i = j = k = -1;
		}
		public int i , j , k ;
	}

	public class struExtent
	{
		public int i = 0 ; 
		public int j = 1 ;
	}
}

