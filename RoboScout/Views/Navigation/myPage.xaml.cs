using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RoboScout.API;

namespace RoboScout.Views
{
    public partial class myPage : ContentPage
    {
        public myPage()
        {
            InitializeComponent();
            // put whatever you want in result to have it print
            debugButton.Text = "";
        }
    }
}