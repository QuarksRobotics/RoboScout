using System;
using System.Collections.Generic;
using System.Text;

namespace RoboScout.API
{
    class Report
    {
        public int team_key { get; set; }
        public int report_key { get; set; }
        public string event_key { get; set; }
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

        public Report()
        {

        }

        public Report(int _team_key, int _report_key, string _event_key, int _auto_points, int _auto_skystone_delv, int _auto_skystone_delv_points, int _auto_stone_delv, int _auto_stone_delv_points, bool _auto_repositioning, int _auto_placing, int _auto_placing_points, bool _auto_navigating, int _tele_points, int _tele_stone_delv, int _tele_stone_delv_points, int _tele_stone_placing, int _tele_stone_placing_points, int _end_points, int _end_tallest_sky, int _end_tallest_sky_points ,bool _end_capped, int _end_capped_lv, bool _end_capping_points, bool _end_foundation, bool _parking, int _penalties)
        {
            team_key = _team_key;
            report_key = _report_key;
            event_key = _event_key;
            auto_points = _auto_points;
            auto_skystone_delv = _auto_skystone_delv;
            auto_skystone_delv_points = _auto_skystone_delv_points;
            auto_stone_delv = _auto_stone_delv;
            auto_stone_delv_points = _auto_stone_delv_points;
            auto_repositioning = _auto_repositioning;
            auto_placing = _auto_placing;
            auto_placing_points = _auto_placing_points;
            auto_navigating = _auto_navigating;
            tele_points = _tele_points;
            tele_stone_delv = _tele_stone_delv;
            tele_stone_delv_points = _tele_stone_delv_points;
            tele_stone_placing = _tele_stone_placing;
            tele_stone_placing_points = _tele_stone_placing_points;
            end_points = _end_points;
            end_tallest_sky = _end_tallest_sky;
            end_tallest_sky_points = _end_tallest_sky_points;
            end_capped = _end_capped;
            end_capped_lv = _end_capped_lv;
            end_capping_points = _end_capping_points;
            end_foundation = _end_foundation;
            parking = _parking;
            penalties = _penalties;

        }
    }
}
