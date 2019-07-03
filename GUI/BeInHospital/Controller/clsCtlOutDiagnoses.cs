using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using com.digitalwave.iCare.gui.Security;
using com.digitalwave.iCare.middletier.baseInfo;//baseInfo_Svc.dll
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsCtlOutDiagnoses : com.digitalwave.GUI_Base.clsController_Base
    {
        private clsDclBihLeaHos m_objDomain;
        private frmOutDiagnoses m_objViewer;

        public clsCtlOutDiagnoses()
        {
            m_objDomain = new clsDclBihLeaHos();
      
        }

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmOutDiagnoses)frmMDI_Child_Base_in;
        }
        #endregion


        internal void ButtonFind_Click()
        {
            string condition = "";

            string strDiagnose = this.m_objViewer.m_txtDiagnose.Text.Trim();
            if (strDiagnose != null && strDiagnose != "")
            {
                condition += @" and a.diagnose_vchr like '%" + strDiagnose + "%' ";
            }
            
            //病区
            bool bolCheck = this.m_objViewer.m_checkBoxArea.Checked;
            if (bolCheck == true)
            {

                if (this.m_objViewer.m_deptIDArr != null && this.m_objViewer.m_deptIDArr.Count > 0)
                {
                    string strAreaId = "";
                    for (int i = 0; i < this.m_objViewer.m_deptIDArr.Count; i++)
                    {
                        strAreaId += "'" + this.m_objViewer.m_deptIDArr[i] + "',";
                    }
                    strAreaId = strAreaId.TrimEnd(",".ToCharArray());

                    condition += @" and a.outareaid_chr in (" + strAreaId + ")";
                }
            }

            //日期
            string strFrom = this.m_objViewer.m_dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00";

            string strTo = this.m_objViewer.m_dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59";

            condition += @" and a.outhospital_dat > to_date('" + strFrom + "', 'yyyy-MM-dd HH24:MI:SS')"
                           + @" and a.outhospital_dat < to_date('" + strTo + "', 'yyyy-MM-dd HH24:MI:SS')";

            long lngRes = 0;
            DataTable dt = new DataTable();
            lngRes = m_objDomain.GetOutDiagnoses(condition, out dt);

            this.m_objViewer.m_dwOutDiagnoses.SetRedrawOff();
            this.m_objViewer.m_dwOutDiagnoses.Retrieve(dt);
            if (this.m_objViewer.m_ckbType.Checked == true)
            {
                this.m_objViewer.m_dwOutDiagnoses.SetFilter("t_opr_bih_leave_type_int = 1");
                this.m_objViewer.m_dwOutDiagnoses.Filter();
            }

            this.m_objViewer.m_dwOutDiagnoses.Sort();
            this.m_objViewer.m_dwOutDiagnoses.CalculateGroups();
            this.m_objViewer.m_dwOutDiagnoses.SetRedrawOn();
            this.m_objViewer.m_dwOutDiagnoses.Refresh();
        }
    }
}
