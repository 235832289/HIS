using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmPATSPECREMARK : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        /// <summary>
        /// 住院号
        /// </summary>
        public string zyh = "";
        bool m_blLoad = false;
        public bool Cancel = false;
        public frmPATSPECREMARK()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_PATSPECREMARK();
            objController.Set_GUI_Apperance(this);
        }

        private void frmPATSPECREMARK_Load(object sender, EventArgs e)
        {
            ucPatientInfo1.Status = 9;
            //if (m_blload)
            //{


            frmCommonFind f = new frmCommonFind("病人查找", 9);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    zyh = f.Zyh;
                    ucPatientInfo1.m_mthFind(zyh,2);
                    ((clsCtl_PATSPECREMARK)this.objController).m_strCurrentRegisterID = ucPatientInfo1.RegisterID;

                }
                else
                {
                    Cancel = true;
                    this.Hide();
                    return;
                    
                }

               // m_blload = false;
           // }
                
                ((clsCtl_PATSPECREMARK)this.objController).LoadData(((clsCtl_PATSPECREMARK)this.objController).m_strCurrentRegisterID);
               
        }

        private void ucPatientInfo1_CardNOChanged()
        {
            if (ucPatientInfo1.IsChanged)
            {
                ((clsCtl_PATSPECREMARK)this.objController).m_strCurrentRegisterID = ucPatientInfo1.RegisterID;
                zyh = ucPatientInfo1.BihPatient_VO.Zyh;
                ((clsCtl_PATSPECREMARK)this.objController).bindtheTextBox(((clsCtl_PATSPECREMARK)this.objController).m_strCurrentRegisterID);
     

            }
        }

        private void ucPatientInfo1_ZyhChanged()
        {
            if (ucPatientInfo1.IsChanged)
            {
                ((clsCtl_PATSPECREMARK)this.objController).m_strCurrentRegisterID = ucPatientInfo1.RegisterID;
                zyh = ucPatientInfo1.BihPatient_VO.Zyh;
                ((clsCtl_PATSPECREMARK)this.objController).bindtheTextBox(((clsCtl_PATSPECREMARK)this.objController).m_strCurrentRegisterID);
     
            }
        }

        private void buttonXP1_Click(object sender, EventArgs e)
        {



            frmCommonFind f = new frmCommonFind("病人查找", 9);
        
            if (f.ShowDialog() == DialogResult.OK)
            {
                zyh = f.Zyh;
                ucPatientInfo1.m_mthFind(zyh, 2);
                ((clsCtl_PATSPECREMARK)this.objController).m_strCurrentRegisterID = ucPatientInfo1.RegisterID;
            }
            else
            {
                return;
            }
            ((clsCtl_PATSPECREMARK)this.objController).bindtheTextBox(((clsCtl_PATSPECREMARK)this.objController).m_strCurrentRegisterID);
        }

        private void cmdRefurbish_Click(object sender, EventArgs e)
        {
            ((clsCtl_PATSPECREMARK)this.objController).LoadData(((clsCtl_PATSPECREMARK)this.objController).m_strCurrentRegisterID);
            //刷新左边信息
            ucPatientInfo1.m_mthFind(zyh, 2);
            ((clsCtl_PATSPECREMARK)this.objController).m_strCurrentRegisterID = ucPatientInfo1.RegisterID;
            /*<===============================*/
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cmdSPECREMARKSave_Click(object sender, EventArgs e)
        {
            ((clsCtl_PATSPECREMARK)this.objController).SaveData();
          

       
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cmdSPECREMARKDel_Click(object sender, EventArgs e)
        {
            ((clsCtl_PATSPECREMARK)this.objController).DelData();
           
        }

     

        private void frmPATSPECREMARK_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (MessageBox.Show(this, "是否确定要退出", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    break;

                case Keys.F1:
                    cmdSPECREMARKSave_Click(null,null);
                    break;
                case Keys.F2:
                    cmdSPECREMARKDel_Click(null,null);
                    break;
                case Keys.F3:
                    buttonXP1_Click(null, null);
                    break;
                case Keys.F4:
                    cmdRefurbish_Click(null,null);
                    break;
                default:
                    break;
            }
        }

       
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ((clsCtl_PATSPECREMARK)this.objController).changeMessage();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_PATSPECREMARK)this.objController).changeMessage();
                if (dataGridView1.CurrentCell != null)
                {
                    if (dataGridView1.CurrentCell.RowIndex < dataGridView1.RowCount - 1)
                    {
                        SendKeys.Send("{UP}");
                    }
                }
            }
        }

        private void frmPATSPECREMARK_Layout(object sender, LayoutEventArgs e)
        {
            if(this.Cancel==true)
            this.Close();
        }
    }
}