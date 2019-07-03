using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Drawing.Printing;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.gui.Security;
using com.digitalwave.iCare.middletier.baseInfo;//baseInfo_Svc.dll
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 特定病种对应ICD10码间维护界面控制
    /// 作者：He Guiqiu
    /// 创建时间:2006-06-22
    /// </summary>
    class clsCtlYbdeadeficd : com.digitalwave.GUI_Base.clsController_Base
    {
        private frmYbdeadeficd m_objViewer;
        private clsDclYbdeadeficd m_objDomain;
        private DataTable m_dataTableICD;

        //private string m_deaCode;
        private ArrayList m_newArr = new ArrayList();
        private ArrayList m_removeArr = new ArrayList();

        public clsCtlYbdeadeficd()
        {
            this.m_objDomain = new clsDclYbdeadeficd();
            this.m_dataTableICD = new DataTable();
        }

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmYbdeadeficd)frmMDI_Child_Base_in;
        }
        #endregion

        #region  建医保特种病TreeView视图
        public void GetSpecialDisease()
        {
            string rootId = "root";
            string rootName = "医保特种病";

            //建根节点
            TreeNode tnRoot = new TreeNode(rootName);
            tnRoot.Tag = rootId;
            tnRoot.ImageIndex = 0;
            tnRoot.SelectedImageIndex = 0;
            this.m_objViewer.m_tvDisease.Nodes.Add(tnRoot);

            long lngRes = 0;
            DataTable dtSpecialDisease = new DataTable();
            lngRes = m_objDomain.GetSpecialDisease(out dtSpecialDisease);

            if (lngRes > 0 && dtSpecialDisease.Rows.Count > 0)
            {
                string tnId = "";
                string tnName = "";

                for (int i = 0; i < dtSpecialDisease.Rows.Count; i++)
                {
                    tnId = dtSpecialDisease.Rows[i]["DEACODE_CHR"].ToString();
                    tnName = dtSpecialDisease.Rows[i]["DEADESC_VCHR"].ToString();
                    TreeNode tn = new TreeNode(tnName);
                    tn.Tag = tnId;
                    //tn.ImageIndex = 0;
                    //tn.SelectedImageIndex = 1;
                    tnRoot.Nodes.Add(tn);
                }


                this.m_objViewer.m_tvDisease.ExpandAll();
            }


        }
        #endregion


        #region  取ICD10信息
        public void GetICD()
        {
            long lngRes = 0;
            lngRes = m_objDomain.GetICD(out m_dataTableICD);

            this.m_objViewer.m_ICdDataGridView.Rows.Clear();
            if (lngRes > 0 && m_dataTableICD.Rows.Count > 0)
            {
                DataView dv = new DataView(m_dataTableICD);
                dv = m_dataTableICD.DefaultView;
               
                foreach (DataRowView drv in dv)
                {
                    string[] s = new string[2];

                    //s[0] = i.ToString();
                    s[0] = drv["ICDCODE_CHR"].ToString().Trim();
                    s[1] = drv["ICDNAME_VCHR"].ToString().Trim();

                    this.m_objViewer.m_ICdDataGridView.Rows.Add(s);
                }
            }

        }
        #endregion

        #region  过滤ICD10信息
        public void FilterICD()
        {
            string filter;
            filter = this.m_objViewer.m_textBoxICD.Text.ToString().Trim();

            if (filter!= null  && filter!= "")
            {
                this.m_objViewer.m_ICdDataGridView.Rows.Clear();

                DataView dv = new DataView(m_dataTableICD);
                dv = m_dataTableICD.DefaultView;
                dv.RowFilter = "ICDCODE_CHR like '%" + filter + "%' or ICDNAME_VCHR like '%" + filter + "%'" ;

                foreach (DataRowView drv in dv)
                {
                    string[] s = new string[2];

                    //s[0] = i.ToString();
                    s[0] = drv["ICDCODE_CHR"].ToString().Trim();
                    s[1] = drv["ICDNAME_VCHR"].ToString().Trim();

                    this.m_objViewer.m_ICdDataGridView.Rows.Add(s);
                }
            }

        }
        #endregion

        #region  取ICD10信息
        public void ResetICD()
        {
            
            if (m_dataTableICD.Rows.Count > 0)
            {
                this.m_objViewer.m_ICdDataGridView.Rows.Clear();
                DataView dv = new DataView(m_dataTableICD);
                dv = m_dataTableICD.DefaultView;

                foreach (DataRowView drv in dv)
                {
                    string[] s = new string[2];

                    //s[0] = i.ToString();
                    s[0] = drv["ICDCODE_CHR"].ToString().Trim();
                    s[1] = drv["ICDNAME_VCHR"].ToString().Trim();

                    this.m_objViewer.m_ICdDataGridView.Rows.Add(s);
                }
            }

        }
        #endregion
        
        #region  根据选择疾病码显示对应的ICD码
        public void AfterSelectDisease(string deaCode)
        {
            if (this.m_newArr.Count > 0 || this.m_removeArr.Count > 0)
            {
                if (MessageBox.Show("是否保存您所做的修改? '", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    SaveDeaDef();
                }
                else
                {
                    this.m_newArr.Clear();
                    this.m_removeArr.Clear();
                }
               
            }

            this.m_objViewer.m_deaDefICDdataGridView.Rows.Clear();

            DataTable dt= new DataTable();
            long lngRes = 0;
            lngRes = m_objDomain.GetICDByDeaCode(deaCode, out dt);

            if (dt.Rows.Count > 0)
            {
                
                DataView dv = new DataView(dt);
                dv = dt.DefaultView;
               
                foreach (DataRowView drv in dv)
                {
                    string[] s = new string[2];

                    //s[0] = i.ToString();
                    s[0] = drv["ICDCODE_CHR"].ToString().Trim();
                    s[1] = drv["ICDNAME_VCHR"].ToString().Trim();

                    this.m_objViewer.m_deaDefICDdataGridView.Rows.Add(s);
                }
            }

        }
        #endregion

        #region 增加对应ICD码
        public void AddDefICD()
        {
            TreeNode tn = new TreeNode();
            tn = this.m_objViewer.m_tvDisease.SelectedNode;
            if (tn == null)
            {
                MessageBox.Show("你尚未选择医保疾病", "提示");
                return;
            }

            string deaCode = tn.Tag.ToString().Trim();

            if (deaCode == "" || deaCode.ToLower() == "root")
            {
                MessageBox.Show("你尚未选择医保疾病", "提示");
                return;
            }

            
            if (this.m_objViewer.m_ICdDataGridView.SelectedRows.Count < 1)
            {
                MessageBox.Show("你尚未选择要添加的ICD码", "提示");
                return;
            }

            string sICDCode = this.m_objViewer.m_ICdDataGridView.SelectedRows[0].Cells["DeaCode"].Value.ToString(); ;
            string sICDName = this.m_objViewer.m_ICdDataGridView.SelectedRows[0].Cells["DeaDesc"].Value.ToString();

            //判断ICD码是否已存在
            for (int i1 = 0; i1 < m_objViewer.m_deaDefICDdataGridView.Rows.Count; i1++)
            {
                if (this.m_objViewer.m_deaDefICDdataGridView.Rows[i1].Cells["ICDCode"].Value.ToString() == sICDCode)
                {
                    MessageBox.Show("已存在相同的记录", "提示");
                    m_objViewer.m_deaDefICDdataGridView.Rows[i1].Selected = true;
                    return;
                }
            }

            bool ifContains = this.m_newArr.Contains(sICDCode);
            if (!ifContains)
            {
                m_newArr.Add(sICDCode);
            }
                       
            string[] s = new string[2];
            s[0] = sICDCode;
            s[1] = sICDName;

            int addIndex = this.m_objViewer.m_deaDefICDdataGridView.Rows.Add(s);
            this.m_objViewer.m_deaDefICDdataGridView.Rows[addIndex].Selected = true;
        }
        #endregion

        #region 删除对应ICD码
        public void RemoveDefICD()
        {
            TreeNode tn = new TreeNode();
            tn = this.m_objViewer.m_tvDisease.SelectedNode;
            if (tn == null)
            {
                MessageBox.Show("你尚未选择医保疾病", "提示");
                return;
            }

            string deaCode = tn.Tag.ToString().Trim();

            if (deaCode == "" || deaCode.ToLower() == "root")
            {
                MessageBox.Show("你尚未选择医保疾病", "提示");
                return;
            }


            if (this.m_objViewer.m_deaDefICDdataGridView.SelectedRows.Count < 1)
            {
                MessageBox.Show("你尚未选择要移去的ICD码", "提示");
                return;
            }

            string sICDCode = this.m_objViewer.m_deaDefICDdataGridView.SelectedRows[0].Cells["ICDCode"].Value.ToString(); ;
            string sICDName = this.m_objViewer.m_deaDefICDdataGridView.SelectedRows[0].Cells["ICDName"].Value.ToString();

            bool ifContains = this.m_newArr.Contains(sICDCode);
            if (ifContains)
            {
                this.m_newArr.Remove(sICDCode);
            }
            
            ifContains = this.m_removeArr.Contains(sICDCode);
            if (!ifContains)
            {
                this.m_removeArr.Add(sICDCode);
            }

            this.m_objViewer.m_deaDefICDdataGridView.Rows.RemoveAt(this.m_objViewer.m_deaDefICDdataGridView.SelectedRows[0].Index);
         }
        #endregion

        #region 保存
        public void SaveDeaDef()
        {
                        
            TreeNode tn = new TreeNode();
            tn = this.m_objViewer.m_tvDisease.SelectedNode;
            if (tn == null)
            {
                this.m_newArr.Clear();
                this.m_removeArr.Clear();
                MessageBox.Show("你尚未选择医保疾病", "提示");
                return;
            }

            string deaCode = tn.Tag.ToString().Trim();

            if (deaCode == "" || deaCode.ToLower() == "root")
            {
                this.m_newArr.Clear();
                this.m_removeArr.Clear();
                MessageBox.Show("你尚未选择医保疾病", "提示");
                return;
            }

            long lngReg = 0;
            lngReg = this.m_objDomain.SaveDeaDef(deaCode, this.m_newArr, this.m_removeArr);
            if (lngReg > 0)
            {
                this.m_newArr.Clear();
                this.m_removeArr.Clear();
                MessageBox.Show("保存成功！", "提示");
            }
            else
            {
                this.m_newArr.Clear();
                this.m_removeArr.Clear();
                MessageBox.Show("保存失败", "警告");
            }
           
        }
        #endregion
        
    }
}
