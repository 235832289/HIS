using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.PatientSvc;
using CrystalDecisions;
using CrystalDecisions.CrystalReports.Engine;

namespace com.digitalwave.iCare.gui.HIS
{
	class clsCtl_PatientDailyChargeDetail : com.digitalwave.GUI_Base.clsController_Base
	{
		com.digitalwave.iCare.gui.HIS.clsDcl_StatQuery objSvc;
		com.digitalwave.iCare.gui.HIS.frmPatientChargedetail m_objViewer;
		private CrystalDecisions.CrystalReports.Engine.ReportDocument rptInHospitalLog;
		private string Registerid = "";
		private string ReportName = "";
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmPatientChargedetail)frmMDI_Child_Base_in;
		}
		public clsCtl_PatientDailyChargeDetail()
		{
			objSvc = new clsDcl_StatQuery();
		}
		#region 载入科室对应的病区
		/// <summary>
		/// 载入科室对应的病区
		/// </summary>
		public void LoadAreaID()
		{
			m_objViewer.lsvAreaInfo.Items.Clear();
			com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO[] DataResultArr =null;
			string strFilter = "WHERE ATTRIBUTEID = '0000003' AND STATUS_INT = 1 AND (shortno_chr LIKE '"+m_objViewer.m_txtAREAID_CHR.Text.ToString().Trim()+"%' or DEPTNAME_VCHR like '"+m_objViewer.m_txtAREAID_CHR.Text.ToString().Trim()+"%' or PYCODE_CHR like '"+m_objViewer.m_txtAREAID_CHR.Text.ToString().Trim()+"%' or WBCODE_CHR like '"+m_objViewer.m_txtAREAID_CHR.Text.ToString().Trim()+"%')";
			System.Windows.Forms.ListViewItem FindItem;
			long lngRes = new com.digitalwave.iCare.gui.HIS.clsDcl_Register().m_lngGetAreaInfo(strFilter,out DataResultArr);
			if(lngRes>0&&DataResultArr.Length >0)
			{
				for(int i = 0;i<DataResultArr.Length;i++)
				{
					FindItem = new ListViewItem(DataResultArr[i].m_strDEPTID_CHR);
					FindItem.SubItems.Add(DataResultArr[i].m_strDEPTNAME_VCHR);
					FindItem.Tag = DataResultArr[i];
					m_objViewer.lsvAreaInfo.Items.Add(FindItem);
				}
			}
		}
		#endregion
		#region 填充病床combox
		public void Addm_cboBed()
		{
			this.m_objViewer.m_cboBedNo.Items.Clear();
			System.Data.DataTable dtbResult = null;
			long lngRes = objSvc.m_lngGetPatientInfoForDailyCharge(this.m_objViewer.m_dtpStatDate.Value,(string)this.m_objViewer.m_txtAREAID_CHR.Tag,out dtbResult);//查询病人数据
			if(lngRes>0&&dtbResult.Rows.Count>0)
			{
				for(int i = 0;i<dtbResult.Rows.Count;i++)
				{
					this.m_objViewer.m_cboBedNo.Items.Add(dtbResult.Rows[i]["bedno"].ToString());
				}
				this.m_objViewer.m_cboBedNo.Tag = dtbResult;
			}
		}
		#endregion
		#region
		public void GetPatientDebtInfo()
		{
			string AreaID = "";
			string registerid = "";
			if(this.m_objViewer.m_txtAREAID_CHR.Tag!=null&&this.m_objViewer.m_cboBedNo.SelectedIndex>=0)
			{
				 AreaID = (string)this.m_objViewer.m_txtAREAID_CHR.Tag;
				registerid = ((DataTable)this.m_objViewer.m_cboBedNo.Tag).Rows[this.m_objViewer.m_cboBedNo.SelectedIndex]["registerid_chr"].ToString().Trim();
			}
			DataTable dtbResult = null;
			long lngRes= 0;
			if(this.m_objViewer.radioButton3.Checked == true)
			{
				lngRes = objSvc.m_lngGetPatientDebt(AreaID,registerid,this.m_objViewer.m_dtpStatDate.Value,"","",out dtbResult);
			}
			else if(this.m_objViewer.radioButton2.Checked == true)
			{
				lngRes = objSvc.m_lngGetPatientDebt(AreaID,"",this.m_objViewer.m_dtpStatDate.Value,this.m_objViewer.m_txtInpatientNo.Text.ToString().Trim(),"",out dtbResult);
			}
			else if(this.m_objViewer.radioButton1.Checked == true)
			{
				lngRes = objSvc.m_lngGetPatientDebt(AreaID,"",this.m_objViewer.m_dtpStatDate.Value,"",this.m_objViewer.m_txtPatientCard.Text.ToString().Trim(),out dtbResult);
			}
			if(lngRes>0&&dtbResult.Rows.Count==1)
			{
				this.m_objViewer.m_cboBedNo.Text = dtbResult.Rows[0]["BedNo"].ToString();
				this.m_objViewer.m_cboChargeType.Text = dtbResult.Rows[0]["PayType"].ToString();
				//				this.m_objViewer.m_totalCharge.Text = dtbResult.Rows[0]["charge_dec"].ToString();
				this.m_objViewer.m_txtAREAID_CHR.Text = dtbResult.Rows[0]["areaname"].ToString();
				this.m_objViewer.m_txtBirthDay.Text = dtbResult.Rows[0]["birth_dat"].ToString();
				//				this.m_objViewer.m_txtCharge.Text = dtbResult.Rows[0]["balance"].ToString();
				this.m_objViewer.m_txtInhospitalDate.Text=dtbResult.Rows[0]["inpatient_dat"].ToString();
				this.m_objViewer.m_txtInpatientNo.Text = dtbResult.Rows[0]["inpatientid_chr"].ToString();
				this.m_objViewer.m_txtPatientCard.Text = dtbResult.Rows[0]["patientcardid_chr"].ToString();
				this.m_objViewer.m_txtPatientName.Text = dtbResult.Rows[0]["lastname_vchr"].ToString();
				this.m_objViewer.m_txtPayType.Text = dtbResult.Rows[0]["paytype"].ToString();
				//				this.m_objViewer.m_txtPrePay.Text = dtbResult.Rows[0]["money_dec"].ToString();
				this.m_objViewer.m_txtSex.Text = dtbResult.Rows[0]["sex_chr"].ToString();
				this.Registerid = dtbResult.Rows[0]["registerid_chr"].ToString();
			}
			else
			{
				this.m_objViewer.m_cboBedNo.Text = "";
				this.m_objViewer.m_cboChargeType.Text = "";
				this.m_objViewer.m_txtAREAID_CHR.Text = "";
				this.m_objViewer.m_txtBirthDay.Text = "";
				this.m_objViewer.m_txtInhospitalDate.Text="";
				this.m_objViewer.m_txtInpatientNo.Text = "";
				this.m_objViewer.m_txtPatientCard.Text = "";
				this.m_objViewer.m_txtPatientName.Text = "";
				this.m_objViewer.m_txtPayType.Text = "";
				this.m_objViewer.m_txtSex.Text = "";
				this.Registerid = "";
			}
		}
		#endregion
		/// <summary>
		/// 病区病人欠费一览表
		/// </summary>
		public void m_mthShowInHospitalAdviceCharge()
		{
			if(this.m_objViewer.m_txtAREAID_CHR.Tag==null&&this.m_objViewer.radioButton3.Checked)
			{
				return;
			}
			if(this.m_objViewer.m_txtPatientName.Text=="")
			{
				MessageBox.Show("先查询病人");
				return;
			}
			this.m_objViewer.Cursor = Cursors.WaitCursor;
			DataTable dtbResult =new DataTable();
			rptInHospitalLog = new ReportDocument();
			rptInHospitalLog.Load(@"Report\rptPatientChargeInAdvice.rpt");
			string groupid ="";

			if(this.m_objViewer.m_cboChargeType.SelectedIndex>=0)
			{
				if(this.m_objViewer.m_cboChargeType.SelectedIndex==0)
				{
					groupid = "";
				}
				else
				{
					groupid = ((DataTable)this.m_objViewer.m_cboChargeType.Tag).Rows[this.m_objViewer.m_cboChargeType.SelectedIndex-1]["groupid_chr"].ToString();
				}
			}
			long lngRes=0;
			if(groupid=="")
			{
				lngRes  = objSvc.m_lngGetPatientDebtDetail(this.m_objViewer.m_dtpStatDate.Value,this.m_objViewer.m_dtpEnd.Value,Registerid,out dtbResult);
			}
			else
			{
				string[] types;
				lngRes  = objSvc.m_lngGetChargeItemTypesByConfigGroupID("0003",groupid,out types);
				lngRes  = objSvc.m_lngGetPatientDebtDetail(types,this.m_objViewer.m_dtpStatDate.Value,this.m_objViewer.m_dtpEnd.Value,Registerid,out dtbResult);
			}
			if(lngRes>0)
			{
				rptInHospitalLog.SetDataSource(dtbResult);		
			}
			else
			{
				return;
			}
			rptInHospitalLog.DataDefinition.FormulaFields["AreaName"].Text = "'"+this.m_objViewer.m_txtAREAID_CHR.Text.Trim()+"'";
			rptInHospitalLog.DataDefinition.FormulaFields["BedNo"].Text = "'"+this.m_objViewer.m_cboBedNo.Text.Trim()+"'";
			rptInHospitalLog.DataDefinition.FormulaFields["InhospitalNo"].Text = "'"+this.m_objViewer.m_txtInpatientNo.Text.Trim()+"'";
			rptInHospitalLog.DataDefinition.FormulaFields["Name"].Text = "'"+this.m_objViewer.m_txtPatientName.Text+"'";
			rptInHospitalLog.DataDefinition.FormulaFields["OperatorName"].Text = "'"+this.m_objViewer.LoginInfo.m_strEmpName+"'";
			rptInHospitalLog.DataDefinition.FormulaFields["Date"].Text = "'"+this.m_objViewer.m_dtpStatDate.Value.ToShortDateString()+"'";
			rptInHospitalLog.DataDefinition.FormulaFields["EndDate"].Text = "'"+this.m_objViewer.m_dtpEnd.Value.ToShortDateString()+"'";
			rptInHospitalLog.DataDefinition.FormulaFields["ReportName"].Text = "'"+this.ReportName+"'";
			this.m_objViewer.m_crvPatientCharheDetail.ReportSource = rptInHospitalLog;
			this.m_objViewer.Cursor = Cursors.Default;
		}
		public void GetGroup()
		{
			this.m_objViewer.m_cboChargeType.Items.Clear();
			this.m_objViewer.m_cboChargeType.Items.Add("全部");
			DataTable dtbResult = null;
            long lngRes = objSvc.m_lngGetDailyDebtConfig("0003",out dtbResult);
			if(lngRes>0&&dtbResult.Rows.Count>0)
			{
				for(int i = 0;i<dtbResult.Rows.Count;i++)
				{
					this.m_objViewer.m_cboChargeType.Items.Add(dtbResult.Rows[i]["groupname_chr"].ToString());
				}
				this.m_objViewer.m_cboChargeType.Tag = dtbResult;
				this.ReportName = dtbResult.Rows[0]["rptName_chr"].ToString();
				this.m_objViewer.m_cboChargeType.SelectedIndex = 0;
			}
		}
		public void Print()
		{
			if(this.rptInHospitalLog!=null)
			{
				try
				{
//						rptInHospitalLog.PrintToPrinter(this.m_objViewer.printDialog.PrinterSettings.Copies,this.m_objViewer.printDialog.PrinterSettings.Collate,this.m_objViewer.printDialog.PrinterSettings.FromPage,this.m_objViewer.printDialog.PrinterSettings.ToPage);
					this.m_objViewer.m_crvPatientCharheDetail.PrintReport();
				}
				catch(System.Exception ex)
				{
					MessageBox.Show(this.m_objViewer,ex.ToString());
				}
				
			}
		}
	}
		
}