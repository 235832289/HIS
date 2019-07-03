using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmYBDefPayType : Form
    {
        public frmYBDefPayType()
        {
            InitializeComponent();
        }

        bool m_blnNewYBDefPayTypes = false;

        #region 一般设置


        #region 快捷键设置


        private void m_mthShortCutKey(Keys p_eumKeyCode)
        {
            //if (m_tabControl.SelectedIndex == 2)
            //{
            //    if (p_eumKeyCode == Keys.F4)
            //    {
            //        m_cmdCDelete_Click(this.m_cmdCMDelete, EventArgs.Empty);
            //    }
            //}
        }

        #endregion

        #endregion

        #region 加载列表

        //加载数据和填充列表
        private void m_mthLoadYBDefPayTypes()
        {
            Cursor.Current = Cursors.WaitCursor;

            //加载数据
            clsYBDefPayTypeVO[] arrYBDefPayTypes = null;
            clsDcl_YBDefPayTypeSmp.s_object.m_lngFindAll(out arrYBDefPayTypes);
            if (arrYBDefPayTypes == null)
            {
                arrYBDefPayTypes = new clsYBDefPayTypeVO[0];
            }
            m_lsvYBPayTypes.Tag = arrYBDefPayTypes;

            //填充列表
            m_mthShowYBDefPayTypesList(arrYBDefPayTypes);

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// 加载患者身份类型
        /// </summary>
        private void m_mthLoadYBTypeList()
        {
            clsPatientType_VO[] arrPatientPayTypes = null;
            clsDcl_PatientPayTypeSmp.s_object.m_lngGetYBPatientPayType(out arrPatientPayTypes);
            if (arrPatientPayTypes == null)
            {
                arrPatientPayTypes = new clsPatientType_VO[0];
            }

            m_cboTypeName.Items.Clear();
            foreach (clsPatientType_VO payTypeVO in arrPatientPayTypes)
            {
                this.m_cboTypeName.Items.Add(payTypeVO);
            }
            m_cboTypeName.Tag = arrPatientPayTypes;
        }

        //填充列表
        private void m_mthShowYBDefPayTypesList(clsYBDefPayTypeVO[] arrYBDefPayTypes)
        {
            this.m_lsvYBPayTypes.BeginUpdate();//开始更新列表

            this.m_lsvYBPayTypes.Items.Clear();
            if (arrYBDefPayTypes != null)
            {

                this.m_lsvYBPayTypes.Items.Clear();
                foreach (clsYBDefPayTypeVO ybType in arrYBDefPayTypes)
                {
                    ListViewItem item = new ListViewItem(ybType.m_strPayTypeId);
                    item.SubItems.Add(ybType.m_strPayTypeName);
                    item.SubItems.Add(ybType.m_strYBJslxName());
                    item.SubItems.Add(ybType.m_strYBRylbName());
                    item.Tag = ybType;

                    this.m_lsvYBPayTypes.Items.Add(item);
                }
            }
            //重置状态标志

            this.m_blnNewYBDefPayTypes = false;
            //清空明细
            m_mthDetailClear();

            this.m_lsvYBPayTypes.EndUpdate();//结束更新列表
        }


        

        private void SelectedTypeNameIndex(string payTypeId)
        {
            foreach (object obj in m_cboTypeName.Items)
            {
                clsPatientType_VO payTypeVO = obj as clsPatientType_VO;
                if (payTypeVO != null && payTypeVO.m_strPayTypeID == payTypeId)
                {
                    m_cboTypeName.SelectedItem = obj;
                    break;
                }
            }
        }
        
        #endregion

        #region 事件实现

        //列表选定项变更
        private void m_lsvYBPayTypes_Click(object sender, EventArgs e)
        {
            if (this.m_lsvYBPayTypes.FocusedItem == null)
                return;
            //变更状态标志

            this.m_blnNewYBDefPayTypes = false;
            this.m_txtTypeId.Enabled = false;
            this.m_cboTypeName.Enabled = false;

            clsYBDefPayTypeVO objPayTypeVO = (clsYBDefPayTypeVO)this.m_lsvYBPayTypes.FocusedItem.Tag;

            this.m_txtTypeId.Text = objPayTypeVO.m_strPayTypeId;
            SelectedTypeNameIndex(objPayTypeVO.m_strPayTypeId);
            this.m_cboYBJslxName.SelectedIndex = GetJslxIndex(objPayTypeVO.m_strYBJslx);
            this.m_cboYBRylxName.SelectedIndex = GetRylxIndex(objPayTypeVO.m_strYBRylb);
        }

        //新增
        private void m_cmdNew_Click(object sender, EventArgs e)
        {
            //使当前ListView具有焦点的行失去焦点
            if (this.m_lsvYBPayTypes.FocusedItem != null)
            {
                this.m_lsvYBPayTypes.FocusedItem.Selected = false;
                this.m_lsvYBPayTypes.FocusedItem.Focused = false;
                this.m_txtTypeId.Enabled = false;
            }

            this.m_cboTypeName.Enabled = true;

            //清空明细
            m_mthDetailClear();

            //设置光标焦点
            this.m_cboTypeName.Focus();

            this.m_cmdSave.Enabled = true;

            //设置新增标志
            this.m_blnNewYBDefPayTypes = true;
        }

        //清空明细
        private void m_mthDetailClear()
        {
            this.m_txtTypeId.Text = string.Empty;
            this.m_cboTypeName.SelectedIndex = 0;
            this.m_cboYBJslxName.SelectedIndex = 0;
            this.m_cboYBRylxName.SelectedIndex = 0;
        }

        //保存
        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            if (m_lsvYBPayTypes.FocusedItem == null && !this.m_blnNewYBDefPayTypes) 
            {
                return;
            }
                
            Cursor.Current = Cursors.WaitCursor;
            this.m_cmdSave.Enabled = false;

            if (this.m_blnNewYBDefPayTypes)
            {//新增的保存

                clsYBDefPayTypeVO ybDefPayTypeVO = new clsYBDefPayTypeVO();

                clsPatientType_VO patientPayType = this.m_cboTypeName.SelectedItem as clsPatientType_VO;
                if (patientPayType == null)
                {
                    MessageBox.Show("请选择患者身份类型！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ybDefPayTypeVO.m_strPayTypeId = patientPayType.m_strPayTypeID;
                ybDefPayTypeVO.m_strYBJslx = GetJslxId(this.m_cboYBJslxName.SelectedIndex);
                ybDefPayTypeVO.m_strYBRylb = GetRylxId(this.m_cboYBRylxName.SelectedIndex);
                ybDefPayTypeVO.m_strPayTypeName = patientPayType.m_strPayTypeName;

                clsYBDefPayTypeVO temp=null;
                clsDcl_YBDefPayTypeSmp.s_object.m_lngFind(ybDefPayTypeVO.m_strPayTypeId,out temp);
                if (temp!=null)
                {
                    MessageBox.Show("该患者身份类型已经添加！","系统消息",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }

                long lngRes = clsDcl_YBDefPayTypeSmp.s_object.m_lngInsert(ybDefPayTypeVO);
                if (lngRes > 0)
                {//成功
                    //更新状态标志

                    this.m_blnNewYBDefPayTypes = false;
                    //加入到集合

                    clsYBDefPayTypeVO[] objGroupArr = (clsYBDefPayTypeVO[])this.m_lsvYBPayTypes.Tag;
                    clsYBDefPayTypeVO[] objGroupNewArr = new clsYBDefPayTypeVO[objGroupArr.Length + 1];
                    objGroupArr.CopyTo(objGroupNewArr, 0);
                    objGroupNewArr[objGroupNewArr.Length - 1] = ybDefPayTypeVO;
                    this.m_lsvYBPayTypes.Tag = objGroupNewArr;

                    //添加新项
                    ListViewItem item = new ListViewItem(ybDefPayTypeVO.m_strPayTypeId);
                    item.SubItems.Add(ybDefPayTypeVO.m_strPayTypeName);
                    item.SubItems.Add(ybDefPayTypeVO.m_strYBJslxName());
                    item.SubItems.Add(ybDefPayTypeVO.m_strYBRylbName());
                    item.Tag = ybDefPayTypeVO;

                    this.m_lsvYBPayTypes.Items.Add(item);

                    item.Selected = true;
                    item.Focused = true;
                    this.m_txtTypeId.Enabled = false;
                    this.m_lsvYBPayTypes_Click(null, null);

                }
                else
                {//失败
                    MessageBox.Show("新增数据失败！");
                }
            }
            else
            {//修改的保存

                clsPatientType_VO patientPayType = this.m_cboTypeName.SelectedItem as clsPatientType_VO;
                if (patientPayType == null)
                {
                    MessageBox.Show("请选择患者身份类型！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                clsYBDefPayTypeVO objYBDefPayType = (clsYBDefPayTypeVO)this.m_lsvYBPayTypes.FocusedItem.Tag;

                clsYBDefPayTypeVO objGroup = new clsYBDefPayTypeVO();
                objYBDefPayType.m_mthCopyTo(objGroup);

                objYBDefPayType.m_strPayTypeName = patientPayType.m_strPayTypeName;
                objYBDefPayType.m_strYBJslx = GetJslxId(this.m_cboYBJslxName.SelectedIndex);
                objYBDefPayType.m_strYBRylb = GetRylxId(this.m_cboYBRylxName.SelectedIndex);

                long lngRes = clsDcl_YBDefPayTypeSmp.s_object.m_lngUpdate(objYBDefPayType);

                if (lngRes > 0)
                {//成功
                    //objGroup.m_mthCopyTo(objYBDefPayType);
                    this.m_lsvYBPayTypes.FocusedItem.Text = objYBDefPayType.m_strPayTypeId;
                    this.m_lsvYBPayTypes.FocusedItem.SubItems[1].Text = objYBDefPayType.m_strPayTypeName;
                    this.m_lsvYBPayTypes.FocusedItem.SubItems[2].Text = objYBDefPayType.m_strYBJslxName();
                    this.m_lsvYBPayTypes.FocusedItem.SubItems[3].Text = objYBDefPayType.m_strYBRylbName();
                    m_lsvYBPayTypes.Tag = objYBDefPayType;
                }
                else
                {//失败
                    MessageBox.Show("修改数据失败！");
                }
                this.m_txtTypeId.Enabled = false;
            }
            this.m_cmdSave.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            if (this.m_lsvYBPayTypes.FocusedItem == null)
                return;

            Cursor.Current = Cursors.WaitCursor;
            this.m_cmdDelete.Enabled = false;

            clsYBDefPayTypeVO objYBDefPayType = (clsYBDefPayTypeVO)this.m_lsvYBPayTypes.FocusedItem.Tag;
            clsYBDefPayTypeVO objCopy = new clsYBDefPayTypeVO();
            objYBDefPayType.m_mthCopyTo(objCopy);

            long lngRes = clsDcl_YBDefPayTypeSmp.s_object.m_lngDelete(objCopy);

            if (lngRes > 0)
            {//成功

                int intIdx = this.m_lsvYBPayTypes.FocusedItem.Index;

                this.m_lsvYBPayTypes.FocusedItem.Remove();

                //设置新的具有焦点的 ListView 项

                if (intIdx < this.m_lsvYBPayTypes.Items.Count)
                {
                    this.m_lsvYBPayTypes.Items[intIdx].Selected = true;
                    this.m_lsvYBPayTypes.Items[intIdx].Focused = true;
                    this.m_lsvYBPayTypes_Click(null, null);
                }
                else if (intIdx - 1 >= 0)
                {
                    this.m_lsvYBPayTypes.Items[intIdx - 1].Selected = true;
                    this.m_lsvYBPayTypes.Items[intIdx - 1].Focused = true;
                    this.m_lsvYBPayTypes_Click(null, null);
                }
            }
            else
            {//失败
                MessageBox.Show("删除失败！");
            }

            this.m_cmdDelete.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void frmYBDefPayType_Load(object sender, EventArgs e)
        {
            m_mthLoadYBTypeList();
            this.m_mthLoadYBDefPayTypes();
            this.m_txtTypeId.Enabled = false;
            this.m_cboTypeName.Enabled = false;
        }

        private void m_lsvYBPayTypes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            bool isAsc = false;
            ListView lsvTemp = m_lsvYBPayTypes;
            if (lsvTemp.Sorting == SortOrder.Ascending)
            {
                lsvTemp.Sorting = SortOrder.Descending;
            }
            else
            {
                lsvTemp.Sorting = SortOrder.Ascending;
                isAsc = true;
            }
            lsvTemp.ListViewItemSorter = new ListViewItemComparer(e.Column, isAsc, lsvTemp);
            lsvTemp.Sort();
        } 

        #endregion

        #region 控件的下拉选定值

        private string GetJslxId(int index)
        {
            string ryJslxId = string.Empty;
            switch (index)
            {
                case 0: ryJslxId = "001"; break;
                case 1: ryJslxId = "010"; break;
                case 2: ryJslxId = "012"; break;
                case 3: ryJslxId = "014"; break;
                case 4: ryJslxId = "015"; break;
                default:
                    break;
            }
            return ryJslxId;
        }

        private string GetRylxId(int index)
        {
            string rylxId = string.Empty;
            switch (index)
            {
                case 0: rylxId = "001"; break;
                case 1: rylxId = "002"; break;
                case 2: rylxId = "003"; break;
                default:
                    break;
            }
            return rylxId;
        }

        private int GetRylxIndex(string rylb)
        {
            int index = 0;
            switch (rylb)
            {
                case "001": index = 0; break;
                case "002": index = 1; break;
                case "003": index = 2; break;
                default:
                    break;
            }
            return index;
        }

        private int GetJslxIndex(string jslxId)
        {
            int index = 0;
            switch (jslxId)
            {
                case "001": index = 0; break;
                case "010": index = 1; break;
                case "012": index = 2; break;
                case "014": index = 3; break;
                case "015": index = 4; break;
                default:
                    break;
            }
            return index;
        }

        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void m_cboTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsPatientType_VO patientType = m_cboTypeName.SelectedItem as clsPatientType_VO;
            if (patientType!=null)
            {
                this.m_txtTypeId.Text = patientType.m_strPayTypeID;
            }
        }

    }
} 