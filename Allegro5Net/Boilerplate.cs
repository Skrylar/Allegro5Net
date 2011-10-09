
/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 10/1/2011
 * Time: 9:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Allegro5Net
{
	public partial class Display : IDisposable
	{
		protected IntPtr mHandle;
		public IntPtr Handle { get { return mHandle; } }
		public void Dispose() { Dispose(true); }
		public bool IsDisposed { get { return (mHandle == IntPtr.Zero); } }
		~Display() {
			Dispose(false);
		}
		protected void Dispose(bool disposing)
		{
			if (!IsDisposed) {
				AL5.Display.al_destroy_display(mHandle);
				mHandle = IntPtr.Zero;
			}
		}
	}
	public partial class EventQueue : IDisposable
	{
		protected IntPtr mHandle;
		public IntPtr Handle { get { return mHandle; } }
		public void Dispose() { Dispose(true); }
		public bool IsDisposed { get { return (mHandle == IntPtr.Zero); } }
		~EventQueue() {
			Dispose(false);
		}
		protected void Dispose(bool disposing)
		{
			if (!IsDisposed) {
				AL5.Events.al_destroy_event_queue(mHandle);
				mHandle = IntPtr.Zero;
			}
		}
	}
	public partial class Bitmap : IDisposable
	{
		protected IntPtr mHandle;
		public IntPtr Handle { get { return mHandle; } }
		public void Dispose() { Dispose(true); }
		public bool IsDisposed { get { return (mHandle == IntPtr.Zero); } }
		~Bitmap() {
			Dispose(false);
		}
		protected void Dispose(bool disposing)
		{
			if (!IsDisposed) {
				AL5.Bitmap.al_destroy_bitmap(mHandle);
				mHandle = IntPtr.Zero;
			}
		}
	}
	public partial class Timer : IDisposable
	{
		protected IntPtr mHandle;
		public IntPtr Handle { get { return mHandle; } }
		public void Dispose() { Dispose(true); }
		public bool IsDisposed { get { return (mHandle == IntPtr.Zero); } }
		~Timer() {
			Dispose(false);
		}
		protected void Dispose(bool disposing)
		{
			if (!IsDisposed) {
				AL5.Timer.al_destroy_timer(mHandle);
				mHandle = IntPtr.Zero;
			}
		}
	}
}

