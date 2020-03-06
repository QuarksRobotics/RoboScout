using System;
using System.Collections.Generic;
using System.Text;

namespace RoboScout.API
{
    class Media
    {
        public string media_key { get; set; }
        public string event_key { get; set; }
        public string team_key { get; set; }
        public int media_type { get; set; }
        public bool is_primary { get; set; }
        public string media_title { get; set; }
        public string link { get; set; }
    }
}
