#region License
/*
*
* The MIT License (MIT)
*
* Copyright (c) 2017 René Kannegießer
*
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*/
#endregion

using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlinkStickAmbiLight
{
	public partial class MainForm : Form
	{				
		/// <summary>
        /// Create color regions for each LED
        /// </summary>
        /// <param name="g">Graphics</param>
		void CreatePixelRects(Graphics g)
		{
			var col = new Color();
			foreach(var region in rf.regions)
			{
				col = Color.FromArgb(cbTransparent.Checked ? RectTransparency : 255, region.color);
				var brush = new SolidBrush(col);
				var textbrush = new SolidBrush(Color.Black);
				var textbrushred = new SolidBrush(Color.Red);
				var textbrushgreen = new SolidBrush(Color.Green);
				var textbrushblue = new SolidBrush(Color.Blue);
				var textfont = new System.Drawing.Font("Tahoma", 6, FontStyle.Bold);
				g.FillRectangle(brush, region.rect);
				g.DrawRectangle(new Pen(Color.Black, PenWidth), region.rect);
				switch(region.channel)
				{
					case 1:
						g.DrawString(region.led_id.ToString(), textfont, textbrushgreen, region.rect);	
						break;
					case 2:
						g.DrawString(region.led_id.ToString(), textfont, textbrushblue, region.rect);		
						break;						
					case 0:
					default:
						if (region.led_id == 0)
							g.DrawString("->" + region.led_id.ToString(), textfont, textbrushred, region.rect);
						else
							g.DrawString(region.led_id.ToString(), textfont, textbrush, region.rect);
						break;
				}
				brush.Dispose();
			}
		}
	}
}
