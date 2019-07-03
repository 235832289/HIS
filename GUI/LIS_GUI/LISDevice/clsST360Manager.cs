using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;
using ExpressionEvaluation;

namespace com.digitalwave.iCare.gui.LIS
{

    #region ST360的管理类

    /// <summary>
    /// ST360的管理类
    /// </summary>
    internal class clsST360Manager
    {

        #region 构造函数

        public clsST360Manager()
        {
            Init();
        }

        #endregion

        #region 私有成员

        private List<clsSTBoardItem> m_lstBoardItems = new List<clsSTBoardItem>();
        private clsSTConstract m_constract;
        private clsSTCheckProject m_checkProject;

        private bool m_isSelfConstractValue=false;
        public event EventHandler<DataChangedEventArgs> DataChanged;
        public const int BOARDCOUNT = 96;

        #endregion

        #region 属 性

        /// <summary>
        /// 查  询
        /// </summary>
        public List<clsSTBoardItem> Data
        {
            get { return m_lstBoardItems; }
            set
            {
                m_lstBoardItems = value;
                if (DataChanged != null)
                {
                    DataChanged(this, new DataChangedEventArgs(enmSTTextBoxShowStatus.None));
                }
            }
        }

        /// <summary>
        /// 数据是否为Null或者为空
        /// </summary>
        public bool IsDataNullOrEmpty
        {
            get
            {
                return this.m_lstBoardItems == null || this.m_lstBoardItems.Count == 0;
            }
        }

        /// <summary>
        /// 检验项目
        /// </summary>
        public clsSTCheckProject CheckProject
        {
            get { return m_checkProject; }
            set { m_checkProject = value; }
        }

        /// <summary>
        /// 对照值
        /// </summary>
        public clsSTConstract ConstractValue
        {
            get { return m_constract; }
            set { m_constract = value; }
        }

        /// <summary>
        /// 是否用户自定义的对照值
        /// </summary>
        public bool IsSelfConstractValue
        {
            set { m_isSelfConstractValue = value; }
            get { return m_isSelfConstractValue; }
        }


        #endregion

        #region 相关操作

        /// <summary>
        /// 保存模板
        /// </summary>
        public void SaveTemplate(out string message)
        {
            message = string.Empty;
            frmAddTemplate addTemplate = new frmAddTemplate();
            if (addTemplate.ShowDialog() == DialogResult.Yes)
            {
                string templateName = addTemplate.TemplateName;

                message = string.Empty;
                clsConfigAssist config = new clsConfigAssist();
                config.AddTemplate(templateName, this.m_lstBoardItems, out message);
            }
        }

        /// <summary>
        /// 清除数据
        /// </summary>
        public void ClearData()
        {
            foreach (clsSTBoardItem item in m_lstBoardItems)
            {
                item.DataNum = string.Empty;
            }

            if (DataChanged != null)
            {
                DataChanged(this, new DataChangedEventArgs(enmSTTextBoxShowStatus.BoardStyle));
            }
        }

        /// <summary>
        /// 清除模板
        /// </summary>
        public void ClearTemplate()
        {
            foreach (clsSTBoardItem item in m_lstBoardItems)
            {
                item.BoardStyle.SampleStyle = enmSTSampleStyle.NONE;
                item.BoardStyle.SampleStyleNo = 0;
            }

            if (DataChanged != null)
            {
                DataChanged(this, new DataChangedEventArgs(enmSTTextBoxShowStatus.ResultNum));
            }
        }

        /// <summary>
        /// 查看历史记录（根据微孔板编号）
        /// </summary>
        /// <param name="boardNo"></param>
        public void ReadHistory(string boardNo)
        {
            Init();

            clsST360CheckResultVO[] arrCheckResult = null;
            clsST360CheckResultSmp.s_object.m_lngFind(boardNo, out arrCheckResult);


            foreach (clsST360CheckResultVO checkResult in arrCheckResult)
            {
                foreach (clsSTBoardItem boardItem in m_lstBoardItems)
                {
                    if (checkResult.m_intSampleId == boardItem.Sequence)
                    {
                        boardItem.DataNum = checkResult.m_strResultNum;
                        boardItem.BoardStyle.SampleStyle = checkResult.m_enmSampelType;
                        boardItem.BoardStyle.SampleStyleNo = checkResult.m_intTemplateNo;
                        boardItem.IsPositive = checkResult.m_IsPositive;
                    }
                }
            }

            if (this.DataChanged != null)
            {
                DataChanged(this, new DataChangedEventArgs(enmSTTextBoxShowStatus.ResultNum));
            }
        }

        /// <summary>
        /// 读 板
        /// </summary>
        /// <returns></returns>
        public string ReadBoard()
        {
            string message = string.Empty;

            List<clsDeviceReslutVO> lstCheckResults = null;
            clsST360Smp.s_object.m_lngFindSTGroupResult(out lstCheckResults);

            if (lstCheckResults == null || lstCheckResults.Count == 0)
            {
                return "没有酶标检验项目结果！";
            }

            foreach (clsSTBoardItem boardItem in m_lstBoardItems)
            {
                foreach (clsDeviceReslutVO resultVO in lstCheckResults)
                {
                    if (boardItem.Sequence.ToString()==resultVO.m_strDeviceSampleID)
                    {
                        boardItem.DataNum = resultVO.m_strResult;
                    }
                }
            }

            if (DataChanged != null)
            {
                DataChanged(this, new DataChangedEventArgs(enmSTTextBoxShowStatus.ResultNum));
            }
            return string.Empty;
        }

        /// <summary>
        /// 模板改变
        /// </summary>
        /// <param name="template"></param>
        public void ChangedTemplate(clsBoardTemplate template)
        {
            foreach (clsSTBoardItem boardItem in m_lstBoardItems)
            {
                bool isChanged = false;
                foreach (clsSTBoardItem tempItem in template.BoardItems)
                {
                    if (boardItem.Sequence==tempItem.Sequence)
                    {
                        boardItem.BoardStyle = tempItem.BoardStyle;
                        isChanged = true;
                    }
                }

                if (!isChanged)
                {
                    boardItem.BoardStyle.SampleStyle = enmSTSampleStyle.NONE;
                    boardItem.BoardStyle.SampleStyleNo = 0;
                }
            }

            if (this.DataChanged!=null)
            {
                DataChanged(this,new DataChangedEventArgs(enmSTTextBoxShowStatus.BoardStyle));
            }
        }

        /// <summary>
        /// 获取N,P对照值
        /// </summary>
        public void AnalysisData(out string message)
        {
            message = string.Empty;
            clsSTConstract constractRule = new clsSTConstract();

            if (m_isSelfConstractValue)
            {
                constractRule = this.m_constract;
            }
            else 
            {
                constractRule.Analysis(m_lstBoardItems);
                this.m_constract = constractRule;
            }

            string formula = this.m_checkProject.Formula;

            formula = formula.Replace("N", constractRule.NegativeValue.ToString());
            formula = formula.Replace("P", constractRule.PositiveValue.ToString());
            formula = formula.Replace("B", constractRule.BlankValue.ToString());

            ExpressionEval eval = new ExpressionEval();

            foreach (clsSTBoardItem boardItem in m_lstBoardItems)
            {
                if (boardItem.BoardStyle.SampleStyle==enmSTSampleStyle.NONE)
                {
                    continue;
                }

                string evalExpression = formula.Replace("V", boardItem.DataNum);
                eval.Expression = evalExpression;
                bool result=false;
                try
                {
                    result = eval.EvaluateBool();
                }
                catch (Exception ex)
                {
                    message = "公式配置不对或者数据不正确！ 系统消息："+ex.Message;
                    return;
                }

                boardItem.IsPositive = result;
            }

            if (DataChanged!=null)
            {
                DataChanged(this,new DataChangedEventArgs(enmSTTextBoxShowStatus.ResultText));
            }
           
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            m_lstBoardItems.Clear();
            for (int i = 0; i < BOARDCOUNT; i++)
            {
                clsSTBoardItem boardItem = new clsSTBoardItem();
                boardItem.Sequence = i + 1;
                m_lstBoardItems.Add(boardItem);
            }
        } 
        #endregion

    }

    #endregion

    #region 数据改变事件的数据类

    /// <summary>
    /// 数据改变事件的数据类
    /// </summary>
    internal class DataChangedEventArgs : System.EventArgs
    {
        public DataChangedEventArgs(enmSTTextBoxShowStatus showStatus)
        {
            this.showStatus = showStatus;
        }
        private enmSTTextBoxShowStatus showStatus;

        public enmSTTextBoxShowStatus ShowStatus
        {
            get { return showStatus; }
        }
    }
    #endregion
}
