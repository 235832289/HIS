using System;
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;
using com.digitalwave.iCare.middletier.HI;
using System.Drawing.Printing;
using System.Drawing;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsCtl_DoctorWorkLoadReport 的摘要说明。
	/// </summary>
	public class clsCtl_DoctorWorkLoadReport: com.digitalwave.GUI_Base.clsController_Base
	{
		private clsDcl_DifficultyReport objSvc;
		/// <summary>
		/// 合计总额行
		/// </summary>
		private DataRow drMain;
		/// <summary>
		/// 全局数据表
		/// </summary>
		private DataTable dt;
		public clsCtl_DoctorWorkLoadReport()
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
		com.digitalwave.iCare.gui.HIS.frmDoctorWorkLoadReport m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmDoctorWorkLoadReport)frmMDI_Child_Base_in;
		}
		#endregion
		#region 加载部门
		public void m_mthLoadDepartment()
		{
			
			DataTable dt;
			long l =objSvc.m_mthGetDepartment(out dt);
			if(l>0&&dt.Rows.Count>0)
			{
				this.m_objViewer.cmbDep.Item.Add("全部","");
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
//			if(strID=="")
//			{
//				return;
//			}
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
		#region 打印
		public void m_mthBeginPrint()
		{
			if(this.m_objViewer.radioButton2.Checked)
			{
				m_mthGetMultWorkLoadData(1);
			}
			if(this.m_objViewer.radioButton4.Checked)
			{
				m_mthGetMultWorkLoadData(2);
			}
		}
		public void m_mthPrint(System.Drawing.Printing.PrintPageEventArgs e)
		{
			if(this.m_objViewer.radioButton1.Checked)//单个员工
			{
			this.m_mthPrintSingleWorkLoad(e,0);
				return;
			}
			
			if(this.m_objViewer.radioButton3.Checked)//单个部门
			{
				this.m_mthPrintSingleWorkLoad(e,2);
				return;
			}

//			if(this.m_objViewer.radioButton2.Checked)
//			{
//				m_mthPrintMultWorkLoad(e);
//			}
//			if(this.m_objViewer.radioButton4.Checked)
//			{
//				m_mthPrintMultWorkLoad(e);
//			}
			this.m_objViewer.myPrintPreViewControl1.m_mthSetDataSource(this.dt);	
			this.m_objViewer.myPrintPreViewControl1.BeginTime =this.m_objViewer.dateTimePicker1.Value.ToString("yyyy-MM-dd");
			this.m_objViewer.myPrintPreViewControl1.EndTime =this.m_objViewer.dateTimePicker2.Value.ToString("yyyy-MM-dd");
			this.m_objViewer.myPrintPreViewControl1.HospitalName =this.strHospitalName;
			this.m_objViewer.myPrintPreViewControl1.Printer=this.m_objViewer.LoginInfo.m_strEmpName;
			this.m_objViewer.myPrintPreViewControl1.ReportName =this.strReportName;
		}
		#endregion
		#region 生成表结构
		private DataTable m_mthCreatTable()
		{
			DataTable ret =new DataTable();
			ret.Columns.Add("姓名", typeof(String));
			ret.Columns.Add("合计", typeof(String));
            if (this.m_objViewer.radioButton2.Checked)
            {
                ret.Columns.Add("正方数", typeof(String));
                ret.Columns.Add("副方数", typeof(String));
    
            }
			//clsSingleWorkLoadSubItem_VO[] objSubArr=null;
			DataTable dt_Temp;
			objSvc.m_mthReportColumns(out dt_Temp,"0005");
			if(dt_Temp.Rows.Count>0)
			{
				for(int i =0;i<dt_Temp.Rows.Count;i++)
				{
					ret.Columns.Add(dt_Temp.Rows[i]["GROUPNAME_CHR"].ToString().Trim(), typeof(String));
				}
				DataRow dr=ret.NewRow();
				dr["姓名"]="医生姓名";
				if(this.m_objViewer.radioButton4.Checked)
				{
				dr["姓名"]="科室姓名";
				}
				dr["合计"]="合计";
                if (this.m_objViewer.radioButton2.Checked)
                {
                    dr["正方数"] = "正方数";
                    dr["副方数"] = "副方数";
                }
				for(int i =0;i<dt_Temp.Rows.Count;i++)
				{
					dr[dt_Temp.Rows[i]["GROUPNAME_CHR"].ToString().Trim()]=dt_Temp.Rows[i]["GROUPNAME_CHR"].ToString().Trim();
				}
				ret.Rows.Add(dr);
			}
			return ret;
		}
		#endregion

		#region 打印单个工作量
		private void m_mthPrintSingleWorkLoad(System.Drawing.Printing.PrintPageEventArgs e,int flag)
		{
			
//			foreach(PaperSize ps in this.m_objViewer.printDocument1.PrinterSettings.PaperSizes)
//			{
//				if(ps.PaperName=="A4")
//				{
//					this.m_objViewer.printDocument1.DefaultPageSettings.PaperSize=ps;
//					break;
//				}
//			}
			if(this.m_objViewer.txtCode.Tag!=null&&this.m_objViewer.txtCode.Tag.ToString().Trim()!="")
			{
				#region 收集数据
				clsSingleWorkLoad_VO obj =new clsSingleWorkLoad_VO();
				obj.m_strHospitalName =this.m_objComInfo.m_strGetHospitalTitle();
				string strID =this.m_objViewer.txtCode.Tag.ToString();
				if(flag ==2)
				{
					obj.m_strTitle="部门工作量统计报表";
					obj.m_strOwnerName ="部门名称:"+this.m_objViewer.cmbDep.Text;
					strID =this.m_objViewer.cmbDep.SelectItemValue;
				}
				else
				{
					obj.m_strTitle="医生工作量统计报表";
					obj.m_strOwnerName ="医生名称:"+this.m_objViewer.txtName.Text;
				
				}
				obj.m_strBeginDate=this.m_objViewer.dateTimePicker1.Value.ToString("yyyy年MM月dd日");
				obj.m_strEndDate=this.m_objViewer.dateTimePicker2.Value.ToString("yyyy年MM月dd日");
				clsSingleWorkLoadSubItem_VO[] objSubArr=null;
				objSvc.m_mthGetSingleWorkLoad(strID,this.m_objViewer.dateTimePicker1.Value,this.m_objViewer.dateTimePicker2.Value,flag,out objSubArr);
				obj.objSubItmeArr =objSubArr;
				if(objSubArr!=null)
				{
					decimal decSumMoney=0;
					for(int i =0;i<objSubArr.Length;i++)
					{
						decSumMoney+=this.m_mthConvertObjToDecimal(objSubArr[i].m_strCatMoney);
					}
					obj.strSumMoney =decSumMoney.ToString();
				}
				else
				{
					obj.strSumMoney="0";
				}
				#endregion
                m_objSingleWorkVo = obj;
				clsPrintSingleWorkLoad objSinglePrint =new clsPrintSingleWorkLoad(e,obj);
				objSinglePrint.m_mthBegionPrint();
			}
			else
			{
				e.Cancel =true;
			}
		}
		#endregion
        #region 全局变量Vo
        private clsSingleWorkLoad_VO m_objSingleWorkVo = null;
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
		#region 获取多个工作量数据
		public void m_mthGetMultWorkLoadData(int flag)
		{

			#region 收集数据
			
			clsSingleWorkLoadSubItem_VO[] objSubArr=null;
			dt =null;
			dt =this.m_mthCreatTable();
			drMain =dt.NewRow();
			drMain["姓名"]="合计";
			DataRow dr;
			if(flag ==2)
			{
				this.strReportName ="门诊科室核算";
				for(int i =0;i<this.m_objViewer.cmbDep.Item.sValue.Count;i++)
				{
					dr =dt.NewRow();
					dr["姓名"]=this.m_objViewer.cmbDep.Item.sText[i].ToString();
					objSvc.m_mthGetSingleWorkLoad(this.m_objViewer.cmbDep.Item.sValue[i].ToString(),this.m_objViewer.dateTimePicker1.Value,this.m_objViewer.dateTimePicker2.Value,2,out objSubArr);
					if(objSubArr!=null)
					{
						decimal decSumMoney=0;
						for(int i1 =0;i1<objSubArr.Length;i1++)
						{
							dr[objSubArr[i1].m_strCatName]=objSubArr[i1].m_strCatMoney;
							drMain[objSubArr[i1].m_strCatName]=((decimal)(m_mthConvertObjToDecimal(objSubArr[i1].m_strCatMoney)+m_mthConvertObjToDecimal(drMain[objSubArr[i1].m_strCatName]))).ToString();//合计
							decSumMoney+=this.m_mthConvertObjToDecimal(objSubArr[i1].m_strCatMoney);
						}
                        if (decSumMoney.ToString().Trim() != "0")
                        {
                            dr["合计"] = decSumMoney.ToString();//单一合计
                            dt.Rows.Add(dr);
                            decSumMoney += m_mthConvertObjToDecimal(drMain["合计"]);//计算合计
                            drMain["合计"] = decSumMoney.ToString();
                        }
					}
				}
			}
			else
			{
				this.strReportName ="门诊科室员工核算("+this.m_objViewer.cmbDep.SelectItemText+")";
                DataTable m_objTable=null;
				for(int i2 =0;i2<this.m_objViewer.listView2.Items.Count;i2++)
				{
					dr =dt.NewRow();
					dr["姓名"]=this.m_objViewer.listView2.Items[i2].SubItems[1].Text;
					objSvc.m_mthGetSingleWorkLoad(this.m_objViewer.listView2.Items[i2].SubItems[3].Text,this.m_objViewer.dateTimePicker1.Value,this.m_objViewer.dateTimePicker2.Value,1,out objSubArr);
                    objSvc.m_lngGetRecipeCountByIDAndDate(this.m_objViewer.listView2.Items[i2].SubItems[3].Text, this.m_objViewer.dateTimePicker1.Value, this.m_objViewer.dateTimePicker2.Value, out m_objTable);
					if(objSubArr!=null&&m_objTable!=null)
					{
						decimal decSumMoney=0;
						for(int i3 =0;i3<objSubArr.Length;i3++)
						{
							dr[objSubArr[i3].m_strCatName]=objSubArr[i3].m_strCatMoney;
							drMain[objSubArr[i3].m_strCatName]=((decimal)(m_mthConvertObjToDecimal(objSubArr[i3].m_strCatMoney)+m_mthConvertObjToDecimal(drMain[objSubArr[i3].m_strCatName]))).ToString();//合计
							decSumMoney+=this.m_mthConvertObjToDecimal(objSubArr[i3].m_strCatMoney);

                           
						}
                        if (decSumMoney.ToString().Trim() != "0")
                        {
                            dr["正方数"] = m_objTable.Rows[0][0].ToString();
                            dr["副方数"] = m_objTable.Rows[1][0].ToString();
                            drMain["正方数"] = ((decimal)(m_mthConvertObjToDecimal(dr["正方数"]) + m_mthConvertObjToDecimal(drMain["正方数"]))).ToString();
                            drMain["副方数"] = ((decimal)(m_mthConvertObjToDecimal(dr["副方数"]) + m_mthConvertObjToDecimal(drMain["副方数"]))).ToString();
                            dr["合计"] = decSumMoney.ToString();//单一合计
                            dt.Rows.Add(dr);
                            decSumMoney += m_mthConvertObjToDecimal(drMain["合计"]);//计算合计
                            drMain["合计"] = decSumMoney.ToString();
                        }

					}
				}
			}
			#endregion
			dt.Rows.Add(drMain);
			dt.AcceptChanges();
		}
		#endregion
		#region 打印多个工作量

		private void m_mthPrintMultWorkLoad(System.Drawing.Printing.PrintPageEventArgs e)
		{
				Pen objPen =new Pen(Color.Black,1);
				this.m_mthPrintTitle(e);
			    this.m_mthPrintColumn(0,e);
//			    X+=e.PageBounds.Width*this.fltRowWidth;
				if(this.m_objViewer.radioButton4.Checked)
				{
				X+=30;
				}
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
        #region 将数据导出到Excel表 
        private int m_intCount = 0;
        public void m_mthDataExportToExcel(int m_intFlag)
        {    
            if (m_intFlag == 2)
            {
                if (dt == null)
                    return;
                m_intCount++;
                DataTable dttemp = new DataTable("Table" + m_intCount.ToString());
                string str = "";
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    str = dt.Columns[i].ColumnName.Replace("(", "");
                    str = str.Replace(")", "");
                    dttemp.Columns.Add(str, dt.Columns[i].DataType);
                }
                DataRow dr = null;
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    dr = dttemp.NewRow();
                    for (int i2 = 0; i2 < dt.Columns.Count; i2++)
                    {
                        dr[i2] = dt.Rows[i][i2];
                    }
                    dttemp.Rows.Add(dr);
                }
                DataSet m_objDataSet = new DataSet();
                m_objDataSet.Tables.Add(dttemp);
                ExcelExporter excel = new ExcelExporter(m_objDataSet);
                bool b = excel.m_mthExport();
                if (b)
                {
                    MessageBox.Show("导出数据成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("导出数据失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                dttemp.Dispose();
                m_objDataSet.Tables.Clear();
                m_objDataSet.Dispose();
            }
            else if (m_intFlag == 1)
            {
                if (this.m_objSingleWorkVo== null)
                    return;
                m_intCount++;
                DataTable dttemp = new DataTable("Table" + m_intCount.ToString());
                string str = "";
                for (int i = 0; i < this.m_objSingleWorkVo.objSubItmeArr.Length; i++)
                {
                    str = this.m_objSingleWorkVo.objSubItmeArr[i].m_strCatName.Trim();
                    str = str.Replace("(", "");
                    str = str.Replace(")", "");
                    dttemp.Columns.Add(str,typeof(System.String));
                }
                DataRow dr = dttemp.NewRow();
                for (int i2 = 0; i2 < this.m_objSingleWorkVo.objSubItmeArr.Length; i2++)
                {
                    dr[i2] = this.m_objSingleWorkVo.objSubItmeArr[i2].m_strCatMoney.Trim();
                }
                dttemp.Rows.Add(dr);
                DataSet m_objDataSet = new DataSet();
                m_objDataSet.Tables.Add(dttemp);
                ExcelExporter excel = new ExcelExporter(m_objDataSet);
                bool b = excel.m_mthExport();
                if (b)
                {
                    MessageBox.Show("导出数据成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("导出数据失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                dttemp.Dispose();
                m_objDataSet.Tables.Clear();
                m_objDataSet.Dispose();
            }
        
        }
        #endregion
        #region 打印指定的列
        private void m_mthPrintColumn(int columnNo,System.Drawing.Printing.PrintPageEventArgs objDraw)
		{
			Pen objPen =new Pen(Color.Black,1);
			float RX=X+objDraw.PageBounds.Width*this.fltRowWidth;
			if(columnNo==0&&this.m_objViewer.radioButton4.Checked)
			{
				RX +=30;
			}
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

	}
}
