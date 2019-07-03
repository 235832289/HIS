using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmMessageChange : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        private bool m_blload = true;
        public frmMessageChange()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_MessageChange();
            objController.Set_GUI_Apperance(this);
        }


        private void frmMessageChange_Load(object sender, EventArgs e)
        {

            m_mthSetEnter2Tab(new System.Windows.Forms.Control[] { m_txtOutPatientDoctor2, m_txtAREAID_CHR1 });
            //初始化下拉框
            ((clsCtl_MessageChange)this.objController).InitializationComboBox();
            //清空并初始化
           
            //this.m_cboInpatientNoType2.SelectedIndex = 0;
            ((clsCtl_MessageChange)this.objController).SetCurrentDoctor(this.LoginInfo);
            //载入科室对应的病区
            ((clsCtl_MessageChange)this.objController).LoadAreaID();
  
            //载入门诊医生信息	glzhang	2005.08.12
            ((clsCtl_MessageChange)this.objController).m_mthLoadMainDoctor();

            if (m_blload)
            {
                string zyh = "";
                frmCommonFind f = new frmCommonFind();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    zyh = f.Zyh;
                    //((clsCtl_MessageChange)this.objController).m_strInPatientID = zyh.Trim();
                    ((clsCtl_MessageChange)this.objController).m_strRegisterID = f.RegisterID.Trim();
                }
                else
                {
                    return;
                }
                
                m_blload = false;
            }
            ((clsCtl_MessageChange)this.objController).QueryPatient();


           
            
        }

        private void cmdSaveBihRegister_Click(object sender, EventArgs e)
        {
         
            long lngReg=((clsCtl_MessageChange)this.objController).m_SaveInfo();
            if(lngReg>0)
            frmMessageChange_Load(null, null);
        }

    

   

        private void cmdRefurbish_Click(object sender, EventArgs e)
        {
            frmMessageChange_Load(null, null);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMessageChange_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void frmMessageChange_KeyDown(object sender, KeyEventArgs e)
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
                    buttonXP1_Click(null, null);
                    break;
                case Keys.F2:
                    cmdSaveBihRegister_Click(null, null);
                    break;
                case Keys.F5:
                    cmdRefurbish_Click(null, null);
                    break;
                default:
                    break;
            }

            m_mthSetKeyTab(e);
        }

        private void buttonXP1_Click(object sender, EventArgs e)
        {
            string zyh = "";
            frmCommonFind f = new frmCommonFind();
            if (f.ShowDialog() == DialogResult.OK)
            {
                zyh = f.Zyh;
                //((clsCtl_MessageChange)this.objController).m_strInPatientID = zyh.Trim();
                ((clsCtl_MessageChange)this.objController).m_strRegisterID = f.RegisterID.Trim();
               
            }
            else
            {
                return;
            }
                
           
            cmdRefurbish_Click(null, null);
              
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void m_dateInHosp2_ValueChanged(object sender, EventArgs e)
        {
            ((clsCtl_MessageChange)this.objController).m_chnageTheTime();
           


        }

        private void m_txtNativeplace2_m_evtFindItem(object sender, string strFindCode, ListView lvwList)
        {
            string m_strFindCode="";
            m_strFindCode= m_txtNativeplace2.Text.Trim();
            DataTable m_dtResult = new DataTable();
            long ret = ((clsCtl_MessageChange)this.objController).m_lngGetNativeplace(m_strFindCode, out  m_dtResult);
            if ((ret > 0) && (m_dtResult.Rows.Count>0))
            {
                //dictname_vchr, pycode_chr, wbcode_chr
                for (int i = 0; i < m_dtResult.Rows.Count; i++)
                {
                    //为床号列表加上姓名及姓别 add by wjqin(06-06-21)
                    ListViewItem objItem = new ListViewItem(m_dtResult.Rows[i]["dictname_vchr"].ToString().Trim());
                    objItem.SubItems.Add(m_dtResult.Rows[i]["pycode_chr"].ToString().Trim());
                    objItem.SubItems.Add(m_dtResult.Rows[i]["wbcode_chr"].ToString().Trim());
                    /*<----------------------*/
                    objItem.Tag = m_dtResult.Rows[i]["dictname_vchr"].ToString().Trim();
                    lvwList.Items.Add(objItem);

                }

            }
        }

        private void m_txtNativeplace2_m_evtInitListView(ListView lvwList)
        {
            /** update by xzf (05-09-20) */
            lvwList.Columns.Add("籍贯", 100, HorizontalAlignment.Left);
            lvwList.Columns.Add("拼音码", 60, HorizontalAlignment.Left);
            lvwList.Columns.Add("五笔码", 70, HorizontalAlignment.Left);
            lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvwList.Width = 230;
            /* <<================================= */
        }

        private void m_txtNativeplace2_m_evtSelectItem(object sender, ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {
                m_txtNativeplace2.Text = lviSelected.SubItems[0].Text;
                m_txtNativeplace2.Tag = lviSelected.Tag;
              
            }
        }

      

       
    }
}