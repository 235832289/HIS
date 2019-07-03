using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// 门诊挂号收费打印处方笺
    /// baojian.mo
    /// </summary>
    public class clsControlRegisterRecipe : com.digitalwave.GUI_Base.clsController_Base
    {
        public clsControlRegisterRecipe()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 根据流水号获取处方笺信息
        /// <summary>
        /// 根据流水号获取处方笺信息
        /// </summary>
        /// <param name="p_strREGISTERNO"></param>
        /// <param name="strRegisterDate"></param>
        /// <param name="objRecipe"></param>
        /// <returns></returns>
        public long m_lngGetData(string p_strREGISTERNO, string strRegisterDate, out com.digitalwave.iCare.ValueObject.clsRegisterRecipe_VO objRecipe)
        {
            long lngRes = 0;
            objRecipe = null;
            System.Security.Principal.IPrincipal objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc objSvc = (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc));
            lngRes = objSvc.m_lngGetRecipeInfo(objPrincipal, p_strREGISTERNO, strRegisterDate, out objRecipe);
            return lngRes;
        }
        #endregion

        #region 打印处方笺
        /// <summary>
        /// 打印处方笺
        /// </summary>
        /// <param name="objRecipe"></param>
        /// <param name="p_strHospitalName"></param>
        /// <param name="p_strPrinterName"></param>
        public void m_mthPrintRecipe(com.digitalwave.iCare.ValueObject.clsRegisterRecipe_VO objRecipe, string p_strHospitalName, string p_strPrinterName)
        {
            Sybase.DataWindow.DataStore dsBill = new DataStore();
            dsBill.LibraryList = Application.StartupPath + "\\pbreport.pbl";
            dsBill.DataWindowObject = "d_opr_recipeforregister";
            try
            {
                string strTitle = dsBill.Describe("t_title.text");
                strTitle = p_strHospitalName + strTitle;
                dsBill.Modify("t_title.text = '" + strTitle + "'");
                dsBill.Modify("t_dat.text = '" + objRecipe.m_strRegisterDate + "'");
                dsBill.Modify("t_regfee.text = '" + objRecipe.m_decRegisterPay.ToString("F2") + "'");
                dsBill.Modify("t_diagfee.text = '" + objRecipe.m_decDiagPay.ToString("F2") + "'");
                dsBill.Modify("t_empid.text = '" + objRecipe.m_strEmpName + "'");
                switch (Int32.Parse(objRecipe.m_intERNALFLAG_INT))
                {
                    case 0:
                        dsBill.Modify("t_11.text = '√'");
                        break;
                    case 1:
                        dsBill.Modify("t_10.text = '√'");
                        break;
                    case 2:
                        dsBill.Modify("t_12.text = '√'");
                        break;
                    case 3:
                    case 4:
                    case 5:
                        dsBill.Modify("t_13.text = '√'");
                        break;
                    default:
                        break;
                }
                dsBill.Modify("t_ylzh.text = '" + objRecipe.m_strGOVCARD_CHR + "'");
                dsBill.Modify("t_ybkh.text = '" + objRecipe.m_strInSurancdID + "'");
                dsBill.Modify("t_fylb.text = '" + objRecipe.m_strPayTypeName + "'");
                dsBill.Modify("t_name.text = '" + objRecipe.m_strPatientName + "'");
                if (objRecipe.m_strSex.Trim() == "男")
                {
                    dsBill.Modify("t_21.text = '√'");
                }
                else if (objRecipe.m_strSex.Trim() == "女")
                {
                    dsBill.Modify("t_23.text = '√'");
                }
                dsBill.Modify("t_age.text = '" + objRecipe.m_strAge + "'");
                dsBill.Modify("t_blh.text = '" + objRecipe.m_strCardid + "'");
                dsBill.Modify("t_kb.text = '" + objRecipe.m_strDeptName + "'");
                dsBill.Modify("t_zd.text = '" + objRecipe.m_strDiag + "'");
                if (!string.IsNullOrEmpty(objRecipe.m_strRegisterDate))
                {
                    dsBill.Modify("t_year.text = '" + DateTime.Parse(objRecipe.m_strRegisterDate).Year.ToString() + "'");
                    dsBill.Modify("t_month.text = '" + DateTime.Parse(objRecipe.m_strRegisterDate).Month.ToString() + "'");
                    dsBill.Modify("t_day.text = '" + DateTime.Parse(objRecipe.m_strRegisterDate).Day.ToString() + "'");
                }
                else
                {
                    dsBill.Modify("t_year.text = ''");
                    dsBill.Modify("t_month.text = ''");
                    dsBill.Modify("t_day.text = ''");
                }
                dsBill.Modify("t_address.text = '" + objRecipe.m_strAddress + "'");
                dsBill.Modify("t_registerpay.text = '" + objRecipe.m_decRegisterPay.ToString("F2") + "'");
                dsBill.Modify("t_diagpay.text = '" + objRecipe.m_decDiagPay.ToString("F2") + "'");
                dsBill.Modify("t_wainno.text = '" + objRecipe.m_strWainno + "'");
                dsBill.PrintProperties.PrinterName = p_strPrinterName;
                dsBill.Print(false);               
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                MessageBox.Show("打印失败!\r\n\r\n" + strTmp, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}