using System;
using System.Collections.Generic;
using System.Text;
using RoboScout;
using Xamarin.Forms;

namespace RoboScout.API
{
    class Team
    {
        public string team_key { get; set; }
        public string region_key { get; set; }
        public string league_key { get; set; }
        public int team_number { get; set; }
        public string team_name_short { get; set; }
        public string team_name_long { get; set; }
        public string robot_name { get; set; }
        public int last_active { get; set; }
        public string city { get; set; }
        public string state_prov { get; set; }
        public int zip_code { get; set; }
        public string country { get; set; }
        public int rookie_year { get; set; }
        public string website { get; set; }
        public Color BackgroundColor_ { get; set; }
    }
}
