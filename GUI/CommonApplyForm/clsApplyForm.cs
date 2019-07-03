using System;
using com.digitalwave.GLS_WS.UI;
using com.digitalwave.GLS_WS.Logic;
using com.digitalwave.GLS_WS.VO;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.GLS_WS
{
	/// <summary>	/// 
	/// 描述:通用检查申请单外部调用入口
	/// 引用:DigitalWave.BaseForm.dll , DigitalWave.DbService.dll , CommonApplyForm.dll
	/// </summary>
	public class clsApplyForm
	{
		#region 内部东东

		public frmProject mainForm = null;
		private FormPrinter printer = null;
		internal static clsCheckType[] saveResult = null;

		public clsApplyForm()
		{		
			Initial();
			printer = new FormPrinter();
		}

		private static void Main()
		{
//			frmProject fm = frmProject.Create();
//			fm.editor = new DigitalWave.Logic.ProjectEditor(fm);
			System.Windows.Forms.Application.Run(new Form1());
		}

		private void Initial()
		{
			if (this.mainForm == null)
			{
				saveResult = null;
				mainForm = frmProject.Create();
				mainForm.editor = new com.digitalwave.GLS_WS.Logic.ProjectEditor(mainForm);
			}
		}

		#endregion

		#region 外部调用接口
        /// <summary>
        /// 1-心电图；2-动态心电图；3-平板运动心电图
        /// </summary>
        public int m_intHeartType = 0;
		/// <summary>
		/// 打开相应的检查申请单
		/// </summary>
		/// <param name="applyID">索引号</param>
		public void OpenForm(string applyID)
		{		
			Initial();
            mainForm.editor.m_intHeartType = 1;
			mainForm.editor.Open(applyID);	
		}
		
		/// <summary>
		/// 直接打印检查申请单
		/// </summary>
		/// <param name="applyID">索引号</param>
		public void Print(string applyID)
		{
			printer.Print(applyID);
		}

		/// <summary>
		/// 打印预览检查申请单
		/// </summary>
		/// <param name="applyID">索引号</param>
		public void PintPreview(string applyID)
		{
			printer.PrintPreview(applyID);
		}

		/// <summary>
		/// 删除指定检查单,成功返回true
		/// </summary>
		/// <param name="applyID"></param>
		public bool Delete(string applyID)
		{
			Initial();
			return mainForm.editor.Delete(applyID);
		}

		/// <summary>
		/// 申请单交费状态修改
		/// </summary>
		/// <param name="sysFromID">来源 {1=门诊;2=住院;3=电子病历;4=其它}</param>
		/// <param name="sourceItemID">源id {if (门诊) = 处方id; if (住院) = 医嘱id}</param>
		/// <param name="newChargeStatus">缴费信息 0-不记录缴费信息 1-未缴费 2-已缴费 3-已退费</param>
		public void SetChargeStatus(string sysFromID, string sourceItemID,string newChargeStatus)
		{
			Logic.clsDataQuery dq = new clsDataQuery();
			dq.SetChargeStatus(sysFromID, sourceItemID, newChargeStatus);
		}

		/// <summary>
		/// 保存一个申请检查单VO.(弹出检查类型选择框)
		/// </summary>
		/// <returns>VO</returns>
		public clsCheckType[] SaveWithVO(clsApplyRecord vo)
		{
			Initial();
			return mainForm.editor.SaveWithVO(vo);
		}    
   
		/// <summary>
		/// 根据VO保存数据，并返回申请单ID
		/// </summary>
		/// <param name="vo"></param>
		/// <returns></returns>
		public clsCheckType GetIDWithVO(clsApplyRecord vo)
		{
			return mainForm.editor.GetIDWithVO(vo);
		}

        public clsCheckType[] opGetIDWithVO(clsApplyRecord[] VO,System.Collections.Hashtable p_has)
        {
            return mainForm.editor.opGetIDWithVO(VO, p_has);
        }
        /// <summary>
        /// 根据VO保存数据，并返回申请单ID
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        public clsCheckType[] GetIDWithVO(clsApplyRecord[] vo)
        {
            return mainForm.editor.GetIDWithVO(vo);
        }

        /// <summary>
        /// 并单分隔符
        /// </summary>
        public const string strSeparate = "+";

		/// <summary>
		/// 打开一个检查申请单VO供编辑,保存后返回单号
		/// </summary>
		/// <param name="vo"></param>
		/// <returns></returns>
		public clsCheckType[] OpenWithVO(clsApplyRecord vo)
		{
			Initial();
			return mainForm.editor.OpenWithVO(vo);	
		}
	
		/// <summary>
		/// 显示检查类型字典维护窗体
		/// </summary>
		public void ShowDictionary()
		{
			frmDictManage frm = new frmDictManage();
			frm.Show();
		}
        /// <summary>
        /// 返回两个日期之间的申请单
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="typeID">NULL，或单个ID或“1,2,3,4,5”--多个ID用逗号隔开</param>
        /// <returns></returns>
        public clsApplyRecord[] GetApplyRecordByDate(DateTime fromDate, DateTime toDate, string typeID)
        {
            clsDataQuery q = new clsDataQuery();
            return q.GetApplyRecord(fromDate, toDate, typeID);
        }
        public clsApplyRecord[] GetApplyRecordByConditions(string fromDate, string toDate, string p_strPatientNo, string p_strInPatientNo, string p_strPatientName, string p_strDept, string strApplyPart, bool m_blnFinished)
        {
            clsDataQuery q = new clsDataQuery();
            return q.GetApplyRecordByConditions(fromDate, toDate, p_strPatientNo, p_strInPatientNo, p_strPatientName, p_strDept, strApplyPart, m_blnFinished);
        }
		/// <summary>
		/// 返回所有检查类型,仅 m_strTypeID 和 m_strTypeName(检查类型名称)有用
		/// </summary>
		/// <returns></returns>
		public clsCheckType[] GetAllCheckTypes()
		{
			clsDataQuery q = new clsDataQuery();
			return q.GetAllCheckTypes();
		}

		/// <summary>
		/// 返回所有检查类型,仅 m_strTypeID 和 m_strTypeName(检查类型名称)有用
		/// </summary>
		/// <param name="p_strARTypeArr"></param>
		/// <returns></returns>
		public clsCheckType[] GetSpecCheckTypes(string[] p_strARTypeArr)
		{
			clsDataQuery q = new clsDataQuery();
			return q.GetSpecCheckTypes(p_strARTypeArr);
		}
        /// <summary>
        /// 返回两个日期之间的申请单
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="typeID">NULL，或单个ID或“1,2,3,4,5”--多个ID用逗号隔开</param>
        /// <returns></returns>
        public clsApplyRecord[] m_mthGetApplyRecordByDate(DateTime fromDate, DateTime toDate, string typeID)
        {
            clsDataQuery q = new clsDataQuery();
            return q.GetApplyRecord(fromDate, toDate, typeID);
        }

		#endregion
	}
}
