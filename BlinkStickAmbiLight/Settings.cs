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
using System.IO;
using System.Windows.Forms;

using Newtonsoft.Json;

namespace BlinkStickAmbiLight
{
	public class globalsettings
	{		
		string device = "";
		
		public string Device {
			get { return device; }
			set { device = value; }
		}

		bool connectFirstDevice = true;
		
		public bool ConnectFirstDevice {
			get { return connectFirstDevice; }
			set { connectFirstDevice = value; }
		}
		
		Color basicColor = Color.Red;
		
		public Color BasicColor {
			get { return basicColor; }
			set { basicColor = value; }
		}
		
		int brightness = 100;
		
		public int Brightness {
			get { return brightness; }
			set { brightness = value; }
		}
		
		int regionsTop = 10;
		
		public int RegionsTop {
			get { return regionsTop; }
			set { regionsTop = value; }
		}

		int regionsBottom = 10;
		
		public int RegionsBottom {
			get { return regionsBottom; }
			set { regionsBottom = value; }
		}

		int regionsLeft = 6;
		
		public int RegionsLeft {
			get { return regionsLeft; }
			set { regionsLeft = value; }
		}

		int regionsRight = 6;
		
		public int RegionsRight {
			get { return regionsRight; }
			set { regionsRight = value; }
		}

		int size = 30;
		
		public int Size {
			get { return size; }
			set { size = value; }
		}

		int shift = 0;
		
		public int Shift {
			get { return shift; }
			set { shift = value; }
		}
		
		bool transparent = false;
		
		public bool Transparent {
			get { return transparent; }
			set { transparent = value; }
		}
		
		public enum LightTypes { AmbilightRegion, AmbilightScreen, Morph, Static }
		
		LightTypes lighttype = LightTypes.AmbilightRegion;
		
		public globalsettings.LightTypes Lighttype {
			get { return lighttype; }
			set { lighttype = value; }
		}
		
		bool refreshPreview = true;
		
		public bool RefreshPreview {
			get { return refreshPreview; }
			set { refreshPreview = value; }
		}		
	}
	
	// Helper class
	public class jsonsettings
	{
		public globalsettings globalsettings { get; set; }
	}

	public static class settings
	{
		public static string AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		public static string SubDataFolder = Path.Combine(AppDataFolder, "BlinkStickAmbiLight");
		
		/// <summary>
        /// Save settings to .json file
        /// </summary>
        /// <param name="glob">settings object</param>
		public static void SaveDat(globalsettings glob)
		{
			var xm = new jsonsettings
			{
				globalsettings = glob,
			};

			string json = JsonConvert.SerializeObject(xm, Formatting.Indented);


			if(!Directory.Exists(SubDataFolder))
				Directory.CreateDirectory(SubDataFolder);
			File.WriteAllText(Path.Combine(SubDataFolder, "settings.json"), json);
		}
		
		/// <summary>
        /// Load settings from .json file
        /// </summary>
		public static jsonsettings LoadDat()
		{
			if (File.Exists(Path.Combine(SubDataFolder, "settings.json")))
			{
				try
				{
					jsonsettings xm = JsonConvert.DeserializeObject<jsonsettings>(File.ReadAllText(Path.Combine(SubDataFolder, "settings.json")));
					return xm;
				}
				catch (Exception)
				{
					MessageBox.Show("Error on serializing settings.json");
					Application.Exit();
					return null;
				}
			}
			else
			{
				var jm = new jsonsettings();
				var glob = new globalsettings();
				SaveDat(glob);
				return null;
			}
		}		
	}
}

