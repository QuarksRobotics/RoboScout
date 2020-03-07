using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Xamarin.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using RoboScout.API.secrets;

namespace RoboScout.API
{
    class api
    {

        public string TOA_URL = "https://theorangealliance.org/api/";
        public Alliance alliance = null;
        public Award award = null;
        public AwardRecipient awardRecipient = null;
        public Event event_ = null;
        public EventInsights eventInsights = null;
        public EventLiveStream eventLiveStream = null;
        public EventParticipant eventParticipant = null;
        public EventType eventType = null;
        public League league = null;
        public LeagueDiv leagueDiv = null;
        public Match match = null;
        public MatchDetails matchDetails = null;
        public MatchParticipant matchParticipant = null;
        public Media media = null;
        public Ranking ranking = null;
        public Region region = null;
        public Season season = null;
        public Team team = null;
        public TeamSeasonRecord teamSeasonRecord = null;
        public WebAnnouncement webAnnouncement = null;
        public String BackgroundColor_ = "#921243";

        public List<Alliance> _alliance; // might not be needed but there are here in case
        public List<Award> _award;
        public List<AwardRecipient> _awardRecipient;
        public List<Event> eventList;
        public List<EventInsights> _eventInsights;
        public List<EventLiveStream> _eventLiveStream;
        public List<EventParticipant> _eventParticipant;
        public List<EventType> _eventType;
        public List<League> _league;
        public List<LeagueDiv> _leagueDiv;
        public List<Match> _match;
        public List<MatchDetails> _matchDetails;
        public List<MatchParticipant> _matchParticipant;
        public List<Media> _media;
        public List<Ranking> _ranking;
        public List<Region> _region;
        public List<Season> _season;
        public List<Team> _team;
        public List<TeamSeasonRecord> _teamSeasonRecord;
        public List<WebAnnouncement> _webAnnouncement;

        JsonSerializerSettings settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

        public static string[] _colors =
        {
            "#921243",
            "#B31250",
            "#CD195E",
            "#56329A",
            "#6A40B9",
            "#7C4ECD",
            "#525ABB",
            "#5F7DD4",
            "#7B96E5"
        };

        // === Return The Object Stored === //
        public Alliance returnAlliance() { return alliance; }
        public Award returnAward() { return award; }
        public AwardRecipient returnAwardRecipient() { return awardRecipient; }
        public Event returnEvent() { return event_; }
        public EventInsights returnEventInsights() { return eventInsights; }
        public EventLiveStream returnEventLiveStream() { return eventLiveStream; }
        public EventParticipant returnEventParticipant() { return eventParticipant; }
        public EventType returnEventType() { return eventType; }
        public League returnLeague() { return league; }
        public LeagueDiv returnLeagueDiv() { return leagueDiv; }
        public Match returnMatch() { return match; }
        public MatchDetails returnMatchDetails() { return matchDetails; }
        public MatchParticipant returnMatchParticipant() { return matchParticipant; }
        public Media returnMedia() { return media; }
        public Ranking returnRanking() { return ranking; }
        public Region returnRegion() { return region; }
        public Season returnSeason() { return season; }
        public Team returnTeam() { return team; }
        public TeamSeasonRecord returnTeamSeasonRecord() { return teamSeasonRecord; }
        public WebAnnouncement returnWebAnnoucement() { return webAnnouncement; }


        // === Update & Return The Object Stored === //
        public Alliance updateAlliance(string eventKey) { parseAlliance(eventKey); return alliance; }
        public Award updateAward() { parseAward(); return award; }
        public AwardRecipient updateAwardRecipient(string eventKey) { parseAwardRecipient(eventKey); return awardRecipient; }
        public AwardRecipient updateAwardRecipient(string teamKey, string seasonKey) { parseAwardRecipient(teamKey, seasonKey); return awardRecipient; }
        public Event updateEvent(string eventKey = "") { parseEvent(eventKey); return event_; }
        public EventInsights updateEventInsights(string eventKey) { parseEventInsights(eventKey); return eventInsights; }
        public EventLiveStream updateEventLiveStream() { parseEventLiveStream(); return eventLiveStream; }
        public EventLiveStream updateEventLiveStream(string eventKey) { parseEventLiveStream(eventKey); return eventLiveStream; }
        public EventParticipant updateEventParticipant(string eventKey) { parseEventParticipant(eventKey); return eventParticipant; }
        public EventParticipant updateEventParticipant(string teamKey, string seasonKey) { parseEventParticipant(teamKey, seasonKey); return eventParticipant; }
        public EventType updateEventType() { parseEventType(); return eventType; }
        public League updateLeague() { parseLeague(); return league; }
        public League updateLeague(string leagueKey) { parseLeague(leagueKey); return league; }
        public LeagueDiv updateLeagueDiv() { parseLeagueDiv(); return leagueDiv; }
        public Match updateMatch(string key, bool matchKey) { parseMatch(key, matchKey); return match; }
        public MatchDetails updateMatchDetails(string key, bool matchKey) { parseMatchDetails(key, matchKey); return matchDetails; }
        public MatchParticipant updateMatchParticipant(string key, bool matchKey) { parseMatchParticipant(key, matchKey); return matchParticipant; }
        public MatchParticipant updateMatchParticipant(string teamKey, string seasonKey) { parseMatchParticipant(teamKey, seasonKey); return matchParticipant; }
        public Media updateMedia(string eventKey) { parseMedia(eventKey); return media; }
        public Ranking updateRanking(string eventKey) { parseRanking(eventKey); return ranking; }
        public Region updateRegion() { parseRegion(); return region; }
        public Season updateSeason() { parseSeason(); return season; }
        public Team updateTeam(string teamKey) { parseTeam(teamKey); return team; }
        public TeamSeasonRecord updateTeamSeasonRecord(string teamKey) { parseTeamSeasonRecord(teamKey); return teamSeasonRecord; }
        public WebAnnouncement updateWebAnnoucement() { parseWebAnnoucement(); return webAnnouncement; }
        public List<Event> updateTodaysEvents()
        {
            parseTodaysEvents();
            int i;
            if (eventList != null) {
                for (i = 0; i < eventList.Count && i < 8; i++)
                {
                    eventList[i].BackgroundColor_ = Color.FromHex(_colors[i]);
                }
            }
            return eventList;
        }




        // === Get and Parse Data === //
        public void parseAlliance(string eventKey) { alliance = JsonConvert.DeserializeObject<List<Alliance>>(getAlliance(eventKey))[0]; } // add this.alliance = PARSEHERE(getAlliance(eventKey))[0]
        public void parseAward() { award = JsonConvert.DeserializeObject<List<Award>>(getAward())[0]; }
        public void parseAwardRecipient(string eventKey) { awardRecipient = JsonConvert.DeserializeObject<List<AwardRecipient>>(getAwardRecipient(eventKey))[0]; }
        public void parseAwardRecipient(string teamKey, string seasonKey) { awardRecipient = JsonConvert.DeserializeObject<List<AwardRecipient>>(getAwardRecipient(teamKey, seasonKey))[0]; }
        public void parseEvent(string eventKey = "") { event_ = JsonConvert.DeserializeObject<List<Event>>(getEvent(eventKey))[0]; }
        public void parseEventInsights(string eventKey) { eventInsights = JsonConvert.DeserializeObject<List<EventInsights>>(getEventInsights(eventKey))[0]; }
        public void parseEventLiveStream() { eventLiveStream = JsonConvert.DeserializeObject<List<EventLiveStream>>(getEventLiveStream())[0]; }
        public void parseEventLiveStream(string eventKey) { eventLiveStream = JsonConvert.DeserializeObject<List<EventLiveStream>>(getEventLiveStream(eventKey))[0]; }
        public void parseEventParticipant(string eventKey) { eventParticipant = JsonConvert.DeserializeObject<List<EventParticipant>>(getEventParticipant(eventKey))[0]; }
        public void parseEventParticipant(string teamKey, string seasonKey) { eventParticipant = JsonConvert.DeserializeObject<List<EventParticipant>>(getEventParticipant(teamKey, seasonKey))[0]; }
        public void parseEventType() { eventType = JsonConvert.DeserializeObject<List<EventType>>(getEventType())[0]; }
        public void parseLeague() { league = JsonConvert.DeserializeObject<List<League>>(getLeague())[0]; }
        public void parseLeague(string leagueKey) { league = JsonConvert.DeserializeObject<List<League>>(getLeague(leagueKey))[0]; }
        public void parseLeagueDiv() { leagueDiv = JsonConvert.DeserializeObject<List<LeagueDiv>>(getLeagueDiv())[0]; }
        public void parseMatch(string key, bool matchKey) { match = JsonConvert.DeserializeObject<List<Match>>(getMatch(key, matchKey))[0]; }
        public void parseMatchDetails(string key, bool matchKey) { matchDetails = JsonConvert.DeserializeObject<List<MatchDetails>>(getMatchDetails(key, matchKey))[0]; }
        public void parseMatchParticipant(string key, bool matchKey) { matchParticipant = JsonConvert.DeserializeObject<List<MatchParticipant>>(getMatchParticipant(key, matchKey))[0]; }
        public void parseMatchParticipant(string teamKey, string seasonKey) { matchParticipant = JsonConvert.DeserializeObject<List<MatchParticipant>>(getMatchParticipant(teamKey, seasonKey))[0]; }
        public void parseMedia(string eventKey) { media = JsonConvert.DeserializeObject<List<Media>>(getMedia(eventKey))[0]; }
        public void parseRanking(string eventKey) { ranking = JsonConvert.DeserializeObject<List<Ranking>>(getRanking(eventKey))[0]; }
        public void parseRegion() { region = JsonConvert.DeserializeObject<List<Region>>(getRegion())[0]; }
        public void parseSeason() { season = JsonConvert.DeserializeObject<List<Season>>(getSeason())[0]; }
        public void parseTeam(string teamKey) { team = JsonConvert.DeserializeObject<List<Team>>(getTeam(teamKey))[0]; }
        public void parseTeam() { team = JsonConvert.DeserializeObject<List<Team>>(getTeam())[0]; }
        public void parseTeamSeasonRecord(string teamKey) { teamSeasonRecord = JsonConvert.DeserializeObject<List<TeamSeasonRecord>>(getTeamSeasonRecord(teamKey))[0]; }
        public void parseWebAnnoucement() { webAnnouncement = JsonConvert.DeserializeObject<List<WebAnnouncement>>(getWebAnnoucement())[0]; }
        public void parseTodaysEvents() {
            eventList = JsonConvert.DeserializeObject<List<Event>>(getTodaysEvents());
        }


        // === API Call For Each Class == //
        public string getAlliance(string eventKey) { return apiCall("event/" + eventKey + "/alliances"); } // returns a list of alliances
        public string getAward() { return null; } // no link allows direct updates
        public string getAwardRecipient(string eventKey) { return apiCall("event/" + eventKey + "/awards"); } // if given an event, returns a list of recipients
        public string getAwardRecipient(string teamKey, string seasonKey) { return apiCall("team/" + teamKey + "/awards/" + seasonKey); } // if given a team | season key for skystone is ___, returns a list of recipiants
        public string getEvent(string eventKey = "") { return apiCall("event/" + eventKey); } // if given no arguments, return a list of all events, else get one specific event
        public string getEventInsights(string eventKey) { return apiCall("event/" + eventKey + "/insights"); } // Q returns a list of insights on the event
        public string getEventLiveStream() { return apiCall("streams"); } // returns a list of all livestreams
        public string getEventLiveStream(string eventKey) { return apiCall("event/" + eventKey + "/streams"); } // returns a list of all the livestreams of that event
        public string getEventParticipant(string eventKey) { return apiCall("event/" + eventKey + "/teams"); } // returns a list of event participants
        public string getEventParticipant(string teamKey, string seasonKey) { return apiCall("team/" + teamKey + "/events/" + seasonKey); } // returns a teams event participants
        public string getEventType() { return apiCall("event-types"); } // returns a list of event types
        public string getLeague() { return apiCall("leagues"); } // Q returns a list of all ftc leagues
        public string getLeague(string leagueKey) { return apiCall("league/" + leagueKey); } // returns a league
        public string getLeagueDiv() { return apiCall("league/divisions"); } // Q returns a list of all ftc divs
        public string getMatch(string key, bool matchKey) { if (matchKey) return apiCall("match/" + key); else return apiCall("event/" + key + "/matches"); } // returns a list of all or one specific match
        public string getMatchDetails(string key, bool matchKey) { if (matchKey) return apiCall("match/" + key + "/details"); else return apiCall("event/" + key + "/matches/details"); } // returns a list of all or one specific match detail(s)
        public string getMatchParticipant(string key, bool matchKey) { if (matchKey) return apiCall("match/" + key + "/participants"); else return apiCall("event/" + key + "/matches/participants"); } // returns a list of particpants based on match or event
        public string getMatchParticipant(string teamKey, string seasonKey) { return apiCall("team/" + teamKey + "/matches/" + seasonKey); } // returns a list of a teams match participants
        public string getMedia(string eventKey) { return apiCall("event/" + eventKey + "/media"); } // returns a list of media for that event
        public string getRanking(string eventKey) { return apiCall("event/" + eventKey + "/ranking"); } // returns the rankings for that event
        public string getRanking(string teamKey, string seasonKey) { return apiCall("team/" + teamKey + "/results/" + seasonKey); } // returns the rankings for that team
        public string getRegion() { return apiCall("regions"); } // returns a list of all regions
        public string getSeason() { return apiCall("seasons"); } // returns a list of all seasons
        public string getTeam(string teamKey) { return apiCall("team/" + teamKey); } // returns a list of all teams or a specific team
        public string getTeam() { return apiCall("team"); }
        public string getTeamSeasonRecord(string teamKey) { return apiCall("team/" + teamKey + "/wlt"); } // returns a teams wlt record
        public string getWebAnnoucement() { return apiCall("web/announcements"); } // there was nothing in here idk man
        public string getEventPara(string para) { return apiCall("event?" + para); }
        public string getEventsOnDate(string date) { return apiCall("event?start_date=" + date + "&end_date=" + date + "&between=true"); }
        public string getEventsOnDate(int day, int mon, int year) { return getEventsOnDate(year.ToString() + "-" + mon.ToString() + "-" + day.ToString()); }
        public string getEventsBetweenDates(string date1, string date2) { return apiCall("event?start_date=" + date1 + "&end_date=" + date2 + "&between=true"); }
        public string getEventsBetweenDates(int day1, int mon1, int year1, int day2, int mon2, int year2) { return getEventsBetweenDates(year1.ToString() + "-" + mon1.ToString() + "-" + day1.ToString(), year2.ToString() + "-" + mon2.ToString() + "-" + day2.ToString()); }
        public string getTodaysDate() {
            DateTime moment = DateTime.Today;
            return moment.Year.ToString() + "-" + moment.Month.ToString() + "-" + moment.Day.ToString();
        }
        public string getTodaysEvents() { return getEventsOnDate(getTodaysDate()); }

        public List<Event> debugEvents() {
            eventList = JsonConvert.DeserializeObject<List<Event>>("[{\"event_key\":\"1920 - DE - DM1\",\"season_key\":\"1920\",\"region_key\":\"DE\",\"league_key\":null,\"event_code\":\"DM1\",\"first_event_code\":\"2019DEM2\",\"event_type_key\":\"LGMEET\",\"event_region_number\":0,\"division_key\":0,\"division_name\":null,\"event_name\":\"DE Meet #2\",\"start_date\":\"2020-01-10T00:00:00.000Z\",\"end_date\":\"2020-01-10T00:00:00.000Z\",\"week_key\":\"January\",\"city\":\"Dover\",\"state_prov\":\"DE\",\"country\":\"USA\",\"venue\":\"Dover High School\",\"website\":\"http://delawareftc.org\",\"time_zone\":\"\",\"is_active\":true,\"is_public\":true,\"active_tournament_level\":0,\"alliance_count\":4,\"field_count\":2,\"advance_spots\":0,\"advance_event\":\"\",\"data_source\":0},{\"event_key\":\"1920-IA-C5\",\"season_key\":\"1920\",\"region_key\":\"IA\",\"league_key\":null,\"event_code\":\"C5\",\"first_event_code\":\"IACORUM9\",\"event_type_key\":\"LGMEET\",\"event_region_number\":0,\"division_key\":0,\"division_name\":null,\"event_name\":\"Coruscant Meet 9\",\"start_date\":\"2020-01-10T00:00:00.000Z\",\"end_date\":\"2020-01-10T00:00:00.000Z\",\"week_key\":\"January\",\"city\":\"Cedar Rapids\",\"state_prov\":\"IA\",\"country\":\"USA\",\"venue\":\"Trinity Lutheran School\",\"website\":null,\"time_zone\":\"\",\"is_active\":true,\"is_public\":true,\"active_tournament_level\":0,\"alliance_count\":4,\"field_count\":2,\"advance_spots\":0,\"advance_event\":\"\",\"data_source\":0},{\"event_key\":\"1920-IA-M45\",\"season_key\":\"1920\",\"region_key\":\"IA\",\"league_key\":null,\"event_code\":\"M45\",\"first_event_code\":\"2019IAM44\",\"event_type_key\":\"LGMEET\",\"event_region_number\":0,\"division_key\":0,\"division_name\":null,\"event_name\":\"Coruscant_2020_01_11\",\"start_date\":\"2020-01-10T00:00:00.000Z\",\"end_date\":\"2020-01-10T00:00:00.000Z\",\"week_key\":\"January\",\"city\":\"Cedar Rapids\",\"state_prov\":\"IA\",\"country\":\"USA\",\"venue\":\"Trinity Lutheran School\",\"website\":null,\"time_zone\":\"\",\"is_active\":true,\"is_public\":true,\"active_tournament_level\":0,\"alliance_count\":4,\"field_count\":2,\"advance_spots\":0,\"advance_event\":\"\",\"data_source\":0},{\"event_key\":\"1920-NM-SPFQT\",\"season_key\":\"1920\",\"region_key\":\"NM\",\"league_key\":null,\"event_code\":\"SPFQT\",\"first_event_code\":\"NMSANQ\",\"event_type_key\":\"QUAL\",\"event_region_number\":0,\"division_key\":0,\"division_name\":null,\"event_name\":\"Sandia Park Qualifying Tournament\",\"start_date\":\"2020-01-10T00:00:00.000Z\",\"end_date\":\"2020-01-11T00:00:00.000Z\",\"week_key\":\"January\",\"city\":\"Sandia Park\",\"state_prov\":\"NM\",\"country\":\"USA\",\"venue\":\"Vista Grande Community Center\",\"website\":\"https://nmftc.org\",\"time_zone\":\"\",\"is_active\":true,\"is_public\":true,\"active_tournament_level\":0,\"alliance_count\":4,\"field_count\":2,\"advance_spots\":0,\"advance_event\":\"\",\"data_source\":0},{\"event_key\":\"1920-OH-DQ\",\"season_key\":\"1920\",\"region_key\":\"OH\",\"league_key\":null,\"event_code\":\"DQ\",\"first_event_code\":\"2019OHQ8\",\"event_type_key\":\"QUAL\",\"event_region_number\":0,\"division_key\":0,\"division_name\":null,\"event_name\":\"Dayton Qualifier\",\"start_date\":\"2020-01-10T00:00:00.000Z\",\"end_date\":\"2020-01-11T00:00:00.000Z\",\"week_key\":\"January\",\"city\":\"Springfield\",\"state_prov\":\"OH\",\"country\":\"USA\",\"venue\":\"Clark State Community College - Clark State Performing Arts Center\",\"website\":\"http://wpafbstem.com/pages/k12_FTC_overview.html\",\"time_zone\":\"\",\"is_active\":true,\"is_public\":true,\"active_tournament_level\":0,\"alliance_count\":4,\"field_count\":2,\"advance_spots\":0,\"advance_event\":\"\",\"data_source\":2}]");
            int i;
            for (i = 0; i < eventList.Count; i++)
            {
                eventList[i].BackgroundColor_ = Color.FromHex(_colors[i]);
            }
            return eventList;
        }

        public List<Team> debugTeams()
        {
            List<Team> temp = new List<Team>();
            temp.Add(updateTeam("3591"));
            return temp;
        }

        // === apiCall function === //
        public string apiCall(string path)
        {
            WebRequest request = WebRequest.Create(TOA_URL + path);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Headers["X-TOA-Key"] = RootPage.getSecrets().apiKey;
            request.Headers["X-Application-Origin"] = "RoboScout";

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                reader.Close();
                dataStream.Close();
                response.Close();
                return responseFromServer;
            }
            catch { return ""; }
        }
        public static void sqlPush(Report report) //creates a row based on report
        {
            string connection_string = @"server=" + RootPage.getSecrets().server + ";userid=" + RootPage.getSecrets().userid + ";password=" + RootPage.getSecrets().password + ";database=" + RootPage.getSecrets().database;
            var con = new MySqlConnection(connection_string);
            string command = "INSERT INTO reports " +
                "(team_key, report_key, event_key, auto_points, auto_skystone_delv, auto_skystone_delv_points, auto_stone_delv, auto_stone_delv_points, auto_repositioning, " +
                "auto_placing, auto_placing_points, auto_navigating, tele_points, tele_stone_delv, tele_stone_delv_points, tele_stone_placing, tele_stone_placing_points, end_points, end_tallest_sky, end_tallest_sky_points, end_capped, end_capped_lv, end_capping_points, end_foundation, parking, penalties)"
                + " VALUES ("
                + report.team_key + ", "
                + report.report_key + ", "
                + report.event_key + ", "
                + report.auto_points + ", "
                + report.auto_skystone_delv + ", "
                + report.auto_skystone_delv_points + ", "
                + report.auto_stone_delv + ", "
                + report.auto_stone_delv_points + ", "
                + report.auto_repositioning + ", "
                + report.auto_placing + ", "
                + report.auto_placing_points + ", "
                + report.auto_navigating + ", "
                + report.tele_points + ", "
                + report.tele_stone_delv + ", "
                + report.tele_stone_delv_points + ", "
                + report.tele_stone_placing + ", "
                + report.tele_stone_placing_points + ", "
                + report.end_points + ", "
                + report.end_tallest_sky + ", "
                + report.end_tallest_sky_points + ", "
                + report.end_capped + ", "
                + report.end_capped_lv + ", "
                + report.end_capping_points + ", "
                + report.end_foundation + ", "
                + report.parking + ", "
                + report.penalties + ");";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(command, con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }
        public Report sqlCallByTeam(string teamkey) //return the first report by teamkey
        {
            string sqlCommand = "SELECT * from reports WHERE team_key == " + teamkey + ";";
            string connection_string = "server=" + RootPage.getSecrets().server + ";userid=" + RootPage.getSecrets().userid + ";password=" + RootPage.getSecrets().password + ";database=" + RootPage.getSecrets().database;
            var con = new MySqlConnection(connection_string);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlCommand, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Report report = null;
            while(rdr.Read())
            {
                report = assignReport(rdr);
            }
            rdr.Close();
            con.Close();
            rdr.Dispose();
            con.Dispose();

            return report;
        }
        public Report sqlCallByEvent(string eventkey) //return the first report by eventkey
        {
            string sqlCommand = "SELECT * from reports WHERE event_key == " + eventkey;
            string connection_string = @"server=" + RootPage.getSecrets().server + ";userid=" + RootPage.getSecrets().userid + ";password=" + RootPage.getSecrets().password + ";database=" + RootPage.getSecrets().database;
            var con = new MySqlConnection(connection_string);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlCommand, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Report report = null;
            while (rdr.Read())
            {
                report = assignReport(rdr);
            }
            rdr.Close();
            con.Close();
            rdr.Dispose();
            con.Dispose();

            return report;
        }
        public List<Report> sqlCallsByTeam(int teamkey) //return multiple reports as a list
        {
            string sqlCommand= "SELECT * from reports WHERE team_key == " + teamkey;
            string connection_string = @"server=" + RootPage.getSecrets().server + ";userid=" + RootPage.getSecrets().userid + ";password=" + RootPage.getSecrets().password + ";database=" + RootPage.getSecrets().database;
            var con = new MySqlConnection(connection_string);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlCommand, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Report> reports = null;
            while (rdr.Read())
            {
                reports.Add(assignReport(rdr));
            }
            rdr.Close();
            con.Close();
            rdr.Dispose();
            con.Dispose();

            return reports;
        }
        public List<Report> sqlCallsByEvent(string eventkey) //return multiple reports as a list
        {
            string sqlCommand = "SELECT * from reports WHERE event_key == " + eventkey;
            string connection_string = @"server=" + RootPage.getSecrets().server + ";userid=" + RootPage.getSecrets().userid + ";password=" + RootPage.getSecrets().password + ";database=" + RootPage.getSecrets().database;
            var con = new MySqlConnection(connection_string);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlCommand, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Report> reports = null;
            while (rdr.Read())
            {
                reports.Add(assignReport(rdr));
            }
            rdr.Close();
            con.Close();
            rdr.Dispose();
            con.Dispose();

            return reports;
        }
        public static Report assignReport(MySqlDataReader reader) //creates a report based on returned data
        {
            Report report = new Report();
            report.team_key = (int)reader[0];
            report.report_key = (int)reader[1];
            report.event_key = (string)reader[2];
            report.auto_points = (int)reader[3];
            report.auto_skystone_delv = (int)reader[4];
            report.auto_skystone_delv_points = (int)reader[5];
            report.auto_stone_delv = (int)reader[6];
            report.auto_stone_delv_points = (int)reader[7];
            report.auto_repositioning = (bool)reader[8];
            report.auto_placing = (int)reader[9];
            report.auto_placing_points = (int)reader[10];
            report.auto_navigating = (bool)reader[11];
            report.tele_points = (int)reader[12];
            report.tele_stone_delv = (int)reader[13];
            report.tele_stone_delv_points = (int)reader[14];
            report.tele_stone_placing = (int)reader[15];
            report.tele_stone_placing_points = (int)reader[16];
            report.end_points = (int)reader[17];
            report.end_tallest_sky = (int)reader[18];
            report.end_tallest_sky_points = (int)reader[19];
            report.end_capped = (bool)reader[20];
            report.end_capped_lv = (int)reader[21];
            report.end_capping_points = (bool)reader[22];
            report.end_foundation = (bool)reader[23];
            report.parking = (bool)reader[24];
            report.penalties = (int)reader[25];
            return report;
        }
    }
}
