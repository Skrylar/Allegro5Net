/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 10/4/2011
 * Time: 10:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Allegro5Net
{
	/// <summary>
	/// A C#-styled wrapper around Allegor's timer objects.
	/// </summary>
	public partial class Timer : IDisposable, IALEventSource
	{
		protected Timer(IntPtr handle)
		{
			mHandle = handle;
		}
		
		public static Timer Create(double speedInSeconds)
		{
			IntPtr handle = AL5.Timer.al_create_timer(speedInSeconds);
			if (handle != IntPtr.Zero)
			{
				return new Timer(handle);
			}
			else
				return null;
		}
		
		public void Start()
		{
			AL5.Timer.al_start_timer(mHandle);
		}
		
		public void Stop()
		{
			AL5.Timer.al_stop_timer(mHandle);
		}
		
		public bool IsRunning
		{
			get
			{
				return AL5.Timer.al_get_timer_started(mHandle);
			}
		}
		
		public double SpeedInSeconds
		{
			get
			{
				return AL5.Timer.al_get_timer_speed(mHandle);
			}
			set
			{
				AL5.Timer.al_set_timer_speed(mHandle, value);
			}
		}
		
		public Int64 Count
		{
			get
			{
				return AL5.Timer.al_get_timer_count(mHandle);
			}
			set
			{
				AL5.Timer.al_set_timer_count(mHandle, value);
			}
		}
		
		public IntPtr RawEventSource
		{
			get
			{
				return AL5.Timer.al_get_timer_event_source(mHandle);
			}
		}
	}
}
