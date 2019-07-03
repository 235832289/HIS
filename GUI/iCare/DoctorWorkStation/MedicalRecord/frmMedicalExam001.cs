using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility;
using com.digitalwave.Utility.Controls ;
using iCare;
using iCareData;


namespace iCare
{
	public class frmMedicalExam001 : iCare.frmHRPBaseForm
	{
		#region Define
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox m_grbGeranal;
		private System.Windows.Forms.Label label25;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTuoShui;
		private System.Windows.Forms.Label label24;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboHuXi;
		private System.Windows.Forms.Label label23;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboBingQing;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Label label20;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTiWei;
		private System.Windows.Forms.Label label19;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboMianRong;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label10;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPeiHeJianCha;
		private System.Windows.Forms.Label label9;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboBuTai;
		private System.Windows.Forms.Label label8;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboBiaoQing;
		private System.Windows.Forms.Label label7;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboShenZhi;
		private System.Windows.Forms.Label label6;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboYingYang;
		private System.Windows.Forms.Label label5;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboFaYu;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox m_txtTemperature;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.GroupBox m_grbJingBu;
		private System.Windows.Forms.Label label94;
		private System.Windows.Forms.Label label93;
		private System.Windows.Forms.TextBox m_txtJiaZhuangXian;
		private System.Windows.Forms.Label label92;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cborJingBuJiaZhuangXian;
		private System.Windows.Forms.Label label91;
		private System.Windows.Forms.TextBox m_txtJingBuHuiLiuZheng;
		private System.Windows.Forms.Label label90;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboJingBuQiGuan;
		private System.Windows.Forms.Label label89;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboJingBuJingJingMai;
		private System.Windows.Forms.Label label88;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboJingBuJingDongLi;
		private System.Windows.Forms.Label label87;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboJIngBuDiKangLi;
		private System.Windows.Forms.Label label86;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboJingBuJingBu;
		private System.Windows.Forms.GroupBox m_grbFuBu;
		private System.Windows.Forms.TextBox m_txtFuBuQiTa;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboFuBuJi;
		private System.Windows.Forms.Label label113;
		private System.Windows.Forms.Label label112;
		private System.Windows.Forms.Label label111;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboFuBuChangRuDongYin;
		private System.Windows.Forms.Label label110;
		private System.Windows.Forms.TextBox m_txtFuBuBaoKuai;
		private System.Windows.Forms.Label label109;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboFuBuBianYuan;
		private System.Windows.Forms.Label label108;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboFuBuYingDu;
		private System.Windows.Forms.Label label107;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboFuBuPiZang;
		private System.Windows.Forms.Label label106;
		private System.Windows.Forms.TextBox m_txtFuBuDanNang;
		private System.Windows.Forms.Label label105;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboFuBuDanNang;
		private System.Windows.Forms.Label label103;
		private System.Windows.Forms.Label label104;
		private System.Windows.Forms.TextBox m_txtFuBuGangZhang;
		private System.Windows.Forms.Label label102;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboFuBuGangZang;
		private System.Windows.Forms.Label label101;
		private System.Windows.Forms.Label label100;
		private System.Windows.Forms.TextBox m_txtFuBuFuBi;
		private System.Windows.Forms.Label label99;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboFuBuFuBi;
		private System.Windows.Forms.Label label98;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboFuBuFuBu;
		private System.Windows.Forms.GroupBox m_grbWaiShengJiQi;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboHuiYinBu;
		private System.Windows.Forms.Label label120;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboYinNang;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboWaiYinBu;
		private System.Windows.Forms.Label label119;
		private System.Windows.Forms.Label label118;
		private System.Windows.Forms.Label label117;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboGouWan;
		private System.Windows.Forms.Label label116;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboWaiShengJiQi;
		private System.Windows.Forms.GroupBox m_grbLinBaXian;
		private System.Windows.Forms.Label label46;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboLinBaXingZhuang;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.TextBox m_txtLinBaDaXiao;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboLinBaDaXiao;
		private System.Windows.Forms.Label label43;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboLinBaFuGuGou;
		private System.Windows.Forms.Label label42;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboLinBoYeWo;
		private System.Windows.Forms.Label label41;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboLinBaJing;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Button cmdClear;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.GroupBox m_grbPiFu;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPiXiaZhiFang;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.TextBox m_txtPiFuQiTa;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboZhiZhuZhi;
		private System.Windows.Forms.Label label36;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboGanZhang;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.TextBox m_txtShuiZhong;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboShuiZhong;
		private System.Windows.Forms.Label label33;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTanXing;
		private System.Windows.Forms.Label label32;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboXiDu;
		private System.Windows.Forms.Label label31;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboWenDu;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.TextBox m_txtMaoFaFenBu;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboMaoFaFenBu;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox m_txtPiXiaChuXue;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPiXiaChuXue;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox m_txtPiZhen;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPiZhen;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label11;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboSeZhe;
		private System.Windows.Forms.GroupBox m_grbTouBu;
		private System.Windows.Forms.Label label85;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuShangE;
		private System.Windows.Forms.Label label84;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuFaYin;
		private System.Windows.Forms.Label label83;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuBianTaoTi;
		private System.Windows.Forms.Label label82;
		private System.Windows.Forms.Label label81;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuSheChi;
		private System.Windows.Forms.Label label80;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuShe;
		private System.Windows.Forms.Label label79;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuXiaNianMo;
		private System.Windows.Forms.Label label78;
		private System.Windows.Forms.TextBox m_txtTouBuYaChi;
		private System.Windows.Forms.Label label77;
		private System.Windows.Forms.Label label76;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuKouZhou;
		private System.Windows.Forms.Label label75;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuChiGen;
		private System.Windows.Forms.Label label74;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuChun;
		private System.Windows.Forms.Label label73;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.TextBox m_txtBiBuFenMiWu;
		private System.Windows.Forms.Label label70;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboBiBu;
		private System.Windows.Forms.Label label69;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboRuiTu;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.TextBox m_txtErBuFenMiWu;
		private System.Windows.Forms.Label label66;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuErBu;
		private System.Windows.Forms.Label label64;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboNeiZiZuiPi;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.TextBox m_txtJieHeMoFenMiWu;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.TextBox m_txtTouBuKuiYang;
		private System.Windows.Forms.Label label61;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuGongMo;
		private System.Windows.Forms.Label label60;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuJieHeMo;
		private System.Windows.Forms.Label label59;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuJiaoMo;
		private System.Windows.Forms.Label label58;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuYanQiu;
		private System.Windows.Forms.Label label57;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuDuiGuangFanYing;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label55;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuTongKong;
		private System.Windows.Forms.Label label54;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuTouPi;
		private System.Windows.Forms.Label label53;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuShezhe;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.TextBox m_txtTouBuLongQi;
		private System.Windows.Forms.Label label50;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuTouFa;
		private System.Windows.Forms.Label label49;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuQianLu;
		private System.Windows.Forms.Label label48;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuGuFeng;
		private System.Windows.Forms.Label label47;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTouBuXingTai;
		private System.Windows.Forms.GroupBox m_grbXiongBu;
		private System.Windows.Forms.Label label97;
		private System.Windows.Forms.TextBox m_txtXiongBuFenBu;
		private System.Windows.Forms.Label label96;
		private System.Windows.Forms.TextBox m_txtXiongBuXinZhuang;
		private System.Windows.Forms.Label label95;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboXiongBuXiongBu;
		private System.Windows.Forms.GroupBox m_grbFuGuGou;
		private System.Windows.Forms.TextBox m_txtFuGuGou;
		private System.Windows.Forms.Label label114;
		private System.Windows.Forms.GroupBox m_grbGangMen;
		private System.Windows.Forms.Label label134;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboGangMen;
		private System.Windows.Forms.GroupBox m_grbSiZhi;
		private System.Windows.Forms.TextBox m_txtTanHuang;
		private System.Windows.Forms.Label label137;
		private System.Windows.Forms.Label label136;
		private System.Windows.Forms.TextBox m_txtSiZhiYangTong;
		private System.Windows.Forms.Label label135;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboWuYiShiDongZuo;
		private System.Windows.Forms.Label label115;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboSiZhi;
		private System.Windows.Forms.Label label121;
		private System.Windows.Forms.GroupBox m_grbZhiZhu;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboHuoDongDu;
		private System.Windows.Forms.Label label138;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboJiZhu;
		private System.Windows.Forms.Label label122;
		private System.Windows.Forms.GroupBox m_grbShenJingFangShe;
		private System.Windows.Forms.TextBox m_txtShenJingFangSheQiTa;
		private System.Windows.Forms.TextBox m_txtLuoGuanJIeJingLan;
		private System.Windows.Forms.TextBox m_txtTiGaoFanShe;
		private System.Windows.Forms.TextBox m_txtFuBiFangShe;
		private System.Windows.Forms.TextBox m_txtOuShiZheng;
		private System.Windows.Forms.TextBox m_txtBaShiZheng;
		private System.Windows.Forms.TextBox m_txtBuShiZheng;
		private System.Windows.Forms.TextBox m_txtKeNiShiZheng;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboXiFangShe;
		private System.Windows.Forms.Label label125;
		private System.Windows.Forms.Label label132;
		private System.Windows.Forms.Label label131;
		private System.Windows.Forms.Label label130;
		private System.Windows.Forms.Label label129;
		private System.Windows.Forms.Label label128;
		private System.Windows.Forms.Label label127;
		private System.Windows.Forms.Label label126;
		private System.Windows.Forms.Label label124;
		private System.Windows.Forms.TabPage 一般情况;
		private System.Windows.Forms.TabPage 外生殖器;
		private System.Windows.Forms.TabPage 淋巴腺;
		private System.Windows.Forms.TabPage 颈部;
		private System.Windows.Forms.TabPage 腹部;
		private System.Windows.Forms.TabPage 皮肤;
		private System.Windows.Forms.TabPage 头部;
		private System.Windows.Forms.TabPage 胸部;
		private System.Windows.Forms.TabPage 腹股沟;
		private System.Windows.Forms.TabPage 肛门;
		private System.Windows.Forms.TabPage 四肢;
		private System.Windows.Forms.TabPage 脊柱;
		private System.Windows.Forms.TabPage 神经反射;
		private System.Windows.Forms.Button cmdPreView;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.TextBox m_txtPreView;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.TextBox textBox13;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.TextBox textBox14;
		private System.Windows.Forms.Label label123;
		private System.Windows.Forms.TextBox textBox15;
		private System.Windows.Forms.Label label133;
		private System.Windows.Forms.TextBox textBox16;
		private System.Windows.Forms.Label label139;
		private System.Windows.Forms.TextBox textBox17;
		private System.Windows.Forms.Label label140;
		private System.Windows.Forms.TextBox textBox18;
		private System.Windows.Forms.Label label141;
		private System.Windows.Forms.TextBox textBox19;
		private System.Windows.Forms.Label label142;
		private System.Windows.Forms.TextBox textBox20;
		private System.ComponentModel.IContainer components = null;
		#endregion Define

		public frmMedicalExam001()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
            //m_objBorderTool = new clsBorderTool(Color.White);
            //#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-29 17:01:41
            //foreach(Control ctlControl in this.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ctlRichTextBox" )
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
            //#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-29 17:01:41
            //foreach(Control ctlControl in this.m_grbFuBu.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ctlRichTextBox" )
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
            //#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-29 17:01:41
            //foreach(Control ctlControl in this.m_grbFuGuGou.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ctlRichTextBox" )
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
            //#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-29 17:01:41
            //foreach(Control ctlControl in this.m_grbGangMen.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ctlRichTextBox" )
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
            //#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-29 17:01:41
            //foreach(Control ctlControl in this.m_grbGeranal.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ctlRichTextBox" )
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
            //#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-29 17:01:41
            //foreach(Control ctlControl in this.m_grbJingBu.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ctlRichTextBox" )
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
            //#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-29 17:01:41
            //foreach(Control ctlControl in this.m_grbLinBaXian.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ctlRichTextBox" )
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
            //#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-29 17:01:41
            //foreach(Control ctlControl in this.m_grbPiFu.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ctlRichTextBox" )
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
            //#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-29 17:01:41
            //foreach(Control ctlControl in this.m_grbShenJingFangShe.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ctlRichTextBox" )
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
            //#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-29 17:01:41
            //foreach(Control ctlControl in this.m_grbSiZhi.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ctlRichTextBox" )
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
            //#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-29 17:01:41
            //foreach(Control ctlControl in this.m_grbTouBu.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ctlRichTextBox" )
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
            //#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-29 17:01:41
            //foreach(Control ctlControl in this.m_grbWaiShengJiQi.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ctlRichTextBox" )
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
            //#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-29 17:01:41
            //foreach(Control ctlControl in this.m_grbXiongBu.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ctlRichTextBox" )
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
            //#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-29 17:01:41
            //foreach(Control ctlControl in this.m_grbZhiZhu.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ctlRichTextBox" )
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

			#region 加入选项,刘颖源,2003-6-2 15:15:26
			m_mthAddMuliStringToComboBox(m_cboBiaoQing,"如常|愉快|苦闷|烦躁|惶恐|不安|呆滞|全无|呈急病容|慢性病容");
			m_mthAddMuliStringToComboBox(m_cboBiBu ,"正常|有分泌物");
			m_mthAddMuliStringToComboBox(m_cboBuTai ,"正常|不正常");			
			m_mthAddMuliStringToComboBox (m_cboFaYu ,"正常|中等|不正常|畸形");
			m_mthAddMuliStringToComboBox(m_cboFuBuBianYuan,"锐|钝");
			m_mthAddMuliStringToComboBox(m_cboFuBuChangRuDongYin ,"正常|亢进|减弱|消失");
			m_mthAddMuliStringToComboBox(m_cboFuBuDanNang ,"未触及|压痛");
			m_mthAddMuliStringToComboBox (m_cboFuBuFuBi ,"柔软|紧张|强直|静脉努张");
			m_mthAddMuliStringToComboBox (m_cboFuBuFuBu ,"正常|膨胀|缺陷");
			m_mthAddMuliStringToComboBox (m_cboFuBuGangZang ,"不可触知|仅可触知|表面平滑|凹凸不平");
			m_mthAddMuliStringToComboBox (m_cboFuBuJi ,"正常|突出|红肿|出血|有分泌物");
			m_mthAddMuliStringToComboBox (m_cboFuBuPiZang ,"不可触知|仅可触知|肿大|坚实|柔软");
			m_mthAddMuliStringToComboBox (m_cboFuBuYingDu ,"I|II|III");
			m_mthAddMuliStringToComboBox (m_cboGangMen ,"正常|闭锁|红肿|皲裂|肛脱");
			m_mthAddMuliStringToComboBox (m_cboGanZhang ,"无|有");
			m_mthAddMuliStringToComboBox(m_cboGouWan ,"正常|未下降|肿大|触痛");
			m_mthAddMuliStringToComboBox(m_cboHuiYinBu,"正常|其他");
			m_mthAddMuliStringToComboBox (m_cboHuoDongDu ,"正常|受限");
			m_mthAddMuliStringToComboBox(m_cboJIngBuDiKangLi ,"无|有");
			m_mthAddMuliStringToComboBox(m_cboJingBuJingBu ,"正常|强直|无力|后倾|斜倾");
			m_mthAddMuliStringToComboBox(m_cboJingBuJingDongLi ,"搏动正常|搏动增强|血管杂音");
			m_mthAddMuliStringToComboBox (m_cboJingBuJingJingMai ,"正常|充盈|努张");
			m_mthAddMuliStringToComboBox (m_cboJingBuQiGuan ,"居中|偏左|偏右");
			m_mthAddMuliStringToComboBox(m_cboJiZhu ,"正常|前凸|后凸|侧弯|触痛|强直|脓疡|角弓反张|椎裂");
			m_mthAddMuliStringToComboBox(m_cboLinBaDaXiao ,"不可触知|肿大");
			m_mthAddMuliStringToComboBox(m_cboLinBaFuGuGou ,"左|右");
			m_mthAddMuliStringToComboBox (m_cboLinBaJing ,"左|右");
			m_mthAddMuliStringToComboBox (m_cboLinBaXingZhuang ,"坚实|柔软|单个|联接成球|可移动|不可移动|压痛|化脓|瘘管");
			m_mthAddMuliStringToComboBox (m_cboLinBoYeWo ,"左|右");
			m_mthAddMuliStringToComboBox (m_cboMianRong ,"无病容|急性病容|慢性病容|其他");
			m_mthAddMuliStringToComboBox(m_cboNeiZiZuiPi ,"有|无");
			m_mthAddMuliStringToComboBox(m_cboPeiHeJianCha ,"合作|不合作");
			m_mthAddMuliStringToComboBox(m_cboPiXiaChuXue,"无|有");
			m_mthAddMuliStringToComboBox(m_cboPiXiaZhiFang ,"丰富|中等|松弛");
			m_mthAddMuliStringToComboBox(m_cboPiZhen ,"无|有");
			m_mthAddMuliStringToComboBox(m_cborJingBuJiaZhuangXian ,"正常|肿大|震颤|血管杂音");
			m_mthAddMuliStringToComboBox(m_cboRuiTu ,"正常|红肿|触痛|溃疡");
			m_mthAddMuliStringToComboBox(m_cboSeZhe ,"正常|红润|干燥|青紫|黄疸|苍白|带黄");
			m_mthAddMuliStringToComboBox(m_cboShenZhi ,"清楚|模糊|昏睡");
			m_mthAddMuliStringToComboBox(m_cboShuiZhong ,"无|有");
			m_mthAddMuliStringToComboBox(m_cboSiZhi ,"正常|强直|抽搐");
			m_mthAddMuliStringToComboBox(m_cboTanXing ,"良好|中等|松弛");
			m_mthAddMuliStringToComboBox(m_cboTiWei ,"自主|半卧位|其他");
			m_mthAddMuliStringToComboBox(m_cboTouBuBianTaoTi ,"正常|肿大|充血|白点|假膜|已摘除");
			m_mthAddMuliStringToComboBox(m_cboTouBuChiGen ,"正常|红肿|出血|流脓|溃疡|黑纹");
			m_mthAddMuliStringToComboBox(m_cboTouBuChun ,"正常|青紫|苍白|干|皲裂|兔唇");
			m_mthAddMuliStringToComboBox(m_cboTouBuErBu ,"正常|侧耳道有分泌物|叮咛|湿疹");
			m_mthAddMuliStringToComboBox(m_cboTouBuFaYin ,"正常|微弱|嘶哑|失声");
			m_mthAddMuliStringToComboBox(m_cboTouBuGongMo ,"正常|黄疸|出血");
			m_mthAddMuliStringToComboBox(m_cboTouBuJiaoMo ,"正常|混浊|干燥|溃疡");
			m_mthAddMuliStringToComboBox(m_cboTouBuJieHeMo ,"正常|充血|浮肿|有分泌物|干燥|出血|脓泡");
			m_mthAddMuliStringToComboBox(m_cboTouBuKouZhou ,"正常|发绀|口角疮");
			m_mthAddMuliStringToComboBox(m_cboTouBuQianLu ,"已合|未合|隆起|平坦|凹陷");
			m_mthAddMuliStringToComboBox(m_cboTouBuShangE ,"正常|腭裂");
			m_mthAddMuliStringToComboBox(m_cboTouBuShe ,"正常|舌苔厚|舌苔薄");
			m_mthAddMuliStringToComboBox(m_cboTouBuSheChi ,"正常|增大|萎缩");
			m_mthAddMuliStringToComboBox(m_cboTouBuShezhe ,"黑|黄");
			m_mthAddMuliStringToComboBox(m_cboTouBuTongKong ,"正常|散大|缩小|不对称");
			m_mthAddMuliStringToComboBox(m_cboTouBuTouFa ,"疏|密|秃");
			m_mthAddMuliStringToComboBox(m_cboTouBuTouPi ,"正常|脓泡|疖疮|发癣");
			m_mthAddMuliStringToComboBox(m_cboTouBuXiaNianMo ,"正常|溃疡|鹅口疮|麻疹粘膜斑");
			m_mthAddMuliStringToComboBox(m_cboTouBuXingTai ,"正常|畸形");
			m_mthAddMuliStringToComboBox(m_cboTouBuYanQiu, "正常|混浊|干燥|溃疡");
			m_mthAddMuliStringToComboBox(m_cboWaiShengJiQi,"正常|包茎|畸形");
			m_mthAddMuliStringToComboBox(m_cboWaiYinBu,"正常|浮肿|有性分泌物");
			m_mthAddMuliStringToComboBox(m_cboWenDu,"灼热|温暖|冰冷");
			m_mthAddMuliStringToComboBox(m_cboWuYiShiDongZuo,"震颤|畸形");
			m_mthAddMuliStringToComboBox(m_cboXiDu,"干|湿");
			m_mthAddMuliStringToComboBox(m_cboXiFangShe,"正常|亢进|减弱|消失");
			m_mthAddMuliStringToComboBox(m_cboXiongBuXiongBu,"正常|鸡胸|漏斗形|不对称||心前区突出郝氏沟|肋间串珠|肋间下陷|突出");
			m_mthAddMuliStringToComboBox(m_cboYingYang,"优良|中等|不良");
			m_mthAddMuliStringToComboBox(m_cboYinNang,"正常|水肿|肿大");
			m_mthAddMuliStringToComboBox(m_cboZhiZhuZhi,"无|有");
			m_mthAddMuliStringToComboBox (m_cboHuXi ,"平静|急促|浅弱|深长|不规则|鼻翼扇动|其他");
			m_mthAddMuliStringToComboBox (m_cboBingQing ,"轻度|中等|严重|紧急");
			m_mthAddMuliStringToComboBox (m_cboTuoShui ,"无|轻度|中等|重度");
			m_mthAddMuliStringToComboBox (m_cboMaoFaFenBu ,"正常|多毛|稀疏|脱落");
			m_mthAddMuliStringToComboBox (m_cboTouBuGuFeng,"已合|未合");
			m_mthAddMuliStringToComboBox (m_cboTouBuDuiGuangFanYing ,"正常|迟缓|消失");

			#endregion
			
			m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);

			m_cboDept.Visible = false;
			lblDept.Visible = false;

			/* When the Close method is called on a Form displayed as a modeless window, 
			you cannot call the Show method to make the form visible, 
			because the form's resources have already been released. */
			this.Closing += new CancelEventHandler(m_mthCancelClose);

		}

		private ctlHighLightFocus m_objHighLight;

		#region 成员变量,刘颖源,2003-6-2 15:13:09
        //clsBorderTool m_objBorderTool=new clsBorderTool (System.Drawing.Color.White );
		public bool m_blnIsOK=false;
		private clsMedicalExamDomain m_objMedicalExamDomain=new clsMedicalExamDomain ();

		#endregion

		#region 加入选项,刘颖源,2003-6-2 15:22:42
		private void m_mthAddMuliStringToComboBox(ctlComboBox p_cboComboBox,string p_strSource)
		{
			int i=0;
			int j=0;
			p_cboComboBox.ClearItem ();
			j=p_strSource.IndexOf ("|",i);
			while(j>=0)
			{

				if(j>i)
					p_cboComboBox.AddItem (p_strSource.Substring (i,j-i));
				else
					p_cboComboBox.AddItem (p_strSource.Substring (i,p_strSource.Length -i));
				i=j+1;
				j=p_strSource.IndexOf ("|",j+1);
				if(j<0)
				{
					p_cboComboBox.AddItem (p_strSource.Substring (i,p_strSource.Length -i));
				}

			}
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.一般情况 = new System.Windows.Forms.TabPage();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.m_grbGeranal = new System.Windows.Forms.GroupBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.m_cboTuoShui = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label24 = new System.Windows.Forms.Label();
			this.m_cboHuXi = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label23 = new System.Windows.Forms.Label();
			this.m_cboBingQing = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.m_cboTiWei = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label19 = new System.Windows.Forms.Label();
			this.m_cboMianRong = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label18 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.m_cboPeiHeJianCha = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.m_cboBuTai = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.m_cboBiaoQing = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.m_cboShenZhi = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.m_cboYingYang = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.m_cboFaYu = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.m_txtTemperature = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.头部 = new System.Windows.Forms.TabPage();
			this.m_grbTouBu = new System.Windows.Forms.GroupBox();
			this.label13 = new System.Windows.Forms.Label();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.label85 = new System.Windows.Forms.Label();
			this.m_cboTouBuShangE = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label84 = new System.Windows.Forms.Label();
			this.m_cboTouBuFaYin = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label83 = new System.Windows.Forms.Label();
			this.m_cboTouBuBianTaoTi = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label82 = new System.Windows.Forms.Label();
			this.label81 = new System.Windows.Forms.Label();
			this.m_cboTouBuSheChi = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label80 = new System.Windows.Forms.Label();
			this.m_cboTouBuShe = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label79 = new System.Windows.Forms.Label();
			this.m_cboTouBuXiaNianMo = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label78 = new System.Windows.Forms.Label();
			this.m_txtTouBuYaChi = new System.Windows.Forms.TextBox();
			this.label77 = new System.Windows.Forms.Label();
			this.label76 = new System.Windows.Forms.Label();
			this.m_cboTouBuKouZhou = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label75 = new System.Windows.Forms.Label();
			this.m_cboTouBuChiGen = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label74 = new System.Windows.Forms.Label();
			this.m_cboTouBuChun = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label73 = new System.Windows.Forms.Label();
			this.label72 = new System.Windows.Forms.Label();
			this.m_txtBiBuFenMiWu = new System.Windows.Forms.TextBox();
			this.label70 = new System.Windows.Forms.Label();
			this.m_cboBiBu = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label69 = new System.Windows.Forms.Label();
			this.m_cboRuiTu = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label67 = new System.Windows.Forms.Label();
			this.m_txtErBuFenMiWu = new System.Windows.Forms.TextBox();
			this.label66 = new System.Windows.Forms.Label();
			this.m_cboTouBuErBu = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label64 = new System.Windows.Forms.Label();
			this.m_cboNeiZiZuiPi = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label65 = new System.Windows.Forms.Label();
			this.m_txtJieHeMoFenMiWu = new System.Windows.Forms.TextBox();
			this.label63 = new System.Windows.Forms.Label();
			this.label62 = new System.Windows.Forms.Label();
			this.m_txtTouBuKuiYang = new System.Windows.Forms.TextBox();
			this.label61 = new System.Windows.Forms.Label();
			this.m_cboTouBuGongMo = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label60 = new System.Windows.Forms.Label();
			this.m_cboTouBuJieHeMo = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label59 = new System.Windows.Forms.Label();
			this.m_cboTouBuJiaoMo = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label58 = new System.Windows.Forms.Label();
			this.m_cboTouBuYanQiu = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label57 = new System.Windows.Forms.Label();
			this.m_cboTouBuDuiGuangFanYing = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label56 = new System.Windows.Forms.Label();
			this.label55 = new System.Windows.Forms.Label();
			this.m_cboTouBuTongKong = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label54 = new System.Windows.Forms.Label();
			this.m_cboTouBuTouPi = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label53 = new System.Windows.Forms.Label();
			this.m_cboTouBuShezhe = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label52 = new System.Windows.Forms.Label();
			this.label51 = new System.Windows.Forms.Label();
			this.m_txtTouBuLongQi = new System.Windows.Forms.TextBox();
			this.label50 = new System.Windows.Forms.Label();
			this.m_cboTouBuTouFa = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label49 = new System.Windows.Forms.Label();
			this.m_cboTouBuQianLu = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label48 = new System.Windows.Forms.Label();
			this.m_cboTouBuGuFeng = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label47 = new System.Windows.Forms.Label();
			this.m_cboTouBuXingTai = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.皮肤 = new System.Windows.Forms.TabPage();
			this.m_grbPiFu = new System.Windows.Forms.GroupBox();
			this.m_cboPiXiaZhiFang = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label38 = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.m_txtPiFuQiTa = new System.Windows.Forms.TextBox();
			this.m_cboZhiZhuZhi = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label36 = new System.Windows.Forms.Label();
			this.m_cboGanZhang = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label35 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.m_txtShuiZhong = new System.Windows.Forms.TextBox();
			this.m_cboShuiZhong = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label33 = new System.Windows.Forms.Label();
			this.m_cboTanXing = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label32 = new System.Windows.Forms.Label();
			this.m_cboXiDu = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label31 = new System.Windows.Forms.Label();
			this.m_cboWenDu = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label30 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.m_txtMaoFaFenBu = new System.Windows.Forms.TextBox();
			this.m_cboMaoFaFenBu = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label29 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.m_txtPiXiaChuXue = new System.Windows.Forms.TextBox();
			this.m_cboPiXiaChuXue = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label27 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.m_txtPiZhen = new System.Windows.Forms.TextBox();
			this.m_cboPiZhen = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label21 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.m_cboSeZhe = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.淋巴腺 = new System.Windows.Forms.TabPage();
			this.m_grbLinBaXian = new System.Windows.Forms.GroupBox();
			this.label68 = new System.Windows.Forms.Label();
			this.textBox13 = new System.Windows.Forms.TextBox();
			this.label46 = new System.Windows.Forms.Label();
			this.m_cboLinBaXingZhuang = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label45 = new System.Windows.Forms.Label();
			this.label44 = new System.Windows.Forms.Label();
			this.m_txtLinBaDaXiao = new System.Windows.Forms.TextBox();
			this.m_cboLinBaDaXiao = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label43 = new System.Windows.Forms.Label();
			this.m_cboLinBaFuGuGou = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label42 = new System.Windows.Forms.Label();
			this.m_cboLinBoYeWo = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label41 = new System.Windows.Forms.Label();
			this.m_cboLinBaJing = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label40 = new System.Windows.Forms.Label();
			this.label39 = new System.Windows.Forms.Label();
			this.颈部 = new System.Windows.Forms.TabPage();
			this.m_grbJingBu = new System.Windows.Forms.GroupBox();
			this.label71 = new System.Windows.Forms.Label();
			this.textBox14 = new System.Windows.Forms.TextBox();
			this.label94 = new System.Windows.Forms.Label();
			this.label93 = new System.Windows.Forms.Label();
			this.m_txtJiaZhuangXian = new System.Windows.Forms.TextBox();
			this.label92 = new System.Windows.Forms.Label();
			this.m_cborJingBuJiaZhuangXian = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label91 = new System.Windows.Forms.Label();
			this.m_txtJingBuHuiLiuZheng = new System.Windows.Forms.TextBox();
			this.label90 = new System.Windows.Forms.Label();
			this.m_cboJingBuQiGuan = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label89 = new System.Windows.Forms.Label();
			this.m_cboJingBuJingJingMai = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label88 = new System.Windows.Forms.Label();
			this.m_cboJingBuJingDongLi = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label87 = new System.Windows.Forms.Label();
			this.m_cboJIngBuDiKangLi = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label86 = new System.Windows.Forms.Label();
			this.m_cboJingBuJingBu = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.胸部 = new System.Windows.Forms.TabPage();
			this.m_grbXiongBu = new System.Windows.Forms.GroupBox();
			this.label123 = new System.Windows.Forms.Label();
			this.textBox15 = new System.Windows.Forms.TextBox();
			this.label97 = new System.Windows.Forms.Label();
			this.m_txtXiongBuFenBu = new System.Windows.Forms.TextBox();
			this.label96 = new System.Windows.Forms.Label();
			this.m_txtXiongBuXinZhuang = new System.Windows.Forms.TextBox();
			this.label95 = new System.Windows.Forms.Label();
			this.m_cboXiongBuXiongBu = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.腹部 = new System.Windows.Forms.TabPage();
			this.m_grbFuBu = new System.Windows.Forms.GroupBox();
			this.m_txtFuBuQiTa = new System.Windows.Forms.TextBox();
			this.m_cboFuBuJi = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label113 = new System.Windows.Forms.Label();
			this.label112 = new System.Windows.Forms.Label();
			this.label111 = new System.Windows.Forms.Label();
			this.m_cboFuBuChangRuDongYin = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label110 = new System.Windows.Forms.Label();
			this.m_txtFuBuBaoKuai = new System.Windows.Forms.TextBox();
			this.label109 = new System.Windows.Forms.Label();
			this.m_cboFuBuBianYuan = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label108 = new System.Windows.Forms.Label();
			this.m_cboFuBuYingDu = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label107 = new System.Windows.Forms.Label();
			this.m_cboFuBuPiZang = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label106 = new System.Windows.Forms.Label();
			this.m_txtFuBuDanNang = new System.Windows.Forms.TextBox();
			this.label105 = new System.Windows.Forms.Label();
			this.m_cboFuBuDanNang = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label103 = new System.Windows.Forms.Label();
			this.label104 = new System.Windows.Forms.Label();
			this.m_txtFuBuGangZhang = new System.Windows.Forms.TextBox();
			this.label102 = new System.Windows.Forms.Label();
			this.m_cboFuBuGangZang = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label101 = new System.Windows.Forms.Label();
			this.label100 = new System.Windows.Forms.Label();
			this.m_txtFuBuFuBi = new System.Windows.Forms.TextBox();
			this.label99 = new System.Windows.Forms.Label();
			this.m_cboFuBuFuBi = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label98 = new System.Windows.Forms.Label();
			this.m_cboFuBuFuBu = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.腹股沟 = new System.Windows.Forms.TabPage();
			this.m_grbFuGuGou = new System.Windows.Forms.GroupBox();
			this.label133 = new System.Windows.Forms.Label();
			this.textBox16 = new System.Windows.Forms.TextBox();
			this.m_txtFuGuGou = new System.Windows.Forms.TextBox();
			this.label114 = new System.Windows.Forms.Label();
			this.肛门 = new System.Windows.Forms.TabPage();
			this.m_grbGangMen = new System.Windows.Forms.GroupBox();
			this.label139 = new System.Windows.Forms.Label();
			this.textBox17 = new System.Windows.Forms.TextBox();
			this.label134 = new System.Windows.Forms.Label();
			this.m_cboGangMen = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.外生殖器 = new System.Windows.Forms.TabPage();
			this.m_grbWaiShengJiQi = new System.Windows.Forms.GroupBox();
			this.label140 = new System.Windows.Forms.Label();
			this.textBox18 = new System.Windows.Forms.TextBox();
			this.m_cboHuiYinBu = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label120 = new System.Windows.Forms.Label();
			this.m_cboYinNang = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboWaiYinBu = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label119 = new System.Windows.Forms.Label();
			this.label118 = new System.Windows.Forms.Label();
			this.label117 = new System.Windows.Forms.Label();
			this.m_cboGouWan = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label116 = new System.Windows.Forms.Label();
			this.m_cboWaiShengJiQi = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.四肢 = new System.Windows.Forms.TabPage();
			this.m_grbSiZhi = new System.Windows.Forms.GroupBox();
			this.label141 = new System.Windows.Forms.Label();
			this.textBox19 = new System.Windows.Forms.TextBox();
			this.m_txtTanHuang = new System.Windows.Forms.TextBox();
			this.label137 = new System.Windows.Forms.Label();
			this.label136 = new System.Windows.Forms.Label();
			this.m_txtSiZhiYangTong = new System.Windows.Forms.TextBox();
			this.label135 = new System.Windows.Forms.Label();
			this.m_cboWuYiShiDongZuo = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label115 = new System.Windows.Forms.Label();
			this.m_cboSiZhi = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label121 = new System.Windows.Forms.Label();
			this.脊柱 = new System.Windows.Forms.TabPage();
			this.m_grbZhiZhu = new System.Windows.Forms.GroupBox();
			this.label142 = new System.Windows.Forms.Label();
			this.textBox20 = new System.Windows.Forms.TextBox();
			this.m_cboHuoDongDu = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label138 = new System.Windows.Forms.Label();
			this.m_cboJiZhu = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label122 = new System.Windows.Forms.Label();
			this.神经反射 = new System.Windows.Forms.TabPage();
			this.m_grbShenJingFangShe = new System.Windows.Forms.GroupBox();
			this.m_txtShenJingFangSheQiTa = new System.Windows.Forms.TextBox();
			this.m_txtLuoGuanJIeJingLan = new System.Windows.Forms.TextBox();
			this.m_txtTiGaoFanShe = new System.Windows.Forms.TextBox();
			this.m_txtFuBiFangShe = new System.Windows.Forms.TextBox();
			this.m_txtOuShiZheng = new System.Windows.Forms.TextBox();
			this.m_txtBaShiZheng = new System.Windows.Forms.TextBox();
			this.m_txtBuShiZheng = new System.Windows.Forms.TextBox();
			this.m_txtKeNiShiZheng = new System.Windows.Forms.TextBox();
			this.m_cboXiFangShe = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label125 = new System.Windows.Forms.Label();
			this.label132 = new System.Windows.Forms.Label();
			this.label131 = new System.Windows.Forms.Label();
			this.label130 = new System.Windows.Forms.Label();
			this.label129 = new System.Windows.Forms.Label();
			this.label128 = new System.Windows.Forms.Label();
			this.label127 = new System.Windows.Forms.Label();
			this.label126 = new System.Windows.Forms.Label();
			this.label124 = new System.Windows.Forms.Label();
			this.m_txtPreView = new System.Windows.Forms.TextBox();
			this.cmdPreView = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdClear = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.一般情况.SuspendLayout();
			this.m_grbGeranal.SuspendLayout();
			this.头部.SuspendLayout();
			this.m_grbTouBu.SuspendLayout();
			this.皮肤.SuspendLayout();
			this.m_grbPiFu.SuspendLayout();
			this.淋巴腺.SuspendLayout();
			this.m_grbLinBaXian.SuspendLayout();
			this.颈部.SuspendLayout();
			this.m_grbJingBu.SuspendLayout();
			this.胸部.SuspendLayout();
			this.m_grbXiongBu.SuspendLayout();
			this.腹部.SuspendLayout();
			this.m_grbFuBu.SuspendLayout();
			this.腹股沟.SuspendLayout();
			this.m_grbFuGuGou.SuspendLayout();
			this.肛门.SuspendLayout();
			this.m_grbGangMen.SuspendLayout();
			this.外生殖器.SuspendLayout();
			this.m_grbWaiShengJiQi.SuspendLayout();
			this.四肢.SuspendLayout();
			this.m_grbSiZhi.SuspendLayout();
			this.脊柱.SuspendLayout();
			this.m_grbZhiZhu.SuspendLayout();
			this.神经反射.SuspendLayout();
			this.m_grbShenJingFangShe.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_lblForTitle
			// 
			this.m_lblForTitle.Location = new System.Drawing.Point(-2000, -8);
			this.m_lblForTitle.Size = new System.Drawing.Size(472, 48);
			this.m_lblForTitle.Visible = true;
			// 
			// lblSex
			// 
			this.lblSex.Location = new System.Drawing.Point(-264, 136);
			this.lblSex.Size = new System.Drawing.Size(104, 19);
			this.lblSex.Visible = true;
			// 
			// lblAge
			// 
			this.lblAge.Location = new System.Drawing.Point(-144, 136);
			this.lblAge.Size = new System.Drawing.Size(108, 19);
			this.lblAge.Visible = true;
			// 
			// lblBedNoTitle
			// 
			this.lblBedNoTitle.Location = new System.Drawing.Point(-360, 40);
			this.lblBedNoTitle.Visible = true;
			// 
			// lblInHospitalNoTitle
			// 
			this.lblInHospitalNoTitle.Location = new System.Drawing.Point(-80, 136);
			this.lblInHospitalNoTitle.Visible = true;
			// 
			// lblNameTitle
			// 
			this.lblNameTitle.Location = new System.Drawing.Point(-232, 40);
			this.lblNameTitle.Visible = true;
			// 
			// lblSexTitle
			// 
			this.lblSexTitle.Location = new System.Drawing.Point(-80, 40);
			this.lblSexTitle.Visible = true;
			// 
			// lblAgeTitle
			// 
			this.lblAgeTitle.Location = new System.Drawing.Point(-200, 136);
			this.lblAgeTitle.Visible = true;
			// 
			// lblAreaTitle
			// 
			this.lblAreaTitle.Location = new System.Drawing.Point(-552, 40);
			this.lblAreaTitle.Visible = true;
			// 
			// m_lsvInPatientID
			// 
			this.m_lsvInPatientID.Location = new System.Drawing.Point(-2000, 160);
			this.m_lsvInPatientID.Size = new System.Drawing.Size(164, 104);
			this.m_lsvInPatientID.Visible = true;
			// 
			// txtInPatientID
			// 
			this.txtInPatientID.Location = new System.Drawing.Point(-200, 136);
			this.txtInPatientID.Size = new System.Drawing.Size(164, 26);
			this.txtInPatientID.Visible = true;
			// 
			// m_txtPatientName
			// 
			this.m_txtPatientName.Location = new System.Drawing.Point(-184, 40);
			this.m_txtPatientName.Size = new System.Drawing.Size(156, 26);
			this.m_txtPatientName.Visible = true;
			// 
			// m_txtBedNO
			// 
			this.m_txtBedNO.Location = new System.Drawing.Point(-312, 40);
			this.m_txtBedNO.Size = new System.Drawing.Size(124, 26);
			this.m_txtBedNO.Visible = true;
			// 
			// m_cboArea
			// 
			this.m_cboArea.Location = new System.Drawing.Point(-504, 40);
			this.m_cboArea.Size = new System.Drawing.Size(188, 26);
			this.m_cboArea.Visible = true;
			// 
			// m_lsvPatientName
			// 
			this.m_lsvPatientName.Location = new System.Drawing.Point(-184, 64);
			this.m_lsvPatientName.Size = new System.Drawing.Size(156, 104);
			this.m_lsvPatientName.Visible = true;
			// 
			// m_lsvBedNO
			// 
			this.m_lsvBedNO.Location = new System.Drawing.Point(-312, 64);
			this.m_lsvBedNO.Size = new System.Drawing.Size(136, 104);
			this.m_lsvBedNO.Visible = true;
			// 
			// m_cboDept
			// 
			this.m_cboDept.Location = new System.Drawing.Point(88, 300);
			this.m_cboDept.Size = new System.Drawing.Size(0, 26);
			this.m_cboDept.Visible = true;
			// 
			// lblDept
			// 
			this.lblDept.Location = new System.Drawing.Point(40, 308);
			this.lblDept.Size = new System.Drawing.Size(0, 19);
			this.lblDept.Text = "";
			this.lblDept.Visible = true;
			// 
			// m_cmdNext
			// 
			this.m_cmdNext.Location = new System.Drawing.Point(200, 520);
			// 
			// m_cmdPre
			// 
			this.m_cmdPre.Location = new System.Drawing.Point(176, 520);
			// 
			// tabControl1
			// 
			this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.一般情况,
																					  this.头部,
																					  this.皮肤,
																					  this.淋巴腺,
																					  this.颈部,
																					  this.胸部,
																					  this.腹部,
																					  this.腹股沟,
																					  this.肛门,
																					  this.外生殖器,
																					  this.四肢,
																					  this.脊柱,
																					  this.神经反射});
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(900, 396);
			this.tabControl1.TabIndex = 3039;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// 一般情况
			// 
			this.一般情况.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.一般情况.Controls.AddRange(new System.Windows.Forms.Control[] {
																			   this.button4,
																			   this.button3,
																			   this.button2,
																			   this.button1,
																			   this.m_grbGeranal,
																			   this.label3,
																			   this.label2,
																			   this.textBox2,
																			   this.m_txtTemperature,
																			   this.label1,
																			   this.textBox3,
																			   this.label4,
																			   this.textBox1});
			this.一般情况.Location = new System.Drawing.Point(4, 26);
			this.一般情况.Name = "一般情况";
			this.一般情况.Size = new System.Drawing.Size(892, 366);
			this.一般情况.TabIndex = 0;
			this.一般情况.Text = "一般情况";
			// 
			// button4
			// 
			this.button4.ForeColor = System.Drawing.Color.White;
			this.button4.Location = new System.Drawing.Point(820, 440);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(56, 28);
			this.button4.TabIndex = 3044;
			this.button4.Text = "Clear";
			this.button4.Visible = false;
			// 
			// button3
			// 
			this.button3.ForeColor = System.Drawing.Color.White;
			this.button3.Location = new System.Drawing.Point(764, 440);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(56, 28);
			this.button3.TabIndex = 3043;
			this.button3.Text = "String";
			this.button3.Visible = false;
			// 
			// button2
			// 
			this.button2.ForeColor = System.Drawing.Color.White;
			this.button2.Location = new System.Drawing.Point(716, 440);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(48, 28);
			this.button2.TabIndex = 3042;
			this.button2.Text = "Load";
			this.button2.Visible = false;
			// 
			// button1
			// 
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(668, 440);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(48, 28);
			this.button1.TabIndex = 3041;
			this.button1.Text = "Save";
			this.button1.Visible = false;
			// 
			// m_grbGeranal
			// 
			this.m_grbGeranal.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.label12,
																					   this.textBox9,
																					   this.label25,
																					   this.m_cboTuoShui,
																					   this.label24,
																					   this.m_cboHuXi,
																					   this.label23,
																					   this.m_cboBingQing,
																					   this.textBox11,
																					   this.textBox10,
																					   this.label20,
																					   this.m_cboTiWei,
																					   this.label19,
																					   this.m_cboMianRong,
																					   this.label18,
																					   this.textBox8,
																					   this.label17,
																					   this.textBox7,
																					   this.label16,
																					   this.textBox6,
																					   this.label15,
																					   this.textBox5,
																					   this.label14,
																					   this.textBox4,
																					   this.label10,
																					   this.m_cboPeiHeJianCha,
																					   this.label9,
																					   this.m_cboBuTai,
																					   this.label8,
																					   this.m_cboBiaoQing,
																					   this.label7,
																					   this.m_cboShenZhi,
																					   this.label6,
																					   this.m_cboYingYang,
																					   this.label5,
																					   this.m_cboFaYu});
			this.m_grbGeranal.ForeColor = System.Drawing.Color.White;
			this.m_grbGeranal.Location = new System.Drawing.Point(8, 8);
			this.m_grbGeranal.Name = "m_grbGeranal";
			this.m_grbGeranal.Size = new System.Drawing.Size(876, 236);
			this.m_grbGeranal.TabIndex = 10;
			this.m_grbGeranal.TabStop = false;
			this.m_grbGeranal.Text = "一般情况";
			// 
			// label12
			// 
			this.label12.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label12.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label12.ForeColor = System.Drawing.Color.White;
			this.label12.Location = new System.Drawing.Point(8, 160);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(48, 16);
			this.label12.TabIndex = 3085;
			this.label12.Text = "其他";
			// 
			// textBox9
			// 
			this.textBox9.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox9.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox9.ForeColor = System.Drawing.Color.White;
			this.textBox9.Location = new System.Drawing.Point(72, 160);
			this.textBox9.Multiline = true;
			this.textBox9.Name = "textBox9";
			this.textBox9.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox9.Size = new System.Drawing.Size(792, 64);
			this.textBox9.TabIndex = 3084;
			this.textBox9.Tag = "[0][0001][09999][0]";
			this.textBox9.Text = "";
			// 
			// label25
			// 
			this.label25.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label25.ForeColor = System.Drawing.Color.White;
			this.label25.Location = new System.Drawing.Point(536, 96);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(40, 16);
			this.label25.TabIndex = 3075;
			this.label25.Text = "脱水";
			// 
			// m_cboTuoShui
			// 
			this.m_cboTuoShui.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTuoShui.BorderColor = System.Drawing.Color.White;
			this.m_cboTuoShui.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTuoShui.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTuoShui.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTuoShui.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTuoShui.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTuoShui.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTuoShui.ForeColor = System.Drawing.Color.White;
			this.m_cboTuoShui.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTuoShui.ListForeColor = System.Drawing.Color.White;
			this.m_cboTuoShui.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTuoShui.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTuoShui.Location = new System.Drawing.Point(584, 88);
			this.m_cboTuoShui.Name = "m_cboTuoShui";
			this.m_cboTuoShui.SelectedIndex = -1;
			this.m_cboTuoShui.SelectedItem = null;
			this.m_cboTuoShui.Size = new System.Drawing.Size(112, 26);
			this.m_cboTuoShui.TabIndex = 180;
			this.m_cboTuoShui.Tag = "[1][0001][00017][0]";
			this.m_cboTuoShui.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTuoShui.TextForeColor = System.Drawing.Color.White;
			// 
			// label24
			// 
			this.label24.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label24.ForeColor = System.Drawing.Color.White;
			this.label24.Location = new System.Drawing.Point(704, 64);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(40, 16);
			this.label24.TabIndex = 3073;
			this.label24.Text = "呼吸";
			// 
			// m_cboHuXi
			// 
			this.m_cboHuXi.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboHuXi.BorderColor = System.Drawing.Color.White;
			this.m_cboHuXi.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboHuXi.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboHuXi.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboHuXi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboHuXi.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboHuXi.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboHuXi.ForeColor = System.Drawing.Color.White;
			this.m_cboHuXi.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboHuXi.ListForeColor = System.Drawing.Color.White;
			this.m_cboHuXi.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboHuXi.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboHuXi.Location = new System.Drawing.Point(752, 56);
			this.m_cboHuXi.Name = "m_cboHuXi";
			this.m_cboHuXi.SelectedIndex = -1;
			this.m_cboHuXi.SelectedItem = null;
			this.m_cboHuXi.Size = new System.Drawing.Size(112, 26);
			this.m_cboHuXi.TabIndex = 140;
			this.m_cboHuXi.Tag = "[1][0001][00016][0]";
			this.m_cboHuXi.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboHuXi.TextForeColor = System.Drawing.Color.White;
			// 
			// label23
			// 
			this.label23.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label23.ForeColor = System.Drawing.Color.White;
			this.label23.Location = new System.Drawing.Point(536, 64);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(40, 16);
			this.label23.TabIndex = 3071;
			this.label23.Text = "病情";
			// 
			// m_cboBingQing
			// 
			this.m_cboBingQing.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboBingQing.BorderColor = System.Drawing.Color.White;
			this.m_cboBingQing.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboBingQing.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboBingQing.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboBingQing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboBingQing.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboBingQing.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboBingQing.ForeColor = System.Drawing.Color.White;
			this.m_cboBingQing.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboBingQing.ListForeColor = System.Drawing.Color.White;
			this.m_cboBingQing.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboBingQing.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboBingQing.Location = new System.Drawing.Point(584, 56);
			this.m_cboBingQing.Name = "m_cboBingQing";
			this.m_cboBingQing.SelectedIndex = -1;
			this.m_cboBingQing.SelectedItem = null;
			this.m_cboBingQing.Size = new System.Drawing.Size(112, 26);
			this.m_cboBingQing.TabIndex = 130;
			this.m_cboBingQing.Tag = "[1][0001][00015][0]";
			this.m_cboBingQing.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboBingQing.TextForeColor = System.Drawing.Color.White;
			// 
			// textBox11
			// 
			this.textBox11.AutoSize = false;
			this.textBox11.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.textBox11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox11.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox11.ForeColor = System.Drawing.Color.White;
			this.textBox11.Location = new System.Drawing.Point(184, 88);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(112, 24);
			this.textBox11.TabIndex = 160;
			this.textBox11.Tag = "[1][0001][00076][0]";
			this.textBox11.Text = "";
			// 
			// textBox10
			// 
			this.textBox10.AutoSize = false;
			this.textBox10.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.textBox10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox10.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox10.ForeColor = System.Drawing.Color.White;
			this.textBox10.Location = new System.Drawing.Point(184, 120);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(112, 24);
			this.textBox10.TabIndex = 210;
			this.textBox10.Tag = "[1][0001][00077][0]";
			this.textBox10.Text = "";
			// 
			// label20
			// 
			this.label20.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label20.ForeColor = System.Drawing.Color.White;
			this.label20.Location = new System.Drawing.Point(8, 124);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(56, 16);
			this.label20.TabIndex = 3067;
			this.label20.Text = "体位";
			// 
			// m_cboTiWei
			// 
			this.m_cboTiWei.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTiWei.BorderColor = System.Drawing.Color.White;
			this.m_cboTiWei.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTiWei.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTiWei.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTiWei.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTiWei.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTiWei.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTiWei.ForeColor = System.Drawing.Color.White;
			this.m_cboTiWei.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTiWei.ListForeColor = System.Drawing.Color.White;
			this.m_cboTiWei.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTiWei.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTiWei.Location = new System.Drawing.Point(70, 120);
			this.m_cboTiWei.Name = "m_cboTiWei";
			this.m_cboTiWei.SelectedIndex = -1;
			this.m_cboTiWei.SelectedItem = null;
			this.m_cboTiWei.Size = new System.Drawing.Size(106, 26);
			this.m_cboTiWei.TabIndex = 200;
			this.m_cboTiWei.Tag = "[1][0001][00077][0]";
			this.m_cboTiWei.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTiWei.TextForeColor = System.Drawing.Color.White;
			// 
			// label19
			// 
			this.label19.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label19.ForeColor = System.Drawing.Color.White;
			this.label19.Location = new System.Drawing.Point(8, 92);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(56, 16);
			this.label19.TabIndex = 3065;
			this.label19.Text = "面容";
			// 
			// m_cboMianRong
			// 
			this.m_cboMianRong.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboMianRong.BorderColor = System.Drawing.Color.White;
			this.m_cboMianRong.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboMianRong.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboMianRong.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboMianRong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboMianRong.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboMianRong.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboMianRong.ForeColor = System.Drawing.Color.White;
			this.m_cboMianRong.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboMianRong.ListForeColor = System.Drawing.Color.White;
			this.m_cboMianRong.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboMianRong.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboMianRong.Location = new System.Drawing.Point(70, 88);
			this.m_cboMianRong.Name = "m_cboMianRong";
			this.m_cboMianRong.SelectedIndex = -1;
			this.m_cboMianRong.SelectedItem = null;
			this.m_cboMianRong.Size = new System.Drawing.Size(106, 26);
			this.m_cboMianRong.TabIndex = 150;
			this.m_cboMianRong.Tag = "[1][0001][00076][0]";
			this.m_cboMianRong.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboMianRong.TextForeColor = System.Drawing.Color.White;
			// 
			// label18
			// 
			this.label18.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label18.ForeColor = System.Drawing.Color.White;
			this.label18.Location = new System.Drawing.Point(704, 24);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(40, 16);
			this.label18.TabIndex = 3063;
			this.label18.Text = "腹围";
			// 
			// textBox8
			// 
			this.textBox8.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox8.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox8.ForeColor = System.Drawing.Color.White;
			this.textBox8.Location = new System.Drawing.Point(752, 24);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(112, 19);
			this.textBox8.TabIndex = 100;
			this.textBox8.Tag = "[0][0001][00009][0]";
			this.textBox8.Text = "";
			// 
			// label17
			// 
			this.label17.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label17.ForeColor = System.Drawing.Color.White;
			this.label17.Location = new System.Drawing.Point(536, 24);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(40, 16);
			this.label17.TabIndex = 3061;
			this.label17.Text = "胸围";
			// 
			// textBox7
			// 
			this.textBox7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox7.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox7.ForeColor = System.Drawing.Color.White;
			this.textBox7.Location = new System.Drawing.Point(584, 24);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(112, 19);
			this.textBox7.TabIndex = 90;
			this.textBox7.Tag = "[0][0001][00008][0]";
			this.textBox7.Text = "";
			// 
			// label16
			// 
			this.label16.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label16.ForeColor = System.Drawing.Color.White;
			this.label16.Location = new System.Drawing.Point(360, 24);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(40, 16);
			this.label16.TabIndex = 3059;
			this.label16.Text = "头围";
			// 
			// textBox6
			// 
			this.textBox6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox6.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox6.ForeColor = System.Drawing.Color.White;
			this.textBox6.Location = new System.Drawing.Point(408, 24);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(120, 19);
			this.textBox6.TabIndex = 80;
			this.textBox6.Tag = "[0][0001][00007][0]";
			this.textBox6.Text = "";
			// 
			// label15
			// 
			this.label15.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label15.ForeColor = System.Drawing.Color.White;
			this.label15.Location = new System.Drawing.Point(184, 24);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(40, 16);
			this.label15.TabIndex = 3057;
			this.label15.Text = "身高";
			// 
			// textBox5
			// 
			this.textBox5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox5.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox5.ForeColor = System.Drawing.Color.White;
			this.textBox5.Location = new System.Drawing.Point(232, 24);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(120, 19);
			this.textBox5.TabIndex = 70;
			this.textBox5.Tag = "[0][0001][00006][0]";
			this.textBox5.Text = "";
			// 
			// label14
			// 
			this.label14.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label14.ForeColor = System.Drawing.Color.White;
			this.label14.Location = new System.Drawing.Point(8, 24);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(56, 16);
			this.label14.TabIndex = 3055;
			this.label14.Text = "体重";
			// 
			// textBox4
			// 
			this.textBox4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox4.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox4.ForeColor = System.Drawing.Color.White;
			this.textBox4.Location = new System.Drawing.Point(72, 24);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(104, 19);
			this.textBox4.TabIndex = 60;
			this.textBox4.Tag = "[0][0001][00005][0]";
			this.textBox4.Text = "";
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label10.ForeColor = System.Drawing.Color.White;
			this.label10.Location = new System.Drawing.Point(504, 128);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 16);
			this.label10.TabIndex = 3053;
			this.label10.Text = "配合检查";
			// 
			// m_cboPeiHeJianCha
			// 
			this.m_cboPeiHeJianCha.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPeiHeJianCha.BorderColor = System.Drawing.Color.White;
			this.m_cboPeiHeJianCha.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPeiHeJianCha.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboPeiHeJianCha.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboPeiHeJianCha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboPeiHeJianCha.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPeiHeJianCha.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPeiHeJianCha.ForeColor = System.Drawing.Color.White;
			this.m_cboPeiHeJianCha.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPeiHeJianCha.ListForeColor = System.Drawing.Color.White;
			this.m_cboPeiHeJianCha.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboPeiHeJianCha.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboPeiHeJianCha.Location = new System.Drawing.Point(584, 120);
			this.m_cboPeiHeJianCha.Name = "m_cboPeiHeJianCha";
			this.m_cboPeiHeJianCha.SelectedIndex = -1;
			this.m_cboPeiHeJianCha.SelectedItem = null;
			this.m_cboPeiHeJianCha.Size = new System.Drawing.Size(112, 26);
			this.m_cboPeiHeJianCha.TabIndex = 230;
			this.m_cboPeiHeJianCha.Tag = "[1][0001][00104][0]";
			this.m_cboPeiHeJianCha.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPeiHeJianCha.TextForeColor = System.Drawing.Color.White;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label9.ForeColor = System.Drawing.Color.White;
			this.label9.Location = new System.Drawing.Point(312, 128);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(40, 16);
			this.label9.TabIndex = 3051;
			this.label9.Text = "步态";
			// 
			// m_cboBuTai
			// 
			this.m_cboBuTai.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboBuTai.BorderColor = System.Drawing.Color.White;
			this.m_cboBuTai.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboBuTai.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboBuTai.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboBuTai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboBuTai.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboBuTai.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboBuTai.ForeColor = System.Drawing.Color.White;
			this.m_cboBuTai.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboBuTai.ListForeColor = System.Drawing.Color.White;
			this.m_cboBuTai.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboBuTai.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboBuTai.Location = new System.Drawing.Point(360, 120);
			this.m_cboBuTai.Name = "m_cboBuTai";
			this.m_cboBuTai.SelectedIndex = -1;
			this.m_cboBuTai.SelectedItem = null;
			this.m_cboBuTai.Size = new System.Drawing.Size(116, 26);
			this.m_cboBuTai.TabIndex = 220;
			this.m_cboBuTai.Tag = "[1][0001][00103][0]";
			this.m_cboBuTai.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboBuTai.TextForeColor = System.Drawing.Color.White;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.ForeColor = System.Drawing.Color.White;
			this.label8.Location = new System.Drawing.Point(312, 96);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 16);
			this.label8.TabIndex = 3049;
			this.label8.Text = "表情";
			// 
			// m_cboBiaoQing
			// 
			this.m_cboBiaoQing.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboBiaoQing.BorderColor = System.Drawing.Color.White;
			this.m_cboBiaoQing.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboBiaoQing.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboBiaoQing.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboBiaoQing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboBiaoQing.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboBiaoQing.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboBiaoQing.ForeColor = System.Drawing.Color.White;
			this.m_cboBiaoQing.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboBiaoQing.ListForeColor = System.Drawing.Color.White;
			this.m_cboBiaoQing.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboBiaoQing.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboBiaoQing.Location = new System.Drawing.Point(360, 88);
			this.m_cboBiaoQing.Name = "m_cboBiaoQing";
			this.m_cboBiaoQing.SelectedIndex = -1;
			this.m_cboBiaoQing.SelectedItem = null;
			this.m_cboBiaoQing.Size = new System.Drawing.Size(116, 26);
			this.m_cboBiaoQing.TabIndex = 170;
			this.m_cboBiaoQing.Tag = "[1][0001][00012][0]";
			this.m_cboBiaoQing.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboBiaoQing.TextForeColor = System.Drawing.Color.White;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label7.ForeColor = System.Drawing.Color.White;
			this.label7.Location = new System.Drawing.Point(704, 96);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 16);
			this.label7.TabIndex = 3047;
			this.label7.Text = "神智";
			// 
			// m_cboShenZhi
			// 
			this.m_cboShenZhi.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboShenZhi.BorderColor = System.Drawing.Color.White;
			this.m_cboShenZhi.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboShenZhi.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboShenZhi.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboShenZhi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboShenZhi.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboShenZhi.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboShenZhi.ForeColor = System.Drawing.Color.White;
			this.m_cboShenZhi.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboShenZhi.ListForeColor = System.Drawing.Color.White;
			this.m_cboShenZhi.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboShenZhi.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboShenZhi.Location = new System.Drawing.Point(752, 88);
			this.m_cboShenZhi.Name = "m_cboShenZhi";
			this.m_cboShenZhi.SelectedIndex = -1;
			this.m_cboShenZhi.SelectedItem = null;
			this.m_cboShenZhi.Size = new System.Drawing.Size(112, 26);
			this.m_cboShenZhi.TabIndex = 190;
			this.m_cboShenZhi.Tag = "[1][0001][00010][0]";
			this.m_cboShenZhi.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboShenZhi.TextForeColor = System.Drawing.Color.White;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.ForeColor = System.Drawing.Color.White;
			this.label6.Location = new System.Drawing.Point(312, 64);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 16);
			this.label6.TabIndex = 3045;
			this.label6.Text = "营养";
			// 
			// m_cboYingYang
			// 
			this.m_cboYingYang.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboYingYang.BorderColor = System.Drawing.Color.White;
			this.m_cboYingYang.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboYingYang.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboYingYang.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboYingYang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboYingYang.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboYingYang.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboYingYang.ForeColor = System.Drawing.Color.White;
			this.m_cboYingYang.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboYingYang.ListForeColor = System.Drawing.Color.White;
			this.m_cboYingYang.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboYingYang.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboYingYang.Location = new System.Drawing.Point(360, 56);
			this.m_cboYingYang.Name = "m_cboYingYang";
			this.m_cboYingYang.SelectedIndex = -1;
			this.m_cboYingYang.SelectedItem = null;
			this.m_cboYingYang.Size = new System.Drawing.Size(116, 26);
			this.m_cboYingYang.TabIndex = 120;
			this.m_cboYingYang.Tag = "[1][0001][00013][0]";
			this.m_cboYingYang.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboYingYang.TextForeColor = System.Drawing.Color.White;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(8, 60);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 16);
			this.label5.TabIndex = 3043;
			this.label5.Text = "发育";
			// 
			// m_cboFaYu
			// 
			this.m_cboFaYu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFaYu.BorderColor = System.Drawing.Color.White;
			this.m_cboFaYu.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFaYu.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboFaYu.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboFaYu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboFaYu.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFaYu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFaYu.ForeColor = System.Drawing.Color.White;
			this.m_cboFaYu.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFaYu.ListForeColor = System.Drawing.Color.White;
			this.m_cboFaYu.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboFaYu.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboFaYu.Location = new System.Drawing.Point(70, 56);
			this.m_cboFaYu.Name = "m_cboFaYu";
			this.m_cboFaYu.SelectedIndex = -1;
			this.m_cboFaYu.SelectedItem = null;
			this.m_cboFaYu.Size = new System.Drawing.Size(106, 26);
			this.m_cboFaYu.TabIndex = 110;
			this.m_cboFaYu.Tag = "[1][0001][00014][0]";
			this.m_cboFaYu.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFaYu.TextForeColor = System.Drawing.Color.White;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(356, 448);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(0, 16);
			this.label3.TabIndex = 3039;
			this.label3.Text = "呼吸";
			this.label3.Visible = false;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(4, 448);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(0, 16);
			this.label2.TabIndex = 3035;
			this.label2.Visible = false;
			// 
			// textBox2
			// 
			this.textBox2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox2.ForeColor = System.Drawing.Color.White;
			this.textBox2.Location = new System.Drawing.Point(404, 448);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(0, 19);
			this.textBox2.TabIndex = 40;
			this.textBox2.Tag = "[0][0001][00002][0]";
			this.textBox2.Text = "";
			this.textBox2.Visible = false;
			// 
			// m_txtTemperature
			// 
			this.m_txtTemperature.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtTemperature.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtTemperature.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTemperature.ForeColor = System.Drawing.Color.White;
			this.m_txtTemperature.Location = new System.Drawing.Point(68, 448);
			this.m_txtTemperature.Name = "m_txtTemperature";
			this.m_txtTemperature.Size = new System.Drawing.Size(0, 19);
			this.m_txtTemperature.TabIndex = 20;
			this.m_txtTemperature.Tag = "[0][0001][00001][0]";
			this.m_txtTemperature.Text = "";
			this.m_txtTemperature.Visible = false;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(180, 448);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 16);
			this.label1.TabIndex = 3037;
			this.label1.Visible = false;
			// 
			// textBox3
			// 
			this.textBox3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox3.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox3.ForeColor = System.Drawing.Color.White;
			this.textBox3.Location = new System.Drawing.Point(580, 448);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(0, 19);
			this.textBox3.TabIndex = 50;
			this.textBox3.Tag = "[0][0001][00004][0]";
			this.textBox3.Text = "";
			this.textBox3.Visible = false;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(532, 448);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(0, 16);
			this.label4.TabIndex = 3041;
			this.label4.Text = "血压";
			this.label4.Visible = false;
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox1.ForeColor = System.Drawing.Color.White;
			this.textBox1.Location = new System.Drawing.Point(228, 448);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(0, 19);
			this.textBox1.TabIndex = 30;
			this.textBox1.Tag = "[0][0001][00003][0]";
			this.textBox1.Text = "";
			this.textBox1.Visible = false;
			// 
			// 头部
			// 
			this.头部.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.头部.Controls.AddRange(new System.Windows.Forms.Control[] {
																			 this.m_grbTouBu});
			this.头部.Location = new System.Drawing.Point(4, 26);
			this.头部.Name = "头部";
			this.头部.Size = new System.Drawing.Size(892, 366);
			this.头部.TabIndex = 7;
			this.头部.Text = "头部";
			// 
			// m_grbTouBu
			// 
			this.m_grbTouBu.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.label13,
																					 this.textBox12,
																					 this.label85,
																					 this.m_cboTouBuShangE,
																					 this.label84,
																					 this.m_cboTouBuFaYin,
																					 this.label83,
																					 this.m_cboTouBuBianTaoTi,
																					 this.label82,
																					 this.label81,
																					 this.m_cboTouBuSheChi,
																					 this.label80,
																					 this.m_cboTouBuShe,
																					 this.label79,
																					 this.m_cboTouBuXiaNianMo,
																					 this.label78,
																					 this.m_txtTouBuYaChi,
																					 this.label77,
																					 this.label76,
																					 this.m_cboTouBuKouZhou,
																					 this.label75,
																					 this.m_cboTouBuChiGen,
																					 this.label74,
																					 this.m_cboTouBuChun,
																					 this.label73,
																					 this.label72,
																					 this.m_txtBiBuFenMiWu,
																					 this.label70,
																					 this.m_cboBiBu,
																					 this.label69,
																					 this.m_cboRuiTu,
																					 this.label67,
																					 this.m_txtErBuFenMiWu,
																					 this.label66,
																					 this.m_cboTouBuErBu,
																					 this.label64,
																					 this.m_cboNeiZiZuiPi,
																					 this.label65,
																					 this.m_txtJieHeMoFenMiWu,
																					 this.label63,
																					 this.label62,
																					 this.m_txtTouBuKuiYang,
																					 this.label61,
																					 this.m_cboTouBuGongMo,
																					 this.label60,
																					 this.m_cboTouBuJieHeMo,
																					 this.label59,
																					 this.m_cboTouBuJiaoMo,
																					 this.label58,
																					 this.m_cboTouBuYanQiu,
																					 this.label57,
																					 this.m_cboTouBuDuiGuangFanYing,
																					 this.label56,
																					 this.label55,
																					 this.m_cboTouBuTongKong,
																					 this.label54,
																					 this.m_cboTouBuTouPi,
																					 this.label53,
																					 this.m_cboTouBuShezhe,
																					 this.label52,
																					 this.label51,
																					 this.m_txtTouBuLongQi,
																					 this.label50,
																					 this.m_cboTouBuTouFa,
																					 this.label49,
																					 this.m_cboTouBuQianLu,
																					 this.label48,
																					 this.m_cboTouBuGuFeng,
																					 this.label47,
																					 this.m_cboTouBuXingTai});
			this.m_grbTouBu.ForeColor = System.Drawing.Color.White;
			this.m_grbTouBu.Location = new System.Drawing.Point(8, 8);
			this.m_grbTouBu.Name = "m_grbTouBu";
			this.m_grbTouBu.Size = new System.Drawing.Size(880, 348);
			this.m_grbTouBu.TabIndex = 481;
			this.m_grbTouBu.TabStop = false;
			this.m_grbTouBu.Text = "头部";
			// 
			// label13
			// 
			this.label13.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label13.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label13.ForeColor = System.Drawing.Color.White;
			this.label13.Location = new System.Drawing.Point(508, 256);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(48, 16);
			this.label13.TabIndex = 3120;
			this.label13.Text = "其他";
			// 
			// textBox12
			// 
			this.textBox12.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.textBox12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox12.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox12.ForeColor = System.Drawing.Color.White;
			this.textBox12.Location = new System.Drawing.Point(588, 256);
			this.textBox12.Multiline = true;
			this.textBox12.Name = "textBox12";
			this.textBox12.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox12.Size = new System.Drawing.Size(280, 84);
			this.textBox12.TabIndex = 3119;
			this.textBox12.Tag = "[0][0004][09999][0]";
			this.textBox12.Text = "";
			// 
			// label85
			// 
			this.label85.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label85.ForeColor = System.Drawing.Color.White;
			this.label85.Location = new System.Drawing.Point(352, 312);
			this.label85.Name = "label85";
			this.label85.Size = new System.Drawing.Size(40, 16);
			this.label85.TabIndex = 3118;
			this.label85.Text = "上腭";
			// 
			// m_cboTouBuShangE
			// 
			this.m_cboTouBuShangE.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuShangE.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuShangE.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuShangE.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuShangE.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuShangE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuShangE.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuShangE.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuShangE.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuShangE.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuShangE.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuShangE.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuShangE.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuShangE.Location = new System.Drawing.Point(400, 308);
			this.m_cboTouBuShangE.Name = "m_cboTouBuShangE";
			this.m_cboTouBuShangE.SelectedIndex = -1;
			this.m_cboTouBuShangE.SelectedItem = null;
			this.m_cboTouBuShangE.Size = new System.Drawing.Size(104, 26);
			this.m_cboTouBuShangE.TabIndex = 790;
			this.m_cboTouBuShangE.Tag = "[1][0004][00052][0]";
			this.m_cboTouBuShangE.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuShangE.TextForeColor = System.Drawing.Color.White;
			// 
			// label84
			// 
			this.label84.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label84.ForeColor = System.Drawing.Color.White;
			this.label84.Location = new System.Drawing.Point(196, 312);
			this.label84.Name = "label84";
			this.label84.Size = new System.Drawing.Size(40, 16);
			this.label84.TabIndex = 3116;
			this.label84.Text = "发音";
			// 
			// m_cboTouBuFaYin
			// 
			this.m_cboTouBuFaYin.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuFaYin.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuFaYin.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuFaYin.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuFaYin.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuFaYin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuFaYin.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuFaYin.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuFaYin.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuFaYin.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuFaYin.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuFaYin.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuFaYin.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuFaYin.Location = new System.Drawing.Point(244, 308);
			this.m_cboTouBuFaYin.Name = "m_cboTouBuFaYin";
			this.m_cboTouBuFaYin.SelectedIndex = -1;
			this.m_cboTouBuFaYin.SelectedItem = null;
			this.m_cboTouBuFaYin.Size = new System.Drawing.Size(100, 26);
			this.m_cboTouBuFaYin.TabIndex = 780;
			this.m_cboTouBuFaYin.Tag = "[1][0004][00051][0]";
			this.m_cboTouBuFaYin.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuFaYin.TextForeColor = System.Drawing.Color.White;
			// 
			// label83
			// 
			this.label83.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label83.ForeColor = System.Drawing.Color.White;
			this.label83.Location = new System.Drawing.Point(8, 312);
			this.label83.Name = "label83";
			this.label83.Size = new System.Drawing.Size(56, 16);
			this.label83.TabIndex = 3114;
			this.label83.Text = "扁桃体";
			// 
			// m_cboTouBuBianTaoTi
			// 
			this.m_cboTouBuBianTaoTi.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuBianTaoTi.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuBianTaoTi.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuBianTaoTi.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuBianTaoTi.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuBianTaoTi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuBianTaoTi.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuBianTaoTi.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuBianTaoTi.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuBianTaoTi.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuBianTaoTi.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuBianTaoTi.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuBianTaoTi.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuBianTaoTi.Location = new System.Drawing.Point(76, 308);
			this.m_cboTouBuBianTaoTi.Name = "m_cboTouBuBianTaoTi";
			this.m_cboTouBuBianTaoTi.SelectedIndex = -1;
			this.m_cboTouBuBianTaoTi.SelectedItem = null;
			this.m_cboTouBuBianTaoTi.Size = new System.Drawing.Size(104, 26);
			this.m_cboTouBuBianTaoTi.TabIndex = 770;
			this.m_cboTouBuBianTaoTi.Tag = "[1][0004][00050][0]";
			this.m_cboTouBuBianTaoTi.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuBianTaoTi.TextForeColor = System.Drawing.Color.White;
			// 
			// label82
			// 
			this.label82.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label82.ForeColor = System.Drawing.Color.White;
			this.label82.Location = new System.Drawing.Point(8, 284);
			this.label82.Name = "label82";
			this.label82.Size = new System.Drawing.Size(56, 16);
			this.label82.TabIndex = 3112;
			this.label82.Text = "咽部：";
			// 
			// label81
			// 
			this.label81.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label81.ForeColor = System.Drawing.Color.White;
			this.label81.Location = new System.Drawing.Point(352, 256);
			this.label81.Name = "label81";
			this.label81.Size = new System.Drawing.Size(40, 16);
			this.label81.TabIndex = 3111;
			this.label81.Text = "舌刺";
			// 
			// m_cboTouBuSheChi
			// 
			this.m_cboTouBuSheChi.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuSheChi.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuSheChi.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuSheChi.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuSheChi.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuSheChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuSheChi.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuSheChi.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuSheChi.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuSheChi.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuSheChi.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuSheChi.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuSheChi.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuSheChi.Location = new System.Drawing.Point(400, 252);
			this.m_cboTouBuSheChi.Name = "m_cboTouBuSheChi";
			this.m_cboTouBuSheChi.SelectedIndex = -1;
			this.m_cboTouBuSheChi.SelectedItem = null;
			this.m_cboTouBuSheChi.Size = new System.Drawing.Size(100, 26);
			this.m_cboTouBuSheChi.TabIndex = 760;
			this.m_cboTouBuSheChi.Tag = "[1][0004][00048][0]";
			this.m_cboTouBuSheChi.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuSheChi.TextForeColor = System.Drawing.Color.White;
			// 
			// label80
			// 
			this.label80.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label80.ForeColor = System.Drawing.Color.White;
			this.label80.Location = new System.Drawing.Point(196, 256);
			this.label80.Name = "label80";
			this.label80.Size = new System.Drawing.Size(16, 16);
			this.label80.TabIndex = 3109;
			this.label80.Text = "舌";
			// 
			// m_cboTouBuShe
			// 
			this.m_cboTouBuShe.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuShe.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuShe.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuShe.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuShe.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuShe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuShe.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuShe.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuShe.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuShe.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuShe.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuShe.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuShe.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuShe.Location = new System.Drawing.Point(244, 252);
			this.m_cboTouBuShe.Name = "m_cboTouBuShe";
			this.m_cboTouBuShe.SelectedIndex = -1;
			this.m_cboTouBuShe.SelectedItem = null;
			this.m_cboTouBuShe.Size = new System.Drawing.Size(100, 26);
			this.m_cboTouBuShe.TabIndex = 750;
			this.m_cboTouBuShe.Tag = "[1][0004][00047][0]";
			this.m_cboTouBuShe.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuShe.TextForeColor = System.Drawing.Color.White;
			// 
			// label79
			// 
			this.label79.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label79.ForeColor = System.Drawing.Color.White;
			this.label79.Location = new System.Drawing.Point(8, 256);
			this.label79.Name = "label79";
			this.label79.Size = new System.Drawing.Size(56, 16);
			this.label79.TabIndex = 3107;
			this.label79.Text = "颊粘膜";
			// 
			// m_cboTouBuXiaNianMo
			// 
			this.m_cboTouBuXiaNianMo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuXiaNianMo.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuXiaNianMo.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuXiaNianMo.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuXiaNianMo.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuXiaNianMo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuXiaNianMo.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuXiaNianMo.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuXiaNianMo.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuXiaNianMo.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuXiaNianMo.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuXiaNianMo.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuXiaNianMo.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuXiaNianMo.Location = new System.Drawing.Point(76, 252);
			this.m_cboTouBuXiaNianMo.Name = "m_cboTouBuXiaNianMo";
			this.m_cboTouBuXiaNianMo.SelectedIndex = -1;
			this.m_cboTouBuXiaNianMo.SelectedItem = null;
			this.m_cboTouBuXiaNianMo.Size = new System.Drawing.Size(104, 26);
			this.m_cboTouBuXiaNianMo.TabIndex = 740;
			this.m_cboTouBuXiaNianMo.Tag = "[1][0004][00046][0]";
			this.m_cboTouBuXiaNianMo.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuXiaNianMo.TextForeColor = System.Drawing.Color.White;
			// 
			// label78
			// 
			this.label78.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label78.ForeColor = System.Drawing.Color.White;
			this.label78.Location = new System.Drawing.Point(720, 220);
			this.label78.Name = "label78";
			this.label78.Size = new System.Drawing.Size(40, 16);
			this.label78.TabIndex = 3105;
			this.label78.Text = "只";
			// 
			// m_txtTouBuYaChi
			// 
			this.m_txtTouBuYaChi.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtTouBuYaChi.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtTouBuYaChi.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTouBuYaChi.ForeColor = System.Drawing.Color.White;
			this.m_txtTouBuYaChi.Location = new System.Drawing.Point(588, 220);
			this.m_txtTouBuYaChi.Name = "m_txtTouBuYaChi";
			this.m_txtTouBuYaChi.Size = new System.Drawing.Size(112, 19);
			this.m_txtTouBuYaChi.TabIndex = 730;
			this.m_txtTouBuYaChi.Tag = "[0][0004][00045][0]";
			this.m_txtTouBuYaChi.Text = "";
			// 
			// label77
			// 
			this.label77.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label77.ForeColor = System.Drawing.Color.White;
			this.label77.Location = new System.Drawing.Point(508, 220);
			this.label77.Name = "label77";
			this.label77.Size = new System.Drawing.Size(40, 16);
			this.label77.TabIndex = 3103;
			this.label77.Text = "牙齿";
			// 
			// label76
			// 
			this.label76.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label76.ForeColor = System.Drawing.Color.White;
			this.label76.Location = new System.Drawing.Point(352, 220);
			this.label76.Name = "label76";
			this.label76.Size = new System.Drawing.Size(40, 16);
			this.label76.TabIndex = 3101;
			this.label76.Text = "口周";
			// 
			// m_cboTouBuKouZhou
			// 
			this.m_cboTouBuKouZhou.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuKouZhou.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuKouZhou.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuKouZhou.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuKouZhou.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuKouZhou.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuKouZhou.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuKouZhou.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuKouZhou.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuKouZhou.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuKouZhou.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuKouZhou.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuKouZhou.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuKouZhou.Location = new System.Drawing.Point(400, 216);
			this.m_cboTouBuKouZhou.Name = "m_cboTouBuKouZhou";
			this.m_cboTouBuKouZhou.SelectedIndex = -1;
			this.m_cboTouBuKouZhou.SelectedItem = null;
			this.m_cboTouBuKouZhou.Size = new System.Drawing.Size(100, 26);
			this.m_cboTouBuKouZhou.TabIndex = 720;
			this.m_cboTouBuKouZhou.Tag = "[1][0004][00044][0]";
			this.m_cboTouBuKouZhou.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuKouZhou.TextForeColor = System.Drawing.Color.White;
			// 
			// label75
			// 
			this.label75.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label75.ForeColor = System.Drawing.Color.White;
			this.label75.Location = new System.Drawing.Point(188, 220);
			this.label75.Name = "label75";
			this.label75.Size = new System.Drawing.Size(48, 16);
			this.label75.TabIndex = 3099;
			this.label75.Text = "齿根";
			// 
			// m_cboTouBuChiGen
			// 
			this.m_cboTouBuChiGen.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuChiGen.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuChiGen.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuChiGen.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuChiGen.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuChiGen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuChiGen.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuChiGen.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuChiGen.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuChiGen.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuChiGen.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuChiGen.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuChiGen.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuChiGen.Location = new System.Drawing.Point(244, 216);
			this.m_cboTouBuChiGen.Name = "m_cboTouBuChiGen";
			this.m_cboTouBuChiGen.SelectedIndex = -1;
			this.m_cboTouBuChiGen.SelectedItem = null;
			this.m_cboTouBuChiGen.Size = new System.Drawing.Size(100, 26);
			this.m_cboTouBuChiGen.TabIndex = 710;
			this.m_cboTouBuChiGen.Tag = "[1][0004][00043][0]";
			this.m_cboTouBuChiGen.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuChiGen.TextForeColor = System.Drawing.Color.White;
			// 
			// label74
			// 
			this.label74.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label74.ForeColor = System.Drawing.Color.White;
			this.label74.Location = new System.Drawing.Point(8, 220);
			this.label74.Name = "label74";
			this.label74.Size = new System.Drawing.Size(36, 16);
			this.label74.TabIndex = 3097;
			this.label74.Text = "唇";
			// 
			// m_cboTouBuChun
			// 
			this.m_cboTouBuChun.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuChun.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuChun.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuChun.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuChun.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuChun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuChun.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuChun.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuChun.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuChun.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuChun.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuChun.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuChun.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuChun.Location = new System.Drawing.Point(76, 216);
			this.m_cboTouBuChun.Name = "m_cboTouBuChun";
			this.m_cboTouBuChun.SelectedIndex = -1;
			this.m_cboTouBuChun.SelectedItem = null;
			this.m_cboTouBuChun.Size = new System.Drawing.Size(104, 26);
			this.m_cboTouBuChun.TabIndex = 700;
			this.m_cboTouBuChun.Tag = "[1][0004][00042][0]";
			this.m_cboTouBuChun.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuChun.TextForeColor = System.Drawing.Color.White;
			// 
			// label73
			// 
			this.label73.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label73.ForeColor = System.Drawing.Color.White;
			this.label73.Location = new System.Drawing.Point(8, 192);
			this.label73.Name = "label73";
			this.label73.Size = new System.Drawing.Size(56, 16);
			this.label73.TabIndex = 3095;
			this.label73.Text = "口腔：";
			// 
			// label72
			// 
			this.label72.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label72.ForeColor = System.Drawing.Color.White;
			this.label72.Location = new System.Drawing.Point(708, 164);
			this.label72.Name = "label72";
			this.label72.Size = new System.Drawing.Size(56, 16);
			this.label72.TabIndex = 3093;
			this.label72.Text = "分泌物";
			// 
			// m_txtBiBuFenMiWu
			// 
			this.m_txtBiBuFenMiWu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtBiBuFenMiWu.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtBiBuFenMiWu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtBiBuFenMiWu.ForeColor = System.Drawing.Color.White;
			this.m_txtBiBuFenMiWu.Location = new System.Drawing.Point(772, 160);
			this.m_txtBiBuFenMiWu.Name = "m_txtBiBuFenMiWu";
			this.m_txtBiBuFenMiWu.Size = new System.Drawing.Size(96, 19);
			this.m_txtBiBuFenMiWu.TabIndex = 690;
			this.m_txtBiBuFenMiWu.Tag = "[1][0004][00041][0]";
			this.m_txtBiBuFenMiWu.Text = "";
			// 
			// label70
			// 
			this.label70.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label70.ForeColor = System.Drawing.Color.White;
			this.label70.Location = new System.Drawing.Point(508, 160);
			this.label70.Name = "label70";
			this.label70.Size = new System.Drawing.Size(40, 16);
			this.label70.TabIndex = 3091;
			this.label70.Text = "鼻部";
			// 
			// m_cboBiBu
			// 
			this.m_cboBiBu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboBiBu.BorderColor = System.Drawing.Color.White;
			this.m_cboBiBu.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboBiBu.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboBiBu.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboBiBu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboBiBu.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboBiBu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboBiBu.ForeColor = System.Drawing.Color.White;
			this.m_cboBiBu.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboBiBu.ListForeColor = System.Drawing.Color.White;
			this.m_cboBiBu.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboBiBu.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboBiBu.Location = new System.Drawing.Point(584, 156);
			this.m_cboBiBu.Name = "m_cboBiBu";
			this.m_cboBiBu.SelectedIndex = -1;
			this.m_cboBiBu.SelectedItem = null;
			this.m_cboBiBu.Size = new System.Drawing.Size(116, 26);
			this.m_cboBiBu.TabIndex = 680;
			this.m_cboBiBu.Tag = "[1][0004][00041][0]";
			this.m_cboBiBu.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboBiBu.TextForeColor = System.Drawing.Color.White;
			// 
			// label69
			// 
			this.label69.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label69.ForeColor = System.Drawing.Color.White;
			this.label69.Location = new System.Drawing.Point(348, 160);
			this.label69.Name = "label69";
			this.label69.Size = new System.Drawing.Size(48, 16);
			this.label69.TabIndex = 3089;
			this.label69.Text = "乳突";
			// 
			// m_cboRuiTu
			// 
			this.m_cboRuiTu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboRuiTu.BorderColor = System.Drawing.Color.White;
			this.m_cboRuiTu.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboRuiTu.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboRuiTu.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboRuiTu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboRuiTu.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboRuiTu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboRuiTu.ForeColor = System.Drawing.Color.White;
			this.m_cboRuiTu.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboRuiTu.ListForeColor = System.Drawing.Color.White;
			this.m_cboRuiTu.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboRuiTu.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboRuiTu.Location = new System.Drawing.Point(400, 156);
			this.m_cboRuiTu.Name = "m_cboRuiTu";
			this.m_cboRuiTu.SelectedIndex = -1;
			this.m_cboRuiTu.SelectedItem = null;
			this.m_cboRuiTu.Size = new System.Drawing.Size(100, 26);
			this.m_cboRuiTu.TabIndex = 670;
			this.m_cboRuiTu.Tag = "[1][0004][00040][0]";
			this.m_cboRuiTu.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboRuiTu.TextForeColor = System.Drawing.Color.White;
			// 
			// label67
			// 
			this.label67.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label67.ForeColor = System.Drawing.Color.White;
			this.label67.Location = new System.Drawing.Point(188, 156);
			this.label67.Name = "label67";
			this.label67.Size = new System.Drawing.Size(56, 16);
			this.label67.TabIndex = 3086;
			this.label67.Text = "分泌物";
			// 
			// m_txtErBuFenMiWu
			// 
			this.m_txtErBuFenMiWu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtErBuFenMiWu.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtErBuFenMiWu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtErBuFenMiWu.ForeColor = System.Drawing.Color.White;
			this.m_txtErBuFenMiWu.Location = new System.Drawing.Point(248, 156);
			this.m_txtErBuFenMiWu.Name = "m_txtErBuFenMiWu";
			this.m_txtErBuFenMiWu.Size = new System.Drawing.Size(96, 19);
			this.m_txtErBuFenMiWu.TabIndex = 660;
			this.m_txtErBuFenMiWu.Tag = "[1][0004][00039][0]";
			this.m_txtErBuFenMiWu.Text = "";
			// 
			// label66
			// 
			this.label66.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label66.ForeColor = System.Drawing.Color.White;
			this.label66.Location = new System.Drawing.Point(4, 152);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(48, 16);
			this.label66.TabIndex = 3084;
			this.label66.Text = "耳部";
			// 
			// m_cboTouBuErBu
			// 
			this.m_cboTouBuErBu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuErBu.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuErBu.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuErBu.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuErBu.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuErBu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuErBu.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuErBu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuErBu.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuErBu.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuErBu.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuErBu.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuErBu.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuErBu.Location = new System.Drawing.Point(76, 148);
			this.m_cboTouBuErBu.Name = "m_cboTouBuErBu";
			this.m_cboTouBuErBu.SelectedIndex = -1;
			this.m_cboTouBuErBu.SelectedItem = null;
			this.m_cboTouBuErBu.Size = new System.Drawing.Size(108, 26);
			this.m_cboTouBuErBu.TabIndex = 650;
			this.m_cboTouBuErBu.Tag = "[1][0004][00039][0]";
			this.m_cboTouBuErBu.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuErBu.TextForeColor = System.Drawing.Color.White;
			// 
			// label64
			// 
			this.label64.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label64.ForeColor = System.Drawing.Color.White;
			this.label64.Location = new System.Drawing.Point(508, 120);
			this.label64.Name = "label64";
			this.label64.Size = new System.Drawing.Size(72, 16);
			this.label64.TabIndex = 3082;
			this.label64.Text = "内眦赘皮";
			// 
			// m_cboNeiZiZuiPi
			// 
			this.m_cboNeiZiZuiPi.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboNeiZiZuiPi.BorderColor = System.Drawing.Color.White;
			this.m_cboNeiZiZuiPi.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboNeiZiZuiPi.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboNeiZiZuiPi.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboNeiZiZuiPi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboNeiZiZuiPi.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboNeiZiZuiPi.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboNeiZiZuiPi.ForeColor = System.Drawing.Color.White;
			this.m_cboNeiZiZuiPi.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboNeiZiZuiPi.ListForeColor = System.Drawing.Color.White;
			this.m_cboNeiZiZuiPi.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboNeiZiZuiPi.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboNeiZiZuiPi.Location = new System.Drawing.Point(584, 116);
			this.m_cboNeiZiZuiPi.Name = "m_cboNeiZiZuiPi";
			this.m_cboNeiZiZuiPi.SelectedIndex = -1;
			this.m_cboNeiZiZuiPi.SelectedItem = null;
			this.m_cboNeiZiZuiPi.Size = new System.Drawing.Size(116, 26);
			this.m_cboNeiZiZuiPi.TabIndex = 640;
			this.m_cboNeiZiZuiPi.Tag = "[1][0004][00038][0]";
			this.m_cboNeiZiZuiPi.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboNeiZiZuiPi.TextForeColor = System.Drawing.Color.White;
			// 
			// label65
			// 
			this.label65.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label65.ForeColor = System.Drawing.Color.White;
			this.label65.Location = new System.Drawing.Point(188, 120);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(56, 16);
			this.label65.TabIndex = 3080;
			this.label65.Text = "分泌物";
			// 
			// m_txtJieHeMoFenMiWu
			// 
			this.m_txtJieHeMoFenMiWu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtJieHeMoFenMiWu.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtJieHeMoFenMiWu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtJieHeMoFenMiWu.ForeColor = System.Drawing.Color.White;
			this.m_txtJieHeMoFenMiWu.Location = new System.Drawing.Point(248, 120);
			this.m_txtJieHeMoFenMiWu.Name = "m_txtJieHeMoFenMiWu";
			this.m_txtJieHeMoFenMiWu.Size = new System.Drawing.Size(96, 19);
			this.m_txtJieHeMoFenMiWu.TabIndex = 620;
			this.m_txtJieHeMoFenMiWu.Tag = "[1][0004][00036][0]";
			this.m_txtJieHeMoFenMiWu.Text = "";
			// 
			// label63
			// 
			this.label63.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label63.ForeColor = System.Drawing.Color.White;
			this.label63.Location = new System.Drawing.Point(508, 88);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(88, 16);
			this.label63.TabIndex = 3078;
			this.label63.Text = "点种处溃疡";
			// 
			// label62
			// 
			this.label62.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label62.ForeColor = System.Drawing.Color.White;
			this.label62.Location = new System.Drawing.Point(352, 88);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(24, 16);
			this.label62.TabIndex = 3077;
			this.label62.Text = "在";
			// 
			// m_txtTouBuKuiYang
			// 
			this.m_txtTouBuKuiYang.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtTouBuKuiYang.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtTouBuKuiYang.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTouBuKuiYang.ForeColor = System.Drawing.Color.White;
			this.m_txtTouBuKuiYang.Location = new System.Drawing.Point(400, 88);
			this.m_txtTouBuKuiYang.Name = "m_txtTouBuKuiYang";
			this.m_txtTouBuKuiYang.TabIndex = 600;
			this.m_txtTouBuKuiYang.Tag = "[1][0004][00035][0]";
			this.m_txtTouBuKuiYang.Text = "";
			// 
			// label61
			// 
			this.label61.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label61.ForeColor = System.Drawing.Color.White;
			this.label61.Location = new System.Drawing.Point(352, 120);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(40, 16);
			this.label61.TabIndex = 3075;
			this.label61.Text = "巩膜";
			// 
			// m_cboTouBuGongMo
			// 
			this.m_cboTouBuGongMo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuGongMo.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuGongMo.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuGongMo.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuGongMo.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuGongMo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuGongMo.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuGongMo.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuGongMo.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuGongMo.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuGongMo.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuGongMo.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuGongMo.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuGongMo.Location = new System.Drawing.Point(400, 116);
			this.m_cboTouBuGongMo.Name = "m_cboTouBuGongMo";
			this.m_cboTouBuGongMo.SelectedIndex = -1;
			this.m_cboTouBuGongMo.SelectedItem = null;
			this.m_cboTouBuGongMo.Size = new System.Drawing.Size(100, 26);
			this.m_cboTouBuGongMo.TabIndex = 630;
			this.m_cboTouBuGongMo.Tag = "[1][0004][00037][0]";
			this.m_cboTouBuGongMo.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuGongMo.TextForeColor = System.Drawing.Color.White;
			// 
			// label60
			// 
			this.label60.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label60.ForeColor = System.Drawing.Color.White;
			this.label60.Location = new System.Drawing.Point(4, 120);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(56, 16);
			this.label60.TabIndex = 3073;
			this.label60.Text = "结合膜";
			// 
			// m_cboTouBuJieHeMo
			// 
			this.m_cboTouBuJieHeMo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuJieHeMo.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuJieHeMo.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuJieHeMo.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuJieHeMo.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuJieHeMo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuJieHeMo.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuJieHeMo.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuJieHeMo.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuJieHeMo.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuJieHeMo.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuJieHeMo.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuJieHeMo.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuJieHeMo.Location = new System.Drawing.Point(76, 116);
			this.m_cboTouBuJieHeMo.Name = "m_cboTouBuJieHeMo";
			this.m_cboTouBuJieHeMo.SelectedIndex = -1;
			this.m_cboTouBuJieHeMo.SelectedItem = null;
			this.m_cboTouBuJieHeMo.Size = new System.Drawing.Size(108, 26);
			this.m_cboTouBuJieHeMo.TabIndex = 610;
			this.m_cboTouBuJieHeMo.Tag = "[1][0004][00036][0]";
			this.m_cboTouBuJieHeMo.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuJieHeMo.TextForeColor = System.Drawing.Color.White;
			// 
			// label59
			// 
			this.label59.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label59.ForeColor = System.Drawing.Color.White;
			this.label59.Location = new System.Drawing.Point(192, 88);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(40, 16);
			this.label59.TabIndex = 3071;
			this.label59.Text = "角膜";
			// 
			// m_cboTouBuJiaoMo
			// 
			this.m_cboTouBuJiaoMo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuJiaoMo.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuJiaoMo.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuJiaoMo.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuJiaoMo.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuJiaoMo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuJiaoMo.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuJiaoMo.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuJiaoMo.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuJiaoMo.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuJiaoMo.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuJiaoMo.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuJiaoMo.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuJiaoMo.Location = new System.Drawing.Point(244, 84);
			this.m_cboTouBuJiaoMo.Name = "m_cboTouBuJiaoMo";
			this.m_cboTouBuJiaoMo.SelectedIndex = -1;
			this.m_cboTouBuJiaoMo.SelectedItem = null;
			this.m_cboTouBuJiaoMo.Size = new System.Drawing.Size(100, 26);
			this.m_cboTouBuJiaoMo.TabIndex = 590;
			this.m_cboTouBuJiaoMo.Tag = "[1][0004][00035][0]";
			this.m_cboTouBuJiaoMo.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuJiaoMo.TextForeColor = System.Drawing.Color.White;
			// 
			// label58
			// 
			this.label58.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label58.ForeColor = System.Drawing.Color.White;
			this.label58.Location = new System.Drawing.Point(508, 56);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(40, 16);
			this.label58.TabIndex = 3069;
			this.label58.Text = "眼球";
			// 
			// m_cboTouBuYanQiu
			// 
			this.m_cboTouBuYanQiu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuYanQiu.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuYanQiu.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuYanQiu.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuYanQiu.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuYanQiu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuYanQiu.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuYanQiu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuYanQiu.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuYanQiu.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuYanQiu.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuYanQiu.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuYanQiu.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuYanQiu.Location = new System.Drawing.Point(584, 52);
			this.m_cboTouBuYanQiu.Name = "m_cboTouBuYanQiu";
			this.m_cboTouBuYanQiu.SelectedIndex = -1;
			this.m_cboTouBuYanQiu.SelectedItem = null;
			this.m_cboTouBuYanQiu.Size = new System.Drawing.Size(116, 26);
			this.m_cboTouBuYanQiu.TabIndex = 580;
			this.m_cboTouBuYanQiu.Tag = "[1][0004][00032][0]";
			this.m_cboTouBuYanQiu.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuYanQiu.TextForeColor = System.Drawing.Color.White;
			// 
			// label57
			// 
			this.label57.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label57.ForeColor = System.Drawing.Color.White;
			this.label57.Location = new System.Drawing.Point(4, 88);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(72, 16);
			this.label57.TabIndex = 3067;
			this.label57.Text = "对光反应";
			// 
			// m_cboTouBuDuiGuangFanYing
			// 
			this.m_cboTouBuDuiGuangFanYing.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuDuiGuangFanYing.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuDuiGuangFanYing.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuDuiGuangFanYing.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuDuiGuangFanYing.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuDuiGuangFanYing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuDuiGuangFanYing.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuDuiGuangFanYing.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuDuiGuangFanYing.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuDuiGuangFanYing.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuDuiGuangFanYing.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuDuiGuangFanYing.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuDuiGuangFanYing.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuDuiGuangFanYing.Location = new System.Drawing.Point(76, 84);
			this.m_cboTouBuDuiGuangFanYing.Name = "m_cboTouBuDuiGuangFanYing";
			this.m_cboTouBuDuiGuangFanYing.SelectedIndex = -1;
			this.m_cboTouBuDuiGuangFanYing.SelectedItem = null;
			this.m_cboTouBuDuiGuangFanYing.Size = new System.Drawing.Size(108, 26);
			this.m_cboTouBuDuiGuangFanYing.TabIndex = 570;
			this.m_cboTouBuDuiGuangFanYing.Tag = "[1][0004][00087][0]";
			this.m_cboTouBuDuiGuangFanYing.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuDuiGuangFanYing.TextForeColor = System.Drawing.Color.White;
			// 
			// label56
			// 
			this.label56.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label56.ForeColor = System.Drawing.Color.White;
			this.label56.Location = new System.Drawing.Point(404, 56);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(56, 16);
			this.label56.TabIndex = 3065;
			this.label56.Text = "眼部：";
			// 
			// label55
			// 
			this.label55.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label55.ForeColor = System.Drawing.Color.White;
			this.label55.Location = new System.Drawing.Point(708, 60);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(40, 16);
			this.label55.TabIndex = 3064;
			this.label55.Text = "瞳孔";
			// 
			// m_cboTouBuTongKong
			// 
			this.m_cboTouBuTongKong.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuTongKong.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuTongKong.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuTongKong.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuTongKong.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuTongKong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuTongKong.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuTongKong.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuTongKong.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuTongKong.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuTongKong.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuTongKong.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuTongKong.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuTongKong.Location = new System.Drawing.Point(768, 52);
			this.m_cboTouBuTongKong.Name = "m_cboTouBuTongKong";
			this.m_cboTouBuTongKong.SelectedIndex = -1;
			this.m_cboTouBuTongKong.SelectedItem = null;
			this.m_cboTouBuTongKong.Size = new System.Drawing.Size(100, 26);
			this.m_cboTouBuTongKong.TabIndex = 560;
			this.m_cboTouBuTongKong.Tag = "[1][0004][00033][0]";
			this.m_cboTouBuTongKong.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuTongKong.TextForeColor = System.Drawing.Color.White;
			// 
			// label54
			// 
			this.label54.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label54.ForeColor = System.Drawing.Color.White;
			this.label54.Location = new System.Drawing.Point(708, 28);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(44, 16);
			this.label54.TabIndex = 3062;
			this.label54.Text = "头皮";
			// 
			// m_cboTouBuTouPi
			// 
			this.m_cboTouBuTouPi.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuTouPi.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuTouPi.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuTouPi.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuTouPi.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuTouPi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuTouPi.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuTouPi.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuTouPi.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuTouPi.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuTouPi.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuTouPi.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuTouPi.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuTouPi.Location = new System.Drawing.Point(768, 20);
			this.m_cboTouBuTouPi.Name = "m_cboTouBuTouPi";
			this.m_cboTouBuTouPi.SelectedIndex = -1;
			this.m_cboTouBuTouPi.SelectedItem = null;
			this.m_cboTouBuTouPi.Size = new System.Drawing.Size(100, 26);
			this.m_cboTouBuTouPi.TabIndex = 530;
			this.m_cboTouBuTouPi.Tag = "[1][0004][00031][0]";
			this.m_cboTouBuTouPi.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuTouPi.TextForeColor = System.Drawing.Color.White;
			// 
			// label53
			// 
			this.label53.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label53.ForeColor = System.Drawing.Color.White;
			this.label53.Location = new System.Drawing.Point(352, 24);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(40, 16);
			this.label53.TabIndex = 3060;
			this.label53.Text = "色泽";
			// 
			// m_cboTouBuShezhe
			// 
			this.m_cboTouBuShezhe.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuShezhe.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuShezhe.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuShezhe.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuShezhe.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuShezhe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuShezhe.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuShezhe.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuShezhe.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuShezhe.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuShezhe.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuShezhe.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuShezhe.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuShezhe.Location = new System.Drawing.Point(400, 20);
			this.m_cboTouBuShezhe.Name = "m_cboTouBuShezhe";
			this.m_cboTouBuShezhe.SelectedIndex = -1;
			this.m_cboTouBuShezhe.SelectedItem = null;
			this.m_cboTouBuShezhe.Size = new System.Drawing.Size(100, 26);
			this.m_cboTouBuShezhe.TabIndex = 510;
			this.m_cboTouBuShezhe.Tag = "[1][0004][00030][0]";
			this.m_cboTouBuShezhe.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuShezhe.TextForeColor = System.Drawing.Color.White;
			// 
			// label52
			// 
			this.label52.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label52.ForeColor = System.Drawing.Color.White;
			this.label52.Location = new System.Drawing.Point(352, 56);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(48, 16);
			this.label52.TabIndex = 3058;
			this.label52.Text = "隆起";
			// 
			// label51
			// 
			this.label51.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label51.ForeColor = System.Drawing.Color.White;
			this.label51.Location = new System.Drawing.Point(192, 56);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(24, 16);
			this.label51.TabIndex = 3057;
			this.label51.Text = "约";
			// 
			// m_txtTouBuLongQi
			// 
			this.m_txtTouBuLongQi.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtTouBuLongQi.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtTouBuLongQi.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTouBuLongQi.ForeColor = System.Drawing.Color.White;
			this.m_txtTouBuLongQi.Location = new System.Drawing.Point(244, 56);
			this.m_txtTouBuLongQi.Name = "m_txtTouBuLongQi";
			this.m_txtTouBuLongQi.TabIndex = 550;
			this.m_txtTouBuLongQi.Tag = "[1][0004][00028][0]";
			this.m_txtTouBuLongQi.Text = "";
			// 
			// label50
			// 
			this.label50.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label50.ForeColor = System.Drawing.Color.White;
			this.label50.Location = new System.Drawing.Point(192, 24);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(44, 16);
			this.label50.TabIndex = 3052;
			this.label50.Text = "头发";
			// 
			// m_cboTouBuTouFa
			// 
			this.m_cboTouBuTouFa.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuTouFa.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuTouFa.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuTouFa.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuTouFa.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuTouFa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuTouFa.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuTouFa.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuTouFa.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuTouFa.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuTouFa.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuTouFa.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuTouFa.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuTouFa.Location = new System.Drawing.Point(244, 20);
			this.m_cboTouBuTouFa.Name = "m_cboTouBuTouFa";
			this.m_cboTouBuTouFa.SelectedIndex = -1;
			this.m_cboTouBuTouFa.SelectedItem = null;
			this.m_cboTouBuTouFa.Size = new System.Drawing.Size(100, 26);
			this.m_cboTouBuTouFa.TabIndex = 500;
			this.m_cboTouBuTouFa.Tag = "[1][0004][00029][0]";
			this.m_cboTouBuTouFa.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuTouFa.TextForeColor = System.Drawing.Color.White;
			// 
			// label49
			// 
			this.label49.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label49.ForeColor = System.Drawing.Color.White;
			this.label49.Location = new System.Drawing.Point(4, 56);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(56, 16);
			this.label49.TabIndex = 3050;
			this.label49.Text = "前卤";
			// 
			// m_cboTouBuQianLu
			// 
			this.m_cboTouBuQianLu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuQianLu.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuQianLu.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuQianLu.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuQianLu.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuQianLu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuQianLu.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuQianLu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuQianLu.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuQianLu.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuQianLu.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuQianLu.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuQianLu.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuQianLu.Location = new System.Drawing.Point(76, 52);
			this.m_cboTouBuQianLu.Name = "m_cboTouBuQianLu";
			this.m_cboTouBuQianLu.SelectedIndex = -1;
			this.m_cboTouBuQianLu.SelectedItem = null;
			this.m_cboTouBuQianLu.Size = new System.Drawing.Size(108, 26);
			this.m_cboTouBuQianLu.TabIndex = 540;
			this.m_cboTouBuQianLu.Tag = "[1][0004][00028][0]";
			this.m_cboTouBuQianLu.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuQianLu.TextForeColor = System.Drawing.Color.White;
			// 
			// label48
			// 
			this.label48.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label48.ForeColor = System.Drawing.Color.White;
			this.label48.Location = new System.Drawing.Point(508, 24);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(56, 16);
			this.label48.TabIndex = 3048;
			this.label48.Text = "骨缝";
			// 
			// m_cboTouBuGuFeng
			// 
			this.m_cboTouBuGuFeng.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuGuFeng.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuGuFeng.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuGuFeng.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuGuFeng.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuGuFeng.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuGuFeng.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuGuFeng.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuGuFeng.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuGuFeng.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuGuFeng.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuGuFeng.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuGuFeng.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuGuFeng.Location = new System.Drawing.Point(584, 20);
			this.m_cboTouBuGuFeng.Name = "m_cboTouBuGuFeng";
			this.m_cboTouBuGuFeng.SelectedIndex = -1;
			this.m_cboTouBuGuFeng.SelectedItem = null;
			this.m_cboTouBuGuFeng.Size = new System.Drawing.Size(116, 26);
			this.m_cboTouBuGuFeng.TabIndex = 520;
			this.m_cboTouBuGuFeng.Tag = "[1][0004][00027][0]";
			this.m_cboTouBuGuFeng.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuGuFeng.TextForeColor = System.Drawing.Color.White;
			// 
			// label47
			// 
			this.label47.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label47.ForeColor = System.Drawing.Color.White;
			this.label47.Location = new System.Drawing.Point(4, 24);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(56, 16);
			this.label47.TabIndex = 3046;
			this.label47.Text = "形态";
			// 
			// m_cboTouBuXingTai
			// 
			this.m_cboTouBuXingTai.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuXingTai.BorderColor = System.Drawing.Color.White;
			this.m_cboTouBuXingTai.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuXingTai.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTouBuXingTai.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTouBuXingTai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTouBuXingTai.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuXingTai.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTouBuXingTai.ForeColor = System.Drawing.Color.White;
			this.m_cboTouBuXingTai.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuXingTai.ListForeColor = System.Drawing.Color.White;
			this.m_cboTouBuXingTai.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTouBuXingTai.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTouBuXingTai.Location = new System.Drawing.Point(76, 20);
			this.m_cboTouBuXingTai.Name = "m_cboTouBuXingTai";
			this.m_cboTouBuXingTai.SelectedIndex = -1;
			this.m_cboTouBuXingTai.SelectedItem = null;
			this.m_cboTouBuXingTai.Size = new System.Drawing.Size(108, 26);
			this.m_cboTouBuXingTai.TabIndex = 490;
			this.m_cboTouBuXingTai.Tag = "[1][0004][00026][0]";
			this.m_cboTouBuXingTai.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTouBuXingTai.TextForeColor = System.Drawing.Color.White;
			// 
			// 皮肤
			// 
			this.皮肤.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.皮肤.Controls.AddRange(new System.Windows.Forms.Control[] {
																			 this.m_grbPiFu});
			this.皮肤.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.皮肤.ForeColor = System.Drawing.Color.White;
			this.皮肤.Location = new System.Drawing.Point(4, 26);
			this.皮肤.Name = "皮肤";
			this.皮肤.Size = new System.Drawing.Size(932, 366);
			this.皮肤.TabIndex = 6;
			this.皮肤.Text = "皮肤";
			// 
			// m_grbPiFu
			// 
			this.m_grbPiFu.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.m_cboPiXiaZhiFang,
																					this.label38,
																					this.label37,
																					this.m_txtPiFuQiTa,
																					this.m_cboZhiZhuZhi,
																					this.label36,
																					this.m_cboGanZhang,
																					this.label35,
																					this.label34,
																					this.m_txtShuiZhong,
																					this.m_cboShuiZhong,
																					this.label33,
																					this.m_cboTanXing,
																					this.label32,
																					this.m_cboXiDu,
																					this.label31,
																					this.m_cboWenDu,
																					this.label30,
																					this.label28,
																					this.m_txtMaoFaFenBu,
																					this.m_cboMaoFaFenBu,
																					this.label29,
																					this.label26,
																					this.m_txtPiXiaChuXue,
																					this.m_cboPiXiaChuXue,
																					this.label27,
																					this.label22,
																					this.m_txtPiZhen,
																					this.m_cboPiZhen,
																					this.label21,
																					this.label11,
																					this.m_cboSeZhe});
			this.m_grbPiFu.ForeColor = System.Drawing.Color.White;
			this.m_grbPiFu.Location = new System.Drawing.Point(8, 12);
			this.m_grbPiFu.Name = "m_grbPiFu";
			this.m_grbPiFu.Size = new System.Drawing.Size(880, 328);
			this.m_grbPiFu.TabIndex = 241;
			this.m_grbPiFu.TabStop = false;
			this.m_grbPiFu.Text = "皮肤";
			// 
			// m_cboPiXiaZhiFang
			// 
			this.m_cboPiXiaZhiFang.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPiXiaZhiFang.BorderColor = System.Drawing.Color.White;
			this.m_cboPiXiaZhiFang.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPiXiaZhiFang.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboPiXiaZhiFang.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboPiXiaZhiFang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboPiXiaZhiFang.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPiXiaZhiFang.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPiXiaZhiFang.ForeColor = System.Drawing.Color.White;
			this.m_cboPiXiaZhiFang.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPiXiaZhiFang.ListForeColor = System.Drawing.Color.White;
			this.m_cboPiXiaZhiFang.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboPiXiaZhiFang.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboPiXiaZhiFang.Location = new System.Drawing.Point(752, 112);
			this.m_cboPiXiaZhiFang.Name = "m_cboPiXiaZhiFang";
			this.m_cboPiXiaZhiFang.SelectedIndex = -1;
			this.m_cboPiXiaZhiFang.SelectedItem = null;
			this.m_cboPiXiaZhiFang.Size = new System.Drawing.Size(116, 26);
			this.m_cboPiXiaZhiFang.TabIndex = 320;
			this.m_cboPiXiaZhiFang.Tag = "[1][0002][00021][0]";
			this.m_cboPiXiaZhiFang.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPiXiaZhiFang.TextForeColor = System.Drawing.Color.White;
			// 
			// label38
			// 
			this.label38.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label38.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label38.ForeColor = System.Drawing.Color.White;
			this.label38.Location = new System.Drawing.Point(672, 120);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(72, 16);
			this.label38.TabIndex = 3084;
			this.label38.Text = "皮下脂肪";
			// 
			// label37
			// 
			this.label37.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label37.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label37.ForeColor = System.Drawing.Color.White;
			this.label37.Location = new System.Drawing.Point(8, 256);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(48, 16);
			this.label37.TabIndex = 3083;
			this.label37.Text = "其他";
			// 
			// m_txtPiFuQiTa
			// 
			this.m_txtPiFuQiTa.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtPiFuQiTa.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtPiFuQiTa.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtPiFuQiTa.ForeColor = System.Drawing.Color.White;
			this.m_txtPiFuQiTa.Location = new System.Drawing.Point(92, 256);
			this.m_txtPiFuQiTa.Multiline = true;
			this.m_txtPiFuQiTa.Name = "m_txtPiFuQiTa";
			this.m_txtPiFuQiTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtPiFuQiTa.Size = new System.Drawing.Size(776, 64);
			this.m_txtPiFuQiTa.TabIndex = 400;
			this.m_txtPiFuQiTa.Tag = "[0][0002][09999][0]";
			this.m_txtPiFuQiTa.Text = "";
			// 
			// m_cboZhiZhuZhi
			// 
			this.m_cboZhiZhuZhi.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboZhiZhuZhi.BorderColor = System.Drawing.Color.White;
			this.m_cboZhiZhuZhi.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboZhiZhuZhi.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboZhiZhuZhi.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboZhiZhuZhi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboZhiZhuZhi.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboZhiZhuZhi.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboZhiZhuZhi.ForeColor = System.Drawing.Color.White;
			this.m_cboZhiZhuZhi.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboZhiZhuZhi.ListForeColor = System.Drawing.Color.White;
			this.m_cboZhiZhuZhi.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboZhiZhuZhi.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboZhiZhuZhi.Location = new System.Drawing.Point(320, 216);
			this.m_cboZhiZhuZhi.Name = "m_cboZhiZhuZhi";
			this.m_cboZhiZhuZhi.SelectedIndex = -1;
			this.m_cboZhiZhuZhi.SelectedItem = null;
			this.m_cboZhiZhuZhi.Size = new System.Drawing.Size(116, 26);
			this.m_cboZhiZhuZhi.TabIndex = 390;
			this.m_cboZhiZhuZhi.Tag = "[1][0002][00085][0]";
			this.m_cboZhiZhuZhi.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboZhiZhuZhi.TextForeColor = System.Drawing.Color.White;
			// 
			// label36
			// 
			this.label36.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label36.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label36.ForeColor = System.Drawing.Color.White;
			this.label36.Location = new System.Drawing.Point(224, 224);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(64, 16);
			this.label36.TabIndex = 3080;
			this.label36.Text = "蜘蛛痣";
			// 
			// m_cboGanZhang
			// 
			this.m_cboGanZhang.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboGanZhang.BorderColor = System.Drawing.Color.White;
			this.m_cboGanZhang.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboGanZhang.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboGanZhang.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboGanZhang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboGanZhang.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboGanZhang.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboGanZhang.ForeColor = System.Drawing.Color.White;
			this.m_cboGanZhang.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboGanZhang.ListForeColor = System.Drawing.Color.White;
			this.m_cboGanZhang.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboGanZhang.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboGanZhang.Location = new System.Drawing.Point(92, 216);
			this.m_cboGanZhang.Name = "m_cboGanZhang";
			this.m_cboGanZhang.SelectedIndex = -1;
			this.m_cboGanZhang.SelectedItem = null;
			this.m_cboGanZhang.Size = new System.Drawing.Size(116, 26);
			this.m_cboGanZhang.TabIndex = 380;
			this.m_cboGanZhang.Tag = "[1][0002][00084][0]";
			this.m_cboGanZhang.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboGanZhang.TextForeColor = System.Drawing.Color.White;
			// 
			// label35
			// 
			this.label35.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label35.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label35.ForeColor = System.Drawing.Color.White;
			this.label35.Location = new System.Drawing.Point(8, 220);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(48, 16);
			this.label35.TabIndex = 3078;
			this.label35.Text = "肝掌";
			// 
			// label34
			// 
			this.label34.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label34.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label34.ForeColor = System.Drawing.Color.White;
			this.label34.Location = new System.Drawing.Point(224, 192);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(88, 16);
			this.label34.TabIndex = 3077;
			this.label34.Text = "部位及程度";
			// 
			// m_txtShuiZhong
			// 
			this.m_txtShuiZhong.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtShuiZhong.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtShuiZhong.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtShuiZhong.ForeColor = System.Drawing.Color.White;
			this.m_txtShuiZhong.Location = new System.Drawing.Point(320, 192);
			this.m_txtShuiZhong.Name = "m_txtShuiZhong";
			this.m_txtShuiZhong.Size = new System.Drawing.Size(336, 19);
			this.m_txtShuiZhong.TabIndex = 370;
			this.m_txtShuiZhong.Tag = "[1][0002][00083][0]";
			this.m_txtShuiZhong.Text = "";
			// 
			// m_cboShuiZhong
			// 
			this.m_cboShuiZhong.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboShuiZhong.BorderColor = System.Drawing.Color.White;
			this.m_cboShuiZhong.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboShuiZhong.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboShuiZhong.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboShuiZhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboShuiZhong.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboShuiZhong.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboShuiZhong.ForeColor = System.Drawing.Color.White;
			this.m_cboShuiZhong.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboShuiZhong.ListForeColor = System.Drawing.Color.White;
			this.m_cboShuiZhong.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboShuiZhong.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboShuiZhong.Location = new System.Drawing.Point(92, 184);
			this.m_cboShuiZhong.Name = "m_cboShuiZhong";
			this.m_cboShuiZhong.SelectedIndex = -1;
			this.m_cboShuiZhong.SelectedItem = null;
			this.m_cboShuiZhong.Size = new System.Drawing.Size(116, 26);
			this.m_cboShuiZhong.TabIndex = 360;
			this.m_cboShuiZhong.Tag = "[1][0002][00083][0]";
			this.m_cboShuiZhong.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboShuiZhong.TextForeColor = System.Drawing.Color.White;
			// 
			// label33
			// 
			this.label33.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label33.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label33.ForeColor = System.Drawing.Color.White;
			this.label33.Location = new System.Drawing.Point(8, 188);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(48, 16);
			this.label33.TabIndex = 3074;
			this.label33.Text = "水肿";
			// 
			// m_cboTanXing
			// 
			this.m_cboTanXing.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTanXing.BorderColor = System.Drawing.Color.White;
			this.m_cboTanXing.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTanXing.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTanXing.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboTanXing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTanXing.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTanXing.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTanXing.ForeColor = System.Drawing.Color.White;
			this.m_cboTanXing.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTanXing.ListForeColor = System.Drawing.Color.White;
			this.m_cboTanXing.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboTanXing.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboTanXing.Location = new System.Drawing.Point(496, 152);
			this.m_cboTanXing.Name = "m_cboTanXing";
			this.m_cboTanXing.SelectedIndex = -1;
			this.m_cboTanXing.SelectedItem = null;
			this.m_cboTanXing.Size = new System.Drawing.Size(116, 26);
			this.m_cboTanXing.TabIndex = 350;
			this.m_cboTanXing.Tag = "[1][0002][00106][0]";
			this.m_cboTanXing.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboTanXing.TextForeColor = System.Drawing.Color.White;
			// 
			// label32
			// 
			this.label32.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label32.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label32.ForeColor = System.Drawing.Color.White;
			this.label32.Location = new System.Drawing.Point(448, 160);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(40, 16);
			this.label32.TabIndex = 3072;
			this.label32.Text = "弹性";
			// 
			// m_cboXiDu
			// 
			this.m_cboXiDu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXiDu.BorderColor = System.Drawing.Color.White;
			this.m_cboXiDu.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXiDu.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboXiDu.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboXiDu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboXiDu.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboXiDu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboXiDu.ForeColor = System.Drawing.Color.White;
			this.m_cboXiDu.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXiDu.ListForeColor = System.Drawing.Color.White;
			this.m_cboXiDu.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboXiDu.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboXiDu.Location = new System.Drawing.Point(320, 152);
			this.m_cboXiDu.Name = "m_cboXiDu";
			this.m_cboXiDu.SelectedIndex = -1;
			this.m_cboXiDu.SelectedItem = null;
			this.m_cboXiDu.Size = new System.Drawing.Size(116, 26);
			this.m_cboXiDu.TabIndex = 340;
			this.m_cboXiDu.Tag = "[1][0002][00105][0]";
			this.m_cboXiDu.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXiDu.TextForeColor = System.Drawing.Color.White;
			// 
			// label31
			// 
			this.label31.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label31.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label31.ForeColor = System.Drawing.Color.White;
			this.label31.Location = new System.Drawing.Point(224, 160);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(48, 16);
			this.label31.TabIndex = 3070;
			this.label31.Text = "湿度";
			// 
			// m_cboWenDu
			// 
			this.m_cboWenDu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboWenDu.BorderColor = System.Drawing.Color.White;
			this.m_cboWenDu.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboWenDu.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboWenDu.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboWenDu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboWenDu.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboWenDu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboWenDu.ForeColor = System.Drawing.Color.White;
			this.m_cboWenDu.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboWenDu.ListForeColor = System.Drawing.Color.White;
			this.m_cboWenDu.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboWenDu.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboWenDu.Location = new System.Drawing.Point(92, 152);
			this.m_cboWenDu.Name = "m_cboWenDu";
			this.m_cboWenDu.SelectedIndex = -1;
			this.m_cboWenDu.SelectedItem = null;
			this.m_cboWenDu.Size = new System.Drawing.Size(116, 26);
			this.m_cboWenDu.TabIndex = 330;
			this.m_cboWenDu.Tag = "[1][0002][00019][0]";
			this.m_cboWenDu.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboWenDu.TextForeColor = System.Drawing.Color.White;
			// 
			// label30
			// 
			this.label30.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label30.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label30.ForeColor = System.Drawing.Color.White;
			this.label30.Location = new System.Drawing.Point(8, 156);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(40, 16);
			this.label30.TabIndex = 3068;
			this.label30.Text = "温度";
			// 
			// label28
			// 
			this.label28.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label28.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label28.ForeColor = System.Drawing.Color.White;
			this.label28.Location = new System.Drawing.Point(224, 120);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(48, 16);
			this.label28.TabIndex = 3067;
			this.label28.Text = "部位";
			// 
			// m_txtMaoFaFenBu
			// 
			this.m_txtMaoFaFenBu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtMaoFaFenBu.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtMaoFaFenBu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtMaoFaFenBu.ForeColor = System.Drawing.Color.White;
			this.m_txtMaoFaFenBu.Location = new System.Drawing.Point(320, 120);
			this.m_txtMaoFaFenBu.Name = "m_txtMaoFaFenBu";
			this.m_txtMaoFaFenBu.Size = new System.Drawing.Size(336, 19);
			this.m_txtMaoFaFenBu.TabIndex = 310;
			this.m_txtMaoFaFenBu.Tag = "[1][0002][00081][0]";
			this.m_txtMaoFaFenBu.Text = "";
			// 
			// m_cboMaoFaFenBu
			// 
			this.m_cboMaoFaFenBu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboMaoFaFenBu.BorderColor = System.Drawing.Color.White;
			this.m_cboMaoFaFenBu.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboMaoFaFenBu.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboMaoFaFenBu.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboMaoFaFenBu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboMaoFaFenBu.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboMaoFaFenBu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboMaoFaFenBu.ForeColor = System.Drawing.Color.White;
			this.m_cboMaoFaFenBu.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboMaoFaFenBu.ListForeColor = System.Drawing.Color.White;
			this.m_cboMaoFaFenBu.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboMaoFaFenBu.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboMaoFaFenBu.Location = new System.Drawing.Point(92, 120);
			this.m_cboMaoFaFenBu.Name = "m_cboMaoFaFenBu";
			this.m_cboMaoFaFenBu.SelectedIndex = -1;
			this.m_cboMaoFaFenBu.SelectedItem = null;
			this.m_cboMaoFaFenBu.Size = new System.Drawing.Size(116, 26);
			this.m_cboMaoFaFenBu.TabIndex = 300;
			this.m_cboMaoFaFenBu.Tag = "[1][0002][00081][0]";
			this.m_cboMaoFaFenBu.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboMaoFaFenBu.TextForeColor = System.Drawing.Color.White;
			// 
			// label29
			// 
			this.label29.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label29.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label29.ForeColor = System.Drawing.Color.White;
			this.label29.Location = new System.Drawing.Point(8, 124);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(72, 16);
			this.label29.TabIndex = 3064;
			this.label29.Text = "毛发分布";
			// 
			// label26
			// 
			this.label26.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label26.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label26.ForeColor = System.Drawing.Color.White;
			this.label26.Location = new System.Drawing.Point(224, 88);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(88, 16);
			this.label26.TabIndex = 3063;
			this.label26.Text = "类型及分布";
			// 
			// m_txtPiXiaChuXue
			// 
			this.m_txtPiXiaChuXue.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtPiXiaChuXue.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtPiXiaChuXue.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtPiXiaChuXue.ForeColor = System.Drawing.Color.White;
			this.m_txtPiXiaChuXue.Location = new System.Drawing.Point(320, 88);
			this.m_txtPiXiaChuXue.Name = "m_txtPiXiaChuXue";
			this.m_txtPiXiaChuXue.Size = new System.Drawing.Size(336, 19);
			this.m_txtPiXiaChuXue.TabIndex = 290;
			this.m_txtPiXiaChuXue.Tag = "[1][0002][00080][0]";
			this.m_txtPiXiaChuXue.Text = "";
			// 
			// m_cboPiXiaChuXue
			// 
			this.m_cboPiXiaChuXue.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPiXiaChuXue.BorderColor = System.Drawing.Color.White;
			this.m_cboPiXiaChuXue.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPiXiaChuXue.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboPiXiaChuXue.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboPiXiaChuXue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboPiXiaChuXue.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPiXiaChuXue.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPiXiaChuXue.ForeColor = System.Drawing.Color.White;
			this.m_cboPiXiaChuXue.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPiXiaChuXue.ListForeColor = System.Drawing.Color.White;
			this.m_cboPiXiaChuXue.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboPiXiaChuXue.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboPiXiaChuXue.Location = new System.Drawing.Point(92, 88);
			this.m_cboPiXiaChuXue.Name = "m_cboPiXiaChuXue";
			this.m_cboPiXiaChuXue.SelectedIndex = -1;
			this.m_cboPiXiaChuXue.SelectedItem = null;
			this.m_cboPiXiaChuXue.Size = new System.Drawing.Size(116, 26);
			this.m_cboPiXiaChuXue.TabIndex = 280;
			this.m_cboPiXiaChuXue.Tag = "[1][0002][00080][0]";
			this.m_cboPiXiaChuXue.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPiXiaChuXue.TextForeColor = System.Drawing.Color.White;
			// 
			// label27
			// 
			this.label27.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label27.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label27.ForeColor = System.Drawing.Color.White;
			this.label27.Location = new System.Drawing.Point(8, 92);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(72, 16);
			this.label27.TabIndex = 3060;
			this.label27.Text = "皮下出血";
			// 
			// label22
			// 
			this.label22.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label22.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label22.ForeColor = System.Drawing.Color.White;
			this.label22.Location = new System.Drawing.Point(224, 56);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(88, 16);
			this.label22.TabIndex = 3059;
			this.label22.Text = "类型及分布";
			// 
			// m_txtPiZhen
			// 
			this.m_txtPiZhen.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtPiZhen.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtPiZhen.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtPiZhen.ForeColor = System.Drawing.Color.White;
			this.m_txtPiZhen.Location = new System.Drawing.Point(320, 56);
			this.m_txtPiZhen.Name = "m_txtPiZhen";
			this.m_txtPiZhen.Size = new System.Drawing.Size(336, 19);
			this.m_txtPiZhen.TabIndex = 270;
			this.m_txtPiZhen.Tag = "[1][0002][00079][0]";
			this.m_txtPiZhen.Text = "";
			// 
			// m_cboPiZhen
			// 
			this.m_cboPiZhen.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPiZhen.BorderColor = System.Drawing.Color.White;
			this.m_cboPiZhen.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPiZhen.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboPiZhen.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboPiZhen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboPiZhen.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPiZhen.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPiZhen.ForeColor = System.Drawing.Color.White;
			this.m_cboPiZhen.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPiZhen.ListForeColor = System.Drawing.Color.White;
			this.m_cboPiZhen.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboPiZhen.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboPiZhen.Location = new System.Drawing.Point(92, 56);
			this.m_cboPiZhen.Name = "m_cboPiZhen";
			this.m_cboPiZhen.SelectedIndex = -1;
			this.m_cboPiZhen.SelectedItem = null;
			this.m_cboPiZhen.Size = new System.Drawing.Size(116, 26);
			this.m_cboPiZhen.TabIndex = 260;
			this.m_cboPiZhen.Tag = "[1][0002][00079][0]";
			this.m_cboPiZhen.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPiZhen.TextForeColor = System.Drawing.Color.White;
			// 
			// label21
			// 
			this.label21.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label21.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label21.ForeColor = System.Drawing.Color.White;
			this.label21.Location = new System.Drawing.Point(8, 60);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(48, 16);
			this.label21.TabIndex = 3056;
			this.label21.Text = "皮疹";
			// 
			// label11
			// 
			this.label11.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label11.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label11.ForeColor = System.Drawing.Color.White;
			this.label11.Location = new System.Drawing.Point(8, 28);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 16);
			this.label11.TabIndex = 3051;
			this.label11.Text = "色泽";
			// 
			// m_cboSeZhe
			// 
			this.m_cboSeZhe.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboSeZhe.BorderColor = System.Drawing.Color.White;
			this.m_cboSeZhe.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboSeZhe.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboSeZhe.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboSeZhe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboSeZhe.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboSeZhe.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboSeZhe.ForeColor = System.Drawing.Color.White;
			this.m_cboSeZhe.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboSeZhe.ListForeColor = System.Drawing.Color.White;
			this.m_cboSeZhe.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboSeZhe.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboSeZhe.Location = new System.Drawing.Point(92, 24);
			this.m_cboSeZhe.Name = "m_cboSeZhe";
			this.m_cboSeZhe.SelectedIndex = -1;
			this.m_cboSeZhe.SelectedItem = null;
			this.m_cboSeZhe.Size = new System.Drawing.Size(116, 26);
			this.m_cboSeZhe.TabIndex = 250;
			this.m_cboSeZhe.Tag = "[1][0002][00018][0]";
			this.m_cboSeZhe.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboSeZhe.TextForeColor = System.Drawing.Color.White;
			// 
			// 淋巴腺
			// 
			this.淋巴腺.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.淋巴腺.Controls.AddRange(new System.Windows.Forms.Control[] {
																			  this.m_grbLinBaXian});
			this.淋巴腺.Location = new System.Drawing.Point(4, 26);
			this.淋巴腺.Name = "淋巴腺";
			this.淋巴腺.Size = new System.Drawing.Size(932, 366);
			this.淋巴腺.TabIndex = 1;
			this.淋巴腺.Text = "淋巴腺";
			this.淋巴腺.Visible = false;
			// 
			// m_grbLinBaXian
			// 
			this.m_grbLinBaXian.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.label68,
																						 this.textBox13,
																						 this.label46,
																						 this.m_cboLinBaXingZhuang,
																						 this.label45,
																						 this.label44,
																						 this.m_txtLinBaDaXiao,
																						 this.m_cboLinBaDaXiao,
																						 this.label43,
																						 this.m_cboLinBaFuGuGou,
																						 this.label42,
																						 this.m_cboLinBoYeWo,
																						 this.label41,
																						 this.m_cboLinBaJing,
																						 this.label40,
																						 this.label39});
			this.m_grbLinBaXian.ForeColor = System.Drawing.Color.White;
			this.m_grbLinBaXian.Location = new System.Drawing.Point(8, 8);
			this.m_grbLinBaXian.Name = "m_grbLinBaXian";
			this.m_grbLinBaXian.Size = new System.Drawing.Size(880, 196);
			this.m_grbLinBaXian.TabIndex = 410;
			this.m_grbLinBaXian.TabStop = false;
			this.m_grbLinBaXian.Text = "淋巴腺";
			this.m_grbLinBaXian.Enter += new System.EventHandler(this.m_grbLinBaXian_Enter);
			// 
			// label68
			// 
			this.label68.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label68.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label68.ForeColor = System.Drawing.Color.White;
			this.label68.Location = new System.Drawing.Point(8, 124);
			this.label68.Name = "label68";
			this.label68.Size = new System.Drawing.Size(48, 16);
			this.label68.TabIndex = 3099;
			this.label68.Text = "其他";
			// 
			// textBox13
			// 
			this.textBox13.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.textBox13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox13.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox13.ForeColor = System.Drawing.Color.White;
			this.textBox13.Location = new System.Drawing.Point(72, 124);
			this.textBox13.Multiline = true;
			this.textBox13.Name = "textBox13";
			this.textBox13.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox13.Size = new System.Drawing.Size(776, 64);
			this.textBox13.TabIndex = 3098;
			this.textBox13.Tag = "[0][0003][09999][0]";
			this.textBox13.Text = "";
			// 
			// label46
			// 
			this.label46.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label46.ForeColor = System.Drawing.Color.White;
			this.label46.Location = new System.Drawing.Point(472, 64);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(48, 16);
			this.label46.TabIndex = 3097;
			this.label46.Text = "大小";
			// 
			// m_cboLinBaXingZhuang
			// 
			this.m_cboLinBaXingZhuang.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinBaXingZhuang.BorderColor = System.Drawing.Color.White;
			this.m_cboLinBaXingZhuang.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinBaXingZhuang.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboLinBaXingZhuang.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboLinBaXingZhuang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboLinBaXingZhuang.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboLinBaXingZhuang.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboLinBaXingZhuang.ForeColor = System.Drawing.Color.White;
			this.m_cboLinBaXingZhuang.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinBaXingZhuang.ListForeColor = System.Drawing.Color.White;
			this.m_cboLinBaXingZhuang.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboLinBaXingZhuang.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboLinBaXingZhuang.Location = new System.Drawing.Point(68, 86);
			this.m_cboLinBaXingZhuang.Name = "m_cboLinBaXingZhuang";
			this.m_cboLinBaXingZhuang.SelectedIndex = -1;
			this.m_cboLinBaXingZhuang.SelectedItem = null;
			this.m_cboLinBaXingZhuang.Size = new System.Drawing.Size(116, 26);
			this.m_cboLinBaXingZhuang.TabIndex = 470;
			this.m_cboLinBaXingZhuang.Tag = "[1][0003][00025][0]";
			this.m_cboLinBaXingZhuang.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinBaXingZhuang.TextForeColor = System.Drawing.Color.White;
			// 
			// label45
			// 
			this.label45.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label45.ForeColor = System.Drawing.Color.White;
			this.label45.Location = new System.Drawing.Point(8, 90);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(44, 16);
			this.label45.TabIndex = 3095;
			this.label45.Text = "性状";
			// 
			// label44
			// 
			this.label44.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label44.ForeColor = System.Drawing.Color.White;
			this.label44.Location = new System.Drawing.Point(196, 64);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(32, 16);
			this.label44.TabIndex = 3094;
			this.label44.Text = "如";
			// 
			// m_txtLinBaDaXiao
			// 
			this.m_txtLinBaDaXiao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtLinBaDaXiao.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtLinBaDaXiao.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtLinBaDaXiao.ForeColor = System.Drawing.Color.White;
			this.m_txtLinBaDaXiao.Location = new System.Drawing.Point(245, 64);
			this.m_txtLinBaDaXiao.Name = "m_txtLinBaDaXiao";
			this.m_txtLinBaDaXiao.Size = new System.Drawing.Size(219, 19);
			this.m_txtLinBaDaXiao.TabIndex = 460;
			this.m_txtLinBaDaXiao.Tag = "[1][0003][00024][0]";
			this.m_txtLinBaDaXiao.Text = "";
			// 
			// m_cboLinBaDaXiao
			// 
			this.m_cboLinBaDaXiao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinBaDaXiao.BorderColor = System.Drawing.Color.White;
			this.m_cboLinBaDaXiao.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinBaDaXiao.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboLinBaDaXiao.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboLinBaDaXiao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboLinBaDaXiao.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboLinBaDaXiao.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboLinBaDaXiao.ForeColor = System.Drawing.Color.White;
			this.m_cboLinBaDaXiao.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinBaDaXiao.ListForeColor = System.Drawing.Color.White;
			this.m_cboLinBaDaXiao.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboLinBaDaXiao.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboLinBaDaXiao.Location = new System.Drawing.Point(68, 56);
			this.m_cboLinBaDaXiao.Name = "m_cboLinBaDaXiao";
			this.m_cboLinBaDaXiao.SelectedIndex = -1;
			this.m_cboLinBaDaXiao.SelectedItem = null;
			this.m_cboLinBaDaXiao.Size = new System.Drawing.Size(116, 26);
			this.m_cboLinBaDaXiao.TabIndex = 450;
			this.m_cboLinBaDaXiao.Tag = "[1][0003][00024][0]";
			this.m_cboLinBaDaXiao.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinBaDaXiao.TextForeColor = System.Drawing.Color.White;
			// 
			// label43
			// 
			this.label43.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label43.ForeColor = System.Drawing.Color.White;
			this.label43.Location = new System.Drawing.Point(8, 60);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(44, 16);
			this.label43.TabIndex = 3091;
			this.label43.Text = "大小";
			// 
			// m_cboLinBaFuGuGou
			// 
			this.m_cboLinBaFuGuGou.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinBaFuGuGou.BorderColor = System.Drawing.Color.White;
			this.m_cboLinBaFuGuGou.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinBaFuGuGou.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboLinBaFuGuGou.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboLinBaFuGuGou.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboLinBaFuGuGou.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboLinBaFuGuGou.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboLinBaFuGuGou.ForeColor = System.Drawing.Color.White;
			this.m_cboLinBaFuGuGou.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinBaFuGuGou.ListForeColor = System.Drawing.Color.White;
			this.m_cboLinBaFuGuGou.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboLinBaFuGuGou.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboLinBaFuGuGou.Location = new System.Drawing.Point(392, 24);
			this.m_cboLinBaFuGuGou.Name = "m_cboLinBaFuGuGou";
			this.m_cboLinBaFuGuGou.SelectedIndex = -1;
			this.m_cboLinBaFuGuGou.SelectedItem = null;
			this.m_cboLinBaFuGuGou.Size = new System.Drawing.Size(72, 26);
			this.m_cboLinBaFuGuGou.TabIndex = 440;
			this.m_cboLinBaFuGuGou.Tag = "[1][0003][00109][0]";
			this.m_cboLinBaFuGuGou.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinBaFuGuGou.TextForeColor = System.Drawing.Color.White;
			// 
			// label42
			// 
			this.label42.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label42.ForeColor = System.Drawing.Color.White;
			this.label42.Location = new System.Drawing.Point(328, 32);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(56, 16);
			this.label42.TabIndex = 3089;
			this.label42.Text = "腹股沟";
			// 
			// m_cboLinBoYeWo
			// 
			this.m_cboLinBoYeWo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinBoYeWo.BorderColor = System.Drawing.Color.White;
			this.m_cboLinBoYeWo.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinBoYeWo.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboLinBoYeWo.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboLinBoYeWo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboLinBoYeWo.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboLinBoYeWo.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboLinBoYeWo.ForeColor = System.Drawing.Color.White;
			this.m_cboLinBoYeWo.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinBoYeWo.ListForeColor = System.Drawing.Color.White;
			this.m_cboLinBoYeWo.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboLinBoYeWo.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboLinBoYeWo.Location = new System.Drawing.Point(244, 24);
			this.m_cboLinBoYeWo.Name = "m_cboLinBoYeWo";
			this.m_cboLinBoYeWo.SelectedIndex = -1;
			this.m_cboLinBoYeWo.SelectedItem = null;
			this.m_cboLinBoYeWo.Size = new System.Drawing.Size(72, 26);
			this.m_cboLinBoYeWo.TabIndex = 430;
			this.m_cboLinBoYeWo.Tag = "[1][0003][00108][0]";
			this.m_cboLinBoYeWo.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinBoYeWo.TextForeColor = System.Drawing.Color.White;
			// 
			// label41
			// 
			this.label41.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label41.ForeColor = System.Drawing.Color.White;
			this.label41.Location = new System.Drawing.Point(196, 32);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(40, 16);
			this.label41.TabIndex = 3087;
			this.label41.Text = "腋窝";
			// 
			// m_cboLinBaJing
			// 
			this.m_cboLinBaJing.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinBaJing.BorderColor = System.Drawing.Color.White;
			this.m_cboLinBaJing.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinBaJing.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboLinBaJing.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboLinBaJing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboLinBaJing.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboLinBaJing.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboLinBaJing.ForeColor = System.Drawing.Color.White;
			this.m_cboLinBaJing.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinBaJing.ListForeColor = System.Drawing.Color.White;
			this.m_cboLinBaJing.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboLinBaJing.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboLinBaJing.Location = new System.Drawing.Point(100, 24);
			this.m_cboLinBaJing.Name = "m_cboLinBaJing";
			this.m_cboLinBaJing.SelectedIndex = -1;
			this.m_cboLinBaJing.SelectedItem = null;
			this.m_cboLinBaJing.Size = new System.Drawing.Size(84, 26);
			this.m_cboLinBaJing.TabIndex = 420;
			this.m_cboLinBaJing.Tag = "[1][0003][00107][0]";
			this.m_cboLinBaJing.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinBaJing.TextForeColor = System.Drawing.Color.White;
			// 
			// label40
			// 
			this.label40.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label40.ForeColor = System.Drawing.Color.White;
			this.label40.Location = new System.Drawing.Point(68, 32);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(32, 16);
			this.label40.TabIndex = 3085;
			this.label40.Text = "颈";
			// 
			// label39
			// 
			this.label39.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label39.ForeColor = System.Drawing.Color.White;
			this.label39.Location = new System.Drawing.Point(8, 32);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(44, 16);
			this.label39.TabIndex = 3084;
			this.label39.Text = "部位";
			// 
			// 颈部
			// 
			this.颈部.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.颈部.Controls.AddRange(new System.Windows.Forms.Control[] {
																			 this.m_grbJingBu});
			this.颈部.Location = new System.Drawing.Point(4, 26);
			this.颈部.Name = "颈部";
			this.颈部.Size = new System.Drawing.Size(932, 366);
			this.颈部.TabIndex = 2;
			this.颈部.Text = "颈部";
			this.颈部.Visible = false;
			// 
			// m_grbJingBu
			// 
			this.m_grbJingBu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_grbJingBu.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.label71,
																					  this.textBox14,
																					  this.label94,
																					  this.label93,
																					  this.m_txtJiaZhuangXian,
																					  this.label92,
																					  this.m_cborJingBuJiaZhuangXian,
																					  this.label91,
																					  this.m_txtJingBuHuiLiuZheng,
																					  this.label90,
																					  this.m_cboJingBuQiGuan,
																					  this.label89,
																					  this.m_cboJingBuJingJingMai,
																					  this.label88,
																					  this.m_cboJingBuJingDongLi,
																					  this.label87,
																					  this.m_cboJIngBuDiKangLi,
																					  this.label86,
																					  this.m_cboJingBuJingBu});
			this.m_grbJingBu.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_grbJingBu.ForeColor = System.Drawing.Color.White;
			this.m_grbJingBu.Location = new System.Drawing.Point(0, 8);
			this.m_grbJingBu.Name = "m_grbJingBu";
			this.m_grbJingBu.Size = new System.Drawing.Size(864, 236);
			this.m_grbJingBu.TabIndex = 800;
			this.m_grbJingBu.TabStop = false;
			this.m_grbJingBu.Text = "颈部";
			// 
			// label71
			// 
			this.label71.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label71.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label71.ForeColor = System.Drawing.Color.White;
			this.label71.Location = new System.Drawing.Point(16, 160);
			this.label71.Name = "label71";
			this.label71.Size = new System.Drawing.Size(48, 16);
			this.label71.TabIndex = 3133;
			this.label71.Text = "其他";
			// 
			// textBox14
			// 
			this.textBox14.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.textBox14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox14.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox14.ForeColor = System.Drawing.Color.White;
			this.textBox14.Location = new System.Drawing.Point(80, 160);
			this.textBox14.Multiline = true;
			this.textBox14.Name = "textBox14";
			this.textBox14.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox14.Size = new System.Drawing.Size(776, 64);
			this.textBox14.TabIndex = 3132;
			this.textBox14.Tag = "[0][0005][09999][0]";
			this.textBox14.Text = "";
			// 
			// label94
			// 
			this.label94.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label94.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label94.ForeColor = System.Drawing.Color.White;
			this.label94.Location = new System.Drawing.Point(368, 112);
			this.label94.Name = "label94";
			this.label94.Size = new System.Drawing.Size(56, 16);
			this.label94.TabIndex = 3131;
			this.label94.Text = "大小";
			// 
			// label93
			// 
			this.label93.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label93.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label93.ForeColor = System.Drawing.Color.White;
			this.label93.Location = new System.Drawing.Point(216, 112);
			this.label93.Name = "label93";
			this.label93.Size = new System.Drawing.Size(32, 16);
			this.label93.TabIndex = 3130;
			this.label93.Text = "如";
			// 
			// m_txtJiaZhuangXian
			// 
			this.m_txtJiaZhuangXian.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtJiaZhuangXian.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtJiaZhuangXian.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtJiaZhuangXian.ForeColor = System.Drawing.Color.White;
			this.m_txtJiaZhuangXian.Location = new System.Drawing.Point(280, 112);
			this.m_txtJiaZhuangXian.Name = "m_txtJiaZhuangXian";
			this.m_txtJiaZhuangXian.Size = new System.Drawing.Size(80, 19);
			this.m_txtJiaZhuangXian.TabIndex = 880;
			this.m_txtJiaZhuangXian.Tag = "[1][0005][00093][0]";
			this.m_txtJiaZhuangXian.Text = "";
			// 
			// label92
			// 
			this.label92.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label92.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label92.ForeColor = System.Drawing.Color.White;
			this.label92.Location = new System.Drawing.Point(16, 112);
			this.label92.Name = "label92";
			this.label92.Size = new System.Drawing.Size(56, 16);
			this.label92.TabIndex = 3128;
			this.label92.Text = "甲状腺";
			// 
			// m_cborJingBuJiaZhuangXian
			// 
			this.m_cborJingBuJiaZhuangXian.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cborJingBuJiaZhuangXian.BorderColor = System.Drawing.Color.White;
			this.m_cborJingBuJiaZhuangXian.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cborJingBuJiaZhuangXian.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cborJingBuJiaZhuangXian.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cborJingBuJiaZhuangXian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cborJingBuJiaZhuangXian.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cborJingBuJiaZhuangXian.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cborJingBuJiaZhuangXian.ForeColor = System.Drawing.Color.White;
			this.m_cborJingBuJiaZhuangXian.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cborJingBuJiaZhuangXian.ListForeColor = System.Drawing.Color.White;
			this.m_cborJingBuJiaZhuangXian.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cborJingBuJiaZhuangXian.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cborJingBuJiaZhuangXian.Location = new System.Drawing.Point(80, 108);
			this.m_cborJingBuJiaZhuangXian.Name = "m_cborJingBuJiaZhuangXian";
			this.m_cborJingBuJiaZhuangXian.SelectedIndex = -1;
			this.m_cborJingBuJiaZhuangXian.SelectedItem = null;
			this.m_cborJingBuJiaZhuangXian.Size = new System.Drawing.Size(116, 26);
			this.m_cborJingBuJiaZhuangXian.TabIndex = 870;
			this.m_cborJingBuJiaZhuangXian.Tag = "[1][0005][00093][0]";
			this.m_cborJingBuJiaZhuangXian.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cborJingBuJiaZhuangXian.TextForeColor = System.Drawing.Color.White;
			// 
			// label91
			// 
			this.label91.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label91.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label91.ForeColor = System.Drawing.Color.White;
			this.label91.Location = new System.Drawing.Point(216, 72);
			this.label91.Name = "label91";
			this.label91.Size = new System.Drawing.Size(128, 16);
			this.label91.TabIndex = 3126;
			this.label91.Text = "肝颈静脉回流征";
			// 
			// m_txtJingBuHuiLiuZheng
			// 
			this.m_txtJingBuHuiLiuZheng.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtJingBuHuiLiuZheng.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtJingBuHuiLiuZheng.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtJingBuHuiLiuZheng.ForeColor = System.Drawing.Color.White;
			this.m_txtJingBuHuiLiuZheng.Location = new System.Drawing.Point(360, 72);
			this.m_txtJingBuHuiLiuZheng.Name = "m_txtJingBuHuiLiuZheng";
			this.m_txtJingBuHuiLiuZheng.Size = new System.Drawing.Size(344, 19);
			this.m_txtJingBuHuiLiuZheng.TabIndex = 860;
			this.m_txtJingBuHuiLiuZheng.Tag = "[0][0005][00111][0]";
			this.m_txtJingBuHuiLiuZheng.Text = "";
			// 
			// label90
			// 
			this.label90.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label90.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label90.ForeColor = System.Drawing.Color.White;
			this.label90.Location = new System.Drawing.Point(16, 72);
			this.label90.Name = "label90";
			this.label90.Size = new System.Drawing.Size(56, 16);
			this.label90.TabIndex = 3124;
			this.label90.Text = "气管";
			// 
			// m_cboJingBuQiGuan
			// 
			this.m_cboJingBuQiGuan.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJingBuQiGuan.BorderColor = System.Drawing.Color.White;
			this.m_cboJingBuQiGuan.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJingBuQiGuan.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboJingBuQiGuan.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboJingBuQiGuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboJingBuQiGuan.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboJingBuQiGuan.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboJingBuQiGuan.ForeColor = System.Drawing.Color.White;
			this.m_cboJingBuQiGuan.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJingBuQiGuan.ListForeColor = System.Drawing.Color.White;
			this.m_cboJingBuQiGuan.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboJingBuQiGuan.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboJingBuQiGuan.Location = new System.Drawing.Point(80, 68);
			this.m_cboJingBuQiGuan.Name = "m_cboJingBuQiGuan";
			this.m_cboJingBuQiGuan.SelectedIndex = -1;
			this.m_cboJingBuQiGuan.SelectedItem = null;
			this.m_cboJingBuQiGuan.Size = new System.Drawing.Size(116, 26);
			this.m_cboJingBuQiGuan.TabIndex = 850;
			this.m_cboJingBuQiGuan.Tag = "[1][0005][00092][0]";
			this.m_cboJingBuQiGuan.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJingBuQiGuan.TextForeColor = System.Drawing.Color.White;
			// 
			// label89
			// 
			this.label89.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label89.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label89.ForeColor = System.Drawing.Color.White;
			this.label89.Location = new System.Drawing.Point(640, 32);
			this.label89.Name = "label89";
			this.label89.Size = new System.Drawing.Size(56, 16);
			this.label89.TabIndex = 3122;
			this.label89.Text = "颈静脉";
			// 
			// m_cboJingBuJingJingMai
			// 
			this.m_cboJingBuJingJingMai.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJingBuJingJingMai.BorderColor = System.Drawing.Color.White;
			this.m_cboJingBuJingJingMai.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJingBuJingJingMai.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboJingBuJingJingMai.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboJingBuJingJingMai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboJingBuJingJingMai.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboJingBuJingJingMai.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboJingBuJingJingMai.ForeColor = System.Drawing.Color.White;
			this.m_cboJingBuJingJingMai.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJingBuJingJingMai.ListForeColor = System.Drawing.Color.White;
			this.m_cboJingBuJingJingMai.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboJingBuJingJingMai.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboJingBuJingJingMai.Location = new System.Drawing.Point(704, 28);
			this.m_cboJingBuJingJingMai.Name = "m_cboJingBuJingJingMai";
			this.m_cboJingBuJingJingMai.SelectedIndex = -1;
			this.m_cboJingBuJingJingMai.SelectedItem = null;
			this.m_cboJingBuJingJingMai.Size = new System.Drawing.Size(116, 26);
			this.m_cboJingBuJingJingMai.TabIndex = 840;
			this.m_cboJingBuJingJingMai.Tag = "[1][0005][00091][0]";
			this.m_cboJingBuJingJingMai.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJingBuJingJingMai.TextForeColor = System.Drawing.Color.White;
			// 
			// label88
			// 
			this.label88.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label88.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label88.ForeColor = System.Drawing.Color.White;
			this.label88.Location = new System.Drawing.Point(424, 32);
			this.label88.Name = "label88";
			this.label88.Size = new System.Drawing.Size(56, 16);
			this.label88.TabIndex = 3120;
			this.label88.Text = "颈动脉";
			// 
			// m_cboJingBuJingDongLi
			// 
			this.m_cboJingBuJingDongLi.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJingBuJingDongLi.BorderColor = System.Drawing.Color.White;
			this.m_cboJingBuJingDongLi.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJingBuJingDongLi.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboJingBuJingDongLi.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboJingBuJingDongLi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboJingBuJingDongLi.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboJingBuJingDongLi.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboJingBuJingDongLi.ForeColor = System.Drawing.Color.White;
			this.m_cboJingBuJingDongLi.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJingBuJingDongLi.ListForeColor = System.Drawing.Color.White;
			this.m_cboJingBuJingDongLi.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboJingBuJingDongLi.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboJingBuJingDongLi.Location = new System.Drawing.Point(488, 28);
			this.m_cboJingBuJingDongLi.Name = "m_cboJingBuJingDongLi";
			this.m_cboJingBuJingDongLi.SelectedIndex = -1;
			this.m_cboJingBuJingDongLi.SelectedItem = null;
			this.m_cboJingBuJingDongLi.Size = new System.Drawing.Size(116, 26);
			this.m_cboJingBuJingDongLi.TabIndex = 830;
			this.m_cboJingBuJingDongLi.Tag = "[1][0005][00090][0]";
			this.m_cboJingBuJingDongLi.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJingBuJingDongLi.TextForeColor = System.Drawing.Color.White;
			// 
			// label87
			// 
			this.label87.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label87.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label87.ForeColor = System.Drawing.Color.White;
			this.label87.Location = new System.Drawing.Point(216, 32);
			this.label87.Name = "label87";
			this.label87.Size = new System.Drawing.Size(56, 16);
			this.label87.TabIndex = 3118;
			this.label87.Text = "抵抗感";
			// 
			// m_cboJIngBuDiKangLi
			// 
			this.m_cboJIngBuDiKangLi.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJIngBuDiKangLi.BorderColor = System.Drawing.Color.White;
			this.m_cboJIngBuDiKangLi.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJIngBuDiKangLi.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboJIngBuDiKangLi.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboJIngBuDiKangLi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboJIngBuDiKangLi.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboJIngBuDiKangLi.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboJIngBuDiKangLi.ForeColor = System.Drawing.Color.White;
			this.m_cboJIngBuDiKangLi.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJIngBuDiKangLi.ListForeColor = System.Drawing.Color.White;
			this.m_cboJIngBuDiKangLi.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboJIngBuDiKangLi.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboJIngBuDiKangLi.Location = new System.Drawing.Point(280, 28);
			this.m_cboJIngBuDiKangLi.Name = "m_cboJIngBuDiKangLi";
			this.m_cboJIngBuDiKangLi.SelectedIndex = -1;
			this.m_cboJIngBuDiKangLi.SelectedItem = null;
			this.m_cboJIngBuDiKangLi.Size = new System.Drawing.Size(116, 26);
			this.m_cboJIngBuDiKangLi.TabIndex = 820;
			this.m_cboJIngBuDiKangLi.Tag = "[1][0005][00089][0]";
			this.m_cboJIngBuDiKangLi.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJIngBuDiKangLi.TextForeColor = System.Drawing.Color.White;
			// 
			// label86
			// 
			this.label86.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label86.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label86.ForeColor = System.Drawing.Color.White;
			this.label86.Location = new System.Drawing.Point(16, 32);
			this.label86.Name = "label86";
			this.label86.Size = new System.Drawing.Size(56, 16);
			this.label86.TabIndex = 3116;
			this.label86.Text = "颈部";
			// 
			// m_cboJingBuJingBu
			// 
			this.m_cboJingBuJingBu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJingBuJingBu.BorderColor = System.Drawing.Color.White;
			this.m_cboJingBuJingBu.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJingBuJingBu.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboJingBuJingBu.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboJingBuJingBu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboJingBuJingBu.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboJingBuJingBu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboJingBuJingBu.ForeColor = System.Drawing.Color.White;
			this.m_cboJingBuJingBu.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJingBuJingBu.ListForeColor = System.Drawing.Color.White;
			this.m_cboJingBuJingBu.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboJingBuJingBu.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboJingBuJingBu.Location = new System.Drawing.Point(80, 28);
			this.m_cboJingBuJingBu.Name = "m_cboJingBuJingBu";
			this.m_cboJingBuJingBu.SelectedIndex = -1;
			this.m_cboJingBuJingBu.SelectedItem = null;
			this.m_cboJingBuJingBu.Size = new System.Drawing.Size(116, 26);
			this.m_cboJingBuJingBu.TabIndex = 810;
			this.m_cboJingBuJingBu.Tag = "[1][0005][00110][0]";
			this.m_cboJingBuJingBu.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJingBuJingBu.TextForeColor = System.Drawing.Color.White;
			// 
			// 胸部
			// 
			this.胸部.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.胸部.Controls.AddRange(new System.Windows.Forms.Control[] {
																			 this.m_grbXiongBu});
			this.胸部.Location = new System.Drawing.Point(4, 26);
			this.胸部.Name = "胸部";
			this.胸部.Size = new System.Drawing.Size(932, 366);
			this.胸部.TabIndex = 8;
			this.胸部.Text = "胸部";
			// 
			// m_grbXiongBu
			// 
			this.m_grbXiongBu.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.label123,
																					   this.textBox15,
																					   this.label97,
																					   this.m_txtXiongBuFenBu,
																					   this.label96,
																					   this.m_txtXiongBuXinZhuang,
																					   this.label95,
																					   this.m_cboXiongBuXiongBu});
			this.m_grbXiongBu.ForeColor = System.Drawing.Color.White;
			this.m_grbXiongBu.Location = new System.Drawing.Point(8, 8);
			this.m_grbXiongBu.Name = "m_grbXiongBu";
			this.m_grbXiongBu.Size = new System.Drawing.Size(864, 336);
			this.m_grbXiongBu.TabIndex = 891;
			this.m_grbXiongBu.TabStop = false;
			this.m_grbXiongBu.Text = "胸部";
			// 
			// label123
			// 
			this.label123.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label123.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label123.ForeColor = System.Drawing.Color.White;
			this.label123.Location = new System.Drawing.Point(12, 228);
			this.label123.Name = "label123";
			this.label123.Size = new System.Drawing.Size(48, 16);
			this.label123.TabIndex = 3136;
			this.label123.Text = "其他";
			// 
			// textBox15
			// 
			this.textBox15.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.textBox15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox15.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox15.ForeColor = System.Drawing.Color.White;
			this.textBox15.Location = new System.Drawing.Point(80, 228);
			this.textBox15.Multiline = true;
			this.textBox15.Name = "textBox15";
			this.textBox15.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox15.Size = new System.Drawing.Size(776, 64);
			this.textBox15.TabIndex = 3135;
			this.textBox15.Tag = "[0][0006][09999][0]";
			this.textBox15.Text = "";
			// 
			// label97
			// 
			this.label97.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label97.ForeColor = System.Drawing.Color.White;
			this.label97.Location = new System.Drawing.Point(16, 140);
			this.label97.Name = "label97";
			this.label97.Size = new System.Drawing.Size(44, 16);
			this.label97.TabIndex = 3134;
			this.label97.Text = "肺部";
			// 
			// m_txtXiongBuFenBu
			// 
			this.m_txtXiongBuFenBu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtXiongBuFenBu.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtXiongBuFenBu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtXiongBuFenBu.ForeColor = System.Drawing.Color.White;
			this.m_txtXiongBuFenBu.Location = new System.Drawing.Point(80, 140);
			this.m_txtXiongBuFenBu.Multiline = true;
			this.m_txtXiongBuFenBu.Name = "m_txtXiongBuFenBu";
			this.m_txtXiongBuFenBu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtXiongBuFenBu.Size = new System.Drawing.Size(776, 72);
			this.m_txtXiongBuFenBu.TabIndex = 920;
			this.m_txtXiongBuFenBu.Tag = "[1][0006][00054][0]";
			this.m_txtXiongBuFenBu.Text = "";
			// 
			// label96
			// 
			this.label96.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label96.ForeColor = System.Drawing.Color.White;
			this.label96.Location = new System.Drawing.Point(16, 64);
			this.label96.Name = "label96";
			this.label96.Size = new System.Drawing.Size(40, 16);
			this.label96.TabIndex = 3132;
			this.label96.Text = "心脏";
			// 
			// m_txtXiongBuXinZhuang
			// 
			this.m_txtXiongBuXinZhuang.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtXiongBuXinZhuang.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtXiongBuXinZhuang.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtXiongBuXinZhuang.ForeColor = System.Drawing.Color.White;
			this.m_txtXiongBuXinZhuang.Location = new System.Drawing.Point(80, 64);
			this.m_txtXiongBuXinZhuang.Multiline = true;
			this.m_txtXiongBuXinZhuang.Name = "m_txtXiongBuXinZhuang";
			this.m_txtXiongBuXinZhuang.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtXiongBuXinZhuang.Size = new System.Drawing.Size(776, 64);
			this.m_txtXiongBuXinZhuang.TabIndex = 910;
			this.m_txtXiongBuXinZhuang.Tag = "[1][0006][00053][0]";
			this.m_txtXiongBuXinZhuang.Text = "";
			// 
			// label95
			// 
			this.label95.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label95.ForeColor = System.Drawing.Color.White;
			this.label95.Location = new System.Drawing.Point(16, 32);
			this.label95.Name = "label95";
			this.label95.Size = new System.Drawing.Size(40, 16);
			this.label95.TabIndex = 3130;
			this.label95.Text = "胸部";
			// 
			// m_cboXiongBuXiongBu
			// 
			this.m_cboXiongBuXiongBu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXiongBuXiongBu.BorderColor = System.Drawing.Color.White;
			this.m_cboXiongBuXiongBu.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXiongBuXiongBu.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboXiongBuXiongBu.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboXiongBuXiongBu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboXiongBuXiongBu.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboXiongBuXiongBu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboXiongBuXiongBu.ForeColor = System.Drawing.Color.White;
			this.m_cboXiongBuXiongBu.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXiongBuXiongBu.ListForeColor = System.Drawing.Color.White;
			this.m_cboXiongBuXiongBu.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboXiongBuXiongBu.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboXiongBuXiongBu.Location = new System.Drawing.Point(80, 24);
			this.m_cboXiongBuXiongBu.Name = "m_cboXiongBuXiongBu";
			this.m_cboXiongBuXiongBu.SelectedIndex = -1;
			this.m_cboXiongBuXiongBu.SelectedItem = null;
			this.m_cboXiongBuXiongBu.Size = new System.Drawing.Size(116, 26);
			this.m_cboXiongBuXiongBu.TabIndex = 900;
			this.m_cboXiongBuXiongBu.Tag = "[1][0006][00112][0]";
			this.m_cboXiongBuXiongBu.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXiongBuXiongBu.TextForeColor = System.Drawing.Color.White;
			// 
			// 腹部
			// 
			this.腹部.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.腹部.Controls.AddRange(new System.Windows.Forms.Control[] {
																			 this.m_grbFuBu});
			this.腹部.Location = new System.Drawing.Point(4, 26);
			this.腹部.Name = "腹部";
			this.腹部.Size = new System.Drawing.Size(932, 366);
			this.腹部.TabIndex = 3;
			this.腹部.Text = "腹部";
			this.腹部.Visible = false;
			// 
			// m_grbFuBu
			// 
			this.m_grbFuBu.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.m_txtFuBuQiTa,
																					this.m_cboFuBuJi,
																					this.label113,
																					this.label112,
																					this.label111,
																					this.m_cboFuBuChangRuDongYin,
																					this.label110,
																					this.m_txtFuBuBaoKuai,
																					this.label109,
																					this.m_cboFuBuBianYuan,
																					this.label108,
																					this.m_cboFuBuYingDu,
																					this.label107,
																					this.m_cboFuBuPiZang,
																					this.label106,
																					this.m_txtFuBuDanNang,
																					this.label105,
																					this.m_cboFuBuDanNang,
																					this.label103,
																					this.label104,
																					this.m_txtFuBuGangZhang,
																					this.label102,
																					this.m_cboFuBuGangZang,
																					this.label101,
																					this.label100,
																					this.m_txtFuBuFuBi,
																					this.label99,
																					this.m_cboFuBuFuBi,
																					this.label98,
																					this.m_cboFuBuFuBu});
			this.m_grbFuBu.ForeColor = System.Drawing.Color.White;
			this.m_grbFuBu.Location = new System.Drawing.Point(8, 8);
			this.m_grbFuBu.Name = "m_grbFuBu";
			this.m_grbFuBu.Size = new System.Drawing.Size(872, 264);
			this.m_grbFuBu.TabIndex = 930;
			this.m_grbFuBu.TabStop = false;
			this.m_grbFuBu.Text = "腹部";
			// 
			// m_txtFuBuQiTa
			// 
			this.m_txtFuBuQiTa.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtFuBuQiTa.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtFuBuQiTa.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtFuBuQiTa.ForeColor = System.Drawing.Color.White;
			this.m_txtFuBuQiTa.Location = new System.Drawing.Point(88, 176);
			this.m_txtFuBuQiTa.Multiline = true;
			this.m_txtFuBuQiTa.Name = "m_txtFuBuQiTa";
			this.m_txtFuBuQiTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtFuBuQiTa.Size = new System.Drawing.Size(776, 80);
			this.m_txtFuBuQiTa.TabIndex = 1070;
			this.m_txtFuBuQiTa.Tag = "[0][0007][09999][0]";
			this.m_txtFuBuQiTa.Text = "";
			// 
			// m_cboFuBuJi
			// 
			this.m_cboFuBuJi.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuJi.BorderColor = System.Drawing.Color.White;
			this.m_cboFuBuJi.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuJi.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboFuBuJi.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboFuBuJi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboFuBuJi.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFuBuJi.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFuBuJi.ForeColor = System.Drawing.Color.White;
			this.m_cboFuBuJi.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuJi.ListForeColor = System.Drawing.Color.White;
			this.m_cboFuBuJi.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboFuBuJi.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboFuBuJi.Location = new System.Drawing.Point(264, 144);
			this.m_cboFuBuJi.Name = "m_cboFuBuJi";
			this.m_cboFuBuJi.SelectedIndex = -1;
			this.m_cboFuBuJi.SelectedItem = null;
			this.m_cboFuBuJi.Size = new System.Drawing.Size(116, 26);
			this.m_cboFuBuJi.TabIndex = 1060;
			this.m_cboFuBuJi.Tag = "[1][0007][00060][0]";
			this.m_cboFuBuJi.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuJi.TextForeColor = System.Drawing.Color.White;
			// 
			// label113
			// 
			this.label113.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label113.ForeColor = System.Drawing.Color.White;
			this.label113.Location = new System.Drawing.Point(16, 176);
			this.label113.Name = "label113";
			this.label113.Size = new System.Drawing.Size(56, 16);
			this.label113.TabIndex = 3158;
			this.label113.Text = "其它";
			// 
			// label112
			// 
			this.label112.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label112.ForeColor = System.Drawing.Color.White;
			this.label112.Location = new System.Drawing.Point(216, 152);
			this.label112.Name = "label112";
			this.label112.Size = new System.Drawing.Size(32, 16);
			this.label112.TabIndex = 3157;
			this.label112.Text = "脐";
			// 
			// label111
			// 
			this.label111.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label111.ForeColor = System.Drawing.Color.White;
			this.label111.Location = new System.Drawing.Point(16, 152);
			this.label111.Name = "label111";
			this.label111.Size = new System.Drawing.Size(72, 16);
			this.label111.TabIndex = 3156;
			this.label111.Text = "肠蠕动音";
			// 
			// m_cboFuBuChangRuDongYin
			// 
			this.m_cboFuBuChangRuDongYin.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuChangRuDongYin.BorderColor = System.Drawing.Color.White;
			this.m_cboFuBuChangRuDongYin.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuChangRuDongYin.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboFuBuChangRuDongYin.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboFuBuChangRuDongYin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboFuBuChangRuDongYin.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFuBuChangRuDongYin.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFuBuChangRuDongYin.ForeColor = System.Drawing.Color.White;
			this.m_cboFuBuChangRuDongYin.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuChangRuDongYin.ListForeColor = System.Drawing.Color.White;
			this.m_cboFuBuChangRuDongYin.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboFuBuChangRuDongYin.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboFuBuChangRuDongYin.Location = new System.Drawing.Point(88, 144);
			this.m_cboFuBuChangRuDongYin.Name = "m_cboFuBuChangRuDongYin";
			this.m_cboFuBuChangRuDongYin.SelectedIndex = -1;
			this.m_cboFuBuChangRuDongYin.SelectedItem = null;
			this.m_cboFuBuChangRuDongYin.Size = new System.Drawing.Size(116, 26);
			this.m_cboFuBuChangRuDongYin.TabIndex = 1050;
			this.m_cboFuBuChangRuDongYin.Tag = "[1][0007][00059][0]";
			this.m_cboFuBuChangRuDongYin.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuChangRuDongYin.TextForeColor = System.Drawing.Color.White;
			// 
			// label110
			// 
			this.label110.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label110.ForeColor = System.Drawing.Color.White;
			this.label110.Location = new System.Drawing.Point(16, 120);
			this.label110.Name = "label110";
			this.label110.Size = new System.Drawing.Size(48, 16);
			this.label110.TabIndex = 3154;
			this.label110.Text = "包块";
			// 
			// m_txtFuBuBaoKuai
			// 
			this.m_txtFuBuBaoKuai.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtFuBuBaoKuai.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtFuBuBaoKuai.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtFuBuBaoKuai.ForeColor = System.Drawing.Color.White;
			this.m_txtFuBuBaoKuai.Location = new System.Drawing.Point(88, 120);
			this.m_txtFuBuBaoKuai.Name = "m_txtFuBuBaoKuai";
			this.m_txtFuBuBaoKuai.Size = new System.Drawing.Size(748, 19);
			this.m_txtFuBuBaoKuai.TabIndex = 1040;
			this.m_txtFuBuBaoKuai.Tag = "[0][0007][00116][0]";
			this.m_txtFuBuBaoKuai.Text = "";
			// 
			// label109
			// 
			this.label109.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label109.ForeColor = System.Drawing.Color.White;
			this.label109.Location = new System.Drawing.Point(656, 55);
			this.label109.Name = "label109";
			this.label109.Size = new System.Drawing.Size(40, 16);
			this.label109.TabIndex = 3152;
			this.label109.Text = "边缘";
			// 
			// m_cboFuBuBianYuan
			// 
			this.m_cboFuBuBianYuan.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuBianYuan.BorderColor = System.Drawing.Color.White;
			this.m_cboFuBuBianYuan.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuBianYuan.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboFuBuBianYuan.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboFuBuBianYuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboFuBuBianYuan.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFuBuBianYuan.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFuBuBianYuan.ForeColor = System.Drawing.Color.White;
			this.m_cboFuBuBianYuan.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuBianYuan.ListForeColor = System.Drawing.Color.White;
			this.m_cboFuBuBianYuan.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboFuBuBianYuan.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboFuBuBianYuan.Location = new System.Drawing.Point(720, 48);
			this.m_cboFuBuBianYuan.Name = "m_cboFuBuBianYuan";
			this.m_cboFuBuBianYuan.SelectedIndex = -1;
			this.m_cboFuBuBianYuan.SelectedItem = null;
			this.m_cboFuBuBianYuan.Size = new System.Drawing.Size(116, 26);
			this.m_cboFuBuBianYuan.TabIndex = 1000;
			this.m_cboFuBuBianYuan.Tag = "[1][0007][00115][0]";
			this.m_cboFuBuBianYuan.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuBianYuan.TextForeColor = System.Drawing.Color.White;
			// 
			// label108
			// 
			this.label108.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label108.ForeColor = System.Drawing.Color.White;
			this.label108.Location = new System.Drawing.Point(464, 56);
			this.label108.Name = "label108";
			this.label108.Size = new System.Drawing.Size(40, 16);
			this.label108.TabIndex = 3150;
			this.label108.Text = "硬度";
			// 
			// m_cboFuBuYingDu
			// 
			this.m_cboFuBuYingDu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuYingDu.BorderColor = System.Drawing.Color.White;
			this.m_cboFuBuYingDu.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuYingDu.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboFuBuYingDu.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboFuBuYingDu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboFuBuYingDu.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFuBuYingDu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFuBuYingDu.ForeColor = System.Drawing.Color.White;
			this.m_cboFuBuYingDu.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuYingDu.ListForeColor = System.Drawing.Color.White;
			this.m_cboFuBuYingDu.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboFuBuYingDu.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboFuBuYingDu.Location = new System.Drawing.Point(520, 48);
			this.m_cboFuBuYingDu.Name = "m_cboFuBuYingDu";
			this.m_cboFuBuYingDu.SelectedIndex = -1;
			this.m_cboFuBuYingDu.SelectedItem = null;
			this.m_cboFuBuYingDu.Size = new System.Drawing.Size(116, 26);
			this.m_cboFuBuYingDu.TabIndex = 990;
			this.m_cboFuBuYingDu.Tag = "[1][0007][00114][0]";
			this.m_cboFuBuYingDu.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuYingDu.TextForeColor = System.Drawing.Color.White;
			// 
			// label107
			// 
			this.label107.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label107.ForeColor = System.Drawing.Color.White;
			this.label107.Location = new System.Drawing.Point(464, 88);
			this.label107.Name = "label107";
			this.label107.Size = new System.Drawing.Size(44, 16);
			this.label107.TabIndex = 3148;
			this.label107.Text = "脾脏";
			// 
			// m_cboFuBuPiZang
			// 
			this.m_cboFuBuPiZang.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuPiZang.BorderColor = System.Drawing.Color.White;
			this.m_cboFuBuPiZang.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuPiZang.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboFuBuPiZang.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboFuBuPiZang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboFuBuPiZang.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFuBuPiZang.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFuBuPiZang.ForeColor = System.Drawing.Color.White;
			this.m_cboFuBuPiZang.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuPiZang.ListForeColor = System.Drawing.Color.White;
			this.m_cboFuBuPiZang.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboFuBuPiZang.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboFuBuPiZang.Location = new System.Drawing.Point(520, 80);
			this.m_cboFuBuPiZang.Name = "m_cboFuBuPiZang";
			this.m_cboFuBuPiZang.SelectedIndex = -1;
			this.m_cboFuBuPiZang.SelectedItem = null;
			this.m_cboFuBuPiZang.Size = new System.Drawing.Size(116, 26);
			this.m_cboFuBuPiZang.TabIndex = 1030;
			this.m_cboFuBuPiZang.Tag = "[1][0007][00102][0]";
			this.m_cboFuBuPiZang.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuPiZang.TextForeColor = System.Drawing.Color.White;
			// 
			// label106
			// 
			this.label106.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label106.ForeColor = System.Drawing.Color.White;
			this.label106.Location = new System.Drawing.Point(216, 89);
			this.label106.Name = "label106";
			this.label106.Size = new System.Drawing.Size(24, 16);
			this.label106.TabIndex = 3146;
			this.label106.Text = "于";
			// 
			// m_txtFuBuDanNang
			// 
			this.m_txtFuBuDanNang.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtFuBuDanNang.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtFuBuDanNang.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtFuBuDanNang.ForeColor = System.Drawing.Color.White;
			this.m_txtFuBuDanNang.Location = new System.Drawing.Point(264, 88);
			this.m_txtFuBuDanNang.Name = "m_txtFuBuDanNang";
			this.m_txtFuBuDanNang.Size = new System.Drawing.Size(116, 19);
			this.m_txtFuBuDanNang.TabIndex = 1020;
			this.m_txtFuBuDanNang.Tag = "[1][0007][00101][0]";
			this.m_txtFuBuDanNang.Text = "";
			// 
			// label105
			// 
			this.label105.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label105.ForeColor = System.Drawing.Color.White;
			this.label105.Location = new System.Drawing.Point(16, 94);
			this.label105.Name = "label105";
			this.label105.Size = new System.Drawing.Size(56, 16);
			this.label105.TabIndex = 3144;
			this.label105.Text = "胆囊";
			// 
			// m_cboFuBuDanNang
			// 
			this.m_cboFuBuDanNang.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuDanNang.BorderColor = System.Drawing.Color.White;
			this.m_cboFuBuDanNang.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuDanNang.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboFuBuDanNang.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboFuBuDanNang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboFuBuDanNang.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFuBuDanNang.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFuBuDanNang.ForeColor = System.Drawing.Color.White;
			this.m_cboFuBuDanNang.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuDanNang.ListForeColor = System.Drawing.Color.White;
			this.m_cboFuBuDanNang.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboFuBuDanNang.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboFuBuDanNang.Location = new System.Drawing.Point(88, 88);
			this.m_cboFuBuDanNang.Name = "m_cboFuBuDanNang";
			this.m_cboFuBuDanNang.SelectedIndex = -1;
			this.m_cboFuBuDanNang.SelectedItem = null;
			this.m_cboFuBuDanNang.Size = new System.Drawing.Size(116, 26);
			this.m_cboFuBuDanNang.TabIndex = 1010;
			this.m_cboFuBuDanNang.Tag = "[1][0007][00101][0]";
			this.m_cboFuBuDanNang.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuDanNang.TextForeColor = System.Drawing.Color.White;
			// 
			// label103
			// 
			this.label103.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label103.ForeColor = System.Drawing.Color.White;
			this.label103.Location = new System.Drawing.Point(388, 56);
			this.label103.Name = "label103";
			this.label103.Size = new System.Drawing.Size(40, 16);
			this.label103.TabIndex = 3142;
			this.label103.Text = "肿大";
			// 
			// label104
			// 
			this.label104.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label104.ForeColor = System.Drawing.Color.White;
			this.label104.Location = new System.Drawing.Point(216, 57);
			this.label104.Name = "label104";
			this.label104.Size = new System.Drawing.Size(24, 16);
			this.label104.TabIndex = 3141;
			this.label104.Text = "于";
			// 
			// m_txtFuBuGangZhang
			// 
			this.m_txtFuBuGangZhang.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtFuBuGangZhang.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtFuBuGangZhang.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtFuBuGangZhang.ForeColor = System.Drawing.Color.White;
			this.m_txtFuBuGangZhang.Location = new System.Drawing.Point(264, 56);
			this.m_txtFuBuGangZhang.Name = "m_txtFuBuGangZhang";
			this.m_txtFuBuGangZhang.Size = new System.Drawing.Size(116, 19);
			this.m_txtFuBuGangZhang.TabIndex = 980;
			this.m_txtFuBuGangZhang.Tag = "[1][0007][00056][0]";
			this.m_txtFuBuGangZhang.Text = "";
			// 
			// label102
			// 
			this.label102.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label102.ForeColor = System.Drawing.Color.White;
			this.label102.Location = new System.Drawing.Point(16, 63);
			this.label102.Name = "label102";
			this.label102.Size = new System.Drawing.Size(56, 16);
			this.label102.TabIndex = 3139;
			this.label102.Text = "肝脏";
			// 
			// m_cboFuBuGangZang
			// 
			this.m_cboFuBuGangZang.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuGangZang.BorderColor = System.Drawing.Color.White;
			this.m_cboFuBuGangZang.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuGangZang.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboFuBuGangZang.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboFuBuGangZang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboFuBuGangZang.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFuBuGangZang.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFuBuGangZang.ForeColor = System.Drawing.Color.White;
			this.m_cboFuBuGangZang.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuGangZang.ListForeColor = System.Drawing.Color.White;
			this.m_cboFuBuGangZang.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboFuBuGangZang.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboFuBuGangZang.Location = new System.Drawing.Point(88, 56);
			this.m_cboFuBuGangZang.Name = "m_cboFuBuGangZang";
			this.m_cboFuBuGangZang.SelectedIndex = -1;
			this.m_cboFuBuGangZang.SelectedItem = null;
			this.m_cboFuBuGangZang.Size = new System.Drawing.Size(116, 26);
			this.m_cboFuBuGangZang.TabIndex = 970;
			this.m_cboFuBuGangZang.Tag = "[1][0007][00056][0]";
			this.m_cboFuBuGangZang.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuGangZang.TextForeColor = System.Drawing.Color.White;
			// 
			// label101
			// 
			this.label101.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label101.ForeColor = System.Drawing.Color.White;
			this.label101.Location = new System.Drawing.Point(656, 24);
			this.label101.Name = "label101";
			this.label101.Size = new System.Drawing.Size(72, 16);
			this.label101.TabIndex = 3137;
			this.label101.Text = "部有触痛";
			// 
			// label100
			// 
			this.label100.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label100.ForeColor = System.Drawing.Color.White;
			this.label100.Location = new System.Drawing.Point(464, 26);
			this.label100.Name = "label100";
			this.label100.Size = new System.Drawing.Size(24, 16);
			this.label100.TabIndex = 3136;
			this.label100.Text = "于";
			// 
			// m_txtFuBuFuBi
			// 
			this.m_txtFuBuFuBi.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtFuBuFuBi.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtFuBuFuBi.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtFuBuFuBi.ForeColor = System.Drawing.Color.White;
			this.m_txtFuBuFuBi.Location = new System.Drawing.Point(520, 24);
			this.m_txtFuBuFuBi.Name = "m_txtFuBuFuBi";
			this.m_txtFuBuFuBi.Size = new System.Drawing.Size(116, 19);
			this.m_txtFuBuFuBi.TabIndex = 960;
			this.m_txtFuBuFuBi.Tag = "[1][0007][00055][0]";
			this.m_txtFuBuFuBi.Text = "";
			// 
			// label99
			// 
			this.label99.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label99.ForeColor = System.Drawing.Color.White;
			this.label99.Location = new System.Drawing.Point(212, 28);
			this.label99.Name = "label99";
			this.label99.Size = new System.Drawing.Size(44, 16);
			this.label99.TabIndex = 3134;
			this.label99.Text = "腹壁";
			// 
			// m_cboFuBuFuBi
			// 
			this.m_cboFuBuFuBi.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuFuBi.BorderColor = System.Drawing.Color.White;
			this.m_cboFuBuFuBi.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuFuBi.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboFuBuFuBi.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboFuBuFuBi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboFuBuFuBi.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFuBuFuBi.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFuBuFuBi.ForeColor = System.Drawing.Color.White;
			this.m_cboFuBuFuBi.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuFuBi.ListForeColor = System.Drawing.Color.White;
			this.m_cboFuBuFuBi.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboFuBuFuBi.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboFuBuFuBi.Location = new System.Drawing.Point(264, 24);
			this.m_cboFuBuFuBi.Name = "m_cboFuBuFuBi";
			this.m_cboFuBuFuBi.SelectedIndex = -1;
			this.m_cboFuBuFuBi.SelectedItem = null;
			this.m_cboFuBuFuBi.Size = new System.Drawing.Size(116, 26);
			this.m_cboFuBuFuBi.TabIndex = 950;
			this.m_cboFuBuFuBi.Tag = "[1][0007][00055][0]";
			this.m_cboFuBuFuBi.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuFuBi.TextForeColor = System.Drawing.Color.White;
			// 
			// label98
			// 
			this.label98.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label98.ForeColor = System.Drawing.Color.White;
			this.label98.Location = new System.Drawing.Point(16, 28);
			this.label98.Name = "label98";
			this.label98.Size = new System.Drawing.Size(56, 16);
			this.label98.TabIndex = 3132;
			this.label98.Text = "腹部";
			// 
			// m_cboFuBuFuBu
			// 
			this.m_cboFuBuFuBu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuFuBu.BorderColor = System.Drawing.Color.White;
			this.m_cboFuBuFuBu.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuFuBu.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboFuBuFuBu.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboFuBuFuBu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboFuBuFuBu.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFuBuFuBu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboFuBuFuBu.ForeColor = System.Drawing.Color.White;
			this.m_cboFuBuFuBu.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuFuBu.ListForeColor = System.Drawing.Color.White;
			this.m_cboFuBuFuBu.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboFuBuFuBu.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboFuBuFuBu.Location = new System.Drawing.Point(88, 24);
			this.m_cboFuBuFuBu.Name = "m_cboFuBuFuBu";
			this.m_cboFuBuFuBu.SelectedIndex = -1;
			this.m_cboFuBuFuBu.SelectedItem = null;
			this.m_cboFuBuFuBu.Size = new System.Drawing.Size(116, 26);
			this.m_cboFuBuFuBu.TabIndex = 940;
			this.m_cboFuBuFuBu.Tag = "[1][0007][00113][0]";
			this.m_cboFuBuFuBu.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboFuBuFuBu.TextForeColor = System.Drawing.Color.White;
			// 
			// 腹股沟
			// 
			this.腹股沟.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.腹股沟.Controls.AddRange(new System.Windows.Forms.Control[] {
																			  this.m_grbFuGuGou});
			this.腹股沟.Location = new System.Drawing.Point(4, 26);
			this.腹股沟.Name = "腹股沟";
			this.腹股沟.Size = new System.Drawing.Size(932, 366);
			this.腹股沟.TabIndex = 9;
			this.腹股沟.Text = "腹股沟";
			// 
			// m_grbFuGuGou
			// 
			this.m_grbFuGuGou.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.label133,
																					   this.textBox16,
																					   this.m_txtFuGuGou,
																					   this.label114});
			this.m_grbFuGuGou.ForeColor = System.Drawing.Color.White;
			this.m_grbFuGuGou.Location = new System.Drawing.Point(8, 8);
			this.m_grbFuGuGou.Name = "m_grbFuGuGou";
			this.m_grbFuGuGou.Size = new System.Drawing.Size(872, 208);
			this.m_grbFuGuGou.TabIndex = 1076;
			this.m_grbFuGuGou.TabStop = false;
			this.m_grbFuGuGou.Text = "腹股沟";
			// 
			// label133
			// 
			this.label133.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label133.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label133.ForeColor = System.Drawing.Color.White;
			this.label133.Location = new System.Drawing.Point(8, 124);
			this.label133.Name = "label133";
			this.label133.Size = new System.Drawing.Size(48, 16);
			this.label133.TabIndex = 3162;
			this.label133.Text = "其他";
			// 
			// textBox16
			// 
			this.textBox16.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.textBox16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox16.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox16.ForeColor = System.Drawing.Color.White;
			this.textBox16.Location = new System.Drawing.Point(88, 124);
			this.textBox16.Multiline = true;
			this.textBox16.Name = "textBox16";
			this.textBox16.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox16.Size = new System.Drawing.Size(776, 64);
			this.textBox16.TabIndex = 3161;
			this.textBox16.Tag = "[0][0008][09999][0]";
			this.textBox16.Text = "";
			// 
			// m_txtFuGuGou
			// 
			this.m_txtFuGuGou.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtFuGuGou.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtFuGuGou.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtFuGuGou.ForeColor = System.Drawing.Color.White;
			this.m_txtFuGuGou.Location = new System.Drawing.Point(88, 27);
			this.m_txtFuGuGou.Multiline = true;
			this.m_txtFuGuGou.Name = "m_txtFuGuGou";
			this.m_txtFuGuGou.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtFuGuGou.Size = new System.Drawing.Size(776, 85);
			this.m_txtFuGuGou.TabIndex = 1080;
			this.m_txtFuGuGou.Tag = "[0][0008][00117][0]";
			this.m_txtFuGuGou.Text = "";
			// 
			// label114
			// 
			this.label114.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label114.ForeColor = System.Drawing.Color.White;
			this.label114.Location = new System.Drawing.Point(8, 27);
			this.label114.Name = "label114";
			this.label114.Size = new System.Drawing.Size(56, 16);
			this.label114.TabIndex = 3160;
			this.label114.Text = "腹股沟";
			// 
			// 肛门
			// 
			this.肛门.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.肛门.Controls.AddRange(new System.Windows.Forms.Control[] {
																			 this.m_grbGangMen});
			this.肛门.Location = new System.Drawing.Point(4, 26);
			this.肛门.Name = "肛门";
			this.肛门.Size = new System.Drawing.Size(932, 366);
			this.肛门.TabIndex = 10;
			this.肛门.Text = "肛门";
			// 
			// m_grbGangMen
			// 
			this.m_grbGangMen.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.label139,
																					   this.textBox17,
																					   this.label134,
																					   this.m_cboGangMen});
			this.m_grbGangMen.ForeColor = System.Drawing.Color.White;
			this.m_grbGangMen.Location = new System.Drawing.Point(8, 12);
			this.m_grbGangMen.Name = "m_grbGangMen";
			this.m_grbGangMen.Size = new System.Drawing.Size(872, 140);
			this.m_grbGangMen.TabIndex = 1086;
			this.m_grbGangMen.TabStop = false;
			this.m_grbGangMen.Text = "肛门";
			// 
			// label139
			// 
			this.label139.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label139.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label139.ForeColor = System.Drawing.Color.White;
			this.label139.Location = new System.Drawing.Point(8, 68);
			this.label139.Name = "label139";
			this.label139.Size = new System.Drawing.Size(48, 16);
			this.label139.TabIndex = 3120;
			this.label139.Text = "其他";
			// 
			// textBox17
			// 
			this.textBox17.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.textBox17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox17.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox17.ForeColor = System.Drawing.Color.White;
			this.textBox17.Location = new System.Drawing.Point(72, 64);
			this.textBox17.Multiline = true;
			this.textBox17.Name = "textBox17";
			this.textBox17.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox17.Size = new System.Drawing.Size(776, 64);
			this.textBox17.TabIndex = 3119;
			this.textBox17.Tag = "[0][0009][09999][0]";
			this.textBox17.Text = "";
			// 
			// label134
			// 
			this.label134.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label134.ForeColor = System.Drawing.Color.White;
			this.label134.Location = new System.Drawing.Point(8, 28);
			this.label134.Name = "label134";
			this.label134.Size = new System.Drawing.Size(44, 16);
			this.label134.TabIndex = 3118;
			this.label134.Text = "肛门";
			// 
			// m_cboGangMen
			// 
			this.m_cboGangMen.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboGangMen.BorderColor = System.Drawing.Color.White;
			this.m_cboGangMen.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboGangMen.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboGangMen.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboGangMen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboGangMen.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboGangMen.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboGangMen.ForeColor = System.Drawing.Color.White;
			this.m_cboGangMen.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboGangMen.ListForeColor = System.Drawing.Color.White;
			this.m_cboGangMen.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboGangMen.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboGangMen.Location = new System.Drawing.Point(72, 24);
			this.m_cboGangMen.Name = "m_cboGangMen";
			this.m_cboGangMen.SelectedIndex = -1;
			this.m_cboGangMen.SelectedItem = null;
			this.m_cboGangMen.Size = new System.Drawing.Size(116, 26);
			this.m_cboGangMen.TabIndex = 1090;
			this.m_cboGangMen.Tag = "[1][0009][00118][0]";
			this.m_cboGangMen.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboGangMen.TextForeColor = System.Drawing.Color.White;
			// 
			// 外生殖器
			// 
			this.外生殖器.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.外生殖器.Controls.AddRange(new System.Windows.Forms.Control[] {
																			   this.m_grbWaiShengJiQi});
			this.外生殖器.Location = new System.Drawing.Point(4, 26);
			this.外生殖器.Name = "外生殖器";
			this.外生殖器.Size = new System.Drawing.Size(892, 366);
			this.外生殖器.TabIndex = 4;
			this.外生殖器.Text = "外生殖器";
			// 
			// m_grbWaiShengJiQi
			// 
			this.m_grbWaiShengJiQi.Controls.AddRange(new System.Windows.Forms.Control[] {
																							this.label140,
																							this.textBox18,
																							this.m_cboHuiYinBu,
																							this.label120,
																							this.m_cboYinNang,
																							this.m_cboWaiYinBu,
																							this.label119,
																							this.label118,
																							this.label117,
																							this.m_cboGouWan,
																							this.label116,
																							this.m_cboWaiShengJiQi});
			this.m_grbWaiShengJiQi.ForeColor = System.Drawing.Color.White;
			this.m_grbWaiShengJiQi.Location = new System.Drawing.Point(8, 8);
			this.m_grbWaiShengJiQi.Name = "m_grbWaiShengJiQi";
			this.m_grbWaiShengJiQi.Size = new System.Drawing.Size(872, 144);
			this.m_grbWaiShengJiQi.TabIndex = 1100;
			this.m_grbWaiShengJiQi.TabStop = false;
			this.m_grbWaiShengJiQi.Text = "外生殖器";
			this.m_grbWaiShengJiQi.Enter += new System.EventHandler(this.m_grbWaiShengJiQi_Enter);
			// 
			// label140
			// 
			this.label140.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label140.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label140.ForeColor = System.Drawing.Color.White;
			this.label140.Location = new System.Drawing.Point(4, 68);
			this.label140.Name = "label140";
			this.label140.Size = new System.Drawing.Size(48, 16);
			this.label140.TabIndex = 3171;
			this.label140.Text = "其他";
			// 
			// textBox18
			// 
			this.textBox18.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.textBox18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox18.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox18.ForeColor = System.Drawing.Color.White;
			this.textBox18.Location = new System.Drawing.Point(80, 68);
			this.textBox18.Multiline = true;
			this.textBox18.Name = "textBox18";
			this.textBox18.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox18.Size = new System.Drawing.Size(776, 64);
			this.textBox18.TabIndex = 3170;
			this.textBox18.Tag = "[0][0010][09999][0]";
			this.textBox18.Text = "";
			// 
			// m_cboHuiYinBu
			// 
			this.m_cboHuiYinBu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboHuiYinBu.BorderColor = System.Drawing.Color.White;
			this.m_cboHuiYinBu.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboHuiYinBu.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboHuiYinBu.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboHuiYinBu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboHuiYinBu.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboHuiYinBu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboHuiYinBu.ForeColor = System.Drawing.Color.White;
			this.m_cboHuiYinBu.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboHuiYinBu.ListForeColor = System.Drawing.Color.White;
			this.m_cboHuiYinBu.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboHuiYinBu.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboHuiYinBu.Location = new System.Drawing.Point(760, 24);
			this.m_cboHuiYinBu.Name = "m_cboHuiYinBu";
			this.m_cboHuiYinBu.SelectedIndex = -1;
			this.m_cboHuiYinBu.SelectedItem = null;
			this.m_cboHuiYinBu.Size = new System.Drawing.Size(105, 26);
			this.m_cboHuiYinBu.TabIndex = 1150;
			this.m_cboHuiYinBu.Tag = "[1][0010][00119][0]";
			this.m_cboHuiYinBu.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboHuiYinBu.TextForeColor = System.Drawing.Color.White;
			// 
			// label120
			// 
			this.label120.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label120.ForeColor = System.Drawing.Color.White;
			this.label120.Location = new System.Drawing.Point(696, 28);
			this.label120.Name = "label120";
			this.label120.Size = new System.Drawing.Size(56, 16);
			this.label120.TabIndex = 3169;
			this.label120.Text = "会阴部";
			// 
			// m_cboYinNang
			// 
			this.m_cboYinNang.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboYinNang.BorderColor = System.Drawing.Color.White;
			this.m_cboYinNang.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboYinNang.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboYinNang.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboYinNang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboYinNang.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboYinNang.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboYinNang.ForeColor = System.Drawing.Color.White;
			this.m_cboYinNang.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboYinNang.ListForeColor = System.Drawing.Color.White;
			this.m_cboYinNang.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboYinNang.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboYinNang.Location = new System.Drawing.Point(584, 24);
			this.m_cboYinNang.Name = "m_cboYinNang";
			this.m_cboYinNang.SelectedIndex = -1;
			this.m_cboYinNang.SelectedItem = null;
			this.m_cboYinNang.Size = new System.Drawing.Size(105, 26);
			this.m_cboYinNang.TabIndex = 1140;
			this.m_cboYinNang.Tag = "[1][0010][00064][0]";
			this.m_cboYinNang.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboYinNang.TextForeColor = System.Drawing.Color.White;
			// 
			// m_cboWaiYinBu
			// 
			this.m_cboWaiYinBu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboWaiYinBu.BorderColor = System.Drawing.Color.White;
			this.m_cboWaiYinBu.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboWaiYinBu.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboWaiYinBu.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboWaiYinBu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboWaiYinBu.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboWaiYinBu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboWaiYinBu.ForeColor = System.Drawing.Color.White;
			this.m_cboWaiYinBu.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboWaiYinBu.ListForeColor = System.Drawing.Color.White;
			this.m_cboWaiYinBu.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboWaiYinBu.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboWaiYinBu.Location = new System.Drawing.Point(272, 24);
			this.m_cboWaiYinBu.Name = "m_cboWaiYinBu";
			this.m_cboWaiYinBu.SelectedIndex = -1;
			this.m_cboWaiYinBu.SelectedItem = null;
			this.m_cboWaiYinBu.Size = new System.Drawing.Size(105, 26);
			this.m_cboWaiYinBu.TabIndex = 1120;
			this.m_cboWaiYinBu.Tag = "[1][0010][00063][0]";
			this.m_cboWaiYinBu.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboWaiYinBu.TextForeColor = System.Drawing.Color.White;
			// 
			// label119
			// 
			this.label119.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label119.ForeColor = System.Drawing.Color.White;
			this.label119.Location = new System.Drawing.Point(536, 28);
			this.label119.Name = "label119";
			this.label119.Size = new System.Drawing.Size(44, 16);
			this.label119.TabIndex = 3166;
			this.label119.Text = "阴囊";
			// 
			// label118
			// 
			this.label118.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label118.ForeColor = System.Drawing.Color.White;
			this.label118.Location = new System.Drawing.Point(196, 28);
			this.label118.Name = "label118";
			this.label118.Size = new System.Drawing.Size(56, 16);
			this.label118.TabIndex = 3165;
			this.label118.Text = "外阴部";
			// 
			// label117
			// 
			this.label117.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label117.ForeColor = System.Drawing.Color.White;
			this.label117.Location = new System.Drawing.Point(380, 28);
			this.label117.Name = "label117";
			this.label117.Size = new System.Drawing.Size(40, 16);
			this.label117.TabIndex = 3164;
			this.label117.Text = "睾丸";
			// 
			// m_cboGouWan
			// 
			this.m_cboGouWan.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboGouWan.BorderColor = System.Drawing.Color.White;
			this.m_cboGouWan.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboGouWan.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboGouWan.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboGouWan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboGouWan.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboGouWan.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboGouWan.ForeColor = System.Drawing.Color.White;
			this.m_cboGouWan.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboGouWan.ListForeColor = System.Drawing.Color.White;
			this.m_cboGouWan.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboGouWan.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboGouWan.Location = new System.Drawing.Point(424, 24);
			this.m_cboGouWan.Name = "m_cboGouWan";
			this.m_cboGouWan.SelectedIndex = -1;
			this.m_cboGouWan.SelectedItem = null;
			this.m_cboGouWan.Size = new System.Drawing.Size(105, 26);
			this.m_cboGouWan.TabIndex = 1130;
			this.m_cboGouWan.Tag = "[1][0010][00062][0]";
			this.m_cboGouWan.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboGouWan.TextForeColor = System.Drawing.Color.White;
			// 
			// label116
			// 
			this.label116.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label116.ForeColor = System.Drawing.Color.White;
			this.label116.Location = new System.Drawing.Point(4, 28);
			this.label116.Name = "label116";
			this.label116.Size = new System.Drawing.Size(56, 16);
			this.label116.TabIndex = 3162;
			this.label116.Text = "外生殖器";
			// 
			// m_cboWaiShengJiQi
			// 
			this.m_cboWaiShengJiQi.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboWaiShengJiQi.BorderColor = System.Drawing.Color.White;
			this.m_cboWaiShengJiQi.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboWaiShengJiQi.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboWaiShengJiQi.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboWaiShengJiQi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboWaiShengJiQi.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboWaiShengJiQi.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboWaiShengJiQi.ForeColor = System.Drawing.Color.White;
			this.m_cboWaiShengJiQi.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboWaiShengJiQi.ListForeColor = System.Drawing.Color.White;
			this.m_cboWaiShengJiQi.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboWaiShengJiQi.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboWaiShengJiQi.Location = new System.Drawing.Point(80, 24);
			this.m_cboWaiShengJiQi.Name = "m_cboWaiShengJiQi";
			this.m_cboWaiShengJiQi.SelectedIndex = -1;
			this.m_cboWaiShengJiQi.SelectedItem = null;
			this.m_cboWaiShengJiQi.Size = new System.Drawing.Size(105, 26);
			this.m_cboWaiShengJiQi.TabIndex = 1110;
			this.m_cboWaiShengJiQi.Tag = "[1][0010][00119][0]";
			this.m_cboWaiShengJiQi.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboWaiShengJiQi.TextForeColor = System.Drawing.Color.White;
			// 
			// 四肢
			// 
			this.四肢.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.四肢.Controls.AddRange(new System.Windows.Forms.Control[] {
																			 this.m_grbSiZhi});
			this.四肢.Location = new System.Drawing.Point(4, 26);
			this.四肢.Name = "四肢";
			this.四肢.Size = new System.Drawing.Size(892, 366);
			this.四肢.TabIndex = 11;
			this.四肢.Text = "四肢";
			// 
			// m_grbSiZhi
			// 
			this.m_grbSiZhi.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.label141,
																					 this.textBox19,
																					 this.m_txtTanHuang,
																					 this.label137,
																					 this.label136,
																					 this.m_txtSiZhiYangTong,
																					 this.label135,
																					 this.m_cboWuYiShiDongZuo,
																					 this.label115,
																					 this.m_cboSiZhi,
																					 this.label121});
			this.m_grbSiZhi.ForeColor = System.Drawing.Color.White;
			this.m_grbSiZhi.Location = new System.Drawing.Point(8, 8);
			this.m_grbSiZhi.Name = "m_grbSiZhi";
			this.m_grbSiZhi.Size = new System.Drawing.Size(872, 168);
			this.m_grbSiZhi.TabIndex = 1161;
			this.m_grbSiZhi.TabStop = false;
			this.m_grbSiZhi.Text = "四肢";
			// 
			// label141
			// 
			this.label141.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label141.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label141.ForeColor = System.Drawing.Color.White;
			this.label141.Location = new System.Drawing.Point(4, 92);
			this.label141.Name = "label141";
			this.label141.Size = new System.Drawing.Size(48, 16);
			this.label141.TabIndex = 3179;
			this.label141.Text = "其他";
			// 
			// textBox19
			// 
			this.textBox19.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.textBox19.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox19.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox19.ForeColor = System.Drawing.Color.White;
			this.textBox19.Location = new System.Drawing.Point(80, 92);
			this.textBox19.Multiline = true;
			this.textBox19.Name = "textBox19";
			this.textBox19.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox19.Size = new System.Drawing.Size(776, 64);
			this.textBox19.TabIndex = 3178;
			this.textBox19.Tag = "[0][0011][09999][0]";
			this.textBox19.Text = "";
			// 
			// m_txtTanHuang
			// 
			this.m_txtTanHuang.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtTanHuang.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtTanHuang.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTanHuang.ForeColor = System.Drawing.Color.White;
			this.m_txtTanHuang.Location = new System.Drawing.Point(80, 60);
			this.m_txtTanHuang.Name = "m_txtTanHuang";
			this.m_txtTanHuang.Size = new System.Drawing.Size(784, 19);
			this.m_txtTanHuang.TabIndex = 1200;
			this.m_txtTanHuang.Tag = "[1][0011][00123][0]";
			this.m_txtTanHuang.Text = "";
			// 
			// label137
			// 
			this.label137.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label137.ForeColor = System.Drawing.Color.White;
			this.label137.Location = new System.Drawing.Point(4, 60);
			this.label137.Name = "label137";
			this.label137.Size = new System.Drawing.Size(48, 16);
			this.label137.TabIndex = 3177;
			this.label137.Text = "瘫痪";
			// 
			// label136
			// 
			this.label136.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label136.ForeColor = System.Drawing.Color.White;
			this.label136.Location = new System.Drawing.Point(540, 28);
			this.label136.Name = "label136";
			this.label136.Size = new System.Drawing.Size(32, 16);
			this.label136.TabIndex = 3176;
			this.label136.Text = "部";
			// 
			// m_txtSiZhiYangTong
			// 
			this.m_txtSiZhiYangTong.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtSiZhiYangTong.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtSiZhiYangTong.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtSiZhiYangTong.ForeColor = System.Drawing.Color.White;
			this.m_txtSiZhiYangTong.Location = new System.Drawing.Point(424, 28);
			this.m_txtSiZhiYangTong.Name = "m_txtSiZhiYangTong";
			this.m_txtSiZhiYangTong.Size = new System.Drawing.Size(104, 19);
			this.m_txtSiZhiYangTong.TabIndex = 1190;
			this.m_txtSiZhiYangTong.Tag = "[1][0011][00122][0]";
			this.m_txtSiZhiYangTong.Text = "";
			// 
			// label135
			// 
			this.label135.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label135.ForeColor = System.Drawing.Color.White;
			this.label135.Location = new System.Drawing.Point(380, 28);
			this.label135.Name = "label135";
			this.label135.Size = new System.Drawing.Size(40, 16);
			this.label135.TabIndex = 3174;
			this.label135.Text = "压痛";
			// 
			// m_cboWuYiShiDongZuo
			// 
			this.m_cboWuYiShiDongZuo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboWuYiShiDongZuo.BorderColor = System.Drawing.Color.White;
			this.m_cboWuYiShiDongZuo.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboWuYiShiDongZuo.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboWuYiShiDongZuo.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboWuYiShiDongZuo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboWuYiShiDongZuo.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboWuYiShiDongZuo.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboWuYiShiDongZuo.ForeColor = System.Drawing.Color.White;
			this.m_cboWuYiShiDongZuo.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboWuYiShiDongZuo.ListForeColor = System.Drawing.Color.White;
			this.m_cboWuYiShiDongZuo.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboWuYiShiDongZuo.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboWuYiShiDongZuo.Location = new System.Drawing.Point(272, 24);
			this.m_cboWuYiShiDongZuo.Name = "m_cboWuYiShiDongZuo";
			this.m_cboWuYiShiDongZuo.SelectedIndex = -1;
			this.m_cboWuYiShiDongZuo.SelectedItem = null;
			this.m_cboWuYiShiDongZuo.Size = new System.Drawing.Size(104, 26);
			this.m_cboWuYiShiDongZuo.TabIndex = 1180;
			this.m_cboWuYiShiDongZuo.Tag = "[1][0011][00121][0]";
			this.m_cboWuYiShiDongZuo.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboWuYiShiDongZuo.TextForeColor = System.Drawing.Color.White;
			// 
			// label115
			// 
			this.label115.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label115.ForeColor = System.Drawing.Color.White;
			this.label115.Location = new System.Drawing.Point(196, 28);
			this.label115.Name = "label115";
			this.label115.Size = new System.Drawing.Size(56, 16);
			this.label115.TabIndex = 3172;
			this.label115.Text = "动作";
			// 
			// m_cboSiZhi
			// 
			this.m_cboSiZhi.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboSiZhi.BorderColor = System.Drawing.Color.White;
			this.m_cboSiZhi.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboSiZhi.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboSiZhi.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboSiZhi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboSiZhi.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboSiZhi.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboSiZhi.ForeColor = System.Drawing.Color.White;
			this.m_cboSiZhi.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboSiZhi.ListForeColor = System.Drawing.Color.White;
			this.m_cboSiZhi.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboSiZhi.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboSiZhi.Location = new System.Drawing.Point(80, 24);
			this.m_cboSiZhi.Name = "m_cboSiZhi";
			this.m_cboSiZhi.SelectedIndex = -1;
			this.m_cboSiZhi.SelectedItem = null;
			this.m_cboSiZhi.Size = new System.Drawing.Size(104, 26);
			this.m_cboSiZhi.TabIndex = 1170;
			this.m_cboSiZhi.Tag = "[1][0011][00120][0]";
			this.m_cboSiZhi.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboSiZhi.TextForeColor = System.Drawing.Color.White;
			// 
			// label121
			// 
			this.label121.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label121.ForeColor = System.Drawing.Color.White;
			this.label121.Location = new System.Drawing.Point(4, 28);
			this.label121.Name = "label121";
			this.label121.Size = new System.Drawing.Size(56, 16);
			this.label121.TabIndex = 3167;
			this.label121.Text = "四肢";
			// 
			// 脊柱
			// 
			this.脊柱.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.脊柱.Controls.AddRange(new System.Windows.Forms.Control[] {
																			 this.m_grbZhiZhu});
			this.脊柱.Location = new System.Drawing.Point(4, 26);
			this.脊柱.Name = "脊柱";
			this.脊柱.Size = new System.Drawing.Size(892, 366);
			this.脊柱.TabIndex = 12;
			this.脊柱.Text = "脊柱";
			// 
			// m_grbZhiZhu
			// 
			this.m_grbZhiZhu.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.label142,
																					  this.textBox20,
																					  this.m_cboHuoDongDu,
																					  this.label138,
																					  this.m_cboJiZhu,
																					  this.label122});
			this.m_grbZhiZhu.ForeColor = System.Drawing.Color.White;
			this.m_grbZhiZhu.Location = new System.Drawing.Point(8, 12);
			this.m_grbZhiZhu.Name = "m_grbZhiZhu";
			this.m_grbZhiZhu.Size = new System.Drawing.Size(872, 136);
			this.m_grbZhiZhu.TabIndex = 1211;
			this.m_grbZhiZhu.TabStop = false;
			this.m_grbZhiZhu.Text = "脊柱";
			// 
			// label142
			// 
			this.label142.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label142.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label142.ForeColor = System.Drawing.Color.White;
			this.label142.Location = new System.Drawing.Point(4, 64);
			this.label142.Name = "label142";
			this.label142.Size = new System.Drawing.Size(48, 16);
			this.label142.TabIndex = 3176;
			this.label142.Text = "其他";
			// 
			// textBox20
			// 
			this.textBox20.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.textBox20.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox20.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox20.ForeColor = System.Drawing.Color.White;
			this.textBox20.Location = new System.Drawing.Point(80, 64);
			this.textBox20.Multiline = true;
			this.textBox20.Name = "textBox20";
			this.textBox20.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox20.Size = new System.Drawing.Size(776, 64);
			this.textBox20.TabIndex = 3175;
			this.textBox20.Tag = "[0][0012][09999][0]";
			this.textBox20.Text = "";
			// 
			// m_cboHuoDongDu
			// 
			this.m_cboHuoDongDu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboHuoDongDu.BorderColor = System.Drawing.Color.White;
			this.m_cboHuoDongDu.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboHuoDongDu.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboHuoDongDu.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboHuoDongDu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboHuoDongDu.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboHuoDongDu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboHuoDongDu.ForeColor = System.Drawing.Color.White;
			this.m_cboHuoDongDu.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboHuoDongDu.ListForeColor = System.Drawing.Color.White;
			this.m_cboHuoDongDu.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboHuoDongDu.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboHuoDongDu.Location = new System.Drawing.Point(272, 24);
			this.m_cboHuoDongDu.Name = "m_cboHuoDongDu";
			this.m_cboHuoDongDu.SelectedIndex = -1;
			this.m_cboHuoDongDu.SelectedItem = null;
			this.m_cboHuoDongDu.Size = new System.Drawing.Size(104, 26);
			this.m_cboHuoDongDu.TabIndex = 1230;
			this.m_cboHuoDongDu.Tag = "[1][0012][00125][0]";
			this.m_cboHuoDongDu.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboHuoDongDu.TextForeColor = System.Drawing.Color.White;
			// 
			// label138
			// 
			this.label138.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label138.ForeColor = System.Drawing.Color.White;
			this.label138.Location = new System.Drawing.Point(192, 28);
			this.label138.Name = "label138";
			this.label138.Size = new System.Drawing.Size(56, 16);
			this.label138.TabIndex = 3174;
			this.label138.Text = "活动度";
			// 
			// m_cboJiZhu
			// 
			this.m_cboJiZhu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJiZhu.BorderColor = System.Drawing.Color.White;
			this.m_cboJiZhu.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJiZhu.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboJiZhu.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboJiZhu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboJiZhu.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboJiZhu.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboJiZhu.ForeColor = System.Drawing.Color.White;
			this.m_cboJiZhu.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJiZhu.ListForeColor = System.Drawing.Color.White;
			this.m_cboJiZhu.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboJiZhu.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboJiZhu.Location = new System.Drawing.Point(80, 24);
			this.m_cboJiZhu.Name = "m_cboJiZhu";
			this.m_cboJiZhu.SelectedIndex = -1;
			this.m_cboJiZhu.SelectedItem = null;
			this.m_cboJiZhu.Size = new System.Drawing.Size(104, 26);
			this.m_cboJiZhu.TabIndex = 1220;
			this.m_cboJiZhu.Tag = "[1][0012][00124][0]";
			this.m_cboJiZhu.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboJiZhu.TextForeColor = System.Drawing.Color.White;
			// 
			// label122
			// 
			this.label122.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label122.ForeColor = System.Drawing.Color.White;
			this.label122.Location = new System.Drawing.Point(4, 28);
			this.label122.Name = "label122";
			this.label122.Size = new System.Drawing.Size(44, 16);
			this.label122.TabIndex = 3172;
			this.label122.Text = "脊柱";
			// 
			// 神经反射
			// 
			this.神经反射.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.神经反射.Controls.AddRange(new System.Windows.Forms.Control[] {
																			   this.m_grbShenJingFangShe});
			this.神经反射.Location = new System.Drawing.Point(4, 26);
			this.神经反射.Name = "神经反射";
			this.神经反射.Size = new System.Drawing.Size(892, 366);
			this.神经反射.TabIndex = 13;
			this.神经反射.Text = "神经反射";
			// 
			// m_grbShenJingFangShe
			// 
			this.m_grbShenJingFangShe.Controls.AddRange(new System.Windows.Forms.Control[] {
																							   this.m_txtShenJingFangSheQiTa,
																							   this.m_txtLuoGuanJIeJingLan,
																							   this.m_txtTiGaoFanShe,
																							   this.m_txtFuBiFangShe,
																							   this.m_txtOuShiZheng,
																							   this.m_txtBaShiZheng,
																							   this.m_txtBuShiZheng,
																							   this.m_txtKeNiShiZheng,
																							   this.m_cboXiFangShe,
																							   this.label125,
																							   this.label132,
																							   this.label131,
																							   this.label130,
																							   this.label129,
																							   this.label128,
																							   this.label127,
																							   this.label126,
																							   this.label124});
			this.m_grbShenJingFangShe.ForeColor = System.Drawing.Color.White;
			this.m_grbShenJingFangShe.Location = new System.Drawing.Point(4, 4);
			this.m_grbShenJingFangShe.Name = "m_grbShenJingFangShe";
			this.m_grbShenJingFangShe.Size = new System.Drawing.Size(872, 208);
			this.m_grbShenJingFangShe.TabIndex = 1241;
			this.m_grbShenJingFangShe.TabStop = false;
			this.m_grbShenJingFangShe.Text = "神经发射";
			// 
			// m_txtShenJingFangSheQiTa
			// 
			this.m_txtShenJingFangSheQiTa.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtShenJingFangSheQiTa.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtShenJingFangSheQiTa.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtShenJingFangSheQiTa.ForeColor = System.Drawing.Color.White;
			this.m_txtShenJingFangSheQiTa.Location = new System.Drawing.Point(80, 132);
			this.m_txtShenJingFangSheQiTa.Multiline = true;
			this.m_txtShenJingFangSheQiTa.Name = "m_txtShenJingFangSheQiTa";
			this.m_txtShenJingFangSheQiTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtShenJingFangSheQiTa.Size = new System.Drawing.Size(692, 64);
			this.m_txtShenJingFangSheQiTa.TabIndex = 1330;
			this.m_txtShenJingFangSheQiTa.Tag = "[0][0013][09999][0]";
			this.m_txtShenJingFangSheQiTa.Text = "";
			// 
			// m_txtLuoGuanJIeJingLan
			// 
			this.m_txtLuoGuanJIeJingLan.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtLuoGuanJIeJingLan.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtLuoGuanJIeJingLan.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtLuoGuanJIeJingLan.ForeColor = System.Drawing.Color.White;
			this.m_txtLuoGuanJIeJingLan.Location = new System.Drawing.Point(620, 100);
			this.m_txtLuoGuanJIeJingLan.Name = "m_txtLuoGuanJIeJingLan";
			this.m_txtLuoGuanJIeJingLan.Size = new System.Drawing.Size(152, 19);
			this.m_txtLuoGuanJIeJingLan.TabIndex = 1320;
			this.m_txtLuoGuanJIeJingLan.Tag = "[0][0013][00073][0]";
			this.m_txtLuoGuanJIeJingLan.Text = "";
			// 
			// m_txtTiGaoFanShe
			// 
			this.m_txtTiGaoFanShe.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtTiGaoFanShe.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtTiGaoFanShe.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTiGaoFanShe.ForeColor = System.Drawing.Color.White;
			this.m_txtTiGaoFanShe.Location = new System.Drawing.Point(272, 100);
			this.m_txtTiGaoFanShe.Name = "m_txtTiGaoFanShe";
			this.m_txtTiGaoFanShe.Size = new System.Drawing.Size(232, 19);
			this.m_txtTiGaoFanShe.TabIndex = 1310;
			this.m_txtTiGaoFanShe.Tag = "[1][0013][00072][0]";
			this.m_txtTiGaoFanShe.Text = "";
			// 
			// m_txtFuBiFangShe
			// 
			this.m_txtFuBiFangShe.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtFuBiFangShe.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtFuBiFangShe.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtFuBiFangShe.ForeColor = System.Drawing.Color.White;
			this.m_txtFuBiFangShe.Location = new System.Drawing.Point(80, 100);
			this.m_txtFuBiFangShe.Name = "m_txtFuBiFangShe";
			this.m_txtFuBiFangShe.Size = new System.Drawing.Size(104, 19);
			this.m_txtFuBiFangShe.TabIndex = 1300;
			this.m_txtFuBiFangShe.Tag = "[0][0013][00071][0]";
			this.m_txtFuBiFangShe.Text = "";
			// 
			// m_txtOuShiZheng
			// 
			this.m_txtOuShiZheng.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtOuShiZheng.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtOuShiZheng.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtOuShiZheng.ForeColor = System.Drawing.Color.White;
			this.m_txtOuShiZheng.Location = new System.Drawing.Point(272, 68);
			this.m_txtOuShiZheng.Name = "m_txtOuShiZheng";
			this.m_txtOuShiZheng.Size = new System.Drawing.Size(232, 19);
			this.m_txtOuShiZheng.TabIndex = 1290;
			this.m_txtOuShiZheng.Tag = "[0][0013][00070][0]";
			this.m_txtOuShiZheng.Text = "";
			// 
			// m_txtBaShiZheng
			// 
			this.m_txtBaShiZheng.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtBaShiZheng.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtBaShiZheng.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtBaShiZheng.ForeColor = System.Drawing.Color.White;
			this.m_txtBaShiZheng.Location = new System.Drawing.Point(80, 68);
			this.m_txtBaShiZheng.Name = "m_txtBaShiZheng";
			this.m_txtBaShiZheng.Size = new System.Drawing.Size(104, 19);
			this.m_txtBaShiZheng.TabIndex = 1280;
			this.m_txtBaShiZheng.Tag = "[0][0013][00069][0]";
			this.m_txtBaShiZheng.Text = "";
			// 
			// m_txtBuShiZheng
			// 
			this.m_txtBuShiZheng.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtBuShiZheng.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtBuShiZheng.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtBuShiZheng.ForeColor = System.Drawing.Color.White;
			this.m_txtBuShiZheng.Location = new System.Drawing.Point(620, 36);
			this.m_txtBuShiZheng.Name = "m_txtBuShiZheng";
			this.m_txtBuShiZheng.Size = new System.Drawing.Size(152, 19);
			this.m_txtBuShiZheng.TabIndex = 1270;
			this.m_txtBuShiZheng.Tag = "[0][0013][00068][0]";
			this.m_txtBuShiZheng.Text = "";
			// 
			// m_txtKeNiShiZheng
			// 
			this.m_txtKeNiShiZheng.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtKeNiShiZheng.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtKeNiShiZheng.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtKeNiShiZheng.ForeColor = System.Drawing.Color.White;
			this.m_txtKeNiShiZheng.Location = new System.Drawing.Point(272, 36);
			this.m_txtKeNiShiZheng.Name = "m_txtKeNiShiZheng";
			this.m_txtKeNiShiZheng.Size = new System.Drawing.Size(232, 19);
			this.m_txtKeNiShiZheng.TabIndex = 1260;
			this.m_txtKeNiShiZheng.Tag = "[0][0013][00067][0]";
			this.m_txtKeNiShiZheng.Text = "";
			// 
			// m_cboXiFangShe
			// 
			this.m_cboXiFangShe.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXiFangShe.BorderColor = System.Drawing.Color.White;
			this.m_cboXiFangShe.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXiFangShe.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboXiFangShe.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboXiFangShe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboXiFangShe.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboXiFangShe.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboXiFangShe.ForeColor = System.Drawing.Color.White;
			this.m_cboXiFangShe.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXiFangShe.ListForeColor = System.Drawing.Color.White;
			this.m_cboXiFangShe.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboXiFangShe.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboXiFangShe.Location = new System.Drawing.Point(80, 28);
			this.m_cboXiFangShe.Name = "m_cboXiFangShe";
			this.m_cboXiFangShe.SelectedIndex = -1;
			this.m_cboXiFangShe.SelectedItem = null;
			this.m_cboXiFangShe.Size = new System.Drawing.Size(104, 26);
			this.m_cboXiFangShe.TabIndex = 1250;
			this.m_cboXiFangShe.Tag = "[1][0013][00066][0]";
			this.m_cboXiFangShe.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboXiFangShe.TextForeColor = System.Drawing.Color.White;
			// 
			// label125
			// 
			this.label125.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label125.ForeColor = System.Drawing.Color.White;
			this.label125.Location = new System.Drawing.Point(196, 36);
			this.label125.Name = "label125";
			this.label125.Size = new System.Drawing.Size(72, 16);
			this.label125.TabIndex = 3186;
			this.label125.Text = "克匿氏征";
			// 
			// label132
			// 
			this.label132.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label132.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label132.ForeColor = System.Drawing.Color.White;
			this.label132.Location = new System.Drawing.Point(4, 132);
			this.label132.Name = "label132";
			this.label132.Size = new System.Drawing.Size(44, 16);
			this.label132.TabIndex = 3185;
			this.label132.Text = "其他";
			// 
			// label131
			// 
			this.label131.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label131.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label131.ForeColor = System.Drawing.Color.White;
			this.label131.Location = new System.Drawing.Point(524, 100);
			this.label131.Name = "label131";
			this.label131.Size = new System.Drawing.Size(88, 16);
			this.label131.TabIndex = 3184;
			this.label131.Text = "踝关节阵挛";
			// 
			// label130
			// 
			this.label130.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label130.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label130.ForeColor = System.Drawing.Color.White;
			this.label130.Location = new System.Drawing.Point(196, 100);
			this.label130.Name = "label130";
			this.label130.Size = new System.Drawing.Size(72, 16);
			this.label130.TabIndex = 3183;
			this.label130.Text = "提睾反射";
			// 
			// label129
			// 
			this.label129.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label129.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label129.ForeColor = System.Drawing.Color.White;
			this.label129.Location = new System.Drawing.Point(4, 100);
			this.label129.Name = "label129";
			this.label129.Size = new System.Drawing.Size(72, 16);
			this.label129.TabIndex = 3182;
			this.label129.Text = "腹壁反射";
			// 
			// label128
			// 
			this.label128.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label128.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label128.ForeColor = System.Drawing.Color.White;
			this.label128.Location = new System.Drawing.Point(196, 68);
			this.label128.Name = "label128";
			this.label128.Size = new System.Drawing.Size(56, 16);
			this.label128.TabIndex = 3181;
			this.label128.Text = "欧氏征";
			// 
			// label127
			// 
			this.label127.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label127.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label127.ForeColor = System.Drawing.Color.White;
			this.label127.Location = new System.Drawing.Point(4, 68);
			this.label127.Name = "label127";
			this.label127.Size = new System.Drawing.Size(64, 16);
			this.label127.TabIndex = 3180;
			this.label127.Text = "巴氏征";
			// 
			// label126
			// 
			this.label126.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label126.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label126.ForeColor = System.Drawing.Color.White;
			this.label126.Location = new System.Drawing.Point(556, 36);
			this.label126.Name = "label126";
			this.label126.Size = new System.Drawing.Size(56, 16);
			this.label126.TabIndex = 3179;
			this.label126.Text = "布氏征";
			// 
			// label124
			// 
			this.label124.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label124.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label124.ForeColor = System.Drawing.Color.White;
			this.label124.Location = new System.Drawing.Point(4, 28);
			this.label124.Name = "label124";
			this.label124.Size = new System.Drawing.Size(56, 16);
			this.label124.TabIndex = 3178;
			this.label124.Text = "膝反射";
			// 
			// m_txtPreView
			// 
			this.m_txtPreView.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtPreView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtPreView.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtPreView.ForeColor = System.Drawing.Color.White;
			this.m_txtPreView.Location = new System.Drawing.Point(12, 444);
			this.m_txtPreView.Multiline = true;
			this.m_txtPreView.Name = "m_txtPreView";
			this.m_txtPreView.ReadOnly = true;
			this.m_txtPreView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtPreView.Size = new System.Drawing.Size(892, 64);
			this.m_txtPreView.TabIndex = 3046;
			this.m_txtPreView.Tag = "[0][0002][09999][0]";
			this.m_txtPreView.Text = "";
			// 
			// cmdPreView
			// 
			this.cmdPreView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdPreView.Location = new System.Drawing.Point(400, 404);
			this.cmdPreView.Name = "cmdPreView";
			this.cmdPreView.Size = new System.Drawing.Size(64, 32);
			this.cmdPreView.TabIndex = 3045;
			this.cmdPreView.Text = "↓↓↓";
			this.cmdPreView.Click += new System.EventHandler(this.cmdPreView_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdOK.ForeColor = System.Drawing.Color.White;
			this.cmdOK.Location = new System.Drawing.Point(736, 524);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(80, 32);
			this.cmdOK.TabIndex = 3042;
			this.cmdOK.Text = "确定";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdClear
			// 
			this.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdClear.ForeColor = System.Drawing.Color.White;
			this.cmdClear.Location = new System.Drawing.Point(648, 524);
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.Size = new System.Drawing.Size(80, 32);
			this.cmdClear.TabIndex = 3043;
			this.cmdClear.Text = "清空";
			this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdCancel.ForeColor = System.Drawing.Color.White;
			this.cmdCancel.Location = new System.Drawing.Point(824, 524);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(80, 32);
			this.cmdCancel.TabIndex = 3042;
			this.cmdCancel.Text = "取消";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// frmMedicalExam001
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(914, 567);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_cmdPre,
																		  this.m_cmdNext,
																		  this.m_cmdNewTemplate,
																		  this.m_lsvBedNO,
																		  this.m_lsvPatientName,
																		  this.m_lsvInPatientID,
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
																		  this.m_cboDept,
																		  this.lblDept,
																		  this.cmdClear,
																		  this.cmdOK,
																		  this.tabControl1,
																		  this.cmdCancel,
																		  this.m_txtPreView,
																		  this.cmdPreView});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMedicalExam001";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "体格检查";
			this.Load += new System.EventHandler(this.frmMedicalExam001_Load);
			this.tabControl1.ResumeLayout(false);
			this.一般情况.ResumeLayout(false);
			this.m_grbGeranal.ResumeLayout(false);
			this.头部.ResumeLayout(false);
			this.m_grbTouBu.ResumeLayout(false);
			this.皮肤.ResumeLayout(false);
			this.m_grbPiFu.ResumeLayout(false);
			this.淋巴腺.ResumeLayout(false);
			this.m_grbLinBaXian.ResumeLayout(false);
			this.颈部.ResumeLayout(false);
			this.m_grbJingBu.ResumeLayout(false);
			this.胸部.ResumeLayout(false);
			this.m_grbXiongBu.ResumeLayout(false);
			this.腹部.ResumeLayout(false);
			this.m_grbFuBu.ResumeLayout(false);
			this.腹股沟.ResumeLayout(false);
			this.m_grbFuGuGou.ResumeLayout(false);
			this.肛门.ResumeLayout(false);
			this.m_grbGangMen.ResumeLayout(false);
			this.外生殖器.ResumeLayout(false);
			this.m_grbWaiShengJiQi.ResumeLayout(false);
			this.四肢.ResumeLayout(false);
			this.m_grbSiZhi.ResumeLayout(false);
			this.脊柱.ResumeLayout(false);
			this.m_grbZhiZhu.ResumeLayout(false);
			this.神经反射.ResumeLayout(false);
			this.m_grbShenJingFangShe.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		
		private void cmdOK_Click(object sender, System.EventArgs e)
		{	
			m_blnIsOK=true;
//			m_objPicValueArr = ctlPaintContainer1.m_objGetPicValue();
			m_evtHide.Invoke(this,e);
			this.Hide ();
		}

		private EventHandler m_evtHide;
		public event EventHandler m_EvtHide
		{
			add
			{
				m_evtHide += value;
			}
			remove
			{
				m_evtHide -= value;
			}
		}

		private void frmMedicalExam001_Load(object sender, System.EventArgs e)
		{
			m_blnIsOK=false;
			m_objHighLight.m_mthAddControlInContainer(this);
		}

		private void m_grbWaiShengJiQi_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void cmdClear_Click(object sender, System.EventArgs e)
		{
			m_objMedicalExamDomain.m_mthClearMedicalExamControls (this);
		}

		private void m_grbLinBaXian_Enter(object sender, System.EventArgs e)
		{
		
		}

//		private clsMedicalExamDomain m_objMedicalExamDomain=new clsMedicalExamDomain();

		private void cmdPreView_Click(object sender, System.EventArgs e)
		{
			string strPreView = new clsMedicalExamDomain().m_strGetMedicalExamUnitString(tabControl1.SelectedTab);
			m_txtPreView.Text = strPreView;
			tabControl1.SelectedTab.Tag = strPreView;
		}

		private void m_mthCancelClose(object sender,CancelEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(tabControl1.SelectedTab.Tag != null && tabControl1.SelectedTab.Tag.ToString() != "")
				m_txtPreView.Text = tabControl1.SelectedTab.Tag.ToString();
			else
				m_txtPreView.Text = "";
		}

		#region 画图
//		public clsPictureBoxValue[] m_objPicValueArr = null;
//
//		/// <summary>
//		/// 清除所有图片
//		/// </summary>
//		public void m_mthClearAllPic()
//		{
//			foreach(Control ctlSub in ctlPaintContainer1.Controls)
//			{
//				if(ctlSub!=null && ctlSub.GetType().Name=="PictureBox")
//				{
//					ctlPaintContainer1.Controls.Remove(ctlSub);
//				}
//			}
//		}
//
//		private void button5_Click(object sender, System.EventArgs e)
//		{
//			m_mthSetPicValue(m_objPicValueArr);
//		}
//
//		private Image m_imgBinaryToImage(object p_obj)
//		{
//			System.IO.MemoryStream objStream = new System.IO.MemoryStream((byte[])p_obj);
//
//			Image img = new Bitmap(objStream);
//
//			return img;
//		}
//
//		public void m_mthSetPicValue(clsPictureBoxValue[] p_objPicValueArr)
//		{
//			ctlPaintContainer1.m_mthSetPicValue(p_objPicValueArr);
//		}
		#endregion
	}
}

