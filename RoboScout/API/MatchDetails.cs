using System;
using System.Collections.Generic;
using System.Text;

namespace RoboScout.API
{
    class MatchDetails
    {
        public string match_detail_key { get; set; }
        public string match_key { get; set; }
        public int red_min_pen { get; set; }
        public int blue_min_pen { get; set; }
        public int red_maj_pen { get; set; }
        public int blue_maj_pen { get; set; }
    }
}
