/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 10/2/2011
 * Time: 12:33 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Allegro5Net
{
	/// <summary>
	/// Indicates a class has an Allegro 5.x event source that may be queued.
	/// Mostly intended for use by the low-level wrapper code, as higher levels
	/// use native C# events.
	/// </summary>
	public interface IALEventSource
	{
		IntPtr RawEventSource
		{
			get;
		}
	}
}
