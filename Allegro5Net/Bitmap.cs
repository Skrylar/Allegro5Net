/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 10/3/2011
 * Time: 10:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Allegro5Net
{
	/// <summary>
	/// Description of Bitmap.
	/// </summary>
	public partial class Bitmap : IDisposable
	{
		protected Bitmap(IntPtr handle)
		{
			mHandle = handle;
		}
		
		public static Bitmap LoadFromFile(string filename)
		{
			IntPtr handle = AL5.Bitmap.al_load_bitmap(filename);
			if (handle != IntPtr.Zero)
				return new Bitmap(handle);
			else
				return null;
		}
		
		public void Draw(float x, float y)
		{
			AL5.Bitmap.al_draw_bitmap(mHandle, x, y, 0);
		}
		
		public void Draw(Color tint, float x, float y)
		{
			AL5.Bitmap.al_draw_tinted_bitmap(mHandle, tint, x, y, 0);
		}
	}
}
