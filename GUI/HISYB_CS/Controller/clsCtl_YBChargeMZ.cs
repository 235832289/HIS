using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using System.Collections.Generic;
using System.Threading;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsCtl_YBChargeMZ : com.digitalwave.GUI_Base.clsController_Base
    {
        public clsCtl_YBChargeMZ()
        {
            objDomain = new clsDcl_YB();
        }
        public clsDcl_YB objDomain = null;

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmYBChargeMZ m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmYBChargeMZ)frmMDI_Child_Base_in;
        }
        #endregion
        /// <summary>
        /// 门诊结算VO
        /// </summary>
        clsDGMzjs_VO objDgmzjsVo = new clsDGMzjs_VO();
        clsDGExtra_VO objDgextraVo = new clsDGExtra_VO();
        /// <summary>
        /// 门诊待遇享受
        /// </summary>
        clsDGMzdyxs_VO objDGMzdyxsVo = new clsDGMzdyxs_VO();
        /// <summary>
        /// 门诊结算返回结果vo
        /// </summary>
        clsDGMzjsfh_VO objDgmzjsfhVo = null;
        /// <summary>
        /// 处方明细
        /// </summary>
        internal List<clsDGMzxmcs_VO> lstDGMzxmcsVo = new List<clsDGMzxmcs_VO>();

        #region 初始化界面,vo
        /// <summary>
        /// 初始化界面,vo
        /// </summary>
        public void m_mthInit()
        {
            long lngRes = clsYBPublic_cs.m_lngUserLoin(null, null, true);//need modify 调试时确定是否每个业务操作需要登录
            if (lngRes > 0)
            {
                //初始化界面
                this.m_objViewer.lblName.Text = this.m_objViewer.strPatientName;
                this.m_objViewer.lblZyh.Text = this.m_objViewer.strPatientCardNo;// strRecipeID;
                this.m_objViewer.lblJsxh.Text = string.Empty;
                lstDGMzxmcsVo = this.m_objViewer.lstDGMzxmcsVo;

                //初始化额外信息vo：objDgextraVo
                objDgextraVo.YYBH = clsYBPublic_cs.m_strReadXML("DGCSMZYB", "YYBHMZ", "AnyOne");
                objDgextraVo.JBR = this.m_objViewer.strEmpNo;// 操作员工号
                //初始化门诊待遇vo
                objDGMzdyxsVo.GMSFHM = this.m_objViewer.strIDCardNo.ToUpper();
                objDGMzdyxsVo.JZLB = "";//默认为空，所有类别全部查询
                objDGMzdyxsVo.JZRQ = DateTime.Now.ToString("yyyyMMdd");
                objDGMzdyxsVo.YYBH = clsYBPublic_cs.m_strReadXML("DGCSMZYB", "YYBHMZ", "AnyOne");
                objDGMzdyxsVo.JZYYBH = clsYBPublic_cs.m_strReadXML("DGCSMZYB", "YYBHMZ", "AnyOne");
                //查询是否享受医保待遇
                m_mthMzdyxs();
                //初始化结算vo：objDgmzjsVo
                DataTable dtResult = null;
                lngRes = this.objDomain.m_lngGetDgmzjsdata(this.m_objViewer.strRecipeID, out dtResult);
                if (lngRes > 0)
                {
                    decimal decTotalEmp = this.m_objViewer.decTotal;
                    if (dtResult != null && dtResult.Rows.Count > 0)
                    {
                        //need modify 需要把vo值补充完整
                        objDgmzjsVo.YYBH = clsYBPublic_cs.m_strReadXML("DGCSMZYB", "YYBHMZ", "AnyOne");
                        objDgmzjsVo.JZYYBH = clsYBPublic_cs.m_strReadXML("DGCSMZYB", "YYBHMZ", "AnyOne");
                        objDgmzjsVo.ZYH = dtResult.Rows[0]["zyh"].ToString();//挂号编号，没有挂号编码的话可统一传处方号
                        objDgmzjsVo.CFH = this.m_objViewer.strRecipeID;
                        objDgmzjsVo.GMSFHM = dtResult.Rows[0]["gmsfhm"].ToString();//身份证号
                        objDgmzjsVo.JZRQ = (Convert.ToDateTime(dtResult.Rows[0]["jzrq"].ToString())).ToString("yyyyMMdd");//就诊日期，可取处方日期
                        objDgmzjsVo.CYZD = dtResult.Rows[0]["cyzd"].ToString().Length == 0 ? "*" : dtResult.Rows[0]["cyzd"].ToString();//门诊诊断

                        objDgmzjsVo.CYBQDM = dtResult.Rows[0]["cybqdm"].ToString();//就诊科室，需从对应表里取t_ins_deptrel.insdeptcode_vchr字段
                        objDgmzjsVo.YYRYKS = dtResult.Rows[0]["yyryks"].ToString();//医院自己命名的科室名称
                        objDgmzjsVo.YLFYZE = decTotalEmp.ToString("0.00"); ;
                        objDgmzjsVo.FPHM = this.m_objViewer.strInvNO;//发票号码
                        objDgmzjsVo.LXDH = dtResult.Rows[0]["lxdh"].ToString();//联系电话
                        objDgmzjsVo.BZ = "";
                        objDgmzjsVo.JBR = this.m_objViewer.strEmpNo;//当前his登录员工号
                        this.m_objViewer.strJZJLH = dtResult.Rows[0]["jzjlh"].ToString();
                        this.m_objViewer.strSDYWH = dtResult.Rows[0]["sdywh"].ToString();//医保结算号
                        this.m_objViewer.decTotal = decTotalEmp;
                        this.m_objViewer.decYBTotal = dtResult.Rows[0]["ylfyze"].ToString().Length == 0 ? 0 : Convert.ToDecimal(dtResult.Rows[0]["ylfyze"].ToString());//医保总金额
                        this.m_objViewer.decAcc = dtResult.Rows[0]["tczf"].ToString().Length == 0 ? 0 : Convert.ToDecimal(dtResult.Rows[0]["tczf"].ToString());//统筹金
                        this.m_objViewer.decSub = dtResult.Rows[0]["grzfze"].ToString().Length == 0 ? 0 : Convert.ToDecimal(dtResult.Rows[0]["grzfze"].ToString());//自付
                        this.m_objViewer.lblTotal.Text = this.m_objViewer.decYBTotal.ToString("0.00"); ;
                        this.m_objViewer.lblSub.Text = this.m_objViewer.decSub.ToString("0.00");
                        this.m_objViewer.lblAcc.Text = this.m_objViewer.decAcc.ToString("0.00");
                        this.m_objViewer.lblJsxh.Text = this.m_objViewer.strSDYWH;
                    }
                }
            }
        }
        #endregion

        #region 门诊享受待遇判断
        /// <summary>
        /// 门诊享受待遇判断
        /// </summary>
        public void m_mthMzdyxs()
        {
            int intPtr = clsYBPublic_cs.CreateInstace();
            if (intPtr > 0)
            {
                string strJZLB = "";
                string strYY = "";
                string strDYXSBZ = "";
                List<string> lstJzlb = new List<string>();
                long lngRes = clsYBPublic_cs.m_lngFunSP1002(intPtr, objDGMzdyxsVo, objDgextraVo, ref strJZLB, ref strYY, ref strDYXSBZ, ref lstJzlb, this.m_objViewer.IsBirthInsurance);
                if (lngRes > 0)
                {
                    // 就诊类别-------------------------------------
                    //构造数据源  
                    DataTable OutDatable = new DataTable();
                    DataColumn ADC1 = new DataColumn("Name", typeof(string));
                    DataColumn ADC2 = new DataColumn("ID", typeof(string));
                    OutDatable.Columns.Add(ADC1);
                    OutDatable.Columns.Add(ADC2);
                    for (int i = 0; i < lstJzlb.Count; i++)
                    {
                        DataRow ADR = OutDatable.NewRow();
                        ADR[0] = clsYBPublic_cs.m_mthYBJzlbConvert(lstJzlb[i].ToString());
                        ADR[1] = lstJzlb[i].ToString();
                        OutDatable.Rows.Add(ADR);
                    }
                    //进行绑定  
                    this.m_objViewer.cmbJzlb.DisplayMember = "Name";//控件显示的列名  
                    this.m_objViewer.cmbJzlb.ValueMember = "ID";//控件值的列名  
                    this.m_objViewer.cmbJzlb.DataSource = OutDatable;
                    //-------------------------------------------
                    // this.m_objViewer.lbljzlb.Tag = strJZLB;
                    this.m_objViewer.lbldyxsdz.Tag = strDYXSBZ;
                    this.m_objViewer.txtReason.Text = strYY;
                    if (strDYXSBZ == "0")
                    {
                        if (this.m_objViewer.IsBirthInsurance)
                        {
                            this.m_objViewer.lbldyxsdz.Text = "不能享受生育保险报销";
                            MessageBox.Show("未办理生育保险登记确认信息，社保不可报销。", "系统提示");
                        }
                        else
                        {
                            this.m_objViewer.lbldyxsdz.Text = "不能享受医保待遇";
                            MessageBox.Show("社保系统提示：该病人目前不能享受医保待遇，请注意！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }
                        this.m_objViewer.btnUpload.Enabled = false;
                        this.m_objViewer.btnCharge.Enabled = false;
                        this.m_objViewer.btnOk.Enabled = false;
                        return;
                    }
                    else if (strDYXSBZ == "1")
                    {
                        this.m_objViewer.lbldyxsdz.Text = "享受医保待遇";
                        this.m_objViewer.btnUpload.Enabled = true;
                        this.m_objViewer.btnCharge.Enabled = true;
                        this.m_objViewer.btnOk.Enabled = true;
                    }
                    #region 就诊类别

                    //if (strJZLB == "12")
                    //{
                    //    this.m_objViewer.lbljzlb.Text = "特定门诊";
                    //}
                    //else if (strJZLB == "32")
                    //{
                    //    this.m_objViewer.lbljzlb.Text = "门诊康复";
                    //}
                    //else if (strJZLB == "51")
                    //{
                    //    this.m_objViewer.lbljzlb.Text = "普通门诊";
                    //}
                    //else if (strJZLB == "52")
                    //{
                    //    this.m_objViewer.lbljzlb.Text = "急诊门诊";
                    //}
                    //else if (strJZLB == "53")
                    //{
                    //    this.m_objViewer.lbljzlb.Text = "转诊门诊";
                    //}
                    //else if (strJZLB == "54")
                    //{
                    //    this.m_objViewer.lbljzlb.Text = "门诊抢救";
                    //}
                    //else if (strJZLB == "61")
                    //{
                    //    this.m_objViewer.lbljzlb.Text = "特定门诊";
                    //}
                    //else if (strJZLB == "62")
                    //{
                    //    this.m_objViewer.lbljzlb.Text = "社区特定门诊转诊";
                    //}
                    //else if (strJZLB == "63")
                    //{
                    //    this.m_objViewer.lbljzlb.Text = "医院特定门诊(综保)";
                    //}
                    //else if (strJZLB == "64")
                    //{
                    //    this.m_objViewer.lbljzlb.Text = "社区二类特定门诊";
                    //}
                    //else if (strJZLB == "81")
                    //{
                    //    this.m_objViewer.lbljzlb.Text = "公务员体检";
                    //}
                    //else if (strJZLB == "101")
                    //{
                    //    this.m_objViewer.lbljzlb.Text = "医学检查";
                    //}
                    #endregion
                }
            }
        }
        #endregion

        #region 处方明细上传
        /// <summary>
        /// 处方明细上传
        /// </summary>
        public void m_mthRecipeUpload()
        {
            //need modify his获取处方明细
            //if (this.m_objViewer.lbljzlb.Tag == null || this.m_objViewer.lbljzlb.Tag.ToString() =="")
            //{
            //    MessageBox.Show("该病人没有就诊类别，请核对是否正常享受医保待遇！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            if (this.m_objViewer.cmbJzlb.SelectedValue.ToString() == null || this.m_objViewer.cmbJzlb.SelectedValue.ToString() == "")
            {
                MessageBox.Show("该病人没有就诊类别，请核对是否正常享受医保待遇！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lstDGMzxmcsVo.Count > 0)
            {
                for (int i = 0; i < lstDGMzxmcsVo.Count; i++)
                {
                    if (this.m_objViewer.IsBirthInsurance && this.m_objViewer.cmbJzlb.SelectedValue.ToString() != "73") // 生育保险-产前检查
                        lstDGMzxmcsVo[i].JZLB = "73";
                    else
                        lstDGMzxmcsVo[i].JZLB = this.m_objViewer.cmbJzlb.SelectedValue.ToString(); //this.m_objViewer.lbljzlb.Tag.ToString();
                }
                long lngRes = clsYBPublic_cs.m_lngFunSP2002(lstDGMzxmcsVo, objDgextraVo);
                if (lngRes < 0)
                {
                    MessageBox.Show("处方明细数据上传至社保系统失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show("处方明细数据上传成功！下一步点击【社保卡密码验证】按钮进行医保结算！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.m_objViewer.btnUpload.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("没有处方明细或处方明细加载失败，请关闭门诊医保界面窗口再重新打开结算！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region 门诊结算
        /// <summary>
        /// 门诊结算
        /// </summary>
        public void m_mthMzybjs()
        {
            this.m_objViewer.lblJsxh.Text = string.Empty;
            long lngRes = clsYBPublic_cs.m_lngFunSP2004(objDgmzjsVo, out objDgmzjsfhVo);
            if (lngRes < 0)
            {
                MessageBox.Show("医保结算处理失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (objDgmzjsfhVo != null)
            {
                //加上凑整费  -- 因为上传的时候没有上传凑整费，所以现在要加上凑整费
                //objDgmzjsfhVo.YLFYZE = objDgmzjsfhVo.YLFYZE + this.m_objViewer.m_decCZF;
                //objDgmzjsfhVo.GRZFZE = objDgmzjsfhVo.GRZFZE + this.m_objViewer.m_decCZF;
                //decimal decTatolMny = this.m_objViewer.decTotal + this.m_objViewer.m_decCZF;
                //界面显示
                decimal decYbTotal = 0;
                decimal.TryParse(objDgmzjsfhVo.YLFYZE.ToString(), out decYbTotal);
                this.m_objViewer.lblTotal.Text = decYbTotal.ToString("0.00");
                this.m_objViewer.decYBTotal = decYbTotal;
                this.m_objViewer.decAcc = clsYBPublic_cs.ConvertObjToDecimal(objDgmzjsfhVo.TCZF);
                this.m_objViewer.decSub = clsYBPublic_cs.ConvertObjToDecimal(objDgmzjsfhVo.GRZFZE);
                this.m_objViewer.lblSub.Text = clsYBPublic_cs.ConvertObjToDecimal(objDgmzjsfhVo.GRZFZE).ToString("0.00");//自付
                this.m_objViewer.lblAcc.Text = clsYBPublic_cs.ConvertObjToDecimal(objDgmzjsfhVo.TCZF).ToString("0.00");//记账
                this.m_objViewer.strSDYWH = objDgmzjsfhVo.SDYWH.ToString();//结算序号
                this.m_objViewer.strJZJLH = objDgmzjsfhVo.JZJLH.ToString();//就诊记录号
                this.m_objViewer.m_decBCYLTCZF1 = objDgmzjsfhVo.BCYLTCZF1;//补充1支付
                this.m_objViewer.m_decBCYLTCZF2 = objDgmzjsfhVo.BCYLTCZF2;//补充2支付
                this.m_objViewer.m_decBCYLTCZF3 = objDgmzjsfhVo.BCYLTCZF3;//补充3支付
                this.m_objViewer.m_decBCYLTCZF4 = objDgmzjsfhVo.BCYLTCZF4;//补充4支付
                this.m_objViewer.m_decQTZHIFU = objDgmzjsfhVo.QTZHIFU;//其他支付
                this.m_objViewer.m_decYBJZFPJE = objDgmzjsfhVo.YBJZFPJE;//医保记账金额
                this.m_objViewer.lblJsxh.Text = this.m_objViewer.strSDYWH;
                if (this.m_objViewer.decTotal != decYbTotal)
                {
                    MessageBox.Show("社保总金额与HIS总金额不一致，请检查！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                //need modify 保存医保结算结果到his (先用门诊处方号代替)
                string strRegID = objDgmzjsfhVo.CFH;//need modify registerid.门诊好像没有该字段，可用唯一表示该次就诊记录字段代替，门诊也可为空。
                lngRes = this.objDomain.m_lngSaveYBChargeReturn(strRegID, objDgmzjsfhVo);
                if (lngRes > 0)
                {
                    MessageBox.Show("医保结算成功！下一步点击【完成】按钮后退出再进行HIS结算！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }
        #endregion

        #region 撤销处方明细上传
        /// <summary>
        /// 撤销处方明细上传
        /// </summary>
        public void m_mthUndoRecipeUpload()
        {
            if (MessageBox.Show("此操作会把此病人所有已上传的费用全撤销，是否确认此操作？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (objDgextraVo != null)
            {
                objDgextraVo.SDYWH = this.m_objViewer.strRecipeID;
                objDgextraVo.ZYH = this.m_objViewer.strPatientCardNo;
                long lngRes = clsYBPublic_cs.m_lngFunSP2003(objDgextraVo);
                if (lngRes < 0)
                {
                    MessageBox.Show("撤销已上传处方明细数据失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show("撤销已上传处方明细数据成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.m_objViewer.btnUpload.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("没有处方明细或处方明细加载失败，请关闭门诊医保界面窗口再重新打开结算！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region 取消门诊结算
        /// <summary>
        /// 取消门诊结算
        /// </summary>
        public void m_mthUndoMzybjs()
        {
            if (MessageBox.Show("此操作会把此病人所有已上传的费用全撤销，是否确认此操作？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            string strValue = null;
            if (objDgextraVo != null)
            {
                objDgextraVo.SDYWH = this.m_objViewer.strSDYWH;
                objDgextraVo.JZJLH = this.m_objViewer.strJZJLH;
                long lngRes = clsYBPublic_cs.m_lngFunSP2005(objDgextraVo);
                if (lngRes > 0)
                {
                    MessageBox.Show("取消医保结算成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            else
            {
                if (strValue != null)
                {
                    MessageBox.Show("取消医保结算传失败！错误信息：" + strValue.ToString(), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("取消医保结算传失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }
        #endregion

        #region 门诊享受待遇判断
        /// <summary>
        /// 门诊享受待遇判断
        /// </summary>
        public long m_lngPulicMzdyxs(string p_strIdcard, out clsPatient_VO clsPatient)
        {
            clsPatient = new clsPatient_VO();
            long lngRes = clsYBPublic_cs.m_lngUserLoin(null, null, true);//门诊登录
            int intPtr = clsYBPublic_cs.CreateInstace();
            if (intPtr > 0)
            {
                string strJZLB = "";
                string strYY = "";
                string strDYXSBZ = "";
                List<string> lstJzlb = new List<string>();
                objDGMzdyxsVo.GMSFHM = p_strIdcard;
                objDGMzdyxsVo.YYBH = clsYBPublic_cs.m_strReadXML("DGCSMZYB", "YYBHMZ", "AnyOne");
                objDGMzdyxsVo.JZYYBH = clsYBPublic_cs.m_strReadXML("DGCSMZYB", "YYBHMZ", "AnyOne");
                objDgextraVo.JBR = "001";
                lngRes = clsYBPublic_cs.m_lngFunSP1002(intPtr, objDGMzdyxsVo, objDgextraVo, ref strJZLB, ref strYY, ref strDYXSBZ, ref lstJzlb, this.m_objViewer.IsBirthInsurance);
                if (lngRes > 0)
                {
                    if (strDYXSBZ == "0")
                    {
                        //this.m_objViewer.lbldyxsdz.Text = "不能享受医保待遇";
                        //MessageBox.Show("社保系统提示：该病人目前不能享受医保待遇，请注意！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        //this.m_objViewer.btnUpload.Enabled = false;
                        //this.m_objViewer.btnCharge.Enabled = false;
                        //this.m_objViewer.btnOk.Enabled = false;
                        //return;
                    }
                    else if (strDYXSBZ == "1")
                    {
                        //this.m_objViewer.lbldyxsdz.Text = "享受医保待遇";
                        //this.m_objViewer.btnUpload.Enabled = true;
                        //this.m_objViewer.btnCharge.Enabled = true;
                        //this.m_objViewer.btnOk.Enabled = true;
                    }
                    #region 就诊类别
                    if (strJZLB == "0")
                    {
                        clsPatient.strPatType = "自费";
                    }
                    else if (strJZLB == "12")
                    {
                        clsPatient.strPatType = "特定门诊";
                    }
                    else if (strJZLB == "32")
                    {
                        clsPatient.strPatType = "门诊康复";
                    }
                    else if (strJZLB == "51")
                    {
                        clsPatient.strPatType = "普通门诊";
                    }
                    else if (strJZLB == "52")
                    {
                        clsPatient.strPatType = "急诊门诊";
                    }
                    else if (strJZLB == "53")
                    {
                        clsPatient.strPatType = "转诊门诊";
                    }
                    else if (strJZLB == "54")
                    {
                        clsPatient.strPatType = "门诊抢救";
                    }
                    else if (strJZLB == "61")
                    {
                        clsPatient.strPatType = "特定门诊";
                    }
                    else if (strJZLB == "62")
                    {
                        clsPatient.strPatType = "社区特定门诊转诊";
                    }
                    else if (strJZLB == "63")
                    {
                        clsPatient.strPatType = "医院特定门诊(综保)";
                    }
                    else if (strJZLB == "64")
                    {
                        clsPatient.strPatType = "社区二类特定门诊";
                    }
                    else if (strJZLB == "81")
                    {
                        clsPatient.strPatType = "公务员体检";
                    }
                    else if (strJZLB == "101")
                    {
                        clsPatient.strPatType = "医学检查";
                    }
                    #endregion
                }
            }
            return lngRes;
        }
        #endregion

        #region 社保卡密码验证
        /// <summary>
        /// 社保卡密码验证
        /// </summary>
        public void m_mthCheckPsw()
        {
            try
            {
                string strRetMsg = string.Empty;
                objDgextraVo.GMSFHM = this.m_objViewer.strIDCardNo;
                objDgextraVo.ZYLB = "1";
                if (this.m_objViewer.cmbJzlb.SelectedValue != null)
                {
                    if (this.m_objViewer.IsBirthInsurance && this.m_objViewer.cmbJzlb.SelectedValue.ToString() != "73") // 生育保险-产前检查
                        objDgextraVo.JZLB = "73";
                    else
                        objDgextraVo.JZLB = this.m_objViewer.cmbJzlb.SelectedValue.ToString();
                }
                long lngRes = clsYBPublic_cs.m_lngFunSP5001(1, objDgextraVo, DateTime.Now);
            }
            catch (Exception objEx)
            {
                new com.digitalwave.Utility.clsLogText().LogError(objEx);
            }
        }
        #endregion
    }
}
