using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 价类管理
	/// 张国良 2004-9-22
	/// </summary>
	public class clsCtl_ChargeIns :com.digitalwave.GUI_Base.clsController_Base
	{
		public clsCtl_ChargeIns()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			clsDomain=new clsDcl_ChargeIns();
		}
		clsDcl_ChargeIns clsDomain;


		//保险公司
		#region 设置窗体对象	张国良	 2004-9-21
		com.digitalwave.iCare.gui.HIS.frmChargeIns m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmChargeIns)frmMDI_Child_Base_in;
		}
		#endregion

		#region 获取保险公司列表	张国良		2004-9-22
		/// <summary>
		/// 获取保险公司列表
		/// </summary>
		public void m_mthGetINSCOMPANYDataArr()
		{
			m_objViewer.m_lsvINSCOMPANY.Items.Clear();
			clsInsCompany_VO[] objResult;
			long lngRes=clsDomain.m_lngGetINSCOMPANYDataArr(out objResult);
			if(lngRes>0 && objResult.Length>0)
			{
				ListViewItem lvw;
				for(int i1=0;i1<objResult.Length;i1++)
				{
					lvw=new ListViewItem();
					
					lvw.SubItems.Add(objResult[i1].m_strCOMPANYID_CHR);
					lvw.SubItems.Add(objResult[i1].m_strUSERCODE_CHR);
					lvw.SubItems.Add(objResult[i1].m_strCOMPANYNAME_CHR);
					lvw.SubItems.Add(objResult[i1].m_strREMARK_VCHR);
					lvw.Tag=objResult[i1].m_strCOMPANYID_CHR;
					m_objViewer.m_lsvINSCOMPANY.Items.Add(lvw);
				}
			}
			if(m_objViewer.m_lsvINSCOMPANY.Items.Count>0)
				m_objViewer.m_lsvINSCOMPANY.Items[0].Selected=true;
		}
		#endregion

		#region 保存保险公司信息	张国良	 2004-9-24
		/// <summary>
		/// 保存保险公司信息
		/// </summary>
		public void m_mthSave()
		{
			if(m_objViewer.m_txtCOMPANYNAME.Text.Trim()=="")
			{
				m_ephHandler.m_mthAddControl(m_objViewer.m_txtCOMPANYNAME);
				m_ephHandler.m_mthShowControlsErrorProvider();
				m_ephHandler.m_mthClearControl();
				m_objViewer.m_txtCOMPANYNAME.Focus();
				m_objViewer.m_txtCOMPANYNAME.SelectAll();
				return;
			}

			if(m_objViewer.m_txINSCOMPANYUSERCODE.Text.Trim()=="")
			{
				m_ephHandler.m_mthAddControl(m_objViewer.m_txINSCOMPANYUSERCODE);
				m_ephHandler.m_mthShowControlsErrorProvider();
				m_ephHandler.m_mthClearControl();
				m_objViewer.m_txINSCOMPANYUSERCODE.Focus();
				m_objViewer.m_txINSCOMPANYUSERCODE.SelectAll();
				return;
			}
			long lngRes=0;
			string strID="";
			clsInsCompany_VO objResult=new clsInsCompany_VO();
			objResult.m_strCOMPANYNAME_CHR=m_objViewer.m_txtCOMPANYNAME.Text.Trim();
			objResult.m_strUSERCODE_CHR=m_objViewer.m_txINSCOMPANYUSERCODE.Text.Trim(); 
			objResult.m_strREMARK_VCHR=m_objViewer.m_txtINSCOMPANYREMARK.Text.Trim(); 
			
			if(m_objViewer.m_txtCOMPANYNAME.Tag==null) //新增
			{
				for(int i=0;i<m_objViewer.m_lsvINSCOMPANY.Items.Count;i++)
				{

					if(m_objViewer.m_lsvINSCOMPANY.Items[i].SubItems[2].Text.Trim()==m_objViewer.m_txINSCOMPANYUSERCODE.Text.Trim())
					{
						MessageBox.Show("该助记码已存在！","提示");
						m_ephHandler.m_mthAddControl(m_objViewer.m_txINSCOMPANYUSERCODE);
						m_ephHandler.m_mthShowControlsErrorProvider();
						m_ephHandler.m_mthClearControl();

						m_objViewer.m_txINSCOMPANYUSERCODE.Focus();
						m_objViewer.m_txINSCOMPANYUSERCODE.SelectAll();
						
						return;
					}	
				
				}
 
				lngRes=clsDomain.m_lngAddNewINSCOMPANYD(objResult,out strID);
				int index=m_objViewer.m_lsvINSCOMPANY.Items.Count;
				if(lngRes>0)
				{
				
					ListViewItem lvw=new ListViewItem();
					lvw.SubItems.Add(strID);
					lvw.SubItems.Add(objResult.m_strUSERCODE_CHR);
					lvw.SubItems.Add(objResult.m_strCOMPANYNAME_CHR);
					lvw.SubItems.Add(objResult.m_strREMARK_VCHR);
					lvw.Tag=strID;
					m_objViewer.m_lsvINSCOMPANY.Items.Add(lvw);

					m_objViewer.m_lsvINSCOMPANY.Items[index].Selected=true;
					
					
				}
				else
					MessageBox.Show("保存失败！","提示");
			}
			else
			{
				if(m_objViewer.m_lsvINSCOMPANY.SelectedItems.Count<=0)
				{
					return;
				}
				for(int i=0;i<m_objViewer.m_lsvINSCOMPANY.Items.Count;i++)
				{
					if (i==m_objViewer.m_lsvINSCOMPANY.SelectedItems[0].Index) continue;
					if(m_objViewer.m_lsvINSCOMPANY.Items[i].SubItems[2].Text.Trim()==m_objViewer.m_txINSCOMPANYUSERCODE.Text.Trim())
					{
						MessageBox.Show("该助记码已存在！","提示");
						m_ephHandler.m_mthAddControl(m_objViewer.m_txINSCOMPANYUSERCODE);
						m_ephHandler.m_mthShowControlsErrorProvider();
						m_ephHandler.m_mthClearControl();
						m_objViewer.m_txINSCOMPANYUSERCODE.Focus();
						m_objViewer.m_txINSCOMPANYUSERCODE.SelectAll();
						
						return;
					}	
				
				}

				objResult.m_strCOMPANYID_CHR=m_objViewer.m_txtCOMPANYNAME.Tag.ToString();
				lngRes=clsDomain.m_lngModifyINSCOMPANYD(objResult);

				if(lngRes>0)
				{

					MessageBox.Show("修改成功！","提示");
					m_objViewer.m_lsvINSCOMPANY.SelectedItems[0].SubItems[2].Text=objResult.m_strUSERCODE_CHR;
					m_objViewer.m_lsvINSCOMPANY.SelectedItems[0].SubItems[3].Text=objResult.m_strCOMPANYNAME_CHR;
					m_objViewer.m_lsvINSCOMPANY.SelectedItems[0].SubItems[4].Text=objResult.m_strREMARK_VCHR;
				}
				else
					MessageBox.Show("修改失败！","提示");
			}

			m_objViewer.m_txtCOMPANYNAME.Text="";
			m_objViewer.m_txINSCOMPANYUSERCODE.Text="";
			m_objViewer.m_txtINSCOMPANYREMARK.Text = "";
			m_objViewer.m_txtCOMPANYNAME.Tag=null;
			m_objViewer.m_txtCOMPANYNAME.Focus();
		}
		#endregion

		#region 删除保险公司信息	张国良	 2004-9-24
		/// <summary>
		/// 删除保险公司信息
		/// </summary>
		public void m_mthINSCOMPANYDel()
		{
			if(m_objViewer.m_lsvINSCOMPANY.Items.Count==0 || m_objViewer.m_lsvINSCOMPANY.SelectedItems==null)
				return;
			if(m_objViewer.m_lsvINSCOMPANY.SelectedItems.Count<=0)
			{
				return;
			}
			if(m_objViewer.m_lsvINSCOMPANY.SelectedItems[0].Tag==null)
				return;
			for(int i=0;i<m_objViewer.m_lsvINSPLAN.Items.Count;i++)
			{
				if(m_objViewer.m_lsvINSPLAN.Items[i].SubItems[5].Text.Trim()==m_objViewer.m_lsvINSCOMPANY.SelectedItems[0].SubItems[1].Text.Trim())
				{
					MessageBox.Show("该项已被引用，请先删除引用！","提示");
					return;
				}	
			}
			if(MessageBox.Show("确认删除该项吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2)==DialogResult.No)
				return;
			long lngRes=clsDomain.m_lngINSCOMPANYDel(m_objViewer.m_lsvINSCOMPANY.SelectedItems[0].Tag.ToString());
			int index=m_objViewer.m_lsvINSCOMPANY.SelectedIndices[0];
			if(lngRes>0)
			{
//				clsGetIsUsing.m_blDeleteDetail("CHARGEID_CHR",m_objViewer.m_lvw.SelectedItems[0].Tag.ToString());	
				m_objViewer.m_lsvINSCOMPANY.Items.Remove(m_objViewer.m_lsvINSCOMPANY.SelectedItems[0]);
			}
			if(m_objViewer.m_lsvINSCOMPANY.Items.Count>0)
			{
				if(index>0)
					m_objViewer.m_lsvINSCOMPANY.Items[index-1].Selected=true;
				else
					m_objViewer.m_lsvINSCOMPANY.Items[index].Selected=true;
			}
		}
		#endregion
		
		//保险计划
		#region 获取保险计划列表	张国良		2004-9-24
		/// <summary>
		/// 保险计划
		/// </summary>
		public void m_mthGetINSPLANataArr()
		{
			m_objViewer.m_lsvINSPLAN.Items.Clear();
			clsInsPlan_VO[] objResult;
			long lngRes=clsDomain.m_lngGetINSPLANDataArr(out objResult);
			if(lngRes>0 && objResult.Length>0)
			{
				ListViewItem lvw;
				for(int i1=0;i1<objResult.Length;i1++)
				{
					lvw=new ListViewItem();
					lvw.SubItems.Add(objResult[i1].m_strPLANID_CHR);
					lvw.SubItems.Add(objResult[i1].m_strUSERCODE_CHR);
					lvw.SubItems.Add(objResult[i1].m_strPLANNAME_CHR);
					lvw.SubItems.Add(objResult[i1].m_strREMARK_VCHR);
					lvw.SubItems.Add(objResult[i1].m_strCOMPANYID_CHR);
					lvw.SubItems.Add(objResult[i1].m_strCOMPANYNAME_CHR);
					lvw.Tag=objResult[i1].m_strCOMPANYID_CHR;
					m_objViewer.m_lsvINSPLAN.Items.Add(lvw);
				}
			}
			if(m_objViewer.m_lsvINSPLAN.Items.Count>0)
				m_objViewer.m_lsvINSPLAN.Items[0].Selected=true;
		}
		#endregion

		#region 保存保险计划	张国良	 2004-9-24
		/// <summary>
		/// 保存保险计划
		/// </summary>
		public void m_mthSaveINSPLAN()
		{
			if(m_objViewer.m_txtPLANNAME_CHR_INSPLAN.Text.Trim()=="")
			{
				m_ephHandler.m_mthAddControl(m_objViewer.m_txtPLANNAME_CHR_INSPLAN);
				m_ephHandler.m_mthShowControlsErrorProvider();
				m_ephHandler.m_mthClearControl();
				m_objViewer.m_txtPLANNAME_CHR_INSPLAN.Focus();
				m_objViewer.m_txtPLANNAME_CHR_INSPLAN.SelectAll();
				return;
			}

			if(m_objViewer.m_txtUSERCODE_CHR_INSPLAN.Text.Trim()=="")
			{
				m_ephHandler.m_mthAddControl(m_objViewer.m_txtUSERCODE_CHR_INSPLAN);
				m_ephHandler.m_mthShowControlsErrorProvider();
				m_ephHandler.m_mthClearControl();
				m_objViewer.m_txtUSERCODE_CHR_INSPLAN.Focus();
				m_objViewer.m_txtUSERCODE_CHR_INSPLAN.SelectAll();
				return;
			}
			if(m_objViewer.m_txtREMARK_VCHR_INSPLAN.Text.Trim()=="")
			{
				m_ephHandler.m_mthAddControl(m_objViewer.m_txtREMARK_VCHR_INSPLAN);
				m_ephHandler.m_mthShowControlsErrorProvider();
				m_ephHandler.m_mthClearControl();
				m_objViewer.m_txtREMARK_VCHR_INSPLAN.Focus();
				m_objViewer.m_txtREMARK_VCHR_INSPLAN.SelectAll();
				return;
			}if(m_objViewer.m_cboCOMPANYID_CHR.Text==""||m_objViewer.m_cboCOMPANYID_CHR.Text==null)
			 {
				 MessageBox.Show("请选择保险公司！","提示");
				 m_objViewer.m_cboCOMPANYID_CHR.Focus();
				 return;
			 }
			long lngRes=0;
			string strID="";
			clsInsPlan_VO objResult=new clsInsPlan_VO();
			objResult.m_strPLANNAME_CHR=m_objViewer.m_txtPLANNAME_CHR_INSPLAN.Text.Trim();
			objResult.m_strUSERCODE_CHR=m_objViewer.m_txtUSERCODE_CHR_INSPLAN.Text.Trim(); 
			objResult.m_strREMARK_VCHR=m_objViewer.m_txtREMARK_VCHR_INSPLAN.Text.Trim();
			objResult.m_strCOMPANYNAME_CHR=m_objViewer.m_cboCOMPANYID_CHR.Text.Trim();
			objResult.m_strCOMPANYID_CHR=m_objViewer.m_lsvINSCOMPANY.Items[m_objViewer.m_cboCOMPANYID_CHR.SelectedIndex].SubItems[1].Text.Trim(); 
		
			if(m_objViewer.m_txtPLANNAME_CHR_INSPLAN.Tag==null) //新增
			{
				for(int i=0;i<m_objViewer.m_lsvINSPLAN.Items.Count;i++)
				{

					if(m_objViewer.m_lsvINSPLAN.Items[i].SubItems[2].Text.Trim()==m_objViewer.m_txtUSERCODE_CHR_INSPLAN.Text.Trim())
					{
						MessageBox.Show("该助记码已存在！","提示");
						m_ephHandler.m_mthAddControl(m_objViewer.m_txtUSERCODE_CHR_INSPLAN);
						m_ephHandler.m_mthShowControlsErrorProvider();
						m_ephHandler.m_mthClearControl();

						m_objViewer.m_txtUSERCODE_CHR_INSPLAN.Focus();
						m_objViewer.m_txtUSERCODE_CHR_INSPLAN.SelectAll();
						
						return;
					}	
				
				}
 
				lngRes=clsDomain.m_lngAddNewINSPLAN(objResult,out strID);
				int index=m_objViewer.m_lsvINSPLAN.Items.Count;
				if(lngRes>0)
				{
				
					ListViewItem lvw=new ListViewItem();
					lvw.SubItems.Add(strID);
					lvw.SubItems.Add(objResult.m_strUSERCODE_CHR);
					lvw.SubItems.Add(objResult.m_strPLANNAME_CHR);
					lvw.SubItems.Add(objResult.m_strREMARK_VCHR);
					lvw.SubItems.Add(objResult.m_strCOMPANYID_CHR);
					lvw.SubItems.Add(objResult.m_strCOMPANYNAME_CHR);
					lvw.Tag=strID;
					m_objViewer.m_lsvINSPLAN.Items.Add(lvw);

					m_objViewer.m_lsvINSPLAN.Items[index].Selected=true;
					
					
				}
				else
					MessageBox.Show("保存失败！","提示");
			}
			else
			{
				if(m_objViewer.m_lsvINSPLAN.SelectedItems.Count<=0)
				{
					return;
				}
				for(int i=0;i<m_objViewer.m_lsvINSPLAN.Items.Count;i++)
				{
					if (i==m_objViewer.m_lsvINSPLAN.SelectedItems[0].Index) continue;
					if(m_objViewer.m_lsvINSPLAN.Items[i].SubItems[2].Text.Trim()==m_objViewer.m_txtUSERCODE_CHR_INSPLAN.Text.Trim())
					{
						MessageBox.Show("该助记码已存在！","提示");
						m_ephHandler.m_mthAddControl(m_objViewer.m_txtUSERCODE_CHR_INSPLAN);
						m_ephHandler.m_mthShowControlsErrorProvider();
						m_ephHandler.m_mthClearControl();
						m_objViewer.m_txtUSERCODE_CHR_INSPLAN.Focus();
						m_objViewer.m_txtUSERCODE_CHR_INSPLAN.SelectAll();
						
						return;
					}	
				
				}

				objResult.m_strPLANID_CHR=m_objViewer.m_lsvINSPLAN.SelectedItems[0].SubItems[1].Text.Trim();
				lngRes=clsDomain.m_lngModifyINSPLAN(objResult);

				if(lngRes>0)
				{

					MessageBox.Show("修改成功！","提示");
					m_objViewer.m_lsvINSPLAN.SelectedItems[0].SubItems[2].Text=objResult.m_strUSERCODE_CHR;
					m_objViewer.m_lsvINSPLAN.SelectedItems[0].SubItems[3].Text=objResult.m_strPLANNAME_CHR;
					m_objViewer.m_lsvINSPLAN.SelectedItems[0].SubItems[4].Text=objResult.m_strREMARK_VCHR;
					m_objViewer.m_lsvINSPLAN.SelectedItems[0].SubItems[5].Text=objResult.m_strCOMPANYID_CHR;
					m_objViewer.m_lsvINSPLAN.SelectedItems[0].SubItems[6].Text=objResult.m_strCOMPANYNAME_CHR;
				}
				else
					MessageBox.Show("修改失败！","提示");
			}

			m_objViewer.m_txtPLANNAME_CHR_INSPLAN.Text="";
			m_objViewer.m_txtUSERCODE_CHR_INSPLAN.Text="";
			m_objViewer.m_txtREMARK_VCHR_INSPLAN.Text = "";
			m_objViewer.m_txtPLANNAME_CHR_INSPLAN.Tag=null;
			m_objViewer.m_txtPLANNAME_CHR_INSPLAN.Focus();
		}
		#endregion

		#region 删除保险计划	张国良	 2004-9-24
		/// <summary>
		/// 删除保险计划
		/// </summary>
		public void m_mthDelINSPLAN()
		{
			if(m_objViewer.m_lsvINSPLAN.Items.Count==0 || m_objViewer.m_lsvINSPLAN.SelectedItems==null)
				return;
			if(m_objViewer.m_lsvINSPLAN.SelectedItems.Count<=0)
			{
				return;
			}
			if(m_objViewer.m_lsvINSPLAN.SelectedItems[0].Tag==null)
				return;

			for(int i=0;i<m_objViewer.m_lsv_INSCOPAY.Items.Count;i++)
			{
				if(m_objViewer.m_lsv_INSCOPAY.Items[i].SubItems[6].Text.Trim()==m_objViewer.m_lsvINSPLAN.SelectedItems[0].SubItems[1].Text.Trim())
				{
					MessageBox.Show("该项已被引用，请先删除引用！","提示");
					return;
				}	
			}

			if(MessageBox.Show("确认删除该项吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2)==DialogResult.No)
				return;
			long lngRes=clsDomain.m_lngDelINSPLAN(m_objViewer.m_lsvINSPLAN.SelectedItems[0].SubItems[1].Text);
			int index=m_objViewer.m_lsvINSPLAN.SelectedIndices[0];
			if(lngRes>0)
			{
				//				clsGetIsUsing.m_blDeleteDetail("CHARGEID_CHR",m_objViewer.m_lvw.SelectedItems[0].Tag.ToString());	
				m_objViewer.m_lsvINSPLAN.Items.Remove(m_objViewer.m_lsvINSPLAN.SelectedItems[0]);
			}
			if(m_objViewer.m_lsvINSPLAN.Items.Count>0)
			{
				if(index>0)
					m_objViewer.m_lsvINSPLAN.Items[index-1].Selected=true;
				else
					m_objViewer.m_lsvINSPLAN.Items[index].Selected=true;
			}
		}
		#endregion

		#region 填充保险公司
		/// <summary>
		/// 填充保险公司
		/// </summary>
		public void mthfillm_cboCOMPANYID_CHR()
		{
			m_objViewer.m_cboCOMPANYID_CHR.Items.Clear();		
			for(int i=0;i<m_objViewer.m_lsvINSCOMPANY.Items.Count;i++)
			{
				m_objViewer.m_cboCOMPANYID_CHR.Items.Add(m_objViewer.m_lsvINSCOMPANY.Items[i].SubItems[3].Text.Trim());
			}
		}
		#endregion

		//保险种类
		#region 获取保险种类列表  张国良	2004-9-27
		/// <summary>
		/// 获取保险种类列表
		/// </summary>
		public void m_mthGetINSCOPAYataArr()
		{
			m_objViewer.m_lsv_INSCOPAY.Items.Clear();
			clsInsPay_VO[] objResult;
			long lngRes=clsDomain.m_lngGetINSCOPAYataArr(out objResult);
			if(lngRes>0 && objResult.Length>0)
			{
				ListViewItem lvw;
				for(int i1=0;i1<objResult.Length;i1++)
				{
					lvw=new ListViewItem();
					lvw.SubItems.Add(objResult[i1].m_strCOPAYID_CHR);
					lvw.SubItems.Add(objResult[i1].m_strUSERCODE_CHR);
					lvw.SubItems.Add(objResult[i1].m_strCOPAYNAME_CHR);
					lvw.SubItems.Add(objResult[i1].m_dblPRECENT_DEC.ToString());
					lvw.SubItems.Add(objResult[i1].m_strREMARK_VCHR);
					lvw.SubItems.Add(objResult[i1].m_strPLANID_CHR);
					lvw.SubItems.Add(objResult[i1].m_strPLANNAME_CHR);
					lvw.Tag=objResult[i1].m_strCOPAYID_CHR;
					m_objViewer.m_lsv_INSCOPAY.Items.Add(lvw);
				}
			}
			if(m_objViewer.m_lsv_INSCOPAY.Items.Count>0)
				m_objViewer.m_lsv_INSCOPAY.Items[0].Selected=true;
		}
		#endregion

		#region 保存保险种类	张国良	 2004-9-27
		/// <summary>
		/// 保存保险种类
		/// </summary>
		public void m_mthSaveINSCOPAY()
		{
			if(m_objViewer.m_txtCOPAYNAME_CHR_INSCOPAY.Text.Trim()=="")
			{
				m_ephHandler.m_mthAddControl(m_objViewer.m_txtCOPAYNAME_CHR_INSCOPAY);
				m_ephHandler.m_mthShowControlsErrorProvider();
				m_ephHandler.m_mthClearControl();
				m_objViewer.m_txtCOPAYNAME_CHR_INSCOPAY.Focus();
				m_objViewer.m_txtCOPAYNAME_CHR_INSCOPAY.SelectAll();
				return;
			}

			if(m_objViewer.m_txtPRECENT_DEC_INSCOPAY.Text.Trim()==""||Convert.ToDouble(m_objViewer.m_txtPRECENT_DEC_INSCOPAY.Text.Trim())>=1000000)
			{
				m_ephHandler.m_mthAddControl(m_objViewer.m_txtPRECENT_DEC_INSCOPAY);
				m_ephHandler.m_mthShowControlsErrorProvider();
				m_ephHandler.m_mthClearControl();
				m_objViewer.m_txtPRECENT_DEC_INSCOPAY.Focus();
				m_objViewer.m_txtPRECENT_DEC_INSCOPAY.SelectAll();
				return;
			}
			if(m_objViewer.m_txtUSERCODE_CHR_INSCOPAY.Text.Trim()=="")
			{
				m_ephHandler.m_mthAddControl(m_objViewer.m_txtUSERCODE_CHR_INSCOPAY);
				m_ephHandler.m_mthShowControlsErrorProvider();
				m_ephHandler.m_mthClearControl();
				m_objViewer.m_txtUSERCODE_CHR_INSCOPAY.Focus();
				m_objViewer.m_txtUSERCODE_CHR_INSCOPAY.SelectAll();
				return;
			}
			if(m_objViewer.m_txtREMARK_VCHR_INSCOPAY.Text.Trim()=="")
			{
				m_ephHandler.m_mthAddControl(m_objViewer.m_txtREMARK_VCHR_INSCOPAY);
				m_ephHandler.m_mthShowControlsErrorProvider();
				m_ephHandler.m_mthClearControl();
				m_objViewer.m_txtREMARK_VCHR_INSCOPAY.Focus();
				m_objViewer.m_txtREMARK_VCHR_INSCOPAY.SelectAll();
				return;
			}
			if(m_objViewer.m_cboPLANID_CHR.Text==""||m_objViewer.m_cboPLANID_CHR.Text==null)
			{
				MessageBox.Show("请选择保险计划！","提示");
				m_objViewer.m_cboPLANID_CHR.Focus();
				return;
			} 
			long lngRes=0;
			string strID="";
			clsInsPay_VO objResult=new clsInsPay_VO();
			objResult.m_strCOPAYNAME_CHR=m_objViewer.m_txtCOPAYNAME_CHR_INSCOPAY.Text.Trim();
			objResult.m_dblPRECENT_DEC=Convert.ToDouble(m_objViewer.m_txtPRECENT_DEC_INSCOPAY.Text.Trim()); 
			objResult.m_strUSERCODE_CHR=m_objViewer.m_txtUSERCODE_CHR_INSCOPAY.Text.Trim(); 
			objResult.m_strREMARK_VCHR=m_objViewer.m_txtREMARK_VCHR_INSCOPAY.Text.Trim();
			objResult.m_strPLANNAME_CHR=m_objViewer.m_cboPLANID_CHR.Text.Trim();
			objResult.m_strPLANID_CHR=m_objViewer.m_lsvINSPLAN.Items[m_objViewer.m_cboPLANID_CHR.SelectedIndex].SubItems[1].Text.Trim();
			
			if(m_objViewer.m_txtCOPAYNAME_CHR_INSCOPAY.Tag==null) //新增
			{
				for(int i=0;i<m_objViewer.m_lsv_INSCOPAY.Items.Count;i++)
				{

					if(m_objViewer.m_lsv_INSCOPAY.Items[i].SubItems[2].Text.Trim()==m_objViewer.m_txtUSERCODE_CHR_INSCOPAY.Text.Trim())
					{
						MessageBox.Show("该助记码已存在！","提示");
						m_ephHandler.m_mthAddControl(m_objViewer.m_txtUSERCODE_CHR_INSCOPAY);
						m_ephHandler.m_mthShowControlsErrorProvider();
						m_ephHandler.m_mthClearControl();

						m_objViewer.m_txtUSERCODE_CHR_INSCOPAY.Focus();
						m_objViewer.m_txtUSERCODE_CHR_INSCOPAY.SelectAll();
						
						return;
					}	
				
				}

				for(int i=0;i<m_objViewer.m_lsv_INSCOPAY.Items.Count;i++)
				{

					if(m_objViewer.m_lsv_INSCOPAY.Items[i].SubItems[3].Text.Trim()==m_objViewer.m_txtCOPAYNAME_CHR_INSCOPAY.Text.Trim())
					{
						MessageBox.Show("该保险种类已存在！","提示");
						m_ephHandler.m_mthAddControl(m_objViewer.m_txtCOPAYNAME_CHR_INSCOPAY);
						m_ephHandler.m_mthShowControlsErrorProvider();
						m_ephHandler.m_mthClearControl();

						m_objViewer.m_txtCOPAYNAME_CHR_INSCOPAY.Focus();
						m_objViewer.m_txtCOPAYNAME_CHR_INSCOPAY.SelectAll();
						
						return;
					}	
				
				}
 
				lngRes=clsDomain.m_lngAddNewINSCOPAY(objResult,out strID);
				int index=m_objViewer.m_lsv_INSCOPAY.Items.Count;
				if(lngRes>0)
				{
				
					ListViewItem lvw=new ListViewItem();
					lvw.SubItems.Add(strID);
					lvw.SubItems.Add(objResult.m_strUSERCODE_CHR);
					lvw.SubItems.Add(objResult.m_strCOPAYNAME_CHR);
					lvw.SubItems.Add(objResult.m_dblPRECENT_DEC.ToString());
					lvw.SubItems.Add(objResult.m_strREMARK_VCHR);
					lvw.SubItems.Add(objResult.m_strPLANID_CHR);
					lvw.SubItems.Add(objResult.m_strPLANNAME_CHR);
					lvw.Tag=strID;
					m_objViewer.m_lsv_INSCOPAY.Items.Add(lvw);

					m_objViewer.m_lsv_INSCOPAY.Items[index].Selected=true;
					
					
				}
				else
					MessageBox.Show("保存失败！","提示");
			}
			else
			{
				if(m_objViewer.m_lsv_INSCOPAY.SelectedItems.Count<=0)
				{
					return;
				}
				for(int i=0;i<m_objViewer.m_lsv_INSCOPAY.Items.Count;i++)
				{
					if (i==m_objViewer.m_lsv_INSCOPAY.SelectedItems[0].Index) continue;
					if(m_objViewer.m_lsv_INSCOPAY.Items[i].SubItems[2].Text.Trim()==m_objViewer.m_txtUSERCODE_CHR_INSCOPAY.Text.Trim())
					{
						MessageBox.Show("该助记码已存在！","提示");
						m_ephHandler.m_mthAddControl(m_objViewer.m_txtUSERCODE_CHR_INSCOPAY);
						m_ephHandler.m_mthShowControlsErrorProvider();
						m_ephHandler.m_mthClearControl();
						m_objViewer.m_txtUSERCODE_CHR_INSCOPAY.Focus();
						m_objViewer.m_txtUSERCODE_CHR_INSCOPAY.SelectAll();
						
						return;
					}	
				
				}
				for(int i=0;i<m_objViewer.m_lsv_INSCOPAY.Items.Count;i++)
				{
					if (i==m_objViewer.m_lsv_INSCOPAY.SelectedItems[0].Index) continue;
					if(m_objViewer.m_lsv_INSCOPAY.Items[i].SubItems[3].Text.Trim()==m_objViewer.m_txtCOPAYNAME_CHR_INSCOPAY.Text.Trim())
					{
						MessageBox.Show("该保险种类已存在！","提示");
						m_ephHandler.m_mthAddControl(m_objViewer.m_txtCOPAYNAME_CHR_INSCOPAY);
						m_ephHandler.m_mthShowControlsErrorProvider();
						m_ephHandler.m_mthClearControl();
						m_objViewer.m_txtCOPAYNAME_CHR_INSCOPAY.Focus();
						m_objViewer.m_txtCOPAYNAME_CHR_INSCOPAY.SelectAll();
						
						return;
					}	
				
				}

				objResult.m_strCOPAYID_CHR=m_objViewer.m_txtCOPAYNAME_CHR_INSCOPAY.Tag.ToString();
				lngRes=clsDomain.m_lngModifyINSCOPAY(objResult);

				if(lngRes>0)
				{

					MessageBox.Show("修改成功！","提示");
					m_objViewer.m_lsv_INSCOPAY.SelectedItems[0].SubItems[3].Text=objResult.m_strCOPAYNAME_CHR;
					m_objViewer.m_lsv_INSCOPAY.SelectedItems[0].SubItems[4].Text=objResult.m_dblPRECENT_DEC.ToString();
					m_objViewer.m_lsv_INSCOPAY.SelectedItems[0].SubItems[2].Text=objResult.m_strUSERCODE_CHR;
					m_objViewer.m_lsv_INSCOPAY.SelectedItems[0].SubItems[5].Text=objResult.m_strREMARK_VCHR;
					m_objViewer.m_lsv_INSCOPAY.SelectedItems[0].SubItems[6].Text=objResult.m_strPLANID_CHR;
					m_objViewer.m_lsv_INSCOPAY.SelectedItems[0].SubItems[7].Text=objResult.m_strPLANNAME_CHR;
				}
				else
					MessageBox.Show("修改失败！","提示");
			}

			m_objViewer.m_txtCOPAYNAME_CHR_INSCOPAY.Text="";
			m_objViewer.m_txtPRECENT_DEC_INSCOPAY.Text="";
			m_objViewer.m_txtUSERCODE_CHR_INSCOPAY.Text = "";
			m_objViewer.m_txtREMARK_VCHR_INSCOPAY.Text = "";
			m_objViewer.m_txtCOPAYNAME_CHR_INSCOPAY.Tag=null;
			m_objViewer.m_txtCOPAYNAME_CHR_INSCOPAY.Focus();
		}
		#endregion

		#region 删除保险种类	张国良	 2004-9-27
		/// <summary>
		/// 删除保险种类
		/// </summary>
		public void m_mthDelINSCOPAY()
		{
			if(m_objViewer.m_lsv_INSCOPAY.Items.Count==0 || m_objViewer.m_lsv_INSCOPAY.SelectedItems==null)
				return;
			if(m_objViewer.m_lsv_INSCOPAY.SelectedItems.Count<=0)
			{
				return;
			}
			if(m_objViewer.m_lsv_INSCOPAY.SelectedItems[0].Tag==null)
				return;

			//			if(clsGetIsUsing.m_blGetIsUsing("CHARGEID_CHR",m_objViewer.m_lvw.SelectedItems[0].Tag.ToString())==true)
			//			{
			//				if(m_objViewer.m_btnStopUse.Tag.ToString() =="0")
			//				{
			//					if(MessageBox.Show("该挂号种类已被引用，不可删除，是否停用？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2) == DialogResult.No)
			//						return;
			//					m_mthIsUseing();
			//					return;
			//				}
			//				else if(m_objViewer.m_btnStopUse.Tag.ToString() =="1")
			//				{																														
			//					MessageBox.Show("该挂号种类已被引用，不可删除！","提示");
			//					return;
			//				}
			//			}

			if(MessageBox.Show("确认删除该项吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2)==DialogResult.No)
				return;
			long lngRes=clsDomain.m_lngDelINSCOPAY(m_objViewer.m_lsv_INSCOPAY.SelectedItems[0].SubItems[1].Text);
			int index=m_objViewer.m_lsv_INSCOPAY.SelectedIndices[0];
			if(lngRes>0)
			{
				//				clsGetIsUsing.m_blDeleteDetail("CHARGEID_CHR",m_objViewer.m_lvw.SelectedItems[0].Tag.ToString());	
				m_objViewer.m_lsv_INSCOPAY.Items.Remove(m_objViewer.m_lsv_INSCOPAY.SelectedItems[0]);
			}
			if(m_objViewer.m_lsv_INSCOPAY.Items.Count>0)
			{
				if(index>0)
					m_objViewer.m_lsv_INSCOPAY.Items[index-1].Selected=true;
				else
					m_objViewer.m_lsv_INSCOPAY.Items[index].Selected=true;
			}
		}
		#endregion

		#region 填充保险计划   2004-9-27
		/// <summary>
		/// 填充保险公司
		/// </summary>
		public void mthfillm_cboPLANID_CHR()
		{
			m_objViewer.m_cboPLANID_CHR.Items.Clear();		
			for(int i=0;i<m_objViewer.m_lsvINSPLAN.Items.Count;i++)
			{
				m_objViewer.m_cboPLANID_CHR.Items.Add(m_objViewer.m_lsvINSPLAN.Items[i].SubItems[3].Text.Trim());
			}
		}
		#endregion




	}
}
