using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xamarin.Forms;

namespace RoboScout.API
{
    class Event
    {
        public string event_key { get; set; }
        public string season_key { get; set; }
        public string region_key { get; set; }
        public string league_key { get; set; }
        public string event_code { get; set; }
        public string event_type_key { get; set; }
        public int event_region_number { get; set; }
        public int division_key { get; set; }
        public string division_name { get; set; }
        public string event_name { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string week_key { get; set; }
        public string city { get; set; }
        public string state_prov { get; set; }
        public string venue { get; set; }
        public string website { get; set; }
        public string timezone { get; set; }
        public bool is_active { get; set; }
        public bool is_public { get; set; }
        public int active_tournament_level { get; set; }
        public int alliance_count { get; set; }
        public int field_count { get; set; }
        public int advance_spots { get; set; }
        public string advance_event { get; set; }
        public int data_source { get; set; }
        public int team_count { get; set; }
        public int match_count { get; set; }
        public Color BackgroundColor_ { get; set; }
        public String location_string { get { return city + ", " + state_prov; } }
    }
}
