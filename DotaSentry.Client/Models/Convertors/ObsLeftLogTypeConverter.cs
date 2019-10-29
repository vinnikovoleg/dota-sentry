using System;
using System.Collections.Generic;
using System.Text;
using DotaSentry.Client.Models.MatchEntities;
using Newtonsoft.Json;

namespace DotaSentry.Client.Models.Convertors
{
    internal class ObsLeftLogTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ObsLeftLogType) || t == typeof(ObsLeftLogType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "obs_left_log":
                    return ObsLeftLogType.ObsLeftLog;
                case "obs_log":
                    return ObsLeftLogType.ObsLog;
                case "sen_left_log":
                    return ObsLeftLogType.SenLeftLog;
                case "sen_log":
                    return ObsLeftLogType.SenLog;
            }
            throw new Exception("Cannot unmarshal type ObsLeftLogType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ObsLeftLogType)untypedValue;
            switch (value)
            {
                case ObsLeftLogType.ObsLeftLog:
                    serializer.Serialize(writer, "obs_left_log");
                    return;
                case ObsLeftLogType.ObsLog:
                    serializer.Serialize(writer, "obs_log");
                    return;
                case ObsLeftLogType.SenLeftLog:
                    serializer.Serialize(writer, "sen_left_log");
                    return;
                case ObsLeftLogType.SenLog:
                    serializer.Serialize(writer, "sen_log");
                    return;
            }
            throw new Exception("Cannot marshal type ObsLeftLogType");
        }

        public static readonly ObsLeftLogTypeConverter Singleton = new ObsLeftLogTypeConverter();
    }
}
