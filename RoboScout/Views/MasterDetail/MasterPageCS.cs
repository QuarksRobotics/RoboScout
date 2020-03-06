using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace RoboScout.Views.Navigation
{
    public class MasterPageCS : ContentPage
    {
        public ListView ListView { get { return listView; } }

        public ListView listView;
        public MasterPageCS()
        {
            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Events",
                //IconSource = "contacts.png",
                TargetType = typeof(EventList)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Teams",
                //IconSource = "todo.png",
                TargetType = typeof(myPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Scouting",
                //IconSource = "reminders.png",
                TargetType = typeof(WelcomeStarterPage)
            });

            listView = new ListView
            {
                ItemsSource = masterPageItems,
                ItemTemplate = new DataTemplate(() =>
                {
                    var grid = new Grid { Padding = new Thickness(15, 10) };
                    //grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(30) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

                    //var image = new Image();
                    //image.SetBinding(Image.SourceProperty, "IconSource");
                    var label = new Label { VerticalOptions = LayoutOptions.FillAndExpand };
                    label.SetBinding(Label.TextProperty, "Title");

                    //grid.Children.Add(image);
                    grid.Children.Add(label, 0, 0);

                    return new ViewCell { View = grid };
                }),
                SeparatorVisibility = SeparatorVisibility.None
            };

            IconImageSource = "hamburger.png";
            Title = "Personal Organiser";
            Padding = new Thickness(0, 40, 0, 0);
            Content = new StackLayout
            {
                Children = { listView }
            };
        }
    }
}