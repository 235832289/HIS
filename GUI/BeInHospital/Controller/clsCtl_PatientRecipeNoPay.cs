using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using System.Data;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsCtl_PatientRecipeNoPay : com.digitalwave.GUI_Base.clsController_Base
    {

        #region 变量

        clsDcl_BIHTransfer objSvc;

        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmPatientRecipeNoPay m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmPatientRecipeNoPay)frmMDI_Child_Base_in;
            
        }
        #endregion

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsCtl_PatientRecipeNoPay()
        {
            objSvc = new clsDcl_BIHTransfer();
        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        
        internal void m_mthSelect()
        {
            if(this.m_objViewer.m_cboType.SelectedIndex<=0)
            {
                MessageBox.Show("请选择病人号类型!","提示框",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            List<clsRecipeNoPay_VO> m_lstRecipeNoPay_VO = new List<clsRecipeNoPay_VO>();
            long lngRes = 0;
            lngRes = objSvc.m_lngGetPatientRecipeNopayZY(this.m_objViewer.m_txtPatientNo.Text.Trim(), this.m_objViewer.m_cboType.SelectedIndex, out m_lstRecipeNoPay_VO);
            if (lngRes > 0 && m_lstRecipeNoPay_VO.Count > 0)
            {
                this.m_objViewer.m_dgvResult.Columns[0].Visible = false;
                this.m_objViewer.m_cmdAssociate.Enabled = false;
                this.m_objViewer.m_lblReminder.Visible = false;
            }
            else
            {
                lngRes = objSvc.m_lngGetPatientRecipeNopay(this.m_objViewer.m_txtPatientNo.Text.Trim(), this.m_objViewer.m_cboType.SelectedIndex, out m_lstRecipeNoPay_VO);
                this.m_objViewer.m_dgvResult.Columns[0].Visible = true;
                this.m_objViewer.m_cmdAssociate.Enabled = true;
                if (lngRes > 0 && m_lstRecipeNoPay_VO.Count > 0)
                {
                    this.m_objViewer.m_lblReminder.Visible = true;
                }
                else
                {
                    this.m_objViewer.m_lblReminder.Visible = false;
                }
                
            }

            if (lngRes > 0 && m_lstRecipeNoPay_VO.Count > 0)
            {


                this.m_objViewer.m_lblName.Text = m_lstRecipeNoPay_VO[0].m_strName;
                this.m_objViewer.m_lblSex.Text = m_lstRecipeNoPay_VO[0].m_strSex;
                this.m_mthFillData(m_lstRecipeNoPay_VO);
            }
            else
            {
                m_mthClear();
            }
            
        }
        #endregion

        #region 清除数据

        internal void m_mthClear()
        {
            this.m_objViewer.m_lblName.Text = "";
            this.m_objViewer.m_lblSex.Text = "";
            this.m_objViewer.m_dgvResult.Rows.Clear();
        }
        #endregion

        #region 填充dataGridView
        /// <summary>
        /// 填充dataGridView
        /// </summary>
        /// <param name="p_lstRecipeNoPay_VO">返回病人数据</param>
        internal void m_mthFillData(List<clsRecipeNoPay_VO> p_lstRecipeNoPay_VO)
        {
            this.m_objViewer.m_dgvResult.Rows.Clear();
            int intCount=p_lstRecipeNoPay_VO.Count;
            int intDgvRow = 0;//datagridView操作行
            clsRecipeNoPay_VO objRecipeNoPay_vo = null;
            for (int i = 0; i < intCount; i++)
            {
                objRecipeNoPay_vo = p_lstRecipeNoPay_VO[i];
                string[] sarr = new string[5];
                sarr[0]="F";
                sarr[1] = objRecipeNoPay_vo.m_strRegisterid;
                sarr[2] = objRecipeNoPay_vo.m_strRecipeid;
                if(objRecipeNoPay_vo.m_intRecipeflag==1)
                {
                    sarr[3]="正方";
                }
                else if(objRecipeNoPay_vo.m_intRecipeflag==2)
                {
                    sarr[3]="副方";
                }
              
                sarr[4]=objRecipeNoPay_vo.m_dtmRecorddate.ToString("yyyy年MM月dd日 hh:mm:ss");
                this.m_objViewer.m_dgvResult.Rows.Add(sarr);
                this.m_objViewer.m_dgvResult.Rows[intDgvRow].Tag = objRecipeNoPay_vo;


                intDgvRow++;


            }
            
        }
        #endregion

        #region 关联未交费用处方号到住院信息表里


        /// <summary>
        /// 关联未交费用处方号到住院信息表里
        /// </summary>
        internal void m_lngInsertPatientNopayRecipeZY()
        {
            if (this.m_objViewer.m_dgvResult.RowCount > 0)
            {
                int intRowCount=this.m_objViewer.m_dgvResult.RowCount;
                List<clsRecipeNoPay_VO> m_lstRecipeNoPay_VO = new List<clsRecipeNoPay_VO>();
                clsRecipeNoPay_VO objRecipeNoPay_vo = null;
                for (int i1 = 0; i1 < intRowCount; i1++)
                {
                    if (this.m_objViewer.m_dgvResult.Rows[i1].Cells[0].Value.ToString().ToUpper() == "T")
                    {
                        objRecipeNoPay_vo = (clsRecipeNoPay_VO)this.m_objViewer.m_dgvResult.Rows[i1].Tag;
                        m_lstRecipeNoPay_VO.Add(objRecipeNoPay_vo);
                    }
                }
                if (m_lstRecipeNoPay_VO.Count > 0)
                {
                    long lngRes = objSvc.m_lngInsertPatientNopayRecipeZY(m_lstRecipeNoPay_VO);
                    if (lngRes > 0)
                    {
                        MessageBox.Show("关联成功!", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.m_mthSelect();

                    }
                    else
                    {
                        MessageBox.Show("关联失败!", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
        #endregion

        #region 重算
        /// <summary>
        /// 重算病人门诊未交费用处方
        /// </summary>
        internal void m_mthReSetPatientNoPayRecipe()
        {
            if (this.m_objViewer.m_dgvResult.RowCount > 0)
            {
                int intRowCount = this.m_objViewer.m_dgvResult.RowCount;
                List<clsRecipeNoPay_VO> m_lstRecipeNoPay_VO = new List<clsRecipeNoPay_VO>();
                List<string> m_lstRecipeNoPayId = new List<string>(intRowCount);
               
                clsRecipeNoPay_VO objRecipeNoPay_vo = null;
                for (int i1 = 0; i1 < intRowCount; i1++)
                {
                    
                        objRecipeNoPay_vo = (clsRecipeNoPay_VO)this.m_objViewer.m_dgvResult.Rows[i1].Tag;
                        //m_lstRecipeNoPay_VO.Add(objRecipeNoPay_vo);
                        m_lstRecipeNoPayId.Add(objRecipeNoPay_vo.m_strRecipeid);
                    
                }
                long lngRes = objSvc.m_lngReSetPatientNoPayRecipe(this.m_objViewer.m_txtPatientNo.Text,this.m_objViewer.m_cboType.SelectedIndex,m_lstRecipeNoPayId, out m_lstRecipeNoPay_VO);
                if (m_lstRecipeNoPay_VO.Count > 0)
                {
                    this.m_mthFillData(m_lstRecipeNoPay_VO);
                }
                else
                {
                    this.m_objViewer.m_dgvResult.Rows.Clear();
                    MessageBox.Show("已重算,无未交门诊处方费用", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion


    }
}
