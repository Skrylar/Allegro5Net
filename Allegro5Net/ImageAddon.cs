/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 10/3/2011
 * Time: 10:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.InteropServices;

using uint32_t = System.UInt32;

namespace Allegro5Net
{
	/// <summary>
	/// Optional addon which installs support for standard image formats like
	/// PNG or JPEG.
	/// </summary>
	public static class ImageAddon
	{
		public const string LIBRARY="allegro_image-5.0.dll";

		[DllImport(LIBRARY, EntryPoint="al_init_image_addon",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool Install();
		
		/// <remarks>
		/// Called automatically when Allegro is shut down, but may be done by
		/// the programmer before then.
		/// </remarks>
		[DllImport(LIBRARY, EntryPoint="al_shutdown_image_addon",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void Uninstall();
		
		[DllImport(LIBRARY, EntryPoint="al_get_allegro_image_version",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern uint32_t al_get_allegro_image_version();

		public static uint32_t Version
		{
			get
			{
				return al_get_allegro_image_version();
			}
		}
	}
}
