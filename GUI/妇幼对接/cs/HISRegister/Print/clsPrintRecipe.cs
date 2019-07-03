using System;
using System.Drawing;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
	public class clsPrintRecipe
	{
		public clsPrintRecipe(System.Drawing.Printing.PrintPageEventArgs p_obj,clsOutpatientPrintRecipe_VO VO)
		{
			objDraw=p_obj;
			objFontTitle=new Font("SimSun",16,FontStyle.Bold);
			objFontNormal=new Font("SimSun",10);
			obj_VO=VO;
		}
		/// <summary>
		/// 画图对象
		/// </summary>
		private System.Drawing.Printing.PrintPageEventArgs objDraw;
		private clsOutpatientPrintRecipe_VO obj_VO;
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
		
		#region 打印标题
		private void m_mthPrintTitle()
		{
			//标题
			SizeF objFontSize =objDraw.Graphics.MeasureString(obj_VO.m_strHospitalName+"处方信息",this.objFontTitle);
			float X=(this.objDraw.PageBounds.Width-objFontSize.Width)/2;
			Y=this.objDraw.PageBounds.Height*0.047f-(objFontSize.Height/2);
			objDraw.Graphics.DrawString(obj_VO.m_strHospitalName+"处方信息",objFontTitle,Brushes.Black,X,Y);
			//页面
			Y+=objFontSize.Height/2-5;
			objFontSize =objDraw.Graphics.MeasureString("第1页/共1页",this.objFontNormal);
			fltRowHeight=objFontSize.Height;
			X=this.objDraw.PageBounds.Width*(1-fltRightIndentProp)-objFontSize.Width;
			objDraw.Graphics.DrawString("第1页/共1页",objFontNormal,Brushes.Black,X,Y);
			//画线
			Y+=14;
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			float RX=this.objDraw.PageBounds.Width*(1-fltRightIndentProp);
			objDraw.Graphics.DrawLine(new Pen(Color.Black,2),X,Y,RX,Y);
			//就诊卡号
			Y+=this.fltRowHeight/2;
			objFontSize =objDraw.Graphics.MeasureString("就诊卡号:",this.objFontNormal);
			objDraw.Graphics.DrawString("就诊卡号:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.m_strCardID,objFontNormal,Brushes.Black,X,Y);
			//流水号
			X=this.objDraw.PageBounds.Width*0.34f;
			objFontSize =objDraw.Graphics.MeasureString("流水号:",this.objFontNormal);
			objDraw.Graphics.DrawString("流水号:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width-2;
			objDraw.Graphics.DrawString(obj_VO.m_strRegisterID,objFontNormal,Brushes.Black,X,Y);
			//处方ID
			X=this.objDraw.PageBounds.Width*0.60f;
			objFontSize =objDraw.Graphics.MeasureString("处方编号:",this.objFontNormal);
			objDraw.Graphics.DrawString("处方编号:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width;
			objDraw.Graphics.DrawString(obj_VO.m_strRecipeID,objFontNormal,Brushes.Black,X,Y);
			//姓名
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			Y+=this.fltRowHeight;
			objFontSize =objDraw.Graphics.MeasureString("姓    名:",this.objFontNormal);
			objDraw.Graphics.DrawString("姓    名:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.m_strPatientName,objFontNormal,Brushes.Black,X,Y);
			//性别
			X=this.objDraw.PageBounds.Width*0.34f;
			objFontSize =objDraw.Graphics.MeasureString("性  别:",this.objFontNormal);
			objDraw.Graphics.DrawString("性  别:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width-2;
			objDraw.Graphics.DrawString(obj_VO.m_strSex,objFontNormal,Brushes.Black,X,Y);
			//处方ID
			X=this.objDraw.PageBounds.Width*0.60f;
			objFontSize =objDraw.Graphics.MeasureString("年    龄:",this.objFontNormal);
			objDraw.Graphics.DrawString("年    龄:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.m_strAge,objFontNormal,Brushes.Black,X,Y);
			//就诊科室
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			Y+=this.fltRowHeight;
			objFontSize =objDraw.Graphics.MeasureString("就诊科室:",this.objFontNormal);
			objDraw.Graphics.DrawString("就诊科室:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.m_strDiagDeptID,objFontNormal,Brushes.Black,X,Y);
			//诊疗医生
			X=this.objDraw.PageBounds.Width*0.34f;
			objFontSize =objDraw.Graphics.MeasureString("主医生:",this.objFontNormal);
			objDraw.Graphics.DrawString("主医生:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.m_strDiagDrName,objFontNormal,Brushes.Black,X,Y);
			//就诊时间
			X=this.objDraw.PageBounds.Width*0.60f;
			objFontSize =objDraw.Graphics.MeasureString("就诊时间:",this.objFontNormal);
			objDraw.Graphics.DrawString("就诊时间:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.m_strPrintDate,objFontNormal,Brushes.Black,X,Y);
			//画线
			Y+=this.fltRowHeight;
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			objDraw.Graphics.DrawLine(new Pen(Color.Black,2),X,Y,RX,Y);
			Y+=this.fltRowHeight/2;
			//项目分类名称
			//名称
			objDraw.Graphics.DrawString("项目名称",objFontNormal,Brushes.Black,X,Y);
			//单位
			X=this.objDraw.PageBounds.Width*0.34f;
			objDraw.Graphics.DrawString("单位",objFontNormal,Brushes.Black,X,Y);
			//总用量
			X=this.objDraw.PageBounds.Width*0.415f;
			objDraw.Graphics.DrawString("总量",objFontNormal,Brushes.Black,X,Y);
			//单价
			X=this.objDraw.PageBounds.Width*0.49f;
			objDraw.Graphics.DrawString("单价",objFontNormal,Brushes.Black,X,Y);
			//总价
			X=this.objDraw.PageBounds.Width*0.565f;
			objDraw.Graphics.DrawString("总价",objFontNormal,Brushes.Black,X,Y);
			//用法
			X=this.objDraw.PageBounds.Width*0.76f;
			objDraw.Graphics.DrawString("用法         药房",objFontNormal,Brushes.Black,X,Y);
			//画线
			Y+=this.fltRowHeight;
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			objDraw.Graphics.DrawLine(new Pen(Color.Black,1),X,Y,RX,Y);
		}
		#endregion
		#region 打印内容
		private void m_mthPrintText()
		{
			Y+=this.fltRowHeight/2;
			float X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
//			clsOutpatientPrintRecipeDetail_VO[] objArr=this.obj_VO.objPRDArr;
			clsOutpatientPrintRecipeDetail_VO[] objArr=null;
			if(objArr==null)
			{
				return;
			}
			for(int i=0;i<objArr.Length;i++)
			{
				if(objArr[i]==null)
				{
					continue;
				}
				X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
				objDraw.Graphics.DrawString(objArr[i].m_strChargeName,objFontNormal,Brushes.Black,X,Y);
				X=this.objDraw.PageBounds.Width*0.35f;
				objDraw.Graphics.DrawString(objArr[i].m_strUnit,objFontNormal,Brushes.Black,X,Y);
				X=this.objDraw.PageBounds.Width*0.425f;
				objDraw.Graphics.DrawString(objArr[i].m_strCount,objFontNormal,Brushes.Black,X,Y);
				X=this.objDraw.PageBounds.Width*0.48f;
				objDraw.Graphics.DrawString(objArr[i].m_strPrice,objFontNormal,Brushes.Black,X,Y);
				X=this.objDraw.PageBounds.Width*0.565f;
				objDraw.Graphics.DrawString(objArr[i].m_strSumPrice,objFontNormal,Brushes.Black,X,Y);
				X=this.objDraw.PageBounds.Width*0.66f;
				objDraw.Graphics.DrawString(objArr[i].m_strUsage,objFontNormal,Brushes.Black,X,Y);
				Y+=this.fltRowHeight;
			}

		
		}
		#endregion
		#region 打印页脚
		private void m_mthPrintEnd()
		{
			//画线
			Y=this.objDraw.PageBounds.Height*0.82f;
			float X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			float RX=this.objDraw.PageBounds.Width*(1-fltRightIndentProp);
			objDraw.Graphics.DrawLine(new Pen(Color.Black,2),X,Y,RX,Y);
			//盖章
			Y+=this.fltRowHeight/2;
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			SizeF objFontSize =objDraw.Graphics.MeasureString("自付金额:",this.objFontNormal);
			objDraw.Graphics.DrawString("自付金额:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.m_strSelfPay,objFontNormal,Brushes.Black,X,Y);
			X=this.objDraw.PageBounds.Width*0.34f;
			objFontSize =objDraw.Graphics.MeasureString("记账金额:",this.objFontNormal);
			objDraw.Graphics.DrawString("记账金额:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.m_strChargeUp,objFontNormal,Brushes.Black,X,Y);
			X=this.objDraw.PageBounds.Width*0.65f;
			objFontSize =objDraw.Graphics.MeasureString("总额:",this.objFontNormal);
			objDraw.Graphics.DrawString("总额:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.m_strRecipePrice,objFontNormal,Brushes.Black,X,Y);
			//画线
			Y+=this.fltRowHeight;
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			objDraw.Graphics.DrawLine(new Pen(Color.Black,1),X,Y,RX,Y);
			//盖章
			Y+=this.fltRowHeight/2;
			X=this.objDraw.PageBounds.Width*0.65f;
			objDraw.Graphics.DrawString(obj_VO.m_strHospitalName+"(盖章)",objFontNormal,Brushes.Black,X,Y);
			//画线
			Y+=this.fltRowHeight;
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			objDraw.Graphics.DrawLine(new Pen(Color.Black,1),X,Y,RX,Y);
			Y+=this.fltRowHeight/2;
			objFontSize =objDraw.Graphics.MeasureString("打印次数:",this.objFontNormal);
			objDraw.Graphics.DrawString("打印次数:",objFontNormal,Brushes.Black,X,Y);
			objDraw.Graphics.DrawString("次",objFontNormal,Brushes.Black,X+objFontSize.Width+15,Y);
			//操作员工号
			X=this.objDraw.PageBounds.Width*0.34f;
			objFontSize =objDraw.Graphics.MeasureString("打印员工号:",this.objFontNormal);
			objDraw.Graphics.DrawString("打印员工号:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.m_strRecordEmpID,objFontNormal,Brushes.Black,X,Y);
			//打印时间
			X=this.objDraw.PageBounds.Width*0.65f;
			objFontSize =objDraw.Graphics.MeasureString("打印时间:",this.objFontNormal);
			objDraw.Graphics.DrawString("打印时间:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(DateTime.Now.ToString("yyyy.MM.dd HH:mm"),objFontNormal,Brushes.Black,X,Y);
		}
		#endregion
		#region 开始打印
		public void m_mthBegionPrint()
		{
			this.m_mthPrintTitle();
			this.m_mthPrintText();
			this.m_mthPrintEnd();
		}
		#endregion
	}
}
