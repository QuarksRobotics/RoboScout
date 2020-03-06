using System;
using System.Collections.Generic;
using System.Text;

namespace RoboScout.API
{
    class Ranking
    {
        public string rank_key { get; set; }
        public string event_key { get; set; }
        public string team_key { get; set; }
        public int rank { get; set; }
        public int rank_change { get; set; }
        public int opr { get; set; }
        public int wins { get; set; }
        public int loses { get; set; }
        public int ties { get; set; }
        public int highest_qual_score { get; set; }
        public int ranking_points { get; set; }
        public int qualifying_points { get; set; }
        public int tie_breaker_points { get; set; }
        public int disqualified { get; set; }
        public int played { get; set; }
        public Team team { get; set; }
    }
}
