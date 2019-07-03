using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsControlReckoningReport 的摘要说明。
	/// </summary>
	public class clsControlReckoningReport_AllDay:com.digitalwave.GUI_Base.clsController_Base
	{
		private CrystalDecisions.CrystalReports.Engine.ReportDocument m_rptRpt;
		clsDcl_ReckoningReport clsDomain;
		Double[]  Doe_ = new Double[47];
		string str_firstDate;
		int m_intSelectedIndex;
		string strEmployee="0000001";
		string strEmployeeName="001";
		public clsControlReckoningReport_AllDay()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_rptRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			clsDomain = new clsDcl_ReckoningReport();
			
		}
		
		#region 设置窗体对象	张国良	 2004-9-9
		com.digitalwave.iCare.gui.HIS.frmReckoningReport_AllDay m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmReckoningReport_AllDay)frmMDI_Child_Base_in;

			
		}
		#endregion

		#region 报表数据  张国良	 2004-9-14
		public  void m_mthFindByDateReport()
		{
			for(int i=0;i<17;i++)
			{
				Doe_[i] =0;
			}

			str_firstDate=m_objViewer.m_daFinDate.Value.ToShortDateString();
			m_intSelectedIndex = 1;

			m_rptRpt.Load("Report\\AllOPREMP_day.rpt");
			((TextObject)m_rptRpt.ReportDefinition.ReportObjects["txtReportTitle"]).Text = this.m_objComInfo.m_strGetHospitalTitle()+"收费处日结凭证";
			
			DataTable m_dtRpt = new DataTable();
			DataTable m_dtRptDitial = new DataTable();
			long lngRes;
			
			if(this.m_objViewer.LoginInfo!=null)
			{
				strEmployee=this.m_objViewer.LoginInfo.m_strEmpID;
				strEmployeeName=this.m_objViewer.LoginInfo.m_strEmpName;
			}
			lngRes =clsDomain.m_lngFindByDateReport(m_intSelectedIndex,strEmployee,str_firstDate,out m_dtRpt,out m_dtRptDitial);
			if(lngRes>=1)
			{

				for(int i=0;i<m_dtRptDitial.Rows.Count;i++)
				{
					#region 统计
					switch (m_dtRptDitial.Rows[i]["ITEMCATID_CHR"].ToString().Trim())
					{

						case "1003":					
							Doe_[3]=Doe_[3]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1004":				
							Doe_[4]=Doe_[4]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1005":				
							Doe_[5]=Doe_[5]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1006":
							Doe_[6]=Doe_[6]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1007":					
							Doe_[7]=Doe_[7]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1008":		
							Doe_[8]=Doe_[8]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;
					
						case "1009":				
							Doe_[9]=Doe_[9]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1010":		
							Doe_[10]=Doe_[10]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1011":
							Doe_[11]=Doe_[11]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1012":				
							Doe_[12]=Doe_[12]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1013":			
							Doe_[13]=Doe_[13]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1014":
							Doe_[14]=Doe_[14]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1015":					
							Doe_[15]=Doe_[15]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1016":					
							Doe_[16]=Doe_[16]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1017":					
							Doe_[17]=Doe_[17]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1018":					
							Doe_[18]=Doe_[18]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1019":					
							Doe_[19]=Doe_[19]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1020":					
							Doe_[20]=Doe_[20]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1021":					
							Doe_[21]=Doe_[21]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1022":					
							Doe_[22]=Doe_[22]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1023":					
							Doe_[23]=Doe_[23]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1024":					
							Doe_[24]=Doe_[24]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1025":					
							Doe_[25]=Doe_[25]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1026":					
							Doe_[26]=Doe_[26]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1027":					
							Doe_[27]=Doe_[27]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1028":					
							Doe_[28]=Doe_[28]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1029":					
							Doe_[29]=Doe_[29]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1030":					
							Doe_[30]=Doe_[30]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1031":					
							Doe_[31]=Doe_[31]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1032":					
							Doe_[32]=Doe_[32]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1033":					
							Doe_[33]=Doe_[33]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1034":					
							Doe_[34]=Doe_[34]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1035":					
							Doe_[35]=Doe_[35]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1036":					
							Doe_[36]=Doe_[36]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1037":					
							Doe_[37]=Doe_[37]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1038":					
							Doe_[38]=Doe_[38]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1039":					
							Doe_[39]=Doe_[39]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1040":					
							Doe_[40]=Doe_[40]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1041":					
							Doe_[41]=Doe_[41]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1042":					
							Doe_[42]=Doe_[42]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1043":					
							Doe_[43]=Doe_[43]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1044":					
							Doe_[44]=Doe_[44]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1045":					
							Doe_[45]=Doe_[45]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;

						case "1046":					
							Doe_[46]=Doe_[46]+Convert.ToDouble(m_dtRptDitial.Rows[i]["TOLFEE_MNY"]);
							break;
					}
					#endregion
				}

			}
			
				#region 付值
				if(Doe_[3] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe03"]).Text =Doe_[3].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe03"]).Text ="";

				if(Doe_[4] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe04"]).Text =Doe_[4].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe04"]).Text ="";

				if(Doe_[5] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe05"]).Text =Doe_[5].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe05"]).Text ="";

				if(Doe_[6] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe06"]).Text =Doe_[6].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe06"]).Text ="";

				if(Doe_[7] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe07"]).Text =Doe_[7].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe07"]).Text ="";

				if(Doe_[8] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe08"]).Text =Doe_[8].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe08"]).Text ="";

				if(Doe_[9] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe09"]).Text =Doe_[9].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe09"]).Text ="";

				if(Doe_[10] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe10"]).Text =Doe_[10].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe10"]).Text ="";

				if(Doe_[11] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe11"]).Text =Doe_[11].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe11"]).Text ="";

				if(Doe_[12] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe12"]).Text =Doe_[12].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe12"]).Text ="";

				if(Doe_[13] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe13"]).Text =Doe_[13].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe13"]).Text ="";

				if(Doe_[14] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe14"]).Text =Doe_[14].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe14"]).Text ="";

				if(Doe_[15] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe15"]).Text =Doe_[15].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe15"]).Text ="";

				if(Doe_[16] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe16"]).Text =Doe_[16].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe16"]).Text ="";

				if(Doe_[17] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe17"]).Text =Doe_[17].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe17"]).Text ="";

				if(Doe_[18] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe18"]).Text =Doe_[18].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe18"]).Text ="";

				if(Doe_[19] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe19"]).Text =Doe_[19].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe19"]).Text ="";

				if(Doe_[20] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe20"]).Text =Doe_[20].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe20"]).Text ="";

				if(Doe_[21] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe21"]).Text =Doe_[21].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe21"]).Text ="";

				if(Doe_[22] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe22"]).Text =Doe_[22].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe22"]).Text ="";

				if(Doe_[23] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe23"]).Text =Doe_[23].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe23"]).Text ="";

				if(Doe_[24] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe24"]).Text =Doe_[24].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe24"]).Text ="";

				if(Doe_[25] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe25"]).Text =Doe_[25].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe25"]).Text ="";

				if(Doe_[26] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe26"]).Text =Doe_[26].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe26"]).Text ="";

				if(Doe_[27] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe27"]).Text =Doe_[27].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe27"]).Text ="";

				if(Doe_[28] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe28"]).Text =Doe_[28].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe28"]).Text ="";

				if(Doe_[29] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe29"]).Text =Doe_[29].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe29"]).Text ="";

				if(Doe_[30] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe30"]).Text =Doe_[30].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe30"]).Text ="";

				if(Doe_[31] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe31"]).Text =Doe_[31].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe31"]).Text ="";

				if(Doe_[32] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe32"]).Text =Doe_[32].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe32"]).Text ="";

				if(Doe_[33] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe33"]).Text =Doe_[33].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe33"]).Text ="";

				if(Doe_[34] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe34"]).Text =Doe_[34].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe34"]).Text ="";

				if(Doe_[35] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe35"]).Text =Doe_[35].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe35"]).Text ="";

				if(Doe_[36] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe36"]).Text =Doe_[36].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe36"]).Text ="";

				if(Doe_[37] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe37"]).Text =Doe_[37].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe37"]).Text ="";

				if(Doe_[38] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe38"]).Text =Doe_[38].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe38"]).Text ="";

				if(Doe_[39] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe39"]).Text =Doe_[39].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe39"]).Text ="";

				if(Doe_[40] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe40"]).Text =Doe_[40].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe40"]).Text ="";

				if(Doe_[41] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe41"]).Text =Doe_[41].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe41"]).Text ="";

				if(Doe_[42] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe42"]).Text =Doe_[42].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe42"]).Text ="";

				if(Doe_[43] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe43"]).Text =Doe_[43].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe43"]).Text ="";

				if(Doe_[44] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe44"]).Text =Doe_[44].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe44"]).Text ="";

				if(Doe_[45] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe45"]).Text =Doe_[45].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe45"]).Text ="";

				if(Doe_[46] != 0)
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe46"]).Text =Doe_[46].ToString("0.00");
				else
					((TextObject)m_rptRpt.ReportDefinition.ReportObjects["doe46"]).Text ="";
				#endregion


				((TextObject)m_rptRpt.ReportDefinition.ReportObjects["acceptDate"]).Text ="实收日期: "+m_objViewer.m_daFinDate.Value.ToShortDateString();
			

			
			
				((TextObject)m_rptRpt.ReportDefinition.ReportObjects["statistician"]).Text ="统计员: "+strEmployeeName;
			
			m_rptRpt.SetDataSource(m_dtRpt);
			m_rptRpt.Refresh();
			m_objViewer.cryReportViewer.ReportSource=m_rptRpt;
		}
		#endregion
	}
}
