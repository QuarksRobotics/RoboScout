using System;
using System.Collections.Generic;
using System.Text;

namespace RoboScout.API
{
    class AwardRecipient
    {
        public string awards_key { get; set; }
        public string event_key { get; set; }
        public string award_key { get; set; }
        public int team_key { get; set; }
        public string receiver_name { get; set; }
        public string award_name { get; set; }
        public Award award { get; set; }
        public Team team { get; set; }
    }
}
