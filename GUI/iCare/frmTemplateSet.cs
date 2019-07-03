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
using com.digitalwave.PublicMiddleTier;
using StaticObject = com.digitalwave.Emr.StaticObject;

namespace iCare
{
	/// <summary>
	/// Summary description for frmTemplateSet.
	/// </summary>
	public class frmTemplateSet : iCare.iCareBaseForm.frmBaseForm,PublicFunction
	{
		#region
		private bool m_blnNewCaseIsAdd = false;
		private TreeNode m_trnP_Node;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox m_glbTemplateset;
		private System.Windows.Forms.ComboBox m_cmbForms;
		protected System.Windows.Forms.GroupBox m_glbTemplateType;
		private System.Windows.Forms.Label lblTemplateType;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ListView m_lsvTemplateset;
		private System.Windows.Forms.Label lblCreator;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button cmdClear;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboDisease;
		private System.Windows.Forms.Label label7;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboOperation;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox m_txtKeywordPY;
		private System.Windows.Forms.TextBox m_txtTemplateID;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox lstICD10;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox m_txtTemplateName;
		protected System.Windows.Forms.RadioButton m_rdbBAXT;
		protected System.Windows.Forms.RadioButton m_rdbKeyWord;
		protected System.Windows.Forms.RadioButton m_rdbICD10;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpEndDate;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpStartDate;
		private System.Windows.Forms.ListBox m_lstControls;
		private System.Windows.Forms.ListBox m_lstTemplates;
		private System.Windows.Forms.Button cmdRemoveTemplate;
		private System.Windows.Forms.Button cmdAddTemplate;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox m_txtTemplateContent;
		private System.Windows.Forms.ListBox lstTemplateIDs;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TreeView m_trvTemplate;
		private System.Windows.Forms.TreeView m_trvForms;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboKeyword;
		private System.Windows.Forms.TextBox m_txtKeyword;
		private System.Windows.Forms.GroupBox groupBox2;
		private PinkieControls.ButtonXP m_cmdModifyBase;
		private PinkieControls.ButtonXP cmdSaveTemplateSet;
		private PinkieControls.ButtonXP cmdDel;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ListView m_lsvDisease;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private PinkieControls.ButtonXP m_cmdDiseaseSelect;
		private PinkieControls.ButtonXP m_cmdDel;
		private System.Windows.Forms.Label label15;
		protected System.Windows.Forms.RadioButton m_rdbDepartment;
		protected System.Windows.Forms.RadioButton m_rdbPublic;
		protected System.Windows.Forms.RadioButton m_rdbPrivate;
		protected System.Windows.Forms.CheckedListBox m_lstDepartment;
        private System.Windows.Forms.Panel panel1;


		#endregion
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem m_tsmiCopyTemplate;
        private IContainer components;
		
		public frmTemplateSet()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-9 9:13:43
            //clsBorderTool m_objBorderTool = new clsBorderTool(Color.White);

            //foreach(Control ctlControl in this.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ListView" )
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "TextBox" && ctlControl.Name!="m_txtKeywordPY")
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "DataGrid")
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //        ((DataGrid)ctlControl).AllowSorting =false ;
            //    }

            //    if(typeName =="TreeView")
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "GroupBox")
            //    {
            //        foreach(Control ctlGrp in ((GroupBox)ctlControl).Controls)
            //        {
            //            string strSubTypeName = ctlGrp.GetType().Name;
            //            if(strSubTypeName == "PictureBox")
            //            {
            //                m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                                            {
            //                                                ctlGrp ,
            //                });
            //            }
            //        }
            //    }
            //}
			#endregion

			#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-9 9:13:43
            //m_objBorderTool = new clsBorderTool(Color.White);

            //foreach(Control ctlControl in this.m_glbTemplateset.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ListView" )
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "TextBox" )
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "ListBox")
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }

            //    if(typeName =="TreeView")
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "GroupBox")
            //    {
            //        foreach(Control ctlGrp in ((GroupBox)ctlControl).Controls)
            //        {
            //            string strSubTypeName = ctlGrp.GetType().Name;
            //            if(strSubTypeName == "PictureBox")
            //            {
            //                m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                                            {
            //                                                ctlGrp ,
            //                });
            //            }
            //        }
            //    }
            //}
            #endregion

            //#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-9 9:13:43
            //m_objBorderTool = new clsBorderTool(Color.White);

            //foreach(Control ctlControl in this.m_glbTemplateType.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ListView" )
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "TextBox" )
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "DataGrid")
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //        ((DataGrid)ctlControl).AllowSorting =false ;
            //    }

            //    if(typeName =="TreeView")
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "GroupBox")
            //    {
            //        foreach(Control ctlGrp in ((GroupBox)ctlControl).Controls)
            //        {
            //            string strSubTypeName = ctlGrp.GetType().Name;
            //            if(strSubTypeName == "PictureBox")
            //            {
            //                m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                                            {
            //                                                ctlGrp ,
            //                });
            //            }
            //        }
            //    }
            //}
            //#endregion
			
			m_mthClearInterface();
			//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//			this.lblCreator.Text =MDIParent.OperatorName;

			#region 获得所有窗体,刘颖源,2003-5-9 9:21:18
//			m_objFormListArr =m_objDomain.lngGetAllForms ();
//			this.m_cmbForms.Items.Clear ();
//			if(m_objFormListArr !=null && m_objFormListArr.Length >0)
//				for(int i=0;i<m_objFormListArr.Length ;i++)
//					this.m_cmbForms.Items.Add (m_objFormListArr[i].m_strForm_Desc ); 
			#endregion

			lstICD10.Visible =false;

			m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);		
	
			m_mthInitContextMenu();
			m_mthLoadCustomForms();

			//ICD10查询
			com.digitalwave.common.ICD10.Tool.clsBindICD10 m_objIcd10Bind=new com.digitalwave.common.ICD10.Tool.clsBindICD10();
			m_objIcd10Bind.m_mthBindICD10(m_cmdDiseaseSelect,m_lsvDisease,0,3,null,null);
			m_trnP_Node = new TreeNode("专科住院病历");
			m_trnP_Node.Nodes.Add("无专科病历");
			m_trnP_Node.Nodes[0].ForeColor = Color.Red;
			m_trvForms.Nodes[0].Nodes[0].Nodes.Insert(0,m_trnP_Node);

            //广西南宁只需病程记录中的术前小结
            if (!string.IsNullOrEmpty(clsEMRLogin.m_StrCurrentHospitalNO) && clsEMRLogin.m_StrCurrentHospitalNO.Trim() == "450101001")
            {
                foreach (TreeNode trN in m_trvForms.Nodes)
                {
                    if (trN.Text == "医生工作站")
                    {
                        m_mthSetSummaryBeforeOPNode(trN);
                        break;
                    }
                }
            }
		}

		/// <summary>
		/// 初始化右键菜单
		/// </summary>
		private void m_mthInitContextMenu()
		{
			System.Windows.Forms.ContextMenu ctmTemplateContent = new System.Windows.Forms.ContextMenu();		

			ctmTemplateContent.MenuItems.Add(new MenuItem("剪切(&T)",new EventHandler(m_mthCut)));
			ctmTemplateContent.MenuItems.Add(new MenuItem("复制(&C)",new EventHandler(m_mthCopy)));
			ctmTemplateContent.MenuItems.Add(new MenuItem("粘贴(&P)",new EventHandler(m_mthPaste)));
			ctmTemplateContent.MenuItems.Add("-");

			MenuItem mniDataShare = new MenuItem("数据复用");
			clsTransferTemplate.s_mthInitDataShareItems(mniDataShare);
			m_mthAssociateDataShareItemsEvent(mniDataShare);
//			ctmTemplateContent.MenuItems.Add(new clsTransferTemplate().m_MniDataShare);
			ctmTemplateContent.MenuItems.Add(mniDataShare);

			m_txtTemplateContent.ContextMenu = ctmTemplateContent;
		}

        /// <summary>
        /// 设置外部“术前小结”是否可见
        /// </summary>
        /// <param name="trN"></param>
        private void m_mthSetSummaryBeforeOPNode(TreeNode trN)
        {
            if (trN == null)
            {
                return;
            }
            if (!string.IsNullOrEmpty(clsEMRLogin.m_StrCurrentHospitalNO) 
                && clsEMRLogin.m_StrCurrentHospitalNO.Trim() == "450101001")
            {
                foreach (TreeNode trChild in trN.Nodes)
                {
                    if (trChild.Text == "术前小结" && trN.Text != "病案记录")
                    {
                        trChild.Remove();
                        return;
                    }
                    else if (trChild.Nodes != null)
                    {
                        m_mthSetSummaryBeforeOPNode(trChild);
                    }
                }
            }
        }
		/// <summary>
		/// 设置数据复用菜单点击事件
		/// </summary>
		/// <param name="p_mniRoot"></param>
		private void m_mthAssociateDataShareItemsEvent(MenuItem p_mniRoot)
		{
			if(p_mniRoot.MenuItems.Count > 0)
				for(int i = 0; i < p_mniRoot.MenuItems.Count; i++)
					m_mthAssociateDataShareItemsEvent(p_mniRoot.MenuItems[i]);
			else
				p_mniRoot.Click += new EventHandler(m_mthDataShareItemClick);
		}

		/// <summary>
		/// 数据复用
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_mthDataShareItemClick(object sender,EventArgs e)
		{
			string strContent = "[" + ((MenuItem)sender).Parent.ToString().Substring(((MenuItem)sender).Parent.ToString().IndexOf("Text: ")+6) + "--" + ((MenuItem)sender).Text + "]";
			m_txtTemplateContent.Text = m_txtTemplateContent.Text.Insert(m_txtTemplateContent.SelectionStart,strContent);
		}


		#region 剪切，复制，粘贴
		private void m_mthCut(object sender,EventArgs e)
		{
			m_txtTemplateContent.Cut();
		}
		private void m_mthCopy(object sender,EventArgs e)
		{
			m_txtTemplateContent.Copy();
		}
		private void m_mthPaste(object sender,EventArgs e)
		{
			m_txtTemplateContent.Paste();
		}
		#endregion

		protected ctlHighLightFocus m_objHighLight;

		
		
		#region 成员变量,刘颖源,2003-5-9 9:21:18
		clsGUI_InfoValue[] m_objFormListArr=null;		//所有的Form列表
		string m_strFormID="";							//选中的FormID
		clsGUI_Info_DetailValue [] m_objControls=null;	//当前Form的Control列表
		string m_strControlID="";						//选中的ControlID
		clsTemplateFormControlValue[] m_objTemplateFromControl=null;	//选定Form和Control后的Template信息
		string m_strTemplateID="";						//选中的模板ID
		int m_intSelectTemplateIndex=-1;				//选中的模板Index

		int m_intSelectTemplateSetIndex=-1;				//选中的套装模板Index

		ArrayList m_objArrTemplateSet=new ArrayList();					//模板集合，即TemplateSet


		clsICD10_IllnessIDValue [] m_objICD10_IllnessIDValue=null;	//当前的ICD10
		clsICD10_IllnessSubIDValue [] m_objICD10_IllnessSubID=null;
		clsICD10_IllnessDetailIDValue [] m_objICD10_IllnessDetail=null;

		int m_intSelectICD10Level=-1;					//选中的ICD10层
		string m_strSelectICD10_0ID="";					//选中的0层的ID
		string m_strSelectICD10_1ID="";					//选中的1层的ID
		string m_strSelectICD10_2D="";					//选中的2层的ID

		clsBio_SystemValue [] m_objBio_System=null;		//八大系统
		clsBio_System_DetailValue[] m_objBio_System_Detail=null;//八大系统部位
		
		int m_intSelectSystem=-1;						//选中的系统
		string m_strSelectSystemID="";					//选中的系统
		string m_strSelectSystemDetailID="";			//选中的部位

		clsTemplateDomain m_objDomain=new clsTemplateDomain ();				//Domain层

		#endregion

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("住院病历");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("首次病程记录");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("病程记录");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("交班记录");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("接班记录");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("会诊记录");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("转出记录");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("转入记录");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("阶段小结");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("查房记录");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("病例讨论");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("术前讨论");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("死亡病例讨论");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("手术后病程记录");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("死亡记录");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("出院记录");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("抢救记录");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("术前小结");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("病案记录", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("会诊记录");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("手术知情同意书");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("术前小结");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("手术记录单");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("ICU转入记录");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("ICU转出记录");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("出院记录");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("住院病案首页");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("病案质量评分表");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("病案生成", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode27,
            treeNode28});
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("B型超声显像检查申请单");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("CT检查申请单");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("X线申请单");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("SPECT检查申请单");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("高压氧治疗申请单");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("病理活体组织送检单");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("MRI申请单");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("心电图申请单");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("电脑多导睡眠图检查申请单");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("核医学检查申请单");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("申  请  单", new System.Windows.Forms.TreeNode[] {
            treeNode30,
            treeNode31,
            treeNode32,
            treeNode33,
            treeNode34,
            treeNode35,
            treeNode36,
            treeNode37,
            treeNode38,
            treeNode39});
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("医生工作站", new System.Windows.Forms.TreeNode[] {
            treeNode29,
            treeNode40});
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("病人入院评估表");
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("入院病人评估");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("一般护理记录");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("一般患者护理记录");
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("一般患者护理记录(病情记录)");
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("观察项目记录表");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("危重患者护理记录");
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("危重患者护理记录(病情记录)");
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("危重症监护中心特护记录单");
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("手术护理记录");
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("手术器械、敷料点数表");
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("中心ICU呼吸机治疗监护记录单");
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("心血管外科特护记录");
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("ICU护理记录");
            System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("护士工作站", new System.Windows.Forms.TreeNode[] {
            treeNode42,
            treeNode43,
            treeNode44,
            treeNode45,
            treeNode46,
            treeNode47,
            treeNode48,
            treeNode49,
            treeNode50,
            treeNode51,
            treeNode52,
            treeNode53,
            treeNode54,
            treeNode55});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTemplateSet));
            this.label1 = new System.Windows.Forms.Label();
            this.m_glbTemplateset = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_rdbPrivate = new System.Windows.Forms.RadioButton();
            this.m_rdbPublic = new System.Windows.Forms.RadioButton();
            this.m_rdbDepartment = new System.Windows.Forms.RadioButton();
            this.m_lstDepartment = new System.Windows.Forms.CheckedListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblCreator = new System.Windows.Forms.Label();
            this.cmdDel = new PinkieControls.ButtonXP();
            this.cmdSaveTemplateSet = new PinkieControls.ButtonXP();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.m_trvForms = new System.Windows.Forms.TreeView();
            this.m_trvTemplate = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_tsmiCopyTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txtTemplateContent = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.m_lsvTemplateset = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.m_glbTemplateType = new System.Windows.Forms.GroupBox();
            this.m_txtTemplateName = new System.Windows.Forms.TextBox();
            this.m_lsvDisease = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.m_cboKeyword = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cboOperation = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_cboDisease = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTemplateType = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.m_cmdDiseaseSelect = new PinkieControls.ButtonXP();
            this.m_cmdDel = new PinkieControls.ButtonXP();
            this.m_cmdModifyBase = new PinkieControls.ButtonXP();
            this.m_cmbForms = new System.Windows.Forms.ComboBox();
            this.cmdClear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtKeyword = new System.Windows.Forms.TextBox();
            this.lstTemplateIDs = new System.Windows.Forms.ListBox();
            this.cmdRemoveTemplate = new System.Windows.Forms.Button();
            this.cmdAddTemplate = new System.Windows.Forms.Button();
            this.m_lstTemplates = new System.Windows.Forms.ListBox();
            this.m_lstControls = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_dtpEndDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_dtpStartDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_rdbBAXT = new System.Windows.Forms.RadioButton();
            this.m_rdbKeyWord = new System.Windows.Forms.RadioButton();
            this.m_rdbICD10 = new System.Windows.Forms.RadioButton();
            this.lstICD10 = new System.Windows.Forms.ListBox();
            this.m_txtTemplateID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtKeywordPY = new System.Windows.Forms.TextBox();
            this.m_glbTemplateset.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.m_glbTemplateType.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(404, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 35);
            this.label1.TabIndex = 3026;
            this.label1.Text = "模 板 维 护";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // m_glbTemplateset
            // 
            this.m_glbTemplateset.Controls.Add(this.panel1);
            this.m_glbTemplateset.Controls.Add(this.m_lstDepartment);
            this.m_glbTemplateset.Controls.Add(this.label15);
            this.m_glbTemplateset.Controls.Add(this.lblCreator);
            this.m_glbTemplateset.Controls.Add(this.cmdDel);
            this.m_glbTemplateset.Controls.Add(this.cmdSaveTemplateSet);
            this.m_glbTemplateset.Controls.Add(this.groupBox2);
            this.m_glbTemplateset.Controls.Add(this.label13);
            this.m_glbTemplateset.Controls.Add(this.label11);
            this.m_glbTemplateset.Controls.Add(this.m_trvForms);
            this.m_glbTemplateset.Controls.Add(this.m_trvTemplate);
            this.m_glbTemplateset.Controls.Add(this.label10);
            this.m_glbTemplateset.Controls.Add(this.label9);
            this.m_glbTemplateset.Controls.Add(this.m_txtTemplateContent);
            this.m_glbTemplateset.Controls.Add(this.label12);
            this.m_glbTemplateset.Controls.Add(this.m_lsvTemplateset);
            this.m_glbTemplateset.Controls.Add(this.m_glbTemplateType);
            this.m_glbTemplateset.Controls.Add(this.m_cmdModifyBase);
            this.m_glbTemplateset.Location = new System.Drawing.Point(4, 0);
            this.m_glbTemplateset.Name = "m_glbTemplateset";
            this.m_glbTemplateset.Size = new System.Drawing.Size(800, 644);
            this.m_glbTemplateset.TabIndex = 15011;
            this.m_glbTemplateset.TabStop = false;
            this.m_glbTemplateset.Enter += new System.EventHandler(this.m_glbTemplateset_Enter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_rdbPrivate);
            this.panel1.Controls.Add(this.m_rdbPublic);
            this.panel1.Controls.Add(this.m_rdbDepartment);
            this.panel1.Location = new System.Drawing.Point(540, 548);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 48);
            this.panel1.TabIndex = 10000011;
            // 
            // m_rdbPrivate
            // 
            this.m_rdbPrivate.Enabled = false;
            this.m_rdbPrivate.Location = new System.Drawing.Point(4, 12);
            this.m_rdbPrivate.Name = "m_rdbPrivate";
            this.m_rdbPrivate.Size = new System.Drawing.Size(60, 24);
            this.m_rdbPrivate.TabIndex = 10000008;
            this.m_rdbPrivate.Text = "自用";
            this.m_rdbPrivate.CheckedChanged += new System.EventHandler(this.m_rdbPublicAnaPrivate_CheckedChanged);
            // 
            // m_rdbPublic
            // 
            this.m_rdbPublic.Checked = true;
            this.m_rdbPublic.Enabled = false;
            this.m_rdbPublic.Location = new System.Drawing.Point(92, 12);
            this.m_rdbPublic.Name = "m_rdbPublic";
            this.m_rdbPublic.Size = new System.Drawing.Size(60, 26);
            this.m_rdbPublic.TabIndex = 10000009;
            this.m_rdbPublic.TabStop = true;
            this.m_rdbPublic.Text = "公用";
            this.m_rdbPublic.CheckedChanged += new System.EventHandler(this.m_rdbPublicAnaPrivate_CheckedChanged);
            // 
            // m_rdbDepartment
            // 
            this.m_rdbDepartment.Enabled = false;
            this.m_rdbDepartment.Location = new System.Drawing.Point(172, 12);
            this.m_rdbDepartment.Name = "m_rdbDepartment";
            this.m_rdbDepartment.Size = new System.Drawing.Size(84, 22);
            this.m_rdbDepartment.TabIndex = 10000010;
            this.m_rdbDepartment.Text = "科室使用";
            this.m_rdbDepartment.CheckedChanged += new System.EventHandler(this.m_rdbDepartment_CheckedChanged);
            // 
            // m_lstDepartment
            // 
            this.m_lstDepartment.BackColor = System.Drawing.Color.White;
            this.m_lstDepartment.CheckOnClick = true;
            this.m_lstDepartment.Enabled = false;
            this.m_lstDepartment.ForeColor = System.Drawing.Color.Black;
            this.m_lstDepartment.Location = new System.Drawing.Point(540, 344);
            this.m_lstDepartment.Name = "m_lstDepartment";
            this.m_lstDepartment.Size = new System.Drawing.Size(252, 202);
            this.m_lstDepartment.TabIndex = 10000007;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(540, 320);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 14);
            this.label15.TabIndex = 10000006;
            this.label15.Text = "适用范围:";
            // 
            // lblCreator
            // 
            this.lblCreator.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCreator.ForeColor = System.Drawing.Color.Black;
            this.lblCreator.Location = new System.Drawing.Point(316, 606);
            this.lblCreator.Name = "lblCreator";
            this.lblCreator.Size = new System.Drawing.Size(92, 20);
            this.lblCreator.TabIndex = 15021;
            this.lblCreator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdDel
            // 
            this.cmdDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmdDel.DefaultScheme = true;
            this.cmdDel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdDel.ForeColor = System.Drawing.Color.Black;
            this.cmdDel.Hint = "";
            this.cmdDel.Location = new System.Drawing.Point(728, 600);
            this.cmdDel.Name = "cmdDel";
            this.cmdDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdDel.Size = new System.Drawing.Size(60, 32);
            this.cmdDel.TabIndex = 10000001;
            this.cmdDel.Text = "删 除";
            this.cmdDel.Click += new System.EventHandler(this.cmdDel_Click);
            // 
            // cmdSaveTemplateSet
            // 
            this.cmdSaveTemplateSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmdSaveTemplateSet.DefaultScheme = true;
            this.cmdSaveTemplateSet.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdSaveTemplateSet.ForeColor = System.Drawing.Color.Black;
            this.cmdSaveTemplateSet.Hint = "";
            this.cmdSaveTemplateSet.Location = new System.Drawing.Point(612, 600);
            this.cmdSaveTemplateSet.Name = "cmdSaveTemplateSet";
            this.cmdSaveTemplateSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSaveTemplateSet.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdSaveTemplateSet.Size = new System.Drawing.Size(108, 32);
            this.cmdSaveTemplateSet.TabIndex = 10000001;
            this.cmdSaveTemplateSet.Text = "修改模板";
            this.cmdSaveTemplateSet.Click += new System.EventHandler(this.cmdSaveTemplateSet_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(0, 308);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 3);
            this.groupBox2.TabIndex = 15044;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(248, 607);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 14);
            this.label13.TabIndex = 15043;
            this.label13.Text = "创建者:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label11.Location = new System.Drawing.Point(14, 320);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 14);
            this.label11.TabIndex = 15042;
            this.label11.Text = "模板名称:";
            // 
            // m_trvForms
            // 
            this.m_trvForms.BackColor = System.Drawing.SystemColors.Window;
            this.m_trvForms.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_trvForms.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_trvForms.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_trvForms.HideSelection = false;
            this.m_trvForms.HotTracking = true;
            this.m_trvForms.Indent = 22;
            this.m_trvForms.Location = new System.Drawing.Point(16, 40);
            this.m_trvForms.Name = "m_trvForms";
            treeNode1.Name = "";
            treeNode1.Text = "住院病历";
            treeNode2.Name = "";
            treeNode2.Text = "首次病程记录";
            treeNode3.Name = "";
            treeNode3.Text = "病程记录";
            treeNode4.Name = "";
            treeNode4.Text = "交班记录";
            treeNode5.Name = "";
            treeNode5.Text = "接班记录";
            treeNode6.Name = "";
            treeNode6.Text = "会诊记录";
            treeNode7.Name = "";
            treeNode7.Text = "转出记录";
            treeNode8.Name = "";
            treeNode8.Text = "转入记录";
            treeNode9.Name = "";
            treeNode9.Text = "阶段小结";
            treeNode10.Name = "";
            treeNode10.Text = "查房记录";
            treeNode11.Name = "";
            treeNode11.Text = "病例讨论";
            treeNode12.Name = "";
            treeNode12.Text = "术前讨论";
            treeNode13.Name = "";
            treeNode13.Text = "死亡病例讨论";
            treeNode14.Name = "";
            treeNode14.Text = "手术后病程记录";
            treeNode15.Name = "";
            treeNode15.Text = "死亡记录";
            treeNode16.Name = "";
            treeNode16.Text = "出院记录";
            treeNode17.Name = "";
            treeNode17.Text = "抢救记录";
            treeNode18.Name = "节点2";
            treeNode18.Text = "术前小结";
            treeNode19.Name = "";
            treeNode19.Text = "病案记录";
            treeNode20.Name = "";
            treeNode20.Text = "会诊记录";
            treeNode21.Name = "";
            treeNode21.Text = "手术知情同意书";
            treeNode22.Name = "";
            treeNode22.Text = "术前小结";
            treeNode23.Name = "";
            treeNode23.Text = "手术记录单";
            treeNode24.Name = "";
            treeNode24.Text = "ICU转入记录";
            treeNode25.Name = "";
            treeNode25.Text = "ICU转出记录";
            treeNode26.Name = "";
            treeNode26.Text = "出院记录";
            treeNode27.Name = "";
            treeNode27.Text = "住院病案首页";
            treeNode28.Name = "";
            treeNode28.Text = "病案质量评分表";
            treeNode29.Name = "";
            treeNode29.Text = "病案生成";
            treeNode30.Name = "";
            treeNode30.Text = "B型超声显像检查申请单";
            treeNode31.Name = "";
            treeNode31.Text = "CT检查申请单";
            treeNode32.Name = "";
            treeNode32.Text = "X线申请单";
            treeNode33.Name = "";
            treeNode33.Text = "SPECT检查申请单";
            treeNode34.Name = "";
            treeNode34.Text = "高压氧治疗申请单";
            treeNode35.Name = "";
            treeNode35.Text = "病理活体组织送检单";
            treeNode36.Name = "";
            treeNode36.Text = "MRI申请单";
            treeNode37.Name = "";
            treeNode37.Text = "心电图申请单";
            treeNode38.Name = "";
            treeNode38.Text = "电脑多导睡眠图检查申请单";
            treeNode39.Name = "";
            treeNode39.Text = "核医学检查申请单";
            treeNode40.Name = "";
            treeNode40.Text = "申  请  单";
            treeNode41.Name = "";
            treeNode41.Text = "医生工作站";
            treeNode42.Name = "";
            treeNode42.Text = "病人入院评估表";
            treeNode43.Name = "";
            treeNode43.Text = "入院病人评估";
            treeNode44.Name = "";
            treeNode44.Text = "一般护理记录";
            treeNode45.Name = "";
            treeNode45.Text = "一般患者护理记录";
            treeNode46.Name = "";
            treeNode46.Text = "一般患者护理记录(病情记录)";
            treeNode47.Name = "";
            treeNode47.Text = "观察项目记录表";
            treeNode48.Name = "";
            treeNode48.Text = "危重患者护理记录";
            treeNode49.Name = "";
            treeNode49.Text = "危重患者护理记录(病情记录)";
            treeNode50.Name = "";
            treeNode50.Text = "危重症监护中心特护记录单";
            treeNode51.Name = "";
            treeNode51.Text = "手术护理记录";
            treeNode52.Name = "";
            treeNode52.Text = "手术器械、敷料点数表";
            treeNode53.Name = "";
            treeNode53.Text = "中心ICU呼吸机治疗监护记录单";
            treeNode54.Name = "";
            treeNode54.Text = "心血管外科特护记录";
            treeNode55.Name = "";
            treeNode55.Text = "ICU护理记录";
            treeNode56.Name = "";
            treeNode56.Text = "护士工作站";
            this.m_trvForms.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode41,
            treeNode56});
            this.m_trvForms.Size = new System.Drawing.Size(220, 264);
            this.m_trvForms.TabIndex = 0;
            this.m_trvForms.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_trvForms_BeforeExpand);
            this.m_trvForms.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trvForms_AfterSelect);
            // 
            // m_trvTemplate
            // 
            this.m_trvTemplate.BackColor = System.Drawing.SystemColors.Window;
            this.m_trvTemplate.ContextMenuStrip = this.contextMenuStrip1;
            this.m_trvTemplate.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_trvTemplate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_trvTemplate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_trvTemplate.HideSelection = false;
            this.m_trvTemplate.HotTracking = true;
            this.m_trvTemplate.Indent = 22;
            this.m_trvTemplate.Location = new System.Drawing.Point(14, 344);
            this.m_trvTemplate.Name = "m_trvTemplate";
            this.m_trvTemplate.Size = new System.Drawing.Size(222, 284);
            this.m_trvTemplate.TabIndex = 15040;
            this.m_trvTemplate.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_trvTemplate_BeforeExpand);
            this.m_trvTemplate.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trvTemplate_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tsmiCopyTemplate});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 26);
            // 
            // m_tsmiCopyTemplate
            // 
            this.m_tsmiCopyTemplate.AccessibleDescription = "复制模板";
            this.m_tsmiCopyTemplate.Name = "m_tsmiCopyTemplate";
            this.m_tsmiCopyTemplate.Size = new System.Drawing.Size(122, 22);
            this.m_tsmiCopyTemplate.Text = "复制模板";
            this.m_tsmiCopyTemplate.Visible = false;
            this.m_tsmiCopyTemplate.Click += new System.EventHandler(this.m_tsmiCopyTemplate_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label10.Location = new System.Drawing.Point(16, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 14);
            this.label10.TabIndex = 15039;
            this.label10.Text = "请选择具体表单:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(244, 320);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 14);
            this.label9.TabIndex = 15037;
            this.label9.Text = "模板具体内容:";
            // 
            // m_txtTemplateContent
            // 
            this.m_txtTemplateContent.BackColor = System.Drawing.Color.White;
            this.m_txtTemplateContent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTemplateContent.ForeColor = System.Drawing.Color.Black;
            this.m_txtTemplateContent.Location = new System.Drawing.Point(244, 344);
            this.m_txtTemplateContent.Multiline = true;
            this.m_txtTemplateContent.Name = "m_txtTemplateContent";
            this.m_txtTemplateContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_txtTemplateContent.Size = new System.Drawing.Size(288, 252);
            this.m_txtTemplateContent.TabIndex = 15036;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(282, 605);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 16);
            this.label12.TabIndex = 15020;
            this.label12.Text = "创建人：";
            this.label12.Visible = false;
            // 
            // m_lsvTemplateset
            // 
            this.m_lsvTemplateset.BackColor = System.Drawing.SystemColors.Window;
            this.m_lsvTemplateset.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.m_lsvTemplateset.ForeColor = System.Drawing.Color.Black;
            this.m_lsvTemplateset.FullRowSelect = true;
            this.m_lsvTemplateset.GridLines = true;
            this.m_lsvTemplateset.HideSelection = false;
            this.m_lsvTemplateset.Location = new System.Drawing.Point(536, 32);
            this.m_lsvTemplateset.MultiSelect = false;
            this.m_lsvTemplateset.Name = "m_lsvTemplateset";
            this.m_lsvTemplateset.Size = new System.Drawing.Size(256, 272);
            this.m_lsvTemplateset.TabIndex = 240;
            this.m_lsvTemplateset.UseCompatibleStateImageBehavior = false;
            this.m_lsvTemplateset.View = System.Windows.Forms.View.Details;
            this.m_lsvTemplateset.SelectedIndexChanged += new System.EventHandler(this.m_lsvTemplateset_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "具体项目";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "模板名称";
            this.columnHeader2.Width = 0;
            // 
            // m_glbTemplateType
            // 
            this.m_glbTemplateType.Controls.Add(this.m_txtTemplateName);
            this.m_glbTemplateType.Controls.Add(this.m_lsvDisease);
            this.m_glbTemplateType.Controls.Add(this.m_cboKeyword);
            this.m_glbTemplateType.Controls.Add(this.label2);
            this.m_glbTemplateType.Controls.Add(this.m_cboOperation);
            this.m_glbTemplateType.Controls.Add(this.label8);
            this.m_glbTemplateType.Controls.Add(this.m_cboDisease);
            this.m_glbTemplateType.Controls.Add(this.label7);
            this.m_glbTemplateType.Controls.Add(this.lblTemplateType);
            this.m_glbTemplateType.Controls.Add(this.label14);
            this.m_glbTemplateType.Controls.Add(this.m_cmdDiseaseSelect);
            this.m_glbTemplateType.Controls.Add(this.m_cmdDel);
            this.m_glbTemplateType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_glbTemplateType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_glbTemplateType.Location = new System.Drawing.Point(244, 32);
            this.m_glbTemplateType.Name = "m_glbTemplateType";
            this.m_glbTemplateType.Size = new System.Drawing.Size(284, 272);
            this.m_glbTemplateType.TabIndex = 131;
            this.m_glbTemplateType.TabStop = false;
            this.m_glbTemplateType.Text = "模板基本信息";
            // 
            // m_txtTemplateName
            // 
            this.m_txtTemplateName.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtTemplateName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTemplateName.ForeColor = System.Drawing.Color.Black;
            this.m_txtTemplateName.Location = new System.Drawing.Point(76, 32);
            this.m_txtTemplateName.MaxLength = 25;
            this.m_txtTemplateName.Name = "m_txtTemplateName";
            this.m_txtTemplateName.Size = new System.Drawing.Size(196, 23);
            this.m_txtTemplateName.TabIndex = 15006;
            // 
            // m_lsvDisease
            // 
            this.m_lsvDisease.BackColor = System.Drawing.Color.White;
            this.m_lsvDisease.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.m_lsvDisease.ForeColor = System.Drawing.Color.Black;
            this.m_lsvDisease.FullRowSelect = true;
            this.m_lsvDisease.GridLines = true;
            this.m_lsvDisease.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvDisease.HideSelection = false;
            this.m_lsvDisease.Location = new System.Drawing.Point(72, 100);
            this.m_lsvDisease.Name = "m_lsvDisease";
            this.m_lsvDisease.Size = new System.Drawing.Size(200, 124);
            this.m_lsvDisease.TabIndex = 15050;
            this.m_lsvDisease.UseCompatibleStateImageBehavior = false;
            this.m_lsvDisease.View = System.Windows.Forms.View.Details;
            this.m_lsvDisease.DoubleClick += new System.EventHandler(this.m_cmdDel_Click);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            this.columnHeader3.Width = 190;
            // 
            // m_cboKeyword
            // 
            this.m_cboKeyword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.m_cboKeyword.BorderColor = System.Drawing.Color.Black;
            this.m_cboKeyword.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboKeyword.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboKeyword.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboKeyword.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboKeyword.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboKeyword.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboKeyword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboKeyword.ListBackColor = System.Drawing.Color.White;
            this.m_cboKeyword.ListForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboKeyword.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboKeyword.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
            this.m_cboKeyword.Location = new System.Drawing.Point(76, 64);
            this.m_cboKeyword.m_BlnEnableItemEventMenu = true;
            this.m_cboKeyword.Name = "m_cboKeyword";
            this.m_cboKeyword.SelectedIndex = -1;
            this.m_cboKeyword.SelectedItem = null;
            this.m_cboKeyword.SelectionStart = 0;
            this.m_cboKeyword.Size = new System.Drawing.Size(196, 23);
            this.m_cboKeyword.TabIndex = 15045;
            this.m_cboKeyword.TextBackColor = System.Drawing.Color.White;
            this.m_cboKeyword.TextForeColor = System.Drawing.Color.Black;
            this.m_cboKeyword.DropDown += new System.EventHandler(this.m_cboKeyword_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 15007;
            this.label2.Text = "模板名称:";
            // 
            // m_cboOperation
            // 
            this.m_cboOperation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.m_cboOperation.BorderColor = System.Drawing.Color.Black;
            this.m_cboOperation.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboOperation.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboOperation.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboOperation.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOperation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOperation.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboOperation.ListBackColor = System.Drawing.Color.White;
            this.m_cboOperation.ListForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboOperation.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboOperation.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
            this.m_cboOperation.Location = new System.Drawing.Point(76, 244);
            this.m_cboOperation.m_BlnEnableItemEventMenu = true;
            this.m_cboOperation.Name = "m_cboOperation";
            this.m_cboOperation.SelectedIndex = -1;
            this.m_cboOperation.SelectedItem = null;
            this.m_cboOperation.SelectionStart = 0;
            this.m_cboOperation.Size = new System.Drawing.Size(24, 23);
            this.m_cboOperation.TabIndex = 3034;
            this.m_cboOperation.TextBackColor = System.Drawing.Color.White;
            this.m_cboOperation.TextForeColor = System.Drawing.Color.Black;
            this.m_cboOperation.Visible = false;
            this.m_cboOperation.DropDown += new System.EventHandler(this.m_cboOperation_DropDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(4, 248);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 3035;
            this.label8.Text = "手术名称:";
            this.label8.Visible = false;
            // 
            // m_cboDisease
            // 
            this.m_cboDisease.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.m_cboDisease.BorderColor = System.Drawing.Color.Black;
            this.m_cboDisease.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboDisease.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboDisease.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboDisease.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboDisease.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDisease.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDisease.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboDisease.ListBackColor = System.Drawing.Color.White;
            this.m_cboDisease.ListForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboDisease.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboDisease.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
            this.m_cboDisease.Location = new System.Drawing.Point(76, 244);
            this.m_cboDisease.m_BlnEnableItemEventMenu = true;
            this.m_cboDisease.Name = "m_cboDisease";
            this.m_cboDisease.SelectedIndex = -1;
            this.m_cboDisease.SelectedItem = null;
            this.m_cboDisease.SelectionStart = 0;
            this.m_cboDisease.Size = new System.Drawing.Size(24, 23);
            this.m_cboDisease.TabIndex = 3033;
            this.m_cboDisease.TextBackColor = System.Drawing.Color.White;
            this.m_cboDisease.TextForeColor = System.Drawing.Color.Black;
            this.m_cboDisease.Visible = false;
            this.m_cboDisease.DropDown += new System.EventHandler(this.m_cboDisease_DropDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(4, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 14);
            this.label7.TabIndex = 3032;
            this.label7.Text = "病名:";
            this.label7.Visible = false;
            // 
            // lblTemplateType
            // 
            this.lblTemplateType.AutoSize = true;
            this.lblTemplateType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTemplateType.ForeColor = System.Drawing.Color.Black;
            this.lblTemplateType.Location = new System.Drawing.Point(8, 68);
            this.lblTemplateType.Name = "lblTemplateType";
            this.lblTemplateType.Size = new System.Drawing.Size(42, 14);
            this.lblTemplateType.TabIndex = 3028;
            this.lblTemplateType.Text = "分类:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(8, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 14);
            this.label14.TabIndex = 3028;
            this.label14.Text = "国际疾病:";
            // 
            // m_cmdDiseaseSelect
            // 
            this.m_cmdDiseaseSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdDiseaseSelect.DefaultScheme = true;
            this.m_cmdDiseaseSelect.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDiseaseSelect.ForeColor = System.Drawing.Color.Black;
            this.m_cmdDiseaseSelect.Hint = "";
            this.m_cmdDiseaseSelect.Location = new System.Drawing.Point(140, 232);
            this.m_cmdDiseaseSelect.Name = "m_cmdDiseaseSelect";
            this.m_cmdDiseaseSelect.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDiseaseSelect.Size = new System.Drawing.Size(60, 28);
            this.m_cmdDiseaseSelect.TabIndex = 10000001;
            this.m_cmdDiseaseSelect.Text = "添 加";
            // 
            // m_cmdDel
            // 
            this.m_cmdDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdDel.DefaultScheme = true;
            this.m_cmdDel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDel.ForeColor = System.Drawing.Color.Black;
            this.m_cmdDel.Hint = "";
            this.m_cmdDel.Location = new System.Drawing.Point(208, 232);
            this.m_cmdDel.Name = "m_cmdDel";
            this.m_cmdDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDel.Size = new System.Drawing.Size(60, 28);
            this.m_cmdDel.TabIndex = 10000001;
            this.m_cmdDel.Text = "删 除";
            this.m_cmdDel.Click += new System.EventHandler(this.m_cmdDel_Click);
            // 
            // m_cmdModifyBase
            // 
            this.m_cmdModifyBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdModifyBase.DefaultScheme = true;
            this.m_cmdModifyBase.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdModifyBase.ForeColor = System.Drawing.Color.Black;
            this.m_cmdModifyBase.Hint = "";
            this.m_cmdModifyBase.Location = new System.Drawing.Point(504, 600);
            this.m_cmdModifyBase.Name = "m_cmdModifyBase";
            this.m_cmdModifyBase.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdModifyBase.Size = new System.Drawing.Size(104, 32);
            this.m_cmdModifyBase.TabIndex = 10000001;
            this.m_cmdModifyBase.Text = "修改基本信息";
            this.m_cmdModifyBase.Visible = false;
            this.m_cmdModifyBase.Click += new System.EventHandler(this.m_cmdModifyBase_Click);
            // 
            // m_cmbForms
            // 
            this.m_cmbForms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_cmbForms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbForms.ForeColor = System.Drawing.Color.White;
            this.m_cmbForms.Location = new System.Drawing.Point(396, 64);
            this.m_cmbForms.MaxDropDownItems = 12;
            this.m_cmbForms.Name = "m_cmbForms";
            this.m_cmbForms.Size = new System.Drawing.Size(44, 22);
            this.m_cmbForms.TabIndex = 190;
            this.m_cmbForms.SelectedIndexChanged += new System.EventHandler(this.m_cmbForms_SelectedIndexChanged);
            // 
            // cmdClear
            // 
            this.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClear.Location = new System.Drawing.Point(874, 24);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(64, 32);
            this.cmdClear.TabIndex = 260;
            this.cmdClear.Text = "清空";
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtKeyword);
            this.groupBox1.Controls.Add(this.lstTemplateIDs);
            this.groupBox1.Controls.Add(this.cmdRemoveTemplate);
            this.groupBox1.Controls.Add(this.cmdAddTemplate);
            this.groupBox1.Controls.Add(this.m_lstTemplates);
            this.groupBox1.Controls.Add(this.m_lstControls);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.m_dtpEndDate);
            this.groupBox1.Controls.Add(this.m_dtpStartDate);
            this.groupBox1.Controls.Add(this.m_rdbBAXT);
            this.groupBox1.Controls.Add(this.m_rdbKeyWord);
            this.groupBox1.Controls.Add(this.m_rdbICD10);
            this.groupBox1.Controls.Add(this.lstICD10);
            this.groupBox1.Controls.Add(this.m_txtTemplateID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.m_txtKeywordPY);
            this.groupBox1.Controls.Add(this.cmdClear);
            this.groupBox1.Controls.Add(this.m_cmbForms);
            this.groupBox1.Location = new System.Drawing.Point(16, 716);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 12);
            this.groupBox1.TabIndex = 15024;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "no use";
            this.groupBox1.Visible = false;
            // 
            // m_txtKeyword
            // 
            this.m_txtKeyword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_txtKeyword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtKeyword.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtKeyword.ForeColor = System.Drawing.Color.White;
            this.m_txtKeyword.Location = new System.Drawing.Point(316, 60);
            this.m_txtKeyword.MaxLength = 25;
            this.m_txtKeyword.Name = "m_txtKeyword";
            this.m_txtKeyword.Size = new System.Drawing.Size(32, 19);
            this.m_txtKeyword.TabIndex = 15047;
            // 
            // lstTemplateIDs
            // 
            this.lstTemplateIDs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lstTemplateIDs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTemplateIDs.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstTemplateIDs.ForeColor = System.Drawing.Color.White;
            this.lstTemplateIDs.HorizontalScrollbar = true;
            this.lstTemplateIDs.ItemHeight = 14;
            this.lstTemplateIDs.Location = new System.Drawing.Point(460, 60);
            this.lstTemplateIDs.Name = "lstTemplateIDs";
            this.lstTemplateIDs.Size = new System.Drawing.Size(124, 28);
            this.lstTemplateIDs.TabIndex = 15036;
            this.lstTemplateIDs.Visible = false;
            this.lstTemplateIDs.DoubleClick += new System.EventHandler(this.lstTemplateIDs_DoubleClick);
            // 
            // cmdRemoveTemplate
            // 
            this.cmdRemoveTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRemoveTemplate.Location = new System.Drawing.Point(811, 24);
            this.cmdRemoveTemplate.Name = "cmdRemoveTemplate";
            this.cmdRemoveTemplate.Size = new System.Drawing.Size(64, 32);
            this.cmdRemoveTemplate.TabIndex = 15035;
            this.cmdRemoveTemplate.Text = "↑";
            // 
            // cmdAddTemplate
            // 
            this.cmdAddTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAddTemplate.Location = new System.Drawing.Point(748, 24);
            this.cmdAddTemplate.Name = "cmdAddTemplate";
            this.cmdAddTemplate.Size = new System.Drawing.Size(64, 32);
            this.cmdAddTemplate.TabIndex = 15034;
            this.cmdAddTemplate.Text = "↓";
            // 
            // m_lstTemplates
            // 
            this.m_lstTemplates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_lstTemplates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_lstTemplates.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lstTemplates.ForeColor = System.Drawing.Color.White;
            this.m_lstTemplates.HorizontalScrollbar = true;
            this.m_lstTemplates.ItemHeight = 16;
            this.m_lstTemplates.Location = new System.Drawing.Point(620, 28);
            this.m_lstTemplates.Name = "m_lstTemplates";
            this.m_lstTemplates.Size = new System.Drawing.Size(116, 32);
            this.m_lstTemplates.TabIndex = 15033;
            // 
            // m_lstControls
            // 
            this.m_lstControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_lstControls.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_lstControls.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lstControls.ForeColor = System.Drawing.Color.White;
            this.m_lstControls.HorizontalScrollbar = true;
            this.m_lstControls.ItemHeight = 16;
            this.m_lstControls.Location = new System.Drawing.Point(212, 52);
            this.m_lstControls.Name = "m_lstControls";
            this.m_lstControls.Size = new System.Drawing.Size(64, 32);
            this.m_lstControls.TabIndex = 15032;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(456, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 15031;
            this.label6.Text = "停用时间:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(300, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 15030;
            this.label5.Text = "启用时间:";
            // 
            // m_dtpEndDate
            // 
            this.m_dtpEndDate.BorderColor = System.Drawing.Color.White;
            this.m_dtpEndDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpEndDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_dtpEndDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpEndDate.DropButtonForeColor = System.Drawing.Color.White;
            this.m_dtpEndDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpEndDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpEndDate.Location = new System.Drawing.Point(536, 32);
            this.m_dtpEndDate.m_BlnOnlyTime = false;
            this.m_dtpEndDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpEndDate.Name = "m_dtpEndDate";
            this.m_dtpEndDate.ReadOnly = false;
            this.m_dtpEndDate.Size = new System.Drawing.Size(56, 22);
            this.m_dtpEndDate.TabIndex = 15029;
            this.m_dtpEndDate.TextBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_dtpEndDate.TextForeColor = System.Drawing.Color.White;
            // 
            // m_dtpStartDate
            // 
            this.m_dtpStartDate.BorderColor = System.Drawing.Color.White;
            this.m_dtpStartDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpStartDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_dtpStartDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpStartDate.DropButtonForeColor = System.Drawing.Color.White;
            this.m_dtpStartDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpStartDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpStartDate.Location = new System.Drawing.Point(388, 32);
            this.m_dtpStartDate.m_BlnOnlyTime = false;
            this.m_dtpStartDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpStartDate.Name = "m_dtpStartDate";
            this.m_dtpStartDate.ReadOnly = false;
            this.m_dtpStartDate.Size = new System.Drawing.Size(56, 22);
            this.m_dtpStartDate.TabIndex = 15028;
            this.m_dtpStartDate.TextBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_dtpStartDate.TextForeColor = System.Drawing.Color.White;
            // 
            // m_rdbBAXT
            // 
            this.m_rdbBAXT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rdbBAXT.Location = new System.Drawing.Point(180, 52);
            this.m_rdbBAXT.Name = "m_rdbBAXT";
            this.m_rdbBAXT.Size = new System.Drawing.Size(12, 24);
            this.m_rdbBAXT.TabIndex = 15027;
            this.m_rdbBAXT.Text = "八大系统";
            // 
            // m_rdbKeyWord
            // 
            this.m_rdbKeyWord.Checked = true;
            this.m_rdbKeyWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rdbKeyWord.Location = new System.Drawing.Point(160, 52);
            this.m_rdbKeyWord.Name = "m_rdbKeyWord";
            this.m_rdbKeyWord.Size = new System.Drawing.Size(12, 24);
            this.m_rdbKeyWord.TabIndex = 15026;
            this.m_rdbKeyWord.TabStop = true;
            this.m_rdbKeyWord.Text = "关键字";
            // 
            // m_rdbICD10
            // 
            this.m_rdbICD10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rdbICD10.Location = new System.Drawing.Point(136, 52);
            this.m_rdbICD10.Name = "m_rdbICD10";
            this.m_rdbICD10.Size = new System.Drawing.Size(16, 24);
            this.m_rdbICD10.TabIndex = 15025;
            this.m_rdbICD10.Text = "ICD - 10";
            // 
            // lstICD10
            // 
            this.lstICD10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lstICD10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstICD10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstICD10.ForeColor = System.Drawing.Color.White;
            this.lstICD10.ItemHeight = 14;
            this.lstICD10.Location = new System.Drawing.Point(136, 28);
            this.lstICD10.Name = "lstICD10";
            this.lstICD10.Size = new System.Drawing.Size(152, 16);
            this.lstICD10.TabIndex = 15024;
            this.lstICD10.Visible = false;
            // 
            // m_txtTemplateID
            // 
            this.m_txtTemplateID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_txtTemplateID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtTemplateID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTemplateID.ForeColor = System.Drawing.Color.White;
            this.m_txtTemplateID.Location = new System.Drawing.Point(96, 60);
            this.m_txtTemplateID.Name = "m_txtTemplateID";
            this.m_txtTemplateID.Size = new System.Drawing.Size(24, 19);
            this.m_txtTemplateID.TabIndex = 15022;
            this.m_txtTemplateID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtTemplateID_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 15023;
            this.label3.Text = "模板编号:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 3048;
            this.label4.Text = "拼音首码";
            this.label4.Visible = false;
            // 
            // m_txtKeywordPY
            // 
            this.m_txtKeywordPY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_txtKeywordPY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtKeywordPY.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtKeywordPY.ForeColor = System.Drawing.Color.White;
            this.m_txtKeywordPY.Location = new System.Drawing.Point(92, 28);
            this.m_txtKeywordPY.Name = "m_txtKeywordPY";
            this.m_txtKeywordPY.Size = new System.Drawing.Size(24, 19);
            this.m_txtKeywordPY.TabIndex = 3047;
            this.m_txtKeywordPY.Visible = false;
            // 
            // frmTemplateSet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(808, 653);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_glbTemplateset);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTemplateSet";
            this.Text = "模板维护";
            this.Load += new System.EventHandler(this.frmTemplateSet_Load);
            this.m_glbTemplateset.ResumeLayout(false);
            this.m_glbTemplateset.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.m_glbTemplateType.ResumeLayout(false);
            this.m_glbTemplateType.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void m_cmbForms_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int intIndex=this.m_cmbForms.SelectedIndex ;
			if(intIndex <0 || intIndex >=this.m_cmbForms.Items.Count )return;
			if(m_objFormListArr !=null && m_objFormListArr.Length > intIndex )
			{
				string strFormID=m_objFormListArr [intIndex ].m_strForm_ID ;
				m_strFormID=strFormID ;
				m_objControls =m_objDomain.lngGetAllControls (strFormID);
				this.m_lstControls.Items.Clear ();
				this.m_lstTemplates.Items.Clear ();
				if(m_objControls!=null && m_objControls.Length >0)
					for(int i=0;i<m_objControls.Length ;i++)
						this.m_lstControls.Items.Add (m_objControls[i].m_strControl_Desc ); 

				m_mthGetAllTemplateByForm(strFormID);
			}
		}

		private void m_lstControls_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int intIndex=this.m_lstControls.SelectedIndex ;
			if(intIndex <0 || intIndex >=this.m_lstControls.Items.Count )return;
			this.m_lstTemplates.Items.Clear ();
			if(m_objControls !=null && m_objControls.Length >intIndex )
			{
				m_strControlID =m_objControls[intIndex].m_strControl_ID ;
				m_objTemplateFromControl =m_objDomain.lngGetAllTemplateFormControl (m_strFormID ,m_strControlID,MDIParent.OperatorID  );
				if(m_objTemplateFromControl !=null && m_objTemplateFromControl.Length >0)
					for(int i=0;i<m_objTemplateFromControl.Length ;i++)
						this.m_lstTemplates.Items.Add (m_objTemplateFromControl[i].m_strTemplate_ID  + "    " +m_objTemplateFromControl[i].m_strTemplate_Name );  
			}
		}

		private void cmdAddTemplate_Click(object sender, System.EventArgs e)
		{
			if(m_strControlID=="" || m_strFormID=="" || m_strTemplateID=="")return;
			if(this.m_cmbForms.SelectedIndex <0 || this.m_cmbForms.SelectedIndex >=this.m_cmbForms.Items.Count )
				return;
			if(this.m_lstControls.SelectedIndex<0 || this.m_lstControls.SelectedIndex >=this.m_lstControls.Items.Count )
				return;   
			ListViewItem objItem=new ListViewItem  ();
			objItem.Text =this.m_cmbForms.Text + " - " + this.m_lstControls.Text;
			for(int i=0;i<m_objArrTemplateSet.Count ;i++)
			{
				clsTemplateFormControlValue objTemplateFormControl1=(clsTemplateFormControlValue)m_objArrTemplateSet[i];
				if(m_strControlID==objTemplateFormControl1.m_strControl_ID &&  m_strFormID==objTemplateFormControl1.m_strForm_ID )
				{
					clsPublicFunction.ShowInformationMessageBox  ("该文本框已经被一个模板(" + objTemplateFormControl1.m_strTemplate_ID + ")锁定,请删除原来的模板进行添加!");
					return;
				}
			}
			if(m_objTemplateFromControl ==null || m_objTemplateFromControl.Length <=0)return;
			objItem.SubItems.Add (m_objTemplateFromControl[m_intSelectTemplateIndex].m_strTemplate_Name );
			this.m_lsvTemplateset.Items.Add (objItem );

			clsTemplateFormControlValue objTemplateFormControl=new clsTemplateFormControlValue();
			objTemplateFormControl.m_strControl_ID =m_strControlID ;
			objTemplateFormControl.m_strForm_ID =m_strFormID ;
			objTemplateFormControl.m_strTemplate_ID =m_strTemplateID ;

			m_objArrTemplateSet.Add (objTemplateFormControl );
			if(this.m_lsvTemplateset.Items.Count >0)
				this.m_cmbForms.Enabled =false;
			else
				this.m_cmbForms.Enabled =true;
			
		}

		private void m_lstTemplates_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int intIndex=m_lstTemplates.SelectedIndex ;
			if(intIndex <0 || intIndex>=this.m_lstTemplates.Items.Count )return; 
			if(m_objTemplateFromControl !=null && m_objTemplateFromControl.Length > intIndex)
			{
				m_strTemplateID = m_objTemplateFromControl[intIndex].m_strTemplate_ID ;
				m_intSelectTemplateIndex =intIndex ; 
			}
		}

		private void m_lsvTemplateset_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.m_lsvTemplateset.SelectedItems.Count <=0)
				return; 

			int intIndex=this.m_lsvTemplateset.SelectedItems[0].Index ;  
			m_intSelectTemplateSetIndex =intIndex ;

			m_mthGetTemplateContent();
		}

		/// <summary>
		/// 获取模板具体内容
		/// </summary>
		private void m_mthGetTemplateContent()
		{
			if(m_lsvTemplateset.SelectedItems.Count > 0 && m_lsvTemplateset.SelectedItems[0] != null)
			{
				string strContent = "";
				string strCreateID = "";
				string strCreateName = "";
				long lngRes = new clsTemplateDomain().m_lngGetTemplateContent(m_lsvTemplateset.SelectedItems[0].SubItems[1].Text,out strContent,out strCreateID,out strCreateName);
				m_txtTemplateContent.Text = strContent;
				lblCreator.Text = strCreateName;
			}
		}

		/// <summary>
		/// 修改模板具体内容
		/// </summary>
        private long m_mthModifyTemplateContent()
        {
            long lngRes = 0;
			if(m_lsvTemplateset.SelectedItems.Count > 0 && m_lsvTemplateset.SelectedItems[0] != null)
			{
//				if(clsPublicFunction.s_blnAskForModify())
//				{
                int intIndex = m_lsvTemplateset.SelectedItems[0].Index;
				if(m_rdbPublic.Checked)
				{
                    for (int i = 0; i < m_lsvTemplateset.Items.Count; i++)
                    {
                        if (intIndex == i)
                        {
                            lngRes = new clsTemplateDomain().m_lngModifyTemplateContent(m_lsvTemplateset.Items[i].SubItems[1].Text, m_txtTemplateContent.Text, "1");
                        }
                        else
                        {
                            lngRes = new clsTemplateDomain().m_lngModifyTemplateVisibitity(m_lsvTemplateset.Items[i].SubItems[1].Text, "1");
                        }
                        if (lngRes < 0)
                            return lngRes;
                    }
				}
				else if(m_rdbPrivate.Checked)
				{
                    for (int i = 0; i < m_lsvTemplateset.Items.Count; i++)
                    {
                        if (intIndex == i)
                        {
                            lngRes = new clsTemplateDomain().m_lngModifyTemplateContent(m_lsvTemplateset.Items[i].SubItems[1].Text, m_txtTemplateContent.Text, "0");
                        }
                        else
                        {
                            lngRes = new clsTemplateDomain().m_lngModifyTemplateVisibitity(m_lsvTemplateset.Items[i].SubItems[1].Text, "0");
                        }
                        if (lngRes < 0)
                            return lngRes;
                    }
				}
				else if(m_rdbDepartment.Checked)
				{
                    for (int i = 0; i < m_lsvTemplateset.Items.Count; i++)
                    {
                        if (intIndex == i)
                        {
                            lngRes = new clsTemplateDomain().m_lngModifyTemplateContent(m_lsvTemplateset.Items[i].SubItems[1].Text, m_txtTemplateContent.Text, "2");
                        }
                        else
                        {
                            lngRes = new clsTemplateDomain().m_lngModifyTemplateVisibitity(m_lsvTemplateset.Items[i].SubItems[1].Text, "2");
                        }
                        if (lngRes < 0)
                            return lngRes;
                    }
				}
//					if(lngRes > 0)
//						clsPublicFunction.ShowInformationMessageBox("修改成功！");
//				}
			}
			else
			{
				clsPublicFunction.ShowInformationMessageBox("请先选择模板！");
			}
            return lngRes;
		}

		private void cmdRemoveTemplate_Click(object sender, System.EventArgs e)
		{
			if(m_intSelectTemplateSetIndex<0 || m_intSelectTemplateSetIndex>=this.m_lsvTemplateset.Items.Count )return;
			this.m_lsvTemplateset.Items.RemoveAt (m_intSelectTemplateSetIndex); 
			m_objArrTemplateSet.RemoveAt (m_intSelectTemplateSetIndex );
			if(this.m_lsvTemplateset.Items.Count >0)
				this.m_cmbForms.Enabled =false;
			else
				this.m_cmbForms.Enabled =true;

		}

		private void m_txtKeyword_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode ==System.Windows.Forms.Keys.Escape )
				this.lstICD10.Visible =false;
			#region ICD-10键盘处理程序,刘颖源,2003-5-8 17:26:57
			if(this.m_rdbICD10.Checked )
			{
				if((e.KeyCode == System.Windows.Forms.Keys.Space || e.KeyCode ==System.Windows.Forms.Keys.Enter ) && this.lstICD10.Visible )
				{
					int intIndex=this.lstICD10.SelectedIndex ;
					if(intIndex>=0 && intIndex < this.lstICD10.Items.Count )
					{
						this.lstICD10.Visible =false;
						this.m_txtKeyword.Text = this.m_txtKeyword.Text + this.lstICD10.Text ; 
						this.m_txtKeyword.SelectionStart =this.m_txtKeyword.TextLength ;
						this.m_txtKeyword.SelectionLength =1;
					}
				}
				if(e.KeyCode ==System.Windows.Forms.Keys.Decimal || e.KeyCode ==System.Windows.Forms.Keys.OemPeriod)
				{
					int intLeftOff=m_txtKeyword.TextLength ;
					this.lstICD10.Left =this.m_glbTemplateset.Left +  this.m_glbTemplateType.Left +  this.m_txtKeyword.Left + intLeftOff;
					this.lstICD10.Top =this.m_glbTemplateset.Top + this.m_glbTemplateType.Top + this.m_txtKeyword.Top + this.m_txtKeyword.Height ;

					this.lstICD10.Items.Clear (); 
					int intPointnumber=0;
					string strText=this.m_txtKeyword.Text ;
					for(int i=0;i<strText.Length ;i++)
						if(strText[i]=='.')intPointnumber ++;
					m_intSelectICD10Level=intPointnumber ;
					switch(intPointnumber )
					{
						case 1:
							m_objICD10_IllnessSubID =m_objDomain.lngGetAllICD10_IllnessSubID (m_strSelectICD10_0ID );
							if(m_objICD10_IllnessSubID !=null && m_objICD10_IllnessSubID.Length >0)
							{
								for(int i=0;i<m_objICD10_IllnessSubID.Length ;i++)
									this.lstICD10.Items.Add (m_objICD10_IllnessSubID[i].m_strIllnessSubName); 
							}
							break;
						case 2:
							m_objICD10_IllnessDetail =m_objDomain.lngGetAllICD10_IllnessDetailID (m_strSelectICD10_1ID );
							if(m_objICD10_IllnessDetail !=null && m_objICD10_IllnessDetail.Length >0)
							{
								for(int i=0;i<m_objICD10_IllnessDetail.Length ;i++)
									this.lstICD10.Items.Add (m_objICD10_IllnessDetail[i].m_strIllnessDetailName ); 
							}
							break;
						case 0:
							m_objICD10_IllnessIDValue =m_objDomain.lngGetAllICD10_IllnessID ();
							if(m_objICD10_IllnessIDValue !=null && m_objICD10_IllnessIDValue.Length >0)
							{
								for(int i=0;i<m_objICD10_IllnessIDValue.Length ;i++)
									this.lstICD10.Items.Add (m_objICD10_IllnessIDValue[i].m_strIllnessName ); 
							}
							break;

						default:
							break;

					}
					if(this.lstICD10.Items.Count >0)
					{
						this.lstICD10.SelectedIndex =0;						
						this.lstICD10.Visible =true;
						this.lstICD10.BringToFront();						
						this.lstICD10.Focus ();
					}
				}
			}
			#endregion

			#region 八大系统键盘处理,刘颖源,2003-5-8 17:26:57
			if(this.m_rdbBAXT.Checked )
			{
				if((e.KeyCode == System.Windows.Forms.Keys.Space || e.KeyCode ==System.Windows.Forms.Keys.Enter ) && this.lstICD10.Visible )
				{
					int intIndex=this.lstICD10.SelectedIndex ;
					if(intIndex>=0 && intIndex < this.lstICD10.Items.Count )
					{
						this.lstICD10.Visible =false;
						this.m_txtKeyword.Text = this.m_txtKeyword.Text + this.lstICD10.Text ; 
						this.m_txtKeyword.SelectionStart =this.m_txtKeyword.TextLength ;
						this.m_txtKeyword.SelectionLength =1;
					}
				}
				if(e.KeyCode ==System.Windows.Forms.Keys.Decimal || e.KeyCode ==System.Windows.Forms.Keys.OemPeriod )
				{
					int intLeftOff=m_txtKeyword.TextLength ;
					this.lstICD10.Left =this.m_glbTemplateset.Left + this.m_glbTemplateType.Left +  this.m_txtKeyword.Left + intLeftOff;
					this.lstICD10.Top =this.m_glbTemplateset.Top + this.m_glbTemplateType.Top + this.m_txtKeyword.Top + this.m_txtKeyword.Height ;

					this.lstICD10.Items.Clear (); 
					int intPointnumber=0;
					string strText=this.m_txtKeyword.Text ;
					for(int i=0;i<strText.Length ;i++)
						if(strText[i]=='.')intPointnumber ++;
					m_intSelectSystem =intPointnumber ;
					switch(intPointnumber )
					{
						case 1:
							m_objBio_System_Detail  =m_objDomain.lngGetAllBio_System_Detail  (m_strSelectSystemID  );
							if(m_objBio_System_Detail !=null && m_objBio_System_Detail.Length >0)
							{
								for(int i=0;i<m_objBio_System_Detail.Length ;i++)
									this.lstICD10.Items.Add (m_objBio_System_Detail[i].m_strComponen_Name ); 
							}
							break;
						case 0:
							m_objBio_System  =m_objDomain.lngGetAllBio_System();
							if(m_objBio_System !=null && m_objBio_System.Length >0)
							{
								for(int i=0;i<m_objBio_System.Length ;i++)
									this.lstICD10.Items.Add (m_objBio_System[i].m_strSystem_Name  ); 
							}
							break;
						default:
							break;

					}
					if(this.lstICD10.Items.Count >0)
					{
						this.lstICD10.SelectedIndex =0;						
						this.lstICD10.Visible =true;
						this.lstICD10.BringToFront();						
						this.lstICD10.Focus ();
					}
				}
			}
			#endregion
		}

		private void lstICD10_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode ==System.Windows.Forms.Keys.Escape )
				this.lstICD10.Visible =false;
			#region ICD-10键盘处理程序,刘颖源,2003-5-8 17:26:57
			if(this.m_rdbICD10.Checked )
			{
				if((e.KeyCode == System.Windows.Forms.Keys.Space || e.KeyCode ==System.Windows.Forms.Keys.Enter ) && this.lstICD10.Visible )
				{
					int intIndex=this.lstICD10.SelectedIndex ;
					if(intIndex>=0 && intIndex < this.lstICD10.Items.Count )
					{
						switch(m_intSelectICD10Level )
						{
							case 1:
								if(m_objICD10_IllnessSubID !=null &&  m_objICD10_IllnessSubID.Length >intIndex )
								{
									m_strSelectICD10_1ID =m_objICD10_IllnessSubID[intIndex].m_strIllnessSubID ;
									this.m_txtKeywordPY.Text =m_objICD10_IllnessSubID[intIndex].m_strPYCode;
								}
								break;
							case 2:
								if(m_objICD10_IllnessDetail !=null && m_objICD10_IllnessDetail.Length > intIndex )
								{
									m_strSelectICD10_2D =m_objICD10_IllnessDetail[intIndex ].m_strIllnessDetailID;
									this.m_txtKeywordPY.Text =m_objICD10_IllnessDetail[intIndex ].m_strPYCode ;
								}
								break;
							default:			//选中0层了
								if(m_objICD10_IllnessIDValue !=null && m_objICD10_IllnessIDValue.Length >intIndex )
								{
									m_strSelectICD10_0ID = m_objICD10_IllnessIDValue[intIndex].m_strIllnessID ;
									this.m_txtKeywordPY.Text =m_objICD10_IllnessIDValue[intIndex].m_strPYCode ;
								}
								break;

						}

						this.lstICD10.Visible =false;
						this.m_txtKeyword.Text = this.m_txtKeyword.Text + this.lstICD10.Text ;						
						this.m_txtKeyword.SelectionStart =this.m_txtKeyword.TextLength ;
						this.m_txtKeyword.SelectionLength =1;
						this.m_txtKeyword.Focus ();
					}
				}
			}
			#endregion

			#region 八大系统,刘颖源,2003-5-8 17:38:38
			if(this.m_rdbBAXT.Checked )
			{
				if((e.KeyCode == System.Windows.Forms.Keys.Space || e.KeyCode ==System.Windows.Forms.Keys.Enter ) && this.lstICD10.Visible )
				{
					int intIndex=this.lstICD10.SelectedIndex ;
					if(intIndex>=0 && intIndex < this.lstICD10.Items.Count )
					{
						switch(m_intSelectSystem  )
						{
							case 1:
								if(m_objBio_System_Detail  !=null &&  m_objBio_System_Detail.Length >intIndex )
								{
									m_strSelectSystemDetailID  =m_objBio_System_Detail[intIndex].m_strComponen_ID  ;
								}
								break;
							default:			//选中0层了
								if(m_objBio_System  !=null && m_objBio_System.Length >intIndex )
								{
									m_strSelectSystemID  = m_objBio_System[intIndex].m_strSystem_ID  ;
								}
								break;


						}

						this.lstICD10.Visible =false;
						this.m_txtKeyword.Text = this.m_txtKeyword.Text + this.lstICD10.Text ; 
						this.m_txtKeyword.SelectionStart =this.m_txtKeyword.TextLength ;
						this.m_txtKeyword.SelectionLength =1;
						this.m_txtKeyword.Focus ();
					}
				}
			}
			#endregion


		}

		private void m_rdbICD10_CheckedChanged(object sender, System.EventArgs e)
		{
			this.m_txtKeyword.Text ="";
			this.m_txtKeywordPY.Text =""; 
			m_strSelectICD10_0ID ="";
			m_strSelectICD10_1ID ="";
			m_strSelectICD10_2D ="";
			m_strSelectSystemDetailID ="";
			m_strSelectSystemID ="";
			this.lblTemplateType.Text ="ICD - 10编号"; 
			this.m_txtKeywordPY.Enabled =false; 

		}

		private void m_rdbKeyWord_CheckedChanged(object sender, System.EventArgs e)
		{
			this.m_txtKeyword.Text ="";
			this.m_txtKeywordPY.Text =""; 
			m_strSelectICD10_0ID ="";
			m_strSelectICD10_1ID ="";
			m_strSelectICD10_2D ="";
			m_strSelectSystemDetailID ="";
			m_strSelectSystemID ="";
			this.lblTemplateType.Text ="关键字";
			this.m_txtKeywordPY.Enabled =true;

		}

		private void m_rdbBAXT_CheckedChanged(object sender, System.EventArgs e)
		{
			this.m_txtKeyword.Text ="";
			this.m_txtKeywordPY.Text =""; 
			m_strSelectICD10_0ID ="";
			m_strSelectICD10_1ID ="";
			m_strSelectICD10_2D ="";
			m_strSelectSystemDetailID ="";
			m_strSelectSystemID ="";
			this.lblTemplateType.Text ="八大系统"; 
			this.m_txtKeywordPY.Enabled =false;
		}
		
		#region 私有函数,刘颖源,2003-5-9 11:05:50
		/// <summary>
		/// 清空
		/// </summary>
		private void m_mthClearInterface()
		{
			this.m_txtKeyword.Text ="";
			this.m_txtTemplateName.Text ="";
			this.m_txtKeywordPY.Text ="";
			this.m_rdbKeyWord.Checked =true;
			this.m_dtpStartDate.Value =DateTime.Now ;
			this.m_dtpEndDate.Value =DateTime.Now.AddYears (100);
		}
		private void m_mthSaveTemplateSet()
		{
			if(this.m_txtTemplateName.Text.Trim() =="" || this.m_cboKeyword.Text.Trim() =="")
			{
				clsPublicFunction.ShowInformationMessageBox("请输入模板名称或分类!");
				return;
			}
			if(this.m_lsvTemplateset.Items.Count <=0)
			{
				clsPublicFunction.ShowInformationMessageBox ("请至少添加一个模板到套装模板中!");
				return;
			}
			string strTemplateID = "";
			string strFormName = "";
//			strTemplateID =m_objDomain.strGetTemplateSetID ();
//			if(strTemplateID ==null || strTemplateID =="")strTemplateID ="000001";
			string strCurrentDate=DateTime.Now.ToString ("yyyy-MM-dd HH:mm:ss");
			clsTempate_SetValue objTemplateValueExist=null;
			objTemplateValueExist=m_objDomain.lngGetTemplateSet (this.m_txtTemplateID.Text);
			bool blnInsert=true;
			if(objTemplateValueExist !=null)
			{
				if(clsPublicFunction.ShowQuestionMessageBox( "模板已经存在(" + objTemplateValueExist.m_strSet_ID  + "),是否修改?")==System.Windows.Forms.DialogResult.No  )
					return;
				else
				{
					blnInsert=false;
					strTemplateID=this.m_txtTemplateID.Text ;
				}
			}

			#region clsTempate_SetValue,刘颖源,2003-5-9 11:05:50
			clsTempate_SetValue objTemplate_Set=new clsTempate_SetValue();
//			if(blnInsert)
//			{
				objTemplate_Set.m_strSet_ID =strTemplateID ;
				objTemplate_Set.m_strStart_Date = this.m_dtpStartDate.Value.ToString ();
				objTemplate_Set.m_strEnd_Date =this.m_dtpEndDate.Value.ToString (); 
//			}
//			else
//				objTemplate_Set=null;
			#endregion

			#region clsTemplate_Set_Detail_01Value,刘颖源,2003-5-9 14:37:44
			clsTemplate_Set_Detail_01Value[] objTemplate_Set_Detail01=new clsTemplate_Set_Detail_01Value[1];
			objTemplate_Set_Detail01[0]=new clsTemplate_Set_Detail_01Value();
			objTemplate_Set_Detail01[0].m_strSet_ID =strTemplateID ;
			objTemplate_Set_Detail01[0].m_strActivity_Date =strCurrentDate ;
			objTemplate_Set_Detail01[0].m_strSet_Name =this.m_txtTemplateName.Text ;
			#endregion
		
			#region clsTemplate_Set_Detail_02Value,刘颖源,2003-5-9 14:44:54
			clsTemplate_Set_Detail_02Value [] objTemplate_Set_Detail02=null;
			if(m_objArrTemplateSet !=null && m_objArrTemplateSet.Count>0)
			{
				objTemplate_Set_Detail02=new clsTemplate_Set_Detail_02Value[m_objArrTemplateSet.Count];
				for(int i=0;i<m_objArrTemplateSet.Count ;i++)
				{
					clsTemplateFormControlValue objTemplateFormControl=(clsTemplateFormControlValue)m_objArrTemplateSet [i];
					objTemplate_Set_Detail02[i] =new clsTemplate_Set_Detail_02Value();
					objTemplate_Set_Detail02[i].m_strActivity_Date =strCurrentDate ;
					objTemplate_Set_Detail02[i].m_strControl_ID =objTemplateFormControl.m_strControl_ID ;
					objTemplate_Set_Detail02[i].m_strForm_ID =objTemplateFormControl.m_strForm_ID ;
					objTemplate_Set_Detail02[i].m_strSet_ID =strTemplateID ; 
					objTemplate_Set_Detail02[i].m_strTemplate_ID = objTemplateFormControl.m_strTemplate_ID ;

					strFormName = objTemplateFormControl.m_strForm_ID;
				}
			}
			#endregion

			#region clsTemplate_Set_KeywordValue,刘颖源,2003-5-8 11:11:40
			clsTemplate_Set_KeywordValue [] objTemplate_Keyword=null;
			if(this.m_rdbKeyWord.Checked )
			{
				string strKeywords=this.m_txtKeyword.Text ;
				string strKeywordPYs=this.m_txtKeywordPY.Text ;
				string[] strKeywodArr= strKeywords.Split (',');
				string[] strKeywordPyArr=strKeywordPYs.Split (',');
				if(strKeywodArr.Length !=strKeywordPyArr.Length || strKeywodArr.Length <=0)
				{
					clsPublicFunction.ShowInformationMessageBox  ("关键字和对应的拼音码数目不相同或者没有输入关键字!");
					return;
				}
				objTemplate_Keyword=new clsTemplate_Set_KeywordValue [strKeywodArr.Length];
				for(int i=0;i<strKeywodArr.Length ;i++)
				{
					objTemplate_Keyword[i]=new clsTemplate_Set_KeywordValue ();
					objTemplate_Keyword[i].m_strSet_ID =strTemplateID ;
					objTemplate_Keyword[i].m_strActivity_Date =strCurrentDate ;
					objTemplate_Keyword[i].m_strKeyword =strKeywodArr[i];
					objTemplate_Keyword[i].m_strKeyword_PY =strKeywordPyArr[i];
					objTemplate_Keyword[i].m_strKeyword_Type ="1";
				}
			}
			else if(this.m_rdbICD10.Checked )
			{
				objTemplate_Keyword=new clsTemplate_Set_KeywordValue[1];
				objTemplate_Keyword[0]=new clsTemplate_Set_KeywordValue();
				if(m_strSelectICD10_2D=="" && m_strSelectICD10_1ID=="" && m_strSelectICD10_0ID=="")
				{
					clsPublicFunction.ShowInformationMessageBox  ("没有指定ICD - 10中的疾病");
					return;
				}
				objTemplate_Keyword[0].m_strActivity_Date =strCurrentDate ;
				objTemplate_Keyword[0].m_strSet_ID =strTemplateID ;
				if(m_strSelectICD10_2D  !="")
					objTemplate_Keyword[0].m_strKeyword =m_strSelectICD10_2D ;
				else if(m_strSelectICD10_1ID !="")
					objTemplate_Keyword[0].m_strKeyword =m_strSelectICD10_1ID ;
				else
					objTemplate_Keyword[0].m_strKeyword =m_strSelectICD10_0ID ;
				objTemplate_Keyword[0].m_strKeyword_PY =this.m_txtKeywordPY.Text  ;
				objTemplate_Keyword[0].m_strKeyword_Type ="0";
			}
			else
			{
				objTemplate_Keyword=new clsTemplate_Set_KeywordValue[1];
				objTemplate_Keyword[0]=new clsTemplate_Set_KeywordValue();
				if(m_strSelectSystemDetailID=="" && m_strSelectSystemID=="")
				{
					clsPublicFunction.ShowInformationMessageBox  ("没有指定系统或系统部位!");
					return;
				}
				objTemplate_Keyword[0].m_strActivity_Date =strCurrentDate ;
				objTemplate_Keyword[0].m_strSet_ID =strTemplateID ;
				if(m_strSelectSystemDetailID!="")
					objTemplate_Keyword[0].m_strKeyword =m_strSelectSystemDetailID ;
				else
					objTemplate_Keyword[0].m_strKeyword =m_strSelectSystemID  ;
				objTemplate_Keyword[0].m_strKeyword_PY =this.m_txtKeywordPY.Text;
				objTemplate_Keyword[0].m_strKeyword_Type ="2";

			}
			#endregion

			m_objDomain.lngSaveTemplateSet (blnInsert,objTemplate_Set ,objTemplate_Set_Detail01 ,objTemplate_Set_Detail02 ,objTemplate_Keyword,out strTemplateID );
		
			m_mthSaveTemplateSet_Associate(strTemplateID,strFormName);

			clsPublicFunction.ShowInformationMessageBox ("模板已经生成,编号为" + strTemplateID );
			this.m_txtTemplateID.Text =strTemplateID;
		}
		#endregion

		/// <summary>
		/// 保存套装模板所关联的字段
		/// </summary>
		private void m_mthSaveTemplateSet_Associate(string p_strTemplateID,string p_strFormName)
		{
			clsTemplateSet_Associate objDisease = new clsTemplateSet_Associate();
			string strDiseaseName = m_cboDisease.Text.Trim();
			objDisease.strAssociateID = (strDiseaseName == "") ? "" : m_objDomain.m_strGetAssociateIDByAssociateName(strDiseaseName,(int)enmAssociate.Disease);
			objDisease.strFormName = p_strFormName;
			objDisease.strTemplateSetID = p_strTemplateID;
			objDisease.strAssociateName = strDiseaseName;
			objDisease.intType = (int)enmAssociate.Disease;
			objDisease.strDeptID = clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID;
			m_objDomain.lngSaveTemplateSet_Associate(objDisease);

			clsTemplateSet_Associate objOperation = new clsTemplateSet_Associate();
			string strOperationName = m_cboOperation.Text.Trim();
			objOperation.strAssociateID = (strOperationName == "") ? "" : m_objDomain.m_strGetAssociateIDByAssociateName(strOperationName,(int)enmAssociate.Operation);
			objOperation.strFormName = p_strFormName;
			objOperation.strTemplateSetID = p_strTemplateID;
			objOperation.strAssociateName = strOperationName;
			objOperation.intType = (int)enmAssociate.Operation;
			objOperation.strDeptID = clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID;
			m_objDomain.lngSaveTemplateSet_Associate(objOperation);
		}

		private void cmdSaveTemplateSet_Click(object sender, System.EventArgs e)
		{
			//暂不修改其他信息
//			m_mthSaveTemplateSet();

			m_mthModifyTemplateBaseInfo();
			m_mthSaveICD10_TemplateSet(m_lsvDisease,m_strTemplateSetID);

            long lngRes = 0;
            lngRes = m_mthDelDeptInfo();
            if (lngRes <= 0)
            {
                clsPublicFunction.ShowInformationMessageBox("更新可见科室信息出错！");
                return;
            }
            lngRes = m_mthModifyTemplateContent();
            if (lngRes <= 0)
            {
                clsPublicFunction.ShowInformationMessageBox("更新模板内容出错！");
                return;
            }
            lngRes = m_mthModifyApplicability();
            if (lngRes <= 0)
            {
                clsPublicFunction.ShowInformationMessageBox("更新可见科室信息出错！");
                return;
            }

            clsPublicFunction.ShowInformationMessageBox("修改成功！");
            //m_trvTemplate.Nodes.Clear();
            //m_strFormID = m_strGetFormID(m_trvForms.SelectedNode.Text);
            //m_mthClear();
            //m_trvTemplate.Nodes.Clear();
            //m_mthGetAllTemplateByForm(m_strFormID);
		}

		private void m_lstTemplates_DoubleClick(object sender, System.EventArgs e)
		{
			cmdAddTemplate_Click(sender,e);
		}

		private void m_lsvTemplateset_DoubleClick(object sender, System.EventArgs e)
		{
			cmdRemoveTemplate_Click (sender,e);
		}

		private void lstICD10_Leave(object sender, System.EventArgs e)
		{
			this.lstICD10.Visible =false;
		}

		private void m_txtTemplateID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == System.Windows.Forms.Keys.Enter )
			{
				m_mthLoadTemplateSet(m_txtTemplateID);
			}
		}

		private void m_mthLoadTemplateSet(Control p_ctlParent)
		{
			if(p_ctlParent.Text =="" && m_cmbForms.SelectedItem != null)
			{
				clsEmployeeTemplateSetValue[] objTemplate_Detail=null;
//				long lngRes=m_objDomain.lngGetAllEmployeeTemplateSet(MDIParent.OperatorID ,out objTemplate_Detail);

				string strFormID = m_objFormListArr[m_cmbForms.SelectedIndex].m_strForm_ID;
				long lngRes=m_objDomain.lngGetAllEmployeeTemplateSetByFormAndKeyword(MDIParent.OperatorID ,strFormID,"假的",out objTemplate_Detail);
				
				this.lstTemplateIDs.Items.Clear ();
				if(objTemplate_Detail !=null && objTemplate_Detail.Length >0)
				{
					for(int i=0;i<objTemplate_Detail.Length ;i++)
						this.lstTemplateIDs.Items.Add (objTemplate_Detail[i]);
					this.lstTemplateIDs.Visible =true;
//					this.lstTemplateIDs.Left =p_ctlParent.Left ;
//					this.lstTemplateIDs.Top =p_ctlParent.Top + p_ctlParent.Height ;   
					this.lstTemplateIDs.SelectedIndex =0;
					this.lstTemplateIDs.Focus ();
				}
				return;

			}
			else
				m_mthReloadTemplateSet();
		}

		private string m_strTemplateSetID = "";

        clsTemplateSet_Gui_TargetValue[] m_objSelectedGUI_TargetValue = null;
		private void m_mthReloadTemplateSet()
		{
			clsTempate_SetValue[] objTemplateSetValue=null;			
			clsTemplate_Set_KeywordValue[] objTemplateSetKeyword=null;
			clsTemplateSet_Gui_TargetValue[] objTemplateSet_Gui_TargetValue=null;
			clsTemplate_Set_Detail_01Value [] objTemplateSet_Detail_01Value=null;
            m_objSelectedGUI_TargetValue = null;

			m_objDomain.lngGetTemplateSetInfo (m_strTemplateSetID ,out objTemplateSetValue,out objTemplateSetKeyword,out objTemplateSet_Gui_TargetValue,out objTemplateSet_Detail_01Value);

			m_mthClear();

			if(objTemplateSetValue !=null && objTemplateSetValue.Length ==1)
			{
				m_strTemplateSetID = objTemplateSetValue[0].m_strSet_ID ;

				//套装模板所对应的病名
				clsTemplateSet_Associate objAssociate;
				long lngRes = m_objDomain.m_lngGetAssociateBySetID(objTemplateSetValue[0].m_strSet_ID.Trim(),(int)enmAssociate.Disease, out objAssociate);
				if(lngRes > 0 && objAssociate != null)
					m_cboDisease.Text = objAssociate.strAssociateName;
				else
					m_cboDisease.Text = "";

				//套装模板所对应的手术名称
				clsTemplateSet_Associate objAssociate2;
				lngRes = m_objDomain.m_lngGetAssociateBySetID(objTemplateSetValue[0].m_strSet_ID.Trim(),(int)enmAssociate.Operation, out objAssociate2);
				if(lngRes > 0 && objAssociate2 != null)
					m_cboOperation.Text = objAssociate2.strAssociateName;
				else
					m_cboOperation.Text = "";

				this.m_dtpStartDate.Value =DateTime.Parse (objTemplateSetValue[0].m_strStart_Date );
				this.m_dtpEndDate.Value =DateTime.Parse (objTemplateSetValue[0].m_strEnd_Date ); 

				if(objTemplateSet_Detail_01Value!=null && objTemplateSet_Detail_01Value.Length >0)
				{
					this.m_txtTemplateName.Text =objTemplateSet_Detail_01Value[0].m_strSet_Name ; 
				}

				if(objTemplateSetKeyword!=null && objTemplateSetKeyword.Length >0)
				{
					switch(int.Parse (objTemplateSetKeyword[0].m_strKeyword_Type ))
					{
						case 0:
							this.m_rdbICD10.Checked =true;
							this.m_strSelectICD10_0ID=objTemplateSetKeyword[0].m_strKeyword ;
							this.m_strSelectICD10_1ID =m_strSelectICD10_0ID;
							this.m_strSelectICD10_2D  =m_strSelectICD10_0ID;
							break;
						case 1:
							this.m_rdbKeyWord.Checked =true;
							for(int i=0;i<objTemplateSetKeyword.Length ;i++)
							{
								this.m_cboKeyword.Text += objTemplateSetKeyword[i].m_strKeyword +"," ;
								this.m_txtKeywordPY.Text  +=objTemplateSetKeyword [i].m_strKeyword_PY +",";
							}
							if(this.m_cboKeyword.Text.Length >0)this.m_cboKeyword.Text= this.m_cboKeyword.Text.Substring (0,this.m_cboKeyword.Text.Length -1);
							if(this.m_txtKeywordPY.Text.Length >0)this.m_txtKeywordPY.Text= this.m_txtKeywordPY.Text.Substring (0,this.m_txtKeywordPY.Text.Length -1);
							break;
						case 2:
							this.m_rdbBAXT.Checked =true;
							this.m_strSelectSystemID =objTemplateSetKeyword[0].m_strKeyword ;
							this.m_strSelectSystemDetailID =objTemplateSetKeyword[0].m_strKeyword ;
							break;
					}
				}

				if(objTemplateSet_Gui_TargetValue !=null && objTemplateSet_Gui_TargetValue.Length >0)
				{
                    m_objSelectedGUI_TargetValue = objTemplateSet_Gui_TargetValue;
					if(m_objFormListArr !=null && m_objFormListArr.Length >0)
					{
						for(int i=0;i<m_objFormListArr.Length ;i++)
						{
							if(m_objFormListArr[i].m_strForm_ID ==objTemplateSet_Gui_TargetValue[0].m_strForm_ID )
							{
								this.m_cmbForms.SelectedIndex = i;
								break;
							}
						}
					}
					for(int i=0;i<objTemplateSet_Gui_TargetValue.Length ;i++)
					{
						ListViewItem objItem=new ListViewItem  ();
						objItem.Text = objTemplateSet_Gui_TargetValue[i].m_strControl_Desc ;
						objItem.SubItems.Add (objTemplateSet_Gui_TargetValue[i].m_strTemplate_ID);
						m_lsvTemplateset.Items.Add (objItem);

						clsTemplateFormControlValue objTemplateFormControl=new clsTemplateFormControlValue();
						objTemplateFormControl.m_strControl_ID =objTemplateSet_Gui_TargetValue[i].m_strControl_ID  ;
						objTemplateFormControl.m_strForm_ID =objTemplateSet_Gui_TargetValue[i].m_strForm_ID  ;
						objTemplateFormControl.m_strTemplate_ID =objTemplateSet_Gui_TargetValue[i].m_strTemplate_ID  ;

						m_objArrTemplateSet.Add(objTemplateFormControl);
					}

                    if (m_lsvTemplateset.Items.Count > 0)
                        m_lsvTemplateset.Items[0].Selected = true;
				}
			}
		}

		private void lstTemplateIDs_Leave(object sender, System.EventArgs e)
		{
			this.lstTemplateIDs.Visible =false;
		}

		private void lstTemplateIDs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode ==System.Windows.Forms.Keys.Enter )
			{
				string strText=this.lstTemplateIDs.Text;
				this.m_txtTemplateID.Text = ((clsEmployeeTemplateSetValue)lstTemplateIDs.SelectedItem).m_strSet_ID;  
				this.lstTemplateIDs.Visible =false;
				m_mthReloadTemplateSet();
			}

		}

		private void frmTemplateSet_Load(object sender, System.EventArgs e)
		{
			m_objHighLight.m_mthAddControlInContainer(this);	
		}

		#region Copy,Cut,Paste
		/// <summary>
		/// 复制操作
		/// </summary>
		/// <returns>操作结果</returns>
		public long m_lngCopy()
		{
			Control ctlControl = this.ActiveControl;
			string strTypeName = ctlControl.GetType().Name;
			if(strTypeName == "ctlRichTextBox" || strTypeName == "RichTextBox" || strTypeName == "TextBox" || strTypeName == "ctlBorderTextBox" || strTypeName == "DataGridTextBox")
			{
				switch(strTypeName)
				{
					case "ctlRichTextBox":
						if(((ctlRichTextBox)ctlControl).Text != "")
						{
							((ctlRichTextBox)ctlControl).Copy();
							return 1;
						}
						break;
					
					case "RichTextBox":
						if(((RichTextBox)ctlControl).Text != "")
						{
							((RichTextBox)ctlControl).Copy();
							return 1;
						}
						break;

					case "TextBox":
						if(((TextBox)ctlControl).Text != "")
						{
							((TextBox)ctlControl).Copy();
							return 1;
						}
						break;

					case "ctlBorderTextBox":
						if(((ctlBorderTextBox)ctlControl).Text != "")
						{
							((ctlBorderTextBox)ctlControl).Copy();
							return 1;
						}
						break;

					case "DataGridTextBox":
						if(((DataGridTextBox)ctlControl).Text != "")
						{
							((DataGridTextBox)ctlControl).Copy();
							return 1;
						}
						break;

					default:
						Clipboard.SetDataObject("");
						break;
				}
			}

			return 0;
		}

		/// <summary>
		/// 剪切操作
		/// </summary>
		/// <returns>操作结果</returns>
		public long m_lngCut()
		{
			Control ctlControl = this.ActiveControl;
			string strTypeName = ctlControl.GetType().Name;
			if(strTypeName == "ctlRichTextBox" || strTypeName == "RichTextBox" || strTypeName == "TextBox" || strTypeName == "ctlBorderTextBox" || strTypeName == "DataGridTextBox")
			{
				switch(strTypeName)
				{
					case "ctlRichTextBox":
						if(((ctlRichTextBox)ctlControl).Text != "")
						{
							((ctlRichTextBox)ctlControl).Cut();
							return 1;
						}
						break;
					
					case "RichTextBox":
						if(((RichTextBox)ctlControl).Text != "")
						{
							((RichTextBox)ctlControl).Cut();
							return 1;
						}
						break;

					case "TextBox":
						if(((TextBox)ctlControl).Text != "")
						{
							((TextBox)ctlControl).Cut();
							return 1;
						}
						break;

					case "ctlBorderTextBox":
						if(((ctlBorderTextBox)ctlControl).Text != "")
						{
							((ctlBorderTextBox)ctlControl).Cut();
							return 1;
						}
						break;

					case "DataGridTextBox":
						if(((DataGridTextBox)ctlControl).Text != "")
						{
							((DataGridTextBox)ctlControl).Cut();
							return 1;
						}
						break;
				}
			}

			return 0;
		}

		/// <summary>
		/// 粘贴操作
		/// </summary>
		/// <returns>操作结果</returns>
		public long m_lngPaste()
		{
			Control ctlControl = this.ActiveControl;
			string strTypeName = ctlControl.GetType().Name;

			if(strTypeName == "ctlRichTextBox" || strTypeName == "RichTextBox" || strTypeName == "TextBox" || strTypeName == "ctlBorderTextBox" || strTypeName == "DataGridTextBox")
			{
				switch(strTypeName)
				{
					case "ctlRichTextBox":
						((ctlRichTextBox)ctlControl).Paste();
						break;

					case "RichTextBox":
						((RichTextBox)ctlControl).Paste();
						break;

					case "TextBox":
						((TextBox)ctlControl).Paste();
						break;

					case "ctlBorderTextBox":
						((ctlBorderTextBox)ctlControl).Paste();
						break;

					case "DataGridTextBox":
						((DataGridTextBox)ctlControl).Paste();
						break;
				}
				return 1;
			}

			return 0;
		}
		#endregion

		# region PublicFuction
		public void Save()
		{
			m_mthSaveTemplateSet();
		}
		public void Display()
		{
		}
		public void Display(string strInPatientID,string strInPatientDate,string strCreateDate)
		{ 			
		}
		public void Delete()
		{			
		}
		public void Display(string cardno,string sendcheckdate){}
		public void Copy(){m_lngCopy();}
		public void Cut(){m_lngCut();}
		public void Paste(){m_lngPaste();}
		public void Redo(){}
		public void Undo(){}
		public void Print()
		{			
		}
		public void Verify()
		{
			////long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
	
		#endregion

		private void cmdClear_Click(object sender, System.EventArgs e)
		{
			this.m_txtKeyword.Text ="";
			this.m_txtKeywordPY.Text ="";
			this.m_txtTemplateName.Text ="";
			this.m_txtTemplateID.Text ="";
			this.m_lsvTemplateset.Items.Clear ();
			m_objArrTemplateSet.Clear ();
			m_lstControls.Items.Clear();
			m_cmbForms.Enabled = true;
			m_cboDisease.Text = "";
			m_cboOperation.Text = "";
            m_cboKeyword.Text = "";
		}

		private void m_cboDisease_DropDown(object sender, System.EventArgs e)
		{
			m_mthLoadAllAssociate((int)enmAssociate.Disease,m_cboDisease);
		}

		/// <summary>
		/// 查找所有关联字段
		/// </summary>
		private void m_mthLoadAllAssociate(int p_intType,ctlComboBox p_cbo)
		{
			clsTemplateSet_Associate[] m_objArr;
			m_objDomain.m_lngGetAllAssociate(p_intType,out m_objArr);
			if(m_objArr!=null && m_objArr.Length>0)			
			{
				p_cbo.ClearItem();
				p_cbo.AddRangeItems(m_objArr);
			}
		}

		private void lstTemplateIDs_DoubleClick(object sender, System.EventArgs e)
		{
			KeyEventArgs ke = new KeyEventArgs(Keys.Enter);
			lstTemplateIDs_KeyDown(sender,ke);
		}

		private void m_glbTemplateset_Enter(object sender, System.EventArgs e)
		{
			m_trvForms.Focus();
		}

		private void m_cboOperation_DropDown(object sender, System.EventArgs e)
		{
			m_mthLoadAllAssociate((int)enmAssociate.Operation,m_cboOperation);
		}

		/// <summary>
		/// 获取选定表单的所有模板
		/// </summary>
		private void m_mthGetAllTemplateByForm(string p_strFormID)
		{
			m_mthLoadAllTemplateKeyword(p_strFormID);
			#region old
//			clsEmployeeTemplateSetValue[] objTemplate_Detail=null;
//
//			long lngRes = m_objDomain.lngGetAllEmployeeTemplateSetByForm(MDIParent.OperatorID,p_strFormID,out objTemplate_Detail);
//
//			if(lngRes > 0 && objTemplate_Detail!=null && objTemplate_Detail.Length > 0)
//			{	
//				string strKeyword = "";				
//				for(int i = 0; i < objTemplate_Detail.Length; i++)
//				{
//					if(!objTemplate_Detail[i].m_strKeyword.Equals(strKeyword))
//					{
//						//关键字
//						TreeNode tnKeyword = new TreeNode(objTemplate_Detail[i].m_strKeyword);							
//						tnKeyword.Tag = objTemplate_Detail[i];
//						m_trvTemplate.Nodes.Add(tnKeyword);
//						strKeyword = objTemplate_Detail[i].m_strKeyword;
//
//						for(int j = 0; j < objTemplate_Detail.Length; j++)
//						{
//							if(objTemplate_Detail[j].m_strKeyword.Equals(strKeyword))
//							{
//								//模板名
//								TreeNode tnName = new TreeNode(objTemplate_Detail[j].m_strSet_Name);							
//								tnName.Tag = objTemplate_Detail[j];
//								tnKeyword.Nodes.Add(tnName);
//							}
//						}
//					}
//				}
//
//				//把关键字下只有一个模板的模板名删除
//				for(int i = 0; i < m_trvTemplate.Nodes.Count; i++)
//				{
//					if(m_trvTemplate.Nodes[i].Nodes.Count == 1)
//					{
//						m_trvTemplate.Nodes[i].Nodes[0].Remove();
//					}
//					else
//					{
//						m_trvTemplate.Nodes[i].Tag = null;
//					}
//				}
//				
//			}
			#endregion	
			#region 旧的逻辑，先查出所有关键字，逐个查关键字下的模板名，速度超慢
//			DataTable dtKeyword = new DataTable();
//
//			long lngRes=m_objDomain.lngGetAllEmployeeTemplateKeywordByForm(MDIParent.OperatorID ,strFormID,out dtKeyword);
//			
//			if(lngRes > 0 && dtKeyword.Rows.Count > 0)
//			{
//				for(int i = 0; i < dtKeyword.Rows.Count; i++)
//				{
//					TreeNode tnKeyword = new TreeNode(dtKeyword.Rows[i][0].ToString().Trim());
//					m_trvTemplate.Nodes.Add(tnKeyword);
//
//					lngRes=m_objDomain.lngGetAllEmployeeTemplateSetByFormAndKeyword(MDIParent.OperatorID ,strFormID,tnKeyword.Text,out objTemplate_Detail);
//
//					if(objTemplate_Detail !=null && objTemplate_Detail.Length > 1)
//					{
//						for(int j=0;j<objTemplate_Detail.Length ;j++)
//						{
//							TreeNode tnTemplate = new TreeNode(objTemplate_Detail[j].m_strSet_Name);
//							tnTemplate.Tag = objTemplate_Detail[j];
//							tnKeyword.Nodes.Add (tnTemplate);
//						}					
//					}
//					else if(objTemplate_Detail !=null && objTemplate_Detail.Length == 1)
//					{
//						tnKeyword.Tag = objTemplate_Detail[0];
//					}
//				}
//			}		
			#endregion
		}

		private void m_trvTemplate_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(m_trvTemplate.SelectedNode.Tag != null)
			{
				m_strTemplateSetID = ((clsEmployeeTemplateSetValue)m_trvTemplate.SelectedNode.Tag).m_strSet_ID;
				m_mthReloadTemplateSet();
				m_mthApplicability();
				m_mthShowCD10_TemplateSet(m_lsvDisease,m_strTemplateSetID);
                m_tsmiCopyTemplate.Enabled = true;
			}
			else
			{
				m_lsvDisease.Items.Clear();
				m_mthClear();
                m_tsmiCopyTemplate.Enabled = false;
			}
		}

		/// <summary>
		/// 清空界面
		/// </summary>
		private void m_mthClear()
		{
			m_strTemplateSetID = "";
			m_txtKeyword.Text ="";
			m_txtTemplateName.Text ="";
			m_lsvTemplateset.Items.Clear ();
			m_objArrTemplateSet.Clear ();
			m_lstControls.Items.Clear();
			m_cboDisease.Text = "";
			m_cboOperation.Text = "";
			m_txtTemplateContent.Text = "";
			m_cboKeyword.Text = "";
			m_lstDepartment.Items.Clear();
			m_rdbPrivate.Checked = false;
			m_rdbPublic.Checked = false;
			m_rdbDepartment.Checked = false;
		}

		/// <summary>
		/// 停用模板
		/// </summary>
		private void m_mthDeleteTemplate()
		{
			if(m_strTemplateSetID != "")
			{
				if(clsPublicFunction.s_blnAskForDelete())
				{
					long lngRes = new clsTemplateDomain().m_lngDeleteTemplate(m_strTemplateSetID);
					if(lngRes > 0)
					{
//						clsPublicFunction.ShowInformationMessageBox("删除成功！");
//						m_trvTemplate.SelectedNode.Remove();
                        m_mthClear();
						m_trvTemplate.Nodes.Clear();
						m_mthGetAllTemplateByForm(m_strFormID);//删除之后刷新
					}
				}
			}
			else
			{
				clsPublicFunction.ShowInformationMessageBox("请先选择模板！");
			}
		}

		private void cmdDel_Click(object sender, System.EventArgs e)
		{			
			m_mthDeleteTemplate();
		}

		private void m_trvForms_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			m_trvTemplate.Nodes.Clear();
			m_mthClear();
			m_lsvDisease.Items.Clear();

			//自定义表单下的表单名特殊处理
			if( m_trvForms.SelectedNode.Tag != null)
				m_strFormID = m_trvForms.SelectedNode.Tag.ToString();
			else
				m_strFormID = m_strGetFormID(m_trvForms.SelectedNode);

			if(m_strFormID != "")
				m_mthGetAllTemplateByForm(m_strFormID);
		}

		private string m_strGetFormID(TreeNode p_trnForm)
		{
            string strFormName = p_trnForm.Text;
			#region 需要模板的表单
            switch (strFormName) 
			{
				case "住院病历":
					return "frmInPatientCaseHistory";
				case "病程记录":
					return "frmGeneralDisease";					
				case "SPECT检查申请单":
					return "frmSPECT";					
				case "高压氧治疗申请单":
					return "frmHighOxygen";					
				case "B型超声显像检查申请单":
					return "frmBUltrasonicCheckOrder";
				case "CT检查申请单":
					return "frmCTCheckOrder";
				case "X线申请单":
					return "frmXRayCheckOrder";
				case "病理活体组织送检单":
					return "frmPathologyOrgCheckOrder";
				case "MRI申请单":
					return "frmMRIApply";
				case "实验室检验申请单":
					return "frmLabAnalysisOrder";
				case "实验室检验报告单":
					return "frmLabCheckReport";
				case "手术知情同意书":
					return "frmOperationAgreedRecord";
				case "术前小结":
                    if (p_trnForm.Parent.Text == "病案记录")
                        return "frmEMR_SummaryBeforeOP";
                    else
					    return "frmBeforeOperationSummary";
				case "手术记录单":
					return "frmOperationRecordDoctor";
				case "ICU转入记录":
					return "frmPICUShiftInForm";
				case "ICU转出记录":
					return "frmPICUShiftOutForm";
				case "SIRS诊断评分":
					return "SIRSEvaluation";
				case "改良Glasgow昏迷评分":
					return "ImproveGlasgowComaEvaluation";
				case "急性肺损伤评分":
					return "LungInjuryEvaluation";
				case "新生儿危重病例评分":
					return "NewBabyInjuryCaseEvaluation";
				case "小儿危重病例评分":
					return "BabyInjuryCaseEvaluation";
				case "APACHEII 评分":
					return "APACHEIIValuation";
				case "APACHEIII 评分":
					return "APACHEIIIValuation";
				case "TISS-28评分":
					return "frmTISSValuation";
				case "趋势分析":
					return "frmICUTrend";
				case "住院病案首页":
					return "frmInHospitalMainRecord";
				case "病案质量评分表":
					return "frmQCRecord";
				case "入院病人评估":
					return "frmInPatientEvaluate";
				case "三 测 表":
					return "frmThreeMeasureRecord";
				case "一般护理记录":
					return "frmGeneralNurseRecord";
				case "观察项目记录表":
					return "frmSubWatchItemRecord";
				case "危重患者护理记录":
					if(clsEMRLogin.m_StrCurrentHospitalNO != null && clsEMRLogin.m_StrCurrentHospitalNO.Trim() == "450101001")//判断医院名称，暂时直接用硬代码比较
					{
						return "frmIntensiveTend_GX";
					}
					else
					{
						return "frmIntensiveTend_FC";
					}
				case "危重患者护理记录(病情记录)":
					if(clsEMRLogin.m_StrCurrentHospitalNO != null && clsEMRLogin.m_StrCurrentHospitalNO.Trim() == "450101001")//判断医院名称，暂时直接用硬代码比较
					{
						return "frmIntensiveTend_GXContent";
					}
					else
					{
						return "frmIntensiveTend_FContent";
					}
				case "ICU危重患者护理记录":
					return "frmICUIntensiveTendRecord";
				case "手术护理记录":
					return "frmOperationRecord";
				case "手术器械、敷料点数表":
					return "frmOperationEquipmentQty";
				case "出院记录":
					return "frmOutHospital";
				case "会诊记录":
					return "frmConsultation";
				case "危重症监护中心特护记录单":
					return "frmSubICUIntensiveTend";
				case "中心ICU呼吸机治疗监护记录单":
					return "frmSubICUBreath";
				case "影像报告单":
					return "frmImageReport";
				case "影像预约查询":
					return "frmImageBookingSearch";
				case "心电图申请单":
					return "frmEKGOrder";
				case "电脑多导睡眠图检查申请单":
					return "frmNuclearOrder";
				case "核医学检查申请单":
					return "frmPSGOrder";

				case "首次病程记录":
					return "frmFirstIllnessNote";
				case "接班记录":
					return "frmTakeOver";
				case "转出记录":
					return "frmConvey";
				case "交班记录":
					return "frmHandOver";
				case "转入记录":
					return "frmTurnIn";
				case "阶段小结":
					return "frmDiseaseSummary";
				case "查房记录":
					return "frmCheckRoom";
				case "病例讨论":
					return "frmCaseDiscuss";
				case "术前讨论":
					return "frmBeforeOperationDiscuss";
				case "死亡病例讨论":
					return "frmDeadCaseDiscuss";
				case "手术后病程记录":
					return "frmAfterOperation";
				case "死亡记录":
					return "frmDeadRecord";
				case "抢救记录":
					return "frmSaveRecord";
				case"病人入院评估表":
					return "frmEMR_InPatientEvaluate";
				case"一般患者护理记录":
					return "frmGeneralNurseRecord_GXRec";
				case"一般患者护理记录(病情记录)":
					return "frmGeneralNurseRecord_GXCon";
				case "心血管外科特护记录":
					return "frmCardiovascularTend_GX";
				case "ICU护理记录":
					return "frmICUNurseRecord_GXCon";
			}
			#endregion

			return "";
		}

		private void m_cmdModifyBase_Click(object sender, System.EventArgs e)
		{
			m_mthModifyTemplateBaseInfo();
		}
	
		/// <summary>
		/// 修改模板基本信息
		/// </summary>
		private void m_mthModifyTemplateBaseInfo()
		{
			if(m_strTemplateSetID != "")
			{
				if(this.m_txtTemplateName.Text.Trim() =="" || this.m_cboKeyword.Text.Trim() =="")
				{
					clsPublicFunction.ShowInformationMessageBox("请输入模板名称或分类!");
					return;
				}

//				if(clsPublicFunction.s_blnAskForModify())
//				{
					long lngRes = m_objDomain.m_lngModifyTemplateBaseInfo(m_strTemplateSetID,m_txtTemplateName.Text,m_cboKeyword.Text);
					m_mthSaveTemplateSet_Associate(m_strTemplateSetID,m_strFormID);
		
					if(lngRes > 0)
					{
//						clsPublicFunction.ShowInformationMessageBox("修改成功！");
						//刷新
//						m_trvTemplate.Nodes.Clear();
//						m_mthGetAllTemplateByForm(m_strFormID);
					}
//				}
			}
			else
			{
				clsPublicFunction.ShowInformationMessageBox("请先选择模板！");
			}
			
		}

		private void m_cboKeyword_DropDown(object sender, System.EventArgs e)
		{
			m_cboKeyword.ClearItem();

			DataTable dtKeywords = new DataTable();
			long lngRes = m_objDomain.m_lngGetKeywordsByForm(m_strFormID,out dtKeywords);
			if(lngRes > 0 && dtKeywords != null && dtKeywords.Rows.Count > 0)
			{
				for(int i = 0; i < dtKeywords.Rows.Count; i++)
					m_cboKeyword.AddItem(dtKeywords.Rows[i][0]);
			}
		}	

		#region 新的模板控制
		private clsEmployeeTemplateSetValue[] m_objTemplate_Detail = null;
		private bool blnHasWholeRole = false;
		/// <summary>
		/// 查出所有模板分类
		/// </summary>
		private void m_mthLoadAllTemplateKeyword(string p_strFormID)
		{
			long lngRes = 0;
			TreeNode trNode = m_trvForms.SelectedNode;
			blnHasWholeRole = m_blnHasWholeRole(3);
            m_tsmiCopyTemplate.Visible = false;
			if(blnHasWholeRole)
			{
                m_tsmiCopyTemplate.Visible = true;
				lngRes = m_objDomain.m_lngGetAllTemplate(p_strFormID,out m_objTemplate_Detail);
			}
			else
			{
				while(trNode.Parent != null)
				{
					if(trNode.Parent.Text == "医生工作站")
					{
						blnHasWholeRole = m_blnHasWholeRole(1);
						break;
					}
					else if(trNode.Parent.Text == "护士工作站")
					{
						blnHasWholeRole = m_blnHasWholeRole(2);
						break;
					}
					else 
					{
						trNode = trNode.Parent;
					}
				}

				if(blnHasWholeRole)
				{
					clsDept_Desc[] p_objDeptArr = null;
					string[] strArrDeptID = null;
					lngRes = m_objDomain.m_lngGetDeptArr_EmployeeCanManage(MDIParent.OperatorID,out p_objDeptArr);
					if(lngRes > 0 && p_objDeptArr != null)
					{
						strArrDeptID = new string[p_objDeptArr.Length];
						for(int i=0; i<strArrDeptID.Length; i++)
						{
							strArrDeptID[i] = p_objDeptArr[i].m_strDeptNewID;
						}
					}
					lngRes = m_objDomain.lngGetAllEmployeeDeptTemplateSetByForm(strArrDeptID,MDIParent.OperatorID,p_strFormID,out m_objTemplate_Detail);
				}
				else
				{
					lngRes = m_objDomain.lngGetAllEmployeeTemplateSetByForm(MDIParent.OperatorID,p_strFormID,out m_objTemplate_Detail);
				}
			}

			if(lngRes > 0 && m_objTemplate_Detail!=null && m_objTemplate_Detail.Length > 0)
			{
				//上一个文件夹名，在这里将分类名比如为文件夹；最前面的分类名即根目录
				string strPreFolder = "";
				for(int i=0;i<m_objTemplate_Detail.Length ;i++)
				{
					string strKeyword = m_objTemplate_Detail[i].m_strKeyword;
					int intIndexOfArrow = strKeyword.IndexOf(">>");
					if(intIndexOfArrow != -1)//多层目录
					{
						if(strKeyword.Substring(0,intIndexOfArrow) != strPreFolder)
						{
							TreeNode tn = new TreeNode(strKeyword.Substring(0,intIndexOfArrow));
							m_mthLoadSubKeywordOrTemplateName(tn);
							m_trvTemplate.Nodes.Add(tn);
							strPreFolder = strKeyword.Substring(0,intIndexOfArrow);
						}			
					}
					else if(strKeyword != strPreFolder)
					{
						TreeNode tn = new TreeNode(strKeyword);
						m_mthLoadSubKeywordOrTemplateName(tn);
						m_trvTemplate.Nodes.Add(tn);
						strPreFolder = strKeyword;
					}
				}
				
			}	

		}

		/// <summary>
		/// 判断是否有权限修改整个科室的模板（最高权限可以修改所有的模板）
		/// </summary>
		/// <param name="p_intRole">角色(1.主任工程师；2.护士长；3.最高权限)</param>
		/// <returns></returns>
		private bool m_blnHasWholeRole(int p_intRole)
        {
            com.digitalwave.PublicMiddleTier.clsPublicMiddleTier objRoleServ =
                (com.digitalwave.PublicMiddleTier.clsPublicMiddleTier)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PublicMiddleTier.clsPublicMiddleTier));

			string strRoleID = "";
			if(p_intRole == 1)
			{
				objRoleServ.m_lngCheckRoleByEmpIDAndRoleName(clsEMRLogin.LoginInfo.m_strEmpID, "主任医师", out strRoleID);
			}
			else if(p_intRole == 2)
			{
				objRoleServ.m_lngCheckRoleByEmpIDAndRoleName(clsEMRLogin.LoginInfo.m_strEmpID, "护士长", out strRoleID);
			}
			else if(p_intRole == 3)
			{
				objRoleServ.m_lngCheckRoleByEmpIDAndRoleName(clsEMRLogin.LoginInfo.m_strEmpID, "最高权限", out strRoleID);
			}
            objRoleServ.Dispose() ;
			if(strRoleID == null || strRoleID == "")
			{
				return false;
			}
			else
				return true;
		}

		/// <summary>
		///	获取当前目录
		/// </summary>
		/// <param name="p_tnChild"></param>
		/// <returns></returns>
		private string m_strGetCurKeyword(TreeNode p_tnNode)
		{
			if(p_tnNode.Parent == null)
				return p_tnNode.Text;
			else
				return  m_strGetCurKeyword(p_tnNode.Parent) + ">>" + p_tnNode.Text;
		}

		/// <summary>
		/// 查找某分类下的分类或者模板名
		/// </summary>
		private void m_mthLoadSubKeywordOrTemplateName(TreeNode p_tnNode)
		{
			string strCurKeyword = m_strGetCurKeyword(p_tnNode);

			if(m_objTemplate_Detail !=null && m_objTemplate_Detail.Length >0)
			{
				//上一个文件夹名，在这里将分类名比如为文件夹；最前面的分类名即根目录
				string strPreFolder = "";
				for(int i=0;i<m_objTemplate_Detail.Length ;i++)
				{
					string strKeyword = m_objTemplate_Detail[i].m_strKeyword;
					if(strKeyword == strCurKeyword || strKeyword.IndexOf(strCurKeyword + ">>") != -1)//属于该分类下
					{
						int intIndexOfArrow = strKeyword.IndexOf(">>",strCurKeyword.Length);
						if(intIndexOfArrow != -1)//多层目录
						{
							int intNextArrow = strKeyword.IndexOf(">>",intIndexOfArrow + 2);
							string strToAdd = "";
							if(intNextArrow != -1)//还有下一层目录
							{
								strToAdd = strKeyword.Substring(intIndexOfArrow + 2,intNextArrow - intIndexOfArrow - 2);
							}
							else//没有下一层目录
							{
								strToAdd = strKeyword.Substring(intIndexOfArrow + 2);
							}
							if(strToAdd != strPreFolder)
							{
								p_tnNode.Nodes.Add (strToAdd);
								strPreFolder = strToAdd;
							}	
						}
						else//上一层目录已是最后一层
						{
							if(strKeyword != strPreFolder)
							{
								m_mthLoadAllTemplateName(p_tnNode);
								strPreFolder = strKeyword;
							}
						}
					}
				}

			}
		}

		/// <summary>
		/// 查找某关键字下的所有模板
		/// </summary>
		/// <param name="p_strKeyword"></param>
		private void m_mthLoadAllTemplateName(TreeNode p_tnParent)
		{
			string strKeyword = m_strGetCurKeyword(p_tnParent);

			if(m_objTemplate_Detail !=null && m_objTemplate_Detail.Length >0)
			{
				for(int i=0;i<m_objTemplate_Detail.Length ;i++)
				{
					if(strKeyword == m_objTemplate_Detail[i].m_strKeyword)
					{
						TreeNode tnName = new TreeNode(m_objTemplate_Detail[i].m_strSet_Name);
						tnName.Tag = m_objTemplate_Detail[i];
						p_tnParent.Nodes.Add (tnName);
					}
				}
			}
		}


		#endregion

		private void m_trvTemplate_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			for(int i = 0; i < e.Node.Nodes.Count; i++)
			{
				e.Node.Nodes[i].Nodes.Clear();
				m_mthLoadSubKeywordOrTemplateName(e.Node.Nodes[i]);
			}
		}

		#region 自定义表单
		private TreeNode m_tnCustomForm = new TreeNode("自定义表单");
		/// <summary>
		/// Load出自定义表单
		/// </summary>
		private void m_mthLoadCustomForms()
		{
			clsCustom_SubmitValue[] objCustomForms;
			long lngRes = new iCare.CustomForm.clsCustomFormDomain().m_lngGetSubmitForms(MDIParent.OperatorID,clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID,out objCustomForms);
			if(lngRes <= 0 || objCustomForms == null || objCustomForms.Length == 0)
				return;

			m_trvForms.Nodes.Add(m_tnCustomForm);
			for(int i = 0; i < objCustomForms.Length; i++)
			{
				TreeNode tnChild = m_tnCustomForm.Nodes.Add(objCustomForms[i].m_strFormName);
				tnChild.Tag = "frmCustomForm_" + objCustomForms[i].m_intFormID.ToString();
			}
		}
		#endregion
		
		#region ICD10相关操作

		private void m_mthShowCD10_TemplateSet(ListView lsvTemp,string p_strTempateSet_ID)
		{
			lsvTemp.Items.Clear();
			m_objDomain.m_lngGetICD10_TemplateSet(lsvTemp,p_strTempateSet_ID);
		}

		private void m_cmdDel_Click(object sender, System.EventArgs e)
		{
			if(m_lsvDisease.SelectedItems!=null)
			{
				foreach(ListViewItem livTemp in m_lsvDisease.SelectedItems)
				{
					m_lsvDisease.SelectedItems[0].Remove();
				}
			}
		}

		private void m_mthSaveICD10_TemplateSet(ListView p_lsvTemp,string p_strTemplateSetID)
		{
			m_objDomain.m_lngSaveICD10_TemplateSet(p_lsvTemp,p_strTemplateSetID);
		}

		#endregion

		private void m_trvForms_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			if(m_blnNewCaseIsAdd == true)
				return;
			if(!e.Node.Equals(m_trnP_Node)) return;
            #region 旧，不用
            //clsInpatMedRec_Type_Dept[] objConentArr = null;
            //if (MDIParent.s_ObjDepartment == null)
            //    return;
            //long lngRes = new clsDepartmentManager().m_lngGetCaseType(MDIParent.s_ObjDepartment.m_StrDeptID, out objConentArr);
            //if (lngRes <= 0 || objConentArr == null)
            //    return; 
            #endregion
            clsInpatMedRec_Type[] objConentArr = StaticObject::clsEMR_StaticObject.s_ObjInpatMedRec_DataShare.m_objTypeArr;
            if (objConentArr == null || objConentArr.Length <= 0)
                return;

			m_trnP_Node.Nodes.Clear();
			for(int i=0;i<objConentArr.Length;i++)
			{
				TreeNode trnNode = new TreeNode(objConentArr[i].m_strTypeName);
				trnNode.Tag = objConentArr[i].m_strTypeID;
				m_trnP_Node.Nodes.Insert(0,trnNode);
			}
			m_blnNewCaseIsAdd = true;
		}

		#region 显示适用范围信息
		private clsDepartmentManager m_objDeptManager = new clsDepartmentManager();
		private clsDepartment [] m_objDepartmentArr=null;
		private string m_strCreateTemplateEmpNO = "";
		/// <summary>
		/// 显示适用范围信息
		/// </summary>
		private void m_mthApplicability()
		{
			m_lstDepartment.Items.Clear();
			m_rdbPublic.Checked = false;
			m_rdbDepartment.Checked = false;
			m_rdbPrivate.Checked = false;

			if(m_strTemplateSetID == null || m_strTemplateSetID == "")
				return;

			if(m_lsvTemplateset.Items.Count <= 0)
				return;			
			string strVisibilityLevel = "";
			string strTemplateID = m_lsvTemplateset.Items[0].SubItems[1].Text;
			long lngRes = m_objDomain.m_lngGetTemplateVLandEmpID(strTemplateID, out m_strCreateTemplateEmpNO, out strVisibilityLevel, out m_strActivityDate);
			if(lngRes <= 0 || strVisibilityLevel == string.Empty)
				return;
			
			if(MDIParent.OperatorID.Trim() != m_strCreateTemplateEmpNO.Trim() && !blnHasWholeRole)
			{
				m_lstDepartment.Enabled = false;
				m_rdbPublic.Enabled = false;
				m_rdbDepartment.Enabled = false;
				m_rdbPrivate.Enabled = false;
				return;
			}
			else
			{
				m_lstDepartment.Enabled = true;
				m_rdbPublic.Enabled = true;
				m_rdbDepartment.Enabled = true;
				m_rdbPrivate.Enabled = true;
			}
			
			switch(Convert.ToInt32(strVisibilityLevel))
			{
				case 1:
					m_rdbPublic.Checked = true;
					break;
				case 2:
					m_rdbDepartment.Checked = true;
                    m_mthLoadVisibilDept(strTemplateID);
					break;
				case 0:
					m_rdbPrivate.Checked = true;
					break;
				default:
					break;
			}
		}

        /// <summary>
        /// 显示可见模板科室
        /// </summary>
        private void m_mthLoadVisibilDept(string p_strTemplateID)
        {
            ArrayList arrDept = null;
            long lngRes = m_objDomain.m_lngGetDeptIDByTemplateID(p_strTemplateID, out arrDept);

            if (arrDept != null && lngRes > 0)
            {
                m_mthCheckVisibilDept(arrDept);
            }
        }

        private void m_mthCheckVisibilDept(ArrayList p_arrDept)
        {
            if (p_arrDept != null && m_objDepartmentArr != null)
            {

                for (int i = 0; i < m_objDepartmentArr.Length; i++)
                {
                    this.m_lstDepartment.SetItemChecked(i, false);
                    for (int m = 0; m < p_arrDept.Count; m++)
                    {
                        if (m_objDepartmentArr[i].m_strDeptNewID.Trim() == ((object[])p_arrDept[m])[0].ToString().Trim())
                            this.m_lstDepartment.SetItemChecked(i, true);
                    }  
                }
            }
        }

		private string m_strActivityDate = "";
		private void m_mthLoadDept(string p_strTemplateID, string p_strEmpNO)
		{		
			clsDept_Desc[] arrDept = null;
			ArrayList arrDeptIndex = new ArrayList();
			
			m_objDepartmentArr= m_objDeptManager.m_objGetAllInDeptArr1();
			for(int i=0;i<m_objDepartmentArr.Length ;i++)
			{
				this.m_lstDepartment.Items.Add (m_objDepartmentArr[i].m_StrDeptName ); 
			}
			
            //long lngRes = m_objDomain.m_lngGetDeptIDByTemplateID(p_strTemplateID, out arrDept); 
            long lngRes = m_objDeptManager.m_lngGetDeptArr_EmployeeCanManage(null, clsEMRLogin.LoginEmployee.m_strEMPNO_CHR,out arrDept);
			if(lngRes <= 0 || arrDept.Length == 0)
				return;

			for(int j=0; j<m_objDepartmentArr.Length; j++)
			{
				for(int m=0; m<arrDept.Length; m++)
				{
                    if (m_objDepartmentArr[j].m_strDeptNewID.Trim() == arrDept[m].m_strDeptNewID.Trim())
						this.m_lstDepartment.SetItemChecked (j,true);  
				}
			}

			//如果该员工创建的模板所用科室不在员工当前所见科室之列，则再加进m_lstDepartment里
			for(int j=0; j<arrDept.Length; j++)
			{
				int m = 0;
				for(m=0; m<m_objDepartmentArr.Length; m++)
				{
                    if (m_objDepartmentArr[m].m_strDeptNewID.Trim() == arrDept[j].m_strDeptNewID.Trim())
						break;
				}
				if(m < m_objDepartmentArr.Length)
					continue;

                string deptName = arrDept[j].m_strDeptName.Trim() == "" ?
                    arrDept[j].m_strDeptNewID.Trim() : arrDept[j].m_strDeptName.Trim();
				this.m_lstDepartment.Items.Add(deptName);
				this.m_lstDepartment.SetItemChecked (m_lstDepartment.Items.Count-1,true);
				arrDeptIndex.Add(j);
			}

			if(m_lstDepartment.Items.Count > m_objDepartmentArr.Length)
			{
				clsDepartment [] objNewDepartmentArr = new clsDepartment[m_lstDepartment.Items.Count];
				for(int i=0; i<m_objDepartmentArr.Length; i++)
				{
					objNewDepartmentArr[i] = m_objDepartmentArr[i];
				}
				for(int i=m_objDepartmentArr.Length; i<m_lstDepartment.Items.Count; i++)
				{ 
					int j = 0;
					if(j < arrDeptIndex.Count)
					{
						int index = Convert.ToInt32(arrDeptIndex[j]);
						objNewDepartmentArr[i] = new clsDepartment();
						objNewDepartmentArr[i].m_StrDeptID = arrDept[index].m_strDeptNewID.Trim();
					}
					j ++;
				}
				m_objDepartmentArr = objNewDepartmentArr;
			}
		}
		#endregion

		/// <summary>
		/// 更必可见范围前先把原有可见科室信息删除
		/// </summary>
        private long m_mthDelDeptInfo()
		{
			long lngRes = 0;

			for(int j=0; j<m_lsvTemplateset.Items.Count; j++)
			{
				lngRes = m_objDomain.m_lngDeleteTemplate_Dept_Visibility(m_lsvTemplateset.Items[j].SubItems[1].Text);
                if (lngRes < 0)
                    return lngRes;
			}
            return lngRes;
		}

        private long m_mthModifyApplicability()
		{
			if(m_strActivityDate == null || m_strActivityDate == "")
				return -1;

			if(!m_lstDepartment.Enabled && !m_rdbPublic.Enabled && !m_rdbDepartment.Enabled && !m_rdbPrivate.Enabled)
				return -1;


			clsTemplate_Dept_VisibilityValue[] objTemplate_Dept_Visiblity=null;			

			long lngRes = 1;
			if(m_rdbDepartment.Checked)
			{
				if(this.m_lstDepartment.CheckedItems.Count <=0)
				{
					clsPublicFunction.ShowInformationMessageBox  ("没有选定任何部门使用该模板");
					return -1;
				}
				 
				objTemplate_Dept_Visiblity=new clsTemplate_Dept_VisibilityValue [this.m_lstDepartment.CheckedItems.Count];
				for(int j=0; j<m_lsvTemplateset.Items.Count; j++)
				{
					for(int i1=0;i1<this.m_lstDepartment.CheckedIndices.Count;i1++)
					{
						objTemplate_Dept_Visiblity[i1]=new clsTemplate_Dept_VisibilityValue ();
						objTemplate_Dept_Visiblity[i1].m_strActivity_Date =m_strActivityDate ;
						objTemplate_Dept_Visiblity[i1].m_strTemplate_ID =m_lsvTemplateset.Items[j].SubItems[1].Text ;
						objTemplate_Dept_Visiblity[i1].m_strDepartmentID =m_objDepartmentArr[m_lstDepartment.CheckedIndices[i1]].m_strDeptNewID;
					}					
					lngRes = m_objDomain.m_lngSaveTemplate_Dept_Visibility(objTemplate_Dept_Visiblity);
                    if (lngRes < 0)
                        return lngRes;
				}
			}
            return lngRes;
		}

		private void m_rdbDepartment_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_rdbDepartment.Checked)
			{
				m_lstDepartment.Items.Clear();
                m_mthLoadDept(m_lsvTemplateset.SelectedItems[0].SubItems[1].Text, m_strCreateTemplateEmpNO);
                if (m_lsvTemplateset.Items.Count > 0)
                {
                    m_mthLoadVisibilDept(m_lsvTemplateset.Items[0].SubItems[1].Text);
                }
			}
		}

		private void m_rdbPublicAnaPrivate_CheckedChanged(object sender, System.EventArgs e)
		{
			if(((RadioButton)sender).Checked)
			{
				m_lstDepartment.Items.Clear();
			}
		}

        private void m_tsmiCopyTemplate_Click(object sender, EventArgs e)
        {
            if (m_objSelectedGUI_TargetValue == null || m_objSelectedGUI_TargetValue.Length <= 0)
                return;

            clsTemplateDomain objDomain = new clsTemplateDomain();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int intControlArrLength = m_objSelectedGUI_TargetValue.Length;
                clsControlInfomation[] objControlArr = new clsControlInfomation[intControlArrLength];
                long lngRes = 0;
                string strContent = "";
                string strCreatID = "";
                string strCreatName = "";

                for (int i = 0; i < intControlArrLength; i++)
                {
                    objControlArr[i] = new clsControlInfomation();
                    objControlArr[i].objGUI_Info.m_strControl_Desc = m_objSelectedGUI_TargetValue[i].m_strControl_Desc;
                    objControlArr[i].objGUI_Info.m_strControl_ID = m_objSelectedGUI_TargetValue[i].m_strControl_ID;
                    objControlArr[i].objGUI_Info.m_strControl_TabIndex = m_objSelectedGUI_TargetValue[i].m_strControl_TabIndex;
                    objControlArr[i].objGUI_Info.m_strForm_ID = m_objSelectedGUI_TargetValue[i].m_strForm_ID;

                    lngRes = objDomain.m_lngGetTemplateContent(m_objSelectedGUI_TargetValue[i].m_strTemplate_ID,
                        out strContent, out strCreatID, out strCreatName);
                    objControlArr[i].strContent = strContent;
                }

                frmTemplatesetDialog objDialog = new frmTemplatesetDialog();
                objDialog.m_lstUserDefine.BeginUpdate();
                for (int i = 0; i < intControlArrLength; i++)
                {
                    objDialog.m_lstUserDefine.Items.Add(objControlArr[i], true);
                }
                objDialog.m_lstUserDefine.EndUpdate();
                objDialog.ShowDialog();
            }
            catch(Exception ex)
            {
                clsPublicFunction.ShowInformationMessageBox(ex.Message);
            }
            finally
            {
                objDomain = null;
                this.Cursor = Cursors.Default;
            }
        }
    }
}
