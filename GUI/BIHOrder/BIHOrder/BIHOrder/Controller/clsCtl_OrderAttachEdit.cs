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
	/// 附加单据编辑	逻辑控制层
	/// 作者： 徐斌辉
	/// 创建时间： 2005-01-11
	/// </summary>
	public class clsCtl_OrderAttachEdit: com.digitalwave.GUI_Base.clsController_Base
	{
		#region 变量
		clsDcl_ExecuteOrder m_objManage = null;
		public string m_strReportID;
		public string m_strOperatorID;
		/// <summary>
		/// 附加单据流水号
		/// </summary>
		public string m_strATTACHID_CHR ="";
		#endregion 
		#region 构造函数
		public clsCtl_OrderAttachEdit()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_objManage = new clsDcl_ExecuteOrder();
			m_strReportID = null;			
			m_strOperatorID = "";
		}
		#endregion 
		#region 设置窗体对象
		com.digitalwave.iCare.BIHOrder.frmOrderAttachEdit m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmOrderAttachEdit)frmMDI_Child_Base_in;
		
		}
		#endregion

		#region 设为只读
		/// <summary>
		/// 设置只读
		/// </summary>
		public void m_SetReadOnly()
		{
			m_objViewer.m_cboMAZUI_CHR.Enabled =false;
			m_objViewer.m_txtDESC_VCHR.Enabled =false;
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
			clsPatient_VO objItem =new clsPatient_VO();
			lngRes =m_objManage.m_lngGetPatientInfoByPatientID(m_objViewer.m_strPatientID,out objItem);
			if(lngRes>0 && objItem!=null)
			{
				m_objViewer.m_lblPATIENTNAME_CHR.Text =objItem.m_strNAME_VCHR;
				m_objViewer.m_lblSEX_CHR.Text =objItem.m_strSEX_CHR;
				m_objViewer.m_lblINPATIENTID_CHR.Text =objItem.m_strINPATIENTID_CHR;
				m_objViewer.m_lblIDCARD_CHR.Text =objItem.m_strIDCARD_CHR;			
			}

			//载入附加单据信息
			string strAttachID =m_objViewer.m_strAttachID.Trim();
			if(strAttachID=="")return;
			clsT_Opr_Bih_Temfororder_VO objResult =null;
			lngRes =m_objManage.m_lngGetTemfororderByID(strAttachID,out objResult);
			if(lngRes>0 && objResult!=null)
			{
				m_strATTACHID_CHR =objResult.m_strID_CHR;
				m_objViewer.m_strPatientID =objResult.m_strPATIENTID_CHR;				
				m_objViewer.m_txtDESC_VCHR.Text =objResult.m_strDESC_VCHR;
				m_objViewer.m_cboMAZUI_CHR.SelectedItem =objResult.m_strMAZUI_CHR;	
				m_objViewer.m_lblPSTATUS_CHR.Tag =objResult.m_fltPSTATUS_CHR;
				switch(objResult.m_fltPSTATUS_CHR.ToString().Trim())
				{
					case "0": 
						m_objViewer.m_lblPSTATUS_CHR.Text ="未发送";
						break;
					case "1": 
						m_objViewer.m_lblPSTATUS_CHR.Text ="已发送";
						break;
					case "2": 
						m_objViewer.m_lblPSTATUS_CHR.Text ="已有结果";
						break;
					default: 
						m_objViewer.m_lblPSTATUS_CHR.Text ="未知状态";
						break;
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
			clsT_Opr_Bih_Temfororder_VO objItem =null;
			SetVo(out objItem);
			if(m_objViewer.m_intEditState==0)//增加
			{
				string strRecordID ="";
				lngRes =m_objManage.m_lngAddNewTemfororder(out strRecordID,objItem);
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
				lngRes =m_objManage.m_lngModifyTemfororder(objItem);
			}

			//报告操作结果
			if(lngRes>0)
				MessageBox.Show("操作成功！");
			else
				MessageBox.Show("操作失败！");
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
				lngRes =m_objManage.m_lngDeleteTemfororder(m_objViewer.m_strAttachID);				
			}
			//报告操作结果
			if(lngRes>0)
				MessageBox.Show("删除成功！");
			else
				MessageBox.Show("删除失败！");
			m_objViewer.Close();
		}
		/// <summary>
		/// 提交事件
		/// </summary>
		public void m_Commit()
		{
			if(m_objViewer.m_strAttachID.Trim()=="") return;
			int IntState =-1;//状态标志	{0=未发送；1=已发送；2=已有结果了；}
			try{IntState =Int32.Parse(m_objViewer.m_lblPSTATUS_CHR.Tag.ToString());}
			catch{}
			if(IntState!=0) return;
			long lngRes =0;
			lngRes =m_objManage.m_lngCommitTemfororder(m_objViewer.m_strAttachID);
			//报告操作结果
			if(lngRes>0)
				MessageBox.Show("提交成功！");
			else
				MessageBox.Show("提交失败！");
			m_objViewer.Close();
		}
		#region 私有方法
		/// <summary>
		/// 验证输入
		/// </summary>
		/// <returns></returns>
		private bool CheckInput()
		{
			return true;
		}
		/// <summary>
		/// 填充附加单据Vo对象
		/// </summary>
		/// <param name="objItem"></param>
		private void SetVo(out clsT_Opr_Bih_Temfororder_VO objItem)
		{
			objItem =new clsT_Opr_Bih_Temfororder_VO();
			objItem.m_strID_CHR =m_objViewer.m_strAttachID;
			objItem.m_strPATIENTID_CHR =m_objViewer.m_strPatientID;
			objItem.m_strREGISTERID_CHR ="";
			objItem.m_strPATIENTNAME_CHR =m_objViewer.m_lblPATIENTNAME_CHR.Text.Trim();
			objItem.m_strMAZUI_CHR =m_objViewer.m_cboMAZUI_CHR.Text;
			objItem.m_strDESC_VCHR =m_objViewer.m_txtDESC_VCHR.Text;
			try
			{
				objItem.m_fltPSTATUS_CHR =Convert.ToSingle(m_objViewer.m_lblPSTATUS_CHR.Tag.ToString());
			}
			catch
			{
				objItem.m_fltPSTATUS_CHR =0;
			}
		}
		/// <summary>
		/// 获取是否可以删除
		/// </summary>
		/// <returns></returns>
		private bool MayDelete()
		{
			if(m_objViewer.m_intEditState==2) return false;
			return true;
		}
		#endregion
		#endregion
	}
}
