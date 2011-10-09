/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 10/8/2011
 * Time: 11:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.InteropServices;

using FontHandle = System.IntPtr;
using UstringHandle = System.IntPtr;
using BitmapHandle = System.IntPtr;
using uint32_t = System.UInt32;

namespace Allegro5Net.AL5
{
	/// <summary>
	/// Description of Font.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Font
	{
		public const string LIBRARY="allegro_font-5.0.dll";
		
		IntPtr data;
		int height;
		unsafe FontVTable *vtable;

		/* text- and font-related stuff */
		[StructLayout(LayoutKind.Sequential)]
		struct FontVTable
		{
			// TODO: Convert this to a proper delegate setup, so we could make font handlers in CIL

		   // ALLEGRO_FONT_METHOD(int, font_height, (const ALLEGRO_FONT *f));
		   private IntPtr font_height;
		   // ALLEGRO_FONT_METHOD(int, font_ascent, (const ALLEGRO_FONT *f));
		   private IntPtr font_ascent;
		   // ALLEGRO_FONT_METHOD(int, font_descent, (const ALLEGRO_FONT *f));
		   private IntPtr font_descent;
		   // ALLEGRO_FONT_METHOD(int, char_length, (const ALLEGRO_FONT *f, int ch));
		   private IntPtr char_length;
		   // ALLEGRO_FONT_METHOD(int, text_length, (const ALLEGRO_FONT *f, const ALLEGRO_USTR *text));
		   private IntPtr text_length;
		   // ALLEGRO_FONT_METHOD(int, render_char, (const ALLEGRO_FONT *f, ALLEGRO_COLOR color, int ch, float x, float y));
		   private IntPtr render_char;
		   // ALLEGRO_FONT_METHOD(int, render, (const ALLEGRO_FONT *f, ALLEGRO_COLOR color, const ALLEGRO_USTR *text, float x, float y));
		   private IntPtr render;
		   // ALLEGRO_FONT_METHOD(void, destroy, (ALLEGRO_FONT *f));
		   private IntPtr destroy;
		   // ALLEGRO_FONT_METHOD(void, get_text_dimensions, (const ALLEGRO_FONT *f, const ALLEGRO_USTR *text, int *bbx, int *bby, int *bbw, int *bbh));
		   private IntPtr get_text_dimensions;
		}

		enum FontAlignment : int
		{
		   Left   = 0,
		   Centre = 1,
		   Right  = 2
		}

		/*[DllImport(LIBRARY, EntryPoint="al_register_font_loader", CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_register_font_loader([MarshalAs(UnmanagedType.LPWStr)] string ext, ALLEGRO_FONT *(*load)(const char *filename, int size, int flags))*/
		[DllImport(LIBRARY, EntryPoint="al_load_bitmap_font", CallingConvention=CallingConvention.Cdecl)]
		public static extern FontHandle al_load_bitmap_font([MarshalAs(UnmanagedType.LPWStr)] string filename);
		[DllImport(LIBRARY, EntryPoint="al_load_font", CallingConvention=CallingConvention.Cdecl)]
		public static extern FontHandle al_load_font([MarshalAs(UnmanagedType.LPWStr)] string filename, int size, int flags);

		/*[DllImport(LIBRARY, EntryPoint="al_grab_font_from_bitmap", CallingConvention=CallingConvention.Cdecl)]
		public static extern FontHandle al_grab_font_from_bitmap(BitmapHandle bmp, int n, int ranges[]);*/

		[DllImport(LIBRARY, EntryPoint="al_draw_ustr", CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_draw_ustr(ref Font font, Color color, float x, float y, int flags, UstringHandle ustr);
		[DllImport(LIBRARY, EntryPoint="al_draw_text", CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_draw_text(ref Font font, Color color, float x, float y, int flags, [MarshalAs(UnmanagedType.LPWStr)] string text);
		[DllImport(LIBRARY, EntryPoint="al_draw_justified_text", CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_draw_justified_text(ref Font font, Color color, float x1, float x2, float y, float diff, int flags, [MarshalAs(UnmanagedType.LPWStr)] string text);
		[DllImport(LIBRARY, EntryPoint="al_draw_justified_ustr", CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_draw_justified_ustr(ref Font font, Color color, float x1, float x2, float y, float diff, int flags, UstringHandle text);
		/*[DllImport(LIBRARY, EntryPoint="al_draw_textf", CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_draw_textf(ref Font font, ALLEGRO_COLOR color, float x, float y, int flags, char const *format, ...);*/
		/*[DllImport(LIBRARY, EntryPoint="al_draw_justified_textf", CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_draw_justified_textf(ref Font font, ALLEGRO_COLOR color, float x1, float x2, float y, float diff, int flags, [MarshalAs(UnmanagedType.LPWStr)] string format, ...);*/
		[DllImport(LIBRARY, EntryPoint="al_get_text_width", CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_text_width(ref Font f, [MarshalAs(UnmanagedType.LPWStr)] string str);
		[DllImport(LIBRARY, EntryPoint="al_get_ustr_width", CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_ustr_width(ref Font f, UstringHandle ustr);
		[DllImport(LIBRARY, EntryPoint="al_get_font_line_height", CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_font_line_height(ref Font f);
		[DllImport(LIBRARY, EntryPoint="al_get_font_ascent", CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_font_ascent(ref Font f);
		[DllImport(LIBRARY, EntryPoint="al_get_font_descent", CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_font_descent(ref Font f);
		[DllImport(LIBRARY, EntryPoint="al_destroy_font", CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_destroy_font(ref Font f);
		[DllImport(LIBRARY, EntryPoint="al_get_ustr_dimensions", CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_get_ustr_dimensions(ref Font f, UstringHandle text, ref int bbx, ref int bby, ref int bbw, ref int bbh);
		[DllImport(LIBRARY, EntryPoint="al_get_text_dimensions", CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_get_text_dimensions(ref Font f, [MarshalAs(UnmanagedType.LPWStr)] string text, ref int bbx, ref int bby, ref int bbw, ref int bbh);
		[DllImport(LIBRARY, EntryPoint="al_init_font_addon", CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_init_font_addon();
		[DllImport(LIBRARY, EntryPoint="al_shutdown_font_addon", CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_shutdown_font_addon();
		[DllImport(LIBRARY, EntryPoint="al_get_allegro_font_version", CallingConvention=CallingConvention.Cdecl)]
		public static extern uint32_t al_get_allegro_font_version();
	}
}
