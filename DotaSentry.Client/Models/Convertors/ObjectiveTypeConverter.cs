using System;
using System.Collections.Generic;
using System.Text;
using DotaSentry.Client.Models.MatchEntities;
using Newtonsoft.Json;

namespace DotaSentry.Client.Models.Convertors
{
    internal class ObjectiveTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ObjectiveType) || t == typeof(ObjectiveType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "CHAT_MESSAGE_AEGIS":
                    return ObjectiveType.ChatMessageAegis;
                case "CHAT_MESSAGE_FIRSTBLOOD":
                    return ObjectiveType.ChatMessageFirstblood;
                case "CHAT_MESSAGE_ROSHAN_KILL":
                    return ObjectiveType.ChatMessageRoshanKill;
                case "building_kill":
                    return ObjectiveType.BuildingKill;
            }
            throw new Exception("Cannot unmarshal type ObjectiveType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ObjectiveType)untypedValue;
            switch (value)
            {
                case ObjectiveType.ChatMessageAegis:
                    serializer.Serialize(writer, "CHAT_MESSAGE_AEGIS");
                    return;
                case ObjectiveType.ChatMessageFirstblood:
                    serializer.Serialize(writer, "CHAT_MESSAGE_FIRSTBLOOD");
                    return;
                case ObjectiveType.ChatMessageRoshanKill:
                    serializer.Serialize(writer, "CHAT_MESSAGE_ROSHAN_KILL");
                    return;
                case ObjectiveType.BuildingKill:
                    serializer.Serialize(writer, "building_kill");
                    return;
            }
            throw new Exception("Cannot marshal type ObjectiveType");
        }

        public static readonly ObjectiveTypeConverter Singleton = new ObjectiveTypeConverter();
    }
}
