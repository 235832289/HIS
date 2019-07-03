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
	class clsCtl_DailyDebtReport : com.digitalwave.GUI_Base.clsController_Base
	{
		System.String strHospitalName = "��ɽ�еڶ�����ҽԺסԺ����һ����";
		System.Data.DataTable dtbReportConfig;
		string reportid = "0003";
		com.digitalwave.iCare.gui.HIS.clsDcl_StatQuery objSvc;
		com.digitalwave.iCare.gui.HIS.frmDailyDebtReport m_objViewer;
		public int RowNum = 0;
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmDailyDebtReport)frmMDI_Child_Base_in;
		}
		public clsCtl_DailyDebtReport()
		{
			objSvc = new clsDcl_StatQuery();
		}
		#region ������Ҷ�Ӧ�Ĳ���
		/// <summary>
		/// ������Ҷ�Ӧ�Ĳ���
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
		/// <summary>
		/// ��������Ƿ��һ����
		/// </summary>
		public void m_mthShowInHospitalDebtLog()
		{
		}
		#region Ԥ������ÿ���嵥
		public void PatientDailyDebtpreview()
		{
			this.RowNum = 0;
			if(this.m_objViewer.PatientDailyDebt.PrinterSettings.PrinterName == null||this.m_objViewer.PatientDailyDebt.PrinterSettings.PrinterName == "<��Ĭ�ϴ�ӡ��>")
			{
				MessageBox.Show(this.m_objViewer,"��ȷ�ϴ�ӡ����װ��ȷ","����");
				return;
			}
			try
			{
				this.m_objViewer.printPreviewDialog1.ShowDialog();
			}
			catch
			{
				MessageBox.Show(this.m_objViewer,"��ȷ�ϴ�ӡ��������ȷ","����");
				return;
			}
			this.m_objViewer.m_cmdPrint.Enabled = true;
		}
		#endregion
		#region Ԥ��סԺ����һ����
		public void rptChargeViewPreview()
		{
			this.m_objViewer.printPreviewDialog.Document = this.m_objViewer.rptChargeView;
			if(this.m_objViewer.rptChargeView.PrinterSettings.PrinterName=="<��Ĭ�ϴ�ӡ��>")
			{
				MessageBox.Show(this.m_objViewer,"��ȷ�ϴ�ӡ����װ��ȷ","����");
				return;
			}
			try
			{
				this.m_objViewer.printPreviewDialog.ShowDialog();
			}
			catch
			{
				MessageBox.Show(this.m_objViewer,"��ȷ�ϴ�ӡ��������ȷ","����");
				return;
			}
			this.m_objViewer.m_cmdPrint.Enabled = true;
		}
		#endregion
		#region ����ÿ���嵥
		public void PrintPage(System.Drawing.Printing.PrintPageEventArgs e)
		{
			long ret = objSvc.m_lngGetDailyDebtConfig(reportid,out this.dtbReportConfig);
			if(ret<0||dtbReportConfig.Rows.Count<1)
			{
				MessageBox.Show("��ȡ��������ʱ����");
				return;
			}
			this.strHospitalName = dtbReportConfig.Rows[0]["RPTNAME_CHR"].ToString();
			DataTable dtbResult = null;
			long lngRes=0;
			if(this.m_objViewer.m_txtAREAID_CHR.Tag==null)
			{
				lngRes = objSvc.m_lngGetPatientInfoForDailyCharge(this.m_objViewer.m_dtpStatTime.Value,out dtbResult);//��ѯ��������
			}
			else
			{
				lngRes = objSvc.m_lngGetPatientInfoForDailyCharge(this.m_objViewer.m_dtpStatTime.Value,(string)this.m_objViewer.m_txtAREAID_CHR.Tag,out dtbResult);//��ѯ��������
			}
			if(lngRes>0&&dtbResult.Rows.Count>0)
			{
				if(this.DrawingPatientDailyDebt(e.Graphics,dtbResult,out RowNum))
				{
					e.HasMorePages = true;
				}
				else
				{
					e.HasMorePages = false;
				}
			}


		}
		#endregion
		#region
		private bool DrawingPatientDailyDebt(System.Drawing.Graphics g,DataTable dtbResult,out int rownum)
		{
			int k=0;
			rownum = RowNum;
			System.Drawing.PointF DrawPoint = new System.Drawing.PointF(0.0f,0.0f);
			float leftMargin = 50.0f;
			System.Drawing.Font font = new System.Drawing.Font("����",10.5f,System.Drawing.FontStyle.Bold);
			System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
			DrawPoint.X = 100.0f;
			DrawPoint.Y = 100.0f;
			for(int i =rownum;i<rownum+4;i++)
			{
				if(i>=dtbResult.Rows.Count)
				{
					return false;
				}
				//
				g.DrawString(strHospitalName,font,brush,DrawPoint);
				font = new System.Drawing.Font("����",10.5f);
				DrawPoint.X = leftMargin;
				DrawPoint.Y = g.MeasureString("��ɽ�еڶ�����ҽԺסԺ����һ���嵥",font).Height+DrawPoint.Y+10.0f;
				g.DrawString("סԺ��",font,brush,DrawPoint);
				DrawPoint.X = DrawPoint.X + g.MeasureString("סԺ��",font).Width+20.0f;
				DrawPoint.Y = DrawPoint.Y;
				g.DrawString(dtbResult.Rows[i]["inpatientid_chr"].ToString(),font,brush,DrawPoint);
				DrawPoint.X = DrawPoint.X + g.MeasureString(dtbResult.Rows[i]["inpatientid_chr"].ToString(),font).Width+20.0f;
				DrawPoint.Y = DrawPoint.Y;
				g.DrawString("����",font,brush,DrawPoint);
				DrawPoint.X = DrawPoint.X + g.MeasureString("����",font).Width+20.0f;
				DrawPoint.Y = DrawPoint.Y;
				g.DrawString(dtbResult.Rows[i]["lastname_vchr"].ToString(),font,brush,DrawPoint);
				DrawPoint.X = leftMargin;
				DrawPoint.Y = DrawPoint.Y+g.MeasureString(dtbResult.Rows[i]["lastname_vchr"].ToString(),font).Height;
				g.DrawString("����",font,brush,DrawPoint);
				DrawPoint.X = DrawPoint.X + g.MeasureString("����",font).Width+20.0f;
				DrawPoint.Y = DrawPoint.Y;
				g.DrawString(this.m_objViewer.m_txtAREAID_CHR.Text.ToString(),font,brush,DrawPoint);
				DrawPoint.X = DrawPoint.X + g.MeasureString(this.m_objViewer.m_txtAREAID_CHR.Text.ToString(),font).Width+20.0f;
				DrawPoint.Y = DrawPoint.Y;
				g.DrawString("����",font,brush,DrawPoint);
				DrawPoint.X = DrawPoint.X + g.MeasureString("����",font).Width+20.0f;
				DrawPoint.Y = DrawPoint.Y;
				g.DrawString(dtbResult.Rows[i]["bedno"].ToString(),font,brush,DrawPoint);
				DrawPoint.X = DrawPoint.X + g.MeasureString(dtbResult.Rows[i]["bedno"].ToString(),font).Width+20.0f;
				DrawPoint.Y = DrawPoint.Y;
				g.DrawString("�嵥����",font,brush,DrawPoint);
				DrawPoint.X = DrawPoint.X + g.MeasureString("�嵥����",font).Width+20.0f;
				DrawPoint.Y = DrawPoint.Y;
				g.DrawString(this.m_objViewer.m_dtpStatTime.Value.ToShortDateString(),font,brush,DrawPoint);
				//����
				float length = 500.0f;
				DrawPoint.Y = DrawPoint.Y+g.MeasureString(this.m_objViewer.m_dtpStatTime.Value.ToShortDateString(),font).Height+5.0f;
				System.Drawing.Pen pen = new System.Drawing.Pen(brush,1);
				g.DrawLine(pen,new System.Drawing.PointF(leftMargin,DrawPoint.Y),new System.Drawing.PointF(length,DrawPoint.Y));
				//�����շ���Ŀ
				float DailyCharge = 0;//���ڵ���ϼ�
				DataTable dtbDetail = null;
				long lngRes = objSvc.m_lngGetDailyChargeInfo(this.dtbReportConfig.Rows[0]["RPTID_CHR"].ToString(),dtbResult.Rows[i]["registerid_chr"].ToString().Trim(),this.m_objViewer.m_dtpStatTime.Value,out dtbDetail);
				if(lngRes>0&&dtbDetail.Rows.Count>0)
				{
					DrawPoint.X = leftMargin;
					DrawPoint.Y = DrawPoint.Y+5.0f;
					System.Drawing.SizeF size = new System.Drawing.SizeF(70.0f,20.0f);//���С
					System.Drawing.RectangleF[] rectangle = new System.Drawing.RectangleF[dtbDetail.Rows.Count*2];//����Ŀ
					System.Drawing.PointF textPointF = DrawPoint;
					for(int j = 0;j<rectangle.Length;j=j+6)
					{
						DrawPoint.X = leftMargin;
						textPointF.X = DrawPoint.X+1.0f;
						textPointF.Y = DrawPoint.Y+1.5f;
						rectangle[j] = new System.Drawing.RectangleF(DrawPoint,size);
						g.DrawString(dtbDetail.Rows[j/2]["typename_vchr"].ToString(),font,brush,textPointF);//��Ӿ��������
						DrawPoint.X = DrawPoint.X+size.Width;
						textPointF.X = DrawPoint.X+1.0f;
						if((j+1)<rectangle.Length)
						{
							rectangle[j+1] = new System.Drawing.RectangleF(DrawPoint,size);
							if(dtbDetail.Rows[j/2]["money"]!=System.DBNull.Value)
							{
								g.DrawString(dtbDetail.Rows[j/2]["money"].ToString(),font,brush,textPointF);//��Ӿ��������
								DailyCharge = DailyCharge+Convert.ToSingle(dtbDetail.Rows[j/2]["money"].ToString());
							}
							DrawPoint.X = DrawPoint.X+size.Width;
							textPointF.X = DrawPoint.X+1.0f;
						}
						if((j+2)<rectangle.Length)
						{
							rectangle[j+2] = new System.Drawing.RectangleF(DrawPoint,size);
							g.DrawString(dtbDetail.Rows[(j+2)/2]["typename_vchr"].ToString(),font,brush,textPointF);//��Ӿ��������
							DrawPoint.X = DrawPoint.X+size.Width;
							textPointF.X = DrawPoint.X+1.0f;
						}
						if((j+3)<rectangle.Length)
						{
							rectangle[j+3] = new System.Drawing.RectangleF(DrawPoint,size);
							if(dtbDetail.Rows[(j+2)/2]["money"]!=System.DBNull.Value)
							{
								g.DrawString(dtbDetail.Rows[(j+2)/2]["money"].ToString(),font,brush,textPointF);//��Ӿ��������
								DailyCharge = DailyCharge+Convert.ToSingle(dtbDetail.Rows[(j+2)/2]["money"].ToString());
							}
							DrawPoint.X = DrawPoint.X+size.Width;
							textPointF.X = DrawPoint.X+1.0f;
						}
						if((j+4)<rectangle.Length)
						{
							rectangle[j+4] = new System.Drawing.RectangleF(DrawPoint,size);
							g.DrawString(dtbDetail.Rows[(j+4)/2]["typename_vchr"].ToString(),font,brush,textPointF);//��Ӿ��������
							DrawPoint.X = DrawPoint.X+size.Width;
							textPointF.X = DrawPoint.X+1.0f;
						}
						if((j+5)<rectangle.Length)
						{
							rectangle[j+5] = new System.Drawing.RectangleF(DrawPoint,size);
							if(dtbDetail.Rows[(j+4)/2]["money"]!=System.DBNull.Value)
							{
								g.DrawString(dtbDetail.Rows[(j+4)/2]["money"].ToString(),font,brush,textPointF);//��Ӿ��������
								DailyCharge = DailyCharge+Convert.ToSingle(dtbDetail.Rows[(j+4)/2]["money"].ToString());
							}
							DrawPoint.X = DrawPoint.X+size.Width;
							textPointF.X = DrawPoint.X+1.0f;
						}
						DrawPoint.Y = DrawPoint.Y+size.Height;
					}
					g.DrawRectangles(pen,rectangle);
				}
				g.DrawLine(pen,new System.Drawing.PointF(leftMargin,DrawPoint.Y+7.0f),new System.Drawing.PointF(length,DrawPoint.Y+6.0f));
				DrawPoint.X = leftMargin;
				DrawPoint.Y = DrawPoint.Y+15.0f;
				g.DrawString("����ϼ�",font,brush,DrawPoint);
				DrawPoint.X = DrawPoint.X+g.MeasureString("����ϼ�",font).Width+5.0f;
				DrawPoint.Y = DrawPoint.Y;
				g.DrawString(DailyCharge.ToString(),font,brush,DrawPoint);
				DrawPoint.X = DrawPoint.X+g.MeasureString(DailyCharge.ToString(),font).Width+5.0f;
				DrawPoint.Y = DrawPoint.Y;
				g.DrawString("Ԥ����",font,brush,DrawPoint);
				DrawPoint.X = DrawPoint.X+g.MeasureString("Ԥ����",font).Width+5.0f;
				DrawPoint.Y = DrawPoint.Y;
				g.DrawString(dtbResult.Rows[i]["money"].ToString(),font,brush,DrawPoint);
				DrawPoint.X = leftMargin;
				DrawPoint.Y = DrawPoint.Y+g.MeasureString("money",font).Height;
				g.DrawString("סԺ���úϼ�",font,brush,DrawPoint);
				DrawPoint.X = DrawPoint.X+g.MeasureString("סԺ���úϼ�",font).Width+5.0f;
				DrawPoint.Y = DrawPoint.Y;
				g.DrawString(dtbResult.Rows[i]["totalcharge"].ToString(),font,brush,DrawPoint);
				DrawPoint.X = DrawPoint.X+g.MeasureString(dtbResult.Rows[i]["totalcharge"].ToString(),font).Width+5.0f;
				DrawPoint.Y = DrawPoint.Y;
				g.DrawString("��ӡʱ��",font,brush,DrawPoint);
				DrawPoint.X = DrawPoint.X+g.MeasureString("��ӡʱ��",font).Width+5.0f;
				DrawPoint.Y = DrawPoint.Y;
				g.DrawString(this.m_objViewer.m_dtpStatTime.Value.ToString(),font,brush,DrawPoint);
				DrawPoint.X = 100.0f;
				DrawPoint.Y = DrawPoint.Y+30.0f;
				font = new System.Drawing.Font("����",10.5f,System.Drawing.FontStyle.Bold);
				k = i+1;
			}
			rownum = k;
			return true;
		}
		#endregion
		#region סԺ����һ����
		public void PrintvChargeView(Object Sender,System.Drawing.Printing.PrintPageEventArgs e)
		{
			long ret = objSvc.m_lngGetDailyDebtConfig(reportid,out this.dtbReportConfig);
			if(ret<0||dtbReportConfig.Rows.Count<1)
			{
				MessageBox.Show("��ȡ��������ʱ����");
			}
			System.Drawing.PointF DrawPoint = new System.Drawing.PointF(0.0f,0.0f);
			float leftMargin = 10.0f;
			System.Drawing.Font font = new System.Drawing.Font("����",15f,System.Drawing.FontStyle.Bold);
			System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
			DrawPoint.X = 230.0f;
			DrawPoint.Y = 100.0f;
			e.Graphics.DrawString(this.strHospitalName,font,brush,DrawPoint);
			DrawPoint.X = 20.0f;
			DrawPoint.Y = 130.0f;
			font = new System.Drawing.Font("����",9.0f);
			e.Graphics.DrawString("ͳ��ʱ��:",font,brush,DrawPoint);
			DrawPoint.X+=e.Graphics.MeasureString("ͳ��ʱ��:",font).Width+5.0f;
			e.Graphics.DrawString(this.m_objViewer.m_dtpStatTime.Value.ToShortDateString(),font,brush,DrawPoint);
			DrawPoint.X+=e.Graphics.MeasureString(this.m_objViewer.m_dtpStatTime.Value.ToShortDateString(),font).Width+400.0f;
			e.Graphics.DrawString("��ӡʱ��:"+System.DateTime.Now.ToShortDateString(),font,brush,DrawPoint);
			#region ������Ϣ
			DataTable dtbResult = null;
			int RowNum = 0;
			long lngRes = objSvc.m_lngGetPatientInfoForDailyCharge(this.m_objViewer.m_dtpStatTime.Value,(string)this.m_objViewer.m_txtAREAID_CHR.Tag,out dtbResult);
			if(lngRes>0&&dtbResult.Rows.Count>0)
			{
				for(int i = 0;i<dtbResult.Rows.Count;i++)
				{
					if(dtbResult.Rows[i]["bedno"].ToString().Trim()==this.m_objViewer.m_cboBedNo.Text.Trim())
					{
						RowNum = i;
					}
				}
			}
			else
			{
				return;
			}
			#endregion
			DrawPoint.X = leftMargin;
			DrawPoint.Y = DrawPoint.Y+e.Graphics.MeasureString("��ӡʱ��",font).Height;
			e.Graphics.DrawString("��λ",font,brush,DrawPoint);
			e.Graphics.DrawString(dtbResult.Rows[RowNum]["bedno"].ToString(),font,brush,new System.Drawing.PointF(DrawPoint.X,DrawPoint.Y+40.0f));
			DrawPoint.X = DrawPoint.X+e.Graphics.MeasureString("��λ",font).Width/2;
			DrawPoint.Y = DrawPoint.Y + e.Graphics.MeasureString("��λ",font).Height;
			e.Graphics.DrawString("סԺ��",font,brush,DrawPoint);
			e.Graphics.DrawString(dtbResult.Rows[RowNum]["inpatientid_chr"].ToString(),font,brush,new System.Drawing.PointF(DrawPoint.X,DrawPoint.Y+40.0f));
			DrawPoint.X = DrawPoint.X+e.Graphics.MeasureString("סԺ��",font).Width+5.0f;
			DrawPoint.Y = DrawPoint.Y-e.Graphics.MeasureString("סԺ��",font).Height/2;
			e.Graphics.DrawString("����",font,brush,DrawPoint);
			e.Graphics.DrawString(dtbResult.Rows[RowNum]["lastname_vchr"].ToString(),font,brush,new System.Drawing.PointF(DrawPoint.X,DrawPoint.Y+30.0f));
			DrawPoint.X = DrawPoint.X+e.Graphics.MeasureString("����",font).Width+10.0f;
			DrawPoint.Y = DrawPoint.Y-e.Graphics.MeasureString("����",font).Height/2;
			System.Drawing.PointF totalcharge = DrawPoint;
			string Registerid = "";
			e.Graphics.DrawString("������ú�\n    ��",font,brush,DrawPoint);
			DrawPoint.X = DrawPoint.X+e.Graphics.MeasureString("������ú�\n    ��",font).Width+10.0f;
			DrawPoint.Y = DrawPoint.Y;//-e.Graphics.MeasureString("����",font).Height/2;
			#region ��ȡ����סԺ�Ǽ�id
			if(this.m_objViewer.m_cboBedNo.SelectedIndex>=0)
			{
				for(int i = 0;i<this.m_objViewer.m_cboBedNo.Items.Count;i++)
				{
					if(this.m_objViewer.m_cboBedNo.Text.ToString().Trim() == ((DataTable)this.m_objViewer.m_cboBedNo.Tag).Rows[i]["bedno"].ToString().Trim())
					{
						Registerid = ((DataTable)this.m_objViewer.m_cboBedNo.Tag).Rows[i]["registerid_chr"].ToString().Trim();
					}
				}
			}
			#endregion
			DataTable dtbResult1 = new DataTable();
			lngRes = objSvc.m_lngGetDailyChargeInfo("0003",Registerid,this.m_objViewer.m_dtpStatTime.Value,out dtbResult1);
			string strResult;
			double money = 0;
			if(lngRes>0&&dtbResult1.Rows.Count>0)
			{
				for(int i = 0;i<dtbResult1.Rows.Count;i++)
				{
					strResult = this.DrawFormatstring(dtbResult1.Rows[i]["TYPENAME_VCHR"].ToString());
					e.Graphics.DrawString(strResult,font,brush,DrawPoint);
					e.Graphics.DrawString(dtbResult1.Rows[i]["money"].ToString(),font,brush,new System.Drawing.PointF(DrawPoint.X,DrawPoint.Y+40.0f));
					if(dtbResult1.Rows[i]["money"]!=System.DBNull.Value)
					{
						money += Convert.ToDouble(dtbResult1.Rows[i]["money"].ToString()); 
					}
					DrawPoint.X = DrawPoint.X+e.Graphics.MeasureString(strResult,font).Width;
				}
			}
			e.Graphics.DrawString(money.ToString(),font,brush,new System.Drawing.PointF(totalcharge.X+15.0f,totalcharge.Y+40.0f));
			DrawPoint.Y=e.Graphics.MeasureString("��",font).Height/2+DrawPoint.Y;
			e.Graphics.DrawString("���÷���",font,brush,DrawPoint);
			e.Graphics.DrawString(dtbResult.Rows[RowNum]["totalcharge"].ToString(),font,brush,new System.Drawing.PointF(DrawPoint.X+5.0f,DrawPoint.Y+40.0f));
			DrawPoint.X = DrawPoint.X+e.Graphics.MeasureString("���÷���",font).Width;
			DrawPoint.Y = DrawPoint.Y;
			e.Graphics.DrawString("Ѻ�����",font,brush,DrawPoint);
			double remaining = 0;
			if(dtbResult.Rows[RowNum]["Money"]!=System.DBNull.Value&&dtbResult.Rows[RowNum]["totalcharge"]!=System.DBNull.Value)
			{
				remaining = Convert.ToDouble(dtbResult.Rows[RowNum]["Money"].ToString())-Convert.ToDouble(dtbResult.Rows[RowNum]["totalcharge"].ToString());
			}
			e.Graphics.DrawString(remaining.ToString(),font,brush,new System.Drawing.PointF(DrawPoint.X,DrawPoint.Y+40.0f));
			DrawPoint.X = DrawPoint.X+e.Graphics.MeasureString("Ѻ�����",font).Width;
			DrawPoint.Y = DrawPoint.Y;
			System.Drawing.Pen pen = new System.Drawing.Pen(brush,1.0f);
			DrawPoint.X = leftMargin;
			DrawPoint.Y = DrawPoint.Y+e.Graphics.MeasureString("Ѻ�����",font).Height;
			e.Graphics.DrawLine(pen,new System.Drawing.PointF(DrawPoint.X,DrawPoint.Y+10.0f),new System.Drawing.PointF(800.0f,DrawPoint.Y+10.0f));
		}
		#endregion
		#region ��䲡��combox
		public void Addm_cboBed()
		{
			this.m_objViewer.m_cboBedNo.Items.Clear();
			System.Data.DataTable dtbResult = null;
			long lngRes = objSvc.m_lngGetPatientInfoForDailyCharge(this.m_objViewer.m_dtpStatTime.Value,(string)this.m_objViewer.m_txtAREAID_CHR.Tag,out dtbResult);//��ѯ��������
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
		#region ���ڸ�ʽ�������ַ���
		private string DrawFormatstring(string DrawString)
		{
			DrawString = DrawString.Trim();
			string strResult = "";
			//int length = 0;
			float harflenth=0;
			int uplength = 0;
			int spaceNum;
			string string1="";
			string string2="";
			harflenth = (float)DrawString.Length/2;
			uplength = DrawString.Length/2;
			if(harflenth>uplength)
			{
				uplength = uplength+1;
				string1 = DrawString.Substring(0,uplength);
				string2 = DrawString.Substring(uplength,DrawString.Length-uplength);
				spaceNum = (string1.Length-string2.Length);
				strResult = string1+"\n";
				for(int i= 0;i<spaceNum;i++)
				{
					strResult+=" ";
				}
				strResult+=string2;
			}
			else
			{
				uplength = uplength;
				string1 = DrawString.Substring(0,uplength);
				string2 = DrawString.Substring(uplength,DrawString.Length-uplength);
				spaceNum = (string1.Length-string2.Length);
				strResult = string1+"\n";
				for(int i= 0;i<spaceNum;i++)
				{
					strResult+=" ";
				}
				strResult+=string2;
			}
			return strResult;
		}
		#endregion
		#region
		public void Print()
		{
			if(this.m_objViewer.printDialog.ShowDialog()==DialogResult.OK)
			{
				try
				{
					this.m_objViewer.printDialog.Document.Print();
				}
				catch(System.Exception	ex)
				{
					MessageBox.Show(this.m_objViewer,ex.ToString());
				}
			}
		}
		#endregion
	}
		
}