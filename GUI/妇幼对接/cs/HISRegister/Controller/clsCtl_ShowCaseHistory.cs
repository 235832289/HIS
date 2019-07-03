using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using System.Collections;
using System.Drawing;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsCtl_ShowCaseHistory 的摘要说明。
	/// </summary>
	public class clsCtl_ShowCaseHistory: com.digitalwave.GUI_Base.clsController_Base
	{
		private clsDcl_ShowReports objSvc=null;
		public clsCtl_ShowCaseHistory()
		{
			objSvc=new clsDcl_ShowReports();
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmShowCaseHistory m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmShowCaseHistory)frmMDI_Child_Base_in;
		}
		#endregion
		#region 加截病历信息
		public void m_mthLoadCaseHistoryInfo()
		{
			DataTable dt;
			long strRet =objSvc.m_mthGetCaseHistoryInfo3(this.m_objViewer.PatientID,out dt);
			string strHospitalName =this.m_objComInfo.m_strGetHospitalTitle();
			TreeNode tn;
			if(strRet>0&&dt.Rows.Count>0)
			{
				m_mthSetButtonEnable(true);
				string strCreatTime=DateTime.Parse(dt.Rows[0]["CREATDATE"].ToString()).ToString("yyyy年MM月dd日");
				tn =new TreeNode(strCreatTime);
				for(int i =0;i<dt.Rows.Count;i++)
				{
					clsOutpatientPrintCaseHis_VO obj_VO=new clsOutpatientPrintCaseHis_VO();
					obj_VO.m_strAge=this.m_objViewer.PatientAge;
					obj_VO.m_strCardID=this.m_objViewer.PatientCardID;
					obj_VO.m_strDiagDeptID=dt.Rows[i]["DEPTNAME_VCHR"].ToString().Trim();
					obj_VO.m_strDiagDrName=dt.Rows[i]["LASTNAME_VCHR"].ToString().Trim();
					obj_VO.m_strHospitalName=strHospitalName;
					obj_VO.m_strPatientName=this.m_objViewer.PatientName;
					obj_VO.m_strRecipeID=dt.Rows[i]["CASEHISID_CHR"].ToString().Trim();
					obj_VO.m_strRecordEmpID="";//员工ID
					obj_VO.m_strRegisterID=dt.Rows[i]["REGISTERID_CHR"].ToString().Trim();
					obj_VO.m_strPrintDate =dt.Rows[i]["MODIFYDATE_DAT"].ToString().Trim();
					obj_VO.m_strSex=this.m_objViewer.PatientSex;
					obj_VO.strAidCheck=dt.Rows[i]["AIDCHECK_VCHR"].ToString().Trim();
					obj_VO.strAnaPhyLaXis=dt.Rows[i]["ANAPHYLAXIS_VCHR"].ToString().Trim();
					obj_VO.strDiag=dt.Rows[i]["DIAG_VCHR"].ToString().Trim();
					obj_VO.strExamineResult=dt.Rows[i]["BODYCHECK_VCHR"].ToString().Trim();
					obj_VO.strDiagCurr=dt.Rows[i]["DIAGCURR_VCHR"].ToString().Trim();
					obj_VO.strDiagHis=dt.Rows[i]["DIAGHIS_VCHR"].ToString().Trim();
					obj_VO.strDiagMain=dt.Rows[i]["DIAGMAIN_VCHR"].ToString().Trim();
					obj_VO.strReMark=dt.Rows[i]["REMARK_VCHR"].ToString().Trim();
					obj_VO.strTreatMent=dt.Rows[i]["TREATMENT_VCHR"].ToString().Trim();
					obj_VO.m_strPRIHIS_VCHR=dt.Rows[i]["PRIHIS_VCHR"].ToString().Trim();
					obj_VO.strParentID=dt.Rows[i]["PARCASEHISID_CHR"].ToString().Trim();
					obj_VO.strChangeDeparement=dt.Rows[i]["CALDEPT_VCHR"].ToString().Trim();
					if(dt.Rows[i]["sign_grp"]!=System.DBNull.Value)
					{
						obj_VO.objDocImage =m_mthConvertByte2Image((byte[])dt.Rows[i]["sign_grp"]);
					}
					Color forColor =Color.Black;
					if(obj_VO.strParentID!="")
					{
						forColor =Color.Red;
					}
//					obj_VO.objItemArr =new ArrayList();
					string temp = DateTime.Parse(dt.Rows[i]["MODIFYDATE_DAT"].ToString()).ToString("yyyy年MM月dd日");
					if(strCreatTime ==temp)
					{
						TreeNode tnSub =new TreeNode(dt.Rows[i]["MODIFYDATE_DAT"].ToString().Trim());
						tnSub.Tag =obj_VO;
						tnSub.ForeColor=forColor;
						tn.Nodes.Add(tnSub);
					}
					else
					{
						this.m_objViewer.treeView1.Nodes.Add(tn);
						strCreatTime= temp;
						tn =new TreeNode(strCreatTime);
						TreeNode tnSub =new TreeNode(dt.Rows[i]["MODIFYDATE_DAT"].ToString().Trim());
						tnSub.Tag =obj_VO;
						tnSub.ForeColor=forColor;
						tn.Nodes.Add(tnSub);
						
					}

			
				}
			
				this.m_objViewer.treeView1.Nodes.Add(tn);
				this.m_objViewer.treeView1.Nodes[0].Expand();
				this.m_objViewer.treeView1.Nodes[0].TreeView.SelectedNode=this.m_objViewer.treeView1.Nodes[0].Nodes[0];
				this.m_objViewer.treeView1.Tag =	this.m_objViewer.treeView1.Nodes[0].Nodes[0].Tag;
				this.m_objViewer.treeView1.Focus();
				this.m_objViewer.treeView1.Select();
			}
			else
			{
				clsOutpatientPrintCaseHis_VO obj_VO=new clsOutpatientPrintCaseHis_VO();
				obj_VO.m_strAge="";
				obj_VO.m_strCardID="";
				obj_VO.m_strDiagDeptID="";
				obj_VO.m_strDiagDrName="";
				obj_VO.m_strHospitalName=strHospitalName;
				obj_VO.m_strPatientName="";
				obj_VO.m_strRecipeID="";
				obj_VO.m_strRecordEmpID="";//员工ID
				obj_VO.m_strRegisterID="";
				obj_VO.m_strPrintDate ="";
				obj_VO.m_strSex="";
				obj_VO.strAidCheck="";
				obj_VO.strAnaPhyLaXis="";
				obj_VO.strDiag="";
				obj_VO.strExamineResult="";
				obj_VO.strDiagCurr="";
				obj_VO.strDiagHis="";
				obj_VO.strDiagMain="";
				obj_VO.strReMark="";
				obj_VO.strTreatMent="";
				obj_VO.m_strPRIHIS_VCHR="";
				obj_VO.strParentID="";
				obj_VO.objItemArr =new ArrayList();
				obj_VO.objItemArr2 =new ArrayList();
				this.m_objViewer.treeView1.Tag =obj_VO;
				m_mthSetButtonEnable(false);
			}
		}
		#region byte转换为image
		private System.Drawing.Image m_mthConvertByte2Image(byte[] p_bytImage)
		{
			Image objImg = null;

			if(p_bytImage != null)
			{
				System.IO.MemoryStream objStream = new System.IO.MemoryStream((byte[])p_bytImage);

				objImg = new Bitmap(objStream);
			}
			return objImg;
		}
		#endregion	
		#endregion
		private void m_mthSetButtonEnable(bool b)
		{
			this.m_objViewer.btPrint.Enabled =b;
			this.m_objViewer.btReConsultation.Enabled =b;
			this.m_objViewer.btReUse.Enabled =b;

		}
		private clsPrintCaseHistory objPrintCaseHistory =null;
		public void m_mthBeginPrint()
		{
			if(this.m_objViewer.treeView1.Tag!=null)
			{
				clsOutpatientPrintCaseHis_VO obj_VO =this.m_objViewer.treeView1.Tag as clsOutpatientPrintCaseHis_VO;
				clsGetRecipeInfo.m_mthGetRecipeInfoByCaseHistoryID(obj_VO.m_strRecipeID,out obj_VO.objItemArr,out obj_VO.objItemArr2);
//				DataTable dt;
//				long ret =objSvc.m_mthGetRecipeInfoByCaseHistoryID(obj_VO.m_strRecipeID,out dt);
//				obj_VO.objItemArr=new ArrayList();
//				obj_VO.objItemArr2=new ArrayList();
//				if(ret>0&&dt.Rows.Count>0)
//				{
//					string strTempID =dt.Rows[0]["OUTPATRECIPEID_CHR"].ToString().Trim();
//					for(int i=0;i<dt.Rows.Count;i++)
//					{
//						if(dt.Rows[i]["SEQID_CHR"].ToString().Trim()=="1")
//						{
//							continue;
//						}
//						if(strTempID!=dt.Rows[i]["OUTPATRECIPEID_CHR"].ToString().Trim())
//						{
//							clsOutpatientPrintRecipeDetail_VO objSpilt =null;
//							
//							if(obj_VO.objItemArr.Count>0)
//							{
//								obj_VO.objItemArr.Add(objSpilt);
//							}
//							if(obj_VO.objItemArr2.Count>0)
//							{
//								obj_VO.objItemArr2.Add(objSpilt);
//							}
//							strTempID =dt.Rows[i]["OUTPATRECIPEID_CHR"].ToString().Trim();
//						}
//
//						clsOutpatientPrintRecipeDetail_VO objtemp=new clsOutpatientPrintRecipeDetail_VO();
//						objtemp.m_strChargeName=dt.Rows[i]["ITEMNAME"].ToString().Trim();
//						objtemp.m_strCount=dt.Rows[i]["QUANTITY"].ToString().Trim()+dt.Rows[i]["UNIT"].ToString().Trim();
//						objtemp.m_strPrice="";
//						objtemp.m_strSumPrice="";
//						objtemp.m_strUnit=dt.Rows[i]["UNIT"].ToString().Trim();
//						objtemp.m_strFrequency=dt.Rows[i]["FREQNAME_CHR"].ToString().Trim();
//						objtemp.m_strDosage=dt.Rows[i]["QTY_DEC"].ToString().Trim()+dt.Rows[i]["DOSAGEUNIT_CHR"].ToString().Trim();
//						objtemp.m_strDays=dt.Rows[i]["DAYS_INT"].ToString().Trim()+"天";
//						objtemp.m_strSpec=dt.Rows[i]["DEC"].ToString().Trim();
//						objtemp.m_strUsage=dt.Rows[i]["USAGENAME_VCHR"].ToString().Trim();
//						objtemp.m_strRowNo=dt.Rows[i]["ROWNO_CHR"].ToString().Trim();
//						if(dt.Rows[i]["SEQID_CHR"].ToString().Trim()=="2")
//						{
//							obj_VO.objItemArr2.Add(objtemp);
//						}
//						else
//						{
//							obj_VO.objItemArr.Add(objtemp);
//						}
//					}
//				}
				objPrintCaseHistory =new clsPrintCaseHistory(obj_VO);
			}
		}
		public void m_mthEndPrint()
		{
			objPrintCaseHistory =null;
		
		}
		public void m_mthPrint(System.Drawing.Printing.PrintPageEventArgs e)
		{
				objPrintCaseHistory.m_mthBegionPrint(e);
		}
	}
	#region 获取病历处方明细类
	public class clsGetRecipeInfo
	{
		public static void m_mthGetRecipeInfoByCaseHistoryID(string strID,out ArrayList a1,out ArrayList a2)
		{
			DataTable dt;
			clsDcl_ShowReports objSvc=new clsDcl_ShowReports();
			long ret =objSvc.m_mthGetRecipeInfoByCaseHistoryID(strID,out dt);
			a1=new ArrayList();
			a2=new ArrayList();
			if(ret>0&&dt.Rows.Count>0)
			{
				string strTempID =dt.Rows[0]["OUTPATRECIPEID_CHR"].ToString().Trim();
				for(int i=0;i<dt.Rows.Count;i++)
				{
					if(dt.Rows[i]["SEQID_CHR"].ToString().Trim()=="1")
					{
						continue;
					}
					if(strTempID!=dt.Rows[i]["OUTPATRECIPEID_CHR"].ToString().Trim())
					{
						clsOutpatientPrintRecipeDetail_VO objSpilt =null;
							
						if(a1.Count>0)
						{
							a1.Add(objSpilt);
						}
						if(a2.Count>0)
						{
							a2.Add(objSpilt);
						}
						strTempID =dt.Rows[i]["OUTPATRECIPEID_CHR"].ToString().Trim();
					}

					clsOutpatientPrintRecipeDetail_VO objtemp=new clsOutpatientPrintRecipeDetail_VO();
					objtemp.m_strChargeName=dt.Rows[i]["ITEMNAME"].ToString().Trim();
					objtemp.m_strCount=dt.Rows[i]["QUANTITY"].ToString().Trim()+dt.Rows[i]["UNIT"].ToString().Trim();
					objtemp.m_strPrice="";
					objtemp.m_strSumPrice="";
					objtemp.m_strUnit=dt.Rows[i]["UNIT"].ToString().Trim();
					objtemp.m_strFrequency=dt.Rows[i]["FREQNAME_CHR"].ToString().Trim();
					objtemp.m_strDosage=dt.Rows[i]["QTY_DEC"].ToString().Trim()+dt.Rows[i]["DOSAGEUNIT_CHR"].ToString().Trim();
					objtemp.m_strDays=dt.Rows[i]["DAYS_INT"].ToString().Trim()+"天";
					objtemp.m_strSpec=dt.Rows[i]["DEC"].ToString().Trim();
					objtemp.m_strUsage=dt.Rows[i]["USAGENAME_VCHR"].ToString().Trim();
					objtemp.m_strRowNo=dt.Rows[i]["ROWNO_CHR"].ToString().Trim();
					objtemp.m_strInvoiceCat = dt.Rows[i]["invtype"].ToString().Trim();
					if(dt.Rows[i]["SEQID_CHR"].ToString().Trim()=="2")
					{
						a2.Add(objtemp);
					}
					else
					{
						a1.Add(objtemp);
					}
				}
			}
		}
	}
	#endregion
}
