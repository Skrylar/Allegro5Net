/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 10/1/2011
 * Time: 9:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.InteropServices;

namespace Allegro5Net
{
	/// <summary>
	/// Description of EventQueue.
	/// </summary>
	public partial class EventQueue : IDisposable
	{
		protected EventQueue()
		{
		}
		
		public static EventQueue Create()
		{
			IntPtr hnd = AL5.Events.al_create_event_queue();
			if (hnd == IntPtr.Zero)
				return null;
			else
			{
				EventQueue self = new EventQueue();
				self.mHandle = hnd;
				return self;
			}
		}
		
		public bool IsEmpty
		{
			get
			{
				return AL5.Events.al_is_event_queue_empty(mHandle);
			}
		}
		
		#region Source Registration
		public void RegisterSource(IALEventSource source)
		{
			if (source != null)
				AL5.Events.al_register_event_source(mHandle, source.RawEventSource);
			else
				throw new ArgumentNullException();
		}
		
		/// <summary>
		/// Adds support for keyboard input to this event queue.
		/// </summary>
		/// <remarks>
		/// Use of this method without first installing the keyboard driver
		/// will fail spectacularly.
		/// </remarks>
		public void RegisterKeyboardSource()
		{
			AL5.Events.al_register_event_source(mHandle, AL5.Keyboard.al_get_keyboard_event_source());
		}
		
		/// <summary>
		/// Adds support for mouse input to this event queue.
		/// </summary>
		/// <remarks>
		/// Use of this method without first installing the mouse driver
		/// will fail spectacularly.
		/// </remarks>
		public void RegisterMouseSource()
		{
			AL5.Events.al_register_event_source(mHandle, AL5.Mouse.al_get_mouse_event_source());
		}
		
		public void UnregisterSource(IALEventSource source)
		{
			if (source != null)
				AL5.Events.al_unregister_event_source(mHandle, source.RawEventSource);
			else
				throw new ArgumentNullException();
		}
		
		public void RegisterRawSource(IntPtr source)
		{
			AL5.Events.al_register_event_source(mHandle, source);
		}
		
		public void UnregisterRawSource(IntPtr source)
		{
			AL5.Events.al_unregister_event_source(mHandle, source);
		}
		#endregion
		
		#region Dispatch
		/// <summary>
		/// Processes events from this queue one at a time, until there are no
		/// further events remaining, and dispatches them to proper C# AL5.
		/// </summary>
		public void DispatchAll()
		{
			if (IsEmpty)
				return;
			else
			{
				AL5.Events.ALEvent evt = new AL5.Events.ALEvent();
				while (!IsEmpty)
				{
					NextRawEvent(ref evt);
					Dispatch(ref evt);
				}
			}
		}
		
		/// <summary>
		/// Waits for an event to be posted to this event queue, then
		/// dispatches all events until the queue is empty once again.
		/// </summary>
		public void WaitDispatchAll()
		{
			AL5.Events.ALEvent evt = new AL5.Events.ALEvent();
			WaitForRawEvent(ref evt);
			do
			{
				Dispatch(ref evt);
				NextRawEvent(ref evt);
			} while (!IsEmpty);
		}
		#endregion
		
		#region Raw Events
		public void WaitForRawEvent(ref AL5.Events.ALEvent evt)
		{
			AL5.Events.al_wait_for_event(mHandle, ref evt);
		}
		
		public void NextRawEvent(ref AL5.Events.ALEvent evt)
		{
			AL5.Events.al_get_next_event(mHandle, ref evt);
		}
		#endregion
	}
}
