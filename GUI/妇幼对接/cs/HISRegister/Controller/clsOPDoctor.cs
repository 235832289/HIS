using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using com.digitalwave.iCare.gui.Security;
using com.digitalwave.iCare.ValueObject; 
using exDataGridSour;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsOPDoctor 的摘要说明。
	/// </summary>
	public class clsOPDoctor:com.digitalwave.GUI_Base.clsController_Base
	{
		public clsOPDoctor()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			clsDomain=new clsDomainControl_OPDoctor();
			clsController_Security clsSe=new clsController_Security();
			OperatorID=clsSe.objGetCurrentLoginEmployee().strEmpID;
			DepID=clsSe.objGetCurrentLoginDepartment().strDeptID;
		}
		string OperatorID="";
		string DepID="";
		public string RegID="";//"000000000000000001";
		string strPatID="";
		clsOutpatientRecipe_VO[] clsRecVO=new clsOutpatientRecipe_VO[0];
		clsDomainControl_OPDoctor clsDomain;
		#region 设置窗体
		private com.digitalwave.iCare.gui.HIS.frmOPDoctor objfrm;
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			objfrm=(frmOPDoctor)frmMDI_Child_Base_in;
			base.Set_GUI_Apperance (frmMDI_Child_Base_in);
		}

		#endregion
        
		#region 清空
		public void Clear()
		{
			RegID="";
			strPatID="";
			objfrm.m_txtCureDesc.Tag=""; //当前病历是否改变
			clsRecVO=new clsOutpatientRecipe_VO[0];
			objfrm.m_RecNo.ClearItem();
			objfrm.m_Memo.Text="";
			objfrm.m_Cooking.SelectedIndex=-1;
			objfrm.m_Dosage.Text="";
			objfrm.m_lbRecA.Text="";
			objfrm.m_tab.SelectedIndex=0; //跳到候诊
		}
		#endregion

		#region 设置各候诊Grid的样式
		public void m_SetWaitGrid(bool IsWait)
		{
			DataTable dtResult=null;
			long lngRes=0;
			if(IsWait)
			{
				lngRes=clsDomain.m_lngGetWaitList(OperatorID,ref dtResult);
				objfrm.dgWait.DataSource=dtResult;
			}
			else
			{
				lngRes=clsDomain.m_lngGetTakeList(OperatorID,ref dtResult);
				objfrm.dgTake.DataSource=dtResult;
			}
			DataGridTableStyle ts1 = new DataGridTableStyle();
			exColumn exTextCol;
			if(IsWait)
				exTextCol=new exColumn("候诊ID","WAITDIAGLISTID_CHR","WaitID");
			else
				exTextCol=new exColumn("接诊记录ID","takediagrecid_chr","TakeID");
			exTextCol.Hide=true;
			ts1.GridColumnStyles.Add(exTextCol);
			exTextCol=new exColumn("挂号ID","RegisterID_CHR","RegID");
			exTextCol.Hide=true;
			ts1.GridColumnStyles.Add(exTextCol);
			exTextCol=new exColumn("序号","order_int");
			exTextCol.Width=40;
			ts1.GridColumnStyles.Add(exTextCol);
			exTextCol=new exColumn("流水号","RegNo");
			exTextCol.Width=60;
			ts1.GridColumnStyles.Add(exTextCol);
			exTextCol=new exColumn("病人姓名","name");
			exTextCol.Width=100;
			ts1.GridColumnStyles.Add(exTextCol);
			exTextCol=new exColumn("性别","sex");
			exTextCol.Width=40;
			ts1.GridColumnStyles.Add(exTextCol);
			exTextCol=new exColumn("年龄","Age");
			exTextCol.Width=40;
			ts1.GridColumnStyles.Add(exTextCol);
			exTextCol=new exColumn("挂号科室","deptname_vchr");
			exTextCol.Width=100;
			if(!IsWait)
			{
				exTextCol=new exColumn("接诊时间","takediagtime_dat");
				exTextCol.Width=120;
			}
			ts1.GridColumnStyles.Add(exTextCol);
			if(IsWait)
			{
				objfrm.dgWait.TableStyles.Add(ts1);			
			}
			else
			{
				objfrm.dgTake.TableStyles.Add(ts1);			        
			}
			
		}
		#endregion
		#region 接诊
		public void m_TakeDiag()
		{
			if(objfrm.dgWait.Row>=objfrm.dgWait.Rows)
				return;
			string strID=objfrm.dgWait.Get_TextMatrix(objfrm.dgWait.Row,objfrm.dgWait.ColIndex("WaitID"));
			if(strID=="")
				return;
			RegID=objfrm.dgWait.Get_TextMatrix(objfrm.dgWait.Row,objfrm.dgWait.ColIndex("RegID"));
			objfrm.m_PatInfo.FindInfoByRegID(RegID);
			if(RegID=="")
				return;
			m_accDiag(strID);
		}
		private void m_accDiag(string strWaitID)
		{
			long lngRes=clsDomain.m_lngTakeWait(strWaitID,RegID,this.DepID,this.OperatorID);
			if(lngRes>=0)
			{
				RefreshWait(true);
				RefreshWait(false);
				//				this.m_FillPatRec(RegID);
			}
		}
		public void RefreshWait(bool IsWait)
		{
			DataTable dtResult=null;
			long lngRes=0;
			if(IsWait)
			{
				int row=objfrm.dgWait.Row;
				lngRes=clsDomain.m_lngGetWaitList(OperatorID,ref dtResult);
				objfrm.dgWait.RefreshDataSource(dtResult);
				if(objfrm.dgWait.Rows>row && row>-1)
				{
					objfrm.dgWait.Row=row;
				}
			}
			else
			{
				lngRes=clsDomain.m_lngGetTakeList(OperatorID,ref dtResult);
				objfrm.dgTake.RefreshDataSource(dtResult);
			}
		}
		#endregion
        
		#region 填充处方
		public void m_FillRecList()
		{
			this.m_ChkMainRec(false);
			for(int i1=1;i1<7;i1++)
			{
				this.m_SetRecList(i1,null);
			}
			this.m_countRec();
		}
		public void m_SetRecList(int RecType,string RecID)
		{
			DataTable dtResult=null;
			long lngRes=0;
			DataGridTableStyle ts1 = new DataGridTableStyle();
			exColumn exCol;
			switch (RecType)
			{
				case 1: //西药
					lngRes=clsDomain.m_lngGetWestRec(RegID,RecID,ref dtResult);
					if(objfrm.dgWest.TableStyles.Count==0)
					{
						m_FillItem(RecType,ref ts1);
						objfrm.dgWest.TableStyles.Add(ts1);	
					}
					objfrm.dgWest.DataSource=dtResult;
					objfrm.dgWest.CheckCol=objfrm.dgWest.ColIndex("pStaut");
					objfrm.dgWest.CheckString="1";
					if(objfrm.dgWest.DataSource.Rows.Count==0)
						this.m_addDetail(objfrm.dgWest);
					objfrm.dgWest.IsDirty=false;
					objfrm.dgWest.CellTextChange+=new exDataGridSour.CellChange(GridCell_TextChanged);
					objfrm.dgWest.RowCanEdit+=new exDataGridSour.CellEdit(GridRow_CanEdit);
					objfrm.dgWest.SetRowColor+=new exDataGridSour.CellColorEventHandler(SetRowColor);
					exCol=(exColumn)objfrm.dgWest.TableStyles[0].GridColumnStyles[objfrm.dgWest.ColIndex("ItemCode")];
					if(!exCol.TextBox.HasChildren)
					{
						exCol.TextBox.Controls.Add(objfrm.m_InWest);
						objfrm.m_InWest.Dock=DockStyle.Fill;
						objfrm.m_InWest.Show();
					}
					exCol=(exColumn)objfrm.dgWest.TableStyles[0].GridColumnStyles[objfrm.dgWest.ColIndex("FreName")];
					if(!exCol.TextBox.HasChildren)
					{
						exCol.TextBox.Controls.Add(objfrm.m_ctlFre);
						objfrm.m_ctlFre.Dock=DockStyle.Fill;
						objfrm.m_ctlFre.Show();
					}
					break;
				case 2: //中药
					lngRes=clsDomain.m_lngGetCMRec(RegID,RecID,ref dtResult);
					if(objfrm.dgCM.TableStyles.Count==0)
					{
						m_FillItem(RecType,ref ts1);
						objfrm.dgCM.TableStyles.Add(ts1);	
					}
					objfrm.dgCM.DataSource=dtResult;
					objfrm.dgCM.CheckCol=objfrm.dgCM.ColIndex("pStaut");
					objfrm.dgCM.CheckString="1";
					if(objfrm.dgCM.DataSource.Rows.Count==0)
						this.m_addDetail(objfrm.dgCM);
	
					objfrm.dgCM.CellTextChange+=new exDataGridSour.CellChange(GridCell_TextChanged);
					objfrm.dgCM.RowCanEdit+=new exDataGridSour.CellEdit(GridRow_CanEdit);
					objfrm.dgCM.SetRowColor+=new exDataGridSour.CellColorEventHandler(SetRowColor);
					exCol=(exColumn)objfrm.dgCM.TableStyles[0].GridColumnStyles[objfrm.dgCM.ColIndex("ItemCode")];
					if(!exCol.TextBox.HasChildren)
					{
						exCol.TextBox.Controls.Add(objfrm.m_InCM);
						objfrm.m_InCM.Dock=DockStyle.Fill;
						objfrm.m_InCM.Show();
					}
					objfrm.dgCM.IsDirty=false;
					break;
				case 3: //检验
					lngRes=clsDomain.m_lngGetCHKRec(RegID,RecID,ref dtResult);
					if(objfrm.dgChk.TableStyles.Count==0)
					{
						m_FillItem(RecType,ref ts1);
						objfrm.dgChk.TableStyles.Add(ts1);	
					}
					objfrm.dgChk.DataSource=dtResult;
					objfrm.dgChk.CheckCol=objfrm.dgChk.ColIndex("pStaut");
					objfrm.dgChk.CheckString="1";
					if(objfrm.dgChk.DataSource.Rows.Count==0)
						this.m_addDetail(objfrm.dgChk);
					
					objfrm.dgChk.CellTextChange+=new exDataGridSour.CellChange(GridCell_TextChanged);
					objfrm.dgChk.RowCanEdit+=new exDataGridSour.CellEdit(GridRow_CanEdit);
					objfrm.dgChk.SetRowColor+=new exDataGridSour.CellColorEventHandler(SetRowColor);
					exCol=(exColumn)objfrm.dgChk.TableStyles[0].GridColumnStyles[objfrm.dgChk.ColIndex("ItemCode")];
					if(!exCol.TextBox.HasChildren)
					{
						exCol.TextBox.Controls.Add(objfrm.m_InChk);
						objfrm.m_InChk.Dock=DockStyle.Fill;
						objfrm.m_InChk.Show();
					}
					objfrm.dgChk.IsDirty=false;
					break;
				case 4: //检查
					lngRes=clsDomain.m_lngGetTestRec(RegID,RecID,ref dtResult);
					if(objfrm.dgTest.TableStyles.Count==0)
					{
						m_FillItem(RecType,ref ts1);
						objfrm.dgTest.TableStyles.Add(ts1);	
					}
					objfrm.dgTest.DataSource=dtResult;
					objfrm.dgTest.CheckCol=objfrm.dgTest.ColIndex("pStaut");
					objfrm.dgTest.CheckString="1";
					if(objfrm.dgTest.DataSource.Rows.Count==0)
						this.m_addDetail(objfrm.dgTest);

					objfrm.dgTest.CellTextChange+=new exDataGridSour.CellChange(GridCell_TextChanged);
					objfrm.dgTest.RowCanEdit+=new exDataGridSour.CellEdit(GridRow_CanEdit);
					objfrm.dgTest.SetRowColor+=new exDataGridSour.CellColorEventHandler(SetRowColor);
					exCol=(exColumn)objfrm.dgTest.TableStyles[0].GridColumnStyles[objfrm.dgTest.ColIndex("ItemCode")];
					if(!exCol.TextBox.HasChildren)
					{
						exCol.TextBox.Controls.Add(objfrm.m_InTest);
						objfrm.m_InTest.Dock=DockStyle.Fill;
						objfrm.m_InTest.Show();
					}
					objfrm.dgTest.IsDirty=false;
					break;
				case 5: //手术
					lngRes=clsDomain.m_lngGetOPSRec(RegID,RecID,ref dtResult);
					if(objfrm.dgOPS.TableStyles.Count==0)
					{
						m_FillItem(RecType,ref ts1);
						objfrm.dgOPS.TableStyles.Add(ts1);	
					}
					objfrm.dgOPS.DataSource=dtResult;
					objfrm.dgOPS.CheckCol=objfrm.dgOPS.ColIndex("pStaut");
					objfrm.dgOPS.CheckString="1";
					if(objfrm.dgOPS.DataSource.Rows.Count==0)
						this.m_addDetail(objfrm.dgOPS);

					objfrm.dgOPS.CellTextChange+=new exDataGridSour.CellChange(GridCell_TextChanged);
					objfrm.dgOPS.RowCanEdit+=new exDataGridSour.CellEdit(GridRow_CanEdit);
					objfrm.dgOPS.SetRowColor+=new exDataGridSour.CellColorEventHandler(SetRowColor);
					exCol=(exColumn)objfrm.dgOPS.TableStyles[0].GridColumnStyles[objfrm.dgOPS.ColIndex("ItemCode")];
					if(!exCol.TextBox.HasChildren)
					{
						exCol.TextBox.Controls.Add(objfrm.m_InOPS);
						objfrm.m_InOPS.Dock=DockStyle.Fill;
						objfrm.m_InOPS.Show();
					}
					objfrm.dgOPS.IsDirty=false;
					break;
				case 6: //其它
					lngRes=clsDomain.m_lngGetOtherRec(RegID,RecID,ref dtResult);
					if(objfrm.dgOther.TableStyles.Count==0)
					{
						m_FillItem(RecType,ref ts1);
						objfrm.dgOther.TableStyles.Add(ts1);	
					}
					objfrm.dgOther.DataSource=dtResult;
					objfrm.dgOther.CheckCol=objfrm.dgOther.ColIndex("pStaut");
					objfrm.dgOther.CheckString="1";
					if(objfrm.dgOther.DataSource.Rows.Count==0)
						this.m_addDetail(objfrm.dgOther);

					objfrm.dgOther.CellTextChange+=new exDataGridSour.CellChange(GridCell_TextChanged);
					objfrm.dgOther.RowCanEdit+=new exDataGridSour.CellEdit(GridRow_CanEdit);
					objfrm.dgOther.SetRowColor+=new exDataGridSour.CellColorEventHandler(SetRowColor);
					exCol=(exColumn)objfrm.dgOther.TableStyles[0].GridColumnStyles[objfrm.dgOther.ColIndex("ItemCode")];
					if(!exCol.TextBox.HasChildren)
					{
						exCol.TextBox.Controls.Add(objfrm.m_InOther);
						objfrm.m_InOther.Dock=DockStyle.Fill;
						objfrm.m_InOther.Show();
					}
					objfrm.dgOther.IsDirty=false;
					break;
			}
		}
		private void m_FillItem(int RecType,ref DataGridTableStyle ts1)
		{
			//行号，项目编码，项目名称，单位，单价，每次量，天数，用法，频率，总量，总价.
			ts1=new DataGridTableStyle();
			exColumn exTextCol;
			exTextCol=new exColumn("处方号","RecNo","RecNo");
			exTextCol.Width=60;
			exTextCol.CanEdit=false;
			ts1.GridColumnStyles.Add(exTextCol);
			exTextCol=new exColumn("行号","RowNo","RowNo");
			exTextCol.Width=60;
			exTextCol.CanEdit=false;
			//exTextCol.IsNum=true;
			//exTextCol.TextBox.MaxLength=4;
			ts1.GridColumnStyles.Add(exTextCol);
			exTextCol=new exColumn("项目编码","ItemCode","ItemCode");
			if(RecType==1)
				exTextCol.Width=80;
			else
				exTextCol.Width=100;
			exTextCol.CanEdit=true;
			ts1.GridColumnStyles.Add(exTextCol);
			exTextCol=new exColumn("项目名称","ItemName","ItemName");
			exTextCol.CanEdit=false;
			exTextCol.Width=120;
			ts1.GridColumnStyles.Add(exTextCol);
			exTextCol=new exColumn("规格","Spec","Spec");
			exTextCol.CanEdit=false;
			exTextCol.Width=100;
			ts1.GridColumnStyles.Add(exTextCol);
			if(RecType<3 || RecType==6)
			{
				exTextCol=new exColumn("单位","UnitName","UnitName");
				if(RecType==1)
					exTextCol.Width=60;
				else
					exTextCol.Width=100;
				exTextCol.CanEdit=false;
				ts1.GridColumnStyles.Add(exTextCol);
			}
			if(RecType<3 || RecType==6)
			{
				exTextCol=new exColumn("单价","Price","Price");
				exTextCol.CanEdit=false;
				if(RecType==1)
					exTextCol.Width=60;
				else
					exTextCol.Width=100;	
				ts1.GridColumnStyles.Add(exTextCol);
			}
			//			if(RecType>2)
			//			{
			//				exTextCol.IsNum=true;
			//				exTextCol.CanEdit=true;
			//			}
			if(RecType==1)
			{
				exTextCol=new exColumn("每次量","QTY","QTY");
				exTextCol.Width=60;
				exTextCol.TextBox.MaxLength=10;
				exTextCol.CanEdit=true;
				exTextCol.IsNumAndOption=true;
				ts1.GridColumnStyles.Add(exTextCol);
				exTextCol=new exColumn("天数","Days","Days");
				exTextCol.Width=60;
				exTextCol.TextBox.MaxLength=3;
				exTextCol.CanEdit=true;
				exTextCol.IsNumAndOption=true;
				ts1.GridColumnStyles.Add(exTextCol);
			}
			if(RecType<3)
			{
				exTextCol=new exColumn("用法","UsageName","UsageName");
				exTextCol.Width=100;
				exTextCol.CanEdit=true;
				ts1.GridColumnStyles.Add(exTextCol);
			}
			if(RecType==1)
			{
				exTextCol=new exColumn("频率","FreName","FreName");
				exTextCol.Width=100;
				exTextCol.CanEdit=true;
				ts1.GridColumnStyles.Add(exTextCol);
			}
			if(RecType<3 || RecType==6)
			{
				if(RecType==6)
					exTextCol=new exColumn("数量","Count","Count");
				else
					exTextCol=new exColumn("总量","Count","Count");
				exTextCol.Width=100;
				exTextCol.IsNumAndOption=true;
				exTextCol.CanEdit=true;
				exTextCol.TextBox.MaxLength=10;
				ts1.GridColumnStyles.Add(exTextCol);
			}
			if(RecType<3 || RecType==6)
				exTextCol=new exColumn("总价","Amount","Amount");
			else
				exTextCol=new exColumn("单价","Amount","Amount");
			exTextCol.Width=100;
			exTextCol.IsNumAndOption=true;
			exTextCol.CanEdit=true;
			exTextCol.TextBox.MaxLength=10;
			ts1.GridColumnStyles.Add(exTextCol);
			
			if(RecType>2 && RecType<6)//中药之后的申请单
			{
				exTextCol=new exColumn("执行科室","DepName","DepName");
				exTextCol.Width=100;
				exTextCol.CanEdit=true;
				ts1.GridColumnStyles.Add(exTextCol);
			}//处方ID，处方明细ID，项目ID，单位ID，用法ID，频率ID，频率次数.
			exTextCol=new exColumn("","RecID","RecID"); //处方ID
			exTextCol.Hide=true;
			ts1.GridColumnStyles.Add(exTextCol);
			exTextCol=new exColumn("","DetID","DetID"); //处方明细ID
			exTextCol.Hide=true;
			ts1.GridColumnStyles.Add(exTextCol);
			exTextCol=new exColumn("","ItemID","ItemID"); //项目ID
			exTextCol.Hide=true;
			ts1.GridColumnStyles.Add(exTextCol);
			if(RecType<3 || RecType==6) //西药和中药
			{
				exTextCol=new exColumn("","UnitID","UnitID"); //单位ID
				exTextCol.Hide=true;
				ts1.GridColumnStyles.Add(exTextCol);
				if(RecType<3)
				{
					exTextCol=new exColumn("","UsageID","UsageID"); //用法ID
					exTextCol.Hide=true;
					ts1.GridColumnStyles.Add(exTextCol);
				}
			}
			if(RecType==1) //西药
			{
				exTextCol=new exColumn("","FreID","FreID"); //频率ID
				exTextCol.Hide=true;
				ts1.GridColumnStyles.Add(exTextCol);
				exTextCol=new exColumn("","intFre","intFre"); //频率次数
				exTextCol.Hide=true;
				ts1.GridColumnStyles.Add(exTextCol);
			}
			if(RecType>2 && RecType<6)
			{
				exTextCol=new exColumn("","DepID","DepID");//执行科室ID
				exTextCol.Hide=true;
				ts1.GridColumnStyles.Add(exTextCol);
			}
			exTextCol=new exColumn("","pStaut","pStaut");
			exTextCol.Hide=true;
			ts1.GridColumnStyles.Add(exTextCol);
			exTextCol=new exColumn("","DocID","DocID");
			exTextCol.Hide=true;
			ts1.GridColumnStyles.Add(exTextCol);
		}
		#endregion

		#region 事件
		private void SetRowColor(object sender, DataGridCellColorEventArgs e)
		{
			
			if(e.checkText != ((exDataGrid)sender).CheckString && e.checkText!="")
			{
				e.ForeColor = Color.Red;
			}
		}
		private void GridRow_CanEdit(object sender,boolVisible e)
		{
			exDataGrid exGrid=(exDataGrid)sender;
			if(e.checkText != exGrid.CheckString && e.checkText!="")
				e.IsVisible=false;
			else
				e.IsVisible=true;
			string cellText=exGrid.Get_TextMatrix(e.Row,exGrid.ColIndex("DocID"));
			if(cellText!=this.OperatorID && cellText!="") //该记录不是该医生所开
				e.IsVisible=false;
		}
		private void GridCell_TextChanged(object sender,CellInfo e)
		{
			if(e.exData.Col==e.exData.ColIndex("RowNo"))
			{
				if(this.m_CheckRowNo(e.exData,e.strCell))
				{
					((TextBox)sender).Text="";
					MessageBox.Show("已存在该行号！","提示");
				}
			}
			exCellChange(e.exData);			
		}
		private void exCellChange(exDataGrid e)
		{
			string[] strCol;
			if(e.Col==e.ColIndex("Amount"))
			{
				this.m_countRec();
				objfrm.m_currRecA.Text=e.ColCount("Amount").ToString();
				return;
			}
			if(e.Name=="dgWest")
			{
				strCol=new string[4];
				strCol[0]="QTY";
				strCol[1]="Days";
				strCol[2]="intFre";
				strCol[3]="Count";
				if(e.Col==e.ColIndex("QTY") || e.Col==e.ColIndex("Days") || e.Col==e.ColIndex("intFre"))
				{
					e.multiplyCol(strCol,"QTY");
					strCol=new string[3];
					strCol[0]="Price";
					strCol[1]="Count";
					strCol[2]="Amount";
					e.multiplyCol(strCol,"Price");
					objfrm.m_currRecA.Text=e.ColCount("Amount").ToString();
				}
				else if(e.Col==e.ColIndex("Count"))
				{
					strCol=new string[3];
					strCol[0]="Price";
					strCol[1]="Count";
					strCol[2]="Amount";
					e.multiplyCol(strCol,"Price");
					objfrm.m_currRecA.Text=e.ColCount("Amount").ToString();
				}
				return;
			}
			if(e.Name=="dgCM" || e.Name=="dgOther")
			{
				if(e.Col==e.ColIndex("Count"))
				{
					strCol=new string[3];
					strCol[0]="Price";
					strCol[1]="Count";
					strCol[2]="Amount";
					e.multiplyCol(strCol,"Price");
					objfrm.m_currRecA.Text=e.ColCount("Amount").ToString();
				}
				return;
			}
			else //其它处方
			{
				if(e.Col==e.ColIndex("Price"))
				{
					this.m_countRec();
					objfrm.m_currRecA.Text=e.ColCount("Price").ToString();
					return;
				}
			}
		}
		#endregion

		#region 当前处方改变时触发的事件
		public void m_currRecindexChange(string tabName)
		{
			exColumn exCol;
			DialogResult intButton;
			DataTable dtResult=new DataTable();
			long lngRes=0;
			string strMsg="已经修改，保存吗？";
			if(objfrm.m_tab.Tag.ToString()==tabName)
				return;
			if(tabName=="tabWait")
			{
				this.RefreshWait(true);
				objfrm.m_timer.Enabled=true;
			}
			else
				objfrm.m_timer.Enabled=false;
			if(tabName=="tabWait"|| tabName=="tabTake")
			{
				if(objfrm.m_panHide.Visible)
				{
					objfrm.lbHide_Click(null,null);
					objfrm.lbHide.Tag="True";
				}
				objfrm.lbHide.Hide();
				objfrm.m_tab.Tag=tabName;
				return;
			}
			if(this.RegID=="")
			{
				if(tabName=="tabWait" || tabName=="tabTake")
				{
					objfrm.m_tab.Tag=tabName;
					return;
				}
				if(objfrm.m_tab.Tag.ToString()=="tabWait")
				{
					this.RefreshWait(true);
					objfrm.m_timer.Enabled=true;
					objfrm.m_tab.SelectedIndex=0;
				}
				else
					objfrm.m_tab.SelectedIndex=1;
				MessageBox.Show("请选择就诊病人","提示");
				return;
			}
			
			switch(objfrm.m_tab.Tag.ToString())
			{
				case "tabWest":
					if(objfrm.dgWest.IsDirty) //已修改
					{
						intButton=MessageBox.Show("西药处方"+strMsg,"提示",MessageBoxButtons.YesNoCancel);
						switch(intButton)
						{
							case DialogResult.Yes:
								lngRes=this.m_SaveRec(objfrm.m_tab.Tag.ToString());
								if(lngRes<0)
									objfrm.m_tab.SelectedIndex=m_intIndex("tabWest");
								break;
							case DialogResult.Cancel:
								objfrm.m_tab.SelectedIndex=m_intIndex("tabWest");
								return;
								break;
							case DialogResult.No:
								lngRes=clsDomain.m_lngGetWestRec(RegID,null,ref dtResult);
								objfrm.dgWest.RefreshDataSource(dtResult);
								if(objfrm.dgWest.DataSource.Rows.Count==0)
									this.m_addDetail(objfrm.dgWest);
								objfrm.dgWest.IsDirty=false;
								break;
						}
					}
					break;
				case "tabCM":
					if(objfrm.dgCM.IsDirty) //已修改
					{
						intButton=MessageBox.Show("中药处方"+strMsg,"提示",MessageBoxButtons.YesNoCancel);
						switch(intButton)
						{
							case DialogResult.Yes:
								lngRes=this.m_SaveRec(objfrm.m_tab.Tag.ToString());
								if(lngRes<0)
									objfrm.m_tab.SelectedIndex=m_intIndex("tabCM");
								break;
							case DialogResult.Cancel:
								objfrm.m_tab.SelectedIndex=m_intIndex("tabCM");
								return;
								break;
							case DialogResult.No:
								lngRes=clsDomain.m_lngGetCMRec(RegID,null,ref dtResult);
								objfrm.dgCM.RefreshDataSource(dtResult);
								if(objfrm.dgCM.DataSource.Rows.Count==0)
									this.m_addDetail(objfrm.dgCM);
								objfrm.dgCM.IsDirty=false;
								break;
						}
					}
					break;
				case "tabChk":
					if(objfrm.dgChk.IsDirty) //已修改
					{
						intButton=MessageBox.Show("检验申请单"+strMsg,"提示",MessageBoxButtons.YesNoCancel);
						switch(intButton)
						{
							case DialogResult.Yes:
								lngRes=this.m_SaveRec(objfrm.m_tab.Tag.ToString());
								if(lngRes<0)
									objfrm.m_tab.SelectedIndex=m_intIndex("tabChk");
								break;
							case DialogResult.Cancel:
								objfrm.m_tab.SelectedIndex=m_intIndex("tabChk");
								return;
								break;
							case DialogResult.No:
								lngRes=clsDomain.m_lngGetCHKRec(RegID,null,ref dtResult);
								objfrm.dgChk.RefreshDataSource(dtResult);
								if(objfrm.dgChk.DataSource.Rows.Count==0)
									this.m_addDetail(objfrm.dgChk);
								objfrm.dgChk.IsDirty=false;
								break;
						}
					}
					break;
				case "tabTest":
					if(objfrm.dgTest.IsDirty) //已修改
					{
						intButton=MessageBox.Show("检查申请单"+strMsg,"提示",MessageBoxButtons.YesNoCancel);
						switch(intButton)
						{
							case DialogResult.Yes:
								lngRes=this.m_SaveRec(objfrm.m_tab.Tag.ToString());
								if(lngRes<0)
									objfrm.m_tab.SelectedIndex=m_intIndex("tabTest");
								break;
							case DialogResult.Cancel:
								objfrm.m_tab.SelectedIndex=m_intIndex("tabTest");
								return;
								break;
							case DialogResult.No:
								lngRes=clsDomain.m_lngGetTestRec(RegID,null,ref dtResult);
								objfrm.dgTest.RefreshDataSource(dtResult);
								if(objfrm.dgTest.DataSource.Rows.Count==0)
									this.m_addDetail(objfrm.dgTest);
								objfrm.dgTest.IsDirty=false;
								break;
						}
					}
					break;
				case "tabOPS":
					if(objfrm.dgOPS.IsDirty) //已修改
					{
						intButton=MessageBox.Show("手术申请单"+strMsg,"提示",MessageBoxButtons.YesNoCancel);
						switch(intButton)
						{
							case DialogResult.Yes:
								lngRes=this.m_SaveRec(objfrm.m_tab.Tag.ToString());
								if(lngRes<0)
									objfrm.m_tab.SelectedIndex=m_intIndex("tabOPS");
								break;
							case DialogResult.Cancel:
								objfrm.m_tab.SelectedIndex=m_intIndex("tabOPS");
								return;
								break;
							case DialogResult.No:
								lngRes=clsDomain.m_lngGetOPSRec(RegID,null,ref dtResult);
								objfrm.dgOPS.RefreshDataSource(dtResult);
								if(objfrm.dgOPS.DataSource.Rows.Count==0)
									this.m_addDetail(objfrm.dgOPS);
								objfrm.dgOPS.IsDirty=false;
								break;
						}
					}
					break;
				case "tabOther":
					if(objfrm.dgOther.IsDirty) //已修改
					{
						intButton=MessageBox.Show("其它项目"+strMsg,"提示",MessageBoxButtons.YesNoCancel);
						switch(intButton)
						{
							case DialogResult.Yes:
								lngRes=this.m_SaveRec(objfrm.m_tab.Tag.ToString());
								if(lngRes<0)
									objfrm.m_tab.SelectedIndex=m_intIndex("tabOther");
								break;
							case DialogResult.Cancel:
								objfrm.m_tab.SelectedIndex=m_intIndex("tabOther");
								return;
								break;
							case DialogResult.No:
								lngRes=clsDomain.m_lngGetOtherRec(RegID,null,ref dtResult);
								objfrm.dgOther.RefreshDataSource(dtResult);
								if(objfrm.dgOther.DataSource.Rows.Count==0)
									this.m_addDetail(objfrm.dgOther);
								objfrm.dgOther.IsDirty=false;
								break;
						}
					}
					break;
			}
			objfrm.m_Dosage.Visible=false;
			objfrm.m_lbDosage.Visible=false;
			objfrm.m_Cooking.Visible=false;
			objfrm.m_lbCook.Visible=false;
			objfrm.lbHide.Show();
			if(objfrm.lbHide.Tag.ToString()=="True") //之前是显示的
			{
				if(!objfrm.m_panHide.Visible)
					objfrm.lbHide_Click(null,null);
			}
			if(objfrm.m_tab.SelectedIndex>=m_intIndex("tabWest"))
			{
				objfrm.m_currRec.Text=objfrm.m_tab.SelectedTab.Text.Substring(3)+"：";
			}
			else
			{
				objfrm.m_currRec.Text="";
				objfrm.m_currRecA.Text="";
			}
			switch(tabName)
			{
				case "tabWest":
					exCol=(exColumn)objfrm.dgWest.TableStyles[0].GridColumnStyles[objfrm.dgWest.ColIndex("UsageName")];
					exCol.TextBox.Controls.Add(objfrm.m_cboUsage);
					objfrm.m_cboUsage.Dock=DockStyle.Fill;
					objfrm.m_cboUsage.Show();
					objfrm.m_currRecA.Text=objfrm.dgWest.ColCount("Amount").ToString();
					objfrm.dgWest.Focus();
					break;
				case "tabCM":
					exCol=(exColumn)objfrm.dgCM.TableStyles[0].GridColumnStyles[objfrm.dgCM.ColIndex("UsageName")];
					exCol.TextBox.Controls.Add(objfrm.m_cboUsage);
					objfrm.m_cboUsage.Dock=DockStyle.Fill;
					objfrm.m_cboUsage.Show();
					objfrm.m_currRecA.Text=objfrm.dgCM.ColCount("Amount").ToString();
					objfrm.dgCM.Focus();
					objfrm.m_Dosage.Visible=true;
					objfrm.m_lbDosage.Visible=true;
					objfrm.m_Cooking.Visible=true;
					objfrm.m_lbCook.Visible=true;
					break;
				case "tabChk":
                    objfrm.ctlDep.Visible=true;
					objfrm.dgChk.Columns[objfrm.dgChk.ColIndex("DepName")].TextBox.Controls.Add(objfrm.ctlDep);
					objfrm.ctlDep.Dock=DockStyle.Fill;
                    objfrm.ctlDep.BringToFront();
					objfrm.m_currRecA.Text=objfrm.dgChk.ColCount("Amount").ToString();
					objfrm.dgChk.Focus();
					break;
				case "tabTest":
					objfrm.ctlDep.Visible=true;
					objfrm.dgTest.Columns[objfrm.dgTest.ColIndex("DepName")].TextBox.Controls.Add(objfrm.ctlDep);
					objfrm.ctlDep.Dock=DockStyle.Fill;
					objfrm.m_currRecA.Text=objfrm.dgTest.ColCount("Amount").ToString();
					objfrm.dgTest.Focus();
					break;
				case "tabOPS":
					objfrm.ctlDep.Visible=true;
					objfrm.dgOPS.Columns[objfrm.dgOPS.ColIndex("DepName")].TextBox.Controls.Add(objfrm.ctlDep);
					objfrm.ctlDep.Dock=DockStyle.Fill;
					objfrm.m_currRecA.Text=objfrm.dgOPS.ColCount("Amount").ToString();
					objfrm.dgOPS.Focus();
					break;
				case "tabOther":
					objfrm.m_currRecA.Text=objfrm.dgOther.ColCount("Amount").ToString();
					objfrm.dgOther.Focus();
					break;
			}
			objfrm.m_tab.Tag=tabName;
		}
		#endregion

		#region 计算金额总计
		public void m_countRec()
		{
			Double dbCount=0;
			dbCount=objfrm.dgWest.ColCount("Amount");
			dbCount=dbCount+objfrm.dgCM.ColCount("Amount");
			dbCount=dbCount+objfrm.dgChk.ColCount("Amount");
			dbCount=dbCount+objfrm.dgTest.ColCount("Amount");
			dbCount=dbCount+objfrm.dgOPS.ColCount("Amount");
			dbCount=dbCount+objfrm.dgOther.ColCount("Amount");
			objfrm.m_lbRecA.Text=dbCount.ToString();
		}
		#endregion
       
		//新增处方
		#region 新增处方
		public void m_AddRec() //新增主处方
		{
			string RecName=objfrm.m_tab.SelectedTab.Name;
			switch(RecName)
			{
				case "tabWest": //西药
					m_addMain(objfrm.dgWest,RecName);
					break;
				case "tabCM": //中药
					m_addMain(objfrm.dgCM,RecName);
					break;
				case "tabChk": //检验
					m_addMain(objfrm.dgChk,RecName);
					break;
				case "tabTest": //检查
					m_addMain(objfrm.dgTest,RecName);
					break;
				case "tabOPS": //手术
					m_addMain(objfrm.dgOPS,RecName);
					break;
				case "tabOther": //手术
					m_addMain(objfrm.dgOther,RecName);
					break;
			}
		}
		private void m_addMain(exDataGrid exDg,string RecName) 
		{
			int intLen=clsRecVO.Length;
			long lngRec=0;
			if(intLen>0)//有主处方
			{
				if(clsRecVO[intLen-1].m_strOutpatRecipeID!=null) //主处方不是新增
				{
					if(clsRecVO[intLen-1].m_intPStatus=="1") //还没收费
					{
						if(exDg.IsDirty)//有修改过
						{
							lngRec=m_SaveRec(RecName);
							if(lngRec>0) //保存成功
								this.m_AddRecToVo();
						}
						else
						{
							this.m_AddRecToVo(); 
							this.m_addDetail(exDg);
						}
					}
					else //已收费
					{
						this.m_AddRecToVo();
						this.m_addDetail(exDg);
					}
				}
				else //有新增的处方
				{
					lngRec=m_SaveRec(RecName);
					if(lngRec>0) //保存成功
						this.m_AddRecToVo();
					this.m_addDetail(exDg);
				}
			}
			else
			{
				this.m_AddRecToVo();
				this.m_addDetail(exDg);
			}
		}
		public void m_AddRecDetail() //新增一处方明细
		{
			string RecName=objfrm.m_tab.SelectedTab.Name;
			switch(RecName)
			{
				case "tabWest": //西药
					m_addDetail(objfrm.dgWest);
					break;
				case "tabCM": //中药
					m_addDetail(objfrm.dgCM);
					break;
				case "tabChk": //检验
					m_addDetail(objfrm.dgChk);
					break;
				case "tabTest": //检查
					m_addDetail(objfrm.dgTest);
					break;
				case "tabOPS": //手术
					m_addDetail(objfrm.dgOPS);
					break;
				case "tabOther": //其它
					m_addDetail(objfrm.dgOther);
					break;
			}
		}
		private void m_addDetail(exDataGrid exDg)
		{
			int intLen=clsRecVO.Length;
			exDg.Focus();
			if(intLen>0)//已有主处方
			{
				if(clsRecVO[intLen-1].m_strOutpatRecipeID!=null) //主处方不是新增的
				{
//					DataRow[] Drw;
//					string strFilter="RecID=" + "'"+clsRecVO[intLen-1].m_strOutpatRecipeID+"'";
//					Drw=exDg.DataSource.Select(strFilter); //是否有此类处方
//					if (Drw.Length>0)
//					{
						if(clsRecVO[intLen-1].m_intPStatus=="1") //还没收费
						{
							if(exDg.Rows==0 || exDg.DataSource.Rows[exDg.Rows-1]["ItemID"].ToString().Trim()!="")
							{
								exDg.DataSource.Rows.Add(new object[exDg.DataSource.Columns.Count]);
								exDg.DataSource.Rows[exDg.Rows-1]["RecID"]=clsRecVO[intLen-1].m_strOutpatRecipeID;
                                exDg.DataSource.Rows[exDg.Rows-1]["RecNo"]=clsRecVO[intLen-1].m_strOutpatRecipeNo;
								exDg.DataSource.Rows[exDg.Rows-1]["DetID"]=null;
							}
							string strNo;
							m_GetMaxRowNo(exDg,Convert.ToString(exDg.Rows-1),out strNo);
							exDg.DataSource.Rows[exDg.Rows-1]["RowNo"]=strNo;
						}
						else
						{
							this.m_AddRecToVo();
							if(exDg.Rows==0 || exDg.DataSource.Rows[exDg.Rows-1]["ItemID"].ToString().Trim()!="")
							{
								exDg.DataSource.Rows.Add(new object[exDg.DataSource.Columns.Count]);
								exDg.DataSource.Rows[exDg.Rows-1]["RecID"]=null;
								exDg.DataSource.Rows[exDg.Rows-1]["RecNo"]=clsRecVO[intLen].m_strOutpatRecipeNo;
								exDg.DataSource.Rows[exDg.Rows-1]["DetID"]=null;
								string strNo;
								m_GetMaxRowNo(exDg,null,out strNo);
								exDg.DataSource.Rows[exDg.Rows-1]["RowNo"]=strNo;
							}
						}
//					}
//					else
//					{
//						if(clsRecVO[intLen-1].m_intPStatus!="1") //已收费
//							this.m_AddRecToVo();
//					
//						exDg.DataSource.Rows.Add(new object[exDg.DataSource.Columns.Count]);
//						exDg.DataSource.Rows[exDg.Rows-1]["RecID"]=clsRecVO[intLen-1].m_strOutpatRecipeID;
//                        exDg.DataSource.Rows[exDg.Rows-1]["RecNo"]=clsRecVO[intLen-1].m_strOutpatRecipeNo;
//						exDg.DataSource.Rows[exDg.Rows-1]["DetID"]=null; 
//						string strNo;
//						m_GetMaxRowNo(exDg,null,out strNo);
//						exDg.DataSource.Rows[exDg.Rows-1]["RowNo"]=strNo;
//					}
					
				}
				else //主处方是新增
				{
					if(exDg.Rows==0 || exDg.DataSource.Rows[exDg.Rows-1]["ItemID"].ToString().Trim()!="")
					{
						exDg.DataSource.Rows.Add(new object[exDg.DataSource.Columns.Count]);
						exDg.DataSource.Rows[exDg.Rows-1]["RecID"]=null;
						exDg.DataSource.Rows[exDg.Rows-1]["RecNo"]=clsRecVO[intLen-1].m_strOutpatRecipeNo;
						exDg.DataSource.Rows[exDg.Rows-1]["DetID"]=null; 
						string strNo;
						m_GetMaxRowNo(exDg,null,out strNo);
						exDg.DataSource.Rows[exDg.Rows-1]["RowNo"]=strNo;
					}
				}
			}
			else //还没有主处方
			{
				this.m_AddRecToVo();
				exDg.DataSource.Rows.Add(new object[exDg.DataSource.Columns.Count]);
				exDg.DataSource.Rows[exDg.Rows-1]["RecID"]=null;
				exDg.DataSource.Rows[exDg.Rows-1]["RecNo"]=clsRecVO[intLen].m_strOutpatRecipeNo;
				string strNo;
				m_GetMaxRowNo(exDg,null,out strNo);
				exDg.DataSource.Rows[exDg.Rows-1]["RowNo"]=strNo;
			}
			exDg.Row=exDg.Rows-1;
			exDg.Col=exDg.ColIndex("ItemCode");
			if(exDg.VisibleColumnCount>0 && exDg.VisibleRowCount>0)
				exDg.CurrentCell=new DataGridCell(exDg.Row,exDg.Col);
		}
		private bool m_CheckRowNo(exDataGrid exGrid,string No)
		{
			string strNo="";
			for(int i1=0;i1<exGrid.Rows;i1++)
			{
				if(i1==exGrid.Row)
					continue;
				strNo=exGrid[i1,exGrid.ColIndex("RowNo")].ToString().Trim();
				if(strNo==No)
				{
					return true; //存在
				}
			}
			return false; //不存在
		}
		private void m_GetMaxRowNo(exDataGrid exGrid,string Row,out string No)
		{
			No="0";
			long MaxNo=0;
			string strNo="";
			for(int i1=0;i1<exGrid.Rows;i1++)
			{
				strNo=exGrid[i1,exGrid.ColIndex("RowNo")].ToString().Trim();
				if(strNo!="" && Row!=i1.ToString())
				{
					if(MaxNo<long.Parse(strNo))
						MaxNo=long.Parse(strNo);
				}
			}
			MaxNo=MaxNo+1;
			No=MaxNo.ToString();
		}
		#endregion
		//新增一主处方
		#region 新增一主处方
		private void m_AddRecToVo()
		{
			int iLeng;
			int intRecNo=1;
			iLeng=clsRecVO.Length;
			clsOutpatientRecipe_VO[] tmpVO;
			if(clsRecVO.Length==0)
			{
				clsRecVO=new clsOutpatientRecipe_VO[1];
				iLeng=1;
				intRecNo=0;
			}
			else
			{
				string RecNO=clsRecVO[iLeng-1].m_strOutpatRecipeNo;
				if(RecNO!=null && RecNO.Trim()!="")
					intRecNo=int.Parse(RecNO.Trim());
				tmpVO=new clsOutpatientRecipe_VO[iLeng+1];
				clsRecVO.CopyTo(tmpVO,0);
				clsRecVO=new clsOutpatientRecipe_VO[iLeng+1];
				tmpVO.CopyTo(clsRecVO,0);
				iLeng=iLeng+1;
			}
			
			iLeng=iLeng-1;
			if (iLeng<0)
				return ;
			intRecNo=intRecNo+1;
			clsRecVO[iLeng]=new clsOutpatientRecipe_VO();
			clsRecVO[iLeng].m_strRegisterID=RegID;
			clsRecVO[iLeng].m_strOutpatRecipeNo=intRecNo.ToString();
			clsRecVO[iLeng].m_objRecordEmp=new clsEmployeeVO();
			clsRecVO[iLeng].m_objRecordEmp.strEmpID=OperatorID;
			clsRecVO[iLeng].m_objDiagDept=new clsDepartmentVO();
			clsRecVO[iLeng].m_objDiagDept.strDeptID=this.DepID;
			clsRecVO[iLeng].m_objDiagDr=new clsEmployeeVO();
			clsRecVO[iLeng].m_objDiagDr.strEmpID=OperatorID;
			clsRecVO[iLeng].m_strOutpatRecipeID=null;
			clsRecVO[iLeng].m_objPatient=new clsPatientVO();
			clsRecVO[iLeng].m_objPatient.strPatientID=this.strPatID;  
			FillMainToCombo();
		}
		#endregion
		//保存处方
		#region 保存处方
		public long m_SaveRec(string RecName) //保存当前处方
		{			
			m_lngSaveDesc();
			long lngRec=0;
			lngRec=m_SaveCaseAndCure();
			if(lngRec<0)
			{
				MessageBox.Show("保存病历失败！","提示");
				return 0;
			}
			DataTable RefDT=new DataTable();
			switch(RecName)
			{
				case "tabWest": //西药
					m_EndEdit(objfrm.dgWest);
					if(m_chekcItem(RecName))
						return 0;
					if(!objfrm.dgWest.IsDirty)
						return 0;
					lngRec=this.m_lngSaveWest();
					if(lngRec>=0)
					{
						clsDomain.m_lngGetWestRec(this.RegID,null,ref RefDT);
						objfrm.dgWest.RefreshDataSource(RefDT);
					}
					break;
				case "tabCM": //中药
					m_EndEdit(objfrm.dgCM);
					if(m_chekcItem(RecName))
						return 0;
					if(!objfrm.dgCM.IsDirty)
						return 0;
					lngRec=this.m_lngSaveCM();
					if(lngRec>=0)
					{
						clsDomain.m_lngGetCMRec(this.RegID,null,ref RefDT);
						objfrm.dgCM.RefreshDataSource(RefDT);
					}
					break;
				case "tabChk": //检验
					m_EndEdit(objfrm.dgChk);
					if(m_chekcItem(RecName))
						return 0;
					if(!objfrm.dgChk.IsDirty)
						return 0;
					lngRec=this.m_lngSaveChk();
					if(lngRec>=0)
					{
						clsDomain.m_lngGetCHKRec(this.RegID,null,ref RefDT);
						objfrm.dgChk.RefreshDataSource(RefDT);
					}
					break;
				case "tabTest": //检查
					m_EndEdit(objfrm.dgTest);
					if(m_chekcItem(RecName))
						return 0;
					if(!objfrm.dgTest.IsDirty)
						return 0;
					lngRec=this.m_lngSaveTest();
					if(lngRec>=0)
					{
						clsDomain.m_lngGetTestRec(this.RegID,null,ref RefDT);
						objfrm.dgTest.RefreshDataSource(RefDT);
					}
					break;
				case "tabOPS": //手术
					m_EndEdit(objfrm.dgOPS);
					if(m_chekcItem(RecName))
						return 0;
					if(!objfrm.dgOPS.IsDirty)
						return 0;
					lngRec=this.m_lngSaveOPS();
					if(lngRec>=0)
					{
						clsDomain.m_lngGetOPSRec(this.RegID,null,ref RefDT);
						objfrm.dgOPS.RefreshDataSource(RefDT);
					}
					break;
				case "tabOther": //其它
					m_EndEdit(objfrm.dgOther);
					if(m_chekcItem(RecName))
						return 0;
					if(!objfrm.dgOther.IsDirty)
						return 0;
					lngRec=this.m_lngSaveOther();
					if(lngRec>=0)
					{
						clsDomain.m_lngGetOtherRec(this.RegID,null,ref RefDT);
						objfrm.dgOther.RefreshDataSource(RefDT);
					}
					break;
			}
			if(lngRec<0)
				MessageBox.Show("保存处方失败！");
			else
			{
				this.m_ChkMainRec(true); //刷新主处方
				if(lngRec>-1)
					m_RefreshAllDetail();
			} 
			return lngRec;
		}
		private void m_RefreshAllDetail()
		{
			if(clsRecVO.Length==0)
				return;
			string strID=clsRecVO[clsRecVO.Length-1].m_strOutpatRecipeID;
			if(strID==null || strID=="")
				return;
			this.m_RefreshDetail(objfrm.dgWest,strID);
			this.m_RefreshDetail(objfrm.dgCM,strID);
			this.m_RefreshDetail(objfrm.dgChk,strID);
			this.m_RefreshDetail(objfrm.dgTest,strID);
			this.m_RefreshDetail(objfrm.dgOPS,strID);
			this.m_RefreshDetail(objfrm.dgOther,strID);
		}
		private void m_RefreshDetail(exDataGrid exGrid,string strID)
		{
			string strRecID;
			for(int i1=0;i1<exGrid.Rows;i1++)
			{
				strRecID=exGrid.Get_TextMatrix(i1,exGrid.ColIndex("RecID"));
				if(strRecID=="")
					exGrid.Set_TextMatrix(i1,exGrid.ColIndex("RecID"),strID);
			}
		}
		private void m_EndEdit(exDataGrid exGrid)
		{
			exGrid.ChangeEditValue();
			//			BindingManagerBase myMgr =(CurrencyManager)objfrm.BindingContext[exGrid.DataSource];
			//			myMgr.EndCurrentEdit();
		}
		#endregion
		#region 保存西药处方
		private long  m_lngSaveWest()
		{
			DataTable tmpDT;
			long lngRes=0;
			bool IsNew=false;
			clsOutpatientPWMRecipeDe_VO[] clsVO;
			tmpDT=objfrm.dgWest.DataSource;
			if(tmpDT.Rows.Count==0) //西药处方的明细
				return 0;
			int intLen=clsRecVO.Length;
			#region 保存处方描述
			//			int index=objfrm.m_RecNo.SelectedIndex-1;
			//			if(objfrm.m_RecNo.SelectItemValue!="All") //不是保存全部
			//			{
			//				if(objfrm.m_RecNo.SelectItemValue==null) //是新增
			//				{
			//					this.m_lngFillWestVO(tmpDT,null,out clsVO,1);
			//					if(clsVO.Length>0)
			//					{
			//						this.m_lngFillDescVO(null,out clsRecVO[index].objRecDesc);
			//						lngRes=clsDomain.m_lngSaveWest(clsRecVO[index],clsVO,true);
			//						IsNew=true;
			//						if(intLen==1 || lngRes<0)
			//							return lngRes;
			//					}
			//				}
			//				else
			//				{ 
			//					this.m_lngFillWestVO(tmpDT,clsRecVO[index].m_strOutpatRecipeID,out clsVO,2); //新增
			//					if(clsVO.Length>0)
			//					{
			//						lngRes=clsDomain.m_lngSaveWest(clsRecVO[index],clsVO,true);
			//						if(lngRes<0)
			//							return lngRes;
			//					}
			//					this.m_lngFillWestVO(tmpDT,clsRecVO[index].m_strOutpatRecipeID,out clsVO,3); //修改
			//					if(clsVO.Length>0)
			//					{
			//						lngRes=clsDomain.m_lngSaveWest(clsRecVO[index],clsVO,false);
			//						if(lngRes<0)
			//							return lngRes;
			//					}
			//				}
			//				return 1;
			//			}
			#endregion
			if(clsRecVO[intLen-1].m_strOutpatRecipeID==null) //先保存新增的记录   
			{
				this.m_lngFillWestVO(tmpDT,null,out clsVO,1);
				if(clsVO.Length>0)
				{
					this.m_lngFillDescVO(clsRecVO[clsRecVO.Length-1].m_strOutpatRecipeID,out clsRecVO[clsRecVO.Length-1].objRecDesc);
					lngRes=clsDomain.m_lngSaveWest(clsRecVO[clsRecVO.Length-1],clsVO,true);
					IsNew=true;
					if(intLen==1 || lngRes<0)
						return lngRes;
				}
			}
			
			if(IsNew) //如果有新增的
				intLen=intLen-1; //不保存新增的那条主记录
			for(int i1=0;i1<intLen;i1++) //根据原来的主处方保存修改或新增的处方明细
			{
				this.m_lngFillWestVO(tmpDT,clsRecVO[i1].m_strOutpatRecipeID,out clsVO,2); //新增
				if(clsVO.Length>0)
				{
					lngRes=clsDomain.m_lngSaveWest(clsRecVO[i1],clsVO,true);
					if(lngRes<0)
						return lngRes;
				}
				this.m_lngFillWestVO(tmpDT,clsRecVO[i1].m_strOutpatRecipeID,out clsVO,3); //修改
				if(clsVO.Length>0)
				{
					lngRes=clsDomain.m_lngSaveWest(clsRecVO[i1],clsVO,false);
					if(lngRes<0)
						return lngRes;
				}
			}
			return lngRes;
		}
		#endregion
		#region 保存中药处方
		private long  m_lngSaveCM()
		{
			DataTable tmpDT;
			long lngRes=0;
			bool IsNew=false;
			clsOutpatientCMRecipeDe_VO[] clsVO;
			tmpDT=objfrm.dgCM.DataSource;
			if(tmpDT.Rows.Count==0) //西药处方的明细
				return 0;
			int intLen=clsRecVO.Length;
			if(clsRecVO[intLen-1].m_strOutpatRecipeID==null) //新增   
			{
				this.m_lngFillCMVO(tmpDT,null,out clsVO,1);
				if(clsVO.Length>0)
				{
					this.m_lngFillDescVO(clsRecVO[clsRecVO.Length-1].m_strOutpatRecipeID,out clsRecVO[clsRecVO.Length-1].objRecDesc);
					lngRes=clsDomain.m_lngSaveCM(clsRecVO[clsRecVO.Length-1],clsVO,true);
					IsNew=true;
					if(intLen==1 || lngRes<0)
						return lngRes;
				}
			}
			
			if(IsNew)
				intLen=intLen-1;
			for(int i1=0;i1<intLen;i1++)
			{
				this.m_lngFillCMVO(tmpDT,clsRecVO[i1].m_strOutpatRecipeID,out clsVO,2);
				if(clsVO.Length>0)
				{
					lngRes=clsDomain.m_lngSaveCM(clsRecVO[i1],clsVO,true);
					if(lngRes<0)
						return lngRes;
				}
				this.m_lngFillCMVO(tmpDT,clsRecVO[i1].m_strOutpatRecipeID,out clsVO,3);
				if(clsVO.Length>0)
				{
					lngRes=clsDomain.m_lngSaveCM(clsRecVO[i1],clsVO,false);
					if(lngRes<0)
						return lngRes;
				}
			}
			return lngRes;
		}
		#endregion
		#region 保存检验
		private long  m_lngSaveChk()
		{
			DataTable tmpDT;
			long lngRes=0;
			bool IsNew=false;
			clsOutpatientCHKRecipeDe_VO[] clsVO;
			tmpDT=objfrm.dgChk.DataSource;
			if(tmpDT.Rows.Count==0) //西药处方的明细
				return 0;
			int intLen=clsRecVO.Length;
			if(clsRecVO[intLen-1].m_strOutpatRecipeID==null) //新增   
			{
				this.m_lngFillChkVO(tmpDT,null,out clsVO,1);
				if(clsVO.Length>0)
				{
					this.m_lngFillDescVO(clsRecVO[clsRecVO.Length-1].m_strOutpatRecipeID,out clsRecVO[clsRecVO.Length-1].objRecDesc);
					lngRes=clsDomain.m_lngSaveChk(clsRecVO[clsRecVO.Length-1],clsVO,true);
					IsNew=true;
					if(intLen==1 || lngRes<0)
						return lngRes;
				}
			}
			
			if(IsNew)
				intLen=intLen-1;
			for(int i1=0;i1<intLen;i1++)
			{
				this.m_lngFillChkVO(tmpDT,clsRecVO[i1].m_strOutpatRecipeID,out clsVO,2);
				if(clsVO.Length>0)
				{
					lngRes=clsDomain.m_lngSaveChk(clsRecVO[i1],clsVO,true);
					if(lngRes<0)
						return lngRes;
				}
				this.m_lngFillChkVO(tmpDT,clsRecVO[i1].m_strOutpatRecipeID,out clsVO,3);
				if(clsVO.Length>0)
				{
					lngRes=clsDomain.m_lngSaveChk(clsRecVO[i1],clsVO,false);
					if(lngRes<0)
						return lngRes;
				}
			}
			return lngRes;
		}
		#endregion
		#region 保存检查
		private long  m_lngSaveTest()
		{
			DataTable tmpDT;
			long lngRes=0;
			bool IsNew=false;
			clsOutpatientTestRecipeDe_VO[] clsVO;
			tmpDT=objfrm.dgTest.DataSource;
			if(tmpDT.Rows.Count==0) //西药处方的明细
				return 0;
			int intLen=clsRecVO.Length;
			if(clsRecVO[intLen-1].m_strOutpatRecipeID==null) //新增   
			{
				this.m_lngFillTestVO(tmpDT,null,out clsVO,1);
				if(clsVO.Length>0)
				{
					this.m_lngFillDescVO(clsRecVO[clsRecVO.Length-1].m_strOutpatRecipeID,out clsRecVO[clsRecVO.Length-1].objRecDesc);
					lngRes=clsDomain.m_lngSaveTest(clsRecVO[clsRecVO.Length-1],clsVO,true);
					IsNew=true;
					if(intLen==1 || lngRes<0)
						return lngRes;
				}
			}
			
			if(IsNew)
				intLen=intLen-1;
			for(int i1=0;i1<intLen;i1++)
			{
				this.m_lngFillTestVO(tmpDT,clsRecVO[i1].m_strOutpatRecipeID,out clsVO,2);
				if(clsVO.Length>0)
				{
					lngRes=clsDomain.m_lngSaveTest(clsRecVO[i1],clsVO,true);
					if(lngRes<0)
						return lngRes;
				}
				this.m_lngFillTestVO(tmpDT,clsRecVO[i1].m_strOutpatRecipeID,out clsVO,3);
				if(clsVO.Length>0)
				{
					lngRes=clsDomain.m_lngSaveTest(clsRecVO[i1],clsVO,false);
					if(lngRes<0)
						return lngRes;
				}
			}
			return lngRes;
		}
		#endregion
		#region 保存手术治疗
		private long  m_lngSaveOPS()
		{
			DataTable tmpDT;
			long lngRes=0;
			bool IsNew=false;
			clsOutpatientOPSRecipeDe_VO[] clsVO;
			tmpDT=objfrm.dgOPS.DataSource;
			if(tmpDT.Rows.Count==0) //西药处方的明细
				return 0;
			int intLen=clsRecVO.Length;
			if(clsRecVO[intLen-1].m_strOutpatRecipeID==null) //新增   
			{
				this.m_lngFillOPSVO(tmpDT,null,out clsVO,1);
				if(clsVO.Length>0)
				{
					this.m_lngFillDescVO(clsRecVO[clsRecVO.Length-1].m_strOutpatRecipeID,out clsRecVO[clsRecVO.Length-1].objRecDesc);
					lngRes=clsDomain.m_lngSaveOPS(clsRecVO[clsRecVO.Length-1],clsVO,true);
					IsNew=true;
					if(intLen==1 || lngRes<0)
						return lngRes;
				}
			}
			
			if(IsNew)
				intLen=intLen-1;
			for(int i1=0;i1<intLen;i1++)
			{
				this.m_lngFillOPSVO(tmpDT,clsRecVO[i1].m_strOutpatRecipeID,out clsVO,2);
				if(clsVO.Length>0)
				{
					lngRes=clsDomain.m_lngSaveOPS(clsRecVO[i1],clsVO,true);
					if(lngRes<0)
						return lngRes;
				}
				this.m_lngFillOPSVO(tmpDT,clsRecVO[i1].m_strOutpatRecipeID,out clsVO,3); //修改
				if(clsVO.Length>0)
				{
					lngRes=clsDomain.m_lngSaveOPS(clsRecVO[i1],clsVO,false);
					if(lngRes<0)
						return lngRes;
				}
			}
			return lngRes;
		}
		#endregion
		#region 保存其它
		private long  m_lngSaveOther()
		{
			DataTable tmpDT;
			long lngRes=0;
			bool IsNew=false;
			clsOutpatientOtherRecipeDe_VO[] clsVO;
			tmpDT=objfrm.dgOther.DataSource;
			if(tmpDT.Rows.Count==0) //西药处方的明细
				return 0;
			int intLen=clsRecVO.Length;
			if(clsRecVO[intLen-1].m_strOutpatRecipeID==null) //新增   
			{
				this.m_lngFillOtherVO(tmpDT,null,out clsVO,1);
				if(clsVO.Length>0)
				{
					this.m_lngFillDescVO(clsRecVO[clsRecVO.Length-1].m_strOutpatRecipeID,out clsRecVO[clsRecVO.Length-1].objRecDesc);
					lngRes=clsDomain.m_lngSaveOther(clsRecVO[clsRecVO.Length-1],clsVO,true);
					IsNew=true;
					if(intLen==1 || lngRes<0)
						return lngRes;
				}
			}
			
			if(IsNew)
				intLen=intLen-1;
			for(int i1=0;i1<intLen;i1++)
			{
				this.m_lngFillOtherVO(tmpDT,clsRecVO[i1].m_strOutpatRecipeID,out clsVO,2);
				if(clsVO.Length>0)
				{
					lngRes=clsDomain.m_lngSaveOther(clsRecVO[i1],clsVO,true);
					if(lngRes<0)
						return lngRes;
				}
				this.m_lngFillOtherVO(tmpDT,clsRecVO[i1].m_strOutpatRecipeID,out clsVO,3); //修改
				if(clsVO.Length>0)
				{
					lngRes=clsDomain.m_lngSaveOther(clsRecVO[i1],clsVO,false);
					if(lngRes<0)
						return lngRes;
				}
			}
			return lngRes;
		}
		#endregion

		#region 保存处方描述
		private long  m_lngSaveDesc()
		{
			long lngRes=0;
			clsOutpatientRecipe_VO[] clsVO;
//			if(objfrm.m_RecNo.SelectItemValue!="All")
//			{
//				clsVO=new clsOutpatientRecipe_VO[1];
//				clsVO[0]=clsRecVO[objfrm.m_RecNo.SelectedIndex-1];
//			}
//			else
//			{
				if(clsRecVO[clsRecVO.Length-1].m_strOutpatRecipeID==null)
				{
					clsVO=new clsOutpatientRecipe_VO[clsRecVO.Length-1];
					Array.Copy(clsRecVO,0,clsVO,0,clsRecVO.Length-1);
				}
				else
				{
					clsVO=new clsOutpatientRecipe_VO[clsRecVO.Length];
					Array.Copy(clsRecVO,0,clsVO,0,clsRecVO.Length);
				}
//			}
			lngRes=clsDomain.m_lngSaveDesc(clsVO);
			return lngRes;
		}
		#endregion 

		#region 把各处方明细用VO保存起来
		private void m_lngFillDescVO(string strID,out clsOutpatientRecipeDesc_VO clsVO)
		{
			if(objfrm.m_Dosage.Text=="" && objfrm.m_Cooking.Text=="" && objfrm.m_Memo.Text=="" && strID==null)
			{
				clsVO=null;//是新增
				return;
			}
			clsVO=new clsOutpatientRecipeDesc_VO();
			clsVO.m_strOutpatRecipeID=strID;
			if(objfrm.m_Dosage.Text!="")
				clsVO.intDosage=int.Parse(objfrm.m_Dosage.Text);
			clsVO.m_strCookingID=objfrm.m_Cooking.CookID;
			clsVO.m_strMemo=objfrm.m_Memo.Text;
		}
		private void m_lngFillWestVO(DataTable DgT,string RecID,out clsOutpatientPWMRecipeDe_VO[] clsVO,int sType)
		{
			clsVO=new clsOutpatientPWMRecipeDe_VO[0];
			DataRow[] Drw=new DataRow[0] ;
			string strFilter;
			if(sType==1) //新增主处方中的明细
				Drw=DgT.Select("RecID is null And RowNum Is null"); //新增
			else if(sType==2) //老处方中新增的明细
			{
				//strFilter="RecID="+ "'"+RecID+"'"+" And DetID='D' And ItemID Is not null";
				strFilter="RecID="+ "'"+RecID+"'"+ " And RowNum Is null";
				Drw=DgT.Select(strFilter); //新增
			}
			else if(sType==3)
			{
				strFilter="RecID="+ "'"+RecID+"'"+" And DetID Is not null And ItemID Is not null";
				Drw=DgT.Select(strFilter); //修改 
			}
			if(Drw.Length==0)
				return;
			clsVO=new clsOutpatientPWMRecipeDe_VO[Drw.Length];
			for(int i1=0;i1<Drw.Length;i1++)
			{
				clsVO[i1]=new clsOutpatientPWMRecipeDe_VO();
//				clsVO[i1].m_objItem=new clsChargeItem_VO();
				if(Drw[i1]["ItemID"].ToString().Trim()=="")
					continue;
				if(Drw[i1]["Days"].ToString().Trim()!="")
					clsVO[i1].m_decDays=decimal.Parse(Drw[i1]["Days"].ToString().Trim());
				clsVO[i1].m_strFrequency=Drw[i1]["FreID"].ToString().Trim(); 
				if(Drw[i1]["Price"].ToString().Trim()!="")
					clsVO[i1].m_decPrice=decimal.Parse(Drw[i1]["Price"].ToString().Trim());
				if(Drw[i1]["QTY"].ToString().Trim()!="")
					clsVO[i1].m_decQty=decimal.Parse(Drw[i1]["QTY"].ToString().Trim());
				if(Drw[i1]["Amount"].ToString().Trim()!="")
					clsVO[i1].m_decTolPrice=decimal.Parse(Drw[i1]["Amount"].ToString().Trim());
				if(Drw[i1]["Count"].ToString().Trim()!="")
					clsVO[i1].m_decTolQty=decimal.Parse(Drw[i1]["Count"].ToString().Trim());
//				clsVO[i1].m_objItem.m_strItemID=Drw[i1]["ItemID"].ToString().Trim();
//				clsVO[i1].m_objUnit=new clsUnit_VO();
//				clsVO[i1].m_objUnit.m_strUnitID=Drw[i1]["UnitID"].ToString().Trim();
//				clsVO[i1].m_objUsage=new clsUsageType_VO();
//				clsVO[i1].m_objUsage.m_strUsageID=Drw[i1]["UsageID"].ToString().Trim();
				if(Drw[i1]["DetID"].ToString().Trim()!="")
					clsVO[i1].m_strOutpatRecipeDeID=Drw[i1]["DetID"].ToString().Trim();
				if(sType!=1)
				{
					if(Drw[i1]["RecID"].ToString().Trim()!="")
						clsVO[i1].m_strOutpatRecipeID=Drw[i1]["RecID"].ToString().Trim(); 
				}
				else
					clsVO[i1].m_strOutpatRecipeID=null;
				clsVO[i1].m_strRowNo=Drw[i1]["RowNo"].ToString().Trim(); 
			}
		}
		private void m_lngFillCMVO(DataTable DgT,string RecID,out clsOutpatientCMRecipeDe_VO[] clsVO,int sType)
		{
			clsVO=new clsOutpatientCMRecipeDe_VO[0];
			DataRow[] Drw=new DataRow[0] ;
			string strFilter;
			if(sType==1) //新增主处方中的明细
				Drw=DgT.Select("RecID is null And RowNum Is null"); //新增
			else if(sType==2) //老处方中新增的明细
			{
				strFilter="RecID="+ "'"+RecID+"'"+ " And RowNum Is null";
				Drw=DgT.Select(strFilter); //新增
			}
			else if(sType==3)
			{
				strFilter="RecID="+ "'"+RecID+"'"+" And DetID Is not null And ItemID Is not null";
				Drw=DgT.Select(strFilter); //修改 
			}
			if(Drw.Length==0)
				return;
			clsVO=new clsOutpatientCMRecipeDe_VO[Drw.Length];
			for(int i1=0;i1<Drw.Length;i1++)
			{
//				clsVO[i1]=new clsOutpatientCMRecipeDe_VO();
//				clsVO[i1].m_objItem=new clsChargeItem_VO();
//				if(Drw[i1]["ItemID"].ToString().Trim()=="")
//					continue;
//				if(Drw[i1]["Price"].ToString().Trim()!="")
//					clsVO[i1].m_decPrice=decimal.Parse(Drw[i1]["Price"].ToString().Trim());
//				if(Drw[i1]["Count"].ToString().Trim()!="")
//					clsVO[i1].m_decQty=decimal.Parse(Drw[i1]["Count"].ToString().Trim());
//				if(Drw[i1]["Amount"].ToString().Trim()!="")
//					clsVO[i1].m_decTolPrice=decimal.Parse(Drw[i1]["Amount"].ToString().Trim());
//				clsVO[i1].m_objItem.m_strItemID=Drw[i1]["ItemID"].ToString().Trim();
//				clsVO[i1].m_objUnit=new clsUnit_VO();
//				clsVO[i1].m_objUnit.m_strUnitID=Drw[i1]["UnitID"].ToString().Trim();
//				clsVO[i1].m_objUsage=new clsUsageType_VO();
//				clsVO[i1].m_objUsage.m_strUsageID=Drw[i1]["UsageID"].ToString().Trim();
				if(Drw[i1]["DetID"].ToString().Trim()!="")
					clsVO[i1].m_strOutpatRecipeDeID=Drw[i1]["DetID"].ToString().Trim();
				if(sType!=1)
				{
					if(Drw[i1]["RecID"].ToString().Trim()!="")
						clsVO[i1].m_strOutpatRecipeID=Drw[i1]["RecID"].ToString().Trim(); 
				} 
				else
					clsVO[i1].m_strOutpatRecipeID=null;
				clsVO[i1].m_strRowNo=Drw[i1]["RowNo"].ToString().Trim(); 
			}
		}
		private void m_lngFillChkVO(DataTable DgT,string RecID,out clsOutpatientCHKRecipeDe_VO[] clsVO,int sType)
		{
			clsVO=new clsOutpatientCHKRecipeDe_VO[0];
			DataRow[] Drw=new DataRow[0] ;
			string strFilter;
			if(sType==1) //新增主处方中的明细
				Drw=DgT.Select("RecID is null And RowNum Is null"); //新增
			else if(sType==2) //老处方中新增的明细
			{
				//strFilter="RecID="+ "'"+RecID+"'"+" And DetID='D' And ItemID Is not null";
				strFilter="RecID="+ "'"+RecID+"'"+ " And RowNum Is null";
				Drw=DgT.Select(strFilter); //新增
			}
			else if(sType==3)
			{
				strFilter="RecID="+ "'"+RecID+"'"+" And DetID Is not null And ItemID Is not null";
				Drw=DgT.Select(strFilter); //修改 
			}
			if(Drw.Length==0)
				return;
			clsVO=new clsOutpatientCHKRecipeDe_VO[Drw.Length];
			for(int i1=0;i1<Drw.Length;i1++)
			{
				clsVO[i1]=new clsOutpatientCHKRecipeDe_VO();
//				clsVO[i1].m_objItem=new clsChargeItem_VO();
//				if(Drw[i1]["ItemID"].ToString().Trim()=="")
//					continue;
//				if(Drw[i1]["Amount"].ToString().Trim()!="")
//					clsVO[i1].m_decPrice=decimal.Parse(Drw[i1]["Amount"].ToString().Trim());
//				clsVO[i1].m_objItem.m_strItemID=Drw[i1]["ItemID"].ToString().Trim();
//				clsVO[i1].m_objOprDept=new clsDepartmentVO();
//				clsVO[i1].m_objOprDept.strDeptID=Drw[i1]["DepID"].ToString().Trim();
				if(Drw[i1]["DetID"].ToString().Trim()!="")
					clsVO[i1].m_strOutpatRecipeDeID=Drw[i1]["DetID"].ToString().Trim();
				if(sType!=1)
				{
					if(Drw[i1]["RecID"].ToString().Trim()!="")
						clsVO[i1].m_strOutpatRecipeID=Drw[i1]["RecID"].ToString().Trim(); 
				}
				else
					clsVO[i1].m_strOutpatRecipeID=null;
				clsVO[i1].m_strRowNo=Drw[i1]["RowNo"].ToString().Trim(); 
			}
		}
		private void m_lngFillTestVO(DataTable DgT,string RecID,out clsOutpatientTestRecipeDe_VO[] clsVO,int sType)
		{
			clsVO=new clsOutpatientTestRecipeDe_VO[0];
			DataRow[] Drw=new DataRow[0] ;
			string strFilter;
			if(sType==1) //新增主处方中的明细
				Drw=DgT.Select("RecID is null And RowNum Is null"); //新增
			else if(sType==2) //老处方中新增的明细
			{
				//strFilter="RecID="+ "'"+RecID+"'"+" And DetID='D' And ItemID Is not null";
				strFilter="RecID="+ "'"+RecID+"'"+ " And RowNum Is null";
				Drw=DgT.Select(strFilter); //新增
			}
			else if(sType==3)
			{
				strFilter="RecID="+ "'"+RecID+"'"+" And DetID Is not null And ItemID Is not null";
				Drw=DgT.Select(strFilter); //修改 
			}
			if(Drw.Length==0)
				return;
			clsVO=new clsOutpatientTestRecipeDe_VO[Drw.Length];
			for(int i1=0;i1<Drw.Length;i1++)
			{
				clsVO[i1]=new clsOutpatientTestRecipeDe_VO();
//				clsVO[i1].m_objItem=new clsChargeItem_VO();
//				if(Drw[i1]["ItemID"].ToString().Trim()=="")
//					continue;
//				if(Drw[i1]["Amount"].ToString().Trim()!="")
//					clsVO[i1].m_decPrice=decimal.Parse(Drw[i1]["Amount"].ToString().Trim());
//				clsVO[i1].m_objItem.m_strItemID=Drw[i1]["ItemID"].ToString().Trim();
//				clsVO[i1].m_objOprDept=new clsDepartmentVO();
//				clsVO[i1].m_objOprDept.strDeptID=Drw[i1]["DepID"].ToString().Trim();
				if(Drw[i1]["DetID"].ToString().Trim()!="")
					clsVO[i1].m_strOutpatRecipeDeID=Drw[i1]["DetID"].ToString().Trim();
				if(sType!=1)
				{
					if(Drw[i1]["RecID"].ToString().Trim()!="")
						clsVO[i1].m_strOutpatRecipeID=Drw[i1]["RecID"].ToString().Trim(); 
				}
				else
					clsVO[i1].m_strOutpatRecipeID=null;
				clsVO[i1].m_strRowNo=Drw[i1]["RowNo"].ToString().Trim(); 
			}
		}
		private void m_lngFillOPSVO(DataTable DgT,string RecID,out clsOutpatientOPSRecipeDe_VO[] clsVO,int sType)
		{
			clsVO=new clsOutpatientOPSRecipeDe_VO[0];
			DataRow[] Drw=new DataRow[0] ;
			string strFilter;
			if(sType==1) //新增主处方中的明细
				Drw=DgT.Select("RecID is null And RowNum Is null"); //新增
			else if(sType==2) //老处方中新增的明细
			{
				//strFilter="RecID="+ "'"+RecID+"'"+" And DetID='D' And ItemID Is not null";
				strFilter="RecID="+ "'"+RecID+"'"+ " And RowNum Is null";
				Drw=DgT.Select(strFilter); //新增
			}
			else if(sType==3)
			{
				strFilter="RecID="+ "'"+RecID+"'"+" And DetID Is not null And ItemID Is not null";
				Drw=DgT.Select(strFilter); //修改 
			}
			if(Drw.Length==0)
				return;
			clsVO=new clsOutpatientOPSRecipeDe_VO[Drw.Length];
			for(int i1=0;i1<Drw.Length;i1++)
			{
//				clsVO[i1]=new clsOutpatientOPSRecipeDe_VO();
//				clsVO[i1].m_objItem=new clsChargeItem_VO();
//				if(Drw[i1]["ItemID"].ToString().Trim()=="")
//					continue;
//				if(Drw[i1]["Amount"].ToString().Trim()!="")
//					clsVO[i1].m_decPrice=decimal.Parse(Drw[i1]["Amount"].ToString().Trim());
//				clsVO[i1].m_objItem.m_strItemID=Drw[i1]["ItemID"].ToString().Trim();
//				clsVO[i1].m_objOprDept=new clsDepartmentVO();
//				clsVO[i1].m_objOprDept.strDeptID=Drw[i1]["DepID"].ToString().Trim();
				if(Drw[i1]["DetID"].ToString().Trim()!="")
					clsVO[i1].m_strOutpatRecipeDeID=Drw[i1]["DetID"].ToString().Trim();
				if(sType!=1)
				{
					if(Drw[i1]["RecID"].ToString().Trim()!="")
						clsVO[i1].m_strOutpatRecipeID=Drw[i1]["RecID"].ToString().Trim(); 
				}
				else
					clsVO[i1].m_strOutpatRecipeID=null;
				clsVO[i1].m_strRowNo=Drw[i1]["RowNo"].ToString().Trim(); 
			}
		}
		private void m_lngFillOtherVO(DataTable DgT,string RecID,out clsOutpatientOtherRecipeDe_VO[] clsVO,int sType)
		{
			clsVO=new clsOutpatientOtherRecipeDe_VO[0];
			DataRow[] Drw=new DataRow[0] ;
			string strFilter;
			if(sType==1) //新增主处方中的明细
				Drw=DgT.Select("RecID is null And RowNum Is null"); //新增
			else if(sType==2) //老处方中新增的明细
			{
				//strFilter="RecID="+ "'"+RecID+"'"+" And DetID='D' And ItemID Is not null";
				strFilter="RecID="+ "'"+RecID+"'"+ " And RowNum Is null";
				Drw=DgT.Select(strFilter); //新增
			}
			else if(sType==3)
			{
				strFilter="RecID="+ "'"+RecID+"'"+" And DetID Is not null And ItemID Is not null";
				Drw=DgT.Select(strFilter); //修改 
			}
			if(Drw.Length==0)
				return;
			
			clsVO=new clsOutpatientOtherRecipeDe_VO[Drw.Length];
			for(int i1=0;i1<Drw.Length;i1++)
			{
				clsVO[i1]=new clsOutpatientOtherRecipeDe_VO();
//				clsVO[i1].m_objItem=new clsChargeItem_VO();
//				if(Drw[i1]["ItemID"].ToString().Trim()=="")
//					continue;
//				if(Drw[i1]["Amount"].ToString().Trim()!="")
//					clsVO[i1].m_decTolPrice=decimal.Parse(Drw[i1]["Amount"].ToString().Trim());
//				if(Drw[i1]["Price"].ToString().Trim()!="")
//					clsVO[i1].m_decPrice=decimal.Parse(Drw[i1]["Price"].ToString().Trim());
//				clsVO[i1].m_objItem.m_strItemID=Drw[i1]["ItemID"].ToString().Trim();
//				if(Drw[i1]["Count"].ToString().Trim()!="")
//					clsVO[i1].m_decQty=decimal.Parse(Drw[i1]["Count"].ToString().Trim());
//				clsVO[i1].m_objUnit=new clsUnit_VO();
//				clsVO[i1].m_objUnit.m_strUnitID=Drw[i1]["UnitID"].ToString().Trim();
				if(Drw[i1]["DetID"].ToString().Trim()!="")
					clsVO[i1].m_strOutpatRecipeDeID=Drw[i1]["DetID"].ToString().Trim();
				if(sType!=1)
				{
					if(Drw[i1]["RecID"].ToString().Trim()!="")
						clsVO[i1].m_strOutpatRecipeID=Drw[i1]["RecID"].ToString().Trim(); 
				}
				else
					clsVO[i1].m_strOutpatRecipeID=null;
				clsVO[i1].m_strRowNo=Drw[i1]["RowNo"].ToString().Trim(); 
			}
		}
		#endregion

		#region 检查病人是否存在处方（填充主处方）
		/// <summary>
		/// 刷新主处方
		/// </summary>
		/// <param name="IsRefresh"></param>
		public void m_ChkMainRec(bool IsRefresh)
		{
			clsRecVO=new clsOutpatientRecipe_VO[0];
			long lngRes=clsDomain.m_lngGetMainRec(RegID,out clsRecVO);
			if(clsRecVO.Length==0 && !IsRefresh)
			{
				this.m_AddRecToVo();
				return;
			}
			FillMainToCombo();
		}
		private bool NoChange=false;
		private void FillMainToCombo()
		{
			objfrm.m_RecNo.ClearItem();
			objfrm.m_RecNo.Tag=null;
			for(int i1=0;i1<clsRecVO.Length;i1++)
			{
				FillRecDesc(clsRecVO[i1].m_strOutpatRecipeID,out clsRecVO[i1].objRecDesc);
				objfrm.m_RecNo.Item.Add(clsRecVO[i1].m_strOutpatRecipeNo,clsRecVO[i1].m_strOutpatRecipeID);
			}
			NoChange=true;
            if(objfrm.m_RecNo.Items.Count>0)
			   objfrm.m_RecNo.SelectedIndex=0;
			NoChange=false;
		}
		//填充处方描述
		private void FillRecDesc(string strID,out clsOutpatientRecipeDesc_VO clsVO)
		{
			clsVO=new clsOutpatientRecipeDesc_VO();
			long lngRes=clsDomain.m_lngGetRecDesc(strID,out clsVO);
			clsVO.m_strOutpatRecipeID=strID;
		}
		#endregion
		#region 过滤显示列表
		public void FilterRec(string strID)
		{
			if(objfrm.m_RecNo.Tag!=null)
			{
				int i=int.Parse(objfrm.m_RecNo.Tag.ToString());
				if(i<0)return;
				this.m_lngFillDescVO(clsRecVO[i].m_strOutpatRecipeID,out clsRecVO[i].objRecDesc);
			}
			if(strID=="All")
			{
				objfrm.m_Memo.Clear();
				objfrm.m_Memo.Enabled=false;
				objfrm.m_Dosage.Clear();
				objfrm.m_Dosage.Visible=false;
				objfrm.m_Cooking.Visible=false;
			}
			else
			{
				getDesc(clsRecVO[objfrm.m_RecNo.SelectedIndex].objRecDesc);
			}
			objfrm.m_RecNo.Tag=objfrm.m_RecNo.SelectedIndex;
			if(NoChange)
				return;
			//			setView(objfrm.dgWest,strID);
			//            setView(objfrm.dgCM,strID);
			//			setView(objfrm.dgChk,strID);
			//			setView(objfrm.dgTest,strID);
			//			setView(objfrm.dgOPS,strID);
			//			setView(objfrm.dgOther,strID);
		}
		private void getDesc(clsOutpatientRecipeDesc_VO clsVO)
		{
			this.NoChange=true;
			objfrm.m_Memo.Text=clsVO.m_strMemo;
			objfrm.m_Dosage.Text=clsVO.intDosage.ToString();
			objfrm.m_Cooking.CookID=clsVO.m_strCookingID;
			if(objfrm.m_tab.SelectedTab.Name=="tabCM")
			{
				objfrm.m_Dosage.Visible=true;
				objfrm.m_Cooking.Visible=true;
			}
			this.NoChange=false;
			return;
		}
		
		private void setView(exDataGrid exGrid,string strID)
		{
			DataView dv;
			string strFilter="RecID="+"'"+strID+"'";
			if(strID=="All")
				strFilter="";
			dv=new DataView(exGrid.DataSource);
			dv.RowFilter=strFilter;
			exGrid.SetDataView(dv);
		}
		#endregion
		public void m_FillPatRec(string strID) //填充病人处方
		{
			objfrm.Cursor=Cursors.WaitCursor;
			this.RegID="";
			if(strID==null)
			{
				this.m_SetWaitGrid(true);
				this.m_SetWaitGrid(false);
				objfrm.m_tab.SelectedIndex=0;
				objfrm.m_tab.Tag="tabWait";
				objfrm.m_currRec.Text="";
				objfrm.m_currRecA.Text="";
				objfrm.Cursor=Cursors.Default;
				return;
			}
			this.RegID=strID;
			if(strID=="")
			{
				objfrm.Cursor=Cursors.Default;
				return;
			}
			this.strPatID=objfrm.m_PatInfo.PatientID;
			m_FillRecList(); //填充处方和明细
			FillCaseHis();//填充病历
			if(objfrm.m_tab.SelectedIndex!=m_intIndex("tabWest"))
			{
				objfrm.m_tab.SelectedIndex=m_intIndex("tabWest");
				objfrm.m_tab.Tag="tabWest";
			}
			else
				objfrm.m_currRecA.Text=objfrm.dgWest.ColCount("Amount").ToString();
			objfrm.Cursor=Cursors.Default;
		}
		private int m_intIndex(string TabName)
		{
			for(int i1=0;i1<objfrm.m_tab.TabCount;i1++)
			{
				if(TabName==objfrm.m_tab.TabPages[i1].Name)
					return i1;
			}
			return 0;
		}
		
		#region 提取病历
		public void FillCaseHis()
		{
			long lngRes=0;
			clsOutpatientCaseHis_VO clsCase=new clsOutpatientCaseHis_VO();
			clsOutpatientDiagRec_VO clsDiag=new clsOutpatientDiagRec_VO();
			lngRes=clsDomain.m_lngFindPatCase(RegID,out clsCase,out clsDiag);
			if(lngRes<0)
				return;
//			objfrm.m_txtCureDesc.Text=clsCase.m_strDiagMemo;
//			objfrm.m_txtDiseDesc.Text=clsCase.m_strDiseaseMemo;
//			objfrm.m_txtCureResult.Text=clsCase.m_strDiagResult;
			objfrm.m_txtCureResult.Tag=clsCase.m_strCaseHisID;
			objfrm.m_txtCureDesc.Tag="";
			objfrm.txtDiagMain.m_mthSetNewText(clsCase.strDiagMain,clsCase.strDiagMain_XML);
			objfrm.txtDiagCurr.m_mthSetNewText(clsCase.strDiagCurr,clsCase.strDiagCurr_XML);
			objfrm.txtDiagHis.m_mthSetNewText(clsCase.strDiagHis,clsCase.strDiagHis_XML);
			objfrm.txtReMark.m_mthSetNewText(clsCase.strReMark,clsCase.strReMark_XML);
			objfrm.txtTreatment.m_mthSetNewText(clsCase.strTreatMent,clsCase.strTreatMent_XML);
			objfrm.txtAidCheck.m_mthSetNewText(clsCase.strAidCheck,clsCase.strAidCheck_XML);
			objfrm.txtDiag.m_mthSetNewText(clsCase.strDiag,clsCase.strDiag_XML);

			objfrm.m_txtDiagDesc.Text=clsDiag.m_strDiagMemo;
			objfrm.m_txtDiagPort.Text=clsDiag.m_strDiagImport;
			objfrm.m_txtCurePrin.Text=clsDiag.m_strCurePrinciple;
			objfrm.m_txtCureSTD.Text=clsDiag.m_strCureStd;
			objfrm.m_txtDefend.Text=clsDiag.m_strDefend;
			objfrm.m_txtDiagSTD.Text=clsDiag.m_strDiagStd;
			objfrm.m_txtDiagSTD.Tag=clsDiag.m_strOutpatientDiagRecID;
		}
		private void SaveCaseToVO(out clsOutpatientCaseHis_VO clsCase,
			out clsOutpatientDiagRec_VO clsDiag)
		{
			clsCase=new clsOutpatientCaseHis_VO();
			clsDiag=new clsOutpatientDiagRec_VO();

			clsDiag.m_strDiagDeptID=this.DepID;
			clsDiag.m_strDiagDrID=this.OperatorID;
			clsDiag.m_strPatientID=this.strPatID;
			clsDiag.m_strRecordEmpID=this.OperatorID;
			clsDiag.m_strRegisterID=RegID;
			clsDiag.m_strDiagMemo=objfrm.m_txtDiagDesc.Text;
			clsDiag.m_strDiagImport=objfrm.m_txtDiagPort.Text;
			clsDiag.m_strCurePrinciple=objfrm.m_txtCurePrin.Text;
			clsDiag.m_strCureStd=objfrm.m_txtCureSTD.Text;
			clsDiag.m_strDefend=objfrm.m_txtDefend.Text;
			clsDiag.m_strDiagStd=objfrm.m_txtDiagSTD.Text;
			if(objfrm.m_txtDiagSTD.Tag!=null)
				clsDiag.m_strOutpatientDiagRecID=objfrm.m_txtDiagSTD.Tag.ToString();

			if(objfrm.m_txtCureDesc.Tag.ToString()=="")
				return;
			clsCase.m_strDiagDeptID=this.DepID;
			clsCase.m_strDiagDrID=this.OperatorID;
			clsCase.m_strRecordEmpID=this.OperatorID;
			clsCase.m_strRegisterID=this.RegID;
			clsCase.m_strPatientID=strPatID;
//			clsCase.m_strDiagMemo=objfrm.m_txtCureDesc.Text;
//			clsCase.m_strDiseaseMemo=objfrm.m_txtDiseDesc.Text;
//			clsCase.m_strDiagResult=objfrm.m_txtCureResult.Text;
            clsCase.strDiagMain=objfrm.txtDiagMain.Text;
            clsCase.strDiagMain_XML=objfrm.txtDiagMain.m_strGetXmlText();
			clsCase.strDiagCurr=objfrm.txtDiagCurr.Text;
			clsCase.strDiagCurr_XML=objfrm.txtDiagCurr.m_strGetXmlText();
            clsCase.strDiagHis=objfrm.txtDiagHis.Text;
			clsCase.strDiagHis_XML=objfrm.txtDiagHis.m_strGetXmlText();
            clsCase.strReMark=objfrm.txtReMark.Text;
			clsCase.strReMark_XML=objfrm.txtReMark.m_strGetXmlText();
			clsCase.strTreatMent=objfrm.txtTreatment.Text;
			clsCase.strTreatMent_XML=objfrm.txtTreatment.m_strGetXmlText();
            clsCase.strAidCheck=objfrm.txtAidCheck.Text;
			clsCase.strAidCheck_XML=objfrm.txtAidCheck.m_strGetXmlText();
			clsCase.strDiag=objfrm.txtDiag.Text;
			clsCase.strDiag_XML=objfrm.txtDiag.m_strGetXmlText();
			


			if(objfrm.m_txtCureResult.Tag!=null)
				clsCase.m_strCaseHisID=objfrm.m_txtCureResult.Tag.ToString();

			
		}
		public long m_SaveCaseAndCure()
		{
			clsOutpatientCaseHis_VO clsCase=new clsOutpatientCaseHis_VO();
			clsOutpatientDiagRec_VO clsDiag=new clsOutpatientDiagRec_VO();
			long lngRes=0;
			SaveCaseToVO(out clsCase,out clsDiag);
			if(objfrm.m_txtCureDesc.Tag.ToString()!="")
				lngRes=clsDomain.m_lngSavePatCase(clsCase);
			if(lngRes<0)
				return lngRes;
			lngRes=clsDomain.m_lngSaveCureRec(clsDiag);
			return lngRes;
		}
		#endregion

		#region 删除病人处方明细
		public void m_Del()
		{
			string RecName=objfrm.m_tab.SelectedTab.Name;
			switch(RecName)
			{
				case "tabWest": //西药
					m_DelDetail(objfrm.dgWest,1);
					break;
				case "tabCM": //中药
					m_DelDetail(objfrm.dgCM,2);
					break;
				case "tabChk": //检验
					m_DelDetail(objfrm.dgChk,3);
					break;
				case "tabTest": //检查
					m_DelDetail(objfrm.dgTest,4);
					break;
				case "tabOPS": //手术
					m_DelDetail(objfrm.dgOPS,5);
					break;
				case "tabOther": //其它
					m_DelDetail(objfrm.dgOther,6);
					break;
			}
		}
		private void m_DelDetail(exDataGrid exGrid,int RecType)
		{
			if(exGrid.RowLock)
				return;
			if(MessageBox.Show("确认删除该项吗？","提示",MessageBoxButtons.YesNo)==DialogResult.No)
				return;
			long lngRes=0;
			if(exGrid.DataSource.Rows.Count==0)
				return;
			int row=exGrid.Row;
			string strID=exGrid.DataSource.Rows[row]["DetID"].ToString().Trim();
			string RecID=exGrid.DataSource.Rows[row]["RecID"].ToString().Trim();
			if(strID=="" || RecID=="")
			{
				exGrid.DataSource.Rows.Remove(exGrid.DataSource.Rows[row]);
			}
			else
			{
				lngRes=clsDomain.m_lngDelRecipeDet(strID,RecID,RecType);
				if(lngRes>=0)
				{
					exGrid.DataSource.Rows.Remove(exGrid.DataSource.Rows[row]);
					this.m_ChkMainRec(false);
				}
				else
					MessageBox.Show("删除处方明细失败，请联系管理员！","提示");
			}
			if(exGrid.DataSource.Rows.Count==0)
			{
				this.m_addDetail(exGrid);
				exGrid.IsDirty=false;
			}
		}
		#endregion
       
		#region 取消接诊
		public void m_UndoTake()
		{
		   
			if(objfrm.dgTake.Row>=objfrm.dgTake.Rows)
				return;
			string strID=objfrm.dgTake.Get_TextMatrix(objfrm.dgTake.Row,objfrm.dgTake.ColIndex("TakeID"));
			if(strID=="")
				return;
			string strRegID=objfrm.dgTake.Get_TextMatrix(objfrm.dgTake.Row,objfrm.dgTake.ColIndex("RegID"));
			if(strRegID=="")
				return;
			long lngRes=clsDomain.m_lngCheckMainRecipe(strRegID);
			if(lngRes>0) //存在处方
				return;
			lngRes=clsDomain.m_lngUndoTakeWait(strID,strRegID);
			if(lngRes>0)
			{
				this.RefreshWait(false);
				objfrm.m_tab.SelectedIndex=0;
				if(strRegID==this.RegID)
				{
					this.RegID="";
				}
			}
		}
		#endregion
		#region 验证挂号ID
		public void m_lngCheckReg(string strID)
		{
			DataTable dtResult=new DataTable();
			RegID=strID;
			string strSeqNo="";
			if(strID==null || strID.Trim()=="")
			{
				this.Clear();
				return ;
			}
			long lngRes=clsDomain.m_lngCheckPatRecipe(RegID,OperatorID,ref dtResult);
			if(dtResult.Rows.Count==0)
			{
				RegID="";
				objfrm.m_tab.SelectedIndex=0;
				MessageBox.Show("您没有查看该病人处方的权限！","提示");
				return;
			}
			if(dtResult.Rows[0]["pstatus"].ToString().Trim()=="1") //还没接诊
			{
				string strWaitID=dtResult.Rows[0]["ID"].ToString().Trim();
				string DocID=dtResult.Rows[0]["RegDocID"].ToString().Trim();
				string DepID=dtResult.Rows[0]["RegDepID"].ToString().Trim();
				string DepName=dtResult.Rows[0]["DepName"].ToString().Trim();
				string DocName=dtResult.Rows[0]["DocName"].ToString().Trim();
				string strMsg="确认接诊流水号为：" + strSeqNo + "，挂号日期为:" +dtResult.Rows[0]["RegDate"].ToString().Trim();
				strMsg=strMsg+ "/n挂号科室：" + DepName + "挂号医生：" +DocName + " ？";
				if(DocID==OperatorID) //是同一医生
				{
					this.m_accDiag(strWaitID);
					this.m_FillPatRec(strID);
				}
				else //不是同一医生
				{
					if(MessageBox.Show(strMsg,"提示",MessageBoxButtons.YesNo)==DialogResult.No)
					{
						RegID="";
						return;
					}
					else
					{
						this.m_accDiag(strWaitID);
						this.m_FillPatRec(RegID);
					}
				}
			}
			else if(dtResult.Rows[0]["pstatus"].ToString().Trim()=="1") //退号
			{
				MessageBox.Show("该号已退！","提示");
				RegID="";
			}
			else //已接诊
			{
				if(dtResult.Rows[0]["DiagDocID"].ToString().Trim()==OperatorID) //是该医生接诊
					this.m_FillPatRec(RegID);
				else
				{
					RegID="";
				}
			}
		}
		#endregion
		#region 检查处方的正确性
		public bool m_chekcItem(string RecType)
		{
			bool IsVail=false;
			int row=0;
			switch(RecType)
			{
				case "tabWest":
					row=this.m_checkCount(objfrm.dgWest);
					if(row>-1)
					{
						objfrm.m_tab.SelectedIndex=m_intIndex("tabWest");
						objfrm.dgWest.Col=objfrm.dgWest.ColIndex("Count");
						objfrm.dgWest.Row=row;
						objfrm.dgWest.Focus();
						IsVail=true;
					}
					break;
				case "tabCM":
					row=this.m_checkCount(objfrm.dgCM);
					if(row>-1)
					{
						objfrm.m_tab.SelectedIndex=m_intIndex("tabCM");
						objfrm.dgCM.Col=objfrm.dgCM.ColIndex("Count");
						objfrm.dgCM.Row=row;
						objfrm.dgCM.Focus();
						IsVail=true;
					}
					break;
					//				case "tabChk":
					//					row=this.m_checkCount(objfrm.dgChk);
					//					if(row>-1)
					//					{
					//						objfrm.m_tab.SelectedIndex=5;
					//						objfrm.dgChk.Col=objfrm.dgChk.ColIndex("Count");
					//						objfrm.dgChk.Row=row;
					//						objfrm.dgChk.Focus();
					//						IsVail=true;
					//					}
					//					break;
					//				case "tabTest":
					//					row=this.m_checkCount(objfrm.dgTest);
					//					if(row>-1)
					//					{
					//						objfrm.m_tab.SelectedIndex=6;
					//						objfrm.dgTest.Col=objfrm.dgTest.ColIndex("Count");
					//						objfrm.dgTest.Row=row;
					//						objfrm.dgTest.Focus();
					//						IsVail=true;
					//					}
					//					break;
					//				case "tabOPS":
					//					row=this.m_checkCount(objfrm.dgOPS);
					//					if(row>-1)
					//					{
					//						objfrm.m_tab.SelectedIndex=7;
					//						objfrm.dgOPS.Col=objfrm.dgOPS.ColIndex("Count");
					//						objfrm.dgOPS.Row=row;
					//						objfrm.dgOPS.Focus();
					//						IsVail=true;
					//					}
					//					break;
				case "tabOther":
					row=this.m_checkCount(objfrm.dgOther);
					if(row>-1)
					{
						objfrm.m_tab.SelectedIndex=m_intIndex("tabOther");
						objfrm.dgOther.Col=objfrm.dgOther.ColIndex("Count");
						objfrm.dgOther.Row=row;
						objfrm.dgOther.Focus();
						IsVail=true;
					}
					break;
			}
			return IsVail;
            
		}
		private int m_checkCount(exDataGrid exGrid)
		{
			string celltext="";
			for(int i1=0;i1<exGrid.Rows;i1++)
			{
				if(exGrid.Get_TextMatrix(i1,exGrid.ColIndex("ItemID"))=="")
				{
					exGrid.DataSource.Rows.Remove(exGrid.DataSource.Rows[i1]);
					continue;
				}
				celltext=exGrid.Get_TextMatrix(i1,exGrid.ColIndex("Count"));
				if(celltext=="" || celltext=="0")
				{
					MessageBox.Show("数量不能为空","提示");
					return i1;	
				}
			}
			return -1;
		}
		#endregion

		#region 填充药品
		public void m_FillInputItem(com.digitalwave.controls.ReturnItem sItem,exDataGrid exGrid)
		{
			if(sItem.ItemID=="")
				return;
			int row=exGrid.Row;
			if(this.m_CheckExist(sItem.ItemID,row,exGrid))
				return;
			exGrid.Set_TextMatrix(row,exGrid.ColIndex("ItemID"),sItem.ItemID);
			exGrid.Set_TextMatrix(row,exGrid.ColIndex("ItemCode"),sItem.ItemCode);
			exGrid.Set_TextMatrix(row,exGrid.ColIndex("ItemName"),sItem.ItemName);
			exGrid.Set_TextMatrix(row,exGrid.ColIndex("Price"),sItem.Price.ToString());
			exGrid.Set_TextMatrix(row,exGrid.ColIndex("Spec"),sItem.Spec);
			exGrid.Set_TextMatrix(row,exGrid.ColIndex("UnitID"),sItem.OPUnitID);
			exGrid.Set_TextMatrix(row,exGrid.ColIndex("UnitName"),sItem.OPUnitName);
			if(exGrid.Name=="dgWest" || exGrid.Name=="dgCM")
			{
				exGrid.Set_TextMatrix(row,exGrid.ColIndex("UsageID"),sItem.UsageID);
				exGrid.Set_TextMatrix(row,exGrid.ColIndex("UsageName"),sItem.UsageName);
			}
			exGrid.IsDirty=true;
			exGrid.SendNextCell();
		}
		private bool m_CheckExist(string strItemID,int row,exDataGrid exGrid)
		{
			bool IsExist=false;
			DataRow[] Drw=new DataRow[0] ;
			if(exGrid.Rows==1) 
				return false;
			string RecID=exGrid.Get_TextMatrix(row,exGrid.ColIndex("RecID"));
			string strFilter="RecID="+ "'"+RecID+"'"+" And ItemID="+ "'"+strItemID+"'"+"";
			Drw=exGrid.DataSource.Select(strFilter);
			if(Drw.Length==0) //不存在本张处方
			{
				strFilter="ItemID="+ "'"+strItemID+"'"+""; 
				Drw=exGrid.DataSource.Select(strFilter);
				if(Drw.Length==0) //不存在其它处方
					return false;
				else
				{
					if(MessageBox.Show("该项目已在上一处方开过，继续吗？","提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
						return false;
					else
						return true;
				}
			}
			else
			{
				MessageBox.Show("项目已存在！","提示");
				return true;
			}
			return IsExist;  
		} 
		#endregion

		#region 填充用法、频率
		public void m_FillUsage(string RecName)
		{
			switch (RecName)
			{
				case "tabWest":
					objfrm.dgWest.Set_TextMatrix(objfrm.dgWest.Row,objfrm.dgWest.ColIndex("UsageID"),objfrm.m_cboUsage.UsageID);
					objfrm.dgWest.Set_TextMatrix(objfrm.dgWest.Row,objfrm.dgWest.ColIndex("UsageName"),objfrm.m_cboUsage.UsageName);
					objfrm.dgWest.IsDirty=true;
					objfrm.dgWest.SendNextCell();
					break;
				case "tabCM":
					objfrm.dgCM.Set_TextMatrix(objfrm.dgCM.Row,objfrm.dgCM.ColIndex("UsageID"),objfrm.m_cboUsage.UsageID);
					objfrm.dgCM.Set_TextMatrix(objfrm.dgCM.Row,objfrm.dgCM.ColIndex("UsageName"),objfrm.m_cboUsage.UsageName);
					objfrm.dgCM.IsDirty=true;
					objfrm.dgCM.SendNextCell();
					break;
			}
		}
		public void m_FillFre()
		{
			objfrm.dgWest.Set_TextMatrix(objfrm.dgWest.Row,objfrm.dgWest.ColIndex("FreID"),objfrm.m_ctlFre.FreqID);
			objfrm.dgWest.Set_TextMatrix(objfrm.dgWest.Row,objfrm.dgWest.ColIndex("FreName"),objfrm.m_ctlFre.FreqName);
			objfrm.dgWest.Set_TextMatrix(objfrm.dgWest.Row,objfrm.dgWest.ColIndex("intFre"),objfrm.m_ctlFre.FreqUency.ToString());
			objfrm.dgWest.IsDirty=true;
			objfrm.dgWest.SendNextCell();
		}
		public void m_FillDep(string RecName)
		{
			switch(RecName)
			{
				case "tabChk":
					objfrm.dgChk.Set_TextMatrix(objfrm.dgChk.Row,objfrm.dgChk.ColIndex("DepName"),objfrm.ctlDep.DepName);
					objfrm.dgChk.Set_TextMatrix(objfrm.dgChk.Row,objfrm.dgChk.ColIndex("DepID"),objfrm.ctlDep.DepID);
					objfrm.dgChk.IsDirty=true;
					objfrm.dgChk.SendNextCell();
					break;
				case "tabTest":
					objfrm.dgTest.Set_TextMatrix(objfrm.dgTest.Row,objfrm.dgTest.ColIndex("DepName"),objfrm.ctlDep.DepName);
					objfrm.dgTest.Set_TextMatrix(objfrm.dgTest.Row,objfrm.dgTest.ColIndex("DepID"),objfrm.ctlDep.DepID);
					objfrm.dgTest.IsDirty=true;
					objfrm.dgTest.SendNextCell();
					break;
				case "tabOPS":
					objfrm.dgOPS.Set_TextMatrix(objfrm.dgOPS.Row,objfrm.dgOPS.ColIndex("DepName"),objfrm.ctlDep.DepName);
					objfrm.dgOPS.Set_TextMatrix(objfrm.dgOPS.Row,objfrm.dgOPS.ColIndex("DepID"),objfrm.ctlDep.DepID);
					objfrm.dgOPS.IsDirty=true;
					objfrm.dgOPS.SendNextCell();
					break; 
			}
		}
		#endregion 

		#region 保存改变过的描述到VO
		public void m_SaveDescToVO()
		{
			if(this.NoChange) return;
			if(objfrm.m_RecNo.SelectItemValue!="All")
			{
				int i=objfrm.m_RecNo.SelectedIndex;
				if(i<0) return;
				this.m_lngFillDescVO(clsRecVO[i].m_strOutpatRecipeID,out clsRecVO[i].objRecDesc);
			}
		}
		#endregion
		#region 跳到下一格
		public void SendNextCell(string RecName)
		{
			switch(RecName)
			{
				case "tabWest":
					if(objfrm.dgWest.Col==objfrm.dgWest.ColIndex("ItemCode"))
						return;
					else
						objfrm.dgWest.SendNextCell();
					break;
				case "tabCM":
					if(objfrm.dgCM.Col==objfrm.dgCM.ColIndex("ItemCode"))
						return;
					else
						objfrm.dgCM.SendNextCell();
					break;
				case "tabChk":
					if(objfrm.dgChk.Col==objfrm.dgChk.ColIndex("ItemCode") ||
						objfrm.dgChk.Col==objfrm.dgChk.ColIndex("DepName"))
						return;
					else
						objfrm.dgChk.SendNextCell();
					break;
				case "tabTest":
					if(objfrm.dgTest.Col==objfrm.dgTest.ColIndex("ItemCode") ||
						objfrm.dgTest.Col==objfrm.dgTest.ColIndex("DepName"))
						return;
					else
						objfrm.dgTest.SendNextCell();
					break;
				case "tabOPS":
					if(objfrm.dgOPS.Col==objfrm.dgOPS.ColIndex("ItemCode")||
						objfrm.dgOPS.Col==objfrm.dgOPS.ColIndex("DepName"))
						return;
					else
						objfrm.dgOPS.SendNextCell();
					break;
				case "tabOther":
					if(objfrm.dgOther.Col==objfrm.dgOther.ColIndex("ItemCode"))
						return;
					else
						objfrm.dgOther.SendNextCell();
					break;
			}
		}
		#endregion
	}
}
