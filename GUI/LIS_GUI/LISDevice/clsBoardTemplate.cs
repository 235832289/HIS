using System;
using System.Collections.Generic;
using System.Text;

namespace com.digitalwave.iCare.gui.LIS
{
    #region 酶标仪模板类
    /// <summary>
    /// 酶标仪模板类
    /// </summary>
    internal class clsBoardTemplate
    {
        private string m_strTemplateName;
        private List<clsSTBoardItem> m_lstBoardItems = new List<clsSTBoardItem>();
        public clsBoardTemplate(string templateName, List<clsSTBoardItem> lstBoardItems)
        {
            this.m_strTemplateName = templateName;
            this.m_lstBoardItems = lstBoardItems;
        }

        /// <summary>
        /// 获取或设置模板名称
        /// </summary>
        public string TemplateName
        {
            get { return m_strTemplateName; }
            set { m_strTemplateName = value; }
        }

        /// <summary>
        /// 设置或获取微孔列表
        /// </summary>
        public List<clsSTBoardItem> BoardItems
        {
            get { return m_lstBoardItems; }
            set { m_lstBoardItems = value; }
        }

        public override string ToString()
        {
            return m_strTemplateName;
        }
    }
    #endregion
}
