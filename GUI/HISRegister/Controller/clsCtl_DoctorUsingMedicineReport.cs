using System;
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;
using com.digitalwave.iCare.middletier.HI;
using System.Drawing.Printing;
using System.Drawing;
using CrystalDecisions.CrystalReports.Engine;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsCtl_DoctorWorkLoadReport 的摘要说明。
	/// </summary>
	public class clsCtl_DoctorUsingMedicineReport: com.digitalwave.GUI_Base.clsController_Base
	{
		private clsDcl_DifficultyReport objSvc;
//		private string strHospitalName;
		public clsCtl_DoctorUsingMedicineReport()
		{
			objSvc=new clsDcl_DifficultyReport();
//			this.strHospitalName =m_objComInfo.m_strGetHospitalTitle();
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmDoctorUsingMedicineReport m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmDoctorUsingMedicineReport)frmMDI_Child_Base_in;
		}
		#endregion
		#region 加载部门
		public void m_mthLoadDepartment()
		{
			
			DataTable dt;
			long l =objSvc.m_mthGetDepartmentByID("",out dt);
			if(l>0&&dt.Rows.Count>0)
			{
				
				for(int i=0;i<dt.Rows.Count;i++)
				{
					this.m_objViewer.cmbDep.Item.Add(dt.Rows[i]["DEPTNAME_VCHR"].ToString().Trim(),dt.Rows[i]["DEPTID_CHR"].ToString().Trim());
				}
				this.m_objViewer.cmbDep.SelectedIndex=0;
			}
		}
		#endregion
		#region 根据部门ID查找当天排班医生,
		public void m_mthGetDocByDepID()
		{
			if(this.m_objViewer.cmbDep.SelectedIndex<0)
			{
				return;
			}
			string strID=this.m_objViewer.cmbDep.SelectItemValue;	
			if(strID=="")
			{
				return;
			}
			DataTable dt;
			long l =objSvc.m_mthGetDocByDepID(strID,out dt);
			this.m_objViewer.listView2.Items.Clear();
			if(l>0&&dt.Rows.Count>0)
			{
				ListViewItem lv;
				for(int i=0;i<dt.Rows.Count;i++)
				{
					lv=new ListViewItem(dt.Rows[i]["EMPNO_CHR"].ToString().Trim());
					lv.SubItems.Add(dt.Rows[i]["LASTNAME_VCHR"].ToString().Trim());
					if(dt.Rows[i]["ISEXPERT_CHR"].ToString().Trim()=="1")
					{
						lv.SubItems.Add("专家");
					}
					else
					{
						lv.SubItems.Add("普通");
					}
					lv.SubItems.Add(dt.Rows[i]["EMPID_CHR"].ToString().Trim());
					this.m_objViewer.listView2.Items.Add(lv);
					
				}
						

				this.m_objViewer.listView2.Items[0].Selected=true;
				this.m_objViewer.listView2.Focus();
			}
		
		}
		#endregion
		#region 查找数据
		public void m_mthGetReportData()
		{
            this.m_objViewer.objReportDocument.Load(this.m_objViewer.strAppPatch + "Report\\cptDoctorUsingMedicineReport.rpt");
			int flag =3;
			string strID ="";
			TextObject txtReportTitle=this.m_objViewer.objReportDocument.ReportDefinition.ReportObjects["Text8"] as TextObject;
			TextObject txtContext=this.m_objViewer.objReportDocument.ReportDefinition.ReportObjects["Text10"] as TextObject;
			if(this.m_objViewer.radioButton1.Checked)
			{
				flag =1;
				if(this.m_objViewer.txtCode.Tag!=null)
				{
				strID=this.m_objViewer.txtCode.Tag.ToString();
				}
				txtReportTitle.Text ="医生用药量报表";
				txtContext.Text ="医生:"+this.m_objViewer.txtName.Text+"\t统计日期:"+this.m_objViewer.dateTimePicker1.Value.ToShortDateString()+" ~ " +this.m_objViewer.dateTimePicker2.Value.ToShortDateString();
			}
			if(this.m_objViewer.radioButton3.Checked)
			{
				flag =2;
				if(this.m_objViewer.cmbDep.SelectedIndex>-1)
				{
					strID=this.m_objViewer.cmbDep.SelectItemValue;
				}
				txtReportTitle.Text ="科室用药量报表";
				txtContext.Text ="科室:"+this.m_objViewer.cmbDep.Text+"\t统计日期:"+this.m_objViewer.dateTimePicker1.Value.ToShortDateString()+" ~ " +this.m_objViewer.dateTimePicker2.Value.ToShortDateString();
			}
			if(this.m_objViewer.radioButton4.Checked)
			{
				txtReportTitle.Text =m_objComInfo.m_strGetHospitalTitle()+"用药量报表";
				txtContext.Text ="统计日期:"+this.m_objViewer.dateTimePicker1.Value.ToShortDateString()+" ~ " +this.m_objViewer.dateTimePicker2.Value.ToShortDateString();
			}

			DataTable dt;

		   long ret =objSvc.m_mthGetUsingMedicine(flag,out dt,strID,this.m_objViewer.dateTimePicker1.Value,this.m_objViewer.dateTimePicker2.Value,"");
			this.m_objViewer.objReportDocument.SetDataSource(dt);
			if(this.m_objViewer.crystalReportViewer1.ReportSource ==null)
			{
				this.m_objViewer.crystalReportViewer1.ReportSource =this.m_objViewer.objReportDocument;
			}
			else
			{
				this.m_objViewer.objReportDocument.Refresh();
				this.m_objViewer.crystalReportViewer1.RefreshReport();
			}
		}
		#endregion
		
	

	}
}
