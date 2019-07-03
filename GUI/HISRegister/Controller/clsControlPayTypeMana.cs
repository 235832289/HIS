using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
using com.digitalwave.controls.datagrid;
using System.Data;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsControlPayTypeMana 的摘要说明。
	/// </summary>
	public class clsControlPayTypeMana: com.digitalwave.GUI_Base.clsController_Base
	{
		public clsControlPayTypeMana()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.clsDomainControl_Register Domain=new clsDomainControl_Register();
		com.digitalwave.iCare.gui.HIS.frmPayTypeMana m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmPayTypeMana)frmMDI_Child_Base_in;
		}
		#endregion

		#region 变量
		/// <summary>
		/// 保存病人类型
		/// </summary>
		DataTable dtPayType=new DataTable();
		/// <summary>
		/// 保存项目明细
		/// </summary>
		DataTable dtItemID=new DataTable();
		/// <summary>
		/// 保存收费项目数据
		/// </summary>
		DataTable tbItem=new DataTable();
		/// <summary>
		/// 保存符合条件的项目数据
		/// </summary>
		DataTable tbItemFind=new DataTable();
		/// <summary>
		/// 标识是否新增数据
		/// </summary>
		int isAddNew=1;
		#endregion

		#region 初始化窗口
		public void m_lngFrmLoad()
		{
			this.m_objViewer.comboBox1.SelectedIndex=0;
			this.m_objViewer.comboBox2.SelectedIndex=0;
			this.m_objViewer.comboBox3.SelectedIndex=0;
			long lngRes=Domain.m_lngGetAllPatientPayType(out dtPayType);
			if(lngRes==1)
			{
				DataRow InserRow=dtPayType.NewRow();
				InserRow["PAYTYPENO_VCHR"]="0000";
				InserRow["PAYTYPENAME_VCHR"]="公用";
				InserRow["strISUSING"]="正常";
				InserRow["MEMO_VCHR"]="公用";
				InserRow["PAYTYPEID_CHR"]="0000";
				dtPayType.Rows.InsertAt(InserRow,0);
				this.m_objViewer.m_DgPayType.m_mthSetDataTable(dtPayType);
				this.m_objViewer.m_DgPayType.CurrentCell=new DataGridCell(0,0);
				this.m_objViewer.m_DgPayType.m_mthSelectARow(0);
				m_lngGetAndShowItem();
			}
			else
			{
				MessageBox.Show("获取数据出错！","系统提示");
			}
			clsDomainConrol_ConcertreCipe m_objDoMain=new clsDomainConrol_ConcertreCipe();
			m_objDoMain.m_mthFindMedicine(out tbItem,null);
		}
		#endregion

		#region 根据ID获取项目明细
		public void m_lngGetAndShowItem()
		{
			string strPayType=dtPayType.Rows[this.m_objViewer.m_DgPayType.CurrentCell.RowNumber]["PAYTYPEID_CHR"].ToString().Trim();
			long lngRes=Domain.m_lngGetItemByPayID(strPayType,out dtItemID);
			this.m_objViewer.m_DgItemDe.m_mthDeleteAllRow();
			if(lngRes==1&&dtItemID.Rows.Count>0)
			{
				for(int i1=0;i1<dtItemID.Rows.Count;i1++)
				{
					this.m_objViewer.m_DgItemDe.m_mthAppendRow();
					this.m_objViewer.m_DgItemDe[i1,0]=dtItemID.Rows[i1]["ITEMCODE_VCHR"].ToString().Trim();
					this.m_objViewer.m_DgItemDe[i1,1]=dtItemID.Rows[i1]["ITEMNAME_VCHR"].ToString().Trim();
					this.m_objViewer.m_DgItemDe[i1,2]=dtItemID.Rows[i1]["ITEMSPEC_VCHR"].ToString().Trim();
					this.m_objViewer.m_DgItemDe[i1,3]=dtItemID.Rows[i1]["ItemType"].ToString().Trim();
					this.m_objViewer.m_DgItemDe[i1,4]=dtItemID.Rows[i1]["ITEMOPUNIT_CHR"].ToString().Trim();
					this.m_objViewer.m_DgItemDe[i1,5]=dtItemID.Rows[i1]["ITEMPRICE_MNY"].ToString().Trim();
					this.m_objViewer.m_DgItemDe[i1,6]=dtItemID.Rows[i1]["QTY_DEC"].ToString().Trim();
					this.m_objViewer.m_DgItemDe[i1,7]=dtItemID.Rows[i1]["ITEMID_CHR"].ToString().Trim();
					this.m_objViewer.m_DgItemDe[i1,8]=dtItemID.Rows[i1]["strISRICH"].ToString().Trim();

					this.m_objViewer.m_DgItemDe[i1,9]=dtItemID.Rows[i1]["REGISTER"].ToString().Trim();
					this.m_objViewer.m_DgItemDe[i1,10]=dtItemID.Rows[i1]["RECIPEFLAG"].ToString().Trim();
					this.m_objViewer.m_DgItemDe[i1,11]=dtItemID.Rows[i1]["EXPERT"].ToString().Trim();
				}
				this.m_objViewer.m_DgItemDe.CurrentCell=new DataGridCell(0,0);
				this.m_objViewer.m_DgItemDe.m_mthSelectARow(0);
			}

		}
		#endregion

		#region 查找项目数据
		public void FindItemData()
		{
			if(tbItem.Rows.Count>0)
			{
				try
				{
					tbItemFind=tbItem.Clone();
				}
				catch
				{
				}
				string strFind=this.m_objViewer.m_txtFindTtem.Text.Trim();
				if(strFind=="")
				{
					MessageBox.Show("请输入查询条件！","Icare",MessageBoxButtons.OK,MessageBoxIcon.Stop);
					return;
				}
				tbItemFind.Rows.Clear();
				
				int Number=0;
				bool IsFind=false;
				if(this.m_objViewer.m_txtFindTtem.Text.Trim().IndexOf("%")==0)
				{
					IsFind=Number!=0;
				}
				else
				{
					IsFind=Number==0;
				}
				string fidCode=this.m_objViewer.m_txtFindTtem.Text.Trim().ToUpper();
				string strSele="";

				strSele="ITEMCODE_VCHR like '"+fidCode+"%' or ITEMENGNAME_VCHR like '"+fidCode+"%' or ITEMNAME_VCHR like '"+fidCode+"%' or ITEMPYCODE_CHR like '"+fidCode+"%' or ITEMWBCODE_CHR like '"+fidCode+"%'";
				DataRow[] seleRow=tbItem.Select(strSele);
				if(seleRow.Length>0)
				{
					for(int i1=0;i1<seleRow.Length;i1++)
					{
						m_mthAddNewRow(ref tbItemFind,seleRow[i1]);
					}
				}
				if(tbItemFind.Rows.Count>0)
				{
					this.m_objViewer.m_DgItem.m_mthSetDataTable(tbItemFind);
					this.m_objViewer.m_DgItem.BeginUpdate();
                    //for(int i1=0;i1<tbItemFind.Rows.Count;i1++)
                    //{
                    //    if(tbItemFind.Rows[i1]["medicineid_chr"].ToString()!=""&&tbItemFind.Rows[i1]["NOQTYFLAG_INT"].ToString()=="1")
                    //    {
                    //        for(int f2=0;f2<8;f2++)
                    //        {
                    //            this.m_objViewer.m_DgItem.m_mthFormatCell(i1,f2,this.m_objViewer.m_DgItem.Font,System.Drawing.Color.White,System.Drawing.Color.Red);
                    //        }
                    //    }
                    //}
					this.m_objViewer.m_DgItem.EndUpdate();
					this.m_objViewer.m_DgItem.Tag="tbItemFind";
					this.m_objViewer.m_DgItem.m_mthClearSelectedRow();
					this.m_objViewer.m_DgItem.m_mthSelectARow(0);
					this.m_objViewer.m_DgItem.CurrentCell=new DataGridCell(0,0);
					this.m_objViewer.pnldg.Top=this.m_objViewer.groupBox2.Top-this.m_objViewer.pnldg.Height-3;
					this.m_objViewer.pnldg.Left=this.m_objViewer.groupBox2.Left;
					this.m_objViewer.pnldg.Width=this.m_objViewer.panel1.Width;
					this.m_objViewer.panel1.Height=this.m_objViewer.panel1.Height-this.m_objViewer.pnldg.Height+18;
					this.m_objViewer.pnldg.Visible=true;
					this.m_objViewer.m_DgItem.Focus();
					return;
				}
			
			}

		}
		#endregion

		#region 为表构造一行
		/// <summary>
		/// 为表构造一行
		/// </summary>
		/// <param name="?"></param>
		private void m_mthAddNewRow(ref DataTable tbItemFind,DataRow rows)
		{
			DataRow newRow=tbItemFind.NewRow();
			newRow["ITEMCODE_VCHR"]=rows["ITEMCODE_VCHR"];
			newRow["ItemType"]=rows["ItemType"];
			newRow["ITEMNAME_VCHR"]=rows["ITEMNAME_VCHR"];
			newRow["ITEMID_CHR"]=rows["ITEMID_CHR"];
			newRow["ITEMSPEC_VCHR"]=rows["ITEMSPEC_VCHR"];
			newRow["ITEMENGNAME_VCHR"]=rows["ITEMENGNAME_VCHR"];
			newRow["ITEMOPUNIT_CHR"]=rows["ITEMOPUNIT_CHR"];
			newRow["ITEMPRICE_MNY"]=rows["ITEMPRICE_MNY"];
			newRow["ITEMOPINVTYPE_CHR"]=rows["ITEMOPINVTYPE_CHR"];
			newRow["ITEMCATID_CHR"]=rows["ITEMCATID_CHR"];
			newRow["SELFDEFINE_INT"]=rows["SELFDEFINE_INT"];
			newRow["ITEMOPCALCTYPE_CHR"]=rows["ITEMOPCALCTYPE_CHR"];
			newRow["NOQTYFLAG_INT"]=rows["NOQTYFLAG_INT"];
			newRow["MEDICINEID_CHR"]=rows["MEDICINEID_CHR"];
			newRow["itemipunit_chr"]=rows["itemipunit_chr"];
			newRow["submoney"]=rows["submoney"];
			newRow["opchargeflg_int"]=rows["opchargeflg_int"];
			tbItemFind.Rows.Add(newRow);
		}

		#endregion

		#region 选择项目数据
		public void seleItem()
		{
			if(this.m_objViewer.m_DgItem.CurrentCell.RowNumber>-1)
			{
				if((string)this.m_objViewer.m_DgItem.Tag=="tbItem")
				{
					DataRow seleRow=tbItem.NewRow();
					seleRow=tbItem.Rows[this.m_objViewer.m_DgItem.CurrentCell.RowNumber];
					fillToTxtBox(seleRow);
				}
				else
				{
					DataRow seleRow=tbItemFind.NewRow();
					seleRow=tbItemFind.Rows[this.m_objViewer.m_DgItem.CurrentCell.RowNumber];
					fillToTxtBox(seleRow);
				}
			}
			this.m_objViewer.panel1.Height=442;
			this.m_objViewer.pnldg.Visible=false;
			this.m_objViewer.m_txtFindTtem.Text="";
			this.m_objViewer.m_txtFindTtem.Tag=null;
			this.m_objViewer.m_txtTQY.Focus();

		}
		#endregion

		#region 把选中的项目明细填充到txtBox
		private void fillToTxtBox(DataRow seleRow)
		{
			this.m_objViewer.m_txtItemName.Text=seleRow["ITEMNAME_VCHR"].ToString();
			this.m_objViewer.m_txtItemName.Tag=seleRow["ITEMID_CHR"].ToString();
			this.m_objViewer.m_txtSpace.Text=seleRow["ITEMSPEC_VCHR"].ToString();
			this.m_objViewer.m_txtSpace.Tag=seleRow["ITEMCODE_VCHR"].ToString();
			this.m_objViewer.m_txtType.Text=seleRow["ItemType"].ToString();
			this.m_objViewer.m_txtunit.Text=seleRow["ITEMOPUNIT"].ToString();
			this.m_objViewer.m_txtUnprir.Text=seleRow["ITEMPRICE_MNY"].ToString();
			this.m_objViewer.m_txtUnprir.Tag=seleRow["ISRICH_INT"].ToString();
		}
		#endregion

		#region 把选中要修改的数据填充到TxtBox
		public void ModifyfillToTxtBox()
		{
			isAddNew=0;
			this.m_objViewer.m_btnSave.Text="修改(&A)";
			this.m_objViewer.m_txtItemName.Text=this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,1].ToString().Trim();
			this.m_objViewer.m_txtItemName.Tag=this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,7].ToString().Trim();
			this.m_objViewer.m_txtSpace.Text=this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,2].ToString().Trim();
			this.m_objViewer.m_txtSpace.Tag=this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,0].ToString().Trim();
			this.m_objViewer.m_txtType.Text=this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,3].ToString().Trim();
			this.m_objViewer.m_txtunit.Text=this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,4].ToString().Trim();
			this.m_objViewer.m_txtUnprir.Text=this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,5].ToString().Trim();
			this.m_objViewer.m_txtTQY.Text=this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,6].ToString().Trim();
			if(this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,8].ToString().Trim()=="是")
			    this.m_objViewer.m_txtUnprir.Tag="1";
			else
				 this.m_objViewer.m_txtUnprir.Tag="0";

			this.m_objViewer.comboBox1.Text=this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,9].ToString().Trim();
			this.m_objViewer.comboBox2.Text=this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,10].ToString().Trim();
			this.m_objViewer.comboBox3.Text=this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,11].ToString().Trim();
		}
		#endregion

		#region 保存数据
		public void m_lngSave()
		{
			if(isAddNew==1)
			{
				long lngRes=Domain.m_lngAddNewItem(dtPayType.Rows[this.m_objViewer.m_DgPayType.CurrentCell.RowNumber]["PAYTYPEID_CHR"].ToString().Trim(),(string)this.m_objViewer.m_txtItemName.Tag,Convert.ToInt32(this.m_objViewer.m_txtTQY.Text.Trim()),this.m_objViewer.comboBox1.SelectedIndex,this.m_objViewer.comboBox2.SelectedIndex,this.m_objViewer.comboBox3.SelectedIndex);
				if(lngRes==1)
				{
					this.m_objViewer.m_DgItemDe.m_mthAppendRow();
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.RowCount-1,0]=(string)this.m_objViewer.m_txtSpace.Tag;
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.RowCount-1,1]=this.m_objViewer.m_txtItemName.Text;
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.RowCount-1,2]=this.m_objViewer.m_txtSpace.Text;
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.RowCount-1,3]=this.m_objViewer.m_txtType.Text;
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.RowCount-1,4]=this.m_objViewer.m_txtunit.Text;
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.RowCount-1,5]=this.m_objViewer.m_txtUnprir.Text;
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.RowCount-1,6]=this.m_objViewer.m_txtTQY.Text.Trim();
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.RowCount-1,7]=(string)this.m_objViewer.m_txtItemName.Tag;
					if((string)this.m_objViewer.m_txtUnprir.Tag=="1")
						this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.RowCount-1,8]="是";
					else
						this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.RowCount-1,8]="否";
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.RowCount-1,9]=this.m_objViewer.comboBox1.Text;
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.RowCount-1,10]=this.m_objViewer.comboBox2.Text.Trim();
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.RowCount-1,11]=(string)this.m_objViewer.comboBox3.Text;
					m_lngClear();
				}
			}
			else
			{
				long lngRes=Domain.m_lngModifyItem(dtPayType.Rows[this.m_objViewer.m_DgPayType.CurrentCell.RowNumber]["PAYTYPEID_CHR"].ToString().Trim(),this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,7].ToString().Trim(),(string)this.m_objViewer.m_txtItemName.Tag,Convert.ToInt32(this.m_objViewer.m_txtTQY.Text.Trim()),this.m_objViewer.comboBox1.SelectedIndex,this.m_objViewer.comboBox2.SelectedIndex,this.m_objViewer.comboBox3.SelectedIndex);
				if(lngRes==1)
				{
					this.m_objViewer.m_DgItemDe.m_mthAppendRow();
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,0]=(string)this.m_objViewer.m_txtSpace.Tag;
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,1]=this.m_objViewer.m_txtItemName.Text;
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,2]=this.m_objViewer.m_txtSpace.Text;
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,3]=this.m_objViewer.m_txtType.Text;
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,4]=this.m_objViewer.m_txtunit.Text;
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,5]=this.m_objViewer.m_txtUnprir.Text;
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,6]=this.m_objViewer.m_txtTQY.Text.Trim();
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,7]=(string)this.m_objViewer.m_txtItemName.Tag;
					if((string)this.m_objViewer.m_txtUnprir.Tag=="1")
						this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,8]="是";
					else
						this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,8]="否";
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,9]=this.m_objViewer.comboBox1.Text;
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,10]=this.m_objViewer.comboBox2.Text.Trim();
					this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,11]=(string)this.m_objViewer.comboBox3.Text;
					m_lngClear();
				}
			}
		}
		#endregion

		#region 清空
		public void m_lngClear()
		{
			isAddNew=1;
			this.m_objViewer.comboBox1.SelectedIndex=0;
			this.m_objViewer.comboBox2.SelectedIndex=0;
			this.m_objViewer.comboBox3.SelectedIndex=0;
			this.m_objViewer.m_btnSave.Text="新增(&A)";
			this.m_objViewer.m_txtFindTtem.Clear();
			this.m_objViewer.m_txtItemName.Clear();
			this.m_objViewer.m_txtSpace.Clear();
			this.m_objViewer.m_txtType.Clear();
			this.m_objViewer.m_txtunit.Clear();
			this.m_objViewer.m_txtUnprir.Clear();
			this.m_objViewer.m_txtTQY.Clear();
		}

		#endregion

		#region 删除项目明细
		public void m_lngDeleItem()
		{
			if(this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber>-1)
			{
				long lngRes=Domain.m_lngDeleItem(dtPayType.Rows[this.m_objViewer.m_DgPayType.CurrentCell.RowNumber]["PAYTYPEID_CHR"].ToString().Trim(),this.m_objViewer.m_DgItemDe[this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber,7].ToString().Trim());
				if(lngRes==1)
				{
					this.m_objViewer.m_DgItemDe.m_mthDeleteRow(this.m_objViewer.m_DgItemDe.CurrentCell.RowNumber);
					m_lngClear();
				}
			}
		}
		#endregion

	}
}
