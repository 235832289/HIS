using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
using System.Data;
using com.digitalwave.controls.datagrid;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsControlRegisterDetail 的摘要说明。
	/// </summary>
	public class clsControlRegisterDetail:com.digitalwave.GUI_Base.clsController_Base
	{
		private clsDomainControl_RegisterDetail objServer =null;
		public DataTable m_DT = new DataTable();
		public clsControlRegisterDetail()
		{
			objServer=new clsDomainControl_RegisterDetail();
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 设置窗体对象
		public com.digitalwave.iCare.gui.HIS.frmRegisterDetail m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmRegisterDetail)frmMDI_Child_Base_in;
		}
		#endregion

/// <summary>
/// 加载数据
/// </summary>
		public void m_mthLoadData()
		{
			objServer.m_lngGetRegisterdetail();
		DataTable dt=null;
		long retstr=objServer.m_lngLoadData(out dt);
			this.m_DT = dt;
			m_Formatdtg();
			//m_FormatLsv();
//			if(dt!=null&&dt.Rows.Count >0)
//			{
//					m_objViewer.listView1.Items.Clear();
//			//在这里添加填充listView代码
//				for(int i=0;i<dt.Rows.Count;i++)
//				{
//					ListViewItem lv=new ListViewItem(dt.Rows[i]["REGISTERTYPEID_CHR"].ToString().Trim());
//					lv.SubItems.Add(dt.Rows[i]["REGISTERTYPENAME_VCHR"].ToString().Trim());//1
//					lv.SubItems.Add(dt.Rows[i]["CHARGEID_CHR"].ToString().Trim());//2
//					lv.SubItems.Add(dt.Rows[i]["CHARGENAME_CHR"].ToString().Trim());//3
//					lv.SubItems.Add(dt.Rows[i]["PAYTYPEID_CHR"].ToString().Trim());//4
//					lv.SubItems.Add(dt.Rows[i]["PAYTYPENAME_VCHR"].ToString().Trim());//5
//					lv.SubItems.Add(dt.Rows[i]["PAYMENT_MNY"].ToString().Trim());//6
//					lv.SubItems.Add(dt.Rows[i]["DISCOUNT_DEC"].ToString().Trim());//7
//					m_objViewer.listView1.Items.Add(lv);
//				}
//				if(m_objViewer.listView1.Items.Count>0)
//				{
//				m_objViewer.listView1.Items[0].Selected=true;
//				}
//			}

		}
		public void m_FormatLsv()
		{
			//this.m_objViewer.listView1.Items.re
			string[] paytypeid = new string[this.m_DT.Rows.Count];
			this.m_objViewer.listView1.Clear();
			
			this.m_objViewer.listView1.Columns.Add("挂号类型",80,HorizontalAlignment.Left);
			this.m_objViewer.listView1.Columns.Add("挂号费别",80,HorizontalAlignment.Left);
			string chname = "";
			string registertype = "";
			string registercharge = "";
			int i = 0;
			foreach(DataRow dr in this.m_DT.Rows)
			{
				ColumnHeader ch = new ColumnHeader();
				if(chname != dr["PAYTYPEID_CHR"].ToString())
				{
					ch.Text = dr["PAYTYPENAME_VCHR"].ToString();
					ch.Width = 100;
					//ch.
					if(paytypeid[0] == dr["PAYTYPEID_CHR"].ToString().Trim())break;
					this.m_objViewer.listView1.Columns.Add(ch);
					chname = ch.Text;
					paytypeid[i] = dr["PAYTYPEID_CHR"].ToString().Trim();
					chname = dr["PAYTYPEID_CHR"].ToString();
					i++;
				}
			}
			ListViewItem lv=new ListViewItem();
			ListViewItem lv1=new ListViewItem();
			foreach(DataRow dr in this.m_DT.Rows)
			{
				if(registercharge != dr["CHARGEID_CHR"].ToString())
				{
					if(lv.SubItems.Count>1)
					{
						this.m_objViewer.listView1.Items.Add(lv);
						this.m_objViewer.listView1.Items.Add(lv1);
					}
					lv=new ListViewItem();
					lv1=new ListViewItem();
					registercharge = dr["CHARGEID_CHR"].ToString();
					lv.SubItems.Add(dr["CHARGENAME_CHR"].ToString().Trim());
					lv1.Text = "";
					lv1.SubItems.Add("优惠");
					if(registertype != dr["REGISTERTYPEID_CHR"].ToString())
					{
						lv.Text = dr["REGISTERTYPENAME_VCHR"].ToString();
						registertype = dr["REGISTERTYPEID_CHR"].ToString();
					}
					else
					{
						lv.Text = "";
					}
				}
				else
				{
					//lv.SubItems.Add("");
				}				
				lv.SubItems.Add(dr["PAYMENT_MNY"].ToString());
				lv1.SubItems.Add(dr["DISCOUNT_DEC"].ToString());
			}
			if(lv.SubItems.Count>1)
			{
				this.m_objViewer.listView1.Items.Add(lv);
				this.m_objViewer.listView1.Items.Add(lv1);
			}
		}
		//enum modify{registertype,charge,ment,count};
		//com.digitalwave.iCare.ValueObject.clsRegchargeType_VO clsreg = new 
		string[] paytypeid;//转成列后按顺序记录其ID
		string[,] lvID;//按顺序记录每一行的ID
		string[,] modifyID = new string[0,0];
		public void m_Formatdtg()
		{
			((System.ComponentModel.ISupportInitialize)(this.m_objViewer.m_dtgdetail)).BeginInit();
			//this.m_objViewer.listView1.Items.re
			paytypeid = new string[this.m_DT.Rows.Count];
			this.m_objViewer.listView1.Clear();
			this.m_objViewer.m_dtgdetail.Columns.Add("挂号类型","挂号类型");
			this.m_objViewer.m_dtgdetail.Columns.Add("挂号费别","挂号费别");
			((clsColumnInfo)this.m_objViewer.m_dtgdetail.Columns[0]).ColumnWidth = 100;
			((clsColumnInfo)this.m_objViewer.m_dtgdetail.Columns[0]).ReadOnly = true;
			((clsColumnInfo)this.m_objViewer.m_dtgdetail.Columns[1]).ColumnWidth = 100;
			((clsColumnInfo)this.m_objViewer.m_dtgdetail.Columns[1]).ReadOnly = true;
			string chname = "";
			string registertype = "";
			string registercharge = "";
			int i = 0;
			foreach(DataRow dr in this.m_DT.Rows)
			{
				clsColumnInfo ch = new clsColumnInfo();
				if(chname != dr["PAYTYPEID_CHR"].ToString())
				{
					
					if(paytypeid[0] == dr["PAYTYPEID_CHR"].ToString().Trim())break;
					this.m_objViewer.m_dtgdetail.Columns.Add(dr["PAYTYPENAME_VCHR"].ToString(),dr["PAYTYPENAME_VCHR"].ToString());
					((clsColumnInfo)this.m_objViewer.m_dtgdetail.Columns[i+2]).ColumnWidth = 100;
					chname = dr["PAYTYPENAME_VCHR"].ToString();
					paytypeid[i] = dr["PAYTYPEID_CHR"].ToString().Trim();
					chname = dr["PAYTYPEID_CHR"].ToString();
					i++;
				}
			}
			try
			{
				this.m_objViewer.m_dtgdetail.AllowAddNew = true;
				this.m_objViewer.m_dtgdetail.AllowDelete = false;
				this.m_objViewer.m_dtgdetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
					| System.Windows.Forms.AnchorStyles.Left) 
					| System.Windows.Forms.AnchorStyles.Right)));
				this.m_objViewer.m_dtgdetail.AutoAppendRow = true;
				this.m_objViewer.m_dtgdetail.AutoScroll = true;
				this.m_objViewer.m_dtgdetail.BackColor = System.Drawing.Color.White;
				this.m_objViewer.m_dtgdetail.CaptionText = "";
				this.m_objViewer.m_dtgdetail.CaptionVisible = false;
				this.m_objViewer.m_dtgdetail.ColumnHeadersVisible = true;
				this.m_objViewer.m_dtgdetail.Font = new System.Drawing.Font("宋体", 10.5F);
				this.m_objViewer.m_dtgdetail.FullRowSelect = false;
				this.m_objViewer.m_dtgdetail.Location = new System.Drawing.Point(0, 0);
				this.m_objViewer.m_dtgdetail.Name = "m_dtgdetail";
				this.m_objViewer.m_dtgdetail.ReadOnly = false;
				this.m_objViewer.m_dtgdetail.RowHeadersVisible = true;
				this.m_objViewer.m_dtgdetail.RowHeaderWidth = 35;
				this.m_objViewer.m_dtgdetail.Size = new System.Drawing.Size(816, 440);
				this.m_objViewer.m_dtgdetail.TabIndex = 9;
				this.m_objViewer.m_dtgdetail.m_evtDataGridTextBoxKeyPress +=new clsDGTextKeyPressEventHandler(m_dtgdetail_m_evtDataGridTextBoxKeyPress);
				this.m_objViewer.m_dtgdetail.m_evtDataGridTextBoxKeyDown +=new clsDGTextKeyEventHandler(m_dtgdetail_m_evtDataGridTextBoxKeyDown);
				this.m_objViewer.m_dtgdetail.m_evtCurrentCellChanged += new System.EventHandler(this.m_dtgdetail_m_evtCurrentCellChanged);
			//	this.m_objViewer.m_dtgdetail.m_evtCurrentCellChanged += new System.EventHandler(this.m_dtgdetail_m_evtCurrentCellChanged);
				this.m_objViewer.m_dtgdetail.Validated += new System.EventHandler(this.m_dtgdetail_Validating);
				this.m_objViewer.m_dtgdetail.AllowAddNew = false;
				
				this.m_objViewer.Controls.Add(this.m_objViewer.m_dtgdetail);
				((System.ComponentModel.ISupportInitialize)(this.m_objViewer.m_dtgdetail)).EndInit();
			}
			catch{}
			string[] lv=new string[0];
			string[] lv1=new string[0];
			lvID = new string[this.m_DT.Rows.Count,this.m_objViewer.m_dtgdetail.Columns.Count];
			i = 0;
			int i1 = 0;
			this.m_objViewer.m_dtgdetail.m_mthDeleteAllRow();
			foreach(DataRow dr in this.m_DT.Rows)
			{
				if(registercharge != dr["CHARGEID_CHR"].ToString())
				{
					lv=new string[this.m_objViewer.m_dtgdetail.Columns.Count];
					lv1=new string[this.m_objViewer.m_dtgdetail.Columns.Count];
					if(registertype != dr["REGISTERTYPEID_CHR"].ToString())
					{
						lv[i1] = dr["REGISTERTYPENAME_VCHR"].ToString();
						registertype = dr["REGISTERTYPEID_CHR"].ToString();
					}
					else
					{
						lv[i1] = "";
					}
					lvID[i,i1] = registertype;
					lv1[i1] = "";
					i1++;
					registercharge = dr["CHARGEID_CHR"].ToString();
					lv[i1]=dr["CHARGENAME_CHR"].ToString().Trim();						
					lv1[i1] = "优惠";	
					lvID[i,i1] = registercharge;
				}
				i1++;	
				lvID[i,i1] = paytypeid[i1-2];
				lv[i1] = dr["PAYMENT_MNY"].ToString();
				lv1[i1] = Convert.ToString(decimal.Parse(dr["DISCOUNT_DEC"].ToString())*100)+"%";
				
				if(lv.Length <= i1+1)
				{
					this.m_objViewer.m_dtgdetail.m_mthAppendRow((object[])lv);
					this.m_objViewer.m_dtgdetail.m_mthAppendRow((object[])lv1);
				//	int result = 0;
//					Math.DivRem(i,2,out result);
//					if(result == 0)
//					{
						
//					}
					i1 = 0;
					i++;
					this.m_objViewer.m_dtgdetail.BeginUpdate();
					for(int z=0;z<this.m_objViewer.m_dtgdetail.Columns.Count;z++)
					{
						this.m_objViewer.m_dtgdetail.m_mthFormatCell(i*2-1,z,this.m_objViewer.m_dtgdetail.Font,System.Drawing.Color.Wheat,System.Drawing.Color.Black);
					}
					this.m_objViewer.m_dtgdetail.EndUpdate();
				}
			}	
			for(int col=2;col<this.m_objViewer.m_dtgdetail.Columns.Count;col++)
			{
				((clsColumnInfo)this.m_objViewer.m_dtgdetail.Columns[col]).DataGridTextBoxColumn.TextBox.TextChanged +=new EventHandler(TextBox_TextChanged);
				//((clsColumnInfo)this.m_objViewer.m_dtgdetail.Columns[col]).DataGridTextBoxColumn.TextBox.sele +=new KeyEventHandler(TextBox_KeyUp);
			}
			
		}
		RegisterDetailVo[] clsModifyVo = new RegisterDetailVo[0];
		int x;
		int y;
		public void m_GetModify()
		{
			if(!isModify) return;
			if(this.m_objViewer.m_dtgdetail[x,1].ToString() == "优惠"
				&& int.Parse(System.Text.RegularExpressions.Regex.Replace(this.m_objViewer.m_dtgdetail[x,y].ToString(),"%",""))>100)
			{
				MessageBox.Show("优惠不能超过100%！");
				this.m_objViewer.m_dtgdetail.Focus();
				this.m_objViewer.m_dtgdetail.CurrentCell = new DataGridCell(x,y);
				return;
			}
			int result;
			for(int z=0;z<this.clsModifyVo.Length;z++)
			{
				if(this.clsModifyVo[z].chargeid == this.lvID[x/2,1]
					&& this.clsModifyVo[z].typeid == this.lvID[x/2,0]
					&& this.clsModifyVo[z].payid == this.lvID[x/2,y])
				{
					result = 0;
					Math.DivRem(x,2,out result);
					if(result == 0)
					{
						clsModifyVo[z].ment = this.m_objViewer.m_dtgdetail[x,y].ToString();
						clsModifyVo[z].cont = this.m_objViewer.m_dtgdetail[x+1,y].ToString();
					}
					else
					{
						clsModifyVo[z].ment = this.m_objViewer.m_dtgdetail[x-1,y].ToString();
						clsModifyVo[z].cont = this.m_objViewer.m_dtgdetail[x,y].ToString();
					}
					return;
				}
			}
			int i = this.clsModifyVo.Length;
			RegisterDetailVo[] temp = new RegisterDetailVo[i+1];
			if(this.clsModifyVo.Length>0)
				this.clsModifyVo.CopyTo(temp,0);
			temp[i] = new RegisterDetailVo();
			temp[i].typeid = this.lvID[x/2,0];
			temp[i].chargeid = this.lvID[x/2,1];
			temp[i].payid = this.lvID[x/2,y];
			result = 0;
			Math.DivRem(x,2,out result);
			if(result == 0)
			{
				temp[i].ment = this.m_objViewer.m_dtgdetail[x,y].ToString();
				temp[i].cont = this.m_objViewer.m_dtgdetail[x+1,y].ToString();
			}
			else
			{
				temp[i].ment = this.m_objViewer.m_dtgdetail[x-1,y].ToString();
				temp[i].cont = this.m_objViewer.m_dtgdetail[x,y].ToString();
			}
			this.clsModifyVo = temp;
		}
		bool isModify = false;
		public void m_dtgdetail_m_evtDataGridTextBoxKeyPress(object sender,com.digitalwave.controls.datagrid.clsDGTextKeyPressEventArgs e)
		{
			x = this.m_objViewer.m_dtgdetail.CurrentCell.RowNumber;
			y = this.m_objViewer.m_dtgdetail.CurrentCell.ColumnNumber;		
			if(((clsColumnInfo)this.m_objViewer.m_dtgdetail.Columns[y]).ReadOnly) return;
			this.m_objViewer.m_dtgdetail.m_mthFormatCell(x,y,this.m_objViewer.m_dtgdetail.Font,System.Drawing.Color.Red,System.Drawing.Color.Black);
			this.isModify = true;
			
		}
		public void m_dtgdetail_m_evtDataGridTextBoxKeyDown(object sender,com.digitalwave.controls.datagrid.clsDGTextKeyEventArgs e)
		{
			
			if(e.m_intColNumber < 2) return;
			//MessageBox.Show(e.KeyCode.ToString()+"  "+e.KeyData.ToString()+"  "+e.KeyValue.ToString());
			if((this.m_objViewer.m_dtgdetail[e.m_intRowNumber,1].ToString() == "优惠"
				&& ((clsColumnInfo)this.m_objViewer.m_dtgdetail.Columns[e.m_intColNumber]).DataGridTextBoxColumn.TextBox.SelectionStart == e.m_strText.Length)
				|| ((clsColumnInfo)this.m_objViewer.m_dtgdetail.Columns[e.m_intColNumber]).DataGridTextBoxColumn.TextBox.SelectedText.IndexOf("%")>=0
				|| (e.KeyCode == Keys.Delete && ((clsColumnInfo)this.m_objViewer.m_dtgdetail.Columns[e.m_intColNumber]).DataGridTextBoxColumn.TextBox.SelectionStart == e.m_strText.Length-1))
			{
				((clsColumnInfo)this.m_objViewer.m_dtgdetail.Columns[e.m_intColNumber]).DataGridTextBoxColumn.TextBox.ReadOnly = true;
				return;
			}
			
			if(e.KeyCode == Keys.D0 ||
				e.KeyCode == Keys.D1 ||
				e.KeyCode == Keys.D2 ||
				e.KeyCode == Keys.D3 ||
				e.KeyCode == Keys.D4 ||
				e.KeyCode == Keys.D5 ||
				e.KeyCode == Keys.D6 ||
				e.KeyCode == Keys.D7 ||
				e.KeyCode == Keys.D8 ||
				e.KeyCode == Keys.D9 ||
				e.KeyCode == Keys.NumPad0 ||
				e.KeyCode == Keys.NumPad1 ||
				e.KeyCode == Keys.NumPad2 ||
				e.KeyCode == Keys.NumPad3 ||
				e.KeyCode == Keys.NumPad4 ||
				e.KeyCode == Keys.NumPad5 ||
				e.KeyCode == Keys.NumPad6 ||
				e.KeyCode == Keys.NumPad7 ||
				e.KeyCode == Keys.NumPad8 ||
				e.KeyCode == Keys.NumPad9 ||
				e.KeyCode == Keys.Decimal ||
				e.KeyCode == Keys.OemPeriod ||
				e.KeyCode == Keys.Back ||
				e.KeyCode == Keys.Delete)
			{
				if((e.KeyCode == Keys.Decimal ||
					e.KeyCode == Keys.OemPeriod) && e.m_strText.IndexOf(".")>=0)
				{
					((clsColumnInfo)this.m_objViewer.m_dtgdetail.Columns[e.m_intColNumber]).DataGridTextBoxColumn.TextBox.ReadOnly = true;
					return;
				}
				
				((clsColumnInfo)this.m_objViewer.m_dtgdetail.Columns[e.m_intColNumber]).DataGridTextBoxColumn.TextBox.ReadOnly = false;
			}
			else
			{
				((clsColumnInfo)this.m_objViewer.m_dtgdetail.Columns[e.m_intColNumber]).DataGridTextBoxColumn.TextBox.ReadOnly = true;
			}
		}
		public void m_dtgdetail_Validating(object sender,System.EventArgs e)
		{
			this.m_objViewer.m_dtgdetail.CurrentCell = new DataGridCell(0,0);
			//m_GetModify();
		}
		public void m_dtgdetail_m_evtCurrentCellChanged(object sender,System.EventArgs e)
		{
			m_GetModify();
		}
		public void TextBox_TextChanged(object sender,System.EventArgs e)
		{
//			if(this.m_objViewer.m_dtgdetail[x,1].ToString() == "优惠")
//			{
//				//this.m_objViewer.m_dtgdetail[x,y] = this.m_objViewer.m_dtgdetail[x,y].ToString().IndexOf("%")
//					//System.Text.RegularExpressions.Regex.Replace(this.m_objViewer.m_dtgdetail[x,y].ToString(),"%","")+"%";
//			}
		}
		public void TextBox_KeyUp(object shender,System.Windows.Forms.KeyEventArgs e)
		{
			
		}
		public void m_mthSave()
		{
			for(int i=0;i<this.clsModifyVo.Length;i++)
			{
				string ID =clsModifyVo[i].typeid;//挂号类型ID
				string ID2 =clsModifyVo[i].chargeid;//费种ID
				string ID3 =clsModifyVo[i].payid;//身份ID
				string strPAYMENT_MNY =clsModifyVo[i].ment;//费用
				string strDISCOUNT_DEC =Convert.ToString(decimal.Parse(clsModifyVo[i].cont.Trim(new char[]{'%'}))/100);//费用比例
				long retstr=objServer.m_lngSave(ID,ID2,ID3,strPAYMENT_MNY,strDISCOUNT_DEC);
				if(retstr<=0)
				{
					MessageBox.Show("对不起,保存失败!","ICare");
				}
			}
		//	this.m_objViewer.m_dtgdetail.m_mthFormatReset();
			this.clsModifyVo = new RegisterDetailVo[0];
//			#region 
//			if(this.m_objViewer.listView1.SelectedItems.Count>0)
//			{
//			string ID =m_objViewer.listView1.SelectedItems[0].SubItems[0].Text.Trim();//挂号类型ID
//			string ID2 =m_objViewer.listView1.SelectedItems[0].SubItems[2].Text.Trim();//费种ID
//			string ID3 =m_objViewer.listView1.SelectedItems[0].SubItems[4].Text.Trim();//身份ID
//            string strPAYMENT_MNY =m_objViewer.m_txtPAYMENT_MNY.Text.Trim();//费用
//            string strDISCOUNT_DEC =m_objViewer.m_txtDISCOUNT_DEC.Text.Trim();//费用比例
//			long retstr=objServer.m_lngSave(ID,ID2,ID3,strPAYMENT_MNY,strDISCOUNT_DEC);
//				if(retstr<=0)
//				{
//					MessageBox.Show("对不起,保存失败!","ICare");
//				}
//				else
//				{
//					m_objViewer.listView1.SelectedItems[0].SubItems[6].Text=m_objViewer.m_txtPAYMENT_MNY.Text.Trim();
//					m_objViewer.listView1.SelectedItems[0].SubItems[7].Text=m_objViewer.m_txtDISCOUNT_DEC.Text.Trim();
//				}
//
//			}
//			#endregion
		}

		public void m_lockTextbox()
		{
//			TextBox tb = new TextBox();
//			tb.Location.X = this.m_objViewer.listView1.SelectedItems[0].SubItems[0].
		}
	}	
}
