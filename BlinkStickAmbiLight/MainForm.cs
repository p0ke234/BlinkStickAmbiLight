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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

using log4net;

namespace BlinkStickAmbiLight
{
	public partial class MainForm : Form
	{		
		private static readonly ILog log = LogManager.GetLogger(typeof(MainForm));
		RegionFrame rf;
		bool valueRefresh = false;
		public globalsettings glob;
		public AboutForm about;
		public Rectangle ScreenRect;
		public Color currentcolor;
		
		public MainForm()
		{
			log4net.Config.XmlConfigurator.Configure();
			log.Info("Starting BlinkStick Ambilight v." + Application.ProductVersion);
			foreach(var screen in Screen.AllScreens)
			{
				log.Debug("Screen (" + screen.DeviceName + ") Resolution: " + screen.WorkingArea.Width.ToString() + " / "
				          + screen.WorkingArea.Height.ToString());
			}
			try
			{
				DXInit();
			}
			catch (Exception ex)
			{
				log.Debug(ex.Message);
			}
			InitializeComponent();
			
			about = new AboutForm();
			currentcolor = new Color();
			
			this.Text = "BlinkStick AmbiLight v." + Application.ProductVersion + " (c) by René Kannegießer";
									
			glob = new globalsettings();
			pbPreview.Width = Screen.AllScreens[iScreen].Bounds.Width / preview_factor;
			pbPreview.Height = Screen.AllScreens[iScreen].Bounds.Height / preview_factor;
			pbPreview.SizeMode = PictureBoxSizeMode.StretchImage;
			
			ScreenRect = new Rectangle(0,0, Screen.AllScreens[iScreen].Bounds.Width / preview_factor,
			                            Screen.AllScreens[iScreen].Bounds.Height / preview_factor);		
			
			this.Height = 484; //pbPreview.Height + 100;
			this.Width = pbPreview.Width + 260;
			grpScreenPreview.Text = "Screen Preview (Resolution: " + Screen.AllScreens[iScreen].Bounds.Width.ToString() + 
									" x " + Screen.AllScreens[iScreen].Bounds.Height.ToString() + ")";

			if (settings.LoadDat() == null)
			{
				glob = new globalsettings();
				FillSettings();
			}
			else
				glob = settings.LoadDat().globalsettings;
					
			rf = new RegionFrame((int)nud_top.Value,
			                     (int)nud_bottom.Value, 
			                     (int)nud_left.Value, 
			                     (int)nud_right.Value, 
			                     pbPreview.Width, 
			                     pbPreview.Height, 
			                     (int)nud_size.Value, 
			                     (int)nud_shift.Value);
					
			FillControls();
					
			if (cb_ConnectFirst.Checked)
				RefreshDevices();
			if (!IsDebug)
				OpenDevice(comboBox1.Text);
			valueRefresh = true;
			RefreshPreview();
		}		
		
		/// <summary>
        /// Fill settings with control values and save
        /// </summary>
		public void FillSettings()
		{
			glob.Device = comboBox1.Text;
			glob.ConnectFirstDevice = cb_ConnectFirst.Checked;
			glob.RegionsTop = (int)nud_top.Value;
			glob.RegionsBottom = (int)nud_bottom.Value;
			glob.RegionsLeft = (int)nud_left.Value;
			glob.RegionsRight = (int)nud_right.Value;
			glob.Size = (int)nud_size.Value;
			glob.Shift = (int)nud_shift.Value;
			glob.Transparent = cbTransparent.Checked;
			glob.Brightness = (int)nud_brightness.Value;
			glob.BasicColor = btnBasicColor.BackColor;
			glob.RefreshPreview = cbPreview.Checked;
			settings.SaveDat(glob);
		}
		
		/// <summary>
        /// Fill controls with setting property values
        /// </summary>
		public void FillControls()
		{
			comboBox1.Text = glob.Device;
			cb_ConnectFirst.Checked = glob.ConnectFirstDevice;
			nud_top.Value = glob.RegionsTop;
			nud_bottom.Value = glob.RegionsBottom;
			nud_left.Value = glob.RegionsLeft;
			nud_right.Value = glob.RegionsRight;
			nud_size.Value = glob.Size;
			nud_shift.Value = glob.Shift;
			cbTransparent.Checked = glob.Transparent;
			nud_brightness.Value = glob.Brightness;
			btnBasicColor.BackColor = glob.BasicColor;
			cbPreview.Checked = glob.RefreshPreview;
			switch(glob.Lighttype)
			{
				case globalsettings.LightTypes.AmbilightScreen:
					rbAmbilightScreen.Checked = true;
					break;
				case globalsettings.LightTypes.Static:
					rbStaticColor.Checked = true;
					break;
				case globalsettings.LightTypes.AmbilightRegion:
				default:
					rbAmbilightRegion.Checked = true;
					break;
			}
			
		}

#region Alternative Average Color Calculations
		
//		private System.Drawing.Color CalculateAverageColor(Bitmap bm, Rectangle rect)
//		{
//			bm = CropImage(bm, rect);
//			int width = bm.Width;
//			int height = bm.Height;
//			int red = 0;
//			int green = 0;
//			int blue = 0;
//			int minDiversion = 15; // drop pixels that do not differ by at least minDiversion between color values (white, gray or black)
//			int dropped = 0; // keep track of dropped pixels
//			long[] totals = new long[] { 0, 0, 0 };
//			int bppModifier = bm.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb ? 3 : 4; // cutting corners, will fail on anything else but 32 and 24 bit images
//
//			BitmapData srcData = bm.LockBits(new System.Drawing.Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadOnly, bm.PixelFormat);
//			int stride = srcData.Stride;
//			IntPtr Scan0 = srcData.Scan0;
//
//			unsafe
//			{
//				byte* p = (byte*)(void*)Scan0;
//
//				for (int y = 0; y < height; y++)
//				{
//					for (int x = 0; x < width; x++)
//					{
//						int idx = (y * stride) + x * bppModifier;
//						red = p[idx + 2];
//						green = p[idx + 1];
//						blue = p[idx];
//						if (Math.Abs(red - green) > minDiversion || Math.Abs(red - blue) > minDiversion || Math.Abs(green - blue) > minDiversion)
//						{
//							totals[2] += red;
//							totals[1] += green;
//							totals[0] += blue;
//						}
//						else
//						{
//							dropped++;
//						}
//					}
//				}
//			}
//
//			int count = width * height - dropped;
//			int avgR = count > 0 ? (int)(totals[2] / count) : 1;
//			int avgG = count > 0 ? (int)(totals[1] / count) : 1;
//			int avgB = count > 0 ? (int)(totals[0] / count) : 1;
//
//			return System.Drawing.Color.FromArgb(avgR, avgG, avgB);
//		}
		
//		public Color getDominantColor(Bitmap orig, Rectangle rect)
//		{
//			orig = CropImage(orig, rect);
//			var fastbmp = new FastBitmap(orig);
//			//Used for tally
//			int r = 0;
//			int g = 0;
//			int b = 0;
//
//			int total = 0;
//
//			for (int x = 0; x < fastbmp.Width; x++)
//			{
//				for (int y = 0; y < fastbmp.Height; y++)
//				{
//					Color clr = fastbmp.GetPixel(x, y);
//
//					r += clr.R;
//					g += clr.G;
//					b += clr.B;
//
//					total++;
//				}
//			}
//
//			//Calculate average
//			r /= total;
//			g /= total;
//			b /= total;
//
//			return Color.FromArgb(r, g, b);
//		}

#endregion

		
		/// <summary>
        /// Calculate average color
        /// </summary>
        /// <param name="bmp_source">Bitmap to calculate color from</param>
        /// <param name="rect">Part of the bitmap</param>
		public Color GetAverageColor(Bitmap bmp_source, Rectangle rect)
		{
			Bitmap regionBitmap = CropImage(bmp_source, rect);
            Color color = GetAverageColor(regionBitmap);
            regionBitmap.Dispose();        
            return color;
		}

		/// <summary>
        /// Calculate average color
        /// </summary>
        /// <param name="bmp_source">Bitmap to calculate color from</param>		
		public Color GetAverageColor(Bitmap bmp_source)
		{
			var bmp = new Bitmap(1, 1);
			using (Graphics g = Graphics.FromImage(bmp))
			{
				// updated: the Interpolation mode needs to be set to
				// HighQualityBilinear or HighQualityBicubic or this method
				// doesn't work at all.  With either setting, the results are
				// slightly different from the averaging method.
				g.InterpolationMode = InterpolationMode.HighQualityBilinear;
				g.DrawImage(bmp_source, new Rectangle(0, 0, 1, 1));
			}
			Color pixel = bmp.GetPixel(0, 0);
			// pixel will contain average values for entire orig Bitmap
			bmp.Dispose();
			return pixel;
		}
		
		/// <summary>
        /// Build the region frame
        /// </summary>
        /// <param name="bmp_source">Bitmap to calculate color from</param>
        /// <param name="rect">Rectangle to crop</param>
		public Bitmap CropImage(Bitmap bmp_source, Rectangle rect)
		{
			var bmp = new Bitmap(rect.Width, rect.Height);
			using (Graphics g = Graphics.FromImage(bmp))
			{
				g.DrawImage(bmp_source, 0, 0, rect, GraphicsUnit.Pixel);
			}
			return bmp;
		}

        private Rectangle GetScreenRect() 
        {
        	return Screen.AllScreens[iScreen].Bounds;
        }
        
        private void CalculateDXRegions()
        {
//			var sw = new Stopwatch();
//			sw.Start();
        	if (glob.Lighttype != globalsettings.LightTypes.Static)
        	{
                if (DXScreen!=null)
                {
                    DXScreen.Dispose();
                }
                
                DXScreen = GetImage(GetScreenRect());
        		SetColors();
        	}
        	if (cbPreview.Checked)
        	{

                if (DXScreen != null)
                {
                    DXScreen.Dispose();
                }

                DXScreen = GetImage(GetScreenRect());
        		SetColors();
        		pbPreview.Image = DXScreen;
        	}
//			sw.Stop();
//			Debug.WriteLine((1000 / sw.ElapsedMilliseconds).ToString());
        }
				
		public void RefreshPreview()
		{
			if (nud_top.Value + nud_bottom.Value + nud_left.Value + nud_right.Value > LEDLimit)
				MessageBox.Show("More than 64 LEDs are not supported!");
			rf.regions.Clear();

			rf = new RegionFrame((int)nud_top.Value,
			                     (int)nud_bottom.Value, 
			                     (int)nud_left.Value, 
			                     (int)nud_right.Value, pbPreview.Width, pbPreview.Height, (int)nud_size.Value, (int)nud_shift.Value);
			CalculateDXRegions();
			SetColors();
			pbPreview.Image = DXScreen;
		}
		
		/// <summary>
        /// Set color for any region
        /// </summary>
		private void SetColors()
		{
			var sw = new Stopwatch();
			sw.Start();
            byte r;
            byte g;
            byte b;
			currentcolor = Color.Black;
			if (glob.Lighttype == globalsettings.LightTypes.AmbilightScreen)
				currentcolor = GetAverageColor(DXScreen);
			data_leds.Clear();
			
			foreach(var region in rf.regions.OrderBy(o => o.led_id))
			{
				var bigrect = region.rect;
				switch(glob.Lighttype)
				{
					case globalsettings.LightTypes.Static:
						currentcolor = btnBasicColor.BackColor;
						break;
					case globalsettings.LightTypes.AmbilightScreen:
						break;
					case globalsettings.LightTypes.AmbilightRegion:
					default:
						currentcolor = GetAverageColor(DXScreen, bigrect);
						break;
				}
				region.color = currentcolor;
				
				if (glob.Brightness < 100 && glob.Brightness >= 0)
				{
					r = (byte)(glob.Brightness / 100.0 * currentcolor.R);
					g = (byte)(glob.Brightness / 100.0 * currentcolor.G);
					b = (byte)(glob.Brightness / 100.0 * currentcolor.B);
				}
				else
				{
					r = currentcolor.R;
					g = currentcolor.G;
					b = currentcolor.B;
				}
				
				data_leds.Add(g);
				data_leds.Add(r);
				data_leds.Add(b);
			}
			if (isOpen)
				blink.SetColors(0, data_leds.ToArray());
			sw.Stop();
			//Debug.WriteLine(sw.ElapsedMilliseconds.ToString());
		}

		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (!IsDebug)
			{
				e.Cancel = true;
				this.Hide();
			}
			cbPreview.Checked = false;
			FillSettings();
		}
		
		void PbPreviewPaint(object sender, PaintEventArgs e)
		{
			CreatePixelRects(e.Graphics);
			lb_FPS.Text = CalculateFrameRate().ToString();
		}
		
		void BtnRefreshBSClick(object sender, EventArgs e)
		{
			RefreshDevices();
		}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (isOpen)
				blink.SetColors(0, data_off);
			}
			catch (Exception) {};
			if (!IsDebug)
				OpenDevice(comboBox1.Text);
		}
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			DisposeAll();
		}
		
		public void DisposeAll()
		{
			ToggleThread(false);
			Thread.Sleep(100);
			try
			{
				if (isOpen)
					blink.SetColors(0, data_off);
			}
			catch (Exception) {};
			FillSettings();
			log.Info("Stopped BlinkStick Ambilight");
			s.Dispose();
			d.Dispose();
			notifyIcon1.Dispose();
			this.Close();
			Dispose();
			Application.Exit();
		}
		
		void Mi_ShowSettingsClick(object sender, EventArgs e)
		{
			this.Show();
		}
		
		void NotifyIcon1MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Show();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			cbPreview.Checked = false;
			foreach(var region in rf.regions)
			{
				region.color = Color.White;
			}
			pbPreview.Refresh();
		}
		
		void TsExitClick(object sender, EventArgs e)
		{
			DisposeAll();
		}
		
		void Nud_topValueChanged(object sender, EventArgs e)
		{
			if (valueRefresh)
				RefreshPreview();
		}
		
		void Nud_bottomValueChanged(object sender, EventArgs e)
		{
			if (valueRefresh)
				RefreshPreview();
		}
		
		void Nud_leftValueChanged(object sender, EventArgs e)
		{
			if (valueRefresh)
				RefreshPreview();
		}
		
		void Nud_rightValueChanged(object sender, EventArgs e)
		{
			if (valueRefresh)
				RefreshPreview();
		}
		
		void Nud_sizeValueChanged(object sender, EventArgs e)
		{
			if (valueRefresh)
				RefreshPreview();
		}
		
		void Nud_shiftValueChanged(object sender, EventArgs e)
		{
			if (valueRefresh)
				RefreshPreview();
		}
		
		void TsAboutClick(object sender, EventArgs e)
		{
			about.Show();
		}

#region Switch Mode		
		void RbAmbilightClick(object sender, EventArgs e)
		{
			glob.Lighttype = globalsettings.LightTypes.AmbilightRegion;
			RefreshPreview();
		}

		void RbAmbilightScreenClick(object sender, EventArgs e)
		{
			glob.Lighttype = globalsettings.LightTypes.AmbilightScreen;
			RefreshPreview();
		}
		
		void RbStaticColorClick(object sender, EventArgs e)
		{
			glob.Lighttype = globalsettings.LightTypes.Static;
			RefreshPreview();
		}
#endregion

		void BtnBasicColorClick(object sender, EventArgs e)
		{
			colorDialog1.ShowDialog();
			btnBasicColor.BackColor = colorDialog1.Color;
			RefreshPreview();
		}
		
		void PbPreviewMouseClick(object sender, MouseEventArgs e)
		{
			foreach(var region in rf.regions)
			{
				if (region.rect.Contains(e.Location))
					Debug.WriteLine(region.led_id.ToString());
			}
		}
		
		void Nud_brightnessValueChanged(object sender, EventArgs e)
		{
			glob.Brightness = (int)nud_brightness.Value;
		}
		
		void MainFormShown(object sender, EventArgs e)
		{
			ToggleThread(true);
		}
	}
}
