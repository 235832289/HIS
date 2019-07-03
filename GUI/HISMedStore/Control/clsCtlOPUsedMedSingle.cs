using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsCtlOPUsedMedSingle : com.digitalwave.GUI_Base.clsController_Base
    {
        clsDomainControlOPMedStore m_objManage = null;
        frmOPUsedMedSingle m_objViewer;

        #region 构造函数
		/// <summary>
		/// 
		/// </summary>
        public clsCtlOPUsedMedSingle()
		{
            m_objManage = new clsDomainControlOPMedStore();
		}
		#endregion
        
		#region 设置窗体对象
		/// <summary>
        /// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance (frmMDI_Child_Base_in);
            this.m_objViewer = (frmOPUsedMedSingle)frmMDI_Child_Base_in;
		}
		#endregion

        #region 查找收费项目
        /// <summary>
        /// 查找收费项目
        /// </summary>
        /// <param name="FindStr"></param>
        public void m_mthFindChargeItem(string FindStr)
        {
            if (FindStr == null || FindStr.Trim() == "")
            {
                return;
            }

            this.m_objViewer.lsvItem.BeginUpdate();
            this.m_objViewer.lsvItem.Items.Clear();

            DataTable dt;
            long l = this.m_objManage.m_lngFindChargeItem(FindStr, "0001", out dt);
            if (l > 0 && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //string invocat = m_strConvertToChType(dt.Rows[i]["itemipinvtype_chr"].ToString().Trim());   //发票分类 flag_int = 4
                    string invocat = "";
                    ListViewItem lv = new ListViewItem(FindStr);
                    lv.SubItems.Add(dt.Rows[i]["itemcode_vchr"].ToString().Trim());
                    lv.SubItems.Add(dt.Rows[i]["itemname_vchr"].ToString().Trim());
                    lv.SubItems.Add(dt.Rows[i]["itemcommname_vchr"].ToString().Trim());
                    lv.SubItems.Add(invocat);
                    lv.SubItems.Add(dt.Rows[i]["itemspec_vchr"].ToString().Trim());
                    //如果已用的是最小单位,就用小单价和最小单位                      
                    if (dt.Rows[i]["ipchargeflg_int"].ToString().Trim() == "1")
                    {
                        lv.SubItems.Add(dt.Rows[i]["itemipunit_chr"].ToString().Trim());
                        lv.SubItems.Add(dt.Rows[i]["submoney"].ToString().Trim());
                    }
                    else
                    {
                        lv.SubItems.Add(dt.Rows[i]["itemunit_chr"].ToString().Trim());
                        lv.SubItems.Add(dt.Rows[i]["itemprice_mny"].ToString().Trim());
                    }

                    string PRECENT_DEC = "100";
                    if (dt.Rows[i]["precent_dec"].ToString().Trim() != "")
                    {
                        PRECENT_DEC = dt.Rows[i]["precent_dec"].ToString().Trim();
                    }
                    lv.SubItems.Add(PRECENT_DEC + "%"); //收费比例  
                    lv.SubItems.Add(dt.Rows[i]["ybtypename"].ToString().Trim());

                    if (invocat.IndexOf("中") >= 0 || invocat.IndexOf("西") >= 0)
                    {
                        if (dt.Rows[i]["ipnoqtyflag_int"].ToString().Trim() != "0")
                        {
                            lv.SubItems.Add("缺药");
                            lv.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            lv.SubItems.Add("");
                        }
                    }
                    else
                    {
                        lv.SubItems.Add("");
                    }

                    lv.Tag = dt.Rows[i];
                    this.m_objViewer.lsvItem.Items.Add(lv);
                }
                this.m_objViewer.m_pnlItem.Height = 200;
                this.m_objViewer.lsvItem.Items[0].Selected = true;
                this.m_objViewer.lsvItem.Focus();
            }

            this.m_objViewer.lsvItem.EndUpdate();
        }
        #endregion

        internal void GetData(System.Collections.ArrayList arrayList, string CodeNo, string MedType, string BeginDate, string EndDate)
        {
            string strDeptId = "";

            if (arrayList != null && arrayList.Count > 0)
            {
                for (int i = 0; i < arrayList.Count; i++)
                {
                    strDeptId += "'" + arrayList[i].ToString() + "',";
                }
                strDeptId = strDeptId.TrimEnd(",".ToCharArray());
            }
            
            this.m_objViewer.Cursor = Cursors.WaitCursor;
            DataTable dtbResult;

            long lngRes = this.m_objManage.GetDoctorUseMedByItemId(strDeptId, CodeNo, MedType, BeginDate, EndDate, out dtbResult);
            if (lngRes > 0)
            {
                this.m_objViewer.dwMed.SetRedrawOff();
                this.m_objViewer.dwMed.Retrieve(dtbResult);


                this.m_objViewer.dwMed.Sort();
                this.m_objViewer.dwMed.CalculateGroups();

                this.m_objViewer.dwMed.Modify("t_date.text = '" + BeginDate + " - " + EndDate + "' ");
                this.m_objViewer.dwMed.Modify("t_yyname.text = '" + this.m_objComInfo.m_strGetHospitalTitle() + "'");

                this.m_objViewer.dwMed.SetRedrawOn();
                this.m_objViewer.dwMed.Refresh();
            }

            this.m_objViewer.Cursor = Cursors.Default;
        }
    }
}
