using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using System.Collections;

namespace com.digitalwave.iCare.BIHOrder
{
    class clsCtl_OrderGroupInput : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量
        clsDcl_InputOrder m_objManage = null;
        /// <summary>
        /// 当前组套项目价格总和
        /// </summary>
        decimal m_decItemsAllCout = 0;
        /// <summary>
        /// 当前项目价格
        /// </summary>
        decimal m_decItemsCount = 0;
        /// <summary>
        /// 医嘱组套成员表
        /// </summary>
        private DataTable m_dtOrderGroupDetail = new DataTable();
        /// <summary>
        /// 保存频率信息
        /// </summary>
        public Hashtable m_htTempFreq = null;
        #endregion 

        #region 构造函数
        public clsCtl_OrderGroupInput()
        {
            m_objManage = new clsDcl_InputOrder();
        }
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.BIHOrder.frmBIHOrderGroupInput m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmBIHOrderGroupInput)frmMDI_Child_Base_in;

        }
        #endregion

        #region 梆定树列表
        /// <summary>
        /// 梆定树列表
        /// </summary>
        internal void bindGroupTree()
        {
            this.m_objViewer.iniControl();

            //SHARETYPE_INT共享类型{1=私用;2=公用}
            //m_objViewer.arrGroup[i].m_intShareType
            this.m_objViewer.treeView1.Nodes.Add("模板列表");
            this.m_objViewer.treeView1.Nodes[0].Nodes.Add("私用");
            this.m_objViewer.treeView1.Nodes[0].Nodes.Add("公用");
            TreeNode selectNode = null;
            ArrayList m_arrPublic = new ArrayList();
            ArrayList m_arrPrivate = new ArrayList();
            for (int i = 0; i < m_objViewer.arrGroup.Length; i++)
            {
                if (m_objViewer.arrGroup[i].m_intShareType == 1)
                {
                    m_arrPrivate.Add(m_objViewer.arrGroup[i]);
                }
                else
                {
                    m_arrPublic.Add(m_objViewer.arrGroup[i]);
                }
            }
            if (m_arrPrivate.Count > 0)
            {
                TreeNode FindNode = this.m_objViewer.treeView1.Nodes[0].Nodes[0];
               
                    for (int i = 0; i < m_arrPrivate.Count; i++)
                    {
                        clsBIHOrderGroup m_Group=(clsBIHOrderGroup)m_arrPrivate[i];
                        string[] m_arrSubNodes = m_Group.m_strName.Split("-".ToCharArray());
                        TreeNode[] m_arrTrAdd = new TreeNode[m_arrSubNodes.Length];
                        if (m_arrTrAdd.Length == 0)
                        {
                            continue;
                        }
                        for (int j = 0; j < m_arrSubNodes.Length; j++)
                        {
                            m_arrTrAdd[j] = new TreeNode();
                            m_arrTrAdd[j].Tag = null;
                            m_arrTrAdd[j].ImageIndex = 0;
                            m_arrTrAdd[j].SelectedImageIndex = 1;
                            m_arrTrAdd[j].Text = m_arrSubNodes[j];
                            if (j == m_arrSubNodes.Length - 1)
                            {
                                m_arrTrAdd[j].ImageIndex = 2;
                                m_arrTrAdd[j].SelectedImageIndex = 2;
                                m_arrTrAdd[j].Tag = m_arrPrivate[i];
                            }
                            if (j > 0)
                            {
                                m_arrTrAdd[j - 1].Nodes.Add(m_arrTrAdd[j]);
                            }
                        }
                        FindNode.Nodes.Add(m_arrTrAdd[0]);

                    }
                
           
            }
            if (m_arrPublic.Count > 0)
            {
                TreeNode FindNode = this.m_objViewer.treeView1.Nodes[0].Nodes[1];

                for (int i = 0; i < m_arrPublic.Count; i++)
                {
                    clsBIHOrderGroup m_Group = (clsBIHOrderGroup)m_arrPublic[i];
                    // TreeNode trAdd = new TreeNode();
                    string[] m_arrSubNodes = m_Group.m_strName.Split("-".ToCharArray());
                    TreeNode[] m_arrTrAdd = new TreeNode[m_arrSubNodes.Length];
                    if (m_arrTrAdd.Length == 0)
                    {
                        continue;
                    }
                    for (int j = 0; j < m_arrSubNodes.Length; j++)
                    {
                        m_arrTrAdd[j] = new TreeNode();
                        m_arrTrAdd[j].Tag = null;
                        m_arrTrAdd[j].ImageIndex = 0;
                        m_arrTrAdd[j].SelectedImageIndex = 1;
                        m_arrTrAdd[j].Text = m_arrSubNodes[j];
                        if (j == m_arrSubNodes.Length - 1)
                        {
                            m_arrTrAdd[j].ImageIndex = 2;
                            m_arrTrAdd[j].SelectedImageIndex = 2;
                            m_arrTrAdd[j].Tag = m_arrPublic[i];
                        }
                        if (j > 0)
                        {
                            m_arrTrAdd[j - 1].Nodes.Add(m_arrTrAdd[j]);
                        }



                    }
                    FindNode.Nodes.Add(m_arrTrAdd[0]);

                }

            }
            sortTheTree(this.m_objViewer.treeView1.Nodes[0]);

           
            if (m_objViewer.treeView1.Nodes[0].Nodes[0].Nodes.Count > 0)
            {
                TreeNode node1 = m_objViewer.treeView1.Nodes[0].Nodes[0];
                while (node1.Nodes.Count>0)
                {
                    node1=node1.Nodes[0];
                }
                m_objViewer.treeView1.SelectedNode = node1;
            }
            else if (m_objViewer.treeView1.Nodes[0].Nodes[1].Nodes.Count > 0)
            {
                TreeNode node1 = m_objViewer.treeView1.Nodes[0].Nodes[1];
                while (node1.Nodes.Count > 0)
                {
                    node1 = node1.Nodes[0];
                }
                m_objViewer.treeView1.SelectedNode = node1;
            }
           
        }
        private void sortTheTree(TreeNode FindNode)
        {
            if (FindNode.Nodes.Count <= 0)
            {
                return;
            }
            for (int i = 0; i < FindNode.Nodes.Count; i++)
            {
                for(int j=i+1;j<FindNode.Nodes.Count;j++)
                {
                    if(FindNode.Nodes[i].Text.Trim().Equals(FindNode.Nodes[j].Text.Trim()))
                    {
                        for (int k = 0; k < FindNode.Nodes[j].Nodes.Count; k++)
                        {
                            FindNode.Nodes[i].Nodes.Add((TreeNode)(FindNode.Nodes[j].Nodes[k].Clone()));
                            //FindNode.Nodes.Remove(FindNode.Nodes[j].Nodes[k]);
                            //k--;
                        }
                        FindNode.Nodes.Remove(FindNode.Nodes[j]);
                        j--;
                    }
                }
                
                sortTheTree(FindNode.Nodes[i]);
            }
            
        }



        #endregion

        #region 根据组套ID查询相关的诊疗项
        /// <summary>
        /// 根据组套ID查询相关的诊疗项
        /// </summary>
        /// <param name="m_strGroupID"></param>
        internal void bindGroupListView(string m_strGroupID)
            {

                m_LoadDataInfo(m_strGroupID);
            }
            #endregion

        #region 保存组套医嘱(blnIsSameNO-true同方,false 不同方)
        /// <summary>
        /// 保存组套医嘱(blnIsSameNO-true同方,false 不同方)
        /// </summary>
        public bool  SaveTheGroup()
        {
            bool m_blSave = false;
            string[] strRecordIDArr;
            this.m_objViewer.m_arrGroupOrder = new ArrayList();
            //if (this.m_objViewer.listView2.CheckedItems.Count > 0)
            if(this.m_objViewer.m_dtvGroupDetail.RowCount>0)
            {
               
                for (int i = 0; i < this.m_objViewer.m_dtvGroupDetail.RowCount; i++)
                {
                    //clsBIHOrder order = (clsBIHOrder)this.m_objViewer.listView2.CheckedItems[i].Tag;
                    if (this.m_objViewer.m_dtvGroupDetail.Rows[i].Cells["dtv_Check"].Value.ToString().Trim().Equals("0"))
                    {
                        continue;
                    }
                    clsBIHOrder order = (clsBIHOrder)this.m_objViewer.m_dtvGroupDetail.Rows[i].Tag;
                    /*补充基本信息到医嘱VO中*/
                    BaseToVo(ref order);
                    this.m_objViewer.m_arrGroupOrder.Add(order);
                }
                if (this.m_objViewer.m_arrGroupOrder.Count > 0)
                { 
                    //m_objManage.m_lngAddNewOrderByGroup(out strRecordIDArr, m_arrGroupOrder);
                    m_blSave = true;
                    /*<======================*/
                }
                else
                {
                    MessageBox.Show("请选择项目!", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   
                }
                
                
            }
            /*保存同方组套*/

            return m_blSave;
            /*<-----------------------------------------------------*/
           
        }

        /// <summary>
        /// 返回选中的诊疗项目数组
        /// </summary>
        /// <returns></returns>
        public ArrayList GetTheSelectOrderDic()
        {
            ArrayList m_arrOrderDic = new ArrayList();
            if (this.m_objViewer.m_dtvGroupDetail.RowCount > 0)
            {

                for (int i = 0; i < this.m_objViewer.m_dtvGroupDetail.RowCount; i++)
                {
                    //clsBIHOrder order = (clsBIHOrder)this.m_objViewer.listView2.CheckedItems[i].Tag;
                    if (this.m_objViewer.m_dtvGroupDetail.Rows[i].Cells["dtv_Check"].Value.ToString().Trim().Equals("0"))
                    {
                        continue;
                    }
                    clsBIHOrder order = (clsBIHOrder)this.m_objViewer.m_dtvGroupDetail.Rows[i].Tag;
                    m_arrOrderDic.Add(order.m_strOrderDicID);
                }
              
            }
            return m_arrOrderDic;
        }
      

        /// <summary>
        /// 根据频率id获取频率VO
        /// </summary>
        /// <param name="m_strExecFreqID"></param>
        /// <returns></returns>
        public clsAIDRecipeFreq GetFreqVoByFreqID(string m_strExecFreqID)
        {
            if (m_htTempFreq == null)
            {
               // clsBIHOrderService m_objService = clsGenerator.CreateObject(typeof(clsBIHOrderService)) as clsBIHOrderService;
                m_htTempFreq = new Hashtable();
                clsAIDRecipeFreq[] Freq;
                m_objManage.m_lngGetRecipeFreq("", out Freq);
                for (int i = 0; i < Freq.Length; i++)
                {
                    m_htTempFreq.Add(Freq[i].m_strFreqID, Freq[i]);
                }

            }
            clsAIDRecipeFreq m_objTemp = (clsAIDRecipeFreq)m_htTempFreq[m_strExecFreqID];
            if (m_objTemp == null)
            {
                m_objTemp = new clsAIDRecipeFreq();
            }
            return m_objTemp;
        }

        private void BaseToVo(ref clsBIHOrder order)
        {
 
            //order.m_strOrderID = m_objViewer.baseBIHOrder.m_strOrderID;
            //order.m_intRecipenNo = m_objViewer.baseBIHOrder.m_intRecipenNo;
            order.m_strRegisterID = m_objViewer.baseBIHOrder.m_strRegisterID;
            //order.m_strParentID = m_objViewer.baseBIHOrder.m_strParentID;
            order.m_strPatientID = m_objViewer.baseBIHOrder.m_strPatientID;
            //order.m_intExecuteType = m_objViewer.baseBIHOrder.m_intExecuteType;
            order.m_intIsRepare = m_objViewer.baseBIHOrder.m_intIsRepare;
            //order.m_intRateType = m_objViewer.baseBIHOrder.m_intRateType;
            
            order.m_strCreator = m_objViewer.baseBIHOrder.m_strCreator;
            order.m_strCreatorID = m_objViewer.baseBIHOrder.m_strCreatorID;
            //order.m_strOrderID = m_objViewer.baseBIHOrder.m_strOrderID;
            order.m_dtCreatedate =DateTime.Now;
            // 保存申请科室（当前科室）
            order.m_strCREATEAREA_ID = m_objViewer.baseBIHOrder.m_strCREATEAREA_ID;
            order.m_strCREATEAREA_Name = m_objViewer.baseBIHOrder.m_strCREATEAREA_Name;

            order.m_strCHARGEDOCTORGROUPID = m_objViewer.baseBIHOrder.m_strCHARGEDOCTORGROUPID; 
            order.m_strDOCTORID_CHR = m_objViewer.baseBIHOrder.m_strDOCTORID_CHR;
            order.m_strDOCTOR_VCHR = m_objViewer.baseBIHOrder.m_strDOCTOR_VCHR;
            order.m_strDOCTORGROUPID_CHR = m_objViewer.baseBIHOrder.m_strDOCTORGROUPID_CHR;
            //下医嘱时病人所在病区ID
            order.m_strCURAREAID_CHR = m_objViewer.baseBIHOrder.m_strCURAREAID_CHR;
            //下医嘱时病人所在病床ID
            order.m_strCURBEDID_CHR = m_objViewer.baseBIHOrder.m_strCURBEDID_CHR ;
            /*<==============================================*/
           //order.m_intOUTGETMEDDAYS_INT=m_objViewer.baseBIHOrder.m_intOUTGETMEDDAYS_INT;
           //order.m_intATTACHTIMES_INT=m_objViewer.baseBIHOrder.m_intATTACHTIMES_INT;
           order.m_dtStartDate=m_objViewer.baseBIHOrder.m_dtStartDate;
           order.m_dtFinishDate = m_objViewer.baseBIHOrder.m_dtFinishDate;
           //医生签名
           order.SIGN_INT = m_objViewer.baseBIHOrder.SIGN_INT;
           // 设置类型及频率次数
           clsAIDRecipeFreq m_objTempFreq = GetFreqVoByFreqID(order.m_strExecFreqID);
           if (m_objTempFreq != null)
           {
               order.m_intFreqTime = m_objTempFreq.m_intTimes;
               order.m_intFreqDays = m_objTempFreq.m_intDays;
           }
           //设置领量及补次的量
       
        }
        #endregion

       
        /// <summary>
        /// 为列表框填充数据并进行数据费用合计
        /// </summary>
        /// <param name="m_strGroupID"></param>
        private void m_LoadDataInfo(string m_strGroupID)
        {
           
            if (m_strGroupID == string.Empty) return;
            //载入基本信息
            clsT_aid_bih_ordergroup_VO p_objResult = new clsT_aid_bih_ordergroup_VO();
            long lngRes =m_objManage.m_lngGetOrderGroupByID(m_strGroupID, out p_objResult);
          
            lngRes=m_objManage.m_lngGetOrderGroupDetailByGroupID(m_strGroupID, out m_dtOrderGroupDetail);
            if (lngRes > 0)
            {
                /*绑定列表数据*/
                ListViewbind(m_strGroupID);
            }
            /**********当前组套所有选项费用和,及还原之前的选中状态*************/
            clsBIHOrder order;
            decimal price=0;
            for (int i = 0; i < m_objViewer.m_dtvGroupDetail.RowCount; i++)
            {
                order = (clsBIHOrder)m_objViewer.m_dtvGroupDetail.Rows[i].Tag;
                ////非同方组套列表
                //if (m_objViewer.m_htBIHOrder.Contains(order.m_strOrderID))
                //{
                //    m_objViewer.listView2.Items[i].Checked = true;
                //}
                ///*<--------------------------------------*/
                ////同方组套列表
                //if (m_objViewer.m_htBIHOrderGroup.Contains(order.m_strOrderID))
                //{
                //    m_objViewer.listView2.Items[i].Checked = true;
                //}
                ///*<--------------------------------------*/
                price += order.m_dmlPrice * (order.m_dmlGet);
            }
            //this.m_objViewer.label2.Text = price.ToString("0.000");
            /*<=======================================================*/
        }
        /// <summary>
        /// 获取相应的明细数据
        /// </summary>
        /// <param name="myDataView"></param>
        /// <param name="m_objGroupVo"></param>
        private void GetGroupDetailData(DataView objRow, out clsT_aid_bih_ordergroup_detail_VO[] m_arrObjItem)
        {
           
            
            m_arrObjItem = new clsT_aid_bih_ordergroup_detail_VO[objRow.Count];
            for (int i = 0; i < objRow.Count; i++)
            {
                m_arrObjItem[i] = new clsT_aid_bih_ordergroup_detail_VO();
                //流水号
                m_arrObjItem[i].m_strDETAILID_CHR = Convert.ToString(objRow[i]["DETAILID_CHR"].ToString().Trim());
                //组套id	{=医嘱组套.Id}
                m_arrObjItem[i].m_strGROUPID_CHR = Convert.ToString(objRow[i]["GROUPID_CHR"].ToString().Trim());
                //诊疗项目id	{=诊疗项目.Id}
                m_arrObjItem[i].m_strORDERDICID_CHR = Convert.ToString(objRow[i]["ORDERDICID_CHR"].ToString().Trim());
                //诊疗项目名称
                
                m_arrObjItem[i].m_strOrderdicName = Convert.ToString(objRow[i]["OrderdicName"].ToString().Trim());
                m_arrObjItem[i].m_strOrderName = Convert.ToString(objRow[i]["NAME_VCHR"].ToString().Trim());

                //执行频率id	{=执行频率.Id}
                m_arrObjItem[i].m_strFREQID_CHR = Convert.ToString(objRow[i]["FREQID_CHR"].ToString().Trim());
                //执行频率名称
                m_arrObjItem[i].m_strExecFreqName = Convert.ToString(objRow[i]["freqname_chr"].ToString().Trim());
                //一次剂量
                if (!objRow[i]["DOSAGE_DEC"].ToString().Trim().Equals(""))
                    m_arrObjItem[i].m_fltDOSAGE_DEC = float.Parse(objRow[i]["DOSAGE_DEC"].ToString().Trim());
                //剂量单位
                m_arrObjItem[i].m_strDOSAGEUNIT_CHR = Convert.ToString(objRow[i]["DOSAGEUNIT_CHR"].ToString().Trim());
                //一次用量
                if (!objRow[i]["USE_DEC"].ToString().Trim().Equals(""))
                    m_arrObjItem[i].m_fltUSE_DEC = float.Parse(objRow[i]["USE_DEC"].ToString().Trim());
                //用量单位
                m_arrObjItem[i].m_strUSEUNIT_CHR = Convert.ToString(objRow[i]["USEUNIT_CHR"].ToString().Trim());
                //一次领量
                if (!objRow[i]["GET_DEC"].ToString().Trim().Equals(""))
                    m_arrObjItem[i].m_fltGET_DEC = float.Parse(objRow[i]["GET_DEC"].ToString().Trim());
                //领量单位
                m_arrObjItem[i].m_strGETUNIT_CHR = Convert.ToString(objRow[i]["GETUNIT_CHR"].ToString().Trim());
                //用药方式id
                m_arrObjItem[i].m_strDOSETYPE_CHR = Convert.ToString(objRow[i]["DOSETYPE_CHR"].ToString().Trim());
                //用药方式名称
                m_arrObjItem[i].m_strDosetypeName = Convert.ToString(objRow[i]["usagename_vchr"].ToString().Trim());
                //医生嘱托
                m_arrObjItem[i].m_strENTRUST_VCHR = Convert.ToString(objRow[i]["ENTRUST_VCHR"].ToString().Trim());
                //是否贵重品
                if (!objRow[i]["ISRICH_INT"].ToString().Trim().Equals(""))
                    m_arrObjItem[i].m_intISRICH_INT = int.Parse(objRow[i]["ISRICH_INT"].ToString().Trim());
                //父诊疗项目id	{=诊疗项目.Id}
                m_arrObjItem[i].m_strPARENTID_CHR = Convert.ToString(objRow[i]["PARENTID_CHR"].ToString().Trim());
                //是否父诊疗项目
                if (!objRow[i]["IFPARENTID_INT"].ToString().Trim().Equals(""))
                    m_arrObjItem[i].m_intIFPARENTID_INT = int.Parse(objRow[i]["IFPARENTID_INT"].ToString().Trim());
                //执行类型{1=长期;2=临时,3=出院带药}
                if (!objRow[i]["EXECUTETYPE_INT"].ToString().Trim().Equals(""))
                {
                    m_arrObjItem[i].m_intEXECUTETYPE_INT = int.Parse(objRow[i]["EXECUTETYPE_INT"].ToString().Trim());
                }
                if(m_arrObjItem[i].m_intEXECUTETYPE_INT==0)
                {
                    m_arrObjItem[i].m_intEXECUTETYPE_INT = 1;
                }
                //出院带药天数
                if (!objRow[i]["OUTGETMEDDAYS_INT"].ToString().Trim().Equals(""))
                    m_arrObjItem[i].m_intOUTGETMEDDAYS_INT = int.Parse(objRow[i]["OUTGETMEDDAYS_INT"].ToString().Trim());
                //补次次数
                if (!objRow[i]["ATTACHTIMES_INT"].ToString().Trim().Equals(""))
                    m_arrObjItem[i].m_intATTACHTIMES_INT = int.Parse(objRow[i]["ATTACHTIMES_INT"].ToString().Trim());
                //样本类型ID
                m_arrObjItem[i].m_strSAMPLEID_VCHR = Convert.ToString(objRow[i]["SAMPLEID_VCHR"].ToString().Trim());
                //样本类型名称
                m_arrObjItem[i].m_strSAMPLEName_VCHR = Convert.ToString(objRow[i]["sample_type_desc_vchr"].ToString().Trim());

                //检查部位ID
                m_arrObjItem[i].m_strPARTID_VCHR = Convert.ToString(objRow[i]["PARTID_VCHR"].ToString().Trim());
                //检查部位名称
                m_arrObjItem[i].m_strPARTNAME_VCHR = Convert.ToString(objRow[i]["partname"].ToString().Trim());
                //医保
                m_arrObjItem[i].m_strMedicareTypeName = Convert.ToString(objRow[i]["typename_vchr"].ToString().Trim());
                //医嘱类型
                m_arrObjItem[i].m_strOrderDicCateID = Convert.ToString(objRow[i]["ordercateid_chr"].ToString().Trim());
                //医嘱类型名称
                m_arrObjItem[i].m_strOrderDicCateName = Convert.ToString(objRow[i]["viewname_vchr"].ToString().Trim());
                //方号	用于编组显示
                if (!objRow[i]["RECIPENO_INT"].ToString().Trim().Equals(""))
                    m_arrObjItem[i].m_intRecipenNo = int.Parse(objRow[i]["RECIPENO_INT"].ToString().Trim());
                //费用标志	{1=全收费，2=用法收费，3=不收费}
                if (!objRow[i]["RATETYPE_INT"].ToString().Trim().Equals(""))
                    m_arrObjItem[i].RateType = int.Parse(objRow[i]["RATETYPE_INT"].ToString().Trim());
                //单价
                if (!objRow[i]["ItemPrice"].ToString().Trim().Equals(""))
                    m_arrObjItem[i].m_dmlPrice = decimal.Parse(objRow[i]["ItemPrice"].ToString().Trim());
                //皮试
                if (!objRow[i]["ISNEEDFEEL"].ToString().Trim().Trim().Equals(""))
                {
                    m_arrObjItem[i].m_intISNEEDFEEL = int.Parse(objRow[i]["ISNEEDFEEL"].ToString().Trim());
                }
                // 补一次的领量(用于主项目补次)
                decimal.TryParse(objRow[i]["SINGLEAMOUNT_DEC"].ToString().Trim(), out m_arrObjItem[i].m_dmlOneUse);
                if(!objRow[i]["stopStatus"].ToString().Trim().Equals(""))
                {
                    m_arrObjItem[i].m_intOrderDicStop = int.Parse(objRow[i]["stopStatus"].ToString().Trim());
                }
                if (!objRow[i]["IPNOQTYFLAG_INT"].ToString().Trim().Equals("") && objRow[i]["ITEMSRCTYPE_INT"].ToString().Trim().Equals("1"))
                {
                    m_arrObjItem[i].m_intIPNOQTYFLAG_INT = int.Parse(objRow[i]["IPNOQTYFLAG_INT"].ToString().Trim());
                }
                //包装量
                if (objRow[i]["packqty_dec"] != DBNull.Value)
                {
                    m_arrObjItem[i].m_dmlPACKQTY_DEC = decimal.Parse(objRow[i]["packqty_dec"].ToString().Trim());
                }

                //住院单位类型
                if (objRow[i]["ipchargeflg_int"] != DBNull.Value)
                {
                    m_arrObjItem[i].m_intIPCHARGEFLG_INT = int.Parse(objRow[i]["ipchargeflg_int"].ToString().Trim());

                }
            }
           // m_objGroupVo.m_objGroupVoList = m_arrObjItem;
        }

        /// <summary>
        /// 绑定项目列表数据
        /// </summary>
        private void ListViewbind(string m_strGroupID)
        {
            m_objViewer.m_dtvGroupDetail.Rows.Clear();
            DataView myDataView = new DataView(m_dtOrderGroupDetail);
            clsT_aid_bih_ordergroup_detail_VO[] m_arrObjItem;
            GetGroupDetailData(myDataView,out m_arrObjItem);
            for (int i = 0; i < m_arrObjItem.Length; i++)
            {
                clsT_aid_bih_ordergroup_detail_VO m_ObjItem = (clsT_aid_bih_ordergroup_detail_VO)m_arrObjItem[i];
                //医嘱类型
                clsT_aid_bih_ordercate_VO p_objItem = (clsT_aid_bih_ordercate_VO)this.m_objViewer.m_htOrderCate[m_ObjItem.m_strOrderDicCateID];
                //转换对象
                //借用保存流水号
                clsBIHOrder order = new clsBIHOrder();
                order.m_strOrderID = m_ObjItem.m_strDETAILID_CHR;
                order.m_strOrderDicID = m_ObjItem.m_strORDERDICID_CHR;
                order.m_strOrderDicCateID = m_ObjItem.m_strOrderDicCateID;
                order.m_strOrderDicCateName = m_ObjItem.m_strOrderDicCateName;
                order.m_strRegisterID = null;
                
                order.m_intRecipenNo = m_ObjItem.m_intRecipenNo;
                if (p_objItem != null && p_objItem.m_strVIEWNAME_VCHR.Trim().Equals("文字医嘱"))//文字医嘱时显示项目名，其它类的显示诊疗项目名
                {
                    //项目名称
                    order.m_strName = m_ObjItem.m_strOrderName;

                }
                else
                {
                    order.m_strName = m_ObjItem.m_strOrderdicName;
                }
                order.m_strSpec = m_ObjItem.m_strItemspec_vchr;
                order.m_strExecFreqID = m_ObjItem.m_strFREQID_CHR;
                order.m_strExecFreqName = m_ObjItem.m_strExecFreqName;
                order.m_dmlDosage = decimal.Parse(m_ObjItem.m_fltDOSAGE_DEC.ToString());

                order.m_strDosageUnit = m_ObjItem.m_strDOSAGEUNIT_CHR;
                order.m_dmlGet = decimal.Parse(m_ObjItem.m_fltGET_DEC.ToString());

                order.m_strGetunit = m_ObjItem.m_strGETUNIT_CHR;
                order.m_dmlUse = decimal.Parse(m_ObjItem.m_fltUSE_DEC.ToString());
                order.m_strUseunit = m_ObjItem.m_strUSEUNIT_CHR;
                order.m_dmlDosageRate = order.m_dmlUse;
                order.m_strDosetypeID = m_ObjItem.m_strDOSETYPE_CHR;
                order.m_strDosetypeName = m_ObjItem.m_strDosetypeName;
                order.m_strEntrust = m_ObjItem.m_strENTRUST_VCHR;
                order.m_dmlPrice = m_ObjItem.m_dmlPrice;
                order.m_intIsRich = m_ObjItem.m_intISRICH_INT;
                order.RateType = m_ObjItem.RateType;
                order.m_strSAMPLEID_VCHR = m_ObjItem.m_strSAMPLEID_VCHR;
                order.m_strPARTID_VCHR = m_ObjItem.m_strPARTID_VCHR; 
                order.m_intExecuteType = m_ObjItem.m_intEXECUTETYPE_INT;
                order.m_intOUTGETMEDDAYS_INT = m_ObjItem.m_intOUTGETMEDDAYS_INT;
                order.m_intATTACHTIMES_INT = m_ObjItem.m_intATTACHTIMES_INT;
                order.m_strSAMPLEID_VCHR = m_ObjItem.m_strSAMPLEID_VCHR;
                order.m_strSAMPLEName_VCHR = m_ObjItem.m_strSAMPLEName_VCHR;
                order.m_strPARTID_VCHR = m_ObjItem.m_strPARTID_VCHR;
                order.m_strPARTNAME_VCHR = m_ObjItem.m_strPARTNAME_VCHR;
                order.m_intISNEEDFEEL = m_ObjItem.m_intISNEEDFEEL;
                order.m_dmlOneUse = m_ObjItem.m_dmlOneUse;
                // 把当前组套id存入医嘱项目中
                order.m_strGroupId = m_strGroupID.Trim();
                // 判断当前医嘱是否为父医嘱
                order.m_intIFPARENTID_INT = m_ObjItem.m_intIFPARENTID_INT;
                order.m_intIPCHARGEFLG_INT = m_ObjItem.m_intIPCHARGEFLG_INT;
                order.m_dmlPACKQTY_DEC = m_ObjItem.m_dmlPACKQTY_DEC;
                if (this.m_objViewer.m_strOrderCateList.Contains(m_ObjItem.m_strOrderDicCateID.ToString().Trim()))
                {
                    continue;
                }
                if (order.m_strName.Trim().Equals(""))
                {
                    continue;
                }
                m_objViewer.m_dtvGroupDetail.Rows.Add();
               
                DataGridViewRow objRow = m_objViewer.m_dtvGroupDetail.Rows[this.m_objViewer.m_dtvGroupDetail.RowCount - 1];
                objRow.Cells["dtv_Check"].Tag = "1";
                if (this.m_objViewer.m_blDeableMedControl == false)//缺药的项目是否可以录入0-不可以false，1-可以true
                {
                    if (m_ObjItem.m_intIPNOQTYFLAG_INT == 1)
                    {
                        objRow.Cells["dtv_Check"].Tag = "0";
                        objRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                    }
                }
                if (this.m_objViewer.m_blStopControl == false)//停用项目是否可录入开关
                {
                    if (m_ObjItem.m_intOrderDicStop == 0)
                    {
                        objRow.Cells["dtv_Check"].Tag = "0";
                        objRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Gray;
                    }
                }
                //选择
                if (this.m_objViewer.ra_selectAll.Checked && objRow.Cells["dtv_Check"].Tag.ToString() != "0")
                {
                    objRow.Cells["dtv_Check"].Value = "1";
                }
                else
                {
                    objRow.Cells["dtv_Check"].Value = "0";
                }
                //序
                objRow.Cells["dtv_DetalNo"].Value = i + 1;
                //方
                objRow.Cells["dtv_RecipeNo"].Value = m_ObjItem.m_intRecipenNo.ToString();
                // 药品来源: 0 药房(全计费,摆药); 1 患者自备(只收费用法加收项目,不摆药); 2 科室基数(全计费，不摆药)
                switch (m_ObjItem.RateType)
                {
                    case 0:
                        objRow.Cells["RATETYPE_INT"].Value = "药房";
                        break;
                    case 1:
                        objRow.Cells["RATETYPE_INT"].Value = "自备";
                        break;
                    case 2:
                        objRow.Cells["RATETYPE_INT"].Value = "基数";
                        break;
                    default:
                        break;
                }              
                //类型
                if (m_ObjItem.m_intEXECUTETYPE_INT == 1)
                {
                    objRow.Cells["dtv_ExecuteType"].Value = "长期";

                }
                else if (m_ObjItem.m_intEXECUTETYPE_INT == 2)
                {
                    objRow.Cells["dtv_ExecuteType"].Value = "临时";

                }
                else if (m_ObjItem.m_intEXECUTETYPE_INT == 3)
                {
                    objRow.Cells["dtv_ExecuteType"].Value = "出院带药";

                }
                else
                {
                    objRow.Cells["dtv_ExecuteType"].Value = "";
                }
                //医保
                objRow.Cells["MedicareTypeName"].Value = m_ObjItem.m_strMedicareTypeName;
                //项目名称
                objRow.Cells["dtv_Name"].Value = m_ObjItem.m_strOrderdicName;

                if (p_objItem != null && !p_objItem.m_strVIEWNAME_VCHR.Trim().Equals("文字医嘱"))
                {
                    //“方法”列。用于显示检验医嘱的样本类型，和检查医嘱的部位信息
                    if (!m_ObjItem.m_strPARTID_VCHR.Trim().Equals(""))
                    {
                        objRow.Cells["dtv_method"].Value = m_ObjItem.m_strPARTNAME_VCHR;
                    }
                    else if (!m_ObjItem.m_strSAMPLEID_VCHR.Trim().Equals(""))
                    {
                        objRow.Cells["dtv_method"].Value = m_ObjItem.m_strSAMPLEName_VCHR;
                    }

                    //用量
                    objRow.Cells["dtv_Dosage"].Value = m_ObjItem.m_fltDOSAGE_DEC + m_ObjItem.m_strDOSAGEUNIT_CHR;
                    //用法
                    objRow.Cells["dtv_UseType"].Value = m_ObjItem.m_strDosetypeName;
                    //频率
                    objRow.Cells["dtv_Freq"].Value = m_ObjItem.m_strExecFreqName;
                    //数量
                    if (m_ObjItem.m_fltGET_DEC > 0)
                    {
                        objRow.Cells["dtv_Get"].Value = m_ObjItem.m_fltGET_DEC + m_ObjItem.m_strGETUNIT_CHR;
                    }
                    else
                    {
                        objRow.Cells["dtv_Get"].Value = "";
                    }
                    //总量  N天共M片。N-表示出院带药的天数，M-表示出院带药合计的数量
                    if (m_ObjItem.m_intEXECUTETYPE_INT == 3)
                    {
                        objRow.Cells["dtv_sum"].Value = m_ObjItem.m_intOUTGETMEDDAYS_INT.ToString() + "天共" + Convert.ToString(m_ObjItem.m_fltGET_DEC * m_ObjItem.m_intOUTGETMEDDAYS_INT) + m_ObjItem.m_strGETUNIT_CHR;
                    }
                    else
                    {
                        objRow.Cells["dtv_sum"].Value = "";
                    }
                    //补次
                    objRow.Cells["ATTACHTIMES_INT"].Value = m_ObjItem.m_intATTACHTIMES_INT;
                    //嘱托
                    objRow.Cells["dtv_ENTRUST"].Value = m_ObjItem.m_strENTRUST_VCHR;
                }
                else
                {
                    //“方法”列。用于显示检验医嘱的样本类型，和检查医嘱的部位信息
                    objRow.Cells["dtv_method"].Value = "";
                    //用量
                    objRow.Cells["dtv_Dosage"].Value = "";
                    //用法
                    objRow.Cells["dtv_UseType"].Value = "";
                    //频率
                    objRow.Cells["dtv_Freq"].Value = "";
                    objRow.Cells["dtv_Get"].Value = "";
                    //总量  N天共M片。N-表示出院带药的天数，M-表示出院带药合计的数量
                    objRow.Cells["dtv_sum"].Value = "";
                    //补次
                    objRow.Cells["ATTACHTIMES_INT"].Value = "";
                    //嘱托
                    objRow.Cells["dtv_ENTRUST"].Value = "";
                }
                if (p_objItem != null && p_objItem.m_strVIEWNAME_VCHR.Trim().Equals("文字医嘱"))//文字医嘱时显示项目名，其它类的显示诊疗项目名
                {
                    //项目名称
                    objRow.Cells["dtv_Name"].Value = m_ObjItem.m_strOrderName;
                }               
              
                objRow.Tag = order;
            }

            if (this.m_objViewer.m_dtvGroupDetail.RowCount > 0)
            {
                this.m_objViewer.m_dtvGroupDetail.CurrentCell = this.m_objViewer.m_dtvGroupDetail.Rows[0].Cells[2];
            }  
           
        }

        internal void m_lngBindChargeListByGroupDetail()
        {
            //lngRes=m_objManage.m_lngGetOrderGroupDetailByGroupID(m_strGroupID, out m_dtOrderGroupDetail);
           
            /**********当前组套所有选项费用和,及还原之前的选中状态*************/
            if (m_objViewer.m_dtvGroupDetail.SelectedRows.Count > 0)
            {
                ArrayList m_arrChargeList=new ArrayList();
                clsBIHOrder order = (clsBIHOrder)m_objViewer.m_dtvGroupDetail.SelectedRows[0].Tag;
                m_objManage.m_lngGetChargeListByGroupDetail(order, out m_arrChargeList);
                ListViewDetailBind((clsORDERCHARGEDEPT_VO[])(m_arrChargeList.ToArray(typeof(clsORDERCHARGEDEPT_VO))));
            }
           
            
        }

        private void ListViewDetailBind(clsORDERCHARGEDEPT_VO[] m_arrDEPT_VO)
        {
            this.m_objViewer.m_dtvChangeList.Rows.Clear();
            if (m_arrDEPT_VO == null)
            {
                return;
            }
            decimal m_decSum = 0;
            for (int i = 0; i < m_arrDEPT_VO.Length; i++)
            {
                clsORDERCHARGEDEPT_VO m_objDEPTVO = m_arrDEPT_VO[i];
                this.m_objViewer.m_dtvChangeList.Rows.Add();
                DataGridViewRow row1 = this.m_objViewer.m_dtvChangeList.Rows[this.m_objViewer.m_dtvChangeList.RowCount - 1];
                row1.Cells["dtv_NO"].Value = Convert.ToString(i + 1);//序
                row1.Cells["dtv_ItemName"].Value = m_objDEPTVO.m_strChargeitemname_chr;//收费项
                row1.Cells["dtv_ChargeClass"].Value = "";//费用类别
                switch (m_objDEPTVO.m_intFLAG_INT)
                {
                    case 0:
                        row1.Cells["dtv_ChargeClass"].Value = "主项目";
                        break;
                    case 1:
                        row1.Cells["dtv_ChargeClass"].Value = "辅助项目";
                        break;
                    case 2:
                        row1.Cells["dtv_ChargeClass"].Value = "用法带出";
                        break;
                    case 3:
                        row1.Cells["dtv_ChargeClass"].Value = "补充录入项目";
                        break;
                }
                row1.Cells["dtv_ITEMSPEC_VCHR"].Value = m_objDEPTVO.m_strSpec_vchr;// 规格
                row1.Cells["dtv_MinPrice"].Value = m_objDEPTVO.m_decUnitprice_dec;//单价
                row1.Cells["dtv_QTY_INT"].Value = m_objDEPTVO.m_decAmount_dec;// 数量
                row1.Cells["dtv_priceAdd"].Value = m_objDEPTVO.m_decUnitprice_dec * m_objDEPTVO.m_decAmount_dec;// 合计
                m_decSum += m_objDEPTVO.m_decUnitprice_dec * m_objDEPTVO.m_decAmount_dec;
                row1.Tag = m_objDEPTVO;
            }
            this.m_objViewer.m_lblChargeSum.Text = "费用合计:" +m_decSum.ToString("0.00");
          
        }

        internal void LoadTheGroup(string m_strFindCode, string m_strEmpId, string m_strInpatientAreaID, int m_intClass, out clsBIHOrderGroup[] arrGroup)
        {
            long ret1 = m_objManage.m_lngFindGroup(m_strFindCode, m_strEmpId, m_strInpatientAreaID, m_intClass, out arrGroup);
        }

        //原来使用ArrayList的代码
        //internal long GetTheHisControl(ArrayList m_arrControl, out DataTable dtbResult)
        //{
        //    long lngRes = m_objManage.GetTheHisControl(m_arrControl, out  dtbResult);
        //    return lngRes;
        //}
        //使用List<T>代码
        internal long GetTheHisControl(System.Collections.Generic.List<string> m_arrControl, out DataTable dtbResult)
        {
            long lngRes = m_objManage.GetTheHisControl(m_arrControl, out  dtbResult);
            return lngRes;
        }
        internal void GetTheSelectOrderDic(ref ArrayList m_arrOrderDic,ref  DataTable m_dtOrderDic)
        {
            m_arrOrderDic = new ArrayList();
            m_dtOrderDic = new DataTable();
            m_dtOrderDic.Columns.Clear();
            m_dtOrderDic.Columns.Add("OrderDicID");
            m_dtOrderDic.Columns.Add("OrderDicCateID");
            if (this.m_objViewer.m_dtvGroupDetail.RowCount > 0)
            {

                for (int i = 0; i < this.m_objViewer.m_dtvGroupDetail.RowCount; i++)
                {
                    //clsBIHOrder order = (clsBIHOrder)this.m_objViewer.listView2.CheckedItems[i].Tag;
                    if (this.m_objViewer.m_dtvGroupDetail.Rows[i].Cells["dtv_Check"].Value.ToString().Trim().Equals("0"))
                    {
                        continue;
                    }
                    clsBIHOrder order = (clsBIHOrder)this.m_objViewer.m_dtvGroupDetail.Rows[i].Tag;
                    m_arrOrderDic.Add(order.m_strOrderDicID);
                    DataRow row1 = m_dtOrderDic.NewRow();
                    row1["OrderDicID"] = order.m_strOrderDicID;
                    row1["OrderDicCateID"] = order.m_strOrderDicCateID;
                    m_dtOrderDic.Rows.Add(row1);
                   
                }

            }
           
        }

        internal void LoadTheCate(ref Hashtable m_htOrderCate)
        {
            long lngRes = 0;
            clsT_aid_bih_ordercate_VO[] p_objItemArr = null;
            lngRes = m_objManage.m_lngGetAidOrderCate(out p_objItemArr);
            m_htOrderCate.Clear();
            for (int i = 0; i < p_objItemArr.Length; i++)
            {
                if (!m_htOrderCate.Contains(p_objItemArr[i].m_strORDERCATEID_CHR))
                {
                    m_htOrderCate.Add(p_objItemArr[i].m_strORDERCATEID_CHR, p_objItemArr[i]);
                }
            }
        }
    }
}
