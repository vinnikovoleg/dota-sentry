using System;
using System.Collections.Generic;
using System.Text;
using DotaSentry.Client.Models.MatchEntities;
using Newtonsoft.Json;

namespace DotaSentry.Client.Models.Convertors
{
    internal class ChatTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ChatType) || t == typeof(ChatType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "chat":
                    return ChatType.Chat;
                case "chatwheel":
                    return ChatType.Chatwheel;
            }
            throw new Exception("Cannot unmarshal type ChatType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ChatType)untypedValue;
            switch (value)
            {
                case ChatType.Chat:
                    serializer.Serialize(writer, "chat");
                    return;
                case ChatType.Chatwheel:
                    serializer.Serialize(writer, "chatwheel");
                    return;
            }
            throw new Exception("Cannot marshal type ChatType");
        }

        public static readonly ChatTypeConverter Singleton = new ChatTypeConverter();
    }
}
