using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;
using com.digitalwave.iCare.middletier.HI;
using System.Collections;
using CrystalDecisions.CrystalReports.Engine;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsCtl_DifficultyReport 的摘要说明。
	/// </summary>
	public class clsCtl_DifficultyReport: com.digitalwave.GUI_Base.clsController_Base
	{
		private clsDcl_DifficultyReport objSvc;
//		com.digitalwave.iCare.gui.HIS.Print.CryDifficultyReport objCry ;
		ReportDocument rd=new ReportDocument();
		
		public clsCtl_DifficultyReport()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			objSvc=new clsDcl_DifficultyReport();
			rd.Load("Report\\CryDifficultyReport.rpt");
//			objCry =new com.digitalwave.iCare.gui.HIS.Print.CryDifficultyReport();
		}
		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmDifficultyReport m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmDifficultyReport)frmMDI_Child_Base_in;
		}
		#endregion
		/// <summary>
		/// 数据表
		/// </summary>
		
		public void m_mthShowReport()
		{
			this.m_mthGetManiReportData();
		}
		#region 获取主框架的数据
		private void m_mthGetManiReportData()
		{
			this.m_objViewer.dataTable1.Rows.Clear();
			DataTable dt;
			DataTable dt2;
			long l =objSvc.m_mthGetManiReportData(this.m_objViewer.dateTimePicker1.Value,this.m_objViewer.dateTimePicker2.Value,out dt,out dt2);
			if(l>0&&dt.Rows.Count>0)
			{
				for(int i =0;i<dt.Rows.Count;i++)
				{
					if(dt.Rows[i]["RECIPEFLAG_INT"].ToString().Trim()=="2")
					{
						dt.Rows[i]["REGISTERCOST"]=0;
					}
					for(int i2=dt2.Rows.Count-1;i2>=0;i2--)
					{
						if(dt.Rows[i]["OUTPATRECIPEID_CHR"].ToString().Trim()==dt2.Rows[i2]["OUTPATRECIPEID_CHR"].ToString().Trim()&&dt.Rows[i]["SEQID_CHR"].ToString().Trim()==dt2.Rows[i2]["SEQID_CHR"].ToString().Trim())
						{
							switch(dt2.Rows[i2]["GROUPID_CHR"].ToString().Trim())
							{
								case "0001":
									dt.Rows[i]["CHECKSELFPAY"]=m_mthConvertToDecimal(dt.Rows[i]["CHECKSELFPAY"])+m_mthConvertToDecimal(dt2.Rows[i2]["SELFPAY"]);
									dt.Rows[i]["CHECKCHARGEUP"]=m_mthConvertToDecimal(dt.Rows[i]["CHECKCHARGEUP"])+m_mthConvertToDecimal(dt2.Rows[i2]["CHARGEUP"]);
									break;
								case "0002":
									dt.Rows[i]["CURESELFPAY"]=m_mthConvertToDecimal(dt.Rows[i]["CURESELFPAY"])+m_mthConvertToDecimal(dt2.Rows[i2]["SELFPAY"]);
									dt.Rows[i]["CURECHARGEUP"]=m_mthConvertToDecimal(dt.Rows[i]["CURECHARGEUP"])+m_mthConvertToDecimal(dt2.Rows[i2]["CHARGEUP"]);
									break;
								case "0003":
									dt.Rows[i]["MEDICINESELFPAY"]=m_mthConvertToDecimal(dt.Rows[i]["MEDICINESELFPAY"])+m_mthConvertToDecimal(dt2.Rows[i2]["SELFPAY"]);
									dt.Rows[i]["MEDICINECHARGEUP"]=m_mthConvertToDecimal(dt.Rows[i]["MEDICINECHARGEUP"])+m_mthConvertToDecimal(dt2.Rows[i2]["CHARGEUP"]);
									break;
							}
							dt2.Rows[i2].Delete();
							dt2.AcceptChanges();
						}

					}

				}
				decimal temp =1;
				for(int ii=0;ii<dt.Rows.Count;ii++)
				{
					if(dt.Rows[ii]["STATUS_INT"].ToString().Trim()=="2")
					{
						temp =-1;
					}
					else
					{
					temp =1;
					}
					DataRow dr =this.m_objViewer.dataTable1.NewRow();
					dr["date"]=dt.Rows[ii]["date"];
					dr["PatientName"]=dt.Rows[ii]["PatientName"];
					dr["DifficultyNo"]=dt.Rows[ii]["DifficultyNo"];
					dr["InvoiceNo"]=dt.Rows[ii]["InvoiceNo"];
					dr["RegisterCost"]=m_mthConvertToDecimal(dt.Rows[ii]["RegisterCost"])*temp;
					dr["CheckSelfPay"]=m_mthConvertToDecimal(dt.Rows[ii]["CheckChargeUp"])*2*temp;
					dr["CheckChargeUp"]=m_mthConvertToDecimal(dt.Rows[ii]["CheckChargeUp"])*temp;
					dr["CureSelfPay"]=m_mthConvertToDecimal(dt.Rows[ii]["CureChargeUp"])*2*temp;
					dr["CureChargeUp"]=m_mthConvertToDecimal(dt.Rows[ii]["CureChargeUp"])*temp;
					dr["MedicineSelfPay"]=m_mthConvertToDecimal(dt.Rows[ii]["MedicineChargeUp"])*2*temp;
					dr["MedicineChargeUp"]=m_mthConvertToDecimal(dt.Rows[ii]["MedicineChargeUp"])*temp;
					dr["SumChargeUp"]=m_mthConvertToDecimal(dt.Rows[ii]["RegisterCost"])*temp+m_mthConvertToDecimal(dt.Rows[ii]["CheckChargeUp"])+m_mthConvertToDecimal(dt.Rows[ii]["CureChargeUp"])+m_mthConvertToDecimal(dt.Rows[ii]["MedicineChargeUp"])*temp;
					dr["Operator"]=dt.Rows[ii]["Operator"];
				this.m_objViewer.dataTable1.Rows.Add(dr);
				}
				rd.SetDataSource(this.m_objViewer.dataTable1);
				rd.Refresh();
				this.m_objViewer.crystalReportViewer1.ReportSource=rd;
				this.m_objViewer.crystalReportViewer1.Refresh();
			}
		}
		#endregion
		#region 转换成数字
		private decimal m_mthConvertToDecimal(Object strValue)
		{
			decimal ret =0;
			try
			{
				if(strValue!=null)
				{
					ret =decimal.Parse(strValue.ToString());
				}
			}
			catch
			{
				ret=0;
			}
			return ret;

		}
		#endregion
	}
}
