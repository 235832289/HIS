using System;
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
    /// 编辑数量UI
    /// </summary>
    public partial class frmAidEditAmount : Form
    {
        #region 变量
        /// <summary>
        /// 退款数组(成员: clsBihRefCharge_VO)
        /// </summary>
        internal ArrayList ChargeIDArr = new ArrayList();
        /// <summary>
        /// 项目数据源

        /// </summary>
        private DataTable dtItemSource;
        /// <summary>
        /// 诊疗项目数组
        /// </summary>
        private ArrayList DiagArr = new ArrayList();
        /// <summary>
        /// 诊疗项目HashTable
        /// </summary>
        private Hashtable hasDiag = new Hashtable();
        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        public frmAidEditAmount(DataTable p_dtItemSource, ArrayList p_DiagArr)
        {
            InitializeComponent();
            dtItemSource = p_dtItemSource;
            DiagArr = p_DiagArr;
        }

        private void frmAidEditAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frmAidEditAmount_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            for (int i = 0; i < DiagArr.Count; i++)
            {
                clsParmDiagItem_VO DiagItem_VO = DiagArr[i] as clsParmDiagItem_VO;
                hasDiag.Add(DiagItem_VO.PchargeID, DiagItem_VO.DiagName.Trim());
            }

            clsDcl_Charge objCharge = new clsDcl_Charge();
            DataTable dtNormal;
            DataTable dtRefundment;
            decimal decAmount = 0;
            long l = objCharge.m_lngGetFeeItemByActiveType(DiagArr, out dtNormal, out dtRefundment);
            if (l > 0)
            {
                for (int i = 0; i < dtNormal.Rows.Count; i++)
                {
                    DataRow drNormal = dtNormal.Rows[i];

                    string pchargeid = drNormal["pchargeid_chr"].ToString();

                    decimal decRef = 0;
                    for (int j = 0; j < dtRefundment.Rows.Count; j++)
                    {
                        DataRow drRef = dtRefundment.Rows[j];

                        if (pchargeid == drRef["pchargeidorg_chr"].ToString())
                        {
                            decRef += Math.Abs(clsPublic.ConvertObjToDecimal(drRef["amount_dec"]));
                        }
                    }

                    string[] sarr = new string[10];
                    sarr[0] = Convert.ToString(i + 1).ToString();
                    sarr[1] = hasDiag[pchargeid].ToString();
                    sarr[2] = drNormal["itemcode_vchr"].ToString();
                    sarr[3] = drNormal["chargeitemname_chr"].ToString().Trim();
                    sarr[4] = drNormal["amount_dec"].ToString();
                    sarr[5] = decRef.ToString();
                    sarr[6] = Convert.ToString(clsPublic.ConvertObjToDecimal(drNormal["amount_dec"]) - decRef);
                    sarr[7] = pchargeid;
                    sarr[8] = drNormal["unitprice_dec"].ToString();
                    decAmount = clsPublic.ConvertObjToDecimal(drNormal["amount_dec"].ToString());

                    if (decAmount > 0)
                        sarr[9] = drNormal["buyprice_dec"].ToString(); //(clsPublic.ConvertObjToDecimal(drNormal["totaldiffcostmoney_dec"].ToString()) / decAmount).ToString();//让利单价

                    this.dtItem.Rows.Add(sarr);
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //校验
            for (int i = 0; i < this.dtItem.Rows.Count; i++)
            {
                //退款数量

                decimal tksl = clsPublic.ConvertObjToDecimal(this.dtItem.Rows[i].Cells["coltksl"].Value);
                //可退数量
                decimal ktsl = clsPublic.ConvertObjToDecimal(this.dtItem.Rows[i].Cells["colkdsl"].Value) - clsPublic.ConvertObjToDecimal(this.dtItem.Rows[i].Cells["colytsl"].Value);

                if (ktsl == 0 || tksl <= 0)
                {
                    continue;
                }
                else if (tksl > ktsl)
                {
                    MessageBox.Show("第" + Convert.ToString(i + 1) + "行" + this.dtItem.Rows[i].Cells["colxmmc"].Value.ToString() + "退款数据大于可退数量,不允许退费.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                clsBihRefCharge_VO Ref_VO = new clsBihRefCharge_VO();
                Ref_VO.PChargeID = this.dtItem.Rows[i].Cells["colpid"].Value.ToString();
                Ref_VO.RefAmount = tksl;
                Ref_VO.RefPrice = clsPublic.ConvertObjToDecimal(this.dtItem.Rows[i].Cells["coldj"].Value);
                Ref_VO.m_decTotalDiffCost = Math.Abs(clsPublic.ConvertObjToDecimal(this.dtItem.Rows[i].Cells["colunitdiffprice"].Value) * tksl);
                // Ref_VO.m_decTotalOrgDiffCost = Math.Abs(clsPublic.ConvertObjToDecimal(this.dtItem.Rows[i].Cells["colunitdiffprice"].Value));
                Ref_VO.BuyPrice = clsPublic.ConvertObjToDecimal(this.dtItem.Rows[i].Cells["colunitdiffprice"].Value);
                if (tksl == ktsl)
                {
                    Ref_VO.m_blnIsAllRef = true;
                }
                ChargeIDArr.Add(Ref_VO);
            }

            if (ChargeIDArr.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请检查退款数量!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}