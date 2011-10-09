
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
	/// <summary>
	/// Description of EventQueue.
	/// </summary>
	public partial class EventQueue
	{
		#region Delegate Declarations
		public delegate void JoystickEventHandler(ref AL5.Events.JoystickEvent evt);
		public delegate void KeyboardEventHandler(ref AL5.Events.KeyboardEvent evt);
		public delegate void MouseEventHandler(ref AL5.Events.MouseEvent evt);
		public delegate void TimerEventHandler(ref AL5.Events.TimerEvent evt);
		public delegate void DisplayEventHandler(ref AL5.Events.DisplayEvent evt);
		#endregion
	
		#region Event Declarations
		public event JoystickEventHandler OnJoystickAxis;
		public event JoystickEventHandler OnJoystickButtonDown;
		public event JoystickEventHandler OnJoystickButtonUp;
		public event JoystickEventHandler OnJoystickConfiguration;
		public event KeyboardEventHandler OnKeyDown;
		public event KeyboardEventHandler OnKeyChar;
		public event KeyboardEventHandler OnKeyUp;
		public event MouseEventHandler OnMouseAxes;
		public event MouseEventHandler OnMouseButtonDown;
		public event MouseEventHandler OnMouseButtonUp;
		public event MouseEventHandler OnMouseEnterDisplay;
		public event MouseEventHandler OnMouseLeaveDisplay;
		public event MouseEventHandler OnMouseWarped;
		public event TimerEventHandler OnTimer;
		public event DisplayEventHandler OnDisplayExpose;
		public event DisplayEventHandler OnDisplayResize;
		public event DisplayEventHandler OnDisplayClose;
		public event DisplayEventHandler OnDisplayLost;
		public event DisplayEventHandler OnDisplayFound;
		public event DisplayEventHandler OnDisplaySwitchIn;
		public event DisplayEventHandler OnDisplaySwitchOut;
		public event DisplayEventHandler OnDisplayOrientation;
		#endregion

		public void Dispatch(ref AL5.Events.ALEvent evt)
		{
			switch (evt.type)
			{
				case AL5.Events.EVENT_JOYSTICK_AXIS:
					if (OnJoystickAxis != null)
						OnJoystickAxis(ref evt.joystick);
					break;
				case AL5.Events.EVENT_JOYSTICK_BUTTON_DOWN:
					if (OnJoystickButtonDown != null)
						OnJoystickButtonDown(ref evt.joystick);
					break;
				case AL5.Events.EVENT_JOYSTICK_BUTTON_UP:
					if (OnJoystickButtonUp != null)
						OnJoystickButtonUp(ref evt.joystick);
					break;
				case AL5.Events.EVENT_JOYSTICK_CONFIGURATION:
					if (OnJoystickConfiguration != null)
						OnJoystickConfiguration(ref evt.joystick);
					break;
				case AL5.Events.EVENT_KEY_DOWN:
					if (OnKeyDown != null)
						OnKeyDown(ref evt.keyboard);
					break;
				case AL5.Events.EVENT_KEY_CHAR:
					if (OnKeyChar != null)
						OnKeyChar(ref evt.keyboard);
					break;
				case AL5.Events.EVENT_KEY_UP:
					if (OnKeyUp != null)
						OnKeyUp(ref evt.keyboard);
					break;
				case AL5.Events.EVENT_MOUSE_AXES:
					if (OnMouseAxes != null)
						OnMouseAxes(ref evt.mouse);
					break;
				case AL5.Events.EVENT_MOUSE_BUTTON_DOWN:
					if (OnMouseButtonDown != null)
						OnMouseButtonDown(ref evt.mouse);
					break;
				case AL5.Events.EVENT_MOUSE_BUTTON_UP:
					if (OnMouseButtonUp != null)
						OnMouseButtonUp(ref evt.mouse);
					break;
				case AL5.Events.EVENT_MOUSE_ENTER_DISPLAY:
					if (OnMouseEnterDisplay != null)
						OnMouseEnterDisplay(ref evt.mouse);
					break;
				case AL5.Events.EVENT_MOUSE_LEAVE_DISPLAY:
					if (OnMouseLeaveDisplay != null)
						OnMouseLeaveDisplay(ref evt.mouse);
					break;
				case AL5.Events.EVENT_MOUSE_WARPED:
					if (OnMouseWarped != null)
						OnMouseWarped(ref evt.mouse);
					break;
				case AL5.Events.EVENT_TIMER:
					if (OnTimer != null)
						OnTimer(ref evt.timer);
					break;
				case AL5.Events.EVENT_DISPLAY_EXPOSE:
					if (OnDisplayExpose != null)
						OnDisplayExpose(ref evt.display);
					break;
				case AL5.Events.EVENT_DISPLAY_RESIZE:
					if (OnDisplayResize != null)
						OnDisplayResize(ref evt.display);
					break;
				case AL5.Events.EVENT_DISPLAY_CLOSE:
					if (OnDisplayClose != null)
						OnDisplayClose(ref evt.display);
					break;
				case AL5.Events.EVENT_DISPLAY_LOST:
					if (OnDisplayLost != null)
						OnDisplayLost(ref evt.display);
					break;
				case AL5.Events.EVENT_DISPLAY_FOUND:
					if (OnDisplayFound != null)
						OnDisplayFound(ref evt.display);
					break;
				case AL5.Events.EVENT_DISPLAY_SWITCH_IN:
					if (OnDisplaySwitchIn != null)
						OnDisplaySwitchIn(ref evt.display);
					break;
				case AL5.Events.EVENT_DISPLAY_SWITCH_OUT:
					if (OnDisplaySwitchOut != null)
						OnDisplaySwitchOut(ref evt.display);
					break;
				case AL5.Events.EVENT_DISPLAY_ORIENTATION:
					if (OnDisplayOrientation != null)
						OnDisplayOrientation(ref evt.display);
					break;
				default: throw new NotImplementedException();
			}
		}
	}
}

