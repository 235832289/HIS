using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsControlRecipeFreq 的摘要说明。
	/// </summary>
	public class clsControlRecipeFreq:com.digitalwave.GUI_Base.clsController_Base
	{
		public clsControlRecipeFreq()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			clsDomain=new clsDomainControl_RecipeFreq();
		}
		clsDomainControl_RecipeFreq clsDomain;
		#region 设置窗体对象	张国良	 2004-8-9
		com.digitalwave.iCare.gui.HIS.frmRecipeFreq m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmRecipeFreq)frmMDI_Child_Base_in;
		}
		#endregion

		#region 获取用药频率列表	张国良		2004-8-12
		public void m_GetItemRecipeFequencyType()
		{
			m_objViewer.m_lvw.Items.Clear();
			clsRecipefreq_VO[] objResult;
			long lngRes=clsDomain.m_lngFindRecipeFrequencyeList(out objResult);
			if(lngRes>0 && objResult.Length>0)
			{
				ListViewItem lvw;
				for(int i1=0;i1<objResult.Length;i1++)
				{
					lvw=new ListViewItem();
					lvw.SubItems.Add(objResult[i1].m_strFREQID_CHR);
					lvw.SubItems.Add(objResult[i1].m_strFREQNAME_CHR);
					lvw.SubItems.Add(objResult[i1].m_strUSERCODE_CHR.ToString());
					lvw.SubItems.Add(objResult[i1].m_intTIMES_INT.ToString());
					lvw.SubItems.Add(objResult[i1].m_intDAYS_INT.ToString());
                    lvw.SubItems.Add(objResult[i1].m_strOPFreqDesc.ToString());
					lvw.Tag=objResult[i1].m_strFREQID_CHR;
					m_objViewer.m_lvw.Items.Add(lvw);
				}
			}
			if(m_objViewer.m_lvw.Items.Count>0)
				m_objViewer.m_lvw.Items[0].Selected=true;
		}
		#endregion

		#region 保存用药频率	张国良	 2004-8-12
		public void m_lngSaveRecipeFequencyType()
		{
			
			if(m_objViewer.m_txtName.Text.Trim()=="")
			{
				m_ephHandler.m_mthAddControl(m_objViewer.m_txtName);
				m_ephHandler.m_mthShowControlsErrorProvider();
				m_ephHandler.m_mthClearControl();
				m_objViewer.m_txtName.Focus();
				return;
			}
			if(m_objViewer.m_txtUSERCODE_CHR.Text.Trim()=="")
			{
				m_ephHandler.m_mthAddControl(m_objViewer.m_txtUSERCODE_CHR);
				m_ephHandler.m_mthShowControlsErrorProvider();
				m_ephHandler.m_mthClearControl();
				m_objViewer.m_txtUSERCODE_CHR.Focus();
				return;
			}
			if(m_objViewer.m_txtTIMES_INT.Text.Trim()=="")
			{
				m_ephHandler.m_mthAddControl(m_objViewer.m_txtTIMES_INT);
				m_ephHandler.m_mthShowControlsErrorProvider();
				m_ephHandler.m_mthClearControl();
				m_objViewer.m_txtTIMES_INT.Focus();
				return;
			}
			if(m_objViewer.tex_DAYS_INT.Text.Trim()=="")
			{
				m_ephHandler.m_mthAddControl(m_objViewer.tex_DAYS_INT);
				m_ephHandler.m_mthShowControlsErrorProvider();
				m_ephHandler.m_mthClearControl();
				m_objViewer.tex_DAYS_INT.Focus();
				return;
			}
			
			long lngRes=0;
			string strID="";
			clsRecipefreq_VO objResult=new clsRecipefreq_VO();
			
			objResult.m_strFREQNAME_CHR=m_objViewer.m_txtName.Text; 
			objResult.m_strUSERCODE_CHR=m_objViewer.m_txtUSERCODE_CHR.Text;  
			objResult.m_intTIMES_INT=Convert.ToInt32(m_objViewer.m_txtTIMES_INT.Text);  
			objResult.m_intDAYS_INT=Convert.ToInt32(m_objViewer.tex_DAYS_INT.Text);
            objResult.m_strOPFreqDesc = this.m_objViewer.m_txtDesc.Text;
			if(m_objViewer.m_txtName.Tag==null) //新增
			{
				for(int i=0;i<m_objViewer.m_lvw.Items.Count;i++)
				{
				
					if(m_objViewer.m_lvw.Items[i].SubItems[3].Text.Trim()==m_objViewer.m_txtUSERCODE_CHR.Text.Trim())
					{
						MessageBox.Show("该助记码已存在！","提示");
						m_ephHandler.m_mthAddControl(m_objViewer.m_txtUSERCODE_CHR);
						m_ephHandler.m_mthShowControlsErrorProvider();
						m_ephHandler.m_mthClearControl();

						m_objViewer.m_txtUSERCODE_CHR.Focus();
						m_objViewer.m_txtUSERCODE_CHR.SelectAll();
						return;
					}
				
				
				}
				

				lngRes=clsDomain.m_lngAddRecipeFrequencyType(objResult,out strID);
				int index=m_objViewer.m_lvw.Items.Count;
				if(lngRes>0)
				{
					//MessageBox.Show("保存成功！","提示");
					ListViewItem lvw=new ListViewItem();
					lvw.SubItems.Add(strID);
					lvw.SubItems.Add(m_objViewer.m_txtName.Text);
					lvw.SubItems.Add(m_objViewer.m_txtUSERCODE_CHR.Text);
					lvw.SubItems.Add(m_objViewer.m_txtTIMES_INT.Text);
					lvw.SubItems.Add(m_objViewer.tex_DAYS_INT.Text);
                    lvw.SubItems.Add(m_objViewer.m_txtDesc.Text);
					lvw.Tag=strID;
					m_objViewer.m_lvw.Items.Add(lvw);
					m_objViewer.m_lvw.Items[index].Selected=true;
					
				}else
					MessageBox.Show("保存失败！","提示");

			}
			else //修改
			{

				if(m_objViewer.m_lvw.SelectedItems.Count<=0)
				{
					return;
				}
				for(int i=0;i<m_objViewer.m_lvw.Items.Count;i++)
				{
					if (i==m_objViewer.m_lvw.SelectedItems[0].Index) continue;
					if(m_objViewer.m_lvw.Items[i].SubItems[3].Text.Trim()==m_objViewer.m_txtUSERCODE_CHR.Text.Trim())
					{
						MessageBox.Show("该助记码已存在！","提示");
						m_ephHandler.m_mthAddControl(m_objViewer.m_txtUSERCODE_CHR);
						m_ephHandler.m_mthShowControlsErrorProvider();
						m_ephHandler.m_mthClearControl();

						m_objViewer.m_txtUSERCODE_CHR.Focus();
						m_objViewer.m_txtUSERCODE_CHR.SelectAll();
						return;
					}	
				
				}

				objResult.m_strFREQID_CHR=m_objViewer.m_txtName.Tag.ToString();				
				lngRes=clsDomain.m_lngDoUpdRecipeFrequencyTypeByID(objResult);
				if(lngRes>0)
				{

					MessageBox.Show("修改成功！","提示");			
					m_objViewer.m_lvw.SelectedItems[0].SubItems[2].Text=m_objViewer.m_txtName.Text;
					m_objViewer.m_lvw.SelectedItems[0].SubItems[3].Text=m_objViewer.m_txtUSERCODE_CHR.Text;
					m_objViewer.m_lvw.SelectedItems[0].SubItems[4].Text=m_objViewer.m_txtTIMES_INT.Text;
					m_objViewer.m_lvw.SelectedItems[0].SubItems[5].Text=m_objViewer.tex_DAYS_INT.Text;
                    m_objViewer.m_lvw.SelectedItems[0].SubItems[6].Text = m_objViewer.m_txtDesc.Text;
				}
				else
				MessageBox.Show("修改失败！","提示");
			}

			m_objViewer.m_txtName.Text="";
			m_objViewer.m_txtUSERCODE_CHR.Text="";
			m_objViewer.m_txtTIMES_INT.Text="";
			m_objViewer.tex_DAYS_INT.Text="";
			m_objViewer.m_txtName.Tag=null;
			m_objViewer.m_txtName.Focus();
		}
		#endregion

		#region 删除用药频率	张国良	 2004-8-12
		public void m_DelRecipeFequencyType()
		{
			if(m_objViewer.m_lvw.Items.Count==0 || m_objViewer.m_lvw.SelectedItems==null)
				return;
			if(m_objViewer.m_lvw.SelectedItems.Count<=0)
			{
				return;
			}
			if(m_objViewer.m_lvw.SelectedItems[0].Tag==null)
				return;
			if(MessageBox.Show("确认删除该项吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2)==DialogResult.No)
				return;
			long lngRes=clsDomain.m_lngDelTRecipeFrequencyTypeByID(m_objViewer.m_lvw.SelectedItems[0].Tag.ToString());
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
	}
}
