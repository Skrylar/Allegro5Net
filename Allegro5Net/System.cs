/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 9/30/2011
 * Time: 4:34 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.InteropServices;

namespace Allegro5Net
{
	public class System
	{
		public const string LIBRARY = "allegro-5.0.dll";
		//typedef struct ALLEGRO_SYSTEM ALLEGRO_SYSTEM;

		/* Function: al_init
		 */
		// #define al_init()    (al_install_system(ALLEGRO_VERSION_INT, atexit))

		public static bool Init()
		{
			// TODO: Figure out if there is a reasonable value we should give atexit.
			return Install(Base.ALLEGRO_VERSION_INT, null);
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int AllegroAtExit(IntPtr uservalue);

		[DllImport(LIBRARY, EntryPoint="al_install_system",
			CallingConvention=CallingConvention.Cdecl)]
		public extern static bool Install(int version, AllegroAtExit atExit);
		[DllImport(LIBRARY, EntryPoint="al_uninstall_system",
			CallingConvention=CallingConvention.Cdecl)]
		public extern static void Uninstall();
		[DllImport(LIBRARY, EntryPoint="al_is_system_installed",
			CallingConvention=CallingConvention.Cdecl)]
		protected extern static bool al_is_system_installed();

		public bool IsSystemInstalled
		{
			get
			{
				return al_is_system_installed();
			}
		}

		// AL_FUNC(ALLEGRO_SYSTEM *, al_get_system_driver, (void));
		// AL_FUNC(ALLEGRO_CONFIG *, al_get_system_config, (void));

		enum AllegroStandardPath : int {
		   Resources = 0,
		   Temp,
		   UserData,
		   UserHome,
		   UserSettings,
		   UserDocuments,
		   Exename,
		   Last // Must Be Last
		}

		// AL_FUNC(ALLEGRO_PATH *, al_get_standard_path, (AllegroStandardPath id));

		[DllImport(LIBRARY, EntryPoint="al_set_org_name", CharSet=CharSet.Unicode,
			CallingConvention=CallingConvention.Cdecl)]
		protected extern static void al_set_org_name([MarshalAs(UnmanagedType.LPStr)] string org_name);
		[DllImport(LIBRARY, EntryPoint="al_set_app_name", CharSet=CharSet.Unicode,
			CallingConvention=CallingConvention.Cdecl)]
		protected extern static void al_set_app_name([MarshalAs(UnmanagedType.LPStr)] string app_name);
		[DllImport(LIBRARY, EntryPoint="al_get_org_name", CharSet=CharSet.Unicode,
			CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.LPStr)]
		protected extern static string al_get_org_name();
		[DllImport(LIBRARY, EntryPoint="al_get_app_name", CharSet=CharSet.Unicode,
			CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.LPStr)]
		protected extern static string al_get_app_name();

		public static string AppName
		{
			set
			{
				al_set_app_name(value);
			}
			get
			{
				return al_get_app_name();
			}
		}

		public static string OrgName
		{
			set
			{
				al_set_org_name(value);
			}
			get
			{
				return al_get_org_name();
			}
		}

		[DllImport(LIBRARY, EntryPoint="al_inhibit_screensaver",
			CallingConvention=CallingConvention.Cdecl)]
		protected extern static bool al_inhibit_screensaver(bool inhibit);

		public static bool InhibitScreensaver
		{
			set
			{
				al_inhibit_screensaver(value);
			}
		}
	}
}