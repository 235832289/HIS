using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 公共方法类

    /// </summary>
    public class clsPublic
    {
        /// <summary>
        /// PB报表库文件路径

        /// </summary>
        public static string PBLPath = Application.StartupPath + "\\pb_ms.pbl";

        #region 获取服务器当前时间

        /// <summary>
        /// 获取数据库服务器当前时间
        /// </summary>
        public static DateTime SysDateTimeNow
        {
            get
            {
                DateTime m_dtmDateTime = DateTime.Now;
                com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.m_lngGetSysDateTimeNow(out m_dtmDateTime);
                return m_dtmDateTime;
            }
        }
        #endregion

        /// <summary>
        /// 获取中间件服务器当前时间
        /// </summary>
        public static DateTime CurrentDateTimeNow
        {
            get
            {
                DateTime m_dtmDateTime = DateTime.Now;
                com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.m_lngGetCurrentDateTime(out m_dtmDateTime);
                return m_dtmDateTime;
            }
        }

        /// <summary>
        /// 获取库房名称
        /// </summary>
        /// <param name="p_blnForDrugStore">是否药房</param>
        /// <param name="p_strStorageID">库房ID</param>
        /// <param name="p_strStroageName">库房名称</param>
        /// <returns></returns>
        public static long m_lngGetStorageName(bool p_blnForDrugStore, string p_strStorageID, out string p_strStroageName)
        {
            com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public objPub = new com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public();
            return objPub.m_lngGetStorageName(p_blnForDrugStore, p_strStorageID, out p_strStroageName);
        }

        /// <summary>
        /// 把null转换成""
        /// </summary>
        /// <param name="strValues"></param>
        /// <param name="IsZero"></param>
        /// <returns></returns>
        public static string IsNullToString(string strValues, string IsZero)
        {
            if (strValues == null)
            {
                if (IsZero != null)
                    return IsZero;
                else
                    return "";
            }
            else
            {
                strValues = strValues.Replace(" ", "").Replace("'", "");
                if (strValues != "")
                    return strValues;
                else
                {
                    if (IsZero != null)
                        return IsZero;
                    else
                        return strValues;
                }
            }
        }
    }
    public class ComboBoxItem
    {
        public ArrayList sText;
        public ArrayList sValue;
        private exComboBox objCombo;
        public ComboBoxItem(exComboBox source)
        {
            this.objCombo = source;
            sText = new ArrayList();
            sValue = new ArrayList();
        }
        public void Add(string Text, string Value)
        {
            //this.sText=Text;
            this.objCombo.Items.Add(Text);
            //this.Value=Value;
            sText.Add(Text);
            sValue.Add(Value);
            //this.Add(Text);
        }
        public string this[int index]
        {
            get
            {
                string tmpText;
                if (index > -1 && sText.Count > 0)
                    tmpText = sText[index].ToString();
                else
                    tmpText = "";
                return tmpText;
            }
        }
    }
    public class exComboBox : ComboBox
    {
        public ComboBoxItem Item;

        public exComboBox()
        {
            Item = new ComboBoxItem(this);
        }
        public void m_mthClear()
        {
            Item.sText.Clear();
            Item.sValue.Clear();
        }
        /// <summary>
        /// 当前选择的值
        /// </summary>
        public string SelectItemValue
        {
            get
            {
                string tmp = "";
                if (Item.sValue.Count == 0)
                    return tmp;
                if (SelectedIndex > -1)
                    tmp = Item.sValue[SelectedIndex].ToString();
                else
                    tmp = "";
                return tmp;
            }
        }
        /// <summary>
        /// 当前显示的值
        /// </summary>
        public string SelectItemText
        {
            get
            {
                string tmp = "";
                if (Item.sText.Count == 0)
                    return tmp;
                if (SelectedIndex > -1)
                    tmp = Item.sText[SelectedIndex].ToString();
                else
                    tmp = "";
                return tmp;
            }
        }
        public void Clear()
        {
            this.SelectedIndex = -1;
            this.Text = "";
        }
        /// <summary>
        /// 查找保存的值
        /// </summary>
        /// <param name="Key"></param>
        public void FindKey(string Key)
        {
            //			this.Clear();
            if (clsPublic.IsNullToString(Key, null) == "")
            {
                this.SelectedIndex = -1;
                return;
            }
            if (Item.sValue.Count == 0)
                return;
            bool b_temp = false;
            for (int i1 = 0; i1 < this.Items.Count; i1++)
            {
                if (Item.sValue[i1].ToString() == Key)
                {
                    b_temp = true;
                    if (this.SelectedIndex != i1)
                    {
                        this.SelectedIndex = i1;

                    }
                    return;
                }
            }
            if (!b_temp)
            {
                this.SelectedIndex = -1;
            }
        }
    }
}