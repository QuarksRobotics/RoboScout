using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using UXDivers.Artina.Shared;
using System.Collections.Generic;

namespace RoboScout
{
	public enum Theme
	{
		Light,
		Dark,
		Enterprise,
		Custom
	}

	public static class Settings
	{
		public static void SetTheme(Theme theme)
		{
			Device.BeginInvokeOnMainThread(() =>
			{
				Application.Current.Resources.MergedDictionaries.Clear();

				switch (theme)
				{
					case Theme.Dark:
						Application.Current.Resources.MergedDictionaries.Add(new GrialDarkTheme());
						break;
				}
			});
		}
	}
}
