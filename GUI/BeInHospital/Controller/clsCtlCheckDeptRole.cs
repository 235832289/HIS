using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.PatientSvc;
using iCare;
using com.digitalwave.iCare.middletier.HIS;
using ControlLibrary;


namespace com.digitalwave.iCare.gui.HIS
{
    class clsCtlCheckDeptRole : com.digitalwave.GUI_Base.clsController_Base
    {
        private clsDclCheckDeptRole m_objDomain;
        #region 
        public clsCtlCheckDeptRole()
        {
            this.m_objDomain = new clsDclCheckDeptRole();
        }
        #endregion

        #region ���ô������
        private frmCheckDeptRole m_objViewer;
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            this.m_objViewer = (frmCheckDeptRole)frmMDI_Child_Base_in;
        }
        #endregion

        /// <summary>
        /// ��������
        /// </summary>
        public void LoadData()
        {
            FillListViewRole();
            FillApplyType();

        }

        #region ������н�ɫ��Ϣ
        /// <summary>
        /// ������н�ɫ��Ϣ
        /// </summary>
        private void FillListViewRole()
        {
            DataTable dt;
            long lngRes = -1;

            lngRes = m_objDomain.GetAllRole(out dt);
            if (lngRes > 0 && dt.Rows.Count > 0)
            {
                this.m_objViewer.m_lsvRole.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lvItem = new ListViewItem(dt.Rows[i]["NAME_VCHR"].ToString());
                    lvItem.SubItems.Add(dt.Rows[i]["ROLEID_CHR"].ToString());
                    this.m_objViewer.m_lsvRole.Items.Add(lvItem);
                }
            }
            if (this.m_objViewer.m_lsvRole.Items.Count > 0)
            {
                this.m_objViewer.m_lsvRole.Items[0].Selected = true;
            }

        }
        #endregion 

        #region ������м��������Ϣ
        /// <summary>
        /// ������м��������Ϣ
        /// </summary>
        private void FillApplyType()
        {
            DataTable dt;
            long lngRes = -1;

            lngRes = m_objDomain.GetAllApplyType(out dt);
            if (lngRes > 0 && dt.Rows.Count > 0)
            {
                this.m_objViewer.m_lsvApplyType.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lvItem = new ListViewItem(dt.Rows[i]["TYPETEXT"].ToString());
                    lvItem.SubItems.Add(dt.Rows[i]["TYPEID"].ToString());
                    lvItem.Tag = dt.Rows[i]["TYPEID"].ToString();
                    this.m_objViewer.m_lsvApplyType.Items.Add(lvItem);
                }
            }
            //if (this.m_objViewer.m_lsvApplyType.Items.Count > 0)
            //{
            //    this.m_objViewer.m_lsvApplyType.Items[0].Selected = true;
            //}

        }
        #endregion 

        #region ����ɫ��Ӧ�ļ��������Ϣ
        /// <summary>
        /// ����ɫ��Ӧ�ļ��������Ϣ
        /// </summary>
        public void FillCheckDeptRole()
        {
            this.m_objViewer.m_lsvCheckDeptRole.Items.Clear();

            if (this.m_objViewer.m_lsvRole.SelectedItems.Count == 0)
            {
                return;
            }

            string strRoleId = "";
            strRoleId = this.m_objViewer.m_lsvRole.SelectedItems[0].SubItems[1].Text.Trim();
            
            DataTable dt;
            long lngRes = -1;

            lngRes = m_objDomain.SelectByRoleId(strRoleId, out dt);
            if (lngRes > 0 && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lvItem = new ListViewItem(dt.Rows[i]["TYPETEXT"].ToString());
                    lvItem.SubItems.Add(dt.Rows[i]["APPLY_TYPE_INT"].ToString());
                    lvItem.SubItems.Add(dt.Rows[i]["SEQ_INT"].ToString());
                    this.m_objViewer.m_lsvCheckDeptRole.Items.Add(lvItem);
                }
            }
            if (this.m_objViewer.m_lsvCheckDeptRole.Items.Count > 0)
            {
                this.m_objViewer.m_lsvCheckDeptRole.Items[0].Selected = true;
            }

        }
        #endregion 
        
        #region ��ӽ�ɫ��鵥��Ӧ
        ///<summary>
        ///��ӽ�ɫ��鵥��Ӧ
        ///</summary>
        public void AddCheckDeptRole()
        {
            if (this.m_objViewer.m_lsvRole.SelectedItems.Count > 0)
            {
                string strRoleId;
                strRoleId = this.m_objViewer.m_lsvRole.SelectedItems[0].SubItems[1].Text;

                string strApplyType;
                strApplyType = this.m_objViewer.m_lsvApplyType.SelectedItems[0].SubItems[1].Text.Trim();

                for (int i = 0; i < this.m_objViewer.m_lsvCheckDeptRole.Items.Count; i++)
                {
                    if (strApplyType == this.m_objViewer.m_lsvCheckDeptRole.Items[i].SubItems[1].Text.Trim())
                    {
                        MessageBox.Show("�ý�ɫ�Ѿ��������������ͣ�", "ϵͳ��ʾ:", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }
               
                long lngRes = -1;
                string strSeq;

                lngRes = m_objDomain.InsertNewRow(strRoleId, strApplyType, this.m_objViewer.LoginInfo.m_strEmpID, out strSeq);
                if (lngRes > 0)
                {
                    ListViewItem lvItem = new ListViewItem(this.m_objViewer.m_lsvApplyType.SelectedItems[0].SubItems[0].Text);
                    lvItem.SubItems.Add(this.m_objViewer.m_lsvApplyType.SelectedItems[0].SubItems[1].Text);
                    lvItem.SubItems.Add(strSeq);
                    this.m_objViewer.m_lsvCheckDeptRole.Items.Add(lvItem);
                    this.m_objViewer.m_lsvCheckDeptRole.Items[this.m_objViewer.m_lsvCheckDeptRole.Items.Count - 1].Selected = true;
                }


            }
            else
            {
                MessageBox.Show("����ѡ���ɫ��", "ϵͳ��ʾ:", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                this.m_objViewer.m_lsvRole.Items[0].Selected = true;
                return;
            }
        }
        #endregion 

        ///<summary>
        ///ɾ������
        ///</summary>
        public void RemoveCheckDeptRole()
        {
            if (this.m_objViewer.m_lsvCheckDeptRole.SelectedItems.Count > 0)
            {
                string strSeq;
                strSeq = this.m_objViewer.m_lsvCheckDeptRole.SelectedItems[0].SubItems[2].Text;

                long lngRes = -1;
                lngRes = m_objDomain.DeleteRow(strSeq);
                if (lngRes > 0)
                {
                    this.m_objViewer.m_lsvCheckDeptRole.SelectedItems[0].Remove();
                    if (this.m_objViewer.m_lsvCheckDeptRole.Items.Count > 0)
                    {
                        this.m_objViewer.m_lsvCheckDeptRole.Items[0].Selected = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("����ѡ��Ҫɾ���", "ϵͳ��ʾ:", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (this.m_objViewer.m_lsvCheckDeptRole.Items.Count > 0)
                {
                    this.m_objViewer.m_lsvCheckDeptRole.Items[0].Selected = true;
                }
                return;
            }
        }

    }
}
