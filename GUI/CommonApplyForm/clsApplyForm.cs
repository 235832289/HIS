using System;
using com.digitalwave.GLS_WS.UI;
using com.digitalwave.GLS_WS.Logic;
using com.digitalwave.GLS_WS.VO;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.GLS_WS
{
	/// <summary>	/// 
	/// ����:ͨ�ü�����뵥�ⲿ�������
	/// ����:DigitalWave.BaseForm.dll , DigitalWave.DbService.dll , CommonApplyForm.dll
	/// </summary>
	public class clsApplyForm
	{
		#region �ڲ�����

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

		#region �ⲿ���ýӿ�
        /// <summary>
        /// 1-�ĵ�ͼ��2-��̬�ĵ�ͼ��3-ƽ���˶��ĵ�ͼ
        /// </summary>
        public int m_intHeartType = 0;
		/// <summary>
		/// ����Ӧ�ļ�����뵥
		/// </summary>
		/// <param name="applyID">������</param>
		public void OpenForm(string applyID)
		{		
			Initial();
            mainForm.editor.m_intHeartType = 1;
			mainForm.editor.Open(applyID);	
		}
		
		/// <summary>
		/// ֱ�Ӵ�ӡ������뵥
		/// </summary>
		/// <param name="applyID">������</param>
		public void Print(string applyID)
		{
			printer.Print(applyID);
		}

		/// <summary>
		/// ��ӡԤ��������뵥
		/// </summary>
		/// <param name="applyID">������</param>
		public void PintPreview(string applyID)
		{
			printer.PrintPreview(applyID);
		}

		/// <summary>
		/// ɾ��ָ����鵥,�ɹ�����true
		/// </summary>
		/// <param name="applyID"></param>
		public bool Delete(string applyID)
		{
			Initial();
			return mainForm.editor.Delete(applyID);
		}

		/// <summary>
		/// ���뵥����״̬�޸�
		/// </summary>
		/// <param name="sysFromID">��Դ {1=����;2=סԺ;3=���Ӳ���;4=����}</param>
		/// <param name="sourceItemID">Դid {if (����) = ����id; if (סԺ) = ҽ��id}</param>
		/// <param name="newChargeStatus">�ɷ���Ϣ 0-����¼�ɷ���Ϣ 1-δ�ɷ� 2-�ѽɷ� 3-���˷�</param>
		public void SetChargeStatus(string sysFromID, string sourceItemID,string newChargeStatus)
		{
			Logic.clsDataQuery dq = new clsDataQuery();
			dq.SetChargeStatus(sysFromID, sourceItemID, newChargeStatus);
		}

		/// <summary>
		/// ����һ�������鵥VO.(�����������ѡ���)
		/// </summary>
		/// <returns>VO</returns>
		public clsCheckType[] SaveWithVO(clsApplyRecord vo)
		{
			Initial();
			return mainForm.editor.SaveWithVO(vo);
		}    
   
		/// <summary>
		/// ����VO�������ݣ����������뵥ID
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
        /// ����VO�������ݣ����������뵥ID
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        public clsCheckType[] GetIDWithVO(clsApplyRecord[] vo)
        {
            return mainForm.editor.GetIDWithVO(vo);
        }

        /// <summary>
        /// �����ָ���
        /// </summary>
        public const string strSeparate = "+";

		/// <summary>
		/// ��һ��������뵥VO���༭,����󷵻ص���
		/// </summary>
		/// <param name="vo"></param>
		/// <returns></returns>
		public clsCheckType[] OpenWithVO(clsApplyRecord vo)
		{
			Initial();
			return mainForm.editor.OpenWithVO(vo);	
		}
	
		/// <summary>
		/// ��ʾ��������ֵ�ά������
		/// </summary>
		public void ShowDictionary()
		{
			frmDictManage frm = new frmDictManage();
			frm.Show();
		}
        /// <summary>
        /// ������������֮������뵥
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="typeID">NULL���򵥸�ID��1,2,3,4,5��--���ID�ö��Ÿ���</param>
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
		/// �������м������,�� m_strTypeID �� m_strTypeName(�����������)����
		/// </summary>
		/// <returns></returns>
		public clsCheckType[] GetAllCheckTypes()
		{
			clsDataQuery q = new clsDataQuery();
			return q.GetAllCheckTypes();
		}

		/// <summary>
		/// �������м������,�� m_strTypeID �� m_strTypeName(�����������)����
		/// </summary>
		/// <param name="p_strARTypeArr"></param>
		/// <returns></returns>
		public clsCheckType[] GetSpecCheckTypes(string[] p_strARTypeArr)
		{
			clsDataQuery q = new clsDataQuery();
			return q.GetSpecCheckTypes(p_strARTypeArr);
		}
        /// <summary>
        /// ������������֮������뵥
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="typeID">NULL���򵥸�ID��1,2,3,4,5��--���ID�ö��Ÿ���</param>
        /// <returns></returns>
        public clsApplyRecord[] m_mthGetApplyRecordByDate(DateTime fromDate, DateTime toDate, string typeID)
        {
            clsDataQuery q = new clsDataQuery();
            return q.GetApplyRecord(fromDate, toDate, typeID);
        }

		#endregion
	}
}
