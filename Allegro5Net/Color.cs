/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 10/3/2011
 * Time: 8:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Allegro5Net
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Color
	{
		public float R, G, B, A;

		public Color(byte r, byte g, byte b, byte a)
		{
			R = (r / 255.0f);
			G = (g / 255.0f);
			B = (b / 255.0f);
			A = (a / 255.0f);
		}

		public Color(byte r, byte g, byte b)
		{
			R = (float)(r / 255.0);
			G = (float)(g / 255.0);
			B = (float)(b / 255.0);
			A = 1.0f;
		}

		public Color(float r, float g, float b, float a)
		{
			R = r;
			G = g;
			B = b;
			A = a;
		}

		public Color(float r, float g, float b)
		{
			R = r;
			G = g;
			B = b;
			A = 1.0f;
		}
		
		public Color(string hex)
		{
			R = 0; G = 0; B = 0; A = 1;
			Map(hex);
		}
		
		/// <summary>
		/// Converts a series of 8-bit RGBA values in to hardware-native
		/// floating point.
		/// </summary>
		/// <param name="r">Red</param>
		/// <param name="g">Green</param>
		/// <param name="b">Blue</param>
		/// <param name="a">Alpha</param>
		public void Map(byte r, byte g, byte b, byte a)
		{
			R = (r / 255.0f);
			G = (g / 255.0f);
			B = (b / 255.0f);
			A = (a / 255.0f);
		}
		
		/// <summary>
		/// Converts a series of 8-bit RGB values in to hardware-native
		/// floating point.  The converted color will have full opacity.
		/// </summary>
		/// <param name="r">Red</param>
		/// <param name="g">Green</param>
		/// <param name="b">Blue</param>
		public void Map(byte r, byte g, byte b)
		{
			Map(r, g, b, 255);
		}
		
		public void Map(float r, float g, float b, float a)
		{
			R = r;
			G = g;
			B = b;
			A = a;
		}
		
		public void Map(float r, float g, float b)
		{
			Map(r, g, b, 1);
		}
		
		public void Map(string hex)
		{
			// Trim excess spaces.
			string hexStr = hex.Trim();
			// Strip a color marker, if its here.
			if (hexStr.StartsWith("#")) hexStr = hexStr.Substring(1);
			// If this is a 3-character color code, convert it to a 6-char.
			if (hexStr.Length == 3)
			{
				// TODO: Is this really how CSS maps 3-character codes?
				hexStr = hexStr + hexStr;
			}
			// Okay, now a final sanity check.
			if (hexStr.Length != 6)
			{
				throw new FormatException("Color hex string is not the right size.");
			}
			
			byte r = byte.Parse(hexStr.Substring(0, 2), NumberStyles.HexNumber);
			byte g = byte.Parse(hexStr.Substring(2, 2), NumberStyles.HexNumber);
			byte b = byte.Parse(hexStr.Substring(4, 2), NumberStyles.HexNumber);
			
			Map(r, g, b);
		}
	}
}
