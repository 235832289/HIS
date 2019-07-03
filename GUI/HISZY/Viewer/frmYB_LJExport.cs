using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 合作医疗数据导出UI
    /// </summary>
    public partial class frmYB_LJExport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 变量
        /// <summary>
        /// 合作医疗身份ID
        /// </summary>
        private string PayTypeID = "";
        /// <summary>
        /// 医院名称
        /// </summary>
        private string HospitaName = "";
        /// <summary>
        /// Domain
        /// </summary>
        private clsDcl_Report objSvc;
        #endregion

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public frmYB_LJExport()
        {
            InitializeComponent();
            objSvc = new clsDcl_Report();
        }
        #endregion

        private void frmYB_LJExport_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.Location.X, this.Location.Y - 100);
            this.PayTypeID = clsPublic.m_strConvertSingleQuoteMark(clsPublic.m_strGetSysparm("0032"), ";").Replace(";", ",");

            clsCtl_Report obj = new clsCtl_Report();
            this.HospitaName = obj.HospitalName;
            obj = null;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string BeginDate = this.dteBeginDate.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteEndDate.Value.ToString("yyyy-MM-dd");

            if (Convert.ToDateTime(BeginDate + " 00:00:01") > Convert.ToDateTime(EndDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }   

            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "请选择保存DBF文件的路径";
            fb.SelectedPath = @"c:\";
            if (fb.ShowDialog() == DialogResult.OK)
            {
                long l = 0;
                string Path = fb.SelectedPath;
                string FileName = "";
                DataRow dr = null;

                try
                {
                    string DSN = @"Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277;Dbq=" + Path;

                    clsPublic.PlayAvi("findFILE.avi", "正在生成DBF文件，请稍候...");

                    #region 基本资料
                    DataTable dtPat;
                    l = this.objSvc.m_lngHZYLPatientInfo(this.PayTypeID, BeginDate, EndDate, out dtPat);
                    if (l > 0)
                    {
                        ArrayList objPatArr = new ArrayList();

                        for (int i = 0; i < dtPat.Rows.Count; i++)
                        {
                            dr = dtPat.Rows[i];

                            clsSDHZYL_PatInfo_VO PatInfo_VO = new clsSDHZYL_PatInfo_VO();
                            PatInfo_VO.Mzh = dr["patientcardid_chr"].ToString().Trim();
                            PatInfo_VO.Sfz = dr["idcard_chr"].ToString().Trim();
                            PatInfo_VO.Dnh = dr["idno_vchr"].ToString().Trim();
                            PatInfo_VO.Cjbh = dr["vbcode_vchr"].ToString().Trim();
                            PatInfo_VO.Xm = dr["lastname_vchr"].ToString().Trim();
                            PatInfo_VO.Xb = dr["sex_chr"].ToString().Trim();
                            PatInfo_VO.Csrq = Convert.ToDateTime(dr["birth_dat"].ToString()).ToString("yyyy-MM-dd");
                            PatInfo_VO.Yymc = this.HospitaName;

                            objPatArr.Add(PatInfo_VO);
                        }

                        if (objPatArr.Count > 0)
                        {
                            FileName = Path + "\\grzl" + ".dbf";                            
                            if (File.Exists(FileName))
                            {
                                File.Delete(FileName);
                            }

                            l = this.objSvc.m_lngCreateHZYLDbf_PatInfo(DSN, "grzl", objPatArr);
                        }
                    }
                    #endregion

                    #region 处方合计
                    DataTable dtRecipeSum1;
                    DataTable dtRecipeSum2;
                    l = this.objSvc.m_lngHZYLRecipeSum1(this.PayTypeID, BeginDate, EndDate, out dtRecipeSum1);
                    l = this.objSvc.m_lngHZYLRecipeSum2(this.PayTypeID, BeginDate, EndDate, out dtRecipeSum2);
                    if (l > 0)
                    {
                        ArrayList objRecipeSumArr = new ArrayList();

                        for (int i = 0; i < dtRecipeSum1.Rows.Count; i++)
                        {
                            dr = dtRecipeSum1.Rows[i];

                            clsSDHZYL_RecipeSum_VO RecipeSum_VO = new clsSDHZYL_RecipeSum_VO();
                            RecipeSum_VO.Cfbh = dr["outpatrecipeid_chr"].ToString().Trim();
                            RecipeSum_VO.Yymc = this.HospitaName;
                            RecipeSum_VO.Cflx = dr["cflx"].ToString().Trim();
                            RecipeSum_VO.Cfsj = Convert.ToDateTime(dr["recorddate_dat"].ToString()).ToString("yyyy-MM-dd");
                            RecipeSum_VO.Mzh = dr["patientcardid_chr"].ToString().Trim();
                            RecipeSum_VO.Cfje = dr["zje"].ToString().Trim();
                            RecipeSum_VO.Yyts = dr["ts"].ToString().Trim();
                            RecipeSum_VO.Bxje = dr["mfje"].ToString().Trim();

                            objRecipeSumArr.Add(RecipeSum_VO);
                        }

                        for (int i = 0; i < dtRecipeSum2.Rows.Count; i++)
                        {
                            dr = dtRecipeSum2.Rows[i];

                            clsSDHZYL_RecipeSum_VO RecipeSum_VO = new clsSDHZYL_RecipeSum_VO();
                            RecipeSum_VO.Cfbh = dr["outpatrecipeid_chr"].ToString().Trim();
                            RecipeSum_VO.Yymc = this.HospitaName;
                            RecipeSum_VO.Cflx = dr["cflx"].ToString().Trim();
                            RecipeSum_VO.Cfsj = Convert.ToDateTime(dr["recorddate_dat"].ToString()).ToString("yyyy-MM-dd");
                            RecipeSum_VO.Mzh = dr["patientcardid_chr"].ToString().Trim();
                            RecipeSum_VO.Cfje = dr["zje"].ToString().Trim();
                            RecipeSum_VO.Yyts = dr["fs"].ToString().Trim();
                            RecipeSum_VO.Bxje = dr["mfje"].ToString().Trim();

                            objRecipeSumArr.Add(RecipeSum_VO);
                        }

                        if (objRecipeSumArr.Count > 0)
                        {
                            FileName = Path + "\\zycf" + ".dbf";
                            if (File.Exists(FileName))
                            {
                                File.Delete(FileName);
                            }

                            l = this.objSvc.m_lngCreateHZYLDbf_RecipeSum(DSN, "zycf", objRecipeSumArr);
                        }
                    }
                    #endregion

                    #region 处方明细
                    DataTable dtRecipeEntry1;
                    DataTable dtRecipeEntry2;
                    DataTable dtRecipeEntry3;
                    DataTable dtRecipeEntry4;
                    DataTable dtRecipeEntry5;
                    DataTable dtRecipeEntry6;
                    l = this.objSvc.m_lngHZYLRecipeEntry1(this.PayTypeID, BeginDate, EndDate, out dtRecipeEntry1);
                    l = this.objSvc.m_lngHZYLRecipeEntry2(this.PayTypeID, BeginDate, EndDate, out dtRecipeEntry2);
                    l = this.objSvc.m_lngHZYLRecipeEntry3(this.PayTypeID, BeginDate, EndDate, out dtRecipeEntry3);
                    l = this.objSvc.m_lngHZYLRecipeEntry4(this.PayTypeID, BeginDate, EndDate, out dtRecipeEntry4);
                    l = this.objSvc.m_lngHZYLRecipeEntry5(this.PayTypeID, BeginDate, EndDate, out dtRecipeEntry5);
                    l = this.objSvc.m_lngHZYLRecipeEntry6(this.PayTypeID, BeginDate, EndDate, out dtRecipeEntry6);
                    if (l > 0)
                    {
                        ArrayList objRecipeEntryArr = new ArrayList();

                        for (int i = 0; i < dtRecipeEntry1.Rows.Count; i++)
                        {
                            dr = dtRecipeEntry1.Rows[i];

                            clsSDHZYL_RecipeEntry_VO RecipeEntry_VO = new clsSDHZYL_RecipeEntry_VO();
                            RecipeEntry_VO.Cfbh = dr["outpatrecipeid_chr"].ToString().Trim();
                            RecipeEntry_VO.Mzh = dr["patientcardid_chr"].ToString().Trim();
                            RecipeEntry_VO.Yymc = this.HospitaName;
                            RecipeEntry_VO.Cfsj = Convert.ToDateTime(dr["recorddate_dat"].ToString()).ToString("yyyy-MM-dd");
                            RecipeEntry_VO.Xmbh = dr["itemcode_vchr"].ToString().Trim();
                            RecipeEntry_VO.Sbbh = dr["insuranceid_chr"].ToString().Trim();
                            RecipeEntry_VO.Xmmc = dr["itemname_vchr"].ToString().Trim();
                            RecipeEntry_VO.Sffl = dr["typename_vchr"].ToString().Trim();
                            RecipeEntry_VO.Xmjg = dr["dj"].ToString().Trim();
                            RecipeEntry_VO.Xmsl = dr["sl"].ToString().Trim();
                            RecipeEntry_VO.Xmje = dr["je"].ToString().Trim();
                            RecipeEntry_VO.Cflx = dr["cflx"].ToString().Trim();

                            if (dr["itemspec_vchr"].ToString().Trim().StartsWith("★"))
                            {
                                RecipeEntry_VO.Mfbz = "Y";
                            }
                            else
                            {
                                RecipeEntry_VO.Mfbz = "N";
                            }

                            objRecipeEntryArr.Add(RecipeEntry_VO);
                        }

                        for (int i = 0; i < dtRecipeEntry2.Rows.Count; i++)
                        {
                            dr = dtRecipeEntry2.Rows[i];

                            clsSDHZYL_RecipeEntry_VO RecipeEntry_VO = new clsSDHZYL_RecipeEntry_VO();
                            RecipeEntry_VO.Cfbh = dr["outpatrecipeid_chr"].ToString().Trim();
                            RecipeEntry_VO.Mzh = dr["patientcardid_chr"].ToString().Trim();
                            RecipeEntry_VO.Yymc = this.HospitaName;
                            RecipeEntry_VO.Cfsj = Convert.ToDateTime(dr["recorddate_dat"].ToString()).ToString("yyyy-MM-dd");
                            RecipeEntry_VO.Xmbh = dr["itemcode_vchr"].ToString().Trim();
                            RecipeEntry_VO.Sbbh = dr["insuranceid_chr"].ToString().Trim();
                            RecipeEntry_VO.Xmmc = dr["itemname_vchr"].ToString().Trim();
                            RecipeEntry_VO.Sffl = dr["typename_vchr"].ToString().Trim();
                            RecipeEntry_VO.Xmjg = dr["dj"].ToString().Trim();
                            RecipeEntry_VO.Xmsl = dr["sl"].ToString().Trim();
                            RecipeEntry_VO.Xmje = dr["je"].ToString().Trim();
                            RecipeEntry_VO.Cflx = dr["cflx"].ToString().Trim();
                            RecipeEntry_VO.Mfbz = "";

                            objRecipeEntryArr.Add(RecipeEntry_VO);
                        }

                        for (int i = 0; i < dtRecipeEntry3.Rows.Count; i++)
                        {
                            dr = dtRecipeEntry3.Rows[i];

                            clsSDHZYL_RecipeEntry_VO RecipeEntry_VO = new clsSDHZYL_RecipeEntry_VO();
                            RecipeEntry_VO.Cfbh = dr["outpatrecipeid_chr"].ToString().Trim();
                            RecipeEntry_VO.Mzh = dr["patientcardid_chr"].ToString().Trim();
                            RecipeEntry_VO.Yymc = this.HospitaName;
                            RecipeEntry_VO.Cfsj = Convert.ToDateTime(dr["recorddate_dat"].ToString()).ToString("yyyy-MM-dd");
                            RecipeEntry_VO.Xmbh = dr["itemcode_vchr"].ToString().Trim();
                            RecipeEntry_VO.Sbbh = dr["insuranceid_chr"].ToString().Trim();
                            RecipeEntry_VO.Xmmc = dr["itemname_vchr"].ToString().Trim();
                            RecipeEntry_VO.Sffl = dr["typename_vchr"].ToString().Trim();
                            RecipeEntry_VO.Xmjg = dr["dj"].ToString().Trim();
                            RecipeEntry_VO.Xmsl = dr["sl"].ToString().Trim();
                            RecipeEntry_VO.Xmje = dr["je"].ToString().Trim();
                            RecipeEntry_VO.Cflx = dr["cflx"].ToString().Trim();

                            if (dr["itemspec_vchr"].ToString().Trim().StartsWith("★"))
                            {
                                RecipeEntry_VO.Mfbz = "Y";
                            }
                            else
                            {
                                RecipeEntry_VO.Mfbz = "N";
                            }

                            objRecipeEntryArr.Add(RecipeEntry_VO);
                        }

                        for (int i = 0; i < dtRecipeEntry4.Rows.Count; i++)
                        {
                            dr = dtRecipeEntry4.Rows[i];

                            clsSDHZYL_RecipeEntry_VO RecipeEntry_VO = new clsSDHZYL_RecipeEntry_VO();
                            RecipeEntry_VO.Cfbh = dr["outpatrecipeid_chr"].ToString().Trim();
                            RecipeEntry_VO.Mzh = dr["patientcardid_chr"].ToString().Trim();
                            RecipeEntry_VO.Yymc = this.HospitaName;
                            RecipeEntry_VO.Cfsj = Convert.ToDateTime(dr["recorddate_dat"].ToString()).ToString("yyyy-MM-dd");
                            RecipeEntry_VO.Xmbh = dr["itemcode_vchr"].ToString().Trim();
                            RecipeEntry_VO.Sbbh = dr["insuranceid_chr"].ToString().Trim();
                            RecipeEntry_VO.Xmmc = dr["itemname_vchr"].ToString().Trim();
                            RecipeEntry_VO.Sffl = dr["typename_vchr"].ToString().Trim();
                            RecipeEntry_VO.Xmjg = dr["dj"].ToString().Trim();
                            RecipeEntry_VO.Xmsl = dr["sl"].ToString().Trim();
                            RecipeEntry_VO.Xmje = dr["je"].ToString().Trim();
                            RecipeEntry_VO.Cflx = dr["cflx"].ToString().Trim();

                            if (dr["itemspec_vchr"].ToString().Trim().StartsWith("★"))
                            {
                                RecipeEntry_VO.Mfbz = "Y";
                            }
                            else
                            {
                                RecipeEntry_VO.Mfbz = "N";
                            }

                            objRecipeEntryArr.Add(RecipeEntry_VO);
                        }

                        for (int i = 0; i < dtRecipeEntry5.Rows.Count; i++)
                        {
                            dr = dtRecipeEntry5.Rows[i];

                            clsSDHZYL_RecipeEntry_VO RecipeEntry_VO = new clsSDHZYL_RecipeEntry_VO();
                            RecipeEntry_VO.Cfbh = dr["outpatrecipeid_chr"].ToString().Trim();
                            RecipeEntry_VO.Mzh = dr["patientcardid_chr"].ToString().Trim();
                            RecipeEntry_VO.Yymc = this.HospitaName;
                            RecipeEntry_VO.Cfsj = Convert.ToDateTime(dr["recorddate_dat"].ToString()).ToString("yyyy-MM-dd");
                            RecipeEntry_VO.Xmbh = dr["itemcode_vchr"].ToString().Trim();
                            RecipeEntry_VO.Sbbh = dr["insuranceid_chr"].ToString().Trim();
                            RecipeEntry_VO.Xmmc = dr["itemname_vchr"].ToString().Trim();
                            RecipeEntry_VO.Sffl = dr["typename_vchr"].ToString().Trim();
                            RecipeEntry_VO.Xmjg = dr["dj"].ToString().Trim();
                            RecipeEntry_VO.Xmsl = dr["sl"].ToString().Trim();
                            RecipeEntry_VO.Xmje = dr["je"].ToString().Trim();
                            RecipeEntry_VO.Cflx = dr["cflx"].ToString().Trim();

                            if (dr["itemspec_vchr"].ToString().Trim().StartsWith("★"))
                            {
                                RecipeEntry_VO.Mfbz = "Y";
                            }
                            else
                            {
                                RecipeEntry_VO.Mfbz = "N";
                            }

                            objRecipeEntryArr.Add(RecipeEntry_VO);
                        }

                        for (int i = 0; i < dtRecipeEntry6.Rows.Count; i++)
                        {
                            dr = dtRecipeEntry6.Rows[i];

                            clsSDHZYL_RecipeEntry_VO RecipeEntry_VO = new clsSDHZYL_RecipeEntry_VO();
                            RecipeEntry_VO.Cfbh = dr["outpatrecipeid_chr"].ToString().Trim();
                            RecipeEntry_VO.Mzh = dr["patientcardid_chr"].ToString().Trim();
                            RecipeEntry_VO.Yymc = this.HospitaName;
                            RecipeEntry_VO.Cfsj = Convert.ToDateTime(dr["recorddate_dat"].ToString()).ToString("yyyy-MM-dd");
                            RecipeEntry_VO.Xmbh = dr["itemcode_vchr"].ToString().Trim();
                            RecipeEntry_VO.Sbbh = dr["insuranceid_chr"].ToString().Trim();
                            RecipeEntry_VO.Xmmc = dr["itemname_vchr"].ToString().Trim();
                            RecipeEntry_VO.Sffl = dr["typename_vchr"].ToString().Trim();
                            RecipeEntry_VO.Xmjg = dr["dj"].ToString().Trim();
                            RecipeEntry_VO.Xmsl = dr["sl"].ToString().Trim();
                            RecipeEntry_VO.Xmje = dr["je"].ToString().Trim();
                            RecipeEntry_VO.Cflx = dr["cflx"].ToString().Trim();

                            if (dr["itemspec_vchr"].ToString().Trim().StartsWith("★"))
                            {
                                RecipeEntry_VO.Mfbz = "Y";
                            }
                            else
                            {
                                RecipeEntry_VO.Mfbz = "N";
                            }

                            objRecipeEntryArr.Add(RecipeEntry_VO);
                        }

                        if (objRecipeEntryArr.Count > 0)
                        {
                            FileName = Path + "\\cfzl" + ".dbf";
                            if (File.Exists(FileName))
                            {
                                File.Delete(FileName);
                            }

                            l = this.objSvc.m_lngCreateHZYLDbf_RecipeEntry(DSN, "cfzl", objRecipeEntryArr);
                        }
                    }
                    #endregion

                    clsPublic.CloseAvi();
                    MessageBox.Show("导出DBF文件成功！！！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception obj)
                {
                    clsPublic.CloseAvi();
                    MessageBox.Show("导出失败。 原因： " + obj.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }                
            }
        }


    }
}