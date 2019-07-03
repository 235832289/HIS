using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 用法项目编辑	徐斌辉	2005-04-06	
	/// </summary>
	public class clsControlUsaEdit:com.digitalwave.GUI_Base.clsController_Base
	{
		#region 全局变量
		clsDcl_OPCharge m_objManage;
		/// <summary>
		/// 操作者ID
		/// </summary>
		public string m_strOperatorID;
		#endregion
		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmUsaEdit m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmUsaEdit)frmMDI_Child_Base_in;
		}
		#endregion
		#region 构造函数 
		public clsControlUsaEdit()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_objManage =new clsDcl_OPCharge();
		}
		#endregion
		#region 清空
		/// <summary>
		/// 清空重制
		/// </summary>
		public void m_ClearInput()
		{
			//项目名称
			m_objViewer.m_txtItem.Text ="";
			m_objViewer.m_txtItem.Tag =null;
			//续用类型
			m_objViewer.m_cboContinueUseType.SelectedIndex =0;
			m_objViewer.m_cboContinueUseType.Tag =null;
			//门诊数量
			m_objViewer.m_txtCLINICQTY.Text ="";
			//门诊数量类型
			m_objViewer.m_cboCLINICTYPE.SelectedIndex =0;
			//门诊总价
			m_objViewer.m_txtCLINICTOTALPRICE.Text ="";
			m_objViewer.m_lblClinicUnit.Text ="";	//存储门诊单位
			m_objViewer.m_lblClinicUnit.Tag =null;	//存储门诊领量单位
			//住院数量
			m_objViewer.m_txtBIHQTY.Text ="";
			//住院数量类型
			m_objViewer.m_cboBIHTYPE.SelectedIndex =0;
			//住院总价
			m_objViewer.m_txtBIHOTALPRICE.Text ="";
			m_objViewer.m_lblBihUnit.Text ="";	//存储住院单位
			m_objViewer.m_lblBihUnit.Tag =null;	//存储住院领量单位
			//项目类型
			m_objViewer.m_txtItemType.Text ="";
			//项目规格
			m_objViewer.m_txtItemSpec.Text ="";
			//剂量
			m_objViewer.m_txtDOSAGE_DEC.Text ="";		//存储剂量+剂量单位
			m_objViewer.m_txtDOSAGE_DEC.Tag =null;		//存储剂量
			m_objViewer.m_lblSaveDosageUnit.Tag =null;	//存储剂量单位
			
			//价格
			m_objViewer.m_txtItemPrice.Text ="";			
		}
		/// <summary>
		/// 清空变量
		/// </summary>
		private void ClearVar()
		{
			//清空变量
			string strUsageID =m_objViewer.m_objBridgeForUsaEdit.m_strUsageID;
			m_objViewer.m_objBridgeForUsaEdit =new clsBridgeForUsaEdit();
			m_objViewer.m_objBridgeForUsaEdit.m_strUsageID =strUsageID;
			//操作状态	{0、新增(默认)；1、修改；}
			m_objViewer.m_intOperateState =0;
			//操作结果状态	{0、直接关闭(默认)；1、操作成功；2、操作失败；}
			m_objViewer.m_intResultState =0;
			//删除按钮
			m_objViewer.m_cmdDel.Enabled =false;
		}
		#endregion

		#region 窗体事件
		public void m_FromLoad()
		{
			m_ClearInput();
		}

		#endregion
		#region 按钮事件
		public void m_Save()
		{
			if(isnoqty==true)
			{
				if(MessageBox.Show(this.m_objViewer.m_txtItem.Text.Trim()+"是缺药或停用药是否要继续？","",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					if(blnSave(false))
					{
						m_objViewer.m_intResultState =1;
						m_objViewer.Close();
					}
				}
				else
				{
					m_objViewer.m_txtItem.Focus();
				}
			}
			else
			{
				if(blnSave(false))
				{
					m_objViewer.m_intResultState =1;
					m_objViewer.Close();
				}
			}
			
		}
		public void m_SaveAdd()
		{
			if(isnoqty==true)
			{
				if(MessageBox.Show(this.m_objViewer.m_txtItem.Text.Trim()+"是缺药或停用药是否要继续？","",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
				{
					m_objViewer.m_txtItem.Focus();
					return;
				}
			}
			if(blnSave(false))
			{
				m_ClearInput();
				ClearVar();
			}
		}
        /// <summary>
        /// 保存新加的中药用法带出项目
        /// </summary>
        public void m_mthCMUsageSaveAdd()
        {
            if (isnoqty == true)
            {
                if (MessageBox.Show(this.m_objViewer.m_txtItem.Text.Trim() + "是缺药或停用药是否要继续？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    m_objViewer.m_txtItem.Focus();
                    return;
                }
            }
            if (this.m_mthblnSave(false))
            {
                m_ClearInput();
                ClearVar();
            }
        }
        /// <summary>
        /// 保存中药用法带出项目
        /// </summary>
        public void m_mthCMUsageSave()
        {
            if (isnoqty == true)
            {
                if (MessageBox.Show(this.m_objViewer.m_txtItem.Text.Trim() + "是缺药或停用药是否要继续？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (blnSave(false))
                    {
                        m_objViewer.m_intResultState = 1;
                        m_objViewer.Close();
                    }
                }
                else
                {
                    m_objViewer.m_txtItem.Focus();
                }
            }
            else
            {
                if (m_mthblnSave(false))
                {
                    m_objViewer.m_intResultState = 1;
                    m_objViewer.Close();
                }
            }

        }
		/// <summary>
		/// 保存
		/// </summary>
		/// <param name="p_blnIsAddNew">是否保存新增</param>
		private bool blnSave(bool p_blnIsAddNew)
		{
			//获取对象
			clsBridgeForUsaEdit objItem;
			GetObjectFromControl(out objItem);
			//验证对象
			if(!CheckObjectForSave(objItem)) return false;
			//保存
			long lngRes =0;
			string strRecordID ="";
			clsChargeItemUsageGroup_VO objItem1 =new clsChargeItemUsageGroup_VO();
			objItem1 =objItem;
			if(m_objViewer.m_intOperateState!=1)
			{//新增
				lngRes =new clsDomainControl_ChargeItem().m_lngDoAddNewChargeItemUsageGroup(out strRecordID,objItem1);
			}
			else
			{//修改
				if(objItem1.m_strTOTALPRICE.Trim()!=objItem1.m_strItemID.Trim())
				{
					if(MessageBox.Show("是否将把其他用法的相同项目更新为些项目？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
					{
						objItem1.m_intFlag =1;
					}
				}

				lngRes =new clsDomainControl_ChargeItem().m_lngDoModifyChargeItemUsageGroup(objItem1);
			}
			if(lngRes>0)
			{
				MessageBox.Show(m_objViewer,"操作成功!","提示框!",MessageBoxButtons.OK,MessageBoxIcon.Information);			
			}
			else
			{
				MessageBox.Show(m_objViewer,"操作失败!","提示框!",MessageBoxButtons.OK,MessageBoxIcon.Information);			
			}
			return (lngRes>0)?(true):(false);
		}
		public void m_Del()
		{
			if(m_objViewer.m_intOperateState!=1) return;
			clsChargeItemUsageGroup_VO objItem =new clsChargeItemUsageGroup_VO();
			objItem =m_objViewer.m_objBridgeForUsaEdit;
			if(MessageBox.Show("确定删除此项吗?","提示框!",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
			{
				return;
			}
			objItem.m_intFlag=0;
			if(MessageBox.Show("是否删除其他同法的此项目?","提示框!",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				objItem.m_intFlag=1;
			}
			long lngRes =new clsDomainControl_ChargeItem().m_lngDelUsageGroupByID(objItem);
			if(lngRes>0)
			{			
				MessageBox.Show(m_objViewer,"操作成功!","提示框!",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2);
				m_objViewer.m_intResultState =1;
				m_objViewer.Close();
			}
			else
			{
				MessageBox.Show(m_objViewer,"操作失败!","提示框!",MessageBoxButtons.OK,MessageBoxIcon.Information);				
			}
		}
        /// <summary>
        /// 删除中药用法带出项目
        /// </summary>
        public void m_mthDel()
        {
            if (m_objViewer.m_intOperateState != 1) return;
            clsChargeItemUsageGroup_VO objItem = new clsChargeItemUsageGroup_VO();
            objItem = m_objViewer.m_objBridgeForUsaEdit;
            if (MessageBox.Show("确定删除此项吗?", "提示框!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            objItem.m_intFlag = 0;
            if (MessageBox.Show("是否删除其他同法的此项目?", "提示框!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                objItem.m_intFlag = 1;
            }
            long lngRes = new clsDomainControl_ChargeItem().m_lngDelCMUsageGroupByID(objItem);
            if (lngRes > 0)
            {
                MessageBox.Show(m_objViewer, "操作成功!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                m_objViewer.m_intResultState = 1;
                m_objViewer.Close();
            }
            else
            {
                MessageBox.Show(m_objViewer, "操作失败!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
		#endregion
		#region 文本事件
		public void m_TextItemInitListView(System.Windows.Forms.ListView lvwList)
		{
			lvwList.Width =540;
			lvwList.HeaderStyle=ColumnHeaderStyle.Clickable;
			//添加列头
			lvwList.Columns.Add("编码",60,HorizontalAlignment.Left);			
			lvwList.Columns.Add("项目名称",150,HorizontalAlignment.Left);			
			lvwList.Columns.Add("项目类型",80,HorizontalAlignment.Left);
			lvwList.Columns.Add("项目规格",80,HorizontalAlignment.Left);
			lvwList.Columns.Add("剂量",70,HorizontalAlignment.Left);
			lvwList.Columns.Add("单价",70,HorizontalAlignment.Right);
		}
		public void m_TextItemFindItem(string strFindCode, System.Windows.Forms.ListView lvwList)
		{
			lvwList.Items.Clear();
			System.Data.DataTable dt=null;
			long longRes =m_objManage.m_mthFindMedicineByID(strFindCode,out dt);
			if(dt==null || dt.Rows.Count<=0)
			{
				MessageBox.Show(m_objViewer,"没有你要的项目,请输入其他条件查找!","提示框!",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return ;
			}
			//加列
			ListViewItem lsvItem =null;
			for(int i=0;i<dt.Rows.Count;i++)
			{
				//项目编码
				lsvItem =new ListViewItem(dt.Rows[i]["ITEMCODE_VCHR"].ToString().Trim());
				//项目名称
				lsvItem.SubItems.Add(dt.Rows[i]["ITEMNAME_VCHR"].ToString().Trim());
				//项目类型
				lsvItem.SubItems.Add(strSwitchTypeToName(dt.Rows[i]["ITEMCATID_CHR"].ToString().Trim()));
				//项目规格
				lsvItem.SubItems.Add(dt.Rows[i]["ITEMSPEC_VCHR"].ToString().Trim());
				//剂量
				lsvItem.SubItems.Add(dt.Rows[i]["DOSAGE_DEC"].ToString().Trim() + dt.Rows[i]["DOSAGEUNIT_CHR"].ToString().Trim());
				//单价
				lsvItem.SubItems.Add(dt.Rows[i]["ITEMPRICE_MNY"].ToString().Trim());
				
				lsvItem.Tag =((dt.Rows[i]) as DataRow);//dt.Rows[i]["ITEMID_CHR"].ToString().Trim();
				lvwList.Items.Add(lsvItem);
                //try
                //{
                //    if(int.Parse(dt.Rows[i]["NOQTYFLAG_INT"].ToString())==1&&int.Parse(dt.Rows[i]["ITEMSRCTYPE_INT"].ToString())==1)
                //    {
                //        lvwList.Items[lvwList.Items.Count-1].ForeColor=System.Drawing.Color.Red;
                //    }
                //}
                //catch
                //{
                //}
			}
		}
		public void m_TextItemSelectItem(System.Windows.Forms.ListViewItem lviSelected)
		{
			if(lviSelected!=null)
			{
				FillTextFromDataRow(lviSelected.Tag as DataRow);
				//计算金额
//				m_mthCalMoney();
				//焦点转移
				SendKeys.SendWait("{Tab}");
			}
		}
		#endregion

		#region 方法
		/// <summary>
		/// 填充文本框	根据DataRow
		/// </summary>
		/// <param name="p_dRow"></param>
		public bool isnoqty=true;
		private void FillTextFromDataRow(DataRow p_dRow)
		{
			if(p_dRow==null) return;
			try
			{
				
				if(this.m_objViewer.CurrentItem!=null&&this.m_objViewer.CurrentItem.IndexOf(p_dRow["ITEMID_CHR"].ToString().Trim())>-1)
				{
				MessageBox.Show("对不起，所选项目已经存在，不能重复选择");
				return;
				}
				//项目名称
				m_objViewer.m_txtItem.Text =p_dRow["ITEMNAME_VCHR"].ToString().Trim();
				m_objViewer.m_txtItem.Tag =p_dRow["ITEMID_CHR"].ToString().Trim();
				//项目类型
				m_objViewer.m_txtItemType.Text =strSwitchTypeToName(p_dRow["ITEMCATID_CHR"].ToString());
				//项目规格
				m_objViewer.m_txtItemSpec.Text =p_dRow["ITEMSPEC_VCHR"].ToString().Trim();
				//剂量
				m_objViewer.m_txtDOSAGE_DEC.Text =p_dRow["DOSAGE_DEC"].ToString().Trim() + p_dRow["DOSAGEUNIT_CHR"].ToString().Trim();
				m_objViewer.m_txtDOSAGE_DEC.Tag =p_dRow["DOSAGE_DEC"].ToString().Trim();
				m_objViewer.m_lblSaveDosageUnit.Tag =p_dRow["DOSAGEUNIT_CHR"].ToString().Trim();
                isnoqty = true;//初始化,默认情况为true
                //if (p_dRow["noqtyflag_int"].ToString().Trim() == string.Empty && p_dRow["IFSTOP_INT"].ToString().Trim() == string.Empty)
                //{
                //    isnoqty = false;
                //}
                //else
                //{
                //    if (p_dRow["noqtyflag_int"].ToString().Trim() != string.Empty && p_dRow["IFSTOP_INT"].ToString().Trim() != string.Empty)
                //    {
                //        if (int.Parse(p_dRow["noqtyflag_int"].ToString().Trim()) == 0 && int.Parse(p_dRow["IFSTOP_INT"].ToString().Trim()) == 0)
                //        {
                //            isnoqty = false;
                //        }
                //    }
                //    else if (p_dRow["noqtyflag_int"].ToString().Trim() == string.Empty && p_dRow["IFSTOP_INT"].ToString().Trim() != string.Empty)
                //    {
                //        if (int.Parse(p_dRow["IFSTOP_INT"].ToString().Trim()) == 0)
                //        {
                //            isnoqty = false;
                //        }
                //    }
                //    else if (p_dRow["noqtyflag_int"].ToString().Trim() != string.Empty && p_dRow["IFSTOP_INT"].ToString().Trim() == string.Empty)
                //    {
                //        if (int.Parse(p_dRow["noqtyflag_int"].ToString().Trim()) == 0)
                //        {
                //            isnoqty = false;
                //        }
                //    }
              
                //}
                //if(int.Parse(p_dRow["noqtyflag_int"].ToString())==1||int.Parse(p_dRow["IFSTOP_INT"].ToString())==1)
                //{
                //    isnoqty=true;
                //}
                //else
                //{
                //    isnoqty=false;
                //}
				//价格
			}
			catch{}
			try
			{
				if(p_dRow["OPCHARGEFLG_INT"].ToString()=="0")
				{
					m_objViewer.m_txtItemPrice.Tag =Convert.ToDouble(p_dRow["ITEMPRICE_MNY"].ToString()).ToString("0.0000");
				}
				else
				{
					double OPPRICE=0;
					OPPRICE=Convert.ToDouble(p_dRow["ITEMPRICE_MNY"].ToString())/Convert.ToDouble(p_dRow["PACKQTY_DEC"].ToString());
					m_objViewer.m_txtItemPrice.Tag =OPPRICE.ToString("0.0000");
				}

				if(p_dRow["IPCHARGEFLG_INT"].ToString()=="0")
				{
					m_objViewer.m_txtItemPrice.Text =Convert.ToDouble(p_dRow["ITEMPRICE_MNY"].ToString()).ToString("0.0000");
				}
				else
				{
					double OPPRICE=0;
					OPPRICE=Convert.ToDouble(p_dRow["ITEMPRICE_MNY"].ToString())/Convert.ToDouble(p_dRow["PACKQTY_DEC"].ToString());
					m_objViewer.m_txtItemPrice.Text =OPPRICE.ToString("0.0000");
				}
			}
			catch{}

			string strGetBihUnit,strClinicUnit;
			GetUnit(p_dRow,out strClinicUnit,out strGetBihUnit);
			m_objViewer.m_lblClinicUnit.Tag =strClinicUnit;
			m_objViewer.m_lblBihUnit.Tag =strGetBihUnit;
			//门诊单位				
			if(m_objViewer.m_cboCLINICTYPE.SelectedIndex==0)//领量单位
				m_objViewer.m_lblClinicUnit.Text =m_objViewer.m_lblClinicUnit.Tag.ToString();
			else
				m_objViewer.m_lblClinicUnit.Text =m_objViewer.m_lblSaveDosageUnit.Tag.ToString();
			//住院单位				
			if(m_objViewer.m_cboBIHTYPE.SelectedIndex==0)//领量单位
				m_objViewer.m_lblBihUnit.Text =m_objViewer.m_lblBihUnit.Tag.ToString();
			else
				m_objViewer.m_lblBihUnit.Text =m_objViewer.m_lblSaveDosageUnit.Tag.ToString();
		
		}
		/// <summary>
		/// 保存原来的项目ID
		/// </summary>
		private string strPreItemID="";
		/// <summary>
		/// 填充文本框	根据用法维护桥梁对象
		/// </summary>
		/// <param name="p_objItem">用法维护桥梁对象</param>
		public void m_FillTextFromObject(clsBridgeForUsaEdit p_objItem)
		{
			if(p_objItem==null || p_objItem.m_strItemID==null || p_objItem.m_strItemID.Trim()=="") return;
			//项目名称
			m_objViewer.m_txtItem.Text =p_objItem.m_strItemName;
			m_objViewer.m_txtItem.Tag =p_objItem.m_strItemID.Trim();
			strPreItemID=p_objItem.m_strItemID.Trim();
			//续用类型 {0=不续用;1=全部续用;2-长嘱续用}
			m_objViewer.m_cboContinueUseType.SelectedIndex =p_objItem.m_intCONTINUEUSETYPE_INT;
			//项目类型
			m_objViewer.m_txtItemType.Text =p_objItem.m_strItemType.Trim();
			//项目规格
			m_objViewer.m_txtItemSpec.Text =p_objItem.m_strItemSpec.Trim();
			//剂量
			m_objViewer.m_txtDOSAGE_DEC.Text =p_objItem.m_dblDOSAGE_DEC.ToString().Trim() + p_objItem.m_strDOSAGEUNIT_CHR.Trim();
			m_objViewer.m_txtDOSAGE_DEC.Tag =p_objItem.m_dblDOSAGE_DEC.ToString().Trim();
			m_objViewer.m_lblSaveDosageUnit.Tag =p_objItem.m_strDOSAGEUNIT_CHR.ToString().Trim();
			//领量单位
			m_objViewer.m_lblClinicUnit.Tag =p_objItem.m_strGetClinicUnit.ToString();
			m_objViewer.m_lblBihUnit.Tag =p_objItem.m_strGetBihUnit.ToString();
			//价格
			m_objViewer.m_txtItemPrice.Text =p_objItem.m_strItemPrice.Trim();
			//门诊数量
			m_objViewer.m_txtCLINICQTY.Text =p_objItem.m_strUNITPRICE.Trim();
			//门诊数量类型
			m_objViewer.m_cboCLINICTYPE.SelectedIndex =p_objItem.m_intCLINICTYPE_INT -1;
			//门诊总价
			m_objViewer.m_txtCLINICTOTALPRICE.Text =p_objItem.m_strTOTALPRICE.Trim();
			//住院数量
			m_objViewer.m_txtBIHQTY.Text =p_objItem.m_dblBIHQTY_DEC.ToString().Trim();
			//住院数量类型
			m_objViewer.m_cboBIHTYPE.SelectedIndex =p_objItem.m_intBIHTYPE_INT -1;
			//住院总价
			m_objViewer.m_txtBIHOTALPRICE.Text =p_objItem.m_strBihOtalPrice.Trim();
			//门诊单位、住院单位
			if(m_objViewer.m_cboCLINICTYPE.SelectedIndex==0)//领量单位
				m_objViewer.m_lblClinicUnit.Text =m_objViewer.m_lblClinicUnit.Tag.ToString();
			else
				m_objViewer.m_lblClinicUnit.Text =m_objViewer.m_lblSaveDosageUnit.Tag.ToString();
			if(m_objViewer.m_cboBIHTYPE.SelectedIndex==0)//领量单位
				m_objViewer.m_lblBihUnit.Text =m_objViewer.m_lblBihUnit.Tag.ToString();
			else
				m_objViewer.m_lblBihUnit.Text =m_objViewer.m_lblSaveDosageUnit.Tag.ToString();
            //住院执行科室标志
            m_objViewer.m_cboZyFlag.SelectedIndex = p_objItem.m_intBihExecDeptflag - 1;
            m_objViewer.m_ctfDefDept.txtValuse = p_objItem.m_strBihExecDeptName;
            m_objViewer.m_ctfDefDept.Tag = p_objItem.m_strBihExecDeptID;

		}
		/// <summary>
		/// 转换类型 {From 编号 To 名称}
		/// </summary>
		/// <param name="strTypeNo">编号</param>
		/// <returns></returns>
		private string strSwitchTypeToName(string strTypeNo)
		{
			string strRet="西药";
			switch(strTypeNo)
			{
				case "0002":
					strRet="中药";
					break;
				case "0003":
					strRet="检验";
					break;
				case "0004":
					strRet="治疗";
					break;
				case "0005":
					strRet="其他";
					break;
				case "0006":
					strRet="手术";
					break;
				default:
					strRet="西药";
					break;
			}
			return strRet;
		}
		/// <summary>
		/// 获取对象	根据用户输入
		/// </summary>
		/// <param name="p_objResult"></param>
		private void GetObjectFromControl(out clsBridgeForUsaEdit p_objResult)
		{
			p_objResult =new clsBridgeForUsaEdit();
			//用法ID
			p_objResult.m_strUsageID =m_objViewer.m_objBridgeForUsaEdit.m_strUsageID.Trim();
			//续用类型 {0=不续用;1=续用}
			p_objResult.m_intCONTINUEUSETYPE_INT =m_objViewer.m_cboContinueUseType.SelectedIndex;
			//项目名称
			p_objResult.m_strItemName =m_objViewer.m_txtItem.Text.Trim();
			if(m_objViewer.m_txtItem.Tag==null) m_objViewer.m_txtItem.Tag ="";
			p_objResult.m_strItemID =m_objViewer.m_txtItem.Tag.ToString().Trim();
			//门诊数量
			p_objResult.m_strUNITPRICE =m_objViewer.m_txtCLINICQTY.Text.Trim();
			//门诊数量类型
			p_objResult.m_intCLINICTYPE_INT =m_objViewer.m_cboCLINICTYPE.SelectedIndex + 1;
			//门诊总价
//			p_objResult.m_strTOTALPRICE =m_objViewer.m_txtCLINICTOTALPRICE.Text.Trim();
			p_objResult.m_strTOTALPRICE =this.strPreItemID;//用总价保存原来的项目ID
			//住院数量
			try
			{
				p_objResult.m_dblBIHQTY_DEC =Convert.ToDouble(m_objViewer.m_txtBIHQTY.Text.Trim());
			}
			catch{}
			//住院数量类型
			p_objResult.m_intBIHTYPE_INT =m_objViewer.m_cboBIHTYPE.SelectedIndex + 1;
			//住院总价
			p_objResult.m_strBihOtalPrice =m_objViewer.m_txtBIHOTALPRICE.Text.Trim();
			//项目类型
			p_objResult.m_strItemType =m_objViewer.m_txtItemType.Text.Trim();
			//项目规格
			p_objResult.m_strItemSpec =m_objViewer.m_txtItemSpec.Text.Trim();
			//剂量
			try
			{
				p_objResult.m_dblDOSAGE_DEC =Convert.ToDouble(m_objViewer.m_txtDOSAGE_DEC.Tag.ToString().Trim());
			}
			catch{}
			//剂量单位
			try
			{
				p_objResult.m_strDOSAGEUNIT_CHR =m_objViewer.m_lblSaveDosageUnit.Tag.ToString().Trim();
			}
			catch{}
			//价格
			p_objResult.m_strItemPrice =m_objViewer.m_txtItemPrice.Text.Trim();
            //住院执行科室标志
            p_objResult.m_intBihExecDeptflag = m_objViewer.m_cboZyFlag.SelectedIndex + 1;
            if (m_objViewer.m_ctfDefDept.Tag != null)
            {
                p_objResult.m_strBihExecDeptID = m_objViewer.m_ctfDefDept.Tag.ToString();
            }
		}
		/// <summary>
		/// 验证对象是否可以保存
		/// </summary>
		/// <param name="p_objItem"></param>
		/// <returns></returns>
		private bool CheckObjectForSave(clsBridgeForUsaEdit p_objItem)
		{
			if(p_objItem==null && p_objItem.m_strItemID!=null) return false;
			//项目不能少
			if(p_objItem.m_strItemName==null || p_objItem.m_strItemID==null || p_objItem.m_strItemName.Trim()=="" || p_objItem.m_strItemID.Trim()=="")
			{
				MessageBox.Show(m_objViewer,"项目不能少!","提示框!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return false;			
			}
			//诊疗相关信息
			double dbl =-1;
			try{dbl=Convert.ToDouble(p_objItem.m_strUNITPRICE);}
			catch{}
			if(dbl<0)
			{
				MessageBox.Show(m_objViewer,"门诊数量错误,必须为大于或等于0的数!","提示框!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				m_objViewer.m_txtCLINICQTY.Focus();
				return false;			
			}
			if(p_objItem.m_intCLINICTYPE_INT<1 || p_objItem.m_intCLINICTYPE_INT>2)
			{
				MessageBox.Show(m_objViewer,"门诊数量类型不能少!","提示框!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				m_objViewer.m_cboCLINICTYPE.Focus();
				return false;			
			}
			//住院相关信息
			if(p_objItem.m_dblBIHQTY_DEC<0)
			{
				MessageBox.Show(m_objViewer,"住院数量错误,必须为大于或等于0的数!","提示框!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				m_objViewer.m_txtBIHQTY.Focus();
				return false;			
			}
			if(p_objItem.m_intBIHTYPE_INT<1 || p_objItem.m_intBIHTYPE_INT>2)
			{
				MessageBox.Show(m_objViewer,"门诊数量类型不能少!","提示框!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				m_objViewer.m_cboBIHTYPE.Focus();
				return false;			
			}
			return true;
		}
		/// <summary>
		/// 获取门诊总价及住院总价
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strITEMID_CHR">项目ID</param>
		/// <param name="intType">1-门诊总价，2-住院总价</param>
		/// <param name="dblQTY">数量</param>
		/// <param name="intNuit">1-领药单位，2-剂量单位</param>
		public double  m_dblCalMoney(string strITEMID_CHR,int intType,double dblQTY,int intNuit)
		{
			double dblTotailMoney=0;
			clsDcl_ChargeItem objChargeItem =new clsDcl_ChargeItem();
			objChargeItem.m_lngGetChargeUsageTotailMoney(strITEMID_CHR,intType,dblQTY,intNuit,out dblTotailMoney); 
			return dblTotailMoney;
		}
		/// <summary>
		/// 获取领量单位
		/// </summary>
		/// <param name="p_dRow"></param>
		/// <param name="p_strClinicUnit">[out 参数] 门诊领量单位</param>
		/// <param name="p_strGetBihUnit">[out 参数] 住院领量单位</param>
		private void GetUnit(DataRow p_dRow,out string p_strClinicUnit,out string p_strGetBihUnit)
		{
			p_strClinicUnit ="";
			p_strGetBihUnit ="";
			if(p_dRow==null) return;

			int intGetType =0;
			//门诊单位
			intGetType =0;//门诊收费单位 0 －基本单位 1－最小单位
			try{intGetType =Convert.ToInt32(p_dRow["OPCHARGEFLG_INT"].ToString());}
			catch{}
			try
			{
				if(intGetType==0)
				{
					p_strClinicUnit = p_dRow["ITEMOPUNIT_CHR"].ToString().Trim();
				}
				else if(intGetType==1)
				{
					p_strClinicUnit = p_dRow["ITEMIPUNIT_CHR"].ToString().Trim();
				}
			}
			catch{}

			//住院单位
			intGetType =0;//住院收费单位 0 －基本单位 1－最小单位
			try{intGetType =Convert.ToInt32(p_dRow["IPCHARGEFLG_INT"].ToString());}
			catch{}
			try
			{
				if(intGetType==0)
					p_strGetBihUnit = p_dRow["ITEMOPUNIT_CHR"].ToString().Trim();
				else
					p_strGetBihUnit = p_dRow["ITEMIPUNIT_CHR"].ToString().Trim();
			}
			catch{}
		}
		#endregion
        #region 保存中药用法带出项目
        /// <summary>
        /// 保存中药用法带出项目
        /// </summary>
        /// <param name="p_blnIsAddNew">是否保存新增</param>
        private bool m_mthblnSave(bool p_blnIsAddNew)
        {
            //获取对象
            clsBridgeForUsaEdit objItem;
            GetObjectFromControl(out objItem);
            //验证对象
            if (!CheckObjectForSave(objItem)) return false;
            //保存
            long lngRes = 0;
            string strRecordID = "";
            clsChargeItemUsageGroup_VO objItem1 = new clsChargeItemUsageGroup_VO();
            objItem1 = objItem;
            if (m_objViewer.m_intOperateState != 1)
            {//新增
                lngRes = new clsDomainControl_ChargeItem().m_lngDoAddNewChargeItemCMUsageGroup(out strRecordID, objItem1);
            }
            else
            {//修改
                if (objItem1.m_strTOTALPRICE.Trim() != objItem1.m_strItemID.Trim())
                {
                    if (MessageBox.Show("是否将把其他用法的相同项目更新为些项目？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objItem1.m_intFlag = 1;
                    }
                }

                lngRes = new clsDomainControl_ChargeItem().m_lngDoModifyChargeItemCMUsageGroup(objItem1);
            }
            if (lngRes > 0)
            {
                MessageBox.Show(m_objViewer, "操作成功!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(m_objViewer, "操作失败!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return (lngRes > 0) ? (true) : (false);
        }
        #endregion

        #region 获取住院执行科室
        /// <summary>
        /// 获取住院执行科室
        /// yibin.zheng
        /// </summary>
        /// <returns></returns>
        public long m_lngGetZyExecDept()
        {
            com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc =
                           (com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));

            clsBSEUsageType[] arrType;
            long lngRes = objSvc.m_lngGetAllDepartment(out arrType);
            if (lngRes > 0 && arrType != null)
            {
                DataTable dtbResult = new DataTable();
                dtbResult.Columns.Add("编  号");
                dtbResult.Columns.Add("科 室 名 称");
                dtbResult.Columns.Add("拼 音 码");
                dtbResult.Columns.Add("deptid_chr");

                DataRow dr = null;
                for (int i1 = 0; i1 < arrType.Length; i1++)
                {
                    dr = dtbResult.NewRow();
                    dr["编  号"] = arrType[i1].m_strUserCode;
                    dr["科 室 名 称"] = arrType[i1].m_strUsageName;
                    dr["拼 音 码"] = arrType[i1].m_strPYCODE_VCHR;
                    dr["deptid_chr"] = arrType[i1].m_strUsageID;
                    dtbResult.Rows.Add(dr);
                }
                dtbResult.AcceptChanges();
                this.m_objViewer.m_ctfDefDept.m_GetDataTable = dtbResult;
            }
            return lngRes;
        }
        #endregion
    }
}
