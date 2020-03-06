using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using RoboScout.API;
using RoboScout.Views;
using RoboScout.Views.Navigation;
using RoboScout.API.secrets;

namespace RoboScout
{

	public partial class RootPage : MasterDetailPage
	{

		MasterPageCS masterPage;

		public RootPage()
		{
			InitializeComponent();

			masterPage = new MasterPageCS();
			Master = masterPage;
			Detail = new NavigationPage(new EventList());

			masterPage.listView.ItemSelected += OnItemSelected;
		}

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as MasterPageItem;
			if (item != null)
			{
				Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
				masterPage.listView.SelectedItem = null;
				IsPresented = false;
			}
		}

		internal static secrets getSecrets()
		{
			secrets mySecrets = new secrets();
			return mySecrets;
		}

		internal static api getData()
		{
			api myData = new api();
			return myData;
		}
	}
}