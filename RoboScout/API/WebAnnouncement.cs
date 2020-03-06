using System;
using System.Collections.Generic;
using System.Text;

namespace RoboScout.API
{
    class WebAnnouncement
    {
        public int announcement_key { get; set; }
        public int title { get; set; }
        public int publish_date { get; set; }
        public bool is_active { get; set; }
        public string text { get; set; }
        public string author { get; set; }
    }
}
