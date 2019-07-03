using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.BIHOrder.Control;
using System.Collections;
using com.digitalwave.iCare.gui.HIS;


namespace com.digitalwave.iCare.BIHOrder
{
    class clsCtl_AreaPutMedList : com.digitalwave.GUI_Base.clsController_Base
    {
         #region 变量声名
        clsDcl_ExecuteOrder m_objManage = null;
        clsDcl_InputOrder m_objInputOrder = null;
        
        
        #endregion


        #region 构造函数
        public clsCtl_AreaPutMedList()
        {
            m_objManage = new clsDcl_ExecuteOrder();
            m_objInputOrder = new clsDcl_InputOrder();

        }
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.BIHOrder.frmAreaPutMedList m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmAreaPutMedList)frmMDI_Child_Base_in;

        }
        #endregion

        /// <summary>
        /// 初始化界面
        /// </summary>
        internal void IniTheForm()
        {
           
            LoadTheDate();

        }

        internal void LoadTheDate()
        {
            this.m_objViewer.m_dtvAreaList.Rows.Clear();
             DataTable m_dtItem;
              long lngRes = m_objInputOrder.m_lngFindSendArea(this.m_objViewer.m_strAreaID, out m_dtItem);
              for (int i = 0; i < m_dtItem.Rows.Count; i++)
              {
                  //a.SEQ_INT,a.put_dat,b.deptid_chr,b.deptname_vchr,b.code_vchr
                  this.m_objViewer.m_dtvAreaList.Rows.Add();
                  DataGridViewRow row = this.m_objViewer.m_dtvAreaList.Rows[this.m_objViewer.m_dtvAreaList.Rows.Count - 1];
                  row.Cells["No"].Value = Convert.ToString(i+1);
                  row.Cells["m_dtvAreaCode"].Value = m_dtItem.Rows[0]["code_vchr"].ToString().Trim();
                  row.Cells["m_dtvAreaName"].Value = m_dtItem.Rows[0]["deptname_vchr"].ToString().Trim();
                  row.Cells["m_dtvAreaId"].Value = m_dtItem.Rows[0]["deptid_chr"].ToString().Trim();
                  row.Cells["m_dtvfinishtime"].Value = m_dtItem.Rows[0]["put_dat"].ToString().Trim();
              }

        }

        internal void ClearComfirm()
        {
            if(this.m_objViewer.m_dtvAreaList.Rows.Count<=0)
            {
                return;
            }
            IPutMadicine madicine;
           
            madicine = PutMadicineFactory.GetInstance();
            long ret = madicine.CancelAreaComplete(this.m_objViewer.m_dtvAreaList.Rows[0].Cells["m_dtvAreaId"].Value.ToString().Trim(), this.m_objViewer.LoginInfo.m_strEmpID,this.m_objViewer.LoginInfo.m_strEmpName);
            if (ret > 0)
            {
                LoadTheDate();
            }
        }

        internal void SetAreaComfirm()
        {
            if (this.m_objViewer.m_dtvAreaList.Rows.Count > 0)
            {
                return;
            }
            IPutMadicine madicine;
            
            madicine = PutMadicineFactory.GetInstance();
            long ret = madicine.SetAreaComplete(this.m_objViewer.m_strAreaID.Trim(), this.m_objViewer.LoginInfo.m_strEmpID, this.m_objViewer.LoginInfo.m_strEmpName);
            if (ret > 0)
            {
                LoadTheDate();
            }
        }
    }
}
