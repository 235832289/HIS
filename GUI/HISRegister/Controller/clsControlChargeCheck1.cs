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
	/// clsControlChargeCheck1 ��ժҪ˵����
	/// </summary>
	public class clsControlChargeCheck1:com.digitalwave.GUI_Base.clsController_Base
	{
		public clsControlChargeCheck1()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#region ���ô������
		public com.digitalwave.iCare.gui.HIS.frmChargeCheck1 m_objViewer;
		/// <summary>
		/// ���ô������
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmChargeCheck1)frmMDI_Child_Base_in;
		}
		#endregion
		#region ����
		clsDomainControl_Register Domain=new clsDomainControl_Register();
		DataTable dtChargeCheck=new DataTable();
		private System.Data.DataView m_dvRegister = new System.Data.DataView();
		/// <summary>
		/// ������������ķ�Ʊ��Ϣ
		/// </summary>
		DataTable dtFindCharge=null;
		#endregion
		public void m_frmLoad()
		{

			string strDateStart=this.m_objViewer.m_datFirstdate.Value.ToShortDateString();
			string strDateEnd=this.m_objViewer.m_datLastdate.Value.ToShortDateString();
			Domain.m_lngGetChargeByDate1(strDateStart,strDateEnd, out dtChargeCheck);
			#region �ı�������
			dtChargeCheck.Columns[0].ColumnName="���ƿ���";
			dtChargeCheck.Columns[1].ColumnName="��Ʊ���";
			dtChargeCheck.Columns[2].ColumnName="������";
			dtChargeCheck.Columns[3].ColumnName="�������";
			dtChargeCheck.Columns[4].ColumnName="��������";
			dtChargeCheck.Columns[5].ColumnName="�Ա�";
			dtChargeCheck.Columns[6].ColumnName="֧������";
			dtChargeCheck.Columns[7].ColumnName="��Ʊ����";
			dtChargeCheck.Columns[8].ColumnName="��������";
			dtChargeCheck.Columns[9].ColumnName="ҽ������";
			dtChargeCheck.Columns[10].ColumnName="�շ�Ա";
			dtChargeCheck.Columns[11].ColumnName="���ʽ��";
			dtChargeCheck.Columns[12].ColumnName="�Ը����";
			dtChargeCheck.Columns[13].ColumnName="�ϼƽ��";
			dtChargeCheck.Columns[14].ColumnName="��������";
			#endregion
			if(dtChargeCheck.Rows.Count>0)
			{
				DataRow newRow=dtChargeCheck.NewRow();
				newRow["���ƿ���"]="�ܷ�Ʊ��";
				newRow["��Ʊ���"]=dtChargeCheck.Rows.Count.ToString();
				dtChargeCheck.Rows.Add(newRow);
			}
			this.m_dvRegister = dtChargeCheck.DefaultView;
			this.m_objViewer.DgChargeCheck.SetDataBinding(m_dvRegister,null);
			this.m_objViewer.DgChargeCheck.Tag="dtChargeCheck";
			this.m_objViewer.DgChargeCheck.m_SetDgrStyle();
			this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["���ƿ���"].Width = 80;
			this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["������"].Width = 100;
			this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["�Ա�"].Width = 40;
			this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["��������"].Width = 120;
			this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["�շ�Ա"].Width = 60;
			this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["��Ʊ���"].Width = 80;
			this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["��������"].Width = 0;
		}

		#region ����
		DataView  m_dvRegisterfind=new DataView();
		public void m_mthFindData()
		{
			if(this.m_objViewer.PatienType.Text.Trim()=="ȫ��")
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
				if(dtChargeCheck.Rows[i1]["��������"].ToString().IndexOf(this.m_objViewer.PatienType.Text.Trim(),0)==0)
				{
					DataRow AddRow=dtFindCharge.NewRow();
					AddRow["���ƿ���"]=dtChargeCheck.Rows[i1]["���ƿ���"];
					AddRow["��Ʊ���"]=dtChargeCheck.Rows[i1]["��Ʊ���"];
					AddRow["������"]=dtChargeCheck.Rows[i1]["������"];
					AddRow["�������"]=dtChargeCheck.Rows[i1]["�������"];
					AddRow["��������"]=dtChargeCheck.Rows[i1]["��������"];
					AddRow["�Ա�"]=dtChargeCheck.Rows[i1]["�Ա�"];
					AddRow["֧������"]=dtChargeCheck.Rows[i1]["֧������"];
					AddRow["��Ʊ����"]=dtChargeCheck.Rows[i1]["��Ʊ����"];
					AddRow["��������"]=dtChargeCheck.Rows[i1]["��������"];
					AddRow["ҽ������"]=dtChargeCheck.Rows[i1]["ҽ������"];
					AddRow["�շ�Ա"]=dtChargeCheck.Rows[i1]["�շ�Ա"];
					AddRow["���ʽ��"]=dtChargeCheck.Rows[i1]["���ʽ��"];
					AddRow["�Ը����"]=dtChargeCheck.Rows[i1]["�Ը����"];
					AddRow["�ϼƽ��"]=dtChargeCheck.Rows[i1]["�ϼƽ��"];
					AddRow["��������"]=dtChargeCheck.Rows[i1]["��������"];
					dtFindCharge.Rows.Add(AddRow);
				}
			}
			if(dtFindCharge.Rows.Count>0)
			{
				DataRow newRow=dtFindCharge.NewRow();
				newRow["���ƿ���"]="�ܷ�Ʊ��";
				newRow["��Ʊ���"]=dtFindCharge.Rows.Count.ToString();
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

		#region �������еĴ������
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
						strArry[i1]=dtFindCharge.Rows[i1]["������"].ToString();
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
						strArry[i1]=dtChargeCheck.Rows[i1]["������"].ToString();
					}
				}
			}
			return strArry;
		}
		#endregion

		#region ��ӡ
		public void m_mthPrintReport()
		{
			com.digitalwave.iCare.gui.HIS.Print.chargeCheck cryregister = new com.digitalwave.iCare.gui.HIS.Print.chargeCheck();
			string strTotail="";
			if((string)this.m_objViewer.DgChargeCheck.Tag=="dtFindCharge")
			{
				if(dtFindCharge==null||dtFindCharge.Rows.Count==0)
				{
					MessageBox.Show("û�пɴ�ӡ���ݣ�","Icare",MessageBoxButtons.OK,MessageBoxIcon.Stop);
					return;
				}
				strTotail=dtFindCharge.Rows[dtFindCharge.Rows.Count-1]["��Ʊ���"].ToString();
				dtFindCharge.Rows.RemoveAt(dtFindCharge.Rows.Count-1);
				dtFindCharge.AcceptChanges();
				cryregister.SetDataSource(dtFindCharge);
				
			}
			else
			{
				if(dtChargeCheck==null||dtChargeCheck.Rows.Count==0)
				{
					MessageBox.Show("û�пɴ�ӡ���ݣ�","Icare",MessageBoxButtons.OK,MessageBoxIcon.Stop);
					return;
				}
				strTotail=dtChargeCheck.Rows[dtChargeCheck.Rows.Count-1]["��Ʊ���"].ToString();
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
				newRow["���ƿ���"]="�ܷ�Ʊ��";
				newRow["��Ʊ���"]=strTotail;
				dtFindCharge.Rows.Add(newRow);
			}
			else
			{
				DataRow newRow=dtChargeCheck.NewRow();
				newRow["���ƿ���"]="�ܷ�Ʊ��";
				newRow["��Ʊ���"]=strTotail;
				dtChargeCheck.Rows.Add(newRow);
			}
		}

		#endregion
	}
}
