using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS;
using com.digitalwave.Utility;
using com.digitalwave.iCare.gui.Security;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.HIS
{
    public class  clsCtlFindPatient : com.digitalwave.GUI_Base.clsController_Base
    {
        clsDcl_BIHTransfer m_objDomain;
        
        #region 构造函数
        public clsCtlFindPatient()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
            m_objDomain = new com.digitalwave.iCare.gui.HIS.clsDcl_BIHTransfer();
		}
		#endregion 
        
        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmFindPatient m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmFindPatient)frmMDI_Child_Base_in;
        }
        #endregion

        #region  根据病人姓名、性别查找历史信息
        /// <summary>
        ///  根据病人姓名、性别查找历史信息
        /// </summary>
        /// <param name="name">病人姓名</param>
        /// <param name="sex">病人性别</param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long GetHisPatientByName(clsPatient_VO p_objPatientVO)
        {
            if (p_objPatientVO == null)
            {
                return -1;
            }
            
            DataTable dt =  new DataTable();
            long lngRes = m_objDomain.GetHisPatientByName(p_objPatientVO.m_strLASTNAME_VCHR, p_objPatientVO.m_strSEX_CHR, out dt);
            if (lngRes > 0 && dt.Rows.Count > 0)
            {
                this.m_objViewer.Cursor = Cursors.WaitCursor;
                this.m_objViewer.lsvPatient.BeginUpdate();
                this.m_objViewer.lsvPatient.Items.Clear();

                string status = "";
                string feestatus = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    switch (dt.Rows[i]["pstatus_int"].ToString())
                    {
                        case "0":
                            status = "无床";
                            break;
                        case "1":
                            status = "在床";
                            break;
                        case "2":
                            status = "预出院";
                            break;
                        case "3":
                            status = "出院";
                            break;
                        case "4":
                            status = "请假";
                            break;
                        case "999":
                            status = "门诊";
                            break;
                    }

                    switch (dt.Rows[i]["feestatus_int"].ToString())
                    {
                        case "0":
                            feestatus = "无费用";
                            break;
                        case "1":
                            feestatus = "待结";
                            break;
                        case "2":
                            feestatus = "待清";
                            break;
                        case "3":
                            feestatus = "中途清帐";
                            break;
                        case "4":
                            feestatus = "出院清帐";
                            break;
                        case "5":
                            feestatus = "呆帐清帐";
                            break;
                    }

                    ListViewItem lvitem = new ListViewItem((Convert.ToInt32(i + 1)).ToString());
                    lvitem.SubItems.Add(status);

                    if (status == "门诊")
                    {
                        lvitem.SubItems.Add("");
                        lvitem.SubItems.Add("");
                        lvitem.SubItems.Add("");
                        lvitem.SubItems.Add("");
                        lvitem.SubItems.Add(dt.Rows[i]["lastname_vchr"].ToString().Trim());
                        lvitem.SubItems.Add(dt.Rows[i]["sex_chr"].ToString().Trim());
                        if (dt.Rows[i]["cssj"].ToString().Trim() == "")
                        {
                            lvitem.SubItems.Add("");
                            lvitem.SubItems.Add("");
                        }
                        else
                        {
                            lvitem.SubItems.Add(clsPublic.CalcAge(Convert.ToDateTime(dt.Rows[i]["birth_dat"])));
                            lvitem.SubItems.Add(dt.Rows[i]["cssj"].ToString());
                        }
                        lvitem.SubItems.Add(dt.Rows[i]["homeaddress_vchr"].ToString());
                        lvitem.SubItems.Add(dt.Rows[i]["employer_vchr"].ToString());
                        lvitem.SubItems.Add("");
                        lvitem.SubItems.Add("");
                        lvitem.SubItems.Add(dt.Rows[i]["patientcardid_chr"].ToString());
                        lvitem.SubItems.Add("");
                        lvitem.SubItems.Add(dt.Rows[i]["patientid_chr"].ToString());

                        lvitem.BackColor = Color.FromArgb(115, 219, 61);
                    }
                    else
                    {
                        lvitem.SubItems.Add(feestatus);
                        lvitem.SubItems.Add(dt.Rows[i]["inpatientid_chr"].ToString().Trim());
                        lvitem.SubItems.Add(dt.Rows[i]["inpatientcount_int"].ToString());
                        lvitem.SubItems.Add(dt.Rows[i]["deptname_vchr"].ToString().Trim());
                        lvitem.SubItems.Add(dt.Rows[i]["lastname_vchr"].ToString().Trim());
                        lvitem.SubItems.Add(dt.Rows[i]["sex_chr"].ToString().Trim());
                        if (dt.Rows[i]["cssj"].ToString().Trim() == "")
                        {
                            lvitem.SubItems.Add("");
                            lvitem.SubItems.Add("");
                        }
                        else
                        {
                            lvitem.SubItems.Add(clsPublic.CalcAge(Convert.ToDateTime(dt.Rows[i]["birth_dat"])));
                            lvitem.SubItems.Add(dt.Rows[i]["cssj"].ToString());
                        }
                        lvitem.SubItems.Add(dt.Rows[i]["homeaddress_vchr"].ToString());
                        lvitem.SubItems.Add(dt.Rows[i]["employer_vchr"].ToString());
                        lvitem.SubItems.Add(dt.Rows[i]["rysj"].ToString());
                        lvitem.SubItems.Add(dt.Rows[i]["cysj"].ToString());
                        lvitem.SubItems.Add(dt.Rows[i]["patientcardid_chr"].ToString());
                        lvitem.SubItems.Add(dt.Rows[i]["registerid_chr"].ToString());
                        lvitem.SubItems.Add(dt.Rows[i]["patientid_chr"].ToString());

                        lvitem.BackColor = Color.FromArgb(255, 255, 255);
                    }


                    lvitem.ImageIndex = 0;
                    lvitem.Tag = dt.Rows[i];
                    this.m_objViewer.lsvPatient.Items.Add(lvitem);
                }

                this.m_objViewer.lblInfo.Text = "找到满足条件的记录数： " + dt.Rows.Count.ToString() + "条";

                this.m_objViewer.lsvPatient.EndUpdate();
                this.m_objViewer.Cursor = Cursors.Default;

                if (dt.Rows.Count > 0)
                {
                    //this.m_objViewer.lsvPatient.Items[0].Selected = true;
                    this.m_objViewer.lsvPatient.Focus();
                }
            }

            if (dt.Rows.Count < 1)
                lngRes = -1;

            return lngRes;
        }
        #endregion
    }
}
