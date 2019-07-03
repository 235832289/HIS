using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.HIS;
namespace com.digitalwave.controls.DGCS
{
	/// <summary>
	/// UserControl1 的摘要说明。
	/// </summary>
	public class txtLoadRecipeNo : System.Windows.Forms.UserControl
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		/// <summary>
		/// 
		/// </summary>
		public event System.EventHandler RecipeSelected;
		/// <summary>
		/// 
		/// </summary>
		public txtLoadRecipeNo()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitComponent 调用后添加任何初始化

		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region 组件设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.txtRecipeNo = new System.Windows.Forms.TextBox();
			this.tv = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// txtRecipeNo
			// 
			this.txtRecipeNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtRecipeNo.Font = new System.Drawing.Font("宋体", 10.5F);
			this.txtRecipeNo.Location = new System.Drawing.Point(0, 0);
			this.txtRecipeNo.Name = "txtRecipeNo";
			this.txtRecipeNo.Size = new System.Drawing.Size(160, 23);
			this.txtRecipeNo.TabIndex = 0;
			this.txtRecipeNo.Text = "";
			this.txtRecipeNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRecipeNo_KeyDown);
			// 
			// tv
			// 
			this.tv.FullRowSelect = true;
			this.tv.HideSelection = false;
			this.tv.ImageIndex = -1;
			this.tv.Indent = 14;
			this.tv.Location = new System.Drawing.Point(4, 32);
			this.tv.Name = "tv";
			this.tv.SelectedImageIndex = -1;
			this.tv.Size = new System.Drawing.Size(160, 152);
			this.tv.TabIndex = 1;
			this.tv.Visible = false;
			this.tv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tv_KeyDown);
			this.tv.DoubleClick += new System.EventHandler(this.tv_DoubleClick);
			this.tv.Leave += new System.EventHandler(this.tv_Leave);
			// 
			// txtLoadRecipeNo
			// 
			this.Controls.Add(this.tv);
			this.Controls.Add(this.txtRecipeNo);
			this.Name = "txtLoadRecipeNo";
			this.Size = new System.Drawing.Size(160, 23);
			this.Load += new System.EventHandler(this.txtLoadRecipeNo_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private System.Windows.Forms.TextBox txtRecipeNo;
		private System.Windows.Forms.TreeView tv;

		#region 设计病人ID属性
		private string strPatientID="";
		/// <summary>
		/// 设置病人ID
		/// </summary>
		public string PatientID
		{
			set
			{
				strPatientID=value;
			
			}
		}
		/// <summary>
		/// 设置或获取文本
		/// </summary>
		public override string Text
		{
			set 
			{
			this.txtRecipeNo.Text=value;
			}
			get
			{
			return this.txtRecipeNo.Text;
			}
		}
		#endregion
		#region  获取处方号
		private clsRecipeInfo_VO objRecipeInfo_VO=null;
		/// <summary>
		/// 获取处方号
		/// </summary>
		public clsRecipeInfo_VO RecipeInfo
		{
			get
			{
				return objRecipeInfo_VO;
			}
		}
		#endregion

		#region  标志 (在门诊收费使用 1,医生工作站使用 2)
		private int intFalg=1;
		/// <summary>
		/// 获取处方号
		/// </summary>
		public int UseFlag
		{
			set
			{
				intFalg=value;
			}
		}
		#endregion

		#region 加载处方号
		/// <summary>
        /// 加载处方号
		/// </summary>
		/// <param name="strID"></param>
		public void m_mthLoadRecipeNo(string strID)
		{
			clsRecipeInfo_VO[] objRI_VO=null;
			com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
			long l=	objSvc.m_mthFindRecipeNoByPatientID(null,strPatientID, out objRI_VO,strID,intFalg);
			
//			ArrayList  objArr;
//			if(l>0&&objRI_VO!=null)
//			{
//				this.m_mthFilter(objRI_VO,out objArr);
//			}
//			else
//			{
//				return;
//			}
			if(l>0&&objRI_VO!=null)
			{
				if(objRI_VO.Length==1)
				{
					this.objRecipeInfo_VO=objRI_VO[0];

                    this.txtRecipeNo.Text = objRecipeInfo_VO.m_strOUTPATRECIPEID_CHR;
                    if (RecipeSelected != null)
                    {
                        RecipeSelected(this, null);
                        if (this.objRecipeInfo_VO != null)
                        {
                            this.txtRecipeNo.ForeColor = this.m_mthCreatColor(this.objRecipeInfo_VO.m_intPSTATUS_INT);
                        }
                    }                    
				}
				else
				{
					this.m_mthFillTreeView(objRI_VO);
				}				
			}
		}
		private void m_mthFilter(clsRecipeInfo_VO[] objRI_VO,out ArrayList  objArr)
		{
			objArr=new ArrayList();
			for(int i=0;i<objRI_VO.Length;i++)
			{
				if(objRI_VO[i].m_intPSTATUS_INT!=1||this.intFalg!=2)
				{
					objArr.Add(objRI_VO[i]);
				}
			}
		}
		private void m_mthFillTreeView(clsRecipeInfo_VO[] p_objRI_VO)
		{
			this.tv.Nodes.Clear();
			this.tv.Height=20+15*p_objRI_VO.Length;
			if(this.tv.Height>300)
			{
				this.tv.Height=300;
			}
			
			clsRecipeInfo_VO objRI_VO;
			string strdate;//日期
			bool flag;
			for(int i=0;i<p_objRI_VO.Length;i++)
			{
				objRI_VO=p_objRI_VO[i];
				flag=true;
				if(i==0)
				{
					m_mthAddNewNode(objRI_VO);
				}
				else
				{
					strdate=DateTime.Parse(objRI_VO.m_strCreatTime).ToString("yyyy年MM月dd日");
					for(int i2=0;i2<this.tv.Nodes.Count;i2++)
					{
						if(strdate==this.tv.Nodes[i2].Text.Trim())
						{
							TreeNode subtn =new TreeNode(objRI_VO.m_strOUTPATRECIPEID_CHR);
//							switch(objRI_VO.m_intPSTATUS_INT)
//							{
//								case 0:
//									subtn.ForeColor=Color.Black;
//									break;
//								case 1:
//									subtn.ForeColor=Color.Blue;
//									break;
//								default:
//									subtn.ForeColor=Color.Red;
//									break;
//							}
							subtn.ForeColor =this.m_mthCreatColor(objRI_VO.m_intPSTATUS_INT);
							subtn.Tag=objRI_VO;
							this.tv.Nodes[i2].Nodes.Add(subtn);
							flag=false;
							break;
						}
												
					}
					if(flag)
					{
						m_mthAddNewNode(objRI_VO);
					}
				}
					
			}
			this.m_mthShowTreeView();

		}
		#endregion
		#region 新增一个节点
		private void m_mthAddNewNode(clsRecipeInfo_VO objRI_VO)
		{
			string strdate=DateTime.Parse(objRI_VO.m_strCreatTime).ToString("yyyy年MM月dd日");
			TreeNode tn=new TreeNode(strdate);
			TreeNode subtn =new TreeNode(objRI_VO.m_strOUTPATRECIPEID_CHR);
//			switch(objRI_VO.m_intPSTATUS_INT)
//			{
//				case 1:
//					subtn.ForeColor=Color.Brown;
//					break;
//				case 2:
//					subtn.ForeColor=Color.Red;
//					break;
//			}
			subtn.ForeColor =this.m_mthCreatColor(objRI_VO.m_intPSTATUS_INT);
			subtn.Tag=objRI_VO;
			tn.Nodes.Add(subtn);
			this.tv.Nodes.Add(tn);
		}
		#endregion
		private Color m_mthCreatColor(int p_flag)
		{
			Color ret =Color.Black;
			switch(p_flag)
			{
				case 1:
					ret=Color.Green;
					break;
				case -2:
					ret=Color.Brown;
					break;
				case 2:
					ret=Color.Red;
					break;
				case 3:
					ret=Color.Red;
					break;
                case 5:
                    ret = Color.Orange;
                    break;
			}
			return ret;
		}
		#region 显示treeView
		private void m_mthShowTreeView()
		{

			this.tv.Show();
			this.tv.BringToFront();
			this.tv.Nodes[0].Expand();
			this.tv.Nodes[0].TreeView.SelectedNode=this.tv.Nodes[0].Nodes[0];
			this.tv.Focus();
			this.tv.Select();
		}
		#endregion
		#region  从treeView选择处方号
		private void m_mthSelectRecipe()
		{
			try
			{
				if(this.tv.SelectedNode.Tag != null)
				{
					this.objRecipeInfo_VO = (clsRecipeInfo_VO)this.tv.SelectedNode.Tag;
					this.tv.Hide();
					this.txtRecipeNo.Text = objRecipeInfo_VO.m_strOUTPATRECIPEID_CHR;
					this.txtRecipeNo.ForeColor = this.m_mthCreatColor(this.objRecipeInfo_VO.m_intPSTATUS_INT);
					if(RecipeSelected != null)
					{
						RecipeSelected(this,null);
					}
					
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		#endregion
		#region  窗体事件
		private void txtLoadRecipeNo_Load(object sender, System.EventArgs e)
		{

			this.FindForm().Controls.Add(this.tv);
						this.tv.Font = new System.Drawing.Font("宋体", 9F);
			Point p =this.txtRecipeNo.Parent.PointToScreen(this.txtRecipeNo.Location);
			p.Offset(0,this.txtRecipeNo.Height);
			p=this.FindForm().PointToClient(p);
			this.tv.Location=p;
		}

		private void tv_Leave(object sender, System.EventArgs e)
		{
			this.tv.Hide();
		}
		
		private void txtRecipeNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.m_mthLoadRecipeNo(txtRecipeNo.Text);
			}
		}
		private void tv_DoubleClick(object sender, System.EventArgs e)
		{
			this.m_mthSelectRecipe();
		}

		private void tv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.m_mthSelectRecipe();
			}
		}
		#endregion
		#region
		/// <summary>
		/// 清空数据
		/// </summary>
		public void m_mthClearText()
		{
            
		    this.txtRecipeNo.Clear();
            this.objRecipeInfo_VO = null;
		}
		/// <summary>
		/// 设置焦点
		/// </summary>
		public void m_mthSetFoucs()
		{
		this.txtRecipeNo.Focus();
		}
		#endregion
		
		

		

		
	}
}
