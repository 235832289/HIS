
using System; 
using System.IO; 
using System.Runtime.InteropServices; 
using System.Text;

namespace iCare
{
	/// <summary>
	/// IniFile 的摘要说明。
	/// </summary>
	public class clsIniFile
	{ 

		private string FFileName; 

		[DllImport("kernel32")] 
		private static extern int GetPrivateProfileInt( 
			string lpAppName, 
			string lpKeyName, 
			int nDefault, 
			string lpFileName 
			); 
		[DllImport("kernel32")] 
		private static extern int GetPrivateProfileString( 
			string lpAppName, 
			string lpKeyName, 
			string lpDefault, 
			StringBuilder lpReturnedString, 
			int nSize, 
			string lpFileName 
			); 
		[DllImport("kernel32")] 
		private static extern bool WritePrivateProfileString( 
			string lpAppName, 
			string lpKeyName, 
			string lpString, 
			string lpFileName 
			); 

		public clsIniFile(string filename) 
		{ 
			FFileName = filename; 
		} 
		public int ReadInt(string section,string key,int intDefault) 
		{ 
			return GetPrivateProfileInt(section,key,intDefault,FFileName); 
		} 
		public string ReadString(string section,string key,string strDefault) 
		{ 
			StringBuilder temp = new StringBuilder(1024); 
			GetPrivateProfileString(section,key,strDefault,temp,1024,FFileName); 
			return temp.ToString(); 
		} 
		public void WriteInt(string section,string key,int iVal) 
		{ 
			WritePrivateProfileString(section,key,iVal.ToString(),FFileName); 
		} 
		public void WriteString(string section,string key,string strVal) 
		{ 
			WritePrivateProfileString(section,key,strVal,FFileName); 
		} 
		public void DelKey(string section,string key) 
		{ 
			WritePrivateProfileString(section,key,null,FFileName); 
		} 
		public void DelSection(string section) 
		{ 
			WritePrivateProfileString(section,null,null,FFileName); 
		} 

	} 
}

 
