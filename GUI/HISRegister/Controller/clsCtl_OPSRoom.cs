using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsCtl_OPSRoom 的摘要说明。
	/// </summary>
	public class clsCtl_OPSRoom : com.digitalwave.GUI_Base.clsController_Base
	{
        /// <summary>
        /// 0 申请单 1 报告单
        /// </summary>
        private int billflag = 0;
        /// <summary>
        /// 单号
        /// </summary>
        private string applyid = "";
         /// <summary>
        /// 单号,用于断定是否内容修改过.
        /// </summary>
        private string m_strApplyId = "";
         
        private string[] anamode;

        private clsDcl_DoctorWorkstation objSvc;
		public clsCtl_OPSRoom()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
            objSvc = new clsDcl_DoctorWorkstation();
		}
        /// <summary>
        /// 是否接受新值.
        /// </summary>
        public DialogResult DialogResultCancel = DialogResult.OK;
        /// <summary>
        /// 记录上一次选择项
        /// </summary>
        public int m_lsvReportPrvSelectIndex = -1;
		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmOPSRoom m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmOPSRoom)frmMDI_Child_Base_in;
		}
		#endregion

		#region 初始化
		/// <summary>
		/// 初始化
		/// </summary>
		public void m_mthInit()
		{
			for(int i=0; i<m_objViewer.outlookBar.Bands.Count; i++)
			{
				if(m_objViewer.outlookBar.Bands[i].ChildControl != null)
					m_objViewer.outlookBar.Bands[i].ChildControl.Parent = m_objViewer.outlookBar;
			}

			for(int i=m_objViewer.outlookBar.Bands.Count-1; i>=0; i--)
			{
				m_objViewer.outlookBar.CurrentBand = i;		
			}

			string Hospitalname = new com.digitalwave.iCare.common.clsCommmonInfo().m_strGetHospitalTitle();
			this.m_objViewer.lblAppTitle.Text = Hospitalname + "门诊手术申请单";
			this.m_objViewer.lblRepTitle.Text = Hospitalname + "门诊手术记录单";

			m_mthSelectBill(0);

            clsCtl_OPSApply objCls = new clsCtl_OPSApply();
            objCls.m_mthSetTextBoxControlsBackColor(new Control[] {
                        this.m_objViewer.txtRepOPSName,
                        this.m_objViewer.txtRepDiagbegin,
                        this.m_objViewer.txtRepDiagend,
                        this.m_objViewer.txtRepMaindoctor,
                        this.m_objViewer.txtRepAssidoctor,
                        this.m_objViewer.txtRepMedtool,
                        this.m_objViewer.txtRepAnadoctor,
                        this.m_objViewer.txtRepOPSStepandResult,
                        this.m_objViewer.txtRepDoctor,
                        this.m_objViewer.txtRepSigndate
            });
		}
		#endregion

		#region 选择表单
		/// <summary>
		/// 选择表单
		/// </summary>
		/// <param name="index">0 申请单 1 报告单</param>
		public void m_mthSelectBill(int index)
		{
			if(index==0)
			{
				this.m_objViewer.panelReport.Visible = false;
				this.m_objViewer.panelApply.Visible = true;
				this.m_objViewer.panelApply.BringToFront();
			}
			else if(index==1)
			{
				this.m_objViewer.panelApply.Visible = false;
				this.m_objViewer.panelReport.Visible = true;
				this.m_objViewer.panelReport.BringToFront();
			}			
		}
		#endregion

		#region 清空表单
		/// <summary>
		/// 清空表单
		/// </summary>
		/// <param name="Control"></param>
		public void m_mthClear(Control Ctl)
		{
			string Type = Ctl.GetType().FullName;
			
			if(Ctl.AccessibleName.Trim().ToUpper().StartsWith("T"))
			{
				switch( Type )
				{
					case "System.Windows.Forms.TextBox":
						Ctl.Text = "";
						break;
					case "com.digitalwave.Utility.Controls.ctlRichTextBox":
						Ctl.Text = "";
						break;
				}
			}

			foreach(Control Ctlchild in Ctl.Controls)
			{
				m_mthClear(Ctlchild);
			}
		}
		#endregion

        #region 判断是否显示未收费手术申请单
        /// <summary>
        /// 判断是否显示未收费手术申请单
        /// </summary>
        /// <returns></returns>
        private int m_intIsshowchrgops()
        {
            int ischrg = 0;
            DataTable dt = new DataTable();
            long ret = objSvc.m_lngGetWSParm("0048", out dt);		//0048 判断是否显示未收费手术申请单
            if (ret > 0 && dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["SETSTATUS_INT"].ToString().Trim() == "1")
                {
                    ischrg = 1;
                }
            }

            return ischrg;
        }
        #endregion

        #region 检索申请信息
        /// <summary>
        /// 检索申请信息
        /// </summary>
        public void m_mthGetappinfo(int flag)
        {
            int ischrg = this.m_intIsshowchrgops();
            DataTable dtRecord = new DataTable();
           
            long ret = objSvc.m_lngGetOPSApply(out dtRecord, "", "", flag, ischrg);

            if (flag == 1)
            {
                this.m_objViewer.lvApply.BeginUpdate();
                this.m_objViewer.lvApply.Items.Clear();
            }
            else if (flag == 2)
            {
                this.m_objViewer.lvReport.BeginUpdate();
                this.m_objViewer.lvReport.Items.Clear();
            }
                        
            if (ret > 0 && dtRecord.Rows.Count > 0)
            {                
                DateTime dteBirth;
                string age = "";
                for (int i = 0; i < dtRecord.Rows.Count; i++)
                {
                    if (dtRecord.Rows[i]["pstauts_int"].ToString().Trim() == "-2")
                    {
                        if (this.m_objViewer.m_chkTui.Checked == false)
                            continue;
                    }

                    //申请单号
                    ListViewItem lv = new ListViewItem(dtRecord.Rows[i]["applyid_vchr"].ToString());                                                       
                    //申请科室
                    lv.SubItems.Add(dtRecord.Rows[i]["deptname_vchr"].ToString());
                    //姓名
                    lv.SubItems.Add(dtRecord.Rows[i]["name_vchr"].ToString());
                    //性别
                    lv.SubItems.Add(dtRecord.Rows[i]["sex_chr"].ToString());
                    //年龄
                    dteBirth = Convert.ToDateTime(dtRecord.Rows[i]["birth_dat"].ToString());
                    age = com.digitalwave.controls.clsArithmetic.CalcAge(dteBirth);
                    lv.SubItems.Add(age);

                    if (flag == 1)
                    {
                        //申请时间
                        lv.SubItems.Add(((DateTime)dtRecord.Rows[i]["opsbookingdate_dat"]).ToString("yyyy/MM/dd HH:mm"));
                    }
                    else if (flag == 2)
                    {
                        //确认时间
                        lv.SubItems.Add(((DateTime)dtRecord.Rows[i]["confirmdate_dat"]).ToString("yyyy/MM/dd HH:mm"));

                        if (dtRecord.Rows[i]["repflag"] != null && dtRecord.Rows[i]["repflag"].ToString().Trim() != "")
                        {
                            lv.BackColor = Color.FromArgb(222, 239, 165);
                        }
                    }

                    lv.Tag = dtRecord.Rows[i];

                    if (flag == 1)
                    {
                        if (ischrg != 1)
                        {
                            if (dtRecord.Rows[i]["pstauts_int"].ToString().Trim() == "2" || dtRecord.Rows[i]["pstauts_int"].ToString().Trim() == "-2")
                            {
                                this.m_objViewer.lvApply.Items.Add(lv);
                            }
                        }
                        else
                        {
                            this.m_objViewer.lvApply.Items.Add(lv);
                        }
                        if( dtRecord.Rows[i]["pstauts_int"].ToString().Trim() == "-2")
                        {
                            lv.ForeColor = Color.Red;
                        }
                    }
                    else if (flag == 2)
                    {
                        this.m_objViewer.lvReport.Items.Add(lv);
                    }
                }
            }

            if (flag == 1)
            {
                this.m_objViewer.lvApply.EndUpdate();
            }
            else if (flag == 2)
            {
                this.m_objViewer.lvReport.EndUpdate();
            }
        }
        #endregion

        #region 申请单赋值
        /// <summary>
        /// 申请单赋值
        /// </summary>
        public void m_mthSetappvalue()
        {
            if (this.m_objViewer.lvApply.SelectedItems.Count > 0)
            {
                DataRow dr = (DataRow)(this.m_objViewer.lvApply.SelectedItems[0].Tag);

                //年龄
                DateTime dteBirth = Convert.ToDateTime(dr["birth_dat"].ToString());
                string age = com.digitalwave.controls.clsArithmetic.CalcAge(dteBirth);

                //预约时间
                string bookingdate = ((DateTime)dr["opsbookingdate_dat"]).ToString("yyyy-MM-dd HH:mm");

                applyid = dr["applyid_vchr"].ToString();
                this.m_objViewer.lblAppNO.Text = "NO: " + applyid;
                this.m_objViewer.lblAppName.Text = dr["name_vchr"].ToString();
                this.m_objViewer.lblAppSex.Text = dr["sex_chr"].ToString();
                this.m_objViewer.lblAppAge.Text = age;
                this.m_objViewer.lblAppCardNo.Text = dr["patientcardid_chr"].ToString();                
                this.m_objViewer.lblAppDept.Text = dr["deptname_vchr"].ToString();
                this.m_objViewer.lblAppOPSName.Text = dr["itemname_vchr"].ToString();
                this.m_objViewer.lblAppYear.Text = bookingdate.Substring(0, 4);
                this.m_objViewer.lblAppMonth.Text = bookingdate.Substring(5, 2);
                this.m_objViewer.lblAppDay.Text = bookingdate.Substring(8, 2);
                this.m_objViewer.lblAppHour.Text = bookingdate.Substring(11, 2);
                this.m_objViewer.lblAppMinute.Text = bookingdate.Substring(14, 2);
                this.m_objViewer.lblAppHint.Text = dr["note_vchr"].ToString();
                this.m_objViewer.lblAppDoctor.Text = dr["lastname_vchr"].ToString();
                this.m_objViewer.lblAppDate.Text = ((DateTime)dr["recorddate_dat"]).ToString("yyyy年MM月dd日");

                billflag = 0;
                //this.m_objViewer.btnPrint.Enabled = false;
                //this.m_objViewer.btnSave.Enabled = false;                
            }
        }
        #endregion

        #region 根据员工信息查相关信息
        /// <summary>
        /// 根据员工名称,找ID
        /// </summary>
        /// <param name="p_strSQLWhere"></param>
        /// <param name="p_strEmployeeArr"></param>
        /// <returns></returns>
        private long m_intGetEmployeeInfo(string p_strSQLWhere, out string[,] p_strEmployeeArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                           (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long ret = objSvc.m_lngGetEmployeeNameByID(p_strSQLWhere, out p_strEmployeeArr);
            return ret;
        }
        /// <summary>
        /// 根据ID,找员工名称
        /// </summary>
        /// <param name="p_strSQLWhere"></param>
        /// <returns></returns>
        private string  m_intGetEmployeeNameInfoByID(string p_strSQLWhere)
        {
            string strRet = "";
            string[,] strEmployeeArr = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                           (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long ret = objSvc.m_lngGetEmployeeNameByID(p_strSQLWhere, out strEmployeeArr);
            if (ret >=0)
            {
                if (strEmployeeArr != null )
                {
                   strRet =  strEmployeeArr[0, 1].ToString();
                }
            }
            return strRet;
        }
        #endregion 
        /// <summary>
        /// 暂存手术名称
        /// </summary>
        private string strOPSName = "";
        #region 报告单赋值
        /// <summary>
        /// 报告单赋值
        /// </summary>
        /// <param name="dr"></param>
        public void m_mthSetreportvalue(DataRow dr)
        {
            //年龄
            DateTime dteBirth = Convert.ToDateTime(dr["birth_dat"].ToString());
            string age = com.digitalwave.controls.clsArithmetic.CalcAge(dteBirth);
            
            applyid = dr["applyid_vchr"].ToString();
            m_strApplyId = applyid;
            this.m_objViewer.lblRepNO.Text = "NO: " + applyid;
            this.m_objViewer.lblRepName.Text = dr["name_vchr"].ToString();
            this.m_objViewer.lblRepSex.Text = dr["sex_chr"].ToString();
            this.m_objViewer.lblRepAge.Text = age;
            this.m_objViewer.lblRepCardNo.Text = dr["patientcardid_chr"].ToString();
            this.m_objViewer.lblRepDept.Text = dr["deptname_vchr"].ToString();

            DataTable dt = new DataTable();
            long ret = objSvc.m_lngGetopsrecord(applyid, out dt);
            if (dt.Rows.Count == 1)
            {
                //手术时间
                string opsdate = ((DateTime)dt.Rows[0]["opsdate_dat"]).ToString("yyyy-MM-dd");
                //麻醉方式
                int index = 0;
                string anamodecode = dt.Rows[0]["opsanamode_chr"].ToString();
                for (int i = 0; i < anamode.Length; i++)
                {
                    if (anamodecode == anamode[i])
                    {
                        index = i;
                        break;
                    }
                }

                this.m_objViewer.lblRepYear.Text = opsdate.Substring(0, 4);
                this.m_objViewer.lblRepMonth.Text = opsdate.Substring(5, 2);
                this.m_objViewer.lblRepDay.Text = opsdate.Substring(8, 2);
                this.m_objViewer.txtRepOPSName.Text = dt.Rows[0]["opsname_vchr"].ToString();
                this.m_objViewer.txtRepDiagbegin.Text = dt.Rows[0]["prediagnoses_vchr"].ToString();
                this.m_objViewer.txtRepDiagend.Text = dt.Rows[0]["enddiagnoses_vchr"].ToString();
                this.m_objViewer.txtRepMaindoctor.Tag = dt.Rows[0]["opsdoctor_chr"].ToString();
                this.m_objViewer.txtRepMaindoctor.Text = m_intGetEmployeeNameInfoByID(" empid_chr ='" + dt.Rows[0]["opsdoctor_chr"].ToString() + "'");
                this.m_objViewer.txtRepAssidoctor.Tag = dt.Rows[0]["opsassistant1_chr"].ToString();
                this.m_objViewer.txtRepAssidoctor.Text = m_intGetEmployeeNameInfoByID(" empid_chr ='" + dt.Rows[0]["opsassistant1_chr"].ToString() + "'");
                this.m_objViewer.txtRepMedtool.Tag = dt.Rows[0]["opsappliance_chr"].ToString();
                this.m_objViewer.txtRepMedtool.Text = m_intGetEmployeeNameInfoByID(" empid_chr ='" + dt.Rows[0]["opsappliance_chr"].ToString() + "'");
                this.m_objViewer.cboAnamode.SelectedIndex = index;
                this.m_objViewer.txtRepAnadoctor.Tag = dt.Rows[0]["anaemp1_chr"].ToString();
                this.m_objViewer.txtRepAnadoctor.Text = m_intGetEmployeeNameInfoByID(" empid_chr ='" + dt.Rows[0]["anaemp1_chr"].ToString() + "'");
                this.m_objViewer.txtRepOPSStepandResult.Text = dt.Rows[0]["opsresult_vchr"].ToString();
                this.m_objViewer.txtRepDoctor.Tag = dt.Rows[0]["signdoctor_chr"].ToString();
                this.m_objViewer.txtRepDoctor.Text = m_intGetEmployeeNameInfoByID(" empid_chr ='" + dt.Rows[0]["signdoctor_chr"].ToString() + "'");
                this.m_objViewer.txtRepSigndate.Text = ((DateTime)dt.Rows[0]["signdate_dat"]).ToString("yyyy-MM-dd");
                if ( dt.Rows[0]["status_int"].ToString().Trim()== "1")
                {
                    this.m_objViewer.lblRepsave.Text = "已审核";
                }
                else
                {
                    this.m_objViewer.lblRepsave.Text = "已保存";
                }
            }
            else
            {
                this.m_objViewer.lblRepYear.Text = "";
                this.m_objViewer.lblRepMonth.Text = "";
                this.m_objViewer.lblRepDay.Text = "";

                this.m_objViewer.txtRepOPSName.Text = dr["itemname_vchr"].ToString();
                strOPSName = this.m_objViewer.txtRepOPSName.Text;
                this.m_objViewer.txtRepDiagbegin.Text = "";
                this.m_objViewer.txtRepDiagend.Text = "";
                this.m_objViewer.txtRepMaindoctor.Text = "";
                this.m_objViewer.txtRepAssidoctor.Text = "";
                this.m_objViewer.txtRepMedtool.Text = "";
                this.m_objViewer.cboAnamode.SelectedIndex = 0;
                this.m_objViewer.txtRepAnadoctor.Text = "";
                this.m_objViewer.txtRepOPSStepandResult.Text = "";
                this.m_objViewer.txtRepDoctor.Tag = this.m_objViewer.LoginInfo.m_strEmpID;
                this.m_objViewer.txtRepDoctor.Text = this.m_objViewer.LoginInfo.m_strEmpName;
                this.m_objViewer.txtRepSigndate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                this.m_objViewer.lblRepsave.Text = "";
            }

            this.m_mthSelectBill(1);
            billflag = 1;
        }
        #endregion

        #region 确认更改后是否保存
        /// <summary>
        /// 确认更改后是否保存
        /// </summary>
        /// <returns>是否通过,转到另一操作.</returns>
        public bool m_blnCheckAlterToSave()
        {
            if (m_strApplyId == "")
            {
                return true;
            }
            bool blnAlter = false;
            bool blnSuccess = false;
            string strWainIng = "报告内容已经修改，是否保存？";
            DataTable dt = new DataTable();

            long ret = objSvc.m_lngGetopsrecord(m_strApplyId, out dt);
            if (dt.Rows.Count == 1)
            {
                //麻醉方式
                int index = 0;
                string anamodecode = dt.Rows[0]["opsanamode_chr"].ToString();
                for (int i = 0; i < anamode.Length; i++)
                {
                    if (anamodecode == anamode[i])
                    {
                        index = i;
                        break;
                    }
                }
                if(this.m_objViewer.txtRepOPSName.Text != dt.Rows[0]["opsname_vchr"].ToString())
                    blnAlter = true;
                if(this.m_objViewer.txtRepDiagbegin.Text != dt.Rows[0]["prediagnoses_vchr"].ToString())
                    blnAlter = true ;
                if(this.m_objViewer.txtRepDiagend.Text != dt.Rows[0]["enddiagnoses_vchr"].ToString())
                    blnAlter = true ;
                if(this.m_objViewer.txtRepMaindoctor.Tag.ToString() != dt.Rows[0]["opsdoctor_chr"].ToString())
                    blnAlter = true ;
                if(this.m_objViewer.txtRepAssidoctor.Tag.ToString() != dt.Rows[0]["opsassistant1_chr"].ToString())
                    blnAlter = true ;
                if(this.m_objViewer.txtRepMedtool.Tag.ToString() != dt.Rows[0]["opsappliance_chr"].ToString())
                    blnAlter = true ;
                if(this.m_objViewer.cboAnamode.SelectedIndex != index)
                blnAlter = true;
                if  (this.m_objViewer.txtRepAnadoctor.Tag.ToString() != dt.Rows[0]["anaemp1_chr"].ToString())
                    blnAlter = true ;
                if(this.m_objViewer.txtRepOPSStepandResult.Text != dt.Rows[0]["opsresult_vchr"].ToString())
                    blnAlter = true ;
                if(this.m_objViewer.txtRepDoctor.Tag.ToString() != dt.Rows[0]["signdoctor_chr"].ToString())
                    blnAlter = true ;
                if(this.m_objViewer.txtRepSigndate.Text != ((DateTime)dt.Rows[0]["signdate_dat"]).ToString("yyyy-MM-dd"))
                    blnAlter = true ;
            }
            else
            {
                //麻醉方式
                if (this.m_objViewer.cboAnamode.Items.Count>0)
                {
                    if (this.m_objViewer.cboAnamode.SelectedIndex != 0)
                    {
                        blnAlter = true;
                    }
                }
                if (this.m_objViewer.txtRepOPSName.Text != strOPSName)
                    blnAlter = true;
                if (this.m_objViewer.txtRepDiagbegin.Text != "")
                    blnAlter = true;
                if (this.m_objViewer.txtRepDiagend.Text != "")
                    blnAlter = true;
                if (this.m_objViewer.txtRepMaindoctor.Text != "")
                    blnAlter = true;
                if (this.m_objViewer.txtRepAssidoctor.Text != "")
                    blnAlter = true;
                if (this.m_objViewer.txtRepMedtool.Text != "")
                    blnAlter = true;
                if (this.m_objViewer.txtRepAnadoctor.Text != "")
                    blnAlter = true;
                if (this.m_objViewer.txtRepOPSStepandResult.Text != "")
                    blnAlter = true;
                if (this.m_objViewer.txtRepDoctor.Text != this.m_objViewer.LoginInfo.m_strEmpName)
                    blnAlter = true;
                if (this.m_objViewer.txtRepSigndate.Text != DateTime.Now.ToString("yyyy-MM-dd"))
                    blnAlter = true;
            }
            if (blnAlter)
            {
                DialogResult dret = MessageBox.Show(strWainIng, "系统提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dret == DialogResult.Yes)
                {
                    blnSuccess = m_mthSave();
                }
                else if (dret == DialogResult.No)
                {
                    blnSuccess = true;
                }
                else if (dret == DialogResult.Cancel)
                {
                    DialogResultCancel = DialogResult.Cancel;
                    blnSuccess = false;
                }
            }
            else
            {
                blnSuccess = true ;
            }
            return blnSuccess;
        }
        #endregion 
        #region 审核(确认)
        /// <summary>
        /// 审核(确认)
        /// </summary>
        public void m_mthConfirm()
        {
            if (billflag != 0)
            {
                return;
            }

            if (applyid == "")
            {
                return;
            }

            frmOPSConfirm fc = new frmOPSConfirm();
            if (fc.ShowDialog() == DialogResult.OK)
            {
                string empid = fc.Empid;
                long ret = objSvc.m_lngConfrimOPS(applyid, empid);
                if (ret > 0)
                {
                    MessageBox.Show("申请单确认成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    this.m_objViewer.Cursor = Cursors.WaitCursor;
                    m_objViewer.outlookBar.CurrentBand = 1;
                    this.m_mthGetappinfo(2);
                    

                    for (int i = 0; i < this.m_objViewer.lvApply.Items.Count; i++)
                    {
                        if (this.m_objViewer.lvApply.Items[i].SubItems[0].Text == applyid)
                        {
                            this.m_objViewer.lvApply.Items[i].Remove();
                            break;
                        }
                    }

                    for (int j = 0; j < this.m_objViewer.lvReport.Items.Count; j++)
                    {
                        if (this.m_objViewer.lvReport.Items[j].SubItems[0].Text == applyid)
                        {
                            DataRow dr = (DataRow)(this.m_objViewer.lvReport.Items[j].Tag);
                            this.m_mthSetreportvalue(dr);
                            break;
                        }
                    }

                    this.m_mthSelectBill(1);
                    this.m_objViewer.Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("确认申请单失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        /// <summary>
        /// 报告单审核(确认)
        /// </summary>
        public void m_mthConfirmReport()
        {
            if (billflag != 1)
            {
                return;
            }

            if (applyid == "")
            {
                return;
            }
            if (this.m_objViewer.lblRepsave.Text.Trim() == "已审核")
            {
                MessageBox.Show("报告已审核,不能重复审核。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            frmOPSConfirm fc = new frmOPSConfirm();
            if (fc.ShowDialog() == DialogResult.OK)
            {
                string empid = fc.Empid;
                long ret = objSvc.m_lngConfrimOPSReport(applyid, empid);
                if (ret > 0)
                {
                    MessageBox.Show("报告审核成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_objViewer.outlookBar.CurrentBand = 1;
                    this.m_objViewer.lblRepsave.Text = "已审核";
                }
                else
                {
                    MessageBox.Show("确认申请单失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        #endregion

        #region 不允许任意录入非员工字典里面的人员
        /// <summary>
        ///  不允许任意录入非员工字典里面的人员
        /// </summary>
        /// <returns></returns>
        private bool m_blnCheckEmployeeIn(string p_strWhere,Control p_ctl)
        {
            bool blnRes = false;
            string[,] strEmployeeArr = null;
            long res = m_intGetEmployeeInfo(p_strWhere, out  strEmployeeArr);
            if (res < 0 )
            {
                MessageBox.Show("数据库操作失败,请联系系统管理员。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                p_ctl.Focus();
                p_ctl.Text = "";
                blnRes = false ;
            }
            else if (res == 0)
            {
                MessageBox.Show("不允许任意录入非员工字典里面的人员,请重新选择输入", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                p_ctl.Focus();
                p_ctl.Text = "";
                blnRes = false;
            }
            else if (res == 1)
            {
                if (p_ctl.Tag != null)
                {
                    if (p_ctl.Tag.ToString() != "")
                    {
                        blnRes = true ;
                        return blnRes;
                    }
                }
                if (strEmployeeArr != null )
                {
                    if (strEmployeeArr.Length > 2)
                    {
                        MessageBox.Show("员工字典里面的存在多个相同名称选项,请选择", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        p_ctl.Focus();
                        clsAssistantInput objAInput = new clsAssistantInput(p_ctl, this.m_objViewer.PointToClient(this.m_objViewer.panelReport.PointToScreen(new Point(((Control)p_ctl).Left, ((Control)p_ctl).Bottom))));
                        objAInput.m_mthSetEmployeeName();
                        blnRes = false;
                    }
                    else
                    {
                        p_ctl.Tag = strEmployeeArr[0, 0].ToString();
                        blnRes = true ;
                    }
                }
            }
            return blnRes;
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        public bool m_mthSave()
        {
            bool blnSuccess = false;

            if (billflag != 1)
            {
                return false;
            }

            if (applyid == "")
            {
                return false;
            }
            if (this.m_objViewer.lblRepsave.Text == "已审核")
            {
                MessageBox.Show("报告已审核,不能再修改。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (this.m_objViewer.txtRepOPSName.Text.Trim() == "")
            {
                MessageBox.Show("手术名称不能为空。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (this.m_objViewer.txtRepMaindoctor.Text.Trim() == "")
            {
                MessageBox.Show("手术者(主刀医生)不能为空。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            try
            {
                Convert.ToDateTime(this.m_objViewer.txtRepSigndate.Text.Trim());
            }
            catch (Exception)
            {
                MessageBox.Show("签名日期格式不正确。(正确例子:2006-03-29)", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.m_objViewer.txtRepSigndate.Focus();
                return false;
            }
            bool blnCheck ;
            blnCheck = m_blnCheckEmployeeIn(" lastname_vchr ='" + m_objViewer.txtRepMaindoctor.Text.Trim() + "'", m_objViewer.txtRepMaindoctor);
            if (!blnCheck)
            { return false; }
            blnCheck = m_blnCheckEmployeeIn(" lastname_vchr ='" + m_objViewer.txtRepAssidoctor.Text.Trim() + "'", m_objViewer.txtRepAssidoctor);
            if (!blnCheck)
            { return false; }
            blnCheck = m_blnCheckEmployeeIn(" lastname_vchr ='" + m_objViewer.txtRepMedtool.Text.Trim() + "'", m_objViewer.txtRepMedtool);
            if (!blnCheck)
            { return false; }
            blnCheck = m_blnCheckEmployeeIn(" lastname_vchr ='" + m_objViewer.txtRepAnadoctor.Text.Trim() + "'", m_objViewer.txtRepAnadoctor);
            if (!blnCheck)
            { return false; }
            blnCheck = m_blnCheckEmployeeIn(" lastname_vchr ='" + m_objViewer.txtRepDoctor.Text.Trim() + "'", m_objViewer.txtRepDoctor);
            if (!blnCheck)
            { return false; }
            int index = this.m_objViewer.cboAnamode.SelectedIndex;

            clsOutops_VO objops_vo = new clsOutops_VO();
            objops_vo.applyid = applyid;
            objops_vo.opsname = this.m_objViewer.txtRepOPSName.Text.Trim();
            objops_vo.opsdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            objops_vo.prediagnoses = this.m_objViewer.txtRepDiagbegin.Text.Trim();
            objops_vo.enddiagnoses = this.m_objViewer.txtRepDiagend.Text.Trim();
            //objops_vo.opsdoctor = this.m_objViewer.txtRepMaindoctor.Text.Trim();
            objops_vo.opsdoctor = this.m_objViewer.txtRepMaindoctor.Tag.ToString().Trim();
            objops_vo.opsassistant1 = this.m_objViewer.txtRepAssidoctor.Tag.ToString().Trim();
            objops_vo.opsappliance = this.m_objViewer.txtRepMedtool.Tag.ToString().Trim();
            objops_vo.opsanamode = anamode[index];
            objops_vo.anaempid1 = this.m_objViewer.txtRepAnadoctor.Tag.ToString().Trim();
            objops_vo.opsresult = this.m_objViewer.txtRepOPSStepandResult.Text.Trim();
            objops_vo.signdoctor = this.m_objViewer.txtRepDoctor.Tag.ToString().Trim();
            objops_vo.signdate = this.m_objViewer.txtRepSigndate.Text.Trim();

            long ret = objSvc.m_lngSaveOPS(applyid, objops_vo);
            if (ret > 0)
            {
                this.m_objViewer.lblRepsave.Text = "已保存";
                blnSuccess = true;
                MessageBox.Show("手术报告单信息保存成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                blnSuccess = false;
                MessageBox.Show("手术报告单信息保存失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return blnSuccess;
        }
        #endregion

        #region 打印
        /// <summary>
        /// 打印
        /// </summary>
        public void m_mthPrint()
        {
            if (billflag == 0)
            {
                return;
            }
            if (applyid == "")
                return;
            if (this.m_objViewer.lblRepsave.Text.Trim() != "已审核")
            {
                MessageBox.Show("报告尚未审核,不能打印报告。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return ;
            }
            frmOPCrytalReport fp = new frmOPCrytalReport(2);
            fp.TextYearRoom = this.m_objViewer.lblRepYear.Text;
            fp.TextMonthRoom = this.m_objViewer.lblRepMonth.Text;
            fp.TextdayRoom = this.m_objViewer.lblRepDay.Text;
            fp.TextNameRoom = this.m_objViewer.lblRepName.Text;
            fp.Text1SexRoom = this.m_objViewer.lblRepSex.Text;
            fp.Text1AgeRoom = this.m_objViewer.lblRepAge.Text;
            fp.Text1CardRoom = this.m_objViewer.lblRepCardNo.Text;
            fp.TextDeptRoom =  this.m_objViewer.lblRepDept.Text;
            fp.TextDiagoseRoom = this.m_objViewer.txtRepDiagbegin.Text;
            fp.TextDialogseAfterRoom = this.m_objViewer.txtRepDiagend.Text;
            fp.TextOPERRoom = this.m_objViewer.txtRepMaindoctor.Text;
            fp.TextHelperRoom = this.m_objViewer.txtRepAnadoctor.Text;
            fp.TextCarRoom = this.m_objViewer.txtRepMedtool.Text;
            fp.TextWayRoom = this.m_objViewer.cboAnamode.Text;
            fp.TextWayERRoom = this.m_objViewer.txtRepAnadoctor.Text;
            fp.TextStepRoom = this.m_objViewer.txtRepOPSStepandResult.Text;
            fp.TextDocNameRoom = this.m_objViewer.txtRepDoctor.Text;
            fp.TextTimeRoom = this.m_objViewer.txtRepSigndate.Text;
            fp.TextOPNameRoom = this.m_objViewer.txtRepOPSName.Text;                 

            fp.ShowDialog();   
        }
        #endregion

        #region 设置焦点
        /// <summary>
        /// 设置焦点
        /// </summary>
        /// <param name="kea"></param>
        /// <param name="ctl"></param>
        public void m_mthSetfoucs(KeyEventArgs kea, string ctl)
        {
            if (kea.KeyCode == Keys.Enter)
            {
                switch (ctl)
                {
                    case "txtRepOPSName":
                        this.m_objViewer.txtRepDiagbegin.Focus();
                        break;
                    case "txtRepDiagbegin":
                        this.m_objViewer.txtRepDiagend.Focus();
                        break;
                    case "txtRepDiagend":
                        this.m_objViewer.txtRepMaindoctor.Focus();
                        break;
                    case "txtRepMaindoctor":
                        this.m_objViewer.txtRepAssidoctor.Focus();
                        break;
                    case "txtRepAssidoctor":
                        this.m_objViewer.txtRepMedtool.Focus();                                            
                        break;
                    case "txtRepAnamode":
                        this.m_objViewer.txtRepAnadoctor.Focus();
                        break;
                    case "txtRepAnadoctor":
                        this.m_objViewer.txtRepOPSStepandResult.Focus();
                        break;
                    case "txtRepDoctor":
                        this.m_objViewer.txtRepSigndate.Focus();
                        break;                        
                }                
            }
        }
        #endregion

        #region 查找
        /// <summary>
        /// 查找 type 0 申请 1 报告
        /// </summary>
        public void m_mthFind(int type)
        {
            if (type == 0)
            {
                frmOPSFindapply fa = new frmOPSFindapply(0);
                fa.ShowDialog();
            }
            else if (type == 1)
            {
                frmOPSFindreport ff = new frmOPSFindreport();
                if (ff.ShowDialog() == DialogResult.OK)
                {
                    applyid = ff.Applyid;
                    m_strApplyId= ff.Applyid;
                    this.m_objViewer.Cursor = Cursors.WaitCursor;

                    DataTable dt = new DataTable();
                    long ret = objSvc.m_lngGetOPSApply(out dt, applyid);
                    if (dt.Rows.Count == 1)
                    {
                        this.m_mthSetreportvalue(dt.Rows[0]);
                        this.m_mthSelectBill(1);
                    }
                    this.m_objViewer.Cursor = Cursors.Default;
                }
            }
        }
        #endregion
        
        #region 设置麻醉方式
        /// <summary>
        /// 设置麻醉方式
        /// </summary>
        public void m_mthSetanamode()
        {
            DataTable dt = new DataTable();
            long ret = objSvc.m_lngGetanaesthesiamode(out dt);
            if (dt.Rows.Count > 0)
            {
                anamode = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.m_objViewer.cboAnamode.Items.Add(dt.Rows[i]["ANAESTHESIAMODENAME"].ToString());
                    anamode[i] = dt.Rows[i]["ANAESTHESIAMODEID"].ToString();
                }
                this.m_objViewer.cboAnamode.SelectedIndex = 0;
            }
            else
            {
                anamode = new string[1];
                anamode[0] = "0001";
            }
        }
        #endregion
    }

    public class clsAssistantInput
    {
        private System.Drawing.Point m_potLocation;
		private Control m_ctlMain;
        public clsAssistantInput(Control p_ctlSender, System.Drawing.Point p_potLocation)
		{
			m_ctlMain = p_ctlSender;
			m_potLocation = p_potLocation;
		}

        /// <summary>
		/// 模糊查找医师（职工）
		/// </summary>
		public void m_mthSetEmployeeName()
		{
			if(m_ctlMain == null)
            {
                return;
            }

			string[,] strEmployeeArr = null;

            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                       (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngGetEmployeeNameByLikeNew(m_ctlMain.Text.Trim(), out strEmployeeArr);
			if(strEmployeeArr != null)
			{
                new clsAssisantInputList(m_ctlMain, strEmployeeArr, 2, m_potLocation);
			}
			else
			{
				SendKeys.Send("{tab}");
			}
		}
    }

    public class clsAssisantInputList
	{
		private ListView m_lstItemList;
		private int m_intType;
		
		/// <summary>
		/// 下拉显示信息
		/// </summary>
		/// <param name="p_ctlSender">输入控件</param>
		/// <param name="p_strValueArr">结果集</param>
		/// <param name="p_intType">类型</param>
		/// <param name="p_potLocation">位置</param>
        public clsAssisantInputList(Control p_ctlSender, string[,] p_strValueArr, int p_intType, System.Drawing.Point p_potLocation)
		{
			if(p_ctlSender == null || p_strValueArr == null || p_strValueArr.Length == 0)
				return;
			m_intType = p_intType;

			m_lstItemList = null;
			m_lstItemList = new ListView();
			m_lstItemList.Size = new System.Drawing.Size(150,200);
			m_lstItemList.View = View.Details;
			m_lstItemList.FullRowSelect = true;
			m_lstItemList.MultiSelect = false;
			m_lstItemList.GridLines = true;
			m_lstItemList.HeaderStyle = ColumnHeaderStyle.None;
            m_lstItemList.Columns.Add("EMPID_CHR", 0, HorizontalAlignment.Left);
            m_lstItemList.Columns.Add("ID", 50, HorizontalAlignment.Left);
			m_lstItemList.Columns.Add("NAME",80,HorizontalAlignment.Left);
			m_lstItemList.DoubleClick +=new EventHandler(m_mth_DoubleClick_1);
			m_lstItemList.LostFocus += new EventHandler(m_lstItemList_Leave);
			m_lstItemList.KeyDown += new KeyEventHandler(m_mth_KeyDown_1);
			m_lstItemList.Tag = p_ctlSender;

			for(int i=0;i<p_strValueArr.Length/3;i++)
			{
				Application.DoEvents();
                ListViewItem item = m_lstItemList.Items.Add(p_strValueArr[i, 2]);
                             item.SubItems.Add(p_strValueArr[i, 0]);
                             item.SubItems.Add(p_strValueArr[i, 1]);
			}
			//p_ctlSender.Tag = m_lstItemList;
			p_ctlSender.FindForm().Controls.Add(m_lstItemList);
			if(p_ctlSender.FindForm().Width >= (p_potLocation.X+m_lstItemList.Width))
				m_lstItemList.Location = p_potLocation;
			else
			{
				System.Drawing.Point pot = p_potLocation;
				pot.X -= p_potLocation.X+m_lstItemList.Width-p_ctlSender.FindForm().Width;
				m_lstItemList.Location = pot;
			}
			m_lstItemList.BringToFront();
			m_lstItemList.Visible = true;
			m_lstItemList.Show();
			if(m_lstItemList.Items.Count > 0)
			{
				m_lstItemList.Focus();
				m_lstItemList.TopItem.Selected = true;
			}
		}

		private void m_mth_DoubleClick_1(object sender, System.EventArgs e)
		{
			ListView lstItem = sender as ListView;
			if(lstItem.SelectedItems.Count > 0)
			{
				Control ctlBase = lstItem.Tag as Control;
                if (ctlBase == null)
                {
                    return;
                }
                ctlBase.Text = lstItem.SelectedItems[0].SubItems[m_intType].Text;
                ctlBase.Tag = lstItem.SelectedItems[0].SubItems[0].Text;
                SendKeys.Send("{tab}");
				lstItem.Visible = false;
				ctlBase.Focus();				
				lstItem.Parent.Controls.Remove(lstItem);
			}
		}

		private void m_mth_KeyDown_1(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			ListView lsvSender = sender as ListView;
			switch(e.KeyValue)
			{
				case 13:// enter
					m_mth_DoubleClick_1(sender,null);
					break;
				case 38://Arrow Up
					if(lsvSender.Items.Count > 0 && lsvSender.TopItem.Selected)
					{
						Control ctlBase = lsvSender.Tag as Control;
						if(ctlBase != null)
							ctlBase.Focus();
					}
					break;
				case 40://Arrow Down
					break;				
			}	
		}
		private void m_mth_KeyDown_2(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			switch(e.KeyChar)
			{
				case (char)40://Arrow Down
					if(m_lstItemList.CanFocus && m_lstItemList != null)
					{
						m_lstItemList.Focus();
						m_lstItemList.Items[0].Selected = true;
					}
					break;				
			}	
		}

		private void m_lstItemList_Leave(object sender, EventArgs e)
		{
			((Control)sender).Visible = false;
		}
	}
}
