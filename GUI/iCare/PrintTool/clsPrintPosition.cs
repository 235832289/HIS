using System;
using System.Drawing;

namespace iCare
{
	/// <summary>
	/// Õ≥“ª¥Ú”°Œª÷√
	/// </summary>
	public abstract class clsPrintPosition
	{
		public clsPrintPosition()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// ◊Û∂À
		/// </summary>
		public const int c_intLeftX =40;//60;
		/// <summary>
		/// ”“∂À
		/// </summary>
        public const int c_intRightX = 792; //852-60;//827-40;

		public const int c_intHospitalTitleY = 30;
		public const int c_intFormTitleY = 70;
		public const int c_intTopLineY = 130;
		//◊Ó”“±ﬂæ‡
		public const int c_intRightLineX = 790;
		public const int c_intBottomY =1024;// 1080;
		public const int c_intRowStep = 25;

        public const int c_intA3TopLineY = 175;
        public const int c_intA3HospitalTitleY = 85;
        public const int c_intA3TopTitleY = 155;

        public static RectangleF m_rtgHospitalTitlePos
        {
            //get { return new RectangleF(c_intLeftX, c_intA3HospitalTitleY, c_intRightLineX, 30); }
            get { return new RectangleF(c_intLeftX, c_intA3HospitalTitleY, c_intRightX - 40, 30); }
        }

        public static RectangleF m_rtgFormTitlePos
        {
            //get { return new RectangleF(c_intLeftX, c_intA3HospitalTitleY + 30, c_intRightLineX, 40); }
            get { return new RectangleF(c_intLeftX, c_intA3HospitalTitleY+30, c_intRightX - 40, 40); }
        }
	}
}
