using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.gui.HIS.Reports;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsCtl_WorkloadCount : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 构造函数
        public clsCtl_WorkloadCount()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_objManage = new clsDcl_WorkloadCount();
        }
        #endregion

        /// <summary>
        /// 类变量
        /// </summary>
        private frmLisWorkloadCount m_objViewer;
        private clsDcl_WorkloadCount m_objManage;
        Dictionary<string, string> dicGroup;


        #region Entity
        /// <summary>
        /// 实体
        /// </summary>
        public class EntityWorkload
        {
            public string xm { get; set; }
            public string zyz { get; set; }
            public decimal dbds { get; set; }
        }
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            m_objViewer = (frmLisWorkloadCount)frmMDI_Child_Base_in;
        }
        #endregion

        #region init
        /// <summary>
        /// init
        /// </summary>
        public void m_mthInit()
        {
            dicGroup = new Dictionary<string, string>();
            m_objViewer.dgvData.Visible = true;
            m_objViewer.dteStart.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01");
            DataTable dtbResult = null;

            m_objManage.lngGetAllCheckSpec(out dtbResult);

            for (int i = 0; i < dtbResult.Rows.Count; i++)
            {
                m_objViewer.cboCategory.Items.Add(dtbResult.Rows[i]["check_category_desc_vchr"].ToString());
                dicGroup.Add(dtbResult.Rows[i]["check_category_id_chr"].ToString(), dtbResult.Rows[i]["check_category_desc_vchr"].ToString());
            }
        }
        #endregion



        #region  工作量统计
        /// <summary>
        /// 
        /// </summary>
        public void m_mthGetWorkLoadCount()
        {
            DataTable dtbResult;

            List<EntityWorkload> data = new List<EntityWorkload>();
            string groupId = string.Empty;
            string dteStart = m_objViewer.dteStart.Text;
            string dteEnd = m_objViewer.dteEnd.Text;

            string checkerId = string.Empty;
            string categoryId = string.Empty;
            string lastCheckId = string.Empty;
            string lastCategoryId = string.Empty;

            foreach (var item in dicGroup)
            {
                if (item.Value == m_objViewer.cboCategory.Text)
                    groupId = item.Key;
            }

            long lngRes = m_objManage.GetWorkLoadCount(dteStart, dteEnd, groupId, out dtbResult);

            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                foreach (DataRow dr in dtbResult.Rows)
                {
                    EntityWorkload vo = new EntityWorkload();
                    
                    checkerId = dr["checkerId"].ToString();
                    categoryId = dr["categoryId"].ToString();

                    if (checkerId != lastCheckId || categoryId != lastCategoryId)
                    {
                        lastCheckId = checkerId;
                        lastCategoryId = categoryId;
                        vo.zyz = dr["categoryDesc"].ToString();
                        vo.xm = dr["checker"].ToString();
                        vo.dbds = 1;
                        data.Add(vo);
                    }
                    else
                    {
                        int idx = data.Count - 1;
                        data[idx].dbds++;
                    }
                }
            }
            else
            {
                MessageBox.Show("没有相关数据。");
            }

            m_objViewer.dgvData.DataSource = data;
        }

        #endregion

    }
}
