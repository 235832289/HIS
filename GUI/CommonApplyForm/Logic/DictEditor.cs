using System;
using System.Windows.Forms;
using com.digitalwave.GLS_WS.UI;
using System.Reflection;
using System.Data;
using System.Collections;
using com.digitalwave.GLS_WS.ApplyReportServer;

namespace com.digitalwave.GLS_WS.Logic
{
	/// <summary>
	/// frmDictmanage的控制层
	/// </summary>
	public class DictEditor
	{
        private frmDictManage frmUI;
		private ListView lvType;
		private ListView lvPart;
		private ListView lvAim;
//		private DataGrid gridPart;
//		private DataGrid gridAim;
		private DataProcess dp;		
		private DataTable dtPart;
		private DataTable dtAim;
		private TextBox m_txtPart;
		private TextBox m_txtAssiCode;
		private TextBox m_txtAim;
        private TextBox m_txtPinYinCode;
        private TextBox m_txtWuBiCode;

		public DictEditor(frmDictManage fm)
		{
			frmUI = fm;
            dp = (DataProcess)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(DataProcess));
			
			//binding controls
			this.lvType   = (ListView)frmUI.GetControl("lvType");
//			this.gridPart = (DataGrid)frmUI.GetControl("gridPart");
//			this.gridAim  = (DataGrid)frmUI.GetControl("gridAim");
			this.lvPart = (ListView)frmUI.GetControl("m_lsvPartList");
			this.lvAim = (ListView)frmUI.GetControl("m_lsvAimList");
			this.m_txtPart = (TextBox)frmUI.GetControl("m_txtPart");
			this.m_txtAssiCode = (TextBox)frmUI.GetControl("m_txtAssCode");
			this.m_txtAim = (TextBox)frmUI.GetControl("m_txtAim");
            this.m_txtPinYinCode = (TextBox)frmUI.GetControl("m_txtPinYinCode");
            this.m_txtWuBiCode = (TextBox)frmUI.GetControl("m_txtWuBiCode");

			BindEvents();
		}

		private void BindEvents()
		{
			frmUI.Load += new EventHandler(Initial);
//			frmUI.Closing += new System.ComponentModel.CancelEventHandler(frmUI_Closing);
			frmUI.GetControl("btnAddType").Click += new EventHandler(AddType);
			frmUI.GetControl("btnDelType").Click += new EventHandler(DelType);
//			frmUI.GetControl("btnSave").Click	 += new EventHandler(Save);		
			(frmUI.GetObject("miNewType") as MenuItem).Click  += new EventHandler(AddType);	//新增类型菜单
			(frmUI.GetObject("miDelType") as MenuItem).Click  += new EventHandler(DelType);	//删除类型菜单	
			(frmUI.GetObject("miDelPart") as MenuItem).Click  += new EventHandler(miDelPart_Click);//删除行菜单
			(frmUI.GetObject("miDelAim")  as MenuItem).Click  += new EventHandler(miDelAim_Click); //删除行菜单
			lvType.AfterLabelEdit += new LabelEditEventHandler(lvType_AfterLabelEdit);
			lvType.SelectedIndexChanged += new EventHandler(lvType_SelectedIndexChanged);	
		}

		/// <summary>
		/// 初始化窗体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Initial(object sender, EventArgs e)
		{
			DataTable ds;			
			
			try
			{
				//check types
				ds = dp.SqlSelect("select * from AR_APPLY_TYPELIST where Deleted != 1");
				lvType.Items.Clear();

				foreach(DataRow dr in ds.Rows)
				{
					ListViewItem item = new ListViewItem(dr["TypeText"].ToString());
					item.SubItems.Add(dr["TypeID"].ToString());
					this.lvType.Items.Add(item);
				}	

				//Check Parts
//				ds = dp.SqlSelect("select * from AR_APPLY_PARTLIST  where Deleted != 1 order by PartID");	
//				this.dtPart = ds;
//				this.dtPart.Columns["Deleted"].DefaultValue = 0;
//				this.gridPart.DataSource = this.dtPart;

				//Check Aims
//				ds = dp.SqlSelect("select * from AR_APPLY_AIMLIST  where Deleted != 1 Order by AimID");
//				this.dtAim = ds;
//				this.dtAim.Columns["Deleted"].DefaultValue = 0;
//				this.gridAim.DataSource = this.dtAim;
	
		
				if (lvType.Items.Count > 0)
				{
					lvType.Items[0].Selected = true;
					lvType.Focus();
				}
			}
			catch{}
		}
		
		/// <summary>
		/// 增加新的检查类型
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddType(object sender, EventArgs e)
		{			
			string newType = frmUI.ShowInput("请输入新的检查类别");

			if (newType == "")
			{
				return;
			}
			
			foreach(ListViewItem item in lvType.Items)
			{
				if (item.Text.Trim().ToLower() == newType.ToLower().Trim())
				{
					frmUI.ShowAlert("输入的类型已存在!");
					return;
				}
			}

			try
			{
				string nextID = dp.GetNextID("AR_APPLY_TYPELIST","TypeID");
				string sql = string.Format("insert into AR_APPLY_TYPELIST (TypeID, TypeText,Deleted) values ({0},'{1}',0)"
					, nextID, newType);
				if (dp.SqlExecute(sql))
				{
					ListViewItem item = new ListViewItem(newType);
					item.SubItems.Add(nextID);
					lvType.Items.Add(item);
					item.Selected = true;
				}
			}
			catch{}
		}

		private void Refresh()
		{
			Initial(null, null);
		}

		/// <summary>
		/// 删除新的检查类型
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DelType(object sender, EventArgs e)
		{
			if (lvType.SelectedItems.Count < 1)
			{
				frmUI.ShowAlert("请选择相应的检查类型!");
				return;
			}

			if (DialogResult.Yes != frmUI.ShowPrompt("删除一个检查类型,将删除相应的检查部位或检查目的数据,你确认要继续吗?"))
			{
				return;
			}

			try
			{
				string id  = lvType.SelectedItems[0].SubItems[1].Text;		
				string sql = "";
				//执行伪删除
				sql += "BEGIN \n";
				sql += "update AR_APPLY_TYPELIST set Deleted = 1 where TypeID = " + id + ";\n";
				sql += "update AR_APPLY_AIMLIST  set Deleted = 1 where TypeID = " + id + ";\n";
				sql += "update AR_APPLY_PARTLIST set deleted = 1 where TypeID = " + id + ";\n";
				sql += "END;";

				if (dp.SqlExecute(sql))
				{
					lvType.SelectedItems[0].Remove();	
					this.Refresh();
				}
			}
			catch{}
		}

		#region 旧，无用部分
		/// <summary>
		/// 保存两个dataGrid
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
//		private void Save(object sender, EventArgs e)
//		{
//			gridPart.BindingContext[dtPart].EndCurrentEdit();
//			gridAim.BindingContext[dtAim].EndCurrentEdit();
//			
//			int idPart = int.Parse( dp.GetNextID("AR_APPLY_PARTLIST","PartID") );
//			int idAim  = int.Parse( dp.GetNextID("AR_APPLY_AIMLIST", "AimID") );
//
//			ArrayList rowsToDelete = new ArrayList();
//
//			foreach(DataRow dr in dtPart.Rows)
//			{
//				if (dr.RowState != DataRowState.Deleted)
//				{
//					if (dr["PartID"] is DBNull)
//					{
//						dr["PartID"] = idPart;
//						idPart++;
//					}
//
//					if (dr["PartName"] is DBNull) rowsToDelete.Add(dr);
//					if (dr["ASSISTCODE_CHR"] is DBNull) rowsToDelete.Add(dr);
//				}				
//			}
//
//			foreach(DataRow dr in dtAim.Rows)
//			{
//				if (dr.RowState != DataRowState.Deleted)
//				{
//					if (dr["AimID"] is DBNull)
//					{
//						dr["AimID"] = idAim;
//						idAim++;
//					}
//
//					if (dr["AimText"] is DBNull) rowsToDelete.Add(dr);
//				}
//			}
//
//			foreach(DataRow dr in rowsToDelete)
//			{
//				dr.RejectChanges();
//			}
//
//			if(dtPart.DataSet.GetChanges() != null)
//			{
//				foreach(DataRow dr in dtPart.DataSet.GetChanges().Tables[0].Rows)
//				{
//					string strCheckAssistCode = dr["ASSISTCODE_CHR"].ToString().Trim();
//					
//					string strCheckTypeID = dr["TYPEID"].ToString().Trim();
//					string strCheckPartName	= "";
//					string strCheckTypeName = "";
//					if(CheckAssistCode(strCheckAssistCode,strCheckTypeID,out strCheckPartName,out strCheckTypeName))
//					{
//						MessageBox.Show("新输入的助记码与"+strCheckTypeName+"的部位或组织--"+strCheckPartName+"的助记码重复，请重新输入！");
//						return;
//					}
//				}
//			}
//
//			if (dp.Update("AR_APPLY_PARTLIST", dtPart.DataSet.GetChanges()) )
//			{
//				dtPart.AcceptChanges();
//			}
//
//			if (dp.Update("AR_APPLY_AIMLIST", dtAim.DataSet.GetChanges()) )
//			{
//				dtAim.AcceptChanges();
//			}
//
//			if (lvType.SelectedIndices.Count > 0)
//			{
//				int i = lvType.SelectedIndices[0];
//				this.Refresh();
//				lvType.Items[i].Selected = true;
//				lvType.Focus();
//			}
//		}
		#endregion

		/// <summary>
		/// 保存的"检查类型"的更改
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lvType_AfterLabelEdit(object sender, LabelEditEventArgs e)
		{
			if (e.Label == "")
			{
				e.CancelEdit = true;
				return;
			}

			IEnumerator ie = lvType.Items.GetEnumerator();
			if (ie.MoveNext())
			{
				if ( (ie.Current as ListViewItem).Text.Trim() == e.Label)
				{
					e.CancelEdit = true;
					frmUI.ShowAlert("指定的类型已经存在!");
					return;
				}
			}

			string id  = lvType.Items[e.Item].SubItems[1].Text;
			string sql = "update AR_APPLY_TYPELIST set TypeText = '" + e.Label + "' where TypeID = " + id;
			dp.SqlExecute(sql);
		}

		private void lvType_SelectedIndexChanged(object sender, EventArgs e)
		{			
			#region 旧
//			dtPart.DefaultView.RowFilter = "TypeID = " + id;
//			dtAim.DefaultView.RowFilter  = "TypeID = " + id;
//
//			dtPart.Columns["TypeID"].DefaultValue = int.Parse(id);			
//			dtAim.Columns["TypeID"].DefaultValue  = int.Parse(id);
			#endregion
			m_txtPart.Text = "";
			m_txtPart.Tag = null;
			m_txtAim.Text = "";
			m_txtAim.Tag = null;
			m_txtAssiCode.Text = "";
            this.m_txtPinYinCode.Text = "";
            this.m_txtWuBiCode.Text = "";
			m_mthGetPartList();
			m_mthGetAimList();
		}
        /// <summary>
        /// 获取部位表信息
        /// </summary>
		public void m_mthGetPartList()
		{
			if (lvType.SelectedItems.Count <1)
			{
				return;
			}

			string id  = lvType.SelectedItems[0].SubItems[1].Text;

			string SqlGetPart = @"select * from AR_APPLY_PARTLIST where TypeID = '"+id+"' and DELETED='0'";
			DataTable dtPartList = dp.SqlSelect(SqlGetPart);
			lvPart.Items.Clear();
			if(dtPartList != null && dtPartList.Rows.Count > 0)
			{
				for(int i=0; i<dtPartList.Rows.Count; i++)
				{
					ListViewItem lPart = lvPart.Items.Add(dtPartList.Rows[i]["PARTNAME"].ToString().Trim());
                    lPart.SubItems.AddRange(new string[] { dtPartList.Rows[i]["ASSISTCODE_CHR"].ToString().Trim(), dtPartList.Rows[i]["PARTID"].ToString().Trim(), dtPartList.Rows[i]["TYPEID"].ToString().Trim(), dtPartList.Rows[i]["PYCODE_VCHR"].ToString().Trim(), dtPartList.Rows[i]["WBCODE_VCHR"].ToString().Trim() });
				}
			}
		}
        /// <summary>
        /// 获取检查目的
        /// </summary>
		public void m_mthGetAimList()
		{
			if (lvType.SelectedItems.Count <1)
			{
				return;
			}

			string id  = lvType.SelectedItems[0].SubItems[1].Text;
			string SqlGetAim = @"select * from AR_APPLY_AIMLIST where TypeID = '"+id+"' and DELETED='0'";
			DataTable dtAimList = dp.SqlSelect(SqlGetAim);
			
			lvAim.Items.Clear();
			
			if(dtAimList != null && dtAimList.Rows.Count > 0)
			{
				for(int j=0; j<dtAimList.Rows.Count; j++)
				{
					ListViewItem lAim = lvAim.Items.Add(dtAimList.Rows[j]["AIMTEXT"].ToString().Trim());
					lAim.SubItems.AddRange(new string[]{dtAimList.Rows[j]["AIMID"].ToString().Trim(), dtAimList.Rows[j]["TYPEID"].ToString().Trim()});
				}
			}
		}

		private void frmUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
//			gridPart.BindingContext[dtPart].EndCurrentEdit();
//			gridAim.BindingContext[dtAim].EndCurrentEdit();

//			if ( !(dtPart.GetChanges() == null && dtAim.GetChanges() == null) )
//			{
//				DialogResult d = frmUI.ShowPrompt("数据已改变,你要保存吗?");
//				
//				if ( d == DialogResult.Yes)
//				{
//					this.Save(null,null);
//				}
//				else
//				{
//					e.Cancel = (d == DialogResult.Cancel);
//				}                
//			}
		}

		/// <summary>
		/// 删除部位数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void miDelPart_Click(object sender, EventArgs e)
		{
//			DeleteRows(gridPart, ref dtPart);	
		}		

		/// <summary>
		/// 删除目的数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void miDelAim_Click(object sender, EventArgs e)
		{
//			DeleteRows(gridAim, ref dtAim);
		}

		private void DeleteRows(DataGrid grid, ref DataTable dt)
		{
			ArrayList list = new ArrayList();
			
			for(int i = dt.DefaultView.Count - 1; i>=0; i--)
			{
				if (grid.IsSelected(i))
				{
					list.Add(dt.DefaultView[i]);
				}
			}
		
			foreach(DataRowView d in list)
			{
				d.Delete();
			}		
		}

		/// <summary>
		/// 判断数据库中是否已存在该助记码,true表示已存在
		/// </summary>
		/// <param name="strAssistCode"></param>
		/// <param name="strTypeID"></param>
		/// <param name="strPartName"></param>
		/// <param name="strTypeName"></param>
		/// <returns></returns>
		private bool CheckAssistCode(string strAssistCode,string strTypeID,out string strPartName,out string strTypeName)
		{
			DataTable ds;
			strPartName = "";
			strTypeName = "";
			ds = dp.SqlSelect(@"select b.typetext, a.PARTNAME, a.ASSISTCODE_CHR
								from AR_APPLY_PARTLIST a, AR_APPLY_TYPELIST b
								where ASSISTCODE_CHR = '"+strAssistCode+@"'
									and a.typeid = b.typeid");
			if(ds.Rows.Count > 0)
			{
				strPartName = ds.Rows[0]["PARTNAME"].ToString().Trim();
				strTypeName = ds.Rows[0]["TYPETEXT"].ToString().Trim();
				return true;
			}
			else
				return false;
		}

		public void m_mthAddPartList(string strPartName,string strAssisCode,string strTypeID,string m_strPY,string m_strWB)
		{
			string nextID = dp.GetNextID("AR_APPLY_PARTLIST","PARTID");
            string strSQLAddPart = @"insert into AR_APPLY_PARTLIST (PARTID,PARTNAME,TYPEID,DELETED,ASSISTCODE_CHR,PYCODE_VCHR,WBCODE_VCHR)
									values('" +nextID+"','"+strPartName+"','"+strTypeID+"','0','"+strAssisCode+"','"+m_strPY+"','"+m_strWB+"')";
			if(!dp.SqlExecute(strSQLAddPart))
			{
				MessageBox.Show("添加失败！");
				return;
			}
		}

		public void m_mthModifyPartList(string strPartName,string strAssisCode,string strPartID,string m_strPY, string m_strWB)
		{
			string strSQLModPart = @"update AR_APPLY_PARTLIST set PARTNAME='"+strPartName+"', ASSISTCODE_CHR='"+strAssisCode+"',PYCODE_VCHR='"+m_strPY+"',WBCODE_VCHR='"+m_strWB+"' where PARTID='"+strPartID+"'";
			if(!dp.SqlExecute(strSQLModPart))
			{
				MessageBox.Show("修改失败！");
				return;
			}
		}

		public void m_mthDelPartList(string strPartID)
		{
			string strSQLModPart = @"update AR_APPLY_PARTLIST set DELETED='1' where PARTID='"+strPartID+"'";
			if(!dp.SqlExecute(strSQLModPart))
			{
				MessageBox.Show("删除失败！");
				return;
			}
		}

		public void m_mthAddAimList(string strAimText,string strTypeID)
		{
			string nextID = dp.GetNextID("AR_APPLY_AIMLIST","AIMID");
			string strSQLAddPart = @"insert into AR_APPLY_AIMLIST (AIMID,AIMTEXT,TYPEID,DELETED)
									values('"+nextID+"','"+strAimText+"','"+strTypeID+"','0')";
			if(!dp.SqlExecute(strSQLAddPart))
			{
				MessageBox.Show("添加失败！");
				return;
			}
		}

		public void m_mthModifyAimList(string strAimText,string strAimID)
		{
			string strSQLModPart = @"update AR_APPLY_AIMLIST set AIMTEXT='"+strAimText+"' where AIMID='"+strAimID+"'";
			if(!dp.SqlExecute(strSQLModPart))
			{
				MessageBox.Show("修改失败！");
				return;
			}
		}

		public void m_mthDelAimList(string strAimID)
		{
			string strSQLModPart = @"update AR_APPLY_AIMLIST set DELETED='1' where AIMID='"+strAimID+"'";
			if(!dp.SqlExecute(strSQLModPart))
			{
				MessageBox.Show("删除失败！");
				return;
			}
		}
	}
}
