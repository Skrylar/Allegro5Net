/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 9/30/2011
 * Time: 5:40 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.InteropServices;
using DisplayHandle = System.IntPtr;

/* Type: ALLEGRO_DISPLAY
 * 
 * "Handle" is because its a pointer to an opaque type, and we don't
 * want it conflicting with our C# wrapper.
 */


namespace Allegro5Net
{
	public partial class Display : IDisposable, IALEventSource
	{
		protected string mTitle;
		
		public static Display Create(int w, int h)
		{
			Display self = new Display();
			self.mHandle = AL5.Display.al_create_display(w, h);
			if (self.mHandle == IntPtr.Zero) return null;
			return self;
		}
		
		protected Display() {}
		
		/// <summary>
		/// Sets this display's backbuffer as the draw target.  This means all
		/// drawing and flipping operations will affect this display.
		/// </summary>
		/// <remarks>
		/// To use multiple displays, make the display you wish to update
		/// the target before drawing and flip it.  Repeat this for each
		/// display you need to update.
		/// </remarks>
		public void BecomeTarget()
		{
			AL5.Display.al_set_target_backbuffer(mHandle);
		}
		
		public Point2D Position
		{
			set
			{
				AL5.Display.al_set_window_position(mHandle, value.X, value.Y);
			}
			get
			{
				int x = 0, y = 0;
				AL5.Display.al_get_window_position(mHandle, ref x, ref y);
				return new Point2D(x, y);
			}
		}
		
		/// <summary>
		/// Title shown at the top of this display (when in windowed mode.)
		/// </summary>
		public string Title
		{
			set
			{
				mTitle = value;
				AL5.Display.al_set_window_title(mHandle, value);
			}
			get
			{
				return mTitle;
			}
		}
		
		/// <summary>
		/// Whether deferred drawing is enabled or not.
		/// </summary>
		public static bool DrawingHeld
		{
			get
			{
				return AL5.Display.al_is_bitmap_drawing_held();
			}
			set
			{
				AL5.Display.al_hold_bitmap_drawing(value);
			}
		}
		
		public IntPtr RawEventSource
		{
			get
			{
				return AL5.Display.al_get_display_event_source(mHandle);
			}
		}
	}
}
