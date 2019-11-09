using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DotaSentry.Business.Models
{
    public class Hero
    {
        public long Id { get; set; }

        public string Name { get; set; }

        [JsonProperty("localized_name")]
        public string LocalizedName { get; set; }

        public string Logo { get; set; }
    }
}
