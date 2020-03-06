using System;
using System.Collections.Generic;
using System.Text;

namespace RoboScout.API
{
    class Report
    {
        public int team_key { get; set; }
        public int report_key { get; set; }
        // === Auto === //
        public int auto_points { get; set; } // //
        public int auto_skystone_delv { get; set; }
        public int auto_skystone_delv_points { get; set; } //
        public int auto_stone_delv { get; set; }
        public int auto_stone_delv_points { get; set; } //
        public bool auto_repositioning { get; set; }
        public int auto_placing { get; set; }
        public int auto_placing_points { get; set; } //
        public bool auto_navigating { get; set; }
        // === Tele-Op === //
        public int tele_points { get; set; } // //
        public int tele_stone_delv { get; set; }
        public int tele_stone_delv_points { get; set; } //
        public int tele_stone_placing { get; set; }
        public int tele_stone_placing_points { get; set; } //
        // === End === //
        public int end_points { get; set; } // //
        public int end_tallest_sky { get; set; }
        public int end_tallest_sky_points { get; set; } //
        public bool end_capped { get; set; }
        public int end_capped_lv { get; set; }
        public bool end_capping_points { get; set; } //
        public bool end_foundation { get; set; }
        public bool parking { get; set; }
        public int penalties { get; set; }
    }
}
