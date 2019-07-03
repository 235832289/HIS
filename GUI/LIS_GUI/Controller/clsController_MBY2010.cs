using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using System.Data.Odbc;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 酶标仪2010 逻辑层
    /// </summary>
    public class clsController_MBY2010 : com.digitalwave.GUI_Base.clsController_Base
    {
        private clsDcl_MBY2010 m_objDomain;

        private frmMBY2010 m_objViewer;

        private OleDbConnection objConn;

        #region 构造函数


        public clsController_MBY2010()
        {
            //
            // TODO: Add constructor logic here
            //
            m_objDomain = new clsDcl_MBY2010();
        }
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            this.m_objViewer = (frmMBY2010)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化窗体

        /// <summary>
        /// 初始化窗体

        /// </summary>
        public void m_mthInitFrom()
        {
            if (m_mthReamXml())
            {
                if (instrumentType == 0)
                {
                    this.m_objViewer.m_dtpQueryDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
                    //初始化检验项目

                    string strSQL = @"select testnumber, testname from tsitem order by testnumber";
                    objConn.Open();
                    OleDbDataAdapter objAdapter = new OleDbDataAdapter(strSQL, objConn);
                    DataTable dt = new DataTable();
                    objAdapter.Fill(dt);
                    objConn.Close();
                    this.m_objViewer.cboItem.Items.Add("全部");
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = null;
                        for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                        {
                            dr = dt.Rows[i1];
                            this.m_objViewer.cboItem.Items.Add(dr[1].ToString());
                        }
                        DataRow drAddRow = dt.NewRow();
                        drAddRow["testnumber"] = 0;
                        drAddRow["testname"] = "全部";
                        dt.Rows.Add(drAddRow);
                        this.m_objViewer.cboItem.Tag = dt;
                    }
                }
                else if (instrumentType == 1)
                {
                    this.m_objViewer.m_dtpQueryDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
                    if (strDeviceCode != string.Empty)
                    {
                        this.m_objViewer.txtMachineCode.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        this.m_objViewer.txtMachineCode.Text = strDeviceCode;
                        this.m_objViewer.txtMachineCode.Enabled = false;
                        this.m_objViewer.txtMachineCode.BackColor = System.Drawing.Color.FromArgb(255, 227, 198);
                        this.m_objViewer.txtMachineCode.ForeColor = System.Drawing.Color.Black;
                    }
                }
                else
                { }
            }
        }
        #endregion

        #region 读取xml获取数据库路径

        /// <summary>
        /// 读取xml获取数据库路径

        /// </summary>
        /// <returns></returns>
        private bool m_mthReamXml()
        {
            bool ret = false;
            string str = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
            try
            {
                System.Xml.XmlDocument xmlConfig = new System.Xml.XmlDocument();
                xmlConfig.Load(Application.StartupPath + "//LIS_GUI.dll.config");
                instrumentType = int.Parse(xmlConfig["configuration"]["mby2010Settings"].SelectSingleNode("add[@key=\"instrumentType\"]").Attributes["value"].Value);
                if (instrumentType == 0)
                {
                    str = str + xmlConfig["configuration"]["mby2010Settings"].SelectSingleNode("add[@key=\"objConn\"]").Attributes["value"].Value;
                    objConn = new OleDbConnection(str);
                    objConn.Open();
                    objConn.Close();
                    ret = true;
                }
                else if (instrumentType == 1)
                {
                    string strDSN = xmlConfig["configuration"]["mby2010Settings"].SelectSingleNode("add[@key=\"DSN\"]").Attributes["value"].Value;
                    string strUid = xmlConfig["configuration"]["mby2010Settings"].SelectSingleNode("add[@key=\"uid\"]").Attributes["value"].Value;
                    string strPwd = xmlConfig["configuration"]["mby2010Settings"].SelectSingleNode("add[@key=\"pwd\"]").Attributes["value"].Value;
                    strDSN = "DSN=" + strDSN + ";UID=" + strUid + ";PWD=" + strPwd;
                    strDeviceCode = xmlConfig["configuration"]["mby2010Settings"].SelectSingleNode("add[@key=\"code\"]").Attributes["value"].Value;
                    ret = true;
                }
                else
                { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.m_objViewer, ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return ret;
        }
        #endregion

        #region 根据条件读取数据
        /// <summary>
        /// 根据条件读取数据
        /// </summary>
        /// <returns></returns>
        public DataTable m_mthReadData()
        {
            if (instrumentType == 1)
            {
                return this.m_dtbGetDataFromOdbc();
            }
            string strSQL = @"select a.psampleid, b.testnumber, b.valuation, c.testname from psampleid a,pwells b,tsitem c 
                               where a.pidnr = b.pidnr and a.sidnr = b.sidnr and b.testnumber = c.testnumber";
            OleDbParameter objParam = null;
            objConn.Open();

            OleDbCommand objCmd = new OleDbCommand();
            objCmd.Connection = objConn;

            #region 生成查询条件

            if (this.m_objViewer.m_dtpQueryDate.Text != "")
            {
                strSQL += @" and b.date = :lis_date";
                objParam = new OleDbParameter("lis_date", OleDbType.DBDate);
                objParam.Value = this.m_objViewer.m_dtpQueryDate.Value;
                objCmd.CommandText = strSQL;
                objCmd.Parameters.Add(objParam);
            }

            if (this.m_objViewer.cboItem.Text != "" && this.m_objViewer.cboItem.Tag != null)
            {
                DataView dtvResult = ((DataTable)this.m_objViewer.cboItem.Tag).DefaultView;
                try
                {
                    int intTsNum = int.Parse(this.m_objViewer.cboItem.Text.Trim());
                    dtvResult.RowFilter = "testnumber = " + intTsNum;
                }
                catch (Exception)
                {
                    dtvResult.RowFilter = "testname like '" + this.m_objViewer.cboItem.Text.Trim() + "%'";
                }

                if (dtvResult.Count == 0)
                {
                    MessageBox.Show("你查找的项目不存在，请重新确定", "系统提示");
                    this.m_objViewer.cboItem.Focus();
                    this.m_objViewer.cboItem.SelectAll();
                    return null;
                }

                this.m_objViewer.cboItem.Text = dtvResult[0]["testname"].ToString();
                if (this.m_objViewer.cboItem.Text == "0" || this.m_objViewer.cboItem.Text == "全" || this.m_objViewer.cboItem.Text == "全部")
                {
                }
                else
                {
                    strSQL += @" and b.testnumber = :lis_itemid";
                    objParam = new OleDbParameter("lis_itemid", OleDbType.UnsignedTinyInt, 8);
                    objParam.Value = Convert.ToUInt16(dtvResult[0]["testnumber"]);
                    objCmd.CommandText = strSQL;
                    objCmd.Parameters.Add(objParam);
                }
            }

            if (this.m_objViewer.txtInitNum.Text != "")
            {
                strSQL += @" and a.psampleid like :lis_initNum";
                objParam = new OleDbParameter("lis_initNum", OleDbType.Char, 12);
                objParam.Value = this.m_objViewer.txtInitNum.Text.Trim() + "%";
                objCmd.CommandText = strSQL;
                objCmd.Parameters.Add(objParam);
            }
            #endregion

            objCmd.CommandText = strSQL + " order by a.psampleid";

            OleDbDataAdapter objAdapter = new OleDbDataAdapter(objCmd);
            System.Data.DataTable dt = new System.Data.DataTable();
            objAdapter.Fill(dt);
            objConn.Close();

            #region 查找样本号段
            if (this.m_objViewer.txtQueryRange.Text != "" && dt.Rows.Count > 0)
            {
                System.Collections.ArrayList FindArr = new System.Collections.ArrayList();
                FindArr = com.digitalwave.iCare.gui.HIS.clsPublic.m_ArrGettoken(this.m_objViewer.txtQueryRange.Text, ";");

                //重新合并dt                
                DataView dv = new DataView(dt);
                string strFind = "";
                int intIndex = 0;
                string strLeft = "";
                string strRight = "";
                DataTable dtTemp1 = new DataTable();   //临时dt
                dtTemp1 = dt.Clone();
                DataTable dtTmp2 = new DataTable();
                for (int i1 = 0; i1 < FindArr.Count; i1++)
                {
                    strFind = FindArr[i1].ToString();
                    intIndex = strFind.IndexOf('-');
                    if (intIndex > 0)    //样本号段
                    {
                        strLeft = strFind.Substring(0, intIndex).Trim();
                        strRight = strFind.Substring(intIndex + 1).Trim();
                        dv.RowFilter = "psampleid >= " + strLeft + " and psampleid <= " + strRight;
                    }
                    else   //单个样本号
                    {
                        dv.RowFilter = "psampleid = '" + strFind.Trim() + "'";
                    }
                    dtTmp2 = dv.ToTable();
                    dtTemp1.BeginLoadData();
                    for (int i2 = 0; i2 < dtTmp2.Rows.Count; i2++)
                    {
                        dtTemp1.LoadDataRow(dtTmp2.Rows[i2].ItemArray, true);
                    }
                    dtTemp1.EndLoadData();
                    dtTemp1.AcceptChanges();
                }
                dt.Rows.Clear();
                dt = dtTemp1;
            }
            #endregion

            return dt;
        }
        #endregion

        #region 插入报告单

        /// <summary>
        /// 插入报告单
        /// </summary>
        /// <param name="strMacCode"></param>
        public void m_mthInsertReport(string strMacCode)
        {
            long lngRes = 0;
            List<clsMBY2010VO> objResultArr = new List<clsMBY2010VO>();
            clsMBY2010VO objRes;

            if (this.m_objViewer.txtQueryRange.Text.Trim() != "")
            {
                if (dtAllRes == null)
                    dtAllRes = this.m_mthReadData();
                this.blnSch = false;
                DataTable dt = this.m_dtbFiltData(dtAllRes);
                DataRow dr = null;
                for (int i2 = 0; i2 < dt.Rows.Count; i2++)
                {
                    dr = dt.Rows[i2];
                    objRes = new clsMBY2010VO();
                    objRes.m_strDeviceId = strMacCode;   //设备代号
                    objRes.m_strCheckDate = dr["sampleda"].ToString();
                    objRes.m_strInstrumentName = dr["instrument"].ToString();
                    objRes.m_strItemCode = dr["testname"].ToString();
                    objRes.m_strItemName = dr["testname"].ToString();
                    objRes.m_strResult = dr["valuation"].ToString();
                    objRes.m_strSampleId = dr["psampleid"].ToString().PadLeft(3, '0');
                    objRes.m_strCheck_Item_Name = dr["testnumber"].ToString();
                    objRes.m_strOperator_ID = this.m_objViewer.LoginInfo.m_strEmpID;
                    objResultArr.Add(objRes);
                }
                dt = null;
            }
            else if (this.m_objViewer.lsvPatList.SelectedItems.Count > 0)
            {
                DataRow dr = null;
                List<clsMBY2010VO> objResVo = null;
                for (int i1 = 0; i1 < this.m_objViewer.lsvPatList.SelectedItems.Count; i1++)
                {
                    if (this.m_objViewer.lsvPatList.SelectedItems[i1].Tag != null)
                    {
                        objResVo = (List<clsMBY2010VO>)this.m_objViewer.lsvPatList.SelectedItems[i1].Tag;
                        for (int i2 = 0; i2 < objResVo.Count; i2++)
                        {
                            objRes = objResVo[i2];
                            objRes.m_strOperator_ID = this.m_objViewer.LoginInfo.m_strEmpID;
                            objResultArr.Add(objRes);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请输入或选择要插入的样本段", "系统提示");
                this.m_objViewer.txtQueryRange.Focus();
                return;
            }
            lngRes = this.m_objDomain.m_lngInsertReport(instrumentType, objResultArr, this.m_objViewer.datReportDate.Value);   //插入操作

            switch (lngRes)
            {
                case 1:
                    MessageBox.Show("插入数据成功！", "系统提示");
                    break;
                case 2:
                    MessageBox.Show("操作返回，请检查标本是否核收\r\n\r\n或检查该标本是否定义检验编号", "系统提示");
                    break;
                case 0:
                    MessageBox.Show("插入 0 条数据，请检查检验编号是否存在！", "系统提示");
                    break;
                case -1:
                    MessageBox.Show("插入数据失败，请检查数据是否合法！", "系统提示");
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Multiskan_Ascent 酶标仪接口程序
        /// <summary>
        /// 酶标仪型号
        /// </summary>
        public int instrumentType = 0;
        /// <summary>
        /// 酶标仪连接
        /// </summary>
        private string strDSN = "DSN=Lis2002;UID=DBA;PWD=thisisapig";
        /// <summary>
        /// 仪器代号
        /// </summary>
        private string strDeviceCode = "";
        /// <summary>
        /// 查询标识 false-过滤 true-查找
        /// </summary>
        public bool blnSch = true;
        /// <summary>
        /// 结果数据集
        /// </summary>
        internal DataTable dtAllRes = null;

        /// <summary>
        /// 测试连接
        /// </summary>
        public DataTable m_dtbGetDataFromOdbc()
        {
            OdbcConnection objCnn = new OdbcConnection(strDSN);
            OdbcCommand objCmd = null;
            DataTable dt = new DataTable();
            string strSQL = @"  SELECT labdetail.sampleda,   
         labdetail.instrument,   
         labdetail.sampleno psampleid,   
         labdetail.itemno testname,   
         labdetail.srcresult valuation,   
         labdetail.resultflag,   
         labitem.itemna testnumber 
    FROM labdetail,   
         labitem  
   WHERE ( labdetail.instrument = labitem.instrument ) and  
         ( ( upper(labdetail.itemno) = upper(labitem.itemno) ) AND  
         ( labdetail.instrument = 'ASCENT' ) AND  
         ( labdetail.sampleda = :vdate ) )   
ORDER BY labdetail.sampleda ASC,   
         labdetail.sampleno ASC";
            try
            {
                objCmd = new OdbcCommand(strSQL, objCnn);
                DateTime d = this.m_objViewer.m_dtpQueryDate.Value;
                OdbcParameter objDP = new OdbcParameter("vdate", OdbcType.Date);
                objDP.Value = d;
                objCmd.Parameters.Add(objDP);
                OdbcDataAdapter objAdapter = new OdbcDataAdapter();
                objAdapter.SelectCommand = objCmd;
                objCnn.Open();
                objAdapter.Fill(dt);
                dtAllRes = dt;
                objCnn.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        private DataTable m_dtbFiltData(DataTable dt)
        {
            if (blnSch == false)
            {
                if (this.m_objViewer.txtQueryRange.Text != "" && dt.Rows.Count > 0)
                {
                    System.Collections.ArrayList FindArr = new System.Collections.ArrayList();
                    FindArr = com.digitalwave.iCare.gui.HIS.clsPublic.m_ArrGettoken(this.m_objViewer.txtQueryRange.Text, ";");

                    //重新合并dt                
                    DataView dv = new DataView(dt);
                    string strFind = "";
                    int intIndex = 0;
                    string strLeft = "";
                    string strRight = "";
                    DataTable dtTemp1 = new DataTable();   //临时dt
                    dtTemp1 = dt.Clone();
                    DataTable dtTmp2 = new DataTable();
                    for (int i1 = 0; i1 < FindArr.Count; i1++)
                    {
                        strFind = FindArr[i1].ToString();
                        intIndex = strFind.IndexOf('-');
                        if (intIndex > 0)    //样本号段
                        {
                            strLeft = strFind.Substring(0, intIndex).Trim();
                            strRight = strFind.Substring(intIndex + 1).Trim();
                            dv.RowFilter = "psampleid >= " + Convert.ToInt32(strLeft) + " and psampleid <= " + Convert.ToInt32(strRight);
                        }
                        else   //单个样本号
                        {
                            dv.RowFilter = "psampleid = '" + Convert.ToInt32(strFind.Trim()) + "'";
                        }
                        dtTmp2 = dv.ToTable();
                        dtTemp1.BeginLoadData();
                        for (int i2 = 0; i2 < dtTmp2.Rows.Count; i2++)
                        {
                            dtTemp1.LoadDataRow(dtTmp2.Rows[i2].ItemArray, true);
                        }
                        dtTemp1.EndLoadData();
                        dtTemp1.AcceptChanges();
                    }
                    return dtTemp1;
                }
            }
            return dt;
        }

        public void m_mthShowResult(clsMBY2010VO[] objResVoArr)
        {
            this.m_objViewer.m_lsvResult.Items.Clear();
            ListViewItem lsiRes = null;
            for (int i1 = 0; i1 < objResVoArr.Length; i1++)
            {
                lsiRes = new ListViewItem((i1 + 1).ToString());
                lsiRes.SubItems.Add(objResVoArr[i1].m_strSampleId);
                lsiRes.SubItems.Add(objResVoArr[i1].m_strItemName);
                lsiRes.SubItems.Add(objResVoArr[i1].m_strResult);
                this.m_objViewer.m_lsvResult.Items.Add(lsiRes);
            }
        }

        public void m_mthFilterData()
        {
            if (dtAllRes == null)
                dtAllRes = this.m_mthReadData();
            DataTable dt = this.m_dtbFiltData(dtAllRes);
            this.m_mthFillSampleList(dt);
        }

        public void m_mthFillSampleList(DataTable dt)
        {
            this.m_objViewer.lsvPatList.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                DataView dv = new DataView(dt);
                ListViewItem lviTemp;
                DataRow dr = null;
                string strLastSamID = "";
                List<com.digitalwave.iCare.ValueObject.clsMBY2010VO> objReslist = new List<com.digitalwave.iCare.ValueObject.clsMBY2010VO>();
                for (int i1 = 0, n = 0; i1 < dt.Rows.Count; i1++)
                {
                    com.digitalwave.iCare.ValueObject.clsMBY2010VO objVo = new com.digitalwave.iCare.ValueObject.clsMBY2010VO();
                    dr = dt.Rows[i1];
                    objVo.m_strCheckDate = dr["sampleda"].ToString();
                    objVo.m_strInstrumentName = dr["instrument"].ToString();
                    objVo.m_strDeviceId = this.m_objViewer.txtMachineCode.Text;
                    objVo.m_strSampleId = dr["psampleid"].ToString().PadLeft(3, '0');
                    objVo.m_strItemName = dr["testname"].ToString();
                    objVo.m_strItemCode = dr["testname"].ToString();
                    objVo.m_strResult = dr["valuation"].ToString();
                    objVo.m_strCheck_Item_Name = dr["testnumber"].ToString();
                    if (objVo.m_strSampleId != strLastSamID)
                    {
                        strLastSamID = objVo.m_strSampleId;
                        lviTemp = new ListViewItem((n + 1).ToString());
                        lviTemp.SubItems.Add(objVo.m_strCheckDate);
                        lviTemp.SubItems.Add(objVo.m_strInstrumentName);
                        lviTemp.SubItems.Add(objVo.m_strSampleId);
                        lviTemp.Tag = objReslist;
                        this.m_objViewer.lsvPatList.Items.Add(lviTemp);
                        objReslist = new List<com.digitalwave.iCare.ValueObject.clsMBY2010VO>();
                        objReslist.Add(objVo);
                    }
                    else
                    {
                        objReslist.Add(objVo);
                        this.m_objViewer.lsvPatList.Items[this.m_objViewer.lsvPatList.Items.Count - 1].Tag = objReslist;
                    }
                }
                this.m_objViewer.lvwColumnSorter.Order = SortOrder.Ascending;
                this.m_objViewer.lsvPatList.Sort();
            }
        }
        #endregion
    }
}