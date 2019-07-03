using System;
using System.Windows.Forms;
using iCareData;

namespace iCare
{
	public class clsCommonUseToolCollection
	{
		private Form m_frmParent;

		public clsCommonUseToolCollection(Form p_frmParent)
		{
			m_frmParent = p_frmParent;
		}

		public void m_mthBindControl(Control p_ctlCall,Control p_ctlTarget,enmCommonUseValue p_enm)
		{
			new clsCommonUseTool(m_frmParent).m_mthBindControl(p_ctlCall,p_ctlTarget,p_enm);
		}

		public void m_mthBindEmployeeSign(Control p_ctlCall,Control p_ctlTarget,int p_intType)
		{
			new clsCommonUseTool(m_frmParent).m_mthBindEmployeeSign(p_ctlCall,p_ctlTarget,p_intType);
		}

		public void m_mthBindControl(Control[] p_ctlCallArr,Control[] p_ctlTargetArr,enmCommonUseValue[] p_enmArr)
		{
			if(p_ctlCallArr != null && p_ctlCallArr.Length > 0)
			{
				for(int i = 0; i < p_ctlCallArr.Length; i++)
					new clsCommonUseTool(m_frmParent).m_mthBindControl(p_ctlCallArr[i],p_ctlTargetArr[i],p_enmArr[i]);
			}
		}

		public void m_mthBindEmployeeSign(Control[] p_ctlCallArr,Control[] p_ctlTargetArr,int[] p_intTypeArr)
		{
			if(p_ctlCallArr != null && p_ctlCallArr.Length > 0)
			{
				for(int i = 0; i < p_ctlCallArr.Length; i++)
					new clsCommonUseTool(m_frmParent).m_mthBindEmployeeSign(p_ctlCallArr[i],p_ctlTargetArr[i],p_intTypeArr[i]);
			}
		}
		public void m_mthClear()
		{
			m_frmParent = null;
		}
	}
	
}
