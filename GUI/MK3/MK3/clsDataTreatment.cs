using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.iCare.ValueObject;
using System.Data;

namespace com.digitalwave.iCare.gui.LIS
{
    internal class clsDataTreatment
    {
        #region
        frmMK3Operation m_objViewer;
        #endregion

        #region
        public clsDataTreatment(frmMK3Operation p_objViewer)
        {
            m_objViewer = p_objViewer;
        }
        #endregion

        public void m_mthDataShow(clsLIS_Device_Test_ResultVO[] objOutResultArr)
        {
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("strDevice_Sample_ID", typeof(string));
            dtResult.Columns.Add("strResult", typeof(string));
            DataRow dtRow = null;
            for (int i = 0; i < objOutResultArr.Length; i++)
            {
                dtRow = dtResult.NewRow();
                dtRow["strDevice_Sample_ID"] = objOutResultArr[i].strDevice_Sample_ID;
                dtRow["strResult"] = objOutResultArr[i].strResult;
                dtResult.Rows.Add(dtRow);
            }
            //m_objViewer.m_dgvResult.DataSource = dtResult;
        }
    }
}
