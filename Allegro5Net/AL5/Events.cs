
/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 10/1/2011
 * Time: 1:02 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.InteropServices;
using EventSourceHandle = System.IntPtr;
using DisplayHandle = System.IntPtr;
using JoystickHandle = System.IntPtr;
using KeyboardHandle = System.IntPtr;
using MouseHandle = System.IntPtr;
using TimerHandle = System.IntPtr;
using EventQueueHandle = System.IntPtr;
using intptr_t = System.IntPtr;

namespace Allegro5Net.AL5
{
	/// <summary>
	/// Description of Events_Bind.
	/// </summary>
	public unsafe class Events
	{
		public const string LIBRARY = "allegro-5.0.dll";

		public const int EVENT_JOYSTICK_AXIS               =  1;
		public const int EVENT_JOYSTICK_BUTTON_DOWN        =  2;
		public const int EVENT_JOYSTICK_BUTTON_UP          =  3;
		public const int EVENT_JOYSTICK_CONFIGURATION      =  4;

		public const int EVENT_KEY_DOWN                    = 10;
		public const int EVENT_KEY_CHAR                    = 11;
		public const int EVENT_KEY_UP                      = 12;

		public const int EVENT_MOUSE_AXES                  = 20;
		public const int EVENT_MOUSE_BUTTON_DOWN           = 21;
		public const int EVENT_MOUSE_BUTTON_UP             = 22;
		public const int EVENT_MOUSE_ENTER_DISPLAY         = 23;
		public const int EVENT_MOUSE_LEAVE_DISPLAY         = 24;
		public const int EVENT_MOUSE_WARPED                = 25;

		public const int EVENT_TIMER                       = 30;

		public const int EVENT_DISPLAY_EXPOSE              = 40;
		public const int EVENT_DISPLAY_RESIZE              = 41;
		public const int EVENT_DISPLAY_CLOSE               = 42;
		public const int EVENT_DISPLAY_LOST                = 43;
		public const int EVENT_DISPLAY_FOUND               = 44;
		public const int EVENT_DISPLAY_SWITCH_IN           = 45;
		public const int EVENT_DISPLAY_SWITCH_OUT          = 46;
		public const int EVENT_DISPLAY_ORIENTATION         = 47;

		/* Function: ALLEGRO_EVENT_TYPE_IS_USER
		 *
		 *    1 <= n < 512  - builtin events
		 *  512 <= n < 1024 - reserved user events (for addons)
		 * 1024 <= n        - unreserved user events
		 */
		public bool EventTypeIsUser(uint id)
		{
			return (id > 512);
		}

		/* Function: ALLEGRO_GET_EVENT_TYPE
		 */
		//#define ALLEGRO_GET_EVENT_TYPE(a, b, c, d)   AL_ID(a, b, c, d)

		/* Type: ALLEGRO_EVENT_SOURCE
		 */
		//typedef struct ALLEGRO_EVENT_SOURCE ALLEGRO_EVENT_SOURCE;

		/*struct ALLEGRO_EVENT_SOURCE
		{
		   int __pad[32];
		};*/

		/*
		 * Event structures
		 *
		 * All event types have the following fields in common.
		 *
		 *  type      -- the type of event this is
		 *  timestamp -- when this event was generated
		 *  source    -- which event source generated this event
		 *
		 * For people writing event sources: The common fields must be at the
		 * very start of each event structure, i.e. put _AL_EVENT_HEADER at the
		 * front.
		 */

		/*#define _AL_EVENT_HEADER(srctype)                    \
		   uint type;                          \
		   srctype *source;                                  \
		   double timestamp;*/

		[StructLayout(LayoutKind.Sequential)]
		public struct AnyEvent
		{
			// AL_EVENT_HEADER -- AUTOMATICALLY GENERATED
			public uint type;
			public EventSourceHandle source;
			public double timestamp;
			// END OF AL_EVENT_HEADER
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct DisplayEvent
		{
			// AL_EVENT_HEADER -- AUTOMATICALLY GENERATED
			public uint type;
			public DisplayHandle source;
			public double timestamp;
			// END OF AL_EVENT_HEADER
		   public int x, y;
		   public int width, height;
		   public int orientation;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct JoystickEvent
		{
			// AL_EVENT_HEADER -- AUTOMATICALLY GENERATED
			public uint type;
			public JoystickHandle source;
			public double timestamp;
			// END OF AL_EVENT_HEADER
		   public JoystickHandle id;
		   public int stick;
		   public int axis;
		   public float pos;
		   public int button;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct KeyboardEvent
		{
			// AL_EVENT_HEADER -- AUTOMATICALLY GENERATED
			public uint type;
			public KeyboardHandle source;
			public double timestamp;
			// END OF AL_EVENT_HEADER
		   public DisplayHandle display; /* the window the key was pressed in */
		   public int keycode;                 /* the physical key pressed */
		   public int unichar;                 /* unicode character or negative */
		   public uint modifiers;      /* bitfield */
		   public bool repeat;                 /* auto-repeated or not */
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct MouseEvent
		{
			// AL_EVENT_HEADER -- AUTOMATICALLY GENERATED
			public uint type;
			public MouseHandle source;
			public double timestamp;
			// END OF AL_EVENT_HEADER
		   DisplayHandle display;
		   /* (display) Window the event originate from
		    * (x, y) Primary mouse position
		    * (z) Mouse wheel position (1D 'wheel'), or,
		    * (w, z) Mouse wheel position (2D 'ball')
		    * (pressure) The pressure applied, for stylus (0 or 1 for normal mouse)
		    */
		   public int x,  y,  z, w;
		   public int dx, dy, dz, dw;
		   public uint button;
		   public float pressure;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct TimerEvent
		{
			// AL_EVENT_HEADER -- AUTOMATICALLY GENERATED
			public uint type;
			public TimerHandle source;
			public double timestamp;
			// END OF AL_EVENT_HEADER
		   public Int64  count;
		   public double error;
		}

		/* Type: ALLEGRO_USER_EVENT
		 */
		[StructLayout(LayoutKind.Sequential)]
		public struct UserEvent
		{
			// AL_EVENT_HEADER -- AUTOMATICALLY GENERATED
			public uint type;
			public EventSourceHandle source;
			public double timestamp;
			// END OF AL_EVENT_HEADER
		   public IntPtr __internal__descr;
		   public intptr_t data1;
		   public intptr_t data2;
		   public intptr_t data3;
		   public intptr_t data4;
		}

		/* Type: ALLEGRO_EVENT
		 */
		[StructLayout(LayoutKind.Explicit)]
		public struct ALEvent
		{
		   /* This must be the same as the first field of _AL_EVENT_HEADER.  */
		   [FieldOffset(0)]
		   public uint type;
		   /* `any' is to allow the user to access the other fields which are
		    * common to all event types, without using some specific type
		    * structure.
		    */
		   [FieldOffset(0)]
		   public AnyEvent      any;
		   [FieldOffset(0)]
		   public DisplayEvent  display;
		   [FieldOffset(0)]
		   public JoystickEvent joystick;
		   [FieldOffset(0)]
		   public KeyboardEvent keyboard;
		   [FieldOffset(0)]
		   public MouseEvent    mouse;
		   [FieldOffset(0)]
		   public TimerEvent    timer;
		   [FieldOffset(0)]
		   public UserEvent     user;
		}

		/* Event sources */

		[DllImport(LIBRARY, EntryPoint="al_init_user_event_source",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_init_user_event_source(EventSourceHandle source);
		[DllImport(LIBRARY, EntryPoint="al_destroy_user_event_source",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_destroy_user_event_source(EventSourceHandle source);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void UserEventDtor(UserEvent *evt);

		/* The second argument is ALLEGRO_EVENT instead of ALLEGRO_USER_EVENT
		 * to prevent users passing a pointer to a too-short structure.
		 */
		[DllImport(LIBRARY, EntryPoint="al_emit_user_event",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_emit_user_event(EventSourceHandle handle, ref ALEvent evt, UserEventDtor dtor);

		[DllImport(LIBRARY, EntryPoint="al_unref_user_event",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_unref_user_event(UserEvent *evt);
		[DllImport(LIBRARY, EntryPoint="al_set_event_source_data",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_set_event_source_data(EventSourceHandle handle, intptr_t data);
		[DllImport(LIBRARY, EntryPoint="al_get_event_source_data",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern intptr_t al_get_event_source_data(EventSourceHandle handle);

		/* Event queues */

		/* Type: ALLEGRO_EVENT_QUEUE
		 */
		//typedef struct ALLEGRO_EVENT_QUEUE ALLEGRO_EVENT_QUEUE;
		[DllImport(LIBRARY, EntryPoint="al_create_event_queue",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern EventQueueHandle al_create_event_queue();
		[DllImport(LIBRARY, EntryPoint="al_destroy_event_queue",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_destroy_event_queue(EventQueueHandle handle);
		[DllImport(LIBRARY, EntryPoint="al_register_event_source",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_register_event_source(EventQueueHandle que, EventSourceHandle src);
		[DllImport(LIBRARY, EntryPoint="al_unregister_event_source",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_unregister_event_source(EventQueueHandle que, EventSourceHandle src);
		[DllImport(LIBRARY, EntryPoint="al_is_event_queue_empty",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_is_event_queue_empty(EventQueueHandle handle);
		[DllImport(LIBRARY, EntryPoint="al_get_next_event",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_get_next_event(EventQueueHandle handle, ref ALEvent ret_event);
		[DllImport(LIBRARY, EntryPoint="al_peek_next_event",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_peek_next_event(EventQueueHandle handle, ref ALEvent ret_event);
		[DllImport(LIBRARY, EntryPoint="al_drop_next_event",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_drop_next_event(EventQueueHandle handle);
		[DllImport(LIBRARY, EntryPoint="al_flush_event_queue",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_flush_event_queue(EventQueueHandle handle);

		[DllImport(LIBRARY, EntryPoint="al_wait_for_event",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern void al_wait_for_event(EventQueueHandle que,
												ref ALEvent ret_event);

		[DllImport(LIBRARY, EntryPoint="al_wait_for_event_timed",
			CallingConvention=CallingConvention.Cdecl)]
		public static extern bool al_wait_for_event_timed(EventQueueHandle que,
													ref ALEvent ret_event,
													float secs);

		/*bool al_wait_for_event_until(EventQueueHandle que,
								ref ALEvent ret_event,
								ALLEGRO_TIMEOUT *timeout);*/
	}
}

