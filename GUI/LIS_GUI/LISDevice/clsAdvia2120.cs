using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using com.digitalwave.iCare.ValueObject;
using System.IO;
using System.Drawing;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// Advia 2120 逻辑层
    /// baojian.mo Create in 2007-10-18
    /// </summary>
    public class clsAdvia2120 : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsAdvia2120()
        {
            //
            // TODO: Add constructor logic here
            //
            m_objDomain = new clsDomainController_Advia2120();
        }
        #endregion

        private frmADVIA2120 m_objViewer;

        private clsDomainController_Advia2120 m_objDomain;

        /// <summary>
        /// Access数库据连接器
        /// </summary>
        private OleDbConnection objConn = null;

        /// <summary>
        /// 数据库路径
        /// </summary>
        public string strDataBasePath = "";

        /// <summary>
        /// 图片文件夹路径
        /// </summary>
        public string strPicturePath = "";

        /// <summary>
        /// 病人类型id
        /// </summary>
        public int intPatientType = 0;

        /// <summary>
        /// 科室id
        /// </summary>
        public int intDetpID = 0;

        /// <summary>
        /// ADVIA2120仪器代号
        /// </summary>
        private string strDeviceModelID = "002120";

        /// <summary>
        /// 样本列本显示内容的设置
        /// 0-读取report_info; 1-读取result_inf
        /// </summary>
        private int m_intShowTypeSetting = 1;

        #region 设置窗体控制器
        /// <summary>
        /// 设置窗体控制器
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            this.m_objViewer = (frmADVIA2120)frmMDI_Child_Base_in;
        }
        #endregion

        #region 设置数据来源路径
        /// <summary>
        /// 设置数据来源路径
        /// </summary>
        /// <returns></returns>
        public bool blnSetDataPath()
        {
            bool ret = false;
            string strdtPat = Application.StartupPath + @"\LIS_GUI.dll.config";
            if (!System.IO.File.Exists(strdtPat))
                return ret;
            ConfigXmlDocument xmlConfig = new ConfigXmlDocument();
            try
            {
                xmlConfig.Load(strdtPat);
                strDataBasePath = xmlConfig["configuration"]["adviaSettings"].SelectSingleNode("add[@key=\"m_strDataPath\"]").Attributes["value"].Value;
                strPicturePath = xmlConfig["configuration"]["adviaSettings"].SelectSingleNode("add[@key=\"m_strPicPath\"]").Attributes["value"].Value;
                //<------------------ 2007-11-08 add
                try
                {
                    m_intShowTypeSetting = int.Parse(xmlConfig["configuration"]["AdviaSamlpeListShowType"].SelectSingleNode("setting").Attributes["type"].Value);
                    if (m_intShowTypeSetting == 1)
                    {
                        this.m_objViewer.cboPatientType.Enabled = false;
                        this.m_objViewer.cboDept.Enabled = false;
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                //------------------>
                ret = true;
            }
            catch (Exception)
            {
                return false;
            }
            return ret;
        }
        #endregion

        #region 查找
        /// <summary>
        /// 查找
        /// </summary>
        public void m_mthQuery()
        {
            this.m_objViewer.listView1.Items.Clear();
            if (strDataBasePath != "")
            {
                string strConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDataBasePath + ";Persist Security Info=False;Jet OLEDB:DataBase Password='555000'";
                objConn = new OleDbConnection(strConnection);
                try
                {
                    objConn.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show(this.m_objViewer, "数据库连接失败，请检查数据库路径是否正确！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (m_intShowTypeSetting == 0)
                {
                    string strSQL = @"select a.dat_inputdate, a.num_samplenum, a.chr_patiid, a.num_typeid,
                                             a.num_departid, a.dat_getdate, a.dat_testdate, a.num_sdoctorid,
                                             a.num_sickid, a.chr_name, a.chr_sexname, a.chr_state, a.chr_code,
                                             b.chr_name as patienttype, c.chr_name as dept, d.chr_name as sdoctor
                                        from (((report_inf a left outer join pat_type b on a.num_typeid = b.num_typeid) 
                                                             left outer join pat_depart c on a.num_departid = c.num_departid) 
                                                             left outer join send_doctor d on a.num_sdoctorid = d.num_sdoctorid)";

                    DataTable dt = new DataTable();
                    OleDbCommand objCommand = new OleDbCommand();
                    objCommand.Connection = objConn;

                    #region 生成查询条件
                    OleDbParameter objParam = null;
                    OleDbParameter objParam2 = null;
                    if (this.m_objViewer.m_dtpCheckDate.Text != "")
                    {
                        strSQL += @" where a.dat_inputdate = :check_date";
                        objParam = new OleDbParameter("check_date", OleDbType.DBDate);
                        objParam.Value = this.m_objViewer.m_dtpCheckDate.Value;
                        objCommand.CommandText = strSQL;
                        objCommand.Parameters.Add(objParam);
                    }
                    else
                    {
                        MessageBox.Show(this.m_objViewer, "检验日期不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        objConn.Close();
                        this.m_objViewer.m_dtpCheckDate.Focus();
                        return;
                    }

                    if (this.intPatientType != 0)
                    {
                        strSQL += @" and a.num_typeid = :patient_typeid";
                        objParam = new OleDbParameter("patient_typeid", OleDbType.SmallInt);
                        objParam.Value = intPatientType;
                        objCommand.CommandText = strSQL;
                        objCommand.Parameters.Add(objParam);
                    }

                    if (this.intDetpID != 0)
                    {
                        strSQL += @" and a.num_departid = :dept_id";
                        objParam = new OleDbParameter("dept_id", OleDbType.SmallInt);
                        objParam.Value = intDetpID;
                        objCommand.CommandText = strSQL;
                        objCommand.Parameters.Add(objParam);
                    }

                    if (this.m_objViewer.txtSampleIDFrom.Text.Trim() != "" && this.m_objViewer.txtSampleIDTo.Text.Trim() != "")
                    {
                        strSQL += @" and a.num_samplenum >= :sample_from and a.num_samplenum <= :sample_to";

                        objParam = new OleDbParameter("sample_from", OleDbType.UnsignedBigInt);
                        objParam.Value = Int64.Parse(this.m_objViewer.txtSampleIDFrom.Text.Trim());
                        objParam2 = new OleDbParameter("sample_to", OleDbType.UnsignedBigInt);
                        objParam2.Value = Int64.Parse(this.m_objViewer.txtSampleIDTo.Text.Trim());

                        objCommand.CommandText = strSQL;
                        objCommand.Parameters.Add(objParam);
                        objCommand.Parameters.Add(objParam2);
                    }
                    else if (this.m_objViewer.txtSampleIDFrom.Text.Trim() != "" || this.m_objViewer.txtSampleIDTo.Text.Trim() != "")
                    {
                        strSQL += @" and a.num_samplenum = :sample_id";
                        string strSampleId = (this.m_objViewer.txtSampleIDFrom.Text.Trim() == "" ? this.m_objViewer.txtSampleIDTo.Text.Trim() : this.m_objViewer.txtSampleIDFrom.Text.Trim());
                        objParam = new OleDbParameter("sample_id", OleDbType.UnsignedBigInt);
                        objParam.Value = Int64.Parse(strSampleId);
                        objCommand.CommandText = strSQL;
                        objCommand.Parameters.Add(objParam);
                    }
                    else
                    {

                    }

                    if (this.m_objViewer.rdbUncheck.Checked == true)
                    {
                        strSQL += @" and a.chr_state <> '1'";
                        objCommand.CommandText = strSQL;
                    }
                    else if (this.m_objViewer.rdbCheckd.Checked == true)
                    {
                        strSQL += @" and a.chr_state = '1'";
                        objCommand.CommandText = strSQL;
                    }
                    else
                    {

                    }
                    #endregion

                    strSQL += @" order by a.num_samplenum";
                    OleDbDataAdapter objAdapter = new OleDbDataAdapter(objCommand);
                    objAdapter.Fill(dt);
                    objConn.Close();
                    clsAdvia2120ReportInf_VO[] objReport_InfArr = null;
                    if (dt.Rows.Count > 0)
                    {
                        objReport_InfArr = new clsAdvia2120ReportInf_VO[dt.Rows.Count];
                        ListViewItem objlvItem = null;
                        for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                        {
                            objReport_InfArr[i1] = new clsAdvia2120ReportInf_VO();
                            m_mthConstructReportVO(dt.Rows[i1], ref objReport_InfArr[i1]);
                            objlvItem = new ListViewItem(objReport_InfArr[i1].strSampleID);   //样本号

                            objlvItem.SubItems.Add(objReport_InfArr[i1].strPatientID);   //病员号

                            objlvItem.SubItems.Add(objReport_InfArr[i1].strPatientName);   //姓名
                            objlvItem.SubItems.Add(objReport_InfArr[i1].strSex);   //性别
                            objlvItem.SubItems.Add(objReport_InfArr[i1].strGetDate);   //采样日期
                            objlvItem.SubItems.Add(objReport_InfArr[i1].strSendDoctorName);   //送检医生
                            objlvItem.SubItems.Add(objReport_InfArr[i1].strTestDate);   //送检日期
                            objlvItem.SubItems.Add(objReport_InfArr[i1].strReportCode);   //标识号

                            if (objReport_InfArr[i1].strState == "1")   //状态
                            {
                                objlvItem.SubItems.Add("√");
                            }
                            else
                            {
                                objlvItem.SubItems.Add(objReport_InfArr[i1].strState);
                            }
                            objlvItem.Tag = objReport_InfArr[i1];
                            this.m_objViewer.listView1.Items.Add(objlvItem);
                        }
                    }
                }
                else if (m_intShowTypeSetting == 1)
                {
                    string strSQL = @"select a.dat_inputdate, a.num_samplenum, a.chr_state 
                                        from result_inf a";

                    DataTable dt = new DataTable();
                    OleDbCommand objCommand = new OleDbCommand();
                    objCommand.Connection = objConn;

                    #region 生成查询条件
                    OleDbParameter objParam = null;
                    OleDbParameter objParam2 = null;
                    if (this.m_objViewer.m_dtpCheckDate.Text != "")
                    {
                        strSQL += @" where a.dat_inputdate = :check_date";
                        objParam = new OleDbParameter("check_date", OleDbType.DBDate);
                        objParam.Value = this.m_objViewer.m_dtpCheckDate.Value;
                        objCommand.CommandText = strSQL;
                        objCommand.Parameters.Add(objParam);
                    }
                    else
                    {
                        MessageBox.Show(this.m_objViewer, "检验日期不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        objConn.Close();
                        this.m_objViewer.m_dtpCheckDate.Focus();
                        return;
                    }

                    if (this.m_objViewer.txtSampleIDFrom.Text.Trim() != "" && this.m_objViewer.txtSampleIDTo.Text.Trim() != "")
                    {
                        strSQL += @" and a.num_samplenum >= :sample_from and a.num_samplenum <= :sample_to";

                        objParam = new OleDbParameter("sample_from", OleDbType.UnsignedBigInt);
                        objParam.Value = Int64.Parse(this.m_objViewer.txtSampleIDFrom.Text.Trim());
                        objParam2 = new OleDbParameter("sample_to", OleDbType.UnsignedBigInt);
                        objParam2.Value = Int64.Parse(this.m_objViewer.txtSampleIDTo.Text.Trim());

                        objCommand.CommandText = strSQL;
                        objCommand.Parameters.Add(objParam);
                        objCommand.Parameters.Add(objParam2);
                    }
                    else if (this.m_objViewer.txtSampleIDFrom.Text.Trim() != "" || this.m_objViewer.txtSampleIDTo.Text.Trim() != "")
                    {
                        strSQL += @" and a.num_samplenum = :sample_id";
                        string strSampleId = (this.m_objViewer.txtSampleIDFrom.Text.Trim() == "" ? this.m_objViewer.txtSampleIDTo.Text.Trim() : this.m_objViewer.txtSampleIDFrom.Text.Trim());
                        objParam = new OleDbParameter("sample_id", OleDbType.UnsignedBigInt);
                        objParam.Value = Int64.Parse(strSampleId);
                        objCommand.CommandText = strSQL;
                        objCommand.Parameters.Add(objParam);
                    }
                    else
                    {

                    }

                    if (this.m_objViewer.rdbUncheck.Checked == true)
                    {
                        strSQL += @" and a.chr_state <> '1'";
                        objCommand.CommandText = strSQL;
                    }
                    else if (this.m_objViewer.rdbCheckd.Checked == true)
                    {
                        strSQL += @" and a.chr_state = '1'";
                        objCommand.CommandText = strSQL;
                    }
                    else
                    {

                    }
                    #endregion

                    strSQL += @" group by a.dat_inputdate, a.num_samplenum, a.chr_state order by a.num_samplenum";
                    objCommand.CommandText = strSQL;
                    OleDbDataAdapter objAdapter = new OleDbDataAdapter(objCommand);
                    objAdapter.Fill(dt);
                    objConn.Close();
                    clsAdvia2120ReportInf_VO[] objReport_InfArr = null;
                    if (dt.Rows.Count > 0)
                    {
                        objReport_InfArr = new clsAdvia2120ReportInf_VO[dt.Rows.Count];
                        ListViewItem objlvItem = null;
                        for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                        {
                            objReport_InfArr[i1] = new clsAdvia2120ReportInf_VO();
                            //<------------------ 2007-11-08 add
                            objReport_InfArr[i1].strSampleID = dt.Rows[i1]["num_samplenum"].ToString();
                            objReport_InfArr[i1].strPatientID = "";
                            objReport_InfArr[i1].strGetDate = dt.Rows[i1]["dat_inputdate"].ToString();
                            objReport_InfArr[i1].strTestDate = "";
                            objReport_InfArr[i1].strPatientName = "";
                            objReport_InfArr[i1].strSex = "";
                            objReport_InfArr[i1].strState = dt.Rows[i1]["chr_state"].ToString();
                            objReport_InfArr[i1].strReportCode = "";
                            objReport_InfArr[i1].strSendDoctorName = "";
                            //------------------>
                            objlvItem = new ListViewItem(objReport_InfArr[i1].strSampleID);   //样本号
                            objlvItem.SubItems.Add(objReport_InfArr[i1].strPatientID);   //病员号
                            objlvItem.SubItems.Add(objReport_InfArr[i1].strPatientName);   //姓名
                            objlvItem.SubItems.Add(objReport_InfArr[i1].strSex);   //性别
                            objlvItem.SubItems.Add(objReport_InfArr[i1].strGetDate);   //采样日期
                            objlvItem.SubItems.Add(objReport_InfArr[i1].strSendDoctorName);   //送检医生
                            objlvItem.SubItems.Add(objReport_InfArr[i1].strTestDate);   //送检日期
                            objlvItem.SubItems.Add(objReport_InfArr[i1].strReportCode);   //标识号
                            if (objReport_InfArr[i1].strState == "1")   //状态
                            {
                                objlvItem.SubItems.Add("√");
                            }
                            else
                            {
                                objlvItem.SubItems.Add(objReport_InfArr[i1].strState);
                            }
                            objlvItem.Tag = objReport_InfArr[i1];
                            this.m_objViewer.listView1.Items.Add(objlvItem);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(this.m_objViewer, "数库路径未设置，请点击“设置”按钮", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            return;
        }
        #endregion

        #region 生成报告VO
        /// <summary>
        /// 生成报告VO
        /// </summary>
        /// <param name="objRow"></param>
        /// <param name="objReportVO"></param>
        private void m_mthConstructReportVO(DataRow objRow, ref clsAdvia2120ReportInf_VO objReportVO)
        {
            objReportVO.strInputDate = objRow["dat_inputdate"].ToString();
            objReportVO.strSampleID = objRow["num_samplenum"].ToString();
            objReportVO.strPatientID = objRow["chr_patiid"].ToString();
            objReportVO.intType = int.Parse(objRow["num_typeid"].ToString());
            objReportVO.intDeptCode = int.Parse(objRow["num_departid"].ToString());
            objReportVO.strGetDate = objRow["dat_getdate"].ToString();
            objReportVO.strTestDate = objRow["dat_testdate"].ToString();
            objReportVO.intSendDoctorID = int.Parse(objRow["num_sdoctorid"].ToString());
            objReportVO.intSickID = int.Parse(objRow["num_sickid"].ToString());
            objReportVO.strPatientName = objRow["chr_name"].ToString();
            objReportVO.strSex = objRow["chr_sexname"].ToString();
            objReportVO.strState = objRow["chr_state"].ToString();
            objReportVO.strReportCode = objRow["chr_code"].ToString();
            objReportVO.strPatineType = objRow["patienttype"].ToString();
            objReportVO.strDeptName = objRow["dept"].ToString();
            objReportVO.strSendDoctorName = objRow["sdoctor"].ToString();
        }
        #endregion

        #region 初始化病人类型和科室列表
        /// <summary>
        /// 初始化病人类型和科室列表
        /// </summary>
        public void m_mthInit()
        {
            if (strDataBasePath != "")
            {
                string strConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDataBasePath + ";Persist Security Info=False;Jet OLEDB:DataBase Password='555000'";
                objConn = new OleDbConnection(strConnection);
                try
                {
                    objConn.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show(this.m_objViewer, "初始化病人类型和科室列表失败，请检查数据库路径是否正确！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string strSQL = "";
                OleDbDataAdapter objAdapter = null;
                DataTable dtTmp = null;
                DataTable dt = null;   //新生成的DataTable                
                DataRow objRow = null;

                if (this.m_objViewer.cboPatientType.Tag == null)
                {
                    strSQL = @"select a.num_typeid, a.chr_name, a.chr_symbol
                                    from pat_type a";

                    dtTmp = new DataTable();
                    objAdapter = new OleDbDataAdapter(strSQL, objConn);
                    objAdapter.Fill(dtTmp);

                    dt = new DataTable();
                    dt = dtTmp.Clone();

                    #region 初始化病人类型列表
                    if (dtTmp.Rows.Count > 0)
                    {
                        objRow = dt.NewRow();
                        objRow["num_typeid"] = 0;
                        objRow["chr_name"] = "全部";
                        objRow["chr_symbol"] = "qb";
                        dt.Rows.Add(objRow);
                        this.m_objViewer.cboPatientType.Items.Add(objRow["chr_name"]);

                        for (int i1 = 0; i1 < dtTmp.Rows.Count; i1++)
                        {
                            objRow = dt.NewRow();
                            objRow["num_typeid"] = dtTmp.Rows[i1]["num_typeid"];
                            objRow["chr_name"] = dtTmp.Rows[i1]["chr_name"];
                            objRow["chr_symbol"] = dtTmp.Rows[i1]["chr_symbol"];
                            dt.Rows.Add(objRow);
                            this.m_objViewer.cboPatientType.Items.Add(objRow["chr_name"]);
                        }
                        dt.AcceptChanges();
                        this.m_objViewer.cboPatientType.Tag = dt;
                        this.m_objViewer.cboPatientType.SelectedIndex = 0;
                    }
                }
                    #endregion

                if (this.m_objViewer.cboDept.Tag == null)
                {
                    strSQL = @"select a.num_departid, a.chr_name, a.chr_symbol
                             from pat_depart a";
                    dtTmp = new DataTable();
                    objAdapter = new OleDbDataAdapter(strSQL, objConn);
                    objAdapter.Fill(dtTmp);

                    dt = new DataTable();
                    dt = dtTmp.Clone();

                    #region 初始化科室列表
                    if (dtTmp.Rows.Count > 0)
                    {
                        objRow = dt.NewRow();
                        objRow["num_departid"] = 0;
                        objRow["chr_name"] = "全部";
                        objRow["chr_symbol"] = "qb";
                        dt.Rows.Add(objRow);
                        this.m_objViewer.cboDept.Items.Add(objRow["chr_name"]);

                        for (int i2 = 0; i2 < dtTmp.Rows.Count; i2++)
                        {
                            objRow = dt.NewRow();
                            objRow["num_departid"] = dtTmp.Rows[i2]["num_departid"];
                            objRow["chr_name"] = dtTmp.Rows[i2]["chr_name"];
                            objRow["chr_symbol"] = dtTmp.Rows[i2]["chr_symbol"];
                            dt.Rows.Add(objRow);
                            this.m_objViewer.cboDept.Items.Add(objRow["chr_name"]);
                        }
                        dt.AcceptChanges();
                        this.m_objViewer.cboDept.Tag = dt;
                        this.m_objViewer.cboDept.SelectedIndex = 0;
                    }
                }
                    #endregion

                objConn.Close();
            }
        }
        #endregion

        #region 读取报告信息
        /// <summary>
        /// 读取报告信息
        /// </summary>
        /// <param name="p_datInputDate">检验日期</param>
        /// <param name="p_intSampleID">样本号</param>
        public void m_mthReadReport(DateTime p_datInputDate, Int64 p_intSampleID)
        {
            string strSQL = @"select a.dat_inputdate, a.num_samplenum, a.num_typeid, a.chr_itemcode, 
                                     a.num_dataformat, a.num_value, a.chr_value, a.num_od, a.chr_picpath, 
                                     a.chr_state, a.dat_testtime, b.chr_itemname, b.num_itemid 
                                from result_inf a left outer join item_set b on a.chr_itemcode = b.chr_itemcode";
            try
            {
                objConn.Open();
            }
            catch (Exception)
            {
                MessageBox.Show(this.m_objViewer, "数据库连接失败，请检查数据库路径是否正确！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OleDbParameter objParam = null;
            OleDbParameter objParam2 = null;
            DataTable dt = new DataTable();
            OleDbCommand objCommand = new OleDbCommand();
            objCommand.Connection = objConn;

            strSQL += @" where a.dat_inputdate = :input_date and a.num_samplenum = :sample_id";
            objParam = new OleDbParameter("input_date", OleDbType.DBDate);
            objParam.Value = DateTime.Parse(p_datInputDate.ToShortDateString());
            objParam2 = new OleDbParameter("sample_id", OleDbType.UnsignedBigInt);
            objParam2.Value = p_intSampleID;

            objCommand.CommandText = strSQL;
            objCommand.Parameters.Add(objParam);
            objCommand.Parameters.Add(objParam2);
            OleDbDataAdapter objAdapter = new OleDbDataAdapter(objCommand);
            objAdapter.Fill(dt);
            objConn.Close();

            clsAdvia2120ResultInf_VO[] objReportVOArr = null;
            if (dt.Rows.Count > 0)
            {
                objReportVOArr = new clsAdvia2120ResultInf_VO[dt.Rows.Count];
                ListViewItem objlvItem = null;
                for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                {
                    objReportVOArr[i1] = new clsAdvia2120ResultInf_VO();
                    m_mthConstructResultVO(dt.Rows[i1], ref objReportVOArr[i1]);

                    #region 添加结果
                    objlvItem = new ListViewItem(Convert.ToString(i1 + 1));
                    objlvItem.SubItems.Add(objReportVOArr[i1].strItemCode);
                    objlvItem.SubItems.Add(objReportVOArr[i1].num_od.ToString());
                    objlvItem.SubItems.Add(objReportVOArr[i1].num_value.ToString());
                    objlvItem.SubItems.Add(objReportVOArr[i1].chr_value);
                    if (objReportVOArr[i1].strState == "1")
                    {
                        objlvItem.SubItems.Add("√");
                    }
                    else
                    {
                        objlvItem.SubItems.Add(objReportVOArr[i1].strState);
                    }
                    objlvItem.SubItems.Add(objReportVOArr[i1].strTestTime);
                    if (objReportVOArr[i1].intDataFormat == 2 && objReportVOArr[i1].strPicPath != "")
                    {
                        objlvItem.SubItems.Add("√");
                    }
                    else
                    {
                        objlvItem.SubItems.Add("");
                    }
                    this.m_objViewer.listView2.Items.Add(objlvItem);
                    #endregion
                }
                //this.m_objViewer.listView1.SelectedItems[0].Tag = objReportVOArr;
            }
        }
        #endregion

        #region 构造结果VO
        /// <summary>
        /// 构造结果VO
        /// </summary>
        /// <param name="p_objRow"></param>
        /// <param name="p_objResultVO"></param>
        private void m_mthConstructResultVO(DataRow p_objRow, ref clsAdvia2120ResultInf_VO p_objResultVO)
        {
            p_objResultVO.strInputDate = p_objRow["dat_inputdate"].ToString();
            p_objResultVO.strSampleID = p_objRow["num_samplenum"].ToString();
            p_objResultVO.intTypeID = int.Parse(p_objRow["num_typeid"].ToString());
            p_objResultVO.strItemCode = p_objRow["chr_itemcode"].ToString();
            p_objResultVO.intDataFormat = int.Parse(p_objRow["num_dataformat"].ToString());
            p_objResultVO.num_value = decimal.Parse(p_objRow["num_value"].ToString());
            p_objResultVO.chr_value = p_objRow["chr_value"].ToString();
            p_objResultVO.num_od = decimal.Parse(p_objRow["num_od"].ToString());
            p_objResultVO.strPicPath = p_objRow["chr_picpath"].ToString().Trim();
            p_objResultVO.strState = p_objRow["chr_state"].ToString();
            p_objResultVO.strTestTime = DateTime.Parse(p_objRow["dat_testtime"].ToString()).ToShortDateString();
            p_objResultVO.strItemName = p_objRow["chr_itemname"].ToString();
            p_objResultVO.m_strItemid = p_objRow["num_itemid"].ToString();
        }
        #endregion

        #region 插入报告
        /// <summary>
        /// 插入报告
        /// </summary>
        public void m_mthInsertReport()
        {
            if (this.m_objViewer.listView1.SelectedItems.Count <= 0)
                return;

            try
            {
                objConn.Open();
            }
            catch (Exception)
            {
                MessageBox.Show(this.m_objViewer, "数据库连接失败，请检查数据库路径是否正确！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                com.digitalwave.iCare.gui.HIS.clsPublic.PlayAvi("findfile.avi", "正在插入检验报告单，请稍候...");

                long lngRes = 0;
                bool blnHasCode = true;   //含有标识值
                int intInsertNum = 0;   //记录数据库插入数据的条数
                DataTable dt = new DataTable();
                DataRow objRow = null;

                #region 生成SQL
                //string strSQL = @"select a.dat_inputdate, a.num_samplenum, a.num_typeid, a.chr_itemcode, a.num_dataformat, a.num_value, a.chr_value, a.num_od, a.chr_picpath, a.chr_state, a.dat_testtime, b.chr_itemname, c.chr_code from ((result_inf a left outer join item_set b on a.chr_itemcode = b.chr_itemcode) inner join report_inf c on a.dat_inputdate = c.dat_inputdate and a.num_samplenum = c.num_samplenum) where a.num_samplenum in(";
                string strSQL = @"select a.dat_inputdate, a.num_samplenum, a.num_typeid, a.chr_itemcode, 
                                         a.num_dataformat, a.num_value, a.chr_value, a.num_od, a.chr_picpath, 
                                         a.chr_state, a.dat_testtime, b.chr_itemname, b.num_itemid
                                    from (result_inf a left outer join item_set b on a.chr_itemcode = b.chr_itemcode) 
                                   where a.num_samplenum in(";

                string strSQL2 = @") and a.dat_inputdate = :check_date";

                ListViewItem objlvItem = null;
                for (int i1 = 0; i1 < this.m_objViewer.listView1.SelectedItems.Count; i1++)
                {
                    objlvItem = this.m_objViewer.listView1.SelectedItems[i1];
                    strSQL += objlvItem.SubItems[0].Text + ",";
                }
                strSQL = strSQL.Remove(strSQL.Length - 1, 1) + strSQL2;
                OleDbCommand objCommand = new OleDbCommand();

                OleDbParameter objParam = new OleDbParameter("check_date", OleDbType.DBDate);
                objParam.Value = DateTime.Parse(this.m_objViewer.listView1.SelectedItems[0].SubItems[4].Text);

                objCommand.Connection = objConn;
                objCommand.CommandText = strSQL;
                objCommand.Parameters.Add(objParam);
                #endregion

                OleDbDataAdapter objAdapter = new OleDbDataAdapter(objCommand);
                objAdapter.Fill(dt);
                objConn.Close();

                List<clsAdvia2120ResultInf_VO> objResultList = new List<clsAdvia2120ResultInf_VO>();
                clsAdvia2120ResultInf_VO objRes;
                string strPP = "";
                DateTime datTmp;

                for (int i2 = 0; i2 < dt.Rows.Count; i2++)
                {
                    objRow = dt.Rows[i2];
                    if (objRow["dat_inputdate"].ToString().Trim() == "" && objRow["num_samplenum"].ToString().Trim() == "")
                    {
                        blnHasCode = false;
                        break;
                    }
                    objRes = new clsAdvia2120ResultInf_VO();
                    this.m_mthConstructResultVO(objRow, ref objRes);
                    //objRes.strCode = objRow["chr_code"].ToString();
                    //<------------------ 2007-11-08 Modify
                    #region 构造标识号
                    datTmp = DateTime.Parse(objRow["dat_inputdate"].ToString());
                    objRes.strCode = datTmp.ToString("yyyy") + datTmp.ToString("MM").PadLeft(2, '0') + datTmp.ToString("dd").PadLeft(2, '0') + objRow["num_samplenum"].ToString();
                    #endregion
                    //------------------>
                    objRes.strDeviceID = strDeviceModelID;
                    objRes.m_strOperator_ID = this.m_objViewer.LoginInfo.m_strEmpID;
                    if (objRes.intDataFormat == 2)
                    {
                        //构造图形
                        strPP = strPicturePath + objRow["chr_picpath"].ToString();
                        objRes.m_byaGraph = this.m_objConstructImage(strPP);
                    }
                    objResultList.Add(objRes);
                }

                if (blnHasCode)
                {
                    lngRes = m_objDomain.m_lngInsertReport(this.m_objViewer.listView1.SelectedItems.Count, objResultList, out intInsertNum);   //插入报告单
                }
                else
                {
                    MessageBox.Show(this.m_objViewer, "插入队列中含有空“样本号”，请检查后再操作！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                com.digitalwave.iCare.gui.HIS.clsPublic.CloseAvi();
                if (lngRes > 0)
                {
                    MessageBox.Show(this.m_objViewer, "选中要插入报告单的共 " + this.m_objViewer.listView1.SelectedItems.Count + " 人\r\n\r\n插入记录 " + intInsertNum + " 条", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmHandInputReport.WYH = true;
                }
                else
                {
                    MessageBox.Show(this.m_objViewer, "没有任何插入报告条数！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception objEx)
            {
                objConn.Close();
                com.digitalwave.iCare.gui.HIS.clsPublic.CloseAvi();
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
        }
        #endregion

        #region 构造图形
        /// <summary>
        /// 构造图形
        /// </summary>
        /// <param name="p_strPath">图片路径</param>
        /// <returns></returns>
        private byte[] m_objConstructImage(string p_strPath)
        {
            byte[] b_img = null;
            if (File.Exists(p_strPath))
            {
                try
                {
                    FileStream fs = new FileStream(p_strPath, FileMode.Open);
                    BinaryReader br = new BinaryReader(fs);
                    b_img = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();

                    return b_img;
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            return b_img;
        }
        #endregion
    }
}