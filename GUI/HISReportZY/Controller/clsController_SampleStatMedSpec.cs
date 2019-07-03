using System;
using System.Collections.Generic;
using com.digitalwave.iCare.gui.HIS.Reports;
using System.Text;
using Sybase.DataWindow;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class clsController_SampleStatMedSpec : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 构造函数
        public clsController_SampleStatMedSpec()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_objManage = new clsDomainController_SampleStatMedSpec();
        }
        #endregion


        // <summary>
        /// 类变量
        /// </summary>
        private frmSampleStatMedSpec m_objViewer;
        internal bool IsEnglish = false;
        private clsDomainController_SampleStatMedSpec m_objManage;
        private Transaction m_objTransation;
        Dictionary<string, string> dicGroup;


        #region Entity
        /// <summary>
        /// 
        /// </summary>
        public class EnitySapleMedSpec 
        {
            public string deptName { get; set; }
            //public string checkItem { get; set; }
            public decimal preMaxTime { get; set; }
            public decimal preMinTime { get; set; }
            public decimal preMidTime { get; set; }
            public decimal lisMaxTime { get; set; }
            public decimal lisMinTime { get; set; }
            public decimal lisMidTime { get; set; }
            public decimal BBS { get; set; }
            //public decimal sampleCount { get; set; }
        }

        public class EntitySamepleStat
        {
            public string HZXM { get; set; }
            public string DEPTNAME { get; set; }
            public string BARCODE  { get; set; }
            public string CARDNO  { get; set; }
            public string patInNo { get; set; }
            public decimal preTime { get; set; }
            public decimal lisTime { get; set; }
        }
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            m_objViewer = (frmSampleStatMedSpec)frmMDI_Child_Base_in;
            this.m_objTransation = new Transaction();
            string ServerName = "";
            string UserID = "";
            string Pwd = "";
            clsPublic.m_mthGetICareParm(out ServerName, out UserID, out Pwd);
            m_objTransation = new Transaction();
            m_objTransation.Dbms = Sybase.DataWindow.DbmsType.Oracle9i;
            m_objTransation.ServerName = ServerName;
            m_objTransation.UserId = UserID;
            m_objTransation.Password = Pwd;
            m_objTransation.AutoCommit = true;
            m_objTransation.Connect();
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public void m_mthInti()
        {
            DataTable dtbResult;
            dicGroup = new Dictionary<string, string>();
            m_objViewer.tabContorl.Visible = false;
            m_objViewer.dgvdata.Visible = true;
            m_objViewer.dteStart.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01");
            m_objViewer.cboStatType.Items.AddRange(new object[] { "检验标本周转中位数统计表", "检验标本周转中位数汇总" });
            m_objViewer.cboStatType.SelectedIndex = 0;
            m_objViewer.cboPatType.Items.Add("住院");
            m_objViewer.cboPatType.Items.Add("门诊");
            m_objViewer.cboEmergency.Items.Add("急诊项目");
            m_objViewer.cboEmergency.Items.Add("非急诊项目");
            m_objManage.lngGetAllCheckSpec(out dtbResult);

            for (int i = 0; i < dtbResult.Rows.Count; i++)
            {
                m_objViewer.cbxGroup.Items.Add(dtbResult.Rows[i]["check_category_desc_vchr"].ToString());
                dicGroup.Add(dtbResult.Rows[i]["check_category_id_chr"].ToString(), dtbResult.Rows[i]["check_category_desc_vchr"].ToString());
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
            string groupId = string.Empty ;
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

        #region  检验标本周转中位数统计表
        /// <summary>
        /// 
        /// </summary>
        public void m_mthGeSampleStatSpec()
        {
            DataTable dtbResult;
            if (string.IsNullOrEmpty(m_objViewer.cbxGroup.Text) && m_objViewer.dgvCheckItem.Rows.Count < 2)
            {
                MessageBox.Show("请选择专业组或检验项目 ！");
                return;
            }

            List<EnitySapleMedSpec> data = new List<EnitySapleMedSpec>();
            string groupId = string.Empty;
            string enmergencyFlg = string.Empty;
            string patType = string.Empty;
            string dteStart = m_objViewer.dteStart.Text;
            string dteEnd = m_objViewer.dteEnd.Text;
            string applyUnitId = string.Empty;

            if (m_objViewer.dgvCheckItem.Rows.Count >= 2)
            {
                //applyUnitId = m_objViewer.dgvCheckItem.Rows[0].Cells[0].Value.ToString();

                for (int i = 0; i < m_objViewer.dgvCheckItem.Rows.Count-1; i++)
                {
                    applyUnitId += "'" + m_objViewer.dgvCheckItem.Rows[i].Cells[0].Value.ToString() + "',";
                }

                applyUnitId = "(" + applyUnitId.TrimEnd(',') + ")";
            }
            
            string strDept = m_objViewer.DeptIdArr;
            if (m_objViewer.cboEmergency.Text.Trim() == "急诊项目")
                enmergencyFlg = "1";
            else if (m_objViewer.cboEmergency.Text.Trim() == "非急诊项目")
                enmergencyFlg = "0";

            if (m_objViewer.cboPatType.Text.Trim() == "住院")
                patType = "1";
            else if (m_objViewer.cboPatType.Text.Trim() == "门诊")
                patType = "2";

            if (m_objViewer.DeptIdArr == "'0000001'")
                strDept = string.Empty;

            foreach (var item in dicGroup)
            {
                if (item.Value == m_objViewer.cbxGroup.Text)
                    groupId = item.Key;
            }

            if (m_objViewer.dgvCheckItem.Rows.Count >= 2)
                groupId = "";

            clsPublic.PlayAvi("findFILE.avi", "正在查询项目信息，请稍候...");
            
            long lngRes = m_objManage.lngGetSampleMedSpec(out dtbResult, dteStart, dteEnd,groupId, applyUnitId, strDept,enmergencyFlg,patType);
            int flg = 0;

            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                //this.FillDWMicSensitive(dtbResult, strTempName);
                //m_objViewer.dgvdata.DataSource = dtbResult;

                foreach(DataRow dr in dtbResult.Rows)
                {
                    string deptName = dr["deptname"].ToString();
                    flg = 0;

                    if (m_objViewer.DeptIdArr == "'0000001'")
                        deptName = "全院";

                    for (int i = 0; i < data.Count; i++)
                    {
                        if (deptName == data[i].deptName)
                        {
                            if (dr["pretime"] != DBNull.Value)
                            {
                                if (data[i].preMaxTime < Convert.ToDecimal(dr["pretime"]) && Convert.ToDecimal(dr["pretime"]) > 0 )
                                    data[i].preMaxTime = Convert.ToDecimal(dr["pretime"]);
                                if (data[i].preMinTime > Convert.ToDecimal(dr["pretime"]) && Convert.ToDecimal(dr["pretime"]) > 0 )
                                    data[i].preMinTime = Convert.ToDecimal(dr["pretime"]);
                            }

                            if (dr["listime"] != DBNull.Value)
                            {
                                if (data[i].lisMaxTime < Convert.ToDecimal(dr["listime"]) && Convert.ToDecimal(dr["listime"]) > 0 )
                                    data[i].lisMaxTime = Convert.ToDecimal(dr["listime"]);
                                if (data[i].lisMinTime > Convert.ToDecimal(dr["listime"]) && Convert.ToDecimal(dr["listime"]) > 0 )
                                    data[i].lisMinTime = Convert.ToDecimal(dr["listime"]);
                            }

                            //data[i].sampleCount++;
                            data[i].BBS++;

                            flg = 1;
                        }
                    }

                    if(flg == 0)
                    {
                        EnitySapleMedSpec vo = new EnitySapleMedSpec();
                        if (dr["lisTime"] == DBNull.Value)
                        {
                            vo.lisMaxTime = 0;
                            vo.lisMinTime = 0;
                        }
                        else if (Convert.ToDecimal(dr["lisTime"]) > 0)
                        {
                            vo.lisMaxTime = Convert.ToDecimal(dr["lisTime"]);
                            vo.lisMinTime = Convert.ToDecimal(dr["lisTime"]);
                        }

                        if (dr["preTime"] == DBNull.Value)
                        {
                            vo.preMaxTime = 0;
                            vo.preMinTime = 0;
                        }
                        else if (Convert.ToDecimal(dr["preTime"]) > 0)
                        {
                            vo.preMaxTime = Convert.ToDecimal(dr["preTime"]);
                            vo.preMinTime = Convert.ToDecimal(dr["preTime"]);
                        }

                        vo.deptName = deptName;
                        vo.BBS = 1;
                        data.Add(vo);
                    }
                }
            }
            else
            {
                MessageBox.Show("没有相关数据。");
                return;
            }

            for (int i = 0; i < data.Count; i++)
            {
                DataRow[] preDrr = null;
                DataRow[] lisDrr = null;

                if (m_objViewer.DeptIdArr == "'0000001'")
                {
                    preDrr = dtbResult.Select("pretime > 0", " pretime desc");
                    lisDrr = dtbResult.Select("listime > 0", " listime desc");
                }
                else
                {
                    preDrr = dtbResult.Select("deptname = '" + data[i].deptName + "' and pretime > 0", " pretime desc");
                    lisDrr = dtbResult.Select("deptname = '" + data[i].deptName + "' and listime > 0", " listime desc");
                }

                if (preDrr.Length > 0)
                {
                    int residPre = preDrr.Length % 2;
                    int remaindPre = preDrr.Length / 2;

                    ////偶数
                    if (residPre == 0)
                    {
                        data[i].preMidTime = (Convert.ToDecimal(preDrr[remaindPre]["pretime"]) + Convert.ToDecimal(preDrr[remaindPre - 1]["pretime"])) / 2;
                    }
                    else
                    {
                        data[i].preMidTime = Convert.ToDecimal(preDrr[remaindPre]["pretime"]);
                    }
                }

                if (lisDrr.Length > 0)
                {
                    int residLis = lisDrr.Length % 2;
                    int remaindLis = lisDrr.Length / 2;
                    ////偶数
                    if (residLis == 0)
                    {
                        data[i].lisMidTime = (Convert.ToDecimal(lisDrr[remaindLis]["listime"]) + Convert.ToDecimal(lisDrr[remaindLis - 1]["listime"])) / 2;
                    }
                    else
                    {
                        data[i].lisMidTime = Convert.ToDecimal(lisDrr[remaindLis]["listime"]);
                    }
                }
            }
                
            m_objViewer.dgvdata.DataSource = data;
            clsPublic.CloseAvi();
        }

        #endregion

        #region  检验标本周转中位数汇总
        /// <summary>
        /// 
        /// </summary>
        public void m_mthGeSampleStatSpecStat()
        {
            DataTable dtbResult;
            if (string.IsNullOrEmpty(m_objViewer.cbxGroup.Text) && m_objViewer.dgvCheckItem.Rows.Count < 2)
            {
                MessageBox.Show("请选择专业组或检验项目 ！");
                return;
            }

            List<EntitySamepleStat> data = new List<EntitySamepleStat>();
            string groupId = string.Empty;
            string enmergencyFlg = string.Empty;
            string patType = string.Empty;
            string dteStart = m_objViewer.dteStart.Text;
            string dteEnd = m_objViewer.dteEnd.Text;
            string applyUnitId = string.Empty;

            if (m_objViewer.dgvCheckItem.Rows.Count >= 2)
            {
                //applyUnitId = m_objViewer.dgvCheckItem.Rows[0].Cells[0].Value.ToString();

                for (int i = 0; i < m_objViewer.dgvCheckItem.Rows.Count - 1; i++)
                {
                    applyUnitId += "'" + m_objViewer.dgvCheckItem.Rows[i].Cells[0].Value.ToString() + "',";
                }

                applyUnitId = "(" + applyUnitId.TrimEnd(',') + ")";
            }

            string strDept = m_objViewer.DeptIdArr;
            if (m_objViewer.cboEmergency.Text.Trim() == "急诊项目")
                enmergencyFlg = "1";
            else if (m_objViewer.cboEmergency.Text.Trim() == "非急诊项目")
                enmergencyFlg = "0";

            if (m_objViewer.cboPatType.Text.Trim() == "住院")
                patType = "1";
            else if (m_objViewer.cboPatType.Text.Trim() == "门诊")
                patType = "2";

            if (m_objViewer.DeptIdArr == "'0000001'")
                strDept = string.Empty;

            foreach (var item in dicGroup)
            {
                if (item.Value == m_objViewer.cbxGroup.Text)
                    groupId = item.Key;
            }

            if (m_objViewer.dgvCheckItem.Rows.Count >= 2)
                groupId = "";

            clsPublic.PlayAvi("findFILE.avi", "正在查询项目信息，请稍候...");

            long lngRes = m_objManage.lngGetSampleMedSpec(out dtbResult, dteStart, dteEnd, groupId, applyUnitId, strDept, enmergencyFlg, patType);

            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                //m_objViewer.dgvStat.DataSource = dtbResult;
                foreach (DataRow dr in dtbResult.Rows)
                {
                    EntitySamepleStat vo = new EntitySamepleStat();

                    vo.HZXM = dr["HZXM"].ToString();
                    vo.DEPTNAME = dr["DEPTNAME"].ToString();
                    vo.BARCODE = dr["BARCODE"].ToString();
                    vo.CARDNO = dr["CARDNO"].ToString();
                    vo.patInNo = dr["patInNo"].ToString();
                    if (dr["preTime"] != DBNull.Value)
                        vo.preTime = Convert.ToDecimal(dr["preTime"]) > 0 ? Convert.ToDecimal(dr["preTime"]) : 0;
                    if (dr["lisTime"] != DBNull.Value)
                        vo.lisTime = Convert.ToDecimal(dr["lisTime"]) > 0 ? Convert.ToDecimal(dr["lisTime"]) : 0;

                    data.Add(vo);
                }

                m_objViewer.dgvStat.DataSource = data;
            }
            else
            {
                MessageBox.Show("没有相关数据。");
                return;
            }

            clsPublic.CloseAvi();
        }

        #endregion

        #region
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

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream = saveFileDialog.OpenFile();
                StreamWriter streamWriter = new StreamWriter(stream, Encoding.GetEncoding("gb2312"));
                string text = "";
                
                try
                {
                    for (int i = 0; i < this.m_objViewer.dgvdata.ColumnCount/2; i++)
                    {
                        if (this.m_objViewer.dgvdata.Columns[i].Visible)
                        {
                            if (i > 0)
                            {
                                text += "\t";
                            }
                        }
                    }
                    text += "检验标本周转中位数统计表";
                    streamWriter.WriteLine(text);
                    text = dteStart + "~" + dteEnd + "              检验项目：" + m_objViewer.dgvCheckItem.Rows[0].Cells[1].Value.ToString();
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
                    MessageBox.Show("导出成功！", "检验标本周转中位数统计表", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
    }
}
