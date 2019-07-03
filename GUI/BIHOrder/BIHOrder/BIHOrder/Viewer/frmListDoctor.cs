using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.common;
using System.Data;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.BIHOrder.Control;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.BIHOrder
{
	/// <summary>
	/// frmListDoctor 的摘要说明。
	/// </summary>
	public class frmListDoctor : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region 自定义变量
		private static string _DoctorID;
		private static string _DoctorName;
		private static string _PatientID;
		private static string _PatientName;
		private int SelectedIndex = -1;

		public static long DialogResult=0;

		private com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService m_OrderService;
		private com.digitalwave.iCare.BIHOrder.clsDcl_InputOrder svc;
		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtDoctor;
		private System.Windows.Forms.TextBox txtPatient;
		private System.Windows.Forms.ListView lsvDoctor;
		private System.Windows.Forms.ListView lsvPatient;
		private System.Windows.Forms.ColumnHeader INPATIENTID;
		private System.Windows.Forms.ColumnHeader Name_VChr;
		private System.Windows.Forms.ColumnHeader sCode;
		private System.Windows.Forms.ColumnHeader sName;
		private PinkieControls.ButtonXP m_cmdOK;
		private PinkieControls.ButtonXP m_cmdCancle;
		private PinkieControls.ButtonXP m_cmdClose;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ColumnHeader Sex_Chr;
		private System.Windows.Forms.ColumnHeader statue;
		private System.Windows.Forms.ColumnHeader eatcare;
		private System.Windows.Forms.ColumnHeader nursecare;
        private ColumnHeader BedName;
        private ColumnHeader AreaName;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmListDoctor()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
            m_OrderService = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		public void setDoctor(com.digitalwave.iCare.ValueObject.clsLoginInfo loginInfo)
		{
			this.LoginInfo = loginInfo;
			DoctorID = loginInfo.m_strEmpID;
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.txtPatient = new System.Windows.Forms.TextBox();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_cmdCancle = new PinkieControls.ButtonXP();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.lsvDoctor = new System.Windows.Forms.ListView();
            this.sCode = new System.Windows.Forms.ColumnHeader();
            this.sName = new System.Windows.Forms.ColumnHeader();
            this.lsvPatient = new System.Windows.Forms.ListView();
            this.INPATIENTID = new System.Windows.Forms.ColumnHeader();
            this.AreaName = new System.Windows.Forms.ColumnHeader();
            this.BedName = new System.Windows.Forms.ColumnHeader();
            this.Name_VChr = new System.Windows.Forms.ColumnHeader();
            this.Sex_Chr = new System.Windows.Forms.ColumnHeader();
            this.statue = new System.Windows.Forms.ColumnHeader();
            this.eatcare = new System.Windows.Forms.ColumnHeader();
            this.nursecare = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择医生:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "选择病人:";
            // 
            // txtDoctor
            // 
            this.txtDoctor.Location = new System.Drawing.Point(76, 0);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(412, 23);
            this.txtDoctor.TabIndex = 2;
            this.txtDoctor.Enter += new System.EventHandler(this.txtDoctor_Enter);
            this.txtDoctor.Leave += new System.EventHandler(this.txtDoctor_Leave);
            this.txtDoctor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDoctor_KeyDown);
            // 
            // txtPatient
            // 
            this.txtPatient.Location = new System.Drawing.Point(16, 248);
            this.txtPatient.Name = "txtPatient";
            this.txtPatient.Size = new System.Drawing.Size(8, 23);
            this.txtPatient.TabIndex = 3;
            this.txtPatient.Visible = false;
            this.txtPatient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPatient_KeyDown);
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(412, 366);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOK.Size = new System.Drawing.Size(71, 26);
            this.m_cmdOK.TabIndex = 43;
            this.m_cmdOK.Text = "确 定";
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_cmdCancle
            // 
            this.m_cmdCancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdCancle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCancle.DefaultScheme = true;
            this.m_cmdCancle.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCancle.Hint = "";
            this.m_cmdCancle.Location = new System.Drawing.Point(341, 366);
            this.m_cmdCancle.Name = "m_cmdCancle";
            this.m_cmdCancle.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancle.Size = new System.Drawing.Size(71, 26);
            this.m_cmdCancle.TabIndex = 44;
            this.m_cmdCancle.Text = "取 消";
            this.m_cmdCancle.Visible = false;
            this.m_cmdCancle.Click += new System.EventHandler(this.m_cmdCancle_Click);
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(269, 366);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(71, 26);
            this.m_cmdClose.TabIndex = 45;
            this.m_cmdClose.Text = "关 闭";
            this.m_cmdClose.Visible = false;
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // lsvDoctor
            // 
            this.lsvDoctor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sCode,
            this.sName});
            this.lsvDoctor.FullRowSelect = true;
            this.lsvDoctor.GridLines = true;
            this.lsvDoctor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvDoctor.Location = new System.Drawing.Point(76, 24);
            this.lsvDoctor.MultiSelect = false;
            this.lsvDoctor.Name = "lsvDoctor";
            this.lsvDoctor.Size = new System.Drawing.Size(412, 144);
            this.lsvDoctor.TabIndex = 46;
            this.lsvDoctor.UseCompatibleStateImageBehavior = false;
            this.lsvDoctor.View = System.Windows.Forms.View.Details;
            this.lsvDoctor.Visible = false;
            this.lsvDoctor.DoubleClick += new System.EventHandler(this.lsvDoctor_DoubleClick);
            this.lsvDoctor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvDoctor_KeyDown);
            this.lsvDoctor.Leave += new System.EventHandler(this.lsvDoctor_Leave);
            // 
            // sCode
            // 
            this.sCode.Width = 76;
            // 
            // sName
            // 
            this.sName.Width = 164;
            // 
            // lsvPatient
            // 
            this.lsvPatient.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.INPATIENTID,
            this.AreaName,
            this.BedName,
            this.Name_VChr,
            this.Sex_Chr,
            this.statue,
            this.eatcare,
            this.nursecare});
            this.lsvPatient.FullRowSelect = true;
            this.lsvPatient.GridLines = true;
            this.lsvPatient.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvPatient.Location = new System.Drawing.Point(4, 44);
            this.lsvPatient.MultiSelect = false;
            this.lsvPatient.Name = "lsvPatient";
            this.lsvPatient.Size = new System.Drawing.Size(484, 316);
            this.lsvPatient.TabIndex = 47;
            this.lsvPatient.UseCompatibleStateImageBehavior = false;
            this.lsvPatient.View = System.Windows.Forms.View.Details;
            this.lsvPatient.DoubleClick += new System.EventHandler(this.lsvPatient_DoubleClick);
            this.lsvPatient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvPatient_KeyDown);
            // 
            // INPATIENTID
            // 
            this.INPATIENTID.Text = "住院号";
            this.INPATIENTID.Width = 80;
            // 
            // AreaName
            // 
            this.AreaName.Text = "病区";
            this.AreaName.Width = 91;
            // 
            // BedName
            // 
            this.BedName.Text = "床号";
            this.BedName.Width = 44;
            // 
            // Name_VChr
            // 
            this.Name_VChr.Text = "姓名";
            this.Name_VChr.Width = 80;
            // 
            // Sex_Chr
            // 
            this.Sex_Chr.Text = "性别";
            // 
            // statue
            // 
            this.statue.Text = "病情";
            // 
            // eatcare
            // 
            this.eatcare.Text = "饮食";
            this.eatcare.Width = 80;
            // 
            // nursecare
            // 
            this.nursecare.Text = "护理";
            this.nursecare.Width = 80;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(76, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 48;
            this.label3.Text = "输入医生编号查找";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(12, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 16);
            this.label4.TabIndex = 49;
            this.label4.Text = "输入住院号以查找病人";
            this.label4.Visible = false;
            // 
            // frmListDoctor
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(492, 402);
            this.ControlBox = false;
            this.Controls.Add(this.lsvDoctor);
            this.Controls.Add(this.txtDoctor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.m_cmdCancle);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPatient);
            this.Controls.Add(this.lsvPatient);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmListDoctor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择病人";
            this.Load += new System.EventHandler(this.frmListDoctor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region 属性

		public static string DoctorID
		{
			get{return _DoctorID;}set{_DoctorID=value;}
		}

		public static string DoctorName
		{
			get{return _DoctorName;}set{_DoctorName=value;}
		}

		public static string PatientID
		{
			get{return _PatientID;}set{_PatientID=value;}
		}
		public static string PatientName
		{
			get{return _PatientName;}set{_PatientName=value;}
		}

		#endregion

		#region 方法

		/// <summary>
		/// 获取医生列表
		/// </summary>
		/// <param name="strFilter"></param>
		/// <returns></returns>
		private long m_lngGetDoctorList(string strFilter)
		{
			DataTable dtbRes=new DataTable();

			long lngRes=m_OrderService.m_lngGetDoctors(strFilter,out dtbRes);

			lsvDoctor.Items.Clear();

			if(lngRes==0 && dtbRes.Rows.Count>0)
			{
				for(int i=0;i<dtbRes.Rows.Count;i++)
				{
					lsvDoctor.Items.Add(new ListViewItem(new string[]{dtbRes.Rows[i]["EMPNO_CHR"].ToString().Trim(),dtbRes.Rows[i]["LASTNAME_VCHR"].ToString().Trim(),}));
				}
				lsvDoctor.Tag=dtbRes;

				return 0;
			}
			else
			{
				return -1;
			}
		}

		private long m_lngGetPatientByDoctor(string strFilter,string strDoctortID)
		{
            lsvPatient.Items.Clear();
            clsBIHPatientInfo[] m_arrObjPatient=null;
            string m_strState = "", m_strNursecate = "";
            long lngRes = m_OrderService.m_lngGetPatientByDoctorID(strDoctortID, out  m_arrObjPatient);
            if (m_arrObjPatient == null) return lngRes;
            DataTable dtbRes=new DataTable();
            lngRes = m_OrderService.m_lngGetPatientEatCareByDoctorID(strDoctortID, out dtbRes);
            Hashtable m_HtEatCare = new Hashtable();
            string registerid_chr="",m_strEatName="";
            for (int i = 0; i < dtbRes.Rows.Count; i++)
            {
                registerid_chr=dtbRes.Rows[i]["registerid_chr"].ToString();
                m_strEatName=dtbRes.Rows[i]["name_chr"].ToString();
                if (!m_HtEatCare.Contains(registerid_chr))
                {
                    m_HtEatCare.Add(registerid_chr, m_strEatName);
                }
            }
            for (int i = 0; i < m_arrObjPatient.Length; i++)
            {
                System.Windows.Forms.ListViewItem lviTemp = lsvPatient.Items.Add(m_arrObjPatient[i].m_strInHospitalNo);//住院号
                lviTemp.SubItems.Add(m_arrObjPatient[i].m_strAreaName);//床号
                lviTemp.SubItems.Add(m_arrObjPatient[i].m_strBedName);//床号
                lviTemp.SubItems.Add(m_arrObjPatient[i].m_strPatientName);//姓名
                lviTemp.SubItems.Add(m_arrObjPatient[i].m_strSex);//性别
                
                
                m_strState = "";
                switch (m_arrObjPatient[i].m_strSTATE_INT)
                {
                    case "1":
                        m_strState = "危";
                        break;
                    case "2":
                        m_strState = "急";
                        break;
                    case "3":
                        m_strState = "普通";
                        break;

                }
                lviTemp.SubItems.Add(m_strState);//病情
                if (m_HtEatCare[m_arrObjPatient[i].m_strRegisterID] != null)
                {
                    m_arrObjPatient[i].m_strEatdiccate = m_HtEatCare[m_arrObjPatient[i].m_strRegisterID].ToString();
                }
                else
                {
                    m_arrObjPatient[i].m_strEatdiccate = "";
                }
                lviTemp.SubItems.Add(m_arrObjPatient[i].m_strEatdiccate);//饮食
                m_strNursecate = "";
                //护理等级(-1=普通护理;0=特级护理;1=一级护理;2=二级护理;3=三级护理)
                switch (m_arrObjPatient[i].m_strNursecate)
                {
                    case "-1":
                        m_strNursecate = "普通护理";
                        break;
                    case "0":
                        m_strNursecate = "特级护理";
                        break;
                    case "1":
                        m_strNursecate = "一级护理";
                        break;
                    case "2":
                        m_strNursecate = "二级护理";
                        break;
                    case "3":
                        m_strNursecate = "三级护理";
                        break;

                }
                lviTemp.SubItems.Add(m_strNursecate);//护理

                lviTemp.Tag = m_arrObjPatient[i];
            }
            return lngRes; 






//            DataTable dtbRes=new DataTable();

//            long lngRes=m_OrderService.m_lngGetPatientInfoByDoctorID(strFilter,strDoctortID,out dtbRes);

//            lsvPatient.Items.Clear();

//            if(lngRes==0 && dtbRes.Rows.Count>0)
//            {
//                for(int i=0;i<dtbRes.Rows.Count;i++)
//                {
////					lsvPatient.Items.Add(new ListViewItem(new string[]{dtbRes.Rows[i]["INPATIENTID_CHR"].ToString().Trim(),dtbRes.Rows[i]["LASTNAME_VCHR"].ToString().Trim()}));
//                    svc = new clsDcl_InputOrder();
//                    DataTable dtbResult = null;
//                    long lngReg =svc.m_lngGetPatientInfoByRegisterid(dtbRes.Rows[i]["REGISTERID_CHR"].ToString().Trim(),out dtbResult);
//                    if(lngReg>0 && dtbResult.Rows.Count >0)
//                    {
//                        //住院编号
//                        System.Windows.Forms.ListViewItem lviTemp = new ListViewItem(dtbResult.Rows[0]["INPATIENTID_CHR"].ToString());
//                        //病人姓名
//                        if(dtbResult.Rows[0]["PSTATUS_INT"].ToString().Trim()=="2")
//                        {
//                            lviTemp.SubItems.Add(dtbResult.Rows[0]["NAME_VCHR"].ToString()+"(预出院)");
//                        }
//                        else if(dtbResult.Rows[0]["PSTATUS_INT"].ToString().Trim()=="4")
//                        {
//                            lviTemp.SubItems.Add(dtbResult.Rows[0]["NAME_VCHR"].ToString()+"(请假)");
//                        }
//                        else
//                        {
//                            lviTemp.SubItems.Add(dtbResult.Rows[0]["NAME_VCHR"].ToString());
//                        }
//                        //性别
//                        lviTemp.SubItems.Add(dtbResult.Rows[0]["SEX_CHR"].ToString().Trim());
//                        //病情 {1危、2急、3普通}						
//                        try
//                        {
//                            lviTemp.SubItems.Add(strGetState(Int32.Parse(dtbResult.Rows[0]["STATE_INT"].ToString())));
//                        }
//                        catch
//                        {
//                            lviTemp.SubItems.Add("");
//                        }
//                        DataTable dtbResult0 = null;
//                        DataTable dtbResult1 = null;
//                        svc.m_lngGetSpChargeItemIDType(out dtbResult1);
//                        string id1="";
//                        string id2 = "";
//                        if(dtbResult1.Rows.Count>0)
//                        {
//                            id1= dtbResult1.Rows[0]["EATDICCATE"].ToString();
//                            id2= dtbResult1.Rows[0]["NURSECATE"].ToString();
//                        }
//                        svc.m_lngGetPatientCareInfo(dtbRes.Rows[i]["REGISTERID_CHR"].ToString().Trim(),out dtbResult0);
//                        if(dtbResult0.Rows.Count>0)
//                        {
//                            for(int j =0;j<dtbResult0.Rows.Count;j++)
//                            {
//                                if(dtbResult0.Rows[j]["ordercateid_chr"].ToString()==id1)
//                                {
//                                    lviTemp.SubItems.Add(dtbResult0.Rows[j]["NAME_CHR"].ToString());
//                                }
//                                if(dtbResult0.Rows[j]["ordercateid_chr"].ToString()==id2)
//                                {
//                                    lviTemp.SubItems.Add(dtbResult0.Rows[j]["NAME_CHR"].ToString());
//                                }
//                            }
//                        }
//                        else
//                        {
//                            lviTemp.SubItems.Add("");
//                            lviTemp.SubItems.Add("");
//                        }
//                        lviTemp.Tag = dtbResult.Rows[0];
//                        lsvPatient.Items.Add(lviTemp);

//                    }
//                }
//                lsvPatient.Tag=dtbRes;

//                return 0;
//            }
//            else
//            {
//                return -1;
//            }
		}

        #endregion
        public void setLoginDoctor(com.digitalwave.iCare.ValueObject.clsLoginInfo loginInfo)
		{
			this.LoginInfo = loginInfo;
			this.setDoctor(loginInfo);
		}
		private string strGetState(int p_intState)
		{
			switch (p_intState)
			{
				case 1:
					return "危";
				case 2:
					return "急";
				case 3:
					return "普通";
				default :
					return "";
			}
		}

		private void txtDoctor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				m_lngGetDoctorList(txtDoctor.Text.Trim());
				lsvDoctor.Show();
				lsvDoctor.Focus();
				if(lsvDoctor.Items.Count>0)
				{
					lsvDoctor.Items[0].Selected=true;
				}
			}
		}

		private void txtPatient_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(DoctorID!=null && DoctorID.Trim()!="")
				{
					m_lngGetPatientByDoctor("",DoctorID.Trim());
//					if(txtPatient.Text.Trim()=="")
//					{
//						m_lngGetPatientByDoctor("",DoctorID.Trim());
//					}
//					else
//					{
//						m_lngGetPatientByDoctor(" A.INPATIENTID_CHR LIKE '"+txtPatient.Tag.ToString().Trim()+"%' ",DoctorID.Trim());
//					}
				}
				lsvPatient.Show();
				lsvPatient.Focus();
				if(lsvPatient.Items.Count>0)
				{
//					lsvPatient.Items[0].Selected=true;
				}
			}
		}

		private void lsvDoctor_Leave(object sender, System.EventArgs e)
		{
			lsvDoctor.Hide();
		}


		private void lsvDoctor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			
			if(e.KeyCode==Keys.Enter)
			{
                lsvDoctor_DoubleClick(null, null);
			}
//			else if(e.KeyCode==Keys.Escape)
//			{
//				txtDoctor.Focus();
//				txtDoctor.SelectAll();
//				lsvDoctor.Hide();
//			}
		}

		private void lsvPatient_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(lsvPatient.SelectedItems.Count>0)
				{
					int CurrIndex=lsvPatient.SelectedItems[0].Index;
					this.SelectedIndex = CurrIndex;
					PatientID=((DataRow)lsvPatient.Items[CurrIndex].Tag)["inpatientID_CHR"].ToString().Trim();
					PatientName=((DataRow)lsvPatient.Items[CurrIndex].Tag)["lastname_vCHR"].ToString().Trim();
					txtPatient.Text=PatientName.Trim();
					txtPatient.Tag=PatientID.Trim();
					m_cmdOK.Focus();
					m_cmdOK.Select();
					((frmBIHOrderInput)(this.ParentForm)).m_mthSetCurrentPatient(PatientID.Trim());
					((frmBIHOrderInput)(this.ParentForm)).lblLeft_Click();
				}
			}
		}

		private void frmListDoctor_Load(object sender, System.EventArgs e)
		{
			if(DoctorID.Trim()!="")
			{
				txtDoctor.Tag=DoctorID.Trim();
				txtDoctor.Text=DoctorName.Trim();
				PatientID="";
				PatientName="";
			}
			else
			{
				DoctorID="";
				DoctorName="";
				PatientID="";
				PatientName="";
			}
			if(this.LoginInfo!=null)
			{
				txtDoctor.Tag=this.LoginInfo.m_strEmpID;
				txtDoctor.Text=this.LoginInfo.m_strEmpName;
				PatientID="";
				PatientName="";
				txtPatient_KeyDown(null,new KeyEventArgs(Keys.Enter));
			}
		}

		private void m_cmdCancle_Click(object sender, System.EventArgs e)
		{
			DoctorID="";
			DoctorName="";
			PatientID="";
			PatientName="";
			DialogResult=-1;
			Close();
		}

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			if(lsvPatient.SelectedItems.Count>0)
			{
				int CurrIndex=lsvPatient.SelectedItems[0].Index;
				this.SelectedIndex = CurrIndex;
                //PatientID = ((DataRow)lsvPatient.Items[CurrIndex].Tag)["inpatientID_CHR"].ToString().Trim();
                //PatientName = ((DataRow)lsvPatient.Items[CurrIndex].Tag)["lastname_vCHR"].ToString().Trim();
                PatientID = ((clsBIHPatientInfo)lsvPatient.Items[CurrIndex].Tag).m_strInHospitalNo;
                PatientName = ((clsBIHPatientInfo)lsvPatient.Items[CurrIndex].Tag).m_strPatientName;
            
                txtPatient.Text = PatientName.Trim();
                txtPatient.Tag = PatientID.Trim();
                if (DialogResult == 0 && PatientID != null && PatientID != "")
                {
                    ((frmBIHOrderInput)(this.ParentForm)).m_mthSetCurrentPatient(PatientID.Trim());
                    ((frmBIHOrderInput)(this.ParentForm)).lblLeft_Click();
                }
			}
			else
			{
				MessageBox.Show("请选择病人");
			}
		}

		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			DialogResult=-2;
			Close();
		}

		private void txtDoctor_Enter(object sender, System.EventArgs e)
		{
			label3.Show();
		}

		private void txtDoctor_Leave(object sender, System.EventArgs e)
		{
			label3.Hide();
		}

		private void lsvPatient_DoubleClick(object sender, System.EventArgs e)
		{
			int CurrIndex=lsvPatient.SelectedItems[0].Index;
			this.SelectedIndex = CurrIndex;
            //PatientID=((DataRow)lsvPatient.Items[CurrIndex].Tag)["inpatientID_CHR"].ToString().Trim();
            //PatientName=((DataRow)lsvPatient.Items[CurrIndex].Tag)["lastname_vCHR"].ToString().Trim();
            PatientID = ((clsBIHPatientInfo)lsvPatient.Items[CurrIndex].Tag).m_strInHospitalNo;
            PatientName = ((clsBIHPatientInfo)lsvPatient.Items[CurrIndex].Tag).m_strPatientName;
            
            txtPatient.Text=PatientName.Trim();
			txtPatient.Tag=PatientID.Trim();
			m_cmdOK.Focus();
			m_cmdOK.Select();
			((frmBIHOrderInput)(this.ParentForm)).m_mthSetCurrentPatient(PatientID.Trim());
			((frmBIHOrderInput)(this.ParentForm)).lblLeft_Click();
		}

		internal void lsvPatientItemSelected()
		{
			this.lsvPatient.Focus();
			if(this.lsvPatient.Items.Count>this.SelectedIndex&&this.SelectedIndex>=0)
			{
				this.lsvPatient.Items[this.SelectedIndex].Selected = true;		
			}
		}
		internal void SetPatient(string p_strInpatientid)
		{
			if(this.lsvPatient.Items.Count>0)
			{
				for(int i = 0;i<this.lsvPatient.Items.Count;i++)
				{
                    if (p_strInpatientid == ((clsBIHPatientInfo)this.lsvPatient.Items[i].Tag).m_strInHospitalNo)
					{
						this.SelectedIndex = i;
						this.lsvPatientItemSelected();
						return;
					}
				}
			}
		}

        private void lsvDoctor_DoubleClick(object sender, EventArgs e)
        {
            if (lsvDoctor.SelectedItems.Count > 0)
            {
                int CurrIndex = lsvDoctor.SelectedItems[0].Index;
                DoctorID = ((DataTable)lsvDoctor.Tag).Rows[CurrIndex]["EMPID_CHR"].ToString().Trim();
                DoctorName = ((DataTable)lsvDoctor.Tag).Rows[CurrIndex]["LASTNAME_VCHR"].ToString().Trim();
                txtDoctor.Text = DoctorName.Trim();
                txtDoctor.Tag = DoctorID.Trim();
                lsvDoctor.Hide();
                txtPatient_KeyDown(null, new KeyEventArgs(Keys.Enter));
            }
           
        }

      
     

	}
}
