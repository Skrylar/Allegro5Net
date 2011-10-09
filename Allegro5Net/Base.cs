/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 9/30/2011
 * Time: 4:36 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Allegro5Net
{
	public class Base
	{
		public static readonly int ALLEGRO_VERSION          = 5;
		public static readonly int ALLEGRO_SUB_VERSION      = 0;
		public static readonly int ALLEGRO_WIP_VERSION      = 4; 

		public static readonly int ALLEGRO_RELEASE_NUMBER   = 1;
		public static readonly string ALLEGRO_VERSION_STR   = "5.0.4";
		public static readonly string ALLEGRO_DATE_STR      = "2011";
		public static readonly int ALLEGRO_DATE             = 20110814;    /* yyyymmdd */

		public static double ALLEGRO_PI        = 3.14159265358979323846;

		public static int ALLEGRO_VERSION_INT
		{
			get
			{
		    	return ((ALLEGRO_VERSION << 24) | (ALLEGRO_SUB_VERSION << 16) |
		    		(ALLEGRO_WIP_VERSION << 8) | ALLEGRO_RELEASE_NUMBER);
			}
		}

		public static int AL_ID(int a,int b,int c,int d)
		{
			return (((a)<<24) | ((b)<<16) | ((c)<<8) | (d));
		}
	}
}
