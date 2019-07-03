using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using System.Collections.Generic;
using com.digitalwave.Utility;
using System.IO;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsCtl_YBChargeZY : com.digitalwave.GUI_Base.clsController_Base
    {
        public clsCtl_YBChargeZY()
        {
            objDomain = new clsDcl_YB();
        }
        public clsDcl_YB objDomain = null;

        /// <summary>
        /// 出院诊断是否使用默认值
        /// </summary>
        public bool blnIfDefaultCYZD = false;
        public string strCYZD = "";
        #region 获取药品让利开关 Add by 吴汉明 2014-12-25
        public bool m_blnDiffCostOn = false;
        #endregion
        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmYBChargeZY m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmYBChargeZY)frmMDI_Child_Base_in;
        }
        #endregion

        clsDGExtra_VO objDgextraVo = null;

        Dictionary<string, string> dicJSDYZDBY = new Dictionary<string, string>();
        string strRYDYZDBY = "";
        string strJSDYZDBY = "";

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public void m_mthInit()
        {
            dicJSDYZDBY.Add("", "");
            dicJSDYZDBY.Add("疾病", "11");
            dicJSDYZDBY.Add("自我因素导致的伤害", "12");
            dicJSDYZDBY.Add("其他非第三方导致的伤害", "13");
            dicJSDYZDBY.Add("突发事件导致的伤害", "14");
            dicJSDYZDBY.Add("第三方导致的伤害（交通事故除外）", "15");
            dicJSDYZDBY.Add("交通事故", "16");
            foreach (string strKey in dicJSDYZDBY.Keys)
            {
                this.m_objViewer.cobJSDYZDBY.Items.Add(strKey);
            }
            this.m_objViewer.cobJSDYZDBY.SelectedIndex = 0;

            if (this.m_objViewer.strJslx == "1")//出院结算必须先做出院登记
            {
                this.m_objViewer.btnCYDJ.Visible = true;
                this.m_objViewer.btnCharge.Enabled = false;
            }
            else
            {
                this.m_objViewer.btnCYDJ.Visible = false;
                this.m_objViewer.btnCharge.Enabled = true;
            }
            objDgextraVo = new clsDGExtra_VO();
            objDgextraVo.YYBH = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "YYBHZY", "AnyOne");
            objDgextraVo.JBR = this.m_objViewer.strEmpNo;// 操作员工号
            string strPwd = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "PASSWORDZY", "AnyOne");
            long lngRes = clsYBPublic_cs.m_lngUserLoin(objDgextraVo.YYBH, strPwd, false);
            if (lngRes > 0)
            {
                m_mthZydyxs();
            }


        }
        #endregion

        #region 住院待遇享受条件判断、初始化界面
        /// <summary>
        /// 住院待遇享受条件判断、初始化界面
        /// </summary>
        public void m_mthZydyxs()
        {
            clsDGZydyxs_VO objDgzydyxsVo = null;
            clsDGZyjsfh_VO objDgzyjsfhVo = null;
            string strName = string.Empty;
            string strZyh = string.Empty;
            string strStatus = string.Empty;
            decimal decZyfyze = 0;
            decimal decGrzfeije = 0;
            long lngRes = this.objDomain.m_lngGetZYYBDyxs(this.m_objViewer.strJslx, this.m_objViewer.strRegisterId, ref strName, ref strZyh, ref  strStatus, out objDgzydyxsVo, out objDgzyjsfhVo, out decZyfyze, out decGrzfeije);
            if (objDgzydyxsVo == null)
            {
                MessageBox.Show("该病人没有医保登记信息，请注意！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            this.strRYDYZDBY = objDgzydyxsVo.RYDYZDBY;
            this.strJSDYZDBY = objDgzydyxsVo.JSDYZDBY;

            #region 补全全局病人VO
            objDgextraVo.JZJLH = objDgzydyxsVo.JZJLH;
            objDgextraVo.ZYH = strZyh;

            DataTable dtTmp = null;
            this.objDomain.m_lngGetPatientInfo(objDgextraVo.ZYH, "0", out dtTmp);
            if (dtTmp != null && dtTmp.Rows.Count > 0)
            {
                objDgextraVo.CBDTCQBM = dtTmp.Rows[dtTmp.Rows.Count - 1]["CBDTCQBM_VCHR"].ToString();
            }
            if (string.IsNullOrEmpty(objDgextraVo.CBDTCQBM)) objDgextraVo.CBDTCQBM = "441925";  // 茶山

            #endregion
            if (objDgzyjsfhVo != null)
            {
                if (objDgzyjsfhVo.SDYWH != "0")
                {
                    this.m_objViewer.lblSdywh.Text = objDgzyjsfhVo.SDYWH;
                }
            }
            this.m_objViewer.lblName.Text = strName;
            this.m_objViewer.lblZyh.Text = strZyh;
            if (objDgzydyxsVo.ZYLB == "1" || objDgzydyxsVo.ZYLB == "4")
            {
                if (objDgzydyxsVo.ZYLB == "1")
                    this.m_objViewer.lblzylb.Text = "医疗住院";
                else if (objDgzydyxsVo.ZYLB == "4")
                    this.m_objViewer.lblzylb.Text = "生育住院";

                if (this.strJSDYZDBY != "")
                {
                    foreach (string key in dicJSDYZDBY.Keys)
                    {
                        if (dicJSDYZDBY[key] == this.strJSDYZDBY)
                        {
                            this.m_objViewer.cobJSDYZDBY.Enabled = false;
                            this.m_objViewer.cobJSDYZDBY.SelectedItem = key;
                        }
                    }
                }
                else if (this.strRYDYZDBY != "5" && this.strRYDYZDBY != "6" && !string.IsNullOrEmpty(this.strRYDYZDBY))
                {
                    this.m_objViewer.cobJSDYZDBY.Enabled = false;
                    string strDefault = Convert.ToString(Convert.ToInt32(this.strRYDYZDBY) + 10);
                    foreach (string key in dicJSDYZDBY.Keys)
                    {
                        if (dicJSDYZDBY[key] == strDefault)
                        {
                            this.m_objViewer.cobJSDYZDBY.SelectedItem = key;
                        }
                    }
                }
                else
                {
                    this.m_objViewer.cobJSDYZDBY.SelectedIndex = 0;
                }
            }
            else if (objDgzydyxsVo.ZYLB == "2")
            {
                this.m_objViewer.lblzylb.Text = "工伤住院";

                if (this.strJSDYZDBY != "")
                {
                    foreach (string key in dicJSDYZDBY.Keys)
                    {
                        if (dicJSDYZDBY[key] == this.strJSDYZDBY)
                        {
                            this.m_objViewer.cobJSDYZDBY.Enabled = false;
                            this.m_objViewer.cobJSDYZDBY.SelectedItem = key;
                        }
                    }
                }
                else
                {
                    this.m_objViewer.cobJSDYZDBY.Enabled = false;
                    if (this.strRYDYZDBY != "")
                    {
                        string strDefault = Convert.ToString(Convert.ToInt32(this.strRYDYZDBY) + 10);
                        foreach (string key in dicJSDYZDBY.Keys)
                        {
                            if (dicJSDYZDBY[key] == strDefault)
                            {
                                this.m_objViewer.cobJSDYZDBY.SelectedItem = key;
                            }
                        }
                    }
                }
            }

            this.m_objViewer.lbljzjlh.Text = objDgzydyxsVo.JZJLH;
            this.m_objViewer.lblTotal.Text = decZyfyze.ToString();
            this.m_objViewer.lblSub.Text = decGrzfeije.ToString();
            this.m_objViewer.lblAcc.Text = Convert.ToString(decZyfyze - decGrzfeije);
            string strYYTemp = string.Empty;
            string strDyxsbzTemp = string.Empty;

            lngRes = clsYBPublic_cs.m_lngFunSP1003(objDgzydyxsVo, objDgextraVo, ref strYYTemp, ref strDyxsbzTemp);
            if (lngRes > 0)
            {
                this.m_objViewer.txtReason.Text = strYYTemp;
                if (strDyxsbzTemp == "0")
                {

                    this.m_objViewer.lbldyxsdz.Text = "不能享受医保待遇";
                    MessageBox.Show("社保系统提示：该病人目前不能享受医保待遇，请注意！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.m_objViewer.btnUpload.Enabled = false;
                    this.m_objViewer.btnCharge.Enabled = false;
                    this.m_objViewer.btnOk.Enabled = false;
                    return;
                }
                else if (strDyxsbzTemp == "1")
                {
                    this.m_objViewer.lbldyxsdz.Text = "享受医保待遇";
                    if (strStatus != null)
                    {
                        switch (strStatus)
                        {
                            case "0":
                                this.m_objViewer.btnUpload.Enabled = true;
                                break;
                            case "1":
                                this.m_objViewer.btnCharge.Enabled = true;
                                break;
                        }
                        this.m_objViewer.btnOk.Enabled = true;
                    }
                }
            }

        }
        #endregion


        #region 数据上传
        /// <summary>
        /// 数据上传
        /// </summary>
        public void m_mthUpload()
        {
            //判斷是否能社保結算
            if ((this.strRYDYZDBY != "5" || this.strRYDYZDBY != "6") && string.IsNullOrEmpty(this.m_objViewer.cobJSDYZDBY.SelectedItem.ToString()))
            {
                MessageBox.Show("当住院类别为“医疗住院”且“入院第一诊断病因”为“5第三方导致的伤害（交通事故除外）,6交通事故”时，“结算第一诊断病因”必须重新录入");
                return;
            }
            List<clsDGZyxmcs_VO> lstDgzyxmcsVo = null;
            long lngRes = this.objDomain.m_lngGetDgzyxmcs(this.m_objViewer.strRegisterId, out lstDgzyxmcsVo, this.m_blnDiffCostOn, this.m_objViewer.decTotal, this.m_objViewer.lstPChargeId);
            if (lngRes < 0 || lstDgzyxmcsVo == null || lstDgzyxmcsVo.Count == 0)
            {
                return;
            }

            // 20151207
            decimal tmpMoney = 0;
            foreach (clsDGZyxmcs_VO item in lstDgzyxmcsVo)
            {
                tmpMoney += item.JE;
            }
            decimal diffMoney = this.m_objViewer.decTotal - tmpMoney;
            if (diffMoney != 0)
            {
                for (int k = lstDgzyxmcsVo.Count - 1; k >= 0; k--)
                {
                    if (lstDgzyxmcsVo[k].JE + diffMoney > 0)
                    {
                        lstDgzyxmcsVo[k].JE += diffMoney;
                    }
                }
            }

            #region bak.20151207
            //decimal TempTotal = 0;
            //for (int k = 0; k < lstDgzyxmcsVo.Count; k++)
            //{
            //    TempTotal += lstDgzyxmcsVo[k].MCYL * lstDgzyxmcsVo[k].JG;
            //}
            //decimal diff = this.m_objViewer.decTotal - this.Round(TempTotal, 2);

            //if (diff != 0)
            //{
            //    if (diff > 0)//说明计算出来的 四舍五入之后金额少了 需要加上
            //    {
            //        lstDgzyxmcsVo[0].JE += diff;
            //        lstDgzyxmcsVo[0].JG = lstDgzyxmcsVo[0].JE / lstDgzyxmcsVo[0].MCYL;//金额/数量

            //    }
            //    else
            //    {
            //        for (int k = 0; k < lstDgzyxmcsVo.Count; k++)
            //        {
            //            if (lstDgzyxmcsVo[k].JE + diff > 0)
            //            {
            //                lstDgzyxmcsVo[k].JE += diff;
            //                lstDgzyxmcsVo[k].JG = lstDgzyxmcsVo[k].JE / lstDgzyxmcsVo[k].MCYL;//金额/数量
            //                break;
            //            }
            //        }
            //    }
            //}
            //System.Text.StringBuilder strValue = null;

            //try
            //{
            //    string strHeader = null;
            //    string LogName = @"d:\code\" + this.m_objViewer.strRegisterId + ".csv";
            //    if (File.Exists(LogName))
            //    {
            //        File.Delete(LogName);
            //    }
            //    TempTotal = 0;
            //    decimal total2 = 0;
            //    for (int k = 0; k < lstDgzyxmcsVo.Count; k++)
            //    {
            //        TempTotal = lstDgzyxmcsVo[k].MCYL * lstDgzyxmcsVo[k].JG;
            //        total2 += TempTotal;
            //    }
            //    TempTotal = this.Round(total2, 2);//说要求和保留两位小数.
            //    if (TempTotal != this.m_objViewer.decTotal)//再次校验
            //    {
            //        diff = this.m_objViewer.decTotal - TempTotal;
            //        if (diff < 0)
            //        {
            //            for (int k = 0; k < lstDgzyxmcsVo.Count; k++)
            //            {
            //                TempTotal = lstDgzyxmcsVo[k].JG * lstDgzyxmcsVo[k].JE;
            //                if (TempTotal + diff > 0)
            //                {
            //                    lstDgzyxmcsVo[k].JE = TempTotal + diff;
            //                    lstDgzyxmcsVo[k].JG = this.Round(lstDgzyxmcsVo[k].JE / lstDgzyxmcsVo[k].MCYL, 4);//金额/数量
            //                    break;
            //                }
            //            }
            //        }
            //        else if (diff > 0)
            //        {
            //            TempTotal = lstDgzyxmcsVo[0].JG * lstDgzyxmcsVo[0].JE;
            //            lstDgzyxmcsVo[0].JE = TempTotal + diff;
            //            lstDgzyxmcsVo[0].JG = this.Round(lstDgzyxmcsVo[0].JE / lstDgzyxmcsVo[0].MCYL, 4);//金额/数量
            //        }
            //    }
            //    //日志记录
            //    for (int k = 0; k < lstDgzyxmcsVo.Count; k++)
            //    {
            //        TempTotal = lstDgzyxmcsVo[k].MCYL * lstDgzyxmcsVo[k].JG;
            //        strHeader = lstDgzyxmcsVo[k].JE + "," + TempTotal + "," + lstDgzyxmcsVo[k].MCYL + "," + lstDgzyxmcsVo[k].JG + "\r\n";
            //        File.AppendAllText(LogName, strHeader);
            //    }

            //}
            //catch
            //{
            //}
            #endregion

            System.Text.StringBuilder strValue = new System.Text.StringBuilder(5000);
            lngRes = clsYBPublic_cs.m_lngFunSP3002(lstDgzyxmcsVo, objDgextraVo, ref strValue);
            if (lngRes > 0)
            {
                lngRes = this.objDomain.m_lngUpdateDgzyxmcs(lstDgzyxmcsVo);
                MessageBox.Show("明细上传成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                this.m_objViewer.btnUpload.Enabled = false;
            }
            else
            {
                if (strValue != null)
                {
                    MessageBox.Show("明细上传失败！错误信息：" + strValue.ToString(), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("明细上传失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }
        #endregion


        #region 撤销数据上传
        /// <summary>
        /// 撤销数据上传
        /// </summary>
        public void m_mthCancelUpload()
        {
            if (MessageBox.Show("此操作会把此病人所有已上传的费用全撤销，是否确认此操作？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            List<clsDGZyxmcs_VO> lstDgzyxmcsVo = null;
            //long lngRes = this.objDomain.m_lngGetDgzyxmcs(this.m_objViewer.strRegisterId, out lstDgzyxmcsVo);
            //if (lngRes < 0 || lstDgzyxmcsVo == null || lstDgzyxmcsVo.Count == 0)
            //{
            //    return;
            //}

            DataTable dtTmp = null;
            this.objDomain.m_lngGetPatientInfo(objDgextraVo.ZYH, "0", out dtTmp);
            if (dtTmp != null && dtTmp.Rows.Count > 0)
            {
                objDgextraVo.CBDTCQBM = dtTmp.Rows[dtTmp.Rows.Count - 1]["CBDTCQBM_VCHR"].ToString();
            }
            if (string.IsNullOrEmpty(objDgextraVo.CBDTCQBM)) objDgextraVo.CBDTCQBM = "441925";  // 茶山

            System.Text.StringBuilder strValue = null;
            long lngRes = clsYBPublic_cs.m_lngFunSP3003(lstDgzyxmcsVo, objDgextraVo, ref strValue);
            if (lngRes > 0)
            {
                lngRes = this.objDomain.m_lngUpdateDgzyxmcs(this.m_objViewer.strRegisterId);
                MessageBox.Show("撤销数据上传成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                this.m_objViewer.btnUpload.Enabled = true;
            }
            else
            {
                if (strValue != null)
                {
                    MessageBox.Show("撤销数据上传失败！错误信息：" + strValue.ToString(), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("撤销数据上传失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }
        #endregion



        #region 医保结算
        /// <summary>
        /// 医保结算
        /// </summary>
        /// <param name="blYBss">是否医保结算</param>
        public void m_mthYBCharge(bool blYBss)
        {
            if (string.IsNullOrEmpty(this.m_objViewer.txtZDZMHM.Text))
            {
                MessageBox.Show("诊断证明号码不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                this.m_objViewer.txtZDZMHM.Focus();
                return;
            }

            clsDGZyjs_VO objDgzyjsVo = null;
            long lngRes = this.objDomain.m_lngGetZYYBjs(this.m_objViewer.strJslx, this.m_objViewer.strInvNo, this.m_objViewer.txtZDZMHM.Text.Trim(), this.m_objViewer.decTotal, this.m_objViewer.strRegisterId, out objDgzyjsVo, this.m_blnDiffCostOn);
            if (lngRes < 0 || objDgzyjsVo == null)
            {
                return;
            }
            if (this.m_objViewer.strJslx.Equals("2"))//中途结算
            {
                objDgzyjsVo.JSQSRQ = this.m_objViewer.strJSQSRQ; //结算起始日期
                objDgzyjsVo.JSZZRQ = this.m_objViewer.strJSZZRQ; //结算终止日期
                int intJSTS = 0;
                try
                {
                    intJSTS = Convert.ToInt32(objDgzyjsVo.JSZZRQ) - Convert.ToInt32(objDgzyjsVo.JSQSRQ);
                    intJSTS += 1;
                    if (intJSTS <= 0)
                    {
                        MessageBox.Show("结算终止日期不能小于结算起始日期！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("请勾选正确的日期进行中途结算！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                objDgzyjsVo.JSTS = intJSTS;

            }
            if (!blYBss)//是否医保结算
            {
                objDgzyjsVo.JSLX = "3";
            }
            string strZDZMHM = this.m_objViewer.txtZDZMHM.Text.Trim();
            //need modify 补全医保结算Vo
            objDgzyjsVo.JBR = this.m_objViewer.strEmpNo;//经办人
            objDgzyjsVo.ZDZMHM = strZDZMHM.Length > 30 ? strZDZMHM.Substring(0, 30) : strZDZMHM;
            objDgzyjsVo.JDZFBL = decimal.Parse(this.m_objViewer.txtJdzfbl.Text);//降低支付比例
            //objDgzyjsVo.ZYFYZE = this.m_objViewer.decTotal;//改成由后台合计总额
            objDgzyjsVo.FPHM = this.m_objViewer.strInvNo;//发票号
            objDgzyjsVo.JSDYZDBY = dicJSDYZDBY[this.m_objViewer.cobJSDYZDBY.SelectedItem.ToString()];
            clsDGZyjsfh_VO objDgzyjsfhVo = null;
            if (!string.IsNullOrEmpty(strCYZD))
            {
                objDgzyjsVo.CYZD = strCYZD;
            }
            else
            {
                objDgzyjsVo.CYZD = "出院诊断";
            }
            if (blnIfDefaultCYZD)
            {
                if (this.m_objViewer.strJslx == "1")
                {
                    objDgzyjsVo.CYZD = "出院结算";
                }
                else if (this.m_objViewer.strJslx == "2")
                {
                    objDgzyjsVo.CYZD = "中途结算";
                }
                blnIfDefaultCYZD = false;
            }

            lngRes = clsYBPublic_cs.m_lngFunSP3004(objDgzyjsVo, objDgextraVo, out objDgzyjsfhVo);
            if (lngRes > 0)
            {
                if (objDgzyjsfhVo != null)
                {
                    if (blYBss)
                    {
                        //need add 保存objDgzyjsfhVo到HIS库 //need add 此处可update t_ins_cszyreg.status=2，控制不能再修改医保登记信息
                        lngRes = this.objDomain.m_lngSaveYBChargeReturnZY(this.m_objViewer.strRegisterId, this.m_objViewer.strInvNo, objDgzyjsfhVo, dicJSDYZDBY[this.m_objViewer.cobJSDYZDBY.SelectedItem.ToString()]);
                        //移到上面的方法里面
                        //lngRes = this.objDomain.m_lngUpdateYBRegisterStatusZY(this.m_objViewer.strRegisterId, "2");
                        if (this.m_objViewer.decTotal != objDgzyjsfhVo.ZYFYZE)
                        {
                            MessageBox.Show("医院上传总金额与社保返回总金额不一致，试算失败，请查清原因后再重试。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            return;
                        }
                        this.m_objViewer.lblTotal.Text = objDgzyjsfhVo.ZYFYZE.ToString();
                        this.m_objViewer.decTotal = objDgzyjsfhVo.ZYFYZE;
                        this.m_objViewer.lblSub.Text = objDgzyjsfhVo.GRZFEIJE.ToString();
                        this.m_objViewer.lblAcc.Text = Convert.ToString(objDgzyjsfhVo.ZYFYZE - objDgzyjsfhVo.GRZFEIJE);
                        this.m_objViewer.decYBSub = Convert.ToDecimal(objDgzyjsfhVo.GRZFEIJE.ToString().Trim());

                        this.m_objViewer.btnUpload.Enabled = false;
                        this.m_objViewer.btnCYDJ.Enabled = false;
                        this.m_objViewer.btnCharge.Enabled = false;
                        this.m_objViewer.btnOk.Enabled = true;
                        this.m_objViewer.btnClose.Enabled = true;
                        this.m_objViewer.lblSdywh.Text = objDgzyjsfhVo.SDYWH;
                        MessageBox.Show("医保结算成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {

                        this.m_objViewer.lblTotal.Text = objDgzyjsfhVo.ZYFYZE.ToString();
                        this.m_objViewer.decTotal = objDgzyjsfhVo.ZYFYZE;
                        this.m_objViewer.lblSub.Text = objDgzyjsfhVo.GRZFEIJE.ToString();
                        this.m_objViewer.lblAcc.Text = Convert.ToString(objDgzyjsfhVo.ZYFYZE - objDgzyjsfhVo.GRZFEIJE);
                        this.m_objViewer.decYBSub = Convert.ToDecimal(objDgzyjsfhVo.GRZFEIJE.ToString().Trim());

                        this.m_objViewer.btnUpload.Enabled = false;
                        //this.m_objViewer.btnCYDJ.Enabled = false;
                        this.m_objViewer.btnCharge.Enabled = true;
                        this.m_objViewer.btnOk.Enabled = true;
                        MessageBox.Show("医保试算成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
            }
            else
            {
                this.m_objViewer.btnOk.Enabled = false;
            }
        }
        #endregion

        #region 取消医保结算
        /// <summary>
        /// 取消医保结算
        /// </summary>
        public void m_mthCancelYBCharge()
        {
            string strJsxh = this.m_objViewer.lblSdywh.Text.Trim();
            if (string.IsNullOrEmpty(strJsxh))
            {
                MessageBox.Show("此病人未做医保结算！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (MessageBox.Show("此操作会把此病人所有已上传的费用全撤销，是否确认此操作？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            DataTable dtTmp = null;
            this.objDomain.m_lngGetPatientInfo(objDgextraVo.ZYH, "0", out dtTmp);
            if (dtTmp != null && dtTmp.Rows.Count > 0)
            {
                objDgextraVo.CBDTCQBM = dtTmp.Rows[dtTmp.Rows.Count - 1]["CBDTCQBM_VCHR"].ToString();
            }
            if (string.IsNullOrEmpty(objDgextraVo.CBDTCQBM)) objDgextraVo.CBDTCQBM = "441925";  // 茶山

            System.Text.StringBuilder strValue = null;
            objDgextraVo.SDYWH = this.m_objViewer.lblSdywh.Text;
            long lngRes = clsYBPublic_cs.m_lngFunSP3008(objDgextraVo, ref strValue);
            if (lngRes > 0)
            {
                lngRes = this.objDomain.m_lngUpdateYBChargeStatusZY(objDgextraVo.SDYWH, this.m_objViewer.strRegisterId, "-1");
                this.m_objViewer.lblSdywh.Text = "";
                this.m_objViewer.lblTotal.Text = "";
                this.m_objViewer.lblAcc.Text = "";
                this.m_objViewer.lblSub.Text = "";
                MessageBox.Show("取消医保结算成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
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

        #region 修改医保登记
        /// <summary>
        /// 修改医保登记
        /// </summary>
        public void m_mthModifyReg()
        {
            frmYBRegisterZY objYBReg = new frmYBRegisterZY();
            objYBReg.strRegisterId = this.m_objViewer.strRegisterId;
            objYBReg.ShowDialog();
        }
        #endregion

        #region 出院登记
        /// <summary>
        /// 医保结算
        /// </summary>
        public void m_mthYBCydj()
        {
            clsDGZycydj_VO objdgzycydjVo = null;
            string strJZJLH = this.m_objViewer.lbljzjlh.Text;
            if (string.IsNullOrEmpty(strJZJLH))
            {
                MessageBox.Show("此病人还未进行医保登记，请先登记！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            long lngRes = this.objDomain.m_lngGetZYYBCydj(this.m_objViewer.strRegisterId, strJZJLH, out objdgzycydjVo);
            if (lngRes < 0 || objdgzycydjVo == null)
            {
                return;
            }
            if (!string.IsNullOrEmpty(strCYZD))
            {
                objdgzycydjVo.CYZD = strCYZD;
            }
            else
            {
                objdgzycydjVo.CYZD = "出院诊断";
            }
            lngRes = clsYBPublic_cs.m_lngFunSP3005(objdgzycydjVo, objDgextraVo);
            if (lngRes > 0)
            {
                this.m_objViewer.btnChargeTest.Enabled = true;
                this.m_objViewer.btnCharge.Enabled = true;
                //need add 此处可update t_ins_cszyreg.status=1，控制不能再修改医保登记信息
                lngRes = this.objDomain.m_lngUpdateYBRegisterStatusZY(this.m_objViewer.strRegisterId, "1");
                MessageBox.Show("出院登记成功，现在可以进行医保结算了！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        #endregion

        #region 医保结算单打印
        /// <summary>
        /// 医保结算单打印
        /// </summary>
        /// <param name="strRegisterId">登记ID</param>
        /// <param name="strEmpNO">操作员工号</param>
        public void m_mthYBChang(string strRegisterId, string strEmpNO)
        {
            clsDGExtra_VO objDgextraVo;
            clsDGZYjsxxxx objDgzyjsxxxxVo;
            List<clsDGZYjsGRZFXMMX_VO> lstDgzyjsGRZFXMMXVo;
            this.objDomain.m_lngGetYBChargeZY(strRegisterId, out objDgextraVo);
            if (objDgextraVo != null)
            {
                if (objDgextraVo.JZJLH != null && objDgextraVo.SDYWH != null)
                {
                    objDgextraVo.YYBH = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "YYBHZY", "AnyOne");
                    objDgextraVo.JBR = strEmpNO.ToString().Trim();
                    string strPwd = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "PASSWORDZY", "AnyOne");
                    long lngRes = clsYBPublic_cs.m_lngUserLoin(objDgextraVo.YYBH, strPwd, false);
                    if (lngRes > 0)
                    {
                        clsYBPublic_cs.m_lngFunSP3007(objDgextraVo, out objDgzyjsxxxxVo, out lstDgzyjsGRZFXMMXVo);
                        clsYBPublic_cs.m_mthRptChargeDet(objDgextraVo, objDgzyjsxxxxVo, lstDgzyjsGRZFXMMXVo, 1);
                    }
                }
            }
        }
        #endregion

        #region 检测是否已填住院诊断
        /// <summary>
        /// 检测是否已填住院诊断
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <returns></returns>
        public long m_lngCheckDiagnose()
        {
            long lngRes = 1;
            DataTable dtResult = new DataTable();
            clsDcl_YB objDcl = new clsDcl_YB();
            objDcl.m_lngCheckDiagnose2(this.m_objViewer.strJslx, this.m_objViewer.strRegisterId, out dtResult);
            objDcl = null;
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                strCYZD = dtResult.Rows[0]["outhospitaldiagnose_right"].ToString();
                if (!string.IsNullOrEmpty(strCYZD))
                {
                    if (strCYZD.Length > 100) strCYZD = strCYZD.Substring(0, 100);
                }
                if (dtResult.Rows[0][0].ToString().Length == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                clsLogText log = new clsLogText();
                log.LogError("没有检测到出院诊断");
                return 0;
            }
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
                DateTime dtmFyrq = DateTime.Now;
                long lngRes = this.objDomain.m_lngGetYBPswCheckInfo(objDgextraVo.JZJLH, ref objDgextraVo, out dtmFyrq);
                if (lngRes > 0)
                {
                    lngRes = clsYBPublic_cs.m_lngFunSP5001(2, objDgextraVo, dtmFyrq);
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
        }
        #endregion

        #region 跨省异地卡交易
        /// <summary>
        /// 跨省异地卡交易
        /// </summary>
        internal void Ksydkjy()
        {
            #region get
            clsDGZydyxs_VO objDgzydyxsVo = null;
            clsDGZyjsfh_VO objDgzyjsfhVo = null;
            string strName = string.Empty;
            string strZyh = string.Empty;
            string strStatus = string.Empty;
            decimal decZyfyze = 0;
            decimal decGrzfeije = 0;
            long lngRes = this.objDomain.m_lngGetZYYBDyxs(this.m_objViewer.strJslx, this.m_objViewer.strRegisterId, ref strName, ref strZyh, ref  strStatus, out objDgzydyxsVo, out objDgzyjsfhVo, out decZyfyze, out decGrzfeije);
            if (objDgzydyxsVo == null)
            {
                MessageBox.Show("该病人没有医保登记信息，请注意！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            #endregion

            string uri = string.Empty;
            string JBR = this.m_objViewer.LoginInfo.m_strEmpNo;
            clsDGZydj_VO vo = new clsDGZydj_VO();
            vo.GMSFHM = objDgzydyxsVo.GMSFHM;
            vo.JZLB = objDgzydyxsVo.JZLB;
            vo.RYRQ = this.objDomain.GetFeeMaxDate(this.m_objViewer.strRegisterId); // 费用日期: 结算终止日期
            vo.CBDTCQBM = objDgzydyxsVo.CBDTCQBM;
            vo.YYBH = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "YYBHZY", "AnyOne");  // 住院医院编号
            clsYBPublic_cs.SP3_5003(vo, JBR, objDgzydyxsVo.JZJLH, out  uri);
            if (!string.IsNullOrEmpty(uri))
            {
                frmUri frm = new frmUri("跨省异地卡交易", uri);
                frm.ShowDialog();
            }

        }
        #endregion

        #region 将数值四舍五入
        /// <summary>
        /// 将数值四舍五入
        /// </summary>
        /// <param name="d">数值</param>
        /// <param name="decimals">小数位数</param>
        /// <returns></returns>
        public decimal Round(decimal d, int decimals)
        {
            try
            {
                if (decimals < 1)
                {
                    return Convert.ToDecimal(Convert.ToInt32(d));
                }
                else
                {
                    string s = "0.";
                    for (int i = 0; i < decimals; i++)
                    {
                        s += "0";
                    }
                    return Convert.ToDecimal(d.ToString(s));
                }
            }
            catch
            {
                return d;
            }
        }
        #endregion
    }
}
