using System;
using System.Collections.Generic;
using System.Text;
using Sybase.DataWindow;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsCtl_SampleAccetable : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 构造函数
        public clsCtl_SampleAccetable()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_objManage = new clsDcl_SampleAcceptable();
        }
        #endregion

        /// <summary>
        /// 类变量
        /// </summary>
        private frmSampleAcceptable m_objViewer;
        internal bool IsEnglish = false;
        private clsDcl_SampleAcceptable m_objManage;
        Dictionary<string, string> dicGroup;

        #region Entity
        /// <summary>
        /// 
        /// </summary>
        public class EnitySampleAcceptable
        {
            //科室
            public string deptName { get; set; }
            //项目总数
            public decimal itemCount { get; set; }
            //检验报告发放时限符合数
            public decimal acceptCount { get; set; }
            //检验报告发放时限符合率
            public string acceptPer { get; set; }
        }

        public class EntitySamepleDetail
        {
            public string HZXM { get; set; }
            public string DEPTNAME { get; set; }
            public string BARCODE { get; set; }
            public string CARDNO { get; set; }
            public string item { get; set; }
            public string ApplyTime { get; set; }
            public string AcceptTime { get; set; }
            public string ConfirmTime { get; set; }
            public string Checker { get; set; }
            public decimal lisTime { get; set; }
            public string acceptFlg { get; set; }
            public string HsWeek { get; set; }
            public string isemergency { get; set; }
        }

        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            m_objViewer = (frmSampleAcceptable)frmMDI_Child_Base_in;
        }
        #endregion

        #region init
        /// <summary>
        /// init
        /// </summary>
        public void m_mthInti()
        {
            DataTable dtbResult;
            dicGroup = new Dictionary<string, string>();
            m_objViewer.tabContorl.Visible = false;
            m_objViewer.dgvdata.Visible = true;
            m_objViewer.cboStatType.Items.AddRange(new object[] { " 检验报告发放时限符合率统计报表", " 检验报告发放时限符合明细" });
            m_objViewer.cboStatType.SelectedIndex = 1;
            m_objViewer.dteStart.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01");
            m_objViewer.cboDeptType.Items.Add("住院");
            m_objViewer.cboDeptType.Items.Add("门诊");
            m_objViewer.cboEmergency.Items.Add("急诊项目");
            m_objViewer.cboEmergency.Items.Add("非急诊项目");
            //m_objManage.lngGetAllCheckSpec(out dtbResult);
            m_objManage.GetAllCheckSpec(out dtbResult);

            for (int i = 0; i < dtbResult.Rows.Count; i++)
            {
                //m_objViewer.cbxGroup.Items.Add(dtbResult.Rows[i]["user_group_name_vchr"].ToString());
                //dicGroup.Add(dtbResult.Rows[i]["user_group_id_chr"].ToString(), dtbResult.Rows[i]["user_group_name_vchr"].ToString());

                m_objViewer.cbxGroup.Items.Add(dtbResult.Rows[i]["check_category_desc_vchr"].ToString());
                dicGroup.Add(dtbResult.Rows[i]["check_category_id_chr"].ToString(), dtbResult.Rows[i]["check_category_desc_vchr"].ToString());
            }
        }
        #endregion

        #region  检验报告发放时限符合率统计报表
        /// <summary>
        /// 
        /// </summary>
        public void m_mthGeSampleAcceptable()
        {
            DataTable dtbResult;
            List<EnitySampleAcceptable> data = new List<EnitySampleAcceptable>();
            string enmergencyFlg = string.Empty;
            string patType = string.Empty;
            string dteStart = m_objViewer.dteStart.Text;
            string dteEnd = m_objViewer.dteEnd.Text;
            string applyUnitIdStr = string.Empty;
            string groupId = string.Empty;
            string applyUnitId = string.Empty;
            string applyNameStr = string.Empty;
            string applyName = string.Empty;
            DataTable dtLimit = null;

            try
            {
                string strDept = m_objViewer.DeptIdArr;
                if (m_objViewer.cboEmergency.Text.Trim() == "急诊项目")
                    enmergencyFlg = "1";
                else if (m_objViewer.cboEmergency.Text.Trim() == "非急诊项目")
                    enmergencyFlg = "0";

                if (m_objViewer.cboDeptType.Text.Trim() == "住院")
                    patType = "1";
                else if (m_objViewer.cboDeptType.Text.Trim() == "门诊")
                    patType = "2";

                foreach (var item in dicGroup)
                {
                    if (item.Value == m_objViewer.cbxGroup.Text)
                        groupId = item.Key;
                }

                if (m_objViewer.dgvCheckItem.Rows.Count >= 2)
                    groupId = "";

                m_objManage.lngGetAllLimitTime(out dtLimit);

                if (!string.IsNullOrEmpty(groupId))
                {
                    m_objManage.lngGetAllCheckItem(out dtbResult, groupId);
                    if (dtbResult != null && dtbResult.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtbResult.Rows)
                        {
                            applyUnitId = dr["项目编码"].ToString();
                            applyName = dr["项目名称"].ToString();

                            if (dtLimit != null && dtLimit.Rows.Count > 0)
                            {
                                DataRow[] drr = dtLimit.Select("applyunitid = '" + applyUnitId + "'");
                                if (drr != null && drr.Length > 0)
                                    applyUnitIdStr += "'" + drr[0]["applyunitid"].ToString() + "',";
                            }
                        }

                        if (!string.IsNullOrEmpty(applyUnitIdStr))
                            applyUnitIdStr = applyUnitIdStr.TrimEnd(',');
                    }

                    applyUnitIdStr = "(" + applyUnitIdStr.TrimEnd(',') + ")";
                }

                if (m_objViewer.dgvCheckItem.Rows.Count >= 2)
                {
                    applyUnitIdStr = string.Empty;

                    for (int i = 0; i < m_objViewer.dgvCheckItem.Rows.Count - 1; i++)
                    {
                        applyUnitId = m_objViewer.dgvCheckItem.Rows[i].Cells[0].Value.ToString();
                        applyName = m_objViewer.dgvCheckItem.Rows[i].Cells[1].Value.ToString();

                        if (dtLimit != null && dtLimit.Rows.Count > 0)
                        {
                            DataRow[] drr = dtLimit.Select("applyunitid = '" + applyUnitId + "'");
                            if (drr != null && drr.Length > 0)
                                applyUnitIdStr += "'" + drr[0]["applyunitid"].ToString() + "'," ;
                        }
                    }

                    if (!string.IsNullOrEmpty(applyUnitIdStr))
                        applyUnitIdStr = applyUnitIdStr.TrimEnd(',');
                }

                clsPublic.PlayAvi("findFILE.avi", "正在查询项目信息，请稍候...");

                long lngRes = m_objManage.lngGetSampleAcceptable(out dtbResult, dteStart, dteEnd, applyUnitIdStr, strDept, enmergencyFlg, patType);
                int flgKS = 0;

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtbResult.Rows)
                    {
                        flgKS = 0;
                        decimal listime = Convert.ToDecimal(dr["listime"]);           // 审核-核收（时间）
                        DateTime? acceptTime = null;
                        DateTime? confirmTime = null;
                        decimal energencyLimit = 0;

                        if (dr["accepttime"] != DBNull.Value)
                            acceptTime = Convert.ToDateTime(dr["acceptTime"]);     //核收时间
                        if (dr["confirmTime"] != DBNull.Value)
                            confirmTime = Convert.ToDateTime(dr["confirmTime"]);   //审核时间
                        if (dr["emergencylimit"] != DBNull.Value)
                            energencyLimit = Convert.ToDecimal(dr["emergencylimit"].ToString().Trim());

                        for (int i = 0; i < data.Count; i++)
                        {
                            if (dr["deptname"].ToString() == data[i].deptName)
                            {
                                flgKS = 1;

                                if (listime >= 0)
                                {
                                    data[i].itemCount++;
                                    // 急诊项目
                                    if (dr["emergency_int"].ToString().Trim() == "1")
                                    {
                                        if (energencyLimit >= listime)
                                            data[i].acceptCount++;
                                    }
                                    else     //非急诊
                                    {
                                        bool isAccept = IsAccept(dr);
                                        if (isAccept)
                                            data[i].acceptCount++;

                                        data[i].acceptPer = Math.Round(((double)data[i].acceptCount / (double)data[i].itemCount) * 100, 2).ToString();
                                    }
                                }
                            }
                        }

                        if (flgKS == 0)
                        {
                            EnitySampleAcceptable vo = new EnitySampleAcceptable();
                            if (listime >= 0)
                            {
                                // 急诊项目
                                if (dr["emergency_int"].ToString().Trim() == "1")
                                {
                                    if (energencyLimit >= listime)
                                        vo.acceptCount++;
                                }
                                else     //非急诊
                                {
                                    bool isAccept = IsAccept(dr);
                                    if (isAccept)
                                        vo.acceptCount++;
                                }
                                vo.deptName = dr["deptname"].ToString();
                                vo.itemCount = 1;
                                vo.acceptPer = Math.Round(((double)vo.acceptCount / (double)vo.itemCount) * 100, 2).ToString();
                                data.Add(vo);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("没有相关数据。");
                }

                if (data.Count > 0)
                {
                    EnitySampleAcceptable voSum = new EnitySampleAcceptable();
                    voSum.deptName = "全院合计";
                    for (int i = 0; i < data.Count; i++)
                    {
                        voSum.acceptCount += data[i].acceptCount;
                        voSum.itemCount += data[i].itemCount;
                    }
                    voSum.acceptPer = Math.Round(((double)voSum.acceptCount / (double)voSum.itemCount) * 100, 2).ToString();
                    data.Add(voSum);
                }

                m_objViewer.dgvdata.DataSource = data;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                clsPublic.CloseAvi();
            }
        }

        #endregion

        #region  检验报告发放时限符合率统计明细
        /// <summary>
        /// 
        /// </summary>
        public void m_mthGeSampleAcceptableDetail()
        {
            DataTable dtbResult;

            List<EntitySamepleDetail> data = new List<EntitySamepleDetail>();
            string enmergencyFlg = string.Empty;
            string patType = string.Empty;
            string dteStart = m_objViewer.dteStart.Text;
            string dteEnd = m_objViewer.dteEnd.Text;
            string applyUnitIdStr = string.Empty;
            string applyUnitId = string.Empty;
            string applyNameStr = string.Empty;
            string applyName = string.Empty;
            DataTable dtLimit = null;
            string groupId = string.Empty;

            try
            {
                string strDept = m_objViewer.DeptIdArr;
                if (m_objViewer.cboEmergency.Text.Trim() == "急诊项目")
                    enmergencyFlg = "1";
                else if (m_objViewer.cboEmergency.Text.Trim() == "非急诊项目")
                    enmergencyFlg = "0";

                if (m_objViewer.cboDeptType.Text.Trim() == "住院")
                    patType = "1";
                else if (m_objViewer.cboDeptType.Text.Trim() == "门诊")
                    patType = "2";


                foreach (var item in dicGroup)
                {
                    if (item.Value == m_objViewer.cbxGroup.Text)
                        groupId = item.Key;
                }

                if (m_objViewer.dgvCheckItem.Rows.Count >= 2)
                    groupId = "";

                m_objManage.lngGetAllLimitTime(out dtLimit);

                if (!string.IsNullOrEmpty(groupId))
                {
                    m_objManage.lngGetAllCheckItem(out dtbResult, groupId);
                    if (dtbResult != null && dtbResult.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtbResult.Rows)
                        {
                            applyUnitId = dr["项目编码"].ToString();
                            applyName = dr["项目名称"].ToString();

                            if (dtLimit != null && dtLimit.Rows.Count > 0)
                            {
                                DataRow[] drr = dtLimit.Select("applyunitid = '" + applyUnitId + "'");
                                if(drr != null && drr.Length > 0)
                                    applyUnitIdStr += "'" + drr[0]["applyunitid"].ToString() + "',";
                            }
                        }

                        if (!string.IsNullOrEmpty(applyUnitIdStr))
                            applyUnitIdStr = applyUnitIdStr.TrimEnd(',');
                    }

                    applyUnitIdStr = "(" + applyUnitIdStr.TrimEnd(',') + ")";
                }

                if (m_objViewer.dgvCheckItem.Rows.Count >= 2)
                {
                    applyUnitIdStr = string.Empty;

                    for (int i = 0; i < m_objViewer.dgvCheckItem.Rows.Count - 1; i++)
                    {
                        applyUnitId = m_objViewer.dgvCheckItem.Rows[i].Cells[0].Value.ToString();
                        applyName = m_objViewer.dgvCheckItem.Rows[i].Cells[1].Value.ToString();

                        if (dtLimit != null && dtLimit.Rows.Count > 0)
                        {
                            DataRow[] drr = dtLimit.Select("applyunitid = '" + applyUnitId + "'");
                            if (drr != null && drr.Length > 0)
                                applyUnitIdStr += "'" + drr[0]["applyunitid"].ToString() + "',";
                        }
                    }

                    if (!string.IsNullOrEmpty(applyUnitIdStr))
                        applyUnitIdStr = applyUnitIdStr.TrimEnd(',');
                }

                clsPublic.PlayAvi("findFILE.avi", "正在查询项目信息，请稍候...");

                long lngRes = m_objManage.lngGetSampleAcceptable(out dtbResult, dteStart, dteEnd, applyUnitIdStr, strDept, enmergencyFlg, patType);

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtbResult.Rows)
                    {
                        decimal listime = Convert.ToDecimal(dr["listime"]);           // 审核-核收（时间）
                        decimal energencyLimit = 0;

                        if (dr["emergencylimit"] != DBNull.Value)
                            energencyLimit = Convert.ToDecimal(dr["emergencylimit"].ToString().Trim());

                        EntitySamepleDetail vo = new EntitySamepleDetail();
                        if (listime >= 0)
                        {
                            if (listime >= 0)
                            {
                                vo.acceptFlg = "F";
                                // 急诊项目
                                if (dr["emergency_int"].ToString().Trim() == "1")
                                {
                                    if (energencyLimit >= listime)
                                        vo.acceptFlg = "T";
                                }
                                else     //非急诊
                                {
                                    bool isAccept = IsAccept(dr);

                                    if (isAccept)
                                        vo.acceptFlg = "T";
                                }

                                vo.HZXM = dr["HZXM"].ToString();
                                vo.DEPTNAME = dr["DEPTNAME"].ToString();

                                vo.BARCODE = dr["BARCODE"].ToString();
                                vo.CARDNO = string.IsNullOrEmpty(dr["CARDNO"].ToString()) ? dr["patInNo"].ToString() : dr["CARDNO"].ToString();
                                vo.ApplyTime = dr["applyTime"].ToString();
                                vo.AcceptTime = dr["accepttime"].ToString();
                                vo.HsWeek = calWeek(Convert.ToDateTime(vo.AcceptTime));
                                vo.ConfirmTime = dr["confirmtime"].ToString();
                                vo.Checker = dr["lastname_vchr"].ToString();
                                vo.item = dr["checkContent"].ToString();
                                if (dr["lisTime"] != DBNull.Value)
                                    vo.lisTime = Convert.ToDecimal(dr["lisTime"]) > 0 ? Convert.ToDecimal(dr["lisTime"]) : 0;

                                data.Add(vo);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("没有相关数据。");
                }

                m_objViewer.dgvStat.DataSource = data;

            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                clsPublic.CloseAvi();
            }
        }
        #endregion

        #region 列出所有检验项目
        /// <summary>
        /// 列出所有检验项目
        /// </summary>
        public void m_mthListCheckItem()
        {
            DataTable dtbResult;
            string groupId = string.Empty;
            foreach (KeyValuePair<string, string> kvp in dicGroup)
            {
                if (kvp.Value.Equals(this.m_objViewer.cbxGroup.Text))
                {
                    groupId = kvp.Key;
                }
            }

            long lngRes = m_objManage.lngGetAllCheckItem(out dtbResult, groupId);

            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                m_objViewer.dgvItem.DataSource = dtbResult;
            }
        }
        #endregion

        #region  m_mthGetCheckItemByName
        /// <summary>
        /// m_mthGetCheckItemByName
        /// </summary>
        public void m_mthGetCheckItemByName()
        {
            DataTable dtbResult;
            string strTempName = string.Empty;
            string strGroupId = string.Empty;
            strTempName = m_objViewer.txtSearchName.Text.Trim();
            string groupId = string.Empty;

            foreach (KeyValuePair<string, string> kvp in dicGroup)
            {
                if (kvp.Value.Equals(this.m_objViewer.cbxGroup.Text))
                {
                    strGroupId = kvp.Key;
                }
            }

            long lngRes = m_objManage.lngGetCheckItemByName(strTempName, strGroupId, out dtbResult);

            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                m_objViewer.dgvItem.DataSource = dtbResult;
            }
        }
        #endregion

        #region 导出EXCEL
        /// <summary>
        /// 
        /// </summary>
        public void m_mthExportToExcel()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出Excel文件到";
            string dteStart = m_objViewer.dteStart.Text;
            string dteEnd = m_objViewer.dteEnd.Text;
            string applyUnitName = string.Empty;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream = saveFileDialog.OpenFile();
                StreamWriter streamWriter = new StreamWriter(stream, Encoding.GetEncoding("gb2312"));
                string text = "";

                try
                {
                    for (int i = 0; i < this.m_objViewer.dgvdata.ColumnCount / 2; i++)
                    {
                        if (this.m_objViewer.dgvdata.Columns[i].Visible)
                        {
                            if (i > 0)
                            {
                                text += "\t";
                            }
                        }
                    }

                    if (m_objViewer.dgvCheckItem.Rows.Count >= 2)
                    {
                        for (int i = 0; i < m_objViewer.dgvCheckItem.Rows.Count - 1; i++)
                        {
                            applyUnitName += m_objViewer.dgvCheckItem.Rows[i].Cells[1].Value.ToString() + ",";
                        }

                        applyUnitName = applyUnitName.TrimEnd(',');
                    }

                    text += "检验报告发放时限符合率统计报表";
                    streamWriter.WriteLine(text);
                    text = dteStart + "~" + dteEnd + "              检验项目：" + applyUnitName;
                    streamWriter.WriteLine(text);
                    text = "";

                    for (int i = 0; i < this.m_objViewer.dgvdata.ColumnCount; i++)
                    {
                        if (this.m_objViewer.dgvdata.Columns[i].Visible)
                        {
                            if (i > 0)
                            {
                                text += "\t";
                            }
                            text += this.m_objViewer.dgvdata.Columns[i].HeaderText.Replace("\n", "");
                        }
                    }
                    streamWriter.WriteLine(text);
                    for (int i = 0; i < this.m_objViewer.dgvdata.Rows.Count; i++)
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        for (int j = 0; j < this.m_objViewer.dgvdata.Columns.Count; j++)
                        {
                            if (this.m_objViewer.dgvdata.Columns[j].Visible)
                            {
                                if (j > 0)
                                {
                                    stringBuilder.Append("\t");
                                }
                                stringBuilder.Append((this.m_objViewer.dgvdata.Rows[i].Cells[j].Value == null) ? "" : this.m_objViewer.dgvdata.Rows[i].Cells[j].Value.ToString());
                            }
                        }
                        streamWriter.WriteLine(stringBuilder);
                    }
                    MessageBox.Show("导出成功！", "检验报告发放时限符合率统计报表", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    streamWriter.Close();
                    stream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    streamWriter.Close();
                    stream.Close();
                }
            }
        }
        #endregion

        #region 导出EXCEL
        /// <summary>
        /// 
        /// </summary>
        public void m_mthExportToExcel2()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出Excel文件到";
            string dteStart = m_objViewer.dteStart.Text;
            string dteEnd = m_objViewer.dteEnd.Text;
            string applyUnitName = string.Empty;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream = saveFileDialog.OpenFile();
                StreamWriter streamWriter = new StreamWriter(stream, Encoding.GetEncoding("gb2312"));
                string text = "";

                try
                {
                    for (int i = 0; i < this.m_objViewer.dgvCheckItem.ColumnCount / 2; i++)
                    {
                        if (this.m_objViewer.dgvStat.Columns[i].Visible)
                        {
                            if (i > 0)
                            {
                                text += "\t";
                            }
                        }
                    }

                    if (m_objViewer.dgvCheckItem.Rows.Count >= 2)
                    {
                        for (int i = 0; i < m_objViewer.dgvCheckItem.Rows.Count - 1; i++)
                        {
                            applyUnitName += m_objViewer.dgvCheckItem.Rows[i].Cells[1].Value.ToString() + ",";
                        }

                        applyUnitName = applyUnitName.TrimEnd(',');
                    }

                    text += "检验报告发放时限明细报表";
                    streamWriter.WriteLine(text);
                    text = dteStart + "~" + dteEnd + "              检验项目：" + applyUnitName;
                    streamWriter.WriteLine(text);
                    text = "";

                    for (int i = 0; i < this.m_objViewer.dgvStat.ColumnCount; i++)
                    {
                        if (this.m_objViewer.dgvStat.Columns[i].Visible)
                        {
                            if (i > 0)
                            {
                                text += "\t";
                            }
                            text += this.m_objViewer.dgvStat.Columns[i].HeaderText.Replace("\n", "");
                        }
                    }
                    streamWriter.WriteLine(text);
                    for (int i = 0; i < this.m_objViewer.dgvStat.Rows.Count; i++)
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        for (int j = 0; j < this.m_objViewer.dgvStat.Columns.Count; j++)
                        {
                            if (this.m_objViewer.dgvStat.Columns[j].Visible)
                            {
                                if (j > 0)
                                {
                                    stringBuilder.Append("\t");
                                }
                                stringBuilder.Append((this.m_objViewer.dgvStat.Rows[i].Cells[j].Value == null) ? "" : this.m_objViewer.dgvStat.Rows[i].Cells[j].Value.ToString());
                            }
                        }
                        streamWriter.WriteLine(stringBuilder);
                    }
                    MessageBox.Show("导出成功！", "检验报告发放时限明细报表", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    streamWriter.Close();
                    stream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    streamWriter.Close();
                    stream.Close();
                }
            }
        }

        #endregion

        #region 关闭
        /// <summary>
        /// 
        /// </summary>
        public void Closed()
        {
            m_objViewer.Close();
        }

        #endregion

        #region 清空
        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            m_objViewer.dgvCheckItem.Rows.Clear();
        }
        #endregion

        #region calWeek
        /// <summary>
        /// calWeek
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string calWeek(DateTime dt)
        {
            string week = Convert.ToDateTime(dt).DayOfWeek.ToString();

            switch (week)
            {
                case "Monday":
                    week = "一";
                    break;
                case "Tuesday":
                    week = "二";
                    break;
                case "Wednesday":
                    week = "三";
                    break;
                case "Thursday":
                    week = "四";
                    break;
                case "Friday":
                    week = "五";
                    break;
                case "Saturday":
                    week = "六";
                    break;
                case "Sunday":
                    week = "日";
                    break;
            }

            return week;
        }
        #endregion

        private bool IsAccept(DataRow dr)
        {
            bool IsAccept = false;

            decimal listime = Convert.ToDecimal(dr["listime"]);           // 审核-核收（时间）
            DateTime? acceptTime = null;
            DateTime? confirmTime = null;

            string acceptTime1 = string.Empty;
            string acceptTime2 = string.Empty;
            string acceptTimeBegin2 = string.Empty;
            string acceptTimeEnd2 = string.Empty;
            string acceptTime3 = string.Empty;
            string acceptTimeBegin3 = string.Empty;
            string acceptTimeEnd3 = string.Empty;
            string acceptTime4 = string.Empty;

            string acceptTime5 = string.Empty;
            string acceptTimeBegin5 = string.Empty;
            string acceptTimeEnd5 = string.Empty;
            string acceptTime6 = string.Empty;
            string acceptTimeBegin6 = string.Empty;
            string acceptTimeEnd6 = string.Empty;

            string confirmEndTime = string.Empty;
            string week1 = string.Empty;
            string week2 = string.Empty;
            string week3 = string.Empty;
            string week4 = string.Empty;
            string week5 = string.Empty;
            string week6 = string.Empty;

            string confirTime1 = string.Empty;
            string confirTime2 = string.Empty;
            string confirTime3 = string.Empty;
            string confirTime4 = string.Empty;
            decimal normalLimit = 0;
            decimal energencyLimit = 0;
            decimal timelimit5 = 0;
            decimal timelimit6 = 0;

            if (dr["accepttime"] != DBNull.Value)
                acceptTime = Convert.ToDateTime(dr["acceptTime"]);     //核收时间
            if (dr["confirmTime"] != DBNull.Value)
                confirmTime = Convert.ToDateTime(dr["confirmTime"]);   //审核时间

            acceptTime1 = dr["acceptTime1"].ToString();
            acceptTime2 = dr["acceptTime2"].ToString();
            acceptTime3 = dr["acceptTime3"].ToString();
            acceptTime4 = dr["acceptTime4"].ToString();
            acceptTime5 = dr["acceptTime5"].ToString();
            acceptTime6 = dr["acceptTime6"].ToString();

            confirmEndTime = dr["confirmEndTime"].ToString();
            confirTime1 = dr["confirTime1"].ToString();
            confirTime2 = dr["confirTime2"].ToString();
            confirTime3 = dr["confirTime3"].ToString();
            confirTime4 = dr["confirTime4"].ToString();

            week1 = dr["week1"].ToString().Trim();
            week2 = dr["week2"].ToString().Trim();
            week3 = dr["week3"].ToString().Trim();
            week4 = dr["week4"].ToString().Trim();
            week5 = dr["week5"].ToString().Trim();
            week6 = dr["week6"].ToString().Trim();

            if (dr["normallimit"] != DBNull.Value)
                normalLimit = Convert.ToDecimal(dr["normallimit"].ToString().Trim());
            if (dr["emergencylimit"] != DBNull.Value)
                energencyLimit = Convert.ToDecimal(dr["emergencylimit"].ToString().Trim());
            if (dr["timelimit5"] != DBNull.Value)
                timelimit5 = Convert.ToDecimal(dr["timelimit5"].ToString().Trim());
            if (dr["timelimit6"] != DBNull.Value)
                timelimit6 = Convert.ToDecimal(dr["timelimit6"].ToString().Trim());

            string acceptTimeTmp = Convert.ToDateTime(acceptTime).ToString("HH:mm:ss");
            string confirmTimeTmp = Convert.ToDateTime(confirmTime).ToString("HH:mm:ss");

            TimeSpan tsAcceptTime = DateTime.Parse(acceptTimeTmp).TimeOfDay;
            TimeSpan tsConfirTime = DateTime.Parse(confirmTimeTmp).TimeOfDay;

            TimeSpan tsAcceptTime1;
            TimeSpan tsConfirTime1;
            TimeSpan tsAcceptTimeBegin2;
            TimeSpan tsAcceptTimeEnd2;
            TimeSpan tsConfirTime2;
            TimeSpan tsAcceptTimeBegin3;
            TimeSpan tsAcceptTimeEnd3;
            TimeSpan tsConfirTime3;
            TimeSpan tsAcceptTime4;
            TimeSpan tsConfirTime4;
            TimeSpan tsAcceptTimeBegin5;
            TimeSpan tsAcceptTimeEnd5;
            TimeSpan tsAcceptTimeBegin6;
            TimeSpan tsAcceptTimeEnd6;
            TimeSpan tsConfirmEndTime = DateTime.Parse("00:00:00").TimeOfDay;
            if (!string.IsNullOrEmpty(confirmEndTime))
                tsConfirmEndTime = DateTime.Parse(confirmEndTime).TimeOfDay;

            #region  指定星期
            if ((!string.IsNullOrEmpty(confirmTime.ToString()) && (!string.IsNullOrEmpty(week1) || !string.IsNullOrEmpty(week2) ||
                    !string.IsNullOrEmpty(week3) || !string.IsNullOrEmpty(week4) || !string.IsNullOrEmpty(week5) || !string.IsNullOrEmpty(week6))))
            {
                string week = calWeek(Convert.ToDateTime(acceptTime));
                if (week == week1 || week == week2 || week == week3 || week == week4 || week == week5 || week == week6)
                {
                    if (tsConfirTime <= tsConfirmEndTime)
                    {
                        IsAccept = true;
                    }
                }
            }
            #endregion

            #region   核收时间-截止时间点

            if (!string.IsNullOrEmpty(confirTime1) && !string.IsNullOrEmpty(acceptTime1))
            {
                tsAcceptTime1 = DateTime.Parse(acceptTime1).TimeOfDay;
                tsConfirTime1 = DateTime.Parse(confirTime1).TimeOfDay;

                if (tsAcceptTime1 >= tsAcceptTime && tsConfirTime1 >= tsConfirTime)
                {
                    IsAccept = true;
                }
            }

            if (!string.IsNullOrEmpty(confirTime2) && !string.IsNullOrEmpty(acceptTime2))
            {
                tsAcceptTimeBegin2 = DateTime.Parse(acceptTime2.Split('~')[0]).TimeOfDay;
                tsAcceptTimeEnd2 = DateTime.Parse(acceptTime2.Split('~')[1]).TimeOfDay;
                tsConfirTime2 = DateTime.Parse(confirTime2).TimeOfDay;

                if (tsAcceptTime >= tsAcceptTimeBegin2 && tsAcceptTime <= tsAcceptTimeEnd2 && tsConfirTime2 >= tsConfirTime)
                {
                    IsAccept = true;
                }
            }

            if (!string.IsNullOrEmpty(confirTime3) && !string.IsNullOrEmpty(acceptTime3))
            {
                tsAcceptTimeBegin3 = DateTime.Parse(acceptTime3.Split('~')[0]).TimeOfDay;
                tsAcceptTimeEnd3 = DateTime.Parse(acceptTime3.Split('~')[1]).TimeOfDay;
                tsConfirTime3 = DateTime.Parse(confirTime3).TimeOfDay;

                if (tsAcceptTime >= tsAcceptTimeBegin3 && tsAcceptTime <= tsAcceptTimeEnd3 && tsConfirTime3 >= tsConfirTime)
                {
                    IsAccept = true;
                }
            }

            if (!string.IsNullOrEmpty(confirTime4) && !string.IsNullOrEmpty(acceptTime4))
            {
                tsAcceptTime4 = DateTime.Parse(acceptTime4).TimeOfDay;
                tsConfirTime4 = DateTime.Parse(confirTime4).TimeOfDay;

                if (tsAcceptTime4 <= tsAcceptTime && tsConfirTime4 >= tsConfirTime)
                {
                    IsAccept = true;
                }
            }

            #endregion

            #region 核收时间-截止时间长度
            if (!string.IsNullOrEmpty(acceptTime.ToString()) && !string.IsNullOrEmpty(acceptTime5))
            {
                tsAcceptTimeEnd5 = DateTime.Parse(acceptTime5.Split('~')[1]).TimeOfDay;
                tsAcceptTimeBegin5 = DateTime.Parse(acceptTime5.Split('~')[0]).TimeOfDay;

                if (tsAcceptTime >= tsAcceptTimeBegin5 && tsAcceptTime <= tsAcceptTimeEnd5 && timelimit5 > 0)
                {
                    if (timelimit5 >= listime)
                        IsAccept = true;
                }
            }

            if (!string.IsNullOrEmpty(acceptTime.ToString()) && !string.IsNullOrEmpty(acceptTime6))
            {
                tsAcceptTimeEnd6 = DateTime.Parse(acceptTime6.Split('~')[1]).TimeOfDay;
                tsAcceptTimeBegin6 = DateTime.Parse(acceptTime6.Split('~')[0]).TimeOfDay;

                if (tsAcceptTime >= tsAcceptTimeBegin6 && tsAcceptTime <= tsAcceptTimeEnd6 && timelimit6 > 0)
                {
                    if (timelimit6 >= listime)
                        IsAccept = true;
                }
            }

            #endregion

            #region  都不在指定核收时间
            if ((normalLimit - listime) >= 0)
            {
                IsAccept = true;
            }
            #endregion

            return IsAccept;
        }

    }
}
