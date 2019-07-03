using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.HIS.Report;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.HIS.Reports;
using System.IO;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmLisSampleTypeStat : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmLisSampleTypeStat()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 实体
        /// </summary>
        public class entitySample
        {
            public entitySample() { }
            public string deptName { get; set; }//科室
            public string deptCode { get; set; }
            public int CCY { get; set; }//穿刺液
            public int NANGY { get; set; }//囊液
            public int JIY { get; set; }//积液
            public int CMFMW { get; set; } //创面分泌物
            public int CM { get; set; }//创面
            public int DC { get; set; }//胆汁
            public int DGJ { get; set; }//导管尖
            public int FMW { get; set; }//分泌物
            public int FB { get; set; }//粪便
            public int FS { get; set; }//腹水
            public int GJFMW { get; set; }//宫颈分泌物
            public int HSZZ { get; set; }//坏死组织
            public int KOU { get; set; }// 口
            public int LWZZ { get; set; }//阑尾组织
            public int NJY { get; set; }//脑脊液
            public int NGT { get; set; } //尿管头
            public int NY { get; set; }//脓液
            public int QLXY { get; set; }//前列腺液
            public int QKSCY { get; set; }//切口渗出液
            public int QX { get; set; }//全血
            public int RC { get; set; } //乳汁
            public int RCFMW { get; set; }//褥疮分泌物
            public int SKSZ { get; set; }//伤口拭子(分泌物)
            public int SKZZ { get; set; }//伤口组织
            public int SKSX { get; set; } //伤口渗血
            public int SJMDG { get; set; } //深静脉导管
            public int TAN { get; set; }//痰
            public int WGYLW { get; set; }//胃管引流物
            public int XS { get; set; } // 胸水
            public int YFMW { get; set; }// 咽分泌物
            public int YSZ1 { get; set; }//咽拭子
            public int YSZ2 { get; set; }//眼拭子
            public int YDFMW { get; set; }//阴道分泌物
            public int YLWG { get; set; }//引流物(管)
            public int YS { get; set; } //羊水
            public int ZDNY { get; set; }//中段尿液
            public int HJ { get; set; }//合计
            public string BL { get; set; }//所占比例
        }

        /// <summary>
        /// 变量
        /// </summary>
        Dictionary<string, string> dicGroup;
        DataTable dtbResult = null;
        DataTable dtbApplyUnit = null;
        string DeptIdArr = string.Empty;

        #region frmLisSampleTypeStat_Load
        /// <summary>
        /// frmLisSampleTypeStat_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLisSampleTypeStat_Load(object sender, EventArgs e)
        {
            this.dwRep.LibraryList = Application.StartupPath + "\\criticalreport.pbl";//clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "t_lcbywswbb_stat";
            this.dteRq1.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01");
            dicGroup = new Dictionary<string, string>();
            this.tabContorl.Visible = false;
            this.cboPatType.Items.Add("门诊");
            this.cboPatType.Items.Add("住院");
            

            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                dtbResult = svc.GetGategoryType();
                dtbApplyUnit = svc.GetGategoryType2();
            }

            for (int i = 0; i < dtbResult.Rows.Count; i++)
            {
                this.cbxGroup.Items.Add(dtbResult.Rows[i]["check_category_desc_vchr"].ToString());
                dicGroup.Add(dtbResult.Rows[i]["check_category_id_chr"].ToString(), dtbResult.Rows[i]["check_category_desc_vchr"].ToString());
            }

            if (dtbApplyUnit != null && dtbApplyUnit.Rows.Count > 0)
            {
                //this.dgvCheckItem.DataSource = dtbApplyUnit;
                for (int i= 0;i<dtbApplyUnit.Rows.Count;i++)
                    this.dgvCheckItem.Rows.Add(dtbApplyUnit.Rows[i].ItemArray);
            }
        }
        #endregion

        #region Query
        /// <summary>
        /// Query
        /// </summary>
        internal void Query()
        {
            string beginDate = string.Empty;
            string endDate = string.Empty;
            List<entitySample> data = new List<entitySample>();

            beginDate = this.dteRq1.Value.ToString("yyyy-MM-dd HH:mm");
            endDate = this.dteRq2.Value.ToString("yyyy-MM-dd HH:mm");

            if (Convert.ToDateTime(beginDate + " :01") > Convert.ToDateTime(endDate + ":59"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(this.cbxGroup.Text) && this.dgvCheckItem.Rows.Count < 2)
            {
                MessageBox.Show("请选择专业组或检验项目 ！");
                return;
            }

            string groupId = string.Empty;
            string enmergencyFlg = string.Empty;
            string patType = string.Empty;

            string applyUnitId = string.Empty;

            if (this.dgvCheckItem.Rows.Count >= 2)
            {
                for (int i = 0; i < this.dgvCheckItem.Rows.Count - 1; i++)
                {
                    applyUnitId += "'" + this.dgvCheckItem.Rows[i].Cells[0].Value.ToString() + "',";
                }

                applyUnitId = "(" + applyUnitId.TrimEnd(',') + ")";
            }

            string strDept = this.DeptIdArr;

            if (this.cboPatType.Text.Trim() == "住院")
                patType = "1";
            else if (this.cboPatType.Text.Trim() == "门诊")
                patType = "2";

            if (this.DeptIdArr == "'0000001'")
                strDept = string.Empty;

            foreach (var item in dicGroup)
            {
                if (item.Value == this.cbxGroup.Text)
                    groupId = item.Key;
            }

            if (this.dgvCheckItem.Rows.Count >= 2)
                groupId = "";

            try
            {
                clsPublic.PlayAvi("findFILE.avi", "正在项目信息，请稍候...");
                dwRep.Reset();
                clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
                DataTable dt = svc.GetLisSampletype2(beginDate, endDate, groupId, applyUnitId,patType, strDept);

                if (dt != null && dt.Rows.Count > 0)
                {
                    string deptName1 = "占比";
                    string CCY = string.Empty; //穿刺液
                    string NANGY = string.Empty;
                    string JIY = string.Empty;
                    string CMFMW = string.Empty;
                    string CM = string.Empty;//创面
                    string DC = string.Empty;//胆汁
                    string DGJ = string.Empty;//导管尖
                    string FMW = string.Empty;//分泌物
                    string FB = string.Empty;//粪便
                    string FS = string.Empty;//腹水
                    string GJFMW = string.Empty;//宫颈分泌物
                    string LWZZ = string.Empty;//阑尾组织
                    string HSZZ = string.Empty;//坏死组织
                    string KOU = string.Empty;//口
                    string NJY = string.Empty;//脑脊液
                    string NGT = string.Empty;//尿管头
                    string NY = string.Empty;//脓液
                    string QLXY = string.Empty;//前列腺液
                    string QKSCY = string.Empty;//切口渗出液
                    string QX = string.Empty;//全血
                    string RC = string.Empty;//乳汁
                    string RCFMW = string.Empty;//褥疮分泌物
                    string SKSZ = string.Empty;//伤口拭子(分泌物)
                    string SKZZ = string.Empty;//伤口组织
                    string SKSX = string.Empty;//伤口渗血
                    string SJMDG = string.Empty;//深静脉导管
                    string TAN = string.Empty;//痰
                    string WGYLW = string.Empty;//胃管引流物
                    string XS = string.Empty;//胸水
                    string YSZ1 = string.Empty;//咽拭子
                    string YFMW = string.Empty;//咽分泌物
                    string YS = string.Empty;//羊水
                    string YDFMW = string.Empty;//阴道分泌物
                    string YLWG = string.Empty;//引流物(管)
                    string ZDNY = string.Empty;//中段尿液
                    string YSZ2 = string.Empty;//眼拭子

                    foreach (DataRow dr in dt.Rows)
                    {
                        bool flg = false;

                        string deptCode = dr["code_vchr"].ToString();
                        string deptName = dr["deptname_vchr"].ToString();
                        string sampletype = dr["sampletype_vchr"].ToString();

                        if (data.Count > 0)
                        {
                            for (int i = 0; i < data.Count; i++)
                            {
                                if (data[i].deptCode == deptCode)
                                {
                                    entitySample vo = data[i];
                                    calcSampleType(ref vo, sampletype);
                                    data[i] = vo;
                                    flg = true;
                                    break;
                                }
                            }

                            if (!flg)
                            {
                                entitySample vo = new entitySample();
                                vo.deptName = deptName;
                                vo.deptCode = deptCode;
                                calcSampleType(ref vo, sampletype);
                                data.Add(vo);
                                flg = false;
                            }
                        }
                        else
                        {
                            entitySample vo = new entitySample();
                            vo.deptName = deptName;
                            vo.deptCode = deptCode;
                            calcSampleType(ref vo, sampletype);
                            data.Add(vo);
                        }
                    }
                    if (data.Count > 0)
                    {
                        #region 合计
                        entitySample voSum = new entitySample();
                        voSum.deptName = "合计";
                        for (int i = 0; i < data.Count; i++)
                        {
                            voSum.HJ += data[i].HJ;
                            voSum.CCY += data[i].CCY; //穿刺液
                            voSum.CM += data[i].CM;//创面
                            voSum.DC += data[i].DC;//胆汁
                            voSum.DGJ += data[i].DGJ;//导管尖
                            voSum.FMW += data[i].FMW;//分泌物
                            voSum.FB += data[i].FB;//粪便
                            voSum.FS += data[i].FS;//腹水
                            voSum.GJFMW += data[i].GJFMW;//宫颈分泌物
                            voSum.LWZZ += data[i].LWZZ;//阑尾组织
                            voSum.HSZZ += data[i].HSZZ;//坏死组织
                            voSum.KOU += data[i].KOU;//口
                            voSum.NJY += data[i].NJY;//脑脊液
                            voSum.NGT += data[i].NGT;//尿管头
                            voSum.NY += data[i].NY;//脓液
                            voSum.QLXY += data[i].QLXY;//前列腺液
                            voSum.QKSCY += data[i].QKSCY;//切口渗出液
                            voSum.QX += data[i].QX;//全血
                            voSum.RC += data[i].RC;//乳汁
                            voSum.RCFMW += data[i].RCFMW;//褥疮分泌物
                            voSum.SKSZ += data[i].SKSZ;//伤口拭子(分泌物)
                            voSum.SKZZ += data[i].SKZZ;//伤口组织
                            voSum.SKSX += data[i].SKSX;//伤口渗血
                            voSum.SJMDG += data[i].SJMDG;//深静脉导管
                            voSum.TAN += data[i].TAN;//痰
                            voSum.WGYLW += data[i].WGYLW;//胃管引流物
                            voSum.XS += data[i].XS;//胸水
                            voSum.YSZ1 += data[i].YSZ1;//咽拭子
                            voSum.YFMW += data[i].YFMW;//咽分泌物
                            voSum.YS += data[i].YS;//羊水
                            voSum.YDFMW += data[i].YDFMW;//阴道分泌物
                            voSum.YLWG += data[i].YLWG;//引流物(管)
                            voSum.ZDNY += data[i].ZDNY;//中段尿液
                            voSum.YSZ2 += data[i].YSZ2;//眼拭子
                        }
                        data.Add(voSum);
                        #endregion

                        #region 百分比

                        if (voSum.CCY > 0)//穿刺液
                        {
                            if (voSum.CCY > 0 && voSum.HJ > 0)
                                CCY = Math.Round(((double)voSum.CCY / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.CMFMW > 0)//创面分泌物
                        {
                            if (voSum.CMFMW > 0 && voSum.HJ > 0)
                                CMFMW = Math.Round(((double)voSum.CMFMW / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.JIY > 0)//积液
                        {
                            if (voSum.JIY > 0 && voSum.HJ > 0)
                                JIY = Math.Round(((double)voSum.JIY / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.NANGY > 0)//囊液
                        {
                            if (voSum.NANGY > 0 && voSum.HJ > 0)
                                NANGY = Math.Round(((double)voSum.NANGY / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.CM > 0)//创面
                        {
                            if (voSum.CM > 0 && voSum.HJ > 0)
                                CM = Math.Round(((double)voSum.CM / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.DC > 0)//胆汁
                        {
                            if (voSum.DC > 0 && voSum.HJ > 0)
                                DC = Math.Round(((double)voSum.DC / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.DGJ > 0)//导管尖
                        {
                            if (voSum.DGJ > 0 && voSum.HJ > 0)
                                DGJ = Math.Round(((double)voSum.DGJ / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.FMW > 0)//分泌物
                        {
                            if (voSum.FMW > 0 && voSum.HJ > 0)
                                FMW = Math.Round(((double)voSum.FMW / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.FB > 0)//粪便
                        {
                            if (voSum.FB > 0 && voSum.HJ > 0)
                                FB = Math.Round(((double)voSum.FB / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.FS > 0)//腹水
                        {
                            if (voSum.FS > 0 && voSum.HJ > 0)
                                FS = Math.Round(((double)voSum.FS / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.GJFMW > 0)//宫颈分泌物
                        {
                            if (voSum.GJFMW > 0 && voSum.HJ > 0)
                                GJFMW = Math.Round(((double)voSum.GJFMW / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.HSZZ > 0)//坏死组织
                        {
                            if (voSum.HSZZ > 0 && voSum.HJ > 0)
                                HSZZ = Math.Round(((double)voSum.HSZZ / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.KOU > 0)//口
                        {
                            if (voSum.KOU > 0 && voSum.HJ > 0)
                                KOU = Math.Round(((double)voSum.KOU / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.LWZZ > 0)//阑尾组织
                        {
                            if (voSum.LWZZ > 0 && voSum.HJ > 0)
                                LWZZ = Math.Round(((double)voSum.LWZZ / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.NJY > 0)//脑脊液
                        {
                            if (voSum.NJY > 0 && voSum.HJ > 0)
                                NJY = Math.Round(((double)voSum.NJY / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.NGT > 0)//尿管头
                        {
                            if (voSum.NGT > 0 && voSum.HJ > 0)
                                NGT = Math.Round(((double)voSum.NGT / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.NY > 0)//脓液
                        {
                            if (voSum.NY > 0 && voSum.HJ > 0)
                                NY = Math.Round(((double)voSum.NY / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.QLXY > 0)//前列腺液
                        {
                            if (voSum.QLXY > 0 && voSum.HJ > 0)
                                QLXY = Math.Round(((double)voSum.QLXY / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.QKSCY > 0)//切口渗出液
                        {
                            if (voSum.QKSCY > 0 && voSum.HJ > 0)
                                QKSCY = Math.Round(((double)voSum.QKSCY / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.QX > 0)//全血
                        {
                            if (voSum.QX > 0 && voSum.HJ > 0)
                                QX = Math.Round(((double)voSum.QX / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.RC > 0)//乳汁
                        {
                            if (voSum.RC > 0 && voSum.HJ > 0)
                                RC = Math.Round(((double)voSum.RC / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.RCFMW > 0)//褥疮分泌物
                        {
                            if (voSum.RCFMW > 0 && voSum.HJ > 0)
                                RCFMW = Math.Round(((double)voSum.RCFMW / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.SKSZ > 0)//伤口拭子(分泌物)
                        {
                            if (voSum.SKSZ > 0 && voSum.HJ > 0)
                                SKSZ = Math.Round(((double)voSum.SKSZ / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.SKZZ > 0)//伤口组织
                        {
                            if (voSum.SKZZ > 0 && voSum.HJ > 0)
                                SKZZ = Math.Round(((double)voSum.SKZZ / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.SKSX > 0)//伤口渗血
                        {
                            if (voSum.SKSX > 0 && voSum.HJ > 0)
                                SKSX = Math.Round(((double)voSum.SKSX / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.SJMDG > 0)//深静脉导管
                        {
                            if (voSum.SJMDG > 0 && voSum.HJ > 0)
                                SJMDG = Math.Round(((double)voSum.SJMDG / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.TAN > 0)//痰
                        {
                            if (voSum.TAN > 0 && voSum.HJ > 0)
                                TAN = Math.Round(((double)voSum.TAN / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.WGYLW > 0)//胃管引流物
                        {
                            if (voSum.WGYLW > 0 && voSum.HJ > 0)
                                WGYLW = Math.Round(((double)voSum.WGYLW / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.XS > 0)//胃管引流物
                        {
                            if (voSum.XS > 0 && voSum.HJ > 0)
                                XS = Math.Round(((double)voSum.XS / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.YFMW > 0)//咽分泌物
                        {
                            if (voSum.YFMW > 0 && voSum.HJ > 0)
                                YFMW = Math.Round(((double)voSum.YFMW / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.YSZ1 > 0)//咽拭子
                        {
                            if (voSum.YSZ1 > 0 && voSum.HJ > 0)
                                YSZ1 = Math.Round(((double)voSum.YSZ1 / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.YSZ2 > 0)//眼拭子
                        {
                            if (voSum.YSZ2 > 0 && voSum.HJ > 0)
                                YSZ2 = Math.Round(((double)voSum.YSZ2 / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.YDFMW > 0)//阴道分泌物
                        {
                            if (voSum.YDFMW > 0 && voSum.HJ > 0)
                                YDFMW = Math.Round(((double)voSum.YDFMW / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.YLWG > 0)////引流物(管)
                        {
                            if (voSum.YLWG > 0 && voSum.HJ > 0)
                                YLWG = Math.Round(((double)voSum.YLWG / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.YS > 0)//羊水
                        {
                            if (voSum.YS > 0 && voSum.HJ > 0)
                                YS = Math.Round(((double)voSum.YS / (double)voSum.HJ) * 100, 2).ToString();
                        }

                        if (voSum.ZDNY > 0)//中段尿液
                        {
                            if (voSum.ZDNY > 0 && voSum.HJ > 0)
                                ZDNY = Math.Round(((double)voSum.ZDNY / (double)voSum.HJ) * 100, 2).ToString();
                        }


                        for (int i = 0; i < data.Count - 1; i++)
                        {
                            if (data[i].HJ > 0 && data[data.Count - 1].HJ > 0)
                                data[i].BL = Math.Round(((double)data[i].HJ / (double)data[data.Count - 1].HJ) * 100, 2).ToString();
                        }

                        #endregion
                    }


                    int row = 0;
                    dwRep.SetRedrawOff();

                    for (int i = 0; i < data.Count; i++)
                    {
                        row = dwRep.InsertRow(0);

                        dwRep.SetItemString(row, "ks", data[i].deptName);
                        dwRep.SetItemString(row, "ccy", data[i].CCY > 0 ? data[i].CCY.ToString() : "");
                        dwRep.SetItemString(row, "nangy", data[i].NANGY > 0 ? data[i].NANGY.ToString() : "");
                        dwRep.SetItemString(row, "jiy", data[i].JIY > 0 ? data[i].JIY.ToString() : "");
                        dwRep.SetItemString(row, "cmfmw", data[i].CMFMW > 0 ? data[i].CMFMW.ToString() : "");
                        dwRep.SetItemString(row, "cm", data[i].CM > 0 ? data[i].CM.ToString() : "");
                        dwRep.SetItemString(row, "dz", data[i].DC > 0 ? data[i].DC.ToString() : "");
                        dwRep.SetItemString(row, "dgj", data[i].DGJ > 0 ? data[i].DGJ.ToString() : "");
                        dwRep.SetItemString(row, "fmw", data[i].FMW > 0 ? data[i].FMW.ToString() : "");
                        dwRep.SetItemString(row, "fb", data[i].FB > 0 ? data[i].FB.ToString() : "");
                        dwRep.SetItemString(row, "fs", data[i].FS > 0 ? data[i].FS.ToString() : "");
                        dwRep.SetItemString(row, "gjfmw", data[i].GJFMW > 0 ? data[i].GJFMW.ToString() : "");
                        dwRep.SetItemString(row, "hszz", data[i].HSZZ > 0 ? data[i].HSZZ.ToString() : "");
                        dwRep.SetItemString(row, "lwzz", data[i].LWZZ > 0 ? data[i].LWZZ.ToString() : "");
                        dwRep.SetItemString(row, "njy", data[i].NJY > 0 ? data[i].NJY.ToString() : "");
                        dwRep.SetItemString(row, "ngt", data[i].NGT > 0 ? data[i].NGT.ToString() : "");
                        dwRep.SetItemString(row, "ny", data[i].NY > 0 ? data[i].NY.ToString() : "");
                        dwRep.SetItemString(row, "qlxy", data[i].QLXY > 0 ? data[i].QLXY.ToString() : "");
                        dwRep.SetItemString(row, "qkscy", data[i].QKSCY > 0 ? data[i].QKSCY.ToString() : "");
                        dwRep.SetItemString(row, "qx", data[i].QX > 0 ? data[i].QX.ToString() : "");
                        dwRep.SetItemString(row, "rc", data[i].RC > 0 ? data[i].RC.ToString() : "");
                        dwRep.SetItemString(row, "rcfmw", data[i].RCFMW > 0 ? data[i].RCFMW.ToString() : "");
                        dwRep.SetItemString(row, "sksz", data[i].SKSZ > 0 ? data[i].SKSZ.ToString() : "");
                        dwRep.SetItemString(row, "skzz", data[i].SKZZ > 0 ? data[i].SKZZ.ToString() : "");
                        dwRep.SetItemString(row, "sksx", data[i].SKSX > 0 ? data[i].SKSX.ToString() : "");
                        dwRep.SetItemString(row, "sjmdg", data[i].SJMDG > 0 ? data[i].SJMDG.ToString() : "");
                        dwRep.SetItemString(row, "dy", data[i].TAN > 0 ? data[i].TAN.ToString() : "");
                        dwRep.SetItemString(row, "wgylw", data[i].WGYLW > 0 ? data[i].WGYLW.ToString() : "");
                        dwRep.SetItemString(row, "xs", data[i].XS > 0 ? data[i].XS.ToString() : "");
                        dwRep.SetItemString(row, "yfmw", data[i].YFMW > 0 ? data[i].YFMW.ToString() : "");
                        dwRep.SetItemString(row, "ysz1", data[i].YSZ1 > 0 ? data[i].YSZ1.ToString() : "");
                        dwRep.SetItemString(row, "ysz2", data[i].YSZ2 > 0 ? data[i].YSZ2.ToString() : "");
                        dwRep.SetItemString(row, "ydfmw", data[i].YDFMW > 0 ? data[i].YDFMW.ToString() : "");
                        dwRep.SetItemString(row, "ylw", data[i].YLWG > 0 ? data[i].YLWG.ToString() : "");
                        dwRep.SetItemString(row, "ys", data[i].YS > 0 ? data[i].YS.ToString() : "");
                        dwRep.SetItemString(row, "zdny", data[i].ZDNY > 0 ? data[i].ZDNY.ToString() : "");
                        dwRep.SetItemString(row, "hj", data[i].HJ > 0 ? data[i].HJ.ToString() : "");
                        dwRep.SetItemString(row, "bfb", data[i].BL);
                    }

                    row = dwRep.InsertRow(0);
                    dwRep.SetItemString(row, "ks", deptName1);
                    dwRep.SetItemString(row, "ccy", CCY);
                    dwRep.SetItemString(row, "nangy", NANGY);
                    dwRep.SetItemString(row, "jiy", JIY);
                    dwRep.SetItemString(row, "cmfmw", CMFMW);
                    dwRep.SetItemString(row, "cm", CM);
                    dwRep.SetItemString(row, "dz", DC);
                    dwRep.SetItemString(row, "dgj", DGJ);
                    dwRep.SetItemString(row, "fmw", FMW);
                    dwRep.SetItemString(row, "fb", FB);
                    dwRep.SetItemString(row, "fs", FS);
                    dwRep.SetItemString(row, "gjfmw", GJFMW);
                    dwRep.SetItemString(row, "hszz", HSZZ);
                    dwRep.SetItemString(row, "lwzz", LWZZ);
                    dwRep.SetItemString(row, "njy", NJY);
                    dwRep.SetItemString(row, "ngt", NGT);
                    dwRep.SetItemString(row, "ny", NY);
                    dwRep.SetItemString(row, "qlxy", QLXY);
                    dwRep.SetItemString(row, "qkscy", QKSCY);
                    dwRep.SetItemString(row, "qx", QX);
                    dwRep.SetItemString(row, "rc", RC);
                    dwRep.SetItemString(row, "rcfmw", RCFMW);
                    dwRep.SetItemString(row, "sksz", SKSZ);
                    dwRep.SetItemString(row, "skzz", SKZZ);
                    dwRep.SetItemString(row, "sksx", SKSX);
                    dwRep.SetItemString(row, "sjmdg", SJMDG);
                    dwRep.SetItemString(row, "dy", TAN);
                    dwRep.SetItemString(row, "wgylw", WGYLW);
                    dwRep.SetItemString(row, "xs", XS);
                    dwRep.SetItemString(row, "yfmw", YFMW);
                    dwRep.SetItemString(row, "ysz1", YSZ1);
                    dwRep.SetItemString(row, "ysz2", YSZ2);
                    dwRep.SetItemString(row, "ydfmw", YDFMW);
                    dwRep.SetItemString(row, "ylw", YLWG);
                    dwRep.SetItemString(row, "ys", YS);
                    dwRep.SetItemString(row, "zdny", ZDNY);

                    dwRep.SetRedrawOn();
                }
                else
                {
                    dwRep.InsertRow(0);
                }

                dwRep.Modify("t_date.text = '" + beginDate + " ~ " + endDate + "'");
            }
            finally
            {
                clsPublic.CloseAvi();
            }
            this.dwRep.Refresh();
        }
        #endregion

        #region Query2
        /// <summary>
        /// Query
        /// </summary>
        internal void Query2()
        {
            string beginDate = string.Empty;
            string endDate = string.Empty;
            DataTable dtData = new DataTable();
            List<entitySample> data = new List<entitySample>();
            int totoal = 0;

            dgvData.DataSource = null;
            beginDate = this.dteRq1.Value.ToString("yyyy-MM-dd HH:mm");
            endDate = this.dteRq2.Value.ToString("yyyy-MM-dd HH:mm");

            if (Convert.ToDateTime(beginDate + " :01") > Convert.ToDateTime(endDate + ":59"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(this.cbxGroup.Text) && this.dgvCheckItem.Rows.Count < 2)
            {
                MessageBox.Show("请选择专业组或检验项目 ！");
                return;
            }

            string groupId = string.Empty;
            string enmergencyFlg = string.Empty;
            string patType = string.Empty;

            string applyUnitId = string.Empty;

            if (this.dgvCheckItem.Rows.Count >= 2)
            {
                for (int i = 0; i < this.dgvCheckItem.Rows.Count - 1; i++)
                {
                    applyUnitId += "'" + this.dgvCheckItem.Rows[i].Cells[0].Value.ToString() + "',";
                }

                applyUnitId = "(" + applyUnitId.TrimEnd(',') + ")";
            }

            string strDept = this.DeptIdArr;

            if (this.cboPatType.Text.Trim() == "住院")
                patType = "1";
            else if (this.cboPatType.Text.Trim() == "门诊")
                patType = "2";

            if (this.DeptIdArr == "'0000001'")
                strDept = string.Empty;

            foreach (var item in dicGroup)
            {
                if (item.Value == this.cbxGroup.Text)
                    groupId = item.Key;
            }

            if (this.dgvCheckItem.Rows.Count >= 2)
                groupId = "";

            try
            {
                clsPublic.PlayAvi("findFILE.avi", "正在项目信息，请稍候...");
                dwRep.Reset();
                clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
                DataTable dt = svc.GetLisSampletype2(beginDate, endDate, groupId, applyUnitId, patType, strDept);
                DataTable dtType = svc.GetBysswSampletype(beginDate, endDate, groupId, applyUnitId, patType, strDept);

                if (dtType != null && dtType.Rows.Count > 0)
                {
                    dtData.Columns.Add("科室\\标本类型", Type.GetType("System.String"));

                    foreach (DataRow dr in dtType.Rows)
                    {
                        dtData.Columns.Add(dr["sampletype_vchr"].ToString().Trim(), Type.GetType("System.String"));
                    }

                    dtData.Columns.Add("合计", Type.GetType("System.String"));
                    dtData.Columns.Add("所占百分比", Type.GetType("System.String"));
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        string deptCode = dr["code_vchr"].ToString();
                        string deptName = dr["deptname_vchr"].ToString();
                        string sampletype = dr["sampletype_vchr"].ToString().Trim();

                        int ksFlg = 0;

                        for (int i = 0; i < dtData.Rows.Count; i++)
                        {
                            if (dtData.Rows[i][0].ToString() == deptName)
                            {
                                if (dr["sampletype_vchr"] != DBNull.Value)
                                {
                                    for (int j = 0; j < dtData.Columns.Count; j++)
                                    {
                                        if (dtData.Columns[j].ToString() == sampletype)
                                        {
                                            if (dtData.Rows[i][j] != DBNull.Value)
                                                dtData.Rows[i][j] = Convert.ToDecimal(dtData.Rows[i][j]) + 1;
                                            else
                                                dtData.Rows[i][j] = 1;

                                            dtData.Rows[i]["合计"] = Convert.ToDecimal(dtData.Rows[i]["合计"]) + 1;
                                            totoal++;
                                        }
                                    }
                                }

                                ksFlg = 1;
                            }
                        }

                        if (ksFlg == 0)
                        {
                            DataRow newRow;
                            newRow = dtData.NewRow();
                            newRow["科室\\标本类型"] = deptName;

                            for (int j = 0; j < dtData.Columns.Count; j++)
                            {
                                if (dtData.Columns[j].ToString() == sampletype)
                                {
                                    newRow[j] = 1;
                                }
                            }

                            newRow["合计"] = 1;
                            newRow["所占百分比"] = "100%";
                            totoal++;
                            dtData.Rows.Add(newRow);
                        }
                    }
                }

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    DataRow newRow;
                    newRow = dtData.NewRow();
                    newRow["科室\\标本类型"] = "合计";
                    newRow["合计"] = totoal;
                    dtData.Rows.Add(newRow);

                    for (int j = 1; j < dtData.Columns.Count-2; j++)
                    {
                        decimal rowSum = 0;
                        for (int i = 0; i < dtData.Rows.Count-1; i++)
                        {
                            if (dtData.Rows[i][j] != DBNull.Value)
                                rowSum += Convert.ToDecimal(dtData.Rows[i][j]);

                            if (dtData.Rows[i]["合计"] != DBNull.Value )
                                dtData.Rows[i]["所占百分比"] = (Convert.ToDecimal(dtData.Rows[i]["合计"]) / Convert.ToDecimal(totoal)).ToString("0.00%");
                        }

                        dtData.Rows[dtData.Rows.Count - 1][j] = rowSum;
                    }
                }

                dgvData.DataSource = dtData;
            }
            finally
            {
                clsPublic.CloseAvi();
            }
            this.dwRep.Refresh();
        }
        #endregion

        #region calcSampleType
        /// <summary>
        /// calcSampleType
        /// </summary>
        /// <param name="vo"></param>
        /// <param name="sampeType"></param>
        private void calcSampleType(ref entitySample vo, string sampeType)
        {

            if (sampeType.Contains("穿刺液"))
                vo.CCY += 1;
            else if (sampeType.Contains("囊液"))
                vo.NANGY += 1;
            else if (sampeType.Contains("积液"))
                vo.JIY += 1;
            else if (sampeType.Contains("创面") && sampeType.Contains("分泌物"))
                vo.CMFMW += 1;
            else if (sampeType.Contains("创面"))
                vo.CM += 1;
            else if (sampeType.Contains("胆汁"))
                vo.DC += 1;
            else if (sampeType.Contains("导管尖"))
                vo.DGJ += 1;
            else if (sampeType.Contains("粪便"))
                vo.FB += 1;
            else if (sampeType.Contains("腹水"))
                vo.FS += 1;
            else if (sampeType.Contains("宫颈分泌物"))
                vo.GJFMW += 1;
            else if (sampeType.Contains("坏死") && sampeType.Contains("组织"))
                vo.HSZZ += 1;
            else if (sampeType.Contains("口腔"))
                vo.KOU += 1;
            else if (sampeType.Contains("阑尾组织"))
                vo.LWZZ += 1;
            else if (sampeType.Contains("脑脊液"))
                vo.NJY += 1;
            else if (sampeType.Contains("尿") && sampeType.Contains("管"))
                vo.NGT += 1;
            else if (sampeType.Contains("脓液"))
                vo.NY += 1;
            else if (sampeType.Contains("前列腺"))
                vo.QLXY += 1;
            else if (sampeType.Contains("切口") && sampeType.Contains("渗"))
                vo.QKSCY += 1;
            else if (sampeType.Contains("全血"))
                vo.QX += 1;
            else if (sampeType.Contains("乳"))
                vo.RC += 1;
            else if (sampeType.Contains("褥疮分泌物"))
                vo.RCFMW += 1;
            else if (sampeType.Contains("伤口") && (sampeType.Contains("分泌物") || sampeType.Contains("拭子")))
                vo.SKSZ += 1;
            else if (sampeType.Contains("伤口组织"))
                vo.SKZZ += 1;
            else if (sampeType.Contains("伤口渗血"))
                vo.SKSX += 1;
            else if (sampeType.Contains("静脉") && sampeType.Contains("管"))
                vo.SJMDG += 1;
            else if (sampeType.Contains("痰"))
                vo.TAN += 1;
            else if (sampeType.Contains("胃") && sampeType.Contains("管"))
                vo.WGYLW += 1;
            else if (sampeType.Contains("胸") && sampeType.Contains("水"))
                vo.XS += 1;
            else if (sampeType.Contains("咽拭子"))
                vo.YSZ1 += 1;
            else if (sampeType.Contains("眼") && sampeType.Contains("拭子"))
                vo.YSZ2 += 1;
            else if (sampeType.Contains("咽") && sampeType.Contains("分泌物"))
                vo.YFMW += 1;
            else if (sampeType.Contains("阴道") || sampeType.Contains("白带") || sampeType.Contains("阴道液体"))
                vo.YDFMW += 1;
            else if (sampeType.Contains("引流物"))
                vo.YLWG += 1;
            else if (sampeType.Contains("羊水"))
                vo.YS += 1;
            else if (sampeType.Contains("尿"))
                vo.ZDNY += 1;
            else if (sampeType.Contains("分泌物"))
                vo.FMW += 1;

            vo.HJ += 1;
        }
        #endregion

        #region btnExport_Click
        /// <summary>
        /// btnExport_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            //if (this.dwRep.RowCount > 0)
            //{
            //    clsVolDatawindowToExcel[] volExcel = new clsVolDatawindowToExcel[2];

            //    volExcel[0] = new clsVolDatawindowToExcel(1);
            //    volExcel[0].m_rowheight[0] = 20;
            //    volExcel[0].m_title_text[0] = this.dwRep.Describe("t_title.text");
            //    volExcel[0].m_HorizontalAlignment[0] = "0";
            //    volExcel[0].m_firstcommn[0] = "A1";
            //    volExcel[0].m_endcommn[0] = "ALL";

            //    volExcel[1] = new clsVolDatawindowToExcel(1);
            //    volExcel[1].m_rowheight[0] = 20;
            //    volExcel[1].m_title_text[0] = this.dwRep.Describe("t_date.text");
            //    volExcel[1].m_HorizontalAlignment[0] = "L";
            //    volExcel[1].m_firstcommn[0] = "B1";
            //    volExcel[1].m_endcommn[0] = "ALL";

            //    clsPublic.ExportDataWindow(this.dwRep, volExcel);
            //}
            m_mthExportToExcel();
        }
        #endregion

        #region 导出EXCEL
        /// <summary>
        /// 
        /// </summary>
        public void m_mthExportToExcel()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出Excel文件到";
            string dteStart = this.dteRq1.Value.ToString("yyyy-MM-dd HH:mm");
            string dteEnd = this.dteRq2.Value.ToString("yyyy-MM-dd HH:mm");
            string applyUnitName = string.Empty;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream = saveFileDialog.OpenFile();
                StreamWriter streamWriter = new StreamWriter(stream, Encoding.GetEncoding("gb2312"));
                string text = "";

                try
                {
                    for (int i = 0; i < this.dgvData.ColumnCount / 2; i++)
                    {
                        if (this.dgvData.Columns[i].Visible)
                        {
                            if (i > 0)
                            {
                                text += "\t";
                            }
                        }
                    }

                    text += "临床病原微生物标本送检情况";
                    streamWriter.WriteLine(text);
                    text = dteStart + "~" + dteEnd;
                    streamWriter.WriteLine(text);
                    text = "";

                    for (int i = 0; i < this.dgvData.ColumnCount; i++)
                    {
                        if (dgvData.Columns[i].Visible)
                        {
                            if (i > 0)
                            {
                                text += "\t";
                            }
                            text += dgvData.Columns[i].HeaderText.Replace("\n", "");
                        }
                    }
                    streamWriter.WriteLine(text);
                    for (int i = 0; i < dgvData.Rows.Count; i++)
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        for (int j = 0; j < dgvData.Columns.Count; j++)
                        {
                            if (dgvData.Columns[j].Visible)
                            {
                                if (j > 0)
                                {
                                    stringBuilder.Append("\t");
                                }
                                stringBuilder.Append((dgvData.Rows[i].Cells[j].Value == null) ? "" : dgvData.Rows[i].Cells[j].Value.ToString());
                            }
                        }
                        streamWriter.WriteLine(stringBuilder);
                    }
                    MessageBox.Show("导出成功！", "临床病原微生物标本送检情况", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    streamWriter.Close();
                    stream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    streamWriter.Close();
                    stream.Close();
                }
            }
        }
        #endregion

        #region btnExite_Click
        /// <summary>
        /// btnExite_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExite_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region txtSearchName_TextChanged
        /// <summary>
        /// txtSearchName_TextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            DataTable dtbResult;
            string strTempName = string.Empty;
            string strGroupId = string.Empty;
            strTempName = this.txtSearchName.Text.Trim();
            string groupId = string.Empty;

            foreach (KeyValuePair<string, string> kvp in dicGroup)
            {
                if (kvp.Value.Equals(this.cbxGroup.Text))
                {
                    strGroupId = kvp.Key;
                }
            }
            clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
            long lngRes = svc.GetCheckItemByNameCpy(strTempName, strGroupId, out dtbResult);

            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                this.dgvItem.DataSource = dtbResult;
            }
        }
        #endregion

        #region dgvItem_CellDoubleClick
        /// <summary>
        /// dgvItem_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvItem.CurrentRow != null)
            {
                {
                    object[] value = new object[dgvItem.Columns.Count];
                    for (int i = 0; i < dgvItem.Columns.Count; i++)
                    {
                        value[i] = dgvItem.CurrentRow.Cells[i].Value;
                    }

                    dgvCheckItem.Rows.Add(value);
                }
            }

            //this.tabContorl.Visible = false;
        }
        #endregion

        #region btnTabClose_Click
        /// <summary>
        /// btnTabClose_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTabClose_Click(object sender, EventArgs e)
        {
            this.tabContorl.Visible = false;
        }
        #endregion

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.dwRep.Visible = false;
            this.Query2();
        }

        private void btnByDept_Click(object sender, EventArgs e)
        {
            frmByDept frmAidChooseDept = new frmByDept();
            if (frmAidChooseDept.ShowDialog() == DialogResult.OK)
            {
                this.DeptIdArr = frmAidChooseDept.DeptIDArr;
            }
        }

        private void cbxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tabContorl.Visible = true;
            this.tabContorl.SelectedTab.Text = "选择检验项目";
            this.m_mthListCheckItem();
        }

        private void cbxGroup_MouseDown(object sender, MouseEventArgs e)
        {
            this.tabContorl.Visible = true;
            this.tabContorl.SelectedTab.Text = "选择检验项目";
            this.m_mthListCheckItem();
        }

        #region 列出所有检验项目
        /// <summary>
        /// 列出所有检验项目
        /// </summary>
        public void m_mthListCheckItem()
        {
            DataTable dtbResult;
            string groupId = string.Empty;
            foreach (KeyValuePair<string, string> kvp in dicGroup)
            {
                if (kvp.Value.Equals(this.cbxGroup.Text))
                {
                    groupId = kvp.Key;
                }
            }

            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                 svc.GetAllCheckItemCpy(out dtbResult, groupId);
            }

            if (dtbResult.Rows.Count > 0)
            {
                this.dgvItem.DataSource = dtbResult;
            }
        }
        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.dgvCheckItem.Rows.Clear();
        }
    }
}
