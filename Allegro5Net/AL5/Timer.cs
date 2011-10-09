/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 10/4/2011
 * Time: 10:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.InteropServices;

using int64_t = System.Int64;
using TimerHandle = System.IntPtr;
using EventSourceHandle = System.IntPtr;

namespace Allegro5Net.AL5
{
	/// <summary>
	/// Description of Timer.
	/// </summary>
	public static class Timer
	{
		public const string LIBRARY="allegro-5.0.dll";

		/* Function: ALLEGRO_USECS_TO_SECS
		 */
		public static double USECS_TO_SECS(double x)
		{
			return ((x) / 1000000.0);
		}

		/* Function: ALLEGRO_MSECS_TO_SECS
		 */
		public static double MSECS_TO_SECS(double x)
		{
			return ((x) / 1000.0);
		}

		/* Function: ALLEGRO_BPS_TO_SECS
		 */
		public static double BPS_TO_SECS(double x)
		{
			return (1.0 / (x));
		}

		/* Function: ALLEGRO_BPM_TO_SECS
		 */
		public static double BPM_TO_SECS(double x)
		{
			return (60.0 / (x));
		}

		[DllImport(LIBRARY, EntryPoint="al_create_timer",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern TimerHandle al_create_timer(double speed_secs);
		[DllImport(LIBRARY, EntryPoint="al_destroy_timer",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_destroy_timer(TimerHandle timer);
		[DllImport(LIBRARY, EntryPoint="al_start_timer",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_start_timer(TimerHandle timer);
		[DllImport(LIBRARY, EntryPoint="al_stop_timer",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_stop_timer(TimerHandle timer);
		[DllImport(LIBRARY, EntryPoint="al_get_timer_started",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_get_timer_started(TimerHandle timer);
		[DllImport(LIBRARY, EntryPoint="al_get_timer_speed",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern double al_get_timer_speed(TimerHandle timer);
		[DllImport(LIBRARY, EntryPoint="al_set_timer_speed",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_set_timer_speed(TimerHandle timer, double speed_secs);
		[DllImport(LIBRARY, EntryPoint="al_get_timer_count",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern int64_t al_get_timer_count(TimerHandle timer);
		[DllImport(LIBRARY, EntryPoint="al_set_timer_count",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_set_timer_count(TimerHandle timer, int64_t count);
		[DllImport(LIBRARY, EntryPoint="al_add_timer_count",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_add_timer_count(TimerHandle timer, int64_t diff);
		[DllImport(LIBRARY, EntryPoint="al_get_timer_event_source",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern EventSourceHandle al_get_timer_event_source(TimerHandle timer);
	}
}
