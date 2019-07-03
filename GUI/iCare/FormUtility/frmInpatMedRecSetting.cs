using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.GetAllRuningFormsServ;
using iCareData;
using com.digitalwave.emr.BEDExplorer;

namespace iCare.FormUtility
{
    public partial class frmInpatMedRecSetting : Form
    {
        clsEmrDept_VO[] m_objSelectDepts;
        clsInpatMedRec_Type m_objSelectType;
        bool m_blnIsChange = false;
        bool m_blnCanDo = true;
        public frmInpatMedRecSetting()
        {
            InitializeComponent();
            m_mthInit();
        }

        private void m_mthInit()
        {
            m_mthGetAllType(null);

            clsHospitalManagerDomain objHospitalManagerDomain = new clsHospitalManagerDomain();
            clsEmrDept_VO[] objDeptArr = null;
            objHospitalManagerDomain.m_lngGetAllDeptInfoByAttributeid("0000002", out objDeptArr);
            if (objDeptArr != null)
                m_lstDept.Items.AddRange(objDeptArr);
        }

        private void m_lstForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_blnCanDo = false;
            m_mthSaveTypeDept();
            int[] intIndex = new int[m_lstDept.CheckedIndices.Count];
            m_lstDept.CheckedIndices.CopyTo(intIndex,0);
            for (int index = 0 ; index < intIndex.Length ; index++)
                m_lstDept.SetItemChecked(intIndex[index], false);
            clsInpatMedRec_Type objType = m_lstForm.SelectedItem as clsInpatMedRec_Type;
            m_txtTypeID.Tag = objType;
            m_objSelectType = objType;
            m_objSelectDepts = new clsEmrDept_VO [0];
            if (objType != null)
            {
                string[] strDepts = null;
                string[] strAreas = null;

                clsGetAllRuningFormsServ objServ =
                    (clsGetAllRuningFormsServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsGetAllRuningFormsServ));

                objServ.m_lngGetInpatMedRecDept(objType.m_strTypeID, out strDepts, out strAreas);
                if (strDepts != null && strDepts.Length > 0 && m_lstDept.Items.Count > 0)
                {
                    List<clsEmrDept_VO> arrDepts = new List<clsEmrDept_VO>(5);
                    for (int i = 0 ; i < strDepts.Length ; i++)
                    {
                        for (int j = 0 ; j <  m_lstDept.Items.Count; j++)
                        {
                            clsEmrDept_VO objDept = m_lstDept.Items[j] as clsEmrDept_VO;
                            if (strDepts[i].Trim() == objDept.m_strDEPTID_CHR.Trim())
                            {
                                m_lstDept.SetItemChecked(j, true);
                                arrDepts.Add(objDept);
                                break;
                            }
                        }
                    }
                    m_objSelectDepts = new clsEmrDept_VO[arrDepts.Count];
                    m_objSelectDepts = arrDepts.ToArray();
                }
                m_txtTypeID.Text = objType.m_strTypeID;
                m_txtFormName.Text = objType.m_strTypeName;

                m_cmdNew.Enabled = true;
                m_cmdSaveType.Enabled = true;
                m_cmdDelete.Enabled = true;
            }
             m_blnCanDo = true;
        }
        public void m_mthSaveTypeDept()
        {
            if (m_blnIsChange && m_objSelectType != null)
            {
                string[] strDepts = new string[m_lstDept.CheckedItems.Count];
                for (int index = 0 ; index < m_lstDept.CheckedItems.Count; index++)
                {
                    strDepts[index] = ((clsEmrDept_VO)m_lstDept.CheckedItems[index]).m_strDEPTID_CHR.Trim();
                }

                clsGetAllRuningFormsServ objServ =
                    (clsGetAllRuningFormsServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsGetAllRuningFormsServ));

                objServ.m_lngAddInpatMedRecDept(m_objSelectType.m_strTypeID, strDepts, strDepts);
                m_blnIsChange = false;
            }
        }

        private void m_lstDept_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!m_blnCanDo)
                return;
            List<clsEmrDept_VO> arrDepts = new List<clsEmrDept_VO>(m_lstDept.CheckedItems.Count+1);
            clsEmrDept_VO[] objDepts = new clsEmrDept_VO[m_lstDept.CheckedItems.Count];
            m_lstDept.CheckedItems.CopyTo(objDepts,0);
            arrDepts.AddRange(objDepts);
            if (e.CurrentValue == CheckState.Checked)
            {
                for (int index = 0 ; index < arrDepts.Count ; index++)
                {
                    if (arrDepts[index].m_strDEPTID_CHR.Trim() == ((clsEmrDept_VO)m_lstDept.Items[e.Index]).m_strDEPTID_CHR)
                    {
                        arrDepts.RemoveAt(index);
                        break;
                    }
                }
            }
            else
            {
                clsEmrDept_VO objdept = (clsEmrDept_VO)m_lstDept.Items[e.Index];
                arrDepts.Add(objdept);
            }
                objDepts = new clsEmrDept_VO[arrDepts.Count];
                objDepts = arrDepts.ToArray();
            if (objDepts.Length != m_objSelectDepts.Length)
            { 
                m_blnIsChange = true; 
                return;
            }
            for (int i = 0 ; i < objDepts.Length ; i++)
            {
                clsEmrDept_VO objDept = objDepts[i];
                bool blnIsFind = false;
                for (int j = 0 ; j < m_objSelectDepts.Length ; j++)
                {
                    if (objDept.m_strDEPTID_CHR.Trim() == m_objSelectDepts[j].m_strDEPTID_CHR.Trim())
                    {
                        blnIsFind = true;
                        break;
                    }
                }
                if (!blnIsFind)
                {
                    m_blnIsChange = true;
                    return;
                }
            }
            m_blnIsChange= false;
        }

        private void m_cmdNew_Click(object sender, EventArgs e)
        {
            m_txtTypeID.Text = "";
            m_txtFormName.Text = "";
            m_txtTypeID.Focus();
            m_cmdNew.Enabled = false;
            m_cmdSaveType.Enabled = true;
            m_cmdDelete.Enabled = false;
            m_txtTypeID.Tag = null;
        }

        private void m_cmdSaveType_Click(object sender, EventArgs e)
        {
            if (m_txtTypeID.Text.Trim() == "")
            {
                MessageBox.Show("请输入表单类型");
                m_txtTypeID.Focus();
                return;
            }
            if (m_txtFormName.Text.Trim() == "")
            {
                MessageBox.Show("描述");
                m_txtFormName.Focus();
                return;
            }
            clsInpatMedRec_Type objType = new clsInpatMedRec_Type();
            objType.m_strTypeID = m_txtTypeID.Text.Trim();
            objType.m_strTypeName = m_txtFormName.Text.Trim();

            clsGetAllRuningFormsServ objServ =
                (clsGetAllRuningFormsServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsGetAllRuningFormsServ));

            if (m_txtTypeID.Tag == null)
                objServ.m_lngAddInpatMedRecType(objType);
            else
                objServ.m_lngModifyInpatMedRecType(((clsInpatMedRec_Type)m_txtTypeID.Tag).m_strTypeID, objType);
            m_mthGetAllType(objType);

        }

        private void frmInpatMedRecSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_mthSaveTypeDept();
        }

        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            if (m_txtTypeID.Tag != null)
            {
                clsGetAllRuningFormsServ objServ =
                    (clsGetAllRuningFormsServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsGetAllRuningFormsServ));

                try
                {
                    objServ.m_lngDeleteInpatMedRecType((clsInpatMedRec_Type)m_txtTypeID.Tag);
                }
                catch
                {
                    MessageBox.Show("此病历表单已写有记录，不能删除！");
                }
            }
            m_txtTypeID.Text = "";
            m_txtTypeID.Tag = null;
            m_txtFormName.Text = "";
            m_mthGetAllType(null);
        }
        private void m_mthGetAllType(clsInpatMedRec_Type p_objType)
        {
            clsGetAllRuningFormsServ objServ =
                (clsGetAllRuningFormsServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsGetAllRuningFormsServ));

            clsInpatMedRec_Type[] objTypes = null;
            objServ.m_lngGetAllInpatMedRec(out objTypes);
            if (objTypes != null && objTypes.Length > 0)
            {
                m_lstForm.Items.Clear();
                m_lstForm.Items.AddRange(objTypes);
            }
            if (p_objType != null)
            {
                for (int i = 0 ; i < m_lstForm.Items.Count ; i++)
                {
                    if (((clsInpatMedRec_Type)m_lstForm.Items[i]).m_strTypeID.Trim() == p_objType.m_strTypeID.Trim())
                    {
                        m_lstForm.SetSelected(i, true);
                        break;
                    }
                }
            }
        }

        private void buttonXP1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}