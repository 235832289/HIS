using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.BIHOrder.Control;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using System.Collections;

namespace com.digitalwave.iCare.BIHOrder
{
	/// <summary>
	/// 重整医嘱	逻辑控制层
	/// 作者：		徐斌辉
	/// 创建时间：	2005-04-22
	/// </summary>
	public class clsCtl_ReformingOrder: com.digitalwave.GUI_Base.clsController_Base
	{
		#region 变量
		clsDcl_InputOrder m_objManage = null;
		public string m_strReportID;
		public string m_strOperatorID ="";
		public string m_strOperatorName ="";
		#endregion 
		#region 构造函数
		public clsCtl_ReformingOrder()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_objManage = new clsDcl_InputOrder();
			m_strReportID = null;
		}
		#endregion 
		#region 设置窗体对象
		com.digitalwave.iCare.BIHOrder.frmReformingOrder m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmReformingOrder)frmMDI_Child_Base_in;
		}
		#endregion

		#region 窗体事件
		/// <summary>
		/// 载入
		/// </summary>
		public void LoadData()
		{
			m_objViewer.m_lsvDisplayOrder.Items.Clear();
			if(m_objViewer.m_strRegisterID.Trim() ==string.Empty) return;

			//获取相关医嘱
			clsBIHOrder[] objResultArr =new clsBIHOrder[0];
			long lngRes =0;
			switch(m_objViewer.m_intType)
			{
				case 3:
					lngRes =m_objManage.m_lngGetCanStopOrder(m_objViewer.m_strRegisterID,out objResultArr );
					break;
				case 4:
                    lngRes = m_objManage.m_lngGetCanReformingOrder(m_objViewer.m_strRegisterID, out objResultArr );
					break;
				default:
					MessageBox.Show(m_objViewer,"不确定的操作，请重新打开页面！","提示框！",MessageBoxButtons.OK,MessageBoxIcon.Information);
					m_objViewer.Close();
					break;
			}
			if(lngRes<=0 || objResultArr==null || objResultArr.Length<=0)	return;

			//赋值ListView
			#region 赋值
			ListViewItem lviTemp = null;
			System.Drawing.Color clrBack,clrFore;
			for(int i1= 0 ;i1<objResultArr.Length;i1++)
			{
				//序号
				lviTemp = new ListViewItem((i1+1).ToString());
				//方号
				lviTemp.SubItems.Add(objResultArr[i1].m_intRecipenNo.ToString());
				//长/临	
				if(objResultArr[i1].m_intExecuteType==1)
				{
					lviTemp.SubItems.Add("长");
				}
				else 
				{
					if(objResultArr[i1].m_intExecuteType==2)
						lviTemp.SubItems.Add("临");
					else
						lviTemp.SubItems.Add("");
				}
				//名称
				lviTemp.SubItems.Add(objResultArr[i1].m_strName);
				//剂 量
				lviTemp.SubItems.Add(objResultArr[i1].m_dmlDosageRate.ToString()+objResultArr[i1].m_strDosageUnit);
				//领 量  
				lviTemp.SubItems.Add(objResultArr[i1].m_dmlGet.ToString()+objResultArr[i1].m_strGetunit);
				//执行频率	  
				lviTemp.SubItems.Add(objResultArr[i1].m_strExecFreqName);
				//用 法	
				lviTemp.SubItems.Add(objResultArr[i1].m_strDosetypeName);
				//皮		
				if(objResultArr[i1].m_intISNEEDFEEL==1)
					lviTemp.SubItems.Add("√");
				else 
					lviTemp.SubItems.Add("");//×
				//父级医嘱
				lviTemp.SubItems.Add(objResultArr[i1].m_strParentName);

				lviTemp.Tag =objResultArr[i1];
				m_objViewer.m_lsvDisplayOrder.Items.Add(lviTemp);
				clsOrderStatus.s_mthGetColorByStatus(objResultArr[i1].m_intExecuteType,objResultArr[i1].m_intStatus,out clrBack,out clrFore);
				m_objViewer.m_lsvDisplayOrder.Items[m_objViewer.m_lsvDisplayOrder.Items.Count-1].ForeColor =clrFore;
				m_objViewer.m_lsvDisplayOrder.Items[m_objViewer.m_lsvDisplayOrder.Items.Count-1].BackColor =clrBack;
			}
			#endregion
		}
		#endregion

		#region 按钮事件
		/// <summary>
		/// 重整
		/// </summary>
		public void m_OK()
		{
			//获取选中医嘱
			ArrayList alItem =new ArrayList();
			IEnumerator iEn =m_objViewer.m_lsvDisplayOrder.CheckedItems.GetEnumerator();
			while (iEn.MoveNext())
			{
				if(((ListViewItem)iEn.Current).Tag is clsBIHOrder)
				{
					alItem.Add(((ListViewItem)iEn.Current).Tag);
				}
			}
			
			//提示
			if(alItem.Count<=0)
			{
				MessageBox.Show(m_objViewer,"请选中医嘱！","提示框！",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			if(MessageBox.Show(m_objViewer,"确定操作吗？","提示框！",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No) return;
			
			string strMessage ="";
			long lngRes =0;
			switch(m_objViewer.m_intType)
			{
				case 3:
					#region 停止
					foreach(clsBIHOrder objItem in alItem)
					{
						//梯归停止医嘱
						try
						{
                            lngRes = m_objManage.m_lngStopOrder(objItem, m_strOperatorID, m_strOperatorName, true, m_objViewer.IsChildPrice); ;
						}
						catch//(System.Exception e)
						{
							strMessage +="医嘱：["+ objItem.m_strName + "]停止失败！\r\n";
						}
					}
					#endregion
					break;
				case 4:
					#region 重整
					foreach(clsBIHOrder objItem in alItem)
					{
						//梯归重整医嘱
						try
						{
                            lngRes = m_objManage.m_lngRetractOrder(objItem, m_strOperatorID, m_strOperatorName, true, m_objViewer.IsChildPrice);
						}
						catch//(System.Exception e)
						{
							strMessage +="医嘱：["+ objItem.m_strName + "]重整失败！\r\n";
						}
					}
					#endregion
					break;
				default:
					MessageBox.Show(m_objViewer,"不确定的操作，请重新打开页面！","提示框！",MessageBoxButtons.OK,MessageBoxIcon.Information);
					m_objViewer.Close();
					break;
			}
			
			//报告结果
			if(lngRes>0 && strMessage=="")
			{
				MessageBox.Show(m_objViewer,"操作成功！","提示框！",MessageBoxButtons.OK,MessageBoxIcon.Information);			
			}
			else
			{
				if(strMessage.Trim()=="") strMessage ="操作失败!";
				MessageBox.Show(m_objViewer,strMessage,"提示框！",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}

			//刷新
			LoadData();
		}
		#endregion
	}
}