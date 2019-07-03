using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.clsMiniBloodSugarChk_GXServ;
using iCareData;
namespace iCare
{
    /// <summary>
    /// 微量血糖检测结果记录界面
    /// </summary>
    public partial class frmMiniBooldSugar : iCare.frmRecordsBase
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmMiniBooldSugar()
        {
            InitializeComponent();
            //datagridview列宽控制
            dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; ;
        } 
        #endregion

        #region 字段
        #endregion

        #region 属性
        #endregion

        #region 方法
        /// <summary>
        /// 重写treeview事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void m_trvInPatientDate_AfterSelect(object sender, TreeViewEventArgs e)
        {
            clsMiniBloodSugarChk_GXServ objservice =
                (clsMiniBloodSugarChk_GXServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMiniBloodSugarChk_GXServ));


            try
            {
                //清空病人记录信息				
                m_mthClearPatientRecordInfo();

                if (m_trvInPatientDate.SelectedNode == null || m_trvInPatientDate.SelectedNode == m_trvInPatientDate.Nodes[0] || m_objCurrentPatient == null)
                {
                    return;
                }

                m_objCurrentPatient.m_DtmSelectedInDate = DateTime.Parse(m_trvInPatientDate.SelectedNode.Text);

                //获取病人记录列表
                clsTransDataInfo[] objTansDataInfoArr;
                string m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
                string m_strInPatientDate = m_trvInPatientDate.SelectedNode.Text; //m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss");
                //获取指定入院时间的记录列表
                DataTable dt = new DataTable();
                long lngRes = objservice.m_lngGetRecoedByInPatient(null, m_strInPatientID, DateTime.Parse(m_strInPatientDate), out dt);
                if (dt!=null)
                {
                    　dgvRecords.DataSource = dt;   
                }
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        
  
        /// <summary>
        /// 处理右键单击添加修改记录弹出窗体事件方法
        /// </summary>
        /// <param name="p_intRecordType"></param>
        /// <returns></returns>
        protected override frmDiseaseTrackBase m_frmGetRecordForm(int p_intRecordType)
        {
            switch ((enmDiseaseTrackType)p_intRecordType)
            {
                case enmDiseaseTrackType.GeneralNurseRecord_GXCon:
                    return new frmMiniBooldSugarContent(true);
            }

            return null;
        }
       
        #endregion

        #region 事件
        /// <summary>
        /// 右键添加记录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmAdd_Click(object sender, EventArgs e)
        {
            m_mthAddNewRecord((int)enmDiseaseTrackType.GeneralNurseRecord_GXCon);
        }
        /// <summary>
        /// 右键修改记录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmModify_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 右键删除记录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDelete_Click(object sender, EventArgs e)
        {

        } 
        #endregion
    }
}