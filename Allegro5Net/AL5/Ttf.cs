/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 10/9/2011
 * Time: 3:30 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.InteropServices;

using FontHandle = System.IntPtr;
using FileHandle = System.IntPtr;
using uint32_t = System.UInt32;

namespace Allegro5Net.AL5
{
	/// <summary>
	/// Description of Ttf.
	/// </summary>
	public static class Ttf
	{
		public const string LIBRARY="allegro_ttf-5.0.dll";
		
		public enum TtfFontFlag : int
		{
			No_Kerning = 1,
			Monochrome = 2
		}

		[DllImport(LIBRARY, EntryPoint="al_load_ttf_font",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern FontHandle al_load_ttf_font([MarshalAs(UnmanagedType.LPStr)] string filename, int size, int flags);
		[DllImport(LIBRARY, EntryPoint="al_load_ttf_font_f",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern FontHandle al_load_ttf_font_f(FileHandle file, [MarshalAs(UnmanagedType.LPStr)] string filename, int size, int flags);
		[DllImport(LIBRARY, EntryPoint="al_init_ttf_addon",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_init_ttf_addon();
		[DllImport(LIBRARY, EntryPoint="al_shutdown_ttf_addon",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_shutdown_ttf_addon();
		[DllImport(LIBRARY, EntryPoint="al_get_allegro_ttf_version",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern uint32_t al_get_allegro_ttf_version();
	}
}
