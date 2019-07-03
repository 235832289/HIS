using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.gui.LIS;
using com.digitalwave.iCare.ValueObject;
using iCareData;
using System.Reflection;
//using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.Emr.StaticObject;

namespace iCare
{
    /// <summary>
    /// frmOutlookBar 的摘要说明。
    /// </summary>
    public class frmOutlookBar : System.Windows.Forms.Form
    {
        #region Variable
        private UtilityLibrary.WinControls.OutlookBar m_outlookBar;
        private UtilityLibrary.WinControls.OutlookBarBand outlookBarBand2;
        private UtilityLibrary.WinControls.OutlookBarBand outlookBarBand3;
        private UtilityLibrary.WinControls.OutlookBarBand outlookBarBand5;
        private UtilityLibrary.WinControls.OutlookBarBand outlookBarBand6;
        private UtilityLibrary.WinControls.OutlookBarBand outlookBarBand7;
        private UtilityLibrary.WinControls.OutlookBarBand outlookBarBand8;
        private System.Windows.Forms.TreeView m_trvMedRecord;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.TreeView m_trvApplyRecord;
        private System.Windows.Forms.TreeView m_trvNurseRecord;
        private System.Windows.Forms.GroupBox o7;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.GroupBox o8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton12;
        private System.Windows.Forms.RadioButton radioButton13;
        private System.Windows.Forms.RadioButton radioButton14;
        private System.Windows.Forms.RadioButton radioButton15;
        private System.Windows.Forms.RadioButton radioButton17;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.LinkLabel m_lklLISApply;
        private System.Windows.Forms.RadioButton radioButton20;
        private System.Windows.Forms.RadioButton radioButton21;
        private System.Windows.Forms.Panel p2;
        private System.Windows.Forms.Panel p3;
        private System.Windows.Forms.Panel p5;
        private System.Windows.Forms.Panel p7;
        private System.Windows.Forms.Panel p8;
        private clsMainMenuFunction m_objMainMenuFunction;
        private System.Windows.Forms.LinkLabel m_lklShowReport;
        private System.Windows.Forms.ImageList m_imgThis;
        private System.Windows.Forms.RadioButton radioButton1;
        private UtilityLibrary.WinControls.OutlookBarBand outlookBarBand9;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Panel m_pnlDataAnalyze;
        private System.Windows.Forms.LinkLabel m_lklBedManage;
        private UtilityLibrary.WinControls.OutlookBarBand outlookBarBand10;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton19;
        private System.Windows.Forms.RadioButton radioButton22;
        private System.Windows.Forms.Panel m_pnlQualityControl;
        private System.Windows.Forms.RadioButton radioButton23;
        private System.Windows.Forms.RadioButton radioButton24;
        private System.Windows.Forms.RadioButton radioButton27;
        private System.Windows.Forms.RadioButton radioButton25;
        private System.Windows.Forms.RadioButton radioButton26;
        private System.Windows.Forms.RadioButton radioButton28;
        private UtilityLibrary.WinControls.OutlookBarBand m_obbPatientInfo;
        private System.Windows.Forms.ImageList m_imgLargeIcons;
        private UtilityLibrary.WinControls.OutlookBarItem outlookBarItem1;
        private UtilityLibrary.WinControls.OutlookBarItem outlookBarItem2;
        private UtilityLibrary.WinControls.OutlookBarBand m_obbOperationInfo;
        private System.Windows.Forms.RadioButton radioButton29;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.RadioButton radioButton30;
        private System.Windows.Forms.RadioButton radioButton31;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton radioButton16;
        private System.Windows.Forms.RadioButton radioButton18;
        private System.Windows.Forms.RadioButton radioButton32;
        private System.Windows.Forms.RadioButton radioButton33;
        private System.Windows.Forms.RadioButton radioButton34;
        private System.Windows.Forms.GroupBox gpbOperation;
        private System.Windows.Forms.RadioButton radioButton35;
        private System.Windows.Forms.Panel p4;
        private RadioButton radioButton36;
        private RadioButton radioButton37;
        private bool m_blnNodeIsNull = false;
        #endregion

        public frmOutlookBar()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            m_objMainMenuFunction = new clsMainMenuFunction();
            m_mthInitTreeView();
            m_mthEnableFunc();

            //			if (MDIParent.strOperatorID.Trim()!="0001")
            //				m_mthFunctionControl();
            s_outlookBar = m_outlookBar;
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutlookBar));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("申请单");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("护理资料");
            this.m_outlookBar = new UtilityLibrary.WinControls.OutlookBar();
            this.m_obbPatientInfo = new UtilityLibrary.WinControls.OutlookBarBand();
            this.outlookBarItem1 = new UtilityLibrary.WinControls.OutlookBarItem();
            this.m_imgLargeIcons = new System.Windows.Forms.ImageList(this.components);
            this.outlookBarBand2 = new UtilityLibrary.WinControls.OutlookBarBand();
            this.p2 = new System.Windows.Forms.Panel();
            this.m_trvMedRecord = new System.Windows.Forms.TreeView();
            this.m_imgThis = new System.Windows.Forms.ImageList(this.components);
            this.outlookBarBand6 = new UtilityLibrary.WinControls.OutlookBarBand();
            this.outlookBarItem2 = new UtilityLibrary.WinControls.OutlookBarItem();
            this.outlookBarBand3 = new UtilityLibrary.WinControls.OutlookBarBand();
            this.p3 = new System.Windows.Forms.Panel();
            this.m_lklLISApply = new System.Windows.Forms.LinkLabel();
            this.m_trvApplyRecord = new System.Windows.Forms.TreeView();
            this.m_lklShowReport = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.m_obbOperationInfo = new UtilityLibrary.WinControls.OutlookBarBand();
            this.p4 = new System.Windows.Forms.Panel();
            this.gpbOperation = new System.Windows.Forms.GroupBox();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton16 = new System.Windows.Forms.RadioButton();
            this.radioButton18 = new System.Windows.Forms.RadioButton();
            this.radioButton32 = new System.Windows.Forms.RadioButton();
            this.radioButton33 = new System.Windows.Forms.RadioButton();
            this.radioButton34 = new System.Windows.Forms.RadioButton();
            this.radioButton37 = new System.Windows.Forms.RadioButton();
            this.radioButton36 = new System.Windows.Forms.RadioButton();
            this.radioButton35 = new System.Windows.Forms.RadioButton();
            this.outlookBarBand5 = new UtilityLibrary.WinControls.OutlookBarBand();
            this.p5 = new System.Windows.Forms.Panel();
            this.m_trvNurseRecord = new System.Windows.Forms.TreeView();
            this.m_lklBedManage = new System.Windows.Forms.LinkLabel();
            this.outlookBarBand7 = new UtilityLibrary.WinControls.OutlookBarBand();
            this.p7 = new System.Windows.Forms.Panel();
            this.o7 = new System.Windows.Forms.GroupBox();
            this.radioButton17 = new System.Windows.Forms.RadioButton();
            this.radioButton15 = new System.Windows.Forms.RadioButton();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton27 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton30 = new System.Windows.Forms.RadioButton();
            this.radioButton31 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.outlookBarBand8 = new UtilityLibrary.WinControls.OutlookBarBand();
            this.p8 = new System.Windows.Forms.Panel();
            this.o8 = new System.Windows.Forms.GroupBox();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton20 = new System.Windows.Forms.RadioButton();
            this.radioButton21 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton25 = new System.Windows.Forms.RadioButton();
            this.outlookBarBand10 = new UtilityLibrary.WinControls.OutlookBarBand();
            this.m_pnlQualityControl = new System.Windows.Forms.Panel();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton19 = new System.Windows.Forms.RadioButton();
            this.radioButton22 = new System.Windows.Forms.RadioButton();
            this.radioButton23 = new System.Windows.Forms.RadioButton();
            this.radioButton24 = new System.Windows.Forms.RadioButton();
            this.outlookBarBand9 = new UtilityLibrary.WinControls.OutlookBarBand();
            this.m_pnlDataAnalyze = new System.Windows.Forms.Panel();
            this.radioButton29 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton26 = new System.Windows.Forms.RadioButton();
            this.radioButton28 = new System.Windows.Forms.RadioButton();
            this.p2.SuspendLayout();
            this.p3.SuspendLayout();
            this.p4.SuspendLayout();
            this.gpbOperation.SuspendLayout();
            this.p5.SuspendLayout();
            this.p7.SuspendLayout();
            this.o7.SuspendLayout();
            this.p8.SuspendLayout();
            this.o8.SuspendLayout();
            this.m_pnlQualityControl.SuspendLayout();
            this.m_pnlDataAnalyze.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_outlookBar
            // 
            this.m_outlookBar.AnimationSpeed = 1;
            this.m_outlookBar.BackColor = System.Drawing.SystemColors.Control;
            this.m_outlookBar.Bands.Add(this.m_obbPatientInfo);
            this.m_outlookBar.Bands.Add(this.outlookBarBand2);
            this.m_outlookBar.Bands.Add(this.outlookBarBand6);
            this.m_outlookBar.Bands.Add(this.outlookBarBand3);
            this.m_outlookBar.Bands.Add(this.m_obbOperationInfo);
            this.m_outlookBar.Bands.Add(this.outlookBarBand5);
            this.m_outlookBar.Bands.Add(this.outlookBarBand7);
            this.m_outlookBar.Bands.Add(this.outlookBarBand8);
            this.m_outlookBar.Bands.Add(this.outlookBarBand10);
            this.m_outlookBar.Bands.Add(this.outlookBarBand9);
            this.m_outlookBar.CurrentBand = 0;
            this.m_outlookBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_outlookBar.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(134)));
            this.m_outlookBar.ItemsCheckStyle = UtilityLibrary.WinControls.OutlookBarCheckStyle.ItemsAsCheckBoxes;
            this.m_outlookBar.LeftTopColor = System.Drawing.Color.Empty;
            this.m_outlookBar.Location = new System.Drawing.Point(0, 0);
            this.m_outlookBar.Name = "m_outlookBar";
            this.m_outlookBar.QuietMode = false;
            this.m_outlookBar.RightBottomColor = System.Drawing.Color.Empty;
            this.m_outlookBar.Size = new System.Drawing.Size(168, 709);
            this.m_outlookBar.TabIndex = 0;
            this.m_outlookBar.Text = "outlookBar1";
            this.m_outlookBar.ItemClicked += new UtilityLibrary.WinControls.OutlookBarItemClickedHandler(this.m_outlookBar_ItemClicked);
            // 
            // m_obbPatientInfo
            // 
            this.m_obbPatientInfo.BackColor = System.Drawing.SystemColors.Control;
            this.m_obbPatientInfo.Background = System.Drawing.SystemColors.AppWorkspace;
            this.m_obbPatientInfo.Items.Add(this.outlookBarItem1);
            this.m_obbPatientInfo.LargeImageList = this.m_imgLargeIcons;
            this.m_obbPatientInfo.Location = new System.Drawing.Point(0, 0);
            this.m_obbPatientInfo.Name = "m_obbPatientInfo";
            this.m_obbPatientInfo.Size = new System.Drawing.Size(0, 0);
            this.m_obbPatientInfo.TabIndex = 0;
            this.m_obbPatientInfo.Text = "病人资料";
            this.m_obbPatientInfo.TextColor = System.Drawing.Color.White;
            // 
            // outlookBarItem1
            // 
            this.outlookBarItem1.ImageIndex = 0;
            this.outlookBarItem1.ImageList = this.m_imgLargeIcons;
            this.outlookBarItem1.Text = "病人浏览";
            // 
            // m_imgLargeIcons
            // 
            this.m_imgLargeIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imgLargeIcons.ImageStream")));
            this.m_imgLargeIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imgLargeIcons.Images.SetKeyName(0, "");
            this.m_imgLargeIcons.Images.SetKeyName(1, "");
            this.m_imgLargeIcons.Images.SetKeyName(2, "");
            this.m_imgLargeIcons.Images.SetKeyName(3, "");
            this.m_imgLargeIcons.Images.SetKeyName(4, "");
            this.m_imgLargeIcons.Images.SetKeyName(5, "");
            this.m_imgLargeIcons.Images.SetKeyName(6, "");
            // 
            // outlookBarBand2
            // 
            this.outlookBarBand2.Background = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(211)))));
            this.outlookBarBand2.ChildControl = this.p2;
            this.outlookBarBand2.Location = new System.Drawing.Point(0, 0);
            this.outlookBarBand2.Name = "outlookBarBand2";
            this.outlookBarBand2.Size = new System.Drawing.Size(0, 0);
            this.outlookBarBand2.TabIndex = 0;
            this.outlookBarBand2.Text = "病历资料";
            this.outlookBarBand2.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // p2
            // 
            this.p2.Controls.Add(this.m_trvMedRecord);
            this.p2.Location = new System.Drawing.Point(176, 16);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(168, 56);
            this.p2.TabIndex = 2;
            // 
            // m_trvMedRecord
            // 
            this.m_trvMedRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_trvMedRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_trvMedRecord.FullRowSelect = true;
            this.m_trvMedRecord.HideSelection = false;
            this.m_trvMedRecord.HotTracking = true;
            this.m_trvMedRecord.ImageIndex = 0;
            this.m_trvMedRecord.ImageList = this.m_imgThis;
            this.m_trvMedRecord.Location = new System.Drawing.Point(0, 0);
            this.m_trvMedRecord.Name = "m_trvMedRecord";
            this.m_trvMedRecord.SelectedImageIndex = 0;
            this.m_trvMedRecord.Size = new System.Drawing.Size(168, 56);
            this.m_trvMedRecord.TabIndex = 0;
            this.m_trvMedRecord.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_trvMedRecord_MouseDown);
            // 
            // m_imgThis
            // 
            this.m_imgThis.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imgThis.ImageStream")));
            this.m_imgThis.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imgThis.Images.SetKeyName(0, "");
            this.m_imgThis.Images.SetKeyName(1, "");
            // 
            // outlookBarBand6
            // 
            this.outlookBarBand6.Background = System.Drawing.SystemColors.AppWorkspace;
            this.outlookBarBand6.Items.Add(this.outlookBarItem2);
            this.outlookBarBand6.LargeImageList = this.m_imgLargeIcons;
            this.outlookBarBand6.Location = new System.Drawing.Point(0, 0);
            this.outlookBarBand6.Name = "outlookBarBand6";
            this.outlookBarBand6.Size = new System.Drawing.Size(0, 0);
            this.outlookBarBand6.TabIndex = 0;
            this.outlookBarBand6.Text = "医嘱";
            this.outlookBarBand6.TextColor = System.Drawing.Color.White;
            // 
            // outlookBarItem2
            // 
            this.outlookBarItem2.ImageIndex = 1;
            this.outlookBarItem2.ImageList = this.m_imgLargeIcons;
            this.outlookBarItem2.Text = "医嘱";
            // 
            // outlookBarBand3
            // 
            this.outlookBarBand3.Background = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(211)))));
            this.outlookBarBand3.ChildControl = this.p3;
            this.outlookBarBand3.Location = new System.Drawing.Point(0, 0);
            this.outlookBarBand3.Name = "outlookBarBand3";
            this.outlookBarBand3.Size = new System.Drawing.Size(0, 0);
            this.outlookBarBand3.TabIndex = 0;
            this.outlookBarBand3.Text = "检验检查";
            this.outlookBarBand3.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // p3
            // 
            this.p3.BackColor = System.Drawing.Color.White;
            this.p3.Controls.Add(this.m_lklLISApply);
            this.p3.Controls.Add(this.m_trvApplyRecord);
            this.p3.Controls.Add(this.m_lklShowReport);
            this.p3.Controls.Add(this.linkLabel1);
            this.p3.Location = new System.Drawing.Point(176, 80);
            this.p3.Name = "p3";
            this.p3.Size = new System.Drawing.Size(168, 152);
            this.p3.TabIndex = 3;
            // 
            // m_lklLISApply
            // 
            this.m_lklLISApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lklLISApply.AutoSize = true;
            this.m_lklLISApply.Location = new System.Drawing.Point(8, 104);
            this.m_lklLISApply.Name = "m_lklLISApply";
            this.m_lklLISApply.Size = new System.Drawing.Size(65, 12);
            this.m_lklLISApply.TabIndex = 2;
            this.m_lklLISApply.TabStop = true;
            this.m_lklLISApply.Text = "检验申请单";
            this.m_lklLISApply.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklLISApply_LinkClicked);
            // 
            // m_trvApplyRecord
            // 
            this.m_trvApplyRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_trvApplyRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_trvApplyRecord.FullRowSelect = true;
            this.m_trvApplyRecord.HideSelection = false;
            this.m_trvApplyRecord.HotTracking = true;
            this.m_trvApplyRecord.ImageIndex = 0;
            this.m_trvApplyRecord.ImageList = this.m_imgThis;
            this.m_trvApplyRecord.Location = new System.Drawing.Point(0, 0);
            this.m_trvApplyRecord.Name = "m_trvApplyRecord";
            treeNode1.Name = "";
            treeNode1.Text = "申请单";
            this.m_trvApplyRecord.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.m_trvApplyRecord.SelectedImageIndex = 0;
            this.m_trvApplyRecord.Size = new System.Drawing.Size(168, 96);
            this.m_trvApplyRecord.TabIndex = 1;
            this.m_trvApplyRecord.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_trvMedRecord_MouseDown);
            // 
            // m_lklShowReport
            // 
            this.m_lklShowReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lklShowReport.AutoSize = true;
            this.m_lklShowReport.Location = new System.Drawing.Point(8, 128);
            this.m_lklShowReport.Name = "m_lklShowReport";
            this.m_lklShowReport.Size = new System.Drawing.Size(65, 12);
            this.m_lklShowReport.TabIndex = 2;
            this.m_lklShowReport.TabStop = true;
            this.m_lklShowReport.Text = "查看报告单";
            this.m_lklShowReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklShowReport_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(88, 104);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 12);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "图文工作站";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // m_obbOperationInfo
            // 
            this.m_obbOperationInfo.Background = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(211)))));
            this.m_obbOperationInfo.ChildControl = this.p4;
            this.m_obbOperationInfo.Location = new System.Drawing.Point(0, 0);
            this.m_obbOperationInfo.Name = "m_obbOperationInfo";
            this.m_obbOperationInfo.Size = new System.Drawing.Size(0, 0);
            this.m_obbOperationInfo.TabIndex = 0;
            this.m_obbOperationInfo.Text = "手术资料";
            this.m_obbOperationInfo.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // p4
            // 
            this.p4.Controls.Add(this.gpbOperation);
            this.p4.Location = new System.Drawing.Point(352, 384);
            this.p4.Name = "p4";
            this.p4.Size = new System.Drawing.Size(199, 279);
            this.p4.TabIndex = 13;
            // 
            // gpbOperation
            // 
            this.gpbOperation.BackColor = System.Drawing.Color.White;
            this.gpbOperation.Controls.Add(this.radioButton11);
            this.gpbOperation.Controls.Add(this.radioButton16);
            this.gpbOperation.Controls.Add(this.radioButton18);
            this.gpbOperation.Controls.Add(this.radioButton32);
            this.gpbOperation.Controls.Add(this.radioButton33);
            this.gpbOperation.Controls.Add(this.radioButton34);
            this.gpbOperation.Controls.Add(this.radioButton37);
            this.gpbOperation.Controls.Add(this.radioButton36);
            this.gpbOperation.Controls.Add(this.radioButton35);
            this.gpbOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbOperation.Location = new System.Drawing.Point(0, 0);
            this.gpbOperation.Name = "gpbOperation";
            this.gpbOperation.Size = new System.Drawing.Size(199, 279);
            this.gpbOperation.TabIndex = 8;
            this.gpbOperation.TabStop = false;
            // 
            // radioButton11
            // 
            this.radioButton11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton11.Location = new System.Drawing.Point(9, 218);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(136, 24);
            this.radioButton11.TabIndex = 1;
            this.radioButton11.Tag = "iCare.frmOpraAnaSignAgree";
            this.radioButton11.Text = "手术知情同意书";
            this.radioButton11.Visible = false;
            this.radioButton11.Click += new System.EventHandler(this.RadioButton_Show);
            // 
            // radioButton16
            // 
            this.radioButton16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton16.Location = new System.Drawing.Point(9, 154);
            this.radioButton16.Name = "radioButton16";
            this.radioButton16.Size = new System.Drawing.Size(104, 24);
            this.radioButton16.TabIndex = 2;
            this.radioButton16.Tag = "iCare.frmOperationRequisition";
            this.radioButton16.Text = "手术通知单";
            this.radioButton16.Visible = false;
            this.radioButton16.Click += new System.EventHandler(this.radioButton16_Click);
            // 
            // radioButton18
            // 
            this.radioButton18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton18.Location = new System.Drawing.Point(9, 198);
            this.radioButton18.Name = "radioButton18";
            this.radioButton18.Size = new System.Drawing.Size(104, 24);
            this.radioButton18.TabIndex = 3;
            this.radioButton18.Tag = "iCare.frmBeforeOperationSummary";
            this.radioButton18.Text = "术前小结";
            this.radioButton18.Visible = false;
            this.radioButton18.Click += new System.EventHandler(this.RadioButton_Show);
            // 
            // radioButton32
            // 
            this.radioButton32.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton32.Location = new System.Drawing.Point(8, 38);
            this.radioButton32.Name = "radioButton32";
            this.radioButton32.Size = new System.Drawing.Size(128, 24);
            this.radioButton32.TabIndex = 4;
            this.radioButton32.Tag = "iCare.frmOperationRecordDoctor";
            this.radioButton32.Text = "手术记录单";
            this.radioButton32.Click += new System.EventHandler(this.RadioButton_Show);
            // 
            // radioButton33
            // 
            this.radioButton33.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton33.Location = new System.Drawing.Point(9, 177);
            this.radioButton33.Name = "radioButton33";
            this.radioButton33.Size = new System.Drawing.Size(128, 24);
            this.radioButton33.TabIndex = 5;
            this.radioButton33.Tag = "iCare.frmIMR_OperateManageRecord";
            this.radioButton33.Text = "手术护理记录";
            this.radioButton33.Visible = false;
            this.radioButton33.Click += new System.EventHandler(this.RadioButton_Show);
            // 
            // radioButton34
            // 
            this.radioButton34.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton34.Location = new System.Drawing.Point(9, 132);
            this.radioButton34.Name = "radioButton34";
            this.radioButton34.Size = new System.Drawing.Size(136, 24);
            this.radioButton34.TabIndex = 6;
            this.radioButton34.Tag = "iCare.frmAnaParamSetting";
            this.radioButton34.Text = "麻醉记录单";
            this.radioButton34.Visible = false;
            this.radioButton34.Click += new System.EventHandler(this.radioButton34_Click);
            // 
            // radioButton37
            // 
            this.radioButton37.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton37.Location = new System.Drawing.Point(8, 108);
            this.radioButton37.Name = "radioButton37";
            this.radioButton37.Size = new System.Drawing.Size(185, 24);
            this.radioButton37.TabIndex = 5;
            this.radioButton37.Tag = "iCare.frmEMR_CesareanRecord";
            this.radioButton37.Text = "剖宫产手术记录";
            this.radioButton37.Click += new System.EventHandler(this.RadioButton_Show);
            // 
            // radioButton36
            // 
            this.radioButton36.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton36.Location = new System.Drawing.Point(8, 84);
            this.radioButton36.Name = "radioButton36";
            this.radioButton36.Size = new System.Drawing.Size(185, 24);
            this.radioButton36.TabIndex = 5;
            this.radioButton36.Tag = "iCare.frmEMR_PullDeliverRecord";
            this.radioButton36.Text = "阴道胎头吸引器助产手术记录";
            this.radioButton36.Click += new System.EventHandler(this.RadioButton_Show);
            // 
            // radioButton35
            // 
            this.radioButton35.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton35.Location = new System.Drawing.Point(8, 61);
            this.radioButton35.Name = "radioButton35";
            this.radioButton35.Size = new System.Drawing.Size(128, 24);
            this.radioButton35.TabIndex = 5;
            this.radioButton35.Tag = "iCare.frmIMR_PrePostOperateSee";
            this.radioButton35.Text = "术前术后访视单";
            this.radioButton35.Click += new System.EventHandler(this.RadioButton_Show);
            // 
            // outlookBarBand5
            // 
            this.outlookBarBand5.Background = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(211)))));
            this.outlookBarBand5.ChildControl = this.p5;
            this.outlookBarBand5.Location = new System.Drawing.Point(0, 0);
            this.outlookBarBand5.Name = "outlookBarBand5";
            this.outlookBarBand5.Size = new System.Drawing.Size(0, 0);
            this.outlookBarBand5.TabIndex = 0;
            this.outlookBarBand5.Text = "护理资料";
            this.outlookBarBand5.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // p5
            // 
            this.p5.BackColor = System.Drawing.Color.White;
            this.p5.Controls.Add(this.m_trvNurseRecord);
            this.p5.Controls.Add(this.m_lklBedManage);
            this.p5.Location = new System.Drawing.Point(176, 240);
            this.p5.Name = "p5";
            this.p5.Size = new System.Drawing.Size(168, 104);
            this.p5.TabIndex = 5;
            // 
            // m_trvNurseRecord
            // 
            this.m_trvNurseRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_trvNurseRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_trvNurseRecord.FullRowSelect = true;
            this.m_trvNurseRecord.HideSelection = false;
            this.m_trvNurseRecord.HotTracking = true;
            this.m_trvNurseRecord.ImageIndex = 0;
            this.m_trvNurseRecord.ImageList = this.m_imgThis;
            this.m_trvNurseRecord.Location = new System.Drawing.Point(0, 0);
            this.m_trvNurseRecord.Name = "m_trvNurseRecord";
            treeNode2.Name = "";
            treeNode2.Text = "护理资料";
            this.m_trvNurseRecord.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.m_trvNurseRecord.SelectedImageIndex = 0;
            this.m_trvNurseRecord.Size = new System.Drawing.Size(168, 72);
            this.m_trvNurseRecord.TabIndex = 2;
            this.m_trvNurseRecord.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_trvMedRecord_MouseDown);
            // 
            // m_lklBedManage
            // 
            this.m_lklBedManage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lklBedManage.AutoSize = true;
            this.m_lklBedManage.Location = new System.Drawing.Point(22, 80);
            this.m_lklBedManage.Name = "m_lklBedManage";
            this.m_lklBedManage.Size = new System.Drawing.Size(65, 12);
            this.m_lklBedManage.TabIndex = 2;
            this.m_lklBedManage.TabStop = true;
            this.m_lklBedManage.Text = "床头卡管理";
            this.m_lklBedManage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklBedManage_LinkClicked);
            // 
            // outlookBarBand7
            // 
            this.outlookBarBand7.Background = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(211)))));
            this.outlookBarBand7.ChildControl = this.p7;
            this.outlookBarBand7.Location = new System.Drawing.Point(0, 0);
            this.outlookBarBand7.Name = "outlookBarBand7";
            this.outlookBarBand7.Size = new System.Drawing.Size(0, 0);
            this.outlookBarBand7.TabIndex = 0;
            this.outlookBarBand7.Text = "辅助工具";
            this.outlookBarBand7.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // p7
            // 
            this.p7.AutoScroll = true;
            this.p7.BackColor = System.Drawing.Color.White;
            this.p7.Controls.Add(this.o7);
            this.p7.Location = new System.Drawing.Point(352, 24);
            this.p7.Name = "p7";
            this.p7.Size = new System.Drawing.Size(176, 352);
            this.p7.TabIndex = 12;
            // 
            // o7
            // 
            this.o7.BackColor = System.Drawing.Color.White;
            this.o7.Controls.Add(this.radioButton17);
            this.o7.Controls.Add(this.radioButton15);
            this.o7.Controls.Add(this.radioButton13);
            this.o7.Controls.Add(this.radioButton14);
            this.o7.Controls.Add(this.radioButton12);
            this.o7.Controls.Add(this.radioButton9);
            this.o7.Controls.Add(this.radioButton10);
            this.o7.Controls.Add(this.radioButton6);
            this.o7.Controls.Add(this.groupBox2);
            this.o7.Controls.Add(this.groupBox3);
            this.o7.Controls.Add(this.radioButton27);
            this.o7.Controls.Add(this.groupBox4);
            this.o7.Controls.Add(this.radioButton30);
            this.o7.Controls.Add(this.radioButton31);
            this.o7.Controls.Add(this.groupBox1);
            this.o7.Location = new System.Drawing.Point(0, 0);
            this.o7.Name = "o7";
            this.o7.Size = new System.Drawing.Size(160, 352);
            this.o7.TabIndex = 7;
            this.o7.TabStop = false;
            // 
            // radioButton17
            // 
            this.radioButton17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton17.Location = new System.Drawing.Point(16, 152);
            this.radioButton17.Name = "radioButton17";
            this.radioButton17.Size = new System.Drawing.Size(104, 24);
            this.radioButton17.TabIndex = 6;
            this.radioButton17.Tag = "iCare.frmTemplateSet";
            this.radioButton17.Text = "模板维护";
            this.radioButton17.Click += new System.EventHandler(this.RadioButton_Show);
            // 
            // radioButton15
            // 
            this.radioButton15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton15.Location = new System.Drawing.Point(16, 176);
            this.radioButton15.Name = "radioButton15";
            this.radioButton15.Size = new System.Drawing.Size(104, 24);
            this.radioButton15.TabIndex = 7;
            this.radioButton15.Tag = "iCare.AssitantTool.frmSpecialSymbolManage";
            this.radioButton15.Text = "特殊符号维护";
            this.radioButton15.Click += new System.EventHandler(this.RadioButton_ShowDialog);
            // 
            // radioButton13
            // 
            this.radioButton13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton13.Location = new System.Drawing.Point(16, 64);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(104, 24);
            this.radioButton13.TabIndex = 3;
            this.radioButton13.Tag = "iCare.frmInPatientCaseHistory_SetForm";
            this.radioButton13.Text = "全套病历";
            this.radioButton13.Click += new System.EventHandler(this.RadioButton_ShowDialog);
            // 
            // radioButton14
            // 
            this.radioButton14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton14.Location = new System.Drawing.Point(16, 200);
            this.radioButton14.Name = "radioButton14";
            this.radioButton14.Size = new System.Drawing.Size(120, 24);
            this.radioButton14.TabIndex = 8;
            this.radioButton14.Tag = "iCare.frmManageDocAndNur";
            this.radioButton14.Text = "员工常用值维护";
            this.radioButton14.Click += new System.EventHandler(this.RadioButton_ShowDialog);
            // 
            // radioButton12
            // 
            this.radioButton12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton12.Location = new System.Drawing.Point(16, 40);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(104, 24);
            this.radioButton12.TabIndex = 2;
            this.radioButton12.Tag = "iCare.frmInPatientCaseHistoryArchiving";
            this.radioButton12.Text = "病案归档";
            this.radioButton12.Click += new System.EventHandler(this.RadioButton_Show);
            // 
            // radioButton9
            // 
            this.radioButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton9.Location = new System.Drawing.Point(16, 112);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(104, 24);
            this.radioButton9.TabIndex = 5;
            this.radioButton9.Tag = "iCare.frmPatientLabel";
            this.radioButton9.Text = "辅助标签";
            this.radioButton9.Click += new System.EventHandler(this.RadioButton_ShowDialog);
            // 
            // radioButton10
            // 
            this.radioButton10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton10.Location = new System.Drawing.Point(16, 16);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(104, 24);
            this.radioButton10.TabIndex = 1;
            this.radioButton10.Tag = "iCare.frmConsultationSearch";
            this.radioButton10.Text = "会诊通知";
            this.radioButton10.Click += new System.EventHandler(this.RadioButton_Show);
            // 
            // radioButton6
            // 
            this.radioButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton6.Location = new System.Drawing.Point(16, 88);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(104, 24);
            this.radioButton6.TabIndex = 4;
            this.radioButton6.Tag = "iCare.frmDeactiveRecord";
            this.radioButton6.Text = "删除记录查询";
            this.radioButton6.Click += new System.EventHandler(this.RadioButton_Show);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(8, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(136, 8);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(8, 272);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(136, 8);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Visible = false;
            // 
            // radioButton27
            // 
            this.radioButton27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton27.Location = new System.Drawing.Point(16, 224);
            this.radioButton27.Name = "radioButton27";
            this.radioButton27.Size = new System.Drawing.Size(120, 24);
            this.radioButton27.TabIndex = 9;
            this.radioButton27.Tag = "com.digitalwave.common.ICD10.Tool.frmRepositoryMaintenance";
            this.radioButton27.Text = "关键字维护";
            this.radioButton27.Visible = false;
            this.radioButton27.Click += new System.EventHandler(this.m_mthShowICD10Form);
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(8, 336);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(136, 8);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Visible = false;
            // 
            // radioButton30
            // 
            this.radioButton30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton30.Location = new System.Drawing.Point(16, 288);
            this.radioButton30.Name = "radioButton30";
            this.radioButton30.Size = new System.Drawing.Size(128, 24);
            this.radioButton30.TabIndex = 11;
            this.radioButton30.Tag = "iCare.frmOutPatientRevisitRemind";
            this.radioButton30.Text = "复诊\\随访提醒设置";
            this.radioButton30.Click += new System.EventHandler(this.RadioButton_ShowDialog);
            // 
            // radioButton31
            // 
            this.radioButton31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton31.Location = new System.Drawing.Point(16, 312);
            this.radioButton31.Name = "radioButton31";
            this.radioButton31.Size = new System.Drawing.Size(104, 24);
            this.radioButton31.TabIndex = 12;
            this.radioButton31.Tag = "iCare.frmOutPatientRevisitRecord";
            this.radioButton31.Text = "复诊\\随访记录";
            this.radioButton31.Click += new System.EventHandler(this.RadioButton_ShowDialog);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(8, 424);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 8);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // outlookBarBand8
            // 
            this.outlookBarBand8.Background = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(211)))));
            this.outlookBarBand8.ChildControl = this.p8;
            this.outlookBarBand8.Location = new System.Drawing.Point(0, 0);
            this.outlookBarBand8.Name = "outlookBarBand8";
            this.outlookBarBand8.Size = new System.Drawing.Size(0, 0);
            this.outlookBarBand8.TabIndex = 0;
            this.outlookBarBand8.Text = "iCare知识库";
            this.outlookBarBand8.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // p8
            // 
            this.p8.Controls.Add(this.o8);
            this.p8.Location = new System.Drawing.Point(528, 16);
            this.p8.Name = "p8";
            this.p8.Size = new System.Drawing.Size(176, 200);
            this.p8.TabIndex = 13;
            // 
            // o8
            // 
            this.o8.BackColor = System.Drawing.Color.White;
            this.o8.Controls.Add(this.radioButton7);
            this.o8.Controls.Add(this.radioButton8);
            this.o8.Controls.Add(this.radioButton20);
            this.o8.Controls.Add(this.radioButton21);
            this.o8.Controls.Add(this.radioButton1);
            this.o8.Controls.Add(this.radioButton25);
            this.o8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.o8.Location = new System.Drawing.Point(0, 0);
            this.o8.Name = "o8";
            this.o8.Size = new System.Drawing.Size(176, 200);
            this.o8.TabIndex = 8;
            this.o8.TabStop = false;
            // 
            // radioButton7
            // 
            this.radioButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton7.Location = new System.Drawing.Point(8, 16);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(160, 24);
            this.radioButton7.TabIndex = 1;
            this.radioButton7.Tag = "com.digitalwave.common.ICD10.Tool.frmIllnessDesc";
            this.radioButton7.Text = "国际疾病分类（ICD-10）";
            this.radioButton7.Click += new System.EventHandler(this.m_mthShowICD10Form);
            // 
            // radioButton8
            // 
            this.radioButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton8.Location = new System.Drawing.Point(8, 40);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(104, 24);
            this.radioButton8.TabIndex = 2;
            this.radioButton8.Tag = "com.digitalwave.common.ICD10.Tool.frmIssnessSymptomParallelism";
            this.radioButton8.Text = "疾病与症状";
            this.radioButton8.Click += new System.EventHandler(this.m_mthShowICD10Form);
            // 
            // radioButton20
            // 
            this.radioButton20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton20.Location = new System.Drawing.Point(8, 64);
            this.radioButton20.Name = "radioButton20";
            this.radioButton20.Size = new System.Drawing.Size(104, 24);
            this.radioButton20.TabIndex = 3;
            this.radioButton20.Tag = "com.digitalwave.common.ICD10.Tool.frmICD10_AssistantDiagnoseInf";
            this.radioButton20.Text = "辅助诊疗";
            this.radioButton20.Click += new System.EventHandler(this.m_mthShowICD10Form);
            // 
            // radioButton21
            // 
            this.radioButton21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton21.Location = new System.Drawing.Point(8, 88);
            this.radioButton21.Name = "radioButton21";
            this.radioButton21.Size = new System.Drawing.Size(128, 24);
            this.radioButton21.TabIndex = 4;
            this.radioButton21.Tag = "com.digitalwave.common.ICD10.Tool.frmHospitalInfectionStandard";
            this.radioButton21.Text = "医院感染诊断标准";
            this.radioButton21.Click += new System.EventHandler(this.m_mthShowICD10Form);
            // 
            // radioButton1
            // 
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton1.Location = new System.Drawing.Point(8, 112);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(128, 24);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.Tag = "com.digitalwave.common.library.frmAtlasForCheckLab";
            this.radioButton1.Text = "检验图谱";
            this.radioButton1.Click += new System.EventHandler(this.m_mthShowICD10Form);
            // 
            // radioButton25
            // 
            this.radioButton25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton25.Location = new System.Drawing.Point(8, 136);
            this.radioButton25.Name = "radioButton25";
            this.radioButton25.Size = new System.Drawing.Size(136, 24);
            this.radioButton25.TabIndex = 6;
            this.radioButton25.Tag = "com.digitalwave.common.Test.frmTest";
            this.radioButton25.Text = "便携式数字连接试验";
            this.radioButton25.Click += new System.EventHandler(this.m_mthShowICD10Form);
            // 
            // outlookBarBand10
            // 
            this.outlookBarBand10.Background = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(211)))));
            this.outlookBarBand10.ChildControl = this.m_pnlQualityControl;
            this.outlookBarBand10.Location = new System.Drawing.Point(0, 0);
            this.outlookBarBand10.Name = "outlookBarBand10";
            this.outlookBarBand10.Size = new System.Drawing.Size(0, 0);
            this.outlookBarBand10.TabIndex = 0;
            this.outlookBarBand10.Text = "病案质量控制";
            this.outlookBarBand10.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // m_pnlQualityControl
            // 
            this.m_pnlQualityControl.Controls.Add(this.radioButton5);
            this.m_pnlQualityControl.Controls.Add(this.radioButton19);
            this.m_pnlQualityControl.Controls.Add(this.radioButton22);
            this.m_pnlQualityControl.Controls.Add(this.radioButton23);
            this.m_pnlQualityControl.Controls.Add(this.radioButton24);
            this.m_pnlQualityControl.Location = new System.Drawing.Point(176, 352);
            this.m_pnlQualityControl.Name = "m_pnlQualityControl";
            this.m_pnlQualityControl.Size = new System.Drawing.Size(168, 168);
            this.m_pnlQualityControl.TabIndex = 17;
            // 
            // radioButton5
            // 
            this.radioButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton5.Location = new System.Drawing.Point(16, 8);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(120, 24);
            this.radioButton5.TabIndex = 1;
            this.radioButton5.Tag = "iCare.frmTodayMessage";
            this.radioButton5.Text = "今日提醒";
            this.radioButton5.Click += new System.EventHandler(this.RadioButton_Show);
            // 
            // radioButton19
            // 
            this.radioButton19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton19.Location = new System.Drawing.Point(16, 32);
            this.radioButton19.Name = "radioButton19";
            this.radioButton19.Size = new System.Drawing.Size(120, 24);
            this.radioButton19.TabIndex = 2;
            this.radioButton19.Tag = "iCare.frmCheckRoomExamine";
            this.radioButton19.Text = "三级查房";
            this.radioButton19.Click += new System.EventHandler(this.RadioButton_Show);
            // 
            // radioButton22
            // 
            this.radioButton22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton22.Location = new System.Drawing.Point(16, 56);
            this.radioButton22.Name = "radioButton22";
            this.radioButton22.Size = new System.Drawing.Size(120, 24);
            this.radioButton22.TabIndex = 3;
            this.radioButton22.Tag = "iCare.frmCaseGrade";
            this.radioButton22.Text = "住院病历评分";
            this.radioButton22.Click += new System.EventHandler(this.RadioButton_Show);
            // 
            // radioButton23
            // 
            this.radioButton23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton23.Location = new System.Drawing.Point(16, 126);
            this.radioButton23.Name = "radioButton23";
            this.radioButton23.Size = new System.Drawing.Size(120, 24);
            this.radioButton23.TabIndex = 5;
            this.radioButton23.Tag = "";
            this.radioButton23.Text = "修改痕迹查询";
            this.radioButton23.Visible = false;
            // 
            // radioButton24
            // 
            this.radioButton24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton24.Location = new System.Drawing.Point(16, 80);
            this.radioButton24.Name = "radioButton24";
            this.radioButton24.Size = new System.Drawing.Size(120, 24);
            this.radioButton24.TabIndex = 4;
            this.radioButton24.Tag = "iCare.frmGradeStatistic";
            this.radioButton24.Text = "病历评分统计";
            this.radioButton24.Click += new System.EventHandler(this.RadioButton_Show);
            // 
            // outlookBarBand9
            // 
            this.outlookBarBand9.Background = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(211)))));
            this.outlookBarBand9.ChildControl = this.m_pnlDataAnalyze;
            this.outlookBarBand9.Location = new System.Drawing.Point(0, 0);
            this.outlookBarBand9.Name = "outlookBarBand9";
            this.outlookBarBand9.Size = new System.Drawing.Size(0, 0);
            this.outlookBarBand9.TabIndex = 0;
            this.outlookBarBand9.Text = "临床数据分析";
            this.outlookBarBand9.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // m_pnlDataAnalyze
            // 
            this.m_pnlDataAnalyze.Controls.Add(this.radioButton29);
            this.m_pnlDataAnalyze.Controls.Add(this.radioButton2);
            this.m_pnlDataAnalyze.Controls.Add(this.radioButton3);
            this.m_pnlDataAnalyze.Controls.Add(this.radioButton4);
            this.m_pnlDataAnalyze.Controls.Add(this.radioButton26);
            this.m_pnlDataAnalyze.Controls.Add(this.radioButton28);
            this.m_pnlDataAnalyze.Location = new System.Drawing.Point(528, 232);
            this.m_pnlDataAnalyze.Name = "m_pnlDataAnalyze";
            this.m_pnlDataAnalyze.Size = new System.Drawing.Size(168, 339);
            this.m_pnlDataAnalyze.TabIndex = 16;
            // 
            // radioButton29
            // 
            this.radioButton29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton29.Location = new System.Drawing.Point(16, 128);
            this.radioButton29.Name = "radioButton29";
            this.radioButton29.Size = new System.Drawing.Size(120, 24);
            this.radioButton29.TabIndex = 6;
            this.radioButton29.Tag = "iCare.CareView";
            this.radioButton29.Text = "重症病人监护";
            this.radioButton29.Click += new System.EventHandler(this.RadioButton_Show);
            // 
            // radioButton2
            // 
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton2.Location = new System.Drawing.Point(16, 8);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(120, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Tag = "iCare.frmDataSearches";
            this.radioButton2.Text = "临床数据检索";
            this.radioButton2.Click += new System.EventHandler(this.RadioButton_Show);
            // 
            // radioButton3
            // 
            this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton3.Location = new System.Drawing.Point(16, 32);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(120, 24);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Tag = "iCare.frmIllnessReport";
            this.radioButton3.Text = "临床数据统计";
            this.radioButton3.Click += new System.EventHandler(this.RadioButton_Show);
            // 
            // radioButton4
            // 
            this.radioButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton4.Location = new System.Drawing.Point(16, 56);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(120, 24);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Tag = "com.digitalwave.common.ICD10.Tool.frmClinicDataAnalysis";
            this.radioButton4.Text = "临床数据研究";
            this.radioButton4.Click += new System.EventHandler(this.m_mthShowICD10Form);
            // 
            // radioButton26
            // 
            this.radioButton26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton26.Location = new System.Drawing.Point(16, 80);
            this.radioButton26.Name = "radioButton26";
            this.radioButton26.Size = new System.Drawing.Size(120, 24);
            this.radioButton26.TabIndex = 4;
            this.radioButton26.Tag = "iCare.frmTimeDirection";
            this.radioButton26.Text = "时间趋势";
            this.radioButton26.Click += new System.EventHandler(this.RadioButton_Show);
            // 
            // radioButton28
            // 
            this.radioButton28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton28.Location = new System.Drawing.Point(16, 104);
            this.radioButton28.Name = "radioButton28";
            this.radioButton28.Size = new System.Drawing.Size(120, 24);
            this.radioButton28.TabIndex = 5;
            this.radioButton28.Tag = "iCare.frmRecordSearch";
            this.radioButton28.Text = "记录查询";
            this.radioButton28.Click += new System.EventHandler(this.RadioButton_Show);
            // 
            // frmOutlookBar
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(720, 709);
            this.Controls.Add(this.m_pnlQualityControl);
            this.Controls.Add(this.m_pnlDataAnalyze);
            this.Controls.Add(this.p8);
            this.Controls.Add(this.p7);
            this.Controls.Add(this.p5);
            this.Controls.Add(this.p3);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.m_outlookBar);
            this.Controls.Add(this.p4);
            this.Name = "frmOutlookBar";
            this.Tag = "";
            this.Text = "frmOutlookBar";
            this.Load += new System.EventHandler(this.frmOutlookBar_Load);
            this.p2.ResumeLayout(false);
            this.p3.ResumeLayout(false);
            this.p3.PerformLayout();
            this.p4.ResumeLayout(false);
            this.gpbOperation.ResumeLayout(false);
            this.p5.ResumeLayout(false);
            this.p5.PerformLayout();
            this.p7.ResumeLayout(false);
            this.o7.ResumeLayout(false);
            this.p8.ResumeLayout(false);
            this.o8.ResumeLayout(false);
            this.m_pnlQualityControl.ResumeLayout(false);
            this.m_pnlDataAnalyze.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void frmOutlookBar_Load(object sender, System.EventArgs e)
        {

        }

        #region 初始化模块
        /// <summary>
        /// 窗体节点
        /// </summary>
        private class clsFormNode
        {
            public clsFormNode(string p_strFormName, string p_strClsName)
            {
                this.m_strFormName = p_strFormName;
                this.m_strClsName = p_strClsName;
            }

            public string m_strFormName;
            public string m_strClsName;
            public int m_intImageIndex = 0;
            public clsFormItemNode[] m_objItemArr
            {
                get
                {
                    return (clsFormItemNode[])m_arlItem.ToArray(typeof(clsFormItemNode));
                }
            }
            private ArrayList m_arlItem = new ArrayList();

            public clsFormItemNode m_objAddItem(string p_strItemName, string p_strControlName)
            {
                clsFormItemNode objItem = new clsFormItemNode(this.m_strClsName, p_strItemName, p_strControlName);
                m_arlItem.Add(objItem);
                return objItem;
            }


        }
        /// <summary>
        /// 窗体项目节点
        /// </summary>
        private class clsFormItemNode
        {
            public clsFormItemNode(string p_strFormClsName, string p_strItemName, string p_strControlName)
            {
                this.m_strFormClsName = p_strFormClsName;
                this.m_strItemName = p_strItemName;
                this.m_strControlName = p_strControlName;
            }

            public string m_strFormClsName;
            public string m_strItemName;
            public string m_strControlName;
            public int m_intImageIndex = 1;
            public clsFormItemNode[] m_objSubItemArr;//子项目


            public clsFormItemNode[] m_objItemArr
            {
                get
                {
                    return (clsFormItemNode[])m_arlItem.ToArray(typeof(clsFormItemNode));
                }
            }
            private ArrayList m_arlItem = new ArrayList();

            public clsFormItemNode m_objAddItem(string p_strItemName, string p_strControlName)
            {
                clsFormItemNode objItem = new clsFormItemNode(this.m_strFormClsName, p_strItemName, p_strControlName);
                m_arlItem.Add(objItem);
                return objItem;
            }
        }

        /// <summary>
        /// 添加窗体节点
        /// </summary>
        /// <param name="p_tvrInput"></param>
        /// <param name="p_objFormArr"></param>
        private void m_mthAddFormNode(TreeView p_tvrInput, clsFormNode[] p_objFormArr)
        {

        }

        private void m_mthInitTreeView()
        {
            #region 病历资料
            TreeNode trnRoot = m_trvMedRecord.Nodes.Add("住院病案首页");
            trnRoot.ImageIndex = 0;
            if (clsEMRLogin.m_StrCurrentHospitalNO == "450101001")//南宁
            {
                trnRoot.Tag = "iCare.frmInHospitalMainRecord_GX";
            }
            else
            {
                trnRoot.Tag = "iCare.frmInHospitalMainRecord";
            }
            //if (clsEMRLogin.m_StrCurrentHospitalNO == "450101001")//南宁,移至病案质量控制
            //{
            //    trnRoot = m_trvMedRecord.Nodes.Add("住院病案首页(病案室用)");
            //    trnRoot.Tag = "iCare.frmInHospitalMainRecord_GXForCH";
            //}
            TreeNode trnCaseHistory = new TreeNode("住院病历");
            trnCaseHistory.ImageIndex = 0;
            trnCaseHistory.SelectedImageIndex = 0;
            m_trvMedRecord.Nodes.Add(trnCaseHistory);
            trnRoot = trnCaseHistory.Nodes.Add("普通住院病历");
            trnRoot.Tag = "iCare.frmInPatientCaseHistory";
            trnRoot = trnCaseHistory.Nodes.Add("住院病历--自由录入风格");
            trnRoot.Tag = "iCare.frmInPatientCaseHistory_NewStyle";
            TreeNode trnInPatMed = new TreeNode("专科表格式住院病历");
            m_mthLoadInPatMed(trnInPatMed);
            trnCaseHistory.Nodes.Add(trnInPatMed);
            if (!(clsEMRLogin.m_StrCurrentHospitalNO == "450101001"))//南宁
            {
                trnRoot = m_trvMedRecord.Nodes.Add("病历摘要");
                trnRoot.Tag = "iCare.frmCaseHistorySummary";
            }
            trnRoot = m_trvMedRecord.Nodes.Add("病程记录");
            trnRoot.Tag = "iCare.frmSubDiseaseTrack";
            trnRoot = m_trvMedRecord.Nodes.Add("会诊记录");
            trnRoot.Tag = "iCare.frmConsultation";

            //trnRoot = m_trvMedRecord.Nodes.Add("ICU转入记录");
            //trnRoot.Tag = "iCare.frmPICUShiftInForm";

            //trnRoot = m_trvMedRecord.Nodes.Add("ICU转出记录");
            //trnRoot.Tag = "iCare.frmPICUShiftOutForm";

            trnRoot = m_trvMedRecord.Nodes.Add("出院记录");
            trnRoot.Tag = "iCare.frmOutHospital";
            if (clsEMRLogin.m_StrCurrentHospitalNO != "440104001")//市一
            {
                trnRoot = m_trvMedRecord.Nodes.Add("24小时内入出院记录");
                trnRoot.Tag = "iCare.frmEMR_OutHospitalIn24Hours";

                trnRoot = m_trvMedRecord.Nodes.Add("入院24小时内死亡记录");
                trnRoot.Tag = "iCare.frmDeathRecordIn24Hours";
            }
            if (!(clsEMRLogin.m_StrCurrentHospitalNO == "450101001"))//南宁
            {
                trnRoot = m_trvMedRecord.Nodes.Add("病案质量评分表");
                trnRoot.Tag = "iCare.frmQCRecord";
            }
            //trnRoot = m_trvMedRecord.Nodes.Add("死亡记录");
            //trnRoot.Tag = "iCare.frmDeathRecord";

            //trnRoot = m_trvMedRecord.Nodes.Add("死亡病例讨论记录");
            //trnRoot.Tag = "iCare.frmDeathCaseDiscuss";


            #endregion

            #region 申请单
            trnRoot = m_trvApplyRecord.Nodes[0].Nodes.Add("B型超声显像检查申请单");

            trnRoot.Tag = "iCare.frmBUltrasonicCheckOrder";
            trnRoot = m_trvApplyRecord.Nodes[0].Nodes.Add("CT检查申请单");
            trnRoot.Tag = "iCare.frmCTCheckOrder";
            trnRoot = m_trvApplyRecord.Nodes[0].Nodes.Add("X线申请单");
            trnRoot.Tag = "iCare.frmXRayCheckOrder";
            trnRoot = m_trvApplyRecord.Nodes[0].Nodes.Add("SPECT检查申请单");
            trnRoot.Tag = "iCare.frmSPECT";
            trnRoot = m_trvApplyRecord.Nodes[0].Nodes.Add("高压氧治疗申请单");
            trnRoot.Tag = "iCare.frmHighOxygen";
            trnRoot = m_trvApplyRecord.Nodes[0].Nodes.Add("病理活体组织送检单");
            trnRoot.Tag = "iCare.frmPathologyOrgCheckOrder";
            trnRoot = m_trvApplyRecord.Nodes[0].Nodes.Add("MRI申请单");
            trnRoot.Tag = "iCare.frmMRIApply";
            trnRoot = m_trvApplyRecord.Nodes[0].Nodes.Add("心电图申请单");
            trnRoot.Tag = "iCare.frmEKGOrder";
            trnRoot = m_trvApplyRecord.Nodes[0].Nodes.Add("电脑多导睡眠图检查申请单");
            trnRoot.Tag = "iCare.frmNuclearOrder";
            trnRoot = m_trvApplyRecord.Nodes[0].Nodes.Add("核医学检查申请单");
            trnRoot.Tag = "iCare.frmPSGOrder";
            m_trvApplyRecord.Nodes[0].ExpandAll();
            #endregion

            #region 护理资料
            if (clsEMRLogin.m_StrCurrentHospitalNO == "440104001")//市一
            {
                trnRoot = m_trvNurseRecord.Nodes[0].Nodes.Add("入院病人评估");
                trnRoot.Tag = "iCare.frmInPatientEvaluate";
            }
            else if (clsEMRLogin.m_StrCurrentHospitalNO != "450101001")//佛二
            {
                trnRoot = m_trvNurseRecord.Nodes[0].Nodes.Add("病人入院评估表");
                trnRoot.Tag = "iCare.frmEMR_InPatientEvaluate";
            }
            trnRoot = m_trvNurseRecord.Nodes[0].Nodes.Add("三 测 表");
            if (clsEMRLogin.m_StrCurrentHospitalNO == "450101001")//南宁
            {
                trnRoot.Tag = "iCare.frmThreeMeasureRecordGN";
            }
            else
            {
                trnRoot.Tag = "iCare.frmThreeMeasureRecord";
            }
            trnRoot = m_trvNurseRecord.Nodes[0].Nodes.Add("一般护理记录");
            trnRoot.Tag = "iCare.frmMainGeneralNurseRecord";
            trnRoot = m_trvNurseRecord.Nodes[0].Nodes.Add("一般护理记录(整体录入)");
            trnRoot.Tag = "iCare.frmGeneralNurseWholeRecord";
            trnRoot = m_trvNurseRecord.Nodes[0].Nodes.Add("一般患者护理记录");
            trnRoot.Tag = "iCare.frmGeneralNurseRecord_GX";

            if (clsEMRLogin.m_StrCurrentHospitalNO != "450101001" || clsEMRLogin.m_StrCurrentHospitalNO == "000000000")//非南宁
            {
                trnRoot = m_trvNurseRecord.Nodes[0].Nodes.Add("观察项目记录表");
                trnRoot.Tag = "iCare.frmWatchItemTrack";
                //trnRoot = m_trvNurseRecord.Nodes[0].Nodes.Add("危重患者护理记录");
                //trnRoot.Tag = "iCare.frmIntensiveTendMain_FC";
            }
            trnRoot = m_trvNurseRecord.Nodes[0].Nodes.Add("危重症监护中心特护记录单");
            trnRoot.Tag = "iCare.frmMainICUIntensiveTend";
            trnRoot = m_trvNurseRecord.Nodes[0].Nodes.Add("手术护理记录");
            //if (clsEMRLogin.m_StrCurrentHospitalNO == "450101001")//南宁
            //{
                trnRoot.Tag = "iCare.frmEMR_OPNurseRecord_GX";
            //}
            //else
            //{
            //    trnRoot.Tag = "iCare.frmOperationRecord";
            //}
            trnRoot = m_trvNurseRecord.Nodes[0].Nodes.Add("手术器械、敷料点数表");
            if (clsEMRLogin.m_StrCurrentHospitalNO == "450101001")//南宁
            {
                trnRoot.Tag = "iCare.frmEMR_OPInstrumentQty";
            }
            else
            {
                trnRoot.Tag = "iCare.frmOperationEquipmentQty";
            }
            trnRoot = m_trvNurseRecord.Nodes[0].Nodes.Add("中心ICU呼吸机治疗监护记录单");
            trnRoot.Tag = "iCare.frmMainICUBreath";
            if (clsEMRLogin.m_StrCurrentHospitalNO == "450101001" || clsEMRLogin.m_StrCurrentHospitalNO == "000000000")//南宁
            {
                trnRoot = m_trvNurseRecord.Nodes[0].Nodes.Add("快速微量血糖检测记录表");
                trnRoot.Tag = "iCare.frmMiniBooldSugarChk_GX";
                //trnRoot.Tag = "iCare.frmMiniBooldSugar";

                trnRoot = m_trvNurseRecord.Nodes[0].Nodes.Add("ICU护理记录");
                trnRoot.Tag = "iCare.frmICUNurseRecord_GX";
                trnRoot = m_trvNurseRecord.Nodes[0].Nodes.Add("外科ICU监护记录");
                trnRoot.Tag = "iCare.frmSurgeryICUWardship";
                trnRoot = m_trvNurseRecord.Nodes[0].Nodes.Add("危重患者护理记录");
                trnRoot.Tag = "iCare.frmIntensiveTendMain_GX";
                trnRoot = m_trvNurseRecord.Nodes[0].Nodes.Add("心血管外科特护记录");
                trnRoot.Tag = "iCare.frmCardiovascularTendMain_GX";
                trnRoot = m_trvNurseRecord.Nodes[0].Nodes.Add("静脉特殊用药观察记录表");
                trnRoot.Tag = "iCare.frmVeinSpecialUseDrug";
                trnRoot = m_trvNurseRecord.Nodes[0].Nodes.Add("出入量登记表");
                trnRoot.Tag = "iCare.frmRegisterQuantity";
                trnRoot = m_trvNurseRecord.Nodes[0].Nodes.Add("通用ICU护理记录");
                trnRoot.Tag = "iCare.frmICUNurseRecordMain";
                
            }
            else if (clsEMRLogin.m_StrCurrentHospitalNO != "450101001")//非南宁
            {
                trnRoot = m_trvNurseRecord.Nodes[0].Nodes.Add("快速微量血糖检测记录表");
                trnRoot.Tag = "iCare.frmMiniBooldSugarChk";
            }

            m_trvNurseRecord.Nodes[0].ExpandAll();
            #endregion
        }
        #endregion

        private void RadioButton_Show(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                RadioButton rbt = (RadioButton)sender;
                if (rbt.Checked && rbt.Tag != null)
                {
                    if (m_objMainMenuFunction.m_blnIsSaveBeforeNewForm())
                        return;

                    Type type = Type.GetType(rbt.Tag.ToString());
                    Form frmMR = (Form)Activator.CreateInstance(type);
                    if (new clsMainMenuFunction().m_blnCheckSamePatientForm(frmMR))
                        return;
                    if (new clsMainMenuFunction().m_blnCheckForFormOpen(frmMR, false))
                        return;
                    frmMR.MdiParent = clsEMRLogin.s_FrmMDI;
                    frmMR.WindowState = FormWindowState.Maximized;
                    frmMR.Show();

                    if (frmMR is frmHRPBaseForm && MDIParent.s_ObjCurrentPatient != null)
                        ((frmHRPBaseForm)frmMR).m_mthSetPatient(MDIParent.s_ObjCurrentPatient);
                }
            }
            catch (Exception ex)
            {
                clsPublicFunction.ShowInformationMessageBox(ex.Message + "   " + ex.StackTrace);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void RadioButton_ShowDialog(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (m_objMainMenuFunction.m_blnIsSaveBeforeNewForm())
                    return;
                RadioButton rbt = (RadioButton)sender;
                if (rbt.Checked && rbt.Tag != null)
                {
                    Type type = Type.GetType(rbt.Tag.ToString());
                    Form frmMR = (Form)Activator.CreateInstance(type);
                    frmMR.StartPosition = FormStartPosition.CenterParent;

                    if (frmMR is frmHRPBaseForm && MDIParent.s_ObjCurrentPatient != null)
                        ((frmHRPBaseForm)frmMR).m_mthSetPatient(MDIParent.s_ObjCurrentPatient);
                    frmMR.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                clsPublicFunction.ShowInformationMessageBox(ex.Message + "   " + ex.StackTrace);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private Control m_ctlGetControlByName(Control p_ctlParent, string p_strCtlName)
        {
            if (p_ctlParent.Name == p_strCtlName)
                return p_ctlParent;

            foreach (Control ctl in p_ctlParent.Controls)
            {
                Control ctlSub = m_ctlGetControlByName(ctl, p_strCtlName);
                if (ctlSub != null)
                    return ctlSub;
            }

            return null;
        }

        #region 调用检验申请单
        private void m_lklLISApply_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            new clsMainMenuFunction().m_mthLISApply();

        }
        #endregion

        #region 调用报告单
        private void m_lklShowReport_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            new clsMainMenuFunction().m_mthShowReport();
        }
        #endregion

        /// <summary>
        /// 打开医嘱
        /// </summary>
        private void m_mthDocAdvice()
        {
            if (clsEMRLogin.m_StrCurrentHospitalNO == "450101001")//广西区医院
            {
                //直接调用his的医嘱  modify by tfzhang at 2005-12-8 16:40
                com.digitalwave.iCare.gui.HIS.frmDoctorOrder frm = new com.digitalwave.iCare.gui.HIS.frmDoctorOrder();

                if (new clsMainMenuFunction().m_blnCheckForFormOpen(frm, false))
                    return;
                frm.MdiParent = clsEMRLogin.s_FrmMDI;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();

            }
            else if (clsEMRLogin.m_StrCurrentHospitalNO != "440104001")//非市一
            {
                if (MDIParent.s_ObjCurrentPatient == null)
                {
                    MessageBox.Show("请先选择病人信息！");
                    return;
                }
                com.digitalwave.iCare.BIHOrder.frmBIHOrderInput objBIHO = new com.digitalwave.iCare.BIHOrder.frmBIHOrderInput();

                if (new clsMainMenuFunction().m_blnCheckForFormOpen(objBIHO, false))
                    return;
                objBIHO.LoginInfo = clsEMRLogin.LoginInfo;
                objBIHO.m_mthSetCurrentPatient(MDIParent.s_ObjCurrentPatient.m_StrInPatientID);
                objBIHO.MdiParent = clsEMRLogin.s_FrmMDI;
                objBIHO.Show();
            }

        }

        #region Public
        private static UtilityLibrary.WinControls.OutlookBar s_outlookBar;
        public static UtilityLibrary.WinControls.OutlookBar s_OutlookBar
        {
            get
            {
                return s_outlookBar;
            }
        }
        private static TreeNode s_trnInPatMed;

        private void m_trvMedRecord_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
        {
            if (m_trvMedRecord.SelectedNode == null)
                m_blnNodeIsNull = true;
            else
                m_blnNodeIsNull = false;
        }
        /// <summary>
        /// 住院病历树节点
        /// </summary>
        public static TreeNode s_TrnInPatMed
        {
            get
            {
                return s_trnInPatMed;
            }
        }
        #endregion

        #region 知识库
        private void m_mthShowICD10Form(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                RadioButton rbt = (RadioButton)sender;
                if (rbt.Checked && rbt.Tag != null)
                {
                    System.Reflection.Assembly asm = System.Reflection.Assembly.LoadFrom(Application.StartupPath + "\\EMR_ICD10_Tool.dll");
                    Form frmMR = (Form)(asm.CreateInstance(rbt.Tag.ToString()));

                    if (new clsMainMenuFunction().m_blnCheckForFormOpen(frmMR, false))
                        return;
                    frmMR.MdiParent = clsEMRLogin.s_FrmMDI;
                    frmMR.WindowState = FormWindowState.Maximized;
                    if (frmMR is com.digitalwave.iCare.ValueObject.iLoginInfo)
                        ((com.digitalwave.iCare.ValueObject.iLoginInfo)frmMR).LoginInfo = clsEMRLogin.LoginInfo;
                    frmMR.Show();
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                clsPublicFunction.ShowInformationMessageBox(ex.Message + "   " + ex.StackTrace);
            }
        }
        #endregion

        #region 病人病床管理
        /// <summary>
        /// 显示病人病床信息
        /// </summary>
        private void m_mthShowPatientBed()
        {
            //Form_HRPExplorer frm = new Form_HRPExplorer();
            com.digitalwave.emr.BEDExplorer.frmHRPExplorer frm = new com.digitalwave.emr.BEDExplorer.frmHRPExplorer(true, clsEMRLogin.LoginInfo.m_strEmpID, clsEMRLogin.s_FrmMDI);

            if (new clsMainMenuFunction().m_blnCheckHasOpenHRPExplorer())
            {
                return;
            }
            if (new clsMainMenuFunction().m_blnCheckForFormOpen(frm, false))
                return;
            frm.MdiParent = clsEMRLogin.s_FrmMDI;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void m_lklBedManage_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            frmBedCardManage frmBed = new frmBedCardManage();
            frmBed.StartPosition = FormStartPosition.CenterParent;
            if (MDIParent.s_ObjCurrentPatient != null)
                frmBed.m_mthSetPatient(MDIParent.s_ObjCurrentPatient);
            frmBed.ShowDialog();
        }
        #endregion

        #region 住院病历


        private void m_mthLoadInPatMed(TreeNode p_trnParent)
        {
            clsInpatMedRec_Type[] objTypeArr = clsEMR_StaticObject.s_ObjInpatMedRec_DataShare.m_objTypeArr;
            if (clsEMRLogin.m_StrCurrentHospitalNO == "000000000")
            {
                new clsInpatMedRecDomain().m_lngGetAllFormID(out objTypeArr);
            }
            else
            {
                if (clsEMRLogin.m_ObjCurDeptOfEmpArr != null && clsEMRLogin.m_ObjCurDeptOfEmpArr.Length > 0)
                {
                    for (int j = 0 ; j < clsEMRLogin.m_ObjCurDeptOfEmpArr.Length ; j++)
                    {
                        if (clsEMRLogin.m_ObjCurDeptOfEmpArr[j].strShortNo == "1050000")
                        {
                            TreeNode trnNew = p_trnParent.Nodes.Add("新生儿入室记录");
                            trnNew.Tag = "iCare.frmNewBabyInRoomRecord";
                            trnNew = p_trnParent.Nodes.Add("候产记录");
                            trnNew.Tag = "iCare.frmWaitLayRecord_Acad";
                            trnNew = p_trnParent.Nodes.Add("产后记录");
                            trnNew.Tag = "iCare.frmPostPartum_Acad";
                            trnNew = p_trnParent.Nodes.Add("催产素静脉点滴观察表");
                            trnNew.Tag = "iCare.frmHurryVeinRecord_Acad";
                            break;
                        }
                    }
                }
            }
            if (objTypeArr != null)
            {
                for (int i = 0; i < objTypeArr.Length; i++)
                {
                    TreeNode trnNew = p_trnParent.Nodes.Add(objTypeArr[i].m_strTypeName);
                    trnNew.Tag = "iCare." + objTypeArr[i].m_strTypeID.Trim();
                }
            }
            objTypeArr = null;
        }

        private void m_trvMedRecord_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //if (m_blnIsSaveBeforeNewForm())
                //    return;

                TreeView trvSender = (TreeView)sender;

                TreeNode trnSelected = trvSender.GetNodeAt(e.X, e.Y);
                if (trnSelected == null || trnSelected.Tag == null)
                    return;

                string strTag = trnSelected.Tag.ToString();
                int intIndex = strTag.IndexOf(">>");
                if (intIndex == -1)//节点为窗体
                {
                    m_objMainMenuFunction.m_mthOpenMedicalRecord(strTag);
                }
                else if (intIndex > 0)
                {
                    string strFormName = strTag.Substring(0, intIndex);
                    string strControlName = strTag.Substring(intIndex + 2, strTag.Length - intIndex - 2);

                    Form frm = null;

                    foreach (Form Frmtemp in clsEMRLogin.s_FrmMDI.MdiChildren)
                    {
                        if (Frmtemp.GetType().FullName == strFormName)
                        {
                            frm = Frmtemp;
                            break;
                        }
                    }

                    if (frm == null)
                        return;
                    Control ctlFocus = m_ctlGetControlByName(frm, strControlName);
                    if (ctlFocus == null)
                        return;
                    frm.Activate();
                    ctlFocus.Focus();
                }
            }//end if
        }
        #endregion

        private void m_outlookBar_ItemClicked(UtilityLibrary.WinControls.OutlookBarBand band, UtilityLibrary.WinControls.OutlookBarItem item)
        {
            switch (band.Name)//Text可能有重复
            {
                case "m_obbOperationInfo":
                    if (item.Tag != null)
                    {
                        //if (m_blnIsSaveBeforeNewForm())
                        //    return;

                        m_objMainMenuFunction.m_mthOpenMedicalRecord(item.Tag.ToString());
                    }
                    return;
            }

            switch (item.Text)
            {
                case "病人浏览":
                    m_mthShowPatientBed();
                    break;
                case "医嘱":
                    m_mthDocAdvice();
                    break;
            }
        }


        private void m_mth_LinkClicked_ShowDialog(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                LinkLabel lkl = (LinkLabel)sender;
                if (lkl.Tag != null)
                {
                    Type type = Type.GetType(lkl.Tag.ToString());
                    Form frmMR = (Form)Activator.CreateInstance(type);
                    frmMR.StartPosition = FormStartPosition.CenterParent;
                    frmMR.ShowDialog();
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                clsPublicFunction.ShowInformationMessageBox(ex.Message + "   " + ex.StackTrace);
            }
        }

        #region 权限控制
        /// <summary>
        /// 控制此窗体的权限
        /// </summary>
        private void m_mthFunctionControl()
        {
            System.Data.DataTable dtRecords = null;
            frmRowlAndUser.m_mthGetUserRole(this.Name, ref dtRecords);

            bool blnShwo = false;

            for (int i = m_outlookBar.Bands.Count - 1; i >= 0; i--)
            {
                blnShwo = false;
                if (dtRecords != null)
                {
                    for (int j = 0; j < dtRecords.Rows.Count; j++)
                    {
                        if (m_outlookBar.Bands[i].Name.ToUpper() == dtRecords.Rows[j]["PURVIEW_FUNCTION"].ToString().ToUpper())
                        {
                            blnShwo = true;
                            break;
                        }
                    }
                }
                //m_outlookBar.Bands[i].Visible=blnShwo;
                if (!blnShwo)
                    m_outlookBar.Bands.RemoveAt(i);
            }

            #region 控制权限细节到TreeView
            for (int i = m_trvMedRecord.Nodes.Count - 1; i >= 0; i--)
            {
                m_mthSetTreeViewPurview(m_trvMedRecord.Nodes[i], dtRecords);
            }

            for (int i = m_trvApplyRecord.Nodes.Count - 1; i >= 0; i--)
            {
                m_mthSetTreeViewPurview(m_trvApplyRecord.Nodes[i], dtRecords);
            }

            for (int i = m_trvNurseRecord.Nodes.Count - 1; i >= 0; i--)
            {
                m_mthSetTreeViewPurview(m_trvNurseRecord.Nodes[i], dtRecords);
            }
            #endregion 控制权限细节到TreeView

            #region 控制权限细节到普通控件
            m_mthSetControlPurview(o7, dtRecords);

            m_mthSetControlPurview(o8, dtRecords);

            m_mthSetControlPurview(m_pnlQualityControl, dtRecords);

            m_mthSetControlPurview(m_pnlDataAnalyze, dtRecords);
            #endregion 控制权限细节到普通控件

            blnShwo = false;
            for (int i = 0; i < m_outlookBar.Bands.Count; i++)
            {
                for (int j = m_outlookBar.Bands[i].Items.Count - 1; j >= 0; j--)
                {
                    blnShwo = false;

                    for (int k = 0; k < dtRecords.Rows.Count; k++)
                    {
                        if (m_outlookBar.Bands[i].Items[j].Text.Trim().ToUpper() == dtRecords.Rows[k]["PURVIEW_CNAME"].ToString().ToUpper())
                        {
                            blnShwo = true;
                            break;
                        }
                    }
                    if (!blnShwo)
                        m_outlookBar.Bands[i].Items.RemoveAt(j);
                }
            }
        }

        /// <summary>
        /// 控制TreeView中指定节点下各个子节点的显示效果
        /// </summary>
        /// <param name="p_trvNode">父节点</param>
        /// <param name="p_dtRecords">此窗体所具有的权限集合</param>
        private void m_mthSetTreeViewPurview(TreeNode p_trvNode, System.Data.DataTable p_dtRecords)
        {
            bool blnShow = false;//根据这个决定节点是否显示 如果父节点的Tag属性无内容且其下无子节点，此父节点不显示，如果父节点的Tag属性无内容且其下有子节点，则此节点显示，如果父节点的Tag属性有内容不管其下是否有子节点都显示。

            for (int i = p_trvNode.Nodes.Count - 1; i >= 0; i--)
            {
                m_mthSetTreeViewPurview(p_trvNode.Nodes[i], p_dtRecords);
            }


            if (p_trvNode.Tag != null)
            {
                if (p_trvNode.Nodes.Count > 0)
                {
                    blnShow = true;
                }
                else
                {
                    for (int i = 0; i < p_dtRecords.Rows.Count; i++)
                    {
                        if (p_trvNode.Tag.ToString().Trim().ToUpper() == p_dtRecords.Rows[i]["PURVIEW_FUNCTION"].ToString().Trim().ToUpper())
                        {
                            blnShow = true;
                            break;
                        }
                    }
                }
            }
            else if (p_trvNode.Nodes.Count > 0)
                blnShow = true;
            else
                blnShow = false;

            if (!blnShow)
                p_trvNode.Remove();

        }


        /// <summary>
        /// 控制窗体中其他控件中的子控件的显示效果
        /// </summary>
        /// <param name="p_ctlParent">子控件所属父控件</param>
        /// <param name="p_dtRecords">此窗体所具有的权限集合</param>
        private void m_mthSetControlPurview(Control p_ctlParent, System.Data.DataTable p_dtRecords)
        {
            bool blnShwo = false;

            ArrayList ControlArry = new ArrayList();

            foreach (Control ctltemp in p_ctlParent.Controls)
            {
                if (ctltemp != null)
                {
                    blnShwo = false;
                    for (int i = 0; i < p_dtRecords.Rows.Count; i++)
                    {
                        if (ctltemp.Tag != null)
                        {
                            if (ctltemp.Tag.ToString().Trim().ToUpper() == p_dtRecords.Rows[i]["PURVIEW_FUNCTION"].ToString().Trim().ToUpper())
                            {
                                blnShwo = true;
                                break;
                            }
                        }
                        else
                        {
                            blnShwo = true;
                        }
                    }

                    if (!blnShwo)
                        ctltemp.Visible = false;
                    else
                        ControlArry.Add(ctltemp);
                }
            }
            m_mthSetControlLocation(ref ControlArry);
        }

        /// <summary>
        /// 控件位置调整
        /// </summary>
        /// <param name="p_arry">所有显示的控件的集合</param>
        private void m_mthSetControlLocation(ref ArrayList p_arry)
        {
            int p = -1;
            string strExpr = "id>0";
            string strSort = "id";

            System.Data.DataTable dtRecord = new System.Data.DataTable();
            System.Data.DataRow[] drTemp = null;
            dtRecord.Columns.Add("id", typeof(int));

            for (int i = 0; i < p_arry.Count; i++)
            {
                dtRecord.Rows.Add(new object[] { ((Control)p_arry[i]).TabIndex });
            }

            if (dtRecord != null)
            {
                if (dtRecord.Rows.Count > 0)
                {
                    drTemp = dtRecord.Select(strExpr, strSort);
                }
                else
                    return;
            }
            else
                return;

            for (int i = 0; i < drTemp.Length; i++)
            {
                for (int j = 0; j < p_arry.Count; j++)
                {
                    if (drTemp[i][0].ToString().Trim() == ((Control)p_arry[j]).TabIndex.ToString().Trim())
                    {
                        if (p == -1)
                            ((Control)p_arry[j]).Top = 10;
                        else
                        {
                            ((Control)p_arry[j]).Top = ((Control)p_arry[p]).Bottom + 3;
                        }
                        p = j;
                        break;
                    }
                }
            }
            //			for(int i=0;i<p_arry.Count;i++)
            //			{
            //				if (p==0)
            //				{
            //					((Control)p_arry[i]).Top=5;
            //				}
            //				else
            //				{
            //					((Control)p_arry[i]).Top=((Control)p_arry[i-1]).Bottom+5;
            //				}
            //				p++;
            //			}
        }
        #endregion 权限控制

        #region 图文工作站
        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            new clsMainMenuFunction().m_mthShowARWorkStation();
        }
        #endregion 图文工作站

        private void m_mthEnableFunc()
        {
            if (clsEMRLogin.m_StrCurrentHospitalNO == "440104001")//市一
            {
                m_lklLISApply.Visible = false;
                m_lklShowReport.Visible = false;
                linkLabel1.Visible = false;
                radioButton29.Visible = false;//重症病人监护
                radioButton3.Visible = false;//临床数据统计
                radioButton4.Visible = false;//临床数据研究
                radioButton25.Visible = false;//便携式数字连接试验

                radioButton11.Tag = "iCare.frmOperationAgreedRecord";
            }
            if (clsEMRLogin.m_StrCurrentHospitalNO == "000000000")//演示
            {
                radioButton34.Visible = true;
                radioButton16.Visible = true;
            }


        }

        private void radioButton34_Click(object sender, EventArgs e)
        {
            new clsMainMenuFunction().m_mthLoadAssemblyForm("iCareAnaesthesia.dll", "iCare.Anaesthesia.frmAnaParamSetting");
        }

        private void radioButton16_Click(object sender, EventArgs e)
        {
             new clsMainMenuFunction().m_mthLoadAssemblyForm("iCareAnaesthesia.dll", "iCare.Anaesthesia.frmOperationRequisition");
        }
    }
}
