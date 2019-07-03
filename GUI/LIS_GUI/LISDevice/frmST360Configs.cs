using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmST360Configs : Form
    {
        public frmST360Configs()
        {
            InitializeComponent();
        }
      
        private void frmST360Configs_Load(object sender, EventArgs e)
        {
            //LoadProjects();
        }

        #region TabpageSelected
        //private void m_tabControl_Selected(object sender, TabControlEventArgs e)
        //{
        //    switch (e.TabPageIndex)
        //    {
        //        case 0:
        //            if (this.m_lsvWorkGroup.Tag == null)
        //                this.m_mthLoadWorkGroup();
        //            break;
        //        case 1:
        //            if (this.m_lsvProject.Tag == null)
        //                this.m_mthLoadProject();
        //            break;
        //        case 2:
        //            if (this.m_lsvConcentration.Tag == null)
        //                this.m_mthLoadConcentration();
        //            break;
        //        case 3:
        //            if (this.m_lsvVendor.Tag == null)
        //                this.m_mthLoadVendor();
        //            break;
        //        default:
        //            break;
        //    }
        //}
        #endregion

        #region Project

        bool m_blnProject = false;

        //private void LoadProjects()
        //{
        //    foreach (clsSTCheckProject project in clsST360Config.CurrentConfig.Projects)
        //    {
        //        this.m_lsvProject.Items.Clear();
        //        this.m_lsvProject.BeginUpdate();

        //        ListViewItem viewItem = new ListViewItem(project.Name);
        //        viewItem.SubItems.Add(project.EnglishName);
        //        viewItem.SubItems.Add(project.TestWaveLength);
        //        viewItem.SubItems.Add(project.BoardTime);
        //        viewItem.SubItems.Add(project.RefWaveLength);
        //        viewItem.Tag = project;
        //        m_lsvProject.Items.Add(viewItem);
        //        this.m_lsvProject.EndUpdate();
        //    }
        //}

        private void m_mthLoadProject()
        {
            Cursor.Current = Cursors.WaitCursor;

            clsSTCheckProject[] objProjectArr = clsST360Config.CurrentConfig.Projects.ToArray();

            //加载数据
            m_lsvProject.Tag = objProjectArr;

            //填充列表
            m_mthShowProjectList(objProjectArr);

            Cursor.Current = Cursors.Default;
        }

        private void m_mthShowProjectList(clsSTCheckProject[] objProjectsArr)
        {
            this.m_lsvProject.BeginUpdate();//开始更新列表
            this.m_lsvProject.Items.Clear();
            if (objProjectsArr != null)
            {
                foreach (clsSTCheckProject project in objProjectsArr)
                {
                    ListViewItem item = new ListViewItem(project.Name);
                    item.SubItems.Add(project.EnglishName);
                    item.SubItems.Add(project.TestWaveLength);
                    item.SubItems.Add(project.BoardTime);
                    item.SubItems.Add(project.RefWaveLength);
                    item.Tag = project;
                    m_lsvProject.Items.Add(item);
                }
            }
            //重置状态标志
            this.m_blnProject = false;
            //清空明细
            m_mthProjectDetailClear();

            this.m_lsvProject.EndUpdate();//结束更新列表
        }

        private void m_lsvProject_Click(object sender, EventArgs e)
        {
            if (this.m_lsvProject.FocusedItem == null)
                return;
            //变更状态标志
            this.m_blnProject = false;

            clsSTCheckProject objProject = (clsSTCheckProject)this.m_lsvProject.FocusedItem.Tag;

            this.m_txtBoardFrequency.Text = objProject.BoardFrequence;
            this.m_txtBoardTime.Text = objProject.BoardTime;
            this.m_txtBoardWay.Text = objProject.BoardWay;
            this.m_txtEnglishName.Text = objProject.EnglishName;
            this.m_txtRefWaveLength.Text = objProject.RefWaveLength;
            this.m_txtTestWaveLength.Text = objProject.TestWaveLength;
            this.m_txtProjectName.Text = objProject.Name;

            foreach (clsSTConstractRule rule in objProject.ConstractRules)
            {
                if (rule.Positive)
                {
                    if (rule.BiggerThan)
                    {
                        this.m_chkBigP.Checked = true;
                        this.m_txtBigRefP.Text = rule.ReferenceValue.ToString();
                        this.m_txtBigActualP.Text = rule.ActualValue.ToString();

                    }
                    else 
                    {
                        this.m_chkSmallP.Checked = false;
                        this.m_txtSmallRefP.Text = rule.ReferenceValue.ToString();
                        this.m_txtSmallActualP.Text = rule.ActualValue.ToString();
                    }
                }
                else 
                {
                    if (rule.BiggerThan)
                    {
                        this.m_chkBigN.Checked = true;
                        this.m_txtBigRefN.Text = rule.ReferenceValue.ToString();
                        this.m_txtBigActualN.Text = rule.ActualValue.ToString();

                    }
                    else
                    {
                        this.m_chkSmallN.Checked = false;
                        this.m_txtSmallRefN.Text = rule.ReferenceValue.ToString();
                        this.m_txtSmallActualN.Text = rule.ActualValue.ToString();
                    }
                }
            }
        }

        //清空明细
        private void m_mthProjectDetailClear()
        {
            this.m_txtBoardFrequency.Text = string.Empty;
            this.m_txtBoardTime.Text = string.Empty;
            this.m_txtBoardWay.Text = string.Empty;
            this.m_txtEnglishName.Text = string.Empty;
            this.m_txtRefWaveLength.Text = string.Empty;
            this.m_txtTestWaveLength.Text = string.Empty;
            this.m_txtProjectName.Text = string.Empty;

            this.m_chkBigN.Checked = false;
            this.m_chkBigP.Checked = false;
            this.m_chkSmallN.Checked = false;
            this.m_chkSmallP.Checked = false;

            this.m_txtSmallActualN.Text = string.Empty;
            this.m_txtSmallActualP.Text = string.Empty;
            this.m_txtSmallRefN.Text = string.Empty;
            this.m_txtSmallRefP.Text = string.Empty;
            this.m_txtBigActualN.Text = string.Empty;
            this.m_txtBigActualP.Text = string.Empty;
            this.m_txtBigRefN.Text = string.Empty;
            this.m_txtBigRefP.Text = string.Empty;
        }

        private void m_cmdProjectNew_Click(object sender, EventArgs e)
        {
            //使当前ListView具有焦点的行失去焦点
            if (this.m_lsvProject.FocusedItem != null)
            {
                this.m_lsvProject.FocusedItem.Selected = false;
                this.m_lsvProject.FocusedItem.Focused = false;
            }

            //清空明细
            m_mthProjectDetailClear();

            //设置光标焦点
            this.m_txtProjectName.Focus();

            //设置新增标志
            this.m_blnProject = true;
        }

        private void m_cmdProjectSave_Click(object sender, EventArgs e)
        {
            if (this.m_lsvProject.FocusedItem == null
              && !this.m_blnProject)
                return;
            Cursor.Current = Cursors.WaitCursor;
            this.m_cmdProjectSave.Enabled = false;

            if (this.m_blnProject)
            {//新增的保存
                clsSTCheckProject objProject = new clsSTCheckProject();

                objProject.BoardFrequence=this.m_txtBoardFrequency.Text ;
                objProject.BoardTime=this.m_txtBoardTime.Text;
                objProject.BoardWay=this.m_txtBoardWay.Text ;
                 objProject.EnglishName=this.m_txtEnglishName.Text ;
                objProject.RefWaveLength=this.m_txtRefWaveLength.Text;
                objProject.TestWaveLength=this.m_txtTestWaveLength.Text;
                objProject.Name=this.m_txtProjectName.Text;

                List<clsSTConstractRule> lstRules = new List<clsSTConstractRule>();
                if (m_chkSmallN.Checked)
                {
                    clsSTConstractRule ruleSmallN = new clsSTConstractRule();
                    ruleSmallN.Positive = false;
                    ruleSmallN.BiggerThan = false;
                    ruleSmallN.ReferenceValue = float.Parse(this.m_txtSmallRefN.Text);
                    ruleSmallN.ActualValue = float.Parse(this.m_txtSmallActualN.Text);
                    lstRules.Add(ruleSmallN);
                }
                if (m_chkBigN.Checked)
                {
                    clsSTConstractRule ruleBigN = new clsSTConstractRule();
                    ruleBigN.Positive = false;
                    ruleBigN.BiggerThan = true;
                    ruleBigN.ReferenceValue = float.Parse(this.m_txtBigRefN.Text);
                    ruleBigN.ActualValue = float.Parse(this.m_txtBigActualN.Text);
                    lstRules.Add(ruleBigN);
                }

                if (m_chkSmallP.Checked)
                {
                    clsSTConstractRule ruleSmallP = new clsSTConstractRule();
                    ruleSmallP.Positive = false;
                    ruleSmallP.BiggerThan = false;
                    ruleSmallP.ReferenceValue = float.Parse(this.m_txtSmallRefP.Text);
                    ruleSmallP.ActualValue = float.Parse(this.m_txtSmallActualP.Text);
                    lstRules.Add(ruleSmallP);
                }
                if (m_chkBigP.Checked)
                {
                    clsSTConstractRule ruleBigP = new clsSTConstractRule();
                    ruleBigP.Positive = false;
                    ruleBigP.BiggerThan = true;
                    ruleBigP.ReferenceValue = float.Parse(this.m_txtBigRefP.Text);
                    ruleBigP.ActualValue = float.Parse(this.m_txtBigActualP.Text);
                    lstRules.Add(ruleBigP);
                }
               
               
                //if (lngRes > 0)
                //{//成功
                //    //更新状态标志
                //    this.m_blnProject = false;
                //    //加入到集合
                //    clsSTCheckProject[] objProjects = (clsSTCheckProject[])this.m_lsvProject.Tag;
                //    clsSTCheckProject[] objProjectsNewArr = new clsSTCheckProject[objProjects.Length + 1];
                //    objProjects.CopyTo(objProjectsNewArr, 0);
                //    objProjectsNewArr[objProjectsNewArr.Length - 1] = objProject;
                //    this.m_lsvProject.Tag = objProjectsNewArr;
                //    //添加新项
                //    ListViewItem item = new ListViewItem(objProject.m_strName);

                //    item.SubItems.Add(objProject.m_strPycode);
                //    item.SubItems.Add(objProject.m_strWbcode);

                //    item.Tag = objProject;
                //    this.m_lsvProject.Items.Add(item);
                //    item.Selected = true;
                //    item.Focused = true;
                //    this.m_lsvProject_Click(null, null);

                //}
                //else
                //{//失败
                //    clsCommonDialog.m_mthShowDBError();
                //}
            }
            else
            {//修改的保存
                //clsSTCheckProject objProject = (clsSTCheckProject)this.m_lsvProject.FocusedItem.Tag;

                //clsSTCheckProject objNewProject = new clsSTCheckProject();
                //objProject.m_mthCopyTo(objNewProject);
                //objNewProject.m_strName = this.m_txtProjectName.Text.Trim();
                //objNewProject.m_strPycode = this.m_txtProjectPYCode.Text.Trim();
                //objNewProject.m_strWbcode = this.m_txtProjectWBCode.Text.Trim();

                //long lngRes = clsTmdProjectSmp.s_object.m_lngUpdate(objNewProject);

                //if (lngRes > 0)
                //{//成功
                //    objNewProject.m_mthCopyTo(objProject);

                //    this.m_lsvProject.FocusedItem.Text = objProject.m_strName;
                //    this.m_lsvProject.FocusedItem.SubItems[1].Text = objProject.m_strPycode;
                //    this.m_lsvProject.FocusedItem.SubItems[2].Text = objProject.m_strWbcode;
                //}
                //else
                //{//失败
                //    clsCommonDialog.m_mthShowDBError();
                //}
            }
            //this.m_ProjectdProjectSave.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void m_ProjectdProjectDelete_Click(object sender, EventArgs e)
        {
            //if (this.m_lsvProject.FocusedItem == null)
            //    return;
            //Cursor.Current = Cursors.WaitCursor;
            //this.m_ProjectdProjectDelete.Enabled = false;
            //clsSTCheckProject objProject = (clsSTCheckProject)this.m_lsvProject.FocusedItem.Tag;
            //clsSTCheckProject objCopy = new clsSTCheckProject();
            //objProject.m_mthCopyTo(objCopy);

            //long lngRes = clsTmdProjectSmp.s_object.m_lngDelete(objCopy.m_intSeq);

            //if (lngRes > 0)
            //{//成功
            //    int intIdx = this.m_lsvProject.FocusedItem.Index;

            //    this.m_lsvProject.FocusedItem.Remove();

            //    //设置新的具有焦点的 ListView 项
            //    if (intIdx < this.m_lsvProject.Items.Count)
            //    {
            //        this.m_lsvProject.Items[intIdx].Selected = true;
            //        this.m_lsvProject.Items[intIdx].Focused = true;
            //        this.m_lsvProject_Click(null, null);
            //    }
            //    else if (intIdx - 1 >= 0)
            //    {
            //        this.m_lsvProject.Items[intIdx - 1].Selected = true;
            //        this.m_lsvProject.Items[intIdx - 1].Focused = true;
            //        this.m_lsvProject_Click(null, null);
            //    }
            //}
            //else
            //{//失败
            //    clsCommonDialog.m_mthShowDBError();
            //}
            //this.m_ProjectdProjectDelete.Enabled = true;
            //Cursor.Current = Cursors.Default;
        }

        #endregion

        #region Sample

        //bool m_blnNewWorkGroup = false;

        ////加载数据和填充列表
        //private void m_mthLoadWorkGroup()
        //{
        //    Cursor.Current = Cursors.WaitCursor;

        //    //加载数据
        //    clsLisWorkGroupVO[] objGroupArr = null;
        //    clsTmdWorkGroupSmp.s_object.m_lngFind(out objGroupArr);
        //    if (objGroupArr == null)
        //    {
        //        objGroupArr = new clsLisWorkGroupVO[0];
        //    }
        //    m_lsvWorkGroup.Tag = objGroupArr;

        //    //填充列表
        //    m_mthShowWorkGroupList(objGroupArr, this.m_chkWGShowDeleted.Checked);

        //    Cursor.Current = Cursors.Default;
        //}

        ////填充列表
        //private void m_mthShowWorkGroupList(clsLisWorkGroupVO[] objGroupArr, bool p_blnDeleted)
        //{
        //    this.m_lsvWorkGroup.BeginUpdate();//开始更新列表
        //    this.m_lsvWorkGroup.Items.Clear();
        //    if (objGroupArr != null)
        //    {
        //        foreach (clsLisWorkGroupVO group in objGroupArr)
        //        {
        //            //根据类别过滤需要填充的项
        //            if ((p_blnDeleted && (group.m_enmStatus == enmQCStatus.Delete))
        //                || (!p_blnDeleted && (group.m_enmStatus == enmQCStatus.Natrural)))
        //            {
        //                ListViewItem item = new ListViewItem(group.m_strName);
        //                item.SubItems.Add(group.m_strSummary);
        //                item.Tag = group;

        //                this.m_lsvWorkGroup.Items.Add(item);
        //            }
        //        }
        //    }
        //    //重置状态标志
        //    this.m_blnNewWorkGroup = false;
        //    //清空明细
        //    m_mthWGDetailClear();

        //    this.m_lsvWorkGroup.EndUpdate();//结束更新列表
        //}
        ////列表选定项变更
        //private void m_lsvWorkGroup_Click(object sender, EventArgs e)
        //{
        //    if (this.m_lsvWorkGroup.FocusedItem == null)
        //        return;
        //    //变更状态标志
        //    this.m_blnNewWorkGroup = false;

        //    clsLisWorkGroupVO objWorkGroup = (clsLisWorkGroupVO)this.m_lsvWorkGroup.FocusedItem.Tag;

        //    this.m_txtWGName.Text = objWorkGroup.m_strName;
        //    this.m_txtWGSummary.Text = objWorkGroup.m_strSummary;
        //}

        ////类别变更
        //private void m_chkWGShowDeleted_CheckedChanged(object sender, EventArgs e)
        //{
        //    Cursor.Current = Cursors.WaitCursor;
        //    m_chkWGShowDeleted.Enabled = false;

        //    //为列表填充选定的类别数据
        //    this.m_mthShowWorkGroupList((clsLisWorkGroupVO[])this.m_lsvWorkGroup.Tag, this.m_chkWGShowDeleted.Checked);

        //    //根据类别设置控件状态
        //    this.m_ProjectdWGCancelDelete.Visible = this.m_chkWGShowDeleted.Checked;
        //    this.m_ProjectdWGNew.Visible = !this.m_chkWGShowDeleted.Checked;
        //    this.m_ProjectdWGSave.Visible = !this.m_chkWGShowDeleted.Checked;
        //    this.m_ProjectdWGDelete.Visible = !this.m_chkWGShowDeleted.Checked;
        //    this.m_gpbWorkGroup.Enabled = !this.m_chkWGShowDeleted.Checked;

        //    m_chkWGShowDeleted.Enabled = true;
        //    Cursor.Current = Cursors.Default;
        //}

        ////恢复
        //private void m_ProjectdWGCancelDelete_Click(object sender, EventArgs e)
        //{
        //    if (this.m_lsvWorkGroup.FocusedItem == null
        //        || this.m_lsvWorkGroup.FocusedItem.Tag == null)
        //        return;

        //    Cursor.Current = Cursors.WaitCursor;
        //    m_ProjectdWGCancelDelete.Enabled = false;

        //    clsLisWorkGroupVO objGroup = (clsLisWorkGroupVO)this.m_lsvWorkGroup.FocusedItem.Tag;
        //    clsLisWorkGroupVO objCopy = new clsLisWorkGroupVO();
        //    objGroup.m_mthCopyTo(objCopy);//拷贝到另一个对象
        //    objCopy.m_enmStatus = enmQCStatus.Natrural;

        //    //更新到数据库
        //    long lngRes = clsTmdWorkGroupSmp.s_object.m_lngUpdate(objCopy);

        //    if (lngRes > 0)
        //    {//更新成功
        //        objGroup.m_enmStatus = enmQCStatus.Natrural;
        //        int intIdx = this.m_lsvWorkGroup.FocusedItem.Index;

        //        this.m_lsvWorkGroup.FocusedItem.Remove();

        //        //设置新的具有焦点的 ListView 项
        //        if (intIdx < this.m_lsvWorkGroup.Items.Count)
        //        {
        //            this.m_lsvWorkGroup.Items[intIdx].Selected = true;
        //            this.m_lsvWorkGroup.Items[intIdx].Focused = true;
        //            this.m_lsvWorkGroup_Click(null, null);
        //        }
        //        else if (intIdx - 1 >= 0)
        //        {
        //            this.m_lsvWorkGroup.Items[intIdx - 1].Selected = true;
        //            this.m_lsvWorkGroup.Items[intIdx - 1].Focused = true;
        //            this.m_lsvWorkGroup_Click(null, null);
        //        }
        //    }
        //    else
        //    {//更新失败
        //        clsCommonDialog.m_mthShowDBError();
        //    }

        //    m_ProjectdWGCancelDelete.Enabled = true;
        //    Cursor.Current = Cursors.Default;
        //}

        ////新增
        //private void m_ProjectdWGNew_Click(object sender, EventArgs e)
        //{
        //    //使当前ListView具有焦点的行失去焦点
        //    if (this.m_lsvWorkGroup.FocusedItem != null)
        //    {
        //        this.m_lsvWorkGroup.FocusedItem.Selected = false;
        //        this.m_lsvWorkGroup.FocusedItem.Focused = false;
        //    }

        //    //清空明细
        //    m_mthWGDetailClear();

        //    //设置光标焦点
        //    this.m_txtWGName.Focus();

        //    //设置新增标志
        //    this.m_blnNewWorkGroup = true;
        //}

        ////清空明细
        //private void m_mthWGDetailClear()
        //{
        //    this.m_txtWGName.Clear();
        //    this.m_txtWGSummary.Clear();
        //}

        ////保存
        //private void m_ProjectdWGSave_Click(object sender, EventArgs e)
        //{
        //    if (this.m_lsvWorkGroup.FocusedItem == null
        //        && !this.m_blnNewWorkGroup)
        //        return;
        //    Cursor.Current = Cursors.WaitCursor;
        //    this.m_ProjectdWGSave.Enabled = false;

        //    if (this.m_blnNewWorkGroup)
        //    {//新增的保存
        //        clsLisWorkGroupVO objGroup = new clsLisWorkGroupVO();
        //        objGroup.m_enmStatus = enmQCStatus.Natrural;
        //        objGroup.m_strName = this.m_txtWGName.Text.Trim();
        //        objGroup.m_strSummary = this.m_txtWGSummary.Text;

        //        long lngRes = clsTmdWorkGroupSmp.s_object.m_lngInsert(objGroup);
        //        if (lngRes > 0)
        //        {//成功
        //            //更新状态标志
        //            this.m_blnNewWorkGroup = false;
        //            //加入到集合
        //            clsLisWorkGroupVO[] objGroupArr = (clsLisWorkGroupVO[])this.m_lsvWorkGroup.Tag;
        //            clsLisWorkGroupVO[] objGroupNewArr = new clsLisWorkGroupVO[objGroupArr.Length + 1];
        //            objGroupArr.CopyTo(objGroupNewArr, 0);
        //            objGroupNewArr[objGroupNewArr.Length - 1] = objGroup;
        //            this.m_lsvWorkGroup.Tag = objGroupNewArr;
        //            //添加新项
        //            ListViewItem item = new ListViewItem(objGroup.m_strName);
        //            item.SubItems.Add(objGroup.m_strSummary);
        //            item.Tag = objGroup;
        //            this.m_lsvWorkGroup.Items.Add(item);
        //            item.Selected = true;
        //            item.Focused = true;
        //            this.m_lsvWorkGroup_Click(null, null);

        //        }
        //        else
        //        {//失败
        //            clsCommonDialog.m_mthShowDBError();
        //        }
        //    }
        //    else
        //    {//修改的保存
        //        clsLisWorkGroupVO objWorkGroup = (clsLisWorkGroupVO)this.m_lsvWorkGroup.FocusedItem.Tag;

        //        clsLisWorkGroupVO objGroup = new clsLisWorkGroupVO();
        //        objWorkGroup.m_mthCopyTo(objGroup);
        //        objGroup.m_strName = this.m_txtWGName.Text.Trim();
        //        objGroup.m_strSummary = this.m_txtWGSummary.Text;

        //        long lngRes = clsTmdWorkGroupSmp.s_object.m_lngUpdate(objGroup);

        //        if (lngRes > 0)
        //        {//成功
        //            objGroup.m_mthCopyTo(objWorkGroup);
        //            this.m_lsvWorkGroup.FocusedItem.Text = objWorkGroup.m_strName;
        //            this.m_lsvWorkGroup.FocusedItem.SubItems[1].Text = objWorkGroup.m_strSummary;
        //        }
        //        else
        //        {//失败
        //            clsCommonDialog.m_mthShowDBError();
        //        }
        //    }
        //    this.m_ProjectdWGSave.Enabled = true;
        //    Cursor.Current = Cursors.Default;
        //}

        //private void m_ProjectdWGDelete_Click(object sender, EventArgs e)
        //{
        //    if (this.m_lsvWorkGroup.FocusedItem == null)
        //        return;
        //    Cursor.Current = Cursors.WaitCursor;
        //    this.m_ProjectdWGDelete.Enabled = false;

        //    clsLisWorkGroupVO objWorkGroup = (clsLisWorkGroupVO)this.m_lsvWorkGroup.FocusedItem.Tag;
        //    clsLisWorkGroupVO objCopy = new clsLisWorkGroupVO();
        //    objWorkGroup.m_mthCopyTo(objCopy);
        //    objCopy.m_enmStatus = enmQCStatus.Delete;

        //    long lngRes = clsTmdWorkGroupSmp.s_object.m_lngUpdate(objCopy);

        //    if (lngRes > 0)
        //    {//成功
        //        objWorkGroup.m_enmStatus = enmQCStatus.Delete;
        //        int intIdx = this.m_lsvWorkGroup.FocusedItem.Index;

        //        this.m_lsvWorkGroup.FocusedItem.Remove();

        //        //设置新的具有焦点的 ListView 项
        //        if (intIdx < this.m_lsvWorkGroup.Items.Count)
        //        {
        //            this.m_lsvWorkGroup.Items[intIdx].Selected = true;
        //            this.m_lsvWorkGroup.Items[intIdx].Focused = true;
        //            this.m_lsvWorkGroup_Click(null, null);
        //        }
        //        else if (intIdx - 1 >= 0)
        //        {
        //            this.m_lsvWorkGroup.Items[intIdx - 1].Selected = true;
        //            this.m_lsvWorkGroup.Items[intIdx - 1].Focused = true;
        //            this.m_lsvWorkGroup_Click(null, null);
        //        }
        //    }
        //    else
        //    {//失败
        //        clsCommonDialog.m_mthShowDBError();
        //    }

        //    this.m_ProjectdWGDelete.Enabled = true;
        //    Cursor.Current = Cursors.Default;
        //}

        //private void LoadSameples()
        //{

        //}

        #endregion

        private void m_tabConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.m_tabConfig.SelectedIndex)
            {
                case 1:
                    if (m_lsvProject.Tag==null)
                    {
                        //LoadProjects();
                    }
                    break;
                case 2:
                    if (m_lsvSample.Tag==null)
                    {
                        //LoadSameples();
                    }
                    
                    break;
            }
        }

    }
}