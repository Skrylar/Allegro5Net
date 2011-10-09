/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 10/2/2011
 * Time: 2:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Allegro5Net
{
	/// <summary>
	/// Description of Keycodes.
	/// </summary>
	public class Keycodes
	{
		/* Note these values are deliberately the same as in Allegro 4.1.x */
		public enum Key : int
		{
			Key_A		= 1,
			Key_B		= 2,
			Key_C		= 3,
			Key_D		= 4,
			Key_E		= 5,
			Key_F		= 6,
			Key_G		= 7,
			Key_H		= 8,
			Key_I		= 9,
			Key_J		= 10,
			Key_K		= 11,
			Key_L		= 12,
			Key_M		= 13,
			Key_N		= 14,
			Key_O		= 15,
			Key_P		= 16,
			Key_Q		= 17,
			Key_R		= 18,
			Key_S		= 19,
			Key_T		= 20,
			Key_U		= 21,
			Key_V		= 22,
			Key_W		= 23,
			Key_X		= 24,
			Key_Y		= 25,
			Key_Z		= 26,

			Key_0		= 27,
			Key_1		= 28,
			Key_2		= 29,
			Key_3		= 30,
			Key_4		= 31,
			Key_5		= 32,
			Key_6		= 33,
			Key_7		= 34,
			Key_8		= 35,
			Key_9		= 36,

			KeyPad_0		= 37,
			KeyPad_1		= 38,
			KeyPad_2		= 39,
			KeyPad_3		= 40,
			KeyPad_4		= 41,
			KeyPad_5		= 42,
			KeyPad_6		= 43,
			KeyPad_7		= 44,
			KeyPad_8		= 45,
			KeyPad_9		= 46,

			Key_F1		= 47,
			Key_F2		= 48,
			Key_F3		= 49,
			Key_F4		= 50,
			Key_F5		= 51,
			Key_F6		= 52,
			Key_F7		= 53,
			Key_F8		= 54,
			Key_F9		= 55,
			Key_F10		= 56,
			Key_F11		= 57,
			Key_F12		= 58,

			Key_Escape		= 59,
			Key_Tilde		= 60,
			Key_Minus		= 61,
			Key_Equals		= 62,
			Key_Backspace	= 63,
			Key_Tab			= 64,
			Key_Openbrace	= 65,
			Key_Closebrace	= 66,
			Key_Enter		= 67,
			Key_Semicolon	= 68,
			Key_Quote		= 69,
			Key_Backslash	= 70,
			Key_Backslash2	= 71, /* DirectInput calls this DIK_OEM_102: "< > | on UK/Germany keyboards" */
			Key_Comma		= 72,
			Key_Fullstop	= 73,
			Key_Slash		= 74,
			Key_Space		= 75,

			Key_Insert		= 76,
			Key_Delete		= 77,
			Key_Home		= 78,
			Key_End			= 79,
			Key_PageUp		= 80,
			Key_PageDown	= 81,
			Key_Left		= 82,
			Key_Right		= 83,
			Key_Up			= 84,
			Key_Down		= 85,

			KeyPad_Slash	= 86,
			KeyPad_Asterisk	= 87,
			KeyPad_Minus	= 88,
			KeyPad_Plus		= 89,
			KeyPad_Delete	= 90,
			KeyPad_Enter	= 91,

			Key_Printscreen	= 92,
			Key_Pause		= 93,

			Key_Abnt_C1		= 94,
			Key_Yen			= 95,
			Key_Kana		= 96,
			Key_Convert		= 97,
			Key_Noconvert	= 98,
			Key_At			= 99,
			Key_Circumflex	= 100,
			Key_Colon2		= 101,
			Key_Kanji		= 102,

			Key_Pad_Equals	= 103,	/* MacOS X */
			Key_Backquote	= 104,	/* MacOS X */
			Key_Semicolon2	= 105,	/* MacOS X -- TODO: ask lillo what this should be */
			Key_Command		= 106,	/* MacOS X */
			Key_Unknown     = 107,

		   /* All codes up to before ALLEGRO_KEY_MODIFIERS can be freely
		    * assignedas additional unknown keys, like various multimedia
		    * and application keys keyboards may have.
		    */

			Key_Modifiers	= 215,

			Key_LeftShift		= 215,
			Key_RightShift		= 216,
			Key_LeftControl		= 217,
			Key_RightControl	= 218,
			Key_Alt				= 219,
			Key_AltGr			= 220,
			Key_LeftWindows		= 221,
			Key_RightWindows	= 222,
			Key_Menu			= 223,
			Key_Scrolllock 		= 224,
			Key_Numlock			= 225,
			Key_Capslock		= 226,

			Max
		}

		public enum KeyModifier : int
		{
			SHIFT       = 0x00001,
			CTRL        = 0x00002,
			ALT         = 0x00004,
			LWIN        = 0x00008,
			RWIN        = 0x00010,
			MENU        = 0x00020,
			ALTGR       = 0x00040,
			COMMAND     = 0x00080,
			SCROLLLOCK  = 0x00100,
			NUMLOCK     = 0x00200,
			CAPSLOCK    = 0x00400,
			INALTSEQ	   = 0x00800,
			ACCENT1     = 0x01000,
			ACCENT2     = 0x02000,
			ACCENT3     = 0x04000,
			ACCENT4     = 0x08000
		}
	}
}
