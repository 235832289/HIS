using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
//using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.common;	//objectGenerator.dll
using com.digitalwave.iCare.ValueObject;	//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS
{
	#region 药理分类维护窗口
	/// <summary>
	/// 药理分类维护窗口
	/// Create 黄伟灵 by 2005-09-8
	/// </summary>
	public class clsControlHISMedTypeManage : com.digitalwave.GUI_Base.clsController_Base	//GUI_Base.dll
	{
		#region 构造函数
		public clsControlHISMedTypeManage()
		{
			m_objManage = new clsDomainControlHISMedTypeManage();
			//m_objClsPublicParm = new clsPublicParm();
		}
		#endregion

		#region 变量
		/// <summary>
		/// DomainControl对象
		/// </summary>
		private clsDomainControlHISMedTypeManage m_objManage = null;
		
		/// <summary>
		/// frm窗体对象
		/// </summary>
		private com.digitalwave.iCare.gui.HIS.frmHISMedTypeManage m_objViewer ;

		#endregion

		#region 设置窗体对象，override Set_GUI_Apperance 实现
		
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			// TODO:  添加 Set_GUI_Apperance 实现
			base.Set_GUI_Apperance (frmMDI_Child_Base_in);
			this.m_objViewer = (frmHISMedTypeManage)frmMDI_Child_Base_in;
		}
		#endregion

		#region 加载主结点
		/// <summary>
		/// 加载主结点
		/// </summary>
		public void m_mthGetMainItem()
		{		
			com.digitalwave.iCare.ValueObject.clsHISMedType_VO[] objResultArr;
			long ret = m_objManage.m_lngGetMedTypeInfo(out objResultArr,"");
			
			if(objResultArr!=null)
			{
				DataTable dtb ;
				this.m_mthCreateDataTable(out dtb,objResultArr);
				this.InitTree(this.m_objViewer.m_trvMedType.Nodes, dtb,"");				
			}
		}
		#endregion

		#region 首先构造一个TABLE
		/// <summary>
		/// 首先构造一个TABLE,并以第二参数填写值,返回一个TABLE(第一参数）
		/// </summary>
		void m_mthCreateDataTable(out System.Data.DataTable p_dtb, clsHISMedType_VO[] p_objMedTypeVoArr)
		{
			p_dtb = new DataTable("tree");
			//开始建表
			System.Data.DataColumn dcol = new DataColumn("PHARMAID_CHR");
			p_dtb.Columns.Add(dcol);
			dcol = new DataColumn("PHARMANAME_VCHR");
			p_dtb.Columns.Add(dcol);
			dcol = new DataColumn("ASSISTCODE_VCHR");
			p_dtb.Columns.Add(dcol);
			dcol = new DataColumn("PYCODE_VCHR");
			p_dtb.Columns.Add(dcol);
			dcol = new DataColumn("WBCODE_VCHR");
			p_dtb.Columns.Add(dcol);
			dcol = new DataColumn("PARENTID_CHR");
			p_dtb.Columns.Add(dcol);
			//建表结束
			
			//开始填写数据
			DataRow dr;
			for(int i1=0;i1<p_objMedTypeVoArr.Length;i1++)
			{	
				dr = p_dtb.NewRow();
				dr["PHARMAID_CHR"] = p_objMedTypeVoArr[i1].m_strPHARMAID_CHR;
				dr["PHARMANAME_VCHR"] = p_objMedTypeVoArr[i1].m_strPHARMANAME_VCHR;
				dr["ASSISTCODE_VCHR"] = p_objMedTypeVoArr[i1].m_strASSISTCODE_VCHR;
				dr["PYCODE_VCHR"] = p_objMedTypeVoArr[i1].m_strPYCODE_VCHR;
				dr["WBCODE_VCHR"] = p_objMedTypeVoArr[i1].m_strWBCODE_VCHR;
				if(p_objMedTypeVoArr[i1].m_strPARENTID_CHR == null)
					dr["PARENTID_CHR"] = "";
				else
					dr["PARENTID_CHR"] =p_objMedTypeVoArr[i1].m_strPARENTID_CHR;
				

				p_dtb.Rows.Add(dr);

			}
			//填写完毕
            
		}
		#endregion

				
		#region 初始化一个树的结点：递归方法
		/// <summary>
		/// 初始化一个树的结点：递归方法
		/// </summary>
		private void InitTree(TreeNodeCollection Nds,DataTable p_dtb,string parentId)
		{
			DataView dv=new DataView();
			TreeNode tmpNd;
			
			dv.Table=p_dtb;
			dv.RowFilter="PARENTID_CHR='"+ parentId+"'";
			foreach(DataRowView drv in dv)
			{
				tmpNd=new TreeNode();
				string ID = drv["PHARMAID_CHR"].ToString();
				tmpNd.Text=drv["PHARMANAME_VCHR"].ToString();

				//one Row转化为一个VO存入结点的tag
				clsHISMedType_VO objMedTypeVo = new clsHISMedType_VO();
				objMedTypeVo.m_strPHARMAID_CHR = drv["PHARMAID_CHR"].ToString();
				objMedTypeVo.m_strPHARMANAME_VCHR = drv["PHARMANAME_VCHR"].ToString();
				objMedTypeVo.m_strASSISTCODE_VCHR = drv["ASSISTCODE_VCHR"].ToString();
				objMedTypeVo.m_strPYCODE_VCHR = drv["PYCODE_VCHR"].ToString();
				objMedTypeVo.m_strWBCODE_VCHR = drv["WBCODE_VCHR"].ToString();
				objMedTypeVo.m_strPARENTID_CHR = drv["PARENTID_CHR"].ToString();

				tmpNd.Tag = objMedTypeVo;
				//存入结束
								
				Nds.Add(tmpNd);
			
				InitTree(tmpNd.Nodes,p_dtb,ID);	

			}
		}
		#endregion

		#region 加载结点
		/// <summary>
		/// 加载结点:递归函数即可!无级别限制.
		/// </summary>
		public void BuildTree(string ParentID,TreeNode td)
		{			
			com.digitalwave.iCare.ValueObject.clsHISMedType_VO[] objResultArr;
			long ret = m_objManage.m_lngGetMedTypeInfo(out objResultArr,ParentID);
			
			if(objResultArr!=null)
			{
				TreeNode tr;
				for(int i=0;i<objResultArr.Length;i++)
				{	
					tr =new TreeNode(objResultArr[i].m_strPHARMANAME_VCHR);
					tr.Tag =objResultArr[i];

					td.Nodes.Add(tr);
					BuildTree(objResultArr[i].m_strPHARMAID_CHR,tr);
				}
			} 
		}
		#endregion

		#region 初始化窗体:首先把焦点放在分类名称
		/// <summary>
		/// 初始化窗体
		/// </summary>
		public void m_mthSetFirstFocus()
		{		
			this.m_objViewer.m_txtMedName.TabIndex = 0;
			this.m_objViewer.m_txtMedName.Focus();

		}
		#endregion

		#region 选择节点
		/// <summary>
		/// 选择节点
		/// </summary>
		public void m_mthSelectNode(TreeNode p_tr)
		{
			if(p_tr==null)
			{
				return;
			}
			if(p_tr.Tag==null)
			{
				return;
			}
			com.digitalwave.iCare.ValueObject.clsHISMedType_VO objTD_VO =p_tr.Tag as com.digitalwave.iCare.ValueObject.clsHISMedType_VO;
			this.m_objViewer.m_lbeType.Text =p_tr.FullPath;
			m_mthFillTextBoxByVO(objTD_VO);
			this.m_objViewer.m_lbeType.Tag=p_tr;
		

		}
		private void m_mthFillTextBoxByVO(com.digitalwave.iCare.ValueObject.clsHISMedType_VO objTD_VO )
		{
			this.m_objViewer.m_txtMedName.Text =objTD_VO.m_strPHARMANAME_VCHR;
			this.m_objViewer.m_txtMedZhuJi.Text=objTD_VO.m_strASSISTCODE_VCHR;
			this.m_objViewer.m_txtMedPy.Text =objTD_VO.m_strPYCODE_VCHR;
			this.m_objViewer.m_txtMedWb.Text=objTD_VO.m_strWBCODE_VCHR;

		}
		#endregion

		#region 新增主节点
		/// <summary>
		/// 新增主节点:清空txtbox
		/// </summary>
		public void m_mthAddMain()
		{
			this.m_objViewer.m_lbeType.Text ="";
			this.m_objViewer.m_txtMedName.Text ="";
			this.m_objViewer.m_txtMedPy.Text="";
			this.m_objViewer.m_txtMedWb.Text ="";
			this.m_objViewer.m_txtMedZhuJi.Text="";
			this.m_objViewer.m_txtMedName.Focus();
		}

		#endregion

		#region 新增子节点
		/// <summary>
		/// 新增子节点:清空txtbox
		/// </summary>
		public void m_mthAddSub()
		{
			//TreeNode trn = this.m_objViewer.m_lbeType.Tag as TreeNode;
			
			if(this.m_objViewer.m_trvMedType.SelectedNode == null)
			{
				MessageBox.Show("请选择节点");
				return;
			}

			this.m_objViewer.m_lbeType.Text ="";
			this.m_objViewer.m_txtMedName.Text ="";
			this.m_objViewer.m_txtMedPy.Text="";
			this.m_objViewer.m_txtMedWb.Text ="";
			this.m_objViewer.m_txtMedZhuJi.Text="";
			this.m_objViewer.m_txtMedName.Focus();

			TreeNode objTreeNode =this.m_objViewer.m_lbeType.Tag as TreeNode;
			this.m_objViewer.m_lbeType .Text = objTreeNode.FullPath.ToString();
			
		}

		#endregion

		#region 保存
		/// <summary>
		/// 保存新增数据
		/// </summary>
		/// <param name="p_strUserOp">用户操作标志：增加主结点，子结点，修改</param>
		
		public void m_mthSave(string p_strUserOp)
		{
			if(this.m_objViewer.m_txtMedName.Text.Trim()=="")
			{
				MessageBox.Show("名称不能为空");
				return;
			}
			if(!m_mthCheckMaxDataLength())
				return;
			clsHISMedType_VO objTD_VO;
			m_mthGetData(out objTD_VO, p_strUserOp);
			long ret =0;
			if(p_strUserOp == "AddTop" || p_strUserOp =="AddSub")
			{	
				// 检查助记码的唯一性
				if(m_mthCheck())
					return ;
				//检查完毕

				//调增加方法	
				clsHISMedType_VO objTDReturn_VO;
				ret =m_objManage.m_lngAddNew(objTD_VO,out objTDReturn_VO);
				if(ret>0)
				{
					MessageBox.Show("保存成功！");
					TreeNode tr =new TreeNode(objTDReturn_VO.m_strPHARMANAME_VCHR);
					tr.Tag =objTDReturn_VO;

					if(p_strUserOp == "AddTop")
					{
						this.m_objViewer.m_trvMedType.Nodes.Add(tr);
					}
					else
					{							
						((TreeNode)this.m_objViewer.m_lbeType.Tag).Nodes.Add(tr);						
					}
					this.m_objViewer.m_lbeType.Tag =tr;
					this.m_objViewer.m_trvMedType.SelectedNode =tr;
				}
			}
			else if (p_strUserOp == "Save")
			{
				//检查助记码的唯一性：
				TreeNode nodeSave = this.m_objViewer.m_lbeType.Tag as TreeNode;
				com.digitalwave.iCare.ValueObject.clsHISMedType_VO objMedSave_VO =nodeSave.Tag as com.digitalwave.iCare.ValueObject.clsHISMedType_VO;
				if(objMedSave_VO.m_strASSISTCODE_VCHR != objTD_VO.m_strASSISTCODE_VCHR)
				{					
					if(m_mthCheck())
					{
						this.m_objViewer.m_strUserOp = "Save";
						return ;
					}
					//检查完毕
				}
				//检查完毕

				//调用修改方法
				ret = this.m_objManage.m_lngModify(objTD_VO);
				if(ret>0)
				{
					MessageBox.Show("保存成功！");
					TreeNode tr =this.m_objViewer.m_lbeType.Tag as TreeNode;
					tr.Text =objTD_VO.m_strPHARMANAME_VCHR;
					tr.Tag =objTD_VO;
				}
			}
			if(ret<1)
			{
				MessageBox.Show("保存失败！");
			}
		}
		#endregion

		#region 修改结点
		/// <summary>
		/// 修改结点
		/// </summary>		
		public void m_mthAlter()
		{

			TreeNode nodeSave = this.m_objViewer.m_lbeType.Tag as TreeNode;
			if(nodeSave != null)
			{	
				if(this.m_objViewer.m_txtMedName.Text.Trim()=="")
				{
					MessageBox.Show("名称不能为空");
					return;
				}
				clsHISMedType_VO objTD_VO;
				m_mthGetData(out objTD_VO, "Save"); //取出要修改的数据
				long ret =0;
			
				//检查助记码的唯一性：
			
				com.digitalwave.iCare.ValueObject.clsHISMedType_VO objMedSave_VO =nodeSave.Tag as com.digitalwave.iCare.ValueObject.clsHISMedType_VO;
				if(objMedSave_VO.m_strASSISTCODE_VCHR != objTD_VO.m_strASSISTCODE_VCHR)
				{					
					if(m_mthCheck())
					{						
						return ;
					}				
				}
				//检查完毕

				//调用修改方法
				ret = this.m_objManage.m_lngModify(objTD_VO);
				if(ret>0)
				{
					MessageBox.Show("修改成功！");
					TreeNode tr =this.m_objViewer.m_lbeType.Tag as TreeNode;
					tr.Text =objTD_VO.m_strPHARMANAME_VCHR;
					tr.Tag =objTD_VO;
				}			
				if(ret<1)
				{
					MessageBox.Show("修改失败！");
				}
			}
			else
			{
				MessageBox.Show("请先选择某分类！");
			}
		}
		#endregion
		#region 取出数据封装到要存到数据库的VO对象
		/// <summary>
		/// 取出数据封装到要存到数据库的VO对象
		/// </summary>
		/// <param name="p_strUserOp">用户操作标志：增加主结点，子结点，修改</param>
		/// <param name="objTD_VO">VO</param>
		/// 
		public void m_mthGetData(out com.digitalwave.iCare.ValueObject.clsHISMedType_VO objTD_VO, string p_strUserOp)
		{
			objTD_VO =new clsHISMedType_VO();
			
			switch(p_strUserOp)
			{				
				case "AddTop":

					break;
				case "AddSub":		
					TreeNode node = this.m_objViewer.m_lbeType.Tag as TreeNode;
					com.digitalwave.iCare.ValueObject.clsHISMedType_VO objMed_VO =node.Tag as com.digitalwave.iCare.ValueObject.clsHISMedType_VO;
					objTD_VO.m_strPARENTID_CHR = objMed_VO.m_strPHARMAID_CHR;//取得父结点的ID
					break;
			
				case "Save":
					
					TreeNode nodeSave = this.m_objViewer.m_lbeType.Tag as TreeNode;
					com.digitalwave.iCare.ValueObject.clsHISMedType_VO objMedSave_VO =nodeSave.Tag as com.digitalwave.iCare.ValueObject.clsHISMedType_VO;
					objTD_VO.m_strPARENTID_CHR = objMedSave_VO.m_strPARENTID_CHR;//取得父结点的ID
					objTD_VO.m_strPHARMAID_CHR = objMedSave_VO.m_strPHARMAID_CHR;//取得要修改的结点的ID
					
					break;
				default:
					break;
			}

			objTD_VO.m_strPHARMANAME_VCHR = this.m_objViewer.m_txtMedName.Text.Trim();
			objTD_VO.m_strPYCODE_VCHR = this.m_objViewer.m_txtMedPy.Text.Trim();
			objTD_VO.m_strWBCODE_VCHR = this.m_objViewer.m_txtMedWb.Text.Trim();
			objTD_VO.m_strASSISTCODE_VCHR = this.m_objViewer.m_txtMedZhuJi.Text.Trim();
            	
		}
		#endregion

		#region 删除节点
		/// <summary>
		/// 删除节点
		/// </summary>
		public void m_mthDelete()
		{
			if(this.m_objViewer.m_lbeType.Tag==null)
			{
				return;
			}
			TreeNode tr =this.m_objViewer.m_lbeType.Tag as TreeNode;
			clsHISMedType_VO objTD_VO =tr.Tag as clsHISMedType_VO;
			DialogResult dr;
			
			bool blnHasSubNode = false;
			this.m_objManage.m_lngCheckMedTypeIsHasSubById(out blnHasSubNode,objTD_VO.m_strPHARMAID_CHR);
			if(blnHasSubNode)
			{
				MessageBox.Show("此节点存在子结点，禁止删除！应先删除其子结点！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return ;
				//dr =MessageBox.Show("当前节点是主节点，删除此节点将删除此节点的所有子节点，\n是否删除？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
			}
			else
			{
				dr =MessageBox.Show("是否删除此节点？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
			}
			if(dr==DialogResult.OK)
			{
				long ret = -1;
				if(blnHasSubNode)//objTD_VO.m_strPARENTID_CHR == "")
				{
					//在此删除本结点与下级结点
					m_mthBianLi(tr, out ret);
				  
				}
				else
				{
					ret =this.m_objManage.m_lngDelete(objTD_VO);//在此删除本结点
				}
				
				if(ret>0)
				{
					MessageBox.Show("删除成功");
					
					this.m_objViewer.m_trvMedType.Nodes.Remove(tr);
				}
				else
				{
					MessageBox.Show("删除失败");
				}
			}
		}
		#endregion

		#region 根据某一结点，遍历其子结点，目的是取出要删除的子结点ID号，用于从数据库中删除
		/// <summary>
		/// <param name="p_trn">根据某一结点，遍历其子结点</param> 
		/// <param name="p_lngResult">操作的结果</param> 
		/// </summary>
		void m_mthBianLi(TreeNode p_trn,out long p_lngResult)
		{		
			p_lngResult = 1;
			foreach (TreeNode node in p_trn.Nodes)
			{
				clsHISMedType_VO objTD_VO =p_trn.Tag as clsHISMedType_VO;
				p_lngResult =this.m_objManage.m_lngDelete(objTD_VO);//从数据库中删除子结点
				m_mthBianLi(node, out p_lngResult);
			}			
		}
		#endregion

		#region 限定用户输入数据的长度
		bool m_mthCheckMaxDataLength()
		{
			string strError = string.Empty;
			if(this.m_objViewer.m_txtMedName.Text.Length>50)
				strError = "输入药理名称长度不能大于50";
			if(this.m_objViewer.m_txtMedZhuJi.Text.Length>20)
				strError = "输入助记名称长度不能大于20";
			if(this.m_objViewer.m_txtMedPy.Text.Length>20)
				strError = "输入拼音长度不能大于20";
			if(this.m_objViewer.m_txtMedWb.Text.Length>20)
				strError = "输入五笔名称长度不能大于20";
			if(strError != string.Empty)
			{	
				MessageBox.Show(strError);
				return false;
			}
			return true;
		}
		#endregion

		#region 判断助记码是否输入重复
		/// <summary>
		/// 判断助记码是否输入重复
		/// </summary>
		
		/// <param name="p_strZhuJiMa">助记码</param>		
		/// <returns blnHasThisZhujima>成功：true :证明输入的数据保证与库中的相同。</returns>
		/// 
		public bool m_blnHasThisZhujima(string p_strZhuJiMa)
		{
			bool blnHasThisZhujima = false;
			long lngRet = 0 ;
			
			lngRet = this.m_objManage.m_lngGetMedTypeZhuJiMaById(out blnHasThisZhujima, p_strZhuJiMa);
			if(lngRet>0)
			{
				return 	blnHasThisZhujima;
			}
			else
			{
				MessageBox.Show("操作失败");
				return false;
			}
			
		}

		#endregion

		#region  检查助记码的唯一性
		/// <summary>
		/// 返回真则证明已存在。
		/// </summary>
		/// <returns></returns>
		bool m_mthCheck()
		{
			if(this.m_objViewer.m_txtMedZhuJi.Text.Trim()!=string.Empty)
			{
				bool blnret = m_blnHasThisZhujima(this.m_objViewer.m_txtMedZhuJi.Text.Trim());				
				if(blnret)
				{
					MessageBox.Show("助记码已存在，重新输入");
					
					this.m_objViewer.m_txtMedZhuJi.Focus();
					this.m_objViewer.m_txtMedZhuJi.Clear();
					return true;
				}
				return false;
			}
			return false;
		}
		#endregion

	}
	#endregion
}
