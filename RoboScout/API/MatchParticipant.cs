using System;
using System.Collections.Generic;
using System.Text;

namespace RoboScout.API
{
    class MatchParticipant
    {
        public string match_participant_key { get; set; }
        public string match_key { get; set; }
        public string team_key { get; set; }
        public int station { get; set; }
        public int station_status { get; set; }
        public int ref_status { get; set; }
        public Team team { get; set; }
        public bool is_league_team { get; set; }
    }
}
