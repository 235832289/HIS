using System;
using System.Windows.Forms;

namespace com.digitalwave.Emr.Signature_gui
{
	/// <summary>
	/// clsCommonUseToolCollection ��ժҪ˵����
	/// �ⲿǩ������������
	/// �÷����ڹ��캯���� ����
	/// ǩ��ֵ��
	/// m_objSign = new clsEmrSignToolCollection();
	/// m_objSign.m_mthBindEmployeeSign(new Control[]{btns,btns1},new Control[]{txtsign,txtsign1},new int[]{1,1},new bool[]{true,false});
	/// m_objSign.m_mthBindEmployeeSign(new Control[]{buttonXP1,buttonXP2},new Control[]{textBox1,textBox2},new int[]{1,1},new string[]{"0000070","0000070"},new bool[]{true,false});
	/// create by tfzhang at 2005-12-27 11:49
	/// </summary>
	public class clsEmrSignToolCollection
	{

        //add by haozhong.liu 2008-11-11 �Ƿ���ʾְ��
        private bool m_blnIsShowLevel = true;
        /// <summary>
        /// �Ƿ���ʾְ��
        /// </summary>
        public bool m_BlnIsShowLevel
        {
            get { return m_blnIsShowLevel; }
            set { m_blnIsShowLevel = value; }
        }

		#region ���캯��
		/// <summary>
		/// ���캯��
		/// </summary>
		/// <param name="p_frmParent"></param>
		public clsEmrSignToolCollection()
		{
		}
		#endregion

		#region �󶨷���
		/// <summary>
		/// ��ǩ������ֵǩ��
		/// </summary>
        /// <param name="p_ctlCall">��ť�ؼ� ͨ��PinkieControls</param>
        /// <param name="p_ctlTarget">ǩ�����ܿؼ� ͨ��textbox��listview</param>
        /// <param name="p_intType">ǩ���б�����ͣ�1Ϊҽ��ǩ����2Ϊ��ʿǩ��</param>
		/// <param name="p_blnVerify">�Ƿ������֤ true=��Ҫ false=����Ҫ</param>
		public void m_mthBindEmployeeSign(Control p_ctlCall,Control p_ctlTarget,int p_intType,bool p_blnVerify)
		{
            clsCommonUseTool objTool = new clsCommonUseTool();
            objTool.m_BlnIsShowLevel = m_blnIsShowLevel;
            objTool.m_mthBindEmployeeSign(p_ctlCall, p_ctlTarget, p_intType, p_blnVerify);
		}
        /// <summary>
        /// ��ǩ������ֵǩ��
        /// ����Ա���������ҵ�ǩ������
        /// </summary>
        /// <param name="p_ctlCall">��ť�ؼ� ͨ��PinkieControls</param>
        /// <param name="p_ctlTarget">ǩ�����ܿؼ� ͨ��textbox��listview</param>
        /// <param name="p_intType">ǩ���б�����ͣ�1Ϊҽ��ǩ����2Ϊ��ʿǩ��</param>
        /// <param name="p_blnVerify">�Ƿ������֤ true=��Ҫ false=����Ҫ</param>
        /// <param name="p_employeeID">Ա��ID</param>
        public void m_mthBindEmployeeSign(Control p_ctlCall, Control p_ctlTarget, int p_intType, bool p_blnVerify,string p_employeeID)
        {
            clsCommonUseTool objTool = new clsCommonUseTool();
            objTool.m_BlnIsShowLevel = m_blnIsShowLevel;
            objTool.m_mthBindEmployeeSign(p_ctlCall, p_ctlTarget, p_intType, p_blnVerify, p_employeeID);
        }

        /// <summary>
        /// ��ǩ������ֵǩ��
        /// ����Ա���������ҵ�ǩ������
        /// </summary>
        /// <param name="p_ctlCall">��ť�ؼ� ͨ��PinkieControls</param>
        /// <param name="p_ctlTarget">ǩ�����ܿؼ� ͨ��textbox��listview</param>
        /// <param name="p_intType">ǩ���б�����ͣ�1Ϊҽ��ǩ����2Ϊ��ʿǩ��</param>
        /// <param name="p_blnVerify">�Ƿ������֤ true=��Ҫ false=����Ҫ</param>
        /// <param name="p_employeeID">Ա��ID</param>
        /// <param name="p_blnIsorNoneShowLevel">�Ƿ���ʾְ��:0ͨ�������������ã�1��ʾ��2����ʾ</param>
        public void m_mthBindEmployeeSign(Control p_ctlCall, Control p_ctlTarget, int p_intType, bool p_blnVerify, string p_employeeID, int p_intIsorNoneShowLevel)
        {
            clsCommonUseTool objTool = new clsCommonUseTool();
            if (p_intIsorNoneShowLevel == 1)
            {
                objTool.m_BlnIsShowLevel = true;
            }
            else if (p_intIsorNoneShowLevel == 2)
            {
                objTool.m_BlnIsShowLevel = false;
            }
            else
            {
                objTool.m_BlnIsShowLevel = m_blnIsShowLevel;
            }
            objTool.m_mthBindEmployeeSign(p_ctlCall, p_ctlTarget, p_intType, p_blnVerify, p_employeeID);
        }
        /// <summary>
        /// ��ǩ������ֵǩ��
        /// ����Ա���������ҵ�ǩ������
        /// </summary>
        /// <param name="p_ctlCall">��ť�ؼ� ͨ��PinkieControls</param>
        /// <param name="p_ctlTarget">ǩ�����ܿؼ� ͨ��textbox��listview</param>
        /// <param name="p_intType">ǩ���б�����ͣ�1Ϊҽ��ǩ����2Ϊ��ʿǩ��</param>
        /// <param name="p_blnVerify">�Ƿ������֤ true=��Ҫ false=����Ҫ</param>
        /// <param name="p_employeeID">Ա��ID</param>
        /// <param name="p_blnIsMultiSignAndNoTag">�Ƿ������Ӷ��ǩ��������ֻ�������ƣ�������ID�� true=�� false=��</param>
        public void m_mthBindEmployeeSign(Control p_ctlCall, Control p_ctlTarget, int p_intType, bool p_blnVerify, string p_employeeID, bool p_blnIsMultiSignAndNoTag)
        {
            p_ctlCall.Tag = p_blnIsMultiSignAndNoTag;
            clsCommonUseTool objTool = new clsCommonUseTool();
            objTool.m_BlnIsShowLevel = m_blnIsShowLevel;
            objTool.m_mthBindEmployeeSign(p_ctlCall, p_ctlTarget, p_intType, p_blnVerify, p_employeeID);
        }
		/// <summary>
		/// ��ǩ������ֵǩ��
		/// ���鴫��
		/// </summary>
		/// <param name="p_ctlCallArr">��ť�ؼ� ͨ��PinkieControls</param>
		/// <param name="p_ctlTargetArr">ǩ�����ܿؼ� ͨ��textbox��listview</param>
		/// <param name="p_intTypeArr">ǩ���б�����ͣ�1Ϊҽ��ǩ����2Ϊ��ʿǩ��</param>
		/// <param name="p_blnVerify">�Ƿ������֤ true=��Ҫ false=����Ҫ</param>
		public void m_mthBindEmployeeSign(Control[] p_ctlCallArr,Control[] p_ctlTargetArr,int[] p_intTypeArr,bool[] p_blnVerifyArr)
		{
			if(p_ctlCallArr != null && p_ctlCallArr.Length > 0)
			{
                clsCommonUseTool objTool;
                for (int i = 0; i < p_ctlCallArr.Length; i++)
                {
                    objTool = new clsCommonUseTool();
                    objTool.m_BlnIsShowLevel = m_blnIsShowLevel;
                    objTool.m_mthBindEmployeeSign(p_ctlCallArr[i], p_ctlTargetArr[i], p_intTypeArr[i], p_blnVerifyArr[i]);
                }
			}
		}
		/// <summary>
		/// ���ض�����ǩ������ֵǩ��
		/// </summary>
        /// <param name="p_ctlCall">��ť�ؼ� ͨ��PinkieControls</param>
        /// <param name="p_ctlTarget">ǩ�����ܿؼ� ͨ��textbox��listview</param>
        /// <param name="p_intType">ǩ���б�����ͣ�1Ϊҽ��ǩ����2Ϊ��ʿǩ��</param>
		/// <param name="p_strDeptID">����ID</param>
		/// <param name="p_blnVerify">�Ƿ������֤ true=��Ҫ false=����Ҫ</param>
		public void m_mthBindEmployeeSign(Control p_ctlCall,Control p_ctlTarget,int p_intType,string p_strDeptID,bool p_blnVerify)
		{
            clsCommonUseTool objTool = new clsCommonUseTool();
            objTool.m_BlnIsShowLevel = m_blnIsShowLevel;
            objTool.m_mthBindEmployeeSign(p_ctlCall, p_ctlTarget, p_intType, p_strDeptID, p_blnVerify);
		}
		/// <summary>
		/// ���ض�����ǩ������ֵǩ��
		/// ���鴫��
		/// </summary>
		/// <param name="p_ctlCallArr">��ť�ؼ� ͨ��PinkieControls</param>
		/// <param name="p_ctlTargetArr">ǩ�����ܿؼ� ͨ��textbox��listview</param>
		/// <param name="p_intTypeArr">ǩ���б�����ͣ�1Ϊҽ��ǩ����2Ϊ��ʿǩ��</param>
		/// <param name="p_strDeptID">����ID</param>
		/// <param name="p_blnVerify">�Ƿ������֤ true=��Ҫ false=����Ҫ</param>
		public void m_mthBindEmployeeSign(Control[] p_ctlCallArr,Control[] p_ctlTargetArr,int[] p_intTypeArr,string[] p_strDeptIDArr,bool[] p_blnVerifyArr)
		{
			if(p_ctlCallArr != null && p_ctlCallArr.Length > 0)
			{
                clsCommonUseTool objTool;
                for (int i = 0; i < p_ctlCallArr.Length; i++)
                {
                    objTool = new clsCommonUseTool();
                    objTool.m_BlnIsShowLevel = m_blnIsShowLevel;
                    objTool.m_mthBindEmployeeSign(p_ctlCallArr[i], p_ctlTargetArr[i], p_intTypeArr[i], p_strDeptIDArr[i], p_blnVerifyArr[i]);
                }
			}
		}
		#endregion

	}
}
