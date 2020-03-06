using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoboScout;
using RoboScout.API;
using Xamarin.Forms;

namespace RoboScout.Views.EventPages
{
    public class EventPage : ContentPage
    {
        public EventPage(string eventKey)
        {
            Event myEvent = RootPage.getData().updateEvent(eventKey);
            
            Title = myEvent.event_name;

            BackgroundColor = myTheme.MainWrapperBackgroundColor;

            var scrollView = new ScrollView
            {
                BackgroundColor = myTheme.BasePageColor,
            };

            // grid wrapper
            var grid_wrapper = new Grid { 
                Padding = 0,
            };
            grid_wrapper.RowDefinitions.Add( new RowDefinition { Height = new GridLength(200) });
            grid_wrapper.RowDefinitions.Add( new RowDefinition { Height = new GridLength(200) });


            // social header
            var social_header = new Grid
            {
                //HeightRequest = 100,
                BackgroundColor = Color.FromHex("#2b2b2b"),
                Padding = 0
            };
            grid_wrapper.Children.Add(social_header, 0, 0);



            // username & descrip
            var username_stack = new StackLayout
            {
                Spacing = 15,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            social_header.Children.Add( username_stack );

            var label_event_name = new Label
            {
                Text = myEvent.event_name,
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Center,
                VerticalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                FontSize = 22
            };

            var label_event_descrip = new Label
            {
                Text = myEvent.location_string,
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Center,
                VerticalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 18
            };

            var label_space = new Label
            {
                Text = " ",
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Center,
                VerticalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 22
            };
            username_stack.Children.Add(label_event_name);
            username_stack.Children.Add(label_event_descrip);
            username_stack.Children.Add(label_space);


            // toolbar
            var toolbar = new Grid
            {
                VerticalOptions = LayoutOptions.End,
                Padding = 15,
                // style??????????
                BackgroundColor = Color.FromHex("#141414"),
            };
            toolbar.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            toolbar.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // toolbar stack layout
            var toolbar_stacklayout_teams = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Spacing = 15
            };
            toolbar.Children.Add(toolbar_stacklayout_teams, 0, 0);

            var tool_teams = new Label
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Teams: ",
                // font family
                // text color
                FontSize = 15
            };

            var tool_teams_result = new Label
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = myEvent.alliance_count.ToString(),
                Margin = new Thickness(6, 0),
                // text colors
                FontSize = 15
            };
            toolbar_stacklayout_teams.Children.Add(tool_teams);
            toolbar_stacklayout_teams.Children.Add(tool_teams_result);

            // toolbar stacklayout
            var toolbar_stacklayout_location = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Spacing = 15
            };
            toolbar.Children.Add(toolbar_stacklayout_location);

            var tool_location = new Label
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = myEvent.location_string,
                // text color
                FontSize = 15
            };
            
            toolbar.Children.Add(tool_location, 1, 0);

            social_header.Children.Add(toolbar);

            scrollView.Content = grid_wrapper;
            this.Content = scrollView;
        }
    }
}