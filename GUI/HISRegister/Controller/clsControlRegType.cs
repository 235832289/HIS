using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 挂号种类
	///  张国良	 2004-9-22
	/// </summary>
	public class clsControlRegType:com.digitalwave.GUI_Base.clsController_Base
	{
		public clsControlRegType()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			clsDomain = new clsDomainControl_RegDefine();
		}
			clsDomainControl_RegDefine clsDomain;
	


		#region 设置窗体对象 张国良	 2004-9-22
		com.digitalwave.iCare.gui.HIS.frmRegType m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmRegType)frmMDI_Child_Base_in;
		}
		#endregion

		#region 获取挂号种类列表  张国良	 2004-9-22
		public void m_GetRegType()
		{
			m_objViewer.m_lvw.Items.Clear();
			clsRegType_VO[] objResult;
			long lngRes = clsDomain.m_lngFindRegType(out objResult);
			if (lngRes > 0 && objResult.Length > 0)
			{
				ListViewItem lvw;
				for (int i1=0; i1 < objResult.Length; i1++)
				{
					lvw = new ListViewItem();
					lvw.SubItems.Add(objResult[i1].m_strRegTypeID);
					lvw.SubItems.Add(objResult[i1].m_strRegTypeName);
					lvw.SubItems.Add(objResult[i1].m_strRegTypeMemo);
					lvw.SubItems.Add(objResult[i1].m_strRegTypeNo);
					lvw.SubItems.Add(objResult[i1].m_strIsUsing);
					lvw.SubItems.Add(objResult[i1].m_strIsDoctor);
					if(objResult[i1].m_strIsUrgency=="1")
                    lvw.SubItems.Add("是");//xigui.peng添加
					else
						lvw.SubItems.Add("否");
					lvw.Tag = objResult[i1].m_strRegTypeID;
					m_objViewer.m_lvw.Items.Add(lvw);
				}
			}
			if (m_objViewer.m_lvw.Items.Count > 0)
				m_objViewer.m_lvw.Items[0].Selected = true;
		}
		#endregion

		#region 保存  张国良	 2004-9-22
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

			if(m_objViewer.m_txtREGISTERTYPENO_VCHR.Text.Trim()=="")
			{
				m_ephHandler.m_mthAddControl(m_objViewer.m_txtREGISTERTYPENO_VCHR);
				m_ephHandler.m_mthShowControlsErrorProvider();
				m_ephHandler.m_mthClearControl();
				m_objViewer.m_txtREGISTERTYPENO_VCHR.Focus();
				return;
			}
			long lngRes=0;
			string strID="";
			clsRegType_VO objResult = new clsRegType_VO();
			objResult.m_strRegTypeName = m_objViewer.m_txtName.Text;
			objResult.m_strRegTypeMemo = m_objViewer.m_txtMemo.Text;
			objResult.m_strRegTypeNo = m_objViewer.m_txtREGISTERTYPENO_VCHR.Text.Trim();
			objResult.m_strIsDoctor=this.GetFlag();
			objResult.m_strIsUrgency=this.GetFlag1();
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
 
				lngRes=clsDomain.m_lngAddRegType(objResult,out strID);
				int index=m_objViewer.m_lvw.Items.Count;
				if(lngRes>0)
				{
				
					ListViewItem lvw=new ListViewItem();	
						lvw.SubItems.Add(strID);
						lvw.SubItems.Add(objResult.m_strRegTypeName);
						lvw.SubItems.Add(objResult.m_strRegTypeMemo);
						lvw.SubItems.Add(objResult.m_strRegTypeNo);
						lvw.SubItems.Add("1");
						lvw.SubItems.Add(objResult.m_strIsDoctor);
					 if(objResult.m_strIsUrgency=="1")
						lvw.SubItems.Add("是");     //xigui.peng添加
					else
						lvw.SubItems.Add("否");
					  // lvw.SubItems.Add(objResult.m_strIsUrgency);//xigui.peng添加

						lvw.Tag = objResult.m_strRegTypeID;
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

				objResult.m_strRegTypeID = m_objViewer.m_txtName.Tag.ToString();
				lngRes=clsDomain.m_lngDoUpdRegByID(objResult);

				if(lngRes>0)
				{

					MessageBox.Show("修改成功！","提示");
					
							m_objViewer.m_lvw.SelectedItems[0].SubItems[2].Text = objResult.m_strRegTypeName;
							m_objViewer.m_lvw.SelectedItems[0].SubItems[3].Text = objResult.m_strRegTypeMemo;
							m_objViewer.m_lvw.SelectedItems[0].SubItems[4].Text =  objResult.m_strRegTypeNo;					
							m_objViewer.m_lvw.SelectedItems[0].SubItems[6].Text = objResult.m_strIsDoctor;
					
					       // m_objViewer.m_lvw.SelectedItems[0].SubItems[7].Text = objResult.m_strIsUrgency;//xigui.peng 添加
					if(objResult.m_strIsUrgency=="1")
					{
						m_objViewer.m_lvw.SelectedItems[0].SubItems[7].Text = "是";//xigui.peng 添加
					  
					}
					else

						m_objViewer.m_lvw.SelectedItems[0].SubItems[7].Text = "否";//xigui.peng 添加
								
				}
				else
					MessageBox.Show("修改失败！","提示");
			}

		m_objViewer.m_txtName.Text = "";
		m_objViewer.m_txtMemo.Text = "";
		m_objViewer.m_txtREGISTERTYPENO_VCHR.Text = "";
		m_objViewer.m_txtName.Tag = null;
		m_objViewer.ra1.Checked = true;
		//m_objViewer.m_chkEmergency.Checked = false;//xigui.peng 添加

		m_objViewer.m_txtName.Focus();
		}
		#endregion


		#region 删除挂号种类  张国良	 2004-9-22
		public void m_Delete()
		{
			if(m_objViewer.m_lvw.SelectedItems.Count<=0)
			{
				return;
			}
			if (m_objViewer.m_lvw.Items.Count == 0 || m_objViewer.m_lvw.SelectedItems == null)
				return;
			if (m_objViewer.m_lvw.SelectedItems[0].Tag == null)
				return;
			if(clsGetIsUsing.m_blGetIsUsingChargeType("REGISTERTYPEID_CHR",m_objViewer.m_lvw.SelectedItems[0].Tag.ToString())==true)
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

			if(MessageBox.Show("确认删除该项吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2) == DialogResult.No)
				return;
			long lngRes = clsDomain.m_lngDelRegByID(m_objViewer.m_lvw.SelectedItems[0].Tag.ToString());
			int index = m_objViewer.m_lvw.SelectedIndices[0];
			if (lngRes > 0)
			{
				clsGetIsUsing.m_blDeleteDetail("REGISTERTYPEID_CHR",m_objViewer.m_lvw.SelectedItems[0].Tag.ToString());				
				m_objViewer.m_lvw.Items.Remove(m_objViewer.m_lvw.SelectedItems[0]);
			}
			if (m_objViewer.m_lvw.Items.Count > 0)
			{
				if(index > 0)
					m_objViewer.m_lvw.Items[index - 1].Selected = true;
				else
					m_objViewer.m_lvw.Items[index].Selected = true;
			}
		}
		#endregion

		#region 是否停用  张国良	 2004-9-22
		public void m_mthIsUseing()
		{
			
			long lngRes = clsDomain.m_lngIsUseing(m_objViewer.m_lvw.SelectedItems[0].Tag.ToString(),m_objViewer.m_btnStopUse.Tag.ToString());
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

		public string GetFlag()
		{
			string strFlag="";
			if(m_objViewer.ra1.Checked)
				strFlag="0";
			else if (m_objViewer.ra2.Checked)
				strFlag="1";
			else if(m_objViewer.ra3.Checked)
				strFlag="2";
			return strFlag;
		}
		public string GetFlag1()//xigui.peng 添加
		{
			string strFlag1="";
			if(m_objViewer.m_chkEmergency.Checked)
				strFlag1="1";
			else 
				strFlag1="0";
			
			return strFlag1;
		}

	}

}
