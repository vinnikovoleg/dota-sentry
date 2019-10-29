using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotaSentry.Client.Models.MatchEntities
{
    public class TemperaturesPlayer
    {
        [JsonProperty("match_id")]
        public long MatchId { get; set; }

        [JsonProperty("player_slot")]
        public long PlayerSlot { get; set; }

        //[JsonProperty("ability_targets")]
        //public AbilityTargets AbilityTargets { get; set; }

        [JsonProperty("ability_upgrades_arr")]
        public List<long> AbilityUpgradesArr { get; set; }

        [JsonProperty("ability_uses")]
        public Dictionary<string, long> AbilityUses { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("actions")]
        public Dictionary<string, long> Actions { get; set; }

        [JsonProperty("additional_units")]
        public object AdditionalUnits { get; set; }

        [JsonProperty("assists")]
        public long Assists { get; set; }

        [JsonProperty("backpack_0")]
        public long Backpack0 { get; set; }

        [JsonProperty("backpack_1")]
        public long Backpack1 { get; set; }

        [JsonProperty("backpack_2")]
        public long Backpack2 { get; set; }

        [JsonProperty("buyback_log")]
        public List<BuybackLog> BuybackLog { get; set; }

        [JsonProperty("camps_stacked")]
        public long CampsStacked { get; set; }

        [JsonProperty("connection_log")]
        public List<object> ConnectionLog { get; set; }

        [JsonProperty("creeps_stacked")]
        public long CreepsStacked { get; set; }

        [JsonProperty("damage")]
        public Dictionary<string, long> Damage { get; set; }

        [JsonProperty("damage_inflictor")]
        public Dictionary<string, long> DamageInflictor { get; set; }

        [JsonProperty("damage_inflictor_received")]
        public Dictionary<string, long> DamageInflictorReceived { get; set; }

        [JsonProperty("damage_taken")]
        public Dictionary<string, long> DamageTaken { get; set; }

        //[JsonProperty("damage_targets")]
        //public DamageTargets DamageTargets { get; set; }

        [JsonProperty("deaths")]
        public long Deaths { get; set; }

        [JsonProperty("denies")]
        public long Denies { get; set; }

        [JsonProperty("dn_t")]
        public List<long> DnT { get; set; }

        [JsonProperty("firstblood_claimed")]
        public long FirstBloodClaimed { get; set; }

        [JsonProperty("gold")]
        public long Gold { get; set; }

        [JsonProperty("gold_per_min")]
        public long GoldPerMin { get; set; }

        [JsonProperty("gold_reasons")]
        public Dictionary<string, long> GoldReasons { get; set; }

        [JsonProperty("gold_spent")]
        public long GoldSpent { get; set; }

        [JsonProperty("gold_t")]
        public List<long> GoldT { get; set; }

        [JsonProperty("hero_damage")]
        public long HeroDamage { get; set; }

        [JsonProperty("hero_healing")]
        public long HeroHealing { get; set; }

        [JsonProperty("hero_hits")]
        public Dictionary<string, long> HeroHits { get; set; }

        [JsonProperty("hero_id")]
        public long HeroId { get; set; }

        [JsonProperty("item_0")]
        public long Item0 { get; set; }

        [JsonProperty("item_1")]
        public long Item1 { get; set; }

        [JsonProperty("item_2")]
        public long Item2 { get; set; }

        [JsonProperty("item_3")]
        public long Item3 { get; set; }

        [JsonProperty("item_4")]
        public long Item4 { get; set; }

        [JsonProperty("item_5")]
        public long Item5 { get; set; }

        [JsonProperty("item_uses")]
        public Dictionary<string, long> ItemUses { get; set; }

        [JsonProperty("kill_streaks")]
        public Dictionary<string, long> KillStreaks { get; set; }

        [JsonProperty("killed")]
        public Dictionary<string, long> Killed { get; set; }

        [JsonProperty("killed_by")]
        public Dictionary<string, long> KilledBy { get; set; }

        [JsonProperty("kills")]
        public long Kills { get; set; }

        [JsonProperty("kills_log")]
        public List<KillsLogElement> KillsLog { get; set; }

        [JsonProperty("lane_pos")]
        public Dictionary<string, Dictionary<string, long>> LanePos { get; set; }

        [JsonProperty("last_hits")]
        public long LastHits { get; set; }

        [JsonProperty("leaver_status")]
        public long LeaverStatus { get; set; }

        [JsonProperty("level")]
        public long Level { get; set; }

        [JsonProperty("lh_t")]
        public List<long> LhT { get; set; }

        [JsonProperty("life_state")]
        public Dictionary<string, long> LifeState { get; set; }

        [JsonProperty("max_hero_hit")]
        public MaxHeroHit MaxHeroHit { get; set; }

        [JsonProperty("multi_kills")]
        public Dictionary<string, long> MultiKills { get; set; }

        [JsonProperty("obs")]
        public Dictionary<string, Dictionary<string, long>> Obs { get; set; }

        [JsonProperty("obs_left_log")]
        public List<ObsLeftLogElement> ObsLeftLog { get; set; }

        [JsonProperty("obs_log")]
        public List<ObsLeftLogElement> ObsLog { get; set; }

        [JsonProperty("obs_placed")]
        public long ObsPlaced { get; set; }

        [JsonProperty("party_id")]
        public long PartyId { get; set; }

        [JsonProperty("party_size")]
        public long PartySize { get; set; }

        [JsonProperty("performance_others")]
        public object PerformanceOthers { get; set; }

        [JsonProperty("permanent_buffs")]
        public List<PermanentBuff> PermanentBuffs { get; set; }

        [JsonProperty("pings")]
        public long Pings { get; set; }

        [JsonProperty("pred_vict")]
        public bool PredVict { get; set; }

        [JsonProperty("purchase")]
        public Dictionary<string, long?> Purchase { get; set; }

        [JsonProperty("purchase_log")]
        public List<KillsLogElement> PurchaseLog { get; set; }

        [JsonProperty("randomed")]
        public bool Randomed { get; set; }

        [JsonProperty("repicked")]
        public object Repicked { get; set; }

        [JsonProperty("roshans_killed")]
        public long RoshansKilled { get; set; }

        [JsonProperty("rune_pickups")]
        public long RunePickups { get; set; }

        [JsonProperty("runes")]
        public Dictionary<string, long> Runes { get; set; }

        [JsonProperty("runes_log")]
        public List<RunesLog> RunesLog { get; set; }

        [JsonProperty("sen")]
        public Dictionary<string, Dictionary<string, long>> Sen { get; set; }

        [JsonProperty("sen_left_log")]
        public List<ObsLeftLogElement> SenLeftLog { get; set; }

        [JsonProperty("sen_log")]
        public List<ObsLeftLogElement> SenLog { get; set; }

        [JsonProperty("sen_placed")]
        public long SenPlaced { get; set; }

        [JsonProperty("stuns")]
        public double Stuns { get; set; }

        [JsonProperty("teamfight_participation")]
        public double TeamfightParticipation { get; set; }

        [JsonProperty("times")]
        public List<long> Times { get; set; }

        [JsonProperty("tower_damage")]
        public long TowerDamage { get; set; }

        [JsonProperty("towers_killed")]
        public long TowersKilled { get; set; }

        [JsonProperty("xp_per_min")]
        public long XpPerMin { get; set; }

        [JsonProperty("xp_reasons")]
        public Dictionary<string, long> XpReasons { get; set; }

        [JsonProperty("xp_t")]
        public List<long> XpT { get; set; }

        [JsonProperty("personaname")]
        public string PersonaName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("last_login")]
        public DateTimeOffset? LastLogin { get; set; }

        [JsonProperty("radiant_win")]
        public bool RadiantWin { get; set; }

        [JsonProperty("start_time")]
        public long StartTime { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("cluster")]
        public long Cluster { get; set; }

        [JsonProperty("lobby_type")]
        public long LobbyType { get; set; }

        [JsonProperty("game_mode")]
        public long GameMode { get; set; }

        [JsonProperty("is_contributor")]
        public bool IsContributor { get; set; }

        [JsonProperty("patch")]
        public long Patch { get; set; }

        [JsonProperty("region")]
        public long Region { get; set; }

        [JsonProperty("isRadiant")]
        public bool IsRadiant { get; set; }

        [JsonProperty("win")]
        public long Win { get; set; }

        [JsonProperty("lose")]
        public long Lose { get; set; }

        [JsonProperty("total_gold")]
        public long TotalGold { get; set; }

        [JsonProperty("total_xp")]
        public long TotalXp { get; set; }

        [JsonProperty("kills_per_min", NullValueHandling = NullValueHandling.Ignore)]
        public double? KillsPerMin { get; set; }

        [JsonProperty("kda")]
        public long Kda { get; set; }

        [JsonProperty("abandons")]
        public long Abandons { get; set; }

        [JsonProperty("neutral_kills")]
        public long NeutralKills { get; set; }

        [JsonProperty("tower_kills")]
        public long TowerKills { get; set; }

        [JsonProperty("courier_kills")]
        public long CourierKills { get; set; }

        [JsonProperty("lane_kills")]
        public long LaneKills { get; set; }

        [JsonProperty("hero_kills")]
        public long HeroKills { get; set; }

        [JsonProperty("observer_kills")]
        public long ObserverKills { get; set; }

        [JsonProperty("sentry_kills")]
        public long SentryKills { get; set; }

        [JsonProperty("roshan_kills")]
        public long RoshanKills { get; set; }

        [JsonProperty("necronomicon_kills")]
        public long NecronomiconKills { get; set; }

        [JsonProperty("ancient_kills")]
        public long AncientKills { get; set; }

        [JsonProperty("buyback_count")]
        public long BuybackCount { get; set; }

        [JsonProperty("observer_uses")]
        public long ObserverUses { get; set; }

        [JsonProperty("sentry_uses")]
        public long SentryUses { get; set; }

        [JsonProperty("lane_efficiency")]
        public double LaneEfficiency { get; set; }

        [JsonProperty("lane_efficiency_pct")]
        public long LaneEfficiencyPct { get; set; }

        [JsonProperty("lane")]
        public long Lane { get; set; }

        [JsonProperty("lane_role")]
        public long LaneRole { get; set; }

        [JsonProperty("is_roaming")]
        public bool IsRoaming { get; set; }

        [JsonProperty("purchase_time")]
        public Dictionary<string, long?> PurchaseTime { get; set; }

        [JsonProperty("first_purchase_time")]
        public Dictionary<string, long?> FirstPurchaseTime { get; set; }

        [JsonProperty("item_win")]
        public Dictionary<string, long?> ItemWin { get; set; }

        [JsonProperty("item_usage")]
        public Dictionary<string, long?> ItemUsage { get; set; }

        [JsonProperty("purchase_ward_observer", NullValueHandling = NullValueHandling.Ignore)]
        public long? PurchaseWardObserver { get; set; }

        [JsonProperty("purchase_ward_sentry", NullValueHandling = NullValueHandling.Ignore)]
        public long? PurchaseWardSentry { get; set; }

        [JsonProperty("purchase_tpscroll")]
        public long PurchaseTpscroll { get; set; }

        [JsonProperty("actions_per_min")]
        public long ActionsPerMin { get; set; }

        [JsonProperty("life_state_dead")]
        public long LifeStateDead { get; set; }

        [JsonProperty("rank_tier")]
        public long? RankTier { get; set; }

        [JsonProperty("cosmetics")]
        public List<Cosmetic> Cosmetics { get; set; }

        [JsonProperty("benchmarks")]
        public Benchmarks Benchmarks { get; set; }
    }
}
