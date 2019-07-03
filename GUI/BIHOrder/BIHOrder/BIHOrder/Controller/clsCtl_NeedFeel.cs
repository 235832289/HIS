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
	/// 皮试录入框	逻辑控制层
	/// 作者： 徐斌辉
	/// 创建时间： 2004-12-23 
	/// </summary>
	public class clsCtl_NeedFeel: com.digitalwave.GUI_Base.clsController_Base
	{
		#region 变量
		clsDcl_ExecuteOrder m_objManage = null;
		public string m_strReportID;
		/// <summary>
		/// 登陆用户ID
		/// </summary>
		public string m_strOperatorID;
		/// <summary>
		/// 当前皮试结果表流水号
		/// </summary>
		internal string m_strOrderFeelID="";
        
		#endregion 
		#region 构造函数
		public clsCtl_NeedFeel()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_objManage = new clsDcl_ExecuteOrder();
			m_strReportID = null;
		}
		#endregion 
		#region 设置窗体对象
		com.digitalwave.iCare.BIHOrder.frmNeedFeel m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmNeedFeel)frmMDI_Child_Base_in;
		}
		#endregion
		#region  载入
		/// <summary>
		/// 载入数据
		/// </summary>
		public void LoadData()
		{
			if(m_objViewer.m_strOrderID==string.Empty) return;

            clsT_Opr_Bih_OrderFeel_VO objTem;
            long lngRes = m_objManage.m_lngGetOrderFeelByOrderID(m_objViewer.m_strOrderID, out objTem);
            if (lngRes > 0 && objTem != null && objTem.m_strORDERFEELID_CHR != null)
            {
                m_strOrderFeelID = objTem.m_strORDERFEELID_CHR;
                m_objViewer.m_cmbRESULTTYPE_INT.SelectedIndex = objTem.m_intRESULTTYPE_INT;
                m_objViewer.m_txbDES_VCHR.Text = objTem.m_strDES_VCHR;
            }
		}
		#endregion

        private clsT_Opr_Bih_OrderFeel_VO objBuckUpVo;

        public void SetVo(clsT_Opr_Bih_OrderFeel_VO obj)
        {
            objBuckUpVo = obj;
        }

		#region 事件
		/// <summary>
		/// 保存
		/// </summary>
		public void SaveOrderFeel()
		{
			//验证输入
			if(!IsPassValidate()) return;

			//填充皮试结果Vo
			clsT_Opr_Bih_OrderFeel_VO p_objRecord;
			FillOrderFeel_VO(out p_objRecord);

			long lngRes =0;
			string p_strRecordID ="";
			if(m_strOrderFeelID!=string.Empty)
			{
				//修改
				lngRes =m_objManage.m_lngModifyOrderFeel(p_objRecord);				
			}
			else
			{
				//新增皮试
				lngRes =m_objManage.m_lngAddNewOrderFeel(out p_strRecordID,p_objRecord);				
			}

			if(lngRes<=0) 
			{
				MessageBox.Show(m_objViewer,"保存失败!","提示框!",MessageBoxButtons.OK,MessageBoxIcon.Information);
				m_objViewer.m_intResult =-1;
				return ;
			}			
			if(p_strRecordID!=string.Empty) 
			{
				m_strOrderFeelID =p_strRecordID;
			}
			MessageBox.Show(m_objViewer,"保存成功!","提示框!",MessageBoxButtons.OK,MessageBoxIcon.Information);	
			m_objViewer.m_intResult =1;		
			m_objViewer.m_objFeelEdit.m_intExitState =1;
			m_objViewer.m_objFeelEdit.m_intFeelResult =p_objRecord.m_intRESULTTYPE_INT;			
			m_objViewer.m_objFeelEdit.m_strFeelResult =(p_objRecord.m_intRESULTTYPE_INT==1)?"阴性":"阳性";
			m_objViewer.Close();
		}

        /// <summary>
        /// 保存皮试
        /// </summary>
        public void SaveOrderFeel2()
        {
            //验证输入
            if (!IsPassValidate()) return;
            FillOrderFeel_VO(out this.m_objViewer.p_objRecord);

            long lngRes = 0;
            string p_strRecordID = "";
            //if (m_strOrderFeelID != string.Empty)
            //{
            //    //修改
            //    lngRes = m_objManage.m_lngModifyOrderFeel(p_objRecord);
            //}
            //else
            //{
            //    //新增皮试
            //   lngRes = m_objManage.m_lngAddNewOrderFeel(out p_strRecordID, p_objRecord);
            //}
            //修改
            lngRes = m_objManage.m_lngModifyOrderFeelEnd(this.m_objViewer.p_objRecord);
            if (lngRes <= 0)
            {
                MessageBox.Show(m_objViewer, "保存失败!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (p_strRecordID != string.Empty)
            {
                m_strOrderFeelID = p_strRecordID;
            }
            MessageBox.Show(m_objViewer, "保存成功!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //m_objViewer.m_intResult = 1;
            //m_objViewer.m_objFeelEdit.m_intExitState = 1;
            //m_objViewer.m_objFeelEdit.m_intFeelResult = p_objRecord.m_intRESULTTYPE_INT;
            //m_objViewer.m_objFeelEdit.m_strFeelResult = (p_objRecord.m_intRESULTTYPE_INT == 1) ? "阴性" : "阳性";
            this.m_objViewer.DialogResult = DialogResult.OK;
        }
		#endregion 
		#region 方法
		/// <summary>
		/// 验证输入
		/// </summary>
		/// <returns></returns>
		private bool IsPassValidate()
		{
			if(m_objViewer.m_strOrderID==string.Empty)
			{
				MessageBox.Show(m_objViewer,"请选择医嘱!","提示框!",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return false;
			}			
			if(m_objViewer.m_cmbRESULTTYPE_INT.SelectedIndex <=0)
			{
				MessageBox.Show(m_objViewer,"皮试结果必填!","提示框!",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return false;
			}
			return true;
		}
		/// <summary>
		/// 填充皮试结果Vo
		/// </summary>
		/// <param name="p_objRecord">皮试结果Vo [out 参数]</param>
		private void FillOrderFeel_VO(out clsT_Opr_Bih_OrderFeel_VO p_objRecord)
		{ 
            if (this.objBuckUpVo.m_intRESULTTYPE_INT == 2 && m_objViewer.m_cmbRESULTTYPE_INT.SelectedIndex == 1)
            {
                this.m_objViewer.m_intFeelFlag = 1;
            }
            else if (this.objBuckUpVo.m_intRESULTTYPE_INT == 2 && m_objViewer.m_cmbRESULTTYPE_INT.SelectedIndex == 2)
            {
                this.m_objViewer.m_intFeelFlag = 2;
            }
            p_objRecord = new clsT_Opr_Bih_OrderFeel_VO();
            p_objRecord.m_strORDERID_CHR = m_objViewer.m_strOrderID;
			p_objRecord.m_intRESULTTYPE_INT =m_objViewer.m_cmbRESULTTYPE_INT.SelectedIndex;
			p_objRecord.m_strDES_VCHR =m_objViewer.m_txbDES_VCHR.Text;				
		}
		#endregion
	}
}
