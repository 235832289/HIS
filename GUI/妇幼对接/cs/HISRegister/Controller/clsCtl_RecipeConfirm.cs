using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;
using System.Drawing;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsCtl_RecipeConfirm : com.digitalwave.GUI_Base.clsController_Base
    {
        public clsCtl_RecipeConfirm()
        {
            objSvc = new clsDcl_RecipeConfirm();
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmRecipeConfirm m_objViewer;
        clsDcl_RecipeConfirm objSvc = null;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmRecipeConfirm)frmMDI_Child_Base_in;
        }
        #endregion

        #region 根据卡号查询病人信息
        /// <summary>
        /// 根据卡号查询病人信息
        /// </summary>
        public void m_mthGetPatientInfo()
        {
            string strCardno = this.m_objViewer.txtCardno.Text.Trim().ToString();
            DataTable dtResult = new DataTable();
            clsRecipeInfo_VO[] objRI_VO = null;
            long lngRes = objSvc.m_lngGetPatientInfo(strCardno, out dtResult);
            if (lngRes > 0 && dtResult.Rows.Count > 0)
            {
                string strPatientID = dtResult.Rows[0]["PATIENTID_CHR"].ToString();
                this.m_objViewer.txtName.Text = dtResult.Rows[0]["lastname_vchr"].ToString();
                this.m_objViewer.txtSex.Text = dtResult.Rows[0]["sex_chr"].ToString();
                lngRes = objSvc.m_mthLoadRecipeNo(strCardno, out objRI_VO);
                if (lngRes > 0 && objRI_VO != null)
                {
                    this.m_mthFillTreeView(objRI_VO);
                }
            }
        }
        #endregion

        #region 加载TreeView
        /// <summary>
        /// 加载TreeView
        /// </summary>
        /// <param name="p_objRI_VO"></param>
        private void m_mthFillTreeView(clsRecipeInfo_VO[] p_objRI_VO)
        {
            this.m_objViewer.trvRecipe.Nodes.Clear();
            clsRecipeInfo_VO objRI_VO;
            string strdate;//日期
            bool flag;
            for (int i = 0; i < p_objRI_VO.Length; i++)
            {
                //if (p_objRI_VO[i].m_strIsGreen != "1")
                //{
                //    continue;
                //}
                objRI_VO = p_objRI_VO[i];
                flag = true;
                if (i == 0)
                {
                    m_mthAddNewNode(objRI_VO);
                }
                else
                {
                    strdate = DateTime.Parse(objRI_VO.m_strCreatTime).ToString("yyyy年MM月dd日");
                    for (int i2 = 0; i2 < this.m_objViewer.trvRecipe.Nodes.Count; i2++)
                    {
                        if (strdate == this.m_objViewer.trvRecipe.Nodes[i2].Text.Trim())
                        {
                            TreeNode subtn = new TreeNode(objRI_VO.m_strOUTPATRECIPEID_CHR);
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
                            subtn.ForeColor = this.m_mthCreatColor(objRI_VO.m_intPSTATUS_INT);
                            subtn.Tag = objRI_VO;
                            this.m_objViewer.trvRecipe.Nodes[i2].Nodes.Add(subtn);
                            flag = false;
                            break;
                        }

                    }
                    if (flag)
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
            string strdate = DateTime.Parse(objRI_VO.m_strCreatTime).ToString("yyyy年MM月dd日");
            TreeNode tn = new TreeNode(strdate);
            TreeNode subtn = new TreeNode(objRI_VO.m_strOUTPATRECIPEID_CHR);
            //			switch(objRI_VO.m_intPSTATUS_INT)
            //			{
            //				case 1:
            //					subtn.ForeColor=Color.Brown;
            //					break;
            //				case 2:
            //					subtn.ForeColor=Color.Red;
            //					break;
            //			}
            subtn.ForeColor = this.m_mthCreatColor(objRI_VO.m_intPSTATUS_INT);
            subtn.Tag = objRI_VO;
            tn.Nodes.Add(subtn);
            this.m_objViewer.trvRecipe.Nodes.Add(tn);
        }

        #endregion

        #region
        private Color m_mthCreatColor(int p_flag)
        {
            Color ret = Color.Black;
            switch (p_flag)
            {
                case 1:
                    ret = Color.Green;
                    break;
                case -2:
                    ret = Color.Brown;
                    break;
                case 2:
                    ret = Color.Red;
                    break;
                case 3:
                    ret = Color.Red;
                    break;
                case 5:
                    ret = Color.Orange;
                    break;
            }
            return ret;
        }
        #endregion

        #region 显示treeView
        private void m_mthShowTreeView()
        {
            this.m_objViewer.trvRecipe.Nodes[0].Expand();
            this.m_objViewer.trvRecipe.Nodes[0].TreeView.SelectedNode = this.m_objViewer.trvRecipe.Nodes[0].Nodes[0];
            this.m_objViewer.trvRecipe.Focus();
            this.m_objViewer.trvRecipe.Select();
        }
        #endregion

        #region 选中某条后，查询处方
        /// <summary>
        /// 选中某条后，查询处方
        /// </summary>
        public void m_mthGetRecipeInfo()
        {
            this.m_objViewer.objListApp.Clear();
            if (this.m_objViewer.trvRecipe.SelectedNode != null && this.m_objViewer.trvRecipe.SelectedNode.Tag != null)
            {
                try
                {
                    clsRecipeInfo_VO objRI_VO = (clsRecipeInfo_VO)this.m_objViewer.trvRecipe.SelectedNode.Tag;
                    DataTable dt = new DataTable();
                    this.m_objViewer.dgvRecipe.Rows.Clear();
                    this.m_objViewer.dgvDetails.Rows.Clear();
                    if (true)
                    {
                        DataTable dtbDiagnosisItemStatus = null;
                        long ret = 0;
                        //诊疗项目
                        //检验
                        int intCheck = 1;
                        //检查
                        int intTest = 2;
                        //手术
                        int intOps = 3;
                        int intIsSendOth = 0;
                        int intRowIndex = 0;
                        decimal Totalmny = 0;
                        objSvc.m_mthRecipeDetail(objRI_VO.m_strOUTPATRECIPEID_CHR, out dt);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            intRowIndex = this.m_objViewer.dgvRecipe.Rows.Add();

                            DataGridViewRow dgvrTemp = this.m_objViewer.dgvRecipe.Rows[intRowIndex];
                            DataRow dr = dt.Rows[i];

                            //方号
                            dgvrTemp.Cells["colRepNo"].Value = dr["id"].ToString();
                            //项目名称
                            dgvrTemp.Cells["colItemName"].Value = dr["name"].ToString();
                            //诊疗项目id
                            dgvrTemp.Cells["colItemID"].Value = dr["itemid_chr"].ToString();
                            dgvrTemp.Cells["colPatientID"].Value = dr["usageparentid_vchr"].ToString();
                            dgvrTemp.Cells["coldeid"].Value = dr["outpatrecipedeid_chr"].ToString();
                            dgvrTemp.Cells["colChecked"].Value = "F";
                            dgvrTemp.Cells["colstatus"].Value = "";
                            dgvrTemp.Cells["colType"].Value = dr["tableindex_int"].ToString();
                            if (dr["status"].ToString() == "1")
                            {
                                dgvrTemp.Cells["colstatus"].Value = "已确认";
                                dgvrTemp.Cells["colChecked"].Value = "T";
                                dgvrTemp.Cells["colChecked"].ReadOnly = true;
                                dgvrTemp.ReadOnly = true;
                                dgvrTemp.DefaultCellStyle.BackColor = Color.Orange;
                            }
                            //添加目标申请单id
                            //dgvrTemp.Cells["colAttachid"].Value = dr["attachid_vchr"].ToString();

                            //string ordertype = dr["tableindex_int"].ToString();
                            //string strItemid = dr["itemid_chr"].ToString().Trim();
                            //if (dtbDiagnosisItemStatus != null)
                            //{
                            //    dtbDiagnosisItemStatus.Dispose();
                            //    dtbDiagnosisItemStatus = null;
                            //}
                            //if (ordertype == "3")
                            //{
                            //    dgvrTemp.Cells["colItemAttribute"].Value = "lis";
                            //    ret = objSvc.m_lngQueryDiagnosisItemStatus(p_strRecipeNo, dr["orderdicid_chr"].ToString().Trim(), intCheck, out dtbDiagnosisItemStatus);
                            //}
                            //else if (ordertype == "4")
                            //{
                            //    dgvrTemp.Cells["colItemAttribute"].Value = "test";
                            //    ret = objSvc.m_lngQueryDiagnosisItemStatus(p_strRecipeNo, dr["orderdicid_chr"].ToString().Trim(), intTest, out dtbDiagnosisItemStatus);
                            //}
                            //else if (ordertype == "5")
                            //{
                            //    dgvrTemp.Cells["colItemAttribute"].Value = "ops";
                            //    if (objSvc.m_blnChkopsitem(strItemid))
                            //    {
                            //        ret = objSvc.m_lngQueryDiagnosisItemStatus(p_strRecipeNo, dr["orderdicid_chr"].ToString().Trim(), intOps, out dtbDiagnosisItemStatus);
                            //    }
                            //    else
                            //    {
                            //        this.m_objViewer.dgvRecipe.Rows.RemoveAt(intRowIndex);
                            //        continue;
                            //    }
                            //}
                            //else
                            //{
                            //    continue;
                            //}

                            //if (ret > 0)
                            //{
                            //    Totalmny += ConvertObjToDecimal(dr["totalmny_dec"]);

                            //    if (dtbDiagnosisItemStatus != null && dtbDiagnosisItemStatus.Rows.Count > 0)
                            //    {
                            //        DataRow dtrTemp = dtbDiagnosisItemStatus.Rows[0];
                            //        int intStatus = 0;
                            //        int.TryParse(dtrTemp["isfinish"].ToString(), out intStatus);

                            //        if (intStatus == 1)
                            //        {
                            //            dgvrTemp.Cells["colChecked"].Value = "T";
                            //            dgvrTemp.Cells["colChecked"].ReadOnly = true;
                            //            dgvrTemp.Cells["colState"].Value = "已做";
                            //            dgvrTemp.DefaultCellStyle.BackColor = Color.Red;
                            //        }
                            //        else
                            //        {
                            //            dgvrTemp.Cells["colChecked"].Value = "F";
                            //            dgvrTemp.Cells["colState"].Value = "未做";
                            //        }
                            //    }

                            //    dgvrTemp.Tag = dr;
                            //}
                        }
                    }
                    else
                    {
                        this.m_objViewer.dgvRecipe.Columns["colchecked"].Visible = true;
                        string p_strRecipeNo = objRI_VO.m_strOUTPATRECIPEID_CHR;
                        //诊疗项目的状态，是否完成该诊疗
                        DataTable dtbDiagnosisItemStatus = null;
                        long ret = 0;
                        #region 3、诊疗项目
                        //诊疗项目
                        //检验
                        int intCheck = 1;
                        //检查
                        int intTest = 2;
                        //手术
                        int intOps = 3;
                        int intIsSendOth = 0;
                        int intRowIndex = 0;
                        decimal Totalmny = 0;
                        ret = objSvc.m_mthFindRecipeDetailOrder(objRI_VO.m_strOUTPATRECIPEID_CHR, out dt);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            intRowIndex = this.m_objViewer.dgvRecipe.Rows.Add();

                            DataGridViewRow dgvrTemp = this.m_objViewer.dgvRecipe.Rows[intRowIndex];
                            DataRow dr = dt.Rows[i];

                            //方号
                            dgvrTemp.Cells["colRepNo"].Value = "";
                            //项目名称
                            dgvrTemp.Cells["colItemName"].Value = dr["orderdicname_vchr"].ToString();
                            //原规格
                            dgvrTemp.Cells["colOriSpecification"].Value = dr["spec_vchr"].ToString();
                            //新规格
                            dgvrTemp.Cells["colNewSpecification"].Value = "";
                            //频率
                            dgvrTemp.Cells["colFrequency"].Value = "";
                            //用法
                            dgvrTemp.Cells["colUsage"].Value = "";
                            //数量
                            dgvrTemp.Cells["colQuantity"].Value = dr["qty_dec"].ToString();
                            //原单价
                            dgvrTemp.Cells["colOriPrice"].Value = dr["pricemny_dec"].ToString();
                            //新单价
                            dgvrTemp.Cells["colNewPrice"].Value = "";
                            // 原合计金额
                            dgvrTemp.Cells["colSum"].Value = dr["totalmny_dec"].ToString();
                            //诊疗项目id
                            dgvrTemp.Cells["colItemID"].Value = dr["orderdicid_chr"].ToString();

                            //添加目标申请单id
                            dgvrTemp.Cells["colAttachid"].Value = dr["attachid_vchr"].ToString();

                            string ordertype = dr["tableindex_int"].ToString();
                            string strItemid = dr["itemid_chr"].ToString().Trim();
                            if (dtbDiagnosisItemStatus != null)
                            {
                                dtbDiagnosisItemStatus.Dispose();
                                dtbDiagnosisItemStatus = null;
                            }
                            if (ordertype == "3")
                            {
                                dgvrTemp.Cells["colItemAttribute"].Value = "lis";
                                ret = objSvc.m_lngQueryDiagnosisItemStatus(p_strRecipeNo, dr["orderdicid_chr"].ToString().Trim(), intCheck, out dtbDiagnosisItemStatus);
                            }
                            else if (ordertype == "4")
                            {
                                dgvrTemp.Cells["colItemAttribute"].Value = "test";
                                ret = objSvc.m_lngQueryDiagnosisItemStatus(p_strRecipeNo, dr["orderdicid_chr"].ToString().Trim(), intTest, out dtbDiagnosisItemStatus);
                            }
                            else if (ordertype == "5")
                            {
                                dgvrTemp.Cells["colItemAttribute"].Value = "ops";
                                if (objSvc.m_blnChkopsitem(strItemid))
                                {
                                    ret = objSvc.m_lngQueryDiagnosisItemStatus(p_strRecipeNo, dr["orderdicid_chr"].ToString().Trim(), intOps, out dtbDiagnosisItemStatus);
                                }
                                else
                                {
                                    this.m_objViewer.dgvRecipe.Rows.RemoveAt(intRowIndex);
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }

                            if (ret > 0)
                            {
                                Totalmny += ConvertObjToDecimal(dr["totalmny_dec"]);

                                if (dtbDiagnosisItemStatus != null && dtbDiagnosisItemStatus.Rows.Count > 0)
                                {
                                    DataRow dtrTemp = dtbDiagnosisItemStatus.Rows[0];
                                    int intStatus = 0;
                                    int.TryParse(dtrTemp["isfinish"].ToString(), out intStatus);

                                    if (intStatus == 1)
                                    {
                                        dgvrTemp.Cells["colChecked"].Value = "T";
                                        dgvrTemp.Cells["colChecked"].ReadOnly = true;
                                        dgvrTemp.Cells["colState"].Value = "已做";
                                        dgvrTemp.DefaultCellStyle.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        dgvrTemp.Cells["colChecked"].Value = "F";
                                        dgvrTemp.Cells["colState"].Value = "未做";
                                    }
                                }

                                dgvrTemp.Tag = dr;
                            }
                        }
                        #endregion

                        #region 4、其他项目,只是显示手动添加的，不显示项目带出的
                        /*
             * 可以通过查看是不是带出的项目来决定是否显示,如，它的用法带出父项目id为空
             * **/
                        //6、其他
                        ret = objSvc.m_mthFindRecipeDetail6(p_strRecipeNo, out dt, false);

                        if (ret > 0)
                        {
                            int intRwoCount = dt.Rows.Count;
                            for (int i1 = 0; i1 < intRwoCount; i1++)
                            {
                                DataRow dtrTemp = dt.Rows[i1];

                                if (string.IsNullOrEmpty(dtrTemp["usageparentid_vchr"].ToString().Trim()))
                                {
                                    intRowIndex = this.m_objViewer.dgvRecipe.Rows.Add();
                                    DataGridViewRow dgvrTemp = this.m_objViewer.dgvRecipe.Rows[intRowIndex];


                                    if (intIsSendOth == 1)
                                    {
                                        dgvrTemp.Cells["colChecked"].Value = "T";
                                        dgvrTemp.Cells["colChecked"].ReadOnly = true;
                                        dgvrTemp.Cells["colState"].Value = "已领材料";
                                        dgvrTemp.DefaultCellStyle.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        dgvrTemp.Cells["colChecked"].Value = "F";
                                        dgvrTemp.Cells["colState"].Value = "未领材料";
                                    }

                                    //方号
                                    dgvrTemp.Cells["colRepNo"].Value = "";
                                    //项目名称
                                    dgvrTemp.Cells["colItemName"].Value = dtrTemp["itemname"].ToString();
                                    //原规格
                                    dgvrTemp.Cells["colOriSpecification"].Value = dtrTemp["dec"].ToString();
                                    //新规格
                                    dgvrTemp.Cells["colNewSpecification"].Value = "";
                                    //频率
                                    dgvrTemp.Cells["colFrequency"].Value = "";
                                    //用法
                                    dgvrTemp.Cells["colUsage"].Value = "";
                                    //数量
                                    dgvrTemp.Cells["colQuantity"].Value = dtrTemp["quantity"].ToString();
                                    //原单价
                                    dgvrTemp.Cells["colOriPrice"].Value = dtrTemp["price"].ToString();
                                    //新单价
                                    dgvrTemp.Cells["colNewPrice"].Value = "";
                                    // 原合计金额
                                    dgvrTemp.Cells["colSum"].Value = dtrTemp["summoney"].ToString();
                                    //项目属性
                                    dgvrTemp.Cells["colItemAttribute"].Value = "oth";
                                    //项目Id
                                    dgvrTemp.Cells["colItemID"].Value = dtrTemp["itemid"].ToString();
                                    //添加目标申请单id
                                    dgvrTemp.Cells["colAttachid"].Value = "";

                                    if (dtrTemp["dec"].ToString().Trim() != dtrTemp["spec"].ToString().Trim())
                                    {
                                        dgvrTemp.Cells["colNewSpecification"].Value = dtrTemp["spec"].ToString();
                                    }

                                    if (this.ConvertObjToDecimal(dtrTemp["price"]) != this.ConvertObjToDecimal(dtrTemp["itemprice_mny"]))
                                    {
                                        dgvrTemp.Cells["colNewPrice"].Value = dtrTemp["itemprice_mny"].ToString();
                                    }

                                    Totalmny += ConvertObjToDecimal(dtrTemp["summoney"]);

                                    dgvrTemp.Tag = dtrTemp;
                                }
                            }
                        }
                        #endregion

                        if (this.m_objViewer.dgvRecipe.Rows.Count == 0)
                        {
                            intRowIndex = this.m_objViewer.dgvRecipe.Rows.Add();
                            DataGridViewRow dgvrTemp = this.m_objViewer.dgvRecipe.Rows[intRowIndex];
                            this.m_objViewer.dgvRecipe.Columns["colchecked"].Visible = false;
                            this.m_objViewer.dgvRecipe.Columns["colItemName"].Width = 300;
                            dgvrTemp.Cells["colItemName"].Value = "没有需要确认的检验、检查、手术等项目";
                            dgvrTemp.Cells["colItemName"].ReadOnly = true;
                        }
                    }
                }
                catch (Exception objEX)
                {
                    com.digitalwave.Utility.clsLogText objLog = new com.digitalwave.Utility.clsLogText();
                    objLog.LogError(objEX);
                }
            }
        }
        #endregion

        #region 转换成数字
        /// <summary>
        /// 转换成数字
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public decimal ConvertObjToDecimal(object obj)
        {
            try
            {
                if (obj != null && obj.ToString() != "")
                {
                    return Convert.ToDecimal(obj.ToString());

                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        #endregion

        #region 根据选择或取消项目，对合单的项目进行关联选择
        /// <summary>
        /// 根据选择或取消项目，对合单的项目进行关联选择
        /// </summary>
        public void m_mthSelectMergeItem(int p_intRowIndex)
        {
            //目标申请单id
            string strArrachid = "";
            string strItemAttribute = this.m_objViewer.dgvRecipe.Rows[p_intRowIndex].Cells["colItemAttribute"].Value.ToString().ToLower();
            if (strItemAttribute == "lis" || strItemAttribute == "test")
            {
                strArrachid = this.m_objViewer.dgvRecipe.Rows[p_intRowIndex].Cells["colAttachid"].Value.ToString().ToLower();
            }

            if (string.IsNullOrEmpty(strArrachid))
            {
                return;
            }

            bool blnIsSelected = false;

            bool.TryParse(this.m_objViewer.dgvRecipe.Rows[p_intRowIndex].Cells["colChecked"].EditedFormattedValue.ToString(), out blnIsSelected);

            if (!blnIsSelected)
            {
                m_mthAddMergeItemStatus(false, strArrachid);
            }
            else
            {
                m_mthAddMergeItemStatus(true, strArrachid);
            }
        }
        private void m_mthAddMergeItemStatus(bool p_blnFlag, string strArrachid)
        {
            int intCount = m_objViewer.dgvRecipe.Rows.Count;
            for (int i1 = 0; i1 < intCount; i1++)
            {
                DataGridViewRow dgvrTmp = this.m_objViewer.dgvRecipe.Rows[i1];
                string strItemAttribute = dgvrTmp.Cells["colItemAttribute"].Value.ToString().ToLower();

                if (strItemAttribute == "lis" || strItemAttribute == "test")
                {
                    if (strArrachid == dgvrTmp.Cells["colAttachid"].Value.ToString().ToLower())
                    {
                        if (p_blnFlag)
                        {
                            dgvrTmp.Cells["colChecked"].Value = "T";
                        }
                        else
                        {
                            dgvrTmp.Cells["colChecked"].Value = "F";
                        }
                    }
                }
            }
        }
        #endregion

        #region 查询该项目的明细
        /// <summary>
        /// 查询该项目的明细
        /// </summary>
        /// <param name="p_strRecipeNO"></param>
        /// <param name="p_strPatientID"></param>
        public void m_mthGetItemDetails(string p_strRecipeNO, string p_strItemID, string p_strPatientID, string p_strPaitentDeID, string p_strType)
        {
            if (string.IsNullOrEmpty(p_strRecipeNO))
            {
                return;
            }
            try
            {                
                DataTable dtDetails = new DataTable();
                long l = objSvc.m_lngGetItemDetails(p_strRecipeNO, p_strPatientID, p_strItemID, p_strType, out dtDetails);
                int intRowIndex = 0;
                if (l > 0 && dtDetails.Rows.Count > 0)
                {
                    for (int i = 0; i < dtDetails.Rows.Count; i++)
                    {
                        intRowIndex = this.m_objViewer.dgvDetails.Rows.Add();

                        DataGridViewRow dgvrTemp = this.m_objViewer.dgvDetails.Rows[intRowIndex];
                        DataRow dr = dtDetails.Rows[i];

                        //方号
                        dgvrTemp.Cells["colRecipeno"].Value = dr["id"].ToString();
                        //项目名称
                        dgvrTemp.Cells["colNAME"].Value = dr["name"].ToString();
                        //数量
                        dgvrTemp.Cells["colCount"].Value = dr["count"].ToString();
                        //单价
                        dgvrTemp.Cells["colPrice"].Value = dr["price"].ToString();
                        //规格
                        dgvrTemp.Cells["colDec"].Value = dr["dec"].ToString();
                        //明细ID
                        dgvrTemp.Cells["colrecipedeid"].Value = dr["outpatrecipedeid_chr"].ToString();
                        //父明细ID
                        dgvrTemp.Cells["colpatientdeid"].Value = p_strPaitentDeID;
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLog = new com.digitalwave.Utility.clsLogText();
                objLog.LogError(objEx);
            }
        }
        #endregion

        #region 确认后更改申请单状态
        /// <summary>
        /// 确认后更改申请单状态
        /// </summary>
        public void m_mthConfirmApp()
        {
            if (this.m_objViewer.dgvDetails.Rows.Count > 0)
            {
                int num = 0;
               
                for (int i = 0; i < this.m_objViewer.dgvRecipe.Rows.Count; i++)
                {
                    DataGridViewRow dr = this.m_objViewer.dgvRecipe.Rows[i];
                    if (dr.Cells["colChecked"].Value.ToString() == "T" && !dr.Cells["colstatus"].Value.ToString().Contains("已确认"))
                    {
                        num++;
                    }
                }
                clsOutpatientRecipe_VO[] objRecipeVO = new clsOutpatientRecipe_VO[num];
                int numbers = -1;
                for (int i = 0; i < this.m_objViewer.dgvRecipe.Rows.Count; i++)
                {
                    DataGridViewRow dr = this.m_objViewer.dgvRecipe.Rows[i];
                    if (dr.Cells["colChecked"].Value.ToString() == "T" && !dr.Cells["colstatus"].Value.ToString().Contains("已确认"))
                    {
                        numbers++;
                        objRecipeVO[numbers] = new clsOutpatientRecipe_VO();
                        objRecipeVO[numbers].m_strOutpatRecipeNo = dr.Cells["colRepNo"].Value.ToString();
                        objRecipeVO[numbers].m_strOutpatRecipeID = dr.Cells["coldeid"].Value.ToString();
                        objRecipeVO[numbers].strDIAG_VCHR = this.m_objViewer.LoginInfo.m_strEmpID.ToString();
                    }
                }
                objSvc.m_lngModiffyAppStatus(objRecipeVO);
                this.m_mthGetRecipeInfo();
            }
            else
            {
                MessageBox.Show("请选择需要确认的项目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        #endregion

        #region 不勾选某条时，去掉明细中的相应条目
        /// <summary>
        /// 不勾选某条时，去掉明细中的相应条目
        /// </summary>
        /// <param name="p_strPatientDeID"></param>
        public void m_mthDeleteItemDetails(string p_strPatientDeID)
        {
            if (this.m_objViewer.dgvDetails.Rows.Count > 0)
            {
                for (int i = 0; i < this.m_objViewer.dgvDetails.Rows.Count; i++)
                {
                    string strTemp = this.m_objViewer.dgvDetails.Rows[i].Cells["colpatientdeid"].Value.ToString();
                    if (p_strPatientDeID == strTemp)
                    {
                        this.m_objViewer.dgvDetails.Rows.RemoveAt(i);
                        i--;
                    }
                }
                //foreach (DataGridViewRow dr in this.m_objViewer.dgvDetails.Rows)
                //{
                //    string strTemp = dr.Cells["colpatientdeid"].Value.ToString();
                //    if (p_strPatientDeID == strTemp)
                //    {
                //        this.m_objViewer.dgvDetails.Rows.Remove(dr);
                //    }
                //}
            }
        }
        #endregion

        #region 取消确认
        /// <summary>
        /// 取消确认
        /// </summary>
        public void m_mthItemsCancel()
        {
            if (this.m_objViewer.dgvRecipe.SelectedRows.Count > 0)
            {
                try
                {
                    string strItemdid = this.m_objViewer.dgvRecipe.CurrentRow.Cells["coldeid"].Value.ToString();
                    string strEmpid = this.m_objViewer.LoginInfo.m_strEmpID;
                    long lngRes = objSvc.m_lngItemsCancel(strItemdid, strEmpid);
                    if(lngRes >0)
                    {
                        this.m_mthGetRecipeInfo();
                    }
                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLog = new com.digitalwave.Utility.clsLogText();
                    objLog.LogError(objEx);
                }               
            }
        }
        #endregion

        #region 权限判断
        /// <summary>
        /// 权限判断
        /// </summary>
        public void m_mthCompetence()
        {
            if (!objSvc.m_blnCompetence(this.m_objViewer.LoginInfo.m_strEmpID))
            {
               // this.m_objViewer.contextMenuStrip1.Visible = false;
                this.m_objViewer.dgvRecipe.ContextMenuStrip = null;
            }
        }
        #endregion
    }
}
