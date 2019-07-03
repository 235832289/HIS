using System;
using System.Xml;
using com.digitalwave.StatisticsService ;
using System.IO;
using System.Text;
using iCareData;
using System.Windows.Forms ;
namespace iCare
{
	/// <summary>
	/// Summary description for clsIntelligentStatisticsDomain.
	/// </summary>
	public class clsIntelligentStatisticsDomain
	{
		/// <summary>
		/// 查询条件项目的默认值
		/// </summary>
		private const string c_strItemIsUse = "IsUse";

		public clsIntelligentStatisticsDomain()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#region 成员变量,刘颖源,2003-7-11 11:04:18
		static string s_strUserCondictionSQL = "";
		static string s_strFixedSystemSQL="";
		static string s_strXmlStruction="";
		static string s_strDeepSpace="";
		static TreeNode m_objTreeNode=null;
        //clsStatisticsService m_objService=new clsStatisticsService();
		#endregion

		#region 递归获得SQL语句,刘颖源,2003-7-11 11:05:11
		static bool m_blnReadUserCondictionSQL(XmlNode p_objNode)
		{
			if(p_objNode ==null)
			{
				return false;
			}
			if(p_objNode.Name == "UserCondiction"  )
			{
				if( p_objNode.HasChildNodes)
					m_blnReadUserCondictionSQL(p_objNode.ChildNodes[0]);
				return true;
			}
			if(p_objNode.Name =="Item")
			{
				try
				{
					if(!bool.Parse(p_objNode.Attributes[c_strItemIsUse].Value))
						return false;
				}
				catch
				{
				}

				s_strUserCondictionSQL += p_objNode.Attributes["OPTIONNAME"].Value + " " + p_objNode.Attributes["SYMBOL"].Value + " " + p_objNode.Attributes["DEFAULTVALUE"].Value + " ";
				return true;
			}

			s_strUserCondictionSQL += "(";

			string strSymbol = p_objNode.Attributes["SYMBOL"].Value;
			//添加此语句来支持选项的选择使用
			if(strSymbol == "or")
			{
				s_strUserCondictionSQL += " 1!=1 or ";
			}
			else
			{
				s_strUserCondictionSQL += " 1==1 and ";
			}

			for(int i=0;i<p_objNode.ChildNodes.Count;i++)
			{
				if(m_blnReadUserCondictionSQL(p_objNode.ChildNodes[i]))
				{
						s_strUserCondictionSQL += " "+strSymbol +" ";				
				}
			}

			//添加此语句来支持选项的选择使用
			if(strSymbol == "or")
			{
				s_strUserCondictionSQL += " 1!=1";
			}
			else
			{
				s_strUserCondictionSQL += " 1==1";
			}

			s_strUserCondictionSQL += ")";

			return true;
		}
		
		static void m_mthReadFixedSystemSQL(XmlNode p_objNode)
		{
			if(p_objNode ==null)
				return;
			if(p_objNode.Name == "FixedSystems"  )
			{
				if( p_objNode.HasChildNodes)
					m_mthReadFixedSystemSQL(p_objNode.ChildNodes[0]);
				return;
			}
			if(p_objNode.Name =="Item")
			{
				s_strFixedSystemSQL += p_objNode.Attributes["OPTIONNAME"].Value + " " + p_objNode.Attributes["SYMBOL"].Value+ " " +p_objNode.Attributes["DEFAULTVALUE"].Value + " ";
				return;
			}

			s_strFixedSystemSQL += "(";

			string strSymbol = p_objNode.Attributes["SYMBOL"].Value;
			for(int i=0;i<p_objNode.ChildNodes.Count;i++)
			{
				m_mthReadFixedSystemSQL(p_objNode.ChildNodes[i]);

				if(i+1 < p_objNode.ChildNodes.Count)
				{
					s_strFixedSystemSQL += " "+strSymbol +" ";
				}
			}

			s_strFixedSystemSQL += ")";
		}
		
		#endregion

		/// <summary>
		/// 执行SQL查询
		/// </summary>
		/// <param name="p_strStatisticSqlTemplate">Sql语句模板的String 格式:Select [SelectedFields] from T1,T2 Where [FixedSystems] and [UserCondiction]</param>
		/// <param name="p_strSelectedFields">用户选择实际显示的字段</param>
		/// <param name="p_strXmlWhereStruction">Where语句的XML结构,包含FixedSystems和UserCondiction</param>
		/// <param name="p_strRowValues">返回二维String数组</param>
		/// <returns></returns>
		public long m_lngPerformSqlQuery(string p_strStatisticSqlTemplate,string p_strOpenClassParameters, string p_strSelectedFields,string p_strXmlWhereStruction,out string [,] p_strRowValues)
		{
			XmlDocument objXmlDocment = new XmlDocument();
			objXmlDocment.LoadXml(p_strXmlWhereStruction);
			
			return m_lngPerformSqlQuery(p_strStatisticSqlTemplate,p_strOpenClassParameters,p_strSelectedFields,objXmlDocment,out p_strRowValues);
		}

		/// <summary>
		/// 执行SQL查询
		/// </summary>
		/// <param name="p_strStatisticSqlTemplate">Sql语句模板的String 格式:Select [SelectedFields] from T1,T2 Where [FixedSystems] and [UserCondiction]</param>
		/// <param name="p_strSelectedFields">用户选择实际显示的字段</param>
		/// <param name="p_strXmlWhereStruction">Where语句的XML结构,包含FixedSystems和UserCondiction</param>
		/// <param name="p_strRowValues">返回二维String数组</param>
		/// <returns></returns>
		public long m_lngPerformSqlQuery(string p_strStatisticSqlTemplate,string p_strOpenClassParameters, string p_strSelectedFields,XmlDocument p_objXmlDocment,out string [,] p_strRowValues)
		{
            clsStatisticsService m_objService =
                (clsStatisticsService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsStatisticsService));

            long lngRes = 0;
            try
            {
                string strSqlStatement = p_strStatisticSqlTemplate;
                strSqlStatement = strSqlStatement.Replace("[SelectedFields]", p_strOpenClassParameters + "," + p_strSelectedFields);
                s_strFixedSystemSQL = "";
                s_strUserCondictionSQL = "";
                m_mthReadFixedSystemSQL(p_objXmlDocment.DocumentElement.ChildNodes[0]);
                m_blnReadUserCondictionSQL(p_objXmlDocment.DocumentElement.ChildNodes[1]);
                strSqlStatement = strSqlStatement.Replace("[FixedSystems]", s_strFixedSystemSQL);
                strSqlStatement = strSqlStatement.Replace("[UserCondiction]", s_strUserCondictionSQL);
                lngRes = (m_objService.m_lngPerformSqlQuery(strSqlStatement, out p_strRowValues));
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;
		}


		public long m_lngGetAllStatisticSelectedField(string p_strStatisticID, out clsStatisticSelectedFieldValue[] p_objStatisticSelectedFieldValue)
		{
            clsStatisticsService m_objService =
                (clsStatisticsService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsStatisticsService));

            long lngRes = 0;
            try
            {
                lngRes = (m_objService.m_lngGetAllStatisticSelectedField(p_strStatisticID, out p_objStatisticSelectedFieldValue));
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;
		}
		public long m_lngGetAllStatisticCCOperator(out clsStatisticCCOperatorValue [] p_objStatisticCCOperatorValue)
		{
            clsStatisticsService m_objService =
                (clsStatisticsService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsStatisticsService));

            long lngRes = 0;
            try
            {
                lngRes =(m_objService.m_lngGetAllStatisticCCOperator(out p_objStatisticCCOperatorValue ));
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;
		}
		public long m_lngGetStatisticCondictionOptionValue(string p_strStatisticID,out clsStatisticCondictionOptionValue [] p_objStatisticCondictionOptionValue)
		{
            clsStatisticsService m_objService =
                (clsStatisticsService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsStatisticsService));

            long lngRes = 0;
            try
            {
                lngRes =(m_objService.m_lngGetStatisticCondictionOptionValue(p_strStatisticID ,out p_objStatisticCondictionOptionValue ));
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;
		}
		public long lngGetStatisticConditionOperatorValue(out clsStatisticConditionOperatorValue [] p_objStatisticConditionOperatorValue)
		{
            clsStatisticsService m_objService =
                (clsStatisticsService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsStatisticsService));

            long lngRes = 0;
            try
            {
                lngRes =(m_objService.lngGetStatisticConditionOperatorValue(out p_objStatisticConditionOperatorValue ));
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;
		}
		public long m_lngGetAllStatisticDefinition(out clsStatisticDefinitionValue [] p_objStatisticDefinitionValue)
		{
            clsStatisticsService m_objService =
                (clsStatisticsService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsStatisticsService));

            long lngRes = 0;
            try
            {
                lngRes =(m_objService.m_lngGetAllStatisticDefinition(out p_objStatisticDefinitionValue ));
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;
		}
		public long m_lngGetStatisticQueryMode(string p_strStatisticID,out clsStatisticQueryModeValue [] p_objStatisticQueryModeValue)
		{
            clsStatisticsService m_objService =
                (clsStatisticsService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsStatisticsService));

            long lngRes = 0;
            try
            {
                lngRes =m_objService.m_lngGetStatisticQueryMode (p_strStatisticID ,out p_objStatisticQueryModeValue );
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;
		}
		public void m_mthLoadXmlStructionToTreeView(string p_strWhereXML,TreeView p_objTree)
		{
			p_objTree.Nodes.Clear ();
			XmlDocument objXmlDocment = new XmlDocument();
			objXmlDocment.LoadXml(p_strWhereXML);
			m_objTreeNode = p_objTree.Nodes.Add ("用户条件");
			m_objTreeNode.Tag ="9";
			m_mthReadUserCondictionToTree(objXmlDocment.DocumentElement.ChildNodes[1],m_objTreeNode );

		}
		public void m_mthLoadTreeViewToXmlStruction(TreeView p_objTree,out string p_strWhereXML)
		{
			p_strWhereXML ="";
			if(p_objTree.Nodes.Count <=0)return;
			s_strXmlStruction="";
			s_strDeepSpace="";
			m_objTreeNode = p_objTree.Nodes[0];
			m_mthReadTreeToUserCondiction(m_objTreeNode );
			p_strWhereXML="<UserCondiction>\r\n" + s_strXmlStruction + "</UserCondiction>";			
		}		
		public long m_lngAddNewStatisticMode(clsStatisticQueryModeValue p_objStatisticQueryModeValue, out string p_strQueryID)
		{
            clsStatisticsService m_objService =
                (clsStatisticsService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsStatisticsService));

            long lngRes = 0;
            try
            {
                lngRes =(m_objService.m_lngAddNewStatisticMode (p_objStatisticQueryModeValue, out p_strQueryID));
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;
		}
		public long m_lngUpdateStatisticMode(string p_strStasticID,string p_strQueryID,string p_strXmlContent,string p_strSelectedFiledsIndexes,string p_strModeDesc)
		{
            clsStatisticsService m_objService =
                (clsStatisticsService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsStatisticsService));

            long lngRes = 0;
            try
            {
                lngRes =(m_objService.m_lngUpdateStatisticMode (p_strStasticID ,p_strQueryID ,p_strXmlContent ,p_strSelectedFiledsIndexes ,p_strModeDesc));
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;
		}
		#region 使用递归把XML结构装入到树中或着把树放入到XML中
		#region 读入到树
		static void m_mthReadUserCondictionToTree(XmlNode p_objNode,TreeNode p_objTreeNode)
		{
			if(p_objNode ==null)
				return;
			if(p_objNode.Name == "UserCondiction"  )
			{
				if( p_objNode.HasChildNodes)
				{
					m_mthReadUserCondictionToTree(p_objNode.ChildNodes[0],p_objTreeNode);
				}
				return;
			}
			//if is Item
			if(p_objNode.Name =="Item")
			{				
				TreeNode objTreeNode= p_objTreeNode.Nodes.Add(p_objNode.Attributes["OPTIONNAME"].Value + " " + p_objNode.Attributes["SYMBOL"].Value + " " + p_objNode.Attributes["DEFAULTVALUE"].Value + " ");
				objTreeNode.Tag =p_objNode.Attributes["OPTIONNAME"].Value + "$" + p_objNode.Attributes["SYMBOL"].Value + "$" + p_objNode.Attributes["DEFAULTVALUE"].Value ; 
				return;
			}

			string strSymbol = p_objNode.Attributes["SYMBOL"].Value;		//condiction symbo
			p_objTreeNode=p_objTreeNode.Nodes.Add (strSymbol); 
			p_objTreeNode.Tag ="1";
			for(int i=0;i<p_objNode.ChildNodes.Count;i++)
			{
				m_mthReadUserCondictionToTree(p_objNode.ChildNodes[i],p_objTreeNode );
			}

		}
		
		#endregion

		static void m_mthReadTreeToUserCondiction(TreeNode p_objTreeNode)
		{
			if(p_objTreeNode ==null)
				return;
			if(p_objTreeNode.Tag.ToString ()  == "9"  )
			{
				if( p_objTreeNode.Nodes.Count >0 )
				{
					m_mthReadTreeToUserCondiction(p_objTreeNode.Nodes[0] );
				}
				return;
			}
			//if is Item
			if(p_objTreeNode.Tag.ToString ().IndexOf ("$")>=0)
			{
				string strItem=p_objTreeNode.Tag.ToString ();
				string [] strItems=strItem.Split ('$');
				if(strItems.Length >=3)
				{
					s_strDeepSpace+="    ";
					s_strXmlStruction=s_strXmlStruction + s_strDeepSpace + "<Item OptionName='" + strItems[0].Trim () +  "' Symbol='" +strItems[1].Trim ()  + "' DefaultValue='" + strItems[2].Trim () +  "' />\r\n";
					if(s_strDeepSpace.Length >4)
						s_strDeepSpace=s_strDeepSpace.Substring (0,s_strDeepSpace.Length -4);
				}
				return;
			}

			string strSymbol = p_objTreeNode.Text  ;		//condiction symbo
			s_strDeepSpace+="    ";
			s_strXmlStruction=s_strXmlStruction + s_strDeepSpace + "<Condiction Symbol='" + strSymbol + "'>\r\n";
			for(int i=0;i<p_objTreeNode.Nodes.Count;i++)
			{
				m_mthReadTreeToUserCondiction(p_objTreeNode.Nodes[i]);
			}
			s_strXmlStruction=s_strXmlStruction  + s_strDeepSpace + "</Condiction>\r\n";
			if(s_strDeepSpace.Length >4)
				s_strDeepSpace=s_strDeepSpace.Substring (0,s_strDeepSpace.Length -4);
		}	
		#endregion

	}
}
