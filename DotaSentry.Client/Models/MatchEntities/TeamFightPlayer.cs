using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotaSentry.Client.Models.MatchEntities
{
    public class TeamFightPlayer
    {
        [JsonProperty("deaths_pos")]
        public Dictionary<string, Dictionary<string, long>> DeathsPos { get; set; }

        [JsonProperty("ability_uses")]
        public Dictionary<string, long> AbilityUses { get; set; }

        //[JsonProperty("ability_targets")]
        //public MyWordCounts AbilityTargets { get; set; }

        [JsonProperty("item_uses")]
        public Dictionary<string, long> ItemUses { get; set; }

        //[JsonProperty("killed")]
        //public MorphlingAdaptiveStrikeAgi Killed { get; set; }

        [JsonProperty("deaths")]
        public long Deaths { get; set; }

        [JsonProperty("buybacks")]
        public long Buybacks { get; set; }

        [JsonProperty("damage")]
        public long Damage { get; set; }

        [JsonProperty("healing")]
        public long Healing { get; set; }

        [JsonProperty("gold_delta")]
        public long GoldDelta { get; set; }

        [JsonProperty("xp_delta")]
        public long XpDelta { get; set; }

        [JsonProperty("xp_start")]
        public long XpStart { get; set; }

        [JsonProperty("xp_end")]
        public long XpEnd { get; set; }
    }
}
