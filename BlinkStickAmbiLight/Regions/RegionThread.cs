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
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace BlinkStickAmbiLight
{
	public partial class MainForm : Form
	{
		private Thread trd;	
		static readonly object lockobj = new object();
		
		public void ToggleThread(bool run)
		{
			Debug.WriteLine("Thread");
			try
			{
				// stop Thread if it is already running
				trd.Abort();
			}
			catch {};
			
			if (run)
			{
				trd = new Thread(new ThreadStart(RegionThread));
				trd.IsBackground = true;
				trd.Priority = ThreadPriority.AboveNormal;
				if (trd.IsAlive)
					trd.Join();
				else
					trd.Start();
			}
			else
			{
				try
				{
					trd.Abort();
				}
				catch {};
			}
		}
		
		static void Sleep(int ms)
		{
			new System.Threading.AutoResetEvent(false).WaitOne(ms);
		}

		private void RegionThread()
		{
			while (true)
			{
				Sleep(RefreshDXTime);
				if (cbPreview.Checked)
				{
					MethodInvoker Calculate = delegate
					{
						CalculateDXRegions();
					};
					try
					{
						Invoke(Calculate); 
					}
					catch (Exception) {}
				}
				else
				{
					CalculateDXRegions();
				}
			}
		}

		private static int lastTick;
		private static int lastFrameRate;
		private static int frameRate;
		
		public static int CalculateFrameRate()
		{
			if (System.Environment.TickCount - lastTick >= 1000)
			{
				lastFrameRate = frameRate;
				frameRate = 0;
				lastTick = System.Environment.TickCount;
			}
			frameRate++;
			return lastFrameRate;
		}
	}
}
