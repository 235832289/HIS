using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsControlRegChargeType 的摘要说明。
	/// </summary>
	public class clsControlRegChargeType:com.digitalwave.GUI_Base.clsController_Base
	{
		public clsControlRegChargeType()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			clsDomain=new clsDomainControl_RegDefine();
		}
		clsDomainControl_RegDefine clsDomain;
		#region 设置窗体对象	张国良	 2004-8-8
		com.digitalwave.iCare.gui.HIS.frmRegChargeType m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmRegChargeType)frmMDI_Child_Base_in;
		}
		#endregion

		#region 获取挂号费种列表	张国良		2004-8-8
		public void m_GetItemType()
		{
			m_objViewer.m_lvw.Items.Clear();
			clsRegchargeType_VO[] objResult;
			long lngRes=clsDomain.m_lngFindType(out objResult);
			if(lngRes>0 && objResult.Length>0)
			{
				ListViewItem lvw;
				for(int i1=0;i1<objResult.Length;i1++)
				{
					lvw=new ListViewItem();
					lvw.SubItems.Add(objResult[i1].m_strCHARGEID_CHR);
					lvw.SubItems.Add(objResult[i1].m_strCHARGENAME_CHR);
					lvw.SubItems.Add(objResult[i1].m_strMEMO_VCHR);
					lvw.SubItems.Add(objResult[i1].m_strCHARGENO_VCHR);
					lvw.SubItems.Add(objResult[i1].m_strISUSING_NUM);

					lvw.Tag=objResult[i1].m_strCHARGEID_CHR;
					m_objViewer.m_lvw.Items.Add(lvw);
				}
			}
			if(m_objViewer.m_lvw.Items.Count>0)
				m_objViewer.m_lvw.Items[0].Selected=true;
		}
		#endregion

		#region 保存挂号费种	张国良	 2004-8-8
		public void m_lngSave()
		{
			
			if(m_objViewer.m_txtName.Text.Trim()=="")
			{
				m_ephHandler.m_mthAddControl(m_objViewer.m_txtName);
				m_ephHandler.m_mthShowControlsErrorProvider();
				m_ephHandler.m_mthClearControl();
				m_objViewer.m_txtName.Focus();
				return;
			}
			

			long lngRes=0;
			string strID="";
			clsRegchargeType_VO objResult=new clsRegchargeType_VO();
			objResult.m_strCHARGENAME_CHR=m_objViewer.m_txtName.Text.Trim(); 
			objResult.m_strMEMO_VCHR=m_objViewer.m_txtMemo.Text.Trim();
			objResult.m_strCHARGENO_VCHR = m_objViewer.m_txtREGISTERTYPENO_VCHR.Text.Trim();

			if(m_objViewer.m_txtName.Tag==null) //新增
			{
				for(int i=0;i<m_objViewer.m_lvw.Items.Count;i++)
				{

					if(m_objViewer.m_lvw.Items[i].SubItems[2].Text.Trim()==m_objViewer.m_txtName.Text.Trim())
					{
						MessageBox.Show("该挂号种类已存在！","提示");
						m_ephHandler.m_mthAddControl(m_objViewer.m_txtName);
						m_ephHandler.m_mthShowControlsErrorProvider();
						m_ephHandler.m_mthClearControl();
						m_objViewer.m_txtName.Focus();
						m_objViewer.m_txtName.SelectAll();
						
						return;
					}	
				}
				lngRes=clsDomain.m_lngAddType(objResult,out strID);
				int index=m_objViewer.m_lvw.Items.Count;
				if(lngRes>0)
				{
					ListViewItem lvw=new ListViewItem();
					lvw.SubItems.Add(strID);
					lvw.SubItems.Add(objResult.m_strCHARGENAME_CHR);
					lvw.SubItems.Add(objResult.m_strMEMO_VCHR);
					lvw.SubItems.Add(objResult.m_strCHARGENO_VCHR);
					lvw.SubItems.Add("1");
					lvw.Tag=strID;
					m_objViewer.m_lvw.Items.Add(lvw);				
					m_objViewer.m_lvw.Items[index].Selected=true;
					
				}
				else
					MessageBox.Show("保存失败！","提示");
			}
			else
			{
				if(m_objViewer.m_lvw.SelectedItems.Count<=0)
				{
					return;
				}
				for(int i=0;i<m_objViewer.m_lvw.Items.Count;i++)
				{
					if (i==m_objViewer.m_lvw.SelectedItems[0].Index) continue;
					if(m_objViewer.m_lvw.Items[i].SubItems[2].Text.Trim()==m_objViewer.m_txtName.Text.Trim())
					{
						MessageBox.Show("该挂号种类已存在！","提示");
						m_ephHandler.m_mthAddControl(m_objViewer.m_txtName);
						m_ephHandler.m_mthShowControlsErrorProvider();
						m_ephHandler.m_mthClearControl();
		
						m_objViewer.m_txtName.Focus();
						m_objViewer.m_txtName.SelectAll();
								
						return;
					}			
				}

				objResult.m_strCHARGEID_CHR=m_objViewer.m_txtName.Tag.ToString();
				lngRes=clsDomain.m_lngDoUpdTypeByID(objResult);
				if(lngRes>0)
				{

					MessageBox.Show("修改成功！","提示");
					m_objViewer.m_lvw.SelectedItems[0].SubItems[2].Text=objResult.m_strCHARGENAME_CHR;
					m_objViewer.m_lvw.SelectedItems[0].SubItems[3].Text=objResult.m_strMEMO_VCHR;
					m_objViewer.m_lvw.SelectedItems[0].SubItems[4].Text=objResult.m_strCHARGENO_VCHR;
				}
				else
					MessageBox.Show("修改失败！","提示");
			}
			m_objViewer.m_txtName.Text="";
			m_objViewer.m_txtMemo.Text="";
			m_objViewer.m_txtREGISTERTYPENO_VCHR.Text = "";
			m_objViewer.m_txtName.Tag=null;
			m_objViewer.m_txtName.Focus();
		}
		#endregion

		#region 删除挂号费种	张国良	 2004-8-8
		public void m_Del()
		{
			if(m_objViewer.m_lvw.Items.Count==0 || m_objViewer.m_lvw.SelectedItems==null)
				return;
			if(m_objViewer.m_lvw.SelectedItems.Count<=0)
			{
				return;
			}
			if(m_objViewer.m_lvw.SelectedItems[0].Tag==null)
				return;

			if(clsGetIsUsing.m_blGetIsUsing("CHARGEID_CHR",m_objViewer.m_lvw.SelectedItems[0].Tag.ToString())==true)
			{
				if(m_objViewer.m_btnStopUse.Tag.ToString() =="0")
				{
					if(MessageBox.Show("该挂号种类已被引用，不可删除，是否停用？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2) == DialogResult.No)
						return;
					m_mthIsUseing();
					return;
				}
				else if(m_objViewer.m_btnStopUse.Tag.ToString() =="1")
				{																														
					MessageBox.Show("该挂号种类已被引用，不可删除！","提示");
					return;
				}
			}

			if(MessageBox.Show("确认删除该项吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2)==DialogResult.No)
				return;
			long lngRes=clsDomain.m_lngDelTypeByID(m_objViewer.m_lvw.SelectedItems[0].Tag.ToString());
			int index=m_objViewer.m_lvw.SelectedIndices[0];
			if(lngRes>0)
			{
				clsGetIsUsing.m_blDeleteDetail("CHARGEID_CHR",m_objViewer.m_lvw.SelectedItems[0].Tag.ToString());	
				m_objViewer.m_lvw.Items.Remove(m_objViewer.m_lvw.SelectedItems[0]);
			}
			if(m_objViewer.m_lvw.Items.Count>0)
			{
				if(index>0)
					m_objViewer.m_lvw.Items[index-1].Selected=true;
				else
					m_objViewer.m_lvw.Items[index].Selected=true;
			}
		}
		#endregion

		#region 是否停用 张国良	 2004-9-22
		public void m_mthIsUseing()
		{
			
			long lngRes = clsDomain.m_lngIsUseingRgechargeType(m_objViewer.m_lvw.SelectedItems[0].Tag.ToString(),m_objViewer.m_btnStopUse.Tag.ToString());
			if (lngRes > 0 )
			{
				if(m_objViewer.m_btnStopUse.Tag.ToString() =="0")
				{
					MessageBox.Show("停用成功！");
					m_objViewer.m_lblIsStopUse.Text="已停用";
					m_objViewer.m_btnStopUse.Text ="恢复";
					m_objViewer.m_lvw.SelectedItems[0].SubItems[5].Text = m_objViewer.m_btnStopUse.Tag.ToString();
					m_objViewer.m_btnStopUse.Tag = "1";
				}
				else if (m_objViewer.m_btnStopUse.Tag.ToString() =="1")
				{
					MessageBox.Show("恢复成功！");
					m_objViewer.m_lblIsStopUse.Text="正常";
					m_objViewer.m_btnStopUse.Text ="停用";
					m_objViewer.m_lvw.SelectedItems[0].SubItems[5].Text = m_objViewer.m_btnStopUse.Tag.ToString();
					m_objViewer.m_btnStopUse.Tag = "0";
				}
				

			}
			else
			{
				if(m_objViewer.m_btnStopUse.Tag.ToString() =="0")
					MessageBox.Show("停用失败！");
				else if (m_objViewer.m_btnStopUse.Tag.ToString() =="1")
					MessageBox.Show("恢复失败！");
			}
			
		}
		#endregion
	}
}
