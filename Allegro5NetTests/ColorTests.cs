/*
 * Created by SharpDevelop.
 * User: Skrylar
 * Date: 10/7/2011
 * Time: 9:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Allegro5Net;
using NUnit.Framework;

namespace Allegro5NetTests
{
	[TestFixture]
	public class ColorTests
	{
		[Test]
		public void HexDecoding()
		{
			Color color = new Color("#ffffff");
			Assert.AreEqual(255, color.R);
			Assert.AreEqual(255, color.G);
			Assert.AreEqual(255, color.B);
			
			color.Map("#000");
			Assert.AreEqual(0, color.R);
			Assert.AreEqual(0, color.G);
			Assert.AreEqual(0, color.B);
			
			/*color.Map("#FCE94F");
			Assert.AreEqual(252, color.R);
			Assert.AreEqual(233, color.G);
			Assert.AreEqual(79, color.B);*/
			// TODO: Find an acceptable variance and do other color tests with floats.
		}
	}
}
