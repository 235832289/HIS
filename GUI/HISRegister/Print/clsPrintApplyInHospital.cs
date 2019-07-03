using System;
using System.Drawing;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsPrintCaseHistory 的摘要说明。
	/// </summary>
	public class clsPrintApplyInHospital
	{

		/// <summary>
		/// 画图对象
		/// </summary>
		private System.Drawing.Printing.PrintPageEventArgs objDraw;
		private clsApplyInHospitalPrint_VO obj_VO;
		/// <summary>
		/// 标题字体
		/// </summary>
		Font objFontTitle;
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
		private  float  fltRowHeight;
		/// <summary>
		/// 纵坐标
		/// </summary>
		private float  Y;
		/// <summary>
		/// 矩形高
		/// </summary>
		private float H;
		/// <summary>
		/// 单字宽
		/// </summary>
		private float SingleFontWidth;
		public clsPrintApplyInHospital(clsApplyInHospitalPrint_VO VO)
		{
			objFontTitle=new Font("SimSun",16,FontStyle.Bold);
			objFontNormal=new Font("SimSun",10);
			obj_VO=VO;
		}
		
		#region 打印标题
		private void m_mthPrintTitle()
		{
			Pen objPen =new Pen(Color.Black,1);
			//标题
			SizeF objFontSize =objDraw.Graphics.MeasureString(obj_VO.HospitalTitle.Trim(),this.objFontTitle);
			float X=(this.objDraw.PageBounds.Width-objFontSize.Width)/2;
			Y=this.objDraw.PageBounds.Height*0.05f;
			objDraw.Graphics.DrawString(obj_VO.HospitalTitle,objFontTitle,Brushes.Black,X,Y);
			Y+=objFontSize.Height+7;
			objFontSize =objDraw.Graphics.MeasureString("样",this.objFontNormal);
			this.fltRowHeight= objFontSize.Height+1;
			this.SingleFontWidth =objFontSize.Width;
			H =this.fltRowHeight-8;
			//医疗付款方式:
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			objFontSize =objDraw.Graphics.MeasureString("医疗付款方式:",this.objFontNormal);
			objDraw.Graphics.DrawString("医疗付款方式:   □",objFontNormal,Brushes.Black,X,Y);
			//医保号
			X=this.objDraw.PageBounds.Width*0.25f;
			objDraw.Graphics.DrawString("医保号:"+obj_VO.InsuranceNo,objFontNormal,Brushes.Black,X,Y);
			//第N次住院
			X=this.objDraw.PageBounds.Width*0.5f;
			objDraw.Graphics.DrawString("第 "+obj_VO.InHospitalTimes+" 次住院",objFontNormal,Brushes.Black,X,Y);
			//病案号
			X=this.objDraw.PageBounds.Width*0.7f;
			objFontSize =objDraw.Graphics.MeasureString("病案号:",this.objFontNormal);
			objDraw.Graphics.DrawString("病案号:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.strNo,objFontNormal,Brushes.Black,X,Y);
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,X+50,Y+objFontSize.Height);
			Y+=this.fltRowHeight-2;
			//画线
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			Y+=this.fltRowHeight-2;
			float RX=this.objDraw.PageBounds.Width*(1-fltRightIndentProp);
			objDraw.Graphics.DrawLine(objPen,X,Y,RX,Y);
			Y+=this.fltRowHeight-2;
			//姓名
			objFontSize =objDraw.Graphics.MeasureString("姓名:",this.objFontNormal);
			objDraw.Graphics.DrawString("姓名:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.PatientName,objFontNormal,Brushes.Black,X,Y);
			RX =X+SingleFontWidth*5;
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX+2;
			objFontSize =objDraw.Graphics.MeasureString("性别: □ ",this.objFontNormal);
			objDraw.Graphics.DrawString("性别: □ 1.男 2.女",objFontNormal,Brushes.Black,X,Y);
			using(Font fontemp =new Font("SimSun",14))
			{
				if(obj_VO.Sex=="男")
				{
					objDraw.Graphics.DrawString("√",fontemp,Brushes.Black,X+objFontSize.Width,Y);
				}
				else
				{
					objDraw.Graphics.DrawString("√",fontemp,Brushes.Black,X+objFontSize.Width*1.5f+2,Y);
				}
			}
			//出生日期
			X=this.objDraw.PageBounds.Width*0.45f;
			objDraw.Graphics.DrawString("出生",objFontNormal,Brushes.Black,X,Y);
			X+=this.SingleFontWidth*2+2;
			objDraw.Graphics.DrawString(obj_VO.BirthDay_Year,objFontNormal,Brushes.Black,X,Y);
			RX =X+SingleFontWidth*2;
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX+2;
			objDraw.Graphics.DrawString("年",objFontNormal,Brushes.Black,X,Y);
			X+=this.SingleFontWidth+2;
			objDraw.Graphics.DrawString(obj_VO.BirthDay_Month,objFontNormal,Brushes.Black,X,Y);
			RX =X+SingleFontWidth+2;
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX+2;
			objDraw.Graphics.DrawString("月",objFontNormal,Brushes.Black,X,Y);
			X+=this.SingleFontWidth+2;
			objDraw.Graphics.DrawString(obj_VO.BirthDay_Day,objFontNormal,Brushes.Black,X,Y);
			RX =X+SingleFontWidth+2;
			
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX;
			objDraw.Graphics.DrawString("日",objFontNormal,Brushes.Black,X,Y);
			//年龄
			X=this.objDraw.PageBounds.Width*0.7f;
			objFontSize =objDraw.Graphics.MeasureString("年龄",this.objFontNormal);
			objDraw.Graphics.DrawString("年龄",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.Age,objFontNormal,Brushes.Black,X,Y);
			//画线
			RX =X+SingleFontWidth*2;
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX+2;
			objFontSize =objDraw.Graphics.MeasureString("婚姻: □ ",this.objFontNormal);
			objDraw.Graphics.DrawString("婚姻: □ 1.未 2.已",objFontNormal,Brushes.Black,X,Y);
			using(Font fontemp =new Font("SimSun",14))
			{
				if(obj_VO.Marry=="已")
				{
					objDraw.Graphics.DrawString("√",fontemp,Brushes.Black,X+objFontSize.Width,Y);
				}
				else
				{
					objDraw.Graphics.DrawString("√",fontemp,Brushes.Black,X+objFontSize.Width*1.5f+2,Y);
				}
			}
			this.Y+=this.fltRowHeight+10;

			//职业
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			objFontSize =objDraw.Graphics.MeasureString("职业:",this.objFontNormal);
			objDraw.Graphics.DrawString("职业:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.Work,objFontNormal,Brushes.Black,X,Y);
			RX =X+SingleFontWidth*5;	
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX+2;
			//出生地
			objFontSize =objDraw.Graphics.MeasureString("出生地",this.objFontNormal);
			objDraw.Graphics.DrawString("出生地",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.BirthPlace,objFontNormal,Brushes.Black,X,Y);
			RX =X+SingleFontWidth*4;	
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX+2;
			//省(市)
			objFontSize =objDraw.Graphics.MeasureString("省(市)",this.objFontNormal);
			objDraw.Graphics.DrawString("省(市)",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.County,objFontNormal,Brushes.Black,X,Y);
			RX =X+SingleFontWidth*2.5f;	
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX;
			float RXTemp =RX;
			objDraw.Graphics.DrawString("县",objFontNormal,Brushes.Black,X,Y);
			X+=SingleFontWidth*2;
			//民族
			objFontSize =objDraw.Graphics.MeasureString("民族",this.objFontNormal);
			objDraw.Graphics.DrawString("民族",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.Nationality,objFontNormal,Brushes.Black,X,Y);
			RX =X+SingleFontWidth*2;	
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX+10;
			//国籍
			objFontSize =objDraw.Graphics.MeasureString("国籍",this.objFontNormal);
			objDraw.Graphics.DrawString("国籍",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.Country,objFontNormal,Brushes.Black,X,Y);
			RX =X+SingleFontWidth*2;	
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX+10;
			//身份证号
			objFontSize =objDraw.Graphics.MeasureString("身份证号",this.objFontNormal);
			objDraw.Graphics.DrawString("身份证号",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.PID,objFontNormal,Brushes.Black,X,Y);
			RX=this.objDraw.PageBounds.Width*(1-fltRightIndentProp);
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			this.Y+=this.fltRowHeight+10;
			//工作单位及地址
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			objFontSize =objDraw.Graphics.MeasureString("工作单位及地址:",this.objFontNormal);
			objDraw.Graphics.DrawString("工作单位及地址:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.WorkAddress,objFontNormal,Brushes.Black,X,Y);
			RX =RXTemp;
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX+2;
			//电话
			objFontSize =objDraw.Graphics.MeasureString("电话",this.objFontNormal);
			objDraw.Graphics.DrawString("电话",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.WorkTel,objFontNormal,Brushes.Black,X,Y);
			RX =X+SingleFontWidth*6;
			RXTemp =RX;
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX+2;
			//邮政编码
			objFontSize =objDraw.Graphics.MeasureString("邮政编码",this.objFontNormal);
			objDraw.Graphics.DrawString("邮政编码",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.WorkPostalcode,objFontNormal,Brushes.Black,X,Y);
			RX=this.objDraw.PageBounds.Width*(1-fltRightIndentProp);
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			this.Y+=this.fltRowHeight+10;
			//户口地址
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			objFontSize =objDraw.Graphics.MeasureString("户口地址:",this.objFontNormal);
			objDraw.Graphics.DrawString("户口地址:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.HomeAddress,objFontNormal,Brushes.Black,X,Y);
			RX =RXTemp;
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX+2;
			//邮政编码
			objFontSize =objDraw.Graphics.MeasureString("邮政编码",this.objFontNormal);
			objDraw.Graphics.DrawString("邮政编码",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.HomePostalcode,objFontNormal,Brushes.Black,X,Y);
			RX=this.objDraw.PageBounds.Width*(1-fltRightIndentProp);
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			this.Y+=this.fltRowHeight+10;

			//联系人姓名
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			objFontSize =objDraw.Graphics.MeasureString("联系人姓名:",this.objFontNormal);
			objDraw.Graphics.DrawString("联系人姓名:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.LinkMan,objFontNormal,Brushes.Black,X,Y);
			RX =X+SingleFontWidth*5;	
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX+2;
			//关系
			objFontSize =objDraw.Graphics.MeasureString("关系",this.objFontNormal);
			objDraw.Graphics.DrawString("关系",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.Relation,objFontNormal,Brushes.Black,X,Y);
			RX =X+SingleFontWidth*3;	
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX+2;
			//地址
			objFontSize =objDraw.Graphics.MeasureString("地址",this.objFontNormal);
			objDraw.Graphics.DrawString("地址",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.RelationAddress,objFontNormal,Brushes.Black,X,Y);
			RX =RXTemp;	
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX;
			//电话
			objFontSize =objDraw.Graphics.MeasureString("电话",this.objFontNormal);
			objDraw.Graphics.DrawString("电话",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.RelationTel,objFontNormal,Brushes.Black,X,Y);
			RX=this.objDraw.PageBounds.Width*(1-fltRightIndentProp);
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX+10;
			this.Y+=this.fltRowHeight+20;
			//////////////////////
			//入院日期
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			objFontSize =objDraw.Graphics.MeasureString("入院日期:",this.objFontNormal);
			objDraw.Graphics.DrawString("入院日期:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;	
			objDraw.Graphics.DrawString(obj_VO.BirthDay_Year,objFontNormal,Brushes.Black,X,Y);
			RX =X+SingleFontWidth*2;
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX+2;
			objDraw.Graphics.DrawString("年",objFontNormal,Brushes.Black,X,Y);
			X+=this.SingleFontWidth+2;
			objDraw.Graphics.DrawString(obj_VO.InhospitalDate_Month,objFontNormal,Brushes.Black,X,Y);
			RX =X+SingleFontWidth+2;
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX+2;
			objDraw.Graphics.DrawString("月",objFontNormal,Brushes.Black,X,Y);
			X+=this.SingleFontWidth+2;
			objDraw.Graphics.DrawString(obj_VO.InhospitalDate_Day,objFontNormal,Brushes.Black,X,Y);
			RX =X+SingleFontWidth+2;
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX+2;
			objDraw.Graphics.DrawString("日",objFontNormal,Brushes.Black,X,Y);
			X+=this.SingleFontWidth+2;
			objDraw.Graphics.DrawString(obj_VO.InhospitalDate_Hour,objFontNormal,Brushes.Black,X,Y);
			RX =X+SingleFontWidth+2;
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX+2;
			objDraw.Graphics.DrawString("时",objFontNormal,Brushes.Black,X,Y);
//			X+=this.SingleFontWidth+2;
//			objDraw.Graphics.DrawString(obj_VO.InhospitalDate_Hour,objFontNormal,Brushes.Black,X,Y);

			//入院科别
			X=this.objDraw.PageBounds.Width*0.5f;
			objFontSize =objDraw.Graphics.MeasureString("入院科别",this.objFontNormal);
			objDraw.Graphics.DrawString("入院科别",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.Department,objFontNormal,Brushes.Black,X,Y);
			RX =X+SingleFontWidth*6;
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX+2;
			//病室
			objFontSize =objDraw.Graphics.MeasureString("病室",this.objFontNormal);
			objDraw.Graphics.DrawString("病室",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.Room,objFontNormal,Brushes.Black,X,Y);
			RX =X+SingleFontWidth*6;
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX+2;
			this.Y+=this.fltRowHeight+10;
			//按金
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			objFontSize =objDraw.Graphics.MeasureString("按金:",this.objFontNormal);
			objDraw.Graphics.DrawString("按金:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.Money,objFontNormal,Brushes.Black,X,Y);
			RX =X+SingleFontWidth*5;
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			X=RX+2;
			objDraw.Graphics.DrawString("元",objFontNormal,Brushes.Black,X,Y);
			//入院时情况
			X=this.objDraw.PageBounds.Width*0.5f;
			objFontSize =objDraw.Graphics.MeasureString("入院时情况:",this.objFontNormal);
			objDraw.Graphics.DrawString("入院时情况:1.危 2.急 3.一般 ",objFontNormal,Brushes.Black,X,Y);
			using(Font fontemp =new Font("SimSun",14))
			{
				switch(obj_VO.InHospitalCase)
				{
					case "危":
						objDraw.Graphics.DrawString("√",fontemp,Brushes.Black,X+objFontSize.Width-SingleFontWidth,Y);
						break;
					case "急":
						objDraw.Graphics.DrawString("√",fontemp,Brushes.Black,X+objFontSize.Width*1.5f-SingleFontWidth,Y);
						break;
					default :
						objDraw.Graphics.DrawString("√",fontemp,Brushes.Black,X+objFontSize.Width*2f-SingleFontWidth,Y);
						break;
				}
			}
			this.Y+=this.fltRowHeight+10;
			/////////////////////////////////////////////
			//门(急)诊诊断
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			objFontSize =objDraw.Graphics.MeasureString("门(急)诊诊断:",this.objFontNormal);
			objDraw.Graphics.DrawString("门(急)诊诊断:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
            RX =this.objDraw.PageBounds.Width*0.6f;
			objFontSize =objDraw.Graphics.MeasureString(obj_VO.Diag,this.objFontNormal);
			float y =Y+this.fltRowHeight;
			objDraw.Graphics.DrawLine(objPen,X,y,RX,y);
			 y +=this.fltRowHeight+10;
			objDraw.Graphics.DrawLine(objPen,X,y,RX,y);
			if((RX-X)>objFontSize.Width)
			{
			//一行
				objDraw.Graphics.DrawString(obj_VO.Diag,objFontNormal,Brushes.Black,X,Y);

			}
			else
			{
				//两行
				RXTemp =X;
				y=Y;
				bool flag =false;
				for(int i=0;i<obj_VO.Diag.Length;i++)
				{
					objFontSize =objDraw.Graphics.MeasureString(obj_VO.Diag[i].ToString(),this.objFontNormal);
                    objDraw.Graphics.DrawString(obj_VO.Diag[i].ToString(),objFontNormal,Brushes.Black,RXTemp,y);
					RXTemp+=objFontSize.Width-3;
					if(RXTemp>=RX)
					{
						if(flag)
						{
						break;
						}
						y+=this.fltRowHeight+10;
						RXTemp =X;
						flag =true;
					}
				}
			}
			//门(急)诊诊断医生
			X=this.objDraw.PageBounds.Width*0.65f;
			objFontSize =objDraw.Graphics.MeasureString("门(急)诊诊断医生:",this.objFontNormal);
			objDraw.Graphics.DrawString("门(急)诊诊断医生:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.DoctorName,objFontNormal,Brushes.Black,X,Y);
			RX=this.objDraw.PageBounds.Width*(1-fltRightIndentProp);
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			this.Y+=this.fltRowHeight+10;

			//医生工号
			X=this.objDraw.PageBounds.Width*0.65f;
			objFontSize =objDraw.Graphics.MeasureString("医生工号:",this.objFontNormal);
			objDraw.Graphics.DrawString("医生工号:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.DoctorNo,objFontNormal,Brushes.Black,X,Y);
			RX=this.objDraw.PageBounds.Width*(1-fltRightIndentProp);
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
			this.Y+=this.fltRowHeight+10;

			//备注
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			objFontSize =objDraw.Graphics.MeasureString("备注:",this.objFontNormal);
			objDraw.Graphics.DrawString("备注:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.Remark,objFontNormal,Brushes.Black,X,Y);
			RX=this.objDraw.PageBounds.Width*(1-fltRightIndentProp);
			//画线
			objDraw.Graphics.DrawLine(objPen,X,Y+objFontSize.Height,RX,Y+objFontSize.Height);
		}
		#endregion
		#region 打印内容
		
		private void m_mthPrintText()
		{
		
		}
		
		#endregion
		#region 打印页脚
		private void m_mthPrintEnd()
		{
		}
		#endregion
		#region 开始打印
		public void m_mthBegionPrint(System.Drawing.Printing.PrintPageEventArgs p_obj)
		{
			objDraw=p_obj;
			this.m_mthPrintTitle();
			this.m_mthPrintText();
			this.m_mthPrintEnd();
		}
		#endregion
	}
}
