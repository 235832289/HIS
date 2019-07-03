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

        #region ����

        clsDcl_BIHTransfer objSvc;

        #endregion

        #region ���ô������
        com.digitalwave.iCare.gui.HIS.frmPatientRecipeNoPay m_objViewer;
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmPatientRecipeNoPay)frmMDI_Child_Base_in;
            
        }
        #endregion

        #region ����
        /// <summary>
        /// ����
        /// </summary>
        public clsCtl_PatientRecipeNoPay()
        {
            objSvc = new clsDcl_BIHTransfer();
        }
        #endregion

        #region ��ѯ
        /// <summary>
        /// ��ѯ
        /// </summary>
        
        internal void m_mthSelect()
        {
            if(this.m_objViewer.m_cboType.SelectedIndex<=0)
            {
                MessageBox.Show("��ѡ���˺�����!","��ʾ��",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

        #region �������

        internal void m_mthClear()
        {
            this.m_objViewer.m_lblName.Text = "";
            this.m_objViewer.m_lblSex.Text = "";
            this.m_objViewer.m_dgvResult.Rows.Clear();
        }
        #endregion

        #region ���dataGridView
        /// <summary>
        /// ���dataGridView
        /// </summary>
        /// <param name="p_lstRecipeNoPay_VO">���ز�������</param>
        internal void m_mthFillData(List<clsRecipeNoPay_VO> p_lstRecipeNoPay_VO)
        {
            this.m_objViewer.m_dgvResult.Rows.Clear();
            int intCount=p_lstRecipeNoPay_VO.Count;
            int intDgvRow = 0;//datagridView������
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
                    sarr[3]="����";
                }
                else if(objRecipeNoPay_vo.m_intRecipeflag==2)
                {
                    sarr[3]="����";
                }
              
                sarr[4]=objRecipeNoPay_vo.m_dtmRecorddate.ToString("yyyy��MM��dd�� hh:mm:ss");
                this.m_objViewer.m_dgvResult.Rows.Add(sarr);
                this.m_objViewer.m_dgvResult.Rows[intDgvRow].Tag = objRecipeNoPay_vo;


                intDgvRow++;


            }
            
        }
        #endregion

        #region ����δ�����ô����ŵ�סԺ��Ϣ����


        /// <summary>
        /// ����δ�����ô����ŵ�סԺ��Ϣ����
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
                        MessageBox.Show("�����ɹ�!", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.m_mthSelect();

                    }
                    else
                    {
                        MessageBox.Show("����ʧ��!", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
        #endregion

        #region ����
        /// <summary>
        /// ���㲡������δ�����ô���
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
                    MessageBox.Show("������,��δ�����ﴦ������", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion


    }
}
