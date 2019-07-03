using System;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// clsController_SampleUnite 的摘要说明。
	/// </summary>
	public class clsController_SampleUnite : com.digitalwave.GUI_Base.clsController_Base
	{
		com.digitalwave.iCare.gui.LIS.clsDomainController_CheckResultManage m_objManage;
		com.digitalwave.iCare.ValueObject.clsResultLogVO m_objResultLog = null;
		internal clsDeviceReslutVO[] m_objDeviceResultArr = null;
		internal bool m_blnShowDialog = false;
		#region 构造函数
		public clsController_SampleUnite()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_objManage = new clsDomainController_CheckResultManage();
		}
		#endregion

		#region 设置窗体对象
		com.digitalwave.iCare.gui.LIS.frmSampleUnite m_objViewer;
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance (frmMDI_Child_Base_in);
			m_objViewer = (frmSampleUnite)frmMDI_Child_Base_in;
		}
		#endregion

		#region 根据Imp_Req_int，仪器ID查询标本列表 童华 2004.08.20
		public DialogResult m_mthShow(string p_strImpReq,string p_strDeviceID)
		{
			long lngRes = 0;
			clsResultLogVO[] objResultArr = null;
			lngRes = m_objManage.m_lngGetDeviceSampleListByCondition(p_strImpReq,p_strDeviceID,out objResultArr);
			if(lngRes > 0 && objResultArr != null && objResultArr.Length > 0)
			{
				string strTemp = "";
				if(m_objViewer.m_lsvSampleList.Items.Count > 0)
				{
					strTemp = ((clsResultLogVO)m_objViewer.m_lsvSampleList.Items[m_objViewer.m_lsvSampleList.Items.Count-1].Tag).m_strIMPORT_REQ_INT;
				}
				for(int i=0;i<objResultArr.Length;i++)
				{
					ListViewItem objlsvItem = new ListViewItem();
					if(strTemp != "")
					{
						if(objResultArr[i].m_strIMPORT_REQ_INT != strTemp)
						{
							if(m_objViewer.m_lsvSampleList.Items[m_objViewer.m_lsvSampleList.Items.Count-1].ForeColor == Color.Blue)
							{
								objlsvItem.ForeColor = Color.Black;
							}
							else
							{
								objlsvItem.ForeColor = Color.Blue;
							}
						}
						else
						{
							objlsvItem.ForeColor = m_objViewer.m_lsvSampleList.Items[m_objViewer.m_lsvSampleList.Items.Count-1].ForeColor;
						}
					}
					objlsvItem.Text = objResultArr[i].m_strDeviceSampleID;
					objlsvItem.SubItems.Add(objResultArr[i].m_strCheckDat);
//					if(objResultArr[i].m_strUseFlag == "1")
//					{
//						objlsvItem.SubItems.Add("√");
//					}
//					else
//					{
//						objlsvItem.SubItems.Add("");
//					}
//					if(objResultArr[i].m_strSample_status == "3" || objResultArr[i].m_strSample_status == "5" || 
//						objResultArr[i].m_strSample_status == "" || objResultArr[i].m_strSample_status == null)
//					{
//						objlsvItem.SubItems.Add("");
//					}
//					else
//					{
//						objlsvItem.SubItems.Add("×");
//					}
					objlsvItem.SubItems.Add("");
					objlsvItem.Tag = objResultArr[i];
					m_objViewer.m_lsvSampleList.Items.Add(objlsvItem);
					strTemp = objResultArr[i].m_strIMPORT_REQ_INT;
				}
			}
			else
			{
				MessageBox.Show("无可用的仪器标本！");
			}
			m_objViewer.m_btnClear.Visible = false;
			m_blnShowDialog = true;
			return m_objViewer.ShowDialog();
		}
		#endregion

		#region 根据仪器样本号，仪器ID和检验时间查询标本列表 童华 2004.08.16
		public void m_mthGetDeviceSampleListByCondition(string p_strDeviceSampleID,string p_strDeviceID,string p_strCheckDat)
		{
//			m_objViewer.m_lsvSampleList.Items.Clear();
//			m_objViewer.m_lsvSampleResult.Items.Clear();
//			m_objViewer.m_lsvResultUnite.Items.Clear();
			if(m_objViewer.m_lsvSampleList.Items.Count > 0)
			{
				clsResultLogVO objResultLog = (clsResultLogVO)m_objViewer.m_lsvSampleList.Items[0].Tag;
				if(m_objViewer.m_cboLisDevice.SelectedValue.ToString().Trim() != objResultLog.m_strDeviceID)
				{
					MessageBox.Show("请选择相同的仪器进行查询！");
					return;
				}
			}
			clsResultLogVO objSelectedLog = null;
			if(m_objViewer.m_lsvSampleList.SelectedItems.Count > 0)
			{
				objSelectedLog = (clsResultLogVO)m_objViewer.m_lsvSampleList.SelectedItems[0].Tag;
			}
			long lngRes = 0;
			clsResultLogVO[] objResultArr = null;
			lngRes = m_objManage.m_lngGetDeviceSampleListByCondition(p_strDeviceSampleID,p_strDeviceID,p_strCheckDat,out objResultArr);
			if(lngRes > 0 && objResultArr != null && objResultArr.Length > 0)
			{
				string strTemp = "";
				if(m_objViewer.m_lsvSampleList.Items.Count > 0)
				{
					for(int i=0;i<m_objViewer.m_lsvSampleList.Items.Count;i++)
					{
						clsResultLogVO objTemp = (clsResultLogVO)m_objViewer.m_lsvSampleList.Items[i].Tag;
						for(int j=0;j<objResultArr.Length;j++)
						{
							if(objTemp.m_strBeginIndex == objResultArr[j].m_strBeginIndex && objTemp.m_strDeviceID == objResultArr[j].m_strDeviceID
								&& objTemp.m_strIMPORT_REQ_INT == objResultArr[j].m_strIMPORT_REQ_INT)
							{
								m_objViewer.m_lsvSampleList.Items[i].Remove();
								i--;
							}
						}
					}
				}
				for(int i=0;i<objResultArr.Length;i++)
				{
					ListViewItem objlsvItem = new ListViewItem();
					if(m_objViewer.m_lsvSampleList.Items.Count > 0)
					{
						if(m_objViewer.m_lsvSampleList.Items[m_objViewer.m_lsvSampleList.Items.Count-1].ForeColor == Color.Blue)
						{
							objlsvItem.ForeColor = Color.Black;
						}
						else
						{
							objlsvItem.ForeColor = Color.Blue;
						}
					}
					else
					{
						objlsvItem.ForeColor = Color.Black;
					}
					objlsvItem.Text = objResultArr[i].m_strDeviceSampleID;
					objlsvItem.SubItems.Add(objResultArr[i].m_strCheckDat);
//					if(objResultArr[i].m_strUseFlag == "1")
//					{
//						objlsvItem.SubItems.Add("√");
//					}
//					else
//					{
//						objlsvItem.SubItems.Add("");
//					}
//					if(objResultArr[i].m_strSample_status == "3" || objResultArr[i].m_strSample_status == "5" || 
//						objResultArr[i].m_strSample_status == "" || objResultArr[i].m_strSample_status == null)
//					{
//						objlsvItem.SubItems.Add("");
//					}
//					else
//					{
//						objlsvItem.SubItems.Add("×");
//					}
					objlsvItem.SubItems.Add("");
					objlsvItem.Tag = objResultArr[i];
					m_objViewer.m_lsvSampleList.Items.Add(objlsvItem);
					strTemp = objResultArr[i].m_strIMPORT_REQ_INT;
				}
				if(objSelectedLog != null)
				{
					for(int i=0;i<m_objViewer.m_lsvSampleList.Items.Count;i++)
					{
						clsResultLogVO objTemp = (clsResultLogVO)m_objViewer.m_lsvSampleList.Items[i].Tag;
						if(objSelectedLog.m_strDeviceID == objTemp.m_strDeviceID && objSelectedLog.m_strIMPORT_REQ_INT == objTemp.m_strIMPORT_REQ_INT
							&& objSelectedLog.m_strBeginIndex == objTemp.m_strBeginIndex)
						{
							m_objViewer.m_lsvSampleList.Items[i].Selected = true;
							m_objViewer.m_lsvSampleList.Items[i].EnsureVisible();
						}
					}
				}
			}
			else
			{
				MessageBox.Show("无可用的仪器标本！");
			}
		}
		#endregion

		#region 根据界面上的参数查询标本列表 童华 2004.08.16
		public void m_mthGetDeviceSampleListByViewer()
		{
			if(m_objViewer.m_cboDeviceModel.Items.Count <= 0)
			{
				MessageBox.Show("没有可用的仪器型号！");
				return;
			}
			if(m_objViewer.m_cboLisDevice.Items.Count <= 0)
			{
				MessageBox.Show("没有可用的仪器！");
				return;
			}
			if(m_objViewer.m_txtDeviceSampleID.Text.ToString().Trim() == "")
			{
				MessageBox.Show("请输入仪器标本号！");
				return;
			}
			string strDeviceID = m_objViewer.m_cboLisDevice.SelectedValue.ToString().Trim();
			string strDeviceSampleID = m_objViewer.m_txtDeviceSampleID.Text.ToString().Trim();
			string strCheckDat = m_objViewer.m_dtpCheckDate.Value.ToShortDateString().Trim();
			m_mthGetDeviceSampleListByCondition(strDeviceSampleID,strDeviceID,strCheckDat);
		}
		#endregion

		#region 查询仪器样本信息对应的仪器结果 童华 2004.08.16
		public void m_mthGetDeviceDataByDeviceSampleInfo()
		{
			if(m_objViewer.m_lsvSampleList.SelectedItems.Count <= 0)
				return;
			m_objViewer.m_lsvSampleResult.Items.Clear();
			clsResultLogVO objReulstLog = (clsResultLogVO)m_objViewer.m_lsvSampleList.SelectedItems[0].Tag;
			long lngRes = 0;
			clsDeviceReslutVO[] objResultArr = null;
			lngRes = m_objManage.m_lngGetDeviceData(objReulstLog.m_strDeviceID,objReulstLog.m_strDeviceSampleID,objReulstLog.m_strCheckDat,
				int.Parse(objReulstLog.m_strBeginIndex),int.Parse(objReulstLog.m_strEndIndex),out objResultArr);
			if(lngRes > 0 && objResultArr != null && objResultArr.Length > 0)
			{
				for(int i=0;i<objResultArr.Length;i++)
				{
					ListViewItem objlsvItem = new ListViewItem();
					objlsvItem.Text = objResultArr[i].m_strDeviceCheckItemName;
					objlsvItem.SubItems.Add(objResultArr[i].m_strResult);
					objlsvItem.Tag = objResultArr[i];
					m_objViewer.m_lsvSampleResult.Items.Add(objlsvItem);
				}
			}
		}
		#endregion

		#region 设为基准样本
		public void m_mthSetToBaseSample()
		{
			if(m_objViewer.m_lsvSampleList.SelectedItems.Count <= 0)
				return;
			clsResultLogVO objTemp = (clsResultLogVO)m_objViewer.m_lsvSampleList.SelectedItems[0].Tag;
//			if(objTemp.m_strSample_status != "3" && objTemp.m_strSample_status != "5" && objTemp.m_strSample_status != "")
//			{
//				MessageBox.Show("该数据不能设为基准样本！");
//				return;
//			}
			m_objViewer.m_lsvResultUnite.Items.Clear();

			for(int i=0;i<m_objViewer.m_lsvSampleList.Items.Count;i++)
			{
				m_objViewer.m_lsvSampleList.Items[i].SubItems[2].Text = "";
			}
			m_objResultLog = (clsResultLogVO)m_objViewer.m_lsvSampleList.SelectedItems[0].Tag;
			m_objViewer.m_lsvSampleList.SelectedItems[0].SubItems[2].Text = "←";
//			m_objResultLog.m_strUseFlag = "1";
			
			long lngRes = 0;
			clsDeviceReslutVO[] objResultArr = null;
			lngRes = m_objManage.m_lngGetDeviceData(m_objResultLog.m_strDeviceID,m_objResultLog.m_strDeviceSampleID,m_objResultLog.m_strCheckDat,
				int.Parse(m_objResultLog.m_strBeginIndex),int.Parse(m_objResultLog.m_strEndIndex),out objResultArr);
			if(lngRes > 0 && objResultArr != null && objResultArr.Length > 0)
			{
				for(int i=0;i<objResultArr.Length;i++)
				{
					ListViewItem objlsvItem = new ListViewItem();
					objlsvItem.Text = objResultArr[i].m_strDeviceCheckItemName;
					objlsvItem.SubItems.Add(objResultArr[i].m_strResult);
					objlsvItem.Tag = objResultArr[i];
					m_objViewer.m_lsvResultUnite.Items.Add(objlsvItem);
				}
			}
		}
		#endregion

		#region 保存
		public void m_mthSave()
		{
			if(m_objViewer.m_lsvResultUnite.Items.Count <= 0 || m_objResultLog == null)
				return;
			m_objDeviceResultArr = new clsDeviceReslutVO[m_objViewer.m_lsvResultUnite.Items.Count];
			for(int i=0;i<m_objViewer.m_lsvResultUnite.Items.Count;i++)
			{
				m_objDeviceResultArr[i] = new clsDeviceReslutVO();
				clsDeviceReslutVO objTemp = (clsDeviceReslutVO)m_objViewer.m_lsvResultUnite.Items[i].Tag;
				m_objDeviceResultArr[i].m_strAbnormalFlag = objTemp.m_strAbnormalFlag;
				m_objDeviceResultArr[i].m_strCheckDat = m_objResultLog.m_strCheckDat;
				m_objDeviceResultArr[i].m_strDeviceCheckItemName = objTemp.m_strDeviceCheckItemName;
				m_objDeviceResultArr[i].m_strDeviceID = objTemp.m_strDeviceID;
				m_objDeviceResultArr[i].m_strDeviceSampleID = m_objResultLog.m_strDeviceSampleID;
				m_objDeviceResultArr[i].m_strMaxVal = objTemp.m_strMaxVal;
				m_objDeviceResultArr[i].m_strMinVal = objTemp.m_strMinVal;
				m_objDeviceResultArr[i].m_strPstatus = "1";
				m_objDeviceResultArr[i].m_strRefRange = objTemp.m_strRefRange;
				m_objDeviceResultArr[i].m_strResult = objTemp.m_strResult;
				m_objDeviceResultArr[i].m_strUnit = objTemp.m_strUnit;
			}

			long lngRes = 0;
			lngRes = m_objManage.m_lngAddNewDeviceCheckResultArrANDLog(m_objDeviceResultArr,m_objResultLog);
			
			if(lngRes > 0 && !this.m_blnShowDialog)
			{
				m_objViewer.m_lsvSampleList.Items.Clear();
				m_mthGetDeviceSampleListByCondition(m_objResultLog.m_strDeviceSampleID,m_objResultLog.m_strDeviceID,
					DateTime.Parse(m_objResultLog.m_strCheckDat).ToShortDateString());
				for(int i=0;i<m_objViewer.m_lsvSampleList.Items.Count;i++)
				{
					clsResultLogVO objTemp = (clsResultLogVO)m_objViewer.m_lsvSampleList.Items[i].Tag;
					if(objTemp.m_strUseFlag == "1")
					{
						m_objViewer.m_lsvSampleList.Items[i].Selected = true;
					}
				}
				m_mthSetToBaseSample();
			}
		}
		#endregion

		#region 重置
		public void m_mthClear()
		{
			m_objViewer.m_lsvSampleList.Items.Clear();
			m_objViewer.m_lsvSampleResult.Items.Clear();
			m_objViewer.m_lsvResultUnite.Items.Clear();
			m_objViewer.m_txtDeviceSampleID.Clear();
			m_objResultLog = null;
			m_objViewer.m_txtDeviceSampleID.Focus();
//			if(m_objViewer.m_cboDeviceModel.Items.Count > 0)
//			{
//				m_objViewer.m_cboDeviceModel.SelectedIndex = 0;
//			}
//			m_objViewer.m_dtpCheckDate.Value = System.DateTime.Now;
		}
		#endregion

		#region 取消
		public void m_mthCancel()
		{
			for(int i=0;i<m_objViewer.m_lsvSampleList.Items.Count;i++)
			{
				if(m_objViewer.m_lsvSampleList.Items[i].SubItems[2].Text.ToString().Trim() != "")
				{
					m_objViewer.m_lsvResultUnite.Items.Clear();
					m_objResultLog = (clsResultLogVO)m_objViewer.m_lsvSampleList.Items[i].Tag;
//					m_objResultLog.m_strUseFlag = "1";

					long lngRes = 0;
					clsDeviceReslutVO[] objResultArr = null;
					lngRes = m_objManage.m_lngGetDeviceData(m_objResultLog.m_strDeviceID,m_objResultLog.m_strDeviceSampleID,m_objResultLog.m_strCheckDat,
						int.Parse(m_objResultLog.m_strBeginIndex),int.Parse(m_objResultLog.m_strEndIndex),out objResultArr);
					if(lngRes > 0 && objResultArr != null && objResultArr.Length > 0)
					{
						for(int j=0;j<objResultArr.Length;j++)
						{
							ListViewItem objlsvItem = new ListViewItem();
							objlsvItem.Text = objResultArr[j].m_strDeviceCheckItemName;
							objlsvItem.SubItems.Add(objResultArr[j].m_strResult);
							objlsvItem.Tag = objResultArr[j];
							m_objViewer.m_lsvResultUnite.Items.Add(objlsvItem);
						}
					}
					break;
				}
			}
			if(m_objViewer.m_lsvSampleResult.Items.Count > 0)
			{
				for(int i=0;i<m_objViewer.m_lsvSampleResult.Items.Count;i++)
				{
					m_objViewer.m_lsvSampleResult.Items[i].Checked = false;
				}
			}
		}
		#endregion

		#region 融合仪器结果
		public void m_mthUniteDeviceCheckResult(int p_index)
		{
			if(m_objResultLog == null)
			{
				MessageBox.Show("请选择基准样本！");
				return;
			}

			for(int i=0;i<m_objViewer.m_lsvResultUnite.Items.Count;i++)
			{
				if(((clsDeviceReslutVO)m_objViewer.m_lsvSampleResult.Items[p_index].Tag).m_strDeviceCheckItemName == 
					((clsDeviceReslutVO)m_objViewer.m_lsvResultUnite.Items[i].Tag).m_strDeviceCheckItemName)
				{
					m_objViewer.m_lsvResultUnite.Items[i].SubItems[1].Text = m_objViewer.m_lsvSampleResult.Items[p_index].SubItems[1].Text;
					m_objViewer.m_lsvResultUnite.Items[i].Tag = m_objViewer.m_lsvSampleResult.Items[p_index].Tag;
				}
			}
		}
		#endregion

	}
}
