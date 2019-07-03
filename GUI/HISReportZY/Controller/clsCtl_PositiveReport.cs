using System;
using System.Collections.Generic;
using System.Text;
using Sybase.DataWindow;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class clsCtl_PositiveReport : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 构造函数
        public clsCtl_PositiveReport()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_objManage = new clsDcl_PositiveReport();
        }
        #endregion

        // <summary>
        /// 类变量
        /// </summary>
        private frmPositiveReport m_objViewer;
        internal bool IsEnglish = false;
        private clsDcl_PositiveReport m_objManage;
        Dictionary<string, string> dicGroup;

        #region Entity
        /// <summary>
        /// 
        /// </summary>
        public class EnityPositiveReport
        {
            public string reportDate { get; set; }
            public string name { get; set; }
            public string sex { get; set; }
            public string deptName { get; set; }
            public string patNo { get; set; }
            public string itemName { get; set; }
            public string itemResult { get; set; }
            public string checker { get; set; }
            public string applyDoct { get; set; }
            public string refrange { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class EntitPositivePerReport
        {
            public string itemName { get; set; }
            public decimal itemCount { get; set; }
            public decimal lowCount { get; set; }
            public string lowPer { get; set; }
            public decimal higerCount { get; set; }
            public string higerPer { get; set; }
            public string itemId { get; set; }
        }

        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            m_objViewer = (frmPositiveReport)frmMDI_Child_Base_in;
        }
        #endregion

        #region   init
        /// <summary>
        /// 
        /// </summary>
        public void m_mthInti()
        {
            DataTable dtbResult;
            dicGroup = new Dictionary<string, string>();
            m_objViewer.tabContorl.Visible = false;
            m_objViewer.dgvPositiveResult.Visible = true;
            m_objViewer.dteStart.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() +"-"+ DateTime.Now.Day.ToString());
            m_objViewer.cboStatType.Items.AddRange(new object[] { "检验项目阳性结果分析统计表", "检验项目结果分析汇总表", "检验项目阳性率分析统计表" });
            m_objViewer.cboStatType.SelectedIndex = 0;
            m_objManage.lngGetAllCheckSpec(out dtbResult);

            for (int i = 0; i < dtbResult.Rows.Count; i++)
            {
                m_objViewer.cbxGroup.Items.Add(dtbResult.Rows[i]["check_category_desc_vchr"].ToString());
                dicGroup.Add(dtbResult.Rows[i]["check_category_id_chr"].ToString(), dtbResult.Rows[i]["check_category_desc_vchr"].ToString());
            }
        }
        #endregion 

        #region  检验项目阳性结果分析统计表
        /// <summary>
        /// 
        /// </summary>
        public void m_mthGetPositiveReport()
        {
            DataTable dtbResult;

            List<EnityPositiveReport> data = new List<EnityPositiveReport>();
            string groupId = string.Empty;
            string dteStart = m_objViewer.dteStart.Text;
            string dteEnd = m_objViewer.dteEnd.Text;
 
            string checkItemId = string.Empty;
            clsPublic.PlayAvi("findFILE.avi", "正在查询项目信息，请稍候...");
            try
            {
                if (m_objViewer.dgvCheckItem.Rows.Count >= 2)
                {
                    for (int i = 0; i < m_objViewer.dgvCheckItem.Rows.Count - 1; i++)
                    {
                        checkItemId += "'" + m_objViewer.dgvCheckItem.Rows[i].Cells[0].Value.ToString() + "',";
                    }

                    checkItemId = "(" + checkItemId.TrimEnd(',') + ")";
                }

                if (string.IsNullOrEmpty(checkItemId))
                {
                    MessageBox.Show("检验项目不能为空。");
                    return;
                }

                string strDept = m_objViewer.DeptIdArr;
                string patNo = m_objViewer.txtPatNo.Text;

                foreach (var item in dicGroup)
                {
                    if (item.Value == m_objViewer.cbxGroup.Text)
                        groupId = item.Key;
                }

                if (m_objViewer.dgvCheckItem.Rows.Count >= 2)
                    groupId = "";

                long lngRes = m_objManage.lngGetPositiveReport(out dtbResult, dteStart, dteEnd, checkItemId, strDept, groupId, patNo);

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtbResult.Rows)
                    {
                        string result = string.Empty;
                        string abnormal = string.Empty;
                        EnityPositiveReport vo = new EnityPositiveReport();
                        result = ToDBC(dr["result_vchr"].ToString().Trim());
                        result = result.Replace(">", "").Replace("<", "").Replace("≤", "").Replace("≥", "").Replace("LO", "").Replace("HI", "").Trim();
                        abnormal = dr["abnormal"].ToString().Trim();
                        if (abnormal.Contains("H"))
                        {
                            abnormal = "H";
                        }
                        if (!abnormal.Contains("H") && !abnormal.Contains("L") && !result.Contains("阳"))
                            continue;
                        vo.refrange = dr["refrange_vchr"].ToString();
                        vo.reportDate = Convert.ToDateTime(dr["BGSJ"]).ToString("yyyy-MM-dd HH:mm");
                        vo.name = dr["HZXM"].ToString();
                        vo.sex = dr["sex_chr"].ToString().Trim();
                        vo.deptName = dr["deptName"].ToString();

                        if (string.IsNullOrEmpty(vo.deptName))
                            continue;
                        if (!string.IsNullOrEmpty(dr["patient_inhospitalno_chr"].ToString()))
                            vo.patNo = dr["patient_inhospitalno_chr"].ToString();
                        else
                            vo.patNo = dr["patientcardid_chr"].ToString();

                        vo.itemName = dr["check_item_name_vchr"].ToString();
                        vo.applyDoct = dr["applyDoct"].ToString();
                        vo.checker = dr["checker"].ToString();
                        vo.itemResult = dr["result_vchr"].ToString().Trim();
                        data.Add(vo);
                    }
                }
                else
                {
                    MessageBox.Show("没有相关数据。");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                clsPublic.CloseAvi();
            }

            m_objViewer.dgvPositiveResult.DataSource = data;
        }

        #endregion

        #region  检验项目结果分析汇总表
        /// <summary>
        /// 
        /// </summary>
        public void m_mthGetLisResultReport()
        {
            DataTable dtbResult;

            List<EnityPositiveReport> data = new List<EnityPositiveReport>();
            string groupId = string.Empty;
            string dteStart = m_objViewer.dteStart.Text;
            string dteEnd = m_objViewer.dteEnd.Text;
            string checkItemId = string.Empty;

            clsPublic.PlayAvi("findFILE.avi", "正在查询项目信息，请稍候...");
            try
            {
                if (m_objViewer.dgvCheckItem.Rows.Count >= 2)
                {
                    for (int i = 0; i < m_objViewer.dgvCheckItem.Rows.Count - 1; i++)
                    {
                        checkItemId += "'" + m_objViewer.dgvCheckItem.Rows[i].Cells[0].Value.ToString() + "',";
                    }

                    checkItemId = "(" + checkItemId.TrimEnd(',') + ")";
                }
                string strDept = m_objViewer.DeptIdArr;
                string patNo = m_objViewer.txtPatNo.Text;



                long lngRes = m_objManage.lngGetPositiveReport(out dtbResult, dteStart, dteEnd, checkItemId, strDept, groupId, patNo);

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtbResult.Rows)
                    {
                        string strMaxVal = string.Empty;
                        string strMinVal = string.Empty;
                        string refRange = string.Empty;
                        string result = string.Empty;
                        EnityPositiveReport vo = new EnityPositiveReport();

                        result = ToDBC(dr["result_vchr"].ToString().Trim());
                        strMaxVal = ToDBC(dr["max_val_dec"].ToString());
                        strMinVal = ToDBC(dr["min_val_dec"].ToString());
                        refRange = ToDBC(dr["refrange_vchr"].ToString().Trim());

                        vo.itemResult = dr["result_vchr"].ToString();
                        vo.refrange = dr["refrange_vchr"].ToString();
                        vo.reportDate = Convert.ToDateTime(dr["BGSJ"]).ToString("yyyy-MM-dd HH:mm");
                        vo.name = dr["HZXM"].ToString();
                        vo.sex = dr["sex_chr"].ToString().Trim();
                        vo.deptName = dr["deptName"].ToString();

                        if (string.IsNullOrEmpty(vo.deptName))
                            continue;
                        if (!string.IsNullOrEmpty(dr["patient_inhospitalno_chr"].ToString()))
                            vo.patNo = dr["patient_inhospitalno_chr"].ToString();
                        else
                            vo.patNo = dr["patientcardid_chr"].ToString();

                        vo.itemName = dr["check_item_name_vchr"].ToString();
                        vo.applyDoct = dr["applyDoct"].ToString();
                        vo.checker = dr["checker"].ToString();

                        data.Add(vo);
                    }
                }
                else
                {
                    MessageBox.Show("没有相关数据。");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                clsPublic.CloseAvi();
            }

            m_objViewer.dgvPositiveResult.DataSource = data;
        }

        #endregion

        #region 检验项目阳性率分析统计表
        /// <summary>
        /// 
        /// </summary>
        public void m_mthGetPositivePerReport()
        {
            DataTable dtbResult;

            List<EntitPositivePerReport> data = new List<EntitPositivePerReport>();
            string groupId = string.Empty;
            string dteStart = m_objViewer.dteStart.Text;
            string dteEnd = m_objViewer.dteEnd.Text;
            string checkItemId = string.Empty;

            clsPublic.PlayAvi("findFILE.avi", "正在查询项目信息，请稍候...");
            try
            {
                if (m_objViewer.dgvCheckItem.Rows.Count >= 2)
                {
                    for (int i = 0; i < m_objViewer.dgvCheckItem.Rows.Count - 1; i++)
                    {
                        checkItemId += "'" + m_objViewer.dgvCheckItem.Rows[i].Cells[0].Value.ToString() + "',";
                    }

                    checkItemId = "(" + checkItemId.TrimEnd(',') + ")";
                }
                string strDept = m_objViewer.DeptIdArr;
                string patNo = m_objViewer.txtPatNo.Text;
                int flg = 0;

                long lngRes = m_objManage.lngGetPositiveReport(out dtbResult, dteStart, dteEnd, checkItemId, strDept, groupId, patNo);

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtbResult.Rows)
                    {
                        string itemName = string.Empty;
                        string itemId = string.Empty;
                        string abnormal = string.Empty;
                        string result = string.Empty;
                        result = ToDBC(dr["result_vchr"].ToString().Trim());
                        result = result.Replace(">", "").Replace("<", "").Replace("≤", "").Replace("≥", "").Replace("LO", "").Replace("HI", "").Trim();
                        DataRow drRet = dr;
                        flg = 0;
                        itemName = dr["check_item_name_vchr"].ToString();
                        itemId = dr["check_item_id_chr"].ToString().Trim();

                        string deptName = dr["deptName"].ToString();

                        if (string.IsNullOrEmpty(deptName))
                            continue;

                        for (int i = 0; i < data.Count; i++)
                        {
                            if (itemId == data[i].itemId)
                            {
                                flg = 1;
                                EntitPositivePerReport vo = data[i];
                                abnormal = dr["abnormal"].ToString().Trim();

                                if (abnormal == "H")
                                    vo.higerCount++;
                                else if (abnormal == "L")
                                    vo.lowCount++;
                                else if(result.Contains("阳"))
                                    vo.higerCount++;

                                vo.lowPer = (vo.lowCount / vo.itemCount).ToString("0.00%");
                                vo.higerPer = (vo.higerCount / vo.itemCount).ToString("0.00%");
                                data[i] = vo;
                            }
                        }

                        if (flg == 0)
                        {
                            EntitPositivePerReport vo = new EntitPositivePerReport();

                            abnormal = dr["abnormal"].ToString().Trim();
                            if (abnormal == "H")
                                vo.higerCount++;
                            else if (abnormal == "L")
                                vo.lowCount++;
                            else if (result.Contains("阳"))
                                vo.higerCount++;
                            vo.itemName = itemName;
                            vo.itemId = itemId;
                            DataRow[] drResult = dtbResult.Select("check_item_id_chr = '" + vo.itemId + "'");

                            if (drResult != null && drResult.Length > 0)
                            {
                                vo.itemCount = drResult.Length;
                            }
                            vo.lowPer = (vo.lowCount / vo.itemCount).ToString("0.00%");
                            vo.higerPer = (vo.higerCount / vo.itemCount).ToString("0.00%");
                            data.Add(vo);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("没有相关数据。");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally 
            {
                clsPublic.CloseAvi();
            }

            m_objViewer.dgvPositivePer.DataSource = data;
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

            //long lngRes = m_objManage.lngGetAllCheckItem(out dtbResult, groupId);
            long lngRes = m_objManage.lngGetAllCheckItemDetail(out dtbResult, groupId);

            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                m_objViewer.dgvItem.DataSource = dtbResult;
            }
        }
        #endregion

        #region   名字查找检验项目
        /// <summary>
        /// 
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

            long lngRes = m_objManage.lngGetCheckItemDetailByNameCpy(strTempName, strGroupId, out dtbResult);

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
        /// <param name="statType"></param>
        public void m_mthExportToExcel(int statType)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出Excel文件到";
            string dteStart = m_objViewer.dteStart.Text;
            string dteEnd = m_objViewer.dteEnd.Text;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream = saveFileDialog.OpenFile();
                StreamWriter streamWriter = new StreamWriter(stream, Encoding.GetEncoding("gb2312"));
                string text = "";
                string itemStr = string.Empty;
                string title = string.Empty;

                try
                {
                    for (int i = 0; i < this.m_objViewer.dgvPositiveResult.ColumnCount / 2; i++)
                    {
                        if (this.m_objViewer.dgvPositiveResult.Columns[i].Visible)
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
                            itemStr += "'" + m_objViewer.dgvCheckItem.Rows[i].Cells[0].Value.ToString() + "',";
                        }

                        itemStr = itemStr.TrimEnd(',');
                    }

                    //"检验项目阳性结果分析统计表", "检验项目结果分析汇总表", "检验项目阳性率分析统计表" 

                    if (statType == 0)
                    {
                        text += "检验项目阳性结果分析统计表";

                        streamWriter.WriteLine(text);
                        text = dteStart + "~" + dteEnd + itemStr;
                        streamWriter.WriteLine(text);
                        text = "";

                        for (int i = 0; i < this.m_objViewer.dgvPositiveResult.ColumnCount; i++)
                        {
                            if (this.m_objViewer.dgvPositiveResult.Columns[i].Visible)
                            {
                                if (i > 0)
                                {
                                    text += "\t";
                                }
                                text += this.m_objViewer.dgvPositiveResult.Columns[i].HeaderText.Replace("\n", "");
                            }
                        }
                        streamWriter.WriteLine(text);
                        for (int i = 0; i < this.m_objViewer.dgvPositiveResult.Rows.Count; i++)
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            for (int j = 0; j < this.m_objViewer.dgvPositiveResult.Columns.Count; j++)
                            {
                                if (this.m_objViewer.dgvPositiveResult.Columns[j].Visible)
                                {
                                    if (j > 0)
                                    {
                                        stringBuilder.Append("\t");
                                    }
                                    stringBuilder.Append((this.m_objViewer.dgvPositiveResult.Rows[i].Cells[j].Value == null) ? "" : this.m_objViewer.dgvPositiveResult.Rows[i].Cells[j].Value.ToString());
                                }
                            }
                            streamWriter.WriteLine(stringBuilder);
                        }
                    }
                    if (statType == 1)
                    {
                        text += "检验项目结果分析汇总表";

                        streamWriter.WriteLine(text);
                        text = dteStart + "~" + dteEnd + itemStr;
                        streamWriter.WriteLine(text);
                        text = "";

                        for (int i = 0; i < this.m_objViewer.dgvPositiveResult.ColumnCount; i++)
                        {
                            if (this.m_objViewer.dgvPositiveResult.Columns[i].Visible)
                            {
                                if (i > 0)
                                {
                                    text += "\t";
                                }
                                text += this.m_objViewer.dgvPositiveResult.Columns[i].HeaderText.Replace("\n", "");
                            }
                        }
                        streamWriter.WriteLine(text);
                        for (int i = 0; i < this.m_objViewer.dgvPositiveResult.Rows.Count; i++)
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            for (int j = 0; j < this.m_objViewer.dgvPositiveResult.Columns.Count; j++)
                            {
                                if (this.m_objViewer.dgvPositiveResult.Columns[j].Visible)
                                {
                                    if (j > 0)
                                    {
                                        stringBuilder.Append("\t");
                                    }
                                    stringBuilder.Append((this.m_objViewer.dgvPositiveResult.Rows[i].Cells[j].Value == null) ? "" : this.m_objViewer.dgvPositiveResult.Rows[i].Cells[j].Value.ToString());
                                }
                            }
                            streamWriter.WriteLine(stringBuilder);
                        }
                    }
                    if (statType == 2)
                    {
                        text += "检验项目阳性率分析统计表";

                        streamWriter.WriteLine(text);
                        text = dteStart + "~" + dteEnd + itemStr;
                        streamWriter.WriteLine(text);
                        text = "";

                        for (int i = 0; i < this.m_objViewer.dgvPositivePer.ColumnCount; i++)
                        {
                            if (this.m_objViewer.dgvPositivePer.Columns[i].Visible)
                            {
                                if (i > 0)
                                {
                                    text += "\t";
                                }
                                text += this.m_objViewer.dgvPositivePer.Columns[i].HeaderText.Replace("\n", "");
                            }
                        }
                        streamWriter.WriteLine(text);
                        for (int i = 0; i < this.m_objViewer.dgvPositivePer.Rows.Count; i++)
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            for (int j = 0; j < this.m_objViewer.dgvPositiveResult.Columns.Count; j++)
                            {
                                if (this.m_objViewer.dgvPositivePer.Columns[j].Visible)
                                {
                                    if (j > 0)
                                    {
                                        stringBuilder.Append("\t");
                                    }
                                    stringBuilder.Append((this.m_objViewer.dgvPositivePer.Rows[i].Cells[j].Value == null) ? "" : this.m_objViewer.dgvPositivePer.Rows[i].Cells[j].Value.ToString());
                                }
                            }
                            streamWriter.WriteLine(stringBuilder);
                        }
                    }

                    
                    MessageBox.Show("导出成功！", "检验项目阳性结果分析统计表", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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


        #region 清空
        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            m_objViewer.dgvCheckItem.Rows.Clear();
        }
        #endregion




        #region 方法

        /// <summary>
        /// 全角转半角
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string ToDBC(String input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }

            return  new String(c);
        }
        #endregion 

        #endregion

    }
}
