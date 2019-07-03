using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;
using System.Xml;
using com.digitalwave.GLS_WS.ApplyReportServer;


namespace com.digitalwave.GLS_WS.Logic
{
	/// <summary>
	/// ��ӡ��Ӧ�ļ�����뵥,���д�ӡ
	/// </summary>
	public class FormPrinter
	{
		/*
			PaperName = Letter,Width = 850,Height = 1100
			PaperName = Tabloid,Width = 1100,Height = 1700
			PaperName = Legal,Width = 850,Height = 1400
			PaperName = A3,Width = 1169,Height = 1654
			PaperName = A4,Width = 827,Height = 1169
			PaperName = A5,Width = 583,Height = 827
			PaperName = B4 (JIS),Width = 1012,Height = 1433
			PaperName = B5 (JIS),Width = 717,Height = 1012
			PaperName = Japanese Postcard,Width = 394,Height = 583		
		*/		 
		
		public int RowHeight	 = 30;
		public int TopMargin     = 15;       
		public int PageWidth	 = 553; 
		public int TextFontSize  = 12;
		public int TitleFontSize = 18;
		
        public string TextFontName  = "����";
		public string TitleFontName = "����";
		public string HospitalName	= "����ҽԺ";
        public string HospitalAddress = "";
		
		private DataRow dr;
		private Point boxA,boxB;	//��������Ϻ���������
		private Point current = new Point(0,0);	
		

		public FormPrinter()
		{
            this.m_mthGetHospitalInfo();
		}
        
		public void PrintPreview(string applyID)
		{
            DataProcess dp = (DataProcess)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(DataProcess));
			DataTable ds = dp.SqlSelect("select * from AR_COMMON_APPLY where ApplyID = " + applyID);
			PrintPreview(ds);	
		}
		/// <summary>
		/// �ⲿ����
		/// </summary>
		/// <param name="applyID"></param>
		public void PrintPreviewInvoke(string applyID)
		{
            DataProcess dp = (DataProcess)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(DataProcess));
			DataTable ds = dp.SqlSelect("select * from AR_COMMON_APPLY where ApplyID = " + applyID);
			this.dr = ds.Rows[0];
		}
		
		

		public void PrintPreview(DataTable dsApply)
		{
			this.dr = dsApply.Rows[0];
            PrintDocument printDoc = new PrintDocument();
			PrintPreviewDialog previewDlg = new PrintPreviewDialog();

			printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
			(previewDlg as Form).WindowState = FormWindowState.Maximized;
			previewDlg.Document = printDoc;	
			
			try
			{	
				//ȡ����ӡʱ�������쳣
				previewDlg.ShowDialog();
			}
			finally
			{
			
			}
		}
		
		private int intRows = 0;//����table������
		private DataTable dsPrintData;
		public void SelectTypePrintPreview(DataTable dsApply)
		{
			if(dsApply == null)
				return;
			PrintDocument printDoc = new PrintDocument(); 
			PrintPreviewDialog previewDlg = new PrintPreviewDialog(); 

			intRows = dsApply.Rows.Count;
			dsPrintData = dsApply;

			printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
			(previewDlg as Form).WindowState = FormWindowState.Maximized;
			previewDlg.Document = printDoc;	
			try
			{	
				//ȡ����ӡʱ�������쳣
				previewDlg.ShowDialog();
			}
			finally
			{
			
			}
		}

        #region ��ȡҽԺ��Ϣ
        /// <summary>
        /// ��ȡҽԺ��Ϣ
        /// </summary>
        public void m_mthGetHospitalInfo()
        {
            string sql = "select * from t_bse_hospitalinfo where rownum = 1";
            DataTable ds = new DataTable();
            try
            {
                DataProcess dp = (DataProcess)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(DataProcess));
                ds = dp.SqlSelect(sql);
            }
            catch { }

            if (ds.Rows.Count == 1)
            {
                HospitalName = ds.Rows[0]["HOSPITAL_NAME_CHR"].ToString();
                HospitalAddress = ds.Rows[0]["ADDRESS_VCHR"].ToString();
            }
        }
        #endregion

		public void Print(string applyID)
		{
            DataProcess dp = (DataProcess)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(DataProcess));
			DataTable ds = dp.SqlSelect("select * from AR_COMMON_APPLY where ApplyID = " + applyID);
			Print(ds);
		}


		/// <summary>
		/// ֱ�Ӵ�ӡ
		/// </summary>
		/// <param name="dsApply"></param>
		public void Print(DataTable dsApply)
		{
			this.dr = dsApply.Rows[0];
			PrintDocument printDoc = new PrintDocument();
			printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
			printDoc.Print();		
		}	

		/// <summary>
		/// ѡ��������ֱ�Ӵ�ӡ
		/// </summary>
		/// <param name="dsApply"></param>
		public void SelectTypePrint(DataTable dsApply)
		{
			if(dsApply == null)
				return;
			PrintDocument printDoc = new PrintDocument();

			intRows = dsApply.Rows.Count;
			dsPrintData = dsApply;

			printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
			printDoc.Print();		
		}

		
		/// <summary>
		/// ��ӡͨ�ü�����뵥
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private int tableRows = 0;
		public void printDoc_PrintPage(object sender, PrintPageEventArgs e)
		{			
			while(tableRows < intRows)
			{	
				this.dr = dsPrintData.Rows[tableRows];
				m_mthPrintDoc_PrintPage(e);	 
				tableRows ++;

				if(current.Y > 1000 && tableRows < intRows)
				{
					e.HasMorePages = true;
					return;
				}
			}
			if(tableRows == 0)
				m_mthPrintDoc_PrintPage(e);
			tableRows = 0;
		}

		private void m_mthPrintDoc_PrintPage(PrintPageEventArgs e)
		{
			Graphics g = e.Graphics; 
			string text = "";

			SolidBrush brush = new SolidBrush(Color.Black);
			Pen pen = new Pen(Color.Black,1);

			Font textFont    = new Font(this.TextFontName,this.TextFontSize);
			Font titleFont   = new Font(this.TitleFontName, this.TitleFontSize,FontStyle.Bold);
			
			float textWidth;
			int titleHeight = (int)(g.MeasureString("��",titleFont).Height);
			int textHeight  = (int)(g.MeasureString("��",textFont).Height);
			if (this.RowHeight < textHeight) this.RowHeight = textHeight + 10;		
			
			StringFormat toLeft, toRight, hCenter, vCenter;

			hCenter = new StringFormat();
			hCenter.Alignment = StringAlignment.Center;
			hCenter.LineAlignment = StringAlignment.Center;

			vCenter = new StringFormat();
			vCenter.LineAlignment = StringAlignment.Center;
            
			
			toLeft = new StringFormat();			
			toLeft.Alignment = StringAlignment.Center;

			toRight = new StringFormat();
			toRight.LineAlignment = StringAlignment.Far;
			toRight.Alignment = StringAlignment.Center;
			            
			//���ƿ���			
			this.current.X = (e.PageBounds.Width - this.PageWidth ) / 2;
			this.current.Y = this.TopMargin;
			g.DrawString("���ƿ��� " + dr["CardNo"].ToString(),textFont, brush, current);

			current.Y += this.RowHeight;
			//Title
			Rectangle hRect = new Rectangle(current.X, current.Y, this.PageWidth, this.RowHeight);
			g.DrawString(this.HospitalName, textFont, brush, hRect,hCenter);

			current.Y += this.RowHeight;			
			Rectangle tRect = new Rectangle(current.X,current.Y,this.PageWidth,titleHeight + 10);
			g.DrawString(dr["ApplyTitle"].ToString(),titleFont, brush,tRect,hCenter);	
	
			//Heading
			current.Y += tRect.Height;
			text = "Ԥ����";
			textWidth = g.MeasureString(text, textFont).Width;
			g.DrawString(text, textFont, brush,current);
			g.DrawString(dr["Deposit"].ToString(), textFont, brush, current.X + textWidth + 20,current.Y);
			g.DrawLine(pen,current.X + textWidth, current.Y + textHeight,current.X  + textWidth + 100, current.Y + textHeight);

			//���Ϸ��� 
			int w1 = (int)textWidth + 100;
			int x1 = e.PageBounds.Width  - (e.PageBounds.Width - this.PageWidth ) / 2 - w1;
			int y1 = current.Y;
			int h1 = this.RowHeight * 4;
			g.DrawRectangle(pen, x1 - 5, y1 - 5, w1 + 5, h1 + 10);		

			current.Y += this.RowHeight;
			g.DrawString("������", textFont, brush,current);
			g.DrawLine(pen,current.X + textWidth, current.Y + textHeight,current.X  + textWidth + 100, current.Y + textHeight);
			g.DrawString(dr["Balance"].ToString(), textFont, brush, current.X + textWidth + 20,current.Y);

			current.Y += this.RowHeight;
			g.DrawString("��������", textFont, brush,current);
			g.DrawLine(pen,current.X + textWidth * 4 / 3, current.Y + textHeight,current.X  + textWidth * 4 / 3 + 100, current.Y + textHeight);
			g.DrawString(((DateTime)dr["ApplyDate"]).ToString("yyyy-MM-dd"), textFont, brush, current.X + textWidth + 20,current.Y);

			g.DrawString("����", textFont, brush, x1, y1);
			g.DrawLine(pen, x1 + textWidth + 5, y1 + textHeight, x1 + textWidth + 95,y1 + textHeight);
			g.DrawString(dr["CheckNo"].ToString(), textFont, brush,x1 + textWidth + 10, y1);

			y1 += this.RowHeight;
			g.DrawString("�����", textFont, brush, x1, y1);
			g.DrawLine(pen, x1 + textWidth + 5, y1 + textHeight, x1 + textWidth + 95,y1 + textHeight);
			g.DrawString(dr["ClinicNo"].ToString(), textFont, brush,x1 + textWidth + 10, y1);

			y1 += this.RowHeight;
			g.DrawString("סԺ��", textFont, brush, x1, y1);
			g.DrawLine(pen, x1 + textWidth + 5, y1 + textHeight, x1 + textWidth + 95,y1 + textHeight);
			g.DrawString(dr["BIHNO"].ToString(), textFont, brush,x1 + textWidth + 10, y1);

			y1 += this.RowHeight;
			g.DrawString("���Ӻ�", textFont, brush, x1, y1);
			g.DrawLine(pen, x1 + textWidth + 5, y1 + textHeight, x1 + textWidth + 95,y1 + textHeight);
			g.DrawString(dr["ExtraNo"].ToString(), textFont, brush,x1 + textWidth + 10, y1);

			//��ʼ�����
			int cellWidth = this.PageWidth / 6;			
			Rectangle rectCell;
			current.Y += 3 * this.RowHeight;
			g.DrawRectangle(pen,current.X, current.Y, this.PageWidth,this.RowHeight);

			rectCell = new Rectangle(current.X, current.Y , cellWidth, this.RowHeight);
			g.DrawRectangle(pen, rectCell);
			g.DrawString("��    ��",textFont, brush,rectCell, hCenter);

			rectCell.X += cellWidth;
			g.DrawRectangle(pen, rectCell);
			g.DrawString(dr["Name"].ToString(),textFont, brush,rectCell, hCenter);

			rectCell.X += cellWidth;
			g.DrawRectangle(pen, rectCell);
			g.DrawString("��    ��",textFont, brush,rectCell, hCenter);

			rectCell.X += cellWidth;
			g.DrawRectangle(pen, rectCell);
			g.DrawString(dr["Sex"].ToString(),textFont, brush,rectCell, hCenter);

			rectCell.X += cellWidth;
			g.DrawRectangle(pen, rectCell);
			g.DrawString("��    ��",textFont, brush,rectCell, hCenter);

			rectCell.X += cellWidth;			
			g.DrawString(dr["Age"].ToString(),textFont, brush,rectCell, hCenter);

			//�ڶ��б��
			current.Y += this.RowHeight;
			g.DrawRectangle(pen,current.X, current.Y, this.PageWidth,this.RowHeight);
			rectCell = new Rectangle(current.X, current.Y , cellWidth, this.RowHeight);   
            
			rectCell = new Rectangle(current.X, current.Y , cellWidth, this.RowHeight);
			g.DrawRectangle(pen, rectCell);
			g.DrawString("��    ��",textFont, brush,rectCell, hCenter);

			rectCell.X += cellWidth;
			g.DrawRectangle(pen, rectCell);
			g.DrawString(dr["Department"].ToString(),textFont, brush,rectCell, hCenter);

			rectCell.X += cellWidth;
			g.DrawRectangle(pen, rectCell);
			g.DrawString("��    ��",textFont, brush,rectCell, hCenter);

			rectCell.X += cellWidth;
			g.DrawRectangle(pen, rectCell);
			g.DrawString(dr["Area"].ToString(),textFont, brush,rectCell, hCenter);

			rectCell.X += cellWidth;
			g.DrawRectangle(pen, rectCell);
			g.DrawString("��    ��",textFont, brush,rectCell, hCenter);

			rectCell.X += cellWidth;			
			g.DrawString(dr["BedNo"].ToString(),textFont, brush,rectCell, hCenter);	

			//�����б��
			current.Y += this.RowHeight;
			g.DrawRectangle(pen,current.X, current.Y, this.PageWidth,this.RowHeight);
			rectCell = new Rectangle(current.X, current.Y , cellWidth, this.RowHeight);   
			
			g.DrawRectangle(pen, rectCell);
			g.DrawString("��ϵ�绰",textFont, brush,rectCell, hCenter);		
			g.DrawString(dr["Tel"].ToString(), textFont, brush, rectCell.X + cellWidth + 10, rectCell.Y + 3);                      

			rectCell.X += 3 * cellWidth;
			g.DrawRectangle(pen, rectCell);
			Font AddressFont    = new Font("����",10);
			g.DrawString("��ͥסַ",textFont, brush,rectCell, hCenter);		
			g.DrawString(dr["Address"].ToString(), AddressFont, brush, rectCell.X + cellWidth, rectCell.Y + 3);    
            
			//�����У�����ժҪ
			current.Y += this.RowHeight;
			int boxHeight = 480; //����ժҪ�ĸ߶�
			g.DrawRectangle(pen,current.X, current.Y, this.PageWidth,boxHeight);
			rectCell = new Rectangle(current.X , current.Y , cellWidth, this.RowHeight);   
			g.DrawString("����ժҪ��", textFont, brush, rectCell, hCenter);

            #region ��ÿһ�ο�ʼ�����������ո�,��ɾ�����
            //{Text="�ֲ�ʷ\r\n��ʷ\r\n����\r\n����ʷ\r\n��fdffd\n��\r\n����\r\n���\r\n��\r\n��"}
            string strTextCut = dr["Diagnose"].ToString().Trim();//���
            string strText = dr["Summary"].ToString().Trim();//����ժҪ
            strText = strText.Replace("\r\n", "\t");
            char[] charArr = new char[] { '\t' };
            string[] str = strText.Split(charArr);
            string strResult = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != strTextCut)
                {
                    str[i] = "  " + str[i] + "\r\n";
                    strResult += str[i];
                }
            }
            strResult = strResult.Replace("\t", ""); ;
            #endregion 

			rectCell = new Rectangle(current.X + 3, current.Y + this.RowHeight, this.PageWidth - 6 ,boxHeight - this.RowHeight);
			StringFormat wrap = new StringFormat();
			wrap.FormatFlags = StringFormatFlags.FitBlackBox;
			g.DrawString(dr["Summary"].ToString(), textFont, brush,rectCell,wrap);

			//���
			current.Y += boxHeight;
			g.DrawRectangle(pen, current.X, current.Y , this.PageWidth, this.RowHeight);
			rectCell = new Rectangle(current.X, current.Y , cellWidth, this.RowHeight);   
			g.DrawString("��    �ϣ�", textFont, brush, rectCell,hCenter);
            
			rectCell.X += cellWidth + 10;
			rectCell.Y += 3;
			g.DrawString(dr["Diagnose"].ToString(), textFont, brush, rectCell.X,rectCell.Y);

			//���С����롱
			current.Y += this.RowHeight;
			g.DrawRectangle(pen, current.X, current.Y , this.PageWidth, this.RowHeight);
			text = "�����鲿λ���ͼ���֯��";
			int lngTextWidth = (int)g.MeasureString(text,textFont).Width;
			g.DrawString(text, textFont, brush, current.X + 3,current.Y + 3);
			g.DrawString(dr["DiagnosePart"].ToString(), textFont, brush, current.X + lngTextWidth + 6,current.Y + 3);

			current.Y += this.RowHeight;
			g.DrawRectangle(pen, current.X, current.Y , this.PageWidth, this.RowHeight);
			text = "������Ŀ�Ļ�����Ҫ��";			
			g.DrawString(text, textFont, brush, current.X + 3,current.Y + 3);
			g.DrawString(dr["DiagnoseAim"].ToString(), textFont, brush, current.X + lngTextWidth + 6,current.Y + 3);

			//ҽ��ǩ��������
			current.Y += this.RowHeight;
			text = "ҽ��ǩ����";
			textWidth = (int)g.MeasureString(text,textFont).Width;
			g.DrawRectangle(pen, current.X, current.Y , this.PageWidth, this.RowHeight);
			g.DrawString(text,textFont, brush, current.X + 3, current.Y + 3);
			g.DrawString(dr["DoctorName"].ToString() ,textFont, brush, current.X + 3 + textWidth, current.Y + 3);            

			g.DrawString("ҽ�����ţ�",textFont, brush, current.X + 2 * textWidth , current.Y + 3);
			g.DrawString(dr["DoctorNO"].ToString(),textFont, brush, current.X + 3 * textWidth , current.Y + 3);

			g.DrawString("���ڣ�",textFont, brush, current.X + 4 * textWidth , current.Y + 3);
			string strFinishDate = "";
			if(dr["FinishDate"] != DBNull.Value && ((DateTime)dr["FinishDate"]) != new DateTime(1900,1,1))
				strFinishDate = ((DateTime)dr["FinishDate"]).ToString("yyyy-MM-dd");
			g.DrawString(strFinishDate,textFont, brush, current.X + 5 + (int)(4.5 * textWidth) , current.Y + 3);

			//�շ���Ϣ
			current.Y += this.RowHeight;
			boxHeight = 100;
			rectCell = new Rectangle(current.X, current.Y, this.PageWidth, boxHeight);
			g.DrawRectangle(pen, rectCell);
			g.DrawString("�շ���Ϣ��",textFont,brush,current.X + 3,current.Y + 3);      

			rectCell.X += 3;
			rectCell.Y += this.RowHeight;
			rectCell.Height -= this.RowHeight;
			rectCell.Width -= 6;
			g.DrawString(dr["ChargeDetail"].ToString(),textFont, brush, rectCell, wrap);

			//ҳβ
			current.Y += boxHeight +  6 ;
			rectCell = new Rectangle(current.X,current.Y,this.PageWidth,this.RowHeight);
			StringFormat far = new StringFormat();
			far.Alignment = StringAlignment.Far;
            
			g.DrawString(this.HospitalName,textFont, brush,current);
            g.DrawString(HospitalAddress, textFont, brush, rectCell, far);

			current.Y += 1000;
		}
	}
}
