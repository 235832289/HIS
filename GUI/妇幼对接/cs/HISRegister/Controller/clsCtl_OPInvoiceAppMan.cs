using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 门诊发票管理
	/// 作者： 徐斌辉
	/// 时间： Aug 23, 2004
	/// </summary>
	public class clsCtl_OPInvoiceAppMan: com.digitalwave.GUI_Base.clsController_Base
	{
		#region 变量
		clsDcl_InvoiceManage m_objManage = null;
		public string m_strReportID;
		public string m_strOperatorID;
        /// <summary>
        /// 发票类型 0-普通发票(默认) 1-行政票据
        /// </summary>
        internal int intInvType = 0;
		#endregion 

		#region 构造函数
		public clsCtl_OPInvoiceAppMan()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_objManage = new clsDcl_InvoiceManage();
			m_strReportID = null;
			m_strOperatorID = "0000001";
		}
		#endregion 

		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmOPInvoiceAppMan m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmOPInvoiceAppMan)frmMDI_Child_Base_in;
		}
		#endregion

		#region 初始化 ListView
		/// <summary>
		/// 初始化 ListView [默认显示当天请领的发票]
		/// </summary>
		public void m_FillListView()
		{
			clsT_opr_opinvoiceman_VO[] objResultArr = null;
			//初始化默认显示当天请领发票的所有记录
			//m_objManage.m_lngGetApplyInvoice(System.DateTime.Now.ToShortDateString(),System.DateTime.Now.ToShortDateString(),"",out objResultArr);
            m_objManage.m_lngGetApplyInvoice("", "", "", intInvType, out objResultArr);
			if(objResultArr == null || objResultArr.Length == 0)
				return;
			
			ListViewItem lviTemp;
			int iTem = 0;
			m_objViewer.m_lstApplyInvoiceMan.Items.Clear();			
			for(int i1= 0 ;i1<objResultArr.Length;i1++)
			{				
				//发票请求流水号
				lviTemp = new ListViewItem(objResultArr[i1].m_strAPPUSERNAME_CHR);
				//请领标志
				//lviTemp.SubItems.Add("");
				//lviTemp.SubItems.Add(objResultArr[i1].m_strAPPUSERID_CHR);
				//开始发票号
				lviTemp.SubItems.Add(objResultArr[i1].m_strINVOICENOFROM_VCHR);
				//结束发票号
				lviTemp.SubItems.Add(objResultArr[i1].m_strINVOICENOTO_VCHR);
				//发票张数
				try
				{
					string intMin="";
					string intMax="";
					long lngRes =this.GetNumber(objResultArr[i1].m_strINVOICENOFROM_VCHR,objResultArr[i1].m_strINVOICENOTO_VCHR, out intMin,out intMax);
					int countint=Convert.ToInt32(intMax)-Convert.ToInt32(intMin);
					lviTemp.SubItems.Add(countint.ToString());
				}
				catch{}
				//操作人姓名
				//lviTemp.SubItems.Add(objResultArr[i1].m_strOPERATORNAME_CHR);
				//请领日期
				lviTemp.SubItems.Add(objResultArr[i1].m_strAPPLY_DAT);
				//作废人姓名
				lviTemp.SubItems.Add(objResultArr[i1].m_strCANCELUSERNAME_CHR);
				//作废时间
				lviTemp.SubItems.Add(objResultArr[i1].m_strCANCEL_DAT);
                if (objResultArr[i1].intInvoiceTypeFlag == 1)
                {
                    lviTemp.SubItems.Add("行政单位往来票据");
                }
                else if (objResultArr[i1].intInvoiceTypeFlag == 2)
                {
                    lviTemp.SubItems.Add("行政收费统一票据");
                }
                else
                {
                    lviTemp.SubItems.Add("普通发票");
                }
				lviTemp.Tag =objResultArr[i1].m_strAPPID_CHR;

				m_objViewer.m_lstApplyInvoiceMan.Items.Add(lviTemp);
			}
		}
		#endregion

		#region 根据工号获得职工名称
		/// <summary>
		/// 根据职工的工号求得职工的姓名
		/// </summary>
		public void m_GetEmployeeName()
		{
			//清空姓名TextBox
			m_objViewer.m_txtAPPUSERNAME_CHR.Text ="";

			if(m_objViewer.m_txtAPPUSERID_CHR.Text==null || m_objViewer.m_txtAPPUSERID_CHR.Text.Trim()=="")
				return;

			string strApplyName = "";
			m_objManage.m_lngGetEmployeeNameByNO(m_objViewer.m_txtAPPUSERID_CHR.Text.Trim(),out strApplyName);
			m_objViewer.m_txtAPPUSERNAME_CHR.Text =strApplyName;
		}
		#endregion 

		#region 求发票数目
		/// <summary>
		/// 求发票数目
		/// </summary>
		public void m_GetInvoiceNumber(string strMinNO,string strMaxNO)
		{
			if(strMinNO==""||strMaxNO=="")
				return;

			//清空发票张数TextBox
			m_objViewer.m_txtINVOICENUMBET_INT.Text ="";
			this.m_objViewer.label10.Text="";
			if(strMinNO.Length!=strMaxNO.Length)
			{
                this.m_objViewer.label10.Text="输入发票的长度不相等！";
				m_objViewer.m_txtINVOICENOTO_VCHR.Focus();
				return;
			}
			string  intMax = "0";
			string  intMin = "0";
			int intNumber=0;
			try
			{
				long lngRes =this.GetNumber(strMinNO,strMaxNO, out intMin,out intMax);
				if(lngRes!=-1&&intMin.Length==intMax.Length)
					intNumber =Convert.ToInt32(intMax) -Convert.ToInt32(intMin);
				else
				{
					this.m_objViewer.label10.Text="输入的发票号不在同一个区间上，\r\n开始发票号—结束发票号必需符合\r\n如下形式，如：WD100—WD500";
					m_objViewer.m_txtINVOICENOTO_VCHR.Focus();
					return;
				}

			}
			catch
			{				
				return;
			}

			m_objViewer.m_txtINVOICENUMBET_INT.Text =intNumber.ToString();
		}
		#endregion 
		/// <summary>
		/// 分解发票号
		/// </summary>
		/// <param name="text1"></param>
		/// <param name="text2"></param>
		/// <param name="number1"></param>
		/// <param name="number1"></param>
		/// <returns>返回-1表示输入的发票号不在同一个发票段上面</returns>
		private long GetNumber(string text1,string text2,out string number1,out string number2)
		{
			number1="";
			number2="";
			char[] chArr1 = text1.ToCharArray();
			char[] chArr2 = text2.ToCharArray();
			int val1 = 0;
			for(int i = chArr1.Length-1 ;i>=0;i--)
			{
				if(chArr1[i]>47&&chArr1[i]<58)
				{
					continue;
				}
				val1 = i;
				break;
			}
			int val2 = 0;
			for(int i1 = chArr2.Length-1 ;i1>=0;i1--)
			{
				if(chArr2[i1]>47&&chArr2[i1]<58)
				{
					continue;
				}
				val2 = i1;
				break;
			}
			if(val2!=val1)
			{
				return -1;//发票号不在同一个发票区间里面
			}
			else if(text1.Substring(0,val1)!=text2.Substring(0,val2))
			{
				return -1;//发票号不在同一个发票区间里面
			}
			if(val1>=text1.Length)
				number1="0";
			else if(val1 ==0)
				number1=text1.Substring(val1,text1.Length);
			else
				number1=text1.Substring(val1+1,text1.Length-val1-1);

			if(val2>=text2.Length)
				number2="0";
			else if(val2 ==0)
				number2=text2.Substring(val2,text2.Length);
			else
				number2=text2.Substring(val1+1,text2.Length-val2-1);
			return 1;
		}

		#region 添加请领发票
		#region 校验输入值
		/// <summary>
		/// 校验输入值
		/// </summary>
		/// <returns>返回验证结果</returns>
		private bool m_bolCheckValuePass()
		{
			bool bolReturn = true;
			string strReturn ="";
			if(m_objViewer.m_txtAPPUSERID_CHR.Text.Trim() == "")
			{
				strReturn += "工号不可少！\n";
				bolReturn = false;
			}
			else
			{
				if(m_objViewer.m_txtAPPUSERNAME_CHR.Text.Trim()=="")
				{
					strReturn += "工号输入错误！\n";
					bolReturn = false;
				}
			}
			if(m_objViewer.m_txtINVOICENOFROM_VCHR.Text.Trim() == "")
			{
				strReturn += "起始发票号不可少\n";
				bolReturn = false;
			}
			if(m_objViewer.m_txtINVOICENOTO_VCHR.Text.Trim() == "")
			{
				strReturn += "终止发票号不可少！\n";
				bolReturn = false;
			}
			if(m_objViewer.m_dtpAPPLY_DAT.Text.Trim() == "")
			{
				strReturn += "请领日期不可少！\n";
				bolReturn = false;
			}
			if(m_objViewer.m_txtINVOICENUMBET_INT.Text.Trim()=="" || Int32.Parse(m_objViewer.m_txtINVOICENUMBET_INT.Text.Trim())<=0)
			{
				strReturn += "发票张数必须大于0张！";
				bolReturn = false;
			}
			if(!bolReturn)
			{
				MessageBox.Show(m_objViewer,strReturn,"警 告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
			return bolReturn;
		}
		#endregion
		public void m_lngDoAddNewT_opr_opinvoiceman()
		{
			//入库验证
			if(!m_bolCheckValuePass())
				return;			

			//获取clsT_opr_opinvoiceman_VO
			clsT_opr_opinvoiceman_VO objResult = new clsT_opr_opinvoiceman_VO();
			string number1="";
			string number2="";
			long lngRes = this.GetNumber(m_objViewer.m_txtINVOICENOFROM_VCHR.Text.Trim(),m_objViewer.m_txtINVOICENOTO_VCHR.Text.Trim(),out number1,out number2);
            // kenny add
            string strH1 = System.Text.RegularExpressions.Regex.Replace(m_objViewer.m_txtINVOICENOFROM_VCHR.Text.Trim(), @"[^A-Za-z]*", "");
            string strH2 = System.Text.RegularExpressions.Regex.Replace(m_objViewer.m_txtINVOICENOTO_VCHR.Text.Trim(), @"[^A-Za-z]*", "");
            // --
            if ((lngRes == -1 || number1.Length != number2.Length) || strH1 != strH2)
			{
				MessageBox.Show("输入的发票号不在同一个区间上，\n开始发票号—结束发票号必需符合如下形式，\n如：WD100—WD500","Icare",MessageBoxButtons.OK,MessageBoxIcon.Stop);
				return;
			}
				objResult.m_strINVOICENOFROM_VCHR=m_objViewer.m_txtINVOICENOFROM_VCHR.Text;
			objResult.m_strINVOICENOTO_VCHR = m_objViewer.m_txtINVOICENOTO_VCHR.Text;
			objResult.m_strAPPLY_DAT = m_objViewer.m_dtpAPPLY_DAT.Value.ToString("yyyy-MM-dd HH:mm:ss");
			//获取职工流水号
			string  strID ="";
			lngRes =m_objManage.m_lngGetEmployeeIDByNO(m_objViewer.m_txtAPPUSERID_CHR.Text,out strID);
			objResult.m_strAPPUSERID_CHR = strID;
			objResult.m_strOPERATORID_CHR = m_strOperatorID;
            objResult.intInvoiceTypeFlag = this.intInvType;

			//验证是否发票区间被领取了
			bool blnIsUsed =true;
            long iResult = m_objManage.m_lngCheckInvoiceNOIsUsed(objResult.m_strINVOICENOFROM_VCHR, objResult.m_strINVOICENOTO_VCHR, objResult.intInvoiceTypeFlag, out blnIsUsed);
			if(iResult<=0)
			{	
				MessageBox.Show(m_objViewer,"请领失败!","错误提示框",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			if(blnIsUsed )
			{
				MessageBox.Show(m_objViewer,"此发票期间内有部分发票已经有人请领了，请领失败！","警 告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			//入库
			string strAppid_chr = "";
			iResult =m_objManage.m_lngDoAddNewT_opr_opinvoiceman(objResult,out strAppid_chr);
			if(iResult<=0)
			{
				MessageBox.Show(m_objViewer,"请领失败!","错误提示框",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			else
			{
				MessageBox.Show(m_objViewer,"请领成功!","提示框",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			
			//在ListView中添加一行
			string strTem = "";
			int iTem =0;			
			//请领人姓名
			m_objManage.m_lngGetEmployeeNameByID(objResult.m_strAPPUSERID_CHR.Trim(),out strTem);
			ListViewItem lviTemp = new ListViewItem(strTem);
			//请领标志
			//lviTemp.SubItems.Add("");
			//lviTemp.SubItems.Add(objResultArr[i1].m_strAPPUSERID_CHR);
			//开始发票号
			lviTemp.SubItems.Add(objResult.m_strINVOICENOFROM_VCHR);
			//结束发票号
			lviTemp.SubItems.Add(objResult.m_strINVOICENOTO_VCHR);
			//发票张数
			iTem = System.Convert.ToInt32(this.m_objViewer.m_txtINVOICENUMBET_INT.Text);
			lviTemp.SubItems.Add(iTem.ToString()) ;
			//操作人姓名
			//m_objManage.m_lngGetEmployeeNameByID(objResult.m_strOPERATORID_CHR.Trim(),out strTem);
			//lviTemp.SubItems.Add(strTem);
			//请领日期
			lviTemp.SubItems.Add(objResult.m_strAPPLY_DAT);
			m_objViewer.m_lstApplyInvoiceMan.Items.Add(lviTemp);	
			//作废人姓名
			lviTemp.SubItems.Add("");
			//作废时间
			lviTemp.SubItems.Add("");
            if (objResult.intInvoiceTypeFlag == 1)
            {
                lviTemp.SubItems.Add("行政单位往来票据");
            }
            else if (objResult.intInvoiceTypeFlag == 2)
            {
                lviTemp.SubItems.Add("行政收费统一票据");
            }
            else
            {
                lviTemp.SubItems.Add("普通发票");
            }
			lviTemp.Tag =strAppid_chr;
			//清空
			m_EmptyInput();
		}
		#endregion

		#region 作废当前记录
		public void m_lngModifyT_opr_opinvoiceman()
		{
			//没有选中，则返回；
			int iTem =m_objViewer.m_lstApplyInvoiceMan.SelectedItems.Count;
			if( iTem == 0)
				return;
			clsT_opr_opinvoiceman_VO objResult = new clsT_opr_opinvoiceman_VO();
			
			//提示用户确认作废操作　［［如果只选中多行，那么在这里提示］］
			if(iTem>1)
			{
				DialogResult result;
				result = MessageBox.Show(m_objViewer, "确定要作废选中行的发票吗？", "提示框",MessageBoxButtons.YesNo,MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
				if(result == DialogResult.No)
				{
					return;
				}
			}

			bool blnIsUsed;
			for(int i1=0;i1< iTem;i1++)
			{
				//作废的发票请求流水号
				objResult.m_strAPPID_CHR =m_objViewer.m_lstApplyInvoiceMan.SelectedItems[i1].Tag.ToString();
				//作废人ID
				objResult.m_strCANCELUSERID_CHR =m_strOperatorID;

				//检查是否已经是作废了    [已经作废的发票将不再做作废操作]
				blnIsUsed =true;
				m_objManage.m_lngCheckInvoiceNOIsCancel(objResult.m_strAPPID_CHR,out blnIsUsed);
				if(!blnIsUsed)
				{
					//提示用户确认作废操作　［如果只选中一行，那么在这里提示］
					if(iTem==1)
					{
						DialogResult result;
						result = MessageBox.Show(m_objViewer, "确定要作废选中行的发票吗？", "提示框",MessageBoxButtons.YesNo,MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
						if(result == DialogResult.No)
						{
							return;
						}
					}

					long iReturn = m_objManage.m_lngModifyT_opr_opinvoiceman(objResult);
					if(iReturn<=0)
					{
						MessageBox.Show(m_objViewer,"操作失败!","错误提示框",MessageBoxButtons.OK,MessageBoxIcon.Error);
						return;
					}
			
					//修改当前ListView选中行
					//修改作废人
					string strTem="";
					m_objManage.m_lngGetEmployeeNameByID(m_strOperatorID.Trim(),out strTem);
					m_objViewer.m_lstApplyInvoiceMan.SelectedItems[i1].SubItems[5].Text =strTem;
					//修改作废时间
					m_objViewer.m_lstApplyInvoiceMan.SelectedItems[i1].SubItems[6].Text =System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				}
			}
		}
		#endregion

		#region 查询请领发票
		/// <summary>
		/// 查询请领发票
		/// </summary>
		public void m_lngGetApplyInvoice()
		{
			//清空 ListView
			m_objViewer.m_lstApplyInvoiceMan.Items.Clear();	

			clsT_opr_opinvoiceman_VO[] objResultArr = null;
			//初始化默认显示当天请领发票的所有记录
			string strStartAPPLY_DAT = m_objViewer.m_dtpStartAPPLY_DAT.Value.ToString("yyyy-MM-dd");// HH:mm:ss
			string strEndAPPLY_DAT = m_objViewer.m_dtpEndAPPLY_DAT.Value.ToString("yyyy-MM-dd");
			string  strID ="";
			long lngRes =m_objManage.m_lngGetEmployeeIDByNO(m_objViewer.m_txtAPPUSERID_CHR2.Text,out strID);
			if(m_objViewer.m_txtAPPUSERID_CHR2.Text!=string.Empty && strID==string.Empty)
			{
				strID ="~!!&^$)(_@";
			}
            m_objManage.m_lngGetApplyInvoice(strStartAPPLY_DAT, strEndAPPLY_DAT, strID, intInvType, out objResultArr);
			if(objResultArr == null || objResultArr.Length == 0)
				return;
			
			ListViewItem lviTemp;
			int iTem = 0;					
			for(int i1= 0 ;i1<objResultArr.Length;i1++)
			{	
				//请领人姓名
				lviTemp = new ListViewItem(objResultArr[i1].m_strAPPUSERNAME_CHR);
				//请领标志
				//lviTemp.SubItems.Add("");
				//lviTemp.SubItems.Add(objResultArr[i1].m_strAPPUSERID_CHR);
				//开始发票号
				lviTemp.SubItems.Add(objResultArr[i1].m_strINVOICENOFROM_VCHR);
				//结束发票号
				lviTemp.SubItems.Add(objResultArr[i1].m_strINVOICENOTO_VCHR);
				//发票张数
				try
				{
                    iTem = System.Convert.ToInt32(System.Text.RegularExpressions.Regex.Replace(objResultArr[i1].m_strINVOICENOTO_VCHR, @"^[A-Za-z]*", "")) - System.Convert.ToInt32(System.Text.RegularExpressions.Regex.Replace(objResultArr[i1].m_strINVOICENOFROM_VCHR, @"^[A-Za-z]*", ""));
				}
				catch{}
				lviTemp.SubItems.Add(iTem.ToString()) ;
				//操作人姓名
				//lviTemp.SubItems.Add(objResultArr[i1].m_strOPERATORNAME_CHR);
				//请领日期
				lviTemp.SubItems.Add(objResultArr[i1].m_strAPPLY_DAT);
				//作废人姓名
				lviTemp.SubItems.Add(objResultArr[i1].m_strCANCELUSERNAME_CHR);
				//作废时间
				lviTemp.SubItems.Add(objResultArr[i1].m_strCANCEL_DAT);
                if (objResultArr[i1].intInvoiceTypeFlag == 1)
                {
                    lviTemp.SubItems.Add("行政单位往来票据");
                }
                else if (objResultArr[i1].intInvoiceTypeFlag == 2)
                {
                    lviTemp.SubItems.Add("行政收费统一票据");
                }
                else
                {
                    lviTemp.SubItems.Add("普通发票");
                }
				lviTemp.Tag =objResultArr[i1].m_strAPPID_CHR;

				m_objViewer.m_lstApplyInvoiceMan.Items.Add(lviTemp);
			}
		}
		#endregion

		#region 清空
		public void m_EmptyInput()
		{
			m_objViewer.m_txtAPPUSERID_CHR.Text ="";
			m_objViewer.m_txtAPPUSERNAME_CHR.Text ="";
			m_objViewer.m_dtpAPPLY_DAT.Value =System.DateTime.Now;
			m_objViewer.m_txtINVOICENOFROM_VCHR.Text ="";
			m_objViewer.m_txtINVOICENOTO_VCHR.Text ="";
			m_objViewer.m_txtINVOICENUMBET_INT.Text ="";
		}	
		#endregion 
	}
}
