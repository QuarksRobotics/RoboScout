using System;
using System.Collections.Generic;
using System.Text;

namespace RoboScout.API
{
    class EventParticipant
    {
        public string event_participant_key { get; set; }
        public string event_key { get; set; }
        public string team_key { get; set; }
        public bool is_active { get; set; }
        public string card_status { get; set; }
        public Team team { get; set; }
        public Event eventID { get; set; }
        public bool is_league_team { get; set; }
        public string league_team_name { get; set; }
    }
}
