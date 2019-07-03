using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.BIHOrder
{
	/// <summary>
	/// frmOrderTemplate 
	/// </summary>
	public class frmOrderTemplate : System.Windows.Forms.Form
	{
		
		#region 自定义变量 
		public ItemTag[] arlOrders=new ItemTag[0];
		public frmBIHOrderInput frmParent;
        // 为了同医嘱界面医嘱列表控件相对应
        
        // 当前医嘱对象是否已经存在
        ArrayList m_arrOrderDicID = new ArrayList();
        /// <summary>
        /// 用于复制及粘贴医嘱
        /// </summary>
        ArrayList m_arrOrderTempList = new ArrayList();
        /*<===========================*/
		#endregion

        private System.Windows.Forms.ImageList m_imgIcons;
		private System.Windows.Forms.ImageList m_imgBigIcons;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private PinkieControls.ButtonXP m_cmdAdd;
		private PinkieControls.ButtonXP m_cmdRemove;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox m_chkAll;
		private PinkieControls.ButtonXP m_cmdClear;
        private PinkieControls.ButtonXP m_cmdGroupAdd;
        internal DataGridView dgv_orderTemp;
        private DataGridViewCheckBoxColumn tmp_check;
        private DataGridViewTextBoxColumn tmp_Name;
        private DataGridViewTextBoxColumn tmp_ExecuteType;
        private DataGridViewTextBoxColumn tmp_Dosage;
        private DataGridViewTextBoxColumn tmp_UseType;
        private DataGridViewTextBoxColumn tmp_Freq;
        private DataGridViewTextBoxColumn tmp_Get;
		private System.ComponentModel.IContainer components;

		public frmOrderTemplate()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderTemplate));
            this.m_imgBigIcons = new System.Windows.Forms.ImageList(this.components);
            this.m_imgIcons = new System.Windows.Forms.ImageList(this.components);
            this.m_cmdAdd = new PinkieControls.ButtonXP();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.m_cmdRemove = new PinkieControls.ButtonXP();
            this.m_chkAll = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_cmdClear = new PinkieControls.ButtonXP();
            this.m_cmdGroupAdd = new PinkieControls.ButtonXP();
            this.dgv_orderTemp = new System.Windows.Forms.DataGridView();
            this.tmp_check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tmp_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_ExecuteType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_Dosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_UseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_Freq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_Get = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_orderTemp)).BeginInit();
            this.SuspendLayout();
            // 
            // m_imgBigIcons
            // 
            this.m_imgBigIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imgBigIcons.ImageStream")));
            this.m_imgBigIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imgBigIcons.Images.SetKeyName(0, "");
            this.m_imgBigIcons.Images.SetKeyName(1, "");
            // 
            // m_imgIcons
            // 
            this.m_imgIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imgIcons.ImageStream")));
            this.m_imgIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imgIcons.Images.SetKeyName(0, "");
            this.m_imgIcons.Images.SetKeyName(1, "");
            // 
            // m_cmdAdd
            // 
            this.m_cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAdd.DefaultScheme = true;
            this.m_cmdAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAdd.Hint = "";
            this.m_cmdAdd.Location = new System.Drawing.Point(268, 377);
            this.m_cmdAdd.Name = "m_cmdAdd";
            this.m_cmdAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAdd.Size = new System.Drawing.Size(71, 26);
            this.m_cmdAdd.TabIndex = 44;
            this.m_cmdAdd.Text = "生成医嘱";
            this.m_cmdAdd.Click += new System.EventHandler(this.m_cmdAdd_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(8, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(52, 24);
            this.radioButton1.TabIndex = 45;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "图略";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(76, 12);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(40, 24);
            this.radioButton2.TabIndex = 46;
            this.radioButton2.Text = "小图标";
            this.radioButton2.Visible = false;
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(64, 12);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(52, 24);
            this.radioButton3.TabIndex = 47;
            this.radioButton3.Text = "详细";
            // 
            // m_cmdRemove
            // 
            this.m_cmdRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdRemove.DefaultScheme = true;
            this.m_cmdRemove.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdRemove.Hint = "";
            this.m_cmdRemove.Location = new System.Drawing.Point(339, 377);
            this.m_cmdRemove.Name = "m_cmdRemove";
            this.m_cmdRemove.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdRemove.Size = new System.Drawing.Size(71, 26);
            this.m_cmdRemove.TabIndex = 48;
            this.m_cmdRemove.Text = "移 除";
            this.m_cmdRemove.Click += new System.EventHandler(this.m_cmdRemove_Click);
            // 
            // m_chkAll
            // 
            this.m_chkAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_chkAll.Location = new System.Drawing.Point(24, 377);
            this.m_chkAll.Name = "m_chkAll";
            this.m_chkAll.Size = new System.Drawing.Size(84, 24);
            this.m_chkAll.TabIndex = 49;
            this.m_chkAll.Text = "全选(&A)";
            this.m_chkAll.CheckedChanged += new System.EventHandler(this.m_chkAll_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(12, 409);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(124, 40);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // m_cmdClear
            // 
            this.m_cmdClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClear.DefaultScheme = true;
            this.m_cmdClear.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClear.Hint = "";
            this.m_cmdClear.Location = new System.Drawing.Point(411, 377);
            this.m_cmdClear.Name = "m_cmdClear";
            this.m_cmdClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClear.Size = new System.Drawing.Size(71, 26);
            this.m_cmdClear.TabIndex = 51;
            this.m_cmdClear.Text = "清 空";
            this.m_cmdClear.Click += new System.EventHandler(this.m_cmdClear_Click);
            // 
            // m_cmdGroupAdd
            // 
            this.m_cmdGroupAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdGroupAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdGroupAdd.DefaultScheme = true;
            this.m_cmdGroupAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdGroupAdd.Hint = "";
            this.m_cmdGroupAdd.Location = new System.Drawing.Point(438, 376);
            this.m_cmdGroupAdd.Name = "m_cmdGroupAdd";
            this.m_cmdGroupAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdGroupAdd.Size = new System.Drawing.Size(72, 28);
            this.m_cmdGroupAdd.TabIndex = 52;
            this.m_cmdGroupAdd.Text = "设为组套";
            this.m_cmdGroupAdd.Visible = false;
            // 
            // dgv_orderTemp
            // 
            this.dgv_orderTemp.AllowUserToAddRows = false;
            this.dgv_orderTemp.BackgroundColor = System.Drawing.Color.White;
            this.dgv_orderTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_orderTemp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tmp_check,
            this.tmp_Name,
            this.tmp_ExecuteType,
            this.tmp_Dosage,
            this.tmp_UseType,
            this.tmp_Freq,
            this.tmp_Get});
            this.dgv_orderTemp.Location = new System.Drawing.Point(12, 12);
            this.dgv_orderTemp.Name = "dgv_orderTemp";
            this.dgv_orderTemp.ReadOnly = true;
            this.dgv_orderTemp.RowHeadersVisible = false;
            this.dgv_orderTemp.RowTemplate.Height = 23;
            this.dgv_orderTemp.Size = new System.Drawing.Size(483, 361);
            this.dgv_orderTemp.TabIndex = 53;
            this.dgv_orderTemp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_orderTemp_CellClick);
            // 
            // tmp_check
            // 
            this.tmp_check.FalseValue = "0";
            this.tmp_check.HeaderText = "";
            this.tmp_check.Name = "tmp_check";
            this.tmp_check.ReadOnly = true;
            this.tmp_check.TrueValue = "1";
            this.tmp_check.Width = 30;
            // 
            // tmp_Name
            // 
            this.tmp_Name.HeaderText = "名称";
            this.tmp_Name.Name = "tmp_Name";
            this.tmp_Name.ReadOnly = true;
            // 
            // tmp_ExecuteType
            // 
            this.tmp_ExecuteType.HeaderText = "长/临";
            this.tmp_ExecuteType.Name = "tmp_ExecuteType";
            this.tmp_ExecuteType.ReadOnly = true;
            this.tmp_ExecuteType.Width = 80;
            // 
            // tmp_Dosage
            // 
            this.tmp_Dosage.HeaderText = "用量 ";
            this.tmp_Dosage.Name = "tmp_Dosage";
            this.tmp_Dosage.ReadOnly = true;
            this.tmp_Dosage.Width = 60;
            // 
            // tmp_UseType
            // 
            this.tmp_UseType.HeaderText = "用法";
            this.tmp_UseType.Name = "tmp_UseType";
            this.tmp_UseType.ReadOnly = true;
            this.tmp_UseType.Width = 60;
            // 
            // tmp_Freq
            // 
            this.tmp_Freq.HeaderText = "频率";
            this.tmp_Freq.Name = "tmp_Freq";
            this.tmp_Freq.ReadOnly = true;
            this.tmp_Freq.Width = 60;
            // 
            // tmp_Get
            // 
            this.tmp_Get.HeaderText = "领量";
            this.tmp_Get.Name = "tmp_Get";
            this.tmp_Get.ReadOnly = true;
            this.tmp_Get.Width = 80;
            // 
            // frmOrderTemplate
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(507, 413);
            this.Controls.Add(this.dgv_orderTemp);
            this.Controls.Add(this.m_cmdClear);
            this.Controls.Add(this.m_cmdGroupAdd);
            this.Controls.Add(this.m_cmdRemove);
            this.Controls.Add(this.m_cmdAdd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_chkAll);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmOrderTemplate";
            this.Text = "frmOrderTemplate";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_orderTemp)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		
		private void m_lngAddOrder(ItemTag p_objAdd)
		{
            this.dgv_orderTemp.Rows.Add();

            DataGridViewRow objRow = this.dgv_orderTemp.Rows[this.dgv_orderTemp.RowCount - 1];

            objRow.Height = 20;

            //序
            //objRow.Cells["tmp_NO"].Value = this.dgv_orderTemp.RowCount.ToString();
            objRow.Cells["tmp_check"].Value = "1";
            //名称
            objRow.Cells["tmp_Name"].Value = p_objAdd.objOrder.m_strName;
            //“方法”列。用于显示检验医嘱的样本类型，和检查医嘱的部位信息
            //if (!objOrder.m_strPARTID_VCHR.Trim().Equals(""))
            //{
            //    objRow.Cells["tmp_method"].Value = objOrder.m_strPARTNAME_VCHR;
            //}
            //else if (!objOrder.m_strSAMPLEID_VCHR.Trim().Equals(""))
            //{
            //    objRow.Cells["tmp_method"].Value = objOrder.m_strSAMPLEName_VCHR;
            //}


            ////总量  N天共M片。N-表示出院带药的天数，M-表示出院带药合计的数量
            //if (objOrder.m_intExecuteType == 3)
            //{
            //    objRow.Cells["tmp_sum"].Value = objOrder.m_intOUTGETMEDDAYS_INT.ToString() + "天共" + Convert.ToString(objOrder.m_dmlGet * objOrder.m_intOUTGETMEDDAYS_INT) + objOrder.m_strGetunit;
            //}
            //else
            //{
            //    objRow.Cells["tmp_sum"].Value = "";
            //}
            ////objRow["TotalMoney"] =(double.Parse(objOrder.m_dmlGet.ToString()) * double.Parse(objOrder.m_dmlPrice.ToString())).ToString("0.00");
           //执行时间/嘱托
            //objRow.Cells["tmp_ENTRUST"].Value = objOrder.m_strEntrust;
            //自备药 (1-全计费 1-否)( 2-用法收费 2-是)(3 不计费 作废)
            //switch (objOrder.m_intRateType)
            //{
            //    case 0:
            //        objRow.Cells["RATETYPE_INT"].Value = "否";
            //        break;
            //    case 1:
            //        objRow.Cells["RATETYPE_INT"].Value = "是";
            //        break;
            //    case 2:
            //        objRow.Cells["RATETYPE_INT"].Value = "";
            //        break;

            //}


            /*<===============================*/
            #region 医嘱类型控制列表界面
           // clsT_aid_bih_ordercate_VO p_objItem = (clsT_aid_bih_ordercate_VO)this.m_frmInput.m_htOrderCate[objOrder.m_strOrderDicCateID];
            //clsT_aid_bih_ordercate_VO p_objItem = new clsT_aid_bih_ordercate_VO();
            //if (p_objItem != null)
            //{
            //    if (p_objItem.m_intDOSAGEVIEWTYPE == 1)
            //    {
            //        //用量
            //        if (objOrder.m_dmlDosage > 0)
            //        {
            //            objRow.Cells["tmp_Dosage"].Value = objOrder.m_dmlDosage.ToString() + " " + objOrder.m_strDosageUnit;
            //        }
            //        else
            //        {
            //            objRow.Cells["tmp_Dosage"].Value = "";

            //        }
            //    }
            //    else
            //    {
            //        objRow.Cells["tmp_Dosage"].Value = "";
            //    }
            //    if (p_objItem.m_intExecuFrenquenceType == 1)
            //    {
            //        //频率
            //        objRow.Cells["tmp_Freq"].Value = objOrder.m_strExecFreqName;
            //    }
            //    else
            //    {
            //        //频率
            //        objRow.Cells["tmp_Freq"].Value = "";
            //    }
            //    if (p_objItem.m_intUSAGEVIEWTYPE == 1)
            //    {
            //        //用法
            //        objRow.Cells["tmp_UseType"].Value = objOrder.m_strDosetypeName;
            //    }
            //    else
            //    {
            //        //用法
            //        objRow.Cells["tmp_UseType"].Value = "";
            //    }
            //    if (p_objItem.m_intAPPENDVIEWTYPE_INT == 1)
            //    {
            //        //补次
            //        objRow.Cells["ATTACHTIMES_INT"].Value = objOrder.m_intATTACHTIMES_INT;
            //    }
            //    else
            //    {
            //        //补次
            //        objRow.Cells["ATTACHTIMES_INT"].Value = "";
            //    }
            //    //领量
            //    if (p_objItem.m_intQTYVIEWTYPE_INT == 1)
            //    {
            //        if (objOrder.m_dmlGet > 0)
            //        {
            //            objRow.Cells["tmp_Get"].Value = objOrder.m_dmlGet.ToString() + " " + objOrder.m_strGetunit;

            //        }
            //        else
            //        {
            //            objRow.Cells["tmp_Get"].Value = "";

            //        }
            //    }
            //    else
            //    {
            //        //领量
            //        objRow.Cells["tmp_Get"].Value = "";
            //    }
            //}
            //else
            //{
                //用量
               objRow.Cells["tmp_Dosage"].Value = p_objAdd.objOrder.m_dmlDosage.ToString() + " " + p_objAdd.objOrder.m_strDosageUnit;
                //频率
               objRow.Cells["tmp_Freq"].Value = p_objAdd.objOrder.m_strExecFreqName;
                //用法
               objRow.Cells["tmp_UseType"].Value = p_objAdd.objOrder.m_strDosetypeName;
                //补次
               //objRow.Cells["tmp_ATTACHTIMES_INT"].Value = p_objAdd.objOrder.m_intATTACHTIMES_INT;
                //领量
               objRow.Cells["tmp_Get"].Value = p_objAdd.objOrder.m_dmlGet.ToString() + " " + p_objAdd.objOrder.m_strGetunit;

            //}
            #endregion
         
            // 同方号的子医嘱不用再显示：长/临、类别、用法、频率、状态、下嘱医生
            //长/临
               if (p_objAdd.objOrder.m_intExecuteType == 1)
            {
                objRow.Cells["tmp_ExecuteType"].Value = "长期";

            }
            else if (p_objAdd.objOrder.m_intExecuteType == 2)
            {
                objRow.Cells["tmp_ExecuteType"].Value = "临时";

            }
            else if (p_objAdd.objOrder.m_intExecuteType == 3)
            {
                objRow.Cells["tmp_ExecuteType"].Value = "出院带药";

            }
            else
            {
                objRow.Cells["tmp_ExecuteType"].Value = "";
            }

            //出院带药天数
            //if (objOrder.m_intExecuteType == 3)
            //{
            //    objRow.Cells["tmp_OUTGETMEDDAYS_INT"].Value = objOrder.m_intOUTGETMEDDAYS_INT.ToString() + "天";
            //}
            //else
            //{
            //    objRow.Cells["tmp_OUTGETMEDDAYS_INT"].Value = "";
            //}
            //医嘱类型名称
            //objRow.Cells["viewname_vchr"].Value = objOrder.m_strOrderDicCateName.ToString().Trim();
          
         

            /*<==================================================================*/
            objRow.Tag = p_objAdd;		    
		}
	
		/// <summary>
		/// 获得模板窗口中的最大方号
		/// </summary>
		/// <returns></returns>
        int iRes=0;
		private int GetListRecipeNOInList()
		{

            iRes++;
			return iRes;
		}
	

        /// <summary>
        /// 添加新医嘱到列表中
        /// </summary>
        /// <param name="m_arrOrderList"></param>
        /// <returns></returns>
        public void m_lngAddOrderGroupList(ArrayList m_arrOrderList)
        {
            //模板文号
            int iRecipeNO = 0;
            //医嘱方号
            int m_intRecipenNo = 0;
            for (int i = 0; i < m_arrOrderList.Count; i++)
            {
                if (m_intRecipenNo != ((clsBIHOrder)m_arrOrderList[i]).m_intRecipenNo)
                {
                    iRecipeNO = GetListRecipeNOInList();
                    
                }
                ItemTag itOrder = new ItemTag();
                itOrder.objOrder = this.frmParent.CopyNewOrder((clsBIHOrder)m_arrOrderList[i]);
                itOrder.intGroupNO = iRecipeNO;
                itOrder.objOrder.m_intRecipenNo = iRecipeNO;
                m_lngAddOrder(itOrder);
                m_intRecipenNo = ((clsBIHOrder)m_arrOrderList[i]).m_intRecipenNo;
            }
        }

        /// <summary>
        /// 添加新医嘱到列表中
        /// </summary>
        /// <param name="m_arrOrderList"></param>
        /// <returns></returns>
        public void m_lngAddOrderGroupTempList(ArrayList m_arrOrderList)
        {
            this.m_arrOrderTempList.Clear();
            for (int i = 0; i < m_arrOrderList.Count; i++)
            {

                clsBIHOrder Order = new clsBIHOrder();
                Order = this.frmParent.CopyNewOrder((clsBIHOrder)m_arrOrderList[i]);

                this.m_arrOrderTempList.Add(Order);
              
            }
        }


        private void m_cmdAdd_Click(object sender, EventArgs e)
        {
            ArrayList m_arrOrderSameNo = GetTheSelectItemWithSon();
            string[] p_strRecordIDArr = null;
            clsBIHOrder objOrder = null;
            for (int i = 0; i < m_arrOrderSameNo.Count; i++)
            {
                objOrder = m_arrOrderSameNo[i] as clsBIHOrder;

                if (!this.frmParent.m_objDomain.m_blChcekOpcurrentgross(ref objOrder))
                {
                    return;
                }
                this.frmParent.SetTheCurrentOrder((clsBIHOrder)m_arrOrderSameNo[i]);
            }
            try
            {

                this.frmParent.m_objDomain.m_lngAddNewOrderByGroup(out p_strRecordIDArr, m_arrOrderSameNo);
                this.frmParent.m_objDomain.m_mthLoadOrderList();
            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message, "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 获取当前已复制到临时数组的医嘱数目
        /// </summary>
        /// <returns></returns>
        public int getTheTempCout()
        {
            return m_arrOrderTempList.Count;
        }
        /// <summary>
        /// 复制当前医嘱
        /// </summary>
        public void m_cmdParseOrder()
        {
           string[] p_strRecordIDArr = null;
           ArrayList m_arrOrderSameNo=new ArrayList();
            for(int i=0;i<m_arrOrderTempList.Count;i++)
            {
                clsBIHOrder objOrder = this.frmParent.CopyNewOrder((clsBIHOrder)m_arrOrderTempList[i]);
                //粘贴医嘱库存的判断
                if (!this.frmParent.m_objDomain.m_blChcekOpcurrentgross(ref objOrder))
                {
                    return;
                }
                m_arrOrderSameNo.Add(objOrder);
            }

            lngParentOrderSet(ref m_arrOrderSameNo);
            if (this.frmParent != null)
            {
                try
                {
                    this.frmParent.m_objDomain.m_lngAddNewOrderByGroup(out p_strRecordIDArr, m_arrOrderSameNo);

                    this.frmParent.m_objDomain.m_mthLoadOrderList();
                }
                catch(Exception objEx)
                {
                    MessageBox.Show(objEx.Message,"提示框",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        ///获得当前选中的医嘱列表(包括父子医嘱)
        /// </summary>
        /// <returns></returns>
        internal ArrayList GetTheSelectItemWithSon()
        {
            //保存已存在的医嘱号
            ArrayList m_arrOrderHave = new ArrayList();
            ArrayList m_arrOrderSameNo = new ArrayList();
            int m_intRecipenNo = -1;
            for (int i = 0; i < this.dgv_orderTemp.RowCount; i++)
            {
                if (this.dgv_orderTemp.Rows[i].Cells["tmp_check"].Value.ToString().Trim().Equals("1"))
                {
                    m_arrOrderSameNo.Add(this.frmParent.CopyNewOrder(((ItemTag)this.dgv_orderTemp.Rows[i].Tag).objOrder));
                }
            }

            lngParentOrderSet(ref m_arrOrderSameNo);
           
            return m_arrOrderSameNo;
        }

        /// <summary>
        /// 为当前医嘱列表进行父子设置
        /// </summary>
        /// <param name="m_arrOrderSameNo"></param>
        private void lngParentOrderSet(ref ArrayList m_arrOrderSameNo)
        {
             //设置第一条医嘱为父医嘱（如果存在父子的情况下）
            if (m_arrOrderSameNo.Count > 0)
            {
                ArrayList m_arrParentSet = new ArrayList();
                for (int i = 0; i < m_arrOrderSameNo.Count; i++)
                {
                    this.frmParent.SetTheCurrentOrder((clsBIHOrder)m_arrOrderSameNo[i]);
                    if (i < m_arrOrderSameNo.Count - 1)
                    {
                        if (m_arrParentSet.Contains(((clsBIHOrder)m_arrOrderSameNo[i]).m_intRecipenNo))
                        {
                            continue;
                        }
                        if (((clsBIHOrder)m_arrOrderSameNo[i]).m_intRecipenNo == ((clsBIHOrder)m_arrOrderSameNo[i + 1]).m_intRecipenNo)
                        {
                            ((clsBIHOrder)m_arrOrderSameNo[i]).m_intIFPARENTID_INT = 1;
                            m_arrParentSet.Add(((clsBIHOrder)m_arrOrderSameNo[i]).m_intRecipenNo);
                        }

                    }

                }

            }
        }
        private void dgv_orderTemp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int rowNum = e.RowIndex;
                if (this.dgv_orderTemp.Rows.Count > 0 && e.RowIndex >= 0)
                {
                    if (this.dgv_orderTemp.Rows[rowNum].Cells["tmp_check"].Value.ToString().Trim().Equals("0"))
                    {
                        this.dgv_orderTemp.Rows[rowNum].Cells["tmp_check"].Value = "1";
                    }
                    else if (this.dgv_orderTemp.Rows[rowNum].Cells["tmp_check"].Value.ToString().Trim().Equals("1"))
                    {
                        this.dgv_orderTemp.Rows[rowNum].Cells["tmp_check"].Value = "0";
                    }

                }
                //同方处理
                TheSamerecipeno(rowNum);
            }
        }

        private void TheSamerecipeno(int rowNum)
        {
            string m_strCheck = this.dgv_orderTemp.Rows[rowNum].Cells["tmp_check"].Value.ToString().Trim();
            int No=((ItemTag)this.dgv_orderTemp.Rows[rowNum].Tag).intGroupNO;
            for (int i = 0; i < this.dgv_orderTemp.RowCount; i++)
            {
                if (((ItemTag)this.dgv_orderTemp.Rows[i].Tag).intGroupNO == No)
                {
                    this.dgv_orderTemp.Rows[i].Cells["tmp_check"].Value = m_strCheck;
                }
            }
        }

        private void m_cmdRemove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dgv_orderTemp.RowCount; i++)
            {
                if (this.dgv_orderTemp.Rows[i].Cells["tmp_check"].Value.ToString().Trim().Equals("1"))
                {
                    this.dgv_orderTemp.Rows.Remove(this.dgv_orderTemp.Rows[i]);
                    i = i - 1;
                }
                
            }
        }

        private void m_cmdClear_Click(object sender, EventArgs e)
        {
            this.dgv_orderTemp.Rows.Clear();
        }

        private void m_chkAll_CheckedChanged(object sender, EventArgs e)
        {
            string check="0";
            if(this.m_chkAll.Checked==true)
            {
                check="1";
            }
            else
            {
                check="0";
            }
            for (int i = 0; i < this.dgv_orderTemp.RowCount; i++)
            {
                this.dgv_orderTemp.Rows[i].Cells["tmp_check"].Value = check;
            }
        }
    }

    /// <summary>
    /// ItemTag 列表Tag使用的类，保持原方号不变，为了在列表中按组选择，增加另一个属性
    /// </summary>
    public class ItemTag
	{
		public ItemTag()
		{
			intGroupNO=0;
			objOrder=new clsBIHOrder();
		}
		public int intGroupNO;
		public clsBIHOrder objOrder;
	}

}
