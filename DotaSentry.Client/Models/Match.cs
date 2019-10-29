using System;
using System.Collections.Generic;
using DotaSentry.Client.Models.MatchEntities;
using Newtonsoft.Json;

namespace DotaSentry.Client.Models
{
    public class Match
    {
        [JsonProperty("match_id")]
        public long MatchId { get; set; }

        [JsonProperty("barracks_status_dire")]
        public long BarracksStatusDire { get; set; }

        [JsonProperty("barracks_status_radiant")]
        public long BarracksStatusRadiant { get; set; }

        [JsonProperty("chat")]
        public List<Chat> Chat { get; set; }

        [JsonProperty("cluster")]
        public long Cluster { get; set; }

        [JsonProperty("cosmetics")]
        public Dictionary<string, long> Cosmetics { get; set; }

        [JsonProperty("dire_score")]
        public long DireScore { get; set; }

        [JsonProperty("dire_team_id")]
        public long DireTeamId { get; set; }

        [JsonProperty("draft_timings")]
        public List<DraftTiming> DraftTimings { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("engine")]
        public long Engine { get; set; }

        [JsonProperty("first_blood_time")]
        public long FirstBloodTime { get; set; }

        [JsonProperty("game_mode")]
        public long GameMode { get; set; }

        [JsonProperty("human_players")]
        public long HumanPlayers { get; set; }

        [JsonProperty("leagueid")]
        public long LeagueId { get; set; }

        [JsonProperty("lobby_type")]
        public long LobbyType { get; set; }

        [JsonProperty("match_seq_num")]
        public long MatchSeqNum { get; set; }

        [JsonProperty("negative_votes")]
        public long NegativeVotes { get; set; }

        [JsonProperty("objectives")]
        public List<Objective> Objectives { get; set; }

        [JsonProperty("picks_bans")]
        public List<PicksBan> PicksBans { get; set; }

        [JsonProperty("positive_votes")]
        public long PositiveVotes { get; set; }

        [JsonProperty("radiant_gold_adv")]
        public List<long> RadiantGoldAdv { get; set; }

        [JsonProperty("radiant_score")]
        public long RadiantScore { get; set; }

        [JsonProperty("radiant_team_id")]
        public long RadiantTeamId { get; set; }

        [JsonProperty("radiant_win")]
        public bool RadiantWin { get; set; }

        [JsonProperty("radiant_xp_adv")]
        public List<long> RadiantXpAdv { get; set; }

        [JsonProperty("skill")]
        public object Skill { get; set; }

        [JsonProperty("start_time")]
        public long StartTime { get; set; }

        [JsonProperty("teamfights")]
        public List<TeamFight> TeamFights { get; set; }

        [JsonProperty("tower_status_dire")]
        public long TowerStatusDire { get; set; }

        [JsonProperty("tower_status_radiant")]
        public long TowerStatusRadiant { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("replay_salt")]
        public long ReplaySalt { get; set; }

        [JsonProperty("series_id")]
        public long SeriesId { get; set; }

        [JsonProperty("series_type")]
        public long SeriesType { get; set; }

        [JsonProperty("league")]
        public League League { get; set; }

        [JsonProperty("radiant_team")]
        public TeamBase RadiantTeam { get; set; }

        [JsonProperty("dire_team")]
        public TeamBase DireTeam { get; set; }

        [JsonProperty("players")]
        public List<TemperaturesPlayer> Players { get; set; }

        [JsonProperty("patch")]
        public long Patch { get; set; }

        [JsonProperty("region")]
        public long Region { get; set; }

        //[JsonProperty("all_word_counts")]
        //public AllWordCounts AllWordCounts { get; set; }

        //[JsonProperty("my_word_counts")]
        //public MyWordCounts MyWordCounts { get; set; }

        [JsonProperty("throw")]
        public long Throw { get; set; }

        [JsonProperty("loss")]
        public long Loss { get; set; }

        [JsonProperty("replay_url")]
        public Uri ReplayUrl { get; set; }
    }
}
