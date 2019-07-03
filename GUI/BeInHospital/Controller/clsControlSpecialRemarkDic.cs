using System.Collections.Generic;
using System.Text;
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
    public class clsControlSpecialRemarkDic:com.digitalwave.GUI_Base.clsController_Base
    {
        private clsDomainSpecialRemarkDic m_objDomainManage = null;
        public DataTable m_objTable = null;
        public clsControlSpecialRemarkDic()
        {
            m_objDomainManage = new clsDomainSpecialRemarkDic();
            m_objTable = new DataTable();
        }
        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.SpecialRemarkDictionary m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (SpecialRemarkDictionary)frmMDI_Child_Base_in;
		}
		#endregion
        public void m_mthLoadData()
        {
            try
            {
                m_objDomainManage.m_lngGetSpecialRemarkDic(out m_objTable);
                BindingSource m_objBS = new BindingSource();
                m_objBS.DataSource = m_objTable;
                this.m_objViewer.m_dgvSpecialRemarkDic.CurrentCellChanged -= new System.EventHandler(m_objViewer.m_dgvSpecialRemarkDic_CurrentCellChanged);
                m_objViewer.m_dgvSpecialRemarkDic.DataSource = m_objBS.DataSource;
                if (m_objViewer.m_dgvSpecialRemarkDic.Rows.Count > 0)
                {
                    m_objViewer.m_dgvSpecialRemarkDic.Rows[0].Selected = true;
                }
                this.m_objViewer.m_dgvSpecialRemarkDic.CurrentCellChanged+= new System.EventHandler(m_objViewer.m_dgvSpecialRemarkDic_CurrentCellChanged);
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取数据发生错误！+"+ex.ToString());
            }
        }
        public void m_mthDataGridViewCellChanged()
        {
            if (this.m_objViewer.m_dgvSpecialRemarkDic.CurrentCell != null)
            {
                int m_intCurrentCell = this.m_objViewer.m_dgvSpecialRemarkDic.CurrentCell.RowIndex;
                if (m_intCurrentCell >= 0)
                {
                    this.m_objViewer.m_txtRemarkID.Text = this.m_objTable.Rows[m_intCurrentCell]["REMARKID_CHR"].ToString();
                    this.m_objViewer.m_txtUserCode.Text = this.m_objTable.Rows[m_intCurrentCell]["USERCODE_VCHR"].ToString();
                    this.m_objViewer.m_txtRemarkContent.Text = this.m_objTable.Rows[m_intCurrentCell]["REMARKNAME_VCHR"].ToString();
                    this.m_objViewer.m_cboDebtControl.Text = this.m_objTable.Rows[m_intCurrentCell]["chargectl_status"].ToString().Trim();
                }
            }
            if (this.m_objViewer.m_dgvSpecialRemarkDic.RowCount <= 0)
            {
                this.m_mthClear();
            }
        }
        #region 清空
        public void m_mthClear()
        {
          
            this.m_objViewer.m_cboDebtControl.Text = "";
            this.m_objViewer.m_txtUserCode.Text="";
            this.m_objViewer.m_txtRemarkContent.Text="";
  
        }
        #endregion 
        #region 获取注释编号
        public void m_mthGetRemarkID()
        {
            string m_strRemarkID = "";
            this.m_objDomainManage.m_lngGetSpecialRemarkID(ref m_strRemarkID);
            if (m_strRemarkID.Length < 7 && m_strRemarkID.Length > 0)
            {
                m_strRemarkID = "0000000" + m_strRemarkID;
                m_strRemarkID = m_strRemarkID.Substring(m_strRemarkID.Length- 7);
            }
            this.m_objViewer.m_txtRemarkID.Text = m_strRemarkID.Trim();
        }
        #endregion 
        #region 保存特殊注释字典
        public void m_mthSaveSpecialRemarkDic()
        {
            clsSpecialRemarkDicVo m_objVo = new clsSpecialRemarkDicVo();
            if (this.m_objViewer.m_txtUserCode.Text.Trim() == string.Empty)
            {
                MessageBox.Show("用户编码不能为空！", "iCare系统温馨提示:", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                this.m_objViewer.m_txtUserCode.Focus();                return;
            }
            m_objVo.m_strRemarkID = this.m_objViewer.m_txtRemarkID.Text.Trim();
            m_objVo.m_strRemarkContent = this.m_objViewer.m_txtRemarkContent.Text.Trim();
            m_objVo.m_strUserCode = this.m_objViewer.m_txtUserCode.Text.Trim();
            if (this.m_objViewer.m_cboDebtControl.SelectedIndex == 1)
            {
                m_objVo.m_intDebtControll = 1;
            }
            else
            {
                m_objVo.m_intDebtControll = 0;
            }
            string m_strResult = "";
            this.m_objDomainManage.m_lngModifySpecialRemakDic(m_objVo, ref m_strResult);
            MessageBox.Show(m_strResult, "iCare提示信息！", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (m_strResult == "添加成功！")
            {
                DataRow m_objDataRow = m_objTable.NewRow();
                m_objDataRow["REMARKID_CHR"]=m_objVo.m_strRemarkID;
                m_objDataRow["REMARKNAME_VCHR"] = m_objVo.m_strRemarkContent;
                m_objDataRow["USERCODE_VCHR"] = m_objVo.m_strUserCode;
                if(m_objVo.m_intDebtControll==0)
                {
                  m_objDataRow["chargectl_status"] ="不允许";
                }
                else
                {
                    m_objDataRow["chargectl_status"] ="允许";
                }
                m_objTable.Rows.Add(m_objDataRow);
                this.m_objViewer.m_dgvSpecialRemarkDic.DataSource = this.m_objTable;
                if (this.m_objTable.Rows.Count > 1)
                {
                    this.m_objViewer.m_dgvSpecialRemarkDic.Rows[this.m_objTable.Rows.Count - 1].Selected = true;
                }
                else
                {
                    this.m_objViewer.m_dgvSpecialRemarkDic.Rows[0].Selected = true;
                }
            }
            else if (m_strResult == "修改成功！")
            { 
                int m_intCurrentIndex=this.m_objViewer.m_dgvSpecialRemarkDic.CurrentRow.Index;
                this.m_objViewer.m_dgvSpecialRemarkDic.Rows[m_intCurrentIndex].Cells[0].Value = m_objVo.m_strRemarkID;
                this.m_objViewer.m_dgvSpecialRemarkDic.Rows[m_intCurrentIndex].Cells[1].Value= m_objVo.m_strRemarkContent;
                this.m_objViewer.m_dgvSpecialRemarkDic.Rows[m_intCurrentIndex].Cells[2].Value= m_objVo.m_strUserCode;
                if (m_objVo.m_intDebtControll == 0)
                {

                    this.m_objViewer.m_dgvSpecialRemarkDic.Rows[m_intCurrentIndex].Cells[3].Value = "不允许";
                }
                else
                {
                    this.m_objViewer.m_dgvSpecialRemarkDic.Rows[m_intCurrentIndex].Cells[3].Value = "允许";
                }
             
            }
                 

        }
        #endregion 
        #region 删除特殊注释字典
        public void m_mthDeleteSpecialRemarkDic()
        {
            string m_strRemarkID = "";
            m_strRemarkID = this.m_objViewer.m_txtRemarkID.Text.Trim();
            long m_lngRes = -1;
            m_lngRes= this.m_objDomainManage.m_lngDeleteSpecialRemarkDicByID(m_strRemarkID);
            if (m_lngRes > 0)
            {
                MessageBox.Show("删除成功！", "iCare提示信息！", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.m_mthLoadData();
            }
            else
            {
                MessageBox.Show("删除失败！", "iCare提示信息！", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        #endregion
        #region 根据条件查询特殊注释字典
        public void m_mthFindSpecialRemarkDicByCondition()
        {
            string m_strSearchCodition = this.m_objViewer.cboCondition.SelectedIndex.ToString();
            string m_strSearchContent = this.m_objViewer.m_txtSearchContent.Text.Trim();
            long m_lngRes = -1;
            m_lngRes = this.m_objDomainManage.m_lngGetSpecialRemarkDicByCondition(m_strSearchCodition, m_strSearchContent, out m_objTable);
            if (m_lngRes > 0)
            {
                this.m_objViewer.m_dgvSpecialRemarkDic.DataSource = this.m_objTable;
                if (this.m_objTable.Rows.Count > 0)
                {
                    this.m_objViewer.m_dgvSpecialRemarkDic.Rows[0].Selected = true;
                }
            }
            else
            {
                MessageBox.Show("查询失败！", "iCare提示信息！", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        #endregion 
 

    }
}
