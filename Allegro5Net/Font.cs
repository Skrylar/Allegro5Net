/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 10/9/2011
 * Time: 3:46 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Allegro5Net
{
	/// <summary>
	/// Description of Font.
	/// </summary>
	public class Font
	{
		public static void Install()
		{
			AL5.Font.al_init_font_addon();
		}
		
		public static void Uninstall()
		{
			AL5.Font.al_shutdown_font_addon();
		}
		
		public static uint Version
		{
			get { return AL5.Font.al_get_allegro_font_version(); }
		}
	}
}
