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
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BlinkStickAmbiLight
{
	public class RegionFrame
	{
		public List<Region> regions;
		public int[] leds;
		
		/// <summary>
        /// Build the region frame
        /// </summary>
        /// <param name="top">Amount of top regions</param>
        /// <param name="bottom">Amount of top regions</param>
        /// <param name="left">Amount of left regions</param>
        /// <param name="right">Amount of right regions</param>
        /// <param name="screenwidth">Screen width</param>
        /// <param name="screenheight">Screen height</param>
        /// <param name="size">Size of a region</param>
        /// <param name="ledshift">shift start led to the left (-) or to the right (+)</param>
		public RegionFrame(int top, int bottom, int left, int right, int screenwidth, int screenheight, int size, int ledshift = 0)
		{
			regions = new List<Region>();
			ledshift *= -1;
			int ledsum = top + bottom + left + right;
			leds = new int[ledsum];
			int idcount = 0;
			int avg_top = 0;
			int avg_bottom = 0;
			int avg_left = 0;
			int avg_right = 0;
			int size_factor_top = 2;
			int size_factor_bottom = 2;
			int rest = 0;
			
			// Calculate size factor
			size_factor_top = top > 0 ? 1 : 0;
			size_factor_bottom = bottom > 0 ? 1 : 0;
			
			// Rest value (remainder)
			int remainder_top = top == 0 ? 0 : screenwidth % top;
			int remainder_bottom = bottom == 0 ? 0 : screenwidth % bottom;
			int remainder_left = left == 0 ? 0 : (screenheight - (size * (size_factor_top + size_factor_bottom))) % left;
			int remainder_right = right == 0 ? 0 : (screenheight - (size * (size_factor_top + size_factor_bottom))) % right;
			
			// Calculate region sizes
			avg_top = top > 0 ? screenwidth / top : 0;
			avg_bottom = bottom > 0 ? screenwidth / bottom : 0;
			avg_left = left > 0 ? (screenheight - (size * (size_factor_top + size_factor_bottom))) / left : 0;
			avg_right = right > 0 ? (screenheight - (size * (size_factor_top + size_factor_bottom))) / right : 0;
			
			FillLEDArray(ledsum);
			for (int i = 0; i < ledshift; i++)
				leds = LEDArrayShiftLeft(leds);
			
			for (int i = 0; i > ledshift; i--)
				leds = LEDArrayShiftRight(leds);
			
			// Left Regions
			for (int i = 1; i < left+1; i++)
			{
				rest = i < remainder_left ? 1 : 0;
				regions.Add(new Region
				            {
				            	id = idcount,
				            	led_id = leds[idcount],
				            	color = Color.Black,

				            	rect = new Rectangle(0,
				            	                     i >= remainder_left ? screenheight - ((avg_left + rest) * i) - remainder_left - (size_factor_bottom > 0 ? size : 0) :
				            	                     screenheight - ((avg_left + rest) * i) - (size_factor_bottom > 0 ? size : 0),
				            	                     size,
				            	                     i >= remainder_left ? avg_left + rest+1 : avg_left + rest),
				            	channel = CalculateChannel(idcount),
				            });
				idcount++;
			}
			
			// Top Regions
			for (int i = 0; i < top; i++)
			{
				rest = i < remainder_top ? 1 : 0;
				regions.Add(new Region
				            {
				            	id = idcount,
				            	led_id = leds[idcount],
				            	color = Color.Black,
				            	rect = new Rectangle(i >= remainder_top ? ((avg_top + rest) * i) + remainder_top : (avg_top + rest) * i,
				            	                     0,
				            	                     avg_top + rest,
				            	                     size),
				            	channel = CalculateChannel(idcount),
				            });
				idcount++;
			}
						
			// Right Regions
			for (int i = 0; i < right; i++)
			{
				rest = i < remainder_right ? 1 : 0;
				regions.Add(new Region
				            {
				            	id = idcount,
				            	led_id = leds[idcount],
				            	color = Color.Black,
				            	rect = new Rectangle(screenwidth - size,
				            	                     i >= remainder_right ? ((avg_right + rest) * i) + remainder_right + (size_factor_top > 0 ? size : 0) : 
				            	                     	((avg_right + rest) * i) + (size_factor_top > 0 ? size : 0),
				            	                     size,
				            	                     avg_right + rest),
				            	channel = CalculateChannel(idcount),
				            });
				idcount++;
			}

	
			// Bottom Regions
			for (int i = 1; i < bottom+1; i++)
			{
				rest = i < remainder_bottom ? 1 : 0;
				regions.Add(new Region
				            {
				            	id = idcount,
				            	led_id = leds[idcount],
				            	color = Color.Black,
				            	rect = new Rectangle(i >= remainder_bottom ? screenwidth - ((avg_bottom + rest) * i) - remainder_bottom : screenwidth - ((avg_bottom + rest) * i),
				            	                     screenheight - size,
				            	                     i >= remainder_bottom ? avg_bottom + rest+1 : avg_bottom + rest,
				            	                     size),
				            	
				            	channel = CalculateChannel(idcount),
				            });
				idcount++;
			}
		}

		public static byte CalculateChannel(int ledsum)
		{ 
			if (ledsum >= 64 && ledsum < 128) {
				return 1;
			}
			if (ledsum >= 128) {
				return 2;
			}
			return 0;
		}
		
		public void FillLEDArray(int ledsum)
		{
			for (int i = 0; i < ledsum; i++)
			{
				leds[i] = i;
			}
		}
		
		public static int[] LEDArrayShiftLeft(int[] arr)
		{
			var temp = new int[arr.Length];
			for (int i = 0; i < arr.Length - 1; i++)
			{
				temp[i] = arr[i + 1];
			}
			temp[temp.Length - 1] = arr[0];
			return temp;
		}
		
		public static int[] LEDArrayShiftRight(int[] arr)
		{
			var temp = new int[arr.Length];
			for (int i = 1; i < arr.Length; i++)
			{
				temp[i] = arr[i - 1];
			}
			temp[0] = arr[temp.Length - 1];
			return temp;
		}
	}
}

