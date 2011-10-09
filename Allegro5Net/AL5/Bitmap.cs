/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 10/3/2011
 * Time: 7:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.InteropServices;

using BitmapHandle = System.IntPtr;
using AlFileHandle = System.IntPtr;

namespace Allegro5Net.AL5
{
	/// <summary>
	/// Description of Graphics.
	/// </summary>
	public static class Bitmap
	{
		public const string LIBRARY="allegro-5.0.dll";
		
		#region BITMAP_H
		/* Enum: ALLEGRO_PIXEL_FORMAT
		 */
		public enum PixelFormat : int
		{
			ANY = 0,
			ANY_NO_ALPHA,
			ANY_WITH_ALPHA,
			ANY_15_NO_ALPHA,
			ANY_16_NO_ALPHA,
			ANY_16_WITH_ALPHA,
			ANY_24_NO_ALPHA,
			ANY_32_NO_ALPHA,
			ANY_32_WITH_ALPHA,
			ARGB_8888,
			RGBA_8888,
			ARGB_4444,
			RGB_888,	/* 24 bit format */
			RGB_565,
			RGB_555,
			RGBA_5551,
			ARGB_1555,
			ABGR_8888,
			XBGR_8888,
			BGR_888,	/* 24 bit format */
			BGR_565,
			BGR_555,
			RGBX_8888,
			XRGB_8888,
			ABGR_F32,
			ABGR_8888_LE,
			RGBA_4444,
			NUM_PIXEL_FORMATS
		}

		/*
		 * Bitmap flags
		 */
		public enum BitmapFlags : int
		{
			MemoryBitmap            = 0x0001,
			KeepBitmapFormat        = 0x0002,
			ForceLocking            = 0x0004,
			NoPreserveTexture       = 0x0008,
			AlphaTest               = 0x0010,
			_INTERNAL_OPENGL        = 0x0020,
			MinLinear               = 0x0040,
			MagLinear               = 0x0080,
			MipMap                  = 0x0100,
			NoPremultipliedAlpha    = 0x0200,
			VideoBitmap             = 0x0400
		}

		/* Flags for the blitting functions */
		public enum BlitFlag : int
		{
		   FlipHorizontal = 0x00001,
		   FlipVertical   = 0x00002
		}

		/*
		 * Locking flags
		 */
		public enum LockFlag
		{
			ReadWrite  = 0,
			ReadOnly   = 1,
			WriteOnly  = 2
		}

		/*
		 * Blending modes
		 */
		public enum BlendMode : int
		{
			Zero         = 0,
			One          = 1,
			Alpha        = 2,
			InverseAlpha = 3
		}

		public enum BlendOperations : int
		{
			Add = 0,
			SrcMinusDest = 1,
			DestMinusSrc = 2,
			NUM_BLEND_OPERATIONS
		}

		/* Type: ALLEGRO_LOCKED_REGION
		 */
		[StructLayout(LayoutKind.Sequential)]
		public struct LockedRegion
		{
		   public IntPtr data;
		   public int format;
		   public int pitch;
		   public int pixel_size;
		}

		[DllImport(LIBRARY, EntryPoint="al_set_new_bitmap_format",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_set_new_bitmap_format(int format);
		[DllImport(LIBRARY, EntryPoint="al_set_new_bitmap_flags",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_set_new_bitmap_flags(int flags);
		[DllImport(LIBRARY, EntryPoint="al_get_new_bitmap_format",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_new_bitmap_format();
		[DllImport(LIBRARY, EntryPoint="al_get_new_bitmap_flags",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_new_bitmap_flags();
		[DllImport(LIBRARY, EntryPoint="al_add_new_bitmap_flag",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_add_new_bitmap_flag(int flag);

		[DllImport(LIBRARY, EntryPoint="al_get_bitmap_width",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_bitmap_width(BitmapHandle bitmap);
		[DllImport(LIBRARY, EntryPoint="al_get_bitmap_height",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_bitmap_height(BitmapHandle bitmap);
		[DllImport(LIBRARY, EntryPoint="al_get_bitmap_format",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_bitmap_format(BitmapHandle bitmap);
		[DllImport(LIBRARY, EntryPoint="al_get_bitmap_flags",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_bitmap_flags(BitmapHandle bitmap);
		
		[DllImport(LIBRARY, EntryPoint="al_create_bitmap",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern BitmapHandle al_create_bitmap(int w, int h);
		[DllImport(LIBRARY, EntryPoint="al_destroy_bitmap",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_destroy_bitmap(BitmapHandle bitmap);

		/* Blitting */
		[DllImport(LIBRARY, EntryPoint="al_draw_bitmap",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_draw_bitmap(BitmapHandle bitmap, float dx, float dy, int flags);
		[DllImport(LIBRARY, EntryPoint="al_draw_bitmap_region",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_draw_bitmap_region(BitmapHandle bitmap, float sx, float sy, float sw, float sh, float dx, float dy, int flags);
		[DllImport(LIBRARY, EntryPoint="al_draw_scaled_bitmap",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_draw_scaled_bitmap(BitmapHandle bitmap, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, int flags);
		[DllImport(LIBRARY, EntryPoint="al_draw_rotated_bitmap",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_draw_rotated_bitmap(BitmapHandle bitmap, float cx, float cy, float dx, float dy, float angle, int flags);
		[DllImport(LIBRARY, EntryPoint="al_draw_scaled_rotated_bitmap",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_draw_scaled_rotated_bitmap(BitmapHandle bitmap, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);

		/* Tinted blitting */
		[DllImport(LIBRARY, EntryPoint="al_draw_tinted_bitmap",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_draw_tinted_bitmap(BitmapHandle bitmap, Allegro5Net.Color tint, float dx, float dy, int flags);
		[DllImport(LIBRARY, EntryPoint="al_draw_tinted_bitmap_region",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_draw_tinted_bitmap_region(BitmapHandle bitmap, Allegro5Net.Color tint, float sx, float sy, float sw, float sh, float dx, float dy, int flags);
		[DllImport(LIBRARY, EntryPoint="al_draw_tinted_scaled_bitmap",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_draw_tinted_scaled_bitmap(BitmapHandle bitmap, Allegro5Net.Color tint, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, int flags);
		[DllImport(LIBRARY, EntryPoint="al_draw_tinted_rotated_bitmap",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_draw_tinted_rotated_bitmap(BitmapHandle bitmap, Allegro5Net.Color tint, float cx, float cy, float dx, float dy, float angle, int flags);
		[DllImport(LIBRARY, EntryPoint="al_draw_tinted_scaled_rotated_bitmap",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_draw_tinted_scaled_rotated_bitmap(BitmapHandle bitmap, Allegro5Net.Color tint, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);

		/* Locking */
		[DllImport(LIBRARY, EntryPoint="al_lock_bitmap",
			CallingConvention=CallingConvention.Cdecl)]
		public unsafe static extern LockedRegion *al_lock_bitmap(BitmapHandle bitmap, int format, int flags);
		[DllImport(LIBRARY, EntryPoint="al_lock_bitmap_region",
			CallingConvention=CallingConvention.Cdecl)]
		public unsafe static extern LockedRegion *al_lock_bitmap_region(BitmapHandle bitmap, int x, int y, int width, int height, int format, int flags);
		[DllImport(LIBRARY, EntryPoint="al_unlock_bitmap",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_unlock_bitmap(BitmapHandle bitmap);
		
		[DllImport(LIBRARY, EntryPoint="al_put_pixel",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_put_pixel(int x, int y, Allegro5Net.Color color);
		[DllImport(LIBRARY, EntryPoint="al_put_blended_pixel",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_put_blended_pixel(int x, int y, Allegro5Net.Color color);
		[DllImport(LIBRARY, EntryPoint="al_get_pixel",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern Allegro5Net.Color al_get_pixel(BitmapHandle bitmap, int x, int y);
		[DllImport(LIBRARY, EntryPoint="al_get_pixel_size",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_pixel_size(int format);

		/* Pixel mapping */
		[DllImport(LIBRARY, EntryPoint="al_map_rgb",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern Allegro5Net.Color al_map_rgb(byte r, byte g, byte b);
		[DllImport(LIBRARY, EntryPoint="al_map_rgba",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern Allegro5Net.Color al_map_rgba(byte r, byte g, byte b, byte a);
		[DllImport(LIBRARY, EntryPoint="al_map_rgb_f",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern Allegro5Net.Color al_map_rgb_f(float r, float g, float b);
		[DllImport(LIBRARY, EntryPoint="al_map_rgba_f",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern Allegro5Net.Color al_map_rgba_f(float r, float g, float b, float a);

		/* Pixel unmapping */
		[DllImport(LIBRARY, EntryPoint="al_unmap_rgb",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_unmap_rgb(Allegro5Net.Color color, ref byte r, ref byte g, ref byte b);
		[DllImport(LIBRARY, EntryPoint="al_unmap_rgba",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_unmap_rgba(Allegro5Net.Color color, ref byte r, ref byte g, ref byte b, ref byte a);
		[DllImport(LIBRARY, EntryPoint="al_unmap_rgb_f",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_unmap_rgb_f(Allegro5Net.Color color, ref float r, ref float g, ref float b);
		[DllImport(LIBRARY, EntryPoint="al_unmap_rgba_f",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_unmap_rgba_f(Allegro5Net.Color color, ref float r, ref float g, ref float b, ref float a);
		[DllImport(LIBRARY, EntryPoint="al_get_pixel_format_bits",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int al_get_pixel_format_bits(int format);

		/* Masking */
		[DllImport(LIBRARY, EntryPoint="al_convert_mask_to_alpha",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_convert_mask_to_alpha(BitmapHandle bitmap, Allegro5Net.Color mask_color);

		/* Clipping */
		[DllImport(LIBRARY, EntryPoint="al_set_clipping_rectangle",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_set_clipping_rectangle(int x, int y, int width, int height);
		[DllImport(LIBRARY, EntryPoint="al_get_clipping_rectangle",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_get_clipping_rectangle(ref int x, ref int y, ref int w, ref int h);

		/* Sub bitmaps */
		[DllImport(LIBRARY, EntryPoint="al_create_sub_bitmap",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern BitmapHandle al_create_sub_bitmap(BitmapHandle parent, int x, int y, int w, int h);
		[DllImport(LIBRARY, EntryPoint="al_is_sub_bitmap",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_is_sub_bitmap(BitmapHandle bitmap);

		/* Miscellaneous */
		[DllImport(LIBRARY, EntryPoint="al_clone_bitmap",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern BitmapHandle al_clone_bitmap(BitmapHandle bitmap);
		[DllImport(LIBRARY, EntryPoint="al_is_bitmap_locked",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_is_bitmap_locked(BitmapHandle bitmap);

		/* Blending */
		[DllImport(LIBRARY, EntryPoint="al_set_blender",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_set_blender(int op, int source, int dest);
		[DllImport(LIBRARY, EntryPoint="al_get_blender",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_get_blender(ref int op, ref int source, ref int dest);
		[DllImport(LIBRARY, EntryPoint="al_set_separate_blender",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_set_separate_blender(int op, int source, int dest,
		   int alpha_op, int alpha_source, int alpha_dest);
		[DllImport(LIBRARY, EntryPoint="al_get_separate_blender",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_get_separate_blender(ref int op, ref int source, ref int dest,
   			ref int alpha_op, ref int alpha_src, ref int alpha_dest);

		// void _al_put_pixel(BitmapHandle bitmap, int x, int y, Allegro5Net.Color color);
		#endregion
		
		#region BITMAP_IO_H
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate BitmapHandle IIO_LOADER_FUNCTION([MarshalAs(UnmanagedType.LPStr)] string filename);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate BitmapHandle IIO_FS_LOADER_FUNCTION(AlFileHandle fp);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate bool IIO_SAVER_FUNCTION([MarshalAs(UnmanagedType.LPStr)] string filename, BitmapHandle bitmap);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate bool IIO_FS_SAVER_FUNCTION(AlFileHandle fp, BitmapHandle bitmap);

		[DllImport(LIBRARY, EntryPoint="al_register_bitmap_loader",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_register_bitmap_loader([MarshalAs(UnmanagedType.LPStr)] string ext, IIO_LOADER_FUNCTION loader);
		[DllImport(LIBRARY, EntryPoint="al_register_bitmap_saver",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_register_bitmap_saver([MarshalAs(UnmanagedType.LPStr)] string ext, IIO_SAVER_FUNCTION saver);
		[DllImport(LIBRARY, EntryPoint="al_register_bitmap_loader_f",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_register_bitmap_loader_f([MarshalAs(UnmanagedType.LPStr)] string ext, IIO_FS_LOADER_FUNCTION fs_loader);
		[DllImport(LIBRARY, EntryPoint="al_register_bitmap_saver_f",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_register_bitmap_saver_f([MarshalAs(UnmanagedType.LPStr)] string ext, IIO_FS_SAVER_FUNCTION fs_saver);
		[DllImport(LIBRARY, EntryPoint="al_load_bitmap",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern BitmapHandle al_load_bitmap([MarshalAs(UnmanagedType.LPStr)] string filename);
		[DllImport(LIBRARY, EntryPoint="al_load_bitmap_f",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern BitmapHandle al_load_bitmap_f(AlFileHandle fp, [MarshalAs(UnmanagedType.LPStr)] string ident);
		[DllImport(LIBRARY, EntryPoint="al_save_bitmap",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_save_bitmap([MarshalAs(UnmanagedType.LPStr)] string filename, BitmapHandle bitmap);
		[DllImport(LIBRARY, EntryPoint="al_save_bitmap_f",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_save_bitmap_f(AlFileHandle fp, [MarshalAs(UnmanagedType.LPStr)] string ident, BitmapHandle bitmap);
		#endregion
	}
}
