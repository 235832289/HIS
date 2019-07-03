using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsControlChargeCat 的摘要说明。
	/// </summary>
	public class clsControlFeeType:com.digitalwave.GUI_Base.clsController_Base
	{
		public clsControlFeeType()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			clsDomain=new clsDomainControl_ChargeItem();
		}
		clsDomainControl_ChargeItem clsDomain;
		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmFeeType m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmFeeType)frmMDI_Child_Base_in;
		}
		#endregion

		#region 获取费用类别列表
		public void m_GetFeeTypeList()
		{
			m_objViewer.m_lvw.Items.Clear();
			clsChargeItemEXType_VO[] objResult;
			string strFlag=this.GetFlag();
			long lngRes=clsDomain.m_GetEXType(strFlag,out objResult);
			if(lngRes>0 && objResult.Length>0)
			{
				ListViewItem lvw;
				for(int i1=0;i1<objResult.Length;i1++)
				{
					lvw=new ListViewItem(objResult[i1].m_strTypeID.Trim());
					lvw.SubItems.Add(objResult[i1].m_intSORTCODE_INT.ToString());
					lvw.SubItems.Add(objResult[i1].m_strTypeName);
					lvw.SubItems.Add(objResult[i1].m_strUSERCODE_CHR);
					lvw.SubItems.Add(objResult[i1].m_decGOVTOPCHARGE_MNY.ToString());
					lvw.Tag=objResult[i1].m_strTypeID;
					m_objViewer.m_lvw.Items.Add(lvw);
				}
			}
			if(m_objViewer.m_lvw.Items.Count>0)
				m_objViewer.m_lvw.Items[0].Selected=true;
		}
		#endregion

		#region 保存
		public void m_lngSave()
		{
//			if(m_objViewer.m_lvw.SelectedItems.Count!=1)
//			{
//				return;
//			}

			if(m_objViewer.txtID.Text.Trim()=="")
			{
				m_ephHandler.m_mthAddControl(m_objViewer.txtID);
				m_ephHandler.m_mthShowControlsErrorProvider();
				m_ephHandler.m_mthClearControl();
				m_objViewer.txtID.Focus();

				return;
			}
			
			if(this.m_objViewer.m_txtName.Tag!=null)
			{
				for(int i=0;i<this.m_objViewer.m_lvw.Items.Count;i++)
				{
					if(this.m_objViewer.m_txtName.Tag.ToString().Trim()==this.m_objViewer.m_lvw.Items[i].SubItems[0].Text.Trim())
					{
						this.m_objViewer.m_lvw.Items[i].Selected=true;
						break;
					}
				}
				for(int i=0;i<this.m_objViewer.m_lvw.Items.Count;i++)
				{
					if(i==this.m_objViewer.m_lvw.SelectedIndices[0])
					{
						continue;
					}
					if(this.m_objViewer.txtID.Text.Trim()==m_objViewer.m_lvw.Items[i].SubItems[0].Text.Trim())
					{
						MessageBox.Show("ID已经存在,请选择另一个ID！","提示");
						this.m_objViewer.txtID.Select();
						return;
					}
					
				}
			
			}
			else
			{
				for(int i=0;i<this.m_objViewer.m_lvw.Items.Count;i++)
				{
					if(this.m_objViewer.txtID.Text.Trim()==m_objViewer.m_lvw.Items[i].SubItems[0].Text.Trim())
					{
						MessageBox.Show("ID已经存在,请选择另一个ID！","提示");
						this.m_objViewer.txtID.Select();
						return;
					}
				}
			}
		
			
			
			if(m_objViewer.m_txtSORTCODE.Text.Trim()=="")
			{
				m_ephHandler.m_mthAddControl(m_objViewer.m_txtSORTCODE);
				m_ephHandler.m_mthShowControlsErrorProvider();
				m_ephHandler.m_mthClearControl();
				m_objViewer.m_txtSORTCODE.Focus();

				return;
			}
			if(m_objViewer.m_txtName.Text.Trim()=="")
			{
				m_ephHandler.m_mthAddControl(m_objViewer.m_txtName);
				m_ephHandler.m_mthShowControlsErrorProvider();
				m_ephHandler.m_mthClearControl();
				m_objViewer.m_txtName.Focus();
				return;
			}
			
			if(m_objViewer.m_textUSERCODE.Text.Trim()=="")
			{
				m_ephHandler.m_mthAddControl(m_objViewer.m_textUSERCODE);
				m_ephHandler.m_mthShowControlsErrorProvider();
				m_ephHandler.m_mthClearControl();
				m_objViewer.m_textUSERCODE.Focus();
				return;
			}
			long lngRes=0;
			string strID="";
			clsChargeItemEXType_VO objResult=new clsChargeItemEXType_VO();
//			if(m_objViewer.m_txtName.Tag!=null)
			objResult.m_strTypeID=m_objViewer.txtID.Text.Trim();
			objResult.m_strTypeName=m_objViewer.m_txtName.Text.Trim();
			objResult.m_intFlag=int.Parse(this.GetFlag());
			objResult.m_strUSERCODE_CHR=m_objViewer.m_textUSERCODE.Text.Trim();
			objResult.m_intSORTCODE_INT=int.Parse(m_objViewer.m_txtSORTCODE.Text.Trim());
			objResult.m_decGOVTOPCHARGE_MNY=0;
			if(this.m_objViewer.txtLimit.Text.Trim()!="")
			{
			objResult.m_decGOVTOPCHARGE_MNY=decimal.Parse(this.m_objViewer.txtLimit.Text.Trim());
			}
			if(m_objViewer.m_txtName.Tag==null) //新增
			{
				
				lngRes=clsDomain.m_lngAddEXType(objResult);
				if(lngRes>0)
				{
					
					ListViewItem lvw=new ListViewItem(objResult.m_strTypeID);
					lvw.SubItems.Add(objResult.m_intSORTCODE_INT.ToString());
					lvw.SubItems.Add(objResult.m_strTypeName);
					lvw.SubItems.Add(objResult.m_strUSERCODE_CHR);
					lvw.SubItems.Add(objResult.m_decGOVTOPCHARGE_MNY.ToString());
					lvw.Tag=strID;
					m_objViewer.m_lvw.Items.Add(lvw);
					this.m_objViewer.m_txtName.Tag=objResult.m_strTypeID;
				}
			}
			else
			{
				
				lngRes=clsDomain.m_lngDoUpdEXType(objResult,m_objViewer.m_txtName.Tag.ToString().Trim());
				if(lngRes>0)
				{
					MessageBox.Show("保存成功！","提示");
					m_objViewer.m_lvw.SelectedItems[0].SubItems[0].Text=objResult.m_strTypeID.ToString().Trim();
					m_objViewer.m_lvw.SelectedItems[0].SubItems[1].Text=objResult.m_intSORTCODE_INT.ToString();
					m_objViewer.m_lvw.SelectedItems[0].SubItems[2].Text=objResult.m_strTypeName;
					m_objViewer.m_lvw.SelectedItems[0].SubItems[3].Text=objResult.m_strUSERCODE_CHR;
					m_objViewer.m_lvw.SelectedItems[0].SubItems[4].Text=objResult.m_decGOVTOPCHARGE_MNY.ToString();
				}
			}

			m_objViewer.m_txtSORTCODE.Text="";
			m_objViewer.txtID.Clear();
			m_objViewer.m_txtName.Text="";
			m_objViewer.m_textUSERCODE.Text="";
			m_objViewer.m_txtName.Tag=null;
			m_objViewer.txtLimit.Text="0";
			m_objViewer.txtID.Focus();
		}
		#endregion

		#region 删除项目
		public void m_Del()
		{	
			if(m_objViewer.m_lvw.SelectedItems.Count!=1)
			{
				return;
			}
			if(m_objViewer.m_lvw.SelectedItems[0].Tag==null)
				return;
			if(MessageBox.Show("确认删除该项吗？","提示",MessageBoxButtons.YesNo)==DialogResult.No)
				return;
			long lngRes=clsDomain.m_lngDelEXType(m_objViewer.m_lvw.SelectedItems[0].Tag.ToString());
			int index=m_objViewer.m_lvw.SelectedIndices[0];
			if(lngRes>0)
				m_objViewer.m_lvw.Items.Remove(m_objViewer.m_lvw.SelectedItems[0]);
			if(m_objViewer.m_lvw.Items.Count>0)
			{
				if(index>0)
					m_objViewer.m_lvw.Items[index-1].Selected=true;
				else
					m_objViewer.m_lvw.Items[index].Selected=true;
			}
		}
		#endregion

		public string GetFlag()
		{
			string strFlag="";
			if(m_objViewer.ra1.Checked)
				strFlag="1";
			else if (m_objViewer.ra2.Checked)
				strFlag="2";
			else if(m_objViewer.ra3.Checked)
				strFlag="3";
			else if(m_objViewer.ra4.Checked)
				strFlag="4";
			else
				strFlag="5";
			return strFlag;
		}
	}
}
