using System;
using System.Collections.Generic;
using System.Text;
using DotaSentry.Client.Models.MatchEntities;
using Newtonsoft.Json;

namespace DotaSentry.Client.Models.Convertors
{
    internal class PrefabConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Prefab) || t == typeof(Prefab?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "courier":
                    return Prefab.Courier;
                case "taunt":
                    return Prefab.Taunt;
                case "tool":
                    return Prefab.Tool;
                case "wearable":
                    return Prefab.Wearable;
            }
            throw new Exception("Cannot unmarshal type Prefab");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Prefab)untypedValue;
            switch (value)
            {
                case Prefab.Courier:
                    serializer.Serialize(writer, "courier");
                    return;
                case Prefab.Taunt:
                    serializer.Serialize(writer, "taunt");
                    return;
                case Prefab.Tool:
                    serializer.Serialize(writer, "tool");
                    return;
                case Prefab.Wearable:
                    serializer.Serialize(writer, "wearable");
                    return;
            }
            throw new Exception("Cannot marshal type Prefab");
        }

        public static readonly PrefabConverter Singleton = new PrefabConverter();
    }
}
