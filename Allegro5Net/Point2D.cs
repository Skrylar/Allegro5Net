/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 9/30/2011
 * Time: 6:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Allegro5Net
{
	/// <summary>
	/// Description of Point2D.
	/// </summary>
	public class Point2D
	{
		protected int mX;
		protected int mY;
		
		public Point2D()
		{
			mX = 0;
			mY = 0;
		}
		
		public Point2D(int x, int y)
		{
			mX = x;
			mY = y;
		}
		
		public int X
		{
			get { return mX; }
			set { mX = value; }
		}
		
		public int Width
		{
			get { return mX; }
			set { mX = value; }
		}
		
		public int Y
		{
			get { return mY; }
			set { mY = value; }
		}
		
		public int Height
		{
			get { return mY; }
			set { mY = value; }
		}
	}
}
