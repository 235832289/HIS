using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 病人打印条码排序窗体层
    /// </summary>
    public partial class frmLisBarcodeSort : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 变量
        /// <summary>
        /// 控制层
        /// </summary>
        clsCtl_LisBarcodeSort m_objController;
        /// <summary>
        /// 是否打印血液类样本的条码 true=是，false=否
        /// </summary>
        internal bool m_blnIsBlood = false;
        /// <summary>
        /// 6002参数信息，血制品打印检验条码样本类型ID，多个用;分开
        /// </summary>
        internal string m_strParmBlood = null;
        /// <summary>
        /// 6007参数信息，非血制品打印检验条码样本类型ID，多个用;分开
        /// </summary>
        internal string m_strParmBloodNo = null;
        /// <summary>
        /// XML文档，用来保存在本地的顺序
        /// </summary>
        internal XmlDocument m_xmlBarcodeSort = null;
        /// <summary>
        /// DataGridView的数据源
        /// </summary>
        internal DataTable m_dtBaricodeSort = null;
        /// <summary>
        /// 登录员工ID
        /// </summary>
        internal string m_strLoginID = null;
        #endregion

        #region 构造函数
        public frmLisBarcodeSort()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            m_objController = new clsCtl_LisBarcodeSort();
            m_objController.Set_GUI_Apperance(this);
        }
        #endregion
        
        #region 外部接口

        /// <summary>
        /// 0 全部; 1 血制品; 2 非血制品
        /// </summary>
        internal decimal BizType { get; set; }

        /// <summary>
        /// 外部调用
        /// </summary>
        /// <param name="bizType"></param>
        public void Show2(string bizType)
        {
            this.BizType = Convert.ToDecimal(bizType);
            this.Show();
            if (bizType == "0")
            {
                this.Text += "";
            }
            else if (bizType == "1")
            {
                this.Text += " - 血制品";
            }
            else if (bizType == "2")
            {
                this.Text += " - 非血制品";
            }
            else
            {
                this.Text += "";
            }
        }
        #endregion
        
        private void frmLisBarcodeSort_Load(object sender, EventArgs e)
        {
            m_dgBarcodeSort.AutoGenerateColumns = false;
            m_dtToDate.Value = DateTime.Now;
            m_dtFromDate.Value = DateTime.Now.AddDays(-1);
            m_dtBaricodeSort = new DataTable();
            m_strLoginID = this.LoginInfo.m_strEmpID;
            m_txtLoginEmp.Text = this.LoginInfo.m_strEmpName;
            DataColumn[] objColumnArr = new DataColumn[] { new DataColumn("PatientCard", typeof(string)), new DataColumn("PatientName", typeof(string)), new DataColumn("PatientSex", typeof(string)), new DataColumn("PatientAge", typeof(string)), new DataColumn("DateTime", typeof(DateTime)) };
            m_dtBaricodeSort.Columns.AddRange(objColumnArr);

            try
            {
                string strPath = Application.StartupPath + @"\LIS_GUI.dll.config";
                System.Configuration.ConfigXmlDocument appConfig = new System.Configuration.ConfigXmlDocument();
                appConfig.Load(strPath);
                string strIsBlood = appConfig["configuration"]["appSettings"].SelectSingleNode("add[@key=\"IsBlood\"]").Attributes["value"].Value.ToString();
                if (strIsBlood == "1")
                {
                    m_blnIsBlood = true;
                }
                else
                {
                    m_blnIsBlood = false;
                }
                clsLisMainSmp.s_obj.m_lngGetSysParm("6002", out m_strParmBlood);
                clsLisMainSmp.s_obj.m_lngGetSysParm("6007", out m_strParmBloodNo);
                m_xmlBarcodeSort = new XmlDocument();
                m_xmlBarcodeSort.Load(Application.StartupPath + @"\PatientBarcodeSort.XML");
                m_mthGetXMLData(m_xmlBarcodeSort);

            }
            catch (Exception objEx)
            {
                MessageBox.Show(this, objEx.Message, "检验条码打印排序提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        #region 获取XML的数据加载到DataTable中
        /// <summary>
        /// 获取XML的数据加载到DataTable中
        /// </summary>
        /// <param name="p_xmlDocument"></param>
        internal void m_mthGetXMLData(XmlDocument p_xmlDocument)
        {
            if (p_xmlDocument == null)
            {
                return;
            }
            XmlNodeList xmlChileNodeList = p_xmlDocument.SelectSingleNode("Sort").ChildNodes;
            DataRow drTemp = null;
            foreach (XmlNode objNode in xmlChileNodeList)
            {
                if (objNode.Name == "Item")
                {
                    drTemp = m_dtBaricodeSort.NewRow();
                    foreach (XmlNode node in objNode.ChildNodes)
                    {
                        switch (node.Name)
                        {
                            case "PatientCard":
                                drTemp["PatientCard"] = node.InnerText;
                                break;
                            case "DateTime":
                                try
                                {
                                    drTemp["DateTime"] = Convert.ToDateTime(node.InnerText);
                                }
                                catch
                                {
                                    continue;
                                }
                                break;
                            case "PatientName":
                                drTemp["PatientName"] = node.InnerText;
                                break;
                            case "PatientSex":
                                drTemp["PatientSex"] = node.InnerText;
                                break;
                            case "PatientAge":
                                drTemp["PatientAge"] = node.InnerText;
                                break;
                        }
                    }
                    m_dtBaricodeSort.Rows.Add(drTemp);
                    m_dtBaricodeSort.AcceptChanges();
                }
            }
            if (m_dtBaricodeSort.Rows.Count > 0)
            {
                DataTable dtResult = m_dtBaricodeSort.Copy();
                DataView dvTemp = dtResult.DefaultView;
                dvTemp.Sort = "DateTime asc";
                m_dtBaricodeSort.Rows.Clear();
                m_dtBaricodeSort = dvTemp.ToTable();
                m_dgBarcodeSort.DataSource = null;
                m_dgBarcodeSort.DataSource = m_dtBaricodeSort;
            }
        }
        #endregion

        private void m_dgBarcodeSort_SelectionChanged(object sender, EventArgs e)
        {
            m_objController.m_mthGetCheckContent();
        }

        private void m_dgBarcodeSort_DoubleClick(object sender, EventArgs e)
        {
            m_objController.Print();     //.m_mthPrint();
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            m_objController.Print();     //.m_mthPrint();
        }

        private void m_btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_btnRemove_Click(object sender, EventArgs e)
        {
            m_objController.m_mthDeleteRow();
        }

        private void m_btnLogin_Click(object sender, EventArgs e)
        {
            SubmitLogin();
        }

        private void SubmitLogin()
        {
            string empid = "";
            string strEmpName = null;
            DialogResult dlg = com.digitalwave.iCare.gui.HIS.clsPublic.m_dlgConfirm(out empid, out strEmpName);
            if (dlg == DialogResult.Yes)
            {
                this.m_strLoginID = empid;
                m_txtLoginEmp.Text = strEmpName;
            }
            else
            {
                m_strLoginID = LoginInfo.m_strEmpID;
                m_txtLoginEmp.Text = LoginInfo.m_strEmpName;
            }
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            SubmitLogin();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                string cardNo = string.Empty;
                if (m_txtPatientCard.Text.Trim().Length > 0)
                {
                    cardNo = m_txtPatientCard.Text.Trim();
                    cardNo = cardNo.PadLeft(10, '0');
                    m_txtPatientCard.Text = cardNo;
                }
                else if (txtWechatCode.Text.Trim().Length > 0)
                {
                    cardNo = txtWechatCode.Text.Trim();
                    cardNo = (new clsDomainController_ApplicationManage()).GetCardNoByRecipeId(cardNo);
                    if (string.IsNullOrEmpty(cardNo)) return false;
                }
                else
                {
                    return false;
                }
                if (m_bgWorker.IsBusy)
                {
                    m_bgWorker.CancelAsync();
                    return false;
                }
                m_bgWorker.RunWorkerAsync(cardNo);
            }
            else if (keyData == Keys.F8)
            {
                m_objController.Print();     //.m_mthPrint();
            }
            else
            {
                string str = null;
                switch (keyData)
                {
                    case Keys.D0:
                        str = "0";
                        break;
                    case Keys.D1:
                        str = "1";
                        break;
                    case Keys.D2:
                        str = "2";
                        break;
                    case Keys.D3:
                        str = "3";
                        break;
                    case Keys.D4:
                        str = "4";
                        break;
                    case Keys.D5:
                        str = "5";
                        break;
                    case Keys.D6:
                        str = "6";
                        break;
                    case Keys.D7:
                        str = "7";
                        break;
                    case Keys.D8:
                        str = "8";
                        break;
                    case Keys.D9:
                        str = "9";
                        break;
                    case Keys.NumPad0:
                        str = "0";
                        break;
                    case Keys.NumPad1:
                        str = "1";
                        break;
                    case Keys.NumPad2:
                        str = "2";
                        break;
                    case Keys.NumPad3:
                        str = "3";
                        break;
                    case Keys.NumPad4:
                        str = "4";
                        break;
                    case Keys.NumPad5:
                        str = "5";
                        break;
                    case Keys.NumPad6:
                        str = "6";
                        break;
                    case Keys.NumPad7:
                        str = "7";
                        break;
                    case Keys.NumPad8:
                        str = "8";
                        break;
                    case Keys.NumPad9:
                        str = "9";
                        break;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void m_bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null)
            {
                return;
            }
            if (m_bgWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            m_objController.m_mthQuery();
        }

        private void m_txtPatientCard_TextChanged(object sender, EventArgs e)
        {
            if (m_txtPatientCard.Text.Trim() == string.Empty) return;
            txtWechatCode.Text = string.Empty;
        }

        private void txtWechatCode_TextChanged(object sender, EventArgs e)
        {
            if (txtWechatCode.Text.Trim() == string.Empty) return;
            m_txtPatientCard.Text = string.Empty;
        }
    }
}