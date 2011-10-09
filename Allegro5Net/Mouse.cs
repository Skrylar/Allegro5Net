/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 10/2/2011
 * Time: 5:26 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Allegro5Net
{
	/// <summary>
	/// Description of Mouse.
	/// </summary>
	public static class Mouse
	{
		public static bool Install()
		{
			return AL5.Mouse.al_install_mouse();
		}
		
		public static void Uninstall()
		{
			AL5.Mouse.al_uninstall_mouse();
		}
		
		public static bool IsInstalled
		{
			get
			{
				return AL5.Mouse.al_is_mouse_installed();
			}
		}
	}
}
