/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 10/2/2011
 * Time: 3:13 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Allegro5Net
{
	/// <summary>
	/// Description of Keyboard.
	/// </summary>
	public static  class Keyboard
	{
		struct KeyboardState
		{
			private AL5.Keyboard.KeyboardState handle;
			
			/// <summary>
			/// Returns whether a key is down in this captured state
			/// or not.
			/// </summary>
			public bool this[int key]
			{
				get
				{
					return AL5.Keyboard.al_key_down(ref handle, key);
				}
			}
			
			/// <summary>
			/// Captures the current state of the keyboard for further
			/// inspection using the index operator.
			/// </summary>
			public static KeyboardState Capture()
			{
				KeyboardState state = new KeyboardState();
				AL5.Keyboard.al_get_keyboard_state(ref state.handle);
				return state;
			}
		}
		
		public static bool Install()
		{
			return AL5.Keyboard.al_install_keyboard();
		}
		
		public static void Uninstall()
		{
			AL5.Keyboard.al_uninstall_keyboard();
		}
		
		public static bool IsInstalled
		{
			get
			{
				return AL5.Keyboard.al_is_keyboard_installed();
			}
		}
	}
}
