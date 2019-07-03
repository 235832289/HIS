using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.emr.BEDExplorer;
using iCareData;
using System.Collections;
using System.Drawing;
namespace iCare
{
    public partial class frmInHospitalQuery : Form
    {
        public frmInHospitalQuery()
        {
            InitializeComponent();
        }
        clsEmrDept_VO[] objDeptInfoArr = null;
        private void frmInHospitalQuery_Load(object sender, EventArgs e)
        {
            //获取科室
            clsHospitalManagerDomain objDomain = new clsHospitalManagerDomain();
    
            long lngRes = objDomain.m_lngGetDeptAreaInfo(clsEMRLogin.LoginInfo.m_strEmpID, out objDeptInfoArr);
            if (lngRes <= 0 || objDeptInfoArr == null)
            {
                if (lngRes == (long)iCareData.enmOperationResult.Not_permission)
                    clsPublicFunction.ShowInformationMessageBox("权限不足!");
                else
                    clsPublicFunction.ShowInformationMessageBox("数据库连接失败!");
                return;
            }
            DataTable deptdt = new DataTable();
            deptdt.Columns.Add("科 室 名 称");
            deptdt.Columns.Add("ID");
            if (objDeptInfoArr.Length > 0)
            {
                for (int i1 = 0; i1 < objDeptInfoArr.Length; i1++)
                {
                    DataRow newRow = deptdt.NewRow();
                    newRow[0] = objDeptInfoArr[i1].m_strDEPTNAME_VCHR;
                    newRow[1] = objDeptInfoArr[i1].m_strDEPTID_CHR;
                    deptdt.Rows.Add(newRow);
                }
            }
            this.m_txtDept.m_GetDataTable = deptdt;
            m_CreatDt();
        }
        #region 生成病人信息表
        DataTable dtPatient = new DataTable();
        private void m_CreatDt()
        {
            dtPatient.Columns.Add("病人住院号");
            dtPatient.Columns.Add("病人床号");
            dtPatient.Columns.Add("病人名称");
            dtPatient.Columns.Add("ID");
        }
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 保存查询结果
        /// </summary>
        DataTable dtQuery = new DataTable();
        private void m_cmdQuery_Click(object sender, EventArgs e)
        {
            if (m_txtDept.txtValuse.Trim() !="")
            {
                clsInHospitalMainRecordDomain_GX Domain = new clsInHospitalMainRecordDomain_GX();
                string deptstr = "";
                if (m_txtDept.Tag != null)
                {
                    deptstr = (string)m_txtDept.Tag;
                }
                string Bedstr = "";
                if (!string.IsNullOrEmpty(m_txtbedNo.Text.Trim()))
                {
                    Bedstr = m_txtbedNo.Text.Trim();
                }
                Domain.m_lngHospitalQuery(deptstr,Bedstr, out dtQuery);
                m_btnOk_Click(null, null);
            }
            else
            {
                Point p = m_txtDept.Parent.PointToScreen(m_txtDept.Location);
                toolTip1.Show("请选择科室！",m_txtDept,p.X, p.Y,1500);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void m_checkedChange(bool isSelect)
        {
            foreach (System.Windows.Forms.Control c in panel3.Controls)
            {
                if (((Control)c).GetType().Name == "CheckBox")
                {
                    ((CheckBox)c).Checked = isSelect;
                }
            }
        }

        private void m_rabSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if(m_rabSelectAll.Checked)
                 m_checkedChange(true);
        }

        private void m_rabNoselect_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rabNoselect.Checked)
                m_checkedChange(false);
        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {
            this.panel3.Visible = false;
            m_listV.Items.Clear();
            m_listV.Columns.Clear();
            ArrayList arrCheck = new ArrayList();
            m_listV.Columns.Add("病人名称",80);
            m_listV.Columns.Add("出院日期",140);
            foreach (System.Windows.Forms.Control c in panel3.Controls)
            {
                if (((Control)c).GetType().Name == "CheckBox")
                {
                    if (((CheckBox)c).Checked == true)
                    {
                        arrCheck.Add(((CheckBox)c));
                    }
                }
            }
            for (int k = arrCheck.Count - 1; k > -1; k--)
            {
                m_listV.Columns.Add(((CheckBox)arrCheck[k]).Text, 20 * ((CheckBox)arrCheck[k]).Text.Length);
            }
            if (dtQuery.Rows.Count > 0)
            {
                for (int i1 = 0; i1 < dtQuery.Rows.Count; i1++)
                {
                    ListViewItem newItem = new ListViewItem(dtQuery.Rows[i1]["LASTNAME_VCHR"].ToString());
                    newItem.UseItemStyleForSubItems = false;
                    newItem.SubItems.Add(dtQuery.Rows[i1]["MODIFY_DAT"].ToString());
                    newItem.Tag = new string[] { dtQuery.Rows[i1]["REGISTERID_CHR"].ToString(), dtQuery.Rows[i1]["EMRINPATIENTID"].ToString(),
                        dtQuery.Rows[i1]["EMRINPATIENTDATE"].ToString(),dtQuery.Rows[i1]["HISINPATIENTID_CHR"].ToString(), dtQuery.Rows[i1]["HISINPATIENTDATE"].ToString(),
                    dtQuery.Rows[i1]["DEPTID_CHR"].ToString(),dtQuery.Rows[i1]["AREAID_CHR"].ToString(),dtQuery.Rows[i1]["PATIENTID_CHR"].ToString()};
                    for (int f2 = arrCheck.Count-1; f2 > -1; f2--)
                    {
                        for (int i2 = 0; i2 < dtQuery.Columns.Count; i2++)
                        {
                            if (dtQuery.Columns[i2].ColumnName.Trim() == ((CheckBox)arrCheck[f2]).Name.Trim())
                            {
                                switch (dtQuery.Rows[i1][i2].GetType().Name)
                                {
                                    case "DBNull":
                                        newItem.SubItems.Add("未填");
                                        newItem.SubItems[newItem.SubItems.Count - 1].ForeColor = System.Drawing.Color.Red;
                                        break;
                                    case "Decimal":
                                        if (dtQuery.Rows[i1][i2].ToString() != "")
                                        {
                                            newItem.SubItems.Add("已填");
                                        }
                                        else
                                        {
                                            newItem.SubItems.Add("未填");
                                            newItem.SubItems[newItem.SubItems.Count - 1].ForeColor = System.Drawing.Color.Red;
                                        }
                                        break;
                                    case "String":
                                        if (dtQuery.Rows[i1][i2] != null && dtQuery.Rows[i1][i2].ToString() != "")
                                        {
                                            newItem.SubItems.Add("已填");
                                        }
                                        else 
                                        {
                                            newItem.SubItems.Add("未填");
                                            newItem.SubItems[newItem.SubItems.Count - 1].ForeColor = System.Drawing.Color.Red;
                                        }
                                        break;
                                    case "DateTime":
                                        newItem.SubItems.Add("已填");
                                        break;
                                    case "Int32":
                                        if (int.Parse(dtQuery.Rows[i1][i2].ToString()) > 0)
                                        {
                                            newItem.SubItems.Add("已填");
                                        }
                                        else
                                        {
                                            newItem.SubItems.Add("未填");
                                            newItem.SubItems[newItem.SubItems.Count - 1].ForeColor = System.Drawing.Color.Red;
                                            
                                        }
                                        break;
                                    case "Int16":
                                        if (int.Parse(dtQuery.Rows[i1][i2].ToString()) != -1)
                                        {
                                           
                                            switch (((CheckBox)arrCheck[f2]).Name)
                                            {
                                                case "ACCORDWITHOUTHOSPITAL":
                                                    if (int.Parse(dtQuery.Rows[i1][i2].ToString()) > 0)
                                                    {
                                                        newItem.SubItems.Add("已填");
                                                    }
                                                    else
                                                    {
                                                        newItem.SubItems.Add("未填");
                                                        newItem.SubItems[newItem.SubItems.Count - 1].ForeColor = System.Drawing.Color.Red;
                                                    }
                                                    break;
                                                case "ACCORDINWITHOUT":
                                                    if (int.Parse(dtQuery.Rows[i1][i2].ToString()) != 0)
                                                    {
                                                        newItem.SubItems.Add("已填");
                                                    }
                                                    else
                                                    {
                                                        newItem.SubItems.Add("未填");
                                                        newItem.SubItems[newItem.SubItems.Count - 1].ForeColor = System.Drawing.Color.Red;
                                                    }
                                                    break;
                                                case "ACCORDBFOPRWITHAF":
                                                    if (int.Parse(dtQuery.Rows[i1][i2].ToString()) != 0)
                                                    {
                                                        newItem.SubItems.Add("已填");
                                                    }
                                                    else
                                                    {
                                                        newItem.SubItems.Add("未填");
                                                        newItem.SubItems[newItem.SubItems.Count - 1].ForeColor = System.Drawing.Color.Red;
                                                    }
                                                    break;
                                                case "ACCORDCLINICWITHPATHOLOGY":
                                                    if (int.Parse(dtQuery.Rows[i1][i2].ToString()) != 0)
                                                    {
                                                        newItem.SubItems.Add("已填");
                                                    }
                                                    else
                                                    {
                                                        newItem.SubItems.Add("未填");
                                                        newItem.SubItems[newItem.SubItems.Count - 1].ForeColor = System.Drawing.Color.Red;
                                                    }
                                                    break;
                                                case "ACCORDCLINICWITHRADIATE":
                                                    if (int.Parse(dtQuery.Rows[i1][i2].ToString()) != 0)
                                                    {
                                                        newItem.SubItems.Add("已填");
                                                    }
                                                    else
                                                    {
                                                        newItem.SubItems.Add("未填");
                                                        newItem.SubItems[newItem.SubItems.Count - 1].ForeColor = System.Drawing.Color.Red;
                                                    }
                                                    break;
                                                case "ACCORDDEATHWITHBODYCHECK":
                                                    if (int.Parse(dtQuery.Rows[i1][i2].ToString()) != 0)
                                                    {
                                                        newItem.SubItems.Add("已填");
                                                    }
                                                    else
                                                    {
                                                        newItem.SubItems.Add("未填");
                                                        newItem.SubItems[newItem.SubItems.Count - 1].ForeColor = System.Drawing.Color.Red;
                                                    }
                                                    break;
                                                case "MAINCONDITIONSEQ":
                                                    newItem.SubItems.Add("已填");
                                                    if (int.Parse(dtQuery.Rows[i1][i2].ToString()) == 4)
                                                    {
                                                        m_listV.Columns.Insert(f2 + 2, "出院主要诊断>>疗效>>其他", 12 * 18);
                                                        if (dtQuery.Rows[i1]["OTHERMAINCONDITION"] != null && dtQuery.Rows[i1]["OTHERMAINCONDITION"].ToString() != "")
                                                        {
                                                            newItem.SubItems.Add("已填");
                                                        }
                                                        else
                                                        {
                                                            newItem.SubItems.Add("未填");
                                                            newItem.SubItems[newItem.SubItems.Count - 1].ForeColor = System.Drawing.Color.Red;
                                                        }
                                                    }
                                                    break;
                                                case "COMPLICATIONSEQ":
                                                    newItem.SubItems.Add("已填");
                                                    if (int.Parse(dtQuery.Rows[i1][i2].ToString()) == 4)
                                                    {
                                                        m_listV.Columns.Insert(f2 + 2, "并发症>>疗效>>其他", 12 * 18);
                                                        if (dtQuery.Rows[i1]["OTHERCOMPLICATION"] != null && dtQuery.Rows[i1]["OTHERCOMPLICATION"].ToString() != "")
                                                        {
                                                            newItem.SubItems.Add("已填");
                                                        }
                                                        else
                                                        {
                                                            newItem.SubItems.Add("未填");
                                                            newItem.SubItems[newItem.SubItems.Count - 1].ForeColor = System.Drawing.Color.Red;
                                                        }
                                                    }
                                                    break;
                                                case "INFECTIONCONDICTIONSEQ":
                                                    newItem.SubItems.Add("已填");
                                                    if (int.Parse(dtQuery.Rows[i1][i2].ToString()) == 4)
                                                    {
                                                        m_listV.Columns.Insert(f2 + 2, "院内感染名称>>疗效>>其他", 12 * 18);
                                                        if (dtQuery.Rows[i1]["OTHERINFECTIONCONDICTION"] != null && dtQuery.Rows[i1]["OTHERINFECTIONCONDICTION"].ToString() != "")
                                                        {
                                                            newItem.SubItems.Add("已填");
                                                        }
                                                        else
                                                        {
                                                            newItem.SubItems.Add("未填");
                                                            newItem.SubItems[newItem.SubItems.Count - 1].ForeColor = System.Drawing.Color.Red;
                                                        }
                                                    }
                                                    break;

                                                case "PATHOLOGYDIAGNOSISSEQ":
                                                    newItem.SubItems.Add("已填");
                                                    if (int.Parse(dtQuery.Rows[i1][i2].ToString()) == 4)
                                                    {
                                                        m_listV.Columns.Insert(f2 + 2, "病理诊断>>疗效>>其他", 12 * 18);
                                                        if (dtQuery.Rows[i1]["OTHERPATHOLOGYDIAGNOSIS"] != null && dtQuery.Rows[i1]["OTHERPATHOLOGYDIAGNOSIS"].ToString() != "")
                                                        {
                                                            newItem.SubItems.Add("已填");
                                                        }
                                                        else
                                                        {
                                                            newItem.SubItems.Add("未填");
                                                            newItem.SubItems[newItem.SubItems.Count - 1].ForeColor = System.Drawing.Color.Red;
                                                        }
                                                    }
                                                    break;
                                                default:
                                                    newItem.SubItems.Add("已填");
                                                        break;
                                            }
                                            
                                        }
                                        else
                                        {
                                            newItem.SubItems.Add("未填");
                                            newItem.SubItems[newItem.SubItems.Count - 1].ForeColor = System.Drawing.Color.Red;
                                        }
                                        break;
                                }
                               
                                break;
                            }
                        }
                    }
                    m_listV.Items.Add(newItem);
                }
            }
        }

        private void m_btnEsc_Click(object sender, EventArgs e)
        {
            this.panel3.Visible = false;
        }

        private void m_txtDept_Leave(object sender, EventArgs e)
        {
            //if (m_txtDept.Tag != null)
            //{
            //    clsSystemContext SystemContext = clsSystemContext.s_ObjCurrentContext;
            //    clsPatient[] PatientArr = SystemContext.m_ObjPatientManager.m_objGetPatientByLikeBedNO_NoArea((string)m_txtDept.Tag, "");
            //    m_cmdQuery.Tag = PatientArr;
            //    if (PatientArr.Length > 0)
            //    {
            //        for (int i1 = 0; i1 < PatientArr.Length; i1++)
            //        {
            //            DataRow newRow = dtPatient.NewRow();
            //            newRow[0] = PatientArr[i1].m_StrRegisterId;
            //            newRow[1] = PatientArr[i1].m_strBedCode;
            //            newRow[2] = PatientArr[i1].m_ObjPeopleInfo.m_StrLastName;
            //            newRow[3] = PatientArr[i1].m_StrPatientID;
            //            dtPatient.Rows.Add(newRow);
            //        }
            //    }
            //    this.m_txtbedNo.m_GetDataTable = dtPatient;
            //}
        }

        private void m_listV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void m_btnOther_Click(object sender, EventArgs e)
        {
            this.panel3.Visible = true;
        }

        private void m_btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_listV_DoubleClick(object sender, EventArgs e)
        {
            if (m_listV.SelectedItems.Count == 0)
                return;
            string[] strPatientArr = (string[])m_listV.SelectedItems[0].Tag;
            clsPeopleInfo objPeopleInfo = new clsPeopleInfo();
            objPeopleInfo.m_StrFirstName = m_listV.SelectedItems[0].Text;
            clsPatient objSelectPatient = new clsPatient(strPatientArr[1], strPatientArr[3], objPeopleInfo );

            objSelectPatient.m_StrPatientID = strPatientArr[7];
            objSelectPatient.m_strDeptNewID = strPatientArr[5];
            objSelectPatient.m_strAreaNewID = strPatientArr[6];
            int seleDetInt = 0;
            if (objDeptInfoArr.Length > 0)
            {
                for (int i1 = 0; i1 < objDeptInfoArr.Length; i1++)
                {
                    if (objDeptInfoArr[i1].m_strDEPTID_CHR == (string)this.m_txtDept.Tag)
                    {
                        seleDetInt = i1;
                        break;
                    }
                }
            }
            com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment = objDeptInfoArr[seleDetInt];
            frmInHospitalMainRecord_GX MainRecord = new frmInHospitalMainRecord_GX();
            MainRecord.m_mthSetPatient(objSelectPatient);
            MainRecord.MdiParent = this.ParentForm;
            MainRecord.Show();
        }
    }
}