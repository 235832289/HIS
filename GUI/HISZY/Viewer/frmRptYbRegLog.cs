using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// frmRptYbRegLog
    /// </summary>
    public partial class frmRptYbRegLog : Form
    {
        #region ctor
        /// <summary>
        /// ctor
        /// </summary>
        public frmRptYbRegLog()
        {
            InitializeComponent();
        }
        #endregion

        #region 变量.属性

        /// <summary>
        /// 行政区域.字典
        /// </summary>
        Dictionary<string, string> dicRegionCode { get; set; }

        /// <summary>
        /// 科室ID
        /// </summary>
        List<string> lstDeptId { get; set; }

        #endregion

        #region 方法

        #region Init
        /// <summary>
        /// Init
        /// </summary>
        void Init()
        {
            this.dicRegionCode = new Dictionary<string, string>();
            this.dicRegionCode.Add("4400", "广东省");
            this.dicRegionCode.Add("4401", "广州市");
            this.dicRegionCode.Add("4402", "韶关市");
            this.dicRegionCode.Add("4403", "深圳市");
            this.dicRegionCode.Add("4404", "珠海市");
            this.dicRegionCode.Add("4405", "汕头市");
            this.dicRegionCode.Add("4406", "佛山市");
            this.dicRegionCode.Add("4407", "江门市");
            this.dicRegionCode.Add("4408", "湛江市");
            this.dicRegionCode.Add("4409", "茂名市");
            this.dicRegionCode.Add("4412", "肇庆市");
            this.dicRegionCode.Add("4413", "惠州市");
            this.dicRegionCode.Add("4414", "梅州市");
            this.dicRegionCode.Add("4415", "汕尾市");
            this.dicRegionCode.Add("4416", "河源市");
            this.dicRegionCode.Add("4417", "阳江市");
            this.dicRegionCode.Add("4418", "清远市");
            this.dicRegionCode.Add("4419", "东莞市");
            this.dicRegionCode.Add("4420", "中山市");
            this.dicRegionCode.Add("4451", "潮州市");
            this.dicRegionCode.Add("4452", "揭阳市");
            this.dicRegionCode.Add("4453", "云浮市");

            this.lstDeptId = new List<string>();
            this.cboType.SelectedIndex = 0;
            this.dteRq1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            this.dwRep.LibraryList = Application.StartupPath + "\\pbwindow.pbl";
            this.dwRep.DataWindowObject = "d_bih_sbreg";

        }
        #endregion

        #region Stat
        /// <summary>
        /// Stat
        /// </summary>
        void Stat()
        {
            string beginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string endDate = this.dteRq2.Value.ToString("yyyy-MM-dd");
            if (Convert.ToDateTime(beginDate + " 00:00:01") > Convert.ToDateTime(endDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string deptIdArr = string.Empty;
            if (this.lstDeptId.Count > 0)
            {
                foreach (string deptid in this.lstDeptId)
                {
                    deptIdArr += "'" + deptid + "',";
                }
                deptIdArr = deptIdArr.TrimEnd(',');
            }

            //全部
            //医疗
            //生育
            //工伤
            //省内-异地就医
            //省外-异地就医
            int sbTypeId = this.cboType.SelectedIndex;
            if (sbTypeId == 2) sbTypeId = 4;
            else if (sbTypeId == 3) sbTypeId = 2;
            else if (sbTypeId == 4) sbTypeId = 5;
            else if (sbTypeId == 5) sbTypeId = 6;

            try
            {
                this.dwRep.SetRedrawOff();
                this.dwRep.Reset();
                clsPublic.PlayAvi("数据查询中，请稍候...");
                clsDcl_Report rpt = new clsDcl_Report();
                DataTable dtResult = rpt.GetRptSbRegister(beginDate, endDate, deptIdArr);
                rpt = null;
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    Dictionary<int, int> dicNum = new Dictionary<int, int>();
                    dicNum.Add(1, 0);
                    dicNum.Add(2, 0);
                    dicNum.Add(4, 0);
                    dicNum.Add(5, 0);
                    dicNum.Add(6, 0);
                    string typeId = string.Empty;
                    string cbdId = string.Empty;
                    foreach (DataRow dr in dtResult.Rows)
                    {
                        int flagId = 0;
                        typeId = dr["zylb_vchr"].ToString();
                        cbdId = (dr["cbdtcqbm"] == DBNull.Value || dr["cbdtcqbm"].ToString().Trim() == string.Empty) ? "" : dr["cbdtcqbm"].ToString().Trim();
                        if (cbdId.Length < 4 || cbdId.StartsWith("4419"))        // 东莞市
                        {
                            if (typeId == "1")              // 1-医疗住院
                                flagId = 1;
                            else if (typeId == "2")         // 2-工伤住院
                                flagId = 2;
                            else if (typeId == "4")         // 4-生育住院
                                flagId = 4;
                            else
                                flagId = 1;
                        }
                        else
                        {
                            cbdId = cbdId.Substring(0, 4);
                            if (this.dicRegionCode.ContainsKey(cbdId))      // 省内
                                flagId = 5;
                            else  // 省外
                                flagId = 6;
                        }
                        dr["flag"] = flagId;
                        dicNum[flagId]++;
                    }
                    int rowIndex = 0;
                    string typeName = string.Empty;
                    DataView dv = new DataView(dtResult);
                    dv.Sort = "flag asc";
                    DataTable dtTmp = dv.ToTable();
                    foreach (DataRow dr in dtTmp.Rows)
                    {
                        typeId = dr["flag"].ToString();
                        if (typeId == "1")
                            typeName = "医疗";
                        else if (typeId == "2")
                            typeName = "工伤";
                        else if (typeId == "4")
                            typeName = "生育";
                        else if (typeId == "5")
                            typeName = "异地就医(省内)";
                        else if (typeId == "6")
                            typeName = "异地就医(省外)";
                        if (sbTypeId > 0)
                        {
                            if (sbTypeId != Convert.ToInt32(typeId)) continue;
                        }

                        DateTime inDate = Convert.ToDateTime(dr["inDate"].ToString());
                        DateTime regDate = dr["regDate2"] == DBNull.Value ? Convert.ToDateTime(dr["regDate"].ToString()) : Convert.ToDateTime(dr["regDate2"].ToString());
                        bool isB = regDate.Subtract(inDate).Days > 3 ? true : false;

                        rowIndex = this.dwRep.InsertRow();
                        this.dwRep.SetItemString(rowIndex, "col1", typeName);
                        this.dwRep.SetItemDecimal(rowIndex, "col2", dicNum[Convert.ToInt32(dr["flag"].ToString())]);
                        this.dwRep.SetItemString(rowIndex, "col3", dr["patName"].ToString());
                        this.dwRep.SetItemString(rowIndex, "col4", dr["sex_chr"].ToString());
                        this.dwRep.SetItemString(rowIndex, "col5", dr["birth_dat"] == DBNull.Value ? "" : clsCalculateAge.s_strCalAge(Convert.ToDateTime(dr["birth_dat"].ToString())));
                        this.dwRep.SetItemString(rowIndex, "col6", dr["ipNo"].ToString());
                        this.dwRep.SetItemString(rowIndex, "col7", dr["areaName"].ToString());
                        this.dwRep.SetItemString(rowIndex, "col8", dr["bedNo"].ToString());
                        this.dwRep.SetItemDecimal(rowIndex, "col9", dr["premoney"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["premoney"].ToString()));
                        this.dwRep.SetItemString(rowIndex, "col10", inDate.ToString("yyyy-MM-dd HH:mm"));
                        this.dwRep.SetItemString(rowIndex, "col11", regDate.ToString("yyyy-MM-dd HH:mm"));
                        this.dwRep.SetItemString(rowIndex, "col12", (isB ? "否" : "是"));
                        this.dwRep.SetItemString(rowIndex, "col13", dr["operName"].ToString());
                    }
                    if (this.dwRep.RowCount == 0)
                    {
                        MessageBox.Show("查无记录.");
                    }
                }
                else
                {
                    MessageBox.Show("查无记录.");
                }
                this.dwRep.Modify("t_date.text='" + beginDate + " 至 " + endDate + "'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                clsPublic.CloseAvi();
                this.dwRep.SetRedrawOn();
                this.dwRep.Refresh();
            }
        }
        #endregion

        #endregion

        #region 事件

        private void frmRptYbRegLog_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Stat();
        }

        private void btnDept_Click(object sender, EventArgs e)
        {
            frmAidDeptList fDept = new frmAidDeptList();
            if (fDept.ShowDialog() == DialogResult.OK)
            {
                this.lstDeptId.Clear();
                foreach (object item in fDept.DeptIDArr)
                {
                    this.lstDeptId.Add(item.ToString());
                }
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.dwRep.PrintProperties.Preview = !this.dwRep.PrintProperties.Preview;
            this.dwRep.PrintProperties.ShowPreviewRulers = this.dwRep.PrintProperties.Preview;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dwRep.RowCount > 0)
            {
                clsPublic.ExportDataWindow(this.dwRep, null);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dwRep, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
