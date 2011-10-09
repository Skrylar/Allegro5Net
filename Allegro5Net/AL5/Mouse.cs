/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 10/2/2011
 * Time: 5:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.InteropServices;
using MouseHandle = System.IntPtr;
using DisplayHandle = System.IntPtr;
using MouseCursorHandle = System.IntPtr;
using BitmapHandle = System.IntPtr;
using EventSourceHandle = System.IntPtr;

namespace Allegro5Net.AL5
{
	/// <summary>
	/// Description of Mouse.
	/// </summary>
	public static class Mouse
	{
		public const string LIBRARY = "allegro-5.0.dll";
		
		/* Allow up to four extra axes for future expansion. */
		public const int ALLEGRO_MOUSE_MAX_EXTRA_AXES = 4;

		/* Type: ALLEGRO_MOUSE_STATE
		 */
		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct MouseState
		{
		   /* (x, y) Primary mouse position
		    * (z) Mouse wheel position (1D 'wheel'), or,
		    * (w, z) Mouse wheel position (2D 'ball')
		    * display - the display the mouse is on (coordinates are relative to this)
		    * pressure - the pressure appleid to the mouse (for stylus/tablet)
		    */
		   public int x;
		   public int y;
		   public int z;
		   public int w;
		   public fixed int more_axes[ALLEGRO_MOUSE_MAX_EXTRA_AXES];
		   public int buttons;
		   public float pressure;
		   public DisplayHandle display;
		}

		/* Mouse cursors */
		public enum SystemMouseCursor : int
		{
		   None      		=  0,
		   Default   		=  1,
		   Arrow       		=  2,
		   Busy        		=  3,
		   Question    		=  4,
		   Edit        		=  5,
		   Move        		=  6,
		   Resize_North     =  7,
		   Resize_West      =  8,
		   Resize_South     =  9,
		   Resize_East      = 10,
		   Resize_Northwest = 11,
		   Resize_Southwest = 12,
		   Resize_Southeast = 13,
		   Resize_Northeast = 14,
		   Progress   		= 15,
		   Precision  		= 16,
		   Link       		= 17,
		   AltSelect  		= 18,
		   Unavailable		= 19,
		   NUM_SYSTEM_MOUSE_CURSORS
		}

		[DllImport(LIBRARY, EntryPoint="al_is_mouse_installed",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_is_mouse_installed();
		[DllImport(LIBRARY, EntryPoint="al_install_mouse",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_install_mouse();
		[DllImport(LIBRARY, EntryPoint="al_uninstall_mouse",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_uninstall_mouse();
		[DllImport(LIBRARY, EntryPoint="al_get_mouse_num_buttons",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern uint al_get_mouse_num_buttons();
		[DllImport(LIBRARY, EntryPoint="al_get_mouse_num_axes",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern uint al_get_mouse_num_axes();
		[DllImport(LIBRARY, EntryPoint="al_set_mouse_xy",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_set_mouse_xy(DisplayHandle display, int x, int y);
		[DllImport(LIBRARY, EntryPoint="al_set_mouse_z",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_set_mouse_z(int z);
		[DllImport(LIBRARY, EntryPoint="al_set_mouse_w",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_set_mouse_w(int w);
		[DllImport(LIBRARY, EntryPoint="al_set_mouse_axis",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_set_mouse_axis(int axis, int value);
		[DllImport(LIBRARY, EntryPoint="al_get_mouse_state",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_get_mouse_state(ref MouseState ret_state);
		[DllImport(LIBRARY, EntryPoint="al_mouse_button_down",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_mouse_button_down(ref MouseState state, int button);
		[DllImport(LIBRARY, EntryPoint="al_get_mouse_state_axisref",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_mouse_state_axis(ref MouseState state, int axis);

		[DllImport(LIBRARY, EntryPoint="al_get_mouse_event_source",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern EventSourceHandle al_get_mouse_event_source();

		/*
		 * Cursors:
		 *
		 * This will probably become part of the display API.  It provides for
		 * hardware cursors only; software cursors may or may not be provided
		 * for later (it would need significant cooperation from the display
		 * API).
		 */
		[DllImport(LIBRARY, EntryPoint="al_create_mouse_cursor",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern MouseCursorHandle al_create_mouse_cursor(BitmapHandle sprite,
			int xfocus, int yfocus);
		[DllImport(LIBRARY, EntryPoint="al_destroy_mouse_cursor",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_destroy_mouse_cursor(MouseCursorHandle handle);
		[DllImport(LIBRARY, EntryPoint="al_set_mouse_cursor",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_set_mouse_cursor(DisplayHandle display,
		                         MouseCursorHandle cursor);
		[DllImport(LIBRARY, EntryPoint="al_set_system_mouse_cursor",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_set_system_mouse_cursor(DisplayHandle display,
		                                SystemMouseCursor cursor_id);
		[DllImport(LIBRARY, EntryPoint="al_show_mouse_cursor",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_show_mouse_cursor(DisplayHandle display);
		[DllImport(LIBRARY, EntryPoint="al_hide_mouse_cursor",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_hide_mouse_cursor(DisplayHandle display);
		[DllImport(LIBRARY, EntryPoint="al_get_mouse_cursor_position",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_get_mouse_cursor_position(ref int ret_x, ref int ret_y);
		[DllImport(LIBRARY, EntryPoint="al_grab_mouse",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_grab_mouse(DisplayHandle display);
		[DllImport(LIBRARY, EntryPoint="al_ungrab_mouse",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_ungrab_mouse();
	}
}
