using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
using com.digitalwave.controls.datagrid;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsControlConcertreCipe 的摘要说明。
	/// </summary>
	public class clsControlConcertreCipe : com.digitalwave.GUI_Base.clsController_Base
	{
		public clsControlConcertreCipe()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_objDoMain=new clsDomainConrol_ConcertreCipe();
			
		}
		private clsDcl_OPCharge objSvc=new clsDcl_OPCharge();
		clsDomainConrol_ConcertreCipe m_objDoMain=null;
		clsDomainControl_Register clsDomain = new clsDomainControl_Register();
		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmConcertrecipe m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmConcertrecipe)frmMDI_Child_Base_in;
		}
		#endregion

		public clsConcertrectpe_VO[] m_clsSConcertrectpe_VO;
		public clsConcertrecipeDetail_VO[] m_clsSConcertrecipeDetail_VO;
		public clsConcertrecipeDept_VO[] m_clsSConcertrecipeDept_VO;
		public clsConcertrectpe_VO[] m_clsMConcertrectpe_VO = new clsConcertrectpe_VO[0];
		public clsConcertrecipeDetail_VO[] m_clsMConcertrecipeDetail_VO = new clsConcertrecipeDetail_VO[0];
		public clsConcertrecipeDept_VO[] m_clsMConcertrecipeDept_VO = new clsConcertrecipeDept_VO[0];
		public string m_strCiptID = "";
		
		#region 获取协定处方
		/// <summary>
		/// 获取协定处方
		/// </summary>
		public void m_lngGetConcertreCipeByEmpID()
		{
			clsConcertrectpe_VO[] objVO = m_clsSConcertrectpe_VO;
			if(objVO.Length > 0) return;
			string strEmployID="0000001";
			if(this.m_objViewer.LoginInfo!=null)
			{
			strEmployID=this.m_objViewer.LoginInfo.m_strEmpID;
			}
			m_objDoMain.m_lngGetConcertreCipeByEmpID(strEmployID,out objVO);
			for(int i=0;i<objVO.Length;i++)
			{
				string strPRIVILEGE = "";
				switch(objVO[i].m_intPRIVILEGE_INT)
				{
					case 0:
						strPRIVILEGE = "公用";
						break;
					case 1:
						strPRIVILEGE = "私用";
						break;
					case 2:
						strPRIVILEGE = "科室";
						break;
				}
				this.m_objViewer.m_dtgConcertrecipe.m_mthAppendRow(new object[] {objVO[i].m_strRECIPEID_CHR,
				objVO[i].m_strRECIPENAME_CHR,strPRIVILEGE,objVO[i].m_strUSERCODE_CHR,objVO[i].m_strWBCODE_CHR,objVO[i].m_strPYCODE_CHR,
				objVO[i].m_strCREATERID_CHR,objVO[i].clsEmployee_VO.m_strLASTNAME_VCHR,objVO[i].m_intSTATUS_INT});
			}
			if(objVO.Length >0)
			{
				this.m_objViewer.m_dtgConcertrecipe.CurrentCell = new DataGridCell(0,1);
			}
			m_clsSConcertrectpe_VO = objVO;
			this.m_intCipeCount = m_clsSConcertrectpe_VO.Length;
		}
		#endregion

		#region 获取协定处方明细
		/// <summary>
		/// 获取协定处方明细
		/// </summary>
		public void m_lngGetConcertreCipeDetailByID()
		{
			clsConcertrecipeDetail_VO[] objVO = m_clsSConcertrecipeDetail_VO;
			this.m_objViewer.m_dtgConcertrecipeDetail.m_mthDeleteAllRow();
			if(objVO.Length > 0) 
			{
				for(int i=0;i<objVO.Length;i++)
				{
					if(objVO[i].m_strRECIPEID_CHR == this.m_strCiptID)
					{
						string strCat = this.m_mthConvertToChType(objVO[i].m_clsChargeItem_VO.m_strINSURANCEID_CHR);
						
						this.m_objViewer.m_dtgConcertrecipeDetail.m_mthAppendRow(new object[] {objVO[i].m_strRECIPEID_CHR,objVO[i].m_strDETAILID_CHR,objVO[i].m_strITEMID_CHR,objVO[i].m_clsChargeItem_VO.m_strItemName,objVO[i].m_strQTY_DEC
																							  ,strCat
																							  ,objVO[i].m_clsChargeItem_VO.m_strItemSpec
																							  ,objVO[i].m_clsChargeItem_VO.m_strItemCode
																							  ,objVO[i].m_strUsageName
																							  ,objVO[i].m_strUsageID
																							  ,objVO[i].m_strFrequencyName
																							  ,objVO[i].m_strFrequencyID
																							  ,objVO[i].m_clsChargeItem_VO.m_fltItemPrice
																							  ,objVO[i].m_clsChargeItem_VO.m_fltItemPrice*m_mthConvertToFloat(objVO[i].m_strQTY_DEC)});
						
					}
				}
				this.m_sumMoney();
				return;
			}
			string strEmployID="0000001";
			if(this.m_objViewer.LoginInfo!=null)
			{
				strEmployID=this.m_objViewer.LoginInfo.m_strEmpID;
			}
			m_objDoMain.m_lngGetConcertreCipeDetailByID(strEmployID,out objVO);
			for(int i=0;i<objVO.Length;i++)
			{
				if(objVO[i].m_strRECIPEID_CHR == this.m_strCiptID)
				{
					this.m_objViewer.m_dtgConcertrecipeDetail.m_mthAppendRow(new object[] {objVO[i].m_strRECIPEID_CHR,objVO[i].m_strDETAILID_CHR,objVO[i].m_strITEMID_CHR,objVO[i].m_clsChargeItem_VO.m_strItemName,objVO[i].m_strQTY_DEC});
				}
			}
			m_clsSConcertrecipeDetail_VO= objVO;
			this.m_sumMoney();
			
		}
		#endregion
		#region 转换为浮点型
		private float m_mthConvertToFloat(object obj)
		{
			float i=0;
			if(obj==null)
			{
			return 0;
			}
			try
			{
			i=float.Parse(obj.ToString());
			}
			catch
			{
			i=0;
			}
			return i;
		}
		#endregion
		#region 获取使用部门
		/// <summary>
		/// 获取协定处方明细
		/// </summary>
		public void m_lngGetConcertreCipeDeptByID()
		{
			clsConcertrecipeDept_VO[] objVO = m_clsSConcertrecipeDept_VO;
			if(objVO.Length > 0) 
			{
				this.m_objViewer.m_lsvDept.Items.Clear();
				for(int i=0;i<objVO.Length;i++)
				{
					if(objVO[i].m_strRECIPEID_CHR == this.m_strCiptID)
					{
						ListViewItem lvw1 = new ListViewItem();
						lvw1.Text=objVO[i].m_clsDepart_VO.m_strDEPTNAME_VCHR;
						lvw1.Tag = (object)objVO[i];
						this.m_objViewer.m_lsvDept.Items.Add(lvw1);
					}
				}
				return;
			}
			string strEmployID="0000001";
			if(this.m_objViewer.LoginInfo!=null)
			{
				strEmployID=this.m_objViewer.LoginInfo.m_strEmpID;
			}
			m_objDoMain.m_lngGetConcertreCipeDeptByID(strEmployID,out objVO);
			for(int i=0;i<objVO.Length;i++)
			{
				if(objVO[i].m_strRECIPEID_CHR == this.m_strCiptID)
				{
					ListViewItem lvw = new ListViewItem();
					lvw.Text=objVO[i].m_clsDepart_VO.m_strDEPTNAME_VCHR;
					lvw.Tag = (object)objVO[i];
					this.m_objViewer.m_lsvDept.Items.Add(lvw);
				}
			}
			m_clsSConcertrecipeDept_VO = objVO;
		}
		#endregion

		#region 新增处方
		/// <summary>
		/// 新增处方
		/// </summary>
		public void m_lngAddNewConcertreCipe()
		{
			for(int i=this.m_intCipeCount;i<m_objViewer.m_dtgConcertrecipe.RowCount;i++)
			{
				if(this.m_objViewer.m_dtgConcertrecipe[i,1].ToString().Trim() == ""
					|| this.m_objViewer.m_dtgConcertrecipe[i,2].ToString().Trim() == "")
				{
					this.m_objViewer.m_dtgConcertrecipe.m_mthDeleteRow(i);
					i--;
					continue;
				}
				int intPRIVILEGE = 0;
				switch(m_objViewer.m_dtgConcertrecipe[i,"PRIVILEGE_INT"].ToString().Trim())
				{
					case "公用":
						intPRIVILEGE = 0;
						break;
					case "私用":
						intPRIVILEGE = 1;
						break;
					case "科室":
						intPRIVILEGE = 2;
						
						break;
					default:
						intPRIVILEGE = 1;
						break;
				}
				clsConcertrectpe_VO objVO = new clsConcertrectpe_VO();
				objVO.m_strRECIPEID_CHR = m_objViewer.m_dtgConcertrecipe[i,"RECIPEID_CHR"].ToString().Trim();
				objVO.m_strRECIPENAME_CHR = m_objViewer.m_dtgConcertrecipe[i,"RECIPENAME_CHR"].ToString().Trim();
				objVO.m_intPRIVILEGE_INT = intPRIVILEGE;
				objVO.m_strUSERCODE_CHR = m_objViewer.m_dtgConcertrecipe[i,"USERCODE_CHR"].ToString().Trim();
				objVO.m_strWBCODE_CHR = m_objViewer.m_dtgConcertrecipe[i,"WBCODE_CHR"].ToString().Trim();
				objVO.m_strPYCODE_CHR = m_objViewer.m_dtgConcertrecipe[i,"PYCODE_CHR"].ToString().Trim();
				objVO.m_intSTATUS_INT = 1;
				objVO.m_strCREATERID_CHR = m_objViewer.m_dtgConcertrecipe[i,"CREATERID_CHR"].ToString().Trim();
				objVO.clsEmployee_VO.m_strLASTNAME_VCHR = m_objViewer.m_dtgConcertrecipe[i,"CREATERNAME_VCHR"].ToString().Trim();
				long lngarg = m_objDoMain.m_lngAddNewConcertreCipe(out objVO.m_strRECIPEID_CHR,objVO);
				if(lngarg == 0)
				{
					if(MessageBox.Show("第"+Convert.ToString(i+1)+"行保存不成功！\n是否要修改？按“是”修改，“否”删除！","提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
					{
						this.m_objViewer.m_dtgConcertrecipe.m_mthSelectARow(i);
						return;
					}
					else
					{
						this.m_objViewer.m_dtgConcertrecipe.m_mthDeleteRow(i);
						i--;
						continue;
					}
				}
				this.m_objViewer.m_dtgConcertrecipe[i,0] = objVO.m_strRECIPEID_CHR;
				int length = this.m_clsSConcertrectpe_VO.Length;
				clsConcertrectpe_VO[] objTempVO = new clsConcertrectpe_VO[length+1];
				this.m_clsSConcertrectpe_VO.CopyTo(objTempVO,0);
				objTempVO[length] = new clsConcertrectpe_VO();
				this.m_strCiptID = objTempVO[length].m_strRECIPEID_CHR = objVO.m_strRECIPEID_CHR;
				objTempVO[length].m_strRECIPENAME_CHR = m_objViewer.m_dtgConcertrecipe[i,"RECIPENAME_CHR"].ToString().Trim();
				objTempVO[length].m_intPRIVILEGE_INT = intPRIVILEGE;
				objTempVO[length].m_strUSERCODE_CHR = m_objViewer.m_dtgConcertrecipe[i,"USERCODE_CHR"].ToString().Trim();
				objTempVO[length].m_strWBCODE_CHR = m_objViewer.m_dtgConcertrecipe[i,"WBCODE_CHR"].ToString().Trim();
				objTempVO[length].m_strPYCODE_CHR = m_objViewer.m_dtgConcertrecipe[i,"PYCODE_CHR"].ToString().Trim();
				objTempVO[length].m_intSTATUS_INT = 1;
				objTempVO[length].m_strCREATERID_CHR = m_objViewer.m_dtgConcertrecipe[i,"CREATERID_CHR"].ToString().Trim();
				objTempVO[length].clsEmployee_VO.m_strLASTNAME_VCHR = m_objViewer.m_dtgConcertrecipe[i,"CREATERNAME_VCHR"].ToString().Trim();
				this.m_clsSConcertrectpe_VO = objTempVO;	
				this.m_intCipeCount++;
			}

		}
		#endregion

		#region 新增处方明细
		/// <summary>
		/// 新增处方明细
		/// </summary>
		public void m_lngAddNewConcertreCipeDetail()
		{
			if(this.m_objViewer.m_dtgConcertrecipeDetail.RowCount>0)
			this.m_objViewer.m_dtgConcertrecipeDetail.CurrentCell = new DataGridCell(0,0);
			for(int i=0;i<m_objViewer.m_dtgConcertrecipeDetail.RowCount;i++)
			{
				if(this.m_objViewer.m_dtgConcertrecipeDetail[i,3].ToString().Trim() == ""
					|| this.m_objViewer.m_dtgConcertrecipeDetail[i,4].ToString().Trim() == "")
				{
					this.m_objViewer.m_dtgConcertrecipeDetail.m_mthDeleteRow(i);
					i--;
					continue;
				}
				if( m_objViewer.m_dtgConcertrecipeDetail[i,"DETAILID_CHR"] == Convert.DBNull)
				{
					clsConcertrecipeDetail_VO objVO = new clsConcertrecipeDetail_VO();			
					objVO.m_strRECIPEID_CHR = this.m_strCiptID;
					objVO.m_strDETAILID_CHR = m_objViewer.m_dtgConcertrecipeDetail[i,"DETAILID_CHR"].ToString().Trim();
					objVO.m_strITEMID_CHR = m_objViewer.m_dtgConcertrecipeDetail[i,"ITEMID_CHR"].ToString().Trim();
					objVO.m_strQTY_DEC = m_objViewer.m_dtgConcertrecipeDetail[i,"QTY_DEC"].ToString().Trim();
					objVO.m_strUsageID = m_objViewer.m_dtgConcertrecipeDetail[i,9].ToString().Trim();
					objVO.m_strFrequencyID = m_objViewer.m_dtgConcertrecipeDetail[i,11].ToString().Trim();
					objVO.m_clsChargeItem_VO.m_strItemName = m_objViewer.m_dtgConcertrecipeDetail[i,"ITEMNAME_VCHR"].ToString().Trim();
					long lngarg = m_objDoMain.m_lngAddNewConcertreCipeDetail(out objVO.m_strDETAILID_CHR,objVO);
					if(lngarg == 0)
					{
						if(MessageBox.Show("第"+Convert.ToString(i+1)+"行保存不成功！\n是否要修改？按“是”修改，“否”删除！","提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
						{
							this.m_objViewer.m_dtgConcertrecipeDetail.m_mthSelectARow(i);
							
							break;
						}
						else
						{
							this.m_objViewer.m_dtgConcertrecipeDetail.m_mthDeleteRow(i);
							i--;
							continue;
						}
					}
					this.m_objViewer.m_dtgConcertrecipeDetail[i,0] = this.m_strCiptID;
					this.m_objViewer.m_dtgConcertrecipeDetail[i,1] = objVO.m_strDETAILID_CHR;
					int length = this.m_clsSConcertrecipeDetail_VO.Length;
					clsConcertrecipeDetail_VO[] objTempVO = new clsConcertrecipeDetail_VO[length+1];
					this.m_clsSConcertrecipeDetail_VO.CopyTo(objTempVO,0);
					objTempVO[length] = new clsConcertrecipeDetail_VO();
					objTempVO[length].m_strDETAILID_CHR = objVO.m_strDETAILID_CHR;
					objTempVO[length].m_strRECIPEID_CHR = this.m_strCiptID;					
					objTempVO[length].m_strITEMID_CHR = m_objViewer.m_dtgConcertrecipeDetail[i,"ITEMID_CHR"].ToString().Trim();
					objTempVO[length].m_strQTY_DEC = m_objViewer.m_dtgConcertrecipeDetail[i,"QTY_DEC"].ToString().Trim();
					objTempVO[length].m_clsChargeItem_VO.m_strItemName = m_objViewer.m_dtgConcertrecipeDetail[i,"ITEMNAME_VCHR"].ToString().Trim();
					objTempVO[length].m_clsChargeItem_VO.m_strINSURANCEID_CHR = m_objViewer.m_dtgConcertrecipeDetail[i,5].ToString().Trim();
					objTempVO[length].m_clsChargeItem_VO.m_strItemSpec = m_objViewer.m_dtgConcertrecipeDetail[i,6].ToString().Trim();
					objTempVO[length].m_clsChargeItem_VO.m_strItemCode = m_objViewer.m_dtgConcertrecipeDetail[i,7].ToString().Trim();
//					objTempVO[length].m_clsChargeItem_VO.m_fltItemPrice = float.Parse(m_objViewer.m_dtgConcertrecipeDetail[i,8].ToString().Trim());
					objTempVO[length].m_clsChargeItem_VO.m_fltItemPrice =float.Parse(m_objViewer.m_dtgConcertrecipeDetail[i,12].ToString().Trim());
					objTempVO[length].m_strUsageID =m_objViewer.m_dtgConcertrecipeDetail[i,9].ToString().Trim();
					objTempVO[length].m_strUsageName =m_objViewer.m_dtgConcertrecipeDetail[i,8].ToString().Trim();
					objTempVO[length].m_strFrequencyID =m_objViewer.m_dtgConcertrecipeDetail[i,11].ToString().Trim();
					objTempVO[length].m_strFrequencyName =m_objViewer.m_dtgConcertrecipeDetail[i,10].ToString().Trim();
					this.m_clsSConcertrecipeDetail_VO = objTempVO;
				}
			}
			this.m_sumMoney();
		}
		#endregion

		#region 新增使用部门
		/// <summary>
		/// 新增使用部门
		/// </summary>
		public void m_lngAddNewConcertreCipeDept()
		{
			if(!this.m_objViewer.m_txtDept.Enabled || this.m_objViewer.m_txtDept.Tag == null) return;

			clsConcertrecipeDept_VO objVO = new clsConcertrecipeDept_VO();
			objVO.m_strDEPTID_CHR = this.m_objViewer.m_txtDept.Tag.ToString();
			objVO.m_strRECIPEID_CHR = this.m_strCiptID;
			long lngarg = m_objDoMain.m_lngAddNewConcertreCipeDept(objVO);
			if(lngarg == 0)
			{
				return;
			}
		
			ListViewItem lvw = new ListViewItem();
			lvw.Text = this.m_objViewer.m_txtDept.Text;
			lvw.Tag = (object)objVO;
			this.m_objViewer.m_lsvDept.Items.Add(lvw);
			int length = this.m_clsSConcertrecipeDept_VO.Length;
			clsConcertrecipeDept_VO[] objTempVO = new clsConcertrecipeDept_VO[length+1];
			this.m_clsSConcertrecipeDept_VO.CopyTo(objTempVO,0);
			objTempVO[length] = new clsConcertrecipeDept_VO();
			objTempVO[length].m_strDEPTID_CHR = this.m_objViewer.m_txtDept.Tag.ToString();
			objTempVO[length].m_strRECIPEID_CHR = this.m_strCiptID;
			this.m_clsSConcertrecipeDept_VO = objTempVO;
			this.m_objViewer.m_txtDept.Text = "";
			this.m_objViewer.m_txtDept.Focus();
		}
		#endregion

		#region 修改协定处方
		/// <summary>
		/// 修改协定处方
		/// </summary>
		public void m_lngConcertreCipeModify()
		{
			
			for(int i=0;i<this.m_clsMConcertrectpe_VO.Length;i++)
			{
				for(int i1=0;i1<this.m_objViewer.m_dtgConcertrecipe.RowCount;i1++)
				{
					if(m_clsMConcertrectpe_VO[i].m_strRECIPEID_CHR == 
						this.m_objViewer.m_dtgConcertrecipe[i1,0].ToString())
					{
						int intPRIVILEGE = 0;
						switch(m_objViewer.m_dtgConcertrecipe[i1,"PRIVILEGE_INT"].ToString().Trim())
						{
							case "公用":
								intPRIVILEGE = 0;
								break;
							case "私用":
								intPRIVILEGE = 1;
								break;
							case "科室":
								intPRIVILEGE = 2;
						
								break;
						}
						m_clsMConcertrectpe_VO[i].m_strRECIPEID_CHR = m_objViewer.m_dtgConcertrecipe[i1,"RECIPEID_CHR"].ToString().Trim();
						m_clsMConcertrectpe_VO[i].m_strRECIPENAME_CHR = m_objViewer.m_dtgConcertrecipe[i1,"RECIPENAME_CHR"].ToString().Trim();
						m_clsMConcertrectpe_VO[i].m_intPRIVILEGE_INT = intPRIVILEGE;
						m_clsMConcertrectpe_VO[i].m_strUSERCODE_CHR = m_objViewer.m_dtgConcertrecipe[i1,"USERCODE_CHR"].ToString().Trim();
						m_clsMConcertrectpe_VO[i].m_strWBCODE_CHR = m_objViewer.m_dtgConcertrecipe[i1,"WBCODE_CHR"].ToString().Trim();
						m_clsMConcertrectpe_VO[i].m_strPYCODE_CHR = m_objViewer.m_dtgConcertrecipe[i1,"PYCODE_CHR"].ToString().Trim();
						m_clsMConcertrectpe_VO[i].m_intSTATUS_INT = 1;
						m_clsMConcertrectpe_VO[i].m_strCREATERID_CHR = m_objViewer.m_dtgConcertrecipe[i1,"CREATERID_CHR"].ToString().Trim();
						m_clsMConcertrectpe_VO[i].clsEmployee_VO.m_strLASTNAME_VCHR = m_objViewer.m_dtgConcertrecipe[i1,"CREATERNAME_VCHR"].ToString().Trim();
					}
					long lngarg = m_objDoMain.m_lngConcertreCipeModify(m_clsMConcertrectpe_VO[i]);				
				}
			}
			if(this.m_clsMConcertrectpe_VO.Length>0)
			{
				this.m_clsMConcertrectpe_VO = new clsConcertrectpe_VO[0];
			}
		}
		#endregion

		#region 修改协定处方明细
		/// <summary>
		/// 修改协定处方明细
		/// </summary>
		public void m_lngConcertreCipeDetailModify()
		{
			for(int i=0;i<this.m_clsMConcertrecipeDetail_VO.Length;i++)
			{
				for(int i1=0;i1<this.m_objViewer.m_dtgConcertrecipeDetail.RowCount;i1++)
				{
					if(m_clsMConcertrecipeDetail_VO[i].m_strDETAILID_CHR == 
						this.m_objViewer.m_dtgConcertrecipeDetail[i1,1].ToString()
						&& m_clsMConcertrecipeDetail_VO[i].m_strRECIPEID_CHR == 
						this.m_objViewer.m_dtgConcertrecipeDetail[i1,0].ToString())
					{
						m_clsMConcertrecipeDetail_VO[i].m_strDETAILID_CHR =  m_objViewer.m_dtgConcertrecipeDetail[i1,"DETAILID_CHR"].ToString().Trim();
						m_clsMConcertrecipeDetail_VO[i].m_strRECIPEID_CHR = this.m_strCiptID;					
						m_clsMConcertrecipeDetail_VO[i].m_strITEMID_CHR = m_objViewer.m_dtgConcertrecipeDetail[i1,"ITEMID_CHR"].ToString().Trim();
						m_clsMConcertrecipeDetail_VO[i].m_strQTY_DEC = m_objViewer.m_dtgConcertrecipeDetail[i1,"QTY_DEC"].ToString().Trim();
						m_clsMConcertrecipeDetail_VO[i].m_clsChargeItem_VO.m_strItemName = m_objViewer.m_dtgConcertrecipeDetail[i1,"ITEMNAME_VCHR"].ToString().Trim();	
						m_clsMConcertrecipeDetail_VO[i].m_strUsageID = m_objViewer.m_dtgConcertrecipeDetail[i1,9].ToString().Trim();	
						m_clsMConcertrecipeDetail_VO[i].m_strFrequencyID = m_objViewer.m_dtgConcertrecipeDetail[i1,11].ToString().Trim();
						
					}
				}
				long lngarg = m_objDoMain.m_lngConcertreCipeDetailModify(m_clsMConcertrecipeDetail_VO[i]);
			}
			if(this.m_clsMConcertrecipeDetail_VO.Length>0)
			{
				this.m_clsMConcertrecipeDetail_VO = new clsConcertrecipeDetail_VO[0];
				this.m_clsSConcertrecipeDetail_VO = new clsConcertrecipeDetail_VO[0];
			}
		}
		#endregion

		#region 删除协定处方明细
		/// <summary>
		/// 删除协定处方明细
		/// </summary>
		public void m_lngDeleteConcertrecipeDetail()
		{
			clsConcertrecipeDetail_VO objVO = new clsConcertrecipeDetail_VO();
			objVO.m_strRECIPEID_CHR = this.m_strCiptID;
			objVO.m_strDETAILID_CHR = this.m_objViewer.m_dtgConcertrecipeDetail[this.m_objViewer.m_dtgConcertrecipeDetail.CurrentCell.RowNumber,1].ToString();
			long lngarg = this.m_objDoMain.m_lngDeleteConcertrecipeDetail(objVO);
			this.m_objViewer.m_dtgConcertrecipeDetail.m_mthDeleteRow(this.m_objViewer.m_dtgConcertrecipeDetail.CurrentCell.RowNumber);
			this.m_clsSConcertrecipeDetail_VO = new clsConcertrecipeDetail_VO[0];
		}
		#endregion
		
		private int m_intCipeCount = 0;
		#region 删除协定处方
		/// <summary>
		/// 删除协定处方
		/// </summary>
		public void m_lngDeleteConcertrecipe()
		{
			int index = this.m_objViewer.m_dtgConcertrecipe.CurrentCell.RowNumber;
			for(int i=0;i<this.m_objViewer.m_dtgConcertrecipeDetail.RowCount;i++)
			{
				clsConcertrecipeDetail_VO objVO = new clsConcertrecipeDetail_VO();
				objVO.m_strRECIPEID_CHR = this.m_strCiptID;
				objVO.m_strDETAILID_CHR = this.m_objViewer.m_dtgConcertrecipeDetail[i,1].ToString();
				long lngarg = this.m_objDoMain.m_lngDeleteConcertrecipeDetail(objVO);
				this.m_objViewer.m_dtgConcertrecipeDetail.m_mthDeleteRow(i);
				i--;
			}
			for(int i1=0;i1<this.m_objViewer.m_lsvDept.Items.Count;i1++)
			{
				clsConcertrecipeDept_VO objVO = new clsConcertrecipeDept_VO();
				objVO.m_strDEPTID_CHR = ((clsConcertrecipeDept_VO)this.m_objViewer.m_lsvDept.Items[i1].Tag).m_strDEPTID_CHR;
				objVO.m_strRECIPEID_CHR = ((clsConcertrecipeDept_VO)this.m_objViewer.m_lsvDept.Items[i1].Tag).m_strRECIPEID_CHR;
				long lngarg = this.m_objDoMain.m_lngDeleteConcertrecipeDept(objVO);
				this.m_objViewer.m_lsvDept.Items[i1].Remove();
				i1--;
			}
			clsConcertrectpe_VO objoVO = new clsConcertrectpe_VO();
			objoVO.m_strRECIPEID_CHR = this.m_strCiptID;
			long lngoarg = this.m_objDoMain.m_lngDeleteConcertrecipe(objoVO);
			if(lngoarg>0)
			{
				this.m_objViewer.m_dtgConcertrecipe.m_mthDeleteRow(this.m_objViewer.m_dtgConcertrecipe.CurrentCell.RowNumber);
				m_intCipeCount--;
			}
		}
		#endregion

		#region 删除使用部门
		/// <summary>
		/// 删除使用部门
		/// </summary>
		public void m_lngDeleteConcertrecipeDept()
		{
			if(this.m_objViewer.m_lsvDept.SelectedItems.Count == 0) return;
			clsConcertrecipeDept_VO objVO = new clsConcertrecipeDept_VO();
			objVO.m_strDEPTID_CHR = ((clsConcertrecipeDept_VO)this.m_objViewer.m_lsvDept.SelectedItems[0].Tag).m_strDEPTID_CHR;
			objVO.m_strRECIPEID_CHR = ((clsConcertrecipeDept_VO)this.m_objViewer.m_lsvDept.SelectedItems[0].Tag).m_strRECIPEID_CHR;
			long lngarg = this.m_objDoMain.m_lngDeleteConcertrecipeDept(objVO);
			this.m_objViewer.m_lsvDept.SelectedItems[0].Remove();
			this.m_clsSConcertrecipeDept_VO = new clsConcertrecipeDept_VO[0];
		}
		#endregion

		public void m_ClearCipe()
		{
			this.m_clsSConcertrectpe_VO = new clsConcertrectpe_VO[0];
			this.m_objViewer.m_dtgConcertrecipe.m_mthDeleteAllRow();
		}
		public void m_ClearDetail()
		{
			this.m_clsSConcertrecipeDetail_VO = new clsConcertrecipeDetail_VO[0];
			this.m_objViewer.m_dtgConcertrecipeDetail.m_mthDeleteAllRow();
		}
		public void m_ClearDept()
		{
			this.m_clsSConcertrecipeDept_VO = new clsConcertrecipeDept_VO[0];
			this.m_objViewer.m_lsvDept.Items.Clear();
		}
		#region 显示科室
		public void m_ShowDept(object sender)
		{			
//			this.m_objViewer.m_pnlDept.Left=((TextBox)sender).Left;
//			this.m_objViewer.m_pnlDept.Top= ((TextBox)sender).Top-this.m_objViewer.m_pnlDept.Height;
			
			this.m_objViewer.m_pnlDept.Visible=true;
			//this.m_pnlAllPlan.BringToFront();
//			this.m_objViewer.Controls.Add(this.m_objViewer.m_pnlDept);
			this.m_objViewer.m_pnlDept.Tag = ((TextBox)sender).Name;
			this.m_objViewer.m_pnlDept.Controls.Add(this.m_objViewer.m_lsvSelectDept);
			this.m_objViewer.m_pnlDept.Width = 164;
			this.m_objViewer.m_pnlDept.BringToFront();
		}
		#endregion

		public void FillDept()
		{
			if(this.m_objViewer.m_lsvSelectDept.Columns.Count >0)
				return;
			clsDepartmentVO[] objResultArr=new clsDepartmentVO[0];
			this.m_objViewer.m_lsvSelectDept.Columns.Clear();
			this.m_objViewer.m_lsvSelectDept.Columns.Add("",50,HorizontalAlignment.Left);
			this.m_objViewer.m_lsvSelectDept.Columns.Add("科室名称",150,HorizontalAlignment.Left);
			this.m_objViewer.m_lsvSelectDept.Columns.Add("拼音码",70,HorizontalAlignment.Left);
			this.m_objViewer.m_lsvSelectDept.ResumeLayout(false);
			this.m_objViewer.m_lsvSelectDept.Items.Clear();
			
			long lngRes = 0;
			if(objResultArr == null || objResultArr.Length == 0)
			{
				lngRes = clsDomain.m_lngGetPlanDepByDate("","",out objResultArr);
			}
			else
			{
				lngRes=1;
			}
			if((lngRes>0)&&(objResultArr != null))
			{
				if (objResultArr.Length > 0)
				{
					ListViewItem lvw=null;
					for(int i1=0; i1<objResultArr.Length;i1++)
					{
						lvw=new ListViewItem(objResultArr[i1].strShortNo);
						lvw.SubItems.Add(objResultArr[i1].strDeptName);
						lvw.SubItems.Add(objResultArr[i1].strPYCode);
						lvw.Tag=objResultArr[i1];
						m_objViewer.m_lsvSelectDept.Items.Add(lvw);
					}
				}
			}
			try
			{
				this.m_objViewer.m_lsvSelectDept.Items[0].Selected = true;
			}
			catch{}
		}

		public void m_txtDeptKeyDown(object sender)
		{
			
				if(!this.m_objViewer.m_pnlDept.Visible)
				{
					if(this.m_objViewer.m_txtDept.Text.Trim() != "")
					{
						if(this.m_FindLvw(this.m_objViewer.m_txtDept.Text.Trim())==0)
						{
							this.m_ShowDept((object)this.m_objViewer.m_txtDept);
						}
						else
						{
							this.m_objViewer.m_pnlDept.Visible = false;
							this.m_objViewer.m_btnSaveDept.Focus();
						}
					}
					
					return;
				}
				if(m_objViewer.m_lsvSelectDept.Items.Count !=0 && this.m_objViewer.m_pnlDept.Visible == true)
				{
					if(!this.FilltxtByDoc())
					{
						this.m_objViewer.m_btnSaveDept.Focus();
						return;
					}
				}
				else if(m_objViewer.m_lsvSelectDept.Items.Count ==0)
				{
					((TextBox)sender).Text = "";
				}
				this.m_objViewer.m_pnlDept.Visible = false;
				this.m_objViewer.m_btnSaveDept.Focus();			
		}
		public void m_locklsv(System.Windows.Forms.KeyEventArgs e)
		{
			int index = 0;
			for(int i=0;i<this.m_objViewer.m_lsvSelectDept.Items.Count;i++)
			{
				if(this.m_objViewer.m_lsvSelectDept.Items[i].Selected)
				{
					index = i;
				}
			}
			this.m_UpDown(index,e,(object)this.m_objViewer.m_lsvSelectDept);
		}
		public void m_UpDown(int index,System.Windows.Forms.KeyEventArgs e,object sender)
		{
			if(((ListView)sender).Items.Count>0)
			{
				if(index == ((ListView)sender).Items.Count-1 && e.KeyCode == Keys.Down)
				{
					((ListView)sender).Items[index].Selected = false;
					((ListView)sender).Items[0].Selected = true;
					((ListView)sender).Items[0].EnsureVisible();
				}
				if(index == 0 && e.KeyCode == Keys.Up)
				{
					((ListView)sender).Items[0].Selected = false;
					((ListView)sender).Items[((ListView)sender).Items.Count-1].Selected = true;
					((ListView)sender).Items[((ListView)sender).Items.Count-1].EnsureVisible();
				}
				if(index>0 && index<=((ListView)sender).Items.Count-1 && e.KeyCode == Keys.Up)
				{
					((ListView)sender).Items[index].Selected = false;
					((ListView)sender).Items[index-1].Selected = true;
					((ListView)sender).Items[index-1].EnsureVisible();
				}
				if(index>=0 && index<((ListView)sender).Items.Count-1 && e.KeyCode == Keys.Down)
				{
					((ListView)sender).Items[index].Selected = false;
					((ListView)sender).Items[index+1].Selected = true;
					((ListView)sender).Items[index+1].EnsureVisible();
				}
			}
		}

		public long m_FindLvw(string strValues)
		{
			for(int i = 0;i<this.m_objViewer.m_lsvSelectDept.Items.Count;i++)
			{
				if(this.m_objViewer.m_lsvSelectDept.Items[i].SubItems[0].Text.IndexOf(strValues)>=0
					|| this.m_objViewer.m_lsvSelectDept.Items[i].SubItems[1].Text.IndexOf(strValues)>=0)
				{
					this.m_objViewer.m_lsvSelectDept.Items[i].Selected = true;
				}
				else
				{
					this.m_objViewer.m_lsvSelectDept.Items[i].Selected = false;
				}
				if(this.m_objViewer.m_lsvSelectDept.Items[i].SubItems[0].Text.Trim() == strValues.Trim()
					|| this.m_objViewer.m_lsvSelectDept.Items[i].SubItems[1].Text.Trim() == strValues.Trim())
				{
					this.m_objViewer.m_lsvSelectDept.Items[i].Selected = true;
					this.m_objViewer.m_txtDept.Tag=((clsDepartmentVO)this.m_objViewer.m_lsvSelectDept.Items[i].Tag).strDeptID;
					this.m_objViewer.m_txtDept.Text=((clsDepartmentVO)this.m_objViewer.m_lsvSelectDept.Items[i].Tag).strDeptName;
					this.m_objViewer.m_pnlDept.Visible = false;
					
					return 1;
				}
			}
			return 0;
		}
		private bool FilltxtByDoc()
		{
			long lngRes=0;
			if(this.m_objViewer.m_lsvSelectDept.SelectedItems.Count == 0) return false;
			clsOPDoctorPlan_VO objResult=new clsOPDoctorPlan_VO();
			
			this.m_objViewer.m_txtDept.Text=((clsDepartmentVO)this.m_objViewer.m_lsvSelectDept.SelectedItems[0].Tag).strDeptName;
			this.m_objViewer.m_txtDept.Tag=((clsDepartmentVO)this.m_objViewer.m_lsvSelectDept.SelectedItems[0].Tag).strDeptID;
			this.m_objViewer.m_pnlDept.Visible = false;
			
			return true;
		}
		public void m_mthFindMedicineByID(string strType,string ID)
		{
			System.Data.DataTable dt=null;
			long strRet=objSvc.m_mthFindMedicineByID(strType,ID,"0001",out dt,"");
			if(strRet>0&&dt.Rows.Count>0)
			{
				
				if(dt.Rows.Count==1)
				{
					int row =m_objViewer.m_dtgConcertrecipeDetail.CurrentCell.RowNumber;
					m_objViewer.m_dtgConcertrecipeDetail[row,3]=dt.Rows[0]["ITEMNAME_VCHR"].ToString().Trim();
					m_objViewer.m_dtgConcertrecipeDetail[row,2]=dt.Rows[0]["ITEMID_CHR"].ToString().Trim();
					m_objViewer.m_dtgConcertrecipeDetail[row,4]=0;
					m_objViewer.m_dtgConcertrecipeDetail[row,5]=m_mthConvertToChType(dt.Rows[0]["ITEMCATID_CHR"].ToString().Trim());//类型
					m_objViewer.m_dtgConcertrecipeDetail[row,6]=dt.Rows[0]["ITEMSPEC_VCHR"].ToString().Trim();//规格
					m_objViewer.m_dtgConcertrecipeDetail[row,7]=dt.Rows[0]["ITEMOPUNIT_CHR"].ToString().Trim();//单位

					m_objViewer.m_dtgConcertrecipeDetail[row,12]=dt.Rows[0]["ITEMPRICE_MNY"].ToString().Trim();//单价
						m_objViewer.m_dtgConcertrecipeDetail.CurrentCell=new DataGridCell(row,4);
					m_objViewer.m_dtgConcertrecipeDetail[row,3]=dt.Rows[0]["ITEMNAME_VCHR"].ToString().Trim();
					//直接填充datagrid
				}
				else
				{
					m_objViewer.m_lsvCharge.Items.Clear();
					for(int i=0;i<dt.Rows.Count;i++)
					{
						ListViewItem lv =new ListViewItem(dt.Rows[i]["ITEMID_CHR"].ToString().Trim());//项目ID
						lv.SubItems.Add(dt.Rows[i]["type"].ToString().Trim());//查询码
						lv.SubItems.Add(dt.Rows[i]["ITEMNAME_VCHR"].ToString().Trim());//名称
						lv.SubItems.Add(m_mthConvertToChType(dt.Rows[i]["ITEMCATID_CHR"].ToString().Trim()));//类型
						lv.SubItems.Add(dt.Rows[i]["ITEMSPEC_VCHR"].ToString().Trim());//规格
						lv.SubItems.Add(dt.Rows[i]["ITEMOPUNIT_CHR"].ToString().Trim());//单位
						lv.SubItems.Add(dt.Rows[i]["ITEMPRICE_MNY"].ToString().Trim());//单价
						m_objViewer.m_lsvCharge.Items.Add(lv);
					}
					//m_objViewer.m_pnlCharge.Height=175;
//					m_objViewer.m_pnlCharge.Visible=true;
					m_objViewer.m_lsvCharge.Height=140;
					m_objViewer.m_lsvCharge.Visible=true;
					m_objViewer.m_lsvCharge.Items[0].Selected=true;
					m_objViewer.m_lsvCharge.Select();
					m_objViewer.m_lsvCharge.Focus();
					//填充listView
				}
			}
			else
			{
				MessageBox.Show("对不起！找不到任何收费项目。","ICare",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
				((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.m_dtgConcertrecipeDetail.Columns[2] ).DataGridTextBoxColumn.TextBox.SelectAll();
			}

		}
		private string m_mthConvertToChType(string strTypeNo)
		{
			string strRet="西药";
			switch(strTypeNo)
			{
				case "0002":
					strRet="中药";
					break;
				case "0003":
					strRet="检验";
					break;
				case "0004":
					strRet="治疗";
					break;
				case "0005":
					strRet="其他";
					break;
				case "0006":
					strRet="手术";
					break;
				default:
					strRet="西药";
					break;
			}
			return strRet;
		}
		public void m_mthListViewDoubleClick()
		{
			
			if(m_objViewer.m_lsvCharge.SelectedItems.Count>0||m_objViewer.m_lsvCharge.SelectedItems[0].ForeColor!=System.Drawing.Color.Red)
			{
				int row =m_objViewer.m_dtgConcertrecipeDetail.CurrentCell.RowNumber;
				for(int i=0;i<this.m_objViewer.m_dtgConcertrecipeDetail.RowCount;i++)
				{
					if(m_objViewer.m_dtgConcertrecipeDetail[i,2].ToString().Trim()==m_objViewer.m_lsvCharge.SelectedItems[0].SubItems[0].Text.Trim())
					{
						if(MessageBox.Show("该项目已经存在于当前处方，是否继续？","提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
						{
							break;
						}
						else
						{
							m_objViewer.m_lsvCharge.Height=0;
							m_objViewer.m_lsvCharge.Visible=false;
							m_objViewer.m_dtgConcertrecipeDetail.CurrentCell=new DataGridCell(row,3);
							return;
						}
					}
				}
				m_objViewer.m_dtgConcertrecipeDetail[row,2]=m_objViewer.m_lsvCharge.SelectedItems[0].SubItems[0].Text.Trim();
				m_objViewer.m_dtgConcertrecipeDetail[row,3]=m_objViewer.m_lsvCharge.SelectedItems[0].SubItems[2].Text.Trim();
				m_objViewer.m_dtgConcertrecipeDetail[row,4]=0;
				m_objViewer.m_dtgConcertrecipeDetail[row,5]=m_objViewer.m_lsvCharge.SelectedItems[0].SubItems[3].Text.Trim();
				m_objViewer.m_dtgConcertrecipeDetail[row,6]=m_objViewer.m_lsvCharge.SelectedItems[0].SubItems[4].Text.Trim();
				m_objViewer.m_dtgConcertrecipeDetail[row,7]=m_objViewer.m_lsvCharge.SelectedItems[0].SubItems[5].Text.Trim();
				m_objViewer.m_dtgConcertrecipeDetail[row,12]=m_objViewer.m_lsvCharge.SelectedItems[0].SubItems[6].Text.Trim();				
//				m_objViewer.m_pnlCharge.Visible=false;
				m_objViewer.m_lsvCharge.Height=0;
				m_objViewer.m_lsvCharge.Visible=false;
				m_objViewer.m_dtgConcertrecipeDetail.CurrentCell=new DataGridCell(row,4);
			}
		}
		public void m_dtgConcertrecipe_m_evtCurrentCellChanged(object sender, System.EventArgs e)
		{
			this.m_objViewer.m_dtgConcertrecipeDetail.AllowAddNew = true;
			if(this.m_objViewer.m_dtgConcertrecipe [this.m_objViewer.m_dtgConcertrecipe.CurrentCell.RowNumber,0].ToString()
				!= this.m_strCiptID)
			{
				this.m_strCiptID = this.m_objViewer.m_dtgConcertrecipe [this.m_objViewer.m_dtgConcertrecipe.CurrentCell.RowNumber,0].ToString();
				this.m_lngGetConcertreCipeDetailByID();
				this.m_lngGetConcertreCipeDeptByID();
			}
			if(this.m_objViewer.m_dtgConcertrecipe [this.m_objViewer.m_dtgConcertrecipe.CurrentCell.RowNumber,2].ToString()
				!= "科室")
			{
				this.m_objViewer.m_txtDept.Enabled = false;
			}
			else
			{
				this.m_objViewer.m_txtDept.Enabled = true;
			}
			if(this.m_objViewer.m_dtgConcertrecipe.CurrentCell.ColumnNumber == 2 && 
				this.m_objViewer.m_dtgConcertrecipe[this.m_objViewer.m_dtgConcertrecipe.CurrentCell.RowNumber,2].ToString() == "科室"
				&& this.m_objViewer.m_lsvDept.Items.Count > 0)
			{
				((clsColumnInfo)this.m_objViewer.m_dtgConcertrecipe.Columns[2]).ReadOnly = true;
			}
			else
			{
				((clsColumnInfo)this.m_objViewer.m_dtgConcertrecipe.Columns[2]).ReadOnly = false;
			}
			if(this.m_objViewer.m_dtgConcertrecipe.CurrentCell.ColumnNumber == 2)
			{
				this.m_objViewer.m_lblUser.Text = "0-公用 1-私用 2-科室";
			}
			else
			{
				this.m_objViewer.m_lblUser.Text = "";;
			}
			if(this.m_objViewer.m_dtgConcertrecipe.CurrentCell.ColumnNumber >5)
			{
				this.m_objViewer.m_dtgConcertrecipe.Focus();
				this.m_objViewer.m_dtgConcertrecipe.CurrentCell=new DataGridCell(this.m_objViewer.m_dtgConcertrecipe.CurrentCell.RowNumber+1,1);

			}
		}

		public void m_Modefy(string strarg)
		{
			if(strarg == "1")
			{
				int inedex = this.m_objViewer.m_dtgConcertrecipeDetail.CurrentCell.RowNumber;
				for(int i=0;i<m_clsMConcertrectpe_VO.Length;i++)
				{
					if(m_clsMConcertrecipeDetail_VO[i].m_strDETAILID_CHR == 
						this.m_objViewer.m_dtgConcertrecipeDetail[this.m_objViewer.m_dtgConcertrecipeDetail.CurrentCell.RowNumber,1].ToString()
						&& m_clsMConcertrecipeDetail_VO[i].m_strRECIPEID_CHR == 
						this.m_objViewer.m_dtgConcertrecipeDetail[this.m_objViewer.m_dtgConcertrecipeDetail.CurrentCell.RowNumber,0].ToString())
					{
						m_clsMConcertrecipeDetail_VO[i].m_strDETAILID_CHR =  m_objViewer.m_dtgConcertrecipeDetail[i,"DETAILID_CHR"].ToString().Trim();
						m_clsMConcertrecipeDetail_VO[i].m_strRECIPEID_CHR = this.m_strCiptID;					
						m_clsMConcertrecipeDetail_VO[i].m_strITEMID_CHR = m_objViewer.m_dtgConcertrecipeDetail[i,"ITEMID_CHR"].ToString().Trim();
						m_clsMConcertrecipeDetail_VO[i].m_strQTY_DEC = m_objViewer.m_dtgConcertrecipeDetail[i,"QTY_DEC"].ToString().Trim();
						m_clsMConcertrecipeDetail_VO[i].m_clsChargeItem_VO.m_strItemName = m_objViewer.m_dtgConcertrecipeDetail[i,"ITEMNAME_VCHR"].ToString().Trim();	
						return;
					}
				}
				int length = this.m_clsMConcertrecipeDetail_VO.Length;
				clsConcertrecipeDetail_VO[] objTempVO = new clsConcertrecipeDetail_VO[length+1];
				this.m_clsMConcertrecipeDetail_VO.CopyTo(objTempVO,0);
				objTempVO[length] = new clsConcertrecipeDetail_VO();
				objTempVO[length].m_strDETAILID_CHR = m_objViewer.m_dtgConcertrecipeDetail[inedex,"DETAILID_CHR"].ToString().Trim();
				objTempVO[length].m_strRECIPEID_CHR = this.m_strCiptID;					
				objTempVO[length].m_strITEMID_CHR = m_objViewer.m_dtgConcertrecipeDetail[inedex,"ITEMID_CHR"].ToString().Trim();
				objTempVO[length].m_strQTY_DEC = m_objViewer.m_dtgConcertrecipeDetail[inedex,"QTY_DEC"].ToString().Trim();
				objTempVO[length].m_clsChargeItem_VO.m_strItemName = m_objViewer.m_dtgConcertrecipeDetail[inedex,"ITEMNAME_VCHR"].ToString().Trim();
				this.m_clsMConcertrecipeDetail_VO = objTempVO;
			}
			else
			{
				int intPRIVILEGE = 0;
				int inedex = this.m_objViewer.m_dtgConcertrecipe.CurrentCell.RowNumber;
				switch(m_objViewer.m_dtgConcertrecipe[inedex,"PRIVILEGE_INT"].ToString().Trim())
				{
					case "公用":
						intPRIVILEGE = 0;
						break;
					case "私用":
						intPRIVILEGE = 1;
						break;
					case "科室":
						intPRIVILEGE = 2;
						
						break;
				}
				for(int i=0;i<m_clsMConcertrectpe_VO.Length;i++)
				{
					if(m_clsMConcertrectpe_VO[i].m_strRECIPEID_CHR == 
						this.m_objViewer.m_dtgConcertrecipe[this.m_objViewer.m_dtgConcertrecipeDetail.CurrentCell.RowNumber,0].ToString())
					{
						m_clsMConcertrectpe_VO[i].m_strRECIPEID_CHR = m_objViewer.m_dtgConcertrecipe[i,"RECIPEID_CHR"].ToString().Trim();
						m_clsMConcertrectpe_VO[i].m_strRECIPENAME_CHR = m_objViewer.m_dtgConcertrecipe[i,"RECIPENAME_CHR"].ToString().Trim();
						m_clsMConcertrectpe_VO[i].m_intPRIVILEGE_INT = intPRIVILEGE;
						m_clsMConcertrectpe_VO[i].m_strUSERCODE_CHR = m_objViewer.m_dtgConcertrecipe[i,"USERCODE_CHR"].ToString().Trim();
						m_clsMConcertrectpe_VO[i].m_strWBCODE_CHR = m_objViewer.m_dtgConcertrecipe[i,"WBCODE_CHR"].ToString().Trim();
						m_clsMConcertrectpe_VO[i].m_strPYCODE_CHR = m_objViewer.m_dtgConcertrecipe[i,"PYCODE_CHR"].ToString().Trim();
						m_clsMConcertrectpe_VO[i].m_intSTATUS_INT = 1;
						m_clsMConcertrectpe_VO[i].m_strCREATERID_CHR = m_objViewer.m_dtgConcertrecipe[i,"CREATERID_CHR"].ToString().Trim();
						m_clsMConcertrectpe_VO[i].clsEmployee_VO.m_strLASTNAME_VCHR = m_objViewer.m_dtgConcertrecipe[i,"CREATERNAME_VCHR"].ToString().Trim();
						return;
					}
				}
				int length = this.m_clsMConcertrectpe_VO.Length;
				clsConcertrectpe_VO[] objTempVO = new clsConcertrectpe_VO[length+1];
				this.m_clsMConcertrectpe_VO.CopyTo(objTempVO,0);
				objTempVO[length] = new clsConcertrectpe_VO();
				objTempVO[length].m_strRECIPEID_CHR = m_objViewer.m_dtgConcertrecipe[inedex,"RECIPEID_CHR"].ToString().Trim();
				objTempVO[length].m_strRECIPENAME_CHR = m_objViewer.m_dtgConcertrecipe[inedex,"RECIPENAME_CHR"].ToString().Trim();
				objTempVO[length].m_intPRIVILEGE_INT = intPRIVILEGE;
				objTempVO[length].m_strUSERCODE_CHR = m_objViewer.m_dtgConcertrecipe[inedex,"USERCODE_CHR"].ToString().Trim();
				objTempVO[length].m_strWBCODE_CHR = m_objViewer.m_dtgConcertrecipe[inedex,"WBCODE_CHR"].ToString().Trim();
				objTempVO[length].m_strPYCODE_CHR = m_objViewer.m_dtgConcertrecipe[inedex,"PYCODE_CHR"].ToString().Trim();
				objTempVO[length].m_intSTATUS_INT = 1;
				objTempVO[length].m_strCREATERID_CHR = m_objViewer.m_dtgConcertrecipe[inedex,"CREATERID_CHR"].ToString().Trim();
				objTempVO[length].clsEmployee_VO.m_strLASTNAME_VCHR = m_objViewer.m_dtgConcertrecipe[inedex,"CREATERNAME_VCHR"].ToString().Trim();
				this.m_clsMConcertrectpe_VO = objTempVO;

			}
		}
		public void m_sumMoney()
		{
			if(this.m_objViewer.m_dtgConcertrecipeDetail.RowCount == 0)
			{
				this.m_objViewer.m_lblP.Text = "";
				return;
			}
			float Money = 0;
			for(int i=0;i<this.m_objViewer.m_dtgConcertrecipeDetail.RowCount;i++)
			{
				try
				{
					Money = Money+float.Parse(this.m_objViewer.m_dtgConcertrecipeDetail[i,13].ToString());
				}
				catch
				{
					this.m_objViewer.m_dtgConcertrecipeDetail[i,13] = m_mthConvertToFloat(this.m_objViewer.m_dtgConcertrecipeDetail[i,4])*m_mthConvertToFloat(this.m_objViewer.m_dtgConcertrecipeDetail[i,12]);
					Money = Money+float.Parse(this.m_objViewer.m_dtgConcertrecipeDetail[i,13].ToString());
				}
			}
			
			this.m_objViewer.m_lblP.Text = "该处方总价："+Money.ToString()+"元";
		}
		#region 查找用服频率(西药)
		public long m_mthFindFrequency(string ID,int row)
		{
			DataTable dt=null;
			clsDcl_DoctorWorkstation objDW =new clsDcl_DoctorWorkstation();
			long strRet=objDW.m_mthFindFrequency(ID,out dt);
			if(strRet>0&&dt.Rows.Count>0)
			{
				
				if(dt.Rows.Count==1)
				{
								
					m_objViewer.m_dtgConcertrecipeDetail[row,11]=dt.Rows[0]["FREQID_CHR"].ToString().Trim();
					m_objViewer.m_dtgConcertrecipeDetail[row,10]=dt.Rows[0]["FREQNAME_CHR"].ToString().Trim();
//					m_objViewer.ctlDataGrid1[row,13]=dt.Rows[0]["DAYS_INT"].ToString().Trim();
//					m_objViewer.ctlDataGrid1[row,14]=dt.Rows[0]["TIMES_INT"].ToString().Trim();
					m_objViewer.m_dtgConcertrecipeDetail.CurrentCell=new DataGridCell(row+1,3);
					m_objViewer.m_dtgConcertrecipeDetail[row,10]=dt.Rows[0]["FREQNAME_CHR"].ToString().Trim();
					
					//直接填充datagrid
					return 0;
				}
				else
				{
					m_objViewer.listView3.Items.Clear();
					for(int i=0;i<dt.Rows.Count;i++)
					{
						ListViewItem lv =new ListViewItem(dt.Rows[i]["FREQID_CHR"].ToString().Trim());//ID
						lv.SubItems.Add(dt.Rows[i]["USERCODE_CHR"].ToString().Trim());//助记码
						lv.SubItems.Add(dt.Rows[i]["FREQNAME_CHR"].ToString().Trim());//名称
						lv.SubItems.Add(dt.Rows[i]["TIMES_INT"].ToString().Trim());//次数
						lv.SubItems.Add(dt.Rows[i]["DAYS_INT"].ToString().Trim());//天数
						m_objViewer.listView3.Items.Add(lv);
					}
										
					//填充listView
				
				}
				return 1;
			}
			else
			{
			
				((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.m_dtgConcertrecipeDetail.Columns[10] ).DataGridTextBoxColumn.TextBox.SelectAll();
				return -1;

			}
		}
		#endregion
		#region 查找用法
		public long m_mthFindUsage(string ID,int row)
		{
			DataTable dt=null;
			clsDcl_DoctorWorkstation objDW =new clsDcl_DoctorWorkstation();
			long strRet=objDW.m_mthFindUsage(ID, 0, out dt);
			if(strRet>0&&dt.Rows.Count>0)
			{
				
				if(dt.Rows.Count==1)
				{
								
					m_objViewer.m_dtgConcertrecipeDetail[row,9]=dt.Rows[0]["USAGEID_CHR"].ToString().Trim();
					m_objViewer.m_dtgConcertrecipeDetail[row,8]=dt.Rows[0]["USAGENAME_VCHR"].ToString().Trim();
					m_objViewer.m_dtgConcertrecipeDetail.CurrentCell=new DataGridCell(row,10);
										
					//直接填充datagrid
					return 0;
				}
				else
				{
					m_objViewer.listView2.Items.Clear();
					for(int i=0;i<dt.Rows.Count;i++)
					{
						ListViewItem lv =new ListViewItem(dt.Rows[i]["USAGEID_CHR"].ToString().Trim());//ID
						lv.SubItems.Add(dt.Rows[i]["USERCODE_CHR"].ToString().Trim());//助记码
						lv.SubItems.Add(dt.Rows[i]["USAGENAME_VCHR"].ToString().Trim());//名称
						m_objViewer.listView2.Items.Add(lv);
					}
										
					//填充listView
				
				}
				return 1;
			}
			else
			{
			
				((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.m_dtgConcertrecipeDetail.Columns[8] ).DataGridTextBoxColumn.TextBox.SelectAll();
				return -1;

			}
		}
		#endregion
		#region 频次和用法的ListViewKeyDown处理
		public void m_mthListViewKeyDown2(System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.m_mthListViewDoubleClick2();
			}
			if(e.KeyCode==Keys.Escape)
			{
				this.m_objViewer.listView2.Visible=false;
				this.m_objViewer.m_dtgConcertrecipeDetail.CurrentCell=new DataGridCell(	this.m_objViewer.m_dtgConcertrecipeDetail.CurrentCell.RowNumber,8);
			}
		}
		public void m_mthListViewKeyDown3(System.Windows.Forms.KeyEventArgs e)//频次
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.m_mthListViewDoubleClick3();
			}
			if(e.KeyCode==Keys.Escape)
			{
				this.m_objViewer.listView3.Visible=false;
				this.m_objViewer.m_dtgConcertrecipeDetail.CurrentCell=new DataGridCell(	this.m_objViewer.m_dtgConcertrecipeDetail.CurrentCell.RowNumber,10);
			}
		}
		//双击事件
		public void m_mthListViewDoubleClick2()
		{
			int row =m_objViewer.m_dtgConcertrecipeDetail.CurrentCell.RowNumber;
			m_objViewer.m_dtgConcertrecipeDetail[row,9]=m_objViewer.listView2.SelectedItems[0].SubItems[0].Text.Trim();
			m_objViewer.m_dtgConcertrecipeDetail[row,8]=m_objViewer.listView2.SelectedItems[0].SubItems[2].Text.Trim();
			m_objViewer.listView2.Hide();
			m_objViewer.m_dtgConcertrecipeDetail.CurrentCell=new DataGridCell(row,10);
		}
		public void m_mthListViewDoubleClick3()//频次
		{
			int row =m_objViewer.m_dtgConcertrecipeDetail.CurrentCell.RowNumber;
			m_objViewer.m_dtgConcertrecipeDetail[row,11]=m_objViewer.listView3.SelectedItems[0].SubItems[0].Text.Trim();
			m_objViewer.m_dtgConcertrecipeDetail[row,10]=m_objViewer.listView3.SelectedItems[0].SubItems[2].Text.Trim();
			m_objViewer.listView3.Hide();
			m_objViewer.m_dtgConcertrecipeDetail.CurrentCell=new DataGridCell(row+1,3);
		}
		#endregion
	}
}
