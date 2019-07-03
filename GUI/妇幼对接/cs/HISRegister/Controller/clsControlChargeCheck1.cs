using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsControlChargeCheck1 的摘要说明。
	/// </summary>
	public class clsControlChargeCheck1:com.digitalwave.GUI_Base.clsController_Base
	{
		public clsControlChargeCheck1()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 设置窗体对象
		public com.digitalwave.iCare.gui.HIS.frmChargeCheck1 m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmChargeCheck1)frmMDI_Child_Base_in;
		}
		#endregion
		#region 变量
		clsDomainControl_Register Domain=new clsDomainControl_Register();
		DataTable dtChargeCheck=new DataTable();
		private System.Data.DataView m_dvRegister = new System.Data.DataView();
		/// <summary>
		/// 保存符合条件的发票信息
		/// </summary>
		DataTable dtFindCharge=null;
		#endregion
		public void m_frmLoad()
		{

			string strDateStart=this.m_objViewer.m_datFirstdate.Value.ToShortDateString();
			string strDateEnd=this.m_objViewer.m_datLastdate.Value.ToShortDateString();
			Domain.m_lngGetChargeByDate1(strDateStart,strDateEnd, out dtChargeCheck);
			#region 改变表的列名
			dtChargeCheck.Columns[0].ColumnName="诊疗卡号";
			dtChargeCheck.Columns[1].ColumnName="发票编号";
			dtChargeCheck.Columns[2].ColumnName="处方号";
			dtChargeCheck.Columns[3].ColumnName="病人身份";
			dtChargeCheck.Columns[4].ColumnName="病人名称";
			dtChargeCheck.Columns[5].ColumnName="性别";
			dtChargeCheck.Columns[6].ColumnName="支付类型";
			dtChargeCheck.Columns[7].ColumnName="发票日期";
			dtChargeCheck.Columns[8].ColumnName="科室名称";
			dtChargeCheck.Columns[9].ColumnName="医生名称";
			dtChargeCheck.Columns[10].ColumnName="收费员";
			dtChargeCheck.Columns[11].ColumnName="记帐金额";
			dtChargeCheck.Columns[12].ColumnName="自付金额";
			dtChargeCheck.Columns[13].ColumnName="合计金额";
			dtChargeCheck.Columns[14].ColumnName="病人类型";
			#endregion
			if(dtChargeCheck.Rows.Count>0)
			{
				DataRow newRow=dtChargeCheck.NewRow();
				newRow["诊疗卡号"]="总发票数";
				newRow["发票编号"]=dtChargeCheck.Rows.Count.ToString();
				dtChargeCheck.Rows.Add(newRow);
			}
			this.m_dvRegister = dtChargeCheck.DefaultView;
			this.m_objViewer.DgChargeCheck.SetDataBinding(m_dvRegister,null);
			this.m_objViewer.DgChargeCheck.Tag="dtChargeCheck";
			this.m_objViewer.DgChargeCheck.m_SetDgrStyle();
			this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["诊疗卡号"].Width = 80;
			this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["处方号"].Width = 100;
			this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["性别"].Width = 40;
			this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["科室名称"].Width = 120;
			this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["收费员"].Width = 60;
			this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["发票编号"].Width = 80;
			this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["病人类型"].Width = 0;
		}

		#region 查找
		DataView  m_dvRegisterfind=new DataView();
		public void m_mthFindData()
		{
			if(this.m_objViewer.PatienType.Text.Trim()=="全部")
			{
				this.m_dvRegister = dtChargeCheck.DefaultView;
				this.m_objViewer.DgChargeCheck.SetDataBinding(m_dvRegister,null);
				this.m_objViewer.DgChargeCheck.Tag="dtChargeCheck";
				return;
			}
			try
			{
				dtFindCharge=dtChargeCheck.Clone();
			}
			catch
			{
			}
			for(int i1=0;i1<dtChargeCheck.Rows.Count;i1++)
			{
				if(dtChargeCheck.Rows[i1]["病人类型"].ToString().IndexOf(this.m_objViewer.PatienType.Text.Trim(),0)==0)
				{
					DataRow AddRow=dtFindCharge.NewRow();
					AddRow["诊疗卡号"]=dtChargeCheck.Rows[i1]["诊疗卡号"];
					AddRow["发票编号"]=dtChargeCheck.Rows[i1]["发票编号"];
					AddRow["处方号"]=dtChargeCheck.Rows[i1]["处方号"];
					AddRow["病人身份"]=dtChargeCheck.Rows[i1]["病人身份"];
					AddRow["病人名称"]=dtChargeCheck.Rows[i1]["病人名称"];
					AddRow["性别"]=dtChargeCheck.Rows[i1]["性别"];
					AddRow["支付类型"]=dtChargeCheck.Rows[i1]["支付类型"];
					AddRow["发票日期"]=dtChargeCheck.Rows[i1]["发票日期"];
					AddRow["科室名称"]=dtChargeCheck.Rows[i1]["科室名称"];
					AddRow["医生名称"]=dtChargeCheck.Rows[i1]["医生名称"];
					AddRow["收费员"]=dtChargeCheck.Rows[i1]["收费员"];
					AddRow["记帐金额"]=dtChargeCheck.Rows[i1]["记帐金额"];
					AddRow["自付金额"]=dtChargeCheck.Rows[i1]["自付金额"];
					AddRow["合计金额"]=dtChargeCheck.Rows[i1]["合计金额"];
					AddRow["病人类型"]=dtChargeCheck.Rows[i1]["病人类型"];
					dtFindCharge.Rows.Add(AddRow);
				}
			}
			if(dtFindCharge.Rows.Count>0)
			{
				DataRow newRow=dtFindCharge.NewRow();
				newRow["诊疗卡号"]="总发票数";
				newRow["发票编号"]=dtFindCharge.Rows.Count.ToString();
				dtFindCharge.Rows.Add(newRow);
				m_dvRegisterfind=dtFindCharge.DefaultView;
				this.m_objViewer.DgChargeCheck.SetDataBinding(m_dvRegisterfind,null);
				this.m_objViewer.DgChargeCheck.Tag="dtFindCharge";
			}
			else
			{
				this.m_objViewer.DgChargeCheck.SetDataBinding(null,null);
				this.m_objViewer.DgChargeCheck.Tag="dtFindCharge";
			}
		}
		#endregion

		#region 返回所有的处方编号
		public string[] m_mthGetAll()
		{
			string[] strArry=null;
			if((string)this.m_objViewer.DgChargeCheck.Tag=="dtFindCharge")
			{
				if(dtFindCharge.Rows.Count-1>0)
				{
					strArry=new string[dtFindCharge.Rows.Count-1];
					for(int i1=0;i1< dtFindCharge.Rows.Count-1;i1++)
					{
						strArry[i1]=dtFindCharge.Rows[i1]["处方号"].ToString();
					}
				}
			}
			else
			{
				if(dtChargeCheck.Rows.Count-1>0)
				{
					strArry=new string[dtChargeCheck.Rows.Count-1];
					for(int i1=0;i1< dtChargeCheck.Rows.Count-1;i1++)
					{
						strArry[i1]=dtChargeCheck.Rows[i1]["处方号"].ToString();
					}
				}
			}
			return strArry;
		}
		#endregion

		#region 打印
		public void m_mthPrintReport()
		{
			com.digitalwave.iCare.gui.HIS.Print.chargeCheck cryregister = new com.digitalwave.iCare.gui.HIS.Print.chargeCheck();
			string strTotail="";
			if((string)this.m_objViewer.DgChargeCheck.Tag=="dtFindCharge")
			{
				if(dtFindCharge==null||dtFindCharge.Rows.Count==0)
				{
					MessageBox.Show("没有可打印数据！","Icare",MessageBoxButtons.OK,MessageBoxIcon.Stop);
					return;
				}
				strTotail=dtFindCharge.Rows[dtFindCharge.Rows.Count-1]["发票编号"].ToString();
				dtFindCharge.Rows.RemoveAt(dtFindCharge.Rows.Count-1);
				dtFindCharge.AcceptChanges();
				cryregister.SetDataSource(dtFindCharge);
				
			}
			else
			{
				if(dtChargeCheck==null||dtChargeCheck.Rows.Count==0)
				{
					MessageBox.Show("没有可打印数据！","Icare",MessageBoxButtons.OK,MessageBoxIcon.Stop);
					return;
				}
				strTotail=dtChargeCheck.Rows[dtChargeCheck.Rows.Count-1]["发票编号"].ToString();
				dtChargeCheck.Rows.RemoveAt(dtChargeCheck.Rows.Count-1);
				dtChargeCheck.AcceptChanges();
				cryregister.SetDataSource(dtChargeCheck);

			}
			((TextObject)cryregister.ReportDefinition.ReportObjects["printDate1"]).Text = DateTime.Now.ToShortDateString();
			((TextObject)cryregister.ReportDefinition.ReportObjects["startDate"]).Text = this.m_objViewer.m_datFirstdate.Value.ToShortDateString();
			((TextObject)cryregister.ReportDefinition.ReportObjects["Text5"]).Text = this.m_objViewer.m_datLastdate.Value.ToShortDateString();
			((TextObject)cryregister.ReportDefinition.ReportObjects["totail"]).Text = strTotail;
			FrmShowPrint ShowPrint=new FrmShowPrint();
			ShowPrint.cryReportViewer.ReportSource=cryregister;
			ShowPrint.ShowDialog();
			if((string)this.m_objViewer.DgChargeCheck.Tag=="dtFindCharge")
			{
				DataRow newRow=dtFindCharge.NewRow();
				newRow["诊疗卡号"]="总发票数";
				newRow["发票编号"]=strTotail;
				dtFindCharge.Rows.Add(newRow);
			}
			else
			{
				DataRow newRow=dtChargeCheck.NewRow();
				newRow["诊疗卡号"]="总发票数";
				newRow["发票编号"]=strTotail;
				dtChargeCheck.Rows.Add(newRow);
			}
		}

		#endregion
	}
}
