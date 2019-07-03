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
    ///  医嘱上限判断	逻辑控制层
    /// 作者： 
    /// 创建时间： 2006-4-6
    /// </summary>
    class clsCtl_OrderSaveCheck : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量
        clsDcl_OrderSaveCheck m_objManage = null;
        
        
        #endregion 

        #region 构造函数
        public clsCtl_OrderSaveCheck()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
            m_objManage = new clsDcl_OrderSaveCheck();
			
		}
		#endregion 

        #region 设置窗体对象
        com.digitalwave.iCare.BIHOrder.frmOrderSaveCheck m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmOrderSaveCheck)frmMDI_Child_Base_in;
		
		}
		#endregion





        public void LoadtoList()
        {
            m_objViewer.m_dtOrderdicList.Items.Clear();
            if (m_objViewer.m_dtTable.Rows.Count > 0)
            {
                for (int i = 0; i < m_objViewer.m_dtTable.Rows.Count; i++)
                {
                   
                     ListViewItem lviTemp=new ListViewItem((i+1).ToString());
                    lviTemp.SubItems.Add(m_objViewer.m_dtTable.Rows[i]["NAME_CHR"].ToString().Trim());
                    lviTemp.SubItems.Add(m_objViewer.m_dtTable.Rows[i]["ItemPrice"].ToString().Trim());
                    lviTemp.SubItems.Add(m_objViewer.m_dtTable.Rows[i]["get_dec"].ToString().Trim());
                    lviTemp.SubItems.Add(m_objViewer.m_dtTable.Rows[i]["pricesum"].ToString().Trim());
                    m_objViewer.m_dtOrderdicList.Items.Add(lviTemp);
                  
                }
            }
            
        }

        public void ConfirmMaxValue()
        {
              string EMPNO_CHR= m_objViewer.m_txtEMPNO_CHR.Text.ToString().Trim();
              string PSW_CHR = m_objViewer.m_txtPSW_CHR.Text.ToString().Trim();
              double maxvalue = 0;
              for (int i = 0; i < m_objViewer.m_dtOrderdicList.Items.Count; i++)
              {
                  if (!m_objViewer.m_dtOrderdicList.Items[i].SubItems[4].Text.ToString().Trim().Equals(""))
                  {
                      if (double.Parse(m_objViewer.m_dtOrderdicList.Items[i].SubItems[4].Text.ToString().Trim()) > maxvalue)
                      {
                          maxvalue = double.Parse(m_objViewer.m_dtOrderdicList.Items[i].SubItems[4].Text.ToString().Trim());
                      }
                  }
              }
              DataTable dtbResult = new DataTable();
              long    lngRes = m_objManage.ConfirmMaxValue(EMPNO_CHR,PSW_CHR,maxvalue,ref dtbResult);
              if (dtbResult.Rows.Count > 0)
              {
                  m_objViewer.DialogResult = DialogResult.OK;
                  m_objViewer.Close();
              }
              else
              {
                  MessageBox.Show("确认失败，当前工号角色权限不足或密码不对！");
              }

              
            
           
              
        }

        internal bool ConfirmPassWork(string EMPNO_CHR, string PSW_CHR, out DataTable dtbResult)
        {
           
            dtbResult = new DataTable();
            long lngRes = m_objManage.ConfirmPassWord(EMPNO_CHR, PSW_CHR, ref dtbResult);
            if (dtbResult.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            return false;
        }
    }
}
