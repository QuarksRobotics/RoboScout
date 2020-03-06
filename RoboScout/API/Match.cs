using System;
using System.Collections.Generic;
using System.Text;

namespace RoboScout.API
{
    class Match
    {
        public string match_key { get; set; }
        public string event_key { get; set; }
        public int tournament_level { get; set; }
        public string scheduled_time { get; set; }
        public string match_name { get; set; }
        public int play_number { get; set; }
        public int field_number { get; set; }
        public string prestart_time { get; set; }
        public string match_start_time { get; set; }
        public int prestart_count { get; set; }
        public string cycle_time { get; set; }
        public int red_score { get; set; }
        public int blue_score { get; set; }
        public int red_penalty { get; set; }
        public int blue_penalty { get; set; }
        public int red_auto_score { get; set; }
        public int blue_auto_score { get; set; }
        public int red_tele_score { get; set; }
        public int blue_tele_score { get; set; }
        public int red_end_score { get; set; }
        public int blue_end_score { get; set; }
        public int video_url { get; set; }
        public EventParticipant participants { get; set; } // models says type is EventParticipant[]
    }
}
