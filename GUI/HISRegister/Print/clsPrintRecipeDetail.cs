using System;
using System.Drawing;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsPrintRecipeDetail
    {
        public clsPrintRecipeDetail(System.Drawing.Printing.PrintPageEventArgs p_obj, clsOutpatientPrintRecipe_VO VO)
        {
            objDraw = p_obj;
            objFontTitle = new Font("SimSun", 16, FontStyle.Bold);
            objFontNormal = new Font("SimSun", 10);
            obj_VO = VO;
        }
        /// <summary>
        /// 画图对象
        /// </summary>
        private System.Drawing.Printing.PrintPageEventArgs objDraw;
        private clsOutpatientPrintRecipe_VO obj_VO;
        /// <summary>
        /// 标题字体
        /// </summary>
        Font objFontTitle;
        /// <summary>
        /// 正常字体
        /// </summary>
        Font objFontNormal;
        /// <summary>
        /// 左边距
        /// </summary>
        float fltLeftIndentProp = 0.07f;

        /// <summary>
        /// 行间隔
        /// </summary>
        private float fltRowHeight = 23F;
        /// <summary>
        /// 纵坐标
        /// </summary>
        private float Y = 46F;

        #region 打印标题
        /// <summary>
        /// 打印标题 
        /// </summary>
        /// <param name="p_blnDiffOn">是否打印药品让利列</param>
        private void m_mthPrintTitle(bool p_blnDiffOn)
        {
            //标题
            SizeF objFontSize = objDraw.Graphics.MeasureString(obj_VO.m_strHospitalName + "门诊收费明细", this.objFontTitle);
            float X = (this.objDraw.PageBounds.Width - objFontSize.Width) / 2;
            Y = this.objDraw.PageBounds.Height * 0.047f - (objFontSize.Height / 2);
            objDraw.Graphics.DrawString(obj_VO.m_strHospitalName + "门诊收费明细", objFontTitle, Brushes.Black, X, Y);
            Y += objFontSize.Height + 2;
            //画线
            float RX = X + objFontSize.Width;
            objFontSize = objDraw.Graphics.MeasureString("第", this.objFontNormal);
            fltRowHeight = objFontSize.Height;

            using (Pen p = new Pen(Color.Black, 1))
            {
                objDraw.Graphics.DrawLine(p, X, Y, RX, Y);
            }
            //就诊时间
            Y += this.fltRowHeight / 2;
            X = this.objDraw.PageBounds.Width * fltLeftIndentProp;
            objFontSize = objDraw.Graphics.MeasureString("就诊时间:", this.objFontNormal);
            objDraw.Graphics.DrawString("就诊时间:", objFontNormal, Brushes.Black, X, Y);
            X += objFontSize.Width + 2;
            objDraw.Graphics.DrawString(obj_VO.m_strPrintDate, objFontNormal, Brushes.Black, X, Y);
            //病人卡号
            X = this.objDraw.PageBounds.Width * 0.357f;
            objFontSize = objDraw.Graphics.MeasureString("病人卡号:", this.objFontNormal);
            objDraw.Graphics.DrawString("病人卡号:", objFontNormal, Brushes.Black, X, Y);
            X += objFontSize.Width - 2;
            objDraw.Graphics.DrawString(obj_VO.m_strCardID, objFontNormal, Brushes.Black, X, Y);
            //处方ID
            X = this.objDraw.PageBounds.Width * 0.64f;
            objFontSize = objDraw.Graphics.MeasureString("发票号码:", this.objFontNormal);
            objDraw.Graphics.DrawString("发票号码:", objFontNormal, Brushes.Black, X, Y);
            X += objFontSize.Width;
            objDraw.Graphics.DrawString(obj_VO.strInvoiceNO, objFontNormal, Brushes.Black, X, Y);
            //姓名
            X = this.objDraw.PageBounds.Width * fltLeftIndentProp;
            Y += this.fltRowHeight;
            objFontSize = objDraw.Graphics.MeasureString("病人姓名:", this.objFontNormal);
            objDraw.Graphics.DrawString("病人姓名:", objFontNormal, Brushes.Black, X, Y);
            X += objFontSize.Width + 2;
            objDraw.Graphics.DrawString(obj_VO.m_strPatientName, objFontNormal, Brushes.Black, X, Y);
            //收费员
            X = this.objDraw.PageBounds.Width * fltLeftIndentProp;
            objFontSize = objDraw.Graphics.MeasureString("收费员 :", this.objFontNormal);
            objDraw.Graphics.DrawString("收 费 员:", objFontNormal, Brushes.Black, X, Y + fltRowHeight);
            X += objFontSize.Width + 2;
            objDraw.Graphics.DrawString(obj_VO.strCheckOutName, objFontNormal, Brushes.Black, X, Y + fltRowHeight);
            //性别
            X = this.objDraw.PageBounds.Width * 0.357f;
            objFontSize = objDraw.Graphics.MeasureString("病人类型:", this.objFontNormal);
            objDraw.Graphics.DrawString("病人类型:", objFontNormal, Brushes.Black, X, Y);
            X += objFontSize.Width - 2;
            objDraw.Graphics.DrawString(obj_VO.m_strPatientType, objFontNormal, Brushes.Black, X, Y);
            //工作单位
            X = this.objDraw.PageBounds.Width * 0.357f;
            objFontSize = objDraw.Graphics.MeasureString("工作单位:", this.objFontNormal);
            objDraw.Graphics.DrawString("工作单位:", objFontNormal, Brushes.Black, X, Y + fltRowHeight);
            X += objFontSize.Width - 2;
            objDraw.Graphics.DrawString(obj_VO.m_strEmployer, objFontNormal, Brushes.Black, X, Y + fltRowHeight);
            //处方ID
            X = this.objDraw.PageBounds.Width * 0.64f;
            objFontSize = objDraw.Graphics.MeasureString("医疗证号:", this.objFontNormal);
            objDraw.Graphics.DrawString("医疗证号:", objFontNormal, Brushes.Black, X, Y);
            objDraw.Graphics.DrawString("开方医生:", objFontNormal, Brushes.Black, X, Y + fltRowHeight);
            X += objFontSize.Width + 2;
            objDraw.Graphics.DrawString(obj_VO.m_strINSURANCEID, objFontNormal, Brushes.Black, X, Y);
            objDraw.Graphics.DrawString(obj_VO.m_strDiagDrName, objFontNormal, Brushes.Black, X, Y + fltRowHeight);

            Y += this.fltRowHeight * 3;
            X = this.objDraw.PageBounds.Width * fltLeftIndentProp;

            float[] widthflaArr ={ 0.34f, 0.45f, 0.65f, 0.73f, 0.81f, 0.89f };
            if (p_blnDiffOn)
                widthflaArr = new float[] { 0.30f, 0.43f, 0.55f, 0.6f, 0.65f, 0.9f, 0.71f, 0.8f };//倒数第三个为最后一项宽
            //项目分类名称
            //名称
            objDraw.Graphics.DrawString("项目名称", objFontNormal, Brushes.Black, X, Y);
            //规格
            X = this.objDraw.PageBounds.Width * widthflaArr[0];
            objDraw.Graphics.DrawString("规格", objFontNormal, Brushes.Black, X, Y);
            //产地
            X = this.objDraw.PageBounds.Width * widthflaArr[1];
            objDraw.Graphics.DrawString("产地", objFontNormal, Brushes.Black, X, Y);
            //单位
            X = this.objDraw.PageBounds.Width * widthflaArr[2];
            objDraw.Graphics.DrawString("单位", objFontNormal, Brushes.Black, X, Y);
            //总用量
            X = this.objDraw.PageBounds.Width * widthflaArr[3];
            objDraw.Graphics.DrawString("单价", objFontNormal, Brushes.Black, X, Y);
            //单价
            X = this.objDraw.PageBounds.Width * widthflaArr[4];
            objDraw.Graphics.DrawString("数量", objFontNormal, Brushes.Black, X, Y);
            if (p_blnDiffOn)
            {
                //让利金额
                X = this.objDraw.PageBounds.Width * widthflaArr[6];
                objDraw.Graphics.DrawString("药品已让利", objFontNormal, Brushes.Black, X, Y);
                //实付金额
                X = this.objDraw.PageBounds.Width * widthflaArr[7];
                objDraw.Graphics.DrawString("实付金额", objFontNormal, Brushes.Black, X, Y);
            }
            //总价
            X = this.objDraw.PageBounds.Width * widthflaArr[5];
            objDraw.Graphics.DrawString("总金额", objFontNormal, Brushes.Black, X, Y);

            Y += this.fltRowHeight * 2;

        }
        #endregion
        #region 打印内容
        /// <summary>
        /// 项目名称最大长度
        /// </summary>
        private int intMaxLength = 5;
        /// <summary>
        /// 打印内容 
        /// </summary>
        /// <param name="currRows">行数</param>
        /// <param name="p_blnDiffOn">是否打印让利列</param>
        private void m_mthPrintText(ref int currRows, bool p_blnDiffOn)
        {
            Y += 5;
            float X = this.objDraw.PageBounds.Width * fltLeftIndentProp;
            //项目最大长度
            SizeF size = objDraw.Graphics.MeasureString("样", objFontNormal);
            float ItemNameMaxLength = this.objDraw.PageBounds.Width * 0.30f;
            intMaxLength = (int)Math.Floor(ItemNameMaxLength / size.Width);
            StringFormat objSF = new StringFormat();
            objSF.Alignment = StringAlignment.Far;
            float[] widthflaArr ={ 0.34f, 0.45f, 0.655f, 0.78f, 0.84f, 0.94f };
            if (p_blnDiffOn)
                widthflaArr = new float[] { 0.30f, 0.43f, 0.56f, 0.65f, 0.7f, 0.94f, 0.77f, 0.88f };//倒数第三个为最后一项宽
            decimal decTotalDiffCost = 0;

            for (int i = currRows; i < this.obj_VO.objPRDArr.Count; i++)
            {
                clsOutpatientPrintRecipeDetail_VO objtemp = obj_VO.objPRDArr[i] as clsOutpatientPrintRecipeDetail_VO;
                X = this.objDraw.PageBounds.Width * fltLeftIndentProp;
                int temp = 1;
                if (objtemp.m_strChargeName.Length <= intMaxLength)
                {
                    objDraw.Graphics.DrawString(objtemp.m_strChargeName, objFontNormal, Brushes.Black, X, Y);
                }
                else
                {
                    objDraw.Graphics.DrawString(objtemp.m_strChargeName.Substring(0, intMaxLength), objFontNormal, Brushes.Black, X, Y);
                    objDraw.Graphics.DrawString(objtemp.m_strChargeName.Substring(intMaxLength, objtemp.m_strChargeName.Length - intMaxLength), objFontNormal, Brushes.Black, X, Y + fltRowHeight);
                    temp = 2;
                }
                //规格
                X = this.objDraw.PageBounds.Width * widthflaArr[0];
                objDraw.Graphics.DrawString(objtemp.m_strSpec, objFontNormal, Brushes.Black, X, Y);
                //产地
                X = this.objDraw.PageBounds.Width * widthflaArr[1];
                objDraw.Graphics.DrawString(objtemp.m_strFrequency, objFontNormal, Brushes.Black, X, Y);
                //单位
                X = this.objDraw.PageBounds.Width * widthflaArr[2];
                objDraw.Graphics.DrawString(objtemp.m_strUnit, objFontNormal, Brushes.Black, X, Y);

                //单价
                X = this.objDraw.PageBounds.Width * widthflaArr[3];
                objDraw.Graphics.DrawString(objtemp.m_strPrice, objFontNormal, Brushes.Black, X, Y, objSF);
                //数量
                X = this.objDraw.PageBounds.Width * widthflaArr[4];
                objDraw.Graphics.DrawString(objtemp.m_strCount, objFontNormal, Brushes.Black, X, Y, objSF);
                if (p_blnDiffOn)
                {
                    //让利金额
                    X = this.objDraw.PageBounds.Width * widthflaArr[6];
                    objDraw.Graphics.DrawString(objtemp.m_decTolDiffPrice.ToString(), objFontNormal, Brushes.Black, X, Y, objSF);
                    //实付金额
                    X = this.objDraw.PageBounds.Width * widthflaArr[7];
                    objDraw.Graphics.DrawString((clsPublic.ConvertObjToDecimal(objtemp.m_strSumPrice) - Math.Abs(objtemp.m_decTolDiffPrice)).ToString(), objFontNormal, Brushes.Black, X, Y, objSF);
                    //decTotalDiffCost += objtemp.m_decTolDiffPrice;
                }
                //总金额
                X = this.objDraw.PageBounds.Width * widthflaArr[5];
                objDraw.Graphics.DrawString(objtemp.m_strSumPrice, objFontNormal, Brushes.Black, X, Y, objSF);

                Y += this.fltRowHeight * temp + 3;
                if (Y + 2 * fltRowHeight > this.objDraw.PageBounds.Height)
                {
                    currRows = i + 1;
                    this.objDraw.HasMorePages = true;
                    return;
                }

            }

            for (int i = 0; i < this.obj_VO.objPRDArr.Count; i++)
            {
                clsOutpatientPrintRecipeDetail_VO objtemp1 = obj_VO.objPRDArr[i] as clsOutpatientPrintRecipeDetail_VO;
                if (p_blnDiffOn)
                {
                    decTotalDiffCost += objtemp1.m_decTolDiffPrice;
                }
            }

            decTotalDiffCost = Math.Abs(decTotalDiffCost) * -1;
            //处方总金额
            X = this.objDraw.PageBounds.Width * 0.94f;
            Y += 30;
            if (p_blnDiffOn)
            {
                obj_VO.m_strSelfPay = (decimal.Parse(obj_VO.m_strSelfPay)).ToString();
                obj_VO.m_strRecipePrice = (decimal.Parse(obj_VO.m_strRecipePrice) + decTotalDiffCost).ToString();
            }
            string strPrint = "记帐金额:" + obj_VO.m_strChargeUp + "   " + "自付金额:" + obj_VO.m_strSelfPay + "   " + "合计:   " + obj_VO.m_strRecipePrice;
            objDraw.Graphics.DrawString(strPrint, objFontNormal, Brushes.Black, X, Y, objSF);
            if (obj_VO.m_strChargeUp != null && obj_VO.m_strChargeUp.Trim() != "0.00" && obj_VO.m_strChargeUp != null && obj_VO.m_strChargeUp.Trim() != string.Empty && obj_VO.m_strChargeUp != null && obj_VO.m_strChargeUp.Trim() != string.Empty && obj_VO.m_strRegisterFee != null && obj_VO.m_strRegisterFee.Trim() != string.Empty && obj_VO.m_strTreatFee != null && obj_VO.m_strTreatFee.Trim() != string.Empty)
            {

                string m_strTemp = "(其中记账挂号费：" + obj_VO.m_strRegisterFee + " 记账诊金：" + obj_VO.m_strTreatFee + " 其他记账:" + ((decimal)(decimal.Parse(obj_VO.m_strChargeUp) - decimal.Parse(obj_VO.m_strRegisterFee) - decimal.Parse(obj_VO.m_strTreatFee))).ToString("0.00") + ")";
                Y += 25;
                objDraw.Graphics.DrawString(m_strTemp, objFontNormal, Brushes.Black, X, Y, objSF);
            }

        }
        #endregion
        #region 打印页脚
        private void m_mthPrintEnd()
        {

        }
        #endregion
        #region 开始打印

        public void m_mthBegionPrint(bool isOtherPage, ref int currRows, bool blnDiffOn)
        {
            if (isOtherPage == false)
                this.m_mthPrintTitle(blnDiffOn);
            this.m_mthPrintText(ref currRows, blnDiffOn);
            this.m_mthPrintEnd();
        }
        #endregion
    }
}
