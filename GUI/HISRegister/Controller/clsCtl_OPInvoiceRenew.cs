using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.HI;
using System.Data;
using System.Collections.Generic;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 门诊发票退回
	/// 作者： 徐斌辉
	/// 创建时间： Aug 26, 2004
	/// </summary>
	public class clsCtl_OPInvoiceRenew: com.digitalwave.GUI_Base.clsController_Base
	{
		#region 变量
		clsDcl_InvoiceManage m_objManage = null;
		public string m_strReportID;
		public string m_strOperatorID;
		#endregion 

		#region 构造函数
		public clsCtl_OPInvoiceRenew()
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
		com.digitalwave.iCare.gui.HIS.frmOPInvoiceRenew m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmOPInvoiceRenew)frmMDI_Child_Base_in;
		}
		#endregion

		#region 恢复发票
		/// <summary>
		/// 恢复发票
		/// </summary>
		public void m_ResumeTicket()
		{
			//如果发票号为空则返回
			if(m_objViewer.txtInvoice.Text.Trim()=="")
			{
				MessageBox.Show(m_objViewer,"发票号不正，或此发票不是退票！","错误提示框",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			if(this.m_objViewer.LoginInfo!=null)
			{
				m_strOperatorID=this.m_objViewer.LoginInfo.m_strEmpID;
			}
			//验证发票是否存在
			clsT_opr_outpatientrecipeinv_VO objResult = null;
			long lngRet = m_objManage.m_lngGetInfoByNoForResume(m_objViewer.txtInvoice.Text.Trim(),out objResult);
			if(lngRet<=0)
			{
				//退票失败！
				MessageBox.Show(m_objViewer,"恢复失败!","错误提示框",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return ;
			}
			if(objResult ==null || objResult.m_intSTATUS_INT != 2)//发票状态  [发票状态：1-有效、0-作废、2-退票]
			{
				//发票不是已经退的发票，恢复失败！
				MessageBox.Show(m_objViewer,"此发票不是退票，恢复失败!","错误提示框",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			//发票未审核,不能退票
			DataTable dt;
			lngRet =m_objManage.m_mthGetInvoiceAuditingInfo(m_objViewer.txtInvoice.Text.Trim(),out dt,2);
			if(dt.Rows.Count==0)
			{
				//发票未审核,不能退票
				MessageBox.Show(m_objViewer,"发票未审核,不能恢复!","错误提示框",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
            //发票如果含有药品，不能退票
            bool blContains=false;
            lngRet = m_objManage.m_CheckIsContainMed(m_objViewer.txtInvoice.Text.Trim(),ref blContains);
            if (lngRet <= 0)
            {
                MessageBox.Show(m_objViewer, "恢复失败!", "错误提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (blContains)
                {
                    MessageBox.Show(m_objViewer, "发票含有药品，不能恢复", "错误提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            string Seqid = "";
			lngRet = m_objManage.m_lngResumeTicket(m_objViewer.txtInvoice.Text.Trim(),m_strOperatorID, ref Seqid);
			if(lngRet<=0)
			{
				//退票失败！
				MessageBox.Show(m_objViewer,"恢复失败！","错误提示框",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return ;
			}
			else
			{
				//退票成功！
				MessageBox.Show(m_objViewer,"发票恢复成功！","提示框",MessageBoxButtons.OK,MessageBoxIcon.Information);
				if(IsPrintInvoice)
				{
                    this.m_objViewer.Cursor = Cursors.WaitCursor;
                    clsCalcPatientCharge objCalPatientCharge = new clsCalcPatientCharge(this.m_objComInfo.m_strGetHospitalTitle());
                    objCalPatientCharge.m_mthReprintinvoice(Seqid, this.m_objViewer.LoginInfo.m_strEmpID, 2);
                    this.m_objViewer.Cursor = Cursors.Default;
				}
			}
			//清空发票号
			m_EmptyInput();
		}
		#endregion 

		#region 根据发票号显示物理号
		public void DisplaySeqNo()
		{
//			m_objViewer.m_txtSEQID_CHR.Text ="";
//
//			//如果发票号为空则返回
//			if(m_objViewer.m_txtINVOICENO_VCHR.Text.Trim()=="")
//				return;
//
//			clsT_opr_outpatientrecipeinv_VO objResult = null;
//			long lngRet = m_objManage.m_lngGetInfoByNoForResume(m_objViewer.m_txtINVOICENO_VCHR.Text.Trim(),out objResult);
//			if(lngRet>0 && objResult.m_strSEQID_CHR!=null)
//			{
//				m_objViewer.m_txtSEQID_CHR.Text = objResult.m_strSEQID_CHR;
//			}
		}
		#endregion

		#region 根据物理号显示发票号
		public void DisplayInvoiceNo()
		{
			m_objViewer.txtInvoice.Text="";

//			//如果物理号为空则返回
//			if(m_objViewer.m_txtSEQID_CHR.Text.Trim()=="")
//				return;
//
//			clsT_opr_outpatientrecipeinv_VO objResult = null;
//			long lngRet = m_objManage.m_lngGetInfoBySeqidForResume(m_objViewer.m_txtSEQID_CHR.Text.Trim(),out objResult);
//			if(lngRet>0 && objResult.m_strINVOICENO_VCHR!=null)
//			{
//				m_objViewer.m_txtINVOICENO_VCHR.Text = objResult.m_strINVOICENO_VCHR;
//			}
		}
		#endregion 

		#region 显示发票信息
		public void m_DisplayInvoiceInfo()
		{
			//没有发票号则，不显示发票——返回
			if(m_objViewer.txtInvoice.Text.ToString().Trim()=="" )
			{
				MessageBox.Show("请选择发票号","提示");
				return;
			}
			DataTable dt;
			m_objManage.m_mthGetInvoiceAuditingInfo(m_objViewer.txtInvoice.Text.Trim(),out dt,2);
			if(dt.Rows.Count>0)
			{
				this.m_objViewer.lbeAuding.Text ="审核人:"+dt.Rows[0]["LASTNAME_VCHR"].ToString().Trim();
			}
			else
			{
				this.m_objViewer.lbeAuding.Text ="未审核";
			}
			m_mthShowInfoByInvoiceNO(m_objViewer.txtInvoice.Text.Trim());
		}
		#endregion 

		#region 清空
		public void m_EmptyInput()
		{
			this.m_objViewer.txtCardID.Clear();
			this.m_objViewer.txtInvoice.Text="";
			this.m_objViewer.m_repInvoiceInfo.ReportSource=null;
			this.m_objViewer.m_lstItemsInfo.Items.Clear();
			this.m_objViewer.txtCardID.Focus();
			this.m_objViewer.lbeAuding.Text ="";
		}
		#endregion 
		#region 根据卡号查出发票号
		public void m_mthFindInvoiceByCardID()
		{
			if(this.m_objViewer.txtCardID.Text.Trim()=="")
			{
				return ;			
			}
			DataTable dt;
			long lngRet = m_objManage.m_mthFindInvoiceByCardID(m_objViewer.txtCardID.Text.Trim(),out dt,2,this.m_objViewer.cmbFind.SelectedIndex);
			this.m_objViewer.listView1.Items.Clear();
			if(dt.Rows.Count==0)
			{
			return;
			}
			if(dt.Rows.Count==1)
			{
				this.m_objViewer.txtInvoice.Text=dt.Rows[0]["SEQID_CHR"].ToString().Trim();
				this.m_objViewer.txtInvoice.Focus();
				//在这里加入调用发票号的代码
			}
			else
			{
				ListViewItem lv;
				for(int i=0;i<dt.Rows.Count;i++)
				{
					lv=new ListViewItem(dt.Rows[i]["INVOICENO_VCHR"].ToString().Trim());
					lv.SubItems.Add(dt.Rows[i]["SEQID_CHR"].ToString().Trim());
					this.m_objViewer.listView1.Items.Add(lv);
                        					
				}
				this.m_objViewer.listView1.Show();
				this.m_objViewer.listView1.BringToFront();
				this.m_objViewer.listView1.Items[0].Selected=true;
				this.m_objViewer.listView1.Focus();
									
			}
		}
		#endregion
		#region 根据发票号显示信息
		private clsPatientChargeCal objPC;
		private void m_mthShowInfoByInvoiceNO(string strInvoiceNO)
		{
			clsCalcPatientCharge objCalcPatienCharge =null;
            objCalcPatienCharge = new clsCalcPatientCharge("", "", 1, this.m_objComInfo.m_strGetHospitalTitle(), 0, 100);
             int setValue = clsPublic.m_intGetSysParm("0320");
             //显示发票明细信息
             objCalcPatienCharge.m_mthGetChargeItemByInvoiceID(strInvoiceNO, m_objViewer.m_lstItemsInfo, "2");
             if (setValue == 0)
             {
                 //显示发票信息			
                 m_objViewer.m_repInvoiceInfo.ReportSource = objCalcPatienCharge.m_mthPrintChargePreview(strInvoiceNO, "2", out objPC);
                 if (objPC.Reprintprninfo.Trim() != "")
                     objPC.Reprintprninfo = "*REPEAT(" + objPC.Reprintprninfo + ")*";
                 m_objViewer.dwInvoice.Visible = false;
             }
             else
             {
                 objCalcPatienCharge.m_mthPrintChargePreview(strInvoiceNO, "2", out objPC);

                 DataTable chargeType = null;
                 DataTable computation = null;
                 if (objPC.Reprintprninfo.Trim() == "")
                     m_objManage.m_lngChargeItemTypeByInvoice(objPC.m_strInvoiceNO, out chargeType);
                 else
                     m_objManage.m_lngChargeItemTypeByInvoice(objPC.Reprintprninfo, out chargeType);
                 if (objPC.Reprintprninfo.Trim() != "")
                     objPC.Reprintprninfo = "*REPEAT(" + objPC.Reprintprninfo + ")*";
                 m_objManage.m_lngComputationByScope("8", out computation);
                

                 m_objViewer.dwInvoice.LibraryList = Application.StartupPath + "\\pb_Invioce.pbl";
                 m_objViewer.dwInvoice.DataWindowObject = "d_op_invoice_prt_new";
                 m_objViewer.dwInvoice.SetRedrawOff();
                 m_objViewer.dwInvoice.Reset();
                 m_objViewer.dwInvoice.InsertRow(0);


                 List<String> arryText = clsNewInvoicPrint.s_arryGetInvoiceInfo(objPC, objCalcPatienCharge.ObjMain.m_mthCreatDataTable(objPC), chargeType, computation,-1);
                 foreach (String text in arryText)
                 {
                     m_objViewer.dwInvoice.Modify(text);
                 }

                 m_objViewer.dwInvoice.Visible = true;
             }
		}
		#endregion
		#region 是否打印发票
		private bool IsPrintInvoice=false;
		public void m_mthIsPrintInvoice()
		{
			clsDcl_OPCharge objTemp =new clsDcl_OPCharge();
			IsPrintInvoice =objTemp.m_mthIsCanDo("0006")==1;
		}
		#endregion
		#region 审核
		public void m_mthAudingInvoice()
		{
			//验证发票是否存在
			clsT_opr_outpatientrecipeinv_VO objResult = null;
			long lngRet = m_objManage.m_lngGetInfoByNoForResume(m_objViewer.txtInvoice.Text.Trim(),out objResult);
			if(objResult ==null || objResult.m_intSTATUS_INT != 2)
			{
				//发票不是有效的发票，退票失败！
				MessageBox.Show(m_objViewer,"此发票不是有效的发票!","错误提示框",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			frmAudingInvoice frmObj =new frmAudingInvoice(m_objViewer.txtInvoice.Text.Trim(),"2");
			frmObj.DataServer =this.m_objManage;
			if(frmObj.ShowDialog()==DialogResult.OK)
			{
				this.m_objViewer.lbeAuding.Text ="审核人:"+frmObj.AudingName;
			}
		}
		#endregion
	}
}
