using System;
using System.ComponentModel;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Drawing.Printing;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsControlPrint 的摘要说明。
	/// </summary>
	public class clsControlPrint:com.digitalwave.GUI_Base.clsController_Base
	{
		clsDomainConrol_Print m_clsDcrl = new clsDomainConrol_Print();
		public clsControlPrint()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			
		}
		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.FrmShowPrint m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (FrmShowPrint)frmMDI_Child_Base_in;
		}
		#endregion
		#region 挂号票数据

		#region  《数据库的数据》预览挂号票 zlc 2004-7-28
		public void m_ShowRegister(string strRegistID)
		{
			System.Data.DataTable dtSource = new System.Data.DataTable();			
			m_clsDcrl.m_lngGetPrintSource(strRegistID,out dtSource);
			if(dtSource .Rows.Count == 0) return;
			com.digitalwave.iCare.gui.HIS.Print.CryRegister cryregister = new com.digitalwave.iCare.gui.HIS.Print.CryRegister();
			cryregister.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation;
			cryregister.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
			cryregister.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
			cryregister.PrintOptions.PrinterDuplex = CrystalDecisions.Shared.PrinterDuplex.Default;
			((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisterID"]).Text = Convert.ToString(decimal.Parse(dtSource.Rows[0]["REGISTERNO_CHR"].ToString().Trim()));
			((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisterName"]).Text = Convert.ToString(dtSource.Rows[0]["NAME_VCHR"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strDatetime"]).Text = DateTime.Parse(dtSource.Rows[0]["REGISTERDATE_DAT"].ToString()).ToShortDateString()+" "+Convert.ToString(dtSource.Rows[0]["PLANPERIOD_CHR"]).Trim();
			((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisterWaitID"]).Text = Convert.ToString(dtSource.Rows[0]["ORDER_INT"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strDiagdept"]).Text = Convert.ToString(dtSource.Rows[0]["DEPTNAME_VCHR"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisterType"]).Text = Convert.ToString(dtSource.Rows[0]["REGISTERTYPENAME_VCHR"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strDiagAddres"]).Text = Convert.ToString(dtSource.Rows[0]["OPADDRESS_VCHR"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["mnyDiagpay"]).Text = Convert.ToString(dtSource.Rows[0]["DIAGPAY_MNY"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["mnyRegisterPay"]).Text = Convert.ToString(dtSource.Rows[0]["REGISTERPAY_MNY"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["mnyInAll"]).Text = Convert.ToString(dtSource.Rows[0]["PAYINALL_MNY"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisteremp"]).Text = Convert.ToString(dtSource.Rows[0]["REGISTEREMP_CHR"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["txtNO"]).Text = Convert.ToString(dtSource.Rows[0]["txtNO"]);
			this.m_objViewer.cryReportViewer.ReportSource = cryregister;
            this.m_objViewer.ShowDialog();
            cryregister.Close();
		}
		#endregion

		#region 前台数据
		public void m_ShowRegister1(System.Data.DataTable dtSource)
		{
			if(dtSource .Rows.Count == 0) return;
			com.digitalwave.iCare.gui.HIS.Print.CryRegister1 cryregister = new com.digitalwave.iCare.gui.HIS.Print.CryRegister1();
			#region 初始化数据
			((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisterID"]).Text = Convert.ToString(decimal.Parse(dtSource.Rows[0]["registerno"].ToString().Trim()));
			((TextObject)cryregister.ReportDefinition.ReportObjects["patienCard"]).Text = Convert.ToString(dtSource.Rows[0]["patienCard"].ToString().Trim());
			((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisterName"]).Text = Convert.ToString(dtSource.Rows[0]["patientname"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strDatetime"]).Text = dtSource.Rows[0]["date"].ToString();//+" "+Convert.ToString(dtSource.Rows[0]["PLANPERIOD_CHR"]).Trim();
			((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisterWaitID"]).Text = Convert.ToString(dtSource.Rows[0]["orderno"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strDiagdept"]).Text = Convert.ToString(dtSource.Rows[0]["strDiagdept"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisterType"]).Text = Convert.ToString(dtSource.Rows[0]["registertype"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strdoctorName"]).Text = Convert.ToString(dtSource.Rows[0]["doctorName"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strAddre"]).Text = Convert.ToString(dtSource.Rows[0]["address"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisteremp"]).Text = Convert.ToString(dtSource.Rows[0]["strEmpt"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["txtNO"]).Text = Convert.ToString(dtSource.Rows[0]["txtNO"]);
			#endregion
			cryregister.SetDataSource(dtSource);
			this.m_objViewer.cryReportViewer.ReportSource = cryregister;
			this.m_objViewer.ShowDialog();
            cryregister.Close();
		}
		#endregion


		#region 前台数据 created by weiling.huang 
		public void m_ShowRegister11(System.Data.DataTable dtSource)
		{
			if(dtSource .Rows.Count == 0) return;
			com.digitalwave.iCare.gui.HIS.Print.CryRegister11 cryregister = new com.digitalwave.iCare.gui.HIS.Print.CryRegister11();
            #region 初始化数据
            ((TextObject)cryregister.ReportDefinition.ReportObjects["patienCard"]).Text = Convert.ToString(dtSource.Rows[0]["patienCard"]);
            ((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisterName"]).Text = Convert.ToString(dtSource.Rows[0]["patientname"]);
            ((TextObject)cryregister.ReportDefinition.ReportObjects["strDatetime"]).Text = dtSource.Rows[0]["date"].ToString();
            ((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisterWaitID"]).Text = Convert.ToString(dtSource.Rows[0]["orderno"]);
            ((TextObject)cryregister.ReportDefinition.ReportObjects["strDiagdept"]).Text = Convert.ToString(dtSource.Rows[0]["strDiagdept"]);
            ((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisterType"]).Text = Convert.ToString(dtSource.Rows[0]["registertype"]);
            ((TextObject)cryregister.ReportDefinition.ReportObjects["strdoctorName"]).Text = Convert.ToString(dtSource.Rows[0]["doctorName"]);
            ((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisteremp"]).Text = Convert.ToString(dtSource.Rows[0]["strEmpt"]);
            ((TextObject)cryregister.ReportDefinition.ReportObjects["txtNO"]).Text = Convert.ToString(dtSource.Rows[0]["txtNO"]);
            ((TextObject)cryregister.ReportDefinition.ReportObjects["txtAvailDays"]).Text = "【" + Convert.ToString(dtSource.Rows[0]["txtAvailDays"]) + "天内有效】";
            ((TextObject)cryregister.ReportDefinition.ReportObjects["txtRepeatNo"]).Text = Convert.ToString(dtSource.Rows[0]["txtRepeatNo"]);

            //此处已改为挂号费

            ((TextObject)cryregister.ReportDefinition.ReportObjects["strAddre"]).Text = "￥" + dtSource.Rows[0][12].ToString();
            //此处已改为诊治费
            ((TextObject)cryregister.ReportDefinition.ReportObjects["Text1"]).Text = "￥" + dtSource.Rows[0][13].ToString();

            decimal tolMoney = (decimal)(dtSource.Rows[0][13]) + (decimal)(dtSource.Rows[0][12]);
            ((TextObject)cryregister.ReportDefinition.ReportObjects["Text4"]).Text = "￥" + Convert.ToString(tolMoney);
            #endregion
			cryregister.SetDataSource(dtSource);
			this.m_objViewer.cryReportViewer.ReportSource = cryregister;
			this.m_objViewer.ShowDialog();
            cryregister.Close();
		}
		#endregion


		#region 前台数据
		/// <summary>
		/// 前台数据
		/// </summary>
		/// <param name="dtSource"></param>
		public void m_PrintRegister1(System.Data.DataTable dtSource)
		{
			if(dtSource .Rows.Count == 0) return;
			com.digitalwave.iCare.gui.HIS.Print.CryRegister1 cryregister = new com.digitalwave.iCare.gui.HIS.Print.CryRegister1();
			#region 初始化数据
			((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisterID"]).Text = Convert.ToString(decimal.Parse(dtSource.Rows[0]["registerno"].ToString().Trim()));
			((TextObject)cryregister.ReportDefinition.ReportObjects["patienCard"]).Text = Convert.ToString(dtSource.Rows[0]["patienCard"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisterName"]).Text = Convert.ToString(dtSource.Rows[0]["patientname"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strDatetime"]).Text = dtSource.Rows[0]["date"].ToString();
			((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisterWaitID"]).Text = Convert.ToString(dtSource.Rows[0]["orderno"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strDiagdept"]).Text = Convert.ToString(dtSource.Rows[0]["strDiagdept"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisterType"]).Text = Convert.ToString(dtSource.Rows[0]["registertype"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strdoctorName"]).Text = Convert.ToString(dtSource.Rows[0]["doctorName"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strAddre"]).Text = Convert.ToString(dtSource.Rows[0]["address"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisteremp"]).Text = Convert.ToString(dtSource.Rows[0]["strEmpt"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["txtNO"]).Text = Convert.ToString(dtSource.Rows[0]["txtNO"]);
			#endregion
			cryregister.SetDataSource(dtSource);
			cryregister.PrintToPrinter(1,true,0,1);
            cryregister.Close();
		}
		#endregion

		#region 前台数据2 created by weiling.huang 
		/// <summary>
		/// 前台数据2
		/// </summary>
		/// <param name="dtSource"></param>
		public void m_PrintRegister11(System.Data.DataTable dtSource)
		{
			if(dtSource .Rows.Count == 0) return;
            com.digitalwave.iCare.gui.HIS.Print.CryRegister11 cryregister = new com.digitalwave.iCare.gui.HIS.Print.CryRegister11();
			#region 初始化数据
			((TextObject)cryregister.ReportDefinition.ReportObjects["patienCard"]).Text = Convert.ToString(dtSource.Rows[0]["patienCard"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisterName"]).Text = Convert.ToString(dtSource.Rows[0]["patientname"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strDatetime"]).Text = dtSource.Rows[0]["date"].ToString();
			((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisterWaitID"]).Text = Convert.ToString(dtSource.Rows[0]["orderno"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strDiagdept"]).Text = Convert.ToString(dtSource.Rows[0]["strDiagdept"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisterType"]).Text = Convert.ToString(dtSource.Rows[0]["registertype"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strdoctorName"]).Text = Convert.ToString(dtSource.Rows[0]["doctorName"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["strRegisteremp"]).Text = Convert.ToString(dtSource.Rows[0]["strEmpt"]);
			((TextObject)cryregister.ReportDefinition.ReportObjects["txtNO"]).Text = Convert.ToString(dtSource.Rows[0]["txtNO"]);
            ((TextObject)cryregister.ReportDefinition.ReportObjects["txtAvailDays"]).Text = "【" + Convert.ToString(dtSource.Rows[0]["txtAvailDays"]) + "天内有效】";
            ((TextObject)cryregister.ReportDefinition.ReportObjects["txtRepeatNo"]).Text = Convert.ToString(dtSource.Rows[0]["txtRepeatNo"]);

			//此处已改为挂号费

            ((TextObject)cryregister.ReportDefinition.ReportObjects["strAddre"]).Text = "￥" + dtSource.Rows[0][12].ToString();		
			//此处已改为诊治费
            ((TextObject)cryregister.ReportDefinition.ReportObjects["Text1"]).Text = "￥" + dtSource.Rows[0][13].ToString();

            decimal tolMoney = (decimal)(dtSource.Rows[0][13]) + (decimal)(dtSource.Rows[0][12]);
            ((TextObject)cryregister.ReportDefinition.ReportObjects["Text4"]).Text = "￥" + Convert.ToString(tolMoney);
			#endregion
			cryregister.SetDataSource(dtSource);
			cryregister.PrintToPrinter(1,true,0,1);
            cryregister.Close();
		}
		#endregion

		#endregion
	}
}
