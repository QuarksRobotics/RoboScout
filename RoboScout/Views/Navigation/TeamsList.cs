using RoboScout.API;
using RoboScout.Views.EventPages;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace RoboScout
{
	public partial class TeamsList : ContentPage
	{
		public TeamsList()
		{
			Title = "Events";

			var teamTemplate = new DataTemplate(() =>
			{

				var grid = new Grid
				{
					ColumnSpacing = 20,
					RowSpacing = 0,
					ColumnDefinitions = { new ColumnDefinition { Width = GridLength.Auto } },
					RowDefinitions = { new RowDefinition { Height = GridLength.Star }, new RowDefinition { Height = GridLength.Star } }
				};

				grid.SetBinding(Grid.BackgroundColorProperty, "BackgroundColor_");
				var eventNameLabel = new Label
				{
					VerticalTextAlignment = TextAlignment.End,
					HorizontalTextAlignment = TextAlignment.Start,
					Margin = new Thickness(12, 0, 0, 0),
					FontSize = 18
				};
				eventNameLabel.SetBinding(Label.TextProperty, "team_name_short");

				var eventLocationLabel = new Label
				{
					VerticalTextAlignment = TextAlignment.Start,
					HorizontalTextAlignment = TextAlignment.Start,
					FontSize = 16,
					Opacity = .5,
					FontAttributes = FontAttributes.Italic,
					Margin = new Thickness(12, 0, 0, 0)
				};
				eventLocationLabel.SetBinding(Label.TextProperty, "team_number");

				grid.Children.Add(eventNameLabel, 0, 0);
				grid.Children.Add(eventLocationLabel, 0, 1);

				var myCell = new ViewCell { View = grid };

				return myCell;
			});


			var myTeam = RootPage.getData().debugTeams(); // this is changed for debugging

			myTeam[0].BackgroundColor_ = Color.FromHex("#921243");

			var list = new ListView
			{
				SelectionMode = ListViewSelectionMode.Single,
				ItemsSource = myTeam,
				SeparatorVisibility = SeparatorVisibility.None,
				SeparatorColor = Color.Transparent,
				HasUnevenRows = false,
				RowHeight = 80, // figure onIdiom out
				ItemTemplate = teamTemplate,
			};

			list.ItemTapped += OnItemTapped;

			if (myTeam != null)
			{
				this.Content = new StackLayout
				{
					Children =
					{
						list
					}
				};
			}
			else
			{
				this.Content = new ContentView { Content = new Label { Text = "There Are No Teams", HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center } };
			}
		}

		private async void OnItemTapped(Object sender, ItemTappedEventArgs e)
		{
			var selectedItem = ((ListView)sender).SelectedItem;
			var selectedEvent = (Team)selectedItem;

			await Navigation.PushAsync(new TeamPage(selectedEvent.team_key)); // argument selectedEvent.event_key
		}
	}
}

