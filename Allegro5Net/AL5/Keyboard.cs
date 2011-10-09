/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 10/2/2011
 * Time: 2:25 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.InteropServices;
using KeyboardHandle = System.IntPtr;
using EventSourceHandle = System.IntPtr;

namespace Allegro5Net.AL5
{
	/// <summary>
	/// Description of Keyboard.
	/// </summary>
	public static class Keyboard
	{
		public const string LIBRARY = "allegro-5.0.dll";

		/* Type: ALLEGRO_KEYBOARD_STATE
		 */
		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct KeyboardState
		{
		   public KeyboardHandle display;  /* public */
		   /* internal */
		   private fixed uint __key_down__internal__[((int)Keycodes.Key.Max + 31) / 32];
		}

		[DllImport(LIBRARY, EntryPoint="al_is_keyboard_installed",
		           CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_is_keyboard_installed();
		[DllImport(LIBRARY, EntryPoint="al_install_keyboard",
		           CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_install_keyboard();
		[DllImport(LIBRARY, EntryPoint="al_uninstall_keyboard",
		           CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_uninstall_keyboard();

		[DllImport(LIBRARY, EntryPoint="al_set_keyboard_leds",
		           CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_set_keyboard_leds(int leds);

		[DllImport(LIBRARY, EntryPoint="al_keycode_to_name",
		           CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.LPStr)]
		public static extern string al_keycode_to_name(int keycode);

		[DllImport(LIBRARY, EntryPoint="al_get_keyboard_state",
		           CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_get_keyboard_state(ref KeyboardState ret_state);
		[DllImport(LIBRARY, EntryPoint="al_key_down",
		           CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_key_down(ref KeyboardState state, int keycode);

		[DllImport(LIBRARY, EntryPoint="al_get_keyboard_event_source",
		           CallingConvention=CallingConvention.Cdecl)]
		public static extern EventSourceHandle al_get_keyboard_event_source();
	}
}
