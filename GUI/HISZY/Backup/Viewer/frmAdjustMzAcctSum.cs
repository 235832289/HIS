using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 调整门诊记帐病人核算分类金额
    /// </summary>
    public partial class frmAdjustMzAcctSum : Form
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmAdjustMzAcctSum()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否开始调整？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            Thread.Sleep(2000);

            try
            {
                this.Cursor = Cursors.WaitCursor;

                string BeginDate = this.dteBegin.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string EndDate = this.dteEnd.Value.ToString("yyyy-MM-dd") + " 23:59:59";

                string tmp = "进度:   ";
                DataTable dt;

                clsDcl_Charge objSvc = new clsDcl_Charge();

                long l = objSvc.m_lngMzGetAcctRecipeID(BeginDate, EndDate, out dt);
                if (l > 0)
                {
                    this.lblProcess.Text = tmp + "0 / " + dt.Rows.Count.ToString();

                    DataRow dr;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dr = dt.Rows[i];

                        if (clsPublic.ConvertObjToDecimal(dr["nums"]) > 1)
                        {
                            continue;
                        }

                        string RecipeID = dr["outpatrecipeid_chr"].ToString();
                        decimal SbSum = clsPublic.ConvertObjToDecimal(dr["sbsum_mny"]);

                        DataTable dtSeq;
                        string SeqIDFirst = "";

                        l = objSvc.m_lngMzGetSeqIDList(RecipeID, out dtSeq);
                        if (l > 0 && dtSeq.Rows.Count > 0)
                        {
                            SeqIDFirst = dtSeq.Rows[0]["seqid_chr"].ToString();
                        }
                        else
                        {
                            continue;
                        }

                        DataTable dtChargeCat;
                        l = objSvc.m_lngMzGetChargeCat(SeqIDFirst, out dtChargeCat);
                        if (l > 0 && dtChargeCat.Rows.Count > 0)
                        {
                            ArrayList objChargeCat = new ArrayList();
                            Hashtable hasChargeCat = new Hashtable();
                            for (int j = 0; j < dtChargeCat.Rows.Count; j++)
                            {
                                objChargeCat.Add(dtChargeCat.Rows[j]["itemcatid_chr"].ToString());
                                hasChargeCat.Add(dtChargeCat.Rows[j]["itemcatid_chr"].ToString(), "0");
                            }

                            DataTable dtRecipeCat;
                            l = objSvc.m_lngMzGetRecipeCat(RecipeID, out dtRecipeCat);
                            if (l > 0 && dtRecipeCat.Rows.Count > 0)
                            {
                                ArrayList objRecipeCat = new ArrayList();
                                Hashtable hasRecipeCat = new Hashtable();
                                for (int k = 0; k < dtRecipeCat.Rows.Count; k++)
                                {
                                    objRecipeCat.Add(dtRecipeCat.Rows[k]["itemopcalctype_chr"].ToString());
                                    hasRecipeCat.Add(dtRecipeCat.Rows[k]["itemopcalctype_chr"].ToString(), "0");
                                }

                                decimal totalsum = 0;
                                for (int k = 0; k < dtRecipeCat.Rows.Count; k++)
                                {
                                    string catid = dtRecipeCat.Rows[k]["itemopcalctype_chr"].ToString();
                                    decimal catsum = clsPublic.ConvertObjToDecimal(dtRecipeCat.Rows[k]["catsum"]);

                                    hasRecipeCat[catid] = catsum.ToString();

                                    totalsum += catsum;

                                    if (totalsum > SbSum)
                                    {
                                        hasRecipeCat[catid] = Convert.ToString(catsum - (totalsum - SbSum));
                                        break;
                                    }

                                    if (k == dtRecipeCat.Rows.Count - 1)
                                    {
                                        if (totalsum < SbSum)
                                        {
                                            hasRecipeCat[catid] = Convert.ToString(catsum + (SbSum - totalsum));
                                        }
                                    }
                                }

                                for (int k = 0; k < objRecipeCat.Count; k++)
                                {
                                    string catid = objRecipeCat[k].ToString();

                                    if (hasChargeCat.ContainsKey(catid) && hasRecipeCat.ContainsKey(catid))
                                    {
                                        hasChargeCat[catid] = hasRecipeCat[catid];
                                        hasRecipeCat.Remove(catid);
                                    }
                                }

                                if (hasRecipeCat.Count > 0)
                                {
                                    for (int l3 = 0; l3 < dtRecipeCat.Rows.Count; l3++)
                                    {
                                        string catid = dtRecipeCat.Rows[l3]["itemopcalctype_chr"].ToString();

                                        if (hasRecipeCat.ContainsKey(catid))
                                        {
                                            decimal val = clsPublic.ConvertObjToDecimal(dtRecipeCat.Rows[l3]["totalsum"]);

                                            for (int l4 = 0; l4 < dtChargeCat.Rows.Count; l4++)
                                            {
                                                decimal val1 = clsPublic.ConvertObjToDecimal(dtChargeCat.Rows[l4]["tolfee_mny"]);
                                                string catid1 = dtChargeCat.Rows[l4]["itemcatid_chr"].ToString();

                                                if (clsPublic.ConvertObjToDecimal(hasChargeCat[catid1]) == 0 && val == val1)
                                                {
                                                    hasChargeCat[catid1] = hasRecipeCat[catid];
                                                    hasRecipeCat.Remove(catid);
                                                    break;
                                                }
                                            }
                                        }
                                    }                                   
                                }

                                if (hasRecipeCat.Count > 0)
                                {
                                    ArrayList obj = new ArrayList();
                                    obj.AddRange(hasRecipeCat.Keys);

                                    decimal d = 0;
                                    for (int l1 = 0; l1 < obj.Count; l1++)
                                    {
                                        d += clsPublic.ConvertObjToDecimal(hasRecipeCat[obj[l1].ToString()]);
                                    }

                                    hasChargeCat[objChargeCat[objChargeCat.Count - 1]] = Convert.ToString(clsPublic.ConvertObjToDecimal(hasChargeCat[objChargeCat[objChargeCat.Count - 1]]) + d);
                                }

                                ArrayList CatIDArr = new ArrayList();
                                ArrayList CatSumArr = new ArrayList();

                                CatIDArr.AddRange(hasChargeCat.Keys);
                                CatSumArr.AddRange(hasChargeCat.Values);

                                for (int l2 = 0; l2 < dtSeq.Rows.Count; l2++)
                                {
                                    l = objSvc.m_lngMzUpdateChargeCat(dtSeq.Rows[l2]["seqid_chr"].ToString(), CatIDArr, CatSumArr, dtSeq.Rows[l2]["status_int"].ToString());
                                }

                            }
                        }

                        Thread.Sleep(1000);
                        this.lblProcess.Text = tmp + Convert.ToString(i + 1) + " / " + dt.Rows.Count.ToString();

                    }
                }
            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message, "失败", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}