using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 出院——界面表示层
    /// 作者： 徐斌辉
    /// 创建时间： 2004-09-09
    /// </summary>
    public class frmBIHLeave : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        /// <summary>
        /// 入院登记流水号
        /// </summary>
        internal string m_strRegisterID = "";
        /// <summary>
        /// 出院科室id
        /// </summary>
        internal string m_strOutDeptID = "";
        /// <summary>
        /// 出院病区id
        /// </summary>
        internal string m_strOutAreaID = "";
        /// <summary>
        /// 出院病床id
        /// </summary>
        internal string m_strOutBedID = "";

        internal clsBedManageVO m_bedManageVO;

        //出院方式
        internal string m_strPstatus = "";

        #region 控件申明
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label m_lblPatientName;
        internal System.Windows.Forms.Label m_lblDEPTID_CHR;
        internal System.Windows.Forms.Label m_lblAREAID_CHR;
        internal System.Windows.Forms.Label m_lblBEDID_CHR;
        internal System.Windows.Forms.TextBox m_txtDES;
        internal System.Windows.Forms.ComboBox m_cbmTYPE;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private PinkieControls.ButtonXP cmdLeave;
        private PinkieControls.ButtonXP cmdCancel;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ComboBox m_cbmPSTATUS_INT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        
        internal System.Windows.Forms.Label m_lblINPATIENT_DAT;
        internal System.Windows.Forms.Label m_lblBIHDays;
        private System.Windows.Forms.Label label6;
        private Label label12;
        private Label label9;
        internal TextBox m_tbInsDiagnose;
        internal TextBox m_tbDiagnose;
        internal CheckBox m_ckbPrint;
        internal NullableDateControls.MaskDateEdit m_dtpOutDate;
        internal CheckBox m_ckbDiseasType;
        internal LinkLabel m_lbDiagnoses;
        private System.Windows.Forms.GroupBox groupBox1;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_strRegisterID">入院登记流水号(200409010001)</param>
        /// <param name="p_strOutDeptID">出院时科室</param>
        /// <param name="p_strOutAreaID">出院时病区</param>
        /// <param name="p_strOutBedID">出院时病床</param>
        public frmBIHLeave(string p_strRegisterID, string p_strOutDeptID, string p_strOutAreaID, string p_strOutBedID)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            m_strRegisterID = p_strRegisterID;
            m_strOutDeptID = p_strOutDeptID;
            m_strOutAreaID = p_strOutAreaID;
            m_strOutBedID = p_strOutBedID;
        }

        public frmBIHLeave(clsBedManageVO p_bedManageVO, string p_strOutDeptID, string p_strOutAreaID, string p_strOutBedID)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            this.m_bedManageVO = p_bedManageVO;

            m_strRegisterID = this.m_bedManageVO.m_strREGISTERID_CHR;
            m_strOutDeptID = p_strOutDeptID;
            m_strOutAreaID = p_strOutAreaID;
            m_strOutBedID = p_strOutBedID;
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
        #endregion

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtDES = new System.Windows.Forms.TextBox();
            this.m_lblPatientName = new System.Windows.Forms.Label();
            this.m_lblDEPTID_CHR = new System.Windows.Forms.Label();
            this.m_lblAREAID_CHR = new System.Windows.Forms.Label();
            this.m_lblBEDID_CHR = new System.Windows.Forms.Label();
            this.m_cbmTYPE = new System.Windows.Forms.ComboBox();
            this.cmdLeave = new PinkieControls.ButtonXP();
            this.cmdCancel = new PinkieControls.ButtonXP();
            this.label7 = new System.Windows.Forms.Label();
            this.m_cbmPSTATUS_INT = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_lblINPATIENT_DAT = new System.Windows.Forms.Label();
            this.m_lblBIHDays = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_ckbDiseasType = new System.Windows.Forms.CheckBox();
            this.m_dtpOutDate = new NullableDateControls.MaskDateEdit();
            this.m_tbInsDiagnose = new System.Windows.Forms.TextBox();
            this.m_tbDiagnose = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_lbDiagnoses = new System.Windows.Forms.LinkLabel();
            this.m_ckbPrint = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(57, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓　　名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(16, 428);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "出院科室:";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(326, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "出院病床:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(57, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "出院病区:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(326, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "出院类型:";
            // 
            // m_txtDES
            // 
            this.m_txtDES.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDES.Location = new System.Drawing.Point(129, 330);
            this.m_txtDES.Multiline = true;
            this.m_txtDES.Name = "m_txtDES";
            this.m_txtDES.Size = new System.Drawing.Size(441, 104);
            this.m_txtDES.TabIndex = 5;
            // 
            // m_lblPatientName
            // 
            this.m_lblPatientName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblPatientName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblPatientName.Location = new System.Drawing.Point(129, 24);
            this.m_lblPatientName.Name = "m_lblPatientName";
            this.m_lblPatientName.Size = new System.Drawing.Size(172, 21);
            this.m_lblPatientName.TabIndex = 0;
            this.m_lblPatientName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblDEPTID_CHR
            // 
            this.m_lblDEPTID_CHR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblDEPTID_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblDEPTID_CHR.Location = new System.Drawing.Point(88, 426);
            this.m_lblDEPTID_CHR.Name = "m_lblDEPTID_CHR";
            this.m_lblDEPTID_CHR.Size = new System.Drawing.Size(130, 21);
            this.m_lblDEPTID_CHR.TabIndex = 6;
            this.m_lblDEPTID_CHR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblDEPTID_CHR.Visible = false;
            // 
            // m_lblAREAID_CHR
            // 
            this.m_lblAREAID_CHR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblAREAID_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblAREAID_CHR.Location = new System.Drawing.Point(129, 145);
            this.m_lblAREAID_CHR.Name = "m_lblAREAID_CHR";
            this.m_lblAREAID_CHR.Size = new System.Drawing.Size(172, 21);
            this.m_lblAREAID_CHR.TabIndex = 7;
            this.m_lblAREAID_CHR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblBEDID_CHR
            // 
            this.m_lblBEDID_CHR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblBEDID_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblBEDID_CHR.Location = new System.Drawing.Point(398, 145);
            this.m_lblBEDID_CHR.Name = "m_lblBEDID_CHR";
            this.m_lblBEDID_CHR.Size = new System.Drawing.Size(172, 21);
            this.m_lblBEDID_CHR.TabIndex = 2;
            this.m_lblBEDID_CHR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cbmTYPE
            // 
            this.m_cbmTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbmTYPE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cbmTYPE.Items.AddRange(new object[] {
            "",
            "治愈出院",
            "转院",
            "其它",
            "死亡",
            "病情好转",
            "24小时死亡"});
            this.m_cbmTYPE.Location = new System.Drawing.Point(398, 105);
            this.m_cbmTYPE.Name = "m_cbmTYPE";
            this.m_cbmTYPE.Size = new System.Drawing.Size(172, 22);
            this.m_cbmTYPE.TabIndex = 2;
            // 
            // cmdLeave
            // 
            this.cmdLeave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmdLeave.DefaultScheme = true;
            this.cmdLeave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdLeave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdLeave.Hint = "";
            this.cmdLeave.Location = new System.Drawing.Point(360, 466);
            this.cmdLeave.Name = "cmdLeave";
            this.cmdLeave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdLeave.Size = new System.Drawing.Size(96, 32);
            this.cmdLeave.TabIndex = 7;
            this.cmdLeave.Text = "出院(F2)";
            this.cmdLeave.Click += new System.EventHandler(this.cmdLeave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmdCancel.DefaultScheme = true;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdCancel.Hint = "";
            this.cmdCancel.Location = new System.Drawing.Point(482, 466);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdCancel.Size = new System.Drawing.Size(96, 32);
            this.cmdCancel.TabIndex = 8;
            this.cmdCancel.Text = "关闭(Esc)";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(57, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 14);
            this.label7.TabIndex = 8;
            this.label7.Text = "出院方式:";
            // 
            // m_cbmPSTATUS_INT
            // 
            this.m_cbmPSTATUS_INT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbmPSTATUS_INT.Enabled = false;
            this.m_cbmPSTATUS_INT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cbmPSTATUS_INT.Items.AddRange(new object[] {
            "",
            "预出院",
            "实际出院"});
            this.m_cbmPSTATUS_INT.Location = new System.Drawing.Point(129, 101);
            this.m_cbmPSTATUS_INT.Name = "m_cbmPSTATUS_INT";
            this.m_cbmPSTATUS_INT.Size = new System.Drawing.Size(172, 22);
            this.m_cbmPSTATUS_INT.TabIndex = 1;
            this.m_cbmPSTATUS_INT.SelectedIndexChanged += new System.EventHandler(this.m_cbmPSTATUS_INT_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(57, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 6;
            this.label8.Text = "入院日期:";
            // 
            // m_lblINPATIENT_DAT
            // 
            this.m_lblINPATIENT_DAT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblINPATIENT_DAT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblINPATIENT_DAT.Location = new System.Drawing.Point(129, 64);
            this.m_lblINPATIENT_DAT.Name = "m_lblINPATIENT_DAT";
            this.m_lblINPATIENT_DAT.Size = new System.Drawing.Size(172, 21);
            this.m_lblINPATIENT_DAT.TabIndex = 3;
            this.m_lblINPATIENT_DAT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblBIHDays
            // 
            this.m_lblBIHDays.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblBIHDays.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblBIHDays.Location = new System.Drawing.Point(398, 25);
            this.m_lblBIHDays.Name = "m_lblBIHDays";
            this.m_lblBIHDays.Size = new System.Drawing.Size(172, 21);
            this.m_lblBIHDays.TabIndex = 1;
            this.m_lblBIHDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(326, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 14);
            this.label11.TabIndex = 6;
            this.label11.Text = "住院天数:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(53, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "备　　注:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_ckbDiseasType);
            this.groupBox1.Controls.Add(this.m_dtpOutDate);
            this.groupBox1.Controls.Add(this.m_tbInsDiagnose);
            this.groupBox1.Controls.Add(this.m_tbDiagnose);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.m_lblAREAID_CHR);
            this.groupBox1.Controls.Add(this.m_cbmTYPE);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.m_lblINPATIENT_DAT);
            this.groupBox1.Controls.Add(this.m_lblBIHDays);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.m_lblPatientName);
            this.groupBox1.Controls.Add(this.m_lblDEPTID_CHR);
            this.groupBox1.Controls.Add(this.m_lblBEDID_CHR);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.m_cbmPSTATUS_INT);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.m_txtDES);
            this.groupBox1.Controls.Add(this.m_lbDiagnoses);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 455);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // m_ckbDiseasType
            // 
            this.m_ckbDiseasType.AutoSize = true;
            this.m_ckbDiseasType.Location = new System.Drawing.Point(129, 300);
            this.m_ckbDiseasType.Name = "m_ckbDiseasType";
            this.m_ckbDiseasType.Size = new System.Drawing.Size(82, 18);
            this.m_ckbDiseasType.TabIndex = 4;
            this.m_ckbDiseasType.Text = "特殊病种";
            this.m_ckbDiseasType.UseVisualStyleBackColor = true;
            // 
            // m_dtpOutDate
            // 
            this.m_dtpOutDate.Location = new System.Drawing.Point(398, 62);
            this.m_dtpOutDate.Mask = "yyyy年MM月dd日HH时mm分";
            this.m_dtpOutDate.Name = "m_dtpOutDate";
            this.m_dtpOutDate.Size = new System.Drawing.Size(172, 23);
            this.m_dtpOutDate.TabIndex = 0;
            // 
            // m_tbInsDiagnose
            // 
            this.m_tbInsDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_tbInsDiagnose.Location = new System.Drawing.Point(88, 260);
            this.m_tbInsDiagnose.Multiline = true;
            this.m_tbInsDiagnose.Name = "m_tbInsDiagnose";
            this.m_tbInsDiagnose.Size = new System.Drawing.Size(15, 52);
            this.m_tbInsDiagnose.TabIndex = 114;
            this.m_tbInsDiagnose.Visible = false;
            // 
            // m_tbDiagnose
            // 
            this.m_tbDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_tbDiagnose.Location = new System.Drawing.Point(127, 195);
            this.m_tbDiagnose.Multiline = true;
            this.m_tbDiagnose.Name = "m_tbDiagnose";
            this.m_tbDiagnose.ReadOnly = true;
            this.m_tbDiagnose.Size = new System.Drawing.Size(443, 96);
            this.m_tbDiagnose.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(6, 298);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 14);
            this.label12.TabIndex = 18;
            this.label12.Text = "医保出院诊断:";
            this.label12.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(326, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 16;
            this.label9.Text = "出院日期:";
            // 
            // m_lbDiagnoses
            // 
            this.m_lbDiagnoses.AutoSize = true;
            this.m_lbDiagnoses.Location = new System.Drawing.Point(62, 196);
            this.m_lbDiagnoses.Name = "m_lbDiagnoses";
            this.m_lbDiagnoses.Size = new System.Drawing.Size(77, 14);
            this.m_lbDiagnoses.TabIndex = 115;
            this.m_lbDiagnoses.TabStop = true;
            this.m_lbDiagnoses.Text = "出院诊断：";
            this.m_lbDiagnoses.Click += new System.EventHandler(this.m_lbDiagnoses_Click);
            // 
            // m_ckbPrint
            // 
            this.m_ckbPrint.AutoSize = true;
            this.m_ckbPrint.Checked = true;
            this.m_ckbPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_ckbPrint.Location = new System.Drawing.Point(12, 466);
            this.m_ckbPrint.Name = "m_ckbPrint";
            this.m_ckbPrint.Size = new System.Drawing.Size(123, 20);
            this.m_ckbPrint.TabIndex = 6;
            this.m_ckbPrint.Text = "打印出院通知";
            this.m_ckbPrint.UseVisualStyleBackColor = true;
            // 
            // frmBIHLeave
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.ClientSize = new System.Drawing.Size(615, 506);
            this.Controls.Add(this.m_ckbPrint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdLeave);
            this.Controls.Add(this.cmdCancel);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmBIHLeave";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "出院";
            this.Load += new System.EventHandler(this.frmBIHLeave_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBIHLeave_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_BIHLeave();
            objController.Set_GUI_Apperance(this);
        }

        #region 事件
        private void cmdCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void cmdLeave_Click(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //((clsCtl_BIHLeave)this.objController).m_LeaveHospital();
            //((clsCtl_BIHLeave)this.objController).PreLeaveHospital();

            switch (this.m_cbmPSTATUS_INT.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    //"预出院";
                    ((clsCtl_BIHLeave)this.objController).PreLeaveHospital();
                    break;
                case 2:
                    //"实际出院";
                    ((clsCtl_BIHLeave)this.objController).LeaveHospital();
                    break;
            }

            this.Cursor = Cursors.Default;
        }
        private void frmBIHLeave_Load(object sender, System.EventArgs e)
        {
            ((clsCtl_BIHLeave)this.objController).LoadBIHInfo();
            m_mthSetEnter2Tab(new System.Windows.Forms.Control[] { m_lblPatientName });
        }

        private void frmBIHLeave_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            m_mthSetKeyTab(e);
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (MessageBox.Show("是否确定退出", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    break;
                case Keys.F2:
                    cmdLeave_Click(sender, e);
                    break;
            }
        }

        //改变出院时间时
        private void m_dtpOutDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime outDate;
            outDate = Convert.ToDateTime(this.m_dtpOutDate.Text);
            //住院天数
            try
            {
                System.TimeSpan diff1 = outDate.Subtract(Convert.ToDateTime(m_lblINPATIENT_DAT.Text));
                this.m_lblBIHDays.Text = diff1.Days.ToString();
            }
            catch
            { }
        }
        #endregion

        private void m_cbmPSTATUS_INT_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (this.m_cbmPSTATUS_INT.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    this.cmdLeave.Text = "预出院";
                    break;
                case 2:
                    this.cmdLeave.Text = "实际出院";
                    break;
                case 3:
                    this.cmdLeave.Text = "请假";
                    break;
                default:
                    break;
            }
        }

        private void m_lbDiagnoses_Click(object sender, EventArgs e)
        {
            ((clsCtl_BIHLeave)this.objController).EditDiagnoses();
        }
    }
}
