using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;

namespace com.digitalwave.iCare.BIHOrder
{
	/// <summary>
	/// 转区附加单据编辑	逻辑控制层
	/// 作者： 徐斌辉
	/// 创建时间： 2005-01-18
	/// </summary>
	public class clsCtl_AOTransfer: com.digitalwave.GUI_Base.clsController_Base
	{
		#region 变量
		clsDcl_ExecuteOrder m_objManage = null;
		public string m_strReportID;
		public string m_strOperatorID;
		/// <summary>
		/// 附加单据流水号
		/// </summary>
		public string m_strATTACHID_CHR ="";
		/// <summary>
		/// 入院登记ID
		/// </summary>
		public string m_strREGISTERID_CHR ="";
		#endregion 
		#region 构造函数
		public clsCtl_AOTransfer()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_objManage = new clsDcl_ExecuteOrder();
			m_strReportID = null;
		}
		#endregion 
		#region 设置窗体对象
		com.digitalwave.iCare.BIHOrder.frmAOTransfer m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmAOTransfer)frmMDI_Child_Base_in;
		
		}
		#endregion
		#region 初始化
		/// <summary>
		/// 初始化
		/// </summary>
		public void m_Initialization()
		{
			switch(m_objViewer.m_intEditState)
			{
				case 0://新增
					m_objViewer.Text ="新增转区医嘱附加单据";
					break;
				case 1://编辑
					m_objViewer.Text ="编辑转区医嘱附加单据";
					break;
				case 2://只读
					m_objViewer.Text ="查看转区医嘱附加单据";
					m_SetReadOnly();
					break;
				default://只读
					m_SetReadOnly();
					break;
			}
		}
		#endregion
		#region 设为只读
		/// <summary>
		/// 设置只读
		/// </summary>
		public void m_SetReadOnly()
		{
			m_objViewer.m_txtTARGETAREAID_CHR.Enabled =false;
			m_objViewer.m_txtDES_VCHR.Enabled =false;
			m_objViewer.cmdOK.Enabled =false;
			m_objViewer.cmdDel.Enabled =false;
		}
		#endregion

		#region 载入
		/// <summary>
		/// 载入病人、附加单据信息
		/// </summary>
		public void m_LoadData()
		{
			long lngRes =0;

			//载入病人信息	
			if(m_objViewer.m_strPatientID.Trim()=="") return ;
			DataTable dtbResult =new DataTable();
			lngRes =m_objManage.lngGetOrderPatientBIHInfo(m_objViewer.m_strOrderID,out dtbResult);
			if(lngRes>0 && dtbResult!=null && dtbResult.Rows.Count>0)
			{
				m_objViewer.m_lblPATIENTNAME_CHR.Text =dtbResult.Rows[0]["NAME_VCHR"].ToString().Trim();
				m_objViewer.m_lblSEX_CHR.Text =dtbResult.Rows[0]["SEX_CHR"].ToString().Trim();
				m_objViewer.m_lblINPATIENTID_CHR.Text =dtbResult.Rows[0]["INPATIENTID_CHR"].ToString().Trim();
				m_objViewer.m_lblIDCARD_CHR.Text =dtbResult.Rows[0]["IDCARD_CHR"].ToString().Trim();
				//入院登记流水号
				m_strREGISTERID_CHR =dtbResult.Rows[0]["REGISTERID_CHR"].ToString().Trim();
				//病区、病床
				m_objViewer.m_txtSOURCEAREAID_CHR.Text =dtbResult.Rows[0]["AreaName"].ToString().Trim();
				m_objViewer.m_txtSOURCEAREAID_CHR.Tag =dtbResult.Rows[0]["AREAID_CHR"].ToString().Trim();
				m_objViewer.m_txtSOURCEBEDID_CHR.Text =dtbResult.Rows[0]["BedCode"].ToString().Trim();
				m_objViewer.m_txtSOURCEBEDID_CHR.Tag =dtbResult.Rows[0]["BEDID_CHR"].ToString().Trim();
			}

			//载入附加单据信息
			string strAttachID =m_objViewer.m_strAttachID.Trim();
			if(strAttachID=="")return;
			clsT_Opr_Bih_OrderAttach_Transfer_Vo objResult =null;
			lngRes =m_objManage.m_lngGetOrderAttachTransferByID(strAttachID,out objResult);
			if(lngRes>0 && objResult!=null)
			{				
				m_strATTACHID_CHR =objResult.m_strTRANSFERID_CHR;	
				m_strREGISTERID_CHR =objResult.m_strREGISTERID_CHR;
				m_objViewer.m_txtSOURCEAREAID_CHR.Text =objResult.m_strSourceAreaName;
				m_objViewer.m_txtSOURCEAREAID_CHR.Tag =objResult.m_strSOURCEAREAID_CHR;
				m_objViewer.m_txtSOURCEBEDID_CHR.Text =objResult.m_strSourceBedNo;
				m_objViewer.m_txtSOURCEBEDID_CHR.Tag =objResult.m_strSOURCEBEDID_CHR;
				m_objViewer.m_txtTARGETAREAID_CHR.Text =objResult.m_strTargetAreaName;
				m_objViewer.m_txtTARGETAREAID_CHR.Tag =objResult.m_strTARGETAREAID_CHR;
				m_objViewer.m_txtSTATUS_INT.Text =objResult.m_strStatusName;
				m_objViewer.m_txtSTATUS_INT.Tag =objResult.m_intSTATUS_INT;
				m_objViewer.m_txtCREATEDATE_DAT.Text =objResult.m_strCREATEDATE_DAT;
				m_objViewer.m_chkISACTIVE_INT.Checked =(objResult.m_intISACTIVE_CHR==1)?true:false;
				m_objViewer.m_txtACTIVEEMPID_CHR.Text =objResult.m_strActiveEmpName;
				m_objViewer.m_txtACTIVEEMPID_CHR.Tag =objResult.m_strACTIVEEMPID_CHR;
				m_objViewer.m_txtACTIVEDATE_DAT.Text =objResult.m_strACTIVEDATE_DAT;
				m_objViewer.m_txtDES_VCHR.Text =objResult.m_strDES_VCHR;
				if(objResult.m_intSTATUS_INT==1 && objResult.m_intISACTIVE_CHR!=1)
				{
					m_objViewer.cmdBecomeEffective.Enabled =true;
				}
			}
		}
		#endregion
		#region 事件
		/// <summary>
		/// 增|改事件
		/// </summary>
		public void m_OK()
		{
			long lngRes =0;
			if(!CheckInput()) return ;
			clsT_Opr_Bih_OrderAttach_Transfer_Vo objItem =null;
			SetVo(out objItem);
			if(m_objViewer.m_intEditState==0)//增加
			{
				string strRecordID ="";
				lngRes =m_objManage.m_lngAddNewOrderAttachTransfer(out strRecordID,objItem);
				if(lngRes>0)
				{
					//增加附加单据影射--后加
					m_objViewer.m_strAttachID =strRecordID;
					com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objTem =new com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService();
					lngRes =objTem.m_lngAddAttachOrder(m_objViewer.m_strOrderID,strRecordID);
				}
			}
			else if(m_objViewer.m_intEditState==1)//编辑
			{
				lngRes =m_objManage.m_lngModifyOrderAttachTransfer(objItem);
			}

			//报告操作结果
			if(lngRes>0)
				MessageBox.Show(m_objViewer,"操作成功！","提示框！",MessageBoxButtons.OK,MessageBoxIcon.Information);
			else
				MessageBox.Show(m_objViewer,"操作失败！","错误！",MessageBoxButtons.OK,MessageBoxIcon.Error);
			m_objViewer.Close();
		}
		/// <summary>
		/// 删除事件	
		/// </summary>
		public void m_Del()
		{
			if(m_objViewer.m_strAttachID.Trim()=="") return;
			//是否可以删除
			if(!MayDelete()) return;

			long lngRes =0;
			//删除附加单据影射--先删
			com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objTem =new com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService();
			lngRes =objTem.m_lngDeleteAttachOrder(m_objViewer.m_strAttachID);
			if(lngRes>0)
			{
				lngRes =m_objManage.m_lngDeleteOrderAttachTransfer(m_objViewer.m_strAttachID);				
			}
			//报告操作结果
			if(lngRes>0)
				MessageBox.Show(m_objViewer,"删除成功！","提示框！",MessageBoxButtons.OK,MessageBoxIcon.Information);
			else
				MessageBox.Show(m_objViewer,"删除失败！","错误！",MessageBoxButtons.OK,MessageBoxIcon.Error);
			m_objViewer.Close();
		}
		/// <summary>
		/// 提交事件
		/// </summary>
		/// 
		public void m_BecomeEffective()
		{
			if(m_objViewer.m_strAttachID.Trim()=="") return;
			if(!MayBecomeEffective()) return;
			clsT_Opr_Bih_Transfer_VO objItem;
			SetVoForTransfer(out objItem);
			long lngRes =0;
			lngRes =m_objManage.m_lngBecomeEffectiveOrderAttachTransfer(m_objViewer.m_strAttachID,m_strOperatorID,objItem);
			//报告操作结果
			if(lngRes>0)
				MessageBox.Show(m_objViewer,"生效成功！","提示框！",MessageBoxButtons.OK,MessageBoxIcon.Information);
			else
				MessageBox.Show(m_objViewer,"生效失败！","错误！",MessageBoxButtons.OK,MessageBoxIcon.Error);
			m_objViewer.Close();
		}
		#region 私有方法
		/// <summary>
		/// 验证输入
		/// </summary>
		/// <returns></returns>
		private bool CheckInput()
		{
			if(m_strREGISTERID_CHR.Trim()=="")
			{
				MessageBox.Show(m_objViewer,"患者住院信息不能明确确定！","警告！",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return false;
			}
			if(m_objViewer.m_txtTARGETAREAID_CHR.Tag.ToString().Trim()=="")
			{
				MessageBox.Show(m_objViewer,"目标病区不能少！","警告！",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return false;
			}
			return true;
		}
		/// <summary>
		/// 填充附加单据Vo对象
		/// </summary>
		/// <param name="objItem"></param>
		private void SetVo(out clsT_Opr_Bih_OrderAttach_Transfer_Vo objItem)
		{
			objItem =new clsT_Opr_Bih_OrderAttach_Transfer_Vo();
			objItem.m_strTRANSFERID_CHR=m_strATTACHID_CHR;
			objItem.m_strREGISTERID_CHR = m_strREGISTERID_CHR;
			objItem.m_strSOURCEAREAID_CHR= m_objViewer.m_txtSOURCEAREAID_CHR.Tag.ToString();
			objItem.m_strSOURCEBEDID_CHR = m_objViewer.m_txtSOURCEBEDID_CHR.Tag.ToString();
			objItem.m_strTARGETAREAID_CHR = m_objViewer.m_txtTARGETAREAID_CHR.Tag.ToString();
			objItem.m_strCREATEDATE_DAT = m_objViewer.m_txtCREATEDATE_DAT.Text.Trim();		
			objItem.m_strDES_VCHR = m_objViewer.m_txtDES_VCHR.Text.Trim();		
			//objItem.m_intSTATUS_INT = Int32.Parse(m_objViewer.m_txtSTATUS_INT.Tag.ToString());
			objItem.m_intSTATUS_INT = 0;//新增的状态默认为0，另外只有0状态才能修改
			objItem.m_intISACTIVE_CHR = (m_objViewer.m_chkISACTIVE_INT.Checked)?1:0;
			//objItem.m_strACTIVEEMPID_CHR = m_objViewer.m_txtACTIVEEMPID_CHR.Tag.ToString();
			//objItem.m_strACTIVEDATE_DAT = Convert.ToDateTime(m_objViewer.m_txtACTIVEDATE_DAT.Text).ToString("yyyy-MM-dd HH:mm:ss").Trim();
			//新增的默认为NULL，另外只有NUll才能修改
			objItem.m_strACTIVEEMPID_CHR =null;
			objItem.m_strACTIVEDATE_DAT =null;
		}
		/// <summary>
		/// 获取是否可以删除
		/// </summary>
		/// <returns></returns>
		private bool MayDelete()
		{
			if(m_objViewer.m_intEditState==2) return false;
			try
			{
				//状态标志{0=未发送;1=已发送;2=已经有结果了;}
				if(Int32.Parse(m_objViewer.m_txtSTATUS_INT.Tag.ToString())>0)
				{
					MessageBox.Show(m_objViewer,"只能删除未发送状态的附加单据！","警告！",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					return false;
				}
			}
			catch{}
			return true;
		}
		/// <summary>
		/// 是否可以做生效操作
		/// </summary>
		/// <returns></returns>
		private bool MayBecomeEffective()
		{
			int IntState =-1;//状态标志	{0=未发送；1=已发送；2=已有结果了；}
			try
			{
				IntState =Int32.Parse(m_objViewer.m_txtSTATUS_INT.Tag.ToString());
			}
			catch{}
			if(IntState!=1)
			{
				MessageBox.Show(m_objViewer,"只有状态为“已发送”才能做生效操作！","警告！",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return false;
			}
			return true;
		}
		/// <summary>
		/// 设置转病区Vo
		/// </summary>
		/// <param name="objItem"></param>
		/// <returns></returns>
		private void SetVoForTransfer(out clsT_Opr_Bih_Transfer_VO objItem)
		{
			objItem =new clsT_Opr_Bih_Transfer_VO();
			//源科室id
			objItem.m_strSOURCEDEPTID_CHR =m_objViewer.m_txtSOURCEAREAID_CHR.Tag.ToString();
			//源病区id
			objItem.m_strSOURCEAREAID_CHR =m_objViewer.m_txtSOURCEAREAID_CHR.Tag.ToString();
			//源病床id
			objItem.m_strSOURCEBEDID_CHR =m_objViewer.m_txtSOURCEBEDID_CHR.Tag.ToString();
			//目标科室id
			//objItem.m_strTARGETDEPTID_CHR =m_objViewer.m_txtTARGETAREAID_CHR.Tag.ToString();
			//目标病区id
			objItem.m_strTARGETAREAID_CHR =m_objViewer.m_txtTARGETAREAID_CHR.Tag.ToString();
			//目标病床id
			objItem.m_strTARGETBEDID_CHR = "";
			//操作类型{1=转科2=调床3=转科+调床4=出院唤回}
			objItem.m_intTYPE_INT =3;
			//备注
			objItem.m_strDES_VCHR =m_objViewer.m_txtDES_VCHR.Text;
			//操作人
			objItem.m_strOPERATORID_CHR =m_strOperatorID;
			//入院登记流水号(200409010001)
			objItem.m_strREGISTERID_CHR =m_strREGISTERID_CHR;
			//修改日期，操作日期
			objItem.m_strMODIFY_DAT =System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");	
		}
		#endregion
		#endregion
	}
}
