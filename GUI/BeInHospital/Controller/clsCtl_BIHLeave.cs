using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility;
using com.digitalwave.iCare.gui.Security;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 出院——界面控制层
	/// 作者： 徐斌辉
	/// 创建时间： 2004-09-06
	/// </summary>
	public class clsCtl_BIHLeave: com.digitalwave.GUI_Base.clsController_Base
	{
		#region 变量
		clsDcl_Register m_objRegister = null;
		public string m_strReportID;
		public string m_strOperatorID;
		com.digitalwave.iCare.gui.Systempower.clsSystemPower_base objsystempower;
		#endregion 

		#region 构造函数
		public clsCtl_BIHLeave()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_objRegister = new clsDcl_Register();
			m_strReportID = null;
			m_strOperatorID = "0000001";
			clsController_Security clsSe=new clsController_Security();
			m_strOperatorID = clsSe.objGetCurrentLoginEmployee().strEmpID;
			objsystempower = new com.digitalwave.iCare.gui.Systempower.clsSystemPower_base(m_strOperatorID);
		}
		#endregion 

		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmBIHLeave m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmBIHLeave)frmMDI_Child_Base_in;
		}
		#endregion

		#region 载入数据
		/// <summary>
		/// 载入住院信息	[根据入院登记流水号]
		/// </summary>
		public void LoadBIHInfo()
		{            
            if(m_objViewer.m_strRegisterID==string.Empty) return;

			clsT_Opr_Bih_Register_VO m_objItem =new clsT_Opr_Bih_Register_VO();
			long lngReg = m_objRegister.m_lngGetBinRegisterByRegisterID(m_objViewer.m_strRegisterID,out m_objItem);
			if(lngReg<=0 || m_objItem==null)
				return;

			//入院时间
            m_objViewer.m_lblINPATIENT_DAT.Text = Convert.ToDateTime(m_objItem.m_strINPATIENT_DAT.ToString()).ToString("yyyy年MM月dd日");
			//住院天数
			try
			{
				System.TimeSpan diff1 =System.DateTime.Now.Subtract(Convert.ToDateTime(m_objItem.m_strINPATIENT_DAT));
                //m_objViewer.m_lblBIHDays.Text =diff1.Days.ToString();
                m_objViewer.m_lblBIHDays.Text = Convert.ToString(diff1.Days + 1);
			}
			catch
			{}

			//入院科室、病区、床号
			m_objViewer.m_lblDEPTID_CHR.Text = m_objItem.m_strDeptName;
			m_objViewer.m_lblAREAID_CHR.Text = m_objItem.m_strAreaName;
			m_objViewer.m_lblBEDID_CHR.Text = m_objItem.m_strBedNo;
            
            m_objViewer.m_dtpOutDate.Text = DateTime.Now.ToString("yyyy年MM月dd日HH时mm分");

            if (m_objViewer.m_bedManageVO.m_strINTERNALFLAG_INT == "2")
            {
                //医保病人
                //this.m_objViewer.m_ckbDiseasType.Checked = true;
                this.m_objViewer.m_ckbDiseasType.Enabled = true;
            }
            else
            {
                //this.m_objViewer.m_ckbDiseasType.Checked = false;
                this.m_objViewer.m_ckbDiseasType.Enabled = false;
            }

            if (m_objItem.m_intDiseaseType == 1)
            {
                this.m_objViewer.m_ckbDiseasType.Enabled = false;
                this.m_objViewer.m_ckbDiseasType.Checked = true;
            }

            this.m_objViewer.m_tbDiagnose.Text = m_objItem.m_strOutDiagnose;

		}
		#endregion

		#region 出院
		/// <summary>
		/// 出院	{1、空出床位；2、增加一条出院记录；}
		/// </summary>
		public void m_LeaveHospital()
        {
            long lngReg = 0;
            if (!IsPassInputValidate()) return;
            clsT_Opr_Bih_Leave_VO objPatientVO;
            ValueToVoForLeave(out objPatientVO);
            //检查是否可以出院
            if (objPatientVO.m_intPSTATUS_INT == 1)
            {
                if (!CheckIsMayLeaveHospital(objPatientVO.m_strREGISTERID_CHR)) return;
            }
            if (objsystempower.isHasRight("住院.进出转.出院"))
            {
                try
                {
                    lngReg = m_objRegister.m_lngLeaveHospital(objPatientVO);
                    MessageBox.Show("操作成功！", "出院", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.DialogResult = DialogResult.OK;
                }
                catch (Exception e)
                {
                    MessageBox.Show(m_objViewer, e.Message, "错误提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("您没有权限");
            }
        }
		private bool IsPassInputValidate()
		{
			if(m_objViewer.m_cbmTYPE.Text.Trim()=="")
			{
				MessageBox.Show(m_objViewer,"出院类型为必选项!","提示框",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return false;
			}
			if(m_objViewer.m_cbmPSTATUS_INT.SelectedIndex<=0)
			{
				MessageBox.Show(m_objViewer,"出院方式为必选项!","提示框",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return false;
			}
			return true;
		}

		/// <summary>
		/// 检查是否可以出院
		/// 业务说明: 
		///		1、有未停止的医嘱，不能出院！
		///		2、有没有审核停止连续性医嘱，不可以出院！
		///		3、今天入院，今天出院的病人如果没有收床位费，不可以出院！
		///		4、今天入院，今天出院的病人如果没有收诊金，不可以出院！
		///		5、有未清的费用，不可以出院!
		/// </summary>
		/// <param name="p_strRegisterID">入院登记流水号</param>
		/// <returns>{true-可以出院；false-不能出院}</returns>
		private bool CheckIsMayLeaveHospital(string p_strRegisterID)
		{
			bool blnRes =true;
			string strMessage ="";
			//1、有未停止的医嘱，不能出院！
			if(m_objRegister.m_lngIshasAdvice(p_strRegisterID))
			{
				if(strMessage!="") strMessage +="\r\n";
				strMessage +="    存在未停止的医嘱！";
			}
			//2、有没有审核停止连续性医嘱，不可以出院！
			if(m_objRegister.m_blnExistNotCheckConfreqOrder(p_strRegisterID))
			{
				if(strMessage!="") strMessage +="\r\n";
				strMessage +="    存在未审核停止的连续性医嘱！";
			}
			//3、今天入院，今天出院的病人如果没有收床位费，不可以出院！
			if(m_objRegister.m_lngChargeBedForTodayPatient(p_strRegisterID)==0)
			{
				if(strMessage!="") strMessage +="\r\n";
				strMessage +="    没有收取床位费！";
			}
			//4、今天入院，今天出院的病人如果没有收取诊金，不可以出院！
			if(m_objRegister.m_lngChargeDiagnosisForTodayPatient(p_strRegisterID)==0)
			{
				if(strMessage!="") strMessage +="\r\n";
				strMessage +="    没有收取诊金！";
			}
			//5、有未清的费用，不可以出院!
			string strDebt = "";
			long lngRes = new clsDcl_StatQuery().m_lngGetPatientDebtByRegisterID(p_strRegisterID,out strDebt);
			if(strDebt!="" && double.Parse(strDebt)>0)
			{
				if(strMessage!="") strMessage +="\r\n";
				strMessage +="    有"+strDebt+"元未清的费用！";
			}

			if(strMessage!="")
			{
				if(MessageBox.Show(m_objViewer,"提示：\r\n"+strMessage+"\r\n\r\n    是否强制出院？","警告！",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2)==DialogResult.No)			
					blnRes =false;
				else
					blnRes =true;
			}
			return blnRes;
		}
		#region 控件赋值给Vo
		/// <summary>
		/// 控件赋值给Vo  {出院}
		/// </summary>
		/// <param name="objPatientVO"></param>
		private void ValueToVoForLeave(out clsT_Opr_Bih_Leave_VO objPatientVO)
		{
			objPatientVO =new clsT_Opr_Bih_Leave_VO();

			//入院登记流水号(200409010001)
			objPatientVO.m_strREGISTERID_CHR = m_objViewer.m_strRegisterID;
			//类型{1=治愈出院2=转院3=其它4=死亡}
			objPatientVO.m_strTYPE_INT = "0";
			if(m_objViewer.m_cbmTYPE.SelectedIndex!=0)
			{
				objPatientVO.m_strTYPE_INT = m_objViewer.m_cbmTYPE.SelectedIndex.ToString();
			}
			//出院科室
			objPatientVO.m_strOUTDEPTID_CHR = m_objViewer.m_strOutDeptID;			
			
            //出院病区
			objPatientVO.m_strOUTAREAID_CHR = m_objViewer.m_strOutAreaID;
            objPatientVO.m_strOutAreaName = m_objViewer.m_lblAREAID_CHR.Text;
			
            //出院病床
			objPatientVO.m_strOUTBEDID_CHR = m_objViewer.m_strOutBedID;
			
            //备注
			objPatientVO.m_strDES_VCHR = m_objViewer.m_txtDES.Text;
			
            //操作人ID
            objPatientVO.m_strOPERATORID_CHR = this.m_objViewer.LoginInfo.m_strEmpID;
            //操作人
            objPatientVO.m_strOperatorName = this.m_objViewer.LoginInfo.m_strEmpName;

            //修改日期，操作日期
			objPatientVO.m_strMODIFY_DAT = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			
            //状态（－1历史，0-无效，1有效）
			objPatientVO.m_intSTATUS_INT = 1;	
			
            //出院方式	{０=预出院;１=实际出院}
			objPatientVO.m_intPSTATUS_INT = m_objViewer.m_cbmPSTATUS_INT.SelectedIndex - 1;

            //出院日期	
            objPatientVO.m_strOUTHOSPITAL_DAT = Convert.ToDateTime(this.m_objViewer.m_dtpOutDate.Text).ToString("yyyy-MM-dd HH:mm:ss");

            //出院诊断
            objPatientVO.m_strDIAGNOSE_VCHR = m_objViewer.m_tbDiagnose.Text;

            //医保出院诊断
            objPatientVO.m_strINS_DIAGNOSE_VCHR = m_objViewer.m_tbInsDiagnose.Text;

            if (this.m_objViewer.m_ckbDiseasType.Checked == true)
            {
                objPatientVO.m_intDISEASETYPE_INT = 1;
            }
            else
            {
                objPatientVO.m_intDISEASETYPE_INT = 0;
            }
		}
		#endregion
		#endregion

        #region 预出院 He Guiqiu 2006.07.12
        public void PreLeaveHospital()
        {
            
            if (!IsPassInputValidate()) return;

           
            //try
            //{
            //    DateTime outDate;
            //    outDate = Convert.ToDateTime(this.m_dtpOutDate.Text);
            //    System.TimeSpan diff1 = outDate.Subtract(DateTime.Now);
            //    if (diff1.Days > 0)
            //    {       
            //        MessageBox.Show("出院日期不能早于今天", "提示");
            //        this.m_objViewer.m_dtpOutDate.Focus();
            //        return;
            //     }
            //}
            //catch
            //{ }

            clsT_Opr_Bih_Leave_VO objPatientVO;
            ValueToVoForLeave(out objPatientVO);
            
            try
            {

                DateTime outDate;
                outDate = Convert.ToDateTime(this.m_objViewer.m_dtpOutDate.Text).Date;
                System.TimeSpan diff1 = outDate.Subtract(DateTime.Today);
                if (diff1.Days < 0)
                {
                    MessageBox.Show("预出院日期不能早于今天", "提示");
                    this.m_objViewer.m_dtpOutDate.Focus();
                    return;
                }

                if (diff1.Days > 1)
                {
                    MessageBox.Show("预出院日期不能迟于明天", "提示");
                    this.m_objViewer.m_dtpOutDate.Focus();
                    return;
                }

                //调用算费接口
                bool charge;
                charge = clsPublic.m_blnChargeContinueItem(objPatientVO.m_strREGISTERID_CHR, objPatientVO.m_strOPERATORID_CHR);
                if (!charge)
                {
                    MessageBox.Show("调用费用接口失败", "提示");
                    //this.m_objViewer.m_dtpOutDate.Focus();
                    return;
                }

                long lngReg = -1;
                clsDclBihLeaHos domainObj = new clsDclBihLeaHos();

                //bool HasDisExcOrder;
                //domainObj.IfHasDisExcOrder(objPatientVO.m_strREGISTERID_CHR, out HasDisExcOrder);
                //if (HasDisExcOrder == true)
                //{
                //    string message = "该病人有医嘱未处理，请处理完毕才可以办理出院手续。是否继续？";
                //    string caption = "提示";
                //    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                //    DialogResult result;

                //    result = MessageBox.Show(this.m_objViewer, message, caption, buttons,
                //        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                //        MessageBoxOptions.RightAlign);

                //    if (result == DialogResult.No)
                //    {
                //        return;
                //    }

                //}
                
                
                lngReg = domainObj.PreLeaveHospital(objPatientVO);

                if (lngReg > 0)
                {
                    string msg = "操作成功！"
                               + this.m_objViewer.m_lblPatientName.Text + "将于"
                               + this.m_objViewer.m_dtpOutDate.Text
                               + "出院。";
                    MessageBox.Show(msg,"预出院", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.DialogResult = DialogResult.OK;

                }
                else
                {
                    MessageBox.Show("预出院失败！", "预出院", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.DialogResult = DialogResult.No;

                }
            }
            catch (Exception e)
            {
                m_objViewer.DialogResult = DialogResult.No;
                MessageBox.Show(m_objViewer, e.Message, "错误提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

            if (m_objViewer.DialogResult == DialogResult.OK && this.m_objViewer.m_ckbPrint.Checked)
            {
                // 打印出院通知单
                frmPrintLeaveNotice printLeaveNotice = new frmPrintLeaveNotice(this.m_objViewer.m_bedManageVO, objPatientVO);

                printLeaveNotice.Show();
                printLeaveNotice.Hide();
                printLeaveNotice.m_cmdPrint_Click(null, null);
            }           
        }
        #endregion 

        #region 直接出院 He Guiqiu 
        public void LeaveHospital()
        {

            if (!IsPassInputValidate()) return;
            clsT_Opr_Bih_Leave_VO objPatientVO;
            ValueToVoForLeave(out objPatientVO);

            try
            {

                DateTime outDate;
                outDate = Convert.ToDateTime(this.m_objViewer.m_dtpOutDate.Text);
                System.TimeSpan diff1 = outDate.Subtract(DateTime.Now);
                if (diff1.Days < 0)
                {
                    MessageBox.Show("出院日期不能早于今天", "提示");
                    this.m_objViewer.m_dtpOutDate.Focus();
                    return;
                }

                long lngReg = -1;
                clsDclBihLeaHos domainObj = new clsDclBihLeaHos();
                lngReg = domainObj.LeaveHospital(objPatientVO);

                if (lngReg > 0)
                {
                    string msg = "操作成功！"
                               + this.m_objViewer.m_lblPatientName.Text + "将于"
                               + this.m_objViewer.m_dtpOutDate.Text
                               + "出院。";
                    MessageBox.Show(msg, "出院", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.DialogResult = DialogResult.OK;

                }
                else
                {
                    MessageBox.Show("出院失败！", "出院", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.DialogResult = DialogResult.No;

                }
            }
            catch (Exception e)
            {
                m_objViewer.DialogResult = DialogResult.No;
                MessageBox.Show(m_objViewer, e.Message, "错误提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (m_objViewer.DialogResult == DialogResult.OK && this.m_objViewer.m_ckbPrint.Checked)
            {
                // 打印出院通知单
                frmPrintLeaveNotice printLeaveNotice = new frmPrintLeaveNotice(this.m_objViewer.m_bedManageVO, objPatientVO);

                printLeaveNotice.ShowDialog();
            }
        }
        #endregion 

        internal void EditDiagnoses()
        {
            //frmDiagnoses frm = new frmDiagnoses(this.m_objViewer.m_tbDiagnose.Text);
            frmDiagnoses frm = new frmDiagnoses(this.m_objViewer.m_tbDiagnose.Text.Trim(), this.m_objViewer.m_ckbDiseasType.Checked);
            frm.m_txtDiagnoses.Text = this.m_objViewer.m_tbDiagnose.Text.Trim();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                this.m_objViewer.m_tbDiagnose.Text = frm.m_txtDiagnoses.Text;
                this.m_objViewer.m_ckbDiseasType.Checked = frm.chkDiseasetype.Checked;
            }
        }
    }
}
