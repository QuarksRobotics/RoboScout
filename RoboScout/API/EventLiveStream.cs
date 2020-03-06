using System;
using System.Collections.Generic;
using System.Text;

namespace RoboScout.API
{
    class EventLiveStream
    {
        public string stream_key { get; set; }
        public string event_key { get; set; }
        public string channel_name { get; set; }
        public string stream_name { get; set; }
        public int stream_type { get; set; }
        public bool is_active { get; set; }
        public string url { get; set; }
        public string start_datetime { get; set; }
        public string end_datetime { get; set; }
        public int channel_url { get; set; }
    }
}
