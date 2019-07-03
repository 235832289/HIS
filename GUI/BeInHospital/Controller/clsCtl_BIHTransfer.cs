using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 调转——界面控制层
	/// 作者： 徐斌辉
	/// 创建时间： 2004-09-06
	/// </summary>
	public class clsCtl_BIHTransfer: com.digitalwave.GUI_Base.clsController_Base
	{
		#region 变量
		clsDcl_BedAdmin m_objBedAdmin = null;
		clsDcl_Register m_objRegister =null;
		public string m_strReportID;
		public string m_strOperatorID;
		#endregion 

		#region 构造函数
		public clsCtl_BIHTransfer()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_objBedAdmin =new clsDcl_BedAdmin();
			m_objRegister = new clsDcl_Register();
			m_strReportID = null;
			m_strOperatorID = "0000001";
		}
		#endregion 

		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmBIHTransfer m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmBIHTransfer)frmMDI_Child_Base_in;
		}
		#endregion

		#region 初始化科室、病区、床号
//		#region 载入科室
//		/// <summary>
//		/// 载入科室
//		/// </summary>
//		public void LoadDeptID()
//		{
//			m_objViewer.lsvDeptInfo.Items.Clear();
//			com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO[] DataResultArr =null;
//			string strFilter = "WHERE ATTRIBUTEID = '0000002' AND STATUS_INT = 1 AND SHORTNO_CHR LIKE '"+m_objViewer.m_txtDEPTID_CHR.Text.ToString().Trim()+"%'";
//			System.Windows.Forms.ListViewItem FindItem;
//			long lngRes = new com.digitalwave.iCare.gui.HIS.clsDcl_Register().m_lngGetAreaInfo(strFilter,out DataResultArr);
//			if(lngRes>0&&DataResultArr.Length >0)
//			{
//				for(int i = 0;i<DataResultArr.Length;i++)
//				{
//					FindItem = new ListViewItem(DataResultArr[i].m_strDEPTNAME_VCHR);
//					FindItem.Tag = DataResultArr[i];
//					m_objViewer.lsvDeptInfo.Items.Add(FindItem);
//				}
//			}
//		}
//		#endregion
		#region 载入科室对应的病区
		/// <summary>
		/// 载入科室对应的病区
		/// </summary>
		public void LoadAreaID()
		{
			m_objViewer.lsvAreaInfo.Items.Clear();
			com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO[] DataResultArr =null;
			string strFilter = "WHERE ATTRIBUTEID = '0000003' AND STATUS_INT = 1 AND (shortno_chr LIKE '"+m_objViewer.m_txtAREAID_CHR.Text.ToString().Trim()+"%' or DEPTNAME_VCHR like '"+m_objViewer.m_txtAREAID_CHR.Text.ToString().Trim()+"%' or PYCODE_CHR like '"+m_objViewer.m_txtAREAID_CHR.Text.ToString().Trim()+"%' or WBCODE_CHR like '"+m_objViewer.m_txtAREAID_CHR.Text.ToString().Trim()+"%')";
			System.Windows.Forms.ListViewItem FindItem;
			long lngRes = new com.digitalwave.iCare.gui.HIS.clsDcl_Register().m_lngGetAreaInfo(strFilter,out DataResultArr);
			if(lngRes>0&&DataResultArr.Length >0)
			{
				for(int i = 0;i<DataResultArr.Length;i++)
				{
					FindItem = new ListViewItem(DataResultArr[i].m_strDEPTNAME_VCHR);
					FindItem.Tag = DataResultArr[i];
					m_objViewer.lsvAreaInfo.Items.Add(FindItem);
				}
			}
		}
		#endregion
//		#region 载入病区的对应空床
//		/// <summary>
//		/// 载入病区的对应空床
//		/// </summary>
//		public void LoadBedID()
//		{
//			m_objViewer.m_txtBEDID_CHR.lsvContext.Items.Clear();
//			//病区ID为空则返回
//			if(((string)m_objViewer.m_txtAREAID_CHR.Tag)=="") return;
//
//			DataTable dtbResult =new DataTable();
//			m_objBedAdmin.m_lngGetAreaBedInfoByStatus_int((string)m_objViewer.m_txtAREAID_CHR.Tag,1,out dtbResult);
//			if(dtbResult.Rows.Count >0)
//			{
//				m_objViewer.m_txtBEDID_CHR.DataSource =dtbResult;
//				m_objViewer.m_txtBEDID_CHR.BindData();
//			}
//		}
//		#endregion
		#endregion

		#region 调转
		public void m_cmdTransfer()
		{
			long lngReg =0;

			if(!IsPassInputValidate())
				return;

			clsT_Opr_Bih_Transfer_VO objPatientVO;
			ValueToVoForTransfer(out objPatientVO);


			try
			{
				lngReg =m_objRegister.m_lngTransferInHospital(objPatientVO);
			}
			catch (Exception e)
			{
				MessageBox.Show(m_objViewer,e.Message,"错误提示框",MessageBoxButtons.OK,MessageBoxIcon.Error);	
				return;
			}			

			//操作结果提示
			if(lngReg>0)
			{
				MessageBox.Show(m_objViewer,"成功调转!","提示框",MessageBoxButtons.OK,MessageBoxIcon.Information);	
				m_objViewer.m_IsOK =true;
				m_objViewer.Close();
			}
			else
			{
				MessageBox.Show(m_objViewer,"调转失败!","提示框",MessageBoxButtons.OK,MessageBoxIcon.Information);	
			}
		}
		/// <summary>
		/// 输入验证
		/// </summary>
		/// <returns></returns>
		private bool IsPassInputValidate()
		{
//			if(m_objViewer.m_cbmTYPE.SelectedIndex<=0)
//			{
//				MessageBox.Show(m_objViewer,"调转类型为必选项!","提示框",MessageBoxButtons.OK,MessageBoxIcon.Information);
//				m_objViewer.m_cbmTYPE.Focus();
//				return false;
//			}
//			if(((string)m_objViewer.m_txtDEPTID_CHR.Tag)=="")
//			{
//				MessageBox.Show(m_objViewer,"目标科室为必选项!","提示框",MessageBoxButtons.OK,MessageBoxIcon.Information);
//				m_objViewer.m_txtDEPTID_CHR.Focus();
//				return false;
//			}
			if(((string)m_objViewer.m_txtAREAID_CHR.Tag)=="")
			{
				MessageBox.Show(m_objViewer,"目标病区为必选项!","提示框",MessageBoxButtons.OK,MessageBoxIcon.Information);
				m_objViewer.m_txtAREAID_CHR.Focus();
				return false;
			}
			if(m_objViewer.m_strRegisterID.Trim()=="")
			{
				MessageBox.Show(m_objViewer,"未知入院登记，不能调转!","提示框",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return false;
			}

			return true;
		}

		#region 控件赋值给Vo
		/// <summary>
		/// 控件赋值给Vo  {调转}
		/// </summary>
		/// <param name="objPatientVO"></param>
		private void ValueToVoForTransfer(out clsT_Opr_Bih_Transfer_VO objPatientVO)
		{
			objPatientVO =new clsT_Opr_Bih_Transfer_VO();
			//源科室id
			objPatientVO.m_strSOURCEDEPTID_CHR =m_objViewer.m_strSourceDeptID;
			//源病区id
			objPatientVO.m_strSOURCEAREAID_CHR =m_objViewer.m_strSourceAreaID;
			//源病床id
			objPatientVO.m_strSOURCEBEDID_CHR =m_objViewer.m_strSourceBedID;
			//目标科室id
//			objPatientVO.m_strTARGETDEPTID_CHR =(string)m_objViewer.m_txtDEPTID_CHR.Tag;
			//目标病区id
			objPatientVO.m_strTARGETAREAID_CHR =(string)m_objViewer.m_txtAREAID_CHR.Tag;
			//目标病床id
//			objPatientVO.m_strTARGETBEDID_CHR =m_objViewer.m_txtBEDID_CHR.Value;
			objPatientVO.m_strTARGETBEDID_CHR = "";
			//操作类型{1=转科2=调床3=转科+调床4=出院唤回}
			objPatientVO.m_intTYPE_INT =3;
			//备注
			objPatientVO.m_strDES_VCHR =m_objViewer.m_txtDES.Text;
			//操作人
			objPatientVO.m_strOPERATORID_CHR =m_strOperatorID;
			//入院登记流水号(200409010001)
			objPatientVO.m_strREGISTERID_CHR =m_objViewer.m_strRegisterID;
			//修改日期，操作日期
			objPatientVO.m_strMODIFY_DAT =System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");	
		}
		#endregion
		#endregion

//		#region 调转类型事件
//		/// <summary>
//		/// 调转类型事件
//		/// </summary>
//		public void m_TYPETextChanged()
//		{
//			if(m_objViewer.m_cbmTYPE.Text.Trim()=="")
//			{
//				m_objViewer.m_txtDEPTID_CHR.Enabled =true;
//				m_objViewer.m_txtAREAID_CHR.Enabled =true;
//				return;
//			}
//			switch(m_objViewer.m_cbmTYPE.SelectedIndex)
//			{
//				case 1://"2-调床":
//					m_objViewer.m_txtDEPTID_CHR.Text =m_objViewer.m_lblDEPTID_CHR.Text;
//					m_objViewer.m_txtDEPTID_CHR.Tag =m_objViewer.m_strSourceDeptID;
//					LoadAreaID();
//					m_objViewer.m_txtAREAID_CHR.Text =m_objViewer.m_lblAREAID_CHR.Text;
//					m_objViewer.m_txtAREAID_CHR.Tag =m_objViewer.m_strSourceAreaID;
//					m_objViewer.m_txtDEPTID_CHR.Enabled =false;
//					m_objViewer.m_txtAREAID_CHR.Enabled =false;
//	
//					break;
//				case 2://转区
//					m_objViewer.m_txtDEPTID_CHR.Text =m_objViewer.m_lblDEPTID_CHR.Text;
//					m_objViewer.m_txtDEPTID_CHR.Tag =m_objViewer.m_strSourceDeptID;
//					LoadAreaID();
//					m_objViewer.m_txtAREAID_CHR.Text =m_objViewer.m_lblAREAID_CHR.Text;
//					m_objViewer.m_txtAREAID_CHR.Tag =m_objViewer.m_strSourceAreaID;
//					m_objViewer.m_txtDEPTID_CHR.Enabled =true;
//					m_objViewer.m_txtAREAID_CHR.Enabled =true;
//					break;
//			}
//		}
//		#endregion
	}
}
