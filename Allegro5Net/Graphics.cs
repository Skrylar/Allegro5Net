/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 10/3/2011
 * Time: 9:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Allegro5Net
{
	/// <summary>
	/// Description of Graphics.
	/// </summary>
	public static class Graphics
	{
		/// <summary>
		/// Flips changes made to the target image or display so they
		/// may be seen.
		/// </summary>
		/// <seealso cref="Display.BecomeTarget" />
		/// <remarks>
		/// May appear to do nothing if a display is not marked as
		/// Allegro's target.
		/// </remarks>
		public static void Flip()
		{
			AL5.Display.al_flip_display();
		}
		
		/// <summary>
		/// Clears the target image to a given color.  To clear only a part
		/// of an image, set a clipping rectangle or use a rectangle
		/// drawing method.
		/// </summary>
		/// <param name="clearColor"></param>
		public static void Clear(ref Color clearColor)
		{
			AL5.Display.al_clear_to_color(clearColor);
		}
	}
}
