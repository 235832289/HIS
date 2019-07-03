using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility.Controls;
using com.digitalwave.iCare.BIHOrder;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ��λ��������ʾ��
    /// </summary>
    public class frmBedAdmin : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        #region �ؼ�����
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        internal System.Windows.Forms.Label m_lblBedNumber;
        internal System.Windows.Forms.Label m_lblEmptyBedNumber;
        internal System.Windows.Forms.ImageList imlLarge;
        internal System.Windows.Forms.ImageList imlSmall;
        internal System.Windows.Forms.ToolTip toolTip1;
        internal PinkieControls.ButtonXP cmdAddBed;
        internal PinkieControls.ButtonXP cmdTurnIn;
        internal PinkieControls.ButtonXP cmdTurnOut;
        internal PinkieControls.ButtonXP cmdLeaveHospital;
        internal PinkieControls.ButtonXP cmdClose;
        internal PinkieControls.ButtonXP m_cmdUndoOut;
        internal TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        internal System.Windows.Forms.ListView m_lsvTurnInNA;
        internal System.Windows.Forms.ListView m_lsvTurnOutNA;
        internal System.Windows.Forms.ListView m_lsvTurnOutA;
        internal System.Windows.Forms.ListView m_lsvTurnInA;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        private System.Windows.Forms.ColumnHeader columnHeader30;
        private System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.ColumnHeader columnHeader32;
        private System.Windows.Forms.ContextMenu m_ctmBedAdmin;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.ColumnHeader SourceArea;
        private System.Windows.Forms.ColumnHeader sourceAreaNA;
        private System.Windows.Forms.ColumnHeader targeArea;
        private System.Windows.Forms.ColumnHeader TargeAreaA;
        private System.Windows.Forms.ContextMenu TransferMenu;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.ColumnHeader columnHeader33;
        private System.Windows.Forms.ColumnHeader columnHeader34;
        internal ContextMenu BedAdmin;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItemOrder;
        private System.Windows.Forms.MenuItem menuItemCharge;
        private System.Windows.Forms.ColumnHeader columnHeader35;
        internal PinkieControls.ButtonXP m_txtrefresh;
        private System.Windows.Forms.MenuItem menuItemCanWarpBed;
        internal System.Windows.Forms.ListView m_lsvDept;
        private System.Windows.Forms.ColumnHeader columnHeader37;
        private System.Windows.Forms.ColumnHeader columnHeader38;
        private CollapsibleSplitter splitter1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private com.digitalwave.Utility.Controls.CollapsibleSplitter collapsibleSplitter1;
        private System.Windows.Forms.Panel m_panArear;
        private System.Windows.Forms.ColumnHeader columnHeader39;
        private System.Windows.Forms.ColumnHeader columnHeader40;
        private System.Windows.Forms.ColumnHeader columnHeader41;
        private System.Windows.Forms.ColumnHeader columnHeader42;
        private System.Windows.Forms.ColumnHeader columnHeader43;
        private System.Windows.Forms.ColumnHeader columnHeader44;
        private System.Windows.Forms.ColumnHeader columnHeader45;
        private System.Windows.Forms.ColumnHeader columnHeader46;
        private System.Windows.Forms.ColumnHeader columnHeader47;
        private System.Windows.Forms.MenuItem menuItem18;
        private System.Windows.Forms.MenuItem menuItem19;
        private System.Windows.Forms.MenuItem menuItem20;
        private System.Windows.Forms.MenuItem menuItem21;
        private System.Windows.Forms.MenuItem menuItem22;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem menuItem16;
        private System.Windows.Forms.MenuItem menuItemTransIn;
        private System.Windows.Forms.MenuItem menuItemTransOut;
        private System.Windows.Forms.MenuItem menuItemLeave;
        private System.Windows.Forms.MenuItem menuItem26;
        internal System.Windows.Forms.ListView m_lsvBedInfo;
        private System.Windows.Forms.MenuItem menuItemReflash;
        private System.Windows.Forms.MenuItem menuItem14;
        internal ComboBox m_cmbView;
        private Label label3;
        internal Label m_lblPatientArea;
        internal Label m_lblDEPTNAME_VCHR;
        private ColumnHeader columnHeader2;
        internal ToolTip toolTip2;
        private MenuItem menuItem15;
        internal PinkieControls.ButtonXP m_cmdHoliday;
        internal MenuItem menuItemHoliday;
        internal MenuItem menuItemCanHoliday;
        private MenuItem menuItemCancelLeave;
        private MenuItem menuItemPrtLeaNotice;
        private MenuItem menuItem32;
        private MenuItem menuItem33;
        private MenuItem menuItem34;
        private MenuItem menuItem35;
        private ContextMenuStrip m_cmsBedAdmin;
        internal PinkieControls.ButtonXP m_cmdLeaHosNoCheck;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private MenuItem menuItemTransBed;
        internal PinkieControls.ButtonXP btnSpire;
        internal PinkieControls.ButtonXP btnPaymentNotice;
        private System.ComponentModel.IContainer components;
        #endregion

        #region ���캯��
        public frmBedAdmin()
        {
            //
            // Windows ���������֧���������
            //
            InitializeComponent();

            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //
        }

        /// <summary>
        /// ������������ʹ�õ���Դ��
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
        #endregion

        #region Windows ������������ɵĴ���
        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBedAdmin));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            this.BedAdmin = new System.Windows.Forms.ContextMenu();
            this.menuItemOrder = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.menuItemCharge = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem32 = new System.Windows.Forms.MenuItem();
            this.menuItemTransIn = new System.Windows.Forms.MenuItem();
            this.menuItemTransOut = new System.Windows.Forms.MenuItem();
            this.menuItemTransBed = new System.Windows.Forms.MenuItem();
            this.menuItem33 = new System.Windows.Forms.MenuItem();
            this.menuItemLeave = new System.Windows.Forms.MenuItem();
            this.menuItemCancelLeave = new System.Windows.Forms.MenuItem();
            this.menuItemPrtLeaNotice = new System.Windows.Forms.MenuItem();
            this.menuItem34 = new System.Windows.Forms.MenuItem();
            this.menuItemHoliday = new System.Windows.Forms.MenuItem();
            this.menuItemCanHoliday = new System.Windows.Forms.MenuItem();
            this.menuItemCanWarpBed = new System.Windows.Forms.MenuItem();
            this.menuItem35 = new System.Windows.Forms.MenuItem();
            this.menuItemReflash = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem26 = new System.Windows.Forms.MenuItem();
            this.imlSmall = new System.Windows.Forms.ImageList(this.components);
            this.imlLarge = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.m_lsvBedInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader39 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader40 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader41 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader42 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader43 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader34 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader33 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader35 = new System.Windows.Forms.ColumnHeader();
            this.TransferMenu = new System.Windows.Forms.ContextMenu();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.m_ctmBedAdmin = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.collapsibleSplitter1 = new com.digitalwave.Utility.Controls.CollapsibleSplitter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.m_lsvTurnInNA = new System.Windows.Forms.ListView();
            this.sourceAreaNA = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader44 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.m_lsvTurnOutNA = new System.Windows.Forms.ListView();
            this.targeArea = new System.Windows.Forms.ColumnHeader();
            this.columnHeader21 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader26 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader23 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader25 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader46 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader24 = new System.Windows.Forms.ColumnHeader();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.m_lsvTurnInA = new System.Windows.Forms.ListView();
            this.SourceArea = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader45 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.m_lsvTurnOutA = new System.Windows.Forms.ListView();
            this.TargeAreaA = new System.Windows.Forms.ColumnHeader();
            this.columnHeader27 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader32 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader29 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader28 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader31 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader47 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader30 = new System.Windows.Forms.ColumnHeader();
            this.splitter1 = new com.digitalwave.Utility.Controls.CollapsibleSplitter();
            this.m_panArear = new System.Windows.Forms.Panel();
            this.m_lsvDept = new System.Windows.Forms.ListView();
            this.columnHeader38 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader37 = new System.Windows.Forms.ColumnHeader();
            this.cmdAddBed = new PinkieControls.ButtonXP();
            this.m_cmsBedAdmin = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_cmbView = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_lblPatientArea = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lblEmptyBedNumber = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_lblBedNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_lblDEPTNAME_VCHR = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSpire = new PinkieControls.ButtonXP();
            this.m_cmdLeaHosNoCheck = new PinkieControls.ButtonXP();
            this.m_cmdHoliday = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtrefresh = new PinkieControls.ButtonXP();
            this.m_cmdUndoOut = new PinkieControls.ButtonXP();
            this.cmdTurnIn = new PinkieControls.ButtonXP();
            this.cmdTurnOut = new PinkieControls.ButtonXP();
            this.cmdLeaveHospital = new PinkieControls.ButtonXP();
            this.cmdClose = new PinkieControls.ButtonXP();
            this.btnPaymentNotice = new PinkieControls.ButtonXP();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.m_panArear.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BedAdmin
            // 
            this.BedAdmin.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemOrder,
            this.menuItemCharge,
            this.menuItem32,
            this.menuItemTransIn,
            this.menuItemTransOut,
            this.menuItemTransBed,
            this.menuItem33,
            this.menuItemLeave,
            this.menuItemCancelLeave,
            this.menuItemPrtLeaNotice,
            this.menuItem34,
            this.menuItemHoliday,
            this.menuItemCanHoliday,
            this.menuItemCanWarpBed,
            this.menuItem35,
            this.menuItemReflash,
            this.menuItem10,
            this.menuItem16,
            this.menuItem26});
            this.BedAdmin.Popup += new System.EventHandler(this.BedAdmin_Popup);
            // 
            // menuItemOrder
            // 
            this.menuItemOrder.Index = 0;
            this.menuItemOrder.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem18,
            this.menuItem19,
            this.menuItem20,
            this.menuItem21,
            this.menuItem22});
            this.menuItemOrder.Text = "ҽ��";
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 0;
            this.menuItem18.Text = "ҽ��¼��";
            this.menuItem18.Click += new System.EventHandler(this.menuItem18_Click);
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 1;
            this.menuItem19.Text = "ҽ������ӡ";
            this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 2;
            this.menuItem20.Text = "ִ��ҽ��(��ǰ����)";
            this.menuItem20.Visible = false;
            this.menuItem20.Click += new System.EventHandler(this.menuItem20_Click);
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 3;
            this.menuItem21.Text = "ִ��ҽ��(��ǰ����)";
            this.menuItem21.Visible = false;
            this.menuItem21.Click += new System.EventHandler(this.menuItem21_Click);
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 4;
            this.menuItem22.Text = "ҽ����ѯ";
            this.menuItem22.Visible = false;
            this.menuItem22.Click += new System.EventHandler(this.menuItem22_Click);
            // 
            // menuItemCharge
            // 
            this.menuItemCharge.Index = 1;
            this.menuItemCharge.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem12,
            this.menuItem14});
            this.menuItemCharge.Text = "����";
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 0;
            this.menuItem12.Text = "���ù���";
            this.menuItem12.Visible = false;
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 1;
            this.menuItem14.Text = "��¼����";
            this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
            // 
            // menuItem32
            // 
            this.menuItem32.Index = 2;
            this.menuItem32.Text = "-";
            // 
            // menuItemTransIn
            // 
            this.menuItemTransIn.Index = 3;
            this.menuItemTransIn.Text = "ת�� (&F4)";
            this.menuItemTransIn.Click += new System.EventHandler(this.menuItem23_Click);
            // 
            // menuItemTransOut
            // 
            this.menuItemTransOut.Index = 4;
            this.menuItemTransOut.Text = "ת�� (&F5)";
            this.menuItemTransOut.Click += new System.EventHandler(this.menuItem24_Click);
            // 
            // menuItemTransBed
            // 
            this.menuItemTransBed.Index = 5;
            this.menuItemTransBed.Text = "ת��";
            this.menuItemTransBed.Click += new System.EventHandler(this.menuItemTransBed_Click);
            // 
            // menuItem33
            // 
            this.menuItem33.Index = 6;
            this.menuItem33.Text = "-";
            // 
            // menuItemLeave
            // 
            this.menuItemLeave.Index = 7;
            this.menuItemLeave.Text = "��Ժ (&F6)";
            this.menuItemLeave.Click += new System.EventHandler(this.menuItem25_Click);
            // 
            // menuItemCancelLeave
            // 
            this.menuItemCancelLeave.Index = 8;
            this.menuItemCancelLeave.Text = "������Ժ";
            this.menuItemCancelLeave.Click += new System.EventHandler(this.menuItemCancelLeave_Click);
            // 
            // menuItemPrtLeaNotice
            // 
            this.menuItemPrtLeaNotice.Index = 9;
            this.menuItemPrtLeaNotice.Text = "��ӡ��Ժ֪ͨ";
            this.menuItemPrtLeaNotice.Click += new System.EventHandler(this.menuItem30_Click);
            // 
            // menuItem34
            // 
            this.menuItem34.Index = 10;
            this.menuItem34.Text = "-";
            // 
            // menuItemHoliday
            // 
            this.menuItemHoliday.Index = 11;
            this.menuItemHoliday.Text = "���";
            this.menuItemHoliday.Click += new System.EventHandler(this.menuItem28_Click);
            // 
            // menuItemCanHoliday
            // 
            this.menuItemCanHoliday.Index = 12;
            this.menuItemCanHoliday.Text = "�������";
            this.menuItemCanHoliday.Click += new System.EventHandler(this.menuItem29_Click);
            // 
            // menuItemCanWarpBed
            // 
            this.menuItemCanWarpBed.Index = 13;
            this.menuItemCanWarpBed.Text = "��������";
            this.menuItemCanWarpBed.Click += new System.EventHandler(this.menuItem17_Click);
            // 
            // menuItem35
            // 
            this.menuItem35.Index = 14;
            this.menuItem35.Text = "-";
            // 
            // menuItemReflash
            // 
            this.menuItemReflash.Index = 15;
            this.menuItemReflash.Text = "ˢ��";
            this.menuItemReflash.Click += new System.EventHandler(this.menuItem27_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 16;
            this.menuItem10.Text = "�༭��λ";
            this.menuItem10.Visible = false;
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 17;
            this.menuItem16.Text = "���Ӵ�λ (&F2)";
            this.menuItem16.Visible = false;
            this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
            // 
            // menuItem26
            // 
            this.menuItem26.Index = 18;
            this.menuItem26.Text = "ɾ����λ";
            this.menuItem26.Visible = false;
            this.menuItem26.Click += new System.EventHandler(this.menuItem26_Click);
            // 
            // imlSmall
            // 
            this.imlSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSmall.ImageStream")));
            this.imlSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSmall.Images.SetKeyName(0, "��λ_��.gif");
            this.imlSmall.Images.SetKeyName(1, "�ж���-��.gif");
            this.imlSmall.Images.SetKeyName(2, "�ж���-Σ.gif");
            this.imlSmall.Images.SetKeyName(3, "�ж���-һ��.gif");
            this.imlSmall.Images.SetKeyName(4, "������-��.gif");
            this.imlSmall.Images.SetKeyName(5, "������-Σ.gif");
            this.imlSmall.Images.SetKeyName(6, "������-һ��.gif");
            this.imlSmall.Images.SetKeyName(7, "���ؼ�-��.gif");
            this.imlSmall.Images.SetKeyName(8, "���ؼ�-Σ.gif");
            this.imlSmall.Images.SetKeyName(9, "���ؼ�-һ��.gif");
            this.imlSmall.Images.SetKeyName(10, "���޻���-��.gif");
            this.imlSmall.Images.SetKeyName(11, "���޻���-Σ.gif");
            this.imlSmall.Images.SetKeyName(12, "���޻���-һ��.gif");
            this.imlSmall.Images.SetKeyName(13, "��һ��-��.gif");
            this.imlSmall.Images.SetKeyName(14, "��һ��-Σ.gif");
            this.imlSmall.Images.SetKeyName(15, "��һ��-һ��.gif");
            this.imlSmall.Images.SetKeyName(16, "Ů����-��.gif");
            this.imlSmall.Images.SetKeyName(17, "Ů����-Σ.gif");
            this.imlSmall.Images.SetKeyName(18, "Ů����-һ��.gif");
            this.imlSmall.Images.SetKeyName(19, "Ů����-��.gif");
            this.imlSmall.Images.SetKeyName(20, "Ů����-Σ.gif");
            this.imlSmall.Images.SetKeyName(21, "Ů����-һ��.gif");
            this.imlSmall.Images.SetKeyName(22, "Ů�ؼ�-��.gif");
            this.imlSmall.Images.SetKeyName(23, "Ů�ؼ�-Σ.gif");
            this.imlSmall.Images.SetKeyName(24, "Ů�ؼ�-һ��.gif");
            this.imlSmall.Images.SetKeyName(25, "Ů�޻���-��.gif");
            this.imlSmall.Images.SetKeyName(26, "Ů�޻���-Σ.gif");
            this.imlSmall.Images.SetKeyName(27, "Ů�޻���-һ��.gif");
            this.imlSmall.Images.SetKeyName(28, "Ůһ��-��.gif");
            this.imlSmall.Images.SetKeyName(29, "Ůһ��-Σ.gif");
            this.imlSmall.Images.SetKeyName(30, "Ůһ��-һ��.gif");
            // 
            // imlLarge
            // 
            this.imlLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlLarge.ImageStream")));
            this.imlLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imlLarge.Images.SetKeyName(0, "��λ_��.gif");
            this.imlLarge.Images.SetKeyName(1, "�ж���-��.gif");
            this.imlLarge.Images.SetKeyName(2, "�ж���-Σ.gif");
            this.imlLarge.Images.SetKeyName(3, "�ж���-һ��.gif");
            this.imlLarge.Images.SetKeyName(4, "������-��.gif");
            this.imlLarge.Images.SetKeyName(5, "������-Σ.gif");
            this.imlLarge.Images.SetKeyName(6, "������-һ��.gif");
            this.imlLarge.Images.SetKeyName(7, "���ؼ�-��.gif");
            this.imlLarge.Images.SetKeyName(8, "���ؼ�-Σ.gif");
            this.imlLarge.Images.SetKeyName(9, "���ؼ�-һ��.gif");
            this.imlLarge.Images.SetKeyName(10, "���޻���-��.gif");
            this.imlLarge.Images.SetKeyName(11, "���޻���-Σ.gif");
            this.imlLarge.Images.SetKeyName(12, "���޻���-һ��.gif");
            this.imlLarge.Images.SetKeyName(13, "��һ��-��.gif");
            this.imlLarge.Images.SetKeyName(14, "��һ��-Σ.gif");
            this.imlLarge.Images.SetKeyName(15, "��һ��-һ��.gif");
            this.imlLarge.Images.SetKeyName(16, "Ů����-��.gif");
            this.imlLarge.Images.SetKeyName(17, "Ů����-Σ.gif");
            this.imlLarge.Images.SetKeyName(18, "Ů����-һ��.gif");
            this.imlLarge.Images.SetKeyName(19, "Ů����-��.gif");
            this.imlLarge.Images.SetKeyName(20, "Ů����-Σ.gif");
            this.imlLarge.Images.SetKeyName(21, "Ů����-һ��.gif");
            this.imlLarge.Images.SetKeyName(22, "Ů�ؼ�-��.gif");
            this.imlLarge.Images.SetKeyName(23, "Ů�ؼ�-Σ.gif");
            this.imlLarge.Images.SetKeyName(24, "Ů�ؼ�-һ��.gif");
            this.imlLarge.Images.SetKeyName(25, "Ů�޻���-��.gif");
            this.imlLarge.Images.SetKeyName(26, "Ů�޻���-Σ.gif");
            this.imlLarge.Images.SetKeyName(27, "Ů�޻���-һ��.gif");
            this.imlLarge.Images.SetKeyName(28, "Ůһ��-��.gif");
            this.imlLarge.Images.SetKeyName(29, "Ůһ��-Σ.gif");
            this.imlLarge.Images.SetKeyName(30, "Ůһ��-һ��.gif");
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 1000;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "��ǰ��λ��Ϣ";
            // 
            // m_lsvBedInfo
            // 
            this.m_lsvBedInfo.AllowDrop = true;
            this.m_lsvBedInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvBedInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader39,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader2,
            this.columnHeader10,
            this.columnHeader40,
            this.columnHeader41,
            this.columnHeader42,
            this.columnHeader43,
            this.columnHeader34,
            this.columnHeader33,
            this.columnHeader35});
            this.m_lsvBedInfo.ContextMenu = this.BedAdmin;
            this.m_lsvBedInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvBedInfo.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvBedInfo.FullRowSelect = true;
            this.m_lsvBedInfo.GridLines = true;
            this.m_lsvBedInfo.HideSelection = false;
            this.m_lsvBedInfo.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.m_lsvBedInfo.LargeImageList = this.imlLarge;
            this.m_lsvBedInfo.Location = new System.Drawing.Point(191, 98);
            this.m_lsvBedInfo.MultiSelect = false;
            this.m_lsvBedInfo.Name = "m_lsvBedInfo";
            this.m_lsvBedInfo.ShowItemToolTips = true;
            this.m_lsvBedInfo.Size = new System.Drawing.Size(833, 339);
            this.m_lsvBedInfo.SmallImageList = this.imlSmall;
            this.m_lsvBedInfo.TabIndex = 4;
            this.toolTip1.SetToolTip(this.m_lsvBedInfo, "test");
            this.m_lsvBedInfo.UseCompatibleStateImageBehavior = false;
            this.m_lsvBedInfo.ItemActivate += new System.EventHandler(this.m_lsvBedInfo_ItemActivate);
            this.m_lsvBedInfo.SelectedIndexChanged += new System.EventHandler(this.m_lsvBedInfo_SelectedIndexChanged);
            this.m_lsvBedInfo.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_lsvBedInfo_DragDrop);
            this.m_lsvBedInfo.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_lsvBedInfo_ColumnClick);
            this.m_lsvBedInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvBedInfo_KeyDown);
            this.m_lsvBedInfo.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.m_lsvBedInfo_ItemDrag);
            this.m_lsvBedInfo.DragOver += new System.Windows.Forms.DragEventHandler(this.m_lsvBedInfo_DragOver);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 34;
            // 
            // columnHeader39
            // 
            this.columnHeader39.Text = "����";
            this.columnHeader39.Width = 47;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "סԺ��";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "��������";
            this.columnHeader6.Width = 77;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "�Ա�";
            this.columnHeader7.Width = 45;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "����";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "����";
            this.columnHeader10.Width = 46;
            // 
            // columnHeader40
            // 
            this.columnHeader40.Text = "����ҽ��";
            this.columnHeader40.Width = 75;
            // 
            // columnHeader41
            // 
            this.columnHeader41.Text = "��Ժ���";
            this.columnHeader41.Width = 120;
            // 
            // columnHeader42
            // 
            this.columnHeader42.Text = "��Ժʱ��";
            this.columnHeader42.Width = 140;
            // 
            // columnHeader43
            // 
            this.columnHeader43.Text = "�������";
            this.columnHeader43.Width = 80;
            // 
            // columnHeader34
            // 
            this.columnHeader34.Text = "������";
            this.columnHeader34.Width = 78;
            // 
            // columnHeader33
            // 
            this.columnHeader33.Text = "��ʳ����";
            this.columnHeader33.Width = 69;
            // 
            // columnHeader35
            // 
            this.columnHeader35.Text = "��λ��";
            this.columnHeader35.Width = 150;
            // 
            // TransferMenu
            // 
            this.TransferMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem9,
            this.menuItem15});
            this.TransferMenu.Popup += new System.EventHandler(this.TransferMenu_Popup);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 0;
            this.menuItem9.Text = "����ת��";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 1;
            this.menuItem15.Text = "��ӡת��֪ͨ��";
            this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // m_ctmBedAdmin
            // 
            this.m_ctmBedAdmin.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3,
            this.menuItem4,
            this.menuItem5,
            this.menuItem6,
            this.menuItem7,
            this.menuItem8});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "���Ӵ�λ";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "ת��";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "ת��";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Text = "ת��";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 4;
            this.menuItem5.Text = "����Ԥ��Ժ";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 5;
            this.menuItem6.Text = "��Ժ";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 6;
            this.menuItem7.Text = "���";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 7;
            this.menuItem8.Text = "�ر�";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolTip2
            // 
            this.toolTip2.AutoPopDelay = 5000;
            this.toolTip2.InitialDelay = 500;
            this.toolTip2.IsBalloon = true;
            this.toolTip2.ReshowDelay = 1000;
            // 
            // collapsibleSplitter1
            // 
            this.collapsibleSplitter1.AnimationDelay = 20;
            this.collapsibleSplitter1.AnimationStep = 20;
            this.collapsibleSplitter1.BorderStyle3D = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.collapsibleSplitter1.ControlToHide = this.tabControl1;
            this.collapsibleSplitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.collapsibleSplitter1.ExpandParentForm = false;
            this.collapsibleSplitter1.Location = new System.Drawing.Point(191, 437);
            this.collapsibleSplitter1.MinExtra = 200;
            this.collapsibleSplitter1.Name = "collapsibleSplitter1";
            this.collapsibleSplitter1.Size = new System.Drawing.Size(833, 8);
            this.collapsibleSplitter1.TabIndex = 11;
            this.collapsibleSplitter1.TabStop = false;
            this.toolTip2.SetToolTip(this.collapsibleSplitter1, "��ʾ\\���ز���ת��ת����Ϣ");
            this.collapsibleSplitter1.UseAnimations = false;
            this.collapsibleSplitter1.VisualStyle = com.digitalwave.Utility.Controls.VisualStyles.XP;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(191, 445);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(833, 144);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_lsvTurnInNA);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(825, 116);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ת�벡�ˣ�δ���գ�";
            // 
            // m_lsvTurnInNA
            // 
            this.m_lsvTurnInNA.AllowDrop = true;
            this.m_lsvTurnInNA.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sourceAreaNA,
            this.columnHeader15,
            this.columnHeader20,
            this.columnHeader17,
            this.columnHeader16,
            this.columnHeader19,
            this.columnHeader44,
            this.columnHeader18,
            this.columnHeader3,
            this.columnHeader4});
            this.m_lsvTurnInNA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvTurnInNA.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvTurnInNA.FullRowSelect = true;
            this.m_lsvTurnInNA.GridLines = true;
            this.m_lsvTurnInNA.HideSelection = false;
            this.m_lsvTurnInNA.Location = new System.Drawing.Point(0, 0);
            this.m_lsvTurnInNA.MultiSelect = false;
            this.m_lsvTurnInNA.Name = "m_lsvTurnInNA";
            this.m_lsvTurnInNA.Size = new System.Drawing.Size(825, 116);
            this.m_lsvTurnInNA.TabIndex = 0;
            this.m_lsvTurnInNA.UseCompatibleStateImageBehavior = false;
            this.m_lsvTurnInNA.View = System.Windows.Forms.View.Details;
            this.m_lsvTurnInNA.DoubleClick += new System.EventHandler(this.m_lsvTurnInNA_DoubleClick);
            this.m_lsvTurnInNA.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_lsvTurnInNA_ColumnClick);
            this.m_lsvTurnInNA.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.m_lsvTurnInNA_ItemDrag);
            this.m_lsvTurnInNA.DragOver += new System.Windows.Forms.DragEventHandler(this.m_lsvTurnInNA_DragOver);
            // 
            // sourceAreaNA
            // 
            this.sourceAreaNA.Text = "ԭ����";
            this.sourceAreaNA.Width = 120;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "סԺ��";
            this.columnHeader15.Width = 120;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "��������";
            this.columnHeader20.Width = 90;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "�Ա�";
            this.columnHeader17.Width = 50;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "����";
            this.columnHeader16.Width = 50;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "����";
            this.columnHeader19.Width = 70;
            // 
            // columnHeader44
            // 
            this.columnHeader44.Text = "��Ժ���";
            this.columnHeader44.Width = 110;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "��Ժ����";
            this.columnHeader18.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "�벡��ʱ��";
            this.columnHeader4.Width = 175;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.m_lsvTurnOutNA);
            this.tabPage3.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(825, 116);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ת�����ˣ�δ���գ�";
            // 
            // m_lsvTurnOutNA
            // 
            this.m_lsvTurnOutNA.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.targeArea,
            this.columnHeader21,
            this.columnHeader26,
            this.columnHeader23,
            this.columnHeader22,
            this.columnHeader25,
            this.columnHeader46,
            this.columnHeader24});
            this.m_lsvTurnOutNA.ContextMenu = this.TransferMenu;
            this.m_lsvTurnOutNA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvTurnOutNA.FullRowSelect = true;
            this.m_lsvTurnOutNA.GridLines = true;
            this.m_lsvTurnOutNA.Location = new System.Drawing.Point(0, 0);
            this.m_lsvTurnOutNA.Name = "m_lsvTurnOutNA";
            this.m_lsvTurnOutNA.Size = new System.Drawing.Size(825, 116);
            this.m_lsvTurnOutNA.TabIndex = 0;
            this.m_lsvTurnOutNA.UseCompatibleStateImageBehavior = false;
            this.m_lsvTurnOutNA.View = System.Windows.Forms.View.Details;
            this.m_lsvTurnOutNA.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_lsvTurnOutNA_ColumnClick);
            // 
            // targeArea
            // 
            this.targeArea.Text = "Ŀ�겡��";
            this.targeArea.Width = 120;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "סԺ��";
            this.columnHeader21.Width = 130;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "��������";
            this.columnHeader26.Width = 90;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "�Ա�";
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "����";
            this.columnHeader22.Width = 70;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "����";
            this.columnHeader25.Width = 70;
            // 
            // columnHeader46
            // 
            this.columnHeader46.Text = "��Ժ���";
            this.columnHeader46.Width = 110;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "��Ժ����";
            this.columnHeader24.Width = 150;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_lsvTurnInA);
            this.tabPage1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(825, 116);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ת�벡�ˣ��ѽ��գ�";
            // 
            // m_lsvTurnInA
            // 
            this.m_lsvTurnInA.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SourceArea,
            this.columnHeader8,
            this.columnHeader14,
            this.columnHeader11,
            this.columnHeader9,
            this.columnHeader13,
            this.columnHeader45,
            this.columnHeader12});
            this.m_lsvTurnInA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvTurnInA.FullRowSelect = true;
            this.m_lsvTurnInA.GridLines = true;
            this.m_lsvTurnInA.Location = new System.Drawing.Point(0, 0);
            this.m_lsvTurnInA.Name = "m_lsvTurnInA";
            this.m_lsvTurnInA.Size = new System.Drawing.Size(825, 116);
            this.m_lsvTurnInA.TabIndex = 0;
            this.m_lsvTurnInA.UseCompatibleStateImageBehavior = false;
            this.m_lsvTurnInA.View = System.Windows.Forms.View.Details;
            this.m_lsvTurnInA.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_lsvTurnInA_ColumnClick);
            // 
            // SourceArea
            // 
            this.SourceArea.Text = "ԭ����";
            this.SourceArea.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "סԺ��";
            this.columnHeader8.Width = 130;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "��������";
            this.columnHeader14.Width = 90;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "�Ա�";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "����";
            this.columnHeader9.Width = 70;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "����";
            this.columnHeader13.Width = 70;
            // 
            // columnHeader45
            // 
            this.columnHeader45.Text = "��Ժ���";
            this.columnHeader45.Width = 110;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "��Ժ����";
            this.columnHeader12.Width = 150;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.m_lsvTurnOutA);
            this.tabPage4.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(825, 116);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "ת�����ˣ��ѽ��գ�";
            // 
            // m_lsvTurnOutA
            // 
            this.m_lsvTurnOutA.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TargeAreaA,
            this.columnHeader27,
            this.columnHeader32,
            this.columnHeader29,
            this.columnHeader28,
            this.columnHeader31,
            this.columnHeader47,
            this.columnHeader30});
            this.m_lsvTurnOutA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvTurnOutA.FullRowSelect = true;
            this.m_lsvTurnOutA.GridLines = true;
            this.m_lsvTurnOutA.Location = new System.Drawing.Point(0, 0);
            this.m_lsvTurnOutA.Name = "m_lsvTurnOutA";
            this.m_lsvTurnOutA.Size = new System.Drawing.Size(825, 116);
            this.m_lsvTurnOutA.TabIndex = 0;
            this.m_lsvTurnOutA.UseCompatibleStateImageBehavior = false;
            this.m_lsvTurnOutA.View = System.Windows.Forms.View.Details;
            this.m_lsvTurnOutA.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_lsvTurnOutA_ColumnClick);
            // 
            // TargeAreaA
            // 
            this.TargeAreaA.Text = "Ŀ�겡��";
            this.TargeAreaA.Width = 120;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "סԺ��";
            this.columnHeader27.Width = 130;
            // 
            // columnHeader32
            // 
            this.columnHeader32.Text = "��������";
            this.columnHeader32.Width = 90;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "�Ա�";
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "����";
            this.columnHeader28.Width = 70;
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "����";
            this.columnHeader31.Width = 70;
            // 
            // columnHeader47
            // 
            this.columnHeader47.Text = "��Ժ���";
            this.columnHeader47.Width = 110;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "��Ժ����";
            this.columnHeader30.Width = 150;
            // 
            // splitter1
            // 
            this.splitter1.AnimationDelay = 20;
            this.splitter1.AnimationStep = 20;
            this.splitter1.BorderStyle3D = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.splitter1.ControlToHide = this.m_panArear;
            this.splitter1.ExpandParentForm = false;
            this.splitter1.Location = new System.Drawing.Point(183, 0);
            this.splitter1.MinExtra = 828;
            this.splitter1.MinSize = 0;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 589);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            this.toolTip2.SetToolTip(this.splitter1, "��ʾ\\���ز����б�");
            this.splitter1.UseAnimations = false;
            this.splitter1.VisualStyle = com.digitalwave.Utility.Controls.VisualStyles.XP;
            // 
            // m_panArear
            // 
            this.m_panArear.Controls.Add(this.m_lsvDept);
            this.m_panArear.Controls.Add(this.cmdAddBed);
            this.m_panArear.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panArear.Location = new System.Drawing.Point(0, 0);
            this.m_panArear.Name = "m_panArear";
            this.m_panArear.Size = new System.Drawing.Size(183, 589);
            this.m_panArear.TabIndex = 12;
            // 
            // m_lsvDept
            // 
            this.m_lsvDept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvDept.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader38,
            this.columnHeader37});
            this.m_lsvDept.Font = new System.Drawing.Font("����", 10.5F);
            this.m_lsvDept.FullRowSelect = true;
            this.m_lsvDept.GridLines = true;
            this.m_lsvDept.HideSelection = false;
            this.m_lsvDept.Location = new System.Drawing.Point(3, 10);
            this.m_lsvDept.Name = "m_lsvDept";
            this.m_lsvDept.Size = new System.Drawing.Size(177, 615);
            this.m_lsvDept.TabIndex = 9;
            this.m_lsvDept.UseCompatibleStateImageBehavior = false;
            this.m_lsvDept.View = System.Windows.Forms.View.Details;
            this.m_lsvDept.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_lsvDept_KeyUp);
            this.m_lsvDept.Click += new System.EventHandler(this.m_lsvDept_Click);
            // 
            // columnHeader38
            // 
            this.columnHeader38.Text = "���";
            this.columnHeader38.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader38.Width = 48;
            // 
            // columnHeader37
            // 
            this.columnHeader37.Text = "��������";
            this.columnHeader37.Width = 125;
            // 
            // cmdAddBed
            // 
            this.cmdAddBed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmdAddBed.DefaultScheme = true;
            this.cmdAddBed.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdAddBed.Hint = "";
            this.cmdAddBed.Location = new System.Drawing.Point(60, 37);
            this.cmdAddBed.Name = "cmdAddBed";
            this.cmdAddBed.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdAddBed.Size = new System.Drawing.Size(100, 32);
            this.cmdAddBed.TabIndex = 4;
            this.cmdAddBed.Text = "���Ӵ�λ(F2)";
            this.cmdAddBed.Visible = false;
            this.cmdAddBed.Click += new System.EventHandler(this.cmdAddBed_Click);
            // 
            // m_cmsBedAdmin
            // 
            this.m_cmsBedAdmin.Name = "m_cmsBedAdmin";
            this.m_cmsBedAdmin.Size = new System.Drawing.Size(61, 4);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_cmbView);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.m_lblPatientArea);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.m_lblEmptyBedNumber);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.m_lblBedNumber);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.m_lblDEPTNAME_VCHR);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(191, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(833, 40);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // m_cmbView
            // 
            this.m_cmbView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_cmbView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbView.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbView.FormattingEnabled = true;
            this.m_cmbView.Items.AddRange(new object[] {
            "��ͼ��",
            "��ϸ����"});
            this.m_cmbView.Location = new System.Drawing.Point(720, 14);
            this.m_cmbView.Name = "m_cmbView";
            this.m_cmbView.Size = new System.Drawing.Size(75, 20);
            this.m_cmbView.TabIndex = 11;
            this.m_cmbView.SelectedIndexChanged += new System.EventHandler(this.m_cmbView_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(444, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 14);
            this.label6.TabIndex = 4;
            this.label6.Text = "�ܴ�λ:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_lblPatientArea
            // 
            this.m_lblPatientArea.AutoSize = true;
            this.m_lblPatientArea.Location = new System.Drawing.Point(287, 17);
            this.m_lblPatientArea.Name = "m_lblPatientArea";
            this.m_lblPatientArea.Size = new System.Drawing.Size(35, 14);
            this.m_lblPatientArea.TabIndex = 2;
            this.m_lblPatientArea.Text = "����";
            this.m_lblPatientArea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "����:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_lblEmptyBedNumber
            // 
            this.m_lblEmptyBedNumber.AutoSize = true;
            this.m_lblEmptyBedNumber.Font = new System.Drawing.Font("����", 10.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblEmptyBedNumber.ForeColor = System.Drawing.Color.Red;
            this.m_lblEmptyBedNumber.Location = new System.Drawing.Point(613, 17);
            this.m_lblEmptyBedNumber.Name = "m_lblEmptyBedNumber";
            this.m_lblEmptyBedNumber.Size = new System.Drawing.Size(15, 14);
            this.m_lblEmptyBedNumber.TabIndex = 7;
            this.m_lblEmptyBedNumber.Text = "0";
            this.m_lblEmptyBedNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(557, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 14);
            this.label8.TabIndex = 6;
            this.label8.Text = "�մ�λ:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_lblBedNumber
            // 
            this.m_lblBedNumber.AutoSize = true;
            this.m_lblBedNumber.Font = new System.Drawing.Font("����", 10.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblBedNumber.ForeColor = System.Drawing.Color.Red;
            this.m_lblBedNumber.Location = new System.Drawing.Point(501, 17);
            this.m_lblBedNumber.Name = "m_lblBedNumber";
            this.m_lblBedNumber.Size = new System.Drawing.Size(15, 14);
            this.m_lblBedNumber.TabIndex = 5;
            this.m_lblBedNumber.Text = "0";
            this.m_lblBedNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(675, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "��ͼ:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_lblDEPTNAME_VCHR
            // 
            this.m_lblDEPTNAME_VCHR.AutoSize = true;
            this.m_lblDEPTNAME_VCHR.Location = new System.Drawing.Point(69, 17);
            this.m_lblDEPTNAME_VCHR.Name = "m_lblDEPTNAME_VCHR";
            this.m_lblDEPTNAME_VCHR.Size = new System.Drawing.Size(35, 14);
            this.m_lblDEPTNAME_VCHR.TabIndex = 0;
            this.m_lblDEPTNAME_VCHR.Text = "����";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "����:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPaymentNotice);
            this.groupBox1.Controls.Add(this.btnSpire);
            this.groupBox1.Controls.Add(this.m_cmdLeaHosNoCheck);
            this.groupBox1.Controls.Add(this.m_cmdHoliday);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_txtrefresh);
            this.groupBox1.Controls.Add(this.m_cmdUndoOut);
            this.groupBox1.Controls.Add(this.cmdTurnIn);
            this.groupBox1.Controls.Add(this.cmdTurnOut);
            this.groupBox1.Controls.Add(this.cmdLeaveHospital);
            this.groupBox1.Controls.Add(this.cmdClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(191, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(833, 58);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btnSpire
            // 
            this.btnSpire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnSpire.DefaultScheme = true;
            this.btnSpire.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSpire.Hint = "";
            this.btnSpire.Location = new System.Drawing.Point(76, 21);
            this.btnSpire.Name = "btnSpire";
            this.btnSpire.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnSpire.Size = new System.Drawing.Size(73, 29);
            this.btnSpire.TabIndex = 10;
            this.btnSpire.Text = "�����";
            this.btnSpire.Click += new System.EventHandler(this.btnSpire_Click);
            // 
            // m_cmdLeaHosNoCheck
            // 
            this.m_cmdLeaHosNoCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdLeaHosNoCheck.DefaultScheme = true;
            this.m_cmdLeaHosNoCheck.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdLeaHosNoCheck.Hint = "";
            this.m_cmdLeaHosNoCheck.Location = new System.Drawing.Point(228, 21);
            this.m_cmdLeaHosNoCheck.Name = "m_cmdLeaHosNoCheck";
            this.m_cmdLeaHosNoCheck.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdLeaHosNoCheck.Size = new System.Drawing.Size(73, 29);
            this.m_cmdLeaHosNoCheck.TabIndex = 9;
            this.m_cmdLeaHosNoCheck.Text = "��Ժ";
            this.m_cmdLeaHosNoCheck.Visible = false;
            this.m_cmdLeaHosNoCheck.Click += new System.EventHandler(this.m_cmdLeaHosNoCheck_Click);
            // 
            // m_cmdHoliday
            // 
            this.m_cmdHoliday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdHoliday.DefaultScheme = true;
            this.m_cmdHoliday.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdHoliday.Hint = "";
            this.m_cmdHoliday.Location = new System.Drawing.Point(556, 21);
            this.m_cmdHoliday.Name = "m_cmdHoliday";
            this.m_cmdHoliday.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdHoliday.Size = new System.Drawing.Size(73, 29);
            this.m_cmdHoliday.TabIndex = 8;
            this.m_cmdHoliday.Text = "��� F7";
            this.m_cmdHoliday.Click += new System.EventHandler(this.m_cmdHoliday_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(96, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // m_txtrefresh
            // 
            this.m_txtrefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_txtrefresh.DefaultScheme = true;
            this.m_txtrefresh.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_txtrefresh.Hint = "";
            this.m_txtrefresh.Location = new System.Drawing.Point(4, 21);
            this.m_txtrefresh.Name = "m_txtrefresh";
            this.m_txtrefresh.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_txtrefresh.Size = new System.Drawing.Size(73, 29);
            this.m_txtrefresh.TabIndex = 6;
            this.m_txtrefresh.Text = "ˢ��";
            this.m_txtrefresh.Click += new System.EventHandler(this.m_txtrefresh_Click);
            // 
            // m_cmdUndoOut
            // 
            this.m_cmdUndoOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdUndoOut.DefaultScheme = true;
            this.m_cmdUndoOut.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdUndoOut.Enabled = false;
            this.m_cmdUndoOut.Hint = "";
            this.m_cmdUndoOut.Location = new System.Drawing.Point(629, 21);
            this.m_cmdUndoOut.Name = "m_cmdUndoOut";
            this.m_cmdUndoOut.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdUndoOut.Size = new System.Drawing.Size(73, 29);
            this.m_cmdUndoOut.TabIndex = 5;
            this.m_cmdUndoOut.Text = "����";
            this.m_cmdUndoOut.Click += new System.EventHandler(this.m_cmdUndoOut_Click);
            // 
            // cmdTurnIn
            // 
            this.cmdTurnIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmdTurnIn.DefaultScheme = true;
            this.cmdTurnIn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdTurnIn.Enabled = false;
            this.cmdTurnIn.Hint = "";
            this.cmdTurnIn.Location = new System.Drawing.Point(332, 21);
            this.cmdTurnIn.Name = "cmdTurnIn";
            this.cmdTurnIn.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdTurnIn.Size = new System.Drawing.Size(73, 29);
            this.cmdTurnIn.TabIndex = 4;
            this.cmdTurnIn.Text = "ת�� F4";
            this.cmdTurnIn.Click += new System.EventHandler(this.cmdTurnIn_Click);
            // 
            // cmdTurnOut
            // 
            this.cmdTurnOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmdTurnOut.DefaultScheme = true;
            this.cmdTurnOut.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdTurnOut.Enabled = false;
            this.cmdTurnOut.Hint = "";
            this.cmdTurnOut.Location = new System.Drawing.Point(405, 21);
            this.cmdTurnOut.Name = "cmdTurnOut";
            this.cmdTurnOut.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdTurnOut.Size = new System.Drawing.Size(73, 29);
            this.cmdTurnOut.TabIndex = 4;
            this.cmdTurnOut.Text = "ת�� F5";
            this.cmdTurnOut.Click += new System.EventHandler(this.cmdTurnOut_Click);
            // 
            // cmdLeaveHospital
            // 
            this.cmdLeaveHospital.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmdLeaveHospital.DefaultScheme = true;
            this.cmdLeaveHospital.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdLeaveHospital.Enabled = false;
            this.cmdLeaveHospital.Hint = "";
            this.cmdLeaveHospital.Location = new System.Drawing.Point(478, 21);
            this.cmdLeaveHospital.Name = "cmdLeaveHospital";
            this.cmdLeaveHospital.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdLeaveHospital.Size = new System.Drawing.Size(78, 29);
            this.cmdLeaveHospital.TabIndex = 4;
            this.cmdLeaveHospital.Text = "Ԥ��Ժ F6";
            this.cmdLeaveHospital.Click += new System.EventHandler(this.cmdLeaveHospital_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmdClose.DefaultScheme = true;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdClose.Hint = "";
            this.cmdClose.Location = new System.Drawing.Point(756, 21);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdClose.Size = new System.Drawing.Size(73, 29);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "�ر� Esc";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // btnPaymentNotice
            // 
            this.btnPaymentNotice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnPaymentNotice.DefaultScheme = true;
            this.btnPaymentNotice.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPaymentNotice.Hint = "";
            this.btnPaymentNotice.Location = new System.Drawing.Point(148, 21);
            this.btnPaymentNotice.Name = "btnPaymentNotice";
            this.btnPaymentNotice.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPaymentNotice.Size = new System.Drawing.Size(80, 29);
            this.btnPaymentNotice.TabIndex = 11;
            this.btnPaymentNotice.Text = "Ƿ��֪ͨ��";
            this.btnPaymentNotice.Click += new System.EventHandler(this.btnPaymentNotice_Click);
            // 
            // frmBedAdmin
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1024, 589);
            this.Controls.Add(this.m_lsvBedInfo);
            this.Controls.Add(this.collapsibleSplitter1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.m_panArear);
            this.Font = new System.Drawing.Font("����", 10.5F);
            this.KeyPreview = true;
            this.Name = "frmBedAdmin";
            this.Text = "��λ����";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBedAdmin_Load);
            this.Activated += new System.EventHandler(this.frmBedAdmin_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBedAdmin_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.m_panArear.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region ���ô��������
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_BedAdmin();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region �����ʼ��
        private void frmBedAdmin_Load(object sender, System.EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).m_mthInit();
            ((clsCtl_BedAdmin)this.objController).m_FillDepartListView();
            ((clsCtl_BedAdmin)this.objController).objsystempower = new com.digitalwave.iCare.gui.Systempower.clsSystemPower_base(((clsCtl_BedAdmin)this.objController).m_strOperatorID);

            /** ��ʾ��ʱ�� */
            this.setFreshMsg();
            /* ##### **/
        }

        private int second = 600;
        private void setFreshMsg()
        {
            this.m_txtrefresh.Text = "ˢ��(" + this.second + ")";
        }

        #endregion

        #region ���Ӵ�λ
        private void cmdAddBed_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).m_AddBed();
        }
        #endregion

        #region �༭��λ
        private void m_lsvBedInfo_ItemActivate(object sender, System.EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).m_EditBed();
        }
        #endregion

        #region ת��
        private void cmdTurnOut_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).m_TurnOut();
            //this.cmdTurnOut.Enabled = false;
        }
        #endregion

        #region ��Ժ
        private void cmdLeaveHospital_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).m_LeaveHospital();
        }
        #endregion

        #region ת��
        private void cmdTurnIn_Click(object sender, System.EventArgs e)
        {
            if (this.m_lsvBedInfo.SelectedItems.Count > 0)
            {
                ((clsCtl_BedAdmin)this.objController).m_TurnIn();
                this.cmdTurnIn.Enabled = false;
            }
        }
        #endregion

        #region �����¼�
        private void frmBedAdmin_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (MessageBox.Show("ȷ��Ҫ�˳���", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    break;
                case Keys.F1:
                    MessageBox.Show(" F9:�л���Ϣ����", "Icare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Keys.F2:
                    if (cmdAddBed.Enabled)
                    {
                        cmdAddBed_Click(sender, e);
                    }
                    break;
                case Keys.F4:
                    if (cmdTurnIn.Enabled)
                    {
                        cmdTurnIn_Click(sender, e);
                    }
                    break;
                case Keys.F5:
                    if (cmdTurnOut.Enabled)
                    {
                        cmdTurnOut_Click(sender, e);
                    }
                    break;
                case Keys.F6:
                    if (cmdClose.Enabled)
                    {
                        cmdLeaveHospital_Click(sender, e);
                    }
                    break;
                case Keys.F7:
                    ((clsCtl_BedAdmin)this.objController).m_mthHoliday();
                    break;
                case Keys.F9:
                    #region  �л���Ϣ����

                    if (m_lsvDept.ContainsFocus == true)
                    {
                        this.m_lsvBedInfo.Focus();
                    }
                    else if (m_lsvBedInfo.ContainsFocus == true)
                    {
                        this.groupBox1.Focus();
                        SendKeys.SendWait("{TAB}");
                    }
                    else if (groupBox1.ContainsFocus == true)
                    {
                        m_lsvDept.Focus();
                    }

                    break;
                    #endregion
                default:
                    break;
            }
        }
        #endregion

        #region ���Ŵ���
        private void cmdClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ListView�϶��¼�
        private void m_lsvBedInfo_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            //�ж��Ƿ�������Ҽ�����
            if (e.Button == MouseButtons.Right) return;

            if (m_lsvBedInfo.SelectedItems.Count != 1) return;
            ListViewItem lsvItem = m_lsvBedInfo.SelectedItems[0];

            //ȷ�������Ƿ������Ϸ�
            if (!IsAllowDrag(lsvItem)) return;

            //��ʼ�ϷŲ���
            m_lsvBedInfo.DoDragDrop(lsvItem, DragDropEffects.Move);
        }

        private void m_lsvBedInfo_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            if (e.AllowedEffect == DragDropEffects.Move)
            {
                e.Effect = DragDropEffects.Move;
            }
            else if (e.AllowedEffect == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void m_lsvBedInfo_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            Point clientPoint = m_lsvBedInfo.PointToClient(new Point(e.X, e.Y));
            ListViewItem lsvItem;
            lsvItem = m_lsvBedInfo.GetItemAt(clientPoint.X, clientPoint.Y);
            if (lsvItem == null) return;

            if (!e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            if (e.AllowedEffect == DragDropEffects.Copy)  //���Ŵ�λ
            {
                //this.Cursor = Cursors.WaitCursor;
                //((clsCtl_BedAdmin)this.objController).m_mthArrange(lsvItem);
                //this.Cursor = Cursors.Default;

                lsvItem.Selected = true;
                ((clsCtl_BedAdmin)this.objController).m_TurnIn();
                this.cmdTurnIn.Enabled = false;
            }
            else //����
            {
                ListViewItem lsvSourceItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
                //ȷ���Ƿ���Խ��ܷŲ���
                if (!IsAllowDrop(lsvSourceItem, lsvItem))
                {
                    return;
                }
                //ѯ��ȷ��
                clsBedManageVO souBedVO = (clsBedManageVO)lsvSourceItem.Tag;
                clsBedManageVO tarBedVO = (clsBedManageVO)lsvItem.Tag;
                if (souBedVO.m_strSTATUS_INT == "1" && tarBedVO.m_strSTATUS_INT == "2")
                {
                    ((clsCtl_BedAdmin)this.objController).m_mthOccupyBed(souBedVO.m_strBEDID_CHR, tarBedVO.m_strREGISTERID_CHR);
                }
                else if (souBedVO.m_strSTATUS_INT == "2" || souBedVO.m_strSTATUS_INT == "6")
                {
                    //add by wjqin(06-4-5) ���Ӵ�λ�Ա��жϣ�������Ů�Դ�������ʾ
                    string strAsk = "";
                    string m_psex = souBedVO.m_strSEX_CHR;
                    string m_bsex = tarBedVO.m_strSEXNAME;
                    if (m_psex == "��" && m_bsex == "Ů")
                    {
                        strAsk = "��ǰ���Բ��˽�ת��Ů�Դ���\r\n";
                    }

                    /*<=========================================================*/
                    strAsk += "ȷ��ת���˻�����";
                    if (MessageBox.Show(strAsk, "��ʾ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;

                    //���ϷŲ���
                    this.Cursor = Cursors.WaitCursor;
                    ((clsCtl_BedAdmin)this.objController).m_cmdTransfer(lsvSourceItem, lsvItem);
                    this.Cursor = Cursors.Default;
                }
            }
        }
        /// <summary>
        /// ȷ�������Ƿ�������ϲ���
        /// </summary>
        /// <param name="lsvTemItem">��</param>
        /// <returns></returns>
        private bool IsAllowDrag(ListViewItem lsvTemItem)
        {
            clsBedManageVO m_objBedVO = (clsBedManageVO)lsvTemItem.Tag;
            if (m_objBedVO.m_strSTATUS_INT == "1" || m_objBedVO.m_strSTATUS_INT == "2" || m_objBedVO.m_strSTATUS_INT == "5")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// ȷ�������Ƿ�������Ų���
        /// </summary>
        /// <param name="lsvTemItem">��</param>
        /// <returns></returns>
        private bool IsAllowDrop(ListViewItem SourceItem, ListViewItem lsvTemItem)
        {
            clsBedManageVO souBedVO = (clsBedManageVO)SourceItem.Tag;
            clsBedManageVO tarBedVO = (clsBedManageVO)lsvTemItem.Tag;
            //if (souBedVO.m_strSTATUS_INT == "2" && tarBedVO.m_strSTATUS_INT == "1")
            //{
            //    //				MessageBox.Show("ֻ��ת�����մ���","��ʾ��",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //    return true;
            //}

            ////��Ŀ�괲λ��Ԥ��Ժʱ��Ҳ����
            //if (souBedVO.m_strSTATUS_INT == "2" && tarBedVO.m_strSTATUS_INT == "5")
            //{
            //    return true;
            //}

            //if (souBedVO.m_strSTATUS_INT == "1" && tarBedVO.m_strSTATUS_INT == "2")
            //{
            //    return true;
            //}

            if (souBedVO.m_strSTATUS_INT == "2" || souBedVO.m_strSTATUS_INT == "6")
            {
                if (tarBedVO.m_strSTATUS_INT == "1" || tarBedVO.m_strSTATUS_INT == "6")
                    return true;
            }
            else if (souBedVO.m_strSTATUS_INT == "1")
            {
                if (tarBedVO.m_strSTATUS_INT == "2")
                    return true;
            }
            
            return false;
        }
        #endregion

        #region ���ô�λ����Ȩ��
        private void m_lsvBedInfo_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).m_mthBedControl();
        }
        #endregion

        #region ������Ժ
        private void m_cmdUndoOut_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).m_lngUndoOutHospital();
        }
        #endregion

        #region ����ת��
        private void menuItem9_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).UndoTransferOut();
        }

        private void TransferMenu_Popup(object sender, System.EventArgs e)
        {
            if (this.m_lsvTurnOutNA.SelectedItems.Count > 0)
            {
                this.TransferMenu.MenuItems[0].Enabled = true;
                this.TransferMenu.MenuItems[1].Enabled = true;
            }
            else
            {
                this.TransferMenu.MenuItems[0].Enabled = false;
                this.TransferMenu.MenuItems[1].Enabled = false;
            }
        }
        #endregion

        #region ��ʱˢ��
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            this.second -= 1;
            this.setFreshMsg();
            if (this.second == 0)
            {
                this.m_txtrefresh_Click(sender, e);
            }
        }

        /// <summary>
        /// ˢ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_txtrefresh_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).m_mthGetBidInfoByArearID();
            ((clsCtl_BedAdmin)this.objController).loadAreaTransferInfo();
            this.second = 600;
        }

        private void m_lsvDept_Click(object sender, EventArgs e)
        {
            if (m_lsvDept.SelectedItems.Count > 0)
            {
                ((clsCtl_BedAdmin)this.objController).m_mthDeptSelectedIndexChanged();
                this.second = 600;
            }
        }
        #endregion

        #region ListView����

        private int iColumn_0 = 0;
        private bool iOrder_0 = false;
        private int iColumn_1 = 0;
        private bool iOrder_1 = false;
        private int iColumn_2 = 0;
        private bool iOrder_2 = false;
        private int iColumn_3 = 0;
        private bool iOrder_3 = false;
        private void m_lsvTurnInNA_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            if (iColumn_0 == e.Column)
            {
                iOrder_0 = !iOrder_0;
            }
            else
            {
                iOrder_0 = true;
            }
            m_lsvTurnInNA.Sorting = iOrder_0 ? SortOrder.Ascending : SortOrder.Descending;
            m_lsvTurnInNA.Sort();
            m_lsvTurnInNA.ListViewItemSorter = new ListViewItemComparer(e.Column, m_lsvTurnInNA.Sorting);
            iColumn_0 = e.Column;
        }

        private void m_lsvTurnOutA_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            if (iColumn_1 == e.Column)
            {
                iOrder_1 = !iOrder_1;
            }
            else
            {
                iOrder_1 = true;
            }
            m_lsvTurnOutA.Sorting = iOrder_1 ? SortOrder.Ascending : SortOrder.Descending;
            m_lsvTurnOutA.Sort();
            m_lsvTurnOutA.ListViewItemSorter = new ListViewItemComparer(e.Column, m_lsvTurnOutA.Sorting);
            iColumn_1 = e.Column;
        }

        private void m_lsvTurnOutNA_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            if (iColumn_2 == e.Column)
            {
                iOrder_2 = !iOrder_2;
            }
            else
            {
                iOrder_2 = true;
            }
            m_lsvTurnOutNA.Sorting = iOrder_0 ? SortOrder.Ascending : SortOrder.Descending;
            m_lsvTurnOutNA.Sort();
            m_lsvTurnOutNA.ListViewItemSorter = new ListViewItemComparer(e.Column, m_lsvTurnOutNA.Sorting);
            iColumn_2 = e.Column;
        }

        private void m_lsvTurnInA_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            if (iColumn_3 == e.Column)
            {
                iOrder_3 = !iOrder_3;
            }
            else
            {
                iOrder_3 = true;
            }
            m_lsvTurnInA.Sorting = iOrder_0 ? SortOrder.Ascending : SortOrder.Descending;
            m_lsvTurnInA.Sort();
            m_lsvTurnInA.ListViewItemSorter = new ListViewItemComparer(e.Column, m_lsvTurnInA.Sorting);
            iColumn_3 = e.Column;
        }
        #endregion

        #region �����ʱˢ������
        int intFlag = 0;
        private void frmBedAdmin_Activated(object sender, System.EventArgs e)
        {
            if (intFlag == 1)
            {
                m_txtrefresh_Click(sender, e);
            }
            intFlag = 1;
        }
        #endregion

        #region ����ݼ�����סԺ�Ǽ�
        /// <summary>
        /// ����ݼ�����סԺ�Ǽ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_lsvBedInfo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:
                    ((clsCtl_BedAdmin)this.objController).m_mthRegidit();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region ���Ų��˴�λ
        private void m_lsvTurnInNA_DoubleClick(object sender, System.EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).m_TurnIn();
        }
        #endregion

        #region	��ݼ��˵�

        #region �Ҽ��˵�����
        private void BedAdmin_Popup(object sender, System.EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).m_mthSetComtext();
        }
        #endregion

        #region �༭��λ��Ϣ
        private void menuItem10_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).m_mthEditBedInfo();
        }
        #endregion

        #region	ҽ��¼��
        private void menuItem18_Click(object sender, System.EventArgs e)
        {
            if (this.m_lsvBedInfo.SelectedItems.Count > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    clsBedManageVO m_objBedVO = (clsBedManageVO)m_lsvBedInfo.SelectedItems[0].Tag;
                    if (((clsCtl_BedAdmin)this.objController).m_intParm1068 != 0)
                    {
                        ////////¼ҽ��ǰ�жϲ����������Ƿ���δ�����õĴ�����������ʾ
                        string strMessage = "";
                        com.digitalwave.iCare.gui.HIS.clsPublic.m_lngSelectPatientNoPayRecipe(m_objBedVO.m_strREGISTERID_CHR, out strMessage);
                        if (!string.IsNullOrEmpty(strMessage))
                        {
                            if (MessageBox.Show("�Ƿ�����¼��ҽ��" + strMessage, "�����������δ��!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                            {
                                return;
                            }
                        }
                        ///////////
                    }
                    int m_intSrc = 1;//0-��ͨ�����1����Դ�ڴ�λ����
                    com.digitalwave.iCare.BIHOrder.frmBIHOrderInput frm = new com.digitalwave.iCare.BIHOrder.frmBIHOrderInput(m_intSrc);
                    /*<==========================*/
                    frm.LoginInfo = this.LoginInfo;
                    frm.m_mthSetCurrentDoctor(this.LoginInfo.m_strEmpID, this.LoginInfo.m_strEmpName);
                    frm.Show_MDI_Child((System.Windows.Forms.Form)this.ParentForm);
                    frm.m_mthSetCurrentPatient(m_objBedVO.m_strINPATIENTID_CHR);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.Cursor = Cursors.Default;��
                }
            }
        }
        #endregion

        #region	ҽ����ѯ
        private void menuItem22_Click(object sender, System.EventArgs e)
        {
            if (this.m_lsvBedInfo.SelectedItems.Count > 0 && this.m_lsvBedInfo.SelectedItems[0].SubItems.Count > 6)
            {
                com.digitalwave.iCare.BIHOrder.frmSearchOrderInfo frm = new com.digitalwave.iCare.BIHOrder.frmSearchOrderInfo();
                frm.LoginInfo = this.LoginInfo;
                frm.Show_MDI_Child((System.Windows.Forms.Form)this.ParentForm);
                frm.AutoActicate(((clsBedManageVO)m_lsvBedInfo.SelectedItems[0].Tag).m_strINPATIENTID_CHR);
            }
        }
        #endregion

        #region	ҽ��ִ�е�ǰ����
        private void menuItem20_Click(object sender, System.EventArgs e)
        {
            char[] split = { '\n' };
            string[] BedCode = this.m_lsvBedInfo.SelectedItems[0].SubItems[0].Text.ToString().Trim().Split(split, 2);
            if (this.m_lsvBedInfo.SelectedItems.Count > 0 && this.m_lsvBedInfo.SelectedItems[0].SubItems.Count > 6)
            {
                com.digitalwave.iCare.BIHOrder.frmBIHOrderExecute frm = new com.digitalwave.iCare.BIHOrder.frmBIHOrderExecute();
                frm.LoginInfo = this.LoginInfo;
                frm.Show_MDI_Child((System.Windows.Forms.Form)this.ParentForm);
                frm.SetQueryCondition(this.m_lblPatientArea.Text, ((clsCtl_BedAdmin)this.objController).m_strAreaID, ((clsBedManageVO)m_lsvBedInfo.SelectedItems[0].Tag).m_strBEDID_CHR, this.LoginInfo.m_strEmpID);

                //com.digitalwave.iCare.BIHOrder.frmOrderExecute frm = new com.digitalwave.iCare.BIHOrder.frmOrderExecute(((clsCtl_BedAdmin)this.objController).m_strAreaID,((clsCtl_BedAdmin)this.objController).m_strAreaID, );
                //frm.LoginInfo = this.LoginInfo;
                //frm.Show_MDI_Child((System.Windows.Forms.Form)this.ParentForm);
                //frm.SetQueryCondition(this.m_lblPatientArea.Text, ((clsCtl_BedAdmin)this.objController).m_strAreaID, ((clsBedManageVO)m_lsvBedInfo.SelectedItems[0].Tag).m_strBEDID_CHR, this.LoginInfo.m_strEmpID);
            }
        }
        #endregion

        #region	ҽ��ִ�е�ǰ����
        private void menuItem21_Click(object sender, System.EventArgs e)
        {
            com.digitalwave.iCare.BIHOrder.frmBIHOrderExecute frm = new com.digitalwave.iCare.BIHOrder.frmBIHOrderExecute();
            frm.LoginInfo = this.LoginInfo;
            frm.Show_MDI_Child((System.Windows.Forms.Form)this.ParentForm);
            frm.SetQueryCondition(this.m_lblPatientArea.Text, ((clsCtl_BedAdmin)this.objController).m_strAreaID, this.LoginInfo.m_strEmpID);
        }
        #endregion

        #region	���ù���
        private void menuItem12_Click(object sender, System.EventArgs e)
        {
            if (this.m_lsvBedInfo.SelectedItems.Count > 0 && this.m_lsvBedInfo.SelectedItems[0].SubItems.Count > 6)
            {
                com.digitalwave.iCare.gui.HIS.frmReserve frm = new com.digitalwave.iCare.gui.HIS.frmReserve();
                frm.SetRegisterid(((clsBedManageVO)m_lsvBedInfo.SelectedItems[0].Tag).m_strREGISTERID_CHR);
                frm.LoginInfo = this.LoginInfo;
                frm.Show_MDI_Child((System.Windows.Forms.Form)this.ParentForm);
            }
        }
        #endregion

        #region	ҽ������ӡ
        private void menuItem19_Click(object sender, System.EventArgs e)
        {
            frmPrintOrder objPrintOrder = new frmPrintOrder(((clsBedManageVO)m_lsvBedInfo.SelectedItems[0].Tag).m_strREGISTERID_CHR);
            objPrintOrder.ShowDialog();
        }
        #endregion

        #region ��Ժ
        private void menuItem25_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).m_LeaveHospital();
        }
        #endregion

        #region	ת��
        private void menuItem24_Click(object sender, System.EventArgs e)
        {
            cmdTurnOut_Click(sender, e);
        }
        #endregion

        #region ת��
        private void menuItem23_Click(object sender, System.EventArgs e)
        {
            cmdTurnIn_Click(sender, e);
        }

        #endregion

        #region ���Ӵ�λ
        private void menuItem16_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).m_AddBed();
        }
        #endregion

        #region	��������
        private void menuItem17_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).m_mthDelOccupBed();
        }
        #endregion

        #region	ɾ����λ
        private void menuItem26_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).m_mthDeleteBedInfoByByBedID();
        }
        #endregion

        #region ��λ��Ϣ����
        private void m_lsvBedInfo_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            if (iColumn_0 == e.Column)
            {
                iOrder_0 = !iOrder_0;
            }
            else
            {
                iOrder_0 = true;
            }
            m_lsvBedInfo.Sorting = iOrder_0 ? SortOrder.Ascending : SortOrder.Descending;
            m_lsvBedInfo.Sort();
            m_lsvBedInfo.ListViewItemSorter = new ListViewItemComparer(e.Column, m_lsvBedInfo.Sorting);
            iColumn_0 = e.Column;
        }
        #endregion

        #region ˢ������
        private void menuItem27_Click(object sender, System.EventArgs e)
        {
            m_txtrefresh_Click(sender, e);
        }
        #endregion

        #region �ֹ�����
        private void menuItem14_Click(object sender, System.EventArgs e)
        {
            if (this.m_lsvBedInfo.SelectedItems.Count > 0 && this.m_lsvBedInfo.SelectedItems[0].SubItems.Count > 6)
            {
                com.digitalwave.iCare.gui.HIS.frmPatchCharge frm = new com.digitalwave.iCare.gui.HIS.frmPatchCharge(((clsBedManageVO)m_lsvBedInfo.SelectedItems[0].Tag).m_strINPATIENTID_CHR);
                frm.LoginInfo = this.LoginInfo;
                frm.Show_MDI_Child((System.Windows.Forms.Form)this.ParentForm);
               // frm.m_mthGetPateintInfoByRegID(((clsBedManageVO)m_lsvBedInfo.SelectedItems[0].Tag).m_strREGISTERID_CHR);
            }
        }
        #endregion

        #endregion

        #region ���벡��ת��ת����Ϣ
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ((clsCtl_BedAdmin)this.objController).loadAreaTransferInfo();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region �ı䴲λ��Ϣ��ͼ
        private void m_cmbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_cmbView.SelectedIndex == 1)
            {
                m_lsvBedInfo.View = View.Details;
            }
            else
            {
                m_lsvBedInfo.View = View.LargeIcon;
            }
        }
        #endregion

        #region ���Ŵ�λ�϶��¼�
        private void m_lsvTurnInNA_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ListViewItem listItem = m_lsvTurnInNA.SelectedItems[0];
            m_lsvTurnInNA.DoDragDrop(listItem, DragDropEffects.Copy);
        }

        private void m_lsvTurnInNA_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        #endregion

        #region ��ӡת��֪ͨ��
        private void menuItem15_Click(object sender, EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).m_mthPrintTurnOutNotice();
        }
        #endregion

        #region ���
        private void m_cmdHoliday_Click(object sender, EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).m_mthHoliday();
        }

        private void menuItem28_Click(object sender, EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).m_mthHoliday();
        }
        #endregion

        #region �������
        private void menuItem29_Click(object sender, EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).m_lngUndoOutHospital();
        }
        #endregion

        #region ������
        /// <summary>
        /// ������
        /// </summary>
        class ListViewItemComparer : IComparer
        {
            private int col;
            private SortOrder _order;

            public ListViewItemComparer()
            {
                col = 0;
                this._order = SortOrder.Ascending;
            }
            public ListViewItemComparer(int column, SortOrder order)
            {
                col = column;
                this._order = order;
            }
            public int Compare(object x, object y)
            {
                int returnVal = -1;
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                if (_order == SortOrder.Descending)
                {
                    returnVal *= -1;
                }
                return returnVal;
            }
        }
        #endregion

        #region ��ӡ��Ժ֪ͨ�� He Guiqiu 20060713
        private void menuItem30_Click(object sender, EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).PrintLeaveNotice();
        }
        #endregion

        #region ����Ԥ��Ժ/���
        private void menuItemCancelLeave_Click(object sender, EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).m_lngUndoOutHospital();
        }
        #endregion

        #region ��ȡ��ǰѡ�в�����λ��Ϣ
        private void m_lsvDept_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                ((clsCtl_BedAdmin)this.objController).m_mthDeptSelectedIndexChanged();
            }
        }
        #endregion

        private void m_cmdLeaHosNoCheck_Click(object sender, EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).LeaveHospitalNoCheck() ;
        }

        private void menuItemTransBed_Click(object sender, EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).TurnBed();
        }

        private void btnSpire_Click(object sender, EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).SpireLamella();
        }

        private void btnPaymentNotice_Click(object sender, EventArgs e)
        {
            ((clsCtl_BedAdmin)this.objController).PaymentNotice();
        }
    }
}
