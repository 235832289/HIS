using System;
using com.digitalwave.GUI_Base;
using com.digitalwave.iCare.common;
using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Collections.Generic;
using com.digitalwave.iCare.gui.HIS;

namespace com.digitalwave.iCare.gui.LIS
{
    public class ctlSamplePack : com.digitalwave.GUI_Base.clsController_Base
    {
        #region override

        private frmSamplePack viewer { get; set; }

        public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            this.viewer = (frmSamplePack)frmMDI_Child_Base_in;
        }

        #endregion

        #region 属性.变量

        /// <summary>
        /// 楼层号
        /// </summary>
        decimal FloorNo { get; set; }

        #endregion

        #region 方法

        #region Init
        /// <summary>
        /// Init
        /// </summary>
        internal void Init()
        {
            viewer.txtBarCode.Text = string.Empty;
            viewer.txtBarCode.Focus();
            viewer.WindowState = FormWindowState.Maximized;
            viewer.Refresh();

            FloorNo = clsPublic.ConvertObjToDecimal(clsPublic.m_strReadXML("Lis", "FloorNo", "AnyOne"));
            if (FloorNo > 0)
            {
                viewer.tsbTempSave.Enabled = true;
            }
            else
            {
                viewer.tsbTempSave.Enabled = false;
                MessageBox.Show("由于本机未配置楼层参数(LoginFile->Lis->FloorNo) \r\n临时保存功能不能使用。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Query
        /// <summary>
        /// Query
        /// </summary>
        internal void Query()
        {
            frmSampleQuery frm = new frmSampleQuery();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(frm.BarCode))
                {
                    FillData(frm.BarCode);
                }
            }
        }

        void FillData(string barCode)
        {
            viewer.dataGridView.Rows.Clear();
            viewer.dataGridView.Refresh();
            try
            {
                viewer.Cursor = Cursors.WaitCursor;
                clsDomainController_ApplicationManage domain = new clsDomainController_ApplicationManage();
                List<EntitySamplePack> data = domain.SamplePackQuery(barCode, ((int)viewer.BizType == 1 ? 2 : 1));
                domain = null;
                if (data != null && data.Count > 0)
                {
                    int n = -1;
                    string[] arr = null;
                    foreach (EntitySamplePack vo in data)
                    {
                        n = -1;
                        arr = new string[15];
                        arr[++n] = vo.sortNo.ToString();
                        arr[++n] = vo.barCode;
                        arr[++n] = vo.patName;
                        arr[++n] = vo.sex;
                        arr[++n] = vo.age;
                        arr[++n] = vo.itemName;
                        arr[++n] = vo.itemCode;
                        arr[++n] = vo.packId.ToString();
                        arr[++n] = vo.peNo;
                        arr[++n] = vo.recorderName;
                        arr[++n] = vo.recordDate.ToString("yyyy-MM-dd HH:mm");
                        arr[++n] = vo.packOperName;
                        arr[++n] = vo.packDate == null ? string.Empty : vo.packDate.Value.ToString("yyyy-MM-dd HH:mm");
                        arr[++n] = vo.status.ToString();
                        arr[++n] = vo.recorderId;
                        viewer.dataGridView.Rows.Add(arr);
                    }
                    viewer.dataGridView.Refresh();
                }
                else
                {
                    MessageBox.Show("查无记录.", "系统提示");
                }
                ShowSampleNums();
            }
            finally
            {
                viewer.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region NewPack
        /// <summary>
        /// NewPack
        /// </summary>
        internal void NewPack()
        {
            if (viewer.dataGridView.Rows.Count > 0)
            {
                if (MessageBox.Show("是否开始打新包？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            viewer.txtBarCode.Text = string.Empty;
            viewer.dataGridView.Rows.Clear();
            viewer.dataGridView.Refresh();
        }
        #endregion

        #region AddSimple
        /// <summary>
        /// AddSimple
        /// </summary>
        internal void AddSimple()
        {
            string barCode = viewer.txtBarCode.Text.Trim();
            clsDomainController_ApplicationManage domain = new clsDomainController_ApplicationManage();
            if (viewer.BizType == 0)
            {
                if (barCode != string.Empty && barCode.Length < 9)
                {
                    barCode = barCode.PadLeft(9, '0');
                    viewer.txtBarCode.Text = barCode;
                }
                if (barCode.Length != 9)
                {
                    MessageBox.Show("请输入9位数的条码号。", "系统提示");
                    return;
                }
            }
            else
            {
                #region 判断是否有临时包
                if (this.FloorNo > 0 && viewer.dataGridView.Rows.Count == 0)
                {
                    string tmpBarCode = string.Empty;
                    if (domain.SamplePackQueryTemp(this.FloorNo, out tmpBarCode))
                    {
                        MessageBox.Show("今天存在临时标本包，系统将自动调出。", "系统提示");
                        FillData(tmpBarCode);
                    }
                }
                #endregion
            }
            DataTable dt = (viewer.BizType == 1 ? domain.GetIpSample(barCode) : domain.GetPeSample(barCode));
            if (dt != null && dt.Rows.Count > 0)
            {
                string age = string.Empty;
                string sex = string.Empty;
                EntitySamplePack vo = new EntitySamplePack();
                vo.sortNo = viewer.dataGridView.Rows.Count + 1;

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["as_group"] == DBNull.Value || string.IsNullOrEmpty(dr["as_group"].ToString()))
                    {
                        MessageBox.Show("combCode:" + dr["comb_code"].ToString() + " 没有对应的检验组合项目,请联系信息科。", "系统提示");
                        return;
                    }
                    vo.itemCode += dr["as_group"].ToString() + ",";
                    vo.itemName += dr["as_group_name"].ToString() + ",";

                    vo.barCode = dr["samp_no"].ToString();
                    vo.peNo = dr["reg_no"].ToString();
                    vo.patName = dr["pat_name"].ToString();
                    sex = dr["sex"].ToString();
                    if (sex != null) sex = sex.Trim();
                    if (sex == "男" || sex == "女")
                        vo.sex = sex;
                    else
                        vo.sex = (sex == "1" ? "男" : "女");
                    age = dr["age"].ToString();
                    if (age.Contains("岁") || age.Contains("月") || age.Contains("天") || age.Contains("时"))
                        vo.age = age;
                    else
                        vo.age = age + " 岁";

                    vo.packId = 0;
                }
                vo.itemCode = vo.itemCode.TrimEnd(',');
                vo.itemName = vo.itemName.TrimEnd(',');

                int n = -1;
                string[] arr = new string[15];
                arr[++n] = vo.sortNo.ToString();
                arr[++n] = vo.barCode;
                arr[++n] = vo.patName;
                arr[++n] = vo.sex;
                arr[++n] = vo.age;
                arr[++n] = vo.itemName;
                arr[++n] = vo.itemCode;
                arr[++n] = vo.packId.ToString();
                arr[++n] = vo.peNo;
                arr[++n] = viewer.LoginInfo.m_strEmpName;
                arr[++n] = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                arr[++n] = string.Empty;
                arr[++n] = string.Empty;
                arr[++n] = "0";
                arr[++n] = viewer.LoginInfo.m_strEmpID;

                // 校验1.
                for (int i = 0; i < viewer.dataGridView.Rows.Count; i++)
                {
                    if (viewer.dataGridView.Rows[i].Cells["barCode"].Value.ToString() == vo.barCode)
                    {
                        MessageBox.Show("该标本已添加到列表。", "系统提示");
                        return;
                    }
                }
                // 校验2.
                bool isExist = domain.SamplePackIsExist(barCode);
                if (isExist)
                {
                    MessageBox.Show("该标本已打包，不能再次添加。", "系统提示");
                    return;
                }

                //viewer.dataGridView.Rows.Add(arr);
                viewer.dataGridView.Rows.Insert(0, arr);
                viewer.dataGridView.Refresh();

                if (viewer.tsbTempSave.Enabled)
                {
                    // 自动临时保存
                    this.CompletePack(0, false);
                }
                viewer.txtBarCode.Text = string.Empty;
                viewer.txtBarCode.Focus();

                ShowSampleNums();
            }
            else
            {
                MessageBox.Show("查无标本信息。", "系统提示");
            }
            domain = null;
        }
        #endregion

        #region DelSimple
        /// <summary>
        /// DelSimple
        /// </summary>
        internal void DelSimple()
        {
            if (MessageBox.Show("是否删除打包标本？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                decimal packId = Convert.ToDecimal(viewer.dataGridView.SelectedRows[0].Cells["packId"].Value);
                if (packId > 0)
                {
                    string barCode = viewer.dataGridView.SelectedRows[0].Cells["barCode"].Value.ToString();
                    clsDomainController_ApplicationManage domain = new clsDomainController_ApplicationManage();
                    try
                    {
                        viewer.Cursor = Cursors.WaitCursor;
                        if (domain.SamplePackDel(new List<string>() { barCode }) > 0)
                        {
                            MessageBox.Show("打包样本删除成功.", "系统提示");
                        }
                        else
                        {
                            MessageBox.Show("打包样本删除失败.", "系统提示");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("打包样本删除异常:" + ex.Message, "系统提示");
                        return;
                    }
                    finally
                    {
                        domain = null;
                        viewer.Cursor = Cursors.Default;
                    }
                }
                viewer.dataGridView.Rows.Remove(viewer.dataGridView.SelectedRows[0]);
                for (int i = 0; i < viewer.dataGridView.Rows.Count; i++)
                {
                    viewer.dataGridView.Rows[i].Cells["sortNo"].Value = Convert.ToString(i + 1);
                }

                ShowSampleNums();
            }
        }
        #endregion

        #region DelSimpleAll
        /// <summary>
        /// DelSimpleAll
        /// </summary>
        internal void DelSimpleAll()
        {
            if (MessageBox.Show("是否删除全部打包标本？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                decimal packId = 0;
                List<string> lstBarCode = new List<string>();
                for (int i = 0; i < viewer.dataGridView.Rows.Count; i++)
                {
                    packId = Convert.ToDecimal(viewer.dataGridView.Rows[i].Cells["packId"].Value);
                    if (packId > 0)
                    {
                        lstBarCode.Add(viewer.dataGridView.Rows[i].Cells["barCode"].Value.ToString());
                    }
                }
                if (lstBarCode.Count > 0)
                {
                    clsDomainController_ApplicationManage domain = new clsDomainController_ApplicationManage();
                    try
                    {
                        viewer.Cursor = Cursors.WaitCursor;
                        if (domain.SamplePackDel(lstBarCode) > 0)
                        {
                            MessageBox.Show("打包样本删除成功.", "系统提示");
                        }
                        else
                        {
                            MessageBox.Show("打包样本删除失败.", "系统提示");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("打包样本删除异常:" + ex.Message, "系统提示");
                        return;
                    }
                    finally
                    {
                        domain = null;
                        viewer.Cursor = Cursors.Default;
                    }
                }
                viewer.dataGridView.Rows.Clear();
                viewer.dataGridView.Refresh();

                ShowSampleNums();
            }
        }
        #endregion

        #region CompletePack
        /// <summary>
        /// CompletePack
        /// </summary>
        /// <param name="packType">0 临时打包; 1 正式打包</param>
        internal void CompletePack(int packType, bool isMsg)
        {
            viewer.lblHint.Text = string.Empty;
            if (viewer.dataGridView.Rows.Count > 0)
            {
                decimal packId = 0;
                decimal packId2 = 0;
                bool isTrue = false;
                List<EntitySamplePack> data = new List<EntitySamplePack>();
                EntitySamplePack vo = null;
                for (int i = 0; i < viewer.dataGridView.Rows.Count; i++)
                {
                    packId = Convert.ToDecimal(viewer.dataGridView.Rows[i].Cells["packId"].Value);
                    vo = new EntitySamplePack();
                    vo.packId = packId;
                    vo.barCode = viewer.dataGridView.Rows[i].Cells["barCode"].Value.ToString();
                    vo.patName = viewer.dataGridView.Rows[i].Cells["patName"].Value.ToString();
                    vo.sex = viewer.dataGridView.Rows[i].Cells["sex"].Value.ToString();
                    vo.age = viewer.dataGridView.Rows[i].Cells["age"].Value.ToString();
                    vo.itemName = viewer.dataGridView.Rows[i].Cells["itemName"].Value.ToString();
                    vo.itemCode = viewer.dataGridView.Rows[i].Cells["itemCode"].Value.ToString();
                    vo.packId = packId;
                    vo.peNo = viewer.dataGridView.Rows[i].Cells["peNo"].Value.ToString();
                    vo.recorderId = viewer.dataGridView.Rows[i].Cells["recorderId"].Value.ToString();
                    vo.recordDate = Convert.ToDateTime(viewer.dataGridView.Rows[i].Cells["recordDate"].Value.ToString());
                    vo.status = Convert.ToInt32(viewer.dataGridView.Rows[i].Cells["status"].Value.ToString());
                    vo.typeId = viewer.BizType;
                    if (packType == 1) vo.packOperId = viewer.LoginInfo.m_strEmpID;
                    if (this.FloorNo > 0) vo.floorNo = this.FloorNo;
                    if (vo.status == 1) isTrue = true;

                    if (packId == 0)
                    {
                        data.Add(vo);
                    }
                    else
                    {
                        packId2 = packId;
                        if (packType == 0)
                            continue;
                        else if (packType == 1 && vo.status == 1)
                            continue;
                        else
                            data.Add(vo);
                    }
                }
                if (isTrue && packType == 0 && data.Count > 0)
                {
                    MessageBox.Show("当前列表存在已打包记录，不能再进行临时打包。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (data.Count == 0)
                {
                    if (packType == 0)
                        MessageBox.Show("数据已完成临时保存。", "系统提示");
                    else
                        MessageBox.Show("数据已完成打包。", "系统提示");
                    return;
                }

                List<EntitySamplePackDetail> lstDetail = new List<EntitySamplePackDetail>();
                EntitySamplePackDetail vod = null;
                foreach (EntitySamplePack item in data)
                {
                    item.status = packType;

                    string[] arr1 = item.itemCode.Split(',');
                    string[] arr2 = item.itemName.Split(',');
                    if (item.packId == 0)
                    {
                        item.packId2 = packId2;
                        if (arr1.Length > 0 && arr1.Length == arr2.Length)
                        {
                            for (int k = 0; k < arr1.Length; k++)
                            {
                                vod = new EntitySamplePackDetail();
                                vod.barCode = item.barCode;
                                vod.itemCode = arr1[k];
                                vod.itemName = arr2[k];
                                lstDetail.Add(vod);
                            }
                        }
                        else
                        {
                            if (packType == 0)
                                MessageBox.Show("标本项目出现异常，临时保存失败。", "系统提示");
                            else
                                MessageBox.Show("标本项目出现异常，打包失败。", "系统提示");
                            return;
                        }
                    }
                }
                clsDomainController_ApplicationManage domain = new clsDomainController_ApplicationManage();
                try
                {
                    viewer.Cursor = Cursors.WaitCursor;
                    if (domain.SamplePackInsert(data, lstDetail, (int)viewer.BizType, out packId) > 0)
                    {
                        string packTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                        for (int i = 0; i < viewer.dataGridView.Rows.Count; i++)
                        {
                            viewer.dataGridView.Rows[i].Cells["packId"].Value = packId;
                            if (packType == 1)
                            {
                                viewer.dataGridView.Rows[i].Cells["packOperName"].Value = viewer.LoginInfo.m_strEmpName;
                                viewer.dataGridView.Rows[i].Cells["packDate"].Value = packTime;
                                viewer.dataGridView.Rows[i].Cells["status"].Value = 1;
                            }
                        }
                        if (packType == 0)
                        {
                            if (isMsg)
                                MessageBox.Show("临时保存成功.", "系统提示");
                            else
                                viewer.lblHint.Text = "临时保存成功";
                        }
                        else
                            MessageBox.Show("打包成功.", "系统提示");
                    }
                    else
                    {
                        if (packType == 0)
                            MessageBox.Show("临时失败.", "系统提示");
                        else
                            MessageBox.Show("打包失败.", "系统提示");
                    }
                }
                catch (Exception ex)
                {
                    if (packType == 0)
                        MessageBox.Show("临时保存异常:" + ex.Message, "系统提示");
                    else
                        MessageBox.Show("打包异常:" + ex.Message, "系统提示");
                }
                finally
                {
                    domain = null;
                    viewer.Cursor = Cursors.Default;
                }
                ShowSampleNums();
            }
        }
        #endregion

        #region 显示状态
        /// <summary>
        /// 显示状态
        /// </summary>
        void ShowSampleNums()
        {
            int num = 0;
            for (int i = 0; i < viewer.dataGridView.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(viewer.dataGridView.Rows[i].Cells["packDate"].Value.ToString()))
                {
                    num++;
                }
            }
            viewer.lblInfo.Text = "整包共 " + viewer.dataGridView.Rows.Count + " 支, 已打包 " + num + " 支";
        }
        #endregion

        #endregion

    }
}
