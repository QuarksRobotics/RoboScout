using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RoboScout
{
	public partial class SocialVariantPage : ContentPage
	{
		public SocialVariantPage()
		{
			InitializeComponent();

			BindingContext = new SocialViewModel();
		}
	}
}