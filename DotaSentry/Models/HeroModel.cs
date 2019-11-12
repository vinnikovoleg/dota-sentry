using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DotaSentry.Models
{
    public class HeroModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        [JsonProperty("localized_name")]
        public string LocalizedName { get; set; }

        public string Logo { get; set; }
    }
}
