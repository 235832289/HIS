using System;
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;
using com.digitalwave.iCare.middletier.HI;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Data.OleDb;
namespace com.digitalwave.iCare.gui.HIS.Reports
{
	/// <summary>
	/// clsCtl_DoctorWorkLoadReport 的摘要说明。
	/// </summary>
	public class clsControlChargeWorkReport: com.digitalwave.GUI_Base.clsController_Base
	{
		private clsDcl_DifficultyReport objSvc;
		/// <summary>
		/// 合计总额行
		/// </summary>
		private DataRow drMain;
		/// <summary>
		/// 全局数据表
		/// </summary>
        public DataTable dt;
		public clsControlChargeWorkReport()
		{
			objSvc=new clsDcl_DifficultyReport();
			objFontTitle1=new Font("SimSun",12,FontStyle.Bold);
			objFontTitle2=new Font("SimSun",16,FontStyle.Bold);
			objFontNormal=new Font("SimSun",10);
			this.strHospitalName =m_objComInfo.m_strGetHospitalTitle();
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.Reports.frmChargeWorkReport m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmChargeWorkReport)frmMDI_Child_Base_in;
		}
		#endregion
		#region 打印
		public void m_mthBeginPrint()
		{
			m_mthGetMultWorkLoadData();

           
			this.m_objViewer.myPrintPreViewControl1.m_mthSetDataSource(this.dt);	
			this.m_objViewer.myPrintPreViewControl1.BeginTime =this.m_objViewer.dateTimePicker1.Value.ToString("yyyy-MM-dd");
			this.m_objViewer.myPrintPreViewControl1.EndTime =this.m_objViewer.dateTimePicker2.Value.ToString("yyyy-MM-dd");
			this.m_objViewer.myPrintPreViewControl1.HospitalName =this.strHospitalName;
			this.m_objViewer.myPrintPreViewControl1.Printer=this.m_objViewer.LoginInfo.m_strEmpName;
			this.m_objViewer.myPrintPreViewControl1.ReportName =this.strReportName;
		}
		public void m_mthPrint(System.Drawing.Printing.PrintPageEventArgs e)
		{
//			this.m_objViewer.myPrintPreViewControl1.m_mthSetDataSource(this.dt);	
//			this.m_objViewer.myPrintPreViewControl1.BeginTime =this.m_objViewer.dateTimePicker1.Value.ToString("yyyy-MM-dd");
//			this.m_objViewer.myPrintPreViewControl1.EndTime =this.m_objViewer.dateTimePicker2.Value.ToString("yyyy-MM-dd");
//			this.m_objViewer.myPrintPreViewControl1.HospitalName =this.strHospitalName;
//			this.m_objViewer.myPrintPreViewControl1.Printer=this.m_objViewer.LoginInfo.m_strEmpName;
//			this.m_objViewer.myPrintPreViewControl1.ReportName =this.strReportName;
		}
		#endregion
		#region 生成表结构
		private DataTable m_mthCreatTable()
		{
			DataTable ret =new DataTable();
			ret.Columns.Add("姓名", typeof(String));
            if (this.m_objViewer.strType == "0")
            {
                ret.Columns.Add("有效发票数", typeof(String));
            }
			ret.Columns.Add("合计", typeof(String));
			DataTable dt_Temp;
			objSvc.m_mthReportColumns(out dt_Temp,"0068");
			if(dt_Temp.Rows.Count>0)
			{
				for(int i =0;i<dt_Temp.Rows.Count;i++)
				{
					ret.Columns.Add(dt_Temp.Rows[i]["GROUPNAME_CHR"].ToString().Trim(), typeof(String));
				}
                DataRow dr = ret.NewRow();
                dr["姓名"] = "收费员姓名";
                if (this.m_objViewer.strType == "0")
                {
                    dr["有效发票数"] = "有效发票数";
                }
                dr["合计"] = "合计";
                for (int i = 0; i < dt_Temp.Rows.Count; i++)
                {
                    dr[dt_Temp.Rows[i]["GROUPNAME_CHR"].ToString().Trim()] = dt_Temp.Rows[i]["GROUPNAME_CHR"].ToString().Trim();
                }
                ret.Rows.Add(dr);
			}
			return ret;
		}
		#endregion

		#region 全局变量
		/// <summary>
		/// 报表名称
		/// </summary>
		private string strReportName ="";
		/// <summary>
		/// 医院名称
		/// </summary>
		private string strHospitalName ="";
	    /// <summary>
	    /// 当前页数
	    /// </summary>
		private int intPageLocation=0;
		/// <summary>
		/// 标题字体1
		/// </summary>
		Font objFontTitle1;
		/// <summary>
		/// 标题字体2
		/// </summary>
		Font objFontTitle2;
		/// <summary>
		/// 正常字体
		/// </summary>
		Font objFontNormal;
		/// <summary>
		/// 左边距
		/// </summary>
		float fltLeftIndentProp=0.07f;
		/// <summary>
		/// 右边距
		/// </summary>
		float fltRightIndentProp=0.07f;
		/// <summary>
		/// 行间隔
		/// </summary>
		private  float  fltRowHeight=0;
		/// <summary>
		///列宽
		/// </summary>
		private  float  fltRowWidth=0.055f;
		/// <summary>
		/// 纵坐标
		/// </summary>
		private float  Y;
		/// <summary>
		/// 横坐标
		/// </summary>
		private float  X;
		/// <summary>
		/// 记录最搞的Y坐标
		/// </summary>
		private float Y2=0;
		/// <summary>
		/// 行号
		/// </summary>
		private int row=2;
		#endregion
		#region 获取收费员工作量数据
		/// <summary>
		/// 获取收费员工作量数据
		/// </summary>
		public void m_mthGetMultWorkLoadData()
		{

			#region 收集数据
			
            //clsChargeWork_VO[] objSubArr=null;
			dt =null;
			dt =this.m_mthCreatTable();
			drMain =dt.NewRow();
			drMain["姓名"]="合计";
			DataRow dr;
			if(this.m_objViewer.strType=="0")
				this.strReportName ="门诊收费员工作量统计报表";
			else
				this.strReportName ="门诊收费员月结统计报表";

            #region old
//            objSvc.m_mthGetCheckManWorkLoad(this.m_objViewer.dateTimePicker1.Value,this.m_objViewer.dateTimePicker2.Value,out objSubArr);
//            if(objSubArr!=null)
//            {               
////				decimal decSumMoney=0;
//                for(int i3 =0;i3<objSubArr.Length;i3++)
//                {
//                    if(objSubArr[i3].m_strChargeName.Trim()!="")
//                    {
//                        if(i3 ==0)
//                        {
//                            dr =dt.NewRow();
//                            dr["姓名"]=objSubArr[i3].m_strChargeName;
//                            dr[objSubArr[i3].m_strCatName]=objSubArr[i3].m_strCatMoney;
//                            drMain[objSubArr[i3].m_strCatName]=((decimal)(m_mthConvertObjToDecimal(objSubArr[i3].m_strCatMoney)+m_mthConvertObjToDecimal(drMain[objSubArr[i3].m_strCatName]))).ToString();//合计
////							decSumMoney+=this.m_mthConvertObjToDecimal(objSubArr[i3].m_strCatMoney);
//                            dt.Rows.Add(dr);
//                        }
//                        else
//                        {
//                            for(int k1=0;k1<dt.Rows.Count;k1++)
//                            {
//                                if(dt.Rows[k1]["姓名"].ToString().Trim()==objSubArr[i3].m_strChargeName.Trim())
//                                {
//                                    dt.Rows[k1][objSubArr[i3].m_strCatName]=objSubArr[i3].m_strCatMoney;
//                                    drMain[objSubArr[i3].m_strCatName]=((decimal)(m_mthConvertObjToDecimal(objSubArr[i3].m_strCatMoney)+m_mthConvertObjToDecimal(drMain[objSubArr[i3].m_strCatName]))).ToString();//合计
////									decSumMoney+=this.m_mthConvertObjToDecimal(objSubArr[i3].m_strCatMoney);
//                                    break;
//                                }
//                                else
//                                {
//                                    if(k1==dt.Rows.Count-1)
//                                    {
//                                        dr =dt.NewRow();
//                                        dr["姓名"]=objSubArr[i3].m_strChargeName;
//                                        dr[objSubArr[i3].m_strCatName]=objSubArr[i3].m_strCatMoney;
//                                        drMain[objSubArr[i3].m_strCatName]=((decimal)(m_mthConvertObjToDecimal(objSubArr[i3].m_strCatMoney)+m_mthConvertObjToDecimal(drMain[objSubArr[i3].m_strCatName]))).ToString();//合计
////										decSumMoney+=this.m_mthConvertObjToDecimal(objSubArr[i3].m_strCatMoney);
//                                        dt.Rows.Add(dr);
//                                    }
//                                }
//                            }
//                        }
//                    }
//                }

////				decSumMoney+=m_mthConvertObjToDecimal(drMain["合计"]);//计算合计
////				drMain["合计"]=decSumMoney.ToString();
//            }
            #endregion //old

            #region new                        
            DataTable dtSource = new DataTable();
            long l = objSvc.m_mthGetCheckManWorkLoad(this.m_objViewer.dateTimePicker1.Value, this.m_objViewer.dateTimePicker2.Value, out dtSource);
            if (l > 0 && dtSource.Rows.Count > 0)
            {
                string empname = "";
                Hashtable has = new Hashtable();

                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    empname = dtSource.Rows[i]["lastname_vchr"].ToString();
                    if (has.ContainsKey(empname) || empname.Trim() == "")
                    {
                        continue;
                    }
                    has.Add(empname, null);
                }

                ArrayList arrEmp = new ArrayList();
                arrEmp.AddRange(has.Keys);
                arrEmp.Sort();
                DataView DV = new DataView(dtSource);

                for (int i = 0; i < arrEmp.Count; i++)
                {
                    empname = arrEmp[i].ToString();

                    dr = dt.NewRow();
                    dr["姓名"] = empname;                                           

                    DV.RowFilter = "lastname_vchr = '" + empname + "'";
                    foreach (DataRowView drv in DV)
                    {
                        dr[drv["groupname_chr"].ToString().Trim()] = drv["tolfee_mny"].ToString().Trim();
                        drMain[drv["groupname_chr"].ToString().Trim()] = ((decimal)(m_mthConvertObjToDecimal(drv["tolfee_mny"].ToString()) + m_mthConvertObjToDecimal(drMain[drv["groupname_chr"].ToString().Trim()]))).ToString(); //合计
                    }
                    dt.Rows.Add(dr);
                }
            }         
            #endregion

            #endregion

            dt.Rows.Add(drMain);
			decimal decSumMoney=0;
			for(int j1=1;j1<dt.Rows.Count-1;j1++)
			{
				decimal decSumMoney1=0;
				for(int b1=2;b1<dt.Columns.Count;b1++)
				{
					if(dt.Rows[j1][b1].ToString()!="")
					{
						decSumMoney1+=m_mthConvertObjToDecimal(dt.Rows[j1][b1]);
					}
				}
				decSumMoney+=decSumMoney1;
				dt.Rows[j1]["合计"]=decSumMoney1.ToString();
			}
			dt.Rows[dt.Rows.Count-1]["合计"]=decSumMoney.ToString();
                        
            //计算有效发票数
            if (this.m_objViewer.strType == "0")
            {
                DataTable dtInvo = new DataTable();
                l = objSvc.m_lngGetCheckinvoicenums(this.m_objViewer.dateTimePicker1.Value.ToString("yyyy-MM-dd"), this.m_objViewer.dateTimePicker2.Value.ToString("yyyy-MM-dd"), out dtInvo);
                if (l > 0 && dtInvo.Rows.Count > 0)
                {
                    decimal Totalinvos = 0;
                    for (int i = 1; i < dt.Rows.Count - 1; i++)
                    {
                        string empname = dt.Rows[i]["姓名"].ToString().Trim();
                        for (int j = 0; j < dtInvo.Rows.Count; j++)
                        {
                            if (dtInvo.Rows[j]["lastname_vchr"].ToString().Trim() == empname)
                            {
                                decimal invos = m_mthConvertObjToDecimal(dtInvo.Rows[j]["kps"]) - m_mthConvertObjToDecimal(dtInvo.Rows[j]["tps"]) + m_mthConvertObjToDecimal(dtInvo.Rows[j]["hfs"]);
                                dt.Rows[i]["有效发票数"] = invos.ToString();

                                Totalinvos += invos;
                            }
                        }
                    }
                    dt.Rows[dt.Rows.Count - 1]["有效发票数"] = Totalinvos.ToString();
                }
            }

			dt.AcceptChanges();

            int colindex = 0;
            int intAgv =9;
            DataTable dtTemp = new DataTable();
            int col = dt.Columns.Count;
            for (int i = 0; i < col; i++)
            {
                dtTemp.Columns.Add(dt.Columns[i].ColumnName);

                if (dtTemp.Columns.Count % intAgv == 0)
                {
                    // intAgv--;
                    colindex++;

                    dtTemp.Columns.Add("收费员姓名" + colindex.ToString());
                }
            }
            DataRow drTemp2 = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                drTemp2 = dtTemp.NewRow();
                for (int i2 = 0; i2 < dt.Columns.Count; i2++)
                {
                    drTemp2[dt.Columns[i2].ColumnName] = dt.Rows[i][i2];
                }
                for (int i3 = 1; i3 <= colindex; i3++)
                {
                    drTemp2["收费员姓名" + i3.ToString()] = dt.Rows[i][0];
                }
                dtTemp.Rows.Add(drTemp2);
            }

            dt = dtTemp;

		}
		#endregion
		#region 打印多个工作量

		private void m_mthPrintMultWorkLoad(System.Drawing.Printing.PrintPageEventArgs e)
		{
				Pen objPen =new Pen(Color.Black,1);
				this.m_mthPrintTitle(e);
			    this.m_mthPrintColumn(0,e);
////			    X+=e.PageBounds.Width*this.fltRowWidth;
//				if(this.m_objViewer.radioButton4.Checked)
//				{
//				X+=30;
//				}
				Y=Y2;
				if(this.intPageLocation==0)
				{
				 X+=e.PageBounds.Width*this.fltRowWidth;
				 this.m_mthPrintColumn(1,e);
				}
				for(int i=row;i<dt.Columns.Count;i++)
				{
					if(X>e.PageBounds.Width*(1-this.fltRowWidth-this.fltRightIndentProp))
					{
					e.HasMorePages =true;
					intPageLocation+=1;
					float temp =X+e.PageBounds.Width*this.fltRowWidth;
					e.Graphics.DrawLine(objPen,temp,Y2,temp,Y2+fltRowHeight*dt.Rows.Count);
					break;
					}
					X+=e.PageBounds.Width*this.fltRowWidth;//把坐标复位
					Y=Y2;
					 this.m_mthPrintColumn(i,e);
					row =i;//记录当前画到那一列
				}
					X+=e.PageBounds.Width*this.fltRowWidth;//定位在最后一条线上
					e.Graphics.DrawLine(objPen,X,Y2,X,Y2+fltRowHeight*dt.Rows.Count);//画最后一条线
					objPen.Dispose();
					objPen=null;
		}
		#endregion
		#region 打印标题
		private void m_mthPrintTitle(System.Drawing.Printing.PrintPageEventArgs objDraw)
		{
			//标题
			//医院名称
			SizeF objFontSize =objDraw.Graphics.MeasureString(this.strHospitalName+this.strReportName,this.objFontTitle1);
			X=(objDraw.PageBounds.Width-objFontSize.Width)/2;
			Y=objDraw.PageBounds.Height*0.047f-(objFontSize.Height/2);
			objDraw.Graphics.DrawString(this.strHospitalName+this.strReportName,objFontTitle1,Brushes.Black,X,Y);
			Y+=objFontSize.Height+5;
			//日期
			objFontSize =objDraw.Graphics.MeasureString(this.m_objViewer.dateTimePicker1.Value.ToString("yyyy-MM-dd")+" 至 "+this.m_objViewer.dateTimePicker2.Value.ToString("yyyy-MM-dd"),this.objFontNormal);
			X=(objDraw.PageBounds.Width-objFontSize.Width)/2;
			objDraw.Graphics.DrawString(this.m_objViewer.dateTimePicker1.Value.ToString("yyyy-MM-dd")+" 至 "+this.m_objViewer.dateTimePicker2.Value.ToString("yyyy-MM-dd"),objFontNormal,Brushes.Black,X,Y);
			//打印人
			Y+=objFontSize.Height+10;
			X=objDraw.PageBounds.Width*fltLeftIndentProp;
			objFontSize =objDraw.Graphics.MeasureString("打印",this.objFontNormal);
			objDraw.Graphics.DrawString("打印:"+this.m_objViewer.LoginInfo.m_strEmpName,objFontNormal,Brushes.Black,X,Y);
			Y+=objFontSize.Height+2;
			Y2=Y;
			fltRowHeight =	objFontSize.Height+2;	

		}
		#endregion
		#region 打印指定的列
		private void m_mthPrintColumn(int columnNo,System.Drawing.Printing.PrintPageEventArgs objDraw)
		{
			Pen objPen =new Pen(Color.Black,1);
			float RX=X+objDraw.PageBounds.Width*this.fltRowWidth;
//			if(columnNo==0&&this.m_objViewer.radioButton4.Checked)
//			{
//				RX +=30;
//			}
			objDraw.Graphics.DrawLine(objPen,X,Y,X,Y+fltRowHeight*dt.Rows.Count);//画左竖线
			for(int i =0;i<dt.Rows.Count;i++)
			{
				objDraw.Graphics.DrawLine(objPen,X,Y,RX,Y);
				objDraw.Graphics.DrawString(dt.Rows[i][columnNo].ToString(),objFontNormal,Brushes.Black,X+1,Y+2);
				Y+=fltRowHeight;

			}
			objDraw.Graphics.DrawLine(objPen,X,Y,RX,Y);//画最后一条横线
			objPen.Dispose();
			objPen =null;
		}
		#endregion
		#region 转换成数字
		public decimal m_mthConvertObjToDecimal(object obj)
		{
			try
			{
				if( obj!=null&&obj.ToString()!="")
				{
					return Convert.ToDecimal(obj.ToString());

				}
				else
				{
					return 0;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return 0;
			}
		}
		public decimal m_mthConvertObjToDecimal(string str)
		{
			try
			{
				return Convert.ToDecimal(str.Trim());
			}
			catch
			{
				return 0;
			}
		}
		#endregion

        
        int intCount = 1;
        public void m_mthOutExcel2(DataTable p_dt)
        {
        
            intCount++;
            DataTable dttemp = new DataTable("Table" + intCount.ToString());
            string str = "";
            for (int i = 0; i < p_dt.Columns.Count; i++)
            {
                str = p_dt.Columns[i].ColumnName.Replace("(", "（");
                str = str.Replace(")", "）");
                dttemp.Columns.Add(str, p_dt.Columns[i].DataType);

            }
            DataRow dr = null;
            for (int i = 0; i < p_dt.Rows.Count; i++)
            {
                dr = dttemp.NewRow();
                for (int i2 = 0; i2 < p_dt.Columns.Count; i2++)
                {
                    dr[i2] = p_dt.Rows[i][i2];
                }
                dttemp.Rows.Add(dr);
            }
            DataSet ds = new DataSet();
            ds.Tables.Clear();
            ds.Tables.Add(dttemp);
            ExcelExporter excel = new ExcelExporter(ds);
            bool b = excel.m_mthExport();
            if (b)
            {
                MessageBox.Show("导出数据成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("导出数据失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            ds.Tables.Clear();
            dttemp = null;
            ds = null;
        }
        public void m_mthOutExcel(DataTable p_dt)
        {
            intCount ++;
            DataTable dttemp = new DataTable("Table"+intCount.ToString());
            string str = "";
            for (int i = 0; i < p_dt.Columns.Count; i++)
            {
                str = p_dt.Columns[i].ColumnName.Replace("(", "（");
                str = str.Replace(")","）");
                if (str.Contains("缴款人") || str.Contains("名称"))
                {
                    dttemp.Columns.Add(str, p_dt.Columns[i].DataType);
                }
                else
                {
                    dttemp.Columns.Add(str, System.Type.GetType("System.Double"));
                }
            }
            DataRow dr = null;
            for (int i = 0; i < p_dt.Rows.Count; i++)
            {
                dr = dttemp.NewRow();
                for (int i2 = 0; i2 < p_dt.Columns.Count; i2++)
                {
                    dr[i2] = p_dt.Rows[i][i2];
                }
                dttemp.Rows.Add(dr);
            }
            DataSet ds = new DataSet();
            ds.Tables.Clear();
            ds.Tables.Add(dttemp);
            ExcelExporter excel = new ExcelExporter(ds);
            bool b = excel.m_mthExport();
            if (b)
            {
                MessageBox.Show("导出数据成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("导出数据失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            ds.Tables.Clear();
            dttemp = null;
            ds = null;
        }

	}


}
