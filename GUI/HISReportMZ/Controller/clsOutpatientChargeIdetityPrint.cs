using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
//using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.common;	//objectGenerator.dll
using com.digitalwave.iCare.ValueObject;

using System.Drawing;//画图需要引入

using System.Drawing.Printing; //打印需要引入


namespace com.digitalwave.iCare.gui.HIS.Reports
{
    #region 门诊收费按身份分类统计报表窗体控制类 ：created by weiling.huang  at 2005-9-16
    /// <summary>
    ///门诊收费按身份分类统计报表窗体控制类 ：created by weiling.huang  at 2005-9-16
    /// </summary>
    public class clsOutpatientChargeIdetityPrint : com.digitalwave.GUI_Base.clsController_Base	//GUI_Base.dll
    {
        #region 构造函数

        public clsOutpatientChargeIdetityPrint()
        {
            m_objDomainManage = new clsDomainOutpatientChargeIdetityPrint();
        }
        #endregion

        #region 变量
        /// <summary>
        /// DomainControl对象
        /// </summary>
        private clsDomainOutpatientChargeIdetityPrint m_objDomainManage = null;

        /// <summary>
        /// frm窗体对象
        /// </summary>
        private frmOutpatientChargeIdetityPrint m_objFrmViewer;

        /// <summary>
        /// Pen对象
        /// </summary>
        private Pen m_objPen = new Pen(Color.Black);
        /// <summary>
        /// 报表主体字体
        /// </summary>
        private Font m_objFont = new Font("宋体", 10);

        /// <summary>
        /// 报表名称
        /// </summary>
        private string m_strTitle = "门诊收费按身份分类统计报表";

        ///<summary>
        ///变量：存取用户查询到的结果数据

        ///</summary>
        private clsOutPatientTableInfo_VO[] m_objResultArr = null;

        ///<summary>
        ///变量：有效人次

        ///</summary>
        private int m_intPeople = 0; //有效人次
        ///<summary>
        ///变量：有效总合计

        ///</summary>
        private float m_fltTotal = 0;//有效总合计

        ///<summary>
        ///变量：有效自付合计

        ///</summary>
        private float m_fltSubTotal = 0;//有效自付合计
        ///<summary>
        ///变量：有效记帐合计

        ///</summary>
        private float m_fltJiTotal = 0;//有效记帐合计

        ///<summary>
        ///变量：退票人次

        ///</summary>
        private int m_intTuiPeople = 0; //退票人次

        ///<summary>
        ///变量：退票总合计

        ///</summary>
        private float m_fltTuiTotal = 0;//退票总合计

        ///<summary>
        ///变量：退票自付合计

        ///</summary>
        private float m_fltTuiSubTotal = 0;//退票自付合计

        ///<summary>
        ///变量：退票记帐合计

        ///</summary>
        private float m_fltTuiJiTotal = 0;//退票记帐合计


        ///<summary>
        ///变量：存取左边距 e.MarginBounds.Left
        ///</summary>
        private float fltLeftAlignWidth;

        ///<summary>
        ///变量：记录当前打印所在高度

        ///</summary>
        private float m_fltCurrentHeight = 0;

        ///<summary>
        ///变量：打印的当前页数
        ///</summary>
        private int m_intCurrentPageIndex = 0;

        ///<summary>
        ///变量：打印的总页数

        ///</summary>
        private int m_intPageTotal = 0;
        ///<summary>
        ///变量：记录打印到几条记录，也就是待打印的VO数组数据的下标

        ///</summary>
        private int m_intVoIndex = -1;

        private bool m_blnfirst = true;
        private int intPageRowCount = 0;
        #endregion

        #region 设置窗体对象，override Set_GUI_Apperance 实现
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            // TODO:  添加 Set_GUI_Apperance 实现
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            this.m_objFrmViewer = (frmOutpatientChargeIdetityPrint)frmMDI_Child_Base_in;
        }
        #endregion

        #region 窗体控件(日间控件,病人身份下拉框,收费员下拉框)的初始化 ：created by weiling.huang  at 2005-9-19
        /// <summary>
        /// 窗体控件(日间控件,病人身份下拉框,收费员下拉框)的初始化 ：created by weiling.huang  at 2005-9-19
        /// </summary>
        public void m_mthFrmInit()
        {
            //m_mthInitDataTimePicker();//初始化日间控件

            m_mthBindPatientTypeList();//初始化病人身份下拉框
            m_mthBindOperatorList();//初始化收费员列表框

        }
        #endregion

        #region 窗体日间控件的初始化 ：created by weiling.huang  at 2005-9-19
        /// <summary>
        /// 窗体日间控件的初始化 ：created by weiling.huang  at 2005-9-19
        /// </summary>
        private void m_mthInitDataTimePicker()
        {
            DateTime dtm = this.m_objDomainManage.m_dtmGetServerDate();
            this.m_objFrmViewer.m_dateTimePickerBegin.Value = Convert.ToDateTime(dtm.Year.ToString() + "-" + dtm.Month.ToString() + "-" + "01"); ;
            this.m_objFrmViewer.m_dateTimePickerEnd.Value = dtm;
        }
        #endregion

        #region 获得病人身份分类名称与ID列表，并加入Combox：created by weiling.huang  at 2005-9-19
        /// <summary>
        /// 获得病人身份分类名称与ID列表，并加入Combox：created by weiling.huang  at 2005-9-19
        /// </summary>
        private void m_mthBindPatientTypeList()
        {

            clsPType_VO[] objPriodItems;
            this.m_objDomainManage.m_mthGetPatientCatInfo(out objPriodItems); //获得病人身份分类名称与ID列表

            if (objPriodItems.Length > 0)
            {

                this.m_objFrmViewer.m_cboIdentity.Items.Insert(0, "全部类型");
                for (int i1 = 0; i1 < objPriodItems.Length; i1++)
                {
                    this.m_objFrmViewer.m_cboIdentity.Items.Insert(i1 + 1, objPriodItems[i1].m_strPAYTYPENAME_VCHR.Trim());
                }
                this.m_objFrmViewer.m_cboIdentity.Tag = objPriodItems;
                this.m_objFrmViewer.m_cboIdentity.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("没有数据!", "系统提示");
            }
        }
        #endregion

        #region 方法:获得收费员名称与ID列表，并加入Combox：created by weiling.huang  at 2005-9-19
        /// <summary>
        /// 方法:获得收费员名称与ID列表，并加入Combox：created by weiling.huang  at 2005-9-19
        /// </summary>
        private void m_mthBindOperatorList()
        {

            clsEChargeInfo_VO[] objEChargeInfoItemsArr;
            this.m_objDomainManage.m_mthGetChargeManInfo(out objEChargeInfoItemsArr); //获得名称与ID列表

            if (objEChargeInfoItemsArr.Length > 0)
            {

                this.m_objFrmViewer.m_cboOperator.Items.Insert(0, "全部");
                for (int i1 = 0; i1 < objEChargeInfoItemsArr.Length; i1++)
                {
                    this.m_objFrmViewer.m_cboOperator.Items.Insert(i1 + 1, objEChargeInfoItemsArr[i1].m_strLastname_vchr.Trim());
                }
                this.m_objFrmViewer.m_cboOperator.Tag = objEChargeInfoItemsArr;
                this.m_objFrmViewer.m_cboOperator.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("没有数据!", "系统提示");
            }
        }
        #endregion

        #region 方法：查询按钮事件触发方法,根据条件查询,并画出：created by weiling.huang  at 2005-9-19
        /// <summary>
        /// 方法：查询按钮事件触发方法,根据条件查询,并画出：created by weiling.huang  at 2005-9-19
        /// <summary>
        public void m_mthQuery()
        {
            string p_strPatientTypeId = null;
            string p_strEmployeeID = null;

            #region 取得所选择的病人类型ID
            if (this.m_objFrmViewer.m_cboIdentity.Items.Count > 0 && this.m_objFrmViewer.m_cboIdentity.SelectedIndex != -1)
            {
                int intIndex = this.m_objFrmViewer.m_cboIdentity.SelectedIndex;
                clsPType_VO[] objPType = this.m_objFrmViewer.m_cboIdentity.Tag as clsPType_VO[];
                if (intIndex == 0)
                {
                    p_strPatientTypeId = null; //标志：选择了全部

                }
                else
                {
                    p_strPatientTypeId = objPType[intIndex - 1].m_strPAYTYPEID_CHR.ToString();
                }
            }
            #endregion

            #region 取得所选择的收费员ID
            if (this.m_objFrmViewer.m_cboOperator.Items.Count > 0 && this.m_objFrmViewer.m_cboOperator.SelectedIndex != -1)
            {
                int intIndex = this.m_objFrmViewer.m_cboOperator.SelectedIndex;
                clsEChargeInfo_VO[] objOp = this.m_objFrmViewer.m_cboOperator.Tag as clsEChargeInfo_VO[];
                if (intIndex == 0)
                {
                    p_strEmployeeID = null; //标志：选择了全部

                }
                else
                {
                    p_strEmployeeID = objOp[intIndex - 1].m_strEmpid_chr.ToString();
                }
            }
            #endregion

            //根据用户所选择时间,病人身份和操作员名称获取发票的结帐信息,并存到对象m_objResultArr
            this.m_mthGetDataByTimeIndetityOp(out m_objResultArr, p_strPatientTypeId, p_strEmployeeID);

        }
        #endregion

        #region 方法：根据用户所选择时间,病人身份和操作员名称获取发票的结帐信息等：created by weiling.huang  at 2005-9-19
        /// <summary>
        /// 根据用户所选择时间,病人身份和操作员名称获取发票的结帐信息等
        /// </summary>
        /// <param name="p_objResultArr">输出数据</param>
        /// <param name="p_strdtmBegin">查询条件：就诊起始日期</param>
        /// <param name="p_strdtmEnd">查询条件：就诊终止日期</param>
        /// <param name="p_strPatientTypeId">查询条件：病人身份类型ID</param>
        /// <param name="p_strEmployeeID">查询条件：收费员ID</param>
        /// <returns></returns>
        public void m_mthGetDataByTimeIndetityOp(out clsOutPatientTableInfo_VO[] p_objResultArr, string p_strPatientTypeId, string p_strEmployeeID)
        {
            p_objResultArr = null;
            string strDateBegin = this.m_objFrmViewer.m_dateTimePickerBegin.Value.ToShortDateString();
            string strDateEnd = this.m_objFrmViewer.m_dateTimePickerEnd.Value.ToShortDateString();
            long lngRes = 0;

            lngRes = this.m_objDomainManage.m_lngGetDataByTimeIndetityOp(out p_objResultArr, strDateBegin, strDateEnd, p_strPatientTypeId, p_strEmployeeID);
            if (lngRes > 0)
            {

            }
            else
            {
                MessageBox.Show("获取数据出错！", "系统错误提示");
                return;
            }
        }
        #endregion

        #region  方法：触发打印

        public void m_mthQueryClick()
        {
            m_intCurrentPageIndex = 0;//初始化当前页为0
            m_intPageTotal = 0;//初始化页数为0
            m_intPeople = 0; //有效人次
            m_fltTotal = 0;//有效总合计

            m_fltSubTotal = 0;//有效自付合计
            m_fltJiTotal = 0;//有效记帐合计
            m_intTuiPeople = 0; //退票人次

            m_fltTuiTotal = 0;//退票总合计

            m_fltTuiSubTotal = 0;//退票自付合计

            m_fltTuiTotal = 0;//退票总合计

            m_fltTuiSubTotal = 0;//退票自付合计

            m_fltTuiJiTotal = 0;//退票记帐合计

            m_intVoIndex = -1;
            m_blnfirst = true;
            intPageRowCount = 0;
            this.m_objFrmViewer.m_printPreviewControl1.Document = this.m_objFrmViewer.m_printDocument1;
            this.m_objFrmViewer.m_printPreviewDialog1.Document = this.m_objFrmViewer.m_printDocument1;

        }
        #endregion

        #region  调用showprintdialog
        public void m_mthClick()
        {
            m_intCurrentPageIndex = 0;//初始化当前页为0
            m_intPageTotal = 0;//初始化页数为0
            m_intPeople = 0; //有效人次
            m_fltTotal = 0;//有效总合计

            m_fltSubTotal = 0;//有效自付合计
            m_fltJiTotal = 0;//有效记帐合计
            m_intTuiPeople = 0; //退票人次

            m_fltTuiTotal = 0;//退票总合计

            m_fltTuiSubTotal = 0;//退票自付合计

            m_fltTuiTotal = 0;//退票总合计

            m_fltTuiSubTotal = 0;//退票自付合计

            m_fltTuiJiTotal = 0;//退票记帐合计

            m_intVoIndex = -1;
            m_blnfirst = true;
            intPageRowCount = 0;
            this.m_objFrmViewer.m_printPreviewDialog1.Document = this.m_objFrmViewer.m_printDocument1;
            this.m_objFrmViewer.m_printPreviewDialog1.ShowDialog();

        }
        #endregion

        #region  打印每一页时触发：created by weiling.huang  at 2005-9-16
        /// <summary>
        /// 打印每一页时触发：created by weiling.huang  at 2005-9-16
        /// </summary>
        /// <param name="sender">触发对象</param>
        /// <param name="e">打印相关参数对象</param>
        public void m_printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            m_printDoc_Header(sender, e);//打印第一页页头

            m_printDoc_HeaderTitleAndBody(sender, e);//打印第一页表头与实体内容
        }
        #endregion

        #region  打印第一页页头：created by weiling.huang  at 2005-9-16
        /// <summary>
        /// 打印第一页页头：created by weiling.huang  at 2005-9-16
        /// </summary>
        /// <param name="sender">触发对象</param>
        /// <param name="e">打印相关参数对象</param>
        public void m_printDoc_Header(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e.Graphics.DrawRectangle(this.m_objPen,e.MarginBounds.X,e.MarginBounds.Y,e.MarginBounds.Width,e.MarginBounds.Height);

            //			this.GetData();
            string strPrint = "";
            if (this.m_intCurrentPageIndex == 0)
            {
                //画大标题
                SizeF objsize = e.Graphics.MeasureString(this.m_strTitle, new Font("宋体", 18));
                e.Graphics.DrawString(m_strTitle, new Font("宋体", 18), Brushes.Black, e.MarginBounds.Left + e.MarginBounds.Width / 2 - objsize.Width / 2, e.MarginBounds.Top + objsize.Height / 2);
                //结束

                fltLeftAlignWidth = e.MarginBounds.Left;//文字距离左边的位移

                //画统计日期行
                float fltHeight = e.MarginBounds.Top + +objsize.Height + 30;//此行的高度

                strPrint = " 统计日期：" + this.m_objFrmViewer.m_dateTimePickerBegin.Value.Date.ToShortDateString() + " 到 " + this.m_objFrmViewer.m_dateTimePickerEnd.Value.Date.ToShortDateString();
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltLeftAlignWidth, fltHeight);

                strPrint = " 病人身份：" + this.m_objFrmViewer.m_cboIdentity.Text.Trim();
                float fltLeft = fltLeftAlignWidth + float.Parse(e.MarginBounds.Width.ToString()) * (float)0.45;
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltLeft, fltHeight);

                fltLeft = fltLeftAlignWidth + float.Parse(e.MarginBounds.Width.ToString()) * (float)0.75;
                strPrint = " 收费员：" + this.m_objFrmViewer.m_cboOperator.Text.Trim();
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltLeft, fltHeight);
                //此行画完

                //画实入人次行
                fltHeight = fltHeight + 35;//此行的高度

                fltLeft = fltLeftAlignWidth;
                strPrint = " 实入人次：" + Convert.ToString(this.m_intPeople + this.m_intTuiPeople) + "次";
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltLeft, fltHeight);

                fltLeft = fltLeftAlignWidth + float.Parse(e.MarginBounds.Width.ToString()) * (float)0.25;
                strPrint = " 自付合计：" + Convert.ToString(this.m_fltSubTotal + this.m_fltTuiSubTotal);
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltLeft, fltHeight);

                fltLeft = fltLeftAlignWidth + float.Parse(e.MarginBounds.Width.ToString()) * (float)0.50;
                strPrint = " 记帐合计：" + Convert.ToString(this.m_fltJiTotal + this.m_fltTuiJiTotal);
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltLeft, fltHeight);

                fltLeft = fltLeftAlignWidth + float.Parse(e.MarginBounds.Width.ToString()) * (float)0.75;
                strPrint = " 总合计：" + Convert.ToString(this.m_fltTotal + this.m_fltTuiTotal);
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltLeft, fltHeight);
                //结束

                //画退票人次行
                objsize = e.Graphics.MeasureString("测试", this.m_objFont);
                fltHeight = fltHeight + objsize.Height;//此行的高度

                fltLeft = fltLeftAlignWidth;
                strPrint = " 退票人次：" + Convert.ToString(this.m_intTuiPeople) + "次";
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltLeft, fltHeight);

                fltLeft = fltLeftAlignWidth + float.Parse(e.MarginBounds.Width.ToString()) * (float)0.25;
                strPrint = " 自付合计：" + Convert.ToString(this.m_fltTuiSubTotal);
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltLeft, fltHeight);

                fltLeft = fltLeftAlignWidth + float.Parse(e.MarginBounds.Width.ToString()) * (float)0.50;
                strPrint = " 记帐合计：" + Convert.ToString(this.m_fltTuiJiTotal);
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltLeft, fltHeight);

                fltLeft = fltLeftAlignWidth + float.Parse(e.MarginBounds.Width.ToString()) * (float)0.75;
                strPrint = " 总合计：" + Convert.ToString(this.m_fltTuiTotal);
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltLeft, fltHeight);
                //结束

                //画有效人次行				
                fltHeight = fltHeight + objsize.Height;//此行的高度

                fltLeft = fltLeftAlignWidth;
                strPrint = " 有效人次：" + Convert.ToString(this.m_intPeople) + "次";
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltLeft, fltHeight);

                fltLeft = fltLeftAlignWidth + float.Parse(e.MarginBounds.Width.ToString()) * (float)0.25;
                strPrint = " 自付合计：" + Convert.ToString(this.m_fltSubTotal);
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltLeft, fltHeight);

                fltLeft = fltLeftAlignWidth + float.Parse(e.MarginBounds.Width.ToString()) * (float)0.50;
                strPrint = " 记帐合计：" + Convert.ToString(this.m_fltJiTotal);
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltLeft, fltHeight);

                fltLeft = fltLeftAlignWidth + float.Parse(e.MarginBounds.Width.ToString()) * (float)0.75;
                strPrint = " 总合计：" + Convert.ToString(this.m_fltTotal);
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltLeft, fltHeight);
                //结束

                //画打印时间行
                fltHeight = fltHeight + 35;//此行的高度

                fltLeft = fltLeftAlignWidth;
                strPrint = " 打印时间：" + this.m_objDomainManage.m_dtmGetServerDate().ToString();
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltLeft, fltHeight);

                fltLeft = fltLeftAlignWidth;
                strPrint = "金额单位：" + m_fltTotal.ToString() + "元";
                fltLeft = fltLeftAlignWidth + float.Parse(e.MarginBounds.Width.ToString()) * (float)0.77;
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltLeft, fltHeight);
                //结束

                m_fltCurrentHeight = fltHeight + objsize.Height;
            }
        }
        #endregion

        #region  打印列表头与实际内容：created by weiling.huang  at 2005-9-16
        /// <summary>
        /// 打印列表头与实际内容：created by weiling.huang  at 2005-9-16
        /// </summary>
        /// <param name="sender">触发对象</param>
        /// <param name="e">打印相关参数对象</param>
        public void m_printDoc_HeaderTitleAndBody(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region 设置打印列宽与每列的横坐标

            float fltFirstCol = e.MarginBounds.Width * (float)0.1; //第1列宽度

            float fltSeconCol = e.MarginBounds.Width * (float)0.15; //第2列宽度

            float fltthCol = e.MarginBounds.Width * (float)0.15; //第3列宽度

            float fltthirCol = e.MarginBounds.Width * (float)0.15; //第4列宽度

            float fltFiveCol = e.MarginBounds.Width * (float)0.1; //第5列宽度

            float fltSixCol = e.MarginBounds.Width * (float)0.1; //第6列宽度

            float fltSenCol = e.MarginBounds.Width * (float)0.1; //第7列宽度

            float fltNigCol = e.MarginBounds.Width * (float)0.15; //第8列宽度


            float fltFirstColLeft = e.MarginBounds.Left; //第1列Left坐际
            float fltSeconColLeft = fltFirstCol + fltFirstColLeft; //第2列Left坐际
            float fltthColLeft = fltSeconColLeft + fltSeconCol; //第3列Left坐际
            float fltthirColLeft = fltthColLeft + fltthCol; //第4列Left坐际
            float fltFiveColLeft = fltthirColLeft + fltthirCol; //第5列Left坐际
            float fltSixColLeft = fltFiveColLeft + fltFiveCol; //第6列Left坐际
            float fltSenColLeft = fltSixColLeft + fltSixCol; //第7列Left坐际
            float fltNigColLeft = fltSenColLeft + fltSenCol; //第8列Left坐际
            #endregion

            string strPrint = "";//要打印的字

            float fltZijiHeight = 4; //字与线间的位置高 ：间距

            SizeF objsize = e.Graphics.MeasureString("测试", this.m_objFont);
            float fltZiHeight = objsize.Height;// 字高
            float fltZiJiWide = 1;// 字与表格的左距离：间距

            float ftlRowHeight = fltZijiHeight + fltZiHeight;//行高

            StringFormat sf = new StringFormat();
            //sf.Alignment = StringAlignment.Far;



            if (this.m_intCurrentPageIndex == 0)//第一页
            {
                //画表头

                e.Graphics.DrawLine(this.m_objPen, fltFirstColLeft, m_fltCurrentHeight, fltNigColLeft + fltNigCol, m_fltCurrentHeight);
                //画线
                m_fltCurrentHeight += ftlRowHeight;
                e.Graphics.DrawLine(this.m_objPen, fltFirstColLeft, m_fltCurrentHeight, fltNigColLeft + fltNigCol, m_fltCurrentHeight);
                //画坚线

                e.Graphics.DrawLine(this.m_objPen, fltFirstColLeft, m_fltCurrentHeight - ftlRowHeight, fltFirstColLeft, m_fltCurrentHeight);
                e.Graphics.DrawLine(this.m_objPen, fltSeconColLeft, m_fltCurrentHeight - ftlRowHeight, fltSeconColLeft, m_fltCurrentHeight);
                e.Graphics.DrawLine(this.m_objPen, fltthColLeft, m_fltCurrentHeight - ftlRowHeight, fltthColLeft, m_fltCurrentHeight);
                e.Graphics.DrawLine(this.m_objPen, fltthirColLeft, m_fltCurrentHeight - ftlRowHeight, fltthirColLeft, m_fltCurrentHeight);
                e.Graphics.DrawLine(this.m_objPen, fltFiveColLeft, m_fltCurrentHeight - ftlRowHeight, fltFiveColLeft, m_fltCurrentHeight);
                e.Graphics.DrawLine(this.m_objPen, fltSixColLeft, m_fltCurrentHeight - ftlRowHeight, fltSixColLeft, m_fltCurrentHeight);
                e.Graphics.DrawLine(this.m_objPen, fltSenColLeft, m_fltCurrentHeight - ftlRowHeight, fltSenColLeft, m_fltCurrentHeight);
                e.Graphics.DrawLine(this.m_objPen, fltNigColLeft, m_fltCurrentHeight - ftlRowHeight, fltNigColLeft, m_fltCurrentHeight);
                e.Graphics.DrawLine(this.m_objPen, fltNigColLeft + fltNigCol, m_fltCurrentHeight - ftlRowHeight, fltNigColLeft + fltNigCol, m_fltCurrentHeight);

                //填表头字
                strPrint = "病人姓名";
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltFirstColLeft + fltZiJiWide, m_fltCurrentHeight - ftlRowHeight + fltZijiHeight);

                strPrint = " 就 诊 卡 号";
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltSeconColLeft + fltZiJiWide, m_fltCurrentHeight - ftlRowHeight + fltZijiHeight);

                strPrint = " 就 诊 日 期";
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltthColLeft + fltZiJiWide, m_fltCurrentHeight - ftlRowHeight + fltZijiHeight);

                strPrint = " 发 票 号 码";
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltthirColLeft + fltZiJiWide, m_fltCurrentHeight - ftlRowHeight + fltZijiHeight);

                strPrint = "自付金额";
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltFiveColLeft + fltZiJiWide, m_fltCurrentHeight - ftlRowHeight + fltZijiHeight);

                strPrint = "记帐金额";
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltSixColLeft + fltZiJiWide, m_fltCurrentHeight - ftlRowHeight + fltZijiHeight);

                strPrint = "合计金额";
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltSenColLeft + fltZiJiWide, m_fltCurrentHeight - ftlRowHeight + fltZijiHeight);

                strPrint = "  收 费 员";
                e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltNigColLeft + fltZiJiWide, m_fltCurrentHeight - ftlRowHeight + fltZijiHeight);
                //结束

                //计算第一页还能打印出多少条记录

                int intRowCount = Convert.ToInt32((float.Parse(e.MarginBounds.Height.ToString()) - m_fltCurrentHeight) / ftlRowHeight);
                intRowCount--; //因为留出一行位置来打印页脚 ，所以显示总行数为减1

                //循环打印各行


                if (this.m_objResultArr.Length > 0)
                {

                    for (int i1 = 0; i1 < this.m_objResultArr.Length && i1 <= intRowCount; i1++)
                    //	for(int i1 = 0 ;i1 < this.m_objResultArr.Length; i1 ++)
                    {
                        e.Graphics.DrawString(" " + m_objResultArr[i1].m_strPatientName, this.m_objFont, Brushes.Black, fltFirstColLeft + fltZiJiWide, m_fltCurrentHeight + fltZijiHeight);
                        e.Graphics.DrawString(" " + m_objResultArr[i1].m_strPatientCardId, this.m_objFont, Brushes.Black, fltSeconColLeft + fltZiJiWide, m_fltCurrentHeight + fltZijiHeight);
                        e.Graphics.DrawString(" " + m_objResultArr[i1].m_strRecordDataTime.Date.ToShortDateString(), this.m_objFont, Brushes.Black, fltthColLeft + fltZiJiWide, m_fltCurrentHeight + fltZijiHeight);
                        e.Graphics.DrawString(" " + m_objResultArr[i1].m_strInvoiceNo, this.m_objFont, Brushes.Black, fltthirColLeft + fltZiJiWide, m_fltCurrentHeight + fltZijiHeight);

                        SizeF sizeX = e.Graphics.MeasureString(" " + m_objResultArr[i1].m_strSBSUM_MNY.ToString("0.00"), this.m_objFont);
                        e.Graphics.DrawString(" " + m_objResultArr[i1].m_strSBSUM_MNY.ToString("0.00"), this.m_objFont, Brushes.Black, fltSixColLeft - fltZiJiWide - sizeX.Width, m_fltCurrentHeight + fltZijiHeight);

                        sizeX = e.Graphics.MeasureString(" " + m_objResultArr[i1].m_strACCTSUM_MNY.ToString("0.00"), this.m_objFont);
                        e.Graphics.DrawString(" " + m_objResultArr[i1].m_strACCTSUM_MNY.ToString("0.00"), this.m_objFont, Brushes.Black, fltSenColLeft - fltZiJiWide - sizeX.Width, m_fltCurrentHeight + fltZijiHeight);

                        sizeX = e.Graphics.MeasureString(" " + m_objResultArr[i1].m_strTOTALSUM_MNY.ToString("0.00"), this.m_objFont);
                        e.Graphics.DrawString(" " + m_objResultArr[i1].m_strTOTALSUM_MNY.ToString("0.00"), this.m_objFont, Brushes.Black, fltNigColLeft - fltZiJiWide - sizeX.Width, m_fltCurrentHeight + fltZijiHeight);
                        e.Graphics.DrawString("  " + m_objResultArr[i1].m_strLastname_vchr, this.m_objFont, Brushes.Black, fltNigColLeft + fltZiJiWide, m_fltCurrentHeight + fltZijiHeight);

                        //画线
                        m_fltCurrentHeight += ftlRowHeight;
                        e.Graphics.DrawLine(this.m_objPen, fltFirstColLeft, m_fltCurrentHeight, fltNigColLeft + fltNigCol, m_fltCurrentHeight);

                        //画坚线

                        e.Graphics.DrawLine(this.m_objPen, fltFirstColLeft, m_fltCurrentHeight - ftlRowHeight, fltFirstColLeft, m_fltCurrentHeight);
                        e.Graphics.DrawLine(this.m_objPen, fltSeconColLeft, m_fltCurrentHeight - ftlRowHeight, fltSeconColLeft, m_fltCurrentHeight);
                        e.Graphics.DrawLine(this.m_objPen, fltthColLeft, m_fltCurrentHeight - ftlRowHeight, fltthColLeft, m_fltCurrentHeight);
                        e.Graphics.DrawLine(this.m_objPen, fltthirColLeft, m_fltCurrentHeight - ftlRowHeight, fltthirColLeft, m_fltCurrentHeight);
                        e.Graphics.DrawLine(this.m_objPen, fltFiveColLeft, m_fltCurrentHeight - ftlRowHeight, fltFiveColLeft, m_fltCurrentHeight);
                        e.Graphics.DrawLine(this.m_objPen, fltSixColLeft, m_fltCurrentHeight - ftlRowHeight, fltSixColLeft, m_fltCurrentHeight);
                        e.Graphics.DrawLine(this.m_objPen, fltSenColLeft, m_fltCurrentHeight - ftlRowHeight, fltSenColLeft, m_fltCurrentHeight);
                        e.Graphics.DrawLine(this.m_objPen, fltNigColLeft, m_fltCurrentHeight - ftlRowHeight, fltNigColLeft, m_fltCurrentHeight);
                        e.Graphics.DrawLine(this.m_objPen, fltNigColLeft + fltNigCol, m_fltCurrentHeight - ftlRowHeight, fltNigColLeft + fltNigCol, m_fltCurrentHeight);

                        m_intCurrentPageIndex = 1; //第一页

                        this.m_intPageTotal = 1; //总页数

                        m_intVoIndex = i1;

                    }
                    #region 计算总页数

                    intPageRowCount = Convert.ToInt32(Convert.ToDouble(e.MarginBounds.Height) / ftlRowHeight);//第二页可显示的记录行数							
                    intPageRowCount--;//留下一行位置写页脚
                    int shengxi = this.m_objResultArr.Length - m_intVoIndex - 1;
                    m_intPageTotal = shengxi / intPageRowCount + 1;//总页数

                    if (shengxi % intPageRowCount != 0)
                    {
                        m_intPageTotal++;
                    }
                    #endregion

                    m_printDoc_PrintFooter(sender, e);//打页脚

                    //判断是否多页
                    if (m_intVoIndex < this.m_objResultArr.Length)
                    {
                        e.HasMorePages = true;
                    }

                }
            }
            else //打印非第一页
            {
                //循环打印剩下各行
                if (m_intVoIndex != -1)
                {
                    int intShengxia = this.m_objResultArr.Length - m_intVoIndex - 1;
                    if (intShengxia != 0) //有没打印的记录
                    {
                        int intTemp = m_intVoIndex;
                        m_fltCurrentHeight = e.MarginBounds.Y;
                        for (int i1 = m_intVoIndex + 1; i1 < this.m_objResultArr.Length && i1 < intPageRowCount + intTemp; i1++)
                        {

                            e.Graphics.DrawLine(this.m_objPen, fltFirstColLeft, m_fltCurrentHeight, fltNigColLeft + fltNigCol, m_fltCurrentHeight);
                            e.Graphics.DrawString(" " + m_objResultArr[i1].m_strPatientName, this.m_objFont, Brushes.Black, fltFirstColLeft + fltZiJiWide, m_fltCurrentHeight + fltZijiHeight);
                            e.Graphics.DrawString(" " + m_objResultArr[i1].m_strPatientCardId, this.m_objFont, Brushes.Black, fltSeconColLeft + fltZiJiWide, m_fltCurrentHeight + fltZijiHeight);
                            e.Graphics.DrawString(" " + m_objResultArr[i1].m_strRecordDataTime.Date.ToShortDateString(), this.m_objFont, Brushes.Black, fltthColLeft + fltZiJiWide, m_fltCurrentHeight + fltZijiHeight);
                            e.Graphics.DrawString(" " + m_objResultArr[i1].m_strInvoiceNo, this.m_objFont, Brushes.Black, fltthirColLeft + fltZiJiWide, m_fltCurrentHeight + fltZijiHeight);

                            SizeF objX = e.Graphics.MeasureString(" " + m_objResultArr[i1].m_strSBSUM_MNY.ToString("0.00"), this.m_objFont);
                            e.Graphics.DrawString(" " + m_objResultArr[i1].m_strSBSUM_MNY.ToString("0.00"), this.m_objFont, Brushes.Black, fltSixColLeft - fltZiJiWide - objX.Width, m_fltCurrentHeight + fltZijiHeight, sf);

                            objX = e.Graphics.MeasureString(" " + m_objResultArr[i1].m_strACCTSUM_MNY.ToString("0.00"), this.m_objFont);
                            e.Graphics.DrawString(" " + m_objResultArr[i1].m_strACCTSUM_MNY.ToString("0.00"), this.m_objFont, Brushes.Black, fltSenColLeft - fltZiJiWide - objX.Width, m_fltCurrentHeight + fltZijiHeight, sf);

                            objX = e.Graphics.MeasureString(" " + m_objResultArr[i1].m_strTOTALSUM_MNY.ToString("0.00"), this.m_objFont);
                            e.Graphics.DrawString(" " + m_objResultArr[i1].m_strTOTALSUM_MNY.ToString("0.00"), this.m_objFont, Brushes.Black, fltNigColLeft - fltZiJiWide - objX.Width, m_fltCurrentHeight + fltZijiHeight, sf);
                            e.Graphics.DrawString(" " + m_objResultArr[i1].m_strLastname_vchr, this.m_objFont, Brushes.Black, fltNigColLeft + fltZiJiWide, m_fltCurrentHeight + fltZijiHeight);

                            //画线
                            m_fltCurrentHeight += ftlRowHeight;
                            e.Graphics.DrawLine(this.m_objPen, fltFirstColLeft, m_fltCurrentHeight, fltNigColLeft + fltNigCol, m_fltCurrentHeight);

                            //画坚线

                            e.Graphics.DrawLine(this.m_objPen, fltFirstColLeft, m_fltCurrentHeight - ftlRowHeight, fltFirstColLeft, m_fltCurrentHeight);
                            e.Graphics.DrawLine(this.m_objPen, fltSeconColLeft, m_fltCurrentHeight - ftlRowHeight, fltSeconColLeft, m_fltCurrentHeight);
                            e.Graphics.DrawLine(this.m_objPen, fltthColLeft, m_fltCurrentHeight - ftlRowHeight, fltthColLeft, m_fltCurrentHeight);
                            e.Graphics.DrawLine(this.m_objPen, fltthirColLeft, m_fltCurrentHeight - ftlRowHeight, fltthirColLeft, m_fltCurrentHeight);
                            e.Graphics.DrawLine(this.m_objPen, fltFiveColLeft, m_fltCurrentHeight - ftlRowHeight, fltFiveColLeft, m_fltCurrentHeight);
                            e.Graphics.DrawLine(this.m_objPen, fltSixColLeft, m_fltCurrentHeight - ftlRowHeight, fltSixColLeft, m_fltCurrentHeight);
                            e.Graphics.DrawLine(this.m_objPen, fltSenColLeft, m_fltCurrentHeight - ftlRowHeight, fltSenColLeft, m_fltCurrentHeight);
                            e.Graphics.DrawLine(this.m_objPen, fltNigColLeft, m_fltCurrentHeight - ftlRowHeight, fltNigColLeft, m_fltCurrentHeight);
                            e.Graphics.DrawLine(this.m_objPen, fltNigColLeft + fltNigCol, m_fltCurrentHeight - ftlRowHeight, fltNigColLeft + fltNigCol, m_fltCurrentHeight);



                            m_intVoIndex = i1;
                        }
                        m_intCurrentPageIndex += 1; //第一页

                        //this.m_intPageTotal += 1; //总页数

                        m_printDoc_PrintFooter(sender, e);//打页脚

                        //判断是否多页
                        if (intPageRowCount < intShengxia)
                        {
                            e.HasMorePages = true;
                            return;
                        }
                    }
                }

            }

        }
        #endregion

        #region 获取打印数据：created by weiling.huang  at 2005-9-16
        /// <summary>
        /// 获取打印数据：created by weiling.huang  at 2005-9-16
        /// </summary>
        private void GetData()
        {
            this.m_mthQuery();//得到要打印的数据于m_objResultArr中

            if (this.m_objResultArr.Length > 0)
            {
                int intPeople = 0; //有效人次
                float fltTotal = 0;//有效总合计

                float fltSubTotal = 0;//有效自付合计
                float fltJiTotal = 0;//有效记帐合计

                int intTuiPeople = 0; //退票人次

                float fltTuiTotal = 0;//退票总合计

                float fltTuiSubTotal = 0;//退票自付合计

                float fltTuiJiTotal = 0;//退票记帐合计


                int intLength = this.m_objResultArr.Length;
                for (int i1 = 0; i1 < intLength; i1++)
                {
                    if (m_objResultArr[i1].m_strTOTALSUM_MNY < 0)//退票
                    {
                        intTuiPeople++;
                        fltTuiTotal += (0 - m_objResultArr[i1].m_strTOTALSUM_MNY);
                        fltTuiSubTotal += (0 - m_objResultArr[i1].m_strSBSUM_MNY);
                        fltTuiJiTotal += (0 - m_objResultArr[i1].m_strACCTSUM_MNY);
                    }
                    else
                    {
                        intPeople++;
                        fltTotal += m_objResultArr[i1].m_strTOTALSUM_MNY;
                        fltSubTotal += m_objResultArr[i1].m_strSBSUM_MNY;
                        fltJiTotal += m_objResultArr[i1].m_strACCTSUM_MNY;
                    }
                }
                this.m_intPeople = intPeople;
                this.m_fltTotal = fltTotal;
                this.m_fltSubTotal = fltSubTotal;
                this.m_fltJiTotal = fltJiTotal;

                this.m_intTuiPeople = intTuiPeople;
                this.m_fltTuiTotal = fltTuiTotal;
                this.m_fltTuiSubTotal = fltTuiSubTotal;
                this.m_fltTuiJiTotal = fltTuiJiTotal;
            }
        }
        #endregion

        #region  打印前触发：created by weiling.huang  at 2005-9-16
        /// <summary>
        /// 打印前触发：created by weiling.huang  at 2005-9-16
        /// </summary>
        /// <param name="sender">触发对象</param>
        /// <param name="e">打印相关参数对象</param>
        public void m_printDoc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            GetData();
        }
        #endregion

        #region  打印后触发：created by weiling.huang  at 2005-9-16
        /// <summary>
        /// 打印后触发：created by weiling.huang  at 2005-9-16
        /// </summary>
        /// <param name="sender">触发对象</param>
        /// <param name="e">打印相关参数对象</param>
        public void m_printDoc_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
        #endregion

        #region  方法：画页脚：created by weiling.huang  at 2005-9-16
        /// <summary>
        /// 方法：画页脚：created by weiling.huang  at 2005-9-16
        /// </summary>
        /// <param name="sender">触发对象</param>
        /// <param name="e">打印相关参数对象</param>
        public void m_printDoc_PrintFooter(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string strPrint = "第" + this.m_intCurrentPageIndex.ToString() + "页,共" + m_intPageTotal.ToString() + "页";
            float fltLeft = this.fltLeftAlignWidth + float.Parse(e.MarginBounds.Width.ToString()) * (float)0.85;
            e.Graphics.DrawString(strPrint, this.m_objFont, Brushes.Black, fltLeft, this.m_fltCurrentHeight + 4);

            this.m_objFrmViewer.numericUpDown1.Maximum = m_intPageTotal;
        }
        #endregion

        #region  方法：导出：created by weiling.huang  at 2005-9-26
        /// <summary>
        /// 方法：导出：created by weiling.huang  at 2005-9-26
        /// </summary>
        private void m_mthExcel(clsOutPatientTableInfo_VO[] p_objResultArr)
        {
            if (p_objResultArr.Length <= 0)
            {
                MessageBox.Show("无导出数据！");
                return;
            }

            DataSet ds = new DataSet();
            ds = m_mthCreateExcelDataSet(p_objResultArr);
            com.digitalwave.iCare.common.ExcelExporter excel = new com.digitalwave.iCare.common.ExcelExporter(ds);
            bool bln = excel.m_mthExport();
            if (bln)
            {
                MessageBox.Show("导出成功！");
            }
            else
            {
                MessageBox.Show("导出失败！");
            }

        }
        #endregion

        #region  方法：导出接口：created by weiling.huang  at 2005-9-26
        /// <summary>
        /// 方法：导出接口：created by weiling.huang  at 2005-9-26
        /// </summary>
        public void m_mthOutExcel()
        {
            m_mthExcel(this.m_objResultArr);
        }
        #endregion

        #region  方法：生成导出报表要用到的DataTable：created by weiling.huang  at 2005-9-26
        /// <summary>
        /// 方法：生成导出报表要用到的DataTable：created by weiling.huang  at 2005-9-26
        /// </summary>
        public DataTable m_mthCreateExcelTable()
        {
            DataTable dt = new DataTable("门诊收费");
            System.Data.DataColumn dc = new DataColumn("病人姓名");
            dt.Columns.Add(dc);
            dc = new DataColumn("就诊卡号");
            dt.Columns.Add(dc);
            dc = new DataColumn("就诊日期");
            dt.Columns.Add(dc);
            dc = new DataColumn("发票号码");
            dt.Columns.Add(dc);
            dc = new DataColumn("自付金额");
            dt.Columns.Add(dc);
            dc = new DataColumn("记帐金额");
            dt.Columns.Add(dc);
            dc = new DataColumn("合计金额");
            dt.Columns.Add(dc);
            dc = new DataColumn("收费员");
            dt.Columns.Add(dc);
            return dt;
        }
        #endregion

        #region  方法：生成导出报表要用到的数据：created by weiling.huang  at 2005-9-26
        /// <summary>
        /// 方法：生成导出报表要用到的数据：created by weiling.huang  at 2005-9-26
        /// </summary>
        public DataSet m_mthCreateExcelDataSet(clsOutPatientTableInfo_VO[] p_objResultArr)
        {
            DataTable p_dt = m_mthCreateExcelTable();
            DataRow dr;
            for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
            {
                dr = p_dt.NewRow();
                dr["病人姓名"] = p_objResultArr[i1].m_strPatientName.Trim();
                dr["就诊卡号"] = p_objResultArr[i1].m_strPatientCardId.Trim();
                dr["就诊日期"] = p_objResultArr[i1].m_strRecordDataTime;
                dr["发票号码"] = p_objResultArr[i1].m_strInvoiceNo.Trim();
                dr["自付金额"] = p_objResultArr[i1].m_strSBSUM_MNY;
                dr["记帐金额"] = p_objResultArr[i1].m_strACCTSUM_MNY;
                dr["合计金额"] = p_objResultArr[i1].m_strTOTALSUM_MNY;
                dr["收费员"] = p_objResultArr[i1].m_strLastname_vchr.Trim();
                p_dt.Rows.Add(dr);
            }
            DataSet objds = new DataSet();
            objds.Tables.Add(p_dt);
            return objds;
        }
        #endregion

    }
    #endregion
}
