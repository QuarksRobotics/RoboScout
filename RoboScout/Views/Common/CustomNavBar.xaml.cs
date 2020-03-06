using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RoboScout
{
	public partial class CustomNavBar : ContentView
	{
		public CustomNavBar ()
		{
			InitializeComponent ();
		}

		public void OnHamburgerIconTapped(Object sender, EventArgs e)
		{
			var currentPage = App.Current.MainPage;
			var master = currentPage as MasterDetailPage;
			master.IsPresented = true;
		}
		/*
		public async void OnCogIconTapped(Object sender, EventArgs e)
		{
			await NaviateTo( new SettingsPage() );
		}
		*/
		private async Task NaviateTo(Page page)
		{
			// Android-only workaround: when navigating to a page with nav bar from one
			// with a custom nav bar we need to hide the nav bar during the navigation 
			// to avoid the displaying both bars at the same time for a short period
			if (Device.RuntimePlatform == Device.Android)
			{
				NavigationPage.SetHasNavigationBar(page, false);

				await Navigation.PushAsync(page, animated: false);

				NavigationPage.SetHasNavigationBar(page, true);
			}
			else
			{
				await Navigation.PushAsync(page);
			}
		}
	}
}

