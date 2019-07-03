using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// Advia2120 设置界面
    /// baojian.mo Create in 2007-10-19
    /// </summary>
    public partial class frmAdvia2120Config : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmAdvia2120Config()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// 数据库路径
        /// </summary>
        public string strDataPath = "";

        /// <summary>
        /// 图片库路径
        /// </summary>
        public string strPicPath = "";

        /// <summary>
        /// Access数库据连接器
        /// </summary>
        private OleDbConnection objConn = null;

        private clsDomainController_Advia2120 objDomain;

        /// <summary>
        /// ADVIA2120仪器代号
        /// </summary>
        private string strDeviceModelID = "002120";

        /// <summary>
        /// 配置文件的路径
        /// </summary>
        private string strConfigPath = Application.StartupPath + @"\LIS_GUI.dll.config";

        private void buttonXP1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                strDataPath = openFileDialog1.FileName;
                this.textBox1.Text = strDataPath;
            }
        }

        private void buttonXP3_Click(object sender, EventArgs e)
        {
            this.txtDeciveItem.Text = "";
            this.txtCheckItem.Text = "";
            this.buttonXP3.Tag = null;
            this.txtDeciveItem.Focus();
        }

        private void buttonXP2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog objfdb = new FolderBrowserDialog();
            objfdb.Description = "请选择ADVIA 2120保存图片的文件夹";
            objfdb.ShowNewFolderButton = true;
            objfdb.RootFolder = Environment.SpecialFolder.Desktop;
            DialogResult dlrResult = objfdb.ShowDialog();
            if (dlrResult == DialogResult.OK)
            {
                strPicPath = objfdb.SelectedPath;
                if (strPicPath != "")
                {
                    textBox2.Text = strPicPath;
                }
            }
        }

        private void frmAdvia2120Config_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Microsoft Office Access(*.mdb)|*.mdb|所有文件|*.*";
            objDomain = new clsDomainController_Advia2120();
            this.m_mthGetCheckCategory();
            this.m_mthClear();
            this.m_mthGetCheckItemDeviceCheckItem();
            this.textBox1.Text = strDataPath;
            this.textBox2.Text = strPicPath;
        }

        #region 获取仪器检验项目对应关系列表
        /// <summary>
        /// 获取仪器检验项目对应关系列表
        /// </summary>
        public void m_mthGetCheckItemDeviceCheckItem()
        {
            //一个检验项目属于一台仪器设备
            clsLisCheckItemDeviceCheckItem_VO[] objItemVOList = null;
            long lngRes = 0;
            lngRes = objDomain.m_lngGetCheckItemDeviceCheckItem(strDeviceModelID, out objItemVOList);

            if (lngRes > 0 && objItemVOList != null)
            {
                if (objItemVOList.Length > 0)
                {
                    ListViewItem objlvRelation = null;
                    for (int i1 = 0; i1 < objItemVOList.Length; i1++)
                    {
                        objlvRelation = new ListViewItem(objItemVOList[i1].m_strDEVICE_CHECK_ITEM_ID_CHR);
                        objlvRelation.SubItems.Add(objItemVOList[i1].m_strCHECK_ITEM_NAME_VCHR);
                        objlvRelation.SubItems.Add(objItemVOList[i1].m_strCHECK_ITEM_ENGLISH_NAME_VCHR);
                        objlvRelation.Tag = objItemVOList[i1];
                        this.listView2.Items.Add(objlvRelation);
                    }
                }
            }

        }
        #endregion

        private void cmdConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                System.Xml.XmlDocument xmlConfig = new System.Xml.XmlDocument();
                xmlConfig.Load(strConfigPath);
                foreach (System.Xml.XmlNode xn in xmlConfig.SelectSingleNode("configuration").ChildNodes)
                {
                    if (xn.LocalName == "adviaSettings")
                    {
                        foreach (System.Xml.XmlNode root in xn.ChildNodes)
                        {
                            if (root.NodeType == System.Xml.XmlNodeType.Element)
                            {
                                if (root.Attributes["key"].Value == "m_strDataPath")
                                {
                                    root.Attributes["value"].Value = this.strDataPath;
                                }
                                else if (root.Attributes["key"].Value == "m_strPicPath")
                                {
                                    root.Attributes["value"].Value = this.strPicPath;
                                }
                                else
                                { }
                            }
                        }
                        xmlConfig.Save(strConfigPath);
                        break;
                    }
                }                
            }
            catch (Exception)
            {

            }
            

            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_mthGetCheckItem();
        }

        #region 获得检验类别
        /// <summary>
        /// 获得检验类别
        /// </summary>
        private void m_mthGetCheckCategory()
        {
            this.comboBox1.Items.Clear();
            clsCheckCategory_VO[] objCategoryArr = null;
            long lngRes = objDomain.m_lngGetCheckCategory(out objCategoryArr);
            if (lngRes > 0 && objCategoryArr != null)
            {
                if (objCategoryArr.Length > 0)
                {
                    for (int i1 = 0; i1 < objCategoryArr.Length; i1++)
                    {
                        this.comboBox1.Items.Add(objCategoryArr[i1].m_strCheck_Category_Name);
                    }
                    this.comboBox1.Tag = objCategoryArr;
                }
                else
                {
                    this.comboBox1.Items.Clear();
                }
            }
            if (objCategoryArr.Length > 0)
                this.comboBox1.SelectedIndex = 0;
        }
        #endregion

        #region 获得检验设备
        /// <summary>
        /// 获得检验设备
        /// </summary>
        private void m_mthGetCheckItem()
        {
            if (this.comboBox1.Tag == null || this.comboBox1.SelectedIndex < 0)
                return;

            this.txtCheckItem.Text = "";
            this.listView3.Items.Clear();
            string strCategoryID = "";
            if (this.comboBox1.SelectedIndex >= 0)
            {
                strCategoryID = ((clsCheckCategory_VO[])this.comboBox1.Tag)[this.comboBox1.SelectedIndex].m_strCheck_Category_ID;
            }
            clsCheckItem_VO[] objResultArr = null;

            long lngRes = objDomain.m_lngGetCheckItemByCategoryID(strCategoryID, out objResultArr);

            if ((lngRes > 0) && (objResultArr != null))
            {
                if (objResultArr.Length > 0)
                {
                    ListViewItem lviItem = null;

                    for (int i1 = 0; i1 < objResultArr.Length; i1++)
                    {
                        lviItem = new ListViewItem(objResultArr[i1].m_strCheck_Item_Name);
                        lviItem.SubItems.Add(objResultArr[i1].m_strCheck_Item_English_Name);
                        lviItem.SubItems.Add(objResultArr[i1].m_strShortName);
                        lviItem.Tag = objResultArr[i1];
                        this.listView3.Items.Add(lviItem);
                    }
                }
                else
                {
                    this.listView3.Items.Clear();
                }
            }
        }
        #endregion

        private void listView3_DoubleClick(object sender, EventArgs e)
        {
            this.m_mthSetCheckItemRelation();
        }

        #region 获得检验类别
        /// <summary>
        /// 设置选择了的检验项目
        /// </summary>
        public void m_mthSetCheckItemRelation()
        {
            if (this.listView3.Items.Count <= 0 || this.listView3.SelectedItems.Count <= 0)
                return;

            clsCheckItem_VO objSelectedCheckItem = (clsCheckItem_VO)this.listView3.SelectedItems[0].Tag;
            string[] str = new string[3];
            str[0] = objSelectedCheckItem.m_strCheck_Item_ID;
            str[1] = objSelectedCheckItem.m_strCheck_Item_English_Name;
            str[2] = objSelectedCheckItem.m_strCheck_Item_Name;
            this.txtCheckItem.Tag = str;
            this.txtCheckItem.Text = objSelectedCheckItem.m_strCheck_Item_Name;
        }
        #endregion

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.TrimEnd().ToLower().LastIndexOf(".mdb") > 0) //&& this.listView1.Items.Count == 0)
            {
                string strConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDataPath + ";Persist Security Info=False;Jet OLEDB:DataBase Password='555000'";
                objConn = new OleDbConnection(strConnection);
                try
                {
                    objConn.Open();
                }
                catch (Exception)
                {
                    return;
                }

                string strSQL = @"select a.chr_itemcode, a.chr_itemname, a.num_itemid from item_set a order by a.num_itemid";
                DataTable dtItem = new DataTable();
                try
                {
                    OleDbDataAdapter objAdapter = new OleDbDataAdapter(strSQL, objConn);
                    objAdapter.Fill(dtItem);
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "读取仪器数据库项目列表失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                objConn.Close();
                if (dtItem.Rows.Count > 0)
                {
                    ListViewItem objlvItem = null;
                    DataRow objRow = null;
                    for (int i1 = 0; i1 < dtItem.Rows.Count; i1++)
                    {
                        objRow = dtItem.Rows[i1];
                        objlvItem = new ListViewItem(objRow["num_itemid"].ToString());
                        objlvItem.SubItems.Add(objRow["chr_itemname"].ToString());
                        objlvItem.SubItems.Add(objRow["chr_itemcode"].ToString());
                        objlvItem.Tag = objRow;                        
                        this.listView1.Items.Add(objlvItem);
                    }
                }
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            this.m_mthSetDeviceItem();
        }

        #region 获得仪器检验项目代号
        /// <summary>
        /// 设置选择了的仪器检验项目
        /// </summary>
        public void m_mthSetDeviceItem()
        {
            if (this.listView1.Items.Count <= 0 || this.listView1.SelectedItems.Count <= 0)
                return;

            DataRow dr = (DataRow)this.listView1.SelectedItems[0].Tag;
            string[] str = new string[3];
            str[0] = ((dr["num_itemid"].ToString().Length > 4) ? dr["num_itemid"].ToString().Substring(0, 4) : dr["num_itemid"].ToString());
            str[1] = dr["chr_itemname"].ToString();
            str[2] = strDeviceModelID;
            this.txtDeciveItem.Tag = str;
            this.txtDeciveItem.Text = dr["chr_itemcode"].ToString();
        }
        #endregion

        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            if (this.ActiveControl == this.listView2)
            {
                if (this.listView2.Items.Count <= 0 || this.listView2.SelectedItems.Count <= 0)
                    return;

                if (this.listView2.SelectedItems[0].Tag != null)
                {
                    clsLisCheckItemDeviceCheckItem_VO objCheckItemDeviceCheckItem = (clsLisCheckItemDeviceCheckItem_VO)this.listView2.SelectedItems[0].Tag;
                    string[] str = new string[3];
                    this.txtDeciveItem.Text = objCheckItemDeviceCheckItem.m_strDEVICE_CHECK_ITEM_ID_CHR;
                    str[0] = objCheckItemDeviceCheckItem.m_strDEVICE_CHECK_ITEM_ID_CHR;
                    str[1] = "";
                    str[2] = strDeviceModelID;
                    this.txtDeciveItem.Tag = str;

                    str = new string[3];
                    this.txtCheckItem.Text = objCheckItemDeviceCheckItem.m_strCHECK_ITEM_NAME_VCHR;
                    str[0] = objCheckItemDeviceCheckItem.m_strCHECK_ITEM_ID_CHR;
                    str[1] = objCheckItemDeviceCheckItem.m_strCHECK_ITEM_ENGLISH_NAME_VCHR;
                    str[2] = objCheckItemDeviceCheckItem.m_strCHECK_ITEM_NAME_VCHR;
                    this.txtCheckItem.Tag = str;
                    this.buttonXP3.Tag = str[0];
                }
            }
        }        

        private void cmdSave_Click(object sender, EventArgs e)
        {
            this.m_mthDoSave();
        }

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        public void m_mthDoSave()
        {
            if (this.txtCheckItem.Tag == null)
            {
                MessageBox.Show("请选择检验项目名称！");
                return;
            }
            else if (this.txtDeciveItem.Tag == null)
            {
                MessageBox.Show("请输入设备项目名称！");
                return;
            }
            //一个检验项目属于一台仪器设备
            clsLisCheckItemDeviceCheckItem_VO[] objItemVOList = null;
            long lngRes = 0;
            lngRes = objDomain.m_lngGetCheckItemDeviceCheckItem("", out objItemVOList);
            string[] str = (string[])this.txtCheckItem.Tag;
            string strCheckItemID = str[0];
            if (lngRes > 0 && objItemVOList != null)
            {
                if (objItemVOList.Length > 0)
                {
                    for (int i = 0; i < objItemVOList.Length; i++)
                    {
                        if (strCheckItemID == objItemVOList[i].m_strCHECK_ITEM_ID_CHR)
                        {
                            MessageBox.Show("检验项目(" + strCheckItemID + ")" + this.txtCheckItem.Text + "已经被添加！");
                            return;
                        }
                    }
                }
            }
            if (this.buttonXP3.Tag == null)
            {
                m_mthAddNewCheckItemDeviceCheckItem();
            }
            else
            {
                m_mthModifyCheckItemDeviceCheckItem();
            }
        }
        #endregion

        #region 新增仪器检验项目与检验项目关系
        /// <summary>
        /// 新增仪器检验项目与检验项目关系
        /// </summary>
        private void m_mthAddNewCheckItemDeviceCheckItem()
        {             
			long lngRes = 0;
            string[] str = (string[])this.txtDeciveItem.Tag;
			clsLisCheckItemDeviceCheckItem_VO objRecord = new clsLisCheckItemDeviceCheckItem_VO();
            objRecord.m_strDEVICE_MODEL_ID_CHR = strDeviceModelID;
            objRecord.m_strDEVICE_CHECK_ITEM_ID_CHR = str[0];

            str = (string[])this.txtCheckItem.Tag;
            objRecord.m_strCHECK_ITEM_ID_CHR = str[0];
            objRecord.m_strOPERATORID_CHR = this.LoginInfo.m_strEmpID;
			lngRes = objDomain.m_lngAddNewCheckItemDeviceCheckItem(objRecord);
			if(lngRes > 0)
			{
                m_mthClear();                
                this.m_mthGetCheckItemDeviceCheckItem();
                MessageBox.Show(this, "保存成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}		
        }
        #endregion        

        #region 修改对应项目
        private void m_mthModifyCheckItemDeviceCheckItem()
        {
            long lngRes = 0;
            string[] str = (string[])this.txtDeciveItem.Tag;
            clsLisCheckItemDeviceCheckItem_VO objRecord = new clsLisCheckItemDeviceCheckItem_VO();
            objRecord.m_strDEVICE_MODEL_ID_CHR = strDeviceModelID;
            objRecord.m_strDEVICE_CHECK_ITEM_ID_CHR = str[0];

            str = (string[])this.txtCheckItem.Tag;
            objRecord.m_strCHECK_ITEM_ID_CHR = str[0]; ;
            objRecord.m_strOPERATORID_CHR = this.LoginInfo.m_strEmpID;
            string strSourceCheckItemID = this.buttonXP3.Tag.ToString().Trim();
            lngRes = objDomain.m_lngModifyCheckItemDeviceCheckItem(strSourceCheckItemID, objRecord);
            if (lngRes > 0)
            {
                m_mthClear();
                this.m_mthGetCheckItemDeviceCheckItem();
                MessageBox.Show(this, "修改成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 清空
        /// <summary>
        /// 清空
        /// </summary>
        public void m_mthClear()
        {
            this.txtCheckItem.Text = "";
            this.txtCheckItem.Tag = null;
            this.txtDeciveItem.Text = "";
            this.txtDeciveItem.Tag = null;
            this.buttonXP3.Tag = null;
            this.listView2.Items.Clear();
        }
        #endregion        

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            this.m_mthDelCheckItemDeviceCheckItem();
        }

        #region 删除仪器检验项目与检验项目关系
        /// <summary>
        /// 删除仪器检验项目与检验项目关系
        /// </summary>
        public void m_mthDelCheckItemDeviceCheckItem()
        {
            if (this.buttonXP3.Tag == null)
                return;
            long lngRes = 0;
            string strSourceCheckItemID = this.buttonXP3.Tag.ToString().Trim();
            lngRes = objDomain.m_lngDelCheckItemDeviceCheckItem(strSourceCheckItemID);
            if (lngRes > 0)
            {
                m_mthClear();
                this.m_mthGetCheckItemDeviceCheckItem();
            }
        }
        #endregion
    }
}