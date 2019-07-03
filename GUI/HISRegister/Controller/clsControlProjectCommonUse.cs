
using System;
using System.Windows.Forms;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsControlProjectCommonUse 的摘要说明。
	/// 丁胜财
	/// </summary>
	public class clsControlProjectCommonUse:com.digitalwave.GUI_Base.clsController_Base
	{
		public clsControlProjectCommonUse()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		com.digitalwave.iCare.gui.HIS.clsDomainControlMedCommonUse objSVC = new clsDomainControlMedCommonUse();
		System.Data.DataTable m_dtMedCommonUse;
		System.Data.DataTable m_dtMedCommonUseDel;

		#region 设置窗体对象		
		com.digitalwave.iCare.gui.HIS.frmProjectCommonUse m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmProjectCommonUse)frmMDI_Child_Base_in;

			
		}
		#endregion

		#region 初始化
		public void InitFrm()
		{
			InitPrjBse("");
			InitMedCommonUse();
			InitMedSort();
			
		}
		System.Data.DataTable dt;
		public void InitPrjBse(string p_strMedSort)
		{
			
			objSVC.GetPrjBseInfo(p_strMedSort,out dt);
			this.m_objViewer.m_dgMedBse.m_mthSetDataTable(dt);

            //this.m_objViewer.m_dgMedBse.BeginUpdate();
            //for(int i1=0;i1<dt.Rows.Count;i1++)
            //{

            //    if(dt.Rows[i1]["NOQTYFLAG_INT"].ToString()=="1")
            //    {
            //        for(int f2=0;f2<3;f2++)
            //        {
            //            this.m_objViewer.m_dgMedBse.m_mthFormatCell(i1,f2,m_objViewer.m_dgMedBse.Font,System.Drawing.Color.White,System.Drawing.Color.Red);
            //        }

            //    }
            //}
            //this.m_objViewer.m_dgMedBse.EndUpdate();
		}
		private void InitMedCommonUse()
		{
			objSVC.GetPrjCommonUseInfo(this.m_objViewer.LoginInfo,out m_dtMedCommonUse);
			this.m_objViewer.m_dgCommonUse.m_mthSetDataTable(m_dtMedCommonUse);
            //this.m_objViewer.m_dgCommonUse.BeginUpdate();
            //for(int i1=0;i1<m_dtMedCommonUse.Rows.Count;i1++)
            //{

            //    if(m_dtMedCommonUse.Rows[i1]["NOQTYFLAG_INT"].ToString()=="1")
            //    {
            //        for(int f2=0;f2<3;f2++)
            //        {
            //            this.m_objViewer.m_dgCommonUse.m_mthFormatCell(i1,f2,m_objViewer.m_dgCommonUse.Font,System.Drawing.Color.White,System.Drawing.Color.Red);
            //        }

            //    }
            //}
            //this.m_objViewer.m_dgCommonUse.EndUpdate();
		}
		#region 查找数据
		

		
		public void m_mthFind()
		{
			if(this.m_objViewer.m_cmbCondition.SelectedIndex ==-1 || this.m_objViewer.m_txtMedName.Text==string.Empty)
			{
				return ;
			}
			System.Data.DataTable dtFind=dt.Clone();
			string strColumn = "";
			string strFiled="";
			if(this.m_objViewer.m_txtMedName.Text != "")
			{
				switch(this.m_objViewer.m_cmbCondition.SelectedIndex)
				{
					case 0:
						strColumn = "ITEMCODE_VCHR";
						strFiled=this.m_objViewer.m_txtMedName.Text;
						break;
					case 1:
						strColumn = "ITEMNAME_VCHR";
						strFiled=this.m_objViewer.m_txtMedName.Text;
						break;
					case 2:
						strColumn = "ITEMPYCODE_CHR";
						strFiled=this.m_objViewer.m_txtMedName.Text.ToUpper();
						break;
					case 3:
						strColumn = "ITEMWBCODE_CHR";
						strFiled=this.m_objViewer.m_txtMedName.Text.ToUpper();
						break;
					case 4:
						strColumn = "ITEMENGNAME_VCHR";
						strFiled=this.m_objViewer.m_txtMedName.Text;
						break;
				
				}
			}
			System.Data.DataRow[] objRows=dt.Select(strColumn+" like '"+strFiled+"%'");
			if(objRows.Length>0)
			{
				for(int i1=0;i1<objRows.Length;i1++)
				{
						m_mthAddRowForTable(objRows[i1],ref dtFind);
				}
			}
			this.m_objViewer.m_dgMedBse.m_mthSetDataTable(dtFind);
            //this.m_objViewer.m_dgMedBse.BeginUpdate();
            //for(int i1=0;i1<dt.Rows.Count;i1++)
            //{

            //    if(dt.Rows[i1]["NOQTYFLAG_INT"].ToString()=="1")
            //    {
            //        for(int f2=0;f2<3;f2++)
            //        {
            //            this.m_objViewer.m_dgMedBse.m_mthFormatCell(i1,f2,m_objViewer.m_dgMedBse.Font,System.Drawing.Color.White,System.Drawing.Color.Red);
            //        }

            //    }
            //}
            //this.m_objViewer.m_dgMedBse.EndUpdate();

		}
		#endregion
		#region 为查找表构造一行
		private void m_mthAddRowForTable(System.Data.DataRow newRow,ref System.Data.DataTable dt)
		{
			System.Data.DataRow AddRow=dt.NewRow();
			for(int i1=0;i1<dt.Rows.Count;i1++)
			{
				AddRow[i1]=newRow[i1];
			}
			dt.Rows.Add(AddRow);
		}

		#endregion
		private void InitMedSort()
		{
			System.Data.DataTable dt;
			System.Data.DataTable dt1;
			System.Data.DataTable dt2;
			System.Data.DataTable dt3;
			clsDomainControlItemAndMedSortRel objSVC = new clsDomainControlItemAndMedSortRel();
			objSVC.m_lngGetFeeSort(out dt,out dt1,out dt2,out dt3);
			this.m_objViewer.m_cmbMedSort.DisplayMember = "ITEMCATNAME_VCHR";
			this.m_objViewer.m_cmbMedSort.ValueMember = "ITEMCATID_CHR";
			System.Data.DataRow dr = dt.NewRow();
			dr["ITEMCATNAME_VCHR"] = "所有";
			dr["ITEMCATID_CHR"] = "%";
			dt.Rows.InsertAt(dr,0);
			this.m_objViewer.m_cmbMedSort.DataSource = dt;
			this.m_objViewer.m_cmbMedSort.SelectedIndex = 0;
		}

		#endregion 初始化
		
		public void m_bIsHasPrescriptionRight(string p_strEmpID)
		{
			if(objSVC.IsHasPrescriptionRight(p_strEmpID) == false)
			{
				disEnable(this.m_objViewer);
			}
		}
		public void disEnable(Control obj)
		{
			if(obj.HasChildren)
			{
				obj.Enabled = false;
				for(int i = 0;i < obj.Controls.Count;i++)
				{
					disEnable(obj.Controls[i]);
				}
			}
			else
			{
				obj.Enabled = false;
			}
		}
		public void Add(bool isDept)
		{
			com.digitalwave.iCare.ValueObject.clsDepartmentVO[] obj;
			this.m_objComInfo.m_mthGetDepartmentByUserID(this.m_objViewer.LoginInfo.m_strEmpID,out obj);
			for(int i1 = 0; i1 < this.m_objViewer.m_dgMedBse.RowCount; i1 ++)
			{
				if(!this.m_objViewer.m_dgMedBse.m_blnRowIsSelected(i1))
				{
					continue;
				}
				
				if(isDept)
				{
					/////////////////////////加入一个人有几个课室的情况///////////////////////////		
					if(obj == null)
					{
						//MessageBox.Show("");
						break;
					}
					for(int j2 = 0;j2 < obj.Length; j2++)
					{
						System.Data.DataRow[] drs = m_dtMedCommonUse.Select("itemid_chr ='"
							+this.m_objViewer.m_dgMedBse.m_objGetRow(i1)["itemid_chr"].ToString()
							+"' and privilege_int=1 and deptid_chr='"+obj[j2].strDeptID+"'");	
						if(drs.Length > 0)
						{
							continue;
						}
						System.Data.DataRow dr = this.m_dtMedCommonUse.NewRow();
						dr["itemid_chr"] = this.m_objViewer.m_dgMedBse.m_objGetRow(i1)["itemid_chr"].ToString();
						dr["itemname_vchr"] = this.m_objViewer.m_dgMedBse.m_objGetRow(i1)["itemname_vchr"].ToString();
						dr["privilege_int"] = 1;
						dr["deptname_vchr"] =  obj[j2].strDeptName;
						dr["deptid_chr"] = obj[j2].strDeptID;
						dr["privilege_name"] = "科室";
						dr["createrid_chr"] = this.m_objViewer.LoginInfo.m_strEmpID;
						dr["itemspec_vchr"] = this.m_objViewer.m_dgMedBse.m_objGetRow(i1)["itemspec_vchr"].ToString();	
						dr["itemcode_vchr"] = this.m_objViewer.m_dgMedBse.m_objGetRow(i1)["itemcode_vchr"].ToString();
						this.m_dtMedCommonUse.Rows.Add(dr);
                        //if(this.m_objViewer.m_dgMedBse.m_objGetRow(i1)["NOQTYFLAG_INT"].ToString()=="1")
                        //{
                        //    for(int f3=0;f3<5;f3++)
                        //    {
                        //        this.m_objViewer.m_dgCommonUse.m_mthFormatCell(this.m_dtMedCommonUse.Rows.Count-1,f3,this.m_objViewer.m_dgCommonUse.Font,System.Drawing.Color.White,System.Drawing.Color.Red);
                        //    }
                        //}
					}
				}
				else
				{
					System.Data.DataRow[] drs = m_dtMedCommonUse.Select("itemid_chr ='"+this.m_objViewer.m_dgMedBse.m_objGetRow(i1)["itemid_chr"].ToString()+"' and privilege_int=0");
					if(drs.Length > 0)
					{
						continue;
					}
					System.Data.DataRow dr = this.m_dtMedCommonUse.NewRow();
					dr["itemid_chr"] = this.m_objViewer.m_dgMedBse.m_objGetRow(i1)["itemid_chr"].ToString();
					dr["itemname_vchr"] = this.m_objViewer.m_dgMedBse.m_objGetRow(i1)["itemname_vchr"].ToString();
					dr["privilege_int"] = 0;
					dr["deptid_chr"] = "";
					dr["privilege_name"] = "个人";
					dr["createrid_chr"] = this.m_objViewer.LoginInfo.m_strEmpID;
					dr["itemspec_vchr"] = this.m_objViewer.m_dgMedBse.m_objGetRow(i1)["itemspec_vchr"].ToString();		
					dr["itemcode_vchr"] = this.m_objViewer.m_dgMedBse.m_objGetRow(i1)["itemcode_vchr"].ToString();
					this.m_dtMedCommonUse.Rows.Add(dr);
                    //if(this.m_objViewer.m_dgMedBse.m_objGetRow(i1)["NOQTYFLAG_INT"].ToString()=="1")
                    //{
                    //    for(int f4=0;f4<5;f4++)
                    //    {
                    //        this.m_objViewer.m_dgCommonUse.m_mthFormatCell(this.m_dtMedCommonUse.Rows.Count-1,f4,this.m_objViewer.m_dgCommonUse.Font,System.Drawing.Color.White,System.Drawing.Color.Red);
                    //    }
                    //}
				}
			}
		}
		public void Del()
		{
			if(this.m_dtMedCommonUseDel == null)
			{
				m_dtMedCommonUseDel = m_dtMedCommonUse.Clone();
			}
			int count = this.m_objViewer.m_dgCommonUse.m_arrSelectRows().Length;
			for(int i1 = 0; i1 < this.m_objViewer.m_dgCommonUse.RowCount ; i1 ++)
			{
				if(this.m_objViewer.m_dgCommonUse.m_blnRowIsSelected(i1))
				{
					m_dtMedCommonUseDel.ImportRow(this.m_objViewer.m_dgCommonUse.m_objGetRow(i1));								m_dtMedCommonUse.Rows[i1].Delete();
					m_dtMedCommonUse.AcceptChanges();
					count--;
				}
				if(count <= 0)
				{
					break;
				}
			}
		}
		public long m_lngSaveMedCommonUse()
		{
			
			long lngRes = objSVC.SaveMedCommonUseInfo(m_dtMedCommonUse,m_dtMedCommonUseDel,"1");
			m_dtMedCommonUseDel=null;
			m_dtMedCommonUse.AcceptChanges();
			return lngRes;
		}
		public bool m_bChangeState()
		{
			if(m_dtMedCommonUseDel != null)
			{
				return true;
			}
			else
			{
				if( m_dtMedCommonUse.GetChanges() != null)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		
	}
}
