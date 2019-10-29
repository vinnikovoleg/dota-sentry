using System;
using System.Collections.Generic;
using System.Text;
using DotaSentry.Client.Models.MatchEntities;
using Newtonsoft.Json;

namespace DotaSentry.Client.Models.Convertors
{
    internal class MaxHeroHitTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(MaxHeroHitType) || t == typeof(MaxHeroHitType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "max_hero_hit")
            {
                return MaxHeroHitType.MaxHeroHit;
            }
            throw new Exception("Cannot unmarshal type MaxHeroHitType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (MaxHeroHitType)untypedValue;
            if (value == MaxHeroHitType.MaxHeroHit)
            {
                serializer.Serialize(writer, "max_hero_hit");
                return;
            }
            throw new Exception("Cannot marshal type MaxHeroHitType");
        }

        public static readonly MaxHeroHitTypeConverter Singleton = new MaxHeroHitTypeConverter();
    }
}
