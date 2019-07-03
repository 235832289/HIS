using System;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace iCare
{
	/// <summary>
	/// clsPreviewPrintControllerFile 的摘要说明。
	/// 通过GetPreviewPageInfo获取页面图片保存于Arraylist中，序列化保存到文件
	/// </summary>
	public class clsPreviewPrintControllerFile: PreviewPrintController
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public clsPreviewPrintControllerFile()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private ImageFormat _Format = null;
		private float _Scale = 1f;
		private long _Quality = 100L;
		private string _Output = String.Empty;
		private bool blnToFile=false;
		private ImageCodecInfo _Codec = null;
		private int _Page = 0;
		private Metafile _Metafile = null;
		private ArrayList arlImage;
		private ArrayList ArlImage1;
		public  ArrayList m_arlImage
		{
			get
			{
				return ArlImage1;
			}
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="format"></param>
		/// <param name="scale"></param>
		/// <param name="quality"></param>
		/// <param name="output"></param>
		public clsPreviewPrintControllerFile(ImageFormat format,  float scale, long quality, string output,bool blnFile )
		{
			if ( quality <   0 ) throw new ArgumentOutOfRangeException( "quality", quality, "Quality must be between 0 and 100" );
			if ( quality > 100 ) throw new ArgumentOutOfRangeException( "quality", quality, "Quality must be between 0 and 100" );
			_Format = format;
			_Scale = scale;
			_Quality = quality;
			_Output = output;
			blnToFile=blnFile;
 
			_Codec = PrintControllerFormat.GetImageCodecInfo( _Format );

			if (blnToFile)//生成文件，解析路径
			{
				string dir = Path.GetDirectoryName( _Output );
				if ( dir.Length > 0 )
					if ( ! Directory.Exists( dir ) )
						Directory.CreateDirectory( dir );
			}
 
			arlImage=new ArrayList();
			ArlImage1=new ArrayList();
		}
		/// <summary>
		/// OnStartPage事件获取页面数
		/// </summary>
		/// <param name="document"></param>
		/// <param name="e"></param>
		/// <returns></returns>
		public override Graphics OnStartPage( PrintDocument document, PrintPageEventArgs e )
		{
			_Page++;

			return base.OnStartPage( document, e );
		}
 
		/// <summary>
		/// OnEndPrint事件保存到文件
		/// </summary>
		/// <param name="document"></param>
		/// <param name="e"></param>
		public override void OnEndPrint(PrintDocument document, PrintEventArgs e)
		{
			base.OnEndPrint (document, e);
			if (blnToFile)
			{
				Stream stream = new FileStream(_Output,FileMode.Create,FileAccess.Write,FileShare.None); 
				BinaryFormatter f = new BinaryFormatter(); 
				f.Serialize(stream,arlImage); 
				stream.Close(); 

			}


		}
		/// <summary>
		/// OnEndPage事件获取每一张页面保存到image对象
		/// </summary>
		/// <param name="document"></param>
		/// <param name="e"></param>
		public override void OnEndPage( PrintDocument document, PrintPageEventArgs e )
		{
			e.Graphics.SmoothingMode=System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			base.OnEndPage( document, e );

			// Get the current Metafile
			PreviewPageInfo[] ppia = GetPreviewPageInfo();
			PreviewPageInfo ppi = ppia[ ppia.Length - 1 ];
			Image image = ppi.Image;
			ArlImage1.Add(image);
			_Metafile = ( Metafile ) image;
			//生成文件
			if (blnToFile)
			{
				if ( _Format == ImageFormat.Emf ) { _Metafile.Save( PagePath, _Format ); return; }
				if ( _Format == ImageFormat.Wmf ) { _Metafile.Save( PagePath, _Format ); return; }

 				SaveViaBitmap( document, e );
   	
			}

		}
		protected string PagePath
		{
			get
			{
				return _Output + "." + _Page.ToString( "000" ) + Extension;
			}
		}

		protected string Extension
		{
			get
			{
				if ( _Format == ImageFormat.Emf ) return ".emf";
				if ( _Format == ImageFormat.Wmf ) return ".wmf";

				if ( _Codec == null ) return ".unknown";

				string[] extensions = _Codec.FilenameExtension.Split( new char[] { ';' } );
				if ( extensions     .Length < 1 ) { Debug.Assert( false ); return ".unknown"; }
				if ( extensions[ 0 ].Length < 1 ) { Debug.Assert( false ); return ".unknown"; }

				string extension = extensions[ 0 ].Substring( 1 );
					
				return extension.ToLower();
			}
		}

		protected void SaveViaBitmap( PrintDocument document, PrintPageEventArgs e )
		{
			int width  = e.PageBounds.Width  ;
			int height = e.PageBounds.Height ;

			using ( Bitmap bitmap = new Bitmap( ( int ) ( width * _Scale ), ( int ) ( height * _Scale ) ) )
			using ( Graphics graphics = Graphics.FromImage( bitmap ) )
			{
				graphics.Clear( Color.White );

				if ( _Scale != 1 ) graphics.ScaleTransform( _Scale, _Scale );

				Point point = new Point( 0, 0 );
				Graphics.EnumerateMetafileProc callback = new Graphics.EnumerateMetafileProc( PlayRecord );
  
				graphics.EnumerateMetafile( _Metafile, point, callback );

				if ( _Scale == 1 || true )
					Save( bitmap );
				else
				{
					using ( Bitmap bitmap2 = new Bitmap( width, height ) )
					using ( Graphics graphics2 = Graphics.FromImage( bitmap2 ) )
					{
						graphics2.DrawImage( bitmap, 0, 0, width, height );

						Save( bitmap2 );
					}
				}
			}
		}

		protected bool PlayRecord(
			EmfPlusRecordType recordType,
			int flags,
			int dataSize,
			IntPtr data,
			PlayRecordCallback callbackData )
		{  
			byte[] dataArray = null;
			if ( data != IntPtr.Zero )
			{
				// Copy the unmanaged record to a managed byte buffer 
				// that can be used by PlayRecord.
				dataArray = new byte[ dataSize ];
				Marshal.Copy( data, dataArray, 0, dataSize );
			}
      
			_Metafile.PlayRecord( recordType, flags, dataSize, dataArray );
            
			return true;
		}

		protected void Save( Bitmap bitmap )
		{
			if ( _Format == ImageFormat.Jpeg )
			{
				EncoderParameters parameters = new EncoderParameters( 1 );
				EncoderParameter parameter = new EncoderParameter( Encoder.Quality, _Quality );
				parameters.Param[ 0 ] = parameter;

//				bitmap.Save( PagePath, _Codec, parameters );
				MemoryStream ms = new MemoryStream();
				bitmap.Save( ms, _Codec, parameters );
				byte[] fileByteArray = ms.ToArray();
				arlImage.Add(fileByteArray);
				return;
			}

			bitmap.Save( PagePath, _Format );
		}
  
	}
	public  class PrintControllerFormat
	{
		private string _Name = String.Empty;
		private ImageFormat _Format = null;
		private ImageCodecInfo _Codec = null;

		public string Name { get { return _Name; } }
		public ImageFormat Format { get { return _Format; } }
		public ImageCodecInfo Codec { get { return _Codec; } }
	

		private PrintControllerFormat() {}

		public static PrintControllerFormat[] Formats
		{
			get
			{
				ArrayList a = new ArrayList();

				Type type = typeof ( ImageFormat );
				PropertyInfo[] properties = type.GetProperties( BindingFlags.Public | BindingFlags.Static );

				foreach ( PropertyInfo property in properties )
					if ( property.PropertyType == type )
					{
						PrintControllerFormat format = new PrintControllerFormat();
						format._Name = property.Name;
						format._Format = ( ImageFormat ) property.GetValue( null, null );
						format._Codec = GetImageCodecInfo( format._Format );
						a.Add( format );
					}

				PrintControllerFormat[] formats = new PrintControllerFormat[ a.Count ];
				a.CopyTo( formats );

				return formats;
			}
		}

		public static ImageCodecInfo GetImageCodecInfo( ImageFormat format )
		{
			ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

			foreach ( ImageCodecInfo codec in codecs )
				if ( codec.FormatID == format.Guid )
					return codec;

			return null;
		}
	}

}
