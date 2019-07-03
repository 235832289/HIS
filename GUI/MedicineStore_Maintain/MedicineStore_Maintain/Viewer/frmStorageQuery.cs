using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.MedicineStoreService;
using com.digitalwave.iCare.ValueObject;
using System.IO;
namespace com.digitalwave.iCare.gui.MedicineStore
{
    #region  药库明细查询 UI  王勇 2007-4-2

    public partial class frmStorageQuery : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 构造函数
        public frmStorageQuery()
        {
            InitializeComponent();
            //焦点控制
            m_txtMedicineCode.LostFocus += new EventHandler(m_txtMedicineCode_LostFocus);
            //开始日期和结束日期验证
            txtAbateEndDate.LostFocus += new EventHandler(txtAbateEndDate_LostFocus);

            cboStorage.GotFocus += new EventHandler(cboStorage_GotFocus);
            cboMedicineType.GotFocus += new EventHandler(cboMedicineType_GotFocus);

        }
        #endregion
        clsValue_MedicineType_VO[] objMedicineTypeArr = null;

        private clsStorageDetail_Stat_VO m_objStatValue = new clsStorageDetail_Stat_VO();

        private clsDcl_StorageDetailQuery m_objStorageDetailQuery = null;
        //
        //摘要
        //    药品类型数组
        private clsValue_MedicineType_VO[] m_objMedicineTypeArr = null;
        //
        //摘要
        //    药库基本信息
        private clsValue_StorageBse_VO[] m_objStorageBseArr = null;
        //
        //摘要
        //   药典查询控件
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        //
        //摘要
        //    药品基本信息
        private clsValue_MedicineBse_VO m_objMedicineBase = new clsValue_MedicineBse_VO();
        //
        //摘要
        //    药典数据表
        internal DataTable m_dtbMedicinDict = null;
        //
        //摘要
        //    药品明细数据表
        internal DataTable dtbResult =null;
        //
        //摘要
        //    药品明细临时表
        internal DataTable tmp_dtbResult = null;
        //
        //摘要
        //    购入金额总计
        private decimal m_decCallSumTotal = 0;
        //
        //摘要
        //    零售金额总计
        private decimal m_decRetailSumTotal = 0;
        //
        //摘要
        //    批发金额总计
        private decimal m_decWholesaleSumTotal = 0;
        //
        //摘要
        //    记录总数字段
        private int m_intRecordCount = 0;

        /// <summary>
        /// 报表文件名称
        /// </summary>
        internal string m_strReportName = string.Empty;
        /// <summary>
        /// 货架列
        /// </summary>
        internal DataGridViewComboBoxColumn comculumn = new DataGridViewComboBoxColumn();
        /// <summary>
        /// 货架列
        /// </summary>
        internal DataGridViewComboBoxColumn comculumnprovide = new DataGridViewComboBoxColumn();
        /// <summary>
        /// 需要修改货架的记录
        /// </summary>
        private Dictionary<string, string> m_dicStorageRack = new Dictionary<string, string>();
        /// <summary>
        /// 需要修改可供标志的记录
        /// </summary>
        private Dictionary<string, string> m_dicStorageProvide = new Dictionary<string, string>();
        /// <summary>
        /// 货架
        /// </summary>
        private DataTable m_dtbStorageRack = new DataTable();
        /// <summary>
        /// 可供标志
        /// </summary>
        private DataTable m_dtbStorageProvide = new DataTable();
        private clsDomainController_StorageDetailQuery objDomain = new clsDomainController_StorageDetailQuery();
        private DataTable dtbTem = new DataTable();
        private clsStorageDetail_SqlConditionQueryParam_VO m_value_Param = new clsStorageDetail_SqlConditionQueryParam_VO();

        #region 调用显示窗体
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="p_strReportName">报表文件名称</param>
        public void m_mthShowThis(string p_strReportName)
        {
            m_strReportName = p_strReportName;
            this.Show();
        }
        #endregion


        #region 记录总数属性
        /// <summary>
        /// 记录总数属性        /// </summary>
        public int intRecordCount
        {
            get
            {
                return m_intRecordCount;
            }
            set
            {
                m_intRecordCount = value;
            }
        }
        #endregion

        #region 窗体Load事件
        /// <summary>
        /// 窗体Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmStorageQusery_Load(object sender, EventArgs e)
        {
            //初始化药品基本信息
            m_objMedicineBase.m_strMedicineID = "";
            m_objMedicineBase.m_strAssistCode = "";
            m_objMedicineBase.m_strMedicineName = "";
            m_objMedicineBase.m_strMedSpec = "";


            ////初始化数据表
            //m_mthInitDataTable();

            //设置初始选项为“明细”

            rdbList.Checked = true;

            //获取药库基本信息
            GetStorageBse();

            //获取药品类型
            GetMedicineType();
            m_mthBindStorageRack();            
            m_mthBindStorageProvide();


            m_mthInitDataTable();
            //dtgLeechdomList.AutoGenerateColumns = false;
        }
        #endregion

        #region 初始化数据表
        /// <summary>
        /// 初始化DataGridView
        /// </summary>
        private void m_mthInitDataTable()
        {
            #region 设置DataGridView的列属性

            dtgLeechdomList.Columns.Clear();           

            lblCallSum.Text = "0.00";//购入金额
            lblRetailSum.Text = "0.00";//零售金额
            lblWholesaleSum.Text = "0.00";//批发金额

            comculumnprovide.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            comculumnprovide.Name = "colStorageProvide";
            comculumnprovide.HeaderText = "可供标志";
            dtgLeechdomList.Columns.Add(comculumnprovide);
            dtgLeechdomList.Columns[0].Width = 100;
            dtgLeechdomList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;            
            dtgLeechdomList.Columns[0].Frozen = true;

            comculumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            comculumn.Name = "colStorageRackID";
            comculumn.HeaderText = "货架";
            //dtgLeechdomList.Columns.Insert(6, comculumn);
            dtgLeechdomList.Columns.Add(comculumn);
            dtgLeechdomList.Columns[1].Width = 100;
            dtgLeechdomList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgLeechdomList.Columns[1].Frozen = true;          

            dtgLeechdomList.Columns.Add("colMedicineID", "药品ID");
            dtgLeechdomList.Columns[2].Width = 56;
            dtgLeechdomList.Columns[2].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dtgLeechdomList.Columns[2].Visible = false ;
            dtgLeechdomList.Columns[2].Frozen = true;


            dtgLeechdomList.Columns.Add("colStorageID", "仓库");
            dtgLeechdomList.Columns[3].Width = 90;
            dtgLeechdomList.Columns[3].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dtgLeechdomList.Columns[3].Frozen = true;

            dtgLeechdomList.Columns.Add("colAssistCode", "药品代码");
            dtgLeechdomList.Columns[4].Width = 82;
            dtgLeechdomList.Columns[4].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dtgLeechdomList.Columns[4].Frozen = true;

            dtgLeechdomList.Columns.Add("colMedicineName", "药品名称");
            dtgLeechdomList.Columns[5].Width = 174;
            dtgLeechdomList.Columns[5].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dtgLeechdomList.Columns[5].Frozen = true;

            dtgLeechdomList.Columns.Add("colMedSpec", "规格");
            dtgLeechdomList.Columns[6].Width = 90;
            dtgLeechdomList.Columns[6].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //dtgLeechdomList.Columns[4].Frozen = true;

            dtgLeechdomList.Columns.Add("colLotNo", "批号");
            dtgLeechdomList.Columns[7].Width = 90;
            dtgLeechdomList.Columns[7].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //dtgLeechdomList.Columns[5].Frozen = true;            

            dtgLeechdomList.Columns.Add("colMedicineTypeName", "药品类型");
            dtgLeechdomList.Columns[8].Width = 78;
            dtgLeechdomList.Columns[8].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //dtgLeechdomList.Columns[6].Frozen = true;

            dtgLeechdomList.Columns.Add("colRealGross", "实际库存");
            dtgLeechdomList.Columns[9].Width = 82;
            dtgLeechdomList.Columns[9].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dtgLeechdomList.Columns[9].DefaultCellStyle.Format = "0.00";

            dtgLeechdomList.Columns.Add("colAvailaGross", "可用库存");
            dtgLeechdomList.Columns[10].Width = 82;
            dtgLeechdomList.Columns[10].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dtgLeechdomList.Columns[10].DefaultCellStyle.Format = "0.00";

            dtgLeechdomList.Columns.Add("colOPUnit", "单位");
            dtgLeechdomList.Columns[11].Width = 52;
            dtgLeechdomList.Columns[11].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            dtgLeechdomList.Columns.Add("colCallPrice", "购入单价");
            dtgLeechdomList.Columns[12].Width = 78;
            dtgLeechdomList.Columns[12].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dtgLeechdomList.Columns[12].DefaultCellStyle.Format = "0.0000";

            dtgLeechdomList.Columns.Add("colCallSum", "购入金额");
            dtgLeechdomList.Columns[13].Width = 78;
            dtgLeechdomList.Columns[13].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dtgLeechdomList.Columns[13].DefaultCellStyle.Format = "0.0000";

            dtgLeechdomList.Columns.Add("colRetailPrice", "零售单价");
            dtgLeechdomList.Columns[14].Width = 78;
            dtgLeechdomList.Columns[14].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dtgLeechdomList.Columns[14].DefaultCellStyle.Format = "0.0000";

            dtgLeechdomList.Columns.Add("colRetailSum", "零售金额");
            dtgLeechdomList.Columns[15].Width = 78;
            dtgLeechdomList.Columns[15].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dtgLeechdomList.Columns[15].DefaultCellStyle.Format = "N4";

            dtgLeechdomList.Columns.Add("colWholesalePrice", "批发单价");
            dtgLeechdomList.Columns[16].Width = 78;
            dtgLeechdomList.Columns[16].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dtgLeechdomList.Columns[16].DefaultCellStyle.Format = "0.0000";

            dtgLeechdomList.Columns.Add("colWholesaleSum", "批发金额");
            dtgLeechdomList.Columns[17].Width = 78;
            dtgLeechdomList.Columns[17].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dtgLeechdomList.Columns[17].DefaultCellStyle.Format = "0.0000";

            dtgLeechdomList.Columns.Add("colDate", "失效日期");
            dtgLeechdomList.Columns[18].Width = 82;
            dtgLeechdomList.Columns[18].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            dtgLeechdomList.Columns.Add("colMedicinePrepTypeName", "药品剂型");
            dtgLeechdomList.Columns[19].Width = 70;
            dtgLeechdomList.Columns[19].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            dtgLeechdomList.Columns.Add("productorid_chr", "生产厂家");
            dtgLeechdomList.Columns[20].Width = 70;
            dtgLeechdomList.Columns[20].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            dtgLeechdomList.Columns.Add("vendorname_vchr", "供应商");
            dtgLeechdomList.Columns[21].Width = 120;
            dtgLeechdomList.Columns[21].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            dtgLeechdomList.Columns.Add("endamount_int", "上期结存");
            dtgLeechdomList.Columns[22].Width = 82;
            dtgLeechdomList.Columns[22].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dtgLeechdomList.Columns[22].DefaultCellStyle.Format = "0.00";

            #endregion


            for (int i1 = 0; i1 < dtgLeechdomList.ColumnCount - 1; i1++)
            {
                dtgLeechdomList.Columns[i1].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                if (i1 != 0 && i1 != 1)
                    dtgLeechdomList.Columns[i1].ReadOnly = true;
            }

            #region 设置DataGride的“DataPropertyName”属性

            dtgLeechdomList.Columns[0].DataPropertyName = "canprovide";
            dtgLeechdomList.Columns[1].DataPropertyName = "storagerackid_chr";
            dtgLeechdomList.Columns[2].DataPropertyName = "MEDICINEID_CHR";
            dtgLeechdomList.Columns[3].DataPropertyName = "MEDICINEROOMNAME";
            dtgLeechdomList.Columns[4].DataPropertyName = "ASSISTCODE_CHR";
            dtgLeechdomList.Columns[5].DataPropertyName = "MEDICINENAME_VCHR";
            dtgLeechdomList.Columns[6].DataPropertyName = "MEDSPEC_VCHR";
            dtgLeechdomList.Columns[7].DataPropertyName = "LOTNO_VCHR";
            dtgLeechdomList.Columns[8].DataPropertyName = "MEDICINETYPENAME_VCHR";            
            dtgLeechdomList.Columns[9].DataPropertyName = "REALGROSS_INT";
            dtgLeechdomList.Columns[10].DataPropertyName = "AVAILAGROSS_INT";
            dtgLeechdomList.Columns[11].DataPropertyName = "OPUNIT_VCHR";
            dtgLeechdomList.Columns[12].DataPropertyName = "CALLPRICE_INT";
            dtgLeechdomList.Columns[13].DataPropertyName = "CALLSUM";
            dtgLeechdomList.Columns[14].DataPropertyName = "RETAILPRICE_INT";
            dtgLeechdomList.Columns[15].DataPropertyName = "RETAILSUM";
            dtgLeechdomList.Columns[16].DataPropertyName = "WHOLESALEPRICE_INT";
            dtgLeechdomList.Columns[17].DataPropertyName = "WHOLESALESUM";
            dtgLeechdomList.Columns[18].DataPropertyName = "VALIDPERIOD_DAT";
            dtgLeechdomList.Columns[19].DataPropertyName = "MEDICINEPREPTYPENAME_VCHR";
            dtgLeechdomList.Columns[20].DataPropertyName = "productorid_chr";
            dtgLeechdomList.Columns[21].DataPropertyName = "vendorname_vchr";
            dtgLeechdomList.Columns[22].DataPropertyName = "endamount_int";

            if (rdbStat.Checked == true)
            {
                dtgLeechdomList.Columns[7].Visible = false;
                dtgLeechdomList.Columns[0].Visible = false;
                dtgLeechdomList.Columns[1].Visible = false;
            }
            else
            {
                dtgLeechdomList.Columns[7].Visible = true;
                dtgLeechdomList.Columns[0].Visible = true;
                dtgLeechdomList.Columns[1].Visible = true;
            }
            #endregion
        }
        #endregion

        #region 窗体的“Shown”事件
        /// <summary>
        /// 窗体的“Shown”事件
        /// 用于初始化窗体布局
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmStorageQusery_Shown(object sender, EventArgs e)
        {
            //使窗体的各个控件的Location属性随窗体的大小变化而改变
            frmSizeChang();

            //在DataGridView上方显示“当前记录数/总记录数”形式的指示器
            displayRecordNo();

            cmdQuery.Focus();
        }
        #endregion

        #region RadioButton控件的“CheckedChanged”事件
        /// <summary>
        /// RadioButton控件的“CheckedChanged”事件
        /// 如果控件的checked发生改变，则清除已获取的数据并准备重新获取数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbStat_CheckedChanged(object sender, EventArgs e)
        {

           if (rdbStat.Checked == true)
            {
                lblList.Text = "药品统计列表";
            }
            else
            {
                lblList.Text = "药品明细列表";
            }


            if (dtgLeechdomList.RowCount > 0)
            {
                dtgLeechdomList.DataSource = null;
            }

           m_mthInitDataTable();
           lblRecordNo.Left = lblList.Left + lblList.Width + 10;
           intRecordCount = 0;
           displayRecordNo();
          
           
       }
        #endregion

        #region 数据表的“MouseClick”事件
       /// <summary>
        /// 数据表的“MouseClick”事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgLeechdomList_MouseClick(object sender, MouseEventArgs e)
        {
            displayRecordNo();
        }
       #endregion

        #region 数据表的“KeyUp”事件
        /// <summary>
        /// 数据表的“KeyUp”事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgLeechdomList_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 9://Tab
                    displayRecordNo();
                    break;
                case 13://Enter
                    displayRecordNo();
                    break;
                case 33://PageUp
                    displayRecordNo();
                    break;
                case 34://PageDown
                    displayRecordNo();
                    break;
                case 38://up
                    displayRecordNo();
                    break;
                case 40://down
                    displayRecordNo();
                    break;
            }
        }
        #endregion

        #region 显示记录号
        /// <summary>
        /// 显示记录号
        /// </summary>
        private void displayRecordNo()
        {
            if ((intRecordCount > 0) && (dtgLeechdomList.RowCount > 0))
                lblRecordNo.Text = (dtgLeechdomList.CurrentRow.Index + 1).ToString() + "/" + dtgLeechdomList.RowCount.ToString();
            else
                lblRecordNo.Text = "0/0";
        }
        #endregion

        #region 当窗体大小发生变化时，改变各控件的“Location”属性
        /// <summary>
        /// 当窗体大小发生变化时，改变各控件的“Location”属性
        /// </summary>
        private void frmStorageQusery_SizeChanged(object sender, EventArgs e)
        {
            //DialogResult dlgResult1 = MessageBox.Show("SizeChanged");
            //DialogResult dlgResult = MessageBox.Show(groupBox1.Left.ToString());

            frmSizeChang();
        }
        #endregion

        #region 改变控件的位置frmSizeChang()
        /// <summary>
        /// 改变控件的位置
        /// </summary>
        private void frmSizeChang()
        {
            //groupBox1.Width = this.Width - groupBox1.Left - groupBox2.Width - 40;

            //groupBox2.Left = this.Width - 20 - groupBox2.Width;

            //dtgLeechdomList.Width = this.Width - dtgLeechdomList.Left - 20;
            //dtgLeechdomList.Height = this.Height - dtgLeechdomList.Top - 60;

        }
        #endregion

        #region 获取药品类型
        /// <summary>
        /// 获取药品类型，保存在“clsValue_MedicineType_VO”类型数组中
        /// 数组的索引号与组合框项的索引号关联
        /// </summary>
        private void GetMedicineType()
        {
            long lngRes = 0;

            cboMedicineType.Items.Clear();
            if ((cboStorage.Items.Count >= 0) && (objMedicineTypeArr==null))
            {
                cboMedicineType.Items.Clear();
                try
                {
                   // clsDomainController_StorageDetailQuery objDomain = new clsDomainController_StorageDetailQuery();

                    //调用Com+服务端

                    lngRes = objDomain.m_lngGetResultByConditionMedicineType(out objMedicineTypeArr);

                    if (lngRes > 0)
                    {
                        m_objMedicineTypeArr = new clsValue_MedicineType_VO[objMedicineTypeArr.Length + 1];
                        cboMedicineType.Items.Add("所有类型");
                        int m_index = 0;
                        for (int i1 = 0; i1 < objMedicineTypeArr.Length; i1++)
                        {                            
                            if (objMedicineTypeArr[i1].m_strMedicineRoomID == m_objStorageBseArr[cboStorage.SelectedIndex].MEDICINEROOMID)
                            {
                                if (i1 == 0)
                                {
                                    m_index = cboMedicineType.Items.Add(objMedicineTypeArr[i1].m_strMedicineTypesetName);
                                    m_objMedicineTypeArr[m_index] = objMedicineTypeArr[i1];
                                }
                                else if (objMedicineTypeArr[i1].m_strMedicineTypesetID.Trim() != objMedicineTypeArr[i1 - 1].m_strMedicineTypesetID.Trim())
                                {
                                    m_index = cboMedicineType.Items.Add(objMedicineTypeArr[i1].m_strMedicineTypesetName);
                                    m_objMedicineTypeArr[m_index] = objMedicineTypeArr[i1];
                                }
                                
                            }
                        }//for
                        cboMedicineType.SelectedIndex = 0;
                    }
                    else
                    {
                        cboMedicineType.Items.Clear();
                    }
                }//try
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                    MessageBox.Show(strTmp, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            else if ((cboStorage.Items.Count >= 0) && (objMedicineTypeArr!=null))
            {
                        cboMedicineType.Items.Add("所有类型");
                        int m_index = 0;
                        for (int i1 = 0; i1 < objMedicineTypeArr.Length; i1++)
                        {
                            if (i1 == 0)
                            {
                                m_index = cboMedicineType.Items.Add(objMedicineTypeArr[i1].m_strMedicineTypesetName);
                                m_objMedicineTypeArr[m_index] = objMedicineTypeArr[i1];
                            }
                            else if (objMedicineTypeArr[i1].m_strMedicineTypesetID.Trim() != objMedicineTypeArr[i1 - 1].m_strMedicineTypesetID.Trim())
                            {
                                m_index = cboMedicineType.Items.Add(objMedicineTypeArr[i1].m_strMedicineTypesetName);
                                m_objMedicineTypeArr[m_index] = objMedicineTypeArr[i1];
                            }
                        }
                        cboMedicineType.SelectedIndex = 0;

            }
        }
        #endregion

        #region 获取药库基本信息
        /// <summary>
        /// 获取药库基本信息，保存在“clsValue_StorageBse_VO”类型数组中
        /// 数组的索引号与组合框项的索引号关联
        /// </summary>
        private void GetStorageBse()
        {
            long lngRes = 0;
            clsValue_StorageBse_VO[] objStorageBseArr = null;
            if (cboStorage.Items.Count == 0)
            {
                try
                {
                    //clsDomainController_StorageDetailQuery objDomain = new clsDomainController_StorageDetailQuery();

                    //调用Com+服务端

                    lngRes = objDomain.m_lngGetResultByConditionStorageBse(out objStorageBseArr);

                    if (lngRes > 0)
                    {
                        m_objStorageBseArr = new clsValue_StorageBse_VO[objStorageBseArr.Length];
                        int m_index = 0;
                        for (int i1 = 0; i1 < objStorageBseArr.Length; i1++)
                        {
                            m_index = cboStorage.Items.Add(objStorageBseArr[i1].MEDICINEROOMNAME);
                            m_objStorageBseArr[m_index] = objStorageBseArr[i1];
                        }
                        cboStorage.SelectedIndex = 0;
                    }
                    else
                    {
                        cboStorage.Items.Clear();
                    }
                }//try
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                    MessageBox.Show(strTmp, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                int m_index = 0;
                for (int i1 = 0; i1 < objStorageBseArr.Length; i1++)
                {
                    m_index = cboStorage.Items.Add(objStorageBseArr[i1].MEDICINEROOMNAME);
                    m_objStorageBseArr[m_index] = objStorageBseArr[i1];
                }
                cboStorage.SelectedIndex = 0;
            }

        }

        #endregion

        #region 获取药品明细数据
        /// <summary>
        /// 获取药品明细数据
        /// 实现统计查询和明细查询功能。
        /// 可按药品的助记码、拼音码、五笔码、药品的ID或药品名称进行模糊查询
        /// </summary>
        private void m_mthGetMedicineDetail()
        {
            long lngRes = 0;
            List<string> lstMedicineType = new List<string>();

            m_value_Param.m_strStorageID = "";
            m_value_Param.m_strMedicineTypeID = "";
            m_value_Param.m_strMedicineID = "";
            m_value_Param.m_strValidBeginDate = "";
            m_value_Param.m_strValidEndDate = "";
            m_value_Param.m_strAssistCode = "";
            m_value_Param.m_blnZeroGross = false;

            dtgLeechdomList.DataSource = null;
            intRecordCount = 0;
            displayRecordNo();



            if (dtbResult != null)
            {
                dtbResult.Clear();
                dtbResult.Dispose();
                dtbResult = null;
            }




            m_mthInitDataTable();


            if (cboStorage.Text.Trim().Length == 0)
            {
                MessageBox.Show("必须选择药库!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            else
                m_value_Param.m_strStorageName = cboStorage.Text;

            if (txtAbateBeginDate.Text.Trim().Length < 11)
                txtAbateBeginDate.Text = "";
            if (txtAbateEndDate.Text.Trim().Length < 11)
                txtAbateEndDate.Text = "";

            if ((txtAbateBeginDate.Text.Trim().Length == 11) && (txtAbateEndDate.Text.Trim().Length == 11))
            {
                if ((Convert.ToDateTime(txtAbateBeginDate.Text)) > (Convert.ToDateTime(txtAbateEndDate.Text)))
                {
                    DialogResult tmpResult = MessageBox.Show("失效开始日期必须小于失效结束日期！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtAbateBeginDate.Focus();
                    return;
                }
            }

            m_value_Param.m_strStorageID = m_objStorageBseArr[cboStorage.SelectedIndex].MEDICINEROOMID;
            if (txtAbateBeginDate.Text.Trim().Length == 11)
            {
                string strDate = txtAbateBeginDate.Text;
                m_value_Param.m_strValidBeginDate = Convert.ToDateTime(strDate).ToString("yyyy-MM-dd");
            }
            if (txtAbateEndDate.Text.Trim().Length == 11)
            {
                string strDate = txtAbateEndDate.Text;
                m_value_Param.m_strValidEndDate = Convert.ToDateTime(strDate).ToString("yyyy-MM-dd");
            }

            if (m_txtMedicineCode.Text.Trim().Length > 0)
            {
                if (m_objMedicineBase.m_strMedicineID.Trim().Length > 0)
                    m_value_Param.m_strMedicineID = m_objMedicineBase.m_strMedicineID.Trim();
                else
                {
                    m_value_Param.m_strAssistCode = m_txtMedicineCode.Text + @"%";
                }
            }
            else
            {
                m_value_Param.m_strAssistCode = "";
            }

            //药品类型
            if ((cboMedicineType.Text.Trim().Length > 0) && (cboMedicineType.Text.Trim() != "所有类型"))
            {
                
                for (int i1 = 0; i1 < objMedicineTypeArr.Length; i1++)
                {
                    if ((m_objStorageBseArr[cboStorage.SelectedIndex].MEDICINEROOMID == 
                        objMedicineTypeArr[i1].m_strMedicineRoomID)
                     && (m_objMedicineTypeArr[cboMedicineType.SelectedIndex].m_strMedicineTypesetID == 
                            objMedicineTypeArr[i1].m_strMedicineTypesetID))
                    {
                        lstMedicineType.Add(objMedicineTypeArr[i1].m_strMedicineTypeID);
                    }
                }
                if (lstMedicineType.Count == 0)
                {
                    lstMedicineType.Add(m_objMedicineTypeArr[cboMedicineType.SelectedIndex].m_strMedicineTypeID);
                }

                //m_value_Param.m_strMedicineTypeID = m_objMedicineTypeArr[cboMedicineType.SelectedIndex].m_strMedicineTypeID;
            }
            else
                m_value_Param.m_strMedicineTypeID = "";

            m_value_Param.m_blnZeroGross = true;// radZeroStorage.Checked;

            m_objStorageDetailQuery = new clsDcl_StorageDetailQuery();

            dtbResult = new DataTable();//数据库返回的结果集

            lngRes = m_objStorageDetailQuery.m_mthGetStorageDetailData(ref m_value_Param,radioButton2.Checked, out dtbResult, ref m_objStatValue,lstMedicineType, rdbStat.Checked);
            if ((lngRes > 0) && (dtbResult != null))
            {
                dtgLeechdomList.DataSource = dtbResult;
                intRecordCount = dtbResult.Rows.Count;
                displayRecordNo();

                lblCallSum.Text = m_objStatValue.m_decCallSumTotal.ToString("#,##0.00");//购入金额
                lblRetailSum.Text = m_objStatValue.m_decRetailSumTotal.ToString("#,##0.00");//零售金额
                lblWholesaleSum.Text = m_objStatValue.m_decWholesaleSumTotal.ToString("#,##0.00");//批发金额
            }


            if (radioButton1.Checked)
            {
                if (dtbResult.Rows.Count > 0)
                {
                    DataRow[] rows = dtbResult.Select("availagross_int <> 0");
                    dtbTem = dtbResult.Clone();
                    for (int intRow = 0; intRow < rows.Length; intRow++)
                    {
                        dtbTem.Rows.Add(rows[intRow].ItemArray);
                    }
                    dtgLeechdomList.DataSource = dtbTem;
                }
                else
                {
                    dtgLeechdomList.DataSource = dtbResult;
                }
            }
            else if (radioButton2.Checked)
            {
                if (dtbResult.Rows.Count > 0)
                {
                    DataRow[] rows = dtbResult.Select("endamount_int <> 0 and availagross_int =0");

                    dtbTem = dtbResult.Clone();
                    for (int intRow = 0; intRow < rows.Length; intRow++)
                    {
                        dtbTem.Rows.Add(rows[intRow].ItemArray);
                    }
                    dtgLeechdomList.DataSource = dtbTem;
                }
                else
                {
                    dtgLeechdomList.DataSource = dtbResult;
                }
                displayRecordNo();

            }
        }//end
        #endregion

        #region 显示药品字典最小元素信息查询窗体


        /// <summary>
        /// 在药品框中按回车键后，显示药典查询窗口
        /// </summary>
        private void m_mthPopupWindow()
        {
            long lngRes = 0;
            if (cboStorage.Text.Trim().Length == 0)
            {
                MessageBox.Show("必须选择药库!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            //clsDomainController_StorageDetailQuery objDomain = new clsDomainController_StorageDetailQuery();

            //调用Com+服务端
            lngRes = objDomain.m_lngGetBaseMedicine(m_txtMedicineCode.Text.Trim(), m_objStorageBseArr[cboStorage.SelectedIndex].MEDICINEROOMID, out  m_dtbMedicinDict);

            if (lngRes > 0)
            {
                m_mthShowQueryMedicineForm(m_txtMedicineCode.Text.Trim());
            }
        }

        /// <summary>
        /// 显示药品字典最小元素信息查询窗体
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon)
        {
           if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(this.m_dtbMedicinDict);
                this.Controls.Add(m_ctlQueryMedicint);
            }
            

            m_ctlQueryMedicint.Visible = true;

            int X = groupBox1.Location.X + m_txtMedicineCode.Location.X;
            int Y = groupBox1.Location.Y + m_txtMedicineCode.Location.Y + m_txtMedicineCode.Height;// -m_ctlQueryMedicint.Size.Height;


            m_ctlQueryMedicint.Location = new System.Drawing.Point(X, Y);

            m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);

            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                m_txtMedicineCode.Text = "";

                m_objMedicineBase.m_strMedicineID = "";
                m_objMedicineBase.m_strAssistCode = "";
                m_objMedicineBase.m_strMedicineName = "";
                m_objMedicineBase.m_strMedSpec = "";
                m_txtMedicineCode.Focus();
                return;
            }
            m_txtMedicineCode.Text = MS_VO.m_strMedicineName;

            m_objMedicineBase.m_strMedicineID = MS_VO.m_strMedicineID;
            m_objMedicineBase.m_strAssistCode = MS_VO.m_strMedicineCode;
            m_objMedicineBase.m_strMedicineName = MS_VO.m_strMedicineName;
            m_objMedicineBase.m_strMedSpec = MS_VO.m_strMedicineSpec;



            cboMedicineType.Focus();
        }
        #endregion






        //#region 在设计时调整DATAGRIDVIEW的列宽度
        //private void dtgLeechdomList_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        //{
        //    label1.Text = "Column Index" + e.Column.Index.ToString() + "     width:" + dtgLeechdomList.Columns[e.Column.Index].Width.ToString();
        //}
        //#endregion


        #region “m_txtMedicineCode”文本框的“KeyUp”事件
        /// <summary>
        /// “m_txtMedicineCode”文本框的“KeyUp”事件
        /// 用于激活药品字典的查询窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_txtMedicineCode_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    m_mthPopupWindow();
                    break;

            }
        }

        #endregion


        #region “m_txtMedicineCode”文本框的“LostFocus”事件
        /// <summary>
        /// “m_txtMedicineCode”文本框的“LostFocus”事件
        /// 实现当按回车键后焦点移到下一个控件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_txtMedicineCode_LostFocus(object sender, EventArgs e)
        {
                //throw new Exception("The method or operation is not implemented.");
            cboMedicineType.Focus();
        }
        #endregion

        #region 实现按回车键移动焦点
        private void cboMedicineType_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    radZeroStorage.Focus();
                    break;
            }
        }

        private void cboStorage_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    txtAbateBeginDate.Focus();
                    break;
            }
        }

        private void txtAbateBeginDate_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    txtAbateEndDate.Focus();
                    break;
            }
        }

        private void txtAbateEndDate_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    m_txtMedicineCode.Focus();
                    break;
            }
        }

        private void chkZeroStorage_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    rdbStat.Focus();
                    break;
            }
        }

        private void rdbStat_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    rdbList.Focus();
                    break;
            }
        }

        private void rdbList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    cboStorage.Focus();
                    break;
            }
        }

        #endregion


        #region 校验日期
        /// <summary>
        /// “txtAbateEndDate”文本框的“LostFocus”事件
        /// 实现日期校验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void txtAbateEndDate_LostFocus(object sender, EventArgs e)
        {
            if ((txtAbateBeginDate.Text.Trim().Length == 11) && (txtAbateEndDate.Text.Trim().Length == 11))
            {
                string strDateBegin = txtAbateBeginDate.Text;
                strDateBegin = Convert.ToDateTime(strDateBegin).Year.ToString().Trim() + "-" +
                                Convert.ToDateTime(strDateBegin).Month.ToString().Trim().PadLeft(2, '0') + "-" +
                                Convert.ToDateTime(strDateBegin).Day.ToString().Trim().PadLeft(2, '0');
                string strDateEnd = txtAbateEndDate.Text;
                strDateEnd = Convert.ToDateTime(strDateEnd).Year.ToString().Trim() + "-" +
                                Convert.ToDateTime(strDateEnd).Month.ToString().Trim().PadLeft(2, '0') + "-" +
                                Convert.ToDateTime(strDateEnd).Day.ToString().Trim().PadLeft(2, '0');

                if ((Convert.ToDateTime(strDateBegin)) > (Convert.ToDateTime(strDateEnd)))
                {
                    DialogResult tmpResult = MessageBox.Show("开始日期必须小于结束日期！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtAbateBeginDate.Focus();
                }
            }
        }

        #endregion


        private void cmdQuery_Click(object sender, EventArgs e)
        {
            m_mthGetMedicineDetail();
            
            displayRecordNo();            
            m_dicStorageRack.Clear();
        }

        #region 根据药房实际货架绑定货架
        /// <summary>
        /// 根据药房实际货架绑定货架
        /// </summary>
        internal void m_mthBindStorageRack()
        {
            long lngRes = 0;
            comculumn.DataSource = null;
            m_dtbStorageRack.Clear();

            if (cboStorage.Text != "")
            {
                try
                {
                    lngRes = objDomain.m_lngGetStorageRack(cboStorage.Text, out m_dtbStorageRack);

                    if (lngRes > 0)
                    {
                        if (m_dtbStorageRack.Rows.Count > 0)
                        {
                            comculumn.DataSource = m_dtbStorageRack;
                            comculumn.ValueMember = "storagerackid_chr";
                            comculumn.DisplayMember = "STORAGERACKNAME_VCHR";
                        }
                    }
                }
                catch (Exception objEx)
                {
                    MessageBox.Show(objEx.Message, "货架加载出错", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        #endregion

        #region 绑定可供标志
        /// <summary>
        /// 绑定可供标志
        /// </summary>
        internal void m_mthBindStorageProvide()
        {
            comculumnprovide.DataSource = null;
            m_dtbStorageProvide.Clear();

            try
            {               
                m_dtbStorageProvide.Columns.Add("canprovide",typeof(Int16));
                m_dtbStorageProvide.Columns.Add("canprovidename",typeof(string));
                m_dtbStorageProvide.Rows.Add(0, "可供");
                m_dtbStorageProvide.Rows.Add(1, "不可供");

                comculumnprovide.DataSource = m_dtbStorageProvide;
                comculumnprovide.ValueMember = "canprovide";
                comculumnprovide.DisplayMember = "canprovidename";

            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message, "货架加载出错", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
           
        }
        #endregion

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void cboMedicineType_GotFocus(object sender, EventArgs e)
        {
            //获取药品类型
            //GetMedicineType();
        }

        void cboStorage_GotFocus(object sender, EventArgs e)
        {
            //获取药库基本信息
            //GetStorageBse();
        }

        private void cboStorage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取药品类型
            GetMedicineType();
        }

        private void txtAbateEndDate_Enter(object sender, EventArgs e)
        {

        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (dtbTem == null || dtbTem.Rows.Count <= 0)
            {
                MessageBox.Show("没有可打印数据！", "库存查询", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmStorageQueryReport frmReport = new frmStorageQueryReport();
            frmReport.m_strReportName = this.m_strReportName;
            frmReport.p_dtbVal = dtbTem;
            frmReport.p_strStorageName = cboStorage.Text;
            frmReport.m_dblCallSum = Convert.ToDouble(lblCallSum.Text);
            frmReport.m_dblRetailSum = Convert.ToDouble(lblRetailSum.Text);
            
            frmReport.ShowDialog();
        }
        /// <summary>
        /// 导出至Excel
        /// </summary>
        private void m_cmdExport_Click(object sender, EventArgs e)
        {
         
       

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出Excel文件到";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Stream myStream;
            myStream = saveFileDialog.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
            string str = "";
            try
            {
                //添加列标题

                for (int iOr = 0; iOr < dtgLeechdomList.ColumnCount; iOr++)
                {
                    if (iOr > 0)
                    {
                        str += "\t";
                    }
                    str += dtgLeechdomList.Columns[iOr].HeaderText;
                }
                sw.WriteLine(str);
                //添加行文本
                StringBuilder objStrBuilder = null;
                for (int iOr = 0; iOr < dtgLeechdomList.Rows.Count; iOr++)
                {
                    objStrBuilder = new StringBuilder();
                    for (int jOr = 0; jOr < dtgLeechdomList.Columns.Count; jOr++)
                    {
                        if (jOr > 0)
                        {
                            objStrBuilder.Append("\t");
                        }
                        objStrBuilder.Append(dtgLeechdomList.Rows[iOr].Cells[jOr].Value.ToString());
                    }
                    sw.WriteLine(objStrBuilder);

                }
                MessageBox.Show("导出成功！", "药品记录", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sw.Close();
                myStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }

        private void chkZeroStorage_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rdbList_CheckedChanged(object sender, EventArgs e)
        {
            m_mthGetMedicineDetail();
            radioButton1.Checked = true;
        }

        private void rdbList_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void rdbStat_MouseUp(object sender, MouseEventArgs e)
        {
            m_mthGetMedicineDetail();
            if (dtbResult == null)
            {
                return;
            }
            if (dtbResult.Rows.Count > 0)
            {
                DataRow[] rows = dtbResult.Select("availagross_int <> 0");

                dtbTem = dtbResult.Clone();
                for (int intRow = 0; intRow < rows.Length; intRow++)
                {
                    dtbTem.Rows.Add(rows[intRow].ItemArray);
                }
                dtgLeechdomList.DataSource = dtbTem;
                intRecordCount = rows.Length;                
            }
            else
            {
                dtgLeechdomList.DataSource = dtbResult;
                intRecordCount = 0;                
            }
            displayRecordNo();
        }

        private void chkZeroStorage_MouseUp(object sender, MouseEventArgs e)
        {
            m_mthGetMedicineDetail();
            dtbTem = dtbResult;
            dtgLeechdomList.DataSource = dtbTem;
            displayRecordNo();
        }

        private void radioButton1_MouseUp(object sender, MouseEventArgs e)
        {
            //m_mthGetMedicineDetail();
            if (dtbResult.Rows.Count > 0)
            {
                DataRow[] rows = dtbResult.Select("availagross_int <> 0");

                dtbTem = dtbResult.Clone();
                for (int intRow = 0; intRow < rows.Length; intRow++)
                {
                    dtbTem.Rows.Add(rows[intRow].ItemArray);
                }
                dtgLeechdomList.DataSource = dtbTem;
            }
            else
            {
                dtgLeechdomList.DataSource = dtbResult;
            }
            displayRecordNo();
        }

        private void radioButton2_MouseUp(object sender, MouseEventArgs e)
        {
            m_mthGetMedicineDetail();
            if (dtbResult.Rows.Count > 0)
            {
                DataRow[] rows = dtbResult.Select("endamount_int <> 0 and availagross_int =0");

                dtbTem = dtbResult.Clone();
                for (int intRow = 0; intRow < rows.Length; intRow++)
                {
                    dtbTem.Rows.Add(rows[intRow].ItemArray);
                }
                dtgLeechdomList.DataSource = dtbTem;
            }
            else
            {
                dtgLeechdomList.DataSource = dtbResult;
            }
            displayRecordNo();
            

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radZeroStorage_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            dtgLeechdomList.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
            if (m_dicStorageRack.Count > 0)
            {
                if (objDomain.m_lngSaveStorageRack(m_dicStorageRack) > 0)
                {
                    m_dicStorageRack.Clear();
                }
            }
            else
            {
                MessageBox.Show("没有修改货架！", "药房货架设置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dtgLeechdomList.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
            if (m_dicStorageProvide.Count > 0)
            {
                if (objDomain.m_lngSaveStorageProvide(m_dicStorageProvide) > 0)
                {
                    m_dicStorageProvide.Clear();
                }
            }
            else
            {
                MessageBox.Show("没有修改可供标志！", "药房可供标志设置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dtgLeechdomList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dtgLeechdomList["colMedicineID", e.RowIndex].Value))//药品号
                && !string.IsNullOrEmpty(Convert.ToString(dtgLeechdomList["colStorageRackID", e.RowIndex].Value)))//货架
            {
                if (!m_dicStorageRack.ContainsKey(dtgLeechdomList["colMedicineID", e.RowIndex].Value.ToString() + dtgLeechdomList["colLotNo", e.RowIndex].Value.ToString()))
                {
                    m_dicStorageRack.Add(dtgLeechdomList["colMedicineID", e.RowIndex].Value.ToString() + dtgLeechdomList["colLotNo", e.RowIndex].Value.ToString(), Convert.ToString(dtgLeechdomList["colStorageRackID", e.RowIndex].Value));
                }
                else
                {
                    m_dicStorageRack[dtgLeechdomList["colMedicineID", e.RowIndex].Value.ToString() + dtgLeechdomList["colLotNo", e.RowIndex].Value.ToString()] = Convert.ToString(dtgLeechdomList["colStorageRackID", e.RowIndex].Value);
                }
            }
            if (!string.IsNullOrEmpty(Convert.ToString(dtgLeechdomList["colMedicineID", e.RowIndex].Value))//药品号
                && !string.IsNullOrEmpty(Convert.ToString(dtgLeechdomList["colStorageProvide", e.RowIndex].Value)))//可供标志
            {
                if (!m_dicStorageProvide.ContainsKey(dtgLeechdomList["colMedicineID", e.RowIndex].Value.ToString() + dtgLeechdomList["colLotNo", e.RowIndex].Value.ToString()))
                {
                    m_dicStorageProvide.Add(dtgLeechdomList["colMedicineID", e.RowIndex].Value.ToString() + dtgLeechdomList["colLotNo", e.RowIndex].Value.ToString(), Convert.ToString(dtgLeechdomList["colStorageProvide", e.RowIndex].Value));
                }
                else
                {
                    m_dicStorageProvide[dtgLeechdomList["colMedicineID", e.RowIndex].Value.ToString() + dtgLeechdomList["colLotNo", e.RowIndex].Value.ToString()] = Convert.ToString(dtgLeechdomList["colStorageProvide", e.RowIndex].Value);
                }
            }
        }

        private void dtgLeechdomList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }
    }

    #endregion

}