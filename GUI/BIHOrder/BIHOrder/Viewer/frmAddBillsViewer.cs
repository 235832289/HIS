using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

using com.digitalwave.iCare.middletier.BIHOrderServer;

using System.Data;

namespace com.digitalwave.iCare.BIHOrder
{
	/// <summary>
	/// frmAddBillsViewer 的摘要说明。
	/// </summary>
	public class frmAddBillsViewer : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region 自定义变量
		
		public frmBIHOrderInput m_frmParent=new frmBIHOrderInput();

		public int m_intOpenbType=0;
		public clsBIHCanExecOrder[] m_objOrderArr=new clsBIHCanExecOrder[0];

		#endregion

		private System.Windows.Forms.TreeView trvAddBills;
		private System.Windows.Forms.ImageList imgAddBills;
		private PinkieControls.ButtonXP m_btnOpen;
		private PinkieControls.ButtonXP m_btnRefresh;
		private PinkieControls.ButtonXP m_btnClose;
		private System.ComponentModel.IContainer components;

		public frmAddBillsViewer()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAddBillsViewer));
			this.trvAddBills = new System.Windows.Forms.TreeView();
			this.imgAddBills = new System.Windows.Forms.ImageList(this.components);
			this.m_btnOpen = new PinkieControls.ButtonXP();
			this.m_btnRefresh = new PinkieControls.ButtonXP();
			this.m_btnClose = new PinkieControls.ButtonXP();
			this.SuspendLayout();
			// 
			// trvAddBills
			// 
			this.trvAddBills.ImageList = this.imgAddBills;
			this.trvAddBills.Location = new System.Drawing.Point(8, 8);
			this.trvAddBills.Name = "trvAddBills";
			this.trvAddBills.Size = new System.Drawing.Size(296, 352);
			this.trvAddBills.TabIndex = 0;
			this.trvAddBills.DoubleClick += new System.EventHandler(this.trvAddBills_DoubleClick);
			
			// 
			// imgAddBills
			// 
			this.imgAddBills.ImageSize = new System.Drawing.Size(32, 32);
			this.imgAddBills.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgAddBills.ImageStream")));
			this.imgAddBills.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_btnOpen
			// 
			this.m_btnOpen.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnOpen.DefaultScheme = true;
			this.m_btnOpen.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnOpen.Hint = "";
			this.m_btnOpen.Location = new System.Drawing.Point(328, 268);
			this.m_btnOpen.Name = "m_btnOpen";
			this.m_btnOpen.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnOpen.Size = new System.Drawing.Size(85, 28);
			this.m_btnOpen.TabIndex = 57;
			this.m_btnOpen.Text = "打开(F2)";
			this.m_btnOpen.Click += new System.EventHandler(this.m_btnOpen_Click);
			// 
			// m_btnRefresh
			// 
			this.m_btnRefresh.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnRefresh.DefaultScheme = true;
			this.m_btnRefresh.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnRefresh.Hint = "";
			this.m_btnRefresh.Location = new System.Drawing.Point(328, 300);
			this.m_btnRefresh.Name = "m_btnRefresh";
			this.m_btnRefresh.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnRefresh.Size = new System.Drawing.Size(85, 28);
			this.m_btnRefresh.TabIndex = 58;
			this.m_btnRefresh.Text = "刷新(F3)";
			this.m_btnRefresh.Click += new System.EventHandler(this.m_btnRefresh_Click);
			// 
			// m_btnClose
			// 
			this.m_btnClose.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnClose.DefaultScheme = true;
			this.m_btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnClose.Hint = "";
			this.m_btnClose.Location = new System.Drawing.Point(328, 332);
			this.m_btnClose.Name = "m_btnClose";
			this.m_btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnClose.Size = new System.Drawing.Size(85, 28);
			this.m_btnClose.TabIndex = 59;
			this.m_btnClose.Text = "关闭(F4)";
			this.m_btnClose.Click += new System.EventHandler(this.m_btnClose_Click);
			// 
			// frmAddBillsViewer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(430, 369);
			this.Controls.Add(this.m_btnClose);
			this.Controls.Add(this.m_btnRefresh);
			this.Controls.Add(this.m_btnOpen);
			this.Controls.Add(this.trvAddBills);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmAddBillsViewer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "附加单据浏览";
			this.Load += new System.EventHandler(this.frmAddBillsViewer_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private long m_lngLoadAddBills()
		{
			trvAddBills.Nodes.Clear();
			clsBIHOrderInputDomain.clsOtherBillInfo.s_objPatient=this.m_frmParent.m_ctlPatient.m_objPatient;
			for(int i=0;i<m_frmParent.m_objDomain.m_arlOtherBillInfo.Count;i++)
			{
				clsBIHOrderInputDomain.clsOtherBillInfo objBillInfo=m_frmParent.m_objDomain.m_arlOtherBillInfo[i] as clsBIHOrderInputDomain.clsOtherBillInfo;
				TreeNode tn=new TreeNode(objBillInfo.ToString().Trim());
				tn.Tag=objBillInfo;
				if(objBillInfo.AttachOrderCount>0)
				{
					#region 获得申请单ID
					DataTable dtbRes=new DataTable();
					long lngAttach=objBillInfo.m_lngGetAddBillByOrderID(objBillInfo.m_objOrder.m_strOrderID.Trim(),out dtbRes);
					if(lngAttach>=0 && dtbRes.Rows.Count>0)
					{
						objBillInfo.m_objART.m_StrRecordID=dtbRes.Rows[0]["ATTACHID_VCHR"].ToString().Trim();
					}
					#endregion

					try
					{
						iCareData.clsApplyReportList_VO p_objApply=new iCareData.clsApplyReportList_VO();
						long lngApply=m_lngGetArRecord(objBillInfo.m_objART.m_StrRecordID.Trim(),out p_objApply);
					
						if(p_objApply!=null && p_objApply.m_objRelaFormArr!=null && p_objApply.m_objRelaFormArr.Length>0)
						{
							tn.ImageIndex=1;
							tn.SelectedImageIndex=1;
						}
						else
						{
							tn.ImageIndex=2;
							tn.SelectedImageIndex=2;
						}
					}
					catch
					{
					}
				}
				else
				{
					tn.ImageIndex=0;
					tn.SelectedImageIndex=0;
				}
				//待加入报告单数据
				trvAddBills.Nodes.Add(tn);
			}
			return 0;
		}

		private void frmAddBillsViewer_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(m_intOpenbType==0)
				{
					m_lngLoadAddBills();
				}
				else
				{
					m_lngLoadAddBillsFromExecute();
				}
			}
			catch
			{
			}
		}

		private void m_btnClose_Click(object sender, System.EventArgs e)
		{
			Close();
		}


		private void trvAddBills_DoubleClick(object sender, System.EventArgs e)
		{
			if(trvAddBills.SelectedNode!=null)
			{
				if(trvAddBills.SelectedNode.Parent==null)
				{
					if(m_intOpenbType==0) //从医嘱录入打开
					{
						clsBIHOrderInputDomain.clsOtherBillInfo objCurrentBillInfo=(clsBIHOrderInputDomain.clsOtherBillInfo)(trvAddBills.SelectedNode.Tag);
						objCurrentBillInfo.m_ParentForm=this.m_frmParent;
						objCurrentBillInfo.m_ParentForm.objController=this.m_frmParent.objController;
						objCurrentBillInfo.m_mthShowUI(m_frmParent.LoginInfo);
						m_lngLoadAddBills();
					}
					else if(m_intOpenbType==1)//从医嘱执行打开
					{
						
						clsBIHCanExecOrder objOrders=(clsBIHCanExecOrder)(trvAddBills.SelectedNode.Tag);
						//医嘱类型ID
						string strOrderCateID=objOrders.m_strOrderDicCateID.Trim();
						//医嘱ID
						string strOrderID=objOrders.m_strOrderID.Trim();
						//附加单据ID
						string strAttachID =GetAttachID(strOrderID);
						//关系表ID
						clsRelation_VOArr objRelation=new clsRelation_VOArr();
						long lngR=objRelation.m_lngGetRelation("sourceitemid_vchr='"+strOrderID.Trim()+"'");
						string strRelationID=objRelation.m_objValues[0].m_strATTARELAID_CHR.Trim();
						DataTable dtbAddBills=null;
						long lngRes=m_lngGetAddBillByOrderID(strOrderID.Trim(),out dtbAddBills);

						clsT_aid_bih_ordercate_VO objResult =null;
						clsDcl_InputOrder objTem =new clsDcl_InputOrder();
						lngRes =objTem.m_lngGetAidOrderCateByID(strOrderCateID,out objResult);
						if(lngRes<=0 || objResult==null) return;
						
						string strDllName =objResult.m_strDLLNAME_VCHR;
						string strClassName =objResult.m_strCLASSNAME_VCHR;
						string strInsertName =objResult.m_strOPRADD_VCHR;
						string strUpdateName =objResult.m_strOPRUPD_VCHR;

						System.Reflection.Assembly objAsm=System.Reflection.Assembly.LoadFrom(strDllName);

						if(objAsm==null) return ;
						object[] objParams =new object[1];

						objParams[0]=strAttachID.Trim();

						object obj;
						try
						{
					
							obj=objAsm.CreateInstance( strClassName,true,System.Reflection.BindingFlags.Default,null,objParams,null,new object[0]{});
						}
						catch(System.Exception err)
						{
							string strMsg=err.Message.ToString();
							MessageBox.Show(strMsg);
							return;
						}
						if(obj==null) return ;
						//打开窗体
						((Form)obj).ShowDialog();
						Type objType=obj.GetType();	
						System.Reflection.PropertyInfo objMi=objType.GetProperty("m_StrRecordID");
						string strAddBillRecordID=objMi.GetValue(obj,null).ToString();
						if(strAddBillRecordID.Trim()!="")
						{
							m_lngSaveAddBill(strAddBillRecordID.Trim(),strRelationID,strOrderID);
						}
						return;
					}
				}
			}
		}

		private void m_btnOpen_Click(object sender, System.EventArgs e)
		{
			trvAddBills_DoubleClick(null,null);
		}

		private void m_btnRefresh_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(m_intOpenbType==0)
				{
					m_lngLoadAddBills();
				}
				else
				{
					m_lngLoadAddBillsFromExecute();
				}
			}
			catch
			{
			}
		}

		private long m_lngGetArRecord(string p_strAttachID,out iCareData.clsApplyReportList_VO p_objApply)
		{
			p_objApply=new iCareData.clsApplyReportList_VO();
			if(p_strAttachID.Trim()=="")
			{
				return -1;
			}
			com.digitalwave.ApplyReportServer.clsApplyReportServer objAttachServer=new com.digitalwave.ApplyReportServer.clsApplyReportServer();
			return objAttachServer.m_lngGetARRecordByRecID(p_strAttachID,out p_objApply);
		}


		private long m_lngLoadAddBillsFromExecute()
		{
			trvAddBills.Nodes.Clear();
			
			//clsBIHOrderInputDomain.clsOtherBillInfo.s_objPatient.=this.m_objOrderArr[0].m_objBIHCanExecOrder.

			for(int i=0;i<this.m_objOrderArr.GetLength(0);i++)
			{
				#region 原处理方法
				//				clsBIHOrderInputDomain.clsOtherBillInfo objBillInfo=m_frmParent.m_objDomain.m_arlOtherBillInfo[i] as clsBIHOrderInputDomain.clsOtherBillInfo;
				//				TreeNode tn=new TreeNode(objBillInfo.ToString().Trim());
				//				tn.Tag=objBillInfo;
				//				//this.objController.m_objComInfo.m_mthGetPatientInfo(
				//				if(objBillInfo.AttachOrderCount>0)
				//				{
				//					#region 获得申请单ID
				//					DataTable dtbRes=new DataTable();
				//					long lngAttach=objBillInfo.m_lngGetAddBillByOrderID(objBillInfo.m_objOrder.m_strOrderID.Trim(),out dtbRes);
				//					if(lngAttach>=0 && dtbRes.Rows.Count>0)
				//					{
				//						objBillInfo.m_objART.m_StrRecordID=dtbRes.Rows[0]["ATTACHID_VCHR"].ToString().Trim();
				//					}
				//					#endregion
				//
				//					iCareData.clsApplyReportList_VO p_objApply=new iCareData.clsApplyReportList_VO();
				//					long lngApply=m_lngGetArRecord(objBillInfo.m_objART.m_StrRecordID.Trim(),out p_objApply);
				//					if(p_objApply!=null && p_objApply.m_objRelaFormArr!=null && p_objApply.m_objRelaFormArr.Length>0)
				//					{
				//						tn.ImageIndex=3;
				//						tn.SelectedImageIndex=3;
				//					}
				//					else
				//					{
				//						tn.ImageIndex=2;
				//						tn.SelectedImageIndex=2;
				//					}
				//				}
				//				else
				//				{
				//					tn.ImageIndex=0;
				//					tn.SelectedImageIndex=0;
				//				}
				//				//待加入报告单数据
				//				trvAddBills.Nodes.Add(tn);
				//			}
				//			return 0;
				#endregion

				clsBIHOrderInputDomain.clsOtherBillInfo objBillInfo=new com.digitalwave.iCare.BIHOrder.clsBIHOrderInputDomain.clsOtherBillInfo();

				DataTable dtbAddBill=new DataTable();

				long lngRes=objBillInfo.m_lngGetAddBillByOrderID(m_objOrderArr[i].m_strOrderID.Trim(),out dtbAddBill);

				if(lngRes>=0 && dtbAddBill.Rows.Count>0)
				{
					TreeNode tnAdd=new TreeNode();
					tnAdd.Text=m_objOrderArr[i].m_strName.Trim();

					tnAdd.Tag=m_objOrderArr[i];
					trvAddBills.Nodes.Add(tnAdd);
				}
			}
			return 0;
		}

		/// <summary>
		/// 获取医嘱附加单据ID
		/// </summary>
		/// <param name="strOrderID">医嘱ID</param>
		/// <returns>附加单据ID</returns>
		private string GetAttachID(string strOrderID)
		{
			//附加表单id
			string[] strAttachIDArr;
			long ret=new clsBIHOrderService().m_lngGetAttachOrder(strOrderID,out strAttachIDArr);
			if(ret>0 && strAttachIDArr!=null && strAttachIDArr.Length>0)
				return strAttachIDArr[0];
			else
				return "";
		}

		struct stAddBills
		{
			clsBIHCanExecOrder m_Order;
			DataTable m_dtbAddBill;
		}


		/// <summary>
		/// 查询医嘱的附加单据
		/// </summary>
		/// <param name="p_strOrderID">医嘱ID</param>
		/// <param name="dtbAddBills">附加单据列表</param>
		/// <returns></returns>
		public long m_lngGetAddBillByOrderID(string p_strOrderID,out DataTable dtbCurrAddBill)
		{
			dtbCurrAddBill=new DataTable();
			try
			{
				clsRelation_DTable dtbRes=new clsRelation_DTable();
				long lngRes=dtbRes.m_lngGetRelation(" sourceitemid_vchr='"+p_strOrderID.Trim()+"'");
				dtbCurrAddBill=dtbRes.m_dtbValues;
				return lngRes;
			}
			catch
			{
				return -1;
			}
		}

		/// <summary>
		/// 保存附加单据
		/// </summary>
		/// <param name="p_strAddBillRecordID">附加单据ID</param>
		/// <returns></returns>
		private long m_lngSaveAddBill(string p_strAddBillRecordID,string m_strRelationID,string m_strOrderID)
		{

			clsRelation_StrArr objAddBill=new clsRelation_StrArr();

			objAddBill.m_strValues=new string[1,5];

			//m_strRelationID=p_strAddBillRecordID.Trim();

			objAddBill.m_strValues[0,0]=m_strRelationID.Trim();
			objAddBill.m_strValues[0,1]="2";
			objAddBill.m_strValues[0,2]="";
			objAddBill.m_strValues[0,3]=m_strOrderID.Trim();
			objAddBill.m_strValues[0,4]=p_strAddBillRecordID.Trim();

			try
			{
				clsRelationService_STR objAddBillSRV=new clsRelationService_STR();
				long lngRes=0;
				if(m_strRelationID.Trim()!="")
				{
					lngRes=objAddBill.m_lngUpdate();
						
				}
				else
				{
					lngRes=objAddBill.m_lngInsertRelation();
				}
				return lngRes;
			}
			catch
			{
				return -1;
			}
		}

	}
}
