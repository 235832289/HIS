using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 医保特种病维护界面控制层 yingrui.liu 2006-6-22
    /// </summary>
    public class clsControlYBSpecialTypeDisease : com.digitalwave.GUI_Base.clsController_Base
    {
        public clsDcl_YBSpecialTypeDisease m_objDomain;
        public clsControlYBSpecialTypeDisease()
        {
            m_objDomain = new clsDcl_YBSpecialTypeDisease();
        }
        #region 设置窗体对象	
        com.digitalwave.iCare.gui.HIS.frmYBSpecialTypeDisease m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmYBSpecialTypeDisease)frmMDI_Child_Base_in;
        }
        #endregion
        #region 获取医保特种病列表	
        public void m_mthGetYBSpecialTypeDiseaseInfo()
        {
            m_objViewer.m_lvw.Items.Clear();
            DataTable m_objResult=null;
            long lngRes =m_objDomain.m_mthGetTableForYBSpecialTypeDisease(out m_objResult);
            if (lngRes > 0 && m_objResult.Rows.Count > 0)
            {
                ListViewItem lvw;
                for (int i1 = 0; i1 < m_objResult.Rows.Count; i1++)
                {
                    lvw = new ListViewItem();
                    lvw.Tag = m_objResult.Rows[i1]["DEACODE_CHR"].ToString();
                    lvw.Text = m_objResult.Rows[i1]["DEACODE_CHR"].ToString();
                    lvw.SubItems.Add(m_objResult.Rows[i1]["DEADESC_VCHR"].ToString());
                    lvw.SubItems.Add(m_objResult.Rows[i1]["YEARMONEY_INT"].ToString());
                    if (m_objResult.Rows[i1]["SORT_INT"].ToString().Trim() != "0")
                    {
                        lvw.SubItems.Add(m_objResult.Rows[i1]["SORT_INT"].ToString());
                    }
                    else
                    {
                        lvw.SubItems.Add(string.Empty);
                    }
                    lvw.SubItems.Add(m_objResult.Rows[i1]["NOTE_VCHR"].ToString());
                    lvw.SubItems.Add(m_objResult.Rows[i1]["STATUS_INT"].ToString());
                    if (lvw.SubItems[5].Text == "0")
                    {
                        lvw.ForeColor = System.Drawing.Color.Red;
                    }
                    m_objViewer.m_lvw.Items.Add(lvw);

                }
            }
            else
            {
                m_objViewer.m_tbDiseCode.Enabled = false;
                m_objViewer.m_tbDiseName.Enabled = false;
                m_objViewer.m_tbSortNO.Enabled = false;
                m_objViewer.m_tbComment.Enabled = false;
                m_objViewer.m_tbYearMoney.Enabled = false;
                m_objViewer.m_btnNew.Focus();
            }
            if (m_objViewer.m_lvw.Items.Count > 0)
                m_objViewer.m_lvw.Items[0].Selected = true;
        }
        #endregion

        #region 保存医保特种病	
        public void m_mthSave()
        {
            if (m_objViewer.m_tbDiseCode.Text.Trim() == "")
            {
                m_objViewer.m_tbDiseCode.Focus();
                return;
            }

            long lngRes = 0;
            clsYBSpecialTypeDisease_VO m_objResult = new clsYBSpecialTypeDisease_VO();
            m_objResult.m_strDieaseCode = m_objViewer.m_tbDiseCode.Text.Trim(); 
            m_objResult.m_strDieaseNamae = m_objViewer.m_tbDiseName.Text.Trim();
            if (m_objViewer.m_tbYearMoney.Text.Trim() != "")
            {
                m_objResult.m_floatYearMoney = float.Parse(m_objViewer.m_tbYearMoney.Text.Trim());
            }
            else
            {
                m_objResult.m_floatYearMoney = 0;
            }
            if (m_objViewer.m_tbSortNO.Text.Trim() != "")
            {
                m_objResult.m_intSortNO = int.Parse(m_objViewer.m_tbSortNO.Text.Trim());
            }
            else
            {
                m_objResult.m_intSortNO = 0;
            }
            m_objResult.m_strComment = m_objViewer.m_tbComment.Text.Trim();
            if (m_objViewer.lblState.Text.Trim() == "正常")
            {
                m_objResult.m_intStatus = 1;
            }
            else
            {
                m_objResult.m_intStatus = 0;
            }

            if (m_objViewer.m_tbDiseCode.Tag == null) //新增
            {
                for (int i = 0; i < m_objViewer.m_lvw.Items.Count; i++)
                {

                    if (m_objViewer.m_lvw.Items[i].SubItems[0].Text.Trim() == m_objViewer.m_tbDiseCode.Text.Trim())
                    {
                        MessageBox.Show("该疾病代码已经存在！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        m_objViewer.m_tbDiseCode.Focus();
                        m_objViewer.m_tbDiseCode.SelectAll();
                        return;
                    }
                }
                lngRes = m_objDomain.m_mthModifyYBSpecialTypeDiseaseInfo( m_objResult);
                int index = m_objViewer.m_lvw.Items.Count;
                if (lngRes > 0)
                {
                    ListViewItem lvw = new ListViewItem();
                    lvw.Text = m_objResult.m_strDieaseCode;
                    lvw.Tag = m_objResult.m_strDieaseCode;
                    lvw.SubItems.Add(m_objResult.m_strDieaseNamae);
                    lvw.SubItems.Add(m_objResult.m_floatYearMoney.ToString());
                    if (m_objResult.m_intSortNO.ToString().Trim() != "0")
                    {
                        lvw.SubItems.Add(m_objResult.m_intSortNO.ToString());
                    }
                    else
                    {
                        lvw.SubItems.Add(string.Empty);
                    }
                    lvw.SubItems.Add(m_objResult.m_strComment);
                    lvw.SubItems.Add(m_objResult.m_intStatus.ToString());
                    if (lvw.SubItems[5].Text == "0")
                    {
                        lvw.ForeColor = System.Drawing.Color.Red;
                    }
                    m_objViewer.m_lvw.Items.Add(lvw);
                    m_objViewer.m_lvw.Items[index].Selected = true;

                }
                else
                    MessageBox.Show("保存失败！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (m_objViewer.m_lvw.SelectedItems.Count <= 0)
                {
                    return;
                }
                for (int i = 0; i < m_objViewer.m_lvw.Items.Count; i++)
                {
                    if (i == m_objViewer.m_lvw.SelectedItems[0].Index) 
                        continue;
                    if (m_objViewer.m_lvw.Items[i].SubItems[0].Text.Trim() == m_objViewer.m_tbDiseCode.Text.Trim())
                    {
                        MessageBox.Show("该疾病代码已经存在！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        m_objViewer.m_tbDiseCode.Focus();
                        m_objViewer.m_tbDiseCode.SelectAll();
                        return;
                    }
                }

                lngRes = m_objDomain.m_mthModifyYBSpecialTypeDiseaseInfo(m_objResult);
              
                if (lngRes > 0)
                {

                    MessageBox.Show("修改成功！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.m_lvw.SelectedItems[0].SubItems[0].Text = m_objResult.m_strDieaseCode;
                    m_objViewer.m_lvw.SelectedItems[0].SubItems[1].Text = m_objResult.m_strDieaseNamae;
                    m_objViewer.m_lvw.SelectedItems[0].SubItems[2].Text = m_objResult.m_floatYearMoney.ToString();
                    if (m_objResult.m_intSortNO.ToString().Trim() != "0")
                    {
                        m_objViewer.m_lvw.SelectedItems[0].SubItems[3].Text = m_objResult.m_intSortNO.ToString();
                    }
                    else
                    {
                        m_objViewer.m_lvw.SelectedItems[0].SubItems[3].Text = string.Empty;
                    }
                    m_objViewer.m_lvw.SelectedItems[0].SubItems[4].Text = m_objResult.m_strComment;
                    m_objViewer.m_lvw.SelectedItems[0].SubItems[5].Text = m_objResult.m_intStatus.ToString() ;
                }
                else
                    MessageBox.Show("修改失败！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            m_objViewer.lblState.Text = "正常";
            m_objViewer.m_tbDiseCode.Text = "";
            m_objViewer.m_tbDiseName.Text = "";
            m_objViewer.m_tbYearMoney.Text = "";
            m_objViewer.m_tbSortNO.Text = "";
            m_objViewer.m_tbComment.Text = "";
            m_objViewer.m_tbDiseCode.Tag = null;
            m_objViewer.m_tbDiseCode.Focus();

        }
        #endregion

        #region 删除医保特种病信息
        public void m_mthDeleletYBSpeInfo()
        {
            if (m_objViewer.m_lvw.Items.Count == 0 || m_objViewer.m_lvw.SelectedItems == null)
                return;
            if (m_objViewer.m_lvw.SelectedItems.Count <= 0)
            {
                return;
            }
            if (m_objViewer.m_lvw.SelectedItems[0].Tag == null)
                return;

            if (MessageBox.Show("确认删除该项吗？", "iCare", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;
            long lngRes = m_objDomain.m_mthDelectYBSpecialTypeDiseaseByDiseaseCode(m_objViewer.m_lvw.SelectedItems[0].Tag.ToString().Trim());
           
            int index = m_objViewer.m_lvw.SelectedIndices[0];
            if (lngRes > 0)
            {
                m_objViewer.m_lvw.Items.Remove(m_objViewer.m_lvw.SelectedItems[0]);
                MessageBox.Show("删除成功！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (m_objViewer.m_lvw.Items.Count > 0)
            {
                if (index > 0)
                    m_objViewer.m_lvw.Items[index - 1].Selected = true;
                else
                    m_objViewer.m_lvw.Items[index].Selected = true;
            }
            else
            {
                m_objViewer.m_tbDiseCode.Text = "";
                m_objViewer.m_tbDiseName.Text = "";
                m_objViewer.m_tbSortNO.Text="";
                m_objViewer.m_tbYearMoney.Text="";
                m_objViewer.m_tbComment.Text="";
                m_objViewer.lblState.Text = "";
                m_objViewer.m_tbDiseCode.Enabled = false;
                m_objViewer.m_tbDiseName.Enabled = false;
                m_objViewer.m_tbSortNO.Enabled = false;
                m_objViewer.m_tbComment.Enabled = false;
                m_objViewer.m_tbYearMoney.Enabled = false;
                m_objViewer.m_btnNew.Focus();

            }
        }
        #endregion
        #region 是否停用医保特种病
        public void m_mthIsStopUsing()
        {
            if (m_objViewer.m_lvw.Items.Count == 0 || m_objViewer.m_lvw.SelectedItems == null)
                return;
            if (m_objViewer.m_lvw.SelectedItems.Count <= 0)
            {
                return;
            }
            if (m_objViewer.m_lvw.SelectedItems[0].Tag == null)
                return;
            long lngRes = -1;
            if (m_objViewer.m_tbDiseCode.Text.Trim() == string.Empty || m_objViewer.m_tbDiseName.Text.Trim() == string.Empty || m_objViewer.m_tbYearMoney.Text.Trim() == string.Empty)
                return;
            clsYBSpecialTypeDisease_VO m_objResult = new clsYBSpecialTypeDisease_VO();
            m_objResult.m_strDieaseCode = m_objViewer.m_tbDiseCode.Text.Trim(); 
            m_objResult.m_strDieaseNamae = m_objViewer.m_tbDiseName.Text.Trim();
            if (m_objViewer.m_tbYearMoney.Text.Trim() != "")
            {
                m_objResult.m_floatYearMoney = float.Parse(m_objViewer.m_tbYearMoney.Text.Trim());
            }
            else
            {
                m_objResult.m_floatYearMoney = 0;
            }
            if (m_objViewer.m_tbSortNO.Text.Trim() != "")
            {
                m_objResult.m_intSortNO = int.Parse(m_objViewer.m_tbSortNO.Text.Trim());
            }
            else
            {
                m_objResult.m_intSortNO = 0;
            }
            m_objResult.m_strComment = m_objViewer.m_tbComment.Text.Trim();
            if (m_objViewer.m_btnStopUse.Tag.ToString() == "0")
            {
                m_objResult.m_intStatus = 0;//停用
            }
            else if (m_objViewer.m_btnStopUse.Tag.ToString()== "1")
            {
                m_objResult.m_intStatus = 1;//启用
            }

            lngRes = m_objDomain.m_mthModifyYBSpecialTypeDiseaseInfo(m_objResult);
            if (lngRes > 0)
            {
                if (m_objResult.m_intStatus ==0)
                {
                    MessageBox.Show("停用成功！","iCare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.lblState.Text = "已停用";
                    m_objViewer.m_btnStopUse.Text = "启用(&R)";
                    m_objViewer.m_lvw.SelectedItems[0].SubItems[5].Text = "0";
                    m_objViewer.m_btnStopUse.Tag = "1";
                    m_objViewer.m_lvw.SelectedItems[0].ForeColor = System.Drawing.Color.Red;
                }
                else if (m_objResult.m_intStatus == 1)
                {
                    MessageBox.Show("启用成功！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.lblState.Text = "正常";
                    m_objViewer.m_btnStopUse.Text = "停用(&T)";
                    m_objViewer.m_lvw.SelectedItems[0].SubItems[5].Text = "1";
                    m_objViewer.m_btnStopUse.Tag = "0";
                    m_objViewer.m_lvw.SelectedItems[0].ForeColor = System.Drawing.Color.Black;
                }


            }
            else
            {
                if (m_objViewer.m_btnStopUse.Tag.ToString() == "0")
                    MessageBox.Show("停用失败！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (m_objViewer.m_btnStopUse.Tag.ToString() == "1")
                    MessageBox.Show("启用失败！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        #endregion
        #region 获取医保特种病列表
        public void m_mthGetYBSpecialTypeDiseaseInfoByCondition(int m_intCondition,string m_strContent)
        {
            m_objViewer.m_lvw.Items.Clear();
            DataTable m_objResult = null;
            long lngRes = m_objDomain.m_mthGetTableForYBSpeTypeDiseByCondition(m_intCondition, m_strContent, out m_objResult);
            if (lngRes > 0 && m_objResult.Rows.Count > 0)
            {
                ListViewItem lvw;
                for (int i1 = 0; i1 < m_objResult.Rows.Count; i1++)
                {
                    lvw = new ListViewItem();
                    lvw.Tag = m_objResult.Rows[i1]["DEACODE_CHR"].ToString();
                    lvw.Text = m_objResult.Rows[i1]["DEACODE_CHR"].ToString();
                    lvw.SubItems.Add(m_objResult.Rows[i1]["DEADESC_VCHR"].ToString());
                    lvw.SubItems.Add(m_objResult.Rows[i1]["YEARMONEY_INT"].ToString());
                    if (m_objResult.Rows[i1]["SORT_INT"].ToString().Trim() != "0")
                    {
                        lvw.SubItems.Add(m_objResult.Rows[i1]["SORT_INT"].ToString());
                    }
                    else
                    {
                        lvw.SubItems.Add(string.Empty);
                    }
                    lvw.SubItems.Add(m_objResult.Rows[i1]["NOTE_VCHR"].ToString());
                    lvw.SubItems.Add(m_objResult.Rows[i1]["STATUS_INT"].ToString());
                    if (lvw.SubItems[5].Text == "0")
                    {
                        lvw.ForeColor = System.Drawing.Color.Red;
                    }
                    m_objViewer.m_lvw.Items.Add(lvw);

                }
            }
            else
            {
                m_objViewer.m_tbDiseCode.Text = "";
                m_objViewer.m_tbDiseName.Text = "";
                m_objViewer.m_tbSortNO.Text = "";
                m_objViewer.m_tbComment.Text = "";
                m_objViewer.m_tbYearMoney.Text = "";
                m_objViewer.lblState.Text = "";
                m_objViewer.m_btnNew.Focus();
            }
            if (m_objViewer.m_lvw.Items.Count > 0)
                m_objViewer.m_lvw.Items[0].Selected = true;
        }
        #endregion

    }
}
