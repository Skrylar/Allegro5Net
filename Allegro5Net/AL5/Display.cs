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

/* Type: ALLEGRO_DISPLAY
 * 
 * "Handle" is because its a pointer to an opaque type, and we don't
 * want it conflicting with our C# wrapper.
 */
using DisplayHandle = System.IntPtr;
using EventSourceHandle = System.IntPtr;

namespace Allegro5Net.AL5
{
	public unsafe class Display
	{
		public const string LIBRARY = "allegro-5.0.dll";

		/* Possible bit combinations for the flags parameter of al_create_display. */
		public enum DisplayFlag : int
		{
			Windowed                    = 1 << 0,
			Fullscreen                  = 1 << 1,
			OpenGL                      = 1 << 2,
			Direct3dInternal            = 1 << 3,
			Resizable                   = 1 << 4,
			Noframe                     = 1 << 5,
			GenerateExposeEvents        = 1 << 6,
			Opengl_3_0                  = 1 << 7,
			OpenglForwardCompatible     = 1 << 8,
			FullscreenWindow            = 1 << 9,
			Minimized                   = 1 << 10
		}

		/* Possible parameters for al_set_display_option.
		 * Make sure to update ALLEGRO_EXTRA_DISPLAY_SETTINGS if you modify
		 * anything here.
		 */
		public enum DisplayOption : int
		{
			RedSize,
			GreenSize,
			BlueSize,
			AlphaSize,
			RedShift,
			GreenShift,
			BlueShift,
			AlphaShift,
			AccRedSize,
			AccGreenSize,
			AccBlueSize,
			AccAlphaSize,
			Stereo,
			AuxBuffers,
			ColorSize,
			DepthSize,
			StencilSize,
			SampleBuffers,
			Samples,
			RenderMethod,
			FloatColor,
			FloatDepth,
			SingleBuffer,
			SwapMethod,
			CompatibleDisplay,
			UpdateDisplayRegion,
			Vsync,
			MaxBitmapSize,
			SupportNpotBitmap,
			CanDrawIntoBitmap,
			SupportSeparateAlpha,
			DisplayOptionsCount
		};

		public enum Importance : int
		{
		   DontCare,
		   Require,
		   Suggest
		}

		public enum DisplayOrientation : int
		{
			Rotate_0_Degrees,
			Rotate_90_Degrees,
			Rotate_180_Degrees,
			Rotate_270_Degrees,
			FaceUp,
			FaceDown
		}

		/* Type: ALLEGRO_DISPLAY
		 */
		[StructLayout(LayoutKind.Sequential)]
		public struct DisplayMode
		{
		   public int Width;
		   public int Height;
		   public int Format;
		   public int RefreshRate;
		}

		/* Type: ALLEGRO_MONITOR_INFO
		 */
		[StructLayout(LayoutKind.Sequential)]
		public struct MonitorInfo
		{
		   public int X1;
		   public int Y1;
		   public int X2;
		   public int Y2;
		}

		/*enum {
		   ALLEGRO_DEFAULT_DISPLAY_ADAPTER = -1
		};*/

		[DllImport(LIBRARY, EntryPoint="al_set_new_display_refresh_rate",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_set_new_display_refresh_rate(int refresh_rate);
		[DllImport(LIBRARY, EntryPoint="al_set_new_display_flags",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_set_new_display_flags(int flags);
		[DllImport(LIBRARY, EntryPoint="al_get_new_display_refresh_rate",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int  al_get_new_display_refresh_rate();
		[DllImport(LIBRARY, EntryPoint="al_get_new_display_flags",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int  al_get_new_display_flags();

		[DllImport(LIBRARY, EntryPoint="al_get_display_width",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_display_width (DisplayHandle display);
		[DllImport(LIBRARY, EntryPoint="al_get_display_height",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_display_height(DisplayHandle display);
		[DllImport(LIBRARY, EntryPoint="al_get_display_format",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_display_format(DisplayHandle display);
		[DllImport(LIBRARY, EntryPoint="al_get_display_refresh_rate",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_display_refresh_rate(DisplayHandle display);
		[DllImport(LIBRARY, EntryPoint="al_get_display_flags",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_display_flags (DisplayHandle display);
		[DllImport(LIBRARY, EntryPoint="al_toggle_display_flag",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_toggle_display_flag(DisplayHandle display, int flag, bool onoff);

		[DllImport(LIBRARY, EntryPoint="al_create_display",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern DisplayHandle al_create_display (int w, int h);
		[DllImport(LIBRARY, EntryPoint="al_destroy_display",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void             al_destroy_display(DisplayHandle display);
		[DllImport(LIBRARY, EntryPoint="al_get_current_display",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern DisplayHandle al_get_current_display ();
		[DllImport(LIBRARY, EntryPoint="al_set_target_bitmap",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void            al_set_target_bitmap(DisplayHandle bitmap);
		[DllImport(LIBRARY, EntryPoint="al_set_target_backbuffer",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void            al_set_target_backbuffer(DisplayHandle display);
		// static extern public ALLEGRO_BITMAP, al_get_backbuffe    (ALLEGRO_DISPLAY *display);
		// static extern public ALLEGRO_BITMAP, al_get_target_bitma ();

		[DllImport(LIBRARY, EntryPoint="al_acknowledge_resize",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_acknowledge_resize(DisplayHandle display);
		[DllImport(LIBRARY, EntryPoint="al_resize_display",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_resize_display    (DisplayHandle display, int width, int height);
		[DllImport(LIBRARY, EntryPoint="al_flip_display",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_flip_display      ();
		[DllImport(LIBRARY, EntryPoint="al_update_display_region",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_update_display_region(int x, int y, int width, int height);
		// static extern public bool al_is_compatible_bitmap(ALLEGRO_BITMAP *bitmap);

		[DllImport(LIBRARY, EntryPoint="al_get_num_display_modes",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_num_display_modes();
		// AL_FUNC(ALLEGRO_DISPLAY_MODE*, al_get_display_mode, (int index,
		//        ALLEGRO_DISPLAY_MODE *mode));

		[DllImport(LIBRARY, EntryPoint="al_wait_for_vsync",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_wait_for_vsync();

		// static extern public ALLEGRO_EVENT_SOURCE al_get_display_event_source (DisplayHandle display);
		[DllImport(LIBRARY, EntryPoint="al_get_display_event_source",
		           CallingConvention=CallingConvention.Cdecl)]
		public static extern EventSourceHandle al_get_display_event_source(DisplayHandle display);
		
		/* Primitives */
		[DllImport(LIBRARY, EntryPoint="al_clear_to_color",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_clear_to_color(Color color);
		//[DllImport(LIBRARY, EntryPoint="al_draw_pixel",
		//	CallingConvention=CallingConvention.Cdecl)]
		//public static extern void al_draw_pixel(float x, float y, ALLEGRO_COLOR color);

		// static extern public void al_set_display_icon(DisplayHandle display, ALLEGRO_BITMAP *icon);

		/* Stuff for multihead/window management */
		[DllImport(LIBRARY, EntryPoint="al_get_num_video_adapters",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_num_video_adapters();
		[DllImport(LIBRARY, EntryPoint="al_get_monitor_info",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_get_monitor_info(int adapter, MonitorInfo *info);
		[DllImport(LIBRARY, EntryPoint="al_get_new_display_adapter",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_new_display_adapter();
		[DllImport(LIBRARY, EntryPoint="al_set_new_display_adapter",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_set_new_display_adapter(int adapter);
		[DllImport(LIBRARY, EntryPoint="al_set_new_window_position",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_set_new_window_position(int x, int y);
		[DllImport(LIBRARY, EntryPoint="al_get_new_window_position",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_get_new_window_position(int *x, int *y);
		[DllImport(LIBRARY, EntryPoint="al_set_window_position",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_set_window_position(DisplayHandle display, int x, int y);
		[DllImport(LIBRARY, EntryPoint="al_get_window_position",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_get_window_position(DisplayHandle display, ref int x, ref int y);

		[DllImport(LIBRARY, EntryPoint="al_set_window_title",
			CallingConvention=CallingConvention.Cdecl,
			CharSet=CharSet.Unicode)]
		public static extern void al_set_window_title(DisplayHandle display,
			[MarshalAs(UnmanagedType.LPStr)] string title);

		/* Defined in display_settings.c */
		[DllImport(LIBRARY, EntryPoint="al_set_new_display_option",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_set_new_display_option(int option, int value, Importance importance);
		[DllImport(LIBRARY, EntryPoint="al_get_new_display_option",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_new_display_option(int option, Importance *importance);
		[DllImport(LIBRARY, EntryPoint="al_reset_new_display_options",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_reset_new_display_options();
		[DllImport(LIBRARY, EntryPoint="al_get_display_option",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_display_option(DisplayHandle display, int option);

		/*Deferred drawing*/
		[DllImport(LIBRARY, EntryPoint="al_hold_bitmap_drawing",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_hold_bitmap_drawing(bool hold);
		[DllImport(LIBRARY, EntryPoint="al_is_bitmap_drawing_held",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_is_bitmap_drawing_held();
	}
}
