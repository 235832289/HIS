using System;
using System.Collections.Generic;
using System.Text;
using Sybase.DataWindow;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsCtl_PmpctStat : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 构造函数
        public clsCtl_PmpctStat()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_objManage = new clsDcl_PmpctStat();
        }
        #endregion

        /// <summary>
        /// 类变量
        /// </summary>
        private frmPmpctStat m_objViewer;
        internal bool IsEnglish = false;
        private clsDcl_PmpctStat m_objManage;
        Dictionary<string, string> dicGroup;

        #region Entity
        /// <summary>
        /// 实体
        /// </summary>
        public class EntityPmpctDetail
        {
            public string RQ { get; set; }
            public string XM { get; set; }
            public string XB { get; set; }
            public string KS { get; set; }
            public string MZZYH { get; set; }
            public string XMMC { get; set; }
            public string XMJG { get; set; }
            public string SQYS { get; set; }
            public string JYZ { get; set; }
        }

        public class EntityPmpctStat
        {
            public string YF { get; set; }
            public decimal HIVYXS { get; set; }
            public decimal MDYXS { get; set; }
            public decimal YGYXZY { get; set; }
            public decimal YGYXMZ { get; set; }
            public decimal MDDXYX { get; set; }
        }

        public class EntityPmpctItem
        {
            public string YF { get; set; }
            public string ApplicationId { get; set; }
            public string patType { get; set; }
            public string HIVYX { get; set; }
            public string MDYX { get; set; }
            public string YGYXZY { get; set; }
            public string YGYXMZ { get; set; }
            public string MDDXMYX { get; set; }
        }

        public class EntityResult
        {
            public string YF { get; set; }
            public string ApplicationId { get; set; }
            public string patType { get; set; }
            public string TPPA { get; set; }
            public string TRUST { get; set; }
            public string RPR { get; set; }
            public string HIV { get; set; }
            public string YGYXZY { get; set; }
            public string YGYXMZ { get; set; }
        }

        public class EntityYfrc
        {
            public string YF { get; set; }
            public decimal ZYRC { get; set; }
            public decimal MZRC { get; set; }
            public decimal HJRC { get; set; }
            public decimal HIVYXS { get; set; }
            public decimal MDYXS { get; set; }
            public decimal YGYXZY { get; set; }
            public decimal YGYXMZ { get; set; }
            public decimal MDDXYX { get; set; }
        }
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            m_objViewer = (frmPmpctStat)frmMDI_Child_Base_in;
        }
        #endregion

        #region init
        /// <summary>
        /// init
        /// </summary>
        public void m_mthInit()
        {
            dicGroup = new Dictionary<string, string>();
            m_objViewer.dgvData.Visible = true;
            m_objViewer.dteStart.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01");
            m_objViewer.cboStatType.Items.AddRange(new object[] { "免费母婴阻断检测工作情况记录表", "免费母婴阻断阳性结果明细表" });
            m_objViewer.cboStatType.SelectedIndex = 0;
            m_objViewer.cboPatType.Items.AddRange(new object[] { "住院","门诊"  });
        }
        #endregion

        #region  免费母婴阻断检测工作情况记录
        /// <summary>
        /// 
        /// </summary>
        public void m_mthGetPmpctStat()
        {
            DataTable dtbResult;

            List<EntityPmpctStat> data = new List<EntityPmpctStat>();
            List<EntityPmpctItem> dataItem = new List<EntityPmpctItem>();
            List<EntityResult> dataResult = new List<EntityResult>();
            List<EntityYfrc> dataYfrc = new List<EntityYfrc>();

            string dteStart = m_objViewer.dteStart.Text;
            string dteEnd = m_objViewer.dteEnd.Text;
            string month = string.Empty;
            string applicationId = string.Empty;
            string patType = string.Empty;
            int resultFlg = 0;
            int itemFlg = 0;
            int yfrcFlg = 0;
            //clsPublic.PlayAvi();
            patType = m_objViewer.cboPatType.SelectedIndex.ToString() ;

            long lngRes = m_objManage.lngGetPmpcStat(dteStart, dteEnd,patType, out dtbResult);

            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                foreach (DataRow dr in dtbResult.Rows)
                {
                    month = Convert.ToDateTime(dr["modify_dat"]).ToString("yyyy-MM");
                    applicationId = dr["application_id_chr"].ToString();
                    patType = dr["patient_type_chr"].ToString();
                    resultFlg = 0;

                    for (int i = 0; i < dataResult.Count; i++)
                    {
                        if (applicationId == dataResult[i].ApplicationId)
                        {
                            EntityResult voClone = dataResult[i];
                            voClone.YF = month;
                            voClone.ApplicationId = applicationId;
                            voClone.patType = patType;
                            if (dr["check_item_id_chr"].ToString() == "000199")
                                voClone.HIV = dr["result_vchr"].ToString();
                            else if (dr["check_item_id_chr"].ToString() == "001448")
                                voClone.TRUST = dr["result_vchr"].ToString();
                            else if (dr["check_item_id_chr"].ToString() == "000196")
                                voClone.TPPA = dr["result_vchr"].ToString();
                            else if (dr["check_item_id_chr"].ToString() == "000195")
                                voClone.RPR = dr["result_vchr"].ToString();
                            else if (dr["check_item_id_chr"].ToString() == "000194" && patType == "1")
                                voClone.YGYXZY = dr["result_vchr"].ToString();
                            else if (dr["check_item_id_chr"].ToString() == "000194" && patType == "2")
                                voClone.YGYXMZ = dr["result_vchr"].ToString();
                            resultFlg = 1;
                        }
                    }

                    if (resultFlg == 0)
                    {
                        EntityResult vo = new EntityResult();
                        vo.YF = month;
                        vo.ApplicationId = applicationId;
                        vo.patType = patType;
                        if (dr["check_item_id_chr"].ToString() == "000199")
                            vo.HIV = dr["result_vchr"].ToString();
                        else if (dr["check_item_id_chr"].ToString() == "001448")
                            vo.TRUST = dr["result_vchr"].ToString();
                        else if (dr["check_item_id_chr"].ToString() == "000196" || dr["check_item_id_chr"].ToString() == "001069")
                            vo.TPPA = dr["result_vchr"].ToString();
                        else if (dr["check_item_id_chr"].ToString() == "000195")
                            vo.RPR = dr["result_vchr"].ToString();
                        else if (dr["check_item_id_chr"].ToString() == "000194" && patType == "1")
                            vo.YGYXZY = dr["result_vchr"].ToString();
                        else if (dr["check_item_id_chr"].ToString() == "000194" && patType == "2")
                            vo.YGYXMZ = dr["result_vchr"].ToString();
                        dataResult.Add(vo);
                    }
                }

                //DataView dataView = dtbResult.DefaultView;
                //DataTable dataTableDistinct = dataView.ToTable(true, "patientid_chr", "patient_type_chr");

                for (int j = 0; j < dataResult.Count; j++)
                {
                    EntityResult voResult = dataResult[j];

                    EntityPmpctItem vo = new EntityPmpctItem();
                    vo.YF = voResult.YF;
                    vo.ApplicationId = voResult.ApplicationId;
                    vo.patType = voResult.patType;
                    yfrcFlg = 0;

                    #region  计算月份人次
                    for (int yfI = 0; yfI < dataYfrc.Count; yfI++)
                    {
                        if (voResult.YF == dataYfrc[yfI].YF)
                        {
                            if (voResult.patType == "1")
                                dataYfrc[yfI].ZYRC++;
                            if (voResult.patType == "2")
                                dataYfrc[yfI].MZRC++;
                            dataYfrc[yfI].HJRC++;
                            yfrcFlg = 1;
                        }
                    }

                    if (yfrcFlg == 0)
                    {
                        EntityYfrc voYfrc = new EntityYfrc();
                        if (voResult.patType == "1")
                            voYfrc.ZYRC = 1;
                        if (voResult.patType == "2")
                            voYfrc.MZRC = 1;
                        voYfrc.HJRC = 1;
                        voYfrc.YF = vo.YF;
                        dataYfrc.Add(voYfrc);
                    }
                    #endregion

                    #region  计算阳性个数
                    if (string.IsNullOrEmpty(voResult.TPPA))
                        voResult.TPPA = "";
                    if (string.IsNullOrEmpty(voResult.RPR))
                        voResult.RPR = "";
                    if (string.IsNullOrEmpty(voResult.TRUST))
                        voResult.TRUST = "";
                    if (string.IsNullOrEmpty(voResult.HIV))
                        voResult.HIV = "";
                    if (string.IsNullOrEmpty(voResult.YGYXMZ))
                        voResult.YGYXMZ = "";
                    if (string.IsNullOrEmpty(voResult.YGYXZY))
                        voResult.YGYXZY = "";

                    if (voResult.TPPA.Contains("阳") && voResult.RPR.Contains("阳"))
                    {
                        vo.MDYX = "阳";
                    }
                    else if (voResult.TRUST.Contains("阳") && voResult.RPR.Contains("阳"))
                    {
                        vo.MDYX = "阳";
                    }
                    else if (voResult.TPPA.Contains("阳") || voResult.TRUST.Contains("阳") || voResult.RPR.Contains("阳"))
                    {
                        vo.MDDXMYX = "阳";
                    }

                    if (voResult.HIV.Contains("阳"))
                    {
                        vo.HIVYX = "阳";
                    }

                    if (voResult.YGYXZY.Contains("阳"))
                    {
                        vo.YGYXZY = "阳";
                    }

                    if (voResult.YGYXMZ.Contains("阳"))
                    {
                        vo.YGYXMZ = "阳";
                    }

                    if (string.IsNullOrEmpty(vo.MDYX) && string.IsNullOrEmpty(vo.MDDXMYX) && string.IsNullOrEmpty(vo.HIVYX) && string.IsNullOrEmpty(vo.YGYXMZ) && string.IsNullOrEmpty(vo.YGYXZY))
                        continue;
                    #endregion

                    dataItem.Add(vo);
                }

                for (int k = 0; k < dataItem.Count; k++)
                {
                    EntityPmpctItem vo = dataItem[k];
                    itemFlg = 0;

                    for (int dataI = 0; dataI < data.Count; dataI++)
                    {
                        if (vo.YF == data[dataI].YF)
                        {
                            if (vo.HIVYX == "阳")
                                data[dataI].HIVYXS++;
                            if (vo.MDYX == "阳")
                                data[dataI].MDYXS++;
                            if (vo.MDDXMYX == "阳")
                                data[dataI].MDDXYX++;
                            if (vo.YGYXMZ == "阳")
                                data[dataI].YGYXMZ++;
                            if (vo.YGYXZY == "阳")
                                data[dataI].YGYXZY++;
                            itemFlg = 1;
                        }
                    }
                    if (itemFlg == 0)
                    {
                        EntityPmpctStat voStat = new EntityPmpctStat();
                        if (vo.HIVYX == "阳")
                            voStat.HIVYXS = 1;
                        if (vo.MDYX == "阳")
                            voStat.MDYXS = 1;
                        if (vo.MDDXMYX == "阳")
                            voStat.MDDXYX = 1;
                        if (vo.YGYXZY == "阳")
                            voStat.YGYXZY = 1;
                        if (vo.YGYXMZ == "阳")
                            voStat.YGYXMZ = 1;

                        voStat.YF = vo.YF;
                        data.Add(voStat);
                    }
                }


                for (int dataI = 0; dataI < data.Count; dataI++)
                {
                    for (int yfrcI = 0; yfrcI < dataYfrc.Count; yfrcI++)
                    {
                        if (dataYfrc[yfrcI].YF == data[dataI].YF)
                        {
                            dataYfrc[yfrcI].HIVYXS = data[dataI].HIVYXS;
                            dataYfrc[yfrcI].MDYXS = data[dataI].MDYXS;
                            dataYfrc[yfrcI].YGYXZY = data[dataI].YGYXZY;
                            dataYfrc[yfrcI].YGYXMZ = data[dataI].YGYXMZ;
                            dataYfrc[yfrcI].MDDXYX = data[dataI].MDDXYX;
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("没有相关数据。");
            }

            m_objViewer.dgvData.DataSource = dataYfrc;
        }

        #endregion

        #region  免费母婴阻断阳性结果汇总
        /// <summary>
        /// 
        /// </summary>
        public void m_mthGetPmpctDetail()
        {
            DataTable dtbResult;

            List<EntityPmpctDetail> data = new List<EntityPmpctDetail>();
            string groupId = string.Empty;
            string dteStart = m_objViewer.dteStart.Text;
            string dteEnd = m_objViewer.dteEnd.Text;
            string patType = m_objViewer.cboPatType.SelectedIndex.ToString();
            long lngRes = m_objManage.lngGetPmpcDetail(dteStart, dteEnd, patType,  out dtbResult);

            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                foreach (DataRow dr in dtbResult.Rows)
                {
                    EntityPmpctDetail vo = new EntityPmpctDetail();

                    vo.RQ = dr["RQ"].ToString();
                    vo.XM = dr["XM"].ToString();
                    vo.XB = dr["XB"].ToString().Trim();
                    vo.KS = dr["KS"].ToString();
                    patType = dr["patient_type_chr"].ToString();
                    if (patType == "1")
                        vo.MZZYH = dr["ZYH"].ToString().Trim();
                    else
                        vo.MZZYH = dr["MZH"].ToString();

                    vo.XMMC = dr["XMMC"].ToString();
                    vo.XMJG = dr["XMJG"].ToString();
                    if (!vo.XMJG.Contains("阳"))
                        continue;
                    vo.SQYS = dr["SQYS"].ToString();
                    vo.JYZ = dr["JYZ"].ToString();

                    data.Add(vo);
                }
            }
            else
            {
                MessageBox.Show("没有相关数据。");
            }

            m_objViewer.dgvDetail.DataSource = data;
        }

        #endregion

        #region 导出EXCEL
        /// <summary>
        /// 
        /// </summary>
        /// <param name="statType"></param>
        public void m_mthExportToExcel(int statType,DataGridView dgvData)
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
                    for (int i = 0; i < dgvData.ColumnCount / 2; i++)
                    {
                        if (dgvData.Columns[i].Visible)
                        {
                            if (i > 0)
                            {
                                text += "\t";
                            }
                        }
                    }
 
                    if (statType == 0)
                    {
                        text += "免费母婴阻断检测工作情况记录表";
                    }
                    if (statType == 1)
                    {
                        text += "免费母婴阻断阳性结果明细表";
                    }

                    streamWriter.WriteLine(text);
                    text = dteStart + "~" + dteEnd;
                    streamWriter.WriteLine(text);
                    text = "";

                    for (int i = 0; i < dgvData.ColumnCount; i++)
                    {
                        if (dgvData.Columns[i].Visible)
                        {
                            if (i > 0)
                            {
                                text += "\t";
                            }
                            text += dgvData.Columns[i].HeaderText.Replace("\n", "");
                        }
                    }
                    streamWriter.WriteLine(text);
                    for (int i = 0; i < dgvData.Rows.Count; i++)
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        for (int j = 0; j < dgvData.Columns.Count; j++)
                        {
                            if (dgvData.Columns[j].Visible)
                            {
                                if (j > 0)
                                {
                                    stringBuilder.Append("\t");
                                }
                                stringBuilder.Append((dgvData.Rows[i].Cells[j].Value == null) ? "" : dgvData.Rows[i].Cells[j].Value.ToString());
                            }
                        }
                        streamWriter.WriteLine(stringBuilder);
                    }
                    MessageBox.Show("导出成功！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
    }
}
