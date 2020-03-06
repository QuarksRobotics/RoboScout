using System;
using System.Collections.Generic;
using System.Text;

namespace RoboScout.API
{
    class EventInsights
    {
        public Match high_score_match { get; set; }
        public int average_match_score { get; set; }
        public int average_winning_score { get; set; }
        public int average_winning_margin { get; set; }
        public string game { get; set; }
    }
}
