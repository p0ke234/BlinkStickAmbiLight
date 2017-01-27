/*
 * Created by SharpDevelop.
 * User: p0ke
 * Date: 25.10.2016
 * Time: 19:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using SlimDX;
using SlimDX.Direct3D9;

namespace BlinkStickAmbiLight
{
	public partial class MainForm : Form
	{
		Device d;
		Surface s;
		Bitmap DXScreen;
		DataStream ds;
		
		private void DXInit()
		{						
//			// GraphicsDeviceManager is mandatory for a Toolkit Game
//			_graphicsDeviceManager = new GraphicsDeviceManager(this);
//			// disable vsync
//			_graphicsDeviceManager.SynchronizeWithVerticalRetrace = false;
//			// disable fixed timestep
//			this.IsFixedTimeStep = false;
			var present_params = new PresentParameters();
            present_params.Windowed = true;
            present_params.SwapEffect = SwapEffect.Discard;
            present_params.BackBufferCount = 1;
            // Verbessert ggf. die gemeldet schlechten Frameraten
            present_params.PresentationInterval = PresentInterval.Immediate;
            //present_params.FullScreenRefreshRateInHertz = 0;
            present_params.BackBufferHeight = Screen.AllScreens[iScreen].WorkingArea.Height;
            present_params.BackBufferWidth = Screen.AllScreens[iScreen].WorkingArea.Width;
			d = new Device(new Direct3D(), 0, DeviceType.Hardware, IntPtr.Zero, CreateFlags.HardwareVertexProcessing, present_params);			
		}
		
		private Bitmap GetImage(Rectangle rect)
		{
			if (s == null)
			{			
				s = Surface.CreateOffscreenPlain(d, rect.Width, rect.Height, Format.A8R8G8B8, Pool.Scratch);
			}
			d.GetFrontBufferData(0, s);
			DataRectangle gsx = s.LockRectangle(rect, LockFlags.DoNotWait);		
			//Debug.WriteLine(CalculateStride(rect.Width, PixelFormat.Format32bppPArgb));
			//var bm = new Bitmap(rect.Width, rect.Height, CalculateStride(rect.Width, PixelFormat.Format32bppPArgb), PixelFormat.Format32bppPArgb, gsx.Data.DataPointer);
			var bm = new Bitmap(rect.Width, rect.Height, 7680, PixelFormat.Format32bppPArgb, gsx.Data.DataPointer);
			bm = (Bitmap)bm.GetThumbnailImage(pbPreview.Width = (Screen.AllScreens[iScreen].Bounds.Width) / preview_factor,
				                 pbPreview.Height = Screen.AllScreens[iScreen].Bounds.Height / preview_factor ,null, IntPtr.Zero);	
			//Debug.WriteLine(bm.Width.ToString() + " / " + bm.Height.ToString());
			ds = gsx.Data;
			s.UnlockRectangle();
			return bm;
		}			
		
		private int CalculateStride(int width, PixelFormat pf)
		{
			int BitsPerPixel = ((int)pf & 0xff00) >> 8;
			return 4 * ((width * BitsPerPixel + 31) / 32);
		}
		
//		private Bitmap ScreenShot()
//		{
//			using (Graphics g = Graphics.FromImage(bmpScreenCapture))
//			{
//				g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
//				                 Screen.PrimaryScreen.Bounds.Y,
//				                 0, 0,
//				                 bmpScreenCapture.Size,
//				                 CopyPixelOperation.SourceCopy);
//			}
//			return bmpScreenCapture;
//		}
		
	}
}
